Imports System.Data.SqlClient
Public Class FormTransaksiPenjualan
    Dim KodeAuto As String
    Dim KdBarang As String = ""
    Dim Harga As Double

    Private Sub Auto()
        Dim maxString As String = " "
        Dim maxInteger As Integer = 0
        StrSQL = "Select Max(Kd_Penjualan) As Maximum, Count(Kd_Penjualan) As Jumlah from T_PENJUALAN"
        Dim command As New SqlCommand(StrSQL, Koneksi.Koneksi)
        Dim Reader As SqlDataReader = command.ExecuteReader
        If Reader.Read Then
            If Reader.Item("Jumlah") = 0 Then
                maxString = 0
            Else
                maxString = Reader.Item("Maximum")
            End If
        End If
        Koneksi.Koneksi.Close()
        maxInteger = Microsoft.VisualBasic.Right(maxString, 3)
        maxInteger = maxInteger + 1
        maxString = maxInteger

        If maxString.Length = 1 Then
            KodeAuto = "KAT00" & maxString
        ElseIf maxString.Length = 2 Then
            KodeAuto = "KAT0" & maxString
        ElseIf maxString.Length = 3 Then
            KodeAuto = "KAT" & maxString
        End If
        TxtKdTransBeli.Text = KodeAuto
    End Sub

    Private Sub ClearText()
        DtpTglTransBeli.Text = Format(CDate(Today), "dd MMMM yyyy")
        ListView1.Items.Clear()
        TxtKdBarang.Clear()
        TxtNmBarang.Clear()
        TxtJumlah.Text = ""
        TxtHarga.Text = "0"
        TxtSubTotal.Text = "0"
        TxtTotal.Text = "0"
        TxtPotongan.Text = "0"
        TxtGrandTotal.Text = "0"
    End Sub

    Private Sub SetListViewColumn()
        With ListView1
            .View = View.Details
            .FullRowSelect = True
            .Items.Clear()
            .Columns.Clear()
            .Columns.Add("Kode Barang", 105, HorizontalAlignment.Left)
            .Columns.Add("Nama Barang", 185, HorizontalAlignment.Left)
            .Columns.Add("Harga Beli", 105, HorizontalAlignment.Right)
            .Columns.Add("Jumlah", 56, HorizontalAlignment.Center)
            .Columns.Add("Sub Total", 105, HorizontalAlignment.Right)
        End With
    End Sub

    Private Sub SimpanPembelian()
        Auto()
        If Not KodeAuto.Length = 0 Then

            Dim QInsert As String
            QInsert = " INSERT INTO T_PENJUALAN " _
                    & " (Kd_Penjualan, " _
                    & " Tgl_Penjualan, " _
                    & " Total, " _
                    & " Bayar, " _
                    & " Grand_Total) " _
                    & " VALUES " _
                    & "('" & Trim(TxtKdTransBeli.Text) & "', " _
                    & " '" & DtpTglTransBeli.Text & "', " _
                    & " '" & CDbl(TxtTotal.Text) & "', " _
                    & " '" & CDbl(TxtPotongan.Text) & "', " _
                    & " '" & CDbl(TxtGrandTotal.Text) & "')"

            Dim CmdIns As New SqlCommand(QInsert, Koneksi.Koneksi)
            CmdIns.ExecuteNonQuery()

            For i As Integer = 0 To ListView1.Items.Count - 1

                Dim QInsertDetail As String
                QInsertDetail = " INSERT INTO T_PENJUALAN_DETAIL " _
                            & "(Kd_Penjualan, " _
                            & " Kd_Barang, " _
                            & " Qty, " _
                            & " Harga_Beli, " _
                            & " Sub_Total) " _
                            & " VALUES " _
                            & "('" & Trim(KodeAuto) & "', " _
                            & " '" & ListView1.Items(i).SubItems(0).Text.ToString & "', " _
                            & " '" & CDbl(ListView1.Items(i).SubItems(3).Text.ToString) & "', " _
                            & " '" & CDbl(ListView1.Items(i).SubItems(2).Text.ToString) & "', " _
                            & " '" & CDbl(ListView1.Items(i).SubItems(4).Text.ToString) & "') "

                Dim CmdInsDtl As New SqlCommand(QInsertDetail, Koneksi.Koneksi)
                CmdInsDtl.ExecuteNonQuery()

            Next i

            For a As Integer = 0 To ListView1.Items.Count - 1
                Dim hrglastbuy As Integer = CDbl(ListView1.Items(a).SubItems(2).Text)
                Dim Jumlah_Beli As Integer = CInt(ListView1.Items(a).SubItems(3).Text)
                Dim KdBarang As String = Trim(ListView1.Items(a).SubItems(0).Text)

                Dim QUpdate As String
                QUpdate = " UPDATE T_BARANG " _
                        & " SET Stock = Stock - '" & Jumlah_Beli & "' " _
                        & " WHERE Kd_Barang =  '" & KdBarang & "' "

                Dim CmdUpd As New SqlCommand(QUpdate, Koneksi.Koneksi)
                CmdUpd.ExecuteNonQuery()
            Next
        End If
        MessageBox.Show("Data Penjualan Telah Tersimpan Dengan Kode Transaksi " & KodeAuto & "", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Call ClearText()
    End Sub

    Private Sub BtnKeluar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnKeluar.Click
        Me.Dispose()
    End Sub

    Private Sub BtnSimpan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSimpan.Click
        If Trim(ListView1.Items.Count) = 0 Then
            MessageBox.Show("Tidak ada barang dalam List Pembelian, " & "silahkan masukan data barang yang telah dibeli Dengan Jelas", "Perhatian", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            TxtKdBarang.Focus()
            Exit Sub
        Else
            Call SimpanPembelian()
            If MessageBox.Show("Cetak Laporan...?", "Perhatian", _
                 MessageBoxButtons.YesNo, _
                 MessageBoxIcon.Question) _
                 = Windows.Forms.DialogResult.Yes Then
                FormNota.ShowDialog()
            End If
            With ListView1
                .View = View.Details
                .FullRowSelect = True
                .Items.Clear()
                .Columns.Clear()
            End With
            Auto()
            Call ClearText()
        End If
    End Sub

    Private Sub BtInsertToList_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtInsertToList.Click
        Dim add As Boolean = False

        If TxtKdBarang.Text = "" Or TxtKdBarang.Text.Length = 0 Then
            TxtKdBarang.Focus()
            Exit Sub
        ElseIf TxtJumlah.Text = "0" Or TxtJumlah.Text.Length = 0 Then
            TxtJumlah.Focus()
            Exit Sub
        Else

            Dim i As Integer
            For i = 0 To ListView1.Items.Count - 1
                If (ListView1.Items.Item(i).SubItems(0).Text).ToString = TxtKdBarang.Text.ToUpper Then
                    ListView1.Items.Item(i).SubItems(1).Text = ListView1.Items.Item(i).SubItems(1).Text
                    ListView1.Items.Item(i).SubItems(2).Text = Val(TxtHarga.Text)
                    ListView1.Items.Item(i).SubItems(3).Text += CInt(TxtJumlah.Text)
                    ListView1.Items.Item(i).SubItems(4).Text = Val(CInt(ListView1.Items.Item(i).SubItems(3).Text) * CDbl(ListView1.Items.Item(i).SubItems(2).Text))

                    Dim total As Double
                    For a As Integer = 0 To ListView1.Items.Count - 1
                        total += CDbl(ListView1.Items(a).SubItems(4).Text).ToString
                    Next

                    Dim pot As Double
                    pot = CDbl(TxtPotongan.Text)

                    TxtTotal.Text = Val(total)
                    TxtGrandTotal.Text = Val(total - pot)
                    TxtKdBarang.Clear()
                    TxtNmBarang.Clear()
                    TxtHarga.Text = "0"
                    TxtJumlah.Text = "0"
                    TxtKdBarang.Focus()
                    add = True
                    Exit Sub
                Else
                    add = False
                    'Exit Sub
                End If
            Next i

            If add = False Then
                Dim MyItem As New ListViewItem(TxtKdBarang.Text.ToUpper)
                MyItem.SubItems.Add(TxtNmBarang.Text)
                MyItem.SubItems.Add(TxtHarga.Text)
                MyItem.SubItems.Add(CDbl(TxtJumlah.Text))
                MyItem.SubItems.Add(TxtSubTotal.Text)
                ListView1.Items.Add(MyItem)

                Dim total As Double
                For a As Integer = 0 To ListView1.Items.Count - 1
                    total += CDbl(ListView1.Items(a).SubItems(4).Text).ToString
                Next

                Dim pot As Double
                pot = CDbl(TxtPotongan.Text)

                TxtTotal.Text = Val(total)
                TxtGrandTotal.Text = Val(total - pot)
                TxtKdBarang.Clear()
                TxtNmBarang.Clear()
                TxtHarga.Text = "0"
                TxtJumlah.Text = "0"
                TxtKdBarang.Focus()
            End If
        End If
    End Sub

    Private Sub BtRemoveFromList_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtRemoveFromList.Click
        If Not TxtKdBarang.Text = "" Then
            ListView1.FocusedItem.Remove()
            TxtKdBarang.Text = ""
            TxtNmBarang.Text = ""
            TxtHarga.Text = ""

            Dim total As Double = 0
            For a As Integer = 0 To ListView1.Items.Count - 1
                total += CDbl(ListView1.Items(a).SubItems(4).Text).ToString
            Next

            Dim pot As Double

            pot = CDbl(TxtPotongan.Text)

            TxtTotal.Text = Val(total)
            TxtGrandTotal.Text = Val(total - pot)
        Else
            MessageBox.Show("Silahkan Pilih Data Barang yang akan dibatalkan")
            Exit Sub
        End If
        TxtKdBarang.Focus()
    End Sub

    Private Sub BtFindBarang_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtFindBarang.Click
        FormCariBarang.Show()
    End Sub


    Private Sub TxtKdBarang_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtKdBarang.TextChanged
        TxtKdBarang.CharacterCasing = CharacterCasing.Upper
        Dim QSelect = " SELECT * " _
                    & " FROM T_BARANG " _
                    & " WHERE Kd_Barang = '" & Trim(TxtKdBarang.Text) & "' "

        Dim cmd As New SqlCommand(QSelect, Koneksi.Koneksi)
        Dim reader As SqlDataReader = cmd.ExecuteReader()
        If reader.Read Then
            TxtNmBarang.Text = reader.Item("Nm_Barang").ToString
            TxtHarga.Text = CDbl(reader.Item("Hrg_Jual").ToString)
            TxtJumlah.Text = ""
            TxtJumlah.Focus()
        Else
            TxtNmBarang.Text = ""
            TxtHarga.Text = ""
            TxtJumlah.Text = ""
            TxtKdBarang.Focus()
        End If
    End Sub

    Private Sub TxtJumlah_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtJumlah.KeyPress
        If TxtHarga.Text = "0" Then
            MessageBox.Show("Silahkan Anda Mengisi Harga Terlebih Dahulu", _
                            "Perhatian", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            TxtHarga.Focus()
            Exit Sub
        End If

        If e.KeyChar = Chr(13) Then
            BtInsertToList.PerformClick()
        End If
    End Sub

    Private Sub TxtJumlah_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtJumlah.TextChanged
        If TxtJumlah.TextLength <> 0 And TxtHarga.TextLength <> 0 Then
            Dim subt As Double
            subt = CDbl(TxtHarga.Text) * CDbl(TxtJumlah.Text)
            TxtSubTotal.Text = (Val(subt))
        Else
            TxtJumlah.Text = ""
            TxtJumlah.Focus()
        End If

    End Sub

    Private Sub TxtPotongan_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtPotongan.TextChanged
        Dim grand, total, pot As Double
        Try
            If Not TxtTotal.TextLength = 0 _
            And Not TxtPotongan.TextLength = 0 Then

                total = CDbl(TxtTotal.Text)
                pot = CDbl(TxtPotongan.Text)

                TxtPotongan.Text = Val(pot)
                TxtPotongan.SelectionStart = Len(TxtPotongan.Text)

                grand = pot - total
                TxtGrandTotal.Text = Val(grand)
            Else
                TxtPotongan.Text = "0"
            End If

        Catch ex As Exception
            MessageBox.Show("Angka tidak valid!" & vbCrLf & " Events Error: " & ex.Message, "Cek: TxtBtxt potongan ", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub FormTransaksiPenjualan_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ClearText()
        Auto()
        SetListViewColumn()
        TxtKdBarang.Focus()
    End Sub

    Private Sub ListView1_ItemSelectionChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.ListViewItemSelectionChangedEventArgs) Handles ListView1.ItemSelectionChanged
        TxtKdBarang.Text = ListView1.FocusedItem.SubItems(0).Text
    End Sub

    Private Sub TxtTotal_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtTotal.TextChanged

    End Sub

    Private Sub ListView1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListView1.SelectedIndexChanged

    End Sub

    Private Sub BtnCetak_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCetak.Click
        FormNota.ShowDialog()
    End Sub
End Class