Imports System.Transactions

Public Class StoreTransferVoucher
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
            CMBX_XBatchLoc.DataSource = Utility.Get_ItemBatchLocations()
            CMBX_XBatchLoc.DisplayMember = "Data"
            CMBX_XBatchLoc.ValueMember = "ID"
            CMBX_XBatchLoc.SelectedItem = Nothing

            Dim MyDepartment = FRM_GLBMain.ApplicationConfig.ThisDepartment
            If FRMMode.Equals(FRMModes.AddNew) Then
                CMBX_AdjustmentID.Enabled = False 'disallow editting
                CMBX_AdjustmentID.Text = Utility.GenerateID(IDTypes.Transfers)
                Me.Text = "Add new STV"
            Else
                CMBX_AdjustmentID.DataSource = From A In LMISDb.Transfers Where A.InventoryJournal.InventoryJournalStatu.Name = "Pending" Select A.ID
                CMBX_AdjustmentID.AutoCompleteSource = AutoCompleteSource.ListItems
                CMBX_AdjustmentID.SelectedItem = Nothing
                Me.Text = "Edit existing STV"
            End If
            CMBX_AdjustmentID.SelectedItem = Nothing

        
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
        If CMBX_MStockCode.SelectedItem Is Nothing Then
            ERP_Error.SetError(CMBX_MStockCode, "Select an appropriate Stock Item")
            No_Error = False
        End If
        If CMBX_MBatch.SelectedItem Is Nothing Then
            ERP_Error.SetError(CMBX_MBatch, "Select an appropriate Batch")
            No_Error = False
        End If
        If CMBX_MBatchLoc.SelectedItem Is Nothing Then
            ERP_Error.SetError(CMBX_MBatchLoc, "Select an appropriate Batch Location")
            No_Error = False
        End If
        If CMBX_XBatchLoc.SelectedItem Is Nothing Then
            ERP_Error.SetError(CMBX_XBatchLoc, "Select an appropriate Batch Location")
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
                '   Using Transaction As New TransactionScope(TransactionScopeOption.RequiresNew)
                Dim LMISDb As New LMISEntities
                ''''''''''''Out           


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
                CMBX_AdjustmentID.Text = Utility.GenerateID(IDTypes.Transfers)


                Dim NewOutIJ As New InventoryJournal With {
.ID = Utility.GenerateID(IDTypes.IJ),
.DepartmentID = FRM_GLBMain.ApplicationConfig.ThisDepartment.ID,
.VoucherDate = DTP_VoucherDate.Value,
.TransactionDate = Date.Today,
.Remark = TBX_Remark.Text,
.EmployeeID = FRM_GLBMain.ApplicationConfig.Employee.ID,
.Void = False,
.InventoryJournalTypeID = 22,
.InventoryJournalStatusID = SaveStatus}
                LMISDb.InventoryJournals.AddObject(NewOutIJ)
                LMISDb.SaveChanges()

                Dim transfers As New Transfer
                With transfers
                    .ID = Utility.GenerateID(IDTypes.Transfers)
                    .Remark = TBX_Remark.Text
                    .InventoryJournalInID = NewInIJ.ID
                    .InventoryJournalOutID = NewOutIJ.ID
                End With
                LMISDb.Transfers.AddObject(transfers)
                LMISDb.SaveChanges()

                For Each r As DataGridViewRow In DGV_Items.Rows
                    Dim LMIDB As New LMISEntities
                    Dim transDetail As New TransferDetail
                    transDetail.TransaferID = transfers.ID
                    LMIDB.TransferDetails.AddObject(transDetail)
                    LMIDB.SaveChanges()

                    Dim LMISDBB As New LMISEntities
                    Dim NewIJDetailOut As New InventoryJournalDetail With {.ItemID = r.Cells(0).Value, .Quantity = CDbl(r.Cells(9).Value), .InventoryJournalID = NewOutIJ.ID, .Remark = ""}
                    LMISDBB.InventoryJournalDetails.AddObject(NewIJDetailOut)
                    LMISDBB.SaveChanges()
                    LMISDb.InventoryJournalDetailsBatches.AddObject(New InventoryJournalDetailsBatch With {.Price = CDbl(r.Cells(11).Value), .InventoryBatchID = r.Cells(2).Value, .LocationID = CDbl(r.Cells(4).Value), .InventoryJournaDetaillID = NewIJDetailOut.ID})

                    Dim LMDB As New LMISEntities
                    Dim transDetailout As New TransferDetailOut
                    transDetailout.TransferDetailID = transDetail.ID
                    transDetailout.InventoryJournalDetailID = NewIJDetailOut.ID
                    LMDB.TransferDetailOuts.AddObject(transDetailout)
                    LMDB.SaveChanges()


                    Dim LMISD As New LMISEntities
                    Dim NewIJDetailIn As New InventoryJournalDetail With {.ItemID = r.Cells(0).Value, .Quantity = CDbl(r.Cells(9).Value), .InventoryJournalID = NewInIJ.ID, .Remark = ""}
                    LMISD.InventoryJournalDetails.AddObject(NewIJDetailIn)
                    LMISD.SaveChanges()
                    LMISDb.InventoryJournalDetailsBatches.AddObject(New InventoryJournalDetailsBatch With {.Price = CDbl(r.Cells(11).Value), .InventoryBatchID = r.Cells(2).Value, .LocationID = CDbl(r.Cells(6).Value), .InventoryJournaDetaillID = NewIJDetailIn.ID})


                    Dim LDB As New LMISEntities
                    Dim transDetailin As New TransferDetailIN
                    transDetailin.TransferDetailID = transDetail.ID
                    transDetailin.InventoryJournalDetailID = NewIJDetailIn.ID
                    LDB.TransferDetailINs.AddObject(transDetailin)
                    LDB.SaveChanges()
                Next
                LMISDb.SaveChanges()





                'Transaction.Complete()
                Return True
                '  End Using
            Catch ex As Exception
                MessageBox.Show("Error:" & vbCrLf & ex.Message & vbCrLf & Utility.InnerExecption(ex), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        ElseIf FRMMode.Equals(FRMModes.EditExisting) Then
            Try

                Try
                    '   Using Transaction As New TransactionScope(TransactionScopeOption.RequiresNew)
                    Dim LMISDb As New LMISEntities
                    ''''''''''''Out           

                    Dim NewInIJ As InventoryJournal = (From x In LMISDb.InventoryJournals Where x.ID = invenJourIDIN Select x).Single
                    With NewInIJ

                        .DepartmentID = FRM_GLBMain.ApplicationConfig.ThisDepartment.ID
                        .VoucherDate = DTP_VoucherDate.Value
                        .TransactionDate = Date.Today
                        .Remark = TBX_Remark.Text
                        .EmployeeID = FRM_GLBMain.ApplicationConfig.Employee.ID
                        .Void = False
                        .InventoryJournalTypeID = 21
                        .InventoryJournalStatusID = SaveStatus
                    End With

                    LMISDb.SaveChanges()

                   
                    Dim NewOutIJ As InventoryJournal = (From x In LMISDb.InventoryJournals Where x.ID = invenJOurnIDOUT Select x).Single

                    With NewOutIJ
                        .DepartmentID = FRM_GLBMain.ApplicationConfig.ThisDepartment.ID
                        .VoucherDate = DTP_VoucherDate.Value
                        .TransactionDate = Date.Today
                        .Remark = TBX_Remark.Text
                        .EmployeeID = FRM_GLBMain.ApplicationConfig.Employee.ID
                        .Void = False
                        .InventoryJournalTypeID = 22
                        .InventoryJournalStatusID = SaveStatus
                    End With
                    LMISDb.SaveChanges()

                   

                    For Each r As DataGridViewRow In DGV_Items.Rows

                        Dim LMISDBB As New LMISEntities
                        Dim invJourID As Integer = CInt(r.Cells(12).Value)
                        Dim invJourIDOut As Integer = CInt(r.Cells(13).Value)
                        Dim qtty As Double = CDbl(r.Cells(9).Value)
                        Dim fromLocation As String = r.Cells(4).Value
                        Dim toLocation As String = r.Cells(6).Value
                        Dim NewIJDetailOut As InventoryJournalDetail = (From x In LMISDBB.InventoryJournalDetails Where x.ID = invJourID Select x).Single
                        With NewIJDetailOut
                            .Quantity = qtty
                        End With
                       
                        Dim invjourdetailBatch As InventoryJournalDetailsBatch = (From x In LMISDBB.InventoryJournalDetailsBatches Where x.InventoryJournaDetaillID = invJourID Select x).Single
                        With invjourdetailBatch
                            .LocationID = toLocation
                        End With

                        Dim NewIJDetailOutIN As InventoryJournalDetail = (From x In LMISDBB.InventoryJournalDetails Where x.ID = invJourIDOut Select x).Single
                        With NewIJDetailOutIN
                            .Quantity = qtty
                        End With

                        Dim invjourdetailBatchIN As InventoryJournalDetailsBatch = (From x In LMISDBB.InventoryJournalDetailsBatches Where x.InventoryJournaDetaillID = invJourIDOut Select x).Single
                        With invjourdetailBatch
                            .LocationID = fromLocation
                        End With
                        
                        LMISDBB.SaveChanges()
                    Next






                    'Transaction.Complete()
                    Return True
                    '  End Using
                Catch ex As Exception
                    MessageBox.Show("Error:" & vbCrLf & ex.Message & vbCrLf & Utility.InnerExecption(ex), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
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

        CMBX_MStockCode.SelectedItem = Nothing
        CMBX_MStockItem.SelectedItem = Nothing
        CMBX_MBatch.SelectedItem = Nothing
        CMBX_MBatchLoc.SelectedItem = Nothing
        CMBX_XBatchLoc.SelectedItem = Nothing
        TBX_AvailableQty.Text = String.Empty
        TBX_MQty.Text = String.Empty

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

    Private Sub CMBX_MBatch_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBX_MBatch.SelectedIndexChanged
        If CMBX_MBatch.SelectedItem IsNot Nothing And CMBX_MBatch.ValueMember <> String.Empty Then
            CMBX_MBatchLoc.DataSource = Utility.Get_BatchLocations(CMBX_MBatch.SelectedValue)
            CMBX_MBatchLoc.ValueMember = "ID"
            CMBX_MBatchLoc.DisplayMember = "Data"
        Else
            CMBX_MBatchLoc.DataSource = Nothing
        End If
    End Sub

    Private Sub CMBX_MBatchLoc_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBX_MBatchLoc.SelectedIndexChanged
        If CMBX_MBatchLoc.SelectedItem IsNot Nothing And CMBX_MBatchLoc.ValueMember <> String.Empty Then
            TBX_AvailableQty.Text = Utility.Get_ItemQtyInBatchLocation(CMBX_MBatch.SelectedValue, CMBX_MBatchLoc.SelectedValue)
        Else
            TBX_AvailableQty.Text = String.Empty
        End If
    End Sub


    'Private Sub TBX_XQty_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TBX_XQty.TextChanged, TBX_XUCost.TextChanged
    '    CalculateTX()
    'End Sub

    Private Sub BTN_Save_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTN_Save.Click
        FRM_GLBMain.TLSL_MainStatus.Text = "Ready"
        If True Then
            Me.Cursor = Cursors.WaitCursor
            If MessageBox.Show("Are you sure you want to Save and Print this STV", "Are you sure?", System.Windows.Forms.MessageBoxButtons.YesNo) = System.Windows.Forms.DialogResult.Yes Then
                If SaveData(1) Then
                    TBX_Remark.Text = String.Empty
                    FRM_GLBMain.TLSL_MainStatus.Text = "STV Saved"
                    MessageBox.Show("STV Saved", "Data Saved", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    ClearForm()
                    DGV_Items.Rows.Clear()
                    LoadForm()
                Else
                    FRM_GLBMain.TLSL_MainStatus.Text = "STV Not Saved"
                    MessageBox.Show("  STV NOT Saved    ", "Error in Saving", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            End If
            Me.Cursor = Cursors.Default
        End If
    End Sub

    Private Sub BTN_Post_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
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

    Private Sub BTN_Pring_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
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

    Dim transferID As String = ""
    Dim invenJourIDIN As String = ""
    Dim invenJOurnIDOUT As String = ""
    Private Sub CMBX_AdjustmentID_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBX_AdjustmentID.SelectedIndexChanged
        Try
            Using context As New LMISEntities
                Dim rs = From x In context.TransfersViews Where x.ID = CMBX_AdjustmentID.Text Select x

                DGV_Items.Rows.Clear()
                For Each r In rs
                    transferID = r.ID
                    invenJourIDIN = r.InventoryJournalInID
                    invenJOurnIDOUT = r.InventoryJournalOutID
                    DTP_VoucherDate.Value = r.Date
                    TBX_Remark.Text = r.Remark
                    Dim rowindex As Integer = DGV_Items.Rows.Add
                    With DGV_Items.Rows(rowindex)
                        .Cells(0).Value = r.Item_ID
                        .Cells(1).Value = r.Item_Name
                        .Cells(2).Value = r.Batch_No
                        .Cells(3).Value = r.Batch_No
                        .Cells(4).Value = r.FromLocationID
                        .Cells(5).Value = r.FromLocation
                        .Cells(6).Value = r.ToLocationID
                        .Cells(7).Value = r.ToLocation
                        .Cells(8).Value = 0
                        .Cells(9).Value = r.Quantity
                        .Cells(11).Value = 0

                        .Cells(12).Value = r.IJDetout
                        .Cells(13).Value = r.IJDetIn
                        .Cells(14).Value = r.transDetailID
                    End With
                Next
            End Using
            'If CMBX_AdjustmentID.SelectedItem IsNot Nothing Then
            '    Dim LMISDb As New LMISEntities
            '    Dim Transfer_IJ = From R In LMISDb.Transfers
            '                    Join IJ In LMISDb.InventoryJournals
            '                        On R.InventoryJournalInID Equals IJ.ID
            '                    Join LF In LMISDb.Locations
            '                        On R.FromLocation Equals LF.ID
            '                    Join LT In LMISDb.Locations
            '                        On R.ToLocation Equals LT.ID
            '                    Where R.ID = CMBX_TransferID.Text
            '                    Select IJ.VoucherDate, IJ.Remark, FromLocID = LF.ID, ToLocID = LT.ID
            '    If Transfer_IJ.Count > 0 Then
            '        
            '        CMBX_FromLocation.SelectedValue = Transfer_IJ.First.FromLocID
            '        CMBX_ToLocation.SelectedValue = Transfer_IJ.First.ToLocID
            '        TBX_Remark.Text = Transfer_IJ.First.Remark
            '    End If
            '    DGV_Items.PopulateItems(CMBX_TransferID.Text)
            'Else
            '    ClearForm()
            'End If
        Catch ex As Exception
            MessageBox.Show("Error: In loading Requisitions" & vbCrLf & ex.Message & Utility.InnerExecption(ex), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub



#End Region

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        Try
            Dim rowindex As Integer = DGV_Items.Rows.Add
            With DGV_Items.Rows(rowindex)
                .Cells(0).Value = CMBX_MStockItem.SelectedValue
                .Cells(1).Value = CMBX_MStockItem.Text
                .Cells(2).Value = CMBX_MBatch.SelectedValue
                .Cells(3).Value = CMBX_MBatch.Text
                .Cells(4).Value = CMBX_MBatchLoc.SelectedValue
                .Cells(5).Value = CMBX_MBatchLoc.Text
                .Cells(6).Value = CMBX_XBatchLoc.SelectedValue
                .Cells(7).Value = CMBX_XBatchLoc.Text
                .Cells(8).Value = TBX_AvailableQty.Text
                .Cells(9).Value = TBX_MQty.Text
                .Cells(11).Value = CMBX_MBatch.SelectedItem.CostPrice
            End With
        Catch ex As Exception

        End Try
        clearForm()
    End Sub

 
    Private Sub BTN_Post_Click_1(sender As System.Object, e As System.EventArgs) Handles BTN_Post.Click
        FRM_GLBMain.TLSL_MainStatus.Text = "Ready"
        If True Then
            If MessageBox.Show("Are you sure you want to save this Transfer", "Are you sure?", System.Windows.Forms.MessageBoxButtons.YesNo) = System.Windows.Forms.DialogResult.Yes Then
                Me.Cursor = Cursors.WaitCursor
                If SaveData(2) Then
                    FRM_GLBMain.TLSL_MainStatus.Text = "STV Saved"
                    MessageBox.Show("STV Saved", "Data Saved", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Dim ReportParameter As New Dictionary(Of String, String())
                    ReportParameter.Add("ID", {CMBX_AdjustmentID.Text})
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

    Private Sub BTN_Print_Click(sender As System.Object, e As System.EventArgs) Handles BTN_Print.Click
        FRM_GLBMain.TLSL_MainStatus.Text = "Ready"
        If True Then
            If MessageBox.Show("Are you sure you want to save this Transfer", "Are you sure?", System.Windows.Forms.MessageBoxButtons.YesNo) = System.Windows.Forms.DialogResult.Yes Then
                Me.Cursor = Cursors.WaitCursor
                If SaveData(1) Then
                    FRM_GLBMain.TLSL_MainStatus.Text = "STV Saved"
                    MessageBox.Show("STV Saved", "Data Saved", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Dim ReportParameter As New Dictionary(Of String, String())
                    ReportParameter.Add("ID", {CMBX_AdjustmentID.Text})
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

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        Dim context As New LMISEntities
        For Each dr As DataGridViewRow In DGV_Items.SelectedRows

            Try
                Dim detID As Integer = dr.Cells(14).Value
                Dim tranDet As TransferDetail = (From x In context.TransferDetails Where x.ID = detID Select x).Single
                context.TransferDetails.DeleteObject(tranDet)
                context.SaveChanges()
            Catch ex As Exception

            End Try

        Next

        For Each dr As DataGridViewRow In DGV_Items.SelectedRows

    
            DGV_Items.Rows.RemoveAt(dr.Index)
        Next
    End Sub
End Class