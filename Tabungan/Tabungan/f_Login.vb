Imports MySql.Data.MySqlClient
Public Class f_Login

    Private Sub btnMasuk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMasuk.Click
        Koneksi()
        CMD = New MySqlCommand("select * from pengguna where Username='" & txtUser.Text & "' and Password='" & txtPass.Text & "'", Conn)
        RD = CMD.ExecuteReader
        RD.Read()
        If RD.HasRows Then
            Me.Visible = False
            f_MenuUtama.Show()
            f_MenuUtama.ToolStripStatusLabel1.Text = RD.GetString(1)
            f_MenuUtama.ToolStripStatusLabel2.Text = RD.GetString(3)
            If f_MenuUtama.ToolStripStatusLabel2.Text = "ADMINISTRATOR" Then
                f_MenuUtama.MasterToolStripMenuItem.Enabled = True
                f_MenuUtama.PetugasToolStripMenuItem.Enabled = True
            Else
                f_MenuUtama.MasterToolStripMenuItem.Enabled = False
                f_MenuUtama.PetugasToolStripMenuItem.Enabled = False
            End If
        Else
            MsgBox("Login Tidak Berhasil, Periksan Kembali Username dan Password", MsgBoxStyle.Exclamation, "Peringatan")
            txtUser.Clear()
            txtPass.Clear()
            txtUser.Focus()
        End If
    End Sub
    Private Sub PictureBox3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox3.Click
        If MessageBox.Show("Yakin Akan Keluar...??? ", "Pesan", _
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question) = vbYes Then
            End
        End If
    End Sub

End Class