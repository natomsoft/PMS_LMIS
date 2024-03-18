Imports System.Data.Objects
Imports System.Data.SqlClient

Public Class FRM_MTNItemBatches

    Public Sub New()
        InitializeComponent()
        Me.MdiParent = FRM_GLBMain
        LoadForm()
    End Sub

#Region "Utilities"

    Private Sub LoadForm()
        Try
            Dim LMISDb As New LMISEntities
            Dim ItemsM = From E In LMISDb.InventoryItems Select E
            CMBX_MStockCode.DataSource = ItemsM
            CMBX_MStockCode.DisplayMember = "ID"
            CMBX_MStockCode.ValueMember = "ID"
            CMBX_MStockCode.SelectedItem = Nothing

            CMBX_MStockItem.DataSource = ItemsM
            CMBX_MStockItem.DisplayMember = "Name"
            CMBX_MStockItem.ValueMember = "ID"
            CMBX_MStockItem.SelectedItem = Nothing
            ClearForm(True)
        Catch ex As Exception
            MessageBox.Show("Error:" & vbCrLf & ex.Message & Utility.InnerExecption(ex), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Function ValidateDataForm() As Boolean
        ERP_Error.Clear()
        Dim No_Error As Boolean = True
        If CMBX_MStockCode.SelectedItem Is Nothing Then
            ERP_Error.SetError(CMBX_MStockCode, "Select an appropriate Stock Item")
            No_Error = False
        End If
        If Not IsNumeric(TBX_MUCost.Text) Then
            ERP_Error.SetError(TBX_MUCost, "Please enter an appropriate number")
            No_Error = False
        ElseIf Val(TBX_MUCost.Text) <= 0 Then
            ERP_Error.SetError(TBX_MUCost, "Please enter a number more than zero")
            No_Error = False
        End If
        If Not IsNumeric(TBX_MUPrice.Text) Then
            ERP_Error.SetError(TBX_MUPrice, "Please enter an appropriate number")
            No_Error = False
        ElseIf Val(TBX_MUPrice.Text) <= 0 Then
            ERP_Error.SetError(TBX_MUPrice, "Please enter a number more than zero")
            No_Error = False
        End If
        If TBX_RenameBatch.Text <> String.Empty Then
            If (From IB In (New LMISEntities).InventoryBatches Where IB.ID = TBX_RenameBatch.Text Select IB).Count > 0 Then
                ERP_Error.SetError(TBX_RenameBatch, "Batch '" & TBX_RenameBatch.Text & "' already exists, please change it or leave empty")
                No_Error = False
            End If
        End If
        Return No_Error
    End Function

    Private Function SaveData() As Boolean
        Try
            Dim LMISDb As New LMISEntities
            Dim Batch As String = CMBX_MBatch.SelectedValue
            Dim ItemBatch = From IB In LMISDb.InventoryBatches Where IB.ID = Batch Select IB
            If ItemBatch.Count > 0 Then 'IF Batch already in database
                If dontSaveexpiry Then
                Else
                    ItemBatch.First.ExpireDate = DTP_ExpiryDate.Value
                End If

                ItemBatch.First.CostPrice = TBX_MUCost.Text
                ItemBatch.First.SalesPrice = TBX_MUPrice.Text
                LMISDb.SaveChanges()
            End If
            If TBX_RenameBatch.Text <> String.Empty Then
                Dim SqlConn As New SqlConnection(New SqlConnectionStringBuilder(My.Settings.LMISConnectionString).ConnectionString)
                SqlConn.Open()
                Dim SqlComm As New SqlCommand("Update InventoryBatches set ID='" & TBX_RenameBatch.Text & "' where ID='" & CMBX_MBatch.Text & "'", SqlConn)
                SqlComm.ExecuteNonQuery ()
            End If
            Return True
        Catch ex As Exception
            MessageBox.Show("Error:" & vbCrLf & ex.Message & Utility.InnerExecption(ex), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try
        Return False
    End Function

    Private Sub ClearForm(ByVal NameClear As Boolean)
        CMBX_MStockItem.SelectedItem = Nothing
    End Sub

#End Region

#Region "Events"

    Private Sub CMBX_MStockCode_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBX_MStockCode.SelectedIndexChanged, CMBX_MStockCode.TextChanged
        If CMBX_MStockCode.SelectedItem IsNot Nothing And CMBX_MStockCode.ValueMember <> String.Empty Then
            CMBX_MBatch.DataSource = Utility.Get_ItemBatchesEvenZero(CMBX_MStockCode.SelectedValue)
            CMBX_MBatch.ValueMember = "ID"
            CMBX_MBatch.DisplayMember = "ID"
            CMBX_MBatch.SelectedItem = Nothing
            TBX_Qty.Text = Utility.Get_ItemQty(CMBX_MStockItem.SelectedValue)
        Else
            CMBX_MBatch.DataSource = Nothing
            TBX_Qty.Text = String.Empty
        End If
    End Sub
    Dim dontSaveexpiry As Boolean = False
    Private Sub CMBX_MBatch_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBX_MBatch.SelectedIndexChanged
        If CMBX_MBatch.SelectedItem IsNot Nothing And CMBX_MBatch.ValueMember <> String.Empty Then
            CMBX_MBatchLoc.DataSource = Utility.Get_BatchLocations(CMBX_MBatch.SelectedValue)
            CMBX_MBatchLoc.ValueMember = "ID"
            CMBX_MBatchLoc.DisplayMember = "Data"
            CMBX_MBatchLoc.SelectedItem = Nothing
            TBX_BatchQty.Text = Utility.Get_ItemQtyInBatch(CMBX_MBatch.SelectedValue)
            TBX_MUCost.Text = CType(CMBX_MBatch.SelectedItem, InventoryBatch).CostPrice
            TBX_MUPrice.Text = CType(CMBX_MBatch.SelectedItem, InventoryBatch).SalesPrice
            dontSaveexpiry = False
            Try
                DTP_ExpiryDate.Value = CType(CMBX_MBatch.SelectedItem, InventoryBatch).ExpireDate

            Catch ex As Exception
                dontSaveexpiry = True
            End Try

        Else
            TBX_MUCost.Text = String.Empty
            TBX_MUPrice.Text = String.Empty
            DTP_ExpiryDate.Value = Date.Today
            CMBX_MBatchLoc.DataSource = Nothing
            TBX_BatchQty.Text = String.Empty
        End If
    End Sub

    Private Sub CMBX_MBatchLoc_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBX_MBatchLoc.SelectedIndexChanged
        If CMBX_MBatchLoc.SelectedItem IsNot Nothing And CMBX_MBatchLoc.ValueMember <> String.Empty Then
            TBX_BatchLocationQty.Text = Utility.Get_ItemQtyInBatchLocation(CMBX_MBatch.SelectedValue, CMBX_MBatchLoc.SelectedValue)
        Else
            TBX_BatchLocationQty.Text = String.Empty
        End If
    End Sub

    Private Sub BTN_Save_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTN_Save.Click
        FRM_GLBMain.TLSL_MainStatus.Text = "Ready"
        If ValidateDataForm() Then
            Me.Cursor = Cursors.WaitCursor
            If MessageBox.Show("Are you sure you want to Save", "Are you sure?", System.Windows.Forms.MessageBoxButtons.YesNo) = System.Windows.Forms.DialogResult.Yes Then
                If SaveData() Then
                    FRM_GLBMain.TLSL_MainStatus.Text = "Data Saved"
                    MessageBox.Show("Data Saved", "Data Saved", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    ClearForm(True)
                    LoadForm()
                Else
                    FRM_GLBMain.TLSL_MainStatus.Text = "Changes Not Saved"
                    MessageBox.Show("  Changes NOT Saved    ", "Error in Saving", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            End If
            Me.Cursor = Cursors.Default
        End If
    End Sub

    Private Sub BTN_Close_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTN_Close.Click
        Me.Close()
    End Sub

#End Region


End Class

