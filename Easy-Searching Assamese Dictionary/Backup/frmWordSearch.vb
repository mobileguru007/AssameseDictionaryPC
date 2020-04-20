Imports System.Data.OleDb
Imports System.Windows.Forms.DataGrid
Imports System.IO
Imports System.Security.Cryptography
Imports System.Text


Public Class frmWordSearch
    Dim sChar As Object
    Dim btn As DataGridViewButtonColumn
    Dim curWord As String
    Dim myStrings() As String
    Dim myStringElements As Integer = 0
    Dim i As Integer = 0
    Dim xd As Integer = 2
    'Public blob As Byte() = {}
    'Dim filename As String
    'Dim fsImage As FileStream
    Dim selecteUNicodeWord As String = ""
    Dim SelecteEngWord As String = ""
    Dim isLinkedWord As Boolean = False
    'Dim myList As New List(Of String)()
    Dim storeWord As ArrayList = New ArrayList
    Dim storedPrevWord As ArrayList = New ArrayList
    Dim wordSelect As Integer = 0   ' 0 for meaing box, 1 for back button
    Dim prevButtonClick As Integer = 0 ' 0 means clicked the prevbutton.
    Dim lastSelectIndex As Integer = 0
    Dim prevSelectIndex As Integer = 0
    Dim isLastIndex As Boolean = False
    Dim isLastPreviosIndex As Boolean = False




    'Private Sub rbtnAssamese_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtnAssamese.CheckedChanged
    '    lvWords.Items.Clear()
    '    txtAMean.Text = ""
    '    lblProbableWords.Visible = True
    '    Me.lvWords.Size = New System.Drawing.Size(204, 322)
    '    If rbtnAssamese.Checked = True Then
    '        isLinkedWord = False
    '        lvWords.Font = New System.Drawing.Font("Asomiya_Rohini", 16.25!, FontStyle.Regular, GraphicsUnit.Point, CType(0, Byte))
    '        lvProbableWord.Font = New System.Drawing.Font("Asomiya_Rohini", 16.25!, FontStyle.Regular, GraphicsUnit.Point, CType(0, Byte))

    '        txtWord.Text = ""
    '        txtWord.Font = New System.Drawing.Font("Asomiya_Rohini", 14.25!, FontStyle.Regular, GraphicsUnit.Point, CType(0, Byte))
    '        txtWord.Focus()
    '        lvWords.Visible = True
    '        lvProbableWord.Visible = True
    '        txtAMean.Font = New System.Drawing.Font("Asomiya_Rohini", 16.0!, FontStyle.Regular, GraphicsUnit.Point, CType(0, Byte))

    '    Else
    '        'If isLinkedWord = False Then
    '        '    txtWord.Text = ""

    '        'End If
    '        txtWord.Text = ""
    '        txtWord.Font = New System.Drawing.Font("Times New Roman", 17.0!, FontStyle.Regular, GraphicsUnit.Point, CType(0, Byte))
    '        txtWord.ReadOnly = False
    '        txtWord.Focus()
    '        lvProbableWord.Visible = False
    '    End If
    'End Sub

    'Function ShowEngWords(ByVal myval As String, Optional ByVal track As Integer = 0) As Boolean
    '    Dim xMyval As String = ""
    '    If track = 0 Then
    '        Try
    '            xMyval = " left(EngWord_Ch, " & Len(myval) & ")= '" & myval.Substring(0, myval.Length) & "'"
    '            lvWords.Items.Clear()
    '            If myval = "" Then
    '                Exit Function
    '            End If
    '            myval = xMyval
    '            Dim myStr As String = Nothing
    '            myStr = "SELECT TOP 20 ID, EngWord FROM EnglishWords WHERE " & myval & " ORDER BY ID, EngWord, LEN(EngWord) ASC"
    '            Dim objCmd As New OleDbCommand(myStr, objConn)
    '            Dim rs As OleDbDataReader = objCmd.ExecuteReader
    '            If rs.HasRows Then
    '                Dim xItem As ListViewItem
    '                Do While rs.Read
    '                    Dim xWord As String = IIf(IsDBNull(rs("EngWord")), "", rs("EngWord"))
    '                    Dim xdecrypt As String = Decrypt(xWord, strEncodeString)
    '                    xItem = lvWords.Items.Add(rs("ID"), xdecrypt, "")
    '                Loop
    '            End If
    '        Catch ex As Exception
    '            'MsgBox(ex.Message)
    '            'MsgBox("Error in loading the data.", MsgBoxStyle.Critical, "Error")
    '            Return False
    '        End Try
    '    End If
    '    Return True
    'End Function

    'Private Sub frmWordSearch_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    '    'Dim dtTabel As DataTable = New DataTable
    '    'Dim cmd1 As New OleDbCommand("SELECT * FROM MainTable", objConn)
    '    'Dim rs1 As OleDbDataReader = cmd1.ExecuteReader
    '    'If rs1.HasRows Then
    '    '    dtTabel.Load(rs1)

    '    'End If


    '    'MsgBox(Application.StartupPath.ToString, MsgBoxStyle.OkOnly, "Application Directory is")
    '    lvProbableWord.Visible = True
    '    getConn()
    '    txtWord.Focus()
    '    Me.Size = New System.Drawing.Size(900, 663)


    '    Try
    '        If IsRegistered = False Then
    '            GroupBox4.Enabled = False
    '            Dim count As Integer = 0
    '            Dim cmd As New OleDbCommand("SELECT COUNT(MyWord) AS Total FROM MainTable", objConn)
    '            Dim rs As OleDbDataReader = cmd.ExecuteReader
    '            If rs.HasRows Then
    '                rs.Read()
    '                count = IIf(IsDBNull(rs("Total")), 0, rs("Total"))
    '            End If
    '            If count > 4000 Then
    '                GroupBox4.Enabled = False
    '                lvWords.Enabled = False
    '            End If
    '        End If
    '    Catch ex As Exception
    '        Exit Sub
    '    End Try

    'End Sub

    'Protected Sub composeQueryStr(ByVal inputTxt As String, ByVal cmdTxt As String)
    '    If txtWord.Text.Trim.Length > 100 Then Exit Sub
    '    If rbtnAssamese.Checked = False Then
    '        MsgBox("Please select the Assamese option.", MsgBoxStyle.Critical)
    '        txtWord.Focus()
    '        Exit Sub
    '    End If
    '    If inputTxt.Length > 0 Then
    '        txtWord.Text = inputTxt & cmdTxt
    '    Else
    '        txtWord.Text = cmdTxt
    '    End If
    'End Sub

    'Function ShowWords(ByRef Mybox As ListView, ByVal myval As String, Optional ByVal track As Integer = 0) As Boolean
    '    'Dim FirstID As Integer = 0

    '    Dim xMyval As String = ""
    '    If track = 0 Then
    '        Try

    '            xMyval = " left(MyWord_Ch, " & Len(myval) & ")= '" & myval.Substring(0, myval.Length) & "'"
    '            txtAMean.Clear()
    '            If myval = "" Then
    '                Exit Function
    '            End If
    '            myval = xMyval
    '            Dim myStr As String = Nothing
    '            myStr = "SELECT TOP 12 ID, MyWord FROM MainTable WHERE " & myval & " ORDER BY ID, MyWOrd , LEN(MyWord) ASC"
    '            Dim objCmd As New OleDbCommand(myStr, objConn)
    '            Dim rs As OleDbDataReader = objCmd.ExecuteReader
    '            If rs.HasRows Then
    '                Dim xItem As ListViewItem
    '                Do While rs.Read
    '                    'If FirstID = 0 Then
    '                    '    FirstID = IIf(IsDBNull(rs("ID")), 0, rs("ID"))
    '                    'End If
    '                    Dim myword As String = IIf(IsDBNull(rs("MyWord")), "", rs("MyWord"))
    '                    Dim decodedtext As String = Decrypt(myword, strEncodeString)
    '                    xItem = Mybox.Items.Add(rs("ID"), decodedtext, "")
    '                Loop
    '            Else
    '                ShowWords = False
    '                Exit Function
    '            End If
    '        Catch ex As Exception
    '            'MsgBox(ex.Message)
    '            'MsgBox("Error in loading the data.", MsgBoxStyle.Critical, "Error")
    '            ShowWords = False
    '            Exit Function
    '        End Try
    '    ElseIf track = True Then
    '        ShowWords = track
    '        Exit Function
    '    End If
    '    ShowWords = True
    'End Function


    'Private Sub rbtnEnglish_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtnEnglish.CheckedChanged
    '    If rbtnEnglish.Checked = True Then
    '        lvWords.Items.Clear()
    '        Me.lvWords.Size = New System.Drawing.Size(204, 559)
    '        lblProbableWords.Visible = False
    '        lblDictword.Text = ""
    '        txtWord.Font = New System.Drawing.Font("Times New Roman", 16.3!, FontStyle.Regular, GraphicsUnit.Point, CType(0, Byte))
    '        lvWords.Font = New System.Drawing.Font("Times New Roman", 17.0!, FontStyle.Regular, GraphicsUnit.Point, CType(0, Byte))
    '        If txtWord.Text = "" Then Exit Sub
    '        If Not ShowEngWords(Trim(txtWord.Text), 0) Then
    '            Exit Sub
    '        End If
    '    Else
    '        'Me.lvWords.Size = New System.Drawing.Size(487, 150)
    '        'Me.lvWords.Columns(0).Width = 250
    '    End If
    'End Sub

    'Private Sub Command5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    If txtWord.Text = "" Then Exit Sub
    '    composeQueryStr(txtWord.Text, " ")
    'End Sub

    'Private Sub PossibleWord(ByVal sword As String)
    '    Dim mword As String
    '    Dim xword As Object
    '    Dim yword As Object
    '    Dim a As Integer
    '    Dim b As Integer = 0

    '    sword = eachCharDecrept(sword, strEncodeString)

    '    xword = New String() {"তত্ব", "ক", "কঁ", "উ", "ও", "ই", "অঁ", "অ", "অ", "আ", "আঁ", "ঈ", "নি", "নিঃস", "নী", "ত্র", "ট্র", "-", " ", "ছ", "চ", "চ্ছ্ব", "জ্ব", "জ্জ্ব", "জ", "ঞ্ছ", "ঞ্চ", "ত", "ট", "ত্ত", "ত্ত্ব", "ত্ব", "থ", "ঠ", "দ", "ড", "দ্দ", "ড্ড", "দ্র", "ড্র", "ধ", "ঢ", "ণ", "ন", "ন্ত", "ণ্ট", "ণ্ণ", "ন্ন", "পঁ", "প", "ফঁ", "ফ", "প্ত", "প্ট", "ম্ম", "ন্ম", "জ", "য", "ৰূ", "ৰু", "ৱ", "ব", "স", "শ", "শ্চ", "শ্ছ", "ওত", "ণু", "দু", "দুঃখ", "দুঃস্ব", "খূ", "খু", "ঘূ", "ঘু", "ছু", "পঁ", "প", "ফ", "ফঁ"}
    '    yword = New String() {"তত্ত্ব", "কঁ", "ক", "ও", "উ", "ঈ", "অ", "অঁ", "অ’", "আঁ", "আ", "ই", "নিঃ", "নিস", "নি", "ট্র", "ত্র", " ", "-", "চ", "ছ", "চ্ছ", "জ", "জ্ব", "ঝ", "ঞ্চ", "ঞ্ছ", "ট", "ত", "ট্ট", "ত্ব", "ত্ত্ব", "ঠ", "থ", "ড", "দ", "ড্ড", "দ্দ", "ড্র", "দ্র", "ঢ", "ধ", "ন", "ণ", "ণ্ট", "ন্ত", "ন্ন", "ণ্ণ", "প", "পঁ", "ফ", "ফঁ", "প্ট", "প্ত", "ন্ম", "ম্ম", "য", "জ", "ৰু", "ৰূ", "ব", "ৱ", "শ", "স", "শ্ছ", "শ্চ", "ওতঃ", "নু", "দুঃ", "দুখ", "দুস্ব", "খু", "খূ", "ঘু", "ঘূ", "চু", "প", "পঁ", "ফ", "ফঁ"}

    '    mword = ""
    '    For a = 0 To UBound(xword)
    '        b = InStr(1, sword, xword(a))
    '        If b > 0 Then
    '            mword = Replace(sword, xword(a), yword(a))
    '            Exit For
    '        End If
    '    Next
    '    If mword <> "" Then
    '        Dim xCharacterEncrypted As String = EachCharacterEncrypt(mword, strEncodeString)
    '        'For i As Integer = 0 To mword.Length - 1
    '        '    Dim eccodedText As String = mword.Substring(i, 1)
    '        '    If eccodedText <> "" Then
    '        '        xCharacterEncrypted = xCharacterEncrypted & Encrypt(eccodedText, strEncodeString)
    '        '    End If
    '        'Next
    '        ShowWords(lvProbableWord, Replace(xCharacterEncrypted, "'", "39"), 0)


    '        ' ShowWords(lvProbableWord, Replace(mword, "'", "39"), 0)
    '    Else
    '        lvProbableWord.Items.Clear()
    '    End If
    'End Sub

    'Private Sub lbProbAssameseWords_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs)
    '    btnClear.Focus()
    'End Sub

    'Private Sub btnClose_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs)
    '    btnClear.Focus()
    'End Sub

    'Private Sub gvComposit_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)
    '    If rbtnAssamese.Checked = False Then
    '        MsgBox("Plese select the Assamese option first.", MsgBoxStyle.Information, "Dictionary")
    '        Exit Sub
    '    End If
    'End Sub

    'Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    If txtWord.Text = "" Then Exit Sub
    '    composeQueryStr(txtWord.Text, " ")
    'End Sub

    'Private Sub gvCons_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)
    '    If rbtnAssamese.Checked = False Then
    '        MsgBox("Plese select the Assamese option first.", MsgBoxStyle.Critical)
    '        Exit Sub
    '    End If
    'End Sub

    'Private Sub gvVowel_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)
    '    If rbtnAssamese.Checked = False Then
    '        MsgBox("Plese select the Assamese option first.", MsgBoxStyle.Critical)
    '        Exit Sub
    '    End If
    'End Sub

    'Private Sub gvData_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)
    '    If rbtnAssamese.Checked = False Then
    '        MsgBox("Plese select the Assamese option first.", MsgBoxStyle.Critical)
    '        Exit Sub
    '    End If
    'End Sub

    'Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
    '    txtAMean.Text = ""
    '    lvWords.Items.Clear()
    '    lvProbableWord.Items.Clear()
    '    If rbtnAssamese.Checked = True Then
    '        lvWords.Items.Clear()
    '        lvProbableWord.Items.Clear()
    '        If txtWord.Text.Length = 0 Then
    '            Exit Sub
    '        End If
    '        txtWord.Text = LSet(txtWord.Text, Len(txtWord.Text) - 1)
    '        lvProbableWord.Items.Clear()
    '        Dim encyptText As String = Encrypt(txtWord.Text, strEncodeString)
    '        PossibleWord(encyptText.Trim)
    '        ShowWords(lvWords, encyptText, 0)
    '    Else
    '        rbtnEnglish.Checked = True
    '        lvWords.Items.Clear()
    '        lvProbableWord.Items.Clear()
    '        lvWords.Refresh()
    '        txtWord.Text = LSet(txtWord.Text, Len(txtWord.Text) - 1)
    '    End If
    '    'FirstRowSelect()
    'End Sub

    'Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click
    '    If txtWord.Text.Trim.Length = 0 Then
    '        txtWord.Focus()
    '        Exit Sub
    '    End If
    '    txtWord.Text = ""
    '    lvWords.Items.Clear()
    '    lvProbableWord.Items.Clear()
    '    imgRetrieve.Image = Nothing
    '    txtAMean.Text = ""
    '    lblDictword.Text = ""
    '    txtWord.Focus()
    'End Sub

    'Private Sub Command5_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Command5.Click
    '    If rbtnAssamese.Checked = False Then
    '        txtWord.Focus()
    '        Exit Sub
    '    End If
    '    If txtWord.Text = "" Then Exit Sub
    '    composeQueryStr(txtWord.Text, " ")
    'End Sub

    'Private Sub SendLetter(ByVal Letter As String)
    '    If rbtnAssamese.Checked = False Then
    '        MsgBox("Please select the Assamese option first.", MsgBoxStyle.Information, "Dictionary")
    '        txtWord.Focus()
    '        Exit Sub
    '    End If
    '    composeQueryStr(txtWord.Text, Letter)
    'End Sub

    'Private Sub cmd1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd1.Click
    '    SendLetter(cmd1.Text)
    'End Sub

    'Private Sub cmd2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd2.Click
    '    SendLetter(cmd2.Text)
    'End Sub

    'Private Sub cmd3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd3.Click
    '    SendLetter(cmd3.Text)
    'End Sub

    'Private Sub cmd4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd4.Click
    '    SendLetter(cmd4.Text)
    'End Sub

    'Private Sub cmd5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd5.Click
    '    SendLetter(cmd5.Text)
    'End Sub

    'Private Sub cmd6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd6.Click
    '    SendLetter(cmd6.Text)
    'End Sub

    'Private Sub cmd7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd7.Click
    '    SendLetter(cmd7.Text)
    'End Sub

    'Private Sub cmd8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd8.Click
    '    SendLetter(cmd8.Text)
    'End Sub

    'Private Sub cmd9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd9.Click
    '    SendLetter(cmd9.Text)
    'End Sub

    'Private Sub cmd10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd10.Click
    '    SendLetter(cmd10.Text)
    'End Sub

    'Private Sub cmd11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd11.Click
    '    SendLetter(cmd11.Text)
    'End Sub

    'Private Sub cmd12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd12.Click
    '    SendLetter(cmd12.Text)
    'End Sub

    'Private Sub cmd13_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd13.Click
    '    SendLetter(cmd13.Text)
    'End Sub

    'Private Sub cmd14_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd14.Click
    '    SendLetter(cmd14.Text)
    'End Sub

    'Private Sub cmd15_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd15.Click
    '    SendLetter(cmd15.Text)
    'End Sub

    'Private Sub cmd16_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd16.Click
    '    SendLetter(cmd16.Text)
    'End Sub

    'Private Sub cmd17_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd17.Click
    '    SendLetter(cmd17.Text)
    'End Sub

    'Private Sub cmd18_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd18.Click
    '    SendLetter(cmd18.Text)
    'End Sub

    'Private Sub cmd19_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd19.Click
    '    SendLetter(cmd19.Text)
    'End Sub

    'Private Sub cmd20_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd20.Click
    '    SendLetter(cmd20.Text)
    'End Sub

    'Private Sub cmd21_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd21.Click
    '    SendLetter(cmd21.Text)
    'End Sub

    'Private Sub cmd22_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd22.Click
    '    SendLetter(cmd22.Text)
    'End Sub

    'Private Sub cmd23_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd23.Click
    '    SendLetter(cmd23.Text)
    'End Sub

    'Private Sub cmd24_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd24.Click
    '    SendLetter(cmd24.Text)
    'End Sub

    'Private Sub cmd25_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd25.Click
    '    SendLetter(cmd25.Text)
    'End Sub

    'Private Sub cmd26_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd26.Click
    '    SendLetter(cmd26.Text)
    'End Sub

    'Private Sub cmd27_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd27.Click
    '    SendLetter(cmd27.Text)
    'End Sub

    'Private Sub cmd28_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd28.Click
    '    SendLetter(cmd28.Text)
    'End Sub

    'Private Sub cmd29_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd29.Click
    '    SendLetter(cmd29.Text)
    'End Sub

    'Private Sub cmd30_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd30.Click
    '    SendLetter(cmd30.Text)
    'End Sub

    'Private Sub cmd31_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd31.Click
    '    SendLetter(cmd31.Text)
    'End Sub

    'Private Sub cmd32_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd32.Click
    '    SendLetter(cmd32.Text)
    'End Sub

    'Private Sub cmd33_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd33.Click
    '    SendLetter(cmd33.Text)
    'End Sub

    'Private Sub cmd34_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd34.Click
    '    SendLetter(cmd34.Text)
    'End Sub

    'Private Sub cmd35_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd35.Click
    '    SendLetter(cmd35.Text)
    'End Sub

    'Private Sub cmd36_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd36.Click
    '    SendLetter(cmd36.Text)
    'End Sub

    'Private Sub cmd37_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd37.Click
    '    SendLetter(cmd37.Text)
    'End Sub

    'Private Sub cmd38_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd38.Click
    '    SendLetter(cmd38.Text)
    'End Sub

    'Private Sub cmd39_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd39.Click
    '    SendLetter(cmd39.Text)
    'End Sub

    'Private Sub cmd40_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd40.Click
    '    SendLetter(cmd40.Text)
    'End Sub

    'Private Sub cmd41_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd41.Click
    '    SendLetter(cmd41.Text)
    'End Sub

    'Private Sub cmd42_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd42.Click
    '    SendLetter(cmd42.Text)
    'End Sub

    'Private Sub cmd43_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd43.Click
    '    SendLetter(cmd43.Text)
    'End Sub

    'Private Sub cmd44_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd44.Click
    '    SendLetter(cmd44.Text)
    'End Sub

    'Private Sub cmd45_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd45.Click
    '    SendLetter(cmd45.Text)
    'End Sub

    'Private Sub cmd46_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd46.Click
    '    SendLetter(cmd46.Text)
    'End Sub

    'Private Sub cmd47_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd47.Click
    '    SendLetter(cmd47.Text)
    'End Sub

    'Private Sub cmd48_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd48.Click
    '    SendLetter(cmd48.Text)
    'End Sub

    'Private Sub cmd49_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd49.Click
    '    SendLetter(cmd49.Text)
    'End Sub

    'Private Sub cmd50_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd50.Click
    '    SendLetter("ং")
    'End Sub

    'Private Sub cmd51_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd51.Click
    '    SendLetter("ঃ")
    'End Sub

    'Private Sub cmd52_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    SendLetter(cmd52.Text)
    'End Sub

    'Private Sub cmd52_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd52.Click
    '    SendLetter("ঁ")
    'End Sub

    'Private Sub cmd53_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd53.Click
    '    SendLetter("’")
    'End Sub

    'Private Sub cmd54_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd54.Click
    '    SendLetter("া")
    'End Sub

    'Private Sub cmd55_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd55.Click
    '    SendLetter("ি")
    'End Sub

    'Private Sub cmd56_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd56.Click
    '    SendLetter("ী")
    'End Sub

    'Private Sub cmd65_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd65.Click
    '    SendLetter("ু")
    'End Sub

    'Private Sub cmd57_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd57.Click
    '    SendLetter("ূ")
    'End Sub

    'Private Sub cmd58_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd58.Click
    '    SendLetter("ৃ")
    'End Sub

    'Private Sub cmd59_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd59.Click
    '    SendLetter("্‌")
    'End Sub

    'Private Sub cmd60_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd60.Click
    '    SendLetter("ে")
    'End Sub

    'Private Sub cmd61_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd61.Click
    '    SendLetter("ৈ")
    'End Sub

    'Private Sub cmd62_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd62.Click
    '    SendLetter("ো")
    'End Sub

    'Private Sub cmd63_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd63.Click
    '    SendLetter("ৌ")
    'End Sub

    'Private Sub cmd64_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd64.Click
    '    SendLetter("ৰ্")
    'End Sub

    'Private Sub cmd66_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd66.Click
    '    SendLetter("-")
    'End Sub

    'Private Sub Button1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
    '    Exit Sub
    'End Sub

    'Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
    '    Exit Sub
    'End Sub

    'Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
    '    Exit Sub
    'End Sub

    'Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
    '    Exit Sub
    'End Sub

    'Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
    '    SendLetter("্য")
    'End Sub

    'Private Sub LoadMeaning(ByVal xID As Integer)
    '    Try
    '        lblDictword.Text = ""
    '        Dim myStr As String = Nothing
    '        If rbtnAssamese.Checked = True Then
    '            myStr = "SELECT MainTable.MyWord, MainTable.AsMeaning, MainTable.EngMeaning, MainTable.Synonyms, MainTable.Antonyms, " & _
    '                    "  Pictures.Picture FROM MainTable LEFT OUTER JOIN Pictures ON Pictures.PiCID=MainTable.PictureID WHERE MainTable.ID= " & xID

    '            'myStr = "SELECT MainTable.MyWord, MainTable.AsMeaning, MainTable.EngMeaning, MainTable.Synonyms," & _
    '            '        " MainTable.Antonyms, Pictures.Picture FROM MainTable LEFT OUTER JOIN Pictures ON Pictures.ID=MainTable.PictureID WHERE MainTable.ID= " & xID
    '            'myStr = "SELECT * FROM MainTable WHERE ID= " & xID

    '            Dim objCmd As New OleDbCommand(myStr, objConn)
    '            Dim rs As OleDbDataReader = objCmd.ExecuteReader
    '            If rs.HasRows Then
    '                rs.Read()
    '                txtAMean.Text = ""
    '                Dim dictWord As String = rs("MyWord")
    '                lblDictword.Text = Decrypt(dictWord, strEncodeString).Trim 'eachCharDecrept(dictWord, strEncodeString)

    '                Dim asMeaning As String = IIf(IsDBNull(rs("AsMeaning")), "", rs("AsMeaning"))
    '                txtAMean.AppendText(Decrypt(asMeaning, strEncodeString) & "  " & Environment.NewLine)
    '                Dim length_1 As Integer = txtAMean.Text.Length
    '                'If txtAMean.Text <> "" Then
    '                '    UnderlineWords(txtAMean.Text, 0, length_1 - 1)
    '                'End If

    '                Dim eMeaning As String = IIf(IsDBNull(rs("EngMeaning")), "", rs("EngMeaning"))
    '                Dim length_2 As Integer = 0
    '                If eMeaning <> "" Then
    '                    txtAMean.AppendText(Decrypt(eMeaning, strEncodeString) & " " & Environment.NewLine)
    '                    length_2 = txtAMean.Text.Length
    '                    Dim Str1 As String = txtAMean.Text.Substring(length_1, length_2 - length_1)
    '                    'If txtAMean.Text <> "" Then
    '                    '    UnderlineWords(Str1, length_1, length_2 - 1)
    '                    'End If
    '                End If
    '                Dim sName As String = "সমাৰ্থক :"
    '                Dim aName As String = "বিপৰীত :"
    '                Dim synonym As String = IIf(IsDBNull(rs("Synonyms")), "", rs("Synonyms"))
    '                Dim length_3 As Integer = 0
    '                If synonym <> "" Then
    '                    sName = sName & " " & Decrypt(synonym, strEncodeString) & " "
    '                    txtAMean.AppendText(Environment.NewLine & sName & " " & Environment.NewLine)
    '                    length_3 = txtAMean.Text.Length
    '                    Dim Str2 As String = txtAMean.Text.Substring(length_2, length_3 - length_2)
    '                    ''If txtAMean.Text <> "" Then
    '                    ''    UnderlineWords(Str2, length_2, length_3 - 1)
    '                    ''End If
    '                End If

    '                Dim antonym As String = IIf(IsDBNull(rs("Antonyms")), "", rs("Antonyms"))
    '                Dim length_4 As Integer = 0
    '                If antonym <> "" Then
    '                    aName = aName & " " & Decrypt(antonym, strEncodeString) & " "
    '                    txtAMean.AppendText(Environment.NewLine & aName & " " & Environment.NewLine)
    '                    length_4 = txtAMean.Text.Length
    '                    Dim Str3 As String = txtAMean.Text.Substring(length_3, length_4 - length_3)
    '                    ''If txtAMean.Text <> "" Then
    '                    ''    UnderlineWords(Str3, length_3, length_4 - 1)
    '                    ''End If
    '                End If
    '                Dim arrayImage() As Byte = CType(rs("Picture"), Byte())
    '                Dim ms As New MemoryStream(arrayImage)
    '                With Me.imgRetrieve
    '                    .Image = Image.FromStream(ms)
    '                    .SizeMode = PictureBoxSizeMode.StretchImage
    '                End With
    '            End If

    '        ElseIf rbtnEnglish.Checked = True Then
    '            'myStr = "SELECT EngWord, EngAsMeaning  FROM EnglishWords WHERE ID=" & xID
    '            myStr = "SELECT EnglishWords.EngWord, EnglishWords.EngAsMeaning, EnglishWords.synonym, EnglishWords.antonym, Pictures.Picture FROM EnglishWords LEFT OUTER JOIN Pictures ON Pictures.PICID=EnglishWords.PictureID WHERE EnglishWords.ID=" & xID

    '            Dim objCmd As New OleDbCommand(myStr, objConn)
    '            Dim rs As OleDbDataReader = objCmd.ExecuteReader
    '            If rs.HasRows Then
    '                rs.Read()
    '                txtAMean.Text = ""
    '                lblDictword.Text = ""
    '                Dim eWord As String = ""
    '                If rs("EngAsMeaning").ToString = "" Then
    '                    txtAMean.Font = New System.Drawing.Font("Times New Roman", 15.0!, FontStyle.Regular, GraphicsUnit.Point, CType(0, Byte))
    '                Else
    '                    txtAMean.Font = New System.Drawing.Font("Asomiya_Rohini", 16.0!, FontStyle.Regular, GraphicsUnit.Point, CType(0, Byte))
    '                    eWord = IIf(IsDBNull(rs("EngWord")), "", rs("EngWord"))
    '                    lblDictword.Text = Decrypt(eWord, strEncodeString).Trim
    '                    Dim eMean As String = IIf(IsDBNull(rs("EngAsMeaning")), "", rs("EngAsMeaning"))
    '                    If eMean <> "" Then
    '                        txtAMean.Text = Decrypt(eMean, strEncodeString)
    '                    End If
    '                End If
    '                'Dim length_1 As Integer = txtAMean.Text.Length
    '                'If txtAMean.Text <> "" Then
    '                '    UnderlineWords(txtAMean.Text, 0, length_1 - 1)
    '                '    'txtAMean.Text = eWord 'Decrypt(txtAMean.Text, strEncodeString)
    '                'End If
    '                Dim sName As String = "SYNONYM :"
    '                Dim aName As String = "ANTONYM :"
    '                Dim synonym As String = IIf(IsDBNull(rs("Synonym")), "", rs("Synonym"))
    '                Dim length_3 As Integer = 0

    '                If synonym <> "" Then
    '                    sName = sName & " " & Decrypt(synonym, strEncodeString) & " "
    '                    txtAMean.AppendText(Environment.NewLine & Environment.NewLine & sName & " " & Environment.NewLine)
    '                    length_3 = txtAMean.Text.Length
    '                    Dim Str2 As String = txtAMean.Text.Substring(length_3)
    '                    ''If txtAMean.Text <> "" Then
    '                    ''    UnderlineWords(Str2, length_2, length_3 - 1)
    '                    ''End If
    '                End If

    '                Dim antonym As String = IIf(IsDBNull(rs("Antonym")), "", rs("Antonym"))
    '                Dim length_4 As Integer = 0
    '                If antonym <> "" Then
    '                    aName = aName & " " & Decrypt(antonym, strEncodeString) & " "
    '                    txtAMean.AppendText(Environment.NewLine & aName & " " & Environment.NewLine)
    '                    length_4 = txtAMean.Text.Length
    '                    Dim Str3 As String = txtAMean.Text.Substring(length_3, length_4 - length_3)
    '                    ''If txtAMean.Text <> "" Then
    '                    ''    UnderlineWords(Str3, length_3, length_4 - 1)
    '                    ''End If
    '                End If
    '                Dim arrayImage() As Byte = CType(rs("Picture"), Byte())
    '                Dim ms As New MemoryStream(arrayImage)
    '                With Me.imgRetrieve
    '                    .Image = Image.FromStream(ms)
    '                    .SizeMode = PictureBoxSizeMode.StretchImage
    '                End With
    '            End If
    '        End If
    '    Catch ex As Exception
    '        Exit Sub
    '    End Try

    'End Sub

    'Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
    '    SendLetter(Button6.Text)
    'End Sub

    'Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
    '    SendLetter("্")
    'End Sub

    'Private Sub txtWord_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtWord.TextChanged
    '    txtAMean.Text = ""
    '    lblDictword.Text = ""
    '    imgRetrieve.Image = Nothing
    '    lvProbableWord.Items.Clear()
    '    lvWords.Items.Clear()
    '    If txtWord.Text.Trim.Length > 49 Then Exit Sub
    '    If txtWord.Text = "" Then
    '        lvWords.Items.Clear()
    '        lvProbableWord.Items.Clear()
    '        Exit Sub
    '    End If
    '    If rbtnAssamese.Checked = False Then
    '        Dim xCharacterEncrypted As String = ""
    '        xCharacterEncrypted = EachCharacterEncrypt(txtWord.Text.ToLower, strEncodeString)

    '        If Not ShowEngWords(xCharacterEncrypted, 0) Then
    '            Exit Sub
    '        End If
    '        'If Not ShowEngWords(txtWord.Text, 0) Then
    '        '    Exit Sub
    '        'End If
    '    Else
    '        lvProbableWord.Items.Clear()
    '        lvWords.Items.Clear()
    '        Dim encryptedByCharacter As String = ""
    '        encryptedByCharacter = EachCharacterEncrypt(txtWord.Text, strEncodeString)

    '        'PossibleWord(txtWord.Text.Trim)
    '        'ShowWords(lvWords, txtWord.Text.Trim)

    '        ShowWords(lvWords, encryptedByCharacter.Trim, 0)
    '        PossibleWord(encryptedByCharacter.Trim)

    '    End If
    '    FirstRowSelect()
    'End Sub


    'Private Sub FirstRowSelect()
    '    lvWords.Refresh()
    '    lvProbableWord.Refresh()
    '    Try
    '        If lvWords.Items.Count > 0 And lvProbableWord.Items.Count > 0 Then
    '            lvProbableWord.SelectedIndices.Clear()
    '            lvProbableWord.HideSelection = True
    '            lvProbableWord.Refresh()
    '            lvWords.SelectedIndices.Clear()
    '            lvWords.Refresh()
    '            lvWords.HideSelection = False
    '            lvWords.Items(0).Selected = True
    '        Else
    '            If lvWords.Items.Count = 0 Then
    '                If lvProbableWord.Items.Count <> 0 Then
    '                    lvWords.SelectedIndices.Clear()
    '                    lvWords.HideSelection = True
    '                    lvWords.Refresh()
    '                    lvProbableWord.SelectedIndices.Clear()
    '                    lvProbableWord.Refresh()
    '                    lvProbableWord.HideSelection = False
    '                    lvProbableWord.Items(0).Selected = True
    '                End If
    '            Else
    '                lvWords.SelectedIndices.Clear()
    '                lvWords.Refresh()
    '                lvWords.HideSelection = False
    '                lvWords.Items(0).Selected = True
    '            End If
    '        End If
    '    Catch ex As Exception
    '        Exit Sub
    '    End Try

    'End Sub

    'Private Sub UnderlineWords(ByVal input As String, ByVal startIndex As Integer, ByVal endIndex As Integer)
    '    'Try

    '    '    Dim Words() As String = input.Split(" ")
    '    '    For Each word As String In Words
    '    '        Dim xWord As String = word
    '    '        Dim len As Integer = xWord.Length
    '    '        If len > 1 Then
    '    '            Dim fCh As Char = xWord.Substring(0, 1)
    '    '            Dim LCh As Char = xWord.Substring(len - 1)

    '    '            If fCh = "" Then
    '    '                xWord = xWord.Substring(1, len - 1)
    '    '                len = len - 1
    '    '                fCh = xWord.Substring(0, 1)
    '    '            End If

    '    '            If fCh = "(" Or fCh = "[" Or fCh = " " Then
    '    '                xWord = xWord.Substring(1, len - 1)
    '    '                len = len - 1
    '    '            End If

    '    '            If LCh = "" Then
    '    '                xWord = xWord.Substring(0, len - 1)
    '    '                len = len - 1
    '    '                LCh = xWord.Substring(len - 1)
    '    '            End If

    '    '            If LCh = "'" Or LCh = ";" Or LCh = ":" Or LCh = "]" Or LCh = ")" Or LCh = "," Or LCh = "।" Or LCh = "(" Or LCh = "[" Or LCh = "." Or LCh = " " Then
    '    '                xWord = xWord.Substring(0, len - 1)
    '    '            End If
    '    '            '===================== using it for second time the same code for some reason========
    '    '            len = xWord.Length
    '    '            LCh = xWord.Substring(len - 1)
    '    '            If LCh = "'" Or LCh = ";" Or LCh = ":" Or LCh = "]" Or LCh = ")" Or LCh = "," Or LCh = "।" Or LCh = "(" Or LCh = "[" Or LCh = "." Then
    '    '                xWord = xWord.Substring(0, len - 1)
    '    '            End If
    '    '            '===================================================================================
    '    '            If len > 1 Then

    '    '                If IsUnicode(xWord) Then
    '    '                    Dim myStr As String = "SELECT * from MainTable where MyWord= '" & xWord & "'" '& Replace(SearchWord, "'", "''") & "'"
    '    '                    'selecteUNicodeWord = EachCharacterEncrypt(xWord, strEncodeString) 'Encrypt(xWord, strEncodeString)
    '    '                    'Dim myStr As String = "SELECT ID from MainTable where MyWord='" & selecteUNicodeWord & "'"

    '    '                    Dim objCmd As New OleDbCommand(myStr, objConn)
    '    '                    Dim rs As OleDbDataReader = objCmd.ExecuteReader
    '    '                    If rs.HasRows Then
    '    '                        Dim strSearch As String = xWord
    '    '                        For i As Integer = startIndex To endIndex
    '    '                            Dim index As Integer = txtAMean.Find(strSearch, startIndex, endIndex, RichTextBoxFinds.WholeWord)
    '    '                            If index <> -1 Then
    '    '                                txtAMean.SelectionStart = index
    '    '                                txtAMean.SelectionLength = strSearch.Length
    '    '                                txtAMean.SelectionColor = Color.Coral
    '    '                                startIndex = index + strSearch.Length
    '    '                            End If
    '    '                        Next
    '    '                    End If
    '    '                    rs.Close()
    '    '                Else
    '    '                    SelecteEngWord = EachCharacterEncrypt(xWord, strEncodeString)
    '    '                    Dim myStr As String = "SELECT ID from EnglishWords where EngWord= '" & SelecteEngWord & "'"
    '    '                    Dim objCmd As New OleDbCommand(myStr, objConn)
    '    '                    Dim rs As OleDbDataReader = objCmd.ExecuteReader
    '    '                    If rs.HasRows Then
    '    '                        Dim strSearch As String = xWord
    '    '                        For i As Integer = startIndex To endIndex
    '    '                            Dim index As Integer = txtAMean.Find(strSearch, startIndex, endIndex, RichTextBoxFinds.WholeWord)
    '    '                            If index <> -1 Then
    '    '                                txtAMean.SelectionStart = index
    '    '                                txtAMean.SelectionLength = strSearch.Length
    '    '                                txtAMean.SelectionColor = Color.Coral
    '    '                            End If
    '    '                            startIndex = i
    '    '                        Next
    '    '                    End If
    '    '                    rs.Close()
    '    '                End If
    '    '            End If
    '    '        End If
    '    '    Next
    '    'Catch ex As Exception
    '    '    Exit Sub
    '    'End Try

    'End Sub

    'Private Sub lvWords_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvWords.GotFocus
    '    If lvWords.Items.Count > 0 Then
    '        lvWords.HideSelection = False
    '        lvProbableWord.SelectedIndices.Clear()
    '        lvProbableWord.Refresh()
    '        lvProbableWord.HideSelection = True
    '        LoadMeaning(lvWords.Items(0).Name)
    '    End If
    'End Sub

    'Private Sub lvProbableWord_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvProbableWord.GotFocus
    '    If lvProbableWord.Items.Count > 0 Then
    '        lvProbableWord.HideSelection = False
    '        lvWords.SelectedIndices.Clear()
    '        lvWords.Refresh()
    '        lvWords.HideSelection = True
    '        LoadMeaning(lvProbableWord.Items(0).Name)
    '    End If
    'End Sub

    'Private Sub lvProbableWord_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvProbableWord.SelectedIndexChanged
    '    imgRetrieve.Image = Nothing
    '    Dim prevWord As String = lblDictword.Text.ToString.Trim
    '    If lvProbableWord.SelectedItems.Count <> 0 Then
    '        lvWords.HideSelection = True
    '        txtAMean.Text = ""
    '        LoadMeaning(lvProbableWord.SelectedItems(0).Name)
    '        'If prevWord <> "" Then
    '        '    storeWord.Add(prevWord)
    '        '    wordSelect = 2
    '        'End If
    '    End If
    'End Sub

    'Private Sub lvWords_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvWords.MouseHover
    '    If lvWords.Items.Count > 0 Then
    '        lvWords.Focus()
    '    End If
    'End Sub

    'Private Sub lvWords_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvWords.SelectedIndexChanged
    '    imgRetrieve.Image = Nothing
    '    Dim prevWord As String = lblDictword.Text.ToString.Trim
    '    If lvWords.SelectedItems.Count <> 0 Then
    '        lvProbableWord.HideSelection = True
    '        txtAMean.Clear()
    '        LoadMeaning(lvWords.SelectedItems(0).Name)
    '        'If prevWord <> "" Then
    '        '    storeWord.Add(prevWord)
    '        '    wordSelect = 2
    '        'End If
    '    End If

    'End Sub

    'Private Sub txtWord_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtWord.LostFocus
    '    If lvWords.Items.Count = 0 And lvProbableWord.Items.Count = 0 Then Exit Sub
    '    If lvWords.Items.Count = 0 Then
    '        lvProbableWord.Focus()
    '    Else
    '        lvWords.Focus()
    '    End If
    'End Sub


    'Public Function GetWordUnderMouse(ByRef Rtf As System.Windows.Forms.RichTextBox, ByVal X As Integer, ByVal Y As Integer) As String
    '    On Error Resume Next
    '    Dim POINT As System.Drawing.Point = New System.Drawing.Point()
    '    Dim Pos As Integer, i As Integer, lStart As Integer, lEnd As Integer
    '    Dim lLen As Integer, sTxt As String, sChr As String
    '    '
    '    POINT.X = X
    '    POINT.Y = Y
    '    GetWordUnderMouse = vbNullString
    '    '
    '    With Rtf
    '        lLen = Len(.Text)
    '        sTxt = .Text
    '        Pos = Rtf.GetCharIndexFromPosition(POINT)
    '        If Pos > 0 Then
    '            For i = Pos To 1 Step -1
    '                sChr = Mid(sTxt, i, 1)
    '                If sChr = " " Or sChr = Chr(13) Or i = 1 Then
    '                    'if the starting character is vbcrlf then
    '                    'we want to chop that off
    '                    If sChr = Chr(13) Then
    '                        lStart = (i + 2)
    '                    Else
    '                        lStart = i
    '                    End If
    '                    Exit For
    '                End If
    '            Next i
    '            For i = Pos To lLen
    '                If Mid(sTxt, i, 1) = " " Or Mid(sTxt, i, 1) = Chr(13) Or i = lLen Then
    '                    lEnd = i + 1
    '                    Exit For
    '                End If
    '            Next i
    '            If lEnd >= lStart Then
    '                GetWordUnderMouse = Trim(Mid(sTxt, lStart, lEnd - lStart))
    '            End If
    '        End If
    '    End With
    'End Function


    'Private Sub txtAMean_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles txtAMean.MouseClick
    '    Dim count As Integer = storeWord.Count
    '    Dim previosWord As String = lblDictword.Text.Trim
    '    'If lastSelectIndex >= 0 Then
    '    '    storedPrevWord.Add(previosWord)
    '    'End If

    '    Try
    '        isLinkedWord = False
    '        curWord = GetWordUnderMouse(Me.txtAMean, e.X, e.Y)

    '        If curWord = "" Then Exit Sub
    '        Dim xWord As String = curWord.Trim
    '        Dim len As Integer = xWord.Length
    '        Dim fCh As Char = xWord.Substring(0, 1)
    '        Dim LCh As Char = xWord.Substring(len - 1)

    '        If fCh = "(" Or fCh = "[" Or fCh = "" Or fCh = "‘" Then
    '            xWord = xWord.Substring(1, len - 1)
    '            len = len - 1
    '        End If
    '        If LCh = "'" Or LCh = "’" Or LCh = ";" Or LCh = ":" Or LCh = "]" Or LCh = ")" Or LCh = "," Or LCh = "।" Or LCh = "(" Or LCh = "[" Or LCh = "." Then
    '            xWord = xWord.Substring(0, len - 1)
    '        End If
    '        '=====================using it for second time the same code for some reason========
    '        len = xWord.Length
    '        LCh = xWord.Substring(len - 1)
    '        If LCh = "'" Or LCh = "‘" Or LCh = ";" Or LCh = ":" Or LCh = "]" Or LCh = ")" Or LCh = "," Or LCh = "।" Or LCh = "(" Or LCh = "[" Or LCh = "." Then
    '            xWord = xWord.Substring(0, len - 1)
    '        End If
    '        '        '===================================================================================
    '        '        ' checking the string Unicode or Not... 
    '        '        'if Unicode then check in the assamese table and if Non Unicode then check in the english table
    '        '        '====================================================================================

    '        If IsUnicode(xWord) Then

    '            'true.. search Assamese
    '            selecteUNicodeWord = EachCharacterEncrypt(xWord, strEncodeString)
    '            Dim cmd As New OleDbCommand("SELECT Asmeaning, EngMeaning FROM MainTable WHERE MyWord_Ch ='" & selecteUNicodeWord & "'", objConn)
    '            'cmd.Parameters.Add("@word", OleDbType.VarWChar).Value = Encrypt(xWord.Trim, strEncodeString)
    '            Dim rs As OleDbDataReader = cmd.ExecuteReader
    '            If rs.HasRows Then
    '                rbtnAssamese.Checked = True
    '                txtWord.Text = xWord
    '            Else
    '                Exit Sub
    '            End If
    '            'myList.Add(previosWord)
    '            'storeWord.Add(previosWord)
    '            'wordSelect = 0

    '        Else
    '            ''false.. search English
    '            xWord = xWord.ToLower
    '            SelecteEngWord = EachCharacterEncrypt(xWord, strEncodeString)
    '            Dim cmd As New OleDbCommand("SELECT * FROM EnglishWords WHERE EngWord_Ch ='" & SelecteEngWord & "'", objConn)
    '            'cmd.Parameters.Add("@EngWord", OleDbType.VarWChar).Value = Encrypt(xWord.Trim, strEncodeString)
    '            Dim rs As OleDbDataReader = cmd.ExecuteReader
    '            If rs.HasRows Then
    '                isLinkedWord = True
    '                rbtnEnglish.Checked = True
    '                txtWord.Text = xWord
    '            Else
    '                Exit Sub
    '            End If
    '            'myList.Add(previosWord)
    '            'storeWord.Add(previosWord)
    '            'wordSelect = 0
    '        End If
    '    Catch ex As Exception
    '        Exit Sub
    '    End Try
    'End Sub

    '        'Private Sub ShowSelecetedEngWord(ByVal mybox As ListView, ByVal myval As String)
    '        '    Try

    '        '        lvWords.Items.Clear()
    '        '        If myval = "" Then
    '        '            Exit Sub
    '        '        End If
    '        '        Dim myStr As String = Nothing
    '        '        myStr = "SELECT  ID, EngWord FROM EnglishWords WHERE EngWord='" & myval & "' ORDER BY  EngWord, LEN(EngWord) ASC"
    '        '        Dim objCmd As New OleDbCommand(myStr, objConn)
    '        '        Dim rs As OleDbDataReader = objCmd.ExecuteReader
    '        '        If rs.HasRows Then
    '        '            Dim xItem As ListViewItem
    '        '            Do While rs.Read
    '        '                Dim xWord As String = IIf(IsDBNull(rs("EngWord")), "", rs("EngWord"))
    '        '                xItem = lvWords.Items.Add(rs("ID"), xWord, "")
    '        '            Loop
    '        '        End If
    '        '    Catch ex As Exception
    '        '        Exit Sub
    '        '    End Try
    '        'End Sub

    '        'Private Sub ShowSelectedAssameseWord(ByRef Mybox As ListView, ByVal myval As String)
    '        '    Try
    '        '        Mybox.Items.Clear()
    '        '        Dim xMyval As String = ""
    '        '        xMyval = " left(MyWord, " & Len(myval) & ")= '" & myval.Substring(0, myval.Length) & "'"
    '        '        txtAMean.Clear()
    '        '        If myval = "" Then
    '        '            Exit Sub
    '        '        End If
    '        '        myval = xMyval
    '        '        Dim myStr As String = Nothing
    '        '        myStr = "SELECT TOP 500 ID, MyWord FROM MainTable WHERE " & myval & " ORDER BY ID, MyWOrd , LEN(MyWord) ASC"
    '        '        Dim objCmd As New OleDbCommand(myStr, objConn)
    '        '        Dim rs As OleDbDataReader = objCmd.ExecuteReader
    '        '        If rs.HasRows Then
    '        '            Dim xItem As ListViewItem
    '        '            Do While rs.Read
    '        '                Dim myword As String = IIf(IsDBNull(rs("MyWord")), "", rs("MyWord"))
    '        '                xItem = Mybox.Items.Add(rs("ID"), myword, "")
    '        '            Loop
    '        '        Else
    '        '            Exit Sub
    '        '        End If
    '        '    Catch ex As Exception
    '        '        'MsgBox(ex.Message)
    '        '        'MsgBox("Error in loading the data.", MsgBoxStyle.Critical, "Error")
    '        '        Exit Sub
    '        '    End Try
    '        '    Exit Sub
    '        'End Sub



    '        'Private Sub addItem(ByVal stext As String)
    '        '    AddElementToStringArray(stext)
    '        '    Try
    '        '        Dim cmd As New OleDbCommand("INSERT INTO tempData(id,word) VALUES(?,?)", objConn)
    '        '        cmd.Parameters.Add("@id", OleDbType.Date).Value = Now
    '        '        cmd.Parameters.Add("@word", OleDbType.VarWChar).Value = stext
    '        '        cmd.ExecuteNonQuery()
    '        '    Catch ex As Exception
    '        '        Exit Sub
    '        '    End Try
    '        'End Sub

    'Private Function IsUnicode(ByVal Str As String) As Boolean

    '    'Set it to False by default
    '    Dim bIsUnicode As Boolean = False
    '    'Setup Encodings
    '    Dim EncDefault As System.Text.Encoding = System.Text.Encoding.GetEncoding(0) 'String Default Encoding
    '    Dim EncUnicode As System.Text.Encoding = System.Text.Encoding.Unicode 'Encoding
    '    Dim bitesDefault As Byte() = EncDefault.GetBytes(Str) 'Get the bytes of the string using the string's default encoding
    '    Dim bitesUnicode As Byte() = EncUnicode.GetBytes(Str)
    '    Dim charsDefault As Char() = EncDefault.GetChars(bitesDefault) 'Get the characters of the default string
    '    Dim charsUnicode As Char() = EncUnicode.GetChars(bitesUnicode) 'Get the characters in unicode
    '    'Loop through all the characters and see if they all match.
    '    ' if any do not match, then it's unicode
    '    For i As Integer = 0 To charsDefault.Length - 1
    '        If charsDefault(i) <> charsUnicode(i) Then
    '            bIsUnicode = True
    '            'we found one that doesn't match, so exit the loop
    '            Exit For
    '        End If
    '    Next
    '    Return bIsUnicode
    'End Function

    'Private Sub txtWord_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtWord.KeyPress
    '    If Val(e.KeyChar) = 108 Then
    '        Me.Close()
    '    End If
    'End Sub

    'Private Sub txtWord_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtWord.KeyDown
    '    Dim Test As Integer = 0
    '    'lblProbableWords.Text = e.KeyCode
    '    If rbtnAssamese.Checked = True Then
    '        'If e.Alt = False And e.Control = False And e.Shift = False And e.KeyCode = 75 Then
    '        '    Test = txtWord.SelectionStart
    '        '    txtWord.Text = txtWord.Text.Insert(txtWord.SelectionStart, "ক")
    '        '    e.SuppressKeyPress = True
    '        '    txtWord.SelectionStart = Test + 1
    '        'End If
    '        'If e.Alt = False And e.Control = False And e.Shift = False And e.KeyCode = 79 Then
    '        '    Test = txtWord.SelectionStart
    '        '    'txtWord.Text = txtWord.Text.Insert(txtWord.SelectionStart, "দ")
    '        '    e.SuppressKeyPress = True
    '        '    txtWord.SelectionStart = Test + 1
    '        'End If
    '        'If e.Alt = False And e.Control = False And e.Shift = False And e.KeyCode = 76 Then
    '        '    Test = txtWord.SelectionStart
    '        '    txtWord.Text = txtWord.Text.Insert(txtWord.SelectionStart, "ল")
    '        '    e.SuppressKeyPress = True
    '        '    txtWord.SelectionStart = Test + 1
    '        'End If
    '        'If e.Alt = False And e.Control = False And e.Shift = False And e.KeyCode = 66 Then
    '        '    Test = txtWord.SelectionStart
    '        '    txtWord.Text = txtWord.Text.Insert(txtWord.SelectionStart, "ব")
    '        '    e.SuppressKeyPress = True
    '        '    txtWord.SelectionStart = Test + 1
    '        'End If
    '        'If e.Alt = False And e.Control = False And e.Shift = False And e.KeyCode = 73 Then
    '        '    Test = txtWord.SelectionStart
    '        '    txtWord.Text = txtWord.Text.Insert(txtWord.SelectionStart, "ি")
    '        '    e.SuppressKeyPress = True
    '        '    txtWord.SelectionStart = Test + 1
    '        'End If






    '        If e.Alt = False And e.Control = False And e.Shift = False And e.KeyCode = 75 Then
    '            Test = txtWord.SelectionStart
    '            txtWord.Text = txtWord.Text.Insert(txtWord.SelectionStart, "ক")
    '            e.SuppressKeyPress = True
    '            txtWord.SelectionStart = Test + 1
    '        End If
    '        If e.Alt = False And e.Control = False And e.Shift = True And e.KeyCode = 75 Then
    '            Test = txtWord.SelectionStart
    '            txtWord.Text = txtWord.Text.Insert(txtWord.SelectionStart, "খ")
    '            e.SuppressKeyPress = True
    '            txtWord.SelectionStart = Test + 1
    '        End If

    '        If e.Alt = False And e.Control = False And e.Shift = False And e.KeyCode = 73 Then
    '            Test = txtWord.SelectionStart
    '            txtWord.Text = txtWord.Text.Insert(txtWord.SelectionStart, "গ")
    '            e.SuppressKeyPress = True
    '            txtWord.SelectionStart = Test + 1
    '        End If
    '        If e.Alt = False And e.Control = False And e.Shift = True And e.KeyCode = 73 Then
    '            Test = txtWord.SelectionStart
    '            txtWord.Text = txtWord.Text.Insert(txtWord.SelectionStart, "ঘ")
    '            e.SuppressKeyPress = True
    '            txtWord.SelectionStart = Test + 1
    '        End If
    '        If e.Alt = False And e.Control = False And e.Shift = True And e.KeyCode = 85 Then
    '            Test = txtWord.SelectionStart
    '            txtWord.Text = txtWord.Text.Insert(txtWord.SelectionStart, "ঙ")
    '            e.SuppressKeyPress = True
    '            txtWord.SelectionStart = Test + 1
    '        End If

    '        If e.Alt = False And e.Control = False And e.Shift = False And e.KeyCode = 186 Then
    '            Test = txtWord.SelectionStart
    '            txtWord.Text = txtWord.Text.Insert(txtWord.SelectionStart, "চ")
    '            e.SuppressKeyPress = True
    '            txtWord.SelectionStart = Test + 1
    '        End If

    '        If e.Alt = False And e.Control = False And e.Shift = True And e.KeyCode = 186 Then
    '            Test = txtWord.SelectionStart
    '            txtWord.Text = txtWord.Text.Insert(txtWord.SelectionStart, "ছ")
    '            e.SuppressKeyPress = True
    '            txtWord.SelectionStart = Test + 1
    '        End If

    '        If e.Alt = False And e.Control = False And e.Shift = False And e.KeyCode = 80 Then
    '            Test = txtWord.SelectionStart
    '            txtWord.Text = txtWord.Text.Insert(txtWord.SelectionStart, "জ")
    '            e.SuppressKeyPress = True
    '            txtWord.SelectionStart = Test + 1
    '        End If
    '        If e.Alt = False And e.Control = False And e.Shift = True And e.KeyCode = 80 Then
    '            Test = txtWord.SelectionStart
    '            txtWord.Text = txtWord.Text.Insert(txtWord.SelectionStart, "ঝ")
    '            e.SuppressKeyPress = True
    '            txtWord.SelectionStart = Test + 1
    '        End If
    '        If e.Alt = False And e.Control = False And e.Shift = True And e.KeyCode = 78 Then
    '            Test = txtWord.SelectionStart
    '            txtWord.Text = txtWord.Text.Insert(txtWord.SelectionStart, "ঞ")
    '            e.SuppressKeyPress = True
    '            txtWord.SelectionStart = Test + 1
    '        End If
    '        If e.Alt = False And e.Control = False And e.Shift = False And e.KeyCode = 222 Then
    '            Test = txtWord.SelectionStart
    '            txtWord.Text = txtWord.Text.Insert(txtWord.SelectionStart, "ট")
    '            e.SuppressKeyPress = True
    '            txtWord.SelectionStart = Test + 1
    '        End If
    '        If e.Alt = False And e.Control = False And e.Shift = True And e.KeyCode = 222 Then
    '            Test = txtWord.SelectionStart
    '            txtWord.Text = txtWord.Text.Insert(txtWord.SelectionStart, "ঠ")
    '            e.SuppressKeyPress = True
    '            txtWord.SelectionStart = Test + 1
    '        End If
    '        If e.Alt = False And e.Control = False And e.Shift = False And e.KeyCode = 219 Then
    '            Test = txtWord.SelectionStart
    '            txtWord.Text = txtWord.Text.Insert(txtWord.SelectionStart, "ড")
    '            e.SuppressKeyPress = True
    '            txtWord.SelectionStart = Test + 1
    '        End If
    '        If e.Alt = False And e.Control = False And e.Shift = True And e.KeyCode = 219 Then
    '            Test = txtWord.SelectionStart
    '            txtWord.Text = txtWord.Text.Insert(txtWord.SelectionStart, "ঢ")
    '            e.SuppressKeyPress = True
    '            txtWord.SelectionStart = Test + 1
    '        End If
    '        If e.Alt = False And e.Control = False And e.Shift = True And e.KeyCode = 67 Then
    '            Test = txtWord.SelectionStart
    '            txtWord.Text = txtWord.Text.Insert(txtWord.SelectionStart, "ণ")
    '            e.SuppressKeyPress = True
    '            txtWord.SelectionStart = Test + 1
    '        End If

    '        If e.Alt = False And e.Control = False And e.Shift = False And e.KeyCode = 76 Then
    '            Test = txtWord.SelectionStart
    '            txtWord.Text = txtWord.Text.Insert(txtWord.SelectionStart, "ত")
    '            e.SuppressKeyPress = True
    '            txtWord.SelectionStart = Test + 1
    '        End If
    '        If e.Alt = False And e.Control = False And e.Shift = True And e.KeyCode = 76 Then
    '            Test = txtWord.SelectionStart
    '            txtWord.Text = txtWord.Text.Insert(txtWord.SelectionStart, "থ")
    '            e.SuppressKeyPress = True
    '            txtWord.SelectionStart = Test + 1
    '        End If

    '        If e.Alt = False And e.Control = False And e.Shift = False And e.KeyCode = 79 Then
    '            Test = txtWord.SelectionStart
    '            txtWord.Text = txtWord.Text.Insert(txtWord.SelectionStart, "দ")
    '            e.SuppressKeyPress = True
    '            txtWord.SelectionStart = Test + 1
    '        End If
    '        If e.Alt = False And e.Control = False And e.Shift = True And e.KeyCode = 79 Then
    '            Test = txtWord.SelectionStart
    '            txtWord.Text = txtWord.Text.Insert(txtWord.SelectionStart, "ধ")
    '            e.SuppressKeyPress = True
    '            txtWord.SelectionStart = Test + 1
    '        End If
    '        If e.Alt = False And e.Control = False And e.Shift = False And e.KeyCode = 86 Then
    '            Test = txtWord.SelectionStart
    '            txtWord.Text = txtWord.Text.Insert(txtWord.SelectionStart, "ন")
    '            e.SuppressKeyPress = True
    '            txtWord.SelectionStart = Test + 1
    '        End If
    '        If e.Alt = False And e.Control = False And e.Shift = False And e.KeyCode = 72 Then
    '            Test = txtWord.SelectionStart
    '            txtWord.Text = txtWord.Text.Insert(txtWord.SelectionStart, "প")
    '            e.SuppressKeyPress = True
    '            txtWord.SelectionStart = Test + 1
    '        End If

    '        If e.Alt = False And e.Control = False And e.Shift = True And e.KeyCode = 72 Then
    '            Test = txtWord.SelectionStart
    '            txtWord.Text = txtWord.Text.Insert(txtWord.SelectionStart, "ফ")
    '            e.SuppressKeyPress = True
    '            txtWord.SelectionStart = Test + 1
    '        End If

    '        If e.Alt = False And e.Control = False And e.Shift = False And e.KeyCode = 89 Then
    '            Test = txtWord.SelectionStart
    '            txtWord.Text = txtWord.Text.Insert(txtWord.SelectionStart, "ব")
    '            e.SuppressKeyPress = True
    '            txtWord.SelectionStart = Test + 1
    '        End If

    '        If e.Alt = False And e.Control = False And e.Shift = True And e.KeyCode = 89 Then
    '            Test = txtWord.SelectionStart
    '            txtWord.Text = txtWord.Text.Insert(txtWord.SelectionStart, "ভ")
    '            e.SuppressKeyPress = True
    '            txtWord.SelectionStart = Test + 1
    '        End If
    '        If e.Alt = False And e.Control = False And e.Shift = False And e.KeyCode = 67 Then
    '            Test = txtWord.SelectionStart
    '            txtWord.Text = txtWord.Text.Insert(txtWord.SelectionStart, "ম")
    '            e.SuppressKeyPress = True
    '            txtWord.SelectionStart = Test + 1
    '        End If
    '        If e.Alt = False And e.Control = False And e.Shift = False And e.KeyCode = 220 Then
    '            Test = txtWord.SelectionStart
    '            txtWord.Text = txtWord.Text.Insert(txtWord.SelectionStart, "য")
    '            e.SuppressKeyPress = True
    '            txtWord.SelectionStart = Test + 1
    '        End If

    '        If e.Alt = False And e.Control = False And e.Shift = False And e.KeyCode = 74 Then
    '            Test = txtWord.SelectionStart
    '            txtWord.Text = txtWord.Text.Insert(txtWord.SelectionStart, "ৰ")
    '            e.SuppressKeyPress = True
    '            txtWord.SelectionStart = Test + 1
    '        End If

    '        If e.Alt = False And e.Control = False And e.Shift = False And e.KeyCode = 78 Then
    '            Test = txtWord.SelectionStart
    '            txtWord.Text = txtWord.Text.Insert(txtWord.SelectionStart, "ল")
    '            e.SuppressKeyPress = True
    '            txtWord.SelectionStart = Test + 1
    '        End If
    '        If e.Alt = False And e.Control = False And e.Shift = False And e.KeyCode = 66 Then
    '            Test = txtWord.SelectionStart
    '            txtWord.Text = txtWord.Text.Insert(txtWord.SelectionStart, "ৱ")
    '            e.SuppressKeyPress = True
    '            txtWord.SelectionStart = Test + 1
    '        End If
    '        If e.Alt = False And e.Control = False And e.Shift = True And e.KeyCode = 77 Then
    '            Test = txtWord.SelectionStart
    '            txtWord.Text = txtWord.Text.Insert(txtWord.SelectionStart, "শ")
    '            e.SuppressKeyPress = True
    '            txtWord.SelectionStart = Test + 1
    '        End If
    '        If e.Alt = False And e.Control = False And e.Shift = True And e.KeyCode = 188 Then
    '            Test = txtWord.SelectionStart
    '            txtWord.Text = txtWord.Text.Insert(txtWord.SelectionStart, "ষ")
    '            e.SuppressKeyPress = True
    '            txtWord.SelectionStart = Test + 1
    '        End If
    '        If e.Alt = False And e.Control = False And e.Shift = False And e.KeyCode = 77 Then
    '            Test = txtWord.SelectionStart
    '            txtWord.Text = txtWord.Text.Insert(txtWord.SelectionStart, "স")
    '            e.SuppressKeyPress = True
    '            txtWord.SelectionStart = Test + 1
    '        End If
    '        If e.Alt = False And e.Control = False And e.Shift = False And e.KeyCode = 85 Then
    '            Test = txtWord.SelectionStart
    '            txtWord.Text = txtWord.Text.Insert(txtWord.SelectionStart, "হ")
    '            e.SuppressKeyPress = True
    '            txtWord.SelectionStart = Test + 1
    '        End If
    '        If e.Alt = False And e.Control = False And e.Shift = True And e.KeyCode = 55 Then
    '            Test = txtWord.SelectionStart
    '            txtWord.Text = txtWord.Text.Insert(txtWord.SelectionStart, "ক্ষ")
    '            e.SuppressKeyPress = True
    '            txtWord.SelectionStart = Test + 3
    '        End If

    '        If e.Alt = False And e.Control = False And e.Shift = False And e.KeyCode = 221 Then
    '            Test = txtWord.SelectionStart
    '            txtWord.Text = txtWord.Text.Insert(txtWord.SelectionStart, "ড়")
    '            e.SuppressKeyPress = True
    '            txtWord.SelectionStart = Test + 1
    '        End If
    '        If e.Alt = False And e.Control = False And e.Shift = True And e.KeyCode = 221 Then
    '            Test = txtWord.SelectionStart
    '            txtWord.Text = txtWord.Text.Insert(txtWord.SelectionStart, "ঢ়")
    '            e.SuppressKeyPress = True
    '            txtWord.SelectionStart = Test + 1
    '        End If
    '        If e.Alt = False And e.Control = False And e.Shift = False And e.KeyCode = 191 Then
    '            Test = txtWord.SelectionStart
    '            txtWord.Text = txtWord.Text.Insert(txtWord.SelectionStart, "য়")
    '            e.SuppressKeyPress = True
    '            txtWord.SelectionStart = Test + 1
    '        End If
    '        If e.Alt = False And e.Control = False And e.Shift = True And e.KeyCode = 220 Then
    '            Test = txtWord.SelectionStart
    '            txtWord.Text = txtWord.Text.Insert(txtWord.SelectionStart, "ৎ")
    '            e.SuppressKeyPress = True
    '            txtWord.SelectionStart = Test + 1
    '        End If
    '        If e.Alt = False And e.Control = False And e.Shift = True And e.KeyCode = 68 Then
    '            Test = txtWord.SelectionStart
    '            txtWord.Text = txtWord.Text.Insert(txtWord.SelectionStart, "অ")
    '            e.SuppressKeyPress = True
    '            txtWord.SelectionStart = Test + 1
    '        End If
    '        If e.Alt = False And e.Control = False And e.Shift = True And e.KeyCode = 69 Then
    '            Test = txtWord.SelectionStart
    '            txtWord.Text = txtWord.Text.Insert(txtWord.SelectionStart, "আ")
    '            e.SuppressKeyPress = True
    '            txtWord.SelectionStart = Test + 1
    '        End If
    '        If e.Alt = False And e.Control = False And e.Shift = True And e.KeyCode = 70 Then
    '            Test = txtWord.SelectionStart
    '            txtWord.Text = txtWord.Text.Insert(txtWord.SelectionStart, "ই")
    '            e.SuppressKeyPress = True
    '            txtWord.SelectionStart = Test + 1
    '        End If
    '        If e.Alt = False And e.Control = False And e.Shift = True And e.KeyCode = 82 Then
    '            Test = txtWord.SelectionStart
    '            txtWord.Text = txtWord.Text.Insert(txtWord.SelectionStart, "ঈ")
    '            e.SuppressKeyPress = True
    '            txtWord.SelectionStart = Test + 1
    '        End If
    '        If e.Alt = False And e.Control = False And e.Shift = True And e.KeyCode = 71 Then
    '            Test = txtWord.SelectionStart
    '            txtWord.Text = txtWord.Text.Insert(txtWord.SelectionStart, "উ")
    '            e.SuppressKeyPress = True
    '            txtWord.SelectionStart = Test + 1
    '        End If
    '        If e.Alt = False And e.Control = False And e.Shift = True And e.KeyCode = 84 Then
    '            Test = txtWord.SelectionStart
    '            txtWord.Text = txtWord.Text.Insert(txtWord.SelectionStart, "ঊ")
    '            e.SuppressKeyPress = True
    '            txtWord.SelectionStart = Test + 1
    '        End If
    '        If e.Alt = False And e.Control = False And e.Shift = True And e.KeyCode = 90 Then
    '            Test = txtWord.SelectionStart
    '            txtWord.Text = txtWord.Text.Insert(txtWord.SelectionStart, "ঋ")
    '            e.SuppressKeyPress = True
    '            txtWord.SelectionStart = Test + 1
    '        End If
    '        If e.Alt = False And e.Control = False And e.Shift = True And e.KeyCode = 83 Then
    '            Test = txtWord.SelectionStart
    '            txtWord.Text = txtWord.Text.Insert(txtWord.SelectionStart, "এ")
    '            e.SuppressKeyPress = True
    '            txtWord.SelectionStart = Test + 1
    '        End If
    '        If e.Alt = False And e.Control = False And e.Shift = True And e.KeyCode = 87 Then
    '            Test = txtWord.SelectionStart
    '            txtWord.Text = txtWord.Text.Insert(txtWord.SelectionStart, "ঐ")
    '            e.SuppressKeyPress = True
    '            txtWord.SelectionStart = Test + 1
    '        End If
    '        If e.Alt = False And e.Control = False And e.Shift = True And e.KeyCode = 65 Then
    '            Test = txtWord.SelectionStart
    '            txtWord.Text = txtWord.Text.Insert(txtWord.SelectionStart, "ও")
    '            e.SuppressKeyPress = True
    '            txtWord.SelectionStart = Test + 1
    '        End If
    '        If e.Alt = False And e.Control = False And e.Shift = True And e.KeyCode = 81 Then
    '            Test = txtWord.SelectionStart
    '            txtWord.Text = txtWord.Text.Insert(txtWord.SelectionStart, "ঔ")
    '            e.SuppressKeyPress = True
    '            txtWord.SelectionStart = Test + 1
    '        End If
    '        If e.Alt = False And e.Control = False And e.Shift = False And e.KeyCode = 88 Then
    '            Test = txtWord.SelectionStart
    '            txtWord.Text = txtWord.Text.Insert(txtWord.SelectionStart, "ং")
    '            e.SuppressKeyPress = True
    '            txtWord.SelectionStart = Test + 1
    '        End If
    '        If e.Alt = False And e.Control = False And e.Shift = True And e.KeyCode = 88 Then
    '            Test = txtWord.SelectionStart
    '            txtWord.Text = txtWord.Text.Insert(txtWord.SelectionStart, "ঁ")
    '            e.SuppressKeyPress = True
    '            txtWord.SelectionStart = Test + 1
    '        End If
    '        If e.Alt = False And e.Control = False And e.Shift = True And e.KeyCode = 189 Then
    '            Test = txtWord.SelectionStart
    '            txtWord.Text = txtWord.Text.Insert(txtWord.SelectionStart, "ঃ")
    '            e.SuppressKeyPress = True
    '            txtWord.SelectionStart = Test + 1
    '        End If
    '        If e.Alt = False And e.Control = False And e.Shift = False And e.KeyCode = 68 Then
    '            Test = txtWord.SelectionStart
    '            txtWord.Text = txtWord.Text.Insert(txtWord.SelectionStart, "্")
    '            e.SuppressKeyPress = True
    '            txtWord.SelectionStart = Test + 1
    '        End If
    '        '=========================
    '        If e.Alt = False And e.Control = False And e.Shift = False And e.KeyCode = 69 Then
    '            Test = txtWord.SelectionStart
    '            txtWord.Text = txtWord.Text.Insert(txtWord.SelectionStart, "া")
    '            e.SuppressKeyPress = True
    '            txtWord.SelectionStart = Test + 1
    '        End If
    '        If e.Alt = False And e.Control = False And e.Shift = False And e.KeyCode = 70 Then
    '            Test = txtWord.SelectionStart
    '            txtWord.Text = txtWord.Text.Insert(txtWord.SelectionStart, "ি")
    '            e.SuppressKeyPress = True
    '            txtWord.SelectionStart = Test + 1
    '        End If
    '        If e.Alt = False And e.Control = False And e.Shift = False And e.KeyCode = 82 Then
    '            Test = txtWord.SelectionStart
    '            txtWord.Text = txtWord.Text.Insert(txtWord.SelectionStart, "ী")
    '            e.SuppressKeyPress = True
    '            txtWord.SelectionStart = Test + 1
    '        End If
    '        If e.Alt = False And e.Control = False And e.Shift = False And e.KeyCode = 71 Then
    '            Test = txtWord.SelectionStart
    '            txtWord.Text = txtWord.Text.Insert(txtWord.SelectionStart, "ু")
    '            e.SuppressKeyPress = True
    '            txtWord.SelectionStart = Test + 1
    '        End If
    '        If e.Alt = False And e.Control = False And e.Shift = False And e.KeyCode = 84 Then
    '            Test = txtWord.SelectionStart
    '            txtWord.Text = txtWord.Text.Insert(txtWord.SelectionStart, "ূ")
    '            e.SuppressKeyPress = True
    '            txtWord.SelectionStart = Test + 1
    '        End If
    '        If e.Alt = False And e.Control = False And e.Shift = False And e.KeyCode = 90 Then
    '            Test = txtWord.SelectionStart
    '            txtWord.Text = txtWord.Text.Insert(txtWord.SelectionStart, "ৃ")
    '            e.SuppressKeyPress = True
    '            txtWord.SelectionStart = Test + 1
    '        End If
    '        If e.Alt = False And e.Control = False And e.Shift = False And e.KeyCode = 83 Then
    '            Test = txtWord.SelectionStart
    '            txtWord.Text = txtWord.Text.Insert(txtWord.SelectionStart, "ে")
    '            e.SuppressKeyPress = True
    '            txtWord.SelectionStart = Test + 1
    '        End If
    '        If e.Alt = False And e.Control = False And e.Shift = False And e.KeyCode = 87 Then
    '            Test = txtWord.SelectionStart
    '            txtWord.Text = txtWord.Text.Insert(txtWord.SelectionStart, "ৈ")
    '            e.SuppressKeyPress = True
    '            txtWord.SelectionStart = Test + 1
    '        End If
    '        If e.Alt = False And e.Control = False And e.Shift = False And e.KeyCode = 65 Then
    '            Test = txtWord.SelectionStart
    '            txtWord.Text = txtWord.Text.Insert(txtWord.SelectionStart, "ো")
    '            e.SuppressKeyPress = True
    '            txtWord.SelectionStart = Test + 1
    '        End If
    '        If e.Alt = False And e.Control = False And e.Shift = False And e.KeyCode = 81 Then
    '            Test = txtWord.SelectionStart
    '            txtWord.Text = txtWord.Text.Insert(txtWord.SelectionStart, "ৌ")
    '            e.SuppressKeyPress = True
    '            txtWord.SelectionStart = Test + 1
    '        End If
    '        If e.Alt = False And e.Control = False And e.Shift = False And e.KeyCode = 192 Then
    '            Test = txtWord.SelectionStart
    '            txtWord.Text = txtWord.Text.Insert(txtWord.SelectionStart, "্য")
    '            e.SuppressKeyPress = True
    '            txtWord.SelectionStart = Test + 2
    '        End If
    '        If e.Alt = False And e.Control = False And e.Shift = True And e.KeyCode = 52 Then
    '            Test = txtWord.SelectionStart
    '            txtWord.Text = txtWord.Text.Insert(txtWord.SelectionStart, "ৰ্")
    '            e.SuppressKeyPress = True
    '            txtWord.SelectionStart = Test + 2
    '        End If
    '        If e.Alt = False And e.Control = False And e.Shift = True And e.KeyCode = 50 Then
    '            Test = txtWord.SelectionStart
    '            txtWord.Text = txtWord.Text.Insert(txtWord.SelectionStart, "’")
    '            e.SuppressKeyPress = True
    '            txtWord.SelectionStart = Test + 1
    '        End If
    '        If e.Alt = False And e.Control = False And e.Shift = True And e.KeyCode = 54 Then
    '            Test = txtWord.SelectionStart
    '            txtWord.Text = txtWord.Text.Insert(txtWord.SelectionStart, "ত্ৰ")
    '            e.SuppressKeyPress = True
    '            txtWord.SelectionStart = Test + 3
    '        End If
    '        If e.Alt = False And e.Control = False And e.Shift = True And e.KeyCode = 56 Then
    '            Test = txtWord.SelectionStart
    '            txtWord.Text = txtWord.Text.Insert(txtWord.SelectionStart, "জ্ঞ")
    '            e.SuppressKeyPress = True
    '            txtWord.SelectionStart = Test + 3
    '        End If
    '        If e.Alt = False And e.Control = False And e.Shift = True And e.KeyCode = 53 Then
    '            Test = txtWord.SelectionStart
    '            txtWord.Text = txtWord.Text.Insert(txtWord.SelectionStart, "প্ৰ")
    '            e.SuppressKeyPress = True
    '            txtWord.SelectionStart = Test + 3
    '        End If
    '        If e.Alt = False And e.Control = False And e.Shift = True And e.KeyCode = 51 Then
    '            Test = txtWord.SelectionStart
    '            txtWord.Text = txtWord.Text.Insert(txtWord.SelectionStart, "ক্ৰ")
    '            e.SuppressKeyPress = True
    '            txtWord.SelectionStart = Test + 3
    '        End If
    '        '==============================





    '        'If e.Alt = False And e.Control = False And e.Shift = True And e.KeyCode = 52 Then
    '        '    Test = txtWord.SelectionStart
    '        '    txtWord.Text = txtWord.Text.Insert(txtWord.SelectionStart, "গ্ৰ")
    '        '    e.SuppressKeyPress = True
    '        '    txtWord.SelectionStart = Test + 3
    '        'End If


    '        'Else
    '        '    If e.Alt = False And e.Control = False And e.Shift = False And e.KeyCode = 75 Then
    '        '        Test = txtWord.SelectionStart
    '        '        txtWord.Text = txtWord.Text.Insert(txtWord.SelectionStart, "ক")
    '        '        e.SuppressKeyPress = True
    '        '        txtWord.SelectionStart = Test + 1
    '        '    End If
    '        '    If e.Alt = False And e.Control = False And e.Shift = True And e.KeyCode = 72 Then
    '        '        Test = txtWord.SelectionStart
    '        '        txtWord.Text = txtWord.Text.Insert(txtWord.SelectionStart, "খ")
    '        '        e.SuppressKeyPress = False
    '        '        txtWord.SelectionStart = Test + 1
    '        '    End If
    '    End If

    'End Sub

    'Public Sub AddElementToStringArray(ByVal stringToAdd As String)
    '    ReDim Preserve myStrings(myStringElements)
    '    myStrings(myStringElements) = stringToAdd
    '    myStringElements += 1
    'End Sub

    'Private Sub Button9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button9.Click
    '    'Dim dtMainTable As DataTable = New DataTable

    '    'Dim cmd As New OleDbCommand("SELECT * FROM MainTable", objConn)
    '    'Dim rs As OleDbDataReader = cmd.ExecuteReader
    '    'If rs.HasRows Then
    '    '    dtMainTable.Load(rs)
    '    'End If
    '    'rs.Close()
    '    'For i As Integer = 0 To 2000 'dtMainTable.Rows.Count - 1
    '    '    Dim id As Integer = dtMainTable.Rows(i).Item("ID")
    '    '    Dim mainWord As String = IIf(IsDBNull(dtMainTable.Rows(i).Item("MyWord")), "", dtMainTable.Rows(i).Item("MyWord"))
    '    '    If mainWord <> "" Then
    '    '        mainWord = Encrypt(mainWord, strEncodeString)
    '    '    End If
    '    '    Dim AsMeaning As String = IIf(IsDBNull(dtMainTable.Rows(i).Item("AsMeaning_old")), "", dtMainTable.Rows(i).Item("AsMeaning_old")) & " "
    '    '    If AsMeaning <> "" Then
    '    '        AsMeaning = Encrypt(AsMeaning, strEncodeString)
    '    '    End If
    '    '    Dim d As String = Decrypt(AsMeaning, strEncodeString)

    '    '    Dim EngMeaning As String = IIf(IsDBNull(dtMainTable.Rows(i).Item("EngMeaning_old")), "", dtMainTable.Rows(i).Item("EngMeaning_old"))
    '    '    If EngMeaning <> "" Then
    '    '        EngMeaning = Encrypt(EngMeaning, strEncodeString)
    '    '    End If
    '    '    Dim Antonyms As String = IIf(IsDBNull(dtMainTable.Rows(i).Item("Antonyms_old")), "", dtMainTable.Rows(i).Item("Antonyms_old"))
    '    '    If Antonyms <> "" Then
    '    '        Antonyms = Encrypt(Antonyms, strEncodeString)
    '    '    End If
    '    '    Dim Synonyms As String = IIf(IsDBNull(dtMainTable.Rows(i).Item("Synonyms_old")), "", dtMainTable.Rows(i).Item("Synonyms_old"))
    '    '    If Synonyms <> "" Then
    '    '        Synonyms = Encrypt(Synonyms, strEncodeString)
    '    '    End If
    '    '    'Dim cmd1 As New OleDbCommand("UPDATE MainTable SET Antonyms='" & Antonyms & "', Synonyms='" & _
    '    '    '                             Synonyms & "' WHERE ID=" & id, objConn)

    '    '    Dim cmd1 As New OleDbCommand("UPDATE MainTable SET newword='" & mainWord & "',AsMeaning='" & AsMeaning & "', EngMeaning='" & _
    '    '                                 EngMeaning & "', Antonyms='" & Antonyms & "', Synonyms='" & _
    '    '                                 Synonyms & "' WHERE ID=" & id, objConn)
    '    '    cmd1.ExecuteNonQuery()

    '    '    'Button9.Text = id
    '    '    btnClear.Text = i
    '    '    btnClear.Refresh()
    '    'Next

    '    ' '===== set the limit to update the table=======================================
    '    'Dim lowerID As Integer = 5000
    '    'Dim upperID As Integer = 5100

    '    'Dim newword As String = ""
    '    'Dim AsMeaning As String = ""
    '    'Dim EngMeaning As String = ""
    '    'Dim Antonyms As String = ""
    '    'Dim Synonyms As String = ""
    '    'Dim id As Integer = 0
    '    'Try
    '    '    Dim cmd As New OleDbCommand("SELECT ID, MyWord,AsMeaning_old, EngMeaning_old,Antonyms_old,Synonyms_old " & _
    '    '                                "FROM MainTable WHERE ID>=" & lowerID & " AND ID<=" & upperID & " ORDER BY ID", objConn)
    '    '    Dim rs1 As OleDbDataReader = cmd.ExecuteReader
    '    '    If rs1.HasRows Then
    '    '        Do While rs1.Read
    '    '            'id = 0
    '    '            'newword = ""
    '    '            'AsMeaning = ""
    '    '            'EngMeaning = ""
    '    '            'Antonyms = ""
    '    '            'Synonyms = ""

    '    '            id = IIf(IsDBNull(rs1("ID")), 0, rs1("ID"))
    '    '            newword = IIf(IsDBNull(rs1("MyWord")), "", rs1("MyWord"))
    '    '            If newword <> "" Then
    '    '                newword = Encrypt(newword, strEncodeString)
    '    '            End If
    '    '            AsMeaning = IIf(IsDBNull(rs1("AsMeaning_old")), "", rs1("AsMeaning_old"))
    '    '            If AsMeaning <> "" Then
    '    '                AsMeaning = Encrypt(AsMeaning, strEncodeString)
    '    '            End If
    '    '            EngMeaning = IIf(IsDBNull(rs1("EngMeaning_old")), "", rs1("EngMeaning_old"))
    '    '            If EngMeaning <> "" Then
    '    '                EngMeaning = Encrypt(EngMeaning, strEncodeString)
    '    '            End If
    '    '            Antonyms = IIf(IsDBNull(rs1("Antonyms_old")), "", rs1("Antonyms_old"))
    '    '            If Antonyms <> "" Then
    '    '                Antonyms = Encrypt(Antonyms, strEncodeString)
    '    '            End If
    '    '            Synonyms = IIf(IsDBNull(rs1("Synonyms_old")), "", rs1("Synonyms_old"))
    '    '            If Synonyms <> "" Then
    '    '                Synonyms = Encrypt(Synonyms, strEncodeString)
    '    '            End If
    '    '            'Dim cmd1 As New OleDbCommand("UPDATE MainTable SET Antonyms='" & Antonyms & "', Synonyms='" & _
    '    '            '                             Synonyms & "' WHERE ID=" & id, objConn)

    '    '            Dim cmd1 As New OleDbCommand("UPDATE MainTable SET newword='" & newword & "',AsMeaning='" & AsMeaning & "', EngMeaning='" & _
    '    '                                 EngMeaning & "', Antonyms='" & Antonyms & "', Synonyms='" & _
    '    '                                Synonyms & "' WHERE ID=" & id, objConn)
    '    '            Button9.Text = id
    '    '            Button9.Refresh()
    '    '        Loop
    '    '        rs1.Close()

    '    '    End If
    '    'Catch ex As Exception
    '    '    MsgBox(ex.Message)
    '    '    MsgBox("Error in loading the data.", MsgBoxStyle.Critical, "Error")
    '    'End Try
    '    '''''''=============================================================



    '    'Dim lowerID As Integer = 43921
    '    'Dim upperID As Integer = 70000

    '    'Try
    '    '    Dim cmd As New OleDbCommand("SELECT ID, Myword, AsMeaning, EngMeaning,Antonyms,Synonyms " & _
    '    '                                "FROM MainTable WHERE ID>=" & lowerID & " AND ID<=" & upperID & " ORDER BY ID", objConn)
    '    '    Dim rs1 As OleDbDataReader = cmd.ExecuteReader
    '    '    If rs1.HasRows Then
    '    '        Do While rs1.Read
    '    '            Dim id As Integer = rs1("ID")
    '    '            Dim myWord As String = IIf(IsDBNull(rs1("MyWord")), "", rs1("MyWOrd"))
    '    '            Dim AsMeaning As String = IIf(IsDBNull(rs1("AsMeaning")), "", rs1("AsMeaning")) & " "
    '    '            Dim EngMeaning As String = IIf(IsDBNull(rs1("EngMeaning")), "", rs1("EngMeaning"))
    '    '            Dim Antonyms As String = IIf(IsDBNull(rs1("Antonyms")), "", rs1("Antonyms"))
    '    '            Dim Synonyms As String = IIf(IsDBNull(rs1("Synonyms")), "", rs1("Synonyms"))
    '    '            Dim cmd1 As New OleDbCommand("INSERT INTO NewTable (ID,Myword,AsMeaning,EngMeaning,Antonyms,Synonyms) " & _
    '    '            " VALUES(" & id & ",'" & myWord & "','" & AsMeaning & "','" & EngMeaning & "','" & _
    '    '             Antonyms & "','" & Synonyms & "')", objConn)

    '    '            cmd1.ExecuteNonQuery()
    '    '            Button9.Text = id
    '    '        Loop
    '    '        rs1.Close()

    '    '    End If
    '    'Catch ex As Exception
    '    '    MsgBox(ex.Message)
    '    '    MsgBox("Error in loading the data.", MsgBoxStyle.Critical, "Error")
    '    'End Try

    '    ''''================================ encrypt word character by character =====================================
    '    'Dim lID As Integer = 1001
    '    'Dim uID As Integer = 2006

    '    'Try
    '    '    Dim cmd As New OleDbCommand("SELECT ID, MyWord_old FROM MainTable WHERE ID>=" & lID & " AND ID<=" & uID & " ORDER BY ID", objConn)
    '    '    Dim rs1 As OleDbDataReader = cmd.ExecuteReader
    '    '    If rs1.HasRows Then
    '    '        Do While rs1.Read
    '    '            Dim id As Integer = rs1("ID")
    '    '            Dim myWord As String = IIf(IsDBNull(rs1("MyWord_old")), "", rs1("MyWord_old"))
    '    '            Dim encyptedWord As String = EachCharacterEncrypt(myWord, strEncodeString)
    '    '            'For i As Integer = 0 To myWord.Length - 1
    '    '            '    encyptedWord = encyptedWord & Encrypt(myWord.Substring(i, 1), strEncodeString)
    '    '            'Next
    '    '            Dim cmd1 As New OleDbCommand("UPDATE MainTable SET MyWord='" & encyptedWord & "' WHERE ID=" & id, objConn)
    '    '            cmd1.ExecuteNonQuery()
    '    '        Loop
    '    '        rs1.Close()
    '    '    End If
    '    'Catch ex As Exception
    '    '    MsgBox(ex.Message)
    '    'MsgBox("Error in loading the data.", MsgBoxStyle.Critical, "Error")
    '    'End Try

    '    ' ''====Encrypt English Table=====================
    '    'Dim lowr As Integer = 10001
    '    'Dim uppr As Integer = 20000
    '    'Try
    '    '    Dim cmd As New OleDbCommand("SELECT ID,EngAsMeaning_old FROM EnglishWords WHERE  ID>=" & lowr & " AND ID<=" & uppr & " ORDER BY ID", objConn)
    '    '    Dim rs1 As OleDbDataReader = cmd.ExecuteReader
    '    '    If rs1.HasRows Then
    '    '        Do While rs1.Read
    '    '            Dim id As Integer = rs1("ID")
    '    '            'Dim myWord As String = IIf(IsDBNull(rs1("EngWord_old")), "", rs1("EngWord_old"))
    '    '            'Dim encyptedWord As String = EachCharacterEncrypt(myWord, strEncodeString)
    '    '            Dim AsMeaning As String = IIf(IsDBNull(rs1("EngAsMeaning_old")), "", rs1("EngAsMeaning_old"))
    '    '            If AsMeaning <> "" Then
    '    '                AsMeaning = Encrypt(AsMeaning, "s3e3df5")
    '    '            End If
    '    '            Dim cmd1 As New OleDbCommand("UPDATE EnglishWords SET  EngAsMeaning='" & AsMeaning & "' WHERE ID=" & id, objConn)
    '    '            cmd1.ExecuteNonQuery()
    '    '        Loop
    '    '        rs1.Close()

    '    '    End If
    '    'Catch ex As Exception
    '    '    MsgBox(ex.Message)
    '    'End Try

    '    MsgBox("Done", MsgBoxStyle.Critical)
    'End Sub


    'Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
    '    Me.Close()
    'End Sub

    'Private Sub Button10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button10.Click
    '    'Dim strSelect As String = "SELECT * FROM MainTable" ' WHERE left(MyWord, " & Len(myval) & ")= '" & myval & "'"
    '    'Dim dscmd As New OleDbDataAdapter(strSelect, objConn)

    '    ' '' Load a data set.
    '    'Dim ds As New DataSet()
    '    ''dscmd.Fill(ds, "AllWords")



    '    ''Do something with the data set.
    '    'Dim myDataTable As DataTable = ds.Tables.Item("AllWords")
    '    ''dt.Select("MyWord LIKE '" & myval & "'")


    '    '' ''myDataTable.DefaultView.RowFilter = String.Format("[Name] LIKE '{0}%' AND [Date] > #{1:M/dd/yyyy}#",
    '    '' ''                                          nameTextBox.Text,
    '    '' ''                                          datePicker.Value)

    '    'myDataTable.DefaultView.RowFilter = String.Format("left(MyWord, " & Len(myval) & ")= '" & myval & "'")
    'End Sub


    'Private Sub btnBack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBack.Click

    '    'If isLastIndex = True Then
    '    '    wordSelect = 1
    '    '    Exit Sub
    '    'End If
    '    If storeWord.Count = 0 Then
    '        Exit Sub
    '    ElseIf storeWord.Count > 0 Then
    '        Dim s As String = lblDictword.Text.Trim
    '        storedPrevWord.Add(lblDictword.Text.Trim)
    '    End If

    '    Try
    '        If wordSelect = 0 Then
    '            ' '''word select 0 means last action was MOUSE CLICK IN MEANING BOX
    '            Dim x As Integer = storeWord.Count
    '            If IsUnicode(storeWord.Item(x - 1)) Then
    '                rbtnAssamese.Checked = True
    '            Else
    '                rbtnEnglish.Checked = True
    '            End If

    '            txtWord.Text = storeWord.Item(x - 1)
    '            If x > 0 Then
    '                lastSelectIndex = x - 1
    '            End If
    '            If lastSelectIndex = 0 Then
    '                'isLastIndex = True
    '                'isLastPreviosIndex = False
    '                Exit Sub
    '            End If
    '        ElseIf wordSelect = 1 Then

    '            '''''word select 1 means last action was BACK BUTTON CLICK 
    '            If lastSelectIndex > 0 Then
    '                If IsUnicode(storeWord.Item(lastSelectIndex - 1)) Then
    '                    rbtnAssamese.Checked = True
    '                Else
    '                    rbtnEnglish.Checked = True
    '                End If
    '                txtWord.Text = storeWord.Item(lastSelectIndex - 1)
    '            End If
    '            If lastSelectIndex > 0 Then
    '                lastSelectIndex = lastSelectIndex - 1
    '            End If
    '            If lastSelectIndex = 0 Then
    '                isLastIndex = True
    '                isLastPreviosIndex = False
    '                Exit Sub
    '            End If
    '        ElseIf wordSelect = 2 Then
    '            ''''  word select 3 means last action is LISTBOX INDEX CHANGE

    '            'Dim x As Integer = storeWord.Count
    '            'If IsUnicode(storeWord.Item(x - 1)) Then
    '            '    rbtnAssamese.Checked = True
    '            'Else
    '            '    rbtnEnglish.Checked = True
    '            'End If

    '            'txtWord.Text = storeWord.Item(x - 1)
    '            'If x <> 0 Then
    '            '    lastSelectIndex = x - 1
    '            'End If
    '        ElseIf wordSelect = 3 Then
    '            ''''  word select 3 means last action is LISTBOX INDEX CHANGE

    '            Dim x As Integer = storeWord.Count
    '            If IsUnicode(storeWord.Item(x - 1)) Then
    '                rbtnAssamese.Checked = True
    '            Else
    '                rbtnEnglish.Checked = True
    '            End If

    '            txtWord.Text = storeWord.Item(x - 1)
    '            If x <> 0 Then
    '                lastSelectIndex = x - 1
    '            End If
    '            If lastSelectIndex = 0 Then
    '                'isLastIndex = True
    '                'isLastPreviosIndex = False
    '                Exit Sub
    '            End If
    '        End If
    '    Catch ex As Exception
    '        Exit Sub
    '    End Try
    '    wordSelect = 1
    'End Sub

    'Private Sub btnForward_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnForward.Click

    '    Dim word As String = lblDictword.Text.ToString.Trim
    '    If storedPrevWord.Count = 0 Then
    '        wordSelect = 3
    '        Exit Sub
    '    End If
    '    If isLastPreviosIndex = True Then
    '        wordSelect = 3
    '        Exit Sub
    '    End If
    '    wordSelect = 3
    '    Try
    '        ''''''  flag should be there to dectect the BACK BUTTON Click and PREV-BUTTON CLICK...............

    '        Dim x As Integer = storedPrevWord.Count
    '        If IsUnicode(storedPrevWord.Item(x - 1)) Then
    '            rbtnAssamese.Checked = True
    '        Else
    '            rbtnEnglish.Checked = True
    '        End If

    '        txtWord.Text = storedPrevWord.Item(x - 1)
    '        If x <> 0 Then
    '            prevSelectIndex = x - 1
    '        End If
    '        If prevSelectIndex = 0 Then
    '            isLastPreviosIndex = True
    '            isLastIndex = False
    '            Exit Sub
    '        End If
    '    Catch ex As Exception
    '        Exit Sub
    '    End Try
    '    storeWord.Add(word)


    'End Sub

    'Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click
    '    If lblDictword.Text <> "" Then
    '        Clipboard.SetText(lblDictword.Text.Trim)
    '    End If
    'End Sub



    'Private Sub txtAMean_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtAMean.TextChanged

    'End Sub
    Private Sub rbtnAssamese_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtnAssamese.CheckedChanged
        lvWords.Items.Clear()
        txtAMean.Text = ""
        lblProbableWords.Visible = True
        Me.lvWords.Size = New System.Drawing.Size(204, 322)
        If rbtnAssamese.Checked = True Then
            isLinkedWord = False
            lvWords.Font = New System.Drawing.Font("Asomiya_Rohini", 16.25!, FontStyle.Regular, GraphicsUnit.Point, CType(0, Byte))
            lvProbableWord.Font = New System.Drawing.Font("Asomiya_Rohini", 16.25!, FontStyle.Regular, GraphicsUnit.Point, CType(0, Byte))

            txtWord.Text = ""
            txtWord.Font = New System.Drawing.Font("Asomiya_Rohini", 14.25!, FontStyle.Regular, GraphicsUnit.Point, CType(0, Byte))
            txtWord.Focus()
            lvWords.Visible = True
            lvProbableWord.Visible = True
            txtAMean.Font = New System.Drawing.Font("Asomiya_Rohini", 16.0!, FontStyle.Regular, GraphicsUnit.Point, CType(0, Byte))

        Else
            'If isLinkedWord = False Then
            '    txtWord.Text = ""

            'End If
            txtWord.Text = ""
            txtWord.Font = New System.Drawing.Font("Times New Roman", 17.0!, FontStyle.Regular, GraphicsUnit.Point, CType(0, Byte))
            txtWord.ReadOnly = False
            txtWord.Focus()
            lvProbableWord.Visible = False
        End If
    End Sub

    Function ShowEngWords(ByVal myval As String, Optional ByVal track As Integer = 0) As Boolean
        Dim xMyval As String = ""
        If track = 0 Then
            Try
                xMyval = " left(EngWord_Ch, " & Len(myval) & ")= '" & myval.Substring(0, myval.Length) & "'"
                lvWords.Items.Clear()
                If myval = "" Then
                    Exit Function
                End If
                myval = xMyval
                Dim myStr As String = Nothing
                myStr = "SELECT TOP 20 ID, EngWord FROM EnglishWords WHERE " & myval & " ORDER BY ID, EngWord, LEN(EngWord) ASC"
                Dim objCmd As New OleDbCommand(myStr, objConn)
                Dim rs As OleDbDataReader = objCmd.ExecuteReader
                If rs.HasRows Then
                    Dim xItem As ListViewItem
                    Do While rs.Read
                        Dim xWord As String = IIf(IsDBNull(rs("EngWord")), "", rs("EngWord"))
                        Dim xdecrypt As String = Decrypt(xWord, strEncodeString)
                        xItem = lvWords.Items.Add(rs("ID"), xdecrypt, "")
                    Loop
                End If
            Catch ex As Exception
                'MsgBox(ex.Message)
                'MsgBox("Error in loading the data.", MsgBoxStyle.Critical, "Error")
                Return False
            End Try
        End If
        Return True
    End Function

    Private Sub frmWordSearch_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Dim dtTabel As DataTable = New DataTable
        'Dim cmd1 As New OleDbCommand("SELECT * FROM MainTable", objConn)
        'Dim rs1 As OleDbDataReader = cmd1.ExecuteReader
        'If rs1.HasRows Then
        '    dtTabel.Load(rs1)

        'End If


        'MsgBox(Application.StartupPath.ToString, MsgBoxStyle.OkOnly, "Application Directory is")
        lvProbableWord.Visible = True
        getConn()
        txtWord.Focus()
        Me.Size = New System.Drawing.Size(900, 663)


        Try
            If IsRegistered = False Then
                GroupBox4.Enabled = False
                Dim count As Integer = 0
                Dim cmd As New OleDbCommand("SELECT COUNT(MyWord) AS Total FROM MainTable", objConn)
                Dim rs As OleDbDataReader = cmd.ExecuteReader
                If rs.HasRows Then
                    rs.Read()
                    count = IIf(IsDBNull(rs("Total")), 0, rs("Total"))
                End If
                If count > 4000 Then
                    GroupBox4.Enabled = False
                    lvWords.Enabled = False
                End If
            End If
        Catch ex As Exception
            Exit Sub
        End Try

    End Sub

    Protected Sub composeQueryStr(ByVal inputTxt As String, ByVal cmdTxt As String)
        If txtWord.Text.Trim.Length > 100 Then Exit Sub
        If rbtnAssamese.Checked = False Then
            MsgBox("Please select the Assamese option.", MsgBoxStyle.Critical)
            txtWord.Focus()
            Exit Sub
        End If
        If inputTxt.Length > 0 Then
            txtWord.Text = inputTxt & cmdTxt
        Else
            txtWord.Text = cmdTxt
        End If
    End Sub

    Function ShowWords(ByRef Mybox As ListView, ByVal myval As String, Optional ByVal track As Integer = 0) As Boolean
        'Dim FirstID As Integer = 0

        Dim xMyval As String = ""
        If track = 0 Then
            Try

                xMyval = " left(MyWord_Ch, " & Len(myval) & ")= '" & myval.Substring(0, myval.Length) & "'"
                txtAMean.Clear()
                If myval = "" Then
                    Exit Function
                End If
                myval = xMyval
                Dim myStr As String = Nothing
                myStr = "SELECT TOP 12 ID, MyWord FROM MainTable WHERE " & myval & " ORDER BY ID, MyWOrd , LEN(MyWord) ASC"
                Dim objCmd As New OleDbCommand(myStr, objConn)
                Dim rs As OleDbDataReader = objCmd.ExecuteReader
                If rs.HasRows Then
                    Dim xItem As ListViewItem
                    Do While rs.Read
                        'If FirstID = 0 Then
                        '    FirstID = IIf(IsDBNull(rs("ID")), 0, rs("ID"))
                        'End If
                        Dim myword As String = IIf(IsDBNull(rs("MyWord")), "", rs("MyWord"))
                        Dim decodedtext As String = Decrypt(myword, strEncodeString)
                        xItem = Mybox.Items.Add(rs("ID"), decodedtext, "")
                    Loop
                Else
                    ShowWords = False
                    Exit Function
                End If
            Catch ex As Exception
                'MsgBox(ex.Message)
                'MsgBox("Error in loading the data.", MsgBoxStyle.Critical, "Error")
                ShowWords = False
                Exit Function
            End Try
        ElseIf track = True Then
            ShowWords = track
            Exit Function
        End If
        ShowWords = True
    End Function


    Private Sub rbtnEnglish_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtnEnglish.CheckedChanged
        If rbtnEnglish.Checked = True Then
            lvWords.Items.Clear()
            Me.lvWords.Size = New System.Drawing.Size(204, 559)
            lblProbableWords.Visible = False
            lblDictword.Text = ""
            txtWord.Font = New System.Drawing.Font("Times New Roman", 16.3!, FontStyle.Regular, GraphicsUnit.Point, CType(0, Byte))
            lvWords.Font = New System.Drawing.Font("Times New Roman", 17.0!, FontStyle.Regular, GraphicsUnit.Point, CType(0, Byte))
            If txtWord.Text = "" Then Exit Sub
            If Not ShowEngWords(Trim(txtWord.Text), 0) Then
                Exit Sub
            End If
        Else
            'Me.lvWords.Size = New System.Drawing.Size(487, 150)
            'Me.lvWords.Columns(0).Width = 250
        End If
    End Sub

    Private Sub Command5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If txtWord.Text = "" Then Exit Sub
        composeQueryStr(txtWord.Text, " ")
    End Sub

    Private Sub PossibleWord(ByVal sword As String)
        Dim mword As String
        Dim xword As Object
        Dim yword As Object
        Dim a As Integer
        Dim b As Integer = 0

        sword = eachCharDecrept(sword, strEncodeString)

        xword = New String() {"তত্ব", "ক", "কঁ", "উ", "ও", "ই", "অঁ", "অ", "অ", "আ", "আঁ", "ঈ", "নি", "নিঃস", "নী", "ত্র", "ট্র", "-", " ", "ছ", "চ", "চ্ছ্ব", "জ্ব", "জ্জ্ব", "জ", "ঞ্ছ", "ঞ্চ", "ত", "ট", "ত্ত", "ত্ত্ব", "ত্ব", "থ", "ঠ", "দ", "ড", "দ্দ", "ড্ড", "দ্র", "ড্র", "ধ", "ঢ", "ণ", "ন", "ন্ত", "ণ্ট", "ণ্ণ", "ন্ন", "পঁ", "প", "ফঁ", "ফ", "প্ত", "প্ট", "ম্ম", "ন্ম", "জ", "য", "ৰূ", "ৰু", "ৱ", "ব", "স", "শ", "শ্চ", "শ্ছ", "ওত", "ণু", "দু", "দুঃখ", "দুঃস্ব", "খূ", "খু", "ঘূ", "ঘু", "ছু", "পঁ", "প", "ফ", "ফঁ"}
        yword = New String() {"তত্ত্ব", "কঁ", "ক", "ও", "উ", "ঈ", "অ", "অঁ", "অ’", "আঁ", "আ", "ই", "নিঃ", "নিস", "নি", "ট্র", "ত্র", " ", "-", "চ", "ছ", "চ্ছ", "জ", "জ্ব", "ঝ", "ঞ্চ", "ঞ্ছ", "ট", "ত", "ট্ট", "ত্ব", "ত্ত্ব", "ঠ", "থ", "ড", "দ", "ড্ড", "দ্দ", "ড্র", "দ্র", "ঢ", "ধ", "ন", "ণ", "ণ্ট", "ন্ত", "ন্ন", "ণ্ণ", "প", "পঁ", "ফ", "ফঁ", "প্ট", "প্ত", "ন্ম", "ম্ম", "য", "জ", "ৰু", "ৰূ", "ব", "ৱ", "শ", "স", "শ্ছ", "শ্চ", "ওতঃ", "নু", "দুঃ", "দুখ", "দুস্ব", "খু", "খূ", "ঘু", "ঘূ", "চু", "প", "পঁ", "ফ", "ফঁ"}

        mword = ""
        For a = 0 To UBound(xword)
            b = InStr(1, sword, xword(a))
            If b > 0 Then
                mword = Replace(sword, xword(a), yword(a))
                Exit For
            End If
        Next
        If mword <> "" Then
            Dim xCharacterEncrypted As String = EachCharacterEncrypt(mword, strEncodeString)
            'For i As Integer = 0 To mword.Length - 1
            '    Dim eccodedText As String = mword.Substring(i, 1)
            '    If eccodedText <> "" Then
            '        xCharacterEncrypted = xCharacterEncrypted & Encrypt(eccodedText, strEncodeString)
            '    End If
            'Next
            ShowWords(lvProbableWord, Replace(xCharacterEncrypted, "'", "39"), 0)


            ' ShowWords(lvProbableWord, Replace(mword, "'", "39"), 0)
        Else
            lvProbableWord.Items.Clear()
        End If
    End Sub

    Private Sub lbProbAssameseWords_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        btnClear.Focus()
    End Sub

    Private Sub btnClose_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        btnClear.Focus()
    End Sub

    Private Sub gvComposit_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)
        If rbtnAssamese.Checked = False Then
            MsgBox("Plese select the Assamese option first.", MsgBoxStyle.Information, "Dictionary")
            Exit Sub
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If txtWord.Text = "" Then Exit Sub
        composeQueryStr(txtWord.Text, " ")
    End Sub

    Private Sub gvCons_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)
        If rbtnAssamese.Checked = False Then
            MsgBox("Plese select the Assamese option first.", MsgBoxStyle.Critical)
            Exit Sub
        End If
    End Sub

    Private Sub gvVowel_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)
        If rbtnAssamese.Checked = False Then
            MsgBox("Plese select the Assamese option first.", MsgBoxStyle.Critical)
            Exit Sub
        End If
    End Sub

    Private Sub gvData_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)
        If rbtnAssamese.Checked = False Then
            MsgBox("Plese select the Assamese option first.", MsgBoxStyle.Critical)
            Exit Sub
        End If
    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        txtAMean.Text = ""
        lvWords.Items.Clear()
        lvProbableWord.Items.Clear()
        If rbtnAssamese.Checked = True Then
            lvWords.Items.Clear()
            lvProbableWord.Items.Clear()
            If txtWord.Text.Length = 0 Then
                Exit Sub
            End If
            txtWord.Text = LSet(txtWord.Text, Len(txtWord.Text) - 1)
            lvProbableWord.Items.Clear()
            Dim encyptText As String = Encrypt(txtWord.Text, strEncodeString)
            PossibleWord(encyptText.Trim)
            ShowWords(lvWords, encyptText, 0)
        Else
            rbtnEnglish.Checked = True
            lvWords.Items.Clear()
            lvProbableWord.Items.Clear()
            lvWords.Refresh()
            txtWord.Text = LSet(txtWord.Text, Len(txtWord.Text) - 1)
        End If
        'FirstRowSelect()
    End Sub

    Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click
        If txtWord.Text.Trim.Length = 0 Then
            txtWord.Focus()
            Exit Sub
        End If
        txtWord.Text = ""
        lvWords.Items.Clear()
        lvProbableWord.Items.Clear()
        imgRetrieve.Image = Nothing
        txtAMean.Text = ""
        lblDictword.Text = ""
        txtWord.Focus()
    End Sub

    Private Sub Command5_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Command5.Click
        If rbtnAssamese.Checked = False Then
            txtWord.Focus()
            Exit Sub
        End If
        If txtWord.Text = "" Then Exit Sub
        composeQueryStr(txtWord.Text, " ")
    End Sub

    Private Sub SendLetter(ByVal Letter As String)
        If rbtnAssamese.Checked = False Then
            MsgBox("Please select the Assamese option first.", MsgBoxStyle.Information, "Dictionary")
            txtWord.Focus()
            Exit Sub
        End If
        composeQueryStr(txtWord.Text, Letter)
    End Sub

    Private Sub cmd1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd1.Click
        SendLetter(cmd1.Text)
    End Sub

    Private Sub cmd2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd2.Click
        SendLetter(cmd2.Text)
    End Sub

    Private Sub cmd3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd3.Click
        SendLetter(cmd3.Text)
    End Sub

    Private Sub cmd4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd4.Click
        SendLetter(cmd4.Text)
    End Sub

    Private Sub cmd5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd5.Click
        SendLetter(cmd5.Text)
    End Sub

    Private Sub cmd6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd6.Click
        SendLetter(cmd6.Text)
    End Sub

    Private Sub cmd7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd7.Click
        SendLetter(cmd7.Text)
    End Sub

    Private Sub cmd8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd8.Click
        SendLetter(cmd8.Text)
    End Sub

    Private Sub cmd9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd9.Click
        SendLetter(cmd9.Text)
    End Sub

    Private Sub cmd10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd10.Click
        SendLetter(cmd10.Text)
    End Sub

    Private Sub cmd11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd11.Click
        SendLetter(cmd11.Text)
    End Sub

    Private Sub cmd12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd12.Click
        SendLetter(cmd12.Text)
    End Sub

    Private Sub cmd13_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd13.Click
        SendLetter(cmd13.Text)
    End Sub

    Private Sub cmd14_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd14.Click
        SendLetter(cmd14.Text)
    End Sub

    Private Sub cmd15_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd15.Click
        SendLetter(cmd15.Text)
    End Sub

    Private Sub cmd16_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd16.Click
        SendLetter(cmd16.Text)
    End Sub

    Private Sub cmd17_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd17.Click
        SendLetter(cmd17.Text)
    End Sub

    Private Sub cmd18_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd18.Click
        SendLetter(cmd18.Text)
    End Sub

    Private Sub cmd19_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd19.Click
        SendLetter(cmd19.Text)
    End Sub

    Private Sub cmd20_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd20.Click
        SendLetter(cmd20.Text)
    End Sub

    Private Sub cmd21_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd21.Click
        SendLetter(cmd21.Text)
    End Sub

    Private Sub cmd22_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd22.Click
        SendLetter(cmd22.Text)
    End Sub

    Private Sub cmd23_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd23.Click
        SendLetter(cmd23.Text)
    End Sub

    Private Sub cmd24_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd24.Click
        SendLetter(cmd24.Text)
    End Sub

    Private Sub cmd25_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd25.Click
        SendLetter(cmd25.Text)
    End Sub

    Private Sub cmd26_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd26.Click
        SendLetter(cmd26.Text)
    End Sub

    Private Sub cmd27_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd27.Click
        SendLetter(cmd27.Text)
    End Sub

    Private Sub cmd28_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd28.Click
        SendLetter(cmd28.Text)
    End Sub

    Private Sub cmd29_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd29.Click
        SendLetter(cmd29.Text)
    End Sub

    Private Sub cmd30_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd30.Click
        SendLetter(cmd30.Text)
    End Sub

    Private Sub cmd31_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd31.Click
        SendLetter(cmd31.Text)
    End Sub

    Private Sub cmd32_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd32.Click
        SendLetter(cmd32.Text)
    End Sub

    Private Sub cmd33_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd33.Click
        SendLetter(cmd33.Text)
    End Sub

    Private Sub cmd34_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd34.Click
        SendLetter(cmd34.Text)
    End Sub

    Private Sub cmd35_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd35.Click
        SendLetter(cmd35.Text)
    End Sub

    Private Sub cmd36_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd36.Click
        SendLetter(cmd36.Text)
    End Sub

    Private Sub cmd37_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd37.Click
        SendLetter(cmd37.Text)
    End Sub

    Private Sub cmd38_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd38.Click
        SendLetter(cmd38.Text)
    End Sub

    Private Sub cmd39_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd39.Click
        SendLetter(cmd39.Text)
    End Sub

    Private Sub cmd40_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd40.Click
        SendLetter(cmd40.Text)
    End Sub

    Private Sub cmd41_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd41.Click
        SendLetter(cmd41.Text)
    End Sub

    Private Sub cmd42_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd42.Click
        SendLetter(cmd42.Text)
    End Sub

    Private Sub cmd43_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd43.Click
        SendLetter(cmd43.Text)
    End Sub

    Private Sub cmd44_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd44.Click
        SendLetter(cmd44.Text)
    End Sub

    Private Sub cmd45_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd45.Click
        SendLetter(cmd45.Text)
    End Sub

    Private Sub cmd46_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd46.Click
        SendLetter(cmd46.Text)
    End Sub

    Private Sub cmd47_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd47.Click
        SendLetter(cmd47.Text)
    End Sub

    Private Sub cmd48_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd48.Click
        SendLetter(cmd48.Text)
    End Sub

    Private Sub cmd49_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd49.Click
        SendLetter(cmd49.Text)
    End Sub

    Private Sub cmd50_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd50.Click
        SendLetter("ং")
    End Sub

    Private Sub cmd51_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd51.Click
        SendLetter("ঃ")
    End Sub

    Private Sub cmd52_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        SendLetter(cmd52.Text)
    End Sub

    Private Sub cmd52_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd52.Click
        SendLetter("ঁ")
    End Sub

    Private Sub cmd53_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd53.Click
        SendLetter("’")
    End Sub

    Private Sub cmd54_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd54.Click
        SendLetter("া")
    End Sub

    Private Sub cmd55_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd55.Click
        SendLetter("ি")
    End Sub

    Private Sub cmd56_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd56.Click
        SendLetter("ী")
    End Sub

    Private Sub cmd65_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd65.Click
        SendLetter("ু")
    End Sub

    Private Sub cmd57_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd57.Click
        SendLetter("ূ")
    End Sub

    Private Sub cmd58_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd58.Click
        SendLetter("ৃ")
    End Sub

    Private Sub cmd59_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd59.Click
        SendLetter("্‌")
    End Sub

    Private Sub cmd60_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd60.Click
        SendLetter("ে")
    End Sub

    Private Sub cmd61_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd61.Click
        SendLetter("ৈ")
    End Sub

    Private Sub cmd62_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd62.Click
        SendLetter("ো")
    End Sub

    Private Sub cmd63_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd63.Click
        SendLetter("ৌ")
    End Sub

    Private Sub cmd64_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd64.Click
        SendLetter("ৰ্")
    End Sub

    Private Sub cmd66_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmd66.Click
        SendLetter("-")
    End Sub

    Private Sub Button1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Exit Sub
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Exit Sub
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Exit Sub
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Exit Sub
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        SendLetter("্য")
    End Sub

    Private Sub LoadMeaning(ByVal xID As Integer)
        Try
            lblDictword.Text = ""
            Dim myStr As String = Nothing
            If rbtnAssamese.Checked = True Then
                myStr = "SELECT MainTable.MyWord, MainTable.AsMeaning, MainTable.EngMeaning, MainTable.Synonyms, MainTable.Antonyms, " & _
                        "  Pictures.Picture FROM MainTable LEFT OUTER JOIN Pictures ON Pictures.PICID=MainTable.PictureID WHERE MainTable.ID= " & xID

                'myStr = "SELECT MainTable.MyWord, MainTable.AsMeaning, MainTable.EngMeaning, MainTable.Synonyms," & _
                '        " MainTable.Antonyms, Pictures.Picture FROM MainTable LEFT OUTER JOIN Pictures ON Pictures.ID=MainTable.PictureID WHERE MainTable.ID= " & xID
                'myStr = "SELECT * FROM MainTable WHERE ID= " & xID

                Dim objCmd As New OleDbCommand(myStr, objConn)
                Dim rs As OleDbDataReader = objCmd.ExecuteReader
                If rs.HasRows Then
                    rs.Read()
                    txtAMean.Text = ""
                    Dim dictWord As String = rs("MyWord")
                    lblDictword.Text = Decrypt(dictWord, strEncodeString).Trim 'eachCharDecrept(dictWord, strEncodeString)

                    Dim asMeaning As String = IIf(IsDBNull(rs("AsMeaning")), "", rs("AsMeaning"))
                    txtAMean.AppendText(Decrypt(asMeaning, strEncodeString) & "  " & Environment.NewLine)
                    Dim length_1 As Integer = txtAMean.Text.Length
                    'If txtAMean.Text <> "" Then
                    '    UnderlineWords(txtAMean.Text, 0, length_1 - 1)
                    'End If

                    Dim eMeaning As String = IIf(IsDBNull(rs("EngMeaning")), "", rs("EngMeaning"))
                    Dim length_2 As Integer = 0
                    If eMeaning <> "" Then
                        txtAMean.AppendText(Environment.NewLine & "Scientific Name: " & Decrypt(eMeaning, strEncodeString) & " " & Environment.NewLine)
                        length_2 = txtAMean.Text.Length
                        Dim Str1 As String = txtAMean.Text.Substring(length_1, length_2 - length_1)
                        'If txtAMean.Text <> "" Then
                        '    UnderlineWords(Str1, length_1, length_2 - 1)
                        'End If
                    End If
                    Dim sName As String = "সমাৰ্থক :"
                    Dim aName As String = "বিপৰীত :"
                    Dim synonym As String = IIf(IsDBNull(rs("Synonyms")), "", rs("Synonyms"))
                    Dim length_3 As Integer = 0
                    If synonym <> "" Then
                        sName = sName & " " & Decrypt(synonym, strEncodeString) & " "
                        txtAMean.AppendText(Environment.NewLine & sName & " " & Environment.NewLine)
                        length_3 = txtAMean.Text.Length
                        Dim Str2 As String = txtAMean.Text.Substring(length_2, length_3 - length_2)
                        ''If txtAMean.Text <> "" Then
                        ''    UnderlineWords(Str2, length_2, length_3 - 1)
                        ''End If
                    End If

                    Dim antonym As String = IIf(IsDBNull(rs("Antonyms")), "", rs("Antonyms"))
                    Dim length_4 As Integer = 0
                    If antonym <> "" Then
                        aName = aName & " " & Decrypt(antonym, strEncodeString) & " "
                        txtAMean.AppendText(Environment.NewLine & aName & " " & Environment.NewLine)
                        length_4 = txtAMean.Text.Length
                        Dim Str3 As String = txtAMean.Text.Substring(length_3, length_4 - length_3)
                        ''If txtAMean.Text <> "" Then
                        ''    UnderlineWords(Str3, length_3, length_4 - 1)
                        ''End If
                    End If
                    Dim arrayImage() As Byte = CType(rs("Picture"), Byte())
                    Dim ms As New MemoryStream(arrayImage)
                    With Me.imgRetrieve
                        .Image = Image.FromStream(ms)
                        .SizeMode = PictureBoxSizeMode.StretchImage
                    End With
                End If

            ElseIf rbtnEnglish.Checked = True Then
                'myStr = "SELECT EngWord, EngAsMeaning  FROM EnglishWords WHERE ID=" & xID
                myStr = "SELECT EnglishWords.ID, EnglishWords.EngWord, EnglishWords.EngAsMeaning, EnglishWords.synonym, EnglishWords.antonym, Pictures.Picture,EnglishWords.Sc_name FROM EnglishWords LEFT OUTER JOIN Pictures ON Pictures.PICID=EnglishWords.PictureID WHERE EnglishWords.ID=" & xID

                Dim objCmd As New OleDbCommand(myStr, objConn)
                Dim rs As OleDbDataReader = objCmd.ExecuteReader
                If rs.HasRows Then
                    rs.Read()
                    txtAMean.Text = ""
                    lblDictword.Text = ""
                    Dim eWord As String = ""
                    If rs("EngAsMeaning").ToString = "" Then
                        txtAMean.Font = New System.Drawing.Font("Times New Roman", 15.0!, FontStyle.Regular, GraphicsUnit.Point, CType(0, Byte))
                    Else
                        txtAMean.Font = New System.Drawing.Font("Asomiya_Rohini", 16.0!, FontStyle.Regular, GraphicsUnit.Point, CType(0, Byte))
                        eWord = IIf(IsDBNull(rs("EngWord")), "", rs("EngWord"))
                        lblDictword.Text = Decrypt(eWord, strEncodeString).Trim
                        Dim eMean As String = IIf(IsDBNull(rs("EngAsMeaning")), "", rs("EngAsMeaning"))
                        If eMean <> "" Then
                            txtAMean.Text = Decrypt(eMean, strEncodeString)
                        End If
                    End If
                    'Dim length_1 As Integer = txtAMean.Text.Length
                    'If txtAMean.Text <> "" Then
                    '    UnderlineWords(txtAMean.Text, 0, length_1 - 1)
                    '    'txtAMean.Text = eWord 'Decrypt(txtAMean.Text, strEncodeString)
                    'End If
                    Dim id As Integer = IIf(IsDBNull(rs("ID")), "", rs("ID"))
                    Dim scName As String = IIf(IsDBNull(rs("Sc_name")), "", rs("Sc_name"))
                    'Dim length_2 As Integer = 0
                    If scName <> "" Then
                        txtAMean.AppendText(Environment.NewLine & Environment.NewLine & "Scientific Name: " & Decrypt(scName, strEncodeString) & " " & Environment.NewLine)
                        'length_2 = txtAMean.Text.Length
                        'Dim Str1 As String = txtAMean.Text.Substring(length_1, length_2 - length_1)
                        'If txtAMean.Text <> "" Then
                        '    UnderlineWords(Str1, length_1, length_2 - 1)
                        'End If
                    End If


                    Dim sName As String = "SYNONYM :"
                    Dim aName As String = "ANTONYM :"
                    Dim synonym As String = IIf(IsDBNull(rs("Synonym")), "", rs("Synonym"))
                    Dim length_3 As Integer = 0

                    If synonym <> "" Then
                        sName = sName & " " & Decrypt(synonym, strEncodeString) & " "
                        txtAMean.AppendText(Environment.NewLine & Environment.NewLine & sName & " " & Environment.NewLine)
                        length_3 = txtAMean.Text.Length
                        Dim Str2 As String = txtAMean.Text.Substring(length_3)
                        ''If txtAMean.Text <> "" Then
                        ''    UnderlineWords(Str2, length_2, length_3 - 1)
                        ''End If
                    End If

                    Dim antonym As String = IIf(IsDBNull(rs("Antonym")), "", rs("Antonym"))
                    Dim length_4 As Integer = 0
                    If antonym <> "" Then
                        aName = aName & " " & Decrypt(antonym, strEncodeString) & " "
                        txtAMean.AppendText(Environment.NewLine & aName & " " & Environment.NewLine)
                        length_4 = txtAMean.Text.Length
                        Dim Str3 As String = txtAMean.Text.Substring(length_3, length_4 - length_3)
                        ''If txtAMean.Text <> "" Then
                        ''    UnderlineWords(Str3, length_3, length_4 - 1)
                        ''End If
                    End If
                    Dim arrayImage() As Byte = CType(rs("Picture"), Byte())
                    Dim ms As New MemoryStream(arrayImage)
                    With Me.imgRetrieve
                        .Image = Image.FromStream(ms)
                        .SizeMode = PictureBoxSizeMode.StretchImage
                    End With
                End If
            End If
        Catch ex As Exception
            Exit Sub
        End Try

    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        SendLetter(Button6.Text)
    End Sub

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        SendLetter("্")
    End Sub

    Private Sub txtWord_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtWord.TextChanged
        txtAMean.Text = ""
        lblDictword.Text = ""
        imgRetrieve.Image = Nothing
        lvProbableWord.Items.Clear()
        lvWords.Items.Clear()
        If txtWord.Text.Trim.Length > 49 Then Exit Sub
        If txtWord.Text = "" Then
            lvWords.Items.Clear()
            lvProbableWord.Items.Clear()
            Exit Sub
        End If
        If rbtnAssamese.Checked = False Then
            '===== English Word====
            Dim xCharacterEncrypted As String = ""

            xCharacterEncrypted = EachCharacterEncrypt(txtWord.Text.Trim.ToLower, strEncodeString)
            If Not ShowEngWords(xCharacterEncrypted, 0) Then
                Exit Sub
            End If
        ElseIf rbtnAssamese.Checked = True Then
            '================= Assamese===========
            lvProbableWord.Items.Clear()
            lvWords.Items.Clear()
            Dim encryptedByCharacter As String = ""
            Dim puretext As String = ""
            For i As Integer = 0 To txtWord.Text.Length - 1
                Dim eachChar As String = txtWord.Text.Substring(i, 1)
                If eachChar.Trim = "" Then
                    puretext = puretext
                Else
                    puretext = puretext & eachChar
                End If
            Next
            encryptedByCharacter = EachCharacterEncrypt(puretext, strEncodeString)
            ShowWords(lvWords, encryptedByCharacter.Trim, 0)
            PossibleWord(encryptedByCharacter.Trim)
        End If
        FirstRowSelect()
    End Sub


    Private Sub FirstRowSelect()
        lvWords.Refresh()
        lvProbableWord.Refresh()
        Try
            If lvWords.Items.Count > 0 And lvProbableWord.Items.Count > 0 Then
                lvProbableWord.SelectedIndices.Clear()
                lvProbableWord.HideSelection = True
                lvProbableWord.Refresh()
                lvWords.SelectedIndices.Clear()
                lvWords.Refresh()
                lvWords.HideSelection = False
                lvWords.Items(0).Selected = True
            Else
                If lvWords.Items.Count = 0 Then
                    If lvProbableWord.Items.Count <> 0 Then
                        lvWords.SelectedIndices.Clear()
                        lvWords.HideSelection = True
                        lvWords.Refresh()
                        lvProbableWord.SelectedIndices.Clear()
                        lvProbableWord.Refresh()
                        lvProbableWord.HideSelection = False
                        lvProbableWord.Items(0).Selected = True
                    End If
                Else
                    lvWords.SelectedIndices.Clear()
                    lvWords.Refresh()
                    lvWords.HideSelection = False
                    lvWords.Items(0).Selected = True
                End If
            End If
        Catch ex As Exception
            Exit Sub
        End Try

    End Sub

    Private Sub UnderlineWords(ByVal input As String, ByVal startIndex As Integer, ByVal endIndex As Integer)
        'Try

        '    Dim Words() As String = input.Split(" ")
        '    For Each word As String In Words
        '        Dim xWord As String = word
        '        Dim len As Integer = xWord.Length
        '        If len > 1 Then
        '            Dim fCh As Char = xWord.Substring(0, 1)
        '            Dim LCh As Char = xWord.Substring(len - 1)

        '            If fCh = "" Then
        '                xWord = xWord.Substring(1, len - 1)
        '                len = len - 1
        '                fCh = xWord.Substring(0, 1)
        '            End If

        '            If fCh = "(" Or fCh = "[" Or fCh = " " Then
        '                xWord = xWord.Substring(1, len - 1)
        '                len = len - 1
        '            End If

        '            If LCh = "" Then
        '                xWord = xWord.Substring(0, len - 1)
        '                len = len - 1
        '                LCh = xWord.Substring(len - 1)
        '            End If

        '            If LCh = "'" Or LCh = ";" Or LCh = ":" Or LCh = "]" Or LCh = ")" Or LCh = "," Or LCh = "।" Or LCh = "(" Or LCh = "[" Or LCh = "." Or LCh = " " Then
        '                xWord = xWord.Substring(0, len - 1)
        '            End If
        '            '===================== using it for second time the same code for some reason========
        '            len = xWord.Length
        '            LCh = xWord.Substring(len - 1)
        '            If LCh = "'" Or LCh = ";" Or LCh = ":" Or LCh = "]" Or LCh = ")" Or LCh = "," Or LCh = "।" Or LCh = "(" Or LCh = "[" Or LCh = "." Then
        '                xWord = xWord.Substring(0, len - 1)
        '            End If
        '            '===================================================================================
        '            If len > 1 Then

        '                If IsUnicode(xWord) Then
        '                    Dim myStr As String = "SELECT * from MainTable where MyWord= '" & xWord & "'" '& Replace(SearchWord, "'", "''") & "'"
        '                    'selecteUNicodeWord = EachCharacterEncrypt(xWord, strEncodeString) 'Encrypt(xWord, strEncodeString)
        '                    'Dim myStr As String = "SELECT ID from MainTable where MyWord='" & selecteUNicodeWord & "'"

        '                    Dim objCmd As New OleDbCommand(myStr, objConn)
        '                    Dim rs As OleDbDataReader = objCmd.ExecuteReader
        '                    If rs.HasRows Then
        '                        Dim strSearch As String = xWord
        '                        For i As Integer = startIndex To endIndex
        '                            Dim index As Integer = txtAMean.Find(strSearch, startIndex, endIndex, RichTextBoxFinds.WholeWord)
        '                            If index <> -1 Then
        '                                txtAMean.SelectionStart = index
        '                                txtAMean.SelectionLength = strSearch.Length
        '                                txtAMean.SelectionColor = Color.Coral
        '                                startIndex = index + strSearch.Length
        '                            End If
        '                        Next
        '                    End If
        '                    rs.Close()
        '                Else
        '                    SelecteEngWord = EachCharacterEncrypt(xWord, strEncodeString)
        '                    Dim myStr As String = "SELECT ID from EnglishWords where EngWord= '" & SelecteEngWord & "'"
        '                    Dim objCmd As New OleDbCommand(myStr, objConn)
        '                    Dim rs As OleDbDataReader = objCmd.ExecuteReader
        '                    If rs.HasRows Then
        '                        Dim strSearch As String = xWord
        '                        For i As Integer = startIndex To endIndex
        '                            Dim index As Integer = txtAMean.Find(strSearch, startIndex, endIndex, RichTextBoxFinds.WholeWord)
        '                            If index <> -1 Then
        '                                txtAMean.SelectionStart = index
        '                                txtAMean.SelectionLength = strSearch.Length
        '                                txtAMean.SelectionColor = Color.Coral
        '                            End If
        '                            startIndex = i
        '                        Next
        '                    End If
        '                    rs.Close()
        '                End If
        '            End If
        '        End If
        '    Next
        'Catch ex As Exception
        '    Exit Sub
        'End Try

    End Sub

    Private Sub lvWords_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvWords.GotFocus
        If lvWords.Items.Count > 0 Then
            lvWords.HideSelection = False
            lvProbableWord.SelectedIndices.Clear()
            lvProbableWord.Refresh()
            lvProbableWord.HideSelection = True
            LoadMeaning(lvWords.Items(0).Name)
        End If
    End Sub

    Private Sub lvProbableWord_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvProbableWord.GotFocus
        If lvProbableWord.Items.Count > 0 Then
            lvProbableWord.HideSelection = False
            lvWords.SelectedIndices.Clear()
            lvWords.Refresh()
            lvWords.HideSelection = True
            LoadMeaning(lvProbableWord.Items(0).Name)
        End If
    End Sub

    Private Sub lvProbableWord_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvProbableWord.SelectedIndexChanged
        imgRetrieve.Image = Nothing
        Dim prevWord As String = lblDictword.Text.ToString.Trim
        If lvProbableWord.SelectedItems.Count <> 0 Then
            lvWords.HideSelection = True
            txtAMean.Text = ""
            LoadMeaning(lvProbableWord.SelectedItems(0).Name)
            'If prevWord <> "" Then
            '    storeWord.Add(prevWord)
            '    wordSelect = 2
            'End If
        End If
    End Sub

    Private Sub lvWords_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvWords.MouseHover
        If lvWords.Items.Count > 0 Then
            lvWords.Focus()
        End If
    End Sub

    Private Sub lvWords_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvWords.SelectedIndexChanged
        imgRetrieve.Image = Nothing
        Dim prevWord As String = lblDictword.Text.ToString.Trim
        If lvWords.SelectedItems.Count <> 0 Then
            lvProbableWord.HideSelection = True
            txtAMean.Clear()
            LoadMeaning(lvWords.SelectedItems(0).Name)
            'If prevWord <> "" Then
            '    storeWord.Add(prevWord)
            '    wordSelect = 2
            'End If
        End If

    End Sub

    Private Sub txtWord_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtWord.LostFocus
        If lvWords.Items.Count = 0 And lvProbableWord.Items.Count = 0 Then Exit Sub
        If lvWords.Items.Count = 0 Then
            lvProbableWord.Focus()
        Else
            lvWords.Focus()
        End If
    End Sub


    Public Function GetWordUnderMouse(ByRef Rtf As System.Windows.Forms.RichTextBox, ByVal X As Integer, ByVal Y As Integer) As String
        On Error Resume Next
        Dim POINT As System.Drawing.Point = New System.Drawing.Point()
        Dim Pos As Integer, i As Integer, lStart As Integer, lEnd As Integer
        Dim lLen As Integer, sTxt As String, sChr As String
        '
        POINT.X = X
        POINT.Y = Y
        GetWordUnderMouse = vbNullString
        '
        With Rtf
            lLen = Len(.Text)
            sTxt = .Text
            Pos = Rtf.GetCharIndexFromPosition(POINT)
            If Pos > 0 Then
                For i = Pos To 1 Step -1
                    sChr = Mid(sTxt, i, 1)
                    If sChr = " " Or sChr = Chr(13) Or i = 1 Then
                        'if the starting character is vbcrlf then
                        'we want to chop that off
                        If sChr = Chr(13) Then
                            lStart = (i + 2)
                        Else
                            lStart = i
                        End If
                        Exit For
                    End If
                Next i
                For i = Pos To lLen
                    If Mid(sTxt, i, 1) = " " Or Mid(sTxt, i, 1) = Chr(13) Or i = lLen Then
                        lEnd = i + 1
                        Exit For
                    End If
                Next i
                If lEnd >= lStart Then
                    GetWordUnderMouse = Trim(Mid(sTxt, lStart, lEnd - lStart))
                End If
            End If
        End With
    End Function


    Private Sub txtAMean_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles txtAMean.MouseClick
        Dim count As Integer = storeWord.Count
        Dim previosWord As String = lblDictword.Text.Trim
        'If lastSelectIndex >= 0 Then
        '    storedPrevWord.Add(previosWord)
        'End If

        Try
            isLinkedWord = False
            curWord = GetWordUnderMouse(Me.txtAMean, e.X, e.Y)

            If curWord = "" Then Exit Sub
            Dim xWord As String = curWord.Trim
            Dim len As Integer = xWord.Length
            Dim fCh As Char = xWord.Substring(0, 1)
            Dim LCh As Char = xWord.Substring(len - 1)

            If fCh = "(" Or fCh = "[" Or fCh = "" Or fCh = "‘" Then
                xWord = xWord.Substring(1, len - 1)
                len = len - 1
            End If
            If LCh = "'" Or LCh = "’" Or LCh = ";" Or LCh = ":" Or LCh = "]" Or LCh = ")" Or LCh = "," Or LCh = "।" Or LCh = "(" Or LCh = "[" Or LCh = "." Then
                xWord = xWord.Substring(0, len - 1)
            End If
            '=====================using it for second time the same code for some reason========
            len = xWord.Length
            LCh = xWord.Substring(len - 1)
            If LCh = "'" Or LCh = "‘" Or LCh = ";" Or LCh = ":" Or LCh = "]" Or LCh = ")" Or LCh = "," Or LCh = "।" Or LCh = "(" Or LCh = "[" Or LCh = "." Then
                xWord = xWord.Substring(0, len - 1)
            End If
            '===================================================================================
            ' checking the string Unicode or Not... 
            'if Unicode then check in the assamese word and if Non Unicode then check in the english table
            '====================================================================================

            If IsUnicode(xWord) Then

                'true.. search Assamese
                selecteUNicodeWord = EachCharacterEncrypt(xWord, strEncodeString)
                Dim cmd As New OleDbCommand("SELECT Asmeaning, EngMeaning FROM MainTable WHERE MyWord_Ch ='" & selecteUNicodeWord & "'", objConn)
                'cmd.Parameters.Add("@word", OleDbType.VarWChar).Value = Encrypt(xWord.Trim, strEncodeString)
                Dim rs As OleDbDataReader = cmd.ExecuteReader
                If rs.HasRows Then
                    rbtnAssamese.Checked = True
                    txtWord.Text = xWord
                Else
                    Exit Sub
                End If
                'myList.Add(previosWord)
                storeWord.Add(previosWord)
                wordSelect = 0

            Else
                ''false.. search English
                xWord = xWord.ToLower
                SelecteEngWord = EachCharacterEncrypt(xWord, strEncodeString)
                Dim cmd As New OleDbCommand("SELECT * FROM EnglishWords WHERE EngWord_Ch ='" & SelecteEngWord & "'", objConn)
                'cmd.Parameters.Add("@EngWord", OleDbType.VarWChar).Value = Encrypt(xWord.Trim, strEncodeString)
                Dim rs As OleDbDataReader = cmd.ExecuteReader
                If rs.HasRows Then
                    isLinkedWord = True
                    rbtnEnglish.Checked = True
                    txtWord.Text = xWord
                Else
                    Exit Sub
                End If
                'myList.Add(previosWord)
                storeWord.Add(previosWord)
                wordSelect = 0
            End If
        Catch ex As Exception
            Exit Sub
        End Try
    End Sub

    'Private Sub ShowSelecetedEngWord(ByVal mybox As ListView, ByVal myval As String)
    '    Try

    '        lvWords.Items.Clear()
    '        If myval = "" Then
    '            Exit Sub
    '        End If
    '        Dim myStr As String = Nothing
    '        myStr = "SELECT  ID, EngWord FROM EnglishWords WHERE EngWord='" & myval & "' ORDER BY  EngWord, LEN(EngWord) ASC"
    '        Dim objCmd As New OleDbCommand(myStr, objConn)
    '        Dim rs As OleDbDataReader = objCmd.ExecuteReader
    '        If rs.HasRows Then
    '            Dim xItem As ListViewItem
    '            Do While rs.Read
    '                Dim xWord As String = IIf(IsDBNull(rs("EngWord")), "", rs("EngWord"))
    '                xItem = lvWords.Items.Add(rs("ID"), xWord, "")
    '            Loop
    '        End If
    '    Catch ex As Exception
    '        Exit Sub
    '    End Try
    'End Sub

    'Private Sub ShowSelectedAssameseWord(ByRef Mybox As ListView, ByVal myval As String)
    '    Try
    '        Mybox.Items.Clear()
    '        Dim xMyval As String = ""
    '        xMyval = " left(MyWord, " & Len(myval) & ")= '" & myval.Substring(0, myval.Length) & "'"
    '        txtAMean.Clear()
    '        If myval = "" Then
    '            Exit Sub
    '        End If
    '        myval = xMyval
    '        Dim myStr As String = Nothing
    '        myStr = "SELECT TOP 500 ID, MyWord FROM MainTable WHERE " & myval & " ORDER BY ID, MyWOrd , LEN(MyWord) ASC"
    '        Dim objCmd As New OleDbCommand(myStr, objConn)
    '        Dim rs As OleDbDataReader = objCmd.ExecuteReader
    '        If rs.HasRows Then
    '            Dim xItem As ListViewItem
    '            Do While rs.Read
    '                Dim myword As String = IIf(IsDBNull(rs("MyWord")), "", rs("MyWord"))
    '                xItem = Mybox.Items.Add(rs("ID"), myword, "")
    '            Loop
    '        Else
    '            Exit Sub
    '        End If
    '    Catch ex As Exception
    '        'MsgBox(ex.Message)
    '        'MsgBox("Error in loading the data.", MsgBoxStyle.Critical, "Error")
    '        Exit Sub
    '    End Try
    '    Exit Sub
    'End Sub



    'Private Sub addItem(ByVal stext As String)
    '    AddElementToStringArray(stext)
    '    Try
    '        Dim cmd As New OleDbCommand("INSERT INTO tempData(id,word) VALUES(?,?)", objConn)
    '        cmd.Parameters.Add("@id", OleDbType.Date).Value = Now
    '        cmd.Parameters.Add("@word", OleDbType.VarWChar).Value = stext
    '        cmd.ExecuteNonQuery()
    '    Catch ex As Exception
    '        Exit Sub
    '    End Try
    'End Sub

    Private Function IsUnicode(ByVal Str As String) As Boolean

        'Set it to False by default
        Dim bIsUnicode As Boolean = False
        'Setup Encodings
        Dim EncDefault As System.Text.Encoding = System.Text.Encoding.GetEncoding(0) 'String Default Encoding
        Dim EncUnicode As System.Text.Encoding = System.Text.Encoding.Unicode 'Encoding
        Dim bitesDefault As Byte() = EncDefault.GetBytes(Str) 'Get the bytes of the string using the string's default encoding
        Dim bitesUnicode As Byte() = EncUnicode.GetBytes(Str)
        Dim charsDefault As Char() = EncDefault.GetChars(bitesDefault) 'Get the characters of the default string
        Dim charsUnicode As Char() = EncUnicode.GetChars(bitesUnicode) 'Get the characters in unicode
        'Loop through all the characters and see if they all match.
        ' if any do not match, then it's unicode
        For i As Integer = 0 To charsDefault.Length - 1
            If charsDefault(i) <> charsUnicode(i) Then
                bIsUnicode = True
                'we found one that doesn't match, so exit the loop
                Exit For
            End If
        Next
        Return bIsUnicode
    End Function

    Private Sub txtWord_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtWord.KeyPress
        If Val(e.KeyChar) = 108 Then
            Me.Close()
        End If
    End Sub

    Private Sub txtWord_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtWord.KeyDown
        Dim Test As Integer = 0
        'lblProbableWords.Text = e.KeyCode
        If rbtnAssamese.Checked = True Then
            'If e.Alt = False And e.Control = False And e.Shift = False And e.KeyCode = 75 Then
            '    Test = txtWord.SelectionStart
            '    txtWord.Text = txtWord.Text.Insert(txtWord.SelectionStart, "ক")
            '    e.SuppressKeyPress = True
            '    txtWord.SelectionStart = Test + 1
            'End If
            'If e.Alt = False And e.Control = False And e.Shift = False And e.KeyCode = 79 Then
            '    Test = txtWord.SelectionStart
            '    'txtWord.Text = txtWord.Text.Insert(txtWord.SelectionStart, "দ")
            '    e.SuppressKeyPress = True
            '    txtWord.SelectionStart = Test + 1
            'End If
            'If e.Alt = False And e.Control = False And e.Shift = False And e.KeyCode = 76 Then
            '    Test = txtWord.SelectionStart
            '    txtWord.Text = txtWord.Text.Insert(txtWord.SelectionStart, "ল")
            '    e.SuppressKeyPress = True
            '    txtWord.SelectionStart = Test + 1
            'End If
            'If e.Alt = False And e.Control = False And e.Shift = False And e.KeyCode = 66 Then
            '    Test = txtWord.SelectionStart
            '    txtWord.Text = txtWord.Text.Insert(txtWord.SelectionStart, "ব")
            '    e.SuppressKeyPress = True
            '    txtWord.SelectionStart = Test + 1
            'End If
            'If e.Alt = False And e.Control = False And e.Shift = False And e.KeyCode = 73 Then
            '    Test = txtWord.SelectionStart
            '    txtWord.Text = txtWord.Text.Insert(txtWord.SelectionStart, "ি")
            '    e.SuppressKeyPress = True
            '    txtWord.SelectionStart = Test + 1
            'End If






            If e.Alt = False And e.Control = False And e.Shift = False And e.KeyCode = 75 Then
                Test = txtWord.SelectionStart
                txtWord.Text = txtWord.Text.Insert(txtWord.SelectionStart, "ক")
                e.SuppressKeyPress = True
                txtWord.SelectionStart = Test + 1
            End If
            If e.Alt = False And e.Control = False And e.Shift = True And e.KeyCode = 75 Then
                Test = txtWord.SelectionStart
                txtWord.Text = txtWord.Text.Insert(txtWord.SelectionStart, "খ")
                e.SuppressKeyPress = True
                txtWord.SelectionStart = Test + 1
            End If

            If e.Alt = False And e.Control = False And e.Shift = False And e.KeyCode = 73 Then
                Test = txtWord.SelectionStart
                txtWord.Text = txtWord.Text.Insert(txtWord.SelectionStart, "গ")
                e.SuppressKeyPress = True
                txtWord.SelectionStart = Test + 1
            End If
            If e.Alt = False And e.Control = False And e.Shift = True And e.KeyCode = 73 Then
                Test = txtWord.SelectionStart
                txtWord.Text = txtWord.Text.Insert(txtWord.SelectionStart, "ঘ")
                e.SuppressKeyPress = True
                txtWord.SelectionStart = Test + 1
            End If
            If e.Alt = False And e.Control = False And e.Shift = True And e.KeyCode = 85 Then
                Test = txtWord.SelectionStart
                txtWord.Text = txtWord.Text.Insert(txtWord.SelectionStart, "ঙ")
                e.SuppressKeyPress = True
                txtWord.SelectionStart = Test + 1
            End If

            If e.Alt = False And e.Control = False And e.Shift = False And e.KeyCode = 186 Then
                Test = txtWord.SelectionStart
                txtWord.Text = txtWord.Text.Insert(txtWord.SelectionStart, "চ")
                e.SuppressKeyPress = True
                txtWord.SelectionStart = Test + 1
            End If

            If e.Alt = False And e.Control = False And e.Shift = True And e.KeyCode = 186 Then
                Test = txtWord.SelectionStart
                txtWord.Text = txtWord.Text.Insert(txtWord.SelectionStart, "ছ")
                e.SuppressKeyPress = True
                txtWord.SelectionStart = Test + 1
            End If

            If e.Alt = False And e.Control = False And e.Shift = False And e.KeyCode = 80 Then
                Test = txtWord.SelectionStart
                txtWord.Text = txtWord.Text.Insert(txtWord.SelectionStart, "জ")
                e.SuppressKeyPress = True
                txtWord.SelectionStart = Test + 1
            End If
            If e.Alt = False And e.Control = False And e.Shift = True And e.KeyCode = 80 Then
                Test = txtWord.SelectionStart
                txtWord.Text = txtWord.Text.Insert(txtWord.SelectionStart, "ঝ")
                e.SuppressKeyPress = True
                txtWord.SelectionStart = Test + 1
            End If
            If e.Alt = False And e.Control = False And e.Shift = True And e.KeyCode = 78 Then
                Test = txtWord.SelectionStart
                txtWord.Text = txtWord.Text.Insert(txtWord.SelectionStart, "ঞ")
                e.SuppressKeyPress = True
                txtWord.SelectionStart = Test + 1
            End If
            If e.Alt = False And e.Control = False And e.Shift = False And e.KeyCode = 222 Then
                Test = txtWord.SelectionStart
                txtWord.Text = txtWord.Text.Insert(txtWord.SelectionStart, "ট")
                e.SuppressKeyPress = True
                txtWord.SelectionStart = Test + 1
            End If
            If e.Alt = False And e.Control = False And e.Shift = True And e.KeyCode = 222 Then
                Test = txtWord.SelectionStart
                txtWord.Text = txtWord.Text.Insert(txtWord.SelectionStart, "ঠ")
                e.SuppressKeyPress = True
                txtWord.SelectionStart = Test + 1
            End If
            If e.Alt = False And e.Control = False And e.Shift = False And e.KeyCode = 219 Then
                Test = txtWord.SelectionStart
                txtWord.Text = txtWord.Text.Insert(txtWord.SelectionStart, "ড")
                e.SuppressKeyPress = True
                txtWord.SelectionStart = Test + 1
            End If
            If e.Alt = False And e.Control = False And e.Shift = True And e.KeyCode = 219 Then
                Test = txtWord.SelectionStart
                txtWord.Text = txtWord.Text.Insert(txtWord.SelectionStart, "ঢ")
                e.SuppressKeyPress = True
                txtWord.SelectionStart = Test + 1
            End If
            If e.Alt = False And e.Control = False And e.Shift = True And e.KeyCode = 67 Then
                Test = txtWord.SelectionStart
                txtWord.Text = txtWord.Text.Insert(txtWord.SelectionStart, "ণ")
                e.SuppressKeyPress = True
                txtWord.SelectionStart = Test + 1
            End If

            If e.Alt = False And e.Control = False And e.Shift = False And e.KeyCode = 76 Then
                Test = txtWord.SelectionStart
                txtWord.Text = txtWord.Text.Insert(txtWord.SelectionStart, "ত")
                e.SuppressKeyPress = True
                txtWord.SelectionStart = Test + 1
            End If
            If e.Alt = False And e.Control = False And e.Shift = True And e.KeyCode = 76 Then
                Test = txtWord.SelectionStart
                txtWord.Text = txtWord.Text.Insert(txtWord.SelectionStart, "থ")
                e.SuppressKeyPress = True
                txtWord.SelectionStart = Test + 1
            End If

            If e.Alt = False And e.Control = False And e.Shift = False And e.KeyCode = 79 Then
                Test = txtWord.SelectionStart
                txtWord.Text = txtWord.Text.Insert(txtWord.SelectionStart, "দ")
                e.SuppressKeyPress = True
                txtWord.SelectionStart = Test + 1
            End If
            If e.Alt = False And e.Control = False And e.Shift = True And e.KeyCode = 79 Then
                Test = txtWord.SelectionStart
                txtWord.Text = txtWord.Text.Insert(txtWord.SelectionStart, "ধ")
                e.SuppressKeyPress = True
                txtWord.SelectionStart = Test + 1
            End If
            If e.Alt = False And e.Control = False And e.Shift = False And e.KeyCode = 86 Then
                Test = txtWord.SelectionStart
                txtWord.Text = txtWord.Text.Insert(txtWord.SelectionStart, "ন")
                e.SuppressKeyPress = True
                txtWord.SelectionStart = Test + 1
            End If
            If e.Alt = False And e.Control = False And e.Shift = False And e.KeyCode = 72 Then
                Test = txtWord.SelectionStart
                txtWord.Text = txtWord.Text.Insert(txtWord.SelectionStart, "প")
                e.SuppressKeyPress = True
                txtWord.SelectionStart = Test + 1
            End If

            If e.Alt = False And e.Control = False And e.Shift = True And e.KeyCode = 72 Then
                Test = txtWord.SelectionStart
                txtWord.Text = txtWord.Text.Insert(txtWord.SelectionStart, "ফ")
                e.SuppressKeyPress = True
                txtWord.SelectionStart = Test + 1
            End If

            If e.Alt = False And e.Control = False And e.Shift = False And e.KeyCode = 89 Then
                Test = txtWord.SelectionStart
                txtWord.Text = txtWord.Text.Insert(txtWord.SelectionStart, "ব")
                e.SuppressKeyPress = True
                txtWord.SelectionStart = Test + 1
            End If

            If e.Alt = False And e.Control = False And e.Shift = True And e.KeyCode = 89 Then
                Test = txtWord.SelectionStart
                txtWord.Text = txtWord.Text.Insert(txtWord.SelectionStart, "ভ")
                e.SuppressKeyPress = True
                txtWord.SelectionStart = Test + 1
            End If
            If e.Alt = False And e.Control = False And e.Shift = False And e.KeyCode = 67 Then
                Test = txtWord.SelectionStart
                txtWord.Text = txtWord.Text.Insert(txtWord.SelectionStart, "ম")
                e.SuppressKeyPress = True
                txtWord.SelectionStart = Test + 1
            End If
            If e.Alt = False And e.Control = False And e.Shift = False And e.KeyCode = 220 Then
                Test = txtWord.SelectionStart
                txtWord.Text = txtWord.Text.Insert(txtWord.SelectionStart, "য")
                e.SuppressKeyPress = True
                txtWord.SelectionStart = Test + 1
            End If

            If e.Alt = False And e.Control = False And e.Shift = False And e.KeyCode = 74 Then
                Test = txtWord.SelectionStart
                txtWord.Text = txtWord.Text.Insert(txtWord.SelectionStart, "ৰ")
                e.SuppressKeyPress = True
                txtWord.SelectionStart = Test + 1
            End If

            If e.Alt = False And e.Control = False And e.Shift = False And e.KeyCode = 78 Then
                Test = txtWord.SelectionStart
                txtWord.Text = txtWord.Text.Insert(txtWord.SelectionStart, "ল")
                e.SuppressKeyPress = True
                txtWord.SelectionStart = Test + 1
            End If
            If e.Alt = False And e.Control = False And e.Shift = False And e.KeyCode = 66 Then
                Test = txtWord.SelectionStart
                txtWord.Text = txtWord.Text.Insert(txtWord.SelectionStart, "ৱ")
                e.SuppressKeyPress = True
                txtWord.SelectionStart = Test + 1
            End If
            If e.Alt = False And e.Control = False And e.Shift = True And e.KeyCode = 77 Then
                Test = txtWord.SelectionStart
                txtWord.Text = txtWord.Text.Insert(txtWord.SelectionStart, "শ")
                e.SuppressKeyPress = True
                txtWord.SelectionStart = Test + 1
            End If
            If e.Alt = False And e.Control = False And e.Shift = True And e.KeyCode = 188 Then
                Test = txtWord.SelectionStart
                txtWord.Text = txtWord.Text.Insert(txtWord.SelectionStart, "ষ")
                e.SuppressKeyPress = True
                txtWord.SelectionStart = Test + 1
            End If
            If e.Alt = False And e.Control = False And e.Shift = False And e.KeyCode = 77 Then
                Test = txtWord.SelectionStart
                txtWord.Text = txtWord.Text.Insert(txtWord.SelectionStart, "স")
                e.SuppressKeyPress = True
                txtWord.SelectionStart = Test + 1
            End If
            If e.Alt = False And e.Control = False And e.Shift = False And e.KeyCode = 85 Then
                Test = txtWord.SelectionStart
                txtWord.Text = txtWord.Text.Insert(txtWord.SelectionStart, "হ")
                e.SuppressKeyPress = True
                txtWord.SelectionStart = Test + 1
            End If
            If e.Alt = False And e.Control = False And e.Shift = True And e.KeyCode = 55 Then
                Test = txtWord.SelectionStart
                txtWord.Text = txtWord.Text.Insert(txtWord.SelectionStart, "ক্ষ")
                e.SuppressKeyPress = True
                txtWord.SelectionStart = Test + 3
            End If

            If e.Alt = False And e.Control = False And e.Shift = False And e.KeyCode = 221 Then
                Test = txtWord.SelectionStart
                txtWord.Text = txtWord.Text.Insert(txtWord.SelectionStart, "ড়")
                e.SuppressKeyPress = True
                txtWord.SelectionStart = Test + 1
            End If
            If e.Alt = False And e.Control = False And e.Shift = True And e.KeyCode = 221 Then
                Test = txtWord.SelectionStart
                txtWord.Text = txtWord.Text.Insert(txtWord.SelectionStart, "ঢ়")
                e.SuppressKeyPress = True
                txtWord.SelectionStart = Test + 1
            End If
            If e.Alt = False And e.Control = False And e.Shift = False And e.KeyCode = 191 Then
                Test = txtWord.SelectionStart
                txtWord.Text = txtWord.Text.Insert(txtWord.SelectionStart, "য়")
                e.SuppressKeyPress = True
                txtWord.SelectionStart = Test + 1
            End If
            If e.Alt = False And e.Control = False And e.Shift = True And e.KeyCode = 220 Then
                Test = txtWord.SelectionStart
                txtWord.Text = txtWord.Text.Insert(txtWord.SelectionStart, "ৎ")
                e.SuppressKeyPress = True
                txtWord.SelectionStart = Test + 1
            End If
            If e.Alt = False And e.Control = False And e.Shift = True And e.KeyCode = 68 Then
                Test = txtWord.SelectionStart
                txtWord.Text = txtWord.Text.Insert(txtWord.SelectionStart, "অ")
                e.SuppressKeyPress = True
                txtWord.SelectionStart = Test + 1
            End If
            If e.Alt = False And e.Control = False And e.Shift = True And e.KeyCode = 69 Then
                Test = txtWord.SelectionStart
                txtWord.Text = txtWord.Text.Insert(txtWord.SelectionStart, "আ")
                e.SuppressKeyPress = True
                txtWord.SelectionStart = Test + 1
            End If
            If e.Alt = False And e.Control = False And e.Shift = True And e.KeyCode = 70 Then
                Test = txtWord.SelectionStart
                txtWord.Text = txtWord.Text.Insert(txtWord.SelectionStart, "ই")
                e.SuppressKeyPress = True
                txtWord.SelectionStart = Test + 1
            End If
            If e.Alt = False And e.Control = False And e.Shift = True And e.KeyCode = 82 Then
                Test = txtWord.SelectionStart
                txtWord.Text = txtWord.Text.Insert(txtWord.SelectionStart, "ঈ")
                e.SuppressKeyPress = True
                txtWord.SelectionStart = Test + 1
            End If
            If e.Alt = False And e.Control = False And e.Shift = True And e.KeyCode = 71 Then
                Test = txtWord.SelectionStart
                txtWord.Text = txtWord.Text.Insert(txtWord.SelectionStart, "উ")
                e.SuppressKeyPress = True
                txtWord.SelectionStart = Test + 1
            End If
            If e.Alt = False And e.Control = False And e.Shift = True And e.KeyCode = 84 Then
                Test = txtWord.SelectionStart
                txtWord.Text = txtWord.Text.Insert(txtWord.SelectionStart, "ঊ")
                e.SuppressKeyPress = True
                txtWord.SelectionStart = Test + 1
            End If
            If e.Alt = False And e.Control = False And e.Shift = True And e.KeyCode = 90 Then
                Test = txtWord.SelectionStart
                txtWord.Text = txtWord.Text.Insert(txtWord.SelectionStart, "ঋ")
                e.SuppressKeyPress = True
                txtWord.SelectionStart = Test + 1
            End If
            If e.Alt = False And e.Control = False And e.Shift = True And e.KeyCode = 83 Then
                Test = txtWord.SelectionStart
                txtWord.Text = txtWord.Text.Insert(txtWord.SelectionStart, "এ")
                e.SuppressKeyPress = True
                txtWord.SelectionStart = Test + 1
            End If
            If e.Alt = False And e.Control = False And e.Shift = True And e.KeyCode = 87 Then
                Test = txtWord.SelectionStart
                txtWord.Text = txtWord.Text.Insert(txtWord.SelectionStart, "ঐ")
                e.SuppressKeyPress = True
                txtWord.SelectionStart = Test + 1
            End If
            If e.Alt = False And e.Control = False And e.Shift = True And e.KeyCode = 65 Then
                Test = txtWord.SelectionStart
                txtWord.Text = txtWord.Text.Insert(txtWord.SelectionStart, "ও")
                e.SuppressKeyPress = True
                txtWord.SelectionStart = Test + 1
            End If
            If e.Alt = False And e.Control = False And e.Shift = True And e.KeyCode = 81 Then
                Test = txtWord.SelectionStart
                txtWord.Text = txtWord.Text.Insert(txtWord.SelectionStart, "ঔ")
                e.SuppressKeyPress = True
                txtWord.SelectionStart = Test + 1
            End If
            If e.Alt = False And e.Control = False And e.Shift = False And e.KeyCode = 88 Then
                Test = txtWord.SelectionStart
                txtWord.Text = txtWord.Text.Insert(txtWord.SelectionStart, "ং")
                e.SuppressKeyPress = True
                txtWord.SelectionStart = Test + 1
            End If
            If e.Alt = False And e.Control = False And e.Shift = True And e.KeyCode = 88 Then
                Test = txtWord.SelectionStart
                txtWord.Text = txtWord.Text.Insert(txtWord.SelectionStart, "ঁ")
                e.SuppressKeyPress = True
                txtWord.SelectionStart = Test + 1
            End If
            If e.Alt = False And e.Control = False And e.Shift = True And e.KeyCode = 189 Then
                Test = txtWord.SelectionStart
                txtWord.Text = txtWord.Text.Insert(txtWord.SelectionStart, "ঃ")
                e.SuppressKeyPress = True
                txtWord.SelectionStart = Test + 1
            End If
            If e.Alt = False And e.Control = False And e.Shift = False And e.KeyCode = 68 Then
                Test = txtWord.SelectionStart
                txtWord.Text = txtWord.Text.Insert(txtWord.SelectionStart, "্")
                e.SuppressKeyPress = True
                txtWord.SelectionStart = Test + 1
            End If
            '=========================
            If e.Alt = False And e.Control = False And e.Shift = False And e.KeyCode = 69 Then
                Test = txtWord.SelectionStart
                txtWord.Text = txtWord.Text.Insert(txtWord.SelectionStart, "া")
                e.SuppressKeyPress = True
                txtWord.SelectionStart = Test + 1
            End If
            If e.Alt = False And e.Control = False And e.Shift = False And e.KeyCode = 70 Then
                Test = txtWord.SelectionStart
                txtWord.Text = txtWord.Text.Insert(txtWord.SelectionStart, "ি")
                e.SuppressKeyPress = True
                txtWord.SelectionStart = Test + 1
            End If
            If e.Alt = False And e.Control = False And e.Shift = False And e.KeyCode = 82 Then
                Test = txtWord.SelectionStart
                txtWord.Text = txtWord.Text.Insert(txtWord.SelectionStart, "ী")
                e.SuppressKeyPress = True
                txtWord.SelectionStart = Test + 1
            End If
            If e.Alt = False And e.Control = False And e.Shift = False And e.KeyCode = 71 Then
                Test = txtWord.SelectionStart
                txtWord.Text = txtWord.Text.Insert(txtWord.SelectionStart, "ু")
                e.SuppressKeyPress = True
                txtWord.SelectionStart = Test + 1
            End If
            If e.Alt = False And e.Control = False And e.Shift = False And e.KeyCode = 84 Then
                Test = txtWord.SelectionStart
                txtWord.Text = txtWord.Text.Insert(txtWord.SelectionStart, "ূ")
                e.SuppressKeyPress = True
                txtWord.SelectionStart = Test + 1
            End If
            If e.Alt = False And e.Control = False And e.Shift = False And e.KeyCode = 90 Then
                Test = txtWord.SelectionStart
                txtWord.Text = txtWord.Text.Insert(txtWord.SelectionStart, "ৃ")
                e.SuppressKeyPress = True
                txtWord.SelectionStart = Test + 1
            End If
            If e.Alt = False And e.Control = False And e.Shift = False And e.KeyCode = 83 Then
                Test = txtWord.SelectionStart
                txtWord.Text = txtWord.Text.Insert(txtWord.SelectionStart, "ে")
                e.SuppressKeyPress = True
                txtWord.SelectionStart = Test + 1
            End If
            If e.Alt = False And e.Control = False And e.Shift = False And e.KeyCode = 87 Then
                Test = txtWord.SelectionStart
                txtWord.Text = txtWord.Text.Insert(txtWord.SelectionStart, "ৈ")
                e.SuppressKeyPress = True
                txtWord.SelectionStart = Test + 1
            End If
            If e.Alt = False And e.Control = False And e.Shift = False And e.KeyCode = 65 Then
                Test = txtWord.SelectionStart
                txtWord.Text = txtWord.Text.Insert(txtWord.SelectionStart, "ো")
                e.SuppressKeyPress = True
                txtWord.SelectionStart = Test + 1
            End If
            If e.Alt = False And e.Control = False And e.Shift = False And e.KeyCode = 81 Then
                Test = txtWord.SelectionStart
                txtWord.Text = txtWord.Text.Insert(txtWord.SelectionStart, "ৌ")
                e.SuppressKeyPress = True
                txtWord.SelectionStart = Test + 1
            End If
            If e.Alt = False And e.Control = False And e.Shift = False And e.KeyCode = 192 Then
                Test = txtWord.SelectionStart
                txtWord.Text = txtWord.Text.Insert(txtWord.SelectionStart, "্য")
                e.SuppressKeyPress = True
                txtWord.SelectionStart = Test + 2
            End If
            If e.Alt = False And e.Control = False And e.Shift = True And e.KeyCode = 52 Then
                Test = txtWord.SelectionStart
                txtWord.Text = txtWord.Text.Insert(txtWord.SelectionStart, "ৰ্")
                e.SuppressKeyPress = True
                txtWord.SelectionStart = Test + 2
            End If
            If e.Alt = False And e.Control = False And e.Shift = True And e.KeyCode = 50 Then
                Test = txtWord.SelectionStart
                txtWord.Text = txtWord.Text.Insert(txtWord.SelectionStart, "’")
                e.SuppressKeyPress = True
                txtWord.SelectionStart = Test + 1
            End If
            If e.Alt = False And e.Control = False And e.Shift = True And e.KeyCode = 54 Then
                Test = txtWord.SelectionStart
                txtWord.Text = txtWord.Text.Insert(txtWord.SelectionStart, "ত্ৰ")
                e.SuppressKeyPress = True
                txtWord.SelectionStart = Test + 3
            End If
            If e.Alt = False And e.Control = False And e.Shift = True And e.KeyCode = 56 Then
                Test = txtWord.SelectionStart
                txtWord.Text = txtWord.Text.Insert(txtWord.SelectionStart, "জ্ঞ")
                e.SuppressKeyPress = True
                txtWord.SelectionStart = Test + 3
            End If
            If e.Alt = False And e.Control = False And e.Shift = True And e.KeyCode = 53 Then
                Test = txtWord.SelectionStart
                txtWord.Text = txtWord.Text.Insert(txtWord.SelectionStart, "প্ৰ")
                e.SuppressKeyPress = True
                txtWord.SelectionStart = Test + 3
            End If
            If e.Alt = False And e.Control = False And e.Shift = True And e.KeyCode = 51 Then
                Test = txtWord.SelectionStart
                txtWord.Text = txtWord.Text.Insert(txtWord.SelectionStart, "ক্ৰ")
                e.SuppressKeyPress = True
                txtWord.SelectionStart = Test + 3
            End If
            '==============================





            'If e.Alt = False And e.Control = False And e.Shift = True And e.KeyCode = 52 Then
            '    Test = txtWord.SelectionStart
            '    txtWord.Text = txtWord.Text.Insert(txtWord.SelectionStart, "গ্ৰ")
            '    e.SuppressKeyPress = True
            '    txtWord.SelectionStart = Test + 3
            'End If


            'Else
            '    If e.Alt = False And e.Control = False And e.Shift = False And e.KeyCode = 75 Then
            '        Test = txtWord.SelectionStart
            '        txtWord.Text = txtWord.Text.Insert(txtWord.SelectionStart, "ক")
            '        e.SuppressKeyPress = True
            '        txtWord.SelectionStart = Test + 1
            '    End If
            '    If e.Alt = False And e.Control = False And e.Shift = True And e.KeyCode = 72 Then
            '        Test = txtWord.SelectionStart
            '        txtWord.Text = txtWord.Text.Insert(txtWord.SelectionStart, "খ")
            '        e.SuppressKeyPress = False
            '        txtWord.SelectionStart = Test + 1
            '    End If
        End If

    End Sub

    Public Sub AddElementToStringArray(ByVal stringToAdd As String)
        ReDim Preserve myStrings(myStringElements)
        myStrings(myStringElements) = stringToAdd
        myStringElements += 1
    End Sub

    Private Sub Button9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button9.Click
        'Dim dtMainTable As DataTable = New DataTable

        'Dim cmd As New OleDbCommand("SELECT * FROM MainTable", objConn)
        'Dim rs As OleDbDataReader = cmd.ExecuteReader
        'If rs.HasRows Then
        '    dtMainTable.Load(rs)
        'End If
        'rs.Close()
        'For i As Integer = 0 To 2000 'dtMainTable.Rows.Count - 1
        '    Dim id As Integer = dtMainTable.Rows(i).Item("ID")
        '    Dim mainWord As String = IIf(IsDBNull(dtMainTable.Rows(i).Item("MyWord")), "", dtMainTable.Rows(i).Item("MyWord"))
        '    If mainWord <> "" Then
        '        mainWord = Encrypt(mainWord, strEncodeString)
        '    End If
        '    Dim AsMeaning As String = IIf(IsDBNull(dtMainTable.Rows(i).Item("AsMeaning_old")), "", dtMainTable.Rows(i).Item("AsMeaning_old")) & " "
        '    If AsMeaning <> "" Then
        '        AsMeaning = Encrypt(AsMeaning, strEncodeString)
        '    End If
        '    Dim d As String = Decrypt(AsMeaning, strEncodeString)

        '    Dim EngMeaning As String = IIf(IsDBNull(dtMainTable.Rows(i).Item("EngMeaning_old")), "", dtMainTable.Rows(i).Item("EngMeaning_old"))
        '    If EngMeaning <> "" Then
        '        EngMeaning = Encrypt(EngMeaning, strEncodeString)
        '    End If
        '    Dim Antonyms As String = IIf(IsDBNull(dtMainTable.Rows(i).Item("Antonyms_old")), "", dtMainTable.Rows(i).Item("Antonyms_old"))
        '    If Antonyms <> "" Then
        '        Antonyms = Encrypt(Antonyms, strEncodeString)
        '    End If
        '    Dim Synonyms As String = IIf(IsDBNull(dtMainTable.Rows(i).Item("Synonyms_old")), "", dtMainTable.Rows(i).Item("Synonyms_old"))
        '    If Synonyms <> "" Then
        '        Synonyms = Encrypt(Synonyms, strEncodeString)
        '    End If
        '    'Dim cmd1 As New OleDbCommand("UPDATE MainTable SET Antonyms='" & Antonyms & "', Synonyms='" & _
        '    '                             Synonyms & "' WHERE ID=" & id, objConn)

        '    Dim cmd1 As New OleDbCommand("UPDATE MainTable SET newword='" & mainWord & "',AsMeaning='" & AsMeaning & "', EngMeaning='" & _
        '                                 EngMeaning & "', Antonyms='" & Antonyms & "', Synonyms='" & _
        '                                 Synonyms & "' WHERE ID=" & id, objConn)
        '    cmd1.ExecuteNonQuery()

        '    'Button9.Text = id
        '    btnClear.Text = i
        '    btnClear.Refresh()
        'Next

        ' '===== set the limit to update the table=======================================
        'Dim lowerID As Integer = 5000
        'Dim upperID As Integer = 5100

        'Dim newword As String = ""
        'Dim AsMeaning As String = ""
        'Dim EngMeaning As String = ""
        'Dim Antonyms As String = ""
        'Dim Synonyms As String = ""
        'Dim id As Integer = 0
        'Try
        '    Dim cmd As New OleDbCommand("SELECT ID, MyWord,AsMeaning_old, EngMeaning_old,Antonyms_old,Synonyms_old " & _
        '                                "FROM MainTable WHERE ID>=" & lowerID & " AND ID<=" & upperID & " ORDER BY ID", objConn)
        '    Dim rs1 As OleDbDataReader = cmd.ExecuteReader
        '    If rs1.HasRows Then
        '        Do While rs1.Read
        '            'id = 0
        '            'newword = ""
        '            'AsMeaning = ""
        '            'EngMeaning = ""
        '            'Antonyms = ""
        '            'Synonyms = ""

        '            id = IIf(IsDBNull(rs1("ID")), 0, rs1("ID"))
        '            newword = IIf(IsDBNull(rs1("MyWord")), "", rs1("MyWord"))
        '            If newword <> "" Then
        '                newword = Encrypt(newword, strEncodeString)
        '            End If
        '            AsMeaning = IIf(IsDBNull(rs1("AsMeaning_old")), "", rs1("AsMeaning_old"))
        '            If AsMeaning <> "" Then
        '                AsMeaning = Encrypt(AsMeaning, strEncodeString)
        '            End If
        '            EngMeaning = IIf(IsDBNull(rs1("EngMeaning_old")), "", rs1("EngMeaning_old"))
        '            If EngMeaning <> "" Then
        '                EngMeaning = Encrypt(EngMeaning, strEncodeString)
        '            End If
        '            Antonyms = IIf(IsDBNull(rs1("Antonyms_old")), "", rs1("Antonyms_old"))
        '            If Antonyms <> "" Then
        '                Antonyms = Encrypt(Antonyms, strEncodeString)
        '            End If
        '            Synonyms = IIf(IsDBNull(rs1("Synonyms_old")), "", rs1("Synonyms_old"))
        '            If Synonyms <> "" Then
        '                Synonyms = Encrypt(Synonyms, strEncodeString)
        '            End If
        '            'Dim cmd1 As New OleDbCommand("UPDATE MainTable SET Antonyms='" & Antonyms & "', Synonyms='" & _
        '            '                             Synonyms & "' WHERE ID=" & id, objConn)

        '            Dim cmd1 As New OleDbCommand("UPDATE MainTable SET newword='" & newword & "',AsMeaning='" & AsMeaning & "', EngMeaning='" & _
        '                                 EngMeaning & "', Antonyms='" & Antonyms & "', Synonyms='" & _
        '                                Synonyms & "' WHERE ID=" & id, objConn)
        '            Button9.Text = id
        '            Button9.Refresh()
        '        Loop
        '        rs1.Close()

        '    End If
        'Catch ex As Exception
        '    MsgBox(ex.Message)
        '    MsgBox("Error in loading the data.", MsgBoxStyle.Critical, "Error")
        'End Try
        '''''''=============================================================



        'Dim lowerID As Integer = 43921
        'Dim upperID As Integer = 70000

        'Try
        '    Dim cmd As New OleDbCommand("SELECT ID, Myword, AsMeaning, EngMeaning,Antonyms,Synonyms " & _
        '                                "FROM MainTable WHERE ID>=" & lowerID & " AND ID<=" & upperID & " ORDER BY ID", objConn)
        '    Dim rs1 As OleDbDataReader = cmd.ExecuteReader
        '    If rs1.HasRows Then
        '        Do While rs1.Read
        '            Dim id As Integer = rs1("ID")
        '            Dim myWord As String = IIf(IsDBNull(rs1("MyWord")), "", rs1("MyWOrd"))
        '            Dim AsMeaning As String = IIf(IsDBNull(rs1("AsMeaning")), "", rs1("AsMeaning")) & " "
        '            Dim EngMeaning As String = IIf(IsDBNull(rs1("EngMeaning")), "", rs1("EngMeaning"))
        '            Dim Antonyms As String = IIf(IsDBNull(rs1("Antonyms")), "", rs1("Antonyms"))
        '            Dim Synonyms As String = IIf(IsDBNull(rs1("Synonyms")), "", rs1("Synonyms"))
        '            Dim cmd1 As New OleDbCommand("INSERT INTO NewTable (ID,Myword,AsMeaning,EngMeaning,Antonyms,Synonyms) " & _
        '            " VALUES(" & id & ",'" & myWord & "','" & AsMeaning & "','" & EngMeaning & "','" & _
        '             Antonyms & "','" & Synonyms & "')", objConn)

        '            cmd1.ExecuteNonQuery()
        '            Button9.Text = id
        '        Loop
        '        rs1.Close()

        '    End If
        'Catch ex As Exception
        '    MsgBox(ex.Message)
        '    MsgBox("Error in loading the data.", MsgBoxStyle.Critical, "Error")
        'End Try

        ''''================================ encrypt word character by character =====================================
        Dim lID As Integer = 1001
        Dim uID As Integer = 2006

        Try
            Dim cmd As New OleDbCommand("SELECT ID, MyWord_old FROM MainTable WHERE ID>=" & lID & " AND ID<=" & uID & " ORDER BY ID", objConn)
            Dim rs1 As OleDbDataReader = cmd.ExecuteReader
            If rs1.HasRows Then
                Do While rs1.Read
                    Dim id As Integer = rs1("ID")
                    Dim myWord As String = IIf(IsDBNull(rs1("MyWord_old")), "", rs1("MyWord_old"))
                    Dim encyptedWord As String = EachCharacterEncrypt(myWord, strEncodeString)
                    'For i As Integer = 0 To myWord.Length - 1
                    '    encyptedWord = encyptedWord & Encrypt(myWord.Substring(i, 1), strEncodeString)
                    'Next
                    Dim cmd1 As New OleDbCommand("UPDATE MainTable SET MyWord='" & encyptedWord & "' WHERE ID=" & id, objConn)
                    cmd1.ExecuteNonQuery()
                Loop
                rs1.Close()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            MsgBox("Error in loading the data.", MsgBoxStyle.Critical, "Error")
        End Try

        ' ''====Encrypt English Table=====================
        'Dim lowr As Integer = 10001
        'Dim uppr As Integer = 20000
        'Try
        '    Dim cmd As New OleDbCommand("SELECT ID,EngAsMeaning_old FROM EnglishWords WHERE  ID>=" & lowr & " AND ID<=" & uppr & " ORDER BY ID", objConn)
        '    Dim rs1 As OleDbDataReader = cmd.ExecuteReader
        '    If rs1.HasRows Then
        '        Do While rs1.Read
        '            Dim id As Integer = rs1("ID")
        '            'Dim myWord As String = IIf(IsDBNull(rs1("EngWord_old")), "", rs1("EngWord_old"))
        '            'Dim encyptedWord As String = EachCharacterEncrypt(myWord, strEncodeString)
        '            Dim AsMeaning As String = IIf(IsDBNull(rs1("EngAsMeaning_old")), "", rs1("EngAsMeaning_old"))
        '            If AsMeaning <> "" Then
        '                AsMeaning = Encrypt(AsMeaning, "s3e3df5")
        '            End If
        '            Dim cmd1 As New OleDbCommand("UPDATE EnglishWords SET  EngAsMeaning='" & AsMeaning & "' WHERE ID=" & id, objConn)
        '            cmd1.ExecuteNonQuery()
        '        Loop
        '        rs1.Close()

        '    End If
        'Catch ex As Exception
        '    MsgBox(ex.Message)
        'End Try

        MsgBox("Done", MsgBoxStyle.Critical)
    End Sub


    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub Button10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button10.Click
        'Dim strSelect As String = "SELECT * FROM MainTable" ' WHERE left(MyWord, " & Len(myval) & ")= '" & myval & "'"
        'Dim dscmd As New OleDbDataAdapter(strSelect, objConn)

        ' '' Load a data set.
        'Dim ds As New DataSet()
        ''dscmd.Fill(ds, "AllWords")



        ''Do something with the data set.
        'Dim myDataTable As DataTable = ds.Tables.Item("AllWords")
        ''dt.Select("MyWord LIKE '" & myval & "'")


        '' ''myDataTable.DefaultView.RowFilter = String.Format("[Name] LIKE '{0}%' AND [Date] > #{1:M/dd/yyyy}#",
        '' ''                                          nameTextBox.Text,
        '' ''                                          datePicker.Value)

        'myDataTable.DefaultView.RowFilter = String.Format("left(MyWord, " & Len(myval) & ")= '" & myval & "'")
    End Sub


    Private Sub btnBack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBack.Click

        'If isLastIndex = True Then
        '    wordSelect = 1
        '    Exit Sub
        'End If
        If storeWord.Count = 0 Then
            Exit Sub
        ElseIf storeWord.Count > 0 Then
            Dim s As String = lblDictword.Text.Trim
            storedPrevWord.Add(lblDictword.Text.Trim)
        End If

        Try
            If wordSelect = 0 Then
                ' '''word select 0 means last action was MOUSE CLICK IN MEANING BOX
                Dim x As Integer = storeWord.Count
                If IsUnicode(storeWord.Item(x - 1)) Then
                    rbtnAssamese.Checked = True
                Else
                    rbtnEnglish.Checked = True
                End If

                txtWord.Text = storeWord.Item(x - 1)
                If x > 0 Then
                    lastSelectIndex = x - 1
                End If
                If lastSelectIndex = 0 Then
                    'isLastIndex = True
                    'isLastPreviosIndex = False
                    Exit Sub
                End If
            ElseIf wordSelect = 1 Then

                '''''word select 1 means last action was BACK BUTTON CLICK 
                If lastSelectIndex > 0 Then
                    If IsUnicode(storeWord.Item(lastSelectIndex - 1)) Then
                        rbtnAssamese.Checked = True
                    Else
                        rbtnEnglish.Checked = True
                    End If
                    txtWord.Text = storeWord.Item(lastSelectIndex - 1)
                End If
                If lastSelectIndex > 0 Then
                    lastSelectIndex = lastSelectIndex - 1
                End If
                If lastSelectIndex = 0 Then
                    isLastIndex = True
                    isLastPreviosIndex = False
                    Exit Sub
                End If
            ElseIf wordSelect = 2 Then
                ''''  word select 3 means last action is LISTBOX INDEX CHANGE

                'Dim x As Integer = storeWord.Count
                'If IsUnicode(storeWord.Item(x - 1)) Then
                '    rbtnAssamese.Checked = True
                'Else
                '    rbtnEnglish.Checked = True
                'End If

                'txtWord.Text = storeWord.Item(x - 1)
                'If x <> 0 Then
                '    lastSelectIndex = x - 1
                'End If
            ElseIf wordSelect = 3 Then
                ''''  word select 3 means last action is LISTBOX INDEX CHANGE

                Dim x As Integer = storeWord.Count
                If IsUnicode(storeWord.Item(x - 1)) Then
                    rbtnAssamese.Checked = True
                Else
                    rbtnEnglish.Checked = True
                End If

                txtWord.Text = storeWord.Item(x - 1)
                If x <> 0 Then
                    lastSelectIndex = x - 1
                End If
                If lastSelectIndex = 0 Then
                    'isLastIndex = True
                    'isLastPreviosIndex = False
                    Exit Sub
                End If
            End If
        Catch ex As Exception
            Exit Sub
        End Try
        wordSelect = 1
    End Sub

    Private Sub btnForward_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnForward.Click

        Dim word As String = lblDictword.Text.ToString.Trim
        If storedPrevWord.Count = 0 Then
            wordSelect = 3
            Exit Sub
        End If
        If isLastPreviosIndex = True Then
            wordSelect = 3
            Exit Sub
        End If
        wordSelect = 3
        Try
            ''''''  flag should be there to dectect the BACK BUTTON Click and PREV-BUTTON CLICK...............

            Dim x As Integer = storedPrevWord.Count
            If IsUnicode(storedPrevWord.Item(x - 1)) Then
                rbtnAssamese.Checked = True
            Else
                rbtnEnglish.Checked = True
            End If

            txtWord.Text = storedPrevWord.Item(x - 1)
            If x <> 0 Then
                prevSelectIndex = x - 1
            End If
            If prevSelectIndex = 0 Then
                isLastPreviosIndex = True
                isLastIndex = False
                Exit Sub
            End If
        Catch ex As Exception
            Exit Sub
        End Try
        storeWord.Add(word)


    End Sub

    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click
        If lblDictword.Text <> "" Then
            Clipboard.SetText(lblDictword.Text.Trim)
        End If
    End Sub


    
End Class