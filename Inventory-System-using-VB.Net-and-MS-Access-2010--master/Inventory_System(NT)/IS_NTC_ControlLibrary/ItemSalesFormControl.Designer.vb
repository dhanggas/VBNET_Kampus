﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ItemSalesFormControl
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ItemSalesFormControl))
        Me.Label9 = New System.Windows.Forms.Label()
        Me.grdItemSales = New System.Windows.Forms.DataGridView()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.dtpDateOfBought = New System.Windows.Forms.DateTimePicker()
        Me.cboItemName = New System.Windows.Forms.ComboBox()
        Me.txtQuantity = New System.Windows.Forms.TextBox()
        Me.txtCustomerPhoneNumber = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.grpItemSales = New System.Windows.Forms.GroupBox()
        Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.txtItemName = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.pnlcboCustomerName = New System.Windows.Forms.Panel()
        Me.cboCustomerName = New System.Windows.Forms.ComboBox()
        Me.pnltxtCustomerName = New System.Windows.Forms.Panel()
        Me.txtCustomerName = New System.Windows.Forms.TextBox()
        Me.lblCustomerName = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Panel11 = New System.Windows.Forms.Panel()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.btnClear = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btnGetReport = New System.Windows.Forms.Button()
        Me.btnView = New System.Windows.Forms.Button()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.txtRecordPosition = New System.Windows.Forms.TextBox()
        Me.btnMoveLast = New System.Windows.Forms.Button()
        Me.btnMoveNext = New System.Windows.Forms.Button()
        Me.btnMovePrevious = New System.Windows.Forms.Button()
        Me.btnMoveFirst = New System.Windows.Forms.Button()
        Me.Panel7 = New System.Windows.Forms.Panel()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.btnRefresh = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.FlowLayoutPanel2 = New System.Windows.Forms.FlowLayoutPanel()
        Me.Panel8 = New System.Windows.Forms.Panel()
        Me.cboSearchCustomerName = New System.Windows.Forms.ComboBox()
        Me.chkCustomerName = New System.Windows.Forms.CheckBox()
        Me.pnlSearchCustomerPhoneNumber = New System.Windows.Forms.Panel()
        Me.txtSearchCustomerPhoneNumber = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.pnlSearchItemName = New System.Windows.Forms.Panel()
        Me.cboSearchItemName = New System.Windows.Forms.ComboBox()
        Me.chkItemName = New System.Windows.Forms.CheckBox()
        Me.pnlSearchDate = New System.Windows.Forms.Panel()
        Me.pnlSearchListOfOptionForDates = New System.Windows.Forms.Panel()
        Me.rdbNoOfDays = New System.Windows.Forms.RadioButton()
        Me.rdbDay = New System.Windows.Forms.RadioButton()
        Me.rdbYear = New System.Windows.Forms.RadioButton()
        Me.chkDate = New System.Windows.Forms.CheckBox()
        Me.pnlSelectADay = New System.Windows.Forms.Panel()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.dtpSearchSelectADay = New System.Windows.Forms.DateTimePicker()
        Me.pnlSelectNoOfDays = New System.Windows.Forms.Panel()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.dtpSearchEndingDate = New System.Windows.Forms.DateTimePicker()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.dtpSearchStartingDate = New System.Windows.Forms.DateTimePicker()
        Me.pnlSelectAYear = New System.Windows.Forms.Panel()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.dtpSearchSelectAYear = New System.Windows.Forms.DateTimePicker()
        Me.btnSearch = New System.Windows.Forms.Button()
        CType(Me.grdItemSales, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpItemSales.SuspendLayout()
        Me.FlowLayoutPanel1.SuspendLayout()
        Me.Panel5.SuspendLayout()
        Me.pnlcboCustomerName.SuspendLayout()
        Me.pnltxtCustomerName.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.Panel6.SuspendLayout()
        Me.Panel11.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel7.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.FlowLayoutPanel2.SuspendLayout()
        Me.Panel8.SuspendLayout()
        Me.pnlSearchCustomerPhoneNumber.SuspendLayout()
        Me.pnlSearchItemName.SuspendLayout()
        Me.pnlSearchDate.SuspendLayout()
        Me.pnlSearchListOfOptionForDates.SuspendLayout()
        Me.pnlSelectADay.SuspendLayout()
        Me.pnlSelectNoOfDays.SuspendLayout()
        Me.pnlSelectAYear.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label9
        '
        Me.Label9.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Times New Roman", 18.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(472, 250)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(253, 30)
        Me.Label9.TabIndex = 44
        Me.Label9.Text = "ITEM SALES FORM"
        '
        'grdItemSales
        '
        Me.grdItemSales.AllowUserToAddRows = False
        Me.grdItemSales.AllowUserToDeleteRows = False
        Me.grdItemSales.AllowUserToOrderColumns = True
        Me.grdItemSales.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.grdItemSales.BackgroundColor = System.Drawing.SystemColors.InactiveCaption
        Me.grdItemSales.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised
        Me.grdItemSales.ColumnHeadersHeight = 30
        Me.grdItemSales.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.grdItemSales.Dock = System.Windows.Forms.DockStyle.Top
        Me.grdItemSales.EnableHeadersVisualStyles = False
        Me.grdItemSales.Location = New System.Drawing.Point(0, 0)
        Me.grdItemSales.Name = "grdItemSales"
        Me.grdItemSales.ReadOnly = True
        Me.grdItemSales.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.grdItemSales.Size = New System.Drawing.Size(1161, 247)
        Me.grdItemSales.TabIndex = 43
        Me.grdItemSales.TabStop = False
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(-3, 7)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(106, 17)
        Me.Label7.TabIndex = 35
        Me.Label7.Text = "Customer Name:"
        '
        'dtpDateOfBought
        '
        Me.dtpDateOfBought.Location = New System.Drawing.Point(101, 3)
        Me.dtpDateOfBought.Name = "dtpDateOfBought"
        Me.dtpDateOfBought.Size = New System.Drawing.Size(218, 25)
        Me.dtpDateOfBought.TabIndex = 34
        '
        'cboItemName
        '
        Me.cboItemName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboItemName.FormattingEnabled = True
        Me.cboItemName.Location = New System.Drawing.Point(101, 3)
        Me.cboItemName.Name = "cboItemName"
        Me.cboItemName.Size = New System.Drawing.Size(218, 25)
        Me.cboItemName.TabIndex = 32
        '
        'txtQuantity
        '
        Me.txtQuantity.Location = New System.Drawing.Point(101, 3)
        Me.txtQuantity.MaxLength = 10
        Me.txtQuantity.Name = "txtQuantity"
        Me.txtQuantity.Size = New System.Drawing.Size(218, 25)
        Me.txtQuantity.TabIndex = 30
        '
        'txtCustomerPhoneNumber
        '
        Me.txtCustomerPhoneNumber.Location = New System.Drawing.Point(101, 3)
        Me.txtCustomerPhoneNumber.MaxLength = 13
        Me.txtCustomerPhoneNumber.Name = "txtCustomerPhoneNumber"
        Me.txtCustomerPhoneNumber.Size = New System.Drawing.Size(218, 25)
        Me.txtCustomerPhoneNumber.TabIndex = 28
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(-4, 6)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(99, 17)
        Me.Label3.TabIndex = 27
        Me.Label3.Text = "Phone Number:"
        '
        'grpItemSales
        '
        Me.grpItemSales.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.grpItemSales.Controls.Add(Me.FlowLayoutPanel1)
        Me.grpItemSales.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpItemSales.Location = New System.Drawing.Point(60, 279)
        Me.grpItemSales.Name = "grpItemSales"
        Me.grpItemSales.Size = New System.Drawing.Size(671, 289)
        Me.grpItemSales.TabIndex = 48
        Me.grpItemSales.TabStop = False
        Me.grpItemSales.Text = "Item Sales"
        '
        'FlowLayoutPanel1
        '
        Me.FlowLayoutPanel1.BackColor = System.Drawing.Color.Transparent
        Me.FlowLayoutPanel1.Controls.Add(Me.Panel5)
        Me.FlowLayoutPanel1.Controls.Add(Me.pnlcboCustomerName)
        Me.FlowLayoutPanel1.Controls.Add(Me.pnltxtCustomerName)
        Me.FlowLayoutPanel1.Controls.Add(Me.Panel2)
        Me.FlowLayoutPanel1.Controls.Add(Me.Panel4)
        Me.FlowLayoutPanel1.Controls.Add(Me.Panel6)
        Me.FlowLayoutPanel1.Controls.Add(Me.Panel11)
        Me.FlowLayoutPanel1.Controls.Add(Me.Panel1)
        Me.FlowLayoutPanel1.Controls.Add(Me.Panel3)
        Me.FlowLayoutPanel1.Controls.Add(Me.Panel7)
        Me.FlowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown
        Me.FlowLayoutPanel1.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FlowLayoutPanel1.Location = New System.Drawing.Point(7, 16)
        Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        Me.FlowLayoutPanel1.Size = New System.Drawing.Size(658, 266)
        Me.FlowLayoutPanel1.TabIndex = 50
        '
        'Panel5
        '
        Me.Panel5.BackColor = System.Drawing.Color.Transparent
        Me.Panel5.Controls.Add(Me.txtItemName)
        Me.Panel5.Controls.Add(Me.cboItemName)
        Me.Panel5.Controls.Add(Me.Label1)
        Me.Panel5.Location = New System.Drawing.Point(3, 3)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(322, 31)
        Me.Panel5.TabIndex = 55
        '
        'txtItemName
        '
        Me.txtItemName.Location = New System.Drawing.Point(101, 3)
        Me.txtItemName.MaxLength = 50
        Me.txtItemName.Name = "txtItemName"
        Me.txtItemName.Size = New System.Drawing.Size(218, 25)
        Me.txtItemName.TabIndex = 31
        Me.txtItemName.Visible = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.Label1.Location = New System.Drawing.Point(-3, 7)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(75, 17)
        Me.Label1.TabIndex = 9
        Me.Label1.Text = "Item Name:"
        '
        'pnlcboCustomerName
        '
        Me.pnlcboCustomerName.BackColor = System.Drawing.Color.Transparent
        Me.pnlcboCustomerName.Controls.Add(Me.cboCustomerName)
        Me.pnlcboCustomerName.Controls.Add(Me.Label7)
        Me.pnlcboCustomerName.Location = New System.Drawing.Point(3, 40)
        Me.pnlcboCustomerName.Name = "pnlcboCustomerName"
        Me.pnlcboCustomerName.Size = New System.Drawing.Size(322, 31)
        Me.pnlcboCustomerName.TabIndex = 56
        '
        'cboCustomerName
        '
        Me.cboCustomerName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCustomerName.FormattingEnabled = True
        Me.cboCustomerName.Location = New System.Drawing.Point(101, 2)
        Me.cboCustomerName.Name = "cboCustomerName"
        Me.cboCustomerName.Size = New System.Drawing.Size(218, 25)
        Me.cboCustomerName.TabIndex = 36
        '
        'pnltxtCustomerName
        '
        Me.pnltxtCustomerName.BackColor = System.Drawing.Color.Transparent
        Me.pnltxtCustomerName.Controls.Add(Me.txtCustomerName)
        Me.pnltxtCustomerName.Controls.Add(Me.lblCustomerName)
        Me.pnltxtCustomerName.Location = New System.Drawing.Point(3, 77)
        Me.pnltxtCustomerName.Name = "pnltxtCustomerName"
        Me.pnltxtCustomerName.Size = New System.Drawing.Size(322, 31)
        Me.pnltxtCustomerName.TabIndex = 57
        '
        'txtCustomerName
        '
        Me.txtCustomerName.Location = New System.Drawing.Point(101, 3)
        Me.txtCustomerName.MaxLength = 30
        Me.txtCustomerName.Name = "txtCustomerName"
        Me.txtCustomerName.Size = New System.Drawing.Size(218, 25)
        Me.txtCustomerName.TabIndex = 47
        '
        'lblCustomerName
        '
        Me.lblCustomerName.AutoSize = True
        Me.lblCustomerName.Location = New System.Drawing.Point(-4, 6)
        Me.lblCustomerName.Name = "lblCustomerName"
        Me.lblCustomerName.Size = New System.Drawing.Size(106, 17)
        Me.lblCustomerName.TabIndex = 48
        Me.lblCustomerName.Text = "Customer Name:"
        Me.lblCustomerName.Visible = False
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.Transparent
        Me.Panel2.Controls.Add(Me.txtCustomerPhoneNumber)
        Me.Panel2.Controls.Add(Me.Label3)
        Me.Panel2.Location = New System.Drawing.Point(3, 114)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(322, 31)
        Me.Panel2.TabIndex = 58
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.Transparent
        Me.Panel4.Controls.Add(Me.Label2)
        Me.Panel4.Controls.Add(Me.dtpDateOfBought)
        Me.Panel4.Location = New System.Drawing.Point(3, 151)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(322, 31)
        Me.Panel4.TabIndex = 58
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(-3, 9)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(38, 17)
        Me.Label2.TabIndex = 27
        Me.Label2.Text = "Date:"
        '
        'Panel6
        '
        Me.Panel6.BackColor = System.Drawing.Color.Transparent
        Me.Panel6.Controls.Add(Me.Label6)
        Me.Panel6.Controls.Add(Me.txtQuantity)
        Me.Panel6.Location = New System.Drawing.Point(3, 188)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(322, 31)
        Me.Panel6.TabIndex = 59
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(-3, 6)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(59, 17)
        Me.Label6.TabIndex = 27
        Me.Label6.Text = "Quantity:"
        '
        'Panel11
        '
        Me.Panel11.BackColor = System.Drawing.Color.Transparent
        Me.Panel11.Controls.Add(Me.btnSave)
        Me.Panel11.Controls.Add(Me.btnClear)
        Me.Panel11.Location = New System.Drawing.Point(3, 225)
        Me.Panel11.Name = "Panel11"
        Me.Panel11.Size = New System.Drawing.Size(322, 31)
        Me.Panel11.TabIndex = 72
        '
        'btnSave
        '
        Me.btnSave.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnSave.FlatAppearance.BorderColor = System.Drawing.SystemColors.ActiveCaption
        Me.btnSave.Image = CType(resources.GetObject("btnSave.Image"), System.Drawing.Image)
        Me.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSave.Location = New System.Drawing.Point(163, 1)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Padding = New System.Windows.Forms.Padding(40, 0, 35, 0)
        Me.btnSave.Size = New System.Drawing.Size(155, 28)
        Me.btnSave.TabIndex = 58
        Me.btnSave.Text = "Save"
        Me.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'btnClear
        '
        Me.btnClear.BackColor = System.Drawing.Color.Transparent
        Me.btnClear.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnClear.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.btnClear.Image = CType(resources.GetObject("btnClear.Image"), System.Drawing.Image)
        Me.btnClear.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnClear.Location = New System.Drawing.Point(3, 1)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Padding = New System.Windows.Forms.Padding(35, 0, 40, 0)
        Me.btnClear.Size = New System.Drawing.Size(154, 28)
        Me.btnClear.TabIndex = 59
        Me.btnClear.TabStop = False
        Me.btnClear.Text = "Clear"
        Me.btnClear.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnClear.UseVisualStyleBackColor = False
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Transparent
        Me.Panel1.Controls.Add(Me.btnGetReport)
        Me.Panel1.Controls.Add(Me.btnView)
        Me.Panel1.Location = New System.Drawing.Point(331, 3)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(322, 31)
        Me.Panel1.TabIndex = 70
        '
        'btnGetReport
        '
        Me.btnGetReport.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnGetReport.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.btnGetReport.Location = New System.Drawing.Point(164, 1)
        Me.btnGetReport.Name = "btnGetReport"
        Me.btnGetReport.Size = New System.Drawing.Size(154, 28)
        Me.btnGetReport.TabIndex = 60
        Me.btnGetReport.Text = "Get Report"
        Me.btnGetReport.UseVisualStyleBackColor = True
        '
        'btnView
        '
        Me.btnView.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnView.FlatAppearance.BorderColor = System.Drawing.SystemColors.ActiveCaption
        Me.btnView.FlatAppearance.BorderSize = 5
        Me.btnView.Image = CType(resources.GetObject("btnView.Image"), System.Drawing.Image)
        Me.btnView.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnView.Location = New System.Drawing.Point(4, 1)
        Me.btnView.Name = "btnView"
        Me.btnView.Padding = New System.Windows.Forms.Padding(40, 0, 40, 0)
        Me.btnView.Size = New System.Drawing.Size(154, 28)
        Me.btnView.TabIndex = 4
        Me.btnView.TabStop = False
        Me.btnView.Text = "View"
        Me.btnView.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnView.UseVisualStyleBackColor = True
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.Transparent
        Me.Panel3.Controls.Add(Me.txtRecordPosition)
        Me.Panel3.Controls.Add(Me.btnMoveLast)
        Me.Panel3.Controls.Add(Me.btnMoveNext)
        Me.Panel3.Controls.Add(Me.btnMovePrevious)
        Me.Panel3.Controls.Add(Me.btnMoveFirst)
        Me.Panel3.Location = New System.Drawing.Point(331, 40)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(322, 31)
        Me.Panel3.TabIndex = 71
        '
        'txtRecordPosition
        '
        Me.txtRecordPosition.Enabled = False
        Me.txtRecordPosition.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRecordPosition.Location = New System.Drawing.Point(80, 3)
        Me.txtRecordPosition.Name = "txtRecordPosition"
        Me.txtRecordPosition.Size = New System.Drawing.Size(163, 25)
        Me.txtRecordPosition.TabIndex = 63
        Me.txtRecordPosition.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'btnMoveLast
        '
        Me.btnMoveLast.Enabled = False
        Me.btnMoveLast.Image = CType(resources.GetObject("btnMoveLast.Image"), System.Drawing.Image)
        Me.btnMoveLast.Location = New System.Drawing.Point(287, 1)
        Me.btnMoveLast.Name = "btnMoveLast"
        Me.btnMoveLast.Size = New System.Drawing.Size(32, 28)
        Me.btnMoveLast.TabIndex = 62
        Me.btnMoveLast.TabStop = False
        Me.btnMoveLast.UseVisualStyleBackColor = True
        '
        'btnMoveNext
        '
        Me.btnMoveNext.Enabled = False
        Me.btnMoveNext.Image = CType(resources.GetObject("btnMoveNext.Image"), System.Drawing.Image)
        Me.btnMoveNext.Location = New System.Drawing.Point(249, 1)
        Me.btnMoveNext.Name = "btnMoveNext"
        Me.btnMoveNext.Size = New System.Drawing.Size(32, 28)
        Me.btnMoveNext.TabIndex = 61
        Me.btnMoveNext.TabStop = False
        Me.btnMoveNext.UseVisualStyleBackColor = True
        '
        'btnMovePrevious
        '
        Me.btnMovePrevious.Enabled = False
        Me.btnMovePrevious.Image = CType(resources.GetObject("btnMovePrevious.Image"), System.Drawing.Image)
        Me.btnMovePrevious.Location = New System.Drawing.Point(42, 1)
        Me.btnMovePrevious.Name = "btnMovePrevious"
        Me.btnMovePrevious.Size = New System.Drawing.Size(32, 28)
        Me.btnMovePrevious.TabIndex = 60
        Me.btnMovePrevious.TabStop = False
        Me.btnMovePrevious.UseVisualStyleBackColor = True
        '
        'btnMoveFirst
        '
        Me.btnMoveFirst.Enabled = False
        Me.btnMoveFirst.Image = CType(resources.GetObject("btnMoveFirst.Image"), System.Drawing.Image)
        Me.btnMoveFirst.Location = New System.Drawing.Point(4, 1)
        Me.btnMoveFirst.Name = "btnMoveFirst"
        Me.btnMoveFirst.Size = New System.Drawing.Size(32, 28)
        Me.btnMoveFirst.TabIndex = 59
        Me.btnMoveFirst.TabStop = False
        Me.btnMoveFirst.UseVisualStyleBackColor = True
        '
        'Panel7
        '
        Me.Panel7.BackColor = System.Drawing.Color.Transparent
        Me.Panel7.Controls.Add(Me.btnDelete)
        Me.Panel7.Controls.Add(Me.btnRefresh)
        Me.Panel7.Location = New System.Drawing.Point(331, 77)
        Me.Panel7.Name = "Panel7"
        Me.Panel7.Size = New System.Drawing.Size(322, 31)
        Me.Panel7.TabIndex = 73
        '
        'btnDelete
        '
        Me.btnDelete.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnDelete.Enabled = False
        Me.btnDelete.FlatAppearance.BorderColor = System.Drawing.SystemColors.ActiveCaption
        Me.btnDelete.FlatAppearance.BorderSize = 5
        Me.btnDelete.Image = CType(resources.GetObject("btnDelete.Image"), System.Drawing.Image)
        Me.btnDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnDelete.Location = New System.Drawing.Point(3, 2)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Padding = New System.Windows.Forms.Padding(35, 0, 30, 0)
        Me.btnDelete.Size = New System.Drawing.Size(155, 28)
        Me.btnDelete.TabIndex = 3
        Me.btnDelete.TabStop = False
        Me.btnDelete.Text = "Delete"
        Me.btnDelete.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnDelete.UseVisualStyleBackColor = True
        '
        'btnRefresh
        '
        Me.btnRefresh.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnRefresh.FlatAppearance.BorderColor = System.Drawing.SystemColors.ActiveCaption
        Me.btnRefresh.FlatAppearance.BorderSize = 5
        Me.btnRefresh.Image = CType(resources.GetObject("btnRefresh.Image"), System.Drawing.Image)
        Me.btnRefresh.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnRefresh.Location = New System.Drawing.Point(164, 2)
        Me.btnRefresh.Name = "btnRefresh"
        Me.btnRefresh.Padding = New System.Windows.Forms.Padding(40, 0, 25, 0)
        Me.btnRefresh.Size = New System.Drawing.Size(154, 28)
        Me.btnRefresh.TabIndex = 59
        Me.btnRefresh.TabStop = False
        Me.btnRefresh.Text = "Refresh"
        Me.btnRefresh.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnRefresh.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.GroupBox2.Controls.Add(Me.FlowLayoutPanel2)
        Me.GroupBox2.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.GroupBox2.Location = New System.Drawing.Point(735, 279)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(369, 289)
        Me.GroupBox2.TabIndex = 49
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Search"
        '
        'FlowLayoutPanel2
        '
        Me.FlowLayoutPanel2.BackColor = System.Drawing.Color.Transparent
        Me.FlowLayoutPanel2.Controls.Add(Me.Panel8)
        Me.FlowLayoutPanel2.Controls.Add(Me.pnlSearchCustomerPhoneNumber)
        Me.FlowLayoutPanel2.Controls.Add(Me.pnlSearchItemName)
        Me.FlowLayoutPanel2.Controls.Add(Me.pnlSearchDate)
        Me.FlowLayoutPanel2.Controls.Add(Me.pnlSelectADay)
        Me.FlowLayoutPanel2.Controls.Add(Me.pnlSelectNoOfDays)
        Me.FlowLayoutPanel2.Controls.Add(Me.pnlSelectAYear)
        Me.FlowLayoutPanel2.Controls.Add(Me.btnSearch)
        Me.FlowLayoutPanel2.FlowDirection = System.Windows.Forms.FlowDirection.TopDown
        Me.FlowLayoutPanel2.Location = New System.Drawing.Point(6, 15)
        Me.FlowLayoutPanel2.Name = "FlowLayoutPanel2"
        Me.FlowLayoutPanel2.Size = New System.Drawing.Size(354, 340)
        Me.FlowLayoutPanel2.TabIndex = 75
        '
        'Panel8
        '
        Me.Panel8.BackColor = System.Drawing.Color.Transparent
        Me.Panel8.Controls.Add(Me.cboSearchCustomerName)
        Me.Panel8.Controls.Add(Me.chkCustomerName)
        Me.Panel8.Location = New System.Drawing.Point(3, 3)
        Me.Panel8.Name = "Panel8"
        Me.Panel8.Size = New System.Drawing.Size(344, 28)
        Me.Panel8.TabIndex = 70
        '
        'cboSearchCustomerName
        '
        Me.cboSearchCustomerName.DropDownHeight = 139
        Me.cboSearchCustomerName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboSearchCustomerName.FormattingEnabled = True
        Me.cboSearchCustomerName.IntegralHeight = False
        Me.cboSearchCustomerName.Items.AddRange(New Object() {"NONE"})
        Me.cboSearchCustomerName.Location = New System.Drawing.Point(123, 2)
        Me.cboSearchCustomerName.Name = "cboSearchCustomerName"
        Me.cboSearchCustomerName.Size = New System.Drawing.Size(218, 25)
        Me.cboSearchCustomerName.TabIndex = 50
        Me.cboSearchCustomerName.Visible = False
        '
        'chkCustomerName
        '
        Me.chkCustomerName.AutoSize = True
        Me.chkCustomerName.Location = New System.Drawing.Point(6, 4)
        Me.chkCustomerName.Name = "chkCustomerName"
        Me.chkCustomerName.Size = New System.Drawing.Size(122, 21)
        Me.chkCustomerName.TabIndex = 78
        Me.chkCustomerName.Text = "Customer Name"
        Me.chkCustomerName.UseVisualStyleBackColor = True
        '
        'pnlSearchCustomerPhoneNumber
        '
        Me.pnlSearchCustomerPhoneNumber.BackColor = System.Drawing.Color.Transparent
        Me.pnlSearchCustomerPhoneNumber.Controls.Add(Me.txtSearchCustomerPhoneNumber)
        Me.pnlSearchCustomerPhoneNumber.Controls.Add(Me.Label17)
        Me.pnlSearchCustomerPhoneNumber.Location = New System.Drawing.Point(3, 37)
        Me.pnlSearchCustomerPhoneNumber.Name = "pnlSearchCustomerPhoneNumber"
        Me.pnlSearchCustomerPhoneNumber.Size = New System.Drawing.Size(344, 28)
        Me.pnlSearchCustomerPhoneNumber.TabIndex = 72
        Me.pnlSearchCustomerPhoneNumber.Visible = False
        '
        'txtSearchCustomerPhoneNumber
        '
        Me.txtSearchCustomerPhoneNumber.Location = New System.Drawing.Point(123, 2)
        Me.txtSearchCustomerPhoneNumber.Name = "txtSearchCustomerPhoneNumber"
        Me.txtSearchCustomerPhoneNumber.ReadOnly = True
        Me.txtSearchCustomerPhoneNumber.Size = New System.Drawing.Size(218, 25)
        Me.txtSearchCustomerPhoneNumber.TabIndex = 52
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(21, 5)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(99, 17)
        Me.Label17.TabIndex = 5
        Me.Label17.Text = "Phone Number:"
        '
        'pnlSearchItemName
        '
        Me.pnlSearchItemName.BackColor = System.Drawing.Color.Transparent
        Me.pnlSearchItemName.Controls.Add(Me.cboSearchItemName)
        Me.pnlSearchItemName.Controls.Add(Me.chkItemName)
        Me.pnlSearchItemName.Location = New System.Drawing.Point(3, 71)
        Me.pnlSearchItemName.Name = "pnlSearchItemName"
        Me.pnlSearchItemName.Size = New System.Drawing.Size(344, 28)
        Me.pnlSearchItemName.TabIndex = 73
        '
        'cboSearchItemName
        '
        Me.cboSearchItemName.DropDownHeight = 139
        Me.cboSearchItemName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboSearchItemName.FormattingEnabled = True
        Me.cboSearchItemName.IntegralHeight = False
        Me.cboSearchItemName.Location = New System.Drawing.Point(123, 2)
        Me.cboSearchItemName.Name = "cboSearchItemName"
        Me.cboSearchItemName.Size = New System.Drawing.Size(218, 25)
        Me.cboSearchItemName.TabIndex = 53
        Me.cboSearchItemName.Visible = False
        '
        'chkItemName
        '
        Me.chkItemName.AutoSize = True
        Me.chkItemName.Location = New System.Drawing.Point(6, 5)
        Me.chkItemName.Name = "chkItemName"
        Me.chkItemName.Size = New System.Drawing.Size(91, 21)
        Me.chkItemName.TabIndex = 79
        Me.chkItemName.Text = "Item Name"
        Me.chkItemName.UseVisualStyleBackColor = True
        '
        'pnlSearchDate
        '
        Me.pnlSearchDate.BackColor = System.Drawing.Color.Transparent
        Me.pnlSearchDate.Controls.Add(Me.pnlSearchListOfOptionForDates)
        Me.pnlSearchDate.Controls.Add(Me.chkDate)
        Me.pnlSearchDate.Location = New System.Drawing.Point(3, 105)
        Me.pnlSearchDate.Name = "pnlSearchDate"
        Me.pnlSearchDate.Size = New System.Drawing.Size(344, 28)
        Me.pnlSearchDate.TabIndex = 80
        '
        'pnlSearchListOfOptionForDates
        '
        Me.pnlSearchListOfOptionForDates.BackColor = System.Drawing.Color.Transparent
        Me.pnlSearchListOfOptionForDates.Controls.Add(Me.rdbNoOfDays)
        Me.pnlSearchListOfOptionForDates.Controls.Add(Me.rdbDay)
        Me.pnlSearchListOfOptionForDates.Controls.Add(Me.rdbYear)
        Me.pnlSearchListOfOptionForDates.Location = New System.Drawing.Point(123, 0)
        Me.pnlSearchListOfOptionForDates.Name = "pnlSearchListOfOptionForDates"
        Me.pnlSearchListOfOptionForDates.Size = New System.Drawing.Size(218, 28)
        Me.pnlSearchListOfOptionForDates.TabIndex = 82
        Me.pnlSearchListOfOptionForDates.Visible = False
        '
        'rdbNoOfDays
        '
        Me.rdbNoOfDays.AutoSize = True
        Me.rdbNoOfDays.Location = New System.Drawing.Point(63, 4)
        Me.rdbNoOfDays.Name = "rdbNoOfDays"
        Me.rdbNoOfDays.Size = New System.Drawing.Size(95, 21)
        Me.rdbNoOfDays.TabIndex = 76
        Me.rdbNoOfDays.TabStop = True
        Me.rdbNoOfDays.Text = "No. of Days"
        Me.rdbNoOfDays.UseVisualStyleBackColor = True
        '
        'rdbDay
        '
        Me.rdbDay.AutoSize = True
        Me.rdbDay.Location = New System.Drawing.Point(167, 4)
        Me.rdbDay.Name = "rdbDay"
        Me.rdbDay.Size = New System.Drawing.Size(48, 21)
        Me.rdbDay.TabIndex = 81
        Me.rdbDay.TabStop = True
        Me.rdbDay.Text = "Day"
        Me.rdbDay.UseVisualStyleBackColor = True
        '
        'rdbYear
        '
        Me.rdbYear.AutoSize = True
        Me.rdbYear.Location = New System.Drawing.Point(3, 4)
        Me.rdbYear.Name = "rdbYear"
        Me.rdbYear.Size = New System.Drawing.Size(52, 21)
        Me.rdbYear.TabIndex = 77
        Me.rdbYear.TabStop = True
        Me.rdbYear.Text = "Year"
        Me.rdbYear.UseVisualStyleBackColor = True
        '
        'chkDate
        '
        Me.chkDate.AutoSize = True
        Me.chkDate.Location = New System.Drawing.Point(6, 4)
        Me.chkDate.Name = "chkDate"
        Me.chkDate.Size = New System.Drawing.Size(54, 21)
        Me.chkDate.TabIndex = 80
        Me.chkDate.Text = "Date"
        Me.chkDate.UseVisualStyleBackColor = True
        '
        'pnlSelectADay
        '
        Me.pnlSelectADay.BackColor = System.Drawing.Color.Transparent
        Me.pnlSelectADay.Controls.Add(Me.Label10)
        Me.pnlSelectADay.Controls.Add(Me.dtpSearchSelectADay)
        Me.pnlSelectADay.Location = New System.Drawing.Point(3, 139)
        Me.pnlSelectADay.Name = "pnlSelectADay"
        Me.pnlSelectADay.Size = New System.Drawing.Size(344, 28)
        Me.pnlSelectADay.TabIndex = 74
        Me.pnlSelectADay.Visible = False
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(21, 2)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(82, 17)
        Me.Label10.TabIndex = 55
        Me.Label10.Text = "Select a Day:"
        '
        'dtpSearchSelectADay
        '
        Me.dtpSearchSelectADay.Location = New System.Drawing.Point(123, 2)
        Me.dtpSearchSelectADay.Name = "dtpSearchSelectADay"
        Me.dtpSearchSelectADay.Size = New System.Drawing.Size(218, 25)
        Me.dtpSearchSelectADay.TabIndex = 54
        Me.dtpSearchSelectADay.Value = New Date(2014, 12, 1, 7, 54, 12, 0)
        '
        'pnlSelectNoOfDays
        '
        Me.pnlSelectNoOfDays.BackColor = System.Drawing.Color.Transparent
        Me.pnlSelectNoOfDays.Controls.Add(Me.Label14)
        Me.pnlSelectNoOfDays.Controls.Add(Me.dtpSearchEndingDate)
        Me.pnlSelectNoOfDays.Controls.Add(Me.Label13)
        Me.pnlSelectNoOfDays.Controls.Add(Me.dtpSearchStartingDate)
        Me.pnlSelectNoOfDays.Location = New System.Drawing.Point(3, 173)
        Me.pnlSelectNoOfDays.Name = "pnlSelectNoOfDays"
        Me.pnlSelectNoOfDays.Size = New System.Drawing.Size(344, 56)
        Me.pnlSelectNoOfDays.TabIndex = 76
        Me.pnlSelectNoOfDays.Visible = False
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(22, 33)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(82, 17)
        Me.Label14.TabIndex = 57
        Me.Label14.Text = "Ending Date:"
        '
        'dtpSearchEndingDate
        '
        Me.dtpSearchEndingDate.Location = New System.Drawing.Point(123, 29)
        Me.dtpSearchEndingDate.Name = "dtpSearchEndingDate"
        Me.dtpSearchEndingDate.Size = New System.Drawing.Size(218, 25)
        Me.dtpSearchEndingDate.TabIndex = 56
        Me.dtpSearchEndingDate.Value = New Date(2014, 12, 1, 7, 54, 12, 0)
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(21, 6)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(87, 17)
        Me.Label13.TabIndex = 55
        Me.Label13.Text = "Starting Date:"
        '
        'dtpSearchStartingDate
        '
        Me.dtpSearchStartingDate.Location = New System.Drawing.Point(123, 2)
        Me.dtpSearchStartingDate.Name = "dtpSearchStartingDate"
        Me.dtpSearchStartingDate.Size = New System.Drawing.Size(218, 25)
        Me.dtpSearchStartingDate.TabIndex = 54
        Me.dtpSearchStartingDate.Value = New Date(2014, 12, 1, 7, 54, 12, 0)
        '
        'pnlSelectAYear
        '
        Me.pnlSelectAYear.BackColor = System.Drawing.Color.Transparent
        Me.pnlSelectAYear.Controls.Add(Me.Label12)
        Me.pnlSelectAYear.Controls.Add(Me.dtpSearchSelectAYear)
        Me.pnlSelectAYear.Location = New System.Drawing.Point(3, 235)
        Me.pnlSelectAYear.Name = "pnlSelectAYear"
        Me.pnlSelectAYear.Size = New System.Drawing.Size(344, 28)
        Me.pnlSelectAYear.TabIndex = 75
        Me.pnlSelectAYear.Visible = False
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(22, 8)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(86, 17)
        Me.Label12.TabIndex = 55
        Me.Label12.Text = "Select a Year:"
        '
        'dtpSearchSelectAYear
        '
        Me.dtpSearchSelectAYear.CustomFormat = """yyyy"""
        Me.dtpSearchSelectAYear.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpSearchSelectAYear.Location = New System.Drawing.Point(123, 2)
        Me.dtpSearchSelectAYear.Name = "dtpSearchSelectAYear"
        Me.dtpSearchSelectAYear.ShowUpDown = True
        Me.dtpSearchSelectAYear.Size = New System.Drawing.Size(218, 25)
        Me.dtpSearchSelectAYear.TabIndex = 54
        Me.dtpSearchSelectAYear.Value = New Date(2014, 6, 24, 0, 0, 0, 0)
        '
        'btnSearch
        '
        Me.btnSearch.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnSearch.Enabled = False
        Me.btnSearch.FlatAppearance.BorderColor = System.Drawing.SystemColors.ActiveCaption
        Me.btnSearch.FlatAppearance.BorderSize = 5
        Me.btnSearch.Image = CType(resources.GetObject("btnSearch.Image"), System.Drawing.Image)
        Me.btnSearch.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSearch.Location = New System.Drawing.Point(3, 269)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Padding = New System.Windows.Forms.Padding(40, 0, 25, 0)
        Me.btnSearch.Size = New System.Drawing.Size(154, 28)
        Me.btnSearch.TabIndex = 81
        Me.btnSearch.TabStop = False
        Me.btnSearch.Text = "Search"
        Me.btnSearch.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnSearch.UseVisualStyleBackColor = True
        '
        'ItemSalesFormControl
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.grpItemSales)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.grdItemSales)
        Me.Name = "ItemSalesFormControl"
        Me.Size = New System.Drawing.Size(1161, 584)
        CType(Me.grdItemSales, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpItemSales.ResumeLayout(False)
        Me.FlowLayoutPanel1.ResumeLayout(False)
        Me.Panel5.ResumeLayout(False)
        Me.Panel5.PerformLayout()
        Me.pnlcboCustomerName.ResumeLayout(False)
        Me.pnlcboCustomerName.PerformLayout()
        Me.pnltxtCustomerName.ResumeLayout(False)
        Me.pnltxtCustomerName.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        Me.Panel6.ResumeLayout(False)
        Me.Panel6.PerformLayout()
        Me.Panel11.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.Panel7.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.FlowLayoutPanel2.ResumeLayout(False)
        Me.Panel8.ResumeLayout(False)
        Me.Panel8.PerformLayout()
        Me.pnlSearchCustomerPhoneNumber.ResumeLayout(False)
        Me.pnlSearchCustomerPhoneNumber.PerformLayout()
        Me.pnlSearchItemName.ResumeLayout(False)
        Me.pnlSearchItemName.PerformLayout()
        Me.pnlSearchDate.ResumeLayout(False)
        Me.pnlSearchDate.PerformLayout()
        Me.pnlSearchListOfOptionForDates.ResumeLayout(False)
        Me.pnlSearchListOfOptionForDates.PerformLayout()
        Me.pnlSelectADay.ResumeLayout(False)
        Me.pnlSelectADay.PerformLayout()
        Me.pnlSelectNoOfDays.ResumeLayout(False)
        Me.pnlSelectNoOfDays.PerformLayout()
        Me.pnlSelectAYear.ResumeLayout(False)
        Me.pnlSelectAYear.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents grdItemSales As System.Windows.Forms.DataGridView
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents dtpDateOfBought As System.Windows.Forms.DateTimePicker
    Friend WithEvents cboItemName As System.Windows.Forms.ComboBox
    Friend WithEvents txtQuantity As System.Windows.Forms.TextBox
    Friend WithEvents txtCustomerPhoneNumber As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents grpItemSales As System.Windows.Forms.GroupBox
    Friend WithEvents FlowLayoutPanel1 As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents Panel5 As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents pnlcboCustomerName As System.Windows.Forms.Panel
    Friend WithEvents cboCustomerName As System.Windows.Forms.ComboBox
    Friend WithEvents pnltxtCustomerName As System.Windows.Forms.Panel
    Friend WithEvents txtCustomerName As System.Windows.Forms.TextBox
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Panel6 As System.Windows.Forms.Panel
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtItemName As System.Windows.Forms.TextBox
    Friend WithEvents lblCustomerName As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel11 As System.Windows.Forms.Panel
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents btnClear As System.Windows.Forms.Button
    Friend WithEvents Panel7 As System.Windows.Forms.Panel
    Friend WithEvents btnDelete As System.Windows.Forms.Button
    Friend WithEvents btnRefresh As System.Windows.Forms.Button
    Friend WithEvents btnView As System.Windows.Forms.Button
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents txtRecordPosition As System.Windows.Forms.TextBox
    Friend WithEvents btnMoveLast As System.Windows.Forms.Button
    Friend WithEvents btnMoveNext As System.Windows.Forms.Button
    Friend WithEvents btnMovePrevious As System.Windows.Forms.Button
    Friend WithEvents btnMoveFirst As System.Windows.Forms.Button
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents FlowLayoutPanel2 As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents Panel8 As System.Windows.Forms.Panel
    Friend WithEvents cboSearchCustomerName As System.Windows.Forms.ComboBox
    Friend WithEvents chkCustomerName As System.Windows.Forms.CheckBox
    Friend WithEvents pnlSearchCustomerPhoneNumber As System.Windows.Forms.Panel
    Friend WithEvents txtSearchCustomerPhoneNumber As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents pnlSearchItemName As System.Windows.Forms.Panel
    Friend WithEvents cboSearchItemName As System.Windows.Forms.ComboBox
    Friend WithEvents chkItemName As System.Windows.Forms.CheckBox
    Friend WithEvents pnlSearchDate As System.Windows.Forms.Panel
    Friend WithEvents pnlSearchListOfOptionForDates As System.Windows.Forms.Panel
    Friend WithEvents rdbNoOfDays As System.Windows.Forms.RadioButton
    Friend WithEvents rdbDay As System.Windows.Forms.RadioButton
    Friend WithEvents rdbYear As System.Windows.Forms.RadioButton
    Friend WithEvents chkDate As System.Windows.Forms.CheckBox
    Friend WithEvents pnlSelectADay As System.Windows.Forms.Panel
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents dtpSearchSelectADay As System.Windows.Forms.DateTimePicker
    Friend WithEvents pnlSelectNoOfDays As System.Windows.Forms.Panel
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents dtpSearchEndingDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents dtpSearchStartingDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents pnlSelectAYear As System.Windows.Forms.Panel
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents dtpSearchSelectAYear As System.Windows.Forms.DateTimePicker
    Friend WithEvents btnSearch As System.Windows.Forms.Button
    Friend WithEvents btnGetReport As System.Windows.Forms.Button

End Class