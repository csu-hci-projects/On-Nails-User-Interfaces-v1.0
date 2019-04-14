Imports System.Runtime.InteropServices

Public Class VolumeControl
    <DllImport("user32.dll", SetLastError:=True, CharSet:=CharSet.Auto)> Private Shared Function SendMessage(ByVal hWnd As IntPtr, ByVal Msg As UInteger, ByVal wParam As IntPtr, ByVal lParam As IntPtr) As IntPtr
    End Function

    Const WM_APPCOMMAND As UInteger = &H319
    Const APPCOMMAND_VOLUME_UP As UInteger = &HA
    Const APPCOMMAND_VOLUME_DOWN As UInteger = &H9
    Const APPCOMMAND_VOLUME_MUTE As UInteger = &H8

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SerialPort1.Close()
        SerialPort1.PortName = "com6"
        SerialPort1.BaudRate = 9600
        SerialPort1.DataBits = 8
        SerialPort1.Encoding = System.Text.Encoding.Default
        SerialPort1.Open()

    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick

        Dim his As Char = SerialPort1.ReadExisting()
        If his = "D" Then 'turn down the volume
            Try
                SendMessage(Me.Handle, WM_APPCOMMAND, &H30292, APPCOMMAND_VOLUME_DOWN * &H10000)
                Label1.Text = "Down"

            Catch ex As Exception

            End Try
        End If

        If his = "U" Then 'turn up the volume
            Try
                SendMessage(Me.Handle, WM_APPCOMMAND, &H30292, APPCOMMAND_VOLUME_UP * &H10000)
                Label1.Text = "Up"

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

    End Sub


End Class




