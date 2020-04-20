Imports System.Data.OleDb
Imports System.IO
Public Class frmPicture
    Dim sChar As Object
    Dim btn As DataGridViewButtonColumn
    Public blob As Byte() = {}
    Dim filename As String
    Dim fsImage As FileStream
    Dim qrystr As String = ""
    Dim flg As Integer = 0
    '================
    Dim DS As DataSet
    '===============


    Private Sub frmPicture_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        If imgRetrieve.Image IsNot Nothing Then
            imgRetrieve.Image.Dispose()
        End If
    End Sub

    Private Sub frmPicture_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        getConn()
        loadConsonent(gvCons)
        loadVowel(gvVowel)
        lblPicName.Text = ""
        If Not LoadAllPicNames() Then Exit Sub
        Me.Size = New System.Drawing.Size(900, 663)

    End Sub

    Private Function LoadSelectedPicNames(ByVal myval As String, Optional ByVal track As Integer = 0) As Boolean
        qrystr = ""
        If track = 0 Then
            lvPicName.Items.Clear()
            Try
                If myval = "" Then
                    Exit Function
                End If
                Dim myStr As String = Nothing
                myStr = "SELECT ID, PName FROM BilingImages WHERE SearchBy='" & myval & "' ORDER BY ID, SearchBy, LEN(SearchBy) ASC"
                Dim objCmd As New OleDbCommand(myStr, objConn)
                Dim rs As OleDbDataReader = objCmd.ExecuteReader
                If rs.HasRows Then
                    Do While rs.Read
                        lvPicName.Items.Add(rs("PName"))
                    Loop
                End If
                qrystr = myStr
            Catch ex As Exception
                'MsgBox(ex.Message)
                MsgBox("Error in loading the data.", MsgBoxStyle.Critical, "Error")
                LoadSelectedPicNames = False
                Exit Function
            End Try
        End If
        LoadSelectedPicNames = True
        If lvPicName.Items.Count > 0 Then
            lvPicName.SelectedIndex = 0
        End If

    End Function

    Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click
        If txtWord.Text.Trim.Length = 0 Then
            Exit Sub
        End If
        txtWord.Text = ""
        lblPicName.Text = ""
        lvPicName.Items.Clear()
        If Not (imgRetrieve.Image Is Nothing) Then
            imgRetrieve.Image.Dispose()
            imgRetrieve.Image = Nothing
            txtPicMean.Text = ""
        End If
        txtWord.Focus()
        qrystr = ""
        flg = 0
        If Not LoadAllPicNames() Then Exit Sub
    End Sub

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

    Private Sub txtWord_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtWord.TextChanged
        
        If Not (imgRetrieve.Image Is Nothing) Then
            imgRetrieve.Image.Dispose()
            imgRetrieve.Image = Nothing
            txtPicMean.Text = ""
        End If
        Dim xText As String = txtWord.Text 'gvCons.CurrentCell.Value.ToString.Trim
        If xText.Trim.Length > 0 Then
            LoadSelectedPicNames(xText, 0)
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub EnlargePicture()
        Dim xID As String = ""
        If lvPicName.Items.Count = 0 Then Exit Sub
        If lvPicName.SelectedItems.Count <> 1 Then
            MsgBox("Please select an item.", MsgBoxStyle.Information, "Error")
            Exit Sub
        End If
        xID = lvPicName.SelectedItem
        If xID = "" Then
            MsgBox("Please select an item.", MsgBoxStyle.Information, "Error")
            Exit Sub
        End If
        Dim f As New frmEnlarge
        f.picID = 0
        f.picID = xID
        f.imgRetrieve.ClientSize = imgRetrieve.Image.Size ' New System.Drawing.Size(370, 285)
        f.imgRetrieve.Image = CType(imgRetrieve.Image.Clone, Image)
        f.bytePic = blob
        f.PicName = Trim(lblPicName.Text)
        If flg = 1 Then
            f.flg = 1
            f.qstr = qrystr
        Else
            f.flg = 0
        End If

        f.ShowDialog()
        xID = f.picID
        lvPicName.SelectedItem = f.picID
        lvPicName.Focus()

    End Sub

    

    Private Sub btnSavePicture_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSavePicture.Click

        Dim xID As String = ""
        If lvPicName.Items.Count = 0 Then Exit Sub
        If lvPicName.SelectedItems.Count <> 1 Then
            MsgBox("Please select a picture from the list.", MsgBoxStyle.Information, "Error")
            Exit Sub
        End If
        xID = lvPicName.SelectedItem
        If xID = "" Then
            MsgBox("Please select an Item", MsgBoxStyle.Information, "Error")
            Exit Sub
        End If
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
                    My.Computer.FileSystem.WriteAllBytes(.FileName, blob, False)
                End If
            End With
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Exclamation, Me.Text)
        End Try
    End Sub

    Private Function LoadAllPicNames() As Boolean
        Try
            Dim myStr As String = Nothing
            myStr = "SELECT ID, PName FROM  BilingImages ORDER BY ID, PName, LEN(PName) ASC"
            Dim objCmd As New OleDbCommand(myStr, objConn)
            Dim rs As OleDbDataReader = objCmd.ExecuteReader
            If rs.HasRows Then
                Do While rs.Read
                    lvPicName.Items.Add(rs("PName"))
                Loop
            End If
        Catch ex As Exception
            LoadAllPicNames = False
            'MsgBox(ex.Message)
            'MsgBox("Error in loading the data.", MsgBoxStyle.Critical, "Error")
            Exit Function
        End Try
        LoadAllPicNames = True
        If lvPicName.Items.Count > 0 Then
            lvPicName.SelectedIndex = 0
        End If
        'Try
        '    Dim cmd As New OleDbCommand("SELECT * FROM Images ORDER BY Word", objConn)
        '    Dim DA As New OleDbDataAdapter(cmd)
        '    DS = New DataSet

        '    DA.Fill(DS)

        '    Me.lvPicName.DataSource = DS.Tables(0)
        '    Me.lvPicName.DisplayMember = "Word"
        '    Me.lvPicName.ValueMember = "ID"
        'Catch ex As Exception
        '    LoadAllPicNames = False
        '    MsgBox(ex.Message)
        'MsgBox("Error in loading the data.", MsgBoxStyle.Critical, "Error")
        'End Try
        'If lvPicName.Items.Count > 0 Then
        '    lvPicName.SelectedIndex = 0
        'End If
        'LoadAllPicNames = True
    End Function

    Private Sub gvCons_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gvCons.CellContentClick
        txtPicMean.Text = ""
        txtWord.Text = ""
        lvPicName.Items.Clear()
        lvPicName.Refresh()
        'PictureBox1.Refresh()
        If Not (imgRetrieve.Image Is Nothing) Then
            imgRetrieve.Image.Dispose()
            imgRetrieve.Image = Nothing
            txtPicMean.Text = ""
        End If
        If gvCons.CurrentCell.Value <> "" Then
            Dim xText As String = gvCons.CurrentCell.Value.ToString.Trim
            If xText.Trim.Length > 0 Then
                txtWord.Text = xText
                LoadSelectedPicNames(xText, 0)
            End If
        End If
        flg = 1
    End Sub

    Private Sub gvVowel_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gvVowel.CellContentClick
        txtPicMean.Text = ""
        txtWord.Text = ""
        lvPicName.Items.Clear()
        lvPicName.Refresh()
        'PictureBox1.Refresh()
        If Not (imgRetrieve.Image Is Nothing) Then
            imgRetrieve.Image.Dispose()
            imgRetrieve.Image = Nothing
            txtPicMean.Text = ""
        End If
        If gvVowel.CurrentCell.Value <> "" Then
            Dim xText As String = gvVowel.CurrentCell.Value.ToString.Trim
            If xText.Trim.Length > 0 Then
                txtWord.Text = xText
                LoadSelectedPicNames(xText, 0)
            End If
        End If
        flg = 1
    End Sub

    Private Sub btnFullImage_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFullImage.Click
        EnlargePicture()
    End Sub

    'Private Sub lvPicName_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    Dim xID As Integer = 0
    '    If lvPicName.Items.Count = 0 Then Exit Sub
    '    If lvPicName.SelectedItems.Count <> 1 Then Exit Sub
    '    xID = Val(lvPicName.SelectedItems(0).Name)
    '    If xID = 0 Then Exit Sub
    '    If Not (imgRetrieve.Image Is Nothing) Then
    '        imgRetrieve.Image.Dispose()
    '        imgRetrieve.Image = Nothing
    '        txtPicMean.Text = ""
    '        'lblDot.Visible = False
    '        lblPicName.Text = ""
    '    End If
    '    Dim dsImage = New DataSet
    '    Dim objCmd As New OleDbCommand("SELECT ID, Image, Meaning, Word FROM [Images] WHERE [id]=" & xID)
    '    dsImage = getData(objCmd)
    '    If dsImage.Tables(0).Rows.Count > 0 Then
    '        fsImage = New FileStream("image.jpg", FileMode.OpenOrCreate)
    '        Dim dataTable As DataTable = dsImage.Tables(0)
    '        Try
    '            For i As Integer = 0 To dsImage.Tables(0).Rows.Count - 1
    '                If dsImage.Tables(0).Rows(i)("id") = xID Then
    '                    blob = DirectCast(dsImage.Tables(0).Rows(i)("image"), Byte())
    '                    fsImage.Write(blob, 0, blob.Length)
    '                    fsImage.Close()
    '                    fsImage = Nothing
    '                    imgRetrieve.Image = Image.FromFile("image.jpg")
    '                    imgRetrieve.SizeMode = PictureBoxSizeMode.StretchImage
    '                    imgRetrieve.Refresh()
    '                End If
    '                txtPicMean.Text = dsImage.Tables(0).Rows(i)("meaning")
    '                lblPicName.Text = dsImage.Tables(0).Rows(i)("word")
    '                'lblDot.Visible = True
    '            Next
    '        Catch ex As Exception
    '            MsgBox("Could not load the picture.", MsgBoxStyle.Critical, "Error")
    '            Exit Sub
    '        End Try
    '    Else
    '        MsgBox("No image found")
    '        Exit Sub
    '    End If
    'End Sub

    
    Private Sub lvPicName_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvPicName.SelectedIndexChanged
        Try
            Dim xid As String = ""
            If lvPicName.Items.Count = 0 Then Exit Sub
            If lvPicName.SelectedItems.Count = 0 Then Exit Sub
            If lvPicName.SelectedItems.Count <> 1 Then Exit Sub
            'If Me.lvPicName.SelectedIndex > -1 Then
            '    Dim arrayImage() As Byte = CType(Me.DS.Tables(0).Rows(Me.lvPicName.SelectedIndex).Item("image"), Byte())
            '    Dim name As String = CType(Me.DS.Tables(0).Rows(Me.lvPicName.SelectedIndex).Item("Word"), String)
            '    'TextBox2.Text = name
            '    Dim ms As New MemoryStream(arrayImage)
            '    With Me.imgRetrieve
            '        .Image = Image.FromStream(ms)
            '        .SizeMode = PictureBoxSizeMode.StretchImage
            '    End With
            'End If
            xid = lvPicName.SelectedItem.ToString
            If xid = "" Then Exit Sub
            'If xid = "System.Data.DataRowView" Then Exit Sub
            If Not (imgRetrieve.Image Is Nothing) Then
                imgRetrieve.Image.Dispose()
                imgRetrieve.Image = Nothing
                txtPicMean.Text = ""
                lblPicName.Text = ""
            End If
            Dim dsImage = New DataSet
            Dim objCmd As New OleDbCommand("SELECT ID, Pictures, PMeaning, PName FROM BilingImages WHERE PName='" & xid & "'")
            dsImage = getData(objCmd)
            If dsImage.Tables(0).Rows.Count > 0 Then
                fsImage = New FileStream("image.jpg", FileMode.OpenOrCreate)
                Dim dataTable As DataTable = dsImage.Tables(0)
                Try
                    For i As Integer = 0 To dsImage.Tables(0).Rows.Count - 1
                        If dsImage.Tables(0).Rows(i)("PName") = xid Then
                            blob = DirectCast(dsImage.Tables(0).Rows(i)("Pictures"), Byte())
                            fsImage.Write(blob, 0, blob.Length)
                            fsImage.Close()
                            fsImage = Nothing
                            imgRetrieve.Image = Image.FromFile("image.jpg")
                            imgRetrieve.SizeMode = PictureBoxSizeMode.StretchImage
                            imgRetrieve.Refresh()
                        End If
                        txtPicMean.Text = dsImage.Tables(0).Rows(i)("PMeaning")
                        lblPicName.Text = "ছবি : " & dsImage.Tables(0).Rows(i)("PName")

                    Next
                Catch ex As Exception
                    MsgBox("Could not load the picture.", MsgBoxStyle.Critical, "Error")
                    Exit Sub
                End Try
            Else
                MsgBox("No image found")
                Exit Sub
            End If

        Catch ex As Exception
            Exit Sub
        End Try
    End Sub
    'Private Sub ReloadImages()
    '    Try
    '        Dim cmd As New OleDbCommand("SELECT * FROM Images ORDER BY Word", objConn)
    '        Dim DA As New OleDbDataAdapter(cmd)
    '        DS = New DataSet

    '        DA.Fill(DS)

    '        Me.lvPicName.DataSource = DS.Tables(0)
    '        Me.lvPicName.DisplayMember = "Word"
    '        Me.lvPicName.ValueMember = "ID"
    '    Catch ex As Exception
    '        MsgBox(ex.Message)
    'MsgBox("Error in loading the data.", MsgBoxStyle.Critical, "Error")
    '    End Try

    'End Sub
    Private Sub imgRetrieve_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles imgRetrieve.DoubleClick
        enlargePicture()
    End Sub
   
    
    
End Class