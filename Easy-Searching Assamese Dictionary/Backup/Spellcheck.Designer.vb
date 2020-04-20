<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSpellcheck
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.txtContent = New System.Windows.Forms.RichTextBox
        Me.lbSuggestedList = New System.Windows.Forms.ListBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.lblSuggest = New System.Windows.Forms.Label
        Me.txtSelectedWord = New System.Windows.Forms.TextBox
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
        Me.ttStart = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuItem6 = New System.Windows.Forms.ToolStripMenuItem
        Me.ttClearText = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuItem5 = New System.Windows.Forms.ToolStripMenuItem
        Me.ttIgnoreOnce = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuItem4 = New System.Windows.Forms.ToolStripMenuItem
        Me.ttIgnoreAll = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuItem3 = New System.Windows.Forms.ToolStripMenuItem
        Me.ttChange = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripMenuItem
        Me.ttChangeAll = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.ttClose = New System.Windows.Forms.ToolStripMenuItem
        Me.btnencrypt = New System.Windows.Forms.Button
        Me.btnClose = New System.Windows.Forms.Button
        Me.btnCopy = New System.Windows.Forms.Button
        Me.btnPaste = New System.Windows.Forms.Button
        Me.btnAdd = New System.Windows.Forms.Button
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtContent
        '
        Me.txtContent.Font = New System.Drawing.Font("Asomiya_Rohini", 20.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtContent.Location = New System.Drawing.Point(3, 43)
        Me.txtContent.MaxLength = 2000
        Me.txtContent.Name = "txtContent"
        Me.txtContent.Size = New System.Drawing.Size(725, 271)
        Me.txtContent.TabIndex = 0
        Me.txtContent.Text = ""
        '
        'lbSuggestedList
        '
        Me.lbSuggestedList.Font = New System.Drawing.Font("Asomiya_Rohini", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbSuggestedList.FormattingEnabled = True
        Me.lbSuggestedList.ItemHeight = 25
        Me.lbSuggestedList.Location = New System.Drawing.Point(3, 386)
        Me.lbSuggestedList.Name = "lbSuggestedList"
        Me.lbSuggestedList.Size = New System.Drawing.Size(725, 229)
        Me.lbSuggestedList.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.DimGray
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(3, 3)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(725, 39)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Put your text here"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblSuggest
        '
        Me.lblSuggest.BackColor = System.Drawing.Color.DimGray
        Me.lblSuggest.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSuggest.ForeColor = System.Drawing.Color.White
        Me.lblSuggest.Location = New System.Drawing.Point(3, 316)
        Me.lblSuggest.Name = "lblSuggest"
        Me.lblSuggest.Size = New System.Drawing.Size(725, 33)
        Me.lblSuggest.TabIndex = 5
        Me.lblSuggest.Text = "Suggestion"
        Me.lblSuggest.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtSelectedWord
        '
        Me.txtSelectedWord.BackColor = System.Drawing.Color.White
        Me.txtSelectedWord.Font = New System.Drawing.Font("Asomiya_Rohini", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSelectedWord.Location = New System.Drawing.Point(3, 352)
        Me.txtSelectedWord.Name = "txtSelectedWord"
        Me.txtSelectedWord.Size = New System.Drawing.Size(725, 32)
        Me.txtSelectedWord.TabIndex = 12
        '
        'MenuStrip1
        '
        Me.MenuStrip1.AutoSize = False
        Me.MenuStrip1.Dock = System.Windows.Forms.DockStyle.Right
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ttStart, Me.ToolStripMenuItem6, Me.ttClearText, Me.ToolStripMenuItem5, Me.ttIgnoreOnce, Me.ToolStripMenuItem4, Me.ttIgnoreAll, Me.ToolStripMenuItem3, Me.ttChange, Me.ToolStripMenuItem2, Me.ttChangeAll, Me.ToolStripMenuItem1, Me.ttClose})
        Me.MenuStrip1.Location = New System.Drawing.Point(730, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(154, 625)
        Me.MenuStrip1.TabIndex = 13
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'ttStart
        '
        Me.ttStart.AccessibleRole = System.Windows.Forms.AccessibleRole.RowHeader
        Me.ttStart.AutoSize = False
        Me.ttStart.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ttStart.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.ttStart.Name = "ttStart"
        Me.ttStart.ShortcutKeyDisplayString = ""
        Me.ttStart.ShortcutKeys = CType(((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Shift) _
                    Or System.Windows.Forms.Keys.Space), System.Windows.Forms.Keys)
        Me.ttStart.Size = New System.Drawing.Size(144, 45)
        Me.ttStart.Text = "Start(Ctrl+Shift+Space)"
        '
        'ToolStripMenuItem6
        '
        Me.ToolStripMenuItem6.AutoSize = False
        Me.ToolStripMenuItem6.Name = "ToolStripMenuItem6"
        Me.ToolStripMenuItem6.Size = New System.Drawing.Size(147, 15)
        '
        'ttClearText
        '
        Me.ttClearText.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ttClearText.AutoSize = False
        Me.ttClearText.BackColor = System.Drawing.Color.Blue
        Me.ttClearText.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.ttClearText.ForeColor = System.Drawing.Color.White
        Me.ttClearText.Name = "ttClearText"
        Me.ttClearText.ShortcutKeys = CType(((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Shift) _
                    Or System.Windows.Forms.Keys.D), System.Windows.Forms.Keys)
        Me.ttClearText.Size = New System.Drawing.Size(144, 45)
        Me.ttClearText.Text = "Clear(Ctrl+Shift+D)"
        '
        'ToolStripMenuItem5
        '
        Me.ToolStripMenuItem5.AutoSize = False
        Me.ToolStripMenuItem5.Name = "ToolStripMenuItem5"
        Me.ToolStripMenuItem5.Size = New System.Drawing.Size(147, 15)
        '
        'ttIgnoreOnce
        '
        Me.ttIgnoreOnce.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ttIgnoreOnce.AutoSize = False
        Me.ttIgnoreOnce.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ttIgnoreOnce.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.ttIgnoreOnce.Name = "ttIgnoreOnce"
        Me.ttIgnoreOnce.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.N), System.Windows.Forms.Keys)
        Me.ttIgnoreOnce.Size = New System.Drawing.Size(144, 45)
        Me.ttIgnoreOnce.Text = "Ignore >>(Ctrl+N)"
        '
        'ToolStripMenuItem4
        '
        Me.ToolStripMenuItem4.AutoSize = False
        Me.ToolStripMenuItem4.Name = "ToolStripMenuItem4"
        Me.ToolStripMenuItem4.Size = New System.Drawing.Size(147, 15)
        '
        'ttIgnoreAll
        '
        Me.ttIgnoreAll.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ttIgnoreAll.AutoSize = False
        Me.ttIgnoreAll.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ttIgnoreAll.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.ttIgnoreAll.Name = "ttIgnoreAll"
        Me.ttIgnoreAll.ShortcutKeys = CType(((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Shift) _
                    Or System.Windows.Forms.Keys.N), System.Windows.Forms.Keys)
        Me.ttIgnoreAll.Size = New System.Drawing.Size(144, 45)
        Me.ttIgnoreAll.Text = "Ignore All (Ctrl+Shift+N)"
        '
        'ToolStripMenuItem3
        '
        Me.ToolStripMenuItem3.AutoSize = False
        Me.ToolStripMenuItem3.Name = "ToolStripMenuItem3"
        Me.ToolStripMenuItem3.Size = New System.Drawing.Size(147, 15)
        '
        'ttChange
        '
        Me.ttChange.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ttChange.AutoSize = False
        Me.ttChange.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ttChange.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.ttChange.Name = "ttChange"
        Me.ttChange.ShortcutKeys = CType((System.Windows.Forms.Keys.Alt Or System.Windows.Forms.Keys.F), System.Windows.Forms.Keys)
        Me.ttChange.Size = New System.Drawing.Size(144, 45)
        Me.ttChange.Text = "Change >>(Alt+F)"
        '
        'ToolStripMenuItem2
        '
        Me.ToolStripMenuItem2.AutoSize = False
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        Me.ToolStripMenuItem2.Size = New System.Drawing.Size(147, 15)
        '
        'ttChangeAll
        '
        Me.ttChangeAll.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ttChangeAll.AutoSize = False
        Me.ttChangeAll.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ttChangeAll.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.ttChangeAll.Name = "ttChangeAll"
        Me.ttChangeAll.ShortcutKeys = CType(((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Shift) _
                    Or System.Windows.Forms.Keys.F), System.Windows.Forms.Keys)
        Me.ttChangeAll.Size = New System.Drawing.Size(144, 45)
        Me.ttChangeAll.Text = "Change All(Ctrl+Shift+F)"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.AutoSize = False
        Me.ToolStripMenuItem1.Enabled = False
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(147, 220)
        '
        'ttClose
        '
        Me.ttClose.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ttClose.AutoSize = False
        Me.ttClose.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ttClose.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold)
        Me.ttClose.Name = "ttClose"
        Me.ttClose.Size = New System.Drawing.Size(144, 45)
        Me.ttClose.Text = "Close "
        '
        'btnencrypt
        '
        Me.btnencrypt.Enabled = False
        Me.btnencrypt.Location = New System.Drawing.Point(24, 14)
        Me.btnencrypt.Name = "btnencrypt"
        Me.btnencrypt.Size = New System.Drawing.Size(75, 23)
        Me.btnencrypt.TabIndex = 14
        Me.btnencrypt.Text = "EncryptData"
        Me.btnencrypt.UseVisualStyleBackColor = True
        Me.btnencrypt.Visible = False
        '
        'btnClose
        '
        Me.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnClose.Location = New System.Drawing.Point(641, 323)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(75, 23)
        Me.btnClose.TabIndex = 15
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'btnCopy
        '
        Me.btnCopy.Location = New System.Drawing.Point(653, 8)
        Me.btnCopy.Name = "btnCopy"
        Me.btnCopy.Size = New System.Drawing.Size(75, 30)
        Me.btnCopy.TabIndex = 16
        Me.btnCopy.Text = "Copy"
        Me.btnCopy.UseVisualStyleBackColor = True
        '
        'btnPaste
        '
        Me.btnPaste.Location = New System.Drawing.Point(572, 8)
        Me.btnPaste.Name = "btnPaste"
        Me.btnPaste.Size = New System.Drawing.Size(75, 30)
        Me.btnPaste.TabIndex = 17
        Me.btnPaste.Text = "Paste"
        Me.btnPaste.UseVisualStyleBackColor = True
        '
        'btnAdd
        '
        Me.btnAdd.Location = New System.Drawing.Point(463, 7)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(103, 30)
        Me.btnAdd.TabIndex = 18
        Me.btnAdd.Text = "&Add To Dictionary"
        Me.btnAdd.UseVisualStyleBackColor = True
        Me.btnAdd.Visible = False
        '
        'frmSpellcheck
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.CancelButton = Me.btnClose
        Me.ClientSize = New System.Drawing.Size(884, 625)
        Me.Controls.Add(Me.btnAdd)
        Me.Controls.Add(Me.btnPaste)
        Me.Controls.Add(Me.btnCopy)
        Me.Controls.Add(Me.btnencrypt)
        Me.Controls.Add(Me.txtSelectedWord)
        Me.Controls.Add(Me.lblSuggest)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.lbSuggestedList)
        Me.Controls.Add(Me.txtContent)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Controls.Add(Me.btnClose)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.MaximizeBox = False
        Me.Name = "frmSpellcheck"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Simple Spellchecking"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtContent As System.Windows.Forms.RichTextBox
    Friend WithEvents lbSuggestedList As System.Windows.Forms.ListBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lblSuggest As System.Windows.Forms.Label
    Friend WithEvents txtSelectedWord As System.Windows.Forms.TextBox
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents ttStart As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ttClearText As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ttIgnoreOnce As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ttIgnoreAll As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ttChange As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ttChangeAll As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ttClose As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem6 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem5 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem4 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem3 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem2 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnencrypt As System.Windows.Forms.Button
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents btnCopy As System.Windows.Forms.Button
    Friend WithEvents btnPaste As System.Windows.Forms.Button
    Friend WithEvents btnAdd As System.Windows.Forms.Button
End Class
