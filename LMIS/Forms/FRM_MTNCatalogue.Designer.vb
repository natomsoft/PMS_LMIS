<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FRM_MTNCatalogue
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
        Me.TBX_ItemName = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.CMBX_Category = New System.Windows.Forms.ComboBox()
        Me.CHBX_ItemExpires = New System.Windows.Forms.CheckBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.CMBX_PrescriptionStatus = New System.Windows.Forms.ComboBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.CMBX_LevelOfUse = New System.Windows.Forms.ComboBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.CMBX_RouteOfAdministration = New System.Windows.Forms.ComboBox()
        Me.BTN_Save = New System.Windows.Forms.Button()
        Me.BTN_Close = New System.Windows.Forms.Button()
        Me.ERP_Error = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.Label16 = New System.Windows.Forms.Label()
        Me.CMBX_TherapeuticClass = New System.Windows.Forms.ComboBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.LineShape1 = New Microsoft.VisualBasic.PowerPacks.LineShape()
        Me.ShapeContainer1 = New Microsoft.VisualBasic.PowerPacks.ShapeContainer()
        Me.LineShape6 = New Microsoft.VisualBasic.PowerPacks.LineShape()
        Me.LineShape5 = New Microsoft.VisualBasic.PowerPacks.LineShape()
        Me.LineShape4 = New Microsoft.VisualBasic.PowerPacks.LineShape()
        Me.LineShape2 = New Microsoft.VisualBasic.PowerPacks.LineShape()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.CMBX_ItemCatalogueID = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.CMBX_ItemCatalogueName = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.DGV_Items = New LMIS.DGV_G()
        Me.ItemID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ItemIDOriginal = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Item_Name = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Old_Item_Code = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Unit = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.MinQty = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.MaxQty = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ReorderQty = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DGV_SR = New LMIS.DGV_G()
        Me.SRType = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SRID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Minimum = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Maximum = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn8 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn9 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PackSize = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.ERP_Error, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DGV_Items, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DGV_SR, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TBX_ItemName
        '
        Me.TBX_ItemName.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TBX_ItemName.Location = New System.Drawing.Point(144, 93)
        Me.TBX_ItemName.Name = "TBX_ItemName"
        Me.TBX_ItemName.Size = New System.Drawing.Size(231, 22)
        Me.TBX_ItemName.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(22, 96)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(76, 16)
        Me.Label1.TabIndex = 24
        Me.Label1.Text = "Item Name:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.White
        Me.Label6.Location = New System.Drawing.Point(22, 124)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(115, 16)
        Me.Label6.TabIndex = 26
        Me.Label6.Text = "Sub classification:"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'CMBX_Category
        '
        Me.CMBX_Category.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBX_Category.FormattingEnabled = True
        Me.CMBX_Category.Location = New System.Drawing.Point(144, 121)
        Me.CMBX_Category.Name = "CMBX_Category"
        Me.CMBX_Category.Size = New System.Drawing.Size(231, 24)
        Me.CMBX_Category.TabIndex = 4
        '
        'CHBX_ItemExpires
        '
        Me.CHBX_ItemExpires.AutoSize = True
        Me.CHBX_ItemExpires.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CHBX_ItemExpires.ForeColor = System.Drawing.Color.White
        Me.CHBX_ItemExpires.Location = New System.Drawing.Point(144, 151)
        Me.CHBX_ItemExpires.Name = "CHBX_ItemExpires"
        Me.CHBX_ItemExpires.Size = New System.Drawing.Size(103, 20)
        Me.CHBX_ItemExpires.TabIndex = 5
        Me.CHBX_ItemExpires.Text = "Item Expires:"
        Me.CHBX_ItemExpires.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.CHBX_ItemExpires.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.CHBX_ItemExpires.UseVisualStyleBackColor = True
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.White
        Me.Label8.Location = New System.Drawing.Point(20, 180)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(120, 16)
        Me.Label8.TabIndex = 37
        Me.Label8.Text = "Therapeutic Class:"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.White
        Me.Label9.Location = New System.Drawing.Point(22, 210)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(122, 16)
        Me.Label9.TabIndex = 39
        Me.Label9.Text = "Prescription Status:"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'CMBX_PrescriptionStatus
        '
        Me.CMBX_PrescriptionStatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBX_PrescriptionStatus.FormattingEnabled = True
        Me.CMBX_PrescriptionStatus.Location = New System.Drawing.Point(144, 207)
        Me.CMBX_PrescriptionStatus.Name = "CMBX_PrescriptionStatus"
        Me.CMBX_PrescriptionStatus.Size = New System.Drawing.Size(231, 24)
        Me.CMBX_PrescriptionStatus.TabIndex = 7
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.White
        Me.Label10.Location = New System.Drawing.Point(396, 68)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(86, 16)
        Me.Label10.TabIndex = 41
        Me.Label10.Text = "Level of Use:"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'CMBX_LevelOfUse
        '
        Me.CMBX_LevelOfUse.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBX_LevelOfUse.FormattingEnabled = True
        Me.CMBX_LevelOfUse.Location = New System.Drawing.Point(517, 65)
        Me.CMBX_LevelOfUse.Name = "CMBX_LevelOfUse"
        Me.CMBX_LevelOfUse.Size = New System.Drawing.Size(229, 24)
        Me.CMBX_LevelOfUse.TabIndex = 8
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.White
        Me.Label11.Location = New System.Drawing.Point(396, 90)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(95, 32)
        Me.Label11.TabIndex = 43
        Me.Label11.Text = "Route of" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Administration:"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'CMBX_RouteOfAdministration
        '
        Me.CMBX_RouteOfAdministration.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBX_RouteOfAdministration.FormattingEnabled = True
        Me.CMBX_RouteOfAdministration.Location = New System.Drawing.Point(516, 95)
        Me.CMBX_RouteOfAdministration.Name = "CMBX_RouteOfAdministration"
        Me.CMBX_RouteOfAdministration.Size = New System.Drawing.Size(230, 24)
        Me.CMBX_RouteOfAdministration.TabIndex = 9
        '
        'BTN_Save
        '
        Me.BTN_Save.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTN_Save.Location = New System.Drawing.Point(590, 473)
        Me.BTN_Save.Name = "BTN_Save"
        Me.BTN_Save.Size = New System.Drawing.Size(75, 28)
        Me.BTN_Save.TabIndex = 12
        Me.BTN_Save.Text = "Save"
        Me.BTN_Save.UseVisualStyleBackColor = True
        '
        'BTN_Close
        '
        Me.BTN_Close.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTN_Close.Location = New System.Drawing.Point(671, 473)
        Me.BTN_Close.Name = "BTN_Close"
        Me.BTN_Close.Size = New System.Drawing.Size(75, 28)
        Me.BTN_Close.TabIndex = 13
        Me.BTN_Close.Text = "Close"
        Me.BTN_Close.UseVisualStyleBackColor = True
        '
        'ERP_Error
        '
        Me.ERP_Error.ContainerControl = Me
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.Color.White
        Me.Label16.Location = New System.Drawing.Point(20, 63)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(89, 16)
        Me.Label16.TabIndex = 57
        Me.Label16.Text = "Catalogue ID:"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'CMBX_TherapeuticClass
        '
        Me.CMBX_TherapeuticClass.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBX_TherapeuticClass.FormattingEnabled = True
        Me.CMBX_TherapeuticClass.Location = New System.Drawing.Point(144, 177)
        Me.CMBX_TherapeuticClass.Name = "CMBX_TherapeuticClass"
        Me.CMBX_TherapeuticClass.Size = New System.Drawing.Size(231, 24)
        Me.CMBX_TherapeuticClass.TabIndex = 6
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.ForeColor = System.Drawing.Color.White
        Me.Label17.Location = New System.Drawing.Point(396, 131)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(146, 16)
        Me.Label17.TabIndex = 60
        Me.Label17.Text = "Storage Requirements:"
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LineShape1
        '
        Me.LineShape1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LineShape1.BorderColor = System.Drawing.Color.LightGray
        Me.LineShape1.Name = "LineShape1"
        Me.LineShape1.X1 = 399
        Me.LineShape1.X2 = 751
        Me.LineShape1.Y1 = 150
        Me.LineShape1.Y2 = 150
        '
        'ShapeContainer1
        '
        Me.ShapeContainer1.Location = New System.Drawing.Point(0, 0)
        Me.ShapeContainer1.Margin = New System.Windows.Forms.Padding(0)
        Me.ShapeContainer1.Name = "ShapeContainer1"
        Me.ShapeContainer1.Shapes.AddRange(New Microsoft.VisualBasic.PowerPacks.Shape() {Me.LineShape6, Me.LineShape5, Me.LineShape4, Me.LineShape2, Me.LineShape1})
        Me.ShapeContainer1.Size = New System.Drawing.Size(767, 512)
        Me.ShapeContainer1.TabIndex = 61
        Me.ShapeContainer1.TabStop = False
        '
        'LineShape6
        '
        Me.LineShape6.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LineShape6.BorderColor = System.Drawing.Color.LightGray
        Me.LineShape6.Name = "LineShape6"
        Me.LineShape6.X1 = 11
        Me.LineShape6.X2 = 758
        Me.LineShape6.Y1 = 461
        Me.LineShape6.Y2 = 461
        '
        'LineShape5
        '
        Me.LineShape5.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LineShape5.BorderColor = System.Drawing.Color.LightGray
        Me.LineShape5.Name = "LineShape5"
        Me.LineShape5.X1 = 399
        Me.LineShape5.X2 = 751
        Me.LineShape5.Y1 = 240
        Me.LineShape5.Y2 = 240
        '
        'LineShape4
        '
        Me.LineShape4.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LineShape4.BorderColor = System.Drawing.Color.LightGray
        Me.LineShape4.Name = "LineShape4"
        Me.LineShape4.X1 = 10
        Me.LineShape4.X2 = 771
        Me.LineShape4.Y1 = 51
        Me.LineShape4.Y2 = 51
        '
        'LineShape2
        '
        Me.LineShape2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LineShape2.BorderColor = System.Drawing.Color.LightGray
        Me.LineShape2.Name = "LineShape2"
        Me.LineShape2.X1 = 21
        Me.LineShape2.X2 = 752
        Me.LineShape2.Y1 = 264
        Me.LineShape2.Y2 = 264
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.ForeColor = System.Drawing.Color.White
        Me.Label19.Location = New System.Drawing.Point(21, 246)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(43, 16)
        Me.Label19.TabIndex = 65
        Me.Label19.Text = "Items:"
        Me.Label19.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'CMBX_ItemCatalogueID
        '
        Me.CMBX_ItemCatalogueID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.CMBX_ItemCatalogueID.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBX_ItemCatalogueID.FormattingEnabled = True
        Me.CMBX_ItemCatalogueID.Location = New System.Drawing.Point(144, 63)
        Me.CMBX_ItemCatalogueID.Name = "CMBX_ItemCatalogueID"
        Me.CMBX_ItemCatalogueID.Size = New System.Drawing.Size(114, 24)
        Me.CMBX_ItemCatalogueID.TabIndex = 0
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(12, 9)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(190, 31)
        Me.Label4.TabIndex = 68
        Me.Label4.Text = "Add/Edit Item"
        '
        'CMBX_ItemCatalogueName
        '
        Me.CMBX_ItemCatalogueName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.CMBX_ItemCatalogueName.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBX_ItemCatalogueName.FormattingEnabled = True
        Me.CMBX_ItemCatalogueName.Location = New System.Drawing.Point(515, 25)
        Me.CMBX_ItemCatalogueName.Name = "CMBX_ItemCatalogueName"
        Me.CMBX_ItemCatalogueName.Size = New System.Drawing.Size(231, 24)
        Me.CMBX_ItemCatalogueName.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(455, 28)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(54, 16)
        Me.Label2.TabIndex = 70
        Me.Label2.Text = "Search:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'DGV_Items
        '
        Me.DGV_Items.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.DGV_Items.BackgroundColor = System.Drawing.Color.SlateGray
        Me.DGV_Items.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.DGV_Items.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV_Items.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ItemID, Me.ItemIDOriginal, Me.Item_Name, Me.Old_Item_Code, Me.Unit, Me.MinQty, Me.MaxQty, Me.ReorderQty, Me.PackSize})
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DGV_Items.DefaultCellStyle = DataGridViewCellStyle1
        Me.DGV_Items.Location = New System.Drawing.Point(38, 270)
        Me.DGV_Items.Name = "DGV_Items"
        Me.DGV_Items.RowHeadersWidth = 20
        Me.DGV_Items.Size = New System.Drawing.Size(708, 184)
        Me.DGV_Items.TabIndex = 11
        '
        'ItemID
        '
        Me.ItemID.HeaderText = "Item Code"
        Me.ItemID.Name = "ItemID"
        '
        'ItemIDOriginal
        '
        Me.ItemIDOriginal.HeaderText = "ItemIDOriginal"
        Me.ItemIDOriginal.Name = "ItemIDOriginal"
        Me.ItemIDOriginal.Visible = False
        '
        'Item_Name
        '
        Me.Item_Name.FillWeight = 170.0!
        Me.Item_Name.HeaderText = "Item Name"
        Me.Item_Name.Name = "Item_Name"
        '
        'Old_Item_Code
        '
        Me.Old_Item_Code.FillWeight = 89.0863!
        Me.Old_Item_Code.HeaderText = "Old Item Code"
        Me.Old_Item_Code.Name = "Old_Item_Code"
        '
        'Unit
        '
        Me.Unit.FillWeight = 70.0!
        Me.Unit.HeaderText = "Unit"
        Me.Unit.Name = "Unit"
        '
        'MinQty
        '
        Me.MinQty.HeaderText = "Minimum Qty"
        Me.MinQty.Name = "MinQty"
        '
        'MaxQty
        '
        Me.MaxQty.HeaderText = "Maximum Qty"
        Me.MaxQty.Name = "MaxQty"
        '
        'ReorderQty
        '
        Me.ReorderQty.HeaderText = "Reorder Qty"
        Me.ReorderQty.Name = "ReorderQty"
        '
        'DGV_SR
        '
        Me.DGV_SR.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.DGV_SR.BackgroundColor = System.Drawing.Color.SlateGray
        Me.DGV_SR.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.DGV_SR.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV_SR.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.SRType, Me.SRID, Me.Minimum, Me.Maximum})
        Me.DGV_SR.Location = New System.Drawing.Point(414, 156)
        Me.DGV_SR.Name = "DGV_SR"
        Me.DGV_SR.RowHeadersWidth = 20
        Me.DGV_SR.Size = New System.Drawing.Size(332, 78)
        Me.DGV_SR.TabIndex = 10
        '
        'SRType
        '
        Me.SRType.FillWeight = 121.8274!
        Me.SRType.HeaderText = "Requirement"
        Me.SRType.Name = "SRType"
        '
        'SRID
        '
        Me.SRID.HeaderText = "SRID"
        Me.SRID.Name = "SRID"
        Me.SRID.Visible = False
        '
        'Minimum
        '
        Me.Minimum.FillWeight = 89.0863!
        Me.Minimum.HeaderText = "Minimum"
        Me.Minimum.Name = "Minimum"
        '
        'Maximum
        '
        Me.Maximum.FillWeight = 89.0863!
        Me.Maximum.HeaderText = "Maximum"
        Me.Maximum.Name = "Maximum"
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.HeaderText = "SRTypeID"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        Me.DataGridViewTextBoxColumn1.Visible = False
        Me.DataGridViewTextBoxColumn1.Width = 105
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
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.FillWeight = 89.0863!
        Me.DataGridViewTextBoxColumn3.HeaderText = "Minimum"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.ReadOnly = True
        Me.DataGridViewTextBoxColumn3.Width = 106
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.FillWeight = 89.0863!
        Me.DataGridViewTextBoxColumn4.HeaderText = "Maximum"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.ReadOnly = True
        Me.DataGridViewTextBoxColumn4.Width = 104
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.FillWeight = 70.0!
        Me.DataGridViewTextBoxColumn5.HeaderText = "Item Code"
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        Me.DataGridViewTextBoxColumn5.ReadOnly = True
        Me.DataGridViewTextBoxColumn5.Width = 105
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
        'DataGridViewTextBoxColumn7
        '
        Me.DataGridViewTextBoxColumn7.FillWeight = 89.0863!
        Me.DataGridViewTextBoxColumn7.HeaderText = "Old Item Code"
        Me.DataGridViewTextBoxColumn7.Name = "DataGridViewTextBoxColumn7"
        Me.DataGridViewTextBoxColumn7.ReadOnly = True
        Me.DataGridViewTextBoxColumn7.Width = 89
        '
        'DataGridViewTextBoxColumn8
        '
        Me.DataGridViewTextBoxColumn8.FillWeight = 89.0863!
        Me.DataGridViewTextBoxColumn8.HeaderText = "Unit"
        Me.DataGridViewTextBoxColumn8.Name = "DataGridViewTextBoxColumn8"
        Me.DataGridViewTextBoxColumn8.ReadOnly = True
        Me.DataGridViewTextBoxColumn8.Width = 89
        '
        'DataGridViewTextBoxColumn9
        '
        Me.DataGridViewTextBoxColumn9.FillWeight = 70.0!
        Me.DataGridViewTextBoxColumn9.HeaderText = "Unit"
        Me.DataGridViewTextBoxColumn9.Name = "DataGridViewTextBoxColumn9"
        Me.DataGridViewTextBoxColumn9.ReadOnly = True
        Me.DataGridViewTextBoxColumn9.Width = 74
        '
        'PackSize
        '
        Me.PackSize.HeaderText = "Pack Size"
        Me.PackSize.Name = "PackSize"
        '
        'FRM_MTNCatalogue
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.SlateGray
        Me.ClientSize = New System.Drawing.Size(767, 512)
        Me.Controls.Add(Me.CMBX_ItemCatalogueName)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label19)
        Me.Controls.Add(Me.DGV_Items)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.CMBX_ItemCatalogueID)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.DGV_SR)
        Me.Controls.Add(Me.BTN_Save)
        Me.Controls.Add(Me.BTN_Close)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.CMBX_RouteOfAdministration)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.CMBX_LevelOfUse)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.CMBX_PrescriptionStatus)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.CMBX_TherapeuticClass)
        Me.Controls.Add(Me.CHBX_ItemExpires)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.CMBX_Category)
        Me.Controls.Add(Me.TBX_ItemName)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ShapeContainer1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "FRM_MTNCatalogue"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = " Add/Edit New Item"
        CType(Me.ERP_Error, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DGV_Items, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DGV_SR, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TBX_ItemName As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents CMBX_Category As System.Windows.Forms.ComboBox
    Friend WithEvents CHBX_ItemExpires As System.Windows.Forms.CheckBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents CMBX_PrescriptionStatus As System.Windows.Forms.ComboBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents CMBX_LevelOfUse As System.Windows.Forms.ComboBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents CMBX_RouteOfAdministration As System.Windows.Forms.ComboBox
    Friend WithEvents BTN_Save As System.Windows.Forms.Button
    Friend WithEvents BTN_Close As System.Windows.Forms.Button
    Friend WithEvents ERP_Error As System.Windows.Forms.ErrorProvider
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents CMBX_TherapeuticClass As System.Windows.Forms.ComboBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents ShapeContainer1 As Microsoft.VisualBasic.PowerPacks.ShapeContainer
    Friend WithEvents LineShape1 As Microsoft.VisualBasic.PowerPacks.LineShape
    Friend WithEvents DGV_Items As LMIS.DGV_G
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents LineShape2 As Microsoft.VisualBasic.PowerPacks.LineShape
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn7 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn8 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CMBX_ItemCatalogueID As System.Windows.Forms.ComboBox
    Friend WithEvents DataGridViewTextBoxColumn9 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DGV_SR As LMIS.DGV_G
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents LineShape4 As Microsoft.VisualBasic.PowerPacks.LineShape
    Friend WithEvents LineShape6 As Microsoft.VisualBasic.PowerPacks.LineShape
    Friend WithEvents LineShape5 As Microsoft.VisualBasic.PowerPacks.LineShape
    Friend WithEvents SRType As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SRID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Minimum As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Maximum As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ItemID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ItemIDOriginal As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Item_Name As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Old_Item_Code As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Unit As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MinQty As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MaxQty As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ReorderQty As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CMBX_ItemCatalogueName As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents PackSize As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
