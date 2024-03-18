Public Class ApplicationConfigs
    Private PrivateEmployee As Employee
    Private PrivateThisDepapartment As Department
    Public Property ThisDepartment As Department
        Set(ByVal value As Department)
            PrivateThisDepapartment = value
            If value Is Nothing Then
                FRM_GLBMain.Text = ""
                FRM_GLBMain.ThisDepartment.Text = ""
            Else
                FRM_GLBMain.Text = "PMS-LMIS, " & PrivateThisDepapartment.Facility.FacilityName & " [" & PrivateThisDepapartment.DepartmentType.Type & "]"
                FRM_GLBMain.ThisDepartment.Text = PrivateThisDepapartment.Name
                FRM_GLBMain.LoadLevelProfile(PrivateThisDepapartment.DepartmentType.Description)
                'MsgBox(PrivateThisDepapartment.DepartmentType.Description)
            End If
        End Set
        Get
            Return PrivateThisDepapartment
        End Get
    End Property
    Public Property Employee As Employee
        Set(ByVal value As Employee)
            PrivateEmployee = value            
        End Set
        Get
            Return PrivateEmployee
        End Get
    End Property

End Class


