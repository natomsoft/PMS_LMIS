Public Class FRM_MTNSubClass

    Public Sub New()
        InitializeComponent()
        Me.MdiParent = FRM_GLBMain
        LoadForm()
    End Sub

    Dim RemovedIDs As New List(Of String)
    Private Sub DGV_Beds_UserDeletingRow(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowCancelEventArgs) Handles DGV_SubClass.UserDeletingRow
        If DGV_SubClass.Rows.Count <> 0 Then RemovedIDs.Add(e.Row.Cells("ClassificationID").Value)
    End Sub
#Region "Utilities"

    Private Sub LoadForm()
        Try
            Dim LMISDb As New LMISEntities
            CMBX_Cat.DataSource = From C In LMISDb.Categories Select C
            CMBX_Cat.DisplayMember = "Name"
            CMBX_Cat.ValueMember = "ID"
            CMBX_Cat.AutoCompleteSource = AutoCompleteSource.ListItems
            CMBX_Cat.SelectedItem = Nothing
            ClearForm(True)
        Catch ex As Exception
            MessageBox.Show("Error:" & vbCrLf & ex.Message & Utility.InnerExecption(ex), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Function ValidateDataForm() As Boolean
        ERP_Error.Clear()
        Dim No_Error As Boolean = True
        If CMBX_Class.SelectedIndex = -1 And CMBX_Class.Text = String.Empty Then
            ERP_Error.SetError(CMBX_Class, "Please select or type appropriate 'Classification'")
            No_Error = False
        ElseIf CMBX_Class.SelectedItem IsNot Nothing Then
            If (From I In (New LMISEntities).Classifications Where I.Name = TBX_ChangeToName.Text Select I).Count > 0 Then
                ERP_Error.SetError(TBX_ChangeToName, "Classification '" & TBX_ChangeToName.Text & "' already exists")
                No_Error = False
            End If
        End If

        If Not DGV_SubClass.ValidateData() Then
            ERP_Error.SetError(DGV_SubClass, "Please correct your errors in the table")
            No_Error = False
        End If
        Return No_Error
    End Function

    Private Function SaveData() As Boolean
        Dim DeleteException As Boolean = False
        Try
            Dim LMISDb As New LMISEntities
            Dim ItemClass As Classification
            Dim ItemClassID As Integer = CMBX_Class.SelectedValue
            Dim ItemClassCheck = (From IC In LMISDb.Classifications Where IC.ID = ItemClassID Select IC)
            If ItemClassCheck.Count > 0 Then
                ItemClass = ItemClassCheck.First
                If TBX_ChangeToName.Text <> String.Empty Then ItemClass.Name = TBX_ChangeToName.Text
            Else
                ItemClass = New Classification With {
                    .CategoryID = CMBX_Cat.SelectedValue
                    }

                ItemClass.Name = CMBX_Class.Text
                LMISDb.Classifications.AddObject(ItemClass)
            End If
            LMISDb.SaveChanges()
            For Each ICC As DataGridViewRow In DGV_SubClass.Rows
                If Not ICC.IsNewRow Then
                    If Not DGV_SubClass.IsInDatabase(ICC) Then
                        LMISDb.InventoryCategories.AddObject(New InventoryCategory With {
                                .Name = ICC.Cells("Classification").Value(),
                                .ClassificationID = ItemClass.ID})
                    Else
                        Dim ICCID As Integer = ICC.Cells("ClassificationID").Value
                        With (From SRT In LMISDb.InventoryCategories Where SRT.ID = ICCID Select SRT).First
                            .Name = ICC.Cells("Classification").Value()
                        End With
                    End If
                End If
            Next
            LMISDb.SaveChanges()
            For Each RDID In RemovedIDs
                Dim IDDel As String = RDID

                Dim RDeletedD = From RD In LMISDb.InventoryCategories Where RD.ID = IDDel Select RD
                If RDeletedD.Count > 0 Then
                    LMISDb.InventoryCategories.DeleteObject(RDeletedD.First)
                    Try
                        LMISDb.SaveChanges()
                    Catch ex As Exception
                        DeleteException = True
                        MsgBox("Can not delete Sub-classification '" & RDeletedD.First.Name & "', because it has been used on other parts of the database")
                    End Try
                End If
            Next
            Return True
        Catch ex As Exception
            If Not DeleteException Then
                MessageBox.Show("Error: In Saving Data" & vbCrLf & ex.Message & Utility.InnerExecption(ex), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return False
            Else
                Return True
            End If
        End Try
        Return False
    End Function

    Private Sub ClearForm(ByVal CatalogueClear As Boolean)
        If CatalogueClear Then
            CMBX_Class.Text = ""
            CMBX_Class.SelectedItem = Nothing
        End If
        DGV_SubClass.Rows.Clear()
    End Sub

    Private Sub ChangeItem(ByVal CatalogryID As String)
        ClearForm(False)
        Dim LMISDb As New LMISEntities
        ' MsgBox(CatalogryID)
        Dim Categorys = From IC In LMISDb.Classifications Where IC.ID = CatalogryID Select IC
        If Categorys.Count > 0 Then
            For Each ICClassi In (From ICC In LMISDb.InventoryCategories Where ICC.ClassificationID = CatalogryID Select ICC)
                Dim NewRow = DGV_SubClass.Rows(DGV_SubClass.Rows.Add())
                NewRow.Cells("Classification").Value = ICClassi.Name
                NewRow.Cells("ClassificationID").Value = ICClassi.ID
                DGV_SubClass.IsInDatabase(NewRow) = True
            Next
        End If
    End Sub

#End Region

#Region "Events"

    Private Sub FRM_GotFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.GotFocus
        FRM_GLBMain.TLSL_MainStatus.Text = "Ready"
    End Sub

    Private Sub BTN_Close_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTN_Close.Click
        Me.Close()
    End Sub

    Private Sub BTN_Save_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTN_Save.Click
        If ValidateDataForm() Then
            If SaveData() Then
                MessageBox.Show("  Data Saved    ", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                LoadForm()
            Else
                MessageBox.Show("  Data NOT Saved    ", "Error in Saving", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End If
    End Sub

    Private Sub CMBX_ItemCatalogue_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBX_Class.SelectedIndexChanged
        If CMBX_Class.ValueMember <> String.Empty Then ChangeItem(CMBX_Class.SelectedValue)
        RemovedIDs.Clear()
    End Sub

    Private Sub CMBX_ItemCatalogue_textChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBX_Class.LostFocus
        If CMBX_Class.SelectedValue Is Nothing Then
            ClearForm(False)
        End If
    End Sub

    Private Sub FRM_ItemAddNew_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        DGV_SubClass.initMe(DGV_GTypes.CategoryOnly)
    End Sub

#End Region

    Private Sub CMBX_Cat_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBX_Cat.SelectedIndexChanged, CMBX_Cat.TextChanged
        If CMBX_Cat.SelectedItem IsNot Nothing And CMBX_Cat.ValueMember <> String.Empty Then
            Dim LMISDb As New LMISEntities
            CMBX_Class.Enabled = True
            Dim CatID As Integer = CMBX_Cat.SelectedValue
            CMBX_Class.DataSource = From C In LMISDb.Classifications Where C.CategoryID = CatID Select C
            CMBX_Class.DisplayMember = "Name"
            CMBX_Class.ValueMember = "ID"
            CMBX_Class.AutoCompleteSource = AutoCompleteSource.ListItems
        Else
            CMBX_Class.Enabled = False
            CMBX_Class.DataSource = Nothing
        End If
    End Sub
End Class

