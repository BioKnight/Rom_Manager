Imports System.Runtime.InteropServices
Imports System.Threading

Public Class frm_Main

    Private Const WM_DEVICECHANGE As Integer = &H219
    Private Const DBT_DEVICEARRIVAL As Integer = &H8000
    Private Const DBT_DEVTYP_VOLUME As Integer = &H2
    Private fl_Thread As Thread
    Private cpy_enabled As Boolean = True
    Private local_Path As String = "C:\Arcade.210\Systems"

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

    'Override message processing to check for the DEVICECHANGE message
    Protected Overrides Sub WndProc(ByRef m As System.Windows.Forms.Message)
        If cpy_enabled Then
            If m.Msg = WM_DEVICECHANGE Then
                If CInt(m.WParam) = DBT_DEVICEARRIVAL Then
                    Dim DeviceInfo As DEV_BROADCAST_HDR
                    DeviceInfo = DirectCast(Marshal.PtrToStructure(m.LParam, GetType(DEV_BROADCAST_HDR)), DEV_BROADCAST_HDR)
                    If DeviceInfo.dbch_devicetype = DBT_DEVTYP_VOLUME Then
                        Dim Volume As DEV_BROADCAST_VOLUME
                        Volume = DirectCast(Marshal.PtrToStructure(m.LParam, GetType(DEV_BROADCAST_VOLUME)), DEV_BROADCAST_VOLUME)
                        Dim DriveLetter As String = (GetDriveLetterFromMask(Volume.dbcv_unitmask) & ":\")
                        fl_Thread = New Thread(AddressOf Get_Roms)
                        fl_Thread.Start(DriveLetter)
                    End If
                End If
            End If
        End If
        'Process all other messages as normal
        MyBase.WndProc(m)
    End Sub

    Private dir_Compare As Comparer(Of Object)
    Private Game_System_Folders As New List(Of IO.DirectoryInfo)
    Private Sub Check_USB_Folders(path As String)

        Dim usb_Folders As New IO.DirectoryInfo(path)
        For Each folder As IO.DirectoryInfo In usb_Folders.EnumerateDirectories
            If chklst_Ignore_Folders.CheckedItems.Contains(folder.Name) Then
                ' Don't Copy
            Else
                If Game_System_Folders.Contains(folder, New Folder_Comparer) Then
                    For Each usb_file As IO.FileInfo In folder.EnumerateFiles
                        Dim copy_Path As String = find_Correct_Folder_And_Verify_File(folder, usb_file)
                        If copy_Path IsNot Nothing Then usb_file.MoveTo(copy_Path)
                    Next
                Else
                    ' Folder not found
                End If
            End If
        Next
    End Sub

    Private Function get_Local_Storage_Structure(Path As String)
        Dim rom_Location As New IO.DirectoryInfo(Path)
        For Each folder As IO.DirectoryInfo In rom_Location.EnumerateDirectories
            Game_System_Folders.Add(folder)
        Next
    End Function

    Private Sub Get_Roms(Path As String)
        get_Local_Storage_Structure("C:\Arcade.210\Systems")
        Check_USB_Folders(Path)

    End Sub

    Function find_Correct_Folder_And_Verify_File(usb_Copy_Folder As IO.DirectoryInfo, usb_Copy_File As IO.FileInfo) As String
        Try
            Dim local_Copy_Folder As IO.DirectoryInfo = Game_System_Folders.Find(Function(p) p.Name = usb_Copy_Folder.Name)
            local_Copy_Folder = New IO.DirectoryInfo(local_Copy_Folder.FullName & "\roms")

            If local_Copy_Folder.EnumerateFiles.Contains(usb_Copy_File, New File_Comparer) Then
                ' Well why do we need two
                'MsgBox("Exists")
            Else
                ' OK, Lets copy
                Return local_Copy_Folder.FullName & "\" & usb_Copy_File.Name
            End If
        Catch ex As Exception

        End Try

    End Function

    Private Sub chk_Enabled_CheckStateChanged(sender As Object, e As EventArgs) Handles chk_Enabled.CheckStateChanged
        cpy_enabled = chk_Enabled.Checked
    End Sub

    Private Sub txt_Local_Folder_Click(sender As Object, e As EventArgs) Handles txt_Local_Folder.Click
        Dim folder_Select As New FolderBrowserDialog
        If folder_Select.ShowDialog() = DialogResult.OK Then
            txt_Local_Folder.Text = folder_Select.SelectedPath
        End If
        lbl_Local_Storage_Path.Select()
    End Sub

    Private Sub txt_Local_Folder_GotFocus(sender As Object, e As EventArgs) Handles txt_Local_Folder.GotFocus
        lbl_Local_Storage_Path.Select()
    End Sub

    Private Sub frm_Main_Load(sender As Object, e As EventArgs) Handles Me.Load
        txt_Local_Folder.Text = local_Path
        chk_Enabled.Checked = cpy_enabled

    End Sub

    Private Sub txt_Local_Folder_TextChanged(sender As Object, e As EventArgs) Handles txt_Local_Folder.TextChanged
        For Each folder As IO.DirectoryInfo In New IO.DirectoryInfo(local_Path).EnumerateDirectories
            chklst_Ignore_Folders.Items.Add(folder.Name)
        Next
    End Sub

    Private Sub btn_Close_Click(sender As Object, e As EventArgs) Handles btn_Close.Click
        Me.Close()
    End Sub

    Private Sub btn_Hide_Click(sender As Object, e As EventArgs) Handles btn_Hide.Click
        systry_Icon.Visible = True
        systry_Icon.Icon = SystemIcons.Application
        systry_Icon.BalloonTipIcon = ToolTipIcon.Info
        systry_Icon.BalloonTipTitle = "ROM Manager"
        systry_Icon.BalloonTipText = "ROM Manager"
        systry_Icon.ShowBalloonTip(50000)
        ShowInTaskbar = False
        Me.Hide()
    End Sub

    Private Sub systry_Icon_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles systry_Icon.MouseDoubleClick
        Me.Show()
        ShowInTaskbar = True
        Me.WindowState = FormWindowState.Normal
    End Sub

    Private Sub lbl_Local_Storage_Path_Click(sender As Object, e As EventArgs) Handles lbl_Local_Storage_Path.Click
        Dim folder_Select As New FolderBrowserDialog
        If folder_Select.ShowDialog() = DialogResult.OK Then
            txt_Local_Folder.Text = folder_Select.SelectedPath
        End If
        lbl_Local_Storage_Path.Select()
    End Sub

    Private Sub btn_Force_Copy_Click(sender As Object, e As EventArgs) Handles btn_Force_Copy.Click
        Dim sel_volume As New FolderBrowserDialog
        sel_volume.Description = "Select USB Drive Root"
        If sel_volume.ShowDialog = DialogResult.OK Then
            Dim DriveLetter As String = sel_volume.SelectedPath
            fl_Thread = New Thread(AddressOf Get_Roms)
            fl_Thread.Start(DriveLetter)
        End If
    End Sub

    Private Sub frm_Main_Resize(sender As Object, e As EventArgs) Handles Me.Resize

    End Sub
End Class

Public Class Folder_Comparer
    Implements Generic.IEqualityComparer(Of IO.DirectoryInfo)

    Public Overloads Function Equals(x As IO.DirectoryInfo, y As IO.DirectoryInfo) As Boolean Implements System.Collections.Generic.IEqualityComparer(Of IO.DirectoryInfo).Equals
        If x.Name = y.Name Then Return True
        Return False
    End Function

    Public Overloads Function GetHashCode(obj As IO.DirectoryInfo) As Integer Implements System.Collections.Generic.IEqualityComparer(Of IO.DirectoryInfo).GetHashCode
        Return obj.GetHashCode
    End Function

End Class

Public Class File_Comparer
    Implements Generic.IEqualityComparer(Of IO.FileInfo)

    Public Overloads Function Equals(x As IO.FileInfo, y As IO.FileInfo) As Boolean Implements System.Collections.Generic.IEqualityComparer(Of IO.FileInfo).Equals
        If x.Name = y.Name Then Return True
        Return False
    End Function

    Public Overloads Function GetHashCode(obj As IO.FileInfo) As Integer Implements System.Collections.Generic.IEqualityComparer(Of IO.FileInfo).GetHashCode
        Return obj.GetHashCode
    End Function

End Class
