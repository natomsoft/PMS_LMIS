<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FRM_IJFacilityRequestEdit
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.BTN_Close = New System.Windows.Forms.Button()
        Me.BTN_Save = New System.Windows.Forms.Button()
        Me.TBX_Remark = New System.Windows.Forms.TextBox()
        Me.DTP_VoucherDate = New System.Windows.Forms.DateTimePicker()
        Me.LBL_RequisitionRemark = New System.Windows.Forms.Label()
        Me.LBL_RequisitionVoucherDate = New System.Windows.Forms.Label()
        Me.TBX_ReferenceID = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.CMBX_RequisitionID = New System.Windows.Forms.ComboBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.CMBX_Department = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TBX_TotalCost = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.ERP_Error = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.LBL_Title = New System.Windows.Forms.Label()
        Me.LineShape1 = New Microsoft.VisualBasic.PowerPacks.LineShape()
        Me.LineShape2 = New Microsoft.VisualBasic.PowerPacks.LineShape()
        Me.LineShape3 = New Microsoft.VisualBasic.PowerPacks.LineShape()
        Me.ShapeContainer1 = New Microsoft.VisualBasic.PowerPacks.ShapeContainer()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.CMBX_Quarter = New System.Windows.Forms.ComboBox()
        Me.TBX_LName = New System.Windows.Forms.TextBox()
        Me.TBX_MName = New System.Windows.Forms.TextBox()
        Me.TBX_FName = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.DGV_Items = New LMIS.DGV_ItemsRef()
        Me.ItemID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Item_Name = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.UOM = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Qty_StockInhand = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Qty_Consumed = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Stock_Out_Days = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Qty = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Cost = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Amount = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Remark = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.CHBX_Scheduled = New System.Windows.Forms.CheckBox()
        Me.CHBX_UseTemplate = New System.Windows.Forms.CheckBox()
        Me.CMBX_RequestDates = New System.Windows.Forms.ComboBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.LabelNoItems = New System.Windows.Forms.Label()
        CType(Me.ERP_Error, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DGV_Items, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BTN_Close
        '
        Me.BTN_Close.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BTN_Close.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTN_Close.Location = New System.Drawing.Point(832, 472)
        Me.BTN_Close.Name = "BTN_Close"
        Me.BTN_Close.Size = New System.Drawing.Size(75, 28)
        Me.BTN_Close.TabIndex = 11
        Me.BTN_Close.Text = "Close"
        Me.BTN_Close.UseVisualStyleBackColor = True
        '
        'BTN_Save
        '
        Me.BTN_Save.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BTN_Save.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTN_Save.Location = New System.Drawing.Point(751, 472)
        Me.BTN_Save.Name = "BTN_Save"
        Me.BTN_Save.Size = New System.Drawing.Size(75, 28)
        Me.BTN_Save.TabIndex = 10
        Me.BTN_Save.Text = "Save"
        Me.BTN_Save.UseVisualStyleBackColor = True
        '
        'TBX_Remark
        '
        Me.TBX_Remark.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TBX_Remark.Location = New System.Drawing.Point(549, 130)
        Me.TBX_Remark.Multiline = True
        Me.TBX_Remark.Name = "TBX_Remark"
        Me.TBX_Remark.Size = New System.Drawing.Size(358, 24)
        Me.TBX_Remark.TabIndex = 8
        '
        'DTP_VoucherDate
        '
        Me.DTP_VoucherDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DTP_VoucherDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DTP_VoucherDate.Location = New System.Drawing.Point(195, 84)
        Me.DTP_VoucherDate.Name = "DTP_VoucherDate"
        Me.DTP_VoucherDate.Size = New System.Drawing.Size(171, 24)
        Me.DTP_VoucherDate.TabIndex = 1
        '
        'LBL_RequisitionRemark
        '
        Me.LBL_RequisitionRemark.AutoSize = True
        Me.LBL_RequisitionRemark.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBL_RequisitionRemark.ForeColor = System.Drawing.Color.White
        Me.LBL_RequisitionRemark.Location = New System.Drawing.Point(546, 111)
        Me.LBL_RequisitionRemark.Name = "LBL_RequisitionRemark"
        Me.LBL_RequisitionRemark.Size = New System.Drawing.Size(59, 16)
        Me.LBL_RequisitionRemark.TabIndex = 2
        Me.LBL_RequisitionRemark.Text = "Remark:"
        '
        'LBL_RequisitionVoucherDate
        '
        Me.LBL_RequisitionVoucherDate.AutoSize = True
        Me.LBL_RequisitionVoucherDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBL_RequisitionVoucherDate.ForeColor = System.Drawing.Color.White
        Me.LBL_RequisitionVoucherDate.Location = New System.Drawing.Point(192, 65)
        Me.LBL_RequisitionVoucherDate.Name = "LBL_RequisitionVoucherDate"
        Me.LBL_RequisitionVoucherDate.Size = New System.Drawing.Size(40, 16)
        Me.LBL_RequisitionVoucherDate.TabIndex = 3
        Me.LBL_RequisitionVoucherDate.Text = "Date:"
        '
        'TBX_ReferenceID
        '
        Me.TBX_ReferenceID.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TBX_ReferenceID.Location = New System.Drawing.Point(18, 130)
        Me.TBX_ReferenceID.Name = "TBX_ReferenceID"
        Me.TBX_ReferenceID.Size = New System.Drawing.Size(171, 24)
        Me.TBX_ReferenceID.TabIndex = 4
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.White
        Me.Label8.Location = New System.Drawing.Point(15, 111)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(95, 16)
        Me.Label8.TabIndex = 19
        Me.Label8.Text = "Reference No:"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'CMBX_RequisitionID
        '
        Me.CMBX_RequisitionID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.CMBX_RequisitionID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBX_RequisitionID.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBX_RequisitionID.FormattingEnabled = True
        Me.CMBX_RequisitionID.Location = New System.Drawing.Point(18, 82)
        Me.CMBX_RequisitionID.Name = "CMBX_RequisitionID"
        Me.CMBX_RequisitionID.Size = New System.Drawing.Size(171, 26)
        Me.CMBX_RequisitionID.TabIndex = 0
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.White
        Me.Label7.Location = New System.Drawing.Point(369, 63)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(125, 16)
        Me.Label7.TabIndex = 16
        Me.Label7.Text = "Requesting Facility:"
        '
        'CMBX_Department
        '
        Me.CMBX_Department.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.CMBX_Department.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBX_Department.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBX_Department.FormattingEnabled = True
        Me.CMBX_Department.ItemHeight = 18
        Me.CMBX_Department.Location = New System.Drawing.Point(372, 82)
        Me.CMBX_Department.Name = "CMBX_Department"
        Me.CMBX_Department.Size = New System.Drawing.Size(171, 26)
        Me.CMBX_Department.TabIndex = 2
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(15, 63)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(83, 16)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "Request No:"
        '
        'TBX_TotalCost
        '
        Me.TBX_TotalCost.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TBX_TotalCost.Enabled = False
        Me.TBX_TotalCost.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TBX_TotalCost.Location = New System.Drawing.Point(665, 431)
        Me.TBX_TotalCost.Name = "TBX_TotalCost"
        Me.TBX_TotalCost.ReadOnly = True
        Me.TBX_TotalCost.Size = New System.Drawing.Size(242, 22)
        Me.TBX_TotalCost.TabIndex = 14
        Me.TBX_TotalCost.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label6
        '
        Me.Label6.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.White
        Me.Label6.Location = New System.Drawing.Point(518, 434)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(148, 16)
        Me.Label6.TabIndex = 13
        Me.Label6.Text = "Estimated Grand Total: "
        '
        'ERP_Error
        '
        Me.ERP_Error.ContainerControl = Me
        '
        'LBL_Title
        '
        Me.LBL_Title.AutoSize = True
        Me.LBL_Title.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBL_Title.ForeColor = System.Drawing.Color.White
        Me.LBL_Title.Location = New System.Drawing.Point(12, 9)
        Me.LBL_Title.Name = "LBL_Title"
        Me.LBL_Title.Size = New System.Drawing.Size(225, 31)
        Me.LBL_Title.TabIndex = 15
        Me.LBL_Title.Text = "Facility Request"
        '
        'LineShape1
        '
        Me.LineShape1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LineShape1.BorderColor = System.Drawing.Color.LightGray
        Me.LineShape1.Name = "LineShape1"
        Me.LineShape1.X1 = 14
        Me.LineShape1.X2 = 920
        Me.LineShape1.Y1 = 53
        Me.LineShape1.Y2 = 53
        '
        'LineShape2
        '
        Me.LineShape2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LineShape2.BorderColor = System.Drawing.Color.LightGray
        Me.LineShape2.Name = "LineShape2"
        Me.LineShape2.X1 = 14
        Me.LineShape2.X2 = 920
        Me.LineShape2.Y1 = 206
        Me.LineShape2.Y2 = 206
        '
        'LineShape3
        '
        Me.LineShape3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LineShape3.BorderColor = System.Drawing.Color.LightGray
        Me.LineShape3.Name = "LineShape3"
        Me.LineShape3.X1 = 13
        Me.LineShape3.X2 = 919
        Me.LineShape3.Y1 = 459
        Me.LineShape3.Y2 = 459
        '
        'ShapeContainer1
        '
        Me.ShapeContainer1.Location = New System.Drawing.Point(0, 0)
        Me.ShapeContainer1.Margin = New System.Windows.Forms.Padding(0)
        Me.ShapeContainer1.Name = "ShapeContainer1"
        Me.ShapeContainer1.Shapes.AddRange(New Microsoft.VisualBasic.PowerPacks.Shape() {Me.LineShape3, Me.LineShape2, Me.LineShape1})
        Me.ShapeContainer1.Size = New System.Drawing.Size(934, 512)
        Me.ShapeContainer1.TabIndex = 20
        Me.ShapeContainer1.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(546, 63)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(51, 16)
        Me.Label1.TabIndex = 22
        Me.Label1.Text = "Period:"
        '
        'CMBX_Quarter
        '
        Me.CMBX_Quarter.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.CMBX_Quarter.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBX_Quarter.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBX_Quarter.FormattingEnabled = True
        Me.CMBX_Quarter.ItemHeight = 18
        Me.CMBX_Quarter.Location = New System.Drawing.Point(549, 82)
        Me.CMBX_Quarter.Name = "CMBX_Quarter"
        Me.CMBX_Quarter.Size = New System.Drawing.Size(171, 26)
        Me.CMBX_Quarter.TabIndex = 3
        '
        'TBX_LName
        '
        Me.TBX_LName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.TBX_LName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.TBX_LName.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TBX_LName.Location = New System.Drawing.Point(432, 130)
        Me.TBX_LName.Name = "TBX_LName"
        Me.TBX_LName.Size = New System.Drawing.Size(111, 24)
        Me.TBX_LName.TabIndex = 7
        '
        'TBX_MName
        '
        Me.TBX_MName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.TBX_MName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.TBX_MName.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TBX_MName.Location = New System.Drawing.Point(312, 130)
        Me.TBX_MName.Name = "TBX_MName"
        Me.TBX_MName.Size = New System.Drawing.Size(113, 24)
        Me.TBX_MName.TabIndex = 6
        '
        'TBX_FName
        '
        Me.TBX_FName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.TBX_FName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.TBX_FName.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TBX_FName.Location = New System.Drawing.Point(195, 130)
        Me.TBX_FName.Name = "TBX_FName"
        Me.TBX_FName.Size = New System.Drawing.Size(111, 24)
        Me.TBX_FName.TabIndex = 5
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(192, 111)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(76, 16)
        Me.Label2.TabIndex = 90
        Me.Label2.Text = "First Name:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'DGV_Items
        '
        Me.DGV_Items.AllowUserToAddRows = False
        Me.DGV_Items.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DGV_Items.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.DGV_Items.BackgroundColor = System.Drawing.Color.SlateGray
        Me.DGV_Items.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.DGV_Items.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV_Items.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ItemID, Me.Item_Name, Me.UOM, Me.Qty_StockInhand, Me.Qty_Consumed, Me.Stock_Out_Days, Me.Qty, Me.Cost, Me.Amount, Me.Remark})
        Me.DGV_Items.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke
        Me.DGV_Items.Location = New System.Drawing.Point(18, 215)
        Me.DGV_Items.MultiSelect = False
        Me.DGV_Items.Name = "DGV_Items"
        Me.DGV_Items.RowHeadersWidth = 20
        Me.DGV_Items.Size = New System.Drawing.Size(889, 210)
        Me.DGV_Items.TabIndex = 9
        '
        'ItemID
        '
        Me.ItemID.HeaderText = "Stock Code"
        Me.ItemID.Name = "ItemID"
        '
        'Item_Name
        '
        Me.Item_Name.FillWeight = 250.0!
        Me.Item_Name.HeaderText = "Stock Item"
        Me.Item_Name.Name = "Item_Name"
        Me.Item_Name.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        '
        'UOM
        '
        Me.UOM.FillWeight = 50.0!
        Me.UOM.HeaderText = "Unit"
        Me.UOM.Name = "UOM"
        Me.UOM.ReadOnly = True
        '
        'Qty_StockInhand
        '
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight
        Me.Qty_StockInhand.DefaultCellStyle = DataGridViewCellStyle1
        Me.Qty_StockInhand.HeaderText = "Qty Stock on hand"
        Me.Qty_StockInhand.Name = "Qty_StockInhand"
        '
        'Qty_Consumed
        '
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight
        DataGridViewCellStyle2.Format = "N2"
        Me.Qty_Consumed.DefaultCellStyle = DataGridViewCellStyle2
        Me.Qty_Consumed.HeaderText = "Qty Consumed"
        Me.Qty_Consumed.Name = "Qty_Consumed"
        '
        'Stock_Out_Days
        '
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight
        DataGridViewCellStyle3.Format = "N2"
        Me.Stock_Out_Days.DefaultCellStyle = DataGridViewCellStyle3
        Me.Stock_Out_Days.HeaderText = "Stock Out Days"
        Me.Stock_Out_Days.Name = "Stock_Out_Days"
        '
        'Qty
        '
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight
        DataGridViewCellStyle4.Format = "N2"
        Me.Qty.DefaultCellStyle = DataGridViewCellStyle4
        Me.Qty.HeaderText = "Qty Requested"
        Me.Qty.Name = "Qty"
        '
        'Cost
        '
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight
        DataGridViewCellStyle5.Format = "N2"
        Me.Cost.DefaultCellStyle = DataGridViewCellStyle5
        Me.Cost.HeaderText = "Unit Price"
        Me.Cost.Name = "Cost"
        '
        'Amount
        '
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight
        DataGridViewCellStyle6.Format = "N2"
        Me.Amount.DefaultCellStyle = DataGridViewCellStyle6
        Me.Amount.HeaderText = "Total Price"
        Me.Amount.Name = "Amount"
        Me.Amount.ReadOnly = True
        '
        'Remark
        '
        Me.Remark.HeaderText = "Remark"
        Me.Remark.Name = "Remark"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(306, 111)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(92, 16)
        Me.Label4.TabIndex = 92
        Me.Label4.Text = "Middle Name:"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(429, 111)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(76, 16)
        Me.Label5.TabIndex = 93
        Me.Label5.Text = "Last Name:"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'CHBX_Scheduled
        '
        Me.CHBX_Scheduled.AutoSize = True
        Me.CHBX_Scheduled.Checked = True
        Me.CHBX_Scheduled.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CHBX_Scheduled.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CHBX_Scheduled.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.CHBX_Scheduled.Location = New System.Drawing.Point(726, 86)
        Me.CHBX_Scheduled.Name = "CHBX_Scheduled"
        Me.CHBX_Scheduled.Size = New System.Drawing.Size(134, 19)
        Me.CHBX_Scheduled.TabIndex = 94
        Me.CHBX_Scheduled.Text = "Scheduled Request"
        Me.CHBX_Scheduled.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.CHBX_Scheduled.UseVisualStyleBackColor = True
        '
        'CHBX_UseTemplate
        '
        Me.CHBX_UseTemplate.AutoSize = True
        Me.CHBX_UseTemplate.ForeColor = System.Drawing.Color.White
        Me.CHBX_UseTemplate.Location = New System.Drawing.Point(408, 176)
        Me.CHBX_UseTemplate.Name = "CHBX_UseTemplate"
        Me.CHBX_UseTemplate.Size = New System.Drawing.Size(135, 17)
        Me.CHBX_UseTemplate.TabIndex = 95
        Me.CHBX_UseTemplate.Text = "Use Request Template"
        Me.CHBX_UseTemplate.UseVisualStyleBackColor = True
        '
        'CMBX_RequestDates
        '
        Me.CMBX_RequestDates.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.CMBX_RequestDates.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBX_RequestDates.DisplayMember = "VoucherDate"
        Me.CMBX_RequestDates.Enabled = False
        Me.CMBX_RequestDates.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBX_RequestDates.FormattingEnabled = True
        Me.CMBX_RequestDates.Location = New System.Drawing.Point(549, 176)
        Me.CMBX_RequestDates.Name = "CMBX_RequestDates"
        Me.CMBX_RequestDates.Size = New System.Drawing.Size(171, 26)
        Me.CMBX_RequestDates.TabIndex = 97
        Me.CMBX_RequestDates.ValueMember = "ID"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.White
        Me.Label9.Location = New System.Drawing.Point(546, 157)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(36, 15)
        Me.Label9.TabIndex = 96
        Me.Label9.Text = "Date:"
        '
        'LabelNoItems
        '
        Me.LabelNoItems.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LabelNoItems.AutoSize = True
        Me.LabelNoItems.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelNoItems.ForeColor = System.Drawing.Color.White
        Me.LabelNoItems.Location = New System.Drawing.Point(15, 434)
        Me.LabelNoItems.Name = "LabelNoItems"
        Me.LabelNoItems.Size = New System.Drawing.Size(45, 16)
        Me.LabelNoItems.TabIndex = 98
        Me.LabelNoItems.Text = "Total: "
        '
        'FRM_IJFacilityRequestEdit
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.SlateGray
        Me.ClientSize = New System.Drawing.Size(934, 512)
        Me.Controls.Add(Me.LabelNoItems)
        Me.Controls.Add(Me.CMBX_RequestDates)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.CHBX_UseTemplate)
        Me.Controls.Add(Me.CHBX_Scheduled)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.TBX_LName)
        Me.Controls.Add(Me.TBX_MName)
        Me.Controls.Add(Me.TBX_FName)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.CMBX_Quarter)
        Me.Controls.Add(Me.TBX_TotalCost)
        Me.Controls.Add(Me.TBX_ReferenceID)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.DGV_Items)
        Me.Controls.Add(Me.LBL_Title)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.CMBX_RequisitionID)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.CMBX_Department)
        Me.Controls.Add(Me.BTN_Save)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.BTN_Close)
        Me.Controls.Add(Me.LBL_RequisitionVoucherDate)
        Me.Controls.Add(Me.TBX_Remark)
        Me.Controls.Add(Me.DTP_VoucherDate)
        Me.Controls.Add(Me.LBL_RequisitionRemark)
        Me.Controls.Add(Me.ShapeContainer1)
        Me.MinimumSize = New System.Drawing.Size(950, 550)
        Me.Name = "FRM_IJFacilityRequestEdit"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Request Items"
        CType(Me.ERP_Error, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DGV_Items, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents DGV_Items As DGV_ItemsRef
    Friend WithEvents BTN_Close As System.Windows.Forms.Button
    Friend WithEvents BTN_Save As System.Windows.Forms.Button
    Friend WithEvents TBX_Remark As System.Windows.Forms.TextBox
    Friend WithEvents DTP_VoucherDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents LBL_RequisitionRemark As System.Windows.Forms.Label
    Friend WithEvents LBL_RequisitionVoucherDate As System.Windows.Forms.Label
    Friend WithEvents ERP_Error As System.Windows.Forms.ErrorProvider
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TBX_TotalCost As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents CMBX_Department As System.Windows.Forms.ComboBox
    Friend WithEvents CMBX_RequisitionID As System.Windows.Forms.ComboBox
    Friend WithEvents TBX_ReferenceID As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents LBL_Title As System.Windows.Forms.Label
    Friend WithEvents ShapeContainer1 As Microsoft.VisualBasic.PowerPacks.ShapeContainer
    Friend WithEvents LineShape3 As Microsoft.VisualBasic.PowerPacks.LineShape
    Friend WithEvents LineShape2 As Microsoft.VisualBasic.PowerPacks.LineShape
    Friend WithEvents LineShape1 As Microsoft.VisualBasic.PowerPacks.LineShape
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents CMBX_Quarter As System.Windows.Forms.ComboBox
    Friend WithEvents TBX_LName As System.Windows.Forms.TextBox
    Friend WithEvents TBX_MName As System.Windows.Forms.TextBox
    Friend WithEvents TBX_FName As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents ItemID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Item_Name As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents UOM As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Qty_StockInhand As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Qty_Consumed As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Stock_Out_Days As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Qty As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Cost As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Amount As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Remark As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents CHBX_Scheduled As System.Windows.Forms.CheckBox
    Friend WithEvents CHBX_UseTemplate As System.Windows.Forms.CheckBox
    Friend WithEvents CMBX_RequestDates As System.Windows.Forms.ComboBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents LabelNoItems As System.Windows.Forms.Label
End Class

