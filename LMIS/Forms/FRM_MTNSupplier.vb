Imports System.Data.Objects

Public Class FRM_MTNSupplier

    Public Sub New()
        InitializeComponent()
        Me.MdiParent = FRM_GLBMain
        LoadForm()
    End Sub

#Region "Utilities"

    Private Sub LoadForm()
        Try
            Dim LMISDb As New LMISEntities

            If CHBX_AddNewSupplier.Checked Then
                CMBX_ID.DataSource = (From ET In LMISDb.Companies Select ET).Except(From ET In LMISDb.Suppliers Select ET.Company)
            Else
                CMBX_ID.DataSource = From ET In LMISDb.Suppliers Select ET.ID, ET.Company.Name
            End If            
            CMBX_ID.DisplayMember = "Name"
            CMBX_ID.ValueMember = "ID"
            CMBX_ID.SelectedItem = Nothing
            ClearForm(True)

            Dim PeopleDetails As New List(Of IDNdata)
            For Each Person In From P In LMISDb.People Select P Where P.PersonStatusID = 1
                Dim Data As String = Person.PersonName.Name & " " & Person.PersonName1.Name & " "
                If Person.PersonName2 IsNot Nothing Then Data = Data & " " & Person.PersonName2.Name
                PeopleDetails.Add(New IDNdata(Person.ID, Data, True))                
            Next
            CMBX_Name.DataSource = PeopleDetails
            CMBX_Name.DisplayMember = "Data"
            CMBX_Name.ValueMember = "ID"
            CMBX_Name.AutoCompleteSource = AutoCompleteSource.ListItems

            ClearForm(True)
        Catch ex As Exception
            MessageBox.Show("Error:" & vbCrLf & ex.Message & Utility.InnerExecption(ex), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Function ValidateDataForm() As Boolean
        ERP_Error.Clear()
        Dim No_Error As Boolean = True
        If CMBX_Name.SelectedItem Is Nothing Then
            ERP_Error.SetError(CMBX_Name, "Please select appropriate 'Name'")
            No_Error = False
        End If
        If CMBX_ID.SelectedItem Is Nothing Then
            ERP_Error.SetError(CMBX_ID, "Select the Institute")
            No_Error = False
        End If
        Return No_Error
    End Function

    Private Function SaveData() As Boolean
        Try
            Dim LMISDb As New LMISEntities
            Dim IsNew As Boolean = False
            Dim CRow As Supplier
            Dim CheckID As Integer = CMBX_ID.SelectedValue
            If CHBX_AddNewSupplier.Checked Then
                CRow = New Supplier With {.ID = Utility.GenerateID(IDTypes.Supplier), .CompanyID = CMBX_ID.SelectedValue}
                IsNew = True
            Else
                Dim EditCheck = (From EC In LMISDb.Suppliers Where EC.ID = CheckID Select EC)
                If EditCheck.Count > 0 Then
                    CRow = EditCheck.First                    
                Else
                    CRow = New Supplier With {.ID = Utility.GenerateID(IDTypes.Supplier)}
                    IsNew = True
                End If
            End If

            With CRow
                .PersonID = CMBX_Name.SelectedValue
                If CHBX_IsActive.Checked Then
                    .SupplierStatusID = 1
                Else
                    .SupplierStatusID = 2
                End If
            End With
            If IsNew Then LMISDb.Suppliers.AddObject(CRow)
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
        CMBX_Name.SelectedItem = Nothing
        CHBX_IsActive.Checked = True
    End Sub

#End Region

#Region "Events"

    Private Sub BTN_Close_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTN_Close.Click
        Me.Close()
    End Sub

    Private Sub CHBX_AddNewFaciliti_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CHBX_AddNewSupplier.CheckedChanged
        Dim LMISDb As New LMISEntities
        If CHBX_AddNewSupplier.Checked Then
            CMBX_ID.DataSource = (From ET In LMISDb.Companies Select ET).Except(From ET In LMISDb.Suppliers Select ET.Company)
        Else
            CMBX_ID.DataSource = From ET In LMISDb.Suppliers Select ET.ID, ET.Company.Name
        End If
        CMBX_ID.DisplayMember = "Name"
        CMBX_ID.ValueMember = "ID"
        CMBX_ID.SelectedItem = Nothing
        ClearForm(True)
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

    Private Sub CMBX_ID_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBX_ID.SelectedIndexChanged
        If CMBX_ID.ValueMember <> String.Empty Then
            ClearForm(False)
            If CHBX_AddNewSupplier.Checked Then
                CMBX_Name.SelectedItem = Nothing
                CHBX_IsActive.Checked = True
            Else
                Dim LMISDb As New LMISEntities
                Dim ECID As Integer = CMBX_ID.SelectedValue
                Dim Supplier = From EC In LMISDb.Suppliers Where EC.ID = ECID Select EC
                If Supplier.Count > 0 Then
                    With Supplier.First
                        'CMBX_IDType.SelectedValue = .CustomerIDTypeID                        
                        CMBX_Name.SelectedValue = .PersonID
                        If .SupplierStatu.Status = "Active" Then
                            CHBX_IsActive.Checked = True
                        Else
                            CHBX_IsActive.Checked = False
                        End If
                    End With
                End If
            End If

        End If
    End Sub


#End Region

End Class

