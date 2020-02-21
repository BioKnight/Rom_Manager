<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_Main
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_Main))
        Me.chk_Enabled = New System.Windows.Forms.CheckBox()
        Me.lbl_Local_Storage_Path = New System.Windows.Forms.Label()
        Me.txt_Local_Folder = New System.Windows.Forms.TextBox()
        Me.chklst_Ignore_Folders = New System.Windows.Forms.CheckedListBox()
        Me.lbl_Ignore_Folders = New System.Windows.Forms.Label()
        Me.btn_Hide = New System.Windows.Forms.Button()
        Me.btn_Close = New System.Windows.Forms.Button()
        Me.systry_Icon = New System.Windows.Forms.NotifyIcon(Me.components)
        Me.btn_Force_Copy = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'chk_Enabled
        '
        Me.chk_Enabled.AutoSize = True
        Me.chk_Enabled.Location = New System.Drawing.Point(12, 235)
        Me.chk_Enabled.Name = "chk_Enabled"
        Me.chk_Enabled.Size = New System.Drawing.Size(65, 17)
        Me.chk_Enabled.TabIndex = 0
        Me.chk_Enabled.Text = "&Enabled"
        Me.chk_Enabled.UseVisualStyleBackColor = True
        '
        'lbl_Local_Storage_Path
        '
        Me.lbl_Local_Storage_Path.AutoSize = True
        Me.lbl_Local_Storage_Path.Location = New System.Drawing.Point(12, 9)
        Me.lbl_Local_Storage_Path.Name = "lbl_Local_Storage_Path"
        Me.lbl_Local_Storage_Path.Size = New System.Drawing.Size(98, 13)
        Me.lbl_Local_Storage_Path.TabIndex = 2
        Me.lbl_Local_Storage_Path.Text = "Local Storage &Path"
        '
        'txt_Local_Folder
        '
        Me.txt_Local_Folder.Location = New System.Drawing.Point(12, 25)
        Me.txt_Local_Folder.Name = "txt_Local_Folder"
        Me.txt_Local_Folder.Size = New System.Drawing.Size(236, 20)
        Me.txt_Local_Folder.TabIndex = 3
        '
        'chklst_Ignore_Folders
        '
        Me.chklst_Ignore_Folders.FormattingEnabled = True
        Me.chklst_Ignore_Folders.Location = New System.Drawing.Point(12, 77)
        Me.chklst_Ignore_Folders.Name = "chklst_Ignore_Folders"
        Me.chklst_Ignore_Folders.Size = New System.Drawing.Size(236, 124)
        Me.chklst_Ignore_Folders.TabIndex = 4
        '
        'lbl_Ignore_Folders
        '
        Me.lbl_Ignore_Folders.AutoSize = True
        Me.lbl_Ignore_Folders.Location = New System.Drawing.Point(12, 61)
        Me.lbl_Ignore_Folders.Name = "lbl_Ignore_Folders"
        Me.lbl_Ignore_Folders.Size = New System.Drawing.Size(74, 13)
        Me.lbl_Ignore_Folders.TabIndex = 5
        Me.lbl_Ignore_Folders.Text = "Ignore Folders"
        '
        'btn_Hide
        '
        Me.btn_Hide.Location = New System.Drawing.Point(83, 231)
        Me.btn_Hide.Name = "btn_Hide"
        Me.btn_Hide.Size = New System.Drawing.Size(90, 23)
        Me.btn_Hide.TabIndex = 6
        Me.btn_Hide.Text = "&Hide"
        Me.btn_Hide.UseVisualStyleBackColor = True
        '
        'btn_Close
        '
        Me.btn_Close.Location = New System.Drawing.Point(179, 231)
        Me.btn_Close.Name = "btn_Close"
        Me.btn_Close.Size = New System.Drawing.Size(69, 23)
        Me.btn_Close.TabIndex = 7
        Me.btn_Close.Text = "&Close"
        Me.btn_Close.UseVisualStyleBackColor = True
        '
        'systry_Icon
        '
        Me.systry_Icon.Icon = CType(resources.GetObject("systry_Icon.Icon"), System.Drawing.Icon)
        Me.systry_Icon.Text = "ROM MAnager"
        Me.systry_Icon.Visible = True
        '
        'btn_Force_Copy
        '
        Me.btn_Force_Copy.Location = New System.Drawing.Point(12, 206)
        Me.btn_Force_Copy.Name = "btn_Force_Copy"
        Me.btn_Force_Copy.Size = New System.Drawing.Size(236, 23)
        Me.btn_Force_Copy.TabIndex = 8
        Me.btn_Force_Copy.Text = "&Force Copy"
        Me.btn_Force_Copy.UseVisualStyleBackColor = True
        '
        'frm_Main
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(260, 261)
        Me.Controls.Add(Me.btn_Force_Copy)
        Me.Controls.Add(Me.btn_Close)
        Me.Controls.Add(Me.btn_Hide)
        Me.Controls.Add(Me.lbl_Ignore_Folders)
        Me.Controls.Add(Me.chklst_Ignore_Folders)
        Me.Controls.Add(Me.txt_Local_Folder)
        Me.Controls.Add(Me.lbl_Local_Storage_Path)
        Me.Controls.Add(Me.chk_Enabled)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frm_Main"
        Me.Text = "ROM Manager"
        Me.WindowState = System.Windows.Forms.FormWindowState.Minimized
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents chk_Enabled As CheckBox
    Friend WithEvents lbl_Local_Storage_Path As Label
    Friend WithEvents txt_Local_Folder As TextBox
    Friend WithEvents chklst_Ignore_Folders As CheckedListBox
    Friend WithEvents lbl_Ignore_Folders As Label
    Friend WithEvents btn_Hide As Button
    Friend WithEvents btn_Close As Button
    Friend WithEvents systry_Icon As NotifyIcon
    Friend WithEvents btn_Force_Copy As Button
End Class
