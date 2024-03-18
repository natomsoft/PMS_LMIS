Imports System.Data.Objects

Public Class FRM_MTNCustomers

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
            CMBX_ID.DataSource = From E In LMISDb.Customers Select E
            CMBX_ID.DisplayMember = "IDNumber"
            CMBX_ID.ValueMember = "ID"
            CMBX_ID.AutoCompleteSource = AutoCompleteSource.ListItems
            CMBX_ID.SelectedItem = Nothing

            Dim Peoples As New List(Of IDNdata)
            For Each Person In From P In LMISDb.People Select P
                Peoples.Add(New IDNdata(Person.ID, Person.PersonName.Name & " " & Person.PersonName1.Name & " " & Person.PersonName2.Name, True))
            Next
            CMBX_Name.DataSource = Peoples
            CMBX_Name.DisplayMember = "Data"
            CMBX_Name.ValueMember = "ID"
            CMBX_Name.AutoCompleteSource = AutoCompleteSource.ListItems

            CMBX_IDType.DataSource = From ET In LMISDb.CustomerIDTypes Select ET
            CMBX_IDType.DisplayMember = "Type"
            CMBX_IDType.ValueMember = "ID"
            CMBX_IDType.SelectedItem = Nothing

            CMBX_Company.DataSource = From ET In LMISDb.Companies Select ET
            CMBX_Company.DisplayMember = "Name"
            CMBX_Company.ValueMember = "ID"
            CMBX_Company.SelectedItem = Nothing
            ClearForm(True)
        Catch ex As Exception
            MessageBox.Show("Error:" & vbCrLf & ex.Message & Utility.InnerExecption(ex), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Function ValidateDataForm() As Boolean
        ERP_Error.Clear()
        Dim No_Error As Boolean = True
        If CMBX_ID.SelectedIndex = -1 And CMBX_ID.Text = String.Empty Then
            ERP_Error.SetError(CMBX_ID, "Please select or type appropriate 'User Name'")
            No_Error = False
        End If
        If CMBX_Name.SelectedItem Is Nothing Then
            ERP_Error.SetError(CMBX_Name, "Please select appropriate 'Name'")
            No_Error = False
        End If
        If CMBX_Company.SelectedItem Is Nothing Then
            ERP_Error.SetError(CMBX_Company, "Select the Company")
            No_Error = False
        End If
        If CMBX_IDType.SelectedItem Is Nothing Then
            ERP_Error.SetError(CMBX_IDType, "Select the ID Type")
            No_Error = False
        End If
        If TBX_ChangetoID.Text <> String.Empty Then
            If (From m In CType(CMBX_ID.DataSource, ObjectQuery(Of Customer)) Where m.IDNumber = TBX_ChangetoID.Text Select m).Count > 0 Then
                ERP_Error.SetError(TBX_ChangetoID, "'" & TBX_ChangetoID.Text & "' Already Exists")
                No_Error = False
            End If
        End If
        Return No_Error
    End Function

    Private Function SaveData() As Boolean
        Try
            Dim LMISDb As New LMISEntities
            Dim IsNew As Boolean = False
            Dim CRow As Customer            
            Dim CheckID As String = CMBX_ID.SelectedValue
            Dim EditCheck = (From EC In LMISDb.Customers Where EC.ID = CheckID Select EC)
            If EditCheck.Count > 0 Then                
                CRow = EditCheck.First
                If TBX_ChangetoID.Text <> String.Empty Then CRow.IDNumber = TBX_ChangetoID.Text
            Else
                CRow = New Customer With {.ID = Utility.GenerateID(IDTypes.Customer), .IDNumber = CMBX_ID.Text}
                IsNew = True
            End If
            With CRow
                .CustomerIDTypeID = CMBX_IDType.SelectedValue
                .CompanyID = CMBX_Company.SelectedValue
                .PersonID = CMBX_Name.SelectedValue
                If CHBX_IsActive.Checked Then
                    .CustomerStatusID = 1
                Else
                    .CustomerStatusID = 2
                End If
            End With
            If IsNew Then LMISDb.Customers.AddObject(CRow)
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
            CMBX_ID.Text = ""
            CMBX_ID.SelectedItem = Nothing
        End If
        TBX_ChangetoID.Text = ""
        CMBX_IDType.SelectedItem = Nothing
        CMBX_Name.SelectedItem = Nothing
        CMBX_Company.SelectedItem = Nothing
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

    Private Sub CMBX_ItemCatalogue_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBX_ID.SelectedIndexChanged
        If CMBX_ID.ValueMember <> String.Empty Then
            ClearForm(False)
            Dim LMISDb As New LMISEntities
            Dim ECID As String = CMBX_ID.SelectedValue
            Dim Customer = From EC In LMISDb.Customers Where EC.ID = ECID Select EC
            If Customer.Count > 0 Then
                With Customer.First
                    CMBX_IDType.SelectedValue = .CustomerIDTypeID
                    CMBX_Company.SelectedValue = .CompanyID
                    CMBX_Name.SelectedValue = .PersonID                    
                    If .CustomerStatu.Status = "Active" Then
                        CHBX_IsActive.Checked = True
                    Else
                        CHBX_IsActive.Checked = False
                    End If
                End With
            End If
        End If
    End Sub

    Private Sub CMBX_ItemCatalogue_textChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBX_ID.LostFocus
        If CMBX_ID.SelectedItem Is Nothing Then ClearForm(False)
    End Sub

#End Region

End Class

