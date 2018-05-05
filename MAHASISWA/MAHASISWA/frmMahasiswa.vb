Imports System
Imports System.Data
Imports System.Data.OleDb

Public Class frmMahasiswa
    Private strSQL As String
    Private objDataTable As DataTable
    Private objReader As OleDbDataReader
    Private objAdapter As OleDbDataAdapter
    Private objDataset As DataSet
    Private myCon As OleDbConnection
    Private objCommand As OleDbCommand
    'Private Const strCon As String = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source=C:\Try\MAHASISWA\Mahasiswa.mdb;"
    Private Const strCon As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\DataMs.accdb"

    Private Sub LockText()
        txtNim.ReadOnly = True
        txtAlamat.ReadOnly = True
        txtJurusan.ReadOnly = True
        txtNama.ReadOnly = True
        txtTelpon.ReadOnly = True
    End Sub

    Private Sub UnLockText()
        txtAlamat.ReadOnly = False
        txtJurusan.ReadOnly = False
        txtNama.ReadOnly = False
        txtNim.ReadOnly = False
        txtTelpon.ReadOnly = False
    End Sub

    Private Sub TextKosong()
        txtAlamat.Text = ""
        txtJurusan.Text = ""
        txtNama.Text = ""
        txtNim.Text = ""
        txtTelpon.Text = ""
    End Sub

    Private Sub ListGrid()
        Try
            myCon = New OleDbConnection(strCon)
            objDataTable = New DataTable
            myCon.Open()
            strSQL = "SELECT * FROM TBL_MAHASISWA ORDER BY NIM_MHS ASC"
            objCommand = New OleDbCommand(strSQL, myCon)
            objReader = objCommand.ExecuteReader(CommandBehavior.Default)
            objDataTable.Load(objReader)
            grdMahasiswa.DataSource = objDataTable
            objCommand.Dispose()
            objReader.Close()
            objCommand = Nothing
            objReader = Nothing
            myCon = Nothing
        Catch ex As Exception
            grdMahasiswa = Nothing
        End Try
    End Sub

    Private Sub frmMahasiswa_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Call TextKosong()
            Call LockText()
            Call ListGrid()
            btnSave.Enabled = False
            btnCancel.Enabled = False
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        Call UnLockText()
        Call TextKosong()
        txtNim.Focus()
        btnAdd.Enabled = False
        btnEdit.Enabled = False
        btnDelete.Enabled = False
        btnExit.Enabled = False
        btnSave.Enabled = True
        btnCancel.Enabled = True
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If txtNim.Text = "" Then
            MsgBox("NIM tidak boleh kosong")
            txtNim.Focus()
        ElseIf txtNama.Text = "" Then
            MsgBox("Nama mahasiswa tidak boleh kosong")
            txtNama.Focus()
        ElseIf txtAlamat.Text = "" Then
            MsgBox("Alamat tidak boleh kosong")
            txtAlamat.Focus()
        ElseIf txtJurusan.Text = "" Then
            MsgBox("Jurusan tidak boleh kosong")
            txtJurusan.Focus()
        ElseIf txtTelpon.Text = "" Then
            MsgBox("Nomor telpon tidak boleh kosong")
            txtTelpon.Focus()
        Else
            myCon = New OleDbConnection(strCon)
            Try
                myCon.Open()
                strSQL = "SELECT * FROM TBL_MAHASISWA WHERE NIM_MHS = '" & Trim(txtNim.Text) & "'"
                objCommand = New OleDbCommand(strSQL, myCon)
                objReader = objCommand.ExecuteReader(CommandBehavior.Default)
                If objReader.HasRows Then
                    MsgBox("Duplicate Data")
                Else
                    objCommand.Dispose()
                    strSQL = "INSERT INTO TBL_MAHASISWA (NIM_MHS,NM_MHS,ALAMAT_MHS,JUR_MHS,TELP_MHS) VALUES('" & txtNim.Text & "','" & txtNama.Text & "','" & txtAlamat.Text & "','" & txtJurusan.Text & "','" & txtTelpon.Text & "')"
                    objCommand = New OleDbCommand(strSQL, myCon)
                    If objCommand.ExecuteNonQuery Then
                        MsgBox("Data telah di simpan")
                    Else
                        MsgBox("Data error di simpan")
                    End If
                    objReader.Close()
                End If
            Catch ex As Exception
                MsgBox("ERROR : " & ex.Message)
            Finally
                myCon.Close()
                objCommand = Nothing
                objReader = Nothing
                myCon = Nothing
                Call ListGrid()
                Call LockText()
                Call TextKosong()
                btnAdd.Enabled = True
                btnEdit.Enabled = True
                btnDelete.Enabled = True
                btnExit.Enabled = True
                btnSave.Enabled = False
                btnCancel.Enabled = False
            End Try
        End If
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Call TextKosong()
        Call LockText()
        btnAdd.Enabled = True
        btnEdit.Enabled = True
        btnDelete.Enabled = True
        btnExit.Enabled = True
        btnSave.Enabled = False
        btnCancel.Enabled = False
        btnEdit.Text = "Edit"
    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        If txtAlamat.Text = "" Or txtJurusan.Text = "" Or txtNama.Text = "" Or txtNim.Text = "" Or txtTelpon.Text = "" Then
            MsgBox("Data kosong")
        Else
            myCon = New OleDbConnection(strCon)
            Try
                myCon.Open()
                strSQL = "DELETE FROM TBL_MAHASISWA WHERE NIM_MHS = '" & Trim(txtNim.Text) & "'"
                objCommand = New OleDbCommand(strSQL, myCon)
                If objCommand.ExecuteNonQuery Then
                    MsgBox("Data telah dihapus")
                Else
                    MsgBox("Hapus data gagal")
                End If
            Catch ex As Exception
                MsgBox("ERROR : " & ex.Message)
            Finally
                myCon.Close()
                objCommand = Nothing
                objReader = Nothing
                myCon = Nothing
                Call ListGrid()
                Call TextKosong()
                Call LockText()
            End Try
        End If
    End Sub

    Private Sub btnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEdit.Click
        If txtAlamat.Text = "" Or txtJurusan.Text = "" Or txtNama.Text = "" Or txtNim.Text = "" Or txtTelpon.Text = "" Then
            MsgBox("Data kosong")
        Else
            If btnEdit.Text = "Edit" Then
                btnEdit.Text = "Update"
                btnAdd.Enabled = False
                btnEdit.Enabled = True
                btnSave.Enabled = False
                btnDelete.Enabled = False
                btnCancel.Enabled = True
                btnExit.Enabled = False
                Call UnLockText()
                txtNim.ReadOnly = True
                txtNama.Focus()
            Else
                myCon = New OleDbConnection(strCon)
                Try
                    myCon.Open()
                    strSQL = "UPDATE TBL_MAHASISWA SET NM_MHS = '" & txtNama.Text & "', ALAMAT_MHS = '" & txtAlamat.Text & "', JUR_MHS = '" & txtJurusan.Text & "', TELP_MHS = '" & txtTelpon.Text & "' WHERE NIM_MHS = '" & txtNim.Text & "'"
                    objCommand = New OleDbCommand(strSQL, myCon)
                    If objCommand.ExecuteNonQuery Then
                        MsgBox("Data telah diupdate")
                    Else
                        MsgBox("Update data gagal")
                    End If
                Catch ex As Exception
                    MsgBox("ERROR : " & ex.Message)
                Finally
                    myCon.Close()
                    objCommand = Nothing
                    objReader = Nothing
                    myCon = Nothing
                    Call ListGrid()
                    Call TextKosong()
                    Call LockText()
                End Try
                btnEdit.Text = "Edit"
                btnAdd.Enabled = True
                btnEdit.Enabled = True
                btnDelete.Enabled = True
                btnExit.Enabled = True
                btnSave.Enabled = False
                btnCancel.Enabled = False
            End If
        End If
    End Sub

    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub

    Private Sub grdMahasiswa_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdMahasiswa.Click
        Try
            Try
                txtNim.Text = Trim(grdMahasiswa.SelectedCells(0).Value)
                txtNama.Text = grdMahasiswa.SelectedCells(1).Value
                txtAlamat.Text = grdMahasiswa.SelectedCells(2).Value
                txtJurusan.Text = grdMahasiswa.SelectedCells(3).Value
                txtTelpon.Text = grdMahasiswa.SelectedCells(4).Value
            Catch ex As Exception

            End Try
        Catch ex As Exception

        End Try
    End Sub

End Class
