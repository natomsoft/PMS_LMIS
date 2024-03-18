Imports System.Data.Objects

Public Class FRM_MTNDepartment

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
            CMBX_DepartmentName.DataSource = From E In LMISDb.Departments Select E
            CMBX_DepartmentName.DisplayMember = "Name"
            CMBX_DepartmentName.ValueMember = "ID"
            CMBX_DepartmentName.AutoCompleteSource = AutoCompleteSource.ListItems
            CMBX_DepartmentName.SelectedItem = Nothing

            CMBX_FacilityName.DataSource = From E In LMISDb.Facilities Select E
            CMBX_FacilityName.DisplayMember = ".FacilityName"
            CMBX_FacilityName.ValueMember = "ID"
            CMBX_FacilityName.AutoCompleteSource = AutoCompleteSource.ListItems
            CMBX_FacilityName.SelectedItem = Nothing

            CMBX_DepartmentType.DataSource = From E In LMISDb.DepartmentTypes Select E
            CMBX_DepartmentType.DisplayMember = "Type"
            CMBX_DepartmentType.ValueMember = "ID"
            CMBX_DepartmentType.AutoCompleteSource = AutoCompleteSource.ListItems
            CMBX_DepartmentType.SelectedItem = Nothing

            CMBX_LevelOfUseID.DataSource = From E In LMISDb.LevelOfUses Select E
            CMBX_LevelOfUseID.DisplayMember = "Description"
            CMBX_LevelOfUseID.ValueMember = "ID"
            CMBX_LevelOfUseID.AutoCompleteSource = AutoCompleteSource.ListItems
            CMBX_LevelOfUseID.SelectedItem = Nothing
            ClearForm(True)
        Catch ex As Exception
            MessageBox.Show("Error:" & vbCrLf & ex.Message & Utility.InnerExecption(ex), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Function ValidateDataForm() As Boolean
        ERP_Error.Clear()
        Dim No_Error As Boolean = True
        If CMBX_DepartmentName.SelectedIndex = -1 And CMBX_DepartmentName.Text = String.Empty Then
            ERP_Error.SetError(CMBX_DepartmentName, "Please select or type appropriate 'Name'")
            No_Error = False
        End If
        If TBX_ChangetoName.Text <> String.Empty Then
            If (From m In CType(CMBX_DepartmentName.DataSource, ObjectQuery(Of Department)) Where m.Name = TBX_ChangetoName.Text Select m).Count > 0 Then
                ERP_Error.SetError(TBX_ChangetoName, "'" & TBX_ChangetoName.Text & "' Already Exists")
                No_Error = False
            End If
        End If
        If CMBX_FacilityName.SelectedItem Is Nothing Then
            ERP_Error.SetError(CMBX_FacilityName, "Please select or type appropriate 'Parent Medical Store'")
            No_Error = False
        End If
        If CMBX_DepartmentType.SelectedItem Is Nothing Then
            ERP_Error.SetError(CMBX_DepartmentType, "Please select or type appropriate 'Facility Type'")
            No_Error = False
        End If
        If CMBX_LevelOfUseID.SelectedItem Is Nothing Then
            ERP_Error.SetError(CMBX_LevelOfUseID, "Please select or type appropriate 'Level of use'")
            No_Error = False
        End If
        Return No_Error
    End Function

    Private Function SaveData() As Boolean
        Try
            Dim LMISDb As New LMISEntities
            Dim IsNew As Boolean = False
            Dim CRow As Department
            Dim CheckID As Integer = CMBX_DepartmentName.SelectedValue
            Dim EditCheck = (From EC In LMISDb.Departments Where EC.ID = CheckID Select EC)
            If EditCheck.Count > 0 Then
                CRow = EditCheck.First
                If TBX_ChangetoName.Text <> String.Empty Then CRow.Name = TBX_ChangetoName.Text
            Else
                Dim FacID As String = CMBX_FacilityName.SelectedValue
                Dim DepaId As String = ""
                Dim MaxID = From IJ In LMISDb.Departments
                            Order By IJ.ID Descending
                            Select IJ
                            Where IJ.ID.StartsWith(FacID)
                If (MaxID.Count = 0) Then
                    DepaId = CMBX_FacilityName.SelectedValue & "001"
                Else
                    DepaID = Double.Parse(MaxID.First.ID) + 1
                End If
                CRow = New Department With {.ID = DepaId, .Name = CMBX_DepartmentName.Text, .Active = False}
                IsNew = True
            End If            
            CRow.FacilityID = CMBX_FacilityName.SelectedValue
            CRow.DepartmentTypeID = CMBX_DepartmentType.SelectedValue
            CRow.LevelofUseID = CMBX_LevelOfUseID.SelectedValue


            If IsNew Then LMISDb.Departments.AddObject(CRow)
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
            CMBX_DepartmentName.Text = ""
            CMBX_DepartmentName.SelectedItem = Nothing
        End If
        TBX_ChangetoName.Text = ""
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

    Private Sub CMBX_ItemCatalogue_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBX_DepartmentName.SelectedIndexChanged
        If CMBX_DepartmentName.ValueMember <> String.Empty Then
            ClearForm(False)
            Dim LMISDb As New LMISEntities
            Dim ECID As Integer = CMBX_DepartmentName.SelectedValue
            Dim CRow = From EC In LMISDb.Departments Where EC.ID = ECID Select EC
            If CRow.Count > 0 Then
                CMBX_FacilityName.SelectedValue = CRow.First.FacilityID
                CMBX_DepartmentType.SelectedValue = CRow.First.DepartmentTypeID
                CMBX_LevelOfUseID.SelectedValue = CRow.First.LevelofUseID
            End If
        End If
    End Sub

    Private Sub CMBX_ItemCatalogue_textChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBX_DepartmentName.LostFocus
        If CMBX_DepartmentName.SelectedItem Is Nothing Then ClearForm(False)
    End Sub

#End Region

End Class

