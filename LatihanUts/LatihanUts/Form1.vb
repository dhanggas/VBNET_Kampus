Imports System
Imports System.Data
Imports System.Data.OleDb
Public Class Form1
    Private strSQL As String
    Private objDataTable As DataTable
    Private objReader As OleDbDataReader
    Private myCon As OleDbConnection
    Private objCommand As OleDbCommand
    Private Const strCon As String = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=E:\ProjectVBNET\KonsepCRUD\mahasiswa.mdb;"


    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        Dispose()

    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Try
            myCon = New OleDbConnection(strCon)
            myCon.Open()
            strSQL = "insert into tbl_mahasiswa (KD_MHS,NM_MHS,ALAMAT_MHS)values('" & txtNim.Text & "','" & txtNama.Text & "','" & txtAlamat.Text & "')"
            objCommand = New OleDbCommand(strSQL, myCon)


            If objCommand.ExecuteNonQuery() Then
                MsgBox("Data Tersimpan")
            Else
                MsgBox("Data Tidak Tersimpan")
            End If

        Catch ex As Exception
            MsgBox(ex)
        End Try
        Call tampilData()
    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            myCon = New OleDbConnection(strCon)
            myCon.Open()
            MsgBox("OK")
            myCon.Close()
            Call tampilData()
        Catch ex As Exception
            MsgBox(ex)
        End Try
    End Sub
    Private Sub tampilData()
        myCon = New OleDbConnection(strCon)
        objDataTable = New DataTable
        myCon.Open()
        strSQL = "select * from tbl_mahasiswa order by NM_MHS"
        objCommand = New OleDbCommand(strSQL, myCon)
        objReader = objCommand.ExecuteReader
        objDataTable.Load(objReader)
        grdMahasiswa.DataSource = objDataTable
        objReader.Close()
        myCon.Close()
    End Sub
End Class
