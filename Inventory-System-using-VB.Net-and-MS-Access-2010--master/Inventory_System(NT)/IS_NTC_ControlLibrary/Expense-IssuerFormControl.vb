Public Class Expense_IssuerFormControl
    Private stockAccess As New StockAccess
    Private objDataView As DataView
    Private objCurrencyManager As CurrencyManager
    Private dt As DataTable

    Private Sub Expense_IssuerFormControl_Load(sender As Object, e As EventArgs) Handles Me.Load
        If stockAccess.HasConnection = True Then
            Query()
            FillDataGridView()
            GetItemName()

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
        'Clear existing records
        If stockAccess.objDataSet IsNot Nothing Then
            stockAccess.objDataSet.Clear()
        End If

        stockAccess.RunQuery("SELECT [Serial No], STOCK.Item_name, Date_of_used, Quantity, Reason, Quantity_on_hand " & _
                             "FROM EXPENSE, STOCK " & _
                             "WHERE EXPENSE.Item_name = STOCK.Item_name " & _
                             "ORDER BY [Serial No]")

        If stockAccess.strExceptionRunQuery <> "" Then
            'Show error message
            MessageBox.Show(stockAccess.strExceptionRunQuery, My.Application.Info.Title, MessageBoxButtons.OK, MessageBoxIcon.Error)

            'Set the variable to nothing
            stockAccess.strExceptionRunQuery = Nothing
        Else
            dt = stockAccess.AutoNumberedTable(stockAccess.objDataSet.Tables(0))
            GblAccessObject.objDataTableofExpenseIssuerForm = dt
            'Set the DataView object to the DataSet object..
            objDataView = New DataView(dt)

            'Set the CurrencyManager object to the DataView object...
            objCurrencyManager = CType(Me.BindingContext(objDataView), CurrencyManager)
        End If
    End Sub

    Private Sub FillDataGridView()
        grdExpenseIssuer.DataSource = objDataView

        grdExpenseIssuer.Font = New Font(grdExpenseIssuer.DefaultCellStyle.Font.FontFamily, 10, FontStyle.Regular)
        'Declare and set the column header style
        Dim objColumnHeaderStyle As New DataGridViewCellStyle
        objColumnHeaderStyle.BackColor = Color.Silver
        objColumnHeaderStyle.ForeColor = Color.Black
        objColumnHeaderStyle.Font = New Font(grdExpenseIssuer.DefaultCellStyle.Font.FontFamily, 9, FontStyle.Bold)
        objColumnHeaderStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

        grdExpenseIssuer.ColumnHeadersDefaultCellStyle = objColumnHeaderStyle

        'Declare and set the default rows style
        Dim objAlignRightCellStyle As New DataGridViewCellStyle
        objAlignRightCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        grdExpenseIssuer.RowsDefaultCellStyle = objAlignRightCellStyle

        'Declare and set the alternating rows style
        Dim objAlternatingCellStyle As New DataGridViewCellStyle
        objAlternatingCellStyle.BackColor = Color.WhiteSmoke
        grdExpenseIssuer.AlternatingRowsDefaultCellStyle = objAlternatingCellStyle

        With grdExpenseIssuer
            .RowHeadersVisible = False
            .Columns(0).HeaderCell.Value = "S.N."
            .Columns(1).HeaderCell.Value = "ITEM NAME"
            .Columns(2).HeaderCell.Value = "DATE OF USED"
            .Columns(3).HeaderCell.Value = "QUANTITY"
            .Columns(4).HeaderCell.Value = "USED FOR WHAT"
            .Columns(5).HeaderCell.Value = "CURRENT QUANTITY IN STOCK"
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






    Private Sub ClearFields()
        cboItemName.SelectedIndex = 0
        txtItemName.Clear()
        dtpDateOfUsed.Value = Now
        txtQuantity.Clear()
        txtUsedFor.Clear()
        cboItemName.Focus()
    End Sub

    Private Sub BindFields()
        ClearDataBindings()

        'Add new bindings to the DataView object..
        txtItemName.DataBindings.Add("Text", objDataView, "Item_name")
        dtpDateOfUsed.DataBindings.Add("Value", objDataView, "Date_of_used")
        txtQuantity.DataBindings.Add("Text", objDataView, "Quantity")
        txtUsedFor.DataBindings.Add("Text", objDataView, "Reason")
    End Sub

    'CLEAR DATABINDINGS..
    Private Sub ClearDataBindings()
        'Clear any previous databindings...
        txtItemName.DataBindings.Clear()
        dtpDateOfUsed.DataBindings.Clear()
        txtQuantity.DataBindings.Clear()
        txtUsedFor.DataBindings.Clear()
    End Sub

    Private Sub ShowPosition()
        'Display the current position and the number of records
        txtRecordPosition.Text = objCurrencyManager.Position + 1 & " of " & objCurrencyManager.Count()
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

        'Show the current record position
        ShowPosition()
    End Sub

    Private Sub btnMoveNext_Click(sender As Object, e As EventArgs) Handles btnMoveNext.Click
        'Set the record position to next record..
        objCurrencyManager.Position += 1

        'Show the current record position
        ShowPosition()
    End Sub

    Private Sub btnMoveLast_Click(sender As Object, e As EventArgs) Handles btnMoveLast.Click
        'Set the record position to last record..
        objCurrencyManager.Position = objCurrencyManager.Count() - 1

        'Show the current record position
        ShowPosition()
    End Sub






    'CHANGE THE READONLY PROPERTY OF TEXTBOXES TO TRUE
    Private Sub ReadOnlyTrue()
        'Make the textboxes readonly
        txtItemName.ReadOnly = True
        txtQuantity.ReadOnly = True
        txtUsedFor.ReadOnly = True
    End Sub

    'CHANGE THE READONLY PROPERTY OF TEXTBOXES TO FALSE
    Private Sub ReadOnlyFalse()
        'Make the textboxes readonly
        txtItemName.ReadOnly = False
        txtQuantity.ReadOnly = False
        txtUsedFor.ReadOnly = False
    End Sub

    Private Sub btnView_Click(sender As Object, e As EventArgs) Handles btnView.Click
        If btnView.Text = "View" Then
            'Make itemName TextBox control visible
            txtItemName.Visible = True


            btnView.Text = "Cancel View"

            'Make buttons enabled
            ViewEnabledButtons()

            'Disabled some buttons
            btnClear.Enabled = False
            btnSave.Enabled = False
            btnRefresh.Enabled = False
            chkItemName.Enabled = False
            chkDate.Enabled = False

            'Bind fields
            BindFields()
            ShowPosition()

            'Make textboxes readonly
            ReadOnlyTrue()

            'Call CheckedPropertyFalse to unselect check list in the Search GroupBox
            CheckedPropertyFalse()
        Else
            'Make itemName TextBox control hidden
            txtItemName.Visible = False

            btnView.Text = "View"

            'Make buttons disabled
            ViewDisabledButtons()

            'Enabled some buttons
            btnClear.Enabled = True
            btnSave.Enabled = True
            btnRefresh.Enabled = True
            chkItemName.Enabled = True
            chkDate.Enabled = True

            'Set readonly property to false of textboxes
            ReadOnlyFalse()

            'Clear fields
            ClearDataBindings()
            ClearFields()
            'Clear the Record Position Text Box Clear
            txtRecordPosition.Clear()
        End If
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




    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Dim objStringBuilder1 As New System.Text.StringBuilder
        Dim objStringBuilder2 As New System.Text.StringBuilder

        'Add the question
        objStringBuilder1.AppendLine("Do you want to add the following expense-issue information?")
        objStringBuilder1.AppendLine(String.Empty)
        objStringBuilder1.AppendLine("INFO ABOUT ITEM : " & cboItemName.Text)
        objStringBuilder1.AppendLine("DATE OF USED : " & dtpDateOfUsed.Text)
        objStringBuilder1.AppendLine("QUANTITY USED : " & txtQuantity.Text)

        objStringBuilder2.AppendLine("Do you also want to deduct the quantity of item store in STOCK?")
        objStringBuilder2.AppendLine("INFO ABOUT ITEM : " & cboItemName.Text)
        objStringBuilder2.AppendLine("QUANTITY : " & txtQuantity.Text & " will also be deducted from the total amount stored in STOCK.")

        If MessageBox.Show(objStringBuilder1.ToString, My.Application.Info.Title, _
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            Dim intDialogResult As DialogResult = MessageBox.Show(objStringBuilder2.ToString, My.Application.Info.Title, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)
            Select Case intDialogResult
                Case DialogResult.Yes
                    AddItemAsExpenseAndDeductFromStock()
                   
                Case DialogResult.No
                    AddItemAsExpenseAndNonDeductFromStock()
                 
                Case Else
                    'Do nothing

            End Select
        Else
            'Do nothing
        End If

        'Set the record position to the last record..
        objCurrencyManager.Position = objCurrencyManager.Count - 1
    End Sub

    'ADD NEW INFORMATION FOR CAPITALIZED ISSUE AND DEDUCT THE QUANTITY OF ITEM FROM STOCK AS WELL
    Private Sub AddItemAsExpenseAndDeductFromStock()
        stockAccess.AddExpenseIssuerAndDeductFromStock(cboItemName.Text, dtpDateOfUsed.Value.Date, txtQuantity.Text, txtUsedFor.Text)

        Dim objStringBuilder As New System.Text.StringBuilder
        objStringBuilder.AppendLine("The following new information has been added...!")
        objStringBuilder.AppendLine(String.Empty)
        objStringBuilder.AppendLine("INFO ABOUT ITEM : " & cboItemName.Text)
        objStringBuilder.AppendLine("DATE OF USED : " & dtpDateOfUsed.Text)
        objStringBuilder.AppendLine("QUANTITY USED : " & txtQuantity.Text)
        objStringBuilder.AppendLine(String.Empty)
        objStringBuilder.AppendLine("QUANTITY SUBTRACTED FROM STOCK : " & txtQuantity.Text)
        objStringBuilder.AppendLine("NOTE: The current quantity of item used as capitalized is also deducted from the quantity of item stored in the STOCK.")

        Dim strExceptionItemAsExpenseDetails As String = stockAccess.strExceptionAddItemAsExpenseAndDeductFromStock
        If strExceptionItemAsExpenseDetails <> "" Then
            MsgBox(strExceptionItemAsExpenseDetails)

            'Set strExceptionAddItemAsExpenseAndDeductFromStock to nothing
            stockAccess.strExceptionAddItemAsExpenseAndDeductFromStock = Nothing
        Else
            MessageBox.Show(objStringBuilder.ToString, My.Application.Info.Title, MessageBoxButtons.OK, MessageBoxIcon.Information)

            'Set stock quantity to zero if quantity is less than zero
            StockUpdateToZero.UpdateToZero()


            Query()
            FillDataGridView()
            ClearFields()
        End If
    End Sub

    'ADD NEW INFORMATION FOR CAPITALIZED ISSUE AND DO NOT DEDUCT THE QUANTITY OF ITEM FROM STOCK
    Private Sub AddItemAsExpenseAndNonDeductFromStock()
        stockAccess.AddExpenseIssuerAndNonDeductFromStock(cboItemName.Text, dtpDateOfUsed.Value.Date, txtQuantity.Text, txtUsedFor.Text)

        Dim objStringBuilder As New System.Text.StringBuilder
        objStringBuilder.AppendLine("The following new information has been added...!")
        objStringBuilder.AppendLine(String.Empty)
        objStringBuilder.AppendLine("INFO ABOUT ITEM : " & cboItemName.Text)
        objStringBuilder.AppendLine("DATE OF USED : " & dtpDateOfUsed.Text)
        objStringBuilder.AppendLine("QUANTITY USED : " & txtQuantity.Text)

        Dim strExceptionItemAsExpenseDetails As String = stockAccess.strExceptionAddItemAsExpenseAndNonDeductFromStock
        If strExceptionItemAsExpenseDetails <> "" Then
            MsgBox(strExceptionItemAsExpenseDetails)

            'Set strExceptionAddItemAsExpenseAndNonDeductFromStock to nothing
            stockAccess.strExceptionAddItemAsExpenseAndNonDeductFromStock = Nothing
        Else
            MessageBox.Show(objStringBuilder.ToString, My.Application.Info.Title, MessageBoxButtons.OK, MessageBoxIcon.Information)

            'Set stock quantity to zero if quantity is less than zero
            StockUpdateToZero.UpdateToZero()

            Query()
            FillDataGridView()
            ClearFields()
        End If
    End Sub







    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        Dim objStringBuilder1 As New System.Text.StringBuilder
        Dim objStringBuilder2 As New System.Text.StringBuilder

        'Add the question
        objStringBuilder1.AppendLine("Do you really want to delete the information of this supplied item?")
        objStringBuilder1.AppendLine(String.Empty)
        objStringBuilder1.AppendLine("INFO ABOUT ITEM : " & txtItemName.Text)
        objStringBuilder1.AppendLine("DATE OF USED : " & dtpDateOfUsed.Text)
        objStringBuilder1.AppendLine("QUANTITY USED : " & txtQuantity.Text)

        objStringBuilder2.AppendLine("Do you also want to ADD the quantity of item store in STOCK?")
        objStringBuilder2.AppendLine("INFO ABOUT ITEM : " & txtItemName.Text)
        objStringBuilder2.AppendLine("QUANTITY : " & txtQuantity.Text & " will also be added to the total quantity stored in STOCK.")

        If MessageBox.Show(objStringBuilder1.ToString, My.Application.Info.Title, _
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            Dim intDialogResult As DialogResult = MessageBox.Show(objStringBuilder2.ToString, My.Application.Info.Title, _
                               MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)
            Select Case intDialogResult
                Case DialogResult.Yes
                    DeleteExpenseIssuerAndAddToStock()
                Case DialogResult.No
                    DeleteExpenseIssuer()
                Case Else
                    'Do nothing
            End Select
        Else
            'Do nothing
        End If
    End Sub

    'DELETE THE INFORMATION FOR EXPENSE ISSUER AND DO NOT ADD THE QUANTITY OF ITEM TO STOCK
    Private Sub DeleteExpenseIssuer()
        Dim intPosition As Integer = objCurrencyManager.Position - 1
        If intPosition < 0 Then
            intPosition = 0
        End If

        stockAccess.DeleteExpenseIssuerAndDoNotAddToStock(txtItemName.Text, dtpDateOfUsed.Value.Date)

        Dim objStringBuilder As New System.Text.StringBuilder

        'Add the question
        objStringBuilder.AppendLine("The following information has been deleted...!")
        objStringBuilder.AppendLine(String.Empty)
        objStringBuilder.AppendLine("INFO ABOUT ITEM : " & txtItemName.Text)
        objStringBuilder.AppendLine("DATE OF USED : " & dtpDateOfUsed.Text)
        objStringBuilder.AppendLine("QUANTITY USED : " & txtQuantity.Text)

        Dim strExceptionDeleteExpenseIssuer As String = stockAccess.strExceptionDeleteItemAsExpenseAndDoNotAddToStock
        If strExceptionDeleteExpenseIssuer <> "" Then
            MsgBox(strExceptionDeleteExpenseIssuer)

            'Set strExceptionDeleteItemAsExpenseAndDoNotAddToStock to nothing
            stockAccess.strExceptionDeleteItemAsExpenseAndDoNotAddToStock = Nothing
        Else
            MessageBox.Show(objStringBuilder.ToString, My.Application.Info.Title, _
                        MessageBoxButtons.OK, MessageBoxIcon.Information)
            Query()
            objCurrencyManager.Position = intPosition
            BindFields()
            ShowPosition()
        End If
    End Sub


    'DELETE THE INFORMATION FOR EXPENSE ISSUER AND ADD THE QUANTITY OF ITEM TO STOCK AS WELL
    Private Sub DeleteExpenseIssuerAndAddToStock()
        Dim intPosition As Integer = objCurrencyManager.Position - 1
        If intPosition < 0 Then
            intPosition = 0
        End If

        stockAccess.DeleteExpenseIssuerAndAddToStock(txtItemName.Text, dtpDateOfUsed.Value.Date, txtQuantity.Text)

        Dim objStringBuilder As New System.Text.StringBuilder

        'Add the question
        objStringBuilder.AppendLine("The following information has been deleted...!")
        objStringBuilder.AppendLine(String.Empty)
        objStringBuilder.AppendLine("INFO ABOUT ITEM : " & txtItemName.Text)
        objStringBuilder.AppendLine("DATE OF USED : " & dtpDateOfUsed.Text)
        objStringBuilder.AppendLine("QUANTITY USED : " & txtQuantity.Text)
        objStringBuilder.AppendLine(String.Empty)
        objStringBuilder.AppendLine("QUANTITY ADDED TO STOCK : " & txtQuantity.Text)
        objStringBuilder.AppendLine("NOTE: The current quantity of item deleted is also added to the quantity of item stored in the STOCK.")

        Dim strExceptionDeleteExpenseIssuer As String = stockAccess.strExceptionDeleteItemAsExpenseAndAddToStock
        If strExceptionDeleteExpenseIssuer <> "" Then
            MsgBox(strExceptionDeleteExpenseIssuer)

            'Set strExceptionDeleteItemAsExpenseAndAddToStock to nothing
            stockAccess.strExceptionDeleteItemAsExpenseAndAddToStock = Nothing
        Else
            MessageBox.Show(objStringBuilder.ToString, My.Application.Info.Title, _
                        MessageBoxButtons.OK, MessageBoxIcon.Information)
            Query()
            objCurrencyManager.Position = intPosition
            BindFields()
            ShowPosition()
        End If
    End Sub

    Private Sub grdExpenseIssuer_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles grdExpenseIssuer.CellClick
        If btnView.Text <> "View" Then
            'Show position of the GridView row in the Record Position Text Box
            ShowPosition()
        End If
    End Sub

    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        Expense_IssuerFormControl_Load(Nothing, Nothing)
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        ClearFields()
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
        If chkDate.Checked = True Or chkItemName.Checked = True Then
            btnSearch.Enabled = True
        ElseIf chkDate.Checked = False Or chkItemName.Checked = False Then
            btnSearch.Enabled = False
        End If
    End Sub

    'UNSELECT THE CHECKED PROPERTY OF CHECKBOX AND RADIOBUTTON
    Private Sub CheckedPropertyFalse()
        'Make sure that Searching checklist are not selected
        chkItemName.Checked = False
        chkDate.Checked = False
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

        'IF  ITEMNAME AND YEAR ARE SELECTED
        If chkItemName.Checked = True And rdbYear.Checked = True Then
            stockAccess.RunQueryForSearchingRecords("SELECT [Serial No], STOCK.Item_name, Date_of_used, Quantity, Reason, Quantity_on_hand " & _
                             "FROM EXPENSE, STOCK " & _
                             "WHERE EXPENSE.Item_name = STOCK.Item_name " & _
                     "AND STOCK.Item_name = '" & cboSearchItemName.Text & "' " & _
                     "AND YEAR(Date_of_used) =" & dtpSearchSelectAYear.Value.Year & _
                     " ORDER BY [Serial No]")

            'IF ITEMNAME AND NOOFDAYS ARE SELECTED
        ElseIf chkItemName.Checked = True And rdbNoOfDays.Checked = True Then
            stockAccess.RunQueryForSearchingRecords("SELECT [Serial No], STOCK.Item_name, Date_of_used, Quantity, Reason, Quantity_on_hand " & _
                             "FROM EXPENSE, STOCK " & _
                             "WHERE EXPENSE.Item_name = STOCK.Item_name " & _
                     "AND STOCK.Item_name = '" & cboSearchItemName.Text & "' " & _
                     "AND Date_of_used BETWEEN #" & dtpSearchStartingDate.Value.Date & "# " & _
                     "AND #" & dtpSearchEndingDate.Value.Date & "# " & _
                     "ORDER BY [Serial No]")

            'IF ITEMNAME AND A DAY ARE SELECTED
        ElseIf chkItemName.Checked = True And rdbDay.Checked = True Then
            stockAccess.RunQueryForSearchingRecords("SELECT [Serial No], STOCK.Item_name, Date_of_used, Quantity, Reason, Quantity_on_hand " & _
                             "FROM EXPENSE, STOCK " & _
                             "WHERE EXPENSE.Item_name = STOCK.Item_name " & _
                  "AND STOCK.Item_name = '" & cboSearchItemName.Text & "' " & _
                    "AND Date_of_used = #" & dtpSearchSelectADay.Value.Date & "# " & _
                       "ORDER BY [Serial No]")

            'IF ONLY ITEMNAME IS SELECTED
        ElseIf chkItemName.Checked = True Then
            stockAccess.RunQueryForSearchingRecords("SELECT [Serial No], STOCK.Item_name, Date_of_used, Quantity, Reason, Quantity_on_hand " & _
                             "FROM EXPENSE, STOCK " & _
                             "WHERE EXPENSE.Item_name = STOCK.Item_name " & _
                   "AND STOCK.Item_name = '" & cboSearchItemName.Text & "' " & _
                   " ORDER BY [Serial No]")

            'IF ONLY YEAR RADIOBUTTON IS SELECTED
        ElseIf rdbYear.Checked = True Then
            stockAccess.RunQueryForSearchingRecords("SELECT [Serial No], STOCK.Item_name, Date_of_used, Quantity, Reason, Quantity_on_hand " & _
                             "FROM EXPENSE, STOCK " & _
                             "WHERE EXPENSE.Item_name = STOCK.Item_name " & _
                   "AND YEAR(Date_of_used) =" & dtpSearchSelectAYear.Value.Year & _
                   " ORDER BY [Serial No]")

            'IF NO OF DAYS RADIOBUTTON IS SELECTED
        ElseIf rdbNoOfDays.Checked = True Then
            stockAccess.RunQueryForSearchingRecords("SELECT [Serial No], STOCK.Item_name, Date_of_used, Quantity, Reason, Quantity_on_hand " & _
                             "FROM EXPENSE, STOCK " & _
                             "WHERE EXPENSE.Item_name = STOCK.Item_name " & _
                    "AND Date_of_used BETWEEN #" & dtpSearchStartingDate.Value.Date & "# " & _
                    "AND #" & dtpSearchEndingDate.Value.Date & "# " & _
                    "ORDER BY [Serial No]")
            'IF ONLY  A RADIOBUTTON FOR A DAY IS SELECTED
        ElseIf rdbDay.Checked = True Then
            stockAccess.RunQueryForSearchingRecords("SELECT [Serial No], STOCK.Item_name, Date_of_used, Quantity, Reason, Quantity_on_hand " & _
                             "FROM EXPENSE, STOCK " & _
                             "WHERE EXPENSE.Item_name = STOCK.Item_name " & _
                      "AND Date_of_used = #" & dtpSearchSelectADay.Value.Date & "# " & _
                      "ORDER BY [Serial No]")
        End If


        'CHECK FOR ERRORS
        If stockAccess.strExceptionSearchRecords <> "" Then
            MsgBox(stockAccess.strExceptionSearchRecords)

            'Set it to nothing
            stockAccess.strExceptionSearchRecords = Nothing

            Exit Sub
        Else
            dt = stockAccess.AutoNumberedTable(stockAccess.objDataSetSearchRecords.Tables(0))
            GblAccessObject.objDataTableofExpenseIssuerForm = dt
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
                .strSender = "ExpenseIssuer"
                .ShowDialog()
            End With
        End Using
    End Sub

    Private Sub txtQuantity_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtQuantity.KeyPress
        e.Handled = Not Char.IsDigit(e.KeyChar)
    End Sub
End Class