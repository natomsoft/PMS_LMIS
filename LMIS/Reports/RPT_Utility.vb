Imports CrystalDecisions.ReportSource
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.Data.SqlClient

Public Class FilterR_IJ
    Inherits FilterReport
    Private RType As ReportTypes
    Private FRM_R As FRM_Reporter
    Private RDocument As ReportDocument

    Public Sub New(ByVal RepoType As ReportTypes)
        RType = RepoType
        'FRM_R = FRM_Report_Parent
    End Sub
    Public Overrides ReadOnly Property Current_Report As ReportDocument
        Get
            Try
                Select Case RType
                    Case ReportTypes.IJRequestOnly
                        RDocument = New RPT_IJRequestOnly
                    Case ReportTypes.IJRequestDetails
                        RDocument = New RPT_IJRequestDetails
                    Case ReportTypes.IJReceive
                        RDocument = New RPT_IJReceive
                    Case ReportTypes.IJGRN
                        RDocument = New RPT_IJGRN
                    Case ReportTypes.IJPreinvoice
                        RDocument = New RPT_IJPreinvoice
                    Case ReportTypes.IJInvoice
                        RDocument = New RPT_IJInvoice
                    Case ReportTypes.IJInvoiceRejected
                        RDocument = New RPT_IJInvoiceRejected
                    Case ReportTypes.IJAdjustment
                        RDocument = New RPT_IJAdjustment
                    Case ReportTypes.IJExchange
                        RDocument = New RPT_IJExchange
                    Case ReportTypes.IJTransfer
                        RDocument = New RPT_IJTransfer
                    Case ReportTypes.IJIPD
                        RDocument = New RPT_IJIPD
                    Case ReportTypes.IJIPDRequ
                        RDocument = New RPT_IJIPDRequ
                    Case ReportTypes.IJOPD
                        RDocument = New RPT_IJOPD
                    Case ReportTypes.EmployeeDetail
                        RDocument = New RPT_EmployeeDetail
                    Case ReportTypes.EmployeeSummary
                        RDocument = New RPT_EmployeeSummary
                    Case ReportTypes.SDFacilities
                        RDocument = New RPT_SDFacilities
                    Case ReportTypes.SDStoresNLocations
                        RDocument = New RPT_SDStoresNLocations
                    Case ReportTypes.SDRoomsNBeds
                        RDocument = New RPT_SDRoomsNBeds
                    Case ReportTypes.CatalogueListbyCategory
                        RDocument = New RPT_ItemCatalogueListbyCategory
                    Case ReportTypes.ItemsListbysubClassification
                        RDocument = New RPT_ItemsListbysubClassification
                    Case ReportTypes.ItemsListbyClassification
                        RDocument = New RPT_ItemsListbyClassification
                    Case ReportTypes.ItemsListbyCategory
                        RDocument = New RPT_ItemsListbyCategory                        
                    Case ReportTypes.ItemsExpiryDetailed
                        RDocument = New RPT_ItemsExpiryDetailed
                    Case ReportTypes.InventorySheet
                        RDocument = New RPT_InventorySheet
                    Case ReportTypes.ItemsExpirySummary
                        RDocument = New RPT_ItemsExpirySummary
                    Case ReportTypes.ItemsExpiredDetailed
                        RDocument = New RPT_ItemsExpiredDetailed
                    Case ReportTypes.ItemsExpiredSummary
                        RDocument = New RPT_ItemsExpiredSummary
                    Case ReportTypes.IJDistributedSMR
                        RDocument = New RPT_IJSMR
                    Case ReportTypes.IJDistributedSMRFacility
                        RDocument = New RPT_IJSMRFacility
                    Case ReportTypes.IJDistributedSMRRoom
                        RDocument = New RPT_IJDETWardSu
                    Case ReportTypes.IJDistributedDetRoom
                        RDocument = New RPT_IJDETWardPD
                    Case ReportTypes.IJDistributedSMRSupplier
                        RDocument = New RPT_IJSMRSupplier
                    Case ReportTypes.IJDistributedSMRDate
                        RDocument = New RPT_IJSMRDate
                    Case ReportTypes.IJDistributedSMRSupplyPeriod
                        RDocument = New RPT_IJSMRSupplyPeriod
                    Case ReportTypes.IJDistributedSMRPaymentType
                        RDocument = New RPT_IJSMRPaymentType
                    Case ReportTypes.IJDistributedSMRPaymentTypeInstorZone
                        RDocument = New RPT_IJSMRPaymentInstOrZone
                    Case ReportTypes.IJFinancialSMRSupplyPeriod
                        RDocument = New RPT_IJFinancialSMRSupplyPeriod
                    Case ReportTypes.IJFinancialSMRPaymentType
                        RDocument = New RPT_IJFinancialSMRPaymentType
                    Case ReportTypes.IJFinancialSMRPaymentTypeInstorZone
                        RDocument = New RPT_IJFinancialSMRPaymentTypeInstOrZone
                    Case ReportTypes.IJFinancialDETSupplyPeriod
                        RDocument = New RPT_IJFinancialDETSupplyPeriod
                    Case ReportTypes.IJFinancialDETPaymentType
                        RDocument = New RPT_IJFinancialDETPaymentType
                    Case ReportTypes.IJFinancialDETPaymentTypeInstorZone
                        RDocument = New RPT_IJFinancialDETPaymentTypeInstOrZone
                    Case ReportTypes.IJDistributedSMRMonth
                        RDocument = New RPT_IJSMRMonth
                    Case ReportTypes.IJDistributedSMRYear
                        RDocument = New RPT_IJSMRYear
                    Case ReportTypes.IJDistributedSMRItem
                        RDocument = New RPT_IJSMRItem
                    Case ReportTypes.IJDistributedDET
                        RDocument = New RPT_IJDET
                    Case ReportTypes.IJDistributedDETFacility
                        RDocument = New RPT_IJDETFacility
                    Case ReportTypes.IJDistributedDETSupplier
                        RDocument = New RPT_IJDETSupplier
                    Case ReportTypes.IJDistributedDETDate
                        RDocument = New RPT_IJDETDate
                    Case ReportTypes.IJDistributedDETSupplyPeriod
                        RDocument = New RPT_IJDETSupplyPeriod
                    Case ReportTypes.IJDistributedDETPaymentType
                        RDocument = New RPT_IJDETPaymentType
                    Case ReportTypes.IJDistributedDETPaymentTypeInstorZone
                        RDocument = New RPT_IJDETPaymentTypeInstOrZone
                    Case ReportTypes.IJDistributedDETMonth
                        RDocument = New RPT_IJDETMonth
                    Case ReportTypes.IJDistributedDETYear
                        RDocument = New RPT_IJDETYear
                    Case ReportTypes.IJDistributedDETItem
                        RDocument = New RPT_IJDETItem
                    Case ReportTypes.IJFinancialSMRDate
                        RDocument = New RPT_IJFinancialSMRDate
                    Case ReportTypes.IJFinancialSMRMonth
                        RDocument = New RPT_IJFinancialSMRMonth
                    Case ReportTypes.IJFinancialSMRYear
                        RDocument = New RPT_IJFinancialSMRYear
                    Case ReportTypes.IJFinancialSMRDepartment
                        RDocument = New RPT_IJFinancialSMRDepartment
                    Case ReportTypes.IJFinancialSMRDepartmentType
                        RDocument = New RPT_IJFinancialSMRDepartmentType
                    Case ReportTypes.IJFinancialSMRFacility
                        RDocument = New RPT_IJFinancialSMRFacility
                    Case ReportTypes.IJFinancialSMRSupplier
                        RDocument = New RPT_IJFinancialSMRSupplier
                    Case ReportTypes.IJFinancialSMRCategory
                        RDocument = New RPT_IJFinancialSMRCategory
                    Case ReportTypes.IJFinancialSMRClassification
                        RDocument = New RPT_IJFinancialSMRClassification
                    Case ReportTypes.IJFinancialSMRSubClassification
                        RDocument = New RPT_IJFinancialSMRSubClassification
                    Case ReportTypes.IJFinancialSMRFacilityType
                        RDocument = New RPT_IJFinancialSMRFacilityType
                    Case ReportTypes.IJFinancialSMRSubzone
                        RDocument = New RPT_IJFinancialSMRSubzone
                    Case ReportTypes.IJFinancialSMRZone
                        RDocument = New RPT_IJFinancialSMRZone
                    Case ReportTypes.IJFinancialSMRAdjReason
                        RDocument = New RPT_IJFinancialSMRAdjReason
                    Case ReportTypes.IJFinancialDETDate
                        RDocument = New RPT_IJFinancialDETDate
                    Case ReportTypes.IJFinancialDETMonth
                        RDocument = New RPT_IJFinancialDETMonth
                    Case ReportTypes.IJFinancialDETYear
                        RDocument = New RPT_IJFinancialDETMonth
                    Case ReportTypes.IJFinancialDETFacility
                        RDocument = New RPT_IJFinancialDETFacility
                    Case ReportTypes.IJFinancialDETSupplier
                        RDocument = New RPT_IJFinancialDETSupplier
                    Case ReportTypes.IJFinancialDETCategory
                        RDocument = New RPT_IJFinancialDETCategory
                    Case ReportTypes.IJFinancialDETClassification
                        RDocument = New RPT_IJFinancialDETClassification
                    Case ReportTypes.IJFinancialDETSubClassification
                        RDocument = New RPT_IJFinancialDETSubClassification
                    Case ReportTypes.IJFinancialDETSubClassificationCons
                        RDocument = New RPT_IJFinancialDETSubClassificationCons
                    Case ReportTypes.IJFinancialDETDepartment
                        RDocument = New RPT_IJFinancialDETDepartment
                    Case ReportTypes.IJFinancialDETDepartmentType
                        RDocument = New RPT_IJFinancialDETDepartmentType
                    Case ReportTypes.IJFinancialDETAdjReason
                        RDocument = New RPT_IJFinancialDETAdjReason
                    Case ReportTypes.IJDETAdjReason
                        RDocument = New RPT_IJDETAdjReason
                    Case ReportTypes.IJSMRAdjReason
                        RDocument = New RPT_IJSMRAdjReason
                    Case ReportTypes.IJReceivedCriteria
                        RDocument = New RPT_IJReceivedCriteria
                    Case ReportTypes.ItemsQtyAvailable
                        RDocument = New RPT_ItemsQtyAvailble
                    Case ReportTypes.ItemsQtyAvailableBatch
                        RDocument = New RPT_ItemsQtyAvailbleBatch
                    Case ReportTypes.IJAdjustedCriteria
                        RDocument = New RPT_IJAdjustmentCriteria
                    Case ReportTypes.IJDistributedDETPatient
                        RDocument = New RPT_IJDETPatient
                    Case ReportTypes.IJDistributedDETPatientIPD
                        RDocument = New RPT_IJDETPatientIPD
                    Case ReportTypes.IJDistributedSMRPatient
                        RDocument = New RPT_IJSMRPatient
                    Case ReportTypes.IJDistributedDETDepartment
                        RDocument = New RPT_IJDETDepartment
                    Case ReportTypes.IJDistributedSMRDepartmentType
                        RDocument = New RPT_IJSMRDepartmentType
                    Case ReportTypes.IJDistributedSMRDepartment
                        RDocument = New RPT_IJSMRDepartment
                    Case ReportTypes.IJDistributedSMRFacility
                        RDocument = New RPT_IJSMRFacility
                    Case ReportTypes.IJDistributedSMRFacilityType
                        RDocument = New RPT_IJSMRFacilityType
                    Case ReportTypes.IJDistributedSMRSubzone
                        RDocument = New RPT_IJSMRSubZone
                    Case ReportTypes.IJDistributedSMRZone
                        RDocument = New RPT_IJSMRZone
                    Case ReportTypes.ANAcquisitions
                        RDocument = New RPT_ANAcquisitions
                    Case ReportTypes.ANConsumptionbyClassification
                        RDocument = New RPT_ANConsumptionByClassification
                    Case ReportTypes.ANConsumptionbyDepartmentType
                        RDocument = New RPT_ANConsumptionbyDepartmentType
                    Case ReportTypes.ANConsumptionbyFacilityDetail
                        RDocument = New RPT_ANConsumptionbyFacilityDetail
                    Case ReportTypes.ANConsumptionbyFacilitySummary
                        RDocument = New RPT_ANConsumptionbyFacilitySummary
                    Case ReportTypes.ANConsumptionbyFacilityType
                        RDocument = New RPT_ANConsumptionbyFacilityType
                    Case ReportTypes.ANConsumptionbyFacilityTypeSummary
                        RDocument = New RPT_ANConsumptionbyFacilityTypeSummary
                    Case ReportTypes.ANConsumptionvsDistributionDetail
                        RDocument = New RPT_ANConsumptionvsDistributionDetail
                    Case ReportTypes.ANConsumptionvsDistributionDetailSubClass
                        RDocument = New RPT_ANConsumptionvsDistributionDetailSubClass
                    Case ReportTypes.ANConsumptionvsDistributionSummary
                        RDocument = New RPT_ANConsumptionvsDistributionsummary
                    Case ReportTypes.ANRequisitionvsDistributionDetail
                        RDocument = New RPT_ANRequisitionvsDistributionDetail
                    Case ReportTypes.ANRequisitionvsDistributionDetailSubClass
                        RDocument = New RPT_ANRequisitionvsDistributionDetailSubClass
                    Case ReportTypes.ANRequisitionvsDistributionSummary
                        RDocument = New RPT_ANRequisitionvsDistributionummary
                    Case ReportTypes.ANConsumptionTopTenSummary
                        RDocument = New RPT_ANConsumptionTopTenSummary
                    Case ReportTypes.ANConsumptionTopTenDetail
                        RDocument = New RPT_ANConsumptionTopTenDetail
                    Case ReportTypes.ANDistribution
                        RDocument = New RPT_ANDistribution
                    Case ReportTypes.ANDistributionbyDepartmentType
                        RDocument = New RPT_ANDistributionbyDepartmentType
                    Case ReportTypes.ANRequestvsReceiveDetail
                        RDocument = New RPT_ANRequestvsReceiveDetail
                    Case ReportTypes.ANRequestvsReceiveDetailSubClass
                        RDocument = New RPT_ANRequestvsReceiveDetailSubClass
                    Case ReportTypes.ANRequestvsReceiveSummary
                        RDocument = New RPT_ANRequestvsReceivesummary
                    Case ReportTypes.ANLeadTimeDetail
                        RDocument = New RPT_ANLeadTimeDetail
                    Case ReportTypes.ANLeadTimeSummary
                        RDocument = New RPT_ANLeadTimeSummary
                    Case ReportTypes.ANInventoryReportbyDepartmentType
                        RDocument = New RPT_ANInventoryReportbyDepartmentType
                    Case ReportTypes.ItemStockCard
                        RDocument = New RPT_ItemStockCard
                    Case ReportTypes.ItemStockCardSummary
                        RDocument = New RPT_ItemStockCardSummary
                    Case ReportTypes.ABCAnalysis
                        RDocument = New RPT_ANABCAnalysis
                    Case ReportTypes.ItemsStockOut
                        RDocument = New RPT_ItemsStockOut
                    Case ReportTypes.ItemsStockOutMinQty
                        RDocument = New RPT_ItemsStockOutMinQty
                    Case ReportTypes.ItemsStockOutMaxQty
                        RDocument = New RPT_ItemsStockOutMaxQty
                    Case ReportTypes.ItemsStockOutReorderQty
                        RDocument = New RPT_ItemsStockOutReorderQty
                    Case ReportTypes.OPDVisitFreq
                        RDocument = New RPT_OPDPatientFreq
                    Case Else
                        Throw New Exception("No Such Error Type")
                End Select
                Dim Database = RDocument.Database
                Dim Tables_Database = Database.Tables
                Dim TablelogoninfoAll As New TableLogOnInfos
                Dim Connection_Builder As New SqlConnectionStringBuilder(My.Settings.LMISConnectionString)
                Dim Connection_Info As New ConnectionInfo
                With Connection_Info
                    .DatabaseName = Connection_Builder.InitialCatalog
                    .ServerName = Connection_Builder.DataSource
                    .UserID = Connection_Builder.UserID
                    .Password = Connection_Builder.Password
                    .IntegratedSecurity = Connection_Builder.IntegratedSecurity
                End With
                For Each Single_Table As CrystalDecisions.CrystalReports.Engine.Table In Tables_Database
                    Dim Tablelogoninfo As New TableLogOnInfo
                    Tablelogoninfo.ConnectionInfo = Connection_Info
                    TablelogoninfoAll.Add(Tablelogoninfo)
                    Single_Table.ApplyLogOnInfo(Tablelogoninfo)
                Next
                Return RDocument
            Catch ex As Exception
                MessageBox.Show("Error: In Preparing Report" & vbCrLf & ex.Message & Utility.InnerExecption(ex), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return Nothing
            End Try
        End Get
    End Property
    Public Overrides Property FRM_Rep As FRM_Reporter
        Set(ByVal value As FRM_Reporter)
            FRM_R = value
        End Set
        Get
            Return FRM_R
        End Get
    End Property
    Public Overrides ReadOnly Property ReportType As ReportTypes
        Get
            Return RType
        End Get
    End Property
    Public Overrides Sub Populate_Filter_Data()

    End Sub

    Public Overrides Function Get_RPT_Paramters(ByVal ReportParamters As Dictionary(Of String, String())) As ParameterFields
        Try
            Dim RPTParamters As New ParameterFields
            Dim Param_Field_Title As New ParameterField()
            Dim Param_Field_SubTitle As New ParameterField()
            Param_Field_Title.Name = "Title"            
            Param_Field_SubTitle.Name = "SubTitle"
            Dim ParamValueTitle As New ParameterDiscreteValue
            Dim ParamValueSubTitle As New ParameterDiscreteValue
            Dim Subtitle As String = String.Empty
            Dim LMISDbA As New LMISEntities
            Dim FacilityAddress = From FA In LMISDbA.Facility_Addres Select FA
            If FacilityAddress.Count > 0 Then
                If FacilityAddress.First.Tele1 IsNot Nothing Then Subtitle &= "Tele1: " & FacilityAddress.First.Tele1
                If FacilityAddress.First.Tele2 IsNot Nothing Then Subtitle &= " Tele2: " & FacilityAddress.First.Tele2
                If FacilityAddress.First.Fax IsNot Nothing Then Subtitle &= " Fax: " & FacilityAddress.First.Fax
                If FacilityAddress.First.PO_Box IsNot Nothing Then Subtitle &= " PO.Box: " & FacilityAddress.First.PO_Box
                If FacilityAddress.First.Email IsNot Nothing Then Subtitle &= " Email: " & FacilityAddress.First.Email
                If FacilityAddress.First.Address IsNot Nothing Then Subtitle &= " Address: " & FacilityAddress.First.Address
                ParamValueSubTitle.Value = Subtitle
            Else
                ParamValueSubTitle.Value = ""
            End If

            Select Case RType
                Case ReportTypes.IJRequestOnly, ReportTypes.IJRequestDetails
                    Dim ID As String = ReportParamters("ID")(0)
                    Dim Param_Field As New ParameterField()
                    Param_Field.Name = "@RequestID"
                    Dim ParamValue As New ParameterDiscreteValue
                    ParamValue.Value = ID
                    Param_Field.CurrentValues.Add(ParamValue)
                    RPTParamters.Add(Param_Field)

                    Dim LMISDb As New LMISEntities
                    Dim ReqDepartmentID = (From Req In LMISDb.Requests Where Req.ID = ID Select Req.DepartmentID).Single
                    Dim VoucherYear As String = (From Req In LMISDb.Requests Where Req.ID = ID Select Req.InventoryJournal.VoucherDate.Year).Single
                    Dim Counter = (From Req In LMISDb.Requests
                                Where Req.ID <= ID And Req.DepartmentID = ReqDepartmentID And Req.InventoryJournal.VoucherDate.Year = VoucherYear
                                Group By Req.DepartmentID
                                Into Cunt = Count(Req.ID)).single
                    Dim Param_FieldRefNo As New ParameterField()
                    Param_FieldRefNo.Name = "RefNo"
                    Dim ParamValueRefNo As New ParameterDiscreteValue
                    ParamValueRefNo.Value = Counter.Cunt
                    Param_FieldRefNo.CurrentValues.Add(ParamValueRefNo)
                    RPTParamters.Add(Param_FieldRefNo)
                Case ReportTypes.IJReceive

                    Dim ID As String = ReportParamters("ID")(0)
                    Dim Param_Field As New ParameterField()
                    Param_Field.Name = "@RecieveID"
                    Dim ParamValue As New ParameterDiscreteValue
                    ParamValue.Value = ID
                    Param_Field.CurrentValues.Add(ParamValue)
                    RPTParamters.Add(Param_Field)

                    Dim LMISDb As New LMISEntities
                    Dim VoucherYear As String = (From Rec In LMISDb.Recieves Where Rec.ID = ID Select Rec.InventoryJournal.VoucherDate.Year).Single
                    Dim RecDepartmentID = (From ReC In LMISDb.Recieves Where ReC.ID = ID Select ReC.Request.DepartmentID).Single
                    Dim Counter = (From Rec In LMISDb.Recieves
                                Where Rec.ID <= ID And Rec.InventoryJournal.VoucherDate.Year = VoucherYear And Rec.Request.DepartmentID = RecDepartmentID And Rec.InventoryJournal.Void = False
                                Group By Rec.InventoryJournal.InventoryJournalTypeID
                                Into Cunt = Count(Rec.ID)).single
                    Dim Param_FieldRefNo As New ParameterField()
                    Param_FieldRefNo.Name = "RefNo"
                    Dim ParamValueRefNo As New ParameterDiscreteValue
                    ParamValueRefNo.Value = Counter.Cunt
                    Param_FieldRefNo.CurrentValues.Add(ParamValueRefNo)
                    RPTParamters.Add(Param_FieldRefNo)
                Case ReportTypes.IJGRN
                    Dim ID As String = ReportParamters("ID")(0)
                    Dim Param_Field As New ParameterField()
                    Param_Field.Name = "@GRNID"
                    Dim ParamValue As New ParameterDiscreteValue
                    ParamValue.Value = ID
                    Param_Field.CurrentValues.Add(ParamValue)
                    RPTParamters.Add(Param_Field)                    
                    Dim LMISDb As New LMISEntities
                    Dim VoucherYear As String = (From GRNC In LMISDb.GRNs Where GRNC.ID = ID Select GRNC.InventoryJournal.VoucherDate.Year).Single
                    Dim SupplierIDS As String = (From GRNC In LMISDb.GRNs Where GRNC.ID = ID Select GRNC.SupplierID).Single                    
                    Dim Counter = (From GRNC In LMISDb.GRNs
                                Where GRNC.ID <= ID And GRNC.InventoryJournal.VoucherDate.Year = VoucherYear And (GRNC.InventoryJournal.InventoryJournalStatu.Name = "Processed" Or (GRNC.ID = ID And GRNC.InventoryJournal.InventoryJournalStatu.Name = "Pending")) And GRNC.SupplierID = SupplierIDS
                                Group By GRNC.InventoryJournal.InventoryJournalStatu.Name
                                Into Cunt = Count(GRNC.ID)).single
                    Dim Param_FieldRefNo As New ParameterField()
                    Param_FieldRefNo.Name = "RefNo"
                    Dim ParamValueRefNo As New ParameterDiscreteValue                    
                    ParamValueRefNo.Value = Counter.Cunt
                    Param_FieldRefNo.CurrentValues.Add(ParamValueRefNo)
                    RPTParamters.Add(Param_FieldRefNo)
                Case ReportTypes.IJTransfer
                    Dim ID As String = ReportParamters("ID")(0)
                    Dim Param_Field As New ParameterField()
                    Param_Field.Name = "@TransferID"
                    Dim ParamValue As New ParameterDiscreteValue
                    ParamValue.Value = ID
                    Param_Field.CurrentValues.Add(ParamValue)
                    RPTParamters.Add(Param_Field)

                    Dim LMISDb As New LMISEntities
                    Dim VoucherYear As String = (From GRNC In LMISDb.Transfers Where GRNC.ID = ID Select GRNC.InventoryJournal.VoucherDate.Year).Single
                    'Dim FromLoc = (From GRNC In LMISDb.Transfers Where GRNC.ID = ID Select GRNC.InventoryJournal.).Single
                    'Dim ToLoc = (From GRNC In LMISDb.Transfers Where GRNC.ID = ID Select GRNC.ToLocation).Single
                    'Dim Counter = (From GRNC In LMISDb.Transfers
                    '            Where GRNC.ID <= ID And GRNC.InventoryJournal.VoucherDate.Year = VoucherYear And GRNC.InventoryJournal.InventoryJournalStatu.Name = "Processed" And GRNC.FromLocation = FromLoc And GRNC.ToLocation = ToLoc
                    '            Group By GRNC.InventoryJournal.InventoryJournalStatu.Name
                    '            Into Cunt = Count(GRNC.ID)).single
                    Dim Param_FieldRefNo As New ParameterField()
                    Param_FieldRefNo.Name = "RefNo"
                    Dim ParamValueRefNo As New ParameterDiscreteValue
                    ParamValueRefNo.Value = (From GRNC In LMISDb.Transfers Where GRNC.ID = ID Select GRNC.InventoryJournal.VoucherDate.Year).Single
                    Param_FieldRefNo.CurrentValues.Add(ParamValueRefNo)
                    RPTParamters.Add(Param_FieldRefNo)
                Case ReportTypes.IJPreinvoice, ReportTypes.IJInvoice, ReportTypes.IJInvoiceRejected
                    Dim ID As String = ReportParamters("ID")(0)
                    Dim Param_Field As New ParameterField
                    Param_Field.Name = "@IssueID"
                    Dim ParamValue As New ParameterDiscreteValue
                    ParamValue.Value = ID
                    Param_Field.CurrentValues.Add(ParamValue)
                    RPTParamters.Add(Param_Field)
                    If RType <> ReportTypes.IJPreinvoice Then
                        Dim Param_Field_CT As New ParameterField
                        Param_Field_CT.Name = "CustomTitle"
                        Dim ParamValue_CT As New ParameterDiscreteValue
                        ParamValue_CT.Value = IIf(FRM_GLBMain.ApplicationConfig.ThisDepartment.DepartmentType.Description = "Level 1", "Delivery Note", "Invoice")
                        Param_Field_CT.CurrentValues.Add(ParamValue_CT)
                        RPTParamters.Add(Param_Field_CT)
                    End If

                    Dim LMISDb As New LMISEntities
                    Dim VoucherYear As String = (From Iss In LMISDb.Issues Where Iss.ID = ID Select Iss.InventoryJournal.VoucherDate.Year).Single

                    Dim IssueStatus As String = ""
                    Select Case RType
                        Case ReportTypes.IJPreinvoice
                            IssueStatus = "Pending"
                        Case ReportTypes.IJInvoice
                            IssueStatus = "Processed"
                        Case ReportTypes.IJInvoiceRejected
                            IssueStatus = "Rejected"
                    End Select
                    Dim ReqDepartmentID = (From Req In LMISDb.Issues Where Req.ID = ID Select Req.Requisition.DepartmentID).Single
                    Dim Counter = (From Iss In LMISDb.Issues
                                Where Iss.ID <= ID And Iss.InventoryJournal.VoucherDate.Year = VoucherYear And Iss.InventoryJournal.InventoryJournalStatu.Name = IssueStatus And Iss.Requisition.DepartmentID = ReqDepartmentID
                                Group By Iss.InventoryJournal.InventoryJournalStatu.Name
                                Into Cunt = Count(Iss.ID)).single
                    Dim Param_FieldRefNo As New ParameterField()
                    Param_FieldRefNo.Name = "RefNo"
                    Dim ParamValueRefNo As New ParameterDiscreteValue
                    ParamValueRefNo.Value = Counter.Cunt
                    Param_FieldRefNo.CurrentValues.Add(ParamValueRefNo)
                    RPTParamters.Add(Param_FieldRefNo)
                Case ReportTypes.IJAdjustment
                    Dim ID As String = ReportParamters("ID")(0)
                    Dim Param_Field As New ParameterField()
                    Param_Field.Name = "@AdjustmentID"
                    Dim ParamValue As New ParameterDiscreteValue
                    ParamValue.Value = ID
                    Param_Field.CurrentValues.Add(ParamValue)
                    RPTParamters.Add(Param_Field)

                    Dim LMISDb As New LMISEntities
                    Dim VoucherYear As String = (From Adj In LMISDb.Adjustments Where Adj.ID = ID Select Adj.InventoryJournal.VoucherDate.Year).Single
                    Dim Counter = (From Adj In LMISDb.Adjustments
                                Where Adj.ID <= ID And Adj.InventoryJournal.VoucherDate.Year = VoucherYear And Adj.InventoryJournal.InventoryJournalStatu.Name = "Processed"
                                Group By Adj.InventoryJournal.InventoryJournalStatu.Name
                                Into Cunt = Count(Adj.ID)).single
                    Dim Param_FieldRefNo As New ParameterField()
                    Param_FieldRefNo.Name = "RefNo"
                    Dim ParamValueRefNo As New ParameterDiscreteValue
                    ParamValueRefNo.Value = Counter.Cunt
                    Param_FieldRefNo.CurrentValues.Add(ParamValueRefNo)
                    RPTParamters.Add(Param_FieldRefNo)
                    'Case ReportTypes.ItemsList, ReportTypes.ItemsQtyAvailable
                    '
                    'Case ReportTypes.ItemsExpiry, ReportTypes.IJDistributedSMR, ReportTypes.IJDistributedDET, ReportTypes.IJReceivedCriteria, ReportTypes.IJAdjustedCriteria,
                    'ReportTypes.IJDistributedSMRFacility, ReportTypes.IJDistributedSMRDate, ReportTypes.IJDistributedSMRMonth, ReportTypes.IJDistributedSMRYear, ReportTypes.IJDistributedSMRItem, ReportTypes.IJDistributedDETFacility, ReportTypes.IJDistributedDETDate, ReportTypes.IJDistributedDETMonth, ReportTypes.IJDistributedDETYear, ReportTypes.IJDistributedDETItem
                Case Else
                    If ReportParamters IsNot Nothing Then
                        For Each RPTParameterName As String In ReportParamters.Keys
                            For Each RPTParameterValue As String In ReportParamters(RPTParameterName)
                                Dim ParameterOBJ As New ParameterField()
                                ParameterOBJ.Name = RPTParameterName
                                Dim ParameterValue As New ParameterDiscreteValue
                                ParameterValue.Value = RPTParameterValue
                                ParameterOBJ.CurrentValues.Add(ParameterValue)
                                RPTParamters.Add(ParameterOBJ)
                            Next
                        Next
                        'Dim Parameter As String = ""
                        'For Each key In ReportParamters.Keys
                        '    Parameter = Parameter & key & " = " & ReportParamters(key)(0) & vbCrLf
                        'Next
                        'MsgBox(Parameter)
                    End If
            End Select
            If FRM_GLBMain.ApplicationConfig.ThisDepartment.DepartmentType.Description = "Level 2" Or FRM_GLBMain.ApplicationConfig.ThisDepartment.DepartmentType.Description = "Level 1" Then
                ParamValueTitle.Value = FRM_GLBMain.ApplicationConfig.ThisDepartment.Name
                'ParamValueTitle.Value = ReportParamters("Title")(0)
            Else
                ParamValueTitle.Value = FRM_GLBMain.ApplicationConfig.ThisDepartment.Facility.FacilityName & "  - " & FRM_GLBMain.ApplicationConfig.ThisDepartment.Name
                'ParamValueTitle.Value = FRM_GLBMain.ApplicationConfig.ThisDepartment.Facility.FacilityName & "  - " & ReportParamters("Title")(0)
            End If

            Param_Field_SubTitle.CurrentValues.Add(ParamValueSubTitle)
            Param_Field_Title.CurrentValues.Add(ParamValueTitle)
            RPTParamters.Add(Param_Field_SubTitle)
            RPTParamters.Add(Param_Field_Title)
            Return RPTParamters
        Catch ex As Exception
            MessageBox.Show("Error: In Assigning Parameters" & vbCrLf & ex.Message & Utility.InnerExecption(ex), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return Nothing
        End Try
    End Function
    Public Overrides Function Validate_Filter() As Boolean
        'Select Case RType
        '    Case ReportTypes.IJRequestOnly
        Return True
        'End Select
    End Function
End Class

Public MustInherit Class FilterReport
    Public MustOverride Property FRM_Rep As FRM_Reporter
    Public MustOverride ReadOnly Property ReportType As ReportTypes
    Public MustOverride ReadOnly Property Current_Report As ReportDocument
    Public Property Report_Title As String
    Public MustOverride Sub Populate_Filter_Data()
    Public MustOverride Function Get_RPT_Paramters(ByVal Parameters As Dictionary(Of String, String())) As ParameterFields
    Public MustOverride Function Validate_Filter() As Boolean
End Class

Public Enum ReportTypes
    IJRequestOnly
    IJRequestDetails
    IJReceive
    IJPreinvoice
    IJInvoice
    IJInvoiceRejected
    IJAdjustment
    IJTransfer
    IJIPD
    IJIPDRequ
    IJOPD
    IJExchange
    IJDistributedDET
    IJDistributedDETDate
    IJDistributedDETSupplyPeriod
    IJDistributedDETPaymentType
    IJDistributedDETPaymentTypeInstorZone
    IJDistributedDETMonth
    IJDistributedDETYear
    IJDistributedDETItem
    IJDistributedDETDepartment
    IJDistributedDETFacility
    IJDistributedDETSupplier
    IJDistributedDETPatient
    IJDistributedDETPatientIPD
    IJFinancialDETDate
    IJFinancialDETSupplyPeriod
    IJFinancialDETPaymentType
    IJFinancialDETPaymentTypeInstorZone
    IJFinancialDETMonth
    IJFinancialDETYear
    IJFinancialDETDepartment
    IJFinancialDETDepartmentType
    IJFinancialDETFacility
    IJFinancialDETSupplier
    IJFinancialDETCategory
    IJFinancialDETClassification
    IJFinancialDETSubClassification
    IJFinancialDETSubClassificationCons
    'IJFinancialDETFacilityType    
    IJFinancialDETAdjReason
    IJFinancialSMRDate
    IJFinancialSMRSupplyPeriod
    IJFinancialSMRPaymentType
    IJFinancialSMRPaymentTypeInstorZone
    IJFinancialSMRMonth
    IJFinancialSMRYear
    IJFinancialSMRDepartment
    IJFinancialSMRDepartmentType
    IJFinancialSMRFacility
    IJFinancialSMRFacilityType
    IJFinancialSMRSubzone
    IJFinancialSMRZone
    IJFinancialSMRSupplier
    IJFinancialSMRCategory
    IJFinancialSMRClassification
    IJFinancialSMRSubClassification
    IJFinancialSMRAdjReason
    IJDistributedSMR
    IJDistributedSMRDate
    IJDistributedSMRSupplyPeriod
    IJDistributedSMRPaymentType
    IJDistributedSMRPaymentTypeInstorZone
    IJDistributedSMRMonth
    IJDistributedSMRYear
    IJDistributedSMRItem
    IJDistributedSMRDepartment
    IJDistributedSMRDepartmentType
    IJDistributedSMRFacilityType
    IJDistributedSMRSubzone
    IJDistributedSMRZone
    IJDistributedSMRFacility
    IJDistributedSMRRoom
    IJDistributedDetRoom
    IJDistributedSMRSupplier
    IJDistributedSMRPatient
    IJSMRAdjReason
    IJDETAdjReason
    IJReceivedCriteria
    IJReceivedCriteriaDetailed
    IJAdjustedCriteria
    IJAdjustedCriteriaDetailed
    IJGRN
    ItemsListbysubClassification
    ItemsListbyClassification
    ItemsListbyCategory
    CatalogueListbysubClassification
    CatalogueListbyCategory
    ItemsExpiryDetailed
    InventorySheet
    ItemsExpirySummary
    ItemsExpiredDetailed
    ItemsExpiredSummary
    ItemsQtyAvailable
    ItemsQtyAvailableBatch
    ItemsStockOut
    ItemsStockOutMinQty
    ItemsStockOutMaxQty
    ItemsStockOutReorderQty
    ANAcquisitions
    ANConsumptionbyClassification
    ANConsumptionbyDepartmentType
    ANConsumptionbyFacilityDetail
    ANConsumptionbyFacilitySummary
    ANConsumptionbyFacilityType
    ANConsumptionbyFacilityTypeSummary
    ANConsumptionTopTenSummary
    ANConsumptionTopTenDetail
    ANConsumptionvsDistributionSummary
    ANConsumptionvsDistributionDetail
    ANConsumptionvsDistributionDetailSubClass
    ANRequisitionvsDistributionSummary
    ANRequisitionvsDistributionDetail
    ANRequisitionvsDistributionDetailSubClass
    ANRequestvsReceiveDetail
    ANRequestvsReceiveDetailSubClass
    ANRequestvsReceiveSummary
    ANDistribution
    ANDistributionbyDepartmentType
    ANInventoryReportbyDepartmentType
    ANLeadTimeDetail
    ANLeadTimeSummary
    ItemStockCard
    ItemStockCardSummary
    ABCAnalysis
    SDFacilities
    SDStoresNLocations
    SDRoomsNBeds
    EmployeeSummary
    EmployeeDetail
    OPDVisitFreq
End Enum