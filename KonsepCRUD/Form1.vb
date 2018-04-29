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


    Private Sub Label1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label1.Click

    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            myCon = New OleDbConnection(strCon)
            myCon.Open()
            MsgBox("OK")
            myCon.Close()
        Catch ex As Exception
            MsgBox(ex)
        End Try
        Call tampilkanData()

    End Sub

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
                MsgBox("Gagal Disimpan")
            End If


            myCon.Close()
        Catch ex As Exception
            MsgBox(ex)
        End Try
        Call tampilkanData()
        Call TextKosong()

    End Sub
    Private Sub tampilkanData()
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
    Private Sub TextKosong()
        txtAlamat.Text = ""
        txtJurusan.Text = ""
        txtNama.Text = ""
        txtNim.Text = ""
        txtTelpon.Text = ""
    End Sub

End Class
