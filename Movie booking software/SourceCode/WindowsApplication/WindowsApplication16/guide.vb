Public Class guide
    Public i As Integer
    Private Sub guide_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        i = 1
        PictureBox1.Image = Image.FromFile(path & "\resources\1.png")


    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        If i < 7 Then
            i = i + 1
            PictureBox1.Image = Image.FromFile(path & "\resources\" & i & ".png")
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If i > 1 Then
            i = i - 1
            PictureBox1.Image = Image.FromFile(path & "\resources\" & i & ".png")
        End If

    End Sub
End Class