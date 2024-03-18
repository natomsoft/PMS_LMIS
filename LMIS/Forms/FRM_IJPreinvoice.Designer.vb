<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FRM_IJPreinvoice
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
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.BTN_Close = New System.Windows.Forms.Button()
        Me.BTN_Save = New System.Windows.Forms.Button()
        Me.TBX_TotalCost = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.ERP_Error = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.Label4 = New System.Windows.Forms.Label()
        Me.LineShape2 = New Microsoft.VisualBasic.PowerPacks.LineShape()
        Me.LineShape1 = New Microsoft.VisualBasic.PowerPacks.LineShape()
        Me.LineShape3 = New Microsoft.VisualBasic.PowerPacks.LineShape()
        Me.ShapeContainer1 = New Microsoft.VisualBasic.PowerPacks.ShapeContainer()
        Me.BTN_Print = New System.Windows.Forms.Button()
        Me.DGV_Items = New LMIS.DGV_ItemsRef()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn8 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TBX_Remark = New System.Windows.Forms.TextBox()
        Me.LBL_RequisitionRemark = New System.Windows.Forms.Label()
        Me.CMBX_RequisitionID = New System.Windows.Forms.ComboBox()
        Me.DTP_VoucherDate = New System.Windows.Forms.DateTimePicker()
        Me.LBL_RequisitionVoucherDate = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TBX_Department = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TBX_IssueID = New System.Windows.Forms.TextBox()
        Me.ItemID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Item_Name = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.UOM = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Batch = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Expiry_Date = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Batch_Location = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Qty_Available = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Qty_AllAvailable = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Adj_Consm = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Qty_Requested = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Qty = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Cost = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Amount = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Remark = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.ERP_Error, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DGV_Items, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BTN_Close
        '
        Me.BTN_Close.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BTN_Close.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTN_Close.Location = New System.Drawing.Point(846, 497)
        Me.BTN_Close.Name = "BTN_Close"
        Me.BTN_Close.Size = New System.Drawing.Size(75, 28)
        Me.BTN_Close.TabIndex = 7
        Me.BTN_Close.Text = "Close"
        Me.BTN_Close.UseVisualStyleBackColor = True
        '
        'BTN_Save
        '
        Me.BTN_Save.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BTN_Save.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTN_Save.Location = New System.Drawing.Point(684, 497)
        Me.BTN_Save.Name = "BTN_Save"
        Me.BTN_Save.Size = New System.Drawing.Size(75, 28)
        Me.BTN_Save.TabIndex = 5
        Me.BTN_Save.Text = "Save"
        Me.BTN_Save.UseVisualStyleBackColor = True
        '
        'TBX_TotalCost
        '
        Me.TBX_TotalCost.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TBX_TotalCost.Enabled = False
        Me.TBX_TotalCost.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TBX_TotalCost.Location = New System.Drawing.Point(680, 456)
        Me.TBX_TotalCost.Name = "TBX_TotalCost"
        Me.TBX_TotalCost.ReadOnly = True
        Me.TBX_TotalCost.Size = New System.Drawing.Size(238, 22)
        Me.TBX_TotalCost.TabIndex = 31
        Me.TBX_TotalCost.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label8
        '
        Me.Label8.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.White
        Me.Label8.Location = New System.Drawing.Point(595, 459)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(82, 16)
        Me.Label8.TabIndex = 30
        Me.Label8.Text = "Grand Total:"
        '
        'ERP_Error
        '
        Me.ERP_Error.ContainerControl = Me
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(12, 9)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(163, 31)
        Me.Label4.TabIndex = 15
        Me.Label4.Text = "Pre-Invoice"
        '
        'LineShape2
        '
        Me.LineShape2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LineShape2.BorderColor = System.Drawing.Color.LightGray
        Me.LineShape2.Name = "LineShape2"
        Me.LineShape2.X1 = 14
        Me.LineShape2.X2 = 920
        Me.LineShape2.Y1 = 118
        Me.LineShape2.Y2 = 118
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
        'LineShape3
        '
        Me.LineShape3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LineShape3.BorderColor = System.Drawing.Color.LightGray
        Me.LineShape3.Name = "LineShape3"
        Me.LineShape3.X1 = 14
        Me.LineShape3.X2 = 920
        Me.LineShape3.Y1 = 485
        Me.LineShape3.Y2 = 485
        '
        'ShapeContainer1
        '
        Me.ShapeContainer1.Location = New System.Drawing.Point(0, 0)
        Me.ShapeContainer1.Margin = New System.Windows.Forms.Padding(0)
        Me.ShapeContainer1.Name = "ShapeContainer1"
        Me.ShapeContainer1.Shapes.AddRange(New Microsoft.VisualBasic.PowerPacks.Shape() {Me.LineShape3, Me.LineShape1, Me.LineShape2})
        Me.ShapeContainer1.Size = New System.Drawing.Size(934, 537)
        Me.ShapeContainer1.TabIndex = 32
        Me.ShapeContainer1.TabStop = False
        '
        'BTN_Print
        '
        Me.BTN_Print.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BTN_Print.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTN_Print.Location = New System.Drawing.Point(765, 497)
        Me.BTN_Print.Name = "BTN_Print"
        Me.BTN_Print.Size = New System.Drawing.Size(75, 28)
        Me.BTN_Print.TabIndex = 6
        Me.BTN_Print.Text = "Print"
        Me.BTN_Print.UseVisualStyleBackColor = True
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
        Me.DGV_Items.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ItemID, Me.Item_Name, Me.UOM, Me.Batch, Me.Expiry_Date, Me.Batch_Location, Me.Qty_Available, Me.Qty_AllAvailable, Me.Adj_Consm, Me.Qty_Requested, Me.Qty, Me.Cost, Me.Amount, Me.Remark})
        Me.DGV_Items.Location = New System.Drawing.Point(18, 132)
        Me.DGV_Items.MultiSelect = False
        Me.DGV_Items.Name = "DGV_Items"
        Me.DGV_Items.RowHeadersWidth = 20
        Me.DGV_Items.Size = New System.Drawing.Size(900, 318)
        Me.DGV_Items.TabIndex = 4
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.FillWeight = 60.19803!
        Me.DataGridViewTextBoxColumn1.HeaderText = "Item Code"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        Me.DataGridViewTextBoxColumn1.Width = 74
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.FillWeight = 150.0!
        Me.DataGridViewTextBoxColumn2.HeaderText = "Item Name"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        Me.DataGridViewTextBoxColumn2.Width = 183
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.FillWeight = 78.67783!
        Me.DataGridViewTextBoxColumn3.HeaderText = "Batch"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.ReadOnly = True
        Me.DataGridViewTextBoxColumn3.Width = 96
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.HeaderText = "Expiry Date"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.ReadOnly = True
        Me.DataGridViewTextBoxColumn4.Width = 122
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.HeaderText = "Batch Location"
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        Me.DataGridViewTextBoxColumn5.ReadOnly = True
        Me.DataGridViewTextBoxColumn5.Width = 123
        '
        'DataGridViewTextBoxColumn6
        '
        Me.DataGridViewTextBoxColumn6.FillWeight = 78.67783!
        Me.DataGridViewTextBoxColumn6.HeaderText = "Qty Requested"
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        Me.DataGridViewTextBoxColumn6.ReadOnly = True
        Me.DataGridViewTextBoxColumn6.Width = 96
        '
        'DataGridViewTextBoxColumn7
        '
        Me.DataGridViewTextBoxColumn7.FillWeight = 78.67783!
        Me.DataGridViewTextBoxColumn7.HeaderText = "Qty Received"
        Me.DataGridViewTextBoxColumn7.Name = "DataGridViewTextBoxColumn7"
        Me.DataGridViewTextBoxColumn7.ReadOnly = True
        Me.DataGridViewTextBoxColumn7.Width = 96
        '
        'DataGridViewTextBoxColumn8
        '
        Me.DataGridViewTextBoxColumn8.FillWeight = 72.09082!
        Me.DataGridViewTextBoxColumn8.HeaderText = "Cost"
        Me.DataGridViewTextBoxColumn8.Name = "DataGridViewTextBoxColumn8"
        Me.DataGridViewTextBoxColumn8.ReadOnly = True
        Me.DataGridViewTextBoxColumn8.Width = 88
        '
        'TBX_Remark
        '
        Me.TBX_Remark.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TBX_Remark.Location = New System.Drawing.Point(719, 83)
        Me.TBX_Remark.Multiline = True
        Me.TBX_Remark.Name = "TBX_Remark"
        Me.TBX_Remark.Size = New System.Drawing.Size(199, 24)
        Me.TBX_Remark.TabIndex = 3
        '
        'LBL_RequisitionRemark
        '
        Me.LBL_RequisitionRemark.AutoSize = True
        Me.LBL_RequisitionRemark.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBL_RequisitionRemark.ForeColor = System.Drawing.Color.White
        Me.LBL_RequisitionRemark.Location = New System.Drawing.Point(716, 64)
        Me.LBL_RequisitionRemark.Name = "LBL_RequisitionRemark"
        Me.LBL_RequisitionRemark.Size = New System.Drawing.Size(59, 16)
        Me.LBL_RequisitionRemark.TabIndex = 2
        Me.LBL_RequisitionRemark.Text = "Remark:"
        '
        'CMBX_RequisitionID
        '
        Me.CMBX_RequisitionID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.CMBX_RequisitionID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBX_RequisitionID.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBX_RequisitionID.FormattingEnabled = True
        Me.CMBX_RequisitionID.Location = New System.Drawing.Point(18, 83)
        Me.CMBX_RequisitionID.Name = "CMBX_RequisitionID"
        Me.CMBX_RequisitionID.Size = New System.Drawing.Size(171, 26)
        Me.CMBX_RequisitionID.TabIndex = 0
        '
        'DTP_VoucherDate
        '
        Me.DTP_VoucherDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DTP_VoucherDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DTP_VoucherDate.Location = New System.Drawing.Point(375, 83)
        Me.DTP_VoucherDate.Name = "DTP_VoucherDate"
        Me.DTP_VoucherDate.Size = New System.Drawing.Size(161, 24)
        Me.DTP_VoucherDate.TabIndex = 1
        '
        'LBL_RequisitionVoucherDate
        '
        Me.LBL_RequisitionVoucherDate.AutoSize = True
        Me.LBL_RequisitionVoucherDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBL_RequisitionVoucherDate.ForeColor = System.Drawing.Color.White
        Me.LBL_RequisitionVoucherDate.Location = New System.Drawing.Point(372, 64)
        Me.LBL_RequisitionVoucherDate.Name = "LBL_RequisitionVoucherDate"
        Me.LBL_RequisitionVoucherDate.Size = New System.Drawing.Size(40, 16)
        Me.LBL_RequisitionVoucherDate.TabIndex = 3
        Me.LBL_RequisitionVoucherDate.Text = "Date:"
        Me.LBL_RequisitionVoucherDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.White
        Me.Label7.Location = New System.Drawing.Point(539, 64)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(125, 16)
        Me.Label7.TabIndex = 13
        Me.Label7.Text = "Requesting Facility:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(15, 64)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(99, 16)
        Me.Label3.TabIndex = 9
        Me.Label3.Text = "Requisition No:"
        '
        'TBX_Department
        '
        Me.TBX_Department.Enabled = False
        Me.TBX_Department.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TBX_Department.Location = New System.Drawing.Point(542, 83)
        Me.TBX_Department.Name = "TBX_Department"
        Me.TBX_Department.ReadOnly = True
        Me.TBX_Department.Size = New System.Drawing.Size(171, 24)
        Me.TBX_Department.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(192, 64)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(105, 16)
        Me.Label1.TabIndex = 34
        Me.Label1.Text = "Invoice Number:"
        '
        'TBX_IssueID
        '
        Me.TBX_IssueID.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TBX_IssueID.Location = New System.Drawing.Point(195, 83)
        Me.TBX_IssueID.Name = "TBX_IssueID"
        Me.TBX_IssueID.Size = New System.Drawing.Size(174, 24)
        Me.TBX_IssueID.TabIndex = 33
        '
        'ItemID
        '
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.Silver
        Me.ItemID.DefaultCellStyle = DataGridViewCellStyle1
        Me.ItemID.FillWeight = 60.19803!
        Me.ItemID.HeaderText = "Stock Code"
        Me.ItemID.Name = "ItemID"
        Me.ItemID.ReadOnly = True
        '
        'Item_Name
        '
        Me.Item_Name.FillWeight = 250.0!
        Me.Item_Name.HeaderText = "Stock Item"
        Me.Item_Name.Name = "Item_Name"
        '
        'UOM
        '
        Me.UOM.FillWeight = 50.0!
        Me.UOM.HeaderText = "Unit"
        Me.UOM.Name = "UOM"
        Me.UOM.ReadOnly = True
        '
        'Batch
        '
        Me.Batch.HeaderText = "Batch"
        Me.Batch.Name = "Batch"
        '
        'Expiry_Date
        '
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.Silver
        Me.Expiry_Date.DefaultCellStyle = DataGridViewCellStyle2
        Me.Expiry_Date.HeaderText = "Exp Date"
        Me.Expiry_Date.Name = "Expiry_Date"
        Me.Expiry_Date.ReadOnly = True
        '
        'Batch_Location
        '
        Me.Batch_Location.FillWeight = 150.0!
        Me.Batch_Location.HeaderText = "Batch Location"
        Me.Batch_Location.Name = "Batch_Location"
        '
        'Qty_Available
        '
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight
        DataGridViewCellStyle3.Format = "N2"
        Me.Qty_Available.DefaultCellStyle = DataGridViewCellStyle3
        Me.Qty_Available.HeaderText = "Qty Available Batch"
        Me.Qty_Available.Name = "Qty_Available"
        Me.Qty_Available.ReadOnly = True
        '
        'Qty_AllAvailable
        '
        DataGridViewCellStyle4.Format = "N2"
        Me.Qty_AllAvailable.DefaultCellStyle = DataGridViewCellStyle4
        Me.Qty_AllAvailable.HeaderText = "Qty Available Items"
        Me.Qty_AllAvailable.Name = "Qty_AllAvailable"
        Me.Qty_AllAvailable.ReadOnly = True
        '
        'Adj_Consm
        '
        Me.Adj_Consm.HeaderText = "Adjusted Consumption"
        Me.Adj_Consm.Name = "Adj_Consm"
        Me.Adj_Consm.ReadOnly = True
        '
        'Qty_Requested
        '
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight
        DataGridViewCellStyle5.Format = "N2"
        Me.Qty_Requested.DefaultCellStyle = DataGridViewCellStyle5
        Me.Qty_Requested.FillWeight = 78.67783!
        Me.Qty_Requested.HeaderText = "Qty Requested"
        Me.Qty_Requested.Name = "Qty_Requested"
        Me.Qty_Requested.ReadOnly = True
        '
        'Qty
        '
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight
        DataGridViewCellStyle6.Format = "N2"
        Me.Qty.DefaultCellStyle = DataGridViewCellStyle6
        Me.Qty.FillWeight = 78.67783!
        Me.Qty.HeaderText = "Qty Issued"
        Me.Qty.Name = "Qty"
        '
        'Cost
        '
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight
        DataGridViewCellStyle7.Format = "N2"
        Me.Cost.DefaultCellStyle = DataGridViewCellStyle7
        Me.Cost.FillWeight = 72.09082!
        Me.Cost.HeaderText = "Unit Price"
        Me.Cost.Name = "Cost"
        Me.Cost.ReadOnly = True
        '
        'Amount
        '
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight
        DataGridViewCellStyle8.Format = "N2"
        Me.Amount.DefaultCellStyle = DataGridViewCellStyle8
        Me.Amount.HeaderText = "Total Price"
        Me.Amount.Name = "Amount"
        Me.Amount.ReadOnly = True
        '
        'Remark
        '
        Me.Remark.HeaderText = "Remark"
        Me.Remark.Name = "Remark"
        '
        'FRM_IJPreinvoice
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.SlateGray
        Me.ClientSize = New System.Drawing.Size(934, 537)
        Me.Controls.Add(Me.TBX_IssueID)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.BTN_Print)
        Me.Controls.Add(Me.TBX_TotalCost)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.TBX_Department)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.DGV_Items)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.LBL_RequisitionVoucherDate)
        Me.Controls.Add(Me.BTN_Save)
        Me.Controls.Add(Me.DTP_VoucherDate)
        Me.Controls.Add(Me.BTN_Close)
        Me.Controls.Add(Me.CMBX_RequisitionID)
        Me.Controls.Add(Me.LBL_RequisitionRemark)
        Me.Controls.Add(Me.TBX_Remark)
        Me.Controls.Add(Me.ShapeContainer1)
        Me.Name = "FRM_IJPreinvoice"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Pre-Invoice"
        CType(Me.ERP_Error, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DGV_Items, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents BTN_Close As System.Windows.Forms.Button
    Friend WithEvents BTN_Save As System.Windows.Forms.Button
    Friend WithEvents ERP_Error As System.Windows.Forms.ErrorProvider
    Friend WithEvents DGV_Items As DGV_ItemsRef
    Friend WithEvents TBX_TotalCost As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn7 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn8 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents ShapeContainer1 As Microsoft.VisualBasic.PowerPacks.ShapeContainer
    Friend WithEvents LineShape3 As Microsoft.VisualBasic.PowerPacks.LineShape
    Friend WithEvents LineShape1 As Microsoft.VisualBasic.PowerPacks.LineShape
    Friend WithEvents LineShape2 As Microsoft.VisualBasic.PowerPacks.LineShape
    Friend WithEvents BTN_Print As System.Windows.Forms.Button
    Friend WithEvents TBX_IssueID As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TBX_Department As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents LBL_RequisitionVoucherDate As System.Windows.Forms.Label
    Friend WithEvents DTP_VoucherDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents CMBX_RequisitionID As System.Windows.Forms.ComboBox
    Friend WithEvents LBL_RequisitionRemark As System.Windows.Forms.Label
    Friend WithEvents TBX_Remark As System.Windows.Forms.TextBox
    Friend WithEvents ItemID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Item_Name As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents UOM As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Batch As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Expiry_Date As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Batch_Location As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Qty_Available As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Qty_AllAvailable As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Adj_Consm As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Qty_Requested As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Qty As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Cost As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Amount As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Remark As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
