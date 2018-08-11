Imports System.Data.OleDb
Partial Public Class _Default
    Inherits System.Web.UI.Page
    Private strSQL As String
    Private objDataTable As DataTable
    Private objReader As OleDbDataReader
    Private myCon As OleDbConnection
    Private objCommand As OleDbCommand
    Private Const strCon As String = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=E:\ProjectVBNET\UASTerakhir\dbbarang.mdb;"



    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub btnSimpan_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSimpan.Click
        Try
            Dim hasil, jumlah, harga As Integer
            jumlah = txtJumlah.Text
            harga = txtHarga.Text
            hasil = jumlah * harga



            myCon = New OleDbConnection(strCon)
            myCon.Open()
            strSQL = "insert into tbbarang values('" & txtKode.Text & "','" & txtNama.Text & "','" & txtHarga.Text & "','" & txtJumlah.Text & "','" & hasil & "')"
            objCommand = New OleDbCommand(strSQL, myCon)
           objCommand.ExecuteNonQuery()
            hapus()
        Catch ex As Exception
            MsgBox(ex)
        End Try
    End Sub

    Sub hapus()
        txtKode.Text = ""
        txtNama.Text = ""
        txtHarga.Text = ""
        txtJumlah.Text = ""

    End Sub

    Protected Sub txtHarga_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles txtHarga.TextChanged

    End Sub

    Protected Sub btnReset_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnReset.Click
        hapus()
    End Sub
End Class