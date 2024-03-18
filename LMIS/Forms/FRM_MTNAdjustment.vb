Public Class FRM_MTNAdjustment

    Public Sub New()
        InitializeComponent()
        Me.MdiParent = FRM_GLBMain
        LoadForm()
    End Sub
    Dim RemovedIDs As New List(Of String)
    Private Sub DGV_Beds_UserDeletingRow(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowCancelEventArgs) Handles DGV_AdjReasons.UserDeletingRow
        If DGV_AdjReasons.Rows.Count <> 0 Then RemovedIDs.Add(e.Row.Cells("AdjReasonID").Value)
    End Sub
#Region "Utilities"

    Private Sub LoadForm()
        Try
            Dim LMISDb As New LMISEntities
            CMBX_AdjType.DataSource = From AT In LMISDb.AdjustmentTypes Where AT.Description <> "Exchange" Order By AT.ID Ascending Select AT.Type Distinct
            CMBX_AdjType.AutoCompleteSource = AutoCompleteSource.ListItems
            ClearForm(True)
        Catch ex As Exception
            MessageBox.Show("Error:" & vbCrLf & ex.Message & Utility.InnerExecption(ex), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Function ValidateDataForm() As Boolean
        ERP_Error.Clear()
        Dim No_Error As Boolean = True
        'If CMBX_AdjType.SelectedIndex = -1 And CMBX_AdjType.Text = String.Empty Then
        '    ERP_Error.SetError(CMBX_AdjType, "Please select or type appropriate 'Type'")
        '    No_Error = False
        'ElseIf CMBX_AdjType.SelectedIndex = -1 Then
        '    If (From I In (New LMISEntities).Categories Where I.Name = CMBX_AdjType.Text Select I).Count > 0 Then
        '        ERP_Error.SetError(CMBX_AdjType, "Store '" & CMBX_AdjType.Text & "' already exists")
        '        No_Error = False
        '    End If
        'End If
        If Not DGV_AdjReasons.ValidateData() Then
            ERP_Error.SetError(DGV_AdjReasons, "Please correct your errors in the table")
            No_Error = False
        End If
        Return No_Error
    End Function

    Private Function SaveData() As Boolean
        Dim DeleteException As Boolean = False
        Try
            Dim LMISDb As New LMISEntities
            For Each Str As DataGridViewRow In DGV_AdjReasons.Rows
                If Not Str.IsNewRow Then
                    If Not DGV_AdjReasons.IsInDatabase(Str) Then
                        LMISDb.AdjustmentTypes.AddObject(New AdjustmentType With {
                                .Type = CMBX_AdjType.Text,
                                .Description = Str.Cells("AdjReason").Value,
                                .Active = Str.Cells("Active").Value})
                    Else
                        Dim AdjID As Integer = Str.Cells("AdjReasonID").Value
                        With (From Adj In LMISDb.AdjustmentTypes Where Adj.ID = AdjID Select Adj).First
                            .Description = Str.Cells("AdjReason").Value()
                            .Active = Str.Cells("Active").Value
                        End With
                    End If
                End If
            Next

            LMISDb.SaveChanges()
            For Each RDID In RemovedIDs
                Dim IDDel As String = RDID

                Dim RDeletedD = From RD In LMISDb.AdjustmentTypes Where RD.ID = IDDel Select RD
                If RDeletedD.Count > 0 Then
                    LMISDb.AdjustmentTypes.DeleteObject(RDeletedD.First)
                    Try
                        LMISDb.SaveChanges()
                    Catch ex As Exception
                        DeleteException = True
                        MsgBox("Can not delete Adjustment reason '" & RDeletedD.First.Description & "', because it has been used on other parts of the database")
                    End Try
                End If
            Next            
            Return True
        Catch ex As Exception
            If Not DeleteException Then
                MessageBox.Show("Error: In Saving Data" & vbCrLf & ex.Message & Utility.InnerExecption(ex), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return False
            Else
                Return True
            End If
        End Try
        Return False
    End Function

    Private Sub ClearForm(ByVal CatalogueClear As Boolean)
        If CatalogueClear Then
            CMBX_AdjType.Text = ""
            CMBX_AdjType.SelectedItem = Nothing
        End If
        DGV_AdjReasons.Rows.Clear()
    End Sub

    Private Sub ChangeItem(ByVal Type As String)
        ClearForm(False)
        Dim LMISDb As New LMISEntities        
        Dim Reasons = From RS In LMISDb.AdjustmentTypes Where RS.Type = Type Select RS        
        If Reasons.Count > 0 Then
            For Each RS In Reasons
                Dim NewRow = DGV_AdjReasons.Rows(DGV_AdjReasons.Rows.Add())
                NewRow.Cells("AdjReason").Value = RS.Description
                NewRow.Cells("AdjReasonID").Value = RS.ID
                NewRow.Cells("Active").Value = RS.Active
                DGV_AdjReasons.IsInDatabase(NewRow) = True
            Next
        End If
    End Sub

#End Region

#Region "Events"

    Private Sub FRM_GotFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.GotFocus
        FRM_GLBMain.TLSL_MainStatus.Text = "Ready"
    End Sub

    Private Sub BTN_Close_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTN_Close.Click
        Me.Close()
    End Sub

    Private Sub BTN_Save_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTN_Save.Click
        If ValidateDataForm() Then
            If SaveData() Then
                MessageBox.Show("  Data Saved    ", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                LoadForm()
            Else
                MessageBox.Show("  Data NOT Saved    ", "Error in Saving", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End If
    End Sub

    Private Sub CMBX_ItemCatalogue_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBX_AdjType.SelectedIndexChanged
        If CMBX_AdjType.SelectedItem IsNot Nothing Then ChangeItem(CMBX_AdjType.Text)
        RemovedIDs.Clear()
    End Sub

    Private Sub CMBX_ItemCatalogue_textChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBX_AdjType.LostFocus
        If CMBX_AdjType.SelectedValue Is Nothing Then ClearForm(False)
    End Sub

    Private Sub FRM_ItemAddNew_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        DGV_AdjReasons.initMe(DGV_GTypes.CategoryOnly)
    End Sub

#End Region

End Class

