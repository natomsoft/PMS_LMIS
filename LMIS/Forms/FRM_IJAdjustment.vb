Imports System.Transactions
Public Class FRM_IJAdjustment

#Region "declarations"
    Private FRMMode As FRMModes = FRMModes.AddNew
    Public FRMAdjMode As FRMAdjModes = FRMAdjModes.Increase

    Public Overloads Sub Show(ByVal FRMMode As FRMModes, ByVal FRMAdjMode As FRMAdjModes)
        Me.FRMMode = FRMMode
        Me.FRMAdjMode = FRMAdjMode
        Me.Show()
    End Sub

    Public Sub New()
        InitializeComponent()
        Me.MdiParent = FRM_GLBMain
        DTP_VoucherDate.MaxDate = Date.Today
    End Sub

#End Region

#Region "Utilities"

    Public Overloads Sub Show(ByVal Mode As FRMModes)
        FRMMode = Mode
        Me.Show()
    End Sub

    Sub LoadForm()
        Try
            Dim LMISDb As New LMISEntities
            Dim InOrOut As String = ""
            Dim NewOrEdit As String = "New "
            If FRMMode.Equals(FRMModes.EditExisting) Then NewOrEdit = "Edit "
            Select Case FRMAdjMode
                Case FRMAdjModes.Increase
                    Me.Text = NewOrEdit & "Items Adjustment Plus"
                    LBL_Title.Text = NewOrEdit & "Adjustment Plus"
                    InOrOut = "In"
                Case FRMAdjModes.Decrease
                    Me.Text = NewOrEdit & "Items Adjustment Minus"
                    LBL_Title.Text = NewOrEdit & "Adjustment Minus"
                    InOrOut = "Out"
                Case FRMAdjModes.Discard
                    Me.Text = NewOrEdit & "Discarded Items"
                    LBL_Title.Text = NewOrEdit & "Discarded"
                    InOrOut = "Discard"
            End Select
            CMBX_AdjustmentType.DataSource = From AID In LMISDb.AdjustmentTypes
                           Where AID.Type = InOrOut And AID.Active = True
                           Select AID
            CMBX_AdjustmentType.ValueMember = "ID"
            CMBX_AdjustmentType.DisplayMember = "Description"
            CMBX_AdjustmentType.SelectedItem = Nothing
            If FRMMode.Equals(FRMModes.AddNew) Then
                CMBX_AdjustmentID.Enabled = False 'disallow editting                
                CMBX_AdjustmentID.Text = Utility.GenerateID(IDTypes.Adjustment)
            Else
                CMBX_AdjustmentID.DataSource = From A In LMISDb.Adjustments Where A.InventoryJournal.InventoryJournalStatu.Name = "Pending" And A.AdjustmentType.Type = InOrOut And A.InventoryJournal.DepartmentID = FRM_GLBMain.ApplicationConfig.ThisDepartment.ID Select A.ID
                CMBX_AdjustmentID.AutoCompleteSource = AutoCompleteSource.ListItems
                CMBX_AdjustmentID.SelectedItem = Nothing
            End If
            DGV_Items.Rows.Clear()            
        Catch ex As Exception
            MessageBox.Show("Error:" & vbCrLf & ex.Message & vbCrLf & Utility.InnerExecption(ex), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Function SaveData(ByVal SaveStatus As Int16) As Boolean
        If FRMMode.Equals(FRMModes.AddNew) Then
            Try
                Using Transaction As New TransactionScope(TransactionScopeOption.RequiresNew)
                    Dim LMISDb As New LMISEntities
                    Dim NewIJ As New InventoryJournal With {
                        .ID = Utility.GenerateID(IDTypes.IJ),
                        .DepartmentID = FRM_GLBMain.ApplicationConfig.ThisDepartment.ID,
                        .VoucherDate = DTP_VoucherDate.Value,
                        .TransactionDate = Date.Today,
                        .Remark = TBX_Remark.Text,
                        .EmployeeID = FRM_GLBMain.ApplicationConfig.Employee.ID,
                        .Void = False,
                        .InventoryJournalStatusID = SaveStatus} '1 for Processed
                    Select Case FRMAdjMode
                        Case FRMAdjModes.Increase
                            NewIJ.InventoryJournalTypeID = 7 'for request Adjustmen In
                        Case FRMAdjModes.Decrease
                            NewIJ.InventoryJournalTypeID = 8 'for request AdjustmentOut
                        Case FRMAdjModes.Discard
                            NewIJ.InventoryJournalTypeID = 23 'for request Discarded
                    End Select
                    LMISDb.InventoryJournals.AddObject(NewIJ)
                    LMISDb.SaveChanges()
                    Dim NewAdj As New Adjustment With {
                        .ID = CMBX_AdjustmentID.Text,
                        .InventoryJournalID = NewIJ.ID,
                        .AdjustmentTypeID = CMBX_AdjustmentType.SelectedValue}
                    LMISDb.Adjustments.AddObject(NewAdj)
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
                End Using
            Catch ex As Exception
                MessageBox.Show("Error:" & vbCrLf & ex.Message & vbCrLf & Utility.InnerExecption(ex), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        ElseIf FRMMode.Equals(FRMModes.EditExisting) Then
            Try
                Using Transaction As New TransactionScope(TransactionScopeOption.RequiresNew)
                    Dim LMISDb As New LMISEntities
                    Dim Adj_IJ = From R In LMISDb.Adjustments
                                        Join IJ In LMISDb.InventoryJournals
                                            On R.InventoryJournalID Equals IJ.ID
                                        Where (R.ID = CMBX_AdjustmentID.Text)
                                        Select IJ
                    LMISDb.SaveChanges()
                    Dim Rec = From R In LMISDb.Recieves
                                        Where R.ID = CMBX_AdjustmentID.Text
                                        Select R
                    Adj_IJ.First.Remark = TBX_Remark.Text
                    Adj_IJ.First.VoucherDate = DTP_VoucherDate.Value
                    Adj_IJ.First.InventoryJournalStatusID = SaveStatus
                    Dim IJID As String = Adj_IJ.First.ID
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
                            If Not ItemRow.IsNewRow Then
                                Dim NewIJDetail As New InventoryJournalDetail With {
                                    .ItemID = ItemRow.Cells("ItemID").Value,
                                    .Quantity = ItemRow.Cells("Qty").Value,
                                    .InventoryJournalID = Adj_IJ.First.ID,
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
                    End If
                    Transaction.Complete()
                    Return True
                End Using
            Catch ex As Exception
                MessageBox.Show("Error:" & vbCrLf & ex.Message & vbCrLf & Utility.InnerExecption(ex), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
        Return False
    End Function

    Sub Load_AdjustmentType(ByVal Type As String)
        Try
            CMBX_AdjustmentType.DataSource = From A In (New LMISEntities).AdjustmentTypes
                            Where A.Type = Type
                            Select A.Description
            CMBX_AdjustmentType.AutoCompleteSource = AutoCompleteSource.ListItems
        Catch ex As Exception
            MessageBox.Show("Error:" & vbCrLf & ex.Message & vbCrLf & Utility.InnerExecption(ex), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Function ValidateDataForm() As Boolean
        ERP_Error.Clear()
        Dim No_Error As Boolean = True
        If FRMMode = FRMModes.EditExisting And CMBX_AdjustmentID.SelectedItem Is Nothing Then
            ERP_Error.SetError(CMBX_AdjustmentID, "Select appropriate Adjustment ID")
            No_Error = False
        End If
        If CMBX_AdjustmentType.SelectedIndex = -1 Or CMBX_AdjustmentID.Text = String.Empty Then
            ERP_Error.SetError(CMBX_AdjustmentType, "Select Appropriate 'Adjustment Type'")
            No_Error = False
        End If
        If IsNothing(CMBX_AdjustmentType.SelectedItem) Or CMBX_AdjustmentType.Text = String.Empty Then
            ERP_Error.SetError(CMBX_AdjustmentType, "Select Appropriate 'Adjustment Type'")
            No_Error = False
        End If
        If DGV_Items.Rows.Count = 0 Then
            ERP_Error.SetError(DGV_Items, "At least one 'Item' should be adjusted")
            No_Error = False
        ElseIf Not DGV_Items.ValidateData() Then
            ERP_Error.SetError(DGV_Items, "Correct your errors in Items table")
            No_Error = False
        End If
        If ValidateDat() Then
            No_Error = False
        End If
        Return No_Error
    End Function

    Public Function ValidateDat() As Boolean
        For Each Row As DataGridViewRow In DGV_Items.Rows
            If Not Row.IsNewRow Then
                If (CMBX_AdjustmentType.SelectedValue = 4) Then
                    With Row

                        ' If Not .Cells("Expiry_Date").ReadOnly Then

                        If .Cells("Expiry_Date").Value > Today Then
                            MsgBox("The Item hasn't expired yet!")
                            Return True
                        End If
                        'End If

                    End With
                End If

            End If
        Next
        Return False
    End Function

    Sub ClearForm()
        DTP_VoucherDate.Value = Date.Today
        CMBX_AdjustmentID.SelectedItem = Nothing
        TBX_Remark.Text = ""
        CMBX_AdjustmentType.SelectedItem = Nothing
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
        DGV_Items.initMe(TBX_TotalCost, IJFRM_Types.Adjustment)
        LoadForm()
    End Sub

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
            If MessageBox.Show("Are you sure you want to Post this Adjustment." & vbCrLf & vbCrLf & "You will not be able to edit it again!", "Are you sure?", System.Windows.Forms.MessageBoxButtons.YesNo) = System.Windows.Forms.DialogResult.Yes Then
                If SaveData(2) Then
                    FRM_GLBMain.TLSL_MainStatus.Text = "Adjustment Posted"
                    MessageBox.Show("Adjustment Posted", "Data Saved", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Dim ReportParameter As New Dictionary(Of String, String())
                    ReportParameter.Add("ID", {CMBX_AdjustmentID.Text})
                    FRM_Reporter.Show(ReportTypes.IJAdjustment, ReportParameter)
                    ClearForm()
                    LoadForm()
                Else
                    FRM_GLBMain.TLSL_MainStatus.Text = "Adjustment Not Posted"
                    MessageBox.Show("  Adjustmen NOT Posted    ", "Error in Saving", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            End If
            Me.Cursor = Cursors.Default
        End If
    End Sub

    Private Sub BTN_Print_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTN_Print.Click
        FRM_GLBMain.TLSL_MainStatus.Text = "Ready"
        If ValidateDataForm() Then
            Me.Cursor = Cursors.WaitCursor
            If MessageBox.Show("Are you sure you want to save this Adjustment", "Are you sure?", System.Windows.Forms.MessageBoxButtons.YesNo) = System.Windows.Forms.DialogResult.Yes Then
                If SaveData(1) Then
                    FRM_GLBMain.TLSL_MainStatus.Text = "Adjustment Saved"
                    MessageBox.Show("Adjustment Saved", "Data Saved", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Dim ReportParameter As New Dictionary(Of String, String())
                    ReportParameter.Add("ID", {CMBX_AdjustmentID.Text})
                    FRM_Reporter.Show(ReportTypes.IJAdjustment, ReportParameter)
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

    Private Sub CMBX_RequestID_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBX_AdjustmentID.SelectedIndexChanged
        Try
            If CMBX_AdjustmentID.SelectedItem IsNot Nothing Then
                Dim LMISDb As New LMISEntities
                Dim Adj_IJ = From R In LMISDb.Adjustments
                                Join IJ In LMISDb.InventoryJournals
                                    On R.InventoryJournalID Equals IJ.ID
                                Where R.ID = CMBX_AdjustmentID.Text
                                Select IJ.VoucherDate, IJ.Remark, R.AdjustmentTypeID
                DTP_VoucherDate.Value = Adj_IJ.First.VoucherDate
                CMBX_AdjustmentType.SelectedValue = Adj_IJ.First.AdjustmentTypeID
                TBX_Remark.Text = Adj_IJ.First.Remark
                DGV_Items.PopulateItems(CMBX_AdjustmentID.Text)                
            End If
        Catch ex As Exception
            MessageBox.Show("Error: In loading Adjustment" & vbCrLf & ex.Message & vbCrLf & Utility.InnerExecption(ex), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

#End Region

End Class

