<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Main_window
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
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.DeveloperModeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CreateAuditoriumToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CreatePoliciesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DesignAuditoriumToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ClientToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CreateMoviesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TaxInsertionToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.HelpToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GuidehowToUseThisSoftwareToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.MenuStrip1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.BackColor = System.Drawing.Color.DimGray
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.DeveloperModeToolStripMenuItem, Me.ClientToolStripMenuItem, Me.HelpToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(1049, 24)
        Me.MenuStrip1.TabIndex = 0
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'DeveloperModeToolStripMenuItem
        '
        Me.DeveloperModeToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CreateAuditoriumToolStripMenuItem, Me.CreatePoliciesToolStripMenuItem, Me.DesignAuditoriumToolStripMenuItem})
        Me.DeveloperModeToolStripMenuItem.Name = "DeveloperModeToolStripMenuItem"
        Me.DeveloperModeToolStripMenuItem.Size = New System.Drawing.Size(106, 20)
        Me.DeveloperModeToolStripMenuItem.Text = "Developer Mode"
        '
        'CreateAuditoriumToolStripMenuItem
        '
        Me.CreateAuditoriumToolStripMenuItem.Name = "CreateAuditoriumToolStripMenuItem"
        Me.CreateAuditoriumToolStripMenuItem.Size = New System.Drawing.Size(174, 22)
        Me.CreateAuditoriumToolStripMenuItem.Text = "Create Auditorium"
        '
        'CreatePoliciesToolStripMenuItem
        '
        Me.CreatePoliciesToolStripMenuItem.Name = "CreatePoliciesToolStripMenuItem"
        Me.CreatePoliciesToolStripMenuItem.Size = New System.Drawing.Size(174, 22)
        Me.CreatePoliciesToolStripMenuItem.Text = "Create policies"
        '
        'DesignAuditoriumToolStripMenuItem
        '
        Me.DesignAuditoriumToolStripMenuItem.Name = "DesignAuditoriumToolStripMenuItem"
        Me.DesignAuditoriumToolStripMenuItem.Size = New System.Drawing.Size(174, 22)
        Me.DesignAuditoriumToolStripMenuItem.Text = "Design Auditorium"
        '
        'ClientToolStripMenuItem
        '
        Me.ClientToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CreateMoviesToolStripMenuItem, Me.TaxInsertionToolStripMenuItem})
        Me.ClientToolStripMenuItem.Name = "ClientToolStripMenuItem"
        Me.ClientToolStripMenuItem.Size = New System.Drawing.Size(84, 20)
        Me.ClientToolStripMenuItem.Text = "Client Mode"
        '
        'CreateMoviesToolStripMenuItem
        '
        Me.CreateMoviesToolStripMenuItem.Name = "CreateMoviesToolStripMenuItem"
        Me.CreateMoviesToolStripMenuItem.Size = New System.Drawing.Size(191, 22)
        Me.CreateMoviesToolStripMenuItem.Text = "Create/update Movies"
        '
        'TaxInsertionToolStripMenuItem
        '
        Me.TaxInsertionToolStripMenuItem.Name = "TaxInsertionToolStripMenuItem"
        Me.TaxInsertionToolStripMenuItem.Size = New System.Drawing.Size(191, 22)
        Me.TaxInsertionToolStripMenuItem.Text = "Tax insertion"
        '
        'HelpToolStripMenuItem
        '
        Me.HelpToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.GuidehowToUseThisSoftwareToolStripMenuItem})
        Me.HelpToolStripMenuItem.Name = "HelpToolStripMenuItem"
        Me.HelpToolStripMenuItem.Size = New System.Drawing.Size(44, 20)
        Me.HelpToolStripMenuItem.Text = "Help"
        '
        'GuidehowToUseThisSoftwareToolStripMenuItem
        '
        Me.GuidehowToUseThisSoftwareToolStripMenuItem.Name = "GuidehowToUseThisSoftwareToolStripMenuItem"
        Me.GuidehowToUseThisSoftwareToolStripMenuItem.Size = New System.Drawing.Size(241, 22)
        Me.GuidehowToUseThisSoftwareToolStripMenuItem.Text = "Guide(how to use this software)"
        '
        'ComboBox1
        '
        Me.ComboBox1.DisplayMember = "1"
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Location = New System.Drawing.Point(899, 74)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(121, 21)
        Me.ComboBox1.TabIndex = 2
        Me.ComboBox1.ValueMember = "4"
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(900, 101)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(120, 23)
        Me.Button2.TabIndex = 4
        Me.Button2.Text = "Clear booking "
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(901, 130)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(119, 23)
        Me.Button3.TabIndex = 5
        Me.Button3.Text = "Clear all Movies"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(28, 135)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(208, 13)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "No movie added,create movies and shows"
        Me.Label1.Visible = False
        '
        'PictureBox1
        '
        Me.PictureBox1.Location = New System.Drawing.Point(445, 27)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(133, 43)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 7
        Me.PictureBox1.TabStop = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(745, 382)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(112, 13)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "Software designed by:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Myriad Pro Cond", 12.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.DarkOrange
        Me.Label3.Location = New System.Drawing.Point(854, 382)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(122, 19)
        Me.Label3.TabIndex = 9
        Me.Label3.Text = "SARANSH KHOBRAGADE"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(897, 57)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(113, 13)
        Me.Label4.TabIndex = 10
        Me.Label4.Text = "Select day for booking"
        '
        'Main_window
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Black
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.ClientSize = New System.Drawing.Size(1049, 411)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.ComboBox1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.ForeColor = System.Drawing.Color.Tomato
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "Main_window"
        Me.Text = "MOVIE TICKET BOOKING "
        Me.TransparencyKey = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents DeveloperModeToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ClientToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CreateAuditoriumToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CreatePoliciesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DesignAuditoriumToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CreateMoviesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
    Friend WithEvents TaxInsertionToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents HelpToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents GuidehowToUseThisSoftwareToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
End Class
