Imports MySql.Data.MySqlClient
Public Class f_CariSiswa

    Private Sub f_CariSiswa_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call Koneksi()
        Call TampilDataGrid()
    End Sub

    Private Sub RB_NIS_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RB_NIS.CheckedChanged
        txtCari.Select()
    End Sub
    Sub TampilDataGrid()
        Modul_Koneksi.Koneksi()
        DA = New MySqlDataAdapter("SELECT * from data_siswa", Conn)
        DS = New DataSet
        DA.Fill(DS, "data_siswa")
        DataGridView1.DataSource = DS.Tables("data_siswa")
        DataGridView1.ReadOnly = True
    End Sub
    Sub CariNIS()
        Dim sql As String = "SELECT * FROM data_siswa WHERE NIS LIKE '%" & txtCari.Text & "%'"
        CMD = New MySqlCommand(sql, Conn)
        DA = New MySqlDataAdapter(CMD)
        DB = New MySqlCommandBuilder(DA)
        DS = New DataSet
        DA.Fill(DS, "data_siswa")
        DT = DS.Tables("data_siswa")
        Conn.Close()
        DataGridView1.DataSource = DT
        DataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect
    End Sub
    Sub CariNama_Siswa()
        Dim sql As String = "SELECT * FROM data_siswa WHERE Nama_Siswa LIKE '%" & txtCari.Text & "%'"
        CMD = New MySqlCommand(sql, Conn)
        DA = New MySqlDataAdapter(CMD)
        DB = New MySqlCommandBuilder(DA)
        DS = New DataSet
        DA.Fill(DS, "data_siswa")
        DT = DS.Tables("data_siswa")
        Conn.Close()
        DataGridView1.DataSource = DT
        DataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect
    End Sub
    Sub CariKelas()
        Dim sql As String = "SELECT * FROM data_siswa WHERE Kelas LIKE '%" & txtCari.Text & "%'"
        CMD = New MySqlCommand(sql, Conn)
        DA = New MySqlDataAdapter(CMD)
        DB = New MySqlCommandBuilder(DA)
        DS = New DataSet
        DA.Fill(DS, "data_siswa")
        DT = DS.Tables("data_siswa")
        Conn.Close()
        DataGridView1.DataSource = DT
        DataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect
    End Sub

    Private Sub txtCari_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCari.KeyUp
        Try
            Dim cari As String
            If RB_NIS.Checked = True Then
                cari = "NIS"
                CariNIS()
            ElseIf RB_Nama.Checked = True Then
                cari = "Nama_Siswa"
                CariNama_Siswa()
            ElseIf RB_Kelas.Checked = True Then
                cari = "Kelas"
                CariKelas()
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Information, "Data Siswa")
        End Try
    End Sub

    Private Sub DataGridView1_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        Try
        Dim gridbaris As DataGridViewRow = DataGridView1.Rows(e.RowIndex)
        f_Setoran.txtNIS.Text = gridbaris.Cells(0).Value.ToString
        f_Setoran.lbNama_Siswa.Text = gridbaris.Cells(1).Value.ToString
        f_Setoran.lbKelas.Text = gridbaris.Cells(5).Value.ToString
        f_Setoran.lbSaldo_Awal.Text = gridbaris.Cells(8).Value.ToString
        f_Pengambilan.txtNIS.Text = gridbaris.Cells(0).Value.ToString
        f_Pengambilan.lbNama_Siswa.Text = gridbaris.Cells(1).Value.ToString
        f_Pengambilan.lbKelas.Text = gridbaris.Cells(5).Value.ToString
        f_Pengambilan.LbSaldo_Awal.Text = gridbaris.Cells(8).Value.ToString
            Me.Hide()
        Catch ex As Exception
            MsgBox("Pilih yang ada di dalam tabel")
        End Try
    End Sub

    Private Sub btnKeluar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnKeluar.Click
        Me.Close()
    End Sub
End Class