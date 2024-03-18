Imports System.Data.Objects
Imports System.Transactions
Public Class FRM_IJSupplyRequestEdit

#Region "declarations"
    Private FRMMode As FRMModes = FRMModes.AddNew

    Public Sub New()
        InitializeComponent()
        Me.MdiParent = FRM_GLBMain
        DTP_VoucherDate.MaxDate = Date.Today
    End Sub

#End Region

#Region "Utilities"

    Public Overloads Sub Show(ByVal Mode As FRMModes)
        FRMMode = Mode
        If FRMMode.Equals(FRMModes.AddNew) Then
            Me.Text = "Supply Request"
            LBL_Title.Text = "Supply Request"
        Else
            Me.Text = "Edit/Reject Existing Supply Requests"
            LBL_Title.Text = "Edit/Reject Existing Supply Requests"
        End If
        Me.Show()
    End Sub

    Sub LoadForm()
        Try
            Dim LMISDb As New LMISEntities
            Dim MyDepartment = FRM_GLBMain.ApplicationConfig.ThisDepartment
            With CMBX_Department
                .DisplayMember = "Name"
                .ValueMember = "ID"
                .DataSource = From F In LMISDb.Departments
                              Where F.Active = False And
                                 (MyDepartment.DepartmentType.Description = "Level 4N" And ((F.DepartmentType.Description = "Level 2" And MyDepartment.FacilityID = F.FacilityID) Or (F.DepartmentType.Description = "Level 3" And MyDepartment.FacilityID = F.FacilityID))) Or
                                 (MyDepartment.DepartmentType.Description = "Level 4I" And ((F.DepartmentType.Description = "Level 2" And MyDepartment.FacilityID = F.FacilityID) Or (F.DepartmentType.Description = "Level 3" And MyDepartment.FacilityID = F.FacilityID))) Or
                                 (MyDepartment.DepartmentType.Description = "Level 4O" And ((F.DepartmentType.Description = "Level 2" And MyDepartment.FacilityID = F.FacilityID) Or (F.DepartmentType.Description = "Level 3" And MyDepartment.FacilityID = F.FacilityID))) Or
                                 (MyDepartment.DepartmentType.Description = "Level 3" And ((F.DepartmentType.Description = "Level 2" And F.Facility.MedicalStoreID = MyDepartment.Facility.MedicalStoreID) Or (F.DepartmentType.Description = "Level 3" And F.Facility.MedicalStoreID = MyDepartment.Facility.MedicalStoreID))) Or
                                 (MyDepartment.DepartmentType.Description = "Level 2" And ((F.DepartmentType.Description = "Level 3" And F.Facility.MedicalStoreID = MyDepartment.Facility.MedicalStoreID) Or F.DepartmentType.Description = "Level 2" Or F.DepartmentType.Description = "Level 1"))
                              Select F Order By F.DepartmentTypeID
                .AutoCompleteSource = AutoCompleteSource.ListItems
                .SelectedItem = Nothing
            End With
            With CMBX_RequestID
                If FRMMode.Equals(FRMModes.AddNew) Then
                    .Enabled = False 'disallow editting                    
                    .Text = Utility.GenerateID(IDTypes.Request)
                Else
                    .Enabled = True
                    .DataSource = (From Req In LMISDb.Requests Where (Req.InventoryJournal.Void = False And Req.InventoryJournal.InventoryJournalStatu.Name = "Pending" And Req.InventoryJournal.DepartmentID = FRM_GLBMain.ApplicationConfig.ThisDepartment.ID)
                                        Select Req.ID).Except(
                                    From Rec In LMISDb.Recieves Where (Rec.InventoryJournal.Void = False And Rec.InventoryJournal.InventoryJournalStatu.Name = "Processed" And Rec.Request.InventoryJournal.Void = False And Rec.InventoryJournal.DepartmentID = FRM_GLBMain.ApplicationConfig.ThisDepartment.ID)
                                        Select Rec.Request.ID)
                    .AutoCompleteSource = AutoCompleteSource.ListItems
                End If
                .SelectedItem = Nothing
            End With

            CMBX_Quarter.DataSource = From C In LMISDb.SupplyPeriods Select C Where FRM_GLBMain.ApplicationConfig.ThisDepartment.DepartmentType.RationDaysID = C.RationDaysID
            CMBX_Quarter.DisplayMember = "Period"
            CMBX_Quarter.ValueMember = "ID"
            CMBX_Quarter.SelectedItem = Nothing
        Catch ex As Exception
            MessageBox.Show("Error: In Loading Form" & vbCrLf & ex.Message & Utility.InnerExecption(ex))
        End Try
    End Sub

    Function SaveData(ByVal SaveStatus As Int16) As Boolean
        Try
            Using Transaction As New TransactionScope(TransactionScopeOption.RequiresNew)
                Dim LMISDb As New LMISEntities
                Select Case FRMMode
                    Case FRMModes.AddNew
                        Dim NewIJ = New InventoryJournal With {
                            .ID = Utility.GenerateID(IDTypes.IJ),
                            .DepartmentID = FRM_GLBMain.ApplicationConfig.ThisDepartment.ID,
                            .VoucherDate = DTP_VoucherDate.Value,
                            .TransactionDate = Date.Today,
                            .Remark = TBX_Remark.Text,
                            .InventoryJournalTypeID = 12,
                            .EmployeeID = FRM_GLBMain.ApplicationConfig.Employee.ID,
                            .Void = False,
                            .InventoryJournalStatusID = SaveStatus}
                        LMISDb.InventoryJournals.AddObject(NewIJ)
                        LMISDb.SaveChanges()
                        For Each ItemRow As DataGridViewRow In DGV_Items.Rows
                            If Not ItemRow.IsNewRow Then
                                LMISDb.InventoryJournalDetails.AddObject(New InventoryJournalDetail With {
                                    .ItemID = ItemRow.Cells("ItemID").Value,
                                    .Quantity = ItemRow.Cells("Qty").Value,
                                    .InventoryJournalID = NewIJ.ID,
                                    .Remark = ItemRow.Cells("Remark").Value})
                                LMISDb.SaveChanges()
                            End If
                        Next
                        CMBX_RequestID.Text = Utility.GenerateID(IDTypes.Request)
                        LMISDb.Requests.AddObject(New Request With {
                            .ID = Utility.GenerateID(IDTypes.Request),
                            .InventoryJournalID = NewIJ.ID,
                            .DepartmentID = CMBX_Department.SelectedValue,
                            .SupplyPeriodID = CMBX_Quarter.SelectedValue})
                        LMISDb.SaveChanges()
                        Transaction.Complete()
                        Return True
                    Case FRMModes.EditExisting
                        Dim Req_IJ = From R In LMISDb.Requests Where R.ID = CMBX_RequestID.Text Select R.InventoryJournal
                        Req_IJ.First.VoucherDate = DTP_VoucherDate.Value
                        Req_IJ.First.Remark = TBX_Remark.Text
                        Req_IJ.First.InventoryJournalStatusID = SaveStatus
                        Dim Req = From R In LMISDb.Requests Where R.ID = CMBX_RequestID.Text Select R
                        Req.First.DepartmentID = CMBX_Department.SelectedValue
                        Req.First.SupplyPeriodID = CMBX_Quarter.SelectedValue
                        LMISDb.SaveChanges()

                        Dim IJID As String = Req_IJ.First.ID
                        Dim IJDDelete = From IJD In LMISDb.InventoryJournalDetails Where IJD.InventoryJournalID = IJID Select IJD
                        For Each IJDRow As InventoryJournalDetail In IJDDelete
                            LMISDb.InventoryJournalDetails.DeleteObject(IJDRow)
                        Next
                        LMISDb.SaveChanges()
                        For Each ItemRow As DataGridViewRow In DGV_Items.Rows
                            If Not ItemRow.IsNewRow Then
                                LMISDb.InventoryJournalDetails.AddObject(New InventoryJournalDetail With {
                                    .ItemID = ItemRow.Cells("ItemID").Value,
                                    .Quantity = ItemRow.Cells("Qty").Value,
                                    .InventoryJournalID = Req_IJ.First.ID,
                                    .Remark = ItemRow.Cells("Remark").Value})
                            End If
                        Next
                        LMISDb.SaveChanges()
                        Transaction.Complete()
                        Return True
                End Select
            End Using
        Catch ex As Exception
            MessageBox.Show("Error: In Saving Data" & vbCrLf & ex.Message & Utility.InnerExecption(ex))
        End Try
        Return False
    End Function

    Function Save_Reject() As Boolean
        Try
            Using LMISDb As New LMISEntities
                Dim Req_IJ = From R In LMISDb.Requests
                Join IJ In LMISDb.InventoryJournals
                    On R.InventoryJournalID Equals IJ.ID
                Where R.ID = CMBX_RequestID.Text
                Select IJ
                If Req_IJ.Count > 0 Then
                    Req_IJ.First.InventoryJournalStatusID = 3 ' for rejected
                    Req_IJ.First.Void = True ' for void
                    If LMISDb.SaveChanges() > 0 Then
                        Return True
                    Else
                        Return False
                    End If
                End If
            End Using
        Catch ex As Exception
            MessageBox.Show("Error:" & vbCrLf & ex.Message & Utility.InnerExecption(ex), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try
        Return False
    End Function

    Function ValidateDataForm() As Boolean
        ERP_Error.Clear()
        Dim No_Error As Boolean = True
        If FRMMode.Equals(FRMModes.EditExisting) And (IsNothing(CMBX_RequestID.SelectedItem) Or CMBX_RequestID.Text = String.Empty) Then
            ERP_Error.SetError(CMBX_RequestID, "Select Appropriate 'Request ID'")
            No_Error = False
        End If
        If DGV_Items.Rows.Count = 1 Then
            ERP_Error.SetError(DGV_Items, "At least 'one Item' should be requested")
            No_Error = False
        ElseIf Not DGV_Items.ValidateData() Then
            ERP_Error.SetError(DGV_Items, "Correct your errors in Items table")
            No_Error = False
        End If
        If IsNothing(CMBX_Department.SelectedItem) Or CMBX_Department.Text = String.Empty Then
            ERP_Error.SetError(CMBX_Department, "Select Appropriate 'Supplier'")
            No_Error = False
        End If
        If CMBX_Quarter.SelectedItem Is Nothing Then
            ERP_Error.SetError(CMBX_Quarter, "'Period' Should not be empty")
            No_Error = False
        End If
        Return No_Error
    End Function

    Function Validate_Reject_Data() As Boolean
        ERP_Error.Clear()
        Dim No_Error As Boolean = True
        If FRMMode.Equals(FRMModes.EditExisting) And (IsNothing(CMBX_RequestID.SelectedItem) Or CMBX_RequestID.Text = String.Empty) Then
            ERP_Error.SetError(CMBX_RequestID, "Select Appropriate 'Request ID'")
            No_Error = False
        End If
        Return No_Error
    End Function

    Sub ClearForm()
        DTP_VoucherDate.Value = Date.Today
        TBX_Remark.Text = ""
        CMBX_Department.SelectedItem = Nothing
        CMBX_Department.Text = ""
        DGV_Items.Rows.Clear()
    End Sub

#End Region

#Region "Events"

    Private Sub FRM_GotFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.GotFocus
        FRM_GLBMain.TLSL_MainStatus.Text = "Ready"
    End Sub

    Private Sub BTN_Close_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTN_Close.Click
        Me.Close()
    End Sub

    Private Sub FRM_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If DGV_Items.Rows.Count > 1 Then If MessageBox.Show("Are you sure you want to close without saving your work?", "Are you sure?", System.Windows.Forms.MessageBoxButtons.YesNo, System.Windows.Forms.MessageBoxIcon.Information) = System.Windows.Forms.DialogResult.No Then e.Cancel = True
    End Sub

    Private Sub FRM_IJRequestEdit_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        DGV_Items.initMe(TBX_TotalCost, IJFRM_Types.RequestEdit)
        LoadForm()
    End Sub

    Private Sub BTN_Reject_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTN_Void.Click
        FRM_GLBMain.TLSL_MainStatus.Text = "Ready"
        If Validate_Reject_Data() Then
            If MessageBox.Show("Are you sure you want to void the Supply Request", "Are you sure?", System.Windows.Forms.MessageBoxButtons.YesNo) = System.Windows.Forms.DialogResult.Yes Then
                If Save_Reject() Then
                    FRM_GLBMain.TLSL_MainStatus.Text = "Supply Request has been voided"
                    MessageBox.Show("Supply Request has been voided", "Data Saved", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    ClearForm()
                    LoadForm()
                Else
                    FRM_GLBMain.TLSL_MainStatus.Text = "Supply Request has been NOT voided"
                    MessageBox.Show("    Supply Request has NOT been voided    ", "Error in Saving", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            End If
        End If
    End Sub

    Private Sub BTN_Save_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTN_Save.Click
        FRM_GLBMain.TLSL_MainStatus.Text = "Ready"
        If ValidateDataForm() Then
            If MessageBox.Show("Are you sure you want to save this Supply Request", "Are you sure?", System.Windows.Forms.MessageBoxButtons.YesNo) = System.Windows.Forms.DialogResult.Yes Then
                If SaveData(1) Then
                    FRM_GLBMain.TLSL_MainStatus.Text = "Supply Request Saved"
                    MessageBox.Show("Supply Request Saved", "Data Saved", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    'Dim SelectedRequest As String = CMBX_RequestID.Text
                    'Me.FRMMode = FRMModes.EditExisting
                    ClearForm()
                    LoadForm()
                    'CMBX_RequestID.SelectedItem = SelectedRequest
                    ''BTN_Void.Enabled = True
                    ''BTN_Report.Enabled = True
                    'CMBX_RequestID.Enabled = True
                Else
                    FRM_GLBMain.TLSL_MainStatus.Text = "Supply Request NOT Saved"
                    MessageBox.Show("  Supply Request NOT Saved    ", "Error in Saving", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            End If
        End If
    End Sub

    Private Sub BTN_Report_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTN_Report.Click
        FRM_GLBMain.TLSL_MainStatus.Text = "Ready"
        If ValidateDataForm() Then
            If MessageBox.Show("Are you sure you want to save this Supply Request", "Are you sure?", System.Windows.Forms.MessageBoxButtons.YesNo) = System.Windows.Forms.DialogResult.Yes Then
                If SaveData(1) Then
                    FRM_GLBMain.TLSL_MainStatus.Text = "Supply Request Saved"
                    MessageBox.Show("Supply Request Saved", "Data Saved", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    'Warning: Donot change the order of execution
                    Dim ReportParameter As New Dictionary(Of String, String())
                    ReportParameter.Add("ID", {CMBX_RequestID.Text})
                    Dim FRM_ReporterWin2 As New FRM_Reporter()
                    FRM_ReporterWin2.Show(ReportTypes.IJRequestDetails, ReportParameter)
                    Dim FRM_ReporterWin1 As New FRM_Reporter()
                    FRM_ReporterWin1.Show(ReportTypes.IJRequestOnly, ReportParameter)
                    ClearForm()
                    LoadForm()
                Else
                    FRM_GLBMain.TLSL_MainStatus.Text = "Supply Request NOT Saved"
                    MessageBox.Show("  Data NOT Saved    ", "Error in Saving", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            End If
        End If
    End Sub

    Private Sub CMBX_RequestID_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBX_RequestID.SelectedIndexChanged
        Try
            If CMBX_RequestID.SelectedItem IsNot Nothing Then
                Dim LMISDb As New LMISEntities
                Dim Req_IJ = From R In LMISDb.Requests
                                Join IJ In LMISDb.InventoryJournals
                                    On R.InventoryJournalID Equals IJ.ID
                                Join D In LMISDb.Departments
                                    On R.DepartmentID Equals D.ID
                                Where R.ID = CMBX_RequestID.Text
                                Select IJ.VoucherDate, IJ.Remark, DepartmentID = D.ID, R.SupplyPeriodID
                If Req_IJ.Count = 0 Then Throw New Exception("Application could not find Request Number")
                DTP_VoucherDate.Value = Req_IJ.First.VoucherDate
                CMBX_Department.SelectedValue = Req_IJ.First.DepartmentID
                TBX_Remark.Text = Req_IJ.First.Remark
                CMBX_Quarter.SelectedValue = Req_IJ.First.SupplyPeriodID
                DGV_Items.PopulateItems(CMBX_RequestID.Text)
            Else
                ClearForm()
            End If
        Catch ex As Exception
            MessageBox.Show("Error:" & vbCrLf & ex.Message & Utility.InnerExecption(ex), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub CHBX_UseTemplate_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CHBX_UseTemplate.CheckedChanged, CMBX_Department.SelectedIndexChanged, CMBX_RequestDates.SelectedIndexChanged
        CMBX_RequestDates.Enabled = CHBX_UseTemplate.Checked
        If sender Is CMBX_Department And CMBX_Department.SelectedItem IsNot Nothing Then
            Dim DepaID As String = CMBX_Department.SelectedValue
            CMBX_RequestDates.DataSource = From LR In (New LMISEntities).Requests
                          Where LR.DepartmentID = DepaID And LR.InventoryJournal.Department.Active = True
                          Order By LR.InventoryJournal.VoucherDate Descending Select LR.ID, LR.InventoryJournal.VoucherDate
            CMBX_RequestDates.ValueMember = "ID"
            CMBX_RequestDates.DisplayMember = "VoucherDate"
            CMBX_RequestDates.SelectedItem = Nothing
        ElseIf CMBX_Department.SelectedItem Is Nothing Then
            CMBX_RequestDates.DataSource = Nothing
        End If
        If CHBX_UseTemplate.Checked And CMBX_Department.SelectedItem IsNot Nothing And CMBX_RequestDates.SelectedItem IsNot Nothing Then
            DGV_Items.IJTransaction.clearRows = False
            DGV_Items.PopulateItems(CMBX_RequestDates.SelectedValue)
            DGV_Items.IJTransaction.clearRows = True
        End If
    End Sub

#End Region

  
    Private Sub DGV_Items_RowsAdded(sender As Object, e As System.Windows.Forms.DataGridViewRowsAddedEventArgs) Handles DGV_Items.RowsAdded
        LabelNoRows.Text = DGV_Items.RowCount - 1
    End Sub
End Class




