Imports System.Data.OleDb

Module StockUpdateToZero
    Dim objConnection As New OleDbConnection With {.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;" & _
        "Data Source='" & Application.StartupPath & "\Database\STOCK.accdb'"}


    'SET THE QUANTITY TO ZERO IF QUANTITY IS LESS THAN ZERO
    Public Sub UpdateToZero()
        Try
            Dim strUpdateToZero As String = "UPDATE STOCK " & _
                "SET Quantity_on_hand= " & 0 & " " & _
                "WHERE Quantity_on_hand<" & 0 & ""

            'Open the connection
            objConnection.Open()

            'Create a command
            Dim objUpdateToStock = New OleDbCommand(strUpdateToZero, objConnection)

            'Execute the command
            objUpdateToStock.ExecuteNonQuery()

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
