Public Class Form1

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim Batas As Long
        Dim Berhenti As Boolean
        Dim Total As Long
        Dim Posisi As Long

        Batas = txtBatas.Text
        Berhenti = False
        Posisi = 0
        Total = 0
        While Berhenti = False
            Posisi = Posisi + 1
            If Posisi = Batas Then
                Berhenti = True
            End If
            Total = Total + Posisi
        End While
        txtNilai.Text = Total

    End Sub
End Class
