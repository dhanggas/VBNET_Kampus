Imports System.Data.DataSet
Imports IS_NTC_ControlLibrary
Public Class DSCustomerDetailsStock
    Inherits DataSet
    Private objCustomerDataTable As DataTable
    Private stockAccess As New StockAccess

    Public Sub New()
        objCustomerDataTable = New DataTable("TableCustomerDetailsStock")
        objCustomerDataTable.Columns.Add("SN", GetType(Integer))
        objCustomerDataTable.Columns.Add("CustomerName")
        objCustomerDataTable.Columns.Add("CustomerPhNumber")

        stockAccess.GetCustomerDetailsForReport()

        Dim i As Integer = 1
        For Each r As DataRow In stockAccess.objCustomerDetailsDataTableForReporting.Rows
            objCustomerDataTable.Rows.Add(i, r(1), r(0))
            i += 1
        Next

        objCustomerDataTable.AcceptChanges()
        Tables.Add(objCustomerDataTable)
    End Sub

End Class
