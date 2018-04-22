Imports System
Imports System.Data
Imports System.Data.OleDb

Public Class Form1
    Private Const strCon As String = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=E:\1.dhiskar\vbNet\AppSimpan\simpan\mahasiswa.mdm;"
    Private myCon As OleDbConnection

    Private Sub Label1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label1.Click

    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try

        Catch ex As Exception
            MsgBox(ex)
        End Try
    End Sub
End Class
