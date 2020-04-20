Imports System.Data.OleDb

Public Class frmWrongRight
    Private Sub frmWrongRight_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.Size = New System.Drawing.Size(900, 663)
        getConn()
        LoadCategory()
        'For Each lvi As ListViewItem In Me.lbWrongRight.Items
        '    lvi.UseItemStyleForSubItems = False
        '    lvi.SubItems(2).ForeColor = Color.Beige
        'Next
        lvCategory.Font = New System.Drawing.Font("Geetanjali", 20.0!, FontStyle.Bold, GraphicsUnit.Point, CType(0, Byte))
        lvWrongRight.Font = New System.Drawing.Font("Geetanjali", 22.0!, FontStyle.Regular, GraphicsUnit.Point, CType(0, Byte))
        lvDictMeaning.Font = New System.Drawing.Font("Geetanjali", 20.0!, FontStyle.Regular, GraphicsUnit.Point, CType(0, Byte))

        AllWords()
    End Sub

    Private Sub LoadCategory()
        lvCategory.Items.Clear()
        lvCategory.Items.Add("ü±ò¿÷ýÃ¿ù", 999)
        Try

            Dim myStr As String = Nothing
            myStr = "SELECT CategoryName FROM Categories ORDER BY SLNo"
            Dim objCmd As New OleDbCommand(myStr, objConn)
            Dim rs As OleDbDataReader = objCmd.ExecuteReader
            If rs.HasRows Then
                Do While rs.Read
                    Dim s As String = IIf(IsDBNull(rs("CategoryName")), "", rs("CategoryName"))
                    If s <> "" Then
                        lvCategory.Items.Add(rs("CategoryName"), IIf(IsDBNull(rs("CategoryName")), "", rs("CategoryName")), "")
                    End If
                Loop
            End If
        Catch ex As Exception
            'MsgBox(ex.Message)
            Exit Sub
        End Try
    End Sub

    Private Function LoadWrongRight(ByVal Category As String) As Boolean
        lvWrongRight.Items.Clear()
        Try
            Dim myStr As String = Nothing
            myStr = "SELECT ID, Wrong, Correct, Meaning FROM WrongCorrect WHERE WrongCorrect.Category='" & Replace(Category, "'", "''") & "' ORDER BY ID"
            Dim objCmd As New OleDbCommand(myStr, objConn)
            Dim rs As OleDbDataReader = objCmd.ExecuteReader
            If rs.HasRows Then
                Dim xItem As ListViewItem
                Do While rs.Read
                    xItem = lvWrongRight.Items.Add(rs("ID"), IIf(IsDBNull(rs("Wrong")), "", rs("Wrong")), "")
                    xItem.SubItems.Add(IIf(IsDBNull(rs("correct")), " ", rs("correct")))
                    xItem.SubItems.Add(IIf(IsDBNull(rs("meaning")), " ", rs("meaning")))
                Loop
                LoadWrongRight = True
            Else
                lvWrongRight.Items.Clear()
                LoadWrongRight = False
                Exit Function
            End If
        Catch ex As Exception
            LoadWrongRight = False
        End Try
    End Function

    Private Function AllWords() As Boolean
        lvWrongRight.Items.Clear()
        Try
            Dim myStr As String = Nothing
            myStr = "SELECT ID,Wrong, Correct, Meaning FROM WrongCorrect ORDER BY ID"
            Dim objCmd As New OleDbCommand(myStr, objConn)
            Dim rs As OleDbDataReader = objCmd.ExecuteReader
            If rs.HasRows Then
                Dim xItem As ListViewItem
                Do While rs.Read
                    Dim word As String = IIf(IsDBNull(rs("Wrong")), "", rs("Wrong"))
                    If word = "" Then Exit Do
                    xItem = lvWrongRight.Items.Add(rs("ID"), IIf(IsDBNull(rs("Wrong")), "", rs("Wrong")), "")
                    xItem.SubItems.Add(IIf(IsDBNull(rs("correct")), " ", rs("correct")))
                    'xItem.SubItems.Add(IIf(IsDBNull(rs("meaning")), " ", rs("meaning")))
                Loop
                AllWords = True
            Else
                lvWrongRight.Items.Clear()
                AllWords = False
                Exit Function
            End If
        Catch ex As Exception
            AllWords = False
        End Try
    End Function

    Private Sub lvWrongRight_DrawColumnHeader(ByVal sender As Object, ByVal e As System.Windows.Forms.DrawListViewColumnHeaderEventArgs) Handles lvWrongRight.DrawColumnHeader
        Dim strFormat As New StringFormat()
        If e.Header.TextAlign = HorizontalAlignment.Center Then
            strFormat.Alignment = StringAlignment.Center
        ElseIf e.Header.TextAlign = HorizontalAlignment.Right Then
            strFormat.Alignment = StringAlignment.Far
        End If
        e.DrawBackground()
        e.Graphics.FillRectangle(Brushes.Bisque, e.Bounds)
        Dim headerFont As New Font("Geetanjali", 20.25, FontStyle.Bold)
        e.Graphics.DrawString(e.Header.Text, headerFont, Brushes.White, e.Bounds, strFormat)
    End Sub

    Private Sub lvWrongRight_DrawItem(ByVal sender As Object, ByVal e As System.Windows.Forms.DrawListViewItemEventArgs) Handles lvWrongRight.DrawItem
        e.DrawDefault = True
    End Sub

    Private Sub lvWrongRight_DrawSubItem(ByVal sender As Object, ByVal e As System.Windows.Forms.DrawListViewSubItemEventArgs) Handles lvWrongRight.DrawSubItem
        e.DrawDefault = True
    End Sub

    Private Sub lvWrongRight_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvWrongRight.SelectedIndexChanged
        Dim xID As String = ""
        If lvWrongRight.Items.Count = 0 Then Exit Sub
        If lvWrongRight.SelectedItems.Count <> 1 Then Exit Sub
        xID = lvWrongRight.SelectedItems(0).Name
        If xID = "" Then Exit Sub
        lvDictMeaning.Items.Clear()
        Try
            Dim myStr As String = Nothing
            myStr = "SELECT ID,meaning, Hemkosh, ChandraKanta, Chalanta, Sharaighat FROM WrongCorrect WHERE ID=" & xID
            Dim objCmd As New OleDbCommand(myStr, objConn)
            Dim rs As OleDbDataReader = objCmd.ExecuteReader
            If rs.HasRows Then
                Dim xItem As ListViewItem
                Do While rs.Read
                    xItem = lvDictMeaning.Items.Add(rs("ID"), IIf(IsDBNull(rs("Hemkosh")), "", rs("Hemkosh")), "")
                    xItem.SubItems.Add(IIf(IsDBNull(rs("ChandraKanta")), " ", rs("ChandraKanta")))
                    xItem.SubItems.Add(IIf(IsDBNull(rs("Chalanta")), " ", rs("Chalanta")))
                    xItem.SubItems.Add(IIf(IsDBNull(rs("Sharaighat")), " ", rs("Sharaighat")))
                    txtMean.Text = IIf(IsDBNull(rs("meaning")), " ", rs("meaning"))
                Loop
            Else
                lvDictMeaning.Items.Clear()
                Exit Sub
            End If
        Catch ex As Exception
            'MsgBox(ex.Message)
            Exit Sub
        End Try
    End Sub

    Private Sub lvCategory_DrawColumnHeader(ByVal sender As Object, ByVal e As System.Windows.Forms.DrawListViewColumnHeaderEventArgs) Handles lvCategory.DrawColumnHeader
        Dim strFormat As New StringFormat()
        If e.Header.TextAlign = HorizontalAlignment.Center Then
            strFormat.Alignment = StringAlignment.Center
        ElseIf e.Header.TextAlign = HorizontalAlignment.Right Then
            strFormat.Alignment = StringAlignment.Far
        End If
        e.DrawBackground()
        e.Graphics.FillRectangle(Brushes.Bisque, e.Bounds)
        Dim headerFont As New Font("Geetanjali", 20.25, FontStyle.Bold)
        e.Graphics.DrawString(e.Header.Text, headerFont, Brushes.White, e.Bounds, strFormat)

    End Sub

    Private Sub lvCategory_DrawItem(ByVal sender As Object, ByVal e As System.Windows.Forms.DrawListViewItemEventArgs) Handles lvCategory.DrawItem
        e.DrawDefault = True
    End Sub

    Private Sub lvCategory_DrawSubItem(ByVal sender As Object, ByVal e As System.Windows.Forms.DrawListViewSubItemEventArgs) Handles lvCategory.DrawSubItem
        e.DrawDefault = True
    End Sub

    Private Sub lvCategory_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvCategory.SelectedIndexChanged
        Dim xCategory As String = ""
        If lvCategory.Items.Count = 0 Then Exit Sub
        If lvCategory.SelectedItems.Count <> 1 Then Exit Sub
        If lvCategory.SelectedItems(0).Index = 0 Then
            AllWords()
            Exit Sub
        End If
        xCategory = lvCategory.SelectedItems(0).Name
        If xCategory = "" Then Exit Sub
        lvWrongRight.Items.Clear()
        lvDictMeaning.Items.Clear()

        If xCategory <> "" Then
            If Not LoadWrongRight(xCategory) Then Exit Sub
        End If
        lvDictMeaning.Items.Clear()
        txtMean.Clear()
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub lvDictMeaning_DrawColumnHeader(ByVal sender As Object, ByVal e As System.Windows.Forms.DrawListViewColumnHeaderEventArgs) Handles lvDictMeaning.DrawColumnHeader
        Dim strFormat As New StringFormat()
        If e.Header.TextAlign = HorizontalAlignment.Center Then
            strFormat.Alignment = StringAlignment.Center
        ElseIf e.Header.TextAlign = HorizontalAlignment.Right Then
            strFormat.Alignment = StringAlignment.Far
        End If
        e.DrawBackground()
        e.Graphics.FillRectangle(Brushes.Bisque, e.Bounds)
        Dim headerFont As New Font("Geetanjali", 20.25, FontStyle.Bold)
        e.Graphics.DrawString(e.Header.Text, headerFont, Brushes.White, e.Bounds, strFormat)
    End Sub

    Private Sub lvDictMeaning_DrawItem(ByVal sender As Object, ByVal e As System.Windows.Forms.DrawListViewItemEventArgs) Handles lvDictMeaning.DrawItem
        e.DrawDefault = True
    End Sub

    Private Sub lvDictMeaning_DrawSubItem(ByVal sender As Object, ByVal e As System.Windows.Forms.DrawListViewSubItemEventArgs) Handles lvDictMeaning.DrawSubItem
        e.DrawDefault = True
    End Sub
End Class