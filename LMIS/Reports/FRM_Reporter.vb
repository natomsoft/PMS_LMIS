Imports CrystalDecisions.ReportSource
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.Data.SqlClient
Imports System.Data.Objects
Imports System.Transactions

Public Class FRM_Reporter

#Region "declarations"
    Private ReportType As ReportTypes
    Private ReportTitle As String = ""
    Private FilterReport As FilterReport = Nothing
    Private ReportParameters As Dictionary(Of String, String())
    Private RBTNs As New List(Of RadioButton)
    Private InSearchProcess As Boolean

    Public Sub New()
        InitializeComponent()
    End Sub

    Public Overloads Sub show(ByVal Report_Type As ReportTypes, ByVal ReportParameters As Dictionary(Of String, String()))
        ShowReport(Report_Type, ReportParameters)
        Me.Show()
    End Sub

#End Region

#Region "utilites"

    Private Sub ShowReport(ByVal ReportType As ReportTypes, ByVal ReportParameters As Dictionary(Of String, String()))
        Me.ReportParameters = ReportParameters
        Me.ReportType = ReportType
        FilterReport = New FilterR_IJ(ReportType)
        Me.CVWR_Reporter.ReportSource = Nothing
        Me.CVWR_Reporter.ReuseParameterValuesOnRefresh = True
        Me.CVWR_Reporter.ParameterFieldInfo = FilterReport.Get_RPT_Paramters(Me.ReportParameters)
        Me.CVWR_Reporter.ReportSource = FilterReport.Current_Report
        'Me.CVWR_Reporter.LogOnInfo = Set_Login_Parameters(Me.CVWR_Reporter.ReportSource)
        Me.CVWR_Reporter.RefreshReport()
        'CType(Me.CVWR_Reporter.ReportSource, RPT_ItemsList).Section3.SectionFormat.
        'CType(Me.CVWR_Reporter.ReportSource, RPT_ItemsList).GroupHeaderSection1 
        'MsgBox(CType((CType(Me.CVWR_Reporter.ReportSource, RPT_ItemsList).ReportDefinition.ReportObjects("Text23")), CrystalDecisions.CrystalReports.Engine.TextObject).Text)
    End Sub

    Private Sub SetEnableControls(ByVal EnableControl As Control(), ByVal SetVal As Boolean)
        If EnableControl IsNot Nothing Then
            For Each ENControl As Control In EnableControl
                ENControl.Enabled = SetVal
            Next
        End If
    End Sub

    Private Sub EnableNCheck(ByVal EnableControl As Control(), ByVal CheckRadio As RadioButton)
        GBX_ItemsExpiry.Enabled = False
        GBX_StockCard.Enabled = False
        GBX_StockBalance.Enabled = False
        GBX_Catalogue.Enabled = False
        If EnableControl IsNot Nothing Then
            For Each ENControl As Control In EnableControl
                ENControl.Enabled = True
            Next
        End If
        If CheckRadio IsNot Nothing Then
            For Each CHKRadio In RBTNs
                If CHKRadio IsNot CheckRadio Then CHKRadio.Checked = False
            Next
        End If
    End Sub

    Private Function Set_Login_Parameters(ByRef Report_Document As ReportDocument) As TableLogOnInfos
        Dim Database = Report_Document.Database
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
        Return TablelogoninfoAll
    End Function

    Private Function ValidateReport() As Boolean
        Dim NoError As Boolean = True
        ERP_Error.Clear()
        If Not CHBX_ReportForDepa.Checked And Not CHBX_ReportForAllDepa.Checked And CMBX_RepoForDepa.SelectedItem Is Nothing Then SetError(CMBX_RepoForDepa, "An appropriate Department should be selected", NoError)
        If TBC_Report.SelectedTab.Equals(TB_Items) Then
            If RBTN_StockCard.Checked And Not CHBX_STAllBy.Checked And CMBX_StockCardItem.SelectedItem Is Nothing Then SetError(CMBX_StockCardItem, "An appropriate Item should be selected", NoError)
            If RBTN_ItemsStockOut.Checked And CMBX_OutofStock.SelectedItem Is Nothing Then SetError(CMBX_OutofStock, "An appropriate Type should be selected", NoError)
            If RBTN_CatalogueList.Checked Then
                If CMBX_Catalogue.SelectedItem Is Nothing Then
                    SetError(CMBX_Catalogue, "An appropriate Group by should be selected", NoError)
                ElseIf CMBX_CatalogueFilter.Text <> String.Empty And CMBX_CatalogueFilter.SelectedItem Is Nothing Then
                    SetError(CMBX_CatalogueFilter, "An appropriate Filter by should be selected", NoError)
                End If
            End If
        ElseIf TBC_Report.SelectedTab.Equals(TB_Transaction) Then
            If CMBX_IJSummaryRepoType.SelectedItem Is Nothing Then SetError(CMBX_IJSummaryRepoType, "An appropriate Report Type should be selected", NoError)
            If Not CHBX_IJAllGroupBy.Checked And CMBX_IJGroupBy.SelectedItem Is Nothing And CMBX_IJSummaryRepoType.SelectedItem IsNot Nothing Then SetError(CMBX_IJGroupBy, "An appropriate Group Type should be selected", NoError)
            If Not CHBX_IJAllItemNames.Checked And CMBX_IJItemName.SelectedItem Is Nothing Then SetError(CMBX_IJItemName, "An appropriate Item Name should be selected", NoError)
            If Not CHBX_IJAllItemGB.Checked And CHBX_IJAllItemNames.Checked And CMBX_IJItemGB.SelectedItem Is Nothing Then SetError(CMBX_IJItemGB, "An appropriate Item Category should be selected", NoError)
            If CMBX_IJFilter1.Text <> String.Empty And CMBX_IJFilter1.SelectedItem Is Nothing Then SetError(CMBX_IJFilter1, "An appropriate " & LBL_IJFilter1.Text & " should be selected", NoError)
            If Not CHBX_IJAllItemGB.Checked And CMBX_IJItemGB.SelectedItem Is Nothing Then SetError(CMBX_IJItemGB, "An appropriate Group by should be selected", NoError)
            If CMBX_IJItemGB.SelectedItem IsNot Nothing And CMBX_IJItemGBList.SelectedItem Is Nothing Then SetError(CMBX_IJItemGBList, "An appropriate " & LBL_IJItemGB.Text & " should be selected", NoError)
            If CMBX_IJFilter2.Text <> String.Empty And CMBX_IJFilter2.SelectedItem Is Nothing Then SetError(CMBX_IJFilter2, "An appropriate " & LBL_IJFilter1.Text & " should be selected", NoError)
        ElseIf TBC_Report.SelectedTab.Equals(TB_Financial) Then
            If CMBX_FNSummaryRepoType.SelectedItem Is Nothing Then SetError(CMBX_FNSummaryRepoType, "An appropriate Report Type should be selected", NoError)
            If Not CHBX_FNAllGroupBy.Checked And CMBX_FNGroupBy.SelectedItem Is Nothing And CMBX_FNSummaryRepoType.SelectedItem IsNot Nothing Then SetError(CMBX_FNGroupBy, "An appropriate Group Type should be selected", NoError)
            If CMBX_FNFilter1.Text <> String.Empty And CMBX_FNFilter1.SelectedItem Is Nothing Then SetError(CMBX_FNFilter1, "An appropriate " & LBL_FNFilter1.Text & " should be selected", NoError)
            If CMBX_FNFilter2.Text <> String.Empty And CMBX_FNFilter2.SelectedItem Is Nothing Then SetError(CMBX_FNFilter2, "An appropriate " & LBL_FNFilter1.Text & " should be selected", NoError)
        ElseIf TBC_Report.SelectedTab.Equals(TB_Financial) Then
            'If Not CHBX_ANAllGroupBy.Checked And CMBX_ANGroupBy.SelectedItem Is Nothing And CMBX_ANSummaryRepoType.SelectedItem IsNot Nothing Then SetError(CMBX_ANGroupBy, "An appropriate Group Type should be selected", NoError)
        End If
        Return NoError
    End Function

    Private Sub SetError(ByVal ErrorControl As Control, ByVal ErrorText As String, ByRef NoError As Boolean)
        NoError = False
        ERP_Error.SetError(ErrorControl, ErrorText)
    End Sub

    Private Function Nothinger(ByVal CheckObject As Object, ByVal NumberofPerce As Int16) As String
        If CheckObject Is Nothing Then
            If NumberofPerce = 1 Then
                Return "%"
            ElseIf NumberofPerce = 3 Then
                Return "%%%%%%%"
            End If
        Else
            Return CheckObject.ToString()
        End If
        Return Nothing
    End Function

    Private Sub Report(ByVal SummaryOrDetail As String)
        If Not ValidateReport() Then Exit Sub
        Dim ReportParameters As New Dictionary(Of String, String())
        If TBC_Report.SelectedTab.Equals(TB_Items) Then
            ReportParameters.Add("Title", {FRM_GLBMain.ApplicationConfig.ThisDepartment.Name})
            Select Case True
                Case RBTN_CatalogueList.Checked
                    ReportParameters.Add("@ItemCategory", {"%"})
                    ReportParameters.Add("@ItemSubclassification", {"%"})
                    ReportParameters.Add("@ItemClassification", {"%"})
                    If CMBX_Catalogue.SelectedItem IsNot Nothing And CMBX_CatalogueFilter.SelectedItem IsNot Nothing Then
                        'If CMBX_IJItemGBList.SelectedItem IsNot Nothing Then CustomTitle = CMBX_IJItemGBList.Text & " " & CustomTitle
                        Select Case CMBX_Catalogue.Text
                            Case "Item Category"
                                ReportParameters("@ItemCategory") = {CMBX_CatalogueFilter.Text}
                            Case "Item Classification"
                                ReportParameters("@ItemClassification") = {CMBX_CatalogueFilter.Text}
                            Case "Item Sub-Classification"
                                ReportParameters("@ItemSubClassification") = {CMBX_CatalogueFilter.Text}
                        End Select
                    End If
                    If SummaryOrDetail = "Summary" Then
                        'Select Case CMBX_Catalogue.Text
                        '    Case "Item Category"
                        '        ShowReport(ReportTypes.CatalogueListbyCategory, ReportParameters)
                        '    Case "Item Classification"
                        '        ShowReport(ReportTypes.CatalogueListbyCategory, ReportParameters)
                        '    Case "Item Sub-Classification"
                        ShowReport(ReportTypes.CatalogueListbyCategory, ReportParameters)
                        'End Select
                    Else
                        'Select Case CMBX_Catalogue.Text
                        '    Case "Item Category"
                        '        ShowReport(ReportTypes.ItemsListbyCategory, ReportParameters)
                        '    Case "Item Classification"
                        '        ShowReport(ReportTypes.ItemsListbyCategory, ReportParameters)
                        '    Case "Item Sub-Classification"
                        ShowReport(ReportTypes.ItemsListbyCategory, ReportParameters)
                        'End Select
                    End If
                Case RBTN_StockBalace.Checked
                    Dim Title As String = ""
                    ReportParameters.Add("@ReportForDepartmentID", {FRM_GLBMain.ApplicationConfig.ThisDepartment.ID})
                    If CHBX_ReportForAllDepa.Checked Then
                        ReportParameters("@ReportForDepartmentID") = {"%%%%%%%"}
                        ReportParameters("Title") = {"All data Reported to " & FRM_GLBMain.ApplicationConfig.ThisDepartment.Name}
                    ElseIf Not CHBX_ReportForDepa.Checked Then
                        ReportParameters("@ReportForDepartmentID") = {CMBX_RepoForDepa.SelectedValue}
                        ReportParameters("Title") = {CMBX_RepoForDepa.Text & ", Reported to " & FRM_GLBMain.ApplicationConfig.ThisDepartment.Name}
                    End If
                    If CMBX_StockCategory.SelectedItem IsNot Nothing Then
                        ReportParameters.Add("@CategoryID", {CMBX_StockCategory.SelectedValue})
                        If CMBX_StockBalanceItem.SelectedItem Is Nothing Then Title = "For Category " & CMBX_StockCategory.Text
                    Else
                        ReportParameters.Add("@CategoryID", {"%"})
                    End If

                    If CMBX_StockBalanceItem.SelectedItem IsNot Nothing Then
                        Title = "For Stock Item " & CMBX_StockBalanceItem.Text
                        ReportParameters.Add("@ItemID", {CMBX_StockBalanceItem.SelectedValue})
                    Else
                        ReportParameters.Add("@ItemID", {"%"})
                    End If

                    If SummaryOrDetail = "Summary" Then
                        ReportParameters.Add("CustomTitle", {"Stock Balance Summary " & Title & ", as of date " & Date.Today.ToShortDateString})
                        ShowReport(ReportTypes.ItemsQtyAvailable, ReportParameters)
                    Else
                        ReportParameters.Add("CustomTitle", {"Stock Balance Detailed " & Title & ", as of date " & Date.Today.ToShortDateString})
                        ShowReport(ReportTypes.ItemsQtyAvailableBatch, ReportParameters)
                    End If
                Case RBTN_InventorySheet.Checked
                    Dim Title As String = ""
                    ReportParameters.Add("@ReportForDepartmentID", {FRM_GLBMain.ApplicationConfig.ThisDepartment.ID})
                    If CHBX_ReportForAllDepa.Checked Then
                        ReportParameters("@ReportForDepartmentID") = {"%%%%%%%"}
                        ReportParameters("Title") = {"All data Reported to " & FRM_GLBMain.ApplicationConfig.ThisDepartment.Name}
                    ElseIf Not CHBX_ReportForDepa.Checked Then
                        ReportParameters("@ReportForDepartmentID") = {CMBX_RepoForDepa.SelectedValue}
                        ReportParameters("Title") = {CMBX_RepoForDepa.Text & ", Reported to " & FRM_GLBMain.ApplicationConfig.ThisDepartment.Name}
                    End If
                    If CMBX_StockCategory.SelectedItem IsNot Nothing Then
                        ReportParameters.Add("@CategoryID", {CMBX_StockCategory.SelectedValue})
                        If CMBX_StockBalanceItem.SelectedItem Is Nothing Then Title = "For Category " & CMBX_StockCategory.Text
                    Else
                        ReportParameters.Add("@CategoryID", {"%"})
                    End If

                    If CMBX_StockBalanceItem.SelectedItem IsNot Nothing Then
                        Title = "For Stock Item " & CMBX_StockBalanceItem.Text
                        ReportParameters.Add("@ItemID", {CMBX_StockBalanceItem.SelectedValue})
                    Else
                        ReportParameters.Add("@ItemID", {"%"})
                    End If

                    If SummaryOrDetail = "Summary" Then
                        ReportParameters.Add("CustomTitle", {"Stock Balance for Physical Inventory " & Title & " as at " & Date.Today.ToShortDateString})
                        ShowReport(ReportTypes.InventorySheet, ReportParameters)
                    Else
                        ' ReportParameters.Add("CustomTitle", {"Stock Balance Detailed " & Title & " as at " & Date.Today.ToShortDateString})
                        ' ShowReport(ReportTypes.ItemsQtyAvailableBatch, ReportParameters)
                    End If
                Case RBTN_ItemAlreadyExpired.Checked
                    ReportParameters.Add("@ReportForDepartmentID", {FRM_GLBMain.ApplicationConfig.ThisDepartment.ID})
                    If CHBX_ReportForAllDepa.Checked Then
                        ReportParameters("@ReportForDepartmentID") = {"%%%%%%%"}
                        ReportParameters("Title") = {"All data Reported to " & FRM_GLBMain.ApplicationConfig.ThisDepartment.Name}
                    ElseIf Not CHBX_ReportForDepa.Checked Then
                        ReportParameters("@ReportForDepartmentID") = {CMBX_RepoForDepa.SelectedValue}
                        ReportParameters("Title") = {CMBX_RepoForDepa.Text & ", Reported to " & FRM_GLBMain.ApplicationConfig.ThisDepartment.Name}
                    End If
                    If SummaryOrDetail = "Summary" Then
                        ReportParameters.Add("CustomTitle", {"Expired Stock Summary as of date " & Date.Today.ToShortDateString})
                        ShowReport(ReportTypes.ItemsExpiredSummary, ReportParameters)
                    Else
                        ReportParameters.Add("CustomTitle", {"Expired Stock Detailed as of date " & Date.Today.ToShortDateString})
                        ShowReport(ReportTypes.ItemsExpiredDetailed, ReportParameters)
                    End If
                Case RBTN_ItemsStockOut.Checked
                    ReportParameters.Add("@ReportForDepartmentID", {FRM_GLBMain.ApplicationConfig.ThisDepartment.ID})
                    If CHBX_ReportForAllDepa.Checked Then
                        ReportParameters("@ReportForDepartmentID") = {"%%%%%%%"}
                        ReportParameters("Title") = {"All data Reported to " & FRM_GLBMain.ApplicationConfig.ThisDepartment.Name}
                    ElseIf Not CHBX_ReportForDepa.Checked Then
                        ReportParameters("@ReportForDepartmentID") = {CMBX_RepoForDepa.SelectedValue}
                        ReportParameters("Title") = {CMBX_RepoForDepa.Text & ", Reported to " & FRM_GLBMain.ApplicationConfig.ThisDepartment.Name}
                    End If
                    ReportParameters.Add("@ToDate", {DTP_OutofStock.Value.ToShortDateString})
                    Select Case CMBX_OutofStock.Text
                        Case "Zero Balance"
                            ReportParameters.Add("CustomTitle", {"Out of stock up to " & DTP_OutofStock.Value.ToShortDateString})
                            ShowReport(ReportTypes.ItemsStockOut, ReportParameters)
                        Case "Below Minimum Quantity"
                            ReportParameters.Add("CustomTitle", {"Stock below Minimum Quantity up to " & DTP_OutofStock.Value.ToShortDateString})
                            ShowReport(ReportTypes.ItemsStockOutMinQty, ReportParameters)
                        Case "Above Maximum Quantity"
                            ReportParameters.Add("CustomTitle", {"Stock Above Maximum Quantity up to " & DTP_OutofStock.Value.ToShortDateString})
                            ShowReport(ReportTypes.ItemsStockOutMaxQty, ReportParameters)
                        Case "Below Reorder Quantity"
                            ReportParameters.Add("CustomTitle", {"Stock below Reorder Quantity up to " & DTP_OutofStock.Value.ToShortDateString})
                            ShowReport(ReportTypes.ItemsStockOutReorderQty, ReportParameters)
                    End Select

                Case RBTN_ItemExpiry.Checked
                    ReportParameters.Add("@ReportForDepartmentID", {FRM_GLBMain.ApplicationConfig.ThisDepartment.ID})
                    If CHBX_ReportForAllDepa.Checked Then
                        ReportParameters("@ReportForDepartmentID") = {"%%%%%%%"}
                        ReportParameters("Title") = {"All data Reported to " & FRM_GLBMain.ApplicationConfig.ThisDepartment.Name}
                    ElseIf Not CHBX_ReportForDepa.Checked Then
                        ReportParameters("@ReportForDepartmentID") = {CMBX_RepoForDepa.SelectedValue}
                        ReportParameters("Title") = {CMBX_RepoForDepa.Text & ", Reported to " & FRM_GLBMain.ApplicationConfig.ThisDepartment.Name}
                    End If
                    ReportParameters.Add("@FromDate", {DTP_ItemExpiry_From.Value})
                    ReportParameters.Add("@ToDate", {DTP_ItemExpiry_To.Value})
                    If SummaryOrDetail = "Summary" Then
                        ReportParameters.Add("CustomTitle", {"Stock Expiring Summary from date " & DTP_ItemExpiry_From.Value.ToShortDateString & " to " & DTP_ItemExpiry_To.Value.ToShortDateString})
                        ShowReport(ReportTypes.ItemsExpirySummary, ReportParameters)
                    Else
                        ReportParameters.Add("CustomTitle", {"Stock Expiring Detailed from date " & DTP_ItemExpiry_From.Value.ToShortDateString & " to " & DTP_ItemExpiry_To.Value.ToShortDateString})
                        ShowReport(ReportTypes.ItemsExpiryDetailed, ReportParameters)
                    End If
                Case RBTN_StockCard.Checked
                    ReportParameters.Add("@ReportForDepartmentID", {FRM_GLBMain.ApplicationConfig.ThisDepartment.ID})
                    If CHBX_ReportForAllDepa.Checked Then
                        ReportParameters("@ReportForDepartmentID") = {"%%%%%%%"}
                        ReportParameters("Title") = {"All data Reported to " & FRM_GLBMain.ApplicationConfig.ThisDepartment.Name}
                    ElseIf Not CHBX_ReportForDepa.Checked Then
                        ReportParameters("@ReportForDepartmentID") = {CMBX_RepoForDepa.SelectedValue}
                        ReportParameters("Title") = {CMBX_RepoForDepa.Text & ", Reported to " & FRM_GLBMain.ApplicationConfig.ThisDepartment.Name}
                    End If
                    ReportParameters.Add("@ItemID", {CMBX_StockCardItem.SelectedValue})
                    ReportParameters.Add("@FromDate", {DTP_StockCard_From.Value.ToShortDateString})
                    ReportParameters.Add("@ToDate", {DTP_StockCard_To.Value.ToShortDateString})
                    ReportParameters.Add("StartingBalance", {Utility.Get_ItemQtyBeforeDate(CMBX_StockCardItem.SelectedValue, DTP_StockCard_From.Value.ToShortDateString)})
                    If SummaryOrDetail = "Detailed" Then
                        ReportParameters.Add("CustomTitle", {"Stock Card, from " & DTP_StockCard_From.Value.ToShortDateString & " upto " & DTP_StockCard_To.Value.ToShortDateString})
                        ShowReport(ReportTypes.ItemStockCardSummary, ReportParameters)
                    Else
                        If CHBX_STAllBy.Checked Then ReportParameters("@ItemID") = {"%"}
                        ReportParameters.Add("CustomTitle", {"Stock Card Summary from " & DTP_StockCard_From.Value.ToShortDateString & " upto " & DTP_StockCard_To.Value.ToShortDateString})
                        ShowReport(ReportTypes.ItemStockCard, ReportParameters)
                    End If
            End Select
            '_______________Transaction_______________
        ElseIf TBC_Report.SelectedTab.Equals(TB_Transaction) Then
            Dim CustomTitle As String = "Transaction Report" & vbCrLf
            Dim ItemID As String = "%"
            Dim Filter1 As String = "%%%%%%%"
            If Not CHBX_IJAllItemNames.Checked Then ItemID = CMBX_IJItemName.SelectedValue
            ReportParameters.Add("@PrimaryID", {"%"})
            ReportParameters.Add("@IJStatusID", {"2"})
            ReportParameters.Add("@AdjType", {"%"})
            ReportParameters.Add("@AdjDescription", {"%"})
            ReportParameters.Add("@FromDate", {DTP_IJSummary_From.Value})
            ReportParameters.Add("@ToDate", {DTP_IJSummary_To.Value})
            ReportParameters.Add("@WithDateRange", {Not CHBX_IJAllDates.Checked})
            ReportParameters.Add("@ItemCategory", {"%"})
            ReportParameters.Add("@ItemSubclassification", {"%"})
            ReportParameters.Add("@ItemClassification", {"%"})
            ReportParameters.Add("@ItemID", {ItemID})
            ReportParameters.Add("@DepartmentID", {"%%%%%%%"})
            ReportParameters.Add("@DepartmentTypeID", {"%"})
            ReportParameters.Add("@FacilityID", {"%"})
            ReportParameters.Add("@FacilityTypeID", {"%"})
            ReportParameters.Add("@SubzoneID", {"%"})
            ReportParameters.Add("@ZoneID", {"%"})
            ReportParameters.Add("@PersonID", {"%"})
            ReportParameters.Add("@SupplierName", {"%"})
            ReportParameters.Add("@PaymentType", {"%"})
            ReportParameters.Add("@PaymentInstttOrZone", {"%"})
            ReportParameters.Add("@SupplyPeriod", {"%"})
            ReportParameters.Add("@Void", {CHBX_VoidTransactionsT.Checked})
            ReportParameters.Add("Title", {FRM_GLBMain.ApplicationConfig.ThisDepartment.Name})
            ReportParameters.Add("@ReportForDepartmentID", {FRM_GLBMain.ApplicationConfig.ThisDepartment.ID})            
            If CHBX_ReportForAllDepa.Checked Then                
                ReportParameters("@ReportForDepartmentID") = {"%%%%%%%"}
                ReportParameters("Title") = {"All data Reported to " & FRM_GLBMain.ApplicationConfig.ThisDepartment.Name}
            ElseIf Not CHBX_ReportForDepa.Checked Then
                ReportParameters("@ReportForDepartmentID") = {CMBX_RepoForDepa.SelectedValue}
                ReportParameters("Title") = {CMBX_RepoForDepa.Text & ", Reported to " & FRM_GLBMain.ApplicationConfig.ThisDepartment.Name}
            End If

            Select Case CMBX_IJSummaryRepoType.Text
                Case "Items Distributed"
                    ReportParameters.Add("@IJTypeID", {"15"})
                    If SummaryOrDetail = "Detailed" Then
                        ReportParameters.Add("PrimaryColName", {"Invoice No"})
                        ReportParameters.Add("ReqColName", {"Req. No"})
                        ReportParameters.Add("DepartmentColName", {"Recepeint"})
                        CustomTitle = CustomTitle & "Distribution Detail"
                    Else
                        CustomTitle = CustomTitle & "Distribution Summary"
                    End If
                Case "Items Received"
                    ReportParameters.Add("@IJTypeID", {"2"})
                    If SummaryOrDetail = "Detailed" Then
                        ReportParameters.Add("PrimaryColName", {"Receive No"})
                        ReportParameters.Add("ReqColName", {"Invoice No"})
                        ReportParameters.Add("DepartmentColName", {"Supplier"})
                        CustomTitle = CustomTitle & "Receive Detail"
                    Else
                        CustomTitle = CustomTitle & "Receive Summary"
                    End If
                Case "Item Consumed"
                    ReportParameters.Add("@IJTypeID", {"2"})
                    If SummaryOrDetail = "Detailed" Then
                        ReportParameters.Add("PrimaryColName", {"Receive No"})
                        ReportParameters.Add("ReqColName", {"Invoice No"})
                        ReportParameters.Add("DepartmentColName", {"Supplier"})
                        CustomTitle = CustomTitle & "Consumed Detail"
                    Else
                        CustomTitle = CustomTitle & "Consumed Summary"
                    End If
                Case "GRV Items Received"
                    ReportParameters.Add("@IJTypeID", {"20"})
                    If SummaryOrDetail = "Detailed" Then
                        ReportParameters.Add("PrimaryColName", {"Receive No"})
                        ReportParameters.Add("ReqColName", {""})
                        ReportParameters.Add("DepartmentColName", {"Supplier"})
                        CustomTitle = CustomTitle & "GRV Receive Detail"
                    Else
                        CustomTitle = CustomTitle & "GRV Receive Summary"
                    End If
                Case "Items Adjustment Plus"
                    ReportParameters.Add("@IJTypeID", {"7"})
                    ReportParameters("@AdjType") = {"In"}
                    If SummaryOrDetail = "Detailed" Then
                        ReportParameters.Add("PrimaryColName", {"Adjustment No"})
                        ReportParameters.Add("ReqColName", {"Type"})
                        ReportParameters.Add("DepartmentColName", {"Reason"})
                        CustomTitle = CustomTitle & "Adjustment Plus Detail"
                    Else
                        CustomTitle = CustomTitle & "Adjustment Plus Summary"
                    End If
                Case "Items Adjustment Minus"
                    ReportParameters.Add("@IJTypeID", {"8"})
                    ReportParameters("@AdjType") = {"Out"}
                    If SummaryOrDetail = "Detailed" Then
                        ReportParameters.Add("PrimaryColName", {"Adjustment No"})
                        ReportParameters.Add("ReqColName", {"Type"})
                        ReportParameters.Add("DepartmentColName", {"Reason"})
                        CustomTitle = CustomTitle & "Adjustment Minus Detail"
                    Else
                        CustomTitle = CustomTitle & "Adjustment Minus Summary"
                    End If
                Case "Discarded Items"
                    ReportParameters.Add("@IJTypeID", {"23"})
                    ReportParameters("@AdjType") = {"Discard"}
                    If SummaryOrDetail = "Detailed" Then
                        ReportParameters.Add("PrimaryColName", {"Discard No"})
                        ReportParameters.Add("ReqColName", {"Type"})
                        ReportParameters.Add("DepartmentColName", {"Reason"})
                        CustomTitle = CustomTitle & "Discarded Detail"
                    Else
                        CustomTitle = CustomTitle & "Discarded Summary"
                    End If
                Case "OPD Items Distributed"
                    ReportParameters.Add("@IJTypeID", {"16"})
                    If SummaryOrDetail = "Detailed" Then
                        ReportParameters.Add("PrimaryColName", {"Invoice No"})
                        ReportParameters.Add("ReqColName", {"Req.No"})
                        ReportParameters.Add("DepartmentColName", {"Recepeint"})
                        CustomTitle = CustomTitle & "OPD Distribution Detail"
                    Else
                        CustomTitle = CustomTitle & "OPD Distribution Summary"
                    End If
                Case "IPD Items Distributed"
                    ReportParameters.Add("@IJTypeID", {"18"})
                    If SummaryOrDetail = "Detailed" Then
                        ReportParameters.Add("PrimaryColName", {"Invoice No"})
                        ReportParameters.Add("ReqColName", {"Req. No"})
                        ReportParameters.Add("DepartmentColName", {"Recepeint"})
                        CustomTitle = CustomTitle & "IPD Distribution Detail"
                    Else
                        CustomTitle = CustomTitle & "IPD Distribution Summary"
                    End If
            End Select

            If Not CHBX_IJAllItemGB.Checked Then
                If CMBX_IJItemGBList.SelectedItem IsNot Nothing Then CustomTitle = CMBX_IJItemGBList.Text & " " & CustomTitle
                Select Case CMBX_IJItemGB.Text
                    Case "Item Category"
                        ReportParameters("@ItemCategory") = {CMBX_IJItemGBList.Text}
                    Case "Item Classification"
                        ReportParameters("@ItemClassification") = {CMBX_IJItemGBList.Text}
                    Case "Item Sub-Classification"
                        ReportParameters("@ItemSubClassification") = {CMBX_IJItemGBList.Text}
                End Select
            End If

            If Not CHBX_IJAllGroupBy.Checked Then
                CustomTitle = CustomTitle & IIf(CMBX_IJFilter1.SelectedValue IsNot Nothing, " to " & CMBX_IJFilter1.Text, "")
                CustomTitle = CustomTitle & IIf(CMBX_IJGroupBy.SelectedValue IsNot Nothing And CMBX_IJFilter1.SelectedValue Is Nothing, " by " & CMBX_IJGroupBy.Text, "")
                Select Case CMBX_IJGroupBy.Text
                    Case "Adjustment Reason", "Discard Reason"
                        ReportParameters("@AdjDescription") = IIf(CMBX_IJFilter1.SelectedValue IsNot Nothing, {CMBX_IJFilter1.Text}, {"%"})
                    Case "Department", "supplier", "Recipient"
                        ReportParameters("@DepartmentID") = IIf(CMBX_IJFilter1.SelectedValue IsNot Nothing, {Nothinger(CMBX_IJFilter1.SelectedValue, 3)}, {"%%%%%%%"})
                    Case "Facility"
                        ReportParameters("@FacilityID") = IIf(CMBX_IJFilter1.SelectedValue IsNot Nothing, {Nothinger(CMBX_IJFilter1.SelectedValue, 1)}, {"%"})
                    Case "Patient"
                        ReportParameters("@PersonID") = IIf(CMBX_IJFilter1.SelectedValue IsNot Nothing, {Nothinger(CMBX_IJFilter1.SelectedValue, 1)}, {"%"})
                    Case "Ward"
                        ReportParameters("@ward") = IIf(CMBX_IJFilter1.SelectedValue IsNot Nothing, {Nothinger(CMBX_IJFilter1.SelectedValue, 1)}, {"%"})
                    Case "Facility Type"
                        '    ReportParameters("@FacilityTypeID") = IIf(CMBX_IJFilter1.SelectedValue IsNot Nothing, {Nothinger(CMBX_IJFilter1.SelectedValue, 1)}, {"%"})
                        ReportParameters("@DepartmentTypeID") = IIf(CMBX_IJFilter1.SelectedValue IsNot Nothing, {Nothinger(CMBX_IJFilter1.SelectedValue, 1)}, {"%"})
                    Case "Sub Zone"
                        ReportParameters("@SubzoneID") = IIf(CMBX_IJFilter1.SelectedValue IsNot Nothing, {Nothinger(CMBX_IJFilter1.SelectedValue, 1)}, {"%"})
                    Case "Zone"
                        ReportParameters("@ZoneID") = IIf(CMBX_IJFilter1.SelectedValue IsNot Nothing, {Nothinger(CMBX_IJFilter1.SelectedValue, 1)}, {"%"})
                    Case "Supplier"
                        ReportParameters("@SupplierName") = IIf(CMBX_IJFilter1.SelectedValue IsNot Nothing, {CMBX_IJFilter1.Text}, {"%"})
                    Case "Supply Period"
                        ReportParameters("@SupplyPeriod") = IIf(CMBX_IJFilter1.SelectedValue IsNot Nothing, {CMBX_IJFilter1.Text}, {"%"})
                    Case "Payment Type"
                        ReportParameters("@PaymentType") = IIf(CMBX_IJFilter1.SelectedValue IsNot Nothing, {CMBX_IJFilter1.Text}, {"%"})
                    Case "Sick Institute"
                        ReportParameters("@PaymentType") = {"Sick"}
                        ReportParameters("@PaymentInstttOrZone") = IIf(CMBX_IJFilter1.SelectedValue IsNot Nothing, {CMBX_IJFilter1.Text}, {"%"})
                    Case "Admin Zoba"
                        ReportParameters("@PaymentType") = {"Admin"}
                        ReportParameters("@PaymentInstttOrZone") = IIf(CMBX_IJFilter1.SelectedValue IsNot Nothing, {CMBX_IJFilter1.Text}, {"%"})
                    Case "Date", "Month", "Year", "Item"
                        If LBL_IJFilter1.Text = "To Facility" Or LBL_IJFilter1.Text = " Facility" Then
                            ReportParameters("@FacilityID") = IIf(CMBX_IJFilter1.SelectedValue Is Nothing, {"%"}, {Nothinger(CMBX_IJFilter1.SelectedValue, 1)})
                            ReportParameters("@DepartmentID") = IIf(CMBX_IJFilter2.SelectedValue IsNot Nothing, {Nothinger(CMBX_IJFilter2.SelectedValue, 3)}, {"%%%%%%%"})
                        End If
                End Select
            End If
            CustomTitle = CustomTitle & IIf(CHBX_IJAllDates.Checked, "", ", b/n " & DTP_IJSummary_From.Value.ToShortDateString & " & " & DTP_IJSummary_To.Value.ToShortDateString)
            ReportParameters.Add("CustomTitle", {CustomTitle})
            If SummaryOrDetail = "Summary" Then
                If CHBX_IJAllGroupBy.Checked Then
                    ShowReport(ReportTypes.IJDistributedSMR, ReportParameters)
                Else
                    Select Case CMBX_IJGroupBy.Text
                        Case "Item"
                            ShowReport(ReportTypes.IJDistributedSMRItem, ReportParameters)
                        Case "Date"
                            ShowReport(ReportTypes.IJDistributedSMRDate, ReportParameters)
                        Case "Month"
                            ShowReport(ReportTypes.IJDistributedSMRMonth, ReportParameters)
                        Case "Year"
                            ShowReport(ReportTypes.IJDistributedSMRYear, ReportParameters)
                        Case "Department", "supplier", "Recipient"
                            ShowReport(ReportTypes.IJDistributedSMRDepartment, ReportParameters)
                        Case "Facility"
                            ShowReport(ReportTypes.IJDistributedSMRFacility, ReportParameters)
                        Case "Supplier"
                            ShowReport(ReportTypes.IJDistributedSMRSupplier, ReportParameters)
                        Case "Supply Period"
                            ShowReport(ReportTypes.IJDistributedSMRSupplyPeriod, ReportParameters)
                        Case "Adjustment Reason", "Discard Reason"
                            ShowReport(ReportTypes.IJSMRAdjReason, ReportParameters)
                        Case "Patient"
                            ShowReport(ReportTypes.IJDistributedSMRPatient, ReportParameters)
                        Case "Facility Type"
                            ShowReport(ReportTypes.IJDistributedSMRDepartmentType, ReportParameters)
                        Case "Sub Zone"
                            ShowReport(ReportTypes.IJDistributedSMRSubzone, ReportParameters)
                        Case "Zone"
                            ShowReport(ReportTypes.IJDistributedSMRZone, ReportParameters)
                        Case "Payment Type"
                            ShowReport(ReportTypes.IJDistributedSMRPaymentType, ReportParameters)
                        Case "Admin Zoba", "Sick Institute"
                            ShowReport(ReportTypes.IJDistributedSMRPaymentTypeInstorZone, ReportParameters)
                        Case "Ward"
                            ShowReport(ReportTypes.IJDistributedDetRoom, ReportParameters)
                        
                    End Select
                End If
            ElseIf SummaryOrDetail = "Detailed" Then
                If CHBX_IJAllGroupBy.Checked Then
                    ShowReport(ReportTypes.IJDistributedDET, ReportParameters)
                Else
                    Select Case CMBX_IJGroupBy.Text
                        Case "Date"
                            ShowReport(ReportTypes.IJDistributedDETDate, ReportParameters)
                        Case "Month"
                            ShowReport(ReportTypes.IJDistributedDETMonth, ReportParameters)
                        Case "Year"
                            ShowReport(ReportTypes.IJDistributedDETYear, ReportParameters)
                        Case "Department", "supplier", "Recipient"
                            ShowReport(ReportTypes.IJDistributedDETDepartment, ReportParameters)
                        Case "Facility"
                            ShowReport(ReportTypes.IJDistributedDETFacility, ReportParameters)
                        Case "Supplier"
                            ShowReport(ReportTypes.IJDistributedDETSupplier, ReportParameters)
                        Case "Supply Period"
                            ShowReport(ReportTypes.IJDistributedDETSupplyPeriod , ReportParameters)
                        Case "Item"
                            ShowReport(ReportTypes.IJDistributedDETItem, ReportParameters)
                        Case "Adjustment Reason", "Discard Reason"
                            ShowReport(ReportTypes.IJDETAdjReason, ReportParameters)
                        Case "Payment Type"
                            ShowReport(ReportTypes.IJDistributedDETPaymentType, ReportParameters)
                        Case "Admin Zoba", "Sick Institute"
                            ShowReport(ReportTypes.IJDistributedDETPaymentTypeInstorZone, ReportParameters)
                        Case "Patient"
                            Select Case CMBX_IJSummaryRepoType.Text
                                Case "OPD Items Distributed"
                                    ShowReport(ReportTypes.IJDistributedDETPatient, ReportParameters)
                                Case "IPD Items Distributed"
                                    ShowReport(ReportTypes.IJDistributedDETPatientIPD, ReportParameters)
                            End Select
                        Case "Ward"
                            ShowReport(ReportTypes.IJDistributedSMRRoom, ReportParameters)

                    End Select
                End If
            End If
            '_____________Finance____________
        ElseIf TBC_Report.SelectedTab.Equals(TB_Financial) Then
            Dim CustomTitle As String = "Financial Report" & vbCrLf
            Dim ItemID As String = "%"
            Dim Filter1 As String = "%%%%%%%"
            ReportParameters.Add("@PrimaryID", {"%"})
            ReportParameters.Add("@IJStatusID", {"2"})
            ReportParameters.Add("@AdjType", {"%"})
            ReportParameters.Add("@AdjDescription", {"%"})
            ReportParameters.Add("@FromDate", {DTP_FNSummary_From.Value})
            ReportParameters.Add("@ToDate", {DTP_FNSummary_To.Value})
            ReportParameters.Add("@WithDateRange", {Not CHBX_FNAllDates.Checked})
            ReportParameters.Add("@ItemCategory", {"%"})
            ReportParameters.Add("@ItemSubclassification", {"%"})
            ReportParameters.Add("@ItemClassification", {"%"})
            ReportParameters.Add("@ItemID", {"%"})
            ReportParameters.Add("@DepartmentID", {"%%%%%%%"})
            ReportParameters.Add("@DepartmentTypeID", {"%"})
            ReportParameters.Add("@FacilityID", {"%"})
            ReportParameters.Add("@FacilityTypeID", {"%"})
            ReportParameters.Add("@SubzoneID", {"%"})
            ReportParameters.Add("@ZoneID", {"%"})
            ReportParameters.Add("@PersonID", {"%"})
            ReportParameters.Add("@SupplierName", {"%"})
            ReportParameters.Add("@PaymentType", {"%"})
            ReportParameters.Add("@PaymentInstttOrZone", {"%"})
            ReportParameters.Add("@SupplyPeriod", {"%"})
            ReportParameters.Add("@Void", {CHBX_VoidTransactionsF.Checked})
            ReportParameters.Add("Title", {FRM_GLBMain.ApplicationConfig.ThisDepartment.Name})
            ReportParameters.Add("@ReportForDepartmentID", {FRM_GLBMain.ApplicationConfig.ThisDepartment.ID})
            If CHBX_ReportForAllDepa.Checked Then
                ReportParameters("@ReportForDepartmentID") = {"%%%%%%%"}
                ReportParameters("Title") = {"All data Reported to " & FRM_GLBMain.ApplicationConfig.ThisDepartment.Name}
            ElseIf Not CHBX_ReportForDepa.Checked Then
                ReportParameters("@ReportForDepartmentID") = {CMBX_RepoForDepa.SelectedValue}
                ReportParameters("Title") = {CMBX_RepoForDepa.Text & ", Reported to " & FRM_GLBMain.ApplicationConfig.ThisDepartment.Name}
            End If

            Select Case CMBX_FNSummaryRepoType.Text
                Case "Items Distributed"
                    ReportParameters.Add("@IJTypeID", {"15"})
                    If SummaryOrDetail = "Detailed" Then
                        ReportParameters.Add("PrimaryColName", {"Invoice No"})
                        ReportParameters.Add("ReqColName", {"Req. No"})
                        ReportParameters.Add("DepartmentColName", {"Recepeint"})
                        CustomTitle = CustomTitle & "Distribution Detail"
                    Else
                        CustomTitle = CustomTitle & "Distribution Summary"
                    End If
                Case "Items Received"
                    ReportParameters.Add("@IJTypeID", {"2"})
                    If SummaryOrDetail = "Detailed" Then
                        ReportParameters.Add("PrimaryColName", {"Receive No"})
                        ReportParameters.Add("ReqColName", {"Request No"})
                        ReportParameters.Add("DepartmentColName", {"Supplier"})
                        CustomTitle = CustomTitle & "Receive Detail"
                    Else
                        CustomTitle = CustomTitle & "Receive Summary"
                    End If
                Case "Item Consumed"
                    ReportParameters.Add("@IJTypeID", {"99"})
                    If SummaryOrDetail = "Detailed" Then
                        ReportParameters.Add("PrimaryColName", {"Receive No"})
                        ReportParameters.Add("ReqColName", {"Request No"})
                        ReportParameters.Add("DepartmentColName", {"Supplier"})
                        CustomTitle = CustomTitle & "Consumed Detail"
                    Else
                        CustomTitle = CustomTitle & "Consumed Summary"
                    End If
                Case "GRV Items Received"
                    ReportParameters.Add("@IJTypeID", {"20"})
                    If SummaryOrDetail = "Detailed" Then
                        ReportParameters.Add("PrimaryColName", {"Receive No"})
                        ReportParameters.Add("ReqColName", {" "})
                        ReportParameters.Add("DepartmentColName", {"Supplier"})
                        CustomTitle = CustomTitle & "GRV Receive Detail"
                    Else
                        CustomTitle = CustomTitle & "GRV Receive Summary"
                    End If
                Case "Items Adjustment Plus"
                    ReportParameters.Add("@IJTypeID", {"7"})
                    ReportParameters("@AdjType") = {"In"}
                    If SummaryOrDetail = "Detailed" Then
                        ReportParameters.Add("PrimaryColName", {"Adjustment No"})
                        ReportParameters.Add("ReqColName", {"Type"})
                        ReportParameters.Add("DepartmentColName", {""})
                        CustomTitle = CustomTitle & "Adjustment Plus Detail"
                    Else
                        CustomTitle = CustomTitle & "Adjustment Plus Summary"
                    End If
                Case "Items Adjustment Minus"
                    ReportParameters.Add("@IJTypeID", {"8"})
                    ReportParameters("@AdjType") = {"Out"}
                    If SummaryOrDetail = "Detailed" Then
                        ReportParameters.Add("PrimaryColName", {"Adjustment No"})
                        ReportParameters.Add("ReqColName", {"Type"})
                        ReportParameters.Add("DepartmentColName", {"Recepeint"})
                        CustomTitle = CustomTitle & "Adjustment Minus Detail"
                    Else
                        CustomTitle = CustomTitle & "Adjustment Minus Summary"
                    End If
                Case "Discarded Items"
                    ReportParameters.Add("@IJTypeID", {"23"})
                    ReportParameters("@AdjType") = {"Discard"}
                    If SummaryOrDetail = "Detailed" Then
                        ReportParameters.Add("PrimaryColName", {"Discard No"})
                        ReportParameters.Add("ReqColName", {"Type"})
                        ReportParameters.Add("DepartmentColName", {"Recepeint"})
                    End If
                Case "OPD Items Distributed"
                    ReportParameters.Add("@IJTypeID", {"16"})
                    If SummaryOrDetail = "Detailed" Then
                        ReportParameters.Add("PrimaryColName", {"Invoice No"})
                        ReportParameters.Add("ReqColName", {"Requisition No"})
                        ReportParameters.Add("DepartmentColName", {"Recepeint"})
                        CustomTitle = CustomTitle & "OPD Items Distributed Detail"
                    Else
                        CustomTitle = CustomTitle & "OPD Items Distributed Summary"
                    End If
                Case "IPD Items Distributed"
                    ReportParameters.Add("@IJTypeID", {"18"})
                    If SummaryOrDetail = "Detailed" Then
                        ReportParameters.Add("PrimaryColName", {"Invoice No"})
                        ReportParameters.Add("ReqColName", {"Requisition No"})
                        ReportParameters.Add("DepartmentColName", {"Recepeint"})
                        CustomTitle = CustomTitle & "IPD Distribution Detail"
                    Else
                        CustomTitle = CustomTitle & "IPD Distribution Summary"
                    End If
            End Select

            If Not CHBX_FNAllGroupBy.Checked Then
                CustomTitle = CustomTitle & IIf(CMBX_FNFilter1.SelectedValue IsNot Nothing, " to " & CMBX_FNFilter1.Text, "")
                CustomTitle = CustomTitle & IIf(CMBX_FNGroupBy.SelectedValue IsNot Nothing And CMBX_FNFilter1.SelectedValue Is Nothing, " by " & CMBX_FNGroupBy.Text, "")
                Select Case CMBX_FNGroupBy.Text
                    Case "Adjustment Reason", "Discard Reason"
                        ReportParameters("@AdjDescription") = IIf(CMBX_FNFilter1.SelectedValue IsNot Nothing, {CMBX_IJFilter1.Text}, {"%"})
                    Case "Department", "supplier", "Recipient"
                        ReportParameters("@DepartmentID") = IIf(CMBX_FNFilter1.SelectedValue IsNot Nothing, {Nothinger(CMBX_FNFilter1.SelectedValue, 3)}, {"%%%%%%%"})
                    Case "Facility"
                        ReportParameters("@FacilityID") = IIf(CMBX_FNFilter1.SelectedValue IsNot Nothing, {Nothinger(CMBX_FNFilter1.SelectedValue, 1)}, {"%"})
                    Case "Patient"
                        ReportParameters("@PersonID") = IIf(CMBX_FNFilter1.SelectedValue IsNot Nothing, {Nothinger(CMBX_FNFilter1.SelectedValue, 1)}, {"%"})
                    Case "Facility Type"
                        'ReportParameters("@FacilityTypeID") = IIf(CMBX_FNFilter1.SelectedValue IsNot Nothing, {Nothinger(CMBX_FNFilter1.SelectedValue, 1)}, {"%"})
                        ReportParameters("@DepartmentTypeID") = IIf(CMBX_FNFilter1.SelectedValue IsNot Nothing, {Nothinger(CMBX_FNFilter1.SelectedValue, 1)}, {"%"})
                    Case "Department Type"
                        ReportParameters("@DepartmentTypeID") = IIf(CMBX_FNFilter1.SelectedValue IsNot Nothing, {Nothinger(CMBX_FNFilter1.SelectedValue, 1)}, {"%"})
                    Case "Sub Zone"
                        ReportParameters("@SubzoneID") = IIf(CMBX_FNFilter1.SelectedValue IsNot Nothing, {Nothinger(CMBX_FNFilter1.SelectedValue, 1)}, {"%"})
                    Case "Zone"
                        ReportParameters("@ZoneID") = IIf(CMBX_FNFilter1.SelectedValue IsNot Nothing, {Nothinger(CMBX_FNFilter1.SelectedValue, 1)}, {"%"})
                    Case "Supplier"
                        ReportParameters("@SupplierName") = IIf(CMBX_FNFilter1.SelectedValue IsNot Nothing, {CMBX_FNFilter1.Text}, {"%"})
                    Case "Supply Period"
                        ReportParameters("@SupplyPeriod") = IIf(CMBX_FNFilter1.SelectedValue IsNot Nothing, {CMBX_FNFilter1.Text}, {"%"})
                    Case "Category"
                        ReportParameters("@ItemSubclassification") = IIf(CMBX_FNFilter1.SelectedValue IsNot Nothing, {CMBX_FNFilter1.Text}, {"%"})
                    Case "Classification"
                        ReportParameters("@ItemClassification") = IIf(CMBX_FNFilter1.SelectedValue IsNot Nothing, {CMBX_FNFilter1.Text}, {"%"})
                    Case "Sub-Classification"
                        ReportParameters("@ItemSubclassification") = IIf(CMBX_FNFilter1.SelectedValue IsNot Nothing, {CMBX_FNFilter1.Text}, {"%"})
                    Case "Payment Type"
                        ReportParameters("@PaymentType") = IIf(CMBX_FNFilter1.SelectedValue IsNot Nothing, {CMBX_FNFilter1.Text}, {"%"})
                    Case "Sick Institute"
                        ReportParameters("@PaymentType") = {"Sick"}
                        ReportParameters("@PaymentInstttOrZone") = IIf(CMBX_FNFilter1.SelectedValue IsNot Nothing, {CMBX_FNFilter1.Text}, {"%"})
                    Case "Admin Zoba"
                        ReportParameters("@PaymentType") = {"Admin"}
                        ReportParameters("@PaymentInstttOrZone") = IIf(CMBX_FNFilter1.SelectedValue IsNot Nothing, {CMBX_FNFilter1.Text}, {"%"})
                    Case "Date", "Month", "Year", "Item"
                        'If LBL_FNFilter1.Text = "To Facility" Or LBL_FNFilter1.Text = "Facility" Then
                        ReportParameters("@FacilityID") = IIf(CMBX_FNFilter1.SelectedValue Is Nothing, {"%"}, {Nothinger(CMBX_FNFilter1.SelectedValue, 1)})
                        ReportParameters("@DepartmentID") = IIf(CMBX_FNFilter2.SelectedValue IsNot Nothing, {Nothinger(CMBX_FNFilter2.SelectedValue, 3)}, {"%%%%%%%"})
                        'End If
                End Select
            End If
            CustomTitle = CustomTitle & IIf(CHBX_FNAllDates.Checked, "", " from date " & DTP_FNSummary_From.Value.ToShortDateString & " to " & DTP_FNSummary_To.Value.ToShortDateString)
            ReportParameters.Add("CustomTitle", {CustomTitle})
            If SummaryOrDetail = "Summary" Then
                If CHBX_FNAllGroupBy.Checked Then
                    ShowReport(ReportTypes.IJDistributedSMR, ReportParameters)
                Else
                    Select Case CMBX_FNGroupBy.Text
                        Case "Date"
                            ShowReport(ReportTypes.IJFinancialSMRDate, ReportParameters)
                        Case "Month"
                            ShowReport(ReportTypes.IJFinancialSMRMonth, ReportParameters)
                        Case "Year"
                            ShowReport(ReportTypes.IJFinancialSMRYear, ReportParameters)
                        Case "Department", "supplier", "Recipient"
                            ShowReport(ReportTypes.IJFinancialSMRDepartment, ReportParameters)
                        Case "Facility"
                            ShowReport(ReportTypes.IJFinancialSMRFacility, ReportParameters)
                        Case "Supplier"
                            ShowReport(ReportTypes.IJFinancialSMRSupplier, ReportParameters)
                        Case "Category"
                            ShowReport(ReportTypes.IJFinancialSMRCategory, ReportParameters)
                        Case "Classification"
                            ShowReport(ReportTypes.IJFinancialSMRClassification, ReportParameters)
                        Case "Sub-Classification"
                            ShowReport(ReportTypes.IJFinancialSMRSubClassification, ReportParameters)
                        Case "Adjustment Reason", "Discard Reason"
                            ShowReport(ReportTypes.IJFinancialSMRAdjReason, ReportParameters)
                        Case "Department Type", "Facility Type"
                            ShowReport(ReportTypes.IJFinancialSMRDepartmentType, ReportParameters)
                            'Case "Facility Type"
                            '    ShowReport(ReportTypes.IJFinancialSMRFacilityType, ReportParameters)
                        Case "Sub Zone"
                            ShowReport(ReportTypes.IJFinancialSMRSubzone, ReportParameters)
                        Case "Zone"
                            ShowReport(ReportTypes.IJFinancialSMRZone, ReportParameters)
                        Case "Supply Period"
                            ShowReport(ReportTypes.IJFinancialSMRSupplyPeriod, ReportParameters)
                        Case "Payment Type"
                            ShowReport(ReportTypes.IJFinancialSMRPaymentType, ReportParameters)
                        Case "Admin Zoba", "Sick Institute"
                            ShowReport(ReportTypes.IJFinancialSMRPaymentTypeInstorZone, ReportParameters)
                    End Select
                End If
            ElseIf SummaryOrDetail = "Detailed" Then
                If CHBX_FNAllGroupBy.Checked Then
                    ShowReport(ReportTypes.IJDistributedDET, ReportParameters)
                Else
                    Select Case CMBX_FNGroupBy.Text
                        Case "Date"
                            ShowReport(ReportTypes.IJFinancialDETDate, ReportParameters)
                        Case "Month"
                            ShowReport(ReportTypes.IJFinancialDETMonth, ReportParameters)
                        Case "Year"
                            ShowReport(ReportTypes.IJFinancialDETYear, ReportParameters)
                        Case "Department"
                            ShowReport(ReportTypes.IJFinancialDETDepartment, ReportParameters)
                        Case "Department Type"
                            ShowReport(ReportTypes.IJFinancialDETDepartmentType, ReportParameters)
                        Case "Facility"
                            ShowReport(ReportTypes.IJFinancialDETFacility, ReportParameters)
                        Case "Supplier"
                            ShowReport(ReportTypes.IJFinancialDETSupplier, ReportParameters)
                        Case "Category"
                            ShowReport(ReportTypes.IJFinancialDETCategory, ReportParameters)
                        Case "Classification"
                            ShowReport(ReportTypes.IJFinancialDETClassification, ReportParameters)
                        Case "Sub-Classification"
                            If CMBX_FNSummaryRepoType.Text = "Item Consumed" Then
                                ShowReport(ReportTypes.IJFinancialDETSubClassificationCons, ReportParameters)
                            Else
                                ShowReport(ReportTypes.IJFinancialDETSubClassification, ReportParameters)
                            End If
                        Case "Adjustment Reason", "Discard Reason"
                                ShowReport(ReportTypes.IJFinancialDETAdjReason, ReportParameters)
                        Case "Supply Period"
                                ShowReport(ReportTypes.IJFinancialDETSupplyPeriod, ReportParameters)
                        Case "Payment Type"
                                ShowReport(ReportTypes.IJFinancialDETPaymentType, ReportParameters)
                        Case "Admin Zoba", "Sick Institute"
                                ShowReport(ReportTypes.IJFinancialDETPaymentTypeInstorZone, ReportParameters)
                    End Select
                End If
            End If

            '_______Analysis_______
        ElseIf TBC_Report.SelectedTab.Equals(TB_Analysis) Then
            Dim CustomTitle As String = "Analysis Report" & vbCrLf
            Dim ReportType As ReportTypes = Nothing
            ReportParameters.Add("@FromDate", {DTP_ANSummary_From.Value})
            ReportParameters.Add("@ToDate", {DTP_ANSummary_To.Value})
            ReportParameters.Add("@WithDateRange", {Not CHBX_ANAllDates.Checked})
            ReportParameters.Add("Title", {FRM_GLBMain.ApplicationConfig.ThisDepartment.Name})
            ReportParameters.Add("@ReportForDepartmentID", {FRM_GLBMain.ApplicationConfig.ThisDepartment.ID})
            If CHBX_ReportForAllDepa.Checked Then
                ReportParameters("@ReportForDepartmentID") = {"%%%%%%%"}
                ReportParameters("Title") = {"All data Reported to " & FRM_GLBMain.ApplicationConfig.ThisDepartment.Name}
            ElseIf Not CHBX_ReportForDepa.Checked Then
                ReportParameters("@ReportForDepartmentID") = {CMBX_RepoForDepa.SelectedValue}
                ReportParameters("Title") = {CMBX_RepoForDepa.Text & ", Reported to " & FRM_GLBMain.ApplicationConfig.ThisDepartment.Name}
            End If
            Select Case CMBX_ANSummaryRepoType.Text
                Case "Consumption by Classification", "Consumption by Facility", "Consumption by Department Type", "Consumption by Stock Items", "Consumption by Facility Detail", "Consumption by Facility Summary", "Consumption by Facility Type", "Consumption Top Ten"

                    ReportParameters.Add("@DepartmentID", {"%%%%%%%"})
                    ReportParameters.Add("@ItemCategory", {"%"})
                    ReportParameters.Add("@ItemSubclassification", {"%"})
                    ReportParameters.Add("@ItemClassification", {"%"})
                    ReportParameters.Add("@DepartmentTypeID", {"%"})
                    ReportParameters.Add("@FacilityID", {"%"})
                    ReportParameters.Add("@FacilityTypeID", {"%"})

                    Select Case CMBX_ANSummaryRepoType.Text
                        Case "Consumption by Classification"
                            CustomTitle = CustomTitle & "Consumption " & IIf(CMBX_ANGroupBy.SelectedValue IsNot Nothing, "for " & CMBX_ANGroupBy.Text, "by Classification ")
                            ReportParameters("@ItemCategory") = IIf(CMBX_ANGroupBy.SelectedValue IsNot Nothing, {Nothinger(CMBX_ANGroupBy.SelectedValue, 1)}, {"%"})
                            ReportType = ReportTypes.ANConsumptionbyClassification
                        Case "Consumption by Facility"
                            CustomTitle = CustomTitle & "Consumption " & IIf(CMBX_ANGroupBy.SelectedValue IsNot Nothing, "for " & CMBX_ANGroupBy.Text, " by Facility")
                            ReportType = ReportTypes.ANConsumptionbyFacilityTypeSummary
                        Case "Consumption by Facility Type"
                            CustomTitle = CustomTitle & "Consumption " & IIf(CMBX_ANGroupBy.SelectedValue IsNot Nothing, "for " & CMBX_ANGroupBy.Text, "by Facility Type ")
                            ReportParameters("@DepartmentTypeID") = IIf(CMBX_ANGroupBy.SelectedValue IsNot Nothing, {Nothinger(CMBX_ANGroupBy.SelectedValue, 1)}, {"%"})
                            ReportType = ReportTypes.ANConsumptionbyDepartmentType
                        Case "Consumption by Stock Items"
                            CustomTitle = CustomTitle & "Consumption " & IIf(CMBX_ANGroupBy.SelectedValue IsNot Nothing, "for " & CMBX_ANGroupBy.Text, " by Stock Items")
                            ReportParameters("@FacilityID") = IIf(CMBX_ANGroupBy.SelectedValue IsNot Nothing, {Nothinger(CMBX_ANGroupBy.SelectedValue, 1)}, {"%"})
                            ReportType = ReportTypes.ANConsumptionbyFacilityDetail
                        Case "Consumption by Facility Detail", "Consumption by Facility Summary"
                            CustomTitle = CustomTitle & "Consumption " & IIf(CMBX_ANGroupBy.SelectedValue IsNot Nothing, "for " & CMBX_ANGroupBy.Text, "by Facility Type ")
                            ReportParameters("@FacilityID") = IIf(CMBX_ANGroupBy.SelectedValue IsNot Nothing, {Nothinger(CMBX_ANGroupBy.SelectedValue, 1)}, {"%"})
                            ReportType = ReportTypes.ANConsumptionbyFacilityDetail
                            'Case "Consumption by Facility Type"
                            '    CustomTitle = CustomTitle & "Consumption " & IIf(CMBX_ANGroupBy.SelectedValue IsNot Nothing, "for " & CMBX_ANGroupBy.Text, "by Facility Type ")
                            '    ReportParameters("@FacilityTypeID") = IIf(CMBX_ANGroupBy.SelectedValue IsNot Nothing, {Nothinger(CMBX_ANGroupBy.SelectedValue, 1)}, {"%"})
                            '    ReportType = ReportTypes.ANConsumptionbyFacilityType
                        Case "Consumption Top Ten"
                            Select Case SummaryOrDetail
                                Case "Summary"
                                    CustomTitle = CustomTitle & "Consumption Top Ten "
                                    ReportType = ReportTypes.ANConsumptionTopTenDetail
                                Case "Detailed"
                                    CustomTitle = CustomTitle & "Consumption Top Ten "
                                    ReportType = ReportTypes.ANConsumptionTopTenDetail
                            End Select
                    End Select
                Case "Distribution by Facility Type"
                    CustomTitle = CustomTitle & "Distribution by Facility Type "
                    ReportParameters.Add("@DepartmentDescription", IIf(CMBX_ANGroupBy.SelectedValue IsNot Nothing, {Nothinger(CMBX_ANGroupBy.SelectedValue, 1)}, {"%"}))
                    ReportType = ReportTypes.ANDistributionbyDepartmentType
                Case "Stock Card Financial Summary"
                    CustomTitle = CustomTitle & "Stock Card Financial Summary "
                    ReportParameters.Add("@DepartmentTypeID", IIf(CMBX_ANGroupBy.SelectedValue IsNot Nothing, {Nothinger(CMBX_ANGroupBy.SelectedValue, 1)}, {"%"}))
                    ReportType = ReportTypes.ANInventoryReportbyDepartmentType
                Case "Receive"
                    CustomTitle = CustomTitle & "Receive "
                    ReportType = ReportTypes.ANAcquisitions
                Case "ABC Analysis"
                    If (CMBX_ANGroupBy.SelectedValue Is Nothing) Then
                        MsgBox("Please select category first.")
                        CMBX_ANGroupBy.Focus()
                        Exit Sub
                    Else
                        CustomTitle = CustomTitle & CMBX_ANGroupBy.Text & " ABC Analysis "
                        ReportParameters.Add("@CategoryID", IIf(CMBX_ANGroupBy.SelectedValue IsNot Nothing, {Nothinger(CMBX_ANGroupBy.SelectedValue, 1)}, {"%"}))
                        ReportType = ReportTypes.ABCAnalysis
                    End If
                Case "Distribution"
                    CustomTitle = CustomTitle & "Distribution "
                    ReportParameters.Add("DepartmentName", {FRM_GLBMain.ApplicationConfig.ThisDepartment.Name})
                    If Not CHBX_ReportForAllDepa.Checked And Not CHBX_ReportForDepa.Checked Then ReportParameters("DepartmentName") = {CMBX_RepoForDepa.Text}
                    ReportType = ReportTypes.ANDistribution
                Case "Consumption vs Distribution"
                    Select Case SummaryOrDetail
                        Case "Summary"
                            CustomTitle = CustomTitle & "Consumption vs Distribution Summary"
                            ReportType = ReportTypes.ANConsumptionvsDistributionSummary
                        Case "Detailed"
                            Select Case CMBX_ANGroupBy.Text
                                Case "Item"
                                    ReportType = ReportTypes.ANConsumptionvsDistributionDetail
                                    CustomTitle = CustomTitle & "Consumption vs Distribution Detailed by Item"
                                Case "Sub-Classification"
                                    ReportType = ReportTypes.ANConsumptionvsDistributionDetailSubClass
                                    CustomTitle = CustomTitle & "Consumption vs Distribution Detailed by Sub-Classification"
                            End Select
                    End Select
                Case "Requisition vs Distribution"
                    Select Case SummaryOrDetail
                        Case "Summary"
                            CustomTitle = CustomTitle & "Requisition vs Distribution Summary "
                            ReportType = ReportTypes.ANRequisitionvsDistributionSummary
                        Case "Detailed"
                            Select Case CMBX_ANGroupBy.Text
                                Case "Item"
                                    ReportType = ReportTypes.ANRequisitionvsDistributionDetail
                                    CustomTitle = CustomTitle & "Requisition vs Distribution Detailed by Item"
                                Case "Sub-Classification"
                                    ReportType = ReportTypes.ANRequisitionvsDistributionDetailSubClass
                                    CustomTitle = CustomTitle & "Requisition vs Distribution Detailed by Sub-Classification"
                            End Select
                    End Select
                Case "Request vs Receive"
                    Select Case SummaryOrDetail
                        Case "Summary"
                            CustomTitle = CustomTitle & "Request vs Receive Summary "
                            ReportType = ReportTypes.ANRequestvsReceiveSummary
                        Case "Detailed"
                            Select Case CMBX_ANGroupBy.Text
                                Case "Item"
                                    ReportType = ReportTypes.ANRequestvsReceiveDetail
                                    CustomTitle = CustomTitle & "Request vs Receive Detailed by Item"
                                Case "Sub-Classification"
                                    ReportType = ReportTypes.ANRequestvsReceiveDetailSubClass
                                    CustomTitle = CustomTitle & "Request vs Receive Detailed by Sub-Classification"
                            End Select

                    End Select

                Case "Lead Time"
                    Select Case SummaryOrDetail
                        Case "Summary"
                            CustomTitle = CustomTitle & "Lead Times Summary "
                            ReportType = ReportTypes.ANLeadTimeSummary
                        Case "Detailed"
                            CustomTitle = CustomTitle & "Lead Time Detail "
                            ReportType = ReportTypes.ANLeadTimeDetail
                    End Select
            End Select
        If ReportType Then
            CustomTitle = CustomTitle & IIf(CHBX_ANAllDates.Checked, "", " b/n " & DTP_ANSummary_From.Value.ToShortDateString & " and " & DTP_ANSummary_To.Value.ToShortDateString)
            ReportParameters.Add("CustomTitle", {CustomTitle})
            ShowReport(ReportType, ReportParameters)
        End If
        '____________________Static_________________________
        ElseIf TBC_Report.SelectedTab.Equals(TB_Static) Then            
        Select Case CMBX_SDRepoType.Text
            Case "Facilities"
                ReportParameters.Add("@FacilityID", {IIf(Not CHBX_SDSearchAll.Checked And CMBX_SDSearchBy.SelectedItem IsNot Nothing, CMBX_SDSearchBy.SelectedValue, "%")})
                ReportType = ReportTypes.SDFacilities
            Case "Store and Locations"
                ReportType = ReportTypes.SDStoresNLocations
            Case "Rooms and Beds"
                ReportType = ReportTypes.SDRoomsNBeds
            Case "Employee Transactions"
                ReportParameters.Add("@FromDate", {DTP_SD_From.Value})
                ReportParameters.Add("@ToDate", {DTP_SD_To.Value})
                ReportParameters.Add("@ReportForDepartmentID", {FRM_GLBMain.ApplicationConfig.ThisDepartment.ID})
                If CHBX_ReportForAllDepa.Checked Then
                    ReportParameters("@ReportForDepartmentID") = {"%%%%%%%"}
                    ReportParameters("Title") = {"All data Reported to " & FRM_GLBMain.ApplicationConfig.ThisDepartment.Name}
                ElseIf Not CHBX_ReportForDepa.Checked Then
                    ReportParameters("@ReportForDepartmentID") = {CMBX_RepoForDepa.SelectedValue}
                    ReportParameters("Title") = {CMBX_RepoForDepa.Text & ", Reported to " & FRM_GLBMain.ApplicationConfig.ThisDepartment.Name}
                End If
                Select Case SummaryOrDetail
                    Case "Summary"
                        ReportType = ReportTypes.EmployeeSummary
                    Case "Detailed"
                        ReportType = ReportTypes.EmployeeDetail
                End Select
            Case "OPD Patient visit frequency"
                ReportParameters.Add("@FromDate", {DTP_SD_From.Value})
                ReportParameters.Add("@ToDate", {DTP_SD_To.Value})
                ReportParameters.Add("CustomTitle", {"Patient visit frequency list, from between " & DTP_SD_From.Value.ToShortDateString & " and " & DTP_SD_From.Value.ToShortDateString})
                ReportParameters.Add("@ReportForDepartmentID", {FRM_GLBMain.ApplicationConfig.ThisDepartment.ID})
                If CHBX_ReportForAllDepa.Checked Then
                    ReportParameters("@ReportForDepartmentID") = {"%%%%%%%"}
                    ReportParameters("Title") = {"All data Reported to " & FRM_GLBMain.ApplicationConfig.ThisDepartment.Name}
                ElseIf Not CHBX_ReportForDepa.Checked Then
                    ReportParameters("@ReportForDepartmentID") = {CMBX_RepoForDepa.SelectedValue}
                    ReportParameters("Title") = {CMBX_RepoForDepa.Text & ", Reported to " & FRM_GLBMain.ApplicationConfig.ThisDepartment.Name}
                End If
                ReportType = ReportTypes.OPDVisitFreq
        End Select
        If ReportType Then
            If Not ReportParameters.Keys.Contains("Title") Then ReportParameters.Add("Title", {FRM_GLBMain.ApplicationConfig.ThisDepartment.Name})
            'Dim Parameter As String = ""
            'For Each key In ReportParameters.Keys
            '    Parameter = Parameter & key & " = " & ReportParameters(key)(0) & vbCrLf
            'Next
            'MsgBox(Parameter)
            ShowReport(ReportType, ReportParameters)
        End If
        End If

    End Sub

#End Region

#Region "Events"

#Region "MainEvents"

    Private Sub FRM_FilterRPT_Inv_Items_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.MdiParent = FRM_GLBMain
        Dim LMISDb As New LMISEntities
        If Not FRM_GLBMain.CheckVisible(TB_Analysis.Name) Then TB_Analysis.Hide()

        CMBX_IJItemName.DataSource = From I In LMISDb.InventoryItems Select I.ID, I.Name
        CMBX_IJItemName.DisplayMember = "Name"
        CMBX_IJItemName.ValueMember = "ID"
        CMBX_IJItemName.SelectedItem = Nothing

        CMBX_StockCategory.DataSource = From I In LMISDb.InventoryCategories Select I.ID, I.Name
        CMBX_StockCategory.DisplayMember = "Name"
        CMBX_StockCategory.ValueMember = "ID"
        CMBX_StockCategory.SelectedItem = Nothing

        CMBX_StockCardItem.DataSource = From I In LMISDb.InventoryItems Select I.ID, I.Name
        CMBX_StockCardItem.DisplayMember = "Name"
        CMBX_StockCardItem.ValueMember = "ID"
        CMBX_StockCardItem.SelectedItem = Nothing

        CMBX_RepoForDepa.DataSource = From D In LMISDb.Departments Join IJ In LMISDb.InventoryJournals On D.ID Equals IJ.DepartmentID Select D Distinct
        CMBX_RepoForDepa.DisplayMember = "Name"
        CMBX_RepoForDepa.ValueMember = "ID"
        CMBX_RepoForDepa.SelectedItem = Nothing
        'CMBX_RepoForDepa.SelectedItem = IIf((From d In CType(CMBX_RepoForDepa.DataSource, ObjectQuery(Of Department)) Where d.ID = FRM_GLBMain.ApplicationConfig.ThisDepartment.ID Select d).Count > 0, FRM_GLBMain.ApplicationConfig.ThisDepartment, Nothing)
    End Sub

    Private Sub BTN_Summary_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTN_Report.Click
        Report("Summary")
    End Sub

    Private Sub BTN_Detailed_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTN_Detailed.Click
        Report("Detailed")
    End Sub

    Private Sub BTN_Close_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTN_Close.Click
        Me.Close()
    End Sub

    Private Sub CHBX_ReportForDepa_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CHBX_ReportForDepa.CheckedChanged
        If CHBX_ReportForDepa.Checked Then
            CMBX_RepoForDepa.Enabled = False
            CHBX_ReportForAllDepa.Checked = False
        ElseIf Not CHBX_ReportForDepa.Checked And Not CHBX_ReportForAllDepa.Checked Then
            CMBX_RepoForDepa.Enabled = True
        End If
    End Sub

    Private Sub CHBX_ReportForAllDepa_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CHBX_ReportForAllDepa.CheckedChanged
        If CHBX_ReportForAllDepa.Checked Then
            CMBX_RepoForDepa.Enabled = False
            CHBX_ReportForDepa.Checked = False
        ElseIf Not CHBX_ReportForDepa.Checked And Not CHBX_ReportForAllDepa.Checked Then
            CMBX_RepoForDepa.Enabled = True
        End If
    End Sub

    Private Sub TBC_Report_SelectChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TBC_Report.SelectedIndexChanged
        BTN_Detailed.Enabled = True
        'If TBC_Report.SelectedTab.Equals(TB_Analysis) Then BTN_Detailed.Enabled = False
    End Sub

    Private Sub TB_Items_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TBC_Report.SelectedIndexChanged
        If TBC_Report.SelectedTab.Equals(TB_Financial) Or TBC_Report.SelectedTab.Equals(TB_Analysis) Then BTN_Detailed.Enabled = False
    End Sub

#End Region

#Region "TB_Items"

    Private Sub DTP_ItemExpiry_From_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DTP_IJSummary_From.ValueChanged
        DTP_ItemExpiry_To.MinDate = DTP_ItemExpiry_From.Value
    End Sub

    Private Sub DTP_ItemExpiry_To_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DTP_IJSummary_To.ValueChanged
        DTP_ItemExpiry_From.MaxDate = DTP_ItemExpiry_To.Value
    End Sub

    Private Sub RBTN_ItemExpiry_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RBTN_ItemExpiry.CheckedChanged
        If RBTN_ItemExpiry.Checked Then EnableNCheck({GBX_ItemsExpiry}, RBTN_ItemExpiry)
    End Sub

    Private Sub RBTN_ItemQtyAvailable_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RBTN_StockBalace.CheckedChanged
        If RBTN_StockBalace.Checked Then EnableNCheck({GBX_StockBalance}, RBTN_StockBalace)
    End Sub

    Private Sub RBTN_ItemList_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RBTN_CatalogueList.CheckedChanged
        If RBTN_CatalogueList.Checked Then EnableNCheck({GBX_Catalogue}, RBTN_CatalogueList)
    End Sub

    Private Sub RBTN_ItemAlreadyExpired_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RBTN_ItemAlreadyExpired.CheckedChanged
        If RBTN_ItemAlreadyExpired.Checked Then EnableNCheck(Nothing, RBTN_ItemAlreadyExpired)
    End Sub

    Private Sub RBTN_ItemsStockOut_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RBTN_ItemsStockOut.CheckedChanged
        If RBTN_ItemsStockOut.Checked Then EnableNCheck({GBX_OutofStock}, RBTN_ItemsStockOut)
    End Sub

    Private Sub RBTN_StockCard_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RBTN_StockCard.CheckedChanged
        If RBTN_StockCard.Checked Then EnableNCheck({GBX_StockCard}, RBTN_StockCard)
    End Sub

    Private Sub CMBX_Catalogue_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBX_Catalogue.SelectedIndexChanged
        If CMBX_Catalogue.SelectedItem IsNot Nothing Then
            Dim LMISDb As New LMISEntities
            With CMBX_CatalogueFilter
                Select Case CMBX_Catalogue.Text
                    Case "Item Category"
                        LBL_Catalogue.Text = "Item Category"
                        .DataSource = From IC In LMISDb.Categories Select IC.ID, IC.Name
                    Case "Item Classification"
                        LBL_Catalogue.Text = "Item Classification"
                        .DataSource = From IC In LMISDb.Classifications Select IC.ID, IC.Name
                    Case "Item Sub-Classification"
                        LBL_Catalogue.Text = "Item Sub-Classification"
                        .DataSource = From IC In LMISDb.InventoryCategories Select IC.ID, IC.Name
                End Select
                .DisplayMember = "Name"
                .ValueMember = "ID"
                .AutoCompleteSource = AutoCompleteSource.ListItems
                .SelectedItem = Nothing
            End With
        End If
    End Sub

    Private Sub DTP_StockCard_From_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DTP_StockCard_From.ValueChanged
        DTP_StockCard_To.MinDate = DTP_StockCard_From.Value
    End Sub

    Private Sub DTP_StockCard_To_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DTP_StockCard_To.ValueChanged
        DTP_StockCard_From.MaxDate = DTP_StockCard_To.Value
    End Sub

    Private Sub DTP_ItemExpiry_From_ValueChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DTP_ItemExpiry_From.ValueChanged
        DTP_ItemExpiry_To.MinDate = DTP_ItemExpiry_From.Value
    End Sub

    Private Sub DTP_ItemExpiry_To_ValueChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DTP_ItemExpiry_To.ValueChanged
        DTP_ItemExpiry_From.MaxDate = DTP_ItemExpiry_To.Value
    End Sub

    Private Sub CHBX_STAllBy_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CHBX_STAllBy.CheckedChanged
        CMBX_StockCardItem.Enabled = Not CHBX_STAllBy.Checked
    End Sub

    Private Sub CMBX_StockCategory_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBX_StockCategory.SelectedIndexChanged
        If CMBX_StockCategory.SelectedItem IsNot Nothing And CMBX_StockCategory.ValueMember <> String.Empty Then
            Dim lMISDb As New LMISEntities
            Dim CatID As Integer = CMBX_StockCategory.SelectedValue
            CMBX_StockBalanceItem.DataSource = From I In lMISDb.InventoryItems Where I.ItemsCatalogue.InventoryCategoryID = CatID Select I.ID, I.Name
            CMBX_StockBalanceItem.DisplayMember = "Name"
            CMBX_StockBalanceItem.ValueMember = "ID"
            CMBX_StockBalanceItem.SelectedItem = Nothing
        Else
            CMBX_StockBalanceItem.DataSource = Nothing
        End If

    End Sub
#End Region

#Region "TB_Transaction"

    Private Sub CMBX_IJSummaryRepoType_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBX_IJSummaryRepoType.TextChanged
        GBX_IJ.Enabled = IIf(CMBX_IJSummaryRepoType.SelectedItem IsNot Nothing, True, False)
    End Sub

    Private Sub CMBX_IJSummaryRepoType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBX_IJSummaryRepoType.SelectedIndexChanged
        If CMBX_IJSummaryRepoType.SelectedItem IsNot Nothing Then
            GBX_IJ.Enabled = True
            Select Case CMBX_IJSummaryRepoType.Text
                Case "Items Distributed"
                    'CMBX_IJGroupBy.DataSource = {"Item", "Date", "Month", "Year", "Recipient", "Facility", "Facility Type", "Sub Zone", "Zone"}
                    CMBX_IJGroupBy.DataSource = {"Item", "Date", "Month", "Year", "Recipient", "Supply Period", "Facility Type", "Sub Zone", "Zone"}
                Case "Items Received"
                    'CMBX_IJGroupBy.DataSource = {"Item", "Date", "Month", "Year", "supplier", "Facility", "Facility Type", "Sub Zone", "Zone"}
                    CMBX_IJGroupBy.DataSource = {"Item", "Date", "Month", "Year", "supplier", "Facility Type", "Sub Zone", "Zone"}
                Case "Item Consumed"
                    CMBX_FNGroupBy.DataSource = {"Sub-Classification"}
                Case "GRV Items Received"
                    CMBX_IJGroupBy.DataSource = {"Item", "Date", "Month", "Year", "Supplier"}
                Case "Items Adjustment Plus", "Items Adjustment Minus"
                    CMBX_IJGroupBy.DataSource = {"Item", "Date", "Month", "Year", "Adjustment Reason"}
                Case "Discarded Items"
                    CMBX_IJGroupBy.DataSource = {"Item", "Date", "Month", "Year", "Discard Reason"}
                Case "OPD Items Distributed"
                    CMBX_IJGroupBy.DataSource = {"Item", "Date", "Month", "Year", "Patient", "Payment Type", "Admin Zoba", "Sick Institute"}
                Case "IPD Items Distributed"
                    CMBX_IJGroupBy.DataSource = {"Item", "Date", "Month", "Year", "Patient", "Payment Type", "Admin Zoba", "Sick Institute", "Ward"}

            End Select
            CMBX_IJGroupBy.SelectedItem = Nothing
            DataSourcer.AssignDataSource(GRPDatas.Naught, CMBX_IJFilter1, LBL_IJFilter1)
            DataSourcer.AssignDataSource(GRPDatas.Naught, CMBX_IJFilter2, LBL_IJFilter2)
        Else
            GBX_IJ.Enabled = False
        End If
    End Sub

    Private Sub CMBX_IJGroupBy_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBX_IJGroupBy.SelectedIndexChanged
        If CMBX_IJGroupBy.SelectedItem IsNot Nothing Then
            Select Case CMBX_IJGroupBy.Text
                Case "Item", "Date", "Month", "Year"
                    BTN_Detailed.Enabled = True
                    Select Case CMBX_IJSummaryRepoType.Text
                        Case "Items Distributed"
                            DataSourcer.AssignDataSource(GRPDatas.ToFacility, CMBX_IJFilter1, LBL_IJFilter1)
                            DataSourcer.AssignDataSource(GRPDatas.ToDepartment, CMBX_IJFilter2, LBL_IJFilter2)
                        Case "Items Received"
                            DataSourcer.AssignDataSource(GRPDatas.FromFacility, CMBX_IJFilter1, LBL_IJFilter1)
                            DataSourcer.AssignDataSource(GRPDatas.FromDepartment, CMBX_IJFilter2, LBL_IJFilter2)
                        Case "Item Consumed"
                            DataSourcer.AssignDataSource(GRPDatas.FromFacility, CMBX_IJFilter1, LBL_IJFilter1)
                            DataSourcer.AssignDataSource(GRPDatas.FromDepartment, CMBX_IJFilter2, LBL_IJFilter2)
                        Case "Items Adjustment Plus"
                            DataSourcer.AssignDataSource(GRPDatas.InAdjReason, CMBX_IJFilter1, LBL_IJFilter1)
                            DataSourcer.AssignDataSource(GRPDatas.Naught, CMBX_IJFilter2, LBL_IJFilter2)
                        Case "Items Adjustment Minus"
                            DataSourcer.AssignDataSource(GRPDatas.OutAdjReason, CMBX_IJFilter1, LBL_IJFilter1)
                            DataSourcer.AssignDataSource(GRPDatas.Naught, CMBX_IJFilter2, LBL_IJFilter2)
                        Case "Discarded Items"
                            DataSourcer.AssignDataSource(GRPDatas.DiscardReason, CMBX_IJFilter1, LBL_IJFilter1)
                            DataSourcer.AssignDataSource(GRPDatas.Naught, CMBX_IJFilter2, LBL_IJFilter2)
                        Case "OPD Items Distributed", "IPD Items Distributed"
                            DataSourcer.AssignDataSource(GRPDatas.Patient, CMBX_IJFilter1, LBL_IJFilter1)
                            DataSourcer.AssignDataSource(GRPDatas.Naught, CMBX_IJFilter2, LBL_IJFilter2)
                        Case Else
                            DataSourcer.AssignDataSource(GRPDatas.Naught, CMBX_IJFilter1, LBL_IJFilter1)
                            DataSourcer.AssignDataSource(GRPDatas.Naught, CMBX_IJFilter2, LBL_IJFilter2)
                    End Select
                Case "Patient"
                    BTN_Detailed.Enabled = True
                    Select Case CMBX_IJSummaryRepoType.Text
                        Case "OPD Items Distributed", "IPD Items Distributed"
                            DataSourcer.AssignDataSource(GRPDatas.Patient, CMBX_IJFilter1, LBL_IJFilter1)
                            DataSourcer.AssignDataSource(GRPDatas.Naught, CMBX_IJFilter2, LBL_IJFilter2)
                        Case Else
                            DataSourcer.AssignDataSource(GRPDatas.Naught, CMBX_IJFilter1, LBL_IJFilter1)
                            DataSourcer.AssignDataSource(GRPDatas.Naught, CMBX_IJFilter2, LBL_IJFilter2)
                    End Select
                Case "Department", "supplier", "Recipient"
                    BTN_Detailed.Enabled = True
                    Select Case CMBX_IJSummaryRepoType.Text
                        Case "Items Distributed"
                            DataSourcer.AssignDataSource(GRPDatas.ToDepartment, CMBX_IJFilter1, LBL_IJFilter1)
                            DataSourcer.AssignDataSource(GRPDatas.Naught, CMBX_IJFilter2, LBL_IJFilter2)
                        Case "Items Received"
                            DataSourcer.AssignDataSource(GRPDatas.FromDepartment, CMBX_IJFilter1, LBL_IJFilter1)
                            DataSourcer.AssignDataSource(GRPDatas.Naught, CMBX_IJFilter2, LBL_IJFilter2)
                        Case "Item Consumed"
                            DataSourcer.AssignDataSource(GRPDatas.FromDepartment, CMBX_IJFilter1, LBL_IJFilter1)
                            DataSourcer.AssignDataSource(GRPDatas.Naught, CMBX_IJFilter2, LBL_IJFilter2)
                        Case Else
                            DataSourcer.AssignDataSource(GRPDatas.Naught, CMBX_IJFilter1, LBL_IJFilter1)
                            DataSourcer.AssignDataSource(GRPDatas.Naught, CMBX_IJFilter2, LBL_IJFilter2)
                    End Select
                Case "Department Type", "Facility Type"
                    BTN_Detailed.Enabled = False
                    Select Case CMBX_IJSummaryRepoType.Text
                        Case "Items Distributed", "Items Received", "Item Consumed"
                            DataSourcer.AssignDataSource(GRPDatas.DepartmentType, CMBX_IJFilter1, LBL_IJFilter1)
                            DataSourcer.AssignDataSource(GRPDatas.Naught, CMBX_IJFilter2, LBL_IJFilter2)
                        Case Else
                            DataSourcer.AssignDataSource(GRPDatas.Naught, CMBX_IJFilter1, LBL_IJFilter1)
                            DataSourcer.AssignDataSource(GRPDatas.Naught, CMBX_IJFilter2, LBL_IJFilter2)
                    End Select
                    'Case "Facility Type"
                    '    BTN_Detailed.Enabled = False
                    '    Select Case CMBX_IJSummaryRepoType.Text
                    '        Case "Items Distributed", "Items Received"
                    '            DataSourcer.AssignDataSource(GRPDatas.FacilityType, CMBX_IJFilter1, LBL_IJFilter1)
                    '            DataSourcer.AssignDataSource(GRPDatas.Naught, CMBX_IJFilter2, LBL_IJFilter2)
                    '        Case Else
                    '            DataSourcer.AssignDataSource(GRPDatas.Naught, CMBX_IJFilter1, LBL_IJFilter1)
                    '            DataSourcer.AssignDataSource(GRPDatas.Naught, CMBX_IJFilter2, LBL_IJFilter2)
                    '    End Select
                Case "Facility"
                    BTN_Detailed.Enabled = True
                    Select Case CMBX_IJSummaryRepoType.Text
                        Case "Items Distributed"
                            DataSourcer.AssignDataSource(GRPDatas.ToFacility, CMBX_IJFilter1, LBL_IJFilter1)
                            DataSourcer.AssignDataSource(GRPDatas.Naught, CMBX_IJFilter2, LBL_IJFilter2)
                        Case "Items Received"
                            DataSourcer.AssignDataSource(GRPDatas.FromFacility, CMBX_IJFilter1, LBL_IJFilter1)
                            DataSourcer.AssignDataSource(GRPDatas.Naught, CMBX_IJFilter2, LBL_IJFilter2)
                        Case "Item Consumed"
                            DataSourcer.AssignDataSource(GRPDatas.FromFacility, CMBX_IJFilter1, LBL_IJFilter1)
                            DataSourcer.AssignDataSource(GRPDatas.Naught, CMBX_IJFilter2, LBL_IJFilter2)
                        Case Else
                            DataSourcer.AssignDataSource(GRPDatas.Naught, CMBX_IJFilter1, LBL_IJFilter1)
                            DataSourcer.AssignDataSource(GRPDatas.Naught, CMBX_IJFilter2, LBL_IJFilter2)
                    End Select
                Case "Sub Zone"
                    BTN_Detailed.Enabled = False
                    Select Case CMBX_IJSummaryRepoType.Text
                        Case "Items Distributed", "Items Received", "Item Consumed"
                            DataSourcer.AssignDataSource(GRPDatas.Subzone, CMBX_IJFilter1, LBL_IJFilter1)
                            DataSourcer.AssignDataSource(GRPDatas.Naught, CMBX_IJFilter2, LBL_IJFilter2)
                        Case Else
                            DataSourcer.AssignDataSource(GRPDatas.Naught, CMBX_IJFilter1, LBL_IJFilter1)
                            DataSourcer.AssignDataSource(GRPDatas.Naught, CMBX_IJFilter2, LBL_IJFilter2)
                    End Select
                Case "Zone"
                    BTN_Detailed.Enabled = False
                    Select Case CMBX_IJSummaryRepoType.Text
                        Case "Items Distributed", "Items Received", "Item Consumed"
                            DataSourcer.AssignDataSource(GRPDatas.Zone, CMBX_IJFilter1, LBL_IJFilter1)
                            DataSourcer.AssignDataSource(GRPDatas.Naught, CMBX_IJFilter2, LBL_IJFilter2)
                        Case Else
                            DataSourcer.AssignDataSource(GRPDatas.Naught, CMBX_IJFilter1, LBL_IJFilter1)
                            DataSourcer.AssignDataSource(GRPDatas.Naught, CMBX_IJFilter2, LBL_IJFilter2)
                    End Select
                Case "Adjustment Reason"
                    BTN_Detailed.Enabled = False
                    Select Case CMBX_IJSummaryRepoType.Text
                        Case "Items Adjustment Plus"
                            DataSourcer.AssignDataSource(GRPDatas.InAdjReason, CMBX_IJFilter1, LBL_IJFilter1)
                            DataSourcer.AssignDataSource(GRPDatas.Naught, CMBX_IJFilter2, LBL_IJFilter2)
                        Case "Items Adjustment Minus"
                            DataSourcer.AssignDataSource(GRPDatas.OutAdjReason, CMBX_IJFilter1, LBL_IJFilter1)
                            DataSourcer.AssignDataSource(GRPDatas.Naught, CMBX_IJFilter2, LBL_IJFilter2)
                        Case Else
                            DataSourcer.AssignDataSource(GRPDatas.Naught, CMBX_IJFilter1, LBL_IJFilter1)
                            DataSourcer.AssignDataSource(GRPDatas.Naught, CMBX_IJFilter2, LBL_IJFilter2)
                    End Select
                Case "Discard Reason"
                    BTN_Detailed.Enabled = False
                    DataSourcer.AssignDataSource(GRPDatas.DiscardReason, CMBX_IJFilter1, LBL_IJFilter1)
                    DataSourcer.AssignDataSource(GRPDatas.Naught, CMBX_IJFilter2, LBL_IJFilter2)
                Case "Supplier"
                    BTN_Detailed.Enabled = True
                    DataSourcer.AssignDataSource(GRPDatas.Supplier, CMBX_IJFilter1, LBL_IJFilter1)
                    DataSourcer.AssignDataSource(GRPDatas.Naught, CMBX_IJFilter2, LBL_IJFilter2)
                Case "Payment Type"
                    BTN_Detailed.Enabled = True
                    DataSourcer.AssignDataSource(GRPDatas.PaymentType, CMBX_IJFilter1, LBL_IJFilter1)
                    DataSourcer.AssignDataSource(GRPDatas.Naught, CMBX_IJFilter2, LBL_IJFilter2)
                Case "Supply Period"
                    BTN_Detailed.Enabled = True
                    DataSourcer.AssignDataSource(GRPDatas.SupplyPeriod, CMBX_IJFilter1, LBL_IJFilter1)
                    DataSourcer.AssignDataSource(GRPDatas.Naught, CMBX_IJFilter2, LBL_IJFilter2)
                Case "Sick Institute"
                    BTN_Detailed.Enabled = True
                    DataSourcer.AssignDataSource(GRPDatas.Institute, CMBX_IJFilter1, LBL_IJFilter1)
                    DataSourcer.AssignDataSource(GRPDatas.Naught, CMBX_IJFilter2, LBL_IJFilter2)
                Case "Admin Zoba"
                    BTN_Detailed.Enabled = True
                    DataSourcer.AssignDataSource(GRPDatas.Zone, CMBX_IJFilter1, LBL_IJFilter1)
                    DataSourcer.AssignDataSource(GRPDatas.Naught, CMBX_IJFilter2, LBL_IJFilter2)
                Case "Ward"
                    DataSourcer.AssignDataSource(GRPDatas.Room, CMBX_IJFilter1, LBL_IJFilter1)
                Case Else
                    DataSourcer.AssignDataSource(GRPDatas.Naught, CMBX_IJFilter1, LBL_IJFilter1)
                    DataSourcer.AssignDataSource(GRPDatas.Naught, CMBX_IJFilter2, LBL_IJFilter2)
            End Select
        Else
            DataSourcer.AssignDataSource(GRPDatas.Naught, CMBX_IJFilter1, LBL_IJFilter1)
            DataSourcer.AssignDataSource(GRPDatas.Naught, CMBX_IJFilter2, LBL_IJFilter2)
        End If
    End Sub

    Private Sub CMBX_IJItemcategory_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBX_IJItemGB.SelectedIndexChanged
        If CMBX_IJItemGB.SelectedItem IsNot Nothing Then
            Dim LMISDb As New LMISEntities
            With CMBX_IJItemGBList
                Select Case CMBX_IJItemGB.Text
                    Case "Item Category"
                        LBL_IJItemGB.Text = "Item Category"
                        .DataSource = From IC In LMISDb.Categories Select IC.ID, IC.Name
                    Case "Item Classification"
                        LBL_IJItemGB.Text = "Item Classification"
                        .DataSource = From IC In LMISDb.Classifications Select IC.ID, IC.Name
                    Case "Item Sub-Classification"
                        LBL_IJItemGB.Text = "Item Sub-Classification"
                        .DataSource = From IC In LMISDb.InventoryCategories Select IC.ID, IC.Name
                End Select
                .DisplayMember = "Name"
                .ValueMember = "ID"
                .AutoCompleteSource = AutoCompleteSource.ListItems
                .SelectedItem = Nothing
            End With
        End If
    End Sub

    Private Sub DTP_IJTransaction_From_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DTP_IJSummary_From.ValueChanged
        DTP_IJSummary_To.MinDate = DTP_IJSummary_From.Value
    End Sub

    Private Sub DTP_IJTransaction_To_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DTP_IJSummary_To.ValueChanged
        DTP_IJSummary_From.MaxDate = DTP_IJSummary_To.Value
    End Sub

    Private Sub CHBX_IJAllGroupBy_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CHBX_IJAllGroupBy.CheckedChanged
        CMBX_IJGroupBy.SelectedItem = Nothing
        SetEnableControls({CMBX_IJGroupBy}, Not CHBX_IJAllGroupBy.Checked)
    End Sub

    Private Sub CHBX_IJAllDates_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CHBX_IJAllDates.CheckedChanged
        SetEnableControls({DTP_IJSummary_From, DTP_IJSummary_To}, Not CHBX_IJAllDates.Checked)
    End Sub

    Private Sub CHBX_IJAllItemNames_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CHBX_IJAllItemNames.CheckedChanged
        CMBX_IJItemName.SelectedItem = Nothing
        SetEnableControls({CMBX_IJItemName}, Not CHBX_IJAllItemNames.Checked)
        SetEnableControls({CHBX_IJAllItemGB}, CHBX_IJAllItemNames.Checked)
        CHBX_IJAllItemGB.Checked = True
        SetEnableControls({CMBX_IJItemGB, CMBX_IJItemGBList}, False)
    End Sub

    Private Sub CHBX_IJAllItemsGroupBys_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CHBX_IJAllItemGB.CheckedChanged
        CMBX_IJItemGB.SelectedItem = Nothing
        CMBX_IJItemGBList.SelectedItem = Nothing
        SetEnableControls({CMBX_IJItemGB, CMBX_IJItemGBList}, Not CHBX_IJAllItemGB.Checked)
    End Sub

    Private Sub CMBX_IJFilter1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBX_IJFilter1.TextChanged
        CMBX_IJFilter2.Enabled = IIf(CMBX_IJFilter1.SelectedItem Is Nothing, True, False)
        If CMBX_IJGroupBy.Text = "Item" Or CMBX_IJGroupBy.Text = "Date" Or CMBX_IJGroupBy.Text = "Month" Or CMBX_IJGroupBy.Text = "Year" Or CMBX_IJGroupBy.Text = "Sub Zone" Then
            CMBX_IJFilter2.Enabled = False
            CMBX_IJFilter1.Enabled = False
        End If
    End Sub

    Private Sub CMBX_IJFilter2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBX_IJFilter2.TextChanged
        CMBX_IJFilter1.Enabled = IIf(CMBX_IJFilter2.SelectedItem Is Nothing, True, False)
        If CMBX_IJGroupBy.Text = "Item" Or CMBX_IJGroupBy.Text = "Date" Or CMBX_IJGroupBy.Text = "Month" Or CMBX_IJGroupBy.Text = "Year" Or CMBX_IJGroupBy.Text = "Sub Zone" Then
            CMBX_IJFilter1.Enabled = False
            CMBX_IJFilter2.Enabled = False
        End If
    End Sub

#End Region

#Region "TB_Financial"

    Private Sub CMBX_FNSummaryRepoType_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBX_FNSummaryRepoType.TextChanged
        GBX_FN.Enabled = IIf(CMBX_FNSummaryRepoType.SelectedItem IsNot Nothing, True, False)
    End Sub

    Private Sub CMBX_FNSummaryRepoType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBX_FNSummaryRepoType.SelectedIndexChanged
        If CMBX_FNSummaryRepoType.SelectedItem IsNot Nothing Then
            GBX_FN.Enabled = True
            Select Case CMBX_FNSummaryRepoType.Text
                Case "Items Distributed"
                    CMBX_FNGroupBy.DataSource = {"Date", "Month", "Year", "Recipient", "Supply Period", "Facility Type", "Sub Zone", "Zone", "Category", "Classification", "Sub-Classification"}
                Case "Items Received"
                    CMBX_FNGroupBy.DataSource = {"Date", "Month", "Year", "supplier", "Facility Type", "Sub Zone", "Zone", "Category", "Classification", "Sub-Classification"}
                Case "Item Consumed"
                    CMBX_FNGroupBy.DataSource = {"Sub-Classification"}
                Case "GRV Items Received"
                    CMBX_FNGroupBy.DataSource = {"Date", "Month", "Year", "Supplier"}
                Case "Items Adjustment Plus", "Items Adjustment Minus"
                    CMBX_FNGroupBy.DataSource = {"Date", "Month", "Year", "Adjustment Reason"}
                Case "OPD Items Distributed", "IPD Items Distributed"
                    CMBX_FNGroupBy.DataSource = {"Date", "Month", "Year", "Payment Type", "Admin Zoba", "Sick Institute"}
            End Select
            CMBX_FNGroupBy.SelectedItem = Nothing
            DataSourcer.AssignDataSource(GRPDatas.Naught, CMBX_FNFilter1, LBL_FNFilter1)
            DataSourcer.AssignDataSource(GRPDatas.Naught, CMBX_FNFilter2, LBL_FNFilter2)
        Else
            GBX_FN.Enabled = False
        End If
    End Sub

    Private Sub CMBX_FNGroupBy_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBX_FNGroupBy.SelectedIndexChanged
        If CMBX_FNGroupBy.SelectedItem IsNot Nothing Then
            Select Case CMBX_FNGroupBy.Text
                Case "Item", "Date", "Month", "Year"
                    BTN_Detailed.Enabled = True
                    Select Case CMBX_FNSummaryRepoType.Text
                        Case "Items Distributed"
                            DataSourcer.AssignDataSource(GRPDatas.ToFacility, CMBX_FNFilter1, LBL_FNFilter1)
                            DataSourcer.AssignDataSource(GRPDatas.ToDepartment, CMBX_FNFilter2, LBL_FNFilter2)
                        Case "Items Received"
                            DataSourcer.AssignDataSource(GRPDatas.FromFacility, CMBX_FNFilter1, LBL_FNFilter1)
                            DataSourcer.AssignDataSource(GRPDatas.FromDepartment, CMBX_FNFilter2, LBL_FNFilter2)
                        Case "Item Consumed"
                            DataSourcer.AssignDataSource(GRPDatas.FromFacility, CMBX_FNFilter1, LBL_FNFilter1)
                            DataSourcer.AssignDataSource(GRPDatas.FromDepartment, CMBX_FNFilter2, LBL_FNFilter2)
                        Case "Items Adjustment Plus"
                            DataSourcer.AssignDataSource(GRPDatas.InAdjReason, CMBX_FNFilter1, LBL_FNFilter1)
                            DataSourcer.AssignDataSource(GRPDatas.Naught, CMBX_FNFilter2, LBL_FNFilter2)
                        Case "Items Adjustment Minus"
                            DataSourcer.AssignDataSource(GRPDatas.OutAdjReason, CMBX_FNFilter1, LBL_FNFilter1)
                            DataSourcer.AssignDataSource(GRPDatas.Naught, CMBX_FNFilter2, LBL_FNFilter2)
                        Case "Discarded Items"
                            DataSourcer.AssignDataSource(GRPDatas.DiscardReason, CMBX_IJFilter1, LBL_IJFilter1)
                            DataSourcer.AssignDataSource(GRPDatas.Naught, CMBX_IJFilter2, LBL_IJFilter2)
                        Case "OPD Items Distributed", "IPD Items Distributed"
                            DataSourcer.AssignDataSource(GRPDatas.Patient, CMBX_FNFilter1, LBL_FNFilter1)
                            DataSourcer.AssignDataSource(GRPDatas.Naught, CMBX_FNFilter2, LBL_FNFilter2)
                        Case Else
                            DataSourcer.AssignDataSource(GRPDatas.Naught, CMBX_FNFilter1, LBL_FNFilter1)
                            DataSourcer.AssignDataSource(GRPDatas.Naught, CMBX_FNFilter2, LBL_FNFilter2)
                    End Select
                Case "Patient"
                    BTN_Detailed.Enabled = True
                    Select Case CMBX_FNSummaryRepoType.Text
                        Case "OPD Items Distributed", "IPD Items Distributed"
                            DataSourcer.AssignDataSource(GRPDatas.Patient, CMBX_FNFilter1, LBL_FNFilter1)
                            DataSourcer.AssignDataSource(GRPDatas.Naught, CMBX_FNFilter2, LBL_FNFilter2)
                        Case Else
                            DataSourcer.AssignDataSource(GRPDatas.Naught, CMBX_FNFilter1, LBL_FNFilter1)
                            DataSourcer.AssignDataSource(GRPDatas.Naught, CMBX_FNFilter2, LBL_FNFilter2)
                    End Select
                Case "Department", "Recipient", "supplier"
                    BTN_Detailed.Enabled = True
                    Select Case CMBX_FNSummaryRepoType.Text
                        Case "Items Distributed"
                            DataSourcer.AssignDataSource(GRPDatas.ToDepartment, CMBX_FNFilter1, LBL_FNFilter1)
                            DataSourcer.AssignDataSource(GRPDatas.Naught, CMBX_FNFilter2, LBL_FNFilter2)
                        Case "Items Received"
                            DataSourcer.AssignDataSource(GRPDatas.FromDepartment, CMBX_FNFilter1, LBL_FNFilter1)
                            DataSourcer.AssignDataSource(GRPDatas.Naught, CMBX_FNFilter2, LBL_FNFilter2)
                        Case "Item Consumed"
                            DataSourcer.AssignDataSource(GRPDatas.FromDepartment, CMBX_FNFilter1, LBL_FNFilter1)
                            DataSourcer.AssignDataSource(GRPDatas.Naught, CMBX_FNFilter2, LBL_FNFilter2)
                        Case Else
                            DataSourcer.AssignDataSource(GRPDatas.Naught, CMBX_FNFilter1, LBL_FNFilter1)
                            DataSourcer.AssignDataSource(GRPDatas.Naught, CMBX_FNFilter2, LBL_FNFilter2)
                    End Select
                Case "Facility"
                    BTN_Detailed.Enabled = True
                    Select Case CMBX_FNSummaryRepoType.Text
                        Case "Items Distributed"
                            DataSourcer.AssignDataSource(GRPDatas.ToFacility, CMBX_FNFilter1, LBL_FNFilter1)
                            DataSourcer.AssignDataSource(GRPDatas.Naught, CMBX_FNFilter2, LBL_FNFilter2)
                        Case "Items Received"
                            DataSourcer.AssignDataSource(GRPDatas.FromFacility, CMBX_FNFilter1, LBL_FNFilter1)
                            DataSourcer.AssignDataSource(GRPDatas.Naught, CMBX_FNFilter2, LBL_FNFilter2)
                        Case "Item Consumed"
                            DataSourcer.AssignDataSource(GRPDatas.FromFacility, CMBX_FNFilter1, LBL_FNFilter1)
                            DataSourcer.AssignDataSource(GRPDatas.Naught, CMBX_FNFilter2, LBL_FNFilter2)
                        Case Else
                            DataSourcer.AssignDataSource(GRPDatas.Naught, CMBX_FNFilter1, LBL_FNFilter1)
                            DataSourcer.AssignDataSource(GRPDatas.Naught, CMBX_FNFilter2, LBL_FNFilter2)
                    End Select
                    'Case "Facility Type"
                    '    BTN_Detailed.Enabled = False
                    '    Select Case CMBX_FNSummaryRepoType.Text
                    '        Case "Items Distributed", "Items Received"
                    '            DataSourcer.AssignDataSource(GRPDatas.FacilityType, CMBX_FNFilter1, LBL_FNFilter1)
                    '            DataSourcer.AssignDataSource(GRPDatas.Naught, CMBX_FNFilter2, LBL_FNFilter2)
                    '        Case Else
                    '            DataSourcer.AssignDataSource(GRPDatas.Naught, CMBX_FNFilter1, LBL_FNFilter1)
                    '            DataSourcer.AssignDataSource(GRPDatas.Naught, CMBX_FNFilter2, LBL_FNFilter2)
                    '    End Select
                Case "Department Type", "Facility Type"
                    'BTN_Detailed.Enabled = False
                    Select Case CMBX_FNSummaryRepoType.Text
                        Case "Items Distributed", "Items Received", "Item Consumed"
                            DataSourcer.AssignDataSource(GRPDatas.DepartmentType, CMBX_FNFilter1, LBL_FNFilter1)
                            DataSourcer.AssignDataSource(GRPDatas.Naught, CMBX_FNFilter2, LBL_FNFilter2)
                        Case Else
                            DataSourcer.AssignDataSource(GRPDatas.Naught, CMBX_FNFilter1, LBL_FNFilter1)
                            DataSourcer.AssignDataSource(GRPDatas.Naught, CMBX_FNFilter2, LBL_FNFilter2)
                    End Select
                Case "Sub Zone"
                    BTN_Detailed.Enabled = False
                    Select Case CMBX_FNSummaryRepoType.Text
                        Case "Items Distributed", "Items Received", "Item Consumed"
                            DataSourcer.AssignDataSource(GRPDatas.Subzone, CMBX_FNFilter1, LBL_FNFilter1)
                            DataSourcer.AssignDataSource(GRPDatas.Naught, CMBX_FNFilter2, LBL_FNFilter2)
                        Case Else
                            DataSourcer.AssignDataSource(GRPDatas.Naught, CMBX_FNFilter1, LBL_FNFilter1)
                            DataSourcer.AssignDataSource(GRPDatas.Naught, CMBX_FNFilter2, LBL_FNFilter2)
                    End Select
                Case "Zone"
                    BTN_Detailed.Enabled = False
                    Select Case CMBX_FNSummaryRepoType.Text
                        Case "Items Distributed", "Items Received", "Item Consumed"
                            DataSourcer.AssignDataSource(GRPDatas.Zone, CMBX_FNFilter1, LBL_FNFilter1)
                            DataSourcer.AssignDataSource(GRPDatas.Naught, CMBX_FNFilter2, LBL_FNFilter2)
                        Case Else
                            DataSourcer.AssignDataSource(GRPDatas.Naught, CMBX_FNFilter1, LBL_FNFilter1)
                            DataSourcer.AssignDataSource(GRPDatas.Naught, CMBX_FNFilter2, LBL_FNFilter2)
                    End Select
                Case "Supplier"
                    BTN_Detailed.Enabled = True
                    DataSourcer.AssignDataSource(GRPDatas.Supplier, CMBX_FNFilter1, LBL_FNFilter1)
                    DataSourcer.AssignDataSource(GRPDatas.Naught, CMBX_FNFilter2, LBL_FNFilter2)
                Case "Payment Type"
                    BTN_Detailed.Enabled = True
                    DataSourcer.AssignDataSource(GRPDatas.PaymentType, CMBX_FNFilter1, LBL_FNFilter1)
                    DataSourcer.AssignDataSource(GRPDatas.Naught, CMBX_FNFilter2, LBL_FNFilter2)
                Case "Supply Period"
                    BTN_Detailed.Enabled = True
                    DataSourcer.AssignDataSource(GRPDatas.SupplyPeriod, CMBX_FNFilter1, LBL_FNFilter1)
                    DataSourcer.AssignDataSource(GRPDatas.Naught, CMBX_FNFilter2, LBL_FNFilter2)
                Case "Sick Institute"
                    BTN_Detailed.Enabled = True
                    DataSourcer.AssignDataSource(GRPDatas.Institute, CMBX_FNFilter1, LBL_FNFilter1)
                    DataSourcer.AssignDataSource(GRPDatas.Naught, CMBX_FNFilter2, LBL_FNFilter2)
                Case "Admin Zoba"
                    BTN_Detailed.Enabled = True
                    DataSourcer.AssignDataSource(GRPDatas.Zone, CMBX_FNFilter1, LBL_FNFilter1)
                    DataSourcer.AssignDataSource(GRPDatas.Naught, CMBX_FNFilter2, LBL_FNFilter2)
                Case "Category"
                    BTN_Detailed.Enabled = True
                    DataSourcer.AssignDataSource(GRPDatas.Category, CMBX_FNFilter1, LBL_FNFilter1)
                    DataSourcer.AssignDataSource(GRPDatas.Naught, CMBX_FNFilter2, LBL_FNFilter2)
                Case "Classification"
                    BTN_Detailed.Enabled = True
                    DataSourcer.AssignDataSource(GRPDatas.Classification, CMBX_FNFilter1, LBL_FNFilter1)
                    DataSourcer.AssignDataSource(GRPDatas.Naught, CMBX_FNFilter2, LBL_FNFilter2)
                Case "Sub-Classification"
                    BTN_Detailed.Enabled = True
                    DataSourcer.AssignDataSource(GRPDatas.Sub_Classificaton, CMBX_FNFilter1, LBL_FNFilter1)
                    DataSourcer.AssignDataSource(GRPDatas.Naught, CMBX_FNFilter2, LBL_FNFilter2)
                Case Else
                    DataSourcer.AssignDataSource(GRPDatas.Naught, CMBX_FNFilter1, LBL_FNFilter1)
                    DataSourcer.AssignDataSource(GRPDatas.Naught, CMBX_FNFilter2, LBL_FNFilter2)
            End Select
        Else
            DataSourcer.AssignDataSource(GRPDatas.Naught, CMBX_FNFilter1, LBL_FNFilter1)
            DataSourcer.AssignDataSource(GRPDatas.Naught, CMBX_FNFilter2, LBL_FNFilter2)
        End If
    End Sub

    Private Sub DTP_FNTransaction_From_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DTP_FNSummary_From.ValueChanged
        DTP_FNSummary_To.MinDate = DTP_FNSummary_From.Value
    End Sub

    Private Sub DTP_FNTransaction_To_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DTP_FNSummary_To.ValueChanged
        DTP_FNSummary_From.MaxDate = DTP_FNSummary_To.Value
    End Sub

    Private Sub CHBX_FNAllGroupBy_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CHBX_FNAllGroupBy.CheckedChanged
        CMBX_FNGroupBy.SelectedItem = Nothing
        SetEnableControls({CMBX_FNGroupBy}, Not CHBX_FNAllGroupBy.Checked)
    End Sub

    Private Sub CHBX_FNAllDates_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CHBX_FNAllDates.CheckedChanged
        SetEnableControls({DTP_FNSummary_From, DTP_FNSummary_To}, Not CHBX_FNAllDates.Checked)
    End Sub

    Private Sub CMBX_FNFilter1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBX_FNFilter1.TextChanged
        CMBX_FNFilter2.Enabled = IIf(CMBX_FNFilter1.SelectedItem Is Nothing, True, False)
    End Sub

    Private Sub CMBX_FNFilter2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBX_FNFilter2.TextChanged
        CMBX_FNFilter1.Enabled = IIf(CMBX_FNFilter2.SelectedItem Is Nothing, True, False)
    End Sub

#End Region

#Region "TB_Analysis"

    Private Sub CMBX_ANSummaryRepoType_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBX_ANSummaryRepoType.TextChanged
        GBX_AN.Enabled = IIf(CMBX_ANSummaryRepoType.SelectedItem IsNot Nothing, True, False)
    End Sub

    Private Sub CMBX_ANSummaryRepoType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBX_ANSummaryRepoType.SelectedIndexChanged
        If CMBX_ANSummaryRepoType.SelectedItem IsNot Nothing Then
            GBX_AN.Enabled = True
            Select Case CMBX_ANSummaryRepoType.Text
                Case "Receive", "Consumption by Facility", "Consumption Top Ten", "Distribution", "Lead Time"
                    DataSourcer.AssignDataSource(GRPDatas.Naught, CMBX_ANGroupBy, LBL_ANGroup)
                Case "ABC Analysis"
                    DataSourcer.AssignDataSource(GRPDatas.Category, CMBX_ANGroupBy, LBL_ANGroup)
                Case "Consumption by Classification"
                    DataSourcer.AssignDataSource(GRPDatas.Category, CMBX_ANGroupBy, LBL_ANGroup)
                Case "Consumption by Department Type"
                    DataSourcer.AssignDataSource(GRPDatas.DepartmentType, CMBX_ANGroupBy, LBL_ANGroup)
                Case "Consumption by Stock Items"
                    DataSourcer.AssignDataSource(GRPDatas.ToFacility, CMBX_ANGroupBy, LBL_ANGroup)
                Case "Consumption by Facility Detail", "Consumption by Facility Summary"
                    DataSourcer.AssignDataSource(GRPDatas.ToFacility, CMBX_ANGroupBy, LBL_ANGroup)
                Case "Consumption by Facility Type"
                    DataSourcer.AssignDataSource(GRPDatas.FacilityType, CMBX_ANGroupBy, LBL_ANGroup)
                Case "Distribution by Department Type"
                    DataSourcer.AssignDataSource(GRPDatas.DepartmentType, CMBX_ANGroupBy, LBL_ANGroup)
                Case "Stock Card Financial Summary"
                    DataSourcer.AssignDataSource(GRPDatas.DepartmentDescription, CMBX_ANGroupBy, LBL_ANGroup)
                Case "Request vs Receive", "Consumption vs Distribution", "Requisition vs Distribution"
                    CMBX_ANGroupBy.DataSource = {"Item", "Sub-Classification"}
            End Select
        Else
            GBX_AN.Enabled = False
        End If
    End Sub

    Private Sub DTP_ANTransaction_From_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DTP_ANSummary_From.ValueChanged
        DTP_ANSummary_To.MinDate = DTP_ANSummary_From.Value
    End Sub

    Private Sub DTP_ANTransaction_To_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DTP_ANSummary_To.ValueChanged
        DTP_ANSummary_From.MaxDate = DTP_ANSummary_To.Value
    End Sub

    Private Sub CHBX_ANAllDates_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CHBX_ANAllDates.CheckedChanged
        SetEnableControls({DTP_ANSummary_From, DTP_ANSummary_To}, Not CHBX_ANAllDates.Checked)
    End Sub

#End Region

#Region "TB_History"

    Private Sub DTP_H_From_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DTP_H_From.ValueChanged
        DTP_H_To.MinDate = DTP_H_From.Value
    End Sub

    Private Sub DTP_H_To_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DTP_H_To.ValueChanged
        DTP_H_From.MaxDate = DTP_H_To.Value
    End Sub

    Function ValidateHistory() As Boolean
        Dim NoError As Boolean = True
        If LBX_SearchResults.SelectedItem Is Nothing Then
            ERP_Error.SetError(LBX_SearchResults, "Select an appropriate Number from the list")
            NoError = False
        End If
        If CMBX_SearchBy.SelectedItem Is Nothing Then
            ERP_Error.SetError(CMBX_SearchBy, "Select an appropriate search by from the list")
            NoError = False
        End If
        If CMBX_TransactionType.SelectedItem Is Nothing Then
            ERP_Error.SetError(CMBX_TransactionType, "Select an appropriate transaction type from the list")
            NoError = False
        End If
        Return NoError
    End Function

    Private Sub Search()
        InSearchProcess = True
        'Try
        LBL_SearchResult.Text = "Searching .... "
        Dim ForDepartment As String = IIf(CHBX_ReportForDepa.Checked, FRM_GLBMain.ApplicationConfig.ThisDepartment.ID, CMBX_RepoForDepa.SelectedValue)
        Dim PrimaryIDF As String = "%"
        Dim ToFromFacility As String = "%%%%%%%"
        Dim IJTypeID As Integer
        Dim IJStatus As Integer = 2
        Select Case CMBX_TransactionType.Text
            Case "Supply Request"
                IJTypeID = 12
            Case "Supply Receive"
                IJTypeID = 2
            Case "Facility Request"
                IJTypeID = 14
                IJStatus = 1
            Case "Facility Invoice"
                IJTypeID = 15
            Case "Adjustment In"
                IJTypeID = 7
            Case "Adjustment Out"
                IJTypeID = 8
            Case "Adjustment Dicard"
                IJTypeID = 23
            Case "Adjustment Exchange"
                IJTypeID = 13
            Case "OPD"
                IJTypeID = 16
            Case "Satellite"
                IJTypeID = 18
            Case "GRV"
                IJTypeID = 20
            Case "Transfers"
                IJTypeID = 22
        End Select
        Select Case CMBX_SearchBy.Text
            Case "ID"
                If TBX_SearchTerm.Text <> String.Empty Then PrimaryIDF = "%" & TBX_SearchTerm.Text + "%"
            Case "Facility"
                If TBX_SearchTerm.SelectedItem IsNot Nothing Then ToFromFacility = TBX_SearchTerm.SelectedValue
        End Select
        Dim SearchResult = (From Res In (From Searcher In ((New LMISEntities).SP_IJSearch(
                                                        ForDepartment,
                                                         IJTypeID,
                                                         IJStatus,
                                                         PrimaryIDF,
                                                         DTP_H_From.Value.ToShortDateString,
                                                         DTP_H_To.Value.ToShortDateString,
                                                         "%", "%", "%", "%",
                                                         Not CHBX_HAllDates.Checked,
                                                         "%", "%", ToFromFacility, "%", "%", "%", "%", "%",
                                                         CHBX_Void.Checked))
                                Select Searcher.PrimaryID, Searcher.VoucherDate, Searcher.Department_Name Distinct)
                            Select New IDNdata(Res.PrimaryID, Res.PrimaryID & ": " & Res.VoucherDate & ", " & Res.Department_Name)).ToList
        LBX_SearchResults.DataSource = SearchResult
        LBX_SearchResults.ValueMember = "ID"
        LBX_SearchResults.DisplayMember = "Data"
        LBX_SearchResults.SelectedItem = Nothing
        LBL_SearchResult.Text = "Records found: " & SearchResult.Count
        'Catch ex As Exception
        '    MessageBox.Show("Error: In Searching" & vbCrLf & ex.Message & Utility.InnerExecption(ex), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        'End Try
        InSearchProcess = False
    End Sub

    Private Sub BTN_Search_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTN_Search.Click
        Search()
    End Sub

    Private Sub BTN_Void_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTN_Void.Click
        Try
            If Not ValidateHistory() Then Exit Sub
            'Using Transaction As New TransactionScope(TransactionScopeOption.Required)
            If MessageBox.Show("Are you sure you want to void this " & CMBX_TransactionType.Text & "?" & vbCrLf, "Are you sure?", System.Windows.Forms.MessageBoxButtons.YesNo, System.Windows.Forms.MessageBoxIcon.Information) = System.Windows.Forms.DialogResult.No Then Exit Sub
            Dim LMISDb As New LMISEntities
            Dim IJVoid As ObjectQuery(Of InventoryJournal) = Nothing
            Dim ID As String = LBX_SearchResults.SelectedValue
            Select Case CMBX_TransactionType.Text
                Case "Supply Request"
                    IJVoid = From IJ In LMISDb.Requests Where IJ.ID = ID Select IJ.InventoryJournal
                Case "Supply Receive"
                    IJVoid = From IJ In LMISDb.Recieves Where IJ.ID = ID Select IJ.InventoryJournal
                Case "Facility Request"
                    IJVoid = From IJ In LMISDb.Requisitions Where IJ.ID = ID Select IJ.InventoryJournal
                Case "Facility Invoice"
                    IJVoid = From IJ In LMISDb.Issues Where IJ.ID = ID Select IJ.InventoryJournal
                Case "Adjustment In", "Adjustment Out", "Adjustment Dicard", "Adjustment Exchange"
                    IJVoid = From IJ In LMISDb.Adjustments Where IJ.ID = ID Select IJ.InventoryJournal
                Case "OPD"
                    IJVoid = From IJ In LMISDb.OPDIssues Where IJ.ID = ID Select IJ.InventoryJournal
                Case "Satellite"
                    IJVoid = From IJ In LMISDb.IPDIssues Where IJ.ID = ID Select IJ.InventoryJournal
                Case "GRV"
                    IJVoid = From IJ In LMISDb.GRNs Where IJ.ID = ID Select IJ.InventoryJournal
                Case "Transfers"
                    IJVoid = (From IJ In LMISDb.Transfers Where IJ.ID = ID Select IJ.InventoryJournal).Union(From IJ In LMISDb.Transfers Where IJ.ID = TBX_SearchTerm.Text Select IJ.InventoryJournal1)
            End Select
            If IJVoid IsNot Nothing Then
                If IJVoid.Count > 0 Then
                    For Each IJ In IJVoid
                        IJ.Void = True
                    Next
                End If
            End If
            LMISDb.SaveChanges()
            Dim Commit As Boolean = True
            If IJVoid IsNot Nothing Then
                If IJVoid.Count > 0 Then
                    For Each IJ In IJVoid
                        For Each IJDet In IJ.InventoryJournalDetails
                            Dim IJDID As String = IJDet.ID
                            Dim IJDBData = From IJDB In LMISDb.InventoryJournalDetailsBatches
                                           Where IJDB.InventoryJournaDetaillID = IJDID
                                           Select IJDB

                            If IJDBData.Count > 0 Then
                                If Utility.Get_ItemQtyInBatchLocation(IJDBData.First.InventoryBatchID, IJDBData.First.LocationID) < 0 Then
                                    Commit = False
                                    MessageBox.Show("Operation could not be performed, because it will result in negative balance for Stock Item'" & IJDet.InventoryItem.ID & "', Stock Name '" & IJDet.InventoryItem.Name & "' in location '" & IJDBData.First.Location.Name & "'", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                    Exit For
                                End If
                            ElseIf Utility.Get_ItemQty(IJDet.ItemID) < 0 Then
                                Commit = False
                                MessageBox.Show("Operation could not be performed, because it will result in negative balance for Stock Item'" & IJDet.InventoryItem.ID & "', Stock Name '" & IJDet.InventoryItem.Name & "'", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                Exit For
                            End If
                            If Not Commit Then Exit For
                        Next
                    Next
                End If
            End If
            If IJVoid IsNot Nothing And Not Commit Then
                If IJVoid.Count > 0 Then
                    For Each IJ In IJVoid
                        IJ.Void = False
                    Next
                End If
            End If
            LMISDb.SaveChanges()
            Search()
            'If LMISDb.SaveChanges() > 0 Then
            '    LBX_SearchResults.DataSource = CType(LBX_SearchResults.DataSource, List(Of IDNdata)).Remove(LBX_SearchResults.SelectedItem)
            'End If
            'If Commit Then Transaction.Complete()
            'End Using
        Catch ex As Exception
            MessageBox.Show("Error: In Saving." & vbCrLf & ex.Message & Utility.InnerExecption(ex), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub CMBX_TransactionType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBX_TransactionType.SelectedIndexChanged
        If CMBX_TransactionType.SelectedItem IsNot Nothing Then
            Select Case CMBX_TransactionType.Text
                Case "Adjustment", "OPD", "Satellite", "GRV", "Transfers", "Adjustment In", "Adjustment Out", "Adjustment Dicard", "Adjustment Exchange"
                    CMBX_SearchBy.DataSource = {"ID"}
                Case "Supply Request", "Supply Receive", "Facility Request", "Facility Invoice"
                    CMBX_SearchBy.DataSource = {"ID", "Facility"}
            End Select
        End If        
    End Sub


    Private Sub CMBX_SearchBy_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBX_SearchBy.SelectedIndexChanged
        If CMBX_SearchBy.SelectedItem IsNot Nothing Then
            Select Case CMBX_TransactionType.Text
                Case "Adjustment", "OPD", "Satellite", "GRV", "Transfers", "Adjustment In", "Adjustment Out", "Adjustment Dicard", "Adjustment Exchange"
                    TBX_SearchTerm.DataSource = Nothing
                Case "Supply Request", "Supply Receive", "Facility Request", "Facility Invoice"
                    Select Case CMBX_TransactionType.Text
                        Case "Supply Request", "Supply Receive"
                            DataSourcer.AssignDataSource(GRPDatas.FromDepartment, TBX_SearchTerm, LBL_SearchTerm)
                        Case "Facility Request", "Facility Invoice"
                            DataSourcer.AssignDataSource(GRPDatas.ToDepartment, TBX_SearchTerm, LBL_SearchTerm)
                    End Select
            End Select
            LBX_SearchResults.DataSource = Nothing
        Else
            TBX_SearchTerm.DataSource = Nothing
        End If
    End Sub

    Private Sub CHBX_Void_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CHBX_Void.CheckedChanged
        BTN_Void.Enabled = Not CHBX_Void.Checked
    End Sub

    Private Sub LBX_SearchResults_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LBX_SearchResults.SelectedIndexChanged
        If Not InSearchProcess And LBX_SearchResults.SelectedItem IsNot Nothing And LBX_SearchResults.ValueMember <> String.Empty Then
            Dim ReportType As ReportTypes
            Dim ReportParameter As New Dictionary(Of String, String())
            If Not ValidateHistory() Then Exit Sub
            Select Case CMBX_TransactionType.Text
                Case "Supply Request"
                    ReportParameter.Add("ID", {LBX_SearchResults.SelectedValue})
                    ReportType = ReportTypes.IJRequestOnly
                Case "Supply Receive"
                    ReportParameter.Add("ID", {LBX_SearchResults.SelectedValue})
                    ReportType = ReportTypes.IJReceive
                Case "Facility Request"
                    ReportParameter.Add("ID", {LBX_SearchResults.SelectedValue})
                    ReportType = ReportTypes.IJRequestDetails
                    'ERP_Error.SetError(LBX_SearchResults, "No such report")
                    'Exit Sub
                Case "Facility Invoice"
                    ReportParameter.Add("ID", {LBX_SearchResults.SelectedValue})
                    ReportType = ReportTypes.IJInvoice
                Case "Adjustment In", "Adjustment Out", "Adjustment Dicard"
                    ReportParameter.Add("ID", {LBX_SearchResults.SelectedValue})
                    ReportType = ReportTypes.IJAdjustment
                Case "Adjustment Exchange"
                    ReportParameter.Add("@ExchangeID", {LBX_SearchResults.SelectedValue})
                    ReportType = ReportTypes.IJExchange
                Case "OPD"
                    ReportParameter.Add("@OPDIssueID", {LBX_SearchResults.SelectedValue})
                    ReportParameter.Add("Title", {FRM_GLBMain.ApplicationConfig.ThisDepartment.Name})
                    ReportType = ReportTypes.IJOPD
                Case "Satellite"
                    ReportParameter.Add("@IPDIssueID", {LBX_SearchResults.SelectedValue})
                    ReportParameter.Add("Title", {FRM_GLBMain.ApplicationConfig.ThisDepartment.Name})
                    ReportType = ReportTypes.IJIPD
                Case "GRV"
                    ReportParameter.Add("ID", {LBX_SearchResults.SelectedValue})
                    ReportType = ReportTypes.IJGRN
                Case "Transfers"
                    ReportParameter.Add("ID", {LBX_SearchResults.SelectedValue})
                    ReportType = ReportTypes.IJTransfer
            End Select
            ShowReport(ReportType, ReportParameter)
        Else
            CVWR_Reporter.ReportSource = Nothing
        End If
    End Sub

#End Region

#Region "TB_SD"
    Private Sub DTP_SD_From_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DTP_SD_From.ValueChanged
        DTP_SD_To.MinDate = DTP_SD_From.Value
    End Sub

    Private Sub DTP_SD_To_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DTP_SD_To.ValueChanged
        DTP_SD_From.MaxDate = DTP_SD_To.Value
    End Sub

    Private Sub CMBX_SDRepoType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBX_SDRepoType.SelectedIndexChanged
        If CMBX_SDRepoType.SelectedItem IsNot Nothing Then
            If CMBX_SDRepoType.Text = "Employee Transactions" Or CMBX_SDRepoType.Text = "OPD Patient visit frequency" Then
                DTP_SD_From.Enabled = True
                DTP_SD_To.Enabled = True
                CMBX_SDSearchBy.Enabled = False
                CHBX_SDSearchAll.Enabled = False
            ElseIf CMBX_SDRepoType.Text = "Facilities" Then
                DTP_SD_From.Enabled = False
                DTP_SD_To.Enabled = False
                CMBX_SDSearchBy.Enabled = True
                CHBX_SDSearchAll.Enabled = True
                With CMBX_SDSearchBy
                    .DataSource = From Facis In (New LMISEntities).Facilities Select Facis
                    .DisplayMember = "FacilityName"
                    .ValueMember = "ID"
                    .SelectedItem = Nothing
                End With
            Else
                DTP_SD_From.Enabled = False
                DTP_SD_To.Enabled = False
                CMBX_SDSearchBy.Enabled = False
                CHBX_SDSearchAll.Enabled = False
            End If
        Else
            DTP_SD_From.Enabled = False
            DTP_SD_To.Enabled = False
            CMBX_SDSearchBy.Enabled = False
            CHBX_SDSearchAll.Enabled = False
        End If
    End Sub

    Private Sub CMBX_SDSearchAll_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CHBX_SDSearchAll.CheckedChanged
        CMBX_SDSearchBy.Enabled = Not CHBX_SDSearchAll.Checked
    End Sub

#End Region

#End Region

End Class

Public Class DataSourcer

    Shared Sub AssignDataSource(ByVal GRPData As GRPDatas, ByVal CMBX_Data As ComboBox, ByVal LBL As Label)
        With CMBX_Data
            .Enabled = True
            Select Case GRPData
                Case GRPDatas.ToFacility
                    LBL.Text = "To Facility"
                    Dim MyDepartment = FRM_GLBMain.ApplicationConfig.ThisDepartment
                    .DataSource = (From F In (New LMISEntities).Departments
                              Where F.Active = False And
                              (
                                  (MyDepartment.DepartmentType.Description = "Level 2" And ((F.DepartmentType.Description = "Level 2" Or F.DepartmentType.Description = "Level 3" Or (F.DepartmentType.Description = "Level 4" And MyDepartment.FacilityID = F.FacilityID))) And F.Facility.FacilityType.Description <> "Private") Or
                                  (MyDepartment.DepartmentType.Description = "Level 1" And (F.DepartmentType.Description = "Level 2" Or F.DepartmentType.Description = "Level 5"))
                              ) Select F.Facility Distinct)
                    .DisplayMember = "FacilityName"
                    .ValueMember = "ID"
                Case GRPDatas.FromFacility
                    LBL.Text = "From Facility"
                    Dim MyDepartment = FRM_GLBMain.ApplicationConfig.ThisDepartment
                    .DataSource = (From F In (New LMISEntities).Departments
                              Where F.Active = False And
                                 (MyDepartment.DepartmentType.Description = "Level 4" And (F.DepartmentType.Description = "Level 2" And MyDepartment.FacilityID = F.FacilityID)) Or
                                 (MyDepartment.DepartmentType.Description = "Level 4I" And (F.DepartmentType.Description = "Level 2" And MyDepartment.FacilityID = F.FacilityID)) Or
                                 (MyDepartment.DepartmentType.Description = "Level 4O" And (F.DepartmentType.Description = "Level 2" And MyDepartment.FacilityID = F.FacilityID)) Or
                                 (MyDepartment.DepartmentType.Description = "Level 3" And (F.DepartmentType.Description = "Level 2" Or (F.DepartmentType.Description = "Level 3" And MyDepartment.FacilityID = F.FacilityID))) Or
                                 (MyDepartment.DepartmentType.Description = "Level 2" And (F.DepartmentType.Description = "Level 3" Or F.DepartmentType.Description = "Level 2" Or F.DepartmentType.Description = "Level 1"))
                              Select F.Facility Distinct)
                    .DisplayMember = "FacilityName"
                    .ValueMember = "ID"
                Case GRPDatas.ToDepartment
                    LBL.Text = "Recipient"
                    Dim MyDepartment = FRM_GLBMain.ApplicationConfig.ThisDepartment
                    .DataSource = From F In (New LMISEntities).Departments
                              Where F.Active = False And
                              (
                                 ((F.DepartmentType.Description = "Level 4" And MyDepartment.FacilityID = F.FacilityID)) Or
                                 ((F.DepartmentType.Description = "Level 4O" And MyDepartment.FacilityID = F.FacilityID)) Or
                                 ((F.DepartmentType.Description = "Level 4I" And MyDepartment.FacilityID = F.FacilityID)) Or
                                 ((F.DepartmentType.Description = "Level 4N" And MyDepartment.FacilityID = F.FacilityID)) Or
                                 ((F.DepartmentType.Description = "Level 5" And MyDepartment.FacilityID = F.FacilityID)) Or
                                 ((F.DepartmentType.Description = "Level 3" And MyDepartment.FacilityID = F.FacilityID)) Or
                                 (MyDepartment.DepartmentType.Description = "Level 2" And ((F.DepartmentType.Description = "Level 2" Or F.DepartmentType.Description = "Level 3" Or (F.DepartmentType.Description = "Level 4" And MyDepartment.FacilityID = F.FacilityID))) And F.Facility.FacilityType.Description <> "Private") Or
                                 (MyDepartment.DepartmentType.Description = "Level 1" And (F.DepartmentType.Description = "Level 2" Or F.DepartmentType.Description = "Level 5"))
                              ) Select F Order By F.Name
                    .DisplayMember = "Name"
                    .ValueMember = "ID"
                Case GRPDatas.FromDepartment
                    LBL.Text = "Supplier"
                    Dim MyDepartment = FRM_GLBMain.ApplicationConfig.ThisDepartment
                    .DataSource = From F In (New LMISEntities).Departments
                              Where F.Active = False And
                                 (MyDepartment.DepartmentType.Description = "Level 4" And (F.DepartmentType.Description = "Level 2" And MyDepartment.FacilityID = F.FacilityID)) Or
                                 (MyDepartment.DepartmentType.Description = "Level 4I" And (F.DepartmentType.Description = "Level 2" And MyDepartment.FacilityID = F.FacilityID)) Or
                                 (MyDepartment.DepartmentType.Description = "Level 4O" And (F.DepartmentType.Description = "Level 2" And MyDepartment.FacilityID = F.FacilityID)) Or
                                 (MyDepartment.DepartmentType.Description = "Level 3" And (F.DepartmentType.Description = "Level 2" Or (F.DepartmentType.Description = "Level 3" And MyDepartment.FacilityID = F.FacilityID))) Or
                                 (MyDepartment.DepartmentType.Description = "Level 2" And (F.DepartmentType.Description = "Level 3" Or F.DepartmentType.Description = "Level 2" Or F.DepartmentType.Description = "Level 1"))
                              Select F Order By F.DepartmentTypeID
                    .DisplayMember = "Name"
                    .ValueMember = "ID"
                Case GRPDatas.FacilityType
                    LBL.Text = "Facility Type"
                    .DataSource = (From A In (New LMISEntities).FacilityTypes Select A)
                    .DisplayMember = "RoomNo"
                    .ValueMember = "ID"
                Case GRPDatas.Room
                    LBL.Text = "Facility Type"
                    .DataSource = (From A In (New LMISEntities).Rooms Select A.ID, A.RoomNo)
                    .DisplayMember = "RoomNo"
                    .ValueMember = "ID"
                Case GRPDatas.OutAdjReason
                    LBL.Text = "Adjustment Reason"
                    .DataSource = (From A In (New LMISEntities).AdjustmentTypes Select A Where A.Type = "Out" And A.Active = True)
                    .DisplayMember = "Description"
                    .ValueMember = "ID"
                Case GRPDatas.InAdjReason
                    LBL.Text = "Adjustment Reason"
                    .DataSource = (From A In (New LMISEntities).AdjustmentTypes Select A Where A.Type = "In" And A.Active = True)
                    .DisplayMember = "Description"
                    .ValueMember = "ID"
                Case GRPDatas.DiscardReason
                    LBL.Text = "Discard Reason"
                    .DataSource = (From A In (New LMISEntities).AdjustmentTypes Select A Where A.Type = "Discard" And A.Active = True)
                    .DisplayMember = "Description"
                    .ValueMember = "ID"
                Case GRPDatas.Patient
                    Dim PeopleDetails As New List(Of IDNdata)
                    For Each Person In From P In (New LMISEntities).People Select P Where P.PersonStatusID = 1 Order By P.PersonName.Name
                        Dim Data As String = Person.PersonName.Name & " " & Person.PersonName1.Name & " "
                        If Person.PersonName2 IsNot Nothing Then Data = Data & " " & Person.PersonName2.Name
                        Data = Data & ", " & Person.IDNO
                        PeopleDetails.Add(New IDNdata(Person.ID, Data, True))
                    Next
                    .DisplayMember = "Data"
                    .ValueMember = "ID"
                    .DataSource = PeopleDetails
                Case GRPDatas.Subzone
                    LBL.Text = "To Subzone"
                    Dim SubZonas As New List(Of IDNdata)
                    For Each Subzone In (From P In (New LMISEntities).SubZones Select P Order By P.ZoneID)
                        SubZonas.Add(New IDNdata(Subzone.SubZoneID, Subzone.Zone.ZoneName & " " & Subzone.SubZoneName, True))
                    Next
                    .DataSource = SubZonas
                    .DisplayMember = "Data"
                    .ValueMember = "ID"
                    .Enabled = True
                Case GRPDatas.Zone
                    LBL.Text = "To Zone"
                    .DataSource = From P In (New LMISEntities).Zones Select P
                    .DisplayMember = "ZoneName"
                    .ValueMember = "ZoneID"
                Case GRPDatas.Category
                    LBL.Text = "Category"
                    .DataSource = From P In (New LMISEntities).Categories Select P.ID, P.Name
                    .DisplayMember = "Name"
                    .ValueMember = "ID"
                Case GRPDatas.Classification
                    LBL.Text = "Category"
                    .DataSource = From P In (New LMISEntities).Classifications Select P.ID, P.Name
                    .DisplayMember = "Name"
                    .ValueMember = "ID"
                Case GRPDatas.Sub_Classificaton
                    LBL.Text = "Sub-Classification"
                    .DataSource = From P In (New LMISEntities).InventoryCategories Select P.ID, P.Name
                    .DisplayMember = "Name"
                    .ValueMember = "ID"
                Case GRPDatas.DepartmentType
                    LBL.Text = "Facility Type"
                    .DataSource = (From P In (New LMISEntities).DepartmentTypes Select P.ID, P.Type Distinct)
                    .DisplayMember = "Type"
                    .ValueMember = "ID"
                Case GRPDatas.DepartmentDescription
                    LBL.Text = "Facility Description"
                    .DataSource = (From P In (New LMISEntities).DepartmentTypes Select P.ID, P.Type Distinct)
                    .DisplayMember = "Description"
                    .ValueMember = "ID"
                Case GRPDatas.Supplier
                    LBL.Text = "Supplier"
                    .DataSource = (From P In (New LMISEntities).Suppliers Select P.ID, P.Company.Name Distinct)
                    .DisplayMember = "Name"
                    .ValueMember = "ID"
                Case GRPDatas.PaymentType
                    LBL.Text = "Payment Type"
                    .DataSource = (From P In (New LMISEntities).PaymentTypes Select P.ID, P.Type Distinct)
                    .DisplayMember = "Type"
                    .ValueMember = "ID"
                Case GRPDatas.Institute
                    LBL.Text = "Institute"
                    .DataSource = (From P In (New LMISEntities).Companies Select P.ID, P.Name Distinct)
                    .DisplayMember = "Name"
                    .ValueMember = "ID"
                Case GRPDatas.SupplyPeriod
                    LBL.Text = "Supply Period"
                    .DataSource = (From P In (New LMISEntities).SupplyPeriods Select P.ID, P.Period)
                    .DisplayMember = "Period"
                    .ValueMember = "ID"
                Case GRPDatas.Naught
                    LBL.Text = String.Empty
                    .DataSource = Nothing
                    .Enabled = False
                Case Else
                    LBL.Text = String.Empty
                    .DataSource = Nothing
                    .Enabled = False
            End Select
            .AutoCompleteSource = AutoCompleteSource.ListItems
            .SelectedItem = Nothing
        End With
    End Sub

End Class

Public Enum GRPDatas
    ToDepartment
    ToFacility
    FromFacility
    FromDepartment
    InAdjReason
    OutAdjReason
    DiscardReason
    FacilityType
    Room
    Person
    Patient
    Subzone
    Zone
    Naught
    Category
    Classification
    Sub_Classificaton
    DepartmentDescription
    DepartmentType
    Supplier
    PaymentType
    Institute
    SupplyPeriod
End Enum