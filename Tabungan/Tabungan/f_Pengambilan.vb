Imports MySql.Data.MySqlClient
Public Class f_Pengambilan
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
    Private Sub f_Pengambilan_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call Koneksi()
        Call NomorOtomatis()
        Call TampilDataGrid()
        Call batal()
    End Sub
    Sub batal()
        txtNIS.Clear()
        txtJml_Ambil.Clear()
        txtAmbil.Clear()
        txtNominal.Clear()
        lbKelas.Text = "----------"
        lbNama_Siswa.Text = "----------"
        lbSaldo_Akhir.Text = "----------"
        LbSaldo_Awal.Text = "----------"
        txtAmbil.Clear()
    End Sub
    Sub NomorOtomatis()
        txtNo_Ambil.Enabled = False
        Dim rd As MySqlDataReader
        CMD = New MySqlCommand("select * from pengambilan order by No_Ambil desc", Conn)
        Conn.Close()
        Conn.Open()
        rd = CMD.ExecuteReader
        rd.Read()
        If Not rd.HasRows Then
            txtNo_Ambil.Text = "N0AB1407001"
        Else
            txtNo_Ambil.Text = Val(Microsoft.VisualBasic.Mid(rd.Item("No_Ambil").ToString, 9, 3)) + 1

            If Len(txtNo_Ambil.Text) = 1 Then
                txtNo_Ambil.Text = "N0AB140700" & txtNo_Ambil.Text & ""
            ElseIf Len(txtNo_Ambil.Text) = 2 Then
                txtNo_Ambil.Text = "N0AB14070" & txtNo_Ambil.Text & ""
            ElseIf Len(txtNo_Ambil.Text) = 3 Then
                txtNo_Ambil.Text = "N0AB1407" & txtNo_Ambil.Text & ""
            End If
        End If
        Conn.Close()
    End Sub
    Sub TampilDataGrid()
        Modul_Koneksi.Koneksi()
        DA = New MySqlDataAdapter("SELECT * from pengambilan", Conn)
        DS = New DataSet
        DA.Fill(DS, "pengambilan")
        DataGridView1.DataSource = DS.Tables("pengambilan")
        DataGridView1.ReadOnly = True
    End Sub

    
    Private Sub btn_Keluar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Keluar.Click
        Me.Close()
    End Sub

    Private Sub txtJml_Ambil_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtJml_Ambil.TextChanged
        If Val(Me.txtJml_Ambil.Text) > Val(Me.LbSaldo_Awal.Text) Then
            MsgBox("Jumlah Terlalu Besar", MsgBoxStyle.Critical, "Peringatan")
            Call batal()
        Else
            lbSaldo_Akhir.Text = Val(LbSaldo_Awal.Text) - Val(txtJml_Ambil.Text)
            txtAmbil.Text = txtJml_Ambil.Text
        End If
    End Sub
    Private Sub btn_simpan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_simpan.Click
        If txtNIS.Text = "" Then
            MsgBox("Data Tidak Boleh Kosong", MsgBoxStyle.Critical, "Pesan")
        Else
            If MessageBox.Show("Apakah Yakin Akan Menyimpan...?", "", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
                Try
                    Call Koneksi()
                    CMD = New MySqlCommand("SELECT No_Ambil from pengambilan WHERE No_Ambil= '" & txtNo_Ambil.Text & "'", Conn)
                    RD = CMD.ExecuteReader
                    RD.Read()
                    If RD.HasRows Then
                        MsgBox("Maaf, Data dengan kode tersebut telah ada", MsgBoxStyle.Exclamation, "Peringatan")
                    Else
                        Dim simpan As String
                        Call Koneksi()
                        simpan = "INSERT INTO pengambilan (No_Ambil,NIS,Nama_Siswa,Kelas,Saldo_Awal,Jml_Ambil,Saldo_Akhir,Tgl_Ambil) VALUES ('" & txtNo_Ambil.Text & "','" & txtNIS.Text & "','" & lbNama_Siswa.Text & "','" & lbKelas.Text & "','" & LbSaldo_Awal.Text & "','" & txtJml_Ambil.Text & "','" & lbSaldo_Akhir.Text & "','" & Format(DateTimePicker1.Value, "yyyy-MM-dd") & "')"
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

    Private Sub btn_Batal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_Batal.Click
        Call batal()
    End Sub

    Private Sub btnCari_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCari.Click
        f_CariSiswa.Show()
    End Sub

    Private Sub txtJml_Ambil_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtJml_Ambil.KeyPress
        If Not ((e.KeyChar >= "0" And e.KeyChar <= "9") Or e.KeyChar = vbBack) Then e.Handled = True
    End Sub

    Private Sub txtAmbil_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtAmbil.TextChanged
        If Microsoft.VisualBasic.Len(txtAmbil.Text) = 0 Then
            Exit Sub
        End If
        txtAmbil.Text = FormatNumber(txtAmbil.Text, 0)
        txtAmbil.SelectionStart = Microsoft.VisualBasic.Len(txtAmbil.Text)
        txtNominal.Text = Terbilang(txtJml_Ambil.Text)
    End Sub

End Class