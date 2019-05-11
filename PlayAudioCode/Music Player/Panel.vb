Imports System.Runtime.InteropServices

Public Class MusicPlayer
    <DllImport("user32.dll", SetLastError:=True, CharSet:=CharSet.Auto)> Private Shared Function SendMessage(ByVal hWnd As IntPtr, ByVal Msg As UInteger, ByVal wParam As IntPtr, ByVal lParam As IntPtr) As IntPtr
    End Function

    Const WM_APPCOMMAND As UInteger = &H319
    Const APPCOMMAND_VOLUME_UP As UInteger = &HA
    Const APPCOMMAND_VOLUME_DOWN As UInteger = &H9
    Const APPCOMMAND_VOLUME_MUTE As UInteger = &H8

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SerialPort1.Close()
        SerialPort1.PortName = "com4"
        SerialPort1.BaudRate = 9600
        SerialPort1.DataBits = 8
        SerialPort1.Encoding = System.Text.Encoding.Default
        SerialPort1.Open()

    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick

        Dim his As Char = SerialPort1.ReadExisting()
        Dim i, j As Integer
        Dim songs() As String = {"D:\Coldplay - Yellow.wav", "D:\Coldplay - Viva La Vida.wav",
          "D:\Linkin Park - Numb.wav"}
        Static songIndex As Integer = 0
        Static playOrStop As Integer = 0

        If his = "D" Then 'turn down the volume
            Try
                For i = 0 To 4
                    SendMessage(Me.Handle, WM_APPCOMMAND, &H30292, APPCOMMAND_VOLUME_DOWN * &H10000)
                    Label1.Text = "Down"
                Next i
            Catch ex As Exception
            End Try

        End If

        If his = "U" Then 'turn up the volume
            Try
                For j = 0 To 4
                    SendMessage(Me.Handle, WM_APPCOMMAND, &H30292, APPCOMMAND_VOLUME_UP * &H10000)
                    Label1.Text = "Up"
                Next j
            Catch ex As Exception
            End Try
        End If

        If his = "M" Then 'mute

            Try
                SendMessage(Me.Handle, WM_APPCOMMAND, &H200EB0, APPCOMMAND_VOLUME_MUTE * &H10000)
                Label1.Text = "Mute"
            Catch ex As Exception
            End Try
        End If

        If his = "P" Then 'play music, stop music alternatively

            playOrStop = playOrStop Mod 2

            If playOrStop = 0 Then
                My.Computer.Audio.Play("D:\Coldplay - Yellow.wav",
                AudioPlayMode.BackgroundLoop)
                Label1.Text = "Music: " + "D:\Coldplay - Yellow.wav"
            Else
                My.Computer.Audio.Stop()
                Label1.Text = "Music stop"
            End If

            playOrStop = playOrStop + 1

        End If


        If his = "S" Then 'switch songs

            songIndex = songIndex + 1
            songIndex = songIndex Mod 3
            My.Computer.Audio.Play(songs(songIndex), AudioPlayMode.BackgroundLoop)
            Label1.Text = "Switch to: " + songs(songIndex)

        End If


    End Sub


End Class




