Imports System.Data.DataSet

Public Class DSItemSales
    Inherits DataSet
    Private objItemSalesDataTable As DataTable

    Public Sub New()
        objItemSalesDataTable = New DataTable("TableItemSales")
        objItemSalesDataTable.Columns.Add("SN")
        objItemSalesDataTable.Columns.Add("ItemName")
        objItemSalesDataTable.Columns.Add("CustomerName")
        objItemSalesDataTable.Columns.Add("CustomerPhNumber")
        objItemSalesDataTable.Columns.Add("DateOfBought", GetType(Date))
        objItemSalesDataTable.Columns.Add("Quantity")

        Dim dt As DataTable = GblAccessObject.objDataTableOfItemSalesForm
        For Each r As DataRow In dt.Rows
            objItemSalesDataTable.Rows.Add(r(0), r(1), r(2), r(3), r(4), r(5))
        Next

        objItemSalesDataTable.AcceptChanges()
        Tables.Add(objItemSalesDataTable)
    End Sub
End Class
