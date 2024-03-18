<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FRM_GLBMain
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FRM_GLBMain))
        Me.MNU_Main = New System.Windows.Forms.MenuStrip()
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ChangePasswordToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.LoginToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MNIT_MTN = New System.Windows.Forms.ToolStripMenuItem()
        Me.MNIT_Item = New System.Windows.Forms.ToolStripMenuItem()
        Me.AddEditCatalogueToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BatchesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CategoriesAndClassificationsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ClassificationsAndSubClassificationToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RouteOfAdministrationToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.StorageRequirementTypesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TherapeuticClassToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PrescriptionStatusToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MNIT_AdjType = New System.Windows.Forms.ToolStripMenuItem()
        Me.MNIT_StoreNLocs = New System.Windows.Forms.ToolStripMenuItem()
        Me.MNIT_RoomsNBeds = New System.Windows.Forms.ToolStripMenuItem()
        Me.TSS_Item = New System.Windows.Forms.ToolStripSeparator()
        Me.NamesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PeopleToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EmployeesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CustomerToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.MNIT_Facility = New System.Windows.Forms.ToolStripMenuItem()
        Me.AddEditDepartmentToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DepartmentToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MNIT_SetLoc = New System.Windows.Forms.ToolStripMenuItem()
        Me.MNIT_Institutes = New System.Windows.Forms.ToolStripMenuItem()
        Me.MNIT_Suppliers = New System.Windows.Forms.ToolStripMenuItem()
        Me.ManufacturersToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator6 = New System.Windows.Forms.ToolStripSeparator()
        Me.TSM_ImportData = New System.Windows.Forms.ToolStripMenuItem()
        Me.TSM_ExportData = New System.Windows.Forms.ToolStripMenuItem()
        Me.MNIT_Transaction = New System.Windows.Forms.ToolStripMenuItem()
        Me.TSM_SupplyRequest = New System.Windows.Forms.ToolStripMenuItem()
        Me.AddNewToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EditExistingRequestToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TSM_SupplyReceive = New System.Windows.Forms.ToolStripMenuItem()
        Me.AddNewReceiveToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EditExistingReceiveToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TSS_FacilityReqInvoice1 = New System.Windows.Forms.ToolStripSeparator()
        Me.TSM_Requisition = New System.Windows.Forms.ToolStripMenuItem()
        Me.AddNewRequistionToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EditExistingRequisitionToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TSM_Issue = New System.Windows.Forms.ToolStripMenuItem()
        Me.AddNewIssueToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PreInvoiceEditToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EditExitionIssueiToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TSS_Adjustment = New System.Windows.Forms.ToolStripSeparator()
        Me.TSM_Adjustment = New System.Windows.Forms.ToolStripMenuItem()
        Me.IncreaseToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EditPlusToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.DecreaseToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EditExistingMinusToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.DiscardToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EditExistingDiscardToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.AddNewEchangeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AddExistingEchangeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TSS_OPDIPD = New System.Windows.Forms.ToolStripSeparator()
        Me.TSM_OPD = New System.Windows.Forms.ToolStripMenuItem()
        Me.AddNewOPDIssueToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EditExistingOPDIssueToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TSM_IPD = New System.Windows.Forms.ToolStripMenuItem()
        Me.AddNewIPDIssueToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EditExistingIPDIssueToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TSS_GRN = New System.Windows.Forms.ToolStripSeparator()
        Me.TSM_GRN = New System.Windows.Forms.ToolStripMenuItem()
        Me.AddNewGRNToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EditExistingGRNToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.TransfersToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AddNewTransfersToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EditNewTransfersToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ReportsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ItemsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TransactionToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.FinancialToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AnalysisToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.HistoryToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OthersToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AboutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.NewItemToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.ToolStripButton4 = New System.Windows.Forms.ToolStripButton()
        Me.TSS_SupplyReqReceive = New System.Windows.Forms.ToolStripSeparator()
        Me.TSB_SupplyRequest = New System.Windows.Forms.ToolStripButton()
        Me.TSB_SupplyReceive = New System.Windows.Forms.ToolStripButton()
        Me.TSB_GRV = New System.Windows.Forms.ToolStripButton()
        Me.TSS_FacilityReqinvoice2 = New System.Windows.Forms.ToolStripSeparator()
        Me.TSB_FacilityReq = New System.Windows.Forms.ToolStripButton()
        Me.TSB_FacilityPreinvoice = New System.Windows.Forms.ToolStripButton()
        Me.TSB_FacilityInvoice = New System.Windows.Forms.ToolStripButton()
        Me.TSB_OPD = New System.Windows.Forms.ToolStripButton()
        Me.ThisDepartment = New System.Windows.Forms.ToolStripLabel()
        Me.TSB_Satellite = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.TLSL_MainStatus = New System.Windows.Forms.ToolStripStatusLabel()
        Me.MNU_Main.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'MNU_Main
        '
        Me.MNU_Main.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.MNIT_MTN, Me.MNIT_Transaction, Me.ReportsToolStripMenuItem, Me.AboutToolStripMenuItem})
        Me.MNU_Main.Location = New System.Drawing.Point(0, 0)
        Me.MNU_Main.Name = "MNU_Main"
        Me.MNU_Main.Size = New System.Drawing.Size(920, 24)
        Me.MNU_Main.TabIndex = 0
        Me.MNU_Main.Text = "MenuStrip1"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ChangePasswordToolStripMenuItem, Me.LoginToolStripMenuItem, Me.ExitToolStripMenuItem})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(37, 20)
        Me.FileToolStripMenuItem.Text = "File"
        '
        'ChangePasswordToolStripMenuItem
        '
        Me.ChangePasswordToolStripMenuItem.Name = "ChangePasswordToolStripMenuItem"
        Me.ChangePasswordToolStripMenuItem.Size = New System.Drawing.Size(168, 22)
        Me.ChangePasswordToolStripMenuItem.Text = "Change Password"
        '
        'LoginToolStripMenuItem
        '
        Me.LoginToolStripMenuItem.Name = "LoginToolStripMenuItem"
        Me.LoginToolStripMenuItem.Size = New System.Drawing.Size(168, 22)
        Me.LoginToolStripMenuItem.Text = "Logoff"
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(168, 22)
        Me.ExitToolStripMenuItem.Text = "Exit"
        '
        'MNIT_MTN
        '
        Me.MNIT_MTN.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MNIT_Item, Me.MNIT_AdjType, Me.MNIT_StoreNLocs, Me.MNIT_RoomsNBeds, Me.TSS_Item, Me.NamesToolStripMenuItem, Me.PeopleToolStripMenuItem, Me.EmployeesToolStripMenuItem, Me.CustomerToolStripMenuItem, Me.ToolStripSeparator1, Me.MNIT_Facility, Me.MNIT_SetLoc, Me.MNIT_Institutes, Me.MNIT_Suppliers, Me.ManufacturersToolStripMenuItem, Me.ToolStripSeparator6, Me.TSM_ImportData, Me.TSM_ExportData})
        Me.MNIT_MTN.Name = "MNIT_MTN"
        Me.MNIT_MTN.Size = New System.Drawing.Size(88, 20)
        Me.MNIT_MTN.Text = "Maintenance"
        '
        'MNIT_Item
        '
        Me.MNIT_Item.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AddEditCatalogueToolStripMenuItem, Me.BatchesToolStripMenuItem, Me.CategoriesAndClassificationsToolStripMenuItem, Me.ClassificationsAndSubClassificationToolStripMenuItem, Me.RouteOfAdministrationToolStripMenuItem, Me.StorageRequirementTypesToolStripMenuItem, Me.TherapeuticClassToolStripMenuItem, Me.PrescriptionStatusToolStripMenuItem})
        Me.MNIT_Item.Name = "MNIT_Item"
        Me.MNIT_Item.Size = New System.Drawing.Size(178, 22)
        Me.MNIT_Item.Text = "Stock Item"
        '
        'AddEditCatalogueToolStripMenuItem
        '
        Me.AddEditCatalogueToolStripMenuItem.Name = "AddEditCatalogueToolStripMenuItem"
        Me.AddEditCatalogueToolStripMenuItem.Size = New System.Drawing.Size(265, 22)
        Me.AddEditCatalogueToolStripMenuItem.Text = "Add/Edit Catalogue"
        '
        'BatchesToolStripMenuItem
        '
        Me.BatchesToolStripMenuItem.Name = "BatchesToolStripMenuItem"
        Me.BatchesToolStripMenuItem.Size = New System.Drawing.Size(265, 22)
        Me.BatchesToolStripMenuItem.Text = "Batches"
        '
        'CategoriesAndClassificationsToolStripMenuItem
        '
        Me.CategoriesAndClassificationsToolStripMenuItem.Name = "CategoriesAndClassificationsToolStripMenuItem"
        Me.CategoriesAndClassificationsToolStripMenuItem.Size = New System.Drawing.Size(265, 22)
        Me.CategoriesAndClassificationsToolStripMenuItem.Text = "Categories and Classifications"
        '
        'ClassificationsAndSubClassificationToolStripMenuItem
        '
        Me.ClassificationsAndSubClassificationToolStripMenuItem.Name = "ClassificationsAndSubClassificationToolStripMenuItem"
        Me.ClassificationsAndSubClassificationToolStripMenuItem.Size = New System.Drawing.Size(265, 22)
        Me.ClassificationsAndSubClassificationToolStripMenuItem.Text = "Classifications and sub classification"
        '
        'RouteOfAdministrationToolStripMenuItem
        '
        Me.RouteOfAdministrationToolStripMenuItem.Name = "RouteOfAdministrationToolStripMenuItem"
        Me.RouteOfAdministrationToolStripMenuItem.Size = New System.Drawing.Size(265, 22)
        Me.RouteOfAdministrationToolStripMenuItem.Text = "Route of Administration"
        '
        'StorageRequirementTypesToolStripMenuItem
        '
        Me.StorageRequirementTypesToolStripMenuItem.Name = "StorageRequirementTypesToolStripMenuItem"
        Me.StorageRequirementTypesToolStripMenuItem.Size = New System.Drawing.Size(265, 22)
        Me.StorageRequirementTypesToolStripMenuItem.Text = "Storage Requirement Types"
        '
        'TherapeuticClassToolStripMenuItem
        '
        Me.TherapeuticClassToolStripMenuItem.Name = "TherapeuticClassToolStripMenuItem"
        Me.TherapeuticClassToolStripMenuItem.Size = New System.Drawing.Size(265, 22)
        Me.TherapeuticClassToolStripMenuItem.Text = "Therapeutic Class"
        '
        'PrescriptionStatusToolStripMenuItem
        '
        Me.PrescriptionStatusToolStripMenuItem.Name = "PrescriptionStatusToolStripMenuItem"
        Me.PrescriptionStatusToolStripMenuItem.Size = New System.Drawing.Size(265, 22)
        Me.PrescriptionStatusToolStripMenuItem.Text = "Prescription Status"
        '
        'MNIT_AdjType
        '
        Me.MNIT_AdjType.Name = "MNIT_AdjType"
        Me.MNIT_AdjType.Size = New System.Drawing.Size(178, 22)
        Me.MNIT_AdjType.Text = "Adjustment Type"
        '
        'MNIT_StoreNLocs
        '
        Me.MNIT_StoreNLocs.Name = "MNIT_StoreNLocs"
        Me.MNIT_StoreNLocs.Size = New System.Drawing.Size(178, 22)
        Me.MNIT_StoreNLocs.Text = "Store and Locations"
        '
        'MNIT_RoomsNBeds
        '
        Me.MNIT_RoomsNBeds.Name = "MNIT_RoomsNBeds"
        Me.MNIT_RoomsNBeds.Size = New System.Drawing.Size(178, 22)
        Me.MNIT_RoomsNBeds.Text = "Rooms and Beds"
        '
        'TSS_Item
        '
        Me.TSS_Item.Name = "TSS_Item"
        Me.TSS_Item.Size = New System.Drawing.Size(175, 6)
        '
        'NamesToolStripMenuItem
        '
        Me.NamesToolStripMenuItem.Name = "NamesToolStripMenuItem"
        Me.NamesToolStripMenuItem.Size = New System.Drawing.Size(178, 22)
        Me.NamesToolStripMenuItem.Text = "Names"
        '
        'PeopleToolStripMenuItem
        '
        Me.PeopleToolStripMenuItem.Name = "PeopleToolStripMenuItem"
        Me.PeopleToolStripMenuItem.Size = New System.Drawing.Size(178, 22)
        Me.PeopleToolStripMenuItem.Text = "Person"
        '
        'EmployeesToolStripMenuItem
        '
        Me.EmployeesToolStripMenuItem.Name = "EmployeesToolStripMenuItem"
        Me.EmployeesToolStripMenuItem.Size = New System.Drawing.Size(178, 22)
        Me.EmployeesToolStripMenuItem.Text = "Health worker"
        '
        'CustomerToolStripMenuItem
        '
        Me.CustomerToolStripMenuItem.Name = "CustomerToolStripMenuItem"
        Me.CustomerToolStripMenuItem.Size = New System.Drawing.Size(178, 22)
        Me.CustomerToolStripMenuItem.Text = "Customers"
        Me.CustomerToolStripMenuItem.Visible = False
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(175, 6)
        '
        'MNIT_Facility
        '
        Me.MNIT_Facility.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AddEditDepartmentToolStripMenuItem, Me.DepartmentToolStripMenuItem})
        Me.MNIT_Facility.Name = "MNIT_Facility"
        Me.MNIT_Facility.Size = New System.Drawing.Size(178, 22)
        Me.MNIT_Facility.Text = "Facility"
        '
        'AddEditDepartmentToolStripMenuItem
        '
        Me.AddEditDepartmentToolStripMenuItem.Name = "AddEditDepartmentToolStripMenuItem"
        Me.AddEditDepartmentToolStripMenuItem.Size = New System.Drawing.Size(196, 22)
        Me.AddEditDepartmentToolStripMenuItem.Text = "Add/Edit Medical Store"
        '
        'DepartmentToolStripMenuItem
        '
        Me.DepartmentToolStripMenuItem.Name = "DepartmentToolStripMenuItem"
        Me.DepartmentToolStripMenuItem.Size = New System.Drawing.Size(196, 22)
        Me.DepartmentToolStripMenuItem.Text = "Add/Edit Facility"
        '
        'MNIT_SetLoc
        '
        Me.MNIT_SetLoc.Name = "MNIT_SetLoc"
        Me.MNIT_SetLoc.Size = New System.Drawing.Size(178, 22)
        Me.MNIT_SetLoc.Text = "Set Location"
        '
        'MNIT_Institutes
        '
        Me.MNIT_Institutes.Name = "MNIT_Institutes"
        Me.MNIT_Institutes.Size = New System.Drawing.Size(178, 22)
        Me.MNIT_Institutes.Text = "Institutes"
        '
        'MNIT_Suppliers
        '
        Me.MNIT_Suppliers.Name = "MNIT_Suppliers"
        Me.MNIT_Suppliers.Size = New System.Drawing.Size(178, 22)
        Me.MNIT_Suppliers.Text = "Suppliers"
        '
        'ManufacturersToolStripMenuItem
        '
        Me.ManufacturersToolStripMenuItem.Name = "ManufacturersToolStripMenuItem"
        Me.ManufacturersToolStripMenuItem.Size = New System.Drawing.Size(178, 22)
        Me.ManufacturersToolStripMenuItem.Text = "Manufacturers"
        Me.ManufacturersToolStripMenuItem.Visible = False
        '
        'ToolStripSeparator6
        '
        Me.ToolStripSeparator6.Name = "ToolStripSeparator6"
        Me.ToolStripSeparator6.Size = New System.Drawing.Size(175, 6)
        '
        'TSM_ImportData
        '
        Me.TSM_ImportData.Name = "TSM_ImportData"
        Me.TSM_ImportData.Size = New System.Drawing.Size(178, 22)
        Me.TSM_ImportData.Text = "Import Data"
        Me.TSM_ImportData.Visible = False
        '
        'TSM_ExportData
        '
        Me.TSM_ExportData.Name = "TSM_ExportData"
        Me.TSM_ExportData.Size = New System.Drawing.Size(178, 22)
        Me.TSM_ExportData.Text = "Export Data"
        Me.TSM_ExportData.Visible = False
        '
        'MNIT_Transaction
        '
        Me.MNIT_Transaction.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TSM_SupplyRequest, Me.TSM_SupplyReceive, Me.TSS_FacilityReqInvoice1, Me.TSM_Requisition, Me.TSM_Issue, Me.TSS_Adjustment, Me.TSM_Adjustment, Me.TSS_OPDIPD, Me.TSM_OPD, Me.TSM_IPD, Me.TSS_GRN, Me.TSM_GRN, Me.ToolStripSeparator2, Me.TransfersToolStripMenuItem})
        Me.MNIT_Transaction.Name = "MNIT_Transaction"
        Me.MNIT_Transaction.Size = New System.Drawing.Size(85, 20)
        Me.MNIT_Transaction.Text = "Transactions"
        '
        'TSM_SupplyRequest
        '
        Me.TSM_SupplyRequest.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AddNewToolStripMenuItem, Me.EditExistingRequestToolStripMenuItem})
        Me.TSM_SupplyRequest.Name = "TSM_SupplyRequest"
        Me.TSM_SupplyRequest.Size = New System.Drawing.Size(156, 22)
        Me.TSM_SupplyRequest.Text = "Supply Request"
        '
        'AddNewToolStripMenuItem
        '
        Me.AddNewToolStripMenuItem.Name = "AddNewToolStripMenuItem"
        Me.AddNewToolStripMenuItem.Size = New System.Drawing.Size(182, 22)
        Me.AddNewToolStripMenuItem.Text = "Add New Request"
        '
        'EditExistingRequestToolStripMenuItem
        '
        Me.EditExistingRequestToolStripMenuItem.Name = "EditExistingRequestToolStripMenuItem"
        Me.EditExistingRequestToolStripMenuItem.Size = New System.Drawing.Size(182, 22)
        Me.EditExistingRequestToolStripMenuItem.Text = "Edit Existing Request"
        '
        'TSM_SupplyReceive
        '
        Me.TSM_SupplyReceive.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AddNewReceiveToolStripMenuItem, Me.EditExistingReceiveToolStripMenuItem})
        Me.TSM_SupplyReceive.Name = "TSM_SupplyReceive"
        Me.TSM_SupplyReceive.Size = New System.Drawing.Size(156, 22)
        Me.TSM_SupplyReceive.Text = "Supply Receive"
        '
        'AddNewReceiveToolStripMenuItem
        '
        Me.AddNewReceiveToolStripMenuItem.Name = "AddNewReceiveToolStripMenuItem"
        Me.AddNewReceiveToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.AddNewReceiveToolStripMenuItem.Text = "Add new Receive"
        '
        'EditExistingReceiveToolStripMenuItem
        '
        Me.EditExistingReceiveToolStripMenuItem.Name = "EditExistingReceiveToolStripMenuItem"
        Me.EditExistingReceiveToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.EditExistingReceiveToolStripMenuItem.Text = "Edit Existing Receive"
        '
        'TSS_FacilityReqInvoice1
        '
        Me.TSS_FacilityReqInvoice1.Name = "TSS_FacilityReqInvoice1"
        Me.TSS_FacilityReqInvoice1.Size = New System.Drawing.Size(153, 6)
        '
        'TSM_Requisition
        '
        Me.TSM_Requisition.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AddNewRequistionToolStripMenuItem, Me.EditExistingRequisitionToolStripMenuItem})
        Me.TSM_Requisition.Name = "TSM_Requisition"
        Me.TSM_Requisition.Size = New System.Drawing.Size(156, 22)
        Me.TSM_Requisition.Text = "Facility Request"
        '
        'AddNewRequistionToolStripMenuItem
        '
        Me.AddNewRequistionToolStripMenuItem.Name = "AddNewRequistionToolStripMenuItem"
        Me.AddNewRequistionToolStripMenuItem.Size = New System.Drawing.Size(199, 22)
        Me.AddNewRequistionToolStripMenuItem.Text = "Add new Requistion"
        '
        'EditExistingRequisitionToolStripMenuItem
        '
        Me.EditExistingRequisitionToolStripMenuItem.Name = "EditExistingRequisitionToolStripMenuItem"
        Me.EditExistingRequisitionToolStripMenuItem.Size = New System.Drawing.Size(199, 22)
        Me.EditExistingRequisitionToolStripMenuItem.Text = "Edit Existing Requisition"
        '
        'TSM_Issue
        '
        Me.TSM_Issue.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AddNewIssueToolStripMenuItem, Me.PreInvoiceEditToolStripMenuItem, Me.EditExitionIssueiToolStripMenuItem})
        Me.TSM_Issue.Name = "TSM_Issue"
        Me.TSM_Issue.Size = New System.Drawing.Size(156, 22)
        Me.TSM_Issue.Text = "Facility Invoice"
        '
        'AddNewIssueToolStripMenuItem
        '
        Me.AddNewIssueToolStripMenuItem.Name = "AddNewIssueToolStripMenuItem"
        Me.AddNewIssueToolStripMenuItem.Size = New System.Drawing.Size(200, 22)
        Me.AddNewIssueToolStripMenuItem.Text = "Add new Pre-Invoice"
        '
        'PreInvoiceEditToolStripMenuItem
        '
        Me.PreInvoiceEditToolStripMenuItem.Name = "PreInvoiceEditToolStripMenuItem"
        Me.PreInvoiceEditToolStripMenuItem.Size = New System.Drawing.Size(200, 22)
        Me.PreInvoiceEditToolStripMenuItem.Text = "Edit existing Pre-Invoice"
        '
        'EditExitionIssueiToolStripMenuItem
        '
        Me.EditExitionIssueiToolStripMenuItem.Name = "EditExitionIssueiToolStripMenuItem"
        Me.EditExitionIssueiToolStripMenuItem.Size = New System.Drawing.Size(200, 22)
        Me.EditExitionIssueiToolStripMenuItem.Text = "Invoice"
        '
        'TSS_Adjustment
        '
        Me.TSS_Adjustment.Name = "TSS_Adjustment"
        Me.TSS_Adjustment.Size = New System.Drawing.Size(153, 6)
        '
        'TSM_Adjustment
        '
        Me.TSM_Adjustment.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.IncreaseToolStripMenuItem, Me.EditPlusToolStripMenuItem, Me.ToolStripSeparator3, Me.DecreaseToolStripMenuItem, Me.EditExistingMinusToolStripMenuItem, Me.ToolStripSeparator4, Me.DiscardToolStripMenuItem, Me.EditExistingDiscardToolStripMenuItem, Me.ToolStripSeparator5, Me.AddNewEchangeToolStripMenuItem, Me.AddExistingEchangeToolStripMenuItem})
        Me.TSM_Adjustment.Name = "TSM_Adjustment"
        Me.TSM_Adjustment.Size = New System.Drawing.Size(156, 22)
        Me.TSM_Adjustment.Text = "Adjustment"
        '
        'IncreaseToolStripMenuItem
        '
        Me.IncreaseToolStripMenuItem.Name = "IncreaseToolStripMenuItem"
        Me.IncreaseToolStripMenuItem.Size = New System.Drawing.Size(190, 22)
        Me.IncreaseToolStripMenuItem.Text = "Add new Plus"
        '
        'EditPlusToolStripMenuItem
        '
        Me.EditPlusToolStripMenuItem.Name = "EditPlusToolStripMenuItem"
        Me.EditPlusToolStripMenuItem.Size = New System.Drawing.Size(190, 22)
        Me.EditPlusToolStripMenuItem.Text = "Edit Existing Plus"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(187, 6)
        '
        'DecreaseToolStripMenuItem
        '
        Me.DecreaseToolStripMenuItem.Name = "DecreaseToolStripMenuItem"
        Me.DecreaseToolStripMenuItem.Size = New System.Drawing.Size(190, 22)
        Me.DecreaseToolStripMenuItem.Text = "Add new Minus"
        '
        'EditExistingMinusToolStripMenuItem
        '
        Me.EditExistingMinusToolStripMenuItem.Name = "EditExistingMinusToolStripMenuItem"
        Me.EditExistingMinusToolStripMenuItem.Size = New System.Drawing.Size(190, 22)
        Me.EditExistingMinusToolStripMenuItem.Text = "Edit existing Minus"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(187, 6)
        '
        'DiscardToolStripMenuItem
        '
        Me.DiscardToolStripMenuItem.Name = "DiscardToolStripMenuItem"
        Me.DiscardToolStripMenuItem.Size = New System.Drawing.Size(190, 22)
        Me.DiscardToolStripMenuItem.Text = "Add new Discard"
        '
        'EditExistingDiscardToolStripMenuItem
        '
        Me.EditExistingDiscardToolStripMenuItem.Name = "EditExistingDiscardToolStripMenuItem"
        Me.EditExistingDiscardToolStripMenuItem.Size = New System.Drawing.Size(190, 22)
        Me.EditExistingDiscardToolStripMenuItem.Text = "Edit existing Discard"
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(187, 6)
        '
        'AddNewEchangeToolStripMenuItem
        '
        Me.AddNewEchangeToolStripMenuItem.Name = "AddNewEchangeToolStripMenuItem"
        Me.AddNewEchangeToolStripMenuItem.Size = New System.Drawing.Size(190, 22)
        Me.AddNewEchangeToolStripMenuItem.Text = "Add new Exchange"
        '
        'AddExistingEchangeToolStripMenuItem
        '
        Me.AddExistingEchangeToolStripMenuItem.Name = "AddExistingEchangeToolStripMenuItem"
        Me.AddExistingEchangeToolStripMenuItem.Size = New System.Drawing.Size(190, 22)
        Me.AddExistingEchangeToolStripMenuItem.Text = "Edit existing Exchange"
        '
        'TSS_OPDIPD
        '
        Me.TSS_OPDIPD.Name = "TSS_OPDIPD"
        Me.TSS_OPDIPD.Size = New System.Drawing.Size(153, 6)
        '
        'TSM_OPD
        '
        Me.TSM_OPD.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AddNewOPDIssueToolStripMenuItem, Me.EditExistingOPDIssueToolStripMenuItem})
        Me.TSM_OPD.Name = "TSM_OPD"
        Me.TSM_OPD.Size = New System.Drawing.Size(156, 22)
        Me.TSM_OPD.Text = "OPD"
        '
        'AddNewOPDIssueToolStripMenuItem
        '
        Me.AddNewOPDIssueToolStripMenuItem.Name = "AddNewOPDIssueToolStripMenuItem"
        Me.AddNewOPDIssueToolStripMenuItem.Size = New System.Drawing.Size(166, 22)
        Me.AddNewOPDIssueToolStripMenuItem.Text = "Add new Issue"
        '
        'EditExistingOPDIssueToolStripMenuItem
        '
        Me.EditExistingOPDIssueToolStripMenuItem.Name = "EditExistingOPDIssueToolStripMenuItem"
        Me.EditExistingOPDIssueToolStripMenuItem.Size = New System.Drawing.Size(166, 22)
        Me.EditExistingOPDIssueToolStripMenuItem.Text = "Edit existing Issue"
        '
        'TSM_IPD
        '
        Me.TSM_IPD.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AddNewIPDIssueToolStripMenuItem, Me.EditExistingIPDIssueToolStripMenuItem})
        Me.TSM_IPD.Name = "TSM_IPD"
        Me.TSM_IPD.Size = New System.Drawing.Size(156, 22)
        Me.TSM_IPD.Text = "Satellite"
        '
        'AddNewIPDIssueToolStripMenuItem
        '
        Me.AddNewIPDIssueToolStripMenuItem.Name = "AddNewIPDIssueToolStripMenuItem"
        Me.AddNewIPDIssueToolStripMenuItem.Size = New System.Drawing.Size(166, 22)
        Me.AddNewIPDIssueToolStripMenuItem.Text = "Add new Issue"
        '
        'EditExistingIPDIssueToolStripMenuItem
        '
        Me.EditExistingIPDIssueToolStripMenuItem.Name = "EditExistingIPDIssueToolStripMenuItem"
        Me.EditExistingIPDIssueToolStripMenuItem.Size = New System.Drawing.Size(166, 22)
        Me.EditExistingIPDIssueToolStripMenuItem.Text = "Edit existing Issue"
        '
        'TSS_GRN
        '
        Me.TSS_GRN.Name = "TSS_GRN"
        Me.TSS_GRN.Size = New System.Drawing.Size(153, 6)
        '
        'TSM_GRN
        '
        Me.TSM_GRN.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AddNewGRNToolStripMenuItem, Me.EditExistingGRNToolStripMenuItem})
        Me.TSM_GRN.Name = "TSM_GRN"
        Me.TSM_GRN.Size = New System.Drawing.Size(156, 22)
        Me.TSM_GRN.Text = "GRV"
        '
        'AddNewGRNToolStripMenuItem
        '
        Me.AddNewGRNToolStripMenuItem.Name = "AddNewGRNToolStripMenuItem"
        Me.AddNewGRNToolStripMenuItem.Size = New System.Drawing.Size(162, 22)
        Me.AddNewGRNToolStripMenuItem.Text = "Add new GRV"
        '
        'EditExistingGRNToolStripMenuItem
        '
        Me.EditExistingGRNToolStripMenuItem.Name = "EditExistingGRNToolStripMenuItem"
        Me.EditExistingGRNToolStripMenuItem.Size = New System.Drawing.Size(162, 22)
        Me.EditExistingGRNToolStripMenuItem.Text = "Edit existing GRV"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(153, 6)
        '
        'TransfersToolStripMenuItem
        '
        Me.TransfersToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AddNewTransfersToolStripMenuItem, Me.EditNewTransfersToolStripMenuItem})
        Me.TransfersToolStripMenuItem.Name = "TransfersToolStripMenuItem"
        Me.TransfersToolStripMenuItem.Size = New System.Drawing.Size(156, 22)
        Me.TransfersToolStripMenuItem.Text = "STV"
        '
        'AddNewTransfersToolStripMenuItem
        '
        Me.AddNewTransfersToolStripMenuItem.Name = "AddNewTransfersToolStripMenuItem"
        Me.AddNewTransfersToolStripMenuItem.Size = New System.Drawing.Size(160, 22)
        Me.AddNewTransfersToolStripMenuItem.Text = "Add New STV"
        '
        'EditNewTransfersToolStripMenuItem
        '
        Me.EditNewTransfersToolStripMenuItem.Name = "EditNewTransfersToolStripMenuItem"
        Me.EditNewTransfersToolStripMenuItem.Size = New System.Drawing.Size(160, 22)
        Me.EditNewTransfersToolStripMenuItem.Text = "Edit existing STV"
        '
        'ReportsToolStripMenuItem
        '
        Me.ReportsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ItemsToolStripMenuItem, Me.TransactionToolStripMenuItem, Me.FinancialToolStripMenuItem, Me.AnalysisToolStripMenuItem, Me.HistoryToolStripMenuItem, Me.OthersToolStripMenuItem})
        Me.ReportsToolStripMenuItem.Name = "ReportsToolStripMenuItem"
        Me.ReportsToolStripMenuItem.Size = New System.Drawing.Size(59, 20)
        Me.ReportsToolStripMenuItem.Text = "Reports"
        '
        'ItemsToolStripMenuItem
        '
        Me.ItemsToolStripMenuItem.Name = "ItemsToolStripMenuItem"
        Me.ItemsToolStripMenuItem.Size = New System.Drawing.Size(135, 22)
        Me.ItemsToolStripMenuItem.Text = "Items"
        '
        'TransactionToolStripMenuItem
        '
        Me.TransactionToolStripMenuItem.Name = "TransactionToolStripMenuItem"
        Me.TransactionToolStripMenuItem.Size = New System.Drawing.Size(135, 22)
        Me.TransactionToolStripMenuItem.Text = "Transaction"
        '
        'FinancialToolStripMenuItem
        '
        Me.FinancialToolStripMenuItem.Name = "FinancialToolStripMenuItem"
        Me.FinancialToolStripMenuItem.Size = New System.Drawing.Size(135, 22)
        Me.FinancialToolStripMenuItem.Text = "Financial"
        '
        'AnalysisToolStripMenuItem
        '
        Me.AnalysisToolStripMenuItem.Name = "AnalysisToolStripMenuItem"
        Me.AnalysisToolStripMenuItem.Size = New System.Drawing.Size(135, 22)
        Me.AnalysisToolStripMenuItem.Text = "Analysis"
        '
        'HistoryToolStripMenuItem
        '
        Me.HistoryToolStripMenuItem.Name = "HistoryToolStripMenuItem"
        Me.HistoryToolStripMenuItem.Size = New System.Drawing.Size(135, 22)
        Me.HistoryToolStripMenuItem.Text = "History"
        '
        'OthersToolStripMenuItem
        '
        Me.OthersToolStripMenuItem.Name = "OthersToolStripMenuItem"
        Me.OthersToolStripMenuItem.Size = New System.Drawing.Size(135, 22)
        Me.OthersToolStripMenuItem.Text = "Others"
        '
        'AboutToolStripMenuItem
        '
        Me.AboutToolStripMenuItem.Name = "AboutToolStripMenuItem"
        Me.AboutToolStripMenuItem.Size = New System.Drawing.Size(52, 20)
        Me.AboutToolStripMenuItem.Text = "About"
        '
        'NewItemToolStripMenuItem
        '
        Me.NewItemToolStripMenuItem.Enabled = False
        Me.NewItemToolStripMenuItem.Name = "NewItemToolStripMenuItem"
        Me.NewItemToolStripMenuItem.Size = New System.Drawing.Size(165, 22)
        Me.NewItemToolStripMenuItem.Text = "New Item"
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton4, Me.TSS_SupplyReqReceive, Me.TSB_SupplyRequest, Me.TSB_SupplyReceive, Me.TSB_GRV, Me.TSS_FacilityReqinvoice2, Me.TSB_FacilityReq, Me.TSB_FacilityPreinvoice, Me.TSB_FacilityInvoice, Me.TSB_OPD, Me.ThisDepartment, Me.TSB_Satellite, Me.ToolStripButton1})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 24)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(920, 25)
        Me.ToolStrip1.TabIndex = 3
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'ToolStripButton4
        '
        Me.ToolStripButton4.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.ToolStripButton4.Image = CType(resources.GetObject("ToolStripButton4.Image"), System.Drawing.Image)
        Me.ToolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton4.Name = "ToolStripButton4"
        Me.ToolStripButton4.Size = New System.Drawing.Size(74, 22)
        Me.ToolStripButton4.Text = "Notification"
        '
        'TSS_SupplyReqReceive
        '
        Me.TSS_SupplyReqReceive.Name = "TSS_SupplyReqReceive"
        Me.TSS_SupplyReqReceive.Size = New System.Drawing.Size(6, 25)
        '
        'TSB_SupplyRequest
        '
        Me.TSB_SupplyRequest.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.TSB_SupplyRequest.Image = CType(resources.GetObject("TSB_SupplyRequest.Image"), System.Drawing.Image)
        Me.TSB_SupplyRequest.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TSB_SupplyRequest.Name = "TSB_SupplyRequest"
        Me.TSB_SupplyRequest.Size = New System.Drawing.Size(92, 22)
        Me.TSB_SupplyRequest.Text = "Supply Request"
        '
        'TSB_SupplyReceive
        '
        Me.TSB_SupplyReceive.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.TSB_SupplyReceive.Image = CType(resources.GetObject("TSB_SupplyReceive.Image"), System.Drawing.Image)
        Me.TSB_SupplyReceive.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TSB_SupplyReceive.Name = "TSB_SupplyReceive"
        Me.TSB_SupplyReceive.Size = New System.Drawing.Size(90, 22)
        Me.TSB_SupplyReceive.Text = "Supply Receive"
        '
        'TSB_GRV
        '
        Me.TSB_GRV.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.TSB_GRV.Image = CType(resources.GetObject("TSB_GRV.Image"), System.Drawing.Image)
        Me.TSB_GRV.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TSB_GRV.Name = "TSB_GRV"
        Me.TSB_GRV.Size = New System.Drawing.Size(33, 22)
        Me.TSB_GRV.Text = "GRV"
        '
        'TSS_FacilityReqinvoice2
        '
        Me.TSS_FacilityReqinvoice2.Name = "TSS_FacilityReqinvoice2"
        Me.TSS_FacilityReqinvoice2.Size = New System.Drawing.Size(6, 25)
        '
        'TSB_FacilityReq
        '
        Me.TSB_FacilityReq.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.TSB_FacilityReq.Image = CType(resources.GetObject("TSB_FacilityReq.Image"), System.Drawing.Image)
        Me.TSB_FacilityReq.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TSB_FacilityReq.Name = "TSB_FacilityReq"
        Me.TSB_FacilityReq.Size = New System.Drawing.Size(93, 22)
        Me.TSB_FacilityReq.Text = "Facility Request"
        '
        'TSB_FacilityPreinvoice
        '
        Me.TSB_FacilityPreinvoice.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.TSB_FacilityPreinvoice.Image = CType(resources.GetObject("TSB_FacilityPreinvoice.Image"), System.Drawing.Image)
        Me.TSB_FacilityPreinvoice.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TSB_FacilityPreinvoice.Name = "TSB_FacilityPreinvoice"
        Me.TSB_FacilityPreinvoice.Size = New System.Drawing.Size(66, 22)
        Me.TSB_FacilityPreinvoice.Text = "Preinvoice"
        '
        'TSB_FacilityInvoice
        '
        Me.TSB_FacilityInvoice.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.TSB_FacilityInvoice.Image = CType(resources.GetObject("TSB_FacilityInvoice.Image"), System.Drawing.Image)
        Me.TSB_FacilityInvoice.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TSB_FacilityInvoice.Name = "TSB_FacilityInvoice"
        Me.TSB_FacilityInvoice.Size = New System.Drawing.Size(49, 22)
        Me.TSB_FacilityInvoice.Text = "Invoice"
        '
        'TSB_OPD
        '
        Me.TSB_OPD.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.TSB_OPD.Image = CType(resources.GetObject("TSB_OPD.Image"), System.Drawing.Image)
        Me.TSB_OPD.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TSB_OPD.Name = "TSB_OPD"
        Me.TSB_OPD.Size = New System.Drawing.Size(35, 22)
        Me.TSB_OPD.Text = "OPD"
        '
        'ThisDepartment
        '
        Me.ThisDepartment.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ThisDepartment.ForeColor = System.Drawing.Color.SteelBlue
        Me.ThisDepartment.Name = "ThisDepartment"
        Me.ThisDepartment.Size = New System.Drawing.Size(70, 22)
        Me.ThisDepartment.Text = "Department"
        '
        'TSB_Satellite
        '
        Me.TSB_Satellite.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.TSB_Satellite.Image = CType(resources.GetObject("TSB_Satellite.Image"), System.Drawing.Image)
        Me.TSB_Satellite.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TSB_Satellite.Name = "TSB_Satellite"
        Me.TSB_Satellite.Size = New System.Drawing.Size(52, 22)
        Me.TSB_Satellite.Text = "Satellite"
        '
        'ToolStripButton1
        '
        Me.ToolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.ToolStripButton1.Image = CType(resources.GetObject("ToolStripButton1.Image"), System.Drawing.Image)
        Me.ToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton1.Name = "ToolStripButton1"
        Me.ToolStripButton1.Size = New System.Drawing.Size(46, 22)
        Me.ToolStripButton1.Text = "Search"
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TLSL_MainStatus})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 449)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(920, 22)
        Me.StatusStrip1.TabIndex = 5
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'TLSL_MainStatus
        '
        Me.TLSL_MainStatus.Name = "TLSL_MainStatus"
        Me.TLSL_MainStatus.Size = New System.Drawing.Size(39, 17)
        Me.TLSL_MainStatus.Text = "Ready"
        '
        'FRM_GLBMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(920, 471)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.MNU_Main)
        Me.IsMdiContainer = True
        Me.MainMenuStrip = Me.MNU_Main
        Me.Name = "FRM_GLBMain"
        Me.Text = "Main Form"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.MNU_Main.ResumeLayout(False)
        Me.MNU_Main.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MNU_Main As System.Windows.Forms.MenuStrip
    Friend WithEvents InventoryJournalToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MNIT_Transaction As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TSM_SupplyRequest As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TSM_SupplyReceive As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TSS_FacilityReqInvoice1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents TSS_Adjustment As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents TSM_Requisition As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TSM_Issue As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AddNewToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditExistingRequestToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AddNewReceiveToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditExistingReceiveToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AddNewRequistionToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditExistingRequisitionToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AddNewIssueToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditExitionIssueiToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TSM_Adjustment As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents NewItemToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents IncreaseToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DecreaseToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MNIT_MTN As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ReportsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AboutToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents TSB_SupplyRequest As System.Windows.Forms.ToolStripButton
    Friend WithEvents TSB_SupplyReceive As System.Windows.Forms.ToolStripButton
    Friend WithEvents MNIT_Item As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TSS_FacilityReqinvoice2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents TSB_FacilityReq As System.Windows.Forms.ToolStripButton
    Friend WithEvents TSB_FacilityPreinvoice As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton4 As System.Windows.Forms.ToolStripButton
    Friend WithEvents TSS_SupplyReqReceive As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents TSB_FacilityInvoice As System.Windows.Forms.ToolStripButton
    Friend WithEvents MNIT_AdjType As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MNIT_StoreNLocs As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AddEditCatalogueToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CategoriesAndClassificationsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents TLSL_MainStatus As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents PeopleToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EmployeesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MNIT_Institutes As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CustomerToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RouteOfAdministrationToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents StorageRequirementTypesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TherapeuticClassToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PrescriptionStatusToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TSS_Item As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ManufacturersToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator6 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents TSM_ImportData As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TSM_ExportData As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TSS_OPDIPD As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents TSM_OPD As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AddNewOPDIssueToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditExistingOPDIssueToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TSM_IPD As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AddNewIPDIssueToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditExistingIPDIssueToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MNIT_SetLoc As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DepartmentToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ItemsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TransactionToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents FinancialToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AnalysisToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ThisDepartment As System.Windows.Forms.ToolStripLabel
    Friend WithEvents AddEditDepartmentToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TSS_GRN As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents TSM_GRN As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AddNewGRNToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditExistingGRNToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MNIT_Suppliers As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents NamesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MNIT_RoomsNBeds As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents TransfersToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AddNewTransfersToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditNewTransfersToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DiscardToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PreInvoiceEditToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditPlusToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditExistingMinusToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditExistingDiscardToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents HistoryToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MNIT_Facility As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ClassificationsAndSubClassificationToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ChangePasswordToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents LoginToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents AddNewEchangeToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AddExistingEchangeToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BatchesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TSB_OPD As System.Windows.Forms.ToolStripButton
    Friend WithEvents TSB_Satellite As System.Windows.Forms.ToolStripButton
    Friend WithEvents OthersToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TSB_GRV As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton1 As System.Windows.Forms.ToolStripButton

End Class
