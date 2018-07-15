Imports System.Data.DataSet
Public Class DSBranchIssuer
    Inherits DataSet
    Private objBranchIssuerDataTable As DataTable

    Public Sub New()
        objBranchIssuerDataTable = New DataTable("TableBranchIssuer")
        objBranchIssuerDataTable.Columns.Add("SN")
        objBranchIssuerDataTable.Columns.Add("ItemName")
        objBranchIssuerDataTable.Columns.Add("DateOfSupplied", GetType(Date))
        objBranchIssuerDataTable.Columns.Add("ReceivingBranch")
        objBranchIssuerDataTable.Columns.Add("Quantity")

        Dim dt As DataTable = GblAccessObject.objDataTableOfBranchIssuerForm
        For Each r As DataRow In dt.Rows
            objBranchIssuerDataTable.Rows.Add(r(0), r(1), r(2), r(3), r(4))
        Next


        objBranchIssuerDataTable.AcceptChanges()
        Tables.Add(objBranchIssuerDataTable)
    End Sub
End Class
