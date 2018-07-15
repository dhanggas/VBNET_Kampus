Imports System.Data.DataSet
Public Class DSExpenseIssuer
    Inherits DataSet
    Private objExpenseIssuerDataTable As DataTable

    Public Sub New()
        objExpenseIssuerDataTable = New DataTable("TableExpenseIssuer")
        objExpenseIssuerDataTable.Columns.Add("SN")
        objExpenseIssuerDataTable.Columns.Add("ItemName")
        objExpenseIssuerDataTable.Columns.Add("DateOfUsed", GetType(Date))
        objExpenseIssuerDataTable.Columns.Add("Quanity")
        objExpenseIssuerDataTable.Columns.Add("Reason")


        Dim dt As DataTable = GblAccessObject.objDataTableofExpenseIssuerForm
        For Each r As DataRow In dt.Rows
            objExpenseIssuerDataTable.Rows.Add(r(0), r(1), r(2), r(3), r(4))
        Next

        objExpenseIssuerDataTable.AcceptChanges()
        Tables.Add(objExpenseIssuerDataTable)
    End Sub

End Class
