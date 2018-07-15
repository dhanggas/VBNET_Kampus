Imports System.Data.DataSet
Public Class DSItemReceived
    Inherits DataSet
    Private objItemReceivedDataTable As DataTable

    Public Sub New()
        objItemReceivedDataTable = New DataTable("TableItemReceived")
        objItemReceivedDataTable.Columns.Add("SN")
        objItemReceivedDataTable.Columns.Add("ItemName")
        objItemReceivedDataTable.Columns.Add("DateOfReceived", GetType(Date))
        objItemReceivedDataTable.Columns.Add("Branch")
        objItemReceivedDataTable.Columns.Add("Quantity")

        Dim dt As DataTable = GblAccessObject.objDataTableOfItemReceivedForm
        For Each r As DataRow In dt.Rows
            objItemReceivedDataTable.Rows.Add(r(0), r(1), r(2), r(3), r(4))
        Next

        objItemReceivedDataTable.AcceptChanges()
        Tables.Add(objItemReceivedDataTable)
    End Sub


End Class
