Imports System.Data.SqlClient
Public Class FormMasterSupplier
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
        StrSQL = "Select Max(Kd_Supplier) As Maximum, Count(Kd_Supplier) As Jumlah from T_SUPPLIER"
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
            KodeAuto = "SUP00" & maxString
        ElseIf maxString.Length = 2 Then
            KodeAuto = "SUP0" & maxString
        ElseIf maxString.Length = 3 Then
            KodeAuto = "SUP" & maxString
        End If
        TxtKode.Text = KodeAuto
    End Sub

    Private Sub ListView1_ItemSelectionChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.ListViewItemSelectionChangedEventArgs) Handles ListView1.ItemSelectionChanged
        TxtKode.Text = ListView1.FocusedItem.SubItems(1).Text
        TxtNama.Text = ListView1.FocusedItem.SubItems(2).Text
        TxtAlamat.Text = ListView1.FocusedItem.SubItems(3).Text
        TxtTlp.Text = ListView1.FocusedItem.SubItems(4).Text
        TxtEmail.Text = ListView1.FocusedItem.SubItems(5).Text
    End Sub
    Private Sub IsiListView()
        With ListView1
            .Items.Clear()
            .Columns.Clear()
            .Columns.Add("No", 70, HorizontalAlignment.Left)
            .Columns.Add("Kode Supplier", 80, HorizontalAlignment.Left)
            .Columns.Add("Nama Supplier", 200, HorizontalAlignment.Left)
            .Columns.Add("Alamat", 200, HorizontalAlignment.Left)
            .Columns.Add("Telp", 80, HorizontalAlignment.Right)
            .Columns.Add("Email", 100, HorizontalAlignment.Right)
        End With

        qSelect = " SELECT * " _
                    & " FROM T_SUPPLIER"

        command = New SqlCommand(qSelect, Koneksi.Koneksi)
        reader = command.ExecuteReader
        no = 0
        Do While reader.Read
            no = no + 1
            Dim myItem As New ListViewItem(no & ".")
            myItem.SubItems.Add(reader.Item("Kd_Supplier"))
            myItem.SubItems.Add(reader.Item("Nm_Supplier"))
            myItem.SubItems.Add(reader.Item("Alamat"))
            myItem.SubItems.Add(reader.Item("Telp"))
            myItem.SubItems.Add(reader.Item("Email"))
            ListView1.Items.Add(myItem)
        Loop
    End Sub

    Private Sub SimpanData()
        'EKSEKUSI SELECT
        qSelect = " SELECT * " _
                & " FROM T_SUPPLIER " _
                & " WHERE Kd_Supplier = '" & Trim(TxtKode.Text) & "' "


        command = New SqlCommand(qSelect, Koneksi.Koneksi)
        reader = command.ExecuteReader
        If reader.Read Then

            qUpdate = " UPDATE T_SUPPLIER " _
                    & " SET Kd_Supplier =    '" & TxtKode.Text & "', " _
                    & " Nm_Supplier =             '" & TxtNama.Text & "', " _
                    & " Alamat =             '" & TxtAlamat.Text & "', " _
                    & " Telp =                 '" & TxtTlp.Text & "', " _
                    & " Email =             '" & TxtEmail.Text & "', " _
                    & " WHERE Kd_Barang =       '" & Trim(TxtKode.Text) & "' "

            command = New SqlCommand(qUpdate, Koneksi.Koneksi)
            command.ExecuteNonQuery()
            MessageBox.Show("Barang : " & vbCrLf & TxtKode.Text & " - " & TxtNama.Text & " ,Telah Terupdate", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information)


        Else
            'AWAL EKSEKUSI INSERT

            Auto()
            qInsert = " INSERT INTO T_SUPPLIER " _
                        & "(Kd_Supplier, " _
                        & " Nm_Supplier, " _
                        & " Alamat, " _
                        & " Telp, " _
                        & " Email)" _
                        & " VALUES " _
                        & "('" & Trim(TxtKode.Text) & "', " _
                        & " '" & TxtNama.Text & "', " _
                        & " '" & TxtAlamat.Text & "', " _
                        & " '" & TxtTlp.Text & "', " _
                        & " '" & TxtEmail.Text & "') "

            command = New SqlCommand(qInsert, Koneksi.Koneksi)
            command.ExecuteNonQuery()
            MessageBox.Show("SUPPLIER : " & TxtNama.Text & vbCrLf & " Telah Tersimpan Dengan Kode : " & KodeAuto, "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub DeleteData()
        qDelete = " DELETE FROM T_SUPPLIER " _
                & " WHERE Kd_Supplier = '" & Trim(TxtKode.Text) & "'"

        command = New SqlCommand(qDelete, Koneksi.Koneksi)
        command.ExecuteNonQuery()
        MessageBox.Show("SUPPLIER : " & vbCrLf & TxtKode.Text & " - " & TxtNama.Text & vbCrLf & "Telah Terhapus!", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub ClearText()
        Auto()
        TxtNama.Clear()
        TxtAlamat.Text = ""
        TxtTlp.Text = ""
        TxtEmail.Text = ""
    End Sub

    Private Sub BtnSimpan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSimpan.Click
        If TxtKode.Text.Length = 0 Then
            MessageBox.Show("Kode Supplier Masih Kosong, Isilah Dengan Jelas", "Perhatian", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            TxtKode.Focus()
            Exit Sub
        ElseIf TxtNama.Text.Length = 0 Then
            MessageBox.Show("Nama Supplier Masih Kosong, Isilah Dengan Jelas", "Perhatian", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            TxtNama.Focus()
            Exit Sub
        ElseIf TxtAlamat.Text.Length = 0 Then
            MessageBox.Show("Alamat Supplier Masih Kosong, Isilah Dengan Jelas", "Perhatian", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            TxtAlamat.Focus()
            Exit Sub
        ElseIf TxtTlp.Text.Length = 0 Then
            MessageBox.Show("Telepone Supplier Masih Kosong, Isilah Dengan Jelas", "Perhatian", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            TxtTlp.Focus()
            Exit Sub
        ElseIf TxtEmail.Text.Length = 0 Then
            MessageBox.Show("Email Supplier Masih Kosong, Isilah Dengan Jelas", "Perhatian", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            TxtEmail.Focus()
            Exit Sub
        Else
            Call SimpanData()
            Call ClearText()
            Call IsiListView()
        End If
    End Sub

    Private Sub FormMasterSupplier_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Call IsiListView()
        Call ClearText()
    End Sub

    Private Sub BtnKeluar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnKeluar.Click
        Me.Dispose()
    End Sub
End Class