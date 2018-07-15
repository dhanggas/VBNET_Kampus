Imports IS_NTC_ControlLibrary

Public Class Settings
    Private loginAccess As New LoginAccess

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        ClearFields()
    End Sub

    Private Sub btnConfirm_Click(sender As Object, e As EventArgs) Handles btnConfirm.Click
        If loginAccess.HasConnection = True Then
            If IsAuthenticated() = True Then
                If IsNewEntryReady() = True Then
                    'MessageBox.Show("You are a good person")
                    'Clear existing records
                    If loginAccess.objDataSet IsNot Nothing Then
                        loginAccess.objDataSet.Clear()
                    End If

                    loginAccess.UpdateEntry(txtOldUsername.Text, txtNewUsername.Text, txtNewPassword.Text)


                    If loginAccess.strExceptionUpdateEntry <> "" Then
                        'Show error message
                        MessageBox.Show(loginAccess.strExceptionUpdateEntry, "SETTINGS", MessageBoxButtons.OK, MessageBoxIcon.Error)

                        'Set the variable to nothing
                        loginAccess.strExceptionUpdateEntry = Nothing
                    Else
                        MessageBox.Show("New username and password are set.", "SETTINGS", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        ClearFields()
                    End If
                End If
            End If
        End If
    End Sub


    Private Function IsAuthenticated() As Boolean
        'Clear existing records
        If loginAccess.objDataSet IsNot Nothing Then
            loginAccess.objDataSet.Clear()
        End If

        loginAccess.RunQuery("SELECT Count(Username)" & _
                                          "FROM USERS " & _
                                         "WHERE Username ='" & txtOldUsername.Text & "' " & _
                                        "AND Password ='" & txtOldPassword.Text & "'")


        If loginAccess.strExceptionRunQuery <> "" Then
            'Show error message
            MessageBox.Show(loginAccess.strExceptionRunQuery, My.Application.Info.Title, MessageBoxButtons.OK, MessageBoxIcon.Error)

            'Set variable to nothing
            loginAccess.strExceptionRunQuery = Nothing
            Return False
        ElseIf loginAccess.objDataSet.Tables(0).Rows(0).Item(0) = 1 Then
            Return True
        Else
            MessageBox.Show("Invalid user credtials", "LOGIN FAILED", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtOldUsername.Clear()
            txtOldPassword.Clear()
            txtOldUsername.Focus()
            Return False
        End If
    End Function

    Private Function IsNewEntryReady() As Boolean
        If txtNewUsername.Text = "" Or txtConfirmPassword.Text = "" Or txtNewPassword.Text = "" Then
            MessageBox.Show("New entry text boxes are blank!", My.Application.Info.Title, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        ElseIf Not String.Equals(txtConfirmPassword.Text, txtNewPassword.Text) Then
            MessageBox.Show("New passwords doesnot match!", My.Application.Info.Title, MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtNewPassword.Clear()
            txtConfirmPassword.Clear()
            txtNewPassword.Focus()
            Return False
        Else
            Return True
        End If
    End Function

    Private Sub ClearFields()
        txtOldUsername.Clear()
        txtOldPassword.Clear()
        txtNewUsername.Clear()
        txtNewPassword.Clear()
        txtConfirmPassword.Clear()
        txtOldUsername.Focus()
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub
End Class