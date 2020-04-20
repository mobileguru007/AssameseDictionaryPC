Public Class frmContactUs

   
    Private Sub frmContactUs_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Dim path As String = "4Contact.rtf"
            RichTextBox1.LoadFile(path, RichTextBoxStreamType.RichText)
            Me.Size = New System.Drawing.Size(900, 667)
        Catch ex As Exception
            MsgBox("Error in loading the page.", MsgBoxStyle.Critical, "Error")
            Exit Sub
        End Try
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub
End Class