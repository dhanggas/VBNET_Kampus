Public Class CariLaporanPenjualan

    Private Sub btnPreview_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPreview.Click
        LaporanPenjualan.ShowDialog()
    End Sub
    Private Sub CariLaporan_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        OptToday.Checked = True
        txtToday.Text = Format(Now, "dd MMMM yyyy")
        DateTimePicker1.Text = Format(Now, "dd MMMM yyyy")
        DateTimePicker2.Text = Format(Now, "dd MMMM yyyy")
    End Sub

    Private Sub OptFrom_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OptFrom.CheckedChanged
        If OptFrom.Checked = True Then
            DateTimePicker1.Enabled = True
            DateTimePicker2.Enabled = True
        Else
            DateTimePicker1.Enabled = False
            DateTimePicker2.Enabled = False
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.Close()
    End Sub
End Class