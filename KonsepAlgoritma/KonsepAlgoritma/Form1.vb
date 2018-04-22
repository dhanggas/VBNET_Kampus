Public Class Form1

  

    Private Sub btnHitung_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnHitung.Click
        Try
            Dim dblBunga As Double
            Dim dblPersen As Double
            Dim dblSaldo As Double
            Dim dblTotalBunga As Double

            dblSaldo = txtAwal.Text
            txtAwal.Text = Format(dblSaldo, "#,##0.00")
            For intTahun As Integer = 1 To 5
                If intTahun = 1 Then
                    dblPersen = 2
                ElseIf intTahun = 2 Then
                    dblPersen = 3
                ElseIf intTahun = 3 Then
                    dblPersen = 4
                ElseIf intTahun = 4 Then
                    dblPersen = 5
                ElseIf intTahun = 5 Then
                    dblPersen = 6
                End If

                dblTotalBunga = 0
                For intBulan As Integer = 1 To 12
                    dblBunga = (dblSaldo * dblPersen) / 100
                    dblSaldo = dblSaldo + dblBunga
                    dblTotalBunga = dblTotalBunga + dblSaldo
                Next

                If intTahun = 1 Then
                    txtBunga1.Text = Format(dblTotalBunga, "#,##0.00")
                    txtSaldo1.Text = Format(dblSaldo, "#,##0.00")
                ElseIf intTahun = 2 Then
                    txtBunga2.Text = Format(dblTotalBunga, "#,##0.00")
                    txtSaldo2.Text = Format(dblSaldo, "#,##0.00")
                ElseIf intTahun = 3 Then
                    txtBunga3.Text = Format(dblTotalBunga, "#,##0.00")
                    txtSaldo3.Text = Format(dblSaldo, "#,##0.00")
                ElseIf intTahun = 4 Then
                    txtBunga4.Text = Format(dblTotalBunga, "#,##0.00")
                    txtSaldo4.Text = Format(dblSaldo, "#,##0.00")
                ElseIf intTahun = 5 Then
                    txtBunga5.Text = Format(dblTotalBunga, "#,##0.00")
                    txtSaldo5.Text = Format(dblSaldo, "#,##0.00")

                End If

            Next


        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
End Class
