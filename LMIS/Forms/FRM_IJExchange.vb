Imports System.Data.Objects
Imports System.Transactions
Public Class FRM_IJExchange

    Private FRMMode As FRMModes = FRMModes.AddNew

    Public Sub New()
        InitializeComponent()
        Me.MdiParent = FRM_GLBMain
        DTP_VoucherDate.MaxDate = Date.Today
    End Sub

    Public Overloads Sub Show(ByVal Mode As FRMModes)
        FRMMode = Mode
        If FRMMode.Equals(FRMModes.AddNew) Then
            Me.Text = "Add new exchange"
            LBL_Title.Text = "Add new exchange"
            CMBX_AdjustmentID.Enabled = False
        Else
            Me.Text = "Edit existing exchange"
            LBL_Title.Text = "Edit Existing Facility Request"
        End If
        Me.Show()
    End Sub

#Region "Utilities"

    Private Sub LoadForm()
        Try
            Dim LMISDb As New LMISEntities
            Dim ItemsM = From E In LMISDb.InventoryItems Order By E.Name Select E
            CMBX_MStockCode.DataSource = ItemsM
            CMBX_MStockCode.DisplayMember = "ID"
            CMBX_MStockCode.ValueMember = "ID"
            CMBX_MStockCode.SelectedItem = Nothing

            CMBX_MStockItem.DataSource = ItemsM
            CMBX_MStockItem.DisplayMember = "Name"
            CMBX_MStockItem.ValueMember = "ID"
            CMBX_MStockItem.SelectedItem = Nothing

            Dim ItemsX = From E In LMISDb.InventoryItems Order By E.Name Select E
            CMBX_XStockCode.DataSource = ItemsM
            CMBX_XStockCode.DisplayMember = "ID"
            CMBX_XStockCode.ValueMember = "ID"
            CMBX_XStockCode.SelectedItem = Nothing

            CMBX_XStockItem.DataSource = ItemsM
            CMBX_XStockItem.DisplayMember = "Name"
            CMBX_XStockItem.ValueMember = "ID"
            CMBX_XStockItem.SelectedItem = Nothing

            CMBX_XBatchLoc.DataSource = Utility.Get_ItemBatchLocations()
            CMBX_XBatchLoc.DisplayMember = "Data"
            CMBX_XBatchLoc.ValueMember = "ID"
            CMBX_XBatchLoc.SelectedItem = Nothing

            Dim MyDepartment = FRM_GLBMain.ApplicationConfig.ThisDepartment
            With CMBX_Department
                .DataSource = From F In LMISDb.Departments
                              Where F.Active = False
                              Select F Order By F.DepartmentTypeID
                .DisplayMember = "Name"
                .ValueMember = "ID"
                .AutoCompleteSource = AutoCompleteSource.ListItems
                .SelectedItem = Nothing
            End With

            If FRMMode = FRMModes.EditExisting Then
                CMBX_AdjustmentID.DataSource = From E In LMISDb.Adjustments Where E.AdjustmentTypeID = 13 And E.InventoryJournal.InventoryJournalStatu.Name = "Pending" Select E.ID
                CMBX_AdjustmentID.SelectedItem = Nothing
            ElseIf FRMMode.Equals(FRMModes.AddNew) Then
                CMBX_AdjustmentID.Text = Utility.GenerateID(IDTypes.Adjustment)
            End If
        Catch ex As Exception
            MessageBox.Show("Error:" & vbCrLf & ex.Message & Utility.InnerExecption(ex), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Function ValidateDataForm() As Boolean
        ERP_Error.Clear()
        Dim No_Error As Boolean = True
        If FRMMode = FRMModes.EditExisting And CMBX_AdjustmentID.SelectedItem Is Nothing Then
            ERP_Error.SetError(CMBX_AdjustmentID, "Select an appropriate Adjustment number")
            No_Error = False
        End If
        If CMBX_Department.SelectedItem Is Nothing Then
            ERP_Error.SetError(CMBX_Department, "Select an appropriate Facility Exchange")
            No_Error = False
        End If
        If CMBX_MStockCode.SelectedItem Is Nothing Then
            ERP_Error.SetError(CMBX_MStockCode, "Select an appropriate Stock Item")
            No_Error = False
        End If
        If CMBX_XStockCode.SelectedItem Is Nothing Then
            ERP_Error.SetError(CMBX_XStockCode, "Select an appropriate Stock Item")
            No_Error = False
        End If
        If CMBX_MBatch.SelectedItem Is Nothing Then
            ERP_Error.SetError(CMBX_MBatch, "Select an appropriate Batch")
            No_Error = False
        End If
        If CMBX_XBatch.SelectedItem Is Nothing And CMBX_XBatch.Text = String.Empty Then
            ERP_Error.SetError(CMBX_XBatch, "Select or type an appropriate Batch")
            No_Error = False
        End If
        If CMBX_MBatchLoc.SelectedItem Is Nothing Then
            ERP_Error.SetError(CMBX_MBatchLoc, "Select an appropriate Batch Location")
            No_Error = False
        End If
        If DTP_ExpiryDate.Value <= Date.Today Then
            ERP_Error.SetError(DTP_ExpiryDate, "New Batch should not be expired")
            No_Error = False
        End If
        If CMBX_XBatchLoc.SelectedItem Is Nothing Then
            ERP_Error.SetError(CMBX_XBatchLoc, "Select an appropriate Batch Location")
            No_Error = False
        End If
        If Not IsNumeric(TBX_MUCost.Text) Then
            ERP_Error.SetError(TBX_MUCost, "Please insert an appropriate number")
            No_Error = False
        ElseIf CDbl(TBX_MUCost.Text) <= 0 Then
            ERP_Error.SetError(TBX_MUCost, " Please insert an appropriate number")
            No_Error = False
        End If
        If Not IsNumeric(TBX_XUCost.Text) Then
            ERP_Error.SetError(TBX_XUCost, "Please insert an appropriate number")
            No_Error = False
        ElseIf CDbl(TBX_XUCost.Text) <= 0 Then
            ERP_Error.SetError(TBX_XUCost, "Please insert an appropriate number")
            No_Error = False
        End If
        If Not IsNumeric(TBX_XQty.Text) Then
            ERP_Error.SetError(TBX_XQty, "Please insert an appropriate number")
            No_Error = False
        ElseIf CDbl(TBX_XQty.Text) = 0 Then
            ERP_Error.SetError(TBX_XQty, "Please insert an appropriate number")
            No_Error = False
        End If

        If Not IsNumeric(TBX_MQty.Text) Or Not IsNumeric(TBX_AvailableQty.Text) Then
            ERP_Error.SetError(TBX_MQty, "Please insert an appropriate number")
            No_Error = False
        ElseIf CDbl(TBX_MQty.Text) = 0 Then
            ERP_Error.SetError(TBX_MQty, "Please insert an appropriate number")
            No_Error = False
        ElseIf CDbl(TBX_AvailableQty.Text) < CDbl(TBX_MQty.Text) Then
            ERP_Error.SetError(TBX_MQty, "Exchange Quantity should not be more than available quantity")
            No_Error = False
        End If
        Return No_Error
    End Function

    Function SaveData(ByVal SaveStatus As Int16) As Boolean
        ERP_Error.Clear()
        If FRMMode.Equals(FRMModes.AddNew) Then
            Try
                Using Transaction As New TransactionScope(TransactionScopeOption.RequiresNew)
                    Dim LMISDb As New LMISEntities
                    ''''''''''''Out                    
                    Dim NewIJOut As New InventoryJournal With {
                        .ID = Utility.GenerateID(IDTypes.IJ),
                        .DepartmentID = FRM_GLBMain.ApplicationConfig.ThisDepartment.ID,
                        .VoucherDate = DTP_VoucherDate.Value,
                        .TransactionDate = Date.Today,
                        .Remark = TBX_Remark.Text,
                        .EmployeeID = FRM_GLBMain.ApplicationConfig.Employee.ID,
                        .Void = False,
                        .InventoryJournalStatusID = SaveStatus,
                        .InventoryJournalTypeID = 8}
                    LMISDb.InventoryJournals.AddObject(NewIJOut)
                    LMISDb.SaveChanges()
                    CMBX_AdjustmentID.Text = Utility.GenerateID(IDTypes.Adjustment)
                    Dim NewAdjOut As New Adjustment With {.ID = CMBX_AdjustmentID.Text, .InventoryJournalID = NewIJOut.ID, .AdjustmentTypeID = 13}
                    LMISDb.Adjustments.AddObject(NewAdjOut)
                    LMISDb.SaveChanges()
                    LMISDb.AdjustmentExchanges.AddObject(New AdjustmentExchange With {.AdjustmentID = NewAdjOut.ID, .DepartmentID = CMBX_Department.SelectedValue})
                    LMISDb.SaveChanges()
                    Dim NewIJDetailOut As New InventoryJournalDetail With {.ItemID = CMBX_MStockCode.SelectedValue, .Quantity = CDbl(TBX_MQty.Text), .InventoryJournalID = NewIJOut.ID, .Remark = ""}
                    LMISDb.InventoryJournalDetails.AddObject(NewIJDetailOut)
                    LMISDb.SaveChanges()
                    LMISDb.InventoryJournalDetailsBatches.AddObject(New InventoryJournalDetailsBatch With {.Price = CDbl(TBX_MUCost.Text), .InventoryBatchID = CMBX_MBatch.SelectedValue, .LocationID = CMBX_MBatchLoc.SelectedValue, .InventoryJournaDetaillID = NewIJDetailOut.ID})
                    LMISDb.SaveChanges()
                    ''''''''''''In

                    Dim NewIJIn As New InventoryJournal With {
                        .ID = Utility.GenerateID(IDTypes.IJ),
                        .DepartmentID = FRM_GLBMain.ApplicationConfig.ThisDepartment.ID,
                        .VoucherDate = DTP_VoucherDate.Value,
                        .TransactionDate = Date.Today,
                        .Remark = TBX_Remark.Text,
                        .EmployeeID = FRM_GLBMain.ApplicationConfig.Employee.ID,
                        .Void = False,
                        .InventoryJournalStatusID = SaveStatus,
                        .InventoryJournalTypeID = 7}
                    LMISDb.InventoryJournals.AddObject(NewIJIn)
                    LMISDb.SaveChanges()
                    Dim NewAdjIn As New Adjustment With {.ID = Utility.GenerateID(IDTypes.Adjustment), .InventoryJournalID = NewIJIn.ID, .AdjustmentTypeID = 12}
                    LMISDb.Adjustments.AddObject(NewAdjIn)
                    LMISDb.SaveChanges()
                    Dim NewIJDetailIn As New InventoryJournalDetail With {.ItemID = CMBX_XStockCode.Text, .Quantity = CDbl(TBX_XQty.Text), .InventoryJournalID = NewIJIn.ID, .Remark = ""}
                    LMISDb.InventoryJournalDetails.AddObject(NewIJDetailIn)
                    LMISDb.SaveChanges()
                    If CMBX_XBatch.SelectedItem Is Nothing Then
                        Dim BatchID As String = CMBX_XBatch.Text
                        Dim BatchExists = From B In LMISDb.InventoryBatches Where B.ID = BatchID Select B

                        If BatchExists.Count > 0 Then
                            ERP_Error.SetError(CMBX_XBatch, "Batch already exists for another item")
                            MsgBox("Batch '" & CMBX_XBatch.Text & "' already exists for another item")
                            Return False
                        End If
                        Utility.Save_Batch(CMBX_XBatch.Text, TBX_XUCost.Text, DTP_ExpiryDate.Value, 1, -1)
                        LMISDb.SaveChanges()
                    End If                    
                    LMISDb.InventoryJournalDetailsBatches.AddObject(New InventoryJournalDetailsBatch With {.Price = CDbl(TBX_XUCost.Text), .InventoryBatchID = CMBX_XBatch.Text, .LocationID = CMBX_XBatchLoc.SelectedValue, .InventoryJournaDetaillID = NewIJDetailIn.ID})
                    LMISDb.SaveChanges()
                    Transaction.Complete()
                    Return True
                End Using
            Catch ex As Exception
                MessageBox.Show("Error:" & vbCrLf & ex.Message & vbCrLf & Utility.InnerExecption(ex), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        ElseIf FRMMode.Equals(FRMModes.EditExisting) Then
            Try
                Using Transaction As New TransactionScope(TransactionScopeOption.RequiresNew)
                    Dim LMISDb As New LMISEntities
                    Dim IJIDOut As String = CMBX_AdjustmentID.SelectedValue
                    Dim IJIDIn As String = CDbl(CMBX_AdjustmentID.SelectedValue) + 1
                    Dim Adj_IJOut = (From R In LMISDb.Adjustments Join IJ In LMISDb.InventoryJournals On R.InventoryJournalID Equals IJ.ID Where (R.ID = IJIDOut) Select IJ).Single
                    Dim Adj_IJIn = (From R In LMISDb.Adjustments Join IJ In LMISDb.InventoryJournals On R.InventoryJournalID Equals IJ.ID Where (R.ID = IJIDIn) Select IJ).Single
                    Dim Adj_Exch_Dep = (From R In LMISDb.Adjustments
                                         Join IJ In LMISDb.InventoryJournals On R.InventoryJournalID Equals IJ.ID
                                         Join Ex_Dep In LMISDb.AdjustmentExchanges On R.ID Equals Ex_Dep.AdjustmentID
                                         Where (R.ID = IJIDOut) Select Ex_Dep).Single
                    Adj_Exch_Dep.DepartmentID = CMBX_Department.SelectedValue
                    Adj_IJOut.Remark = TBX_Remark.Text
                    Adj_IJOut.VoucherDate = DTP_VoucherDate.Value
                    Adj_IJOut.InventoryJournalStatusID = SaveStatus
                    Adj_IJIn.Remark = TBX_Remark.Text
                    Adj_IJIn.VoucherDate = DTP_VoucherDate.Value
                    Adj_IJIn.InventoryJournalStatusID = SaveStatus

                    LMISDb.SaveChanges()
                    Dim IJDDelete = From IJD In LMISDb.InventoryJournalDetails Where IJD.InventoryJournalID = Adj_IJOut.ID Or IJD.InventoryJournalID = Adj_IJIn.ID Select IJD
                    For Each IJDRow As InventoryJournalDetail In IJDDelete
                        Dim IJDDeleteID As String = IJDRow.ID
                        Dim IJDBDelete = From IJDB In LMISDb.InventoryJournalDetailsBatches Where IJDB.InventoryJournaDetaillID = IJDDeleteID Select IJDB
                        LMISDb.InventoryJournalDetailsBatches.DeleteObject(IJDBDelete.First)
                    Next
                    LMISDb.SaveChanges()
                    For Each IJDRow As InventoryJournalDetail In IJDDelete
                        LMISDb.InventoryJournalDetails.DeleteObject(IJDRow)
                    Next
                    LMISDb.SaveChanges()
                    'Out
                    Dim NewIJDetailOut As New InventoryJournalDetail With {.ItemID = CMBX_MStockCode.SelectedValue, .Quantity = CDbl(TBX_MQty.Text), .InventoryJournalID = Adj_IJOut.ID, .Remark = ""}
                    LMISDb.InventoryJournalDetails.AddObject(NewIJDetailOut)
                    LMISDb.SaveChanges()
                    Dim NewIJDBatchoUT As New InventoryJournalDetailsBatch With {.Price = CDbl(TBX_MUCost.Text), .InventoryBatchID = CMBX_MBatch.SelectedValue, .LocationID = CMBX_MBatchLoc.SelectedValue, .InventoryJournaDetaillID = NewIJDetailOut.ID}
                    LMISDb.InventoryJournalDetailsBatches.AddObject(NewIJDBatchoUT)
                    LMISDb.SaveChanges()

                    'In
                    Dim NewIJDetailIn As New InventoryJournalDetail With {.ItemID = CMBX_XStockCode.Text, .Quantity = CDbl(TBX_XQty.Text), .InventoryJournalID = Adj_IJIn.ID, .Remark = ""}
                    LMISDb.InventoryJournalDetails.AddObject(NewIJDetailIn)
                    LMISDb.SaveChanges()
                    If CMBX_XBatch.SelectedItem Is Nothing Then
                        Dim BatchID As String = CMBX_XBatch.Text
                        Dim BatchExists = From B In LMISDb.InventoryBatches Where B.ID = BatchID Select B

                        If BatchExists.Count > 0 Then
                            ERP_Error.SetError(CMBX_XBatch, "Batch already exists for another item")
                            MsgBox("Batch '" & CMBX_XBatch.Text & "' already exists for another item")
                            Return False
                        End If
                        Utility.Save_Batch(CMBX_XBatch.Text, TBX_XUCost.Text, DTP_ExpiryDate.Value, 1, -1)
                        LMISDb.SaveChanges()
                    End If
                    LMISDb.InventoryJournalDetailsBatches.AddObject(New InventoryJournalDetailsBatch With {.Price = CDbl(TBX_XUCost.Text), .InventoryBatchID = CMBX_XBatch.Text, .LocationID = CMBX_XBatchLoc.SelectedValue, .InventoryJournaDetaillID = NewIJDetailIn.ID})                    
                    LMISDb.SaveChanges()
                    Transaction.Complete()
                    Return True
                End Using
            Catch ex As Exception
                MessageBox.Show("Error:" & vbCrLf & ex.Message & vbCrLf & Utility.InnerExecption(ex), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
        Return False
    End Function

    Private Sub ClearForm()
        If FRMMode.Equals(FRMModes.AddNew) Then
            CMBX_AdjustmentID.Text = Utility.GenerateID(IDTypes.Adjustment)
        End If
        CMBX_Department.SelectedItem = Nothing
        TBX_Remark.Text = String.Empty
        CMBX_MStockCode.SelectedItem = Nothing
        CMBX_XStockCode.SelectedItem = Nothing
        CMBX_MStockItem.SelectedItem = Nothing
        CMBX_XStockItem.SelectedItem = Nothing
        CMBX_MBatch.SelectedItem = Nothing
        CMBX_XBatch.SelectedItem = Nothing
        CMBX_MBatchLoc.SelectedItem = Nothing
        CMBX_XBatchLoc.SelectedItem = Nothing
        TBX_AvailableQty.Text = String.Empty
        TBX_MQty.Text = String.Empty
        TBX_XQty.Text = String.Empty
        TBX_MTCost.Text = String.Empty
        TBX_XTCost.Text = String.Empty
        TBX_MUCost.Text = String.Empty
        TBX_XUCost.Text = String.Empty
    End Sub

#End Region

#Region "Events"

    Private Sub BTN_Close_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTN_Close.Click
        Me.Close()
    End Sub

    Private Sub FRM_IJExchange_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadForm()
    End Sub
    Private Sub MStockCodeChanged()
        If CMBX_MStockCode.SelectedItem IsNot Nothing And CMBX_MStockCode.ValueMember <> String.Empty Then
            CMBX_MBatch.DataSource = Utility.Get_ItemBatches(CMBX_MStockCode.SelectedValue)
            CMBX_MBatch.ValueMember = "ID"
            CMBX_MBatch.DisplayMember = "ID"
            CMBX_MBatch.SelectedItem = Nothing
        Else
            CMBX_MBatch.DataSource = Nothing
        End If
    End Sub
    Private Sub CMBX_MStockCode_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBX_MStockCode.SelectedIndexChanged
        MStockCodeChanged()
    End Sub
    Private Sub XStockCodeChanged()
        If CMBX_XStockCode.SelectedItem IsNot Nothing And CMBX_XStockCode.ValueMember <> String.Empty Then
            CMBX_XBatch.DataSource = Utility.Get_ItemBatchesEvenZero(CMBX_XStockCode.SelectedValue)
            CMBX_XBatch.ValueMember = "ID"
            CMBX_XBatch.DisplayMember = "ID"
            CMBX_XBatch.SelectedItem = Nothing
        Else
            CMBX_XBatch.DataSource = Nothing
        End If
    End Sub
    Private Sub CMBX_XStockCode_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBX_XStockCode.SelectedIndexChanged
        XStockCodeChanged()
    End Sub

    Private Sub CMBX_MBatch_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBX_MBatch.SelectedIndexChanged
        If CMBX_MBatch.SelectedItem IsNot Nothing And CMBX_MBatch.ValueMember <> String.Empty Then
            CMBX_MBatchLoc.DataSource = Utility.Get_BatchLocations(CMBX_MBatch.SelectedValue)
            TBX_MUCost.Text = Utility.Get_BatchSalesCost(CMBX_MBatch.SelectedValue)
            CMBX_MBatchLoc.ValueMember = "ID"
            CMBX_MBatchLoc.DisplayMember = "Data"
        Else
            CMBX_MBatchLoc.DataSource = Nothing
        End If
    End Sub

    Private Sub CalculateTM()
        If IsNumeric(TBX_MUCost.Text) And IsNumeric(TBX_MQty.Text) Then
            TBX_MTCost.Text = CDbl(TBX_MUCost.Text) * CDbl(TBX_MQty.Text)
            TBX_XQty.Text = TBX_MQty.Text
            TBX_XTCost.Text = TBX_MTCost.Text
            TBX_XUCost.Text = TBX_MUCost.Text
        Else
            TBX_MTCost.Text = ""
        End If
    End Sub

    Private Sub CalculateTX()
        If IsNumeric(TBX_XUCost.Text) And IsNumeric(TBX_XQty.Text) Then
            TBX_XTCost.Text = CDbl(TBX_XUCost.Text) * CDbl(TBX_XQty.Text)
            TBX_MUCost.Text = TBX_MTCost.Text
        Else
            TBX_XTCost.Text = ""
        End If
    End Sub

    Private Sub CMBX_MBatchLoc_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBX_MBatchLoc.SelectedIndexChanged
        If CMBX_MBatchLoc.SelectedItem IsNot Nothing And CMBX_MBatchLoc.ValueMember <> String.Empty Then
            TBX_AvailableQty.Text = Utility.Get_ItemQtyInBatchLocation(CMBX_MBatch.SelectedValue, CMBX_MBatchLoc.SelectedValue)
        Else
            TBX_AvailableQty.Text = String.Empty
        End If
    End Sub

    Private Sub TBX_MQty_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TBX_MQty.TextChanged, TBX_MUCost.TextChanged
        CalculateTM()
    End Sub

    'Private Sub TBX_XQty_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TBX_XQty.TextChanged, TBX_XUCost.TextChanged
    '    CalculateTX()
    'End Sub

    Private Sub BTN_Save_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTN_Save.Click
        FRM_GLBMain.TLSL_MainStatus.Text = "Ready"
        If ValidateDataForm() Then
            Me.Cursor = Cursors.WaitCursor
            If MessageBox.Show("Are you sure you want to Save and Print this Adjustment", "Are you sure?", System.Windows.Forms.MessageBoxButtons.YesNo) = System.Windows.Forms.DialogResult.Yes Then
                If SaveData(1) Then
                    FRM_GLBMain.TLSL_MainStatus.Text = "Adjustment Saved"
                    MessageBox.Show("Adjustment Saved", "Data Saved", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    ClearForm()
                    LoadForm()
                Else
                    FRM_GLBMain.TLSL_MainStatus.Text = "Adjustment Not Saved"
                    MessageBox.Show("  Adjustmen NOT Saved    ", "Error in Saving", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            End If
            Me.Cursor = Cursors.Default
        End If
    End Sub

    Private Sub BTN_Post_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTN_Post.Click
        FRM_GLBMain.TLSL_MainStatus.Text = "Ready"
        If ValidateDataForm() Then
            Me.Cursor = Cursors.WaitCursor
            If MessageBox.Show("Are you sure you want to Post this Adjustment?" & vbCrLf & vbCrLf & "You will not be able to edit it again", "Are you sure?", System.Windows.Forms.MessageBoxButtons.YesNo) = System.Windows.Forms.DialogResult.Yes Then
                If SaveData(2) Then
                    FRM_GLBMain.TLSL_MainStatus.Text = "Adjustment Posted"
                    MessageBox.Show("Adjustment Saved", "Data Saved", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Dim ReportParameter As New Dictionary(Of String, String())
                    ReportParameter.Add("@ExchangeID", {CMBX_AdjustmentID.Text})
                    ReportParameter.Add("Title", {FRM_GLBMain.ApplicationConfig.ThisDepartment.Name})
                    ReportParameter.Add("CustomTitle", {"Exchanged Items"})
                    FRM_Reporter.Show(ReportTypes.IJExchange, ReportParameter)

                    ClearForm()
                    LoadForm()
                Else
                    FRM_GLBMain.TLSL_MainStatus.Text = "Adjustment Not Posted"
                    MessageBox.Show("  Adjustmen NOT Posted    ", "Error in Posting", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            End If
            Me.Cursor = Cursors.Default
        End If
    End Sub

    Private Sub BTN_Pring_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTN_Print.Click
        FRM_GLBMain.TLSL_MainStatus.Text = "Ready"
        If ValidateDataForm() Then
            Me.Cursor = Cursors.WaitCursor
            If MessageBox.Show("Are you sure you want to Save and Print this Adjustment", "Are you sure?", System.Windows.Forms.MessageBoxButtons.YesNo) = System.Windows.Forms.DialogResult.Yes Then
                If SaveData(1) Then
                    FRM_GLBMain.TLSL_MainStatus.Text = "Adjustment Saved"
                    MessageBox.Show("Adjustment Saved", "Data Saved", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Dim ReportParameter As New Dictionary(Of String, String())
                    ReportParameter.Add("@ExchangeID", {CMBX_AdjustmentID.Text})
                    ReportParameter.Add("Title", {FRM_GLBMain.ApplicationConfig.ThisDepartment.Name})
                    ReportParameter.Add("CustomTitle", {"Adjustment Exchange"})
                    FRM_Reporter.Show(ReportTypes.IJExchange, ReportParameter)

                    ClearForm()
                    LoadForm()
                Else
                    FRM_GLBMain.TLSL_MainStatus.Text = "Adjustment Not Saved"
                    MessageBox.Show("  Adjustmen NOT Saved    ", "Error in Saving", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            End If
            Me.Cursor = Cursors.Default
        End If
    End Sub

    Private Sub CMBX_AdjustmentID_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBX_AdjustmentID.SelectedIndexChanged
        If CMBX_AdjustmentID.SelectedItem IsNot Nothing Then
            Dim LMISDb As New LMISEntities
            Dim IJIDOut As String = CMBX_AdjustmentID.SelectedValue
            Dim IJIDIn As String = CDbl(CMBX_AdjustmentID.SelectedValue + 1)
            Dim AdjustedItemsOut = From R In LMISDb.Adjustments
                          Join IJ In LMISDb.InventoryJournals
                              On R.InventoryJournalID Equals IJ.ID
                          Join IJD In LMISDb.InventoryJournalDetails
                              On IJD.InventoryJournalID Equals IJ.ID
                          Join IJT In LMISDb.InventoryJournalStatus
                              On IJ.InventoryJournalStatusID Equals IJT.ID
                          Join IJDB In LMISDb.InventoryJournalDetailsBatches
                              On IJD.ID Equals IJDB.InventoryJournaDetaillID
                          Join IJB In LMISDb.InventoryBatches
                              On IJB.ID Equals IJDB.InventoryBatchID
                           Join II In LMISDb.InventoryItems
                              On II.ID Equals IJD.ItemID
                           Join AD In LMISDb.AdjustmentExchanges
                            On R.ID Equals AD.AdjustmentID
                          Where R.ID = IJIDOut
                          Select II.ID, II.Name, IJ.Remark, IJ.VoucherDate, IJD.Quantity, BatchNo = IJB.ID, IJDB.Price, IJDID = IJD.ID, IJB.ExpireDate, IJDB.LocationID, Unit = II.Unit.Name, AD.DepartmentID
                          Order By ID
            If AdjustedItemsOut.Count > 0 Then
                CMBX_MStockItem.SelectedValue = AdjustedItemsOut.First.ID
                CMBX_XStockItem.SelectedValue = AdjustedItemsOut.First.ID
                CMBX_MStockCode.SelectedItem = AdjustedItemsOut.First.ID
                CMBX_XStockCode.SelectedItem = AdjustedItemsOut.First.ID
                CMBX_MBatch.SelectedValue = AdjustedItemsOut.First.BatchNo
                CMBX_XBatch.SelectedValue = AdjustedItemsOut.First.BatchNo
                CMBX_MBatchLoc.SelectedValue = AdjustedItemsOut.First.LocationID
                TBX_MQty.Text = AdjustedItemsOut.First.Quantity
                TBX_MUCost.Text = AdjustedItemsOut.First.Price
                TBX_MTCost.Text = AdjustedItemsOut.First.Price * AdjustedItemsOut.First.Quantity
                TBX_Remark.Text = AdjustedItemsOut.First.Remark
                DTP_VoucherDate.Value = AdjustedItemsOut.First.VoucherDate
                CMBX_Department.SelectedValue = AdjustedItemsOut.First.DepartmentID
            End If

            Dim AdjustedItemsIn = From R In LMISDb.Adjustments
                          Join IJ In LMISDb.InventoryJournals
                              On R.InventoryJournalID Equals IJ.ID
                          Join IJD In LMISDb.InventoryJournalDetails
                              On IJD.InventoryJournalID Equals IJ.ID
                          Join IJT In LMISDb.InventoryJournalStatus
                              On IJ.InventoryJournalStatusID Equals IJT.ID
                          Join IJDB In LMISDb.InventoryJournalDetailsBatches
                              On IJD.ID Equals IJDB.InventoryJournaDetaillID
                          Join IJB In LMISDb.InventoryBatches
                              On IJB.ID Equals IJDB.InventoryBatchID
                           Join II In LMISDb.InventoryItems
                              On II.ID Equals IJD.ItemID
                          Where R.ID = IJIDIn
                          Select II.ID, II.Name, IJD.Quantity, BatchNo = IJB.ID, IJDB.Price, IJDID = IJD.ID, IJB.ExpireDate, IJDB.LocationID, Unit = II.Unit.Name
                          Order By ID

            If AdjustedItemsIn.Count > 0 Then                
                CMBX_XStockItem.SelectedValue = AdjustedItemsIn.First.ID
                XStockCodeChanged()
                CMBX_XBatch.SelectedValue = AdjustedItemsIn.First.BatchNo
                CMBX_XBatchLoc.SelectedValue = AdjustedItemsIn.First.LocationID
                TBX_XQty.Text = AdjustedItemsIn.First.Quantity
                TBX_XUCost.Text = AdjustedItemsIn.First.Price
                TBX_XTCost.Text = AdjustedItemsIn.First.Price * AdjustedItemsOut.First.Quantity
            End If
        Else
            ClearForm()
        End If
    End Sub

    Private Sub CMBX_XBatch_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBX_XBatch.TextChanged
        If CMBX_XBatch.SelectedItem Is Nothing Then
            DTP_ExpiryDate.Enabled = True
        Else
            DTP_ExpiryDate.Enabled = False
            DTP_ExpiryDate.Value = CType(CMBX_XBatch.SelectedItem, InventoryBatch).ExpireDate
        End If
    End Sub

#End Region

End Class