Public Class Search_Items
    Dim rowIndex As Integer = 0
    Private Sub nameTextBox_TextChanged(sender As Object, e As System.EventArgs) Handles nameTextBox.TextChanged
        Dim nameStr As String = nameTextBox.Text
        If nameStr = "" Then
            itemsDataGridView.Rows.Clear()
        Else
            itemsDataGridView.Rows.Clear()
            Using context As New LMISEntities
                Dim rs = From x In context.InventoryItems Where x.Name.Contains(nameStr) Select x.ID, x.Name

                For Each r In rs
                    rowIndex = itemsDataGridView.Rows.Add
                    With itemsDataGridView.Rows(rowIndex)
                        .Cells(0).Value = r.ID
                        .Cells(1).Value = r.Name
                    End With
                Next

            End Using

        End If
    End Sub
End Class