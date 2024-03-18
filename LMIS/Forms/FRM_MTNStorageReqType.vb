Imports System.Data.Objects

Public Class FRM_MTNStorageReqType

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
            CMBX_SRType.DataSource = From E In LMISDb.StorageRequirementTypes Select E
            CMBX_SRType.DisplayMember = "Type"
            CMBX_SRType.ValueMember = "ID"
            CMBX_SRType.AutoCompleteSource = AutoCompleteSource.ListItems
            CMBX_SRType.SelectedItem = Nothing

            ClearForm(True)
        Catch ex As Exception
            MessageBox.Show("Error:" & vbCrLf & ex.Message & Utility.InnerExecption(ex), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Function ValidateDataForm() As Boolean
        ERP_Error1.Clear()
        Dim No_Error As Boolean = True
        If CMBX_SRType.SelectedIndex = -1 And CMBX_SRType.Text = String.Empty Then
            ERP_Error1.SetError(CMBX_SRType, "Please select or type appropriate 'Type'")
            No_Error = False
        End If
        If TBX_ChangetoSRType.Text <> String.Empty Then
            If (From m In CType(CMBX_SRType.DataSource, ObjectQuery(Of StorageRequirementType)) Where m.Type = TBX_ChangetoSRType.Text Select m).Count > 0 Then
                ERP_Error1.SetError(TBX_ChangetoSRType, "'" & TBX_ChangetoSRType.Text & "' Already Exists")
                No_Error = False
            End If
        End If
        Return No_Error
    End Function

    Private Function SaveData() As Boolean
        Try
            Dim LMISDb As New LMISEntities
            Dim IsNew As Boolean = False
            Dim CRow As StorageRequirementType
            Dim CheckID As Integer = CMBX_SRType.SelectedValue
            Dim EditCheck = (From EC In LMISDb.StorageRequirementTypes Where EC.ID = CheckID Select EC)
            If EditCheck.Count > 0 Then
                CRow = EditCheck.First
                If TBX_ChangetoSRType.Text <> String.Empty Then CRow.Type = TBX_ChangetoSRType.Text
            Else
                CRow = New StorageRequirementType With {.Type = CMBX_SRType.Text}
                IsNew = True
            End If
            CRow.Active = CHBX_IsActive.Checked

            If IsNew Then LMISDb.StorageRequirementTypes.AddObject(CRow)
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
            CMBX_SRType.Text = ""
            CMBX_SRType.SelectedItem = Nothing
        End If
        TBX_ChangetoSRType.Text = ""
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

    Private Sub CMBX_ItemCatalogue_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBX_SRType.SelectedIndexChanged
        If CMBX_SRType.ValueMember <> String.Empty Then
            ClearForm(False)
            Dim LMISDb As New LMISEntities
            Dim ECID As Integer = CMBX_SRType.SelectedValue
            Dim CRow = From EC In LMISDb.StorageRequirementTypes Where EC.ID = ECID Select EC
            If CRow.Count > 0 Then
                CHBX_IsActive.Checked = CRow.First.Active
            End If
        End If
    End Sub

    Private Sub CMBX_ItemCatalogue_textChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBX_SRType.LostFocus
        If CMBX_SRType.SelectedItem Is Nothing Then ClearForm(False)
    End Sub

#End Region

End Class

