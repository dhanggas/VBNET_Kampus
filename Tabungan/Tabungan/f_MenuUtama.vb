Public Class f_MenuUtama

    Private Sub SetoranToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SetoranToolStripMenuItem.Click
        f_Setoran.Show()
        f_Setoran.MdiParent = Me
    End Sub

    Private Sub DataSiswaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DataSiswaToolStripMenuItem.Click
        f_DataSiswa.Show()
        f_DataSiswa.MdiParent = Me
    End Sub

    Private Sub KeluarToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles KeluarToolStripMenuItem.Click
        If MessageBox.Show("Yakin Akan Keluar...??? ", "Pesan", _
                          MessageBoxButtons.YesNo, MessageBoxIcon.Question) = vbYes Then
            End
        End If
    End Sub

    Private Sub PengambilanToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PengambilanToolStripMenuItem.Click
        f_Pengambilan.Show()
        f_Pengambilan.MdiParent = Me
    End Sub

    Private Sub LaporanSetoranToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LaporanSetoranToolStripMenuItem.Click
        f_ReportSetorDate.Show()
        f_ReportSetorDate.MdiParent = Me
    End Sub
   
    Private Sub LaporanPengambilanTanggalToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LaporanPengambilanTanggalToolStripMenuItem.Click
        f_ReportAmbilDate.Show()
        f_ReportAmbilDate.MdiParent = Me
    End Sub

    Private Sub GantiPasswordToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GantiPasswordToolStripMenuItem.Click
        f_PenggunaControl.Show()
        f_PenggunaControl.MdiParent = Me
    End Sub
    Private Sub LogoutToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LogoutToolStripMenuItem.Click
        Dim Login As New f_Login
        Login.Show()
        Me.Hide()
    End Sub

    Private Sub TambahPenggunaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TambahPenggunaToolStripMenuItem.Click
        f_TambahPengguna.Show()
        f_TambahPengguna.MdiParent = Me
    End Sub

    Private Sub LihatPenggunaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LihatPenggunaToolStripMenuItem.Click
        f_LihatPengguna.Show()
        f_LihatPengguna.MdiParent = Me
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub ToolStripStatusLabel1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripStatusLabel1.Click

    End Sub
End Class
