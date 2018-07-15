<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class LaporanPenjualan
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim ReportDataSource1 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource
        Me.ReportViewer1 = New Microsoft.Reporting.WinForms.ReportViewer
        Me.DbTokoBukuDataSet = New Toko_Buku.DbTokoBukuDataSet
        Me.T_PENJUALANBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.T_PENJUALANTableAdapter = New Toko_Buku.DbTokoBukuDataSetTableAdapters.T_PENJUALANTableAdapter
        CType(Me.DbTokoBukuDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.T_PENJUALANBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ReportViewer1
        '
        Me.ReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill
        ReportDataSource1.Name = "DbTokoBukuDataSet_T_PENJUALAN"
        ReportDataSource1.Value = Me.T_PENJUALANBindingSource
        Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource1)
        Me.ReportViewer1.LocalReport.ReportEmbeddedResource = "Toko_Buku.Report2.rdlc"
        Me.ReportViewer1.Location = New System.Drawing.Point(0, 0)
        Me.ReportViewer1.Name = "ReportViewer1"
        Me.ReportViewer1.Size = New System.Drawing.Size(748, 466)
        Me.ReportViewer1.TabIndex = 1
        '
        'DbTokoBukuDataSet
        '
        Me.DbTokoBukuDataSet.DataSetName = "DbTokoBukuDataSet"
        Me.DbTokoBukuDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'T_PENJUALANBindingSource
        '
        Me.T_PENJUALANBindingSource.DataMember = "T_PENJUALAN"
        Me.T_PENJUALANBindingSource.DataSource = Me.DbTokoBukuDataSet
        '
        'T_PENJUALANTableAdapter
        '
        Me.T_PENJUALANTableAdapter.ClearBeforeFill = True
        '
        'LaporanPenjualan
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(748, 466)
        Me.Controls.Add(Me.ReportViewer1)
        Me.Name = "LaporanPenjualan"
        Me.Text = "LaporanPenjualan"
        CType(Me.DbTokoBukuDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.T_PENJUALANBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ReportViewer1 As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents T_PENJUALANBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents DbTokoBukuDataSet As Toko_Buku.DbTokoBukuDataSet
    Friend WithEvents T_PENJUALANTableAdapter As Toko_Buku.DbTokoBukuDataSetTableAdapters.T_PENJUALANTableAdapter
End Class
