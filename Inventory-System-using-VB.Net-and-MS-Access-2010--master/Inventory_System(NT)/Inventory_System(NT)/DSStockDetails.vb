Imports System.Data.DataSet
Imports IS_NTC_ControlLibrary
Public Class DSStockDetails
    Inherits DataSet
    Private objStockDetailsDataTable As DataTable
    Private stockAccess As New StockAccess

    Public Sub New()
        objStockDetailsDataTable = New DataTable("TableStockDetails")
        objStockDetailsDataTable.Columns.Add("SN", GetType(Integer))
        objStockDetailsDataTable.Columns.Add("ItemName")
        objStockDetailsDataTable.Columns.Add("QOH")

        stockAccess.GetStockkDetailsForReport()

        Dim i As Integer = 1
        For Each r As DataRow In stockAccess.objStockDetailsDataTableForReporting.Rows
            objStockDetailsDataTable.Rows.Add(i, r(0), r(1))
            i += 1
        Next


        objStockDetailsDataTable.AcceptChanges()
        Tables.Add(objStockDetailsDataTable)
    End Sub
End Class
