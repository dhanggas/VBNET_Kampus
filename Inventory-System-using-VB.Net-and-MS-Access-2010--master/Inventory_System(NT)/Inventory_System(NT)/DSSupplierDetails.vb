Imports System.Data.DataSet
Imports IS_NTC_ControlLibrary

Public Class DSSupplierDetails
    Inherits DataSet
    Private objSupplierDataTable As DataTable
    Private storeAccess As New StoreAccess

    Public Sub New()
        objSupplierDataTable = New DataTable()
        objSupplierDataTable.TableName = "TableSupplierDetails"
        objSupplierDataTable.Columns.Add("SN", GetType(Integer))
        objSupplierDataTable.Columns.Add("NAME", GetType(String))
        objSupplierDataTable.Columns.Add("ADDRESS", GetType(String))
        objSupplierDataTable.Columns.Add("PHNUMBER", GetType(String))
        'objBranchDataTable.Rows.Clear()

        storeAccess.GetSupplierDetailsForReport()

        Dim i As Integer = 1
        For Each r As DataRow In storeAccess.objSupplierDataTableForReporting.Rows
            objSupplierDataTable.Rows.Add(i, r(0), r(1), r(2))
            i += 1
        Next

        objSupplierDataTable.AcceptChanges()
        Tables.Add(objSupplierDataTable)
    End Sub
End Class
