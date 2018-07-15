Imports System.Data.DataSet
Imports IS_NTC_ControlLibrary

Public Class DSStoreDetails
    Inherits DataSet
    Private objStoreDetailsDataTable As DataTable
    Private storeAccess As New StoreAccess

    Public Sub New()
        objStoreDetailsDataTable = New DataTable("TableStoreDetails")
        objStoreDetailsDataTable.Columns.Add("SN", GetType(Integer))
        objStoreDetailsDataTable.Columns.Add("ITEMNAME")
        objStoreDetailsDataTable.Columns.Add("QOH", GetType(Integer))

        storeAccess.GetStoreDetailsForReport()

        Dim i As Integer = 1
        For Each r As DataRow In storeAccess.objStoreDetailsDataTableForReporting.Rows
            objStoreDetailsDataTable.Rows.Add(i, r(0), r(1))
            i += 1
        Next

        objStoreDetailsDataTable.AcceptChanges()
        Tables.Add(objStoreDetailsDataTable)
    End Sub
End Class
