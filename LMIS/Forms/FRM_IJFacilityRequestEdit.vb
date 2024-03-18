Imports System.Data.Objects
Imports System.Transactions

Public Class FRM_IJFacilityRequestEdit

#Region "declarations"
    Private FRMMode As FRMModes = FRMModes.AddNew

    Public Sub New()
        InitializeComponent()
        Me.MdiParent = FRM_GLBMain
        DTP_VoucherDate.MaxDate = Date.Today
    End Sub

    Public Overloads Sub Show(ByVal Mode As FRMModes)
        FRMMode = Mode
        If FRMMode.Equals(FRMModes.AddNew) Then
            Me.Text = "Facility Request"
            LBL_Title.Text = "Facility Request"
            CMBX_RequisitionID.Text = Utility.GenerateID(IDTypes.Requisition)
        Else
            Me.Text = "Edit Existing Facility Request"
            LBL_Title.Text = "Edit Existing Facility Request"
        End If
        Me.Show()
    End Sub

#End Region

#Region "Utilities"

    Sub LoadForm()
        Try
            Dim LMISDb As New LMISEntities
            Dim MyDepartment = FRM_GLBMain.ApplicationConfig.ThisDepartment
            If FRMMode.Equals(FRMModes.AddNew) Then CMBX_RequisitionID.Text = Utility.GenerateID(IDTypes.Requisition)
            With CMBX_Department
                .DataSource = From F In LMISDb.Departments
                              Where F.Active = False And
                              (
                                  (MyDepartment.DepartmentType.Description = "Level 3" And (((F.DepartmentType.Description = "Level 3" And F.Facility.MedicalStoreID = MyDepartment.Facility.MedicalStoreID) Or (F.DepartmentType.Description = "Level 4I" And MyDepartment.FacilityID = F.FacilityID) Or (F.DepartmentType.Description = "Level 4O" And MyDepartment.FacilityID = F.FacilityID) Or (F.DepartmentType.Description = "Level 4N" And MyDepartment.FacilityID = F.FacilityID)))) Or
                                  (MyDepartment.DepartmentType.Description = "Level 2" And ((F.DepartmentType.Description = "Level 2" Or MyDepartment.FacilityID = F.FacilityID))) Or
                                  (MyDepartment.DepartmentType.Description = "Level 1" And (F.DepartmentType.Description = "Level 2" Or F.DepartmentType.Description = "Level 5"))
                              ) Select F Order By F.DepartmentTypeID
                .DisplayMember = "Name"
                .ValueMember = "ID"
                .AutoCompleteSource = AutoCompleteSource.ListItems
                .SelectedItem = Nothing
            End With
            With CMBX_RequisitionID
                If FRMMode.Equals(FRMModes.AddNew) Then
                    .Enabled = False 'disallow editting                    A
                Else
                    .Enabled = True
                    .DataSource = (From Req In LMISDb.Requisitions
                                        Where (Req.InventoryJournal.Void = False And Req.InventoryJournal.InventoryJournalStatu.Name = "Pending" And Req.InventoryJournal.DepartmentID = MyDepartment.ID)
                                        Select Req.ID).Except(
                                    From Req In LMISDb.Requisitions
                                        Join Iss In LMISDb.Issues
                                            On Iss.RequisitionID Equals Req.ID
                                        Where (Iss.InventoryJournal.Void = False And Req.InventoryJournal.Void = False And Req.InventoryJournal.DepartmentID = MyDepartment.ID)
                                        Select Req.ID)
                    .AutoCompleteSource = AutoCompleteSource.ListItems
                    .SelectedItem = Nothing
                End If
            End With

        Catch ex As Exception
            MessageBox.Show("Error: In Loading Form" & vbCrLf & ex.Message & Utility.InnerExecption(ex), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Function SaveData(ByVal SaveStatus As Int16)
        Try
            Using Transaction As New TransactionScope(TransactionScopeOption.RequiresNew)
                Dim LMISDb As New LMISEntities
                Try
                    Select Case FRMMode
                        Case FRMModes.AddNew
                            Dim NewIJ = New InventoryJournal With {
                                .ID = Utility.GenerateID(IDTypes.IJ),
                                .DepartmentID = FRM_GLBMain.ApplicationConfig.ThisDepartment.ID,
                                .VoucherDate = DTP_VoucherDate.Value,
                                .TransactionDate = Date.Today,
                                .Remark = TBX_Remark.Text,
                                .InventoryJournalTypeID = 14,
                                .EmployeeID = FRM_GLBMain.ApplicationConfig.Employee.ID,
                                .Void = False,
                                .InventoryJournalStatusID = SaveStatus}
                            LMISDb.InventoryJournals.AddObject(NewIJ)
                            LMISDb.SaveChanges()
                            For Each ItemRow As DataGridViewRow In DGV_Items.Rows
                                If Not ItemRow.IsNewRow And DGV_Items.RowHasError(ItemRow) Then
                                    Dim IJD As New InventoryJournalDetail With {
                                        .ItemID = ItemRow.Cells("ItemID").Value,
                                        .Quantity = ItemRow.Cells("Qty").Value,
                                        .InventoryJournalID = NewIJ.ID,
                                        .Remark = ItemRow.Cells("Remark").Value}
                                    LMISDb.InventoryJournalDetails.AddObject(IJD)
                                    LMISDb.SaveChanges()
                                    'If Not (ItemRow.Cells("Stock_Out_Days").Value = Nothing And ItemRow.Cells("Qty_StockInhand").Value = Nothing And ItemRow.Cells("Qty_Consumed").Value = Nothing) Then                                   
                                    LMISDb.ConsumedItems.AddObject(New ConsumedItem With {
                                        .InventoryJournalDetailID = IJD.ID,
                                        .StockOutDays = ItemRow.Cells("Stock_Out_Days").Value,
                                        .StockOnHand = ItemRow.Cells("Qty_StockInhand").Value,
                                        .Consumption = ItemRow.Cells("Qty_Consumed").Value,
                                        .Price = CDbl(ItemRow.Cells("Cost").Value)})
                                    LMISDb.SaveChanges()
                                    'End If
                                End If
                            Next
                            CMBX_RequisitionID.Text = Utility.GenerateID(IDTypes.Requisition)
                            Dim Requisition = New Requisition With {
                                .ID = CMBX_RequisitionID.Text,
                                .ReferenceID = TBX_ReferenceID.Text,
                                .InventoryJournalID = NewIJ.ID,
                                .DepartmentID = CType(CMBX_Department.SelectedItem, Department).ID,
                                .SupplyPeriodID = CMBX_Quarter.SelectedValue}
                            Dim NameID As ObjectQuery(Of PersonName)
                            NameID = From N In LMISDb.PersonNames Select N Where N.Name = TBX_FName.Text
                            Requisition.FirstNameID = Nothing
                            If NameID.Count <> 0 Then Requisition.FirstNameID = NameID.First.ID
                            NameID = From N In LMISDb.PersonNames Select N Where N.Name = TBX_MName.Text
                            Requisition.MiddleNameID = Nothing
                            If NameID.Count <> 0 Then Requisition.MiddleNameID = NameID.First.ID
                            NameID = From N In LMISDb.PersonNames Select N Where N.Name = TBX_LName.Text
                            Requisition.LastNameID = Nothing
                            If NameID.Count <> 0 Then Requisition.LastNameID = NameID.First.ID

                            LMISDb.Requisitions.AddObject(Requisition)
                            LMISDb.SaveChanges()
                            Transaction.Complete()
                            Return True
                        Case FRMModes.EditExisting
                            Dim Req_IJ = From R In LMISDb.Requisitions
                                            Join IJ In LMISDb.InventoryJournals
                                                On R.InventoryJournalID Equals IJ.ID
                                            Where R.ID = CMBX_RequisitionID.Text
                                            Select IJ

                            Req_IJ.First.VoucherDate = DTP_VoucherDate.Value
                            Req_IJ.First.Remark = TBX_Remark.Text
                            Req_IJ.First.InventoryJournalStatusID = SaveStatus
                            Dim Req = From R In LMISDb.Requisitions
                                            Where R.ID = CMBX_RequisitionID.Text
                                            Select R
                            Req.First.ReferenceID = TBX_ReferenceID.Text
                            Req.First.DepartmentID = CType(CMBX_Department.SelectedItem, Department).ID
                            Req.First.SupplyPeriodID = CMBX_Quarter.SelectedValue
                            Dim NameID As ObjectQuery(Of PersonName)
                            NameID = From N In LMISDb.PersonNames Select N Where N.Name = TBX_FName.Text
                            Req.First.FirstNameID = Nothing
                            If NameID.Count <> 0 Then Req.First.FirstNameID = NameID.First.ID
                            NameID = From N In LMISDb.PersonNames Select N Where N.Name = TBX_MName.Text
                            Req.First.MiddleNameID = Nothing
                            If NameID.Count <> 0 Then Req.First.MiddleNameID = NameID.First.ID
                            NameID = From N In LMISDb.PersonNames Select N Where N.Name = TBX_LName.Text
                            Req.First.LastNameID = Nothing
                            If NameID.Count <> 0 Then Req.First.LastNameID = NameID.First.ID
                            LMISDb.SaveChanges()
                            Dim IJID As String = Req_IJ.First.ID
                            Dim IJDDelete = From IJD In LMISDb.InventoryJournalDetails
                                            Where IJD.InventoryJournalID = IJID
                                            Select IJD
                            For Each IJDRow As InventoryJournalDetail In IJDDelete
                                Dim IJDDeleteID As Integer = IJDRow.ID
                                Dim ConItemsDelete = From Con In LMISDb.ConsumedItems
                                                    Where Con.InventoryJournalDetailID = IJDDeleteID
                                                    Select Con
                                If ConItemsDelete.Count > 0 Then LMISDb.ConsumedItems.DeleteObject(ConItemsDelete.First)
                            Next
                            LMISDb.SaveChanges()
                            For Each IJDRow As InventoryJournalDetail In IJDDelete
                                LMISDb.InventoryJournalDetails.DeleteObject(IJDRow)
                            Next
                            LMISDb.SaveChanges()

                            For Each ItemRow As DataGridViewRow In DGV_Items.Rows
                                If Not ItemRow.IsNewRow Then
                                    Dim IJD As New InventoryJournalDetail With {
                                        .ItemID = ItemRow.Cells("ItemID").Value,
                                        .Quantity = ItemRow.Cells("Qty").Value,
                                        .InventoryJournalID = Req_IJ.First.ID,
                                        .Remark = ItemRow.Cells("Remark").Value}
                                    LMISDb.InventoryJournalDetails.AddObject(IJD)
                                    LMISDb.SaveChanges()
                                    LMISDb.ConsumedItems.AddObject(New ConsumedItem With {
                                        .InventoryJournalDetailID = IJD.ID,
                                        .StockOutDays = ItemRow.Cells("Stock_Out_Days").Value,
                                        .StockOnHand = ItemRow.Cells("Qty_StockInhand").Value,
                                        .Consumption = ItemRow.Cells("Qty_Consumed").Value,
                                        .Price = CDbl(ItemRow.Cells("Cost").Value)
                                    }) '.Price = Get_ItemCost(ItemRow.Cells("ItemID").Value, CMBX_Department.SelectedValue)
                                    LMISDb.SaveChanges()
                                End If
                            Next
                            Transaction.Complete()
                            Return True
                    End Select
                Catch ex As Exception
                    MessageBox.Show("Error: In Saving Data" & vbCrLf & ex.Message & Utility.InnerExecption(ex), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Return False
                End Try
            End Using
        Catch ex As Exception
            MessageBox.Show("Error: In Saving Data" & vbCrLf & ex.Message & Utility.InnerExecption(ex), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try
        Return False
    End Function

    Public Function Get_ItemCost(ByVal ItemID As String, ByVal DepartmentID As String) As Double
        Try
            Dim LMISDb As New LMISEntities
            Dim LastCost = From IJDB In LMISDb.InventoryJournalDetailsBatches
                            Join Iss In LMISDb.Issues On Iss.InventoryJournalID Equals IJDB.InventoryJournalDetail.InventoryJournalID
                            Where IJDB.InventoryJournalDetail.ItemID = ItemID And IJDB.InventoryJournalDetail.InventoryJournal.DepartmentID = FRM_GLBMain.ApplicationConfig.ThisDepartment.ID And Iss.Requisition.DepartmentID = DepartmentID
                            Group By IJDB.InventoryJournalDetail.InventoryJournalID
                            Into SumOut = Sum(IJDB.Price), Count = Count()
            If LastCost.Count = 0 Then Return Utility.Get_ItemCost(ItemID)
            Return LastCost.ToArray.Last.SumOut / LastCost.ToArray.Last.Count  'average cost        
        Catch ex As Exception
            MessageBox.Show("Error: In Getting Cost", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return 0
        End Try
    End Function

    Function ValidateDataForm() As Boolean
        ERP_Error.Clear()
        Dim No_Error As Boolean = True
        Dim DeparmentSelected As Boolean = True
        If IsNothing(CMBX_Department.SelectedItem) Or CMBX_Department.Text = String.Empty Then
            ERP_Error.SetError(CMBX_Department, "Select Appropriate 'Supplier'")
            DeparmentSelected = False
            No_Error = False
        End If
        If DGV_Items.Rows.Count >= 1 And DeparmentSelected Then
            For Each Row As DataGridViewRow In DGV_Items.Rows
                If Not Row.IsNewRow Then
                    Dim ItemID As String = Row.Cells("ItemID").Value
                    Dim Item = (From I In (New LMISEntities).InventoryItems Where I.ID = ItemID Select I.ItemsCatalogue).Single
                    If Item.LevelOfUseID < CType(CMBX_Department.SelectedItem, Department).LevelofUseID Then
                        If MessageBox.Show("Item '" & Row.Cells("ItemID").Value & "' or '" & Row.Cells("Item_Name").Value & "' has Levelof use of '" & Item.LevelOfUseID & "', but the facility " & CType(CMBX_Department.SelectedItem, Department).Name & " has Level of use '" & CType(CMBX_Department.SelectedItem, Department).LevelofUseID & "'" & vbCrLf & vbCrLf & "Are you sure you want dispense the Item to the facility?", "Are you sure?", System.Windows.Forms.MessageBoxButtons.YesNo) = System.Windows.Forms.DialogResult.No Then
                            DGV_Items.Rows.Remove(Row)
                        End If
                    End If
                End If
            Next
        End If
        If FRMMode.Equals(FRMModes.EditExisting) And (IsNothing(CMBX_RequisitionID.SelectedItem) Or CMBX_RequisitionID.Text = String.Empty) Then
            ERP_Error.SetError(CMBX_RequisitionID, "Select Appropriate 'Requisition ID'")
            No_Error = False
        End If
        If CMBX_Quarter.SelectedItem Is Nothing Then
            ERP_Error.SetError(CMBX_Quarter, "'Period' Should not be empty")
            No_Error = False
        End If
        If CMBX_Department.SelectedItem Is Nothing Then
            ERP_Error.SetError(CMBX_Department, "'Facility' Should not be empty")
            No_Error = False
        End If
        If TBX_ReferenceID.Text = String.Empty Then
            ERP_Error.SetError(TBX_ReferenceID, "'Reference No' Should not be empty")
            No_Error = False
        End If
        If CMBX_Quarter.SelectedItem Is Nothing Then
            ERP_Error.SetError(CMBX_Quarter, "Select request period")
            No_Error = False
        End If
        If IsNothing(CMBX_Department.SelectedItem) Or CMBX_Department.Text = String.Empty Then
            ERP_Error.SetError(CMBX_Department, "Select Appropriate 'Supplier'")
            No_Error = False
        End If
        If TBX_FName.Text <> String.Empty Then
            If (From N In (New LMISEntities).PersonNames Where N.Name = TBX_FName.Text Select N).Count = 0 Then
                ERP_Error.SetError(TBX_FName, "Name is not present in database")
                No_Error = False
            End If
        End If
        If TBX_MName.Text <> String.Empty Then
            If (From N In (New LMISEntities).PersonNames Where N.Name = TBX_MName.Text Select N).Count = 0 Then
                ERP_Error.SetError(TBX_MName, "Name is not present in database")
                No_Error = False
            End If
        End If
        If TBX_LName.Text <> String.Empty Then
            If (From N In (New LMISEntities).PersonNames Where N.Name = TBX_LName.Text Select N).Count = 0 Then
                ERP_Error.SetError(TBX_LName, "Name is not present in database")
                No_Error = False
            End If
        End If
        If DGV_Items.Rows.Count = 1 Then
            ERP_Error.SetError(DGV_Items, "At least 'one Item' should be requested")
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
        TBX_ReferenceID.Text = ""
        CMBX_Department.SelectedItem = Nothing
        CMBX_Department.Text = ""
        TBX_FName.Text = ""
        TBX_MName.Text = ""
        TBX_LName.Text = ""
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

    Private Sub FRM_IJRequisitionEdit_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        AddHandler TBX_FName.TextChanged, AddressOf TBX_Name
        AddHandler TBX_MName.TextChanged, AddressOf TBX_Name
        AddHandler TBX_LName.TextChanged, AddressOf TBX_Name
        DGV_Items.initMe(TBX_TotalCost, IJFRM_Types.RequisitionEdit)
        If FRM_GLBMain.ApplicationConfig.ThisDepartment.DepartmentType.Description = "Level 1" Then
            Qty_StockInhand.Visible = False
            Qty_Consumed.Visible = False
            Stock_Out_Days.Visible = False
        End If
        LoadForm()
    End Sub

    Private Sub BTN_Save_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTN_Save.Click
        FRM_GLBMain.TLSL_MainStatus.Text = "Ready"
        If ValidateDataForm() Then
            If MessageBox.Show("Are you sure you want to save this Request", "Are you sure?", System.Windows.Forms.MessageBoxButtons.YesNo) = System.Windows.Forms.DialogResult.Yes Then
                Me.Cursor = Cursors.WaitCursor
                If SaveData(1) Then
                    FRM_GLBMain.TLSL_MainStatus.Text = "Facility Request Saved"
                    MessageBox.Show("Facility Request Saved", "Data Saved", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    ClearForm()
                    LoadForm()
                Else
                    FRM_GLBMain.TLSL_MainStatus.Text = "Facility Request NOT Saved"
                    MessageBox.Show("  Facility Request NOT Saved    ", "Error in Saving", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            End If
            Me.Cursor = Cursors.Default
        End If
    End Sub

    Private Sub CMBX_RequisitionID_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBX_RequisitionID.SelectedIndexChanged
        Try
            If CMBX_RequisitionID.SelectedItem IsNot Nothing Then
                Dim LMISDb As New LMISEntities
                Dim Req_IJ = From R In LMISDb.Requisitions
                                Join IJ In LMISDb.InventoryJournals
                                    On R.InventoryJournalID Equals IJ.ID
                                Join D In LMISDb.Departments
                                    On R.DepartmentID Equals D.ID
                                Where R.ID = CMBX_RequisitionID.Text
                                Select IJ.VoucherDate, IJ.Remark, DepartmentID = D.ID, R.ReferenceID, SupplyPeriodID = R.SupplyPeriod.ID, FName = R.PersonName.Name, MName = R.PersonName1.Name, LName = R.PersonName2.Name
                If Req_IJ.Count = 0 Then Throw New Exception("Error: In Changing Items" & vbCrLf & "Application could not find Requist")
                DTP_VoucherDate.Value = Req_IJ.First.VoucherDate
                TBX_ReferenceID.Text = Req_IJ.First.ReferenceID
                CMBX_Department.SelectedValue = Req_IJ.First.DepartmentID
                TBX_Remark.Text = Req_IJ.First.Remark
                CMBX_Quarter.SelectedValue = Req_IJ.First.SupplyPeriodID
                TBX_FName.Text = Req_IJ.First.FName
                TBX_MName.Text = Req_IJ.First.MName
                TBX_LName.Text = Req_IJ.First.LName
                DGV_Items.PopulateItems(CMBX_RequisitionID.Text)
            Else
                ClearForm()
            End If
        Catch ex As Exception
            MessageBox.Show("Error: In changing items" & vbCrLf & ex.Message & Utility.InnerExecption(ex), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub TBX_Name(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim TBX_N As TextBox = CType(sender, TextBox)
        If TBX_N.Text.Length = 1 Then
            Dim LMISDb As New LMISEntities
            Dim AutoCSource As New AutoCompleteStringCollection
            Dim Names = From d In (New LMISEntities).PersonNames Select d Where d.Name.StartsWith(TBX_N.Text)
            For Each SName In Names
                AutoCSource.Add(SName.Name)
            Next
            TBX_N.AutoCompleteCustomSource = AutoCSource
        End If
    End Sub

    Private Sub CHBX_Scheduled_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CHBX_Scheduled.CheckedChanged
        DGV_Items.Columns("Qty_StockInhand").Visible = CHBX_Scheduled.Checked
        DGV_Items.Columns("Qty_Consumed").Visible = CHBX_Scheduled.Checked
        DGV_Items.Columns("Stock_Out_Days").Visible = CHBX_Scheduled.Checked
    End Sub

    Private Sub CMBX_Department_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBX_Department.SelectedIndexChanged, CHBX_UseTemplate.CheckedChanged, CMBX_RequestDates.SelectedIndexChanged
        CMBX_RequestDates.Enabled = CHBX_UseTemplate.Checked
        If CMBX_Department.SelectedItem IsNot Nothing And CMBX_Department.ValueMember <> String.Empty Then
            Dim LMISDb As New LMISEntities
            Dim RID As Integer = CType(CMBX_Department.SelectedItem, Department).DepartmentType.RationDaysID
            CMBX_Quarter.DataSource = From C In LMISDb.SupplyPeriods Select C Where RID = C.RationDaysID
            CMBX_Quarter.DisplayMember = "Period"
            CMBX_Quarter.ValueMember = "ID"
            CMBX_Quarter.SelectedItem = Nothing
            If sender Is CMBX_Department Then
                Dim DepaID As String = CMBX_Department.SelectedValue
                CMBX_RequestDates.DataSource = From LR In (New LMISEntities).Requisitions
                              Where LR.DepartmentID = DepaID And LR.InventoryJournal.Department.Active = True
                              Order By LR.InventoryJournal.VoucherDate Descending Select LR.ID, LR.InventoryJournal.VoucherDate
                CMBX_RequestDates.ValueMember = "ID"
                CMBX_RequestDates.DisplayMember = "VoucherDate"
                CMBX_RequestDates.SelectedItem = Nothing
            ElseIf CMBX_Department.SelectedItem Is Nothing Then
                CMBX_RequestDates.DataSource = Nothing
            End If
            If CHBX_UseTemplate.Checked And CMBX_RequestDates.SelectedItem IsNot Nothing Then
                If CMBX_RequestDates.SelectedItem IsNot Nothing Then
                    DGV_Items.IJTransaction.clearRows = False
                    DGV_Items.PopulateItems(CMBX_RequestDates.SelectedValue)
                    DGV_Items.IJTransaction.clearRows = True
                End If
            End If
        End If
    End Sub

#End Region

   

    Private Sub DGV_Items_RowsAdded(sender As Object, e As System.Windows.Forms.DataGridViewRowsAddedEventArgs) Handles DGV_Items.RowsAdded
        LabelNoItems.Text = DGV_Items.RowCount - 1
    End Sub
End Class




