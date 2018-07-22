Imports MySql.Data.MySqlClient
Public Class f_TambahPengguna

    Private Sub f_TambahPengguna_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call Koneksi()
        Call hapustext()
    End Sub
    Sub hapustext()
        txtKd.Clear()
        txtUser.Clear()
        txtPass.Clear()
        cmbStatus.Text = "--Pilih Status--"
    End Sub

    Private Sub btnBatal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBatal.Click
        Call hapustext()
    End Sub

    Private Sub btnKeluar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnKeluar.Click
        Me.Close()
    End Sub

    Private Sub btnSimpan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSimpan.Click
        If txtKd.Text = "" Then
            MsgBox("Data Tidak Boleh Kosong", MsgBoxStyle.Critical, "Pesan")
        Else
            If MessageBox.Show("Apakah Yakin Akan Menyimpan...?", "", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
                Try
                    Call Koneksi()
                    CMD = New MySqlCommand("SELECT Kd_Pengguna from pengguna WHERE Kd_Pengguna= '" & txtKd.Text & "'", Conn)
                    RD = CMD.ExecuteReader
                    RD.Read()
                    If RD.HasRows Then
                        MsgBox("Maaf, Data dengan kode tersebut telah ada", MsgBoxStyle.Exclamation, "Peringatan")
                    Else
                        Dim simpan As String
                        Call Koneksi()
                        simpan = "INSERT INTO pengguna (Kd_Pengguna,Username,Password,Status) VALUES ('" & txtKd.Text & "','" & txtUser.Text & "','" & txtPass.Text & "','" & cmbStatus.Text & "')"
                        CMD = New MySqlCommand(simpan, Conn)
                        CMD.ExecuteNonQuery()
                        Call hapustext()
                    End If
                Catch ex As Exception
                    MsgBox(ex.ToString, MsgBoxStyle.Critical, "Terjadi Kesalahan")
                End Try
            End If
        End If
    End Sub
End Class