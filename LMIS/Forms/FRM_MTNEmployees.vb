Imports System.Data.Objects

Public Class FRM_MTNEmployees

    Public Sub New()
        InitializeComponent()
        Me.MdiParent = FRM_GLBMain
        LoadForm()
    End Sub

#Region "Utilities"

    Private Sub LoadForm()
        Try
            Dim LMISDb As New LMISEntities
            Dim Personnel As ObjectQuery(Of Person)
            If CHBX_Addnew.Checked Then
                Personnel = (From P In LMISDb.People Select P).Except(From EE In LMISDb.Employees Select EE.Person)
            Else
                Personnel = From EE In LMISDb.Employees Select EE.Person
            End If
            Dim People As New List(Of IDNdata)
            For Each Person In Personnel
                Dim Lastname As String = String.Empty
                If Person.PersonName2 IsNot Nothing Then Lastname = Person.PersonName2.Name
                People.Add(New IDNdata(Person.ID, Person.PersonName.Name & " " & Person.PersonName1.Name & " " & Lastname, True))
            Next
            CMBX_Name.DataSource = People
            CMBX_Name.DisplayMember = "Data"
            CMBX_Name.ValueMember = "ID"
            CMBX_Name.AutoCompleteSource = AutoCompleteSource.ListItems

            CMBX_EmpType.DisplayMember = "Name"
            CMBX_EmpType.ValueMember = "ID"
            CMBX_EmpType.DataSource = From ET In LMISDb.EmployeeTypes Where ET.Name <> "Health Worker" Select ET
            CMBX_EmpType.SelectedItem = Nothing
            ClearForm(True)
        Catch ex As Exception
            MessageBox.Show("Error:" & vbCrLf & ex.Message & Utility.InnerExecption(ex), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Function ValidateDataForm() As Boolean
        ERP_Error.Clear()
        Dim No_Error As Boolean = True
        If CHBX_IsSystemUser.Checked And TBX_UserName.Text = String.Empty Then
            ERP_Error.SetError(TBX_UserName, "Please type appropriate 'User Name'")
            No_Error = False
        End If
        If CMBX_Name.SelectedItem Is Nothing Then
            ERP_Error.SetError(CMBX_Name, "Please select appropriate 'Name'")
            No_Error = False
        End If
        If CHBX_IsSystemUser.Checked And TBX_Password.Text.Length <= 3 Then
            ERP_Error.SetError(TBX_Password, "'Password' length should be more than 3")
            No_Error = False
        End If
        If CHBX_IsSystemUser.Checked And TBX_Password.Text <> TBX_ConPassword.Text Then
            ERP_Error.SetError(TBX_Password, "'Password' and 'Confirm password' do not match")
            No_Error = False
        End If
        If CHBX_IsSystemUser.Checked And CMBX_EmpType.SelectedItem Is Nothing Then
            ERP_Error.SetError(CMBX_EmpType, "Select the Employee Type")
            No_Error = False
        End If
        If CHBX_IsSystemUser.Checked And TBX_ChangetoUserName.Text <> String.Empty Then
            If (From m In (New LMISEntities).Employees Where m.UserName = TBX_ChangetoUserName.Text Select m).Count > 0 Then
                ERP_Error.SetError(TBX_ChangetoUserName, "'" & TBX_ChangetoUserName.Text & "' Already Exists")
                No_Error = False
            End If
        End If
        Return No_Error
    End Function

    Private Function SaveData() As Boolean
        Try
            Dim LMISDb As New LMISEntities
            Dim IsNewEmployee As Boolean = False
            Dim Employee As Employee
            Dim EmployeeID As String = CMBX_Name.SelectedValue
            Dim EmployeeCheck = (From E In LMISDb.Employees Where E.PersonID = EmployeeID Select E)
            If EmployeeCheck.Count > 0 Then
                Employee = EmployeeCheck.First
                If TBX_ChangetoUserName.Text <> String.Empty Then Employee.UserName = TBX_ChangetoUserName.Text
            Else                
                Employee = New Employee With {.ID = Utility.GenerateID(IDTypes.Employee), .DepartmentID = FRM_GLBMain.ApplicationConfig.ThisDepartment.ID}
                IsNewEmployee = True
            End If
            With Employee
                .PersonID = CMBX_Name.SelectedValue
                .IsSystemUser = CHBX_IsSystemUser.Checked
                If .Password <> TBX_Password.Text Then
                    .Password = New hlpPasswordEncryptDecrypt().Encrypt(TBX_Password.Text)
                End If
                If CHBX_IsSystemUser.Checked Then
                    .UserName = TBX_UserName.Text
                    .EmployeeTypeID = IIf(CMBX_EmpType.SelectedItem Is Nothing, Nothing, CMBX_EmpType.SelectedValue)
                Else
                    .UserName = CMBX_Name.Text
                    .EmployeeTypeID = 5
                End If
                .EmployeeStatusID = IIf(CHBX_IsActive.Checked, 1, 2)
            End With
            If IsNewEmployee Then LMISDb.Employees.AddObject(Employee)
            LMISDb.SaveChanges()            
            Return True
        Catch ex As Exception
            MessageBox.Show("Error in saving:" & vbCrLf & ex.Message & Utility.InnerExecption(ex), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try
        Return False
    End Function

    Private Sub ClearForm(ByVal NameClear As Boolean)
        If NameClear Then
            CMBX_Name.SelectedItem = Nothing
        End If
        TBX_UserName.Text = String.Empty
        TBX_ChangetoUserName.Text = String.Empty
        TBX_Password.Text = String.Empty
        TBX_ConPassword.Text = String.Empty
        CMBX_EmpType.SelectedItem = Nothing


    End Sub

    Private Sub ChangeUser(ByVal EmpID As String)
        ClearForm(False)
        Dim LMISDb As New LMISEntities
        Dim User = From E In LMISDb.Employees Where E.ID = EmpID Select E
        If User.Count > 0 Then
            With User.First
                'CMBX_Name.SelectedValue = .PersonID
                TBX_Password.Text = .Password
                TBX_ConPassword.Text = .Password
                TBX_UserName.Text = .UserName
                CMBX_EmpType.SelectedValue = .EmployeeTypeID
                CHBX_IsSystemUser.Checked = .IsSystemUser
                CHBX_IsActive.Checked = IIf(.EmployeeStatusID = 1, True, False)
            End With
        Else
            MsgBox("No such user")
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
                ClearForm(True)
            Else
                MessageBox.Show("  Data NOT Saved    ", "Error in Saving", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
            'If Not CMBX_EmpType.Visible Then Me.Close()
        End If        
    End Sub

#End Region

    Private Sub CHBX_IsSystemUser_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CHBX_IsSystemUser.CheckedChanged
        TBX_Password.Visible = CHBX_IsSystemUser.Checked
        LBL_Password.Visible = CHBX_IsSystemUser.Checked
        TBX_ConPassword.Visible = CHBX_IsSystemUser.Checked
        LBL_ConPassword.Visible = CHBX_IsSystemUser.Checked
        CMBX_EmpType.Visible = CHBX_IsSystemUser.Checked
        LBL_EmpType.Visible = CHBX_IsSystemUser.Checked
        TBX_ChangetoUserName.Visible = CHBX_IsSystemUser.Checked
        LBL_Changeto.Visible = CHBX_IsSystemUser.Checked
        TBX_UserName.Visible = CHBX_IsSystemUser.Checked
        LBL_UserName.Visible = CHBX_IsSystemUser.Checked
    End Sub

    Private Sub CMBX_Addnew_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CHBX_Addnew.CheckedChanged
        Dim LMISDb As New LMISEntities
        Dim Personnel As ObjectQuery(Of Person)
        If CHBX_Addnew.Checked Then
            Personnel = (From P In LMISDb.People Select P).Except(From EE In LMISDb.Employees Select EE.Person)
        Else
            Personnel = From EE In LMISDb.Employees Select EE.Person
        End If

        Dim People As New List(Of IDNdata)
        For Each Person In Personnel
            Dim Lastname As String = String.Empty
            If Person.PersonName2 IsNot Nothing Then Lastname = Person.PersonName2.Name
            People.Add(New IDNdata(Person.ID, Person.PersonName.Name & " " & Person.PersonName1.Name & " " & Lastname, True))
        Next
        CMBX_Name.DataSource = People
        CMBX_Name.DisplayMember = "Data"
        CMBX_Name.ValueMember = "ID"
        CMBX_Name.AutoCompleteSource = AutoCompleteSource.ListItems
    End Sub

    Private Sub CMBX_Name_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBX_Name.SelectedIndexChanged
        If CMBX_Name.SelectedItem IsNot Nothing Then
            If Not CHBX_Addnew.Checked Then
                Dim PersonID As String = CMBX_Name.SelectedValue
                ChangeUser((From U In (New LMISEntities).Employees Where U.PersonID = PersonID Select U.ID).Single)
            Else
                ClearForm(False)
            End If
        Else
            ClearForm(False)
        End If
    End Sub

    Private Sub FRM_MTNEmployees_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class

