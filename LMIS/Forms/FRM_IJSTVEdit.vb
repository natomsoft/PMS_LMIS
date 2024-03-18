Imports System.Transactions
Public Class FRM_IJSTVEdit

#Region "declarations"
    Private FRMMode As FRMModes = FRMModes.AddNew

    Public Overloads Sub Show(ByVal FRMMode As FRMModes)
        Me.FRMMode = FRMMode
        Me.Show()
    End Sub

    Public Sub New()
        InitializeComponent()
        Me.MdiParent = FRM_GLBMain
        DTP_VoucherDate.MaxDate = Date.Today
    End Sub

#End Region

#Region "Utilities"

    Sub LoadForm()
        Try
            Dim LMISDb As New LMISEntities
            If FRMMode.Equals(FRMModes.AddNew) Then
                CMBX_TransferID.Enabled = False 'disallow editting
                CMBX_TransferID.Text = Utility.GenerateID(IDTypes.Transfers)
                Me.Text = "Add new STV"
            Else
                CMBX_TransferID.DataSource = From A In LMISDb.Transfers Where A.InventoryJournal.InventoryJournalStatu.Name = "Pending" Select A.ID
                CMBX_TransferID.AutoCompleteSource = AutoCompleteSource.ListItems
                CMBX_TransferID.SelectedItem = Nothing
                Me.Text = "Edit existing STV"
            End If
            CMBX_TransferID.SelectedItem = Nothing

            Dim BatchLocations = From IJDB In LMISDb.InventoryJournalDetailsBatches
                                 Where IJDB.InventoryJournalDetail.InventoryJournal.DepartmentID = FRM_GLBMain.ApplicationConfig.ThisDepartment.ID And IJDB.Location.Store.Active = True
                                 Select IJDB.Location.ID, LocationName = IJDB.Location.Name, StoreName = IJDB.Location.Store.Name Distinct
            Dim RetLocations As New List(Of IDNdata)
            For Each BatchLocation In BatchLocations
                RetLocations.Add(New IDNdata(BatchLocation.ID, BatchLocation.StoreName & " | " & BatchLocation.LocationName, True))
            Next
            CMBX_FromLocation.DataSource = RetLocations
            CMBX_FromLocation.SelectedItem = Nothing
        Catch ex As Exception
            MessageBox.Show("Error:" & vbCrLf & ex.Message & Utility.InnerExecption(ex), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Function SaveData(ByVal SaveStatus As Int16) As Boolean
        Try
            If FRMMode.Equals(FRMModes.AddNew) Then
                Using Transaction As New TransactionScope(TransactionScopeOption.RequiresNew)
                    Dim LMISDb As New LMISEntities
                    Dim NewInIJ As New InventoryJournal With {
                        .ID = Utility.GenerateID(IDTypes.IJ),
                        .DepartmentID = FRM_GLBMain.ApplicationConfig.ThisDepartment.ID,
                        .VoucherDate = DTP_VoucherDate.Value,
                        .TransactionDate = Date.Today,
                        .Remark = TBX_Remark.Text,
                        .EmployeeID = FRM_GLBMain.ApplicationConfig.Employee.ID,
                        .Void = False,
                        .InventoryJournalTypeID = 21,
                        .InventoryJournalStatusID = SaveStatus}
                    LMISDb.InventoryJournals.AddObject(NewInIJ)
                    LMISDb.SaveChanges()
                    CMBX_TransferID.Text = Utility.GenerateID(IDTypes.Transfers)
                    Dim NewOutIJ As New InventoryJournal With {
                        .ID = Utility.GenerateID(IDTypes.IJ),
                        .DepartmentID = FRM_GLBMain.ApplicationConfig.ThisDepartment.ID,
                        .VoucherDate = DTP_VoucherDate.Value,
                        .TransactionDate = Date.Today,
                        .Remark = TBX_Remark.Text,
                        .EmployeeID = FRM_GLBMain.ApplicationConfig.Employee.ID,
                        .Void = False,
                        .InventoryJournalTypeID = 22,
                        .InventoryJournalStatusID = 2}
                    LMISDb.InventoryJournals.AddObject(NewOutIJ)
                    LMISDb.SaveChanges()
                    Dim NewTransfer As New Transfer With {
                        .ID = CMBX_TransferID.Text,
                        .InventoryJournalInID = NewInIJ.ID,
                        .InventoryJournalOutID = NewOutIJ.ID,
                        .FromLocation = CMBX_FromLocation.SelectedValue,
                        .ToLocation = CMBX_ToLocation.SelectedValue}
                    LMISDb.Transfers.AddObject(NewTransfer)
                    LMISDb.SaveChanges()
                    For Each ItemRow As DataGridViewRow In DGV_Items.Rows
                        If Not ItemRow.IsNewRow Then
                            Dim NewInIJDetail As New InventoryJournalDetail With {
                                .ItemID = ItemRow.Cells("ItemID").Value,
                                .Quantity = ItemRow.Cells("Qty").Value,
                                .InventoryJournalID = NewInIJ.ID,
                                .Remark = ItemRow.Cells("Remark").Value}
                            LMISDb.InventoryJournalDetails.AddObject(NewInIJDetail)
                            If LMISDb.SaveChanges() > 0 Then
                                Dim NewIJDetailsBatch As New InventoryJournalDetailsBatch With {
                                    .InventoryBatchID = ItemRow.Cells("Batch").Value,
                                    .Price = 0,
                                    .LocationID = CMBX_ToLocation.SelectedValue,
                                    .InventoryJournaDetaillID = NewInIJDetail.ID}
                                LMISDb.InventoryJournalDetailsBatches.AddObject(NewIJDetailsBatch)
                                LMISDb.SaveChanges()
                            End If

                            Dim NewOutIJDetail As New InventoryJournalDetail With {
                                .ItemID = ItemRow.Cells("ItemID").Value,
                                .Quantity = ItemRow.Cells("Qty").Value,
                                .InventoryJournalID = NewOutIJ.ID,
                                .Remark = ItemRow.Cells("Remark").Value}
                            LMISDb.InventoryJournalDetails.AddObject(NewOutIJDetail)
                            If LMISDb.SaveChanges() > 0 Then
                                Dim NewIJDetailsBatch As New InventoryJournalDetailsBatch With {
                                    .InventoryBatchID = ItemRow.Cells("Batch").Value,
                                    .Price = ItemRow.Cells("Cost").Value,
                                    .LocationID = CMBX_FromLocation.SelectedValue,
                                    .InventoryJournaDetaillID = NewOutIJDetail.ID}
                                LMISDb.InventoryJournalDetailsBatches.AddObject(NewIJDetailsBatch)
                                LMISDb.SaveChanges()
                            End If
                        End If
                    Next
                    LMISDb.SaveChanges()
                    Transaction.Complete()
                End Using
                Return True
            ElseIf FRMMode.Equals(FRMModes.EditExisting) Then
                Using Transaction As New TransactionScope(TransactionScopeOption.RequiresNew)
                    Dim LMISDb As New LMISEntities
                    Dim GRN_OutIJ = From R In LMISDb.Transfers
                                    Join IJ In LMISDb.InventoryJournals
                                        On R.InventoryJournalOutID Equals IJ.ID
                                    Where R.ID = CMBX_TransferID.Text
                                    Select IJ
                    Dim GRN_InIJ = From R In LMISDb.Transfers
                                    Join IJ In LMISDb.InventoryJournals
                                        On R.InventoryJournalInID Equals IJ.ID
                                    Where R.ID = CMBX_TransferID.Text
                                    Select IJ
                    Dim Transfer = From R In LMISDb.Transfers
                                    Where R.ID = CMBX_TransferID.Text
                                    Select R
                    Transfer.First.FromLocation = CMBX_FromLocation.SelectedValue
                    Transfer.First.ToLocation = CMBX_ToLocation.SelectedValue
                    GRN_OutIJ.First.VoucherDate = DTP_VoucherDate.Value
                    GRN_OutIJ.First.Remark = TBX_Remark.Text
                    GRN_OutIJ.First.InventoryJournalStatusID = SaveStatus
                    GRN_InIJ.First.VoucherDate = DTP_VoucherDate.Value
                    GRN_InIJ.First.Remark = TBX_Remark.Text
                    GRN_InIJ.First.InventoryJournalStatusID = SaveStatus
                    LMISDb.SaveChanges()
                    Dim IJInID As String = GRN_InIJ.First.ID
                    Dim IJOutID As String = GRN_OutIJ.First.ID

                    Dim IJDInDelete = From IJD In LMISDb.InventoryJournalDetails Where IJD.InventoryJournalID = IJInID Select IJD
                    For Each IJDRow As InventoryJournalDetail In IJDInDelete
                        Dim IJDDeleteID As String = IJDRow.ID
                        Dim IJDBDelete = From IJDB In LMISDb.InventoryJournalDetailsBatches Where IJDB.InventoryJournaDetaillID = IJDDeleteID Select IJDB
                        LMISDb.InventoryJournalDetailsBatches.DeleteObject(IJDBDelete.First)
                    Next
                    LMISDb.SaveChanges()
                    For Each IJDRow As InventoryJournalDetail In IJDInDelete
                        LMISDb.InventoryJournalDetails.DeleteObject(IJDRow)
                    Next
                    LMISDb.SaveChanges()

                    Dim IJDOutDelete = From IJD In LMISDb.InventoryJournalDetails Where IJD.InventoryJournalID = IJOutID Select IJD
                    For Each IJDRow As InventoryJournalDetail In IJDOutDelete
                        Dim IJDDeleteID As String = IJDRow.ID
                        Dim IJDBDelete = From IJDB In LMISDb.InventoryJournalDetailsBatches Where IJDB.InventoryJournaDetaillID = IJDDeleteID Select IJDB
                        LMISDb.InventoryJournalDetailsBatches.DeleteObject(IJDBDelete.First)
                    Next
                    LMISDb.SaveChanges()
                    For Each IJDRow As InventoryJournalDetail In IJDOutDelete
                        LMISDb.InventoryJournalDetails.DeleteObject(IJDRow)
                    Next
                    LMISDb.SaveChanges()

                    For Each ItemRow As DataGridViewRow In DGV_Items.Rows
                        If Not ItemRow.IsNewRow Then
                            Dim NewInIJDetail As New InventoryJournalDetail With {
                                .ItemID = ItemRow.Cells("ItemID").Value,
                                .Quantity = ItemRow.Cells("Qty").Value,
                                .InventoryJournalID = GRN_InIJ.First.ID,
                                .Remark = ItemRow.Cells("Remark").Value}
                            LMISDb.InventoryJournalDetails.AddObject(NewInIJDetail)
                            If LMISDb.SaveChanges() > 0 Then
                                Dim NewIJDetailsBatch As New InventoryJournalDetailsBatch With {
                                    .InventoryBatchID = ItemRow.Cells("Batch").Value,
                                    .Price = ItemRow.Cells("Cost").Value,
                                    .LocationID = CMBX_ToLocation.SelectedValue,
                                    .InventoryJournaDetaillID = NewInIJDetail.ID}
                                LMISDb.InventoryJournalDetailsBatches.AddObject(NewIJDetailsBatch)
                                LMISDb.SaveChanges()
                            End If
                            Dim NewOutIJDetail As New InventoryJournalDetail With {
                                .ItemID = ItemRow.Cells("ItemID").Value,
                                .Quantity = ItemRow.Cells("Qty").Value,
                                .InventoryJournalID = GRN_OutIJ.First.ID,
                                .Remark = ItemRow.Cells("Remark").Value}
                            LMISDb.InventoryJournalDetails.AddObject(NewOutIJDetail)
                            If LMISDb.SaveChanges() > 0 Then
                                Dim NewIJDetailsBatch As New InventoryJournalDetailsBatch With {
                                    .InventoryBatchID = ItemRow.Cells("Batch").Value,
                                    .Price = ItemRow.Cells("Cost").Value,
                                    .LocationID = CMBX_FromLocation.SelectedValue,
                                    .InventoryJournaDetaillID = NewOutIJDetail.ID}
                                LMISDb.InventoryJournalDetailsBatches.AddObject(NewIJDetailsBatch)
                                LMISDb.SaveChanges()
                            End If
                        End If
                    Next
                    LMISDb.SaveChanges()
                    Transaction.Complete()
                End Using
                Return True
            End If
        Catch ex As Exception
            MessageBox.Show("Error: In Saving" & vbCrLf & ex.Message & Utility.InnerExecption(ex), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return False
    End Function

    Function ValidateDataForm() As Boolean
        ERP_Error.Clear()
        Dim No_Error As Boolean = True
        If CMBX_FromLocation.SelectedItem Is Nothing Or CMBX_FromLocation.Text = String.Empty Then
            ERP_Error.SetError(CMBX_FromLocation, "Select Appropriate 'Location'")
            No_Error = False
        End If
        If CMBX_ToLocation.SelectedItem Is Nothing Or CMBX_ToLocation.Text = String.Empty Then
            ERP_Error.SetError(CMBX_FromLocation, "Select Appropriate 'Location'")
            No_Error = False
        End If
        If DGV_Items.Rows.Count = 1 Then
            ERP_Error.SetError(DGV_Items, "At least 'One Item' should be requested")
            No_Error = False
        ElseIf Not DGV_Items.ValidateData() Then
            ERP_Error.SetError(DGV_Items, "Correct your errors in Items table")
            No_Error = False
        End If
        Return No_Error
    End Function

    Sub ClearForm()
        DTP_VoucherDate.Value = Date.Today
        TBX_Remark.Text = ""
        CMBX_FromLocation.SelectedItem = Nothing
        DGV_Items.Rows.Clear()
    End Sub

#End Region

#Region "Events"

    Private Sub BTN_Close_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTN_Close.Click
        Me.Close()
    End Sub

    Private Sub FRM_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If DGV_Items.Rows.Count > 1 Then If MessageBox.Show("Are you sure you want to close without saving your work?", "Are you sure?", System.Windows.Forms.MessageBoxButtons.YesNo, System.Windows.Forms.MessageBoxIcon.Information) = System.Windows.Forms.DialogResult.No Then e.Cancel = True
    End Sub

    Private Sub FRM_GotFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.GotFocus
        FRM_GLBMain.TLSL_MainStatus.Text = "Ready"
    End Sub

    Private Sub FRM_IJRequisition_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        DGV_Items.initMe(TBX_TotalCost, IJFRM_Types.TransfersEdit)
        LoadForm()
    End Sub

    Private Sub BTN_Save_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTN_Save.Click
        FRM_GLBMain.TLSL_MainStatus.Text = "Ready"
        If ValidateDataForm() Then
            If MessageBox.Show("Are you sure you want to save this STV", "Are you sure?", System.Windows.Forms.MessageBoxButtons.YesNo) = System.Windows.Forms.DialogResult.Yes Then
                Me.Cursor = Cursors.WaitCursor
                If SaveData(1) Then
                    FRM_GLBMain.TLSL_MainStatus.Text = "STV Saved"
                    ClearForm()
                    LoadForm()
                Else
                    FRM_GLBMain.TLSL_MainStatus.Text = "STV Not Saved"
                    MessageBox.Show("  STV NOT Saved    ", "Error in Saving", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
                Me.Cursor = Cursors.Default
            End If
        End If
    End Sub

    Private Sub BTN_Print_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTN_Print.Click
        FRM_GLBMain.TLSL_MainStatus.Text = "Ready"
        If ValidateDataForm() Then
            If MessageBox.Show("Are you sure you want to save this Transfer", "Are you sure?", System.Windows.Forms.MessageBoxButtons.YesNo) = System.Windows.Forms.DialogResult.Yes Then
                Me.Cursor = Cursors.WaitCursor
                If SaveData(1) Then
                    FRM_GLBMain.TLSL_MainStatus.Text = "STV Saved"
                    MessageBox.Show("STV Saved", "Data Saved", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Dim ReportParameter As New Dictionary(Of String, String())
                    ReportParameter.Add("ID", {CMBX_TransferID.Text})
                    FRM_Reporter.Show(ReportTypes.IJTransfer, ReportParameter)
                    ClearForm()
                    LoadForm()
                Else
                    FRM_GLBMain.TLSL_MainStatus.Text = "STV Not Saved"
                    MessageBox.Show("  STV NOT Saved    ", "Error in Saving", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
                Me.Cursor = Cursors.Default
            End If
        End If
    End Sub

    Private Sub BTN_Post_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTN_Post.Click
        FRM_GLBMain.TLSL_MainStatus.Text = "Ready"
        If ValidateDataForm() Then
            If MessageBox.Show("Are you sure you want to Post this STV" & vbCrLf & vbCrLf & "You will not be able to edit it again!", "Are you sure?", System.Windows.Forms.MessageBoxButtons.YesNo) = System.Windows.Forms.DialogResult.Yes Then
                Me.Cursor = Cursors.WaitCursor
                If SaveData(2) Then
                    FRM_GLBMain.TLSL_MainStatus.Text = "STV Posted"
                    MessageBox.Show("STV Posted", "Data Posted", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Dim ReportParameter As New Dictionary(Of String, String())
                    ReportParameter.Add("ID", {CMBX_TransferID.Text})
                    FRM_Reporter.Show(ReportTypes.IJTransfer, ReportParameter)
                    ClearForm()
                    LoadForm()
                Else
                    FRM_GLBMain.TLSL_MainStatus.Text = "STV Not Posted"
                    MessageBox.Show("  STV NOT Posted    ", "Error in Posting", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
                Me.Cursor = Cursors.Default
            End If
        End If
    End Sub

    Private Sub CMBX_RequestID_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBX_TransferID.SelectedIndexChanged
        Try
            If CMBX_TransferID.SelectedItem IsNot Nothing Then
                Dim LMISDb As New LMISEntities
                Dim Transfer_IJ = From R In LMISDb.Transfers
                                Join IJ In LMISDb.InventoryJournals
                                    On R.InventoryJournalInID Equals IJ.ID
                                Join LF In LMISDb.Locations
                                    On R.FromLocation Equals LF.ID
                                Join LT In LMISDb.Locations
                                    On R.ToLocation Equals LT.ID
                                Where R.ID = CMBX_TransferID.Text
                                Select IJ.VoucherDate, IJ.Remark, FromLocID = LF.ID, ToLocID = LT.ID
                If Transfer_IJ.Count > 0 Then
                    DTP_VoucherDate.Value = Transfer_IJ.First.VoucherDate
                    CMBX_FromLocation.SelectedValue = Transfer_IJ.First.FromLocID
                    CMBX_ToLocation.SelectedValue = Transfer_IJ.First.ToLocID
                    TBX_Remark.Text = Transfer_IJ.First.Remark
                End If
                DGV_Items.PopulateItems(CMBX_TransferID.Text)
            Else
                ClearForm()
            End If
        Catch ex As Exception
            MessageBox.Show("Error: In loading Requisitions" & vbCrLf & ex.Message & Utility.InnerExecption(ex), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub CMBX_FromLocation_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBX_FromLocation.SelectedIndexChanged, CMBX_FromLocation.TextChanged
        If CMBX_FromLocation.SelectedItem IsNot Nothing And CMBX_FromLocation.ValueMember <> String.Empty Then
            'Dim BatchLocations = From IJDB In (New LMISEntities).InventoryJournalDetailsBatches
            '         Where IJDB.InventoryJournalDetail.InventoryJournal.DepartmentID = FRM_GLBMain.ApplicationConfig.ThisDepartment.ID
            '         Select IJDB.Location.ID, LocationName = IJDB.Location.Name, StoreName = IJDB.Location.Store.Name Distinct
            'Dim RetLocations As New List(Of IDNdata)
            'For Each BatchLocation In BatchLocations
            '    If CMBX_FromLocation.SelectedValue <> BatchLocation.ID Then
            '        RetLocations.Add(New IDNdata(BatchLocation.ID, BatchLocation.StoreName & " | " & BatchLocation.LocationName, True))
            '    End If
            'Next
            'CMBX_ToLocation.DataSource = RetLocations
            CMBX_ToLocation.DataSource = (From Locs In Utility.Get_ItemBatchLocations() Where Locs.ID <> CMBX_FromLocation.SelectedValue Select Locs).ToList
            CMBX_ToLocation.SelectedItem = Nothing
            For Each ItemRow As DataGridViewRow In DGV_Items.Rows
                If Not ItemRow.IsNewRow Then
                    ItemRow.Cells("Batch").Value = String.Empty
                    ItemRow.Cells("Expiry_Date").Value = String.Empty
                    ItemRow.Cells("Batch_Location").Value = String.Empty
                    CType(ItemRow.Cells("Batch_Location"), ComboCell).BatchLocationID = CMBX_FromLocation.SelectedValue
                    ItemRow.Cells("Qty_Available").Value = 0
                    ItemRow.Cells("Cost").Value = 0
                    ItemRow.Cells("Amount").Value = 0
                End If
            Next
        Else
            CMBX_ToLocation.DataSource = Nothing
        End If
    End Sub

#End Region

End Class

