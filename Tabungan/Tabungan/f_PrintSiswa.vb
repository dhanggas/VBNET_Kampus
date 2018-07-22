Imports Microsoft.Reporting.WinForms
Public Class f_PrintSiswa

    Private Sub f_PrintSiswa_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'dbtabunganDataSet.data_siswa' table. You can move, or remove it, as needed.
        Dim NIS As New ReportParameter("Nis", f_DataSiswa.txtNIS.Text)
        ReportViewer1.LocalReport.SetParameters(NIS)
        Dim Nama As New ReportParameter("Nama", f_DataSiswa.txtNama_Siswa.Text)
        ReportViewer1.LocalReport.SetParameters(Nama)
        Dim Jk As New ReportParameter("Jk", f_DataSiswa.cmbJK.Text)
        ReportViewer1.LocalReport.SetParameters(Jk)
        Dim Alam As New ReportParameter("Alamat", f_DataSiswa.txtAlamat.Text)
        ReportViewer1.LocalReport.SetParameters(Alam)
        Dim Thn As New ReportParameter("Th_Ajar", f_DataSiswa.txtThn_Ajar.Text)
        ReportViewer1.LocalReport.SetParameters(Thn)
        Dim Kls As New ReportParameter("Kelas", f_DataSiswa.cmbKelas.Text)
        ReportViewer1.LocalReport.SetParameters(Kls)
        Dim Ortu As New ReportParameter("Ortu", f_DataSiswa.txtNama_Ortu.Text)
        ReportViewer1.LocalReport.SetParameters(Ortu)
        Dim Sald As New ReportParameter("Saldo", f_DataSiswa.txtSaldo.Text)
        ReportViewer1.LocalReport.SetParameters(Sald)
        Dim Ket As New ReportParameter("Ket", f_DataSiswa.cmbKet.Text)
        ReportViewer1.LocalReport.SetParameters(Ket)
        Dim User As New ReportParameter("user", f_MenuUtama.ToolStripStatusLabel2.Text)
        ReportViewer1.LocalReport.SetParameters(User)
        Me.ReportViewer1.RefreshReport()
    End Sub
End Class