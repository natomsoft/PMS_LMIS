Imports System.Data.Objects
Imports System.Transactions
Public Class FRM_IJSupplyReceive

#Region "declarations"
    Private ReceiveID As String
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
            Dim Requests = (From Req In LMISDb.Requests
                                Join IJ In LMISDb.InventoryJournals
                                    On Req.InventoryJournalID Equals IJ.ID
                                Join IJS In LMISDb.InventoryJournalStatus
                                    On IJ.InventoryJournalStatusID Equals IJS.ID
                                Where (IJ.Void = False And IJ.DepartmentID = FRM_GLBMain.ApplicationConfig.ThisDepartment.ID)
                                Select Req.ID).Except(
                            From Rec In LMISDb.Recieves
                                Join Req In LMISDb.Requests
                                    On Rec.RequestID Equals Req.ID
                                Join IJRec In LMISDb.InventoryJournals
                                    On Rec.InventoryJournalID Equals IJRec.ID
                                Join IJReq In LMISDb.InventoryJournals
                                    On Req.InventoryJournalID Equals IJReq.ID
                                Where (IJRec.Void = False And IJReq.Void = False And IJReq.DepartmentID = FRM_GLBMain.ApplicationConfig.ThisDepartment.ID And IJReq.DepartmentID = FRM_GLBMain.ApplicationConfig.ThisDepartment.ID)
                                Select Req.ID)
            CMBX_RequestID.DataSource = Requests
            CMBX_RequestID.AutoCompleteSource = AutoCompleteSource.ListItems
            CMBX_RequestID.SelectedItem = Nothing

        Catch ex As Exception
            MessageBox.Show("Error:" & vbCrLf & ex.Message & Utility.InnerExecption(ex), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Function SaveData(ByVal SaveStatus As Int16) As Boolean
        Try
            Using Transaction As New TransactionScope(TransactionScopeOption.RequiresNew)
                Dim LMISDb As New LMISEntities
                Dim NewIJ As New InventoryJournal With {
                    .ID = Utility.GenerateID(IDTypes.IJ),
                    .DepartmentID = FRM_GLBMain.ApplicationConfig.ThisDepartment.ID,
                    .VoucherDate = DTP_VoucherDate.Value,
                    .TransactionDate = Date.Today,
                    .Remark = TBX_Remark.Text,
                    .InventoryJournalTypeID = 2,
                    .EmployeeID = FRM_GLBMain.ApplicationConfig.Employee.ID,
                    .Void = False,
                    .InventoryJournalStatusID = SaveStatus} '2 for Processed
                LMISDb.InventoryJournals.AddObject(NewIJ)
                Dim Requ_IJ As ObjectQuery(Of InventoryJournal) = From IJ In LMISDb.InventoryJournals
                             Join R In LMISDb.Requests
                                On R.InventoryJournalID Equals IJ.ID
                            Where R.ID = CMBX_RequestID.Text
                            Select IJ
                Requ_IJ.First.InventoryJournalStatusID = SaveStatus
                LMISDb.SaveChanges()
                ReceiveID = Utility.GenerateID(IDTypes.Receive)
                Dim NewReceive As New Recieve With {
                    .ID = ReceiveID,
                    .RequestID = CMBX_RequestID.Text,
                    .InventoryJournalID = NewIJ.ID,
                    .ReferenceID = TBX_InvoiceNo.Text}
                LMISDb.Recieves.AddObject(NewReceive)
                LMISDb.SaveChanges()
                For Each ItemRow As DataGridViewRow In DGV_Items.Rows
                    If Not ItemRow.IsNewRow And DGV_Items.RowHasError(ItemRow) Then
                        Dim ItemID As String = ItemRow.Cells("ItemID").Value
                        Dim BatchID As String = ItemRow.Cells("Batch").Value
                      
                        Dim NewIJDetail As New InventoryJournalDetail With {
                            .ItemID = ItemRow.Cells("ItemID").Value,
                            .Quantity = ItemRow.Cells("Qty").Value,
                            .InventoryJournalID = NewIJ.ID,
                            .Remark = ItemRow.Cells("Remark").Value}
                        LMISDb.InventoryJournalDetails.AddObject(NewIJDetail)

                        If LMISDb.SaveChanges() > 0 Then
                            Dim Batch As String = ItemRow.Cells("Batch").Value
                            While True
                                Dim ItemBatch = From IB In LMISDb.InventoryBatches Where IB.ID = Batch Select IB
                                Dim Batc = (From IJDB In (New LMISEntities).InventoryJournalDetailsBatches Where IJDB.InventoryBatchID = Batch Select IJDB)

                                'If ItemBatch.Count > 0 Then 'IF Batch already in database
                                If ItemBatch.Count > 0 Then 'IF Batch already in database

                                    If Batc.Count > 0 Then
                                        If Batc.First.InventoryJournalDetail.ItemID = ItemID And Batc.First.Price = ItemRow.Cells("Cost").Value Then
                                            If Not ItemRow.Cells("Expiry_Date").ReadOnly Then ItemBatch.First.ExpireDate = Date.Parse(ItemRow.Cells("Expiry_Date").Value)

                                            Exit While
                                        
                                        End If
                                    End If
                                       Else
                                    Utility.Save_Batch(ItemRow.Cells("Batch").Value, ItemRow.Cells("Cost").Value, ItemRow.Cells("Expiry_Date").Value, 1, -1)
                                    Exit While
                                End If
                                Batch = Batch & "#"
                                ItemRow.Cells("Batch").Value = Batch
                            End While





                            'Dim Batch As String = ItemRow.Cells("Batch").Value
                            'Dim ItemBatch = From IB In LMISDb.InventoryBatches Where IB.ID = Batch Select IB
                            'Dim Batc = (From IJDB In (New LMISEntities).InventoryJournalDetailsBatches Where IJDB.InventoryBatchID = Batch Select IJDB)

                            ''If ItemBatch.Count > 0 Then 'IF Batch already in database
                            'If ItemBatch.Count > 0 Then 'IF Batch already in database

                            '    If Batc.Count > 0 Then
                            '        If Batc.First.InventoryJournalDetail.ItemID = ItemID And Batc.First.Price = ItemRow.Cells("Cost").Value Then

                            '        Else
                            '            ItemRow.Cells("Batch").Value = ItemRow.Cells("Batch").Value & "#"
                            '            Utility.Save_Batch(ItemRow.Cells("Batch").Value, ItemRow.Cells("Cost").Value, ItemRow.Cells("Expiry_Date").Value, 1, -1)

                            '        End If
                            '    End If
                            '    If Not ItemRow.Cells("Expiry_Date").ReadOnly Then ItemBatch.First.ExpireDate = Date.Parse(ItemRow.Cells("Expiry_Date").Value)
                            'Else
                            '    Utility.Save_Batch(ItemRow.Cells("Batch").Value, ItemRow.Cells("Cost").Value, ItemRow.Cells("Expiry_Date").Value, 1, -1)
                            'End If
                            Dim NewIJDetailsBatch As New InventoryJournalDetailsBatch With {
                                .InventoryBatchID = ItemRow.Cells("Batch").Value,
                                .Price = Val(ItemRow.Cells("Cost").Value),
                                .InventoryJournaDetaillID = NewIJDetail.ID,
                                .LocationID = CType(ItemRow.Cells("Batch_Location"), ComboCell).BatchLocationID}
                            LMISDb.InventoryJournalDetailsBatches.AddObject(NewIJDetailsBatch)
                            LMISDb.SaveChanges()
                        End If
                    End If
                Next
                Transaction.Complete()
                Return True
            End Using
        Catch ex As Exception
            MessageBox.Show("Error: In saving" & vbCrLf & ex.Message & Utility.InnerExecption(ex), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return False
    End Function

    Function ValidateDataForm() As Boolean
        ERP_Error.Clear()
        Dim No_Error As Boolean = True
        If CMBX_RequestID.SelectedIndex = -1 Or CMBX_RequestID.Text = String.Empty Then
            ERP_Error.SetError(CMBX_RequestID, "Please select appropriate 'Request ID' from the list")
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
                    If Not Row.IsNewRow And DGV_Items.RowHasError(Row) Then
                        OneRowNoError = True
                    End If
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
        TBX_Department.Text = ""
        DGV_Items.Rows.Clear()
    End Sub

    Sub CalcualteTotalCost()
        Dim Running_Quantity As Double = 0
        For Each ItemRow As DataGridViewRow In DGV_Items.Rows
            Running_Quantity += ItemRow.Cells("Cost").Value
        Next
        TBX_TotalCost.Text = Running_Quantity
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
        DGV_Items.initMe(TBX_TotalCost, IJFRM_Types.Receive)
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
                    FRM_GLBMain.TLSL_MainStatus.Text = "Supply NOT Saved"
                    MessageBox.Show("  Data NOT Saved    ", "Error in Saving", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
                Me.Cursor = Cursors.Default
            End If
        End If
    End Sub

    Private Sub BTN_Print_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTN_Print.Click
        FRM_GLBMain.TLSL_MainStatus.Text = "Ready"
        If ValidateDataForm() Then
            If MessageBox.Show("Are you sure you want to save this Supply Receive", "Are you sure?", System.Windows.Forms.MessageBoxButtons.YesNo) = System.Windows.Forms.DialogResult.Yes Then
                Me.Cursor = Cursors.WaitCursor
                If SaveData(1) Then
                    FRM_GLBMain.TLSL_MainStatus.Text = "Supply Receive Saved"
                    MessageBox.Show("Supply Receive Saved", "Data Saved", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Dim ReportParameter As New Dictionary(Of String, String())
                    ReportParameter.Add("ID", {ReceiveID})
                    FRM_Reporter.Show(ReportTypes.IJReceive, ReportParameter)
                    ClearForm()
                    LoadForm()
                Else
                    FRM_GLBMain.TLSL_MainStatus.Text = "Supply NOT Saved"
                    MessageBox.Show("  Data NOT Saved    ", "Error in Saving", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
                Me.Cursor = Cursors.Default
            End If
        End If
    End Sub

    Private Sub BTN_Post_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTN_Post.Click
        FRM_GLBMain.TLSL_MainStatus.Text = "Ready"
        If ValidateDataForm() Then
            If MessageBox.Show("Are you sure you want to Post this Supply Receive" & vbCrLf & vbCrLf & "You will not be able to edit it again!", "Are you sure?", System.Windows.Forms.MessageBoxButtons.YesNo) = System.Windows.Forms.DialogResult.Yes Then
                Me.Cursor = Cursors.WaitCursor
                If SaveData(2) Then
                    FRM_GLBMain.TLSL_MainStatus.Text = "Supply Receive Posted"
                    MessageBox.Show("Supply Receive Posted", "Data Posted", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Dim ReportParameter As New Dictionary(Of String, String())
                    ReportParameter.Add("ID", {ReceiveID})
                    FRM_Reporter.Show(ReportTypes.IJReceive, ReportParameter)
                    ClearForm()
                    LoadForm()
                Else
                    FRM_GLBMain.TLSL_MainStatus.Text = "Supply NOT Posted"
                    MessageBox.Show("  Data NOT Posted    ", "Error in Posting", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
                Me.Cursor = Cursors.Default
            End If
        End If
    End Sub

    Private Sub CMBX_IJRequestID_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBX_RequestID.SelectedIndexChanged
        Try
            If CMBX_RequestID.SelectedItem IsNot Nothing Then
                Dim LMISDb As New LMISEntities
                Dim Department = From R In LMISDb.Requests
                                Join D In LMISDb.Departments
                                On R.DepartmentID Equals D.ID
                                Where R.ID = CMBX_RequestID.Text
                                Select D.Name, R.InventoryJournal.VoucherDate
                If Not Department.Count = 0 Then
                    DTP_VoucherDate.MinDate = Department.First.VoucherDate
                    TBX_Department.Text = Department.First.Name
                Else
                    TBX_Department.Text = ""
                End If
                DGV_Items.PopulateItems(CMBX_RequestID.Text)
            Else
                ClearForm()
            End If
        Catch ex As Exception
            MessageBox.Show("Error:" & vbCrLf & ex.Message & Utility.InnerExecption(ex), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

#End Region

End Class