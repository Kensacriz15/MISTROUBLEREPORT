Imports MySql.Data.MySqlClient


Public Class Form1
    Dim connectionString As String = "server=194.110.173.106;port=3306;database=bbox_logistics;user=bbox_logistics;password=1234;"

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TabControl1.Anchor = AnchorStyles.Top Or AnchorStyles.Left
        MaximizeBox = False
        combo_Department.SelectedIndex = 0
        combo_RiskRating.SelectedIndex = 0

        Using connection As New MySqlConnection("server=194.110.173.106;port=3306;database=bbox_logistics;user=bbox_logistics;password=1234;")
            connection.Open()

            Dim query As String = "SELECT * FROM tb_MIS"

            Using command As New MySqlCommand(query, connection)

                Dim table As New DataTable()

                Dim adapter As New MySqlDataAdapter(command)
                adapter.Fill(table)

                DataGridView2.DataSource = table
            End Using

            connection.Close()
        End Using
    End Sub

    Private Sub btn_CreateTicket_Click(sender As Object, e As EventArgs) Handles btn_CreateTicket.Click
        TabControl1.SelectedIndex = 0
    End Sub

    Private Sub btn_Find_Click(sender As Object, e As EventArgs) Handles btn_Find.Click
        TabControl1.SelectedIndex = 1
    End Sub

    Dim correctPassword As String = "admin"
    Private Sub btn_Print_Click(sender As Object, e As EventArgs) Handles btn_Print.Click
        Dim inputPassword As String = InputBox("Enter the password:", "Password Required")

        If inputPassword = correctPassword Then
            TabControl1.SelectedIndex = 2
        Else
            MessageBox.Show("Incorrect password. Access denied.", "Password Incorrect", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub btn_Settings_Click(sender As Object, e As EventArgs) Handles btn_Settings.Click
        TabControl1.SelectedIndex = 3
    End Sub

#Region "Tab1"

    Dim ticketCounter As Integer = 0

    Private Sub combo_Department_SelectedIndexChanged(sender As Object, e As EventArgs) Handles combo_Department.SelectedIndexChanged
        If combo_Department.SelectedItem.ToString() = "Select Department" Then
            txt_ticketnumber.Clear()
        Else
            Dim currentDate As String = DateTime.Now.ToString("ddMMyyyy")
            Dim departmentInitials As String = combo_Department.SelectedItem.ToString().Substring(0, 2)
            Dim ticketNumber As String = currentDate & departmentInitials & GetNextTicketNumber().ToString()
            txt_ticketnumber.Text = ticketNumber
        End If
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

    Private Sub txt_Description_Enter(sender As Object, e As EventArgs) Handles txt_Description.Enter
        If txt_Description.Text = "Type here" Then
            txt_Description.Text = ""
            txt_Description.ForeColor = Color.Black
        End If
    End Sub

    Private Sub txt_ticketnumber_TextChanged(sender As Object, e As EventArgs) Handles txt_ticketnumber.TextChanged
        txt_ticketnumber.ShortcutsEnabled = True
    End Sub

    Private Sub btn_Submit_Click(sender As Object, e As EventArgs) Handles btn_Submit.Click
        Dim startDate As DateTime = DateTime.Now
        Dim name As String = txt_Name.Text.Trim()
        Dim ticketNumber As String = txt_ticketnumber.Text
        Dim description As String = txt_Description.Text

        ' Validate the name field
        If String.IsNullOrWhiteSpace(name) Then
            MessageBox.Show("Please enter a name.", "Submit Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        Using connection As New MySqlConnection(connectionString)
            connection.Open()

            Dim query As String = "INSERT INTO tb_MIS (start_date, name, ticket_number, description) VALUES (@start_date, @name, @ticket_number, @description)"

            Using command As New MySqlCommand(query, connection)
                command.Parameters.AddWithValue("@start_date", startDate.ToString("yyyy-MM-dd hh:mm:ss tt"))
                command.Parameters.AddWithValue("@name", name)
                command.Parameters.AddWithValue("@ticket_number", ticketNumber)
                command.Parameters.AddWithValue("@description", description)

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
    Private Sub btn_find1_Click(sender As Object, e As EventArgs) Handles btn_find1.Click
        Dim searchValue As String = txt_find2.Text.Trim()

        Dim query As String = "SELECT * FROM tb_MIS WHERE ticket_number = @searchValue"

        Using connection As New MySqlConnection(connectionString)
            connection.Open()

            Using command As New MySqlCommand(query, connection)
                command.Parameters.AddWithValue("@searchValue", searchValue)

                Dim adapter As New MySqlDataAdapter(command)
                Dim table As New DataTable()
                adapter.Fill(table)

                ' Display the ticket information if found
                If table.Rows.Count > 0 Then
                    Dim row As DataRow = table.Rows(0)
                    Dim ticketNumber As String = row("ticket_number").ToString()
                    Dim startDate As DateTime = Convert.ToDateTime(row("start_date"))
                    Dim name As String = row("name").ToString()
                    Dim description As String = row("description").ToString()

                    ' Display the ticket information in a message box or any other desired way
                    Dim ticketInfo As String = $"Ticket Number: {ticketNumber}{Environment.NewLine}" &
                                           $"Start Date: {startDate}{Environment.NewLine}" &
                                           $"Name: {name}{Environment.NewLine}" &
                                           $"Description: {description}"
                    MessageBox.Show(ticketInfo, "Ticket Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
                    ' Display a message if no ticket information is found
                    MessageBox.Show("Ticket not found.", "Ticket Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            End Using

            connection.Close()
        End Using
    End Sub

    Private Sub txt_find2_TextChanged(sender As Object, e As EventArgs) Handles txt_find2.TextChanged

    End Sub

    Private Sub DataGridView2_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView2.CellContentClick

    End Sub

#End Region

#Region "Tab3"

#End Region

#Region "Tab4"

#End Region



End Class