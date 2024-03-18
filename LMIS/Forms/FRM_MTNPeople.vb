Imports System.Data.Objects
Public Class FRM_MTNPeople

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
            Dim Personnel = From P In LMISDb.People Select P
            Dim PersonnelNames As New List(Of IDNdata)
            For Each Person In Personnel
                Dim Data As String = Person.PersonName.Name & " " & Person.PersonName1.Name & " "
                If Person.PersonName2 IsNot Nothing Then Data = Data & Person.PersonName2.Name
                PersonnelNames.Add(New IDNdata(Person.ID, Data, True))
            Next
            CMBX_Name.DataSource = PersonnelNames
            CMBX_Name.DisplayMember = "Data"
            CMBX_Name.ValueMember = "ID"
            CMBX_Name.AutoCompleteSource = AutoCompleteSource.ListItems

            CMBX_IDNO.DataSource = Personnel
            CMBX_IDNO.DisplayMember = "IDNO"
            CMBX_IDNO.ValueMember = "ID"
            CMBX_IDNO.AutoCompleteSource = AutoCompleteSource.ListItems
            CMBX_IDNO.SelectedItem = Nothing

            'AddHandler CMBX_FName.TextChanged, AddressOf CMBX_Name_SelectedtextChanged
            CMBX_Country.DataSource = From C In LMISDb.Countries Select C
            CMBX_Country.DisplayMember = "Name"
            CMBX_Country.ValueMember = "ID"
            CMBX_Country.AutoCompleteSource = AutoCompleteSource.ListItems
            CMBX_Country.SelectedItem = Nothing

            'CMBX_FName.DataSource = From N In LMISDb.PersonNames Select N
            'CMBX_FName.DisplayMember = "Name"
            'CMBX_FName.ValueMember = "ID"
            'CMBX_FName.AutoCompleteSource = AutoCompleteSource.ListItems
            'CMBX_FName.SelectedItem = Nothing

            'CMBX_MName.DataSource = From N In LMISDb.PersonNames Select N
            'CMBX_MName.DisplayMember = "Name"
            'CMBX_MName.ValueMember = "ID"
            'CMBX_MName.AutoCompleteSource = AutoCompleteSource.ListItems
            'CMBX_MName.SelectedItem = Nothing

            'CMBX_LName.DataSource = From N In LMISDb.PersonNames Select N
            'CMBX_LName.DisplayMember = "Name"
            'CMBX_LName.ValueMember = "ID"
            'CMBX_LName.AutoCompleteSource = AutoCompleteSource.ListItems
            'CMBX_LName.SelectedItem = Nothing

            ClearForm(True)
        Catch ex As Exception
            MessageBox.Show("Error:" & vbCrLf & ex.Message & Utility.InnerExecption(ex), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Function ValidateDataForm() As Boolean
        ERP_Error.Clear()
        Dim No_Error As Boolean = True

        If CMBX_FName.Text = String.Empty Then
            ERP_Error.SetError(CMBX_FName, "First Name should not be empty")
            No_Error = False
        ElseIf (From N In (New LMISEntities).PersonNames Where N.Name = CMBX_FName.Text Select N).Count = 0 Then
            ERP_Error.SetError(CMBX_FName, "Name is not present in database")
            No_Error = False
        End If
        If CMBX_MName.Text = String.Empty Then
            ERP_Error.SetError(CMBX_MName, "First Name should not be empty")
            No_Error = False
        ElseIf (From N In (New LMISEntities).PersonNames Where N.Name = CMBX_MName.Text Select N).Count = 0 Then
            ERP_Error.SetError(CMBX_MName, "Name is not present in database")
            No_Error = False
        End If
        If CHBX_NewPerson.Checked Then
            If CMBX_IDNO.Text = String.Empty Then
                ERP_Error.SetError(CMBX_IDNO, "Please select appropriate 'ID' from the list or type in a new one")
                No_Error = False
            ElseIf CMBX_IDNO.SelectedItem IsNot Nothing Then
                ERP_Error.SetError(CMBX_IDNO, "'Eritrean ID' already exists, type in a new one")
                No_Error = False
            End If
        End If
        If Not CHBX_NewPerson.Checked And CMBX_Name.SelectedItem Is Nothing Then
            ERP_Error.SetError(CMBX_Name, "Please select appropriate 'Name' from the list")
            No_Error = False
        End If
        If CMBX_LName.Text <> String.Empty Then
            If (From N In (New LMISEntities).PersonNames Where N.Name = CMBX_LName.Text Select N).Count = 0 Then
                ERP_Error.SetError(CMBX_LName, "Name is not present in database")
                No_Error = False
            End If
        End If
        If CMBX_Gender.SelectedItem Is Nothing Then
            ERP_Error.SetError(CMBX_Gender, "Select the gender of the Person")
            No_Error = False
        End If
        If CMBX_Country.SelectedItem Is Nothing Then
            ERP_Error.SetError(CMBX_Country, "Select the Country of the Person")
            No_Error = False
        End If

        Return No_Error
    End Function

    Private Function SaveData() As Boolean
        Try
            Dim LMISDb As New LMISEntities
            Dim IsNewPerson As Boolean = False
            Dim Person As Person

            If CMBX_Name.SelectedItem IsNot Nothing And Not CHBX_NewPerson.Checked Then
                Dim PersonID As String = CType(CMBX_Name.SelectedItem, IDNdata).ID
                Person = (From P In LMISDb.People Where P.ID = PersonID Select P).Single
            Else
                Person = New Person
                Person.ID = Utility.GenerateID(IDTypes.Person)
                IsNewPerson = True
            End If
            With Person
                .IDNO = CMBX_IDNO.Text
                .FirstNameID = (From N In LMISDb.PersonNames Select N Where N.Name = CMBX_FName.Text).First.ID
                .MiddleNameID = (From N In LMISDb.PersonNames Select N Where N.Name = CMBX_MName.Text).First.ID
                If CMBX_LName.Text <> String.Empty Then .LastNameID = (From N In LMISDb.PersonNames Select N Where N.Name = CMBX_LName.Text).First.ID
                .PhoneNo = TBX_PhoneNo.Text
                .EmailAddress = TBX_Email.Text
                .Gender = CMBX_Gender.Text
                .CountryID = CMBX_Country.SelectedValue
                .DOB = DTP_DOB.Value
                If CHBX_IsActive.Checked Then
                    .PersonStatusID = 1
                Else
                    .PersonStatusID = 2
                End If
            End With
            If IsNewPerson Then LMISDb.People.AddObject(Person)
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
        CMBX_FName.Text = ""
        CMBX_MName.Text = ""
        CMBX_LName.Text = ""
        TBX_PhoneNo.Text = ""
        TBX_Email.Text = ""
        CMBX_FName.Text = ""
        CMBX_Gender.SelectedItem = Nothing
        CMBX_Country.SelectedItem = Nothing

    End Sub

    Private Sub ChangePerson(ByVal PersonID As String)
        'ClearForm(False)
        Dim LMISDb As New LMISEntities
        Dim Person = From P In LMISDb.People Where P.ID = PersonID Select P
        If Person.Count > 0 Then
            With Person.First
                CMBX_FName.Text = .PersonName.Name
                CMBX_MName.Text = .PersonName1.Name
                If .PersonName2 IsNot Nothing Then
                    CMBX_LName.Text = .PersonName2.Name
                Else
                    CMBX_LName.Text = String.Empty
                End If
                TBX_PhoneNo.Text = .PhoneNo
                TBX_Email.Text = .EmailAddress
                CMBX_Gender.Text = .Gender
                CMBX_Country.SelectedValue = .CountryID
                DTP_DOB.Value = .DOB
                If .PersonStatusID = 1 Then
                    CHBX_IsActive.Checked = True
                Else
                    CHBX_IsActive.Checked = False
                End If
            End With
        End If
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

    Private Sub CMBX_ItemCatalogue_textChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBX_Name.LostFocus
        'If CMBX_Name.SelectedItem Is Nothing Then ClearForm(False)
    End Sub
    'Private Sub CMBX_IDNO_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBX_IDNO.TextChanged
    '    If CMBX_IDNO.SelectedItem Is Nothing Then
    '        RemoveHandler CMBX_Name.SelectedIndexChanged, AddressOf CMBX_Name_SelectedIndexChanged
    '        CMBX_Name.SelectedItem = Nothing
    '        AddHandler CMBX_Name.SelectedIndexChanged, AddressOf CMBX_Name_SelectedIndexChanged
    '    End If
    'End Sub
    Private Sub CMBX_IDNO_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBX_IDNO.SelectedIndexChanged
        If CMBX_IDNO.SelectedItem IsNot Nothing And CMBX_IDNO.ValueMember <> String.Empty Then
            ChangePerson(CMBX_IDNO.SelectedValue)
            RemoveHandler CMBX_Name.SelectedIndexChanged, AddressOf CMBX_Name_SelectedIndexChanged
            CMBX_Name.SelectedValue = CMBX_IDNO.SelectedValue
            AddHandler CMBX_Name.SelectedIndexChanged, AddressOf CMBX_Name_SelectedIndexChanged
        End If
    End Sub

    Private Sub CMBX_Name_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBX_Name.SelectedIndexChanged
        If CMBX_Name.SelectedItem IsNot Nothing And CMBX_Name.ValueMember <> String.Empty Then
            ChangePerson(CMBX_Name.SelectedValue)
            RemoveHandler CMBX_IDNO.SelectedIndexChanged, AddressOf CMBX_IDNO_SelectedIndexChanged
            CMBX_IDNO.SelectedValue = CMBX_Name.SelectedValue
            AddHandler CMBX_IDNO.SelectedIndexChanged, AddressOf CMBX_IDNO_SelectedIndexChanged
        End If
    End Sub
#End Region

    Private Sub CMBX_Name_SelectedtextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim CMBX_Sender As ComboBox = CType(sender, ComboBox)
        If CMBX_Sender.Text <> String.Empty Then
            If CMBX_Sender.Text.Length = 1 Then
                With CMBX_Sender
                    .DataSource = From N In (New LMISEntities).PersonNames Select N Where N.Name Like (CMBX_Sender.Text & "%")
                    .DisplayMember = "Name"
                    .ValueMember = "ID"
                    .AutoCompleteSource = AutoCompleteSource.ListItems
                    .SelectedItem = Nothing
                End With
            End If
        Else
            CMBX_Sender.DataSource = Nothing
        End If
    End Sub

    Private Sub FRM_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        AddHandler CMBX_FName.TextChanged, AddressOf TBX_Name
        AddHandler CMBX_MName.TextChanged, AddressOf TBX_Name
        AddHandler CMBX_LName.TextChanged, AddressOf TBX_Name
    End Sub

    Private Sub TBX_Name(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim TBX_N As TextBox = CType(sender, TextBox)
        If TBX_N.Text.Length = 1 Then
            Dim LMISDb As New LMISEntities
            Dim AutoCSource As New AutoCompleteStringCollection
            Dim Names = From d In (New LMISEntities).PersonNames Select d Where d.Name.StartsWith(TBX_N.Text)
            For Each SName In Names
                AutoCSource.Add(SName.Name)
            Next
            TBX_N.AutoCompleteCustomSource = AutoCSource
        End If
    End Sub

    Private Sub CHBX_NewPerson_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CHBX_NewPerson.CheckedChanged
        CMBX_Name.Enabled = Not CHBX_IsActive.Checked
        CMBX_Name.Enabled = Not CHBX_NewPerson.Checked
        If CHBX_NewPerson.Checked Then CMBX_Name.SelectedItem = Nothing
        If CHBX_NewPerson.Checked Then CMBX_IDNO.SelectedItem = Nothing
    End Sub
End Class




