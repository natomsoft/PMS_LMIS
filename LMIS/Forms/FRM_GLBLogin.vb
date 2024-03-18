
Public Class FRM_GLBLogin

    Private Sub OK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK.Click
        Try
            'If Date.Today > New Date(2015, 5, 1) Then
            '    MessageBox.Show("This version of LMIS is intended for demonstration purposes only and it's trial period has ended." & vbCrLf & vbCrLf & "To continue using this application install the Non-demo version of the software.")
            '    Me.Close()
            'End If
            Dim theEncryptDecrypt As New hlpPasswordEncryptDecrypt
            Dim LMISDb As New LMISEntities
            Dim theUserName = UsernameTextBox.Text, thePassword = theEncryptDecrypt.Encrypt(PasswordTextBox.Text)            
            'UsernameTextBox.Text = thePassword
            Dim theUser As Employee = (From it As Employee In LMISDb.Employees
                                       Join D In LMISDb.Departments
                                            On D.ID Equals it.DepartmentID
                                       Where it.IsSystemUser = True And it.UserName = theUserName And it.Password = thePassword And it.EmployeeStatu.Status.ToLower = "active" And
                                       ((D.Active = True And theUserName <> "admin") Or (theUserName = "admin"))
                                       Select it).Single
            If theUser.ID Then
                FRM_GLBMain.Show(theUser)
            Else
                MsgBox("You don't have the privileges to login in to this system, please contact your system admin.", MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly)
            End If
            Me.Close()
        Catch ex As InvalidOperationException
            MessageBox.Show("The system could not log you in." & vbNewLine & "Please check your user name and password.", "User not found", MessageBoxButtons.OK, MessageBoxIcon.Error)
            PasswordTextBox.Clear()
            UsernameTextBox.Focus()
        Catch ex As Exception
            If ex.InnerException Is Nothing Then
                MessageBox.Show(ex.Message + vbNewLine + ex.StackTrace, ex.Source, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Else
                MessageBox.Show(ex.InnerException.Message + vbNewLine + ex.StackTrace, ex.Source, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End Try
    End Sub

    Private Sub Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel.Click
        Me.Close()
    End Sub

    Private Sub FRM_GLBLogin_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Dim LMISDb As New LMISEntities
        'Dim MaxID = (From IPDReq In LMISDb.IPDRequisitions
        '            Join IPDIss In LMISDb.IPDIssues
        '                On IPDIss.IPDRequisitionID Equals IPDReq.ID
        '            Where IPDIss.InventoryJournal.DepartmentID = "6010001"
        '            Select IPDReq).Union(From IPDReq In LMISDb.IPDRequisitions
        '            Where IPDReq.InventoryJournal.DepartmentID = "6010001"
        '            Select IPDReq)
        'For Each ipd In MaxID
        '    MsgBox(ipd.ID)

        'Next        
    End Sub

End Class
