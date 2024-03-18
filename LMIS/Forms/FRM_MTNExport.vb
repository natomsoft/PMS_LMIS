Imports System.Data.Objects
Imports System.IO
Imports System.Runtime.Serialization.XmlObjectSerializer
Imports System.Xml.Serialization
Imports System.Transactions

Public Class FRM_MTNExport

    Public Sub New()
        InitializeComponent()
        Me.MdiParent = FRM_GLBMain
        LoadForm()
    End Sub

#Region "Utilities"

    Private Sub LoadForm()
        Try
            Dim LMISDb As New LMISEntities
            If FRM_GLBMain.ApplicationConfig.Employee.EmployeeType.Name = "Administrator" Then
                CMBX_ExportType.DataSource = {"Transactions", "Facilities", "Catalogues", "Institutes", "Adjustment Types", "Names", "Person", "Health Worker", "Suppliers"}
            ElseIf FRM_GLBMain.ApplicationConfig.Employee.EmployeeType.Name = "Super Users" Then
                CMBX_ExportType.DataSource = {"Transactions"}
            End If
            ClearForm(True)
        Catch ex As Exception
            MessageBox.Show("Error:" & vbCrLf & ex.Message & Utility.InnerExecption(ex), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Function ValidateDataForm() As Boolean
        ERP_Error.Clear()
        Dim No_Error As Boolean = True
        If CMBX_ExportType.SelectedItem Is Nothing Then SetError(CMBX_ExportType, "Select the object to export", No_Error)
        If TBX_ExportFile.Text = String.Empty Then SetError(TBX_ExportFile, "A file should be selected for exporting data", No_Error)
        Return No_Error
    End Function

    Private Function SaveData() As Boolean
        Try
            Dim LMISDb As New LMISEntities
            PGB_Progress.Value = 0
            'Using Transaction As New TransactionScope(TransactionScopeOption.RequiresNew)
            Using ToFile As StreamWriter = New StreamWriter(TBX_ExportFile.Text)
                ToFile.Write("<?xml version='1.0'?><LMISExportedData FromDate='" & DTP_FromDate.Value & "' ToDate='" & DTP_ToDate.Value & "'>")
                Select Case CMBX_ExportType.Text
                    Case "Transactions"
                        Dim Counter = From CNT In LMISDb.InventoryJournals Where CNT.DepartmentID = FRM_GLBMain.ApplicationConfig.ThisDepartment.ID And (CNT.TransactionDate >= DTP_FromDate.Value And CNT.TransactionDate <= DTP_ToDate.Value) Select CNT.ID
                        PGB_Progress.Maximum = Counter.Count

                        Dim RequestData = From Req In LMISDb.Requests Select Req Where Req.InventoryJournal.DepartmentID = FRM_GLBMain.ApplicationConfig.ThisDepartment.ID And (Req.InventoryJournal.TransactionDate >= DTP_FromDate.Value And Req.InventoryJournal.TransactionDate <= DTP_ToDate.Value)
                        For Each Request In RequestData
                            PGB_Progress.Value += 1
                            SerializeNSave(ToFile, {Request.InventoryJournal.Employee.Person.PersonName})
                            SerializeNSave(ToFile, {Request.InventoryJournal.Employee.Person.PersonName1})
                            SerializeNSave(ToFile, {Request.InventoryJournal.Employee.Person.PersonName2})
                            SerializeNSave(ToFile, {Request.InventoryJournal.Employee.Person})
                            SerializeNSave(ToFile, {Request.InventoryJournal.Employee})
                            SerializeNSave(ToFile, {Request.InventoryJournal})
                            SerializeNSave(ToFile, DataHarvestor(Request.InventoryJournalID, HarvestTypes.IJD))
                            SerializeNSave(ToFile, {Request})
                        Next
                        Dim ReceiveData = From Rec In LMISDb.Recieves Select Rec Where Rec.InventoryJournal.DepartmentID = FRM_GLBMain.ApplicationConfig.ThisDepartment.ID And (Rec.InventoryJournal.TransactionDate >= DTP_FromDate.Value And Rec.InventoryJournal.TransactionDate <= DTP_ToDate.Value)
                        For Each Receive In ReceiveData
                            PGB_Progress.Value += 1
                            SerializeNSave(ToFile, {Receive.InventoryJournal.Employee.Person.PersonName})
                            SerializeNSave(ToFile, {Receive.InventoryJournal.Employee.Person.PersonName1})
                            SerializeNSave(ToFile, {Receive.InventoryJournal.Employee.Person.PersonName2})
                            SerializeNSave(ToFile, {Receive.InventoryJournal.Employee.Person})
                            SerializeNSave(ToFile, {Receive.InventoryJournal.Employee})
                            SerializeNSave(ToFile, {Receive.InventoryJournal})
                            SerializeNSave(ToFile, DataHarvestor(Receive.InventoryJournalID, HarvestTypes.IJD))
                            SerializeNSave(ToFile, {Receive})
                        Next
                        Dim RequisitionData = From Rec In LMISDb.Requisitions Select Rec Where Rec.InventoryJournal.DepartmentID = FRM_GLBMain.ApplicationConfig.ThisDepartment.ID And (Rec.InventoryJournal.TransactionDate >= DTP_FromDate.Value And Rec.InventoryJournal.TransactionDate <= DTP_ToDate.Value)
                        For Each Requisition In RequisitionData
                            PGB_Progress.Value += 1
                            SerializeNSave(ToFile, {Requisition.InventoryJournal.Employee.Person.PersonName})
                            SerializeNSave(ToFile, {Requisition.InventoryJournal.Employee.Person.PersonName1})
                            SerializeNSave(ToFile, {Requisition.InventoryJournal.Employee.Person.PersonName2})
                            SerializeNSave(ToFile, {Requisition.InventoryJournal.Employee.Person})
                            SerializeNSave(ToFile, {Requisition.InventoryJournal.Employee})
                            SerializeNSave(ToFile, {Requisition.InventoryJournal})
                            SerializeNSave(ToFile, DataHarvestor(Requisition.InventoryJournalID, HarvestTypes.IJD))
                            SerializeNSave(ToFile, {Requisition})
                        Next
                        Dim IssueData = From Rec In LMISDb.Issues Select Rec Where Rec.InventoryJournal.DepartmentID = FRM_GLBMain.ApplicationConfig.ThisDepartment.ID And (Rec.InventoryJournal.TransactionDate >= DTP_FromDate.Value And Rec.InventoryJournal.TransactionDate <= DTP_ToDate.Value)
                        For Each Issue In IssueData
                            PGB_Progress.Value += 1
                            SerializeNSave(ToFile, {Issue.InventoryJournal.Employee.Person.PersonName})
                            SerializeNSave(ToFile, {Issue.InventoryJournal.Employee.Person.PersonName1})
                            SerializeNSave(ToFile, {Issue.InventoryJournal.Employee.Person.PersonName2})
                            SerializeNSave(ToFile, {Issue.InventoryJournal.Employee.Person})
                            SerializeNSave(ToFile, {Issue.InventoryJournal.Employee})
                            SerializeNSave(ToFile, {Issue.InventoryJournal})
                            SerializeNSave(ToFile, DataHarvestor(Issue.InventoryJournalID, HarvestTypes.IJD))
                            SerializeNSave(ToFile, {Issue})
                        Next
                        Dim AdjustmentData = From Rec In LMISDb.Adjustments Select Rec Where Rec.InventoryJournal.DepartmentID = FRM_GLBMain.ApplicationConfig.ThisDepartment.ID And (Rec.InventoryJournal.TransactionDate >= DTP_FromDate.Value And Rec.InventoryJournal.TransactionDate <= DTP_ToDate.Value)
                        For Each Adjustment In AdjustmentData
                            PGB_Progress.Value += 1
                            SerializeNSave(ToFile, {Adjustment.InventoryJournal.Employee.Person.PersonName})
                            SerializeNSave(ToFile, {Adjustment.InventoryJournal.Employee.Person.PersonName1})
                            SerializeNSave(ToFile, {Adjustment.InventoryJournal.Employee.Person.PersonName2})
                            SerializeNSave(ToFile, {Adjustment.InventoryJournal.Employee.Person})
                            SerializeNSave(ToFile, {Adjustment.InventoryJournal.Employee})
                            SerializeNSave(ToFile, {Adjustment.InventoryJournal})
                            SerializeNSave(ToFile, DataHarvestor(Adjustment.InventoryJournalID, HarvestTypes.IJD))
                            SerializeNSave(ToFile, {Adjustment})
                        Next
                        'Dim OPDReqData = From Rec In LMISDb.OPDRequisitions Select Rec Where Rec.InventoryJournal.DepartmentID = FRM_GLBMain.ApplicationConfig.ThisDepartment.ID And (Rec.InventoryJournal.TransactionDate >= DTP_FromDate.Value And Rec.InventoryJournal.TransactionDate <= DTP_ToDate.Value)
                        'For Each OPDReq In OPDReqData
                        '    PGB_Progress.Value += 1
                        '    SerializeNSave(ToFile, {OPDReq.InventoryJournal})
                        '    SerializeNSave(ToFile, DataHarvestor(OPDReq.InvetoryJournalID, HarvestTypes.IJD))
                        '    SerializeNSave(ToFile, {OPDReq})
                        'Next
                        Dim OPDIssueData = From Rec In LMISDb.OPDIssues Select Rec Where Rec.InventoryJournal.DepartmentID = FRM_GLBMain.ApplicationConfig.ThisDepartment.ID And (Rec.InventoryJournal.TransactionDate >= DTP_FromDate.Value And Rec.InventoryJournal.TransactionDate <= DTP_ToDate.Value)
                        For Each OPDIssue In OPDIssueData
                            PGB_Progress.Value += 1
                            SerializeNSave(ToFile, {OPDIssue.InventoryJournal.Employee.Person.PersonName})
                            SerializeNSave(ToFile, {OPDIssue.InventoryJournal.Employee.Person.PersonName1})
                            SerializeNSave(ToFile, {OPDIssue.InventoryJournal.Employee.Person.PersonName2})
                            SerializeNSave(ToFile, {OPDIssue.InventoryJournal.Employee.Person})
                            SerializeNSave(ToFile, {OPDIssue.InventoryJournal.Employee})
                            SerializeNSave(ToFile, {OPDIssue.OPDRequisition.Person.PersonName})
                            SerializeNSave(ToFile, {OPDIssue.OPDRequisition.Person.PersonName1})
                            SerializeNSave(ToFile, {OPDIssue.OPDRequisition.Person.PersonName2})
                            SerializeNSave(ToFile, {OPDIssue.OPDRequisition.Person})
                            SerializeNSave(ToFile, {OPDIssue.OPDRequisition.PaymentAdminOPDs})
                            SerializeNSave(ToFile, {OPDIssue.OPDRequisition.SickReportOPDs})
                            SerializeNSave(ToFile, {OPDIssue.OPDRequisition.PaymentType})
                            SerializeNSave(ToFile, {OPDIssue.OPDRequisition})
                            SerializeNSave(ToFile, {OPDIssue.InventoryJournal})
                            SerializeNSave(ToFile, DataHarvestor(OPDIssue.InvetoryJournalID, HarvestTypes.IJD))
                            SerializeNSave(ToFile, {OPDIssue})
                        Next
                        'Dim IPDReqData = From Rec In LMISDb.IPDRequisitions Select Rec Where Rec.InventoryJournal.DepartmentID = FRM_GLBMain.ApplicationConfig.ThisDepartment.ID And (Rec.InventoryJournal.TransactionDate >= DTP_FromDate.Value And Rec.InventoryJournal.TransactionDate <= DTP_ToDate.Value)
                        'For Each IPDReq In IPDReqData
                        '    PGB_Progress.Value += 1
                        '    SerializeNSave(ToFile, {IPDReq.InventoryJournal})
                        '    SerializeNSave(ToFile, DataHarvestor(IPDReq.InventoryJournalID, HarvestTypes.IJD))
                        '    SerializeNSave(ToFile, {IPDReq})
                        'Next
                        Dim IPDIssueData = From Rec In LMISDb.IPDIssues Select Rec Where Rec.InventoryJournal.DepartmentID = FRM_GLBMain.ApplicationConfig.ThisDepartment.ID And (Rec.InventoryJournal.TransactionDate >= DTP_FromDate.Value And Rec.InventoryJournal.TransactionDate <= DTP_ToDate.Value)
                        For Each IPDIssue In IPDIssueData
                            PGB_Progress.Value += 1
                            SerializeNSave(ToFile, {IPDIssue.InventoryJournal.Employee.Person.PersonName})
                            SerializeNSave(ToFile, {IPDIssue.InventoryJournal.Employee.Person.PersonName1})
                            SerializeNSave(ToFile, {IPDIssue.InventoryJournal.Employee.Person.PersonName2})
                            SerializeNSave(ToFile, {IPDIssue.InventoryJournal.Employee.Person})
                            SerializeNSave(ToFile, {IPDIssue.InventoryJournal.Employee})
                            SerializeNSave(ToFile, {IPDIssue.IPDRequisition.Patient.Person.PersonName})
                            SerializeNSave(ToFile, {IPDIssue.IPDRequisition.Patient.Person.PersonName1})
                            SerializeNSave(ToFile, {IPDIssue.IPDRequisition.Patient.Person.PersonName2})
                            SerializeNSave(ToFile, {IPDIssue.IPDRequisition.Patient.Person})
                            SerializeNSave(ToFile, {IPDIssue.IPDRequisition.Patient})
                            SerializeNSave(ToFile, {IPDIssue.IPDRequisition.Bed.Room})
                            SerializeNSave(ToFile, {IPDIssue.IPDRequisition.Bed})
                            SerializeNSave(ToFile, {IPDIssue.IPDRequisition.PaymentAdminIPDs})
                            SerializeNSave(ToFile, {IPDIssue.IPDRequisition.SickReportIPDs})
                            SerializeNSave(ToFile, {IPDIssue.IPDRequisition.PaymentType})
                            SerializeNSave(ToFile, {IPDIssue.IPDRequisition})
                            SerializeNSave(ToFile, {IPDIssue.InventoryJournal})
                            SerializeNSave(ToFile, DataHarvestor(IPDIssue.InventoryJournalID, HarvestTypes.IJD))
                            SerializeNSave(ToFile, {IPDIssue})
                        Next
                        PGB_Progress.Value = PGB_Progress.Maximum
                    Case "Facilities"
                        Dim Departments = From Rec In LMISDb.Departments Select Rec
                        PGB_Progress.Value = 0
                        PGB_Progress.Maximum = Departments.Count
                        For Each Department In Departments
                            PGB_Progress.Value += 1
                            Department.DepartmentType = Nothing
                            Department.DepartmentTypeReference = Nothing
                            Dim d As Department = Department.CreateDepartment(Department.ID, Department.Name, Department.FacilityID, Department.DepartmentTypeID, Department.LevelofUseID, Department.Active)
                            SerializeNSave(ToFile, {Department.Facility})
                            SerializeNSave(ToFile, {d})
                        Next
                        PGB_Progress.Value = PGB_Progress.Maximum
                    Case "Catalogues"
                        Dim InvetoryItems = From Rec In LMISDb.InventoryItems Select Rec
                        PGB_Progress.Value = 0
                        PGB_Progress.Maximum = InvetoryItems.Count
                        For Each InvetoryItem In InvetoryItems
                            PGB_Progress.Value += 1
                            SerializeNSave(ToFile, {InvetoryItem.ItemsCatalogue})
                            SerializeNSave(ToFile, {InvetoryItem})
                        Next
                        PGB_Progress.Value = PGB_Progress.Maximum
                        PGB_Progress.Value = PGB_Progress.Maximum
                    Case "Institutes"
                        Dim Companies = From Rec In LMISDb.Companies Select Rec
                        PGB_Progress.Value = 0
                        PGB_Progress.Maximum = Companies.Count
                        For Each Company In Companies
                            PGB_Progress.Value += 1
                            SerializeNSave(ToFile, {Company})
                        Next
                        PGB_Progress.Value = PGB_Progress.Maximum
                    Case "Adjustment Types"
                        Dim AdjTypes = From Rec In LMISDb.AdjustmentTypes Select Rec
                        PGB_Progress.Value = 0
                        PGB_Progress.Maximum = AdjTypes.Count
                        For Each AdjType In AdjTypes
                            PGB_Progress.Value += 1
                            SerializeNSave(ToFile, {AdjType})
                        Next
                        PGB_Progress.Value = PGB_Progress.Maximum
                    Case "Names"
                        Dim Names = From Rec In LMISDb.PersonNames Select Rec
                        PGB_Progress.Value = 0
                        PGB_Progress.Maximum = Names.Count
                        For Each Name1 In Names
                            PGB_Progress.Value += 1
                            SerializeNSave(ToFile, {Name1})
                        Next
                        PGB_Progress.Value = PGB_Progress.Maximum
                    Case "Person"
                        Dim People = From Rec In LMISDb.People Select Rec
                        PGB_Progress.Value = 0
                        PGB_Progress.Maximum = People.Count
                        For Each Person In People
                            PGB_Progress.Value += 1
                            SerializeNSave(ToFile, {Person.PersonName, Person.PersonName1, Person.PersonName2})
                            SerializeNSave(ToFile, {Person})
                        Next
                        PGB_Progress.Value = PGB_Progress.Maximum
                    Case "Health Worker"
                        Dim Employees = From Rec In LMISDb.Employees Select Rec
                        PGB_Progress.Value = 0
                        PGB_Progress.Maximum = Employees.Count
                        For Each Employee In Employees
                            PGB_Progress.Value += 1
                            SerializeNSave(ToFile, {Employee.Person.PersonName, Employee.Person.PersonName1, Employee.Person.PersonName2})
                            SerializeNSave(ToFile, {Employee.Person})
                            SerializeNSave(ToFile, {Employee})
                        Next
                        PGB_Progress.Value = PGB_Progress.Maximum
                    Case "Suppliers"
                        Dim Suppliers = From Rec In LMISDb.Suppliers Select Rec
                        PGB_Progress.Value = 0
                        PGB_Progress.Maximum = Suppliers.Count
                        For Each Supplier In Suppliers
                            PGB_Progress.Value += 1
                            SerializeNSave(ToFile, {Supplier.Company})
                            SerializeNSave(ToFile, {Supplier.Person.PersonName, Supplier.Person.PersonName1, Supplier.Person.PersonName2, Supplier.Person})
                            SerializeNSave(ToFile, {Supplier})
                        Next
                        PGB_Progress.Value = PGB_Progress.Maximum
                End Select
                ToFile.Write("</LMISExportedData>")
                'Transaction.Complete()
                Return True
                'End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error:" & vbCrLf & ex.Message & Utility.InnerExecption(ex), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try
        Return False
    End Function

    Private Sub SerializeNSave(ByRef WriteToFile As StreamWriter, ByVal WriteObjects() As Object)
        If WriteObjects IsNot Nothing Then
            For Each WriteObject As Object In WriteObjects
                If WriteObject IsNot Nothing Then
                    Dim TempData As New MemoryStream
                    Dim OBJSerializer As New XmlSerializer(WriteObject.GetType())
                    OBJSerializer.Serialize(TempData, WriteObject)
                    TempData.Seek(0, IO.SeekOrigin.Begin)
                    WriteToFile.Write(XElement.Load(TempData).ToString(System.Xml.Linq.SaveOptions.DisableFormatting))
                End If
            Next
        End If
    End Sub

    Private Function DataHarvestor(ByVal ID As String, ByVal HarvestType As HarvestTypes) As Object()
        Dim OBJS(0) As Object
        Select Case HarvestType
            Case HarvestTypes.IJD
                Dim IJDOBJS = From IJD In (New LMISEntities).InventoryJournalDetails Where IJD.InventoryJournalID = ID Select IJD
                For Each IJDOBJ In IJDOBJS
                    IJDOBJ.InventoryItemReference.Value = Nothing
                    RedimNAssign(OBJS, IJDOBJ)
                    Dim IJDID As String = IJDOBJ.ID
                    Dim IJDBOBJ = From IJDB In (New LMISEntities).InventoryJournalDetailsBatches Where IJDB.InventoryJournaDetaillID = IJDID Select IJDB
                    If IJDBOBJ.Count > 0 Then
                        RedimNAssign(OBJS, IJDBOBJ.First.InventoryBatch)
                        RedimNAssign(OBJS, IJDBOBJ.First.Location.Store)
                        RedimNAssign(OBJS, IJDBOBJ.First.Location)
                        RedimNAssign(OBJS, IJDBOBJ.First)
                    End If
                    Dim ConsumedOBJ = From Consu In (New LMISEntities).ConsumedItems Where Consu.InventoryJournalDetailID = IJDID Select Consu
                    If ConsumedOBJ.Count > 0 Then RedimNAssign(OBJS, ConsumedOBJ.First)
                Next
                Return OBJS
            Case Else
                Return Nothing
        End Select
    End Function

    Private Sub RedimNAssign(ByRef OBJS() As Object, ByVal AssignOBJ As Object)
        If AssignOBJ IsNot Nothing And OBJS IsNot Nothing Then
            OBJS(OBJS.Count - 1) = AssignOBJ
            ReDim Preserve OBJS(OBJS.Count)
        End If
    End Sub

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

    Private Sub BTN_Export_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTN_Export.Click
        If ValidateDataForm() Then
            Me.Cursor = Cursors.WaitCursor
            If SaveData() Then
                MessageBox.Show("  Data Successfully Exported   ", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                LoadForm()
            Else
                MessageBox.Show("  Data has not been Exported    ", "Error in Saving", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
            Me.Cursor = Cursors.Default
        End If
    End Sub

    Private Sub BTN_Brows_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTN_Brows.Click
        SFD_ExportFile.ShowDialog()
        TBX_ExportFile.Text = SFD_ExportFile.FileName
    End Sub

    Private Sub DTP_ItemExpiry_From_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DTP_FromDate.ValueChanged
        DTP_ToDate.MinDate = DTP_FromDate.Value
    End Sub

    Private Sub DTP_ItemExpiry_To_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DTP_ToDate.ValueChanged
        DTP_FromDate.MaxDate = DTP_ToDate.Value
    End Sub

#End Region

End Class

Enum HarvestTypes
    IJD
End Enum