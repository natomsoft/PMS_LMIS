Imports System.Data.Objects

Public Class FRM_MTNFacility

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
            CMBX_FacilityName.DataSource = From E In LMISDb.Facilities Select E
            CMBX_FacilityName.DisplayMember = "FacilityName"
            CMBX_FacilityName.ValueMember = "ID"
            CMBX_FacilityName.AutoCompleteSource = AutoCompleteSource.ListItems
            CMBX_FacilityName.SelectedItem = Nothing

            CMBX_Zone.DataSource = From E In LMISDb.Zones Select E
            CMBX_Zone.DisplayMember = "ZoneName"
            CMBX_Zone.ValueMember = "ZoneID"
            CMBX_Zone.AutoCompleteSource = AutoCompleteSource.ListItems
            CMBX_Zone.SelectedItem = Nothing

            CMBX_FacilityType.DataSource = From E In LMISDb.FacilityTypes Select E
            CMBX_FacilityType.DisplayMember = "Name"
            CMBX_FacilityType.ValueMember = "ID"
            CMBX_FacilityType.AutoCompleteSource = AutoCompleteSource.ListItems
            CMBX_FacilityType.SelectedItem = Nothing

            CMBX_Parent.DataSource = From E In LMISDb.MedicalStores Select E
            CMBX_Parent.DisplayMember = "Name"
            CMBX_Parent.ValueMember = "ID"
            CMBX_Parent.AutoCompleteSource = AutoCompleteSource.ListItems
            CMBX_Parent.SelectedItem = Nothing

            ClearForm(True)
        Catch ex As Exception
            MessageBox.Show("Error:" & vbCrLf & ex.Message & Utility.InnerExecption(ex), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Function ValidateDataForm() As Boolean
        ERP_Error.Clear()
        Dim No_Error As Boolean = True
        If CMBX_FacilityName.SelectedIndex = -1 And CMBX_FacilityName.Text = String.Empty Then
            ERP_Error.SetError(CMBX_FacilityName, "Please select or type appropriate 'Name'")
            No_Error = False
        End If
        If TBX_ChangetoName.Text <> String.Empty Then
            If (From m In CType(CMBX_FacilityName.DataSource, ObjectQuery(Of Facility)) Where m.FacilityName = TBX_ChangetoName.Text Select m).Count > 0 Then
                ERP_Error.SetError(TBX_ChangetoName, "'" & TBX_ChangetoName.Text & "' Already Exists")
                No_Error = False
            End If
        End If
        If CMBX_Zone.SelectedItem Is Nothing Then
            ERP_Error.SetError(CMBX_Zone, "Please select or type appropriate 'Zone'")
            No_Error = False
        End If
        If CMBX_Subzone.SelectedItem Is Nothing Then
            ERP_Error.SetError(CMBX_Subzone, "Please select or type appropriate 'Sub zone'")
            No_Error = False
        End If
        If CMBX_Village.SelectedItem Is Nothing Then
            ERP_Error.SetError(CMBX_Village, "Please select or type appropriate 'Village'")
            No_Error = False
        End If
        If CMBX_Zone.SelectedItem Is Nothing Then
            ERP_Error.SetError(CMBX_Zone, "Please select or type appropriate 'Zone Name'")
            No_Error = False
        End If
        If CMBX_FacilityType.SelectedItem Is Nothing Then
            ERP_Error.SetError(CMBX_FacilityType, "Please select or type appropriate 'Medical Store Type'")
            No_Error = False
        End If
        Return No_Error
    End Function

    Private Function SaveData() As Boolean
        Try
            Dim LMISDb As New LMISEntities
            Dim IsNew As Boolean = False
            Dim CRow As Facility
            Dim CheckID As String = CMBX_FacilityName.SelectedValue
            Dim EditCheck = (From EC In LMISDb.Facilities Where EC.ID = CheckID Select EC)
            If EditCheck.Count > 0 Then
                CRow = EditCheck.First
                If TBX_ChangetoName.Text <> String.Empty Then CRow.FacilityName = TBX_ChangetoName.Text
            Else
                Dim ZoneID As String = CMBX_Zone.SelectedValue
                Dim FacilityId As String
                Dim MaxID = From IJ In LMISDb.Facilities
                            Order By IJ.ID Descending
                            Select IJ
                            Where IJ.ID.StartsWith(ZoneID)
                If (MaxID.Count = 0) Then
                    FacilityId = ZoneID & "01"
                Else
                    FacilityId = Double.Parse(MaxID.First.ID) + 1
                End If                
                CRow = New Facility With {.ID = FacilityId, .FacilityName = CMBX_FacilityName.Text}
                IsNew = True
            End If           
            CRow.VillageID = CMBX_Village.SelectedValue
            CRow.MedicalStoreID = CMBX_Parent.SelectedValue
            CRow.FaciltyTypeID = CMBX_FacilityType.SelectedValue
            CRow.Owner = TBX_Owner.Text
            CRow.ContactPerson = TBX_ContactPerson.Text
            If IsNew Then LMISDb.Facilities.AddObject(CRow)
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
            CMBX_FacilityName.Text = ""            
            CMBX_FacilityName.SelectedItem = Nothing
        End If
        CMBX_Zone.SelectedItem = Nothing
        CMBX_Subzone.SelectedItem = Nothing
        CMBX_Village.SelectedItem = Nothing
        CMBX_FacilityType.SelectedItem = Nothing
        CMBX_Parent.SelectedItem = Nothing
        TBX_ChangetoName.Text = ""
        TBX_ContactPerson.Text = ""
        TBX_Owner.Text = String.Empty
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

    Private Sub CMBX_ItemCatalogue_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBX_FacilityName.SelectedIndexChanged
        If CMBX_FacilityName.SelectedItem IsNot Nothing And CMBX_FacilityName.ValueMember <> String.Empty Then            
            ClearForm(False)
            Dim LMISDb As New LMISEntities
            Dim ECID As String = CMBX_FacilityName.SelectedValue
            Dim CRow = From EC In LMISDb.Facilities Where EC.ID = ECID Select EC
            If CRow.Count > 0 Then                
                CMBX_Zone.SelectedValue = CRow.First.Village.SubZone.ZoneID
                CMBX_Subzone.SelectedValue = CRow.First.Village.SubZoneID
                CMBX_Village.SelectedValue = CRow.First.VillageID
                CMBX_Parent.SelectedValue = CRow.First.MedicalStoreID
                CMBX_FacilityType.SelectedValue = CRow.First.FaciltyTypeID
                TBX_ContactPerson.Text = CRow.First.ContactPerson
                TBX_Owner.Text = CRow.First.Owner
            End If
        End If
    End Sub

    Private Sub CMBX_ItemCatalogue_textChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBX_FacilityName.LostFocus
        If CMBX_FacilityName.SelectedItem Is Nothing Then ClearForm(False)
    End Sub

    Private Sub CMBX_Zone_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBX_Zone.SelectedIndexChanged
        If CMBX_Zone.SelectedItem IsNot Nothing And CMBX_Zone.ValueMember <> String.Empty Then
            Dim ZoneID As Integer = CMBX_Zone.SelectedValue
            CMBX_Subzone.DataSource = From D In (New LMISEntities).SubZones Where D.ZoneID = ZoneID Select D
            CMBX_Subzone.DisplayMember = "SubZoneName"
            CMBX_Subzone.ValueMember = "SubZoneID"
            CMBX_Subzone.AutoCompleteSource = AutoCompleteSource.ListItems
            CMBX_Subzone.SelectedItem = Nothing
        Else
            CMBX_Subzone.DataSource = Nothing
        End If
    End Sub

    Private Sub CMBX_Subzone_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBX_Subzone.SelectedIndexChanged
        If CMBX_Subzone.SelectedItem IsNot Nothing And CMBX_Subzone.ValueMember <> String.Empty Then
            Dim SubZoneID As Integer = CMBX_Subzone.SelectedValue
            CMBX_Village.DataSource = From D In (New LMISEntities).Villages Where D.SubZoneID = SubZoneID Select D
            CMBX_Village.DisplayMember = "VillageName"
            CMBX_Village.ValueMember = "VillageID"
            CMBX_Village.AutoCompleteSource = AutoCompleteSource.ListItems
            CMBX_Village.SelectedItem = Nothing
        Else
            CMBX_Village.DataSource = Nothing
        End If
    End Sub

#End Region
 
End Class

