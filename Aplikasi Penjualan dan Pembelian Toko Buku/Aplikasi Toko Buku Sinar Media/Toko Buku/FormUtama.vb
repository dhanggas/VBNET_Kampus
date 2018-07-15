Public Class FormUtama

    Private Sub MenuMasterKatagori_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuMasterKatagori.Click
        FormMasterKatagori.TopLevel = False
        FormMasterKatagori.Parent = Me.SplUtama.Panel2
        FormMasterKatagori.Dock = DockStyle.Fill
        FormMasterKatagori.Show()
    End Sub

    Private Sub MenuMasterBarang_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuMasterBarang.Click
        FormMasterBarang.TopLevel = False
        FormMasterBarang.Parent = Me.SplUtama.Panel2
        FormMasterBarang.Dock = DockStyle.Fill
        FormMasterBarang.Show()
    End Sub

    Private Sub MenuMasterSupplier_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuMasterSupplier.Click
        FormMasterSupplier.TopLevel = False
        FormMasterSupplier.Parent = Me.SplUtama.Panel2
        FormMasterSupplier.Dock = DockStyle.Fill
        FormMasterSupplier.Show()
    End Sub

    Private Sub MenuPembelian_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuPembelian.Click
        FormTransaksiPembelian.TopLevel = False
        FormTransaksiPembelian.Parent = Me.SplUtama.Panel2
        FormTransaksiPembelian.Dock = DockStyle.Fill
        FormTransaksiPembelian.Show()
    End Sub

    Private Sub MenuPenjualan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuPenjualan.Click
        FormTransaksiPenjualan.TopLevel = False
        FormTransaksiPenjualan.Parent = Me.SplUtama.Panel2
        FormTransaksiPenjualan.Dock = DockStyle.Fill
        FormTransaksiPenjualan.Show()
    End Sub

    Private Sub FormUtama_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        enebelkan(False)
        FormLogin.ShowDialog()
        FormLogin.TxtNama.Focus()
    End Sub

    Private Sub enebelkan(ByVal xEnebel As Boolean)
        MenuMasterBarang.Enabled = xEnebel
        MenuMasterKatagori.Enabled = xEnebel
        MenuMasterSupplier.Enabled = xEnebel
        MasterUser.Enabled = xEnebel
        MenuPembelian.Enabled = xEnebel
        MenuPenjualan.Enabled = xEnebel
        MenuLaporan.Enabled = xEnebel
        LaporanPembelian.Enabled = xEnebel
        LaporanPenjualan.Enabled = xEnebel
    End Sub

    Private Sub MasterUser_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MasterUser.Click
        FormMasterUser.TopLevel = False
        FormMasterUser.Parent = Me.SplUtama.Panel2
        FormMasterUser.Dock = DockStyle.Fill
        FormMasterUser.Show()
    End Sub

    Private Sub LoginToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LoginToolStripMenuItem.Click
        FormLogin.ShowDialog()
    End Sub

    Private Sub LogOutToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LogOutToolStripMenuItem.Click
        enebelkan(False)
        FormLogin.ShowDialog()
    End Sub

    Private Sub LaporanPembelian_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LaporanPembelian.Click
        CariLaporanPembelian.ShowDialog()
    End Sub

    Private Sub LaporanPenjualan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LaporanPenjualan.Click
        CariLaporanPenjualan.ShowDialog()
    End Sub
End Class
