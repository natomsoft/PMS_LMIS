Imports System.Data.Objects
Imports System.Data.SqlClient
Imports Microsoft.Reporting.WinForms

Public Class FRM_GLBMain
    Public ApplicationConfig As ApplicationConfigs
    Private LevelProfilesExclude As Dictionary(Of String, Object())
    Private PrivilegeExclude As Dictionary(Of String, Object())
    Private PrivilegeInvisible As Dictionary(Of String, String())
    Public RequestSave As String
    Public Sub New()
        InitializeComponent()
        ApplicationConfig = New ApplicationConfigs
        LevelProfilesExclude = New Dictionary(Of String, Object())
        PrivilegeExclude = New Dictionary(Of String, Object())
        PrivilegeInvisible = New Dictionary(Of String, String())
    End Sub

    Public Overloads Sub show(ByVal Employee As Employee)
        ApplicationConfig.Employee = Employee
        Me.Show()
    End Sub

    Private Sub SetVisible(ByVal Items As Object(), ByVal Toggle As Boolean)
        For Each Item In Items
            If Item.GetType() = GetType(ToolStripMenuItem) Then
                CType(Item, ToolStripMenuItem).Visible = Toggle
            ElseIf Item.GetType() = GetType(ToolStripSeparator) Then
                CType(Item, ToolStripSeparator).Visible = Toggle
            ElseIf Item.GetType() = GetType(ToolStripButton) Then
                CType(Item, ToolStripButton).Visible = Toggle
            End If
        Next
    End Sub

    Public Sub LoadUserProfile(ByVal Privilege As String)
        If PrivilegeExclude.ContainsKey(Privilege) Then
            SetVisible(PrivilegeExclude(Privilege), False)
        Else
            Throw New Exception("LMIS cannot find the specified user Profile, '" & Privilege & "'")
        End If
    End Sub

    Public Function CheckVisible(ByVal ControlName As String) As Boolean
        If PrivilegeInvisible(Me.ApplicationConfig.Employee.EmployeeType.Name).Contains(ControlName) Then
            Return False
        Else
            Return True
        End If
    End Function

    Public Sub LoadLevelProfile(ByVal Level As String)
        If LevelProfilesExclude.ContainsKey(Level) Then
            SetVisible({TSM_SupplyRequest, TSM_SupplyReceive, TSB_SupplyRequest, TSB_SupplyReceive, TSS_SupplyReqReceive, TSM_OPD, TSM_IPD, TSS_OPDIPD, TSM_GRN, TSS_GRN, TSM_Requisition, TSM_Issue, TSS_FacilityReqInvoice1, TSB_FacilityReq, TSB_FacilityInvoice, TSB_FacilityPreinvoice, TSB_OPD, TSB_Satellite}, True)
            SetVisible(LevelProfilesExclude(Level), False)
        Else
            SetVisible({TSM_SupplyRequest, TSM_SupplyReceive, TSB_SupplyRequest, TSB_SupplyReceive, TSS_SupplyReqReceive, TSM_OPD, TSM_IPD, TSS_OPDIPD, TSM_GRN, TSS_GRN, TSM_Requisition, TSM_Issue, TSS_FacilityReqInvoice1, TSB_FacilityReq, TSB_FacilityInvoice, TSB_FacilityPreinvoice, TSB_OPD, TSB_Satellite}, False)
            Throw New Exception("LMIS cannot find the specified Level Profile, '" & Level & "'")
        End If
    End Sub

#Region "Events"

    Private Sub FRM_GLBMain_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        'e.Cancel = False
    End Sub

    Private Sub FRM_GLBMain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        LevelProfilesExclude.Add("Level 1", {TSM_SupplyRequest, TSM_SupplyReceive, TSB_SupplyRequest, TSB_SupplyReceive, TSS_SupplyReqReceive, TSM_OPD, TSM_IPD, TSS_OPDIPD, TSB_OPD, TSB_Satellite})
        LevelProfilesExclude.Add("Level 2", {TSM_GRN, TSS_GRN, TSM_OPD, TSM_IPD, TSS_OPDIPD, TSB_OPD, TSB_Satellite, TSB_GRV})
        LevelProfilesExclude.Add("Level 3", {TSM_GRN, TSS_GRN, TSM_OPD, TSM_IPD, TSS_OPDIPD, TSB_OPD, TSB_Satellite, TSB_GRV})
        LevelProfilesExclude.Add("Level 4", {TSM_GRN, TSS_GRN, TSB_GRV})
        LevelProfilesExclude.Add("Level 4I", {TSM_GRN, TSS_GRN, TSM_OPD, TSB_OPD, TSS_FacilityReqInvoice1, TSM_Requisition, TSM_Issue, TSB_FacilityReq, TSB_FacilityPreinvoice, TSB_FacilityInvoice, TSB_GRV})
        LevelProfilesExclude.Add("Level 4O", {TSM_GRN, TSS_GRN, TSM_IPD, TSB_Satellite, TSS_FacilityReqInvoice1, TSM_Requisition, TSM_Issue, TSB_FacilityReq, TSB_FacilityPreinvoice, TSB_FacilityInvoice, TSB_GRV})

        PrivilegeExclude.Add("Administrator", {MNIT_Transaction, TSM_SupplyRequest, TSM_SupplyReceive, TSB_SupplyRequest, TSB_SupplyReceive, TSB_FacilityReq, TSB_FacilityPreinvoice, TSB_FacilityInvoice, TSS_SupplyReqReceive, TSM_OPD, TSM_IPD, TSS_OPDIPD, TSB_OPD, TSB_Satellite, TSB_GRV})
        PrivilegeExclude.Add("Super Users", {MNIT_Item, MNIT_AdjType, MNIT_Facility, MNIT_SetLoc, MNIT_Institutes})
        PrivilegeExclude.Add("Data Entry", {MNIT_MTN})
        PrivilegeExclude.Add("Report", {MNIT_MTN, MNIT_Transaction, TSM_SupplyRequest, TSM_SupplyReceive, TSB_SupplyRequest, TSB_SupplyReceive, TSS_SupplyReqReceive, TSB_FacilityReq, TSB_FacilityPreinvoice, TSB_FacilityInvoice})

        PrivilegeInvisible.Add("Administrator", {})
        PrivilegeInvisible.Add("Super Users", {})
        PrivilegeInvisible.Add("Data Entry", {"TB_Analysis", "TB_Financial", "TB_History"})
        PrivilegeInvisible.Add("Report", {})

        ApplicationConfig.ThisDepartment = Utility.GetMyDepartment()

        If ThisDepartment.Text <> "PHARMECOR" Then
            MNIT_Suppliers.Visible = False
        End If

        Me.LoadUserProfile(ApplicationConfig.Employee.EmployeeType.Name)

        If ApplicationConfig.ThisDepartment Is Nothing Then
            FRM_MTNSetLocation.ShowDialog()
            ApplicationConfig.ThisDepartment = Utility.GetMyDepartment()
            If ApplicationConfig.ThisDepartment Is Nothing Then
                MessageBox.Show("LMIS cannot start without selecting a Department", "LMIS", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
        End If
        If FRM_Notification.ShowNotification() Then
            FRM_Notification.BringToFront()
        Else
            FRM_Notification.Close()
        End If
    End Sub

    Private Sub ExitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub AddNewToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddNewToolStripMenuItem.Click
        FRM_IJSupplyRequestEdit.Close()
        FRM_IJSupplyRequestEdit.Show(FRMModes.AddNew)
        FRM_IJSupplyRequestEdit.BringToFront()
    End Sub

    Private Sub EditExistingRequestToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EditExistingRequestToolStripMenuItem.Click
        FRM_IJSupplyRequestEdit.Close()
        FRM_IJSupplyRequestEdit.Show(FRMModes.EditExisting)
        FRM_IJSupplyRequestEdit.BringToFront()
    End Sub

    Private Sub AddNewReceiveToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddNewReceiveToolStripMenuItem.Click
        FRM_IJSupplyReceive.Show()
    End Sub

    Private Sub EditExistingReceiveToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EditExistingReceiveToolStripMenuItem.Click
        FRM_IJSupplyReceiveEdit.Show()
        FRM_IJSupplyReceiveEdit.BringToFront()
    End Sub

    Private Sub AddNewRequistionToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddNewRequistionToolStripMenuItem.Click
        FRM_IJFacilityRequestEdit.Close()
        FRM_IJFacilityRequestEdit.Show(FRMModes.AddNew)
        FRM_IJFacilityRequestEdit.BringToFront()
    End Sub

    Private Sub EditExistingRequisitionToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EditExistingRequisitionToolStripMenuItem.Click
        FRM_IJFacilityRequestEdit.Close()
        FRM_IJFacilityRequestEdit.Show(FRMModes.EditExisting)
        FRM_IJFacilityRequestEdit.BringToFront()
    End Sub

    Private Sub AddNewIssueToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddNewIssueToolStripMenuItem.Click
        FRM_IJPreinvoice.Show()
        FRM_IJPreinvoice.BringToFront()
    End Sub

    Private Sub PreInvoiceEditToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PreInvoiceEditToolStripMenuItem.Click
        FRM_IJPreInvoiceEdit.Show()
        FRM_IJPreInvoiceEdit.BringToFront()
    End Sub

    Private Sub ToolStripButton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSB_FacilityPreinvoice.Click
        FRM_IJPreinvoice.Show()
        FRM_IJPreinvoice.BringToFront()
    End Sub

    Private Sub EditExitionIssueiToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EditExitionIssueiToolStripMenuItem.Click
        FRM_IJInvoice.Show()
        FRM_IJInvoice.BringToFront()
    End Sub

    Private Sub IncreaseToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles IncreaseToolStripMenuItem.Click
        FRM_IJAdjustment.Close()
        FRM_IJAdjustment.Show(FRMModes.AddNew, FRMAdjModes.Increase)
        FRM_IJAdjustment.BringToFront()
    End Sub

    Private Sub EditIncreaseToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EditPlusToolStripMenuItem.Click
        FRM_IJAdjustment.Close()
        FRM_IJAdjustment.Show(FRMModes.EditExisting, FRMAdjModes.Increase)
        FRM_IJAdjustment.BringToFront()
    End Sub

    Private Sub DiscardToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DiscardToolStripMenuItem.Click
        FRM_IJAdjustment.Close()
        FRM_IJAdjustment.Show(FRMModes.AddNew, FRMAdjModes.Discard)
        FRM_IJAdjustment.BringToFront()
    End Sub

    Private Sub EditDiscardToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EditExistingDiscardToolStripMenuItem.Click
        FRM_IJAdjustment.Close()
        FRM_IJAdjustment.Show(FRMModes.EditExisting, FRMAdjModes.Discard)
        FRM_IJAdjustment.BringToFront()
    End Sub

    Private Sub DecreaseToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DecreaseToolStripMenuItem.Click
        FRM_IJAdjustment.Close()
        FRM_IJAdjustment.Show(FRMModes.AddNew, FRMAdjModes.Decrease)
        FRM_IJAdjustment.BringToFront()
    End Sub

    Private Sub EditDecreaseToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EditExistingMinusToolStripMenuItem.Click
        FRM_IJAdjustment.Close()
        FRM_IJAdjustment.Show(FRMModes.EditExisting, FRMAdjModes.Decrease)
        FRM_IJAdjustment.BringToFront()
    End Sub

    Private Sub AddNewEchangeToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddNewEchangeToolStripMenuItem.Click
        FRM_IJExchange.Close()
        FRM_IJExchange.Show(FRMModes.AddNew)
        FRM_IJExchange.BringToFront()
    End Sub

    Private Sub AddExistingEchangeToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddExistingEchangeToolStripMenuItem.Click
        FRM_IJExchange.Close()
        FRM_IJExchange.Show(FRMModes.EditExisting)
        FRM_IJExchange.BringToFront()
    End Sub

    Private Sub ToolStripLabel1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSB_SupplyRequest.Click
        FRM_IJSupplyRequestEdit.Close()
        FRM_IJSupplyRequestEdit.Show(FRMModes.AddNew)
        FRM_IJSupplyRequestEdit.BringToFront()
    End Sub

    Private Sub ToolStripLabel2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSB_SupplyReceive.Click
        FRM_IJSupplyReceive.Show()
        FRM_IJSupplyReceive.BringToFront()
    End Sub

    Private Sub ToolStripLabel6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSB_FacilityInvoice.Click
        FRM_IJInvoice.Show()
        FRM_IJInvoice.BringToFront()
    End Sub

    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSB_FacilityReq.Click
        FRM_IJFacilityRequestEdit.Close()
        FRM_IJFacilityRequestEdit.Show(FRMModes.AddNew)
        FRM_IJFacilityRequestEdit.BringToFront()
    End Sub

    Private Sub ToolStripButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        FRM_IJPreinvoice.Show()
        FRM_IJPreinvoice.BringToFront()
    End Sub

    Private Sub AddNewTransfersToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddNewTransfersToolStripMenuItem.Click
        StoreTransferVoucher.Close()
        StoreTransferVoucher.Show(FRMModes.AddNew)
        StoreTransferVoucher.BringToFront()
    End Sub

    Private Sub EditNewTransfersToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EditNewTransfersToolStripMenuItem.Click
        StoreTransferVoucher.Close()
        StoreTransferVoucher.Show(FRMModes.EditExisting)
        StoreTransferVoucher.BringToFront()
    End Sub

    Private Sub ToolStripButton4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton4.Click
        FRM_Notification.ShowNotification()
        FRM_Notification.BringToFront()
    End Sub

    Private Sub AddEditCatalogueToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddEditCatalogueToolStripMenuItem.Click
        FRM_MTNCatalogue.Show()
        FRM_MTNCatalogue.BringToFront()
    End Sub

    Private Sub BatchesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BatchesToolStripMenuItem.Click
        FRM_MTNItemBatches.Show()
        FRM_MTNItemBatches.BringToFront()
    End Sub

    Private Sub CategoriesAndClassificationsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CategoriesAndClassificationsToolStripMenuItem.Click
        FRM_MTNCategory.Show()
        FRM_MTNCategory.BringToFront()
    End Sub


    Private Sub ClassificationsAndSubClassificationToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ClassificationsAndSubClassificationToolStripMenuItem.Click
        FRM_MTNSubClass.Show()
        FRM_MTNSubClass.BringToFront()
    End Sub

    Private Sub LocationsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MNIT_StoreNLocs.Click
        FRM_MTNStore.Show()
        FRM_MTNStore.BringToFront()
    End Sub

    Private Sub UOMToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MNIT_AdjType.Click
        FRM_MTNAdjustment.Show()
        FRM_MTNAdjustment.BringToFront()
    End Sub

    Private Sub PeopleToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PeopleToolStripMenuItem.Click
        FRM_MTNPeople.Show()
        FRM_MTNPeople.BringToFront()
    End Sub

    Private Sub EmployeesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EmployeesToolStripMenuItem.Click
        FRM_MTNEmployees.Show()
        FRM_MTNEmployees.BringToFront()
    End Sub

    Private Sub CompaniesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MNIT_Institutes.Click
        FRM_MTNCompanies.Show()
        FRM_MTNCompanies.BringToFront()
    End Sub

    Private Sub CustomerToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CustomerToolStripMenuItem.Click
        FRM_IJExchange.Show()
        FRM_IJExchange.BringToFront()
    End Sub

    Private Sub RouteOfAdministrationToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RouteOfAdministrationToolStripMenuItem.Click
        FRM_MTNRouteofAdministration.Show()
        FRM_MTNRouteofAdministration.BringToFront()
    End Sub

    Private Sub StorageRequirementTypesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles StorageRequirementTypesToolStripMenuItem.Click
        FRM_MTNStorageReqType.Show()
        FRM_MTNStorageReqType.BringToFront()
    End Sub

    Private Sub TherapeuticClassToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TherapeuticClassToolStripMenuItem.Click
        FRM_MTNTherapeuticClass.Show()
        FRM_MTNTherapeuticClass.BringToFront()
    End Sub

    Private Sub PrescriptionStatusToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PrescriptionStatusToolStripMenuItem.Click
        FRM_MTNPrescriptionStatus.Show()
        FRM_MTNPrescriptionStatus.BringToFront()
    End Sub

    Private Sub ManufacturersToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ManufacturersToolStripMenuItem.Click
        FRM_MTNManufacturer.Show()
        FRM_MTNManufacturer.BringToFront()
    End Sub

    Private Sub ImportExportDataToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSM_ImportData.Click
        FRM_MTNImport.Show()
        FRM_MTNImport.BringToFront()
    End Sub

    Private Sub ImportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSM_ExportData.Click
        FRM_MTNExport.Show()
        FRM_MTNExport.BringToFront()
    End Sub

    Private Sub AddNewOPDIssueToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddNewOPDIssueToolStripMenuItem.Click
        FRM_IJOPD.Show(FRMModes.AddNew)
        FRM_IJOPD.BringToFront()
    End Sub

    Private Sub TSB_OPD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSB_OPD.Click
        FRM_IJOPD.Show(FRMModes.AddNew)
        FRM_IJOPD.BringToFront()
    End Sub

    Private Sub EditExistingOPDIssueToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EditExistingOPDIssueToolStripMenuItem.Click
        FRM_IJOPD.Show(FRMModes.EditExisting)
        FRM_IJOPD.BringToFront()
    End Sub

    Private Sub AddNewIPDIssueToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddNewIPDIssueToolStripMenuItem.Click
        FRM_IJSatellite.Show(FRMModes.AddNew)
        FRM_IJSatellite.BringToFront()
    End Sub

    Private Sub TSB_Satellite_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSB_Satellite.Click
        FRM_IJSatellite.Show(FRMModes.AddNew)
        FRM_IJSatellite.BringToFront()
    End Sub


    Private Sub TSB_GRV_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSB_GRV.Click
        FRM_IJGRV.Show(FRMModes.AddNew)
        FRM_IJGRV.BringToFront()
    End Sub

    Private Sub EditExistingIPDIssueToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EditExistingIPDIssueToolStripMenuItem.Click
        FRM_IJSatellite.Show(FRMModes.EditExisting)
        FRM_IJSatellite.BringToFront()
    End Sub

    Private Sub ChangeMyDepartmentToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MNIT_SetLoc.Click
        FRM_MTNSetLocation.Show()
        FRM_MTNSetLocation.BringToFront()
    End Sub

    Private Sub DepartmentToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DepartmentToolStripMenuItem.Click
        FRM_MTNDepartment.Show()
        FRM_MTNDepartment.BringToFront()
    End Sub

    Private Sub ItemsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ItemsToolStripMenuItem.Click
        Dim FRM_R As New FRM_Reporter
        FRM_R.Show()
        FRM_R.TBC_Report.SelectedTab = FRM_R.TB_Items
    End Sub

    Private Sub TransactionToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TransactionToolStripMenuItem.Click
        Dim FRM_R As New FRM_Reporter
        FRM_R.Show()
        FRM_R.TBC_Report.SelectedTab = FRM_R.TB_Transaction
    End Sub

    Private Sub FinancialToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FinancialToolStripMenuItem.Click
        Dim FRM_R As New FRM_Reporter
        FRM_R.Show()
        FRM_R.TBC_Report.SelectedTab = FRM_R.TB_Financial
    End Sub

    Private Sub AnalysisToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AnalysisToolStripMenuItem.Click
        Dim FRM_R As New FRM_Reporter
        FRM_R.Show()
        FRM_R.TBC_Report.SelectedTab = FRM_R.TB_Analysis
    End Sub


    Private Sub HistoryToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HistoryToolStripMenuItem.Click
        Dim FRM_R As New FRM_Reporter
        FRM_R.Show()
        FRM_R.TBC_Report.SelectedTab = FRM_R.TB_History
    End Sub

    Private Sub OthersToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OthersToolStripMenuItem.Click
        Dim FRM_R As New FRM_Reporter
        FRM_R.Show()
        FRM_R.TBC_Report.SelectedTab = FRM_R.TB_Static
    End Sub

    Private Sub AddEditDepartmentToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddEditDepartmentToolStripMenuItem.Click
        FRM_MTNFacility.Show()
        FRM_MTNFacility.BringToFront()
    End Sub

    Private Sub AddNewGRNToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddNewGRNToolStripMenuItem.Click
        FRM_IJGRV.Show(FRMModes.AddNew)
        FRM_IJGRV.BringToFront()
    End Sub

    Private Sub EditExistingGRNToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EditExistingGRNToolStripMenuItem.Click
        FRM_IJGRV.Show(FRMModes.EditExisting)
        FRM_IJGRV.BringToFront()
    End Sub

    Private Sub SuppliersToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MNIT_Suppliers.Click
        FRM_MTNSupplier.Show()
        FRM_MTNSupplier.BringToFront()
    End Sub

    Private Sub NamesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NamesToolStripMenuItem.Click
        FRM_MTNNames.Show()
        FRM_MTNNames.BringToFront()
    End Sub

    Private Sub RoomsAndBedsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MNIT_RoomsNBeds.Click
        FRM_MTNRoomsNBeds.Show()
        FRM_MTNRoomsNBeds.BringToFront()
    End Sub

    Private Sub ChangePasswordToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChangePasswordToolStripMenuItem.Click
        With FRM_MTNEmployees
            .Show()
            .BringToFront()
            .CMBX_EmpType.Visible = False
            .TBX_UserName.Enabled = False
            .CMBX_Name.Enabled = False
            .LBL_EmpType.Visible = False
            .TBX_ChangetoUserName.Visible = False
            .LBL_Changeto.Visible = False
            .LBL_Title.Text = "Change Password"
            .Text = "Change Password"
            .CHBX_IsSystemUser.Visible = False            
        End With
    End Sub

    Private Sub LoginToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LoginToolStripMenuItem.Click
        FRM_GLBLogin.Show()
        Me.Close()
    End Sub

    Private Sub AboutToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AboutToolStripMenuItem.Click
        FRM_GLBAbout.Show()
        FRM_GLBAbout.BringToFront()
    End Sub
#End Region

    Private Sub ToolStripButton1_Click_1(sender As System.Object, e As System.EventArgs) Handles ToolStripButton1.Click

        Search_Items.Show()
        Search_Items.BringToFront()
    End Sub
End Class


