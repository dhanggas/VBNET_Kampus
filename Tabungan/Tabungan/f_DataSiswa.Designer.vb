<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class f_DataSiswa
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtNama_Siswa = New System.Windows.Forms.TextBox()
        Me.txtAlamat = New System.Windows.Forms.TextBox()
        Me.txtNama_Ortu = New System.Windows.Forms.TextBox()
        Me.txtNo_Tlp = New System.Windows.Forms.TextBox()
        Me.cmbJK = New System.Windows.Forms.ComboBox()
        Me.cmbKelas = New System.Windows.Forms.ComboBox()
        Me.cmbKet = New System.Windows.Forms.ComboBox()
        Me.btnBuka = New System.Windows.Forms.Button()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.btn_simpan = New System.Windows.Forms.Button()
        Me.btn_hapus = New System.Windows.Forms.Button()
        Me.btn_ubah = New System.Windows.Forms.Button()
        Me.btn_batal = New System.Windows.Forms.Button()
        Me.btn_keluar = New System.Windows.Forms.Button()
        Me.txtThn_Ajar = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btnReport = New System.Windows.Forms.Button()
        Me.txtSaldo = New System.Windows.Forms.TextBox()
        Me.txtNIS = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(13, 89)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(25, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "NIS"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(13, 114)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(66, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Nama Siswa"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(13, 145)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(71, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Jenis Kelamin"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(13, 175)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(39, 13)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Alamat"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(12, 203)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(71, 13)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "Tahun Ajaran"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.ForeColor = System.Drawing.Color.White
        Me.Label6.Location = New System.Drawing.Point(12, 232)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(33, 13)
        Me.Label6.TabIndex = 5
        Me.Label6.Text = "Kelas"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.ForeColor = System.Drawing.Color.White
        Me.Label7.Location = New System.Drawing.Point(250, 85)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(57, 13)
        Me.Label7.TabIndex = 6
        Me.Label7.Text = "No Telpon"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.ForeColor = System.Drawing.Color.White
        Me.Label8.Location = New System.Drawing.Point(12, 263)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(89, 13)
        Me.Label8.TabIndex = 7
        Me.Label8.Text = "Nama Orang Tua"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.ForeColor = System.Drawing.Color.White
        Me.Label9.Location = New System.Drawing.Point(250, 145)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(62, 13)
        Me.Label9.TabIndex = 8
        Me.Label9.Text = "Keterangan"
        '
        'txtNama_Siswa
        '
        Me.txtNama_Siswa.Location = New System.Drawing.Point(106, 111)
        Me.txtNama_Siswa.Name = "txtNama_Siswa"
        Me.txtNama_Siswa.Size = New System.Drawing.Size(382, 20)
        Me.txtNama_Siswa.TabIndex = 11
        '
        'txtAlamat
        '
        Me.txtAlamat.Location = New System.Drawing.Point(106, 172)
        Me.txtAlamat.Name = "txtAlamat"
        Me.txtAlamat.Size = New System.Drawing.Size(382, 20)
        Me.txtAlamat.TabIndex = 12
        '
        'txtNama_Ortu
        '
        Me.txtNama_Ortu.Location = New System.Drawing.Point(106, 260)
        Me.txtNama_Ortu.Name = "txtNama_Ortu"
        Me.txtNama_Ortu.Size = New System.Drawing.Size(133, 20)
        Me.txtNama_Ortu.TabIndex = 14
        '
        'txtNo_Tlp
        '
        Me.txtNo_Tlp.Location = New System.Drawing.Point(327, 82)
        Me.txtNo_Tlp.MaxLength = 12
        Me.txtNo_Tlp.Name = "txtNo_Tlp"
        Me.txtNo_Tlp.Size = New System.Drawing.Size(161, 20)
        Me.txtNo_Tlp.TabIndex = 15
        '
        'cmbJK
        '
        Me.cmbJK.FormattingEnabled = True
        Me.cmbJK.Items.AddRange(New Object() {"Laki-Laki", "Perempuan"})
        Me.cmbJK.Location = New System.Drawing.Point(106, 142)
        Me.cmbJK.Name = "cmbJK"
        Me.cmbJK.Size = New System.Drawing.Size(133, 21)
        Me.cmbJK.TabIndex = 16
        Me.cmbJK.Text = "Pilih Jenis Kelamin"
        '
        'cmbKelas
        '
        Me.cmbKelas.FormattingEnabled = True
        Me.cmbKelas.Items.AddRange(New Object() {"1", "2", "3", "4", "5", "6"})
        Me.cmbKelas.Location = New System.Drawing.Point(106, 229)
        Me.cmbKelas.Name = "cmbKelas"
        Me.cmbKelas.Size = New System.Drawing.Size(133, 21)
        Me.cmbKelas.TabIndex = 17
        Me.cmbKelas.Text = "Pilih Kelas"
        '
        'cmbKet
        '
        Me.cmbKet.FormattingEnabled = True
        Me.cmbKet.Items.AddRange(New Object() {"Aktif", "Tidak Aktif (Keluar)"})
        Me.cmbKet.Location = New System.Drawing.Point(327, 142)
        Me.cmbKet.Name = "cmbKet"
        Me.cmbKet.Size = New System.Drawing.Size(161, 21)
        Me.cmbKet.TabIndex = 18
        Me.cmbKet.Text = "Pilih Keterangan"
        '
        'btnBuka
        '
        Me.btnBuka.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnBuka.Font = New System.Drawing.Font("Tempus Sans ITC", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBuka.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnBuka.Location = New System.Drawing.Point(250, 203)
        Me.btnBuka.Name = "btnBuka"
        Me.btnBuka.Size = New System.Drawing.Size(238, 77)
        Me.btnBuka.TabIndex = 19
        Me.btnBuka.Text = "Buka Kolom"
        Me.btnBuka.UseVisualStyleBackColor = True
        '
        'DataGridView1
        '
        Me.DataGridView1.BackgroundColor = System.Drawing.Color.White
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(12, 329)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.Size = New System.Drawing.Size(717, 196)
        Me.DataGridView1.TabIndex = 21
        '
        'btn_simpan
        '
        Me.btn_simpan.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_simpan.Location = New System.Drawing.Point(99, 539)
        Me.btn_simpan.Name = "btn_simpan"
        Me.btn_simpan.Size = New System.Drawing.Size(89, 31)
        Me.btn_simpan.TabIndex = 22
        Me.btn_simpan.Text = "Simpan"
        Me.btn_simpan.UseVisualStyleBackColor = True
        '
        'btn_hapus
        '
        Me.btn_hapus.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_hapus.Location = New System.Drawing.Point(202, 539)
        Me.btn_hapus.Name = "btn_hapus"
        Me.btn_hapus.Size = New System.Drawing.Size(89, 31)
        Me.btn_hapus.TabIndex = 23
        Me.btn_hapus.Text = "Hapus"
        Me.btn_hapus.UseVisualStyleBackColor = True
        '
        'btn_ubah
        '
        Me.btn_ubah.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_ubah.Location = New System.Drawing.Point(306, 539)
        Me.btn_ubah.Name = "btn_ubah"
        Me.btn_ubah.Size = New System.Drawing.Size(89, 31)
        Me.btn_ubah.TabIndex = 24
        Me.btn_ubah.Text = "Ubah"
        Me.btn_ubah.UseVisualStyleBackColor = True
        '
        'btn_batal
        '
        Me.btn_batal.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_batal.Location = New System.Drawing.Point(410, 539)
        Me.btn_batal.Name = "btn_batal"
        Me.btn_batal.Size = New System.Drawing.Size(89, 31)
        Me.btn_batal.TabIndex = 25
        Me.btn_batal.Text = "Batal"
        Me.btn_batal.UseVisualStyleBackColor = True
        '
        'btn_keluar
        '
        Me.btn_keluar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_keluar.Location = New System.Drawing.Point(511, 539)
        Me.btn_keluar.Name = "btn_keluar"
        Me.btn_keluar.Size = New System.Drawing.Size(89, 31)
        Me.btn_keluar.TabIndex = 26
        Me.btn_keluar.Text = "Keluar"
        Me.btn_keluar.UseVisualStyleBackColor = True
        '
        'txtThn_Ajar
        '
        Me.txtThn_Ajar.Location = New System.Drawing.Point(106, 200)
        Me.txtThn_Ajar.Name = "txtThn_Ajar"
        Me.txtThn_Ajar.Size = New System.Drawing.Size(133, 20)
        Me.txtThn_Ajar.TabIndex = 28
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Black
        Me.Label10.Font = New System.Drawing.Font("Times New Roman", 26.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label10.Location = New System.Drawing.Point(38, 13)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(183, 40)
        Me.Label10.TabIndex = 30
        Me.Label10.Text = "Data Siswa"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Panel1.Controls.Add(Me.Label10)
        Me.Panel1.Location = New System.Drawing.Point(0, -1)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(266, 68)
        Me.Panel1.TabIndex = 31
        '
        'btnReport
        '
        Me.btnReport.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnReport.Font = New System.Drawing.Font("Trebuchet MS", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        'Me.btnReport.Image = Global.Tabungan.My.Resources.Resources.Printer_Network_icon
        Me.btnReport.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnReport.Location = New System.Drawing.Point(495, 82)
        Me.btnReport.Name = "btnReport"
        Me.btnReport.Size = New System.Drawing.Size(241, 143)
        Me.btnReport.TabIndex = 32
        Me.btnReport.UseVisualStyleBackColor = True
        '
        'txtSaldo
        '
        Me.txtSaldo.Enabled = False
        Me.txtSaldo.Location = New System.Drawing.Point(741, -1)
        Me.txtSaldo.Name = "txtSaldo"
        Me.txtSaldo.Size = New System.Drawing.Size(10, 20)
        Me.txtSaldo.TabIndex = 33
        '
        'txtNIS
        '
        Me.txtNIS.Location = New System.Drawing.Point(106, 82)
        Me.txtNIS.Name = "txtNIS"
        Me.txtNIS.Size = New System.Drawing.Size(133, 20)
        Me.txtNIS.TabIndex = 10
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.SystemColors.Control
        Me.Label11.Font = New System.Drawing.Font("Tempus Sans ITC", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(604, 87)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(128, 20)
        Me.Label11.TabIndex = 34
        Me.Label11.Text = "Print Data Kolom"
        '
        'f_DataSiswa
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(748, 575)
        Me.ControlBox = False
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.txtSaldo)
        Me.Controls.Add(Me.btnReport)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.txtThn_Ajar)
        Me.Controls.Add(Me.btn_keluar)
        Me.Controls.Add(Me.btn_batal)
        Me.Controls.Add(Me.btn_ubah)
        Me.Controls.Add(Me.btn_hapus)
        Me.Controls.Add(Me.btn_simpan)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.btnBuka)
        Me.Controls.Add(Me.cmbKet)
        Me.Controls.Add(Me.cmbKelas)
        Me.Controls.Add(Me.cmbJK)
        Me.Controls.Add(Me.txtNo_Tlp)
        Me.Controls.Add(Me.txtNama_Ortu)
        Me.Controls.Add(Me.txtAlamat)
        Me.Controls.Add(Me.txtNama_Siswa)
        Me.Controls.Add(Me.txtNIS)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.MaximizeBox = False
        Me.Name = "f_DataSiswa"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Data Siswa"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtNama_Siswa As System.Windows.Forms.TextBox
    Friend WithEvents txtAlamat As System.Windows.Forms.TextBox
    Friend WithEvents txtNama_Ortu As System.Windows.Forms.TextBox
    Friend WithEvents txtNo_Tlp As System.Windows.Forms.TextBox
    Friend WithEvents cmbJK As System.Windows.Forms.ComboBox
    Friend WithEvents cmbKelas As System.Windows.Forms.ComboBox
    Friend WithEvents cmbKet As System.Windows.Forms.ComboBox
    Friend WithEvents btnBuka As System.Windows.Forms.Button
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents btn_simpan As System.Windows.Forms.Button
    Friend WithEvents btn_hapus As System.Windows.Forms.Button
    Friend WithEvents btn_ubah As System.Windows.Forms.Button
    Friend WithEvents btn_batal As System.Windows.Forms.Button
    Friend WithEvents btn_keluar As System.Windows.Forms.Button
    Friend WithEvents txtThn_Ajar As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents btnReport As System.Windows.Forms.Button
    Friend WithEvents txtSaldo As System.Windows.Forms.TextBox
    Friend WithEvents txtNIS As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
End Class
