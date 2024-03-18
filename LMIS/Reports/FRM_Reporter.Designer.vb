<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FRM_Reporter
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
        Me.CVWR_Reporter = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
        Me.TBC_Report = New System.Windows.Forms.TabControl()
        Me.TB_Items = New System.Windows.Forms.TabPage()
        Me.RBTN_InventorySheet = New System.Windows.Forms.RadioButton()
        Me.GBX_OutofStock = New System.Windows.Forms.GroupBox()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.DTP_OutofStock = New System.Windows.Forms.DateTimePicker()
        Me.CMBX_OutofStock = New System.Windows.Forms.ComboBox()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.GBX_Catalogue = New System.Windows.Forms.GroupBox()
        Me.LBL_Catalogue = New System.Windows.Forms.Label()
        Me.CMBX_CatalogueFilter = New System.Windows.Forms.ComboBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.CMBX_Catalogue = New System.Windows.Forms.ComboBox()
        Me.RBTN_ItemsStockOut = New System.Windows.Forms.RadioButton()
        Me.GBX_StockBalance = New System.Windows.Forms.GroupBox()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.CMBX_StockCategory = New System.Windows.Forms.ComboBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.CMBX_StockBalanceItem = New System.Windows.Forms.ComboBox()
        Me.GBX_StockCard = New System.Windows.Forms.GroupBox()
        Me.CHBX_STAllBy = New System.Windows.Forms.CheckBox()
        Me.DTP_StockCard_To = New System.Windows.Forms.DateTimePicker()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.CMBX_StockCardItem = New System.Windows.Forms.ComboBox()
        Me.DTP_StockCard_From = New System.Windows.Forms.DateTimePicker()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.RBTN_ItemAlreadyExpired = New System.Windows.Forms.RadioButton()
        Me.RBTN_StockCard = New System.Windows.Forms.RadioButton()
        Me.RBTN_StockBalace = New System.Windows.Forms.RadioButton()
        Me.RBTN_ItemExpiry = New System.Windows.Forms.RadioButton()
        Me.GBX_ItemsExpiry = New System.Windows.Forms.GroupBox()
        Me.DTP_ItemExpiry_To = New System.Windows.Forms.DateTimePicker()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.DTP_ItemExpiry_From = New System.Windows.Forms.DateTimePicker()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.RBTN_CatalogueList = New System.Windows.Forms.RadioButton()
        Me.TB_Transaction = New System.Windows.Forms.TabPage()
        Me.GBX_IJ = New System.Windows.Forms.GroupBox()
        Me.CHBX_VoidTransactionsT = New System.Windows.Forms.CheckBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.CMBX_IJItemGB = New System.Windows.Forms.ComboBox()
        Me.CHBX_IJAllItemGB = New System.Windows.Forms.CheckBox()
        Me.CMBX_IJItemGBList = New System.Windows.Forms.ComboBox()
        Me.LBL_IJItemGB = New System.Windows.Forms.Label()
        Me.GBX_IJFilter = New System.Windows.Forms.GroupBox()
        Me.LBL_IJFilter2 = New System.Windows.Forms.Label()
        Me.CMBX_IJFilter2 = New System.Windows.Forms.ComboBox()
        Me.LBL_IJFilter1 = New System.Windows.Forms.Label()
        Me.CMBX_IJFilter1 = New System.Windows.Forms.ComboBox()
        Me.CHBX_IJAllGroupBy = New System.Windows.Forms.CheckBox()
        Me.CMBX_IJGroupBy = New System.Windows.Forms.ComboBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.CHBX_IJAllItemNames = New System.Windows.Forms.CheckBox()
        Me.CHBX_IJAllDates = New System.Windows.Forms.CheckBox()
        Me.CMBX_IJItemName = New System.Windows.Forms.ComboBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.DTP_IJSummary_To = New System.Windows.Forms.DateTimePicker()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.DTP_IJSummary_From = New System.Windows.Forms.DateTimePicker()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.CMBX_IJSummaryRepoType = New System.Windows.Forms.ComboBox()
        Me.TB_Financial = New System.Windows.Forms.TabPage()
        Me.GBX_FN = New System.Windows.Forms.GroupBox()
        Me.CHBX_VoidTransactionsF = New System.Windows.Forms.CheckBox()
        Me.GBX_FNFilter = New System.Windows.Forms.GroupBox()
        Me.LBL_FNFilter2 = New System.Windows.Forms.Label()
        Me.CMBX_FNFilter2 = New System.Windows.Forms.ComboBox()
        Me.LBL_FNFilter1 = New System.Windows.Forms.Label()
        Me.CMBX_FNFilter1 = New System.Windows.Forms.ComboBox()
        Me.CHBX_FNAllGroupBy = New System.Windows.Forms.CheckBox()
        Me.CMBX_FNGroupBy = New System.Windows.Forms.ComboBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.CHBX_FNAllDates = New System.Windows.Forms.CheckBox()
        Me.DTP_FNSummary_To = New System.Windows.Forms.DateTimePicker()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.DTP_FNSummary_From = New System.Windows.Forms.DateTimePicker()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.CMBX_FNSummaryRepoType = New System.Windows.Forms.ComboBox()
        Me.TB_Analysis = New System.Windows.Forms.TabPage()
        Me.GBX_AN = New System.Windows.Forms.GroupBox()
        Me.CHBX_ANAllDates = New System.Windows.Forms.CheckBox()
        Me.DTP_ANSummary_To = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.DTP_ANSummary_From = New System.Windows.Forms.DateTimePicker()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.CMBX_ANGroupBy = New System.Windows.Forms.ComboBox()
        Me.LBL_ANGroup = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.CMBX_ANSummaryRepoType = New System.Windows.Forms.ComboBox()
        Me.TB_History = New System.Windows.Forms.TabPage()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.TBX_SearchTerm = New System.Windows.Forms.ComboBox()
        Me.CHBX_Void = New System.Windows.Forms.CheckBox()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.LBL_SearchResult = New System.Windows.Forms.Label()
        Me.BTN_Void = New System.Windows.Forms.Button()
        Me.dfd = New System.Windows.Forms.Label()
        Me.LBX_SearchResults = New System.Windows.Forms.ListBox()
        Me.BTN_Search = New System.Windows.Forms.Button()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.CMBX_SearchBy = New System.Windows.Forms.ComboBox()
        Me.CHBX_HAllDates = New System.Windows.Forms.CheckBox()
        Me.LBL_SearchTerm = New System.Windows.Forms.Label()
        Me.DTP_H_To = New System.Windows.Forms.DateTimePicker()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.DTP_H_From = New System.Windows.Forms.DateTimePicker()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.CMBX_TransactionType = New System.Windows.Forms.ComboBox()
        Me.TB_Static = New System.Windows.Forms.TabPage()
        Me.GBX_SD = New System.Windows.Forms.GroupBox()
        Me.CHBX_SDSearchAll = New System.Windows.Forms.CheckBox()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.Label33 = New System.Windows.Forms.Label()
        Me.CMBX_SDSearchBy = New System.Windows.Forms.ComboBox()
        Me.DTP_SD_To = New System.Windows.Forms.DateTimePicker()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.DTP_SD_From = New System.Windows.Forms.DateTimePicker()
        Me.Label32 = New System.Windows.Forms.Label()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.CMBX_SDRepoType = New System.Windows.Forms.ComboBox()
        Me.BTN_Close = New System.Windows.Forms.Button()
        Me.BTN_Report = New System.Windows.Forms.Button()
        Me.ERP_Error = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.BTN_Detailed = New System.Windows.Forms.Button()
        Me.CMBX_RepoForDepa = New System.Windows.Forms.ComboBox()
        Me.CHBX_ReportForDepa = New System.Windows.Forms.CheckBox()
        Me.GBX_RepoForDepa = New System.Windows.Forms.GroupBox()
        Me.CHBX_ReportForAllDepa = New System.Windows.Forms.CheckBox()
        Me.TBC_Report.SuspendLayout()
        Me.TB_Items.SuspendLayout()
        Me.GBX_OutofStock.SuspendLayout()
        Me.GBX_Catalogue.SuspendLayout()
        Me.GBX_StockBalance.SuspendLayout()
        Me.GBX_StockCard.SuspendLayout()
        Me.GBX_ItemsExpiry.SuspendLayout()
        Me.TB_Transaction.SuspendLayout()
        Me.GBX_IJ.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GBX_IJFilter.SuspendLayout()
        Me.TB_Financial.SuspendLayout()
        Me.GBX_FN.SuspendLayout()
        Me.GBX_FNFilter.SuspendLayout()
        Me.TB_Analysis.SuspendLayout()
        Me.GBX_AN.SuspendLayout()
        Me.TB_History.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.TB_Static.SuspendLayout()
        Me.GBX_SD.SuspendLayout()
        CType(Me.ERP_Error, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GBX_RepoForDepa.SuspendLayout()
        Me.SuspendLayout()
        '
        'CVWR_Reporter
        '
        Me.CVWR_Reporter.ActiveViewIndex = -1
        Me.CVWR_Reporter.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CVWR_Reporter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CVWR_Reporter.Cursor = System.Windows.Forms.Cursors.Default
        Me.CVWR_Reporter.Location = New System.Drawing.Point(274, 0)
        Me.CVWR_Reporter.Name = "CVWR_Reporter"
        Me.CVWR_Reporter.Size = New System.Drawing.Size(652, 664)
        Me.CVWR_Reporter.TabIndex = 0
        Me.CVWR_Reporter.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
        '
        'TBC_Report
        '
        Me.TBC_Report.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.TBC_Report.Controls.Add(Me.TB_Items)
        Me.TBC_Report.Controls.Add(Me.TB_Transaction)
        Me.TBC_Report.Controls.Add(Me.TB_Financial)
        Me.TBC_Report.Controls.Add(Me.TB_Analysis)
        Me.TBC_Report.Controls.Add(Me.TB_History)
        Me.TBC_Report.Controls.Add(Me.TB_Static)
        Me.TBC_Report.Location = New System.Drawing.Point(2, -2)
        Me.TBC_Report.Name = "TBC_Report"
        Me.TBC_Report.SelectedIndex = 0
        Me.TBC_Report.Size = New System.Drawing.Size(270, 545)
        Me.TBC_Report.TabIndex = 1
        '
        'TB_Items
        '
        Me.TB_Items.Controls.Add(Me.RBTN_InventorySheet)
        Me.TB_Items.Controls.Add(Me.GBX_OutofStock)
        Me.TB_Items.Controls.Add(Me.GBX_Catalogue)
        Me.TB_Items.Controls.Add(Me.RBTN_ItemsStockOut)
        Me.TB_Items.Controls.Add(Me.GBX_StockBalance)
        Me.TB_Items.Controls.Add(Me.GBX_StockCard)
        Me.TB_Items.Controls.Add(Me.RBTN_ItemAlreadyExpired)
        Me.TB_Items.Controls.Add(Me.RBTN_StockCard)
        Me.TB_Items.Controls.Add(Me.RBTN_StockBalace)
        Me.TB_Items.Controls.Add(Me.RBTN_ItemExpiry)
        Me.TB_Items.Controls.Add(Me.GBX_ItemsExpiry)
        Me.TB_Items.Controls.Add(Me.RBTN_CatalogueList)
        Me.TB_Items.Location = New System.Drawing.Point(4, 22)
        Me.TB_Items.Name = "TB_Items"
        Me.TB_Items.Padding = New System.Windows.Forms.Padding(3)
        Me.TB_Items.Size = New System.Drawing.Size(262, 519)
        Me.TB_Items.TabIndex = 0
        Me.TB_Items.Text = "Items"
        Me.TB_Items.UseVisualStyleBackColor = True
        '
        'RBTN_InventorySheet
        '
        Me.RBTN_InventorySheet.AutoSize = True
        Me.RBTN_InventorySheet.Location = New System.Drawing.Point(7, 165)
        Me.RBTN_InventorySheet.Name = "RBTN_InventorySheet"
        Me.RBTN_InventorySheet.Size = New System.Drawing.Size(100, 17)
        Me.RBTN_InventorySheet.TabIndex = 44
        Me.RBTN_InventorySheet.Text = "Inventory Sheet"
        Me.RBTN_InventorySheet.UseVisualStyleBackColor = True
        '
        'GBX_OutofStock
        '
        Me.GBX_OutofStock.Controls.Add(Me.Label28)
        Me.GBX_OutofStock.Controls.Add(Me.DTP_OutofStock)
        Me.GBX_OutofStock.Controls.Add(Me.CMBX_OutofStock)
        Me.GBX_OutofStock.Controls.Add(Me.Label27)
        Me.GBX_OutofStock.Enabled = False
        Me.GBX_OutofStock.Location = New System.Drawing.Point(26, 204)
        Me.GBX_OutofStock.Name = "GBX_OutofStock"
        Me.GBX_OutofStock.Size = New System.Drawing.Size(230, 52)
        Me.GBX_OutofStock.TabIndex = 43
        Me.GBX_OutofStock.TabStop = False
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Location = New System.Drawing.Point(115, 11)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(31, 13)
        Me.Label28.TabIndex = 40
        Me.Label28.Text = "Type"
        '
        'DTP_OutofStock
        '
        Me.DTP_OutofStock.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DTP_OutofStock.Location = New System.Drawing.Point(6, 27)
        Me.DTP_OutofStock.Name = "DTP_OutofStock"
        Me.DTP_OutofStock.Size = New System.Drawing.Size(108, 20)
        Me.DTP_OutofStock.TabIndex = 29
        '
        'CMBX_OutofStock
        '
        Me.CMBX_OutofStock.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.CMBX_OutofStock.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBX_OutofStock.FormattingEnabled = True
        Me.CMBX_OutofStock.Items.AddRange(New Object() {"Zero Balance", "Below Minimum Quantity", "Above Maximum Quantity", "Below Reorder Quantity"})
        Me.CMBX_OutofStock.Location = New System.Drawing.Point(118, 26)
        Me.CMBX_OutofStock.Name = "CMBX_OutofStock"
        Me.CMBX_OutofStock.Size = New System.Drawing.Size(104, 21)
        Me.CMBX_OutofStock.TabIndex = 41
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Location = New System.Drawing.Point(6, 10)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(28, 13)
        Me.Label27.TabIndex = 28
        Me.Label27.Text = "Until"
        '
        'GBX_Catalogue
        '
        Me.GBX_Catalogue.Controls.Add(Me.LBL_Catalogue)
        Me.GBX_Catalogue.Controls.Add(Me.CMBX_CatalogueFilter)
        Me.GBX_Catalogue.Controls.Add(Me.Label13)
        Me.GBX_Catalogue.Controls.Add(Me.CMBX_Catalogue)
        Me.GBX_Catalogue.Enabled = False
        Me.GBX_Catalogue.Location = New System.Drawing.Point(26, 29)
        Me.GBX_Catalogue.Name = "GBX_Catalogue"
        Me.GBX_Catalogue.Size = New System.Drawing.Size(230, 57)
        Me.GBX_Catalogue.TabIndex = 43
        Me.GBX_Catalogue.TabStop = False
        '
        'LBL_Catalogue
        '
        Me.LBL_Catalogue.AutoSize = True
        Me.LBL_Catalogue.Location = New System.Drawing.Point(115, 10)
        Me.LBL_Catalogue.Name = "LBL_Catalogue"
        Me.LBL_Catalogue.Size = New System.Drawing.Size(56, 13)
        Me.LBL_Catalogue.TabIndex = 42
        Me.LBL_Catalogue.Text = "Show only"
        '
        'CMBX_CatalogueFilter
        '
        Me.CMBX_CatalogueFilter.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.CMBX_CatalogueFilter.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBX_CatalogueFilter.DropDownWidth = 200
        Me.CMBX_CatalogueFilter.FormattingEnabled = True
        Me.CMBX_CatalogueFilter.Items.AddRange(New Object() {"Item Category", "Item Classification"})
        Me.CMBX_CatalogueFilter.Location = New System.Drawing.Point(118, 26)
        Me.CMBX_CatalogueFilter.Name = "CMBX_CatalogueFilter"
        Me.CMBX_CatalogueFilter.Size = New System.Drawing.Size(106, 21)
        Me.CMBX_CatalogueFilter.TabIndex = 43
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(3, 10)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(50, 13)
        Me.Label13.TabIndex = 40
        Me.Label13.Text = "Group by"
        '
        'CMBX_Catalogue
        '
        Me.CMBX_Catalogue.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.CMBX_Catalogue.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBX_Catalogue.DropDownWidth = 200
        Me.CMBX_Catalogue.FormattingEnabled = True
        Me.CMBX_Catalogue.Items.AddRange(New Object() {"Item Category", "Item Classification", "Item Sub-Classification"})
        Me.CMBX_Catalogue.Location = New System.Drawing.Point(6, 26)
        Me.CMBX_Catalogue.Name = "CMBX_Catalogue"
        Me.CMBX_Catalogue.Size = New System.Drawing.Size(109, 21)
        Me.CMBX_Catalogue.TabIndex = 41
        '
        'RBTN_ItemsStockOut
        '
        Me.RBTN_ItemsStockOut.AutoSize = True
        Me.RBTN_ItemsStockOut.Location = New System.Drawing.Point(7, 188)
        Me.RBTN_ItemsStockOut.Name = "RBTN_ItemsStockOut"
        Me.RBTN_ItemsStockOut.Size = New System.Drawing.Size(85, 17)
        Me.RBTN_ItemsStockOut.TabIndex = 43
        Me.RBTN_ItemsStockOut.Text = "Out of Stock"
        Me.RBTN_ItemsStockOut.UseVisualStyleBackColor = True
        '
        'GBX_StockBalance
        '
        Me.GBX_StockBalance.Controls.Add(Me.Label29)
        Me.GBX_StockBalance.Controls.Add(Me.CMBX_StockCategory)
        Me.GBX_StockBalance.Controls.Add(Me.Label14)
        Me.GBX_StockBalance.Controls.Add(Me.CMBX_StockBalanceItem)
        Me.GBX_StockBalance.Enabled = False
        Me.GBX_StockBalance.Location = New System.Drawing.Point(26, 108)
        Me.GBX_StockBalance.Name = "GBX_StockBalance"
        Me.GBX_StockBalance.Size = New System.Drawing.Size(230, 52)
        Me.GBX_StockBalance.TabIndex = 42
        Me.GBX_StockBalance.TabStop = False
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.Location = New System.Drawing.Point(2, 10)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(90, 13)
        Me.Label29.TabIndex = 44
        Me.Label29.Text = "Sub-Classification"
        '
        'CMBX_StockCategory
        '
        Me.CMBX_StockCategory.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.CMBX_StockCategory.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBX_StockCategory.DropDownWidth = 200
        Me.CMBX_StockCategory.FormattingEnabled = True
        Me.CMBX_StockCategory.Items.AddRange(New Object() {"Item Classification", "Item Sub-Classification", "Item Category"})
        Me.CMBX_StockCategory.Location = New System.Drawing.Point(5, 26)
        Me.CMBX_StockCategory.Name = "CMBX_StockCategory"
        Me.CMBX_StockCategory.Size = New System.Drawing.Size(109, 21)
        Me.CMBX_StockCategory.TabIndex = 45
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(115, 10)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(27, 13)
        Me.Label14.TabIndex = 40
        Me.Label14.Text = "Item"
        '
        'CMBX_StockBalanceItem
        '
        Me.CMBX_StockBalanceItem.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.CMBX_StockBalanceItem.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBX_StockBalanceItem.DropDownWidth = 200
        Me.CMBX_StockBalanceItem.FormattingEnabled = True
        Me.CMBX_StockBalanceItem.Items.AddRange(New Object() {"Items Distributed", "Items Received", "Items Adjustment Plus", "Items Adjustment Minus", "OPD Items Distributed", "IPD Items Distributed"})
        Me.CMBX_StockBalanceItem.Location = New System.Drawing.Point(118, 26)
        Me.CMBX_StockBalanceItem.Name = "CMBX_StockBalanceItem"
        Me.CMBX_StockBalanceItem.Size = New System.Drawing.Size(104, 21)
        Me.CMBX_StockBalanceItem.TabIndex = 41
        '
        'GBX_StockCard
        '
        Me.GBX_StockCard.Controls.Add(Me.CHBX_STAllBy)
        Me.GBX_StockCard.Controls.Add(Me.DTP_StockCard_To)
        Me.GBX_StockCard.Controls.Add(Me.Label4)
        Me.GBX_StockCard.Controls.Add(Me.Label3)
        Me.GBX_StockCard.Controls.Add(Me.CMBX_StockCardItem)
        Me.GBX_StockCard.Controls.Add(Me.DTP_StockCard_From)
        Me.GBX_StockCard.Controls.Add(Me.Label12)
        Me.GBX_StockCard.Enabled = False
        Me.GBX_StockCard.Location = New System.Drawing.Point(31, 381)
        Me.GBX_StockCard.Name = "GBX_StockCard"
        Me.GBX_StockCard.Size = New System.Drawing.Size(225, 91)
        Me.GBX_StockCard.TabIndex = 36
        Me.GBX_StockCard.TabStop = False
        '
        'CHBX_STAllBy
        '
        Me.CHBX_STAllBy.AutoSize = True
        Me.CHBX_STAllBy.CheckAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.CHBX_STAllBy.Location = New System.Drawing.Point(202, 16)
        Me.CHBX_STAllBy.Name = "CHBX_STAllBy"
        Me.CHBX_STAllBy.Size = New System.Drawing.Size(22, 31)
        Me.CHBX_STAllBy.TabIndex = 42
        Me.CHBX_STAllBy.Text = "All"
        Me.CHBX_STAllBy.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.CHBX_STAllBy.UseVisualStyleBackColor = True
        '
        'DTP_StockCard_To
        '
        Me.DTP_StockCard_To.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DTP_StockCard_To.Location = New System.Drawing.Point(113, 66)
        Me.DTP_StockCard_To.Name = "DTP_StockCard_To"
        Me.DTP_StockCard_To.Size = New System.Drawing.Size(104, 20)
        Me.DTP_StockCard_To.TabIndex = 27
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(110, 50)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(20, 13)
        Me.Label4.TabIndex = 26
        Me.Label4.Text = "To"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(3, 10)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(27, 13)
        Me.Label3.TabIndex = 40
        Me.Label3.Text = "Item"
        '
        'CMBX_StockCardItem
        '
        Me.CMBX_StockCardItem.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.CMBX_StockCardItem.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBX_StockCardItem.FormattingEnabled = True
        Me.CMBX_StockCardItem.Items.AddRange(New Object() {"Items Distributed", "Items Received", "Items Adjustment Plus", "Items Adjustment Minus", "OPD Items Distributed", "IPD Items Distributed"})
        Me.CMBX_StockCardItem.Location = New System.Drawing.Point(6, 26)
        Me.CMBX_StockCardItem.Name = "CMBX_StockCardItem"
        Me.CMBX_StockCardItem.Size = New System.Drawing.Size(190, 21)
        Me.CMBX_StockCardItem.TabIndex = 41
        '
        'DTP_StockCard_From
        '
        Me.DTP_StockCard_From.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DTP_StockCard_From.Location = New System.Drawing.Point(6, 66)
        Me.DTP_StockCard_From.Name = "DTP_StockCard_From"
        Me.DTP_StockCard_From.Size = New System.Drawing.Size(103, 20)
        Me.DTP_StockCard_From.TabIndex = 23
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(3, 50)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(30, 13)
        Me.Label12.TabIndex = 22
        Me.Label12.Text = "From"
        '
        'RBTN_ItemAlreadyExpired
        '
        Me.RBTN_ItemAlreadyExpired.AutoSize = True
        Me.RBTN_ItemAlreadyExpired.Location = New System.Drawing.Point(7, 261)
        Me.RBTN_ItemAlreadyExpired.Name = "RBTN_ItemAlreadyExpired"
        Me.RBTN_ItemAlreadyExpired.Size = New System.Drawing.Size(91, 17)
        Me.RBTN_ItemAlreadyExpired.TabIndex = 42
        Me.RBTN_ItemAlreadyExpired.Text = "Stock Expired"
        Me.RBTN_ItemAlreadyExpired.UseVisualStyleBackColor = True
        '
        'RBTN_StockCard
        '
        Me.RBTN_StockCard.AutoSize = True
        Me.RBTN_StockCard.Location = New System.Drawing.Point(11, 358)
        Me.RBTN_StockCard.Name = "RBTN_StockCard"
        Me.RBTN_StockCard.Size = New System.Drawing.Size(78, 17)
        Me.RBTN_StockCard.TabIndex = 39
        Me.RBTN_StockCard.Text = "Stock Card"
        Me.RBTN_StockCard.UseVisualStyleBackColor = True
        '
        'RBTN_StockBalace
        '
        Me.RBTN_StockBalace.AutoSize = True
        Me.RBTN_StockBalace.Location = New System.Drawing.Point(6, 92)
        Me.RBTN_StockBalace.Name = "RBTN_StockBalace"
        Me.RBTN_StockBalace.Size = New System.Drawing.Size(95, 17)
        Me.RBTN_StockBalace.TabIndex = 37
        Me.RBTN_StockBalace.Text = "Stock Balance"
        Me.RBTN_StockBalace.UseVisualStyleBackColor = True
        '
        'RBTN_ItemExpiry
        '
        Me.RBTN_ItemExpiry.AutoSize = True
        Me.RBTN_ItemExpiry.Location = New System.Drawing.Point(7, 284)
        Me.RBTN_ItemExpiry.Name = "RBTN_ItemExpiry"
        Me.RBTN_ItemExpiry.Size = New System.Drawing.Size(103, 17)
        Me.RBTN_ItemExpiry.TabIndex = 36
        Me.RBTN_ItemExpiry.Text = "Stock Expiry List"
        Me.RBTN_ItemExpiry.UseVisualStyleBackColor = True
        '
        'GBX_ItemsExpiry
        '
        Me.GBX_ItemsExpiry.Controls.Add(Me.DTP_ItemExpiry_To)
        Me.GBX_ItemsExpiry.Controls.Add(Me.Label16)
        Me.GBX_ItemsExpiry.Controls.Add(Me.DTP_ItemExpiry_From)
        Me.GBX_ItemsExpiry.Controls.Add(Me.Label5)
        Me.GBX_ItemsExpiry.Enabled = False
        Me.GBX_ItemsExpiry.Location = New System.Drawing.Point(31, 298)
        Me.GBX_ItemsExpiry.Name = "GBX_ItemsExpiry"
        Me.GBX_ItemsExpiry.Size = New System.Drawing.Size(230, 54)
        Me.GBX_ItemsExpiry.TabIndex = 35
        Me.GBX_ItemsExpiry.TabStop = False
        '
        'DTP_ItemExpiry_To
        '
        Me.DTP_ItemExpiry_To.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DTP_ItemExpiry_To.Location = New System.Drawing.Point(113, 27)
        Me.DTP_ItemExpiry_To.Name = "DTP_ItemExpiry_To"
        Me.DTP_ItemExpiry_To.Size = New System.Drawing.Size(104, 20)
        Me.DTP_ItemExpiry_To.TabIndex = 27
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(112, 11)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(20, 13)
        Me.Label16.TabIndex = 26
        Me.Label16.Text = "To"
        '
        'DTP_ItemExpiry_From
        '
        Me.DTP_ItemExpiry_From.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DTP_ItemExpiry_From.Location = New System.Drawing.Point(6, 27)
        Me.DTP_ItemExpiry_From.Name = "DTP_ItemExpiry_From"
        Me.DTP_ItemExpiry_From.Size = New System.Drawing.Size(104, 20)
        Me.DTP_ItemExpiry_From.TabIndex = 23
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(3, 11)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(30, 13)
        Me.Label5.TabIndex = 22
        Me.Label5.Text = "From"
        '
        'RBTN_CatalogueList
        '
        Me.RBTN_CatalogueList.AutoSize = True
        Me.RBTN_CatalogueList.Location = New System.Drawing.Point(6, 16)
        Me.RBTN_CatalogueList.Name = "RBTN_CatalogueList"
        Me.RBTN_CatalogueList.Size = New System.Drawing.Size(101, 17)
        Me.RBTN_CatalogueList.TabIndex = 34
        Me.RBTN_CatalogueList.Text = "Items Catalogue"
        Me.RBTN_CatalogueList.UseVisualStyleBackColor = True
        '
        'TB_Transaction
        '
        Me.TB_Transaction.Controls.Add(Me.GBX_IJ)
        Me.TB_Transaction.Controls.Add(Me.Label6)
        Me.TB_Transaction.Controls.Add(Me.CMBX_IJSummaryRepoType)
        Me.TB_Transaction.Location = New System.Drawing.Point(4, 22)
        Me.TB_Transaction.Name = "TB_Transaction"
        Me.TB_Transaction.Padding = New System.Windows.Forms.Padding(3)
        Me.TB_Transaction.Size = New System.Drawing.Size(262, 519)
        Me.TB_Transaction.TabIndex = 1
        Me.TB_Transaction.Text = "Transaction"
        Me.TB_Transaction.UseVisualStyleBackColor = True
        '
        'GBX_IJ
        '
        Me.GBX_IJ.Controls.Add(Me.CHBX_VoidTransactionsT)
        Me.GBX_IJ.Controls.Add(Me.GroupBox3)
        Me.GBX_IJ.Controls.Add(Me.GBX_IJFilter)
        Me.GBX_IJ.Controls.Add(Me.CHBX_IJAllGroupBy)
        Me.GBX_IJ.Controls.Add(Me.CMBX_IJGroupBy)
        Me.GBX_IJ.Controls.Add(Me.Label9)
        Me.GBX_IJ.Controls.Add(Me.CHBX_IJAllItemNames)
        Me.GBX_IJ.Controls.Add(Me.CHBX_IJAllDates)
        Me.GBX_IJ.Controls.Add(Me.CMBX_IJItemName)
        Me.GBX_IJ.Controls.Add(Me.Label7)
        Me.GBX_IJ.Controls.Add(Me.DTP_IJSummary_To)
        Me.GBX_IJ.Controls.Add(Me.Label10)
        Me.GBX_IJ.Controls.Add(Me.DTP_IJSummary_From)
        Me.GBX_IJ.Controls.Add(Me.Label11)
        Me.GBX_IJ.Enabled = False
        Me.GBX_IJ.Location = New System.Drawing.Point(6, 46)
        Me.GBX_IJ.Name = "GBX_IJ"
        Me.GBX_IJ.Size = New System.Drawing.Size(253, 394)
        Me.GBX_IJ.TabIndex = 44
        Me.GBX_IJ.TabStop = False
        '
        'CHBX_VoidTransactionsT
        '
        Me.CHBX_VoidTransactionsT.AutoSize = True
        Me.CHBX_VoidTransactionsT.Location = New System.Drawing.Point(9, 371)
        Me.CHBX_VoidTransactionsT.Name = "CHBX_VoidTransactionsT"
        Me.CHBX_VoidTransactionsT.Size = New System.Drawing.Size(111, 17)
        Me.CHBX_VoidTransactionsT.TabIndex = 44
        Me.CHBX_VoidTransactionsT.Text = "Void Transactions"
        Me.CHBX_VoidTransactionsT.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.CHBX_VoidTransactionsT.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.Label8)
        Me.GroupBox3.Controls.Add(Me.CMBX_IJItemGB)
        Me.GroupBox3.Controls.Add(Me.CHBX_IJAllItemGB)
        Me.GroupBox3.Controls.Add(Me.CMBX_IJItemGBList)
        Me.GroupBox3.Controls.Add(Me.LBL_IJItemGB)
        Me.GroupBox3.Location = New System.Drawing.Point(29, 252)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(217, 99)
        Me.GroupBox3.TabIndex = 44
        Me.GroupBox3.TabStop = False
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(2, 16)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(72, 13)
        Me.Label8.TabIndex = 43
        Me.Label8.Text = "Items Filter By"
        '
        'CMBX_IJItemGB
        '
        Me.CMBX_IJItemGB.Enabled = False
        Me.CMBX_IJItemGB.FormattingEnabled = True
        Me.CMBX_IJItemGB.Items.AddRange(New Object() {"Item Category", "Item Classification", "Item Sub-Classification"})
        Me.CMBX_IJItemGB.Location = New System.Drawing.Point(4, 32)
        Me.CMBX_IJItemGB.Name = "CMBX_IJItemGB"
        Me.CMBX_IJItemGB.Size = New System.Drawing.Size(185, 21)
        Me.CMBX_IJItemGB.TabIndex = 33
        '
        'CHBX_IJAllItemGB
        '
        Me.CHBX_IJAllItemGB.AutoSize = True
        Me.CHBX_IJAllItemGB.CheckAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.CHBX_IJAllItemGB.Checked = True
        Me.CHBX_IJAllItemGB.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CHBX_IJAllItemGB.Enabled = False
        Me.CHBX_IJAllItemGB.Location = New System.Drawing.Point(195, 22)
        Me.CHBX_IJAllItemGB.Name = "CHBX_IJAllItemGB"
        Me.CHBX_IJAllItemGB.Size = New System.Drawing.Size(22, 31)
        Me.CHBX_IJAllItemGB.TabIndex = 34
        Me.CHBX_IJAllItemGB.Text = "All"
        Me.CHBX_IJAllItemGB.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.CHBX_IJAllItemGB.UseVisualStyleBackColor = True
        '
        'CMBX_IJItemGBList
        '
        Me.CMBX_IJItemGBList.Enabled = False
        Me.CMBX_IJItemGBList.FormattingEnabled = True
        Me.CMBX_IJItemGBList.Location = New System.Drawing.Point(4, 72)
        Me.CMBX_IJItemGBList.Name = "CMBX_IJItemGBList"
        Me.CMBX_IJItemGBList.Size = New System.Drawing.Size(185, 21)
        Me.CMBX_IJItemGBList.TabIndex = 42
        '
        'LBL_IJItemGB
        '
        Me.LBL_IJItemGB.AutoSize = True
        Me.LBL_IJItemGB.Location = New System.Drawing.Point(1, 56)
        Me.LBL_IJItemGB.Name = "LBL_IJItemGB"
        Me.LBL_IJItemGB.Size = New System.Drawing.Size(72, 13)
        Me.LBL_IJItemGB.TabIndex = 41
        Me.LBL_IJItemGB.Text = "Items Filter By"
        '
        'GBX_IJFilter
        '
        Me.GBX_IJFilter.Controls.Add(Me.LBL_IJFilter2)
        Me.GBX_IJFilter.Controls.Add(Me.CMBX_IJFilter2)
        Me.GBX_IJFilter.Controls.Add(Me.LBL_IJFilter1)
        Me.GBX_IJFilter.Controls.Add(Me.CMBX_IJFilter1)
        Me.GBX_IJFilter.Location = New System.Drawing.Point(29, 54)
        Me.GBX_IJFilter.Name = "GBX_IJFilter"
        Me.GBX_IJFilter.Size = New System.Drawing.Size(219, 98)
        Me.GBX_IJFilter.TabIndex = 43
        Me.GBX_IJFilter.TabStop = False
        '
        'LBL_IJFilter2
        '
        Me.LBL_IJFilter2.AutoSize = True
        Me.LBL_IJFilter2.Location = New System.Drawing.Point(2, 55)
        Me.LBL_IJFilter2.Name = "LBL_IJFilter2"
        Me.LBL_IJFilter2.Size = New System.Drawing.Size(35, 13)
        Me.LBL_IJFilter2.TabIndex = 52
        Me.LBL_IJFilter2.Text = "Filter2"
        '
        'CMBX_IJFilter2
        '
        Me.CMBX_IJFilter2.FormattingEnabled = True
        Me.CMBX_IJFilter2.Location = New System.Drawing.Point(4, 71)
        Me.CMBX_IJFilter2.Name = "CMBX_IJFilter2"
        Me.CMBX_IJFilter2.Size = New System.Drawing.Size(185, 21)
        Me.CMBX_IJFilter2.TabIndex = 50
        '
        'LBL_IJFilter1
        '
        Me.LBL_IJFilter1.AutoSize = True
        Me.LBL_IJFilter1.Location = New System.Drawing.Point(2, 11)
        Me.LBL_IJFilter1.Name = "LBL_IJFilter1"
        Me.LBL_IJFilter1.Size = New System.Drawing.Size(35, 13)
        Me.LBL_IJFilter1.TabIndex = 43
        Me.LBL_IJFilter1.Text = "Filter1"
        '
        'CMBX_IJFilter1
        '
        Me.CMBX_IJFilter1.FormattingEnabled = True
        Me.CMBX_IJFilter1.Location = New System.Drawing.Point(5, 27)
        Me.CMBX_IJFilter1.Name = "CMBX_IJFilter1"
        Me.CMBX_IJFilter1.Size = New System.Drawing.Size(185, 21)
        Me.CMBX_IJFilter1.TabIndex = 27
        '
        'CHBX_IJAllGroupBy
        '
        Me.CHBX_IJAllGroupBy.AutoSize = True
        Me.CHBX_IJAllGroupBy.CheckAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.CHBX_IJAllGroupBy.Location = New System.Drawing.Point(226, 22)
        Me.CHBX_IJAllGroupBy.Name = "CHBX_IJAllGroupBy"
        Me.CHBX_IJAllGroupBy.Size = New System.Drawing.Size(22, 31)
        Me.CHBX_IJAllGroupBy.TabIndex = 40
        Me.CHBX_IJAllGroupBy.Text = "All"
        Me.CHBX_IJAllGroupBy.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.CHBX_IJAllGroupBy.UseVisualStyleBackColor = True
        '
        'CMBX_IJGroupBy
        '
        Me.CMBX_IJGroupBy.FormattingEnabled = True
        Me.CMBX_IJGroupBy.Items.AddRange(New Object() {"Date", "Month", "Year", "Facility", "Item", "Adjustment Reason"})
        Me.CMBX_IJGroupBy.Location = New System.Drawing.Point(11, 32)
        Me.CMBX_IJGroupBy.Name = "CMBX_IJGroupBy"
        Me.CMBX_IJGroupBy.Size = New System.Drawing.Size(209, 21)
        Me.CMBX_IJGroupBy.TabIndex = 39
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(8, 16)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(51, 13)
        Me.Label9.TabIndex = 38
        Me.Label9.Text = "Group By"
        '
        'CHBX_IJAllItemNames
        '
        Me.CHBX_IJAllItemNames.AutoSize = True
        Me.CHBX_IJAllItemNames.CheckAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.CHBX_IJAllItemNames.Location = New System.Drawing.Point(224, 219)
        Me.CHBX_IJAllItemNames.Name = "CHBX_IJAllItemNames"
        Me.CHBX_IJAllItemNames.Size = New System.Drawing.Size(22, 31)
        Me.CHBX_IJAllItemNames.TabIndex = 36
        Me.CHBX_IJAllItemNames.Text = "All"
        Me.CHBX_IJAllItemNames.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.CHBX_IJAllItemNames.UseVisualStyleBackColor = True
        '
        'CHBX_IJAllDates
        '
        Me.CHBX_IJAllDates.AutoSize = True
        Me.CHBX_IJAllDates.CheckAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.CHBX_IJAllDates.Location = New System.Drawing.Point(224, 179)
        Me.CHBX_IJAllDates.Name = "CHBX_IJAllDates"
        Me.CHBX_IJAllDates.Size = New System.Drawing.Size(22, 31)
        Me.CHBX_IJAllDates.TabIndex = 35
        Me.CHBX_IJAllDates.Text = "All"
        Me.CHBX_IJAllDates.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.CHBX_IJAllDates.UseVisualStyleBackColor = True
        '
        'CMBX_IJItemName
        '
        Me.CMBX_IJItemName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.CMBX_IJItemName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBX_IJItemName.FormattingEnabled = True
        Me.CMBX_IJItemName.Location = New System.Drawing.Point(9, 229)
        Me.CMBX_IJItemName.Name = "CMBX_IJItemName"
        Me.CMBX_IJItemName.Size = New System.Drawing.Size(209, 21)
        Me.CMBX_IJItemName.TabIndex = 31
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(6, 213)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(58, 13)
        Me.Label7.TabIndex = 30
        Me.Label7.Text = "Item Name"
        '
        'DTP_IJSummary_To
        '
        Me.DTP_IJSummary_To.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DTP_IJSummary_To.Location = New System.Drawing.Point(118, 190)
        Me.DTP_IJSummary_To.Name = "DTP_IJSummary_To"
        Me.DTP_IJSummary_To.Size = New System.Drawing.Size(100, 20)
        Me.DTP_IJSummary_To.TabIndex = 25
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(115, 174)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(20, 13)
        Me.Label10.TabIndex = 24
        Me.Label10.Text = "To"
        '
        'DTP_IJSummary_From
        '
        Me.DTP_IJSummary_From.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DTP_IJSummary_From.Location = New System.Drawing.Point(9, 190)
        Me.DTP_IJSummary_From.Name = "DTP_IJSummary_From"
        Me.DTP_IJSummary_From.Size = New System.Drawing.Size(100, 20)
        Me.DTP_IJSummary_From.TabIndex = 23
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(6, 174)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(30, 13)
        Me.Label11.TabIndex = 22
        Me.Label11.Text = "From"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(3, 7)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(66, 13)
        Me.Label6.TabIndex = 28
        Me.Label6.Text = "Report Type"
        '
        'CMBX_IJSummaryRepoType
        '
        Me.CMBX_IJSummaryRepoType.FormattingEnabled = True
        Me.CMBX_IJSummaryRepoType.Items.AddRange(New Object() {"Items Received", "Items Distributed", "GRV Items Received", "Items Adjustment Plus", "Items Adjustment Minus", "Discarded Items", "OPD Items Distributed", "IPD Items Distributed"})
        Me.CMBX_IJSummaryRepoType.Location = New System.Drawing.Point(6, 23)
        Me.CMBX_IJSummaryRepoType.Name = "CMBX_IJSummaryRepoType"
        Me.CMBX_IJSummaryRepoType.Size = New System.Drawing.Size(231, 21)
        Me.CMBX_IJSummaryRepoType.TabIndex = 29
        '
        'TB_Financial
        '
        Me.TB_Financial.Controls.Add(Me.GBX_FN)
        Me.TB_Financial.Controls.Add(Me.Label21)
        Me.TB_Financial.Controls.Add(Me.CMBX_FNSummaryRepoType)
        Me.TB_Financial.Location = New System.Drawing.Point(4, 22)
        Me.TB_Financial.Name = "TB_Financial"
        Me.TB_Financial.Padding = New System.Windows.Forms.Padding(3)
        Me.TB_Financial.Size = New System.Drawing.Size(262, 519)
        Me.TB_Financial.TabIndex = 5
        Me.TB_Financial.Text = "Financial"
        Me.TB_Financial.UseVisualStyleBackColor = True
        '
        'GBX_FN
        '
        Me.GBX_FN.Controls.Add(Me.CHBX_VoidTransactionsF)
        Me.GBX_FN.Controls.Add(Me.GBX_FNFilter)
        Me.GBX_FN.Controls.Add(Me.CHBX_FNAllGroupBy)
        Me.GBX_FN.Controls.Add(Me.CMBX_FNGroupBy)
        Me.GBX_FN.Controls.Add(Me.Label17)
        Me.GBX_FN.Controls.Add(Me.CHBX_FNAllDates)
        Me.GBX_FN.Controls.Add(Me.DTP_FNSummary_To)
        Me.GBX_FN.Controls.Add(Me.Label19)
        Me.GBX_FN.Controls.Add(Me.DTP_FNSummary_From)
        Me.GBX_FN.Controls.Add(Me.Label20)
        Me.GBX_FN.Enabled = False
        Me.GBX_FN.Location = New System.Drawing.Point(6, 46)
        Me.GBX_FN.Name = "GBX_FN"
        Me.GBX_FN.Size = New System.Drawing.Size(253, 255)
        Me.GBX_FN.TabIndex = 47
        Me.GBX_FN.TabStop = False
        '
        'CHBX_VoidTransactionsF
        '
        Me.CHBX_VoidTransactionsF.AutoSize = True
        Me.CHBX_VoidTransactionsF.Location = New System.Drawing.Point(6, 229)
        Me.CHBX_VoidTransactionsF.Name = "CHBX_VoidTransactionsF"
        Me.CHBX_VoidTransactionsF.Size = New System.Drawing.Size(111, 17)
        Me.CHBX_VoidTransactionsF.TabIndex = 45
        Me.CHBX_VoidTransactionsF.Text = "Void Transactions"
        Me.CHBX_VoidTransactionsF.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.CHBX_VoidTransactionsF.UseVisualStyleBackColor = True
        '
        'GBX_FNFilter
        '
        Me.GBX_FNFilter.Controls.Add(Me.LBL_FNFilter2)
        Me.GBX_FNFilter.Controls.Add(Me.CMBX_FNFilter2)
        Me.GBX_FNFilter.Controls.Add(Me.LBL_FNFilter1)
        Me.GBX_FNFilter.Controls.Add(Me.CMBX_FNFilter1)
        Me.GBX_FNFilter.Location = New System.Drawing.Point(29, 54)
        Me.GBX_FNFilter.Name = "GBX_FNFilter"
        Me.GBX_FNFilter.Size = New System.Drawing.Size(219, 98)
        Me.GBX_FNFilter.TabIndex = 43
        Me.GBX_FNFilter.TabStop = False
        '
        'LBL_FNFilter2
        '
        Me.LBL_FNFilter2.AutoSize = True
        Me.LBL_FNFilter2.Location = New System.Drawing.Point(2, 55)
        Me.LBL_FNFilter2.Name = "LBL_FNFilter2"
        Me.LBL_FNFilter2.Size = New System.Drawing.Size(35, 13)
        Me.LBL_FNFilter2.TabIndex = 52
        Me.LBL_FNFilter2.Text = "Filter2"
        '
        'CMBX_FNFilter2
        '
        Me.CMBX_FNFilter2.FormattingEnabled = True
        Me.CMBX_FNFilter2.Location = New System.Drawing.Point(4, 71)
        Me.CMBX_FNFilter2.Name = "CMBX_FNFilter2"
        Me.CMBX_FNFilter2.Size = New System.Drawing.Size(185, 21)
        Me.CMBX_FNFilter2.TabIndex = 50
        '
        'LBL_FNFilter1
        '
        Me.LBL_FNFilter1.AutoSize = True
        Me.LBL_FNFilter1.Location = New System.Drawing.Point(2, 11)
        Me.LBL_FNFilter1.Name = "LBL_FNFilter1"
        Me.LBL_FNFilter1.Size = New System.Drawing.Size(35, 13)
        Me.LBL_FNFilter1.TabIndex = 43
        Me.LBL_FNFilter1.Text = "Filter1"
        '
        'CMBX_FNFilter1
        '
        Me.CMBX_FNFilter1.FormattingEnabled = True
        Me.CMBX_FNFilter1.Location = New System.Drawing.Point(5, 27)
        Me.CMBX_FNFilter1.Name = "CMBX_FNFilter1"
        Me.CMBX_FNFilter1.Size = New System.Drawing.Size(185, 21)
        Me.CMBX_FNFilter1.TabIndex = 27
        '
        'CHBX_FNAllGroupBy
        '
        Me.CHBX_FNAllGroupBy.AutoSize = True
        Me.CHBX_FNAllGroupBy.CheckAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.CHBX_FNAllGroupBy.Location = New System.Drawing.Point(226, 22)
        Me.CHBX_FNAllGroupBy.Name = "CHBX_FNAllGroupBy"
        Me.CHBX_FNAllGroupBy.Size = New System.Drawing.Size(22, 31)
        Me.CHBX_FNAllGroupBy.TabIndex = 40
        Me.CHBX_FNAllGroupBy.Text = "All"
        Me.CHBX_FNAllGroupBy.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.CHBX_FNAllGroupBy.UseVisualStyleBackColor = True
        Me.CHBX_FNAllGroupBy.Visible = False
        '
        'CMBX_FNGroupBy
        '
        Me.CMBX_FNGroupBy.FormattingEnabled = True
        Me.CMBX_FNGroupBy.Items.AddRange(New Object() {"Date", "Month", "Year", "Facility", "Item", "Adjustment Reason"})
        Me.CMBX_FNGroupBy.Location = New System.Drawing.Point(11, 32)
        Me.CMBX_FNGroupBy.Name = "CMBX_FNGroupBy"
        Me.CMBX_FNGroupBy.Size = New System.Drawing.Size(220, 21)
        Me.CMBX_FNGroupBy.TabIndex = 39
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(8, 16)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(51, 13)
        Me.Label17.TabIndex = 38
        Me.Label17.Text = "Group By"
        '
        'CHBX_FNAllDates
        '
        Me.CHBX_FNAllDates.AutoSize = True
        Me.CHBX_FNAllDates.CheckAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.CHBX_FNAllDates.Location = New System.Drawing.Point(224, 179)
        Me.CHBX_FNAllDates.Name = "CHBX_FNAllDates"
        Me.CHBX_FNAllDates.Size = New System.Drawing.Size(22, 31)
        Me.CHBX_FNAllDates.TabIndex = 35
        Me.CHBX_FNAllDates.Text = "All"
        Me.CHBX_FNAllDates.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.CHBX_FNAllDates.UseVisualStyleBackColor = True
        '
        'DTP_FNSummary_To
        '
        Me.DTP_FNSummary_To.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DTP_FNSummary_To.Location = New System.Drawing.Point(118, 190)
        Me.DTP_FNSummary_To.Name = "DTP_FNSummary_To"
        Me.DTP_FNSummary_To.Size = New System.Drawing.Size(100, 20)
        Me.DTP_FNSummary_To.TabIndex = 25
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(115, 174)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(20, 13)
        Me.Label19.TabIndex = 24
        Me.Label19.Text = "To"
        '
        'DTP_FNSummary_From
        '
        Me.DTP_FNSummary_From.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DTP_FNSummary_From.Location = New System.Drawing.Point(9, 190)
        Me.DTP_FNSummary_From.Name = "DTP_FNSummary_From"
        Me.DTP_FNSummary_From.Size = New System.Drawing.Size(100, 20)
        Me.DTP_FNSummary_From.TabIndex = 23
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(6, 174)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(30, 13)
        Me.Label20.TabIndex = 22
        Me.Label20.Text = "From"
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(3, 7)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(66, 13)
        Me.Label21.TabIndex = 45
        Me.Label21.Text = "Report Type"
        '
        'CMBX_FNSummaryRepoType
        '
        Me.CMBX_FNSummaryRepoType.FormattingEnabled = True
        Me.CMBX_FNSummaryRepoType.Items.AddRange(New Object() {"Items Received", "Items Distributed", "Item Consumed", "GRV Items Received", "Items Adjustment Plus", "Items Adjustment Minus", "Discarded Items", "OPD Items Distributed", "IPD Items Distributed"})
        Me.CMBX_FNSummaryRepoType.Location = New System.Drawing.Point(6, 23)
        Me.CMBX_FNSummaryRepoType.Name = "CMBX_FNSummaryRepoType"
        Me.CMBX_FNSummaryRepoType.Size = New System.Drawing.Size(231, 21)
        Me.CMBX_FNSummaryRepoType.TabIndex = 46
        '
        'TB_Analysis
        '
        Me.TB_Analysis.Controls.Add(Me.GBX_AN)
        Me.TB_Analysis.Controls.Add(Me.Label18)
        Me.TB_Analysis.Controls.Add(Me.CMBX_ANSummaryRepoType)
        Me.TB_Analysis.Location = New System.Drawing.Point(4, 22)
        Me.TB_Analysis.Name = "TB_Analysis"
        Me.TB_Analysis.Padding = New System.Windows.Forms.Padding(3)
        Me.TB_Analysis.Size = New System.Drawing.Size(262, 519)
        Me.TB_Analysis.TabIndex = 3
        Me.TB_Analysis.Text = "Analysis"
        Me.TB_Analysis.UseVisualStyleBackColor = True
        '
        'GBX_AN
        '
        Me.GBX_AN.Controls.Add(Me.CHBX_ANAllDates)
        Me.GBX_AN.Controls.Add(Me.DTP_ANSummary_To)
        Me.GBX_AN.Controls.Add(Me.Label1)
        Me.GBX_AN.Controls.Add(Me.DTP_ANSummary_From)
        Me.GBX_AN.Controls.Add(Me.Label2)
        Me.GBX_AN.Controls.Add(Me.CMBX_ANGroupBy)
        Me.GBX_AN.Controls.Add(Me.LBL_ANGroup)
        Me.GBX_AN.Enabled = False
        Me.GBX_AN.Location = New System.Drawing.Point(6, 46)
        Me.GBX_AN.Name = "GBX_AN"
        Me.GBX_AN.Size = New System.Drawing.Size(253, 117)
        Me.GBX_AN.TabIndex = 47
        Me.GBX_AN.TabStop = False
        '
        'CHBX_ANAllDates
        '
        Me.CHBX_ANAllDates.AutoSize = True
        Me.CHBX_ANAllDates.CheckAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.CHBX_ANAllDates.Location = New System.Drawing.Point(224, 73)
        Me.CHBX_ANAllDates.Name = "CHBX_ANAllDates"
        Me.CHBX_ANAllDates.Size = New System.Drawing.Size(22, 31)
        Me.CHBX_ANAllDates.TabIndex = 48
        Me.CHBX_ANAllDates.Text = "All"
        Me.CHBX_ANAllDates.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.CHBX_ANAllDates.UseVisualStyleBackColor = True
        '
        'DTP_ANSummary_To
        '
        Me.DTP_ANSummary_To.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DTP_ANSummary_To.Location = New System.Drawing.Point(118, 84)
        Me.DTP_ANSummary_To.Name = "DTP_ANSummary_To"
        Me.DTP_ANSummary_To.Size = New System.Drawing.Size(100, 20)
        Me.DTP_ANSummary_To.TabIndex = 47
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(115, 68)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(20, 13)
        Me.Label1.TabIndex = 46
        Me.Label1.Text = "To"
        '
        'DTP_ANSummary_From
        '
        Me.DTP_ANSummary_From.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DTP_ANSummary_From.Location = New System.Drawing.Point(9, 84)
        Me.DTP_ANSummary_From.Name = "DTP_ANSummary_From"
        Me.DTP_ANSummary_From.Size = New System.Drawing.Size(100, 20)
        Me.DTP_ANSummary_From.TabIndex = 45
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(8, 68)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(30, 13)
        Me.Label2.TabIndex = 44
        Me.Label2.Text = "From"
        '
        'CMBX_ANGroupBy
        '
        Me.CMBX_ANGroupBy.FormattingEnabled = True
        Me.CMBX_ANGroupBy.Items.AddRange(New Object() {"Date", "Month", "Year", "Facility", "Item", "Adjustment Reason"})
        Me.CMBX_ANGroupBy.Location = New System.Drawing.Point(11, 32)
        Me.CMBX_ANGroupBy.Name = "CMBX_ANGroupBy"
        Me.CMBX_ANGroupBy.Size = New System.Drawing.Size(209, 21)
        Me.CMBX_ANGroupBy.TabIndex = 39
        '
        'LBL_ANGroup
        '
        Me.LBL_ANGroup.AutoSize = True
        Me.LBL_ANGroup.Location = New System.Drawing.Point(8, 16)
        Me.LBL_ANGroup.Name = "LBL_ANGroup"
        Me.LBL_ANGroup.Size = New System.Drawing.Size(51, 13)
        Me.LBL_ANGroup.TabIndex = 38
        Me.LBL_ANGroup.Text = "Group By"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(3, 7)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(66, 13)
        Me.Label18.TabIndex = 45
        Me.Label18.Text = "Report Type"
        '
        'CMBX_ANSummaryRepoType
        '
        Me.CMBX_ANSummaryRepoType.FormattingEnabled = True
        Me.CMBX_ANSummaryRepoType.Items.AddRange(New Object() {"Receive", "Consumption by Classification", "Consumption by Stock Items", "Consumption by Facility Type", "Consumption by Facility", "Consumption Top Ten", "Distribution", "Distribution by Facility Type", "Stock Card Financial Summary", "ABC Analysis", "Request vs Receive", "Consumption vs Distribution", "Requisition vs Distribution", "Lead Time"})
        Me.CMBX_ANSummaryRepoType.Location = New System.Drawing.Point(6, 23)
        Me.CMBX_ANSummaryRepoType.Name = "CMBX_ANSummaryRepoType"
        Me.CMBX_ANSummaryRepoType.Size = New System.Drawing.Size(231, 21)
        Me.CMBX_ANSummaryRepoType.TabIndex = 46
        '
        'TB_History
        '
        Me.TB_History.Controls.Add(Me.GroupBox1)
        Me.TB_History.Controls.Add(Me.Label15)
        Me.TB_History.Controls.Add(Me.CMBX_TransactionType)
        Me.TB_History.Location = New System.Drawing.Point(4, 22)
        Me.TB_History.Name = "TB_History"
        Me.TB_History.Padding = New System.Windows.Forms.Padding(3)
        Me.TB_History.Size = New System.Drawing.Size(262, 519)
        Me.TB_History.TabIndex = 4
        Me.TB_History.Text = "History"
        Me.TB_History.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.TBX_SearchTerm)
        Me.GroupBox1.Controls.Add(Me.CHBX_Void)
        Me.GroupBox1.Controls.Add(Me.Label24)
        Me.GroupBox1.Controls.Add(Me.LBL_SearchResult)
        Me.GroupBox1.Controls.Add(Me.BTN_Void)
        Me.GroupBox1.Controls.Add(Me.dfd)
        Me.GroupBox1.Controls.Add(Me.LBX_SearchResults)
        Me.GroupBox1.Controls.Add(Me.BTN_Search)
        Me.GroupBox1.Controls.Add(Me.Label23)
        Me.GroupBox1.Controls.Add(Me.CMBX_SearchBy)
        Me.GroupBox1.Controls.Add(Me.CHBX_HAllDates)
        Me.GroupBox1.Controls.Add(Me.LBL_SearchTerm)
        Me.GroupBox1.Controls.Add(Me.DTP_H_To)
        Me.GroupBox1.Controls.Add(Me.Label25)
        Me.GroupBox1.Controls.Add(Me.DTP_H_From)
        Me.GroupBox1.Controls.Add(Me.Label26)
        Me.GroupBox1.Location = New System.Drawing.Point(6, 50)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(253, 463)
        Me.GroupBox1.TabIndex = 54
        Me.GroupBox1.TabStop = False
        '
        'TBX_SearchTerm
        '
        Me.TBX_SearchTerm.FormattingEnabled = True
        Me.TBX_SearchTerm.Items.AddRange(New Object() {"ID"})
        Me.TBX_SearchTerm.Location = New System.Drawing.Point(11, 71)
        Me.TBX_SearchTerm.Name = "TBX_SearchTerm"
        Me.TBX_SearchTerm.Size = New System.Drawing.Size(235, 21)
        Me.TBX_SearchTerm.TabIndex = 62
        '
        'CHBX_Void
        '
        Me.CHBX_Void.AutoSize = True
        Me.CHBX_Void.CheckAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.CHBX_Void.Location = New System.Drawing.Point(203, 39)
        Me.CHBX_Void.Name = "CHBX_Void"
        Me.CHBX_Void.Size = New System.Drawing.Size(15, 14)
        Me.CHBX_Void.TabIndex = 61
        Me.CHBX_Void.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.CHBX_Void.UseVisualStyleBackColor = True
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Location = New System.Drawing.Point(182, 16)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(65, 13)
        Me.Label24.TabIndex = 60
        Me.Label24.Text = "Search Void"
        '
        'LBL_SearchResult
        '
        Me.LBL_SearchResult.AutoSize = True
        Me.LBL_SearchResult.Location = New System.Drawing.Point(3, 172)
        Me.LBL_SearchResult.Name = "LBL_SearchResult"
        Me.LBL_SearchResult.Size = New System.Drawing.Size(89, 13)
        Me.LBL_SearchResult.TabIndex = 59
        Me.LBL_SearchResult.Text = "Records found: 0"
        '
        'BTN_Void
        '
        Me.BTN_Void.BackColor = System.Drawing.Color.Red
        Me.BTN_Void.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BTN_Void.ForeColor = System.Drawing.SystemColors.ControlLight
        Me.BTN_Void.Location = New System.Drawing.Point(171, 146)
        Me.BTN_Void.Name = "BTN_Void"
        Me.BTN_Void.Size = New System.Drawing.Size(75, 23)
        Me.BTN_Void.TabIndex = 58
        Me.BTN_Void.Text = "Void"
        Me.BTN_Void.UseVisualStyleBackColor = False
        '
        'dfd
        '
        Me.dfd.AutoSize = True
        Me.dfd.Location = New System.Drawing.Point(8, 172)
        Me.dfd.Name = "dfd"
        Me.dfd.Size = New System.Drawing.Size(0, 13)
        Me.dfd.TabIndex = 37
        '
        'LBX_SearchResults
        '
        Me.LBX_SearchResults.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.LBX_SearchResults.FormattingEnabled = True
        Me.LBX_SearchResults.Location = New System.Drawing.Point(6, 188)
        Me.LBX_SearchResults.Name = "LBX_SearchResults"
        Me.LBX_SearchResults.Size = New System.Drawing.Size(240, 251)
        Me.LBX_SearchResults.TabIndex = 37
        '
        'BTN_Search
        '
        Me.BTN_Search.Location = New System.Drawing.Point(6, 146)
        Me.BTN_Search.Name = "BTN_Search"
        Me.BTN_Search.Size = New System.Drawing.Size(75, 23)
        Me.BTN_Search.TabIndex = 37
        Me.BTN_Search.Text = "Search"
        Me.BTN_Search.UseVisualStyleBackColor = True
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Location = New System.Drawing.Point(8, 16)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(56, 13)
        Me.Label23.TabIndex = 55
        Me.Label23.Text = "Search By"
        '
        'CMBX_SearchBy
        '
        Me.CMBX_SearchBy.FormattingEnabled = True
        Me.CMBX_SearchBy.Items.AddRange(New Object() {"ID"})
        Me.CMBX_SearchBy.Location = New System.Drawing.Point(11, 32)
        Me.CMBX_SearchBy.Name = "CMBX_SearchBy"
        Me.CMBX_SearchBy.Size = New System.Drawing.Size(172, 21)
        Me.CMBX_SearchBy.TabIndex = 56
        '
        'CHBX_HAllDates
        '
        Me.CHBX_HAllDates.AutoSize = True
        Me.CHBX_HAllDates.CheckAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.CHBX_HAllDates.Location = New System.Drawing.Point(224, 100)
        Me.CHBX_HAllDates.Name = "CHBX_HAllDates"
        Me.CHBX_HAllDates.Size = New System.Drawing.Size(22, 31)
        Me.CHBX_HAllDates.TabIndex = 48
        Me.CHBX_HAllDates.Text = "All"
        Me.CHBX_HAllDates.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.CHBX_HAllDates.UseVisualStyleBackColor = True
        '
        'LBL_SearchTerm
        '
        Me.LBL_SearchTerm.AutoSize = True
        Me.LBL_SearchTerm.Location = New System.Drawing.Point(9, 56)
        Me.LBL_SearchTerm.Name = "LBL_SearchTerm"
        Me.LBL_SearchTerm.Size = New System.Drawing.Size(68, 13)
        Me.LBL_SearchTerm.TabIndex = 49
        Me.LBL_SearchTerm.Text = "Search Term"
        '
        'DTP_H_To
        '
        Me.DTP_H_To.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DTP_H_To.Location = New System.Drawing.Point(118, 111)
        Me.DTP_H_To.Name = "DTP_H_To"
        Me.DTP_H_To.Size = New System.Drawing.Size(100, 20)
        Me.DTP_H_To.TabIndex = 47
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Location = New System.Drawing.Point(115, 95)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(20, 13)
        Me.Label25.TabIndex = 46
        Me.Label25.Text = "To"
        '
        'DTP_H_From
        '
        Me.DTP_H_From.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DTP_H_From.Location = New System.Drawing.Point(9, 111)
        Me.DTP_H_From.Name = "DTP_H_From"
        Me.DTP_H_From.Size = New System.Drawing.Size(100, 20)
        Me.DTP_H_From.TabIndex = 45
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Location = New System.Drawing.Point(8, 95)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(30, 13)
        Me.Label26.TabIndex = 44
        Me.Label26.Text = "From"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(3, 7)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(90, 13)
        Me.Label15.TabIndex = 47
        Me.Label15.Text = "Transaction Type"
        '
        'CMBX_TransactionType
        '
        Me.CMBX_TransactionType.FormattingEnabled = True
        Me.CMBX_TransactionType.Items.AddRange(New Object() {"Supply Request", "Supply Receive", "Facility Invoice", "Adjustment In", "Adjustment Out", "Adjustment Dicard", "Adjustment Exchange", "OPD", "Satellite", "GRV"})
        Me.CMBX_TransactionType.Location = New System.Drawing.Point(6, 23)
        Me.CMBX_TransactionType.Name = "CMBX_TransactionType"
        Me.CMBX_TransactionType.Size = New System.Drawing.Size(246, 21)
        Me.CMBX_TransactionType.TabIndex = 48
        '
        'TB_Static
        '
        Me.TB_Static.Controls.Add(Me.GBX_SD)
        Me.TB_Static.Controls.Add(Me.Label30)
        Me.TB_Static.Controls.Add(Me.CMBX_SDRepoType)
        Me.TB_Static.Location = New System.Drawing.Point(4, 22)
        Me.TB_Static.Name = "TB_Static"
        Me.TB_Static.Padding = New System.Windows.Forms.Padding(3)
        Me.TB_Static.Size = New System.Drawing.Size(262, 519)
        Me.TB_Static.TabIndex = 6
        Me.TB_Static.Text = "Others"
        Me.TB_Static.UseVisualStyleBackColor = True
        '
        'GBX_SD
        '
        Me.GBX_SD.Controls.Add(Me.CHBX_SDSearchAll)
        Me.GBX_SD.Controls.Add(Me.Label22)
        Me.GBX_SD.Controls.Add(Me.Label33)
        Me.GBX_SD.Controls.Add(Me.CMBX_SDSearchBy)
        Me.GBX_SD.Controls.Add(Me.DTP_SD_To)
        Me.GBX_SD.Controls.Add(Me.Label31)
        Me.GBX_SD.Controls.Add(Me.DTP_SD_From)
        Me.GBX_SD.Controls.Add(Me.Label32)
        Me.GBX_SD.Location = New System.Drawing.Point(6, 50)
        Me.GBX_SD.Name = "GBX_SD"
        Me.GBX_SD.Size = New System.Drawing.Size(246, 118)
        Me.GBX_SD.TabIndex = 51
        Me.GBX_SD.TabStop = False
        '
        'CHBX_SDSearchAll
        '
        Me.CHBX_SDSearchAll.AutoSize = True
        Me.CHBX_SDSearchAll.CheckAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.CHBX_SDSearchAll.Location = New System.Drawing.Point(199, 39)
        Me.CHBX_SDSearchAll.Name = "CHBX_SDSearchAll"
        Me.CHBX_SDSearchAll.Size = New System.Drawing.Size(15, 14)
        Me.CHBX_SDSearchAll.TabIndex = 65
        Me.CHBX_SDSearchAll.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.CHBX_SDSearchAll.UseVisualStyleBackColor = True
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(196, 16)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(18, 13)
        Me.Label22.TabIndex = 64
        Me.Label22.Text = "All"
        '
        'Label33
        '
        Me.Label33.AutoSize = True
        Me.Label33.Location = New System.Drawing.Point(4, 16)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(56, 13)
        Me.Label33.TabIndex = 62
        Me.Label33.Text = "Search By"
        '
        'CMBX_SDSearchBy
        '
        Me.CMBX_SDSearchBy.FormattingEnabled = True
        Me.CMBX_SDSearchBy.Items.AddRange(New Object() {"ID"})
        Me.CMBX_SDSearchBy.Location = New System.Drawing.Point(7, 32)
        Me.CMBX_SDSearchBy.Name = "CMBX_SDSearchBy"
        Me.CMBX_SDSearchBy.Size = New System.Drawing.Size(172, 21)
        Me.CMBX_SDSearchBy.TabIndex = 63
        '
        'DTP_SD_To
        '
        Me.DTP_SD_To.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DTP_SD_To.Location = New System.Drawing.Point(118, 84)
        Me.DTP_SD_To.Name = "DTP_SD_To"
        Me.DTP_SD_To.Size = New System.Drawing.Size(100, 20)
        Me.DTP_SD_To.TabIndex = 47
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.Location = New System.Drawing.Point(115, 68)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(20, 13)
        Me.Label31.TabIndex = 46
        Me.Label31.Text = "To"
        '
        'DTP_SD_From
        '
        Me.DTP_SD_From.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DTP_SD_From.Location = New System.Drawing.Point(9, 84)
        Me.DTP_SD_From.Name = "DTP_SD_From"
        Me.DTP_SD_From.Size = New System.Drawing.Size(100, 20)
        Me.DTP_SD_From.TabIndex = 45
        '
        'Label32
        '
        Me.Label32.AutoSize = True
        Me.Label32.Location = New System.Drawing.Point(8, 68)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(30, 13)
        Me.Label32.TabIndex = 44
        Me.Label32.Text = "From"
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.Location = New System.Drawing.Point(3, 7)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(66, 13)
        Me.Label30.TabIndex = 49
        Me.Label30.Text = "Report Type"
        '
        'CMBX_SDRepoType
        '
        Me.CMBX_SDRepoType.FormattingEnabled = True
        Me.CMBX_SDRepoType.Items.AddRange(New Object() {"Facilities", "Store and Locations", "Rooms and Beds", "Employee Transactions", "OPD Patient visit frequency"})
        Me.CMBX_SDRepoType.Location = New System.Drawing.Point(6, 23)
        Me.CMBX_SDRepoType.Name = "CMBX_SDRepoType"
        Me.CMBX_SDRepoType.Size = New System.Drawing.Size(246, 21)
        Me.CMBX_SDRepoType.TabIndex = 50
        '
        'BTN_Close
        '
        Me.BTN_Close.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.BTN_Close.Location = New System.Drawing.Point(191, 629)
        Me.BTN_Close.Name = "BTN_Close"
        Me.BTN_Close.Size = New System.Drawing.Size(81, 26)
        Me.BTN_Close.TabIndex = 8
        Me.BTN_Close.Text = "Close"
        Me.BTN_Close.UseVisualStyleBackColor = True
        '
        'BTN_Report
        '
        Me.BTN_Report.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.BTN_Report.Location = New System.Drawing.Point(98, 629)
        Me.BTN_Report.Name = "BTN_Report"
        Me.BTN_Report.Size = New System.Drawing.Size(81, 26)
        Me.BTN_Report.TabIndex = 7
        Me.BTN_Report.Text = "Summary"
        Me.BTN_Report.UseVisualStyleBackColor = True
        '
        'ERP_Error
        '
        Me.ERP_Error.ContainerControl = Me
        '
        'BTN_Detailed
        '
        Me.BTN_Detailed.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.BTN_Detailed.Location = New System.Drawing.Point(4, 629)
        Me.BTN_Detailed.Name = "BTN_Detailed"
        Me.BTN_Detailed.Size = New System.Drawing.Size(81, 26)
        Me.BTN_Detailed.TabIndex = 9
        Me.BTN_Detailed.Text = "Detailed"
        Me.BTN_Detailed.UseVisualStyleBackColor = True
        '
        'CMBX_RepoForDepa
        '
        Me.CMBX_RepoForDepa.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.CMBX_RepoForDepa.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.CMBX_RepoForDepa.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.CMBX_RepoForDepa.Enabled = False
        Me.CMBX_RepoForDepa.FormattingEnabled = True
        Me.CMBX_RepoForDepa.Items.AddRange(New Object() {"Date", "Month", "Year", "Facility", "Item", "Adjustment Reason"})
        Me.CMBX_RepoForDepa.Location = New System.Drawing.Point(17, 42)
        Me.CMBX_RepoForDepa.Name = "CMBX_RepoForDepa"
        Me.CMBX_RepoForDepa.Size = New System.Drawing.Size(220, 21)
        Me.CMBX_RepoForDepa.TabIndex = 42
        '
        'CHBX_ReportForDepa
        '
        Me.CHBX_ReportForDepa.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.CHBX_ReportForDepa.AutoSize = True
        Me.CHBX_ReportForDepa.Checked = True
        Me.CHBX_ReportForDepa.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CHBX_ReportForDepa.Location = New System.Drawing.Point(17, 19)
        Me.CHBX_ReportForDepa.Name = "CHBX_ReportForDepa"
        Me.CHBX_ReportForDepa.Size = New System.Drawing.Size(75, 17)
        Me.CHBX_ReportForDepa.TabIndex = 43
        Me.CHBX_ReportForDepa.Text = "My Facility"
        Me.CHBX_ReportForDepa.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.CHBX_ReportForDepa.UseVisualStyleBackColor = True
        '
        'GBX_RepoForDepa
        '
        Me.GBX_RepoForDepa.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.GBX_RepoForDepa.Controls.Add(Me.CHBX_ReportForAllDepa)
        Me.GBX_RepoForDepa.Controls.Add(Me.CHBX_ReportForDepa)
        Me.GBX_RepoForDepa.Controls.Add(Me.CMBX_RepoForDepa)
        Me.GBX_RepoForDepa.Location = New System.Drawing.Point(6, 551)
        Me.GBX_RepoForDepa.Name = "GBX_RepoForDepa"
        Me.GBX_RepoForDepa.Size = New System.Drawing.Size(262, 72)
        Me.GBX_RepoForDepa.TabIndex = 36
        Me.GBX_RepoForDepa.TabStop = False
        Me.GBX_RepoForDepa.Text = "Report for Facility"
        '
        'CHBX_ReportForAllDepa
        '
        Me.CHBX_ReportForAllDepa.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.CHBX_ReportForAllDepa.AutoSize = True
        Me.CHBX_ReportForAllDepa.Location = New System.Drawing.Point(124, 19)
        Me.CHBX_ReportForAllDepa.Name = "CHBX_ReportForAllDepa"
        Me.CHBX_ReportForAllDepa.Size = New System.Drawing.Size(98, 17)
        Me.CHBX_ReportForAllDepa.TabIndex = 44
        Me.CHBX_ReportForAllDepa.Text = "For All Facilities"
        Me.CHBX_ReportForAllDepa.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.CHBX_ReportForAllDepa.UseVisualStyleBackColor = True
        '
        'FRM_Reporter
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(920, 662)
        Me.Controls.Add(Me.GBX_RepoForDepa)
        Me.Controls.Add(Me.BTN_Detailed)
        Me.Controls.Add(Me.BTN_Close)
        Me.Controls.Add(Me.BTN_Report)
        Me.Controls.Add(Me.TBC_Report)
        Me.Controls.Add(Me.CVWR_Reporter)
        Me.Name = "FRM_Reporter"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Report"
        Me.TBC_Report.ResumeLayout(False)
        Me.TB_Items.ResumeLayout(False)
        Me.TB_Items.PerformLayout()
        Me.GBX_OutofStock.ResumeLayout(False)
        Me.GBX_OutofStock.PerformLayout()
        Me.GBX_Catalogue.ResumeLayout(False)
        Me.GBX_Catalogue.PerformLayout()
        Me.GBX_StockBalance.ResumeLayout(False)
        Me.GBX_StockBalance.PerformLayout()
        Me.GBX_StockCard.ResumeLayout(False)
        Me.GBX_StockCard.PerformLayout()
        Me.GBX_ItemsExpiry.ResumeLayout(False)
        Me.GBX_ItemsExpiry.PerformLayout()
        Me.TB_Transaction.ResumeLayout(False)
        Me.TB_Transaction.PerformLayout()
        Me.GBX_IJ.ResumeLayout(False)
        Me.GBX_IJ.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GBX_IJFilter.ResumeLayout(False)
        Me.GBX_IJFilter.PerformLayout()
        Me.TB_Financial.ResumeLayout(False)
        Me.TB_Financial.PerformLayout()
        Me.GBX_FN.ResumeLayout(False)
        Me.GBX_FN.PerformLayout()
        Me.GBX_FNFilter.ResumeLayout(False)
        Me.GBX_FNFilter.PerformLayout()
        Me.TB_Analysis.ResumeLayout(False)
        Me.TB_Analysis.PerformLayout()
        Me.GBX_AN.ResumeLayout(False)
        Me.GBX_AN.PerformLayout()
        Me.TB_History.ResumeLayout(False)
        Me.TB_History.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.TB_Static.ResumeLayout(False)
        Me.TB_Static.PerformLayout()
        Me.GBX_SD.ResumeLayout(False)
        Me.GBX_SD.PerformLayout()
        CType(Me.ERP_Error, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GBX_RepoForDepa.ResumeLayout(False)
        Me.GBX_RepoForDepa.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents CVWR_Reporter As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents TBC_Report As System.Windows.Forms.TabControl
    Friend WithEvents TB_Items As System.Windows.Forms.TabPage
    Friend WithEvents TB_Transaction As System.Windows.Forms.TabPage
    Friend WithEvents RBTN_ItemExpiry As System.Windows.Forms.RadioButton
    Friend WithEvents GBX_ItemsExpiry As System.Windows.Forms.GroupBox
    Friend WithEvents DTP_ItemExpiry_From As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents RBTN_CatalogueList As System.Windows.Forms.RadioButton
    Friend WithEvents BTN_Close As System.Windows.Forms.Button
    Friend WithEvents BTN_Report As System.Windows.Forms.Button
    Friend WithEvents GBX_IJ As System.Windows.Forms.GroupBox
    Friend WithEvents RBTN_StockBalace As System.Windows.Forms.RadioButton
    Friend WithEvents CMBX_IJFilter1 As System.Windows.Forms.ComboBox
    Friend WithEvents CHBX_IJAllItemNames As System.Windows.Forms.CheckBox
    Friend WithEvents CHBX_IJAllItemGB As System.Windows.Forms.CheckBox
    Friend WithEvents CMBX_IJItemGB As System.Windows.Forms.ComboBox
    Friend WithEvents CMBX_IJItemName As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents CMBX_IJSummaryRepoType As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents ERP_Error As System.Windows.Forms.ErrorProvider
    Friend WithEvents BTN_Detailed As System.Windows.Forms.Button
    Friend WithEvents TB_Analysis As System.Windows.Forms.TabPage
    Friend WithEvents TB_History As System.Windows.Forms.TabPage
    Friend WithEvents CHBX_IJAllGroupBy As System.Windows.Forms.CheckBox
    Friend WithEvents CMBX_IJGroupBy As System.Windows.Forms.ComboBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents CMBX_IJItemGBList As System.Windows.Forms.ComboBox
    Friend WithEvents LBL_IJItemGB As System.Windows.Forms.Label
    Friend WithEvents TB_Financial As System.Windows.Forms.TabPage
    Friend WithEvents DTP_ItemExpiry_To As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents GBX_IJFilter As System.Windows.Forms.GroupBox
    Friend WithEvents LBL_IJFilter1 As System.Windows.Forms.Label
    Friend WithEvents CMBX_IJFilter2 As System.Windows.Forms.ComboBox
    Friend WithEvents LBL_IJFilter2 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents GBX_FN As System.Windows.Forms.GroupBox
    Friend WithEvents GBX_FNFilter As System.Windows.Forms.GroupBox
    Friend WithEvents LBL_FNFilter2 As System.Windows.Forms.Label
    Friend WithEvents CMBX_FNFilter2 As System.Windows.Forms.ComboBox
    Friend WithEvents LBL_FNFilter1 As System.Windows.Forms.Label
    Friend WithEvents CMBX_FNFilter1 As System.Windows.Forms.ComboBox
    Friend WithEvents CHBX_FNAllGroupBy As System.Windows.Forms.CheckBox
    Friend WithEvents CMBX_FNGroupBy As System.Windows.Forms.ComboBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents CHBX_FNAllDates As System.Windows.Forms.CheckBox
    Friend WithEvents DTP_FNSummary_To As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents DTP_FNSummary_From As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents CMBX_FNSummaryRepoType As System.Windows.Forms.ComboBox
    Friend WithEvents GBX_AN As System.Windows.Forms.GroupBox
    Friend WithEvents CMBX_ANGroupBy As System.Windows.Forms.ComboBox
    Friend WithEvents LBL_ANGroup As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents CMBX_ANSummaryRepoType As System.Windows.Forms.ComboBox
    Friend WithEvents CHBX_IJAllDates As System.Windows.Forms.CheckBox
    Friend WithEvents DTP_IJSummary_To As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents DTP_IJSummary_From As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents CHBX_ANAllDates As System.Windows.Forms.CheckBox
    Friend WithEvents DTP_ANSummary_To As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents DTP_ANSummary_From As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents CMBX_StockCardItem As System.Windows.Forms.ComboBox
    Friend WithEvents RBTN_StockCard As System.Windows.Forms.RadioButton
    Friend WithEvents CMBX_RepoForDepa As System.Windows.Forms.ComboBox
    Friend WithEvents CHBX_ReportForDepa As System.Windows.Forms.CheckBox
    Friend WithEvents GBX_RepoForDepa As System.Windows.Forms.GroupBox
    Friend WithEvents RBTN_ItemAlreadyExpired As System.Windows.Forms.RadioButton
    Friend WithEvents GBX_StockCard As System.Windows.Forms.GroupBox
    Friend WithEvents DTP_StockCard_To As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents DTP_StockCard_From As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents GBX_StockBalance As System.Windows.Forms.GroupBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents CMBX_StockBalanceItem As System.Windows.Forms.ComboBox
    Friend WithEvents RBTN_ItemsStockOut As System.Windows.Forms.RadioButton
    Friend WithEvents GBX_Catalogue As System.Windows.Forms.GroupBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents CMBX_Catalogue As System.Windows.Forms.ComboBox
    Friend WithEvents LBL_Catalogue As System.Windows.Forms.Label
    Friend WithEvents CMBX_CatalogueFilter As System.Windows.Forms.ComboBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents CMBX_TransactionType As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents CMBX_SearchBy As System.Windows.Forms.ComboBox
    Friend WithEvents CHBX_HAllDates As System.Windows.Forms.CheckBox
    Friend WithEvents LBL_SearchTerm As System.Windows.Forms.Label
    Friend WithEvents DTP_H_To As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents DTP_H_From As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents LBX_SearchResults As System.Windows.Forms.ListBox
    Friend WithEvents BTN_Search As System.Windows.Forms.Button
    Friend WithEvents dfd As System.Windows.Forms.Label
    Friend WithEvents BTN_Void As System.Windows.Forms.Button
    Friend WithEvents LBL_SearchResult As System.Windows.Forms.Label
    Friend WithEvents CHBX_Void As System.Windows.Forms.CheckBox
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents CHBX_STAllBy As System.Windows.Forms.CheckBox
    Friend WithEvents DTP_OutofStock As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents GBX_OutofStock As System.Windows.Forms.GroupBox
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents CMBX_OutofStock As System.Windows.Forms.ComboBox
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents CMBX_StockCategory As System.Windows.Forms.ComboBox
    Friend WithEvents CHBX_ReportForAllDepa As System.Windows.Forms.CheckBox
    Friend WithEvents TB_Static As System.Windows.Forms.TabPage
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents CMBX_SDRepoType As System.Windows.Forms.ComboBox
    Friend WithEvents GBX_SD As System.Windows.Forms.GroupBox
    Friend WithEvents DTP_SD_To As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents DTP_SD_From As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label32 As System.Windows.Forms.Label
    Friend WithEvents TBX_SearchTerm As System.Windows.Forms.ComboBox
    Friend WithEvents CHBX_SDSearchAll As System.Windows.Forms.CheckBox
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents Label33 As System.Windows.Forms.Label
    Friend WithEvents CMBX_SDSearchBy As System.Windows.Forms.ComboBox
    Friend WithEvents CHBX_VoidTransactionsT As System.Windows.Forms.CheckBox
    Friend WithEvents CHBX_VoidTransactionsF As System.Windows.Forms.CheckBox
    Friend WithEvents RBTN_InventorySheet As System.Windows.Forms.RadioButton
End Class
