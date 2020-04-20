Imports System.Data.OleDb
Imports System.Data


Imports System.Text
Imports System.IO
Imports System.IO.Compression
Imports System.Text.RegularExpressions
Imports System.Windows.Forms.DataGrid
Imports System.Security.Cryptography


Public Class frmSpellcheck
    'Dim originalString As String = ""
    Dim leftString As String = ""
    Dim rightString As String = ""
    Dim wordList() As String
    Dim currentWordList() As String
    Dim currentString As String = ""



    Dim WrongWordList As ArrayList = New ArrayList
    Dim uniqueWrongList As ArrayList = New ArrayList

    Dim firstWrongWordCount As Integer = 0
    Dim firstWrongWordText As String = ""
    Dim firstWrongWordIndex As Integer = 0

    Dim isChecked As Boolean = False
    Dim xIndex As Integer = 0


    Dim spellCheck As Boolean = False
    Dim ignoreWordList As ArrayList = New ArrayList

    Dim ignoreType As Integer = 0
    Dim uniqueWordList() As String


    Dim isSingeleWordOnly As Boolean = False
    Dim foundInTextFile As Boolean = False


    Dim dtAllWOrd As New DataTable
    Dim txtPath As String = path & "\snew.dll"


    Private Sub getAllWrongWord(ByVal input As String, ByVal startIndex As Integer, ByVal endIndex As Integer)
        Try
            splitOriginalString(input, 200)
            For Each word As String In wordList
                Dim xWord As String = word.Trim
                Dim len As Integer = xWord.Length
                If len > 1 And xWord <> "" And xWord <> " " Then
                    Dim xSerachWord As String = getSearchWord(xWord, len)
                    If xSerachWord.Length > 1 Then
                        UnderlineAllWrongWord(xSerachWord, xIndex, endIndex)
                        xIndex = xIndex + word.Length
                    End If
                End If
            Next
            For x As Integer = 0 To WrongWordList.Count - 1
                If WrongWordList(x).ToString <> "" And WrongWordList(x).ToString <> " " Then
                    Dim addWord As String = getSearchWord(WrongWordList(x).ToString, WrongWordList(x).ToString.Length)
                    If addWord <> "" Or addWord.Length > 1 Then
                        uniqueWrongList.Add(WrongWordList(x))
                    End If
                End If

            Next
            If uniqueWrongList.Count > 0 Then
                For i As Integer = 0 To uniqueWrongList.Count - 1
                    For j As Integer = i + 1 To uniqueWrongList.Count - 1
                        If j > uniqueWrongList.Count - 1 Then Exit For
                        If uniqueWrongList(i) = uniqueWrongList(j) Then
                            uniqueWrongList.RemoveAt(j)
                            j = j - 1
                        End If
                    Next j
                Next i
            End If
        Catch ex As Exception
            Exit Sub
        End Try
    End Sub


    Private Function getSearchWord(ByVal xWord As String, ByVal len As Integer) As String
        If xWord = "" Or xWord = " " Then
            Return ""
            Exit Function
        End If
        Try
            Dim fCh As Char = xWord.Substring(0, 1)
            Dim LCh As Char = xWord.Substring(len - 1)
            If fCh = "" Then
                xWord = xWord.Substring(1, len - 1)
                len = len - 1
                fCh = xWord.Substring(0, 1)
            End If
            If fCh = "‘" Or fCh = "(" Or fCh = "[" Or fCh = " " Or fCh = "" Or fCh = "--" Or fCh = "-" Or fCh = "’)-" Or fCh = "..." Then
                xWord = xWord.Substring(1, len - 1)
                len = len - 1
            End If
            If LCh = "" Or LCh = " " Then
                xWord = xWord.Substring(0, len - 1)
                len = len - 1
                LCh = xWord.Substring(len - 1)
            End If
            If LCh = "‘" Or LCh = "’" Or LCh = ";" Or LCh = ":" Or LCh = "]" Or LCh = ")" Or LCh = "," Or LCh = "।" Or LCh = "(" Or LCh = "[" Or LCh = "." Or LCh = " " Then
                xWord = xWord.Substring(0, len - 1)
            End If
            '===================== using it for second time the same code for some reason========
            len = xWord.Length
            LCh = xWord.Substring(len - 1)
            If LCh = "‘" Or LCh = "’" Or LCh = ";" Or LCh = ":" Or LCh = "]" Or LCh = ")" Or LCh = "," Or LCh = "।" Or LCh = "(" Or LCh = "[" Or LCh = "." Then
                xWord = xWord.Substring(0, len - 1)
            End If
        Catch ex As Exception
            Return xWord = ""
            Exit Function
        End Try
        Return xWord
    End Function

    Private Function getFirstWrongWord(ByVal input As String, ByVal startIndex As Integer, ByVal endIndex As Integer, ByVal type As Integer) As Boolean
        Try
            foundInTextFile = False
            splitOriginalString(input, 200)
            Dim encodeWord As String = ""
            For Each word As String In wordList

                If word <> "" Then
                    Dim xWord As String = word
                    Dim len As Integer = xWord.Length
                    ' ''it is used for all wrong word
                    If wordList.Count = 1 Then
                        isSingeleWordOnly = True
                        txtContent.SelectionStart = 0
                        txtContent.SelectionLength = txtContent.Text.Length 'ppppppppp
                        txtContent.SelectionBackColor = Color.White
                        txtContent.SelectionColor = Color.Black
                    End If
                    If len > 1 And xWord <> "" And xWord <> " " Then
                        xWord = getSearchWord(xWord, len)
                        If xWord.Length > 1 Then
                            Dim isIgnoredWrongWord As Boolean = False
                            If ignoreType = 1 Then
                                If ignoreWordList.Count > 0 Then
                                    For Each Str As String In ignoreWordList
                                        If Str.Contains(xWord) Then
                                            isIgnoredWrongWord = True
                                        End If
                                    Next
                                End If
                            End If
                            If isIgnoredWrongWord = False Then
                                encodeWord = EachCharacterEncrypt(xWord, strEncodeString)

                                Dim myStr As String = "SELECT ID FROM ErrorCollection WHERE WrongWord='" & encodeWord & "'"
                                Dim objCmd As New OleDbCommand(myStr, objConn)
                                Dim rs As OleDbDataReader = objCmd.ExecuteReader
                                If rs.HasRows Then
                                    For i As Integer = startIndex To endIndex
                                        Dim index As Integer = txtContent.Find(xWord, startIndex, endIndex, RichTextBoxFinds.WholeWord)
                                        firstWrongWordText = xWord
                                        firstWrongWordIndex = index
                                        Return True
                                        Exit Function
                                    Next
                                Else
                                    Dim dr() As System.Data.DataRow
                                    dr = dtAllWOrd.Select("MyWord='" & xWord & "'")
                                    If dr.Length = 0 Then
                                        Dim isExists As Integer = 0
                                        Dim encryptedString As String = Encrypt(xWord, strEncodeString)

                                        ''Dim storeString As String = ""
                                        ''For j As Integer = 40001 To 50000 'uniqueWordList.Count - 1
                                        ''    Dim currWord As String = uniqueWordList(j).ToString
                                        ''    If currWord.Length > 0 And currWord <> "" And currWord <> " " Then
                                        ''        'encryptedString = encryptedString & "," & currWord.Substring(1)
                                        ''        storeString = storeString & "," & Encrypt(currWord, strEncodeString)
                                        ''    End If
                                        ''Next

                                        ''If isExists = 0 Then
                                        ''    For j As Integer = 0 To uniqueWordList.Count - 1
                                        ''        Dim currWordDecoded As String = uniqueWordList(j).ToString
                                        ''        If currWordDecoded.Length > 0 And currWordDecoded <> "" And currWordDecoded <> " " Then
                                        ''            If currWordDecoded = encryptedString Then
                                        ''                isExists = 1
                                        ''                Exit For
                                        ''            End If
                                        ''        End If
                                        ''    Next
                                        ''End If

                                        If isExists = 0 Then
                                            For j As Integer = 0 To uniqueWordList.Count - 1
                                                Dim currWordDecoded As String = uniqueWordList(j).ToString
                                                If currWordDecoded.Length > 0 And currWordDecoded <> "" And currWordDecoded <> " " Then
                                                    If currWordDecoded = encryptedString Then
                                                        isExists = 1
                                                        Exit For
                                                    End If
                                                End If
                                            Next
                                        End If

                                        If isExists = 0 Then
                                            Dim index As Integer = txtContent.Find(xWord, startIndex, endIndex, RichTextBoxFinds.WholeWord)
                                            firstWrongWordText = xWord
                                            firstWrongWordIndex = index
                                            foundInTextFile = True
                                            btnAdd.Visible = True
                                            Return True
                                            Exit Function
                                        End If
                                    End If
                                End If
                                rs.Close()
                            End If
                        End If
                    End If
                End If

            Next
        Catch ex As Exception
            'MsgBox(ex.Message)
            firstWrongWordIndex = 0
            firstWrongWordText = ""
            Return False
            Exit Function
        End Try
        Return False
    End Function


    Private Sub UnderlineAllWrongWord(ByVal xWord As String, ByVal startIndex As Integer, ByVal endIndex As Integer)

        Try
            If xWord = "" Then
                Exit Sub
            End If
            Dim ecncodeWord = EachCharacterEncrypt(xWord, strEncodeString)
            If xWord.Length > 1 Then
                Dim myStr As String = "SELECT ID FROM MainTable WHERE MyWord='" & ecncodeWord & "'"
                Dim objCmd As New OleDbCommand(myStr, objConn)
                Dim rs As OleDbDataReader = objCmd.ExecuteReader
                Dim strSearch As String = xWord
                If rs.HasRows Then
                    Dim index As Integer = txtContent.Find(strSearch, startIndex, endIndex, RichTextBoxFinds.WholeWord)
                    startIndex = index
                Else
                    For i As Integer = startIndex To endIndex
                        Dim index As Integer = txtContent.Find(strSearch, startIndex, endIndex, RichTextBoxFinds.WholeWord)
                        If index <> -1 Then
                            txtContent.SelectionStart = index
                            txtContent.SelectionLength = strSearch.Length
                            txtContent.SelectionColor = Color.Chocolate
                            If firstWrongWordCount = 0 Then
                                txtContent.SelectionBackColor = Color.LightBlue
                                firstWrongWordCount = 1
                                firstWrongWordText = strSearch
                                firstWrongWordIndex = index
                            End If

                            startIndex = index + strSearch.Length + 1
                            WrongWordList.Add(strSearch)
                            Exit For
                        End If
                    Next
                End If
                rs.Close()
            End If
        Catch ex As Exception
            Throw
        End Try

    End Sub


    Private Function splitOriginalString(ByVal textToSplit As String, ByVal charCount As Integer) As System.Collections.Queue

        Dim returnQueue As New System.Collections.Queue

        wordList = textToSplit.Split(" ".ToCharArray)

        Dim currentChunk As String = ""

        For index As Integer = 0 To wordList.GetUpperBound(0)

            Dim currentWord As String = wordList(index)

            If currentChunk.Length + currentWord.Length <= charCount Then
                'The phrase is still short enough
                currentChunk += " " & currentWord
            Else
                'The phrase would be too long
                'Add the chunk to the list
                returnQueue.Enqueue(currentChunk)
                'Start a new chunk
                currentChunk = currentWord
            End If

        Next index

        'Reached the end. Add the last chunk to the list
        returnQueue.Enqueue(currentChunk)
        Return returnQueue
    End Function

    Private Function splitUniqueWordList(ByVal textToSplit As String, ByVal charCount As Integer) As System.Collections.Queue

        Dim returnQueue As New System.Collections.Queue

        uniqueWordList = textToSplit.Split(",".ToCharArray)

        Dim currentChunk As String = ""

        For index As Integer = 0 To uniqueWordList.GetUpperBound(0)

            Dim currentWord As String = uniqueWordList(index)

            If currentChunk.Length + currentWord.Length <= charCount Then
                'The phrase is still short enough
                currentChunk += " " & currentWord
            Else
                'The phrase would be too long
                'Add the chunk to the list
                returnQueue.Enqueue(currentChunk)
                'Start a new chunk
                currentChunk = currentWord
            End If

        Next index

        'Reached the end. Add the last chunk to the list
        returnQueue.Enqueue(currentChunk)
        Return returnQueue
    End Function

    Private Function splitEncryptedWOrd(ByVal textToSplit As String, ByVal charCount As Integer) As System.Collections.Queue
        uniqueWordList = Nothing
        Dim returnQueue As New System.Collections.Queue

        uniqueWordList = textToSplit.Split(",".ToCharArray)

        Dim currentChunk As String = ""

        For index As Integer = 0 To uniqueWordList.GetUpperBound(0)

            Dim currentWord As String = uniqueWordList(index)

            If currentChunk.Length + currentWord.Length <= charCount Then
                'The phrase is still short enough
                currentChunk += " " & currentWord
            Else
                'The phrase would be too long
                'Add the chunk to the list
                returnQueue.Enqueue(currentChunk)
                'Start a new chunk
                currentChunk = currentWord
            End If

        Next index

        'Reached the end. Add the last chunk to the list
        returnQueue.Enqueue(currentChunk)
        Return returnQueue
    End Function


    Private Function splitCurrentString(ByVal textToSplit As String, ByVal charCount As Integer) As System.Collections.Queue

        Dim returnQueue As New System.Collections.Queue

        currentWordList = textToSplit.Split(" ".ToCharArray)

        Dim currentChunk As String = ""

        For index As Integer = 0 To currentWordList.GetUpperBound(0)

            Dim currentWord As String = currentWordList(index)

            If currentChunk.Length + currentWord.Length <= charCount Then
                'The phrase is still short enough
                currentChunk += " " & currentWord
            Else
                'The phrase would be too long
                'Add the chunk to the list
                returnQueue.Enqueue(currentChunk)
                'Start a new chunk
                currentChunk = currentWord
            End If

        Next index

        'Reached the end. Add the last chunk to the list
        returnQueue.Enqueue(currentChunk)
        Return returnQueue
    End Function

    Private Sub startSpellCheck()
        lblSuggest.Text = "Suggestions"
        If isChecked = True Then
            Exit Sub
        End If
        'originalString = txtContent.Text
        Dim len As Integer = txtContent.Text.Length
        If len = 0 Then
            MsgBox("Provide the text for spell check", MsgBoxStyle.Information, "Spell check")
            Exit Sub
        End If
        '==================================================
        spellCheck = False
        xIndex = 0
        lbSuggestedList.Items.Clear()
        WrongWordList.Clear()
        firstWrongWordText = ""
        firstWrongWordIndex = 0
        txtSelectedWord.Text = ""
        '==================================================

        txtContent.SelectionStart = 0
        txtContent.SelectionLength = len - 1
        txtContent.SelectionBackColor = Color.White
        txtContent.ForeColor = Color.Black
        '=========================================Optional function... decide later .................
        'getAllWrongWord(originalString, firstWrongWordIndex, len - 1)
        '==============================================
        '################################################################################################################
        '=============================== startindex is 0 as it start from the begining of the richtextbox===============
        'lblSuggest.Text = "Suggestion"
        If getFirstWrongWord(txtContent.Text, 0, len, 2) Then
            If firstWrongWordIndex >= 0 Then
                txtContent.SelectionStart = firstWrongWordIndex
                txtContent.SelectionLength = firstWrongWordText.Trim.Length
                txtContent.SelectionBackColor = Color.LightBlue
                txtContent.SelectionColor = Color.Chocolate


             

                leftString = txtContent.Text.Substring(0, firstWrongWordIndex + firstWrongWordText.Trim.Length)
                rightString = txtContent.Text.Substring(firstWrongWordIndex + firstWrongWordText.Trim.Length)
                txtSelectedWord.Text = firstWrongWordText
                lblSuggest.Text = "Not in the dictionary."
                If foundInTextFile = False Then
                    getSuggestionWord(firstWrongWordText)
                    btnAdd.Visible = False
                Else
                    btnAdd.Visible = True
                End If
            End If
        Else
            btnAdd.Visible = False
            MsgBox("Spell checking completed. No error found.", MsgBoxStyle.Information, "Spell check")
            lblSuggest.Text = "Suggestions"
        End If
        isChecked = True

        txtContent.ScrollToCaret()
        Exit Sub
    End Sub

    Private Function getSuggestionWord(ByVal searchText As String) As Boolean
        Try
            lbSuggestedList.Items.Clear()
            Dim sText As String = EachCharacterEncrypt(searchText, strEncodeString)
            Dim cmd As New OleDbCommand("SELECT SuggestWord FROM ErrorCollection WHERE WrongWord='" & sText & "'", objConn)
            Dim rs As OleDbDataReader = cmd.ExecuteReader
            If rs.HasRows Then
                Do While rs.Read
                    'lbSuggestedList.Text = EachCharacterEncrypt(searchText, strEncodeString)
                    Dim xText As String = IIf(IsDBNull(rs("SuggestWord")), "", rs("SuggestWord"))
                    If xText <> "" Then
                        xText = Decrypt(xText, strEncodeString)
                        Dim wordArray() As String = xText.Split(", ")
                        For Each word As String In wordArray
                            If word <> " " And word.Length > 1 And word <> "" Then
                                Dim newWord As String = getSearchWord(word, word.Length)
                                lbSuggestedList.Items.Add(newWord)
                                lblSuggest.Text = "Suggestions"
                            End If
                        Next
                    End If
                Loop
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Throw ex
            Return False
        End Try
    End Function

    Private Sub clearText()
        isChecked = False
        txtContent.Clear()
        lbSuggestedList.Items.Clear()
        firstWrongWordIndex = 0
        firstWrongWordText = ""
    End Sub

    Private Sub ignoreSingleWord()
        'Ignore only one word and go to next
        lbSuggestedList.Items.Clear()
        txtSelectedWord.Text = ""
        If spellCheck = True Then
            MsgBox("Spell check  completed.", MsgBoxStyle.Information, "Spell Check")
            Exit Sub
        End If
        If isChecked = False Then
            MsgBox("Please start first.", MsgBoxStyle.Information, "Spell Check")
            Exit Sub
        End If

        txtContent.SelectionStart = 0
        txtContent.SelectionLength = leftString.Length
        txtContent.SelectionBackColor = Color.White
        txtContent.SelectionColor = Color.Black

        If firstWrongWordIndex + firstWrongWordText.Length <> txtContent.Text.Length Then
            leftString = txtContent.Text.Substring(0, firstWrongWordIndex + firstWrongWordText.Length)
            rightString = txtContent.Text.Substring(firstWrongWordIndex + firstWrongWordText.Length + 1)
            getNextWrongWord()
        Else
            txtContent.SelectionStart = 0
            txtContent.SelectionLength = txtContent.Text.Length
            txtContent.SelectionBackColor = Color.White
            txtContent.SelectionColor = Color.Black
            MsgBox("Spell check completed.", MsgBoxStyle.Information, "Spell Checking")
            lblSuggest.Text = "Suggestions."
            Exit Sub
        End If
    End Sub


    Private Sub getNextWrongWord()
        btnAdd.Visible = False
        If txtContent.Text = "" Then
            Exit Sub
        End If
        txtSelectedWord.Text = ""

        '################################################################################################################
        '=============================== start index is firstWrongWordIndex + firstWrongWordText.Length + 1 ===============
        If getFirstWrongWord(rightString, firstWrongWordIndex + firstWrongWordText.Length, txtContent.Text.Length, 2) Then
            If firstWrongWordIndex >= 0 Then
                txtContent.SelectionStart = firstWrongWordIndex
                txtContent.SelectionLength = firstWrongWordText.Length
                txtContent.SelectionBackColor = Color.LightBlue
                txtContent.SelectionColor = Color.Chocolate

                If firstWrongWordIndex + firstWrongWordText.Length <> txtContent.Text.Length Then
                    leftString = txtContent.Text.Substring(0, firstWrongWordIndex + firstWrongWordText.Length)
                    rightString = txtContent.Text.Substring(firstWrongWordIndex + firstWrongWordText.Length + 1)
                End If
                getSuggestionWord(firstWrongWordText)
            End If
        Else
            txtContent.SelectionStart = 0
            txtContent.SelectionLength = txtContent.Text.Length
            txtContent.SelectionBackColor = Color.White
            txtContent.SelectionColor = Color.Black
            txtSelectedWord.Text = ""
            lbSuggestedList.Items.Clear()
            MsgBox("Spell checking completed.", MsgBoxStyle.Information, "Spell Check")
            'lblSuggest.Text = "Suggestions"
            spellCheck = True
            Exit Sub
        End If
        txtContent.ScrollToCaret()
        txtSelectedWord.Text = firstWrongWordText
    End Sub

    Private Sub lbSuggestedList_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbSuggestedList.SelectedIndexChanged
        Try
            txtSelectedWord.Text = ""
            txtSelectedWord.Text = lbSuggestedList.SelectedItem.ToString
        Catch ex As Exception
            Exit Sub
        End Try

    End Sub

    Private Sub StartToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ttStart.Click
        If isChecked = False Then
            txtContent.Text = txtContent.Text & " "
        Else
            Exit Sub
        End If
        txtContent.ReadOnly = True

        ttClose.Enabled = False
        ttChange.Enabled = False
        ttChangeAll.Enabled = False
        ttIgnoreAll.Enabled = False
        ttIgnoreOnce.Enabled = False


        startSpellCheck()

        If lbSuggestedList.Items.Count > 0 Then
            lblSuggest.Text = "Suggestions."
        Else
            lblSuggest.Text = "Not in the dictionary."
        End If

        ttClose.Enabled = True
        ttChange.Enabled = True
        ttChangeAll.Enabled = True
        ttIgnoreAll.Enabled = True
        ttIgnoreOnce.Enabled = True

    End Sub


    Private Sub ttIgnoreOnce_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ttIgnoreOnce.Click
        ignoreType = 1
        btnAdd.Visible = False
        ignoreSingleWord()
        If lbSuggestedList.Items.Count > 0 Then
            lblSuggest.Text = "Suggestions."
        Else
            lblSuggest.Text = "Not in the dictionary."
        End If
    End Sub


    Private Sub ttIgnoreAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ttIgnoreAll.Click
        ''''''''''''''''''=====================

        '''''' first ignore the selected text and then add this text to the ignore list 
        '''''' then check for the next wrong word in the whole word 
        '''''' if the next worg is found in the ignored_word list then it will take this word as right word....
        '''''' then it increase the search to the next index to find next worng word....
        '''''' this process will continue for each click of the ignore all button
        ''''''''''''''''''===================== lbSuggestedList.Items.Clear()
        txtSelectedWord.Text = ""
        If spellCheck = True Then
            MsgBox("Spell check  completed.", MsgBoxStyle.Information, "Spell Check")
            Exit Sub
        End If
        If isChecked = False Then
            MsgBox("Please start first.", MsgBoxStyle.Information, "Spell Check")
            Exit Sub
        End If
        ignoreType = 1

        If ignoreWordList.Count = 0 Then
            ignoreWordList.Add(firstWrongWordText)
            txtContent.SelectionStart = 0
            txtContent.SelectionLength = leftString.Length
            txtContent.SelectionBackColor = Color.White
            txtContent.SelectionColor = Color.Black
        End If
        Dim isExistsWrongWord As Boolean = False
        For Each Str As String In ignoreWordList
            If Str.Contains(firstWrongWordText) Then
                isExistsWrongWord = True
            End If
        Next

        If isExistsWrongWord = False Then
            ignoreWordList.Add(firstWrongWordText)
            txtContent.SelectionStart = 0
            txtContent.SelectionLength = leftString.Length
            txtContent.SelectionBackColor = Color.White
            txtContent.SelectionColor = Color.Black
        End If
        getNextWrongWord()
    End Sub


    Private Function isNewWOrdExists(ByVal xWOrd As String) As Boolean
        Dim encodeWord As String = EachCharacterEncrypt(xWOrd, strEncodeString)

        Dim myStr As String = "SELECT ID FROM ErrorCollection WHERE WrongWord='" & encodeWord & "'"
        Dim objCmd As New OleDbCommand(myStr, objConn)
        Dim rs As OleDbDataReader = objCmd.ExecuteReader
        If rs.HasRows Then
            Return True
        Else

            Dim dr() As System.Data.DataRow
            dr = dtAllWOrd.Select("MyWord='" & xWOrd & "'")
            If dr.Length = 0 Then
                Dim isExists As Integer = 0
                Dim encryptedString As String = encodeWord 'Encrypt(xWord, strEncodeString)

                If isExists = 0 Then
                    For j As Integer = 0 To uniqueWordList.Count - 1
                        Dim currWordDecoded As String = uniqueWordList(j).ToString
                        If currWordDecoded.Length > 0 And currWordDecoded <> "" And currWordDecoded <> " " Then
                            If currWordDecoded = encryptedString Then
                                Return True
                            End If
                        End If
                    Next
                End If
            End If
        End If
        Return False
    End Function

    Private Sub ignoreAllWrong()
        'Ignore only one word and go to next
        lbSuggestedList.Items.Clear()
        txtSelectedWord.Text = ""
        If spellCheck = True Then
            MsgBox("Spell check already completed.", MsgBoxStyle.Information, "Spell Check")
            Exit Sub
        End If
        If isChecked = False Then
            MsgBox("Please check the content before igorne", MsgBoxStyle.Information, "Ignore")
            Exit Sub
        End If
        txtContent.SelectionStart = 0
        txtContent.SelectionLength = leftString.Length
        txtContent.SelectionBackColor = Color.White
        txtContent.SelectionColor = Color.Black
        If firstWrongWordIndex + firstWrongWordText.Length <> txtContent.Text.Length Then
            leftString = txtContent.Text.Substring(0, firstWrongWordIndex + firstWrongWordText.Length)
            rightString = txtContent.Text.Substring(firstWrongWordIndex + firstWrongWordText.Length + 1)
            getNextWrongWord()
        Else
            txtContent.SelectionStart = 0
            txtContent.SelectionLength = txtContent.Text.Length
            txtContent.SelectionBackColor = Color.White
            txtContent.SelectionColor = Color.Black
            MsgBox("Spell check completed.", MsgBoxStyle.Information, "Spell Checking")
            Exit Sub
        End If
    End Sub

    Private Sub ttChange_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ttChange.Click
        If isChecked = False Then
            Exit Sub
        End If
        If spellCheck = True Then
            MsgBox("Spell check  completed.", MsgBoxStyle.Information, "Spell Check")
            Exit Sub
        End If
        'If lbSuggestedList.Items.Count = 0 Then
        '    MsgBox("No suggestion to change.", MsgBoxStyle.Information, "Spell Check")
        '    Exit Sub
        'End If
        txtContent.SelectionStart = 0
        txtContent.SelectionLength = leftString.Length
        txtContent.SelectionBackColor = Color.White
        txtContent.SelectionColor = Color.Black


        Dim suggestWordLength As Integer = txtSelectedWord.Text.Length
        Dim wrongWordLength As Integer = firstWrongWordText.Length

        Dim diffLength As Integer = 0
        diffLength = suggestWordLength - wrongWordLength
        If firstWrongWordIndex = -1 Then
            MsgBox("Spell check complete", MsgBoxStyle.Information, "Spell Check")
            Exit Sub
        End If


        If diffLength = 0 Then
            'equal
            If firstWrongWordIndex = 0 Then
                leftString = txtContent.Text.Substring(0, firstWrongWordIndex)
            ElseIf firstWrongWordIndex > 0 Then
                leftString = txtContent.Text.Substring(0, firstWrongWordIndex - 1)
            End If
            If leftString = "" Then
                leftString = txtSelectedWord.Text.Trim
            Else
                leftString = leftString & " " & txtSelectedWord.Text.Trim
            End If
            If firstWrongWordIndex + firstWrongWordText.Length >= txtContent.Text.Length Then
                rightString = txtContent.Text.Substring(firstWrongWordIndex + firstWrongWordText.Length)
            Else
                rightString = txtContent.Text.Substring(firstWrongWordIndex + firstWrongWordText.Length + 1)
            End If


            txtContent.Text = leftString & " " & rightString
        End If
        If diffLength > 0 Then
            ' ' smaller
            If firstWrongWordIndex = 0 Then
                leftString = txtContent.Text.Substring(0, firstWrongWordIndex)
            ElseIf firstWrongWordIndex > 0 Then
                leftString = txtContent.Text.Substring(0, firstWrongWordIndex - 1)
            End If
            If leftString = "" Then
                leftString = txtSelectedWord.Text.Trim
            Else
                leftString = leftString & " " & txtSelectedWord.Text.Trim
            End If
            If firstWrongWordIndex + firstWrongWordText.Length >= txtContent.Text.Length Then
                rightString = txtContent.Text.Substring(firstWrongWordIndex + firstWrongWordText.Length)
            Else
                rightString = txtContent.Text.Substring(firstWrongWordIndex + firstWrongWordText.Length + 1)
            End If

            txtContent.Text = leftString & " " & rightString
        End If

        If diffLength < 0 Then
            ' ' large
            If firstWrongWordIndex = 0 Then
                leftString = txtContent.Text.Substring(0, firstWrongWordIndex)
            ElseIf firstWrongWordIndex > 1 Then
                leftString = txtContent.Text.Substring(0, firstWrongWordIndex - 1)
            End If
            If leftString.Length > 0 Then
                leftString = leftString.Trim & " " & txtSelectedWord.Text.Trim
            Else
                leftString = txtSelectedWord.Text.Trim
            End If
            If firstWrongWordIndex + firstWrongWordText.Length >= txtContent.Text.Length Then
                rightString = txtContent.Text.Substring(firstWrongWordIndex + firstWrongWordText.Length)
            Else
                rightString = txtContent.Text.Substring(firstWrongWordIndex + firstWrongWordText.Length + 1)
            End If


            txtContent.Text = leftString & " " & rightString
        End If


        'If getFirstWrongWord(txtContent.Text, firstWrongWordIndex, txtContent.Text.Length, 2) Then
        '    txtSelectedWord.Text = ""
        '    lbSuggestedList.Items.Clear()
        '    txtSelectedWord.Text = firstWrongWordText
        '    getSuggestionWord(firstWrongWordText)
        '    If firstWrongWordIndex <> -1 Then
        '        txtContent.SelectionStart = firstWrongWordIndex
        '        txtContent.SelectionLength = firstWrongWordText.Length
        '        txtContent.SelectionBackColor = Color.LightBlue
        '        txtContent.SelectionColor = Color.Chocolate
        '    End If


        '    Exit Sub
        'End If

        splitOriginalString(txtContent.Text, 200)

        getNextWrongWord()
    End Sub


    Private Sub ttChangeAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ttChangeAll.Click
        If isChecked = False Then
            Exit Sub
        End If
        If spellCheck = True Then
            MsgBox("Spell check  completed.", MsgBoxStyle.Information, "Spell Check")
            Exit Sub
        End If
        If firstWrongWordIndex = -1 Then
            MsgBox("Spell check complete", MsgBoxStyle.Information, "Spell Check")
            Exit Sub
        End If
        If ignoreWordList.Count = 0 Then
            ignoreWordList.Add(txtSelectedWord.Text)
            txtContent.SelectionStart = 0
            txtContent.SelectionLength = leftString.Length
            txtContent.SelectionBackColor = Color.White
            txtContent.SelectionColor = Color.Black
        End If
        Dim isExistsWrongWord As Boolean = False
        For Each Str As String In ignoreWordList
            If Str.Contains(txtSelectedWord.Text) Then
                isExistsWrongWord = True
            End If
        Next

        If isExistsWrongWord = False Then
            ignoreWordList.Add(txtSelectedWord.Text)
            txtContent.SelectionStart = 0
            txtContent.SelectionLength = leftString.Length
            txtContent.SelectionBackColor = Color.White
            txtContent.SelectionColor = Color.Black
        End If

        If firstWrongWordText.Length = 0 Or txtSelectedWord.Text.Length = 0 Then
            MsgBox("Spell checking completed.", MsgBoxStyle.Information, "Spelll check")
            lblSuggest.Text = "Suggestions"
            Exit Sub
        End If

        Dim newText As String = txtContent.Text.Replace(firstWrongWordText, txtSelectedWord.Text)

        txtContent.Text = newText
        firstWrongWordText = ""
        ignoreType = 1
        getFirstWrongWord(txtContent.Text, 0, txtContent.Text.Length - 1, 2)


        txtSelectedWord.Text = ""
        lbSuggestedList.Items.Clear()
        txtSelectedWord.Text = firstWrongWordText
        getSuggestionWord(firstWrongWordText)

        txtContent.SelectionStart = firstWrongWordIndex
        txtContent.SelectionLength = firstWrongWordText.Length
        txtContent.SelectionBackColor = Color.LightBlue
        txtContent.SelectionColor = Color.Chocolate

    End Sub

    Private Sub ttClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ttClose.Click
        'Dim st As String = ""
        'Try
        '    'Dim myStr2 As String = "SELECT word FROM words  ORDER BY word "
        '    'Dim objCmd2 As New OleDbCommand(myStr2, objConn)
        '    'Dim rs2 As OleDbDataReader = objCmd2.ExecuteReader
        '    'If rs2.HasRows Then
        '    '    Do While rs2.Read
        '    '        'Dim rowStr As String = IIf(IsDBNull(rs2("Ameaning")), "", rs2("Ameaning"))
        '    '        'Dim wordlist1() As String
        '    '        'wordlist1 = rowStr.Split(" ")
        '    '        'For Each word As String In wordlist1
        '    '        '    Label2.Text = Now

        '    '        '    Dim xWord As String = word
        '    '        '    Dim len As Integer = xWord.Length
        '    '        '    If len > 1 and xWord<>"" and xWord <>" " Then
        '    '        '        For x As Integer = 0 To wordlist1.Count - 1
        '    '        '            Dim addWord As String = getSearchWord(wordlist1(x).ToString, wordlist1(x).ToString.Length)
        '    '        '            If addWord <> "" Or addWord.Length > 1 Or addWord <> ":" Or addWord <> " " Then
        '    '        '                'uniqueWrongList.Add(addWord)
        '    '        '                st = st & ", " & addWord
        '    '        '            End If
        '    '        '        Next
        '    '        '    End If
        '    '        'Next
        '    '        st = st & " " & IIf(IsDBNull(rs2("word")), "", rs2("word"))
        '    '        'Dim wordlist1() As String
        '    '    Loop
        '    '    rs2.Close()
        '    'End If
        '' ''If uniqueWrongList.Count > 0 Then
        '' ''    For i As Integer = 0 To uniqueWrongList.Count - 1
        '' ''        For j As Integer = i + 1 To uniqueWrongList.Count - 1
        '' ''            If j > uniqueWrongList.Count - 1 Then Exit For
        '' ''            If uniqueWrongList(i) = uniqueWrongList(j) Then
        '' ''                uniqueWrongList.RemoveAt(j)
        '' ''                j = j - 1
        '' ''            End If
        '' ''        Next j
        '' ''    Next i
        '' ''End If
        '    ''Dim cmd As New OleDbCommand
        ' '' ''Dim str As String = ""
        '    ''For i As Integer = 0 To uniqueWrongList.Count - 1
        '    ''    'cmd = New OleDbCommand("INSERT INTO tb33 (word) VALUES('" & uniqueWrongList(i).ToString.Replace("'", "''") & "')", objConn)
        '    ''    'cmd.ExecuteNonQuery()
        '    ''    str = str & "," & uniqueWrongList(i).ToString.Replace("'", "''")
        '    ''Next


        '    ''=======================this is an experiment=========================
        '    'Dim cmd As New OleDbCommand("SELECT DISTINCT(MyWord) As Word FROM MainTable ", objConn)
        '    'Dim rs As OleDbDataReader = cmd.ExecuteReader
        '    'If rs.HasRows Then
        '    '    Do While rs.Read
        '    '        uniqueWrongList.Add(rs("Word"))
        '    '    Loop
        '    'End If



        '    ''====================================delete this======================



        '    Dim txt As String = "..\\text.txt"  '"F:\\New_Dict\\originfile.txt" 
        '    Dim txt_b As New IO.StreamReader(txt)
        '    Dim line As String = ""
        '    Do While txt_b.Peek <> -1
        '        line = line & "," & txt_b.ReadLine

        '    Loop
        '    splitOriginalString(line, 200)
        '    For Each word As String In wordList
        '        Dim xWord As String = word
        '        Dim len As Integer = xWord.Length
        '        If len > 1 And xWord <> "" And xWord <> " " Then
        '            'For x As Integer = 0 To wordList.Count - 1
        '            Dim addWord As String = getSearchWord(xWord, xWord.Length) 'getSearchWord(wordList(x).ToString, wordList(x).ToString.Length)
        '            If addWord <> "" Or addWord.Length > 1 Or addWord <> ":" Or addWord <> " " Then
        '                uniqueWrongList.Add(addWord)
        '            End If
        '            'Next
        '        End If
        '    Next

        ''If uniqueWrongList.Count > 0 Then
        ''    For i As Integer = 0 To uniqueWrongList.Count - 1
        ''        For j As Integer = i + 1 To uniqueWrongList.Count - 1
        ''            If j > uniqueWrongList.Count - 1 Then Exit For
        ''            If uniqueWrongList(i) = uniqueWrongList(j) Then
        ''                uniqueWrongList.RemoveAt(j)
        ''                j = j - 1
        ''            End If
        ''        Next j
        ''    Next i
        ''End If
        '    For i As Integer = 0 To uniqueWrongList.Count - 1
        '        st = st & ", " & uniqueWrongList(i).ToString.Replace("'", "''")
        '    Next
        ' ''Dim s As Integer = wordList.Count
        '    txtContent.Text = st
        'Catch ex As Exception
        '    Throw
        'End Try
        'MsgBox("oK")...





        'Dim allWordList As String = ""
        'Dim xCount As Integer = 0
        'If uniqueWordList.Count > 0 Then
        '    For i As Integer = 99001 To uniqueWordList.Count - 1
        '        Dim xStr As String = Decrypt(uniqueWordList(i).ToString, strEncodeString)
        '        Dim dr() As System.Data.DataRow
        '        dr = dtAllWOrd.Select("MyWord='" & xStr & "'")
        '        If dr.Length = 0 Then
        '            allWordList = allWordList & "," & uniqueWordList(i).ToString
        '            xCount = xCount + 1

        '            txtContent.Text = ""
        '        Else
        '            txtContent.Text = xCount
        '        End If
        '    Next i
        'End If



        isChecked = False
        Me.Close()
    End Sub


    Private Sub ToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem1.Click
        splitCurrentString(txtContent.Text, 200)
        Dim str As String = Nothing

        For Each word As String In currentWordList
            If word <> "" Then
                str = str & " " & word.Trim

            End If
        Next
        txtContent.Text = str.Substring(1)
    End Sub


    Private Sub frmSpellcheck_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        getConn()
        txtContent.Clear()
        txtContent.Focus()
        Me.Size = New System.Drawing.Size(900, 663)
        Try
            If IsRegistered = False Then
                txtContent.Enabled = False
                MenuStrip1.Enabled = False
                txtSelectedWord.Enabled = False
                lbSuggestedList.Enabled = False
                btnPaste.Visible = False
                btnCopy.Visible = False

                txtContent.Text = "This feature works only after activation."
            End If
        Catch ex As Exception
            Exit Sub
        End Try

        Dim strSql As String = "SELECT MyWord FROM MainTable"

        Using dad As New OleDbDataAdapter(strSql, objConn)
            dad.Fill(dtAllWOrd)
        End Using
        loadFromTheTxtFile()


    End Sub

    Private Sub loadFromTheTxtFile()
        '''' read from the unique list

        Dim txt_b As New IO.StreamReader(txtPath)
        Dim line As String = ""
        Do While txt_b.Peek <> -1
            line = line & "" & txt_b.ReadLine
        Loop
        splitEncryptedWOrd(line, 200)
        txt_b.Close()
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnencrypt.Click
        ''''================================ encrypt word character by character =====================================
        'Dim lID As Integer = 2683
        'Dim uID As Integer = 2690

        'Try
        '    Dim cmd As New OleDbCommand("SELECT ID, WrongWord_old, SuggestWord_old FROM ErrorCollection WHERE ID>=" & lID & " AND ID<=" & uID & " ORDER BY ID", objConn)
        '    Dim rs1 As OleDbDataReader = cmd.ExecuteReader
        '    If rs1.HasRows Then
        '        Do While rs1.Read
        '            Dim id As Integer = rs1("ID")
        '            Dim myWord As String = IIf(IsDBNull(rs1("WrongWord_old")), "", rs1("WrongWord_old"))
        '            Dim encyptedWord As String = ""
        '            If myWord <> "" Then
        '                encyptedWord = EachCharacterEncrypt(myWord, strEncodeString)
        '            End If
        '            Dim SuggestWord As String = IIf(IsDBNull(rs1("SuggestWord_old")), "", rs1("SuggestWord_old"))
        '            Dim swordEncrypted As String = ""
        '            If SuggestWord <> "" Then
        '                swordEncrypted = Encrypt(SuggestWord, strEncodeString)
        '            End If

        '            Dim cmd1 As New OleDbCommand("UPDATE ErrorCollection SET WrongWOrd='" & encyptedWord & "', SuggestWord='" & swordEncrypted & "' WHERE ID=" & id, objConn)
        '            cmd1.ExecuteNonQuery()
        '        Loop
        '        rs1.Close()
        '    End If
        'Catch ex As Exception
        '    MsgBox(ex.Message)
        'End Try
        'MsgBox("ok")
    End Sub


    Private Sub ttClearText_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ttClearText.Click
        lbSuggestedList.Text = ""
        clearText()
        lblSuggest.Text = "Suggestions."
        txtSelectedWord.Text = ""
        btnAdd.Visible = False

    End Sub

    Private Sub txtContent_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtContent.KeyDown
        Dim Test As Integer = 0
        If e.Alt = False And e.Control = False And e.Shift = False And e.KeyCode = 75 Then
            Test = txtContent.SelectionStart
            txtContent.Text = txtContent.Text.Insert(txtContent.SelectionStart, "ক")
            e.SuppressKeyPress = True
            txtContent.SelectionStart = Test + 1
        End If
        If e.Alt = False And e.Control = False And e.Shift = True And e.KeyCode = 75 Then
            Test = txtContent.SelectionStart
            txtContent.Text = txtContent.Text.Insert(txtContent.SelectionStart, "খ")
            e.SuppressKeyPress = True
            txtContent.SelectionStart = Test + 1
        End If

        If e.Alt = False And e.Control = False And e.Shift = False And e.KeyCode = 73 Then
            Test = txtContent.SelectionStart
            txtContent.Text = txtContent.Text.Insert(txtContent.SelectionStart, "গ")
            e.SuppressKeyPress = True
            txtContent.SelectionStart = Test + 1
        End If
        If e.Alt = False And e.Control = False And e.Shift = True And e.KeyCode = 73 Then
            Test = txtContent.SelectionStart
            txtContent.Text = txtContent.Text.Insert(txtContent.SelectionStart, "ঘ")
            e.SuppressKeyPress = True
            txtContent.SelectionStart = Test + 1
        End If
        If e.Alt = False And e.Control = False And e.Shift = True And e.KeyCode = 85 Then
            Test = txtContent.SelectionStart
            txtContent.Text = txtContent.Text.Insert(txtContent.SelectionStart, "ঙ")
            e.SuppressKeyPress = True
            txtContent.SelectionStart = Test + 1
        End If

        If e.Alt = False And e.Control = False And e.Shift = False And e.KeyCode = 186 Then
            Test = txtContent.SelectionStart
            txtContent.Text = txtContent.Text.Insert(txtContent.SelectionStart, "চ")
            e.SuppressKeyPress = True
            txtContent.SelectionStart = Test + 1
        End If

        If e.Alt = False And e.Control = False And e.Shift = True And e.KeyCode = 186 Then
            Test = txtContent.SelectionStart
            txtContent.Text = txtContent.Text.Insert(txtContent.SelectionStart, "ছ")
            e.SuppressKeyPress = True
            txtContent.SelectionStart = Test + 1
        End If

        If e.Alt = False And e.Control = False And e.Shift = False And e.KeyCode = 80 Then
            Test = txtContent.SelectionStart
            txtContent.Text = txtContent.Text.Insert(txtContent.SelectionStart, "জ")
            e.SuppressKeyPress = True
            txtContent.SelectionStart = Test + 1
        End If
        If e.Alt = False And e.Control = False And e.Shift = True And e.KeyCode = 80 Then
            Test = txtContent.SelectionStart
            txtContent.Text = txtContent.Text.Insert(txtContent.SelectionStart, "ঝ")
            e.SuppressKeyPress = True
            txtContent.SelectionStart = Test + 1
        End If
        If e.Alt = False And e.Control = False And e.Shift = True And e.KeyCode = 78 Then
            Test = txtContent.SelectionStart
            txtContent.Text = txtContent.Text.Insert(txtContent.SelectionStart, "ঞ")
            e.SuppressKeyPress = True
            txtContent.SelectionStart = Test + 1
        End If
        If e.Alt = False And e.Control = False And e.Shift = False And e.KeyCode = 222 Then
            Test = txtContent.SelectionStart
            txtContent.Text = txtContent.Text.Insert(txtContent.SelectionStart, "ট")
            e.SuppressKeyPress = True
            txtContent.SelectionStart = Test + 1
        End If
        If e.Alt = False And e.Control = False And e.Shift = True And e.KeyCode = 222 Then
            Test = txtContent.SelectionStart
            txtContent.Text = txtContent.Text.Insert(txtContent.SelectionStart, "ঠ")
            e.SuppressKeyPress = True
            txtContent.SelectionStart = Test + 1
        End If
        If e.Alt = False And e.Control = False And e.Shift = False And e.KeyCode = 219 Then
            Test = txtContent.SelectionStart
            txtContent.Text = txtContent.Text.Insert(txtContent.SelectionStart, "ড")
            e.SuppressKeyPress = True
            txtContent.SelectionStart = Test + 1
        End If
        If e.Alt = False And e.Control = False And e.Shift = True And e.KeyCode = 219 Then
            Test = txtContent.SelectionStart
            txtContent.Text = txtContent.Text.Insert(txtContent.SelectionStart, "ঢ")
            e.SuppressKeyPress = True
            txtContent.SelectionStart = Test + 1
        End If
        If e.Alt = False And e.Control = False And e.Shift = True And e.KeyCode = 67 Then
            Test = txtContent.SelectionStart
            txtContent.Text = txtContent.Text.Insert(txtContent.SelectionStart, "ণ")
            e.SuppressKeyPress = True
            txtContent.SelectionStart = Test + 1
        End If

        If e.Alt = False And e.Control = False And e.Shift = False And e.KeyCode = 76 Then
            Test = txtContent.SelectionStart
            txtContent.Text = txtContent.Text.Insert(txtContent.SelectionStart, "ত")
            e.SuppressKeyPress = True
            txtContent.SelectionStart = Test + 1
        End If
        If e.Alt = False And e.Control = False And e.Shift = True And e.KeyCode = 76 Then
            Test = txtContent.SelectionStart
            txtContent.Text = txtContent.Text.Insert(txtContent.SelectionStart, "থ")
            e.SuppressKeyPress = True
            txtContent.SelectionStart = Test + 1
        End If

        If e.Alt = False And e.Control = False And e.Shift = False And e.KeyCode = 79 Then
            Test = txtContent.SelectionStart
            txtContent.Text = txtContent.Text.Insert(txtContent.SelectionStart, "দ")
            e.SuppressKeyPress = True
            txtContent.SelectionStart = Test + 1
        End If
        If e.Alt = False And e.Control = False And e.Shift = True And e.KeyCode = 79 Then
            Test = txtContent.SelectionStart
            txtContent.Text = txtContent.Text.Insert(txtContent.SelectionStart, "ধ")
            e.SuppressKeyPress = True
            txtContent.SelectionStart = Test + 1
        End If
        If e.Alt = False And e.Control = False And e.Shift = False And e.KeyCode = 86 Then
            Test = txtContent.SelectionStart
            txtContent.Text = txtContent.Text.Insert(txtContent.SelectionStart, "ন")
            e.SuppressKeyPress = True
            txtContent.SelectionStart = Test + 1
        End If
        If e.Alt = False And e.Control = False And e.Shift = False And e.KeyCode = 72 Then
            Test = txtContent.SelectionStart
            txtContent.Text = txtContent.Text.Insert(txtContent.SelectionStart, "প")
            e.SuppressKeyPress = True
            txtContent.SelectionStart = Test + 1
        End If

        If e.Alt = False And e.Control = False And e.Shift = True And e.KeyCode = 72 Then
            Test = txtContent.SelectionStart
            txtContent.Text = txtContent.Text.Insert(txtContent.SelectionStart, "ফ")
            e.SuppressKeyPress = True
            txtContent.SelectionStart = Test + 1
        End If

        If e.Alt = False And e.Control = False And e.Shift = False And e.KeyCode = 89 Then
            Test = txtContent.SelectionStart
            txtContent.Text = txtContent.Text.Insert(txtContent.SelectionStart, "ব")
            e.SuppressKeyPress = True
            txtContent.SelectionStart = Test + 1
        End If

        If e.Alt = False And e.Control = False And e.Shift = True And e.KeyCode = 89 Then
            Test = txtContent.SelectionStart
            txtContent.Text = txtContent.Text.Insert(txtContent.SelectionStart, "ভ")
            e.SuppressKeyPress = True
            txtContent.SelectionStart = Test + 1
        End If
        If e.Alt = False And e.Control = False And e.Shift = False And e.KeyCode = 67 Then
            Test = txtContent.SelectionStart
            txtContent.Text = txtContent.Text.Insert(txtContent.SelectionStart, "ম")
            e.SuppressKeyPress = True
            txtContent.SelectionStart = Test + 1
        End If
        If e.Alt = False And e.Control = False And e.Shift = False And e.KeyCode = 220 Then
            Test = txtContent.SelectionStart
            txtContent.Text = txtContent.Text.Insert(txtContent.SelectionStart, "য")
            e.SuppressKeyPress = True
            txtContent.SelectionStart = Test + 1
        End If

        If e.Alt = False And e.Control = False And e.Shift = False And e.KeyCode = 74 Then
            Test = txtContent.SelectionStart
            txtContent.Text = txtContent.Text.Insert(txtContent.SelectionStart, "ৰ")
            e.SuppressKeyPress = True
            txtContent.SelectionStart = Test + 1
        End If

        If e.Alt = False And e.Control = False And e.Shift = False And e.KeyCode = 78 Then
            Test = txtContent.SelectionStart
            txtContent.Text = txtContent.Text.Insert(txtContent.SelectionStart, "ল")
            e.SuppressKeyPress = True
            txtContent.SelectionStart = Test + 1
        End If
        If e.Alt = False And e.Control = False And e.Shift = False And e.KeyCode = 66 Then
            Test = txtContent.SelectionStart
            txtContent.Text = txtContent.Text.Insert(txtContent.SelectionStart, "ৱ")
            e.SuppressKeyPress = True
            txtContent.SelectionStart = Test + 1
        End If
        If e.Alt = False And e.Control = False And e.Shift = True And e.KeyCode = 77 Then
            Test = txtContent.SelectionStart
            txtContent.Text = txtContent.Text.Insert(txtContent.SelectionStart, "শ")
            e.SuppressKeyPress = True
            txtContent.SelectionStart = Test + 1
        End If
        If e.Alt = False And e.Control = False And e.Shift = True And e.KeyCode = 188 Then
            Test = txtContent.SelectionStart
            txtContent.Text = txtContent.Text.Insert(txtContent.SelectionStart, "ষ")
            e.SuppressKeyPress = True
            txtContent.SelectionStart = Test + 1
        End If
        If e.Alt = False And e.Control = False And e.Shift = False And e.KeyCode = 77 Then
            Test = txtContent.SelectionStart
            txtContent.Text = txtContent.Text.Insert(txtContent.SelectionStart, "স")
            e.SuppressKeyPress = True
            txtContent.SelectionStart = Test + 1
        End If
        If e.Alt = False And e.Control = False And e.Shift = False And e.KeyCode = 85 Then
            Test = txtContent.SelectionStart
            txtContent.Text = txtContent.Text.Insert(txtContent.SelectionStart, "হ")
            e.SuppressKeyPress = True
            txtContent.SelectionStart = Test + 1
        End If
        If e.Alt = False And e.Control = False And e.Shift = True And e.KeyCode = 55 Then
            Test = txtContent.SelectionStart
            txtContent.Text = txtContent.Text.Insert(txtContent.SelectionStart, "ক্ষ")
            e.SuppressKeyPress = True
            txtContent.SelectionStart = Test + 1
        End If

        If e.Alt = False And e.Control = False And e.Shift = False And e.KeyCode = 221 Then
            Test = txtContent.SelectionStart
            txtContent.Text = txtContent.Text.Insert(txtContent.SelectionStart, "ড়")
            e.SuppressKeyPress = True
            txtContent.SelectionStart = Test + 1
        End If
        If e.Alt = False And e.Control = False And e.Shift = True And e.KeyCode = 221 Then
            Test = txtContent.SelectionStart
            txtContent.Text = txtContent.Text.Insert(txtContent.SelectionStart, "ঢ়")
            e.SuppressKeyPress = True
            txtContent.SelectionStart = Test + 1
        End If
        If e.Alt = False And e.Control = False And e.Shift = False And e.KeyCode = 191 Then
            Test = txtContent.SelectionStart
            txtContent.Text = txtContent.Text.Insert(txtContent.SelectionStart, "য়")
            e.SuppressKeyPress = True
            txtContent.SelectionStart = Test + 1
        End If
        If e.Alt = False And e.Control = False And e.Shift = True And e.KeyCode = 220 Then
            Test = txtContent.SelectionStart
            txtContent.Text = txtContent.Text.Insert(txtContent.SelectionStart, "ৎ")
            e.SuppressKeyPress = True
            txtContent.SelectionStart = Test + 1
        End If
        If e.Alt = False And e.Control = False And e.Shift = True And e.KeyCode = 68 Then
            Test = txtContent.SelectionStart
            txtContent.Text = txtContent.Text.Insert(txtContent.SelectionStart, "অ")
            e.SuppressKeyPress = True
            txtContent.SelectionStart = Test + 1
        End If
        If e.Alt = False And e.Control = False And e.Shift = True And e.KeyCode = 69 Then
            Test = txtContent.SelectionStart
            txtContent.Text = txtContent.Text.Insert(txtContent.SelectionStart, "আ")
            e.SuppressKeyPress = True
            txtContent.SelectionStart = Test + 1
        End If
        If e.Alt = False And e.Control = False And e.Shift = True And e.KeyCode = 70 Then
            Test = txtContent.SelectionStart
            txtContent.Text = txtContent.Text.Insert(txtContent.SelectionStart, "ই")
            e.SuppressKeyPress = True
            txtContent.SelectionStart = Test + 1
        End If
        If e.Alt = False And e.Control = False And e.Shift = True And e.KeyCode = 82 Then
            Test = txtContent.SelectionStart
            txtContent.Text = txtContent.Text.Insert(txtContent.SelectionStart, "ঈ")
            e.SuppressKeyPress = True
            txtContent.SelectionStart = Test + 1
        End If
        If e.Alt = False And e.Control = False And e.Shift = True And e.KeyCode = 71 Then
            Test = txtContent.SelectionStart
            txtContent.Text = txtContent.Text.Insert(txtContent.SelectionStart, "উ")
            e.SuppressKeyPress = True
            txtContent.SelectionStart = Test + 1
        End If
        If e.Alt = False And e.Control = False And e.Shift = True And e.KeyCode = 84 Then
            Test = txtContent.SelectionStart
            txtContent.Text = txtContent.Text.Insert(txtContent.SelectionStart, "ঊ")
            e.SuppressKeyPress = True
            txtContent.SelectionStart = Test + 1
        End If
        If e.Alt = False And e.Control = False And e.Shift = True And e.KeyCode = 90 Then
            Test = txtContent.SelectionStart
            txtContent.Text = txtContent.Text.Insert(txtContent.SelectionStart, "ঋ")
            e.SuppressKeyPress = True
            txtContent.SelectionStart = Test + 1
        End If
        If e.Alt = False And e.Control = False And e.Shift = True And e.KeyCode = 83 Then
            Test = txtContent.SelectionStart
            txtContent.Text = txtContent.Text.Insert(txtContent.SelectionStart, "এ")
            e.SuppressKeyPress = True
            txtContent.SelectionStart = Test + 1
        End If
        If e.Alt = False And e.Control = False And e.Shift = True And e.KeyCode = 87 Then
            Test = txtContent.SelectionStart
            txtContent.Text = txtContent.Text.Insert(txtContent.SelectionStart, "ঐ")
            e.SuppressKeyPress = True
            txtContent.SelectionStart = Test + 1
        End If
        If e.Alt = False And e.Control = False And e.Shift = True And e.KeyCode = 65 Then
            Test = txtContent.SelectionStart
            txtContent.Text = txtContent.Text.Insert(txtContent.SelectionStart, "ও")
            e.SuppressKeyPress = True
            txtContent.SelectionStart = Test + 1
        End If
        If e.Alt = False And e.Control = False And e.Shift = True And e.KeyCode = 81 Then
            Test = txtContent.SelectionStart
            txtContent.Text = txtContent.Text.Insert(txtContent.SelectionStart, "ঔ")
            e.SuppressKeyPress = True
            txtContent.SelectionStart = Test + 1
        End If
        If e.Alt = False And e.Control = False And e.Shift = False And e.KeyCode = 88 Then
            Test = txtContent.SelectionStart
            txtContent.Text = txtContent.Text.Insert(txtContent.SelectionStart, "ং")
            e.SuppressKeyPress = True
            txtContent.SelectionStart = Test + 1
        End If
        If e.Alt = False And e.Control = False And e.Shift = True And e.KeyCode = 88 Then
            Test = txtContent.SelectionStart
            txtContent.Text = txtContent.Text.Insert(txtContent.SelectionStart, "ঁ")
            e.SuppressKeyPress = True
            txtContent.SelectionStart = Test + 1
        End If
        If e.Alt = False And e.Control = False And e.Shift = True And e.KeyCode = 187 Then
            Test = txtContent.SelectionStart
            txtContent.Text = txtContent.Text.Insert(txtContent.SelectionStart, "ঃ")
            e.SuppressKeyPress = True
            txtContent.SelectionStart = Test + 1
        End If
        If e.Alt = False And e.Control = False And e.Shift = False And e.KeyCode = 68 Then
            Test = txtContent.SelectionStart
            txtContent.Text = txtContent.Text.Insert(txtContent.SelectionStart, "্")
            e.SuppressKeyPress = True
            txtContent.SelectionStart = Test + 1
        End If
        '=========================
        If e.Alt = False And e.Control = False And e.Shift = False And e.KeyCode = 69 Then
            Test = txtContent.SelectionStart
            txtContent.Text = txtContent.Text.Insert(txtContent.SelectionStart, "া")
            e.SuppressKeyPress = True
            txtContent.SelectionStart = Test + 1
        End If
        If e.Alt = False And e.Control = False And e.Shift = False And e.KeyCode = 70 Then
            Test = txtContent.SelectionStart
            txtContent.Text = txtContent.Text.Insert(txtContent.SelectionStart, "ি")
            e.SuppressKeyPress = True
            txtContent.SelectionStart = Test + 1
        End If
        If e.Alt = False And e.Control = False And e.Shift = False And e.KeyCode = 82 Then
            Test = txtContent.SelectionStart
            txtContent.Text = txtContent.Text.Insert(txtContent.SelectionStart, "ী")
            e.SuppressKeyPress = True
            txtContent.SelectionStart = Test + 1
        End If
        If e.Alt = False And e.Control = False And e.Shift = False And e.KeyCode = 71 Then
            Test = txtContent.SelectionStart
            txtContent.Text = txtContent.Text.Insert(txtContent.SelectionStart, "ু")
            e.SuppressKeyPress = True
            txtContent.SelectionStart = Test + 1
        End If
        If e.Alt = False And e.Control = False And e.Shift = False And e.KeyCode = 84 Then
            Test = txtContent.SelectionStart
            txtContent.Text = txtContent.Text.Insert(txtContent.SelectionStart, "ূ")
            e.SuppressKeyPress = True
            txtContent.SelectionStart = Test + 1
        End If
        If e.Alt = False And e.Control = False And e.Shift = False And e.KeyCode = 90 Then
            Test = txtContent.SelectionStart
            txtContent.Text = txtContent.Text.Insert(txtContent.SelectionStart, "ৃ")
            e.SuppressKeyPress = True
            txtContent.SelectionStart = Test + 1
        End If
        If e.Alt = False And e.Control = False And e.Shift = False And e.KeyCode = 83 Then
            Test = txtContent.SelectionStart
            txtContent.Text = txtContent.Text.Insert(txtContent.SelectionStart, "ে")
            e.SuppressKeyPress = True
            txtContent.SelectionStart = Test + 1
        End If
        If e.Alt = False And e.Control = False And e.Shift = False And e.KeyCode = 87 Then
            Test = txtContent.SelectionStart
            txtContent.Text = txtContent.Text.Insert(txtContent.SelectionStart, "ৈ")
            e.SuppressKeyPress = True
            txtContent.SelectionStart = Test + 1
        End If
        If e.Alt = False And e.Control = False And e.Shift = False And e.KeyCode = 65 Then
            Test = txtContent.SelectionStart
            txtContent.Text = txtContent.Text.Insert(txtContent.SelectionStart, "ো")
            e.SuppressKeyPress = True
            txtContent.SelectionStart = Test + 1
        End If
        If e.Alt = False And e.Control = False And e.Shift = False And e.KeyCode = 81 Then
            Test = txtContent.SelectionStart
            txtContent.Text = txtContent.Text.Insert(txtContent.SelectionStart, "ৌ")
            e.SuppressKeyPress = True
            txtContent.SelectionStart = Test + 1
        End If
        If e.Alt = False And e.Control = False And e.Shift = False And e.KeyCode = 192 Then
            Test = txtContent.SelectionStart
            txtContent.Text = txtContent.Text.Insert(txtContent.SelectionStart, "্য")
            e.SuppressKeyPress = True
            txtContent.SelectionStart = Test + 2
        End If
        If e.Alt = False And e.Control = False And e.Shift = True And e.KeyCode = 52 Then
            Test = txtContent.SelectionStart
            txtContent.Text = txtContent.Text.Insert(txtContent.SelectionStart, "ৰ্")
            e.SuppressKeyPress = True
            txtContent.SelectionStart = Test + 1
        End If
    End Sub

    Private Sub txtSelectedWord_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtSelectedWord.KeyDown
        Dim Test As Integer = 0
        'lblProbableWords.Text = e.KeyCode
        If e.Alt = False And e.Control = False And e.Shift = False And e.KeyCode = 75 Then
            Test = txtSelectedWord.SelectionStart
            txtSelectedWord.Text = txtSelectedWord.Text.Insert(txtSelectedWord.SelectionStart, "ক")
            e.SuppressKeyPress = True
            txtSelectedWord.SelectionStart = Test + 1
        End If
        If e.Alt = False And e.Control = False And e.Shift = True And e.KeyCode = 75 Then
            Test = txtSelectedWord.SelectionStart
            txtSelectedWord.Text = txtSelectedWord.Text.Insert(txtSelectedWord.SelectionStart, "খ")
            e.SuppressKeyPress = True
            txtSelectedWord.SelectionStart = Test + 1
        End If

        If e.Alt = False And e.Control = False And e.Shift = False And e.KeyCode = 73 Then
            Test = txtSelectedWord.SelectionStart
            txtSelectedWord.Text = txtSelectedWord.Text.Insert(txtSelectedWord.SelectionStart, "গ")
            e.SuppressKeyPress = True
            txtSelectedWord.SelectionStart = Test + 1
        End If
        If e.Alt = False And e.Control = False And e.Shift = True And e.KeyCode = 73 Then
            Test = txtSelectedWord.SelectionStart
            txtSelectedWord.Text = txtSelectedWord.Text.Insert(txtSelectedWord.SelectionStart, "ঘ")
            e.SuppressKeyPress = True
            txtSelectedWord.SelectionStart = Test + 1
        End If
        If e.Alt = False And e.Control = False And e.Shift = True And e.KeyCode = 85 Then
            Test = txtSelectedWord.SelectionStart
            txtSelectedWord.Text = txtSelectedWord.Text.Insert(txtSelectedWord.SelectionStart, "ঙ")
            e.SuppressKeyPress = True
            txtSelectedWord.SelectionStart = Test + 1
        End If

        If e.Alt = False And e.Control = False And e.Shift = False And e.KeyCode = 186 Then
            Test = txtSelectedWord.SelectionStart
            txtSelectedWord.Text = txtSelectedWord.Text.Insert(txtSelectedWord.SelectionStart, "চ")
            e.SuppressKeyPress = True
            txtSelectedWord.SelectionStart = Test + 1
        End If

        If e.Alt = False And e.Control = False And e.Shift = True And e.KeyCode = 186 Then
            Test = txtSelectedWord.SelectionStart
            txtSelectedWord.Text = txtSelectedWord.Text.Insert(txtSelectedWord.SelectionStart, "ছ")
            e.SuppressKeyPress = True
            txtSelectedWord.SelectionStart = Test + 1
        End If

        If e.Alt = False And e.Control = False And e.Shift = False And e.KeyCode = 80 Then
            Test = txtSelectedWord.SelectionStart
            txtSelectedWord.Text = txtSelectedWord.Text.Insert(txtSelectedWord.SelectionStart, "জ")
            e.SuppressKeyPress = True
            txtSelectedWord.SelectionStart = Test + 1
        End If
        If e.Alt = False And e.Control = False And e.Shift = True And e.KeyCode = 80 Then
            Test = txtSelectedWord.SelectionStart
            txtSelectedWord.Text = txtSelectedWord.Text.Insert(txtSelectedWord.SelectionStart, "ঝ")
            e.SuppressKeyPress = True
            txtSelectedWord.SelectionStart = Test + 1
        End If
        If e.Alt = False And e.Control = False And e.Shift = True And e.KeyCode = 78 Then
            Test = txtSelectedWord.SelectionStart
            txtSelectedWord.Text = txtSelectedWord.Text.Insert(txtSelectedWord.SelectionStart, "ঞ")
            e.SuppressKeyPress = True
            txtSelectedWord.SelectionStart = Test + 1
        End If
        If e.Alt = False And e.Control = False And e.Shift = False And e.KeyCode = 222 Then
            Test = txtSelectedWord.SelectionStart
            txtSelectedWord.Text = txtSelectedWord.Text.Insert(txtSelectedWord.SelectionStart, "ট")
            e.SuppressKeyPress = True
            txtSelectedWord.SelectionStart = Test + 1
        End If
        If e.Alt = False And e.Control = False And e.Shift = True And e.KeyCode = 222 Then
            Test = txtSelectedWord.SelectionStart
            txtSelectedWord.Text = txtSelectedWord.Text.Insert(txtSelectedWord.SelectionStart, "ঠ")
            e.SuppressKeyPress = True
            txtSelectedWord.SelectionStart = Test + 1
        End If
        If e.Alt = False And e.Control = False And e.Shift = False And e.KeyCode = 219 Then
            Test = txtSelectedWord.SelectionStart
            txtSelectedWord.Text = txtSelectedWord.Text.Insert(txtSelectedWord.SelectionStart, "ড")
            e.SuppressKeyPress = True
            txtSelectedWord.SelectionStart = Test + 1
        End If
        If e.Alt = False And e.Control = False And e.Shift = True And e.KeyCode = 219 Then
            Test = txtSelectedWord.SelectionStart
            txtSelectedWord.Text = txtSelectedWord.Text.Insert(txtSelectedWord.SelectionStart, "ঢ")
            e.SuppressKeyPress = True
            txtSelectedWord.SelectionStart = Test + 1
        End If
        If e.Alt = False And e.Control = False And e.Shift = True And e.KeyCode = 67 Then
            Test = txtSelectedWord.SelectionStart
            txtSelectedWord.Text = txtSelectedWord.Text.Insert(txtSelectedWord.SelectionStart, "ণ")
            e.SuppressKeyPress = True
            txtSelectedWord.SelectionStart = Test + 1
        End If

        If e.Alt = False And e.Control = False And e.Shift = False And e.KeyCode = 76 Then
            Test = txtSelectedWord.SelectionStart
            txtSelectedWord.Text = txtSelectedWord.Text.Insert(txtSelectedWord.SelectionStart, "ত")
            e.SuppressKeyPress = True
            txtSelectedWord.SelectionStart = Test + 1
        End If
        If e.Alt = False And e.Control = False And e.Shift = True And e.KeyCode = 76 Then
            Test = txtSelectedWord.SelectionStart
            txtSelectedWord.Text = txtSelectedWord.Text.Insert(txtSelectedWord.SelectionStart, "থ")
            e.SuppressKeyPress = True
            txtSelectedWord.SelectionStart = Test + 1
        End If

        If e.Alt = False And e.Control = False And e.Shift = False And e.KeyCode = 79 Then
            Test = txtSelectedWord.SelectionStart
            txtSelectedWord.Text = txtSelectedWord.Text.Insert(txtSelectedWord.SelectionStart, "দ")
            e.SuppressKeyPress = True
            txtSelectedWord.SelectionStart = Test + 1
        End If
        If e.Alt = False And e.Control = False And e.Shift = True And e.KeyCode = 79 Then
            Test = txtSelectedWord.SelectionStart
            txtSelectedWord.Text = txtSelectedWord.Text.Insert(txtSelectedWord.SelectionStart, "ধ")
            e.SuppressKeyPress = True
            txtSelectedWord.SelectionStart = Test + 1
        End If
        If e.Alt = False And e.Control = False And e.Shift = False And e.KeyCode = 86 Then
            Test = txtSelectedWord.SelectionStart
            txtSelectedWord.Text = txtSelectedWord.Text.Insert(txtSelectedWord.SelectionStart, "ন")
            e.SuppressKeyPress = True
            txtSelectedWord.SelectionStart = Test + 1
        End If
        If e.Alt = False And e.Control = False And e.Shift = False And e.KeyCode = 72 Then
            Test = txtSelectedWord.SelectionStart
            txtSelectedWord.Text = txtSelectedWord.Text.Insert(txtSelectedWord.SelectionStart, "প")
            e.SuppressKeyPress = True
            txtSelectedWord.SelectionStart = Test + 1
        End If

        If e.Alt = False And e.Control = False And e.Shift = True And e.KeyCode = 72 Then
            Test = txtSelectedWord.SelectionStart
            txtSelectedWord.Text = txtSelectedWord.Text.Insert(txtSelectedWord.SelectionStart, "ফ")
            e.SuppressKeyPress = True
            txtSelectedWord.SelectionStart = Test + 1
        End If

        If e.Alt = False And e.Control = False And e.Shift = False And e.KeyCode = 89 Then
            Test = txtSelectedWord.SelectionStart
            txtSelectedWord.Text = txtSelectedWord.Text.Insert(txtSelectedWord.SelectionStart, "ব")
            e.SuppressKeyPress = True
            txtSelectedWord.SelectionStart = Test + 1
        End If

        If e.Alt = False And e.Control = False And e.Shift = True And e.KeyCode = 89 Then
            Test = txtSelectedWord.SelectionStart
            txtSelectedWord.Text = txtSelectedWord.Text.Insert(txtSelectedWord.SelectionStart, "ভ")
            e.SuppressKeyPress = True
            txtSelectedWord.SelectionStart = Test + 1
        End If
        If e.Alt = False And e.Control = False And e.Shift = False And e.KeyCode = 67 Then
            Test = txtSelectedWord.SelectionStart
            txtSelectedWord.Text = txtSelectedWord.Text.Insert(txtSelectedWord.SelectionStart, "ম")
            e.SuppressKeyPress = True
            txtSelectedWord.SelectionStart = Test + 1
        End If
        If e.Alt = False And e.Control = False And e.Shift = False And e.KeyCode = 220 Then
            Test = txtSelectedWord.SelectionStart
            txtSelectedWord.Text = txtSelectedWord.Text.Insert(txtSelectedWord.SelectionStart, "য")
            e.SuppressKeyPress = True
            txtSelectedWord.SelectionStart = Test + 1
        End If

        If e.Alt = False And e.Control = False And e.Shift = False And e.KeyCode = 74 Then
            Test = txtSelectedWord.SelectionStart
            txtSelectedWord.Text = txtSelectedWord.Text.Insert(txtSelectedWord.SelectionStart, "ৰ")
            e.SuppressKeyPress = True
            txtSelectedWord.SelectionStart = Test + 1
        End If

        If e.Alt = False And e.Control = False And e.Shift = False And e.KeyCode = 78 Then
            Test = txtSelectedWord.SelectionStart
            txtSelectedWord.Text = txtSelectedWord.Text.Insert(txtSelectedWord.SelectionStart, "ল")
            e.SuppressKeyPress = True
            txtSelectedWord.SelectionStart = Test + 1
        End If
        If e.Alt = False And e.Control = False And e.Shift = False And e.KeyCode = 66 Then
            Test = txtSelectedWord.SelectionStart
            txtSelectedWord.Text = txtSelectedWord.Text.Insert(txtSelectedWord.SelectionStart, "ৱ")
            e.SuppressKeyPress = True
            txtSelectedWord.SelectionStart = Test + 1
        End If
        If e.Alt = False And e.Control = False And e.Shift = True And e.KeyCode = 77 Then
            Test = txtSelectedWord.SelectionStart
            txtSelectedWord.Text = txtSelectedWord.Text.Insert(txtSelectedWord.SelectionStart, "শ")
            e.SuppressKeyPress = True
            txtSelectedWord.SelectionStart = Test + 1
        End If
        If e.Alt = False And e.Control = False And e.Shift = True And e.KeyCode = 188 Then
            Test = txtSelectedWord.SelectionStart
            txtSelectedWord.Text = txtSelectedWord.Text.Insert(txtSelectedWord.SelectionStart, "ষ")
            e.SuppressKeyPress = True
            txtSelectedWord.SelectionStart = Test + 1
        End If
        If e.Alt = False And e.Control = False And e.Shift = False And e.KeyCode = 77 Then
            Test = txtSelectedWord.SelectionStart
            txtSelectedWord.Text = txtSelectedWord.Text.Insert(txtSelectedWord.SelectionStart, "স")
            e.SuppressKeyPress = True
            txtSelectedWord.SelectionStart = Test + 1
        End If
        If e.Alt = False And e.Control = False And e.Shift = False And e.KeyCode = 85 Then
            Test = txtSelectedWord.SelectionStart
            txtSelectedWord.Text = txtSelectedWord.Text.Insert(txtSelectedWord.SelectionStart, "হ")
            e.SuppressKeyPress = True
            txtSelectedWord.SelectionStart = Test + 1
        End If
        If e.Alt = False And e.Control = False And e.Shift = True And e.KeyCode = 55 Then
            Test = txtSelectedWord.SelectionStart
            txtSelectedWord.Text = txtSelectedWord.Text.Insert(txtSelectedWord.SelectionStart, "ক্ষ")
            e.SuppressKeyPress = True
            txtSelectedWord.SelectionStart = Test + 1
        End If

        If e.Alt = False And e.Control = False And e.Shift = False And e.KeyCode = 221 Then
            Test = txtSelectedWord.SelectionStart
            txtSelectedWord.Text = txtSelectedWord.Text.Insert(txtSelectedWord.SelectionStart, "ড়")
            e.SuppressKeyPress = True
            txtSelectedWord.SelectionStart = Test + 1
        End If
        If e.Alt = False And e.Control = False And e.Shift = True And e.KeyCode = 221 Then
            Test = txtSelectedWord.SelectionStart
            txtSelectedWord.Text = txtSelectedWord.Text.Insert(txtSelectedWord.SelectionStart, "ঢ়")
            e.SuppressKeyPress = True
            txtSelectedWord.SelectionStart = Test + 1
        End If
        If e.Alt = False And e.Control = False And e.Shift = False And e.KeyCode = 191 Then
            Test = txtSelectedWord.SelectionStart
            txtSelectedWord.Text = txtSelectedWord.Text.Insert(txtSelectedWord.SelectionStart, "য়")
            e.SuppressKeyPress = True
            txtSelectedWord.SelectionStart = Test + 1
        End If
        If e.Alt = False And e.Control = False And e.Shift = True And e.KeyCode = 220 Then
            Test = txtSelectedWord.SelectionStart
            txtSelectedWord.Text = txtSelectedWord.Text.Insert(txtSelectedWord.SelectionStart, "ৎ")
            e.SuppressKeyPress = True
            txtSelectedWord.SelectionStart = Test + 1
        End If
        If e.Alt = False And e.Control = False And e.Shift = True And e.KeyCode = 68 Then
            Test = txtSelectedWord.SelectionStart
            txtSelectedWord.Text = txtSelectedWord.Text.Insert(txtSelectedWord.SelectionStart, "অ")
            e.SuppressKeyPress = True
            txtSelectedWord.SelectionStart = Test + 1
        End If
        If e.Alt = False And e.Control = False And e.Shift = True And e.KeyCode = 69 Then
            Test = txtSelectedWord.SelectionStart
            txtSelectedWord.Text = txtSelectedWord.Text.Insert(txtSelectedWord.SelectionStart, "আ")
            e.SuppressKeyPress = True
            txtSelectedWord.SelectionStart = Test + 1
        End If
        If e.Alt = False And e.Control = False And e.Shift = True And e.KeyCode = 70 Then
            Test = txtSelectedWord.SelectionStart
            txtSelectedWord.Text = txtSelectedWord.Text.Insert(txtSelectedWord.SelectionStart, "ই")
            e.SuppressKeyPress = True
            txtSelectedWord.SelectionStart = Test + 1
        End If
        If e.Alt = False And e.Control = False And e.Shift = True And e.KeyCode = 82 Then
            Test = txtSelectedWord.SelectionStart
            txtSelectedWord.Text = txtSelectedWord.Text.Insert(txtSelectedWord.SelectionStart, "ঈ")
            e.SuppressKeyPress = True
            txtSelectedWord.SelectionStart = Test + 1
        End If
        If e.Alt = False And e.Control = False And e.Shift = True And e.KeyCode = 71 Then
            Test = txtSelectedWord.SelectionStart
            txtSelectedWord.Text = txtSelectedWord.Text.Insert(txtSelectedWord.SelectionStart, "উ")
            e.SuppressKeyPress = True
            txtSelectedWord.SelectionStart = Test + 1
        End If
        If e.Alt = False And e.Control = False And e.Shift = True And e.KeyCode = 84 Then
            Test = txtSelectedWord.SelectionStart
            txtSelectedWord.Text = txtSelectedWord.Text.Insert(txtSelectedWord.SelectionStart, "ঊ")
            e.SuppressKeyPress = True
            txtSelectedWord.SelectionStart = Test + 1
        End If
        If e.Alt = False And e.Control = False And e.Shift = True And e.KeyCode = 90 Then
            Test = txtSelectedWord.SelectionStart
            txtSelectedWord.Text = txtSelectedWord.Text.Insert(txtSelectedWord.SelectionStart, "ঋ")
            e.SuppressKeyPress = True
            txtSelectedWord.SelectionStart = Test + 1
        End If
        If e.Alt = False And e.Control = False And e.Shift = True And e.KeyCode = 83 Then
            Test = txtSelectedWord.SelectionStart
            txtSelectedWord.Text = txtSelectedWord.Text.Insert(txtSelectedWord.SelectionStart, "এ")
            e.SuppressKeyPress = True
            txtSelectedWord.SelectionStart = Test + 1
        End If
        If e.Alt = False And e.Control = False And e.Shift = True And e.KeyCode = 87 Then
            Test = txtSelectedWord.SelectionStart
            txtSelectedWord.Text = txtSelectedWord.Text.Insert(txtSelectedWord.SelectionStart, "ঐ")
            e.SuppressKeyPress = True
            txtSelectedWord.SelectionStart = Test + 1
        End If
        If e.Alt = False And e.Control = False And e.Shift = True And e.KeyCode = 65 Then
            Test = txtSelectedWord.SelectionStart
            txtSelectedWord.Text = txtSelectedWord.Text.Insert(txtSelectedWord.SelectionStart, "ও")
            e.SuppressKeyPress = True
            txtSelectedWord.SelectionStart = Test + 1
        End If
        If e.Alt = False And e.Control = False And e.Shift = True And e.KeyCode = 81 Then
            Test = txtSelectedWord.SelectionStart
            txtSelectedWord.Text = txtSelectedWord.Text.Insert(txtSelectedWord.SelectionStart, "ঔ")
            e.SuppressKeyPress = True
            txtSelectedWord.SelectionStart = Test + 1
        End If
        If e.Alt = False And e.Control = False And e.Shift = False And e.KeyCode = 88 Then
            Test = txtSelectedWord.SelectionStart
            txtSelectedWord.Text = txtSelectedWord.Text.Insert(txtSelectedWord.SelectionStart, "ং")
            e.SuppressKeyPress = True
            txtSelectedWord.SelectionStart = Test + 1
        End If
        If e.Alt = False And e.Control = False And e.Shift = True And e.KeyCode = 88 Then
            Test = txtSelectedWord.SelectionStart
            txtSelectedWord.Text = txtSelectedWord.Text.Insert(txtSelectedWord.SelectionStart, "ঁ")
            e.SuppressKeyPress = True
            txtSelectedWord.SelectionStart = Test + 1
        End If
        If e.Alt = False And e.Control = False And e.Shift = True And e.KeyCode = 187 Then
            Test = txtSelectedWord.SelectionStart
            txtSelectedWord.Text = txtSelectedWord.Text.Insert(txtSelectedWord.SelectionStart, "ঃ")
            e.SuppressKeyPress = True
            txtSelectedWord.SelectionStart = Test + 1
        End If
        If e.Alt = False And e.Control = False And e.Shift = False And e.KeyCode = 68 Then
            Test = txtSelectedWord.SelectionStart
            txtSelectedWord.Text = txtSelectedWord.Text.Insert(txtSelectedWord.SelectionStart, "্")
            e.SuppressKeyPress = True
            txtSelectedWord.SelectionStart = Test + 1
        End If
        '=========================
        If e.Alt = False And e.Control = False And e.Shift = False And e.KeyCode = 69 Then
            Test = txtSelectedWord.SelectionStart
            txtSelectedWord.Text = txtSelectedWord.Text.Insert(txtSelectedWord.SelectionStart, "া")
            e.SuppressKeyPress = True
            txtSelectedWord.SelectionStart = Test + 1
        End If
        If e.Alt = False And e.Control = False And e.Shift = False And e.KeyCode = 70 Then
            Test = txtSelectedWord.SelectionStart
            txtSelectedWord.Text = txtSelectedWord.Text.Insert(txtSelectedWord.SelectionStart, "ি")
            e.SuppressKeyPress = True
            txtSelectedWord.SelectionStart = Test + 1
        End If
        If e.Alt = False And e.Control = False And e.Shift = False And e.KeyCode = 82 Then
            Test = txtSelectedWord.SelectionStart
            txtSelectedWord.Text = txtSelectedWord.Text.Insert(txtSelectedWord.SelectionStart, "ী")
            e.SuppressKeyPress = True
            txtSelectedWord.SelectionStart = Test + 1
        End If
        If e.Alt = False And e.Control = False And e.Shift = False And e.KeyCode = 71 Then
            Test = txtSelectedWord.SelectionStart
            txtSelectedWord.Text = txtSelectedWord.Text.Insert(txtSelectedWord.SelectionStart, "ু")
            e.SuppressKeyPress = True
            txtSelectedWord.SelectionStart = Test + 1
        End If
        If e.Alt = False And e.Control = False And e.Shift = False And e.KeyCode = 84 Then
            Test = txtSelectedWord.SelectionStart
            txtSelectedWord.Text = txtSelectedWord.Text.Insert(txtSelectedWord.SelectionStart, "ূ")
            e.SuppressKeyPress = True
            txtSelectedWord.SelectionStart = Test + 1
        End If
        If e.Alt = False And e.Control = False And e.Shift = False And e.KeyCode = 90 Then
            Test = txtSelectedWord.SelectionStart
            txtSelectedWord.Text = txtSelectedWord.Text.Insert(txtSelectedWord.SelectionStart, "ৃ")
            e.SuppressKeyPress = True
            txtSelectedWord.SelectionStart = Test + 1
        End If
        If e.Alt = False And e.Control = False And e.Shift = False And e.KeyCode = 83 Then
            Test = txtSelectedWord.SelectionStart
            txtSelectedWord.Text = txtSelectedWord.Text.Insert(txtSelectedWord.SelectionStart, "ে")
            e.SuppressKeyPress = True
            txtSelectedWord.SelectionStart = Test + 1
        End If
        If e.Alt = False And e.Control = False And e.Shift = False And e.KeyCode = 87 Then
            Test = txtSelectedWord.SelectionStart
            txtSelectedWord.Text = txtSelectedWord.Text.Insert(txtSelectedWord.SelectionStart, "ৈ")
            e.SuppressKeyPress = True
            txtSelectedWord.SelectionStart = Test + 1
        End If
        If e.Alt = False And e.Control = False And e.Shift = False And e.KeyCode = 65 Then
            Test = txtSelectedWord.SelectionStart
            txtSelectedWord.Text = txtSelectedWord.Text.Insert(txtSelectedWord.SelectionStart, "ো")
            e.SuppressKeyPress = True
            txtSelectedWord.SelectionStart = Test + 1
        End If
        If e.Alt = False And e.Control = False And e.Shift = False And e.KeyCode = 81 Then
            Test = txtSelectedWord.SelectionStart
            txtSelectedWord.Text = txtSelectedWord.Text.Insert(txtSelectedWord.SelectionStart, "ৌ")
            e.SuppressKeyPress = True
            txtSelectedWord.SelectionStart = Test + 1
        End If
        If e.Alt = False And e.Control = False And e.Shift = False And e.KeyCode = 192 Then
            Test = txtSelectedWord.SelectionStart
            txtSelectedWord.Text = txtSelectedWord.Text.Insert(txtSelectedWord.SelectionStart, "্য")
            e.SuppressKeyPress = True
            txtSelectedWord.SelectionStart = Test + 1
        End If
        If e.Alt = False And e.Control = False And e.Shift = True And e.KeyCode = 52 Then
            Test = txtSelectedWord.SelectionStart
            txtSelectedWord.Text = txtSelectedWord.Text.Insert(txtSelectedWord.SelectionStart, "ৰ্")
            e.SuppressKeyPress = True
            txtSelectedWord.SelectionStart = Test + 1
        End If
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        If txtContent.Text = "" Then
            Me.Close()
        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCopy.Click
        'txtContent.Copy()
        If txtContent.Text.Length = 0 Then
            Exit Sub
        End If
        Clipboard.SetText(txtContent.Text)
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPaste.Click
        If Clipboard.GetText.Length = 0 Then
            Exit Sub
        End If
        txtContent.Paste()
    End Sub

    Private Sub Button1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        If uniqueWordList.Count >= 300000 Then
            MsgBox("Unable to add the word. No more word can be added.", MsgBoxStyle.Information)
            Exit Sub
        End If
        If firstWrongWordIndex = 0 And firstWrongWordText = "" Then
            Exit Sub
        End If
        If firstWrongWordText = "" Then
            Exit Sub
        End If
        Dim newWordToAdd As String = Encrypt(firstWrongWordText, strEncodeString)
        Dim sw As StreamWriter
        Try
            If (Not File.Exists(txtPath)) Then
                MsgBox("Error in adding the word.", MsgBoxStyle.Critical, "Error")
                Exit Sub
            Else
                sw = File.AppendText(txtPath)
                sw.Write(newWordToAdd & ",")
                sw.Close()
            End If
        Catch ex As IOException
            MsgBox("Error adding the word.")
        End Try
        btnAdd.Visible = False
        loadFromTheTxtFile()
        ignoreSingleWord()
        If lbSuggestedList.Items.Count > 0 Then
            lblSuggest.Text = "Suggestions."
        Else
            lblSuggest.Text = "Not in the dictionary."
        End If
    End Sub
End Class