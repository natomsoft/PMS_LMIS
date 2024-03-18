<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FRM_IJOPD
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
        Me.BTN_Close = New System.Windows.Forms.Button()
        Me.BTN_Save = New System.Windows.Forms.Button()
        Me.TBX_Remark = New System.Windows.Forms.TextBox()
        Me.DTP_VoucherDate = New System.Windows.Forms.DateTimePicker()
        Me.LBL_RequisitionRemark = New System.Windows.Forms.Label()
        Me.LBL_RequisitionVoucherDate = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.CMBX_OPDIssueID = New System.Windows.Forms.ComboBox()
        Me.TBX_TotalCost = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.ERP_Error = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.LBL_Title = New System.Windows.Forms.Label()
        Me.LineShape2 = New Microsoft.VisualBasic.PowerPacks.LineShape()
        Me.LineShape1 = New Microsoft.VisualBasic.PowerPacks.LineShape()
        Me.LineShape3 = New Microsoft.VisualBasic.PowerPacks.LineShape()
        Me.ShapeContainer1 = New Microsoft.VisualBasic.PowerPacks.ShapeContainer()
        Me.LineShape4 = New Microsoft.VisualBasic.PowerPacks.LineShape()
        Me.BTN_SaveNReport = New System.Windows.Forms.Button()
        Me.CMBX_Name = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.CMBX_PaymentType = New System.Windows.Forms.ComboBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.CMBX_IDNO = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.CMBX_Country = New System.Windows.Forms.ComboBox()
        Me.TBX_Email = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.TBX_PhoneNo = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.CMBX_Gender = New System.Windows.Forms.ComboBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.CHBX_NewPerson = New System.Windows.Forms.CheckBox()
        Me.CMBX_Company = New System.Windows.Forms.ComboBox()
        Me.CMBX_LName = New System.Windows.Forms.TextBox()
        Me.CMBX_MName = New System.Windows.Forms.TextBox()
        Me.CMBX_FName = New System.Windows.Forms.TextBox()
        Me.BTN_Post = New System.Windows.Forms.Button()
        Me.CMBX_DispersedBy = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.CMBX_Prescribedby = New System.Windows.Forms.ComboBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.TBX_CardNo = New System.Windows.Forms.TextBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.NUD_Age = New System.Windows.Forms.NumericUpDown()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.CMBX_CardNo = New System.Windows.Forms.ComboBox()
        Me.DGV_Items = New LMIS.DGV_ItemsRef()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn8 = New System.Windows.Forms.DataGridViewTextBoxColumn()
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
        CType(Me.ERP_Error, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NUD_Age, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DGV_Items, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BTN_Close
        '
        Me.BTN_Close.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BTN_Close.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTN_Close.Location = New System.Drawing.Point(856, 538)
        Me.BTN_Close.Name = "BTN_Close"
        Me.BTN_Close.Size = New System.Drawing.Size(75, 28)
        Me.BTN_Close.TabIndex = 21
        Me.BTN_Close.Text = "Close"
        Me.BTN_Close.UseVisualStyleBackColor = True
        '
        'BTN_Save
        '
        Me.BTN_Save.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BTN_Save.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTN_Save.Location = New System.Drawing.Point(368, 538)
        Me.BTN_Save.Name = "BTN_Save"
        Me.BTN_Save.Size = New System.Drawing.Size(75, 28)
        Me.BTN_Save.TabIndex = 58
        Me.BTN_Save.Text = "Save"
        Me.BTN_Save.UseVisualStyleBackColor = True
        Me.BTN_Save.Visible = False
        '
        'TBX_Remark
        '
        Me.TBX_Remark.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TBX_Remark.Location = New System.Drawing.Point(556, 78)
        Me.TBX_Remark.Multiline = True
        Me.TBX_Remark.Name = "TBX_Remark"
        Me.TBX_Remark.Size = New System.Drawing.Size(372, 24)
        Me.TBX_Remark.TabIndex = 2
        '
        'DTP_VoucherDate
        '
        Me.DTP_VoucherDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DTP_VoucherDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DTP_VoucherDate.Location = New System.Drawing.Point(378, 78)
        Me.DTP_VoucherDate.Name = "DTP_VoucherDate"
        Me.DTP_VoucherDate.Size = New System.Drawing.Size(171, 24)
        Me.DTP_VoucherDate.TabIndex = 1
        '
        'LBL_RequisitionRemark
        '
        Me.LBL_RequisitionRemark.AutoSize = True
        Me.LBL_RequisitionRemark.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBL_RequisitionRemark.ForeColor = System.Drawing.Color.White
        Me.LBL_RequisitionRemark.Location = New System.Drawing.Point(553, 61)
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
        Me.LBL_RequisitionVoucherDate.Location = New System.Drawing.Point(375, 61)
        Me.LBL_RequisitionVoucherDate.Name = "LBL_RequisitionVoucherDate"
        Me.LBL_RequisitionVoucherDate.Size = New System.Drawing.Size(40, 16)
        Me.LBL_RequisitionVoucherDate.TabIndex = 3
        Me.LBL_RequisitionVoucherDate.Text = "Date:"
        Me.LBL_RequisitionVoucherDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(15, 61)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(99, 16)
        Me.Label3.TabIndex = 9
        Me.Label3.Text = "Requisition No:"
        '
        'CMBX_OPDIssueID
        '
        Me.CMBX_OPDIssueID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.CMBX_OPDIssueID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBX_OPDIssueID.DropDownWidth = 250
        Me.CMBX_OPDIssueID.Enabled = False
        Me.CMBX_OPDIssueID.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBX_OPDIssueID.FormattingEnabled = True
        Me.CMBX_OPDIssueID.Location = New System.Drawing.Point(18, 78)
        Me.CMBX_OPDIssueID.Name = "CMBX_OPDIssueID"
        Me.CMBX_OPDIssueID.Size = New System.Drawing.Size(171, 26)
        Me.CMBX_OPDIssueID.TabIndex = 0
        '
        'TBX_TotalCost
        '
        Me.TBX_TotalCost.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TBX_TotalCost.Enabled = False
        Me.TBX_TotalCost.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TBX_TotalCost.Location = New System.Drawing.Point(690, 497)
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
        Me.Label8.Location = New System.Drawing.Point(605, 500)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(82, 16)
        Me.Label8.TabIndex = 30
        Me.Label8.Text = "Grand Total:"
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
        Me.LBL_Title.Size = New System.Drawing.Size(76, 31)
        Me.LBL_Title.TabIndex = 15
        Me.LBL_Title.Text = "OPD"
        '
        'LineShape2
        '
        Me.LineShape2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LineShape2.BorderColor = System.Drawing.Color.LightGray
        Me.LineShape2.Name = "LineShape2"
        Me.LineShape2.X1 = 14
        Me.LineShape2.X2 = 940
        Me.LineShape2.Y1 = 326
        Me.LineShape2.Y2 = 326
        '
        'LineShape1
        '
        Me.LineShape1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LineShape1.BorderColor = System.Drawing.Color.LightGray
        Me.LineShape1.Name = "LineShape1"
        Me.LineShape1.X1 = 14
        Me.LineShape1.X2 = 940
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
        Me.LineShape3.X2 = 940
        Me.LineShape3.Y1 = 526
        Me.LineShape3.Y2 = 526
        '
        'ShapeContainer1
        '
        Me.ShapeContainer1.Location = New System.Drawing.Point(0, 0)
        Me.ShapeContainer1.Margin = New System.Windows.Forms.Padding(0)
        Me.ShapeContainer1.Name = "ShapeContainer1"
        Me.ShapeContainer1.Shapes.AddRange(New Microsoft.VisualBasic.PowerPacks.Shape() {Me.LineShape4, Me.LineShape3, Me.LineShape1, Me.LineShape2})
        Me.ShapeContainer1.Size = New System.Drawing.Size(954, 578)
        Me.ShapeContainer1.TabIndex = 32
        Me.ShapeContainer1.TabStop = False
        '
        'LineShape4
        '
        Me.LineShape4.BorderColor = System.Drawing.Color.LightGray
        Me.LineShape4.Name = "LineShape4"
        Me.LineShape4.X1 = 470
        Me.LineShape4.X2 = 470
        Me.LineShape4.Y1 = 154
        Me.LineShape4.Y2 = 303
        '
        'BTN_SaveNReport
        '
        Me.BTN_SaveNReport.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BTN_SaveNReport.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTN_SaveNReport.Location = New System.Drawing.Point(694, 539)
        Me.BTN_SaveNReport.Name = "BTN_SaveNReport"
        Me.BTN_SaveNReport.Size = New System.Drawing.Size(75, 28)
        Me.BTN_SaveNReport.TabIndex = 19
        Me.BTN_SaveNReport.Text = "Save"
        Me.BTN_SaveNReport.UseVisualStyleBackColor = True
        '
        'CMBX_Name
        '
        Me.CMBX_Name.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.CMBX_Name.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBX_Name.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBX_Name.FormattingEnabled = True
        Me.CMBX_Name.Location = New System.Drawing.Point(161, 152)
        Me.CMBX_Name.Name = "CMBX_Name"
        Me.CMBX_Name.Size = New System.Drawing.Size(283, 24)
        Me.CMBX_Name.TabIndex = 4
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(158, 133)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(48, 16)
        Me.Label1.TabIndex = 84
        Me.Label1.Text = "Name:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.White
        Me.Label7.Location = New System.Drawing.Point(17, 133)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(73, 16)
        Me.Label7.TabIndex = 89
        Me.Label7.Text = "Eritrean ID:"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'CMBX_PaymentType
        '
        Me.CMBX_PaymentType.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.CMBX_PaymentType.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBX_PaymentType.FormattingEnabled = True
        Me.CMBX_PaymentType.Location = New System.Drawing.Point(490, 196)
        Me.CMBX_PaymentType.Name = "CMBX_PaymentType"
        Me.CMBX_PaymentType.Size = New System.Drawing.Size(211, 24)
        Me.CMBX_PaymentType.TabIndex = 14
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.White
        Me.Label9.Location = New System.Drawing.Point(487, 177)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(99, 16)
        Me.Label9.TabIndex = 92
        Me.Label9.Text = "Payment Type:"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.White
        Me.Label10.Location = New System.Drawing.Point(718, 177)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(65, 16)
        Me.Label10.TabIndex = 94
        Me.Label10.Text = "Institution:"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'CMBX_IDNO
        '
        Me.CMBX_IDNO.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.CMBX_IDNO.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBX_IDNO.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBX_IDNO.FormattingEnabled = True
        Me.CMBX_IDNO.Location = New System.Drawing.Point(19, 152)
        Me.CMBX_IDNO.Name = "CMBX_IDNO"
        Me.CMBX_IDNO.Size = New System.Drawing.Size(128, 24)
        Me.CMBX_IDNO.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(16, 225)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(36, 16)
        Me.Label2.TabIndex = 115
        Me.Label2.Text = "Age:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(304, 225)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(74, 16)
        Me.Label4.TabIndex = 110
        Me.Label4.Text = "Nationality:"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'CMBX_Country
        '
        Me.CMBX_Country.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.CMBX_Country.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBX_Country.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBX_Country.FormattingEnabled = True
        Me.CMBX_Country.Location = New System.Drawing.Point(304, 242)
        Me.CMBX_Country.Name = "CMBX_Country"
        Me.CMBX_Country.Size = New System.Drawing.Size(139, 24)
        Me.CMBX_Country.TabIndex = 12
        '
        'TBX_Email
        '
        Me.TBX_Email.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TBX_Email.Location = New System.Drawing.Point(164, 288)
        Me.TBX_Email.Name = "TBX_Email"
        Me.TBX_Email.Size = New System.Drawing.Size(279, 22)
        Me.TBX_Email.TabIndex = 10
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.White
        Me.Label6.Location = New System.Drawing.Point(161, 269)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(62, 16)
        Me.Label6.TabIndex = 109
        Me.Label6.Text = "Address:"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TBX_PhoneNo
        '
        Me.TBX_PhoneNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TBX_PhoneNo.Location = New System.Drawing.Point(20, 288)
        Me.TBX_PhoneNo.Name = "TBX_PhoneNo"
        Me.TBX_PhoneNo.Size = New System.Drawing.Size(125, 22)
        Me.TBX_PhoneNo.TabIndex = 9
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.White
        Me.Label11.Location = New System.Drawing.Point(17, 269)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(101, 16)
        Me.Label11.TabIndex = 108
        Me.Label11.Text = "Phone Number:"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.White
        Me.Label12.Location = New System.Drawing.Point(302, 179)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(76, 16)
        Me.Label12.TabIndex = 107
        Me.Label12.Text = "Last Name:"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.White
        Me.Label13.Location = New System.Drawing.Point(158, 179)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(92, 16)
        Me.Label13.TabIndex = 106
        Me.Label13.Text = "Middle Name:"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.White
        Me.Label14.Location = New System.Drawing.Point(158, 225)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(34, 16)
        Me.Label14.TabIndex = 105
        Me.Label14.Text = "Sex:"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'CMBX_Gender
        '
        Me.CMBX_Gender.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBX_Gender.FormattingEnabled = True
        Me.CMBX_Gender.Items.AddRange(New Object() {"Female", "Male"})
        Me.CMBX_Gender.Location = New System.Drawing.Point(161, 244)
        Me.CMBX_Gender.Name = "CMBX_Gender"
        Me.CMBX_Gender.Size = New System.Drawing.Size(128, 24)
        Me.CMBX_Gender.TabIndex = 11
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.Color.White
        Me.Label15.Location = New System.Drawing.Point(16, 179)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(76, 16)
        Me.Label15.TabIndex = 104
        Me.Label15.Text = "First Name:"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'CHBX_NewPerson
        '
        Me.CHBX_NewPerson.AutoSize = True
        Me.CHBX_NewPerson.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CHBX_NewPerson.ForeColor = System.Drawing.Color.White
        Me.CHBX_NewPerson.Location = New System.Drawing.Point(18, 110)
        Me.CHBX_NewPerson.Name = "CHBX_NewPerson"
        Me.CHBX_NewPerson.Size = New System.Drawing.Size(106, 22)
        Me.CHBX_NewPerson.TabIndex = 3
        Me.CHBX_NewPerson.Text = "New Patient"
        Me.CHBX_NewPerson.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.CHBX_NewPerson.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.CHBX_NewPerson.UseVisualStyleBackColor = True
        Me.CHBX_NewPerson.Visible = False
        '
        'CMBX_Company
        '
        Me.CMBX_Company.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBX_Company.FormattingEnabled = True
        Me.CMBX_Company.Location = New System.Drawing.Point(721, 196)
        Me.CMBX_Company.Name = "CMBX_Company"
        Me.CMBX_Company.Size = New System.Drawing.Size(207, 24)
        Me.CMBX_Company.TabIndex = 15
        '
        'CMBX_LName
        '
        Me.CMBX_LName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.CMBX_LName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.CMBX_LName.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBX_LName.Location = New System.Drawing.Point(305, 198)
        Me.CMBX_LName.Name = "CMBX_LName"
        Me.CMBX_LName.Size = New System.Drawing.Size(139, 22)
        Me.CMBX_LName.TabIndex = 7
        '
        'CMBX_MName
        '
        Me.CMBX_MName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.CMBX_MName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.CMBX_MName.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBX_MName.Location = New System.Drawing.Point(161, 198)
        Me.CMBX_MName.Name = "CMBX_MName"
        Me.CMBX_MName.Size = New System.Drawing.Size(128, 22)
        Me.CMBX_MName.TabIndex = 6
        '
        'CMBX_FName
        '
        Me.CMBX_FName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.CMBX_FName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource
        Me.CMBX_FName.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBX_FName.Location = New System.Drawing.Point(19, 198)
        Me.CMBX_FName.Name = "CMBX_FName"
        Me.CMBX_FName.Size = New System.Drawing.Size(128, 22)
        Me.CMBX_FName.TabIndex = 5
        '
        'BTN_Post
        '
        Me.BTN_Post.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BTN_Post.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTN_Post.Location = New System.Drawing.Point(775, 539)
        Me.BTN_Post.Name = "BTN_Post"
        Me.BTN_Post.Size = New System.Drawing.Size(75, 27)
        Me.BTN_Post.TabIndex = 20
        Me.BTN_Post.Text = "Post"
        Me.BTN_Post.UseVisualStyleBackColor = True
        '
        'CMBX_DispersedBy
        '
        Me.CMBX_DispersedBy.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.CMBX_DispersedBy.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBX_DispersedBy.FormattingEnabled = True
        Me.CMBX_DispersedBy.Location = New System.Drawing.Point(721, 242)
        Me.CMBX_DispersedBy.Name = "CMBX_DispersedBy"
        Me.CMBX_DispersedBy.Size = New System.Drawing.Size(207, 24)
        Me.CMBX_DispersedBy.TabIndex = 17
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(718, 223)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(96, 16)
        Me.Label5.TabIndex = 122
        Me.Label5.Text = "Dispensed By:"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'CMBX_Prescribedby
        '
        Me.CMBX_Prescribedby.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.CMBX_Prescribedby.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBX_Prescribedby.FormattingEnabled = True
        Me.CMBX_Prescribedby.Location = New System.Drawing.Point(490, 242)
        Me.CMBX_Prescribedby.Name = "CMBX_Prescribedby"
        Me.CMBX_Prescribedby.Size = New System.Drawing.Size(211, 24)
        Me.CMBX_Prescribedby.TabIndex = 16
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.Color.White
        Me.Label16.Location = New System.Drawing.Point(487, 223)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(96, 16)
        Me.Label16.TabIndex = 121
        Me.Label16.Text = "Prescribed By:"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'TBX_CardNo
        '
        Me.TBX_CardNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TBX_CardNo.Location = New System.Drawing.Point(490, 152)
        Me.TBX_CardNo.Name = "TBX_CardNo"
        Me.TBX_CardNo.Size = New System.Drawing.Size(211, 22)
        Me.TBX_CardNo.TabIndex = 13
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.ForeColor = System.Drawing.Color.White
        Me.Label18.Location = New System.Drawing.Point(487, 133)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(91, 16)
        Me.Label18.TabIndex = 148
        Me.Label18.Text = "Card Number:"
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'NUD_Age
        '
        Me.NUD_Age.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NUD_Age.Location = New System.Drawing.Point(19, 245)
        Me.NUD_Age.Name = "NUD_Age"
        Me.NUD_Age.Size = New System.Drawing.Size(128, 21)
        Me.NUD_Age.TabIndex = 8
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.ForeColor = System.Drawing.Color.White
        Me.Label17.Location = New System.Drawing.Point(195, 61)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(61, 16)
        Me.Label17.TabIndex = 150
        Me.Label17.Text = "Card No:"
        '
        'CMBX_CardNo
        '
        Me.CMBX_CardNo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.CMBX_CardNo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBX_CardNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBX_CardNo.FormattingEnabled = True
        Me.CMBX_CardNo.Location = New System.Drawing.Point(198, 78)
        Me.CMBX_CardNo.Name = "CMBX_CardNo"
        Me.CMBX_CardNo.Size = New System.Drawing.Size(171, 26)
        Me.CMBX_CardNo.TabIndex = 149
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
        Me.DGV_Items.Location = New System.Drawing.Point(18, 335)
        Me.DGV_Items.MultiSelect = False
        Me.DGV_Items.Name = "DGV_Items"
        Me.DGV_Items.RowHeadersWidth = 20
        Me.DGV_Items.Size = New System.Drawing.Size(910, 156)
        Me.DGV_Items.TabIndex = 18
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
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.Silver
        Me.Expiry_Date.DefaultCellStyle = DataGridViewCellStyle1
        Me.Expiry_Date.HeaderText = "Exp Date"
        Me.Expiry_Date.Name = "Expiry_Date"
        Me.Expiry_Date.ReadOnly = True
        '
        'Batch_Location
        '
        Me.Batch_Location.FillWeight = 150.0!
        Me.Batch_Location.HeaderText = "Batch Location"
        Me.Batch_Location.Name = "Batch_Location"
        Me.Batch_Location.Visible = False
        '
        'Qty_Available
        '
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight
        DataGridViewCellStyle2.Format = "N2"
        Me.Qty_Available.DefaultCellStyle = DataGridViewCellStyle2
        Me.Qty_Available.HeaderText = "Qty Available"
        Me.Qty_Available.Name = "Qty_Available"
        Me.Qty_Available.ReadOnly = True
        '
        'Qty
        '
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight
        DataGridViewCellStyle3.Format = "N2"
        Me.Qty.DefaultCellStyle = DataGridViewCellStyle3
        Me.Qty.FillWeight = 78.67783!
        Me.Qty.HeaderText = "Qty Issued"
        Me.Qty.Name = "Qty"
        '
        'Cost
        '
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight
        DataGridViewCellStyle4.Format = "N2"
        Me.Cost.DefaultCellStyle = DataGridViewCellStyle4
        Me.Cost.FillWeight = 72.09082!
        Me.Cost.HeaderText = "Unit Price"
        Me.Cost.Name = "Cost"
        Me.Cost.ReadOnly = True
        '
        'Amount
        '
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight
        DataGridViewCellStyle5.Format = "N2"
        Me.Amount.DefaultCellStyle = DataGridViewCellStyle5
        Me.Amount.HeaderText = "Total Price"
        Me.Amount.Name = "Amount"
        Me.Amount.ReadOnly = True
        '
        'Remark
        '
        Me.Remark.HeaderText = "Remark"
        Me.Remark.Name = "Remark"
        '
        'FRM_IJOPD
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.SlateGray
        Me.ClientSize = New System.Drawing.Size(954, 578)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.CMBX_CardNo)
        Me.Controls.Add(Me.NUD_Age)
        Me.Controls.Add(Me.TBX_CardNo)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.CMBX_DispersedBy)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.CMBX_Prescribedby)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.BTN_Post)
        Me.Controls.Add(Me.CMBX_LName)
        Me.Controls.Add(Me.CMBX_MName)
        Me.Controls.Add(Me.CMBX_FName)
        Me.Controls.Add(Me.CMBX_Company)
        Me.Controls.Add(Me.CHBX_NewPerson)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.CMBX_Country)
        Me.Controls.Add(Me.TBX_Email)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.TBX_PhoneNo)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.CMBX_Gender)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.CMBX_IDNO)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.CMBX_PaymentType)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.CMBX_Name)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.BTN_SaveNReport)
        Me.Controls.Add(Me.TBX_TotalCost)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.LBL_Title)
        Me.Controls.Add(Me.DGV_Items)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.LBL_RequisitionVoucherDate)
        Me.Controls.Add(Me.BTN_Save)
        Me.Controls.Add(Me.DTP_VoucherDate)
        Me.Controls.Add(Me.BTN_Close)
        Me.Controls.Add(Me.CMBX_OPDIssueID)
        Me.Controls.Add(Me.LBL_RequisitionRemark)
        Me.Controls.Add(Me.TBX_Remark)
        Me.Controls.Add(Me.ShapeContainer1)
        Me.Name = "FRM_IJOPD"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Patient OPD"
        CType(Me.ERP_Error, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NUD_Age, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents CMBX_OPDIssueID As System.Windows.Forms.ComboBox
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
    Friend WithEvents LBL_Title As System.Windows.Forms.Label
    Friend WithEvents ShapeContainer1 As Microsoft.VisualBasic.PowerPacks.ShapeContainer
    Friend WithEvents LineShape3 As Microsoft.VisualBasic.PowerPacks.LineShape
    Friend WithEvents LineShape1 As Microsoft.VisualBasic.PowerPacks.LineShape
    Friend WithEvents LineShape2 As Microsoft.VisualBasic.PowerPacks.LineShape
    Friend WithEvents BTN_SaveNReport As System.Windows.Forms.Button
    Friend WithEvents CMBX_Name As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents CMBX_PaymentType As System.Windows.Forms.ComboBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents CMBX_IDNO As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents CMBX_Country As System.Windows.Forms.ComboBox
    Friend WithEvents TBX_Email As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents TBX_PhoneNo As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents CMBX_Gender As System.Windows.Forms.ComboBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents CHBX_NewPerson As System.Windows.Forms.CheckBox
    Friend WithEvents CMBX_Company As System.Windows.Forms.ComboBox
    Friend WithEvents LineShape4 As Microsoft.VisualBasic.PowerPacks.LineShape
    Friend WithEvents CMBX_LName As System.Windows.Forms.TextBox
    Friend WithEvents CMBX_MName As System.Windows.Forms.TextBox
    Friend WithEvents CMBX_FName As System.Windows.Forms.TextBox
    Friend WithEvents BTN_Post As System.Windows.Forms.Button
    Friend WithEvents CMBX_DispersedBy As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents CMBX_Prescribedby As System.Windows.Forms.ComboBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents TBX_CardNo As System.Windows.Forms.TextBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents NUD_Age As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents CMBX_CardNo As System.Windows.Forms.ComboBox
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
End Class
