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

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click

    End Sub

    Private Sub grdMahasiswa_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdMahasiswa.CellContentClick

    End Sub

    Private Sub grdMahasiswa_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdMahasiswa.Click
        Try

            txtNim.Text = IIf(IsDBNull(grdMahasiswa.SelectedCells(0).Value), " ", grdMahasiswa.SelectedCells(0).Value)
            txtNama.Text = IIf(IsDBNull(grdMahasiswa.SelectedCells(1).Value), " ", grdMahasiswa.SelectedCells(1).Value)
            txtJurusan.Text = IIf(IsDBNull(grdMahasiswa.SelectedCells(2).Value), " ", grdMahasiswa.SelectedCells(2).Value)
            txtAlamat.Text = IIf(IsDBNull(grdMahasiswa.SelectedCells(3).Value), " ", grdMahasiswa.SelectedCells(3).Value)
            txtTelpon.Text = IIf(IsDBNull(grdMahasiswa.SelectedCells(4).Value), " ", grdMahasiswa.SelectedCells(4).Value)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEdit.Click
        Try

            If btnEdit.Text = "EDIT" Then
                btnEdit.Text = "UPDATE"
            Else
                myCon = New OleDbConnection(strCon)
                myCon.Open()
                strSQL = "update tbl_mahasiswa set NM_MHS ='" & txtNama.Text & "',ALAMAT_MHS='" & txtAlamat.Text & "',JUR_MHS='" & txtJurusan.Text & "',TELP_MHS='" & txtJurusan.Text & "' WHERE KD_MHS= '" & txtNim.Text & "'"
                objCommand = New OleDbCommand(strSQL, myCon)
                If objCommand.ExecuteNonQuery() Then
                    MsgBox("Data TerUpdate")
                Else
                    MsgBox("Gagal DiUpdate")
                End If


                myCon.Close()
                Call tampilkanData()
                Call TextKosong()
                btnEdit.Text = "EDIT"
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        Try
            myCon = New OleDbConnection(strCon)
            myCon.Open()
            strSQL = "delete from tbl_mahasiswa WHERE KD_MHS= '" & txtNim.Text & "'"
            objCommand = New OleDbCommand(strSQL, myCon)
            If objCommand.ExecuteNonQuery() Then
                MsgBox("Data TerHapus")
            Else
                MsgBox("Gagal DiHapus")
            End If


            myCon.Close()
            Call tampilkanData()
            Call TextKosong()
        Catch ex As Exception

        End Try
    End Sub
End Class
