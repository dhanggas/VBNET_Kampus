Imports System.Data.SqlClient
Public Class FormMasterUser
    Dim KodeAuto As String
    Private Sub Auto()
        Dim maxString As String = " "
        Dim maxInteger As Integer = 0
        StrSQL = "Select Max(Id_Admin) As Maximum, Count(Id_Admin) As Jumlah from T_USER"
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
            KodeAuto = "KMK00" & maxString
        ElseIf maxString.Length = 2 Then
            KodeAuto = "MKM0" & maxString
        ElseIf maxString.Length = 3 Then
            KodeAuto = "MKM" & maxString
        End If
        TextId.Text = KodeAuto
    End Sub
    Private Sub ListData()
        Dim Adapter As New SqlDataAdapter("select Id_Admin as [Id Admin], Nama_Depan as [Nama], user_name as[User Name] " _
                        & " from T_USER", Koneksi.Koneksi)
        Dim dt As New DataTable("pemakai")
        Adapter.Fill(dt)
        grid1.DataSource = dt
        Koneksi.Koneksi.Close()
    End Sub
    Private Sub kosongkan(ByVal xTipe As Int16)
        If xTipe = 0 Then
            txtNameD.Text = ""
            txtNameB.Text = ""
            txtNameU.Text = ""
        End If
        txtPass.Text = ""
        txtConPass.Text = ""
    End Sub
    Private Sub Hapus()
        If Trim(TextId.Text) <> "" Then
            StrSQL = "delete from T_USER where id_admin = '" & TextId.Text & "'"
            Dim command As New SqlCommand(StrSQL, Koneksi.Koneksi)
            command.ExecuteNonQuery()
            Koneksi.Koneksi.Close()
            MessageBox.Show("Data Sudah dihapus", "Penghapusan Sukses", _
                            MessageBoxButtons.OK, MessageBoxIcon.Information)
            ListData()
            kosongkan(0)
            TextId.Focus()
        Else
            MessageBox.Show("Masukkan dulu data yang akan dihapus", _
                            "Tidak ada data yang akan dihapus", MessageBoxButtons.OK, _
                            MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub Simpan()
        Dim oCommand As SqlCommand = New SqlCommand
        If Trim(txtNameD.Text) = "" Then
            MessageBox.Show("Nama depan belum diisi", "Perhatian", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            TextId.Focus()
            Exit Sub
        End If
        If Trim(txtNameB.Text) = "" Then
            MessageBox.Show("Nama belakang belum diisi", "Perhatian", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            TextId.Focus()
            Exit Sub
        End If
        If Trim(txtNameU.Text) = "" Then
            MessageBox.Show("Username belum diisi", "Perhatian", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            TextId.Focus()
            Exit Sub
        End If
        If Trim(txtPass.Text) = "" Then
            MessageBox.Show("Password belum diisi", "Perhatian", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            TextId.Focus()
            Exit Sub
        End If
        If Trim(txtConPass.Text) = "" Then
            MessageBox.Show("Confirmasi Password belum diisi", "Perhatian", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            TextId.Focus()
            Exit Sub
        End If
        If txtPass.Text <> txtConPass.Text Then
            MessageBox.Show("Password tidak sama.", "Perhatian", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtPass.Focus()
            Exit Sub
        End If
        StrSQL = " select Id_Admin from T_USER " _
                 & " where Id_Admin = '" & TextId.Text & "'"
        oCommand.Connection = Koneksi.Koneksi
        oCommand.CommandText = StrSQL
        Dim xReader As SqlDataReader = oCommand.ExecuteReader
        If xReader.HasRows = True Then
            StrSQL = " update T_USER set " _
                   & " Id_Admin = '" & TextId.Text & "', " _
                   & " Nama_Depan = '" & txtNameD.Text & "', " _
                   & " Nama_Belakang = '" & txtNameB.Text & "', " _
                   & " User_name = '" & txtNameU.Text & "' " _
                   & " Password = '" & txtPass.Text & "' " _
                   & " where Id_Admin = '" & TextId.Text & "' "
            oCommand.Connection = Koneksi.Koneksi
            oCommand.CommandText = StrSQL
            oCommand.ExecuteNonQuery()
            Koneksi.Koneksi.Close()
            MessageBox.Show("Data Sudah Update", "Perhatian", MessageBoxButtons.OK, MessageBoxIcon.Information)
            ListData()
            kosongkan(0)
            txtNameD.Focus()
        Else
            StrSQL = "insert into T_USER" _
                   & " (Id_Admin,Nama_Depan ,Nama_Belakang, User_Name, Password) " _
                   & " values('" & TextId.Text & "','" & txtNameD.Text & "', '" & txtNameB.Text & "', '" & txtNameU.Text & "', '" & txtPass.Text & "')"
            oCommand.Connection = Koneksi.Koneksi
            oCommand.CommandText = StrSQL
            oCommand.ExecuteNonQuery()
            Koneksi.Koneksi.Close()
            MessageBox.Show("Data Sudah Disimpan", "Perhatian", MessageBoxButtons.OK, MessageBoxIcon.Information)
            ListData()
            kosongkan(0)
            txtNameD.Focus()
        End If
        xReader.Close()
        Koneksi.Koneksi.Close()
    End Sub
    Private Sub txtNameU_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtNameU.Validating
        Dim oCommand As SqlCommand = New SqlCommand
        If Trim(txtNameU.Text) = "" Then
            kosongkan(0)
        Else
            StrSQL = " select * from T_USER " _
                 & " where Id_Admin = '" & txtNameU.Text & "'"
            oCommand.Connection = Koneksi.Koneksi
            oCommand.CommandText = StrSQL
            Dim xReader As SqlDataReader = oCommand.ExecuteReader
            If xReader.HasRows = True Then
                xReader.Read()
                TextId.Text = xReader("Id_Admin")
                txtNameU.Text = xReader("User_Name")
                txtNameD.Text = xReader("Nama_Depan")
                txtNameB.Text = xReader("Nama_Belakang")
                txtPass.Text = xReader("pass_pemakai")
                txtConPass.Text = xReader("pass_pemakai")
            Else
                kosongkan(1)
            End If
            xReader.Close()
            Koneksi.Koneksi.Close()
        End If
    End Sub
    Private Sub grid1_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grid1.CellClick
        Dim xE As System.ComponentModel.CancelEventArgs
        TextId.Text = grid1.Item(0, grid1.CurrentRow.Index).Value.ToString
        txtNameD.Text = grid1.Item(1, grid1.CurrentRow.Index).Value.ToString
        txtNameU.Text = grid1.Item(2, grid1.CurrentRow.Index).Value.ToString
        txtNameU_Validating(sender, xE)
    End Sub

    Private Sub FormMasterUser_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Auto()
        TextId.Enabled = False
        txtNameD.Focus()
        kosongkan(0)
        ListData()
    End Sub

    Private Sub BtnSimpan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSimpan.Click
        Auto()
        Simpan()
    End Sub

    Private Sub BtnHapus_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnHapus.Click
        If MessageBox.Show("Hapus...?", "Perhatian", _
               MessageBoxButtons.YesNo, _
               MessageBoxIcon.Question) _
               = Windows.Forms.DialogResult.Yes Then
            Hapus()
        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Dispose()
    End Sub
End Class