Public Class FRM_MTNRoomsNBeds

    Public Sub New()
        InitializeComponent()
        Me.MdiParent = FRM_GLBMain
        LoadForm()

    End Sub

    Dim RemovedIDs As New List(Of String)
    Private Sub DGV_Beds_UserDeletingRow(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowCancelEventArgs) Handles DGV_Beds.UserDeletingRow        
        If DGV_Beds.Rows.Count <> 0 Then RemovedIDs.Add(e.Row.Cells("BedID").Value)
    End Sub

#Region "Utilities"

    Private Sub LoadForm()
        Try
            Dim LMISDb As New LMISEntities
            Dim DepartmentID As String = FRM_GLBMain.ApplicationConfig.ThisDepartment.ID
            CMBX_Rooms.DataSource = From R In LMISDb.Rooms Where R.DepartmentID = FRM_GLBMain.ApplicationConfig.ThisDepartment.ID Select R
            CMBX_Rooms.DisplayMember = "RoomNo"
            CMBX_Rooms.ValueMember = "ID"
            CMBX_Rooms.SelectedItem = Nothing
            CMBX_Department.DataSource = From R In LMISDb.Departments Where R.FacilityID = FRM_GLBMain.ApplicationConfig.ThisDepartment.FacilityID Select R
            CMBX_Department.DisplayMember = "Name"
            CMBX_Department.ValueMember = "ID"
            CMBX_Department.SelectedValue = FRM_GLBMain.ApplicationConfig.ThisDepartment.ID
            If Not (FRM_GLBMain.ApplicationConfig.ThisDepartment.Facility.IsNationalReferral = True) Then CMBX_Department.Enabled = False
        Catch ex As Exception
            MessageBox.Show("Error:" & vbCrLf & ex.Message & Utility.InnerExecption(ex), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Function ValidateDataForm() As Boolean
        ERP_Error.Clear()
        Dim No_Error As Boolean = True
        If CMBX_Rooms.SelectedIndex = -1 And CMBX_Rooms.Text = String.Empty Then
            ERP_Error.SetError(CMBX_Rooms, "Please select or type appropriate 'Room Number'")
            No_Error = False
        ElseIf CMBX_Rooms.SelectedIndex = -1 Then
            If (From I In (New LMISEntities).Rooms Where I.RoomNo = CMBX_Rooms.Text Select I).Count > 0 Then
                ERP_Error.SetError(CMBX_Rooms, "Room Number'" & CMBX_Rooms.Text & "' already exists")
                No_Error = False
            End If
        End If
        If CMBX_Department.SelectedItem Is Nothing Then
            ERP_Error.SetError(CMBX_Department, "Select appropriate Facility")
            No_Error = False
        End If
        If Not DGV_Beds.ValidateData() Then
            ERP_Error.SetError(DGV_Beds, "Please correct your errors in the table")
            No_Error = False
        End If
        Return No_Error
    End Function

    Private Function SaveData() As Boolean
        Dim DeleteException As Boolean = False
        Try
            Dim LMISDb As New LMISEntities
            Dim Room As Room
            Dim ItemCategoryID As String = CMBX_Rooms.SelectedValue
            Dim ItemCataegoryCheck = (From IC In LMISDb.Rooms Where IC.ID = ItemCategoryID Select IC)
            If ItemCataegoryCheck.Count > 0 Then
                Room = ItemCataegoryCheck.First
                If TBX_ChangeTo.Text <> String.Empty Then Room.RoomNo = TBX_ChangeTo.Text
                Room.Active = CHBX_IsActive.Checked
            Else
                Room = New Room With {
                        .ID = Utility.GenerateID(IDTypes.Rooms),
                        .DepartmentID = CMBX_Department.SelectedValue,
                        .RoomNo = CMBX_Rooms.Text,
                        .Active = CHBX_IsActive.Checked}
                LMISDb.Rooms.AddObject(Room)
            End If
            LMISDb.SaveChanges()
            For Each ICC As DataGridViewRow In DGV_Beds.Rows
                If Not ICC.IsNewRow Then
                    If Not DGV_Beds.IsInDatabase(ICC) Then
                        LMISDb.Beds.AddObject(New Bed With {
                                            .ID = Utility.GenerateID(IDTypes.Beds),
                                            .BedNo = ICC.Cells("Bed").Value(),
                                            .RoomID = Room.ID})
                    Else
                        Dim ICCID As String = ICC.Cells("BedID").Value
                        With (From SRT In LMISDb.Beds Where SRT.ID = ICCID Select SRT).First
                            .BedNo = ICC.Cells("bed").Value()
                        End With
                    End If
                End If
                LMISDb.SaveChanges()
                For Each RDID In RemovedIDs
                    Dim IDDel As String = RDID

                    Dim RDeletedD = From RD In LMISDb.Beds Where RD.ID = IDDel Select RD
                    If RDeletedD.Count > 0 Then
                        LMISDb.Beds.DeleteObject(RDeletedD.First)
                        Try
                            LMISDb.SaveChanges()
                        Catch ex As Exception
                            DeleteException = True
                            MsgBox("Can not delete bed '" & RDeletedD.First.BedNo & "', because it has been used on other parts of the database")
                        End Try
                    End If
                Next
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
            CMBX_Rooms.Text = ""
            CMBX_Rooms.SelectedItem = Nothing
            CMBX_Department.SelectedItem = Nothing
        End If
        DGV_Beds.Rows.Clear()
    End Sub

    Private Sub ChangeItem(ByVal RoomID As String)
        ClearForm(False)
        Dim LMISDb As New LMISEntities
        Dim Rooms = From IC In LMISDb.Rooms Where IC.ID = RoomID Select IC
        'MsgBox("|" & RoomID & "|" & Rooms.Count)
        If Rooms.Count > 0 Then
            CHBX_IsActive.Checked = Rooms.First.Active
            For Each Bedr In (From Bed In LMISDb.Beds Where Bed.RoomID = RoomID Select Bed)
                Dim NewRow = DGV_Beds.Rows(DGV_Beds.Rows.Add())
                NewRow.Cells("Bed").Value = Bedr.BedNo
                NewRow.Cells("BedID").Value = Bedr.ID
                DGV_Beds.IsInDatabase(NewRow) = True
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

    Private Sub CMBX_ItemCatalogue_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBX_Rooms.SelectedIndexChanged
        If CMBX_Rooms.ValueMember <> String.Empty Then ChangeItem(CMBX_Rooms.SelectedValue)
        RemovedIDs.Clear()
    End Sub

    Private Sub CMBX_ItemCatalogue_textChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBX_Rooms.LostFocus
        If CMBX_Rooms.SelectedValue Is Nothing Then
            ClearForm(False)
        End If
    End Sub

    Private Sub FRM_ItemAddNew_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        DGV_Beds.initMe(DGV_GTypes.Beds)
    End Sub

#End Region

    Private Sub CMBX_Department_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBX_Department.SelectedIndexChanged
        If CMBX_Department.SelectedItem IsNot Nothing And CMBX_Department.ValueMember <> String.Empty Then            
            Dim SelectedDepartment As String = CMBX_Department.SelectedValue
            CMBX_Rooms.DataSource = From R In (New LMISEntities).Rooms Where R.DepartmentID = SelectedDepartment Select R
            CMBX_Rooms.SelectedItem = Nothing
        End If
    End Sub



    Private Sub rowsRemoved(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewRowsRemovedEventArgs)

    End Sub
End Class

