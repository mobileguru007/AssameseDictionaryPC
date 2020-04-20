<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPicture
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPicture))
        Me.GroupBox8 = New System.Windows.Forms.GroupBox
        Me.lblPicName = New System.Windows.Forms.Label
        Me.btnFullImage = New System.Windows.Forms.Button
        Me.txtPicMean = New System.Windows.Forms.TextBox
        Me.btnSavePicture = New System.Windows.Forms.Button
        Me.btnClose = New System.Windows.Forms.Button
        Me.imgRetrieve = New System.Windows.Forms.PictureBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtWord = New System.Windows.Forms.TextBox
        Me.GroupBox6 = New System.Windows.Forms.GroupBox
        Me.btnClear = New System.Windows.Forms.Button
        Me.Label4 = New System.Windows.Forms.Label
        Me.GroupBox7 = New System.Windows.Forms.GroupBox
        Me.lvPicName = New System.Windows.Forms.ListBox
        Me.savePicture = New System.Windows.Forms.SaveFileDialog
        Me.GroupBox12 = New System.Windows.Forms.GroupBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.gvCons = New System.Windows.Forms.DataGridView
        Me.Column13 = New System.Windows.Forms.DataGridViewButtonColumn
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.gvVowel = New System.Windows.Forms.DataGridView
        Me.Column18 = New System.Windows.Forms.DataGridViewButtonColumn
        Me.PictureBox5 = New System.Windows.Forms.PictureBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.GroupBox5 = New System.Windows.Forms.GroupBox
        Me.GroupBox8.SuspendLayout()
        CType(Me.imgRetrieve, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox6.SuspendLayout()
        Me.GroupBox7.SuspendLayout()
        Me.GroupBox12.SuspendLayout()
        CType(Me.gvCons, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        CType(Me.gvVowel, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox5.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox8
        '
        Me.GroupBox8.BackgroundImage = Global.ABD.My.Resources.Resources.BackDown
        Me.GroupBox8.Controls.Add(Me.lblPicName)
        Me.GroupBox8.Controls.Add(Me.btnFullImage)
        Me.GroupBox8.Controls.Add(Me.txtPicMean)
        Me.GroupBox8.Controls.Add(Me.btnSavePicture)
        Me.GroupBox8.Controls.Add(Me.btnClose)
        Me.GroupBox8.Controls.Add(Me.imgRetrieve)
        Me.GroupBox8.Location = New System.Drawing.Point(366, 62)
        Me.GroupBox8.Name = "GroupBox8"
        Me.GroupBox8.Size = New System.Drawing.Size(528, 578)
        Me.GroupBox8.TabIndex = 64
        Me.GroupBox8.TabStop = False
        '
        'lblPicName
        '
        Me.lblPicName.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.lblPicName.Font = New System.Drawing.Font("Asomiya_Rohini", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPicName.ForeColor = System.Drawing.Color.Maroon
        Me.lblPicName.Location = New System.Drawing.Point(5, 11)
        Me.lblPicName.Name = "lblPicName"
        Me.lblPicName.Size = New System.Drawing.Size(518, 30)
        Me.lblPicName.TabIndex = 58
        '
        'btnFullImage
        '
        Me.btnFullImage.BackColor = System.Drawing.Color.Linen
        Me.btnFullImage.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnFullImage.ForeColor = System.Drawing.Color.Black
        Me.btnFullImage.Location = New System.Drawing.Point(120, 543)
        Me.btnFullImage.Name = "btnFullImage"
        Me.btnFullImage.Size = New System.Drawing.Size(113, 30)
        Me.btnFullImage.TabIndex = 56
        Me.btnFullImage.Text = "&View Full Screen"
        Me.btnFullImage.UseVisualStyleBackColor = False
        '
        'txtPicMean
        '
        Me.txtPicMean.BackColor = System.Drawing.Color.White
        Me.txtPicMean.Font = New System.Drawing.Font("Asomiya_Rohini", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPicMean.ForeColor = System.Drawing.Color.Black
        Me.txtPicMean.Location = New System.Drawing.Point(5, 407)
        Me.txtPicMean.MaxLength = 50
        Me.txtPicMean.Multiline = True
        Me.txtPicMean.Name = "txtPicMean"
        Me.txtPicMean.ReadOnly = True
        Me.txtPicMean.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtPicMean.Size = New System.Drawing.Size(518, 134)
        Me.txtPicMean.TabIndex = 55
        '
        'btnSavePicture
        '
        Me.btnSavePicture.BackColor = System.Drawing.Color.Linen
        Me.btnSavePicture.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSavePicture.ForeColor = System.Drawing.Color.Black
        Me.btnSavePicture.Location = New System.Drawing.Point(3, 543)
        Me.btnSavePicture.Name = "btnSavePicture"
        Me.btnSavePicture.Size = New System.Drawing.Size(113, 30)
        Me.btnSavePicture.TabIndex = 5
        Me.btnSavePicture.Text = "&Save Picture"
        Me.btnSavePicture.UseVisualStyleBackColor = False
        '
        'btnClose
        '
        Me.btnClose.BackColor = System.Drawing.Color.Linen
        Me.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnClose.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClose.ForeColor = System.Drawing.Color.Black
        Me.btnClose.Location = New System.Drawing.Point(433, 543)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(92, 30)
        Me.btnClose.TabIndex = 4
        Me.btnClose.Text = "&Close"
        Me.btnClose.UseVisualStyleBackColor = False
        '
        'imgRetrieve
        '
        Me.imgRetrieve.BackColor = System.Drawing.Color.Black
        Me.imgRetrieve.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.imgRetrieve.Location = New System.Drawing.Point(5, 44)
        Me.imgRetrieve.Name = "imgRetrieve"
        Me.imgRetrieve.Size = New System.Drawing.Size(518, 360)
        Me.imgRetrieve.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.imgRetrieve.TabIndex = 0
        Me.imgRetrieve.TabStop = False
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label3.Font = New System.Drawing.Font("Asomiya_Rohini", 11.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.DarkRed
        Me.Label3.Location = New System.Drawing.Point(4, 8)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(233, 25)
        Me.Label3.TabIndex = 49
        Me.Label3.Text = "ছবিৰ প্ৰথমৰ আখৰটো টাইপ কৰক"
        '
        'txtWord
        '
        Me.txtWord.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtWord.ForeColor = System.Drawing.Color.Black
        Me.txtWord.Location = New System.Drawing.Point(4, 28)
        Me.txtWord.MaxLength = 50
        Me.txtWord.Name = "txtWord"
        Me.txtWord.Size = New System.Drawing.Size(233, 35)
        Me.txtWord.TabIndex = 50
        '
        'GroupBox6
        '
        Me.GroupBox6.BackgroundImage = Global.ABD.My.Resources.Resources.BackDown
        Me.GroupBox6.Controls.Add(Me.btnClear)
        Me.GroupBox6.Controls.Add(Me.txtWord)
        Me.GroupBox6.Controls.Add(Me.Label3)
        Me.GroupBox6.Location = New System.Drawing.Point(173, -5)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(720, 67)
        Me.GroupBox6.TabIndex = 61
        Me.GroupBox6.TabStop = False
        '
        'btnClear
        '
        Me.btnClear.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.btnClear.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClear.ForeColor = System.Drawing.Color.Black
        Me.btnClear.Location = New System.Drawing.Point(239, 33)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(61, 26)
        Me.btnClear.TabIndex = 51
        Me.btnClear.Text = "Clea&r"
        Me.btnClear.UseVisualStyleBackColor = False
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label4.Font = New System.Drawing.Font("Asomiya_Rohini", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Maroon
        Me.Label4.Location = New System.Drawing.Point(4, 12)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(185, 29)
        Me.Label4.TabIndex = 53
        Me.Label4.Text = "প্ৰয়োজনীয় শব্দটো ক্লিক কৰক"
        '
        'GroupBox7
        '
        Me.GroupBox7.BackgroundImage = Global.ABD.My.Resources.Resources.BackDown
        Me.GroupBox7.Controls.Add(Me.lvPicName)
        Me.GroupBox7.Controls.Add(Me.Label4)
        Me.GroupBox7.Location = New System.Drawing.Point(173, 62)
        Me.GroupBox7.Name = "GroupBox7"
        Me.GroupBox7.Size = New System.Drawing.Size(194, 578)
        Me.GroupBox7.TabIndex = 62
        Me.GroupBox7.TabStop = False
        '
        'lvPicName
        '
        Me.lvPicName.Font = New System.Drawing.Font("Asomiya_Rohini", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lvPicName.FormattingEnabled = True
        Me.lvPicName.ItemHeight = 26
        Me.lvPicName.Location = New System.Drawing.Point(5, 43)
        Me.lvPicName.Name = "lvPicName"
        Me.lvPicName.Size = New System.Drawing.Size(185, 524)
        Me.lvPicName.TabIndex = 60
        '
        'GroupBox12
        '
        Me.GroupBox12.BackgroundImage = Global.ABD.My.Resources.Resources.BackDown
        Me.GroupBox12.Controls.Add(Me.Label2)
        Me.GroupBox12.Controls.Add(Me.gvCons)
        Me.GroupBox12.Font = New System.Drawing.Font("Asomiya_Rohini", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox12.ForeColor = System.Drawing.Color.Black
        Me.GroupBox12.Location = New System.Drawing.Point(0, -10)
        Me.GroupBox12.Name = "GroupBox12"
        Me.GroupBox12.Size = New System.Drawing.Size(174, 490)
        Me.GroupBox12.TabIndex = 71
        Me.GroupBox12.TabStop = False
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Label2.Font = New System.Drawing.Font("Asomiya_Rohini", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(5, 27)
        Me.Label2.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(168, 25)
        Me.Label2.TabIndex = 68
        Me.Label2.Text = "ব্যঞ্জনবর্ণ"
        '
        'gvCons
        '
        Me.gvCons.AllowUserToAddRows = False
        Me.gvCons.AllowUserToDeleteRows = False
        Me.gvCons.AllowUserToResizeColumns = False
        Me.gvCons.AllowUserToResizeRows = False
        Me.gvCons.BackgroundColor = System.Drawing.Color.Silver
        Me.gvCons.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gvCons.ColumnHeadersVisible = False
        Me.gvCons.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column13})
        Me.gvCons.Location = New System.Drawing.Point(9, 57)
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
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.gvVowel)
        Me.GroupBox2.Controls.Add(Me.PictureBox5)
        Me.GroupBox2.Font = New System.Drawing.Font("Asomiya_Rohini", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.ForeColor = System.Drawing.Color.Black
        Me.GroupBox2.Location = New System.Drawing.Point(6, 505)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(163, 126)
        Me.GroupBox2.TabIndex = 72
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "¦¤1ÂõíÇ"
        '
        'gvVowel
        '
        Me.gvVowel.AllowUserToAddRows = False
        Me.gvVowel.AllowUserToDeleteRows = False
        Me.gvVowel.AllowUserToResizeColumns = False
        Me.gvVowel.AllowUserToResizeRows = False
        Me.gvVowel.BackgroundColor = System.Drawing.Color.Silver
        Me.gvVowel.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gvVowel.ColumnHeadersVisible = False
        Me.gvVowel.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column18})
        Me.gvVowel.Location = New System.Drawing.Point(1, 3)
        Me.gvVowel.Name = "gvVowel"
        Me.gvVowel.ReadOnly = True
        Me.gvVowel.RowHeadersVisible = False
        Me.gvVowel.ShowCellToolTips = False
        Me.gvVowel.Size = New System.Drawing.Size(160, 120)
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
        'PictureBox5
        '
        Me.PictureBox5.Image = Global.ABD.My.Resources.Resources.P_extra_label3
        Me.PictureBox5.Location = New System.Drawing.Point(0, 0)
        Me.PictureBox5.Name = "PictureBox5"
        Me.PictureBox5.Size = New System.Drawing.Size(163, 126)
        Me.PictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox5.TabIndex = 1
        Me.PictureBox5.TabStop = False
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Label5.Font = New System.Drawing.Font("Asomiya_Rohini", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(3, 473)
        Me.Label5.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(169, 32)
        Me.Label5.TabIndex = 76
        Me.Label5.Text = "স্বৰবর্ণ"
        '
        'GroupBox5
        '
        Me.GroupBox5.BackgroundImage = Global.ABD.My.Resources.Resources.BackDown
        Me.GroupBox5.Controls.Add(Me.Label5)
        Me.GroupBox5.Controls.Add(Me.GroupBox2)
        Me.GroupBox5.Controls.Add(Me.GroupBox12)
        Me.GroupBox5.Location = New System.Drawing.Point(-1, -2)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(174, 641)
        Me.GroupBox5.TabIndex = 76
        Me.GroupBox5.TabStop = False
        '
        'frmPicture
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.IndianRed
        Me.CancelButton = Me.btnClose
        Me.ClientSize = New System.Drawing.Size(894, 641)
        Me.Controls.Add(Me.GroupBox5)
        Me.Controls.Add(Me.GroupBox8)
        Me.Controls.Add(Me.GroupBox7)
        Me.Controls.Add(Me.GroupBox6)
        Me.ForeColor = System.Drawing.Color.Black
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "frmPicture"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ছবি"
        Me.GroupBox8.ResumeLayout(False)
        Me.GroupBox8.PerformLayout()
        CType(Me.imgRetrieve, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox6.ResumeLayout(False)
        Me.GroupBox6.PerformLayout()
        Me.GroupBox7.ResumeLayout(False)
        Me.GroupBox12.ResumeLayout(False)
        CType(Me.gvCons, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        CType(Me.gvVowel, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox5, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox5.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox8 As System.Windows.Forms.GroupBox
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtWord As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox6 As System.Windows.Forms.GroupBox
    Friend WithEvents btnClear As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents GroupBox7 As System.Windows.Forms.GroupBox
    Friend WithEvents btnSavePicture As System.Windows.Forms.Button
    Friend WithEvents savePicture As System.Windows.Forms.SaveFileDialog
    Friend WithEvents imgRetrieve As System.Windows.Forms.PictureBox
    Friend WithEvents txtPicMean As System.Windows.Forms.TextBox
    Friend WithEvents btnFullImage As System.Windows.Forms.Button
    Friend WithEvents lblPicName As System.Windows.Forms.Label
    Friend WithEvents lvPicName As System.Windows.Forms.ListBox
    Friend WithEvents GroupBox12 As System.Windows.Forms.GroupBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents gvCons As System.Windows.Forms.DataGridView
    Friend WithEvents Column13 As System.Windows.Forms.DataGridViewButtonColumn
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents gvVowel As System.Windows.Forms.DataGridView
    Friend WithEvents Column18 As System.Windows.Forms.DataGridViewButtonColumn
    Friend WithEvents PictureBox5 As System.Windows.Forms.PictureBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
End Class
