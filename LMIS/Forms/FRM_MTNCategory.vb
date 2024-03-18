Public Class FRM_MTNCategory

    Public Sub New()
        InitializeComponent()
        Me.MdiParent = FRM_GLBMain
        LoadForm()
    End Sub
    Dim RemovedIDs As New List(Of String)
    Private Sub DGV_Beds_UserDeletingRow(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowCancelEventArgs) Handles DGV_Classification.UserDeletingRow
        If DGV_Classification.Rows.Count <> 0 Then RemovedIDs.Add(e.Row.Cells("ClassificationID").Value)
    End Sub
#Region "Utilities"

    Private Sub LoadForm()
        Try
            Dim LMISDb As New LMISEntities
            CMBX_Category.DataSource = From C In LMISDb.Categories Select C
            CMBX_Category.DisplayMember = "Name"
            CMBX_Category.ValueMember = "ID"
            CMBX_Category.AutoCompleteSource = AutoCompleteSource.ListItems
            ClearForm(True)
        Catch ex As Exception
            MessageBox.Show("Error:" & vbCrLf & ex.Message & Utility.InnerExecption(ex), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Function ValidateDataForm() As Boolean
        ERP_Error.Clear()
        Dim No_Error As Boolean = True
        If CMBX_Category.SelectedIndex = -1 And CMBX_Category.Text = String.Empty Then
            ERP_Error.SetError(CMBX_Category, "Please select or type appropriate 'Category'")
            No_Error = False
        ElseIf CMBX_Category.SelectedItem IsNot Nothing Then
            If (From I In (New LMISEntities).Categories Where I.Name = TBX_ChangeToCategoryName.Text Select I).Count > 0 Then
                ERP_Error.SetError(TBX_ChangeToCategoryName, "Category '" & TBX_ChangeToCategoryName.Text & "' already exists")
                No_Error = False
            End If
        End If

        If Not DGV_Classification.ValidateData() Then
            ERP_Error.SetError(DGV_Classification, "Please correct your errors in the table")
            No_Error = False
        End If
        Return No_Error
    End Function

    Private Function SaveData() As Boolean
        Dim DeleteException As Boolean = False
        Try
            Dim LMISDb As New LMISEntities
            Dim ItemCategory As Category
            Dim ItemCategoryID As Integer = CMBX_Category.SelectedValue
            Dim ItemCataegoryCheck = (From IC In LMISDb.Categories Where IC.ID = ItemCategoryID Select IC)
            If ItemCataegoryCheck.Count > 0 Then
                ItemCategory = ItemCataegoryCheck.First
                If TBX_ChangeToCategoryName.Text <> String.Empty Then ItemCategory.Name = TBX_ChangeToCategoryName.Text
            Else
                ItemCategory = New Category
                ItemCategory.Name = CMBX_Category.Text
                LMISDb.Categories.AddObject(ItemCategory)
            End If
            LMISDb.SaveChanges()
            For Each ICC As DataGridViewRow In DGV_Classification.Rows
                If Not ICC.IsNewRow Then
                    If Not DGV_Classification.IsInDatabase(ICC) Then
                        LMISDb.Classifications.AddObject(New Classification With {
                                .Name = ICC.Cells("Classification").Value(),
                                .CategoryID = ItemCategory.ID})
                    Else
                        Dim ICCID As Integer = ICC.Cells("ClassificationID").Value
                        With (From SRT In LMISDb.Classifications Where SRT.ID = ICCID Select SRT).First
                            .Name = ICC.Cells("Classification").Value()
                        End With
                    End If
                End If
            Next
            LMISDb.SaveChanges()
            For Each RDID In RemovedIDs
                Dim IDDel As String = RDID

                Dim RDeletedD = From RD In LMISDb.Classifications Where RD.ID = IDDel Select RD
                If RDeletedD.Count > 0 Then
                    LMISDb.Classifications.DeleteObject(RDeletedD.First)
                    Try
                        LMISDb.SaveChanges()
                    Catch ex As Exception
                        DeleteException = True
                        MsgBox("Can not delete Classification'" & RDeletedD.First.Name & "', because it has been used on other parts of the database")
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
            CMBX_Category.Text = ""
            CMBX_Category.SelectedItem = Nothing
        End If
        DGV_Classification.Rows.Clear()
    End Sub

    Private Sub ChangeItem(ByVal CatalogryID As String)
        ClearForm(False)
        Dim LMISDb As New LMISEntities
        ' MsgBox(CatalogryID)
        Dim Categorys = From IC In LMISDb.Categories Where IC.ID = CatalogryID Select IC
        If Categorys.Count > 0 Then
            For Each ICClassi In (From ICC In LMISDb.Classifications Where ICC.CategoryID = CatalogryID Select ICC)
                Dim NewRow = DGV_Classification.Rows(DGV_Classification.Rows.Add())
                NewRow.Cells("Classification").Value = ICClassi.Name
                NewRow.Cells("ClassificationID").Value = ICClassi.ID
                DGV_Classification.IsInDatabase(NewRow) = True
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

    Private Sub CMBX_ItemCatalogue_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBX_Category.SelectedIndexChanged
        If CMBX_Category.ValueMember <> String.Empty Then ChangeItem(CMBX_Category.SelectedValue)
        RemovedIDs.Clear()
    End Sub

    Private Sub CMBX_ItemCatalogue_textChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBX_Category.LostFocus
        If CMBX_Category.SelectedValue Is Nothing Then
            ClearForm(False)
        End If
    End Sub

    Private Sub FRM_ItemAddNew_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        DGV_Classification.initMe(DGV_GTypes.CategoryOnly)
    End Sub

#End Region

End Class

