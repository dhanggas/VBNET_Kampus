Public Class Sales_IssuerFormControl
    Private stockAccess As New StockAccess
    Private objDataView As DataView
    Private objCurrencyManager As CurrencyManager
    Private dt As DataTable

    Private Sub Sales_IssuerFormControl_Load(sender As Object, e As EventArgs) Handles Me.Load
        If stockAccess.HasConnection = True Then
            Query()
            FillDataGridView()
            GetItemName()
            GetCustomerName()

            'MAKE SURE THAT THE SEARCHING CHECKLIST FOR SEARCH GROUPBOX ARE NOT SELECTED
            CheckedPropertyFalse()
        Else
            'Show error message
            MessageBox.Show(stockAccess.strExceptionHasConnection, My.Application.Info.Title, MessageBoxButtons.OK, MessageBoxIcon.Error)

            'Set variable to nothing
            stockAccess.strExceptionHasConnection = Nothing
        End If
    End Sub

    Private Sub Query()
        'Clear the existing records
        If stockAccess.objDataSet IsNot Nothing Then
            stockAccess.objDataSet.Clear()
        End If

        stockAccess.RunQuery("SELECT [Serial No],STOCK.Item_name, Customer_name, CUSTOMER.Customer_ph_no, Date_of_sale,  Quantity, Quantity_on_hand " & _
                             "FROM CUSTOMER, SALES, STOCK " & _
                             "WHERE CUSTOMER.Customer_ph_no = SALES.Customer_ph_no " & _
                             "AND SALES.Item_name= STOCK.Item_name " & _
                             "ORDER BY [Serial No]")

        If stockAccess.strExceptionRunQuery <> "" Then
            'Show error message
            MessageBox.Show(stockAccess.strExceptionRunQuery, My.Application.Info.Title, MessageBoxButtons.OK, MessageBoxIcon.Error)

            'Set the variable to nothing
            stockAccess.strExceptionRunQuery = Nothing
        Else
            dt = stockAccess.AutoNumberedTable(stockAccess.objDataSet.Tables(0))
            GblAccessObject.objDataTableOfSalesIssuerForm = dt

            'Set the DataView object to the DataSet object..
            objDataView = New DataView(dt)

            'Set the CurrencyManager object to the DataView object...
            objCurrencyManager = CType(Me.BindingContext(objDataView), CurrencyManager)
        End If

    End Sub

    Private Sub FillDataGridView()
        grdSalesIssuer.DataSource = objDataView

        grdSalesIssuer.Font = New Font(grdSalesIssuer.DefaultCellStyle.Font.FontFamily, 10, FontStyle.Regular)
        'Declare and set the column header style
        Dim objColumnHeaderStyle As New DataGridViewCellStyle
        objColumnHeaderStyle.BackColor = Color.Silver
        objColumnHeaderStyle.ForeColor = Color.Black
        objColumnHeaderStyle.Font = New Font(grdSalesIssuer.DefaultCellStyle.Font.FontFamily, 9, FontStyle.Bold)
        objColumnHeaderStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

        grdSalesIssuer.ColumnHeadersDefaultCellStyle = objColumnHeaderStyle

        'Declare and set the default rows style
        Dim objAlignRightCellStyle As New DataGridViewCellStyle
        objAlignRightCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        grdSalesIssuer.RowsDefaultCellStyle = objAlignRightCellStyle

        'Declare and set the alternating rows style
        Dim objAlternatingCellStyle As New DataGridViewCellStyle
        objAlternatingCellStyle.BackColor = Color.WhiteSmoke
        grdSalesIssuer.AlternatingRowsDefaultCellStyle = objAlternatingCellStyle

        With grdSalesIssuer
            .RowHeadersVisible = False
            .Columns(0).HeaderCell.Value = "S.N."
            .Columns(1).HeaderCell.Value = "ITEM NAME"
            .Columns(2).HeaderCell.Value = "CUSTOMER NAME"
            .Columns(3).HeaderCell.Value = "CUSTOMER PHONE NUMBER"
            .Columns(4).HeaderCell.Value = "DATE OF SALES"
            .Columns(5).HeaderCell.Value = "QUANTITY"
            .Columns(6).HeaderCell.Value = "CURRENT QUANTITY IN STOCK"
        End With
    End Sub

    Private Sub GetItemName()
        'Clear existing records..
        If stockAccess.objItemNameDataTable IsNot Nothing Then
            stockAccess.objItemNameDataTable.Clear()
        End If

        stockAccess.GetItemNameForComboBox("SELECT Item_name FROM STOCK " & _
                                           "ORDER BY Item_name")

        If stockAccess.strExceptionGetItemName <> "" Then
            'Display error message
            MessageBox.Show(stockAccess.strExceptionGetItemName)

            'Set the variable to nothing
            stockAccess.strExceptionGetItemName = Nothing
        Else
            stockAccess.objItemNameDataTable.Rows(0).Delete()
                cboItemName.DataSource = stockAccess.objItemNameDataTable
                cboItemName.DisplayMember = "Item_name"
        End If
    End Sub

    Private Sub GetCustomerName()
        'Clear existing records..
        If stockAccess.objCustomerNameDataTable IsNot Nothing Then
            stockAccess.objCustomerNameDataTable.Clear()
        End If

        stockAccess.GetCustomerNameForComboBox("SELECT Customer_ph_no, Customer_name FROM CUSTOMER " & _
                                               "ORDER BY Customer_name")

        If stockAccess.strExceptionGetCustomerName <> "" Then
            'Show error message
            MessageBox.Show(stockAccess.strExceptionGetCustomerName, My.Application.Info.Title, MessageBoxButtons.OK, MessageBoxIcon.Error)

            'Set the variable to nothing
            stockAccess.strExceptionGetCustomerName = Nothing
        Else
            'If records are found, add them to the combobox
            If stockAccess.objCustomerNameDataTable.Rows.Count > 0 Then
                cboCustomerName.DataSource = stockAccess.objCustomerNameDataTable
                cboCustomerName.DisplayMember = "Customer_name"
                cboCustomerName.SelectedIndex = 0
            End If
        End If
    End Sub






    'BIND THE CONTROLS TO THE DATAVIEW OBJECT
    Private Sub BindFields()
        'Clear any previous bindings
        ClearDataBindings()

        'Add new bindings to the DataView object..
        txtItemName.DataBindings.Add("Text", objDataView, "Item_name")
        txtCustomerName.DataBindings.Add("Text", objDataView, "Customer_name")
        txtCustomerPhoneNumber.DataBindings.Add("Text", objDataView, "Customer_ph_no")
        dtpDateOfSale.DataBindings.Add("Value", objDataView, "Date_of_sale")
        txtQuantity.DataBindings.Add("Text", objDataView, "Quantity")
    End Sub

    'CLEAR THE DATABINDINGS
    Private Sub ClearDataBindings()
        'Clear any previous bindings
        txtItemName.DataBindings.Clear()
        txtCustomerName.DataBindings.Clear()
        txtCustomerPhoneNumber.DataBindings.Clear()
        dtpDateOfSale.DataBindings.Clear()
        txtQuantity.DataBindings.Clear()
    End Sub

    'BIND THE CONTROLS WITH CUSTOMER DATATABLE
    Private Sub BindFieldsForCustomer()
        'Clear any previous bindings
        txtCustomerPhoneNumber.DataBindings.Clear()

        'Binding process
        txtCustomerPhoneNumber.DataBindings.Add("Text", stockAccess.objCustomerNameDataTable, "Customer_ph_no")
    End Sub

    Private Sub ShowPosition()
        'Display the current position and the number of records
        txtRecordPosition.Text = objCurrencyManager.Position + 1 & " of " & objCurrencyManager.Count()
    End Sub

    Private Sub cboCustomerName_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboCustomerName.SelectedIndexChanged
        If cboCustomerName.SelectedIndex <> 0 Then
            pnltxtCustomerName.Visible = False
            txtCustomerPhoneNumber.ReadOnly = True
            'grpItemSales.Size = New Size(341, 288)
            BindFieldsForCustomer()
        Else
            pnltxtCustomerName.Visible = True
            txtCustomerPhoneNumber.ReadOnly = False
            'grpItemSales.Size = New Size(341, 317)
            BindFieldsForCustomer()
        End If
    End Sub







    Private Sub btnMoveFirst_Click(sender As Object, e As EventArgs) Handles btnMoveFirst.Click
        'Set the record position to the first record..
        objCurrencyManager.Position = 0

        'Show the current record position
        ShowPosition()
    End Sub


    Private Sub btnMovePrevious_Click(sender As Object, e As EventArgs) Handles btnMovePrevious.Click
        'Set the record position to previous record..
        objCurrencyManager.Position -= 1

        'Show the current record positon
        ShowPosition()
    End Sub


    Private Sub btnMoveNext_Click(sender As Object, e As EventArgs) Handles btnMoveNext.Click
        'Set the record position to the next record..
        objCurrencyManager.Position += 1

        'Show the current record position
        ShowPosition()
    End Sub


    Private Sub btnMoveLast_Click(sender As Object, e As EventArgs) Handles btnMoveLast.Click
        'Set the record position to the last record..
        objCurrencyManager.Position = objCurrencyManager.Count - 1

        'Show the current record position
        ShowPosition()
    End Sub







    Private Sub btnView_Click(sender As Object, e As EventArgs) Handles btnView.Click
        If btnView.Text = "View" Then
            'Make sure the Item Name combobox is hidden and ItemName TextBox is visible
            cboItemName.Visible = False
            txtItemName.Visible = True

            'Make sure some panels are hidden and visible
            pnlcboCustomerName.Visible = False
            pnltxtCustomerName.Visible = True

            'Make sure the CustomerName label is visible
            lblCustomerName.Visible = True

            'Convert the View button text 
            btnView.Text = "Cancel View"

            'btnUpdate.Text = "Edit"

            'Buttons are enabled
            ViewEnabledButtons()

            'Disabled some buttons
            btnClear.Enabled = False
            btnSave.Enabled = False
            btnRefresh.Enabled = False
            chkCustomerName.Enabled = False
            chkItemName.Enabled = False
            chkDate.Enabled = False

            BindFields()
            ShowPosition()

            'Make sure that all the text fields readonly property is true
            ReadOnlyTrue()

            'Call CheckedPropertyFalse to unselect check list in the Search GroupBox
            CheckedPropertyFalse()
        Else
            ClearDataBindings()

            'Make sure the Item Name combobox is visible and ItemName TextBox is hidden
            cboItemName.Visible = True
            txtItemName.Visible = False

            'Make sure panels are visible
            pnlcboCustomerName.Visible = True

            'Make sure the CustomerName label is hidden
            lblCustomerName.Visible = False

            'Convert the View button text
            btnView.Text = "View"

            'btnUpdate.Text = "Update"

            'Buttons are disabled
            ViewDisabledButtons()

            'Enabled some buttons
            btnClear.Enabled = True
            btnSave.Enabled = True
            btnRefresh.Enabled = True
            chkCustomerName.Enabled = True
            chkItemName.Enabled = True
            chkDate.Enabled = True

            'Clear the RecordPosition TextBox 
            txtRecordPosition.Text = ""

            ClearFields()

            'Make sure that all the text fields readonly property is false
            ReadOnlyFalse()
        End If
    End Sub


    'CLEAR THE TEXTBOXES 
    Private Sub ClearFields()
        cboItemName.SelectedIndex = 0
        txtItemName.Clear()
        cboCustomerName.SelectedIndex = 0
        txtCustomerName.Clear()
        txtCustomerPhoneNumber.Clear()
        dtpDateOfSale.Value = Now
        txtQuantity.Clear()
        cboItemName.Focus()
    End Sub

    'MAKE BUTTONS ENABLED
    Private Sub ViewEnabledButtons()
        'btnUpdate.Enabled = True
        btnDelete.Enabled = True
        btnMoveFirst.Enabled = True
        btnMovePrevious.Enabled = True
        txtRecordPosition.Enabled = True
        btnMoveNext.Enabled = True
        btnMoveLast.Enabled = True
    End Sub

    'MAKE BUTTONS DISABLED
    Private Sub ViewDisabledButtons()
        'btnUpdate.Enabled = False
        btnDelete.Enabled = False
        btnMoveFirst.Enabled = False
        btnMovePrevious.Enabled = False
        txtRecordPosition.Enabled = False
        btnMoveNext.Enabled = False
        btnMoveLast.Enabled = False
        'txtRecordPosition.Text = ""
    End Sub

    'MAKE SURE THAT THE TEXT FIELDS READONLY PROPERTY IS FALSE
    Private Sub ReadOnlyFalse()
        txtItemName.ReadOnly = False
        txtCustomerName.ReadOnly = False
        txtCustomerPhoneNumber.ReadOnly = False
        txtQuantity.ReadOnly = False
    End Sub

    'MAKE SURE THAT THE TEXT FIELDS READONLY PROPERTY IS TRUE
    Private Sub ReadOnlyTrue()
        txtItemName.ReadOnly = True
        txtCustomerName.ReadOnly = True
        txtCustomerPhoneNumber.ReadOnly = True
        txtQuantity.ReadOnly = True
    End Sub

    Private Sub grdSalesIssuer_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles grdSalesIssuer.CellClick
        If btnView.Text <> "View" Then
            'Show position of the GridView row in the Record Position Text Box
            ShowPosition()
        End If
    End Sub


    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        'CLEAR THE TEXTBOXES
        ClearFields()
    End Sub








    'DELETE THE SALES DETAILS
    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        Dim objStringBuilder1 As New System.Text.StringBuilder
        Dim objStringBuilder2 As New System.Text.StringBuilder

        'Add the question
        objStringBuilder1.AppendLine("Do you really want to delete the information of this sold item?")
        objStringBuilder1.AppendLine(String.Empty)
        objStringBuilder1.AppendLine("INFO ABOUT CUSTOMER : " & txtCustomerName.Text & ", " & txtCustomerPhoneNumber.Text)
        objStringBuilder1.AppendLine("INFO ABOUT ITEM : " & txtItemName.Text)
        objStringBuilder1.AppendLine("DATE OF SOLD : " & dtpDateOfSale.Text)
        objStringBuilder1.AppendLine("QUANTITY : " & txtQuantity.Text)

        objStringBuilder2.AppendLine("Do you also want to ADD the quantity of item store in STOCK?")
        objStringBuilder2.AppendLine("INFO ABOUT ITEM : " & txtItemName.Text)
        objStringBuilder2.AppendLine("QUANTITY : " & txtQuantity.Text & " will also be added to the total quantity stored in STOCK.")

        If MessageBox.Show(objStringBuilder1.ToString, My.Application.Info.Title, _
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            Dim intDialogResult As DialogResult = MessageBox.Show(objStringBuilder2.ToString, My.Application.Info.Title, _
                               MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)
            Select Case intDialogResult
                Case DialogResult.Yes
                    DeleteSalesIssuerAndAddToStock()
                Case DialogResult.No
                    DeleteSalesIssuer()
                Case Else
                    'Do nothing
            End Select
        Else
            'Do nothing
        End If
    End Sub

    'DELETE THE INFORMATION FOR SALES ISSUER AND DO NOT ADD THE QUANTITY OF ITEM TO STOCK
    Private Sub DeleteSalesIssuer()
        Dim intPosition As Integer = objCurrencyManager.Position - 1
        If intPosition < 0 Then
            intPosition = 0
        End If

        stockAccess.DeleteSalesIssuerAndDoNotAddToStock(txtItemName.Text, dtpDateOfSale.Value.Date, txtCustomerPhoneNumber.Text)

        Dim objStringBuilder As New System.Text.StringBuilder

        'Add the question
        objStringBuilder.AppendLine("The following information has been deleted...!")
        objStringBuilder.AppendLine(String.Empty)
        objStringBuilder.AppendLine("INFO ABOUT CUSTOMER : " & txtCustomerName.Text & ", " & txtCustomerPhoneNumber.Text)
        objStringBuilder.AppendLine("INFO ABOUT ITEM : " & txtItemName.Text)
        objStringBuilder.AppendLine("DATE OF SOLD : " & dtpDateOfSale.Text)
        objStringBuilder.AppendLine("QUANTITY USED : " & txtQuantity.Text)

        Dim strExceptionDeleteSalesIssuer As String = stockAccess.strExceptionDeleteItemAsSalesAndDoNotAddToStock
        If strExceptionDeleteSalesIssuer <> "" Then
            MsgBox(strExceptionDeleteSalesIssuer)

            'Set the strExceptionDeleteItemAsSalesAndDoNotAddToStock to nothing
            stockAccess.strExceptionDeleteItemAsSalesAndDoNotAddToStock = Nothing
        Else
            MessageBox.Show(objStringBuilder.ToString, My.Application.Info.Title, _
                        MessageBoxButtons.OK, MessageBoxIcon.Information)
            Query()
            FillDataGridView()
            objCurrencyManager.Position = intPosition
            BindFields()
            ShowPosition()
        End If
    End Sub

    'DELETE THE ITEM SOLD DETAILS AND ALSO ADD THE QUANTITY OF ITEM TO THE STOCK
    Public Sub DeleteSalesIssuerAndAddToStock()
        Dim intPosition As Integer = objCurrencyManager.Position - 1
        If intPosition < 0 Then
            intPosition = 0
        End If

        stockAccess.DeleteSalesIssuerAndAddToStock(txtItemName.Text, dtpDateOfSale.Value.Date, txtCustomerPhoneNumber.Text, txtQuantity.Text)

        Dim objStringBuilder As New System.Text.StringBuilder

        'Add the question
        objStringBuilder.AppendLine("The following information has been deleted...!")
        objStringBuilder.AppendLine(String.Empty)
        objStringBuilder.AppendLine("INFO ABOUT CUSTOMER : " & txtCustomerName.Text & ", " & txtCustomerPhoneNumber.Text)
        objStringBuilder.AppendLine("INFO ABOUT ITEM : " & txtItemName.Text)
        objStringBuilder.AppendLine("DATE OF BOUGHT : " & dtpDateOfSale.Text)
        objStringBuilder.AppendLine("QUANTITY : " & txtQuantity.Text)
        objStringBuilder.AppendLine(String.Empty)
        objStringBuilder.AppendLine("QUANTITY ADDED TO STOCK : " & txtQuantity.Text)
        objStringBuilder.AppendLine("NOTE: The current quantity of item deleted is also added to the quantity of item stored in the STOCK.")

        Dim strExceptionDeleteSalesIssuer As String = stockAccess.strExceptionDeleteItemAsSalesAndAddToStock
        If strExceptionDeleteSalesIssuer <> "" Then
            MsgBox(strExceptionDeleteSalesIssuer)

            'Set the strExceptionDeleteItemAsSalesAndAddToStock to nothing
            stockAccess.strExceptionDeleteItemAsSalesAndAddToStock = Nothing
        Else
            MessageBox.Show(objStringBuilder.ToString, My.Application.Info.Title, _
                        MessageBoxButtons.OK, MessageBoxIcon.Information)
            Query()
            FillDataGridView()
            objCurrencyManager.Position = intPosition
            BindFields()
            ShowPosition()
        End If
    End Sub






    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If pnltxtCustomerName.Visible = True Then
            AddSalesIssuerAndCustomerDetails()
        Else
            AddSalesIssuerDetails()
        End If


    End Sub

    Private Sub AddSalesIssuerAndCustomerDetails()
        Dim objStringBuilder1 As New System.Text.StringBuilder
        Dim objStringBuilder2 As New System.Text.StringBuilder

        'Add the question
        objStringBuilder1.AppendLine("Do you want to add the following sales-issue information?")
        objStringBuilder1.AppendLine(String.Empty)
        objStringBuilder1.AppendLine("INFO ABOUT CUSTOMER : " & cboCustomerName.Text & ", " & txtCustomerPhoneNumber.Text)
        objStringBuilder1.AppendLine("INFO ABOUT ITEM : " & cboItemName.Text)
        objStringBuilder1.AppendLine("DATE OF SUPPLIED : " & dtpDateOfSale.Text)
        objStringBuilder1.AppendLine("QUANTITY SUPPLIED : " & txtQuantity.Text)

        objStringBuilder2.AppendLine("Do you also want to deduct the quantity of item store in STORE?")
        objStringBuilder2.AppendLine("INFO ABOUT ITEM : " & cboItemName.Text)
        objStringBuilder2.AppendLine("QUANTITY : " & txtQuantity.Text & " will also be deducted from the total amount stored in STORE.")

        If MessageBox.Show(objStringBuilder1.ToString, My.Application.Info.Title, _
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            Dim intDialogResult As DialogResult = MessageBox.Show(objStringBuilder2.ToString, My.Application.Info.Title, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)
            Select Case intDialogResult
                Case DialogResult.Yes
                    AddSalesIssuerAndCustomerAndDeductFromStock()
                    'Sales_IssuerFormControl_Load(Nothing, Nothing)
                   
                Case DialogResult.No
                    AddSalesIssuerAndCustomerAndNonDeductFromStock()
                    'Sales_IssuerFormControl_Load(Nothing, Nothing)
                   
                Case Else
                    'Do nothing

            End Select
        Else
            'Do nothing
        End If
    End Sub

    Private Sub AddSalesIssuerAndCustomerAndNonDeductFromStock()
        stockAccess.AddSalesIssuerAndCustomerAndNonDeductFromStock(cboItemName.Text, dtpDateOfSale.Value.Date, txtCustomerPhoneNumber.Text, txtCustomerName.Text, txtQuantity.Text)

        Dim objStringBuilder As New System.Text.StringBuilder
        objStringBuilder.AppendLine("The following new information has been added...!")
        objStringBuilder.AppendLine(String.Empty)
        objStringBuilder.AppendLine("INFO ABOUT NEW CUSTOMER : " & txtCustomerName.Text & ", " & txtCustomerPhoneNumber.Text)
        objStringBuilder.AppendLine("INFO ABOUT ITEM : " & cboItemName.Text)
        objStringBuilder.AppendLine("DATE OF SALE : " & dtpDateOfSale.Text)
        objStringBuilder.AppendLine("QUANTITY USED : " & txtQuantity.Text)

        Dim strExceptionItemAsSaleAndCustomerDetails As String = stockAccess.strExceptionAddItemAsSaleAndCustomerAndNonDeductFromStock
        If strExceptionItemAsSaleAndCustomerDetails <> "" Then
            MsgBox(strExceptionItemAsSaleAndCustomerDetails)

            'Set the strExceptionAddItemAsSaleAndCustomerAndNonDeductFromStock to nothing
            stockAccess.strExceptionAddItemAsSaleAndCustomerAndNonDeductFromStock = Nothing
        Else
            MessageBox.Show(objStringBuilder.ToString, My.Application.Info.Title, MessageBoxButtons.OK, MessageBoxIcon.Information)

            'Set stock quantity to zero if quantity is less than zero
            StockUpdateToZero.UpdateToZero()


            Query()
            FillDataGridView()
            GetCustomerName()
            ClearFields()

            'Set the record position to the last record..
            objCurrencyManager.Position = objCurrencyManager.Count - 1
        End If
    End Sub

    Private Sub AddSalesIssuerAndCustomerAndDeductFromStock()
        stockAccess.AddSalesIssuerAndCustomerAndDeductFromStock(cboItemName.Text, dtpDateOfSale.Value.Date, txtCustomerPhoneNumber.Text, txtCustomerName.Text, txtQuantity.Text)

        Dim objStringBuilder As New System.Text.StringBuilder
        objStringBuilder.AppendLine("The following new information has been added...!")
        objStringBuilder.AppendLine(String.Empty)
        objStringBuilder.AppendLine("INFO ABOUT NEW CUSTOMER : " & txtCustomerName.Text & ", " & txtCustomerPhoneNumber.Text)
        objStringBuilder.AppendLine("INFO ABOUT ITEM : " & cboItemName.Text)
        objStringBuilder.AppendLine("DATE OF SALE : " & dtpDateOfSale.Text)
        objStringBuilder.AppendLine("QUANTITY USED : " & txtQuantity.Text)
        objStringBuilder.AppendLine(String.Empty)
        objStringBuilder.AppendLine("QUANTITY SUBTRACTED FROM STOCK : " & txtQuantity.Text)
        objStringBuilder.AppendLine("NOTE: The current quantity of item sold is also deducted from the quantity of item stored in the STOCK.")

        Dim strExceptionItemAsSaleAndCustomerDetails As String = stockAccess.strExceptionAddItemAsSaleAndCustomerAndDeductFromStock
        If strExceptionItemAsSaleAndCustomerDetails <> "" Then
            MsgBox(strExceptionItemAsSaleAndCustomerDetails)

            'Set the strExceptionAddItemAsSaleAndCustomerAndDeductFromStock to nothing
            stockAccess.strExceptionAddItemAsSaleAndCustomerAndDeductFromStock = Nothing
        Else
            MessageBox.Show(objStringBuilder.ToString, My.Application.Info.Title, MessageBoxButtons.OK, MessageBoxIcon.Information)

            'Set stock quantity to zero if quantity is less than zero
            StockUpdateToZero.UpdateToZero()


            Query()
            FillDataGridView()
            GetCustomerName()
            ClearFields()

            'Set the record position to the last record..
            objCurrencyManager.Position = objCurrencyManager.Count - 1
        End If
    End Sub

    Private Sub AddSalesIssuerDetails()
        Dim objStringBuilder1 As New System.Text.StringBuilder
        Dim objStringBuilder2 As New System.Text.StringBuilder

        'Add the question
        objStringBuilder1.AppendLine("Do you want to add the following sales information?")
        objStringBuilder1.AppendLine(String.Empty)
        objStringBuilder1.AppendLine("INFO ABOUT CUSTOMER : " & cboCustomerName.Text & ", " & txtCustomerPhoneNumber.Text)
        objStringBuilder1.AppendLine("INFO ABOUT ITEM : " & cboItemName.Text)
        objStringBuilder1.AppendLine("DATE OF SUPPLIED : " & dtpDateOfSale.Text)
        objStringBuilder1.AppendLine("QUANTITY SUPPLIED : " & txtQuantity.Text)

        objStringBuilder2.AppendLine("Do you also want to deduct the quantity of item store in STORE?")
        objStringBuilder2.AppendLine("INFO ABOUT ITEM : " & cboItemName.Text)
        objStringBuilder2.AppendLine("QUANTITY : " & txtQuantity.Text & " will also be deducted from the total amount stored in STORE.")

        If MessageBox.Show(objStringBuilder1.ToString, My.Application.Info.Title, _
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            Dim intDialogResult As DialogResult = MessageBox.Show(objStringBuilder2.ToString, My.Application.Info.Title, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)
            Select Case intDialogResult
                Case DialogResult.Yes
                    AddSalesIssuerAndDeductFromStock()
                 
                Case DialogResult.No
                    AddSalesIssuerAndNonDeductFromStock()
                
                Case Else
                    'Do nothing

            End Select
        Else
            'Do nothing
        End If
    End Sub

    Private Sub AddSalesIssuerAndNonDeductFromStock()
        stockAccess.AddSalesIssuerAndNonDeductFromStock(cboItemName.Text, dtpDateOfSale.Value.Date, txtCustomerPhoneNumber.Text, txtQuantity.Text)

        Dim objStringBuilder As New System.Text.StringBuilder
        objStringBuilder.AppendLine("The following new information has been added...!")
        objStringBuilder.AppendLine(String.Empty)
        objStringBuilder.AppendLine("INFO ABOUT NEW CUSTOMER : " & cboCustomerName.Text & ", " & txtCustomerPhoneNumber.Text)
        objStringBuilder.AppendLine("INFO ABOUT ITEM : " & cboItemName.Text)
        objStringBuilder.AppendLine("DATE OF SALE : " & dtpDateOfSale.Text)
        objStringBuilder.AppendLine("QUANTITY USED : " & txtQuantity.Text)

        Dim strExceptionItemAsSaleDetails As String = stockAccess.strExceptionAddItemAsSaleAndNonDeductFromStock
        If strExceptionItemAsSaleDetails <> "" Then
            MsgBox(strExceptionItemAsSaleDetails)

            'Set the strExceptionAddItemAsSaleAndNonDeductFromStock to nothing
            stockAccess.strExceptionAddItemAsSaleAndNonDeductFromStock = Nothing
        Else
            MessageBox.Show(objStringBuilder.ToString, My.Application.Info.Title, MessageBoxButtons.OK, MessageBoxIcon.Information)

            'Set stock quantity to zero if quantity is less than zero
            StockUpdateToZero.UpdateToZero()


            Query()
            FillDataGridView()
            ClearFields()

            'Set the record position to the last record..
            objCurrencyManager.Position = objCurrencyManager.Count - 1
        End If
    End Sub

    Private Sub AddSalesIssuerAndDeductFromStock()
        stockAccess.AddSalesIssuerAndDeductFromStock(cboItemName.Text, dtpDateOfSale.Value.Date, txtCustomerPhoneNumber.Text, txtQuantity.Text)

        Dim objStringBuilder As New System.Text.StringBuilder
        objStringBuilder.AppendLine("The following new information has been added...!")
        objStringBuilder.AppendLine(String.Empty)
        objStringBuilder.AppendLine("INFO ABOUT NEW CUSTOMER : " & cboCustomerName.Text & ", " & txtCustomerPhoneNumber.Text)
        objStringBuilder.AppendLine("INFO ABOUT ITEM : " & cboItemName.Text)
        objStringBuilder.AppendLine("DATE OF SALE : " & dtpDateOfSale.Text)
        objStringBuilder.AppendLine("QUANTITY USED : " & txtQuantity.Text)
        objStringBuilder.AppendLine(String.Empty)
        objStringBuilder.AppendLine("QUANTITY SUBTRACTED FROM STOCK : " & txtQuantity.Text)
        objStringBuilder.AppendLine("NOTE: The current quantity of item sold is also deducted from the quantity of item stored in the STOCK.")

        Dim strExceptionItemAsSaleDetails As String = stockAccess.strExceptionAddItemAsSaleAndDeductFromStock
        If strExceptionItemAsSaleDetails <> "" Then
            MsgBox(strExceptionItemAsSaleDetails)

            'Set the strExceptionAddItemAsSaleAndDeductFromStockt to nothing
            stockAccess.strExceptionAddItemAsSaleAndDeductFromStock = Nothing
        Else
            MessageBox.Show(objStringBuilder.ToString, My.Application.Info.Title, MessageBoxButtons.OK, MessageBoxIcon.Information)

            'Set stock quantity to zero if quantity is less than zero
            StockUpdateToZero.UpdateToZero()


            Query()
            FillDataGridView()
            ClearFields()

            'Set the record position to the last record..
            objCurrencyManager.Position = objCurrencyManager.Count - 1
        End If
    End Sub

    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        Sales_IssuerFormControl_Load(Nothing, Nothing)
    End Sub






    Private Sub cboSearchCustomerName_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboSearchCustomerName.SelectedIndexChanged
        BindFieldsForCustomerForSearching()
    End Sub

    'QUERY TO FILL CUSTOMER NAME COMBOBOX FOR SEARCHING
    Private Sub GetCustomerNameForSearching()
        'Clear the existing records..
        If stockAccess.objCustomerNameDataTableForSearching IsNot Nothing Then
            stockAccess.objCustomerNameDataTableForSearching.Clear()
        End If

        stockAccess.GetCustomerNameForSearchingComboBox("SELECT * FROM CUSTOMER " & _
                                               "ORDER BY Customer_name")

        If stockAccess.strExceptionGetCustomerNameForSearching <> "" Then
            'Show error message
            MessageBox.Show(stockAccess.strExceptionGetCustomerNameForSearching, My.Application.Info.Title, MessageBoxButtons.OK, MessageBoxIcon.Error)

            'Set the variable to nothing
            stockAccess.strExceptionGetCustomerNameForSearching = Nothing
        Else
            cboSearchCustomerName.DataSource = stockAccess.objCustomerNameDataTableForSearching
            cboSearchCustomerName.DisplayMember = "Customer_name"
        End If
    End Sub

    'BIND VALUES FOR CUSTOMER PHONE NUMBER
    Private Sub BindFieldsForCustomerForSearching()
        'Clear any previous bindings..
        txtSearchCustomerPhoneNumber.DataBindings.Clear()

        'Binding process
        txtSearchCustomerPhoneNumber.DataBindings.Add("Text", stockAccess.objCustomerNameDataTableForSearching, "Customer_ph_no")
    End Sub


    'QUERY TO FILL ITEMNAME COMBOBOX FOR SEARCHING
    Private Sub GetItemNameforSearching()
        'Clear existing records
        If stockAccess.objItemNameDataTableForSearching IsNot Nothing Then
            stockAccess.objItemNameDataTableForSearching.Clear()
        End If

        stockAccess.GetItemNameForSearchingComboBox("SELECT Item_name FROM STOCK " & _
                                               "ORDER BY Item_name")


        If stockAccess.strExceptionGetItemNameForSearching <> "" Then
            'Show error message
            MessageBox.Show(stockAccess.strExceptionGetItemNameForSearching, My.Application.Info.Title, MessageBoxButtons.OK, MessageBoxIcon.Error)

            'Set the variable to nothing
            stockAccess.strExceptionGetItemNameForSearching = Nothing
        Else
            cboSearchItemName.DataSource = stockAccess.objItemNameDataTableForSearching
            cboSearchItemName.DisplayMember = "Item_name"
        End If
    End Sub

    'CHECKING CHECKED PROPERTY OF CHECKBOX AND RADIOBUTTON TO ENABLE OR DISABLE THE SEARCH BUTTON
    Private Sub CheckBoxClick()
        If chkDate.Checked = True Or chkItemName.Checked = True Or chkCustomerName.Checked = True Then
            btnSearch.Enabled = True
        ElseIf chkDate.Checked = False Or chkItemName.Checked = False Or chkCustomerName.Checked = False Then
            btnSearch.Enabled = False
        End If
    End Sub

    'UNSELECT THE CHECKED PROPERTY OF CHECKBOX AND RADIOBUTTON
    Private Sub CheckedPropertyFalse()
        'Make sure that Searching checklist are not selected
        chkCustomerName.Checked = False
        chkItemName.Checked = False
        chkDate.Checked = False
    End Sub

    Private Sub chkCustomerName_CheckedChanged(sender As Object, e As EventArgs) Handles chkCustomerName.CheckedChanged
        If chkCustomerName.Checked = True Then
            'Get list of item for combo box
            GetCustomerNameForSearching()

            'Make corresponding controls visible
            cboSearchCustomerName.Visible = True
            pnlSearchCustomerPhoneNumber.Visible = True
        Else
            'Set the DataTable to nothing
            stockAccess.objCustomerNameDataTableForSearching = Nothing

            'Clear databindings for Customer control
            txtSearchCustomerPhoneNumber.DataBindings.Clear()

            'Make corresponding controls hidden
            cboSearchCustomerName.Visible = False
            pnlSearchCustomerPhoneNumber.Visible = False
        End If

        'Call CheckBoxClick procedure
        CheckBoxClick()
    End Sub


 Private Sub chkItemName_CheckedChanged(sender As Object, e As EventArgs) Handles chkItemName.CheckedChanged
        If chkItemName.Checked = True Then
            'Get a list of item for combobox
            GetItemNameforSearching()

            'Make Search ItemName Combobox visible
            cboSearchItemName.Visible = True
        Else
            'Set the DataTable to nothing
            stockAccess.objItemNameDataTableForSearching = Nothing

            'Make Search ItemName Combobox hidden
            cboSearchItemName.Visible = False
        End If

        'Call CheckBoxClick procedure
        CheckBoxClick()
    End Sub

    Private Sub chkDate_CheckedChanged(sender As Object, e As EventArgs) Handles chkDate.CheckedChanged
        If chkDate.Checked = True Then
            'Make ListOfOptions Radio buttons controls visible
            pnlSearchListOfOptionForDates.Visible = True

            'Make sure that Year radio button is selected
            rdbYear.Checked = True
        Else
            'Make ListOfOptions Radio buttons controls hidden
            pnlSearchListOfOptionForDates.Visible = False

            'Make sure that the radio buttons are not selected
            rdbYear.Checked = False
            rdbNoOfDays.Checked = False
            rdbDay.Checked = False
        End If

        'Call CheckBoxClick procedure
        CheckBoxClick()
    End Sub

    Private Sub rdbYear_CheckedChanged(sender As Object, e As EventArgs) Handles rdbYear.CheckedChanged
        If rdbYear.Checked = True Then
            'Make corresponding panel visible
            pnlSelectAYear.Visible = True
        Else
            'Make corresponding panel hidden
            pnlSelectAYear.Visible = False
        End If
    End Sub

    Private Sub rdbNoOfDays_CheckedChanged(sender As Object, e As EventArgs) Handles rdbNoOfDays.CheckedChanged
        If rdbNoOfDays.Checked = True Then
            'Make corresponding panel visible
            pnlSelectNoOfDays.Visible = True
        Else
            'Make corresponding panel hidden
            pnlSelectNoOfDays.Visible = False
        End If
    End Sub

    Private Sub rdbDay_CheckedChanged(sender As Object, e As EventArgs) Handles rdbDay.CheckedChanged
        If rdbDay.Checked = True Then
            'Make corresponding panel visible
            pnlSelectADay.Visible = True
        Else
            'Make corresponding panel hidden
            pnlSelectADay.Visible = False
        End If
    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        'Make sure that the Data Set is nothing
        If stockAccess.objDataSetSearchRecords IsNot Nothing Then
            stockAccess.objDataSetSearchRecords.Clear()
        End If


        'IF ALL CUSTOMER NAME AND ITEMNAME AND YEAR ARE SELECTED
        If chkCustomerName.Checked = True And chkItemName.Checked = True And rdbYear.Checked = True Then
            stockAccess.RunQueryForSearchingRecords("SELECT [Serial No],STOCK.Item_name, Customer_name, CUSTOMER.Customer_ph_no, Date_of_sale,  Quantity, Quantity_on_hand " & _
                             "FROM CUSTOMER, SALES, STOCK " & _
                             "WHERE CUSTOMER.Customer_ph_no = SALES.Customer_ph_no " & _
                             "AND SALES.Item_name= STOCK.Item_name " & _
                            "AND CUSTOMER.Customer_ph_no='" & txtSearchCustomerPhoneNumber.Text & "' " & _
     "AND SALES.Item_name='" & cboSearchItemName.Text & "' " & _
      "AND YEAR(Date_of_sale)=" & dtpSearchSelectAYear.Value.Year & _
    " ORDER BY [Serial No] ")

            'IF ALL CUSTOMERNAME AND ITEMNAME AND NO OF DAYS ARE SELECTED
        ElseIf chkCustomerName.Checked = True And chkItemName.Checked = True And rdbNoOfDays.Checked = True Then
            stockAccess.RunQueryForSearchingRecords("SELECT [Serial No],STOCK.Item_name, Customer_name, CUSTOMER.Customer_ph_no, Date_of_sale,  Quantity, Quantity_on_hand " & _
                              "FROM CUSTOMER, SALES, STOCK " & _
                              "WHERE CUSTOMER.Customer_ph_no = SALES.Customer_ph_no " & _
                              "AND SALES.Item_name= STOCK.Item_name " & _
                             "AND CUSTOMER.Customer_ph_no='" & txtSearchCustomerPhoneNumber.Text & "' " & _
      "AND SALES.Item_name='" & cboSearchItemName.Text & "' " & _
       "AND Date_of_sale BETWEEN #" & dtpSearchStartingDate.Value.Date & "# " & _
    "AND #" & dtpSearchEndingDate.Value.Date & "# " & _
    "ORDER BY [Serial No] ")

            'IF ALL CUSTOMERNAME AND ITEMNAME AND A DAY ARE SELECTED
        ElseIf chkCustomerName.Checked = True And chkItemName.Checked = True And rdbDay.Checked = True Then
            stockAccess.RunQueryForSearchingRecords("SELECT [Serial No],STOCK.Item_name, Customer_name, CUSTOMER.Customer_ph_no, Date_of_sale,  Quantity, Quantity_on_hand " & _
                              "FROM CUSTOMER, SALES, STOCK " & _
                              "WHERE CUSTOMER.Customer_ph_no = SALES.Customer_ph_no " & _
                              "AND SALES.Item_name= STOCK.Item_name " & _
                             "AND CUSTOMER.Customer_ph_no='" & txtSearchCustomerPhoneNumber.Text & "' " & _
      "AND SALES.Item_name='" & cboSearchItemName.Text & "' " & _
       "AND Date_of_sale = #" & dtpSearchSelectADay.Value.Date & "# " & _
    "ORDER BY [Serial No] ")

            'IF BOTH CUSTOMERNAME AND ITEMNAME IS CHECKED
        ElseIf chkCustomerName.Checked = True And chkItemName.Checked = True Then
            stockAccess.RunQueryForSearchingRecords("SELECT [Serial No],STOCK.Item_name, Customer_name, CUSTOMER.Customer_ph_no, Date_of_sale,  Quantity, Quantity_on_hand " & _
                             "FROM CUSTOMER, SALES, STOCK " & _
                             "WHERE CUSTOMER.Customer_ph_no = SALES.Customer_ph_no " & _
                             "AND SALES.Item_name= STOCK.Item_name " & _
                            "AND CUSTOMER.Customer_ph_no='" & txtSearchCustomerPhoneNumber.Text & "' " & _
     "AND SALES.Item_name='" & cboSearchItemName.Text & "' " & _
     " ORDER BY [Serial No] ")

            'IF CUSTOMERNAME AND YEAR ARE SELECTED
        ElseIf chkCustomerName.Checked = True And rdbYear.Checked = True Then
            stockAccess.RunQueryForSearchingRecords("SELECT [Serial No],STOCK.Item_name, Customer_name, CUSTOMER.Customer_ph_no, Date_of_sale,  Quantity, Quantity_on_hand " & _
                                "FROM CUSTOMER, SALES, STOCK " & _
                                "WHERE CUSTOMER.Customer_ph_no = SALES.Customer_ph_no " & _
                                "AND SALES.Item_name= STOCK.Item_name " & _
                               "AND CUSTOMER.Customer_ph_no='" & txtSearchCustomerPhoneNumber.Text & "' " & _
                 "AND YEAR(Date_of_sale)=" & dtpSearchSelectAYear.Value.Year & _
       " ORDER BY [Serial No] ")

            'IF CUSTOMERNAME AND NO OF DAYS ARE SELECTED
        ElseIf chkCustomerName.Checked = True And rdbNoOfDays.Checked = True Then
            stockAccess.RunQueryForSearchingRecords("SELECT [Serial No],STOCK.Item_name, Customer_name, CUSTOMER.Customer_ph_no, Date_of_sale,  Quantity, Quantity_on_hand " & _
                               "FROM CUSTOMER, SALES, STOCK " & _
                               "WHERE CUSTOMER.Customer_ph_no = SALES.Customer_ph_no " & _
                               "AND SALES.Item_name= STOCK.Item_name " & _
                              "AND CUSTOMER.Customer_ph_no='" & txtSearchCustomerPhoneNumber.Text & "' " & _
              "AND Date_of_sale BETWEEN #" & dtpSearchStartingDate.Value.Date & "# " & _
     "AND #" & dtpSearchEndingDate.Value.Date & "# " & _
     "ORDER BY [Serial No] ")

            'IF CUSTOMERNAME AND A DAY ARE SELECTED
        ElseIf chkCustomerName.Checked = True And rdbDay.Checked = True Then
            stockAccess.RunQueryForSearchingRecords("SELECT [Serial No],STOCK.Item_name, Customer_name, CUSTOMER.Customer_ph_no, Date_of_sale,  Quantity, Quantity_on_hand " & _
                            "FROM CUSTOMER, SALES, STOCK " & _
                            "WHERE CUSTOMER.Customer_ph_no = SALES.Customer_ph_no " & _
                            "AND SALES.Item_name= STOCK.Item_name " & _
                           "AND CUSTOMER.Customer_ph_no='" & txtSearchCustomerPhoneNumber.Text & "' " & _
         "AND Date_of_sale = #" & dtpSearchSelectADay.Value.Date & "# " & _
  "ORDER BY [Serial No] ")

            'IF ITEMNAME AND YEAR ARE SELECTED
        ElseIf chkItemName.Checked = True And rdbYear.Checked = True Then
            stockAccess.RunQueryForSearchingRecords("SELECT [Serial No],STOCK.Item_name, Customer_name, CUSTOMER.Customer_ph_no, Date_of_sale,  Quantity, Quantity_on_hand " & _
                         "FROM CUSTOMER, SALES, STOCK " & _
                         "WHERE CUSTOMER.Customer_ph_no = SALES.Customer_ph_no " & _
                         "AND SALES.Item_name= STOCK.Item_name " & _
                      "AND SALES.Item_name='" & cboSearchItemName.Text & "' " & _
  "AND YEAR(Date_of_sale)=" & dtpSearchSelectAYear.Value.Year & _
" ORDER BY [Serial No] ")


            'IF ITEM NAME AND NO OF DAYS ARE SELECTED
        ElseIf chkItemName.Checked = True And rdbNoOfDays.Checked = True Then
            stockAccess.RunQueryForSearchingRecords("SELECT [Serial No],STOCK.Item_name, Customer_name, CUSTOMER.Customer_ph_no, Date_of_sale,  Quantity, Quantity_on_hand " & _
                             "FROM CUSTOMER, SALES, STOCK " & _
                             "WHERE CUSTOMER.Customer_ph_no = SALES.Customer_ph_no " & _
                             "AND SALES.Item_name= STOCK.Item_name " & _
                               "AND SALES.Item_name='" & cboSearchItemName.Text & "' " & _
      "AND Date_of_sale BETWEEN #" & dtpSearchStartingDate.Value.Date & "# " & _
   "AND #" & dtpSearchEndingDate.Value.Date & "# " & _
   "ORDER BY [Serial No] ")

            'IF ITEM NAME AND SELECT A DAY ARE SELECTED
        ElseIf chkItemName.Checked = True And rdbDay.Checked = True Then
            stockAccess.RunQueryForSearchingRecords("SELECT [Serial No],STOCK.Item_name, Customer_name, CUSTOMER.Customer_ph_no, Date_of_sale,  Quantity, Quantity_on_hand " & _
                          "FROM CUSTOMER, SALES, STOCK " & _
                          "WHERE CUSTOMER.Customer_ph_no = SALES.Customer_ph_no " & _
                          "AND SALES.Item_name= STOCK.Item_name " & _
                          "AND SALES.Item_name='" & cboSearchItemName.Text & "' " & _
   "AND Date_of_sale = #" & dtpSearchSelectADay.Value.Date & "# " & _
"ORDER BY [Serial No] ")


            'IF ONLY CUSTOMERNAME IS CHECKED
        ElseIf chkCustomerName.Checked = True Then
            stockAccess.RunQueryForSearchingRecords("SELECT [Serial No],STOCK.Item_name, Customer_name, CUSTOMER.Customer_ph_no, Date_of_sale,  Quantity, Quantity_on_hand " & _
                             "FROM CUSTOMER, SALES, STOCK " & _
                             "WHERE CUSTOMER.Customer_ph_no = SALES.Customer_ph_no " & _
                             "AND SALES.Item_name= STOCK.Item_name " & _
                            "AND CUSTOMER.Customer_ph_no='" & txtSearchCustomerPhoneNumber.Text & "' " & _
          " ORDER BY [Serial No] ")

            'IF ONLY ITEMNAME IS CHECKED
        ElseIf chkItemName.Checked = True Then
            stockAccess.RunQueryForSearchingRecords("SELECT [Serial No],STOCK.Item_name, Customer_name, CUSTOMER.Customer_ph_no, Date_of_sale,  Quantity, Quantity_on_hand " & _
                             "FROM CUSTOMER, SALES, STOCK " & _
                             "WHERE CUSTOMER.Customer_ph_no = SALES.Customer_ph_no " & _
                             "AND SALES.Item_name= STOCK.Item_name " & _
                               "AND SALES.Item_name='" & cboSearchItemName.Text & "' " & _
     " ORDER BY [Serial No] ")


            'IF ONLY YEAR RADIOBUTTON IS SELECTED
        ElseIf rdbYear.Checked = True Then
            stockAccess.RunQueryForSearchingRecords("SELECT [Serial No],STOCK.Item_name, Customer_name, CUSTOMER.Customer_ph_no, Date_of_sale,  Quantity, Quantity_on_hand " & _
                        "FROM CUSTOMER, SALES, STOCK " & _
                        "WHERE CUSTOMER.Customer_ph_no = SALES.Customer_ph_no " & _
                        "AND SALES.Item_name= STOCK.Item_name " & _
                      "AND YEAR(Date_of_sale)=" & dtpSearchSelectAYear.Value.Year & _
" ORDER BY [Serial No] ")

            'IF NO OF DAYS RADIOBUTTON IS SELECTED
        ElseIf rdbNoOfDays.Checked = True Then
            stockAccess.RunQueryForSearchingRecords("SELECT [Serial No],STOCK.Item_name, Customer_name, CUSTOMER.Customer_ph_no, Date_of_sale,  Quantity, Quantity_on_hand " & _
                             "FROM CUSTOMER, SALES, STOCK " & _
                             "WHERE CUSTOMER.Customer_ph_no = SALES.Customer_ph_no " & _
                             "AND SALES.Item_name= STOCK.Item_name " & _
                                  "AND Date_of_sale BETWEEN #" & dtpSearchStartingDate.Value.Date & "# " & _
   "AND #" & dtpSearchEndingDate.Value.Date & "# " & _
   "ORDER BY [Serial No] ")


            'IF ONLY  A RADIOBUTTON FOR A DAY IS SELECTED
        ElseIf rdbDay.Checked = True Then
            stockAccess.RunQueryForSearchingRecords("SELECT [Serial No],STOCK.Item_name, Customer_name, CUSTOMER.Customer_ph_no, Date_of_sale,  Quantity, Quantity_on_hand " & _
                          "FROM CUSTOMER, SALES, STOCK " & _
                          "WHERE CUSTOMER.Customer_ph_no = SALES.Customer_ph_no " & _
                          "AND SALES.Item_name= STOCK.Item_name " & _
                           "AND Date_of_sale = #" & dtpSearchSelectADay.Value.Date & "# " & _
"ORDER BY [Serial No] ")

        End If


        'CHECK FOR ERRORS
        If stockAccess.strExceptionSearchRecords <> "" Then
            MsgBox(stockAccess.strExceptionSearchRecords)

            'Set it to nothing
            stockAccess.strExceptionSearchRecords = Nothing

            Exit Sub
        Else
            dt = stockAccess.AutoNumberedTable(stockAccess.objDataSetSearchRecords.Tables(0))
            GblAccessObject.objDataTableOfSalesIssuerForm = dt
            'Set the DataView object to the DataSet object..
            objDataView = New DataView(dt)

            'Set the CurrencyManager object to the DataView object...
            objCurrencyManager = CType(Me.BindingContext(objDataView), CurrencyManager)

            FillDataGridView()
        End If


        'CHECK THE NUMBER OF RECORDS IN DATASET OBJECT IN STOREACCESS CLASS
        If stockAccess.intNumberOfRecords > 0 Then
            If stockAccess.intNumberOfRecords = 1 Then
                MessageBox.Show(stockAccess.intNumberOfRecords & " Record Found!", "SEARCHING RECORDS", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                MessageBox.Show(stockAccess.intNumberOfRecords & " Records Found!", "SEARCHING RECORDS", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Else
            MessageBox.Show("No Records Found for this Search!", "SEARCHING RECORDS", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If

        'Set intNumberOfRecords to Nothing
        stockAccess.intNumberOfRecords = Nothing
    End Sub

    Private Sub btnGetReport_Click(sender As Object, e As EventArgs) Handles btnGetReport.Click
        Using objReportForm As New ReportForm
            With objReportForm
                .strSender = "SalesIssuer"
                .ShowDialog()
            End With
        End Using
    End Sub

    Private Sub txtQuantity_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtQuantity.KeyPress
        e.Handled = Not Char.IsDigit(e.KeyChar)
    End Sub
End Class