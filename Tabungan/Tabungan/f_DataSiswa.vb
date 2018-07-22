Imports MySql.Data.MySqlClient
Public Class f_DataSiswa

    Private Sub f_DataSiswa_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call Koneksi()
        Call TampilDataGrid()
        Call tidak_Aktif()
    End Sub

    Sub TampilDataGrid()
        Modul_Koneksi.Koneksi()
        DA = New MySqlDataAdapter("SELECT * from data_siswa", Conn)
        DS = New DataSet
        DA.Fill(DS, "data_siswa")
        DataGridView1.DataSource = DS.Tables("data_siswa")
        DataGridView1.ReadOnly = True
    End Sub
    Sub hapustext()
        txtAlamat.Clear()
        txtNama_Ortu.Clear()
        txtNama_Siswa.Clear()
        txtNis.Clear()
        txtNo_Tlp.Clear()
        txtThn_Ajar.Clear()
        txtSaldo.Clear()
        cmbJK.Text = "Pilih Jenis Kelamin"
        cmbKelas.Text = "Pilih Kelas"
        cmbKet.Text = "Pilih Ket"
    End Sub
    Sub tidak_Aktif()
        btn_batal.Enabled = False
        btn_hapus.Enabled = False
        btn_keluar.Enabled = True
        btn_simpan.Enabled = False
        btn_ubah.Enabled = False
        txtAlamat.Enabled = False
        txtNama_Ortu.Enabled = False
        txtNama_Siswa.Enabled = False
        txtNis.Enabled = False
        txtNo_Tlp.Enabled = False
        txtThn_Ajar.Enabled = False
        cmbJK.Enabled = False
        cmbKelas.Enabled = False
        cmbKet.Enabled = False
    End Sub
    Private Sub btn_simpan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_simpan.Click
        If txtNIS.Text = "" Then
            MsgBox("Data Tidak Boleh Kosong", MsgBoxStyle.Critical, "Pesan")
        Else
            If MessageBox.Show("Apakah Yakin Akan Menyimpan...?", "", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
                Try
                    Call Koneksi()
                    CMD = New MySqlCommand("SELECT NIS from data_siswa WHERE NIS= '" & txtNIS.Text & "'", Conn)
                    RD = CMD.ExecuteReader
                    RD.Read()
                    If RD.HasRows Then
                        MsgBox("Maaf, Data dengan kode tersebut telah ada", MsgBoxStyle.Exclamation, "Peringatan")
                    Else
                        Dim simpan As String
                        Call Koneksi()
                        simpan = "INSERT INTO data_siswa (NIS,Nama_Siswa,Jenis_Kelamin,Alamat,Tahun_Ajar,Kelas,Nama_Ortu,No_Telp,Keterangan) VALUES ('" & txtNIS.Text & "','" & txtNama_Siswa.Text & "','" & cmbJK.Text & "','" & txtAlamat.Text & "','" & txtThn_Ajar.Text & "','" & cmbKelas.Text & "','" & txtNama_Ortu.Text & "','" & txtNo_Tlp.Text & "','" & cmbKet.Text & "')"
                        CMD = New MySqlCommand(simpan, Conn)
                        CMD.ExecuteNonQuery()
                        Call TampilDataGrid()
                        Call hapustext()
                        cmbJK.Text = "Pilih Jenis Kelamin"
                        cmbKelas.Text = "Pilih Kelas"
                        cmbKet.Text = "Pilih Keterangan"
                    End If
                Catch ex As Exception
                    MsgBox(ex.ToString, MsgBoxStyle.Critical, "Terjadi Kesalahan")
                End Try
            End If
        End If
    End Sub

    Private Sub btn_hapus_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_hapus.Click
        If txtNIS.Text = "" Then
            MsgBox("Cari Data Yang Akan Dihapus", MsgBoxStyle.Critical, "Pesan")

        Else
            If MessageBox.Show("Apakah Yakin Akan Dihapus...?", "", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
                Try
                    Dim hapus As String
                    Call Koneksi()
                    hapus = "DELETE FROM data_siswa WHERE NIS='" & txtNIS.Text & "'"
                    CMD = New MySqlCommand(hapus, Conn)
                    CMD.ExecuteNonQuery()
                    Call hapustext()
                    Call TampilDataGrid()
                    cmbJK.Text = "Pilih Jenis Kelamin"
                    cmbKelas.Text = "Pilih Kelas"
                    cmbKet.Text = "Pilih Keterangan"
                Catch ex As Exception
                    MsgBox(ex.ToString, MsgBoxStyle.Critical, "Terjadi Kesalahan")
                End Try
            End If
        End If
    End Sub

    Private Sub btn_ubah_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_ubah.Click
        If txtNIS.Text = "" Then
            MsgBox("Cari Data Yang Akan Diubah", MsgBoxStyle.Critical, "Pesan")
        Else
            If MessageBox.Show("Apakah Yakin Akan Ubah...?", "", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
                Try
                    Dim ubah As String
                    Call Koneksi()
                    ubah = "UPDATE data_siswa SET Nama_Siswa='" & txtNama_Siswa.Text & "',Jenis_Kelamin='" & cmbJK.Text & "',Alamat='" & txtAlamat.Text & "',Tahun_Ajar='" & txtThn_Ajar.Text & "',Kelas='" & cmbKelas.Text & "',Nama_Ortu='" & txtNama_Ortu.Text & "',No_Telp='" & txtNo_Tlp.Text & "',Keterangan='" & cmbKet.Text & "' WHERE NIS = '" & txtNIS.Text & "'"
                    CMD = New MySqlCommand(ubah, Conn)
                    CMD.ExecuteNonQuery()
                    Call hapustext()
                    Call TampilDataGrid()
                    cmbJK.Text = "Pilih Jenis Kelamin"
                    cmbKelas.Text = "Pilih Kelas"
                    cmbKet.Text = "Pilih Keterangan"
                Catch ex As Exception
                    MsgBox(ex.ToString, MsgBoxStyle.Critical, "Terjadi Kesalahan")
                End Try
            End If
        End If
    End Sub

    Private Sub btn_keluar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_keluar.Click
        Me.Close()
    End Sub
    Private Sub btnReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReport.Click
        If txtSaldo.Text = "" Then
            MsgBox("Tidak Ada Data Yang Akan Di Cetak", MsgBoxStyle.Information, "Pesan")
        Else
            f_PrintSiswa.Show()
        End If
    End Sub

    Private Sub btn_batal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_batal.Click
        hapustext()
        txtNIS.Focus()
    End Sub

    Private Sub DataGridView1_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        Try
            Dim gridbaris As DataGridViewRow = DataGridView1.Rows(e.RowIndex)
            'databaru()
            txtNIS.Text = gridbaris.Cells(0).Value
            txtNama_Siswa.Text = gridbaris.Cells(1).Value
            cmbJK.Text = gridbaris.Cells(2).Value
            txtAlamat.Text = gridbaris.Cells(3).Value
            txtThn_Ajar.Text = gridbaris.Cells(4).Value
            cmbKelas.Text = gridbaris.Cells(5).Value
            txtNama_Ortu.Text = gridbaris.Cells(6).Value
            txtNo_Tlp.Text = gridbaris.Cells(7).Value
            txtSaldo.Text = gridbaris.Cells(8).Value
            cmbKet.Text = gridbaris.Cells(9).Value
            btn_hapus.Enabled = True
            btn_ubah.Enabled = True
            btn_batal.Enabled = True
            btn_simpan.Enabled = False
        Catch ex As Exception
            MsgBox("Pilih yang ada di dalam tabel")

        End Try
    End Sub

    Private Sub btnBuka_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuka.Click
        txtAlamat.Enabled = True
        txtNama_Ortu.Enabled = True
        txtNama_Siswa.Enabled = True
        txtNIS.Enabled = True
        txtNo_Tlp.Enabled = True
        txtThn_Ajar.Enabled = True
        cmbJK.Enabled = True
        cmbKelas.Enabled = True
        cmbKet.Enabled = True
        btn_keluar.Enabled = True
        btn_simpan.Enabled = True
    End Sub
End Class