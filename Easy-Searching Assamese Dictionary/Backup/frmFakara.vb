
Imports System.Data.OleDb

Public Class frmFakara
    Dim sChar As Object
    Dim btn As DataGridViewButtonColumn
    Dim counter As Integer = 0

    
    'Dim s As String = ""

    Private Sub frmFakara_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        txtWord.Focus()
        getConn()
        loadConsonent(gvCons)
        loadVowel(gvVowel)
        LoaAllFakara()
        Me.Size = New System.Drawing.Size(900, 663)
    End Sub

    Private Function ShowFakara(ByVal myval As String, Optional ByVal track As Integer = 0) As Boolean
        txtSMean.Text = ""
        lvFakara.Items.Clear()
        If track = 0 Then
            Try
                If myval = "" Then
                    Exit Function
                End If
                Dim myStr As String = Nothing
                myStr = "SELECT ID, Fakara FROM FakaraJojana WHERE SearchChar='" & myval & "' ORDER BY ID ASC"
                Dim objCmd As New OleDbCommand(myStr, objConn)
                Dim rs As OleDbDataReader = objCmd.ExecuteReader
                If rs.HasRows Then
                    Do While rs.Read
                        Dim xItem As ListViewItem
                        Dim fakara As String = IIf(IsDBNull(rs("fakara")), "", rs("fakara"))
                        xItem = lvFakara.Items.Add(rs("ID"), fakara, "")
                    Loop
                End If
            Catch ex As Exception
                ShowFakara = False
                'MsgBox(ex.Message)
                'MsgBox("Error in loading the data.", MsgBoxStyle.Critical, "Error")
                Exit Function
            End Try
        End If
        ShowFakara = True
    End Function

    Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click
        If txtWord.Text.Trim.Length = 0 Then
            Exit Sub
        End If
        txtWord.Text = ""
        txtSMean.Text = ""
        lvFakara.Items.Clear()
        txtWord.Focus()
        LoaAllFakara()
    End Sub


    Private Sub gvCons_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gvCons.CellContentClick
        txtWord.Text = ""
        If gvCons.CurrentCell.Value <> "" Then
            Dim xText As String = gvCons.CurrentCell.Value.ToString.Trim
            If xText.Trim.Length > 0 Then
                txtWord.Text = xText
                ShowFakara(xText, 0)
            End If
        End If

    End Sub

    Private Sub gvVowel_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gvVowel.CellContentClick
        txtWord.Text = ""
        If gvVowel.CurrentCell.Value <> "" Then
            Dim xText As String = gvVowel.CurrentCell.Value.ToString.Trim
            If xText.Trim.Length > 0 Then
                txtWord.Text = xText
                ShowFakara(xText, 0)
            End If
        End If
        txtWord.Focus()
    End Sub

    Private Sub LoaAllFakara()
        Try
            lvFakara.Items.Clear()
            Dim myStr As String = Nothing
            myStr = "SELECT  ID, Fakara FROM FakaraJojana ORDER BY ID ASC"

            Dim objCmd As New OleDbCommand(myStr, objConn)
            Dim rs As OleDbDataReader = objCmd.ExecuteReader
            If rs.HasRows Then
                Do While rs.Read
                    Dim xItem As ListViewItem
                    Dim fakara As String = IIf(IsDBNull(rs("fakara")), "", rs("fakara"))
                    xItem = lvFakara.Items.Add(rs("ID"), fakara, "")
                Loop
            End If
        Catch ex As Exception
            'MsgBox(ex.Message)
            'MsgBox("Error in loading the data.", MsgBoxStyle.Critical, "Error")
            Exit Sub
        End Try
    End Sub

    Private Sub lvFakara_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvFakara.LostFocus
        btnClear.Focus()
    End Sub

    Private Sub lvFakara_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvFakara.SelectedIndexChanged
        Try
            Dim xID As String = ""
            txtSMean.Text = ""
            If lvFakara.Items.Count = 0 Then Exit Sub
            If lvFakara.SelectedItems.Count <> 1 Then Exit Sub
            xID = lvFakara.SelectedItems(0).Name
            If xID = "" Then Exit Sub
            Dim myStr As String = Nothing
            myStr = "SELECT * FROM FakaraJojana WHERE ID=" & xID & " ORDER BY ID"     ''" & Replace(lbFakara.SelectedItem.ToString, "'", "''") & "'" 'lvFakara.SelectedItems(0).Tag

            Dim objCmd As New OleDbCommand(myStr, objConn)
            Dim rs As OleDbDataReader = objCmd.ExecuteReader
            If rs.HasRows Then
                rs.Read()
                Dim Fakara As String = IIf(IsDBNull(rs("Fakara")), "", rs("Fakara")) & ":  "
                Dim Meaning As String = IIf(IsDBNull(rs("FMeaning")), "", rs("FMeaning"))
                Dim newMeaning As String = ""
                
                If Meaning <> "" Then
                    newMeaning = Decrypt(Meaning, strEncodeString)
                End If

                txtSMean.AppendText(Fakara & " " & Environment.NewLine)

                txtSMean.SelectionStart = 0
                txtSMean.SelectionLength = Fakara.Length
                txtSMean.SelectionColor = Color.Chocolate
                txtSMean.SelectionBackColor = Color.LightGreen

                txtSMean.AppendText(newMeaning & " " & Environment.NewLine)
            End If
            rs.Close()
        Catch ex As Exception
            Exit Sub
        End Try
    End Sub

    

    Private Sub txtFakara_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtWord.LostFocus
        lvFakara.Focus()
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

  

    'Private Sub SetColor(ByVal Fakara As String)
    '    Dim loc As Int16
    '    If txtSMean.Text.Contains(Fakara) Then
    '        loc = txtSMean.Find(Fakara)
    '        Dim ln As Integer = Fakara.Length
    '        txtSMean.Select(loc, ln)
    '        txtSMean.SelectionColor = Color.Red
    '        txtSMean.SelectionBackColor = Color.Aqua
    '    End If

    'End Sub


    'Private Sub txtSMean_VScroll(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSMean.VScroll
    '    'Cursor = Cursors.Hand

    'End Sub
    'Private Sub txtSMean_HScroll(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSMean.HScroll
    '    Cursor = Cursors.Hand
    'End Sub

    'Private Sub txtSMean_MouseWheel(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles txtSMean.MouseWheel
    '    If Counter = 0 Then
    '        If e.Delta + 120 Then
    '            SendKeys.Send("{UP}")
    '        ElseIf e.Delta - 120 Then
    '            SendKeys.Send("{DOWN}")
    '        End If
    '    ElseIf Counter = 1 Then
    '        If e.Delta + 120 Then
    '            SendKeys.Send("{PGUP}")
    '        ElseIf e.Delta - 120 Then
    '            SendKeys.Send("{PGDN}")
    '        End If
    '    End If
    'End Sub

   
    Private Sub btnEncryptData_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEncryptData.Click
        Dim lowerID As Integer = 276
        Dim upperID As Integer = 742
        Try
            Dim cmd As New OleDbCommand("SELECT ID, FMeaning_old FROM FakaraJojana WHERE ID>=" & lowerID & " AND ID<=" & upperID & " ORDER BY ID", objConn)
            Dim rs1 As OleDbDataReader = cmd.ExecuteReader
            If rs1.HasRows Then
                Do While rs1.Read
                    Dim id As Integer = rs1("ID")
                    Dim FMeaning As String = IIf(IsDBNull(rs1("FMeaning_old")), "", rs1("FMeaning_old"))
                    Dim newFmeaning As String = ""
                    If FMeaning <> "" Then
                        newFmeaning = Encrypt(FMeaning, strEncodeString)
                    End If


                    Dim cmd1 As New OleDbCommand("UPDATE FakaraJojana SET  FMeaning='" & _
                                                 newFmeaning & "' WHERE ID=" & id, objConn)
                    cmd1.ExecuteNonQuery()
                Loop
                rs1.Close()

            End If
        Catch ex As Exception
            'MsgBox(ex.Message)
            'MsgBox("Error in loading the data.", MsgBoxStyle.Critical, "Error")
            Exit Sub
        End Try
        MsgBox("OK")
    End Sub

    
End Class