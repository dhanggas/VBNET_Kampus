Public Class ItemReceivedFormControl
    Private stockAccess As New StockAccess
    Private objDataView As DataView
    Private objCurrencyManager As CurrencyManager
    Private dt As DataTable

    Private Sub ItemReceivedFormControl_Load(sender As Object, e As EventArgs) Handles Me.Load
        If stockAccess.HasConnection = True Then
            Query()
            FillDataGridView()
            GetBranchLocation()
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

    'Query to fill DataGridView for the ItemReceivedForm
    Private Sub Query()
        'Clear existing records
        If stockAccess.objDataSet IsNot Nothing Then
            stockAccess.objDataSet.Clear()
        End If

        stockAccess.RunQuery("SELECT [Serial No],STOCK.Item_name, Date_of_received, Supplying_Branch, Quantity, Quantity_on_hand " & _
                             "FROM RECEIVED_FROM_BRANCH, STOCK " & _
                             "WHERE RECEIVED_FROM_BRANCH.Item_name = STOCK.Item_name " & _
                             "ORDER BY [Serial No]")

        If stockAccess.strExceptionRunQuery <> "" Then
            'Show error message
            MessageBox.Show(stockAccess.strExceptionRunQuery, My.Application.Info.Title, MessageBoxButtons.OK, MessageBoxIcon.Error)

            'Set the variable to nothing
            stockAccess.strExceptionRunQuery = Nothing
        Else
            dt = stockAccess.AutoNumberedTable(stockAccess.objDataSet.Tables(0))
            GblAccessObject.objDataTableOfItemReceivedForm = dt
            'Set the DataView object to the DataSet object..
            objDataView = New DataView(dt)

            'Set the CurrencyManager object to the DataView object...
            objCurrencyManager = CType(Me.BindingContext(objDataView), CurrencyManager)
        End If
    End Sub


    Private Sub FillDataGridView()
        grdItemReceived.DataSource = objDataView

        grdItemReceived.Font = New Font(grdItemReceived.DefaultCellStyle.Font.FontFamily, 10, FontStyle.Regular)
        'Declare and set the column header style
        Dim objColumnHeaderStyle As New DataGridViewCellStyle
        objColumnHeaderStyle.BackColor = Color.Silver
        objColumnHeaderStyle.ForeColor = Color.Black
        objColumnHeaderStyle.Font = New Font(grdItemReceived.DefaultCellStyle.Font.FontFamily, 9, FontStyle.Bold)
        objColumnHeaderStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

        grdItemReceived.ColumnHeadersDefaultCellStyle = objColumnHeaderStyle

        'Declare and set the default rows style
        Dim objAlignRightCellStyle As New DataGridViewCellStyle
        objAlignRightCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        grdItemReceived.RowsDefaultCellStyle = objAlignRightCellStyle

        'Declare and set the alternating rows style
        Dim objAlternatingCellStyle As New DataGridViewCellStyle
        objAlternatingCellStyle.BackColor = Color.WhiteSmoke
        grdItemReceived.AlternatingRowsDefaultCellStyle = objAlternatingCellStyle

        With grdItemReceived
            .RowHeadersVisible = False
            .Columns(0).HeaderCell.Value = "S.N."
            .Columns(1).HeaderCell.Value = "ITEM NAME"
            .Columns(2).HeaderCell.Value = "DATE OF RECEIVED"
            .Columns(3).HeaderCell.Value = "SUPPLYING BRANCH"
            .Columns(4).HeaderCell.Value = "QUANTITY"
            .Columns(5).HeaderCell.Value = "CURRENT QUANTITY IN STOCK"
        End With
    End Sub

    Private Sub GetBranchLocation()
        'Clear existing records
        If stockAccess.objBranchLocationDataTable IsNot Nothing Then
            stockAccess.objBranchLocationDataTable.Clear()
        End If

        stockAccess.GetBranchNameForComboBox("SELECT * From BRANCH " & _
                                             "ORDER BY Branch_location")

        'If records are found, add them to the combobox
        If stockAccess.objBranchLocationDataTable.Rows.Count > 0 Then
            cboBranch.DataSource = stockAccess.objBranchLocationDataTable
            cboBranch.DisplayMember = "Branch_location"

            'Set the combobox to first record
            cboBranch.SelectedIndex = 0
        ElseIf stockAccess.strExceptionGetBranchLocation <> "" Then
            'Display error message
            MessageBox.Show(stockAccess.strExceptionGetBranchLocation)
        End If
    End Sub

    Private Sub GetItemName()
        'Clear existing records..
        If stockAccess.objItemNameDataTable IsNot Nothing Then
            stockAccess.objItemNameDataTable.Clear()
        End If

        stockAccess.GetItemNameForComboBox("SELECT Item_name FROM STOCK " & _
                                           "ORDER BY Item_name")

        'If records are found, add them to combobox
        If stockAccess.objItemNameDataTable.Rows.Count > 0 Then
            cboItemName.DataSource = stockAccess.objItemNameDataTable
            cboItemName.DisplayMember = "Item_name"

            'Set the combobox to first record
            cboItemName.SelectedIndex = 0
        ElseIf stockAccess.strExceptionGetItemName <> "" Then
            'Display error message
            MessageBox.Show(stockAccess.strExceptionGetItemName)
        End If

    End Sub

    Private Sub cboBranch_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboBranch.SelectedIndexChanged
        If cboBranch.SelectedIndex <> 0 Then
            pnltxtBranch.Visible = False
        Else
            pnltxtBranch.Visible = True
        End If
    End Sub

    'MAKE TEXTBOX CONTROL OF ITEMNAME VISIBLE OR 
    Private Sub cboItemName_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboItemName.SelectedIndexChanged
        If cboItemName.SelectedIndex <> 0 Then
            pnltxtItemName.Visible = False
        Else
            pnltxtItemName.Visible = True
        End If
    End Sub







    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If pnltxtBranch.Visible = False And pnltxtItemName.Visible = False Then
            'Both Branch and Item are existing
            AddItemReceived()
        ElseIf pnltxtBranch.Visible = False And pnltxtItemName.Visible = True Then
            'Branch is existing but Item is new
            AddItemReceivedAndItem()
        ElseIf pnltxtBranch.Visible = True And pnltxtItemName.Visible = False Then
            'Branch is new but Item is exising
            AddBranchAndItemReceived()
        Else
            'Both Branch and Item are new
            AddBranchAndItemReceivedAndItem()
        End If
    End Sub

    'ADD ITEM RECEIVED DETAILS ONLY
    Private Sub AddItemReceived()
        Dim objStringBuilder1 As New System.Text.StringBuilder
        Dim objStringBuilder2 As New System.Text.StringBuilder

        'Add the question
        objStringBuilder1.AppendLine("Do you want to add the following information?")
        objStringBuilder1.AppendLine(String.Empty)
        objStringBuilder1.AppendLine("INFO ABOUT EXISTING SUPPLYING BRANCH: " & cboBranch.Text)
        objStringBuilder1.AppendLine("INFO ABOUT EXISTING ITEM : " & cboItemName.Text)
        objStringBuilder1.AppendLine("DATE OF RECEIVED : " & dtpDateOfReceived.Text)
        objStringBuilder1.AppendLine("QUANTITY : " & txtQuantity.Text)
        objStringBuilder1.AppendLine(String.Empty)
        objStringBuilder1.AppendLine("NOTE: The current quantity of item supplied will also be added to the quantity of item stored in the STOCK.")

        objStringBuilder2.AppendLine("The following information has been added...!")
        objStringBuilder2.AppendLine(String.Empty)
        objStringBuilder2.AppendLine("INFO ABOUT SUPPLYING BRANCH: " & cboBranch.Text)
        objStringBuilder2.AppendLine("INFO ABOUT ITEM : " & cboItemName.Text)
        objStringBuilder2.AppendLine("DATE OF RECEIVED : " & dtpDateOfReceived.Text)
        objStringBuilder2.AppendLine("QUANTITY : " & txtQuantity.Text)
        objStringBuilder2.AppendLine(String.Empty)
        objStringBuilder2.AppendLine("NOTE: The current quantity of item supplied is also added to the quantity of item stored in the STOCK.")

        If MessageBox.Show(objStringBuilder1.ToString, My.Application.Info.Title, _
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            stockAccess.AddItemReceived(cboItemName.Text, dtpDateOfReceived.Text, cboBranch.Text, txtQuantity.Text)

            Dim strExceptionItemReceived As String = stockAccess.strExceptionAddItemReceivedDetails
            If strExceptionItemReceived <> "" Then
                MsgBox(strExceptionItemReceived)

                'Set strExceptionAddItemReceivedDetails to nothing
                stockAccess.strExceptionAddItemReceivedDetails = Nothing
            Else
                MessageBox.Show(objStringBuilder2.ToString, My.Application.Info.Title, MessageBoxButtons.OK, MessageBoxIcon.Information)

                Query()
                FillDataGridView()
                ClearFields()

                'Set the record position to the last record..
                objCurrencyManager.Position = objCurrencyManager.Count - 1
            End If
        Else
            'Do nothing

        End If
    End Sub

    'ADD BRANCH AND ITEM RECEIVED DETAILS
    Private Sub AddBranchAndItemReceived()
        Dim objStringBuilder1 As New System.Text.StringBuilder
        Dim objStringBuilder2 As New System.Text.StringBuilder

        'Add the question
        objStringBuilder1.AppendLine("Do you want to add the following new information?")
        objStringBuilder1.AppendLine(String.Empty)
        objStringBuilder1.AppendLine("INFO ABOUT NEW SUPPLYING BRANCH: " & txtBranch.Text)
        objStringBuilder1.AppendLine("INFO ABOUT EXISTING ITEM : " & cboItemName.Text)
        objStringBuilder1.AppendLine("DATE OF RECEIVED : " & dtpDateOfReceived.Text)
        objStringBuilder1.AppendLine("QUANTITY : " & txtQuantity.Text)
        objStringBuilder1.AppendLine(String.Empty)
        objStringBuilder1.AppendLine("NOTE: The current quantity of item supplied will also be added to the quantity of item stored in the STOCK.")

        objStringBuilder2.AppendLine("The following information has been added...!")
        objStringBuilder2.AppendLine(String.Empty)
        objStringBuilder2.AppendLine("INFO ABOUT SUPPLYING BRANCH: " & txtBranch.Text)
        objStringBuilder2.AppendLine("INFO ABOUT ITEM : " & cboItemName.Text)
        objStringBuilder2.AppendLine("DATE OF RECEIVED : " & dtpDateOfReceived.Text)
        objStringBuilder2.AppendLine("QUANTITY : " & txtQuantity.Text)
        objStringBuilder2.AppendLine(String.Empty)
        objStringBuilder2.AppendLine("NOTE: The current quantity of item supplied is also added to the quantity of item stored in the STOCK.")

        If MessageBox.Show(objStringBuilder1.ToString, My.Application.Info.Title, _
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            stockAccess.AddBranchAndItemReceived(cboItemName.Text, dtpDateOfReceived.Value.Date, txtBranch.Text, txtQuantity.Text)

            Dim strExceptionBranchAndItemReceived As String = stockAccess.strExceptionAddBranchAndItemReceivedDetails
            If strExceptionBranchAndItemReceived <> "" Then
                MsgBox(strExceptionBranchAndItemReceived)

                'Set strExceptionAddBranchAndItemReceivedDetails to nothing
                stockAccess.strExceptionAddBranchAndItemReceivedDetails = Nothing
            Else
                MessageBox.Show(objStringBuilder2.ToString, My.Application.Info.Title, MessageBoxButtons.OK, MessageBoxIcon.Information)


                Query()
                FillDataGridView()
                GetBranchLocation()
                ClearFields()

                'Set the record position to the last record..
                objCurrencyManager.Position = objCurrencyManager.Count - 1
            End If
        Else
            'Do nothing

        End If
    End Sub

    'ADD ITEM RECEIVED AND ITEM DETAILS
    Private Sub AddItemReceivedAndItem()
        Dim objStringBuilder1 As New System.Text.StringBuilder
        Dim objStringBuilder2 As New System.Text.StringBuilder

        'Add the question
        objStringBuilder1.AppendLine("Do you want to add the following new information?")
        objStringBuilder1.AppendLine(String.Empty)
        objStringBuilder1.AppendLine("INFO ABOUT EXISTING SUPPLYING BRANCH: " & cboBranch.Text)
        objStringBuilder1.AppendLine("INFO ABOUT NEW ITEM : " & txtItemName.Text)
        objStringBuilder1.AppendLine("DATE OF RECEIVED : " & dtpDateOfReceived.Text)
        objStringBuilder1.AppendLine("QUANTITY : " & txtQuantity.Text)
        objStringBuilder1.AppendLine(String.Empty)
        objStringBuilder1.AppendLine("NOTE: The current quantity of item received will also be added to the STOCK.")

        objStringBuilder2.AppendLine("The following information has been added...!")
        objStringBuilder2.AppendLine(String.Empty)
        objStringBuilder2.AppendLine("INFO ABOUT SUPPLYING BRANCH: " & cboBranch.Text)
        objStringBuilder2.AppendLine("INFO ABOUT ITEM : " & txtItemName.Text)
        objStringBuilder2.AppendLine("DATE OF RECEIVED : " & dtpDateOfReceived.Text)
        objStringBuilder2.AppendLine("QUANTITY : " & txtQuantity.Text)
        objStringBuilder2.AppendLine(String.Empty)
        objStringBuilder2.AppendLine("NOTE: The current quantity of item received is also added to the STOCK.")
        If MessageBox.Show(objStringBuilder1.ToString, My.Application.Info.Title, _
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            stockAccess.AddItemReceivedAndItem(txtItemName.Text, dtpDateOfReceived.Value.Date, cboBranch.Text, txtQuantity.Text)

            Dim strExceptionItemReceivedAndItem As String = stockAccess.strExceptionAddItemReceivedAndItemDetails
            If strExceptionItemReceivedAndItem <> "" Then
                MsgBox(strExceptionItemReceivedAndItem)

                'Set strExceptionAddItemReceivedAndItemDetails to nothing
                stockAccess.strExceptionAddItemReceivedAndItemDetails = Nothing
            Else
                MessageBox.Show(objStringBuilder2.ToString, My.Application.Info.Title, MessageBoxButtons.OK, MessageBoxIcon.Information)


                Query()
                FillDataGridView()
                GetItemName()
                ClearFields()

                'Set the record position to the last record..
                objCurrencyManager.Position = objCurrencyManager.Count - 1
            End If

        Else
            'Do nothing

        End If
    End Sub


    'ADD BRANCH AND ITEM RECEIVED AND ITEM DETAILS
    Private Sub AddBranchAndItemReceivedAndItem()
        Dim objStringBuilder1 As New System.Text.StringBuilder
        Dim objStringBuilder2 As New System.Text.StringBuilder

        'Add the question
        objStringBuilder1.AppendLine("Do you want to add the following new information?")
        objStringBuilder1.AppendLine(String.Empty)
        objStringBuilder1.AppendLine("INFO ABOUT NEW SUPPLYING BRANCH: " & txtBranch.Text)
        objStringBuilder1.AppendLine("INFO ABOUT NEW ITEM : " & txtItemName.Text)
        objStringBuilder1.AppendLine("DATE OF RECEIVED : " & dtpDateOfReceived.Text)
        objStringBuilder1.AppendLine("QUANTITY : " & txtQuantity.Text)
        objStringBuilder1.AppendLine(String.Empty)
        objStringBuilder1.AppendLine("NOTE: The current quantity of item received will also be added to the STOCK.")

        objStringBuilder2.AppendLine("The following information has been added...!")
        objStringBuilder2.AppendLine(String.Empty)
        objStringBuilder2.AppendLine("INFO ABOUT SUPPLYING BRANCH: " & txtBranch.Text)
        objStringBuilder2.AppendLine("INFO ABOUT ITEM : " & txtItemName.Text)
        objStringBuilder2.AppendLine("DATE OF RECEIVED : " & dtpDateOfReceived.Text)
        objStringBuilder2.AppendLine("QUANTITY : " & txtQuantity.Text)
        objStringBuilder2.AppendLine(String.Empty)
        objStringBuilder2.AppendLine("NOTE: The current quantity of item received is also added to the STOCK.")
        If MessageBox.Show(objStringBuilder1.ToString, My.Application.Info.Title, _
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            stockAccess.AddBranchAndItemReceivedAndItem(txtItemName.Text, dtpDateOfReceived.Value.Date, txtBranch.Text, txtQuantity.Text)

            Dim strExceptionBranchAndItemReceivedAndItem As String = stockAccess.strExceptionAddBranchAndItemReceivedAndItemDetails
            If strExceptionBranchAndItemReceivedAndItem <> "" Then
                MsgBox(strExceptionBranchAndItemReceivedAndItem)

                'Set strExceptionAddBranchAndItemReceivedAndItemDetails to nothing
                stockAccess.strExceptionAddBranchAndItemReceivedAndItemDetails = Nothing
            Else
                MessageBox.Show(objStringBuilder2.ToString, My.Application.Info.Title, MessageBoxButtons.OK, MessageBoxIcon.Information)

                Query()
                FillDataGridView()
                GetBranchLocation()
                GetItemName()
                ClearFields()

                'Set the record position to the last record..
                objCurrencyManager.Position = objCurrencyManager.Count - 1
            End If
        Else
            'Do nothing

        End If
    End Sub







    Private Sub btnView_Click(sender As Object, e As EventArgs) Handles btnView.Click
        If btnView.Text = "View" Then

            'Make sure that some panels are visible
            pnltxtBranch.Visible = True
            pnltxtItemName.Visible = True

            'Make Branch and Item label control visible
            lblBranch.Visible = True
            lblItemName.Visible = True

            'Make some panels hidden
            pnlcboBranch.Visible = False
            pnlcboItemName.Visible = False


            btnView.Text = "Cancel View"

            'Make buttons enabled
            ViewEnabledButtons()

            'Disabled some buttons
            btnClear.Enabled = False
            btnSave.Enabled = False
            btnRefresh.Enabled = False
            chkBranch.Enabled = False
            chkItemName.Enabled = False
            chkDate.Enabled = False

            'Make sure that all the text fields readonly property is true
            ReadOnlyTrue()

            'Bind fields
            BindFields()
            ShowPosition()

            'Call CheckedPropertyFalse to unselect check list in the Search GroupBox
            CheckedPropertyFalse()
        Else
            'Make Branch and Item label control visible
            lblBranch.Visible = False
            lblItemName.Visible = False

            'Make some panels visible
            pnlcboBranch.Visible = True
            pnlcboItemName.Visible = True

            btnView.Text = "View"

            'Make buttons disabled
            ViewDisabledButtons()

            'Enabled some buttons
            btnClear.Enabled = True
            btnSave.Enabled = True
            btnRefresh.Enabled = True
            chkBranch.Enabled = True
            chkItemName.Enabled = True
            chkDate.Enabled = True

            'Make sure that all the text fields readonly property is false
            ReadOnlyFalse()

            'Clear fields
            ClearDataBindings()
            ClearFields()
            'Clear the Record Position Text Box Clear
            txtRecordPosition.Text = ""
        End If
    End Sub

    'MAKE SURE THAT THE TEXT FIELDS READONLY PROPERTY IS FALSE
    Private Sub ReadOnlyFalse()
        txtBranch.ReadOnly = False
        txtItemName.ReadOnly = False
        txtQuantity.ReadOnly = False
    End Sub

    'MAKE SURE THAT THE TEXT FIELDS READONLY PROPERTY IS TRUE
    Private Sub ReadOnlyTrue()
        txtBranch.ReadOnly = True
        txtItemName.ReadOnly = True
        txtQuantity.ReadOnly = True
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
    End Sub







    'CLEAR THE TEXT FIELDS
    Private Sub ClearFields()
        cboBranch.SelectedIndex = 0
        txtBranch.Clear()
        cboItemName.SelectedIndex = 0
        txtItemName.Clear()
        dtpDateOfReceived.Value = Now
        txtQuantity.Clear()
        cboItemName.Focus()
    End Sub


    'BIND THE CONTROLS TO DATAVIEW OBJECT..
    Private Sub BindFields()
        ClearDataBindings()

        'Add new bindings to the DataView object..
        txtBranch.DataBindings.Add("Text", objDataView, "Supplying_branch")
        txtItemName.DataBindings.Add("Text", objDataView, "Item_name")
        dtpDateOfReceived.DataBindings.Add("Value", objDataView, "Date_of_received")
        txtQuantity.DataBindings.Add("Text", objDataView, "Quantity")
    End Sub

    'CLEAR DATABINDINGS..
    Private Sub ClearDataBindings()
        'Clear any previous databindings...
        txtBranch.DataBindings.Clear()
        txtItemName.DataBindings.Clear()
        dtpDateOfReceived.DataBindings.Clear()
        txtQuantity.DataBindings.Clear()
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

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        ClearFields()
    End Sub






    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        Dim objStringBuilder1 As New System.Text.StringBuilder
        Dim objStringBuilder2 As New System.Text.StringBuilder

        'Add the question
        objStringBuilder1.AppendLine("Do you really want to delete the information of this supplied item?")
        objStringBuilder1.AppendLine(String.Empty)
        objStringBuilder1.AppendLine("INFO ABOUT SUPPLYING BRANCH: " & txtBranch.Text)
        objStringBuilder1.AppendLine("INFO ABOUT ITEM : " & txtItemName.Text)
        objStringBuilder1.AppendLine("DATE OF RECEIVED : " & dtpDateOfReceived.Text)
        objStringBuilder1.AppendLine("QUANTITY : " & txtQuantity.Text)

        objStringBuilder2.AppendLine("Do you also want to deduct the quantity of item store in STOCK?")
        objStringBuilder2.AppendLine("INFO ABOUT ITEM : " & txtItemName.Text)
        objStringBuilder2.AppendLine("QUANTITY : " & txtQuantity.Text & " will also be deducted from the total amount stored in STOCK.")

        If MessageBox.Show(objStringBuilder1.ToString, My.Application.Info.Title, _
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            Dim intDialogResult As DialogResult = MessageBox.Show(objStringBuilder2.ToString, My.Application.Info.Title, _
                               MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)
            Select Case intDialogResult
                Case DialogResult.Yes
                    DeleteItemReceivedAndDeductFromStock()
                Case DialogResult.No
                    DeleteItemReceivedAndNonDeductFromStock()
                Case Else
                    'Do nothing

            End Select
        Else
            'Do nothing

        End If
    End Sub

    Private Sub DeleteItemReceivedAndDeductFromStock()
        Dim intPosition As Integer = objCurrencyManager.Position - 1
        If intPosition < 0 Then
            intPosition = 0
        End If

        stockAccess.DeleteItemReceivedAndDeductFromStock(txtItemName.Text, dtpDateOfReceived.Value.Date, txtBranch.Text, txtQuantity.Text)

        Dim objStringBuilder As New System.Text.StringBuilder

        'Add the question
        objStringBuilder.AppendLine("The following information has been deleted...!")
        objStringBuilder.AppendLine(String.Empty)
        objStringBuilder.AppendLine("INFO ABOUT SUPPLYING BRANCH: " & txtBranch.Text)
        objStringBuilder.AppendLine("INFO ABOUT ITEM : " & txtItemName.Text)
        objStringBuilder.AppendLine("DATE OF RECEIVED : " & dtpDateOfReceived.Text)
        objStringBuilder.AppendLine("QUANTITY : " & txtQuantity.Text)
        objStringBuilder.AppendLine(String.Empty)
        objStringBuilder.AppendLine("QUANTITY SUBTRACT FROM STOCK : " & txtQuantity.Text)
        objStringBuilder.AppendLine("NOTE: The current quantity of item deleted is also subtracted from the quantity of item stored in the STOCK.")

        Dim strExceptionDeleteItemReceived As String = stockAccess.strExceptionDeleteItemReceivedAndDeductFromStock
        If strExceptionDeleteItemReceived <> "" Then
            MsgBox(strExceptionDeleteItemReceived)

            'Set  strExceptionDeleteItemReceivedAndDeductFromStock to Nothing
            stockAccess.strExceptionDeleteItemReceivedAndDeductFromStock = Nothing
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

    Private Sub DeleteItemReceivedAndNonDeductFromStock()
        Dim intPosition As Integer = objCurrencyManager.Position - 1
        If intPosition < 0 Then
            intPosition = 0
        End If

        stockAccess.DeleteItemReceivedAndNonDeductFromStock(txtItemName.Text, dtpDateOfReceived.Value.Date, txtBranch.Text)

        Dim objStringBuilder As New System.Text.StringBuilder

        'Add the question
        objStringBuilder.AppendLine("The following information has been deleted...!")
        objStringBuilder.AppendLine(String.Empty)
        objStringBuilder.AppendLine("INFO ABOUT SUPPLYING BRANCH: " & txtBranch.Text)
        objStringBuilder.AppendLine("INFO ABOUT ITEM : " & txtItemName.Text)
        objStringBuilder.AppendLine("DATE OF RECEIVED : " & dtpDateOfReceived.Text)
        objStringBuilder.AppendLine("QUANTITY : " & txtQuantity.Text)


        Dim strExceptionDeleteItemReceived As String = stockAccess.strExceptionDeleteItemReceivedAndNonDeductFromStock
        If strExceptionDeleteItemReceived <> "" Then
            MsgBox(strExceptionDeleteItemReceived)

            'Set strExceptionDeleteItemReceivedAndNonDeductFromStock to Nothing
            stockAccess.strExceptionDeleteItemReceivedAndNonDeductFromStock = Nothing
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

    Private Sub grdItemReceived_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles grdItemReceived.CellClick
        If btnView.Text <> "View" Then
            'Show position of the GridView row in the Record Position Text Box
            ShowPosition()
        End If
    End Sub


    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        ItemReceivedFormControl_Load(Nothing, Nothing)
    End Sub






    'QUERY TO FILL CUSTOMERNAME COMBOBX FOR SEARCHING
    Private Sub GetBranchLocationForSearching()
        'Clear the existing records..
        If stockAccess.objBranchLocationDataTableForSearching IsNot Nothing Then
            stockAccess.objBranchLocationDataTableForSearching.Clear()
        End If

        stockAccess.GetBranchNameForSearchingComboBox("SELECT * FROM BRANCH " & _
                                               "ORDER BY Branch_location")

        If stockAccess.strExceptionGetBranchLocationForSearching <> "" Then
            'Show error message
            MessageBox.Show(stockAccess.strExceptionGetBranchLocationForSearching, My.Application.Info.Title, MessageBoxButtons.OK, MessageBoxIcon.Error)

            'Set the variable to nothing
            stockAccess.strExceptionGetBranchLocationForSearching = Nothing
        Else
            cboSearchBranch.DataSource = stockAccess.objBranchLocationDataTableForSearching
            cboSearchBranch.DisplayMember = "Branch_location"
        End If
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
        If chkDate.Checked = True Or chkItemName.Checked = True Or chkBranch.Checked = True Then
            btnSearch.Enabled = True
        ElseIf chkDate.Checked = False Or chkItemName.Checked = False Or chkBranch.Checked = False Then
            btnSearch.Enabled = False
        End If
    End Sub

    'UNSELECT THE CHECKED PROPERTY OF CHECKBOX AND RADIOBUTTON
    Private Sub CheckedPropertyFalse()
        'Make sure that Searching checklist are not selected
        chkBranch.Checked = False
        chkItemName.Checked = False
        chkDate.Checked = False
    End Sub

    Private Sub chkBranch_CheckedChanged(sender As Object, e As EventArgs) Handles chkBranch.CheckedChanged
        If chkBranch.Checked = True Then
            'Get a list of item for searching
            GetBranchLocationForSearching()

            'Make Branch ComboBox visible
            cboSearchBranch.Visible = True
        Else
            'Set the DataTable to nothing
            stockAccess.objBranchLocationDataTableForSearching = Nothing

            'Make Branch ComboBox hidden
            cboSearchBranch.Visible = False
        End If

        'Call the CheckBoxClick procedure
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

        'IF ALL BRANCH AND ITEMNAME AND YEAR ARE SELECTED
        If chkBranch.Checked = True And chkItemName.Checked = True And rdbYear.Checked = True Then
            stockAccess.RunQueryForSearchingRecords("SELECT [Serial No],STOCK.Item_name, Date_of_received, Supplying_Branch, Quantity, Quantity_on_hand " & _
                           "FROM RECEIVED_FROM_BRANCH, STOCK " & _
                           "WHERE RECEIVED_FROM_BRANCH.Item_name = STOCK.Item_name " & _
                           "AND RECEIVED_FROM_BRANCH.Supplying_Branch = '" & cboSearchBranch.Text & "' " & _
                           "AND RECEIVED_FROM_BRANCH.Item_name = '" & cboSearchItemName.Text & "' " & _
                           "AND YEAR(Date_of_received) =" & dtpSearchSelectAYear.Value.Year & _
                           " ORDER BY [Serial No]")

            'IF ALL BRANCH AND ITEMNAME AND NOOFDAYS ARE SELECTED
        ElseIf chkBranch.Checked = True And chkItemName.Checked = True And rdbNoOfDays.Checked = True Then
            stockAccess.RunQueryForSearchingRecords("SELECT [Serial No],STOCK.Item_name, Date_of_received, Supplying_Branch, Quantity, Quantity_on_hand " & _
                           "FROM RECEIVED_FROM_BRANCH, STOCK " & _
                           "WHERE RECEIVED_FROM_BRANCH.Item_name = STOCK.Item_name " & _
                           "AND RECEIVED_FROM_BRANCH.Supplying_Branch = '" & cboSearchBranch.Text & "' " & _
                           "AND RECEIVED_FROM_BRANCH.Item_name = '" & cboSearchItemName.Text & "' " & _
                           "AND Date_of_received BETWEEN #" & dtpSearchStartingDate.Value.Date & "# " & _
                           "AND #" & dtpSearchEndingDate.Value.Date & "# " & _
                           " ORDER BY [Serial No]")

            'IF ALL BRANCH AND ITEMNAME AND A DAY ARE SELECTED
        ElseIf chkBranch.Checked = True And chkItemName.Checked = True And rdbDay.Checked = True Then
            stockAccess.RunQueryForSearchingRecords("SELECT [Serial No],STOCK.Item_name, Date_of_received, Supplying_Branch, Quantity, Quantity_on_hand " & _
                         "FROM RECEIVED_FROM_BRANCH, STOCK " & _
                         "WHERE RECEIVED_FROM_BRANCH.Item_name = STOCK.Item_name " & _
                         "AND RECEIVED_FROM_BRANCH.Supplying_Branch = '" & cboSearchBranch.Text & "' " & _
                         "AND RECEIVED_FROM_BRANCH.Item_name = '" & cboSearchItemName.Text & "' " & _
                        "AND Date_of_received =#" & dtpSearchSelectADay.Value.Date & "# " & _
                         " ORDER BY [Serial No]")

            'IF BRANCH AND ITEMNAME ARE SELECTED
        ElseIf chkBranch.Checked = True And chkItemName.Checked = True Then
            stockAccess.RunQueryForSearchingRecords("SELECT [Serial No],STOCK.Item_name, Date_of_received, Supplying_Branch, Quantity, Quantity_on_hand " & _
                        "FROM RECEIVED_FROM_BRANCH, STOCK " & _
                        "WHERE RECEIVED_FROM_BRANCH.Item_name = STOCK.Item_name " & _
                        "AND RECEIVED_FROM_BRANCH.Supplying_Branch = '" & cboSearchBranch.Text & "' " & _
                        "AND RECEIVED_FROM_BRANCH.Item_name = '" & cboSearchItemName.Text & "' " & _
                        " ORDER BY [Serial No]")

            'IF BRANCH AND YEAR ARE SELECTED
        ElseIf chkBranch.Checked = True And rdbYear.Checked = True Then
            stockAccess.RunQueryForSearchingRecords("SELECT [Serial No],STOCK.Item_name, Date_of_received, Supplying_Branch, Quantity, Quantity_on_hand " & _
                          "FROM RECEIVED_FROM_BRANCH, STOCK " & _
                          "WHERE RECEIVED_FROM_BRANCH.Item_name = STOCK.Item_name " & _
                          "AND RECEIVED_FROM_BRANCH.Supplying_Branch = '" & cboSearchBranch.Text & "' " & _
                          "AND YEAR(Date_of_received) =" & dtpSearchSelectAYear.Value.Year & _
                          " ORDER BY [Serial No]")

            'IF BRANCH AND AND NOOFDAYS ARE SELECTED
        ElseIf chkBranch.Checked = True And rdbNoOfDays.Checked = True Then
            stockAccess.RunQueryForSearchingRecords("SELECT [Serial No],STOCK.Item_name, Date_of_received, Supplying_Branch, Quantity, Quantity_on_hand " & _
                          "FROM RECEIVED_FROM_BRANCH, STOCK " & _
                          "WHERE RECEIVED_FROM_BRANCH.Item_name = STOCK.Item_name " & _
                          "AND RECEIVED_FROM_BRANCH.Supplying_Branch = '" & cboSearchBranch.Text & "' " & _
                          "AND Date_of_received BETWEEN #" & dtpSearchStartingDate.Value.Date & "# " & _
                          "AND #" & dtpSearchEndingDate.Value.Date & "# " & _
                          " ORDER BY [Serial No]")

            'IF BRANCH AND A DAY ARE SELECTED
        ElseIf chkBranch.Checked = True And rdbDay.Checked = True Then
            stockAccess.RunQueryForSearchingRecords("SELECT [Serial No],STOCK.Item_name, Date_of_received, Supplying_Branch, Quantity, Quantity_on_hand " & _
                       "FROM RECEIVED_FROM_BRANCH, STOCK " & _
                       "WHERE RECEIVED_FROM_BRANCH.Item_name = STOCK.Item_name " & _
                       "AND RECEIVED_FROM_BRANCH.Supplying_Branch = '" & cboSearchBranch.Text & "' " & _
                      "AND Date_of_received =#" & dtpSearchSelectADay.Value.Date & "# " & _
                       " ORDER BY [Serial No]")

            'IF  ITEMNAME AND YEAR ARE SELECTED
        ElseIf chkItemName.Checked = True And rdbYear.Checked = True Then
            stockAccess.RunQueryForSearchingRecords("SELECT [Serial No],STOCK.Item_name, Date_of_received, Supplying_Branch, Quantity, Quantity_on_hand " & _
                           "FROM RECEIVED_FROM_BRANCH, STOCK " & _
                           "WHERE RECEIVED_FROM_BRANCH.Item_name = STOCK.Item_name " & _
                           "AND RECEIVED_FROM_BRANCH.Item_name = '" & cboSearchItemName.Text & "' " & _
                           "AND YEAR(Date_of_received) =" & dtpSearchSelectAYear.Value.Year & _
                           " ORDER BY [Serial No]")

            'IF ITEMNAME AND NOOFDAYS ARE SELECTED
        ElseIf chkItemName.Checked = True And rdbNoOfDays.Checked = True Then
            stockAccess.RunQueryForSearchingRecords("SELECT [Serial No],STOCK.Item_name, Date_of_received, Supplying_Branch, Quantity, Quantity_on_hand " & _
                         "FROM RECEIVED_FROM_BRANCH, STOCK " & _
                         "WHERE RECEIVED_FROM_BRANCH.Item_name = STOCK.Item_name " & _
                         "AND RECEIVED_FROM_BRANCH.Item_name = '" & cboSearchItemName.Text & "' " & _
                         "AND Date_of_received BETWEEN #" & dtpSearchStartingDate.Value.Date & "# " & _
                         "AND #" & dtpSearchEndingDate.Value.Date & "# " & _
                         " ORDER BY [Serial No]")

            'IF ITEMNAME AND A DAY ARE SELECTED
        ElseIf chkItemName.Checked = True And rdbDay.Checked = True Then
            stockAccess.RunQueryForSearchingRecords("SELECT [Serial No],STOCK.Item_name, Date_of_received, Supplying_Branch, Quantity, Quantity_on_hand " & _
                       "FROM RECEIVED_FROM_BRANCH, STOCK " & _
                       "WHERE RECEIVED_FROM_BRANCH.Item_name = STOCK.Item_name " & _
                      "AND RECEIVED_FROM_BRANCH.Item_name = '" & cboSearchItemName.Text & "' " & _
                       "AND Date_of_received =#" & dtpSearchSelectADay.Value.Date & "# " & _
                       " ORDER BY [Serial No]")

            'IF ONLY BRANCH IS SELECTED
        ElseIf chkBranch.Checked = True Then
            stockAccess.RunQueryForSearchingRecords("SELECT [Serial No],STOCK.Item_name, Date_of_received, Supplying_Branch, Quantity, Quantity_on_hand " & _
                           "FROM RECEIVED_FROM_BRANCH, STOCK " & _
                           "WHERE RECEIVED_FROM_BRANCH.Item_name = STOCK.Item_name " & _
                           "AND RECEIVED_FROM_BRANCH.Supplying_Branch = '" & cboSearchBranch.Text & "' " & _
                           " ORDER BY [Serial No]")

            'IF ONLY ITEMNAME IS SELECTED
        ElseIf chkItemName.Checked = True Then
            stockAccess.RunQueryForSearchingRecords("SELECT [Serial No],STOCK.Item_name, Date_of_received, Supplying_Branch, Quantity, Quantity_on_hand " & _
                           "FROM RECEIVED_FROM_BRANCH, STOCK " & _
                           "WHERE RECEIVED_FROM_BRANCH.Item_name = STOCK.Item_name " & _
                           "AND RECEIVED_FROM_BRANCH.Item_name = '" & cboSearchItemName.Text & "' " & _
                           " ORDER BY [Serial No]")

            'IF ONLY YEAR RADIOBUTTON IS SELECTED
        ElseIf rdbYear.Checked = True Then
            stockAccess.RunQueryForSearchingRecords("SELECT [Serial No],STOCK.Item_name, Date_of_received, Supplying_Branch, Quantity, Quantity_on_hand " & _
                           "FROM RECEIVED_FROM_BRANCH, STOCK " & _
                           "WHERE RECEIVED_FROM_BRANCH.Item_name = STOCK.Item_name " & _
                           "AND YEAR(Date_of_received) =" & dtpSearchSelectAYear.Value.Year & _
                           " ORDER BY [Serial No]")

            'IF NO OF DAYS RADIOBUTTON IS SELECTED
        ElseIf rdbNoOfDays.Checked = True Then
            stockAccess.RunQueryForSearchingRecords("SELECT [Serial No],STOCK.Item_name, Date_of_received, Supplying_Branch, Quantity, Quantity_on_hand " & _
                         "FROM RECEIVED_FROM_BRANCH, STOCK " & _
                         "WHERE RECEIVED_FROM_BRANCH.Item_name = STOCK.Item_name " & _
                         "AND Date_of_received BETWEEN #" & dtpSearchStartingDate.Value.Date & "# " & _
                         "AND #" & dtpSearchEndingDate.Value.Date & "# " & _
                         " ORDER BY [Serial No]")

            'IF ONLY  A RADIOBUTTON FOR A DAY IS SELECTED
        ElseIf rdbDay.Checked = True Then
            stockAccess.RunQueryForSearchingRecords("SELECT [Serial No],STOCK.Item_name, Date_of_received, Supplying_Branch, Quantity, Quantity_on_hand " & _
                  "FROM RECEIVED_FROM_BRANCH, STOCK " & _
                  "WHERE RECEIVED_FROM_BRANCH.Item_name = STOCK.Item_name " & _
                  "AND Date_of_received =#" & dtpSearchSelectADay.Value.Date & "# " & _
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
            GblAccessObject.objDataTableOfItemReceivedForm = dt
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
                .strSender = "ItemReceived"
                .ShowDialog()
            End With
        End Using
    End Sub

    Private Sub txtQuantity_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtQuantity.KeyPress
        e.Handled = Not Char.IsDigit(e.KeyChar)
    End Sub
End Class