Imports System.Data
Imports System.Data.OleDb

Public Class LoginAccess
    Dim strConnectionString As String = "Provider=Microsoft.ACE.OLEDB.12.0;" & _
        "Data Source='" & Application.StartupPath & "\Database\LOGIN.accdb'"
    Private objConnection As New OleDbConnection(strConnectionString)
    Dim objCommand As OleDbCommand
    Private objDataAdapter As OleDbDataAdapter
    Public objDataSet As New DataSet
    Public strExceptionUpdateEntry As String
    Public strExceptionHasConnection As String
    Public strExceptionRunQuery As String


    Public Function HasConnection() As Boolean
        Try
            If objConnection Is Nothing Then
                objConnection = New OleDbConnection(strConnectionString)
            End If

            'Open connection
            objConnection.Open()

            'Close the connection
            objConnection.Close()
            Return True
        Catch ex As Exception
            'Capture error
            strExceptionHasConnection = ex.message

            Return False
            'Make sure connection is closed
            If objConnection.State = ConnectionState.Open Then
                objConnection.Close()
            End If
        End Try
    End Function


    Public Sub RunQuery(Query As String)
        Try
            'Open connection
            objConnection.Open()

            'Create command
            objCommand = New OleDbCommand(Query, objConnection)

            'Fill the dataset
            objDataAdapter = New OleDbDataAdapter(objCommand)
            objDataSet = New DataSet
            objDataAdapter.Fill(objDataSet)

            'Close connection
            objConnection.Close()

            objDataAdapter = Nothing
            objConnection = Nothing
        Catch ex As Exception
            'Capture error
            strExceptionRunQuery = ex.Message

            'Make sure connection is closed
            If objConnection.State = ConnectionState.Open Then
                objConnection.Close()
            End If
        End Try
    End Sub

    Public Sub UpdateEntry(ByVal oldUserName As String, ByVal newUserName As String, ByVal newPassWord As String)
        Try
            If objConnection Is Nothing Then
                objConnection = New OleDbConnection(strConnectionString)
            End If

            Dim strUpdateQuery As String = "UPDATE USERS " & _
                                                      "SET [Username] ='" & newUserName & "', " & _
                                                    "[Password] ='" & newPassWord & "' " & _
                                                    "WHERE [Username]='" & oldUserName & "'"

            objConnection.Open()

            'Create a command
            Dim objCommandUpdateEntry = New OleDbCommand(strUpdateQuery, objConnection)

            'Execute the comand
            objCommandUpdateEntry.ExecuteNonQuery()

            objConnection.Close()
        Catch ex As Exception
            'Capture error
            strExceptionUpdateEntry = ex.Message

            'Make sure that the connection is closed
            If objConnection.State = ConnectionState.Open Then objConnection.Close()
        End Try

    End Sub
End Class