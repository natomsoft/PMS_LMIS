Imports System.Data.Objects
Imports System.Transactions
Public Class FRM_IJPreinvoice

#Region "declarations"
    Public Sub New()
        InitializeComponent()
        Me.MdiParent = FRM_GLBMain
        DTP_VoucherDate.MaxDate = Date.Today
        If FRM_GLBMain.ApplicationConfig.ThisDepartment.DepartmentType.Description = "Level 1" Then
            TBX_IssueID.Enabled = True
        Else            
            TBX_IssueID.Enabled = False
        End If
    End Sub

#End Region

#Region "Utilities"

    Sub LoadForm()
        Try
            Dim LMISDb As New LMISEntities
            CMBX_RequisitionID.DataSource = (From Req In LMISDb.Requisitions
                              Join IJ In LMISDb.InventoryJournals
                                  On Req.InventoryJournalID Equals IJ.ID
                              Where (IJ.Void = False And IJ.DepartmentID = FRM_GLBMain.ApplicationConfig.ThisDepartment.ID)
                              Select Req.ID).Except(
                          From Iss In LMISDb.Issues
                              Join Req In LMISDb.Requisitions
                                  On Iss.RequisitionID Equals Req.ID
                              Join IJRec In LMISDb.InventoryJournals
                                  On Iss.InventoryJournalID Equals IJRec.ID
                              Join IJReq In LMISDb.InventoryJournals
                                  On Req.InventoryJournalID Equals IJReq.ID
                              Where (IJRec.Void = False And IJReq.Void = False And IJReq.DepartmentID = FRM_GLBMain.ApplicationConfig.ThisDepartment.ID And IJRec.DepartmentID = FRM_GLBMain.ApplicationConfig.ThisDepartment.ID)
                              Select Req.ID)
            CMBX_RequisitionID.AutoCompleteSource = AutoCompleteSource.ListItems
            CMBX_RequisitionID.SelectedItem = Nothing
        Catch ex As Exception
            MessageBox.Show("Error:" & vbCrLf & ex.Message & Utility.InnerExecption(ex), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
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
                Dim NewIJ As New InventoryJournal With {
                    .ID = Utility.GenerateID(IDTypes.IJ),
                    .DepartmentID = FRM_GLBMain.ApplicationConfig.ThisDepartment.ID,
                    .VoucherDate = DTP_VoucherDate.Value,
                    .TransactionDate = Date.Today,
                    .Remark = TBX_Remark.Text,
                    .InventoryJournalTypeID = 15,
                    .EmployeeID = FRM_GLBMain.ApplicationConfig.Employee.ID,
                    .Void = False,
                    .InventoryJournalStatusID = SaveStatus}
                Dim Requ_IJ As ObjectQuery(Of InventoryJournal) = From IJ In LMISDb.InventoryJournals
                                                                    Join R In LMISDb.Requisitions
                                                                  On R.InventoryJournalID Equals IJ.ID
                                                                  Where R.ID = CMBX_RequisitionID.Text
                                                                  Select IJ
                Requ_IJ.First.InventoryJournalStatusID = 1 '1 for pending or pre-invoice
                LMISDb.InventoryJournals.AddObject(NewIJ)
                If LMISDb.SaveChanges() > 0 Then
                    While (True)
                        Try
                            Dim NewIssue As New Issue With {
                                .ID = Utility.GenerateID(IDTypes.Issue),
                                .RequisitionID = CMBX_RequisitionID.Text,
                                .InventoryJournalID = NewIJ.ID}
                            LMISDb.Issues.AddObject(NewIssue)
                            LMISDb.SaveChanges()
                            Exit While
                        Catch ex As Exception

                        End Try
                    End While





                    For Each ItemRow As DataGridViewRow In DGV_Items.Rows
                        If Not ItemRow.IsNewRow Then
                            Dim NewIJDetail As New InventoryJournalDetail With {
                                .ItemID = ItemRow.Cells("ItemID").Value,
                                .Quantity = ItemRow.Cells("Qty").Value,
                                .InventoryJournalID = NewIJ.ID,
                                .Remark = ItemRow.Cells("Remark").Value}
                            LMISDb.InventoryJournalDetails.AddObject(NewIJDetail)
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

                End If
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
        If CMBX_RequisitionID.SelectedIndex = -1 Or CMBX_RequisitionID.Text = String.Empty Then
            ERP_Error.SetError(CMBX_RequisitionID, "Please select appropriate 'Request ID' from the list")
            No_Error = False
        Else
            Dim LMISDb As New LMISEntities
            'Dim RequestingFacility = (From R In LMISDb.Requisitions Join D In LMISDb.Departments On R.DepartmentID Equals D.ID Where (R.ID = CMBX_RequisitionID.Text) Select D).Single
            '    For Each Row As DataGridViewRow In DGV_Items.Rows
            '        If Not Row.IsNewRow Then
            '            Dim ItemID As String = Row.Cells("ItemID").Value
            '            Dim Item = (From I In (New LMISEntities).InventoryItems Where I.ID = ItemID Select I.ItemsCatalogue).Single
            '            If Item.LevelOfUseID < RequestingFacility.LevelofUseID Then
            '                If MessageBox.Show("Item '" & Row.Cells("ItemID").Value & "' or '" & Row.Cells("Item_Name").Value & "' has Levelof use of '" & Item.LevelOfUseID & "', but the facility " & RequestingFacility.Name & " has Level of use '" & RequestingFacility.LevelofUseID & "'" & vbCrLf & vbCrLf & "Are you sure you want dispense the Item to the facility?", "Are you sure?", System.Windows.Forms.MessageBoxButtons.YesNo) = System.Windows.Forms.DialogResult.No Then
            '                DGV_Items.Rows.Remove(Row)

            '                End If
            '            End If
            '        End If
            'Next
        End If
        If TBX_IssueID.Text = String.Empty Then
            ERP_Error.SetError(TBX_IssueID, "Invoice number should not be empty")
            No_Error = False
        ElseIf (From I In (New LMISEntities).Issues Where I.ID = TBX_IssueID.Text Select I).Count > 0 Then
            ERP_Error.SetError(TBX_IssueID, "There already is an invoice with ID '" & TBX_IssueID.Text & "', please type in another invoice number")
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
        If Not FRM_GLBMain.ApplicationConfig.ThisDepartment.DepartmentType.Description = "Level 1" Then TBX_IssueID.Text = Utility.GenerateID(IDTypes.Issue)
        DTP_VoucherDate.Value = Date.Today
        TBX_Remark.Text = ""
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
        DGV_Items.initMe(TBX_TotalCost, IJFRM_Types.Issue)
        LoadForm()
    End Sub

    Private Sub BTN_Print_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTN_Print.Click
        FRM_GLBMain.TLSL_MainStatus.Text = "Ready"
        If ValidateDataForm() Then
            If MessageBox.Show("Are you sure you want to Save and Print this Pre-invoice", "Are you sure?", System.Windows.Forms.MessageBoxButtons.YesNo) = System.Windows.Forms.DialogResult.Yes Then
                Me.Cursor = Cursors.WaitCursor
                If SaveData(1) Then
                    FRM_GLBMain.TLSL_MainStatus.Text = "Pre-invoice Saved"
                    MessageBox.Show("Pre-invoice Saved", "Data Saved", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Dim ReportParameter As New Dictionary(Of String, String())
                    ReportParameter.Add("ID", {TBX_IssueID.Text})
                    FRM_Reporter.Show(ReportTypes.IJPreinvoice, ReportParameter)
                    ClearForm()
                    LoadForm()
                Else
                    FRM_GLBMain.TLSL_MainStatus.Text = "Pre-invoice Saved"
                    MessageBox.Show("   Pre-invoice Saved    ", "Error in Saving", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
                Me.Cursor = Cursors.Default
            End If
        End If
    End Sub

    Private Sub BTN_Save_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTN_Save.Click
        FRM_GLBMain.TLSL_MainStatus.Text = "Ready"
        If ValidateDataForm() Then
            If MessageBox.Show("Are you sure you want to save this Pre-invoice", "Are you sure?", System.Windows.Forms.MessageBoxButtons.YesNo) = System.Windows.Forms.DialogResult.Yes Then
                Me.Cursor = Cursors.WaitCursor
                If SaveData(1) Then
                    FRM_GLBMain.TLSL_MainStatus.Text = "Pre-invoice Saved"
                    MessageBox.Show("Pre-invoice Saved", "Data Saved", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    ClearForm()
                    LoadForm()
                Else
                    FRM_GLBMain.TLSL_MainStatus.Text = "Pre-invoice Saved"
                    MessageBox.Show("   Pre-invoice Saved    ", "Error in Saving", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
                Me.Cursor = Cursors.Default
            End If
        End If
    End Sub

    Private Sub CMBX_IJRequestID_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBX_RequisitionID.SelectedIndexChanged
        Try
            If CMBX_RequisitionID.SelectedItem IsNot Nothing Then
                Dim LMISDb As New LMISEntities
                Dim ReqData = From R In LMISDb.Requisitions
                                Join D In LMISDb.Departments
                                    On R.DepartmentID Equals D.ID
                                Where R.ID = CMBX_RequisitionID.Text
                                Select DepartmentName = D.Name, R.InventoryJournal.Remark, R.InventoryJournal.VoucherDate
                TBX_Department.Text = ""
                If ReqData.Count = 0 Then Throw New Exception("Application can not find Department")
                TBX_Department.Text = ReqData.First.DepartmentName
                TBX_Remark.Text = ReqData.First.Remark
                DGV_Items.PopulateItems(CMBX_RequisitionID.Text)
                DTP_VoucherDate.MinDate = ReqData.First.VoucherDate
            Else
                ClearForm()
            End If
        Catch ex As Exception
            MessageBox.Show("Error:" & vbCrLf & ex.Message & Utility.InnerExecption(ex), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

#End Region

End Class