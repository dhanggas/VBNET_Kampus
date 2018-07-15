Imports IS_NTC_ControlLibrary

Public Class BranchDetails

    Private Sub btnGetReport_Click(sender As Object, e As EventArgs) Handles btnGetReport.Click
        Using objReportForm As New ReportForm
            With objReportForm
                .strSender = "BranchDetails"
                .ShowDialog()
            End With
        End Using
    End Sub

    Private stockAccess As New StockAccess
    'Private objBindingSource As BindingSource
    'Dim isloading As Boolean = True

    Private Sub BranchDetails_Load(sender As Object, e As EventArgs) Handles Me.Load
        If stockAccess.HasConnection = True Then
            'isloading = True
            Query()

            'Update the label text
            lblResults.Text = (grdBranchDetails.RowCount - 1).ToString

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

        stockAccess.RunQueryToGetDetails("SELECT * FROM BRANCH " & _
                                         "ORDER BY Branch_location")

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
        grdBranchDetails.DataSource = stockAccess.objDataSetGetDetails.Tables(0)
        'grdStoreDetails.Rows(0).Selected = True

        grdBranchDetails.Font = New Font(grdBranchDetails.DefaultCellStyle.Font.FontFamily, 10, FontStyle.Regular)

        'Declare and set the column header style
        Dim objColumnHeaderStyle As New DataGridViewCellStyle
        objColumnHeaderStyle.BackColor = Color.Silver
        objColumnHeaderStyle.ForeColor = Color.Black
        'objColumnHeaderStyle.Font = New Font(grdItemEntrance.Font, FontStyle.Bold)
        objColumnHeaderStyle.Font = New Font(grdBranchDetails.DefaultCellStyle.Font.FontFamily, 10, FontStyle.Bold)
        objColumnHeaderStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        grdBranchDetails.ColumnHeadersDefaultCellStyle = objColumnHeaderStyle

        'Declare and set the default rows style
        Dim objAlignRightCellStyle As New DataGridViewCellStyle
        objAlignRightCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        grdBranchDetails.RowsDefaultCellStyle = objAlignRightCellStyle

        'Declare and set the alternating rows style
        Dim objAlternatingCellStyle As New DataGridViewCellStyle
        objAlternatingCellStyle.BackColor = Color.WhiteSmoke
        grdBranchDetails.AlternatingRowsDefaultCellStyle = objAlternatingCellStyle

        With grdBranchDetails
            .RowHeadersVisible = True
            '.Columns(0).HeaderCell.Value = "S.N."
            '.Columns(0).Width = 45
            .Columns(0).HeaderCell.Value = "BRANCH"
        End With

        stockAccess.objDataAdapterGetDetails.UpdateCommand = New OleDb.OleDbCommandBuilder(stockAccess.objDataAdapterGetDetails).GetUpdateCommand
    End Sub


    Private Sub grdStoreDetails_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles grdBranchDetails.CellValueChanged
        'Enable the save button
        btnSave.Enabled = True
    End Sub



    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Try
            'Save updates to the database
            stockAccess.objDataAdapterGetDetails.Update(stockAccess.objDataSetGetDetails)

            'Refresh GridView Data
            'FillDataGridView()

            'Load the form once again
            BranchDetails_Load(Nothing, Nothing)
        Catch ex As Exception
            'Show the messagebox
            MessageBox.Show(ex.Message)
        End Try

        'Disable the Save button
        btnSave.Enabled = False
    End Sub

    Private Sub grdBranchDetails_UserDeletedRow(sender As Object, e As DataGridViewRowEventArgs) Handles grdBranchDetails.UserDeletedRow
        btnSave.Enabled = True
    End Sub
End Class
