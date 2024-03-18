Imports System.Data.Objects

Public Class FRM_MTNPrescriptionStatus

    Public Sub New()
        InitializeComponent()
        Me.MdiParent = FRM_GLBMain
        LoadForm()
    End Sub

#Region "Utilities"

    Private Sub LoadForm()
        Try
            Dim LMISDb As New LMISEntities
            '
            CMBX_PS.DataSource = From E In LMISDb.PrescriptionStatus Select E
            CMBX_PS.DisplayMember = "Status"
            CMBX_PS.ValueMember = "ID"
            CMBX_PS.AutoCompleteSource = AutoCompleteSource.ListItems
            CMBX_PS.SelectedItem = Nothing

            ClearForm(True)
        Catch ex As Exception
            MessageBox.Show("Error:" & vbCrLf & ex.Message & Utility.InnerExecption(ex), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Function ValidateDataForm() As Boolean
        ERP_Error.Clear()
        Dim No_Error As Boolean = True
        If CMBX_PS.SelectedIndex = -1 And CMBX_PS.Text = String.Empty Then
            ERP_Error.SetError(CMBX_PS, "Please select or type appropriate 'Status Name'")
            No_Error = False
        End If
        If TBX_ChangetoPS.Text <> String.Empty Then
            If (From m In CType(CMBX_PS.DataSource, ObjectQuery(Of PrescriptionStatu)) Where m.Status = TBX_ChangetoPS.Text Select m).Count > 0 Then
                ERP_Error.SetError(TBX_ChangetoPS, "'" & TBX_ChangetoPS.Text & "' Already Exists")
                No_Error = False
            End If
        End If
        Return No_Error
    End Function

    Private Function SaveData() As Boolean
        Try
            Dim LMISDb As New LMISEntities
            Dim IsNew As Boolean = False
            Dim CRow As PrescriptionStatu
            Dim CheckID As Integer = CMBX_PS.SelectedValue
            Dim EditCheck = (From EC In LMISDb.PrescriptionStatus Where EC.ID = CheckID Select EC)
            If EditCheck.Count > 0 Then
                CRow = EditCheck.First
                If TBX_ChangetoPS.Text <> String.Empty Then CRow.Status = TBX_ChangetoPS.Text
            Else
                CRow = New PrescriptionStatu With {.Status = CMBX_PS.Text}
                IsNew = True
            End If
            If IsNew Then LMISDb.PrescriptionStatus.AddObject(CRow)
            LMISDb.SaveChanges()
            Return True
        Catch ex As Exception
            MessageBox.Show("Error:" & vbCrLf & ex.Message & Utility.InnerExecption(ex), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try
        Return False
    End Function

    Private Sub ClearForm(ByVal NameClear As Boolean)
        If NameClear Then
            CMBX_PS.Text = ""
            CMBX_PS.SelectedItem = Nothing
        End If
        TBX_ChangetoPS.Text = ""
    End Sub

#End Region

#Region "Events"

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

    Private Sub CMBX_ItemCatalogue_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBX_PS.SelectedIndexChanged
        'If CMBX_RAType.ValueMember <> String.Empty Then
        '    ClearForm(False)
        '    Dim LMISDb As New LMISEntities
        '    Dim ECID As Integer = CMBX_RAType.SelectedValue
        '    Dim CRow = From EC In LMISDb.RouteOfAdministrations Where EC.ID = ECID Select EC
        'End If
    End Sub

    Private Sub CMBX_ItemCatalogue_textChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBX_PS.LostFocus
        If CMBX_PS.SelectedItem Is Nothing Then ClearForm(False)
    End Sub

#End Region
End Class

