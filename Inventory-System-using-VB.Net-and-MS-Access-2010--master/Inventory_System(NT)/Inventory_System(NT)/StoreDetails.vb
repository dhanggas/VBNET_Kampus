Imports IS_NTC_ControlLibrary

Public Class StoreDetails
    Private storeAccess As New StoreAccess
    'Private objBindingSource As BindingSource


    Private Sub StoreDetails_Load(sender As Object, e As EventArgs) Handles Me.Load
        If storeAccess.HasConnection = True Then
            Query()

            'Update the label text
            lblResults.Text = (grdStoreDetails.RowCount - 1).ToString

            'Disable the Save button
            btnSave.Enabled = False
        Else
            'Show error message
            MessageBox.Show(storeAccess.strExceptionHasConnection, My.Application.Info.Title, MessageBoxButtons.OK, MessageBoxIcon.Error)

            'Set variable to nothing
            storeAccess.strExceptionHasConnection = Nothing
        End If
    End Sub


    Private Sub Query()
        If storeAccess.objDataSetGetDetails IsNot Nothing Then
            'Clear the DataSet
            storeAccess.objDataSetGetDetails.Clear()
        End If

        storeAccess.RunQueryToGetDetails("SELECT * FROM STORE " & _
                                         "ORDER BY Item_name")

        If storeAccess.strExceptionGetDetails <> "" Then
            'Show the error message
            MessageBox.Show(storeAccess.strExceptionGetDetails, "STORE DETAILS", MessageBoxButtons.OK, MessageBoxIcon.Error)

            'Set the variable to nothing
            storeAccess.strExceptionGetDetails = Nothing
        Else
            'Set the DataView object to the DataSet object..
            ' objBindingSource = New BindingSource(storeAccess.AutoNumberedTable(storeAccess.objDataSetGetDetails.Tables(0)))
            FillDataGridView()
        End If
    End Sub


    Private Sub FillDataGridView()
        grdStoreDetails.DataSource = storeAccess.objDataSetGetDetails.Tables(0)
        'grdStoreDetails.Rows(0).Selected = True

        grdStoreDetails.Font = New Font(grdStoreDetails.DefaultCellStyle.Font.FontFamily, 10, FontStyle.Regular)

        'Declare and set the column header style
        Dim objColumnHeaderStyle As New DataGridViewCellStyle
        objColumnHeaderStyle.BackColor = Color.Silver
        objColumnHeaderStyle.ForeColor = Color.Black
        'objColumnHeaderStyle.Font = New Font(grdItemEntrance.Font, FontStyle.Bold)
        objColumnHeaderStyle.Font = New Font(grdStoreDetails.DefaultCellStyle.Font.FontFamily, 10, FontStyle.Bold)
        objColumnHeaderStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        grdStoreDetails.ColumnHeadersDefaultCellStyle = objColumnHeaderStyle

        'Declare and set the default rows style
        Dim objAlignRightCellStyle As New DataGridViewCellStyle
        objAlignRightCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        grdStoreDetails.RowsDefaultCellStyle = objAlignRightCellStyle

        'Declare and set the alternating rows style
        Dim objAlternatingCellStyle As New DataGridViewCellStyle
        objAlternatingCellStyle.BackColor = Color.WhiteSmoke
        grdStoreDetails.AlternatingRowsDefaultCellStyle = objAlternatingCellStyle

        With grdStoreDetails
            .RowHeadersVisible = True
            '.Columns(0).HeaderCell.Value = "S.N."
            '.Columns(0).Width = 45
            .Columns(0).HeaderCell.Value = "ITEM NAME"
            .Columns(1).HeaderCell.Value = "QUANTITY ON HAND"
        End With

        storeAccess.objDataAdapterGetDetails.UpdateCommand = New OleDb.OleDbCommandBuilder(storeAccess.objDataAdapterGetDetails).GetUpdateCommand
    End Sub



    Private Sub grdStoreDetails_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles grdStoreDetails.CellValueChanged
        'Enable the save button
        btnSave.Enabled = True
    End Sub



    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Try
            'Save updates to the database
            storeAccess.objDataAdapterGetDetails.Update(storeAccess.objDataSetGetDetails)

            'Load the form once again
            StoreDetails_Load(Nothing, Nothing)
        Catch ex As Exception
            'Show the messagebox
            MessageBox.Show(ex.Message)
        End Try

        'Disable the Save button
        btnSave.Enabled = False
    End Sub

    Private Sub grdStoreDetails_UserDeletedRow(sender As Object, e As DataGridViewRowEventArgs) Handles grdStoreDetails.UserDeletedRow
        btnSave.Enabled = True
    End Sub

    Private Sub btnGetReport_Click(sender As Object, e As EventArgs) Handles btnGetReport.Click
        Using objReportForm As New ReportForm
            With objReportForm
                .strSender = "StoreDetails"
                .ShowDialog()
            End With
        End Using
    End Sub
End Class
