Imports System.Data.Objects

Public Class FRM_MTNSupplyPeriod

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
            CMBX_RationDays.DataSource = From E In LMISDb.RationDays Select E
            CMBX_RationDays.DisplayMember = "Days"
            CMBX_RationDays.ValueMember = "ID"
            CMBX_RationDays.AutoCompleteSource = AutoCompleteSource.ListItems
            CMBX_RationDays.SelectedItem = Nothing

            ClearForm(True)
        Catch ex As Exception
            MessageBox.Show("Error:" & vbCrLf & ex.Message & Utility.InnerExecption(ex), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Function ValidateDataForm() As Boolean
        ERP_Error.Clear()
        Dim No_Error As Boolean = True
        If CMBX_RationDays.SelectedIndex = -1 And CMBX_RationDays.Text = String.Empty Then
            ERP_Error.SetError(CMBX_RationDays, "Please select or type appropriate 'Name'")
            No_Error = False
        End If
        If TBX_ChangetoRationDays.Text <> String.Empty Then
            If (From m In CType(CMBX_RationDays.DataSource, ObjectQuery(Of Manufacturer)) Where m.Name = TBX_ChangetoRationDays.Text Select m).Count > 0 Then
                ERP_Error.SetError(TBX_ChangetoRationDays, "'" & TBX_ChangetoRationDays.Text & "' Already Exists")
                No_Error = False
            End If
        End If
        Return No_Error
    End Function

    Private Function SaveData() As Boolean
        Try
            Dim LMISDb As New LMISEntities
            Dim IsNew As Boolean = False
            Dim CRow As Manufacturer
            Dim CheckID As Integer = CMBX_RationDays.SelectedValue
            Dim EditCheck = (From EC In LMISDb.Manufacturers Where EC.ID = CheckID Select EC)
            If EditCheck.Count > 0 Then
                CRow = EditCheck.First
                If TBX_ChangetoRationDays.Text <> String.Empty Then CRow.Name = TBX_ChangetoRationDays.Text
            Else
                CRow = New Manufacturer With {.Name = CMBX_RationDays.Text}
                IsNew = True
            End If


            If IsNew Then LMISDb.Manufacturers.AddObject(CRow)
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
            CMBX_RationDays.Text = ""
            CMBX_RationDays.SelectedItem = Nothing
        End If
        TBX_ChangetoRationDays.Text = ""
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

    Private Sub CMBX_ItemCatalogue_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBX_RationDays.SelectedIndexChanged
        If CMBX_RationDays.ValueMember <> String.Empty And CMBX_RationDays.SelectedItem IsNot Nothing Then
            Dim RDID As Integer = CMBX_RationDays.SelectedValue
            Dim SupPeriod = (From SP In (New LMISEntities).SupplyPeriods Where SP.RationDaysID = RDID Select SP).Single
            With SupPeriod

            End With
        End If
    End Sub

    Private Sub CMBX_ItemCatalogue_textChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBX_RationDays.LostFocus
        If CMBX_RationDays.SelectedItem Is Nothing Then ClearForm(False)
    End Sub

#End Region

End Class

