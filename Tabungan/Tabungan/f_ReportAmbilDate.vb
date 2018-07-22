Imports Microsoft.Reporting.WinForms
Public Class f_ReportAmbilDate

    Private Sub f_ReportAmbilDate_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'dbtabunganDataSet.pengambilan' table. You can move, or remove it, as needed.
        Me.pengambilanTableAdapter.Fill(Me.dbtabunganDataSet.pengambilan)

        Me.ReportViewer1.RefreshReport()
        Me.ReportViewer1.RefreshReport()
        Me.ReportViewer1.RefreshReport()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim tgl_1 As New ReportParameter("tgl1", Format(DateTimePicker1.Value, "yyyy-MM-dd"))
        Dim tgl_2 As New ReportParameter("tgl2", Format(DateTimePicker2.Value, "yyyy-MM-dd"))
        With Me
            .ReportViewer1.RefreshReport()

            .ReportViewer1.LocalReport.SetParameters(tgl_1)
            .ReportViewer1.LocalReport.SetParameters(tgl_2)
            .ReportViewer1.RefreshReport()

        End With
    End Sub
End Class