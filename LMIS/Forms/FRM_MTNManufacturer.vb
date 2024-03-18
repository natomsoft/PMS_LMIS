Imports System.Data.Objects

Public Class FRM_MTNManufacturer

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
            CMBX_Manufuc.DataSource = From E In LMISDb.Manufacturers Select E
            CMBX_Manufuc.DisplayMember = "Name"
            CMBX_Manufuc.ValueMember = "ID"
            CMBX_Manufuc.AutoCompleteSource = AutoCompleteSource.ListItems
            CMBX_Manufuc.SelectedItem = Nothing

            ClearForm(True)
        Catch ex As Exception
            MessageBox.Show("Error:" & vbCrLf & ex.Message & Utility.InnerExecption(ex), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Function ValidateDataForm() As Boolean
        ERP_Error.Clear()
        Dim No_Error As Boolean = True
        If CMBX_Manufuc.SelectedIndex = -1 And CMBX_Manufuc.Text = String.Empty Then
            ERP_Error.SetError(CMBX_Manufuc, "Please select or type appropriate 'Name'")
            No_Error = False
        End If
        If TBX_ChangetoManufuc.Text <> String.Empty Then
            If (From m In CType(CMBX_Manufuc.DataSource, ObjectQuery(Of Manufacturer)) Where m.Name = TBX_ChangetoManufuc.Text Select m).Count > 0 Then
                ERP_Error.SetError(TBX_ChangetoManufuc, "'" & TBX_ChangetoManufuc.Text & "' Already Exists")
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
            Dim CheckID As Integer = CMBX_Manufuc.SelectedValue
            Dim EditCheck = (From EC In LMISDb.Manufacturers Where EC.ID = CheckID Select EC)
            If EditCheck.Count > 0 Then
                CRow = EditCheck.First
                If TBX_ChangetoManufuc.Text <> String.Empty Then CRow.Name = TBX_ChangetoManufuc.Text
            Else
                CRow = New Manufacturer With {.Name = CMBX_Manufuc.Text}
                IsNew = True
            End If
            CRow.Active = CHBX_IsActive.Checked

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
            CMBX_Manufuc.Text = ""
            CMBX_Manufuc.SelectedItem = Nothing
        End If
        TBX_ChangetoManufuc.Text = ""
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

    Private Sub CMBX_ItemCatalogue_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBX_Manufuc.SelectedIndexChanged
        If CMBX_Manufuc.ValueMember <> String.Empty Then
            ClearForm(False)
            Dim LMISDb As New LMISEntities
            Dim ECID As Integer = CMBX_Manufuc.SelectedValue
            Dim CRow = From EC In LMISDb.Manufacturers Where EC.ID = ECID Select EC
            If CRow.Count > 0 Then
                CHBX_IsActive.Checked = CRow.First.Active
            End If
        End If
    End Sub

    Private Sub CMBX_ItemCatalogue_textChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBX_Manufuc.LostFocus
        If CMBX_Manufuc.SelectedItem Is Nothing Then ClearForm(False)
    End Sub

#End Region

End Class

