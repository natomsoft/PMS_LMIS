<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FRM_MTNEmployees
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
        Me.LBL_EmpType = New System.Windows.Forms.Label()
        Me.CMBX_EmpType = New System.Windows.Forms.ComboBox()
        Me.BTN_Save = New System.Windows.Forms.Button()
        Me.BTN_Close = New System.Windows.Forms.Button()
        Me.ERP_Error = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.LBL_UserName = New System.Windows.Forms.Label()
        Me.ShapeContainer1 = New Microsoft.VisualBasic.PowerPacks.ShapeContainer()
        Me.LineShape6 = New Microsoft.VisualBasic.PowerPacks.LineShape()
        Me.LineShape4 = New Microsoft.VisualBasic.PowerPacks.LineShape()
        Me.LBL_Title = New System.Windows.Forms.Label()
        Me.TBX_ConPassword = New System.Windows.Forms.TextBox()
        Me.LBL_ConPassword = New System.Windows.Forms.Label()
        Me.TBX_Password = New System.Windows.Forms.TextBox()
        Me.LBL_Password = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.CMBX_Name = New System.Windows.Forms.ComboBox()
        Me.TBX_ChangetoUserName = New System.Windows.Forms.TextBox()
        Me.LBL_Changeto = New System.Windows.Forms.Label()
        Me.CHBX_IsSystemUser = New System.Windows.Forms.CheckBox()
        Me.CHBX_IsActive = New System.Windows.Forms.CheckBox()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn8 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn9 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CHBX_Addnew = New System.Windows.Forms.CheckBox()
        Me.TBX_UserName = New System.Windows.Forms.TextBox()
        CType(Me.ERP_Error, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LBL_EmpType
        '
        Me.LBL_EmpType.AutoSize = True
        Me.LBL_EmpType.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBL_EmpType.ForeColor = System.Drawing.Color.White
        Me.LBL_EmpType.Location = New System.Drawing.Point(15, 252)
        Me.LBL_EmpType.Name = "LBL_EmpType"
        Me.LBL_EmpType.Size = New System.Drawing.Size(108, 16)
        Me.LBL_EmpType.TabIndex = 26
        Me.LBL_EmpType.Text = "Employee Type:"
        Me.LBL_EmpType.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'CMBX_EmpType
        '
        Me.CMBX_EmpType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CMBX_EmpType.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBX_EmpType.FormattingEnabled = True
        Me.CMBX_EmpType.Items.AddRange(New Object() {"Female", "Male"})
        Me.CMBX_EmpType.Location = New System.Drawing.Point(18, 271)
        Me.CMBX_EmpType.Name = "CMBX_EmpType"
        Me.CMBX_EmpType.Size = New System.Drawing.Size(156, 24)
        Me.CMBX_EmpType.TabIndex = 5
        '
        'BTN_Save
        '
        Me.BTN_Save.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTN_Save.Location = New System.Drawing.Point(189, 333)
        Me.BTN_Save.Name = "BTN_Save"
        Me.BTN_Save.Size = New System.Drawing.Size(75, 28)
        Me.BTN_Save.TabIndex = 8
        Me.BTN_Save.Text = "Save"
        Me.BTN_Save.UseVisualStyleBackColor = True
        '
        'BTN_Close
        '
        Me.BTN_Close.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTN_Close.Location = New System.Drawing.Point(270, 333)
        Me.BTN_Close.Name = "BTN_Close"
        Me.BTN_Close.Size = New System.Drawing.Size(75, 28)
        Me.BTN_Close.TabIndex = 9
        Me.BTN_Close.Text = "Close"
        Me.BTN_Close.UseVisualStyleBackColor = True
        '
        'ERP_Error
        '
        Me.ERP_Error.ContainerControl = Me
        '
        'LBL_UserName
        '
        Me.LBL_UserName.AutoSize = True
        Me.LBL_UserName.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBL_UserName.ForeColor = System.Drawing.Color.White
        Me.LBL_UserName.Location = New System.Drawing.Point(15, 161)
        Me.LBL_UserName.Name = "LBL_UserName"
        Me.LBL_UserName.Size = New System.Drawing.Size(74, 16)
        Me.LBL_UserName.TabIndex = 57
        Me.LBL_UserName.Text = "Username:"
        Me.LBL_UserName.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'ShapeContainer1
        '
        Me.ShapeContainer1.Location = New System.Drawing.Point(0, 0)
        Me.ShapeContainer1.Margin = New System.Windows.Forms.Padding(0)
        Me.ShapeContainer1.Name = "ShapeContainer1"
        Me.ShapeContainer1.Shapes.AddRange(New Microsoft.VisualBasic.PowerPacks.Shape() {Me.LineShape6, Me.LineShape4})
        Me.ShapeContainer1.Size = New System.Drawing.Size(369, 373)
        Me.ShapeContainer1.TabIndex = 61
        Me.ShapeContainer1.TabStop = False
        '
        'LineShape6
        '
        Me.LineShape6.BorderColor = System.Drawing.Color.LightGray
        Me.LineShape6.Name = "LineShape6"
        Me.LineShape6.X1 = 11
        Me.LineShape6.X2 = 360
        Me.LineShape6.Y1 = 315
        Me.LineShape6.Y2 = 315
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
        'LBL_Title
        '
        Me.LBL_Title.AutoSize = True
        Me.LBL_Title.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBL_Title.ForeColor = System.Drawing.Color.White
        Me.LBL_Title.Location = New System.Drawing.Point(12, 9)
        Me.LBL_Title.Name = "LBL_Title"
        Me.LBL_Title.Size = New System.Drawing.Size(210, 31)
        Me.LBL_Title.TabIndex = 68
        Me.LBL_Title.Text = "Health workers"
        '
        'TBX_ConPassword
        '
        Me.TBX_ConPassword.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TBX_ConPassword.Location = New System.Drawing.Point(189, 224)
        Me.TBX_ConPassword.Name = "TBX_ConPassword"
        Me.TBX_ConPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.TBX_ConPassword.Size = New System.Drawing.Size(156, 22)
        Me.TBX_ConPassword.TabIndex = 7
        '
        'LBL_ConPassword
        '
        Me.LBL_ConPassword.AutoSize = True
        Me.LBL_ConPassword.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBL_ConPassword.ForeColor = System.Drawing.Color.White
        Me.LBL_ConPassword.Location = New System.Drawing.Point(186, 205)
        Me.LBL_ConPassword.Name = "LBL_ConPassword"
        Me.LBL_ConPassword.Size = New System.Drawing.Size(119, 16)
        Me.LBL_ConPassword.TabIndex = 76
        Me.LBL_ConPassword.Text = "Confirm Password:"
        Me.LBL_ConPassword.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TBX_Password
        '
        Me.TBX_Password.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TBX_Password.Location = New System.Drawing.Point(18, 224)
        Me.TBX_Password.Name = "TBX_Password"
        Me.TBX_Password.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.TBX_Password.Size = New System.Drawing.Size(156, 22)
        Me.TBX_Password.TabIndex = 6
        '
        'LBL_Password
        '
        Me.LBL_Password.AutoSize = True
        Me.LBL_Password.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBL_Password.ForeColor = System.Drawing.Color.White
        Me.LBL_Password.Location = New System.Drawing.Point(15, 205)
        Me.LBL_Password.Name = "LBL_Password"
        Me.LBL_Password.Size = New System.Drawing.Size(71, 16)
        Me.LBL_Password.TabIndex = 74
        Me.LBL_Password.Text = "Password:"
        Me.LBL_Password.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(15, 83)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(48, 16)
        Me.Label2.TabIndex = 80
        Me.Label2.Text = "Name:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'CMBX_Name
        '
        Me.CMBX_Name.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.CMBX_Name.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CMBX_Name.FormattingEnabled = True
        Me.CMBX_Name.Location = New System.Drawing.Point(18, 102)
        Me.CMBX_Name.Name = "CMBX_Name"
        Me.CMBX_Name.Size = New System.Drawing.Size(327, 24)
        Me.CMBX_Name.TabIndex = 3
        '
        'TBX_ChangetoUserName
        '
        Me.TBX_ChangetoUserName.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TBX_ChangetoUserName.Location = New System.Drawing.Point(189, 180)
        Me.TBX_ChangetoUserName.Name = "TBX_ChangetoUserName"
        Me.TBX_ChangetoUserName.Size = New System.Drawing.Size(156, 22)
        Me.TBX_ChangetoUserName.TabIndex = 2
        '
        'LBL_Changeto
        '
        Me.LBL_Changeto.AutoSize = True
        Me.LBL_Changeto.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LBL_Changeto.ForeColor = System.Drawing.Color.White
        Me.LBL_Changeto.Location = New System.Drawing.Point(186, 161)
        Me.LBL_Changeto.Name = "LBL_Changeto"
        Me.LBL_Changeto.Size = New System.Drawing.Size(142, 16)
        Me.LBL_Changeto.TabIndex = 83
        Me.LBL_Changeto.Text = "Update Username To:"
        Me.LBL_Changeto.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'CHBX_IsSystemUser
        '
        Me.CHBX_IsSystemUser.AutoSize = True
        Me.CHBX_IsSystemUser.Checked = True
        Me.CHBX_IsSystemUser.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CHBX_IsSystemUser.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CHBX_IsSystemUser.ForeColor = System.Drawing.Color.White
        Me.CHBX_IsSystemUser.Location = New System.Drawing.Point(18, 132)
        Me.CHBX_IsSystemUser.Name = "CHBX_IsSystemUser"
        Me.CHBX_IsSystemUser.Size = New System.Drawing.Size(117, 20)
        Me.CHBX_IsSystemUser.TabIndex = 4
        Me.CHBX_IsSystemUser.Text = "Is System User"
        Me.CHBX_IsSystemUser.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.CHBX_IsSystemUser.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.CHBX_IsSystemUser.UseVisualStyleBackColor = True
        '
        'CHBX_IsActive
        '
        Me.CHBX_IsActive.AutoSize = True
        Me.CHBX_IsActive.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CHBX_IsActive.ForeColor = System.Drawing.Color.White
        Me.CHBX_IsActive.Location = New System.Drawing.Point(189, 132)
        Me.CHBX_IsActive.Name = "CHBX_IsActive"
        Me.CHBX_IsActive.Size = New System.Drawing.Size(77, 20)
        Me.CHBX_IsActive.TabIndex = 84
        Me.CHBX_IsActive.Text = "Is Active"
        Me.CHBX_IsActive.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.CHBX_IsActive.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.CHBX_IsActive.UseVisualStyleBackColor = True
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
        'CHBX_Addnew
        '
        Me.CHBX_Addnew.AutoSize = True
        Me.CHBX_Addnew.Checked = True
        Me.CHBX_Addnew.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CHBX_Addnew.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CHBX_Addnew.ForeColor = System.Drawing.Color.White
        Me.CHBX_Addnew.Location = New System.Drawing.Point(18, 60)
        Me.CHBX_Addnew.Name = "CHBX_Addnew"
        Me.CHBX_Addnew.Size = New System.Drawing.Size(79, 20)
        Me.CHBX_Addnew.TabIndex = 85
        Me.CHBX_Addnew.Text = "Add new"
        Me.CHBX_Addnew.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.CHBX_Addnew.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.CHBX_Addnew.UseVisualStyleBackColor = True
        '
        'TBX_UserName
        '
        Me.TBX_UserName.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TBX_UserName.Location = New System.Drawing.Point(18, 180)
        Me.TBX_UserName.Name = "TBX_UserName"
        Me.TBX_UserName.Size = New System.Drawing.Size(156, 22)
        Me.TBX_UserName.TabIndex = 86
        '
        'FRM_MTNEmployees
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.SlateGray
        Me.ClientSize = New System.Drawing.Size(369, 373)
        Me.Controls.Add(Me.TBX_UserName)
        Me.Controls.Add(Me.CHBX_Addnew)
        Me.Controls.Add(Me.CHBX_IsActive)
        Me.Controls.Add(Me.CHBX_IsSystemUser)
        Me.Controls.Add(Me.TBX_ChangetoUserName)
        Me.Controls.Add(Me.LBL_Changeto)
        Me.Controls.Add(Me.CMBX_Name)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.TBX_ConPassword)
        Me.Controls.Add(Me.LBL_ConPassword)
        Me.Controls.Add(Me.TBX_Password)
        Me.Controls.Add(Me.LBL_Password)
        Me.Controls.Add(Me.LBL_Title)
        Me.Controls.Add(Me.LBL_UserName)
        Me.Controls.Add(Me.BTN_Save)
        Me.Controls.Add(Me.BTN_Close)
        Me.Controls.Add(Me.LBL_EmpType)
        Me.Controls.Add(Me.CMBX_EmpType)
        Me.Controls.Add(Me.ShapeContainer1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "FRM_MTNEmployees"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Health workers"
        CType(Me.ERP_Error, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents LBL_EmpType As System.Windows.Forms.Label
    Friend WithEvents CMBX_EmpType As System.Windows.Forms.ComboBox
    Friend WithEvents BTN_Save As System.Windows.Forms.Button
    Friend WithEvents BTN_Close As System.Windows.Forms.Button
    Friend WithEvents ERP_Error As System.Windows.Forms.ErrorProvider
    Friend WithEvents LBL_UserName As System.Windows.Forms.Label
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
    Friend WithEvents LBL_Title As System.Windows.Forms.Label
    Friend WithEvents LineShape4 As Microsoft.VisualBasic.PowerPacks.LineShape
    Friend WithEvents TBX_ConPassword As System.Windows.Forms.TextBox
    Friend WithEvents LBL_ConPassword As System.Windows.Forms.Label
    Friend WithEvents TBX_Password As System.Windows.Forms.TextBox
    Friend WithEvents LBL_Password As System.Windows.Forms.Label
    Friend WithEvents LineShape6 As Microsoft.VisualBasic.PowerPacks.LineShape
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents CMBX_Name As System.Windows.Forms.ComboBox
    Friend WithEvents TBX_ChangetoUserName As System.Windows.Forms.TextBox
    Friend WithEvents LBL_Changeto As System.Windows.Forms.Label
    Friend WithEvents CHBX_IsSystemUser As System.Windows.Forms.CheckBox
    Friend WithEvents CHBX_IsActive As System.Windows.Forms.CheckBox
    Friend WithEvents CHBX_Addnew As System.Windows.Forms.CheckBox
    Friend WithEvents TBX_UserName As System.Windows.Forms.TextBox
End Class
