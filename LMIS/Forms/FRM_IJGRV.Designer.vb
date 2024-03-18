<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FRM_IJGRV
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
        Me.BTN_Close = New System.Windows.Forms.Button()
        Me.BTN_Save = New System.Windows.Forms.Button()
        Me.TBX_Remark = New System.Windows.Forms.TextBox()
        Me.DTP_VoucherDate = New System.Windows.Forms.DateTimePicker()
        Me.LBL_RequisitionRemark = New System.Windows.Forms.Label()
        Me.LBL_RequisitionVoucherDate = New System.Windows.Forms.Label()
        Me.CMBX_GRVID = New System.Windows.Forms.ComboBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.CMBX_Supplier = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TBX_TotalCost = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.ERP_Error = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.LBL_Adjustment = New System.Windows.Forms.Label()
        Me.ShapeContainer1 = New Microsoft.VisualBasic.PowerPacks.ShapeContainer()
        Me.LineShape3 = New Microsoft.VisualBasic.PowerPacks.LineShape()
        Me.LineShape2 = New Microsoft.VisualBasic.PowerPacks.LineShape()
        Me.LineShape1 = New Microsoft.VisualBasic.PowerPacks.LineShape()
        Me.DGV_Items = New LMIS.DGV_ItemsRef()
        Me.ItemID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Item_Name = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.UOM = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Batch = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Expiry_Date = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Batch_Location = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Qty_Available = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Qty = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Cost = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Amount = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Remark = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TBX_ReferenceID = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.BTN_Post = New System.Windows.Forms.Button()
        Me.BTN_Print = New System.Windows.Forms.Button()
        CType(Me.ERP_Error, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DGV_Items, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BTN_Close
        '
        Me.BTN_Close.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BTN_Close.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTN_Close.Location = New System.Drawing.Point(843, 512)
        Me.BTN_Close.Name = "BTN_Close"
        Me.BTN_Close.Size = New System.Drawing.Size(75, 27)
        Me.BTN_Close.TabIndex = 9
        Me.BTN_Close.Text = "Close"
        Me.BTN_Close.UseVisualStyleBackColor = True
        '
        'BTN_Save
        '
        Me.BTN_Save.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BTN_Save.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTN_Save.Location = New System.Drawing.Point(600, 512)
        Me.BTN_Save.Name = "BTN_Save"
        Me.BTN_Save.Size = New System.Drawing.Size(75, 27)
        Me.BTN_Save.TabIndex = 6
        Me.BTN_Save.Text = "Save"
        Me.BTN_Save.UseVisualStyleBackColor = True
        '
        'TBX_Remark
        '
        Me.TBX_Remark.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TBX_Remark.Location = New System.Drawing.Point(729, 83)
        Me.TBX_Remark.Multiline = True
        Me.TBX_Remark.Name = "TBX_Remark"
        Me.TBX_Remark.Size = New System.Drawing.Size(188, 24)
        Me.TBX_Remark.TabIndex = 4
        '
        'DTP_VoucherDate
        '
        Me.DTP_VoucherDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DTP_VoucherDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DTP_VoucherDate.Location = New System.Drawing.Point(195, 83)
        Me.DTP_VoucherDate.Name = "DTP_VoucherDate"
        Me.DTP_VoucherDate.Size = New System.Drawing.Size(171, 24)
        Me.DTP_VoucherDate.TabIndex = 1
        '
        'LBL_RequisitionRemark
        '
        Me.LBL_RequisitionRemark.AutoSize = True
        Me.LBL_RequisitionRemark.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBL_RequisitionRemark.ForeColor = System.Drawing.Color.White
        Me.LBL_RequisitionRemark.Location = New System.Drawing.Point(726, 64)
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
        Me.LBL_RequisitionVoucherDate.Location = New System.Drawing.Point(192, 64)
        Me.LBL_RequisitionVoucherDate.Name = "LBL_RequisitionVoucherDate"
        Me.LBL_RequisitionVoucherDate.Size = New System.Drawing.Size(40, 16)
        Me.LBL_RequisitionVoucherDate.TabIndex = 3
        Me.LBL_RequisitionVoucherDate.Text = "Date:"
        '
        'CMBX_GRVID
        '
        Me.CMBX_GRVID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.CMBX_GRVID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBX_GRVID.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBX_GRVID.FormattingEnabled = True
        Me.CMBX_GRVID.Location = New System.Drawing.Point(18, 83)
        Me.CMBX_GRVID.Name = "CMBX_GRVID"
        Me.CMBX_GRVID.Size = New System.Drawing.Size(171, 26)
        Me.CMBX_GRVID.TabIndex = 0
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.White
        Me.Label7.Location = New System.Drawing.Point(369, 64)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(61, 16)
        Me.Label7.TabIndex = 16
        Me.Label7.Text = "Supplier:"
        '
        'CMBX_Supplier
        '
        Me.CMBX_Supplier.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.CMBX_Supplier.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBX_Supplier.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBX_Supplier.FormattingEnabled = True
        Me.CMBX_Supplier.Location = New System.Drawing.Point(372, 83)
        Me.CMBX_Supplier.Name = "CMBX_Supplier"
        Me.CMBX_Supplier.Size = New System.Drawing.Size(171, 26)
        Me.CMBX_Supplier.TabIndex = 2
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(13, 64)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(61, 16)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "GRV No:"
        '
        'TBX_TotalCost
        '
        Me.TBX_TotalCost.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TBX_TotalCost.Enabled = False
        Me.TBX_TotalCost.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TBX_TotalCost.Location = New System.Drawing.Point(666, 473)
        Me.TBX_TotalCost.Name = "TBX_TotalCost"
        Me.TBX_TotalCost.ReadOnly = True
        Me.TBX_TotalCost.Size = New System.Drawing.Size(251, 22)
        Me.TBX_TotalCost.TabIndex = 14
        Me.TBX_TotalCost.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label6
        '
        Me.Label6.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.White
        Me.Label6.Location = New System.Drawing.Point(570, 476)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(90, 16)
        Me.Label6.TabIndex = 13
        Me.Label6.Text = "Total Amount:"
        '
        'ERP_Error
        '
        Me.ERP_Error.ContainerControl = Me
        '
        'LBL_Adjustment
        '
        Me.LBL_Adjustment.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LBL_Adjustment.AutoSize = True
        Me.LBL_Adjustment.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBL_Adjustment.ForeColor = System.Drawing.Color.White
        Me.LBL_Adjustment.Location = New System.Drawing.Point(12, 9)
        Me.LBL_Adjustment.Name = "LBL_Adjustment"
        Me.LBL_Adjustment.Size = New System.Drawing.Size(352, 31)
        Me.LBL_Adjustment.TabIndex = 15
        Me.LBL_Adjustment.Text = "Goods Receiving Voucher"
        '
        'ShapeContainer1
        '
        Me.ShapeContainer1.Location = New System.Drawing.Point(0, 0)
        Me.ShapeContainer1.Margin = New System.Windows.Forms.Padding(0)
        Me.ShapeContainer1.Name = "ShapeContainer1"
        Me.ShapeContainer1.Shapes.AddRange(New Microsoft.VisualBasic.PowerPacks.Shape() {Me.LineShape3, Me.LineShape2, Me.LineShape1})
        Me.ShapeContainer1.Size = New System.Drawing.Size(944, 551)
        Me.ShapeContainer1.TabIndex = 16
        Me.ShapeContainer1.TabStop = False
        '
        'LineShape3
        '
        Me.LineShape3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LineShape3.BorderColor = System.Drawing.Color.LightGray
        Me.LineShape3.Name = "LineShape3"
        Me.LineShape3.X1 = 14
        Me.LineShape3.X2 = 930
        Me.LineShape3.Y1 = 503
        Me.LineShape3.Y2 = 503
        '
        'LineShape2
        '
        Me.LineShape2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LineShape2.BorderColor = System.Drawing.Color.LightGray
        Me.LineShape2.Name = "LineShape2"
        Me.LineShape2.X1 = 14
        Me.LineShape2.X2 = 930
        Me.LineShape2.Y1 = 123
        Me.LineShape2.Y2 = 123
        '
        'LineShape1
        '
        Me.LineShape1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LineShape1.BorderColor = System.Drawing.Color.LightGray
        Me.LineShape1.Name = "LineShape1"
        Me.LineShape1.X1 = 14
        Me.LineShape1.X2 = 930
        Me.LineShape1.Y1 = 53
        Me.LineShape1.Y2 = 53
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
        Me.DGV_Items.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ItemID, Me.Item_Name, Me.UOM, Me.Batch, Me.Expiry_Date, Me.Batch_Location, Me.Qty_Available, Me.Qty, Me.Cost, Me.Amount, Me.Remark})
        Me.DGV_Items.Location = New System.Drawing.Point(18, 137)
        Me.DGV_Items.MultiSelect = False
        Me.DGV_Items.Name = "DGV_Items"
        Me.DGV_Items.RowHeadersWidth = 20
        Me.DGV_Items.Size = New System.Drawing.Size(900, 330)
        Me.DGV_Items.TabIndex = 5
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
        Me.Expiry_Date.HeaderText = "Exp Date"
        Me.Expiry_Date.Name = "Expiry_Date"
        '
        'Batch_Location
        '
        Me.Batch_Location.HeaderText = "Location"
        Me.Batch_Location.Name = "Batch_Location"
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
        'Cost
        '
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight
        DataGridViewCellStyle3.Format = "N2"
        Me.Cost.DefaultCellStyle = DataGridViewCellStyle3
        Me.Cost.FillWeight = 72.09082!
        Me.Cost.HeaderText = "U.Price"
        Me.Cost.Name = "Cost"
        '
        'Amount
        '
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight
        DataGridViewCellStyle4.Format = "N2"
        DataGridViewCellStyle4.NullValue = Nothing
        Me.Amount.DefaultCellStyle = DataGridViewCellStyle4
        Me.Amount.HeaderText = "Amount"
        Me.Amount.Name = "Amount"
        Me.Amount.ReadOnly = True
        '
        'Remark
        '
        Me.Remark.HeaderText = "Remark"
        Me.Remark.Name = "Remark"
        '
        'TBX_ReferenceID
        '
        Me.TBX_ReferenceID.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TBX_ReferenceID.Location = New System.Drawing.Point(552, 83)
        Me.TBX_ReferenceID.Name = "TBX_ReferenceID"
        Me.TBX_ReferenceID.Size = New System.Drawing.Size(171, 24)
        Me.TBX_ReferenceID.TabIndex = 3
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.White
        Me.Label8.Location = New System.Drawing.Point(549, 64)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(95, 16)
        Me.Label8.TabIndex = 21
        Me.Label8.Text = "Reference No:"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'BTN_Post
        '
        Me.BTN_Post.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BTN_Post.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTN_Post.Location = New System.Drawing.Point(762, 512)
        Me.BTN_Post.Name = "BTN_Post"
        Me.BTN_Post.Size = New System.Drawing.Size(75, 27)
        Me.BTN_Post.TabIndex = 8
        Me.BTN_Post.Text = "Post"
        Me.BTN_Post.UseVisualStyleBackColor = True
        '
        'BTN_Print
        '
        Me.BTN_Print.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BTN_Print.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTN_Print.Location = New System.Drawing.Point(681, 512)
        Me.BTN_Print.Name = "BTN_Print"
        Me.BTN_Print.Size = New System.Drawing.Size(75, 27)
        Me.BTN_Print.TabIndex = 7
        Me.BTN_Print.Text = "Print"
        Me.BTN_Print.UseVisualStyleBackColor = True
        '
        'FRM_IJGRV
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.SlateGray
        Me.ClientSize = New System.Drawing.Size(944, 551)
        Me.Controls.Add(Me.BTN_Post)
        Me.Controls.Add(Me.BTN_Print)
        Me.Controls.Add(Me.TBX_ReferenceID)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.TBX_TotalCost)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.DGV_Items)
        Me.Controls.Add(Me.CMBX_GRVID)
        Me.Controls.Add(Me.TBX_Remark)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.LBL_RequisitionRemark)
        Me.Controls.Add(Me.CMBX_Supplier)
        Me.Controls.Add(Me.DTP_VoucherDate)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.LBL_RequisitionVoucherDate)
        Me.Controls.Add(Me.LBL_Adjustment)
        Me.Controls.Add(Me.BTN_Save)
        Me.Controls.Add(Me.BTN_Close)
        Me.Controls.Add(Me.ShapeContainer1)
        Me.MinimumSize = New System.Drawing.Size(950, 575)
        Me.Name = "FRM_IJGRV"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "GRV"
        CType(Me.ERP_Error, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DGV_Items, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

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
    Friend WithEvents CMBX_Supplier As System.Windows.Forms.ComboBox
    Friend WithEvents CMBX_GRVID As System.Windows.Forms.ComboBox
    Friend WithEvents DGV_Items As LMIS.DGV_ItemsRef
    Friend WithEvents LBL_Adjustment As System.Windows.Forms.Label
    Friend WithEvents ShapeContainer1 As Microsoft.VisualBasic.PowerPacks.ShapeContainer
    Friend WithEvents LineShape1 As Microsoft.VisualBasic.PowerPacks.LineShape
    Friend WithEvents LineShape3 As Microsoft.VisualBasic.PowerPacks.LineShape
    Friend WithEvents LineShape2 As Microsoft.VisualBasic.PowerPacks.LineShape
    Friend WithEvents TBX_ReferenceID As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents ItemID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Item_Name As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents UOM As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Batch As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Expiry_Date As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Batch_Location As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Qty_Available As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Qty As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Cost As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Amount As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Remark As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BTN_Post As System.Windows.Forms.Button
    Friend WithEvents BTN_Print As System.Windows.Forms.Button
End Class
