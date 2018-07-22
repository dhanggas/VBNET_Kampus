Imports MySql.Data.MySqlClient
Public Class f_PenggunaControl
    Private Sub f_PenggunaControl_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Koneksi()
    End Sub
    Sub hapustext()
        txtKd.Clear()
        txtUser.Clear()
        txtPass.Clear()
        txtStatus.Clear()
    End Sub
    Private Sub txtKd_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtKd.KeyPress
        Dim cari As String
        Dim tombol As Integer = Asc(e.KeyChar)
        If tombol = 13 Then
            cari = "SELECT * FROM pengguna Where Kd_Pengguna='" & txtKd.Text & "'"
            CMD = New MySqlCommand(cari, Conn)
            RD = CMD.ExecuteReader
            RD.Read()
            If RD.HasRows = True Then
                txtUser.Text = RD.Item(1)
                txtPass.Text = RD.Item(2)
                txtStatus.Text = RD.Item(3)
                MsgBox("Data Ditemukan!!!")
            Else
                MsgBox("Data tidak ditemukan", MsgBoxStyle.Exclamation, "Pesan")
                txtKd.Clear()
            End If
            txtUser.Focus()
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If txtKd.Text = "" Then
            MsgBox("Cari Data Yang Akan Diubah", MsgBoxStyle.Critical, "Pesan")
        Else
            If MessageBox.Show("Apakah Yakin Akan Ubah...?", "", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
                Try
                    Dim ubah As String
                    Call Koneksi()
                    ubah = "UPDATE pengguna SET Username='" & txtUser.Text & "',Password='" & txtPass.Text & "',Status='" & txtStatus.Text & "' WHERE Kd_Pengguna = '" & txtKd.Text & "'"
                    CMD = New MySqlCommand(ubah, Conn)
                    CMD.ExecuteNonQuery()
                    Call hapustext()
                Catch ex As Exception
                    MsgBox(ex.ToString, MsgBoxStyle.Critical, "Terjadi Kesalahan")
                End Try
            End If
        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        hapustext()
    End Sub

    Private Sub btnKeluar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnKeluar.Click
        Me.Close()
    End Sub
End Class