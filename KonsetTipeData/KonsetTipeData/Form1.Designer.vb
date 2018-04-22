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
        Me.txtNilai1 = New System.Windows.Forms.TextBox
        Me.txtNilai2 = New System.Windows.Forms.TextBox
        Me.txtNilai3 = New System.Windows.Forms.TextBox
        Me.btnByte = New System.Windows.Forms.Button
        Me.btnSingle = New System.Windows.Forms.Button
        Me.btnDouble = New System.Windows.Forms.Button
        Me.Label4 = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(36, 60)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(36, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Nilai 1"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(36, 106)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(36, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Nilai 2"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(36, 153)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(36, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Nilai 3"
        '
        'txtNilai1
        '
        Me.txtNilai1.Location = New System.Drawing.Point(131, 60)
        Me.txtNilai1.Name = "txtNilai1"
        Me.txtNilai1.Size = New System.Drawing.Size(144, 20)
        Me.txtNilai1.TabIndex = 3
        '
        'txtNilai2
        '
        Me.txtNilai2.Location = New System.Drawing.Point(131, 106)
        Me.txtNilai2.Name = "txtNilai2"
        Me.txtNilai2.Size = New System.Drawing.Size(144, 20)
        Me.txtNilai2.TabIndex = 4
        '
        'txtNilai3
        '
        Me.txtNilai3.Location = New System.Drawing.Point(131, 153)
        Me.txtNilai3.Name = "txtNilai3"
        Me.txtNilai3.Size = New System.Drawing.Size(144, 20)
        Me.txtNilai3.TabIndex = 5
        '
        'btnByte
        '
        Me.btnByte.Location = New System.Drawing.Point(322, 60)
        Me.btnByte.Name = "btnByte"
        Me.btnByte.Size = New System.Drawing.Size(75, 23)
        Me.btnByte.TabIndex = 6
        Me.btnByte.Text = "Byte"
        Me.btnByte.UseVisualStyleBackColor = True
        '
        'btnSingle
        '
        Me.btnSingle.Location = New System.Drawing.Point(322, 106)
        Me.btnSingle.Name = "btnSingle"
        Me.btnSingle.Size = New System.Drawing.Size(75, 23)
        Me.btnSingle.TabIndex = 7
        Me.btnSingle.Text = "Single"
        Me.btnSingle.UseVisualStyleBackColor = True
        '
        'btnDouble
        '
        Me.btnDouble.Location = New System.Drawing.Point(322, 153)
        Me.btnDouble.Name = "btnDouble"
        Me.btnDouble.Size = New System.Drawing.Size(75, 23)
        Me.btnDouble.TabIndex = 8
        Me.btnDouble.Text = "Double"
        Me.btnDouble.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(68, 9)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(270, 24)
        Me.Label4.TabIndex = 9
        Me.Label4.Text = "Mamahami konsep tipe data"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(435, 203)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.btnDouble)
        Me.Controls.Add(Me.btnSingle)
        Me.Controls.Add(Me.btnByte)
        Me.Controls.Add(Me.txtNilai3)
        Me.Controls.Add(Me.txtNilai2)
        Me.Controls.Add(Me.txtNilai1)
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
    Friend WithEvents txtNilai1 As System.Windows.Forms.TextBox
    Friend WithEvents txtNilai2 As System.Windows.Forms.TextBox
    Friend WithEvents txtNilai3 As System.Windows.Forms.TextBox
    Friend WithEvents btnByte As System.Windows.Forms.Button
    Friend WithEvents btnSingle As System.Windows.Forms.Button
    Friend WithEvents btnDouble As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label

End Class
