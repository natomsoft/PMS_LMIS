
Public Class DGV_G
    Inherits System.Windows.Forms.DataGridView

    Private DGV_GType As DGV_GTypes
    Private ColumnsConfig As Long
    Public IsInDatabase As New Dictionary(Of DataGridViewRow, Boolean)

    Sub initMe(ByVal DGV_GType As DGV_GTypes)
        Me.DGV_GType = DGV_GType
        Select Case DGV_GType
            Case DGV_GTypes.StorageReqTypeOnly
                ColumnsConfig = DGV_GColumnsConfigs.RequiresSRT + DGV_GColumnsConfigs.UniqueSRT
            Case DGV_GTypes.ItemAddEdit
                ColumnsConfig = DGV_GColumnsConfigs.RequiresUnit + DGV_GColumnsConfigs.UniqueItemId + DGV_GColumnsConfigs.UniqueItemName + DGV_GColumnsConfigs.UniqueOldItemCode + DGV_GColumnsConfigs.RequiresPackSize
            Case DGV_GTypes.CategoryOnly
                ColumnsConfig = DGV_GColumnsConfigs.UniqueClassification
            Case DGV_GTypes.Store
                ColumnsConfig = DGV_GColumnsConfigs.UniqueLocation
            Case DGV_GTypes.Adjustment
                ColumnsConfig = DGV_GColumnsConfigs.UniqueAdjustmentReason
            Case DGV_GTypes.Beds
                ColumnsConfig = DGV_GColumnsConfigs.UniqueBed
        End Select
        For Each column As DataGridViewColumn In Me.Columns
            If column.ReadOnly Then column.CellTemplate.Style.BackColor = Color.FromArgb(200, 200, 200)
        Next
        Me.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(245, 245, 245)
        AddHandler Me.RowsAdded, AddressOf rowsAdd
        AddHandler Me.RowsRemoved, AddressOf rowsRemove
        Me.AllowUserToAddRows = False
        Me.AllowUserToAddRows = True
    End Sub

    Private Sub rowsAdd(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewRowsAddedEventArgs)        
        For RowIndex = e.RowIndex To (e.RowIndex + e.RowCount - 1)
            If ColumnsConfig And DGV_GColumnsConfigs.RequiresUnit Then Me.Rows(RowIndex).Cells("Unit") = New ComboCellGeneral(DGV_ComboCellTypes.Unit)
            If ColumnsConfig And DGV_GColumnsConfigs.RequiresSRT Then Me.Rows(RowIndex).Cells("SRType") = New ComboCellGeneral(DGV_ComboCellTypes.StorageReqType)
            IsInDatabase.Add(Rows(RowIndex), False)
        Next
    End Sub

    Private Sub rowsRemove(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsRemovedEventArgs) ' Handles DGV_Items.RowsRemoved
        'For RowIndex = e.RowIndex To (e.RowIndex + e.RowCount - 1)
        '    MsgBox(RowIndex)
        '    If IsInDatabase.ContainsKey(Rows(RowIndex)) And Not Rows(RowIndex).IsNewRow Then IsInDatabase.Remove(Rows(RowIndex))
        'Next
    End Sub

    Private Sub cellValidate(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Me.CellValidated
        ValidateCell(Me.Rows(e.RowIndex).Cells(e.ColumnIndex))
    End Sub

    Private Sub setError(ByVal Cell As DataGridViewCell, ByVal ErrorText As String, ByRef NoErrorVar As Boolean)
        Cell.ErrorText = ErrorText
        Cell.Style.BackColor = Color.FromArgb(255, 200, 200)
        NoErrorVar = False
    End Sub

    Private Sub clearError(ByVal Cell As DataGridViewCell)
        Cell.ErrorText = ""
        Cell.Style.BackColor = Color.White
    End Sub

#Region "Utilities"

    Public Overridable Function ValidateData() As Boolean
        Dim NoError As Boolean = True
        For Each ValRow As DataGridViewRow In Me.Rows
            For Each ValCell As DataGridViewCell In ValRow.Cells                
                If Not ValidateCell(ValCell) Then NoError = False 'only GO for false returns for ValidateCell(ValCell)                
            Next
        Next
        Return NoError
    End Function

    Private Function ValidateCell(ByVal CheckCell As DataGridViewCell)
        Dim NoError As Boolean = True
        If Not Me.Rows(CheckCell.RowIndex).IsNewRow And Not CheckCell.ReadOnly Then
            clearError(CheckCell)            
            If Me.Columns.Contains("Unit") Then 'check existence of column so not to trigger an exception
                If Me.Columns(CheckCell.ColumnIndex).Equals(Me.Columns("Unit")) Then If CheckCell.Value Is Nothing Then setError(CheckCell, "'Unit' should not be empty", NoError)            
            End If
            If Me.Columns.Contains("SRType") Then
                If Me.Columns(CheckCell.ColumnIndex).Equals(Me.Columns("SRType")) Then
                    If CheckCell.Value Is Nothing Then
                        setError(CheckCell, "'Storage requirement type' should not be empty", NoError)
                    ElseIf ColumnsConfig And DGV_GColumnsConfigs.UniqueSRT Then 'check uniquety
                        For Each SRTRow As DataGridViewRow In Me.Rows
                            If Not SRTRow.IsNewRow And Not SRTRow.Index = CheckCell.RowIndex Then If SRTRow.Cells("SRType").Value = CheckCell.Value And CheckCell.Value IsNot Nothing Then setError(CheckCell, "'Requirement' should not be repeated", NoError)
                        Next
                    End If
                End If
            End If
            If Me.Columns.Contains("Maximum") Or Me.Columns.Contains("Minimum") Then
                If Me.Columns(CheckCell.ColumnIndex).Equals(Me.Columns("Minimum")) Or Me.Columns(CheckCell.ColumnIndex).Equals(Me.Columns("Maximum")) Then If Not IsNumeric(CheckCell.Value) Then setError(CheckCell, "Please enter appropriate number", NoError)
            End If
            If Me.Columns.Contains("ItemID") Then
                If Me.Columns(CheckCell.ColumnIndex).Equals(Me.Columns("ItemID")) Then
                    If CheckCell.Value Is Nothing Then
                        setError(CheckCell, "'ItemID' should not be empty", NoError)
                    ElseIf Not IsInDatabase(Me.Rows(CheckCell.RowIndex)) Then
                        Dim Val As String = CheckCell.Value
                        If (From I In (New LMISEntities).InventoryItems Where I.ID = Val Select I).Count > 0 Then setError(CheckCell, "Item Code' " & CheckCell.Value & "' already exists", NoError)
                    End If
                    If (ColumnsConfig And DGV_GColumnsConfigs.UniqueItemId) And CheckCell.Value IsNot Nothing Then
                        For Each ItemRow As DataGridViewRow In Me.Rows
                            If Not ItemRow.IsNewRow And Not ItemRow.Index = CheckCell.RowIndex Then If ItemRow.Cells("ItemID").Value.ToString.ToLower = CheckCell.Value.ToString.ToLower Then setError(CheckCell, "'ItemID' should not be repeated", NoError)
                        Next
                    End If
                End If
            End If
            If Me.Columns.Contains("PackSize") Then
                If Me.Columns(CheckCell.ColumnIndex).Equals(Me.Columns("PackSize")) Then
                    If CheckCell.Value Is Nothing Then
                        setError(CheckCell, "'PackSize' should not be empty", NoError)
                    ElseIf Not IsNumeric(CheckCell.Value) Then
                        setError(CheckCell, "'PackSize' should be numeric", NoError)
                    ElseIf (CheckCell.Value) <= 0 Then
                        setError(CheckCell, "'PackSize' should be numeric", NoError)
                    End If
                End If
            End If
            If Me.Columns.Contains("Item_Name") Then
                If Me.Columns(CheckCell.ColumnIndex).Equals(Me.Columns("Item_Name")) Then
                    If CheckCell.Value Is Nothing Then
                        setError(CheckCell, "'Item_Name' should not be empty", NoError)
                    ElseIf Not IsInDatabase(Me.Rows(CheckCell.RowIndex)) Then
                        Dim Val As String = CheckCell.Value
                        If (From I In (New LMISEntities).InventoryItems Where I.Name = Val Select I).Count > 0 Then NoError = False
                    End If
                    If (ColumnsConfig And DGV_GColumnsConfigs.UniqueItemName) And CheckCell.Value IsNot Nothing Then
                        For Each ItemRow As DataGridViewRow In Me.Rows
                            If Not ItemRow.IsNewRow And Not ItemRow.Index = CheckCell.RowIndex Then If ItemRow.Cells("Item_Name").Value.ToString.ToLower = CheckCell.Value.ToString.ToLower Then setError(CheckCell, "'Item Name' should not be repeated", NoError)
                        Next
                    End If
                End If
            End If
            If Me.Columns.Contains("Old_Item_Code") Then
                If Me.Columns(CheckCell.ColumnIndex).Equals(Me.Columns("Old_Item_Code")) Then
                    If CheckCell.Value IsNot Nothing And Not IsInDatabase(Me.Rows(CheckCell.RowIndex)) Then
                        Dim Val As String = CheckCell.Value
                        If (From I In (New LMISEntities).InventoryItems Where I.OldItemCode = Val Select I).Count > 0 Then setError(CheckCell, "'Old Item Code' " & CheckCell.Value & "' already exists", NoError)
                    End If
                    If (ColumnsConfig And DGV_GColumnsConfigs.UniqueOldItemCode) And CheckCell.Value IsNot Nothing Then
                        For Each ItemRow As DataGridViewRow In Me.Rows
                            If Not ItemRow.IsNewRow And Not ItemRow.Index = CheckCell.RowIndex Then If ItemRow.Cells("Old_Item_Code").Value.ToString.ToLower = CheckCell.Value.ToString.ToLower Then setError(CheckCell, "'Old Item Code' should not be repeated", NoError)
                        Next
                    End If
                End If
            End If
            If Me.Columns.Contains("MaxQty") Or Me.Columns.Contains("MinQty") Or Me.Columns.Contains("ReorderQty") Then
                If Me.Columns(CheckCell.ColumnIndex).Equals(Me.Columns("MinQty")) Or Me.Columns(CheckCell.ColumnIndex).Equals(Me.Columns("MaxQty")) Or Me.Columns(CheckCell.ColumnIndex).Equals(Me.Columns("ReorderQty")) Then
                    If Not IsNumeric(CheckCell.Value) Then setError(CheckCell, "Please enter appropriate number", NoError)
                End If
            End If
            If Me.Columns.Contains("Classification") Then
                If Me.Columns(CheckCell.ColumnIndex).Equals(Me.Columns("Classification")) Then
                    If CheckCell.Value IsNot Nothing And Not IsInDatabase(Me.Rows(CheckCell.RowIndex)) Then
                        Dim Val As String = CheckCell.Value
                        If (From ICC In (New LMISEntities).Classifications Where ICC.Name = Val Select ICC).Count > 0 Then setError(CheckCell, "Classification '" & CheckCell.Value & "' already exists", NoError)
                    End If
                    If (ColumnsConfig And DGV_GColumnsConfigs.UniqueClassification) And CheckCell.Value IsNot Nothing Then
                        For Each ICCRow As DataGridViewRow In Me.Rows
                            If Not ICCRow.IsNewRow And Not ICCRow.Index = CheckCell.RowIndex Then If ICCRow.Cells("Classification").Value = CheckCell.Value Then setError(CheckCell, "'Classification' should not be repeated", NoError)
                        Next
                    End If
                End If
            End If
            If Me.Columns.Contains("Location") Then
                If Me.Columns(CheckCell.ColumnIndex).Equals(Me.Columns("Location")) Then
                    If CheckCell.Value IsNot Nothing And Not IsInDatabase(Me.Rows(CheckCell.RowIndex)) Then
                        Dim Val As String = CheckCell.Value
                        If CType(Me.FindForm, FRM_MTNStore).CMBX_Store.SelectedValue IsNot Nothing Then
                            Dim StoreID As String = CType(Me.FindForm, FRM_MTNStore).CMBX_Store.SelectedValue
                            If (From Loc In (New LMISEntities).Locations Where Loc.Name = Val And Loc.StoreID = StoreID Select Loc).Count > 0 Then setError(CheckCell, "Location '" & CheckCell.Value & "' already exists", NoError)
                        End If
                    End If
                    If (ColumnsConfig And DGV_GColumnsConfigs.UniqueClassification) And CheckCell.Value IsNot Nothing Then
                        For Each ICCRow As DataGridViewRow In Me.Rows
                            If Not ICCRow.IsNewRow And Not ICCRow.Index = CheckCell.RowIndex Then If ICCRow.Cells("Location").Value = CheckCell.Value Then setError(CheckCell, "'Location' should not be repeated", NoError)
                        Next
                    End If
                End If
            End If
            If Me.Columns.Contains("Bed") Then
                If Me.Columns(CheckCell.ColumnIndex).Equals(Me.Columns("Bed")) Then
                    If CheckCell.Value IsNot Nothing And Not IsInDatabase(Me.Rows(CheckCell.RowIndex)) Then
                        Dim Val As String = CheckCell.Value
                        If (From Loc In (New LMISEntities).Rooms Where Loc.RoomNo = Val Select Loc).Count > 0 Then setError(CheckCell, "Bed Number '" & CheckCell.Value & "' already exists", NoError)
                    End If
                    If (ColumnsConfig And DGV_GColumnsConfigs.UniqueBed) And CheckCell.Value IsNot Nothing Then
                        For Each ICCRow As DataGridViewRow In Me.Rows
                            If Not ICCRow.IsNewRow And Not ICCRow.Index = CheckCell.RowIndex Then If ICCRow.Cells("Bed").Value = CheckCell.Value Then setError(CheckCell, "'Bed' should not be repeated", NoError)
                        Next
                    End If
                End If
            End If
            If Me.Columns.Contains("AdjReason") Then
                If Me.Columns(CheckCell.ColumnIndex).Equals(Me.Columns("AdjReason")) Then
                    If CheckCell.Value IsNot Nothing And Not IsInDatabase(Me.Rows(CheckCell.RowIndex)) Then
                        Dim Val As String = CheckCell.Value
                        If (From Adj In (New LMISEntities).AdjustmentTypes Where Adj.Description = Val Select Adj).Count > 0 Then setError(CheckCell, "'Reason '" & CheckCell.Value & "' already exists", NoError)
                    End If
                    If (ColumnsConfig And DGV_GColumnsConfigs.UniqueClassification) And CheckCell.Value IsNot Nothing Then
                        For Each ICCRow As DataGridViewRow In Me.Rows
                            If Not ICCRow.IsNewRow And Not ICCRow.Index = CheckCell.RowIndex Then If ICCRow.Cells("AdjReason").Value = CheckCell.Value Then setError(CheckCell, "'Location' should not be repeated", NoError)
                        Next
                    End If
                End If
            End If
        End If
        Return NoError
    End Function

#End Region

End Class

Public Class ComboCellGeneral
    Inherits DataGridViewTextBoxCell
    Public DGV_ComboCellType As DGV_ComboCellTypes
    Public SelectedValue As Object
    Public Sub New()

    End Sub
    Public Sub New(ByVal DGV_ComboCellType As DGV_ComboCellTypes)
        Me.DGV_ComboCellType = DGV_ComboCellType        
    End Sub

    Public Sub ChangeValue(ByVal SelectedValue As Object, ByVal Text As String)
        Me.SelectedValue = SelectedValue        
        Me.Value = Text
    End Sub

    Public Overrides ReadOnly Property EditType() As Type
        Get
            Return GetType(ComboEditingControlGeneral)
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

Class ComboEditingControlGeneral
    Inherits System.Windows.Forms.ComboBox
    Implements IDataGridViewEditingControl
    Private ParentComboCell As ComboCellGeneral
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
        If Me.SelectedItem IsNot Nothing Then Return Me.Text
        Return ""
    End Function

    Public Sub PrepareEditingControlForEdit(ByVal selectAll As Boolean) Implements IDataGridViewEditingControl.PrepareEditingControlForEdit
        ParentComboCell = CType(DGV.CurrentCell, ComboCellGeneral)        
        Select Case ParentComboCell.DGV_ComboCellType
            Case DGV_ComboCellTypes.StorageReqType
                Me.DataSource = (From SRT In (New LMISEntities).StorageRequirementTypes Select SRT)
                Me.DisplayMember = "Type"
                Me.ValueMember = "ID"               
            Case DGV_ComboCellTypes.Unit
                Me.DataSource = (From U In (New LMISEntities).Units Select U)
                Me.DisplayMember = "Name"
                Me.ValueMember = "ID"
            Case DGV_ComboCellTypes.Employee
                Dim EmployeesDetails As New List(Of IDNdata)
                Dim LMISDb As New LMISEntities
                For Each Employee In From E In LMISDb.Employees Select E.ID, FName = E.Person.PersonName.Name, SName = E.Person.PersonName1.Name, LName = E.Person.PersonName2.Name, E.Person.IDNO, E.Person.PhoneNo
                    EmployeesDetails.Add(New IDNdata(Employee.ID, Employee.FName & " " & Employee.SName & " " & Employee.LName & " " & Employee.IDNO & ", " & Employee.PhoneNo, True))
                Next
                Me.DataSource = EmployeesDetails
                Me.DisplayMember = "Data"
                Me.ValueMember = "ID"
        End Select
        If ParentComboCell.SelectedValue IsNot Nothing Then
            Me.SelectedValue = ParentComboCell.SelectedValue
        Else
            Me.SelectedItem = Nothing
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
        If UserPromptedSelectionChange Then            
            ParentComboCell.ChangeValue(Me.SelectedValue, Me.Text)
        End If
    End Sub

#Region "Donot Touch"
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

Public Enum DGV_ComboCellTypes
    Unit
    StorageReqType
    Employee
End Enum

Public Enum DGV_GTypes    
    ItemAddEdit
    StorageReqTypeOnly
    CategoryOnly
    Store
    Adjustment
    Beds
End Enum

Public Enum DGV_GColumnsConfigs As Long
    RequiresUnit = 1
    RequiresSRT = 2
    UniqueItemId = 4
    UniqueItemName = 8
    UniqueOldItemCode = 16
    UniqueSRT = 32
    UniqueClassification = 64
    UniqueLocation = 128
    UniqueAdjustmentReason = 256
    UniqueBed = 512
    RequiresPackSize = 1024
End Enum