Imports System.Data.Objects
Imports System.IO
Imports System.Runtime.Serialization.XmlObjectSerializer
Imports System.Xml.Serialization
Imports System.Transactions

Public Class FRM_MTNImport

    Public Sub New()
        InitializeComponent()
        Me.MdiParent = FRM_GLBMain
        LoadForm()
    End Sub

#Region "Utilities"

    Private Sub LoadForm()
        Try
            Dim LMISDb As New LMISEntities
            ClearForm(True)
        Catch ex As Exception
            MessageBox.Show("Error:" & vbCrLf & ex.Message & Utility.InnerExecption(ex), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Function ValidateDataForm() As Boolean
        ERP_Error.Clear()
        Dim No_Error As Boolean = True
        If TBX_ImportFile.Text = String.Empty Then SetError(TBX_ImportFile, "A file should be selected for Importing data", No_Error)
        Return No_Error
    End Function

    Private Function SenseType(ByVal TypeString As String) As Type
        Select Case TypeString
            Case "PersonName"
                Return GetType(PersonName)
            Case "Person"
                Return GetType(Person)
            Case "Employee"
                Return GetType(Employee)
            Case "Request"
                Return GetType(Request)
            Case "Recieve"
                Return GetType(Recieve)
            Case "Requisition"
                Return GetType(Requisition)
            Case "Issue"
                Return GetType(Issue)
            Case "Adjustment"
                Return GetType(Adjustment)
            Case "OPDRequisition"
                Return GetType(OPDRequisition)
            Case "OPDIssue"
                Return GetType(OPDIssue)
            Case "IPDRequisition"
                Return GetType(IPDRequisition)
            Case "IPDIssue"
                Return GetType(IPDIssue)
            Case "InventoryJournal"
                Return GetType(InventoryJournal)
            Case "InventoryJournalDetail"
                Return GetType(InventoryJournalDetail)
            Case "InventoryJournalDetailsBatch"
                Return GetType(InventoryJournalDetailsBatch)
            Case "InventoryBatch"
                Return GetType(InventoryBatch)
            Case "Department"
                Return GetType(Department)
            Case "ConsumedItem"
                Return GetType(ConsumedItem)
            Case "Patient"
                Return GetType(Patient)
            Case "SickReportIPD"
                Return GetType(SickReportIPD)
            Case "SickReportOPD"
                Return GetType(SickReportOPD)
            Case "PaymentAdminIPD"
                Return GetType(PaymentAdminIPD)
            Case "PaymentAdminOPD"
                Return GetType(PaymentAdminOPD)
            Case "Store"
                Return GetType(Store)
            Case "Location"
                Return GetType(Location)
            Case "Facility"
                Return GetType(Facility)
            Case "ItemsCatalogue"
                Return GetType(ItemsCatalogue)
            Case "InventoryItem"
                Return GetType(InventoryItem)
            Case "Company"
                Return GetType(Company)
            Case "AdjustmentType"
                Return GetType(AdjustmentType)
            Case "Names"
                Return GetType(PersonName)
            Case "Person"
                Return GetType(Person)
            Case "Employee"
                Return GetType(Employee)
            Case "Supplier"
                Return GetType(Supplier)
            Case "Room"
                Return GetType(Room)
            Case "Bed"
                Return GetType(Bed)
            Case Else
                Return Nothing
        End Select
    End Function

    Private Function SaveData() As Boolean
        'Dim testd As String
        Try
            'Using Transaction As New TransactionScope(TransactionScopeOption.RequiresNew)
            Dim LMISDb As New LMISEntities
            Dim SavedResultsCount As Integer = 0
            Dim IJSaved As Boolean = False
            Dim EmployeeID As String = 0
            Dim Employees As New List(Of String)
            Dim CurIJDID As Integer = 0
            Dim AllElements = XElement.Load(TBX_ImportFile.Text).Nodes
            PGB_Progress.Value = 0
            LBL_Count.Text = ""
            PGB_Progress.Maximum = AllElements.Count
            For Each XmlSerialzedOBJ As XElement In AllElements
                Dim TempWriter As StreamWriter = New StreamWriter(New MemoryStream())
                TempWriter.Write("<?xml version='1.0' encoding='utf-8'?>")
                TempWriter.Write(XmlSerialzedOBJ.ToString(System.Xml.Linq.SaveOptions.DisableFormatting))
                TempWriter.Flush()
                TempWriter.BaseStream.Seek(0, IO.SeekOrigin.Begin)
                'MsgBox("OBJ Name " & XmlSerialzedOBJ.Name.ToString)
                Dim OBJType As Type = SenseType(XmlSerialzedOBJ.Name.ToString)
                If OBJType IsNot Nothing Then
                    Dim DeserializedOBJ As Object = (New XmlSerializer(SenseType(XmlSerialzedOBJ.Name.ToString))).Deserialize(TempWriter.BaseStream)
                    'testd = testd & "  " & DeserializedOBJ.GetType.ToString
                    Select Case DeserializedOBJ.GetType
                        Case GetType(PersonName)
                            Dim OBJ = CType(DeserializedOBJ, PersonName)
                            IJSaved = False
                            If (From Test In (LMISDb).PersonNames Where Test.ID = OBJ.ID Select Test).Count = 0 Then LMISDb.PersonNames.AddObject(OBJ)
                        Case GetType(Person)
                            Dim OBJ = CType(DeserializedOBJ, Person)
                            IJSaved = False
                            If (From Test In (LMISDb).People Where Test.ID = OBJ.ID Select Test).Count = 0 Then LMISDb.People.AddObject(OBJ)
                        Case GetType(Employee)
                            Dim OBJ = CType(DeserializedOBJ, Employee)
                            IJSaved = False
                            EmployeeID = OBJ.ID
                            If Not Employees.Contains(OBJ.ID) Then
                                Employees.Add(OBJ.ID)
                                If (From Test In (LMISDb).Employees Where Test.ID = OBJ.ID Select Test).Count = 0 Then LMISDb.Employees.AddObject(OBJ)
                            End If
                        Case GetType(Request)
                            Dim OBJ = CType(DeserializedOBJ, Request)
                            IJSaved = False
                            If (From Test In (LMISDb).Requests Where Test.ID = OBJ.ID Select Test).Count = 0 Then LMISDb.Requests.AddObject(OBJ)
                        Case GetType(Recieve)
                            Dim OBJ = CType(DeserializedOBJ, Recieve)
                            IJSaved = False
                            If (From Test In (LMISDb).Recieves Where Test.ID = OBJ.ID Select Test).Count = 0 Then LMISDb.Recieves.AddObject(OBJ)
                        Case GetType(Requisition)
                            Dim OBJ = CType(DeserializedOBJ, Requisition)
                            IJSaved = False
                            If (From Test In (LMISDb).Requisitions Where Test.ID = OBJ.ID Select Test).Count = 0 Then LMISDb.Requisitions.AddObject(OBJ)
                        Case GetType(Issue)
                            Dim OBJ = CType(DeserializedOBJ, Issue)
                            IJSaved = False
                            If (From Test In (LMISDb).Issues Where Test.ID = OBJ.ID Select Test).Count = 0 Then LMISDb.Issues.AddObject(OBJ)
                        Case GetType(Adjustment)
                            Dim OBJ = CType(DeserializedOBJ, Adjustment)
                            IJSaved = False
                            If (From Test In (LMISDb).Adjustments Where Test.ID = OBJ.ID Select Test).Count = 0 Then LMISDb.Adjustments.AddObject(OBJ)
                        Case GetType(OPDRequisition)
                            Dim OBJ = CType(DeserializedOBJ, OPDRequisition)
                            IJSaved = False
                            If (From Test In (LMISDb).OPDRequisitions Where Test.ID = OBJ.ID Select Test).Count = 0 Then LMISDb.OPDRequisitions.AddObject(OBJ)
                        Case GetType(OPDIssue)
                            Dim OBJ = CType(DeserializedOBJ, OPDIssue)
                            IJSaved = False
                            If (From Test In (LMISDb).OPDIssues Where Test.ID = OBJ.ID Select Test).Count = 0 Then LMISDb.OPDIssues.AddObject(OBJ)
                        Case GetType(IPDRequisition)
                            Dim OBJ = CType(DeserializedOBJ, IPDRequisition)
                            IJSaved = False
                            If (From Test In (LMISDb).IPDRequisitions Where Test.ID = OBJ.ID Select Test).Count = 0 Then LMISDb.IPDRequisitions.AddObject(OBJ)
                        Case GetType(IPDIssue)
                            Dim OBJ = CType(DeserializedOBJ, IPDIssue)
                            IJSaved = False
                            If (From Test In (LMISDb).IPDIssues Where Test.ID = OBJ.ID Select Test).Count = 0 Then LMISDb.IPDIssues.AddObject(OBJ)
                        Case GetType(Patient)
                            Dim OBJ = CType(DeserializedOBJ, Patient)
                            IJSaved = False
                            If (From Test In (LMISDb).Patients Where Test.ID = OBJ.ID Select Test).Count = 0 Then LMISDb.Patients.AddObject(OBJ)
                        Case GetType(PaymentAdminIPD)
                            Dim OBJ = CType(DeserializedOBJ, PaymentAdminIPD)
                            IJSaved = True
                            If (From Test In (LMISDb).PaymentAdminIPDs Where Test.ID = OBJ.ID Select Test).Count = 0 Then LMISDb.PaymentAdminIPDs.AddObject(OBJ)
                        Case GetType(PaymentAdminOPD)
                            Dim OBJ = CType(DeserializedOBJ, PaymentAdminOPD)
                            IJSaved = True
                            If (From Test In (LMISDb).PaymentAdminOPDs Where Test.ID = OBJ.ID Select Test).Count = 0 Then LMISDb.PaymentAdminOPDs.AddObject(OBJ)
                        Case GetType(SickReportIPD)
                            Dim OBJ = CType(DeserializedOBJ, SickReportIPD)
                            IJSaved = True
                            If (From Test In (LMISDb).SickReportIPDs Where Test.ID = OBJ.ID Select Test).Count = 0 Then LMISDb.SickReportIPDs.AddObject(OBJ)
                        Case GetType(SickReportOPD)
                            Dim OBJ = CType(DeserializedOBJ, SickReportOPD)
                            IJSaved = True
                            If (From Test In (LMISDb).SickReportOPDs Where Test.ID = OBJ.ID Select Test).Count = 0 Then LMISDb.SickReportOPDs.AddObject(OBJ)
                        Case GetType(InventoryJournal)
                            Dim OBJ = CType(DeserializedOBJ, InventoryJournal)
                            'OBJ.EmployeeID = EmployeeID
                            If (From Test In (LMISDb).InventoryJournals Where Test.ID = OBJ.ID Select Test).Count = 0 Then
                                LMISDb.InventoryJournals.AddObject(OBJ)
                                LMISDb.SaveChanges()
                                IJSaved = True
                                CurIJDID = 0
                                SavedResultsCount += 1
                            End If
                        Case GetType(InventoryJournalDetail)
                            Dim OBJ = CType(DeserializedOBJ, InventoryJournalDetail)
                            If IJSaved Then
                                OBJ.ID = Nothing
                                LMISDb.InventoryJournalDetails.AddObject(OBJ)
                                LMISDb.SaveChanges()
                                CurIJDID = OBJ.ID
                            End If
                        Case GetType(InventoryBatch)
                            Dim OBJ = CType(DeserializedOBJ, InventoryBatch)
                            If (From Test In (LMISDb).InventoryBatches Where Test.ID = OBJ.ID Select Test).Count = 0 Then LMISDb.InventoryBatches.AddObject(OBJ)
                        Case GetType(InventoryJournalDetailsBatch)
                            Dim OBJ = CType(DeserializedOBJ, InventoryJournalDetailsBatch)
                            If IJSaved And CurIJDID <> 0 Then
                                OBJ.ID = Nothing
                                LMISDb.InventoryJournalDetailsBatches.AddObject(OBJ)
                                OBJ.InventoryJournaDetaillID = CurIJDID
                            End If
                        Case GetType(ConsumedItem)
                            Dim OBJ = CType(DeserializedOBJ, ConsumedItem)
                            If IJSaved And CurIJDID <> 0 Then
                                OBJ.InventoryJournalDetailID = CurIJDID
                                IJSaved = True
                                LMISDb.ConsumedItems.AddObject(OBJ)
                            End If
                        Case GetType(Store)
                            Dim OBJ = CType(DeserializedOBJ, Store)
                            IJSaved = True
                            If (From Test In (LMISDb).Stores Where Test.ID = OBJ.ID Select Test).Count = 0 Then LMISDb.Stores.AddObject(OBJ)
                        Case GetType(Location)
                            Dim OBJ = CType(DeserializedOBJ, Location)
                            IJSaved = True
                            If (From Test In (LMISDb).Locations Where Test.ID = OBJ.ID Select Test).Count = 0 Then LMISDb.Locations.AddObject(OBJ)
                        Case GetType(Department)
                            Dim OBJ = CType(DeserializedOBJ, Department)
                            If (From Test In (LMISDb).Departments Where Test.ID = OBJ.ID Select Test).Count = 0 Then
                                LMISDb.Departments.AddObject(OBJ)
                                SavedResultsCount += 1
                            End If
                        Case GetType(Facility)
                            Dim OBJ = CType(DeserializedOBJ, Facility)
                            If (From Test In (LMISDb).Facilities Where Test.ID = OBJ.ID Select Test).Count = 0 Then
                                LMISDb.Facilities.AddObject(OBJ)
                                SavedResultsCount += 1
                            End If
                        Case GetType(ItemsCatalogue)
                            Dim OBJ = CType(DeserializedOBJ, ItemsCatalogue)
                            If (From Test In (LMISDb).ItemsCatalogues Where Test.ID = OBJ.ID Select Test).Count = 0 Then
                                LMISDb.ItemsCatalogues.AddObject(OBJ)
                                SavedResultsCount += 1
                            End If
                        Case GetType(InventoryItem)
                            Dim OBJ = CType(DeserializedOBJ, InventoryItem)
                            If (From Test In (LMISDb).InventoryItems Where Test.ID = OBJ.ID Select Test).Count = 0 Then
                                LMISDb.InventoryItems.AddObject(OBJ)
                                SavedResultsCount += 1
                            End If
                        Case GetType(Company)
                            Dim OBJ = CType(DeserializedOBJ, Company)
                            If (From Test In (LMISDb).Companies Where Test.ID = OBJ.ID Select Test).Count = 0 Then
                                LMISDb.Companies.AddObject(OBJ)
                                SavedResultsCount += 1
                            End If
                        Case GetType(AdjustmentType)
                            Dim OBJ = CType(DeserializedOBJ, AdjustmentType)
                            If (From Test In (LMISDb).AdjustmentTypes Where Test.ID = OBJ.ID Select Test).Count = 0 Then
                                LMISDb.AdjustmentTypes.AddObject(OBJ)
                                SavedResultsCount += 1
                            End If
                        Case GetType(PersonName)
                            Dim OBJ = CType(DeserializedOBJ, PersonName)
                            If (From Test In (LMISDb).PersonNames Where Test.ID = OBJ.ID Select Test).Count = 0 Then
                                LMISDb.PersonNames.AddObject(OBJ)
                                SavedResultsCount += 1
                            End If
                        Case GetType(Person)
                            Dim OBJ = CType(DeserializedOBJ, Person)
                            If (From Test In (LMISDb).People Where Test.ID = OBJ.ID Select Test).Count = 0 Then
                                LMISDb.People.AddObject(OBJ)
                                SavedResultsCount += 1
                            End If
                            'Case GetType(Employee)
                            '    Dim OBJ = CType(DeserializedOBJ, Employee)
                            '    If (From Test In (LMISDb).Employees Where Test.ID = OBJ.ID Select Test).Count = 0 Then
                            '        OBJ.ID = Nothing
                            '        LMISDb.Employees.AddObject(OBJ)
                            '        SavedResultsCount += 1
                            '    End If
                        Case GetType(Supplier)
                            Dim OBJ = CType(DeserializedOBJ, Supplier)
                            If (From Test In (LMISDb).Suppliers Where Test.ID = OBJ.ID Select Test).Count = 0 Then
                                LMISDb.Suppliers.AddObject(OBJ)
                                SavedResultsCount += 1
                            End If
                        Case GetType(Room)
                            Dim OBJ = CType(DeserializedOBJ, Room)
                            If (From Test In (LMISDb).Rooms Where Test.ID = OBJ.ID Select Test).Count = 0 Then
                                LMISDb.Rooms.AddObject(OBJ)
                                SavedResultsCount += 1
                            End If
                        Case GetType(Bed)
                            Dim OBJ = CType(DeserializedOBJ, Bed)
                            If (From Test In (LMISDb).Beds Where Test.ID = OBJ.ID Select Test).Count = 0 Then
                                LMISDb.Beds.AddObject(OBJ)
                                SavedResultsCount += 1
                            End If
                    End Select
                End If
                PGB_Progress.Value += 1
            Next
            PGB_Progress.Value = PGB_Progress.Maximum
            LMISDb.SaveChanges()
            LBL_Count.Text = "Number of Records Saved: " & SavedResultsCount
            'Transaction.Complete()
            'End Using
            Return True
        Catch ex As Exception
            ' MsgBox(testd)
            MessageBox.Show("Error:" & vbCrLf & ex.Message & Utility.InnerExecption(ex), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try
        Return False
    End Function

    Private Sub ClearForm(ByVal NameClear As Boolean)

    End Sub

    Private Sub SetError(ByVal ErrorControl As Control, ByVal ErrorText As String, ByRef NoError As Boolean)
        NoError = False
        ERP_Error.SetError(ErrorControl, ErrorText)
    End Sub

#End Region

#Region "Events"

    Private Sub BTN_Close_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTN_Close.Click
        Me.Close()
    End Sub

    Private Sub BTN_Export_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTN_Import.Click
        ''SerializeToBinaryStream()
        'ReadFromBinaryStream()
        'Exit Sub
        If ValidateDataForm() Then
            Me.Cursor = Cursors.WaitCursor
            If SaveData() Then
                MessageBox.Show("  Data Successfully Imported   ", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                LoadForm()
            Else
                MessageBox.Show("  Data has not been Imported    ", "Error in Saving", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
            Me.Cursor = Cursors.Default
        End If
    End Sub

    Private Sub BTN_Brows_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTN_Browse.Click
        OPF_ImportFile.ShowDialog()
        TBX_ImportFile.Text = OPF_ImportFile.FileName
    End Sub

#End Region

End Class

