Imports System.Data.SqlClient
Public Class FormCariBarang
    Private Sub IsiListView()
        With ListView1
            .Items.Clear()
            .Columns.Clear()
            .Columns.Add("Kode", 80, HorizontalAlignment.Left)
            .Columns.Add("Nama Barang", 150, HorizontalAlignment.Left)
            .Columns.Add("Kategori Barang", 100, HorizontalAlignment.Left)
        End With

        Dim qSelect = " SELECT AA.*, BB.* " _
                & " FROM T_BARANG AA, T_KATEGORI BB " _
                & " WHERE AA.Kd_Katagori = BB.Kd_Katagori and Nm_Barang LIKE '" & TxtKeyword.Text & "%' " _
                & " ORDER BY AA.Kd_Barang "

        Dim command As New SqlCommand(qSelect, Koneksi.Koneksi)
        Dim reader As SqlDataReader = command.ExecuteReader
        Do While reader.Read
            Dim myItem As New ListViewItem(reader.Item("Kd_Barang").ToString)
            myItem.SubItems.Add(reader.Item("Nm_Barang"))
            myItem.SubItems.Add(reader.Item("Nm_Katagori"))
            ListView1.Items.Add(myItem)
        Loop
    End Sub
    Private Sub FormCariBarang_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call IsiListView()
    End Sub

    Private Sub TxtKeyword_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtKeyword.TextChanged
        IsiListView()
    End Sub

    Private Sub ListView1_ItemSelectionChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.ListViewItemSelectionChangedEventArgs) Handles ListView1.ItemSelectionChanged
        kodepanggil = ListView1.FocusedItem.SubItems(0).Text
    End Sub

    Private Sub ListView1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ListView1.KeyDown
        If e.KeyCode = Keys.Enter Then
            kodepanggil = ListView1.FocusedItem.SubItems(0).Text.ToString
            BtnPilih.PerformClick()
        End If
    End Sub


    Private Sub BtnPilih_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnPilih.Click
        With FormTransaksiPembelian
            .TxtKdBarang.Text = kodepanggil
        End With
        With FormTransaksiPenjualan
            .TxtKdBarang.Text = kodepanggil
        End With
        kodepanggil = ""
        Me.Dispose()
    End Sub

    Private Sub BtnKeluar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnKeluar.Click
        Me.Dispose()
    End Sub
End Class