<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class STVForm
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
        Me.ERP_Error = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.BTN_Print = New System.Windows.Forms.Button()
        Me.TBX_TotalCost = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.BTN_Save = New System.Windows.Forms.Button()
        Me.CMBX_TransferID = New System.Windows.Forms.ComboBox()
        Me.TBX_Remark = New System.Windows.Forms.TextBox()
        Me.LBL_RequisitionRemark = New System.Windows.Forms.Label()
        Me.DTP_VoucherDate = New System.Windows.Forms.DateTimePicker()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.LBL_RequisitionVoucherDate = New System.Windows.Forms.Label()
        Me.DGV_Items = New LMIS.DGV_ItemsRef()
        Me.ItemID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Item_Name = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.UOM = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Batch = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Expiry_Date = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.locationTo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Batch_Location = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Qty_Available = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Qty_AllAvailable = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Adj_Consm = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Qty_Requested = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Qty = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Cost = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Amount = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Remark = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn8 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.ERP_Error, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DGV_Items, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BTN_Close
        '
        Me.BTN_Close.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BTN_Close.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTN_Close.Location = New System.Drawing.Point(1078, 507)
        Me.BTN_Close.Name = "BTN_Close"
        Me.BTN_Close.Size = New System.Drawing.Size(75, 28)
        Me.BTN_Close.TabIndex = 44
        Me.BTN_Close.Text = "Close"
        Me.BTN_Close.UseVisualStyleBackColor = True
        '
        'ERP_Error
        '
        Me.ERP_Error.ContainerControl = Me
        '
        'BTN_Print
        '
        Me.BTN_Print.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BTN_Print.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTN_Print.Location = New System.Drawing.Point(997, 507)
        Me.BTN_Print.Name = "BTN_Print"
        Me.BTN_Print.Size = New System.Drawing.Size(75, 28)
        Me.BTN_Print.TabIndex = 43
        Me.BTN_Print.Text = "Print"
        Me.BTN_Print.UseVisualStyleBackColor = True
        '
        'TBX_TotalCost
        '
        Me.TBX_TotalCost.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TBX_TotalCost.Enabled = False
        Me.TBX_TotalCost.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TBX_TotalCost.Location = New System.Drawing.Point(680, 465)
        Me.TBX_TotalCost.Name = "TBX_TotalCost"
        Me.TBX_TotalCost.ReadOnly = True
        Me.TBX_TotalCost.Size = New System.Drawing.Size(238, 22)
        Me.TBX_TotalCost.TabIndex = 49
        Me.TBX_TotalCost.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.TBX_TotalCost.Visible = False
        '
        'Label8
        '
        Me.Label8.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.White
        Me.Label8.Location = New System.Drawing.Point(595, 468)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(82, 16)
        Me.Label8.TabIndex = 48
        Me.Label8.Text = "Grand Total:"
        Me.Label8.Visible = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(12, 18)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(70, 31)
        Me.Label4.TabIndex = 47
        Me.Label4.Text = "STV"
        '
        'BTN_Save
        '
        Me.BTN_Save.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BTN_Save.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTN_Save.Location = New System.Drawing.Point(916, 507)
        Me.BTN_Save.Name = "BTN_Save"
        Me.BTN_Save.Size = New System.Drawing.Size(75, 28)
        Me.BTN_Save.TabIndex = 42
        Me.BTN_Save.Text = "Save"
        Me.BTN_Save.UseVisualStyleBackColor = True
        '
        'CMBX_TransferID
        '
        Me.CMBX_TransferID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.CMBX_TransferID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBX_TransferID.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBX_TransferID.FormattingEnabled = True
        Me.CMBX_TransferID.Location = New System.Drawing.Point(21, 85)
        Me.CMBX_TransferID.Name = "CMBX_TransferID"
        Me.CMBX_TransferID.Size = New System.Drawing.Size(171, 26)
        Me.CMBX_TransferID.TabIndex = 50
        '
        'TBX_Remark
        '
        Me.TBX_Remark.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TBX_Remark.Location = New System.Drawing.Point(375, 85)
        Me.TBX_Remark.Multiline = True
        Me.TBX_Remark.Name = "TBX_Remark"
        Me.TBX_Remark.Size = New System.Drawing.Size(193, 24)
        Me.TBX_Remark.TabIndex = 54
        '
        'LBL_RequisitionRemark
        '
        Me.LBL_RequisitionRemark.AutoSize = True
        Me.LBL_RequisitionRemark.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBL_RequisitionRemark.ForeColor = System.Drawing.Color.White
        Me.LBL_RequisitionRemark.Location = New System.Drawing.Point(372, 66)
        Me.LBL_RequisitionRemark.Name = "LBL_RequisitionRemark"
        Me.LBL_RequisitionRemark.Size = New System.Drawing.Size(59, 16)
        Me.LBL_RequisitionRemark.TabIndex = 52
        Me.LBL_RequisitionRemark.Text = "Remark:"
        '
        'DTP_VoucherDate
        '
        Me.DTP_VoucherDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DTP_VoucherDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DTP_VoucherDate.Location = New System.Drawing.Point(198, 85)
        Me.DTP_VoucherDate.Name = "DTP_VoucherDate"
        Me.DTP_VoucherDate.Size = New System.Drawing.Size(171, 24)
        Me.DTP_VoucherDate.TabIndex = 51
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(18, 66)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(59, 16)
        Me.Label3.TabIndex = 55
        Me.Label3.Text = "STV No:"
        '
        'LBL_RequisitionVoucherDate
        '
        Me.LBL_RequisitionVoucherDate.AutoSize = True
        Me.LBL_RequisitionVoucherDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBL_RequisitionVoucherDate.ForeColor = System.Drawing.Color.White
        Me.LBL_RequisitionVoucherDate.Location = New System.Drawing.Point(195, 66)
        Me.LBL_RequisitionVoucherDate.Name = "LBL_RequisitionVoucherDate"
        Me.LBL_RequisitionVoucherDate.Size = New System.Drawing.Size(40, 16)
        Me.LBL_RequisitionVoucherDate.TabIndex = 53
        Me.LBL_RequisitionVoucherDate.Text = "Date:"
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
        Me.DGV_Items.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ItemID, Me.Item_Name, Me.UOM, Me.Batch, Me.Expiry_Date, Me.locationTo, Me.Batch_Location, Me.Qty_Available, Me.Qty_AllAvailable, Me.Adj_Consm, Me.Qty_Requested, Me.Qty, Me.Cost, Me.Amount, Me.Remark})
        Me.DGV_Items.Location = New System.Drawing.Point(18, 141)
        Me.DGV_Items.MultiSelect = False
        Me.DGV_Items.Name = "DGV_Items"
        Me.DGV_Items.RowHeadersWidth = 20
        Me.DGV_Items.Size = New System.Drawing.Size(1143, 318)
        Me.DGV_Items.TabIndex = 41
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
        'locationTo
        '
        Me.locationTo.HeaderText = "Location To"
        Me.locationTo.Name = "locationTo"
        '
        'Batch_Location
        '
        Me.Batch_Location.FillWeight = 150.0!
        Me.Batch_Location.HeaderText = "Batch Location"
        Me.Batch_Location.Name = "Batch_Location"
        '
        'Qty_Available
        '
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight
        DataGridViewCellStyle1.Format = "N2"
        Me.Qty_Available.DefaultCellStyle = DataGridViewCellStyle1
        Me.Qty_Available.HeaderText = "Qty Available Batch"
        Me.Qty_Available.Name = "Qty_Available"
        Me.Qty_Available.ReadOnly = True
        '
        'Qty_AllAvailable
        '
        DataGridViewCellStyle2.Format = "N2"
        Me.Qty_AllAvailable.DefaultCellStyle = DataGridViewCellStyle2
        Me.Qty_AllAvailable.HeaderText = "Qty Available Items"
        Me.Qty_AllAvailable.Name = "Qty_AllAvailable"
        Me.Qty_AllAvailable.ReadOnly = True
        Me.Qty_AllAvailable.Visible = False
        '
        'Adj_Consm
        '
        Me.Adj_Consm.HeaderText = "Adjusted Consumption"
        Me.Adj_Consm.Name = "Adj_Consm"
        Me.Adj_Consm.ReadOnly = True
        Me.Adj_Consm.Visible = False
        '
        'Qty_Requested
        '
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight
        DataGridViewCellStyle3.Format = "N2"
        Me.Qty_Requested.DefaultCellStyle = DataGridViewCellStyle3
        Me.Qty_Requested.FillWeight = 78.67783!
        Me.Qty_Requested.HeaderText = "Qty Requested"
        Me.Qty_Requested.Name = "Qty_Requested"
        Me.Qty_Requested.ReadOnly = True
        Me.Qty_Requested.Visible = False
        '
        'Qty
        '
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight
        DataGridViewCellStyle4.Format = "N2"
        Me.Qty.DefaultCellStyle = DataGridViewCellStyle4
        Me.Qty.FillWeight = 78.67783!
        Me.Qty.HeaderText = "Qty"
        Me.Qty.Name = "Qty"
        '
        'Cost
        '
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight
        DataGridViewCellStyle5.Format = "N2"
        Me.Cost.DefaultCellStyle = DataGridViewCellStyle5
        Me.Cost.FillWeight = 72.09082!
        Me.Cost.HeaderText = "Unit Price"
        Me.Cost.Name = "Cost"
        Me.Cost.ReadOnly = True
        Me.Cost.Visible = False
        '
        'Amount
        '
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight
        DataGridViewCellStyle6.Format = "N2"
        Me.Amount.DefaultCellStyle = DataGridViewCellStyle6
        Me.Amount.HeaderText = "Total Price"
        Me.Amount.Name = "Amount"
        Me.Amount.ReadOnly = True
        Me.Amount.Visible = False
        '
        'Remark
        '
        Me.Remark.HeaderText = "Remark"
        Me.Remark.Name = "Remark"
        '
        'DataGridViewTextBoxColumn7
        '
        Me.DataGridViewTextBoxColumn7.FillWeight = 78.67783!
        Me.DataGridViewTextBoxColumn7.HeaderText = "Qty Received"
        Me.DataGridViewTextBoxColumn7.Name = "DataGridViewTextBoxColumn7"
        Me.DataGridViewTextBoxColumn7.ReadOnly = True
        Me.DataGridViewTextBoxColumn7.Width = 96
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.FillWeight = 60.19803!
        Me.DataGridViewTextBoxColumn1.HeaderText = "Item Code"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        Me.DataGridViewTextBoxColumn1.Width = 74
        '
        'DataGridViewTextBoxColumn8
        '
        Me.DataGridViewTextBoxColumn8.FillWeight = 72.09082!
        Me.DataGridViewTextBoxColumn8.HeaderText = "Cost"
        Me.DataGridViewTextBoxColumn8.Name = "DataGridViewTextBoxColumn8"
        Me.DataGridViewTextBoxColumn8.ReadOnly = True
        Me.DataGridViewTextBoxColumn8.Width = 88
        '
        'DataGridViewTextBoxColumn6
        '
        Me.DataGridViewTextBoxColumn6.FillWeight = 78.67783!
        Me.DataGridViewTextBoxColumn6.HeaderText = "Qty Requested"
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        Me.DataGridViewTextBoxColumn6.ReadOnly = True
        Me.DataGridViewTextBoxColumn6.Width = 96
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.FillWeight = 150.0!
        Me.DataGridViewTextBoxColumn2.HeaderText = "Item Name"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        Me.DataGridViewTextBoxColumn2.Width = 183
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.HeaderText = "Batch Location"
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        Me.DataGridViewTextBoxColumn5.ReadOnly = True
        Me.DataGridViewTextBoxColumn5.Width = 123
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
        'STVForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.SlateGray
        Me.ClientSize = New System.Drawing.Size(1173, 547)
        Me.Controls.Add(Me.CMBX_TransferID)
        Me.Controls.Add(Me.TBX_Remark)
        Me.Controls.Add(Me.LBL_RequisitionRemark)
        Me.Controls.Add(Me.DTP_VoucherDate)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.LBL_RequisitionVoucherDate)
        Me.Controls.Add(Me.BTN_Close)
        Me.Controls.Add(Me.BTN_Print)
        Me.Controls.Add(Me.TBX_TotalCost)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.DGV_Items)
        Me.Controls.Add(Me.BTN_Save)
        Me.Name = "STVForm"
        Me.Text = "STVForm"
        CType(Me.ERP_Error, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DGV_Items, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents BTN_Close As System.Windows.Forms.Button
    Friend WithEvents DataGridViewTextBoxColumn7 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn8 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ERP_Error As System.Windows.Forms.ErrorProvider
    Friend WithEvents BTN_Print As System.Windows.Forms.Button
    Friend WithEvents TBX_TotalCost As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents DGV_Items As LMIS.DGV_ItemsRef
    Friend WithEvents BTN_Save As System.Windows.Forms.Button
    Friend WithEvents CMBX_TransferID As System.Windows.Forms.ComboBox
    Friend WithEvents TBX_Remark As System.Windows.Forms.TextBox
    Friend WithEvents LBL_RequisitionRemark As System.Windows.Forms.Label
    Friend WithEvents DTP_VoucherDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents LBL_RequisitionVoucherDate As System.Windows.Forms.Label
    Friend WithEvents ItemID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Item_Name As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents UOM As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Batch As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Expiry_Date As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents locationTo As System.Windows.Forms.DataGridViewTextBoxColumn
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
