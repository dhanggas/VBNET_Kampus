<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormCariSupplier
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
        Me.ListView1 = New System.Windows.Forms.ListView
        Me.BtnKeluar = New System.Windows.Forms.Button
        Me.BtnPilih = New System.Windows.Forms.Button
        Me.TxtKeyword = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'ListView1
        '
        Me.ListView1.FullRowSelect = True
        Me.ListView1.GridLines = True
        Me.ListView1.Location = New System.Drawing.Point(12, 12)
        Me.ListView1.Name = "ListView1"
        Me.ListView1.Size = New System.Drawing.Size(391, 347)
        Me.ListView1.TabIndex = 10
        Me.ListView1.UseCompatibleStateImageBehavior = False
        Me.ListView1.View = System.Windows.Forms.View.Details
        '
        'BtnKeluar
        '
        Me.BtnKeluar.Location = New System.Drawing.Point(328, 365)
        Me.BtnKeluar.Name = "BtnKeluar"
        Me.BtnKeluar.Size = New System.Drawing.Size(75, 23)
        Me.BtnKeluar.TabIndex = 9
        Me.BtnKeluar.Text = "Keluar"
        Me.BtnKeluar.UseVisualStyleBackColor = True
        '
        'BtnPilih
        '
        Me.BtnPilih.Location = New System.Drawing.Point(247, 367)
        Me.BtnPilih.Name = "BtnPilih"
        Me.BtnPilih.Size = New System.Drawing.Size(75, 23)
        Me.BtnPilih.TabIndex = 8
        Me.BtnPilih.Text = "Pilih"
        Me.BtnPilih.UseVisualStyleBackColor = True
        '
        'TxtKeyword
        '
        Me.TxtKeyword.Location = New System.Drawing.Point(90, 367)
        Me.TxtKeyword.Name = "TxtKeyword"
        Me.TxtKeyword.Size = New System.Drawing.Size(146, 20)
        Me.TxtKeyword.TabIndex = 7
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 370)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(54, 13)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Keywoard"
        '
        'FormCariSupplier
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(415, 398)
        Me.Controls.Add(Me.ListView1)
        Me.Controls.Add(Me.BtnKeluar)
        Me.Controls.Add(Me.BtnPilih)
        Me.Controls.Add(Me.TxtKeyword)
        Me.Controls.Add(Me.Label1)
        Me.Name = "FormCariSupplier"
        Me.Text = "FormCariSupplier"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ListView1 As System.Windows.Forms.ListView
    Friend WithEvents BtnKeluar As System.Windows.Forms.Button
    Friend WithEvents BtnPilih As System.Windows.Forms.Button
    Friend WithEvents TxtKeyword As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
End Class
