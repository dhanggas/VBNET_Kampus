Imports System.Data
Imports System.Data.OleDb

Public Class StockAccess
    Dim strConnection As String = "Provider=Microsoft.ACE.OLEDB.12.0;" & _
        "Data Source='" & Application.StartupPath & "\Database\STOCK.accdb'"
    Dim objConnection As New OleDbConnection(strConnection)
    Dim objCommand As OleDbCommand
    Dim objDataAdapter As OleDbDataAdapter
    Public objDataSet As DataSet

    Dim objSNDataAdapter As OleDbDataAdapter
    Public objBranchLocationDataTable As DataTable
    Public objItemNameDataTable As DataTable
    Public objCustomerNameDataTable As DataTable

    Public strExceptionHasConnection As String
    Public strExceptionRunQuery As String

    'DETAILS OF TABLES VARIABLES
    Public objDataAdapterGetDetails As OleDbDataAdapter
    Public objDataSetGetDetails As DataSet
    Public strExceptionGetDetails As String

    'SEARCHING VARIABLES
    Public objDataSetSearchRecords As DataSet
    Public intNumberOfRecords As Integer
    Public strExceptionSearchRecords As String

    Public objBranchLocationDataTableForSearching As DataTable
    Public objItemNameDataTableForSearching As DataTable
    Public objCustomerNameDataTableForSearching As DataTable
    Public strExceptionGetBranchLocationForSearching As String
    Public strExceptionGetItemNameForSearching As String
    Public strExceptionGetCustomerNameForSearching As String

    'QUERY STATISTICS
    Public intRecordCountGetBranchLocation As Integer
    Public intRecordCountGetItemName As Integer
    Public intRecordCountGetCustomerName As Integer
    Public strExceptionGetBranchLocation As String
    Public strExceptionGetItemName As String
    Public strExceptionGetCustomerName As String

    'ITEM-RECEIVED FORM VARIABLES
    Public strExceptionAddItemReceivedDetails As String
    Public strExceptionAddItemReceivedAndItemDetails As String
    Public strExceptionAddBranchAndItemReceivedDetails As String
    Public strExceptionAddBranchAndItemReceivedAndItemDetails As String
    Public strExceptionDeleteItemReceivedAndDeductFromStock As String
    Public strExceptionDeleteItemReceivedAndNonDeductFromStock As String

    'BRANCH-ISSUER FORM VARIABLES
    Public strExceptionAddItemAsBranchIssuedAndDeductFromStock As String
    Public strExceptionAddItemAsBranchIssuedAndNonDeductFromStock As String
    Public strExceptionAddBranchAndItemAsBranchIssuedAndDeductFromStock As String
    Public strExceptionAddBranchAndItemAsBranchIssuedAndNonDeductFromStock As String
    Public strExceptionDeleteBranchIssuerAndAddToStock As String
    Public strExceptionDeleteBranchIssuerAndDoNotAddToStock As String

    'CAPITALIZED-ISSUER FORM VARIABLES
    Public strExceptionAddItemAsCapitalizedAndDeductFromStock As String
    Public strExceptionAddItemAsCapitalizedAndNonDeductFromStock As String
    Public strExceptionDeleteItemAsCapitalizedAndAddToStock As String
    Public strExceptionDeleteItemAsCapitalizedAndDoNotAddToStock As String

    'EXPENSE-ISSUER FORM VARIABLES
    Public strExceptionAddItemAsExpenseAndDeductFromStock As String
    Public strExceptionAddItemAsExpenseAndNonDeductFromStock As String
    Public strExceptionDeleteItemAsExpenseAndAddToStock As String
    Public strExceptionDeleteItemAsExpenseAndDoNotAddToStock As String

    'SALES-ISSUER FORM VARIABLES
    Public strExceptionDeleteItemAsSalesAndAddToStock As String
    Public strExceptionDeleteItemAsSalesAndDoNotAddToStock As String
    Public strExceptionAddItemAsSaleAndDeductFromStock As String
    Public strExceptionAddItemAsSaleAndNonDeductFromStock As String
    Public strExceptionAddItemAsSaleAndCustomerAndDeductFromStock As String
    Public strExceptionAddItemAsSaleAndCustomerAndNonDeductFromStock As String

    'BRANCH DETAILS REPORT VARIABLES
    Public objBranchDataTableForReporting As DataTable
    Public strExceptionGetBranchDetailsForReport As String
    Public objCustomerDetailsDataTableForReporting As DataTable
    Public objStockDetailsDataTableForReporting As DataTable


    Public Function AutoNumberedTable(ByVal sourceTable As DataTable)
        Dim ResultTable As DataTable = New DataTable

        Dim AutoNumberColumn As New DataColumn
        AutoNumberColumn.DataType = GetType(Integer)
        AutoNumberColumn.AutoIncrement = True
        AutoNumberColumn.AutoIncrementSeed = 1
        AutoNumberColumn.AutoIncrementStep = 1
        ResultTable.Columns.Add(AutoNumberColumn)
        sourceTable.Columns.RemoveAt(0)
        ResultTable.Merge(sourceTable)
        Return ResultTable
    End Function

    Public Function HasConnection() As Boolean
        Try
            'Open the connection
            objConnection.Open()

            'Close the connection
            objConnection.Close()
            Return True
        Catch ex As Exception
            'Capture error
            strExceptionHasConnection = ex.Message

            Return False

            'Make sure that the connection is closed
            If objConnection.State = ConnectionState.Open Then objConnection.Close()
        End Try
    End Function

    Public Sub RunQuery(Query As String)
        Try
            'Open the connection
            objConnection.Open()

            'Create a command
            objCommand = New OleDbCommand(Query, objConnection)

            'Fill the dataset
            objDataAdapter = New OleDbDataAdapter(objCommand)
            objDataSet = New DataSet
            objDataAdapter.Fill(objDataSet)

            'Close the connection
            objConnection.Close()
        Catch ex As Exception
            'Display an error message
            strExceptionRunQuery = ex.Message

            'Make sure that the connection is closed
            If objConnection.State = ConnectionState.Open Then objConnection.Close()
        End Try
    End Sub

    Public Sub RunQueryForSearchingRecords(ByVal query As String)
        Try
            'Open the connection
            objConnection.Open()

            'Create a command
            objCommand = New OleDbCommand(query, objConnection)

            'Fill the dataset
            objDataAdapter = New OleDbDataAdapter(objCommand)
            objDataSetSearchRecords = New DataSet
            intNumberOfRecords = objDataAdapter.Fill(objDataSetSearchRecords)

            'Close the connection
            objConnection.Close()
        Catch ex As Exception
            'Capture the error
            strExceptionSearchRecords = ex.Message

            'Make sure that the connection is closed
            If objConnection.State = ConnectionState.Open Then objConnection.Close()
        End Try
    End Sub



    'METHOD TO RETRIEVE DATA FROM TABLES
    Public Sub RunQueryToGetDetails(Query As String)
        Try
            objConnection.Open()

            'Create a command
            objCommand = New OleDbCommand(Query, objConnection)

            'Fill the dataset
            objDataAdapterGetDetails = New OleDbDataAdapter(objCommand)
            objDataSetGetDetails = New DataSet
            objDataAdapterGetDetails.Fill(objDataSetGetDetails)

            objConnection.Close()
        Catch ex As Exception
            'Capture error message
            strExceptionGetDetails = ex.Message

            'Make sure that the connection is closed
            If objConnection.State = ConnectionState.Open Then
                objConnection.Close()
            End If
        End Try
    End Sub

    Public Sub GetBranchNameForComboBox(ByVal Query As String)
        Try
            objConnection.Open()

            'Create a command
            objCommand = New OleDbCommand(Query, objConnection)

            'Fill the datatable
            objSNDataAdapter = New OleDbDataAdapter(objCommand)
            objBranchLocationDataTable = New DataTable
            objBranchLocationDataTable.Load(objCommand.ExecuteReader)
            Dim row As DataRow = objBranchLocationDataTable.NewRow
            row(0) = "NONE"
            objBranchLocationDataTable.Rows.Clear()
            objBranchLocationDataTable.Rows.Add(row)
            objBranchLocationDataTable.Load(objCommand.ExecuteReader)

            objConnection.Close()
        Catch ex As Exception
            'Capture errors
            strExceptionGetBranchLocation = ex.Message

            'Make sure that the connection is closed
            If objConnection.State = ConnectionState.Open Then objConnection.Close()
        End Try
    End Sub

    Public Sub GetBranchNameForSearchingComboBox(ByVal Query As String)
        Try
            objConnection.Open()

            'Create a command
            objCommand = New OleDbCommand(Query, objConnection)

            'Fill the dataset
            objBranchLocationDataTableForSearching = New DataTable
            objBranchLocationDataTableForSearching.Load(objCommand.ExecuteReader)

            objConnection.Close()
        Catch ex As Exception
            'Capture errors
            strExceptionGetBranchLocationForSearching = ex.Message

            'Make sure that the connection is closed
            If objConnection.State = ConnectionState.Open Then objConnection.Close()
        End Try
    End Sub

    Public Sub GetItemNameForComboBox(ByVal Query As String)
        Try
            'Open the connection
            objConnection.Open()

            'Create a command
            objCommand = New OleDbCommand(Query, objConnection)


            'Fill the datatable
            'objSNDataAdapter = New OleDbDataAdapter(objCommand)
            objItemNameDataTable = New DataTable
            objItemNameDataTable.Load(objCommand.ExecuteReader)
            Dim row As DataRow = objItemNameDataTable.NewRow
            row(0) = "NONE"
            objItemNameDataTable.Rows.Clear()
            objItemNameDataTable.Rows.Add(row)
            objItemNameDataTable.Load(objCommand.ExecuteReader)

            'Close the connection
            objConnection.Close()
        Catch ex As Exception
            'Capture errors
            strExceptionGetItemName = ex.Message

            'Make sure that the connection is closed
            If objConnection.State = ConnectionState.Open Then objConnection.Close()
        End Try
    End Sub

    Public Sub GetItemNameForSearchingComboBox(ByVal Query As String)
        Try
            objConnection.Open()

            'Create a command
            objCommand = New OleDbCommand(Query, objConnection)

            'Fill the dataset
            objItemNameDataTableForSearching = New DataTable
            objItemNameDataTableForSearching.Load(objCommand.ExecuteReader)

            objConnection.Close()
        Catch ex As Exception
            'Capture errors
            strExceptionGetItemNameForSearching = ex.Message

            'Make sure that the connection is closed
            If objConnection.State = ConnectionState.Open Then objConnection.Close()
        End Try
    End Sub

    Public Sub GetCustomerNameForComboBox(ByVal Query As String)
        Try
            'Open the connection
            objConnection.Open()

            'Create a command
            Dim objCommand = New OleDbCommand(Query, objConnection)


            'Fill the datatable
            objSNDataAdapter = New OleDbDataAdapter(objCommand)
            objCustomerNameDataTable = New DataTable
            objCustomerNameDataTable.Load(objCommand.ExecuteReader)
            Dim row As DataRow = objCustomerNameDataTable.NewRow
            row(1) = "NONE"
            objCustomerNameDataTable.Rows.Clear()
            objCustomerNameDataTable.Rows.Add(row)
            objCustomerNameDataTable.Load(objCommand.ExecuteReader)

            'Close the connection
            objConnection.Close()
        Catch ex As Exception
            'Capture error
            strExceptionGetCustomerName = ex.Message

            'Make sure that the connection is closed
            If objConnection.State = ConnectionState.Open Then objConnection.Close()
        End Try
    End Sub

    Public Sub GetCustomerNameForSearchingComboBox(ByVal query As String)
        Try
            objConnection.Open()

            'Create a command
            objCommand = New OleDbCommand(query, objConnection)

            'Fill the dataset
            objCustomerNameDataTableForSearching = New DataTable
            objCustomerNameDataTableForSearching.Load(objCommand.ExecuteReader)

            objConnection.Close()
        Catch ex As Exception
            'Capture errors
            strExceptionGetCustomerNameForSearching = ex.Message

            'Make sure that the connection is closed
            If objConnection.State = ConnectionState.Open Then objConnection.Close()
        End Try
    End Sub

    'Public Sub AddBranchIssuer(ByVal itemName As String, ByVal dateOfSupplied As Date, ByVal receivingBranch As String, ByVal quantity As String)
    '    Try
    '        Dim strAddItemSent As String = "INSERT INTO SENT_TO_BRANCH" & _
    '            "(Item_name, Date_of_supplied, Receiving_branch, Quantity) " & _
    '            "VALUES('" & itemName & "'," & _
    '            "'" & dateOfSupplied & "'," & _
    '            "'" & receivingBranch & "'," & _
    '            "'" & quantity & "')"
    '        Dim strAddBranch As String = "INSERT INTO BRANCH" & _
    '            "(Branch_location) " & _
    '            "VALUES('" & receivingBranch & "')"

    '        'Open the connection
    '        objConnection.Open()

    '        'Create a command
    '        Dim objCommandItemSent = New OleDbCommand(strAddItemSent, objConnection)
    '        Dim objCommandBranch = New OleDbCommand(strAddBranch, objConnection)

    '        'Execute the command to insert into SENT_TO_BRANCH and BRANCH Tables
    '        objCommandItemSent.ExecuteNonQuery()
    '        objCommandBranch.ExecuteNonQuery()

    '        'Close the connection
    '        objConnection.Close()
    '    Catch ex As Exception
    '        'Display an error message
    '        MessageBox.Show(ex.Message, My.Application.Info.Title)

    '        'Make sure that the connection is closed
    '        If objConnection.State = ConnectionState.Open Then objConnection.Close()
    '    End Try
    'End Sub







    'REPORTING METHODS



    'GET BRANCH DETAILS FOR REPORT

    Public Sub GetBranchDetailsForReport()
        Try
            Dim strCommand As String = "SELECT * FROM BRANCH ORDER BY Branch_location"

            objConnection.Open()

            'Create a command
            objCommand = New OleDbCommand(strCommand, objConnection)

            'Fill the datatable
            objBranchDataTableForReporting = New DataTable
            objBranchDataTableForReporting.Load(objCommand.ExecuteReader)

            objConnection.Close()
        Catch ex As Exception
            'Capture errors
            'strExceptionGetBranchDetailsForReport = ex.Message
            MsgBox(ex.Message)

            'Make sure that the connection is closed
            If objConnection.State = ConnectionState.Open Then objConnection.Close()
        End Try
    End Sub


    'GET QUANTITY ON STORE DETAILS FOR REPORT
    Public Sub GetCustomerDetailsForReport()
        Try
            Dim strCommand As String = "SELECT * FROM Customer ORDER BY Customer_name"

            objConnection.Open()

            'Create a command
            objCommand = New OleDbCommand(strCommand, objConnection)

            'Fill the datatable
            objCustomerDetailsDataTableForReporting = New DataTable
            objCustomerDetailsDataTableForReporting.Load(objCommand.ExecuteReader)

            objConnection.Close()
        Catch ex As Exception
            'Capture errors
            'strExceptionGetBranchDetailsForReport = ex.Message
            MsgBox(ex.Message)

            'Make sure that the connection is closed
            If objConnection.State = ConnectionState.Open Then objConnection.Close()
        End Try
    End Sub

    'GET QUANTITY ON STOCK DETAILS FOR REPORT
    Public Sub GetStockkDetailsForReport()
        Try
            Dim strCommand As String = "SELECT * FROM STOCK ORDER BY Item_name"

            objConnection.Open()

            'Create a command
            objCommand = New OleDbCommand(strCommand, objConnection)

            'Fill the datatable
            objStockDetailsDataTableForReporting = New DataTable
            objStockDetailsDataTableForReporting.Load(objCommand.ExecuteReader)

            objConnection.Close()
        Catch ex As Exception
            'Capture errors
            'strExceptionGetBranchDetailsForReport = ex.Message
            MsgBox(ex.Message)

            'Make sure that the connection is closed
            If objConnection.State = ConnectionState.Open Then objConnection.Close()
        End Try
    End Sub




    'ITEM RECEIVED FORM METHODS

    'ADD ITEM RECEIVED DETAILS ONLY
    Public Sub AddItemReceived(ByVal itemName As String, ByVal dateOfReceived As Date, ByVal supplyingBranch As String, ByVal quantity As String)
        Try
            Dim strAddItemReceived As String = "INSERT INTO RECEIVED_FROM_BRANCH(Item_name, Date_of_received, Supplying_Branch, Quantity) " & _
                            "VALUES(" & _
                            "'" & itemName & "'," & _
                            "#" & dateOfReceived & "#," & _
                            "'" & supplyingBranch & "'," & _
                            "'" & quantity & "')"

            Dim strAddItemQuantityToStock As String = "UPDATE STOCK " & _
                "SET Quantity_on_hand = (Quantity_on_hand + " & quantity & ") " & _
                "WHERE Item_name = '" & itemName & "'"

            'Open the connection
            objConnection.Open()

            Dim objCommandAddItemReceived = New OleDbCommand(strAddItemReceived, objConnection)
            Dim objCommandAddItemQuantityToStock = New OleDbCommand(strAddItemQuantityToStock, objConnection)

            objCommandAddItemReceived.ExecuteNonQuery()
            objCommandAddItemQuantityToStock.ExecuteNonQuery()

            'Close the connection
            objConnection.Close()
        Catch ex As Exception
            strExceptionAddItemReceivedDetails = ex.Message

            'Make sure that the connection is closed
            If objConnection.State = ConnectionState.Open Then objConnection.Close()
        End Try

    End Sub

    'ADD ITEM RECEIVED AND ITEM DETAILS
    Public Sub AddItemReceivedAndItem(ByVal itemName As String, ByVal dateOfReceived As Date, ByVal supplyingBranch As String, ByVal quantity As String)
        Try
            Dim strAddItem As String = "INSERT INTO STOCK " & _
            "VALUES(" & _
            "'" & itemName & "'," & _
            "'" & quantity & "')"

            Dim strAddItemReceived As String = "INSERT INTO RECEIVED_FROM_BRANCH(Item_name, Date_of_received, Supplying_Branch, Quantity) " & _
                            "VALUES(" & _
                            "'" & itemName & "'," & _
                            "#" & dateOfReceived & "#," & _
                            "'" & supplyingBranch & "'," & _
                            "'" & quantity & "')"

            'Open the connection
            objConnection.Open()

            Dim objCommandAddItem = New OleDbCommand(strAddItem, objConnection)
            Dim objCommandAddItemReceived = New OleDbCommand(strAddItemReceived, objConnection)

            objCommandAddItem.ExecuteNonQuery()
            objCommandAddItemReceived.ExecuteNonQuery()

            'Close the connection
            objConnection.Close()
        Catch ex As Exception
            strExceptionAddItemReceivedAndItemDetails = ex.Message

            'Make sure that the connection is closed
            If objConnection.State = ConnectionState.Open Then objConnection.Close()
        End Try

    End Sub

    'ADD BRANCH AND ITEM RECEIVED DETAILS
    Public Sub AddBranchAndItemReceived(ByVal itemName As String, ByVal dateOfReceived As Date, ByVal supplyingBranch As String, ByVal quantity As String)
        Try
            Dim strAddBranch As String = "INSERT INTO BRANCH " & _
                "VALUES(" & _
                "'" & supplyingBranch & "')"

            Dim strAddItemReceived As String = "INSERT INTO RECEIVED_FROM_BRANCH(Item_name, Date_of_received, Supplying_Branch, Quantity) " & _
                            "VALUES(" & _
                            "'" & itemName & "'," & _
                            "#" & dateOfReceived & "#," & _
                            "'" & supplyingBranch & "'," & _
                            "'" & quantity & "')"

            Dim strAddItemQuantityToStock As String = "UPDATE STOCK " & _
              "SET Quantity_on_hand = (Quantity_on_hand + " & quantity & ") " & _
              "WHERE Item_name = '" & itemName & "'"

            'Open the connection
            objConnection.Open()

            Dim objCommandAddBranch = New OleDbCommand(strAddBranch, objConnection)
            Dim objCommandAddItemReceived = New OleDbCommand(strAddItemReceived, objConnection)
            Dim objCommandAddItemQuantityToStock = New OleDbCommand(strAddItemQuantityToStock, objConnection)

            objCommandAddBranch.ExecuteNonQuery()
            objCommandAddItemReceived.ExecuteNonQuery()
            objCommandAddItemQuantityToStock.ExecuteNonQuery()

            'Close the connection
            objConnection.Close()
        Catch ex As Exception
            strExceptionAddBranchAndItemReceivedAndItemDetails = ex.Message

            'Make sure that the connection is closed
            If objConnection.State = ConnectionState.Open Then objConnection.Close()
        End Try

    End Sub

    'ADD BRANCH AND ITEM RECEIVED AND ITEM DETAILS
    Public Sub AddBranchAndItemReceivedAndItem(ByVal itemName As String, ByVal dateOfReceived As Date, ByVal supplyingBranch As String, ByVal quantity As String)
        Try
            Dim strAddBranch As String = "INSERT INTO BRANCH " & _
                "VALUES(" & _
                "'" & supplyingBranch & "')"

            Dim strAddItem As String = "INSERT INTO STOCK " & _
            "VALUES(" & _
            "'" & itemName & "'," & _
            "'" & quantity & "')"

            Dim strAddItemReceived As String = "INSERT INTO RECEIVED_FROM_BRANCH(Item_name, Date_of_received, Supplying_Branch, Quantity) " & _
                            "VALUES(" & _
                            "'" & itemName & "'," & _
                            "#" & dateOfReceived & "#," & _
                            "'" & supplyingBranch & "'," & _
                            "'" & quantity & "')"

            'Open the connection
            objConnection.Open()

            Dim objCommandAddBranch = New OleDbCommand(strAddBranch, objConnection)
            Dim objCommandAddItem = New OleDbCommand(strAddItem, objConnection)
            Dim objCommandAddItemReceived = New OleDbCommand(strAddItemReceived, objConnection)

            objCommandAddBranch.ExecuteNonQuery()
            objCommandAddItem.ExecuteNonQuery()
            objCommandAddItemReceived.ExecuteNonQuery()

            'Close the connection
            objConnection.Close()
        Catch ex As Exception
            strExceptionAddBranchAndItemReceivedAndItemDetails = ex.Message

            'Make sure that the connection is closed
            If objConnection.State = ConnectionState.Open Then objConnection.Close()
        End Try

    End Sub

    'DELETE THE INFORMATION FOR ITEM RECEIVED AND DEDUCT THE QUANTITY OF ITEM FROM STOCK AS WELL
    Public Sub DeleteItemReceivedAndDeductFromStock(ByVal itemName As String, ByVal dateOfReceived As Date, ByVal supplyingBranch As String, ByVal quantity As String)
        Try
            Dim strDeleteItemReceived As String = "DELETE * FROM RECEIVED_FROM_BRANCH " & _
                "WHERE Item_name='" & itemName & "' " & _
                "AND Date_of_received=#" & dateOfReceived & "#" & _
                "AND Supplying_branch='" & supplyingBranch & "'"
            Dim strSubtractItemFromStock As String = "UPDATE STOCK " & _
                "SET Quantity_on_hand=(Quantity_on_hand - " & quantity & ") " & _
                "WHERE Item_name='" & itemName & "'"

            'Open the connection
            objConnection.Open()

            Dim objCommandDeleteItemReceived = New OleDbCommand(strDeleteItemReceived, objConnection)
            Dim objCommandSubtractItemFromStock = New OleDbCommand(strSubtractItemFromStock, objConnection)

            'Execute 
            objCommandDeleteItemReceived.ExecuteNonQuery()
            objCommandSubtractItemFromStock.ExecuteNonQuery()

            'Close the connection
            objConnection.Close()
        Catch ex As Exception
            strExceptionDeleteItemReceivedAndDeductFromStock = ex.Message

            'Make sure the connection is closed
            If objConnection.State = ConnectionState.Open Then objConnection.Close()
        End Try
    End Sub

    'DELETE THE INFORMATION FOR ITEM RECEIVED AND DO NOT DEDUCT THE QUANTITY OF ITEM FROM STOCK
    Public Sub DeleteItemReceivedAndNonDeductFromStock(ByVal itemName As String, ByVal dateOfReceived As Date, ByVal supplyingBranch As String)
        Try
            Dim strDeleteItemReceived As String = "DELETE * FROM RECEIVED_FROM_BRANCH " & _
                "WHERE Item_name='" & itemName & "' " & _
                "AND Date_of_received=#" & dateOfReceived & "#" & _
                "AND Supplying_branch='" & supplyingBranch & "'"

            'Open the connection
            objConnection.Open()

            Dim objCommandDeleteItemReceived = New OleDbCommand(strDeleteItemReceived, objConnection)

            'Execute 
            objCommandDeleteItemReceived.ExecuteNonQuery()

            'Close the connection
            objConnection.Close()
        Catch ex As Exception
            strExceptionDeleteItemReceivedAndNonDeductFromStock = ex.Message

            'Make sure the connection is closed
            If objConnection.State = ConnectionState.Open Then objConnection.Close()
        End Try
    End Sub







    'BRANCH-ISSUER FORM METHODS

    'ADD NEW INFORMATION FOR BRANCH AND BRANCH ISSUE AND DEDUCT THE QUANTITY OF ITEM FROM STOCK AS WELL
    Public Sub AddBranchAndBranchIssuerAndDeductFromStock(ByVal itemName As String, ByVal dateOfSupplied As Date, ByVal receivingBranch As String, ByVal quantity As String)
        Try
            Dim strAddBranch As String = "INSERT INTO BRANCH " & _
                "VALUES('" & receivingBranch & "')"

            Dim strAddBranchIssuer As String = "INSERT INTO SENT_TO_BRANCH" & _
                "(Item_name, Date_of_supplied, Receiving_branch, Quantity) " & _
                "VALUES('" & itemName & "'," & _
                "#" & dateOfSupplied & "#," & _
                "'" & receivingBranch & "'," & _
                "'" & quantity & "')"

            Dim strSubtractItemQuantityFromStock As String = "UPDATE STOCK " & _
                "SET Quantity_on_hand= (Quantity_on_hand - " & quantity & ") " & _
                "WHERE Item_name= '" & itemName & "'"


            'Open the connection
            objConnection.Open()

            'Create a command
            Dim objCommandAddBranch = New OleDbCommand(strAddBranch, objConnection)
            Dim objCommandAddBranchIssuer = New OleDbCommand(strAddBranchIssuer, objConnection)
            Dim objCommandItemSubtractedFromStock = New OleDbCommand(strSubtractItemQuantityFromStock, objConnection)

            'Execute the command
            objCommandAddBranch.ExecuteNonQuery()
            objCommandAddBranchIssuer.ExecuteNonQuery()
            objCommandItemSubtractedFromStock.ExecuteNonQuery()

            'Close the connection
            objConnection.Close()
        Catch ex As Exception
            'Display an error message
            strExceptionAddBranchAndItemAsBranchIssuedAndDeductFromStock = ex.Message

            'Make sure that the connection is closed
            If objConnection.State = ConnectionState.Open Then objConnection.Close()
        End Try
    End Sub

    'ADD NEW INFORMATION FOR BRANCH AND BRANCH ISSUE AND DEDUCT THE QUANTITY OF ITEM FROM STOCK AS WELL
    Public Sub AddBranchAndBranchIssuerAndNonDeductFromStock(ByVal itemName As String, ByVal dateOfSupplied As Date, ByVal receivingBranch As String, ByVal quantity As String)
        Try
            Dim strAddBranch As String = "INSERT INTO BRANCH " & _
                "VALUES('" & receivingBranch & "')"

            Dim strAddBranchIssuer As String = "INSERT INTO SENT_TO_BRANCH" & _
                "(Item_name, Date_of_supplied, Receiving_branch, Quantity) " & _
                "VALUES('" & itemName & "'," & _
                "#" & dateOfSupplied & "#," & _
                "'" & receivingBranch & "'," & _
                "'" & quantity & "')"

            'Open the connection
            objConnection.Open()

            'Create a command
            Dim objCommandAddBranch = New OleDbCommand(strAddBranch, objConnection)
            Dim objCommandAddBranchIssuer = New OleDbCommand(strAddBranchIssuer, objConnection)

            'Execute the command
            objCommandAddBranch.ExecuteNonQuery()
            objCommandAddBranchIssuer.ExecuteNonQuery()

            'Close the connection
            objConnection.Close()
        Catch ex As Exception
            'Display an error message
            strExceptionAddBranchAndItemAsBranchIssuedAndNonDeductFromStock = ex.Message

            'Make sure that the connection is closed
            If objConnection.State = ConnectionState.Open Then objConnection.Close()
        End Try
    End Sub


    'ADD NEW INFORMATION FOR BRANCH ISSUE AND DEDUCT THE QUANTITY OF ITEM FROM STOCK AS WELL
    Public Sub AddBranchIssuerAndDeductFromStock(ByVal itemName As String, ByVal dateOfSupplied As Date, ByVal receivingBranch As String, ByVal quantity As String)
        Try
            Dim strAddBranchIssuer As String = "INSERT INTO SENT_TO_BRANCH" & _
                "(Item_name, Date_of_supplied, Receiving_branch, Quantity) " & _
                "VALUES('" & itemName & "'," & _
                "#" & dateOfSupplied & "#," & _
                "'" & receivingBranch & "'," & _
                "'" & quantity & "')"

            Dim strSubtractItemQuantityFromStock As String = "UPDATE STOCK " & _
                "SET Quantity_on_hand= (Quantity_on_hand - " & quantity & ") " & _
                "WHERE Item_name= '" & itemName & "'"


            'Open the connection
            objConnection.Open()

            'Create a command
            Dim objCommandAddBranchIssuer = New OleDbCommand(strAddBranchIssuer, objConnection)
            Dim objCommandItemSubtractedFromStock = New OleDbCommand(strSubtractItemQuantityFromStock, objConnection)

            'Execute the command
            objCommandAddBranchIssuer.ExecuteNonQuery()
            objCommandItemSubtractedFromStock.ExecuteNonQuery()

            'Close the connection
            objConnection.Close()
        Catch ex As Exception
            'Display an error message
            strExceptionAddItemAsBranchIssuedAndDeductFromStock = ex.Message

            'Make sure that the connection is closed
            If objConnection.State = ConnectionState.Open Then objConnection.Close()
        End Try
    End Sub


    'ADD NEW INFORMATION FOR BRANCH ISSUE AND DO NOT DEDUCT THE QUANTITY OF ITEM FROM STOCK AS WELL
    Public Sub AddBranchIssuerAndNonDeductFromStock(ByVal itemName As String, ByVal dateOfSupplied As Date, ByVal receivingBranch As String, ByVal quantity As String)
        Try
            Dim strAddBranchIssuer As String = "INSERT INTO SENT_TO_BRANCH" & _
                "(Item_name, Date_of_supplied, Receiving_branch, Quantity) " & _
                "VALUES('" & itemName & "'," & _
                "#" & dateOfSupplied & "#," & _
                "'" & receivingBranch & "'," & _
                "'" & quantity & "')"

            'Open the connection
            objConnection.Open()

            'Create a command
            Dim objCommandAddBranchIssuer = New OleDbCommand(strAddBranchIssuer, objConnection)

            'Execute the command
            objCommandAddBranchIssuer.ExecuteNonQuery()

            'Close the connection
            objConnection.Close()
        Catch ex As Exception
            'Display an error message
            strExceptionAddItemAsBranchIssuedAndNonDeductFromStock = ex.Message

            'Make sure that the connection is closed
            If objConnection.State = ConnectionState.Open Then objConnection.Close()
        End Try
    End Sub


    'DELETE THE INFORMATION FOR BRANCH ISSUER AND DO NOT ADD THE QUANTITY OF ITEM TO STOCK
    Public Sub DeleteBranchIssuerAndDoNotAddToStock(ByVal itemName As String, ByVal dateOfSupplied As Date, ByVal receivingBranch As String)
        Try
            Dim strDeleteBranchIssuer As String = "DELETE FROM SENT_TO_BRANCH " & _
                "WHERE Item_name='" & itemName & "' " & _
                "AND Date_of_supplied=#" & dateOfSupplied & "#" & _
                "AND Receiving_branch='" & receivingBranch & "'"

            'Open the connection
            objConnection.Open()

            Dim objCommandDeleteBranchIssuer = New OleDbCommand(strDeleteBranchIssuer, objConnection)

            'Execute 
            objCommandDeleteBranchIssuer.ExecuteNonQuery()

            'Close the connection
            objConnection.Close()
        Catch ex As Exception
            strExceptionDeleteBranchIssuerAndDoNotAddToStock = ex.Message

            'Make sure the connection is closed
            If objConnection.State = ConnectionState.Open Then objConnection.Close()
        End Try
    End Sub

    'DELETE THE INFORMATION FOR BRANCH ISSUER AND ADD THE QUANTITY OF ITEM TO STOCK AS WELL
    Public Sub DeleteBranchIssuerAndAddToStock(ByVal itemName As String, ByVal dateOfSupplied As Date, ByVal receivingBranch As String, ByVal quantity As String)
        Try
            Dim strDeleteBranchIssuer As String = "DELETE FROM SENT_TO_BRANCH " & _
                "WHERE Item_name='" & itemName & "' " & _
                "AND Date_of_supplied=#" & dateOfSupplied & "#" & _
                "AND Receiving_branch='" & receivingBranch & "'"


            Dim strAddItemToStock As String = "UPDATE STOCK " & _
                "SET Quantity_on_hand=(Quantity_on_hand + " & quantity & ") " & _
                "WHERE Item_name='" & itemName & "'"

            'Open the connection
            objConnection.Open()

            Dim objCommandDeleteBranchIssuer = New OleDbCommand(strDeleteBranchIssuer, objConnection)
            Dim objCommandAddItemToStock = New OleDbCommand(strAddItemToStock, objConnection)


            'Execute 
            objCommandDeleteBranchIssuer.ExecuteNonQuery()
            objCommandAddItemToStock.ExecuteNonQuery()

            'Close the connection
            objConnection.Close()
        Catch ex As Exception
            strExceptionDeleteBranchIssuerAndAddToStock = ex.Message

            'Make sure the connection is closed
            If objConnection.State = ConnectionState.Open Then objConnection.Close()
        End Try
    End Sub








    'CAPITALIZED ISSUER FORM METHODS

    'ADD NEW INFORMATION FOR CAPITALIZED ISSUE AND DEDUCT THE QUANTITY OF ITEM FROM STOCK AS WELL
    Public Sub AddCapitalizedIssuerAndDeductFromStock(ByVal itemName As String, ByVal dateOfUsed As Date, ByVal quantity As String, ByVal reason As String)
        Try
            Dim strAddItemAsCapitalized As String = "INSERT INTO CAPITALIZED" & _
                "(Item_name, Date_of_used, Quantity, Reason) " & _
                "VALUES('" & itemName & "'," & _
                "'" & dateOfUsed & "'," & _
                "'" & quantity & "'," & _
                "'" & reason & "')"

            Dim strSubtractItemQuantityFromStock As String = "UPDATE STOCK " & _
                "SET Quantity_on_hand= (Quantity_on_hand - " & quantity & ") " & _
                "WHERE Item_name= '" & itemName & "'"


            'Open the connection
            objConnection.Open()

            'Create a command
            Dim objCommandItemAsCapitalized = New OleDbCommand(strAddItemAsCapitalized, objConnection)
            Dim objCommandItemSubtractedFromStock = New OleDbCommand(strSubtractItemQuantityFromStock, objConnection)

            'Execute the command
            objCommandItemAsCapitalized.ExecuteNonQuery()
            objCommandItemSubtractedFromStock.ExecuteNonQuery()

            'Close the connection
            objConnection.Close()
        Catch ex As Exception
            'Display an error message
            strExceptionAddItemAsCapitalizedAndDeductFromStock = ex.Message

            'Make sure that the connection is closed
            If objConnection.State = ConnectionState.Open Then objConnection.Close()
        End Try
    End Sub

    'ADD NEW INFORMATION FOR CAPITALIZED ISSUE AND DO NOT DEDUCT THE QUANTITY OF ITEM FROM STOCK
    Public Sub AddCapitalizedIssuerAndNonDeductFromStock(ByVal itemName As String, ByVal dateOfUsed As Date, ByVal quantity As String, ByVal reason As String)
        Try
            Dim strAddItemAsCapitalized As String = "INSERT INTO CAPITALIZED" & _
                "(Item_name, Date_of_used, Quantity, Reason) " & _
                "VALUES('" & itemName & "'," & _
                "'" & dateOfUsed & "'," & _
                "'" & quantity & "'," & _
                "'" & reason & "')"

            'Open the connection
            objConnection.Open()

            'Create a command
            Dim objCommandItemAsCapitalized = New OleDbCommand(strAddItemAsCapitalized, objConnection)

            'Execute the command
            objCommandItemAsCapitalized.ExecuteNonQuery()

            'Close the connection
            objConnection.Close()
        Catch ex As Exception
            'Display an error message
            strExceptionAddItemAsCapitalizedAndNonDeductFromStock = ex.Message

            'Make sure that the connection is closed
            If objConnection.State = ConnectionState.Open Then objConnection.Close()
        End Try
    End Sub

    'DELETE THE INFORMATION FOR CAPITALIZED ISSUER AND ADD THE QUANTITY OF ITEM TO STOCK AS WELL
    Public Sub DeleteCapitalizedIssuerAndAddToStock(ByVal itemName As String, ByVal dateOfUsed As Date, ByVal quantity As String)
        Try
            Dim strDeleteCapitalizedIssuer As String = "DELETE * FROM CAPITALIZED " & _
                "WHERE Item_name='" & itemName & "' " & _
                "AND Date_of_used=#" & dateOfUsed & "#"
            Dim strAddItemToStock As String = "UPDATE STOCK " & _
                "SET Quantity_on_hand=(Quantity_on_hand + " & quantity & ") " & _
                "WHERE Item_name='" & itemName & "'"

            'Open the connection
            objConnection.Open()

            Dim objCommandDeleteCapitalizedIssuer = New OleDbCommand(strDeleteCapitalizedIssuer, objConnection)
            Dim objCommandAddItemToStock = New OleDbCommand(strAddItemToStock, objConnection)

            'Execute 
            objCommandDeleteCapitalizedIssuer.ExecuteNonQuery()
            objCommandAddItemToStock.ExecuteNonQuery()

            'Close the connection
            objConnection.Close()
        Catch ex As Exception
            strExceptionDeleteItemAsCapitalizedAndAddToStock = ex.Message

            'Make sure the connection is closed
            If objConnection.State = ConnectionState.Open Then objConnection.Close()
        End Try
    End Sub

    'DELETE THE INFORMATION FOR CAPITALIZED ISSUER AND DO NOT ADD THE QUANTITY OF ITEM TO STOCK
    Public Sub DeleteCapitalizedIssuerAndDoNotAddToStock(ByVal itemName As String, ByVal dateOfUsed As Date)
        Try
            Dim strDeleteCapitalizedIssuer As String = "DELETE * FROM CAPITALIZED " & _
                "WHERE Item_name='" & itemName & "' " & _
                "AND Date_of_used=#" & dateOfUsed & "#"
            'Open the connection
            objConnection.Open()

            Dim objCommandDeleteCapitalizedIssuer = New OleDbCommand(strDeleteCapitalizedIssuer, objConnection)

            'Execute 
            objCommandDeleteCapitalizedIssuer.ExecuteNonQuery()

            'Close the connection
            objConnection.Close()
        Catch ex As Exception
            strExceptionDeleteItemAsCapitalizedAndDoNotAddToStock = ex.Message

            'Make sure the connection is closed
            If objConnection.State = ConnectionState.Open Then objConnection.Close()
        End Try
    End Sub






    'EXPENSE ISSUER FORM METHODS

    'ADD NEW INFORMATION FOR EXPENSE ISSUE AND DEDUCT THE QUANTITY OF ITEM FROM STOCK AS WELL
    Public Sub AddExpenseIssuerAndDeductFromStock(ByVal itemName As String, ByVal dateOfUsed As Date, ByVal quantity As String, ByVal reason As String)
        Try
            Dim strAddItemAsExpense As String = "INSERT INTO EXPENSE " & _
                "(Item_name, Date_of_used, Quantity, Reason) " & _
                "VALUES('" & itemName & "'," & _
                "'" & dateOfUsed & "'," & _
                "'" & quantity & "'," & _
                "'" & reason & "')"


            Dim strSubtractItemQuantityFromStock As String = "UPDATE STOCK " & _
                "SET Quantity_on_hand= (Quantity_on_hand - " & quantity & ") " & _
                "WHERE Item_name= '" & itemName & "'"

            'Open the connection
            objConnection.Open()

            'Create a command
            Dim objCommandItemAsExpense = New OleDbCommand(strAddItemAsExpense, objConnection)
            Dim objCommandItemSubtractedFromStock = New OleDbCommand(strSubtractItemQuantityFromStock, objConnection)

            'Execute the command
            objCommandItemAsExpense.ExecuteNonQuery()
            objCommandItemSubtractedFromStock.ExecuteNonQuery()

            'Close the connection
            objConnection.Close()
        Catch ex As Exception
            strExceptionAddItemAsExpenseAndDeductFromStock = ex.Message

            'Make sure that the connection is closed
            If objConnection.State = ConnectionState.Open Then objConnection.Close()
        End Try

        'ADD NEW INFORMATION FOR EXPENSE ISSUE AND DO NOT DEDUCT THE QUANTITY OF ITEM FROM STOCK
    End Sub


    'ADD NEW INFORMATION FOR EXPENSE ISSUE AND DO NOT DEDUCT THE QUANTITY OF ITEM FROM STOCK
    Public Sub AddExpenseIssuerAndNonDeductFromStock(ByVal itemName As String, ByVal dateOfUsed As Date, ByVal quantity As String, ByVal reason As String)
        Try
            Dim strAddItemAsExpense As String = "INSERT INTO EXPENSE " & _
                "(Item_name, Date_of_used, Quantity, Reason) " & _
                "VALUES('" & itemName & "'," & _
                "'" & dateOfUsed & "'," & _
                "'" & quantity & "'," & _
                "'" & reason & "')"

            'Open the connection
            objConnection.Open()

            'Create a command
            Dim objCommandItemAsExpense = New OleDbCommand(strAddItemAsExpense, objConnection)

            'Execute the command to insert into EXPENSE Table
            objCommandItemAsExpense.ExecuteNonQuery()

            'Close the connection
            objConnection.Close()
        Catch ex As Exception
            strExceptionAddItemAsExpenseAndNonDeductFromStock = ex.Message

            'Make sure that the connection is closed
            If objConnection.State = ConnectionState.Open Then objConnection.Close()
        End Try
    End Sub


    'DELETE THE INFORMATION FOR EXPENSE ISSUER AND ADD THE QUANTITY OF ITEM TO STOCK AS WELL
    Public Sub DeleteExpenseIssuerAndAddToStock(ByVal itemName As String, ByVal dateOfUsed As Date, ByVal quantity As String)
        Try
            Dim strDeleteExpenseIssuer As String = "DELETE * FROM EXPENSE " & _
                "WHERE Item_name='" & itemName & "' " & _
                "AND Date_of_used=#" & dateOfUsed & "#"
            Dim strAddItemToStock As String = "UPDATE STOCK " & _
                "SET Quantity_on_hand=(Quantity_on_hand + " & quantity & ") " & _
                "WHERE Item_name='" & itemName & "'"

            'Open the connection
            objConnection.Open()

            Dim objCommandDeleteExpenseIssuer = New OleDbCommand(strDeleteExpenseIssuer, objConnection)
            Dim objCommandAddItemToStock = New OleDbCommand(strAddItemToStock, objConnection)

            'Execute 
            objCommandDeleteExpenseIssuer.ExecuteNonQuery()
            objCommandAddItemToStock.ExecuteNonQuery()

            'Close the connection
            objConnection.Close()
        Catch ex As Exception
            strExceptionDeleteItemAsExpenseAndAddToStock = ex.Message

            'Make sure the connection is closed
            If objConnection.State = ConnectionState.Open Then objConnection.Close()
        End Try
    End Sub

    'DELETE THE INFORMATION FOR EXPENSE ISSUER AND DO NOT ADD THE QUANTITY OF ITEM TO STOCK
    Public Sub DeleteExpenseIssuerAndDoNotAddToStock(ByVal itemName As String, ByVal dateOfUsed As Date)
        Try
            Dim strDeleteExpenseIssuer As String = "DELETE * FROM EXPENSE " & _
                "WHERE Item_name='" & itemName & "' " & _
                "AND Date_of_used=#" & dateOfUsed & "#"
            'Open the connection
            objConnection.Open()

            Dim objCommandDeleteExpenseIssuer = New OleDbCommand(strDeleteExpenseIssuer, objConnection)

            'Execute 
            objCommandDeleteExpenseIssuer.ExecuteNonQuery()

            'Close the connection
            objConnection.Close()
        Catch ex As Exception
            strExceptionDeleteItemAsExpenseAndDoNotAddToStock = ex.Message

            'Make sure the connection is closed
            If objConnection.State = ConnectionState.Open Then objConnection.Close()
        End Try
    End Sub







    'SALES ISSUER FORM METHODS

    'ADD NEW INFORMATION FOR SALES ISSUE AND DEDUCT THE QUANTITY OF ITEM FROM STOCK AS WELL
    Public Sub AddSalesIssuerAndDeductFromStock(ByVal itemName As String, ByVal dateOfSale As Date, ByVal customerPhoneNumber As String, ByVal quantity As String)
        Try
            Dim strAddItemAsSale As String = "INSERT INTO SALES " & _
                "(Item_name, Date_of_sale, Customer_ph_no, Quantity) " & _
                "VALUES('" & itemName & "'," & _
                "'" & dateOfSale & "'," & _
                "'" & customerPhoneNumber & "'," & _
                "'" & quantity & "')"


            Dim strSubtractItemQuantityFromStock As String = "UPDATE STOCK " & _
                "SET Quantity_on_hand= (Quantity_on_hand - " & quantity & ") " & _
                "WHERE Item_name= '" & itemName & "'"

            'Open the connection
            objConnection.Open()

            'Create a command
            Dim objCommandItemAsSale = New OleDbCommand(strAddItemAsSale, objConnection)
            Dim objCommandItemSubtractedFromStock = New OleDbCommand(strSubtractItemQuantityFromStock, objConnection)

            'Execute the command
            objCommandItemAsSale.ExecuteNonQuery()
            objCommandItemSubtractedFromStock.ExecuteNonQuery()

            'Close the connection
            objConnection.Close()
        Catch ex As Exception
            strExceptionAddItemAsSaleAndDeductFromStock = ex.Message

            'Make sure that the connection is closed
            If objConnection.State = ConnectionState.Open Then objConnection.Close()
        End Try

        'ADD NEW INFORMATION FOR EXPENSE ISSUE AND DO NOT DEDUCT THE QUANTITY OF ITEM FROM STOCK
    End Sub

    'ADD NEW INFORMATION FOR SALES ISSUE AND DO NOT DEDUCT THE QUANTITY OF ITEM FROM STOCK
    Public Sub AddSalesIssuerAndNonDeductFromStock(ByVal itemName As String, ByVal dateOfSale As Date, ByVal customerPhoneNumber As String, ByVal quantity As String)
        Try
            Dim strAddItemAsSale As String = "INSERT INTO SALES " & _
              "(Item_name, Date_of_sale, Customer_ph_no, Quantity) " & _
              "VALUES('" & itemName & "'," & _
              "'" & dateOfSale & "'," & _
              "'" & customerPhoneNumber & "'," & _
              "'" & quantity & "')"

            'Open the connection
            objConnection.Open()

            'Create a command
            Dim objCommandItemAsSale = New OleDbCommand(strAddItemAsSale, objConnection)

            'Execute the command to insert into EXPENSE Table
            objCommandItemAsSale.ExecuteNonQuery()

            'Close the connection
            objConnection.Close()
        Catch ex As Exception
            strExceptionAddItemAsSaleAndNonDeductFromStock = ex.Message

            'Make sure that the connection is closed
            If objConnection.State = ConnectionState.Open Then objConnection.Close()
        End Try
    End Sub

    'ADD SALES AND NEW CUSTOMER DETAILS AND DO NOT DEDUCT THE QUANTITY OF ITEM SOLD FROM THE STORE
    Public Sub AddSalesIssuerAndCustomerAndNonDeductFromStock(ByVal itemName As String, ByVal dateOfSale As Date, ByVal customerPhoneNumber As String, ByVal customerName As String, ByVal quantity As String)
        Try
            Dim strAddCustomer As String = "INSERT INTO CUSTOMER " & _
                "VALUES(" & _
                "'" & customerPhoneNumber & "'," & _
                "'" & customerName & "')"

            Dim strAddItemAsSale As String = "INSERT INTO SALES " & _
                "(Item_name, Date_of_sale, Customer_ph_no, Quantity) " & _
                "VALUES(" & _
                "'" & itemName & "'," & _
                "#" & dateOfSale & "#," & _
                "'" & customerPhoneNumber & "'," & _
                "'" & quantity & "')"

            objConnection.Open()

            'Create a command
            Dim objCommandCustomer = New OleDbCommand(strAddCustomer, objConnection)
            Dim objCommandItemAsSale = New OleDbCommand(strAddItemAsSale, objConnection)

            'Execute the Command object to insert into CUSTOMER and SALES Table
            objCommandCustomer.ExecuteNonQuery()
            objCommandItemAsSale.ExecuteNonQuery()

            objConnection.Close()
        Catch ex As Exception
            strExceptionAddItemAsSaleAndCustomerAndNonDeductFromStock = ex.Message

            'Make sure that the connection is closed
            If objConnection.State = ConnectionState.Open Then objConnection.Close()
        End Try
    End Sub

    'ADD SALES AND NEW CUSTOMER DETAILS AND DEDUCT THE QUANTITY OF ITEM SOLD FROM THE STORE
    Public Sub AddSalesIssuerAndCustomerAndDeductFromStock(ByVal itemName As String, ByVal dateOfSale As Date, ByVal customerPhoneNumber As String, ByVal customerName As String, ByVal quantity As String)
        Try
            Dim strAddCustomer As String = "INSERT INTO CUSTOMER " & _
                   "VALUES(" & _
                   "'" & customerPhoneNumber & "'," & _
                   "'" & customerName & "')"

            Dim strAddItemAsSale As String = "INSERT INTO SALES " & _
                "(Item_name, Date_of_sale, Customer_ph_no, Quantity) " & _
                "VALUES(" & _
                "'" & itemName & "'," & _
                "#" & dateOfSale & "#," & _
                "'" & customerPhoneNumber & "'," & _
                "'" & quantity & "')"

            Dim strSubtractItemQuantityFromStock As String = "UPDATE STOCK " & _
              "SET Quantity_on_hand= (Quantity_on_hand - " & quantity & ") " & _
              "WHERE Item_name= '" & itemName & "'"


            objConnection.Open()

            'Create a command
            Dim objCommandCustomer = New OleDbCommand(strAddCustomer, objConnection)
            Dim objCommandItemAsSale = New OleDbCommand(strAddItemAsSale, objConnection)
            Dim objCommandItemSubractedFromStock = New OleDbCommand(strSubtractItemQuantityFromStock, objConnection)

            'Execute the Command object to insert into CUSTOMER and SALES Table
            objCommandCustomer.ExecuteNonQuery()
            objCommandItemAsSale.ExecuteNonQuery()
            objCommandItemSubractedFromStock.ExecuteNonQuery()

            objConnection.Close()
        Catch ex As Exception
            strExceptionAddItemAsSaleAndCustomerAndDeductFromStock = ex.Message

            'Make sure that the connection is closed
            If objConnection.State = ConnectionState.Open Then objConnection.Close()
        End Try
    End Sub




    'DELETE THE ITEM SOLD DETAILS ONLY
    Public Sub DeleteSalesIssuerAndDoNotAddToStock(ByVal itemName As String, ByVal dateOfSale As Date, ByVal customerPhoneNumber As String)
        Try
            Dim strDeleteSalesIssuer = "DELETE * FROM SALES " & _
           "WHERE Item_name='" & itemName & "' " & _
           "AND Date_of_sale=#" & dateOfSale & "#" & _
           "AND Customer_ph_no='" & customerPhoneNumber & "'"

            'Open the connection
            objConnection.Open()

            Dim objCommandDeleteSalesIssuer = New OleDbCommand(strDeleteSalesIssuer, objConnection)

            objCommandDeleteSalesIssuer.ExecuteNonQuery()

            'Close the connection
            objConnection.Close()
        Catch ex As Exception
            strExceptionDeleteItemAsSalesAndDoNotAddToStock = ex.Message

            'Make sure that the connection is closed..
            If objConnection.State = ConnectionState.Open Then objConnection.Close()
        End Try
    End Sub

    'DELETE THE ITEM SOLD DETAILS AND ALSO ADD THE QUANTITY OF ITEM TO THE STORE
    Public Sub DeleteSalesIssuerAndAddToStock(ByVal itemName As String, ByVal dateOfSale As Date, ByVal customerPhoneNumber As String, ByVal quantity As String)
        Try
            Dim strDeleteSalesIssuer = "DELETE FROM SALES " & _
           "WHERE Item_name='" & itemName & "' " & _
           "AND Date_of_sale=#" & dateOfSale & "#" & _
           "AND Customer_ph_no='" & customerPhoneNumber & "'"

            Dim strAddItemToStock As String = "UPDATE STOCK " & _
                "SET Quantity_on_hand=(Quantity_on_hand + " & quantity & ") " & _
                    "WHERE Item_name='" & itemName & "'"

            'Open the connection
            objConnection.Open()

            Dim bjCommandDeleteSalesIssuer = New OleDbCommand(strDeleteSalesIssuer, objConnection)
            Dim objCommandAddItemToStock = New OleDbCommand(strAddItemToStock, objConnection)

            bjCommandDeleteSalesIssuer.ExecuteNonQuery()
            objCommandAddItemToStock.ExecuteNonQuery()

            'Close the connection
            objConnection.Close()
        Catch ex As Exception
            strExceptionDeleteItemAsSalesAndDoNotAddToStock = ex.Message

            'Make sure that the connection is closed..
            If objConnection.State = ConnectionState.Open Then objConnection.Close()
        End Try
    End Sub


    'Public Sub AddSalesIssuer(ByVal itemName As String, ByVal dateOfSale As Date, ByVal customerPhoneNumber As String, ByVal customerName As String, ByVal quantity As String)
    '    Try
    '        Dim strAddItemAsSales As String = "INSERT INTO SALES" & _
    '            "(Item_name, Date_of_Sale, Customer_ph_no, Customer_name, Quantity) " & _
    '            "VALUES('" & itemName & "'," & _
    '            "'" & dateOfSale & "'," & _
    '            "'" & customerPhoneNumber & "'," & _
    '            "'" & customerName & "'," & _
    '            "'" & quantity & "')"

    '        'Open the connection
    '        objConnection.Open()

    '        'Create a command
    '        Dim objCommandItemAsSales = New OleDbCommand(strAddItemAsSales, objConnection)

    '        'Execute the command
    '        objCommandItemAsSales.ExecuteNonQuery()

    '        'Close the connection
    '        objConnection.Close()
    '    Catch ex As Exception
    '        'Display an error message
    '        MessageBox.Show(ex.Message, My.Application.Info.Title)

    '        'Make sure that the connection is closed
    '        If objConnection.State = ConnectionState.Open Then objConnection.Close()
    '    End Try
    'End Sub
End Class
