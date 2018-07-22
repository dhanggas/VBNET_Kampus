<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class f_CariSiswa
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(f_CariSiswa))
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.txtCari = New System.Windows.Forms.TextBox()
        Me.RB_NIS = New System.Windows.Forms.RadioButton()
        Me.RB_Nama = New System.Windows.Forms.RadioButton()
        Me.RB_Kelas = New System.Windows.Forms.RadioButton()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ShapeContainer1 = New Microsoft.VisualBasic.PowerPacks.ShapeContainer()
        Me.LineShape1 = New Microsoft.VisualBasic.PowerPacks.LineShape()
        Me.btnKeluar = New System.Windows.Forms.Button()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DataGridView1
        '
        Me.DataGridView1.BackgroundColor = System.Drawing.Color.White
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(12, 146)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Size = New System.Drawing.Size(611, 248)
        Me.DataGridView1.TabIndex = 0
        '
        'txtCari
        '
        Me.txtCari.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCari.Location = New System.Drawing.Point(112, 79)
        Me.txtCari.Multiline = True
        Me.txtCari.Name = "txtCari"
        Me.txtCari.Size = New System.Drawing.Size(349, 29)
        Me.txtCari.TabIndex = 1
        '
        'RB_NIS
        '
        Me.RB_NIS.AutoSize = True
        Me.RB_NIS.Cursor = System.Windows.Forms.Cursors.Hand
        Me.RB_NIS.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RB_NIS.ForeColor = System.Drawing.Color.Black
        Me.RB_NIS.Location = New System.Drawing.Point(127, 114)
        Me.RB_NIS.Name = "RB_NIS"
        Me.RB_NIS.Size = New System.Drawing.Size(75, 20)
        Me.RB_NIS.TabIndex = 2
        Me.RB_NIS.TabStop = True
        Me.RB_NIS.Text = "Cari NIS"
        Me.RB_NIS.UseVisualStyleBackColor = True
        '
        'RB_Nama
        '
        Me.RB_Nama.AutoSize = True
        Me.RB_Nama.Cursor = System.Windows.Forms.Cursors.Hand
        Me.RB_Nama.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RB_Nama.ForeColor = System.Drawing.Color.Black
        Me.RB_Nama.Location = New System.Drawing.Point(236, 114)
        Me.RB_Nama.Name = "RB_Nama"
        Me.RB_Nama.Size = New System.Drawing.Size(90, 20)
        Me.RB_Nama.TabIndex = 3
        Me.RB_Nama.TabStop = True
        Me.RB_Nama.Text = "Cari Nama"
        Me.RB_Nama.UseVisualStyleBackColor = True
        '
        'RB_Kelas
        '
        Me.RB_Kelas.AutoSize = True
        Me.RB_Kelas.Cursor = System.Windows.Forms.Cursors.Hand
        Me.RB_Kelas.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RB_Kelas.ForeColor = System.Drawing.Color.Black
        Me.RB_Kelas.Location = New System.Drawing.Point(348, 114)
        Me.RB_Kelas.Name = "RB_Kelas"
        Me.RB_Kelas.Size = New System.Drawing.Size(87, 20)
        Me.RB_Kelas.TabIndex = 4
        Me.RB_Kelas.TabStop = True
        Me.RB_Kelas.Text = "Cari Kelas"
        Me.RB_Kelas.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Times New Roman", 26.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Transparent
        Me.Label1.Location = New System.Drawing.Point(5, 1)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(178, 40)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Cari Siswa"
        '
        'ShapeContainer1
        '
        Me.ShapeContainer1.Location = New System.Drawing.Point(0, 0)
        Me.ShapeContainer1.Margin = New System.Windows.Forms.Padding(0)
        Me.ShapeContainer1.Name = "ShapeContainer1"
        Me.ShapeContainer1.Shapes.AddRange(New Microsoft.VisualBasic.PowerPacks.Shape() {Me.LineShape1})
        Me.ShapeContainer1.Size = New System.Drawing.Size(635, 450)
        Me.ShapeContainer1.TabIndex = 6
        Me.ShapeContainer1.TabStop = False
        '
        'LineShape1
        '
        Me.LineShape1.BorderColor = System.Drawing.Color.White
        Me.LineShape1.Name = "LineShape1"
        Me.LineShape1.X1 = 4
        Me.LineShape1.X2 = 419
        Me.LineShape1.Y1 = 43
        Me.LineShape1.Y2 = 43
        '
        'btnKeluar
        '
        Me.btnKeluar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnKeluar.Location = New System.Drawing.Point(530, 403)
        Me.btnKeluar.Name = "btnKeluar"
        Me.btnKeluar.Size = New System.Drawing.Size(93, 40)
        Me.btnKeluar.TabIndex = 7
        Me.btnKeluar.Text = "Keluar"
        Me.btnKeluar.UseVisualStyleBackColor = True
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox1.BackgroundImage = CType(resources.GetObject("PictureBox1.BackgroundImage"), System.Drawing.Image)
        Me.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.PictureBox1.Location = New System.Drawing.Point(467, 79)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(31, 29)
        Me.PictureBox1.TabIndex = 8
        Me.PictureBox1.TabStop = False
        '
        'f_CariSiswa
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(635, 450)
        Me.ControlBox = False
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.btnKeluar)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.RB_Kelas)
        Me.Controls.Add(Me.RB_Nama)
        Me.Controls.Add(Me.RB_NIS)
        Me.Controls.Add(Me.txtCari)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.ShapeContainer1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "f_CariSiswa"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "CariSiswa"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents txtCari As System.Windows.Forms.TextBox
    Friend WithEvents RB_NIS As System.Windows.Forms.RadioButton
    Friend WithEvents RB_Nama As System.Windows.Forms.RadioButton
    Friend WithEvents RB_Kelas As System.Windows.Forms.RadioButton
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ShapeContainer1 As Microsoft.VisualBasic.PowerPacks.ShapeContainer
    Friend WithEvents LineShape1 As Microsoft.VisualBasic.PowerPacks.LineShape
    Friend WithEvents btnKeluar As System.Windows.Forms.Button
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
End Class
