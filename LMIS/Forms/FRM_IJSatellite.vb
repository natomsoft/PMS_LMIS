Imports System.Data.Objects
Imports System.Transactions
Public Class FRM_IJSatellite

#Region "declarations"
    Private FRMMode As FRMModes = FRMModes.AddNew
    Dim IPDIssueID As String = String.Empty

    Public Sub New()
        InitializeComponent()
        Me.MdiParent = FRM_GLBMain
        DTP_VoucherDate.MaxDate = Date.Today
    End Sub

    Public Overloads Sub Show(ByVal Mode As FRMModes)
        FRMMode = Mode
        If FRMMode.Equals(FRMModes.AddNew) Then
            Me.Text = "Satellite Invoice"
            LBL_Title.Text = "Satellite Invoice"
            CMBX_IPDIssueID.Text = Utility.GenerateID(IDTypes.IPDRequisition)
            CMBX_IPDIssueID.Enabled = False
            CMBX_CardNo.Enabled = False
        Else
            Me.Text = "Edit Existing Satellite Invoice"
            LBL_Title.Text = "Edit Existing Satellite Invoice"
            CMBX_IPDIssueID.Enabled = True
            CMBX_CardNo.Enabled = True
        End If
        Me.Show()
    End Sub

#End Region

#Region "Utilities"

    Sub LoadForm()
        Try
            Dim LMISDb As New LMISEntities
            With CMBX_IPDIssueID
                .DataSource = From O In LMISDb.IPDRequisitions Where O.InventoryJournal.InventoryJournalStatu.Name = "Pending" And O.InventoryJournal.DepartmentID = FRM_GLBMain.ApplicationConfig.ThisDepartment.ID Select O.ID
                .AutoCompleteSource = AutoCompleteSource.ListItems
                .SelectedItem = Nothing
            End With

            Dim Cards = From I In LMISDb.IPDRequisitions Where I.InventoryJournal.InventoryJournalStatu.Name = "Pending" Select I.ID, I.Patient.Person, I.Patient.CardNo Order By CardNo Ascending
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

            Dim Patients = From P In LMISDb.Patients Where P.Active = True Select P.ID, FName = P.Person.PersonName.Name, SName = P.Person.PersonName1.Name, LName = P.Person.PersonName2.Name, P.Person.IDNO, P.Person.PhoneNo Order By IDNO
            Dim PatientDetails As New List(Of IDNdata)
            For Each Patient In Patients
                PatientDetails.Add(New IDNdata(Patient.ID, Patient.FName & " " & Patient.SName & " " & Patient.LName & " " & Patient.IDNO & ", " & Patient.PhoneNo, True))
            Next
            With CMBX_IDNO
                .DataSource = Patients
                .DisplayMember = "IDNO"
                .ValueMember = "ID"
                .AutoCompleteSource = AutoCompleteSource.ListItems
                .SelectedItem = Nothing
            End With

            With CMBX_Name
                .DataSource = PatientDetails
                .DisplayMember = "Data"
                .ValueMember = "ID"
                .AutoCompleteSource = AutoCompleteSource.ListItems
                .SelectedItem = Nothing
            End With

            Dim Beds As New List(Of IDNdata)
            Dim MyDepartment = FRM_GLBMain.ApplicationConfig.ThisDepartment
            For Each Bed In From B In LMISDb.Beds Where ((MyDepartment.Facility.IsNationalReferral = True And B.Room.Department.FacilityID = MyDepartment.FacilityID) Or (MyDepartment.Facility.IsNationalReferral = False And B.Room.DepartmentID = MyDepartment.ID)) And B.Room.Active = True Select B.ID, B.BedNo, B.Room.RoomNo, B.Room.Department.Name
                Beds.Add(New IDNdata(Bed.ID, Bed.RoomNo & " - " & Bed.BedNo, True))
            Next
            With CMBX_BedNo
                .DataSource = Beds
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
            CMBX_Country.DataSource = From C In LMISDb.Countries Select C
            CMBX_Country.DisplayMember = "Name"
            CMBX_Country.ValueMember = "ID"
            CMBX_Country.AutoCompleteSource = AutoCompleteSource.ListItems
            CMBX_Country.SelectedItem = Nothing
        Catch ex As Exception
            MessageBox.Show("Error: In Loading Requisitions" & vbCrLf & ex.Message & Utility.InnerExecption(ex), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
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
            IPDIssueID = String.Empty
            Using Transaction As New TransactionScope(TransactionScopeOption.RequiresNew)
                Dim LMISDb As New LMISEntities
                Dim IPDIssID As String = Nothing
                Dim SaveIJType As Integer = 19            'IPD Issue
                If SaveStatus = 2 Then SaveIJType = 18 'IPD Requisition
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
                        If SaveStatus = 1 Then IPDIssID = NewIssIJ.ID
                        'CMBX_IPDIssueID.Text = Utility.GenerateID(IDTypes.IPDIssue)
                        Dim NewIPDReq As New IPDRequisition With {
                            .ID = Utility.GenerateID(IDTypes.IPDRequisition),
                            .InventoryJournalID = IPDIssID,
                            .PatientID = SavePatient(),
                            .BedID = CMBX_BedNo.SelectedValue,
                            .AdmissionDate = DTP_AdmssionDate.Value,
                            .DischargeDate = DTP_DischargeDate.Value,
                            .PaymentTypeID = CMBX_PaymentType.SelectedValue
                            }
                        LMISDb.IPDRequisitions.AddObject(NewIPDReq)
                        LMISDb.SaveChanges()
                        SavePayment(LMISDb, CMBX_IPDIssueID.Text)
                        If SaveStatus = 2 Then      'if for processed
                            Dim NewIPDIssue As New IPDIssue With {
                                .ID = Utility.GenerateID(IDTypes.IPDIssue),
                                .IPDRequisitionID = NewIPDReq.ID,
                                .InventoryJournalID = NewIssIJ.ID}
                            Dim IPDReq = (From O In LMISDb.IPDRequisitions Where O.ID = CMBX_IPDIssueID.Text Select O).Single
                            IPDReq.InventoryJournalID = Nothing
                            IPDIssueID = NewIPDIssue.ID
                            LMISDb.IPDIssues.AddObject(NewIPDIssue)
                            LMISDb.SaveChanges()
                        End If
                        For Each ItemRow As DataGridViewRow In DGV_Items.Rows
                            If Not ItemRow.IsNewRow Then
                                Dim NewIJDetail As New InventoryJournalDetail With {
                                    .ItemID = ItemRow.Cells("ItemID").Value,
                                    .Quantity = ItemRow.Cells("Qty").Value,
                                    .InventoryJournalID = NewIssIJ.ID,
                                    .Remark = ItemRow.Cells("Remark").Value}
                                LMISDb.InventoryJournalDetails.AddObject(NewIJDetail)
                                LMISDb.SaveChanges()
                                Dim NewIJDetailsBatch As New InventoryJournalDetailsBatch With {
                                    .InventoryBatchID = ItemRow.Cells("Batch").Value,
                                    .Price = ItemRow.Cells("Cost").Value,
                                    .LocationID = CType(ItemRow.Cells("Batch_Location"), ComboCell).BatchLocationID,
                                    .InventoryJournaDetaillID = NewIJDetail.ID}
                                LMISDb.InventoryJournalDetailsBatches.AddObject(NewIJDetailsBatch)
                                LMISDb.SaveChanges()
                                If ItemRow.Cells("OrderedBy").Value IsNot Nothing Then
                                    Dim NewONA As New OrderandAdminister With {
                                        .ID = Utility.GenerateID(IDTypes.OrdereNAdminister),
                                        .InventoryJournalDetailID = NewIJDetail.ID,
                                        .OrderedBy = CType(ItemRow.Cells("OrderedBy"), ComboCellGeneral).SelectedValue,
                                        .AdministereBy = CType(ItemRow.Cells("AdministeredBy"), ComboCellGeneral).SelectedValue,
                                        .Date = ItemRow.Cells("EntryDate").Value}
                                    LMISDb.OrderandAdministers.AddObject(NewONA)
                                    LMISDb.SaveChanges()
                                End If
                            End If
                        Next
                        Transaction.Complete()
                        Return True
                    Case FRMModes.EditExisting
                        Dim IPDReqIJ = (From O In LMISDb.IPDRequisitions Where O.ID = CMBX_IPDIssueID.Text Select O.InventoryJournal).Single
                        Dim IPDReq = (From O In LMISDb.IPDRequisitions Where O.ID = CMBX_IPDIssueID.Text Select O).Single
                        IPDReqIJ.Remark = TBX_Remark.Text
                        IPDReqIJ.VoucherDate = DTP_VoucherDate.Value
                        IPDReqIJ.InventoryJournalStatusID = SaveStatus
                        IPDReq.PatientID = SavePatient()
                        IPDReq.BedID = CMBX_BedNo.SelectedValue
                        IPDReq.AdmissionDate = DTP_AdmssionDate.Value
                        IPDReq.DischargeDate = DTP_DischargeDate.Value
                        IPDReq.PaymentTypeID = CMBX_PaymentType.SelectedValue
                        SavePayment(LMISDb, CMBX_IPDIssueID.Text)
                        If SaveStatus = 2 Then      'if for processed
                            Dim NewIPDIssue As New IPDIssue With {
                                .ID = Utility.GenerateID(IDTypes.IPDIssue),
                                .IPDRequisitionID = IPDReq.ID,
                                .InventoryJournalID = IPDReqIJ.ID}
                            LMISDb.IPDIssues.AddObject(NewIPDIssue)
                            IPDIssueID = NewIPDIssue.ID
                            IPDReq.InventoryJournalID = Nothing
                            IPDReqIJ.InventoryJournalTypeID = 18 'switch the ipdreq to ipdiss
                        End If
                        LMISDb.SaveChanges()
                        Dim IJDDelete = From IJD In LMISDb.InventoryJournalDetails
                                            Where IJD.InventoryJournalID = IPDReqIJ.ID
                                            Select IJD
                        For Each IJDRow As InventoryJournalDetail In IJDDelete
                            Dim IJDDeleteID As String = IJDRow.ID
                            Dim IJDBDelete = From IJDB In LMISDb.InventoryJournalDetailsBatches
                                             Where IJDB.InventoryJournaDetaillID = IJDDeleteID
                                             Select IJDB
                            If IJDBDelete.Count > 0 Then LMISDb.InventoryJournalDetailsBatches.DeleteObject(IJDBDelete.First)
                            Dim ONASDelete = From ONAS In LMISDb.OrderandAdministers
                                             Where ONAS.InventoryJournalDetailID = IJDDeleteID
                                             Select ONAS
                            If ONASDelete.Count > 0 Then LMISDb.OrderandAdministers.DeleteObject(ONASDelete.First)
                        Next
                        LMISDb.SaveChanges()
                        For Each IJDRow As InventoryJournalDetail In IJDDelete
                            LMISDb.InventoryJournalDetails.DeleteObject(IJDRow)
                        Next
                        LMISDb.SaveChanges()
                        Dim EnteredItemIDs As New List(Of String)
                        For Each ItemRow As DataGridViewRow In DGV_Items.Rows
                            If Not ItemRow.IsNewRow Then
                                Dim NewIJDetailIPDIssID As New InventoryJournalDetail With {
                                    .ItemID = ItemRow.Cells("ItemID").Value,
                                    .Quantity = ItemRow.Cells("Qty").Value,
                                    .InventoryJournalID = IPDReqIJ.ID,
                                    .Remark = ItemRow.Cells("Remark").Value}
                                LMISDb.InventoryJournalDetails.AddObject(NewIJDetailIPDIssID)
                                LMISDb.SaveChanges()
                                Dim NewIJDetailsBatch As New InventoryJournalDetailsBatch With {
                                    .InventoryBatchID = ItemRow.Cells("Batch").Value,
                                    .Price = ItemRow.Cells("Cost").Value,
                                    .LocationID = CType(ItemRow.Cells("Batch_Location"), ComboCell).BatchLocationID,
                                    .InventoryJournaDetaillID = NewIJDetailIPDIssID.ID}
                                LMISDb.InventoryJournalDetailsBatches.AddObject(NewIJDetailsBatch)
                                LMISDb.SaveChanges()
                                If ItemRow.Cells("OrderedBy").Value IsNot Nothing Then
                                    Dim NewONA As New OrderandAdminister With {
                                        .ID = Utility.GenerateID(IDTypes.OrdereNAdminister),
                                        .InventoryJournalDetailID = NewIJDetailIPDIssID.ID,
                                        .OrderedBy = CType(ItemRow.Cells("OrderedBy"), ComboCellGeneral).SelectedValue,
                                        .AdministereBy = CType(ItemRow.Cells("AdministeredBy"), ComboCellGeneral).SelectedValue,
                                        .Date = ItemRow.Cells("EntryDate").Value}
                                    LMISDb.OrderandAdministers.AddObject(NewONA)
                                    LMISDb.SaveChanges()
                                End If
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
        If CMBX_IPDIssueID.SelectedItem Is Nothing And CMBX_IPDIssueID.Text = String.Empty Then
            ERP_Error.SetError(CMBX_IPDIssueID, "Please select appropriate 'Request ID' from the list")
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
        If NUD_Age.Value <= 0 Then
            ERP_Error.SetError(NUD_Age, "Please select appropriate 'Age' from the list")
            No_Error = False
        End If
        If TBX_CardNo.Text = String.Empty Then
            ERP_Error.SetError(TBX_CardNo, "Please type in the Card Number of the patient")
            No_Error = False
        End If
        If CMBX_PaymentType.SelectedItem Is Nothing Then
            ERP_Error.SetError(CMBX_PaymentType, "Please select appropriate 'Payment Type' from the list")
            No_Error = False
        End If
        If CMBX_PaymentType.Text = "Sick" And CMBX_Company.SelectedItem Is Nothing Then
            ERP_Error.SetError(CMBX_Company, "'Institute' should not be empty")
            No_Error = False
        End If
        If CMBX_PaymentType.Text = "Admin" And CMBX_Company.SelectedItem Is Nothing Then
            ERP_Error.SetError(CMBX_Company, "'Zoba' should not be empty")
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
        If CMBX_BedNo.SelectedItem Is Nothing Then
            ERP_Error.SetError(CMBX_BedNo, "Please select appropriate 'Bed Number' from the list")
            No_Error = False
        End If
        If DGV_Items.Rows.Count = 1 Then
            ERP_Error.SetError(DGV_Items, "At least 'One Item' should be requested")
            No_Error = False
        ElseIf Not DGV_Items.ValidateData() Then
            ERP_Error.SetError(DGV_Items, "Correct your errors in Items table")
            No_Error = False
        End If
        Return No_Error
    End Function

    Sub ClearForm()
        If FRMMode = FRMModes.AddNew Then
            CMBX_IPDIssueID.Text = Utility.GenerateID(IDTypes.IPDRequisition)
        Else
            CMBX_IPDIssueID.SelectedItem = Nothing
        End If
        DTP_VoucherDate.Value = Date.Today
        TBX_Remark.Text = String.Empty
        CMBX_BedNo.SelectedItem = Nothing
        CMBX_PaymentType.SelectedItem = Nothing
        CMBX_Company.SelectedItem = Nothing        
        DGV_Items.Rows.Clear()
        CMBX_IDNO.SelectedItem = Nothing
        CMBX_IDNO.Text = String.Empty
        ClearPerson()
    End Sub

    Sub ClearPerson()
        CMBX_Name.SelectedItem = Nothing
        CMBX_FName.Text = String.Empty
        CMBX_MName.Text = String.Empty
        CMBX_LName.Text = String.Empty
        TBX_Email.Text = String.Empty
        TBX_Remark.Text = String.Empty
        CMBX_Gender.SelectedItem = Nothing
        NUD_Age.Value = 0
        TBX_PhoneNo.Text = String.Empty
        TBX_Allergies.Text = String.Empty
        TBX_CardNo.Text = String.Empty
        TBX_ClinicalCardNo.Text = String.Empty
        CMBX_Country.SelectedValue = 39
    End Sub

    Sub CalcualteTotalCost()
        Dim Running_Quantity As Double = 0
        For Each ItemRow As DataGridViewRow In DGV_Items.Rows
            Running_Quantity += ItemRow.Cells("Cost").Value
        Next
        TBX_TotalCost.Text = Running_Quantity
    End Sub

    Private Sub ChangePatient(ByVal PatientID As String)
        'ClearForm(False)        
        Dim LMISDb As New LMISEntities
        Dim Patient = From P In LMISDb.Patients Where P.ID = PatientID Select P
        If Patient.Count > 0 Then
            With Patient.First
                CMBX_FName.Text = .Person.PersonName.Name
                CMBX_MName.Text = .Person.PersonName1.Name
                If .Person.PersonName2 IsNot Nothing Then
                    CMBX_LName.Text = .Person.PersonName2.Name
                Else
                    CMBX_LName.Text = Nothing
                End If
                TBX_CardNo.Text = .CardNo
                TBX_ClinicalCardNo.Text = .ClinicalCardNo
                TBX_PhoneNo.Text = .Person.PhoneNo
                TBX_Email.Text = .Person.EmailAddress
                CMBX_Gender.Text = .Person.Gender
                CMBX_Country.SelectedValue = .Person.CountryID
                NUD_Age.Value = Date.Today.Year - .Person.DOB.Year
            End With
        End If
    End Sub

    Private Function SavePatient() As String
        'Try
        Dim LMISDb As New LMISEntities
        Dim IsNewPerson As Boolean = False
        Dim Person As Person
        Dim Patient As Patient

        If CMBX_Name.SelectedItem IsNot Nothing Then
            Dim PatientID As String = CMBX_Name.SelectedValue
            Dim PersonID As String = CType(CMBX_Name.SelectedItem, IDNdata).ID
            Patient = (From P In LMISDb.Patients Where P.ID = PatientID Select P).Single
            Person = Patient.Person
        Else
            Person = New Person
            Patient = New Patient            
            Patient.ID = Utility.GenerateID(IDTypes.Patient)
            Patient.Active = True
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
        With Patient
            .PersonID = Person.ID
            .CardNo = TBX_CardNo.Text
            .ClinicalCardNo = TBX_ClinicalCardNo.Text
            .AllergiesOrInteraction = TBX_Allergies.Text
        End With
        If IsNewPerson Then
            LMISDb.People.AddObject(Person)
            LMISDb.Patients.AddObject(Patient)
        End If

        LMISDb.SaveChanges()
        Return Patient.ID
        'Catch ex As Exception
        '    MessageBox.Show("Error:" & vbCrLf & ex.Message & Utility.InnerExecption(ex), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        '    Return Nothing
        'End Try
        Return Nothing
    End Function

    Private Sub SavePayment(ByRef LMISDb As LMISEntities, ByVal IPDReqID As String)
        Try
            Dim CompanyID As Integer = CMBX_Company.SelectedValue
            Dim SickReportIPDs = From SR In LMISDb.SickReportIPDs Where SR.IPDRequisitionID = IPDReqID Select SR
            Dim PaymentAdminIPDs = From PA In LMISDb.PaymentAdminIPDs Where PA.IPDRequisitionID = IPDReqID Select PA
            Dim SickReportIPD As SickReportIPD
            Dim PaymentAdminIPD As PaymentAdminIPD
            If CMBX_PaymentType.Text = "Sick" Then
                If SickReportIPDs.Count > 0 Then
                    SickReportIPD = SickReportIPDs.First
                    SickReportIPD.CompanyID = CMBX_Company.SelectedValue
                Else                    
                    SickReportIPD = New SickReportIPD With {.ID = Utility.GenerateID(IDTypes.SickReportIPD), .CompanyID = CMBX_Company.SelectedValue, .IPDRequisitionID = IPDReqID}
                    LMISDb.SickReportIPDs.AddObject(SickReportIPD)
                End If
                If PaymentAdminIPDs.Count > 0 Then LMISDb.PaymentAdminIPDs.DeleteObject(PaymentAdminIPDs.First)
            ElseIf CMBX_PaymentType.Text = "Admin" Then
                If PaymentAdminIPDs.Count > 0 Then
                    PaymentAdminIPD = PaymentAdminIPDs.First
                    PaymentAdminIPD.ZoneID = CMBX_Company.SelectedValue
                Else
                    PaymentAdminIPD = New PaymentAdminIPD With {.ID = Utility.GenerateID(IDTypes.PaymentAdminIPD), .ZoneID = CMBX_Company.SelectedValue, .IPDRequisitionID = IPDReqID}
                    LMISDb.PaymentAdminIPDs.AddObject(PaymentAdminIPD)                    
                End If
                If SickReportIPDs.Count > 0 Then LMISDb.SickReportIPDs.DeleteObject(SickReportIPDs.First)
            Else
                If PaymentAdminIPDs.Count > 0 Then LMISDb.PaymentAdminIPDs.DeleteObject(PaymentAdminIPDs.First)
                If SickReportIPDs.Count > 0 Then LMISDb.SickReportIPDs.DeleteObject(SickReportIPDs.First)
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
        DGV_Items.initMe(TBX_TotalCost, IJFRM_Types.IPDIssueEdit)
        LoadForm()
        AddHandler CMBX_FName.TextChanged, AddressOf TBX
        AddHandler CMBX_MName.TextChanged, AddressOf TBX
        AddHandler CMBX_LName.TextChanged, AddressOf TBX
    End Sub

    Private Sub BTN_SaveNReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTN_SaveNReport.Click
        FRM_GLBMain.TLSL_MainStatus.Text = "Ready"
        If ValidateDataForm() Then
            If MessageBox.Show("Are you sure you want to save this Pre-invoice", "Are you sure?", System.Windows.Forms.MessageBoxButtons.YesNo) = System.Windows.Forms.DialogResult.Yes Then
                Me.Cursor = Cursors.WaitCursor
                If SaveData(1) Then
                    FRM_GLBMain.TLSL_MainStatus.Text = "Satellite Invoice Saved"
                    MessageBox.Show("Invoice Saved", "Data Saved", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    LoadForm()
                    ClearForm()
                Else
                    FRM_GLBMain.TLSL_MainStatus.Text = "Satellite Invoice Saved"
                    MessageBox.Show("   IPD Satellite Not Saved    ", "Error in Saving", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
                Me.Cursor = Cursors.Default
            End If
        End If
    End Sub

    Private Sub BTN_Print_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTN_Print.Click
        FRM_GLBMain.TLSL_MainStatus.Text = "Ready"
        If ValidateDataForm() Then
            If MessageBox.Show("Are you sure you want to save this Pre-invoice", "Are you sure?", System.Windows.Forms.MessageBoxButtons.YesNo) = System.Windows.Forms.DialogResult.Yes Then
                Me.Cursor = Cursors.WaitCursor
                If SaveData(1) Then
                    FRM_GLBMain.TLSL_MainStatus.Text = "Satellite Invoice Saved"
                    MessageBox.Show("Invoice Saved", "Data Saved", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Dim ReportParameter As New Dictionary(Of String, String())
                    ReportParameter.Add("@IPDRequID", {CMBX_IPDIssueID.Text})
                    ReportParameter.Add("Title", {FRM_GLBMain.ApplicationConfig.ThisDepartment.Name})
                    FRM_Reporter.Show(ReportTypes.IJIPDRequ, ReportParameter)
                    LoadForm()
                    ClearForm()
                Else
                    FRM_GLBMain.TLSL_MainStatus.Text = "Satellite Invoice Saved"
                    MessageBox.Show("   IPD Satellite Not Saved    ", "Error in Saving", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
                Me.Cursor = Cursors.Default
            End If
        End If
    End Sub

    Private Sub BTN_Post_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTN_Post.Click
        FRM_GLBMain.TLSL_MainStatus.Text = "Ready"
        If ValidateDataForm() Then
            If DTP_AdmssionDate.Value = DTP_DischargeDate.Value Then If MessageBox.Show("Admission Date and Discharge date are the same!" & vbCrLf & vbCrLf & "Post as is?", "Are you sure?", System.Windows.Forms.MessageBoxButtons.YesNo) = System.Windows.Forms.DialogResult.No Then Exit Sub
            If MessageBox.Show("Are you sure you want to Post this Invoice." & vbCrLf & vbCrLf & "You will not be able to edit it again!", "Are you sure?", System.Windows.Forms.MessageBoxButtons.YesNo) = System.Windows.Forms.DialogResult.Yes Then
                Me.Cursor = Cursors.WaitCursor
                If SaveData(2) Then
                    FRM_GLBMain.TLSL_MainStatus.Text = "Satellite Invoice Saved"
                    MessageBox.Show("Satellite Saved", "Data Saved", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Dim ReportParameter As New Dictionary(Of String, String())
                    ReportParameter.Add("@IPDIssueID", {IPDIssueID})
                    ReportParameter.Add("Title", {FRM_GLBMain.ApplicationConfig.ThisDepartment.Name})
                    FRM_Reporter.Show(ReportTypes.IJIPD, ReportParameter)
                    LoadForm()
                    ClearForm()
                Else
                    FRM_GLBMain.TLSL_MainStatus.Text = "Satellite Invoice Saved"
                    MessageBox.Show("   IPD Satellite Not Saved    ", "Error in Saving", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
                Me.Cursor = Cursors.Default
            End If
        End If
    End Sub

    Private Sub CMBX_IJRequestID_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBX_IPDIssueID.SelectedIndexChanged
        Try
            If CMBX_IPDIssueID.SelectedItem IsNot Nothing Then
                Dim LMISDb As New LMISEntities
                Dim IPDReq = (From O In LMISDb.IPDRequisitions Where O.ID = CMBX_IPDIssueID.Text Select O).Single
                DTP_VoucherDate.Value = IPDReq.InventoryJournal.VoucherDate
                DTP_AdmssionDate.Value = IPDReq.AdmissionDate
                DTP_DischargeDate.Value = IPDReq.DischargeDate
                TBX_Remark.Text = IPDReq.InventoryJournal.Remark
                TBX_CardNo.Text = IPDReq.Patient.CardNo
                TBX_ClinicalCardNo.Text = IPDReq.Patient.ClinicalCardNo
                TBX_Allergies.Text = IPDReq.Patient.AllergiesOrInteraction
                CMBX_BedNo.SelectedValue = IPDReq.BedID
                CMBX_Name.SelectedValue = IPDReq.PatientID
                CMBX_IDNO.SelectedValue = IPDReq.PatientID
                CMBX_PaymentType.SelectedValue = IPDReq.PaymentTypeID
                If IPDReq.PaymentType.Type = "Sick" Then
                    Dim SickReportIPDs = From SR In LMISDb.SickReportIPDs Where SR.IPDRequisitionID = IPDReq.ID Select SR
                    CMBX_Company.SelectedValue = SickReportIPDs.First.CompanyID
                ElseIf IPDReq.PaymentType.Type = "Admin" Then
                    Dim PaymentAdminIPDs = From PA In LMISDb.PaymentAdminIPDs Where PA.IPDRequisitionID = IPDReq.ID Select PA
                    CMBX_Company.SelectedValue = PaymentAdminIPDs.First.ZoneID
                End If
                DGV_Items.PopulateItems(CMBX_IPDIssueID.Text)
                'CHBX_NewPerson.Checked = False
                RemoveHandler CMBX_CardNo.SelectedIndexChanged, AddressOf CMBX_CardNo_SelectedIndexChanged
                CMBX_CardNo.SelectedValue = CMBX_IPDIssueID.SelectedValue
                AddHandler CMBX_CardNo.SelectedIndexChanged, AddressOf CMBX_CardNo_SelectedIndexChanged
            Else
                ClearForm()
            End If
        Catch ex As Exception
            MessageBox.Show("Error:" & vbCrLf & ex.Message & Utility.InnerExecption(ex), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub CMBX_CardNo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If CMBX_CardNo.SelectedItem IsNot Nothing And CMBX_CardNo.ValueMember <> String.Empty Then
            CMBX_IPDIssueID.SelectedItem = CMBX_CardNo.SelectedValue
        End If
    End Sub

    Private Sub DTP_AdmssionDate_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DTP_AdmssionDate.ValueChanged
        'DTP_DischargeDate.MinDate = DTP_AdmssionDate.Value
    End Sub

    Private Sub DTP_DischargeDate_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DTP_DischargeDate.ValueChanged
        'DTP_AdmssionDate.MaxDate = DTP_DischargeDate.Value
    End Sub

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
                ChangePatient(CMBX_IDNO.SelectedValue)
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
                ChangePatient(CMBX_Name.SelectedValue)
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
    '    If CHBX_NewPerson.Checked Then CMBX_IDNO.SelectedItem = Nothing
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

#End Region

  
End Class