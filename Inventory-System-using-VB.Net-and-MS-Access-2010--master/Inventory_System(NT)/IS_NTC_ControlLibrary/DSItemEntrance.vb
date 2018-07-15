Imports System.Data.DataSet

Public Class DSItemEntrance
    Inherits DataSet
    Private objItemEntranceDataTable As DataTable

    Public Sub New()
        objItemEntranceDataTable = New DataTable("TableItemEntrance")
        objItemEntranceDataTable.Columns.Add("SN", GetType(Integer))
        objItemEntranceDataTable.Columns.Add("SupplierName")
        objItemEntranceDataTable.Columns.Add("Address")
        objItemEntranceDataTable.Columns.Add("PhNumber")
        objItemEntranceDataTable.Columns.Add("ItemName")
        objItemEntranceDataTable.Columns.Add("DateOfSupplied", GetType(Date))
        objItemEntranceDataTable.Columns.Add("Rate")
        objItemEntranceDataTable.Columns.Add("Quantity")
        objItemEntranceDataTable.Columns.Add("Amount")

        Dim dt As DataTable = GblAccessObject.objDataTableOfItemEntranceForm
        For Each r As DataRow In dt.Rows
            objItemEntranceDataTable.Rows.Add(r(0), r(1), r(2), r(3), r(4), r(5), r(6), r(7), r(8))
        Next

        objItemEntranceDataTable.AcceptChanges()
        Tables.Add(objItemEntranceDataTable)
    End Sub
End Class
