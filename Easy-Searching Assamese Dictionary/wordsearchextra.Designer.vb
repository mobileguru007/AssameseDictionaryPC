<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class wordsearchextra
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.rbtnAbbr = New System.Windows.Forms.RadioButton
        Me.rbtnSName = New System.Windows.Forms.RadioButton
        Me.rbtnPin = New System.Windows.Forms.RadioButton
        Me.rbtnInsect = New System.Windows.Forms.RadioButton
        Me.rbtnPlant = New System.Windows.Forms.RadioButton
        Me.rbtnCountry = New System.Windows.Forms.RadioButton
        Me.rbtnVeg = New System.Windows.Forms.RadioButton
        Me.rbtnDate = New System.Windows.Forms.RadioButton
        Me.rbtnToos = New System.Windows.Forms.RadioButton
        Me.rbtnLaw = New System.Windows.Forms.RadioButton
        Me.rbtnFruit = New System.Windows.Forms.RadioButton
        Me.btnFlower = New System.Windows.Forms.RadioButton
        Me.rbtnFish = New System.Windows.Forms.RadioButton
        Me.rbtnBird = New System.Windows.Forms.RadioButton
        Me.rbtnAnimal = New System.Windows.Forms.RadioButton
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.txtWord = New System.Windows.Forms.TextBox
        Me.lvWords = New System.Windows.Forms.ListView
        Me.ColumnHeader6 = New System.Windows.Forms.ColumnHeader
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.DataGridView2 = New System.Windows.Forms.DataGridView
        Me.txtMeaning = New System.Windows.Forms.RichTextBox
        Me.imgRetrieve = New System.Windows.Forms.PictureBox
        Me.DataGridView1 = New System.Windows.Forms.DataGridView
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.rbtnHindi = New System.Windows.Forms.RadioButton
        Me.rbtnEnglish = New System.Windows.Forms.RadioButton
        Me.rbtnAssamese = New System.Windows.Forms.RadioButton
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.imgRetrieve, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.rbtnAbbr)
        Me.GroupBox1.Controls.Add(Me.rbtnSName)
        Me.GroupBox1.Controls.Add(Me.rbtnPin)
        Me.GroupBox1.Controls.Add(Me.rbtnInsect)
        Me.GroupBox1.Controls.Add(Me.rbtnPlant)
        Me.GroupBox1.Controls.Add(Me.rbtnCountry)
        Me.GroupBox1.Controls.Add(Me.rbtnVeg)
        Me.GroupBox1.Controls.Add(Me.rbtnDate)
        Me.GroupBox1.Controls.Add(Me.rbtnToos)
        Me.GroupBox1.Controls.Add(Me.rbtnLaw)
        Me.GroupBox1.Controls.Add(Me.rbtnFruit)
        Me.GroupBox1.Controls.Add(Me.btnFlower)
        Me.GroupBox1.Controls.Add(Me.rbtnFish)
        Me.GroupBox1.Controls.Add(Me.rbtnBird)
        Me.GroupBox1.Controls.Add(Me.rbtnAnimal)
        Me.GroupBox1.Location = New System.Drawing.Point(1, 2)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(880, 85)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Categories"
        '
        'rbtnAbbr
        '
        Me.rbtnAbbr.AutoSize = True
        Me.rbtnAbbr.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbtnAbbr.Location = New System.Drawing.Point(108, 18)
        Me.rbtnAbbr.Name = "rbtnAbbr"
        Me.rbtnAbbr.Size = New System.Drawing.Size(133, 28)
        Me.rbtnAbbr.TabIndex = 14
        Me.rbtnAbbr.Text = "&Abbreviation"
        Me.rbtnAbbr.UseVisualStyleBackColor = True
        '
        'rbtnSName
        '
        Me.rbtnSName.AutoSize = True
        Me.rbtnSName.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbtnSName.Location = New System.Drawing.Point(479, 52)
        Me.rbtnSName.Name = "rbtnSName"
        Me.rbtnSName.Size = New System.Drawing.Size(158, 28)
        Me.rbtnSName.TabIndex = 13
        Me.rbtnSName.Text = "&Scientific Name"
        Me.rbtnSName.UseVisualStyleBackColor = True
        '
        'rbtnPin
        '
        Me.rbtnPin.AutoSize = True
        Me.rbtnPin.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbtnPin.Location = New System.Drawing.Point(243, 52)
        Me.rbtnPin.Name = "rbtnPin"
        Me.rbtnPin.Size = New System.Drawing.Size(109, 28)
        Me.rbtnPin.TabIndex = 11
        Me.rbtnPin.Text = "PI&N Code"
        Me.rbtnPin.UseVisualStyleBackColor = True
        '
        'rbtnInsect
        '
        Me.rbtnInsect.AutoSize = True
        Me.rbtnInsect.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbtnInsect.Location = New System.Drawing.Point(16, 52)
        Me.rbtnInsect.Name = "rbtnInsect"
        Me.rbtnInsect.Size = New System.Drawing.Size(77, 28)
        Me.rbtnInsect.TabIndex = 12
        Me.rbtnInsect.Text = "&Insect"
        Me.rbtnInsect.UseVisualStyleBackColor = True
        '
        'rbtnPlant
        '
        Me.rbtnPlant.AutoSize = True
        Me.rbtnPlant.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbtnPlant.Location = New System.Drawing.Point(352, 52)
        Me.rbtnPlant.Name = "rbtnPlant"
        Me.rbtnPlant.Size = New System.Drawing.Size(69, 28)
        Me.rbtnPlant.TabIndex = 10
        Me.rbtnPlant.Text = "&Plant"
        Me.rbtnPlant.UseVisualStyleBackColor = True
        '
        'rbtnCountry
        '
        Me.rbtnCountry.AutoSize = True
        Me.rbtnCountry.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbtnCountry.Location = New System.Drawing.Point(352, 18)
        Me.rbtnCountry.Name = "rbtnCountry"
        Me.rbtnCountry.Size = New System.Drawing.Size(93, 28)
        Me.rbtnCountry.TabIndex = 9
        Me.rbtnCountry.Text = "&Country"
        Me.rbtnCountry.UseVisualStyleBackColor = True
        '
        'rbtnVeg
        '
        Me.rbtnVeg.AutoSize = True
        Me.rbtnVeg.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbtnVeg.Location = New System.Drawing.Point(760, 52)
        Me.rbtnVeg.Name = "rbtnVeg"
        Me.rbtnVeg.Size = New System.Drawing.Size(114, 28)
        Me.rbtnVeg.TabIndex = 8
        Me.rbtnVeg.Text = "&Vegetable"
        Me.rbtnVeg.UseVisualStyleBackColor = True
        '
        'rbtnDate
        '
        Me.rbtnDate.AutoSize = True
        Me.rbtnDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbtnDate.Location = New System.Drawing.Point(470, 18)
        Me.rbtnDate.Name = "rbtnDate"
        Me.rbtnDate.Size = New System.Drawing.Size(66, 28)
        Me.rbtnDate.TabIndex = 7
        Me.rbtnDate.Text = "&Date"
        Me.rbtnDate.UseVisualStyleBackColor = True
        '
        'rbtnToos
        '
        Me.rbtnToos.AutoSize = True
        Me.rbtnToos.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbtnToos.Location = New System.Drawing.Point(647, 52)
        Me.rbtnToos.Name = "rbtnToos"
        Me.rbtnToos.Size = New System.Drawing.Size(75, 28)
        Me.rbtnToos.TabIndex = 6
        Me.rbtnToos.Text = "&Tools"
        Me.rbtnToos.UseVisualStyleBackColor = True
        '
        'rbtnLaw
        '
        Me.rbtnLaw.AutoSize = True
        Me.rbtnLaw.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbtnLaw.Location = New System.Drawing.Point(108, 52)
        Me.rbtnLaw.Name = "rbtnLaw"
        Me.rbtnLaw.Size = New System.Drawing.Size(133, 28)
        Me.rbtnLaw.TabIndex = 5
        Me.rbtnLaw.Text = "&Law && Office"
        Me.rbtnLaw.UseVisualStyleBackColor = True
        '
        'rbtnFruit
        '
        Me.rbtnFruit.AutoSize = True
        Me.rbtnFruit.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbtnFruit.Location = New System.Drawing.Point(760, 18)
        Me.rbtnFruit.Name = "rbtnFruit"
        Me.rbtnFruit.Size = New System.Drawing.Size(65, 28)
        Me.rbtnFruit.TabIndex = 4
        Me.rbtnFruit.Text = "F&ruit"
        Me.rbtnFruit.UseVisualStyleBackColor = True
        '
        'btnFlower
        '
        Me.btnFlower.AutoSize = True
        Me.btnFlower.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnFlower.Location = New System.Drawing.Point(647, 18)
        Me.btnFlower.Name = "btnFlower"
        Me.btnFlower.Size = New System.Drawing.Size(86, 28)
        Me.btnFlower.TabIndex = 3
        Me.btnFlower.Text = "Flo&wer"
        Me.btnFlower.UseVisualStyleBackColor = True
        '
        'rbtnFish
        '
        Me.rbtnFish.AutoSize = True
        Me.rbtnFish.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbtnFish.Location = New System.Drawing.Point(561, 18)
        Me.rbtnFish.Name = "rbtnFish"
        Me.rbtnFish.Size = New System.Drawing.Size(64, 28)
        Me.rbtnFish.TabIndex = 2
        Me.rbtnFish.Text = "&Fish"
        Me.rbtnFish.UseVisualStyleBackColor = True
        '
        'rbtnBird
        '
        Me.rbtnBird.AutoSize = True
        Me.rbtnBird.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbtnBird.Location = New System.Drawing.Point(243, 18)
        Me.rbtnBird.Name = "rbtnBird"
        Me.rbtnBird.Size = New System.Drawing.Size(61, 28)
        Me.rbtnBird.TabIndex = 1
        Me.rbtnBird.Text = "&Bird"
        Me.rbtnBird.UseVisualStyleBackColor = True
        '
        'rbtnAnimal
        '
        Me.rbtnAnimal.AutoSize = True
        Me.rbtnAnimal.Checked = True
        Me.rbtnAnimal.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbtnAnimal.Location = New System.Drawing.Point(16, 18)
        Me.rbtnAnimal.Name = "rbtnAnimal"
        Me.rbtnAnimal.Size = New System.Drawing.Size(86, 28)
        Me.rbtnAnimal.TabIndex = 0
        Me.rbtnAnimal.TabStop = True
        Me.rbtnAnimal.Text = "&Animal"
        Me.rbtnAnimal.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.txtWord)
        Me.GroupBox3.Controls.Add(Me.lvWords)
        Me.GroupBox3.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox3.Location = New System.Drawing.Point(1, 93)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(432, 529)
        Me.GroupBox3.TabIndex = 6
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Search"
        '
        'txtWord
        '
        Me.txtWord.Location = New System.Drawing.Point(5, 19)
        Me.txtWord.Name = "txtWord"
        Me.txtWord.Size = New System.Drawing.Size(421, 23)
        Me.txtWord.TabIndex = 106
        '
        'lvWords
        '
        Me.lvWords.Activation = System.Windows.Forms.ItemActivation.OneClick
        Me.lvWords.BackColor = System.Drawing.Color.White
        Me.lvWords.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader6})
        Me.lvWords.Font = New System.Drawing.Font("Microsoft Sans Serif", 17.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lvWords.ForeColor = System.Drawing.Color.Black
        Me.lvWords.FullRowSelect = True
        Me.lvWords.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None
        Me.lvWords.Location = New System.Drawing.Point(3, 53)
        Me.lvWords.MultiSelect = False
        Me.lvWords.Name = "lvWords"
        Me.lvWords.Size = New System.Drawing.Size(423, 470)
        Me.lvWords.TabIndex = 105
        Me.lvWords.UseCompatibleStateImageBehavior = False
        Me.lvWords.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader6
        '
        Me.ColumnHeader6.Text = "words"
        Me.ColumnHeader6.Width = 400
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.DataGridView2)
        Me.GroupBox4.Controls.Add(Me.txtMeaning)
        Me.GroupBox4.Controls.Add(Me.imgRetrieve)
        Me.GroupBox4.Controls.Add(Me.DataGridView1)
        Me.GroupBox4.Controls.Add(Me.rbtnHindi)
        Me.GroupBox4.Controls.Add(Me.rbtnEnglish)
        Me.GroupBox4.Controls.Add(Me.rbtnAssamese)
        Me.GroupBox4.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox4.Location = New System.Drawing.Point(439, 93)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(442, 529)
        Me.GroupBox4.TabIndex = 7
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Laguages"
        '
        'DataGridView2
        '
        Me.DataGridView2.AllowUserToAddRows = False
        Me.DataGridView2.AllowUserToDeleteRows = False
        Me.DataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView2.Location = New System.Drawing.Point(6, 56)
        Me.DataGridView2.Name = "DataGridView2"
        Me.DataGridView2.ReadOnly = True
        Me.DataGridView2.RowHeadersVisible = False
        Me.DataGridView2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridView2.Size = New System.Drawing.Size(430, 464)
        Me.DataGridView2.TabIndex = 55569
        Me.DataGridView2.Visible = False
        '
        'txtMeaning
        '
        Me.txtMeaning.BackColor = System.Drawing.Color.White
        Me.txtMeaning.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMeaning.Location = New System.Drawing.Point(6, 56)
        Me.txtMeaning.Name = "txtMeaning"
        Me.txtMeaning.ReadOnly = True
        Me.txtMeaning.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical
        Me.txtMeaning.Size = New System.Drawing.Size(430, 464)
        Me.txtMeaning.TabIndex = 55568
        Me.txtMeaning.Text = ""
        Me.txtMeaning.Visible = False
        '
        'imgRetrieve
        '
        Me.imgRetrieve.BackColor = System.Drawing.Color.Black
        Me.imgRetrieve.BackgroundImage = Global.ABD.My.Resources.Resources.BackDown
        Me.imgRetrieve.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.imgRetrieve.Location = New System.Drawing.Point(6, 184)
        Me.imgRetrieve.Name = "imgRetrieve"
        Me.imgRetrieve.Size = New System.Drawing.Size(430, 336)
        Me.imgRetrieve.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.imgRetrieve.TabIndex = 19
        Me.imgRetrieve.TabStop = False
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.ColumnHeadersVisible = False
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.Column2})
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.Padding = New System.Windows.Forms.Padding(0, 0, 0, 5)
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridView1.DefaultCellStyle = DataGridViewCellStyle1
        Me.DataGridView1.Location = New System.Drawing.Point(6, 53)
        Me.DataGridView1.MultiSelect = False
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RowHeadersVisible = False
        Me.DataGridView1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders
        Me.DataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.DataGridView1.Size = New System.Drawing.Size(427, 125)
        Me.DataGridView1.TabIndex = 18
        '
        'Column1
        '
        Me.Column1.HeaderText = ""
        Me.Column1.Name = "Column1"
        Me.Column1.Width = 120
        '
        'Column2
        '
        Me.Column2.HeaderText = ""
        Me.Column2.Name = "Column2"
        Me.Column2.Width = 800
        '
        'rbtnHindi
        '
        Me.rbtnHindi.AutoSize = True
        Me.rbtnHindi.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbtnHindi.Location = New System.Drawing.Point(299, 22)
        Me.rbtnHindi.Name = "rbtnHindi"
        Me.rbtnHindi.Size = New System.Drawing.Size(72, 28)
        Me.rbtnHindi.TabIndex = 16
        Me.rbtnHindi.Text = "&Hindi"
        Me.rbtnHindi.UseVisualStyleBackColor = True
        '
        'rbtnEnglish
        '
        Me.rbtnEnglish.AutoSize = True
        Me.rbtnEnglish.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbtnEnglish.Location = New System.Drawing.Point(158, 22)
        Me.rbtnEnglish.Name = "rbtnEnglish"
        Me.rbtnEnglish.Size = New System.Drawing.Size(91, 28)
        Me.rbtnEnglish.TabIndex = 15
        Me.rbtnEnglish.Text = "&English"
        Me.rbtnEnglish.UseVisualStyleBackColor = True
        '
        'rbtnAssamese
        '
        Me.rbtnAssamese.AutoSize = True
        Me.rbtnAssamese.Checked = True
        Me.rbtnAssamese.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbtnAssamese.Location = New System.Drawing.Point(12, 22)
        Me.rbtnAssamese.Name = "rbtnAssamese"
        Me.rbtnAssamese.Size = New System.Drawing.Size(116, 28)
        Me.rbtnAssamese.TabIndex = 14
        Me.rbtnAssamese.TabStop = True
        Me.rbtnAssamese.Text = "&Assamese"
        Me.rbtnAssamese.UseVisualStyleBackColor = True
        '
        'wordsearchextra
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ControlLight
        Me.ClientSize = New System.Drawing.Size(894, 611)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox1)
        Me.Font = New System.Drawing.Font("Asomiya_Rohini", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "wordsearchextra"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "অতিৰিক্ত শব্দকোষ"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.imgRetrieve, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents rbtnCountry As System.Windows.Forms.RadioButton
    Friend WithEvents rbtnVeg As System.Windows.Forms.RadioButton
    Friend WithEvents rbtnDate As System.Windows.Forms.RadioButton
    Friend WithEvents rbtnToos As System.Windows.Forms.RadioButton
    Friend WithEvents rbtnLaw As System.Windows.Forms.RadioButton
    Friend WithEvents rbtnFruit As System.Windows.Forms.RadioButton
    Friend WithEvents btnFlower As System.Windows.Forms.RadioButton
    Friend WithEvents rbtnFish As System.Windows.Forms.RadioButton
    Friend WithEvents rbtnBird As System.Windows.Forms.RadioButton
    Friend WithEvents rbtnAnimal As System.Windows.Forms.RadioButton
    Friend WithEvents rbtnSName As System.Windows.Forms.RadioButton
    Friend WithEvents rbtnInsect As System.Windows.Forms.RadioButton
    Friend WithEvents rbtnPin As System.Windows.Forms.RadioButton
    Friend WithEvents rbtnPlant As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents rbtnHindi As System.Windows.Forms.RadioButton
    Friend WithEvents rbtnEnglish As System.Windows.Forms.RadioButton
    Friend WithEvents rbtnAssamese As System.Windows.Forms.RadioButton
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents lvWords As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader6 As System.Windows.Forms.ColumnHeader
    Friend WithEvents imgRetrieve As System.Windows.Forms.PictureBox
    Friend WithEvents txtWord As System.Windows.Forms.TextBox
    Friend WithEvents txtMeaning As System.Windows.Forms.RichTextBox
    Friend WithEvents rbtnAbbr As System.Windows.Forms.RadioButton
    Friend WithEvents DataGridView2 As System.Windows.Forms.DataGridView
End Class
