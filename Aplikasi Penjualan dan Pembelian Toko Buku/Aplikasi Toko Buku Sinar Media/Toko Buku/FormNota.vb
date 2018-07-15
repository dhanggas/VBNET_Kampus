Public Class FormNota

    Private Sub FormNota_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'Nota.T_PENJUALAN' table. You can move, or remove it, as needed.
        Me.T_PENJUALANTableAdapter.trans(Me.Nota.T_PENJUALAN, FormTransaksiPenjualan.TxtKdTransBeli.Text)
        Me.ReportViewer1.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout)
        Me.ReportViewer1.ZoomMode = Microsoft.Reporting.WinForms.ZoomMode.FullPage
        Me.ReportViewer1.RefreshReport()
    End Sub
End Class