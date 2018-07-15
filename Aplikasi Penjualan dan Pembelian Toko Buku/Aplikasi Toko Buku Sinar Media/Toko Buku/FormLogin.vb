Imports System.Data.SqlClient
Public Class FormLogin
    Private Sub enebelkanKasir(ByVal xEnebel As Boolean)
        FormUtama.MenuPenjualan.Enabled = xEnebel
        FormUtama.MenuLaporan.Enabled = xEnebel
        FormUtama.LaporanPenjualan.Enabled = xEnebel
    End Sub
    Private Sub enebelkanPegawai(ByVal xEnebel As Boolean)
        FormUtama.MenuMasterBarang.Enabled = xEnebel
        FormUtama.MenuMasterKatagori.Enabled = xEnebel
        FormUtama.MenuMasterSupplier.Enabled = xEnebel
        FormUtama.MasterUser.Enabled = xEnebel
        FormUtama.MenuPembelian.Enabled = xEnebel
        FormUtama.MenuLaporan.Enabled = xEnebel
        FormUtama.LaporanPembelian.Enabled = xEnebel
    End Sub
    Private Sub login()
        Dim oCommand As SqlCommand = New SqlCommand
        If Trim(TxtNama.Text) = "" Then
            MessageBox.Show("Username belum diisi", "Perhatian", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            TxtNama.Focus()
        ElseIf Trim(TextPass.Text) = "" Then
            MessageBox.Show("Password belum diisi", "Perhatian", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            TxtNama.Focus()
        Else
            StrSQL = " select * from T_USER " _
                 & " where user_name = '" & TxtNama.Text & "'" _
                 & " and password = '" & TextPass.Text & "'"
            oCommand.Connection = Koneksi.Koneksi
            oCommand.CommandText = StrSQL
            Dim xReader As SqlDataReader = oCommand.ExecuteReader

            If xReader.Read = True Then
                If xReader(3) = "admin" Then
                    enebelkanPegawai(True)
                ElseIf xReader(3) = "kasir" Then
                    enebelkanKasir(True)
                End If
                Me.Dispose()
            Else
                MessageBox.Show("Username atau Password Anda salah", "Perhatian", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                TextPass.Text = ""
                TxtNama.Text = ""
                TxtNama.Focus()
            End If
            xReader.Close()
            Koneksi.Koneksi.Close()
        End If
    End Sub

    Private Sub BtnLogin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnLogin.Click
        login()
    End Sub

    Private Sub BtnBatal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnBatal.Click
        Me.Dispose()
    End Sub

    Private Sub FormLogin_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        TxtNama.Focus()
    End Sub
End Class