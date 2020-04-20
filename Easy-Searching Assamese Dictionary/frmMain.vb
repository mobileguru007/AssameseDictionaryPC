Imports System.Windows.Forms

Public Class frmMain

    Private Sub ShowNewForm(ByVal sender As Object, ByVal e As EventArgs)
        ' Create a new instance of the child form.
        Dim ChildForm As New System.Windows.Forms.Form
        ' Make it a child of this MDI form before showing it.
        ChildForm.MdiParent = Me

        m_ChildFormNumber += 1
        ChildForm.Text = "Window " & m_ChildFormNumber

        ChildForm.Show()
    End Sub

    Private Sub OpenFile(ByVal sender As Object, ByVal e As EventArgs)
        Dim OpenFileDialog As New OpenFileDialog
        OpenFileDialog.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.MyDocuments
        OpenFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*"
        If (OpenFileDialog.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK) Then
            Dim FileName As String = OpenFileDialog.FileName
            ' TODO: Add code here to open the file.
        End If
    End Sub

    Private Sub SaveAsToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        Dim SaveFileDialog As New SaveFileDialog
        SaveFileDialog.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.MyDocuments
        SaveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*"

        If (SaveFileDialog.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK) Then
            Dim FileName As String = SaveFileDialog.FileName
            ' TODO: Add code here to save the current contents of the form to a file.
        End If
    End Sub


    Private Sub ExitToolsStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        Me.Close()
    End Sub

    Private Sub CutToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        ' Use My.Computer.Clipboard to insert the selected text or images into the clipboard
    End Sub

    Private Sub CopyToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        ' Use My.Computer.Clipboard to insert the selected text or images into the clipboard
    End Sub

    Private Sub PasteToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        'Use My.Computer.Clipboard.GetText() or My.Computer.Clipboard.GetData to retrieve information from the clipboard.
    End Sub

    Private Sub CascadeToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        Me.LayoutMdi(MdiLayout.Cascade)
    End Sub

    Private Sub TileVerticalToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        Me.LayoutMdi(MdiLayout.TileVertical)
    End Sub

    Private Sub TileHorizontalToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        Me.LayoutMdi(MdiLayout.TileHorizontal)
    End Sub

    Private Sub ArrangeIconsToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        Me.LayoutMdi(MdiLayout.ArrangeIcons)
    End Sub

    Private Sub CloseAllToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        ' Close all child forms of the parent.
        For Each ChildForm As Form In Me.MdiChildren
            ChildForm.Close()
        Next
    End Sub

    Private m_ChildFormNumber As Integer


    Private Sub frmMain_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsRegistered = False Then
            Me.Text = Me.Text & "(Demo Version)"
            ActvationToolStripMenuItem.Visible = True
            frmRegistration.ShowDialog()
        Else
            Me.Text = Me.Text & "(" & Registeredto & ")"
        End If
        getConn()
        'Me.Size = New System.Drawing.Size(950, 743)
    End Sub

    Private Sub ActivateToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If IsRegistered = True Then Exit Sub
        frmRegistration.ShowDialog()
    End Sub

   
    Private Sub WordSearchToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OpenWordSearch.Click
        frmWordSearch.Close()
        frmWordSearch.MdiParent = Me
        frmWordSearch.Show()


        'If WordSearchToolStripMenuItem.Checked Then
        '   frmWordSearch.Close()
        'Else
        '   frmWordSearch.MdiParent = Me
        '   frmWordSearch.Show()
        'End If
    End Sub

    
    Private Sub OpenFakara_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OpenFakara.Click
        frmFakara.Close()
        frmFakara.MdiParent = Me
        frmFakara.Show()
        'If OpenToolStripMenuItem1.Checked Then
        '   frmFakara.Close()
        'Else
        '   frmFakara.MdiParent = Me
        '   frmFakara.Show()
        'End If
    End Sub

    
    

    
   
    Private Sub OpenPicture_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OpenPicture.Click
        frmPicture.Close()
        frmPicture.MdiParent = Me
        frmPicture.Show()
        'If OpenToolStripMenuItem2.Checked Then
        '   frmPicture.Close()
        'Else
        '   frmPicture.MdiParent = Me
        '   frmPicture.Show()
        'End If
    End Sub

   
    Private Sub OpenToolStripMenuItem3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OpenToolStripMenuItem3.Click
        frmWrongRight.Close()
        frmWrongRight.MdiParent = Me
        frmWrongRight.Show()
    End Sub

   
    Private Sub NamingToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NamingToolStripMenuItem.Click
        xNaming.Close()
        xNaming.MdiParent = Me
        xNaming.Show()
        'NameWord.Close()
        'NameWord.MdiParent = Me
        'NameWord.Show()
    End Sub

    Private Sub GrammerToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GrammerToolStripMenuItem.Click
        frmGrammar.Close()
        frmGrammar.MdiParent = Me
        frmGrammar.Show()
    End Sub

    Private Sub AboutUsToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AboutUsToolStripMenuItem1.Click
        frmAboutUs.Close()
        frmAboutUs.MdiParent = Me
        frmAboutUs.Show()
    End Sub

    Private Sub EditorialToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EditorialToolStripMenuItem.Click
        frmEditorial.Close()
        frmEditorial.MdiParent = Me
        frmEditorial.Show()
    End Sub

    Private Sub ContactUs_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ContactUs.Click
        'frmContactUs.Close()
        'frmContactUs.MdiParent = Me
        'frmContactUs.Show()
    End Sub

    Private Sub PersonalToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PersonalToolStripMenuItem.Click
        'frmLanguage.Close()
        'frmLanguage.MdiParent = Me
        'frmLanguage.Show()
    End Sub

    Private Sub AcknowToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AcknowToolStripMenuItem.Click
        'frmThanks.Close()
        'frmThanks.MdiParent = Me
        'frmThanks.Show()
    End Sub

    Private Sub HelpToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HelpToolStripMenuItem.Click
        frmHelp.Close()
        frmHelp.MdiParent = Me
        frmHelp.Show()
    End Sub

    Private Sub SpellChecker_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        frmSpellcheck.Close()
        frmSpellcheck.MdiParent = Me
        frmSpellcheck.Show()
    End Sub

    Private Sub ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles extrawords.Click
        wordsearchextra.Close()
        wordsearchextra.Show()
        wordsearchextra.MdiParent = Me
    End Sub

    
End Class
