Public Class Form1

    Private Sub btnLock_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLock.Click
        txtUserID.ReadOnly = True
        txtPassword.ReadOnly = True
        txtAddress.ReadOnly = True

    End Sub

    Private Sub btnUnlock_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUnlock.Click
        txtUserID.ReadOnly = False
        txtPassword.ReadOnly = False
        txtAddress.ReadOnly = False

    End Sub

    Private Sub btnEnable_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEnable.Click
        txtUserID.Enabled = True
        txtPassword.Enabled = True
        txtAddress.Enabled = True

    End Sub

    Private Sub btnDisable_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDisable.Click
        txtUserID.Enabled = False
        txtPassword.Enabled = False
        txtAddress.Enabled = False

    End Sub

    Private Sub btnFore_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFore.Click
        txtUserID.ForeColor = Color.White
        txtPassword.ForeColor = Color.White
        txtAddress.ForeColor = Color.White

    End Sub

    Private Sub btnBack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBack.Click
        txtUserID.BackColor = Color.Blue
        txtPassword.BackColor = Color.Blue
        txtAddress.BackColor = Color.Blue

    End Sub

    Private Sub btnHide_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnHide.Click
        txtUserID.Visible = False
        txtPassword.Visible = False
        txtAddress.Visible = False

    End Sub

    Private Sub btnShow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnShow.Click
        txtUserID.Visible = True
        txtPassword.Visible = True
        txtAddress.Visible = True

    End Sub

    Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click
        txtUserID.Text = ""
        txtPassword.Text = ""
        txtAddress.Text = ""

    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Close()

    End Sub
End Class
