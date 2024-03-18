Imports System.Data.Objects

Public Class FRM_MTNCompanies

    Public Sub New()
        InitializeComponent()
        Me.MdiParent = FRM_GLBMain
        LoadForm()
    End Sub

#Region "Utilities"

    Private Sub LoadForm()
        Try
            Dim LMISDb As New LMISEntities            
            CMBX_Company.DataSource = From C In LMISDb.Companies Select C
            CMBX_Company.DisplayMember = "Name"
            CMBX_Company.ValueMember = "ID"
            CMBX_Company.AutoCompleteSource = AutoCompleteSource.ListItems
            CMBX_Company.SelectedItem = Nothing
            ClearForm(True)
        Catch ex As Exception
            MessageBox.Show("Error:" & vbCrLf & ex.Message & Utility.InnerExecption(ex), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Function ValidateDataForm() As Boolean
        ERP_Error.Clear()
        Dim No_Error As Boolean = True
        If CMBX_Company.SelectedIndex = -1 And CMBX_Company.Text = String.Empty Then
            ERP_Error.SetError(CMBX_Company, "Please select or type appropriate 'User Name'")
            No_Error = False
        End If
        If TBX_Address.Text = String.Empty Then
            ERP_Error.SetError(TBX_Address, "'Address' should not be empty")
            No_Error = False
        End If
        If TBX_Telephone.Text = String.Empty Then
            ERP_Error.SetError(TBX_Telephone, "'Telephone' should not be empty")
            No_Error = False
        End If
        If TBX_ChangetoCompany.Text <> String.Empty Then
            If (From m In CType(CMBX_Company.DataSource, ObjectQuery(Of Company)) Where m.Name = TBX_ChangetoCompany.Text Select m).Count > 0 Then
                ERP_Error.SetError(TBX_ChangetoCompany, "'" & TBX_ChangetoCompany.Text & "' Already Exists")
                No_Error = False
            End If
        End If
        Return No_Error
    End Function

    Private Function SaveData() As Boolean
        Try
            Dim LMISDb As New LMISEntities
            Dim IsNew As Boolean = False
            Dim CRow As Company
            Dim CheckID As Integer = CMBX_Company.SelectedValue
            Dim EditCheck = (From EC In LMISDb.Companies Where EC.ID = CheckID Select EC)
            If EditCheck.Count > 0 Then
                CRow = EditCheck.First
                If TBX_ChangetoCompany.Text <> String.Empty Then CRow.Name = TBX_ChangetoCompany.Text
            Else
                CRow = New Company With {.Name = CMBX_Company.Text}
                IsNew = True
            End If
            With CRow
                .Address = TBX_Address.Text
                .TelephoneNumber = TBX_Telephone.Text
                .Fax = TBX_Fax.Text
                .POBox = TBX_POBox.Text
                .EmailAddress = TBX_Email.Text
                If CHBX_IsActive.Checked Then
                    .CompanyStatusID = 1
                Else
                    .CompanyStatusID = 2
                End If
            End With
            If IsNew Then LMISDb.Companies.AddObject(CRow)
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
            CMBX_Company.Text = ""
            CMBX_Company.SelectedItem = Nothing
        End If
        TBX_ChangetoCompany.Text = ""
        TBX_Address.Text = ""
        TBX_Telephone.Text = ""
        TBX_Fax.Text = ""
        TBX_POBox.Text = ""
        TBX_Email.Text = ""        
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

    Private Sub CMBX_ItemCatalogue_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBX_Company.SelectedIndexChanged
        If CMBX_Company.ValueMember <> String.Empty Then
            ClearForm(False)
            Dim LMISDb As New LMISEntities
            Dim ECID As Integer = CMBX_Company.SelectedValue
            Dim Company = From EC In LMISDb.Companies Where EC.ID = ECID Select EC
            If Company.Count > 0 Then
                With Company.First
                    TBX_Address.Text = .Address
                    TBX_Telephone.Text = .TelephoneNumber
                    TBX_Fax.Text = .Fax
                    TBX_POBox.Text = .POBox
                    TBX_Email.Text = .EmailAddress
                    If .CompanyStatu.Status = "Active" Then
                        CHBX_IsActive.Checked = True
                    Else
                        CHBX_IsActive.Checked = False
                    End If
                End With
            End If
        End If
    End Sub

    Private Sub CMBX_ItemCatalogue_textChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBX_Company.LostFocus
        If CMBX_Company.SelectedItem Is Nothing Then ClearForm(False)
    End Sub

#End Region
End Class

