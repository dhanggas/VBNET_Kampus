Imports System.Data.OleDb

Module StoreUpdateToZero
    Dim objConnection As New OleDbConnection With {.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;" & _
        "Data Source='" & Application.StartupPath & "\Database\STORE.accdb'"}


    'SET THE QUANTITY TO ZERO IF QUANTITY IS LESS THAN ZERO
    Public Sub UpdateToZero()
        Try
            Dim strUpdateToZero As String = "UPDATE STORE " & _
                "SET Quantity_on_hand= " & 0 & " " & _
                "WHERE Quantity_on_hand<" & 0 & ""

            'Open the connection
            objConnection.Open()

            'Create a command
            Dim objUpdateToStore = New OleDbCommand(strUpdateToZero, objConnection)

            'Execute the command
            objUpdateToStore.ExecuteNonQuery()

            'Close the connection
            objConnection.Close()

        Catch ex As Exception
            MsgBox(ex.Message)

            'Make sure that the connection is closed
            If objConnection.State = ConnectionState.Open Then
                objConnection.Close()
            End If
        End Try
    End Sub


End Module
