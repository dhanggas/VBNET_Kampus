Public Class LaporanPenjualan

    Private Sub ReportViewer1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReportViewer1.Load

    End Sub

    Private Sub LaporanPenjualan_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'DbTokoBukuDataSet.T_PENJUALAN' table. You can move, or remove it, as needed.
        Me.T_PENJUALANTableAdapter.Fill(Me.DbTokoBukuDataSet.T_PENJUALAN)
        Me.ReportViewer1.RefreshReport()

        If CariLaporanPembelian.OptToday.Checked = True Then
            Me.T_PENJUALANTableAdapter.awal(Me.DbTokoBukuDataSet.T_PENJUALAN, CariLaporanPenjualan.txtToday.Text)
            Me.ReportViewer1.RefreshReport()
        Else
            Me.T_PENJUALANTableAdapter.tanggal(Me.DbTokoBukuDataSet.T_PENJUALAN, CariLaporanPenjualan.DateTimePicker1.Text, CariLaporanPenjualan.DateTimePicker2.Text)
            Me.ReportViewer1.RefreshReport()
        End If
    End Sub
End Class