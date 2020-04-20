
Imports System.Data.OleDb
Imports System.Windows.Forms.DataGrid
Imports System.IO
Imports System.Security.Cryptography
Imports System.Text
Public Class wordsearchextra
    Dim cmd As New OleDbCommand
    Dim lowerID As Integer = 711
    Dim upperID As Integer = 883
    Dim SearchText As String = "As_Search"
    Dim orderBy As String = "ID"
    Dim QueryText As String = " Eng_Meaning AS fld1, Hin_Meaning AS fld2, Sc_Meaning AS fld3"
    Dim pinCodLoaded As Boolean = False

    Private Sub wordsearchextra_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        With DataGridView1
            .Columns(0).DefaultCellStyle.Font = New Font("Asomiya_Rohini", 10, FontStyle.Bold)
        End With
        lvWords.Font = New System.Drawing.Font("Asomiya_Rohini", 14.25!, FontStyle.Regular, GraphicsUnit.Point, CType(0, Byte))


        'If Not loadListview(lowerID, upperID, SearchText, orderBy) Then
        '    Exit Sub
        'End If

        txtMeaning.Font = New System.Drawing.Font("Asomiya_Rohini", 16.25!, FontStyle.Regular, GraphicsUnit.Point, CType(0, Byte))

    End Sub

    Private Function loadListview(ByVal low As Integer, ByVal high As Integer, ByVal searchField As String, ByVal orderBy As String) As Boolean
        Try
            lvWords.Items.Clear()
            cmd = New OleDbCommand("SELECT ID," & searchField & " AS SearchField FROM CateTable WHERE ID>=" & low & " AND ID<=" & high & " ORDER BY " & orderBy, objConn)
            Dim dr As OleDbDataReader = cmd.ExecuteReader
            If dr.HasRows Then
                Dim xItem As ListViewItem
                Do While dr.Read

                    Dim myword As String = IIf(IsDBNull(dr("SearchField")), "", dr("SearchField"))
                    If myword <> "" Then
                        xItem = lvWords.Items.Add(dr("ID"), myword, "")
                    End If
                Loop
            End If
            FirstRowSelect()
        Catch ex As Exception
            Return False
        End Try

        Return True
    End Function

    Private Function loadCountry(ByVal low As Integer, ByVal high As Integer, ByVal searchField As String, ByVal orderBy As String) As Boolean
        Try
            lvWords.Items.Clear()
            cmd = New OleDbCommand("SELECT ID," & searchField & " AS SearchField FROM Country WHERE ID>=" & low & " AND ID<=" & high & " ORDER BY " & orderby, objConn)
            Dim dr As OleDbDataReader = cmd.ExecuteReader
            If dr.HasRows Then
                Dim xItem As ListViewItem
                Do While dr.Read

                    Dim myword As String = IIf(IsDBNull(dr("SearchField")), "", dr("SearchField"))
                    If myword <> "" Then
                        xItem = lvWords.Items.Add(dr("ID"), myword, "")
                    End If
                Loop

            End If
            FirstRowSelect()
        Catch ex As Exception
            Return False
        End Try
        Return True

    End Function


    Private Sub rbtnAssamese_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtnAssamese.CheckedChanged
        DataGridView1.Rows.Clear()
        For i = 0 To DataGridView1.Rows.Count - 1
            DataGridView1.Rows(i).Height = 35
        Next
        QueryText = " Eng_Meaning AS fld1, Hin_Meaning AS fld2, Sc_Meaning AS fld3"
        lvWords.Items.Clear()
        lvWords.Font = New System.Drawing.Font("Asomiya_Rohini", 14.25!, FontStyle.Regular, GraphicsUnit.Point, CType(0, Byte))
        txtWord.Font = New System.Drawing.Font("Asomiya_Rohini", 13.0!, FontStyle.Regular, GraphicsUnit.Point, CType(0, Byte))
        txtWord.Text = ""

        lvWords.Items.Clear()
        SearchText = "As_Search"
        orderBy = "ID"
        'If rbtnCountry.Checked = False Then
        '    If Not loadListview(lowerID, upperID, SearchText, orderBy) Then
        '        Exit Sub
        '    End If
        'ElseIf rbtnCountry.Checked = True Then
        '    If Not loadCountry(lowerID, upperID, SearchText, orderBy) Then
        '        Exit Sub
        '    End If
        'End If

        If rbtnCountry.Checked = False Then
            If Not loadSelectedData(lowerID, upperID, SearchText, orderBy) Then
                Exit Sub
            End If
        ElseIf rbtnCountry.Checked = True Then
            If Not LoadSelectedCountry(lowerID, upperID, SearchText, orderBy) Then
                Exit Sub
            End If
        End If
       

    End Sub

    Private Sub rbtnEnglish_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtnEnglish.CheckedChanged
        DataGridView1.Rows.Clear()
        For i = 0 To DataGridView1.Rows.Count - 1
            DataGridView1.Rows(i).Height = 35
        Next

        QueryText = " As_Meaning AS fld1, Hin_Meaning AS fld2, Sc_Meaning AS fld3"
        

        lvWords.Items.Clear()
        lvWords.Font = New System.Drawing.Font("Times New Roman", 14.25!, FontStyle.Regular, GraphicsUnit.Point, CType(0, Byte))
        txtWord.Font = New System.Drawing.Font("Times New Roman", 14.25!, FontStyle.Regular, GraphicsUnit.Point, CType(0, Byte))
        txtWord.Text = ""

        SearchText = "Eng_Search"
        orderBy = "Eng_Search"
        
        'If rbtnCountry.Checked = False Then
        '    If Not loadListview(lowerID, upperID, SearchText, orderBy) Then
        '        Exit Sub
        '    End If
        'ElseIf rbtnCountry.Checked = True Then
        '    If Not loadCountry(lowerID, upperID, SearchText, orderBy) Then
        '        Exit Sub
        '    End If
        'End If
        If rbtnCountry.Checked = False Then

            If rbtnDate.Checked = True Then
                If Not loadSelectedData(lowerID, upperID, SearchText, "ID") Then
                    Exit Sub
                End If
            Else
                If Not loadSelectedData(lowerID, upperID, SearchText, orderBy) Then
                    Exit Sub
                End If
            End If



        ElseIf rbtnCountry.Checked = True Then
            If Not LoadSelectedCountry(lowerID, upperID, SearchText, orderBy) Then
                Exit Sub
            End If
        End If

        
    End Sub

    Private Sub rbtnHindi_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtnHindi.CheckedChanged
        DataGridView1.Rows.Clear()
        For i = 0 To DataGridView1.Rows.Count - 1
            DataGridView1.Rows(i).Height = 35
        Next

        QueryText = " As_Meaning AS fld1, Eng_Meaning AS fld2, Sc_Meaning AS fld3"
        lvWords.Items.Clear()
        lvWords.Font = New System.Drawing.Font("Mongol", 16.25!, FontStyle.Regular, GraphicsUnit.Point, CType(0, Byte))
        txtWord.Font = New System.Drawing.Font("Mongol", 14.25!, FontStyle.Regular, GraphicsUnit.Point, CType(0, Byte))
        txtWord.Text = ""

        SearchText = "Hin_Search"
        orderBy = "Hin_Search"
        'If Not loadListview(lowerID, upperID, SearchText, orderBy) Then
        '    Exit Sub
        'End If
        If rbtnDate.Checked = True Then
            If Not loadSelectedData(lowerID, upperID, SearchText, "ID") Then
                Exit Sub
            End If
        Else
            If Not loadSelectedData(lowerID, upperID, SearchText, orderBy) Then
                Exit Sub
            End If
        End If


        'If Not loadSelectedData(lowerID, upperID, SearchText, orderBy) Then
        '    Exit Sub
        'End If
    End Sub

    Private Sub rbtnAnimal_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtnAnimal.CheckedChanged
        lvWords.Items.Clear()
        txtWord.Text = ""
        DataGridView1.Visible = True
        imgRetrieve.Visible = True
        lowerID = 710
        upperID = 883
        If rbtnEnglish.Checked = False Then
            If Not loadListview(lowerID, upperID, SearchText, "ID") Then
                Exit Sub
            End If
        ElseIf rbtnEnglish.Checked = True Or rbtnHindi.Checked = True Then
            If Not loadListview(lowerID, upperID, SearchText, SearchText) Then
                Exit Sub
            End If
        End If


    End Sub

    Private Sub rbtnBird_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtnBird.CheckedChanged
        lvWords.Items.Clear()
        txtWord.Text = ""
        DataGridView1.Visible = True
        imgRetrieve.Visible = True
        lowerID = 889
        upperID = 1287
        If Not loadListview(lowerID, upperID, SearchText, "ID") Then
            Exit Sub
        End If
    End Sub

    Private Sub rbtnCountry_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtnCountry.CheckedChanged

        lvWords.Items.Clear()
        txtWord.Text = ""
        If rbtnCountry.Checked = True Then
            rbtnHindi.Enabled = False
            rbtnAssamese.Checked = True
            txtMeaning.Visible = True
            txtMeaning.Text = ""
        ElseIf rbtnCountry.Checked = False Then
            rbtnHindi.Enabled = True
            txtMeaning.Visible = False
        End If
        DataGridView1.Visible = False
        imgRetrieve.Visible = False

        lowerID = 1
        upperID = 221


        If Not loadCountry(lowerID, upperID, SearchText, orderBy) Then
            Exit Sub
        End If
    End Sub

    

    Private Sub rbtnFish_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtnFish.CheckedChanged
        lvWords.Items.Clear()
        txtWord.Text = ""
        DataGridView1.Visible = True
        imgRetrieve.Visible = True
        lowerID = 6067
        upperID = 6257
        If Not loadListview(lowerID, upperID, SearchText, "ID") Then
            Exit Sub
        End If
    End Sub

    Private Sub rbtnSName_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtnSName.CheckedChanged
        lvWords.Items.Clear()
        txtWord.Text = ""
        If rbtnSName.Checked = True Then
            rbtnEnglish.Checked = False
            rbtnHindi.Enabled = False
            rbtnAssamese.Enabled = False
            rbtnEnglish.Enabled = False
            rbtnEnglish.Checked = True
        ElseIf rbtnSName.Checked = False Then
            rbtnHindi.Enabled = True
            rbtnAssamese.Enabled = True
            rbtnEnglish.Enabled = True
        End If
        DataGridView1.Visible = True
        imgRetrieve.Visible = True

        lowerID = 710
        upperID = 7029
        
        If Not loadListview(lowerID, upperID, "Sc_Search", "Sc_Search") Then
            Exit Sub
        End If

    End Sub

    Private Sub rbtnDate_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtnDate.CheckedChanged

        lvWords.Items.Clear()
        txtWord.Text = ""
        If rbtnDate.Checked = True Then
            txtMeaning.Visible = True
            txtMeaning.Text = ""
        ElseIf rbtnDate.Checked = False Then
            txtMeaning.Visible = False
        End If

        DataGridView1.Visible = False
        imgRetrieve.Visible = False
        lowerID = 1291
        upperID = 1440
        If Not loadListview(lowerID, upperID, SearchText, "ID") Then
            Exit Sub
        End If
    End Sub

    Private Sub rbtnPin_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtnPin.CheckedChanged

        lvWords.Items.Clear()
        txtWord.Text = ""
        If rbtnPin.Checked = True Then
            rbtnHindi.Enabled = False
            rbtnAssamese.Enabled = False
            rbtnEnglish.Checked = True
            rbtnEnglish.Enabled = False
            'txtMeaning.Visible = True
            txtMeaning.Text = ""
            DataGridView2.Visible = True
        ElseIf rbtnPin.Checked = False Then
            rbtnHindi.Enabled = True
            rbtnAssamese.Enabled = True
            rbtnEnglish.Enabled = True
            'txtMeaning.Visible = False
            DataGridView2.Visible = False
        End If

        DataGridView1.Visible = False
        imgRetrieve.Visible = False
        lvWords.Items.Clear()
        'Dim lv As ListViewItem
        'Dim i As Integer
        'For i = 0 To dtPinCod.Tables(0).Rows.Count - 1 'Dataset have multiple tables, here I am reffering the first table
        '    lv = New ListViewItem

        '    lv.SubItems.Add(dtPinCod.Tables(0).Rows(i)("officename"))
        '    lv.SubItems.Add(dtPinCod.Tables(0).Rows(i)("pincode"))
        '    'lv.SubItems.Add(dtPinCod.Tables(0).Rows(i)("Fname"))

        '    lvWords.Items.Add(lv) 'Listview control
        'Next

    End Sub

    Private Sub rbtnLaw_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtnLaw.CheckedChanged

        lvWords.Items.Clear()
        txtWord.Text = ""
        If rbtnLaw.Checked = True Then
            rbtnHindi.Enabled = False
            rbtnEnglish.Checked = True
            txtMeaning.Visible = True
            txtMeaning.Text = ""
        ElseIf rbtnLaw.Checked = False Then
            rbtnHindi.Enabled = True
            txtMeaning.Visible = False
        End If

        DataGridView1.Visible = False
        imgRetrieve.Visible = False
        lowerID = 2060
        upperID = 5662
        If Not loadListview(lowerID, upperID, SearchText, "ID") Then
            Exit Sub
        End If
    End Sub

    Private Sub btnFlower_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFlower.CheckedChanged

        lvWords.Items.Clear()
        txtWord.Text = ""
        txtWord.Text = ""
        DataGridView1.Visible = True
        imgRetrieve.Visible = True
        lowerID = 1449
        upperID = 1706
        If Not loadListview(lowerID, upperID, SearchText, "ID") Then
            Exit Sub
        End If
    End Sub

    Private Sub rbtnFruit_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtnFruit.CheckedChanged

        lvWords.Items.Clear()
        txtWord.Text = ""
        DataGridView1.Visible = True
        imgRetrieve.Visible = True
        lowerID = 1712
        upperID = 1906
        If Not loadListview(lowerID, upperID, SearchText, "ID") Then
            Exit Sub
        End If
    End Sub

    Private Sub rbtnInsect_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtnInsect.CheckedChanged

        lvWords.Items.Clear()
        txtWord.Text = ""
        DataGridView1.Visible = True
        imgRetrieve.Visible = True
        lowerID = 1912
        upperID = 2054
        If Not loadListview(lowerID, upperID, SearchText, "ID") Then
            Exit Sub
        End If
    End Sub

    Private Sub rbtnPlant_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtnPlant.CheckedChanged

        lvWords.Items.Clear()
        txtWord.Text = ""
        DataGridView1.Visible = True
        imgRetrieve.Visible = True
        lowerID = 6258
        upperID = 7034
        If Not loadListview(lowerID, upperID, SearchText, "ID") Then
            Exit Sub
        End If
    End Sub

    Private Sub rbtnToos_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtnToos.CheckedChanged

        lvWords.Items.Clear()
        txtWord.Text = ""
        DataGridView1.Visible = True
        imgRetrieve.Visible = True
        lowerID = 7035
        upperID = 7395
        'If rbtnHindi.Checked = True Then
        '    rbtnHindi.Checked = False
        '    rbtnHindi.Enabled = False
        'ElseIf rbtnToos.Checked = False Then
        '    rbtnHindi.Enabled = True
        'End If
        If rbtnToos.Checked = True Then
            rbtnAssamese.Checked = True
        End If

        If Not loadListview(lowerID, upperID, SearchText, "ID") Then
            Exit Sub
        End If


    End Sub

    Private Sub rbtnVeg_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtnVeg.CheckedChanged
        lvWords.Items.Clear()
        txtWord.Text = ""
        DataGridView1.Visible = True
        imgRetrieve.Visible = True
        lowerID = 5678
        upperID = 6065
        If Not loadListview(lowerID, upperID, SearchText, "ID") Then
            Exit Sub
        End If
    End Sub

    Private Sub txtWord_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtWord.KeyDown
        Dim Test As Integer = 0
        If rbtnAssamese.Checked = True Then
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

    Private Sub txtWord_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtWord.KeyPress
        If Val(e.KeyChar) = 108 Then
            Me.Close()
        End If
    End Sub

    Private Sub txtWord_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtWord.TextChanged
        txtMeaning.Text = ""

        imgRetrieve.Image = Nothing

        lvWords.Items.Clear()
        If txtWord.Text.Trim.Length > 49 Then Exit Sub

        If rbtnPin.Checked = True Then
            If Not loadSelectedPINCode(SearchText) Then
                Exit Sub
            End If
            Exit Sub
        End If

        If rbtnAssamese.Checked=True Then
            If rbtnCountry.Checked = False Then
                If Not loadSelectedData(lowerID, upperID, SearchText, orderBy) Then
                    Exit Sub
                End If
            ElseIf rbtnCountry.Checked = True Then
                If Not LoadSelectedCountry(lowerID, upperID, SearchText, orderBy) Then
                    Exit Sub
                End If
            End If
        ElseIf rbtnEnglish.Checked = True Then
            If rbtnCountry.Checked = False Then
                If Not loadSelectedData(lowerID, upperID, SearchText, orderBy) Then
                    Exit Sub
                End If
            ElseIf rbtnCountry.Checked = True Then
                If Not LoadSelectedCountry(lowerID, upperID, SearchText, orderBy) Then
                    Exit Sub
                End If
            End If
        ElseIf rbtnHindi.Checked = True Then
            If Not loadSelectedData(lowerID, upperID, SearchText, orderBy) Then
                Exit Sub
            End If
        End If

        

        FirstRowSelect()


    End Sub
    
    Private Sub lvWords_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvWords.SelectedIndexChanged
        imgRetrieve.Image = Nothing
        If lvWords.SelectedItems.Count <> 0 Then
            txtMeaning.Clear()
            LoadMeaning(lvWords.SelectedItems(0).Name)
        End If
    End Sub

    Private Sub LoadMeaning(ByVal xID As Integer)
        Try
            If rbtnAnimal.Checked = True Or rbtnBird.Checked = True Or rbtnFish.Checked = True Or btnFlower.Checked = True Or rbtnFruit.Checked = True Or rbtnInsect.Checked = True Or rbtnPlant.Checked = True Or rbtnSName.Checked = True Or rbtnToos.Checked = True Or rbtnVeg.Checked = True Then
                Dim myStr As String = Nothing
                If rbtnSName.Checked = True Then
                    QueryText = "As_Meaning AS fld1,  Hin_Meaning AS fld2 ,Eng_Meaning AS fld3"
                End If
                myStr = "SELECT " & QueryText & ", PictureID FROM CateTable WHERE ID=" & xID

                Dim objCmd As New OleDbCommand(myStr, objConn)
                Dim rs As OleDbDataReader = objCmd.ExecuteReader
                If rs.HasRows Then
                    rs.Read()
                    txtMeaning.Text = ""
                    Dim fld1 As String = IIf(IsDBNull(rs("fld1")), "", rs("fld1"))
                    Dim fld2 As String = IIf(IsDBNull(rs("fld2")), "", rs("fld2"))
                    Dim fld3 As String = IIf(IsDBNull(rs("fld3")), "", rs("fld3"))
                    DataGridView1.Font = New System.Drawing.Font("Asomiya_Rohini", 16.25!, FontStyle.Regular, GraphicsUnit.Point, CType(0, Byte))

                    If rbtnToos.Checked = True Then
                        If rbtnAssamese.Checked Then
                            DataGridView1.Rows.Clear()
                            DataGridView1.Rows.Add("English", Decrypt(fld1, strEncodeString))
                            DataGridView1.Rows.Add("Hindi", Decrypt(fld2, strEncodeString))
                            'DataGridView1.Rows.Add("Sc. Name", Decrypt(fld3, strEncodeString))
                            For i = 0 To DataGridView1.Rows.Count - 1
                                DataGridView1.Rows(i).Height = 35
                            Next
                        End If

                        If rbtnEnglish.Checked = True Then

                            DataGridView1.Rows.Clear()
                            DataGridView1.Rows.Add("Assamese", Decrypt(fld1, strEncodeString))
                            DataGridView1.Rows.Add("Hindi", Decrypt(fld2, strEncodeString))
                            'DataGridView1.Rows.Add("Sc. Name", Decrypt(fld3, strEncodeString))
                            For i = 0 To DataGridView1.Rows.Count - 1
                                DataGridView1.Rows(i).Height = 35
                            Next
                        End If
                        If rbtnHindi.Checked = True Then
                            Exit Sub
                        End If


                    ElseIf rbtnToos.Checked = False Then


                        If rbtnAssamese.Checked = True Then
                            DataGridView1.Rows.Clear()
                            DataGridView1.Rows.Add("English", Decrypt(fld1, strEncodeString))
                            DataGridView1.Rows.Add("Hindi", Decrypt(fld2, strEncodeString))
                            DataGridView1.Rows.Add("Sc. Name", Decrypt(fld3, strEncodeString))
                            For i = 0 To DataGridView1.Rows.Count - 1
                                DataGridView1.Rows(i).Height = 35
                            Next
                        End If
                        If rbtnEnglish.Checked = True Then
                            If rbtnSName.Checked = True Then
                                DataGridView1.Rows.Clear()
                                DataGridView1.Rows.Add("Assamese", Decrypt(fld1, strEncodeString))
                                DataGridView1.Rows.Add("Hindi", Decrypt(fld2, strEncodeString))
                                DataGridView1.Rows.Add("Eng Name", Decrypt(fld3, strEncodeString))
                            ElseIf rbtnSName.Checked = False Then
                                DataGridView1.Rows.Clear()
                                DataGridView1.Rows.Add("Assamese", Decrypt(fld1, strEncodeString))
                                DataGridView1.Rows.Add("Hindi", Decrypt(fld2, strEncodeString))
                                DataGridView1.Rows.Add("Sc. Name", Decrypt(fld3, strEncodeString))
                            End If

                            For i = 0 To DataGridView1.Rows.Count - 1
                                DataGridView1.Rows(i).Height = 35
                            Next
                        End If
                        If rbtnHindi.Checked = True Then
                            DataGridView1.Rows.Clear()
                            DataGridView1.Rows.Add("Assamese", Decrypt(fld1, strEncodeString))
                            DataGridView1.Rows.Add("English", Decrypt(fld2, strEncodeString))
                            DataGridView1.Rows.Add("Sc. Name", Decrypt(fld3, strEncodeString))
                            For i = 0 To DataGridView1.Rows.Count - 1
                                DataGridView1.Rows(i).Height = 35
                            Next
                        End If

                    End If


                    Dim pictureID As Integer = IIf(IsDBNull(rs("PictureID")), 0, rs("PictureID"))
                    If pictureID <> 0 Then
                        Dim cmd1 As New OleDbCommand("SELECT * FROM Pictures WHERE PicID=" & pictureID, objConn)
                        Dim dr1 As OleDbDataReader = cmd1.ExecuteReader
                        If dr1.HasRows Then
                            dr1.Read()
                            Dim arrayImage() As Byte = CType(dr1("Picture"), Byte())
                            Dim ms As New MemoryStream(arrayImage)
                            With Me.imgRetrieve
                                .Image = Image.FromStream(ms)
                                .SizeMode = PictureBoxSizeMode.StretchImage
                            End With
                        End If
                    End If
                End If
                rs.Close()
            End If
            Dim cmd As New OleDbCommand
            If rbtnAbbr.Checked = True Or rbtnDate.Checked = True Then
                cmd = New OleDbCommand("SELECT As_Meaning, Eng_Meaning FROM CateTable WHERE ID=" & xID, objConn)
                Dim dr As OleDbDataReader = cmd.ExecuteReader
                If dr.HasRows Then
                    dr.Read()
                    Dim ASM As String = IIf(IsDBNull(dr("As_Meaning")), "", dr("As_Meaning"))
                    Dim EM As String = IIf(IsDBNull(dr("Eng_Meaning")), "", dr("Eng_Meaning"))
                    If ASM <> "" Then
                        txtMeaning.Text = Decrypt(ASM, strEncodeString)
                    End If
                    If EM <> "" Then
                        txtMeaning.AppendText(Environment.NewLine & Decrypt(EM, strEncodeString))
                    End If
                    dr.Close()
                End If
            End If

            If rbtnLaw.Checked = True Then
                cmd = New OleDbCommand("SELECT As_Meaning, Eng_Meaning FROM CateTable WHERE ID=" & xID, objConn)
                Dim dr As OleDbDataReader = cmd.ExecuteReader
                If dr.HasRows Then
                    dr.Read()
                    Dim ASM As String = IIf(IsDBNull(dr("As_Meaning")), "", dr("As_Meaning"))
                    Dim EM As String = IIf(IsDBNull(dr("Eng_Meaning")), "", dr("Eng_Meaning"))
                    If ASM <> "" Then
                        txtMeaning.Text = ASM
                    End If
                    If EM <> "" Then
                        txtMeaning.AppendText(Environment.NewLine & EM)
                    End If
                    dr.Close()
                End If
            End If
            If rbtnCountry.Checked = True Then
                cmd = New OleDbCommand("SELECT * FROM Country WHERE ID=" & xID, objConn)
                Dim dr As OleDbDataReader = cmd.ExecuteReader
                If dr.HasRows Then
                    dr.Read()
                    Dim capital As String = IIf(IsDBNull(dr("Capital")), "", dr("Capital"))
                    Dim Curr As String = IIf(IsDBNull(dr("Currency")), "", dr("Currency"))
                    Dim Lang As String = IIf(IsDBNull(dr("Language")), "", dr("Language"))
                    If capital <> "" Then
                        txtMeaning.Text = "Capital: " & capital
                    End If
                    If Curr <> "" Then
                        txtMeaning.AppendText(Environment.NewLine & "Currency: " & Curr)
                    End If
                    If Lang <> "" Then
                        txtMeaning.AppendText(Environment.NewLine & "Language: " & Lang)
                    End If
                    dr.Close()
                End If
            End If

        Catch ex As Exception
            Exit Sub
        End Try

    End Sub
    Private Sub FirstRowSelect()
        lvWords.Refresh()
        'lvProbableWord.Refresh()
        Try
            If lvWords.Items.Count > 0 Then
                'lvProbableWord.SelectedIndices.Clear()
                'lvProbableWord.HideSelection = True
                'lvProbableWord.Refresh()
                lvWords.SelectedIndices.Clear()
                lvWords.Refresh()
                lvWords.HideSelection = False
                lvWords.Items(0).Selected = True
            Else
                If lvWords.Items.Count = 0 Then
                    'If lvProbableWord.Items.Count <> 0 Then
                    '    lvWords.SelectedIndices.Clear()
                    '    lvWords.HideSelection = True
                    '    lvWords.Refresh()
                    '    lvProbableWord.SelectedIndices.Clear()
                    '    lvProbableWord.Refresh()
                    '    lvProbableWord.HideSelection = False
                    '    lvProbableWord.Items(0).Selected = True
                    'End If
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

    Private Sub rbtnAbbr_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtnAbbr.CheckedChanged

        lvWords.Items.Clear()
        txtWord.Text = ""

        If rbtnAbbr.Checked = True Then
            rbtnHindi.Enabled = False
            rbtnAssamese.Checked = True
            txtMeaning.Visible = True
            txtMeaning.Text = ""
        ElseIf rbtnAbbr.Checked = False Then
            rbtnHindi.Enabled = True
            txtMeaning.Visible = False
        End If
        DataGridView1.Visible = False
        imgRetrieve.Visible = False

        lowerID = 1
        upperID = 705 - 1

        If Not loadListview(lowerID, upperID, SearchText, orderBy) Then
            Exit Sub
        End If
        
    End Sub

    Private Function loadSelectedPINCode(ByVal searchField As String) As Boolean
        Try
            lvWords.Items.Clear()
            Dim filtDT As New DataTable
            If dtPinCod.Rows.Count <= 0 Then
                MsgBox("No Data found.")
            Else
                Try
                    Dim s As String = txtWord.Text.Trim.Substring(0, 1)
                    If Val(s) = 0 Then 'search post office name
                        filtDT = dtPinCod.Select("Post_Office like '" & txtWord.Text.ToString & "%'").CopyToDataTable
                    ElseIf Val(s) > 1 Then 'search pin code
                        If txtWord.Text.Trim.Length = 6 Then
                            filtDT = dtPinCod.Select("PIN=" & Val(txtWord.Text.ToString.Substring(0, 6))).CopyToDataTable

                        End If

                    End If

                    'filtDT = dtPinCod.Select("names like '%" & txtWord.Text & "%'").CopyToDataTable
                    'filtDT = dtPinCod.Select("Post_Office like '" & txtWord.Text & "%'").CopyToDataTable
                    'DataGridView2.DataSource = dtPinCod.Select("PO like " & txtWord.Text & "%'")
                    DataGridView2.DataSource = filtDT
                    ' DataGridView2.AutoResizeColumns()
                    'If filtDT.Rows.Count > 0 Then
                    '    For Each row As DataRow In filtDT.Rows
                    '        Dim lst As ListViewItem
                    '        lst = lvWords.Items.Add(row(0))
                    '        For i As Integer = 1 To filtDT.Columns.Count - 3
                    '            lst.SubItems.Add(row(i))
                    '        Next
                    '    Next
                    'End If
                Catch ex As Exception
                    ' 'MsgBox("failed to copy to table. Trying Cast.." & vbCrLf & ex.Message & vbCrLf & ex.StackTrace)
                    'Try
                    '    filtDT = dtPinCod.Select("names like '%" & txtWord.Text & "%'")
                    '    Dim h As DataTable = dtPinCod.Copy
                    '    h.Clear()
                    '    For Each m In filtDT
                    '        h.Rows.Add(m)
                    '    Next
                    '    DataGridView1.DataSource = h
                    'Catch ex1 As InvalidCastException
                    '    MsgBox("Casting is impossible.." & vbCrLf & ex.Message & vbCrLf & ex.StackTrace)
                    'Catch ex1 As Exception
                    '    MsgBox("failed .." & vbCrLf & ex.Message & vbCrLf & ex.StackTrace)
                    'End Try
                End Try
            End If
            FirstRowSelect()
        Catch ex As Exception
            Return False
        End Try

        Return True
    End Function

    Private Function loadSelectedData(ByVal low As Integer, ByVal high As Integer, ByVal searchField As String, ByVal orderBy As String) As Boolean
        DataGridView1.Rows.Clear()
        Dim storeSearchText As String = searchField
        'Dim storedOrderBy As String = orderBy

        If rbtnSName.Checked = True Then
            searchField = "Sc_Search"
            'orderBy = "Sc_Search"
        ElseIf rbtnSName.Checked = False Then
            searchField = storeSearchText
            'orderBy = storedOrderBy
        End If

        Try
            lvWords.Items.Clear()
            cmd = New OleDbCommand("SELECT ID," & searchField & " AS SearchField FROM CateTable WHERE ID>=" & low & " AND ID<=" & high & " AND " & searchField & " LIKE '" & txtWord.Text.Trim & "%' ORDER BY " & orderBy, objConn)
            Dim dr As OleDbDataReader = cmd.ExecuteReader
            If dr.HasRows Then
                Dim xItem As ListViewItem
                Do While dr.Read

                    Dim myword As String = IIf(IsDBNull(dr("SearchField")), "", dr("SearchField"))
                    If myword <> "" Then
                        xItem = lvWords.Items.Add(dr("ID"), myword, "")
                    End If
                Loop
            End If
            FirstRowSelect()
        Catch ex As Exception
            Return False
        End Try

        Return True
    End Function

    Private Function LoadSelectedCountry(ByVal low As Integer, ByVal high As Integer, ByVal searchField As String, ByVal orderBy As String) As Boolean
        Try
            lvWords.Items.Clear()
            'cmd = New OleDbCommand("SELECT ID," & searchField & " AS SearchField FROM Country WHERE ID>=" & low & " AND ID<=" & high & " ORDER BY " & orderBy, objConn)
            cmd = New OleDbCommand("SELECT ID," & searchField & " AS SearchField FROM Country WHERE ID>=" & low & " AND ID<=" & high & " AND " & searchField & " LIKE '" & txtWord.Text.Trim & "%' ORDER BY " & orderBy, objConn)

            Dim dr As OleDbDataReader = cmd.ExecuteReader
            If dr.HasRows Then
                Dim xItem As ListViewItem
                Do While dr.Read

                    Dim myword As String = IIf(IsDBNull(dr("SearchField")), "", dr("SearchField"))
                    If myword <> "" Then
                        xItem = lvWords.Items.Add(dr("ID"), myword, "")
                    End If
                Loop

            End If
            FirstRowSelect()
        Catch ex As Exception
            Return False
        End Try
        Return True

    End Function


    Private Function LoadPINCODE() As Boolean
        Try
            lvWords.Items.Clear()
            'cmd = New OleDbCommand("SELECT ID," & searchField & " AS SearchField FROM Country WHERE ID>=" & low & " AND ID<=" & high & " ORDER BY " & orderBy, objConn)
            Dim dr As OleDbDataReader = cmd.ExecuteReader
            If dr.HasRows Then
                Dim xItem As ListViewItem
                Do While dr.Read

                    Dim myword As String = IIf(IsDBNull(dr("SearchField")), "", dr("SearchField"))
                    If myword <> "" Then
                        xItem = lvWords.Items.Add(dr("ID"), myword, "")
                    End If
                Loop

            End If
            FirstRowSelect()
        Catch ex As Exception
            Return False
        End Try
        Return True

    End Function
End Class