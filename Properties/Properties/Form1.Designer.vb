<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
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
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtUserID = New System.Windows.Forms.TextBox
        Me.txtPassword = New System.Windows.Forms.TextBox
        Me.txtAddress = New System.Windows.Forms.TextBox
        Me.btnUnlock = New System.Windows.Forms.Button
        Me.btnDisable = New System.Windows.Forms.Button
        Me.btnBack = New System.Windows.Forms.Button
        Me.btnShow = New System.Windows.Forms.Button
        Me.btnClose = New System.Windows.Forms.Button
        Me.btnClear = New System.Windows.Forms.Button
        Me.btnHide = New System.Windows.Forms.Button
        Me.btnFore = New System.Windows.Forms.Button
        Me.btnEnable = New System.Windows.Forms.Button
        Me.btnLock = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(26, 38)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(43, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "User ID"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(26, 75)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(53, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Password"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(26, 119)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(45, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Address"
        '
        'txtUserID
        '
        Me.txtUserID.Location = New System.Drawing.Point(104, 38)
        Me.txtUserID.Name = "txtUserID"
        Me.txtUserID.Size = New System.Drawing.Size(137, 20)
        Me.txtUserID.TabIndex = 3
        '
        'txtPassword
        '
        Me.txtPassword.Location = New System.Drawing.Point(104, 75)
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtPassword.Size = New System.Drawing.Size(137, 20)
        Me.txtPassword.TabIndex = 4
        '
        'txtAddress
        '
        Me.txtAddress.Location = New System.Drawing.Point(104, 112)
        Me.txtAddress.Multiline = True
        Me.txtAddress.Name = "txtAddress"
        Me.txtAddress.Size = New System.Drawing.Size(137, 41)
        Me.txtAddress.TabIndex = 5
        '
        'btnUnlock
        '
        Me.btnUnlock.Location = New System.Drawing.Point(166, 176)
        Me.btnUnlock.Name = "btnUnlock"
        Me.btnUnlock.Size = New System.Drawing.Size(106, 23)
        Me.btnUnlock.TabIndex = 6
        Me.btnUnlock.Text = "UNLOCK TEXT"
        Me.btnUnlock.UseVisualStyleBackColor = True
        '
        'btnDisable
        '
        Me.btnDisable.Location = New System.Drawing.Point(166, 205)
        Me.btnDisable.Name = "btnDisable"
        Me.btnDisable.Size = New System.Drawing.Size(106, 23)
        Me.btnDisable.TabIndex = 7
        Me.btnDisable.Text = "DISABLE TEXT"
        Me.btnDisable.UseVisualStyleBackColor = True
        '
        'btnBack
        '
        Me.btnBack.Location = New System.Drawing.Point(166, 234)
        Me.btnBack.Name = "btnBack"
        Me.btnBack.Size = New System.Drawing.Size(106, 23)
        Me.btnBack.TabIndex = 8
        Me.btnBack.Text = "BACK COLOR"
        Me.btnBack.UseVisualStyleBackColor = True
        '
        'btnShow
        '
        Me.btnShow.Location = New System.Drawing.Point(166, 263)
        Me.btnShow.Name = "btnShow"
        Me.btnShow.Size = New System.Drawing.Size(106, 23)
        Me.btnShow.TabIndex = 9
        Me.btnShow.Text = "SHOW TEXT"
        Me.btnShow.UseVisualStyleBackColor = True
        '
        'btnClose
        '
        Me.btnClose.Location = New System.Drawing.Point(166, 292)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(106, 23)
        Me.btnClose.TabIndex = 10
        Me.btnClose.Text = "CLOSE"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'btnClear
        '
        Me.btnClear.Location = New System.Drawing.Point(66, 292)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(94, 23)
        Me.btnClear.TabIndex = 15
        Me.btnClear.Text = "CLEAR"
        Me.btnClear.UseVisualStyleBackColor = True
        '
        'btnHide
        '
        Me.btnHide.Location = New System.Drawing.Point(66, 263)
        Me.btnHide.Name = "btnHide"
        Me.btnHide.Size = New System.Drawing.Size(94, 23)
        Me.btnHide.TabIndex = 14
        Me.btnHide.Text = "HIDE TEXT"
        Me.btnHide.UseVisualStyleBackColor = True
        '
        'btnFore
        '
        Me.btnFore.Location = New System.Drawing.Point(66, 234)
        Me.btnFore.Name = "btnFore"
        Me.btnFore.Size = New System.Drawing.Size(94, 23)
        Me.btnFore.TabIndex = 13
        Me.btnFore.Text = "FORE COLOR"
        Me.btnFore.UseVisualStyleBackColor = True
        '
        'btnEnable
        '
        Me.btnEnable.Location = New System.Drawing.Point(66, 205)
        Me.btnEnable.Name = "btnEnable"
        Me.btnEnable.Size = New System.Drawing.Size(94, 23)
        Me.btnEnable.TabIndex = 12
        Me.btnEnable.Text = "ENABLE TEXT"
        Me.btnEnable.UseVisualStyleBackColor = True
        '
        'btnLock
        '
        Me.btnLock.Location = New System.Drawing.Point(66, 176)
        Me.btnLock.Name = "btnLock"
        Me.btnLock.Size = New System.Drawing.Size(94, 23)
        Me.btnLock.TabIndex = 11
        Me.btnLock.Text = "LOCK TEXT"
        Me.btnLock.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(284, 327)
        Me.Controls.Add(Me.btnClear)
        Me.Controls.Add(Me.btnHide)
        Me.Controls.Add(Me.btnFore)
        Me.Controls.Add(Me.btnEnable)
        Me.Controls.Add(Me.btnLock)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.btnShow)
        Me.Controls.Add(Me.btnBack)
        Me.Controls.Add(Me.btnDisable)
        Me.Controls.Add(Me.btnUnlock)
        Me.Controls.Add(Me.txtAddress)
        Me.Controls.Add(Me.txtPassword)
        Me.Controls.Add(Me.txtUserID)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtUserID As System.Windows.Forms.TextBox
    Friend WithEvents txtPassword As System.Windows.Forms.TextBox
    Friend WithEvents txtAddress As System.Windows.Forms.TextBox
    Friend WithEvents btnUnlock As System.Windows.Forms.Button
    Friend WithEvents btnDisable As System.Windows.Forms.Button
    Friend WithEvents btnBack As System.Windows.Forms.Button
    Friend WithEvents btnShow As System.Windows.Forms.Button
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents btnClear As System.Windows.Forms.Button
    Friend WithEvents btnHide As System.Windows.Forms.Button
    Friend WithEvents btnFore As System.Windows.Forms.Button
    Friend WithEvents btnEnable As System.Windows.Forms.Button
    Friend WithEvents btnLock As System.Windows.Forms.Button

End Class
