Imports Microsoft.Reporting.WinForms

Public Class ReportForm
    Public strSender As String

    Private Sub ReportForm_Load(sender As Object, e As EventArgs) Handles Me.Load
        'Make sure that the all Report Viewer is hidden
        ReportViewerItemEntrance.Visible = False
        ReportViewerItemSales.Visible = False
        ReportViewerItemReceived.Visible = False
        ReportViewerBranchIssuer.Visible = False
        ReportViewerCapitalizedIssuer.Visible = False
        ReportViewerExpenseIssuer.Visible = False
        ReportViewerSalesIssuer.Visible = False

        If strSender = "ItemEntrance" Then
            LoadReportItemEntrance()
        ElseIf strSender = "ItemSales" Then
            LoadReportItemSales()
        ElseIf strSender = "ItemReceived" Then
            LoadReportItemReceived()
        ElseIf strSender = "BranchIssuer" Then
            LoadReportBranchIssuer()
        ElseIf strSender = "CapitalizedIssuer" Then
            LoadReportCapitalizedIssuer()
        ElseIf strSender = "ExpenseIssuer" Then
            LoadReportExpenseIssuer()
        ElseIf strSender = "SalesIssuer" Then
            LoadReportSalesIssuer()
        End If


        Me.ReportViewerItemReceived.RefreshReport()
        Me.ReportViewerBranchIssuer.RefreshReport()
        Me.ReportViewerCapitalizedIssuer.RefreshReport()
        Me.ReportViewerExpenseIssuer.RefreshReport()
        Me.ReportViewerSalesIssuer.RefreshReport()
    End Sub

    Private Sub LoadReportItemEntrance()
        Dim dsItemEntrance As New DSItemEntrance

        Me.DSItemEntranceBindingSource.DataMember = "TableItemEntrance"
        Me.DSItemEntranceBindingSource.DataSource = dsItemEntrance
        Me.ReportViewerItemEntrance.Visible = True
        With Me.ReportViewerItemEntrance
            .Dock = DockStyle.Fill
            .SetDisplayMode(DisplayMode.PrintLayout)
        End With
    End Sub

    Private Sub LoadReportItemSales()
        Dim dsItemSales As New DSItemSales

        Me.DSItemSalesBindingSource.DataMember = "TableItemSales"
        Me.DSItemSalesBindingSource.DataSource = dsItemSales
        Me.ReportViewerItemSales.Visible = True
        With Me.ReportViewerItemSales
            .Dock = DockStyle.Fill
            .SetDisplayMode(DisplayMode.PrintLayout)
            .ZoomMode = ZoomMode.Percent
            .ZoomPercent = 100%
        End With
    End Sub

    Private Sub LoadReportItemReceived()
        Dim dsItemReceived As New DSItemReceived

        Me.DSItemReceivedBindingSource.DataMember = "TableItemReceived"
        Me.DSItemReceivedBindingSource.DataSource = dsItemReceived
        With Me.ReportViewerItemReceived
            .Visible = True
            .Dock = DockStyle.Fill
            .SetDisplayMode(DisplayMode.PrintLayout)
            .ZoomMode = ZoomMode.Percent
            .ZoomPercent = 100%
        End With
    End Sub

    Private Sub LoadReportBranchIssuer()
        Dim dsBranchIssuer As New DSBranchIssuer

        Me.DSBranchIssuerBindingSource.DataMember = "TableBranchIssuer"
        Me.DSBranchIssuerBindingSource.DataSource = dsBranchIssuer
        With Me.ReportViewerBranchIssuer
            .Visible = True
            .Dock = DockStyle.Fill
            .SetDisplayMode(DisplayMode.PrintLayout)
            .ZoomMode = ZoomMode.Percent
            .ZoomPercent = 100%
        End With
    End Sub

    Private Sub LoadReportCapitalizedIssuer()
        Dim dsCapitalizedIssuer As New DSCapitalizedIssuer

        Me.DSCapitalizedIssuerBindingSource.DataMember = "TableCapitalizedIssuer"
        Me.DSCapitalizedIssuerBindingSource.DataSource = dsCapitalizedIssuer
        With Me.ReportViewerCapitalizedIssuer
            .Visible = True
            .Dock = DockStyle.Fill
            .SetDisplayMode(DisplayMode.PrintLayout)
            .ZoomMode = ZoomMode.Percent
            .ZoomPercent = 100%
        End With
    End Sub

    Private Sub LoadReportExpenseIssuer()
        Dim dsExpenseIssuer As New DSExpenseIssuer

        Me.DSExpenseIssuerBindingSource.DataMember = "TableExpenseIssuer"
        Me.DSExpenseIssuerBindingSource.DataSource = dsExpenseIssuer
        With Me.ReportViewerExpenseIssuer
            .Visible = True
            .Dock = DockStyle.Fill
            .SetDisplayMode(DisplayMode.PrintLayout)
            .ZoomMode = ZoomMode.Percent
            .ZoomPercent = 100%
        End With
    End Sub

    Private Sub LoadReportSalesIssuer()
        Dim dsSalesIssuer As New DSSalesIssuer

        Me.DSSalesIssuerBindingSource.DataMember = "TableSalesIssuer"
        Me.DSSalesIssuerBindingSource.DataSource = dsSalesIssuer
        With Me.ReportViewerSalesIssuer
            .Visible = True
            .Dock = DockStyle.Fill
            .SetDisplayMode(DisplayMode.PrintLayout)
            .ZoomMode = ZoomMode.Percent
            .ZoomPercent = 100%
        End With
    End Sub
End Class