Imports System.Transactions
Public Class FRM_IJGRV

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
                CMBX_GRVID.Enabled = False 'disallow editting
                CMBX_GRVID.Text = Utility.GenerateID(IDTypes.GRN)
                Me.Text = "Add new GRN"
            Else
                CMBX_GRVID.DataSource = From A In LMISDb.GRNs Where A.InventoryJournal.InventoryJournalStatu.Name = "Pending" Select A.ID
                CMBX_GRVID.AutoCompleteSource = AutoCompleteSource.ListItems
                CMBX_GRVID.SelectedItem = Nothing
                Me.Text = "Edit existing GRN"
            End If
            CMBX_GRVID.SelectedItem = Nothing

            CMBX_Supplier.DataSource = From S In LMISDb.Suppliers Select S.ID, S.Company.Name
            CMBX_Supplier.ValueMember = "ID"
            CMBX_Supplier.DisplayMember = "Name"
            CMBX_Supplier.SelectedItem = Nothing
        Catch ex As Exception
            MessageBox.Show("Error:" & vbCrLf & ex.Message & Utility.InnerExecption(ex), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Function SaveData(ByVal SaveStatus As Int16) As Boolean
        Try
            Using Transaction As New TransactionScope(TransactionScopeOption.RequiresNew)
                If FRMMode.Equals(FRMModes.AddNew) Then
                    Dim LMISDb As New LMISEntities
                    Dim NewIJ As New InventoryJournal With {
                        .ID = Utility.GenerateID(IDTypes.IJ),
                        .DepartmentID = FRM_GLBMain.ApplicationConfig.ThisDepartment.ID,
                        .VoucherDate = DTP_VoucherDate.Value,
                        .TransactionDate = Date.Today,
                        .Remark = TBX_Remark.Text,
                        .EmployeeID = FRM_GLBMain.ApplicationConfig.Employee.ID,
                        .Void = False,
                        .InventoryJournalTypeID = 20,
                        .InventoryJournalStatusID = SaveStatus} '1 for Processed
                    LMISDb.InventoryJournals.AddObject(NewIJ)
                    If LMISDb.SaveChanges() > 0 Then
                        CMBX_GRVID.Text = Utility.GenerateID(IDTypes.GRN)
                        Dim NewGRN As New GRN With {
                            .ID = CMBX_GRVID.Text,
                            .InventoryJournalID = NewIJ.ID,
                            .SupplierID = CMBX_Supplier.SelectedValue,
                            .ReferenceID = TBX_ReferenceID.Text}
                        LMISDb.GRNs.AddObject(NewGRN)
                        LMISDb.SaveChanges()
                        For Each ItemRow As DataGridViewRow In DGV_Items.Rows
                            If Not ItemRow.IsNewRow Then
                                Dim NewIJDetail As New InventoryJournalDetail With {
                                    .ItemID = ItemRow.Cells("ItemID").Value,
                                    .Quantity = ItemRow.Cells("Qty").Value,
                                    .InventoryJournalID = NewIJ.ID,
                                    .Remark = ItemRow.Cells("Remark").Value}
                                LMISDb.InventoryJournalDetails.AddObject(NewIJDetail)
                                Dim Batch As String = ItemRow.Cells("Batch").Value
                                Dim ItemBatch = From IB In LMISDb.InventoryBatches Where IB.ID = Batch Select IB
                                If ItemBatch.Count > 0 Then 'IF Batch already in database
                                    If Not ItemRow.Cells("Expiry_Date").ReadOnly Then ItemBatch.First.ExpireDate = Date.Parse(ItemRow.Cells("Expiry_Date").Value)
                                Else
                                    Utility.Save_Batch(ItemRow.Cells("Batch").Value, ItemRow.Cells("Cost").Value, ItemRow.Cells("Expiry_Date").Value, 1, -1)
                                End If
                                If LMISDb.SaveChanges() > 0 Then
                                    Dim NewIJDetailsBatch As New InventoryJournalDetailsBatch With {
                                        .InventoryBatchID = ItemRow.Cells("Batch").Value,
                                        .Price = ItemRow.Cells("Cost").Value,
                                        .LocationID = CType(ItemRow.Cells("Batch_Location"), ComboCell).BatchLocationID,
                                        .InventoryJournaDetaillID = NewIJDetail.ID}
                                    LMISDb.InventoryJournalDetailsBatches.AddObject(NewIJDetailsBatch)
                                    LMISDb.SaveChanges()
                                End If
                            End If
                        Next
                        LMISDb.SaveChanges()
                        Transaction.Complete()
                        Return True
                    End If
                ElseIf FRMMode.Equals(FRMModes.EditExisting) Then
                    Dim LMISDb As New LMISEntities
                    Dim GRN_IJ = From R In LMISDb.GRNs
                                    Join IJ In LMISDb.InventoryJournals
                                        On R.InventoryJournalID Equals IJ.ID
                                    Where R.ID = CMBX_GRVID.Text
                                    Select IJ
                    Dim GRN = From R In LMISDb.GRNs
                                    Where R.ID = CMBX_GRVID.Text
                                    Select R
                    If GRN_IJ.Count > 0 Then
                        GRN.First.SupplierID = CMBX_Supplier.SelectedValue
                        GRN.First.ReferenceID = TBX_ReferenceID.Text
                        GRN_IJ.First.VoucherDate = DTP_VoucherDate.Value
                        GRN_IJ.First.Remark = TBX_Remark.Text
                        GRN_IJ.First.InventoryJournalStatusID = SaveStatus
                        If LMISDb.SaveChanges() > 0 Then
                            Dim IJID As String = GRN_IJ.First.ID
                            Dim IJDDelete = From IJD In LMISDb.InventoryJournalDetails
                                     Where IJD.InventoryJournalID = IJID
                                     Select IJD
                            For Each IJDRow As InventoryJournalDetail In IJDDelete
                                Dim IJDDeleteID As String = IJDRow.ID
                                Dim IJDBDelete = From IJDB In LMISDb.InventoryJournalDetailsBatches
                                            Where IJDB.InventoryJournaDetaillID = IJDDeleteID
                                            Select IJDB
                                LMISDb.InventoryJournalDetailsBatches.DeleteObject(IJDBDelete.First)
                            Next
                            LMISDb.SaveChanges()
                            For Each IJDRow As InventoryJournalDetail In IJDDelete
                                LMISDb.InventoryJournalDetails.DeleteObject(IJDRow)
                            Next
                            LMISDb.SaveChanges()

                            For Each ItemRow As DataGridViewRow In DGV_Items.Rows
                                If Not ItemRow.IsNewRow Then
                                    Dim NewIJDetail As New InventoryJournalDetail With {
                                        .ItemID = ItemRow.Cells("ItemID").Value,
                                        .Quantity = ItemRow.Cells("Qty").Value,
                                        .InventoryJournalID = GRN_IJ.First.ID,
                                        .Remark = ItemRow.Cells("Remark").Value}
                                    LMISDb.InventoryJournalDetails.AddObject(NewIJDetail)
                                    LMISDb.SaveChanges()
                                    Dim Batch As String = ItemRow.Cells("Batch").Value
                                    Dim ItemBatch = From IB In LMISDb.InventoryBatches Where IB.ID = Batch Select IB
                                    If ItemBatch.Count > 0 Then 'IF Batch already in database
                                        If Not ItemRow.Cells("Expiry_Date").ReadOnly Then ItemBatch.First.ExpireDate = Date.Parse(ItemRow.Cells("Expiry_Date").Value)
                                    Else
                                        Utility.Save_Batch(ItemRow.Cells("Batch").Value, ItemRow.Cells("Cost").Value, ItemRow.Cells("Expiry_Date").Value, 1, -1)
                                    End If
                                    Dim NewIJDBatch As New InventoryJournalDetailsBatch With {
                                        .Price = ItemRow.Cells("Cost").Value,
                                        .InventoryBatchID = ItemRow.Cells("Batch").Value,
                                        .LocationID = CType(ItemRow.Cells("Batch_Location"), ComboCell).BatchLocationID,
                                        .InventoryJournaDetaillID = NewIJDetail.ID}
                                    LMISDb.InventoryJournalDetailsBatches.AddObject(NewIJDBatch)
                                End If
                            Next
                            LMISDb.SaveChanges()
                            Transaction.Complete()
                            Return True
                        End If
                    End If
                End If
            End Using
        Catch ex As Exception
            MessageBox.Show("Error:" & vbCrLf & ex.Message & Utility.InnerExecption(ex), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return False
    End Function

    Function ValidateDataForm() As Boolean
        ERP_Error.Clear()
        Dim No_Error As Boolean = True
        If CMBX_Supplier.SelectedIndex = -1 Or CMBX_GRVID.Text = String.Empty Then
            ERP_Error.SetError(CMBX_Supplier, "Select Appropriate 'Adjustment Type'")
            No_Error = False
        End If
        If TBX_ReferenceID.Text = String.Empty Then
            ERP_Error.SetError(TBX_ReferenceID, "Select Appropriate 'Adjustment Type'")
            No_Error = False
        End If
        If IsNothing(CMBX_Supplier.SelectedItem) Or CMBX_Supplier.Text = String.Empty Then
            ERP_Error.SetError(CMBX_Supplier, "Select Appropriate 'Facility'")
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
        CMBX_Supplier.SelectedItem = Nothing
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
        DGV_Items.initMe(TBX_TotalCost, IJFRM_Types.GRNEdit)
        LoadForm()
    End Sub

    Private Sub BTN_Save_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTN_Save.Click
        FRM_GLBMain.TLSL_MainStatus.Text = "Ready"
        If ValidateDataForm() Then
            If MessageBox.Show("Are you sure you want to save this GRV", "Are you sure?", System.Windows.Forms.MessageBoxButtons.YesNo) = System.Windows.Forms.DialogResult.Yes Then
                Me.Cursor = Cursors.WaitCursor
                If SaveData(1) Then
                    FRM_GLBMain.TLSL_MainStatus.Text = "GRV Saved"
                    MessageBox.Show("GRV Saved", "Data Saved", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    ClearForm()
                    LoadForm()
                Else
                    FRM_GLBMain.TLSL_MainStatus.Text = "GRV Not Saved"
                    MessageBox.Show("  GRV NOT Saved    ", "Error in Saving", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
                Me.Cursor = Cursors.Default
            End If
        End If
    End Sub

    Private Sub BTN_Print_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTN_Print.Click
        FRM_GLBMain.TLSL_MainStatus.Text = "Ready"
        If ValidateDataForm() Then
            If MessageBox.Show("Are you sure you want to save this GRV", "Are you sure?", System.Windows.Forms.MessageBoxButtons.YesNo) = System.Windows.Forms.DialogResult.Yes Then
                Me.Cursor = Cursors.WaitCursor
                If SaveData(1) Then
                    FRM_GLBMain.TLSL_MainStatus.Text = "GRV Saved"
                    MessageBox.Show("GRV Saved", "Data Saved", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Dim ReportParameter As New Dictionary(Of String, String())
                    ReportParameter.Add("ID", {CMBX_GRVID.Text})
                    FRM_Reporter.Show(ReportTypes.IJGRN, ReportParameter)
                    ClearForm()
                    LoadForm()
                Else
                    FRM_GLBMain.TLSL_MainStatus.Text = "GRV Not Saved"
                    MessageBox.Show("  GRV NOT Saved    ", "Error in Saving", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
                Me.Cursor = Cursors.Default
            End If
        End If
    End Sub

    Private Sub BTN_Post_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTN_Post.Click
        FRM_GLBMain.TLSL_MainStatus.Text = "Ready"
        If ValidateDataForm() Then
            If MessageBox.Show("Are you sure you want to Post this GRV" & vbCrLf & vbCrLf & "You will not be able to edit it again!", "Are you sure?", System.Windows.Forms.MessageBoxButtons.YesNo) = System.Windows.Forms.DialogResult.Yes Then
                Me.Cursor = Cursors.WaitCursor
                If SaveData(2) Then
                    FRM_GLBMain.TLSL_MainStatus.Text = "GRV Saved"
                    MessageBox.Show("GRV Saved", "Data Saved", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Dim ReportParameter As New Dictionary(Of String, String())
                    ReportParameter.Add("ID", {CMBX_GRVID.Text})
                    FRM_Reporter.Show(ReportTypes.IJGRN, ReportParameter)
                    ClearForm()
                    LoadForm()
                Else
                    FRM_GLBMain.TLSL_MainStatus.Text = "GRV Not Saved"
                    MessageBox.Show("  GRV NOT Saved    ", "Error in Saving", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
                Me.Cursor = Cursors.Default
            End If
        End If
    End Sub

    Private Sub CMBX_RequestID_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBX_GRVID.SelectedIndexChanged
        Try
            If CMBX_GRVID.SelectedItem IsNot Nothing Then
                Dim LMISDb As New LMISEntities
                Dim GRN_IJ = From R In LMISDb.GRNs
                                Join IJ In LMISDb.InventoryJournals
                                    On R.InventoryJournalID Equals IJ.ID
                                Join S In LMISDb.Suppliers
                                    On R.SupplierID Equals S.ID
                                Where R.ID = CMBX_GRVID.Text
                                Select IJ.VoucherDate, IJ.Remark, SupplierID = S.ID, R.ReferenceID

                If GRN_IJ.Count > 0 Then
                    DTP_VoucherDate.Value = GRN_IJ.First.VoucherDate
                    TBX_ReferenceID.Text = GRN_IJ.First.ReferenceID
                    CMBX_Supplier.SelectedValue = GRN_IJ.First.SupplierID
                    TBX_Remark.Text = GRN_IJ.First.Remark
                End If
                DGV_Items.PopulateItems(CMBX_GRVID.Text)
            Else
                ClearForm()
            End If
        Catch ex As Exception
            MessageBox.Show("Error: In loading Requisitions" & vbCrLf & ex.Message & Utility.InnerExecption(ex), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

#End Region

End Class

