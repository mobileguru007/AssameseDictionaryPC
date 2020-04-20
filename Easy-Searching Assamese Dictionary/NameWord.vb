Imports System.Data.OleDb
Imports System.Windows.Forms.DataGrid

Public Class NameWord
    Dim sChar As Object
    Dim btn As DataGridViewButtonColumn

    Private Sub RadioButton1_CheckedChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs)
        lvNames.Items.Clear()
        txtAssMean.Text = ""
        txtEngMean.Text = ""
        lvNames.Font = New System.Drawing.Font("Asomiya_Rohini", 14.25!, FontStyle.Regular, GraphicsUnit.Point, CType(0, Byte))
        'lvProbableWord.Font = New System.Drawing.Font("Asomiya_Rohini", 14.25!, FontStyle.Regular, GraphicsUnit.Point, CType(0, Byte))

        'Label4.Text = "সম্ভাব্য শব্দৰ তালিকা"
        txtWord.Text = ""
        txtWord.Font = New System.Drawing.Font("Asomiya_Rohini", 14.25!, FontStyle.Regular, GraphicsUnit.Point, CType(0, Byte))
        txtWord.Focus()
        lvNames.Visible = True
        'lvProbableWord.Visible = True
        lblEngMean.Visible = True
        lblEngMean.Visible = True
        txtEngMean.Visible = True
        Me.txtAssMean.Size = New System.Drawing.Size(528, 137)
        Label5.Text = "অসমীয়া শব্দটো টাইপ কৰক"
        Label3.Text = "প্ৰয়োজনীয় শব্দটো ক্লিক কৰক"
        lblAssMean.Text = "অসমীয়া অর্থ"
        lblEngMean.Text = "ইংৰাজী অর্থ"
        'Label4.Font = New System.Drawing.Font("Asomiya_Rohini", 12.25!, FontStyle.Regular, GraphicsUnit.Point, CType(0, Byte))
        Label5.Font = New System.Drawing.Font("Asomiya_Rohini", 12.25!, FontStyle.Regular, GraphicsUnit.Point, CType(0, Byte))
        Label3.Font = New System.Drawing.Font("Asomiya_Rohini", 12.25!, FontStyle.Regular, GraphicsUnit.Point, CType(0, Byte))
        lblAssMean.Font = New System.Drawing.Font("Asomiya_Rohini", 12.25!, FontStyle.Regular, GraphicsUnit.Point, CType(0, Byte))
        lblEngMean.Font = New System.Drawing.Font("Asomiya_Rohini", 12.25!, FontStyle.Regular, GraphicsUnit.Point, CType(0, Byte))
        txtAssMean.Font = New System.Drawing.Font("Geetanjali", 18.0!, FontStyle.Regular, GraphicsUnit.Point, CType(0, Byte))
    End Sub

    Private Sub txtWord_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtWord.KeyPress
        If Val(e.KeyChar) = 108 Then
            Me.Close()
        End If
    End Sub


    Function showengwords(ByVal myval As String, Optional ByVal track As Integer = 0) As Boolean
        If track = 0 Then
            If Len(myval) = 1 Then myval = "len(eword)>=1 and len(eword)<=40 and left(eword, " & Len(myval) & ")= '" & myval.Substring(0, 1) & "'" 'myval.Substring(1) & "'"
            If Len(myval) = 2 Then myval = "len(eword)>=2 and len(eword)<=45 and left(eword, " & Len(myval) & ")= '" & myval.Substring(0, 2) & "'"
            If Len(myval) = 3 Then myval = "len(eword)>=3 and len(eword)<=50 and left(eword, " & Len(myval) & ")= '" & myval.Substring(0, 3) & "'"
            If Len(myval) = 4 Then myval = "len(eword)>=4 and len(eword)<=65 and left(eword, " & Len(myval) & ")= '" & myval.Substring(0, 4) & "'"
            If Len(myval) = 5 Then myval = "len(eword)>=5 and len(eword)<=70 and left(eword, " & Len(myval) & ")= '" & myval.Substring(0, 5) & "'"
            If Len(myval) = 6 Then myval = "len(eword)>=6 and len(eword)<=75 and left(eword, " & Len(myval) & ")= '" & myval.Substring(0, 6) & "'"
            If Len(myval) = 7 Then myval = "len(eword)>=7 and len(eword)<=80 and left(eword, " & Len(myval) & ")= '" & myval.Substring(0, 7) & "'"
            If Len(myval) = 8 Then myval = "len(eword)>=8 and len(eword)<=85 and left(eword, " & Len(myval) & ")= '" & myval.Substring(0, 8) & "'"
            If Len(myval) = 9 Then myval = "len(eword)>=9 and len(eword)<=90 and left(eword, " & Len(myval) & ")= '" & myval.Substring(0, 9) & "'"
            If Len(myval) = 10 Then myval = "len(eword)>=10 and len(eword)<=95 and left(eword, " & Len(myval) & ")= '" & myval.Substring(0, 10) & "'"
            If Len(myval) = 11 Then myval = "len(eword)>=11 and len(eword)<=100 and left(eword, " & Len(myval) & ")= '" & myval.Substring(0, 11) & "'"
            If Len(myval) = 12 Then myval = "len(eword)>=12 and len(eword)<=105 and left(eword, " & Len(myval) & ")= '" & myval.Substring(0, 12) & "'"
            If Len(myval) = 13 Then myval = "len(eword)>=13  and left(eword, " & Len(myval) & ")= '" & myval.Substring(0, 13) & "'"
            If Len(myval) = 14 Then myval = "len(eword)>=14  and left(eword, " & Len(myval) & ")= '" & myval.Substring(0, 14) & "'"
            If Len(myval) = 15 Then myval = "len(eword)>=15  and left(eword, " & Len(myval) & ")= '" & myval.Substring(0, 15) & "'"
            If Len(myval) = 16 Then myval = "len(eword)>=16  and left(eword, " & Len(myval) & ")= '" & myval.Substring(0, 16) & "'"
            If Len(myval) = 17 Then myval = "len(eword)>=17  and left(eword, " & Len(myval) & ")= '" & myval.Substring(0, 17) & "'"
            If Len(myval) = 18 Then myval = "len(eword)>=18  and left(eword, " & Len(myval) & ")= '" & myval.Substring(0, 18) & "'"
            If Len(myval) = 19 Then myval = "len(eword)>=19  and left(eword, " & Len(myval) & ")= '" & myval.Substring(0, 19) & "'"
            If Len(myval) = 20 Then myval = "len(eword)>=20  and left(eword, " & Len(myval) & ")= '" & myval.Substring(0, 20) & "'"
            If Len(myval) = 21 Then myval = "len(eword)>=21  and left(eword, " & Len(myval) & ")= '" & myval.Substring(0, 21) & "'"
            If Len(myval) = 22 Then myval = "len(eword)>=22  and left(eword, " & Len(myval) & ")= '" & myval.Substring(0, 22) & "'"
            If Len(myval) = 23 Then myval = "len(eword)>=23  and left(eword, " & Len(myval) & ")= '" & myval.Substring(0, 23) & "'"
            If Len(myval) = 24 Then myval = "len(eword)>=24  and left(eword, " & Len(myval) & ")= '" & myval.Substring(0, 24) & "'"
            If Len(myval) = 25 Then myval = "len(eword)>=25  and left(eword, " & Len(myval) & ")= '" & myval.Substring(0, 25) & "'"
            If Len(myval) = 26 Then myval = "len(eword)>=26  and left(eword, " & Len(myval) & ")= '" & myval.Substring(0, 26) & "'"
            If Len(myval) = 27 Then myval = "len(eword)>=27  and left(eword, " & Len(myval) & ")= '" & myval.Substring(0, 27) & "'"
            If Len(myval) = 28 Then myval = "len(eword)>=28  and left(eword, " & Len(myval) & ")= '" & myval.Substring(0, 28) & "'"

            If Len(myval) = 29 Then myval = "len(eword)>=29  and left(eword, " & Len(myval) & ")= '" & myval.Substring(0, 29) & "'"
            If Len(myval) = 30 Then myval = "len(eword)>=30  and left(eword, " & Len(myval) & ")= '" & myval.Substring(0, 30) & "'"
            If Len(myval) = 31 Then myval = "len(eword)>=31  and left(eword, " & Len(myval) & ")= '" & myval.Substring(0, 31) & "'"
            If Len(myval) = 32 Then myval = "len(eword)>=32  and left(eword, " & Len(myval) & ")= '" & myval.Substring(0, 32) & "'"
            If Len(myval) = 33 Then myval = "len(eword)>=33  and left(eword, " & Len(myval) & ")= '" & myval.Substring(0, 33) & "'"
            If Len(myval) = 34 Then myval = "len(eword)>=34  and left(eword, " & Len(myval) & ")= '" & myval.Substring(0, 34) & "'"
            If Len(myval) = 35 Then myval = "len(eword)>=35  and left(eword, " & Len(myval) & ")= '" & myval.Substring(0, 35) & "'"
            If Len(myval) = 36 Then myval = "len(eword)>=36  and left(eword, " & Len(myval) & ")= '" & myval.Substring(0, 36) & "'"
            If Len(myval) = 37 Then myval = "len(eword)>=37  and left(eword, " & Len(myval) & ")= '" & myval.Substring(0, 37) & "'"
            If Len(myval) = 38 Then myval = "len(eword)>=38  and left(eword, " & Len(myval) & ")= '" & myval.Substring(0, 38) & "'"
            If Len(myval) = 39 Then myval = "len(eword)>=39  and left(eword, " & Len(myval) & ")= '" & myval.Substring(0, 39) & "'"
            If Len(myval) = 40 Then myval = "len(eword)>=40  and left(eword, " & Len(myval) & ")= '" & myval.Substring(0, 40) & "'"

            If Len(myval) = 41 Then myval = "len(eword)>=41  and left(eword, " & Len(myval) & ")= '" & myval.Substring(0, 41) & "'"
            If Len(myval) = 42 Then myval = "len(eword)>=42  and left(eword, " & Len(myval) & ")= '" & myval.Substring(0, 42) & "'"
            If Len(myval) = 43 Then myval = "len(eword)>=43  and left(eword, " & Len(myval) & ")= '" & myval.Substring(0, 43) & "'"
            If Len(myval) = 44 Then myval = "len(eword)>=44  and left(eword, " & Len(myval) & ")= '" & myval.Substring(0, 44) & "'"
            If Len(myval) = 45 Then myval = "len(eword)>=45  and left(eword, " & Len(myval) & ")= '" & myval.Substring(0, 45) & "'"
            If Len(myval) = 46 Then myval = "len(eword)>=46  and left(eword, " & Len(myval) & ")= '" & myval.Substring(0, 46) & "'"
            If Len(myval) = 47 Then myval = "len(eword)>=47  and left(eword, " & Len(myval) & ")= '" & myval.Substring(0, 47) & "'"
            If Len(myval) = 48 Then myval = "len(eword)>=48  and left(eword, " & Len(myval) & ")= '" & myval.Substring(0, 48) & "'"
            If Len(myval) = 49 Then myval = "len(eword)>=49  and left(eword, " & Len(myval) & ")= '" & myval.Substring(0, 49) & "'"
            Try
                lvNames.Items.Clear()
                If myval = "" Then
                    Exit Function
                End If
                Dim myStr As String = Nothing
                myStr = "SELECT ID,eword FROM engtable WHERE " & myval & " ORDER BY  eword, LEN(eword) ASC"
                Dim objCmd As New OleDbCommand(myStr, objConn)
                Dim rs As OleDbDataReader = objCmd.ExecuteReader
                If rs.HasRows Then
                    Dim xItem As ListViewItem
                    Do While rs.Read
                        xItem = lvNames.Items.Add(rs("ID"), IIf(IsDBNull(rs("eword")), "", rs("eword")), "")
                    Loop
                End If
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If
    End Function

    Private Sub frmWordSearch_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'lvProbableWord.Visible = True
        getConn()
        txtWord.Focus()
        loadComboCharacters(gvComposit)
        Me.Size = New System.Drawing.Size(900, 663)
        LoadAllNames()

        'Try
        '    'If IsRegistered = False Then
        '    '    GroupBox4.Enabled = False
        '    '    gvComposit.Enabled = False
        '    '    Dim count As Integer = 0
        '    '    Dim cmd As New OleDbCommand("SELECT COUNT(Word) AS Total FROM Words", objConn)
        '    '    Dim rs As OleDbDataReader = cmd.ExecuteReader
        '    '    If rs.HasRows Then
        '    '        rs.Read()
        '    '        count = IIf(IsDBNull(rs("Total")), 0, rs("Total"))
        '    '    End If
        '    '    If count > 4000 Then
        '    '        GroupBox4.Enabled = False
        '    '        gvComposit.Enabled = False
        '    '        lvWords.Enabled = False
        '    '    End If
        '    'End If
        'Catch ex As Exception
        '    Exit Sub
        'End Try

    End Sub
    Private Function LoadAllNames() As Boolean
        Try
            lvNames.Items.Clear()
            Dim myStr As String = Nothing
            myStr = "SELECT ID, NameWord, AssMeaning FROM NameWord ORDER BY ID ASC"

            Dim objCmd As New OleDbCommand(myStr, objConn)
            Dim rs As OleDbDataReader = objCmd.ExecuteReader
            If rs.HasRows Then
                Do While rs.Read
                    Dim xItem As ListViewItem
                    xItem = lvNames.Items.Add(rs("ID"), IIf(IsDBNull(rs("NameWord")), "", rs("NameWord")), "")
                Loop
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Function

    Protected Sub composeQueryStr(ByVal inputTxt As String, ByVal cmdTxt As String)
        If txtWord.Text.Trim.Length > 100 Then Exit Sub
        'If rbtnAssamese.Checked = False Then
        '    MsgBox("Please select the Assamese option.", MsgBoxStyle.Critical)
        '    txtWord.Focus()
        '    Exit Sub
        'End If
        If inputTxt.Length > 0 Then
            txtWord.Text = inputTxt & cmdTxt
        Else
            txtWord.Text = cmdTxt
        End If
    End Sub

    Function ShowWords(ByRef Mybox As ListView, ByVal myval As String, Optional ByVal track As Integer = 0) As Boolean
        If track = 0 Then
            If Len(myval) = 1 Then myval = "len(word)>=1 and len(word)<=40 and left(word, " & Len(myval) & ")= '" & myval.Substring(0, 1) & "'" 'myval.Substring(1) & "'"
            If Len(myval) = 2 Then myval = "len(word)>=2 and len(word)<=45 and left(word, " & Len(myval) & ")= '" & myval.Substring(0, 2) & "'"
            If Len(myval) = 3 Then myval = "len(word)>=3 and len(word)<=50 and left(word, " & Len(myval) & ")= '" & myval.Substring(0, 3) & "'"
            If Len(myval) = 4 Then myval = "len(word)>=4 and len(word)<=65 and left(word, " & Len(myval) & ")= '" & myval.Substring(0, 4) & "'"
            If Len(myval) = 5 Then myval = "len(word)>=5 and len(word)<=70 and left(word, " & Len(myval) & ")= '" & myval.Substring(0, 5) & "'"
            If Len(myval) = 6 Then myval = "len(word)>=6 and len(word)<=75 and left(word, " & Len(myval) & ")= '" & myval.Substring(0, 6) & "'"
            If Len(myval) = 7 Then myval = "len(word)>=7 and len(word)<=80 and left(word, " & Len(myval) & ")= '" & myval.Substring(0, 7) & "'"
            If Len(myval) = 8 Then myval = "len(word)>=8 and len(word)<=85 and left(word, " & Len(myval) & ")= '" & myval.Substring(0, 8) & "'"
            If Len(myval) = 9 Then myval = "len(word)>=9 and len(word)<=90 and left(word, " & Len(myval) & ")= '" & myval.Substring(0, 9) & "'"
            If Len(myval) = 10 Then myval = "len(word)>=10 and len(word)<=95 and left(word, " & Len(myval) & ")= '" & myval.Substring(0, 10) & "'"
            If Len(myval) = 11 Then myval = "len(word)>=11 and len(word)<=100 and left(word, " & Len(myval) & ")= '" & myval.Substring(0, 11) & "'"
            If Len(myval) = 12 Then myval = "len(word)>=12 and len(word)<=105 and left(word, " & Len(myval) & ")= '" & myval.Substring(0, 12) & "'"
            If Len(myval) = 13 Then myval = "len(word)>=13  and left(word, " & Len(myval) & ")= '" & myval.Substring(0, 13) & "'"
            If Len(myval) = 14 Then myval = "len(word)>=14  and left(word, " & Len(myval) & ")= '" & myval.Substring(0, 14) & "'"
            If Len(myval) = 15 Then myval = "len(word)>=15  and left(word, " & Len(myval) & ")= '" & myval.Substring(0, 15) & "'"
            If Len(myval) = 16 Then myval = "len(word)>=16  and left(word, " & Len(myval) & ")= '" & myval.Substring(0, 16) & "'"
            If Len(myval) = 17 Then myval = "len(word)>=17  and left(word, " & Len(myval) & ")= '" & myval.Substring(0, 17) & "'"
            If Len(myval) = 18 Then myval = "len(word)>=18  and left(word, " & Len(myval) & ")= '" & myval.Substring(0, 18) & "'"
            If Len(myval) = 19 Then myval = "len(word)>=19  and left(word, " & Len(myval) & ")= '" & myval.Substring(0, 19) & "'"
            If Len(myval) = 20 Then myval = "len(word)>=20  and left(word, " & Len(myval) & ")= '" & myval.Substring(0, 20) & "'"
            If Len(myval) = 21 Then myval = "len(word)>=21  and left(word, " & Len(myval) & ")= '" & myval.Substring(0, 21) & "'"
            If Len(myval) = 22 Then myval = "len(word)>=22  and left(word, " & Len(myval) & ")= '" & myval.Substring(0, 22) & "'"
            If Len(myval) = 23 Then myval = "len(word)>=23  and left(word, " & Len(myval) & ")= '" & myval.Substring(0, 23) & "'"
            If Len(myval) = 24 Then myval = "len(word)>=24  and left(word, " & Len(myval) & ")= '" & myval.Substring(0, 24) & "'"
            If Len(myval) = 25 Then myval = "len(word)>=25  and left(word, " & Len(myval) & ")= '" & myval.Substring(0, 25) & "'"
            If Len(myval) = 26 Then myval = "len(word)>=26  and left(word, " & Len(myval) & ")= '" & myval.Substring(0, 26) & "'"
            If Len(myval) = 27 Then myval = "len(word)>=27  and left(word, " & Len(myval) & ")= '" & myval.Substring(0, 27) & "'"
            If Len(myval) = 28 Then myval = "len(word)>=28  and left(word, " & Len(myval) & ")= '" & myval.Substring(0, 28) & "'"

            If Len(myval) = 29 Then myval = "len(word)>=29  and left(word, " & Len(myval) & ")= '" & myval.Substring(0, 29) & "'"
            If Len(myval) = 30 Then myval = "len(word)>=30  and left(word, " & Len(myval) & ")= '" & myval.Substring(0, 30) & "'"
            If Len(myval) = 31 Then myval = "len(word)>=31  and left(word, " & Len(myval) & ")= '" & myval.Substring(0, 31) & "'"
            If Len(myval) = 32 Then myval = "len(word)>=32  and left(word, " & Len(myval) & ")= '" & myval.Substring(0, 32) & "'"
            If Len(myval) = 33 Then myval = "len(word)>=33  and left(word, " & Len(myval) & ")= '" & myval.Substring(0, 33) & "'"
            If Len(myval) = 34 Then myval = "len(word)>=34  and left(word, " & Len(myval) & ")= '" & myval.Substring(0, 34) & "'"
            If Len(myval) = 35 Then myval = "len(word)>=35  and left(word, " & Len(myval) & ")= '" & myval.Substring(0, 35) & "'"
            If Len(myval) = 36 Then myval = "len(word)>=36  and left(word, " & Len(myval) & ")= '" & myval.Substring(0, 36) & "'"
            If Len(myval) = 37 Then myval = "len(word)>=37  and left(word, " & Len(myval) & ")= '" & myval.Substring(0, 37) & "'"
            If Len(myval) = 38 Then myval = "len(word)>=38  and left(word, " & Len(myval) & ")= '" & myval.Substring(0, 38) & "'"
            If Len(myval) = 39 Then myval = "len(word)>=39  and left(word, " & Len(myval) & ")= '" & myval.Substring(0, 39) & "'"
            If Len(myval) = 40 Then myval = "len(word)>=40  and left(word, " & Len(myval) & ")= '" & myval.Substring(0, 40) & "'"

            If Len(myval) = 41 Then myval = "len(word)>=41  and left(word, " & Len(myval) & ")= '" & myval.Substring(0, 41) & "'"
            If Len(myval) = 42 Then myval = "len(word)>=42  and left(word, " & Len(myval) & ")= '" & myval.Substring(0, 42) & "'"
            If Len(myval) = 43 Then myval = "len(word)>=43  and left(word, " & Len(myval) & ")= '" & myval.Substring(0, 43) & "'"
            If Len(myval) = 44 Then myval = "len(word)>=44  and left(word, " & Len(myval) & ")= '" & myval.Substring(0, 44) & "'"
            If Len(myval) = 45 Then myval = "len(word)>=45  and left(word, " & Len(myval) & ")= '" & myval.Substring(0, 45) & "'"
            If Len(myval) = 46 Then myval = "len(word)>=46  and left(word, " & Len(myval) & ")= '" & myval.Substring(0, 46) & "'"
            If Len(myval) = 47 Then myval = "len(word)>=47  and left(word, " & Len(myval) & ")= '" & myval.Substring(0, 47) & "'"
            If Len(myval) = 48 Then myval = "len(word)>=48  and left(word, " & Len(myval) & ")= '" & myval.Substring(0, 48) & "'"
            If Len(myval) = 49 Then myval = "len(word)>=49  and left(word, " & Len(myval) & ")= '" & myval.Substring(0, 49) & "'"

            Try
                lvNames.Items.Clear()
                If myval = "" Then
                    Exit Function
                End If
                Dim myStr As String = Nothing
                myStr = "SELECT ID, word FROM Words WHERE " & myval & " ORDER BY id, [word] ASC"

                Dim objCmd As New OleDbCommand(myStr, objConn)
                Dim rs As OleDbDataReader = objCmd.ExecuteReader
                If rs.HasRows Then
                    Dim xItem As ListViewItem
                    Do While rs.Read
                        xItem = Mybox.Items.Add(rs("ID"), IIf(IsDBNull(rs("word")), "", rs("word")), "")
                    Loop
                Else
                    ShowWords = False
                    Exit Function
                End If
            Catch ex As Exception
                MsgBox(ex.Message)
                ShowWords = False
                Exit Function
            End Try
        ElseIf track = True Then
            ShowWords = track
            Exit Function
        End If
        ShowWords = True
    End Function


    'Private Sub RadioButton2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    If rbtnEnglish.Checked = True Then
    '        Me.lvWords.Size = New System.Drawing.Size(528, 150)
    '        Me.lvWords.Columns(0).Width = 504
    '        ' Label4.Text = ""
    '        txtWord.Font = New System.Drawing.Font("Times New Roman", 18.0!, FontStyle.Regular, GraphicsUnit.Point, CType(0, Byte))
    '        lvWords.Font = New System.Drawing.Font("Times New Roman", 17.0!, FontStyle.Regular, GraphicsUnit.Point, CType(0, Byte))
    '        If txtWord.Text = "" Then Exit Sub
    '        If Not showengwords(Trim(txtWord.Text), 0) Then
    '            Exit Sub
    '        End If
    '    Else
    '        Me.lvWords.Size = New System.Drawing.Size(287, 150)
    '        Me.lvWords.Columns(0).Width = 250
    '    End If
    'End Sub

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

        xword = New String() {"তত্ত্ব", "নি", "নিঃস", "নী", "ত্র", "ট্র", "-", " ", "ছ", "চ", "চ্ছ্ব", "জ্ব", "জ্জ্ব", "জ", "ঞ্ছ", "ঞ্চ", "ত", "ট", "ত্ত", "ত্ত্ব", "ত্ব", "থ", "ঠ", "দ", "ড", "দ্দ", "ড্ড", "দ্র", "ড্র", "ধ", "ণ", "ন", "ন্ত", "ণ্ট", "ণ্ণ", "ন্ন", "পঁ", "প", "ফঁ", "ফ", "প্ত", "প্ট", "ম্ম", "ন্ম", "জ", "য", "ৰূ", "ৰু", "ৱ", "ব", "স", "শ", "শ্চ", "শ্ছ", "ওত", "ণু", "দু", "দুঃখ", "দুঃস্ব", "খূ", "খু", "ঘূ", "ঘু", "ছু", "পঁ", "প", "ফ", "ফঁ"}
        yword = New String() {"তত্ব", "নিঃ", "নিস", "নি", "ট্র", "ত্র", " ", "-", "চ", "ছ", "চ্ছ", "জ", "জ্ব", "ঝ", "ঞ্চ", "ঞ্ছ", "ট", "ত", "ট্ট", "ত্ব", "ত্ত্ব", "ঠ", "থ", "ড", "দ", "ড্ড", "দ্দ", "ড্র", "দ্র", "ঢ", "ন", "ণ", "ণ্ট", "ন্ত", "ন্ন", "ণ্ণ", "প", "পঁ", "ফ", "ফঁ", "প্ট", "প্ত", "ন্ম", "ম্ম", "য", "জ", "ৰু", "ৰূ", "ব", "ৱ", "শ", "স", "শ্ছ", "শ্চ", "ওতঃ", "নু", "দুঃ", "দুখ", "দুস্ব", "খু", "খূ", "ঘু", "ঘূ", "চু", "প", "পঁ", "ফ", "ফঁ"}

        mword = ""
        For a = 0 To UBound(xword)
            b = InStr(1, sword, xword(a))
            If b > 0 Then
                mword = Replace(sword, xword(a), yword(a))
                Exit For
            End If
        Next

        'If mword <> "" Then
        '    ShowWords(lvProbableWord, Replace(mword, "'", "39"), 0)
        'Else
        '    lvProbableWord.Items.Clear()
        'End If
    End Sub

    Private Sub lbProbAssameseWords_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        btnClear.Focus()
    End Sub

    Private Sub btnClose_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        btnClear.Focus()
    End Sub


    Private Sub gvComposit_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gvComposit.CellContentClick
        'If rbtnAssamese.Checked = False Then
        '    MsgBox("Plese select the Assamese option first.", MsgBoxStyle.Information, "Dictionary")
        '    Exit Sub
        'End If
        If gvComposit.CurrentCell.ColumnIndex = 0 Then Exit Sub
        If gvComposit.CurrentCell.Value = "'" Or gvComposit.CurrentCell.Value = "'Ç" Then Exit Sub
        If gvComposit.CurrentCell.Value <> "" Then
            Dim xText As String = gvComposit.CurrentCell.Value.ToString.Trim
            composeQueryStr(txtWord.Text, xText)
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If txtWord.Text = "" Then Exit Sub
        composeQueryStr(txtWord.Text, " ")
    End Sub

    Private Sub gvCons_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)
        'If rbtnAssamese.Checked = False Then
        '    MsgBox("Plese select the Assamese option first.", MsgBoxStyle.Critical)
        '    Exit Sub
        'End If
    End Sub

    Private Sub gvVowel_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)
        'If rbtnAssamese.Checked = False Then
        '    MsgBox("Plese select the Assamese option first.", MsgBoxStyle.Critical)
        '    Exit Sub
        'End If
    End Sub

    Private Sub gvData_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs)
        'If rbtnAssamese.Checked = False Then
        '    MsgBox("Plese select the Assamese option first.", MsgBoxStyle.Critical)
        '    Exit Sub
        'End If
    End Sub


    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        txtAssMean.Text = ""
        txtEngMean.Text = ""
        'If rbtnAssamese.Checked = True Then
        '    lvWords.Items.Clear()
        '    'lvProbableWord.Items.Clear()
        '    If txtWord.Text.Length = 0 Then
        '        Exit Sub
        '    End If
        '    txtWord.Text = LSet(txtWord.Text, Len(txtWord.Text) - 1)
        '    'lvProbableWord.Items.Clear()
        '    PossibleWord(txtWord.Text.Trim)
        '    ShowWords(lvWords, txtWord.Text.Trim, 0)
        'Else
        '    rbtnEnglish.Checked = True
        '    lvWords.Items.Clear()
        '    'lvProbableWord.Items.Clear()
        '    lvWords.Refresh()
        '    txtWord.Text = LSet(txtWord.Text, Len(txtWord.Text) - 1)
        'End If
        FirstRowSelect()
    End Sub

    Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click
        If txtWord.Text.Trim.Length = 0 Then
            Exit Sub
        End If
        txtWord.Text = ""
        lvNames.Items.Clear()
        'lvProbableWord.Items.Clear()
        txtAssMean.Text = ""
        txtEngMean.Text = ""
        txtWord.Focus()
    End Sub

    Private Sub Command5_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Command5.Click
        'If rbtnAssamese.Checked = False Then
        '    txtWord.Focus()
        '    Exit Sub
        'End If
        'If txtWord.Text = "" Then Exit Sub
        'composeQueryStr(txtWord.Text, " ")
    End Sub

    Private Sub SendLetter(ByVal Letter As String)
        'If rbtnAssamese.Checked = False Then
        '    MsgBox("Please select the Assamese option first.", MsgBoxStyle.Information, "Dictionary")
        '    txtWord.Focus()
        '    Exit Sub
        'End If
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
        SendLetter("র্")
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
        Dim myStr As String = Nothing
        'If rbtnAssamese.Checked = True Then
        '    myStr = "SELECT ameaning, emeaning from Words where id= " & xID '" & Replace(xWord, "'", "''") & "'"
        '    Dim objCmd As New OleDbCommand(myStr, objConn)
        '    Dim rs As OleDbDataReader = objCmd.ExecuteReader
        '    If rs.HasRows Then
        '        rs.Read()
        '        txtAMean.Text = IIf(IsDBNull(rs("ameaning")), "", rs("ameaning"))
        '        If rs("emeaning").ToString = "" Then
        '            txtEMean.Text = "no result."
        '        Else
        '            txtEMean.Text = rs("emeaning")
        '        End If
        '    End If
        'ElseIf rbtnEnglish.Checked = True Then
        '    myStr = "SELECT emeaning, emeaningExp FROM engtable WHERE id=" & xID
        '    Dim objCmd As New OleDbCommand(myStr, objConn)
        '    Dim rs As OleDbDataReader = objCmd.ExecuteReader
        '    If rs.HasRows Then
        '        rs.Read()
        '        If rs("emeaning").ToString = "" Then
        '            txtAMean.Font = New System.Drawing.Font("Times New Roman", 15.0!, FontStyle.Regular, GraphicsUnit.Point, CType(0, Byte))
        '            txtAMean.Text = IIf(IsDBNull(rs("emeaningExp")), "", rs("emeaningExp"))
        '        Else
        '            txtAMean.Font = New System.Drawing.Font("geetanjali", 19.25!, FontStyle.Regular, GraphicsUnit.Point, CType(0, Byte))
        '            txtAMean.Text = IIf(IsDBNull(rs("emeaning")), "", rs("emeaning"))
        '        End If
        '    End If
        'End If
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        SendLetter(Button6.Text)
    End Sub

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        SendLetter("্")
    End Sub

    Private Sub txtWord_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtWord.TextChanged
        txtAssMean.Text = ""
        txtEngMean.Text = ""
        'lvProbableWord.Items.Clear()
        If txtWord.Text.Trim.Length > 49 Then Exit Sub
        If txtWord.Text = "" Then
            lvNames.Items.Clear()
            'lvProbableWord.Items.Clear()
            Exit Sub
        End If
        'If rbtnAssamese.Checked = False Then
        '    If Not showengwords(Trim(txtWord.Text.Trim), 0) Then
        '        Exit Sub
        '    End If
        'Else
        '    'lvProbableWord.Items.Clear()
        '    lvWords.Items.Clear()
        '    PossibleWord(txtWord.Text.Trim)
        '    ShowWords(lvWords, txtWord.Text.Trim, 0)
        'End If
        FirstRowSelect()
    End Sub

    Private Sub FirstRowSelect()
        Try
            '    If lvWords.Items.Count > 0 And lvProbableWord.Items.Count > 0 Then
            '        'lvProbableWord.SelectedIndices.Clear()
            '        'lvProbableWord.HideSelection = True
            '        'lvProbableWord.Refresh()
            '        lvWords.SelectedIndices.Clear()
            '        lvWords.Refresh()
            '        lvWords.HideSelection = False
            '        lvWords.Items(0).Selected = True
            '    Else
            '        If lvWords.Items.Count = 0 Then
            '            'If lvProbableWord.Items.Count <> 0 Then
            '            '    lvWords.SelectedIndices.Clear()
            '            '    lvWords.HideSelection = True
            '            '    lvWords.Refresh()
            '            '    lvProbableWord.SelectedIndices.Clear()
            '            '    lvProbableWord.Refresh()
            '            '    lvProbableWord.HideSelection = False
            '            '    lvProbableWord.Items(0).Selected = True
            '            'End If
            '        Else
            '            lvWords.SelectedIndices.Clear()
            '            lvWords.Refresh()
            '            lvWords.HideSelection = False
            '            lvWords.Items(0).Selected = True
            '        End If
            '    End If
        Catch ex As Exception
            Exit Sub
        End Try
    End Sub

    Private Sub lvWords_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvNames.GotFocus
        If lvNames.Items.Count > 0 Then
            lvNames.HideSelection = False
            'lvProbableWord.SelectedIndices.Clear()
            'lvProbableWord.Refresh()
            'lvProbableWord.HideSelection = True
            LoadMeaning(lvNames.Items(0).Name)
        End If
    End Sub

    Private Sub lvProbableWord_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs)
        'If lvProbableWord.Items.Count > 0 Then
        '    lvProbableWord.HideSelection = False
        '    lvWords.SelectedIndices.Clear()
        '    lvWords.Refresh()
        '    lvWords.HideSelection = True
        '    LoadMeaning(lvProbableWord.Items(0).Name)
        'End If
    End Sub

    Private Sub lvProbableWord_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'If lvProbableWord.SelectedItems.Count <> 0 Then
        '    lvWords.HideSelection = True
        '    LoadMeaning(lvProbableWord.SelectedItems(0).Name)
        'End If
    End Sub

    Private Sub lvWords_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvNames.SelectedIndexChanged
        Try
            Dim xID As String = ""
            txtAssMean.Text = ""
            txtEngMean.Text = ""
            If lvNames.Items.Count = 0 Then Exit Sub
            If lvNames.SelectedItems.Count <> 1 Then Exit Sub
            xID = lvNames.SelectedItems(0).Name
            If xID = "" Then Exit Sub
            Dim myStr As String = Nothing
            myStr = "SELECT * FROM NameWord WHERE ID=" & xID & " ORDER BY ID"     ''" & Replace(lbFakara.SelectedItem.ToString, "'", "''") & "'" 'lvFakara.SelectedItems(0).Tag

            Dim objCmd As New OleDbCommand(myStr, objConn)
            Dim rs As OleDbDataReader = objCmd.ExecuteReader
            If rs.HasRows Then
                rs.Read()
                txtAssMean.Text = IIf(IsDBNull(rs("AssMeaning")), "", rs("AssMeaning"))
                txtEngMean.Text = IIf(IsDBNull(rs("EngMeaning")), "", rs("EngMeaning"))
            End If
            rs.Close()
        Catch ex As Exception
            Exit Sub
        End Try
    End Sub

    Private Sub txtWord_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtWord.LostFocus
        'If lvWords.Items.Count = 0 And lvProbableWord.Items.Count = 0 Then Exit Sub
        'If lvWords.Items.Count = 0 Then
        '    lvProbableWord.Focus()
        'Else
        '    lvWords.Focus()
        'End If
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

End Class