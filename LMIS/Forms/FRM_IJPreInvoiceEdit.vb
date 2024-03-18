Imports System.Data.Objects
Imports System.Transactions
Public Class FRM_IJPreInvoiceEdit

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
            CMBX_IssuedID.DataSource = From Iss In LMISDb.Issues
                    Join IJ In LMISDb.InventoryJournals
                        On Iss.InventoryJournalID Equals IJ.ID
                    Join IJS In LMISDb.InventoryJournalStatus
                        On IJS.ID Equals IJ.InventoryJournalStatusID
                    Where (IJ.Void = False And IJS.Name = "Pending" And IJ.DepartmentID = FRM_GLBMain.ApplicationConfig.ThisDepartment.ID)
                    Select Iss.ID
            CMBX_IssuedID.AutoCompleteSource = AutoCompleteSource.ListItems
            CMBX_IssuedID.SelectedItem = Nothing
        Catch ex As Exception
            MessageBox.Show("Error: In Loading form" & vbCrLf & ex.Message & Utility.InnerExecption(ex), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Function SaveData(ByVal SaveStatus As Integer) As Boolean
        For Each ItemRow As DataGridViewRow In DGV_Items.Rows
            Try
                Dim expDate As Date = ItemRow.Cells("Expiry_Date").Value
                If expDate < Today And expDate <> "12:00:00 AM" Then
                    MsgBox("The list contains expired items please remove them first")
                    Return False
                End If
            Catch ex As Exception
            End Try
        Next
        Try
            Using Transaction As New TransactionScope(TransactionScopeOption.RequiresNew)
                Dim LMISDb As New LMISEntities
                Dim Iss_IJ = From R In LMISDb.Issues
                                    Join IJ In LMISDb.InventoryJournals
                                        On R.InventoryJournalID Equals IJ.ID
                                Where (R.ID = CMBX_IssuedID.Text)
                                    Select IJ
                Iss_IJ.First.Remark = TBX_Remark.Text
                Iss_IJ.First.VoucherDate = DTP_VoucherDate.Value
                Iss_IJ.First.InventoryJournalStatusID = SaveStatus

                Dim IJID As String = Iss_IJ.First.ID
                If LMISDb.SaveChanges() > 0 Then
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
                                .InventoryJournalID = IJID,
                                .Remark = ItemRow.Cells("Remark").Value}
                            LMISDb.InventoryJournalDetails.AddObject(NewIJDetail)
                            LMISDb.SaveChanges()
                            Dim NewIJDetailsBatch As New InventoryJournalDetailsBatch With {
                                .InventoryBatchID = ItemRow.Cells("Batch").Value,
                                .Price = ItemRow.Cells("Cost").Value,
                                .LocationID = CType(ItemRow.Cells("Batch_Location"), ComboCell).BatchLocationID,
                                .InventoryJournaDetaillID = NewIJDetail.ID}
                            LMISDb.InventoryJournalDetailsBatches.AddObject(NewIJDetailsBatch)
                            LMISDb.SaveChanges()
                        End If
                    Next
                    LMISDb.SaveChanges()
                End If
                Transaction.Complete()
                Return True
            End Using
        Catch ex As Exception
            MessageBox.Show("Error: In Saving data" & vbCrLf & ex.Message & Utility.InnerExecption(ex), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return False
    End Function

    Function ValidateDataForm() As Boolean
        ERP_Error.Clear()
        Dim No_Error As Boolean = True
        If CMBX_IssuedID.SelectedIndex = -1 Or CMBX_IssuedID.Text = String.Empty Then
            ERP_Error.SetError(CMBX_IssuedID, "Please select appropriate 'Request ID' from the list")
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

    Function Save_Reject() As Boolean
        Try
            Dim LMISDb As New LMISEntities
            Dim Req_IJ = From R In LMISDb.Issues
                    Join IJ In LMISDb.InventoryJournals
                        On R.InventoryJournalID Equals IJ.ID
                    Where R.ID = CMBX_IssuedID.Text
                    Select IJ
            Req_IJ.First.InventoryJournalStatusID = 3 ' for rejected
            LMISDb.SaveChanges()
            Return True
        Catch ex As Exception
            MessageBox.Show("Error:" & vbCrLf & ex.Message & Utility.InnerExecption(ex), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try
        Return False
    End Function

    Function Validate_Reject_Data() As Boolean
        ERP_Error.Clear()
        Dim No_Error As Boolean = True
        If (IsNothing(CMBX_IssuedID.SelectedItem) Or CMBX_IssuedID.Text = String.Empty) Then
            ERP_Error.SetError(CMBX_IssuedID, "Select Appropriate 'Issue ID'")
            No_Error = False
        End If
        Return No_Error
    End Function

    Sub ClearForm()
        DTP_VoucherDate.Value = Date.Today
        TBX_Remark.Text = ""
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
        DGV_Items.initMe(TBX_TotalCost, IJFRM_Types.IssueEdit)
        LoadForm()
    End Sub

    Private Sub BTN_Save_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTN_Save.Click
        FRM_GLBMain.TLSL_MainStatus.Text = "Ready"
        If ValidateDataForm() Then
            If MessageBox.Show("Are you sure you want to save this Pre-Invoice", "Are you sure?", System.Windows.Forms.MessageBoxButtons.YesNo) = System.Windows.Forms.DialogResult.Yes Then
                Me.Cursor = Cursors.WaitCursor
                If SaveData(1) Then
                    FRM_GLBMain.TLSL_MainStatus.Text = "Pre-Invoice Saved"
                    MessageBox.Show("Pre-Invoice Saved", "Data Saved", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    'Dim ReportParameter As New Dictionary(Of String, String())
                    'ReportParameter.Add("ID", {CMBX_IssuedID.Text})
                    'FRM_Reporter1.Show(ReportTypes.IJInvoice, ReportParameter)
                    ClearForm()
                    LoadForm()
                Else
                    FRM_GLBMain.TLSL_MainStatus.Text = "Invoice NOT Saved"
                    MessageBox.Show("  Invoice Not Saved   ", "Error in Saving", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            End If
            Me.Cursor = Cursors.Default
        End If
    End Sub

    Private Sub BTN_Print_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTN_Print.Click
        If ValidateDataForm() Then
            If MessageBox.Show("Are you sure you want to save this Pre-Invoice", "Are you sure?", System.Windows.Forms.MessageBoxButtons.YesNo) = System.Windows.Forms.DialogResult.Yes Then
                Me.Cursor = Cursors.WaitCursor
                If SaveData(1) Then
                    FRM_GLBMain.TLSL_MainStatus.Text = "Pre-Invoice Saved"
                    MessageBox.Show("Pre-Invoice Saved", "Data Saved", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Dim ReportParameter As New Dictionary(Of String, String())
                    ReportParameter.Add("ID", {CMBX_IssuedID.Text})
                    FRM_Reporter.Show(ReportTypes.IJPreinvoice, ReportParameter)
                    ClearForm()
                    LoadForm()
                Else
                    FRM_GLBMain.TLSL_MainStatus.Text = "Pre-Invoice NOT Saved"
                    MessageBox.Show("  Pre-Invoice Not Saved   ", "Error in Saving", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            End If
            Me.Cursor = Cursors.Default
        End If
    End Sub

    Private Sub BTN_Void_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTN_Void.Click
        If ValidateDataForm() Then
            Me.Cursor = Cursors.WaitCursor
            If MessageBox.Show("Are you sure you want to invalidate this Pre-Invoice", "Are you sure?", System.Windows.Forms.MessageBoxButtons.YesNo) = System.Windows.Forms.DialogResult.Yes Then
                Try
                    Dim LMISDb As New LMISEntities
                    Dim Req_IJ = From R In LMISDb.Issues
                            Join IJ In LMISDb.InventoryJournals
                                On R.InventoryJournalID Equals IJ.ID
                            Where R.ID = CMBX_IssuedID.Text
                            Select IJ
                    Req_IJ.First.InventoryJournalStatusID = 3 'for rejected
                    Req_IJ.First.Void = True ' for void
                    LMISDb.SaveChanges()
                Catch ex As Exception
                    MessageBox.Show("Error:" & vbCrLf & ex.Message & Utility.InnerExecption(ex), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    MessageBox.Show("  Data NOT Saved    ", "Error in Saving", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
                MessageBox.Show("  Data Saved    ", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                ClearForm()
                LoadForm()
            End If
            Me.Cursor = Cursors.Default
        End If
    End Sub

    Private Sub CMBX_IJRequestID_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBX_IssuedID.SelectedIndexChanged
        Try
            If CMBX_IssuedID.SelectedItem IsNot Nothing Then
                Dim LMISDb As New LMISEntities
                Dim Received = From Iss In LMISDb.Issues
                               Join Req In LMISDb.Requisitions
                                    On Iss.RequisitionID Equals Req.ID
                               Join L In LMISDb.Departments
                                    On Req.DepartmentID Equals L.ID
                               Join IJIss In LMISDb.InventoryJournals
                                    On IJIss.ID Equals Iss.InventoryJournalID
                               Join IJReq In LMISDb.InventoryJournals
                                    On IJReq.ID Equals Req.InventoryJournalID
                               Where (IJIss.Void = False And IJReq.Void = False And Iss.ID = CMBX_IssuedID.Text)
                               Select FacilityName = L.Name, IJIss.Remark, ReqID = Req.ID, Req.InventoryJournal.VoucherDate
                If Not Received.Count = 0 Then
                    TBX_Facility.Text = Received.First.FacilityName
                    TBX_Remark.Text = Received.First.Remark
                    TBX_RequsitionID.Text = Received.First.ReqID
                    DTP_VoucherDate.MinDate = Received.First.VoucherDate
                Else
                    TBX_Facility.Text = ""
                    TBX_Remark.Text = ""
                End If
                DGV_Items.PopulateItems(CMBX_IssuedID.Text)
            Else
                ClearForm()
            End If
        Catch ex As Exception
            MessageBox.Show("Error:" & vbCrLf & ex.Message & Utility.InnerExecption(ex), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

#End Region

End Class

