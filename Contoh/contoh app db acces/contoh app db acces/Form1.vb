Imports System.Data.OleDb

Public Class Form1

    Sub kosongkan()
        TextBox1.Clear()
        TextBox2.Clear()
        TextBox3.Clear()
        TextBox4.Clear()

    End Sub

    Sub tampilgrid()
        DA = New OleDbDataAdapter("select * from tblcontoh", conn)
        ds = New DataSet
        DA.Fill(ds, "contoh")
        DataGridView1.DataSource = ds.Tables("contoh")
        DataGridView1.ReadOnly = True

    End Sub
    Private Sub Label4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label4.Click

    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call koneksi()
        Call tampilgrid()

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If TextBox1.Text = "" Or TextBox2.Text = "" Or TextBox3.Text = "" Or TextBox4.Text = "" Then
            MsgBox("data belum lengkap")
            Exit Sub
        Else
            Call koneksi()
            cmd = New OleDbCommand("select * from tblcontoh where nip='" & TextBox1.Text & "'", conn)
            RD = cmd.ExecuteReader
            RD.Read()
            If Not RD.HasRows Then
                Dim simpan As String = "insert into tblcontoh values('" & TextBox1.Text & "','" & TextBox2.Text & "','" & TextBox3.Text & "','" & TextBox4.Text & "')"
                cmd = New OleDbCommand(simpan, conn)
                cmd.ExecuteNonQuery()
            Else
                Dim edit As String = " update tblcontoh set nama='" & TextBox2.Text & "',alamat='" & TextBox3.Text & "',no_hp='" & TextBox4.Text & "' where nip='" & TextBox1.Text & "'"
                cmd = New OleDbCommand(edit, conn)
                cmd.ExecuteNonQuery()
            End If
            Call tampilgrid()
            Call kosongkan()
        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        If TextBox1.Text = "" Then
            MsgBox("nip masih kosong, silakan isi dahulu")
            TextBox1.Focus()
            Exit Sub
        Else
            If MessageBox.Show("yakin akan di hapus ? ", "", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
                Dim hapus As String = " delete * from tblcontoh where nip='" & TextBox1.Text & "'"
                cmd = New OleDbCommand(hapus, conn)
                cmd.ExecuteNonQuery()
                Call tampilgrid()
                Call kosongkan()
            Else
                Call kosongkan()
            End If
        End If
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Call kosongkan()

    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        End
    End Sub

    Private Sub TextBox5_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox5.TextChanged
        cmd = New OleDbCommand(" select * from tblcontoh where nama like '%" & TextBox5.Text & "%'", conn)
        RD = cmd.ExecuteReader
        RD.Read()
        If RD.HasRows Then
            DA = New OleDbDataAdapter(" select * from tblcontoh where nama like '%" & TextBox5.Text & "%'", conn)
            ds = New DataSet
            DA.Fill(ds, "ketemu")
            DataGridView1.DataSource = ds.Tables("ketemu")
            DataGridView1.ReadOnly = True
        End If

    End Sub
End Class
