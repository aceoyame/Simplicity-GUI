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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMain))
        Me.pbMyriad = New System.Windows.Forms.PictureBox()
        Me.gbWallet = New System.Windows.Forms.GroupBox()
        Me.rbCustomAddress = New System.Windows.Forms.RadioButton()
        Me.rbUseElectrum = New System.Windows.Forms.RadioButton()
        Me.txtAddress = New System.Windows.Forms.TextBox()
        Me.lblAddress = New System.Windows.Forms.Label()
        Me.btnWalletSetup = New System.Windows.Forms.Button()
        Me.btnStart = New System.Windows.Forms.Button()
        Me.btnStop = New System.Windows.Forms.Button()
        Me.gbMethod = New System.Windows.Forms.GroupBox()
        Me.rbScrypt = New System.Windows.Forms.RadioButton()
        Me.rbGroestl = New System.Windows.Forms.RadioButton()
        Me.rbQubit = New System.Windows.Forms.RadioButton()
        Me.rbSkein = New System.Windows.Forms.RadioButton()
        Me.llWebsite = New System.Windows.Forms.LinkLabel()
        Me.gbStatus = New System.Windows.Forms.GroupBox()
        Me.ProgressBar = New System.Windows.Forms.ProgressBar()
        Me.txtOutput = New System.Windows.Forms.TextBox()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.rbUseBirdsPool = New System.Windows.Forms.RadioButton()
        Me.rbCustomPool = New System.Windows.Forms.RadioButton()
        Me.txtPool = New System.Windows.Forms.TextBox()
        Me.gbMiningPool = New System.Windows.Forms.GroupBox()
        Me.lblCustomAddress = New System.Windows.Forms.Label()
        Me.txtPassword = New System.Windows.Forms.TextBox()
        Me.lblPassword = New System.Windows.Forms.Label()
        Me.lblUsername = New System.Windows.Forms.Label()
        Me.txtUsername = New System.Windows.Forms.TextBox()
        Me.NotifyIcon1 = New System.Windows.Forms.NotifyIcon(Me.components)
        CType(Me.pbMyriad, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbWallet.SuspendLayout()
        Me.gbMethod.SuspendLayout()
        Me.gbStatus.SuspendLayout()
        Me.gbMiningPool.SuspendLayout()
        Me.SuspendLayout()
        '
        'pbMyriad
        '
        Me.pbMyriad.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pbMyriad.Image = Global.Simplicity.My.Resources.Resources.header_logo2
        Me.pbMyriad.Location = New System.Drawing.Point(176, 1)
        Me.pbMyriad.Name = "pbMyriad"
        Me.pbMyriad.Size = New System.Drawing.Size(313, 91)
        Me.pbMyriad.TabIndex = 0
        Me.pbMyriad.TabStop = False
        '
        'gbWallet
        '
        Me.gbWallet.BackColor = System.Drawing.Color.WhiteSmoke
        Me.gbWallet.Controls.Add(Me.rbCustomAddress)
        Me.gbWallet.Controls.Add(Me.rbUseElectrum)
        Me.gbWallet.Controls.Add(Me.txtAddress)
        Me.gbWallet.Controls.Add(Me.lblAddress)
        Me.gbWallet.Controls.Add(Me.btnWalletSetup)
        Me.gbWallet.Font = New System.Drawing.Font("Georgia", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbWallet.Location = New System.Drawing.Point(24, 111)
        Me.gbWallet.Name = "gbWallet"
        Me.gbWallet.Size = New System.Drawing.Size(283, 134)
        Me.gbWallet.TabIndex = 1
        Me.gbWallet.TabStop = False
        Me.gbWallet.Text = "Wallet Address"
        '
        'rbCustomAddress
        '
        Me.rbCustomAddress.AutoSize = True
        Me.rbCustomAddress.Location = New System.Drawing.Point(12, 53)
        Me.rbCustomAddress.Name = "rbCustomAddress"
        Me.rbCustomAddress.Size = New System.Drawing.Size(127, 20)
        Me.rbCustomAddress.TabIndex = 11
        Me.rbCustomAddress.TabStop = True
        Me.rbCustomAddress.Text = "Custom Address"
        Me.rbCustomAddress.UseVisualStyleBackColor = True
        '
        'rbUseElectrum
        '
        Me.rbUseElectrum.AutoSize = True
        Me.rbUseElectrum.Location = New System.Drawing.Point(12, 23)
        Me.rbUseElectrum.Name = "rbUseElectrum"
        Me.rbUseElectrum.Size = New System.Drawing.Size(137, 20)
        Me.rbUseElectrum.TabIndex = 10
        Me.rbUseElectrum.TabStop = True
        Me.rbUseElectrum.Text = "Electrum Address"
        Me.rbUseElectrum.UseVisualStyleBackColor = True
        '
        'txtAddress
        '
        Me.txtAddress.Font = New System.Drawing.Font("Georgia", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAddress.Location = New System.Drawing.Point(9, 104)
        Me.txtAddress.Name = "txtAddress"
        Me.txtAddress.Size = New System.Drawing.Size(268, 20)
        Me.txtAddress.TabIndex = 9
        '
        'lblAddress
        '
        Me.lblAddress.AutoSize = True
        Me.lblAddress.Location = New System.Drawing.Point(9, 80)
        Me.lblAddress.Name = "lblAddress"
        Me.lblAddress.Size = New System.Drawing.Size(118, 16)
        Me.lblAddress.TabIndex = 8
        Me.lblAddress.Text = "Selected Address:"
        '
        'btnWalletSetup
        '
        Me.btnWalletSetup.Location = New System.Drawing.Point(152, 20)
        Me.btnWalletSetup.Name = "btnWalletSetup"
        Me.btnWalletSetup.Size = New System.Drawing.Size(122, 23)
        Me.btnWalletSetup.TabIndex = 8
        Me.btnWalletSetup.Text = "Setup Electrum"
        Me.btnWalletSetup.UseVisualStyleBackColor = True
        '
        'btnStart
        '
        Me.btnStart.Font = New System.Drawing.Font("Georgia", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnStart.Location = New System.Drawing.Point(215, 467)
        Me.btnStart.Name = "btnStart"
        Me.btnStart.Size = New System.Drawing.Size(114, 30)
        Me.btnStart.TabIndex = 2
        Me.btnStart.Text = "Start Mining"
        Me.btnStart.UseVisualStyleBackColor = True
        '
        'btnStop
        '
        Me.btnStop.Enabled = False
        Me.btnStop.Font = New System.Drawing.Font("Georgia", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnStop.Location = New System.Drawing.Point(338, 467)
        Me.btnStop.Name = "btnStop"
        Me.btnStop.Size = New System.Drawing.Size(114, 30)
        Me.btnStop.TabIndex = 3
        Me.btnStop.Text = "Stop Mining"
        Me.btnStop.UseVisualStyleBackColor = True
        '
        'gbMethod
        '
        Me.gbMethod.Controls.Add(Me.rbScrypt)
        Me.gbMethod.Controls.Add(Me.rbGroestl)
        Me.gbMethod.Controls.Add(Me.rbQubit)
        Me.gbMethod.Controls.Add(Me.rbSkein)
        Me.gbMethod.Font = New System.Drawing.Font("Georgia", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbMethod.Location = New System.Drawing.Point(323, 111)
        Me.gbMethod.Name = "gbMethod"
        Me.gbMethod.Size = New System.Drawing.Size(328, 134)
        Me.gbMethod.TabIndex = 4
        Me.gbMethod.TabStop = False
        Me.gbMethod.Text = "Mining Method"
        '
        'rbScrypt
        '
        Me.rbScrypt.AutoSize = True
        Me.rbScrypt.Location = New System.Drawing.Point(16, 105)
        Me.rbScrypt.Name = "rbScrypt"
        Me.rbScrypt.Size = New System.Drawing.Size(302, 20)
        Me.rbScrypt.TabIndex = 9
        Me.rbScrypt.TabStop = True
        Me.rbScrypt.Text = "Scrypt (Not Recommended for Profitability!)"
        Me.rbScrypt.UseVisualStyleBackColor = True
        '
        'rbGroestl
        '
        Me.rbGroestl.AutoSize = True
        Me.rbGroestl.Location = New System.Drawing.Point(15, 75)
        Me.rbGroestl.Name = "rbGroestl"
        Me.rbGroestl.Size = New System.Drawing.Size(280, 20)
        Me.rbGroestl.TabIndex = 8
        Me.rbGroestl.TabStop = True
        Me.rbGroestl.Text = "Groestl (Recommended for Nvidia Cards)"
        Me.rbGroestl.UseVisualStyleBackColor = True
        '
        'rbQubit
        '
        Me.rbQubit.AutoSize = True
        Me.rbQubit.Location = New System.Drawing.Point(15, 48)
        Me.rbQubit.Name = "rbQubit"
        Me.rbQubit.Size = New System.Drawing.Size(246, 20)
        Me.rbQubit.TabIndex = 7
        Me.rbQubit.TabStop = True
        Me.rbQubit.Text = "Qubit (Best for CPU and AMD cards)"
        Me.rbQubit.UseVisualStyleBackColor = True
        '
        'rbSkein
        '
        Me.rbSkein.AutoSize = True
        Me.rbSkein.Location = New System.Drawing.Point(16, 21)
        Me.rbSkein.Name = "rbSkein"
        Me.rbSkein.Size = New System.Drawing.Size(245, 20)
        Me.rbSkein.TabIndex = 6
        Me.rbSkein.TabStop = True
        Me.rbSkein.Text = "Skein (Universal\Highest Hashrate)"
        Me.rbSkein.UseVisualStyleBackColor = True
        '
        'llWebsite
        '
        Me.llWebsite.ActiveLinkColor = System.Drawing.Color.Black
        Me.llWebsite.AutoSize = True
        Me.llWebsite.Location = New System.Drawing.Point(577, 476)
        Me.llWebsite.Name = "llWebsite"
        Me.llWebsite.Size = New System.Drawing.Size(79, 13)
        Me.llWebsite.TabIndex = 5
        Me.llWebsite.TabStop = True
        Me.llWebsite.Text = "Myriad Platform"
        '
        'gbStatus
        '
        Me.gbStatus.Controls.Add(Me.ProgressBar)
        Me.gbStatus.Controls.Add(Me.txtOutput)
        Me.gbStatus.Font = New System.Drawing.Font("Georgia", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbStatus.Location = New System.Drawing.Point(23, 362)
        Me.gbStatus.Name = "gbStatus"
        Me.gbStatus.Size = New System.Drawing.Size(628, 91)
        Me.gbStatus.TabIndex = 7
        Me.gbStatus.TabStop = False
        Me.gbStatus.Text = "Mining Status"
        '
        'ProgressBar
        '
        Me.ProgressBar.ForeColor = System.Drawing.Color.RoyalBlue
        Me.ProgressBar.Location = New System.Drawing.Point(13, 73)
        Me.ProgressBar.MarqueeAnimationSpeed = 20
        Me.ProgressBar.Name = "ProgressBar"
        Me.ProgressBar.Size = New System.Drawing.Size(603, 10)
        Me.ProgressBar.Step = 100
        Me.ProgressBar.Style = System.Windows.Forms.ProgressBarStyle.Marquee
        Me.ProgressBar.TabIndex = 1
        Me.ProgressBar.Visible = False
        '
        'txtOutput
        '
        Me.txtOutput.Font = New System.Drawing.Font("Georgia", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtOutput.Location = New System.Drawing.Point(13, 18)
        Me.txtOutput.Multiline = True
        Me.txtOutput.Name = "txtOutput"
        Me.txtOutput.Size = New System.Drawing.Size(603, 47)
        Me.txtOutput.TabIndex = 0
        '
        'Timer1
        '
        Me.Timer1.Interval = 500
        '
        'rbUseBirdsPool
        '
        Me.rbUseBirdsPool.AutoSize = True
        Me.rbUseBirdsPool.Font = New System.Drawing.Font("Georgia", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbUseBirdsPool.Location = New System.Drawing.Point(9, 21)
        Me.rbUseBirdsPool.Name = "rbUseBirdsPool"
        Me.rbUseBirdsPool.Size = New System.Drawing.Size(168, 20)
        Me.rbUseBirdsPool.TabIndex = 8
        Me.rbUseBirdsPool.TabStop = True
        Me.rbUseBirdsPool.Text = "Use BirdsPool (default)"
        Me.rbUseBirdsPool.UseVisualStyleBackColor = True
        '
        'rbCustomPool
        '
        Me.rbCustomPool.AutoSize = True
        Me.rbCustomPool.Font = New System.Drawing.Font("Georgia", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbCustomPool.Location = New System.Drawing.Point(10, 46)
        Me.rbCustomPool.Name = "rbCustomPool"
        Me.rbCustomPool.Size = New System.Drawing.Size(104, 20)
        Me.rbCustomPool.TabIndex = 9
        Me.rbCustomPool.TabStop = True
        Me.rbCustomPool.Text = "Custom Pool"
        Me.rbCustomPool.UseVisualStyleBackColor = True
        '
        'txtPool
        '
        Me.txtPool.Font = New System.Drawing.Font("Georgia", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPool.Location = New System.Drawing.Point(201, 44)
        Me.txtPool.Name = "txtPool"
        Me.txtPool.Size = New System.Drawing.Size(288, 20)
        Me.txtPool.TabIndex = 10
        '
        'gbMiningPool
        '
        Me.gbMiningPool.Controls.Add(Me.lblCustomAddress)
        Me.gbMiningPool.Controls.Add(Me.txtPassword)
        Me.gbMiningPool.Controls.Add(Me.lblPassword)
        Me.gbMiningPool.Controls.Add(Me.lblUsername)
        Me.gbMiningPool.Controls.Add(Me.txtUsername)
        Me.gbMiningPool.Controls.Add(Me.txtPool)
        Me.gbMiningPool.Controls.Add(Me.rbCustomPool)
        Me.gbMiningPool.Controls.Add(Me.rbUseBirdsPool)
        Me.gbMiningPool.Font = New System.Drawing.Font("Georgia", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbMiningPool.Location = New System.Drawing.Point(23, 251)
        Me.gbMiningPool.Name = "gbMiningPool"
        Me.gbMiningPool.Size = New System.Drawing.Size(627, 105)
        Me.gbMiningPool.TabIndex = 2
        Me.gbMiningPool.TabStop = False
        Me.gbMiningPool.Text = "Mining Pool"
        '
        'lblCustomAddress
        '
        Me.lblCustomAddress.AutoSize = True
        Me.lblCustomAddress.Location = New System.Drawing.Point(132, 48)
        Me.lblCustomAddress.Name = "lblCustomAddress"
        Me.lblCustomAddress.Size = New System.Drawing.Size(63, 16)
        Me.lblCustomAddress.TabIndex = 13
        Me.lblCustomAddress.Text = "Address:"
        '
        'txtPassword
        '
        Me.txtPassword.Location = New System.Drawing.Point(389, 70)
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtPassword.Size = New System.Drawing.Size(100, 22)
        Me.txtPassword.TabIndex = 8
        '
        'lblPassword
        '
        Me.lblPassword.AutoSize = True
        Me.lblPassword.Location = New System.Drawing.Point(314, 73)
        Me.lblPassword.Name = "lblPassword"
        Me.lblPassword.Size = New System.Drawing.Size(71, 16)
        Me.lblPassword.TabIndex = 12
        Me.lblPassword.Text = "Password:"
        '
        'lblUsername
        '
        Me.lblUsername.AutoSize = True
        Me.lblUsername.Location = New System.Drawing.Point(121, 73)
        Me.lblUsername.Name = "lblUsername"
        Me.lblUsername.Size = New System.Drawing.Size(75, 16)
        Me.lblUsername.TabIndex = 11
        Me.lblUsername.Text = "Username:"
        '
        'txtUsername
        '
        Me.txtUsername.Location = New System.Drawing.Point(201, 70)
        Me.txtUsername.Name = "txtUsername"
        Me.txtUsername.Size = New System.Drawing.Size(100, 22)
        Me.txtUsername.TabIndex = 8
        '
        'NotifyIcon1
        '
        Me.NotifyIcon1.Icon = CType(resources.GetObject("NotifyIcon1.Icon"), System.Drawing.Icon)
        Me.NotifyIcon1.Text = "Simplicity Myriad Miner"
        Me.NotifyIcon1.Visible = True
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.BackColor = System.Drawing.Color.WhiteSmoke
        Me.ClientSize = New System.Drawing.Size(672, 508)
        Me.Controls.Add(Me.gbMiningPool)
        Me.Controls.Add(Me.gbStatus)
        Me.Controls.Add(Me.llWebsite)
        Me.Controls.Add(Me.gbMethod)
        Me.Controls.Add(Me.btnStop)
        Me.Controls.Add(Me.btnStart)
        Me.Controls.Add(Me.gbWallet)
        Me.Controls.Add(Me.pbMyriad)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmMain"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Simplicity Myriad Miner"
        CType(Me.pbMyriad, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbWallet.ResumeLayout(False)
        Me.gbWallet.PerformLayout()
        Me.gbMethod.ResumeLayout(False)
        Me.gbMethod.PerformLayout()
        Me.gbStatus.ResumeLayout(False)
        Me.gbStatus.PerformLayout()
        Me.gbMiningPool.ResumeLayout(False)
        Me.gbMiningPool.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents pbMyriad As System.Windows.Forms.PictureBox
    Friend WithEvents gbWallet As System.Windows.Forms.GroupBox
    Friend WithEvents btnStart As System.Windows.Forms.Button
    Friend WithEvents btnStop As System.Windows.Forms.Button
    Friend WithEvents gbMethod As System.Windows.Forms.GroupBox
    Friend WithEvents llWebsite As System.Windows.Forms.LinkLabel
    Friend WithEvents rbScrypt As System.Windows.Forms.RadioButton
    Friend WithEvents rbGroestl As System.Windows.Forms.RadioButton
    Friend WithEvents rbQubit As System.Windows.Forms.RadioButton
    Friend WithEvents rbSkein As System.Windows.Forms.RadioButton
    Friend WithEvents gbStatus As System.Windows.Forms.GroupBox
    Friend WithEvents txtOutput As System.Windows.Forms.TextBox
    Friend WithEvents txtAddress As System.Windows.Forms.TextBox
    Friend WithEvents lblAddress As System.Windows.Forms.Label
    Friend WithEvents btnWalletSetup As System.Windows.Forms.Button
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents ProgressBar As System.Windows.Forms.ProgressBar
    Friend WithEvents rbCustomAddress As System.Windows.Forms.RadioButton
    Friend WithEvents rbUseElectrum As System.Windows.Forms.RadioButton
    Friend WithEvents rbUseBirdsPool As System.Windows.Forms.RadioButton
    Friend WithEvents rbCustomPool As System.Windows.Forms.RadioButton
    Friend WithEvents txtPool As System.Windows.Forms.TextBox
    Friend WithEvents gbMiningPool As System.Windows.Forms.GroupBox
    Friend WithEvents lblCustomAddress As System.Windows.Forms.Label
    Friend WithEvents txtPassword As System.Windows.Forms.TextBox
    Friend WithEvents lblPassword As System.Windows.Forms.Label
    Friend WithEvents lblUsername As System.Windows.Forms.Label
    Friend WithEvents txtUsername As System.Windows.Forms.TextBox
    Friend WithEvents NotifyIcon1 As System.Windows.Forms.NotifyIcon

End Class
