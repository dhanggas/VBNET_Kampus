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
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.txtKodeBrg = New System.Windows.Forms.TextBox
        Me.TxtNamaBrg = New System.Windows.Forms.TextBox
        Me.txtHargaSat = New System.Windows.Forms.TextBox
        Me.txtQty = New System.Windows.Forms.TextBox
        Me.txtTotal = New System.Windows.Forms.TextBox
        Me.Button1 = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(45, 26)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(69, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Kode Barang"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(45, 55)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(72, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Nama Barang"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(45, 84)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(71, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "harga Satuan"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(45, 113)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(46, 13)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Quantity"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(45, 142)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(60, 13)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "Total bayar"
        '
        'txtKodeBrg
        '
        Me.txtKodeBrg.Location = New System.Drawing.Point(136, 26)
        Me.txtKodeBrg.Name = "txtKodeBrg"
        Me.txtKodeBrg.Size = New System.Drawing.Size(185, 20)
        Me.txtKodeBrg.TabIndex = 5
        '
        'TxtNamaBrg
        '
        Me.TxtNamaBrg.Location = New System.Drawing.Point(136, 55)
        Me.TxtNamaBrg.Name = "TxtNamaBrg"
        Me.TxtNamaBrg.ReadOnly = True
        Me.TxtNamaBrg.Size = New System.Drawing.Size(185, 20)
        Me.TxtNamaBrg.TabIndex = 6
        '
        'txtHargaSat
        '
        Me.txtHargaSat.Location = New System.Drawing.Point(136, 84)
        Me.txtHargaSat.Name = "txtHargaSat"
        Me.txtHargaSat.ReadOnly = True
        Me.txtHargaSat.Size = New System.Drawing.Size(185, 20)
        Me.txtHargaSat.TabIndex = 7
        '
        'txtQty
        '
        Me.txtQty.Location = New System.Drawing.Point(136, 113)
        Me.txtQty.Name = "txtQty"
        Me.txtQty.Size = New System.Drawing.Size(185, 20)
        Me.txtQty.TabIndex = 8
        '
        'txtTotal
        '
        Me.txtTotal.Location = New System.Drawing.Point(136, 142)
        Me.txtTotal.Name = "txtTotal"
        Me.txtTotal.ReadOnly = True
        Me.txtTotal.Size = New System.Drawing.Size(185, 20)
        Me.txtTotal.TabIndex = 9
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(136, 189)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 10
        Me.Button1.Text = "Close"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(449, 261)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.txtTotal)
        Me.Controls.Add(Me.txtQty)
        Me.Controls.Add(Me.txtHargaSat)
        Me.Controls.Add(Me.TxtNamaBrg)
        Me.Controls.Add(Me.txtKodeBrg)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
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
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtKodeBrg As System.Windows.Forms.TextBox
    Friend WithEvents TxtNamaBrg As System.Windows.Forms.TextBox
    Friend WithEvents txtHargaSat As System.Windows.Forms.TextBox
    Friend WithEvents txtQty As System.Windows.Forms.TextBox
    Friend WithEvents txtTotal As System.Windows.Forms.TextBox
    Friend WithEvents Button1 As System.Windows.Forms.Button

End Class
