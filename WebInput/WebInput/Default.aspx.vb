Imports System
Imports System.Data
Imports System.Data.OleDb
Partial Public Class _Default
    Inherits System.Web.UI.Page
    Private strSQL As String
    Private objDataTable As DataTable
    Private objReader As OleDbDataReader
    Private myCon As OleDbConnection
    Private objCommand As OleDbCommand
    Private Const strCon As String = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=E:\ProjectVBNET\WebInput\WebInput\mahasiswa.mdb;"

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Private Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Try
            myCon = New OleDbConnection(strCon)
            myCon.Open()
            strSQL = "insert into tbl_mahasiswa (KD_MHS,NM_MHS,ALAMAT_MHS,JUR_MHS,TELP_MHS)values('" & txtNim.Text & "','" & txtNama.Text & "','" & txtAlamat.Text & "','" & txtJurusan.Text & "','" & txtTelpon.Text & "')"
            objCommand = New OleDbCommand(strSQL, myCon)
            If objCommand.ExecuteNonQuery() Then
                MsgBox("Data Tersimpan")
            Else
                MsgBox("Gagal Disimpan")
            End If


            myCon.Close()
        Catch ex As Exception
            MsgBox(ex)
        End Try
    End Sub
End Class