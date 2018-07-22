<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class f_PenggunaControl
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
        Dim UsernameLabel1 As System.Windows.Forms.Label
        Dim PasswordLabel1 As System.Windows.Forms.Label
        Dim Label1 As System.Windows.Forms.Label
        Dim Label2 As System.Windows.Forms.Label
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.txtStatus = New System.Windows.Forms.TextBox()
        Me.txtKd = New System.Windows.Forms.TextBox()
        Me.txtUser = New System.Windows.Forms.TextBox()
        Me.txtPass = New System.Windows.Forms.TextBox()
        Me.btnKeluar = New System.Windows.Forms.Button()
        UsernameLabel1 = New System.Windows.Forms.Label()
        PasswordLabel1 = New System.Windows.Forms.Label()
        Label1 = New System.Windows.Forms.Label()
        Label2 = New System.Windows.Forms.Label()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'UsernameLabel1
        '
        UsernameLabel1.AutoSize = True
        UsernameLabel1.ForeColor = System.Drawing.Color.White
        UsernameLabel1.Location = New System.Drawing.Point(13, 57)
        UsernameLabel1.Name = "UsernameLabel1"
        UsernameLabel1.Size = New System.Drawing.Size(58, 13)
        UsernameLabel1.TabIndex = 0
        UsernameLabel1.Text = "Username:"
        '
        'PasswordLabel1
        '
        PasswordLabel1.AutoSize = True
        PasswordLabel1.ForeColor = System.Drawing.Color.White
        PasswordLabel1.Location = New System.Drawing.Point(13, 93)
        PasswordLabel1.Name = "PasswordLabel1"
        PasswordLabel1.Size = New System.Drawing.Size(56, 13)
        PasswordLabel1.TabIndex = 2
        PasswordLabel1.Text = "Password:"
        '
        'Label1
        '
        Label1.AutoSize = True
        Label1.ForeColor = System.Drawing.Color.White
        Label1.Location = New System.Drawing.Point(13, 22)
        Label1.Name = "Label1"
        Label1.Size = New System.Drawing.Size(87, 13)
        Label1.TabIndex = 4
        Label1.Text = "Kode Pengguna:"
        '
        'Label2
        '
        Label2.AutoSize = True
        Label2.ForeColor = System.Drawing.Color.White
        Label2.Location = New System.Drawing.Point(13, 130)
        Label2.Name = "Label2"
        Label2.Size = New System.Drawing.Size(37, 13)
        Label2.TabIndex = 6
        Label2.Text = "Status"
        '
        'Button2
        '
        Me.Button2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button2.Location = New System.Drawing.Point(103, 189)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 40)
        Me.Button2.TabIndex = 14
        Me.Button2.Text = "Batal"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button1.Location = New System.Drawing.Point(22, 189)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 40)
        Me.Button1.TabIndex = 13
        Me.Button1.Text = "Ubah"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Label2)
        Me.GroupBox2.Controls.Add(Me.txtStatus)
        Me.GroupBox2.Controls.Add(Label1)
        Me.GroupBox2.Controls.Add(Me.txtKd)
        Me.GroupBox2.Controls.Add(UsernameLabel1)
        Me.GroupBox2.Controls.Add(Me.txtUser)
        Me.GroupBox2.Controls.Add(PasswordLabel1)
        Me.GroupBox2.Controls.Add(Me.txtPass)
        Me.GroupBox2.Location = New System.Drawing.Point(10, 12)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(266, 160)
        Me.GroupBox2.TabIndex = 12
        Me.GroupBox2.TabStop = False
        '
        'txtStatus
        '
        Me.txtStatus.Location = New System.Drawing.Point(101, 127)
        Me.txtStatus.Name = "txtStatus"
        Me.txtStatus.Size = New System.Drawing.Size(159, 20)
        Me.txtStatus.TabIndex = 7
        '
        'txtKd
        '
        Me.txtKd.Location = New System.Drawing.Point(101, 19)
        Me.txtKd.Name = "txtKd"
        Me.txtKd.Size = New System.Drawing.Size(159, 20)
        Me.txtKd.TabIndex = 5
        '
        'txtUser
        '
        Me.txtUser.Location = New System.Drawing.Point(101, 54)
        Me.txtUser.Name = "txtUser"
        Me.txtUser.Size = New System.Drawing.Size(159, 20)
        Me.txtUser.TabIndex = 1
        '
        'txtPass
        '
        Me.txtPass.Location = New System.Drawing.Point(101, 90)
        Me.txtPass.Name = "txtPass"
        Me.txtPass.Size = New System.Drawing.Size(159, 20)
        Me.txtPass.TabIndex = 3
        '
        'btnKeluar
        '
        Me.btnKeluar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnKeluar.Location = New System.Drawing.Point(184, 189)
        Me.btnKeluar.Name = "btnKeluar"
        Me.btnKeluar.Size = New System.Drawing.Size(75, 40)
        Me.btnKeluar.TabIndex = 15
        Me.btnKeluar.Text = "Keluar"
        Me.btnKeluar.UseVisualStyleBackColor = True
        '
        'f_PenggunaControl
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(294, 250)
        Me.ControlBox = False
        Me.Controls.Add(Me.btnKeluar)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.GroupBox2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "f_PenggunaControl"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "f_PenggunaControl"
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents txtUser As System.Windows.Forms.TextBox
    Friend WithEvents txtPass As System.Windows.Forms.TextBox
    Friend WithEvents txtKd As System.Windows.Forms.TextBox
    Friend WithEvents txtStatus As System.Windows.Forms.TextBox
    Friend WithEvents btnKeluar As System.Windows.Forms.Button
End Class
