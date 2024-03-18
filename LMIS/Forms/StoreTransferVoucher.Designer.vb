<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class StoreTransferVoucher
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
        Me.CMBX_MStockCode = New System.Windows.Forms.ComboBox()
        Me.CMBX_XBatchLoc = New System.Windows.Forms.ComboBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.CMBX_MBatchLoc = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.TBX_AvailableQty = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.TBX_Remark = New System.Windows.Forms.TextBox()
        Me.LBL_RequisitionVoucherDate = New System.Windows.Forms.Label()
        Me.DTP_VoucherDate = New System.Windows.Forms.DateTimePicker()
        Me.CMBX_AdjustmentID = New System.Windows.Forms.ComboBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.ERP_Error = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TBX_MQty = New System.Windows.Forms.TextBox()
        Me.CMBX_MBatch = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.CMBX_MStockItem = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.LBL_Title = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.BTN_Save = New System.Windows.Forms.Button()
        Me.BTN_Close = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.BTN_Post = New System.Windows.Forms.Button()
        Me.BTN_Print = New System.Windows.Forms.Button()
        Me.DGV_Items = New LMIS.DGV_ItemsRef()
        Me.DataGridViewTextBoxColumn8 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn9 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.ItemID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Item_Name = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.batchID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Batch = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.locationID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Batch_Location = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.destinationID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.toLocation = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Qty_Available = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Qty = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Expiry_Date = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.batchPrice = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IJDetIDout = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IJDetIn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.transferDetID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.ERP_Error, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DGV_Items, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'CMBX_MStockCode
        '
        Me.CMBX_MStockCode.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.CMBX_MStockCode.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBX_MStockCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBX_MStockCode.FormattingEnabled = True
        Me.CMBX_MStockCode.Location = New System.Drawing.Point(56, 175)
        Me.CMBX_MStockCode.Name = "CMBX_MStockCode"
        Me.CMBX_MStockCode.Size = New System.Drawing.Size(135, 24)
        Me.CMBX_MStockCode.TabIndex = 114
        '
        'CMBX_XBatchLoc
        '
        Me.CMBX_XBatchLoc.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.CMBX_XBatchLoc.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBX_XBatchLoc.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBX_XBatchLoc.FormattingEnabled = True
        Me.CMBX_XBatchLoc.Location = New System.Drawing.Point(200, 221)
        Me.CMBX_XBatchLoc.Name = "CMBX_XBatchLoc"
        Me.CMBX_XBatchLoc.Size = New System.Drawing.Size(135, 24)
        Me.CMBX_XBatchLoc.TabIndex = 124
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.ForeColor = System.Drawing.Color.White
        Me.Label18.Location = New System.Drawing.Point(197, 202)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(129, 16)
        Me.Label18.TabIndex = 153
        Me.Label18.Text = "Destination Location"
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'CMBX_MBatchLoc
        '
        Me.CMBX_MBatchLoc.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.CMBX_MBatchLoc.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBX_MBatchLoc.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBX_MBatchLoc.FormattingEnabled = True
        Me.CMBX_MBatchLoc.Location = New System.Drawing.Point(57, 221)
        Me.CMBX_MBatchLoc.Name = "CMBX_MBatchLoc"
        Me.CMBX_MBatchLoc.Size = New System.Drawing.Size(135, 24)
        Me.CMBX_MBatchLoc.TabIndex = 117
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(54, 202)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(96, 16)
        Me.Label4.TabIndex = 152
        Me.Label4.Text = "Batch Location"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.ForeColor = System.Drawing.Color.White
        Me.Label17.Location = New System.Drawing.Point(344, 202)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(116, 16)
        Me.Label17.TabIndex = 151
        Me.Label17.Text = "Available Quantity"
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TBX_AvailableQty
        '
        Me.TBX_AvailableQty.Enabled = False
        Me.TBX_AvailableQty.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TBX_AvailableQty.Location = New System.Drawing.Point(347, 221)
        Me.TBX_AvailableQty.Name = "TBX_AvailableQty"
        Me.TBX_AvailableQty.Size = New System.Drawing.Size(163, 24)
        Me.TBX_AvailableQty.TabIndex = 118
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.Color.White
        Me.Label15.Location = New System.Drawing.Point(329, 99)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(56, 16)
        Me.Label15.TabIndex = 150
        Me.Label15.Text = "Remark"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TBX_Remark
        '
        Me.TBX_Remark.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TBX_Remark.Location = New System.Drawing.Point(332, 118)
        Me.TBX_Remark.Name = "TBX_Remark"
        Me.TBX_Remark.Size = New System.Drawing.Size(368, 24)
        Me.TBX_Remark.TabIndex = 113
        '
        'LBL_RequisitionVoucherDate
        '
        Me.LBL_RequisitionVoucherDate.AutoSize = True
        Me.LBL_RequisitionVoucherDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBL_RequisitionVoucherDate.ForeColor = System.Drawing.Color.White
        Me.LBL_RequisitionVoucherDate.Location = New System.Drawing.Point(209, 99)
        Me.LBL_RequisitionVoucherDate.Name = "LBL_RequisitionVoucherDate"
        Me.LBL_RequisitionVoucherDate.Size = New System.Drawing.Size(40, 16)
        Me.LBL_RequisitionVoucherDate.TabIndex = 149
        Me.LBL_RequisitionVoucherDate.Text = "Date:"
        '
        'DTP_VoucherDate
        '
        Me.DTP_VoucherDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DTP_VoucherDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DTP_VoucherDate.Location = New System.Drawing.Point(212, 118)
        Me.DTP_VoucherDate.Name = "DTP_VoucherDate"
        Me.DTP_VoucherDate.Size = New System.Drawing.Size(114, 24)
        Me.DTP_VoucherDate.TabIndex = 111
        '
        'CMBX_AdjustmentID
        '
        Me.CMBX_AdjustmentID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.CMBX_AdjustmentID.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBX_AdjustmentID.FormattingEnabled = True
        Me.CMBX_AdjustmentID.Location = New System.Drawing.Point(56, 118)
        Me.CMBX_AdjustmentID.Name = "CMBX_AdjustmentID"
        Me.CMBX_AdjustmentID.Size = New System.Drawing.Size(150, 24)
        Me.CMBX_AdjustmentID.TabIndex = 110
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.White
        Me.Label14.Location = New System.Drawing.Point(53, 99)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(56, 16)
        Me.Label14.TabIndex = 148
        Me.Label14.Text = "STV No"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'ERP_Error
        '
        Me.ERP_Error.ContainerControl = Me
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(513, 202)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(109, 16)
        Me.Label3.TabIndex = 133
        Me.Label3.Text = "Transfer Quantity"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TBX_MQty
        '
        Me.TBX_MQty.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TBX_MQty.Location = New System.Drawing.Point(516, 221)
        Me.TBX_MQty.Name = "TBX_MQty"
        Me.TBX_MQty.Size = New System.Drawing.Size(184, 24)
        Me.TBX_MQty.TabIndex = 119
        '
        'CMBX_MBatch
        '
        Me.CMBX_MBatch.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.CMBX_MBatch.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBX_MBatch.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBX_MBatch.FormattingEnabled = True
        Me.CMBX_MBatch.Location = New System.Drawing.Point(461, 175)
        Me.CMBX_MBatch.Name = "CMBX_MBatch"
        Me.CMBX_MBatch.Size = New System.Drawing.Size(239, 24)
        Me.CMBX_MBatch.TabIndex = 116
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(458, 156)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(42, 16)
        Me.Label2.TabIndex = 132
        Me.Label2.Text = "Batch"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'CMBX_MStockItem
        '
        Me.CMBX_MStockItem.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.CMBX_MStockItem.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBX_MStockItem.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBX_MStockItem.FormattingEnabled = True
        Me.CMBX_MStockItem.Location = New System.Drawing.Point(200, 175)
        Me.CMBX_MStockItem.Name = "CMBX_MStockItem"
        Me.CMBX_MStockItem.Size = New System.Drawing.Size(256, 24)
        Me.CMBX_MStockItem.TabIndex = 115
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(197, 156)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(70, 16)
        Me.Label1.TabIndex = 131
        Me.Label1.Text = "Stock Item"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LBL_Title
        '
        Me.LBL_Title.AutoSize = True
        Me.LBL_Title.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBL_Title.ForeColor = System.Drawing.Color.White
        Me.LBL_Title.Location = New System.Drawing.Point(38, 33)
        Me.LBL_Title.Name = "LBL_Title"
        Me.LBL_Title.Size = New System.Drawing.Size(70, 31)
        Me.LBL_Title.TabIndex = 130
        Me.LBL_Title.Text = "STV"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.Color.White
        Me.Label16.Location = New System.Drawing.Point(56, 156)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(78, 16)
        Me.Label16.TabIndex = 129
        Me.Label16.Text = "Stock Code"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'BTN_Save
        '
        Me.BTN_Save.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTN_Save.Location = New System.Drawing.Point(807, 530)
        Me.BTN_Save.Name = "BTN_Save"
        Me.BTN_Save.Size = New System.Drawing.Size(75, 28)
        Me.BTN_Save.TabIndex = 125
        Me.BTN_Save.Text = "Save"
        Me.BTN_Save.UseVisualStyleBackColor = True
        '
        'BTN_Close
        '
        Me.BTN_Close.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTN_Close.Location = New System.Drawing.Point(1050, 529)
        Me.BTN_Close.Name = "BTN_Close"
        Me.BTN_Close.Size = New System.Drawing.Size(75, 28)
        Me.BTN_Close.TabIndex = 128
        Me.BTN_Close.Text = "Close"
        Me.BTN_Close.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Location = New System.Drawing.Point(716, 221)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 28)
        Me.Button1.TabIndex = 154
        Me.Button1.Text = "Add"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'BTN_Post
        '
        Me.BTN_Post.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BTN_Post.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTN_Post.Location = New System.Drawing.Point(969, 530)
        Me.BTN_Post.Name = "BTN_Post"
        Me.BTN_Post.Size = New System.Drawing.Size(75, 27)
        Me.BTN_Post.TabIndex = 157
        Me.BTN_Post.Text = "Post"
        Me.BTN_Post.UseVisualStyleBackColor = True
        '
        'BTN_Print
        '
        Me.BTN_Print.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BTN_Print.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTN_Print.Location = New System.Drawing.Point(888, 530)
        Me.BTN_Print.Name = "BTN_Print"
        Me.BTN_Print.Size = New System.Drawing.Size(75, 27)
        Me.BTN_Print.TabIndex = 156
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
        Me.DGV_Items.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ItemID, Me.Item_Name, Me.batchID, Me.Batch, Me.locationID, Me.Batch_Location, Me.destinationID, Me.toLocation, Me.Qty_Available, Me.Qty, Me.Expiry_Date, Me.batchPrice, Me.IJDetIDout, Me.IJDetIn, Me.transferDetID})
        Me.DGV_Items.Location = New System.Drawing.Point(12, 254)
        Me.DGV_Items.MultiSelect = False
        Me.DGV_Items.Name = "DGV_Items"
        Me.DGV_Items.RowHeadersWidth = 20
        Me.DGV_Items.Size = New System.Drawing.Size(1146, 254)
        Me.DGV_Items.TabIndex = 155
        '
        'DataGridViewTextBoxColumn8
        '
        Me.DataGridViewTextBoxColumn8.FillWeight = 89.0863!
        Me.DataGridViewTextBoxColumn8.HeaderText = "Unit"
        Me.DataGridViewTextBoxColumn8.Name = "DataGridViewTextBoxColumn8"
        Me.DataGridViewTextBoxColumn8.ReadOnly = True
        Me.DataGridViewTextBoxColumn8.Width = 89
        '
        'DataGridViewTextBoxColumn6
        '
        Me.DataGridViewTextBoxColumn6.FillWeight = 121.8274!
        Me.DataGridViewTextBoxColumn6.HeaderText = "Item Name"
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        Me.DataGridViewTextBoxColumn6.ReadOnly = True
        Me.DataGridViewTextBoxColumn6.Visible = False
        Me.DataGridViewTextBoxColumn6.Width = 122
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.FillWeight = 70.0!
        Me.DataGridViewTextBoxColumn5.HeaderText = "Item Code"
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        Me.DataGridViewTextBoxColumn5.ReadOnly = True
        Me.DataGridViewTextBoxColumn5.Width = 105
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.FillWeight = 89.0863!
        Me.DataGridViewTextBoxColumn4.HeaderText = "Maximum"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.ReadOnly = True
        Me.DataGridViewTextBoxColumn4.Width = 104
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.HeaderText = "SRTypeID"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        Me.DataGridViewTextBoxColumn1.Visible = False
        Me.DataGridViewTextBoxColumn1.Width = 105
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.FillWeight = 89.0863!
        Me.DataGridViewTextBoxColumn3.HeaderText = "Minimum"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.ReadOnly = True
        Me.DataGridViewTextBoxColumn3.Width = 106
        '
        'DataGridViewTextBoxColumn7
        '
        Me.DataGridViewTextBoxColumn7.FillWeight = 89.0863!
        Me.DataGridViewTextBoxColumn7.HeaderText = "Old Item Code"
        Me.DataGridViewTextBoxColumn7.Name = "DataGridViewTextBoxColumn7"
        Me.DataGridViewTextBoxColumn7.ReadOnly = True
        Me.DataGridViewTextBoxColumn7.Width = 89
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.FillWeight = 121.8274!
        Me.DataGridViewTextBoxColumn2.HeaderText = "Storage Requirement Type"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        Me.DataGridViewTextBoxColumn2.Visible = False
        Me.DataGridViewTextBoxColumn2.Width = 144
        '
        'DataGridViewTextBoxColumn9
        '
        Me.DataGridViewTextBoxColumn9.FillWeight = 70.0!
        Me.DataGridViewTextBoxColumn9.HeaderText = "Unit"
        Me.DataGridViewTextBoxColumn9.Name = "DataGridViewTextBoxColumn9"
        Me.DataGridViewTextBoxColumn9.ReadOnly = True
        Me.DataGridViewTextBoxColumn9.Width = 74
        '
        'Button2
        '
        Me.Button2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.ForeColor = System.Drawing.Color.Red
        Me.Button2.Location = New System.Drawing.Point(1079, 220)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 28)
        Me.Button2.TabIndex = 158
        Me.Button2.Text = "X"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'ItemID
        '
        Me.ItemID.FillWeight = 60.19803!
        Me.ItemID.HeaderText = "Stock Code"
        Me.ItemID.Name = "ItemID"
        '
        'Item_Name
        '
        Me.Item_Name.FillWeight = 250.0!
        Me.Item_Name.HeaderText = "Stock Item"
        Me.Item_Name.Name = "Item_Name"
        '
        'batchID
        '
        Me.batchID.HeaderText = "batchID"
        Me.batchID.Name = "batchID"
        Me.batchID.Visible = False
        '
        'Batch
        '
        Me.Batch.HeaderText = "Batch"
        Me.Batch.Name = "Batch"
        '
        'locationID
        '
        Me.locationID.HeaderText = "locationID"
        Me.locationID.Name = "locationID"
        Me.locationID.Visible = False
        '
        'Batch_Location
        '
        Me.Batch_Location.HeaderText = "Location"
        Me.Batch_Location.Name = "Batch_Location"
        '
        'destinationID
        '
        Me.destinationID.HeaderText = "destinationID"
        Me.destinationID.Name = "destinationID"
        Me.destinationID.Visible = False
        '
        'toLocation
        '
        Me.toLocation.HeaderText = "To Location"
        Me.toLocation.Name = "toLocation"
        '
        'Qty_Available
        '
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight
        DataGridViewCellStyle1.Format = "N2"
        Me.Qty_Available.DefaultCellStyle = DataGridViewCellStyle1
        Me.Qty_Available.HeaderText = "Qty Available"
        Me.Qty_Available.Name = "Qty_Available"
        Me.Qty_Available.ReadOnly = True
        '
        'Qty
        '
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight
        DataGridViewCellStyle2.Format = "N2"
        Me.Qty.DefaultCellStyle = DataGridViewCellStyle2
        Me.Qty.FillWeight = 78.67783!
        Me.Qty.HeaderText = "Qty"
        Me.Qty.Name = "Qty"
        '
        'Expiry_Date
        '
        Me.Expiry_Date.HeaderText = "Exp Date"
        Me.Expiry_Date.Name = "Expiry_Date"
        Me.Expiry_Date.Visible = False
        '
        'batchPrice
        '
        Me.batchPrice.HeaderText = "batchPrice"
        Me.batchPrice.Name = "batchPrice"
        '
        'IJDetIDout
        '
        Me.IJDetIDout.HeaderText = "IJDetIDout"
        Me.IJDetIDout.Name = "IJDetIDout"
        Me.IJDetIDout.Visible = False
        '
        'IJDetIn
        '
        Me.IJDetIn.HeaderText = "IJDetIn"
        Me.IJDetIn.Name = "IJDetIn"
        Me.IJDetIn.Visible = False
        '
        'transferDetID
        '
        Me.transferDetID.HeaderText = "transferDetID"
        Me.transferDetID.Name = "transferDetID"
        Me.transferDetID.Visible = False
        '
        'StoreTransferVoucher
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.SlateGray
        Me.ClientSize = New System.Drawing.Size(1166, 569)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.BTN_Post)
        Me.Controls.Add(Me.BTN_Print)
        Me.Controls.Add(Me.DGV_Items)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.CMBX_MStockCode)
        Me.Controls.Add(Me.CMBX_XBatchLoc)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.CMBX_MBatchLoc)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.TBX_AvailableQty)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.TBX_Remark)
        Me.Controls.Add(Me.LBL_RequisitionVoucherDate)
        Me.Controls.Add(Me.DTP_VoucherDate)
        Me.Controls.Add(Me.CMBX_AdjustmentID)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.TBX_MQty)
        Me.Controls.Add(Me.CMBX_MBatch)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.CMBX_MStockItem)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.LBL_Title)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.BTN_Save)
        Me.Controls.Add(Me.BTN_Close)
        Me.Name = "StoreTransferVoucher"
        Me.Text = "StoreTransferVoucher"
        CType(Me.ERP_Error, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DGV_Items, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents CMBX_MStockCode As System.Windows.Forms.ComboBox
    Friend WithEvents CMBX_XBatchLoc As System.Windows.Forms.ComboBox
    Friend WithEvents DataGridViewTextBoxColumn8 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents CMBX_MBatchLoc As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents TBX_AvailableQty As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents TBX_Remark As System.Windows.Forms.TextBox
    Friend WithEvents LBL_RequisitionVoucherDate As System.Windows.Forms.Label
    Friend WithEvents DTP_VoucherDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents DataGridViewTextBoxColumn6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CMBX_AdjustmentID As System.Windows.Forms.ComboBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents DataGridViewTextBoxColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn7 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn9 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ERP_Error As System.Windows.Forms.ErrorProvider
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TBX_MQty As System.Windows.Forms.TextBox
    Friend WithEvents CMBX_MBatch As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents CMBX_MStockItem As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents LBL_Title As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents BTN_Save As System.Windows.Forms.Button
    Friend WithEvents BTN_Close As System.Windows.Forms.Button
    Friend WithEvents DGV_Items As LMIS.DGV_ItemsRef
    Friend WithEvents BTN_Post As System.Windows.Forms.Button
    Friend WithEvents BTN_Print As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents ItemID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Item_Name As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents batchID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Batch As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents locationID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Batch_Location As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents destinationID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents toLocation As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Qty_Available As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Qty As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Expiry_Date As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents batchPrice As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IJDetIDout As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IJDetIn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents transferDetID As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
