Imports System.Data.Objects

Public Class FRM_MTNNames

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
            CMBX_Name.DataSource = From E In LMISDb.PersonNames Order By E.Name Select E
            CMBX_Name.DisplayMember = "Name"
            CMBX_Name.ValueMember = "ID"
            CMBX_Name.AutoCompleteSource = AutoCompleteSource.ListItems
            CMBX_Name.SelectedItem = Nothing

            ClearForm(True)
        Catch ex As Exception
            MessageBox.Show("Error:" & vbCrLf & ex.Message & Utility.InnerExecption(ex), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Function ValidateDataForm() As Boolean
        ERP_Error.Clear()
        Dim No_Error As Boolean = True
        If CMBX_Name.SelectedIndex = -1 And CMBX_Name.Text = String.Empty Then
            ERP_Error.SetError(CMBX_Name, "Please select or type appropriate 'Name'")
            No_Error = False
        End If
        If TBX_Changeto.Text <> String.Empty Then
            If (From m In CType(CMBX_Name.DataSource, ObjectQuery(Of PersonName)) Where m.Name = TBX_Changeto.Text Select m).Count > 0 Then
                ERP_Error.SetError(TBX_Changeto, "'" & TBX_Changeto.Text & "' Already Exists")
                No_Error = False
            End If
        End If
        Return No_Error
    End Function

    Private Function SaveData() As Boolean
        Try
            Dim LMISDb As New LMISEntities
            Dim IsNew As Boolean = False
            Dim CRow As PersonName
            Dim CheckName As String = CMBX_Name.Text
            Dim EditCheck = (From EC In LMISDb.PersonNames Where EC.Name = CheckName Select EC)
            If EditCheck.Count > 0 Then
                CRow = EditCheck.First
                If TBX_Changeto.Text <> String.Empty Then CRow.Name = TBX_Changeto.Text
            Else
                CRow = New PersonName With {.ID = Utility.GenerateID(IDTypes.Names), .Name = CMBX_Name.Text}
                IsNew = True
            End If

            If IsNew Then LMISDb.PersonNames.AddObject(CRow)
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
            CMBX_Name.Text = ""
            CMBX_Name.SelectedItem = Nothing
        End If
        TBX_Changeto.Text = ""
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

    Private Sub CMBX_ItemCatalogue_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBX_Name.SelectedIndexChanged
        If CMBX_Name.ValueMember <> String.Empty Then
            ClearForm(False)
            Dim LMISDb As New LMISEntities
            Dim ECID As String = CMBX_Name.SelectedValue
            Dim CRow = From EC In LMISDb.Manufacturers Where EC.ID = ECID Select EC
            If CRow.Count > 0 Then
                CHBX_IsActive.Checked = CRow.First.Active
            End If
        End If
    End Sub

    Private Sub CMBX_ItemCatalogue_textChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBX_Name.LostFocus
        If CMBX_Name.SelectedItem Is Nothing Then ClearForm(False)
    End Sub

#End Region

End Class

