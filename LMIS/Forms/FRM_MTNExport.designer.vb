<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FRM_MTNExport
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.ERP_Error = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.Label16 = New System.Windows.Forms.Label()
        Me.ShapeContainer1 = New Microsoft.VisualBasic.PowerPacks.ShapeContainer()
        Me.LineShape6 = New Microsoft.VisualBasic.PowerPacks.LineShape()
        Me.LineShape4 = New Microsoft.VisualBasic.PowerPacks.LineShape()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TBX_ExportFile = New System.Windows.Forms.TextBox()
        Me.BTN_Brows = New System.Windows.Forms.Button()
        Me.LBL_Objects = New System.Windows.Forms.Label()
        Me.BTN_Export = New System.Windows.Forms.Button()
        Me.BTN_Close = New System.Windows.Forms.Button()
        Me.SFD_ExportFile = New System.Windows.Forms.SaveFileDialog()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.DTP_FromDate = New System.Windows.Forms.DateTimePicker()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.DTP_ToDate = New System.Windows.Forms.DateTimePicker()
        Me.CMBX_ExportType = New System.Windows.Forms.ComboBox()
        Me.PGB_Progress = New System.Windows.Forms.ProgressBar()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn8 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn9 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.ERP_Error, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ERP_Error
        '
        Me.ERP_Error.ContainerControl = Me
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.Color.White
        Me.Label16.Location = New System.Drawing.Point(15, 166)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(74, 16)
        Me.Label16.TabIndex = 57
        Me.Label16.Text = "Export File:"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'ShapeContainer1
        '
        Me.ShapeContainer1.Location = New System.Drawing.Point(0, 0)
        Me.ShapeContainer1.Margin = New System.Windows.Forms.Padding(0)
        Me.ShapeContainer1.Name = "ShapeContainer1"
        Me.ShapeContainer1.Shapes.AddRange(New Microsoft.VisualBasic.PowerPacks.Shape() {Me.LineShape6, Me.LineShape4})
        Me.ShapeContainer1.Size = New System.Drawing.Size(369, 281)
        Me.ShapeContainer1.TabIndex = 61
        Me.ShapeContainer1.TabStop = False
        '
        'LineShape6
        '
        Me.LineShape6.BorderColor = System.Drawing.Color.LightGray
        Me.LineShape6.Name = "LineShape6"
        Me.LineShape6.X1 = 9
        Me.LineShape6.X2 = 357
        Me.LineShape6.Y1 = 231
        Me.LineShape6.Y2 = 231
        '
        'LineShape4
        '
        Me.LineShape4.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LineShape4.BorderColor = System.Drawing.Color.LightGray
        Me.LineShape4.Name = "LineShape4"
        Me.LineShape4.X1 = 10
        Me.LineShape4.X2 = 358
        Me.LineShape4.Y1 = 51
        Me.LineShape4.Y2 = 51
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(10, 9)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(98, 31)
        Me.Label4.TabIndex = 68
        Me.Label4.Text = "Export"
        '
        'TBX_ExportFile
        '
        Me.TBX_ExportFile.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TBX_ExportFile.Location = New System.Drawing.Point(18, 185)
        Me.TBX_ExportFile.Name = "TBX_ExportFile"
        Me.TBX_ExportFile.ReadOnly = True
        Me.TBX_ExportFile.Size = New System.Drawing.Size(257, 22)
        Me.TBX_ExportFile.TabIndex = 82
        '
        'BTN_Brows
        '
        Me.BTN_Brows.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTN_Brows.Location = New System.Drawing.Point(281, 183)
        Me.BTN_Brows.Name = "BTN_Brows"
        Me.BTN_Brows.Size = New System.Drawing.Size(66, 26)
        Me.BTN_Brows.TabIndex = 3
        Me.BTN_Brows.Text = "Browse"
        Me.BTN_Brows.UseVisualStyleBackColor = True
        '
        'LBL_Objects
        '
        Me.LBL_Objects.AutoSize = True
        Me.LBL_Objects.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBL_Objects.ForeColor = System.Drawing.Color.White
        Me.LBL_Objects.Location = New System.Drawing.Point(13, 74)
        Me.LBL_Objects.Name = "LBL_Objects"
        Me.LBL_Objects.Size = New System.Drawing.Size(94, 16)
        Me.LBL_Objects.TabIndex = 85
        Me.LBL_Objects.Text = "Data to export:"
        Me.LBL_Objects.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'BTN_Export
        '
        Me.BTN_Export.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTN_Export.Location = New System.Drawing.Point(203, 239)
        Me.BTN_Export.Name = "BTN_Export"
        Me.BTN_Export.Size = New System.Drawing.Size(75, 28)
        Me.BTN_Export.TabIndex = 4
        Me.BTN_Export.Text = "Export"
        Me.BTN_Export.UseVisualStyleBackColor = True
        '
        'BTN_Close
        '
        Me.BTN_Close.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTN_Close.Location = New System.Drawing.Point(284, 239)
        Me.BTN_Close.Name = "BTN_Close"
        Me.BTN_Close.Size = New System.Drawing.Size(75, 28)
        Me.BTN_Close.TabIndex = 5
        Me.BTN_Close.Text = "Close"
        Me.BTN_Close.UseVisualStyleBackColor = True
        '
        'SFD_ExportFile
        '
        Me.SFD_ExportFile.DefaultExt = "xml"
        Me.SFD_ExportFile.Filter = "Script Files |*.xml"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(13, 120)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(74, 16)
        Me.Label1.TabIndex = 90
        Me.Label1.Text = "From Date:"
        '
        'DTP_FromDate
        '
        Me.DTP_FromDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DTP_FromDate.Location = New System.Drawing.Point(16, 139)
        Me.DTP_FromDate.Name = "DTP_FromDate"
        Me.DTP_FromDate.Size = New System.Drawing.Size(159, 22)
        Me.DTP_FromDate.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(185, 120)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(60, 16)
        Me.Label2.TabIndex = 92
        Me.Label2.Text = "To Date:"
        '
        'DTP_ToDate
        '
        Me.DTP_ToDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DTP_ToDate.Location = New System.Drawing.Point(188, 139)
        Me.DTP_ToDate.Name = "DTP_ToDate"
        Me.DTP_ToDate.Size = New System.Drawing.Size(159, 22)
        Me.DTP_ToDate.TabIndex = 2
        '
        'CMBX_ExportType
        '
        Me.CMBX_ExportType.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.CMBX_ExportType.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBX_ExportType.FormattingEnabled = True
        Me.CMBX_ExportType.Items.AddRange(New Object() {"Transactions", "Facilities", "Catalogues"})
        Me.CMBX_ExportType.Location = New System.Drawing.Point(16, 93)
        Me.CMBX_ExportType.Name = "CMBX_ExportType"
        Me.CMBX_ExportType.Size = New System.Drawing.Size(335, 24)
        Me.CMBX_ExportType.TabIndex = 0
        '
        'PGB_Progress
        '
        Me.PGB_Progress.Location = New System.Drawing.Point(18, 213)
        Me.PGB_Progress.MarqueeAnimationSpeed = 0
        Me.PGB_Progress.Name = "PGB_Progress"
        Me.PGB_Progress.Size = New System.Drawing.Size(257, 12)
        Me.PGB_Progress.TabIndex = 94
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.HeaderText = "SRTypeID"
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        Me.DataGridViewTextBoxColumn1.Visible = False
        Me.DataGridViewTextBoxColumn1.Width = 105
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.FillWeight = 121.8274!
        Me.DataGridViewTextBoxColumn2.HeaderText = "Storage Requirement Type"
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        Me.DataGridViewTextBoxColumn2.Visible = False
        Me.DataGridViewTextBoxColumn2.Width = 144
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.FillWeight = 89.0863!
        Me.DataGridViewTextBoxColumn3.HeaderText = "Minimum"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.ReadOnly = True
        Me.DataGridViewTextBoxColumn3.Width = 106
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.FillWeight = 89.0863!
        Me.DataGridViewTextBoxColumn4.HeaderText = "Maximum"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.ReadOnly = True
        Me.DataGridViewTextBoxColumn4.Width = 104
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.FillWeight = 70.0!
        Me.DataGridViewTextBoxColumn5.HeaderText = "Item Code"
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        Me.DataGridViewTextBoxColumn5.ReadOnly = True
        Me.DataGridViewTextBoxColumn5.Width = 105
        '
        'DataGridViewTextBoxColumn6
        '
        Me.DataGridViewTextBoxColumn6.FillWeight = 121.8274!
        Me.DataGridViewTextBoxColumn6.HeaderText = "Item Name"
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        Me.DataGridViewTextBoxColumn6.ReadOnly = True
        Me.DataGridViewTextBoxColumn6.Visible = False
        Me.DataGridViewTextBoxColumn6.Width = 122
        '
        'DataGridViewTextBoxColumn7
        '
        Me.DataGridViewTextBoxColumn7.FillWeight = 89.0863!
        Me.DataGridViewTextBoxColumn7.HeaderText = "Old Item Code"
        Me.DataGridViewTextBoxColumn7.Name = "DataGridViewTextBoxColumn7"
        Me.DataGridViewTextBoxColumn7.ReadOnly = True
        Me.DataGridViewTextBoxColumn7.Width = 89
        '
        'DataGridViewTextBoxColumn8
        '
        Me.DataGridViewTextBoxColumn8.FillWeight = 89.0863!
        Me.DataGridViewTextBoxColumn8.HeaderText = "Unit"
        Me.DataGridViewTextBoxColumn8.Name = "DataGridViewTextBoxColumn8"
        Me.DataGridViewTextBoxColumn8.ReadOnly = True
        Me.DataGridViewTextBoxColumn8.Width = 89
        '
        'DataGridViewTextBoxColumn9
        '
        Me.DataGridViewTextBoxColumn9.FillWeight = 70.0!
        Me.DataGridViewTextBoxColumn9.HeaderText = "Unit"
        Me.DataGridViewTextBoxColumn9.Name = "DataGridViewTextBoxColumn9"
        Me.DataGridViewTextBoxColumn9.ReadOnly = True
        Me.DataGridViewTextBoxColumn9.Width = 74
        '
        'FRM_MTNExport
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.SlateGray
        Me.ClientSize = New System.Drawing.Size(369, 281)
        Me.Controls.Add(Me.PGB_Progress)
        Me.Controls.Add(Me.CMBX_ExportType)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.DTP_ToDate)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.DTP_FromDate)
        Me.Controls.Add(Me.BTN_Export)
        Me.Controls.Add(Me.BTN_Close)
        Me.Controls.Add(Me.LBL_Objects)
        Me.Controls.Add(Me.BTN_Brows)
        Me.Controls.Add(Me.TBX_ExportFile)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.ShapeContainer1)
        Me.Name = "FRM_MTNExport"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Export Data"
        CType(Me.ERP_Error, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ERP_Error As System.Windows.Forms.ErrorProvider
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents ShapeContainer1 As Microsoft.VisualBasic.PowerPacks.ShapeContainer
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn7 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn8 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn9 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents LineShape4 As Microsoft.VisualBasic.PowerPacks.LineShape
    Friend WithEvents LineShape6 As Microsoft.VisualBasic.PowerPacks.LineShape
    Friend WithEvents TBX_ExportFile As System.Windows.Forms.TextBox
    Friend WithEvents LBL_Objects As System.Windows.Forms.Label
    Friend WithEvents BTN_Brows As System.Windows.Forms.Button
    Friend WithEvents BTN_Export As System.Windows.Forms.Button
    Friend WithEvents BTN_Close As System.Windows.Forms.Button
    Friend WithEvents SFD_ExportFile As System.Windows.Forms.SaveFileDialog
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents DTP_ToDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents DTP_FromDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents CMBX_ExportType As System.Windows.Forms.ComboBox
    Friend WithEvents PGB_Progress As System.Windows.Forms.ProgressBar
End Class
