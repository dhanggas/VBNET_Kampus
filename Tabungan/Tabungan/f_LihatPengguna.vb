Imports MySql.Data.MySqlClient
Public Class f_LihatPengguna

    Private Sub btnKeluar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnKeluar.Click
        Me.Close()
    End Sub

    Private Sub f_LihatPengguna_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call LihatData()
    End Sub
    Sub LihatData()
        Modul_Koneksi.Koneksi()
        DA = New MySqlDataAdapter("SELECT * from pengguna", Conn)
        DS = New DataSet
        DA.Fill(DS, "pengguna")
        DataGridView1.DataSource = DS.Tables("pengguna")
        DataGridView1.ReadOnly = True
    End Sub
End Class