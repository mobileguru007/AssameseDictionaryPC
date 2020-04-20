Imports System.Data.OleDb

Public Class xNaming

    Private Sub Naming_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        getConn()
        loadConsonent(gvCons)
        loadVowel(gvVowel)

        Me.Size = New System.Drawing.Size(900, 663)
        LoadAllNames()
        txtWord.Focus()

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
            'MsgBox(ex.Message)
            Exit Function
        End Try
        txtWord.Focus()
    End Function

    Private Sub gvCons_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gvCons.CellContentClick
        'txtName.Text = ""
        If gvCons.CurrentCell.Value <> "" Then
            Dim xText As String = gvCons.CurrentCell.Value.ToString.Trim
            If xText.Trim.Length > 0 Then
                'txtName.Text = xText
                'ShowNames(xText, 0)
                SendLetter(xText)

            End If
        End If
    End Sub

    Private Function ShowNames(ByVal myval As String, Optional ByVal track As Integer = 0) As Boolean
        lvNames.Items.Clear()
        If track = 0 Then
            Try
                If myval = "" Then
                    Exit Function
                End If
                Dim myStr As String = Nothing
                myStr = "SELECT ID, NameWord FROM NameWord WHERE SearchChar='" & myval & "' ORDER BY ID ASC"
                Dim objCmd As New OleDbCommand(myStr, objConn)
                Dim rs As OleDbDataReader = objCmd.ExecuteReader
                If rs.HasRows Then
                    Do While rs.Read
                        Dim xItem As ListViewItem
                        xItem = lvNames.Items.Add(rs("ID"), IIf(IsDBNull(rs("NameWord")), "", rs("NameWord")), "")
                    Loop
                End If
            Catch ex As Exception
                ShowNames = False
                'MsgBox(ex.Message)
                Exit Function
            End Try
        End If
        ShowNames = True
        txtWord.Focus()
    End Function

    Private Sub gvVowel_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gvVowel.CellContentClick
        'txtName.Text = ""
        'lvNames.Items.Clear()
        'If gvVowel.CurrentCell.Value <> "" Then
        '    Dim xText As String = gvVowel.CurrentCell.Value.ToString.Trim
        '    If xText.Trim.Length > 0 Then
        '        txtName.Text = xText
        '        ShowNames(xText, 0)
        '    End If
        'End If
        'txtName.Text = ""
        If gvCons.CurrentCell.Value <> "" Then
            Dim xText As String = gvVowel.CurrentCell.Value.ToString.Trim
            If xText.Trim.Length > 0 Then
                'txtName.Text = xText
                'ShowNames(xText, 0)
                SendLetter(xText)

            End If
        End If
    End Sub

    Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click
        If txtWord.Text.Trim.Length = 0 Then
            Exit Sub
        End If
        txtWord.Text = ""
        txtAssMean.Text = ""
        txtEngMean.Text = ""
        lvNames.Items.Clear()
        txtWord.Focus()
        LoadAllNames()
    End Sub

    Private Sub lvNames_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvNames.SelectedIndexChanged
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
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub SendLetter(ByVal Letter As String)
        'If rbtnAssamese.Checked = False Then
        '    MsgBox("Please select the Assamese option first.", MsgBoxStyle.Information, "Dictionary")
        '    txtWord.Focus()
        '    Exit Sub
        'End If
        composeQueryStr(txtWord.Text, Letter)
    End Sub

    Protected Sub composeQueryStr(ByVal inputTxt As String, ByVal cmdTxt As String)
        If txtWord.Text.Trim.Length > 25 Then Exit Sub
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



    Private Sub txtName_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtWord.TextChanged
        txtAssMean.Text = ""
        txtEngMean.Text = ""
        lvNames.Items.Clear()
        If txtWord.Text.Trim.Length > 49 Then Exit Sub
        If txtWord.Text = "" Then
            lvNames.Items.Clear()
            Exit Sub
        End If

        lvNames.Items.Clear()

        ShowWords(lvNames, txtWord.Text.Trim, 0)

        FirstRowSelect()
    End Sub


    Private Sub FirstRowSelect()
        lvNames.Refresh()
        Try
            If lvNames.Items.Count > 0 Then

                lvNames.SelectedIndices.Clear()
                lvNames.Refresh()
                lvNames.HideSelection = False
                lvNames.Items(0).Selected = True
            Else
                If lvNames.Items.Count = 0 Then
                Else
                    lvNames.SelectedIndices.Clear()
                    lvNames.Refresh()
                    lvNames.HideSelection = False
                    lvNames.Items(0).Selected = True
                End If
            End If
        Catch ex As Exception
            Exit Sub
        End Try


    End Sub

    Private Sub txtWord_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtWord.KeyDown
        Dim Test As Integer = 0
        'lblProbableWords.Text = e.KeyCode
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
            txtWord.SelectionStart = Test + 1
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
        If e.Alt = False And e.Control = False And e.Shift = True And e.KeyCode = 187 Then
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
            txtWord.SelectionStart = Test + 1
        End If
    End Sub
    Function ShowWords(ByRef Mybox As ListView, ByVal myval As String, Optional ByVal track As Integer = 0) As Boolean
        If track = 0 Then
            If Len(myval) = 1 Then myval = "len(nameword)>=1 and len(nameword)<=40 and left(nameword, " & Len(myval) & ")= '" & myval.Substring(0, 1) & "'" 'myval.Substring(1) & "'"
            If Len(myval) = 2 Then myval = "len(nameword)>=2 and len(nameword)<=45 and left(nameword, " & Len(myval) & ")= '" & myval.Substring(0, 2) & "'"
            If Len(myval) = 3 Then myval = "len(nameword)>=3 and len(nameword)<=50 and left(nameword, " & Len(myval) & ")= '" & myval.Substring(0, 3) & "'"
            If Len(myval) = 4 Then myval = "len(nameword)>=4 and len(nameword)<=65 and left(nameword, " & Len(myval) & ")= '" & myval.Substring(0, 4) & "'"
            If Len(myval) = 5 Then myval = "len(nameword)>=5 and len(nameword)<=70 and left(nameword, " & Len(myval) & ")= '" & myval.Substring(0, 5) & "'"
            If Len(myval) = 6 Then myval = "len(nameword)>=6 and len(nameword)<=75 and left(nameword, " & Len(myval) & ")= '" & myval.Substring(0, 6) & "'"
            If Len(myval) = 7 Then myval = "len(nameword)>=7 and len(nameword)<=80 and left(nameword, " & Len(myval) & ")= '" & myval.Substring(0, 7) & "'"
            If Len(myval) = 8 Then myval = "len(nameword)>=8 and len(nameword)<=85 and left(nameword, " & Len(myval) & ")= '" & myval.Substring(0, 8) & "'"
            If Len(myval) = 9 Then myval = "len(nameword)>=9 and len(nameword)<=90 and left(nameword, " & Len(myval) & ")= '" & myval.Substring(0, 9) & "'"
            If Len(myval) = 10 Then myval = "len(nameword)>=10 and len(nameword)<=95 and left(nameword, " & Len(myval) & ")= '" & myval.Substring(0, 10) & "'"
            If Len(myval) = 11 Then myval = "len(nameword)>=11 and len(nameword)<=100 and left(nameword, " & Len(myval) & ")= '" & myval.Substring(0, 11) & "'"
            If Len(myval) = 12 Then myval = "len(nameword)>=12 and len(nameword)<=105 and left(nameword, " & Len(myval) & ")= '" & myval.Substring(0, 12) & "'"
            If Len(myval) = 13 Then myval = "len(nameword)>=13  and left(nameword, " & Len(myval) & ")= '" & myval.Substring(0, 13) & "'"
            If Len(myval) = 14 Then myval = "len(nameword)>=14  and left(nameword, " & Len(myval) & ")= '" & myval.Substring(0, 14) & "'"
            If Len(myval) = 15 Then myval = "len(nameword)>=15  and left(nameword, " & Len(myval) & ")= '" & myval.Substring(0, 15) & "'"
            If Len(myval) = 16 Then myval = "len(nameword)>=16  and left(nameword, " & Len(myval) & ")= '" & myval.Substring(0, 16) & "'"
            If Len(myval) = 17 Then myval = "len(nameword)>=17  and left(nameword, " & Len(myval) & ")= '" & myval.Substring(0, 17) & "'"
            If Len(myval) = 18 Then myval = "len(nameword)>=18  and left(nameword, " & Len(myval) & ")= '" & myval.Substring(0, 18) & "'"
            If Len(myval) = 19 Then myval = "len(nameword)>=19  and left(nameword, " & Len(myval) & ")= '" & myval.Substring(0, 19) & "'"
            If Len(myval) = 20 Then myval = "len(nameword)>=20  and left(nameword, " & Len(myval) & ")= '" & myval.Substring(0, 20) & "'"
            If Len(myval) = 21 Then myval = "len(nameword)>=21  and left(nameword, " & Len(myval) & ")= '" & myval.Substring(0, 21) & "'"
            If Len(myval) = 22 Then myval = "len(nameword)>=22  and left(nameword, " & Len(myval) & ")= '" & myval.Substring(0, 22) & "'"
            If Len(myval) = 23 Then myval = "len(nameword)>=23  and left(nameword, " & Len(myval) & ")= '" & myval.Substring(0, 23) & "'"
            If Len(myval) = 24 Then myval = "len(nameword)>=24  and left(nameword, " & Len(myval) & ")= '" & myval.Substring(0, 24) & "'"
            If Len(myval) = 25 Then myval = "len(nameword)>=25  and left(nameword, " & Len(myval) & ")= '" & myval.Substring(0, 25) & "'"
            If Len(myval) = 26 Then myval = "len(nameword)>=26  and left(nameword, " & Len(myval) & ")= '" & myval.Substring(0, 26) & "'"
            If Len(myval) = 27 Then myval = "len(nameword)>=27  and left(nameword, " & Len(myval) & ")= '" & myval.Substring(0, 27) & "'"
            If Len(myval) = 28 Then myval = "len(nameword)>=28  and left(nameword, " & Len(myval) & ")= '" & myval.Substring(0, 28) & "'"

            If Len(myval) = 29 Then myval = "len(nameword)>=29  and left(nameword, " & Len(myval) & ")= '" & myval.Substring(0, 29) & "'"
            If Len(myval) = 30 Then myval = "len(nameword)>=30  and left(nameword, " & Len(myval) & ")= '" & myval.Substring(0, 30) & "'"
            If Len(myval) = 31 Then myval = "len(nameword)>=31  and left(nameword, " & Len(myval) & ")= '" & myval.Substring(0, 31) & "'"
            If Len(myval) = 32 Then myval = "len(nameword)>=32  and left(nameword, " & Len(myval) & ")= '" & myval.Substring(0, 32) & "'"
            If Len(myval) = 33 Then myval = "len(nameword)>=33  and left(nameword, " & Len(myval) & ")= '" & myval.Substring(0, 33) & "'"
            If Len(myval) = 34 Then myval = "len(nameword)>=34  and left(nameword, " & Len(myval) & ")= '" & myval.Substring(0, 34) & "'"
            If Len(myval) = 35 Then myval = "len(nameword)>=35  and left(nameword, " & Len(myval) & ")= '" & myval.Substring(0, 35) & "'"
            If Len(myval) = 36 Then myval = "len(nameword)>=36  and left(nameword, " & Len(myval) & ")= '" & myval.Substring(0, 36) & "'"
            If Len(myval) = 37 Then myval = "len(nameword)>=37  and left(nameword, " & Len(myval) & ")= '" & myval.Substring(0, 37) & "'"
            If Len(myval) = 38 Then myval = "len(nameword)>=38  and left(nameword, " & Len(myval) & ")= '" & myval.Substring(0, 38) & "'"
            If Len(myval) = 39 Then myval = "len(nameword)>=39  and left(nameword, " & Len(myval) & ")= '" & myval.Substring(0, 39) & "'"
            If Len(myval) = 40 Then myval = "len(nameword)>=40  and left(nameword, " & Len(myval) & ")= '" & myval.Substring(0, 40) & "'"

            If Len(myval) = 41 Then myval = "len(nameword)>=41  and left(nameword, " & Len(myval) & ")= '" & myval.Substring(0, 41) & "'"
            If Len(myval) = 42 Then myval = "len(nameword)>=42  and left(nameword, " & Len(myval) & ")= '" & myval.Substring(0, 42) & "'"
            If Len(myval) = 43 Then myval = "len(nameword)>=43  and left(nameword, " & Len(myval) & ")= '" & myval.Substring(0, 43) & "'"
            If Len(myval) = 44 Then myval = "len(nameword)>=44  and left(nameword, " & Len(myval) & ")= '" & myval.Substring(0, 44) & "'"
            If Len(myval) = 45 Then myval = "len(nameword)>=45  and left(nameword, " & Len(myval) & ")= '" & myval.Substring(0, 45) & "'"
            If Len(myval) = 46 Then myval = "len(nameword)>=46  and left(nameword, " & Len(myval) & ")= '" & myval.Substring(0, 46) & "'"
            If Len(myval) = 47 Then myval = "len(nameword)>=47  and left(nameword, " & Len(myval) & ")= '" & myval.Substring(0, 47) & "'"
            If Len(myval) = 48 Then myval = "len(nameword)>=48  and left(nameword, " & Len(myval) & ")= '" & myval.Substring(0, 48) & "'"
            If Len(myval) = 49 Then myval = "len(nameword)>=49  and left(nameword, " & Len(myval) & ")= '" & myval.Substring(0, 49) & "'"

            Try
                lvNames.Items.Clear()
                If myval = "" Then
                    Exit Function
                End If
                Dim myStr As String = Nothing
                myStr = "SELECT ID, NameWord FROM NameWord WHERE " & myval & " ORDER BY id, [NameWord] ASC"

                Dim objCmd As New OleDbCommand(myStr, objConn)
                Dim rs As OleDbDataReader = objCmd.ExecuteReader
                If rs.HasRows Then
                    Dim xItem As ListViewItem
                    Do While rs.Read
                        xItem = Mybox.Items.Add(rs("ID"), IIf(IsDBNull(rs("NameWord")), "", rs("NameWord")), "")
                    Loop
                Else
                    ShowWords = False
                    Exit Function
                End If
            Catch ex As Exception
                'MsgBox(ex.Message)
                ShowWords = False
                Exit Function
            End Try
        ElseIf track = True Then
            ShowWords = track
            Exit Function
        End If
        ShowWords = True
    End Function

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

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        SendLetter("্য")
    End Sub

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        SendLetter("্")
    End Sub

    Private Sub Command5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Command5.Click
        'If rbtnAssamese.Checked = False Then
        '    txtWord.Focus()
        '    Exit Sub
        'End If
        If txtWord.Text = "" Then Exit Sub
        composeQueryStr(txtWord.Text, " ")
    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        txtAssMean.Text = ""
        txtEngMean.Text = ""


        lvNames.Items.Clear()

        lvNames.Refresh()
        If Len(txtWord.Text) = 0 Then Exit Sub
        txtWord.Text = LSet(txtWord.Text, Len(txtWord.Text) - 1)

        FirstRowSelect()
    End Sub

End Class