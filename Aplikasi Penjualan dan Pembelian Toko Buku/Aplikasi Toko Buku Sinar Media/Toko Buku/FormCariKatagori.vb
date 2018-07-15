Imports System.Data.SqlClient
Public Class FormCariKatagori
    Sub isiListView()
        With ListView1
            .FullRowSelect = True
            .Items.Clear()
            .Columns.Clear()
            .Columns.Add("Kode", 60, HorizontalAlignment.Left)
            .Columns.Add("Nama Kategori", 150, HorizontalAlignment.Left)
        End With

        Dim QS = " SELECT * " _
                & " FROM T_KATEGORI " _
                & " WHERE Nm_Katagori LIKE '" & TxtKeyword.Text & "%' "

        Dim cmd As New SqlCommand(QS, Koneksi.Koneksi)
        Dim reader As SqlDataReader = cmd.ExecuteReader()
        Do While reader.Read()
            Dim MyItem As New ListViewItem(reader.Item("Kd_Katagori").ToString)
            MyItem.SubItems.Add(reader.Item("Nm_Katagori").ToString)
            ListView1.Items.Add(MyItem)
        Loop
    End Sub

    Private Sub FormCariKatagori_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call isiListView()
    End Sub

    Private Sub TxtKeyword_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtKeyword.TextChanged
        isiListView()
    End Sub

    Private Sub ListView1_ItemSelectionChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.ListViewItemSelectionChangedEventArgs) Handles ListView1.ItemSelectionChanged
        kodepanggil = ListView1.FocusedItem.SubItems(0).Text

    End Sub

    Private Sub ListView1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ListView1.KeyDown
        If e.KeyCode = Keys.Enter Then
            KodePanggil = ListView1.FocusedItem.SubItems(0).Text.ToString
            BtnPilih.PerformClick()
        End If
    End Sub



    Private Sub BtnPilih_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnPilih.Click
        With FormMasterBarang
            .TxtKdKategori.Text = kodepanggil
            .TxtStock.Focus()
        End With
        kodepanggil = ""
        Me.Dispose()
    End Sub

    Private Sub BtnKeluar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnKeluar.Click
        Me.Dispose()
    End Sub
End Class