Public Class LaporanPembelian

    Private Sub LaporanPembelian_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'DbTokoBukuDataSet.T_PEMBELIAN' table. You can move, or remove it, as needed.

        Me.T_PEMBELIANTableAdapter.Fill(Me.DbTokoBukuDataSet.T_PEMBELIAN)
        Me.ReportViewer1.RefreshReport()
        If CariLaporanPembelian.OptToday.Checked = True Then
            Me.T_PEMBELIANTableAdapter.awal(Me.DbTokoBukuDataSet.T_PEMBELIAN, CariLaporanPembelian.txtToday.Text)
            Me.ReportViewer1.RefreshReport()
        Else
            Me.T_PEMBELIANTableAdapter.tanggal(Me.DbTokoBukuDataSet.T_PEMBELIAN, CariLaporanPembelian.DateTimePicker1.Text, CariLaporanPembelian.DateTimePicker2.Text)
            Me.ReportViewer1.RefreshReport()
        End If
    End Sub
End Class