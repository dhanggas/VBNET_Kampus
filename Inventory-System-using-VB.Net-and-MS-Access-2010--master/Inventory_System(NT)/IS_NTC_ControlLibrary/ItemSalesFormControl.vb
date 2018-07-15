Public Class ItemSalesFormControl
    Private storeAccess As New StoreAccess
    Private objDataView As DataView
    Private objCurrencyManager As CurrencyManager
    Private dt As DataTable

    Private Sub ItemSalesFormControl_Load(sender As Object, e As EventArgs) Handles Me.Load
        If storeAccess.HasConnection = True Then
            Query()
            FillDataGridView()
            GetItemName()
            GetCustomerName()

            'MAKE SURE ALL CONTROLS ARE CLEARED AND WITH DEFAULT VALUE
            'ClearFields()      

            txtCustomerName.Focus()

            'MAKE SURE THAT THE SEARCHING CHECKLIST FOR SEARCH GROUPBOX ARE NOT SELECTED
            CheckedPropertyFalse()
        Else
            'Show error message
            MessageBox.Show(storeAccess.strExceptionHasConnection, My.Application.Info.Title, MessageBoxButtons.OK, MessageBoxIcon.Error)

            'Set variable to nothing
            storeAccess.strExceptionHasConnection = Nothing
        End If
    End Sub

    'Query to fill DataGridView for ItemSalesForm
    Private Sub Query()
        'Clear existing records
        If storeAccess.objDataSet IsNot Nothing Then
            storeAccess.objDataSet.Clear()
        End If

        storeAccess.RunQuery("SELECT [Serial No], STORE.Item_name,Customer_name, CUSTOMER.Customer_ph_no,  Date_of_bought, Quantity, Quantity_on_hand " & _
                             "FROM CUSTOMER,SALES, STORE " & _
                             "WHERE CUSTOMER.Customer_ph_no=SALES.Customer_ph_no " & _
                             "AND SALES.Item_name=STORE.Item_name " & _
                             "ORDER BY [Serial No]")

        If storeAccess.strExceptionRunQuery <> "" Then
            'Show error message
            MessageBox.Show(storeAccess.strExceptionRunQuery, My.Application.Info.Title, MessageBoxButtons.OK, MessageBoxIcon.Error)

            'Set the variable to nothing
            storeAccess.strExceptionRunQuery = Nothing
        Else
            dt = storeAccess.AutoNumberedTable(storeAccess.objDataSet.Tables(0))
            GblAccessObject.objDataTableOfItemSalesForm = dt

            'Set the DataView object to the DataSet object..
            objDataView = New DataView(dt)

            'Set the CurrencyManager object to the DataView object...
            objCurrencyManager = CType(Me.BindingContext(objDataView), CurrencyManager)
        End If
    End Sub


    Private Sub FillDataGridView()
        'grdItemSales.DataSource = storeAccess.AutoNumberedTable(storeAccess.objDataSet.Tables(0))
        grdItemSales.DataSource = objDataView

        grdItemSales.Font = New Font(grdItemSales.DefaultCellStyle.Font.FontFamily, 10, FontStyle.Regular)
        'Declare and set the column header style
        Dim objColumnHeaderStyle As New DataGridViewCellStyle
        objColumnHeaderStyle.BackColor = Color.Silver
        objColumnHeaderStyle.ForeColor = Color.Black
        objColumnHeaderStyle.Font = New Font(grdItemSales.DefaultCellStyle.Font.FontFamily, 9, FontStyle.Bold)
        objColumnHeaderStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        grdItemSales.ColumnHeadersDefaultCellStyle = objColumnHeaderStyle

        'Declare and set the default rows style
        Dim objAlignRightCellStyle As New DataGridViewCellStyle
        objAlignRightCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        grdItemSales.RowsDefaultCellStyle = objAlignRightCellStyle

        'Declare and set the alternating rows style
        Dim objAlternatingCellStyle As New DataGridViewCellStyle
        objAlternatingCellStyle.BackColor = Color.WhiteSmoke
        grdItemSales.AlternatingRowsDefaultCellStyle = objAlternatingCellStyle

        With grdItemSales
            .RowHeadersVisible = False
            .Columns(0).HeaderCell.Value = "S.N."
            .Columns(1).HeaderCell.Value = "ITEM NAME"
            .Columns(2).HeaderCell.Value = "CUSTOMER NAME"
            .Columns(3).HeaderCell.Value = "CUSTOMER PHONE NUMBER"
            .Columns(4).HeaderCell.Value = "DATE OF SALES"
            .Columns(5).HeaderCell.Value = "QUANTITY"
            .Columns(6).HeaderCell.Value = "CURRENT QUANTITY IN STORE"
        End With
    End Sub

    Private Sub ClearFields()
        cboItemName.SelectedIndex = 0
        txtItemName.Clear()
        cboCustomerName.SelectedIndex = 0
        txtCustomerName.Clear()
        txtCustomerPhoneNumber.Clear()
        dtpDateOfBought.Value = Now
        txtQuantity.Clear()
        txtCustomerName.Focus()
    End Sub

    Private Sub GetItemName()
        'Clear existing records
        If storeAccess.objItemNameDataTable IsNot Nothing Then
            storeAccess.objItemNameDataTable.Clear()
        End If

        storeAccess.GetItemNameForComboBox("SELECT Item_name FROM STORE " & _
                                               "ORDER BY Item_name")


        If storeAccess.strExceptionGetItemName <> "" Then
            'Show error message
            MessageBox.Show(storeAccess.strExceptionGetItemName, My.Application.Info.Title, MessageBoxButtons.OK, MessageBoxIcon.Error)

            'Set the variable to nothing
            storeAccess.strExceptionGetItemName = Nothing
        Else
            'If records are found, add them to the combobox
            If storeAccess.objItemNameDataTable.Rows.Count > 0 Then
                'Remove the first row from the objItemNameDataTable
                storeAccess.objItemNameDataTable.Rows(0).Delete()
                cboItemName.DataSource = storeAccess.objItemNameDataTable
                cboItemName.DisplayMember = "Item_name"
            End If
        End If
    End Sub

    Private Sub GetCustomerName()
        'Clear the existing records..
        If storeAccess.objCustomerNameDataTable IsNot Nothing Then
            storeAccess.objCustomerNameDataTable.Clear()
        End If

        storeAccess.GetCustomerNameForComboBox("SELECT Customer_ph_no, Customer_name FROM CUSTOMER " & _
                                               "ORDER BY Customer_name")

        If storeAccess.strExceptionGetCustomerName <> "" Then
            'Show error message
            MessageBox.Show(storeAccess.strExceptionGetCustomerName, My.Application.Info.Title, MessageBoxButtons.OK, MessageBoxIcon.Error)

            'Set the variable to nothing
            storeAccess.strExceptionGetCustomerName = Nothing
        Else
            'If records are found, add them to the combobox
            If storeAccess.objCustomerNameDataTable.Rows.Count > 0 Then
                cboCustomerName.DataSource = storeAccess.objCustomerNameDataTable
                cboCustomerName.DisplayMember = "Customer_name"
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
        dtpDateOfBought.DataBindings.Add("Value", objDataView, "Date_of_bought")
        txtQuantity.DataBindings.Add("Text", objDataView, "Quantity")
    End Sub

    'CLEAR THE DATABINDINGS
    Private Sub ClearDataBindings()
        'Clear any previous bindings
        txtItemName.DataBindings.Clear()
        txtCustomerName.DataBindings.Clear()
        txtCustomerPhoneNumber.DataBindings.Clear()
        dtpDateOfBought.DataBindings.Clear()
        txtQuantity.DataBindings.Clear()
    End Sub

    'BIND THE CONTROLS WITH CUSTOMER DATATABLE
    Private Sub BindFieldsForCustomer()
        'Clear any previous bindings
        txtCustomerPhoneNumber.DataBindings.Clear()

        'Binding process
        txtCustomerPhoneNumber.DataBindings.Add("Text", storeAccess.objCustomerNameDataTable, "Customer_ph_no")
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

    Private Sub grdItemSales_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles grdItemSales.CellClick
        If btnView.Text <> "View" Then
            'Show position of the GridView row in the Record Position Text Box
            ShowPosition()
        End If
    End Sub


  





    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If pnltxtCustomerName.Visible = True Then
            AddSalesAndCustomerDetails()
        Else
            AddSalesDetails()
        End If


    End Sub

    'ADD SALES AND NEW CUSTOMER DETAILS
    Private Sub AddSalesAndCustomerDetails()
        Dim objStringBuilder1 As New System.Text.StringBuilder
        Dim objStringBuilder2 As New System.Text.StringBuilder

        'Add the question
        objStringBuilder1.AppendLine("Do you want to add the following sales information?")
        objStringBuilder1.AppendLine(String.Empty)
        objStringBuilder1.AppendLine("INFO ABOUT NEW CUSTOMER : " & txtCustomerName.Text & ", " & txtCustomerPhoneNumber.Text)
        objStringBuilder1.AppendLine("INFO ABOUT ITEM : " & cboItemName.Text)
        objStringBuilder1.AppendLine("DATE OF SUPPLIED : " & dtpDateOfBought.Text)
        objStringBuilder1.AppendLine("QUANTITY SUPPLIED : " & txtQuantity.Text)

        objStringBuilder2.AppendLine("Do you also want to deduct the quantity of item store in STORE?")
        objStringBuilder2.AppendLine("INFO ABOUT ITEM : " & cboItemName.Text)
        objStringBuilder2.AppendLine("QUANTITY : " & txtQuantity.Text & " will also be deducted from the total amount stored in STORE.")

        If MessageBox.Show(objStringBuilder1.ToString, My.Application.Info.Title, _
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            Dim intDialogResult As DialogResult = MessageBox.Show(objStringBuilder2.ToString, My.Application.Info.Title, _
                               MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)
            Select Case intDialogResult
                Case DialogResult.Yes
                    AddSalesAndCustomerDetailsAndDeductFromStore()

                Case DialogResult.No
                    AddSalesAndCustomerDetailsAndNonDeductFromStore()
                
                Case Else
                    'Do nothing 
            End Select
        Else
            'Do nothing
        End If

        'Query()
        'ClearFields()
    End Sub

    'ADD SALES AND NEW CUSTOMER DETAILS AND DEDUCT THE QUANTITY OF ITEM SOLD FROM THE STORE
    Private Sub AddSalesAndCustomerDetailsAndDeductFromStore()
        storeAccess.AddSalesAndCustomerAndDeductFromStore(cboItemName.Text, dtpDateOfBought.Value.Date, txtCustomerPhoneNumber.Text, txtCustomerName.Text, txtQuantity.Text)

        Dim objStringBuilder As New System.Text.StringBuilder
        objStringBuilder.AppendLine("The following new information has been added...!")
        objStringBuilder.AppendLine(String.Empty)
        objStringBuilder.AppendLine("INFO ABOUT NEW CUSTOMER : " & txtCustomerName.Text & ", " & txtCustomerPhoneNumber.Text)
        objStringBuilder.AppendLine("INFO ABOUT ITEM : " & cboItemName.Text)
        objStringBuilder.AppendLine("DATE OF SUPPLIED : " & dtpDateOfBought.Text)
        objStringBuilder.AppendLine("QUANTITY SUPPLIED : " & txtQuantity.Text)
        objStringBuilder.AppendLine(String.Empty)
        objStringBuilder.AppendLine("QUANTITY SUBTRACTED FROM STORE : " & txtQuantity.Text)
        objStringBuilder.AppendLine("NOTE: The current quantity of item supplied is also deducted from the quantity of item stored in the STORE.")

        Dim strExceptionSalesAndCustomerDetails As String = storeAccess.strExceptionAddSalesAndCustomerDetailsDeductFromStore
        If strExceptionSalesAndCustomerDetails <> "" Then
            MsgBox(strExceptionSalesAndCustomerDetails)

            'Set strExceptionAddSalesAndCustomerDetailsDeductFromStore to nothing
            storeAccess.strExceptionAddSalesAndCustomerDetailsDeductFromStore = Nothing
        Else
            MessageBox.Show(objStringBuilder.ToString, My.Application.Info.Title, MessageBoxButtons.OK, MessageBoxIcon.Information)

            'Set store quantity to zero if quantity is less than zero
            StoreUpdateToZero.UpdateToZero()

            Query()
            FillDataGridView()
            GetCustomerName()
            ClearFields()

            'Set the record position to the last record..
            objCurrencyManager.Position = objCurrencyManager.Count - 1
        End If
    End Sub

    'ADD SALES AND NEW CUSTOMER DETAILS AND DO NOT DEDUCT THE QUANTITY OF ITEM SOLD FROM THE STORE
    Private Sub AddSalesAndCustomerDetailsAndNonDeductFromStore()
        storeAccess.AddSalesAndCustomerAndNonDeductFromStore(cboItemName.Text, dtpDateOfBought.Value.Date, txtCustomerPhoneNumber.Text, txtCustomerName.Text, txtQuantity.Text)

        Dim objStringBuilder As New System.Text.StringBuilder
        objStringBuilder.AppendLine("The following new information has been added...!")
        objStringBuilder.AppendLine(String.Empty)
        objStringBuilder.AppendLine("INFO ABOUT NEW CUSTOMER : " & txtCustomerName.Text & ", " & txtCustomerPhoneNumber.Text)
        objStringBuilder.AppendLine("INFO ABOUT ITEM : " & cboItemName.Text)
        objStringBuilder.AppendLine("DATE OF SUPPLIED : " & dtpDateOfBought.Text)
        objStringBuilder.AppendLine("QUANTITY SUPPLIED : " & txtQuantity.Text)

        Dim strExceptionSalesAndCustomerDetails As String = storeAccess.strExceptionAddSalesAndCustomerDetailsNonDeductFromStore
        If strExceptionSalesAndCustomerDetails <> "" Then
            MsgBox(strExceptionSalesAndCustomerDetails)

            'Set strExceptionAddSalesAndCustomerDetailsNonDeductFromStore to nothing
            storeAccess.strExceptionAddSalesAndCustomerDetailsNonDeductFromStore = Nothing
        Else
            MessageBox.Show(objStringBuilder.ToString, My.Application.Info.Title, MessageBoxButtons.OK, MessageBoxIcon.Information)

            'Set store quantity to zero if quantity is less than zero
            StoreUpdateToZero.UpdateToZero()

            Query()
            FillDataGridView()
            GetCustomerName()
            ClearFields()

            'Set the record position to the last record..
            objCurrencyManager.Position = objCurrencyManager.Count - 1
        End If
    End Sub

    'ADD SALES DETAILS
    Private Sub AddSalesDetails()
        Dim objStringBuilder1 As New System.Text.StringBuilder
        Dim objStringBuilder2 As New System.Text.StringBuilder

        'Add the question
        objStringBuilder1.AppendLine("Do you want to add the following sales information?")
        objStringBuilder1.AppendLine(String.Empty)
        objStringBuilder1.AppendLine("INFO ABOUT CUSTOMER : " & txtCustomerName.Text & ", " & txtCustomerPhoneNumber.Text)
        objStringBuilder1.AppendLine("INFO ABOUT ITEM : " & cboItemName.Text)
        objStringBuilder1.AppendLine("DATE OF SUPPLIED : " & dtpDateOfBought.Text)
        objStringBuilder1.AppendLine("QUANTITY SUPPLIED : " & txtQuantity.Text)

        objStringBuilder2.AppendLine("Do you also want to deduct the quantity of item store in STORE?")
        objStringBuilder2.AppendLine("INFO ABOUT ITEM : " & cboItemName.Text)
        objStringBuilder2.AppendLine("QUANTITY : " & txtQuantity.Text & " will also be deducted from the total amount stored in STORE.")

        If MessageBox.Show(objStringBuilder1.ToString, My.Application.Info.Title, _
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            Dim intDialogResult As DialogResult = MessageBox.Show(objStringBuilder2.ToString, My.Application.Info.Title, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)
            Select Case intDialogResult
                Case DialogResult.Yes
                    AddSalesDetailsAndDeductFromStore()
                   
                Case DialogResult.No
                    AddSalesDetailsAndNonDeductFromStore()
                Case Else
                    'Do nothing

            End Select
        Else
            'Do nothing
        End If
    End Sub

    'ADD SALES DETAILS AND DEDUCT THE QUANTITY OF ITEM SOLD FROM THE STORE
    Private Sub AddSalesDetailsAndDeductFromStore()
        storeAccess.AddSalesAndDeductFromStore(cboItemName.Text, dtpDateOfBought.Value.Date, txtCustomerPhoneNumber.Text, txtCustomerName.Text, txtQuantity.Text)

        Dim objStringBuilder As New System.Text.StringBuilder
        objStringBuilder.AppendLine("The following new information has been added...!")
        objStringBuilder.AppendLine(String.Empty)
        objStringBuilder.AppendLine("INFO ABOUT NEW CUSTOMER : " & cboCustomerName.Text & ", " & txtCustomerPhoneNumber.Text)
        objStringBuilder.AppendLine("INFO ABOUT ITEM : " & cboItemName.Text)
        objStringBuilder.AppendLine("DATE OF SUPPLIED : " & dtpDateOfBought.Text)
        objStringBuilder.AppendLine("QUANTITY SUPPLIED : " & txtQuantity.Text)
        objStringBuilder.AppendLine(String.Empty)
        objStringBuilder.AppendLine("QUANTITY SUBTRACTED FROM STORE : " & txtQuantity.Text)
        objStringBuilder.AppendLine("NOTE: The current quantity of item supplied is also deducted from the quantity of item stored in the STORE.")

        Dim strExceptionSalesAndCustomerDetails As String = storeAccess.strExceptionAddSalesDetailsDeductFromStore
        If strExceptionSalesAndCustomerDetails <> "" Then
            MsgBox(strExceptionSalesAndCustomerDetails)

            'Set strExceptionAddSalesDetailsDeductFromStore to nothing
            storeAccess.strExceptionAddSalesDetailsDeductFromStore = Nothing
        Else
            MessageBox.Show(objStringBuilder.ToString, My.Application.Info.Title, MessageBoxButtons.OK, MessageBoxIcon.Information)


            'Set store quantity to zero if quantity is less than zero
            StoreUpdateToZero.UpdateToZero()

            Query()
            FillDataGridView()
            ClearFields()

            'Set the record position to the last record..
            objCurrencyManager.Position = objCurrencyManager.Count - 1
        End If
    End Sub

    'ADD SALES DETAILS AND DO NOT DEDUCT THE QUANTITY OF ITEM SOLD FROM THE STORE
    Private Sub AddSalesDetailsAndNonDeductFromStore()
        storeAccess.AddSalesAndNonDeductFromStore(cboItemName.Text, dtpDateOfBought.Value.Date, txtCustomerPhoneNumber.Text, txtCustomerName.Text, txtQuantity.Text)

        Dim objStringBuilder As New System.Text.StringBuilder
        objStringBuilder.AppendLine("The following new information has been added...!")
        objStringBuilder.AppendLine(String.Empty)
        objStringBuilder.AppendLine("INFO ABOUT NEW CUSTOMER : " & cboCustomerName.Text & ", " & txtCustomerPhoneNumber.Text)
        objStringBuilder.AppendLine("INFO ABOUT ITEM : " & cboItemName.Text)
        objStringBuilder.AppendLine("DATE OF SUPPLIED : " & dtpDateOfBought.Text)
        objStringBuilder.AppendLine("QUANTITY SUPPLIED : " & txtQuantity.Text)

        Dim strExceptionSalesAndCustomerDetails As String = storeAccess.strExceptionAddSalesDetailsNonDeductFromStore
        If strExceptionSalesAndCustomerDetails <> "" Then
            MsgBox(strExceptionSalesAndCustomerDetails)

            'Set strExceptionAddSalesDetailsNonDeductFromStore to nothing
            storeAccess.strExceptionAddSalesDetailsNonDeductFromStore = Nothing
        Else
            MessageBox.Show(objStringBuilder.ToString, My.Application.Info.Title, MessageBoxButtons.OK, MessageBoxIcon.Information)


            'Set store quantity to zero if quantity is less than zero
            StoreUpdateToZero.UpdateToZero()

            Query()
            FillDataGridView()
            ClearFields()

            'Set the record position to the last record..
            objCurrencyManager.Position = objCurrencyManager.Count - 1
        End If
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
        objStringBuilder1.AppendLine("DATE OF BOUGHT : " & dtpDateOfBought.Text)
        objStringBuilder1.AppendLine("QUANTITY : " & txtQuantity.Text)

        objStringBuilder2.AppendLine("Do you also want to ADD the quantity of item store in STORE?")
        objStringBuilder2.AppendLine("INFO ABOUT ITEM : " & txtItemName.Text)
        objStringBuilder2.AppendLine("QUANTITY : " & txtQuantity.Text & " will also be added to the total quantity stored in STORE.")

        If MessageBox.Show(objStringBuilder1.ToString, My.Application.Info.Title, _
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            Dim intDialogResult As DialogResult = MessageBox.Show(objStringBuilder2.ToString, My.Application.Info.Title, _
                               MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)
            Select Case intDialogResult
                Case DialogResult.Yes
                    DeleteSalesAndAddToStore()
                Case DialogResult.No
                    DeleteSales()
                Case Else
                    'Do nothing
            End Select
        Else
            'Do nothing
        End If
    End Sub


    'DELETE THE ITEM SOLD DETAILS ONLY
    Public Sub DeleteSales()
        Dim intPosition As Integer = objCurrencyManager.Position - 1
        If intPosition < 0 Then
            intPosition = 0
        End If

        storeAccess.DeleteSales(txtItemName.Text, dtpDateOfBought.Value.Date, txtCustomerPhoneNumber.Text)

        Dim objStringBuilder As New System.Text.StringBuilder

        'Add the question
        objStringBuilder.AppendLine("The following information has been deleted...!")
        objStringBuilder.AppendLine(String.Empty)
        objStringBuilder.AppendLine("INFO ABOUT CUSTOMER : " & txtCustomerName.Text & ", " & txtCustomerPhoneNumber.Text)
        objStringBuilder.AppendLine("INFO ABOUT ITEM : " & txtItemName.Text)
        objStringBuilder.AppendLine("DATE OF BOUGHT : " & dtpDateOfBought.Text)
        objStringBuilder.AppendLine("QUANTITY : " & txtQuantity.Text)

        Dim strExceptionDeleteSalesData As String = storeAccess.strExceptionDeleteSales
        If strExceptionDeleteSalesData <> "" Then
            MsgBox(strExceptionDeleteSalesData)

            'Set strExceptionDeleteSales to nothing
            storeAccess.strExceptionDeleteSales = Nothing
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

    'DELETE THE ITEM SOLD DETAILS AND ALSO ADD THE QUANTITY OF ITEM TO THE STORE
    Public Sub DeleteSalesAndAddToStore()
        Dim intPosition As Integer = objCurrencyManager.Position - 1
        If intPosition < 0 Then
            intPosition = 0
        End If

        storeAccess.DeleteSalesAndAddToStore(txtItemName.Text, dtpDateOfBought.Value.Date, txtCustomerPhoneNumber.Text, txtQuantity.Text)

        Dim objStringBuilder As New System.Text.StringBuilder

        'Add the question
        objStringBuilder.AppendLine("The following information has been deleted...!")
        objStringBuilder.AppendLine(String.Empty)
        objStringBuilder.AppendLine("INFO ABOUT CUSTOMER : " & txtCustomerName.Text & ", " & txtCustomerPhoneNumber.Text)
        objStringBuilder.AppendLine("INFO ABOUT ITEM : " & txtItemName.Text)
        objStringBuilder.AppendLine("DATE OF BOUGHT : " & dtpDateOfBought.Text)
        objStringBuilder.AppendLine("QUANTITY : " & txtQuantity.Text)
        objStringBuilder.AppendLine(String.Empty)
        objStringBuilder.AppendLine("QUANTITY ADDED TO STORE : " & txtQuantity.Text)
        objStringBuilder.AppendLine("NOTE: The current quantity of item deleted is also added to the quantity of item stored in the STORE.")

        Dim strExceptionDeleteSalesDataAndAddToStore As String = storeAccess.strExceptionDeleteSalesAndAddToStore
        If strExceptionDeleteSalesDataAndAddToStore <> "" Then
            MsgBox(strExceptionDeleteSalesDataAndAddToStore)

            'Set strExceptionDeleteSalesAndAddToStore to nothing
            storeAccess.strExceptionDeleteSalesAndAddToStore = Nothing
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

    'Private Sub btnUpdate_Click(sender As Object, e As EventArgs)
    '    If btnUpdate.Text = "Edit" Then
    '        btnUpdate.Text = "Update"

    '        'Make sure that the some text fields readonly property is false
    '        txtQuantity.ReadOnly = False

    '        'Disabled DELETE button
    '        btnDelete.Enabled = False
    '    Else
    '        btnUpdate.Text = "Edit"

    '        'Make sure that all text fields readonly property is true
    '        ReadOnlyTrue()

    '        'Enabled DELETE button
    '        btnDelete.Enabled = True

    '        'Dim intPosition As Integer = objCurrencyManager.Position
    '        'storeAccess.UpdateData(dtpDateOfSupplied.Value.Date, txtRate.Text, txtQuantity.Text, txtAmount.Text, txtSupplierPhoneNumber.Text, txtItemName.Text)
    '        ''BindFields()
    '        ''objCurrencyManager.Position = intPosition
    '        ''ShowPosition()
    '        'Query()
    '    End If
    'End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        'Call ClearFields procedure
        ClearFields()
    End Sub


    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        ItemSalesFormControl_Load(Nothing, Nothing)
    End Sub






    'SEARCH BY CUSTOMER NAME, LIST OF PROCEDURES
    Private Sub chkCustomerName_CheckedChanged(sender As Object, e As EventArgs) Handles chkCustomerName.CheckedChanged
        If chkCustomerName.Checked = True Then
            'Get list of item for combo box
            GetCustomerNameForSearching()

            'Make corresponding controls visible
            cboSearchCustomerName.Visible = True
            pnlSearchCustomerPhoneNumber.Visible = True
        Else
            'Set the DataTable to nothing
            storeAccess.objCustomerNameDataTableForSearching = Nothing

            'Clear databindings for Customer control
            txtSearchCustomerPhoneNumber.DataBindings.Clear()

            'Make corresponding controls hidden
            cboSearchCustomerName.Visible = False
            pnlSearchCustomerPhoneNumber.Visible = False
        End If

        'Call CheckBoxClick procedure
        CheckBoxClick()
    End Sub

    Private Sub cboSearchCustomerName_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboSearchCustomerName.SelectedIndexChanged
        BindFieldsForCustomerForSearching()
    End Sub
    'Query to fill CustomerName ComboBox for searching
    Private Sub GetCustomerNameForSearching()
        'Clear the existing records..
        If storeAccess.objCustomernameDataTableForSearching IsNot Nothing Then
            storeAccess.objCustomernameDataTableForSearching.Clear()
        End If

        storeAccess.GetCustomerNameForSearchingComboBox("SELECT * FROM CUSTOMER " & _
                                               "ORDER BY Customer_name")

        If storeAccess.strExceptionGetCustomerNameForSearching <> "" Then
            'Show error message
            MessageBox.Show(storeAccess.strExceptionGetCustomerNameForSearching, My.Application.Info.Title, MessageBoxButtons.OK, MessageBoxIcon.Error)

            'Set the variable to nothing
            storeAccess.strExceptionGetCustomerNameForSearching = Nothing
        Else
            cboSearchCustomerName.DataSource = storeAccess.objCustomerNameDataTableForSearching
            cboSearchCustomerName.DisplayMember = "Customer_name"
        End If
    End Sub

    'BIND VALUES FOR CUSTOMER PHONE NUMBER
    Private Sub BindFieldsForCustomerForSearching()
        'Clear any previous bindings..
        txtSearchCustomerPhoneNumber.DataBindings.Clear()

        'Binding process
        txtSearchCustomerPhoneNumber.DataBindings.Add("Text", storeAccess.objCustomerNameDataTableForSearching, "Customer_ph_no")
    End Sub





    Private Sub chkItemName_CheckedChanged(sender As Object, e As EventArgs) Handles chkItemName.CheckedChanged
        If chkItemName.Checked = True Then
            'Get a list of item for combobox
            GetItemNameforSearching()

            'Make Search ItemName Combobox visible
            cboSearchItemName.Visible = True
        Else
            'Set the DataTable to nothing
            storeAccess.objItemNameDataTableForSearching = Nothing

            'Make Search ItemName Combobox hidden
            cboSearchItemName.Visible = False
        End If

        'Call CheckBoxClick procedure
        CheckBoxClick()
    End Sub

    Private Sub GetItemNameforSearching()
        'Clear existing records
        If storeAccess.objItemNameDataTableForSearching IsNot Nothing Then
            storeAccess.objItemNameDataTableForSearching.Clear()
        End If

        storeAccess.GetItemNameForComboBoxForSearching("SELECT Item_name FROM STORE " & _
                                               "ORDER BY Item_name")


        If storeAccess.strExceptionGetItemNameForSearching <> "" Then
            'Show error message
            MessageBox.Show(storeAccess.strExceptionGetItemNameForSearching, My.Application.Info.Title, MessageBoxButtons.OK, MessageBoxIcon.Error)

            'Set the variable to nothing
            storeAccess.strExceptionGetItemNameForSearching = Nothing
        Else
            cboSearchItemName.DataSource = storeAccess.objItemNameDataTableForSearching
            cboSearchItemName.DisplayMember = "Item_name"
        End If
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

    'CHECKING CHECKED PROPERTY OF CHECKBOX AND RADIOBUTTON TO ENABLE OR DISABLE THE SEARCH BUTTON
    Private Sub CheckBoxClick()
        If chkDate.Checked = True Or chkItemName.Checked = True Or chkCustomerName.Checked = True Then
            btnSearch.Enabled = True
        ElseIf chkDate.Checked = False Or chkItemName.Checked = False Or chkCustomerName.Checked = False Then
            btnSearch.Enabled = False
        End If
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
        If storeAccess.objDataSetSearchRecords IsNot Nothing Then
            storeAccess.objDataSetSearchRecords.Clear()
        End If


        'IF ALL CUSTOMER NAME AND ITEMNAME AND YEAR ARE SELECTED
        If chkCustomerName.Checked = True And chkItemName.Checked = True And rdbYear.Checked = True Then
            storeAccess.RunQueryForSearchingRecords("SELECT [Serial No], STORE.Item_name,Customer_name, CUSTOMER.Customer_ph_no,  Date_of_bought, Quantity, Quantity_on_hand " & _
                             "FROM CUSTOMER,SALES, STORE " & _
                             "WHERE CUSTOMER.Customer_ph_no=SALES.Customer_ph_no " & _
                             "AND SALES.Item_name=STORE.Item_name " & _
    "AND CUSTOMER.Customer_ph_no='" & txtSearchCustomerPhoneNumber.Text & "' " & _
     "AND SALES.Item_name='" & cboSearchItemName.Text & "' " & _
      "AND YEAR(Date_of_bought)=" & dtpSearchSelectAYear.Value.Year & _
    " ORDER BY [Serial No] ")

            'IF ALL CUSTOMERNAME AND ITEMNAME AND NO OF DAYS ARE SELECTED
        ElseIf chkCustomerName.Checked = True And chkItemName.Checked = True And rdbNoOfDays.Checked = True Then
            storeAccess.RunQueryForSearchingRecords("SELECT [Serial No], STORE.Item_name,Customer_name, CUSTOMER.Customer_ph_no,  Date_of_bought, Quantity, Quantity_on_hand " & _
                             "FROM CUSTOMER,SALES, STORE " & _
                             "WHERE CUSTOMER.Customer_ph_no=SALES.Customer_ph_no " & _
                             "AND SALES.Item_name=STORE.Item_name " & _
    "AND CUSTOMER.Customer_ph_no='" & txtSearchCustomerPhoneNumber.Text & "' " & _
     "AND SALES.Item_name='" & cboSearchItemName.Text & "' " & _
    "AND Date_of_bought BETWEEN #" & dtpSearchStartingDate.Value.Date & "# " & _
    "AND #" & dtpSearchEndingDate.Value.Date & "# " & _
    "ORDER BY [Serial No] ")

            'IF ALL CUSTOMERNAME AND ITEMNAME AND A DAY ARE SELECTED
        ElseIf chkCustomerName.Checked = True And chkItemName.Checked = True And rdbDay.Checked = True Then
            storeAccess.RunQueryForSearchingRecords("SELECT [Serial No], STORE.Item_name,Customer_name, CUSTOMER.Customer_ph_no,  Date_of_bought, Quantity, Quantity_on_hand " & _
                             "FROM CUSTOMER,SALES, STORE " & _
                             "WHERE CUSTOMER.Customer_ph_no=SALES.Customer_ph_no " & _
                             "AND SALES.Item_name=STORE.Item_name " & _
    "AND CUSTOMER.Customer_ph_no='" & txtSearchCustomerPhoneNumber.Text & "' " & _
     "AND SALES.Item_name='" & cboSearchItemName.Text & "' " & _
    "AND Date_of_bought= #" & dtpSearchSelectADay.Value.Date & "# " & _
    "ORDER BY [Serial No] ")

            'IF BOTH CUSTOMERNAME AND ITEMNAME IS CHECKED
        ElseIf chkCustomerName.Checked = True And chkItemName.Checked = True Then
            storeAccess.RunQueryForSearchingRecords("SELECT [Serial No], STORE.Item_name,Customer_name, CUSTOMER.Customer_ph_no,  Date_of_bought, Quantity, Quantity_on_hand " & _
                             "FROM CUSTOMER,SALES, STORE " & _
                             "WHERE CUSTOMER.Customer_ph_no=SALES.Customer_ph_no " & _
                             "AND SALES.Item_name=STORE.Item_name " & _
    "AND CUSTOMER.Customer_ph_no='" & txtSearchCustomerPhoneNumber.Text & "' " & _
     "AND SALES.Item_name='" & cboSearchItemName.Text & "' " & _
     "ORDER BY [Serial No] ")

            'IF CUSTOMERNAME AND YEAR ARE SELECTED
        ElseIf chkCustomerName.Checked = True And rdbYear.Checked = True Then
            storeAccess.RunQueryForSearchingRecords("SELECT [Serial No], STORE.Item_name,Customer_name, CUSTOMER.Customer_ph_no,  Date_of_bought, Quantity, Quantity_on_hand " & _
                             "FROM CUSTOMER,SALES, STORE " & _
                             "WHERE CUSTOMER.Customer_ph_no=SALES.Customer_ph_no " & _
                             "AND SALES.Item_name=STORE.Item_name " & _
    "AND CUSTOMER.Customer_ph_no='" & txtSearchCustomerPhoneNumber.Text & "' " & _
    "AND YEAR(Date_of_bought)=" & dtpSearchSelectAYear.Value.Year & _
    " ORDER BY [Serial No] ")

            'IF CUSTOMERNAME AND NO OF DAYS ARE SELECTED
        ElseIf chkCustomerName.Checked = True And rdbNoOfDays.Checked = True Then
            storeAccess.RunQueryForSearchingRecords("SELECT [Serial No], STORE.Item_name,Customer_name, CUSTOMER.Customer_ph_no,  Date_of_bought, Quantity, Quantity_on_hand " & _
                             "FROM CUSTOMER,SALES, STORE " & _
                             "WHERE CUSTOMER.Customer_ph_no=SALES.Customer_ph_no " & _
                             "AND SALES.Item_name=STORE.Item_name " & _
    "AND CUSTOMER.Customer_ph_no='" & txtSearchCustomerPhoneNumber.Text & "' " & _
    "AND Date_of_bought BETWEEN #" & dtpSearchStartingDate.Value.Date & "# " & _
    "AND #" & dtpSearchEndingDate.Value.Date & "# " & _
      "ORDER BY Date_of_bought ")

            'IF CUSTOMERNAME AND A DAY ARE SELECTED
        ElseIf chkCustomerName.Checked = True And rdbDay.Checked = True Then
            storeAccess.RunQueryForSearchingRecords("SELECT [Serial No], STORE.Item_name,Customer_name, CUSTOMER.Customer_ph_no,  Date_of_bought, Quantity, Quantity_on_hand " & _
                             "FROM CUSTOMER,SALES, STORE " & _
                             "WHERE CUSTOMER.Customer_ph_no=SALES.Customer_ph_no " & _
                             "AND SALES.Item_name=STORE.Item_name " & _
    "AND CUSTOMER.Customer_ph_no='" & txtSearchCustomerPhoneNumber.Text & "' " & _
    "AND Date_of_bought=#" & dtpSearchSelectADay.Value.Date & "# " & _
    "ORDER BY Date_of_bought ")

            'IF ITEMNAME AND YEAR ARE SELECTED
        ElseIf chkItemName.Checked = True And rdbYear.Checked = True Then
            storeAccess.RunQueryForSearchingRecords("SELECT [Serial No], STORE.Item_name,Customer_name, CUSTOMER.Customer_ph_no,  Date_of_bought, Quantity, Quantity_on_hand " & _
                             "FROM CUSTOMER,SALES, STORE " & _
                             "WHERE CUSTOMER.Customer_ph_no=SALES.Customer_ph_no " & _
                             "AND SALES.Item_name=STORE.Item_name " & _
    "AND SALES.Item_name='" & cboSearchItemName.Text & "' " & _
    "AND YEAR(Date_of_bought)=" & dtpSearchSelectAYear.Value.Year & _
    " ORDER BY [Serial No] ")

            'IF ITEM NAME AND NO OF DAYS ARE SELECTED
        ElseIf chkItemName.Checked = True And rdbNoOfDays.Checked = True Then
            storeAccess.RunQueryForSearchingRecords("SELECT [Serial No], STORE.Item_name,Customer_name, CUSTOMER.Customer_ph_no,  Date_of_bought, Quantity, Quantity_on_hand " & _
                             "FROM CUSTOMER,SALES, STORE " & _
                             "WHERE CUSTOMER.Customer_ph_no=SALES.Customer_ph_no " & _
                             "AND SALES.Item_name=STORE.Item_name " & _
    "AND SALES.Item_name='" & cboSearchItemName.Text & "' " & _
    "AND Date_of_bought BETWEEN #" & dtpSearchStartingDate.Value.Date & "# " & _
    "AND #" & dtpSearchEndingDate.Value.Date & "# " & _
       "ORDER BY Date_of_bought ")

            'IF ITEM NAME AND SELECT A DAY ARE SELECTED
        ElseIf chkItemName.Checked = True And rdbDay.Checked = True Then
            storeAccess.RunQueryForSearchingRecords("SELECT [Serial No], STORE.Item_name,Customer_name, CUSTOMER.Customer_ph_no,  Date_of_bought, Quantity, Quantity_on_hand " & _
                             "FROM CUSTOMER,SALES, STORE " & _
                             "WHERE CUSTOMER.Customer_ph_no=SALES.Customer_ph_no " & _
                             "AND SALES.Item_name=STORE.Item_name " & _
    "AND SALES.Item_name='" & cboSearchItemName.Text & "' " & _
             "AND Date_of_bought=#" & dtpSearchSelectADay.Value.Date & "# " & _
             "ORDER BY Date_of_bought ")

            'IF ONLY CUSTOMERNAME IS CHECKED
        ElseIf chkCustomerName.Checked = True Then
            storeAccess.RunQueryForSearchingRecords("SELECT [Serial No], STORE.Item_name,Customer_name, CUSTOMER.Customer_ph_no,  Date_of_bought, Quantity, Quantity_on_hand " & _
                             "FROM CUSTOMER,SALES, STORE " & _
                             "WHERE CUSTOMER.Customer_ph_no=SALES.Customer_ph_no " & _
                             "AND SALES.Item_name=STORE.Item_name " & _
    "AND CUSTOMER.Customer_ph_no='" & txtSearchCustomerPhoneNumber.Text & "' " & _
      "ORDER BY [Serial No] ")

            'IF ONLY ITEMNAME IS CHECKED
        ElseIf chkItemName.Checked = True Then
            storeAccess.RunQueryForSearchingRecords("SELECT [Serial No], STORE.Item_name,Customer_name, CUSTOMER.Customer_ph_no,  Date_of_bought, Quantity, Quantity_on_hand " & _
                             "FROM CUSTOMER,SALES, STORE " & _
                             "WHERE CUSTOMER.Customer_ph_no=SALES.Customer_ph_no " & _
                             "AND SALES.Item_name=STORE.Item_name " & _
    "AND SALES.Item_name='" & cboSearchItemName.Text & "' " & _
      "ORDER BY [Serial No] ")

            'IF ONLY YEAR RADIOBUTTON IS SELECTED
        ElseIf rdbYear.Checked = True Then
            storeAccess.RunQueryForSearchingRecords("SELECT [Serial No], STORE.Item_name,Customer_name, CUSTOMER.Customer_ph_no,  Date_of_bought, Quantity, Quantity_on_hand " & _
                             "FROM CUSTOMER,SALES, STORE " & _
                             "WHERE CUSTOMER.Customer_ph_no=SALES.Customer_ph_no " & _
                             "AND SALES.Item_name=STORE.Item_name " & _
        "AND YEAR(Date_of_bought)=" & dtpSearchSelectAYear.Value.Year & " " & _
      "ORDER BY [Serial No] ")

            'IF NO OF DAYS RADIOBUTTON IS SELECTED
        ElseIf rdbNoOfDays.Checked = True Then
            storeAccess.RunQueryForSearchingRecords("SELECT [Serial No], STORE.Item_name,Customer_name, CUSTOMER.Customer_ph_no,  Date_of_bought, Quantity, Quantity_on_hand " & _
                             "FROM CUSTOMER,SALES, STORE " & _
                             "WHERE CUSTOMER.Customer_ph_no=SALES.Customer_ph_no " & _
                             "AND SALES.Item_name=STORE.Item_name " & _
    "AND Date_of_bought BETWEEN #" & dtpSearchStartingDate.Value.Date & "# " & _
    "AND #" & dtpSearchEndingDate.Value.Date & "# " & _
       "ORDER BY Date_of_bought ")

            'IF ONLY  A RADIOBUTTON FOR A DAY IS SELECTED
        ElseIf rdbDay.Checked = True Then
            storeAccess.RunQueryForSearchingRecords("SELECT [Serial No], STORE.Item_name,Customer_name, CUSTOMER.Customer_ph_no,  Date_of_bought, Quantity, Quantity_on_hand " & _
                             "FROM CUSTOMER,SALES, STORE " & _
                             "WHERE CUSTOMER.Customer_ph_no=SALES.Customer_ph_no " & _
                             "AND SALES.Item_name=STORE.Item_name " & _
     "AND Date_of_bought=#" & dtpSearchSelectADay.Value.Date & "# " & _
        "ORDER BY [Serial No] ")
        End If

        If storeAccess.strExceptionSearchRecords <> "" Then
            MsgBox(storeAccess.strExceptionSearchRecords)

            'Set it to nothing
            storeAccess.strExceptionSearchRecords = Nothing
        Else
            dt = storeAccess.AutoNumberedTable(storeAccess.objDataSetSearchRecords.Tables(0))
            GblAccessObject.objDataTableOfItemSalesForm = dt

            'Set the DataView object to the DataSet object..
            objDataView = New DataView(dt)

            'Set the CurrencyManager object to the DataView object...
            objCurrencyManager = CType(Me.BindingContext(objDataView), CurrencyManager)

            FillDataGridView()
        End If


        'CHECK THE NUMBER OF RECORDS IN DATASET OBJECT IN STOREACCESS CLASS
        If storeAccess.intNumberOfRecords > 0 Then
            If storeAccess.intNumberOfRecords = 1 Then
                MessageBox.Show(storeAccess.intNumberOfRecords & " Record Found!", "SEARCHING RECORDS", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                MessageBox.Show(storeAccess.intNumberOfRecords & " Records Found!", "SEARCHING RECORDS", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Else
            MessageBox.Show("No Records Found for this Search!", "SEARCHING RECORDS", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If

        'Set intNumberOfRecords to Nothing
        storeAccess.intNumberOfRecords = Nothing
    End Sub


    'UNSELECT THE CHECKED PROPERTY OF CHECKBOX AND RADIOBUTTON
    Private Sub CheckedPropertyFalse()
        'Make sure that Searching checklist are not selected
        chkCustomerName.Checked = False
        chkItemName.Checked = False
        chkDate.Checked = False
    End Sub

   
    Private Sub btnGetReport_Click(sender As Object, e As EventArgs) Handles btnGetReport.Click
        Using objReportForm As New ReportForm
            With objReportForm
                .strSender = "ItemSales"
                .ShowDialog()
            End With
        End Using
    End Sub

    Private Sub txtQuantity_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtQuantity.KeyPress
        e.Handled = Not Char.IsDigit(e.KeyChar)
    End Sub
End Class
