Public Class ItemEntranceFormControl
    Private storeAccess As New StoreAccess
    Public objDataView As DataView
    Private objCurrencyManager As CurrencyManager
    Private dt As DataTable
    Public dt1 As DataTable
    Public dt2 As DataTable
    'Private objSupplierDataView As DataView
    'Private objSupplierCurrencyManager As CurrencyManager

    'Private currentView As DataGridView

    'Public Function DataGridView() As DataGridView
    '    'currentView = grdItemEntrance.ClipboardCopyMode
    '    'DataGridViewRowCount = grdItemEntrance.DataSource
    '    currentView = New DataGridView
    '    currentView.DataSource = storeAccess.AutoNumberedTable(storeAccess.objDataSet.Tables(0))
    '    Return currentView
    'End Function


    'Public WriteOnly Property DataGridViewRowCount() As DataGridView
    '    Set(value As DataGridView)
    '        'value = grdItemEntrance.DataSource
    '        currentView = New DataGridView
    '        currentView = value
    '    End Set
    'End Property


    'Public Function grdDataSet(sourceTable As DataTable) As DataTable
    '    Dim dt As DataTable
    '    dt = storeAccess.AutoNumberedTable(storeAccess.objDataSet.Tables(0))
    '    Return dt
    'End Function

    Public Function grdDataTable(sourceTable As DataTable) As DataTable
        dt2 = New DataTable
        With dt2.Columns
            .Add("S.N.")
            .Add("SUPPLIER NAME")
            .Add("SUPPLIER ADDRESS")
            .Add("SUPPLIER PHONE NUMBER")
            .Add("ITEM NAME")
            .Add("DATE OF ENTRANCE")
            .Add("RATE")
            .Add("QUANTITY")
            .Add("AMOUNT")
            .Add("CURRENT QUANTITY IN STORE")
        End With

        For Each r As DataRow In sourceTable.Rows
            For Each c As DataColumn In dt2.Columns
                dt2.Rows.Add(r(c))
            Next
        Next

        Return dt2
    End Function
        


    Private Sub ItemEntranceFormControl_Load(sender As Object, e As EventArgs) Handles Me.Load
        If storeAccess.HasConnection = True Then
            Query()
            FillDataGridView()
            GetSupplierName()
            GetItemName()

            'MAKE SURE SOME CONTROLS CAN BE TYPED
            ReadOnlyFalse()

            'MAKE SURE ALL CONTROLS ARE CLEARED AND WITH DEFAULT VALUE
            ClearFields()

            'MAKE SURE THAT THE SEARCHING CHECKLIST FOR SEARCH GROUPBOX ARE NOT SELECTED
            CheckedPropertyFalse()

            'objMainForm.StripMenuItemClick(sender, e)
            'Call StripMenuItemClick procedure

        Else
            'Show error message
            MessageBox.Show(storeAccess.strExceptionHasConnection, My.Application.Info.Title, MessageBoxButtons.OK, MessageBoxIcon.Error)

            'Set variable to nothing
            storeAccess.strExceptionHasConnection = Nothing
        End If
    End Sub

    'Query to fill DataGridView for the ItemEntranceForm
    Private Sub Query()
        'Clear existing records
        If storeAccess.objDataSet IsNot Nothing Then
            storeAccess.objDataSet.Clear()
        End If

        storeAccess.RunQuery("SELECT [Serial No], Supplier_name,Supplier_address,SUPPLIER.Supplier_ph_no, ITEM_SUPPLIED.Item_name, Date_of_supplied, Rate, Quantity,(Rate * Quantity) As Amount, Quantity_on_hand " & _
        "FROM ITEM_SUPPLIED,SUPPLIER, STORE " & _
        "WHERE ITEM_SUPPLIED.Supplier_ph_no=SUPPLIER.Supplier_ph_no " & _
        "AND ITEM_SUPPLIED.Item_name = STORE.Item_name " & _
        "ORDER BY [Serial No] ")
        If storeAccess.strExceptionRunQuery <> "" Then
            'Show error message
            MessageBox.Show(storeAccess.strExceptionRunQuery, My.Application.Info.Title, MessageBoxButtons.OK, MessageBoxIcon.Error)

            'Set the variable to nothing
            storeAccess.strExceptionRunQuery = Nothing
        Else
            dt = storeAccess.AutoNumberedTable(storeAccess.objDataSet.Tables(0))
            GblAccessObject.objDataTableOfItemEntranceForm = dt

            'Set the DataView object to the DataSet object..
            objDataView = New DataView(dt)

            'Dim dt As New DataTable
            'dt = storeAccess.AutoNumberedTable(storeAccess.objDataSet.Tables(0))
            dt1 = storeAccess.AutoNumberedTable(storeAccess.objDataSet.Tables(0))

            'Set the CurrencyManager object to the DataView object...
            objCurrencyManager = CType(Me.BindingContext(objDataView), CurrencyManager)
        End If
    End Sub


    Public Sub FillDataGridView()
        grdItemEntrance.DataSource = objDataView


        grdItemEntrance.Font = New Font(grdItemEntrance.DefaultCellStyle.Font.FontFamily, 10, FontStyle.Regular)

        'Declare and set the column header style
        Dim objColumnHeaderStyle As New DataGridViewCellStyle
        objColumnHeaderStyle.BackColor = Color.Silver
        objColumnHeaderStyle.ForeColor = Color.Black
        'objColumnHeaderStyle.Font = New Font(grdItemEntrance.Font, FontStyle.Bold)
        objColumnHeaderStyle.Font = New Font(grdItemEntrance.DefaultCellStyle.Font.FontFamily, 9, FontStyle.Bold)
        objColumnHeaderStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        grdItemEntrance.ColumnHeadersDefaultCellStyle = objColumnHeaderStyle

        'Declare and set the default rows style
        Dim objAlignRightCellStyle As New DataGridViewCellStyle
        objAlignRightCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        grdItemEntrance.RowsDefaultCellStyle = objAlignRightCellStyle

        'Declare and set the alternating rows style
        Dim objAlternatingCellStyle As New DataGridViewCellStyle
        objAlternatingCellStyle.BackColor = Color.WhiteSmoke
        grdItemEntrance.AlternatingRowsDefaultCellStyle = objAlternatingCellStyle

        With grdItemEntrance
            .RowHeadersVisible = False
            .Columns(0).HeaderCell.Value = "S.N."
            .Columns(0).Width = 45
            .Columns(1).HeaderCell.Value = "SUPPLIER NAME"
            .Columns(1).Width = 130
            .Columns(2).HeaderCell.Value = "SUPPLIER ADDRESS"
            .Columns(2).Width = 160
            .Columns(3).HeaderCell.Value = "SUPPLIER PHONE NUMBER"
            .Columns(3).Width = 200
            .Columns(4).HeaderCell.Value = "ITEM NAME"
            .Columns(5).HeaderCell.Value = "DATE OF ENTRANCE"
            .Columns(5).Width = 150
            .Columns(6).HeaderCell.Value = "RATE"
            .Columns(6).Width = 60
            .Columns(7).HeaderCell.Value = "QUANTITY"
            .Columns(7).Width = 80
            .Columns(8).HeaderCell.Value = "AMOUNT"
            .Columns(8).Width = 80
            .Columns(9).HeaderCell.Value = "CURRENT QUANTITY IN STORE"
            .Columns(9).Width = 230
        End With
    End Sub

    'Query to fill suppliername combobox
    Private Sub GetSupplierName()
        'Clear existing records
        If storeAccess.objSupplierNameDataTable IsNot Nothing Then
            storeAccess.objSupplierNameDataTable.Clear()
        End If

        storeAccess.GetSupplierNameForComboBox("SELECT * FROM SUPPLIER " & _
                                               "ORDER BY Supplier_name")

        If storeAccess.strExceptionGetSupplierName <> "" Then
            'Show error message
            MessageBox.Show(storeAccess.strExceptionGetSupplierName, My.Application.Info.Title, MessageBoxButtons.OK, MessageBoxIcon.Error)

            'Set the variable to nothing
            storeAccess.strExceptionGetSupplierName = Nothing
        Else
            If storeAccess.objSupplierNameDataTable.Rows.Count > 0 Then
                cboSupplierName.DataSource = storeAccess.objSupplierNameDataTable
                cboSupplierName.DisplayMember = "Supplier_name"

                ''cboSupplierName.ValueMember = "Supplier_ph_no"

                cboSupplierName.SelectedIndex = 0
            End If
        End If


    End Sub

    'BIND VALUES FOR SUPPLIER ADDRESS AND PHONE NUMBER
    Private Sub BindFieldsForSupplier()
        'Clear any previous bindings..
        txtSupplierAddress.DataBindings.Clear()
        txtSupplierPhoneNumber.DataBindings.Clear()

        'Binding process
        txtSupplierAddress.DataBindings.Add("Text", storeAccess.objSupplierNameDataTable, "Supplier_address")
        txtSupplierPhoneNumber.DataBindings.Add("Text", storeAccess.objSupplierNameDataTable, "Supplier_ph_no")
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
                cboItemName.DataSource = storeAccess.objItemNameDataTable
                cboItemName.DisplayMember = "Item_name"

                'Set the combobox to first record
                cboItemName.SelectedIndex = 0

            End If
        End If
    End Sub

    'CLEAR THE TEXT OF THE CONTROLS
    Private Sub ClearFields()
        cboSupplierName.SelectedIndex = 0
        txtSupplierName.Clear()
        txtSupplierAddress.Clear()
        txtSupplierPhoneNumber.Clear()
        cboItemName.SelectedIndex = 0
        txtItemName.Clear()
        dtpDateOfSupplied.Value = Now
        txtRate.Clear()
        txtQuantity.Clear()
        txtAmount.Clear()
        txtSupplierName.Focus()
    End Sub

    'MAKE SOME CONTROLS VISIBLE OR HIDDEN OR READONLY OR BINDING VALUES TO THEM BASED ON SELECTED VALUE IN SUPPLIERNAME COMBOBOX
    Private Sub cboSupplierName_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboSupplierName.SelectedIndexChanged
        If cboSupplierName.SelectedIndex <> 0 Then
            txtSupplierAddress.ReadOnly = True
            txtSupplierPhoneNumber.ReadOnly = True
            pnltxtSupplierName.Visible = False
            BindFieldsForSupplier()
        Else
            txtSupplierAddress.ReadOnly = False
            txtSupplierPhoneNumber.ReadOnly = False
            txtSupplierAddress.Text = ""
            txtSupplierPhoneNumber.Text = ""
            pnltxtSupplierName.Visible = True
            BindFieldsForSupplier()
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

    Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        ItemEntranceFormControl_Load(Nothing, Nothing)
    End Sub

    Private Sub grdItemEntrance_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles grdItemEntrance.CellClick
        If btnView.Text <> "View" Then
            'Show position of the GridView row in the Record Position Text Box
            ShowPosition()
        End If
    End Sub

   



    Private Sub ShowPosition()
        'Display the current position and the number of records
        txtRecordPosition.Text = objCurrencyManager.Position + 1 & " of " & objCurrencyManager.Count()
    End Sub

    'BIND THE CONTROLS TO DATAVIEW OBJECT
    Private Sub BindFields()
        ClearDataBindings()

        'Add new bindings to the DataView object..
        txtSupplierName.DataBindings.Add("Text", objDataView, "Supplier_name")
        txtSupplierAddress.DataBindings.Add("Text", objDataView, "Supplier_address")
        txtSupplierPhoneNumber.DataBindings.Add("Text", objDataView, "Supplier_ph_no")
        txtItemName.DataBindings.Add("Text", objDataView, "Item_name")
        dtpDateOfSupplied.DataBindings.Add("Value", objDataView, "Date_of_supplied")
        txtRate.DataBindings.Add("Text", objDataView, "Rate")
        txtQuantity.DataBindings.Add("Text", objDataView, "Quantity")
        txtAmount.DataBindings.Add("Text", objDataView, "Amount")
    End Sub

    'CLEAR THE DATABINDING
    Private Sub ClearDataBindings()
        'Clear any previous bindings...
        txtSupplierName.DataBindings.Clear()
        txtSupplierAddress.DataBindings.Clear()
        txtSupplierPhoneNumber.DataBindings.Clear()
        txtItemName.DataBindings.Clear()
        dtpDateOfSupplied.DataBindings.Clear()
        txtRate.DataBindings.Clear()
        txtQuantity.DataBindings.Clear()
        txtAmount.DataBindings.Clear()
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

        'Show the current record position..
        ShowPosition()
    End Sub

    Private Sub btnMoveNext_Click(sender As Object, e As EventArgs) Handles btnMoveNext.Click
        'Set the record position to next record..
        objCurrencyManager.Position += 1

        'Show the current record position..
        ShowPosition()
    End Sub

    Private Sub btnMoveLast_Click(sender As Object, e As EventArgs) Handles btnMoveLast.Click
        'Set the record position to the last record..
        objCurrencyManager.Position = objCurrencyManager.Count - 1

        'Show the current record position..
        ShowPosition()
    End Sub






    Private Sub btnView_Click(sender As Object, e As EventArgs) Handles btnView.Click
        If btnView.Text = "View" Then
            'Make some panels hidden
            pnlcboSupplierName.Visible = False
            pnlcboItemName.Visible = False


            'Make sure some panels are visible
            pnltxtItemName.Visible = True
            pnltxtSupplierName.Visible = True
            pnltxtAmount.Visible = True

            'Make some text visible
            lblSupplierName.Visible = True
            lblItemName.Visible = True

            'Change button View Text
            btnView.Text = "Cancel View"

            'btnUpdate.Text = "Edit"

            'Make buttons enabled
            ViewEnabledButtons()

            'Disabled some buttons
            btnClear.Enabled = False
            btnSave.Enabled = False
            btnRefresh.Enabled = False
            chkSupplierName.Enabled = False
            chkItemName.Enabled = False
            chkDate.Enabled = False

            'Query()
            BindFields()
            ShowPosition()


            'Make sure that all the text fields readonly property is true
            ReadOnlyTrue()

            'Call CheckedPropertyFalse to unselect check list in the Search GroupBox
            CheckedPropertyFalse()
        Else
            ClearDataBindings()

            'Change button View Text
            btnView.Text = "View"

            'Make some panels visible
            pnlcboSupplierName.Visible = True
            pnlcboItemName.Visible = True

            'Make some of the text hidden
            lblSupplierName.Visible = False
            lblItemName.Visible = False

            'Make Amount Panel hidden
            pnltxtAmount.Visible = False

            'btnUpdate.Text = "Update"

            'Make buttons disabled
            ViewDisabledButtons()


            'Enabled some buttons
            btnClear.Enabled = True
            btnSave.Enabled = True
            btnRefresh.Enabled = True
            chkSupplierName.Enabled = True
            chkItemName.Enabled = True
            chkDate.Enabled = True

            'Clear the RecordPosition TextBox 
            txtRecordPosition.Text = ""

            'Make sure that all the text fields readonly property is false
            ReadOnlyFalse()

            ClearFields()

            ''Make sure that the Search Button is enabled
            'btnSearch.Enabled = True
        End If

    End Sub

    'MAKE SURE THAT THE TEXT FIELDS READONLY PROPERTY IS FALSE
    Private Sub ReadOnlyFalse()
        txtSupplierName.ReadOnly = False
        txtSupplierAddress.ReadOnly = False
        txtSupplierPhoneNumber.ReadOnly = False
        txtItemName.ReadOnly = False
        txtRate.ReadOnly = False
        txtQuantity.ReadOnly = False
        txtAmount.ReadOnly = False
    End Sub

    'MAKE SURE THAT THE TEXT FIELDS READONLY PROPERTY IS TRUE
    Private Sub ReadOnlyTrue()
        txtSupplierName.ReadOnly = True
        txtSupplierAddress.ReadOnly = True
        txtSupplierPhoneNumber.ReadOnly = True
        txtItemName.ReadOnly = True
        txtRate.ReadOnly = True
        txtQuantity.ReadOnly = True
        txtAmount.ReadOnly = True
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






    'Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
    '    'Call a method for checking low price details
    '    If CheckLowPriceDetails() = True Then
    '        If pnltxtSupplierName.Visible = False And pnltxtItemName.Visible = False Then
    '            'Both Supplier and Item are existing
    '            AddItemSuppliedDetails()
    '        ElseIf pnltxtSupplierName.Visible = False And pnltxtItemName.Visible = True Then
    '            'Item is New but Supplier is existing
    '            AddItemSuppliedAndItemDetails()
    '        ElseIf pnltxtSupplierName.Visible = True And pnltxtItemName.Visible = False Then
    '            'Supplier is New but Item is existing
    '            AddSupplierAndItemSuppliedDetails()
    '        Else
    '            'Both Supplier and Item are new
    '            AddSupplierAndItemSuppliedAndItemDetails()
    '        End If
    '    Else
    '        'Do nothing

    '    End If
    'End Sub









    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If pnltxtItemName.Visible <> True Then
            CheckLowPriceDetails()
        Else
            If pnltxtSupplierName.Visible = False And pnltxtItemName.Visible = False Then
                'Both Supplier and Item are existing
                AddItemSuppliedDetails()
            ElseIf pnltxtSupplierName.Visible = False And pnltxtItemName.Visible = True Then
                'Item is New but Supplier is existing
                AddItemSuppliedAndItemDetails()
            ElseIf pnltxtSupplierName.Visible = True And pnltxtItemName.Visible = False Then
                'Supplier is New but Item is existing
                AddSupplierAndItemSuppliedDetails()
            Else
                'Both Supplier and Item are new
                AddSupplierAndItemSuppliedAndItemDetails()
            End If
        End If
    End Sub

    'CHECK LOW PRICE FOR ITEM
    Private Sub CheckLowPriceDetails()
        storeAccess.GetLowPrice(cboItemName.Text)

        If storeAccess.strExceptionGetLowPriceDetails <> "" Then
            MessageBox.Show(storeAccess.strExceptionGetLowPriceDetails, My.Application.Info.Title, MessageBoxButtons.OK, MessageBoxIcon.Error)


            'Set strExceptionGetLowPriceDetails to nothing
            storeAccess.strExceptionGetLowPriceDetails = Nothing

        Else
            If storeAccess.objGetLowPriceDataTable.Rows.Count > 0 Then
                Dim objStringBuilder As New System.Text.StringBuilder

                Dim strItemName As String = cboItemName.Text


                objStringBuilder.AppendLine("LOWEST PRICE DETAILS ABOUT THE " & cboItemName.Text.ToUpper)
                objStringBuilder.AppendLine(String.Empty)
                objStringBuilder.AppendLine("MINIMUM PRICE: " & storeAccess.strItemMinimumValue)
                objStringBuilder.AppendLine("UPTO NOW, IT IS SUPPLIED BY: ")
                For intIndex As Integer = 0 To storeAccess.objGetLowPriceDataTable.Rows.Count - 1

                    objStringBuilder.AppendLine(intIndex + 1 & ") " & storeAccess.objGetLowPriceDataTable.Rows(intIndex).Item(1).ToString & ", " & _
                                                storeAccess.objGetLowPriceDataTable.Rows(intIndex).Item(2).ToString & ", " & _
                                                storeAccess.objGetLowPriceDataTable.Rows(intIndex).Item(0).ToString)
                    'objStringBuilder.AppendLine("    DATE OF SUPPLIED: " & storeAccess.objGetLowPriceDataTable.Rows(intIndex).Item(3).ToString)
                Next

                objStringBuilder.AppendLine(String.Empty)
                objStringBuilder.AppendLine("Do you want to continue to add the Item Supplied Information? ")

                If MessageBox.Show(objStringBuilder.ToString, "LOW PRICE DETAILS", MessageBoxButtons.YesNo, MessageBoxIcon.Information) = DialogResult.Yes Then
                    If pnltxtSupplierName.Visible = False And pnltxtItemName.Visible = False Then
                        'Both Supplier and Item are existing
                        AddItemSuppliedDetails()
                    ElseIf pnltxtSupplierName.Visible = False And pnltxtItemName.Visible = True Then
                        'Item is New but Supplier is existing
                        AddItemSuppliedAndItemDetails()
                    ElseIf pnltxtSupplierName.Visible = True And pnltxtItemName.Visible = False Then
                        'Supplier is New but Item is existing
                        AddSupplierAndItemSuppliedDetails()
                    Else
                        'Both Supplier and Item are new
                        AddSupplierAndItemSuppliedAndItemDetails()
                    End If
                Else
                    'Do nothing

                End If
            End If
        End If
    End Sub


    ''CHECK LOW PRICE FOR ITEM
    'Private Function CheckLowPriceDetails()
    '    If pnltxtItemName.Visible <> True Then
    '        storeAccess.GetLowPrice(cboItemName.Text)

    '        If storeAccess.strExceptionGetLowPriceDetails <> "" Then
    '            MessageBox.Show(storeAccess.strExceptionGetLowPriceDetails, My.Application.Info.Title, MessageBoxButtons.OK, MessageBoxIcon.Error)


    '            'Set strExceptionGetLowPriceDetails to nothing
    '            storeAccess.strExceptionGetLowPriceDetails = Nothing

    '        Else
    '            If storeAccess.objGetLowPriceDataTable.Rows.Count > 0 Then
    '                Dim objStringBuilder As New System.Text.StringBuilder

    '                'Dim strName As String = storeAccess.objGetLowPriceDataTable.Rows(0).Item(1).ToString
    '                'Dim strAddress As String = storeAccess.objGetLowPriceDataTable.Rows(0).Item(2).ToString
    '                'Dim strPhoneNumber As String = storeAccess.objGetLowPriceDataTable.Rows(0).Item(0).ToString
    '                'Dim dtpDateOfSupplied As String = storeAccess.objGetLowPriceDataTable.Rows(0).Item(3).ToString
    '                Dim strItemName As String = cboItemName.Text


    '                objStringBuilder.AppendLine("LOWEST PRICE DETAILS ABOUT THE " & cboItemName.Text.ToUpper)
    '                objStringBuilder.AppendLine(String.Empty)
    '                objStringBuilder.AppendLine("MINIMUM PRICE: " & storeAccess.strItemMinimumValue)
    '                objStringBuilder.AppendLine("UPTO NOW, IT IS SUPPLIED BY: ")
    '                For intIndex As Integer = 0 To storeAccess.objGetLowPriceDataTable.Rows.Count - 1

    '                    objStringBuilder.AppendLine(intIndex + 1 & ") " & storeAccess.objGetLowPriceDataTable.Rows(intIndex).Item(1).ToString & ", " & _
    '                                                storeAccess.objGetLowPriceDataTable.Rows(intIndex).Item(2).ToString & ", " & _
    '                                                storeAccess.objGetLowPriceDataTable.Rows(intIndex).Item(0).ToString)
    '                    'objStringBuilder.AppendLine("    DATE OF SUPPLIED: " & storeAccess.objGetLowPriceDataTable.Rows(intIndex).Item(3).ToString)
    '                Next

    '                objStringBuilder.AppendLine(String.Empty)
    '                objStringBuilder.AppendLine("Do you want to continue to add the Item Supplied Information? ")

    '                If MessageBox.Show(objStringBuilder.ToString, "LOW PRICE DETAILS", MessageBoxButtons.YesNo, MessageBoxIcon.Information) = DialogResult.Yes Then
    '                    Return True
    '                Else
    '                    Return False
    '                End If
    '            End If
    '        End If
    '    Else
    '        Return True
    '    End If
    'End Function

    'ADD ITEM SUPPLIED DETAILS ONLY



    Private Sub AddItemSuppliedDetails()
        Dim objStringBuilder1 As New System.Text.StringBuilder
        Dim objStringBuilder2 As New System.Text.StringBuilder

        'Add the question
        objStringBuilder1.AppendLine("Do you want to add the following information?")
        objStringBuilder1.AppendLine(String.Empty)
        objStringBuilder1.AppendLine("INFO ABOUT EXISTING SUPPLIER: " & cboSupplierName.Text & ", " & txtSupplierAddress.Text & ", " & txtSupplierPhoneNumber.Text)
        objStringBuilder1.AppendLine("INFO ABOUT EXISTING ITEM: " & cboItemName.Text)
        objStringBuilder1.AppendLine("DATE OF SUPPLIED : " & dtpDateOfSupplied.Text)
        objStringBuilder1.AppendLine("QUANTITY SUPPLIED : " & txtQuantity.Text)
        objStringBuilder1.AppendLine(String.Empty)
        objStringBuilder1.AppendLine("NOTE: The current quantity of item supplied will also be added to the quantity of item stored in the STORE.")

        objStringBuilder2.AppendLine("The following information has been added...!")
        objStringBuilder2.AppendLine(String.Empty)
        objStringBuilder2.AppendLine("INFO ABOUT SUPPLIER: " & cboSupplierName.Text & ", " & txtSupplierAddress.Text & ", " & txtSupplierPhoneNumber.Text)
        objStringBuilder2.AppendLine("INFO ABOUT ITEM: " & cboItemName.Text)
        objStringBuilder2.AppendLine("DATE OF SUPPLIED : " & dtpDateOfSupplied.Text)
        objStringBuilder2.AppendLine("QUANTITY SUPPLIED: " & txtQuantity.Text)
        objStringBuilder2.AppendLine("QUANTITY ADDED TO STORE : " & txtQuantity.Text)
        objStringBuilder2.AppendLine(String.Empty)
        objStringBuilder2.AppendLine("NOTE: The current quantity of item supplied is also added to the quantity of item stored in the STORE.")


        If MessageBox.Show(objStringBuilder1.ToString, My.Application.Info.Title, _
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            storeAccess.AddItemSupplied(txtSupplierPhoneNumber.Text, cboItemName.Text, dtpDateOfSupplied.Value.Date, txtRate.Text, txtQuantity.Text)

            Dim strExceptionItemSuppliedDetails As String = storeAccess.strExceptionAddItemSuppliedDetails
            If strExceptionItemSuppliedDetails <> "" Then
                MsgBox(strExceptionItemSuppliedDetails)

                'Set strExceptionAddItemSuppliedDetails to nothing
                storeAccess.strExceptionAddItemSuppliedDetails = Nothing
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

    'ADD ITEM SUPPLIED AND NEW ITEM DETAILS
    Private Sub AddItemSuppliedAndItemDetails()
        Dim objStringBuilder1 As New System.Text.StringBuilder
        Dim objStringBuilder2 As New System.Text.StringBuilder

        'Add the question
        objStringBuilder1.AppendLine("Do you want to add the following information?")
        objStringBuilder1.AppendLine(String.Empty)
        objStringBuilder1.AppendLine("INFO ABOUT EXISTING SUPPLIER : " & cboSupplierName.Text & ", " & txtSupplierAddress.Text & ", " & txtSupplierPhoneNumber.Text)
        objStringBuilder1.AppendLine("INFO ABOUT NEW ITEM : " & txtItemName.Text)
        objStringBuilder1.AppendLine("DATE OF SUPPLIED : " & dtpDateOfSupplied.Text)
        objStringBuilder1.AppendLine("QUANTITY SUPPLIED : " & txtQuantity.Text)

        objStringBuilder2.AppendLine("The following information has been added...!")
        objStringBuilder2.AppendLine(String.Empty)
        objStringBuilder2.AppendLine("INFO ABOUT EXISTING SUPPLIER : " & cboSupplierName.Text & ", " & txtSupplierAddress.Text & ", " & txtSupplierPhoneNumber.Text)
        objStringBuilder2.AppendLine("INFO ABOUT NEW ITEM : " & txtItemName.Text)
        objStringBuilder2.AppendLine("DATE OF SUPPLIED : " & dtpDateOfSupplied.Text)
        objStringBuilder2.AppendLine("QUANTITY SUPPLIED : " & txtQuantity.Text)

        If MessageBox.Show(objStringBuilder1.ToString, My.Application.Info.Title, _
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            storeAccess.AddItemSuppliedAndItem(txtSupplierPhoneNumber.Text, txtItemName.Text, dtpDateOfSupplied.Value.Date, txtRate.Text, txtQuantity.Text)

            Dim strExceptionItemSuppliedAndItemDetails As String = storeAccess.strExceptionAddItemSuppliedAndItemDetails
            If strExceptionItemSuppliedAndItemDetails <> "" Then
                MsgBox(strExceptionItemSuppliedAndItemDetails)

                'Set strExceptionAddItemSuppliedAndItemDetails to nothing
                storeAccess.strExceptionAddItemSuppliedAndItemDetails = Nothing
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

    'ADD NEW SUPPLIER AND ITEM SUPPLIED DETAILS
    Private Sub AddSupplierAndItemSuppliedDetails()
        Dim objStringBuilder1 As New System.Text.StringBuilder
        Dim objStringBuilder2 As New System.Text.StringBuilder

        'Add the question
        objStringBuilder1.AppendLine("Do you want to add the following information?")
        objStringBuilder1.AppendLine(String.Empty)
        objStringBuilder1.AppendLine("INFO ABOUT NEW SUPPLIER: " & txtSupplierName.Text & ", " & txtSupplierAddress.Text & ", " & txtSupplierPhoneNumber.Text)
        objStringBuilder1.AppendLine("INFO ABOUT EXISTING ITEM: " & cboItemName.Text)
        objStringBuilder1.AppendLine("DATE OF SUPPLIED : " & dtpDateOfSupplied.Text)
        objStringBuilder1.AppendLine("QUANTITY SUPPLIED : " & txtQuantity.Text)
        objStringBuilder1.AppendLine(String.Empty)
        objStringBuilder1.AppendLine("NOTE: The current quantity of item supplied will also be added to the quantity of item stored in the STORE.")

        objStringBuilder2.AppendLine("The following information has been added...!")
        objStringBuilder2.AppendLine(String.Empty)
        objStringBuilder2.AppendLine("INFO ABOUT SUPPLIER: " & txtSupplierName.Text & ", " & txtSupplierAddress.Text & ", " & txtSupplierPhoneNumber.Text)
        objStringBuilder2.AppendLine("INFO ABOUT ITEM: " & cboItemName.Text)
        objStringBuilder2.AppendLine("DATE OF SUPPLIED : " & dtpDateOfSupplied.Text)
        objStringBuilder2.AppendLine("QUANTITY SUPPLIED: " & txtQuantity.Text)
        objStringBuilder2.AppendLine("QUANTITY ADDED TO STORE : " & txtQuantity.Text)
        objStringBuilder2.AppendLine(String.Empty)
        objStringBuilder2.AppendLine("NOTE: The current quantity of item supplied is also added to the quantity of item stored in the STORE.")


        If MessageBox.Show(objStringBuilder1.ToString, My.Application.Info.Title, _
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            storeAccess.AddSupplierAndItemSupplied(txtSupplierName.Text, txtSupplierAddress.Text, txtSupplierPhoneNumber.Text, cboItemName.Text, dtpDateOfSupplied.Value.Date, txtRate.Text, txtQuantity.Text)
            Dim strExceptionSupplierAndItemSuppliedDetails As String = storeAccess.strExceptionAddSupplierAndItemSuppliedDetails
            If strExceptionSupplierAndItemSuppliedDetails <> "" Then
                MsgBox(strExceptionSupplierAndItemSuppliedDetails)

                'Set strExceptionAddSupplierAndItemSuppliedDetails to nothing
                storeAccess.strExceptionAddSupplierAndItemSuppliedDetails = Nothing
            Else
                MessageBox.Show(objStringBuilder2.ToString, My.Application.Info.Title, MessageBoxButtons.OK, MessageBoxIcon.Information)

                Query()
                FillDataGridView()
                GetSupplierName()
                ClearFields()

                'Set the record position to the last record..
                objCurrencyManager.Position = objCurrencyManager.Count - 1
            End If
        Else
            'Do nothing

        End If




    End Sub

    'ADD NEW SUPPLIER, ITEM SUPPLIED AND NEW ITEM DETAILS
    Private Sub AddSupplierAndItemSuppliedAndItemDetails()
        Dim objStringBuilder1 As New System.Text.StringBuilder
        Dim objStringBuilder2 As New System.Text.StringBuilder

        'Add the question
        objStringBuilder1.AppendLine("Do you want to add the following new information?")
        objStringBuilder1.AppendLine(String.Empty)
        objStringBuilder1.AppendLine("INFO ABOUT NEW SUPPLIER : " & txtSupplierName.Text & ", " & txtSupplierAddress.Text & ", " & txtSupplierPhoneNumber.Text)
        objStringBuilder1.AppendLine("INFO ABOUT NEW ITEM : " & txtItemName.Text)
        objStringBuilder1.AppendLine("DATE OF SUPPLIED : " & dtpDateOfSupplied.Text)
        objStringBuilder1.AppendLine("QUANTITY SUPPLIED : " & txtQuantity.Text)

        objStringBuilder2.AppendLine("The following information has been added...!")
        objStringBuilder2.AppendLine(String.Empty)
        objStringBuilder2.AppendLine("INFO ABOUT NEW SUPPLIER : " & txtSupplierName.Text & ", " & txtSupplierAddress.Text & ", " & txtSupplierPhoneNumber.Text)
        objStringBuilder2.AppendLine("INFO ABOUT NEW ITEM : " & txtItemName.Text)
        objStringBuilder2.AppendLine("DATE OF SUPPLIED : " & dtpDateOfSupplied.Text)
        objStringBuilder2.AppendLine("QUANTITY SUPPLIED : " & txtQuantity.Text)

        If MessageBox.Show(objStringBuilder1.ToString, My.Application.Info.Title, _
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            storeAccess.AddSupplierAndItemSuppliedAndItem(txtSupplierName.Text, txtSupplierAddress.Text, txtSupplierPhoneNumber.Text, txtItemName.Text, dtpDateOfSupplied.Text, txtRate.Text, txtQuantity.Text)
            Dim strExceptionSupplierAndItemSuppliedAndItemDetails As String = storeAccess.strExceptionAddSupplierAndItemSuppliedAndItemDetails
            If strExceptionSupplierAndItemSuppliedAndItemDetails <> "" Then
                MsgBox(strExceptionSupplierAndItemSuppliedAndItemDetails)

                'Set strExceptionAddSupplierAndItemSuppliedAndItemDetails to nothing
                storeAccess.strExceptionAddSupplierAndItemSuppliedAndItemDetails = Nothing
            Else
                MessageBox.Show(objStringBuilder2.ToString, My.Application.Info.Title, MessageBoxButtons.OK, MessageBoxIcon.Information)

                Query()
                FillDataGridView()
                GetSupplierName()
                GetItemName()
                ClearFields()

                'Set the record position to the last record..
                objCurrencyManager.Position = objCurrencyManager.Count - 1
            End If
        Else
            'Do nothing

        End If
        'Show a status
        'MainForm.sbiStatus.Text = "New Record Added Successfully."
    End Sub







    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        Dim objStringBuilder1 As New System.Text.StringBuilder
        Dim objStringBuilder2 As New System.Text.StringBuilder

        'Add the question
        objStringBuilder1.AppendLine("Do you really want to delete the information of this supplied item?")
        objStringBuilder1.AppendLine(String.Empty)
        objStringBuilder1.AppendLine("INFO ABOUT SUPPLIER : " & txtSupplierName.Text & ", " & txtSupplierAddress.Text & ", " & txtSupplierPhoneNumber.Text)
        objStringBuilder1.AppendLine("INFO ABOUT ITEM : " & txtItemName.Text)
        objStringBuilder1.AppendLine("DATE OF SUPPLIED : " & dtpDateOfSupplied.Text)
        objStringBuilder1.AppendLine("QUANTITY : " & txtQuantity.Text)

        objStringBuilder2.AppendLine("Do you also want to deduct the quantity of item store in STORE?")
        objStringBuilder2.AppendLine("INFO ABOUT ITEM : " & txtItemName.Text)
        objStringBuilder2.AppendLine("QUANTITY : " & txtQuantity.Text & " will also be deducted from the total amount stored in STORE.")

        If MessageBox.Show(objStringBuilder1.ToString, My.Application.Info.Title, _
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            Dim intDialogResult As DialogResult = MessageBox.Show(objStringBuilder2.ToString, My.Application.Info.Title, _
                               MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)
            Select Case intDialogResult
                Case DialogResult.Yes
                    DeleteItemSuppliedAndStoreData()
                Case DialogResult.No
                    DeleteItemSuppliedData()
                Case Else
                    'Do nothing

            End Select
        Else
            'Do nothing

        End If
    End Sub

    'DELETE ITEM SUPPLIED DETAILS ONLY
    Private Sub DeleteItemSuppliedData()
        Dim intPosition As Integer = objCurrencyManager.Position - 1
        If intPosition < 0 Then
            intPosition = 0
        End If

        storeAccess.DeleteItemSuppliedDataOnly(txtSupplierPhoneNumber.Text, txtItemName.Text, dtpDateOfSupplied.Value.Date)

        Dim objStringBuilder As New System.Text.StringBuilder

        'Add the question
        objStringBuilder.AppendLine("The following information has been deleted...!")
        objStringBuilder.AppendLine(String.Empty)
        objStringBuilder.AppendLine("INFO ABOUT SUPPLIER : " & txtSupplierName.Text & ", " & txtSupplierAddress.Text & ", " & txtSupplierPhoneNumber.Text)
        objStringBuilder.AppendLine("INFO ABOUT ITEM : " & txtItemName.Text)
        objStringBuilder.AppendLine("DATE OF SUPPLIED : " & dtpDateOfSupplied.Text)
        objStringBuilder.AppendLine("QUANTITY : " & txtQuantity.Text)

        Dim strExceptionDeleteItemSuppliedData As String = storeAccess.strExceptionDeleteItemSuppliedDataOnly
        If strExceptionDeleteItemSuppliedData <> "" Then
            MsgBox(strExceptionDeleteItemSuppliedData)

            'Set strExceptionDeleteItemSuppliedDataOnly to nothing
            storeAccess.strExceptionDeleteItemSuppliedDataOnly = Nothing
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

    'DELETE ITEM SUPPLIED DETAILS AND ALSO DEDUCT THE QUANTITY OF ITEM SUPPLIED FROM THE STORE
    Private Sub DeleteItemSuppliedAndStoreData()
        Dim intPosition As Integer = objCurrencyManager.Position - 1
        If intPosition < 0 Then
            intPosition = 0
        End If

        storeAccess.DeleteItemSuppliedAndStoreData(txtSupplierPhoneNumber.Text, txtItemName.Text, dtpDateOfSupplied.Value.Date, txtQuantity.Text)

        Dim objStringBuilder As New System.Text.StringBuilder

        'Add the question
        objStringBuilder.AppendLine("The following information has been deleted...!")
        objStringBuilder.AppendLine(String.Empty)
        objStringBuilder.AppendLine("INFO ABOUT SUPPLIER : " & txtSupplierName.Text & ", " & txtSupplierAddress.Text & ", " & txtSupplierPhoneNumber.Text)
        objStringBuilder.AppendLine("INFO ABOUT ITEM : " & txtItemName.Text)
        objStringBuilder.AppendLine("DATE OF SUPPLIED : " & dtpDateOfSupplied.Text)
        objStringBuilder.AppendLine("QUANTITY : " & txtQuantity.Text)
        objStringBuilder.AppendLine(String.Empty)
        objStringBuilder.AppendLine("NOTE: The quantity " & txtQuantity.Text & " has also be deducted from the total quantity stored in STORE.")



        Dim strExceptionDeleteItemSuppliedAndStoreData As String = storeAccess.strExceptionDeleteItemSuppliedAndStoreData
        If strExceptionDeleteItemSuppliedAndStoreData <> "" Then
            MsgBox(strExceptionDeleteItemSuppliedAndStoreData)

            'Set strExceptionDeleteItemSuppliedAndStoreData to nothing
            storeAccess.strExceptionDeleteItemSuppliedAndStoreData = Nothing
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






    'Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
    '    'Dim strUpdateItemSupplied As String = "UPDATE ITEM_SUPPLIED " & _
    '    '    "SET Date_of_supplied=#" & dtpDateOfSupplied.Value.Date & "#, " & _
    '    '    "Rate='" & txtRate.Text & "'," & _
    '    '    "Quantity='" & txtQuantity.Text & "'," & _
    '    '    "Amount='" & txtAmount.Text & "'" & _
    '    '    "WHERE Supplier_ph_no='" & txtQuantity.Text & "' " & _
    '    '    "AND Item_name='" & txtItemName.Text & "'"

    '    If btnUpdate.Text = "Edit" Then
    '        btnUpdate.Text = "Update"

    '        'Make sure that the some text fields readonly property is false
    '        txtRate.ReadOnly = False
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



    'SEARCH SUPPLIER NAME, LIST OF PROCEDURES
    Private Sub chkSupplierName_CheckedChanged(sender As Object, e As EventArgs) Handles chkSupplierName.CheckedChanged
        If chkSupplierName.Checked = True Then
            'Get list of item for combo box
            GetSupplierNameForSearching()

            'Make some corresponding controls visible
            cboSearchSupplierName.Visible = True
            pnlSearchSupplierAddress.Visible = True
            pnlSearchSupplierPhoneNumber.Visible = True


            'Call CheckBoxClick procedure
            CheckBoxClick()
        Else
            'Clear existing records
            storeAccess.objSupplierNameDataTableForSearching = Nothing

            'Clear databindings for Supplier controls
            txtSearchSupplierAddress.DataBindings.Clear()
            txtSearchSupplierPhoneNumber.DataBindings.Clear()

            'Make some corresponding controls hidden
            cboSearchSupplierName.Visible = False
            pnlSearchSupplierAddress.Visible = False
            pnlSearchSupplierPhoneNumber.Visible = False


            'Call CheckBoxClick procedure
            CheckBoxClick()
        End If
    End Sub

    Private Sub cboSearchSupplierName_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboSearchSupplierName.SelectedIndexChanged
        BindFieldsForSupplierForSearching()
    End Sub

    'Query to fill suppliername combobox
    Private Sub GetSupplierNameForSearching()
        'Clear existing records
        If storeAccess.objSupplierNameDataTableForSearching IsNot Nothing Then
            storeAccess.objSupplierNameDataTableForSearching.Clear()
        End If

        storeAccess.GetSupplierNameForSearchingComboBox("SELECT * FROM SUPPLIER " & _
                                               "ORDER BY Supplier_name")

        If storeAccess.strExceptionGetSupplierNameForSearching <> "" Then
            'Show error message
            MessageBox.Show(storeAccess.strExceptionGetSupplierNameForSearching, My.Application.Info.Title, MessageBoxButtons.OK, MessageBoxIcon.Error)

            'Set the variable to nothing
            storeAccess.strExceptionGetSupplierNameForSearching = Nothing
        Else
            cboSearchSupplierName.DataSource = storeAccess.objSupplierNameDataTableForSearching
            cboSearchSupplierName.DisplayMember = "Supplier_name"
        End If
    End Sub

    'BIND VALUES FOR SUPPLIER ADDRESS AND PHONE NUMBER
    Private Sub BindFieldsForSupplierForSearching()
        'Clear any previous bindings..
        txtSearchSupplierAddress.DataBindings.Clear()
        txtSearchSupplierPhoneNumber.DataBindings.Clear()

        'Binding process
        txtSearchSupplierAddress.DataBindings.Add("Text", storeAccess.objSupplierNameDataTableForSearching, "Supplier_address")
        txtSearchSupplierPhoneNumber.DataBindings.Add("Text", storeAccess.objSupplierNameDataTableForSearching, "Supplier_ph_no")
    End Sub






    Private Sub chkItemName_CheckedChanged(sender As Object, e As EventArgs) Handles chkItemName.CheckedChanged
        If chkItemName.Checked = True Then
            'Get list of item for combo box
            GetItemNameforSearching()

            'Make searchItemName combobox visible
            cboSearchItemName.Visible = True

            'Call CheckBoxClick procedure
            CheckBoxClick()

        Else
            'Set object to nothing
            storeAccess.objItemNameDataTableForSearching = Nothing

            'Make searchItemName combobox hidden
            cboSearchItemName.Visible = False

            'Call CheckBoxClick procedure
            CheckBoxClick()
        End If
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
            'Make List of Options for Date panel visible
            pnlSearchListOfOptionForDates.Visible = True

            'Make sure that Year radio button is selected
            rdbYear.Checked = True

            'Call CheckBoxClick procedure
            CheckBoxClick()
        Else
            'Make List of Options for Date panel hidden
            pnlSearchListOfOptionForDates.Visible = False

            'Make sure that the radio buttons are not selected
            rdbYear.Checked = False
            rdbNoOfDays.Checked = False
            rdbDay.Checked = False

            'Call CheckBoxClick procedure
            CheckBoxClick()
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

    'CHECKING CHECKED PROPERTY OF CHECKBOX AND RADIOBUTTON TO ENABLE OR DISABLE THE SEARCH BUTTON
    Private Sub CheckBoxClick()
        If chkDate.Checked = True Or chkItemName.Checked = True Or chkSupplierName.Checked = True Then
            btnSearch.Enabled = True
        ElseIf chkDate.Checked = False Or chkItemName.Checked = False Or chkSupplierName.Checked = False Then
            btnSearch.Enabled = False
        End If
    End Sub

    'UNSELECT THE CHECKED PROPERTY OF CHECKBOX AND RADIOBUTTON
    Private Sub CheckedPropertyFalse()
        'Make sure that Searching checklist are not selected
        chkSupplierName.Checked = False
        chkItemName.Checked = False
        chkDate.Checked = False
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        'Clear the fields
        ClearFields()
    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        'Make sure that the Data Set is nothing
        If storeAccess.objDataSetSearchRecords IsNot Nothing Then
            storeAccess.objDataSetSearchRecords.Clear()
        End If

        'IF ALL SUPPLIER NAME AND ITEMNAME AND YEAR ARE SELEDTED
        If chkSupplierName.Checked = True And chkItemName.Checked = True And rdbYear.Checked = True Then
            storeAccess.RunQueryForSearchingRecords("SELECT [Serial No], Supplier_name,Supplier_address,SUPPLIER.Supplier_ph_no, ITEM_SUPPLIED.Item_name, Date_of_supplied, Rate, Quantity,(Rate * Quantity) As Amount, Quantity_on_hand " & _
    "FROM ITEM_SUPPLIED,SUPPLIER, STORE " & _
    "WHERE ITEM_SUPPLIED.Supplier_ph_no=SUPPLIER.Supplier_ph_no " & _
    "AND ITEM_SUPPLIED.Item_name = STORE.Item_name " & _
    "AND SUPPLIER.Supplier_ph_no='" & txtSearchSupplierPhoneNumber.Text & "' " & _
     "AND ITEM_SUPPLIED.Item_name='" & cboSearchItemName.Text & "' " & _
      "AND YEAR(Date_of_supplied)=" & dtpSearchSelectAYear.Value.Year & _
    " ORDER BY [Serial No] ")

            'IF ALL SUPPLIERNAME AND ITEMNAME AND NO OF DAYS ARE SELECTED
        ElseIf chkSupplierName.Checked = True And chkItemName.Checked = True And rdbNoOfDays.Checked = True Then
            storeAccess.RunQueryForSearchingRecords("SELECT [Serial No], Supplier_name,Supplier_address,SUPPLIER.Supplier_ph_no, ITEM_SUPPLIED.Item_name, Date_of_supplied, Rate, Quantity,(Rate * Quantity) As Amount, Quantity_on_hand " & _
    "FROM ITEM_SUPPLIED,SUPPLIER, STORE " & _
    "WHERE ITEM_SUPPLIED.Supplier_ph_no=SUPPLIER.Supplier_ph_no " & _
    "AND ITEM_SUPPLIED.Item_name = STORE.Item_name " & _
    "AND SUPPLIER.Supplier_ph_no='" & txtSearchSupplierPhoneNumber.Text & "' " & _
     "AND ITEM_SUPPLIED.Item_name='" & cboSearchItemName.Text & "' " & _
    "AND Date_of_supplied BETWEEN #" & dtpSearchStartingDate.Value.Date & "# " & _
    "AND #" & dtpSearchEndingDate.Value.Date & "# " & _
    "ORDER BY [Serial No] ")

            'IF ALL SUPPLIERNAME AND ITEMNAME AND A DAY ARE SELECTED
        ElseIf chkSupplierName.Checked = True And chkItemName.Checked = True And rdbDay.Checked = True Then
            storeAccess.RunQueryForSearchingRecords("SELECT [Serial No], Supplier_name,Supplier_address,SUPPLIER.Supplier_ph_no, ITEM_SUPPLIED.Item_name, Date_of_supplied, Rate, Quantity,(Rate * Quantity) As Amount, Quantity_on_hand " & _
    "FROM ITEM_SUPPLIED,SUPPLIER, STORE " & _
    "WHERE ITEM_SUPPLIED.Supplier_ph_no=SUPPLIER.Supplier_ph_no " & _
    "AND ITEM_SUPPLIED.Item_name = STORE.Item_name " & _
    "AND SUPPLIER.Supplier_ph_no='" & txtSearchSupplierPhoneNumber.Text & "' " & _
    "AND ITEM_SUPPLIED.Item_name='" & cboSearchItemName.Text & "' " & _
    "AND Date_of_supplied=#" & dtpSearchSelectADay.Value.Date & "# " & _
    "ORDER BY [Serial No] ")

            'IF BOTH SUPPLIERNAME AND ITEMNAME IS CHECKED
        ElseIf chkSupplierName.Checked = True And chkItemName.Checked = True Then
            storeAccess.RunQueryForSearchingRecords("SELECT [Serial No], Supplier_name,Supplier_address,SUPPLIER.Supplier_ph_no, ITEM_SUPPLIED.Item_name, Date_of_supplied, Rate, Quantity,(Rate * Quantity) As Amount, Quantity_on_hand " & _
     "FROM ITEM_SUPPLIED,SUPPLIER, STORE " & _
     "WHERE ITEM_SUPPLIED.Supplier_ph_no=SUPPLIER.Supplier_ph_no " & _
     "AND ITEM_SUPPLIED.Item_name = STORE.Item_name " & _
     "AND SUPPLIER.Supplier_ph_no='" & txtSearchSupplierPhoneNumber.Text & "' " & _
      "AND ITEM_SUPPLIED.Item_name='" & cboSearchItemName.Text & "' " & _
     "ORDER BY [Serial No] ")

            'IF SUPPLIER NAME AND YEAR ARE SELECTED
        ElseIf chkSupplierName.Checked = True And rdbYear.Checked = True Then
            storeAccess.RunQueryForSearchingRecords("SELECT [Serial No], Supplier_name,Supplier_address,SUPPLIER.Supplier_ph_no, ITEM_SUPPLIED.Item_name, Date_of_supplied, Rate, Quantity,(Rate * Quantity) As Amount, Quantity_on_hand " & _
    "FROM ITEM_SUPPLIED,SUPPLIER, STORE " & _
    "WHERE ITEM_SUPPLIED.Supplier_ph_no=SUPPLIER.Supplier_ph_no " & _
    "AND ITEM_SUPPLIED.Item_name = STORE.Item_name " & _
    "AND SUPPLIER.Supplier_ph_no='" & txtSearchSupplierPhoneNumber.Text & "' " & _
    "AND YEAR(Date_of_supplied)=" & dtpSearchSelectAYear.Value.Year & _
    " ORDER BY [Serial No] ")

            'IF SUPPLIER NAME AND NO OF DAYS ARE SELECTED
        ElseIf chkSupplierName.Checked = True And rdbNoOfDays.Checked = True Then
            storeAccess.RunQueryForSearchingRecords("SELECT [Serial No], Supplier_name,Supplier_address,SUPPLIER.Supplier_ph_no, ITEM_SUPPLIED.Item_name, Date_of_supplied, Rate, Quantity,(Rate * Quantity) As Amount, Quantity_on_hand " & _
    "FROM ITEM_SUPPLIED,SUPPLIER, STORE " & _
    "WHERE ITEM_SUPPLIED.Supplier_ph_no=SUPPLIER.Supplier_ph_no " & _
    "AND ITEM_SUPPLIED.Item_name = STORE.Item_name " & _
    "AND SUPPLIER.Supplier_ph_no='" & txtSearchSupplierPhoneNumber.Text & "' " & _
    "AND Date_of_supplied BETWEEN #" & dtpSearchStartingDate.Value.Date & "# " & _
    "AND #" & dtpSearchEndingDate.Value.Date & "# " & _
      "ORDER BY Date_of_supplied ")

            'IF SUPPLIER NAME AND A DAY ARE SELECTED
        ElseIf chkSupplierName.Checked = True And rdbDay.Checked = True Then
            storeAccess.RunQueryForSearchingRecords("SELECT [Serial No], Supplier_name,Supplier_address,SUPPLIER.Supplier_ph_no, ITEM_SUPPLIED.Item_name, Date_of_supplied, Rate, Quantity,(Rate * Quantity) As Amount, Quantity_on_hand " & _
    "FROM ITEM_SUPPLIED,SUPPLIER, STORE " & _
    "WHERE ITEM_SUPPLIED.Supplier_ph_no=SUPPLIER.Supplier_ph_no " & _
    "AND ITEM_SUPPLIED.Item_name = STORE.Item_name " & _
    "AND SUPPLIER.Supplier_ph_no='" & txtSearchSupplierPhoneNumber.Text & "' " & _
    "AND Date_of_supplied=#" & dtpSearchSelectADay.Value.Date & "# " & _
    "ORDER BY Date_of_supplied ")

            'IF ITEMNAME AND YEAR ARE SELECTED
        ElseIf chkItemName.Checked = True And rdbYear.Checked = True Then
            storeAccess.RunQueryForSearchingRecords("SELECT [Serial No], Supplier_name,Supplier_address,SUPPLIER.Supplier_ph_no, ITEM_SUPPLIED.Item_name, Date_of_supplied, Rate, Quantity,(Rate * Quantity) As Amount, Quantity_on_hand " & _
    "FROM ITEM_SUPPLIED,SUPPLIER, STORE " & _
    "WHERE ITEM_SUPPLIED.Supplier_ph_no=SUPPLIER.Supplier_ph_no " & _
    "AND ITEM_SUPPLIED.Item_name = STORE.Item_name " & _
    "AND ITEM_SUPPLIED.Item_name='" & cboSearchItemName.Text & "' " & _
    "AND YEAR(Date_of_supplied)=" & dtpSearchSelectAYear.Value.Year & _
    " ORDER BY [Serial No] ")

            'IF ITEM NAME AND NO OF DAYS ARE SELECTED
        ElseIf chkItemName.Checked = True And rdbNoOfDays.Checked = True Then
            storeAccess.RunQueryForSearchingRecords("SELECT [Serial No], Supplier_name,Supplier_address,SUPPLIER.Supplier_ph_no, ITEM_SUPPLIED.Item_name, Date_of_supplied, Rate, Quantity,(Rate * Quantity) As Amount, Quantity_on_hand " & _
    "FROM ITEM_SUPPLIED,SUPPLIER, STORE " & _
    "WHERE ITEM_SUPPLIED.Supplier_ph_no=SUPPLIER.Supplier_ph_no " & _
    "AND ITEM_SUPPLIED.Item_name = STORE.Item_name " & _
    "AND ITEM_SUPPLIED.Item_name='" & cboSearchItemName.Text & "' " & _
    "AND Date_of_supplied BETWEEN #" & dtpSearchStartingDate.Value.Date & "# " & _
    "AND #" & dtpSearchEndingDate.Value.Date & "# " & _
       "ORDER BY Date_of_supplied ")

            'IF ITEM NAME AND SELECT A DAY ARE SELECTED
        ElseIf chkItemName.Checked = True And rdbDay.Checked = True Then
            storeAccess.RunQueryForSearchingRecords("SELECT [Serial No], Supplier_name,Supplier_address,SUPPLIER.Supplier_ph_no, ITEM_SUPPLIED.Item_name, Date_of_supplied, Rate, Quantity,(Rate * Quantity) As Amount, Quantity_on_hand " & _
              "FROM ITEM_SUPPLIED,SUPPLIER, STORE " & _
              "WHERE ITEM_SUPPLIED.Supplier_ph_no=SUPPLIER.Supplier_ph_no " & _
              "AND ITEM_SUPPLIED.Item_name = STORE.Item_name " & _
              "AND ITEM_SUPPLIED.Item_name='" & cboSearchItemName.Text & "' " & _
             "AND Date_of_supplied=#" & dtpSearchSelectADay.Value.Date & "# " & _
             "ORDER BY Date_of_supplied ")

            'IF ONLY SUPPLIER NAME IS CHECKED
        ElseIf chkSupplierName.Checked = True Then
            storeAccess.RunQueryForSearchingRecords("SELECT [Serial No], Supplier_name,Supplier_address,SUPPLIER.Supplier_ph_no, ITEM_SUPPLIED.Item_name, Date_of_supplied, Rate, Quantity,(Rate * Quantity) As Amount, Quantity_on_hand " & _
      "FROM ITEM_SUPPLIED,SUPPLIER, STORE " & _
      "WHERE ITEM_SUPPLIED.Supplier_ph_no=SUPPLIER.Supplier_ph_no " & _
      "AND ITEM_SUPPLIED.Item_name = STORE.Item_name " & _
      "AND SUPPLIER.Supplier_ph_no='" & txtSearchSupplierPhoneNumber.Text & "' " & _
      "ORDER BY [Serial No] ")

            'IF ONLY ITEMNAME IS CHECKED
        ElseIf chkItemName.Checked = True Then
            storeAccess.RunQueryForSearchingRecords("SELECT [Serial No], Supplier_name,Supplier_address,SUPPLIER.Supplier_ph_no, ITEM_SUPPLIED.Item_name, Date_of_supplied, Rate, Quantity,(Rate * Quantity) As Amount, Quantity_on_hand " & _
      "FROM ITEM_SUPPLIED,SUPPLIER, STORE " & _
      "WHERE ITEM_SUPPLIED.Supplier_ph_no=SUPPLIER.Supplier_ph_no " & _
      "AND ITEM_SUPPLIED.Item_name = STORE.Item_name " & _
      "AND ITEM_SUPPLIED.Item_name='" & cboSearchItemName.Text & "' " & _
      "ORDER BY [Serial No] ")

        ElseIf rdbYear.Checked = True Then
            storeAccess.RunQueryForSearchingRecords("SELECT [Serial No], Supplier_name,Supplier_address,SUPPLIER.Supplier_ph_no, ITEM_SUPPLIED.Item_name, Date_of_supplied, Rate, Quantity,(Rate * Quantity) As Amount, Quantity_on_hand " & _
    "FROM ITEM_SUPPLIED,SUPPLIER, STORE " & _
    "WHERE ITEM_SUPPLIED.Supplier_ph_no=SUPPLIER.Supplier_ph_no " & _
    "AND ITEM_SUPPLIED.Item_name = STORE.Item_name " & _
    "AND YEAR(Date_of_supplied)=" & dtpSearchSelectAYear.Value.Year & " " & _
      "ORDER BY [Serial No] ")

            'IF NO OF DAYS RADIOBUTTON IS SELECTED
        ElseIf rdbNoOfDays.Checked = True Then
            storeAccess.RunQueryForSearchingRecords("SELECT [Serial No], Supplier_name,Supplier_address,SUPPLIER.Supplier_ph_no, ITEM_SUPPLIED.Item_name, Date_of_supplied, Rate, Quantity,(Rate * Quantity) As Amount, Quantity_on_hand " & _
    "FROM ITEM_SUPPLIED,SUPPLIER, STORE " & _
    "WHERE ITEM_SUPPLIED.Supplier_ph_no=SUPPLIER.Supplier_ph_no " & _
    "AND ITEM_SUPPLIED.Item_name = STORE.Item_name " & _
    "AND Date_of_supplied BETWEEN #" & dtpSearchStartingDate.Value.Date & "# " & _
    "AND #" & dtpSearchEndingDate.Value.Date & "# " & _
       "ORDER BY Date_of_supplied ")

            'IF ONLY  A RADIOBUTTON FOR A DAY IS SELECTED
        ElseIf rdbDay.Checked = True Then
            storeAccess.RunQueryForSearchingRecords("SELECT [Serial No], Supplier_name,Supplier_address,SUPPLIER.Supplier_ph_no, ITEM_SUPPLIED.Item_name, Date_of_supplied, Rate, Quantity,(Rate * Quantity) As Amount, Quantity_on_hand " & _
     "FROM ITEM_SUPPLIED,SUPPLIER, STORE " & _
     "WHERE ITEM_SUPPLIED.Supplier_ph_no=SUPPLIER.Supplier_ph_no " & _
     "AND ITEM_SUPPLIED.Item_name = STORE.Item_name " & _
     "AND Date_of_supplied=#" & dtpSearchSelectADay.Value.Date & "# " & _
        "ORDER BY [Serial No] ")
        End If

        If storeAccess.strExceptionSearchRecords <> "" Then
            MsgBox(storeAccess.strExceptionSearchRecords)

            'Set it to nothing
            storeAccess.strExceptionSearchRecords = Nothing
        Else
            dt = storeAccess.AutoNumberedTable(storeAccess.objDataSetSearchRecords.Tables(0))
            GblAccessObject.objDataTableOfItemEntranceForm = dt

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

    Private Sub btnGetReport_Click(sender As Object, e As EventArgs) Handles btnGetReport.Click
        Using objReportForm As New ReportForm
            With objReportForm
                .strSender = "ItemEntrance"
                .ShowDialog()
            End With
        End Using
    End Sub

    Private Sub txtQuantity_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtQuantity.KeyPress
        e.Handled = Not Char.IsDigit(e.KeyChar)
    End Sub

    Private Sub txtRate_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtRate.KeyPress
        e.Handled = Not (Char.IsDigit(e.KeyChar) Or e.KeyChar = ".")
    End Sub
End Class