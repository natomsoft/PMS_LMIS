Imports System.Data.Objects
Imports System.Transactions
Public Class FRM_IJSupplyReceiveEdit

#Region "declarations"

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
            CMBX_ReceiveID.DataSource = From Rec In LMISDb.Recieves
                    Join IJRec In LMISDb.InventoryJournals
                        On Rec.InventoryJournalID Equals IJRec.ID
                    Join IJS In LMISDb.InventoryJournalStatus
                        On IJRec.InventoryJournalStatusID Equals IJS.ID
                    Where (IJRec.Void = False And IJRec.InventoryJournalStatu.Name = "Pending" And IJRec.DepartmentID = FRM_GLBMain.ApplicationConfig.ThisDepartment.ID)
                    Select Rec.ID
            CMBX_ReceiveID.AutoCompleteSource = AutoCompleteSource.ListItems
            CMBX_ReceiveID.SelectedItem = Nothing
        Catch ex As Exception
            MessageBox.Show("Error:" & vbCrLf & ex.Message & Utility.InnerExecption(ex), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Function SaveData(ByVal SaveStatus As Int16) As Boolean
        Try
            Using Transaction As New TransactionScope(TransactionScopeOption.RequiresNew)
                Dim LMISDb As New LMISEntities
                Dim Rec_IJ = From R In LMISDb.Recieves
                                    Join IJ In LMISDb.InventoryJournals
                                        On R.InventoryJournalID Equals IJ.ID
                                    Where (R.ID = CMBX_ReceiveID.Text)
                                    Select IJ
                LMISDb.SaveChanges()
                Dim Rec = From R In LMISDb.Recieves
                                    Where R.ID = CMBX_ReceiveID.Text
                                    Select R
                Dim Req_IJ = From R In LMISDb.Recieves
                                    Where R.ID = CMBX_ReceiveID.Text
                                    Select R.Request.InventoryJournal
                Rec_IJ.First.Remark = TBX_Remark.Text
                Rec_IJ.First.InventoryJournalStatusID = SaveStatus
                Rec_IJ.First.VoucherDate = DTP_VoucherDate.Value
                Req_IJ.First.InventoryJournalStatusID = SaveStatus
                Rec.First.ReferenceID = TBX_InvoiceNo.Text
                Dim IJID As String = Rec_IJ.First.ID
                LMISDb.SaveChanges()
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
                    If Not ItemRow.IsNewRow And DGV_Items.RowHasError(ItemRow) Then
                        Dim NewIJDetail As New InventoryJournalDetail With {
                            .ItemID = ItemRow.Cells("ItemID").Value,
                            .Quantity = ItemRow.Cells("Qty").Value,
                            .InventoryJournalID = Rec_IJ.First.ID,
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
            End Using
        Catch ex As Exception
            MessageBox.Show("Error: In Saving Data" & vbCrLf & ex.Message & Utility.InnerExecption(ex))
        End Try
        Return False
    End Function

    Function ValidateDataForm() As Boolean
        ERP_Error.Clear()
        Dim No_Error As Boolean = True
        If CMBX_ReceiveID.SelectedIndex = -1 Or CMBX_ReceiveID.Text = String.Empty Then
            ERP_Error.SetError(CMBX_ReceiveID, "Please select appropriate 'Request ID' from the list")
            No_Error = False
        End If
        If TBX_InvoiceNo.Text = "" Then
            ERP_Error.SetError(TBX_InvoiceNo, "'Reference ID' should not be empty")
            No_Error = False
        End If
        If DGV_Items.Rows.Count = 1 Then
            ERP_Error.SetError(DGV_Items, "At least 'One Item' should be requested")
            No_Error = False
        ElseIf Not DGV_Items.ValidateData() Then
            ERP_Error.SetError(DGV_Items, "Correct your errors in Items table")
            If No_Error Then
                Dim OneRowNoError As Boolean = False
                For Each Row As DataGridViewRow In DGV_Items.Rows
                    If Not Row.IsNewRow And DGV_Items.RowHasError(Row) Then OneRowNoError = True
                Next
                If OneRowNoError Then
                    If MessageBox.Show("There are some errors in your items table." & vbCrLf & vbCrLf & "Would you like to disregard the errors and only save rows that have no errors?", "Disregard item table errors?", System.Windows.Forms.MessageBoxButtons.YesNo, MessageBoxIcon.Question) = System.Windows.Forms.DialogResult.Yes Then
                        No_Error = True
                    Else
                        No_Error = False
                    End If
                Else
                    No_Error = False
                End If
            End If
        End If
        Return No_Error
    End Function

    Sub ClearForm()
        DTP_VoucherDate.Value = Date.Today
        TBX_Remark.Text = ""
        TBX_InvoiceNo.Text = ""
        TBX_Facility.Text = ""
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

    Private Sub FRM_IJReceipt_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ClearForm()
        DGV_Items.initMe(TBX_TotalCost, IJFRM_Types.ReceiveEdit)
        LoadForm()
    End Sub

    Private Sub BTN_Save_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTN_Save.Click
        FRM_GLBMain.TLSL_MainStatus.Text = "Ready"
        If ValidateDataForm() Then
            If MessageBox.Show("Are you sure you want to save this Supply Receive", "Are you sure?", System.Windows.Forms.MessageBoxButtons.YesNo) = System.Windows.Forms.DialogResult.Yes Then
                Me.Cursor = Cursors.WaitCursor
                If SaveData(1) Then
                    FRM_GLBMain.TLSL_MainStatus.Text = "Supply Receive Saved"
                    MessageBox.Show("Supply Receive Saved", "Data Saved", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    ClearForm()
                    LoadForm()
                Else
                    FRM_GLBMain.TLSL_MainStatus.Text = "Supply Receive NOT Saved"
                    MessageBox.Show("    Supply Receive NOT Saved    ", "Error in Saving", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
                Me.Cursor = Cursors.Default
            End If
        End If
    End Sub

    Private Sub BTN_Print_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTN_Print.Click
        FRM_GLBMain.TLSL_MainStatus.Text = "Ready"
        If ValidateDataForm() Then
            If MessageBox.Show("Are you sure you want to save and print this Supply Receive", "Are you sure?", System.Windows.Forms.MessageBoxButtons.YesNo) = System.Windows.Forms.DialogResult.Yes Then
                Me.Cursor = Cursors.WaitCursor
                If SaveData(1) Then
                    FRM_GLBMain.TLSL_MainStatus.Text = "Supply Receive Saved"
                    MessageBox.Show("Supply Receive Saved", "Data Saved", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Dim ReportParameter As New Dictionary(Of String, String())
                    ReportParameter.Add("ID", {CMBX_ReceiveID.Text})
                    FRM_Reporter.Show(ReportTypes.IJReceive, ReportParameter)
                    ClearForm()
                    LoadForm()
                Else
                    FRM_GLBMain.TLSL_MainStatus.Text = "Supply Receive NOT Saved"
                    MessageBox.Show("    Supply Receive NOT Saved    ", "Error in Saving", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
                Me.Cursor = Cursors.Default
            End If
        End If
    End Sub

    Private Sub BTN_Post_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTN_Post.Click
        FRM_GLBMain.TLSL_MainStatus.Text = "Ready"
        If ValidateDataForm() Then
            If MessageBox.Show("Are you sure you want to Save and Post this Supply Receive", "Are you sure?", System.Windows.Forms.MessageBoxButtons.YesNo) = System.Windows.Forms.DialogResult.Yes Then
                Me.Cursor = Cursors.WaitCursor
                If SaveData(2) Then
                    FRM_GLBMain.TLSL_MainStatus.Text = "Supply Receive Saved and Posted"
                    MessageBox.Show("Supply Receive Saved and Posted", "Data Saved", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Dim ReportParameter As New Dictionary(Of String, String())
                    ReportParameter.Add("ID", {CMBX_ReceiveID.Text})
                    FRM_Reporter.Show(ReportTypes.IJReceive, ReportParameter)
                    ClearForm()
                    LoadForm()
                Else
                    FRM_GLBMain.TLSL_MainStatus.Text = "Supply Receive NOT Saved"
                    MessageBox.Show("    Supply Receive NOT Saved    ", "Error in Saving", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
                Me.Cursor = Cursors.Default
            End If
        End If
    End Sub

    Private Sub CMBX_IJRequestID_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBX_ReceiveID.SelectedIndexChanged
        Try
            If CMBX_ReceiveID.SelectedItem IsNot Nothing Then
                Dim LMISDb As New LMISEntities
                Dim Received = From Rec In LMISDb.Recieves
                               Join Req In LMISDb.Requests
                                    On Rec.RequestID Equals Req.ID
                               Join L In LMISDb.Departments
                                    On Req.DepartmentID Equals L.ID
                               Join IJRec In LMISDb.InventoryJournals
                                    On IJRec.ID Equals Rec.InventoryJournalID
                               Join IJReq In LMISDb.InventoryJournals
                                    On IJReq.ID Equals Req.InventoryJournalID
                               Where (IJRec.Void = False And IJReq.Void = False And Rec.ID = CMBX_ReceiveID.Text)
                               Select FacilityName = L.Name, Rec.ReferenceID, IJRec.Remark, ReqID = Req.ID, IJRec.VoucherDate
                If Not Received.Count = 0 Then
                    TBX_Facility.Text = Received.First.FacilityName
                    TBX_InvoiceNo.Text = Received.First.ReferenceID
                    TBX_Remark.Text = Received.First.Remark
                    TBX_RequestID.Text = Received.First.ReqID
                    DTP_VoucherDate.Value = Received.First.VoucherDate
                Else
                    TBX_Facility.Text = ""
                    TBX_InvoiceNo.Text = ""
                    TBX_Remark.Text = ""
                End If
                DGV_Items.PopulateItems(CMBX_ReceiveID.Text)
            Else
                ClearForm()
            End If
        Catch ex As Exception
            MessageBox.Show("Error:" & vbCrLf & ex.Message & Utility.InnerExecption(ex), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub DGV_Items_CellContentClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DGV_Items.Click
        DGV_Items.Refresh()
    End Sub

#End Region

End Class

