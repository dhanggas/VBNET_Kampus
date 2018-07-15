<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ReportForm
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
        Dim ReportDataSource2 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource()
        Dim ReportDataSource3 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource()
        Dim ReportDataSource4 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource()
        Dim ReportDataSource5 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource()
        Dim ReportDataSource6 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource()
        Dim ReportDataSource7 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource()
        Me.DSItemEntranceBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DSItemSalesBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DSItemReceivedBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DSBranchIssuerBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DSCapitalizedIssuerBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DSExpenseIssuerBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ReportViewerItemEntrance = New Microsoft.Reporting.WinForms.ReportViewer()
        Me.ReportViewerItemSales = New Microsoft.Reporting.WinForms.ReportViewer()
        Me.ReportViewerItemReceived = New Microsoft.Reporting.WinForms.ReportViewer()
        Me.ReportViewerBranchIssuer = New Microsoft.Reporting.WinForms.ReportViewer()
        Me.ReportViewerCapitalizedIssuer = New Microsoft.Reporting.WinForms.ReportViewer()
        Me.ReportViewerExpenseIssuer = New Microsoft.Reporting.WinForms.ReportViewer()
        Me.ReportViewerSalesIssuer = New Microsoft.Reporting.WinForms.ReportViewer()
        Me.DSSalesIssuerBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        CType(Me.DSItemEntranceBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DSItemSalesBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DSItemReceivedBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DSBranchIssuerBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DSCapitalizedIssuerBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DSExpenseIssuerBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DSSalesIssuerBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ReportViewerItemEntrance
        '
        ReportDataSource1.Name = "DataSet1"
        ReportDataSource1.Value = Me.DSItemEntranceBindingSource
        Me.ReportViewerItemEntrance.LocalReport.DataSources.Add(ReportDataSource1)
        Me.ReportViewerItemEntrance.LocalReport.ReportEmbeddedResource = "IS_NTC_ControlLibrary.ReportItemEntrance.rdlc"
        Me.ReportViewerItemEntrance.Location = New System.Drawing.Point(1, 0)
        Me.ReportViewerItemEntrance.Name = "ReportViewerItemEntrance"
        Me.ReportViewerItemEntrance.Size = New System.Drawing.Size(413, 41)
        Me.ReportViewerItemEntrance.TabIndex = 0
        '
        'ReportViewerItemSales
        '
        ReportDataSource2.Name = "DataSet1"
        ReportDataSource2.Value = Me.DSItemSalesBindingSource
        Me.ReportViewerItemSales.LocalReport.DataSources.Add(ReportDataSource2)
        Me.ReportViewerItemSales.LocalReport.ReportEmbeddedResource = "IS_NTC_ControlLibrary.ReportItemSales.rdlc"
        Me.ReportViewerItemSales.Location = New System.Drawing.Point(1, 48)
        Me.ReportViewerItemSales.Name = "ReportViewerItemSales"
        Me.ReportViewerItemSales.Size = New System.Drawing.Size(413, 46)
        Me.ReportViewerItemSales.TabIndex = 1
        '
        'ReportViewerItemReceived
        '
        ReportDataSource3.Name = "DataSet1"
        ReportDataSource3.Value = Me.DSItemReceivedBindingSource
        Me.ReportViewerItemReceived.LocalReport.DataSources.Add(ReportDataSource3)
        Me.ReportViewerItemReceived.LocalReport.ReportEmbeddedResource = "IS_NTC_ControlLibrary.ReportItemReceived.rdlc"
        Me.ReportViewerItemReceived.Location = New System.Drawing.Point(1, 100)
        Me.ReportViewerItemReceived.Name = "ReportViewerItemReceived"
        Me.ReportViewerItemReceived.Size = New System.Drawing.Size(413, 36)
        Me.ReportViewerItemReceived.TabIndex = 2
        '
        'ReportViewerBranchIssuer
        '
        ReportDataSource4.Name = "DataSet1"
        ReportDataSource4.Value = Me.DSBranchIssuerBindingSource
        Me.ReportViewerBranchIssuer.LocalReport.DataSources.Add(ReportDataSource4)
        Me.ReportViewerBranchIssuer.LocalReport.ReportEmbeddedResource = "IS_NTC_ControlLibrary.ReportBranchIssuer.rdlc"
        Me.ReportViewerBranchIssuer.Location = New System.Drawing.Point(1, 143)
        Me.ReportViewerBranchIssuer.Name = "ReportViewerBranchIssuer"
        Me.ReportViewerBranchIssuer.Size = New System.Drawing.Size(413, 47)
        Me.ReportViewerBranchIssuer.TabIndex = 3
        '
        'ReportViewerCapitalizedIssuer
        '
        ReportDataSource5.Name = "DataSet1"
        ReportDataSource5.Value = Me.DSCapitalizedIssuerBindingSource
        Me.ReportViewerCapitalizedIssuer.LocalReport.DataSources.Add(ReportDataSource5)
        Me.ReportViewerCapitalizedIssuer.LocalReport.ReportEmbeddedResource = "IS_NTC_ControlLibrary.ReportCapitalizedIssuer.rdlc"
        Me.ReportViewerCapitalizedIssuer.Location = New System.Drawing.Point(1, 196)
        Me.ReportViewerCapitalizedIssuer.Name = "ReportViewerCapitalizedIssuer"
        Me.ReportViewerCapitalizedIssuer.Size = New System.Drawing.Size(413, 49)
        Me.ReportViewerCapitalizedIssuer.TabIndex = 4
        '
        'ReportViewerExpenseIssuer
        '
        ReportDataSource6.Name = "DataSet1"
        ReportDataSource6.Value = Me.DSExpenseIssuerBindingSource
        Me.ReportViewerExpenseIssuer.LocalReport.DataSources.Add(ReportDataSource6)
        Me.ReportViewerExpenseIssuer.LocalReport.ReportEmbeddedResource = "IS_NTC_ControlLibrary.ReportExpenseIssuer.rdlc"
        Me.ReportViewerExpenseIssuer.Location = New System.Drawing.Point(1, 251)
        Me.ReportViewerExpenseIssuer.Name = "ReportViewerExpenseIssuer"
        Me.ReportViewerExpenseIssuer.Size = New System.Drawing.Size(413, 57)
        Me.ReportViewerExpenseIssuer.TabIndex = 5
        '
        'ReportViewerSalesIssuer
        '
        ReportDataSource7.Name = "DataSet1"
        ReportDataSource7.Value = Me.DSSalesIssuerBindingSource
        Me.ReportViewerSalesIssuer.LocalReport.DataSources.Add(ReportDataSource7)
        Me.ReportViewerSalesIssuer.LocalReport.ReportEmbeddedResource = "IS_NTC_ControlLibrary.ReportSalesIssuer.rdlc"
        Me.ReportViewerSalesIssuer.Location = New System.Drawing.Point(1, 314)
        Me.ReportViewerSalesIssuer.Name = "ReportViewerSalesIssuer"
        Me.ReportViewerSalesIssuer.Size = New System.Drawing.Size(413, 64)
        Me.ReportViewerSalesIssuer.TabIndex = 6
        '
      
        'ReportForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(801, 482)
        Me.Controls.Add(Me.ReportViewerSalesIssuer)
        Me.Controls.Add(Me.ReportViewerExpenseIssuer)
        Me.Controls.Add(Me.ReportViewerCapitalizedIssuer)
        Me.Controls.Add(Me.ReportViewerBranchIssuer)
        Me.Controls.Add(Me.ReportViewerItemReceived)
        Me.Controls.Add(Me.ReportViewerItemSales)
        Me.Controls.Add(Me.ReportViewerItemEntrance)
        Me.Name = "ReportForm"
        Me.Text = "ReportForm"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.DSItemEntranceBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DSItemSalesBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DSItemReceivedBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DSBranchIssuerBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DSCapitalizedIssuerBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DSExpenseIssuerBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DSSalesIssuerBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ReportViewerItemEntrance As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents DSItemEntranceBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ReportViewerItemSales As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents DSItemSalesBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ReportViewerItemReceived As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents DSItemReceivedBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ReportViewerBranchIssuer As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents DSBranchIssuerBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ReportViewerCapitalizedIssuer As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents DSCapitalizedIssuerBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ReportViewerExpenseIssuer As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents DSExpenseIssuerBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ReportViewerSalesIssuer As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents DSSalesIssuerBindingSource As System.Windows.Forms.BindingSource
End Class
