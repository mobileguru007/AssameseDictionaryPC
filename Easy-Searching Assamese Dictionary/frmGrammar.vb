Imports System.Data.OleDb

Public Class frmGrammar

    Private Sub frmGrammar_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        getConn()
        Me.Size = New System.Drawing.Size(900, 663)
        LoadAllNames()

        'Dim path As String = "grammar1.rtf"
        'rtxtbox.LoadFile(path, RichTextBoxStreamType.RichText)
        'Me.Size = New System.Drawing.Size(900, 663)
    End Sub

    Private Function LoadAllNames() As Boolean
        Try
            lvNames.Items.Clear()
            Dim myStr As String = Nothing
            'myStr = "SELECT ID, NameWord, AssMeaning FROM NameWord ORDER BY ID ASC"
            myStr = "SELECT * FROM Grammar ORDER BY ID"

            Dim objCmd As New OleDbCommand(myStr, objConn)
            Dim rs As OleDbDataReader = objCmd.ExecuteReader
            If rs.HasRows Then
                Do While rs.Read
                    Dim xItem As ListViewItem
                    xItem = lvNames.Items.Add(rs("ID"), IIf(IsDBNull(rs("Head")), "", rs("Head")), "")
                Loop
            End If
        Catch ex As Exception
            'MsgBox(ex.Message)
            MsgBox("Error in loading the data.", MsgBoxStyle.Information, "Error")
            Exit Function
        End Try
    End Function

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
    End Function

    Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        LoadAllNames()
    End Sub

    Private Sub lvNames_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvNames.SelectedIndexChanged
        'Dim path As String = "grammar1.rtf"
        'rtxtbox.LoadFile(path, RichTextBoxStreamType.RichText)
        'Me.Size = New System.Drawing.Size(900, 663)

        Try
            Dim xID As String = ""

            If lvNames.Items.Count = 0 Then Exit Sub
            If lvNames.SelectedItems.Count <> 1 Then Exit Sub
            xID = lvNames.SelectedItems(0).Name
            If xID = "" Then Exit Sub
            Dim myStr As String = Nothing
            myStr = "SELECT * FROM Grammar WHERE ID=" & xID & " ORDER BY ID"     ''" & Replace(lbFakara.SelectedItem.ToString, "'", "''") & "'" 'lvFakara.SelectedItems(0).Tag

            Dim objCmd As New OleDbCommand(myStr, objConn)
            Dim rs As OleDbDataReader = objCmd.ExecuteReader
            If rs.HasRows Then
                rs.Read()
                Dim path As String = IIf(IsDBNull(rs("filename")), "", rs("filename"))
                If path = "" Then
                    RichTextBox1.Clear()
                    Exit Sub
                End If
                RichTextBox1.LoadFile(path, RichTextBoxStreamType.RichText)
                Me.Size = New System.Drawing.Size(900, 663)
                RichTextBox1.SelectionFont = New Font(RichTextBox1.Font, FontStyle.Bold)
            End If
            rs.Close()
        Catch ex As Exception
            MsgBox("Error in loading the page.", MsgBoxStyle.Critical, "Error")
            Exit Sub
        End Try
       




        'Try
        '    lv1.Items.Clear()
        '    Dim myStr1 As String = Nothing
        '    'myStr = "SELECT ID, NameWord, AssMeaning FROM NameWord ORDER BY ID ASC"
        '    myStr1 = "SELECT grammarSub.* FROM grammarSub LEFT OUTER JOIN grammar ON grammar.id=grammarsub.id WHERE grammarsub.ID=" & xID & " ORDER BY grammarsub.ID"

        '    Dim objCmd1 As New OleDbCommand(myStr1, objConn)
        '    Dim rs1 As OleDbDataReader = objCmd1.ExecuteReader
        '    If rs1.HasRows Then
        '        Do While rs1.Read
        '            Dim xItem As ListViewItem
        '            xItem = lv1.Items.Add(rs1("pk"), IIf(IsDBNull(rs1("bb")), "", rs1("bb")), "")
        '        Loop
        '    End If
        'Catch ex As Exception
        '    MsgBox(ex.Message)
        'End Try

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub


    'Private Sub lv1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    If lv1.SelectedItems.Count <> 1 Then Exit Sub
    '    'MsgBox(lv1.SelectedItems(0).Name)
    '    ' MsgBox(lv1.SelectedItems(0).Text)
    '    'If FindMyText(lv1.SelectedItems(0).Text) Then
    '    '    MsgBox("true")
    '    'End If


    '    Dim searchstring As String = lv1.SelectedItems(0).Text
    '    ' The word you're looking for
    '    Dim count As New List(Of Integer)()
    '    For i As Integer = 0 To RichTextBox1.Text.Length - 1
    '        If RichTextBox1.Text.IndexOf(searchstring, i) <> -1 Then
    '            'If the word is found
    '            'Add the index to the list
    '            count.Add(RichTextBox1.Text.IndexOf(searchstring, i))
    '        End If
    '    Next
    '    Try
    '        For i As Integer = 0 To count.Count - 1

    '            RichTextBox1.[Select](count(i), searchstring.Length)
    '            RichTextBox1.SelectionFont = New Font(RichTextBox1.Font, FontStyle.Bold)
    '            count.RemoveAt(i)
    '        Next
    '    Catch
    '    End Try
    '    RichTextBox1.[Select](RichTextBox1.Text.Length, 0)
    '    RichTextBox1.SelectionFont = New Font(RichTextBox1.Font, FontStyle.Underline)
    '    RichTextBox1.SelectionColor = Color.Blue

    'End Sub

    Public Function FindMyText(ByVal text As String) As Boolean
        ' Initialize the return value to false by default. 
        Dim returnValue As Boolean = False

        ' Ensure a search string has been specified. 
        If text.Length > 0 Then
            ' Obtain the location of the search string in richTextBox1. 
            Dim indexToText As Integer = RichTextBox1.Find(text)
            ' Determine whether the text was found in richTextBox1. 
            If indexToText >= 0 Then
                returnValue = True
            End If
        End If

        Return returnValue
    End Function

    '    Private Sub Button1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
    '        'private void FontColorToolStripMenuItem_Click(object sender, System.EventArgs e)
    '{
    '        Try
    '    {
    '        ColorDialog1.Color = rtbDoc.ForeColor;
    '        if (ColorDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
    '        {
    '            rtbDoc.SelectionColor = ColorDialog1.Color;
    '        }
    '    }
    '    catch (Exception ex)
    '    {
    '        MessageBox.Show(ex.Message.ToString(), "Error");
    '    }
    '}
    '    End Sub
    '    private void btnFindNext_Click(object sender, System.EventArgs e)
    '{
    '    try
    '    {
    '        int StartPosition = mMain.rtbDoc.SelectionStart + 2;

    '        StringComparison SearchType;

    '        if (chkMatchCase.Checked == true)
    '        {
    '            SearchType = StringComparison.Ordinal;
    '        }
    '        else
    '        {
    '            SearchType = StringComparison.OrdinalIgnoreCase;
    '        }

    '        StartPosition = mMain.rtbDoc.Text.IndexOf(txtSearchTerm.Text, 
    '            StartPosition, SearchType);

    '        if (StartPosition == 0 || StartPosition < 0)
    '        {
    '            MessageBox.Show("String: " + 
    '                txtSearchTerm.Text.ToString() + " not found", 
    '                "No Matches", MessageBoxButtons.OK, 
    '                MessageBoxIcon.Asterisk);
    '            return;
    '        }

    '        mMain.rtbDoc.Select(StartPosition, 
    '            txtSearchTerm.Text.Length);
    '        mMain.rtbDoc.ScrollToCaret();
    '        mMain.Focus();
    '    }
    '    catch (Exception ex)
    '    {
    '    '        MessageBox.Show(ex.Message.ToString(), "Error");
    '    }
    '}
End Class