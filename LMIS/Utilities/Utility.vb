Imports System.Data.Objects
Public Class Utility

    Shared Function GenerateID(ByVal Type As IDTypes) As String
        Try
            Dim LMISDb As New LMISEntities
            Dim ID As Double
            Select Case Type
                Case IDTypes.IJ
                    Dim MaxID = From IJ In LMISDb.InventoryJournals
                                Order By IJ.ID Descending
                                Select IJ
                                Where IJ.DepartmentID = FRM_GLBMain.ApplicationConfig.ThisDepartment.ID
                    If (MaxID.Count = 0) Then
                        Return FRM_GLBMain.ApplicationConfig.ThisDepartment.ID & "00001"
                    Else
                        ID = Double.Parse(MaxID.First.ID) + 1
                    End If
                Case IDTypes.Request
                    Dim MaxID = From IJ In LMISDb.Requests
                                Order By IJ.ID Descending
                                Select IJ
                                Where IJ.InventoryJournal.DepartmentID = FRM_GLBMain.ApplicationConfig.ThisDepartment.ID
                    If (MaxID.Count = 0) Then
                        Return FRM_GLBMain.ApplicationConfig.ThisDepartment.ID & "00001"
                    Else
                        ID = Double.Parse(MaxID.First.ID) + 1
                    End If
                Case IDTypes.Receive
                    Dim MaxID = From IJ In LMISDb.Recieves
                                Order By IJ.ID Descending
                                Select IJ
                                Where IJ.InventoryJournal.DepartmentID = FRM_GLBMain.ApplicationConfig.ThisDepartment.ID
                    If (MaxID.Count = 0) Then
                        Return FRM_GLBMain.ApplicationConfig.ThisDepartment.ID & "00001"
                    Else
                        ID = Double.Parse(MaxID.First.ID) + 1
                    End If
                Case IDTypes.Requisition
                    Dim MaxID = From IJ In LMISDb.Requisitions
                                Order By IJ.ID Descending
                                Select IJ
                                Where IJ.InventoryJournal.DepartmentID = FRM_GLBMain.ApplicationConfig.ThisDepartment.ID
                    If (MaxID.Count = 0) Then
                        Return FRM_GLBMain.ApplicationConfig.ThisDepartment.ID & "00001"
                    Else
                        ID = Double.Parse(MaxID.First.ID) + 1
                    End If
                Case IDTypes.Issue
                    Dim MaxID = From IJ In LMISDb.Issues
                                Order By IJ.ID Descending
                                Select IJ
                                Where IJ.InventoryJournal.DepartmentID = FRM_GLBMain.ApplicationConfig.ThisDepartment.ID
                    If (MaxID.Count = 0) Then
                        Return FRM_GLBMain.ApplicationConfig.ThisDepartment.ID & "00001"
                    Else
                        ID = Double.Parse(MaxID.First.ID) + 1
                    End If
                Case IDTypes.Adjustment
                    Dim MaxID = From IJ In LMISDb.Adjustments
                                Order By IJ.ID Descending
                                Select IJ
                                Where IJ.InventoryJournal.DepartmentID = FRM_GLBMain.ApplicationConfig.ThisDepartment.ID
                    If (MaxID.Count = 0) Then
                        Return FRM_GLBMain.ApplicationConfig.ThisDepartment.ID & "00001"
                    Else
                        ID = Double.Parse(MaxID.First.ID) + 1
                    End If
                Case IDTypes.OPDIssue
                    Dim MaxID = From IJ In LMISDb.OPDIssues
                                Order By IJ.ID Descending
                                Select IJ
                                Where IJ.InventoryJournal.DepartmentID = FRM_GLBMain.ApplicationConfig.ThisDepartment.ID
                    If (MaxID.Count = 0) Then
                        Return FRM_GLBMain.ApplicationConfig.ThisDepartment.ID & "00001"
                    Else
                        ID = Double.Parse(MaxID.First.ID) + 1
                    End If
                Case IDTypes.OPDRequisition
                    Dim MaxID = From IJ In (From OPDReq In LMISDb.OPDRequisitions
                                    Join OPDIss In LMISDb.OPDIssues
                                        On OPDIss.OPDRequisitionID Equals OPDReq.ID
                                    Where OPDIss.InventoryJournal.DepartmentID = FRM_GLBMain.ApplicationConfig.ThisDepartment.ID
                                    Select OPDReq).Union(From OPDReq In LMISDb.OPDRequisitions
                                    Where OPDReq.InventoryJournal.DepartmentID = FRM_GLBMain.ApplicationConfig.ThisDepartment.ID
                                    Select OPDReq)
                                Order By IJ.ID Descending
                                Select IJ
                    If (MaxID.Count = 0) Then
                        Return FRM_GLBMain.ApplicationConfig.ThisDepartment.ID & "00001"
                    Else
                        ID = Double.Parse(MaxID.First.ID) + 1
                    End If
                Case IDTypes.IPDIssue
                    Dim MaxID = From IJ In LMISDb.IPDIssues
                                Order By IJ.ID Descending
                                Select IJ
                                Where IJ.InventoryJournal.DepartmentID = FRM_GLBMain.ApplicationConfig.ThisDepartment.ID
                    If (MaxID.Count = 0) Then
                        Return FRM_GLBMain.ApplicationConfig.ThisDepartment.ID & "00001"
                    Else
                        ID = Double.Parse(MaxID.First.ID) + 1
                    End If
                Case IDTypes.GRN
                    Dim MaxID = From IJ In LMISDb.GRNs
                                Order By IJ.ID Descending
                                Select IJ
                                Where IJ.InventoryJournal.DepartmentID = FRM_GLBMain.ApplicationConfig.ThisDepartment.ID
                    If (MaxID.Count = 0) Then
                        Return FRM_GLBMain.ApplicationConfig.ThisDepartment.ID & "00001"
                    Else
                        ID = Double.Parse(MaxID.First.ID) + 1
                    End If
                Case IDTypes.Transfers
                    Dim MaxID = From IJ In LMISDb.Transfers
                                Order By IJ.ID Descending
                                Select IJ
                                Where IJ.InventoryJournal.DepartmentID = FRM_GLBMain.ApplicationConfig.ThisDepartment.ID
                    If (MaxID.Count = 0) Then
                        Return FRM_GLBMain.ApplicationConfig.ThisDepartment.ID & "00001"
                    Else
                        ID = Double.Parse(MaxID.First.ID) + 1
                    End If
                Case IDTypes.IPDRequisition
                    Dim MaxID = From IJ In (From IPDReq In LMISDb.IPDRequisitions
                                    Join IPDIss In LMISDb.IPDIssues
                                        On IPDIss.IPDRequisitionID Equals IPDReq.ID
                                    Where IPDIss.InventoryJournal.DepartmentID = FRM_GLBMain.ApplicationConfig.ThisDepartment.ID
                                    Select IPDReq).Union(From IPDReq In LMISDb.IPDRequisitions
                                    Where IPDReq.InventoryJournal.DepartmentID = FRM_GLBMain.ApplicationConfig.ThisDepartment.ID
                                    Select IPDReq)
                                Order By IJ.ID Descending
                                Select IJ
                    If (MaxID.Count = 0) Then
                        Return FRM_GLBMain.ApplicationConfig.ThisDepartment.ID & "00001"
                    Else
                        ID = Double.Parse(MaxID.First.ID) + 1
                    End If
                Case IDTypes.SickReportIPD
                    Dim MaxID = From IJ In LMISDb.SickReportIPDs
                                Order By IJ.ID Descending
                                Where IJ.ID.StartsWith(FRM_GLBMain.ApplicationConfig.ThisDepartment.ID)
                                Select IJ
                    If (MaxID.Count = 0) Then
                        Return FRM_GLBMain.ApplicationConfig.ThisDepartment.ID & "00001"
                    Else
                        ID = Double.Parse(MaxID.First.ID) + 1
                    End If
                Case IDTypes.SickReportOPD
                    Dim MaxID = From IJ In LMISDb.SickReportOPDs
                                Order By IJ.ID Descending
                                Where IJ.ID.StartsWith(FRM_GLBMain.ApplicationConfig.ThisDepartment.ID)
                                Select IJ
                    If (MaxID.Count = 0) Then
                        Return FRM_GLBMain.ApplicationConfig.ThisDepartment.ID & "00001"
                    Else
                        ID = Double.Parse(MaxID.First.ID) + 1
                    End If

                Case IDTypes.PaymentAdminIPD
                    Dim MaxID = From IJ In LMISDb.PaymentAdminIPDs
                                Order By IJ.ID Descending
                                Where IJ.ID.StartsWith(FRM_GLBMain.ApplicationConfig.ThisDepartment.ID)
                                Select IJ
                    If (MaxID.Count = 0) Then
                        Return FRM_GLBMain.ApplicationConfig.ThisDepartment.ID & "00001"
                    Else
                        ID = Double.Parse(MaxID.First.ID) + 1
                    End If
                Case IDTypes.PaymentAdminOPD
                    Dim MaxID = From IJ In LMISDb.PaymentAdminOPDs
                                Order By IJ.ID Descending
                                Where IJ.ID.StartsWith(FRM_GLBMain.ApplicationConfig.ThisDepartment.ID)
                                Select IJ
                    If (MaxID.Count = 0) Then
                        Return FRM_GLBMain.ApplicationConfig.ThisDepartment.ID & "00001"
                    Else
                        ID = Double.Parse(MaxID.First.ID) + 1
                    End If
                Case IDTypes.Person
                    Dim DepaID As String = FRM_GLBMain.ApplicationConfig.ThisDepartment.ID
                    Dim MaxID = From IJ In LMISDb.People
                                Order By IJ.ID Descending
                                Select IJ
                                Where IJ.ID.StartsWith(DepaID)
                    If (MaxID.Count = 0) Then
                        Return FRM_GLBMain.ApplicationConfig.ThisDepartment.ID & "00001"
                    Else
                        ID = Double.Parse(MaxID.First.ID) + 1
                    End If
                Case IDTypes.Patient
                    Dim DepaID As String = FRM_GLBMain.ApplicationConfig.ThisDepartment.ID
                    Dim MaxID = From IJ In LMISDb.Patients
                                Order By IJ.ID Descending
                                Select IJ
                                Where IJ.ID.StartsWith(DepaID)
                    If (MaxID.Count = 0) Then
                        Return FRM_GLBMain.ApplicationConfig.ThisDepartment.ID & "00001"
                    Else
                        ID = Double.Parse(MaxID.First.ID) + 1
                    End If
                Case IDTypes.Supplier
                    Dim MaxID = From IJ In LMISDb.Suppliers
                                Order By IJ.ID Descending
                                Select IJ

                    If (MaxID.Count = 0) Then
                        Return "001"
                    Else
                        ID = Double.Parse(MaxID.First.ID) + 1
                    End If
                Case IDTypes.Rooms
                    Dim MaxID = From IJ In LMISDb.Rooms
                                Order By IJ.ID Descending
                                Select IJ
                                Where IJ.ID.StartsWith(FRM_GLBMain.ApplicationConfig.ThisDepartment.ID)
                    If (MaxID.Count = 0) Then
                        Return FRM_GLBMain.ApplicationConfig.ThisDepartment.ID & "00001"
                    Else
                        ID = Double.Parse(MaxID.First.ID) + 1
                    End If
                Case IDTypes.Beds
                    Dim MaxID = From IJ In LMISDb.Beds
                                Order By IJ.ID Descending
                                Select IJ
                                Where IJ.ID.StartsWith(FRM_GLBMain.ApplicationConfig.ThisDepartment.ID)
                    If (MaxID.Count = 0) Then
                        Return FRM_GLBMain.ApplicationConfig.ThisDepartment.ID & "00001"
                    Else
                        ID = Double.Parse(MaxID.First.ID) + 1
                    End If
                Case IDTypes.Names
                    Dim MaxID = From IJ In LMISDb.PersonNames
                                Order By IJ.ID Descending
                                Select IJ
                                Where IJ.ID.StartsWith(FRM_GLBMain.ApplicationConfig.ThisDepartment.ID)
                    If (MaxID.Count = 0) Then
                        Return FRM_GLBMain.ApplicationConfig.ThisDepartment.ID & "00001"
                    Else
                        ID = Double.Parse(MaxID.First.ID) + 1
                    End If
                Case IDTypes.OrdereNAdminister
                    Dim MaxID = From IJ In LMISDb.OrderandAdministers
                                Order By IJ.ID Descending
                                Select IJ
                    If (MaxID.Count = 0) Then
                        Return FRM_GLBMain.ApplicationConfig.ThisDepartment.ID & "00001"
                    Else
                        ID = Double.Parse(MaxID.First.ID) + 1
                    End If
                Case IDTypes.Customer
                    Dim MaxID = From IJ In LMISDb.Customers
                                Order By IJ.ID Descending
                                Select IJ
                    If (MaxID.Count = 0) Then
                        Return FRM_GLBMain.ApplicationConfig.ThisDepartment.ID & "00001"
                    Else
                        ID = Double.Parse(MaxID.First.ID) + 1
                    End If
                Case IDTypes.Store
                    Dim MaxID = From IJ In LMISDb.Stores
                                Order By IJ.ID Descending
                                Select IJ
                                Where IJ.DepartmentID = FRM_GLBMain.ApplicationConfig.ThisDepartment.ID
                    If (MaxID.Count = 0) Then
                        Return FRM_GLBMain.ApplicationConfig.ThisDepartment.ID & "00001"
                    Else
                        ID = Double.Parse(MaxID.First.ID) + 1
                    End If
                Case IDTypes.Location
                    Dim MaxID = From IJ In LMISDb.Locations
                                Order By IJ.ID Descending
                                Select IJ
                                Where IJ.Store.DepartmentID = FRM_GLBMain.ApplicationConfig.ThisDepartment.ID
                    If (MaxID.Count = 0) Then
                        Return FRM_GLBMain.ApplicationConfig.ThisDepartment.ID & "00001"
                    Else
                        ID = Double.Parse(MaxID.First.ID) + 1
                    End If
                Case IDTypes.Employee
                    Dim MaxID = From IJ In LMISDb.Employees
                                Order By IJ.ID Descending
                                Select IJ
                                Where IJ.ID.StartsWith(FRM_GLBMain.ApplicationConfig.ThisDepartment.ID)
                    If (MaxID.Count = 0) Then
                        Return FRM_GLBMain.ApplicationConfig.ThisDepartment.ID & "00001"
                    Else
                        ID = Double.Parse(MaxID.First.ID) + 1
                    End If
                Case Else
                    MessageBox.Show("Error: In generating ID" & vbCrLf & vbCrLf & "No such ID type", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Return Nothing
            End Select
            Return ID
        Catch ex As Exception
            MessageBox.Show("Error: In generating ID" & vbCrLf & ex.Message & Utility.InnerExecption(ex), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return Nothing
        End Try
    End Function

    Shared Function GetMyDepartment() As Department
        Try
            Dim LMISDb As New LMISEntities
            Dim ThisDepartment = From FID In LMISDb.Departments
                                 Where FID.Active = True
                                 Select FID
            If ThisDepartment.Count = 0 Then
                Return Nothing
            ElseIf ThisDepartment.Count > 1 Then
                For Each Depa In ThisDepartment
                    Depa.Active = False
                Next
                LMISDb.SaveChanges()
                Return Nothing
            Else
                Return ThisDepartment.First
            End If
        Catch ex As Exception
            MessageBox.Show("Error: In Getting Department" & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return Nothing
        End Try
    End Function

    Shared Function Get_ItemQtyPending(ByVal ItemID As String) As Double
        Try
            Dim LMISDb As New LMISEntities
            Dim AvailableQIn = From IJD In LMISDb.InventoryJournalDetails
                               Join IJDB In LMISDb.InventoryJournalDetailsBatches
                                    On IJD.ID Equals IJDB.InventoryJournaDetaillID
                        Where IJD.InventoryJournal.InventoryJournalStatu.Name = "Processed" And IJD.InventoryJournal.InventoryJournalType.Type = "In" And IJD.InventoryItem.ID = ItemID And IJD.InventoryJournal.DepartmentID = FRM_GLBMain.ApplicationConfig.ThisDepartment.ID And ((IJDB.InventoryBatch.ExpireDate IsNot Nothing And IJDB.InventoryBatch.ExpireDate > Date.Today) Or (True)) And IJD.InventoryJournal.Void = False
                        Group By IJD.InventoryItem.ID
                        Into SumIn = Sum(IJD.Quantity)
            Dim AvailableQOut = From IJD In LMISDb.InventoryJournalDetails
                               Join IJDB In LMISDb.InventoryJournalDetailsBatches
                                    On IJD.ID Equals IJDB.InventoryJournaDetaillID
                        Where IJD.InventoryJournal.InventoryJournalType.Type = "Out" And ((IJD.InventoryJournal.InventoryJournalStatu.Name = "Processed") Or ((IJD.InventoryJournal.InventoryJournalType.Name = "Issue" And IJD.InventoryJournal.InventoryJournalStatu.Name = "Pending"))) And IJD.InventoryItem.ID = ItemID And IJD.InventoryJournal.DepartmentID = FRM_GLBMain.ApplicationConfig.ThisDepartment.ID And ((IJDB.InventoryBatch.ExpireDate IsNot Nothing And IJDB.InventoryBatch.ExpireDate > Date.Today) Or (True)) And IJD.InventoryJournal.Void = False
                        Group By IJD.InventoryItem.ID
                        Into SumOut = Sum(IJD.Quantity)
            Dim Available As Double = 0
            If Not (AvailableQIn.Count = 0) Then Available = AvailableQIn.First.SumIn
            If Not (AvailableQOut.Count = 0) Then Available = Available - AvailableQOut.First.SumOut
            'MsgBox(AvailableQIn.First.SumIn & " " & AvailableQOut.First.SumOut)
            Return Available
        Catch ex As Exception
            MessageBox.Show("Error: In Getting Item Qty Available" & vbCrLf & ex.Message & vbCrLf & Utility.InnerExecption(ex), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return 0
        End Try
    End Function

    Shared Function IsItemExpires(ByVal ItemID As String) As Boolean
        Try
            Dim LMISDb As New LMISEntities
            Dim Expirable = From IJD In LMISDb.InventoryItems
                               Where IJD.ID = ItemID Select IJD.ItemsCatalogue.Expires
            Dim Available As Double = 0
            If Not (Expirable.Count = 0) Then Return Expirable.First
            Return False
        Catch ex As Exception
            MessageBox.Show("Error: Checking if Item expires." & vbCrLf & ex.Message & vbCrLf & Utility.InnerExecption(ex), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try
    End Function

    Shared Function Get_ItemQty(ByVal ItemID As String) As Double
        Try
            Dim LMISDb As New LMISEntities

            Dim AvailableQIn = From IJD In LMISDb.InventoryJournalDetails
                               Join IJDB In LMISDb.InventoryJournalDetailsBatches
                                    On IJD.ID Equals IJDB.InventoryJournaDetaillID
                        Where IJD.InventoryJournal.InventoryJournalStatu.Name = "Processed" And IJD.InventoryJournal.InventoryJournalType.Type = "In" And IJD.InventoryItem.ID = ItemID And IJD.InventoryJournal.DepartmentID = FRM_GLBMain.ApplicationConfig.ThisDepartment.ID And ((IJDB.InventoryBatch.ExpireDate IsNot Nothing And IJDB.InventoryBatch.ExpireDate > Date.Today) Or (True)) And IJD.InventoryJournal.Void = False
                        Group By IJD.InventoryItem.ID
                        Into SumIn = Sum(IJD.Quantity)
            Dim AvailableQOut = From IJD In LMISDb.InventoryJournalDetails
                               Join IJDB In LMISDb.InventoryJournalDetailsBatches
                                    On IJD.ID Equals IJDB.InventoryJournaDetaillID
                        Where IJD.InventoryJournal.InventoryJournalStatu.Name = "Processed" And IJD.InventoryJournal.InventoryJournalType.Type = "Out" And IJD.InventoryItem.ID = ItemID And IJD.InventoryJournal.DepartmentID = FRM_GLBMain.ApplicationConfig.ThisDepartment.ID And ((IJDB.InventoryBatch.ExpireDate IsNot Nothing And IJDB.InventoryBatch.ExpireDate > Date.Today) Or (True)) And IJD.InventoryJournal.Void = False
                        Group By IJD.InventoryItem.ID
                        Into SumOut = Sum(IJD.Quantity)
            Dim Available As Double = 0
            If Not (AvailableQIn.Count = 0) Then Available = AvailableQIn.First.SumIn
            If Not (AvailableQOut.Count = 0) Then Available = Available - AvailableQOut.First.SumOut
            'MsgBox(AvailableQIn.First.SumIn & " " & AvailableQOut.First.SumOut)
            Return Available
        Catch ex As Exception
            MessageBox.Show("Error: In Getting Item Qty Available" & vbCrLf & ex.Message & vbCrLf & Utility.InnerExecption(ex), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return 0
        End Try
    End Function

    Shared Function Get_ItemQtyBeforeDate(ByVal ItemID As String, ByVal BeforeDate As Date) As Double
        Try
            Dim LMISDb As New LMISEntities
            Dim AvailableQIn = From IJD In LMISDb.InventoryJournalDetails
                               Join IJDB In LMISDb.InventoryJournalDetailsBatches
                                    On IJD.ID Equals IJDB.InventoryJournaDetaillID
                        Where IJD.InventoryJournal.VoucherDate < BeforeDate And IJD.InventoryJournal.InventoryJournalStatu.Name = "Processed" And IJD.InventoryJournal.InventoryJournalType.Type = "In" And IJD.InventoryItem.ID = ItemID And IJD.InventoryJournal.DepartmentID = FRM_GLBMain.ApplicationConfig.ThisDepartment.ID And IJDB.InventoryBatch.ExpireDate > BeforeDate And IJD.InventoryJournal.Void = False
                        Group By IJD.InventoryItem.ID
                        Into SumIn = Sum(IJD.Quantity)
            Dim AvailableQOut = From IJD In LMISDb.InventoryJournalDetails
                               Join IJDB In LMISDb.InventoryJournalDetailsBatches
                                    On IJD.ID Equals IJDB.InventoryJournaDetaillID
                        Where IJD.InventoryJournal.VoucherDate < BeforeDate And IJD.InventoryJournal.InventoryJournalStatu.Name = "Processed" And IJD.InventoryJournal.InventoryJournalType.Type = "Out" And IJD.InventoryItem.ID = ItemID And IJD.InventoryJournal.DepartmentID = FRM_GLBMain.ApplicationConfig.ThisDepartment.ID And IJDB.InventoryBatch.ExpireDate > BeforeDate And IJD.InventoryJournal.Void = False
                        Group By IJD.InventoryItem.ID
                        Into SumOut = Sum(IJD.Quantity)
            Dim Available As Double = 0
            If Not (AvailableQIn.Count = 0) Then Available = AvailableQIn.First.SumIn
            If Not (AvailableQOut.Count = 0) Then Available = Available - AvailableQOut.First.SumOut
            'MsgBox(AvailableQIn.First.SumIn & " " & AvailableQOut.First.SumOut)
            Return Available
        Catch ex As Exception
            MessageBox.Show("Error: In Getting Item Qty Available", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return 0
        End Try
    End Function

    Shared Function Get_ItemQtyInBatch(ByVal BatchNo As String) As Double
        'Try
        Dim LMISDb As New LMISEntities
        Dim AvailableQIn = From IB In LMISDb.InventoryBatches
                                    Join IJDB In LMISDb.InventoryJournalDetailsBatches
                                        On IJDB.InventoryBatchID Equals IB.ID
                                    Join IJD In LMISDb.InventoryJournalDetails
                                        On IJDB.InventoryJournaDetaillID Equals IJD.ID
                                    Join IJ In LMISDb.InventoryJournals
                                        On IJD.InventoryJournalID Equals IJ.ID
                                    Join IJT In LMISDb.InventoryJournalTypes
                                        On IJ.InventoryJournalTypeID Equals IJT.ID
                                    Join IJS In LMISDb.InventoryJournalStatus
                                        On IJ.InventoryJournalStatusID Equals IJS.ID
                                    Where IJ.Void = False And ((IJDB.InventoryBatch.ExpireDate IsNot Nothing And IJDB.InventoryBatch.ExpireDate > Date.Today) Or (True)) And IJT.Type = "In" And IB.ID = BatchNo And IJS.Name = "Processed" And IJ.DepartmentID = FRM_GLBMain.ApplicationConfig.ThisDepartment.ID
                                    Group By IB.ID
                                    Into SumIn = Sum(IJD.Quantity)
        Dim AvailableQOut = From IB In LMISDb.InventoryBatches
                                Join IJDB In LMISDb.InventoryJournalDetailsBatches
                                    On IJDB.InventoryBatchID Equals IB.ID
                                Join IJD In LMISDb.InventoryJournalDetails
                                    On IJDB.InventoryJournaDetaillID Equals IJD.ID
                                Join IJ In LMISDb.InventoryJournals
                                    On IJD.InventoryJournalID Equals IJ.ID
                                Join IJT In LMISDb.InventoryJournalTypes
                                    On IJ.InventoryJournalTypeID Equals IJT.ID
                                Join IJS In LMISDb.InventoryJournalStatus
                                    On IJ.InventoryJournalStatusID Equals IJS.ID
                                Where IJ.Void = False And ((IJDB.InventoryBatch.ExpireDate IsNot Nothing And IJDB.InventoryBatch.ExpireDate > Date.Today) Or (True)) And IJT.Type = "Out" And IB.ID = BatchNo And IJS.Name = "Processed" And IJ.DepartmentID = FRM_GLBMain.ApplicationConfig.ThisDepartment.ID
                                Group By IB.ID
                                Into SumOut = Sum(IJD.Quantity)
        Dim Available As Double = 0
        If Not (AvailableQIn.Count = 0) Then Available = AvailableQIn.First.SumIn
        If Not (AvailableQOut.Count = 0) Then Available = Available - AvailableQOut.First.SumOut

        Return Available
        ' Catch ex As Exception
        'MessageBox.Show("Error: In getting Qty of Items available in a batch", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        ' Return 0
        ' End Try
    End Function

    Shared Function Get_ItemQtyInBatchLocationame(ByVal BatchNo As String, ByVal LocationID As String) As Double

        ' Try
        LocationID = LocationID.Substring(LocationID.IndexOf("|"))
        Dim LMISDb As New LMISEntities
        Dim AvailableQIn = From IB In LMISDb.InventoryBatches
                                Join IJDB In LMISDb.InventoryJournalDetailsBatches
                                    On IJDB.InventoryBatchID Equals IB.ID
                                Join IJD In LMISDb.InventoryJournalDetails
                                    On IJDB.InventoryJournaDetaillID Equals IJD.ID
                                Join IJ In LMISDb.InventoryJournals
                                    On IJD.InventoryJournalID Equals IJ.ID
                                Join IJT In LMISDb.InventoryJournalTypes
                                    On IJ.InventoryJournalTypeID Equals IJT.ID
                                Join IJS In LMISDb.InventoryJournalStatus
                                    On IJ.InventoryJournalStatusID Equals IJS.ID
                                Where IJ.Void = False And ((IJDB.InventoryBatch.ExpireDate IsNot Nothing And IJDB.InventoryBatch.ExpireDate > Date.Today) Or (True)) And IJT.Type = "In" And IB.ID = BatchNo And IJS.Name = "Processed" And IJDB.Location.Name = LocationID And IJ.DepartmentID = FRM_GLBMain.ApplicationConfig.ThisDepartment.ID
                                Group By IB.ID
                                Into SumIn = Sum(IJD.Quantity)
        Dim AvailableQOut = From IB In LMISDb.InventoryBatches
                                Join IJDB In LMISDb.InventoryJournalDetailsBatches
                                    On IJDB.InventoryBatchID Equals IB.ID
                                Join IJD In LMISDb.InventoryJournalDetails
                                    On IJDB.InventoryJournaDetaillID Equals IJD.ID
                                Join IJ In LMISDb.InventoryJournals
                                    On IJD.InventoryJournalID Equals IJ.ID
                                Join IJT In LMISDb.InventoryJournalTypes
                                    On IJ.InventoryJournalTypeID Equals IJT.ID
                                Join IJS In LMISDb.InventoryJournalStatus
                                    On IJ.InventoryJournalStatusID Equals IJS.ID
                                Where IJ.Void = False And ((IJDB.InventoryBatch.ExpireDate IsNot Nothing And IJDB.InventoryBatch.ExpireDate > Date.Today) Or (True)) And IJT.Type = "Out" And IB.ID = BatchNo And IJS.Name = "Processed" And IJDB.Location.Name = LocationID And IJ.DepartmentID = FRM_GLBMain.ApplicationConfig.ThisDepartment.ID
                                Group By IB.ID
                                Into SumOut = Sum(IJD.Quantity)
        Dim Available As Double = 0
        If Not (AvailableQIn.Count = 0) Then Available = AvailableQIn.First.SumIn
        If Not (AvailableQOut.Count = 0) Then Available = Available - AvailableQOut.First.SumOut
        'MsgBox(AvailableQIn.First.SumIn & " " & AvailableQOut.First.SumOut)
        Return Available
        ' Catch ex As Exception
        '     MessageBox.Show("Error: In getting Qty of Items available in a batch", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        '      Return 0
        ' End Try
    End Function


    Shared Function Get_ItemQtyInBatchLocation(ByVal BatchNo As String, ByVal LocationID As String) As Double
        ' Try
        Dim LMISDb As New LMISEntities
        Dim AvailableQIn = From IB In LMISDb.InventoryBatches
                                Join IJDB In LMISDb.InventoryJournalDetailsBatches
                                    On IJDB.InventoryBatchID Equals IB.ID
                                Join IJD In LMISDb.InventoryJournalDetails
                                    On IJDB.InventoryJournaDetaillID Equals IJD.ID
                                Join IJ In LMISDb.InventoryJournals
                                    On IJD.InventoryJournalID Equals IJ.ID
                                Join IJT In LMISDb.InventoryJournalTypes
                                    On IJ.InventoryJournalTypeID Equals IJT.ID
                                Join IJS In LMISDb.InventoryJournalStatus
                                    On IJ.InventoryJournalStatusID Equals IJS.ID
                                Where IJ.Void = False And ((IJDB.InventoryBatch.ExpireDate IsNot Nothing And IJDB.InventoryBatch.ExpireDate > Date.Today) Or (True)) And IJT.Type = "In" And IB.ID = BatchNo And IJS.Name = "Processed" And IJDB.LocationID = LocationID And IJ.DepartmentID = FRM_GLBMain.ApplicationConfig.ThisDepartment.ID
                                Group By IB.ID
                                Into SumIn = Sum(IJD.Quantity)
        Dim AvailableQOut = From IB In LMISDb.InventoryBatches
                                Join IJDB In LMISDb.InventoryJournalDetailsBatches
                                    On IJDB.InventoryBatchID Equals IB.ID
                                Join IJD In LMISDb.InventoryJournalDetails
                                    On IJDB.InventoryJournaDetaillID Equals IJD.ID
                                Join IJ In LMISDb.InventoryJournals
                                    On IJD.InventoryJournalID Equals IJ.ID
                                Join IJT In LMISDb.InventoryJournalTypes
                                    On IJ.InventoryJournalTypeID Equals IJT.ID
                                Join IJS In LMISDb.InventoryJournalStatus
                                    On IJ.InventoryJournalStatusID Equals IJS.ID
                                Where IJ.Void = False And ((IJDB.InventoryBatch.ExpireDate IsNot Nothing And IJDB.InventoryBatch.ExpireDate > Date.Today) Or (True)) And IJT.Type = "Out" And IB.ID = BatchNo And IJS.Name = "Processed" And IJDB.LocationID = LocationID And IJ.DepartmentID = FRM_GLBMain.ApplicationConfig.ThisDepartment.ID
                                Group By IB.ID
                                Into SumOut = Sum(IJD.Quantity)
        Dim Available As Double = 0
        If Not (AvailableQIn.Count = 0) Then Available = AvailableQIn.First.SumIn
        If Not (AvailableQOut.Count = 0) Then Available = Available - AvailableQOut.First.SumOut
        'MsgBox(AvailableQIn.First.SumIn & " " & AvailableQOut.First.SumOut)
        Return Available
        ' Catch ex As Exception
        '     MessageBox.Show("Error: In getting Qty of Items available in a batch", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        '     Return 0
        'End Try
    End Function

    Shared Function Get_ItemQtyInBatchLocationPending(ByVal BatchNo As String, ByVal LocationID As String) As Double
        ' Try
        Dim LMISDb As New LMISEntities
        Dim AvailableQIn = From IB In LMISDb.InventoryBatches
                                Join IJDB In LMISDb.InventoryJournalDetailsBatches
                                    On IJDB.InventoryBatchID Equals IB.ID
                                Join IJD In LMISDb.InventoryJournalDetails
                                    On IJDB.InventoryJournaDetaillID Equals IJD.ID
                                Join IJ In LMISDb.InventoryJournals
                                    On IJD.InventoryJournalID Equals IJ.ID
                                Join IJT In LMISDb.InventoryJournalTypes
                                    On IJ.InventoryJournalTypeID Equals IJT.ID
                                Join IJS In LMISDb.InventoryJournalStatus
                                    On IJ.InventoryJournalStatusID Equals IJS.ID
                                Where IJ.Void = False And ((IJDB.InventoryBatch.ExpireDate IsNot Nothing And IJDB.InventoryBatch.ExpireDate > Date.Today) Or (True)) And IJT.Type = "In" And IB.ID = BatchNo And IJS.Name = "Processed" And IJDB.LocationID = LocationID And IJ.DepartmentID = FRM_GLBMain.ApplicationConfig.ThisDepartment.ID
                                Group By IB.ID
                                Into SumIn = Sum(IJD.Quantity)
        Dim AvailableQOut = From IB In LMISDb.InventoryBatches
                                Join IJDB In LMISDb.InventoryJournalDetailsBatches
                                    On IJDB.InventoryBatchID Equals IB.ID
                                Join IJD In LMISDb.InventoryJournalDetails
                                    On IJDB.InventoryJournaDetaillID Equals IJD.ID
                                Join IJ In LMISDb.InventoryJournals
                                    On IJD.InventoryJournalID Equals IJ.ID
                                Join IJT In LMISDb.InventoryJournalTypes
                                    On IJ.InventoryJournalTypeID Equals IJT.ID
                                Join IJS In LMISDb.InventoryJournalStatus
                                    On IJ.InventoryJournalStatusID Equals IJS.ID
                                Where IJ.Void = False And ((IJDB.InventoryBatch.ExpireDate IsNot Nothing And IJDB.InventoryBatch.ExpireDate > Date.Today) Or (True)) And ((IJT.Type = "Out" And IB.ID = BatchNo And IJS.Name = "Processed") Or (IJT.Type = "Out" And IJT.Name = "Issue" And IB.ID = BatchNo And IJS.Name = "Pending")) And
                                        IJDB.LocationID = LocationID And IJ.DepartmentID = FRM_GLBMain.ApplicationConfig.ThisDepartment.ID
                                Group By IB.ID
                                Into SumOut = Sum(IJD.Quantity)
        Dim Available As Double = 0
        If Not (AvailableQIn.Count = 0) Then Available = AvailableQIn.First.SumIn
        If Not (AvailableQOut.Count = 0) Then Available = Available - AvailableQOut.First.SumOut
        'MsgBox(AvailableQIn.First.SumIn & " " & AvailableQOut.First.SumOut)
        Return Available
        'Catch ex As Exception
        '    MessageBox.Show("Error: In getting Qty of Items available in a batch", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        '    Return 0
        'End Try
    End Function

    Shared Function Get_ItemCost(ByVal ItemID As String) As Double
        Try
            Dim LMISDb As New LMISEntities
            Dim LastCost = From I In LMISDb.InventoryBatches
                            Join IJDB In LMISDb.InventoryJournalDetailsBatches
                                On I.ID Equals IJDB.InventoryBatchID
                            Join IJD In LMISDb.InventoryJournalDetails
                                On IJD.ID Equals IJDB.InventoryJournaDetaillID
                            Where IJD.ItemID = ItemID And IJD.InventoryJournal.DepartmentID = FRM_GLBMain.ApplicationConfig.ThisDepartment.ID
                            Select IJDB.Price
            If LastCost.Count = 0 Then Return 0
            Return LastCost.ToArray.Last 'get last cost        
        Catch ex As Exception
            MessageBox.Show("Error: In Getting Cost", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return 0
        End Try
    End Function

    Shared Function Get_ItemConsumedQty(ByVal ItemID As String) As Integer
        Try
            Dim LMISDb As New LMISEntities
            Dim AvailableQOut = From IJD In LMISDb.InventoryJournalDetails
                                    Join IJC In LMISDb.ConsumedItems
                                        On IJC.ID Equals IJD.InventoryJournalID
                                    Join IJ In LMISDb.InventoryJournals
                                        On IJ.ID Equals IJD.InventoryJournalID
                                    Join IJT In LMISDb.InventoryJournalTypes
                                        On IJ.InventoryJournalTypeID Equals IJT.ID
                                    Join IJS In LMISDb.InventoryJournalStatus
                                        On IJ.InventoryJournalStatusID Equals IJS.ID
                                    Where IJT.Type = "Out" And IJT.Name = "Issue" And IJD.ItemID = ItemID And IJS.Name = "Processed" And IJ.DepartmentID = FRM_GLBMain.ApplicationConfig.ThisDepartment.ID
                                    Group By IDdd = IJD.ItemID
                                    Into SumOut = Sum(IJC.Consumption)
            Dim ConsumedQty As Double = 0
            If Not (AvailableQOut.Count = 0) Then
                ConsumedQty = AvailableQOut.First.SumOut
            End If
            Return ConsumedQty
        Catch ex As Exception
            MessageBox.Show("Error: In Getting Consumed Quantity", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return 0
        End Try
    End Function

    Shared Function Get_ItemFacilityConsumedQty(ByVal ItemID As String, ByVal DepartmentID As Integer) As Integer
        Try
            Dim LMISDb As New LMISEntities
            Dim LastQOut = From IJD In LMISDb.InventoryJournalDetails
                                    Join IJ In LMISDb.InventoryJournals
                                        On IJ.ID Equals IJD.InventoryJournalID
                                    Join Iss In LMISDb.Issues
                                        On IJ.ID Equals Iss.InventoryJournalID
                                    Join Req In LMISDb.Requisitions
                                        On Iss.RequisitionID Equals Req.ID
                                    Join IJT In LMISDb.InventoryJournalTypes
                                        On IJ.InventoryJournalTypeID Equals IJT.ID
                                    Join IJS In LMISDb.InventoryJournalStatus
                                        On IJ.InventoryJournalStatusID Equals IJS.ID
                                    Where IJT.Type = "Out" And IJT.Name = "Issue" And IJD.ItemID = ItemID And IJS.Name = "Processed" And Req.DepartmentID = DepartmentID And IJ.DepartmentID = FRM_GLBMain.ApplicationConfig.ThisDepartment.ID
                                    Order By IJ.VoucherDate
                                    Select IJD.Quantity
            If LastQOut.Count = 0 Then Return 0
            Return LastQout.ToArray.Last
        Catch ex As Exception
            MessageBox.Show("Error: In Getting Consumed Quantity", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return 0
        End Try
    End Function

    Shared Function Get_ItemBatches(ByVal ItemID As String) As ObjectQuery(Of InventoryBatch)
        Try
            Dim LMISDb As New LMISEntities
            Dim Batches = From IJDB In LMISDb.InventoryJournalDetailsBatches
                          Join VIT In LMISDb.VW_ItemBatchQty
                          On VIT.ID Equals IJDB.InventoryBatchID
                          Where ((IJDB.InventoryBatch.ExpireDate IsNot Nothing And IJDB.InventoryBatch.ExpireDate > Date.Today) Or (True)) And IJDB.InventoryJournalDetail.ItemID = ItemID And VIT.Quantity_Available > 0 And IJDB.InventoryJournalDetail.InventoryJournal.DepartmentID = FRM_GLBMain.ApplicationConfig.ThisDepartment.ID
                          Select IJDB.InventoryBatch Distinct
                          Order By InventoryBatch.ExpireDate Ascending
            If Batches.Count = 0 Then
                Return Nothing
            Else
                Return Batches
            End If
        Catch ex As Exception
            MessageBox.Show("Error: In getting Item Batches" & vbCrLf & ex.Message & Utility.InnerExecption(ex), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return Nothing
        End Try
    End Function

    Shared Function Get_ItemBatchesEvenExpired(ByVal ItemID As String) As ObjectQuery(Of InventoryBatch)
        Try
            Dim LMISDb As New LMISEntities
            Dim BatchesEx = From IJDB In LMISDb.InventoryJournalDetailsBatches
                          Join VIT In LMISDb.VW_ItemBatchQty
                          On VIT.ID Equals IJDB.InventoryBatchID
                          Where (IJDB.InventoryJournalDetail.ItemID = ItemID And VIT.Quantity_Available > 0 And IJDB.InventoryJournalDetail.InventoryJournal.DepartmentID = FRM_GLBMain.ApplicationConfig.ThisDepartment.ID)
                          Select IJDB.InventoryBatch Distinct
                          Order By InventoryBatch.ExpireDate Ascending
            If BatchesEx.Count = 0 Then
                Return Nothing
            Else
                Return BatchesEx
            End If
        Catch ex As Exception
            MessageBox.Show("Error: In getting Item Batches" & vbCrLf & ex.Message & Utility.InnerExecption(ex), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return Nothing
        End Try
    End Function

    Shared Function Get_ItemBatchesEvenZero(ByVal ItemID As String) As ObjectQuery(Of InventoryBatch)
        Try
            Dim LMISDb As New LMISEntities
            Dim Batches = From IJDB In LMISDb.InventoryJournalDetailsBatches
                          Where IJDB.InventoryJournalDetail.ItemID = ItemID Where ((IJDB.InventoryBatch.ExpireDate IsNot Nothing And IJDB.InventoryBatch.ExpireDate > Date.Today) Or (True)) And IJDB.InventoryJournalDetail.InventoryJournal.DepartmentID = FRM_GLBMain.ApplicationConfig.ThisDepartment.ID
                          Select IJDB.InventoryBatch Distinct
                          Order By InventoryBatch.ExpireDate Ascending
            If Batches.Count = 0 Then
                Return Nothing
            Else
                Return Batches
            End If
        Catch ex As Exception
            MessageBox.Show("Error: In getting Item Batches" & vbCrLf & ex.Message & Utility.InnerExecption(ex), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return Nothing
        End Try
    End Function

    Shared Function Get_ItemBatchExpiryDate(ByVal BatchID As String) As String
        Try
            Dim LMISDb As New LMISEntities
            Dim ExpiryDate = From IB In LMISDb.InventoryBatches
                          Where IB.ID = BatchID And IB.ExpireDate IsNot Nothing
                          Select IB.ExpireDate
            If ExpiryDate.Count = 0 Then Return Nothing
            Return ExpiryDate.First.Value.ToShortDateString()
        Catch ex As Exception
            MessageBox.Show("Error: In getting Item Batches Expiry Date", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return Nothing
        End Try
    End Function

    Shared Function Get_ItemDetailByID(ByVal ItemID As String) As InventoryItem
        Try
            If ItemID = Nothing Or ItemID = String.Empty Then Return Nothing
            Dim Item = (From I In (New LMISEntities).InventoryItems Where I.ID = ItemID Select I)
            If Item.Count = 0 Then Return Nothing
            Return Item.First
        Catch ex As Exception
            MessageBox.Show("Error: In getting Item" & ex.Message & Utility.InnerExecption(ex), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return Nothing
        End Try
    End Function

    Overloads Shared Function Get_BatchLocations(ByVal BatchID As String) As List(Of IDNdata)
        '  Try
        Dim LMISDb As New LMISEntities
        Dim BatchLocations = From IJDB In LMISDb.InventoryJournalDetailsBatches
                             Where IJDB.InventoryBatchID = BatchID And IJDB.InventoryJournalDetail.InventoryJournal.DepartmentID = FRM_GLBMain.ApplicationConfig.ThisDepartment.ID And IJDB.Location.Active = True
                             Select IJDB.Location.ID, LocationName = IJDB.Location.Name, StoreName = IJDB.Location.Store.Name Distinct
        If BatchLocations.Count = 0 Then Return Nothing
        Dim RetLocations As New List(Of IDNdata)
        For Each BatchLocation In BatchLocations
            If Get_ItemQtyInBatchLocation(BatchID, BatchLocation.ID) > 0 Then
                RetLocations.Add(New IDNdata(BatchLocation.ID, BatchLocation.StoreName & " | " & BatchLocation.LocationName, True))
            End If
        Next
        If RetLocations.Count = 0 Then Return Nothing
        Return RetLocations
        ' Catch ex As Exception
        '     MessageBox.Show("Error: In getting Item Batch locations", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        '     Return Nothing
        '  End Try
    End Function

    Overloads Shared Function Get_ItemBatchLocations() As List(Of IDNdata)
        'Try
        Dim LMISDb As New LMISEntities
        Dim Locations = From L In LMISDb.Locations
                            Where L.Store.DepartmentID = FRM_GLBMain.ApplicationConfig.ThisDepartment.ID And L.Store.Active = True
                             Select L.ID, LocationName = L.Name, StoreName = L.Store.Name
                             Distinct
        If Locations.Count = 0 Then Return Nothing
        Dim RetLocations As New List(Of IDNdata)
        For Each BatchLocation In Locations
            RetLocations.Add(New IDNdata(BatchLocation.ID, BatchLocation.StoreName & " | " & BatchLocation.LocationName, True))
        Next
        Return RetLocations
        'Catch ex As Exception
        'MessageBox.Show("Error: In getting Item Batch locations", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        'Return Nothing
        'End Try
    End Function

    Shared Function Get_StoreNLocationFromLID(ByVal LocationID As String) As IDNdata
        'Try
        Dim LMISDb As New LMISEntities
        Dim BatchLocations = From L In LMISDb.Locations
                             Where L.ID = LocationID
                             Select L.ID, LocationName = L.Name, StoreName = L.Store.Name Distinct
        If BatchLocations.Count = 0 Then Throw New ArgumentException("Wrong Argument for Get_ItemStoreNLocations")
        Return New IDNdata(BatchLocations.First.ID, BatchLocations.First.StoreName & " | " & BatchLocations.First.LocationName, True)
        ' Catch ex As Exception
        'MessageBox.Show("Error: In getting Item Batch locations", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        '  Return Nothing
        '  End Try
    End Function

    Shared Function Get_BatchCost(ByVal BatchID As String) As Double
        Try
            Dim LMISDb As New LMISEntities
            Dim LastCost = From IJDB In LMISDb.InventoryJournalDetailsBatches
                            Where IJDB.InventoryBatchID = BatchID And IJDB.InventoryJournalDetail.InventoryJournal.DepartmentID = FRM_GLBMain.ApplicationConfig.ThisDepartment.ID
                            Select IJDB.Price
            If LastCost.Count = 0 Then Return 0
            Return LastCost.ToArray.Last
        Catch ex As Exception
            MessageBox.Show("Error: In Getting Cost for batch", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return 0
        End Try
    End Function

    Shared Function Get_BatchSalesCost(ByVal BatchID As String) As Double
        Try
            Dim LMISDb As New LMISEntities
            Dim Batch = (From B In LMISDb.InventoryBatches Where B.ID = BatchID Select B)
            If Batch.Count = 0 Then Return 0
            Return Batch.First.SalesPrice
        Catch ex As Exception
            MessageBox.Show("Error: In Getting Batch sales cost", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return 0
        End Try
    End Function

    Shared Function Get_BatchPriceCost(ByVal BatchID As String) As Double
        Try
            Dim LMISDb As New LMISEntities
            Dim Batch = (From B In LMISDb.InventoryBatches Where B.ID = BatchID Select B)
            If Batch.Count = 0 Then Return 0
            Return Batch.First.CostPrice
        Catch ex As Exception
            MessageBox.Show("Error: In Getting Batch sales cost", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return 0
        End Try
    End Function

    Shared Function InnerExecption(ByVal Ex As Exception) As String
        If Ex.InnerException Is Nothing Then
            Return String.Empty
        Else
            Return vbCrLf & vbCrLf & "InnerExecption:" & vbCrLf & Ex.InnerException.Message
        End If
    End Function

    Shared Function Save_Batch(ByVal ID As String, ByVal CostPrice As Double, ByVal ExpireDateString As String, ByVal InventoryBatchStatusID As Integer, ByVal SalesPrice As Double) As Boolean
        Try

            Dim LMISDb As New LMISEntities          
            Dim PM = (From PMA In LMISDb.Facility_Addres Select PMA.ProfitMargin).Single
            Dim IB As New InventoryBatch With {
                                       .ID = ID,
                                       .CostPrice = CostPrice,
                                       .InventoryBatchStatusID = 1,
                                       .SalesPrice = IIf(SalesPrice <> -1, SalesPrice, CostPrice + PM * CostPrice)}
            If ExpireDateString <> String.Empty Then IB.ExpireDate = Date.Parse(ExpireDateString)
            LMISDb.InventoryBatches.AddObject(IB)
            LMISDb.SaveChanges()
        Catch ex As Exception
            MessageBox.Show("Error: In Saving Batch" & vbCrLf & ex.Message & Utility.InnerExecption(ex), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return 0
        End Try
    End Function

End Class

Public Class IDNdata
    Private IDPri As Object
    Private DataPri As String
    Private DataOnlyPri As Boolean = False
    Private SeparatorPri As Char = "|"
    ReadOnly Property ID As Object
        Get
            Return IDPri
        End Get
    End Property
    ReadOnly Property Data As String
        Get
            Return DataPri
        End Get
    End Property
    ReadOnly Property DataOnly As Boolean
        Get
            Return DataOnlyPri
        End Get
    End Property
    Public Sub New(ByVal ID As Object, ByVal Data As String)
        IDPri = ID
        DataPri = Data
    End Sub
    Public Sub New(ByVal ID As Object, ByVal Data As String, ByVal DataOnly As Boolean)
        MyClass.New(ID, Data)
        DataOnlyPri = DataOnly
    End Sub
    Public Sub New(ByVal ID As Object, ByVal Data As String, ByVal Separator As Char)
        MyClass.New(ID, Data)
        SeparatorPri = Separator
    End Sub
    Public Overrides Function ToString() As String
        If DataOnly Then
            Return Data
        Else
            Return ID & SeparatorPri & Data
        End If
    End Function

    'Shared Function ArrayToIDNData(ByVal Data As List(Of Integer)) As IDNdata()
    '    Dim ReturnData(Data.Count) As IDNdata
    '    Dim Index As Integer = 0
    '    For Each roww In Data
    '        MsgBox(roww.ToString())
    '        'ReturnData(Index) = New IDNdata(roww.key, row(1))
    '        Index += 1
    '    Next
    '    Return ReturnData
    'End Function
End Class

Public Class Range
    Public FromIndex As Integer
    Public ToIndex As Integer
    Public Sub New(ByVal FromIndex As Integer, ByVal ToIndex As Integer)
        Me.FromIndex = FromIndex
        Me.ToIndex = ToIndex
    End Sub
End Class
