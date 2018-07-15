Imports System.Data.DataSet

Public Class DSCapitalizedIssuer
    Inherits DataSet
    Private objCapitalizedIssuerDataTable As DataTable

    Public Sub New()
        objCapitalizedIssuerDataTable = New DataTable("TableCapitalizedIssuer")
        objCapitalizedIssuerDataTable.Columns.Add("SN")
        objCapitalizedIssuerDataTable.Columns.Add("ItemName")
        objCapitalizedIssuerDataTable.Columns.Add("DateOfUsed", GetType(Date))
        objCapitalizedIssuerDataTable.Columns.Add("Quantity")
        objCapitalizedIssuerDataTable.Columns.Add("Reason")

        Dim dt As DataTable = GblAccessObject.objDataTableOfCapitalizedIssuerForm
        For Each r As DataRow In dt.Rows
            objCapitalizedIssuerDataTable.Rows.Add(r(0), r(1), r(2), r(3), r(4))
        Next

        objCapitalizedIssuerDataTable.AcceptChanges()
        Tables.Add(objCapitalizedIssuerDataTable)
    End Sub
End Class
