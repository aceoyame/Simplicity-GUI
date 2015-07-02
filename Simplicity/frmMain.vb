﻿Imports System.Environment
Imports System.IO
Imports System.Management

Public Class frmMain

    Private strModule As String = "frmMain: "
    Private _newProcess As Process
    Private _SelectedMiningMethod As enumMiningMethod
    Private Const PROGRAM_TITLE As String = "Simplicity Myriad Miner"

#Region " Events "

    Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim strLocation As String = "frmMain_Load"
        Try
            MaximizeBox = False
            rbSkein.Checked = True

            'get registry setting from last time.  Are we using a cutom address or the electrum wallet
            Dim strRegAddress As String = GetSetting("SimplicityMiner", "Settings", "CustomAddress")
            Dim strRegUsername As String = GetSetting("SimplicityMiner", "Settings", "CustomUsername")
            Dim strRegPassword As String = GetSetting("SimplicityMiner", "Settings", "CustomPassword")
            If strRegAddress.Length > 0 Then 'saved a custom address previously
                rbCustomAddress.Checked = True
                txtAddress.Text = strRegAddress

            Else
                rbUseElectrum.Checked = True
            End If

            Dim strRegPool As String = GetSetting("SimplicityMiner", "Settings", "CustomMiningPool")
            If strRegPool.Length > 0 Then
                rbCustomPool.Checked = True
                txtPool.Text = strRegPool
                txtUsername.Text = strRegUsername
                txtPassword.Text = strRegPassword
            Else
                rbUseBirdsPool.Checked = True
            End If

        Catch ex As Exception
            BuildErrorMessage(strModule, strLocation, ex.Message)
        End Try
    End Sub

    Private Sub frmMain_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        KillMiner()
    End Sub

    Private Sub frmMain_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        Dim strLocation As String = "frmMain_Resize"
        Try
            If Me.WindowState = FormWindowState.Minimized Then
                NotifyIcon1.Visible = True
                Me.Hide()
                NotifyIcon1.BalloonTipText = PROGRAM_TITLE
                NotifyIcon1.ShowBalloonTip(500)
            End If

        Catch ex As Exception
            BuildErrorMessage(strModule, strLocation, ex.Message)
        End Try
    End Sub

    Private Sub NotifyIcon1_Click(sender As Object, e As EventArgs) Handles NotifyIcon1.DoubleClick, NotifyIcon1.Click
        Dim strLocation As String = "NotifyIcon1_Click"
        Try
            Me.Show()
            Me.WindowState = FormWindowState.Normal
            NotifyIcon1.Visible = False
        Catch ex As Exception
            BuildErrorMessage(strModule, strLocation, ex.Message)
        End Try
    End Sub

    Private Sub llWebsite_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles llWebsite.LinkClicked
        Dim strLocation As String = "llWebsite_LinkClicked"
        Try
            System.Diagnostics.Process.Start("http://myriadplatform.org/mining-setup/")
        Catch ex As Exception
            BuildErrorMessage(strModule, strLocation, ex.Message)
        End Try
    End Sub

    Private Sub btn_Click(sender As Object, e As EventArgs) Handles btnStart.Click, btnStop.Click
        Dim strLocation As String = "btn_Click"
        Try
            Dim btn As Button = CType(sender, Button)
            Select Case btn.Name
                Case "btnStart"
                    If rbCustomPool.Checked And txtPool.Text.Length < 1 Then
                        MessageBox.Show("You must enter a custom pool address to continue.", PROGRAM_TITLE, MessageBoxButtons.OK, MessageBoxIcon.Stop)
                        Exit Sub
                    End If
                    btnStart.Enabled = False
                    btnStop.Enabled = True
                    DisableEnableControls(False)
                    If rbCustomAddress.Checked Then
                        WriteToRegistry(enumRegistryValue.CustomAddress)
                    Else
                        If GetSetting("SimplicityMiner", "Settings", "CustomAddress").Length > 0 Then
                            DeleteSetting("SimplicityMiner", "Settings", "CustomAddress")
                        End If
                    End If

                    If rbCustomPool.Checked Then
                        WriteToRegistry(enumRegistryValue.CustomMiningPool)
                        WriteToRegistry(enumRegistryValue.CustomUsername)
                        WriteToRegistry(enumRegistryValue.CustomPassword)
                        WriteToRegistry(enumRegistryValue.CustomSelectedAlgorithm)
                    Else
                        If GetSetting("SimplicityMiner", "Settings", "CustomMiningPool").Length > 0 Then
                            DeleteSetting("SimplicityMiner", "Settings", "CustomMiningPool")
                            DeleteSetting("SimplicityMiner", "Settings", "CustomUsername")
                            DeleteSetting("SimplicityMiner", "Settings", "CustomPassword")
                            DeleteSetting("SimplicityMiner", "Settings", "CustomSelectedAlgorithm")
                        End If
                    End If
                    Dim Result As DialogResult = MessageBox.Show("Mine CPU?", PROGRAM_TITLE, MessageBoxButtons.YesNoCancel)
                    If Result = DialogResult.Cancel Then
                        Exit Sub
                    End If
                    txtOutput.Text &= vbCrLf & "Mining Started at " & Now

                    If rbSkein.Checked Then
                        Select Case Result
                            Case DialogResult.Yes 'Mine CPU
                                _SelectedMiningMethod = If(Is64BitOperatingSystem, enumMiningMethod.SkeinCPU64, enumMiningMethod.SkeinCPU32)

                            Case DialogResult.No 'Mine GPU
                                _SelectedMiningMethod = enumMiningMethod.SkeinGPU
                        End Select
                    End If

                    If rbQubit.Checked Then
                        Select Case Result
                            Case DialogResult.Yes 'Mine CPU
                                _SelectedMiningMethod = If(Is64BitOperatingSystem, enumMiningMethod.QubitCPU64, enumMiningMethod.QubitCPU32)

                            Case DialogResult.No 'Mine GPU
                                _SelectedMiningMethod = enumMiningMethod.QubitGPU
                        End Select
                    End If

                    If rbGroestl.Checked Then
                        Select Case Result
                            Case DialogResult.Yes 'Mine CPU
                                _SelectedMiningMethod = If(Is64BitOperatingSystem, enumMiningMethod.GroestlCPU64, enumMiningMethod.GroestlCPU32)

                            Case DialogResult.No 'Mine GPU
                                _SelectedMiningMethod = enumMiningMethod.GroestlGPU
                        End Select
                    End If

                    If rbScrypt.Checked Then
                        Select Case Result
                            Case DialogResult.Yes 'Mine CPU
                                _SelectedMiningMethod = If(Is64BitOperatingSystem, enumMiningMethod.ScryptCPU64, enumMiningMethod.ScryptCPU32)

                            Case DialogResult.No 'Mine GPU
                                _SelectedMiningMethod = enumMiningMethod.ScryptGPU
                        End Select
                    End If

                    WriteBatchFile()
                    StartMiningProcess()
                    Timer1.Start()
                    ProgressBar.Visible = True
                Case "btnStop"
                    btnStart.Enabled = True
                    btnStop.Enabled = False
                    txtOutput.Text &= vbCrLf & "Mining Stopped at " & Now
                    If _newProcess IsNot Nothing Then
                        _newProcess.Close()
                    End If

                    KillMiner()
                    Timer1.Stop()
                    ProgressBar.Visible = False
                    DisableEnableControls(True)
            End Select

        Catch ex As Exception
            BuildErrorMessage(strModule, strLocation, ex.Message)
        End Try
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Dim strLocation As String = "Timer1_Tick"
        Try
            UpdateOutputWindow()
            Timer1.Start()
        Catch ex As Exception
            BuildErrorMessage(strModule, strLocation, ex.Message)
        End Try
    End Sub

    Private Sub Address_CheckedChanged(sender As Object, e As EventArgs) Handles rbCustomAddress.CheckedChanged, rbUseElectrum.CheckedChanged
        Dim strLocation As String = "Address_CheckedChanged"
        Try
            If rbUseElectrum.Checked Then
                'check wallet is setup
                If IsWalletSetup Then
                    txtAddress.Text = WalletAddress
                    txtAddress.ReadOnly = True
                Else
                    MessageBox.Show("An Electrum wallet address does not exist yet.  Click setup wallet to create an address.", PROGRAM_TITLE, MessageBoxButtons.OK, MessageBoxIcon.Stop)
                End If
            End If

            If rbCustomAddress.Checked Then
                txtAddress.ReadOnly = False
                txtAddress.Text = GetSetting("SimplicityMiner", "Settings", "CustomAddress")
                txtUsername.Text = GetSetting("SimplicityMiner", "Settings", "CustomUsername")
                txtPassword.Text = GetSetting("SimplicityMiner", "Settings", "CustomPassword")

            End If
        Catch ex As Exception
            BuildErrorMessage(strModule, strLocation, ex.Message)
        End Try
    End Sub

    Private Sub Pool_CheckedChanged(sender As Object, e As EventArgs) Handles rbUseBirdsPool.CheckedChanged, rbCustomPool.CheckedChanged
        Dim strLocation As String = "Pool_CheckedChanged"
        Try
            If rbUseBirdsPool.Checked Then
                txtPool.Text = ""
                txtUsername.Text = ""
                txtPassword.Text = ""
                txtPool.ReadOnly = True
                txtUsername.ReadOnly = True
                txtPassword.ReadOnly = True
            Else
                txtPool.Text = GetSetting("SimplicityMiner", "Settings", "CustomMiningPool")
                txtUsername.Text = GetSetting("SimplicityMiner", "Settings", "CustomUsername")
                txtPassword.Text = GetSetting("SimplicityMiner", "Settings", "CustomPassword")
                Dim iCustomSelectedAlgorith As String = GetSetting("SimplicityMiner", "Settings", "CustomSelectedAlgorithm")
                If iCustomSelectedAlgorith.Length = 0 Then iCustomSelectedAlgorith = 0
                Select Case iCustomSelectedAlgorith
                    Case 0
                        rbSkein.Checked = True
                    Case 1
                        rbQubit.Checked = True
                    Case 2
                        rbGroestl.Checked = True
                    Case 3
                        rbScrypt.Checked = True
                End Select
                txtPool.ReadOnly = False
                txtUsername.ReadOnly = False
                txtPassword.ReadOnly = False
            End If
        Catch ex As Exception
            BuildErrorMessage(strModule, strLocation, ex.Message)
        End Try
    End Sub

    Private Sub btnWalletSetup_Click(sender As Object, e As EventArgs) Handles btnWalletSetup.Click
        Dim strLocation As String = "btnWalletSetup_Click"
        Try
            If Not My.Computer.FileSystem.FileExists(GetPathToElectrum) Then
                MessageBox.Show("Electrum was not found.", PROGRAM_TITLE, MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Else
                Process.Start(GetPathToElectrum)
            End If

        Catch ex As Exception
            BuildErrorMessage(strModule, strLocation, ex.Message)
        End Try
    End Sub

#End Region

#Region " Properties "

    Private ReadOnly Property WalletFolder As String
        Get
            Return GetFolderPath(SpecialFolder.ApplicationData) & "\Electrum-MYR"
        End Get
    End Property

    Private ReadOnly Property WalletAddress As String
        Get
            If rbUseElectrum.Checked Then
                Dim strFileName As String = GetFolderPath(SpecialFolder.ApplicationData) & "\Electrum-MYR\wallets\default_wallet"

                If System.IO.File.Exists(strFileName) = True Then

                    'Copied similar hack from vbs files to grab the first address in the file.
                    Dim objReader As New System.IO.StreamReader(strFileName)
                    Dim strWalletLine As String = objReader.ReadLine()

                    Dim strTokens As String()
                    strTokens = strWalletLine.Split(":")
                    Dim strWalletAddress As String = strTokens(1)
                    strWalletAddress = strWalletAddress.Replace("{", "")
                    strWalletAddress = strWalletAddress.Replace("'", "")
                    strWalletAddress = strWalletAddress.Replace(" ", "")
                    objReader.Close()
                    Return strWalletAddress

                Else
                    MessageBox.Show("Electrum Wallet Not found.  Make sure you have run the inital setup.", PROGRAM_TITLE)
                    Return String.Empty
                End If
            Else 'Custom Address
                Return txtAddress.Text
            End If
        End Get
    End Property

    Private ReadOnly Property IsWalletSetup As Boolean
        Get
            Return My.Computer.FileSystem.DirectoryExists(WalletFolder) And WalletAddress.Length > 0
        End Get
    End Property

    Private ReadOnly Property IsX64 As Boolean
        Get
            Return Is64BitOperatingSystem
        End Get
    End Property

    Private ReadOnly Property HasOpenCl As Boolean
        Get
            Return My.Computer.FileSystem.FileExists(Environment.SystemDirectory & "\OpenCL.DLL")
        End Get
    End Property

    Private ReadOnly Property NVidiaCheck As Boolean
        Get
            Return My.Computer.FileSystem.FileExists(Environment.SystemDirectory & "\NVCuda.DLL")
        End Get
    End Property

    Private ReadOnly Property VisualStudioRuntime As Boolean
        Get
            Return My.Computer.FileSystem.FileExists(Environment.SystemDirectory & "\MSVCR100.DLL")
        End Get
    End Property

    Private ReadOnly Property LogFileLocation As String
        Get
            Return Application.StartupPath & "\scripts\minelog.txt"
        End Get
    End Property

    Private ReadOnly Property IsAMDProcessor As Boolean
        Get
            Dim mosSearcher As New ManagementObjectSearcher("select * from Win32_Processor")
            Dim moc As ManagementObjectCollection = mosSearcher.Get()
            For Each mObject As ManagementObject In moc
                If mObject("name") IsNot Nothing Then
                    If mObject("name").ToString.ToUpper.Contains("INTEL") Then
                        Return False
                    End If
                End If
            Next
            Return True
        End Get
    End Property

    Private ReadOnly Property GetPathToMinerEXE() As String
        Get
            Dim strOutput As String = String.Empty
            strOutput = Application.StartupPath & "\Scripts\"

            Select Case _SelectedMiningMethod
                'SKEIN SKEIN SKEIN SKEIN SKEIN SKEIN SKEIN SKEIN SKEIN SKEIN SKEIN SKEIN SKEIN SKEIN SKEIN SKEIN
                Case enumMiningMethod.SkeinCPU32, enumMiningMethod.SkeinCPU64, enumMiningMethod.SkeinGPU
                    strOutput &= "skein\"
                    If _SelectedMiningMethod = enumMiningMethod.SkeinCPU64 Then
                        strOutput &= "SkeinCPU64.exe"
                    End If
                    If _SelectedMiningMethod = enumMiningMethod.SkeinCPU32 Then
                        strOutput &= "Skein32\SkeinCPU32.exe"
                    End If
                    If _SelectedMiningMethod = enumMiningMethod.SkeinGPU Then
                        strOutput &= "SkeinGPU\skeingpu.exe"
                    End If
                    'QUBIT QUBIT QUBIT QUBIT QUBIT QUBIT QUBIT QUBIT QUBIT QUBIT QUBIT QUBIT QUBIT QUBIT QUBIT QUBIT 
                Case enumMiningMethod.QubitCPU32, enumMiningMethod.QubitCPU64, enumMiningMethod.QubitGPU
                    strOutput &= "qubit\"
                    If _SelectedMiningMethod = enumMiningMethod.QubitCPU64 Then
                        If IsAMDProcessor Then
                            strOutput &= "AMDCPU64.exe"
                        Else
                            strOutput &= "QubitCPU64.exe"
                        End If
                    End If
                    If _SelectedMiningMethod = enumMiningMethod.QubitCPU32 Then
                        strOutput &= "Qubit32\QubitCPU32.exe"
                    End If
                    If _SelectedMiningMethod = enumMiningMethod.QubitGPU Then
                        strOutput &= "QubitGPU\QubitGPU.exe"
                    End If
                    'GROESTL GROESTL GROESTL GROESTL GROESTL GROESTL GROESTL GROESTL GROESTL GROESTL GROESTL GROESTL 
                Case enumMiningMethod.GroestlCPU32, enumMiningMethod.GroestlCPU64, enumMiningMethod.GroestlGPU
                    strOutput &= "groestl\"
                    If _SelectedMiningMethod = enumMiningMethod.GroestlCPU64 Then
                        strOutput &= "GroestlCPU64.exe"
                    End If
                    If _SelectedMiningMethod = enumMiningMethod.GroestlCPU32 Then
                        strOutput &= "Groestl32\GroestlCPU32.exe"
                    End If
                    If _SelectedMiningMethod = enumMiningMethod.GroestlGPU Then
                        If NVidiaCheck Then
                            strOutput &= "GroestlGPU\GroestlNVGPU.exe"
                        Else
                            strOutput &= "GroestlGPU\GroestlGPU.exe"
                        End If
                    End If
                    'SCRYPT SCRYPT SCRYPT SCRYPT SCRYPT SCRYPT SCRYPT SCRYPT SCRYPT SCRYPT SCRYPT SCRYPT SCRYPT SCRYPT 
                Case enumMiningMethod.ScryptCPU32, enumMiningMethod.ScryptCPU64, enumMiningMethod.ScryptGPU
                    strOutput &= "scrypt\"
                    If _SelectedMiningMethod = enumMiningMethod.ScryptCPU64 Then
                        strOutput &= "ScryptCPU64.exe"
                    End If
                    If _SelectedMiningMethod = enumMiningMethod.ScryptCPU32 Then
                        strOutput &= "Scrypt32\ScryptCPU32.exe"
                    End If
                    If _SelectedMiningMethod = enumMiningMethod.ScryptGPU Then
                        If NVidiaCheck Then
                            strOutput &= "ScryptGPU\ScryptNVGPU.exe"
                        End If
                        strOutput &= "ScryptGPU\ScryptGPU.exe"
                    End If
            End Select

            Return strOutput
        End Get
    End Property

    Private ReadOnly Property GetMiningEXE As String
        Get
            Dim strExe as String = GetPathToMinerEXE
            For I As Integer = strExe.Length - 1 To 0 Step -1
                If strExe.ElementAt(I) = "\" Then
                    strExe = strExe.Substring(I, strExe.Length - I).Replace("\", "")
                    Exit For
                End If
            Next
            Return strExe
        End Get
    End Property

    Private ReadOnly Property GetMiningBatch As String
        Get
            Return Application.StartupPath & "\scripts\StartMining.bat"
        End Get
    End Property

    Private ReadOnly Property GetPathToElectrum As String
        Get
            Return Application.StartupPath & "\Wallet.exe"
        End Get
    End Property

    Private Enum enumMiningMethod
        SkeinCPU32
        SkeinCPU64
        SkeinGPU
        QubitCPU32
        QubitCPU64
        QubitGPU
        GroestlCPU32
        GroestlCPU64
        GroestlGPU
        ScryptCPU32
        ScryptCPU64
        ScryptGPU
    End Enum

    Private Enum enumRegistryValue
        CustomAddress
        CustomUsername
        CustomPassword
        CustomMiningPool
        CustomSelectedAlgorithm
    End Enum

#End Region

#Region " Functions and Subs "

    Private Sub StartMiningProcess()
        Dim strLocation As String = "StartMiningProcess"
        Try
            'Just in case make sure there isn't another miner running from a crash or something else
            KillMiner()
            'here goes nothing....
            'load the dynamically created batch file as a process
            'I had to do it this way because for whatever reason when you try to log the output from the command window
            'you cannot log to file via the arguments using 2>file.txt
            'it never logs to the file when the process is started this way, permissions when creating a process?
            'but if you put everything you need into a batch and then start it, it works fine.
            _newProcess = New Process
            With _newProcess
                If System.IO.File.Exists(GetMiningBatch) Then
                    'TODO:Threads portion?
                    .StartInfo.FileName = GetMiningBatch
                    .StartInfo.UseShellExecute = False
                    .StartInfo.CreateNoWindow = True
                    .StartInfo.RedirectStandardOutput = True
                    .StartInfo.RedirectStandardError = True
                    .Start()
                    'uncomment for debugging of command line processes
                    'freezes up if leave this in so..just for debugging.
                    'Dim strOutputError As String = _newProcess.StandardError.ReadToEnd
                    'Dim strOutput As String = _newProcess.StandardOutput.ReadToEnd
                    'Dim setbreakpointhere As String = ""
                Else
                    Throw New Exception(" StartMining.bat not found!")
                End If
            End With

        Catch ex As Exception
            BuildErrorMessage(strModule, strLocation, ex.Message)
        End Try
    End Sub

    Private Sub WriteBatchFile()
        Dim strLocation As String = "StartMiningProcess"
        Try
            Dim strFileLine As String = String.Empty
            strFileLine &= """" & GetPathToMinerEXE & """"

            '        'TODO Threads always 1 aparently?
            Dim strAlgo As String = ""
            If _SelectedMiningMethod.ToString.ToUpper.Contains("SKEIN") Then
                If _SelectedMiningMethod = enumMiningMethod.SkeinGPU Then
                    strAlgo = "-k skein --intensity D"
                Else
                    strAlgo = "-a skein"
                End If
            ElseIf _SelectedMiningMethod.ToString.ToUpper.Contains("QUBIT") Then
                If _SelectedMiningMethod = enumMiningMethod.QubitCPU64 Or _SelectedMiningMethod = enumMiningMethod.QubitCPU32 Then
                    strAlgo = "-a qubit"
                End If
                If _SelectedMiningMethod = enumMiningMethod.QubitGPU And Not NVidiaCheck Then
                    strAlgo = "--kernel qubitcoin --intensity D"
                End If
                If _SelectedMiningMethod = enumMiningMethod.QubitGPU And NVidiaCheck Then
                    strAlgo = "--algo=qubit"
                End If

                If IsAMDProcessor And Is64BitOperatingSystem And (_SelectedMiningMethod = enumMiningMethod.QubitCPU32 Or _SelectedMiningMethod = enumMiningMethod.QubitCPU64) Then
                    strAlgo = "-a qubit"
                End If
                '?
                If IsAMDProcessor And Not Is64BitOperatingSystem Then
                    MessageBox.Show("Unable to do qubit CPU mining on AMD cpu's with a 32 bit OS at this time. Please upgrade to 64 bit and try again", PROGRAM_TITLE)
                    Exit Sub 'will probably have more errors cause no batch
                End If
            ElseIf _SelectedMiningMethod.ToString.ToUpper.Contains("GROESTL") Then
                If _SelectedMiningMethod = enumMiningMethod.GroestlCPU32 Or _SelectedMiningMethod = enumMiningMethod.GroestlCPU64 Then
                    strAlgo = "-a myr-gr"
                End If
                If _SelectedMiningMethod = enumMiningMethod.GroestlGPU Then
                    If NVidiaCheck Then
                        strAlgo = "-a myr-gr"
                    Else
                        strAlgo = "-k myriadcoin-groestl"
                    End If
                End If
            ElseIf _SelectedMiningMethod.ToString.ToUpper.Contains("SCRYPT") Then
                If _SelectedMiningMethod = enumMiningMethod.SkeinCPU32 Or _SelectedMiningMethod = enumMiningMethod.SkeinCPU64 Then
                    strAlgo = "-a scrypt"
                End If
                If _SelectedMiningMethod = enumMiningMethod.ScryptGPU Then
                    If NVidiaCheck Then
                        strAlgo = "-a scrypt"
                    Else
                        strAlgo = "--Intensity D"
                    End If
                End If
            End If
            'Set proper port for mining method
            If rbUseBirdsPool.Checked Then
                Dim strPort As String = String.Empty
                Select Case _SelectedMiningMethod
                    Case enumMiningMethod.SkeinCPU32, enumMiningMethod.SkeinCPU64, enumMiningMethod.SkeinGPU
                        strPort = "5589"
                    Case enumMiningMethod.GroestlCPU32, enumMiningMethod.GroestlCPU64, enumMiningMethod.GroestlGPU
                        strPort = "3333"
                    Case enumMiningMethod.QubitCPU32, enumMiningMethod.QubitCPU64, enumMiningMethod.QubitGPU
                        strPort = "5567"
                    Case enumMiningMethod.ScryptCPU32, enumMiningMethod.ScryptCPU64, enumMiningMethod.ScryptGPU
                        strPort = "5556"
                End Select

                strFileLine &= String.Format(" {1} -o stratum+tcp://birdspool.no-ip.org:{0} -u " & WalletAddress & " -p 912837465 --threads 1", strPort, strAlgo)
            Else
                strFileLine &= String.Format(" {2} -o stratum+tcp://{0} -u " & txtUsername.Text & " -p {1} --threads 1", txtPool.Text, txtPassword.Text, strAlgo)
            End If

            'Lazy removal - gpu has no threads
            If _SelectedMiningMethod = enumMiningMethod.GroestlGPU Or _SelectedMiningMethod = enumMiningMethod.QubitGPU Or _
                _SelectedMiningMethod = enumMiningMethod.SkeinGPU Or _SelectedMiningMethod = enumMiningMethod.ScryptGPU Then
                strFileLine = strFileLine.Replace(" --threads 1","")
            End If

            'Always
            strFileLine &= " 2>""" & LogFileLocation & """"

            Using writer As StreamWriter = New StreamWriter(GetMiningBatch)
                writer.Write(strFileLine)
                writer.Close() 'added this
            End Using
        Catch ex As Exception
            BuildErrorMessage(strModule, strLocation, ex.Message)
        End Try
    End Sub

    Private Sub UpdateOutputWindow()
        Dim strLocation As String = "UpdateOutputWindow"
        Try
            'So here is the issue..
            'the miner writes to the log file forever so it can get super big with log entries.
            'there is no way in hell we want to open the file and read line by line until we get to the last line
            'solution - open the file and binary read starting from the end of the file
            'I've got to think this would be faster and not tend to freeze things up.
            'This method is called via the timer.

            Dim fsLogFile As FileStream = New FileStream(LogFileLocation, FileMode.Open, FileAccess.Read, FileShare.ReadWrite)
            Dim buffer(256) As Char 'assume a line is not more than 256 chars?

            Dim brReader As New IO.BinaryReader(fsLogFile)
            If fsLogFile.Length < 1 Then
                fsLogFile.Close()
                Exit Sub
            End If

            Dim iFound As Integer = 0
            For i As Integer = 1 To 1000
                If i > fsLogFile.Length Then Exit For
                fsLogFile.Position = fsLogFile.Length - i
                brReader = New IO.BinaryReader(fsLogFile)
                If brReader.ReadChars(1) = "[" Then
                    iFound = i
                    Exit For
                End If
            Next
            fsLogFile.Position = fsLogFile.Length - iFound
            brReader = New IO.BinaryReader(fsLogFile)
            brReader.Read(buffer, 0, 256)
            Dim strLastLine As New String(buffer)
            If Not txtOutput.Text.Contains(strLastLine) Then
                txtOutput.Text = strLastLine
            End If

            fsLogFile.Close()
        Catch ex As Exception
            BuildErrorMessage(strModule, strLocation, ex.Message)
        End Try
    End Sub

    Private Sub WriteToRegistry(ByVal enumRegValue As enumRegistryValue)
        Dim strLocation As String = "WriteToRegistry"
        Try
            Select Case enumRegValue
                Case enumRegistryValue.CustomAddress
                    SaveSetting("SimplicityMiner", "Settings", "CustomAddress", txtAddress.Text)
                Case enumRegistryValue.CustomMiningPool
                    SaveSetting("SimplicityMiner", "Settings", "CustomMiningPool", txtPool.Text)
                Case enumRegistryValue.CustomUsername
                    SaveSetting("SimplicityMiner", "Settings", "CustomUsername", txtUsername.Text)
                Case enumRegistryValue.CustomPassword
                    SaveSetting("SimplicityMiner", "Settings", "CustomPassword", txtPassword.Text)
                Case enumRegistryValue.CustomSelectedAlgorithm
                    Dim iSelectedAlgorithm As Integer = 0
                    If rbSkein.Checked Then
                        iSelectedAlgorithm = 0
                    End If
                    If rbQubit.Checked Then
                        iSelectedAlgorithm = 1
                    End If
                    If rbGroestl.Checked Then
                        iSelectedAlgorithm = 2
                    End If
                    If rbScrypt.Checked Then
                        iSelectedAlgorithm = 3
                    End If

                    SaveSetting("SimplicityMiner", "Settings", "CustomSelectedAlgorithm", iSelectedAlgorithm)
            End Select
        Catch ex As Exception
            BuildErrorMessage(strModule, strLocation, ex.Message)
        End Try
    End Sub

    Private Sub DisableEnableControls(ByVal blnEnabled As Boolean)
        Dim strLocation As String = strModule & ":" & "DisableEnableControls"
        Try
            gbMethod.Enabled = blnEnabled
            gbMiningPool.Enabled = blnEnabled
            gbWallet.Enabled = blnEnabled

        Catch ex As Exception
            BuildErrorMessage(strModule, strLocation, ex.Message)
        End Try

    End Sub

    Private Sub KillMiner()
        For Each p As Process In System.Diagnostics.Process.GetProcessesByName(GetMiningEXE.Replace(".exe", ""))
            Try
                p.Kill()
            Catch ex As Exception
            End Try
        Next
    End Sub

#End Region

End Class
