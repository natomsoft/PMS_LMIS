Public Class FRM_MTNCatalogue

    Public Sub New()
        InitializeComponent()
        Me.MdiParent = FRM_GLBMain
        LoadForm()
    End Sub

    Dim RemovedItemIDs As New List(Of String)
    Private Sub DGV_Beds_UserDeletingItemRow(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowCancelEventArgs) Handles DGV_Items.UserDeletingRow
        If e.Row.Cells("ItemID").Value = CMBX_ItemCatalogueID.SelectedValue Then
            e.Cancel = True
            Exit Sub
        End If
        If DGV_Items.Rows.Count <> 0 Then RemovedItemIDs.Add(e.Row.Cells("ItemID").Value)
    End Sub
    Dim RemovedSRIDs As New List(Of String)
    Private Sub DGV_Beds_UserDeletingSRRow(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowCancelEventArgs) Handles DGV_SR.UserDeletingRow
        If DGV_SR.Rows.Count <> 0 Then RemovedSRIDs.Add(e.Row.Cells("SRID").Value)
    End Sub

#Region "Utilities"

    Private Sub LoadForm()
        Try
            Dim LMISDb As New LMISEntities
            Dim Catalogues = From I In LMISDb.ItemsCatalogues Select I
            CMBX_ItemCatalogueID.DataSource = Catalogues
            CMBX_ItemCatalogueID.DisplayMember = "ID"
            CMBX_ItemCatalogueID.ValueMember = "ID"
            CMBX_ItemCatalogueID.SelectedItem = Nothing
            CMBX_ItemCatalogueID.AutoCompleteSource = AutoCompleteSource.ListItems

            CMBX_ItemCatalogueName.DataSource = Catalogues
            CMBX_ItemCatalogueName.DisplayMember = "Name"
            CMBX_ItemCatalogueName.ValueMember = "ID"
            CMBX_ItemCatalogueName.SelectedItem = Nothing
            CMBX_ItemCatalogueName.AutoCompleteSource = AutoCompleteSource.ListItems

            CMBX_Category.DataSource = From C In LMISDb.InventoryCategories Select C
            CMBX_Category.DisplayMember = "Name"
            CMBX_Category.ValueMember = "ID"
            CMBX_Category.AutoCompleteSource = AutoCompleteSource.ListItems

            CMBX_TherapeuticClass.DataSource = From T In LMISDb.TherapeuticClasses Select T
            CMBX_TherapeuticClass.DisplayMember = "Name"
            CMBX_TherapeuticClass.ValueMember = "ID"
            CMBX_TherapeuticClass.AutoCompleteSource = AutoCompleteSource.ListItems

            CMBX_PrescriptionStatus.DataSource = From P In LMISDb.PrescriptionStatus Select P
            CMBX_PrescriptionStatus.DisplayMember = "Status"
            CMBX_PrescriptionStatus.ValueMember = "ID"
            CMBX_PrescriptionStatus.AutoCompleteSource = AutoCompleteSource.ListItems

            CMBX_LevelOfUse.DataSource = From L In LMISDb.LevelOfUses Select L
            CMBX_LevelOfUse.DisplayMember = "Description"
            CMBX_LevelOfUse.ValueMember = "ID"
            CMBX_LevelOfUse.AutoCompleteSource = AutoCompleteSource.ListItems

            CMBX_RouteOfAdministration.DataSource = From R In LMISDb.RouteOfAdministrations Select R
            CMBX_RouteOfAdministration.DisplayMember = "Name"
            CMBX_RouteOfAdministration.ValueMember = "ID"
            CMBX_RouteOfAdministration.AutoCompleteSource = AutoCompleteSource.ListItems
            ClearForm(True)
        Catch ex As Exception
            MessageBox.Show("Error:" & vbCrLf & ex.Message & Utility.InnerExecption(ex), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Function ValidateDataForm() As Boolean
        ERP_Error.Clear()
        Dim No_Error As Boolean = True
        If CMBX_ItemCatalogueID.SelectedIndex = -1 And CMBX_ItemCatalogueID.Text = String.Empty Then
            ERP_Error.SetError(CMBX_ItemCatalogueID, "Please select or type appropriate 'Catalogue ID'")
            No_Error = False
        End If
        If TBX_ItemName.Text = String.Empty Then
            ERP_Error.SetError(TBX_ItemName, "'Item Name' should not be empty")
            No_Error = False
        ElseIf CMBX_ItemCatalogueID.SelectedIndex = -1 Then
            If (From I In (New LMISEntities).InventoryItems Where I.Name = TBX_ItemName.Text Select I).Count > 0 Then
                ERP_Error.SetError(TBX_ItemName, "Item Name '" & TBX_ItemName.Text & "' already exists")
                No_Error = False
            End If
        End If
        If CMBX_Category.SelectedIndex = -1 Or CMBX_Category.Text = String.Empty Then
            ERP_Error.SetError(CMBX_Category, "Please select appropriate 'Category' from the list")
            No_Error = False
        End If
        If CMBX_TherapeuticClass.SelectedIndex = -1 Or CMBX_TherapeuticClass.Text = String.Empty Then
            ERP_Error.SetError(CMBX_TherapeuticClass, "Please select appropriate 'Therapeutic Class' from the list")
            No_Error = False
        End If
        If CMBX_PrescriptionStatus.SelectedIndex = -1 Or CMBX_PrescriptionStatus.Text = String.Empty Then
            ERP_Error.SetError(CMBX_PrescriptionStatus, "Please select appropriate 'Prescription Status' from the list")
            No_Error = False
        End If
        If CMBX_LevelOfUse.SelectedIndex = -1 Or CMBX_LevelOfUse.Text = String.Empty Then
            ERP_Error.SetError(CMBX_LevelOfUse, "Please select appropriate 'Level Of Use' from the list")
            No_Error = False
        End If
        If CMBX_RouteOfAdministration.SelectedIndex = -1 Or CMBX_RouteOfAdministration.Text = String.Empty Then
            ERP_Error.SetError(CMBX_RouteOfAdministration, "Please select appropriate 'Route Of Administration' from the list")
            No_Error = False
        End If
        If Not DGV_SR.ValidateData() Then
            ERP_Error.SetError(DGV_SR, "Please correct your errors in the table")
            No_Error = False
        End If
        If DGV_Items.Rows.Count = 1 Then
            ERP_Error.SetError(DGV_Items, "At least one item should be entered")
            No_Error = False
            'Else
            '    Dim ICatalogueasItem As Boolean = False
            '    For Each ItemRow As DataGridViewRow In DGV_Items.Rows
            '        If Not ItemRow.IsNewRow Then
            '            If ItemRow.Cells("ItemID").Value = CMBX_ItemCatalogueID.Text And ItemRow.Cells("Item_Name").Value = TBX_ItemName.Text Then ICatalogueasItem = True
            '        End If
            '    Next
            '    If Not ICatalogueasItem Then
            '        ERP_Error.SetError(DGV_Items, "Error:" & vbCrLf & "There should be an Item with the Item catalogue's ID: '" & CMBX_ItemCatalogueID.Text & "' and name '" & TBX_ItemName.Text & "'")
            '        No_Error = False
            '    End If
        End If
        If Not DGV_Items.ValidateData() Then
            ERP_Error.SetError(DGV_Items, "Please correct your errors in the table")
            No_Error = False
        End If
        Return No_Error
    End Function

    Private Function SaveData() As Boolean
        Dim DeleteException As Boolean = False
        Try
            Dim LMISDb As New LMISEntities
            Dim IsNewItemCatalogue As Boolean = False
            Dim ItemCatalogue As ItemsCatalogue
            Dim ItemCatalogueCheck = (From IC In LMISDb.ItemsCatalogues Where IC.ID = CMBX_ItemCatalogueID.Text Select IC)
            If ItemCatalogueCheck.Count > 0 Then
                ItemCatalogue = ItemCatalogueCheck.First
            Else
                ItemCatalogue = New ItemsCatalogue
                ItemCatalogue.ID = CMBX_ItemCatalogueID.Text
                IsNewItemCatalogue = True
            End If
            With ItemCatalogue
                .Name = TBX_ItemName.Text
                .InventoryCategoryID = CMBX_Category.SelectedValue
                .Expires = CHBX_ItemExpires.Checked
                .TherapeuticClassID = CMBX_TherapeuticClass.SelectedValue
                .PrescriptionStatusID = CMBX_PrescriptionStatus.SelectedValue
                .LevelOfUseID = CMBX_LevelOfUse.SelectedValue
                .RouteofAdministrationID = CMBX_RouteOfAdministration.SelectedValue
            End With
            If IsNewItemCatalogue Then LMISDb.ItemsCatalogues.AddObject(ItemCatalogue)
            For Each SR As DataGridViewRow In DGV_SR.Rows
                If Not SR.IsNewRow Then
                    If Not DGV_SR.IsInDatabase(SR) Then
                        LMISDb.StorageRequirements.AddObject(New StorageRequirement With {
                                .ItemsCatalogueID = ItemCatalogue.ID,
                                .StorageRequirementTypeID = CType(SR.Cells("SRType"), ComboCellGeneral).SelectedValue,
                                .MinValue = SR.Cells("Minimum").Value(),
                                .MaxValue = SR.Cells("Maximum").Value()
                            })
                    Else
                        Dim SRID As Integer = SR.Cells("SRID").Value
                        With (From SRT In LMISDb.StorageRequirements Where SRT.ID = SRID Select SRT).First
                            .StorageRequirementTypeID = CType(SR.Cells("SRType"), ComboCellGeneral).SelectedValue
                            .MinValue = SR.Cells("Minimum").Value()
                            .MaxValue = SR.Cells("Maximum").Value()
                        End With
                    End If
                End If
            Next
            For Each Item As DataGridViewRow In DGV_Items.Rows
                If Not Item.IsNewRow Then
                    If Not DGV_Items.IsInDatabase(Item) Then
                        LMISDb.InventoryItems.AddObject(New InventoryItem With {
                                .ID = Item.Cells("ItemID").Value,
                                .OldItemCode = Item.Cells("Old_Item_Code").Value,
                                .Name = Item.Cells("Item_Name").Value,
                                .UnitID = CType(Item.Cells("Unit"), ComboCellGeneral).SelectedValue,
                                .ItemsCatalogueID = ItemCatalogue.ID,
                                .MinQty = Val(Item.Cells("MinQty").Value),
                                .MaxQty = Val(Item.Cells("MaxQty").Value),
                                .ReorderQty = Val(Item.Cells("ReorderQty").Value),
                                .PackSize = Val(Item.Cells("PackSize").Value)
                            })
                    Else
                        Dim ItemID As String = Item.Cells("ItemIDOriginal").Value
                        With (From I In LMISDb.InventoryItems Where I.ID = ItemID Select I).First
                            .ID = Item.Cells("ItemID").Value
                            .OldItemCode = Item.Cells("Old_Item_Code").Value
                            .Name = Item.Cells("Item_Name").Value
                            .UnitID = CType(Item.Cells("Unit"), ComboCellGeneral).SelectedValue
                            .MinQty = Val(Item.Cells("MinQty").Value)
                            .MaxQty = Val(Item.Cells("MaxQty").Value)
                            .ReorderQty = Val(Item.Cells("ReorderQty").Value)
                            .PackSize = Val(Item.Cells("PackSize").Value)
                        End With
                    End If
                End If
            Next
            LMISDb.SaveChanges()
            For Each RDID In RemovedSRIDs
                Dim IDDel As String = RDID

                Dim RDeletedD = From RD In LMISDb.StorageRequirements Where RD.ID = IDDel Select RD
                If RDeletedD.Count > 0 Then
                    LMISDb.StorageRequirements.DeleteObject(RDeletedD.First)
                    Try
                        LMISDb.SaveChanges()
                    Catch ex As Exception
                        DeleteException = True
                        MsgBox("Can not delete Storage requirement '" & RDeletedD.First.StorageRequirementType.Type & "', because it has been used on other parts of the database")
                    End Try
                End If
            Next
            For Each RDID In RemovedItemIDs
                Dim IDDel As String = RDID

                Dim RDeletedD = From RD In LMISDb.InventoryItems Where RD.ID = IDDel Select RD
                If RDeletedD.Count > 0 Then
                    LMISDb.InventoryItems.DeleteObject(RDeletedD.First)
                    Try
                        LMISDb.SaveChanges()
                    Catch ex As Exception
                        DeleteException = True
                        MsgBox("Can not delete Item '" & RDeletedD.First.Name & "', because it has been used on other parts of the database")
                    End Try
                End If
            Next
            Return True
        Catch ex As Exception
            If Not DeleteException Then
                MessageBox.Show("Error: In Saving Data" & vbCrLf & ex.Message & Utility.InnerExecption(ex), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return False
            Else
                Return True
            End If
        End Try
        Return False
    End Function

    Private Sub ClearForm(ByVal CatalogueClear As Boolean)
        If CatalogueClear Then
            CMBX_ItemCatalogueID.Text = ""
            CMBX_ItemCatalogueID.SelectedItem = Nothing
        End If
        TBX_ItemName.Text = ""
        CMBX_Category.SelectedItem = Nothing
        CMBX_LevelOfUse.SelectedItem = Nothing
        CMBX_TherapeuticClass.SelectedItem = Nothing
        CMBX_PrescriptionStatus.SelectedItem = Nothing
        CMBX_LevelOfUse.SelectedItem = Nothing
        CMBX_RouteOfAdministration.SelectedItem = Nothing
        DGV_SR.Rows.Clear()
        DGV_Items.Rows.Clear()
    End Sub

    Private Sub ChangeItem(ByVal ItemCatalogueID As String)
        ClearForm(False)
        Dim LMISDb As New LMISEntities
        Dim ItemCatalogue = From IC In LMISDb.ItemsCatalogues Where IC.ID = ItemCatalogueID Select IC
        If ItemCatalogue.Count > 0 Then
            With ItemCatalogue.First
                TBX_ItemName.Text = .Name
                CMBX_Category.SelectedValue = .InventoryCategoryID
                CMBX_TherapeuticClass.SelectedValue = .TherapeuticClassID
                CMBX_PrescriptionStatus.SelectedValue = .PrescriptionStatusID
                CMBX_LevelOfUse.SelectedValue = .LevelOfUseID
                CMBX_RouteOfAdministration.SelectedValue = .RouteofAdministrationID
                CHBX_ItemExpires.Checked = .Expires
            End With
            For Each SRT In (From SR In LMISDb.StorageRequirements Where SR.ItemsCatalogueID = ItemCatalogueID Select SR)
                Dim NewRow = DGV_SR.Rows(DGV_SR.Rows.Add())
                With NewRow
                    .Cells("SRType").Value = SRT.StorageRequirementType.Type
                    .Cells("SRID").Value = SRT.ID
                    CType(.Cells("SRType"), ComboCellGeneral).SelectedValue = SRT.StorageRequirementType.ID
                    .Cells("Minimum").Value = SRT.MinValue
                    .Cells("Maximum").Value = SRT.MinValue
                    DGV_SR.IsInDatabase(NewRow) = True
                End With
            Next
            For Each InvItem In From I In LMISDb.InventoryItems Where I.ItemsCatalogueID = ItemCatalogueID Select I
                Dim NewRow = DGV_Items.Rows(DGV_Items.Rows.Add())
                With NewRow
                    .Cells("ItemIDOriginal").Value = InvItem.ID
                    '.Cells("ItemID").ReadOnly = True
                    .Cells("ItemID").Style.BackColor = Color.FromArgb(200, 200, 200)
                    .Cells("ItemID").Value = InvItem.ID
                    .Cells("Item_Name").Value = InvItem.Name
                    .Cells("Old_Item_Code").Value = InvItem.OldItemCode
                    .Cells("Unit").Value = InvItem.Unit.Name
                    CType(.Cells("Unit"), ComboCellGeneral).SelectedValue = InvItem.Unit.ID
                    .Cells("MinQty").Value = InvItem.MinQty
                    .Cells("MaxQty").Value = InvItem.MaxQty
                    .Cells("ReorderQty").Value = InvItem.ReorderQty
                    .Cells("PackSize").Value = InvItem.PackSize
                    DGV_Items.IsInDatabase(NewRow) = True
                End With
            Next
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

    Private Sub CMBX_ItemCatalogue_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBX_ItemCatalogueID.SelectedIndexChanged
        If CMBX_ItemCatalogueID.ValueMember <> String.Empty Then ChangeItem(CMBX_ItemCatalogueID.SelectedValue)
        RemovedItemIDs.Clear()
        RemovedSRIDs.Clear()
    End Sub

    Private Sub CMBX_ItemCatalogue_textChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CMBX_ItemCatalogueID.LostFocus
        If CMBX_ItemCatalogueID.SelectedValue Is Nothing Then
            ClearForm(False)
            Dim NewItem = DGV_Items.Rows(DGV_Items.Rows.Add())
            With NewItem
                .Cells("ItemID").Value = CMBX_ItemCatalogueID.Text
                '.Cells("ItemID").ReadOnly = True 'allow them to be editted only from the parent combobox and textbox
                '.Cells("Item_Name").ReadOnly = True
            End With
        End If
    End Sub

    Private Sub TBX_ItemName_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TBX_ItemName.TextChanged
        For Each ItemRow As DataGridViewRow In DGV_Items.Rows
            'If Not ItemRow.IsNewRow Then If ItemRow.Cells("ItemID").Value = CMBX_ItemCatalogueID.Text Then ItemRow.Cells("Item_Name").Value = TBX_ItemName.Text
        Next
    End Sub

    Private Sub FRM_ItemAddNew_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        DGV_SR.initMe(DGV_GTypes.StorageReqTypeOnly)
        DGV_Items.initMe(DGV_GTypes.ItemAddEdit)
    End Sub

#End Region

End Class

