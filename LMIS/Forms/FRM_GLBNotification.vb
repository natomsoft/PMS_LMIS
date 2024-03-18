Public Class FRM_Notification
    Dim Loca1 As System.Drawing.Point, Loca2 As System.Drawing.Point, Loca3 As System.Drawing.Point, Loca4 As System.Drawing.Point

    Public Sub New()
        Me.MdiParent = FRM_GLBMain
        InitializeComponent()
        Loca1 = DGV_NotifyReorder.Location
        Loca2 = DGV_ItemExpiry.Location
        Loca3 = DGV_SupplyRequest.Location
        Loca4 = DGV_FacilityRequest.Location
    End Sub

    Public Overloads Function ShowNotification() As Boolean
        Try
            Dim LMISDb As New LMISEntities
            Dim NotifyReorderDS = From I In LMISDb.VW_ItemQty Where I.ReorderQty >= I.Quantity_Available Select I
            Dim ItemExpiryDs = LMISDb.SP_ItemBatchExpiry1(FRM_GLBMain.ApplicationConfig.ThisDepartment.ID, Date.Today, Date.Today.AddMonths(3))
            Dim SupplyRequestDS = (From Req In LMISDb.Requests Where (Req.InventoryJournal.Void = False And Req.InventoryJournal.Department.Active = True And Req.InventoryJournal.InventoryJournalStatu.Name = "Pending" And Req.InventoryJournal.DepartmentID = FRM_GLBMain.ApplicationConfig.ThisDepartment.ID)
                                        Select [RequestNo] = Req.ID, Req.InventoryJournal.Remark, Facility = Req.Department.Name, [Date] = Req.InventoryJournal.VoucherDate
                                        ).Except(
                                        From Rec In LMISDb.Recieves Where (Rec.InventoryJournal.Void = False And Rec.InventoryJournal.Department.Active = True And Rec.Request.InventoryJournal.Void = False And Rec.InventoryJournal.DepartmentID = FRM_GLBMain.ApplicationConfig.ThisDepartment.ID)
                                        Select [RequestNo] = Rec.Request.ID, Rec.Request.InventoryJournal.Remark, Facility = Rec.Request.Department.Name, [Date] = Rec.Request.InventoryJournal.VoucherDate)
            Dim FacilityRequestDS = (From Req In LMISDb.Requisitions
                                        Where (Req.InventoryJournal.Void = False And Req.InventoryJournal.Department.Active = True And Req.InventoryJournal.InventoryJournalStatu.Name = "Pending" And Req.InventoryJournal.DepartmentID = FRM_GLBMain.ApplicationConfig.ThisDepartment.ID)
                                        Select [RequisitionNo] = Req.ID, Req.InventoryJournal.Remark, Facility = Req.Department.Name, [Date] = Req.InventoryJournal.VoucherDate
                                        ).Except(
                                    From Req In LMISDb.Requisitions
                                        Join Iss In LMISDb.Issues
                                            On Iss.RequisitionID Equals Req.ID
                                        Where (Iss.InventoryJournal.Void = False And Iss.InventoryJournal.Department.Active = True And Req.InventoryJournal.Void = False And Req.InventoryJournal.DepartmentID = FRM_GLBMain.ApplicationConfig.ThisDepartment.ID)
                                        Select [RequisitionNo] = Req.ID, Req.InventoryJournal.Remark, Facility = Req.Department.Name, [Date] = Req.InventoryJournal.VoucherDate)
            If Not (NotifyReorderDS.Count = 0 And ItemExpiryDs.Count = 0 And SupplyRequestDS.Count = 0 And FacilityRequestDS.Count = 0) Then
                Me.Size = New System.Drawing.Size(515, 326)
                LS_LUU.Visible = False
                LS_LUD.Visible = False
                LS_RUU.Visible = False
                LS_RUD.Visible = False
                LS_LDU.Visible = False
                LS_LDD.Visible = False
                LS_RDU.Visible = False
                LS_RDD.Visible = False
                LBL_NotifyReorder.Visible = False
                LBL_ItemExpiry.Visible = False
                LBL_SupplyRequest.Visible = False
                LBL_FacilityRequest.Visible = False
                DGV_NotifyReorder.DataSource = From I In LMISDb.VW_ItemQty Where I.ReorderQty >= I.Quantity_Available Select I
                DGV_ItemExpiry.DataSource = LMISDb.SP_ItemBatchExpiry1(FRM_GLBMain.ApplicationConfig.ThisDepartment.ID, Date.Today, Date.Today.AddMonths(3))
                DGV_SupplyRequest.DataSource = (From Req In LMISDb.Requests Where (Req.InventoryJournal.Void = False And Req.InventoryJournal.Department.Active = True And Req.InventoryJournal.InventoryJournalStatu.Name = "Pending" And Req.InventoryJournal.DepartmentID = FRM_GLBMain.ApplicationConfig.ThisDepartment.ID)
                                        Select [RequestNo] = Req.ID, Req.InventoryJournal.Remark, Facility = Req.Department.Name, [Date] = Req.InventoryJournal.VoucherDate
                                        ).Except(
                                        From Rec In LMISDb.Recieves Where (Rec.InventoryJournal.Void = False And Rec.InventoryJournal.Department.Active = True And Rec.Request.InventoryJournal.Void = False And Rec.InventoryJournal.DepartmentID = FRM_GLBMain.ApplicationConfig.ThisDepartment.ID)
                                        Select [RequestNo] = Rec.Request.ID, Rec.Request.InventoryJournal.Remark, Facility = Rec.Request.Department.Name, [Date] = Rec.Request.InventoryJournal.VoucherDate)
                DGV_FacilityRequest.DataSource = (From Req In LMISDb.Requisitions
                                        Where (Req.InventoryJournal.Void = False And Req.InventoryJournal.Department.Active = True And Req.InventoryJournal.InventoryJournalStatu.Name = "Pending" And Req.InventoryJournal.DepartmentID = FRM_GLBMain.ApplicationConfig.ThisDepartment.ID)
                                        Select [RequisitionNo] = Req.ID, Req.InventoryJournal.Remark, Facility = Req.Department.Name, [Date] = Req.InventoryJournal.VoucherDate
                                        ).Except(
                                    From Req In LMISDb.Requisitions
                                        Join Iss In LMISDb.Issues
                                            On Iss.RequisitionID Equals Req.ID
                                        Where (Iss.InventoryJournal.Void = False And Iss.InventoryJournal.Department.Active = True And Req.InventoryJournal.Void = False And Req.InventoryJournal.DepartmentID = FRM_GLBMain.ApplicationConfig.ThisDepartment.ID)
                                        Select [RequisitionNo] = Req.ID, Req.InventoryJournal.Remark, Facility = Req.Department.Name, [Date] = Req.InventoryJournal.VoucherDate)
                Dim Order As Integer = 0
                Dim Notifcations As New Dictionary(Of DataGridView, Label)
                Notifcations.Add(DGV_NotifyReorder, LBL_NotifyReorder)
                Notifcations.Add(DGV_ItemExpiry, LBL_ItemExpiry)
                Notifcations.Add(DGV_SupplyRequest, LBL_SupplyRequest)
                Notifcations.Add(DGV_FacilityRequest, LBL_FacilityRequest)
                For Each DGV As DataGridView In Notifcations.Keys
                    If DGV.Rows.Count = 0 Then
                        DGV.Visible = False
                    Else
                        Order += 1
                        DGV.Location = ReLocation(Order)
                        Notifcations(DGV).Visible = True
                        Notifcations(DGV).Location = New System.Drawing.Point(DGV.Location.X - 14, DGV.Location.Y - 29)
                    End If
                Next
                If Order = 1 Then
                    Me.Size = New System.Drawing.Size(515, 326)
                ElseIf Order = 2 Then
                    Me.Size = New System.Drawing.Size(986, 326)
                Else
                    Me.Size = New System.Drawing.Size(974, 614)
                End If
                Return True
                Me.Show()
            Else
                Return False
            End If
        Catch ex As Exception
            MessageBox.Show("Error:" & vbCrLf & ex.Message & Utility.InnerExecption(ex), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try
    End Function

    Private Function ReLocation(ByVal Order As Integer) As System.Drawing.Point
        Select Case Order
            Case 1
                LS_LUU.Visible = True
                LS_LUD.Visible = True
                Return Loca1
            Case 2
                LS_RUU.Visible = True
                LS_RUD.Visible = True
                Return Loca2
            Case 3
                LS_LDU.Visible = True
                LS_LDD.Visible = True
                Return Loca3
            Case 4
                LS_RDU.Visible = True
                LS_RDD.Visible = True
                Return Loca4
        End Select
    End Function

    Private Sub BTN_Close_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTN_Close.Click
        Me.Close()
    End Sub

End Class