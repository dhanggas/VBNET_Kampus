<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormTransaksiPembelian
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
        Me.SplUtama = New System.Windows.Forms.SplitContainer
        Me.BtnKeluar = New System.Windows.Forms.Button
        Me.BtnSimpan = New System.Windows.Forms.Button
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.BtRemoveFromList = New System.Windows.Forms.Button
        Me.BtInsertToList = New System.Windows.Forms.Button
        Me.BtFindBarang = New System.Windows.Forms.Button
        Me.ListView1 = New System.Windows.Forms.ListView
        Me.TxtStok = New System.Windows.Forms.TextBox
        Me.TxtSubTotal = New System.Windows.Forms.TextBox
        Me.TxtJumlah = New System.Windows.Forms.TextBox
        Me.TxtHarga = New System.Windows.Forms.TextBox
        Me.TxtNmBarang = New System.Windows.Forms.TextBox
        Me.TxtKdBarang = New System.Windows.Forms.TextBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Label16 = New System.Windows.Forms.Label
        Me.Label15 = New System.Windows.Forms.Label
        Me.Label14 = New System.Windows.Forms.Label
        Me.TxtGrandTotal = New System.Windows.Forms.TextBox
        Me.TxtPotongan = New System.Windows.Forms.TextBox
        Me.TxtTotal = New System.Windows.Forms.TextBox
        Me.DtpTglTransBeli = New System.Windows.Forms.DateTimePicker
        Me.BtFindSupplier = New System.Windows.Forms.Button
        Me.TxtAlamat = New System.Windows.Forms.TextBox
        Me.TxtNmSupp = New System.Windows.Forms.TextBox
        Me.TxtKdSupplier = New System.Windows.Forms.TextBox
        Me.TxtKdTransBeli = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.SplUtama.Panel1.SuspendLayout()
        Me.SplUtama.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'SplUtama
        '
        Me.SplUtama.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.SplUtama.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplUtama.Location = New System.Drawing.Point(0, 0)
        Me.SplUtama.Name = "SplUtama"
        Me.SplUtama.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplUtama.Panel1
        '
        Me.SplUtama.Panel1.Controls.Add(Me.BtnKeluar)
        Me.SplUtama.Panel1.Controls.Add(Me.BtnSimpan)
        Me.SplUtama.Panel1.Controls.Add(Me.GroupBox2)
        Me.SplUtama.Panel1.Controls.Add(Me.GroupBox1)
        Me.SplUtama.Panel1.Controls.Add(Me.Label1)
        Me.SplUtama.Panel1MinSize = 0
        '
        'SplUtama.Panel2
        '
        Me.SplUtama.Panel2.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.SplUtama.Panel2MinSize = 0
        Me.SplUtama.Size = New System.Drawing.Size(1039, 550)
        Me.SplUtama.SplitterDistance = 546
        Me.SplUtama.TabIndex = 0
        '
        'BtnKeluar
        '
        Me.BtnKeluar.Location = New System.Drawing.Point(952, 498)
        Me.BtnKeluar.Name = "BtnKeluar"
        Me.BtnKeluar.Size = New System.Drawing.Size(75, 45)
        Me.BtnKeluar.TabIndex = 6
        Me.BtnKeluar.Text = "Keluar"
        Me.BtnKeluar.UseVisualStyleBackColor = True
        '
        'BtnSimpan
        '
        Me.BtnSimpan.Location = New System.Drawing.Point(871, 498)
        Me.BtnSimpan.Name = "BtnSimpan"
        Me.BtnSimpan.Size = New System.Drawing.Size(75, 45)
        Me.BtnSimpan.TabIndex = 4
        Me.BtnSimpan.Text = "Simpan"
        Me.BtnSimpan.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.Controls.Add(Me.BtRemoveFromList)
        Me.GroupBox2.Controls.Add(Me.BtInsertToList)
        Me.GroupBox2.Controls.Add(Me.BtFindBarang)
        Me.GroupBox2.Controls.Add(Me.ListView1)
        Me.GroupBox2.Controls.Add(Me.TxtStok)
        Me.GroupBox2.Controls.Add(Me.TxtSubTotal)
        Me.GroupBox2.Controls.Add(Me.TxtJumlah)
        Me.GroupBox2.Controls.Add(Me.TxtHarga)
        Me.GroupBox2.Controls.Add(Me.TxtNmBarang)
        Me.GroupBox2.Controls.Add(Me.TxtKdBarang)
        Me.GroupBox2.Controls.Add(Me.Label13)
        Me.GroupBox2.Controls.Add(Me.Label12)
        Me.GroupBox2.Controls.Add(Me.Label11)
        Me.GroupBox2.Controls.Add(Me.Label10)
        Me.GroupBox2.Controls.Add(Me.Label9)
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 274)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(1015, 213)
        Me.GroupBox2.TabIndex = 2
        Me.GroupBox2.TabStop = False
        '
        'BtRemoveFromList
        '
        Me.BtRemoveFromList.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtRemoveFromList.Location = New System.Drawing.Point(812, 40)
        Me.BtRemoveFromList.Name = "BtRemoveFromList"
        Me.BtRemoveFromList.Size = New System.Drawing.Size(95, 26)
        Me.BtRemoveFromList.TabIndex = 15
        Me.BtRemoveFromList.Text = "Remove List"
        Me.BtRemoveFromList.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.BtRemoveFromList.UseVisualStyleBackColor = True
        '
        'BtInsertToList
        '
        Me.BtInsertToList.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtInsertToList.Location = New System.Drawing.Point(705, 40)
        Me.BtInsertToList.Name = "BtInsertToList"
        Me.BtInsertToList.Size = New System.Drawing.Size(101, 26)
        Me.BtInsertToList.TabIndex = 14
        Me.BtInsertToList.Text = "Add List"
        Me.BtInsertToList.UseVisualStyleBackColor = True
        '
        'BtFindBarang
        '
        Me.BtFindBarang.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtFindBarang.Location = New System.Drawing.Point(137, 40)
        Me.BtFindBarang.Name = "BtFindBarang"
        Me.BtFindBarang.Size = New System.Drawing.Size(34, 26)
        Me.BtFindBarang.TabIndex = 13
        Me.BtFindBarang.Text = "--"
        Me.BtFindBarang.UseVisualStyleBackColor = True
        '
        'ListView1
        '
        Me.ListView1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ListView1.FullRowSelect = True
        Me.ListView1.GridLines = True
        Me.ListView1.Location = New System.Drawing.Point(7, 72)
        Me.ListView1.Name = "ListView1"
        Me.ListView1.Size = New System.Drawing.Size(1002, 135)
        Me.ListView1.TabIndex = 12
        Me.ListView1.UseCompatibleStateImageBehavior = False
        Me.ListView1.View = System.Windows.Forms.View.Details
        '
        'TxtStok
        '
        Me.TxtStok.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtStok.Location = New System.Drawing.Point(913, 40)
        Me.TxtStok.Name = "TxtStok"
        Me.TxtStok.Size = New System.Drawing.Size(77, 26)
        Me.TxtStok.TabIndex = 11
        '
        'TxtSubTotal
        '
        Me.TxtSubTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtSubTotal.Location = New System.Drawing.Point(599, 40)
        Me.TxtSubTotal.Name = "TxtSubTotal"
        Me.TxtSubTotal.Size = New System.Drawing.Size(100, 26)
        Me.TxtSubTotal.TabIndex = 10
        '
        'TxtJumlah
        '
        Me.TxtJumlah.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtJumlah.Location = New System.Drawing.Point(481, 40)
        Me.TxtJumlah.Name = "TxtJumlah"
        Me.TxtJumlah.Size = New System.Drawing.Size(100, 26)
        Me.TxtJumlah.TabIndex = 9
        '
        'TxtHarga
        '
        Me.TxtHarga.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtHarga.Location = New System.Drawing.Point(363, 40)
        Me.TxtHarga.Name = "TxtHarga"
        Me.TxtHarga.Size = New System.Drawing.Size(100, 26)
        Me.TxtHarga.TabIndex = 8
        '
        'TxtNmBarang
        '
        Me.TxtNmBarang.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtNmBarang.Location = New System.Drawing.Point(177, 40)
        Me.TxtNmBarang.Name = "TxtNmBarang"
        Me.TxtNmBarang.Size = New System.Drawing.Size(170, 26)
        Me.TxtNmBarang.TabIndex = 7
        '
        'TxtKdBarang
        '
        Me.TxtKdBarang.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtKdBarang.Location = New System.Drawing.Point(9, 40)
        Me.TxtKdBarang.Name = "TxtKdBarang"
        Me.TxtKdBarang.Size = New System.Drawing.Size(122, 26)
        Me.TxtKdBarang.TabIndex = 6
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(910, 16)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(52, 18)
        Me.Label13.TabIndex = 5
        Me.Label13.Text = "Stock"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(596, 16)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(80, 18)
        Me.Label12.TabIndex = 4
        Me.Label12.Text = "Sub Total"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(478, 16)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(62, 18)
        Me.Label11.TabIndex = 3
        Me.Label11.Text = "Jumlah"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(360, 16)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(86, 18)
        Me.Label10.TabIndex = 2
        Me.Label10.Text = "Harga Beli"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(174, 16)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(110, 18)
        Me.Label9.TabIndex = 1
        Me.Label9.Text = "Nama Barang"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(6, 16)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(105, 18)
        Me.Label8.TabIndex = 0
        Me.Label8.Text = "Kode Barang"
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.Label16)
        Me.GroupBox1.Controls.Add(Me.Label15)
        Me.GroupBox1.Controls.Add(Me.Label14)
        Me.GroupBox1.Controls.Add(Me.TxtGrandTotal)
        Me.GroupBox1.Controls.Add(Me.TxtPotongan)
        Me.GroupBox1.Controls.Add(Me.TxtTotal)
        Me.GroupBox1.Controls.Add(Me.DtpTglTransBeli)
        Me.GroupBox1.Controls.Add(Me.BtFindSupplier)
        Me.GroupBox1.Controls.Add(Me.TxtAlamat)
        Me.GroupBox1.Controls.Add(Me.TxtNmSupp)
        Me.GroupBox1.Controls.Add(Me.TxtKdSupplier)
        Me.GroupBox1.Controls.Add(Me.TxtKdTransBeli)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 63)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(1015, 205)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 26.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(596, 142)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(210, 39)
        Me.Label16.TabIndex = 23
        Me.Label16.Text = "Grand Total"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 26.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(676, 74)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(130, 39)
        Me.Label15.TabIndex = 22
        Me.Label15.Text = "Diskon"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 26.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(698, 16)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(99, 39)
        Me.Label14.TabIndex = 21
        Me.Label14.Text = "Total"
        '
        'TxtGrandTotal
        '
        Me.TxtGrandTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 26.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtGrandTotal.Location = New System.Drawing.Point(812, 139)
        Me.TxtGrandTotal.Name = "TxtGrandTotal"
        Me.TxtGrandTotal.Size = New System.Drawing.Size(193, 47)
        Me.TxtGrandTotal.TabIndex = 20
        '
        'TxtPotongan
        '
        Me.TxtPotongan.Font = New System.Drawing.Font("Microsoft Sans Serif", 26.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtPotongan.Location = New System.Drawing.Point(812, 74)
        Me.TxtPotongan.Name = "TxtPotongan"
        Me.TxtPotongan.Size = New System.Drawing.Size(193, 47)
        Me.TxtPotongan.TabIndex = 19
        '
        'TxtTotal
        '
        Me.TxtTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 26.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtTotal.Location = New System.Drawing.Point(812, 13)
        Me.TxtTotal.Name = "TxtTotal"
        Me.TxtTotal.Size = New System.Drawing.Size(193, 47)
        Me.TxtTotal.TabIndex = 18
        '
        'DtpTglTransBeli
        '
        Me.DtpTglTransBeli.CustomFormat = "dd  MMMM yyyy"
        Me.DtpTglTransBeli.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DtpTglTransBeli.Location = New System.Drawing.Point(216, 54)
        Me.DtpTglTransBeli.Name = "DtpTglTransBeli"
        Me.DtpTglTransBeli.Size = New System.Drawing.Size(144, 29)
        Me.DtpTglTransBeli.TabIndex = 17
        '
        'BtFindSupplier
        '
        Me.BtFindSupplier.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtFindSupplier.Location = New System.Drawing.Point(331, 100)
        Me.BtFindSupplier.Name = "BtFindSupplier"
        Me.BtFindSupplier.Size = New System.Drawing.Size(37, 29)
        Me.BtFindSupplier.TabIndex = 16
        Me.BtFindSupplier.Text = "--"
        Me.BtFindSupplier.UseVisualStyleBackColor = True
        '
        'TxtAlamat
        '
        Me.TxtAlamat.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtAlamat.Location = New System.Drawing.Point(216, 170)
        Me.TxtAlamat.Name = "TxtAlamat"
        Me.TxtAlamat.Size = New System.Drawing.Size(247, 29)
        Me.TxtAlamat.TabIndex = 11
        '
        'TxtNmSupp
        '
        Me.TxtNmSupp.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtNmSupp.Location = New System.Drawing.Point(216, 135)
        Me.TxtNmSupp.Name = "TxtNmSupp"
        Me.TxtNmSupp.Size = New System.Drawing.Size(247, 29)
        Me.TxtNmSupp.TabIndex = 10
        '
        'TxtKdSupplier
        '
        Me.TxtKdSupplier.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtKdSupplier.Location = New System.Drawing.Point(216, 100)
        Me.TxtKdSupplier.Name = "TxtKdSupplier"
        Me.TxtKdSupplier.Size = New System.Drawing.Size(100, 29)
        Me.TxtKdSupplier.TabIndex = 9
        '
        'TxtKdTransBeli
        '
        Me.TxtKdTransBeli.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtKdTransBeli.Location = New System.Drawing.Point(215, 16)
        Me.TxtKdTransBeli.Name = "TxtKdTransBeli"
        Me.TxtKdTransBeli.Size = New System.Drawing.Size(144, 29)
        Me.TxtKdTransBeli.TabIndex = 6
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(6, 170)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(142, 24)
        Me.Label7.TabIndex = 5
        Me.Label7.Text = "Alamat Supplier"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(6, 135)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(135, 24)
        Me.Label6.TabIndex = 4
        Me.Label6.Text = "Nama Supplier"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(5, 100)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(130, 24)
        Me.Label5.TabIndex = 3
        Me.Label5.Text = "Kode Supplier"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(5, 54)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(174, 24)
        Me.Label3.TabIndex = 1
        Me.Label3.Text = "Tanggal Pembelian"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(6, 16)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(150, 24)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Kode Pembelian"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(13, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(414, 31)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "TRANSAKSI PEMBELIAN BUKU"
        '
        'FormTransaksiPembelian
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1039, 550)
        Me.Controls.Add(Me.SplUtama)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "FormTransaksiPembelian"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FormTransaksiPembelian"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.SplUtama.Panel1.ResumeLayout(False)
        Me.SplUtama.Panel1.PerformLayout()
        Me.SplUtama.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents SplUtama As System.Windows.Forms.SplitContainer
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents TxtStok As System.Windows.Forms.TextBox
    Friend WithEvents TxtSubTotal As System.Windows.Forms.TextBox
    Friend WithEvents TxtJumlah As System.Windows.Forms.TextBox
    Friend WithEvents TxtHarga As System.Windows.Forms.TextBox
    Friend WithEvents TxtNmBarang As System.Windows.Forms.TextBox
    Friend WithEvents TxtKdBarang As System.Windows.Forms.TextBox
    Friend WithEvents BtRemoveFromList As System.Windows.Forms.Button
    Friend WithEvents BtInsertToList As System.Windows.Forms.Button
    Friend WithEvents BtFindBarang As System.Windows.Forms.Button
    Friend WithEvents ListView1 As System.Windows.Forms.ListView
    Friend WithEvents BtFindSupplier As System.Windows.Forms.Button
    Friend WithEvents TxtAlamat As System.Windows.Forms.TextBox
    Friend WithEvents TxtNmSupp As System.Windows.Forms.TextBox
    Friend WithEvents TxtKdSupplier As System.Windows.Forms.TextBox
    Friend WithEvents TxtKdTransBeli As System.Windows.Forms.TextBox
    Friend WithEvents DtpTglTransBeli As System.Windows.Forms.DateTimePicker
    Friend WithEvents BtnSimpan As System.Windows.Forms.Button
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents TxtGrandTotal As System.Windows.Forms.TextBox
    Friend WithEvents TxtPotongan As System.Windows.Forms.TextBox
    Friend WithEvents TxtTotal As System.Windows.Forms.TextBox
    Friend WithEvents BtnKeluar As System.Windows.Forms.Button
End Class
