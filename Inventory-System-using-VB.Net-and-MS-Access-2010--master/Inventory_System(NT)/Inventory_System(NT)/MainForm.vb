Imports IS_NTC_ControlLibrary


Public Class MainForm
    Private itemEntranceForm As New ItemEntranceFormControl

    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub MainForm_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        LoginForm.Close()
    End Sub

    Private Sub SettingsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SettingsToolStripMenuItem.Click
        Settings.ShowDialog()
    End Sub

    'THE FOLLOWING EVENT HANDLER WOULD BE CONNECTED TO 7 MENU ITEMS AND IT WILL MANIPULATE THEM
    Private Sub StripMenuItemClick(sender As Object, e As EventArgs)
        If sender Is ItemEntranceToolStripMenuItem Then
            'Set the checkmark for ItemEntranceToolStripMenuItem 
            ItemEntranceToolStripMenuItem.Checked = True

            'Open first tab
            TabControl1.SelectedIndex = 0

            'Set the Checked property for other StripMenuItem to false
            ItemSalesToolStripMenuItem.Checked = False
            ItemReceivedToolStripMenuItem.Checked = False
            BranchIssuerToolStripMenuItem.Checked = False
            ExpenseIssuerToolStripMenuItem.Checked = False
            CapitalizedIssuerToolStripMenuItem.Checked = False
            SalesIssuerToolStripMenuItem.Checked = False
        ElseIf sender Is ItemSalesToolStripMenuItem Then
            'Set the checkmark for ItemSalesToolStripMenuItem 
            ItemSalesToolStripMenuItem.Checked = True

            'Open second tab
            TabControl1.SelectedIndex = 1

            'Set the Checked property for other StripMenuItem to false
            ItemEntranceToolStripMenuItem.Checked = False
            ItemReceivedToolStripMenuItem.Checked = False
            BranchIssuerToolStripMenuItem.Checked = False
            ExpenseIssuerToolStripMenuItem.Checked = False
            CapitalizedIssuerToolStripMenuItem.Checked = False
            SalesIssuerToolStripMenuItem.Checked = False

        ElseIf sender Is ItemReceivedToolStripMenuItem Then
            'Set the checkmark for  ItemReceivedToolStripMenuItem 
            ItemReceivedToolStripMenuItem.Checked = True

            'Open third tab
            TabControl1.SelectedIndex = 2

            'Set the Checked property for other StripMenuItem to false
            ItemEntranceToolStripMenuItem.Checked = False
            ItemSalesToolStripMenuItem.Checked = False
            BranchIssuerToolStripMenuItem.Checked = False
            ExpenseIssuerToolStripMenuItem.Checked = False
            CapitalizedIssuerToolStripMenuItem.Checked = False
            SalesIssuerToolStripMenuItem.Checked = False

        ElseIf sender Is BranchIssuerToolStripMenuItem Then
            'Set the checkmark for  BranchIssuerToolStripMenuItem
            BranchIssuerToolStripMenuItem.Checked = True

            'Open fourth tab
            TabControl1.SelectedIndex = 3

            'Set the Checked property for other StripMenuItem to false
            ItemEntranceToolStripMenuItem.Checked = False
            ItemSalesToolStripMenuItem.Checked = False
            ItemReceivedToolStripMenuItem.Checked = False
            ExpenseIssuerToolStripMenuItem.Checked = False
            CapitalizedIssuerToolStripMenuItem.Checked = False
            SalesIssuerToolStripMenuItem.Checked = False
        ElseIf sender Is CapitalizedIssuerToolStripMenuItem Then
            'Set the checkmark for  CapitalizedIssuerToolStripMenuItem
            CapitalizedIssuerToolStripMenuItem.Checked = True

            'Open fifth tab
            TabControl1.SelectedIndex = 4

            'Set the Checked property for other StripMenuItem to false
            ItemEntranceToolStripMenuItem.Checked = False
            ItemSalesToolStripMenuItem.Checked = False
            ItemReceivedToolStripMenuItem.Checked = False
            BranchIssuerToolStripMenuItem.Checked = False
            ExpenseIssuerToolStripMenuItem.Checked = False
            SalesIssuerToolStripMenuItem.Checked = False
        ElseIf sender Is ExpenseIssuerToolStripMenuItem Then
            'Set the checkmark for  ExpenseIssuerToolStripMenuItem
            ExpenseIssuerToolStripMenuItem.Checked = True

            'Open sixth tab
            TabControl1.SelectedIndex = 5

            'Set the Checked property for other StripMenuItem to false
            ItemEntranceToolStripMenuItem.Checked = False
            ItemSalesToolStripMenuItem.Checked = False
            ItemReceivedToolStripMenuItem.Checked = False
            BranchIssuerToolStripMenuItem.Checked = False
            CapitalizedIssuerToolStripMenuItem.Checked = False
            SalesIssuerToolStripMenuItem.Checked = False
        Else
            'Set the checkmark for  SalesIssuerToolStripMenuItem
            SalesIssuerToolStripMenuItem.Checked = True

            'Open seventh tab
            TabControl1.SelectedIndex = 6

            'Set the Checked property for other StripMenuItem to false
            ItemEntranceToolStripMenuItem.Checked = False
            ItemSalesToolStripMenuItem.Checked = False
            ItemReceivedToolStripMenuItem.Checked = False
            BranchIssuerToolStripMenuItem.Checked = False
            CapitalizedIssuerToolStripMenuItem.Checked = False
            ExpenseIssuerToolStripMenuItem.Checked = False
        End If
    End Sub

    Private Sub ItemEntranceToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ItemEntranceToolStripMenuItem.Click
        'Call StripMenuItemClick procedure
        StripMenuItemClick(sender, e)
    End Sub

    Private Sub ItemSalesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ItemSalesToolStripMenuItem.Click
        'Call StripMenuItemClick procedure
        StripMenuItemClick(sender, e)
    End Sub

    Private Sub ItemReceivedToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ItemReceivedToolStripMenuItem.Click
        'Call StripMenuItemClick procedure
        StripMenuItemClick(sender, e)
    End Sub

    Private Sub BranchIssuerToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BranchIssuerToolStripMenuItem.Click
        'Call StripMenuItemClick procedure
        StripMenuItemClick(sender, e)
    End Sub

    Private Sub CapitalizedIssuerToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CapitalizedIssuerToolStripMenuItem.Click
        'Call StripMenuItemClick procedure
        StripMenuItemClick(sender, e)
    End Sub

    Private Sub ExpenseIssuerToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExpenseIssuerToolStripMenuItem.Click
        'Call StripMenuItemClick procedure
        StripMenuItemClick(sender, e)
    End Sub

    Private Sub SalesIssuerToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SalesIssuerToolStripMenuItem.Click
        'Call StripMenuItemClick procedure
        StripMenuItemClick(sender, e)
    End Sub

    Private Sub AboutSoftwareToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AboutSoftwareToolStripMenuItem.Click
        Using objAboutSoftware As New AboutSoftware
            objAboutSoftware.ShowDialog()
        End Using
    End Sub





    'CHECK AND CHANGE THE REQUIRED CHECKED PROPERTY OF STRIPMENUITEM

    'IF ITEMENTRANCEFORM PAGE IS ENTERED
    Private Sub TabPage1_Enter(sender As Object, e As EventArgs) Handles TabPage1.Enter
        'Set the checkmark for ItemEntranceToolStripMenuItem 
        ItemEntranceToolStripMenuItem.Checked = True

        'Open first tab
        TabControl1.SelectedIndex = 0

        'Set the Checked property for other StripMenuItem to false
        ItemSalesToolStripMenuItem.Checked = False
        ItemReceivedToolStripMenuItem.Checked = False
        BranchIssuerToolStripMenuItem.Checked = False
        ExpenseIssuerToolStripMenuItem.Checked = False
        CapitalizedIssuerToolStripMenuItem.Checked = False
        SalesIssuerToolStripMenuItem.Checked = False
    End Sub

    'IF ITEMSALESFORM PAGE IS ENTERED
    Private Sub TabPage2_Enter(sender As Object, e As EventArgs) Handles TabPage2.Enter
      ItemSalesToolStripMenuItem.Checked = True

        'Open second tab
        TabControl1.SelectedIndex = 1

        'Set the Checked property for other StripMenuItem to false
        ItemEntranceToolStripMenuItem.Checked = False
        ItemReceivedToolStripMenuItem.Checked = False
        BranchIssuerToolStripMenuItem.Checked = False
        ExpenseIssuerToolStripMenuItem.Checked = False
        CapitalizedIssuerToolStripMenuItem.Checked = False
        SalesIssuerToolStripMenuItem.Checked = False
    End Sub

    'IF ITEMRECEIVEDFORM PAGE IS ENTERED
    Private Sub TabPage3_Enter(sender As Object, e As EventArgs) Handles TabPage3.Enter
        'Set the checkmark for  ItemReceivedToolStripMenuItem 
        ItemReceivedToolStripMenuItem.Checked = True

        'Open third tab
        TabControl1.SelectedIndex = 2

        'Set the Checked property for other StripMenuItem to false
        ItemEntranceToolStripMenuItem.Checked = False
        ItemSalesToolStripMenuItem.Checked = False
        BranchIssuerToolStripMenuItem.Checked = False
        ExpenseIssuerToolStripMenuItem.Checked = False
        CapitalizedIssuerToolStripMenuItem.Checked = False
        SalesIssuerToolStripMenuItem.Checked = False
    End Sub

    'IF BRANCHISSUERFORM PAGE IS ENTERED
    Private Sub TabPage4_Enter(sender As Object, e As EventArgs) Handles TabPage4.Enter
        'Set the checkmark for  BranchIssuerToolStripMenuItem
        BranchIssuerToolStripMenuItem.Checked = True

        'Open fourth tab
        TabControl1.SelectedIndex = 3

        'Set the Checked property for other StripMenuItem to false
        ItemEntranceToolStripMenuItem.Checked = False
        ItemSalesToolStripMenuItem.Checked = False
        ItemReceivedToolStripMenuItem.Checked = False
        ExpenseIssuerToolStripMenuItem.Checked = False
        CapitalizedIssuerToolStripMenuItem.Checked = False
        SalesIssuerToolStripMenuItem.Checked = False
    End Sub

    'IF CAPITALIZEDISSUERFORM PAGE IS ENTERED
    Private Sub TabPage5_Enter(sender As Object, e As EventArgs) Handles TabPage5.Enter
        'Set the checkmark for  CapitalizedIssuerToolStripMenuItem
        CapitalizedIssuerToolStripMenuItem.Checked = True

        'Open fifth tab
        TabControl1.SelectedIndex = 4

        'Set the Checked property for other StripMenuItem to false
        ItemEntranceToolStripMenuItem.Checked = False
        ItemSalesToolStripMenuItem.Checked = False
        ItemReceivedToolStripMenuItem.Checked = False
        BranchIssuerToolStripMenuItem.Checked = False
        ExpenseIssuerToolStripMenuItem.Checked = False
        SalesIssuerToolStripMenuItem.Checked = False

    End Sub

    'IF EXPENSEISSUERFORM PAGE IS ENTERED
    Private Sub TabPage6_Enter(sender As Object, e As EventArgs) Handles TabPage6.Enter
        'Set the checkmark for  ExpenseIssuerToolStripMenuItem
        ExpenseIssuerToolStripMenuItem.Checked = True

        'Open sixth tab
        TabControl1.SelectedIndex = 5

        'Set the Checked property for other StripMenuItem to false
        ItemEntranceToolStripMenuItem.Checked = False
        ItemSalesToolStripMenuItem.Checked = False
        ItemReceivedToolStripMenuItem.Checked = False
        BranchIssuerToolStripMenuItem.Checked = False
        CapitalizedIssuerToolStripMenuItem.Checked = False
        SalesIssuerToolStripMenuItem.Checked = False

    End Sub

    'IF SALESISSUERFORM PAGE IS ENTERED
    Private Sub TabPage7_Enter(sender As Object, e As EventArgs) Handles TabPage7.Enter

        'Set the checkmark for  SalesIssuerToolStripMenuItem
        SalesIssuerToolStripMenuItem.Checked = True

        'Open seventh tab
        TabControl1.SelectedIndex = 6

        'Set the Checked property for other StripMenuItem to false
        ItemEntranceToolStripMenuItem.Checked = False
        ItemSalesToolStripMenuItem.Checked = False
        ItemReceivedToolStripMenuItem.Checked = False
        BranchIssuerToolStripMenuItem.Checked = False
        CapitalizedIssuerToolStripMenuItem.Checked = False
        ExpenseIssuerToolStripMenuItem.Checked = False

    End Sub

    Private Sub ViewQuantityOnStoreDetailsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ViewQuantityOnStoreDetailsToolStripMenuItem.Click
        StoreDetails.ShowDialog(Me)
    End Sub

    Private Sub CustomerDetailsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ViewCustomerDetailsToolStripMenuItem.Click
        CustomerDetails.ShowDialog(Me)
    End Sub

    Private Sub SupplierDetailsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ViewSupplierDetailsToolStripMenuItem.Click
        
        SupplierDetails.ShowDialog(Me)
    End Sub

    Private Sub ViewRecordsToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ViewRecordsToolStripMenuItem1.Click
        StockDetails.ShowDialog(Me)
    End Sub

    Private Sub BranchDetailsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BranchDetailsToolStripMenuItem.Click
        BranchDetails.ShowDialog(Me)
    End Sub

    Private Sub CustomerDetailsToolStripMenuItem_Click_1(sender As Object, e As EventArgs) Handles CustomerDetailsToolStripMenuItem.Click
        CustomerDetailsStock.ShowDialog(Me)
    End Sub

    Private Sub AboutDeveloperToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AboutDeveloperToolStripMenuItem.Click
        Using objAboutDeveloper As New AboutDeveloper
            objAboutDeveloper.ShowDialog(Me)
        End Using
    End Sub

    Private Sub MainForm_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If MessageBox.Show("Are you sure to close the windows?", "Inventory System", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            e.Cancel = False
        Else
            e.Cancel = True
        End If
    End Sub

    Private Sub MainForm_Load(sender As Object, e As EventArgs) Handles Me.Load
        'Me.MaximumSize = New Size(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height)
    End Sub

   
End Class