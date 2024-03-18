Imports System.Data.Objects

Public Class DGV_ItemsRef
    Inherits System.Windows.Forms.DataGridView
    Private TBX_TotalCost As TextBox
    Public IJTransaction As IJTransaction

    Sub initMe(ByRef TextBox_TotalCost As TextBox, ByVal IJFRM_Type As IJFRM_Types)
        Me.TBX_TotalCost = TextBox_TotalCost

        Select Case IJFRM_Type
            Case IJFRM_Types.RequestEdit
                IJTransaction = New IJSupplyRequestEdit(Me)
            Case IJFRM_Types.Receive
                IJTransaction = New IJSupplyReceive(Me)
            Case IJFRM_Types.ReceiveEdit
                IJTransaction = New IJSupplyReceiveEdit(Me)
            Case IJFRM_Types.RequisitionEdit
                IJTransaction = New IJFacilityRequestEdit(Me)
            Case IJFRM_Types.Issue
                IJTransaction = New IJPreInvoice(Me)
            Case IJFRM_Types.IssueEdit
                IJTransaction = New IJInvoice(Me)
            Case IJFRM_Types.Adjustment
                IJTransaction = New IJAdjustment(Me)
            Case IJFRM_Types.OPDIssueEdit
                IJTransaction = New IJOPDEdit(Me)
            Case IJFRM_Types.IPDIssueEdit
                IJTransaction = New IJIPDEdit(Me)
            Case IJFRM_Types.GRNEdit
                IJTransaction = New IJGRNEdit(Me)
            Case IJFRM_Types.TransfersEdit
                IJTransaction = New IJTransferEdit(Me)
        End Select
        For Each column As DataGridViewColumn In Me.Columns
            If column.ReadOnly Then column.CellTemplate.Style.BackColor = Color.FromArgb(200, 200, 200)
        Next
        Me.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(245, 245, 245)
        AddHandler Me.CellValueChanged, AddressOf cellValueChange
        AddHandler Me.RowsRemoved, AddressOf rowsRemove
        AddHandler Me.RowsAdded, AddressOf rowsAdd
        If IJFRM_Type = IJFRM_Types.Receive Or IJFRM_Types.Issue Or IJFRM_Types.IssueEdit Then
            Me.AllowUserToAddRows = False
            Me.AllowUserToAddRows = True
        Else
            Me.AllowUserToAddRows = False
        End If
    End Sub

    Sub CalcualteTotalCost()
        Dim Running_Quantity As Double = 0
        For Each ItemRow As DataGridViewRow In Me.Rows
            Running_Quantity += Val(ItemRow.Cells("Amount").Value)
        Next
        TBX_TotalCost.Text = FormatNumber(Running_Quantity, 2, , , TriState.True)
    End Sub

    Private Sub cellValidate(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Me.CellValidated
        IJTransaction.ValidateCell(Me.Rows(e.RowIndex).Cells(e.ColumnIndex))
    End Sub

    Private Sub cellValueChange(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) ' Handles DGV_Items.CellValueChanged
        Dim checkcell = Me.Rows(e.RowIndex).Cells(e.ColumnIndex)
        Dim Qty As Single = 0
        Dim allowCalculate As Boolean = False

        If Not Me.Rows(checkcell.RowIndex).IsNewRow Then
            If Me.FindForm.GetType() = GetType(FRM_IJSupplyReceive) Or Me.FindForm.GetType() = GetType(FRM_IJSupplyReceiveEdit) Then
                If Me.Columns(checkcell.ColumnIndex).Equals(Me.Columns("Qty")) Or Me.Columns.Contains("Amount") Then
                    'MsgBox("RowIndex: " & e.RowIndex & " " & Val(Me.Rows(checkcell.RowIndex).Cells("Cost").Value) * Val(Me.Rows(checkcell.RowIndex).Cells("Qty").Value))
                    RemoveHandler Me.CellValueChanged, AddressOf cellValueChange
                    If Val(Me.Rows(checkcell.RowIndex).Cells("Qty").Value) <> 0 Then
                        Me.Rows(checkcell.RowIndex).Cells("Cost").Value = (Val(Me.Rows(checkcell.RowIndex).Cells("Amount").Value) / Val(Me.Rows(checkcell.RowIndex).Cells("Qty").Value)) & ""
                        Me.IJTransaction.clearError(Me.Rows(checkcell.RowIndex).Cells("Cost"))
                    Else
                        Me.Rows(checkcell.RowIndex).Cells("Cost").Value = 0
                    End If
                    AddHandler Me.CellValueChanged, AddressOf cellValueChange
                    CalcualteTotalCost()
                End If
            Else
                If Me.Columns(checkcell.ColumnIndex).Equals(Me.Columns("Qty")) Or Me.Columns.Contains("Cost") Then
                    'MsgBox("RowIndex: " & e.RowIndex & " " & Val(Me.Rows(checkcell.RowIndex).Cells("Cost").Value) * Val(Me.Rows(checkcell.RowIndex).Cells("Qty").Value))
                    RemoveHandler Me.CellValueChanged, AddressOf cellValueChange
                    Me.Rows(checkcell.RowIndex).Cells("Amount").Value = Val(Me.Rows(checkcell.RowIndex).Cells("Cost").Value) * Val(Me.Rows(checkcell.RowIndex).Cells("Qty").Value)
                    AddHandler Me.CellValueChanged, AddressOf cellValueChange
                    CalcualteTotalCost()
                End If
            End If

        End If
    End Sub

    Private Sub rowsRemove(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsRemovedEventArgs) ' Handles DGV_Items.RowsRemoved
        CalcualteTotalCost()
    End Sub

    Private Sub rowsAdd(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewRowsAddedEventArgs) ' Handles DGV_Items.RowsAdded        
        IJTransaction.RowsAdd(e.RowIndex, (e.RowIndex + e.RowCount - 1))
    End Sub

    Public Sub PopulateItems(ByVal IJID As String)
        IJTransaction.PopulateItems(IJID)
        'Me.Sort(Me.Columns("ItemID"), System.ComponentModel.ListSortDirection.Ascending)        
    End Sub

    Public Function ValidateData() As Boolean
        Return IJTransaction.ValidateData()
    End Function

    Public Function RowHasError(ByVal checkRow As DataGridViewRow) As Boolean
        For Each cell As DataGridViewCell In checkRow.Cells
            If cell.ErrorText <> String.Empty Then Return False
        Next
        Return True
    End Function
End Class

Public Class ComboCell
    Inherits DataGridViewTextBoxCell
    Public BatchLocationID As String
    Private ComboCellType As ComboCellTypes
    Public Sub New(ByVal ComboCellType As ComboCellTypes)
        Me.Style.Format = "d"
        Me.ComboCellType = ComboCellType
    End Sub

    Public Overrides Sub InitializeEditingControl(ByVal rowIndex As Integer, ByVal initialFormattedValue As Object, ByVal dataGridViewCellStyle As DataGridViewCellStyle)
        MyBase.InitializeEditingControl(rowIndex, initialFormattedValue, dataGridViewCellStyle)
        Select Case ComboCellType
            Case ComboCellTypes.Items
                Dim ctl As New ComboEditingControlItems
            Case ComboCellTypes.Batches
                Dim ctl As New ComboEditingControlBatches
            Case ComboCellTypes.Locations
                Dim ctl As New ComboEditingControlLocations
            Case ComboCellTypes.BatchLocations
                Dim ctl As New ComboEditingControlBatchLocations
        End Select
    End Sub

    Public Overrides ReadOnly Property EditType() As Type
        Get
            Select Case ComboCellType
                Case ComboCellTypes.Items
                    Return GetType(ComboEditingControlItems)
                Case ComboCellTypes.Batches
                    Return GetType(ComboEditingControlBatches)
                Case ComboCellTypes.Locations
                    Return GetType(ComboEditingControlLocations)
                Case ComboCellTypes.BatchLocations
                    Return GetType(ComboEditingControlBatchLocations)
                Case Else
                    Return Nothing
            End Select
        End Get
    End Property

    Public Overrides ReadOnly Property ValueType() As Type
        Get
            Return GetType(Object)
        End Get
    End Property

    Public Overrides ReadOnly Property DefaultNewRowValue() As Object
        Get
            Return Nothing
        End Get
    End Property

End Class

Class ComboEditingControlItems
    Inherits System.Windows.Forms.ComboBox
    Implements IDataGridViewEditingControl

    Private UserPromptedSelectionChange As Boolean = True
    Private DGV As DataGridView
    Private ValueIsChanged As Boolean = False
    Private RowIndex As Integer
    Public Property EditingControlFormattedValue() As Object Implements IDataGridViewEditingControl.EditingControlFormattedValue
        Get
            Return CType(Me.SelectedItem, InventoryItem).Name
        End Get
        Set(ByVal value As Object)
            Me.SelectedItem = value
        End Set
    End Property

    Public Function GetEditingControlFormattedValue(ByVal context As DataGridViewDataErrorContexts) As Object Implements IDataGridViewEditingControl.GetEditingControlFormattedValue
        If Me.SelectedItem IsNot Nothing Then Return CType(Me.SelectedItem, InventoryItem).Name
        Return ""
    End Function

    Public Sub PrepareEditingControlForEdit(ByVal selectAll As Boolean) Implements IDataGridViewEditingControl.PrepareEditingControlForEdit
        Dim SelectItemID As String = DGV.Rows(RowIndex).Cells("ItemID").Value
        Me.ValueMember = "ID"
        Me.DisplayMember = "Name"
        Dim IPDOPD As Boolean = False
        If FRM_GLBMain.ApplicationConfig.ThisDepartment.DepartmentType.Description = "Level 4O" Or FRM_GLBMain.ApplicationConfig.ThisDepartment.DepartmentType.Description = "Level 4I" Then IPDOPD = True
        If DGV.FindForm.GetType() = GetType(FRM_IJSTVEdit) Then
            If CType(DGV.FindForm, FRM_IJSTVEdit).CMBX_FromLocation.SelectedItem IsNot Nothing Then
                Dim LMISDb As New LMISEntities
                Dim LocationID As String = CType(DGV.FindForm, FRM_IJSTVEdit).CMBX_FromLocation.SelectedValue
                Me.DataSource = From IJDB In LMISDb.InventoryJournalDetailsBatches
                              Join VIT In LMISDb.VW_ItemBatchQty
                              On VIT.ID Equals IJDB.InventoryBatchID
                              Where IJDB.LocationID = LocationID And ((IJDB.InventoryBatch.ExpireDate IsNot Nothing And IJDB.InventoryBatch.ExpireDate > Date.Today) Or (True)) And VIT.Quantity_Available > 0 And IJDB.InventoryJournalDetail.InventoryJournal.DepartmentID = FRM_GLBMain.ApplicationConfig.ThisDepartment.ID And ((IPDOPD And (IJDB.InventoryJournalDetail.InventoryItem.ItemsCatalogue.InventoryCategory.Classification.Category.ID = "10000000" Or IJDB.InventoryJournalDetail.InventoryItem.ItemsCatalogue.InventoryCategory.Classification.Category.ID = "70000000")) Or True)
                              Order By IJDB.InventoryBatch.ExpireDate Ascending
                              Order By IJDB.InventoryJournalDetail.InventoryItem.Name Select IJDB.InventoryJournalDetail.InventoryItem Distinct
            Else
                Me.DataSource = From I In (New LMISEntities).InventoryItems Order By I.Name Select I Where ((IPDOPD And (I.ItemsCatalogue.InventoryCategory.Classification.Category.ID = "10000000" Or I.ItemsCatalogue.InventoryCategory.Classification.Category.ID = "70000000")) Or True)
            End If
        Else
            Me.DataSource = From I In (New LMISEntities).InventoryItems Order By I.Name Select I Where ((IPDOPD And (I.ItemsCatalogue.InventoryCategory.Classification.Category.ID = "10000000" Or I.ItemsCatalogue.InventoryCategory.Classification.Category.ID = "70000000")) Or True)
        End If
        Me.DropDownWidth = 400
        If Me.DataSource IsNot Nothing Then
            Me.AutoCompleteSource = AutoCompleteSource.ListItems
            Me.AutoCompleteMode = AutoCompleteMode.Suggest
            If SelectItemID IsNot Nothing Then
                Me.SelectedValue = SelectItemID
            Else
                Me.SelectedIndex = -1
            End If
        Else
            Me.SelectedIndex = -1
        End If
    End Sub

    Protected Overrides Sub OnDataSourceChanged(ByVal e As System.EventArgs)
        userPromptedSelectionChange = False 'this allows the combobox to differentiate between selections that occured due to datasource changes and those that are real user selections. when datasource is changed the selectedindex becomes 0 that is it points to the first combobox item, which is undesirable at this case. 
        MyBase.OnDataSourceChanged(e)
        userPromptedSelectionChange = True
    End Sub
    Protected Overrides Sub OnValueMemberChanged(ByVal e As System.EventArgs)
        userPromptedSelectionChange = False 'this allows the combobox to differentiate between selections that occured due to datasource changes and those that are real user selections. when datasource is changed the selectedindex becomes 0 that is it points to the first combobox item, which is undesirable at this case. 
        MyBase.OnValueMemberChanged(e)
        userPromptedSelectionChange = True
    End Sub
    Protected Overrides Sub OnDisplayMemberChanged(ByVal e As System.EventArgs)
        userPromptedSelectionChange = False 'this allows the combobox to differentiate between selections that occured due to datasource changes and those that are real user selections. when datasource is changed the selectedindex becomes 0 that is it points to the first combobox item, which is undesirable at this case. 
        MyBase.OnDisplayMemberChanged(e)
        userPromptedSelectionChange = True
    End Sub

    Protected Overrides Sub OnSelectedIndexChanged(ByVal eventargs As System.EventArgs)
        MyBase.OnSelectedIndexChanged(eventargs)
        valueIsChanged = True
        Me.EditingControlDataGridView.NotifyCurrentCellDirty(True)
        MyBase.OnSelectedIndexChanged(eventargs)
        If UserPromptedSelectionChange Then CType(DGV, DGV_ItemsRef).IJTransaction.ItemChanged(RowIndex, Me.SelectedItem)
    End Sub

    Public Sub ApplyCellStyleToEditingControl(ByVal dataGridViewCellStyle As DataGridViewCellStyle) Implements IDataGridViewEditingControl.ApplyCellStyleToEditingControl
        Me.Font = dataGridViewCellStyle.Font
    End Sub

    Public Property EditingControlRowIndex() As Integer Implements IDataGridViewEditingControl.EditingControlRowIndex
        Get
            Return rowIndex
        End Get
        Set(ByVal value As Integer)
            rowIndex = value
        End Set
    End Property

    Public Function EditingControlWantsInputKey(ByVal key As Keys, ByVal dataGridViewWantsInputKey As Boolean) As Boolean Implements IDataGridViewEditingControl.EditingControlWantsInputKey
        Select Case key And Keys.KeyCode
            Case Keys.Left, Keys.Up, Keys.Down, Keys.Right, Keys.Home, Keys.End, Keys.PageDown, Keys.PageUp
                Return True
            Case Else
                Return Not dataGridViewWantsInputKey
        End Select
    End Function

    Public ReadOnly Property RepositionEditingControlOnValueChange() As Boolean Implements IDataGridViewEditingControl.RepositionEditingControlOnValueChange
        Get
            Return False
        End Get
    End Property

    Public Property EditingControlDataGridView() As DataGridView Implements IDataGridViewEditingControl.EditingControlDataGridView
        Get
            Return DGV
        End Get
        Set(ByVal value As DataGridView)
            DGV = value
        End Set
    End Property

    Public Property EditingControlValueChanged() As Boolean Implements IDataGridViewEditingControl.EditingControlValueChanged
        Get
            Return valueIsChanged
        End Get
        Set(ByVal value As Boolean)
            valueIsChanged = value
        End Set
    End Property

    Public ReadOnly Property EditingControlCursor() As Cursor Implements IDataGridViewEditingControl.EditingPanelCursor
        Get
            Return MyBase.Cursor
        End Get
    End Property

End Class

Class ComboEditingControlBatches
    Inherits System.Windows.Forms.ComboBox
    Implements IDataGridViewEditingControl

    Private UserPromptedSelectionChange As Boolean = True
    Private DGV As DataGridView
    Private ValueIsChanged As Boolean = False
    Private RowIndex As Integer
    Public Property EditingControlFormattedValue() As Object Implements IDataGridViewEditingControl.EditingControlFormattedValue
        Get
            Return Me.Text
        End Get
        Set(ByVal value As Object)
            Me.Text = CType(value, String)
        End Set
    End Property

    Public Function GetEditingControlFormattedValue(ByVal context As DataGridViewDataErrorContexts) As Object Implements IDataGridViewEditingControl.GetEditingControlFormattedValue
        Return Me.Text
    End Function

    Public Sub PrepareEditingControlForEdit(ByVal selectAll As Boolean) Implements IDataGridViewEditingControl.PrepareEditingControlForEdit
        Dim SelectBatch As String = DGV.Rows(RowIndex).Cells("Batch").Value
        Me.DropDownWidth = 200
        If DGV.FindForm.GetType() = GetType(FRM_IJSTVEdit) Then
            If CType(DGV.FindForm, FRM_IJSTVEdit).CMBX_FromLocation.SelectedItem IsNot Nothing Then
                Dim LMISDb As New LMISEntities
                Dim ItemID As String = DGV.Rows(RowIndex).Cells("ItemID").Value
                Dim LocationID As String = CType(DGV.FindForm, FRM_IJSTVEdit).CMBX_FromLocation.SelectedValue
                SelectBatch = String.Empty
                Me.DataSource = From IJDB In LMISDb.InventoryJournalDetailsBatches
                              Join VIT In LMISDb.VW_ItemBatchQty
                              On VIT.ID Equals IJDB.InventoryBatchID
                              Where IJDB.InventoryJournalDetail.ItemID = ItemID And IJDB.LocationID = LocationID And ((IJDB.InventoryBatch.ExpireDate IsNot Nothing And IJDB.InventoryBatch.ExpireDate > Date.Today) Or (True)) And VIT.Quantity_Available > 0 And IJDB.InventoryJournalDetail.InventoryJournal.DepartmentID = FRM_GLBMain.ApplicationConfig.ThisDepartment.ID
                              Order By IJDB.InventoryBatch.ExpireDate Ascending
                              Select IJDB.InventoryBatch Distinct
            Else
                Me.DataSource = Nothing
            End If
        ElseIf DGV.FindForm.GetType() = GetType(FRM_IJAdjustment) Then
            Dim LMISDb As New LMISEntities
            Dim ItemID As String = DGV.Rows(RowIndex).Cells("ItemID").Value
            SelectBatch = String.Empty
            Me.DataSource = From IJDB In LMISDb.InventoryJournalDetailsBatches
                          Join VIT In LMISDb.VW_ItemBatchQty
                          On VIT.ID Equals IJDB.InventoryBatchID
                          Where IJDB.InventoryJournalDetail.ItemID = ItemID And ((IJDB.InventoryBatch.ExpireDate IsNot Nothing And IJDB.InventoryBatch.ExpireDate > Date.Today) Or (True)) And VIT.Quantity_Available > 0 And IJDB.InventoryJournalDetail.InventoryJournal.DepartmentID = FRM_GLBMain.ApplicationConfig.ThisDepartment.ID
                          Order By IJDB.InventoryBatch.ExpireDate Ascending
                          Select IJDB.InventoryBatch Distinct
        Else
            Me.DataSource = Utility.Get_ItemBatches(DGV.Rows(RowIndex).Cells("ItemID").Value)
        End If
        If Me.DataSource IsNot Nothing Then
            Me.ValueMember = "ID"
            Me.DisplayMember = "ID"
            Me.AutoCompleteSource = AutoCompleteSource.ListItems
            Me.AutoCompleteMode = AutoCompleteMode.Suggest
            If SelectBatch IsNot Nothing Then
                If Me.Items.Contains(SelectBatch) Then
                    Me.SelectedValue = SelectBatch
                Else
                    Me.Text = SelectBatch
                End If
            Else
                Me.SelectedIndex = -1
            End If
        Else
            Me.SelectedIndex = -1
        End If

    End Sub

    Protected Overrides Sub OnDataSourceChanged(ByVal e As System.EventArgs)
        userPromptedSelectionChange = False 'this allows the combobox to differentiate between selections that occured due to datasource changes and those that are real user selections. when datasource is changed the selectedindex becomes 0 that is it points to the first combobox item, which is undesirable at this case. 
        MyBase.OnDataSourceChanged(e)
        userPromptedSelectionChange = True
    End Sub
    Protected Overrides Sub OnValueMemberChanged(ByVal e As System.EventArgs)
        userPromptedSelectionChange = False 'this allows the combobox to differentiate between selections that occured due to datasource changes and those that are real user selections. when datasource is changed the selectedindex becomes 0 that is it points to the first combobox item, which is undesirable at this case. 
        MyBase.OnValueMemberChanged(e)
        userPromptedSelectionChange = True
    End Sub
    Protected Overrides Sub OnDisplayMemberChanged(ByVal e As System.EventArgs)
        userPromptedSelectionChange = False 'this allows the combobox to differentiate between selections that occured due to datasource changes and those that are real user selections. when datasource is changed the selectedindex becomes 0 that is it points to the first combobox item, which is undesirable at this case. 
        MyBase.OnDisplayMemberChanged(e)
        userPromptedSelectionChange = True
    End Sub

    Protected Overrides Sub OnTextChanged(ByVal e As System.EventArgs)
        MyBase.OnTextChanged(e)
        ValueIsChanged = True
        Me.EditingControlDataGridView.NotifyCurrentCellDirty(True)
        MyBase.OnTextChanged(e)
    End Sub
    Protected Overrides Sub OnSelectedIndexChanged(ByVal eventargs As System.EventArgs)
        MyBase.OnSelectedIndexChanged(eventargs)
        ValueIsChanged = True
        Me.EditingControlDataGridView.NotifyCurrentCellDirty(True)
        MyBase.OnSelectedIndexChanged(eventargs)
        If UserPromptedSelectionChange And Me.SelectedIndex <> -1 Then CType(DGV, DGV_ItemsRef).IJTransaction.BatchChanged(RowIndex, Me.Text)
    End Sub

    Public Sub ApplyCellStyleToEditingControl(ByVal dataGridViewCellStyle As DataGridViewCellStyle) Implements IDataGridViewEditingControl.ApplyCellStyleToEditingControl
        Me.Font = dataGridViewCellStyle.Font
    End Sub

    Public Property EditingControlRowIndex() As Integer Implements IDataGridViewEditingControl.EditingControlRowIndex
        Get
            Return RowIndex
        End Get
        Set(ByVal value As Integer)
            RowIndex = value
        End Set
    End Property

    Public Function EditingControlWantsInputKey(ByVal key As Keys, ByVal dataGridViewWantsInputKey As Boolean) As Boolean Implements IDataGridViewEditingControl.EditingControlWantsInputKey
        'Select Case key And Keys.KeyCode
        '    Case Keys.Left, Keys.Up, Keys.Down, Keys.Right, Keys.Home, Keys.End, Keys.PageDown, Keys.PageUp
        Return True
        '    Case Else
        '        Return Not dataGridViewWantsInputKey
        'End Select
    End Function

    Public ReadOnly Property RepositionEditingControlOnValueChange() As Boolean Implements IDataGridViewEditingControl.RepositionEditingControlOnValueChange
        Get
            Return False
        End Get
    End Property

    Public Property EditingControlDataGridView() As DataGridView Implements IDataGridViewEditingControl.EditingControlDataGridView
        Get
            Return DGV
        End Get
        Set(ByVal value As DataGridView)
            DGV = value
        End Set
    End Property

    Public Property EditingControlValueChanged() As Boolean Implements IDataGridViewEditingControl.EditingControlValueChanged
        Get
            Return ValueIsChanged
        End Get
        Set(ByVal value As Boolean)
            ValueIsChanged = value
        End Set
    End Property

    Public ReadOnly Property EditingControlCursor() As Cursor Implements IDataGridViewEditingControl.EditingPanelCursor
        Get
            Return MyBase.Cursor
        End Get
    End Property

End Class

Class ComboEditingControlLocations
    Inherits System.Windows.Forms.ComboBox
    Implements IDataGridViewEditingControl

    Private UserPromptedSelectionChange As Boolean = True
    Private DGV As DataGridView
    Private ValueIsChanged As Boolean = False
    Private RowIndex As Integer

    Public Property EditingControlFormattedValue() As Object Implements IDataGridViewEditingControl.EditingControlFormattedValue
        Get
            Return CType(Me.SelectedItem, IDNdata).Data
        End Get
        Set(ByVal value As Object)
            Me.SelectedItem = value
        End Set
    End Property

    Public Function GetEditingControlFormattedValue(ByVal context As DataGridViewDataErrorContexts) As Object Implements IDataGridViewEditingControl.GetEditingControlFormattedValue
        If Me.SelectedItem IsNot Nothing Then Return CType(Me.SelectedItem, IDNdata).Data
        Return ""
    End Function

    Public Sub PrepareEditingControlForEdit(ByVal selectAll As Boolean) Implements IDataGridViewEditingControl.PrepareEditingControlForEdit
        Me.DropDownWidth = 200
        Dim SelectItemID As String = CType(DGV.Rows(RowIndex).Cells("Batch_Location"), ComboCell).BatchLocationID
        Me.DataSource = Utility.Get_ItemBatchLocations()
        If Me.DataSource IsNot Nothing Then
            Me.ValueMember = "ID"
            Me.DisplayMember = "Data"
            Me.AutoCompleteSource = AutoCompleteSource.ListItems
            Me.AutoCompleteMode = AutoCompleteMode.Suggest
            Me.DropDownStyle = ComboBoxStyle.DropDown
            If SelectItemID IsNot Nothing Then
                Me.SelectedValue = SelectItemID
            Else
                Me.SelectedIndex = -1
            End If
        Else
            Me.SelectedIndex = -1
        End If
    End Sub

    Protected Overrides Sub OnDataSourceChanged(ByVal e As System.EventArgs)
        UserPromptedSelectionChange = False 'this allows the combobox to differentiate between selections that occured due to datasource changes and those that are real user selections. when datasource is changed the selectedindex becomes 0 that is it points to the first combobox item, which is undesirable at this case. 
        MyBase.OnDataSourceChanged(e)
        UserPromptedSelectionChange = True
    End Sub
    Protected Overrides Sub OnValueMemberChanged(ByVal e As System.EventArgs)
        UserPromptedSelectionChange = False 'this allows the combobox to differentiate between selections that occured due to datasource changes and those that are real user selections. when datasource is changed the selectedindex becomes 0 that is it points to the first combobox item, which is undesirable at this case. 
        MyBase.OnValueMemberChanged(e)
        UserPromptedSelectionChange = True
    End Sub
    Protected Overrides Sub OnDisplayMemberChanged(ByVal e As System.EventArgs)
        UserPromptedSelectionChange = False 'this allows the combobox to differentiate between selections that occured due to datasource changes and those that are real user selections. when datasource is changed the selectedindex becomes 0 that is it points to the first combobox item, which is undesirable at this case. 
        MyBase.OnDisplayMemberChanged(e)
        UserPromptedSelectionChange = True
    End Sub

    Protected Overrides Sub OnSelectedIndexChanged(ByVal eventargs As System.EventArgs)
        MyBase.OnSelectedIndexChanged(eventargs)
        ValueIsChanged = True
        Me.EditingControlDataGridView.NotifyCurrentCellDirty(True)
        MyBase.OnSelectedIndexChanged(eventargs)
        If UserPromptedSelectionChange And Me.SelectedIndex <> -1 Then CType(DGV, DGV_ItemsRef).IJTransaction.BatchLocationChanged(RowIndex, Me.SelectedItem)
    End Sub

    Public Sub ApplyCellStyleToEditingControl(ByVal dataGridViewCellStyle As DataGridViewCellStyle) Implements IDataGridViewEditingControl.ApplyCellStyleToEditingControl
        Me.Font = dataGridViewCellStyle.Font
    End Sub

    Public Property EditingControlRowIndex() As Integer Implements IDataGridViewEditingControl.EditingControlRowIndex
        Get
            Return RowIndex
        End Get
        Set(ByVal value As Integer)
            RowIndex = value
        End Set
    End Property

    Public Function EditingControlWantsInputKey(ByVal key As Keys, ByVal dataGridViewWantsInputKey As Boolean) As Boolean Implements IDataGridViewEditingControl.EditingControlWantsInputKey
        Select Case key And Keys.KeyCode
            Case Keys.Left, Keys.Up, Keys.Down, Keys.Right, Keys.Home, Keys.End, Keys.PageDown, Keys.PageUp
                Return True
            Case Else
                Return Not dataGridViewWantsInputKey
        End Select

    End Function

    Public ReadOnly Property RepositionEditingControlOnValueChange() As Boolean Implements IDataGridViewEditingControl.RepositionEditingControlOnValueChange
        Get
            Return False
        End Get
    End Property

    Public Property EditingControlDataGridView() As DataGridView Implements IDataGridViewEditingControl.EditingControlDataGridView
        Get
            Return DGV
        End Get
        Set(ByVal value As DataGridView)
            DGV = value
        End Set
    End Property

    Public Property EditingControlValueChanged() As Boolean Implements IDataGridViewEditingControl.EditingControlValueChanged
        Get
            Return ValueIsChanged
        End Get
        Set(ByVal value As Boolean)
            ValueIsChanged = value
        End Set
    End Property

    Public ReadOnly Property EditingControlCursor() As Cursor Implements IDataGridViewEditingControl.EditingPanelCursor
        Get
            Return MyBase.Cursor
        End Get
    End Property

End Class

Class ComboEditingControlBatchLocations
    Inherits System.Windows.Forms.ComboBox
    Implements IDataGridViewEditingControl

    Private UserPromptedSelectionChange As Boolean = True
    Private DGV As DataGridView
    Private ValueIsChanged As Boolean = False
    Private RowIndex As Integer

    Public Property EditingControlFormattedValue() As Object Implements IDataGridViewEditingControl.EditingControlFormattedValue
        Get
            Return CType(Me.SelectedItem, IDNdata).Data
        End Get
        Set(ByVal value As Object)
            Me.SelectedItem = value
        End Set
    End Property

    Public Function GetEditingControlFormattedValue(ByVal context As DataGridViewDataErrorContexts) As Object Implements IDataGridViewEditingControl.GetEditingControlFormattedValue
        If Me.SelectedItem IsNot Nothing Then Return CType(Me.SelectedItem, IDNdata).Data
        Return ""
    End Function

    Public Sub PrepareEditingControlForEdit(ByVal selectAll As Boolean) Implements IDataGridViewEditingControl.PrepareEditingControlForEdit
        Me.DropDownWidth = 200
        Dim SelectItemID As String = CType(DGV.Rows(RowIndex).Cells("Batch_Location"), ComboCell).BatchLocationID
        Me.DataSource = Utility.Get_BatchLocations(DGV.Rows(Me.RowIndex).Cells("Batch").Value)
        If Me.DataSource IsNot Nothing Then
            Me.ValueMember = "ID"
            Me.DisplayMember = "Data"
            Me.AutoCompleteSource = AutoCompleteSource.ListItems
            Me.AutoCompleteMode = AutoCompleteMode.Suggest
            Me.DropDownStyle = ComboBoxStyle.DropDown
            If SelectItemID IsNot Nothing Then
                Me.SelectedValue = SelectItemID
            Else
                Me.SelectedIndex = -1
            End If
        Else
            Me.SelectedIndex = -1
        End If
    End Sub

    Protected Overrides Sub OnDataSourceChanged(ByVal e As System.EventArgs)
        UserPromptedSelectionChange = False 'this allows the combobox to differentiate between selections that occured due to datasource changes and those that are real user selections. when datasource is changed the selectedindex becomes 0 that is it points to the first combobox item, which is undesirable at this case. 
        MyBase.OnDataSourceChanged(e)
        UserPromptedSelectionChange = True
    End Sub
    Protected Overrides Sub OnValueMemberChanged(ByVal e As System.EventArgs)
        UserPromptedSelectionChange = False 'this allows the combobox to differentiate between selections that occured due to datasource changes and those that are real user selections. when datasource is changed the selectedindex becomes 0 that is it points to the first combobox item, which is undesirable at this case. 
        MyBase.OnValueMemberChanged(e)
        UserPromptedSelectionChange = True
    End Sub
    Protected Overrides Sub OnDisplayMemberChanged(ByVal e As System.EventArgs)
        UserPromptedSelectionChange = False 'this allows the combobox to differentiate between selections that occured due to datasource changes and those that are real user selections. when datasource is changed the selectedindex becomes 0 that is it points to the first combobox item, which is undesirable at this case. 
        MyBase.OnDisplayMemberChanged(e)
        UserPromptedSelectionChange = True
    End Sub

    Protected Overrides Sub OnSelectedIndexChanged(ByVal eventargs As System.EventArgs)
        MyBase.OnSelectedIndexChanged(eventargs)
        ValueIsChanged = True
        Me.EditingControlDataGridView.NotifyCurrentCellDirty(True)
        MyBase.OnSelectedIndexChanged(eventargs)
        If UserPromptedSelectionChange And Me.SelectedIndex <> -1 Then CType(DGV, DGV_ItemsRef).IJTransaction.BatchLocationChanged(RowIndex, Me.SelectedItem)
    End Sub
#Region "Do not touch"
    Public Sub ApplyCellStyleToEditingControl(ByVal dataGridViewCellStyle As DataGridViewCellStyle) Implements IDataGridViewEditingControl.ApplyCellStyleToEditingControl
        Me.Font = dataGridViewCellStyle.Font
    End Sub

    Public Property EditingControlRowIndex() As Integer Implements IDataGridViewEditingControl.EditingControlRowIndex
        Get
            Return RowIndex
        End Get
        Set(ByVal value As Integer)
            RowIndex = value
        End Set
    End Property

    Public Function EditingControlWantsInputKey(ByVal key As Keys, ByVal dataGridViewWantsInputKey As Boolean) As Boolean Implements IDataGridViewEditingControl.EditingControlWantsInputKey
        Select Case key And Keys.KeyCode
            Case Keys.Left, Keys.Up, Keys.Down, Keys.Right, Keys.Home, Keys.End, Keys.PageDown, Keys.PageUp
                Return True
            Case Else
                Return Not dataGridViewWantsInputKey
        End Select

    End Function

    Public ReadOnly Property RepositionEditingControlOnValueChange() As Boolean Implements IDataGridViewEditingControl.RepositionEditingControlOnValueChange
        Get
            Return False
        End Get
    End Property

    Public Property EditingControlDataGridView() As DataGridView Implements IDataGridViewEditingControl.EditingControlDataGridView
        Get
            Return DGV
        End Get
        Set(ByVal value As DataGridView)
            DGV = value
        End Set
    End Property

    Public Property EditingControlValueChanged() As Boolean Implements IDataGridViewEditingControl.EditingControlValueChanged
        Get
            Return ValueIsChanged
        End Get
        Set(ByVal value As Boolean)
            ValueIsChanged = value
        End Set
    End Property

    Public ReadOnly Property EditingControlCursor() As Cursor Implements IDataGridViewEditingControl.EditingPanelCursor
        Get
            Return MyBase.Cursor
        End Get
    End Property
#End Region
End Class

Public Enum ComboCellTypes As Integer
    Items
    Batches
    Locations
    BatchLocations
End Enum

Public Class CalendarCell
    Inherits DataGridViewTextBoxCell

    Public Sub New()
        Me.Style.Format = "d"
    End Sub

    Public Overrides Sub InitializeEditingControl(ByVal rowIndex As Integer, ByVal initialFormattedValue As Object, ByVal dataGridViewCellStyle As DataGridViewCellStyle)
        MyBase.InitializeEditingControl(rowIndex, initialFormattedValue, dataGridViewCellStyle)
        Dim ctl As CalendarEditingControl = CType(DataGridView.EditingControl, CalendarEditingControl)
        ctl.Value = Date.Today
    End Sub

    Public Overrides ReadOnly Property EditType() As Type
        Get
            Return GetType(CalendarEditingControl)
        End Get
    End Property

    Public Overrides ReadOnly Property ValueType() As Type
        Get
            Return GetType(DateTime)
        End Get
    End Property

    Public Overrides ReadOnly Property DefaultNewRowValue() As Object
        Get
            Return DateTime.Now
        End Get
    End Property

End Class

Class CalendarEditingControl
    Inherits DateTimePicker
    Implements IDataGridViewEditingControl

    Private dataGridViewControl As DataGridView
    Private valueIsChanged As Boolean = False
    Private rowIndexNum As Integer

    Public Sub New()
        Me.Format = DateTimePickerFormat.Short
    End Sub

    Public Property EditingControlFormattedValue() As Object Implements IDataGridViewEditingControl.EditingControlFormattedValue
        Get
            Return Me.Value.ToShortDateString()
        End Get

        Set(ByVal value As Object)
            If TypeOf value Is String Then
                Me.Value = DateTime.Parse(CStr(value))
            End If
        End Set
    End Property

    Public Function GetEditingControlFormattedValue(ByVal context As DataGridViewDataErrorContexts) As Object Implements IDataGridViewEditingControl.GetEditingControlFormattedValue
        Return Me.Value.ToShortDateString()
    End Function

    Public Sub ApplyCellStyleToEditingControl(ByVal dataGridViewCellStyle As DataGridViewCellStyle) Implements IDataGridViewEditingControl.ApplyCellStyleToEditingControl
        Me.Font = dataGridViewCellStyle.Font
        Me.CalendarForeColor = dataGridViewCellStyle.ForeColor
        Me.CalendarMonthBackground = dataGridViewCellStyle.BackColor
    End Sub

    Public Property EditingControlRowIndex() As Integer Implements IDataGridViewEditingControl.EditingControlRowIndex
        Get
            Return rowIndexNum
        End Get
        Set(ByVal value As Integer)
            rowIndexNum = value
        End Set
    End Property

    Public Function EditingControlWantsInputKey(ByVal key As Keys, ByVal dataGridViewWantsInputKey As Boolean) As Boolean Implements IDataGridViewEditingControl.EditingControlWantsInputKey
        Select Case key And Keys.KeyCode
            Case Keys.Left, Keys.Up, Keys.Down, Keys.Right, Keys.Home, Keys.End, Keys.PageDown, Keys.PageUp
                Return True
            Case Else
                Return Not dataGridViewWantsInputKey
        End Select

    End Function

    Public Sub PrepareEditingControlForEdit(ByVal selectAll As Boolean) Implements IDataGridViewEditingControl.PrepareEditingControlForEdit
    End Sub

    Public ReadOnly Property RepositionEditingControlOnValueChange() As Boolean Implements IDataGridViewEditingControl.RepositionEditingControlOnValueChange
        Get
            Return False
        End Get
    End Property

    Public Property EditingControlDataGridView() As DataGridView Implements IDataGridViewEditingControl.EditingControlDataGridView
        Get
            Return dataGridViewControl
        End Get
        Set(ByVal value As DataGridView)
            dataGridViewControl = value
        End Set
    End Property

    Public Property EditingControlValueChanged() As Boolean Implements IDataGridViewEditingControl.EditingControlValueChanged
        Get
            Return valueIsChanged
        End Get
        Set(ByVal value As Boolean)
            valueIsChanged = value
        End Set
    End Property

    Public ReadOnly Property EditingControlCursor() As Cursor Implements IDataGridViewEditingControl.EditingPanelCursor
        Get
            Return MyBase.Cursor
        End Get
    End Property

    Protected Overrides Sub OnValueChanged(ByVal eventargs As EventArgs)
        valueIsChanged = True
        Me.EditingControlDataGridView.NotifyCurrentCellDirty(True)
        MyBase.OnValueChanged(eventargs)
    End Sub

End Class

Public MustInherit Class IJTransaction
    Protected DGV_Items As DGV_ItemsRef
    Public clearRows As Boolean = True

    Sub New(ByVal DGV_Items As DGV_ItemsRef)
        Me.DGV_Items = DGV_Items
    End Sub

    Public Overridable Sub ItemChanged(ByVal rowIndex As Integer, ByVal Item As InventoryItem)
        With DGV_Items.Rows(rowIndex)
            If Item IsNot Nothing Then
                If .Cells("ItemID").Value <> Item.ID Then BatchChanged(rowIndex, Nothing) 'if batch is prefilled by data from database when in edit mode                
                clearError(.Cells("ItemID"))
                clearError(.Cells("Item_Name"))
                .Cells("ItemID").Value = Item.ID
                .Cells("Item_Name").Value = Item.Name
                .Cells("UOM").Value = Item.Unit.Name
                If Item.ItemsCatalogue.Expires Then
                    If DGV_Items.Columns.Contains("Expiry_Date") Then
                        .Cells("Expiry_Date").ReadOnly = False 'True
                        .Cells("Expiry_Date").Style.BackColor = Color.White 'Color.FromArgb(200, 200, 200)
                    End If
                Else
                    If DGV_Items.Columns.Contains("Expiry_Date") Then
                        .Cells("Expiry_Date").Value = String.Empty
                        .Cells("Expiry_Date").ReadOnly = True
                        .Cells("Expiry_Date").Style.BackColor = Color.FromArgb(200, 200, 200)
                    End If
                End If
            Else
                If .Cells("ItemID").ErrorText = String.Empty Then .Cells("ItemID").Value = ""
                If .Cells("Item_Name").ErrorText = String.Empty Then .Cells("Item_Name").Value = ""
                .Cells("UOM").Value = ""
                .Cells("Cost").Value = ""
                BatchChanged(rowIndex, Nothing)
            End If
        End With
    End Sub

    Public Overridable Sub BatchChanged(ByVal rowIndex As Integer, ByVal BatchID As String)
        If BatchID IsNot Nothing Then
            If Utility.Get_ItemBatchExpiryDate(BatchID) IsNot Nothing Then
                DGV_Items.Rows(rowIndex).Cells("Expiry_Date").Value = Date.Parse(Utility.Get_ItemBatchExpiryDate(BatchID))

            Else
                DGV_Items.Rows(rowIndex).Cells("Expiry_Date").Value = ""
            End If

            DGV_Items.Rows(rowIndex).Cells("Cost").Value = Utility.Get_BatchCost(BatchID)
            DGV_Items.Rows(rowIndex).Cells("Batch_Location").Value = ""
        Else
            DGV_Items.Rows(rowIndex).Cells("Cost").Value = ""
            DGV_Items.Rows(rowIndex).Cells("Batch").Value = ""
            DGV_Items.Rows(rowIndex).Cells("Expiry_Date").Value = ""
            DGV_Items.Rows(rowIndex).Cells("Batch_Location").Value = ""
        End If
        BatchLocationChanged(rowIndex, Nothing)
    End Sub

    Public Overridable Sub BatchLocationChanged(ByVal rowIndex As Integer, ByVal BatchLocation As IDNdata)
        If BatchLocation IsNot Nothing Then
            CType(DGV_Items.Rows(rowIndex).Cells("Batch_Location"), ComboCell).BatchLocationID = BatchLocation.ID
        Else
            CType(DGV_Items.Rows(rowIndex).Cells("Batch_Location"), ComboCell).BatchLocationID = 0
        End If
    End Sub

    Public Overridable Function ValidateData() As Boolean
        Dim NoError As Boolean = True
        For Each Row As DataGridViewRow In DGV_Items.Rows
            If Not Row.IsNewRow Then
                With Row
                    If .Cells("ItemID").Value = String.Empty Then
                        setError(.Cells("ItemID"), "'Item Code' should not be empty", NoError)
                    ElseIf .Cells("ItemID").ErrorText <> String.Empty Then
                        NoError = False
                    End If
                    If .Cells("Item_Name").Value = String.Empty Then
                        setError(.Cells("Item_Name"), "'Item Name' should not be empty", NoError)
                    ElseIf .Cells("Item_Name").ErrorText <> String.Empty Then
                        NoError = False
                    End If
                    If Val(Row.Cells("Qty").Value) <= 0 Then
                        setError(Row.Cells("Qty"), "A proper 'Qty' should be entered", NoError)
                    ElseIf Row.Cells("Qty").ErrorText <> String.Empty Then
                        NoError = False
                    End If
                End With
            End If
        Next
        Return NoError
    End Function

    Public Overridable Sub ValidateCell(ByVal CheckCell As DataGridViewCell)
        If Not DGV_Items.Rows(CheckCell.RowIndex).IsNewRow And Not CheckCell.ReadOnly Then
            clearError(CheckCell)
            If DGV_Items.Columns(CheckCell.ColumnIndex).Equals(DGV_Items.Columns("ItemID")) Then
                If CheckCell.Value Is Nothing Then
                    setError(CheckCell, "'Item Code' should not be empty")
                    ItemChanged(CheckCell.RowIndex, Nothing)
                Else
                    Dim Item = Utility.Get_ItemDetailByID(CheckCell.Value)
                    If Item Is Nothing Then setError(CheckCell, "Item Code '" & CheckCell.Value & "' not found in database")
                    ItemChanged(CheckCell.RowIndex, Item)
                End If
            ElseIf DGV_Items.Columns(CheckCell.ColumnIndex).Equals(DGV_Items.Columns("Item_Name")) Then
                If CheckCell.Value Is Nothing Then
                    setError(CheckCell, "'Item Name' should not be empty")
                    ItemChanged(CheckCell.RowIndex, Nothing)
                End If
            ElseIf DGV_Items.Columns(CheckCell.ColumnIndex).Equals(DGV_Items.Columns("Cost")) Then
                If (Not IsNumeric(CheckCell.Value) Or Val(CheckCell.Value) < 0) Then setError(CheckCell, "Please Enter appropriate Number")
            ElseIf DGV_Items.Columns(CheckCell.ColumnIndex).Equals(DGV_Items.Columns("Qty")) Then
                If (Not IsNumeric(CheckCell.Value) Or Val(CheckCell.Value) <= 0) Then
                    setError(CheckCell, "Please Enter appropriate Number")
                End If
            End If
            If DGV_Items.Columns.Contains("Batch") Then
                If DGV_Items.Columns(CheckCell.ColumnIndex).Equals(DGV_Items.Columns("Batch")) Then
                    Dim ItemID As String = DGV_Items.Rows(CheckCell.RowIndex).Cells("ItemID").Value
                    Dim BatchID As String = DGV_Items.Rows(CheckCell.RowIndex).Cells("Batch").Value
                    'If ItemID IsNot String.Empty And BatchID IsNot String.Empty Then
                    '    Dim Batch = (From IJDB In (New LMISEntities).InventoryJournalDetailsBatches Where IJDB.InventoryBatchID = BatchID Select IJDB)
                    '    If Batch.Count > 0 Then If Batch.First.InventoryJournalDetail.ItemID <> ItemID Then setError(CheckCell, "Batch '" & BatchID & "' already exists for item '" & Batch.First.InventoryJournalDetail.ItemID & "'")
                    'End If
                    For Each Row As DataGridViewRow In DGV_Items.Rows
                        If Not Row.IsNewRow And Not Row.Equals(DGV_Items.Rows(CheckCell.RowIndex)) Then
                            If DGV_Items.Rows(CheckCell.RowIndex).Cells("ItemID").Value <> Row.Cells("ItemID").Value _
                                And DGV_Items.Rows(CheckCell.RowIndex).Cells("Batch").Value = Row.Cells("Batch").Value Then
                                setError(CheckCell, "Item " & DGV_Items.Rows(CheckCell.RowIndex).Cells("ItemID").Value & "' and  '" & Row.Cells("ItemID").Value & "' cannot have the same batch '" & DGV_Items.Rows(CheckCell.RowIndex).Cells("Batch").Value & "'")
                            End If
                        End If
                    Next
                End If
            End If
            If DGV_Items.Columns.Contains("Batch_Location") Then
                If DGV_Items.Columns(CheckCell.ColumnIndex).Equals(DGV_Items.Columns("Batch_Location")) Then
                    For Each Row As DataGridViewRow In DGV_Items.Rows
                        If Not Row.IsNewRow And Not Row.Equals(DGV_Items.Rows(CheckCell.RowIndex)) Then
                            If DGV_Items.Rows(CheckCell.RowIndex).Cells("ItemID").Value = Row.Cells("ItemID").Value _
                                And CType(DGV_Items.Rows(CheckCell.RowIndex).Cells("Batch_Location"), ComboCell).BatchLocationID = CType(Row.Cells("Batch_Location"), ComboCell).BatchLocationID _
                                And DGV_Items.Rows(CheckCell.RowIndex).Cells("Batch").Value = Row.Cells("Batch").Value Then
                                setError(CheckCell, "A row exists for Batch Location  '" & DGV_Items.Rows(CheckCell.RowIndex).Cells("Batch_Location").Value & "' for batch '" & DGV_Items.Rows(CheckCell.RowIndex).Cells("Batch").Value & "' and item '" & Row.Cells("ItemID").Value & "', OMIT either of the rows.")
                            End If
                        End If
                    Next
                    Dim ItemID As String = DGV_Items.Rows(CheckCell.RowIndex).Cells("ItemID").Value
                    Dim BatchID As String = DGV_Items.Rows(CheckCell.RowIndex).Cells("Batch").Value
                    If ItemID IsNot String.Empty And BatchID IsNot String.Empty Then
                        Dim Batch = (From IJDB In (New LMISEntities).InventoryJournalDetailsBatches Where IJDB.InventoryBatchID = BatchID Select IJDB)
                        If Batch.Count > 0 Then If Batch.First.InventoryJournalDetail.ItemID <> ItemID Then setError(CheckCell, "Batch '" & BatchID & "' already exists for item '" & Batch.First.InventoryJournalDetail.ItemID & "'")
                    End If
                End If
            End If
            If DGV_Items.Columns.Contains("Stock_Out_Days") Or DGV_Items.Columns.Contains("Qty_StockInhand") Or DGV_Items.Columns.Contains("Qty_Consumed") Then
                If DGV_Items.Columns(CheckCell.ColumnIndex).Equals(DGV_Items.Columns("Stock_Out_Days")) Or DGV_Items.Columns(CheckCell.ColumnIndex).Equals(DGV_Items.Columns("Qty_StockInhand")) Or DGV_Items.Columns(CheckCell.ColumnIndex).Equals(DGV_Items.Columns("Qty_Consumed")) Then
                    If CheckCell.Value IsNot Nothing Then If (Not IsNumeric(CheckCell.Value) Or Val(CheckCell.Value) < 0) Then setError(CheckCell, "Please Enter appropriate Number")
                End If
            End If
        End If
    End Sub

    Public Overridable Sub RowsAdd(ByVal FromRowIndex As Integer, ByVal ToRowIndex As Integer)
        For RowIndex = FromRowIndex To ToRowIndex
            If DGV_Items.Columns.Contains("Item_Name") Then DGV_Items.Rows(RowIndex).Cells("Item_Name") = New ComboCell(ComboCellTypes.Items)
            If DGV_Items.Columns.Contains("Batch") Then DGV_Items.Rows(RowIndex).Cells("Batch") = New ComboCell(ComboCellTypes.Batches)
            If DGV_Items.Columns.Contains("Batch_Location") Then DGV_Items.Rows(RowIndex).Cells("Batch_Location") = New ComboCell(ComboCellTypes.Locations)
            If DGV_Items.Columns.Contains("Expiry_Date") Then DGV_Items.Rows(RowIndex).Cells("Expiry_Date") = New CalendarCell()
        Next
    End Sub

    Public MustOverride Sub PopulateItems(ByVal IJID As String)

    Protected Overloads Sub setError(ByVal Cell As DataGridViewCell, ByVal ErrorText As String, ByRef NoError As Boolean)
        Cell.ErrorText = ErrorText
        Cell.Style.BackColor = Color.FromArgb(255, 200, 200)
        NoError = False
    End Sub
    Protected Overloads Sub setError(ByVal Cell As DataGridViewCell, ByVal ErrorText As String)
        Cell.ErrorText = ErrorText
        Cell.Style.BackColor = Color.FromArgb(255, 200, 200)
    End Sub
    Protected Overloads Sub setReadOnly(ByVal Cell As DataGridViewCell, ByRef DateValue As Boolean)
        If Not DateValue Then
            Cell.ReadOnly = True
            Cell.Style.BackColor = Color.FromArgb(200, 200, 200)
        Else
            Cell.ReadOnly = False
            Cell.Style.BackColor = Color.White
        End If
    End Sub

    Public Sub clearError(ByVal Cell As DataGridViewCell)
        Cell.ErrorText = ""
        If Cell.ReadOnly Then
            Cell.Style.BackColor = Color.FromArgb(200, 200, 200)
        Else
            Cell.Style.BackColor = Color.White
        End If


    End Sub

End Class

Public Class IJSupplyRequestEdit
    Inherits IJTransaction

    Sub New(ByVal DGV_Items As DGV_ItemsRef)
        MyBase.New(DGV_Items)
    End Sub

    Public Overrides Sub ItemChanged(ByVal rowIndex As Integer, ByVal Item As InventoryItem)
        MyBase.ItemChanged(rowIndex, Item)
        With DGV_Items.Rows(rowIndex)
            If Item IsNot Nothing Then
                .Cells("Qty_Available").Value = Utility.Get_ItemQty(Item.ID)
                .Cells("Qty_Consumed").Value = Utility.Get_ItemConsumedQty(Item.ID)
                .Cells("Cost").Value = Utility.Get_ItemCost(Item.ID)
                'MsgBox(.Cells("Qty_Available").Value)
                'If .Cells("Qty_Available").Value = 0 Then
                Dim ID As String = Item.ID
                Dim ZeroDate = From ZD In (New LMISEntities).VW_ItemZeroDate Where ZD.ItemID = Item.ID Select ZD
                If ZeroDate.Count > 0 And Val(.Cells("Qty_Available").Value) = 0 Then
                    .Cells("ZeroDate").Value = ZeroDate.First.ZeroDate
                Else
                    .Cells("ZeroDate").Value = ""
                End If
                'End If
            Else
                .Cells("Qty_Available").Value = ""
                .Cells("Qty_Consumed").Value = ""
            End If
        End With
    End Sub

    Public Overrides Sub BatchChanged(ByVal rowIndex As Integer, ByVal BatchID As String)
    End Sub

    Public Overrides Sub BatchLocationChanged(ByVal rowIndex As Integer, ByVal BatchLocation As IDNdata)
    End Sub

    Public Overrides Function ValidateData() As Boolean
        Return MyBase.ValidateData()
    End Function

    Public Overrides Sub ValidateCell(ByVal CheckCell As DataGridViewCell)
        MyBase.ValidateCell(CheckCell)
    End Sub

    Public Overrides Sub RowsAdd(ByVal FromRowIndex As Integer, ByVal ToRowIndex As Integer)
        For RowIndex = FromRowIndex To ToRowIndex
            DGV_Items.Rows(RowIndex).Cells("Item_Name") = New ComboCell(ComboCellTypes.Items)
        Next
    End Sub

    Public Overrides Sub PopulateItems(ByVal IJID As String)
        Try
            Dim LMISDb As New LMISEntities
            Dim RowCount As Integer = 0
            If clearRows Then
                DGV_Items.Rows.Clear()
            Else
                RowCount = DGV_Items.Rows.Count
            End If

            Dim Items = From R In LMISDb.Requests
                     Join IJ In LMISDb.InventoryJournals
                         On R.InventoryJournalID Equals IJ.ID
                     Join IJD In LMISDb.InventoryJournalDetails
                         On IJD.InventoryJournalID Equals IJ.ID
                     Join II In LMISDb.InventoryItems
                         On II.ID Equals IJD.ItemID
                     Where R.ID = IJID
                     Select II.ID, II.Name, IJD.Quantity, IJDID = IJD.ID, Unit = II.Unit.Name, IJD.Remark
                     Order By ID
            For Each RequestedItem In Items
                Dim ItemNew As Boolean = True
                If Not clearRows Then
                    For rowIndex = 0 To RowCount - 1 Step 1
                        If DGV_Items.Rows(rowIndex).Cells("ItemID").Value = RequestedItem.ID Then ItemNew = False
                    Next
                End If
                If ItemNew Then
                    With DGV_Items.Rows(DGV_Items.Rows.Add())
                        .Cells("ItemID").Value = RequestedItem.ID
                        .Cells("Item_Name").Value = RequestedItem.Name
                        .Cells("Cost").Value = Utility.Get_ItemCost(RequestedItem.ID)
                        .Cells("Qty_Available").Value = Utility.Get_ItemQty(RequestedItem.ID)
                        .Cells("Qty_Consumed").Value = Utility.Get_ItemConsumedQty(RequestedItem.ID)
                        .Cells("UOM").Value = RequestedItem.Unit
                        .Cells("Qty").Value = RequestedItem.Quantity
                        .Cells("Amount").Value = .Cells("Cost").Value * RequestedItem.Quantity
                        .Cells("Remark").Value = RequestedItem.Remark
                    End With
                End If
            Next
        Catch ex As Exception
            MessageBox.Show("Error: In Changing Items" & vbCrLf & ex.Message & Utility.InnerExecption(ex), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

End Class

Public Class IJSupplyReceive
    Inherits IJTransaction

    Sub New(ByVal DGV_Items As DGV_ItemsRef)
        MyBase.New(DGV_Items)
    End Sub

    Public Overrides Sub ItemChanged(ByVal rowIndex As Integer, ByVal Item As InventoryItem)
        MyBase.ItemChanged(rowIndex, Item)
        'If Item IsNot Nothing Then DGV_Items.Rows(rowIndex).Cells("Cost").Value = Utility.Get_ItemCost(Item.ID)
    End Sub

    Public Overrides Function ValidateData() As Boolean
        Dim NoError As Boolean = MyBase.ValidateData()
        For Each Row As DataGridViewRow In DGV_Items.Rows
            If Not Row.IsNewRow Then
                With Row
                    If .Cells("Batch").Value Is Nothing Then
                        setError(.Cells("Batch"), "'Batch' should not be empty", NoError)
                    ElseIf .Cells("Batch").ErrorText <> String.Empty Then
                        NoError = False
                    End If
                    If Not .Cells("Expiry_Date").ReadOnly Then
                        If .Cells("Expiry_Date").Value Is Nothing Then
                            setError(.Cells("Expiry_Date"), "'Expiry Date' should not be empty", NoError)
                        ElseIf .Cells("Expiry_Date").Value <= Date.Today Then
                            setError(.Cells("Expiry_Date"), "Batch Should not be expired", NoError)
                        ElseIf .Cells("Expiry_Date").ErrorText <> String.Empty Then
                            NoError = False
                        End If
                    End If
                    If .Cells("Batch_Location").Value Is Nothing Then
                        setError(.Cells("Batch_Location"), "'Batch Location' should not be empty", NoError)
                    ElseIf .Cells("Batch_Location").ErrorText <> String.Empty Then
                        NoError = False
                    End If
                    If Val(.Cells("Cost").Value) <= 0 Then
                        setError(.Cells("Cost"), "A proper 'Cost' should be entered", NoError)
                    ElseIf .Cells("Cost").ErrorText <> String.Empty Then
                        NoError = False
                    End If
                    If Val(.Cells("Amount").Value) <= 0 Then
                        setError(.Cells("Amount"), "A proper 'Total price' should be entered", NoError)
                    ElseIf .Cells("Amount").ErrorText <> String.Empty Then
                        NoError = False
                    End If
                End With
            End If
        Next
        Return NoError
    End Function

    Public Overrides Sub ValidateCell(ByVal CheckCell As DataGridViewCell)
        MyBase.ValidateCell(CheckCell)
    End Sub

    Public Overrides Sub PopulateItems(ByVal IJID As String)
        Try
            Dim LMISDb As New LMISEntities
            DGV_Items.Rows.Clear()
            Dim Items = From R In LMISDb.Requests
                     Join IJ In LMISDb.InventoryJournals
                         On R.InventoryJournalID Equals IJ.ID
                     Join IJD In LMISDb.InventoryJournalDetails
                         On IJD.InventoryJournalID Equals IJ.ID
                     Join II In LMISDb.InventoryItems
                         On II.ID Equals IJD.ItemID
                     Where R.ID = IJID
                     Select II.ID, II.Name, II.ItemsCatalogue.Expires, IJD.Quantity, IJDID = IJD.ID, Unit = II.Unit.Name, IJD.Remark
                     Order By ID
            For Each RequestedItem In Items
                With DGV_Items.Rows(DGV_Items.Rows.Add())
                    .Cells("ItemID").Value = RequestedItem.ID
                    .Cells("Item_Name").Value = RequestedItem.Name
                    .Cells("Qty_Requested").Value = RequestedItem.Quantity
                    .Cells("UOM").Value = RequestedItem.Unit
                    '.Cells("Cost").Value = Utility.Get_ItemCost(RequestedItem.ID)
                    .Cells("Amount").Value = .Cells("Cost").Value * RequestedItem.Quantity
                    .Cells("Remark").Value = RequestedItem.Remark
                    setReadOnly(.Cells("Expiry_Date"), RequestedItem.Expires)
                End With
            Next
        Catch ex As Exception
            MessageBox.Show("Error: In Changing Items" & vbCrLf & ex.Message & Utility.InnerExecption(ex), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

End Class

Public Class IJSupplyReceiveEdit
    Inherits IJTransaction

    Sub New(ByVal DGV_Items As DGV_ItemsRef)
        MyBase.New(DGV_Items)
    End Sub

    Public Overrides Sub ItemChanged(ByVal rowIndex As Integer, ByVal Item As InventoryItem)
        MyBase.ItemChanged(rowIndex, Item)
        'If Item IsNot Nothing Then DGV_Items.Rows(rowIndex).Cells("Cost").Value = Utility.Get_ItemCost(Item.ID)
    End Sub

    Public Overrides Function ValidateData() As Boolean
        Dim NoError As Boolean = MyBase.ValidateData()
        For Each Row As DataGridViewRow In DGV_Items.Rows
            If Not Row.IsNewRow Then
                With Row
                    If .Cells("Batch").Value Is Nothing Then
                        setError(.Cells("Batch"), "'Batch' should not be empty", NoError)
                    ElseIf .Cells("Batch").ErrorText <> String.Empty Then
                        NoError = False
                    End If
                    If Not .Cells("Expiry_Date").ReadOnly Then
                        If .Cells("Expiry_Date").Value Is Nothing Then
                            setError(.Cells("Expiry_Date"), "'Expiry Date' should not be empty", NoError)
                        ElseIf .Cells("Expiry_Date").Value.GetType() = GetType(Date) Then
                            If .Cells("Expiry_Date").Value <= Date.Today Then
                                setError(.Cells("Expiry_Date"), "Batch Should not be expired", NoError)
                            End If
                        ElseIf .Cells("Expiry_Date").Value.GetType() = GetType(String) Then
                            setError(.Cells("Expiry_Date"), "Please enter an appropriate Expiry Date", NoError)
                        ElseIf .Cells("Expiry_Date").ErrorText <> String.Empty Then
                            NoError = False
                        End If
                    End If
                    If .Cells("Batch_Location").Value Is Nothing Then
                        setError(.Cells("Batch_Location"), "'Batch Location' should not be empty", NoError)
                    ElseIf .Cells("Batch_Location").ErrorText <> String.Empty Then
                        NoError = False
                    End If
                    If Val(.Cells("Cost").Value) <= 0 Then
                        setError(.Cells("Cost"), "A proper 'Cost' should be entered", NoError)
                    ElseIf .Cells("Cost").ErrorText <> String.Empty Then
                        NoError = False
                    End If
                    If Val(.Cells("Amount").Value) <= 0 Then
                        setError(.Cells("Amount"), "A proper 'Total price' should be entered", NoError)
                    ElseIf .Cells("Amount").ErrorText <> String.Empty Then
                        NoError = False
                    End If
                End With
            End If
        Next
        Return NoError
    End Function

    Public Overrides Sub ValidateCell(ByVal CheckCell As DataGridViewCell)
        MyBase.ValidateCell(CheckCell)
        If Not DGV_Items.Rows(CheckCell.RowIndex).IsNewRow Then
            If DGV_Items.Columns(CheckCell.ColumnIndex).Equals(DGV_Items.Columns("Batch_Location")) Then
                If CheckCell.Value Is Nothing Then
                    setError(CheckCell, "'Batch Location' should not be empty")
                    BatchChanged(CheckCell.RowIndex, Nothing)
                End If
            End If
        End If
    End Sub

    Public Overrides Sub PopulateItems(ByVal IJID As String)
        Try
            Dim LMISDb As New LMISEntities
            DGV_Items.Rows.Clear()
            Dim ReceivedItems = From R In LMISDb.Recieves
                            Join IJ In LMISDb.InventoryJournals
                                On R.InventoryJournalID Equals IJ.ID
                            Join IJD In LMISDb.InventoryJournalDetails
                                On IJD.InventoryJournalID Equals IJ.ID
                            Join IJDB In LMISDb.InventoryJournalDetailsBatches
                                On IJD.ID Equals IJDB.InventoryJournaDetaillID
                            Join IB In LMISDb.InventoryBatches
                                On IB.ID Equals IJDB.InventoryBatchID
                             Join II In LMISDb.InventoryItems
                                On II.ID Equals IJD.ItemID
                            Where R.ID = IJID
                            Select II.ID, II.Name, II.ItemsCatalogue.Expires, IJD.Quantity, BatchNo = IB.ID, IJDB.Price, IJDID = IJD.ID, IJDB.LocationID, IB.ExpireDate, Unit = II.Unit.Name, IJD.Remark
                            Order By ID
            For Each ReceivedItem In ReceivedItems
                With DGV_Items.Rows(DGV_Items.Rows.Add())
                    .Cells("ItemID").Value = ReceivedItem.ID
                    .Cells("Item_Name").Value = ReceivedItem.Name
                    .Cells("Batch").Value = ReceivedItem.BatchNo
                    CType(.Cells("Batch_Location"), ComboCell).BatchLocationID = ReceivedItem.LocationID
                    .Cells("Batch_Location").Value = Utility.Get_StoreNLocationFromLID(ReceivedItem.LocationID).Data
                    If ReceivedItem.Expires Then .Cells("Expiry_Date").Value = ReceivedItem.ExpireDate
                    MessageBox.Show("ddddddddddd")
                    setReadOnly(.Cells("Expiry_Date"), ReceivedItem.Expires)
                    .Cells("Qty").Value = ReceivedItem.Quantity
                    .Cells("UOM").Value = ReceivedItem.Unit
                    .Cells("Amount").Value = ReceivedItem.Price * ReceivedItem.Quantity
                    .Cells("Cost").Value = ReceivedItem.Price
                    .Cells("Remark").Value = ReceivedItem.Remark
                End With
            Next


            Dim RequestedItems = From R In LMISDb.Requests
                     Join IJ In LMISDb.InventoryJournals
                         On R.InventoryJournalID Equals IJ.ID
                     Join Rec In LMISDb.Recieves
                         On R.ID Equals Rec.RequestID
                     Join IJD In LMISDb.InventoryJournalDetails
                         On IJD.InventoryJournalID Equals IJ.ID
                     Join II In LMISDb.InventoryItems
                         On II.ID Equals IJD.ItemID
                     Where Rec.ID = IJID
                     Select II.ID, II.Name, IJD.Quantity, IJDID = IJD.ID, Unit = II.Unit.Name, IJD.Remark
                     Order By ID
            Dim RowCount As Integer = DGV_Items.Rows.Count
            For Each RequisitionedItem In RequestedItems
                Dim ItemNew As Boolean = True
                For rowIndex = 0 To RowCount - 1 Step 1
                    If DGV_Items.Rows(rowIndex).Cells("ItemID").Value = RequisitionedItem.ID Then ItemNew = False
                Next
                If ItemNew Then
                    With DGV_Items.Rows(DGV_Items.Rows.Add())
                        .Cells("ItemID").Value = RequisitionedItem.ID
                        .Cells("Item_Name").Value = RequisitionedItem.Name
                        .Cells("UOM").Value = RequisitionedItem.Unit
                    End With
                End If
            Next
        Catch ex As Exception
            MessageBox.Show("Error: In Changing Items" & vbCrLf & ex.Message & Utility.InnerExecption(ex), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

End Class

Public Class IJFacilityRequestEdit
    Inherits IJTransaction

    Sub New(ByVal DGV_Items As DGV_ItemsRef)
        MyBase.New(DGV_Items)
    End Sub

    Public Overrides Sub ItemChanged(ByVal rowIndex As Integer, ByVal Item As InventoryItem)
        MyBase.ItemChanged(rowIndex, Item)
        With DGV_Items.Rows(rowIndex)
            If Item IsNot Nothing Then
                .Cells("Cost").Value = Utility.Get_ItemCost(Item.ID)
            End If
        End With
    End Sub

    Public Overrides Sub BatchChanged(ByVal rowIndex As Integer, ByVal BatchID As String)
    End Sub

    Public Overrides Sub BatchLocationChanged(ByVal rowIndex As Integer, ByVal BatchLocation As IDNdata)
    End Sub

    Public Overrides Function ValidateData() As Boolean
        Dim NoError As Boolean = MyBase.ValidateData()
        For Each Row As DataGridViewRow In DGV_Items.Rows
            If Not Row.IsNewRow Then
                With Row
                    If .Cells("Stock_Out_Days").Value IsNot Nothing Then
                        If (Not IsNumeric(.Cells("Stock_Out_Days").Value) Or Val(.Cells("Stock_Out_Days").Value) < 0) Then
                            setError(.Cells("Stock_Out_Days"), "Please Enter appropriate Number")
                            NoError = False
                        End If
                    End If
                    If .Cells("Qty_StockInhand").Value IsNot Nothing Then
                        If (Not IsNumeric(.Cells("Qty_StockInhand").Value) Or Val(.Cells("Qty_StockInhand").Value) < 0) Then
                            setError(.Cells("Qty_StockInhand"), "Please Enter appropriate Number")
                            NoError = False
                        End If
                    End If
                    If .Cells("Qty_Consumed").Value IsNot Nothing Then
                        If (Not IsNumeric(.Cells("Qty_Consumed").Value) Or Val(.Cells("Qty_Consumed").Value) < 0) Then
                            setError(.Cells("Qty_StockInhand"), "Please Enter appropriate Number")
                            NoError = False
                        End If
                    End If
                    If IsNumeric(.Cells("Stock_Out_Days").Value) And CType(DGV_Items.FindForm, FRM_IJFacilityRequestEdit).CMBX_Department.SelectedItem IsNot Nothing Then
                        Dim Depa As Department = CType(CType(DGV_Items.FindForm, FRM_IJFacilityRequestEdit).CMBX_Department.SelectedItem, Department)
                        If Depa.DepartmentType.RationDay.Days < .Cells("Stock_Out_Days").Value Then
                            setError(.Cells("Stock_Out_Days"), "Stock out days should not be more than maximum supply period for department '" & Depa.Name & "' which is '" & Depa.DepartmentType.RationDay.Days & "'")
                            NoError = False
                        End If
                    End If
                End With
            End If
        Next
        Return NoError
    End Function

    Public Overrides Sub ValidateCell(ByVal CheckCell As DataGridViewCell)
        MyBase.ValidateCell(CheckCell)
    End Sub

    Public Overrides Sub PopulateItems(ByVal IJID As String)
        Try
            Dim LMISDb As New LMISEntities
            Dim RowCount As Integer = 0
            If clearRows Then
                DGV_Items.Rows.Clear()
            Else
                RowCount = DGV_Items.Rows.Count
            End If
            Dim Items = From R In LMISDb.Requisitions
                        Join IJ In LMISDb.InventoryJournals
                            On R.InventoryJournalID Equals IJ.ID
                        Join IJD In LMISDb.InventoryJournalDetails
                            On IJD.InventoryJournalID Equals IJ.ID
                        Join II In LMISDb.InventoryItems
                            On II.ID Equals IJD.ItemID
                        Join C In LMISDb.ConsumedItems
                            On IJD.ID Equals C.InventoryJournalDetailID
                        Where (R.ID = IJID)
                        Select II.ID, II.Name, IJD.Quantity, IJDID = IJD.ID, Unit = II.Unit.Name, IJD.Remark, C.StockOnHand, C.StockOutDays, C.Consumption
                        Order By ID
            For Each RequisitionedItem In Items
                Dim ItemNew As Boolean = True
                If Not clearRows Then
                    For rowIndex = 0 To RowCount - 1 Step 1
                        If DGV_Items.Rows(rowIndex).Cells("ItemID").Value = RequisitionedItem.ID Then ItemNew = False
                    Next
                End If
                If ItemNew Then
                    With DGV_Items.Rows(DGV_Items.Rows.Add())
                        .Cells("ItemID").Value = RequisitionedItem.ID
                        .Cells("Item_Name").Value = RequisitionedItem.Name
                        .Cells("Qty").Value = RequisitionedItem.Quantity
                        .Cells("Stock_Out_Days").Value = RequisitionedItem.StockOutDays
                        .Cells("Qty_StockInhand").Value = RequisitionedItem.StockOnHand
                        .Cells("Qty_Consumed").Value = RequisitionedItem.Consumption
                        .Cells("UOM").Value = RequisitionedItem.Unit
                        .Cells("Cost").Value = Utility.Get_ItemCost(RequisitionedItem.ID)
                        .Cells("Amount").Value = .Cells("Cost").Value * RequisitionedItem.Quantity
                        .Cells("Remark").Value = RequisitionedItem.Remark
                    End With
                End If
            Next
        Catch ex As Exception
            MessageBox.Show("Error: In Changing Items" & vbCrLf & ex.Message & Utility.InnerExecption(ex), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

End Class

Public Class IJPreInvoice
    Inherits IJTransaction

    Sub New(ByVal DGV_Items As DGV_ItemsRef)
        MyBase.New(DGV_Items)
    End Sub

    Public Overrides Sub ItemChanged(ByVal rowIndex As Integer, ByVal Item As InventoryItem)
        MyBase.ItemChanged(rowIndex, Item)
        If Item IsNot Nothing Then
            DGV_Items.Rows(rowIndex).Cells("Cost").Value = Utility.Get_ItemCost(Item.ID)
            DGV_Items.Rows(rowIndex).Cells("Qty_Allavailable").Value = Utility.Get_ItemQtyPending(Item.ID)
            'DGV_Items.Rows(rowIndex).Cells("Adj_Consm").Value = String.Empty
        End If
    End Sub

    Public Overrides Sub BatchChanged(ByVal rowIndex As Integer, ByVal BatchID As String)
        MyBase.BatchChanged(rowIndex, BatchID)
        DGV_Items.Rows(rowIndex).Cells("Qty_Available").Value = ""
        DGV_Items.Rows(rowIndex).Cells("Cost").Value = Utility.Get_BatchSalesCost(BatchID)
    End Sub

    Public Overrides Sub BatchLocationChanged(ByVal rowIndex As Integer, ByVal BatchLocation As IDNdata)
        MyBase.BatchLocationChanged(rowIndex, BatchLocation)
        If BatchLocation IsNot Nothing Then
            DGV_Items.Rows(rowIndex).Cells("Qty_Available").Value = Utility.Get_ItemQtyInBatchLocationPending(DGV_Items.Rows(rowIndex).Cells("Batch").Value, BatchLocation.ID)
        Else
            DGV_Items.Rows(rowIndex).Cells("Qty_Available").Value = ""
        End If
    End Sub

    Public Overrides Function ValidateData() As Boolean
        Dim NoError As Boolean = MyBase.ValidateData()
        For Each Row As DataGridViewRow In DGV_Items.Rows
            If Not Row.IsNewRow Then
                With Row
                    If .Cells("Batch").Value Is Nothing Then
                        setError(.Cells("Batch"), "'Batch' should not be empty", NoError)
                    ElseIf .Cells("Batch").ErrorText <> String.Empty Then
                        NoError = False
                    End If
                    If Not .Cells("Expiry_Date").ReadOnly Then
                        If .Cells("Expiry_Date").Value Is Nothing Then
                            setError(.Cells("Expiry_Date"), "'Expiry Date' should not be empty", NoError)
                        ElseIf .Cells("Expiry_Date").Value.GetType() = GetType(Date) Then
                            If .Cells("Expiry_Date").Value <= Date.Today Then
                                setError(.Cells("Expiry_Date"), "Batch Should not be expired", NoError)
                            End If
                        ElseIf .Cells("Expiry_Date").Value.GetType() = GetType(String) Then
                            setError(.Cells("Expiry_Date"), "Please enter an appropriate Expiry Date", NoError)
                        ElseIf .Cells("Expiry_Date").ErrorText <> String.Empty Then
                            NoError = False
                        End If
                    End If
                    If .Cells("Batch_Location").Value Is Nothing Then
                        setError(.Cells("Batch_Location"), "'Batch Location' should not be empty", NoError)
                    ElseIf .Cells("Batch_Location").ErrorText <> String.Empty Then
                        NoError = False
                    End If
                    If .Cells("Qty").Value Is Nothing Then
                        setError(.Cells("Batch_Location"), "'Batch Location' should not be empty", NoError)
                    ElseIf .Cells("Batch_Location").ErrorText <> String.Empty Then
                        NoError = False
                    End If
                    If Val(.Cells("Qty").Value) > Val(.Cells("Qty_Available").Value) Then
                        setError(.Cells("Qty"), "'Qty Issued' should not be more than 'Qty Available", NoError)
                    ElseIf .Cells("Qty").ErrorText <> String.Empty Then
                        NoError = False
                    End If
                    If Val(.Cells("Cost").Value) <= 0 Then
                        setError(.Cells("Cost"), "A proper 'Cost' should be entered", NoError)
                    ElseIf .Cells("Cost").ErrorText <> String.Empty Then
                        NoError = False
                    End If
                End With
            End If
        Next
        Return NoError
    End Function

    Public Overrides Sub ValidateCell(ByVal CheckCell As DataGridViewCell)
        MyBase.ValidateCell(CheckCell)
        If Not DGV_Items.Rows(CheckCell.RowIndex).IsNewRow Then
            If DGV_Items.Columns(CheckCell.ColumnIndex).Equals(DGV_Items.Columns("Batch")) Then
                Dim BatchID As String = CheckCell.Value
                If (From B In (New LMISEntities).InventoryBatches Where B.ID = BatchID Select B).Count = 0 Then
                    setError(CheckCell, "'Batch' is not present in database")
                    BatchChanged(CheckCell.RowIndex, Nothing)
                End If
            ElseIf DGV_Items.Columns(CheckCell.ColumnIndex).Equals(DGV_Items.Columns("Batch_Location")) Then
                If CheckCell.Value Is Nothing Then
                    setError(CheckCell, "'Batch Location' should not be empty")
                    BatchLocationChanged(CheckCell.RowIndex, Nothing)
                End If
            ElseIf DGV_Items.Columns(CheckCell.ColumnIndex).Equals(DGV_Items.Columns("Qty")) Then
                If CheckCell.ErrorText = String.Empty Then
                    If Val(CheckCell.Value) > Val(DGV_Items.Rows(CheckCell.RowIndex).Cells("Qty_Available").Value) Then
                        setError(CheckCell, "'Qty Issued' should not be more than 'Qty Available")
                    End If
                End If
            End If
        End If
    End Sub

    Public Overrides Sub RowsAdd(ByVal FromRowIndex As Integer, ByVal ToRowIndex As Integer)
        For RowIndex = FromRowIndex To ToRowIndex
            If DGV_Items.Columns.Contains("Item_Name") Then DGV_Items.Rows(RowIndex).Cells("Item_Name") = New ComboCell(ComboCellTypes.Items)
            If DGV_Items.Columns.Contains("Batch") Then DGV_Items.Rows(RowIndex).Cells("Batch") = New ComboCell(ComboCellTypes.Batches)
            If DGV_Items.Columns.Contains("Batch_Location") Then DGV_Items.Rows(RowIndex).Cells("Batch_Location") = New ComboCell(ComboCellTypes.BatchLocations)
            If DGV_Items.Columns.Contains("Expiry_Date") Then DGV_Items.Rows(RowIndex).Cells("Expiry_Date") = New CalendarCell()
        Next
    End Sub

    Public Overrides Sub PopulateItems(ByVal IJID As String)
        Try
            Dim LMISDb As New LMISEntities
            DGV_Items.Rows.Clear()
            Dim Items = From R In LMISDb.Requisitions
                        Join IJ In LMISDb.InventoryJournals
                            On R.InventoryJournalID Equals IJ.ID
                        Join IJD In LMISDb.InventoryJournalDetails
                            On IJD.InventoryJournalID Equals IJ.ID
                        Join II In LMISDb.InventoryItems
                            On II.ID Equals IJD.ItemID
                        Join Consm In LMISDb.ConsumedItems
                            On IJD.ID Equals Consm.InventoryJournalDetailID
                        Where (R.ID = IJID)
                        Select II.ID, II.Name, II.ItemsCatalogue.Expires, IJD.Quantity, Unit = II.Unit.Name, IJD.Remark, Consm.Consumption, R.Department.DepartmentType.RationDay.Days, Consm.StockOutDays
                        Order By ID
            For Each RequestedItem In Items
                If Utility.Get_ItemQty(RequestedItem.ID) > 0 Then
                    With DGV_Items.Rows(DGV_Items.Rows.Add())
                        .Cells("ItemID").Value = RequestedItem.ID
                        .Cells("Item_Name").Value = RequestedItem.Name
                        .Cells("Qty_Requested").Value = RequestedItem.Quantity
                        .Cells("UOM").Value = RequestedItem.Unit
                        .Cells("Amount").Value = .Cells("Cost").Value * RequestedItem.Quantity
                        .Cells("Remark").Value = RequestedItem.Remark
                        .Cells("Qty_Allavailable").Value = Utility.Get_ItemQtyPending(RequestedItem.ID)
                        'setReadOnly(.Cells("Expiry_Date"), RequestedItem.Expires)
                        If Not RequestedItem.Days = RequestedItem.StockOutDays Then
                            .Cells("Adj_Consm").Value = RequestedItem.Days * RequestedItem.Consumption / (RequestedItem.Days - RequestedItem.StockOutDays)
                        Else
                            .Cells("Adj_Consm").Value = RequestedItem.Consumption
                        End If
                    End With
                End If
            Next
        Catch ex As Exception
            MessageBox.Show("Error: In Changing Items" & vbCrLf & ex.Message & Utility.InnerExecption(ex), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

End Class

Public Class IJInvoice
    Inherits IJTransaction

    Sub New(ByVal DGV_Items As DGV_ItemsRef)
        MyBase.New(DGV_Items)
    End Sub

    Public Overrides Sub ItemChanged(ByVal rowIndex As Integer, ByVal Item As InventoryItem)
        MyBase.ItemChanged(rowIndex, Item)
        'If Item IsNot Nothing Then DGV_Items.Rows(rowIndex).Cells("Cost").Value = Utility.Get_ItemCost(Item.ID)
        If Item IsNot Nothing Then DGV_Items.Rows(rowIndex).Cells("Qty_Allavailable").Value = Utility.Get_ItemQtyPending(Item.ID)
    End Sub

    Public Overrides Sub BatchChanged(ByVal rowIndex As Integer, ByVal BatchID As String)
        MyBase.BatchChanged(rowIndex, BatchID)
        DGV_Items.Rows(rowIndex).Cells("Qty_Available").Value = ""
        DGV_Items.Rows(rowIndex).Cells("Cost").Value = Utility.Get_BatchSalesCost(BatchID)
    End Sub

    Public Overrides Sub BatchLocationChanged(ByVal rowIndex As Integer, ByVal BatchLocation As IDNdata)
        MyBase.BatchLocationChanged(rowIndex, BatchLocation)
        If BatchLocation IsNot Nothing Then
            DGV_Items.Rows(rowIndex).Cells("Qty_Available").Value = Utility.Get_ItemQtyInBatchLocationPending(DGV_Items.Rows(rowIndex).Cells("Batch").Value, BatchLocation.ID)
        Else
            DGV_Items.Rows(rowIndex).Cells("Qty_Available").Value = ""
        End If
    End Sub

    Public Overrides Function ValidateData() As Boolean
        Dim NoError As Boolean = MyBase.ValidateData()
        For Each Row As DataGridViewRow In DGV_Items.Rows
            If Not Row.IsNewRow Then
                With Row
                    If .Cells("Batch").Value Is Nothing Then
                        setError(.Cells("Batch"), "'Batch' should not be empty", NoError)
                    ElseIf .Cells("Batch").ErrorText <> String.Empty Then
                        NoError = False
                    End If
                    If Not .Cells("Expiry_Date").ReadOnly Then
                        If .Cells("Expiry_Date").Value Is Nothing Then
                            setError(.Cells("Expiry_Date"), "'Expiry Date' should not be empty", NoError)
                        ElseIf .Cells("Expiry_Date").Value.GetType() = GetType(Date) Then
                            If .Cells("Expiry_Date").Value <= Date.Today Then
                                setError(.Cells("Expiry_Date"), "Batch Should not be expired", NoError)
                            End If
                        ElseIf .Cells("Expiry_Date").Value.GetType() = GetType(String) Then
                            setError(.Cells("Expiry_Date"), "Please enter an appropriate Expiry Date", NoError)
                        ElseIf .Cells("Expiry_Date").ErrorText <> String.Empty Then
                            NoError = False
                        End If
                    End If
                    If .Cells("Batch_Location").Value Is Nothing Then
                        setError(.Cells("Batch_Location"), "'Batch Location' should not be empty", NoError)
                    ElseIf .Cells("Batch_Location").ErrorText <> String.Empty Then
                        NoError = False
                    End If
                    If Val(.Cells("Qty").Value) > Val(.Cells("Qty_Available").Value) Then
                        setError(.Cells("Qty"), "'Qty Issued' should not be more than 'Qty Available", NoError)
                    ElseIf .Cells("Qty").ErrorText <> String.Empty Then
                        NoError = False
                    End If
                    If Val(.Cells("Cost").Value) <= 0 Then
                        setError(.Cells("Cost"), "A proper 'Cost' should be entered", NoError)
                    ElseIf .Cells("Cost").ErrorText <> String.Empty Then
                        NoError = False
                    End If
                End With
            End If
        Next
        Return NoError
    End Function

    Public Overrides Sub RowsAdd(ByVal FromRowIndex As Integer, ByVal ToRowIndex As Integer)
        For RowIndex = FromRowIndex To ToRowIndex
            If DGV_Items.Columns.Contains("Item_Name") Then DGV_Items.Rows(RowIndex).Cells("Item_Name") = New ComboCell(ComboCellTypes.Items)
            If DGV_Items.Columns.Contains("Batch") Then DGV_Items.Rows(RowIndex).Cells("Batch") = New ComboCell(ComboCellTypes.Batches)
            If DGV_Items.Columns.Contains("Batch_Location") Then DGV_Items.Rows(RowIndex).Cells("Batch_Location") = New ComboCell(ComboCellTypes.BatchLocations)
            If DGV_Items.Columns.Contains("Expiry_Date") Then DGV_Items.Rows(RowIndex).Cells("Expiry_Date") = New CalendarCell()
        Next
    End Sub

    Public Overrides Sub ValidateCell(ByVal CheckCell As DataGridViewCell)
        MyBase.ValidateCell(CheckCell)
        If Not DGV_Items.Rows(CheckCell.RowIndex).IsNewRow Then
            If DGV_Items.Columns(CheckCell.ColumnIndex).Equals(DGV_Items.Columns("Batch")) Then
                Dim BatchID As String = CheckCell.Value
                If (From B In (New LMISEntities).InventoryBatches Where B.ID = BatchID Select B).Count = 0 Then
                    setError(CheckCell, "'Batch' is not present in database")
                    BatchChanged(CheckCell.RowIndex, Nothing)
                End If
            ElseIf DGV_Items.Columns(CheckCell.ColumnIndex).Equals(DGV_Items.Columns("Batch_Location")) Then
                If CheckCell.Value Is Nothing Then
                    setError(CheckCell, "'Batch Location' should not be empty")
                    BatchLocationChanged(CheckCell.RowIndex, Nothing)
                End If
            ElseIf DGV_Items.Columns(CheckCell.ColumnIndex).Equals(DGV_Items.Columns("Qty")) Then
                If CheckCell.ErrorText = String.Empty Then
                    If Val(CheckCell.Value) > Val(DGV_Items.Rows(CheckCell.RowIndex).Cells("Qty_Available").Value) Then
                        setError(CheckCell, "'Qty Issued' should not be more than 'Qty Available")
                    End If
                End If
            End If
        End If
    End Sub

    Public Overrides Sub PopulateItems(ByVal IJID As String)
        Try
            Dim LMISDb As New LMISEntities
            DGV_Items.Rows.Clear()
            Dim IssuedItems = From R In LMISDb.Issues
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
                            Where R.ID = IJID And IJT.Name = "Pending"
                            Select II.ID, II.Name, II.ItemsCatalogue.Expires, IJD.Quantity, BatchNo = IJB.ID, IJDB.Price, IJDID = IJD.ID, IJB.ExpireDate, IJDB.LocationID, Unit = II.Unit.Name, IJD.Remark
                            Order By ID
            For Each IssuedItem In IssuedItems
                With DGV_Items.Rows(DGV_Items.Rows.Add())
                    .Cells("ItemID").Value = IssuedItem.ID
                    .Cells("Item_Name").Value = IssuedItem.Name
                    .Cells("Batch").Value = IssuedItem.BatchNo
                    If IssuedItem.Expires Then .Cells("Expiry_Date").Value = IssuedItem.ExpireDate
                    'setReadOnly(.Cells("Expiry_Date"), IssuedItem.Expires)
                    CType(.Cells("Batch_Location"), ComboCell).BatchLocationID = IssuedItem.LocationID
                    .Cells("Batch_Location").Value = Utility.Get_StoreNLocationFromLID(IssuedItem.LocationID)
                    .Cells("Qty_Available").Value = Utility.Get_ItemQtyInBatchLocation(IssuedItem.BatchNo, IssuedItem.LocationID)
                    .Cells("Qty").Value = IssuedItem.Quantity
                    .Cells("UOM").Value = IssuedItem.Unit
                    .Cells("Cost").Value = IssuedItem.Price
                    .Cells("Amount").Value = .Cells("Cost").Value * IssuedItem.Quantity
                    .Cells("Remark").Value = IssuedItem.Remark
                    .Cells("Qty_Allavailable").Value = Utility.Get_ItemQtyPending(IssuedItem.ID)
                    Dim ItemIDCon As String = IssuedItem.ID
                    Dim Consum = From R In LMISDb.Issues
                                    Join IJ In LMISDb.InventoryJournals
                                        On R.InventoryJournalID Equals IJ.ID
                                    Join IJD In LMISDb.InventoryJournalDetails
                                        On IJD.InventoryJournalID Equals IJ.ID
                                    Join Req In LMISDb.Requisitions
                                        On Req.ID Equals R.RequisitionID
                                    Join IJ2 In LMISDb.InventoryJournals
                                        On Req.InventoryJournalID Equals IJ2.ID
                                    Join IJD2 In LMISDb.InventoryJournalDetails
                                        On IJD2.InventoryJournalID Equals IJ2.ID
                                    Join Consm In LMISDb.ConsumedItems
                                        On IJD2.ID Equals Consm.InventoryJournalDetailID
                                    Join IJT In LMISDb.InventoryJournalStatus
                                        On IJ.InventoryJournalStatusID Equals IJT.ID
                                    Join IJDB In LMISDb.InventoryJournalDetailsBatches
                                        On IJD.ID Equals IJDB.InventoryJournaDetaillID
                                    Join IJB In LMISDb.InventoryBatches
                                        On IJB.ID Equals IJDB.InventoryBatchID
                                    Join II In LMISDb.InventoryItems
                                        On II.ID Equals IJD.ItemID
                                    Where R.ID = IJID And IJT.Name = "Pending" And IJD2.ItemID = ItemIDCon
                                    Select Consm.Consumption, Req.Department.DepartmentType.RationDay.Days, Consm.StockOutDays
                    If Consum.Count > 0 Then If Not Consum.First.Days = Consum.First.StockOutDays Then .Cells("Adj_Consm").Value = IIf(Consum.First.StockOutDays = 0, Consum.First.Consumption, Consum.First.Days * Consum.First.Consumption / (Consum.First.Days - Consum.First.StockOutDays))
                End With
            Next
            Dim RequestedItems = From R In LMISDb.Requisitions
                        Join IJ In LMISDb.InventoryJournals
                            On R.InventoryJournalID Equals IJ.ID
                        Join Iss In LMISDb.Issues
                            On R.ID Equals Iss.RequisitionID
                        Join IJD In LMISDb.InventoryJournalDetails
                            On IJD.InventoryJournalID Equals IJ.ID
                        Join II In LMISDb.InventoryItems
                            On II.ID Equals IJD.ItemID
                        Join C In LMISDb.ConsumedItems
                            On IJD.ID Equals C.InventoryJournalDetailID
                        Where (Iss.ID = IJID)
                        Select II.ID, II.Name, IJD.Quantity, IJDID = IJD.ID, Unit = II.Unit.Name, IJD.Remark, C.StockOnHand, C.StockOutDays, C.Consumption
                        Order By ID
            Dim RowCount As Integer = DGV_Items.Rows.Count
            For Each RequisitionedItem In RequestedItems
                Dim ItemNew As Boolean = True
                For rowIndex = 0 To RowCount - 1 Step 1
                    If DGV_Items.Rows(rowIndex).Cells("ItemID").Value = RequisitionedItem.ID Then ItemNew = False
                Next
                If ItemNew Then
                    With DGV_Items.Rows(DGV_Items.Rows.Add())
                        .Cells("ItemID").Value = RequisitionedItem.ID
                        .Cells("Item_Name").Value = RequisitionedItem.Name
                        .Cells("UOM").Value = RequisitionedItem.Unit
                    End With
                End If
            Next
        Catch ex As Exception
            MessageBox.Show("Error: In Changing Items" & vbCrLf & ex.Message & Utility.InnerExecption(ex), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

End Class

Public Class IJOPDEdit
    Inherits IJTransaction

    Sub New(ByVal DGV_Items As DGV_ItemsRef)
        MyBase.New(DGV_Items)
    End Sub

    Public Overrides Sub ItemChanged(ByVal rowIndex As Integer, ByVal Item As InventoryItem)
        MyBase.ItemChanged(rowIndex, Item)
        If Item IsNot Nothing Then DGV_Items.Rows(rowIndex).Cells("Cost").Value = Utility.Get_ItemCost(Item.ID)
    End Sub

    Public Overrides Sub BatchChanged(ByVal rowIndex As Integer, ByVal BatchID As String)
        MyBase.BatchChanged(rowIndex, BatchID)
        DGV_Items.Rows(rowIndex).Cells("Qty_Available").Value = ""
        Dim BatchLocs = Utility.Get_BatchLocations(BatchID)
        'automate batchlocation change
        If BatchLocs IsNot Nothing Then
            If BatchLocs.Count = 0 Or BatchLocs.Count > 1 Then
                Throw New Exception("Since your Facility is registered as a Satellite(IPD), you are not allowed to have more than one location")
            Else
                CType(DGV_Items.Rows(rowIndex).Cells("Batch_Location"), ComboCell).BatchLocationID = BatchLocs.First.ID
                DGV_Items.Rows(rowIndex).Cells("Qty_Available").Value = Utility.Get_ItemQtyInBatchLocation(BatchID, BatchLocs.First.ID)
            End If
        End If
    End Sub

    Public Overrides Sub BatchLocationChanged(ByVal rowIndex As Integer, ByVal BatchLocation As IDNdata)
        MyBase.BatchLocationChanged(rowIndex, BatchLocation)
        If BatchLocation IsNot Nothing Then
            DGV_Items.Rows(rowIndex).Cells("Qty_Available").Value = Utility.Get_ItemQtyInBatchLocation(DGV_Items.Rows(rowIndex).Cells("Batch").Value, BatchLocation.ID)
        Else
            DGV_Items.Rows(rowIndex).Cells("Qty_Available").Value = ""
        End If
    End Sub

    Public Overrides Function ValidateData() As Boolean
        Dim NoError As Boolean = MyBase.ValidateData()
        For Each Row As DataGridViewRow In DGV_Items.Rows
            If Not Row.IsNewRow Then
                With Row
                    If .Cells("Batch").Value Is Nothing Then
                        setError(.Cells("Batch"), "'Batch' should not be empty", NoError)
                    ElseIf .Cells("Batch").ErrorText <> String.Empty Then
                        NoError = False
                    End If
                    If Not .Cells("Expiry_Date").ReadOnly Then
                        If .Cells("Expiry_Date").Value Is Nothing Then
                            setError(.Cells("Expiry_Date"), "'Expiry Date' should not be empty", NoError)
                        ElseIf .Cells("Expiry_Date").Value <= Date.Today Then
                            setError(.Cells("Expiry_Date"), "Batch Should not be expired", NoError)
                        ElseIf .Cells("Expiry_Date").ErrorText <> String.Empty Then
                            NoError = False
                        End If
                    End If
                    If .Cells("Batch_Location").Value Is Nothing Then
                        setError(.Cells("Batch_Location"), "'Batch Location' should not be empty", NoError)
                    ElseIf .Cells("Batch_Location").ErrorText <> String.Empty Then
                        NoError = False
                    End If
                    If Val(.Cells("Qty").Value) > Val(.Cells("Qty_Available").Value) Then
                        setError(.Cells("Qty"), "'Qty Issued' should not be more than 'Qty Available", NoError)
                    ElseIf .Cells("Qty").ErrorText <> String.Empty Then
                        NoError = False
                    End If
                    If Val(.Cells("Cost").Value) <= 0 Then
                        setError(.Cells("Cost"), "A proper 'Cost' should be entered", NoError)
                    ElseIf .Cells("Cost").ErrorText <> String.Empty Then
                        NoError = False
                    End If
                End With
            End If
        Next
        Return NoError
    End Function

    Public Overrides Sub ValidateCell(ByVal CheckCell As DataGridViewCell)
        MyBase.ValidateCell(CheckCell)
        If Not DGV_Items.Rows(CheckCell.RowIndex).IsNewRow Then
            If DGV_Items.Columns(CheckCell.ColumnIndex).Equals(DGV_Items.Columns("Batch")) Then
                Dim BatchID As String = CheckCell.Value
                If (From B In (New LMISEntities).InventoryBatches Where B.ID = BatchID Select B).Count = 0 Then
                    setError(CheckCell, "'Batch' is not present in database")
                    BatchChanged(CheckCell.RowIndex, Nothing)
                End If
            ElseIf DGV_Items.Columns(CheckCell.ColumnIndex).Equals(DGV_Items.Columns("Batch_Location")) Then
                If CheckCell.Value Is Nothing Then
                    setError(CheckCell, "'Batch Location' should not be empty")
                    BatchLocationChanged(CheckCell.RowIndex, Nothing)
                End If
            ElseIf DGV_Items.Columns(CheckCell.ColumnIndex).Equals(DGV_Items.Columns("Qty")) Then
                If CheckCell.ErrorText = String.Empty Then
                    If Val(CheckCell.Value) > Val(DGV_Items.Rows(CheckCell.RowIndex).Cells("Qty_Available").Value) Then
                        setError(CheckCell, "'Qty Issued' should not be more than 'Qty Available")
                    End If
                End If
            End If
        End If
    End Sub

    Public Overrides Sub RowsAdd(ByVal FromRowIndex As Integer, ByVal ToRowIndex As Integer)
        For RowIndex = FromRowIndex To ToRowIndex
            If DGV_Items.Columns.Contains("Item_Name") Then DGV_Items.Rows(RowIndex).Cells("Item_Name") = New ComboCell(ComboCellTypes.Items)
            If DGV_Items.Columns.Contains("Batch") Then DGV_Items.Rows(RowIndex).Cells("Batch") = New ComboCell(ComboCellTypes.Batches)
            If DGV_Items.Columns.Contains("Batch_Location") Then DGV_Items.Rows(RowIndex).Cells("Batch_Location") = New ComboCell(ComboCellTypes.BatchLocations)
            If DGV_Items.Columns.Contains("Expiry_Date") Then DGV_Items.Rows(RowIndex).Cells("Expiry_Date") = New CalendarCell()
        Next
    End Sub

    Public Overrides Sub PopulateItems(ByVal IJID As String)
        Try
            Dim LMISDb As New LMISEntities
            DGV_Items.Rows.Clear()
            Dim OPDIssuedItems = From R In LMISDb.OPDRequisitions
                            Join IJ In LMISDb.InventoryJournals
                                On R.InvetoryJournalID Equals IJ.ID
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
                            Where R.ID = IJID
                            Select II.ID, II.Name, II.ItemsCatalogue.Expires, IJD.Quantity, BatchNo = IJB.ID, IJDB.Price, IJDID = IJD.ID, IJB.ExpireDate, IJDB.LocationID, Unit = II.Unit.Name, IJD.Remark
                            Order By ID
            For Each OPDIssuedItem In OPDIssuedItems
                Dim Index As Integer = DGV_Items.Rows.Add()
                With DGV_Items.Rows(Index)
                    .Cells("ItemID").Value = OPDIssuedItem.ID
                    .Cells("Item_Name").Value = OPDIssuedItem.Name
                    .Cells("Batch").Value = OPDIssuedItem.BatchNo
                    If OPDIssuedItem.Expires Then .Cells("Expiry_Date").Value = OPDIssuedItem.ExpireDate
                    setReadOnly(.Cells("Expiry_Date"), OPDIssuedItem.Expires)
                    CType(.Cells("Batch_Location"), ComboCell).BatchLocationID = OPDIssuedItem.LocationID
                    .Cells("Batch_Location").Value = Utility.Get_StoreNLocationFromLID(OPDIssuedItem.LocationID)
                    .Cells("Qty_Available").Value = Utility.Get_ItemQtyInBatchLocation(OPDIssuedItem.BatchNo, OPDIssuedItem.LocationID)
                    .Cells("Qty").Value = OPDIssuedItem.Quantity
                    .Cells("UOM").Value = OPDIssuedItem.Unit
                    .Cells("Cost").Value = OPDIssuedItem.Price
                    .Cells("Amount").Value = .Cells("Cost").Value * OPDIssuedItem.Quantity
                    .Cells("Remark").Value = OPDIssuedItem.Remark
                End With
            Next
        Catch ex As Exception
            MessageBox.Show("Error: In Changing Items" & vbCrLf & ex.Message & Utility.InnerExecption(ex), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

End Class

Public Class IJIPDEdit
    Inherits IJTransaction

    Sub New(ByVal DGV_Items As DGV_ItemsRef)
        MyBase.New(DGV_Items)
    End Sub

    Public Overrides Sub ItemChanged(ByVal rowIndex As Integer, ByVal Item As InventoryItem)
        MyBase.ItemChanged(rowIndex, Item)
        If Item IsNot Nothing Then DGV_Items.Rows(rowIndex).Cells("Cost").Value = Utility.Get_ItemCost(Item.ID)
    End Sub

    Public Overrides Sub BatchChanged(ByVal rowIndex As Integer, ByVal BatchID As String)
        Try
            MyBase.BatchChanged(rowIndex, BatchID)
            DGV_Items.Rows(rowIndex).Cells("Qty_Available").Value = ""
            Dim BatchLocs = Utility.Get_BatchLocations(BatchID)
            'automate batchlocation change
            If BatchLocs IsNot Nothing Then
                If BatchLocs.Count = 0 Or BatchLocs.Count > 1 Then
                    Throw New Exception("Since your Facility is registered as a Satellite(IPD), you are not allowed to have more than one location")
                Else
                    CType(DGV_Items.Rows(rowIndex).Cells("Batch_Location"), ComboCell).BatchLocationID = BatchLocs.First.ID
                    DGV_Items.Rows(rowIndex).Cells("Qty_Available").Value = Utility.Get_ItemQtyInBatchLocation(BatchID, BatchLocs.First.ID)
                End If
            End If
        Catch ex As Exception
            MessageBox.Show("Error: In Changing Items" & vbCrLf & ex.Message & Utility.InnerExecption(ex), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Public Overrides Sub BatchLocationChanged(ByVal rowIndex As Integer, ByVal BatchLocation As IDNdata)
        MyBase.BatchLocationChanged(rowIndex, BatchLocation)
        If BatchLocation IsNot Nothing Then
            DGV_Items.Rows(rowIndex).Cells("Qty_Available").Value = Utility.Get_ItemQtyInBatchLocation(DGV_Items.Rows(rowIndex).Cells("Batch").Value, BatchLocation.ID)
        Else
            DGV_Items.Rows(rowIndex).Cells("Qty_Available").Value = ""
        End If
    End Sub

    Public Overrides Function ValidateData() As Boolean
        Dim NoError As Boolean = MyBase.ValidateData()
        For Each Row As DataGridViewRow In DGV_Items.Rows
            If Not Row.IsNewRow Then
                With Row
                    If .Cells("Batch").Value Is Nothing Then
                        setError(.Cells("Batch"), "'Batch' should not be empty", NoError)
                    ElseIf .Cells("Batch").ErrorText <> String.Empty Then
                        NoError = False
                    End If
                    If Not .Cells("Expiry_Date").ReadOnly Then
                        If .Cells("Expiry_Date").Value Is Nothing Then
                            setError(.Cells("Expiry_Date"), "'Expiry Date' should not be empty", NoError)
                        ElseIf .Cells("Expiry_Date").Value <= Date.Today Then
                            setError(.Cells("Expiry_Date"), "Batch Should not be expired", NoError)
                        ElseIf .Cells("Expiry_Date").ErrorText <> String.Empty Then
                            NoError = False
                        End If
                    End If
                    If .Cells("Batch_Location").Value Is Nothing Then
                        setError(.Cells("Batch_Location"), "'Batch Location' should not be empty", NoError)
                    ElseIf .Cells("Batch_Location").ErrorText <> String.Empty Then
                        NoError = False
                    End If
                    If Val(.Cells("Qty").Value) > Val(.Cells("Qty_Available").Value) Then
                        setError(.Cells("Qty"), "'Qty Issued' should not be more than 'Qty Available", NoError)
                    ElseIf .Cells("Qty").ErrorText <> String.Empty Then
                        NoError = False
                    End If
                    If Val(.Cells("Cost").Value) <= 0 Then
                        setError(.Cells("Cost"), "A proper 'Cost' should be entered", NoError)
                    ElseIf .Cells("Cost").ErrorText <> String.Empty Then
                        NoError = False
                    End If
                    'If CType(.Cells("AdministeredBy"), ComboCellGeneral).SelectedValue Is Nothing Then
                    '    setError(.Cells("AdministeredBy"), "'Administered By' should not be empty")
                    '    NoError = False
                    'ElseIf .Cells("Ad   ministeredBy").ErrorText <> String.Empty Then
                    '    NoError = False
                    'End If
                    'If CType(.Cells("OrderedBy"), ComboCellGeneral).SelectedValue Is Nothing Then
                    '    setError(.Cells("OrderedBy"), "'Ordered By' should not be empty")
                    '    NoError = False
                    'ElseIf .Cells("OrderedBy").ErrorText <> String.Empty Then
                    '    NoError = False
                    'End If
                    'If .Cells("EntryDate").Value Is Nothing Then
                    '    setError(.Cells("EntryDate"), "'Date' should not be empty")
                    '    NoError = False
                    'ElseIf .Cells("EntryDate").ErrorText <> String.Empty Then
                    '    NoError = False
                    'End If
                End With
            End If
        Next
        Return NoError
    End Function

    Public Overrides Sub ValidateCell(ByVal CheckCell As DataGridViewCell)
        MyBase.ValidateCell(CheckCell)
        If Not DGV_Items.Rows(CheckCell.RowIndex).IsNewRow Then
            If DGV_Items.Columns(CheckCell.ColumnIndex).Equals(DGV_Items.Columns("Batch")) Then
                Dim BatchID As String = CheckCell.Value
                If (From B In (New LMISEntities).InventoryBatches Where B.ID = BatchID Select B).Count = 0 Then
                    setError(CheckCell, "'Batch' is not present in database")
                    BatchChanged(CheckCell.RowIndex, Nothing)
                End If
            ElseIf DGV_Items.Columns(CheckCell.ColumnIndex).Equals(DGV_Items.Columns("Batch_Location")) Then
                If CheckCell.Value Is Nothing Then
                    setError(CheckCell, "'Batch Location' should not be empty")
                    BatchLocationChanged(CheckCell.RowIndex, Nothing)
                End If
            ElseIf DGV_Items.Columns(CheckCell.ColumnIndex).Equals(DGV_Items.Columns("Qty")) Then
                If CheckCell.ErrorText = String.Empty Then
                    If Val(CheckCell.Value) > Val(DGV_Items.Rows(CheckCell.RowIndex).Cells("Qty_Available").Value) Then
                        setError(CheckCell, "'Qty Issued' should not be more than 'Qty Available")
                    End If
                End If
            End If
        End If
    End Sub

    Public Overrides Sub RowsAdd(ByVal FromRowIndex As Integer, ByVal ToRowIndex As Integer)
        For RowIndex = FromRowIndex To ToRowIndex
            DGV_Items.Rows(RowIndex).Cells("Item_Name") = New ComboCell(ComboCellTypes.Items)
            DGV_Items.Rows(RowIndex).Cells("Batch") = New ComboCell(ComboCellTypes.Batches)
            DGV_Items.Rows(RowIndex).Cells("OrderedBy") = New ComboCellGeneral(DGV_ComboCellTypes.Employee)
            DGV_Items.Rows(RowIndex).Cells("AdministeredBy") = New ComboCellGeneral(DGV_ComboCellTypes.Employee)
            DGV_Items.Rows(RowIndex).Cells("Batch_Location") = New ComboCell(ComboCellTypes.BatchLocations)
            DGV_Items.Rows(RowIndex).Cells("Expiry_Date") = New CalendarCell()
            If DGV_Items.Columns.Contains("EntryDate") Then DGV_Items.Rows(RowIndex).Cells("EntryDate") = New CalendarCell()
        Next
    End Sub

    Public Overrides Sub PopulateItems(ByVal IJID As String)
        Try
            Dim LMISDb As New LMISEntities
            DGV_Items.Rows.Clear()
            'Dim IPDIssuedItems = From R In LMISDb.IPDRequisitions
            '                Join IJ In LMISDb.InventoryJournals
            '                    On R.InventoryJournalID Equals IJ.ID
            '                Join IJD In LMISDb.InventoryJournalDetails
            '                    On IJD.InventoryJournalID Equals IJ.ID
            '                Join IJT In LMISDb.InventoryJournalStatus
            '                    On IJ.InventoryJournalStatusID Equals IJT.ID
            '                Join IJDB In LMISDb.InventoryJournalDetailsBatches
            '                    On IJD.ID Equals IJDB.InventoryJournaDetaillID
            '                Join IJB In LMISDb.InventoryBatches
            '                    On IJB.ID Equals IJDB.InventoryBatchID
            '                Join II In LMISDb.InventoryItems
            '                    On II.ID Equals IJD.ItemID
            '                Join ONA In LMISDb.OrderandAdministers
            '                    On IJD.ID Equals ONA.InventoryJournalDetailID
            '                Where R.ID = IJID
            '                Select II.ID, II.Name, IJD.Quantity, BatchNo = IJB.ID, IJDB.Price, IJDID = IJD.ID, IJB.ExpireDate, IJDB.LocationID, Unit = II.Unit.Name, IJD.Remark, ONA.AdministereBy, ONA.OrderedBy, F1 = ONA.Employee.Person.PersonName.Name, M1 = ONA.Employee.Person.PersonName1.Name, L1 = ONA.Employee.Person.PersonName2.Name, I1 = ONA.Employee.Person.IDNO, P1 = ONA.Employee.Person.PhoneNo, F2 = ONA.Employee1.Person.PersonName.Name, M2 = ONA.Employee1.Person.PersonName2.Name, L2 = ONA.Employee1.Person.PersonName2.Name, I2 = ONA.Employee1.Person.IDNO, P2 = ONA.Employee1.Person.PhoneNo, ONA.Date
            '                Order By ID
            Dim IPDIssuedItems = From R In LMISDb.IPDRequisitions
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
                            Where R.ID = IJID
                            Select II.ID, II.Name, II.ItemsCatalogue.Expires, IJD.Quantity, BatchNo = IJB.ID, IJDB.Price, IJDID = IJD.ID, IJB.ExpireDate, IJDB.LocationID, Unit = II.Unit.Name, IJD.Remark
                            Order By ID
            For Each IPDIssuedItem In IPDIssuedItems
                Dim Index As Integer = DGV_Items.Rows.Add()
                With DGV_Items.Rows(Index)
                    .Cells("ItemID").Value = IPDIssuedItem.ID
                    .Cells("Item_Name").Value = IPDIssuedItem.Name
                    .Cells("Batch").Value = IPDIssuedItem.BatchNo
                    If IPDIssuedItem.Expires Then .Cells("Expiry_Date").Value = IPDIssuedItem.ExpireDate
                    setReadOnly(.Cells("Expiry_Date"), IPDIssuedItem.Expires)
                    CType(.Cells("Batch_Location"), ComboCell).BatchLocationID = IPDIssuedItem.LocationID
                    Dim IJDID As String = IPDIssuedItem.IJDID
                    Dim ONA = From OA In LMISDb.OrderandAdministers Where OA.InventoryJournalDetailID = IJDID Select OA
                    If (ONA.Count = 1) Then
                        Dim LastName As String = ""
                        If ONA.First.Employee.Person.PersonName2 IsNot Nothing Then LastName = ONA.First.Employee.Person.PersonName2.Name
                        CType(.Cells("OrderedBy"), ComboCellGeneral).SelectedValue = ONA.First.OrderedBy
                        .Cells("OrderedBy").Value = ONA.First.Employee.Person.PersonName.Name & " " & ONA.First.Employee.Person.PersonName1.Name & " " & LastName & " " & ONA.First.Employee.Person.IDNO & ", " & ONA.First.Employee.Person.PhoneNo
                    End If
                    'CType(.Cells("OrderedBy"), ComboCellGeneral).SelectedValue = IPDIssuedItem.OrderedBy
                    '.Cells("OrderedBy").Value = IPDIssuedItem.F1 & " " & IPDIssuedItem.M1 & " " & IPDIssuedItem.L1 & " " & IPDIssuedItem.I1 & ", " & IPDIssuedItem.P1
                    'CType(.Cells("AdministeredBy"), ComboCellGeneral).SelectedValue = IPDIssuedItem.AdministereBy
                    '.Cells("AdministeredBy").Value = IPDIssuedItem.F2 & " " & IPDIssuedItem.M2 & " " & IPDIssuedItem.L2 & " " & IPDIssuedItem.I2 & ", " & IPDIssuedItem.P2
                    '.Cells("EntryDate").Value = IPDIssuedItem.Date
                    .Cells("Batch_Location").Value = Utility.Get_StoreNLocationFromLID(IPDIssuedItem.LocationID)
                    .Cells("Qty_Available").Value = Utility.Get_ItemQtyInBatchLocation(IPDIssuedItem.BatchNo, IPDIssuedItem.LocationID)
                    .Cells("Qty").Value = IPDIssuedItem.Quantity
                    .Cells("UOM").Value = IPDIssuedItem.Unit
                    .Cells("Cost").Value = IPDIssuedItem.Price
                    .Cells("Amount").Value = .Cells("Cost").Value * IPDIssuedItem.Quantity
                    .Cells("Remark").Value = IPDIssuedItem.Remark
                End With
            Next
        Catch ex As Exception
            MessageBox.Show("Error: In Changing Items" & vbCrLf & ex.Message & Utility.InnerExecption(ex), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

End Class

Public Class IJAdjustment
    Inherits IJTransaction

    Sub New(ByVal DGV_Items As DGV_ItemsRef)
        MyBase.New(DGV_Items)
    End Sub

    Public Overrides Sub ItemChanged(ByVal rowIndex As Integer, ByVal Item As InventoryItem)
        MyBase.ItemChanged(rowIndex, Item)
        With DGV_Items.Rows(rowIndex)
            If Item IsNot Nothing Then
                .Cells("Qty_Available").Value = Utility.Get_ItemQty(Item.ID)
                '.Cells("Cost").Value = Utility.Get_ItemCost(Item.ID)
            Else
                .Cells("Qty_Available").Value = ""
            End If
        End With
    End Sub

    Public Overrides Sub BatchChanged(ByVal rowIndex As Integer, ByVal BatchID As String)
        MyBase.BatchChanged(rowIndex, BatchID)
        DGV_Items.Rows(rowIndex).Cells("Qty_Available").Value = ""
        DGV_Items.Rows(rowIndex).Cells("Cost").Value = Utility.Get_BatchPriceCost(BatchID)
    End Sub

    Public Overrides Sub BatchLocationChanged(ByVal rowIndex As Integer, ByVal BatchLocation As IDNdata)
        MyBase.BatchLocationChanged(rowIndex, BatchLocation)
        If BatchLocation IsNot Nothing Then
            DGV_Items.Rows(rowIndex).Cells("Qty_Available").Value = Utility.Get_ItemQtyInBatchLocation(DGV_Items.Rows(rowIndex).Cells("Batch").Value, BatchLocation.ID)
        Else
            DGV_Items.Rows(rowIndex).Cells("Qty_Available").Value = ""
        End If
    End Sub

    Public Overrides Function ValidateData() As Boolean
        Dim NoError As Boolean = MyBase.ValidateData()
        For Each Row As DataGridViewRow In DGV_Items.Rows
            If Not Row.IsNewRow Then
                With Row
                    If .Cells("Batch").Value Is Nothing Then
                        setError(.Cells("Batch"), "'Batch' should not be empty", NoError)
                    ElseIf .Cells("Batch").ErrorText <> String.Empty Then
                        NoError = False
                    End If
                    If Not .Cells("Expiry_Date").ReadOnly Then
                        If .Cells("Expiry_Date").Value Is Nothing Then
                            setError(.Cells("Expiry_Date"), "'Expiry Date' should not be empty", NoError)
                            ' ElseIf .Cells("Expiry_Date").Value <= Date.Today Then
                            '    setError(.Cells("Expiry_Date"), "Batch Should not be expired", NoError)
                        ElseIf .Cells("Expiry_Date").ErrorText <> String.Empty Then

                            NoError = False
                        End If
                        If .Cells("Expiry_Date").Value > Today Then
                            MsgBox("The Item hasn't expired yet!")
                        End If
                    End If
                    If .Cells("Batch_Location").Value Is Nothing Then
                        setError(.Cells("Batch_Location"), "'Batch Location' should not be empty", NoError)
                    ElseIf .Cells("Batch_Location").ErrorText <> String.Empty Then
                        NoError = False
                    End If
                    If (CType(DGV_Items.FindForm, FRM_IJAdjustment).FRMAdjMode = FRMAdjModes.Decrease Or CType(DGV_Items.FindForm, FRM_IJAdjustment).FRMAdjMode = FRMAdjModes.Discard) And Val(.Cells("Qty").Value) > Val(.Cells("Qty_Available").Value) Then
                        setError(.Cells("Qty"), "'Qty Issued' should not be more than 'Qty Available", NoError)
                    ElseIf .Cells("Qty").ErrorText <> String.Empty Then
                        NoError = False
                    End If
                    If Val(.Cells("Cost").Value) <= 0 Then
                        setError(.Cells("Cost"), "A proper 'Cost' should be entered", NoError)
                    ElseIf .Cells("Cost").ErrorText <> String.Empty Then
                        NoError = False
                    End If

                End With
            End If
        Next
        Return NoError
    End Function

    Public Overrides Sub ValidateCell(ByVal CheckCell As DataGridViewCell)
        MyBase.ValidateCell(CheckCell)
        If Not DGV_Items.Rows(CheckCell.RowIndex).IsNewRow Then
            If DGV_Items.Columns(CheckCell.ColumnIndex).Equals(DGV_Items.Columns("Batch")) Then
                'Dim BatchID As String = CheckCell.Value
                'If (From B In (New LMISEntities).InventoryBatches Where B.ID = BatchID Select B).Count = 0 Then
                '    setError(CheckCell, "'Batch' is not present in database")
                '    BatchChanged(CheckCell.RowIndex, Nothing)
                'End If
            ElseIf DGV_Items.Columns(CheckCell.ColumnIndex).Equals(DGV_Items.Columns("Batch_Location")) Then
                If CheckCell.Value Is Nothing Then
                    setError(CheckCell, "'Batch Location' should not be empty")
                    BatchLocationChanged(CheckCell.RowIndex, Nothing)
                End If
            End If
        End If
    End Sub

    Public Overrides Sub PopulateItems(ByVal IJID As String)
        Try
            Dim LMISDb As New LMISEntities
            DGV_Items.Rows.Clear()
            Dim AdjustedItems = From R In LMISDb.Adjustments
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
                            Where R.ID = IJID
                            Select II.ID, II.Name, II.ItemsCatalogue.Expires, IJD.Quantity, BatchNo = IJB.ID, IJDB.Price, IJDID = IJD.ID, IJB.ExpireDate, IJDB.LocationID, Unit = II.Unit.Name, IJD.Remark
                            Order By ID
            For Each AdjustedItem In AdjustedItems
                With DGV_Items.Rows(DGV_Items.Rows.Add())
                    .Cells("ItemID").Value = AdjustedItem.ID
                    .Cells("Item_Name").Value = AdjustedItem.Name
                    .Cells("Batch").Value = AdjustedItem.BatchNo
                    If AdjustedItem.Expires Then .Cells("Expiry_Date").Value = AdjustedItem.ExpireDate
                    setReadOnly(.Cells("Expiry_Date"), AdjustedItem.Expires)
                    CType(.Cells("Batch_Location"), ComboCell).BatchLocationID = AdjustedItem.LocationID
                    .Cells("Batch_Location").Value = Utility.Get_StoreNLocationFromLID(AdjustedItem.LocationID)
                    .Cells("Qty_Available").Value = Utility.Get_ItemQtyInBatchLocation(AdjustedItem.BatchNo, AdjustedItem.LocationID)
                    .Cells("Qty").Value = AdjustedItem.Quantity
                    .Cells("UOM").Value = AdjustedItem.Unit
                    .Cells("Cost").Value = AdjustedItem.Price
                    .Cells("Amount").Value = .Cells("Cost").Value * AdjustedItem.Quantity
                    .Cells("Remark").Value = AdjustedItem.Remark
                End With
            Next
        Catch ex As Exception
            MessageBox.Show("Error: In Changing Items" & vbCrLf & ex.Message & Utility.InnerExecption(ex), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Public Overrides Sub RowsAdd(ByVal FromRowIndex As Integer, ByVal ToRowIndex As Integer)
        For RowIndex = FromRowIndex To ToRowIndex
            DGV_Items.Rows(RowIndex).Cells("Item_Name") = New ComboCell(ComboCellTypes.Items)
            DGV_Items.Rows(RowIndex).Cells("Batch") = New ComboCell(ComboCellTypes.Batches)
            If CType(DGV_Items.FindForm, FRM_IJAdjustment).FRMAdjMode = FRMAdjModes.Discard Or CType(DGV_Items.FindForm, FRM_IJAdjustment).FRMAdjMode = FRMAdjModes.Decrease Then
                DGV_Items.Rows(RowIndex).Cells("Batch_Location") = New ComboCell(ComboCellTypes.BatchLocations)
            Else
                DGV_Items.Rows(RowIndex).Cells("Batch_Location") = New ComboCell(ComboCellTypes.Locations)
            End If

            DGV_Items.Rows(RowIndex).Cells("Expiry_Date") = New CalendarCell()
        Next
    End Sub

End Class

Public Class IJGRNEdit
    Inherits IJTransaction

    Sub New(ByVal DGV_Items As DGV_ItemsRef)
        MyBase.New(DGV_Items)
    End Sub

    Public Overrides Sub ItemChanged(ByVal rowIndex As Integer, ByVal Item As InventoryItem)
        MyBase.ItemChanged(rowIndex, Item)
        With DGV_Items.Rows(rowIndex)
            If Item IsNot Nothing Then
                .Cells("Qty_Available").Value = Utility.Get_ItemQty(Item.ID)
                .Cells("Cost").Value = Utility.Get_ItemCost(Item.ID)
            Else
                .Cells("Qty_Available").Value = ""
            End If
        End With
    End Sub

    Public Overrides Sub BatchChanged(ByVal rowIndex As Integer, ByVal BatchID As String)
        MyBase.BatchChanged(rowIndex, BatchID)
        DGV_Items.Rows(rowIndex).Cells("Qty_Available").Value = ""
    End Sub

    Public Overrides Sub BatchLocationChanged(ByVal rowIndex As Integer, ByVal BatchLocation As IDNdata)
        MyBase.BatchLocationChanged(rowIndex, BatchLocation)
        If BatchLocation IsNot Nothing Then
            DGV_Items.Rows(rowIndex).Cells("Qty_Available").Value = Utility.Get_ItemQtyInBatchLocation(DGV_Items.Rows(rowIndex).Cells("Batch").Value, BatchLocation.ID)
        Else
            DGV_Items.Rows(rowIndex).Cells("Qty_Available").Value = ""
        End If
    End Sub

    Public Overrides Function ValidateData() As Boolean
        Dim NoError As Boolean = MyBase.ValidateData()
        For Each Row As DataGridViewRow In DGV_Items.Rows
            If Not Row.IsNewRow Then
                With Row
                    If .Cells("Batch").Value Is Nothing Or .Cells("Batch").Value = String.Empty Then
                        setError(.Cells("Batch"), "'Batch' should not be empty", NoError)
                    ElseIf .Cells("Batch").ErrorText <> String.Empty Then
                        NoError = False
                    End If
                    If Not .Cells("Expiry_Date").ReadOnly Then
                        If .Cells("Expiry_Date").Value Is Nothing Then
                            setError(.Cells("Expiry_Date"), "'Expiry Date' should not be empty", NoError)
                        ElseIf .Cells("Expiry_Date").Value <= Date.Today Then
                            setError(.Cells("Expiry_Date"), "Batch Should not be expired", NoError)
                        ElseIf .Cells("Expiry_Date").ErrorText <> String.Empty Then
                            NoError = False
                        End If
                    End If
                    If .Cells("Batch_Location").Value Is Nothing Then
                        setError(.Cells("Batch_Location"), "'Batch Location' should not be empty", NoError)
                    ElseIf .Cells("Batch_Location").ErrorText <> String.Empty Then
                        NoError = False
                    End If
                    If Val(.Cells("Cost").Value) <= 0 Then
                        setError(.Cells("Cost"), "A proper 'Cost' should be entered", NoError)
                    ElseIf .Cells("Cost").ErrorText <> String.Empty Then
                        NoError = False
                    End If
                End With
            End If
        Next
        Return NoError
    End Function

    Public Overrides Sub ValidateCell(ByVal CheckCell As DataGridViewCell)
        MyBase.ValidateCell(CheckCell)
        If Not DGV_Items.Rows(CheckCell.RowIndex).IsNewRow Then
            'If DGV_Items.Columns(CheckCell.ColumnIndex).Equals(DGV_Items.Columns("Batch")) Then
            '    Dim BatchID As String = CheckCell.Value
            '    If (From B In (New LMISEntities).InventoryBatches Where B.ID = BatchID Select B).Count = 0 Then
            '        setError(CheckCell, "'Batch' is not present in database")
            '        BatchChanged(CheckCell.RowIndex, Nothing)
            '    End If
            'Else
            If DGV_Items.Columns(CheckCell.ColumnIndex).Equals(DGV_Items.Columns("Batch_Location")) Then
                If CheckCell.Value Is Nothing Then
                    setError(CheckCell, "'Batch Location' should not be empty")
                    BatchLocationChanged(CheckCell.RowIndex, Nothing)
                End If
            End If
        End If
    End Sub

    Public Overrides Sub RowsAdd(ByVal FromRowIndex As Integer, ByVal ToRowIndex As Integer)
        For RowIndex = FromRowIndex To ToRowIndex
            DGV_Items.Rows(RowIndex).Cells("Item_Name") = New ComboCell(ComboCellTypes.Items)
            DGV_Items.Rows(RowIndex).Cells("Batch") = New ComboCell(ComboCellTypes.Batches)
            DGV_Items.Rows(RowIndex).Cells("Batch_Location") = New ComboCell(ComboCellTypes.Locations)
            DGV_Items.Rows(RowIndex).Cells("Expiry_Date") = New CalendarCell()
        Next
    End Sub

    Public Overrides Sub PopulateItems(ByVal IJID As String)
        Try
            Dim LMISDb As New LMISEntities
            DGV_Items.Rows.Clear()
            Dim GRNItems = From R In LMISDb.GRNs
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
                            Where R.ID = IJID And IJT.Name = "Pending"
                            Select II.ID, II.Name, II.ItemsCatalogue.Expires, IJD.Quantity, BatchNo = IJB.ID, IJDB.Price, IJDID = IJD.ID, IJB.ExpireDate, IJDB.LocationID, Unit = II.Unit.Name, IJD.Remark
                            Order By ID


            For Each GRNItem In GRNItems
                Dim Index As Integer = DGV_Items.Rows.Add()
                With DGV_Items.Rows(Index)
                    .Cells("ItemID").Value = GRNItem.ID
                    .Cells("Item_Name").Value = GRNItem.Name
                    .Cells("Batch").Value = GRNItem.BatchNo
                    If GRNItem.Expires Then .Cells("Expiry_Date").Value = GRNItem.ExpireDate
                    setReadOnly(.Cells("Expiry_Date"), GRNItem.Expires)
                    CType(.Cells("Batch_Location"), ComboCell).BatchLocationID = GRNItem.LocationID
                    .Cells("Batch_Location").Value = Utility.Get_StoreNLocationFromLID(GRNItem.LocationID)
                    .Cells("Qty_Available").Value = Utility.Get_ItemQtyInBatchLocation(GRNItem.BatchNo, GRNItem.LocationID)
                    .Cells("Qty").Value = GRNItem.Quantity
                    .Cells("UOM").Value = GRNItem.Unit
                    .Cells("Cost").Value = GRNItem.Price
                    .Cells("Amount").Value = .Cells("Cost").Value * GRNItem.Quantity
                    .Cells("Remark").Value = GRNItem.Remark
                End With
            Next
        Catch ex As Exception
            MessageBox.Show("Error: In Changing Items" & vbCrLf & ex.Message & Utility.InnerExecption(ex), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

End Class

Public Class IJTransferEdit
    Inherits IJTransaction

    Sub New(ByVal DGV_Items As DGV_ItemsRef)
        MyBase.New(DGV_Items)
    End Sub

    Public Overrides Sub ItemChanged(ByVal rowIndex As Integer, ByVal Item As InventoryItem)
        MyBase.ItemChanged(rowIndex, Item)
        With DGV_Items.Rows(rowIndex)
            If Item IsNot Nothing Then
                .Cells("Qty_Available").Value = Utility.Get_ItemQty(Item.ID)
                .Cells("Cost").Value = Utility.Get_ItemCost(Item.ID)
            Else
                .Cells("Qty_Available").Value = ""
            End If
        End With
    End Sub

    Public Overrides Sub BatchChanged(ByVal rowIndex As Integer, ByVal BatchID As String)
        MyBase.BatchChanged(rowIndex, BatchID)
        If CType(DGV_Items.FindForm, FRM_IJSTVEdit).CMBX_FromLocation.SelectedItem IsNot Nothing Then
            DGV_Items.Rows(rowIndex).Cells("Qty_Available").Value = Utility.Get_ItemQtyInBatchLocation(BatchID, CType(DGV_Items.FindForm, FRM_IJSTVEdit).CMBX_FromLocation.SelectedValue)
        Else
            DGV_Items.Rows(rowIndex).Cells("Qty_Available").Value = ""
        End If

    End Sub

    Public Overrides Sub BatchLocationChanged(ByVal rowIndex As Integer, ByVal BatchLocation As IDNdata)
        MyBase.BatchLocationChanged(rowIndex, BatchLocation)
        If BatchLocation IsNot Nothing Then
            DGV_Items.Rows(rowIndex).Cells("Qty_Available").Value = Utility.Get_ItemQtyInBatchLocation(DGV_Items.Rows(rowIndex).Cells("Batch").Value, BatchLocation.ID)
        Else
            DGV_Items.Rows(rowIndex).Cells("Qty_Available").Value = ""
        End If
    End Sub

    Public Overrides Function ValidateData() As Boolean
        Dim NoError As Boolean = MyBase.ValidateData()
        For Each Row As DataGridViewRow In DGV_Items.Rows
            If Not Row.IsNewRow Then
                With Row
                    If .Cells("Batch").Value Is Nothing Or .Cells("Batch").Value = String.Empty Then
                        setError(.Cells("Batch"), "'Batch' should not be empty", NoError)
                    ElseIf .Cells("Batch").ErrorText <> String.Empty Then
                        NoError = False
                    End If
                    If Not .Cells("Expiry_Date").ReadOnly Then
                        If .Cells("Expiry_Date").Value Is Nothing Then
                            setError(.Cells("Expiry_Date"), "'Expiry Date' should not be empty", NoError)
                        ElseIf .Cells("Expiry_Date").Value <= Date.Today Then
                            setError(.Cells("Expiry_Date"), "Batch Should not be expired", NoError)
                        ElseIf .Cells("Expiry_Date").ErrorText <> String.Empty Then
                            NoError = False
                        End If
                    End If
                    If .Cells("Qty_Available").ErrorText = String.Empty And .Cells("Qty").ErrorText = String.Empty Then
                        If Val(.Cells("Qty_Available").Value) < Val(.Cells("Qty").Value) Then
                            setError(.Cells("Qty"), "'Qty' should not be more than 'Qty Available'")
                            NoError = False
                        End If
                    End If
                    If Val(.Cells("Cost").Value) <= 0 Then
                        setError(.Cells("Cost"), "A proper 'Cost' should be entered", NoError)
                    ElseIf .Cells("Cost").ErrorText <> String.Empty Then
                        NoError = False
                    End If
                End With
            End If
        Next
        Return NoError
    End Function

    Public Overrides Sub ValidateCell(ByVal CheckCell As DataGridViewCell)
        MyBase.ValidateCell(CheckCell)
        If Not DGV_Items.Rows(CheckCell.RowIndex).IsNewRow Then
            For Each Row As DataGridViewRow In DGV_Items.Rows
                If Not Row.IsNewRow And Not Row.Equals(DGV_Items.Rows(CheckCell.RowIndex)) Then
                    If DGV_Items.Rows(CheckCell.RowIndex).Cells("ItemID").Value = Row.Cells("ItemID").Value _
                        And DGV_Items.Rows(CheckCell.RowIndex).Cells("Batch").Value = Row.Cells("Batch").Value Then
                        setError(CheckCell, "A row exists for batch '" & DGV_Items.Rows(CheckCell.RowIndex).Cells("Batch").Value & "' and item '" & Row.Cells("ItemID").Value & "', OMIT either of the rows.")
                    End If
                End If
            Next
        End If
    End Sub

    Public Overrides Sub RowsAdd(ByVal FromRowIndex As Integer, ByVal ToRowIndex As Integer)
        For RowIndex = FromRowIndex To ToRowIndex
            DGV_Items.Rows(RowIndex).Cells("Item_Name") = New ComboCell(ComboCellTypes.Items)
            DGV_Items.Rows(RowIndex).Cells("Batch") = New ComboCell(ComboCellTypes.Batches)
            DGV_Items.Rows(RowIndex).Cells("Batch_Location") = New ComboCell(ComboCellTypes.BatchLocations)
            'If CType(DGV_Items.FindForm, FRM_IJTransfersEdit).CMBX_FromLocation.SelectedItem IsNot Nothing Then
            '    CType(DGV_Items.Rows(RowIndex).Cells("Batch_Location"), ComboCell).BatchLocationID = CType(DGV_Items.FindForm, FRM_IJTransfersEdit).CMBX_FromLocation.SelectedValue
            'End If
            DGV_Items.Rows(RowIndex).Cells("Expiry_Date") = New CalendarCell()
        Next
    End Sub

    Public Overrides Sub PopulateItems(ByVal IJID As String)
        Try
            Dim LMISDb As New LMISEntities
            DGV_Items.Rows.Clear()
            Dim GRNItems = From R In LMISDb.Transfers
                            Join IJ In LMISDb.InventoryJournals
                                On R.InventoryJournalInID Equals IJ.ID
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
                            Where R.ID = IJID And IJT.Name = "Processed"
                            Select II.ID, II.Name, II.ItemsCatalogue.Expires, IJD.Quantity, BatchNo = IJB.ID, IJDB.Price, IJDID = IJD.ID, IJB.ExpireDate, IJDB.LocationID, Unit = II.Unit.Name, IJD.Remark
                            Order By ID
            For Each GRNItem In GRNItems
                Dim Index As Integer = DGV_Items.Rows.Add()
                With DGV_Items.Rows(Index)
                    .Cells("ItemID").Value = GRNItem.ID
                    .Cells("Item_Name").Value = GRNItem.Name
                    .Cells("Batch").Value = GRNItem.BatchNo
                    If GRNItem.Expires Then .Cells("Expiry_Date").Value = GRNItem.ExpireDate
                    setReadOnly(.Cells("Expiry_Date"), GRNItem.Expires)
                    CType(.Cells("Batch_Location"), ComboCell).BatchLocationID = GRNItem.LocationID
                    .Cells("Batch_Location").Value = Utility.Get_StoreNLocationFromLID(GRNItem.LocationID)
                    .Cells("Qty_Available").Value = Utility.Get_ItemQtyInBatchLocation(GRNItem.BatchNo, GRNItem.LocationID)
                    .Cells("Qty").Value = GRNItem.Quantity
                    .Cells("UOM").Value = GRNItem.Unit
                    .Cells("Cost").Value = GRNItem.Price
                    .Cells("Amount").Value = .Cells("Cost").Value * GRNItem.Quantity
                    .Cells("Remark").Value = GRNItem.Remark
                End With
            Next
        Catch ex As Exception
            MessageBox.Show("Error: In Changing Items" & vbCrLf & ex.Message & Utility.InnerExecption(ex), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

End Class
