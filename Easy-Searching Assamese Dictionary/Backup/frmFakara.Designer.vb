<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmFakara
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmFakara))
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.btnEncryptData = New System.Windows.Forms.Button
        Me.txtSMean = New System.Windows.Forms.RichTextBox
        Me.btnClose = New System.Windows.Forms.Button
        Me.Label6 = New System.Windows.Forms.Label
        Me.lvFakara = New System.Windows.Forms.ListView
        Me.ColumnHeader6 = New System.Windows.Forms.ColumnHeader
        Me.btnClear = New System.Windows.Forms.Button
        Me.Label4 = New System.Windows.Forms.Label
        Me.txtWord = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.PictureBox3 = New System.Windows.Forms.PictureBox
        Me.PictureBox2 = New System.Windows.Forms.PictureBox
        Me.GroupBox5 = New System.Windows.Forms.GroupBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.gvVowel = New System.Windows.Forms.DataGridView
        Me.Column18 = New System.Windows.Forms.DataGridViewButtonColumn
        Me.GroupBox12 = New System.Windows.Forms.GroupBox
        Me.gvCons = New System.Windows.Forms.DataGridView
        Me.Column13 = New System.Windows.Forms.DataGridViewButtonColumn
        Me.PictureBox6 = New System.Windows.Forms.PictureBox
        Me.GroupBox4.SuspendLayout()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox5.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.gvVowel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox12.SuspendLayout()
        CType(Me.gvCons, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox6, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox4
        '
        Me.GroupBox4.BackColor = System.Drawing.Color.LightCoral
        Me.GroupBox4.BackgroundImage = Global.ABD.My.Resources.Resources.BackDown
        Me.GroupBox4.Controls.Add(Me.btnEncryptData)
        Me.GroupBox4.Controls.Add(Me.txtSMean)
        Me.GroupBox4.Controls.Add(Me.btnClose)
        Me.GroupBox4.Controls.Add(Me.Label6)
        Me.GroupBox4.Controls.Add(Me.lvFakara)
        Me.GroupBox4.Controls.Add(Me.btnClear)
        Me.GroupBox4.Controls.Add(Me.Label4)
        Me.GroupBox4.Controls.Add(Me.txtWord)
        Me.GroupBox4.Controls.Add(Me.Label3)
        Me.GroupBox4.Controls.Add(Me.PictureBox3)
        Me.GroupBox4.Controls.Add(Me.PictureBox2)
        Me.GroupBox4.Location = New System.Drawing.Point(176, -4)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(714, 645)
        Me.GroupBox4.TabIndex = 64
        Me.GroupBox4.TabStop = False
        '
        'btnEncryptData
        '
        Me.btnEncryptData.Location = New System.Drawing.Point(583, 33)
        Me.btnEncryptData.Name = "btnEncryptData"
        Me.btnEncryptData.Size = New System.Drawing.Size(94, 24)
        Me.btnEncryptData.TabIndex = 86
        Me.btnEncryptData.Text = "Encrypt data"
        Me.btnEncryptData.UseVisualStyleBackColor = True
        Me.btnEncryptData.Visible = False
        '
        'txtSMean
        '
        Me.txtSMean.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtSMean.Font = New System.Drawing.Font("Asomiya_Rohini", 17.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSMean.Location = New System.Drawing.Point(4, 334)
        Me.txtSMean.Name = "txtSMean"
        Me.txtSMean.Size = New System.Drawing.Size(705, 267)
        Me.txtSMean.TabIndex = 85
        Me.txtSMean.Text = ""
        '
        'btnClose
        '
        Me.btnClose.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnClose.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClose.ForeColor = System.Drawing.Color.Blue
        Me.btnClose.Location = New System.Drawing.Point(628, 605)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(80, 28)
        Me.btnClose.TabIndex = 79
        Me.btnClose.Text = "&Close"
        Me.btnClose.UseVisualStyleBackColor = False
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Label6.Font = New System.Drawing.Font("Asomiya_Rohini", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(6, 306)
        Me.Label6.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(704, 25)
        Me.Label6.TabIndex = 78
        Me.Label6.Text = "সৰল ভাঙনি"
        '
        'lvFakara
        '
        Me.lvFakara.BackColor = System.Drawing.SystemColors.Window
        Me.lvFakara.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader6})
        Me.lvFakara.Font = New System.Drawing.Font("Asomiya_Rohini", 17.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lvFakara.ForeColor = System.Drawing.Color.Black
        Me.lvFakara.FullRowSelect = True
        Me.lvFakara.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None
        Me.lvFakara.Location = New System.Drawing.Point(5, 92)
        Me.lvFakara.MultiSelect = False
        Me.lvFakara.Name = "lvFakara"
        Me.lvFakara.Size = New System.Drawing.Size(707, 211)
        Me.lvFakara.TabIndex = 69
        Me.lvFakara.UseCompatibleStateImageBehavior = False
        Me.lvFakara.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader6
        '
        Me.ColumnHeader6.Text = ""
        Me.ColumnHeader6.Width = 665
        '
        'btnClear
        '
        Me.btnClear.BackColor = System.Drawing.Color.Silver
        Me.btnClear.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClear.ForeColor = System.Drawing.Color.Black
        Me.btnClear.Location = New System.Drawing.Point(315, 35)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(69, 26)
        Me.btnClear.TabIndex = 68
        Me.btnClear.Text = "Clea&r"
        Me.btnClear.UseVisualStyleBackColor = False
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Label4.Font = New System.Drawing.Font("Asomiya_Rohini", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(6, 69)
        Me.Label4.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(705, 25)
        Me.Label4.TabIndex = 66
        Me.Label4.Text = "নির্দিষ্ট ফকৰাটোত ক্লিক কৰক"
        '
        'txtWord
        '
        Me.txtWord.Font = New System.Drawing.Font("Asomiya_Rohini", 19.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtWord.Location = New System.Drawing.Point(6, 33)
        Me.txtWord.MaxLength = 2
        Me.txtWord.Name = "txtWord"
        Me.txtWord.Size = New System.Drawing.Size(303, 41)
        Me.txtWord.TabIndex = 65
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Label3.Font = New System.Drawing.Font("Asomiya_Rohini", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(6, 6)
        Me.Label3.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(705, 65)
        Me.Label3.TabIndex = 64
        Me.Label3.Text = "ফকৰাটোৰ প্ৰথমৰ আখৰটো টাইপ কৰক"
        '
        'PictureBox3
        '
        Me.PictureBox3.Image = Global.ABD.My.Resources.Resources.Fakara_label_5
        Me.PictureBox3.Location = New System.Drawing.Point(0, 5)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(711, 89)
        Me.PictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox3.TabIndex = 82
        Me.PictureBox3.TabStop = False
        '
        'PictureBox2
        '
        Me.PictureBox2.Image = Global.ABD.My.Resources.Resources.F_label1
        Me.PictureBox2.Location = New System.Drawing.Point(340, 5)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(371, 87)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox2.TabIndex = 81
        Me.PictureBox2.TabStop = False
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.Label1)
        Me.GroupBox5.Controls.Add(Me.GroupBox2)
        Me.GroupBox5.Controls.Add(Me.GroupBox12)
        Me.GroupBox5.Location = New System.Drawing.Point(5, -3)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(173, 644)
        Me.GroupBox5.TabIndex = 75
        Me.GroupBox5.TabStop = False
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Label1.Font = New System.Drawing.Font("Asomiya_Rohini", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(0, 4)
        Me.Label1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(173, 25)
        Me.Label1.TabIndex = 67
        Me.Label1.Text = "ব্যঞ্জনবর্ণ"
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.IndianRed
        Me.GroupBox2.BackgroundImage = Global.ABD.My.Resources.Resources.BackDown
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.gvVowel)
        Me.GroupBox2.Font = New System.Drawing.Font("Asomiya_Rohini", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.ForeColor = System.Drawing.Color.Black
        Me.GroupBox2.Location = New System.Drawing.Point(-1, 390)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(170, 250)
        Me.GroupBox2.TabIndex = 70
        Me.GroupBox2.TabStop = False
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Label2.Font = New System.Drawing.Font("Asomiya_Rohini", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(1, 0)
        Me.Label2.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(170, 25)
        Me.Label2.TabIndex = 75
        Me.Label2.Text = "স্বৰবর্ণ"
        '
        'gvVowel
        '
        Me.gvVowel.AllowUserToAddRows = False
        Me.gvVowel.AllowUserToDeleteRows = False
        Me.gvVowel.AllowUserToResizeColumns = False
        Me.gvVowel.AllowUserToResizeRows = False
        Me.gvVowel.BackgroundColor = System.Drawing.Color.WhiteSmoke
        Me.gvVowel.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gvVowel.ColumnHeadersVisible = False
        Me.gvVowel.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column18})
        Me.gvVowel.GridColor = System.Drawing.Color.Silver
        Me.gvVowel.Location = New System.Drawing.Point(6, 59)
        Me.gvVowel.Name = "gvVowel"
        Me.gvVowel.ReadOnly = True
        Me.gvVowel.RowHeadersVisible = False
        Me.gvVowel.ShowCellToolTips = False
        Me.gvVowel.Size = New System.Drawing.Size(157, 122)
        Me.gvVowel.TabIndex = 0
        '
        'Column18
        '
        Me.Column18.HeaderText = "Column18"
        Me.Column18.Name = "Column18"
        Me.Column18.ReadOnly = True
        Me.Column18.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Column18.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.Column18.Width = 35
        '
        'GroupBox12
        '
        Me.GroupBox12.Controls.Add(Me.gvCons)
        Me.GroupBox12.Controls.Add(Me.PictureBox6)
        Me.GroupBox12.Font = New System.Drawing.Font("Asomiya_Rohini", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox12.ForeColor = System.Drawing.Color.Black
        Me.GroupBox12.Location = New System.Drawing.Point(0, 20)
        Me.GroupBox12.Name = "GroupBox12"
        Me.GroupBox12.Size = New System.Drawing.Size(170, 363)
        Me.GroupBox12.TabIndex = 70
        Me.GroupBox12.TabStop = False
        '
        'gvCons
        '
        Me.gvCons.AllowUserToAddRows = False
        Me.gvCons.AllowUserToDeleteRows = False
        Me.gvCons.AllowUserToResizeColumns = False
        Me.gvCons.AllowUserToResizeRows = False
        Me.gvCons.BackgroundColor = System.Drawing.Color.WhiteSmoke
        Me.gvCons.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gvCons.ColumnHeadersVisible = False
        Me.gvCons.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column13})
        Me.gvCons.GridColor = System.Drawing.Color.Silver
        Me.gvCons.Location = New System.Drawing.Point(6, 38)
        Me.gvCons.Name = "gvCons"
        Me.gvCons.ReadOnly = True
        Me.gvCons.RowHeadersVisible = False
        Me.gvCons.ShowCellToolTips = False
        Me.gvCons.Size = New System.Drawing.Size(158, 273)
        Me.gvCons.TabIndex = 0
        '
        'Column13
        '
        Me.Column13.HeaderText = "Column13"
        Me.Column13.Name = "Column13"
        Me.Column13.ReadOnly = True
        Me.Column13.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Column13.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.Column13.Width = 35
        '
        'PictureBox6
        '
        Me.PictureBox6.BackColor = System.Drawing.Color.IndianRed
        Me.PictureBox6.BackgroundImage = Global.ABD.My.Resources.Resources.BackDown
        Me.PictureBox6.Location = New System.Drawing.Point(-1, 13)
        Me.PictureBox6.Name = "PictureBox6"
        Me.PictureBox6.Size = New System.Drawing.Size(173, 350)
        Me.PictureBox6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox6.TabIndex = 1
        Me.PictureBox6.TabStop = False
        '
        'frmFakara
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.SandyBrown
        Me.CancelButton = Me.btnClose
        Me.ClientSize = New System.Drawing.Size(891, 643)
        Me.Controls.Add(Me.GroupBox5)
        Me.Controls.Add(Me.GroupBox4)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ForeColor = System.Drawing.Color.Black
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "frmFakara"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ফকৰা-যোজনা"
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        CType(Me.gvVowel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox12.ResumeLayout(False)
        CType(Me.gvCons, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox6, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtWord As System.Windows.Forms.TextBox
    Friend WithEvents btnClear As System.Windows.Forms.Button
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents gvVowel As System.Windows.Forms.DataGridView
    Friend WithEvents Column18 As System.Windows.Forms.DataGridViewButtonColumn
    Friend WithEvents GroupBox12 As System.Windows.Forms.GroupBox
    Friend WithEvents gvCons As System.Windows.Forms.DataGridView
    Friend WithEvents Column13 As System.Windows.Forms.DataGridViewButtonColumn
    Friend WithEvents lvFakara As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader6 As System.Windows.Forms.ColumnHeader
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents PictureBox6 As System.Windows.Forms.PictureBox
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents PictureBox3 As System.Windows.Forms.PictureBox
    Friend WithEvents txtSMean As System.Windows.Forms.RichTextBox
    Friend WithEvents btnEncryptData As System.Windows.Forms.Button
End Class
