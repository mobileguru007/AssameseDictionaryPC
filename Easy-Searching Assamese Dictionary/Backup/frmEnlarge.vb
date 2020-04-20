Imports System.Data
Imports System.Data.OleDb
Imports System.IO


Public Class frmEnlarge
    Dim filename As String
    Public PicName As String
    Public bytePic As Byte() = {}
    Dim cmd As New OleDbCommand
    Dim fsImage As FileStream
    Public blob As Byte() = {}
    Public picID As String = ""
    Public flg As Integer = 0
    Public qstr As String = ""

    Private Sub frmEnlarge_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.WindowState = FormWindowState.Maximized
        Me.lblPicName.Text = PicName
        lvPicName.Items.Clear()
        If flg = 0 Then
            LoadAllPicNames()
        Else
            LoadSelectedPicNames(qstr, 0)
        End If
        lvPicName.SelectedItem = picID
        lvPicName.Focus()

    End Sub

    Private Sub frmEnlarge_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        If imgRetrieve.Image IsNot Nothing Then
            imgRetrieve.Image.Dispose()
        End If
    End Sub
    Private Function LoadSelectedPicNames(ByVal qstr As String, Optional ByVal track As Integer = 0) As Boolean
        If track = 0 Then
            lvPicName.Items.Clear()
            Try
                If qstr = "" Then
                    Exit Function
                End If
                Dim myStr As String = Nothing
                myStr = qstr '"SELECT ID, Word FROM images WHERE SearchChar='" & myval & "' ORDER BY id, SearchChar, LEN(SearchChar) ASC"
                Dim objCmd As New OleDbCommand(myStr, objConn)
                Dim rs As OleDbDataReader = objCmd.ExecuteReader
                If rs.HasRows Then
                    'Dim xItem As ListViewItem
                    Do While rs.Read
                        'xItem = lvPicName.Items.Add(rs("ID"), IIf(IsDBNull(rs("word")), "", rs("word")), "")
                        lvPicName.Items.Add(rs("PName"))

                    Loop
                End If
            Catch ex As Exception
                'MsgBox(ex.Message)
                LoadSelectedPicNames = False
                Exit Function
            End Try
        End If
        LoadSelectedPicNames = True
    End Function



    Private Sub btnSavePicture_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSavePicture.Click
        Try
            With savePicture
                .AddExtension = True

                .CheckPathExists = True
                ' The default is False.
                .CreatePrompt = False
                ' The default is True.
                .OverwritePrompt = True
                ' The default is True.
                .ValidateNames = True
                ' The default is False.
                .ShowHelp = True

                ' If the user doesn't supply an extension, and if the AddExtension property is
                ' True, use this extension. The default is "".
                .DefaultExt = "jpeg"

                ' Prompt with the current file name if you've specified it.
                ' The default is "".
                .FileName = filename

                ' The default is "".
                .Filter = _
                "Image files (*.jpeg)|*.jpeg|" & _
                "All files|*.*"
                .FilterIndex = 1

                If .ShowDialog() = Windows.Forms.DialogResult.OK Then
                    My.Computer.FileSystem.WriteAllBytes(.FileName, bytePic, False)
                End If
            End With
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, Me.Text)
            Exit Sub
        End Try
        lvPicName.Focus()
    End Sub

    Private Sub pic_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles imgRetrieve.DoubleClick
        If Me.WindowState = FormWindowState.Maximized Then
            Me.WindowState = FormWindowState.Normal
        ElseIf Me.WindowState = FormWindowState.Normal Then
            Me.WindowState = FormWindowState.Maximized
        End If
    End Sub

    Private Sub pic_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles imgRetrieve.Click
        'imgRetrieve.Image.Dispose()
        Me.Close()
    End Sub

    Private Function LoadAllPicNames() As Boolean
        Try
            Dim myStr As String = Nothing
            myStr = "SELECT ID, PName FROM  BilingImages ORDER BY ID, PName, LEN(PName) ASC"
            Dim objCmd As New OleDbCommand(myStr, objConn)
            Dim rs As OleDbDataReader = objCmd.ExecuteReader
            If rs.HasRows Then
                'Dim xItem As ListViewItem
                Do While rs.Read
                    'xItem = lvPicName.Items.Add(rs("ID"), IIf(IsDBNull(rs("word")), "", rs("word")), "")
                    lvPicName.Items.Add(rs("PName"))

                Loop
            End If
        Catch ex As Exception
            LoadAllPicNames = False
            'MsgBox(ex.Message)
            Exit Function
        End Try
        LoadAllPicNames = True
    End Function

    Protected Function getData(ByVal objCmd As OleDbCommand) As DataSet
        Dim ds As New DataSet
        Try
            objCmd.Connection = objConn
            Dim objAdpt As New OleDbDataAdapter(objCmd)
            objAdpt.Fill(ds)
        Catch ex As Exception

        End Try

        Return ds
    End Function

    'Private Sub lvPicName_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
    'Dim xID As Integer = 0
    'If lvPicName.Items.Count = 0 Then Exit Sub
    'If lvPicName.SelectedItems.Count <> 1 Then Exit Sub
    'xID = Val(lvPicName.SelectedItems(0).Name)
    'If xID = 0 Then Exit Sub
    'If Not (imgRetrieve.Image Is Nothing) Then
    '    imgRetrieve.Image.Dispose()
    '    imgRetrieve.Image = Nothing
    'End If
    'loadPicture(xID)
    'End Sub

    Private Sub loadPicture(ByVal xid As String)
        Dim dsImage = New DataSet
        Dim objCmd As New OleDbCommand("SELECT ID, Pictures, PMeaning, PName FROM BilingImages WHERE PName='" & xid & "'")
        dsImage = getData(objCmd)
        If dsImage.Tables(0).Rows.Count > 0 Then
            fsImage = New FileStream("image1.jpg", FileMode.OpenOrCreate)
            Dim dataTable As DataTable = dsImage.Tables(0)
            Try
                For i As Integer = 0 To dsImage.Tables(0).Rows.Count - 1
                    If dsImage.Tables(0).Rows(i)("PName") = xid Then
                        blob = DirectCast(dsImage.Tables(0).Rows(i)("Pictures"), Byte())
                        fsImage.Write(blob, 0, blob.Length)
                        fsImage.Close()
                        fsImage = Nothing
                        imgRetrieve.Image = Image.FromFile("image1.jpg")
                        imgRetrieve.SizeMode = PictureBoxSizeMode.StretchImage
                        imgRetrieve.Refresh()
                    End If
                    lblPicName.Text = "ছবি :" & dsImage.Tables(0).Rows(i)("PName")
                Next
            Catch ex As Exception
                MsgBox("Could not load the picture.", MsgBoxStyle.Critical, "Error")
                Exit Sub
            End Try
        Else
            MsgBox("No image found")
            Exit Sub
        End If
    End Sub

    Private Sub lvPicName_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvPicName.SelectedIndexChanged
        Dim xID As String = ""
        If lvPicName.Items.Count = 0 Then Exit Sub
        If lvPicName.SelectedItems.Count <> 1 Then Exit Sub
        xID = lvPicName.SelectedItem
        If xID = "" Then Exit Sub
        If Not (imgRetrieve.Image Is Nothing) Then
            imgRetrieve.Image.Dispose()
            imgRetrieve.Image = Nothing
        End If
        loadPicture(xID)
        picID = xID
    End Sub

    
    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        If imgRetrieve.Image IsNot Nothing Then
            imgRetrieve.Image.Dispose()
        End If
        Me.Close()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If lvPicName.Items.Count > 0 Then
            If lvPicName.SelectedIndex < lvPicName.Items.Count - 1 Then
                lvPicName.SelectedIndex = lvPicName.SelectedIndex + 1
            End If
        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        If lvPicName.Items.Count > 0 Then
            If lvPicName.SelectedIndex > 1 Then
                lvPicName.SelectedIndex = lvPicName.SelectedIndex - 1
            End If
        End If
    End Sub
End Class