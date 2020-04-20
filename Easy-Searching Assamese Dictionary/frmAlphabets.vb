Public Class frmAlphabets

    Private Sub frmAlphabets_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Dim path As String = "3Barnamala.rtf"
            rtxt1.LoadFile(path, RichTextBoxStreamType.RichText)
            Me.Size = New System.Drawing.Size(900, 663)
        Catch ex As Exception
            MsgBox("Error in loading the page.", MsgBoxStyle.Critical, "Error")
            Exit Sub
        End Try
    End Sub


    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub
End Class