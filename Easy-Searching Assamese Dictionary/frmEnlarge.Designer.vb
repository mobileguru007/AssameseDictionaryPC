<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmEnlarge
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmEnlarge))
        Me.imgRetrieve = New System.Windows.Forms.PictureBox
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer
        Me.lvPicName = New System.Windows.Forms.ListBox
        Me.SplitContainer2 = New System.Windows.Forms.SplitContainer
        Me.lblPicName = New System.Windows.Forms.Label
        Me.btnSavePicture = New System.Windows.Forms.Button
        Me.btnClose = New System.Windows.Forms.Button
        Me.savePicture = New System.Windows.Forms.SaveFileDialog
        Me.Button1 = New System.Windows.Forms.Button
        Me.Button2 = New System.Windows.Forms.Button
        CType(Me.imgRetrieve, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.SplitContainer2.Panel1.SuspendLayout()
        Me.SplitContainer2.Panel2.SuspendLayout()
        Me.SplitContainer2.SuspendLayout()
        Me.SuspendLayout()
        '
        'imgRetrieve
        '
        Me.imgRetrieve.Dock = System.Windows.Forms.DockStyle.Fill
        Me.imgRetrieve.Location = New System.Drawing.Point(0, 0)
        Me.imgRetrieve.Margin = New System.Windows.Forms.Padding(6)
        Me.imgRetrieve.Name = "imgRetrieve"
        Me.imgRetrieve.Size = New System.Drawing.Size(1220, 746)
        Me.imgRetrieve.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.imgRetrieve.TabIndex = 0
        Me.imgRetrieve.TabStop = False
        '
        'SplitContainer1
        '
        Me.SplitContainer1.BackColor = System.Drawing.Color.LightGray
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer1.Margin = New System.Windows.Forms.Padding(6)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.BackColor = System.Drawing.Color.DarkGray
        Me.SplitContainer1.Panel1.Controls.Add(Me.imgRetrieve)
        Me.SplitContainer1.Panel1.Controls.Add(Me.lvPicName)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.BackColor = System.Drawing.Color.DarkGray
        Me.SplitContainer1.Panel2.Controls.Add(Me.SplitContainer2)
        Me.SplitContainer1.Size = New System.Drawing.Size(1366, 746)
        Me.SplitContainer1.SplitterDistance = 1220
        Me.SplitContainer1.SplitterWidth = 2
        Me.SplitContainer1.TabIndex = 0
        '
        'lvPicName
        '
        Me.lvPicName.Font = New System.Drawing.Font("Times New Roman", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lvPicName.FormattingEnabled = True
        Me.lvPicName.ItemHeight = 27
        Me.lvPicName.Location = New System.Drawing.Point(1101, 577)
        Me.lvPicName.Name = "lvPicName"
        Me.lvPicName.Size = New System.Drawing.Size(112, 166)
        Me.lvPicName.TabIndex = 0
        '
        'SplitContainer2
        '
        Me.SplitContainer2.BackColor = System.Drawing.Color.Thistle
        Me.SplitContainer2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer2.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer2.Margin = New System.Windows.Forms.Padding(6)
        Me.SplitContainer2.Name = "SplitContainer2"
        Me.SplitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer2.Panel1
        '
        Me.SplitContainer2.Panel1.BackColor = System.Drawing.Color.Thistle
        Me.SplitContainer2.Panel1.Controls.Add(Me.lblPicName)
        Me.SplitContainer2.Panel1.Controls.Add(Me.btnSavePicture)
        '
        'SplitContainer2.Panel2
        '
        Me.SplitContainer2.Panel2.BackColor = System.Drawing.Color.Thistle
        Me.SplitContainer2.Panel2.Controls.Add(Me.Button2)
        Me.SplitContainer2.Panel2.Controls.Add(Me.Button1)
        Me.SplitContainer2.Panel2.Controls.Add(Me.btnClose)
        Me.SplitContainer2.Size = New System.Drawing.Size(144, 746)
        Me.SplitContainer2.SplitterDistance = 373
        Me.SplitContainer2.SplitterWidth = 8
        Me.SplitContainer2.TabIndex = 2
        '
        'lblPicName
        '
        Me.lblPicName.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.lblPicName.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblPicName.Font = New System.Drawing.Font("Geetanjali", 15.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPicName.Location = New System.Drawing.Point(0, 0)
        Me.lblPicName.Name = "lblPicName"
        Me.lblPicName.Size = New System.Drawing.Size(144, 30)
        Me.lblPicName.TabIndex = 3
        Me.lblPicName.Text = "ll"
        '
        'btnSavePicture
        '
        Me.btnSavePicture.BackColor = System.Drawing.SystemColors.InactiveCaptionText
        Me.btnSavePicture.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.btnSavePicture.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnSavePicture.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSavePicture.ForeColor = System.Drawing.Color.Maroon
        Me.btnSavePicture.Location = New System.Drawing.Point(0, 340)
        Me.btnSavePicture.Margin = New System.Windows.Forms.Padding(6)
        Me.btnSavePicture.Name = "btnSavePicture"
        Me.btnSavePicture.Size = New System.Drawing.Size(144, 33)
        Me.btnSavePicture.TabIndex = 2
        Me.btnSavePicture.Text = "&Save Picture"
        Me.btnSavePicture.UseVisualStyleBackColor = False
        '
        'btnClose
        '
        Me.btnClose.BackColor = System.Drawing.SystemColors.InactiveCaptionText
        Me.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnClose.Dock = System.Windows.Forms.DockStyle.Top
        Me.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnClose.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClose.ForeColor = System.Drawing.Color.Maroon
        Me.btnClose.Location = New System.Drawing.Point(0, 0)
        Me.btnClose.Margin = New System.Windows.Forms.Padding(6)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(144, 33)
        Me.btnClose.TabIndex = 3
        Me.btnClose.Text = "&Close"
        Me.btnClose.UseVisualStyleBackColor = False
        '
        'Button1
        '
        Me.Button1.Font = New System.Drawing.Font("Times New Roman", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Location = New System.Drawing.Point(79, 42)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(65, 33)
        Me.Button1.TabIndex = 4
        Me.Button1.Text = ">>"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Font = New System.Drawing.Font("Times New Roman", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.Location = New System.Drawing.Point(1, 42)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(65, 33)
        Me.Button2.TabIndex = 5
        Me.Button2.Text = "<<"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'frmEnlarge
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(11.0!, 27.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnClose
        Me.ClientSize = New System.Drawing.Size(1366, 746)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Font = New System.Drawing.Font("Geetanjali", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(6)
        Me.Name = "frmEnlarge"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Picture"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.imgRetrieve, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.ResumeLayout(False)
        Me.SplitContainer2.Panel1.ResumeLayout(False)
        Me.SplitContainer2.Panel2.ResumeLayout(False)
        Me.SplitContainer2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents imgRetrieve As System.Windows.Forms.PictureBox
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents savePicture As System.Windows.Forms.SaveFileDialog
    Friend WithEvents SplitContainer2 As System.Windows.Forms.SplitContainer
    Friend WithEvents lblPicName As System.Windows.Forms.Label
    Friend WithEvents lvPicName As System.Windows.Forms.ListBox
    Friend WithEvents btnSavePicture As System.Windows.Forms.Button
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
End Class
