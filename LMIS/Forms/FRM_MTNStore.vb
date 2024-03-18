Imports System.Data.Objects

Public Class FRM_MTNStore

    Public Sub New()
        InitializeComponent()
        Me.MdiParent = FRM_GLBMain
        LoadForm()
    End Sub

    Dim RemovedIDs As New List(Of String)
    Private Sub DGV_Beds_UserDeletingRow(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowCancelEventArgs) Handles DGV_Store.UserDeletingRow
        If DGV_Store.Rows.Count <> 0 Then RemovedIDs.Add(e.Row.Cells("LocationID").Value)
    End Sub

#Region "Utilities"

    Private Sub LoadForm()
        Try
            Dim LMISDb As New LMISEntities
            CMBX_Store.DataSource = From S In LMISDb.Stores Select S Where S.DepartmentID = FRM_GLBMain.ApplicationConfig.ThisDepartment.ID
            CMBX_Store.DisplayMember = "Name"
            CMBX_Store.ValueMember = "ID"
            CMBX_Store.AutoCompleteSource = AutoCompleteSource.ListItems
            ClearForm(True)
        Catch ex As Exception
            MessageBox.Show("Error:" & vbCrLf & ex.Message & Utility.InnerExecption(ex), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Function ValidateDataForm() As Boolean
        ERP_Error.Clear()
        Dim No_Error As Boolean = True
        If CMBX_Store.SelectedIndex = -1 And CMBX_Store.Text = String.Empty Then
            ERP_Error.SetError(CMBX_Store, "Please select or type appropriate 'Store'")
            No_Error = False
        ElseIf CMBX_Store.SelectedIndex = -1 Then
            If (From I In (New LMISEntities).Categories Where I.Name = CMBX_Store.Text Select I).Count > 0 Then
                ERP_Error.SetError(CMBX_Store, "Store '" & CMBX_Store.Text & "' already exists")
                No_Error = False
            End If
        End If
        If TBX_ChangeToStoreName.Text <> String.Empty Then
            If (From m In CType(CMBX_Store.DataSource, ObjectQuery(Of Store)) Where m.Name = TBX_ChangeToStoreName.Text Select m).Count > 0 Then
                ERP_Error.SetError(TBX_ChangeToStoreName, "'" & TBX_ChangeToStoreName.Text & "' Already Exists")
                No_Error = False
            End If
        End If
        If Not DGV_Store.ValidateData() Then
            ERP_Error.SetError(DGV_Store, "Please correct your errors in the table")
            No_Error = False
        End If
        Return No_Error
    End Function

    Private Function SaveData() As Boolean
        Dim DeleteException As Boolean = False
        Try
            Dim LMISDb As New LMISEntities
            Dim ItemStore As Store
            Dim ItemStoreID As String = CMBX_Store.SelectedValue
            Dim ItemStoreCheck = (From S In LMISDb.Stores Where S.ID = ItemStoreID Select S)
            If ItemStoreCheck.Count > 0 Then
                ItemStore = ItemStoreCheck.First
                If TBX_ChangeToStoreName.Text <> String.Empty Then ItemStore.Name = TBX_ChangeToStoreName.Text
                ItemStore.Active = CHBX_IsActive.Checked
            Else
                ItemStore = New Store With {
                .ID = Utility.GenerateID(IDTypes.Store),
                .Name = CMBX_Store.Text, .DepartmentID = FRM_GLBMain.ApplicationConfig.ThisDepartment.ID,
                .Active = CHBX_IsActive.Checked}
                LMISDb.Stores.AddObject(ItemStore)
            End If
            LMISDb.SaveChanges()
            For Each Str As DataGridViewRow In DGV_Store.Rows
                If Not Str.IsNewRow Then
                    If Not DGV_Store.IsInDatabase(Str) Then
                        LMISDb.Locations.AddObject(New Location With {
                                .Name = Str.Cells("Location").Value(),
                                .StoreID = ItemStore.ID,
                                .Active = Str.Cells("Active").Value(),
                                .ID = Utility.GenerateID(IDTypes.Location)})
                    Else
                        Dim LocID As String = Str.Cells("LocationID").Value
                        With (From Loc In LMISDb.Locations Where Loc.ID = LocID Select Loc).First
                            .Name = Str.Cells("Location").Value()
                            .Active = Str.Cells("Active").Value()
                        End With
                    End If
                    LMISDb.SaveChanges()
                End If
            Next
            LMISDb.SaveChanges()
            For Each RDID In RemovedIDs
                Dim IDDel As String = RDID

                Dim RDeletedD = From RD In LMISDb.Locations Where RD.ID = IDDel Select RD
                If RDeletedD.Count > 0 Then
                    LMISDb.Locations.DeleteObject(RDeletedD.First)
                    Try
                        LMISDb.SaveChanges()
                    Catch ex As Exception
                        DeleteException = True
                        MsgBox("Can not delete Location '" & RDeletedD.First.Name & "', because it has been used on another parts of the database")
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
            CMBX_Store.Text = ""
            CMBX_Store.SelectedItem = Nothing
        End If
        DGV_Store.Rows.Clear()
    End Sub

    Private Sub ChangeItem(ByVal StoreID As String)
        ClearForm(False)
        Dim LMISDb As New LMISEntities        
        Dim Stores = From S In LMISDb.Stores Where S.ID = StoreID Select S
        If Stores.Count > 0 Then
            CHBX_IsActive.Checked = Stores.First.Active
            For Each Loca In (From Loc In LMISDb.Locations Where Loc.StoreID = StoreID Select Loc)
                Dim NewRow = DGV_Store.Rows(DGV_Store.Rows.Add())
                NewRow.Cells("Location").Value = Loca.Name
                NewRow.Cells("LocationID").Value = Loca.ID
                NewRow.Cells("Active").Value = Loca.Active
                DGV_Store.IsInDatabase(NewRow) = True
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

    Private Sub CMBX_ItemCatalogue_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBX_Store.SelectedIndexChanged
        If CMBX_Store.ValueMember <> String.Empty Then ChangeItem(CMBX_Store.SelectedValue)
        RemovedIDs.Clear()
    End Sub

    Private Sub CMBX_ItemCatalogue_textChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBX_Store.LostFocus
        If CMBX_Store.SelectedValue Is Nothing Then
            ClearForm(False)
        End If
    End Sub

    Private Sub FRM_ItemAddNew_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        DGV_Store.initMe(DGV_GTypes.CategoryOnly)
    End Sub

#End Region

End Class

