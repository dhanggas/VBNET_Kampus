Imports MySql.Data.MySqlClient
Public Class f_Setoran
    Public Function Terbilang(ByVal nilai As Long) As String
        Dim bilangan As String() = {"", "satu", "dua", "tiga", "empat", "lima", _
        "enam", "tujuh", "delapan", "sembilan", "sepuluh", "sebelas"}
        If nilai < 12 Then
            Return " " & bilangan(nilai)
        ElseIf nilai < 20 Then
            Return Terbilang(nilai - 10) & " belas"
        ElseIf nilai < 100 Then
            Return (Terbilang(CInt((nilai \ 10))) & " puluh") + Terbilang(nilai Mod 10)
        ElseIf nilai < 200 Then
            Return " seratus" & Terbilang(nilai - 100)
        ElseIf nilai < 1000 Then
            Return (Terbilang(CInt((nilai \ 100))) & " ratus") + Terbilang(nilai Mod 100)
        ElseIf nilai < 2000 Then
            Return " seribu" & Terbilang(nilai - 1000)
        ElseIf nilai < 1000000 Then
            Return (Terbilang(CInt((nilai \ 1000))) & " ribu") + Terbilang(nilai Mod 1000)
        ElseIf nilai < 1000000000 Then
            Return (Terbilang(CInt((nilai \ 1000000))) & " juta") + Terbilang(nilai Mod 1000000)
        ElseIf nilai < 1000000000000 Then
            Return (Terbilang(CInt((nilai \ 1000000000))) & " milyar") + Terbilang(nilai Mod 1000000000)
        ElseIf nilai < 1000000000000000 Then
            Return (Terbilang(CInt((nilai \ 1000000000000))) & " trilyun") + Terbilang(nilai Mod 1000000000000)
        Else
            Return ""
        End If
    End Function
    Private Sub f_Setoran_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call batal()
        Call Koneksi()
        Call NomorOtomatis()
        Call TampilDataGrid()

    End Sub
    Sub NomorOtomatis()
        txtNo_Setor.Enabled = False
        Dim rd As MySqlDataReader
        CMD = New MySqlCommand("select * from setoran order by No_Setor desc", Conn)
        Conn.Close()
        Conn.Open()
        rd = CMD.ExecuteReader
        rd.Read()
        If Not rd.HasRows Then
            txtNo_Setor.Text = "N0ST1407001"
        Else
            txtNo_Setor.Text = Val(Microsoft.VisualBasic.Mid(rd.Item("No_Setor").ToString, 9, 3)) + 1

            If Len(txtNo_Setor.Text) = 1 Then
                txtNo_Setor.Text = "N0ST140700" & txtNo_Setor.Text & ""
            ElseIf Len(txtNo_Setor.Text) = 2 Then
                txtNo_Setor.Text = "N0ST14070" & txtNo_Setor.Text & ""
            ElseIf Len(txtNo_Setor.Text) = 3 Then
                txtNo_Setor.Text = "N0ST1407" & txtNo_Setor.Text & ""
            End If
        End If
        Conn.Close()
    End Sub
    Sub batal()
        txtNIS.Clear()
        txtJml_Setor.Clear()
        txtSetor.Clear()
        txtNominal.Clear()
        lbKelas.Text = "----------"
        lbNama_Siswa.Text = "----------"
        lbSaldo_Akhir.Text = "----------"
        lbSaldo_Awal.Text = "----------"
    End Sub
    Sub TampilDataGrid()
        Modul_Koneksi.Koneksi()
        DA = New MySqlDataAdapter("SELECT * from setoran", Conn)
        DS = New DataSet
        DA.Fill(DS, "setoran")
        DataGridView1.DataSource = DS.Tables("setoran")
        DataGridView1.ReadOnly = True
    End Sub

    Private Sub txtJml_Setor_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtJml_Setor.TextChanged
        lbSaldo_Akhir.Text = Val(lbSaldo_Awal.Text) + Val(txtJml_Setor.Text)
        txtSetor.Text = txtJml_Setor.Text
    End Sub

    Private Sub btn_simpan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_simpan.Click
        If txtNIS.Text = "" Then
            MsgBox("Data Tidak Boleh Kosong", MsgBoxStyle.Critical, "Pesan")
        Else
            If MessageBox.Show("Apakah Yakin Akan Menyimpan...?", "", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
                Try
                    Call Koneksi()
                    CMD = New MySqlCommand("SELECT No_Setor from setoran WHERE No_Setor= '" & txtNo_Setor.Text & "'", Conn)
                    RD = CMD.ExecuteReader
                    RD.Read()
                    If RD.HasRows Then
                        MsgBox("Maaf, Data dengan kode tersebut telah ada", MsgBoxStyle.Exclamation, "Peringatan")
                    Else
                        Dim simpan As String
                        Call Koneksi()
                        simpan = "INSERT INTO setoran (No_Setor,NIS,Nama_Siswa,Kelas,Saldo_Awal,Jml_Setor,Saldo_Akhir,Tgl_Setor) VALUES ('" & txtNo_Setor.Text & "','" & txtNIS.Text & "','" & lbNama_Siswa.Text & "','" & lbKelas.Text & "','" & lbSaldo_Awal.Text & "','" & txtJml_Setor.Text & "','" & lbSaldo_Akhir.Text & "','" & Format(DateTimePicker1.Value, "yyyy-MM-dd") & "')"
                        CMD = New MySqlCommand(simpan, Conn)
                        CMD.ExecuteNonQuery()
                        Call NomorOtomatis()
                        Call TampilDataGrid()
                        Call Koneksi()
                        Dim UpdatesaldoDataSiswa As String = "UPDATE data_siswa SET Saldo='" & lbSaldo_Akhir.Text & "' WHERE NIS = '" & txtNIS.Text & "'"
                        CMD = New MySqlCommand(UpdatesaldoDataSiswa, Conn)
                        CMD.ExecuteNonQuery()
                        f_DataSiswa.TampilDataGrid()
                        f_CariSiswa.TampilDataGrid()

                        Call batal()
                    End If
                Catch ex As Exception
                    MsgBox(ex.ToString, MsgBoxStyle.Critical, "Terjadi Kesalahan")
                End Try
            End If
        End If
    End Sub

    Private Sub btnCari_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCari.Click
        f_CariSiswa.Show()
    End Sub

    Private Sub btn_Batal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Batal.Click
        Call batal()
    End Sub

    Private Sub btn_Keluar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Keluar.Click
        Me.Close()
    End Sub

    Private Sub txtJml_Setor_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtJml_Setor.KeyPress
        If Not ((e.KeyChar >= "0" And e.KeyChar <= "9") Or e.KeyChar = vbBack) Then e.Handled = True
    End Sub

    Private Sub txtSetor_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSetor.TextChanged
        If Microsoft.VisualBasic.Len(txtSetor.Text) = 0 Then
            Exit Sub
        End If
        txtSetor.Text = FormatNumber(txtSetor.Text, 0)
        txtSetor.SelectionStart = Microsoft.VisualBasic.Len(txtSetor.Text)
        txtNominal.Text = Terbilang(txtJml_Setor.Text)
    End Sub
End Class