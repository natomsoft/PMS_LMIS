Imports System.Data.Objects

Public Class FRM_MTNTherapeuticClass

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
            CMBX_THClass.DataSource = From E In LMISDb.TherapeuticClasses Select E
            CMBX_THClass.DisplayMember = "Name"
            CMBX_THClass.ValueMember = "ID"
            CMBX_THClass.AutoCompleteSource = AutoCompleteSource.ListItems
            CMBX_THClass.SelectedItem = Nothing

            ClearForm(True)
        Catch ex As Exception
            MessageBox.Show("Error:" & vbCrLf & ex.Message & Utility.InnerExecption(ex), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Function ValidateDataForm() As Boolean
        ERP_Error.Clear()
        Dim No_Error As Boolean = True
        If CMBX_THClass.SelectedIndex = -1 And CMBX_THClass.Text = String.Empty Then
            ERP_Error.SetError(CMBX_THClass, "Please select or type appropriate 'Class'")
            No_Error = False
        End If
        If TBX_ChangetoTHClass.Text <> String.Empty Then
            If (From m In CType(CMBX_THClass.DataSource, ObjectQuery(Of TherapeuticClass)) Where m.Name = TBX_ChangetoTHClass.Text Select m).Count > 0 Then
                ERP_Error.SetError(TBX_ChangetoTHClass, "'" & TBX_ChangetoTHClass.Text & "' Already Exists")
                No_Error = False
            End If
        End If
        Return No_Error
    End Function

    Private Function SaveData() As Boolean
        Try
            Dim LMISDb As New LMISEntities
            Dim IsNew As Boolean = False
            Dim CRow As TherapeuticClass
            Dim CheckID As Integer = CMBX_THClass.SelectedValue
            Dim EditCheck = (From EC In LMISDb.TherapeuticClasses Where EC.ID = CheckID Select EC)
            If EditCheck.Count > 0 Then
                CRow = EditCheck.First
                If TBX_ChangetoTHClass.Text <> String.Empty Then CRow.Name = TBX_ChangetoTHClass.Text
            Else
                CRow = New TherapeuticClass With {.Name = CMBX_THClass.Text}
                IsNew = True
            End If
            If IsNew Then LMISDb.TherapeuticClasses.AddObject(CRow)
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
            CMBX_THClass.Text = ""
            CMBX_THClass.SelectedItem = Nothing
        End If
        TBX_ChangetoTHClass.Text = ""
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

    Private Sub CMBX_ItemCatalogue_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBX_THClass.SelectedIndexChanged
        'If CMBX_RAType.ValueMember <> String.Empty Then
        '    ClearForm(False)
        '    Dim LMISDb As New LMISEntities
        '    Dim ECID As Integer = CMBX_RAType.SelectedValue
        '    Dim CRow = From EC In LMISDb.RouteOfAdministrations Where EC.ID = ECID Select EC
        'End If
    End Sub

    Private Sub CMBX_ItemCatalogue_textChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBX_THClass.LostFocus
        If CMBX_THClass.SelectedItem Is Nothing Then ClearForm(False)
    End Sub

#End Region
End Class

