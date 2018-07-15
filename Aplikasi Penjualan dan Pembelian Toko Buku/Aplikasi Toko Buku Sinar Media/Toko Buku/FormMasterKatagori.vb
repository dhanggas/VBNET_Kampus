Imports System.Data.SqlClient
Public Class FormMasterKatagori
    Dim KodeAuto As String
    Dim qSelect As String
    Dim qUpdate As String
    Dim qInsert As String
    Dim qDelete As String
    Dim no As Integer
    Dim command As SqlCommand
    Dim reader As SqlDataReader
    Private Sub Auto()
        Dim maxString As String = " "
        Dim maxInteger As Integer = 0
        StrSQL = "Select Max(Kd_Katagori) As Maximum, Count(Kd_Katagori) As Jumlah from T_KATEGORI"
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
        TxtKode.Text = KodeAuto
    End Sub
    Private Sub ListView1_ItemSelectionChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.ListViewItemSelectionChangedEventArgs) Handles ListView1.ItemSelectionChanged
        TxtKode.Text = ListView1.FocusedItem.SubItems(1).Text
        TxtNama.Text = ListView1.FocusedItem.SubItems(2).Text
    End Sub

    Private Sub IsiListView()
        With ListView1
            .Items.Clear()
            .Columns.Clear()
            .Columns.Add("No", 70, HorizontalAlignment.Left)
            .Columns.Add("Kode Katagori", 80, HorizontalAlignment.Left)
            .Columns.Add("Nama Katagori", 200, HorizontalAlignment.Left)
        End With

        qSelect = " SELECT * " _
                    & " FROM T_KATEGORI"

        command = New SqlCommand(qSelect, Koneksi.Koneksi)
        reader = command.ExecuteReader
        no = 0
        Do While reader.Read
            no = no + 1
            Dim myItem As New ListViewItem(no & ".")
            myItem.SubItems.Add(reader.Item("Kd_Katagori"))
            myItem.SubItems.Add(reader.Item("Nm_Katagori"))
            ListView1.Items.Add(myItem)
        Loop
    End Sub

    Private Sub SimpanData()
        'EKSEKUSI SELECT
        qSelect = " SELECT * " _
                & " FROM T_KATEGORI " _
                & " WHERE Kd_Katagori = '" & Trim(TxtKode.Text) & "' "


        command = New SqlCommand(qSelect, Koneksi.Koneksi)
        reader = command.ExecuteReader
        If reader.Read Then

            qUpdate = " UPDATE T_KATEGORI " _
                    & " SET Kd_Katagori =    '" & TxtKode.Text & "', " _
                    & " Nm_Katagori =             '" & TxtNama.Text & "', " _
                    & " WHERE Kd_Katagori =       '" & Trim(TxtKode.Text) & "' "

            command = New SqlCommand(qUpdate, Koneksi.Koneksi)
            command.ExecuteNonQuery()
            MessageBox.Show("KATEGORI : " & vbCrLf & TxtKode.Text & " - " & TxtNama.Text & " ,Telah Terupdate", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information)


        Else
            'AWAL EKSEKUSI INSERT

            Auto()
            qInsert = " INSERT INTO T_KATEGORI " _
                        & "(Kd_Katagori, " _
                        & " Nm_Katagori) " _
                        & " VALUES " _
                        & "('" & Trim(TxtKode.Text) & "', " _
                        & " '" & TxtNama.Text & "') "

            command = New SqlCommand(qInsert, Koneksi.Koneksi)
            command.ExecuteNonQuery()
            MessageBox.Show("KATEGORI : " & TxtNama.Text & vbCrLf & " Telah Tersimpan Dengan Kode : " & KodeAuto, "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub DeleteData()
        qDelete = " DELETE FROM T_KATEGORI " _
                & " WHERE Kd_Katagori = '" & Trim(TxtKode.Text) & "'"

        command = New SqlCommand(qDelete, Koneksi.Koneksi)
        command.ExecuteNonQuery()
        MessageBox.Show("KATEGORI : " & vbCrLf & TxtKode.Text & " - " & TxtNama.Text & vbCrLf & "Telah Terhapus!", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub ClearText()
        Auto()
        TxtNama.Clear()
        TxtNama.Focus()
    End Sub

    Private Sub TmbSimpan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TmbSimpan.Click
        If TxtKode.Text.Length = 0 Then
            MessageBox.Show("Kode Kategori Masih Kosong, Isilah Dengan Jelas", "Perhatian", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            TxtKode.Focus()
            Exit Sub
        ElseIf TxtNama.Text.Length = 0 Then
            MessageBox.Show("Nama Kategori Masih Kosong, Isilah Dengan Jelas", "Perhatian", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            TxtNama.Focus()
            Exit Sub
        Else
            Call SimpanData()
            Call ClearText()
            Call IsiListView()
        End If
    End Sub

    Private Sub TmbKeluar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TmbKeluar.Click
        Me.Dispose()
    End Sub

    Private Sub FormMasterKatagori_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Call IsiListView()
        Call ClearText()
    End Sub
End Class