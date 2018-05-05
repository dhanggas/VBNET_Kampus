
Public Class Form1

    Private Sub txtQty_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtQty.GotFocus
        txtQty.BackColor = Color.White
    End Sub

    Private Sub txtQty_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtQty.KeyPress
        If (e.KeyChar < Chr(48) Or e.KeyChar > Chr(57)) And e.KeyChar <> Chr(8) Then
            e.Handled = True
            MsgBox("HARUS ANGKA")
        End If

    End Sub

    Private Sub txtQty_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtQty.LostFocus
        txtQty.BackColor = Color.Gainsboro
    End Sub

    Private Sub txtKodeBrg_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtKodeBrg.GotFocus
        txtKodeBrg.BackColor = Color.White
    End Sub



    Private Sub txtKodeBrg_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtKodeBrg.KeyPress
        
        If UCase(txtKodeBrg.Text) = "A" Then
            TxtNamaBrg.Text = "PC"
            txtHargaSat.Text = "3500000"
        ElseIf UCase(txtKodeBrg.Text) = "B" Then
            TxtNamaBrg.Text = "LAPTOP"
            txtHargaSat.Text = "5000000"
        End If
        'txtHargaSat.Text = Format(CDbl(txtHargaSat.Text), "#,###.00")
        txtQty.Focus()
           



    End Sub

    Private Sub txtQty_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtQty.TextChanged
        If txtQty.Text <> "" Then
            txtTotal.Text = CDbl(txtQty.Text) * CDbl(txtHargaSat.Text)
            txtTotal.Text = Format(CDbl(txtTotal.Text), "#,###.00")
        Else
            txtTotal.Text = 0
        End If

    End Sub

    Private Sub txtKodeBrg_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtKodeBrg.LostFocus
        txtKodeBrg.BackColor = Color.Gainsboro
    End Sub

    Private Sub txtKodeBrg_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtKodeBrg.TextChanged

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.Close()

    End Sub
End Class
