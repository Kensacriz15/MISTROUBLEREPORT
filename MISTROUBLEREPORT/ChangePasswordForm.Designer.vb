<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ChangePasswordForm
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
        Me.txt_OldPassword = New System.Windows.Forms.TextBox()
        Me.txt_NewPassword = New System.Windows.Forms.TextBox()
        Me.txt_ConfirmPassword = New System.Windows.Forms.TextBox()
        Me.btn_Change = New System.Windows.Forms.Button()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'txt_OldPassword
        '
        Me.txt_OldPassword.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_OldPassword.Location = New System.Drawing.Point(154, 59)
        Me.txt_OldPassword.Name = "txt_OldPassword"
        Me.txt_OldPassword.Size = New System.Drawing.Size(156, 21)
        Me.txt_OldPassword.TabIndex = 0
        '
        'txt_NewPassword
        '
        Me.txt_NewPassword.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_NewPassword.Location = New System.Drawing.Point(154, 86)
        Me.txt_NewPassword.Name = "txt_NewPassword"
        Me.txt_NewPassword.Size = New System.Drawing.Size(156, 21)
        Me.txt_NewPassword.TabIndex = 1
        '
        'txt_ConfirmPassword
        '
        Me.txt_ConfirmPassword.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_ConfirmPassword.Location = New System.Drawing.Point(154, 113)
        Me.txt_ConfirmPassword.Name = "txt_ConfirmPassword"
        Me.txt_ConfirmPassword.Size = New System.Drawing.Size(156, 21)
        Me.txt_ConfirmPassword.TabIndex = 2
        '
        'btn_Change
        '
        Me.btn_Change.Location = New System.Drawing.Point(126, 155)
        Me.btn_Change.Name = "btn_Change"
        Me.btn_Change.Size = New System.Drawing.Size(75, 23)
        Me.btn_Change.TabIndex = 0
        Me.btn_Change.Text = "Change"
        Me.btn_Change.UseVisualStyleBackColor = True
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(83, 9)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(174, 24)
        Me.Label17.TabIndex = 9
        Me.Label17.Text = "Access Password"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(57, 62)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(91, 16)
        Me.Label1.TabIndex = 10
        Me.Label1.Text = "Old Password"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(51, 86)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(97, 16)
        Me.Label2.TabIndex = 11
        Me.Label2.Text = "New Password"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(12, 113)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(145, 16)
        Me.Label3.TabIndex = 12
        Me.Label3.Text = "Confirm New Password"
        '
        'ChangePasswordForm
        '
        Me.AcceptButton = Me.btn_Change
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(322, 211)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.btn_Change)
        Me.Controls.Add(Me.txt_ConfirmPassword)
        Me.Controls.Add(Me.txt_NewPassword)
        Me.Controls.Add(Me.txt_OldPassword)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "ChangePasswordForm"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Change Password"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents txt_OldPassword As TextBox
    Friend WithEvents txt_NewPassword As TextBox
    Friend WithEvents txt_ConfirmPassword As TextBox
    Friend WithEvents btn_Change As Button
    Friend WithEvents Label17 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
End Class
