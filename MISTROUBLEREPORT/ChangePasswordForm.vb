Public Class ChangePasswordForm
    Private Sub btn_Change_Click(sender As Object, e As EventArgs) Handles btn_Change.Click
        If txt_OldPassword.Text <> My.Settings.AdminPassword Then
            MessageBox.Show("Old password is incorrect.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        If txt_NewPassword.Text <> txt_ConfirmPassword.Text Then
            MessageBox.Show("New passwords do not match.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        If String.IsNullOrWhiteSpace(txt_NewPassword.Text) Then
            MessageBox.Show("New password cannot be empty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        My.Settings.AdminPassword = txt_NewPassword.Text
        My.Settings.Save()

        MessageBox.Show("Password changed successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Me.Close()
    End Sub


End Class