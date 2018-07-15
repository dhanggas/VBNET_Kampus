Imports IS_NTC_ControlLibrary

Public Class CustomerDetailsStock
    Private stockAccess As New StockAccess
    'Private objBindingSource As BindingSource


    Private Sub CustomerDetailsStock_Load(sender As Object, e As EventArgs) Handles Me.Load
        If stockAccess.HasConnection = True Then
            Query()

            'Update the label text
            lblResults.Text = (grdCustomerDetails.RowCount - 1).ToString

            'Disable the Save button
            btnSave.Enabled = False
        Else
            'Show error message
            MessageBox.Show(stockAccess.strExceptionHasConnection, My.Application.Info.Title, MessageBoxButtons.OK, MessageBoxIcon.Error)

            'Set variable to nothing
            stockAccess.strExceptionHasConnection = Nothing
        End If
    End Sub


    Private Sub Query()
        If stockAccess.objDataSetGetDetails IsNot Nothing Then
            'Clear the DataSet
            stockAccess.objDataSetGetDetails.Clear()
        End If

        stockAccess.RunQueryToGetDetails("SELECT Customer_name, Customer_ph_no FROM CUSTOMER " & _
                                         "ORDER BY Customer_name")

        If stockAccess.strExceptionGetDetails <> "" Then
            'Show the error message
            MessageBox.Show(stockAccess.strExceptionGetDetails, "STORE DETAILS", MessageBoxButtons.OK, MessageBoxIcon.Error)

            'Set the variable to nothing
            stockAccess.strExceptionGetDetails = Nothing
        Else
            'Set the DataView object to the DataSet object..
            ' objBindingSource = New BindingSource(stockAccess.AutoNumberedTable(stockAccess.objDataSetGetDetails.Tables(0)))
            FillDataGridView()
        End If
    End Sub


    Private Sub FillDataGridView()
        grdCustomerDetails.DataSource = stockAccess.objDataSetGetDetails.Tables(0)
        'grdStoreDetails.Rows(0).Selected = True

        grdCustomerDetails.Font = New Font(grdCustomerDetails.DefaultCellStyle.Font.FontFamily, 10, FontStyle.Regular)

        'Declare and set the column header style
        Dim objColumnHeaderStyle As New DataGridViewCellStyle
        objColumnHeaderStyle.BackColor = Color.Silver
        objColumnHeaderStyle.ForeColor = Color.Black
        'objColumnHeaderStyle.Font = New Font(grdItemEntrance.Font, FontStyle.Bold)
        objColumnHeaderStyle.Font = New Font(grdCustomerDetails.DefaultCellStyle.Font.FontFamily, 10, FontStyle.Bold)
        objColumnHeaderStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        grdCustomerDetails.ColumnHeadersDefaultCellStyle = objColumnHeaderStyle

        'Declare and set the default rows style
        Dim objAlignRightCellStyle As New DataGridViewCellStyle
        objAlignRightCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        grdCustomerDetails.RowsDefaultCellStyle = objAlignRightCellStyle

        'Declare and set the alternating rows style
        Dim objAlternatingCellStyle As New DataGridViewCellStyle
        objAlternatingCellStyle.BackColor = Color.WhiteSmoke
        grdCustomerDetails.AlternatingRowsDefaultCellStyle = objAlternatingCellStyle

        With grdCustomerDetails
            .RowHeadersVisible = True
            '.Columns(0).HeaderCell.Value = "S.N."
            '.Columns(0).Width = 45
            .Columns(0).HeaderCell.Value = "CUSTOMER NAME"
            .Columns(1).HeaderCell.Value = "PHONE NUMBER"
        End With

        stockAccess.objDataAdapterGetDetails.UpdateCommand = New OleDb.OleDbCommandBuilder(stockAccess.objDataAdapterGetDetails).GetUpdateCommand
    End Sub


    Private Sub grdStoreDetails_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles grdCustomerDetails.CellValueChanged
        'Enable the save button
        btnSave.Enabled = True
    End Sub



    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Try
            'Save updates to the database
            stockAccess.objDataAdapterGetDetails.Update(stockAccess.objDataSetGetDetails)

            'Load the form once again
            CustomerDetailsStock_Load(Nothing, Nothing)
        Catch ex As Exception
            'Show the messagebox
            MessageBox.Show(ex.Message)
        End Try

        'Disable the Save button
        btnSave.Enabled = False
    End Sub

    Private Sub grdCustomerDetails_UserDeletedRow(sender As Object, e As DataGridViewRowEventArgs) Handles grdCustomerDetails.UserDeletedRow
        btnSave.Enabled = True
    End Sub

    Private Sub btnGetReport_Click(sender As Object, e As EventArgs) Handles btnGetReport.Click
        Using objReportForm As New ReportForm
            With objReportForm
                .strSender = "CustomerDetailsStock"
                .ShowDialog()
            End With
        End Using
    End Sub
End Class
