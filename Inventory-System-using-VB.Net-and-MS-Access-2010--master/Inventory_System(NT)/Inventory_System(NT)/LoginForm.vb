Imports IS_NTC_ControlLibrary

Public Class LoginForm


    ' TODO: Insert code to perform custom authentication using the provided username and password 
    ' (See http://go.microsoft.com/fwlink/?LinkId=35339).  
    ' The custom principal can then be attached to the current thread's principal as follows: 
    '     My.User.CurrentPrincipal = CustomPrincipal
    ' where CustomPrincipal is the IPrincipal implementation used to perform authentication. 
    ' Subsequently, My.User will return identity information encapsulated in the CustomPrincipal object
    ' such as the username, display name, etc.

    Private loginAccess As New LoginAccess
    Private strAuthenticatedUser As String
    Dim textStyle As New TextStyle

    Private Sub OK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLogin.Click
        If loginAccess.HasConnection = True Then
            If IsAuthenticated() = True Then
                strAuthenticatedUser = txtUsername.Text
                MessageBox.Show("Login Successful, Welcome " & strAuthenticatedUser & "!", My.Application.Info.Title)
                Me.Hide()
                MainForm.Show()
            End If
        End If
    End Sub

    Private Sub Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub LoginForm_Load(sender As Object, e As EventArgs) Handles Me.Load
        'Call GetTime method
        'Timer1.Enabled = True
        'GetDate()
    End Sub

    'Private Sub GetDate()
    '    lblDate.Text = Now.ToLongDateString
    'End Sub

    'Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
    '    lblTime.Text = Now.Day.ToString & " " & Now.ToLongTimeString
    'End Sub

    Private Function IsAuthenticated() As Boolean
        'Clear existing records
        If loginAccess.objDataSet IsNot Nothing Then
            loginAccess.objDataSet.Clear()
        End If

        loginAccess.RunQuery("SELECT Count(Username)" & _
                            "FROM USERS " & _
                           "WHERE Username ='" & txtUsername.Text & "' " & _
                          "AND Password ='" & txtPassword.Text & "'")

        'loginAccess.RunQuery("SELECT Username, Password FROM USERS")
        'If String.Compare(loginAccess.objDataSet.Tables("login").Rows(0).Item(0), txtUsername.Text, False) = 0 & _
        'String.Compare(loginAccess.objDataSet.Tables("login").Rows(0).Item(1), txtPassword.Text, False) = 0 Then
        '    Return True
        'Else

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
            txtUsername.Clear()
            txtPassword.Clear()
            txtUsername.Focus()
            Return False
        End If
    End Function
End Class
