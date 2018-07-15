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
        Me.DSBranchDetailsBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DSSupplierDetailsBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DSStoreDetailsBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DSCustomerDetailsBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DSCustomerDetailsStockBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DSStockDetailsBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.BranchDetailsReportViewer = New Microsoft.Reporting.WinForms.ReportViewer()
        Me.SupplierDetailsReportViewer = New Microsoft.Reporting.WinForms.ReportViewer()
        Me.StoreDetailsReportViewer = New Microsoft.Reporting.WinForms.ReportViewer()
        Me.CustomerDetailsReportViewer = New Microsoft.Reporting.WinForms.ReportViewer()
        Me.CustomerDetailsStockReportViewer = New Microsoft.Reporting.WinForms.ReportViewer()
        Me.StockDetailsReportViewer = New Microsoft.Reporting.WinForms.ReportViewer()
        CType(Me.DSBranchDetailsBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DSSupplierDetailsBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DSStoreDetailsBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DSCustomerDetailsBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DSCustomerDetailsStockBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DSStockDetailsBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BranchDetailsReportViewer
        '
        ReportDataSource1.Name = "DataSet1"
        ReportDataSource1.Value = Me.DSBranchDetailsBindingSource
        Me.BranchDetailsReportViewer.LocalReport.DataSources.Add(ReportDataSource1)
        Me.BranchDetailsReportViewer.LocalReport.ReportEmbeddedResource = "Inventory_System_NT_.BranchDetailsReport.rdlc"
        Me.BranchDetailsReportViewer.Location = New System.Drawing.Point(0, 0)
        Me.BranchDetailsReportViewer.Name = "BranchDetailsReportViewer"
        Me.BranchDetailsReportViewer.Size = New System.Drawing.Size(521, 34)
        Me.BranchDetailsReportViewer.TabIndex = 0
        '
        'SupplierDetailsReportViewer
        '
        ReportDataSource2.Name = "DataSet1"
        ReportDataSource2.Value = Me.DSSupplierDetailsBindingSource
        Me.SupplierDetailsReportViewer.LocalReport.DataSources.Add(ReportDataSource2)
        Me.SupplierDetailsReportViewer.LocalReport.ReportEmbeddedResource = "Inventory_System_NT_.SupplierDetailsReport.rdlc"
        Me.SupplierDetailsReportViewer.Location = New System.Drawing.Point(0, 40)
        Me.SupplierDetailsReportViewer.Name = "SupplierDetailsReportViewer"
        Me.SupplierDetailsReportViewer.Size = New System.Drawing.Size(521, 39)
        Me.SupplierDetailsReportViewer.TabIndex = 2
        '
        'StoreDetailsReportViewer
        '
        ReportDataSource3.Name = "DataSet1"
        ReportDataSource3.Value = Me.DSStoreDetailsBindingSource
        Me.StoreDetailsReportViewer.LocalReport.DataSources.Add(ReportDataSource3)
        Me.StoreDetailsReportViewer.LocalReport.ReportEmbeddedResource = "Inventory_System_NT_.ReportStoreDetails.rdlc"
        Me.StoreDetailsReportViewer.Location = New System.Drawing.Point(0, 86)
        Me.StoreDetailsReportViewer.Name = "StoreDetailsReportViewer"
        Me.StoreDetailsReportViewer.Size = New System.Drawing.Size(521, 51)
        Me.StoreDetailsReportViewer.TabIndex = 3
        '
        'CustomerDetailsReportViewer
        '
        ReportDataSource4.Name = "DataSet1"
        ReportDataSource4.Value = Me.DSCustomerDetailsBindingSource
        Me.CustomerDetailsReportViewer.LocalReport.DataSources.Add(ReportDataSource4)
        Me.CustomerDetailsReportViewer.LocalReport.ReportEmbeddedResource = "Inventory_System_NT_.ReportCustomerDetails.rdlc"
        Me.CustomerDetailsReportViewer.Location = New System.Drawing.Point(0, 143)
        Me.CustomerDetailsReportViewer.Name = "CustomerDetailsReportViewer"
        Me.CustomerDetailsReportViewer.Size = New System.Drawing.Size(521, 49)
        Me.CustomerDetailsReportViewer.TabIndex = 4
        '
        'CustomerDetailsStockReportViewer
        '
        ReportDataSource5.Name = "DataSet1"
        ReportDataSource5.Value = Me.DSCustomerDetailsStockBindingSource
        Me.CustomerDetailsStockReportViewer.LocalReport.DataSources.Add(ReportDataSource5)
        Me.CustomerDetailsStockReportViewer.LocalReport.ReportEmbeddedResource = "Inventory_System_NT_.ReportCustomerDetailsStock.rdlc"
        Me.CustomerDetailsStockReportViewer.Location = New System.Drawing.Point(0, 198)
        Me.CustomerDetailsStockReportViewer.Name = "CustomerDetailsStockReportViewer"
        Me.CustomerDetailsStockReportViewer.Size = New System.Drawing.Size(521, 55)
        Me.CustomerDetailsStockReportViewer.TabIndex = 5
        '
        'StockDetailsReportViewer
        '
        ReportDataSource6.Name = "DataSet1"
        ReportDataSource6.Value = Me.DSStockDetailsBindingSource
        Me.StockDetailsReportViewer.LocalReport.DataSources.Add(ReportDataSource6)
        Me.StockDetailsReportViewer.LocalReport.ReportEmbeddedResource = "Inventory_System_NT_.ReportStockDetails.rdlc"
        Me.StockDetailsReportViewer.Location = New System.Drawing.Point(0, 259)
        Me.StockDetailsReportViewer.Name = "StockDetailsReportViewer"
        Me.StockDetailsReportViewer.Size = New System.Drawing.Size(521, 46)
        Me.StockDetailsReportViewer.TabIndex = 6
        '
        'ReportForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(825, 477)
        Me.Controls.Add(Me.StockDetailsReportViewer)
        Me.Controls.Add(Me.CustomerDetailsStockReportViewer)
        Me.Controls.Add(Me.CustomerDetailsReportViewer)
        Me.Controls.Add(Me.StoreDetailsReportViewer)
        Me.Controls.Add(Me.SupplierDetailsReportViewer)
        Me.Controls.Add(Me.BranchDetailsReportViewer)
        Me.Name = "ReportForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "ReportForm"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.DSBranchDetailsBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DSSupplierDetailsBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DSStoreDetailsBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DSCustomerDetailsBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DSCustomerDetailsStockBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DSStockDetailsBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents BranchDetailsReportViewer As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents DSBranchDetailsBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents DSSupplierDetailsBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents SupplierDetailsReportViewer As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents StoreDetailsReportViewer As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents DSStoreDetailsBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents CustomerDetailsReportViewer As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents DSCustomerDetailsBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents CustomerDetailsStockReportViewer As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents DSCustomerDetailsStockBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents StockDetailsReportViewer As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents DSStockDetailsBindingSource As System.Windows.Forms.BindingSource
End Class
