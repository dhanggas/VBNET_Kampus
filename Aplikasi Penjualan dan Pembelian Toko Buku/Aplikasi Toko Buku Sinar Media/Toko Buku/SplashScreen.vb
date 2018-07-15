Public Class SplashScreen
    Dim Z As Integer
    Private Sub SplashScreen_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Timer1.Enabled = True
        Timer1.Interval = 100
    End Sub
    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Me.Opacity = Me.Opacity - 0.01
        If Me.Opacity <= 0 Then
            Me.Hide()
            FormUtama.Show()
            Timer1.Enabled = False
        End If
    End Sub
End Class