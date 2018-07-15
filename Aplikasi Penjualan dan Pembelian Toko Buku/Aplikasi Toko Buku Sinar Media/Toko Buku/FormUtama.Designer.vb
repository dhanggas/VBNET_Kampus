<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormUtama
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormUtama))
        Me.MenuSamping = New System.Windows.Forms.ToolStrip
        Me.MenuFile = New System.Windows.Forms.ToolStripDropDownButton
        Me.LoginToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.LogOutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripSeparator
        Me.ExitToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.MenuMasterKatagori = New System.Windows.Forms.ToolStripButton
        Me.MenuMasterBarang = New System.Windows.Forms.ToolStripButton
        Me.MenuMasterSupplier = New System.Windows.Forms.ToolStripButton
        Me.MasterUser = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator
        Me.MenuPembelian = New System.Windows.Forms.ToolStripButton
        Me.MenuPenjualan = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator
        Me.MenuLaporan = New System.Windows.Forms.ToolStripDropDownButton
        Me.LaporanPembelian = New System.Windows.Forms.ToolStripMenuItem
        Me.LaporanPenjualan = New System.Windows.Forms.ToolStripMenuItem
        Me.SplUtama = New System.Windows.Forms.SplitContainer
        Me.MenuSamping.SuspendLayout()
        Me.SplUtama.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuSamping
        '
        Me.MenuSamping.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.MenuSamping.Dock = System.Windows.Forms.DockStyle.Left
        Me.MenuSamping.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MenuFile, Me.ToolStripSeparator1, Me.MenuMasterKatagori, Me.MenuMasterBarang, Me.MenuMasterSupplier, Me.MasterUser, Me.ToolStripSeparator5, Me.MenuPembelian, Me.MenuPenjualan, Me.ToolStripSeparator2, Me.MenuLaporan})
        Me.MenuSamping.Location = New System.Drawing.Point(0, 0)
        Me.MenuSamping.Name = "MenuSamping"
        Me.MenuSamping.Size = New System.Drawing.Size(100, 764)
        Me.MenuSamping.TabIndex = 0
        Me.MenuSamping.Text = "ToolStrip1"
        '
        'MenuFile
        '
        Me.MenuFile.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.LoginToolStripMenuItem, Me.LogOutToolStripMenuItem, Me.ExitToolStripMenuItem, Me.ExitToolStripMenuItem1})
        Me.MenuFile.Image = Global.Toko_Buku.My.Resources.Resources.Smurf_House_Brainy
        Me.MenuFile.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.MenuFile.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.MenuFile.Name = "MenuFile"
        Me.MenuFile.Size = New System.Drawing.Size(97, 83)
        Me.MenuFile.Text = "Home"
        Me.MenuFile.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'LoginToolStripMenuItem
        '
        Me.LoginToolStripMenuItem.Name = "LoginToolStripMenuItem"
        Me.LoginToolStripMenuItem.Size = New System.Drawing.Size(117, 22)
        Me.LoginToolStripMenuItem.Text = "Login"
        '
        'LogOutToolStripMenuItem
        '
        Me.LogOutToolStripMenuItem.Name = "LogOutToolStripMenuItem"
        Me.LogOutToolStripMenuItem.Size = New System.Drawing.Size(117, 22)
        Me.LogOutToolStripMenuItem.Text = "Log Out"
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(114, 6)
        '
        'ExitToolStripMenuItem1
        '
        Me.ExitToolStripMenuItem1.Name = "ExitToolStripMenuItem1"
        Me.ExitToolStripMenuItem1.Size = New System.Drawing.Size(117, 22)
        Me.ExitToolStripMenuItem1.Text = "Exit"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(97, 6)
        '
        'MenuMasterKatagori
        '
        Me.MenuMasterKatagori.Image = Global.Toko_Buku.My.Resources.Resources.Facebook
        Me.MenuMasterKatagori.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.MenuMasterKatagori.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.MenuMasterKatagori.Name = "MenuMasterKatagori"
        Me.MenuMasterKatagori.Size = New System.Drawing.Size(97, 89)
        Me.MenuMasterKatagori.Text = "Master Katagori"
        Me.MenuMasterKatagori.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.MenuMasterKatagori.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'MenuMasterBarang
        '
        Me.MenuMasterBarang.Image = Global.Toko_Buku.My.Resources.Resources.Book1
        Me.MenuMasterBarang.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.MenuMasterBarang.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.MenuMasterBarang.Name = "MenuMasterBarang"
        Me.MenuMasterBarang.Size = New System.Drawing.Size(97, 89)
        Me.MenuMasterBarang.Text = "Master Buku"
        Me.MenuMasterBarang.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.MenuMasterBarang.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'MenuMasterSupplier
        '
        Me.MenuMasterSupplier.Image = Global.Toko_Buku.My.Resources.Resources.Fieldrunner
        Me.MenuMasterSupplier.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.MenuMasterSupplier.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.MenuMasterSupplier.Name = "MenuMasterSupplier"
        Me.MenuMasterSupplier.Size = New System.Drawing.Size(97, 89)
        Me.MenuMasterSupplier.Text = "Master Supplier"
        Me.MenuMasterSupplier.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.MenuMasterSupplier.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'MasterUser
        '
        Me.MasterUser.Image = Global.Toko_Buku.My.Resources.Resources.CBNK3D
        Me.MasterUser.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.MasterUser.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.MasterUser.Name = "MasterUser"
        Me.MasterUser.Size = New System.Drawing.Size(97, 89)
        Me.MasterUser.Text = "Master User"
        Me.MasterUser.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.MasterUser.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(97, 6)
        '
        'MenuPembelian
        '
        Me.MenuPembelian.Image = Global.Toko_Buku.My.Resources.Resources.Wire_transfer
        Me.MenuPembelian.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.MenuPembelian.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.MenuPembelian.Name = "MenuPembelian"
        Me.MenuPembelian.Size = New System.Drawing.Size(97, 83)
        Me.MenuPembelian.Text = "Trans Pembelian"
        Me.MenuPembelian.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.MenuPembelian.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'MenuPenjualan
        '
        Me.MenuPenjualan.Image = Global.Toko_Buku.My.Resources.Resources.Green_Dollar
        Me.MenuPenjualan.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.MenuPenjualan.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.MenuPenjualan.Name = "MenuPenjualan"
        Me.MenuPenjualan.Size = New System.Drawing.Size(97, 83)
        Me.MenuPenjualan.Text = "Trans Penjualan"
        Me.MenuPenjualan.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.MenuPenjualan.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(97, 6)
        '
        'MenuLaporan
        '
        Me.MenuLaporan.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.LaporanPembelian, Me.LaporanPenjualan})
        Me.MenuLaporan.Image = Global.Toko_Buku.My.Resources.Resources.Psd
        Me.MenuLaporan.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.MenuLaporan.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.MenuLaporan.Name = "MenuLaporan"
        Me.MenuLaporan.Size = New System.Drawing.Size(97, 83)
        Me.MenuLaporan.Text = "Laporan"
        Me.MenuLaporan.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.MenuLaporan.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'LaporanPembelian
        '
        Me.LaporanPembelian.Name = "LaporanPembelian"
        Me.LaporanPembelian.Size = New System.Drawing.Size(176, 22)
        Me.LaporanPembelian.Text = "Laporan Pembelian"
        '
        'LaporanPenjualan
        '
        Me.LaporanPenjualan.Name = "LaporanPenjualan"
        Me.LaporanPenjualan.Size = New System.Drawing.Size(176, 22)
        Me.LaporanPenjualan.Text = "Laporan Penjualan"
        '
        'SplUtama
        '
        Me.SplUtama.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.SplUtama.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplUtama.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
        Me.SplUtama.IsSplitterFixed = True
        Me.SplUtama.Location = New System.Drawing.Point(100, 0)
        Me.SplUtama.Name = "SplUtama"
        '
        'SplUtama.Panel1
        '
        Me.SplUtama.Panel1.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.SplUtama.Panel1MinSize = 0
        '
        'SplUtama.Panel2
        '
        Me.SplUtama.Panel2.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.SplUtama.Size = New System.Drawing.Size(651, 764)
        Me.SplUtama.SplitterDistance = 0
        Me.SplUtama.TabIndex = 1
        '
        'FormUtama
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(751, 764)
        Me.Controls.Add(Me.SplUtama)
        Me.Controls.Add(Me.MenuSamping)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FormUtama"
        Me.Text = "APLIKASI PENJUALAN DAN PEMBELIAN TOKO BUKU SINAR MEDIA"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.MenuSamping.ResumeLayout(False)
        Me.MenuSamping.PerformLayout()
        Me.SplUtama.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuSamping As System.Windows.Forms.ToolStrip
    Friend WithEvents MenuFile As System.Windows.Forms.ToolStripDropDownButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents MenuMasterKatagori As System.Windows.Forms.ToolStripButton
    Friend WithEvents MenuMasterBarang As System.Windows.Forms.ToolStripButton
    Friend WithEvents MenuMasterSupplier As System.Windows.Forms.ToolStripButton
    Friend WithEvents MasterUser As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents MenuPembelian As System.Windows.Forms.ToolStripButton
    Friend WithEvents MenuPenjualan As System.Windows.Forms.ToolStripButton
    Friend WithEvents SplUtama As System.Windows.Forms.SplitContainer
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents LoginToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents LogOutToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ExitToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuLaporan As System.Windows.Forms.ToolStripDropDownButton
    Friend WithEvents LaporanPembelian As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents LaporanPenjualan As System.Windows.Forms.ToolStripMenuItem

End Class
