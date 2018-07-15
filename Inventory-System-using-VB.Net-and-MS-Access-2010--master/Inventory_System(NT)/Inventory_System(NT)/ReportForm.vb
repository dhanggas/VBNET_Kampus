Imports Microsoft.Reporting.WinForms

Public Class ReportForm
    Public Property strSender As String

    Private Sub ReportForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If strSender = "BranchDetails" Then
            Me.SupplierDetailsReportViewer.Visible = False
            Me.StoreDetailsReportViewer.Visible = False
            Me.CustomerDetailsReportViewer.Visible = False
            Me.CustomerDetailsStockReportViewer.Visible = False
            Me.StockDetailsReportViewer.Visible = False
            LoadReportBranchDetails()

        ElseIf strSender = "CustomerDetailsStock" Then
            Me.BranchDetailsReportViewer.Visible = False
            Me.SupplierDetailsReportViewer.Visible = False
            Me.StoreDetailsReportViewer.Visible = False
            Me.CustomerDetailsReportViewer.Visible = False
            Me.StockDetailsReportViewer.Visible = False
            LoadReportCustomerDetailsStock()

        ElseIf strSender = "StockDetails" Then
            Me.BranchDetailsReportViewer.Visible = False
            Me.SupplierDetailsReportViewer.Visible = False
            Me.StoreDetailsReportViewer.Visible = False
            Me.CustomerDetailsReportViewer.Visible = False
            Me.CustomerDetailsStockReportViewer.Visible = False
            LoadReportStockDetails()

        ElseIf strSender = "SupplierDetails" Then
            Me.BranchDetailsReportViewer.Visible = False
            Me.StoreDetailsReportViewer.Visible = False
            Me.CustomerDetailsReportViewer.Visible = False
            Me.CustomerDetailsStockReportViewer.Visible = False
            Me.StockDetailsReportViewer.Visible = False
            LoadReportSupplierDetails()

        ElseIf strSender = "StoreDetails" Then
            Me.BranchDetailsReportViewer.Visible = False
            Me.SupplierDetailsReportViewer.Visible = False
            Me.CustomerDetailsReportViewer.Visible = False
            Me.CustomerDetailsStockReportViewer.Visible = False
            Me.StockDetailsReportViewer.Visible = False
            LoadReportStoreDetails()

        ElseIf strSender = "CustomerDetails" Then
            Me.BranchDetailsReportViewer.Visible = False
            Me.SupplierDetailsReportViewer.Visible = False
            Me.StoreDetailsReportViewer.Visible = False
            Me.CustomerDetailsStockReportViewer.Visible = False
            Me.StockDetailsReportViewer.Visible = False
            LoadReportCustomerDetails()



        End If
        strSender = Nothing
        'Me.StoreDetailsReportViewer.RefreshReport()
        'Me.CustomerDetailsReportViewer.RefreshReport()
        'Me.CustomerDetailsStockReportViewer.RefreshReport()
        'Me.StockDetailsReportViewer.RefreshReport()
    End Sub

    Public Sub LoadReportBranchDetails()
        'Me.BranchDetailsReportViewer.LocalReport.DataSources.Clear()
        'Me.BranchDetailsReportViewer.LocalReport.ReportEmbeddedResource = "Inventory_System_NT_.BranchDetailsReport.rdlc"
        Dim dsBranchDetails As New DSBranchDetails


        Me.DSBranchDetailsBindingSource.DataMember = "TableBranchDetails"
        Me.DSBranchDetailsBindingSource.DataSource = dsBranchDetails
        With Me.BranchDetailsReportViewer
            .Dock = DockStyle.Fill
            .SetDisplayMode(DisplayMode.PrintLayout)
            .ZoomMode = ZoomMode.Percent
            .ZoomPercent = 100%
        End With
    End Sub

    Public Sub LoadReportSupplierDetails()
        'Me.SupplierDetailsReportViewer.LocalReport.DataSources.Clear()
        'Me.BranchDetailsReportViewer.LocalReport.ReportEmbeddedResource = "Inventory_System_NT_.SupplierDetailsReport.rdlc"
        Dim dsSupplierDetails As New DSSupplierDetails
        Me.DSSupplierDetailsBindingSource.DataMember = "TableSupplierDetails"
        Me.DSSupplierDetailsBindingSource.DataSource = dsSupplierDetails
        With Me.SupplierDetailsReportViewer
            .Dock = DockStyle.Fill
            .SetDisplayMode(DisplayMode.PrintLayout)
            .ZoomMode = ZoomMode.Percent
            .ZoomPercent = 100%
        End With
    End Sub

    Public Sub LoadReportStoreDetails()
        Dim dsSupplierDetails As New DSStoreDetails
        Me.DSStoreDetailsBindingSource.DataMember = "TableStoreDetails"
        Me.DSStoreDetailsBindingSource.DataSource = dsSupplierDetails
        With Me.StoreDetailsReportViewer
            .Dock = DockStyle.Fill
            .SetDisplayMode(DisplayMode.PrintLayout)
            .ZoomMode = ZoomMode.Percent
            .ZoomPercent = 100%
        End With
        
    End Sub

    Public Sub LoadReportCustomerDetails()
        Dim dsCustomerDetails As New DSCustomerDetails
        Me.DSCustomerDetailsBindingSource.DataMember = "TableCustomerDetails"
        Me.DSCustomerDetailsBindingSource.DataSource = dsCustomerDetails
        With Me.CustomerDetailsReportViewer
            .Dock = DockStyle.Fill
            .SetDisplayMode(DisplayMode.PrintLayout)
            .ZoomMode = ZoomMode.Percent
            .ZoomPercent = 100%
        End With
    End Sub

    Public Sub LoadReportCustomerDetailsStock()
        Dim dsCustomerDetailsStock As New DSCustomerDetailsStock
        Me.DSCustomerDetailsStockBindingSource.DataMember = "TableCustomerDetailsStock"
        Me.DSCustomerDetailsStockBindingSource.DataSource = dsCustomerDetailsStock
        With Me.CustomerDetailsStockReportViewer
            .Dock = DockStyle.Fill
            .SetDisplayMode(DisplayMode.PrintLayout)
            .ZoomMode = ZoomMode.Percent
            .ZoomPercent = 100%
        End With
    End Sub


    Public Sub LoadReportStockDetails()
        Dim dsStockDetails As New DSStockDetails
        Me.DSStockDetailsBindingSource.DataMember = "TableStockDetails"
        Me.DSStockDetailsBindingSource.DataSource = dsStockDetails
        With Me.StockDetailsReportViewer
            .Dock = DockStyle.Fill
            .SetDisplayMode(DisplayMode.PrintLayout)
            .ZoomMode = ZoomMode.Percent
            .ZoomPercent = 100%
        End With
    End Sub
End Class