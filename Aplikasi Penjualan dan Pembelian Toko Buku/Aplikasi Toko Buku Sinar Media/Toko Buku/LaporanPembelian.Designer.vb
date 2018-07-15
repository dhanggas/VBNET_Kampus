<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class LaporanPembelian
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
        Me.T_PEMBELIANBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.T_PEMBELIANTableAdapter = New Toko_Buku.DbTokoBukuDataSetTableAdapters.T_PEMBELIANTableAdapter
        CType(Me.DbTokoBukuDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.T_PEMBELIANBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ReportViewer1
        '
        Me.ReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill
        ReportDataSource1.Name = "DbTokoBukuDataSet_T_PEMBELIAN"
        ReportDataSource1.Value = Me.T_PEMBELIANBindingSource
        Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource1)
        Me.ReportViewer1.LocalReport.ReportEmbeddedResource = "Toko_Buku.Report1.rdlc"
        Me.ReportViewer1.Location = New System.Drawing.Point(0, 0)
        Me.ReportViewer1.Name = "ReportViewer1"
        Me.ReportViewer1.Size = New System.Drawing.Size(624, 416)
        Me.ReportViewer1.TabIndex = 0
        '
        'DbTokoBukuDataSet
        '
        Me.DbTokoBukuDataSet.DataSetName = "DbTokoBukuDataSet"
        Me.DbTokoBukuDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'T_PEMBELIANBindingSource
        '
        Me.T_PEMBELIANBindingSource.DataMember = "T_PEMBELIAN"
        Me.T_PEMBELIANBindingSource.DataSource = Me.DbTokoBukuDataSet
        '
        'T_PEMBELIANTableAdapter
        '
        Me.T_PEMBELIANTableAdapter.ClearBeforeFill = True
        '
        'LaporanPembelian
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(624, 416)
        Me.Controls.Add(Me.ReportViewer1)
        Me.Name = "LaporanPembelian"
        Me.Text = "LaporanPembelian"
        CType(Me.DbTokoBukuDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.T_PEMBELIANBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ReportViewer1 As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents T_PEMBELIANBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents DbTokoBukuDataSet As Toko_Buku.DbTokoBukuDataSet
    Friend WithEvents T_PEMBELIANTableAdapter As Toko_Buku.DbTokoBukuDataSetTableAdapters.T_PEMBELIANTableAdapter
End Class
