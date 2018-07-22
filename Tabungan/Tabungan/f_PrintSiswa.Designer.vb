<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class f_PrintSiswa
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
        Me.components = New System.ComponentModel.Container()
        Dim ReportDataSource1 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource()
        Me.ReportViewer1 = New Microsoft.Reporting.WinForms.ReportViewer()
        Me.dbtabunganDataSet = New Tabungan.dbtabunganDataSet()
        Me.data_siswaBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.data_siswaTableAdapter = New Tabungan.dbtabunganDataSetTableAdapters.data_siswaTableAdapter()
        CType(Me.dbtabunganDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.data_siswaBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ReportViewer1
        '
        Me.ReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill
        ReportDataSource1.Name = "DataSet1"
        ReportDataSource1.Value = Me.data_siswaBindingSource
        Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource1)
        Me.ReportViewer1.LocalReport.ReportEmbeddedResource = "Tabungan.ReportSiswaTxt.rdlc"
        Me.ReportViewer1.Location = New System.Drawing.Point(0, 0)
        Me.ReportViewer1.Name = "ReportViewer1"
        Me.ReportViewer1.Size = New System.Drawing.Size(859, 472)
        Me.ReportViewer1.TabIndex = 0
        '
        'dbtabunganDataSet
        '
        Me.dbtabunganDataSet.DataSetName = "dbtabunganDataSet"
        Me.dbtabunganDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'data_siswaBindingSource
        '
        Me.data_siswaBindingSource.DataMember = "data_siswa"
        Me.data_siswaBindingSource.DataSource = Me.dbtabunganDataSet
        '
        'data_siswaTableAdapter
        '
        Me.data_siswaTableAdapter.ClearBeforeFill = True
        '
        'f_PrintSiswa
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(859, 472)
        Me.Controls.Add(Me.ReportViewer1)
        Me.Name = "f_PrintSiswa"
        Me.Text = "f_PrintSiswa"
        CType(Me.dbtabunganDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.data_siswaBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ReportViewer1 As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents data_siswaBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents dbtabunganDataSet As Tabungan.dbtabunganDataSet
    Friend WithEvents data_siswaTableAdapter As Tabungan.dbtabunganDataSetTableAdapters.data_siswaTableAdapter
End Class
