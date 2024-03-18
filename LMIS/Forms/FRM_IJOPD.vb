Imports System.Data.Objects
Imports System.Transactions
Public Class FRM_IJOPD

#Region "declarations"
    Private FRMMode As FRMModes = FRMModes.AddNew

    Public Sub New()
        InitializeComponent()
        Me.MdiParent = FRM_GLBMain
        DTP_VoucherDate.MaxDate = Date.Today
    End Sub

    Public Overloads Sub Show(ByVal Mode As FRMModes)
        FRMMode = Mode
        If FRMMode.Equals(FRMModes.AddNew) Then
            Me.Text = "OPD Invoice"
            LBL_Title.Text = "OPD Invoice"
            CMBX_OPDIssueID.Text = Utility.GenerateID(IDTypes.Requisition)
            CMBX_OPDIssueID.Enabled = False
            CMBX_CardNo .Enabled =False 
        Else
            Me.Text = "Edit Existing OPD Invoice"
            LBL_Title.Text = "Edit Existing OPD Invoice"
            CMBX_OPDIssueID.Enabled = True
            CMBX_CardNo.Enabled = True
        End If
        Me.Show()
    End Sub

#End Region

#Region "Utilities"

    Sub LoadForm()
        ' Try
        Dim LMISDb As New LMISEntities
        With CMBX_OPDIssueID
            .DataSource = From O In LMISDb.OPDRequisitions Where O.InventoryJournal.InventoryJournalStatu.Name = "Pending" Select O.ID
            .AutoCompleteSource = AutoCompleteSource.ListItems
            .SelectedItem = Nothing
        End With

        Dim Cards = From O In LMISDb.OPDRequisitions Where O.InventoryJournal.InventoryJournalStatu.Name = "Pending" Select O.ID, O.Person, O.CardNo
        Dim CardNos As New List(Of IDNdata)
        For Each Card In Cards
            Dim Data As String = Card.CardNo & ", " & Card.Person.PersonName.Name & " " & Card.Person.PersonName1.Name & " "
            If Card.Person.PersonName2 IsNot Nothing Then Data = Data & " " & Card.Person.PersonName2.Name
            CardNos.Add(New IDNdata(Card.ID, Data, True))
        Next
        With CMBX_CardNo
            .DataSource = CardNos
            .DisplayMember = "Data"
            .ValueMember = "ID"
            .AutoCompleteSource = AutoCompleteSource.ListItems
            .SelectedItem = Nothing
        End With

        Dim People = From P In LMISDb.People Select P Where P.PersonStatusID = 1 Order By P.IDNO
        Dim PeopleDetails As New List(Of IDNdata)
        With CMBX_IDNO
            .DataSource = People
            .DisplayMember = "IDNO"
            .ValueMember = "ID"
            .AutoCompleteSource = AutoCompleteSource.ListItems
            .SelectedItem = Nothing
        End With
        For Each Person In People
            Dim Data As String = Person.PersonName.Name & " " & Person.PersonName1.Name & " "
            If Person.PersonName2 IsNot Nothing Then Data = Data & " " & Person.PersonName2.Name
            PeopleDetails.Add(New IDNdata(Person.ID, Data, True))
        Next

        With CMBX_Name
            .DataSource = PeopleDetails
            .DisplayMember = "Data"
            .ValueMember = "ID"
            .AutoCompleteSource = AutoCompleteSource.ListItems
            .SelectedItem = Nothing
        End With
        With CMBX_PaymentType
            .DataSource = From S In LMISDb.PaymentTypes Select S Where S.InventoryJournalTypeID = 16
            .DisplayMember = "Type"
            .ValueMember = "ID"
            .AutoCompleteSource = AutoCompleteSource.ListItems
            .SelectedItem = Nothing
        End With

        Dim EmployeesDetails1 As New List(Of IDNdata)
        For Each Employee In From E In LMISDb.Employees Where E.DepartmentID = FRM_GLBMain.ApplicationConfig.ThisDepartment.ID And E.EmployeeStatu.Status = "Active" Select E.ID, FName = E.Person.PersonName.Name, SName = E.Person.PersonName1.Name, LName = E.Person.PersonName2.Name, E.Person.IDNO, E.Person.PhoneNo
            EmployeesDetails1.Add(New IDNdata(Employee.ID, Employee.FName & " " & Employee.SName & " " & Employee.LName & " " & Employee.IDNO & ", " & Employee.PhoneNo, True))
        Next
        With CMBX_Prescribedby
            .DataSource = EmployeesDetails1
            .DisplayMember = "Data"
            .ValueMember = "ID"
            .AutoCompleteSource = AutoCompleteSource.ListItems
            .SelectedItem = Nothing
        End With
        Dim EmployeesDetails2 As New List(Of IDNdata)
        For Each Employee In From E In LMISDb.Employees Where E.DepartmentID = FRM_GLBMain.ApplicationConfig.ThisDepartment.ID And E.EmployeeStatu.Status = "Active" Select E.ID, FName = E.Person.PersonName.Name, SName = E.Person.PersonName1.Name, LName = E.Person.PersonName2.Name, E.Person.IDNO, E.Person.PhoneNo
            EmployeesDetails2.Add(New IDNdata(Employee.ID, Employee.FName & " " & Employee.SName & " " & Employee.LName & " " & Employee.IDNO & ", " & Employee.PhoneNo, True))
        Next
        With CMBX_DispersedBy
            .DataSource = EmployeesDetails2
            .DisplayMember = "Data"
            .ValueMember = "ID"
            .AutoCompleteSource = AutoCompleteSource.ListItems
            .SelectedItem = Nothing
        End With
        CMBX_Country.DataSource = From C In LMISDb.Countries Select C
        CMBX_Country.DisplayMember = "Name"
        CMBX_Country.ValueMember = "ID"
        CMBX_Country.AutoCompleteSource = AutoCompleteSource.ListItems
        CMBX_Country.SelectedValue = 39

        CMBX_Company.DataSource = From N In LMISDb.Companies Select N
        CMBX_Company.DisplayMember = "Name"
        CMBX_Company.ValueMember = "ID"
        CMBX_Company.AutoCompleteSource = AutoCompleteSource.ListItems
        CMBX_Company.SelectedItem = Nothing

        'AddHandler CMBX_CardNo.SelectedIndexChanged, AddressOf CMBX_CardNo_SelectedIndexChanged
        'Catch ex As Exception
        'MessageBox.Show("Error: In Loading Requisitions" & vbCrLf & ex.Message & Utility.InnerExecption(ex), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        'End Try
    End Sub

    Function SaveData(ByVal SaveStatus As Int16) As Boolean
        For Each ItemRow As DataGridViewRow In DGV_Items.Rows
            Try
                Dim expDate As Date = ItemRow.Cells("Expiry_Date").Value
                If expDate < Today And expDate <> "12:00:00 AM" Then
                    MsgBox("The list contains expired items please remove them first")
                    Return False
                End If
            Catch ex As Exception
            End Try
        Next
        Try
            Using Transaction As New TransactionScope(TransactionScopeOption.RequiresNew)
                Dim LMISDb As New LMISEntities
                Dim OPDIssID As String = Nothing
                Dim SaveIJType As Integer = 17            'OPD Issue
                If SaveStatus = 2 Then SaveIJType = 16 'OPD Requisition
                Select Case FRMMode
                    Case FRMModes.AddNew
                        Dim NewIssIJ As New InventoryJournal With {
                            .ID = Utility.GenerateID(IDTypes.IJ),
                            .DepartmentID = FRM_GLBMain.ApplicationConfig.ThisDepartment.ID,
                            .VoucherDate = DTP_VoucherDate.Value,
                            .TransactionDate = Date.Today,
                            .Remark = TBX_Remark.Text,
                            .InventoryJournalTypeID = SaveIJType,
                            .EmployeeID = FRM_GLBMain.ApplicationConfig.Employee.ID,
                            .Void = False,
                            .InventoryJournalStatusID = SaveStatus}
                        LMISDb.InventoryJournals.AddObject(NewIssIJ)
                        LMISDb.SaveChanges()
                        If SaveStatus = 1 Then OPDIssID = NewIssIJ.ID
                        CMBX_OPDIssueID.Text = Utility.GenerateID(IDTypes.OPDRequisition)
                        Dim NewOPDReq As New OPDRequisition With {
                            .ID = CMBX_OPDIssueID.Text,
                            .InvetoryJournalID = OPDIssID,
                            .PersonID = SavePerson(),
                            .PaymentTypeID = CMBX_PaymentType.SelectedValue,
                            .DispensedBy = CMBX_DispersedBy.SelectedValue,
                            .PrescribedBy = CMBX_Prescribedby.SelectedValue,
                            .CardNo = TBX_CardNo.Text}
                        LMISDb.OPDRequisitions.AddObject(NewOPDReq)
                        LMISDb.SaveChanges()
                        SavePayment(LMISDb, CMBX_OPDIssueID.Text)
                        If SaveStatus = 2 Then      'if for processed
                            Dim NewOPDIssue As New OPDIssue With {
                                 .ID = Utility.GenerateID(IDTypes.OPDIssue),
                                 .OPDRequisitionID = NewOPDReq.ID,
                                 .InvetoryJournalID = NewIssIJ.ID}
                            Dim OPDReq = (From O In LMISDb.OPDRequisitions Where O.ID = CMBX_OPDIssueID.Text Select O).Single
                            OPDReq.InvetoryJournalID = Nothing
                            LMISDb.OPDIssues.AddObject(NewOPDIssue)
                            LMISDb.SaveChanges()
                        End If
                        For Each ItemRow As DataGridViewRow In DGV_Items.Rows
                            If Not ItemRow.IsNewRow Then
                                Dim NewIJDetailOPDIssID As New InventoryJournalDetail With {
                                    .ItemID = ItemRow.Cells("ItemID").Value,
                                    .Quantity = ItemRow.Cells("Qty").Value,
                                    .InventoryJournalID = NewIssIJ.ID,
                                    .Remark = ItemRow.Cells("Remark").Value}
                                LMISDb.InventoryJournalDetails.AddObject(NewIJDetailOPDIssID)
                                LMISDb.SaveChanges()
                                Dim NewIJDetailsBatch As New InventoryJournalDetailsBatch With {
                                    .InventoryBatchID = ItemRow.Cells("Batch").Value,
                                    .Price = ItemRow.Cells("Cost").Value,
                                    .LocationID = CType(ItemRow.Cells("Batch_Location"), ComboCell).BatchLocationID,
                                    .InventoryJournaDetaillID = NewIJDetailOPDIssID.ID}
                                LMISDb.InventoryJournalDetailsBatches.AddObject(NewIJDetailsBatch)
                                LMISDb.SaveChanges()
                            End If
                        Next
                        Transaction.Complete()
                        Return True
                    Case FRMModes.EditExisting
                        Dim OPDReqIJ = (From O In LMISDb.OPDRequisitions Where O.ID = CMBX_OPDIssueID.Text Select O.InventoryJournal).Single
                        Dim OPDReq = (From O In LMISDb.OPDRequisitions Where O.ID = CMBX_OPDIssueID.Text Select O).Single
                        OPDReqIJ.Remark = TBX_Remark.Text
                        OPDReqIJ.VoucherDate = DTP_VoucherDate.Value
                        OPDReqIJ.InventoryJournalTypeID = SaveStatus
                        OPDReq.PersonID = SavePerson()
                        OPDReq.PaymentTypeID = CMBX_PaymentType.SelectedValue
                        OPDReq.PrescribedBy = CMBX_Prescribedby.SelectedValue
                        OPDReq.DispensedBy = CMBX_DispersedBy.SelectedValue
                        OPDReq.CardNo = TBX_CardNo.Text
                        SavePayment(LMISDb, CMBX_OPDIssueID.Text)
                        If SaveStatus = 2 Then      'if for processed
                            If SaveStatus = 2 Then      'if for processed
                                Dim NewOPDIssue As New OPDIssue With {
                                     .ID = Utility.GenerateID(IDTypes.OPDIssue),
                                     .OPDRequisitionID = OPDReq.ID,
                                     .InvetoryJournalID = OPDReqIJ.ID}
                                LMISDb.OPDIssues.AddObject(NewOPDIssue)
                            End If
                            OPDReq.InvetoryJournalID = Nothing
                            OPDReqIJ.InventoryJournalTypeID = 16 ' switch the ipdreq to ipdiss
                        End If
                        LMISDb.SaveChanges()
                        Dim IJDDelete = From IJD In LMISDb.InventoryJournalDetails
                                            Where IJD.InventoryJournalID = OPDReqIJ.ID
                                            Select IJD
                        For Each IJDRow As InventoryJournalDetail In IJDDelete
                            Dim IJDDeleteID As String = IJDRow.ID
                            Dim IJDBDelete = From IJDB In LMISDb.InventoryJournalDetailsBatches
                                        Where IJDB.InventoryJournaDetaillID = IJDDeleteID
                                        Select IJDB

                            If IJDBDelete.Count > 0 Then LMISDb.InventoryJournalDetailsBatches.DeleteObject(IJDBDelete.First)
                        Next
                        LMISDb.SaveChanges()
                        For Each IJDRow As InventoryJournalDetail In IJDDelete
                            LMISDb.InventoryJournalDetails.DeleteObject(IJDRow)
                        Next
                        LMISDb.SaveChanges()
                        Dim EnteredItemIDs As New List(Of String)
                        For Each ItemRow As DataGridViewRow In DGV_Items.Rows
                            If Not ItemRow.IsNewRow Then
                                Dim NewIJDetailOPDIssID As New InventoryJournalDetail With {
                                    .ItemID = ItemRow.Cells("ItemID").Value,
                                    .Quantity = ItemRow.Cells("Qty").Value,
                                    .InventoryJournalID = OPDReqIJ.ID,
                                    .Remark = ItemRow.Cells("Remark").Value}
                                LMISDb.InventoryJournalDetails.AddObject(NewIJDetailOPDIssID)
                                LMISDb.SaveChanges()
                                Dim NewIJDetailsBatch As New InventoryJournalDetailsBatch With {
                                    .InventoryBatchID = ItemRow.Cells("Batch").Value,
                                    .Price = ItemRow.Cells("Cost").Value,
                                    .LocationID = CType(ItemRow.Cells("Batch_Location"), ComboCell).BatchLocationID,
                                    .InventoryJournaDetaillID = NewIJDetailOPDIssID.ID}
                                LMISDb.InventoryJournalDetailsBatches.AddObject(NewIJDetailsBatch)
                                LMISDb.SaveChanges()
                            End If
                        Next
                        Transaction.Complete()
                        Return True
                End Select
            End Using
        Catch ex As Exception
            MessageBox.Show("Error: In Saving Data" & vbCrLf & ex.Message & Utility.InnerExecption(ex), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return False
    End Function

    Function ValidateDataForm() As Boolean
        ERP_Error.Clear()
        Dim No_Error As Boolean = True
        If CMBX_OPDIssueID.SelectedItem Is Nothing And CMBX_OPDIssueID.Text = String.Empty Then
            ERP_Error.SetError(CMBX_OPDIssueID, "Please select appropriate 'Request ID' from the list")
            No_Error = False
        End If
        'If CHBX_NewPerson.Checked Then
        If CMBX_IDNO.Text = String.Empty Then
            ERP_Error.SetError(CMBX_IDNO, "Please select appropriate 'ID' from the list or type in a new one")
            No_Error = False
            'ElseIf CMBX_IDNO.SelectedItem IsNot Nothing Then
            '    ERP_Error.SetError(CMBX_IDNO, "'Eritrean ID' already exists, type in a new one")
            '    No_Error = False
        End If
        'End If
        If CMBX_IDNO.SelectedItem IsNot Nothing And CMBX_Name.SelectedItem Is Nothing Then
            ERP_Error.SetError(CMBX_Name, "Please select appropriate 'Name' from the list")
            No_Error = False
        End If

        If CMBX_PaymentType.SelectedItem Is Nothing Then
            ERP_Error.SetError(CMBX_PaymentType, "Please select appropriate 'Payment Type' from the list")
            No_Error = False
        End If
        If CMBX_PaymentType.Text = "Sick" And CMBX_Company.Text = String.Empty And CMBX_Company.SelectedItem Is Nothing Then
            ERP_Error.SetError(CMBX_Company, "'Company' should not be empty")
            No_Error = False
        End If
        If TBX_CardNo.Text = String.Empty Then
            ERP_Error.SetError(TBX_CardNo, "Please type in the Card Number of the patient")
            No_Error = False
        End If
        If CMBX_DispersedBy.SelectedItem Is Nothing Then
            ERP_Error.SetError(CMBX_DispersedBy, "Please select appropriate 'Disperser' from the list")
            No_Error = False
        End If
        If CMBX_Prescribedby.SelectedItem Is Nothing Then
            ERP_Error.SetError(CMBX_Prescribedby, "Please select appropriate 'Payment Type' from the list")
            No_Error = False
        End If
        If DGV_Items.Rows.Count = 1 Then
            ERP_Error.SetError(DGV_Items, "At least 'One Item' should be requested")
            No_Error = False
        ElseIf Not DGV_Items.ValidateData() Then
            ERP_Error.SetError(DGV_Items, "Correct your errors in Items table")
            No_Error = False
        End If
        If CMBX_FName.Text = String.Empty Then
            ERP_Error.SetError(CMBX_FName, "First Name should not be empty")
            No_Error = False
        ElseIf (From N In (New LMISEntities).PersonNames Where N.Name = CMBX_FName.Text Select N).Count = 0 Then
            ERP_Error.SetError(CMBX_FName, "Name is not present in database")
            No_Error = False
        End If
        If NUD_Age.Value <= 0 Then
            ERP_Error.SetError(NUD_Age, "Please select appropriate 'Age' from the list")
            No_Error = False
        End If
        If CMBX_MName.Text = String.Empty Then
            ERP_Error.SetError(CMBX_MName, "First Name should not be empty")
            No_Error = False
        ElseIf (From N In (New LMISEntities).PersonNames Where N.Name = CMBX_MName.Text Select N).Count = 0 Then
            ERP_Error.SetError(CMBX_MName, "Name is not present in database")
            No_Error = False
        End If
        If CMBX_LName.Text <> String.Empty Then
            If (From N In (New LMISEntities).PersonNames Where N.Name = CMBX_LName.Text Select N).Count = 0 Then
                ERP_Error.SetError(CMBX_LName, "Name is not present in database")
                No_Error = False
            End If
        End If
        If CMBX_Gender.SelectedItem Is Nothing Then
            ERP_Error.SetError(CMBX_Gender, "Select the gender of the Person")
            No_Error = False
        End If
        If CMBX_Country.SelectedItem Is Nothing Then
            ERP_Error.SetError(CMBX_Country, "Select the Country of the Person")
            No_Error = False
        End If
        Return No_Error
    End Function

    Sub ClearForm()
        If FRMMode = FRMModes.AddNew Then
            CMBX_OPDIssueID.Text = Utility.GenerateID(IDTypes.OPDRequisition)
        Else
            CMBX_OPDIssueID.SelectedItem = Nothing
        End If
        CMBX_IDNO.SelectedItem = Nothing
        CMBX_Company.SelectedItem = Nothing
        CMBX_DispersedBy.SelectedItem = Nothing
        CMBX_Prescribedby.SelectedItem = Nothing
        CMBX_Company.Text = String.Empty
        DTP_VoucherDate.Value = Date.Today
        TBX_Remark.Text = ""
        ClearPerson()
        DGV_Items.Rows.Clear()
    End Sub

    Sub ClearPerson()
        CMBX_Name.SelectedItem = Nothing
        CMBX_FName.Text = String.Empty
        CMBX_MName.Text = String.Empty
        CMBX_LName.Text = String.Empty
        CMBX_Country.SelectedValue = 39
        CMBX_Gender.SelectedItem = Nothing
        TBX_PhoneNo.Text = String.Empty
        TBX_Email.Text = String.Empty
        TBX_CardNo.Text = String.Empty
        NUD_Age.Value = 0
    End Sub

    Sub CalcualteTotalCost()
        Dim Running_Quantity As Double = 0
        For Each ItemRow As DataGridViewRow In DGV_Items.Rows
            Running_Quantity += ItemRow.Cells("Cost").Value
        Next
        TBX_TotalCost.Text = Running_Quantity
    End Sub

    Private Sub ChangePerson(ByVal PersonID As String)
        'ClearForm(False)
        Dim LMISDb As New LMISEntities
        Dim Person = From P In LMISDb.People Where P.ID = PersonID Select P
        If Person.Count > 0 Then
            With Person.First
                CMBX_FName.Text = .PersonName.Name
                CMBX_MName.Text = .PersonName1.Name
                If .PersonName2 IsNot Nothing Then
                    CMBX_LName.Text = .PersonName2.Name
                Else
                    CMBX_LName.Text = String.Empty
                End If
                TBX_PhoneNo.Text = .PhoneNo
                TBX_Email.Text = .EmailAddress
                CMBX_Gender.Text = .Gender
                CMBX_Country.SelectedValue = .CountryID
                NUD_Age.Value = Date.Today.Year - .DOB.Year
            End With
        End If
    End Sub

    Private Function SavePerson() As String
        Try
            Dim LMISDb As New LMISEntities
            Dim IsNewPerson As Boolean = False
            Dim Person As Person

            If CMBX_Name.SelectedItem IsNot Nothing Then
                Dim PersonID As String = CType(CMBX_Name.SelectedItem, IDNdata).ID
                Person = (From P In LMISDb.People Where P.ID = PersonID Select P).Single
            Else
                Person = New Person
                Person.ID = Utility.GenerateID(IDTypes.Person)
                Person.PersonStatusID = 1
                IsNewPerson = True
            End If
            With Person
                .IDNO = CMBX_IDNO.Text
                .FirstNameID = (From N In LMISDb.PersonNames Select N Where N.Name = CMBX_FName.Text).First.ID
                .MiddleNameID = (From N In LMISDb.PersonNames Select N Where N.Name = CMBX_MName.Text).First.ID
                If CMBX_LName.Text <> String.Empty Then .LastNameID = (From N In LMISDb.PersonNames Select N Where N.Name = CMBX_LName.Text).First.ID
                .PhoneNo = TBX_PhoneNo.Text
                .EmailAddress = TBX_Email.Text
                .Gender = CMBX_Gender.Text
                .CountryID = CMBX_Country.SelectedValue
                .DOB = New Date(Date.Today.Year - NUD_Age.Value, 1, 1)
            End With
            If IsNewPerson Then LMISDb.People.AddObject(Person)
            LMISDb.SaveChanges()
            Return Person.ID
        Catch ex As Exception
            MessageBox.Show("Error:" & vbCrLf & ex.Message & Utility.InnerExecption(ex), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return Nothing
        End Try
        Return Nothing
    End Function

    Private Sub SavePayment(ByRef LMISDb As LMISEntities, ByVal OPDReqID As String)
        Try
            Dim CompanyID As Integer = CMBX_Company.SelectedValue
            Dim SickReportOPDs = From SR In LMISDb.SickReportOPDs Where SR.OPDRequisitionID = OPDReqID Select SR
            Dim PaymentAdminOPDs = From PA In LMISDb.PaymentAdminOPDs Where PA.OPDRequisitionID = OPDReqID Select PA
            Dim SickReportOPD As SickReportOPD
            Dim PaymentAdminOPD As PaymentAdminOPD
            'MsgBox (Utility.GenerateID(IDTypes.SickReportOPD)
            If CMBX_PaymentType.Text = "Sick" Then
                If SickReportOPDs.Count > 0 Then
                    SickReportOPD = SickReportOPDs.First
                    SickReportOPD.CompanyID = CMBX_Company.SelectedValue
                Else
                    SickReportOPD = New SickReportOPD With {.ID = Utility.GenerateID(IDTypes.SickReportOPD), .CompanyID = CMBX_Company.SelectedValue, .OPDRequisitionID = OPDReqID}
                    LMISDb.SickReportOPDs.AddObject(SickReportOPD)
                End If
                If PaymentAdminOPDs.Count > 0 Then LMISDb.PaymentAdminOPDs.DeleteObject(PaymentAdminOPDs.First)
            ElseIf CMBX_PaymentType.Text = "Admin" Then
                If PaymentAdminOPDs.Count > 0 Then
                    PaymentAdminOPD = PaymentAdminOPDs.First
                    PaymentAdminOPD.ZoneID = CMBX_Company.SelectedValue
                Else
                    PaymentAdminOPD = New PaymentAdminOPD With {.ID = Utility.GenerateID(IDTypes.PaymentAdminOPD), .ZoneID = CMBX_Company.SelectedValue, .OPDRequisitionID = OPDReqID}
                    LMISDb.PaymentAdminOPDs.AddObject(PaymentAdminOPD)
                End If
                If SickReportOPDs.Count > 0 Then LMISDb.SickReportOPDs.DeleteObject(SickReportOPDs.First)
            Else
                If PaymentAdminOPDs.Count > 0 Then LMISDb.PaymentAdminOPDs.DeleteObject(PaymentAdminOPDs.First)
                If SickReportOPDs.Count > 0 Then LMISDb.SickReportOPDs.DeleteObject(SickReportOPDs.First)
            End If
            LMISDb.SaveChanges()
        Catch ex As Exception
            MessageBox.Show("Error:" & vbCrLf & ex.Message & Utility.InnerExecption(ex), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

#End Region

#Region "Events"

    Private Sub FRM_GotFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.GotFocus
        FRM_GLBMain.TLSL_MainStatus.Text = "Ready"
    End Sub

    Private Sub BTN_Close_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTN_Close.Click
        Me.Close()
    End Sub

    Private Sub FRM_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If DGV_Items.Rows.Count > 1 Then If MessageBox.Show("Are you sure you want to close without saving your work?", "Are you sure?", System.Windows.Forms.MessageBoxButtons.YesNo, System.Windows.Forms.MessageBoxIcon.Information) = System.Windows.Forms.DialogResult.No Then e.Cancel = True
    End Sub

    Private Sub FRM_IJReceipt_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ClearForm()
        DGV_Items.initMe(TBX_TotalCost, IJFRM_Types.OPDIssueEdit)
        LoadForm()
        AddHandler CMBX_FName.TextChanged, AddressOf TBX
        AddHandler CMBX_MName.TextChanged, AddressOf TBX
        AddHandler CMBX_LName.TextChanged, AddressOf TBX
    End Sub

    Private Sub BTN_SaveNReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTN_SaveNReport.Click
        FRM_GLBMain.TLSL_MainStatus.Text = "Ready"
        If ValidateDataForm() Then
            If MessageBox.Show("Are you sure you want to save this Invoice", "Are you sure?", System.Windows.Forms.MessageBoxButtons.YesNo) = System.Windows.Forms.DialogResult.Yes Then
                Me.Cursor = Cursors.WaitCursor
                If SaveData(1) Then
                    FRM_GLBMain.TLSL_MainStatus.Text = "OPD Invoice Saved"
                    MessageBox.Show("OPD Invoice Saved", "Data Saved", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    LoadForm()
                    ClearForm()
                Else
                    FRM_GLBMain.TLSL_MainStatus.Text = "OPD Invoice Saved"
                    MessageBox.Show("   OPD Invoice Saved    ", "Error in Saving", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
                Me.Cursor = Cursors.Default
            End If
        End If
    End Sub


    Private Sub BTN_Post_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTN_Post.Click
        FRM_GLBMain.TLSL_MainStatus.Text = "Ready"
        If ValidateDataForm() Then
            If MessageBox.Show("Are you sure you want to Post this Invoice" & vbCrLf & vbCrLf & "You will not be able to edit it again!", "Are you sure?", System.Windows.Forms.MessageBoxButtons.YesNo) = System.Windows.Forms.DialogResult.Yes Then
                Me.Cursor = Cursors.WaitCursor
                If SaveData(2) Then
                    FRM_GLBMain.TLSL_MainStatus.Text = "OPD Invoice Posted"
                    MessageBox.Show("OPD Invoice Posted", "Data Posted", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    LoadForm()
                    ClearForm()
                Else
                    FRM_GLBMain.TLSL_MainStatus.Text = "OPD Invoice Posted"
                    MessageBox.Show("   OPD Invoice Posted    ", "Error in Posting", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
                Me.Cursor = Cursors.Default
            End If
        End If
    End Sub
    Private Sub CMBX_IJRequestID_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBX_OPDIssueID.SelectedIndexChanged
4:      Try
            If CMBX_OPDIssueID.SelectedItem IsNot Nothing Then
                Dim LMISDb As New LMISEntities
                Dim OPDReq = (From O In LMISDb.OPDRequisitions Where O.ID = CMBX_OPDIssueID.Text Select O).Single
                CMBX_Name.SelectedValue = OPDReq.PersonID
                CMBX_IDNO.SelectedValue = OPDReq.PersonID
                CMBX_PaymentType.SelectedValue = OPDReq.PaymentTypeID
                CMBX_Prescribedby.SelectedValue = OPDReq.PrescribedBy
                CMBX_DispersedBy.SelectedValue = OPDReq.DispensedBy
                CMBX_Company.SelectedItem = Nothing
                TBX_Remark.Text = OPDReq.InventoryJournal.Remark
                TBX_CardNo.Text = OPDReq.CardNo
                DGV_Items.PopulateItems(CMBX_OPDIssueID.Text)
                'CHBX_NewPerson.Checked = False
                If OPDReq.PaymentType.Type = "Sick" Then
                    Dim SickReportOPDs = From SR In LMISDb.SickReportOPDs Where SR.OPDRequisitionID = OPDReq.ID Select SR
                    CMBX_Company.SelectedValue = SickReportOPDs.First.CompanyID
                ElseIf OPDReq.PaymentType.Type = "Admin" Then
                    Dim PaymentAdminOPDs = From PA In LMISDb.PaymentAdminOPDs Where PA.OPDRequisitionID = OPDReq.ID Select PA
                    CMBX_Company.SelectedValue = PaymentAdminOPDs.First.ZoneID
                End If
                RemoveHandler CMBX_CardNo.SelectedIndexChanged, AddressOf CMBX_CardNo_SelectedIndexChanged
                CMBX_CardNo.SelectedValue = CMBX_OPDIssueID.SelectedValue
                AddHandler CMBX_CardNo.SelectedIndexChanged, AddressOf CMBX_CardNo_SelectedIndexChanged
            Else
                ClearForm()
            End If
        Catch ex As Exception
            MessageBox.Show("Error: In Changing Invoice" & vbCrLf & ex.Message & Utility.InnerExecption(ex), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub CMBX_CardNo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If CMBX_CardNo.SelectedItem IsNot Nothing And CMBX_CardNo.ValueMember <> String.Empty Then
            CMBX_OPDIssueID.SelectedItem = CMBX_CardNo.SelectedValue
        End If
    End Sub

#End Region

    Private Sub CMBX_PaymentType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBX_PaymentType.SelectedIndexChanged
        If CMBX_PaymentType.Text = "Sick" Then
            CMBX_Company.Enabled = True
            CMBX_Company.DataSource = From N In (New LMISEntities).Companies Select N
            CMBX_Company.DisplayMember = "Name"
            CMBX_Company.ValueMember = "ID"
            CMBX_Company.AutoCompleteSource = AutoCompleteSource.ListItems
            CMBX_Company.SelectedItem = Nothing
        ElseIf CMBX_PaymentType.Text = "Admin" Then
            CMBX_Company.Enabled = True
            CMBX_Company.DataSource = From N In (New LMISEntities).Zones Select N
            CMBX_Company.DisplayMember = "ZoneName"
            CMBX_Company.ValueMember = "ZoneID"
            CMBX_Company.AutoCompleteSource = AutoCompleteSource.ListItems
            CMBX_Company.SelectedItem = Nothing
        Else
            CMBX_Company.Enabled = False
        End If
    End Sub
    Private Sub CMBX_IDNO_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBX_IDNO.SelectedIndexChanged, CMBX_IDNO.LostFocus
        If CMBX_IDNO.ValueMember <> String.Empty Then
            If CMBX_IDNO.SelectedItem IsNot Nothing Then
                ChangePerson(CMBX_IDNO.SelectedValue)
                RemoveHandler CMBX_Name.SelectedIndexChanged, AddressOf CMBX_Name_SelectedIndexChanged
                CMBX_Name.SelectedValue = CMBX_IDNO.SelectedValue
                AddHandler CMBX_Name.SelectedIndexChanged, AddressOf CMBX_Name_SelectedIndexChanged
                CMBX_Name.Enabled = True
            Else
                ClearPerson()
                CMBX_Name.Enabled = False
            End If
        End If
    End Sub

    Private Sub CMBX_Name_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBX_Name.SelectedIndexChanged, CMBX_Name.LostFocus
        If CMBX_Name.ValueMember <> String.Empty Then
            If CMBX_Name.SelectedItem IsNot Nothing Then
                ChangePerson(CMBX_Name.SelectedValue)
                RemoveHandler CMBX_IDNO.SelectedIndexChanged, AddressOf CMBX_IDNO_SelectedIndexChanged
                CMBX_IDNO.SelectedValue = CMBX_Name.SelectedValue
                AddHandler CMBX_IDNO.SelectedIndexChanged, AddressOf CMBX_IDNO_SelectedIndexChanged
            Else
                ClearPerson()
                CMBX_IDNO.SelectedItem = Nothing
            End If
        End If
    End Sub
    'Private Sub CHBX_NewPerson_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CHBX_NewPerson.CheckedChanged
    '    CMBX_Name.Enabled = Not CHBX_NewPerson.Checked
    '    If CHBX_NewPerson.Checked Then CMBX_Name.SelectedItem = Nothing
    'End Sub

    Private Sub TBX(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim TBX_N As TextBox = CType(sender, TextBox)
        If TBX_N.Text.Length = 1 Then
            Dim LMISDb As New LMISEntities
            Dim AutoCSource As New AutoCompleteStringCollection
            Dim Names = From d In (New LMISEntities).PersonNames Select d Where d.Name.StartsWith(TBX_N.Text)
            For Each SName In Names
                AutoCSource.Add(SName.Name)
            Next
            TBX_N.AutoCompleteCustomSource = AutoCSource
        End If
    End Sub

End Class