

Imports System.Data.DataSet
Imports IS_NTC_ControlLibrary

Public Class DSBranchDetails
    Inherits DataSet

    Private objBranchDataTable As DataTable
    Private stockAccess As New StockAccess

    Public Sub New()
        objBranchDataTable = New DataTable()
        objBranchDataTable.TableName = "TableBranchDetails"
        objBranchDataTable.Columns.Add("SN", GetType(Integer))
        objBranchDataTable.Columns.Add("BRANCH", GetType(String))
        'objBranchDataTable.Rows.Clear()

        stockAccess.GetBranchDetailsForReport()

        Dim i As Integer = 1
        For Each r As DataRow In stockAccess.objBranchDataTableForReporting.Rows
            objBranchDataTable.Rows.Add(i, r(0))
            i += 1
        Next

        objBranchDataTable.AcceptChanges()
        Tables.Add(objBranchDataTable)
    End Sub
End Class