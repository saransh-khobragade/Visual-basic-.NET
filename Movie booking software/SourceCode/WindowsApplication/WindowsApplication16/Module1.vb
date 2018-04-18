Imports System.Data.OleDb
Public Module Module1

    Public path As New String("" & Application.StartupPath & "")
    Public con As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & path & "\resources\movie.booking.accdb")

    Public Sub conopen()
        Try
            If con.State <> ConnectionState.Open Then
                con.Open()
            End If
        Catch ex As Exception
            Dim file As New FolderBrowserDialog
            MsgBox("Your MSaccess database file has been misplaced,help to locate resources folder")

            Clipboard.SetText(Application.StartupPath)
            file.ShowDialog()
           
            My.Computer.FileSystem.CopyDirectory(file.SelectedPath, Application.StartupPath & "/resources", True)

            MsgBox("Done,your resources folder is placed at needed location.ENJOY")
            Application.Restart()
        End Try
        
    End Sub

    Public Function redimage()
        Return "" & path & "\resources\RED.PNG"
    End Function
    Public Function blackimage()
        Return "" & path & "\resources\BLACK.PNG"
    End Function
    Public Function greenimage()
        Return "" & path & "\resources\GREEN.PNG"
    End Function
    Public Function whiteimage()
        Return "" & path & "\resources\WHITE.JPG"
    End Function
End Module
