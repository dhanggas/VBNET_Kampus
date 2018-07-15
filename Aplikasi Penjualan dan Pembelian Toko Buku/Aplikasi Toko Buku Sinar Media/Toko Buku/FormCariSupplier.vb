Imports System.Data.SqlClient
Public Class FormCariSupplier
    Private Sub IsiListView()
        With ListView1
            .Items.Clear()
            .Columns.Clear()
            .Columns.Add("Kode", 150, HorizontalAlignment.Left)
            .Columns.Add("Nama Supplier", 200, HorizontalAlignment.Left)
            .Columns.Add("Alamat", 150, HorizontalAlignment.Left)
        End With

        Dim qSelect = " SELECT * FROM T_SUPPLIER " _
                & " WHERE Nm_Supplier LIKE '" & TxtKeyword.Text & "%' "

        Dim command As New SqlCommand(qSelect, Koneksi.Koneksi)
        Dim reader As SqlDataReader = command.ExecuteReader
        Dim no As Integer = 0
        Do While reader.Read
            no = no + 1
            Dim myItem As New ListViewItem(reader.Item("Kd_Supplier").ToString)
            myItem.SubItems.Add(reader.Item("Nm_Supplier"))
            myItem.SubItems.Add(reader.Item("Alamat"))
            ListView1.Items.Add(myItem)
        Loop
    End Sub

    Private Sub FormCariSupplier_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Call IsiListView()
    End Sub

    Private Sub ListView1_ItemSelectionChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.ListViewItemSelectionChangedEventArgs) Handles ListView1.ItemSelectionChanged
        kodepanggil = ListView1.FocusedItem.SubItems(0).Text
    End Sub

    Private Sub ListView1_KeyDown(ByVal sender As Object, ByVal e As  System.Windows.Forms.KeyEventArgs) Handles ListView1.KeyDown
        If e.KeyCode = Keys.Enter Then
            kodepanggil = ListView1.FocusedItem.SubItems(0).Text.ToString
            BtnPilih.PerformClick()
        End If
    End Sub


    Private Sub BtnPilih_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnPilih.Click
        With FormTransaksiPembelian
            .TxtKdSupplier.Text = kodepanggil
            .TxtKdBarang.Focus()
        End With

        kodepanggil = ""
        Me.Dispose()

    End Sub

    Private Sub BtnKeluar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnKeluar.Click
        Me.Dispose()
    End Sub

    Private Sub TxtKeyword_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtKeyword.TextChanged

    End Sub
End Class