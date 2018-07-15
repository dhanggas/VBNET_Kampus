Imports System.Data.DataSet
Imports IS_NTC_ControlLibrary
Public Class DSCustomerDetails
    Inherits DataSet
    Private objCustomerDataTable As DataTable
    Private storeAccess As New StoreAccess

    Public Sub New()
        objCustomerDataTable = New DataTable("TableCustomerDetails")
        objCustomerDataTable.Columns.Add("SN", GetType(Integer))
        objCustomerDataTable.Columns.Add("CustomerName")
        objCustomerDataTable.Columns.Add("CustomerPhNumber")

        storeAccess.GetCustomerDetailsForReport()

        Dim i As Integer = 1
        For Each r As DataRow In storeAccess.objCustomerDetailsDataTableForReporting.Rows
            objCustomerDataTable.Rows.Add(i, r(1), r(0))
            i += 1
        Next
        objCustomerDataTable.AcceptChanges()
        Tables.Add(objCustomerDataTable)
    End Sub
End Class
