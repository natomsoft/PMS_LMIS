Imports System.Data.Objects

Public Class FRM_MTNSetLocation

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
            CMBX_Facility.DataSource = From F In LMISDb.Facilities Select F.ID, F.FacilityName
            CMBX_Facility.DisplayMember = "FacilityName"
            CMBX_Facility.ValueMember = "ID"
            CMBX_Facility.AutoCompleteSource = AutoCompleteSource.ListItems
            CMBX_Facility.SelectedItem = Nothing
            Dim FacilityAddress = From FA In LMISDb.Facility_Addres Select FA
            If FacilityAddress.Count > 0 Then
                With FacilityAddress.First
                    TBX_Tele1.Text = .Tele1
                    TBX_Tele2.Text = .Tele2
                    TBX_Fax.Text = .Fax
                    TBX_POBox.Text = .PO_Box
                    TBX_Email.Text = .Email
                    TBX_Address.Text = .Address
                    TBX_ProfitMargin.Text = .ProfitMargin
                End With
            End If
            ClearForm(True)
        Catch ex As Exception
            MessageBox.Show("Error:" & vbCrLf & ex.Message & Utility.InnerExecption(ex), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Function ValidateDataForm() As Boolean
        ERP_Error.Clear()
        Dim No_Error As Boolean = True
        If CMBX_Department.SelectedItem Is Nothing Then
            ERP_Error.SetError(CMBX_Department, "Please select your Facility")
            No_Error = False
        End If

        If TBX_ProfitMargin.Text <> String.Empty Then
            If Not IsNumeric(TBX_ProfitMargin.Text) Then
                ERP_Error.SetError(TBX_ProfitMargin, "Please enter appropriate profit margin")
                No_Error = False
            ElseIf Val(TBX_ProfitMargin.Text) < 0 Then
                ERP_Error.SetError(TBX_ProfitMargin, "Please enter appropriate profit margin")
                No_Error = False
            End If
        End If
        Return No_Error
    End Function

    Private Function SaveData() As Boolean
        Try
            Dim LMISDb As New LMISEntities
            Dim FacilityAddr As Facility_Addres
            Dim isNew As Boolean = False
            Dim ThisDepartment = From FID In LMISDb.Departments
                                 Where FID.Active = True
                                 Select FID

            For Each Depa In ThisDepartment
                Depa.Active = False
            Next
            Dim FacilityAddress = From FA In LMISDb.Facility_Addres Select FA

            If FacilityAddress.Count > 0 Then
                FacilityAddr = FacilityAddress.First
            Else
                isNew = True
                FacilityAddr = New Facility_Addres
            End If
            With FacilityAddr
                If (TBX_Tele1.Text <> String.Empty) Then
                    .Tele1 = TBX_Tele1.Text
                Else
                    .Tele1 = Nothing
                End If
                If (TBX_Tele2.Text <> String.Empty) Then
                    .Tele2 = TBX_Tele2.Text
                Else
                    .Tele2 = Nothing
                End If
                If (TBX_Fax.Text <> String.Empty) Then
                    .Fax = TBX_Fax.Text
                Else
                    .Fax = Nothing
                End If
                If (TBX_POBox.Text <> String.Empty) Then
                    .PO_Box = TBX_POBox.Text
                Else
                    .PO_Box = Nothing
                End If
                If (TBX_Email.Text <> String.Empty) Then
                    .Email = TBX_Email.Text
                Else
                    .Email = Nothing
                End If
                If (TBX_Address.Text <> String.Empty) Then
                    .Address = TBX_Address.Text
                Else
                    .Address = Nothing
                End If        
                .ProfitMargin = Val(TBX_ProfitMargin.Text)
            End With
            If isNew Then LMISDb.Facility_Addres.AddObject(FacilityAddr)
            LMISDb.SaveChanges()

            Dim DepartmentID As String = CMBX_Department.SelectedValue
            Dim ConDepartment = (From D In LMISDb.Departments Select D Where D.ID = DepartmentID).Single
            ConDepartment.Active = True
            LMISDb.SaveChanges()
            FRM_GLBMain.ApplicationConfig.ThisDepartment = ConDepartment
            Return (True)
        Catch ex As Exception
            MessageBox.Show("Error:" & vbCrLf & ex.Message & Utility.InnerExecption(ex), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try
        Return False
    End Function

    Private Sub ClearForm(ByVal NameClear As Boolean)
        If NameClear Then
            CMBX_Facility.Text = ""
            CMBX_Facility.SelectedItem = Nothing
        End If

    End Sub

#End Region

#Region "Events"

    Private Sub BTN_Close_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub
    Public Sub ShowForm()
        Me.Show()
    End Sub

    Private Sub clearAddress()
        TBX_Tele1.Text = String.Empty
        TBX_Tele2.Text = String.Empty
        TBX_Fax.Text = String.Empty
        TBX_POBox.Text = String.Empty
        TBX_Email.Text = String.Empty
        TBX_Address.Text = String.Empty
    End Sub
    Private Sub BTN_Save_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTN_Save.Click
        If ValidateDataForm() Then
            If SaveData() Then
                MessageBox.Show("Set Facility Saved." & vbCrLf & vbCrLf & "LMIS will log you off to enter the profile of the Facility you selected.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                Me.Close()
                FRM_GLBLogin.Show()
                FRM_GLBMain.Close()
            Else
                MessageBox.Show("  Data NOT Saved    ", "Error in Saving", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End If
    End Sub

    Private Sub CMBX_Facility_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBX_Facility.SelectedIndexChanged
        clearAddress()
        If CMBX_Facility.SelectedItem IsNot Nothing And CMBX_Facility.ValueMember <> String.Empty Then
            Dim FacilityID As String = CMBX_Facility.SelectedValue
            CMBX_Department.DataSource = From D In (New LMISEntities).Departments Where D.FacilityID = FacilityID And D.DepartmentType.Description <> "Level 4N" Select D
            CMBX_Department.DisplayMember = "Name"
            CMBX_Department.ValueMember = "ID"
            CMBX_Department.SelectedItem = Nothing
        Else
            CMBX_Department.DataSource = Nothing
        End If
    End Sub

    Private Sub CMBX_Department_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBX_Department.SelectedIndexChanged
        clearAddress()
    End Sub

    Private Sub CMBX_ItemCatalogue_textChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBX_Facility.LostFocus
        If CMBX_Facility.SelectedItem Is Nothing Then ClearForm(False)
    End Sub

#End Region

    Private Sub FRM_MTNThisDepartment_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.FormClosed
        If Utility.GetMyDepartment() Is Nothing Then
            FRM_GLBMain.Close()
        End If
    End Sub

End Class

