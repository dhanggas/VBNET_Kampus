Public Class GblAccessObject
    'STORE DATA TABLE
    Private Shared objDataTableItemEntrance As DataTable
    Private Shared objDataTableItemSales As DataTable

    'STOCK DATA TABLE
    Private Shared objDataTableItemReceived As DataTable
    Private Shared objDataTableBranchIssuer As DataTable
    Private Shared objDataTableCapitalizedIssuer As DataTable
    Private Shared objDataTableExpenseIssuer As DataTable
    Private Shared objDataTableSalesIssuer As DataTable

    'DATA TABLE FOR ITEM ENTRANCE FORM
    Public Shared Property objDataTableOfItemEntranceForm As DataTable
        Get
            Return objDataTableItemEntrance
        End Get
        Set(value As DataTable)
            objDataTableItemEntrance = value
        End Set
    End Property



    'DATA TABLE FOR ITEM SALES FORM
    Public Shared Property objDataTableOfItemSalesForm As DataTable
        Get
            Return objDataTableItemSales
        End Get
        Set(value As DataTable)
            objDataTableItemSales = value
        End Set
    End Property

    'DATA TABLE FOR ITEM RECEIVED FORM
    Public Shared Property objDataTableOfItemReceivedForm As DataTable
        Get
            Return objDataTableItemReceived
        End Get
        Set(value As DataTable)
            objDataTableItemReceived = value
        End Set
    End Property

    'DATA TABLE FOR BRANCH ISSUER FORM
    Public Shared Property objDataTableOfBranchIssuerForm As DataTable
        Get
            Return objDataTableBranchIssuer
        End Get
        Set(value As DataTable)
            objDataTableBranchIssuer = value
        End Set
    End Property

    'DATA TABLE FOR CAPITALIZED ISSUER FORM
    Public Shared Property objDataTableOfCapitalizedIssuerForm As DataTable
        Get
            Return objDataTableCapitalizedIssuer
        End Get
        Set(value As DataTable)
            objDataTableCapitalizedIssuer = value
        End Set
    End Property

    'DATA TABLE FOR EXPENSE ISSUER FORM
    Public Shared Property objDataTableofExpenseIssuerForm As DataTable
        Get
            Return objDataTableExpenseIssuer
        End Get
        Set(value As DataTable)
            objDataTableExpenseIssuer = value
        End Set
    End Property

    'DATA TABLE FOR SALES ISSUER FORM
    Public Shared Property objDataTableOfSalesIssuerForm As DataTable
        Get
            Return objDataTableSalesIssuer
        End Get
        Set(value As DataTable)
            objDataTableSalesIssuer = value
        End Set
    End Property
End Class
