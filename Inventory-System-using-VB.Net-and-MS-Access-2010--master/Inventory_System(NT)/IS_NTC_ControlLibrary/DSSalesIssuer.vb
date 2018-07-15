Imports System.Data.DataSet

Public Class DSSalesIssuer
    Inherits DataSet
    Private objSalesIssuerDataTable As DataTable

    Public Sub New()
        objSalesIssuerDataTable = New DataTable("TableSalesIssuer")
        objSalesIssuerDataTable.Columns.Add("SN")
        objSalesIssuerDataTable.Columns.Add("ItemName")
        objSalesIssuerDataTable.Columns.Add("CustomerName")
        objSalesIssuerDataTable.Columns.Add("CustomerPhNumber")
        objSalesIssuerDataTable.Columns.Add("DateOfSale", GetType(Date))
        objSalesIssuerDataTable.Columns.Add("Quantity")

        Dim dt As DataTable = GblAccessObject.objDataTableOfSalesIssuerForm
        For Each r As DataRow In dt.Rows
            objSalesIssuerDataTable.Rows.Add(r(0), r(1), r(2), r(3), r(4), r(5))
        Next
        objSalesIssuerDataTable.AcceptChanges()
        Tables.Add(objSalesIssuerDataTable)
    End Sub
End Class
