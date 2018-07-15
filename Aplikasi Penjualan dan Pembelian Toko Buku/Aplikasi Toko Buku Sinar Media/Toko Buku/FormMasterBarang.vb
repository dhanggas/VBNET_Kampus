Imports System.Data.SqlClient
Public Class FormMasterBarang
    Dim qSelect As String
    Dim qUpdate As String
    Dim qInsert As String
    Dim qDelete As String
    Dim no As Integer
    Dim KodeAuto As String
    Dim command As SqlCommand
    Dim reader As SqlDataReader
    Private Sub ListView1_ItemSelectionChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.ListViewItemSelectionChangedEventArgs) Handles ListView1.ItemSelectionChanged
        TxtKdBarang.Text = ListView1.FocusedItem.SubItems(1).Text
        TxtNmBarang.Text = ListView1.FocusedItem.SubItems(2).Text
        TxtKdKategori.Text = ListView1.FocusedItem.SubItems(7).Text
        TxtStock.Text = ListView1.FocusedItem.SubItems(4).Text
        TxtHrgPkk.Text = ListView1.FocusedItem.SubItems(5).Text
        TxtHrgJual.Text = ListView1.FocusedItem.SubItems(6).Text
    End Sub

    Private Sub IsiListView()
        With ListView1
            .Items.Clear()
            .Columns.Clear()
            .Columns.Add("No", 70, HorizontalAlignment.Left)
            .Columns.Add("Kode Barang", 80, HorizontalAlignment.Left)
            .Columns.Add("Nama Barang", 150, HorizontalAlignment.Left)
            .Columns.Add("Kategori Barang", 100, HorizontalAlignment.Left)
            .Columns.Add("Stock", 80, HorizontalAlignment.Right)
            .Columns.Add("Harga Dasar", 100, HorizontalAlignment.Right)
            .Columns.Add("Harga Jual", 100, HorizontalAlignment.Right)
            .Columns.Add("Kode Kategori", 0, HorizontalAlignment.Right)
        End With

        qSelect = " SELECT AA.*, BB.* " _
                    & " FROM T_BARANG AA, T_KATEGORI BB " _
                    & " WHERE AA.Kd_Katagori = BB.Kd_Katagori " _
                    & " ORDER BY AA.Kd_Barang "

        command = New SqlCommand(qSelect, Koneksi.Koneksi)
        reader = command.ExecuteReader
        no = 0
        Do While reader.Read
            no = no + 1
            Dim myItem As New ListViewItem(no & ".")
            myItem.SubItems.Add(reader.Item("Kd_Barang"))
            myItem.SubItems.Add(reader.Item("Nm_Barang"))
            myItem.SubItems.Add(reader.Item("Nm_Katagori"))
            myItem.SubItems.Add(reader.Item("Stock"))
            myItem.SubItems.Add(reader.Item("Hrg_Pokok"))
            myItem.SubItems.Add(reader.Item("Hrg_Jual"))
            myItem.SubItems.Add(reader.Item("Kd_Katagori"))
            ListView1.Items.Add(myItem)
        Loop

    End Sub

    Private Sub Auto()
        Dim maxString As String = " "
        Dim maxInteger As Integer = 0
        StrSQL = "Select Max(Kd_Barang) As Maximum, Count(Kd_Barang) As Jumlah from T_BARANG"
        Dim command As New SqlCommand(StrSQL, Koneksi.Koneksi)
        Dim Reader As SqlDataReader = command.ExecuteReader
        If Reader.Read Then
            If Reader.Item("Jumlah") = 0 Then
                maxString = 0
            Else
                maxString = Reader.Item("Maximum")
            End If
        End If
        'Koneksi.Koneksi.Close()
        maxInteger = Microsoft.VisualBasic.Right(maxString, 3)
        maxInteger = maxInteger + 1
        maxString = maxInteger

        If maxString.Length = 1 Then
            KodeAuto = "BRG00" & maxString
        ElseIf maxString.Length = 2 Then
            KodeAuto = "BRG0" & maxString
        ElseIf maxString.Length = 3 Then
            KodeAuto = "BRG" & maxString
        End If
        TxtKdBarang.Text = KodeAuto
    End Sub

    Private Sub SimpanData()
        'EKSEKUSI SELECT
        qSelect = " SELECT * " _
                & " FROM T_BARANG " _
                & " WHERE Kd_Barang = '" & Trim(TxtKdBarang.Text) & "' "


        command = New SqlCommand(qSelect, Koneksi.Koneksi)
        reader = command.ExecuteReader
        If reader.Read Then

            qUpdate = " UPDATE T_BARANG " _
                    & " SET Kd_Barang =    '" & TxtKdKategori.Text & "', " _
                    & " Nm_Barang =             '" & TxtNmBarang.Text & "', " _
                    & " Kd_Katagori =             '" & TxtKdKategori.Text & "', " _
                    & " Stock =                 '" & CInt(TxtStock.Text) & "', " _
                    & " Hrg_Pokok =             '" & CDbl(TxtHrgPkk.Text) & "', " _
                    & " Hrg_Jual =              '" & CDbl(TxtHrgJual.Text) & "' " _
                    & " WHERE Kd_Barang =       '" & Trim(TxtKdBarang.Text) & "' "

            command = New SqlCommand(qUpdate, Koneksi.Koneksi)
            command.ExecuteNonQuery()
            MessageBox.Show("Barang : " & vbCrLf & TxtKdBarang.Text & " - " & TxtNmBarang.Text & " ,Telah Terupdate", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information)


        Else
            'AWAL EKSEKUSI INSERT

            Auto()
            qInsert = " INSERT INTO T_BARANG " _
                        & "(Kd_Barang, " _
                        & " Kd_Katagori, " _
                        & " Nm_Barang, " _
                        & " Stock, " _
                        & " Hrg_Pokok, " _
                        & " Hrg_Jual) " _
                        & " VALUES " _
                        & "('" & Trim(KodeAuto) & "', " _
                        & " '" & Trim(TxtKdKategori.Text) & "', " _
                        & " '" & TxtNmBarang.Text & "', " _
                        & " '" & CDbl(TxtStock.Text) & "', " _
                        & " '" & CDbl(TxtHrgPkk.Text) & "', " _
                        & " '" & CDbl(TxtHrgJual.Text) & "') "

            command = New SqlCommand(qInsert, Koneksi.Koneksi)
            command.ExecuteNonQuery()
            MessageBox.Show("Barang : " & TxtNmBarang.Text & vbCrLf & " Telah Tersimpan Dengan Kode : " & KodeAuto, "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information)
           
        End If
    End Sub

    Private Sub DeleteData()
        qDelete = " DELETE FROM T_BARANG " _
                & " WHERE Kd_Barang = '" & Trim(TxtKdBarang.Text) & "'"

        'Koneksi.Koneksi.Open()
        command = New SqlCommand(qDelete, Koneksi.Koneksi)
        command.ExecuteNonQuery()
        MessageBox.Show("Barang : " & vbCrLf & TxtKdBarang.Text & " - " & TxtNmBarang.Text & vbCrLf & "Telah Terhapus!", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information)
        'Koneksi.Koneksi.Close()
    End Sub

    Private Sub ClearText()
        Auto()
        TxtNmBarang.Clear()
        TxtKdKategori.Clear()
        TxtStock.Text = 0
        TxtHrgPkk.Text = 0
        TxtHrgJual.Text = 0
        TxtNmBarang.Focus()
    End Sub

    Private Sub BtnSimpan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSimpan.Click
        If TxtNmBarang.Text.Length = 0 Then
            MessageBox.Show("Nama Barang Masih Kosong, Isilah Dengan Jelas", "Perhatian", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            TxtNmBarang.Focus()
            Exit Sub
        ElseIf TxtKdBarang.Text.Length = 0 Then
            MessageBox.Show("Barang Masih Kosong, Isilah Dengan Jelas", "Perhatian", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            TxtKdBarang.Focus()
            Exit Sub
        ElseIf TxtStock.Text.Length = 0 Then
            MessageBox.Show("stock Barang Masih Kosong, Isilah Dengan Jelas", "Perhatian", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            TxtStock.Focus()
            Exit Sub
        ElseIf TxtHrgPkk.Text.Length = 0 Then
            MessageBox.Show("Harga Dasar Masih Kosong, Isilah Dengan Jelas",  "Perhatian", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            TxtHrgPkk.Focus()
            Exit Sub
        ElseIf TxtHrgJual.Text.Length = 0 Then
            MessageBox.Show("Harga Jual Masih Kosong, Isilah Dengan Jelas", "Perhatian", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            TxtHrgJual.Focus()
            Exit Sub
        Else
            Call SimpanData()
            Call ClearText()
            Call IsiListView()
        End If
    End Sub


    Private Sub BtnHapus_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnHapus.Click
        If Trim(TxtNmBarang.Text.Length) = 0 Then
            MessageBox.Show("Pilih Data Barang Yang Akan di Delete!", "Perhatian.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            ListView1.Focus()
            Exit Sub
        ElseIf Trim(TxtNmBarang.Text.Length) <> 0 Then
            If (MessageBox.Show("Delete Data Barang " & TxtKdBarang.Text & "?", "Perhatian.", MessageBoxButtons.YesNo, MessageBoxIcon.Question)) = Windows.Forms.DialogResult.Yes Then
                Call DeleteData()
                Call IsiListView()
                Call ClearText()
            Else
                MessageBox.Show("Data Barang " & TxtKdBarang.Text & " Batal Dihapus",  "Perhatian.", MessageBoxButtons.OK, MessageBoxIcon.Information)
                ListView1.Focus()
            End If
        End If
    End Sub

    Private Sub TxtKdKategori_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtKdKategori.TextChanged
        Dim qS = " SELECT * FROM T_KATEGORI " _
                & " WHERE Kd_Katagori = '" & Trim(TxtKdKategori.Text) & "' "
        Dim cmd As New SqlCommand(qS, Koneksi.Koneksi)
        Dim reader As SqlDataReader = cmd.ExecuteReader()
        If reader.Read Then
            TxtNmKategori.Text = reader.Item("Nm_Katagori").ToString
            TxtStock.Focus()
        Else
            TxtNmKategori.Text = ""
        End If
    End Sub

    Private Sub TxtHrgPkk_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtHrgPkk.KeyPress
        Dim key As Integer = Char.ConvertToUtf32(e.KeyChar.ToString(), 0)
        If Not (((key >= 48) And (key <= 57)) Or (key = 8)) Then
            e.Handled = True
        End If
    End Sub

    Private Sub TxtHrgJual_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtHrgJual.KeyPress
        Dim key As Integer = Char.ConvertToUtf32(e.KeyChar.ToString(), 0)
        If Not (((key >= 48) And (key <= 57)) Or (key = 8)) Then
            e.Handled = True
        End If
    End Sub


    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        FormCariKatagori.Show()
    End Sub

    Private Sub FormMasterBarang_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Call IsiListView()
        Call ClearText()
    End Sub

    Private Sub BtnKeluar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnKeluar.Click
        Me.Dispose()
    End Sub

    Private Sub ListView1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListView1.SelectedIndexChanged

    End Sub
End Class