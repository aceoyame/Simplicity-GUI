﻿Module General
    Public Sub BuildErrorMessage(ByVal strException As String, ByVal strModule As String,ByVal strLocation As String)
        MessageBox.Show(strException & " at " & strModule & ":" & strLocation, "Simplicity Myriad Miner", MessageBoxButtons.OK, MessageBoxIcon.Stop)
    End Sub
End Module
