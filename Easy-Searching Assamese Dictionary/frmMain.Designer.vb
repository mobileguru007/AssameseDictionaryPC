<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMain
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
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMain))
        Me.StatusStrip = New System.Windows.Forms.StatusStrip
        Me.ToolStripStatusLabel = New System.Windows.Forms.ToolStripStatusLabel
        Me.ToolTip = New System.Windows.Forms.ToolTip(Me.components)
        Me.FileSystemWatcher1 = New System.IO.FileSystemWatcher
        Me.MenuStrip = New System.Windows.Forms.MenuStrip
        Me.DictionaryToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.OpenWordSearch = New System.Windows.Forms.ToolStripMenuItem
        Me.extrawords = New System.Windows.Forms.ToolStripMenuItem
        Me.FakaraJojanaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.OpenFakara = New System.Windows.Forms.ToolStripMenuItem
        Me.PictureToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.OpenPicture = New System.Windows.Forms.ToolStripMenuItem
        Me.WrongCorrectWordsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.OpenToolStripMenuItem3 = New System.Windows.Forms.ToolStripMenuItem
        Me.GrammarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.GrammerToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.NameWordToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.NamingToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.AboutUsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.EditorialToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.AboutUsToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.ContactUs = New System.Windows.Forms.ToolStripMenuItem
        Me.ReferenceToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.UsersGuideToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.HelpToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ActvationToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ActivateToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.PersonalToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.AcknowToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.CascadeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.TileVerticalToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.TileHorizontalToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.CloseAllToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.StatusStrip.SuspendLayout()
        CType(Me.FileSystemWatcher1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MenuStrip.SuspendLayout()
        Me.SuspendLayout()
        '
        'StatusStrip
        '
        Me.StatusStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel})
        Me.StatusStrip.Location = New System.Drawing.Point(0, 495)
        Me.StatusStrip.Name = "StatusStrip"
        Me.StatusStrip.Size = New System.Drawing.Size(797, 22)
        Me.StatusStrip.TabIndex = 7
        Me.StatusStrip.Text = "StatusStrip"
        Me.StatusStrip.Visible = False
        '
        'ToolStripStatusLabel
        '
        Me.ToolStripStatusLabel.Name = "ToolStripStatusLabel"
        Me.ToolStripStatusLabel.Size = New System.Drawing.Size(39, 17)
        Me.ToolStripStatusLabel.Text = "Status"
        '
        'ToolTip
        '
        Me.ToolTip.BackColor = System.Drawing.SystemColors.ActiveCaption
        '
        'FileSystemWatcher1
        '
        Me.FileSystemWatcher1.EnableRaisingEvents = True
        Me.FileSystemWatcher1.SynchronizingObject = Me
        '
        'MenuStrip
        '
        Me.MenuStrip.BackColor = System.Drawing.Color.LightGray
        Me.MenuStrip.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.MenuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DictionaryToolStripMenuItem, Me.FakaraJojanaToolStripMenuItem, Me.PictureToolStripMenuItem, Me.WrongCorrectWordsToolStripMenuItem, Me.GrammarToolStripMenuItem, Me.NameWordToolStripMenuItem, Me.AboutUsToolStripMenuItem, Me.ReferenceToolStripMenuItem, Me.UsersGuideToolStripMenuItem, Me.ActvationToolStripMenuItem})
        Me.MenuStrip.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip.Name = "MenuStrip"
        Me.MenuStrip.Size = New System.Drawing.Size(1042, 37)
        Me.MenuStrip.TabIndex = 11
        Me.MenuStrip.Text = "MenuStrip"
        '
        'DictionaryToolStripMenuItem
        '
        Me.DictionaryToolStripMenuItem.BackColor = System.Drawing.Color.LightGray
        Me.DictionaryToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.OpenWordSearch, Me.extrawords})
        Me.DictionaryToolStripMenuItem.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DictionaryToolStripMenuItem.ForeColor = System.Drawing.Color.DimGray
        Me.DictionaryToolStripMenuItem.Name = "DictionaryToolStripMenuItem"
        Me.DictionaryToolStripMenuItem.Size = New System.Drawing.Size(93, 33)
        Me.DictionaryToolStripMenuItem.Text = "অভিধান"
        Me.DictionaryToolStripMenuItem.ToolTipText = "F2"
        '
        'OpenWordSearch
        '
        Me.OpenWordSearch.BackColor = System.Drawing.Color.Silver
        Me.OpenWordSearch.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OpenWordSearch.ForeColor = System.Drawing.Color.Black
        Me.OpenWordSearch.Name = "OpenWordSearch"
        Me.OpenWordSearch.ShortcutKeys = System.Windows.Forms.Keys.F2
        Me.OpenWordSearch.Size = New System.Drawing.Size(235, 28)
        Me.OpenWordSearch.Text = "শব্দ শিতান"
        '
        'extrawords
        '
        Me.extrawords.BackColor = System.Drawing.Color.Silver
        Me.extrawords.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.extrawords.ForeColor = System.Drawing.Color.Black
        Me.extrawords.Name = "extrawords"
        Me.extrawords.ShortcutKeys = System.Windows.Forms.Keys.F8
        Me.extrawords.Size = New System.Drawing.Size(235, 28)
        Me.extrawords.Text = "অতিৰিক্ত শব্দকোষ"
        '
        'FakaraJojanaToolStripMenuItem
        '
        Me.FakaraJojanaToolStripMenuItem.BackColor = System.Drawing.Color.LightGray
        Me.FakaraJojanaToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.OpenFakara})
        Me.FakaraJojanaToolStripMenuItem.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FakaraJojanaToolStripMenuItem.ForeColor = System.Drawing.Color.DimGray
        Me.FakaraJojanaToolStripMenuItem.Name = "FakaraJojanaToolStripMenuItem"
        Me.FakaraJojanaToolStripMenuItem.Size = New System.Drawing.Size(145, 33)
        Me.FakaraJojanaToolStripMenuItem.Text = "ফকৰা-যোজনা"
        Me.FakaraJojanaToolStripMenuItem.ToolTipText = "F3"
        '
        'OpenFakara
        '
        Me.OpenFakara.BackColor = System.Drawing.Color.LightGray
        Me.OpenFakara.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OpenFakara.ForeColor = System.Drawing.Color.Black
        Me.OpenFakara.Name = "OpenFakara"
        Me.OpenFakara.ShortcutKeys = System.Windows.Forms.Keys.F3
        Me.OpenFakara.Size = New System.Drawing.Size(159, 28)
        Me.OpenFakara.Text = "খোলক"
        '
        'PictureToolStripMenuItem
        '
        Me.PictureToolStripMenuItem.BackColor = System.Drawing.Color.LightGray
        Me.PictureToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.OpenPicture})
        Me.PictureToolStripMenuItem.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PictureToolStripMenuItem.ForeColor = System.Drawing.Color.DimGray
        Me.PictureToolStripMenuItem.Name = "PictureToolStripMenuItem"
        Me.PictureToolStripMenuItem.Size = New System.Drawing.Size(55, 33)
        Me.PictureToolStripMenuItem.Text = "ছবি"
        Me.PictureToolStripMenuItem.ToolTipText = "F4"
        '
        'OpenPicture
        '
        Me.OpenPicture.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OpenPicture.ForeColor = System.Drawing.Color.Black
        Me.OpenPicture.Name = "OpenPicture"
        Me.OpenPicture.ShortcutKeys = System.Windows.Forms.Keys.F4
        Me.OpenPicture.Size = New System.Drawing.Size(159, 28)
        Me.OpenPicture.Text = "খোলক"
        '
        'WrongCorrectWordsToolStripMenuItem
        '
        Me.WrongCorrectWordsToolStripMenuItem.BackColor = System.Drawing.Color.LightGray
        Me.WrongCorrectWordsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.OpenToolStripMenuItem3})
        Me.WrongCorrectWordsToolStripMenuItem.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.WrongCorrectWordsToolStripMenuItem.ForeColor = System.Drawing.Color.DimGray
        Me.WrongCorrectWordsToolStripMenuItem.Name = "WrongCorrectWordsToolStripMenuItem"
        Me.WrongCorrectWordsToolStripMenuItem.Size = New System.Drawing.Size(97, 33)
        Me.WrongCorrectWordsToolStripMenuItem.Text = "ভুল-শুদ্ধ"
        Me.WrongCorrectWordsToolStripMenuItem.ToolTipText = "F5"
        '
        'OpenToolStripMenuItem3
        '
        Me.OpenToolStripMenuItem3.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OpenToolStripMenuItem3.ForeColor = System.Drawing.Color.Black
        Me.OpenToolStripMenuItem3.Name = "OpenToolStripMenuItem3"
        Me.OpenToolStripMenuItem3.ShortcutKeys = System.Windows.Forms.Keys.F5
        Me.OpenToolStripMenuItem3.Size = New System.Drawing.Size(159, 28)
        Me.OpenToolStripMenuItem3.Text = "খোলক"
        '
        'GrammarToolStripMenuItem
        '
        Me.GrammarToolStripMenuItem.BackColor = System.Drawing.Color.LightGray
        Me.GrammarToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.GrammerToolStripMenuItem})
        Me.GrammarToolStripMenuItem.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GrammarToolStripMenuItem.ForeColor = System.Drawing.Color.DimGray
        Me.GrammarToolStripMenuItem.Name = "GrammarToolStripMenuItem"
        Me.GrammarToolStripMenuItem.Size = New System.Drawing.Size(89, 33)
        Me.GrammarToolStripMenuItem.Text = "ব্যাকৰণ"
        Me.GrammarToolStripMenuItem.ToolTipText = "F7"
        '
        'GrammerToolStripMenuItem
        '
        Me.GrammerToolStripMenuItem.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GrammerToolStripMenuItem.ForeColor = System.Drawing.Color.Black
        Me.GrammerToolStripMenuItem.Name = "GrammerToolStripMenuItem"
        Me.GrammerToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F7
        Me.GrammerToolStripMenuItem.Size = New System.Drawing.Size(159, 28)
        Me.GrammerToolStripMenuItem.Text = "খোলক"
        '
        'NameWordToolStripMenuItem
        '
        Me.NameWordToolStripMenuItem.BackColor = System.Drawing.Color.LightGray
        Me.NameWordToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NamingToolStripMenuItem})
        Me.NameWordToolStripMenuItem.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NameWordToolStripMenuItem.ForeColor = System.Drawing.Color.DimGray
        Me.NameWordToolStripMenuItem.Name = "NameWordToolStripMenuItem"
        Me.NameWordToolStripMenuItem.Size = New System.Drawing.Size(95, 33)
        Me.NameWordToolStripMenuItem.Text = "নাম-শব্দ"
        Me.NameWordToolStripMenuItem.ToolTipText = "F6"
        '
        'NamingToolStripMenuItem
        '
        Me.NamingToolStripMenuItem.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NamingToolStripMenuItem.ForeColor = System.Drawing.Color.Black
        Me.NamingToolStripMenuItem.Name = "NamingToolStripMenuItem"
        Me.NamingToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F6
        Me.NamingToolStripMenuItem.Size = New System.Drawing.Size(159, 28)
        Me.NamingToolStripMenuItem.Text = "খোলক"
        '
        'AboutUsToolStripMenuItem
        '
        Me.AboutUsToolStripMenuItem.BackColor = System.Drawing.Color.LightGray
        Me.AboutUsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.EditorialToolStripMenuItem, Me.AboutUsToolStripMenuItem1, Me.ContactUs})
        Me.AboutUsToolStripMenuItem.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.AboutUsToolStripMenuItem.ForeColor = System.Drawing.Color.DimGray
        Me.AboutUsToolStripMenuItem.Name = "AboutUsToolStripMenuItem"
        Me.AboutUsToolStripMenuItem.Size = New System.Drawing.Size(90, 33)
        Me.AboutUsToolStripMenuItem.Text = "সবিশেষ"
        '
        'EditorialToolStripMenuItem
        '
        Me.EditorialToolStripMenuItem.BackColor = System.Drawing.Color.LightGray
        Me.EditorialToolStripMenuItem.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.EditorialToolStripMenuItem.ForeColor = System.Drawing.Color.Black
        Me.EditorialToolStripMenuItem.Name = "EditorialToolStripMenuItem"
        Me.EditorialToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.E), System.Windows.Forms.Keys)
        Me.EditorialToolStripMenuItem.Size = New System.Drawing.Size(237, 28)
        Me.EditorialToolStripMenuItem.Text = "সম্পাদনা গোট"
        '
        'AboutUsToolStripMenuItem1
        '
        Me.AboutUsToolStripMenuItem1.BackColor = System.Drawing.Color.LightGray
        Me.AboutUsToolStripMenuItem1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.AboutUsToolStripMenuItem1.ForeColor = System.Drawing.Color.Black
        Me.AboutUsToolStripMenuItem1.Name = "AboutUsToolStripMenuItem1"
        Me.AboutUsToolStripMenuItem1.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.U), System.Windows.Forms.Keys)
        Me.AboutUsToolStripMenuItem1.Size = New System.Drawing.Size(237, 28)
        Me.AboutUsToolStripMenuItem1.Text = "সবিশেষ"
        '
        'ContactUs
        '
        Me.ContactUs.BackColor = System.Drawing.Color.LightGray
        Me.ContactUs.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ContactUs.ForeColor = System.Drawing.Color.Black
        Me.ContactUs.Name = "ContactUs"
        Me.ContactUs.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.F), System.Windows.Forms.Keys)
        Me.ContactUs.Size = New System.Drawing.Size(237, 28)
        Me.ContactUs.Text = "যোগাযোগ"
        Me.ContactUs.Visible = False
        '
        'ReferenceToolStripMenuItem
        '
        Me.ReferenceToolStripMenuItem.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ReferenceToolStripMenuItem.ForeColor = System.Drawing.Color.DimGray
        Me.ReferenceToolStripMenuItem.Name = "ReferenceToolStripMenuItem"
        Me.ReferenceToolStripMenuItem.Size = New System.Drawing.Size(104, 33)
        Me.ReferenceToolStripMenuItem.Text = "প্ৰাসংগিক"
        Me.ReferenceToolStripMenuItem.Visible = False
        '
        'UsersGuideToolStripMenuItem
        '
        Me.UsersGuideToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.HelpToolStripMenuItem})
        Me.UsersGuideToolStripMenuItem.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UsersGuideToolStripMenuItem.ForeColor = System.Drawing.Color.DimGray
        Me.UsersGuideToolStripMenuItem.Name = "UsersGuideToolStripMenuItem"
        Me.UsersGuideToolStripMenuItem.Size = New System.Drawing.Size(68, 33)
        Me.UsersGuideToolStripMenuItem.Text = "সহায়"
        '
        'HelpToolStripMenuItem
        '
        Me.HelpToolStripMenuItem.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.HelpToolStripMenuItem.ForeColor = System.Drawing.Color.Black
        Me.HelpToolStripMenuItem.Name = "HelpToolStripMenuItem"
        Me.HelpToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F1
        Me.HelpToolStripMenuItem.Size = New System.Drawing.Size(159, 28)
        Me.HelpToolStripMenuItem.Text = "খোলক"
        '
        'ActvationToolStripMenuItem
        '
        Me.ActvationToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ActivateToolStripMenuItem})
        Me.ActvationToolStripMenuItem.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ActvationToolStripMenuItem.ForeColor = System.Drawing.Color.DimGray
        Me.ActvationToolStripMenuItem.Name = "ActvationToolStripMenuItem"
        Me.ActvationToolStripMenuItem.Size = New System.Drawing.Size(127, 33)
        Me.ActvationToolStripMenuItem.Text = "এক্টিভেইশ‌্যন"
        Me.ActvationToolStripMenuItem.Visible = False
        '
        'ActivateToolStripMenuItem
        '
        Me.ActivateToolStripMenuItem.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ActivateToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.ActivateToolStripMenuItem.Name = "ActivateToolStripMenuItem"
        Me.ActivateToolStripMenuItem.Size = New System.Drawing.Size(152, 28)
        Me.ActivateToolStripMenuItem.Text = "এক্টিভেইট"
        '
        'PersonalToolStripMenuItem
        '
        Me.PersonalToolStripMenuItem.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PersonalToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.PersonalToolStripMenuItem.Name = "PersonalToolStripMenuItem"
        Me.PersonalToolStripMenuItem.Size = New System.Drawing.Size(254, 28)
        Me.PersonalToolStripMenuItem.Text = "অসমীয়া ভাষা সম্পৰ্কে"
        '
        'AcknowToolStripMenuItem
        '
        Me.AcknowToolStripMenuItem.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.AcknowToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.AcknowToolStripMenuItem.Name = "AcknowToolStripMenuItem"
        Me.AcknowToolStripMenuItem.Size = New System.Drawing.Size(254, 28)
        Me.AcknowToolStripMenuItem.Text = "কৃতজ্ঞতা"
        '
        'CascadeToolStripMenuItem
        '
        Me.CascadeToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.CascadeToolStripMenuItem.Name = "CascadeToolStripMenuItem"
        Me.CascadeToolStripMenuItem.Size = New System.Drawing.Size(151, 22)
        Me.CascadeToolStripMenuItem.Text = "&Cascade"
        '
        'TileVerticalToolStripMenuItem
        '
        Me.TileVerticalToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.TileVerticalToolStripMenuItem.Name = "TileVerticalToolStripMenuItem"
        Me.TileVerticalToolStripMenuItem.Size = New System.Drawing.Size(151, 22)
        Me.TileVerticalToolStripMenuItem.Text = "Tile &Vertical"
        '
        'TileHorizontalToolStripMenuItem
        '
        Me.TileHorizontalToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.TileHorizontalToolStripMenuItem.Name = "TileHorizontalToolStripMenuItem"
        Me.TileHorizontalToolStripMenuItem.Size = New System.Drawing.Size(151, 22)
        Me.TileHorizontalToolStripMenuItem.Text = "Tile &Horizontal"
        '
        'CloseAllToolStripMenuItem
        '
        Me.CloseAllToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.CloseAllToolStripMenuItem.Name = "CloseAllToolStripMenuItem"
        Me.CloseAllToolStripMenuItem.Size = New System.Drawing.Size(151, 22)
        Me.CloseAllToolStripMenuItem.Text = "C&lose All"
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Black
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(1042, 632)
        Me.Controls.Add(Me.MenuStrip)
        Me.Controls.Add(Me.StatusStrip)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ForeColor = System.Drawing.Color.Black
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.IsMdiContainer = True
        Me.Name = "frmMain"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Aadarxa Bilingual Dictionary, Version 3.0"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.StatusStrip.ResumeLayout(False)
        Me.StatusStrip.PerformLayout()
        CType(Me.FileSystemWatcher1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MenuStrip.ResumeLayout(False)
        Me.MenuStrip.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolTip As System.Windows.Forms.ToolTip
    Friend WithEvents ToolStripStatusLabel As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents StatusStrip As System.Windows.Forms.StatusStrip
    Friend WithEvents FileSystemWatcher1 As System.IO.FileSystemWatcher
    Friend WithEvents MenuStrip As System.Windows.Forms.MenuStrip
    Friend WithEvents DictionaryToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OpenWordSearch As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents FakaraJojanaToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OpenFakara As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PictureToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OpenPicture As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents WrongCorrectWordsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OpenToolStripMenuItem3 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents NameWordToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents NamingToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents GrammarToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents GrammerToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AboutUsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AboutUsToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EditorialToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ContactUs As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents UsersGuideToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents HelpToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ActvationToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ActivateToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ReferenceToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PersonalToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AcknowToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CascadeToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TileVerticalToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TileHorizontalToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CloseAllToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents extrawords As System.Windows.Forms.ToolStripMenuItem

End Class
