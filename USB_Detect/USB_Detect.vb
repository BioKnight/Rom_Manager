Imports System.Runtime.InteropServices

Public Class USB_Detect

    Private Const WM_DEVICECHANGE As Integer = &H219
    Private Const DBT_DEVICEARRIVAL As Integer = &H8000
    Private Const DBT_DEVTYP_VOLUME As Integer = &H2

    'Device information structure
    Public Structure DEV_BROADCAST_HDR
        Public dbch_size As Int32
        Public dbch_devicetype As Int32
        Public dbch_reserved As Int32
    End Structure

    'Volume information Structure
    Private Structure DEV_BROADCAST_VOLUME
        Public dbcv_size As Int32
        Public dbcv_devicetype As Int32
        Public dbcv_reserved As Int32
        Public dbcv_unitmask As Int32
        Public dbcv_flags As Int16
    End Structure

    'Function that gets the drive letter from the unit mask
    Private Function GetDriveLetterFromMask(ByRef Unit As Int32) As Char
        For i As Integer = 0 To 25
            If Unit = (2 ^ i) Then
                Return Chr(Asc("A") + i)
            End If
        Next
    End Function

End Class
