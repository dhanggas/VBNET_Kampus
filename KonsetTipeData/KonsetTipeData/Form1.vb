Public Class Form1


    Private Sub btnByte_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnByte.Click
        Try
            Dim nilai1 As Byte
            Dim nilai2 As Byte
            Dim hasil As Byte
            nilai1 = txtNilai1.Text
            nilai2 = txtNilai2.Text
            hasil = nilai1 / nilai2
            txtNilai3.Text = hasil
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub btnSingle_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSingle.Click
        Try
            Dim nilai1 As Single
            Dim nilai2 As Single
            Dim hasil As Single
            nilai1 = txtNilai1.Text
            nilai2 = txtNilai2.Text
            hasil = nilai1 / nilai2
            txtNilai3.Text = hasil
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub btnDouble_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDouble.Click
        Try
            Dim nilai1 As Double
            Dim nilai2 As Double
            Dim hasil As Double
            nilai1 = txtNilai1.Text
            nilai2 = txtNilai2.Text
            hasil = nilai1 / nilai2
            txtNilai3.Text = hasil
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
End Class
