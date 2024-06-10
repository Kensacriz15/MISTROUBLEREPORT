Imports MySql.Data.MySqlClient


Public Class Form1
    Dim connectionString As String = "server=194.110.173.106;port=3306;database=bbox_logistics;user=bbox_logistics;password=1234;"

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TabControl1.Anchor = AnchorStyles.Top Or AnchorStyles.Left
        MaximizeBox = False
    End Sub

    Private Sub btn_CreateTicket_Click(sender As Object, e As EventArgs) Handles btn_CreateTicket.Click
        TabControl1.SelectedIndex = 0
    End Sub

    Private Sub btn_Find_Click(sender As Object, e As EventArgs) Handles btn_Find.Click
        TabControl1.SelectedIndex = 1
    End Sub

    Private Sub btn_Print_Click(sender As Object, e As EventArgs) Handles btn_Print.Click
        TabControl1.SelectedIndex = 2
    End Sub

    Private Sub btn_Settings_Click(sender As Object, e As EventArgs) Handles btn_Settings.Click
        TabControl1.SelectedIndex = 3
    End Sub

#Region "Tab1"

    Dim ticketCounter As Integer = 0

    Private Sub combo_Department_SelectedIndexChanged(sender As Object, e As EventArgs) Handles combo_Department.SelectedIndexChanged
        Dim currentDate As String = DateTime.Now.ToString("ddMMyyyy")
        Dim departmentInitials As String = combo_Department.SelectedItem.ToString().Substring(0, 2)
        Dim ticketNumber As String = currentDate & departmentInitials & GetNextTicketNumber().ToString()
        txt_ticketnumber.Text = ticketNumber
    End Sub

    Private Function GetNextTicketNumber() As Integer
        Dim maxTicketNumber As Integer = 0

        Using connection As New MySqlConnection(connectionString)
            connection.Open()

            Dim query As String = "SELECT MAX(CAST(SUBSTRING_INDEX(ticket_number, '" & DateTime.Now.ToString("ddMMyyyy") & combo_Department.SelectedItem.ToString().Substring(0, 2) & "', -1) AS UNSIGNED)) AS max_ticket_number FROM tb_MIS WHERE ticket_number LIKE '" & DateTime.Now.ToString("ddMMyyyy") & combo_Department.SelectedItem.ToString().Substring(0, 2) & "%'"

            Using command As New MySqlCommand(query, connection)
                Dim reader As MySqlDataReader = command.ExecuteReader()

                If reader.Read() AndAlso Not reader.IsDBNull(0) Then
                    maxTicketNumber = Convert.ToInt32(reader("max_ticket_number"))
                End If

                reader.Close()
            End Using

            connection.Close()
        End Using

        ticketCounter = maxTicketNumber + 1
        Return ticketCounter
    End Function

    Private Sub txt_Name_TextChanged(sender As Object, e As EventArgs) Handles txt_Name.TextChanged

    End Sub

    Private Sub txt_Description_TextChanged(sender As Object, e As EventArgs) Handles txt_Description.TextChanged

    End Sub

    Private Sub txt_ticketnumber_TextChanged(sender As Object, e As EventArgs) Handles txt_ticketnumber.TextChanged

    End Sub

    Private Sub btn_Submit_Click(sender As Object, e As EventArgs) Handles btn_Submit.Click
        Dim startDate As DateTime = DateTime.Now
        Dim name As String = txt_Name.Text.Trim()
        Dim ticketNumber As String = txt_ticketnumber.Text
        Dim description As String = txt_Description.Text
        Dim level As String = Nothing
        Dim completedDate As DateTime? = Nothing
        Dim riskRating As String = Nothing

        ' Validate the name field
        If String.IsNullOrWhiteSpace(name) Then
            MessageBox.Show("Please enter a name.", "Submit Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        Using connection As New MySqlConnection(connectionString)
            connection.Open()

            Dim query As String = "INSERT INTO tb_MIS (start_date, name, ticket_number, description, level, completed_date, risk_rating) VALUES (@start_date, @name, @ticket_number, @description, @level, @completed_date, @risk_rating)"

            Using command As New MySqlCommand(query, connection)
                command.Parameters.AddWithValue("@start_date", startDate.ToString("yyyy-MM-dd hh:mm:ss tt"))
                command.Parameters.AddWithValue("@name", name)
                command.Parameters.AddWithValue("@ticket_number", ticketNumber)
                command.Parameters.AddWithValue("@description", description)
                command.Parameters.AddWithValue("@level", DBNull.Value)
                command.Parameters.AddWithValue("@completed_date", DBNull.Value)
                command.Parameters.AddWithValue("@risk_rating", DBNull.Value)

                command.ExecuteNonQuery()
            End Using

            connection.Close()
        End Using

        ' Clear the input fields after submitting
        txt_Name.Text = ""
        txt_ticketnumber.Text = ""
        txt_Description.Text = ""

        ' Display a message or perform any additional actions after submitting
        MessageBox.Show("Ticket submitted successfully!")
    End Sub


#End Region

#Region "Tab2"

#End Region

#Region "Tab3"

#End Region

#Region "Tab4"

#End Region

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub

End Class