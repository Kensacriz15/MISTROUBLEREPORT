Imports MySql.Data.MySqlClient
Imports System.Data

Public Class Form1
    Dim connectionString As String

    Private activeFilter As String = "all"

    ' Form Load Event
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TabControl1.Anchor = AnchorStyles.Top Or AnchorStyles.Left
        MaximizeBox = False
        combo_Department.SelectedIndex = 0
        combo_RiskRating.SelectedIndex = 0
        txt_password.UseSystemPasswordChar = True
        LoadSettings()

        ' Only try to connect if ALL fields are filled
        If Not String.IsNullOrEmpty(txt_server.Text) AndAlso
       Not String.IsNullOrEmpty(txt_port.Text) AndAlso
       Not String.IsNullOrEmpty(txt_database.Text) AndAlso
       Not String.IsNullOrEmpty(txt_username.Text) AndAlso
       Not String.IsNullOrEmpty(txt_password.Text) Then

            InitializeConnectionString()
            CheckDatabaseConnection()
        Else
            ' Do not attempt to connect, do not show error, just stay on the current tab or switch to settings
            ' Optionally, you can show a message or highlight the settings tab
            'TabControl1.SelectedIndex = 1'
        End If
    End Sub

    Private Sub LoadSettings()
        txt_server.Text = My.Settings.Server
        txt_port.Text = My.Settings.Port
        txt_database.Text = My.Settings.Database
        txt_username.Text = My.Settings.Username
        txt_password.Text = My.Settings.Password
    End Sub
    ' Initialize the connection string with proper validation and debugging output
    Private Sub InitializeConnectionString()
        Try
            Dim server As String = My.Settings.Server
            Dim port As String = My.Settings.Port
            Dim database As String = My.Settings.Database
            Dim username As String = My.Settings.Username
            Dim password As String = My.Settings.Password

            ' Debugging output to verify the values
            Console.WriteLine($"Server: {server}")
            Console.WriteLine($"Port: {port}")
            Console.WriteLine($"Database: {database}")
            Console.WriteLine($"Username: {username}")
            Console.WriteLine($"Password: {password}")

            ' Validate the settings are not empty
            If String.IsNullOrEmpty(server) OrElse
               String.IsNullOrEmpty(port) OrElse
               String.IsNullOrEmpty(database) OrElse
               String.IsNullOrEmpty(username) OrElse
               String.IsNullOrEmpty(password) Then
                Throw New ArgumentException("One or more connection string values are empty.")
            End If

            connectionString = $"server={server};port={port};database={database};user={username};password={password};"
        Catch ex As Exception
            MessageBox.Show($"Error initializing connection string: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            TabControl1.SelectedIndex = 3 ' Navigate to settings tab
        End Try
    End Sub

    ' Check Database Connection
    Private Sub CheckDatabaseConnection()
        Using connection As New MySqlConnection(connectionString)
            Try
                connection.Open()
                ' Connection successful, load the data
                LoadData()
            Catch ex As Exception
                ' Connection failed, navigate to the settings tab
                MessageBox.Show($"Database connection failed: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                TabControl1.SelectedIndex = 3
            End Try
        End Using
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Timer1.Stop() ' Stop the timer
        If activeFilter = "all" Then
            Dim query As String = "SELECT * FROM tb_mistroublereport"

            Using connection As New MySqlConnection(connectionString)
                connection.Open()

                Using command As New MySqlCommand(query, connection)
                    Dim table As New DataTable()
                    Dim adapter As New MySqlDataAdapter(command)
                    adapter.Fill(table)

                    DataGridView2.DataSource = table
                End Using

                connection.Close()
            End Using
        End If
        Timer1.Start() ' Restart the timer
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

            Dim query As String = "SELECT MAX(CAST(SUBSTRING_INDEX(ticket_number, '" & DateTime.Now.ToString("ddMMyyyy") & combo_Department.SelectedItem.ToString().Substring(0, 2) & "', -1) AS UNSIGNED)) AS max_ticket_number FROM tb_mistroublereport WHERE ticket_number LIKE '" & DateTime.Now.ToString("ddMMyyyy") & combo_Department.SelectedItem.ToString().Substring(0, 2) & "%'"

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

            Dim query As String = "INSERT INTO tb_mistroublereport (start_date, name, ticket_number, description) VALUES (@start_date, @name, @ticket_number, @description)"

            Using command As New MySqlCommand(query, connection)
                command.Parameters.AddWithValue("@start_date", startDate)
                command.Parameters.AddWithValue("@name", name)
                command.Parameters.AddWithValue("@ticket_number", ticketNumber)
                command.Parameters.AddWithValue("@description", description)

                command.ExecuteNonQuery()
            End Using

            ' Refresh the DataGridView
            Dim adapter As New MySqlDataAdapter("SELECT * FROM tb_mistroublereport", connection)
            Dim table As New DataTable()
            adapter.Fill(table)
            DataGridView2.DataSource = table

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

        Dim query As String = "SELECT * FROM tb_mistroublereport WHERE ticket_number = @searchValue"

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








#End Region

#Region "Tab3"
    'Add Information in tb_mistroublereport
    'wHEN i select in gridbox it will automatic show ticket number
    'and Add information such as trouble time and completed time
    'i have level low impact, negligible, moderate and critical this would be based on trouble_time and completed time
    '0-30 mins low impact, 1 to 2hrs neglible , 2 to 3hrs moderate lastly critiacal 3hrs and up
    'lastly risk taking combo box but leave at it should be

    Private Sub DataGridView2_SelectionChanged(sender As Object, e As EventArgs) Handles DataGridView2.SelectionChanged
        If DataGridView2.SelectedRows.Count > 0 Then
            txt_id.Text = DataGridView2.SelectedRows(0).Cells("id").Value.ToString()
            txt_inputticket.Text = DataGridView2.SelectedRows(0).Cells("ticket_number").Value.ToString()
            txt_TroubleTime.Text = DataGridView2.SelectedRows(0).Cells("trouble_time").Value.ToString()
            txt_CompletedTime.Text = DataGridView2.SelectedRows(0).Cells("completed_time").Value.ToString()
            txt_Level.Text = DataGridView2.SelectedRows(0).Cells("level").Value.ToString()
            combo_RiskRating.Text = DataGridView2.SelectedRows(0).Cells("risk_rating").Value.ToString()
        End If
    End Sub

    Private Sub UpdateIDFromTicketNumber(ticketNumber As String)
        ' Search for the ID based on the entered ticket number
        For Each row As DataGridViewRow In DataGridView2.Rows
            If row.Cells("ticket_number").Value.ToString() = ticketNumber Then
                txt_id.Text = row.Cells("id").Value.ToString()
                Exit Sub ' Exit loop once the ID is found
            End If
        Next

        ' If the ticket number is not found, clear the ID textbox
        txt_id.Text = ""
    End Sub
    Private Sub txt_id_TextChanged(sender As Object, e As EventArgs) Handles txt_id.TextChanged

    End Sub

    Private Sub txt_inputticket_TextChanged(sender As Object, e As EventArgs) Handles txt_inputticket.TextChanged
        ' Call the function to update the ID when the ticket number is changed
        UpdateIDFromTicketNumber(txt_inputticket.Text)
    End Sub

    Private Sub CalculateLevel()
        ' Get the trouble time and completed time entered by the user
        Dim troubleTime As DateTime
        Dim completedTime As DateTime

        If DateTime.TryParse(txt_TroubleTime.Text, troubleTime) AndAlso DateTime.TryParse(txt_CompletedTime.Text, completedTime) Then
            ' Calculate the time duration in minutes
            Dim timeDuration As TimeSpan = completedTime - troubleTime
            Dim durationInMinutes As Integer = CInt(timeDuration.TotalMinutes)

            ' Determine the level based on the time duration
            Dim level As String = ""

            If durationInMinutes <= 30 Then
                level = "Low Impact"
            ElseIf durationInMinutes > 30 AndAlso durationInMinutes <= 120 Then
                level = "Negligible"
            ElseIf durationInMinutes > 120 AndAlso durationInMinutes <= 180 Then
                level = "Moderate"
            Else
                level = "Critical"
            End If

            ' Update the txt_Level text box with the calculated level
            txt_Level.Text = level

        End If
    End Sub

    Private Sub txt_TroubleTime_TextChanged(sender As Object, e As EventArgs) Handles txt_TroubleTime.TextChanged
        ' Call the CalculateLevel function whenever the trouble time is changed
        CalculateLevel()
    End Sub

    Private Sub txt_CompletedTime_TextChanged(sender As Object, e As EventArgs) Handles txt_CompletedTime.TextChanged
        ' Call the CalculateLevel function whenever the completed time is changed
        CalculateLevel()
    End Sub
    Private Sub txt_Level_TextChanged(sender As Object, e As EventArgs) Handles txt_Level.TextChanged

    End Sub

    Private Sub combo_RiskRating_SelectedIndexChanged(sender As Object, e As EventArgs) Handles combo_RiskRating.SelectedIndexChanged

    End Sub


    Private Sub btn_Save2_Click(sender As Object, e As EventArgs) Handles btn_Save2.Click


        Using connection As New MySqlConnection(connectionString)
            connection.Open()

            ' Check if the ticket number exists in the database
            Dim queryCheckTicket As String = "SELECT COUNT(*) FROM tb_mistroublereport WHERE ticket_number = @ticket_number"
            Dim ticketExists As Boolean = False

            Using commandCheckTicket As New MySqlCommand(queryCheckTicket, connection)
                commandCheckTicket.Parameters.AddWithValue("@ticket_number", txt_inputticket.Text)

                Dim countTicket As Integer = Convert.ToInt32(commandCheckTicket.ExecuteScalar())
                ticketExists = (countTicket > 0)
            End Using

            If Not ticketExists Then
                MessageBox.Show("The ticket number does not exist in the database. Cannot save the data.")
                connection.Close()
                Return
            End If

            ' Check if the record with the same ID already exists
            Dim queryCheck As String = "SELECT COUNT(*) FROM tb_mistroublereport WHERE id = @id"
            Dim recordExists As Boolean = False

            Using commandCheck As New MySqlCommand(queryCheck, connection)
                commandCheck.Parameters.AddWithValue("@id", txt_id.Text)

                Dim count As Integer = Convert.ToInt32(commandCheck.ExecuteScalar())
                recordExists = (count > 0)
            End Using

            ' Construct the SQL insert or update query based on record existence
            Dim query As String = ""
            If recordExists Then
                query = "UPDATE tb_mistroublereport SET ticket_number = @ticket_number, trouble_time = @trouble_time, completed_time = @completed_time, level = @level, risk_rating = @risk_rating WHERE id = @id"
            Else
                query = "INSERT INTO tb_mistroublereport (id, ticket_number, trouble_time, completed_time, level, risk_rating) VALUES (@id, @ticket_number, @trouble_time, @completed_time, @level, @risk_rating)"
            End If

            ' Create and configure the MySqlCommand object
            Using command As New MySqlCommand(query, connection)
                command.Parameters.AddWithValue("@id", txt_id.Text)
                command.Parameters.AddWithValue("@ticket_number", txt_inputticket.Text)
                command.Parameters.AddWithValue("@trouble_time", txt_TroubleTime.Text)
                command.Parameters.AddWithValue("@completed_time", txt_CompletedTime.Text)
                Dim level As String = CalculateLevelFromTimes(txt_TroubleTime.Text, txt_CompletedTime.Text)
                command.Parameters.AddWithValue("@level", level)
                command.Parameters.AddWithValue("@risk_rating", combo_RiskRating.SelectedItem.ToString())

                ' Execute the insert or update query
                command.ExecuteNonQuery()

                If recordExists Then
                    MessageBox.Show("Data updated successfully.")
                Else
                    MessageBox.Show("Data saved successfully.")
                End If

                ' Clear the text boxes after saving
                txt_inputticket.Text = ""
                txt_TroubleTime.Text = ""
                txt_CompletedTime.Text = ""
                txt_Level.Text = ""
                combo_RiskRating.SelectedIndex = 0
            End Using

            ' Refresh the DataGridView
            Dim adapter As New MySqlDataAdapter("SELECT * FROM tb_mistroublereport", connection)
            Dim table As New DataTable()
            adapter.Fill(table)
            DataGridView2.DataSource = table

            connection.Close()
        End Using
    End Sub


    Private Function CalculateLevelFromTimes(troubleTime As String, completedTime As String) As String
        ' Calculate the time duration in minutes
        Dim troubleDateTime As DateTime
        Dim completedDateTime As DateTime

        If DateTime.TryParse(troubleTime, troubleDateTime) AndAlso DateTime.TryParse(completedTime, completedDateTime) Then
            Dim timeDuration As TimeSpan = completedDateTime - troubleDateTime
            Dim durationInMinutes As Integer = CInt(timeDuration.TotalMinutes)

            ' Determine the level based on the time duration
            If durationInMinutes <= 30 Then
                Return "Low Impact"
            ElseIf durationInMinutes > 30 AndAlso durationInMinutes <= 120 Then
                Return "Negligible"
            ElseIf durationInMinutes > 120 AndAlso durationInMinutes <= 180 Then
                Return "Moderate"
            Else
                Return "Critical"
            End If
        Else
            ' Return a default level if there are parsing errors
            Return "Unknown"
        End If
    End Function

    Private Sub RadioToday_CheckedChanged(sender As Object, e As EventArgs) Handles RadioToday.CheckedChanged
        If RadioToday.Checked Then
            activeFilter = "today"
            LoadData()
        End If
    End Sub

    Private Sub RadioWeek_CheckedChanged(sender As Object, e As EventArgs) Handles RadioWeek.CheckedChanged
        If RadioWeek.Checked Then
            activeFilter = "week"
            LoadData()
        End If
    End Sub

    Private Sub RadioYear_CheckedChanged(sender As Object, e As EventArgs) Handles RadioYear.CheckedChanged
        If RadioYear.Checked Then
            activeFilter = "year"
            LoadData()
        End If
    End Sub

    Private Sub RadioAll_CheckedChanged(sender As Object, e As EventArgs) Handles RadioAll.CheckedChanged
        If RadioAll.Checked Then
            activeFilter = "all"
            LoadData()
        End If
    End Sub

    ' Method to Load Data Based on Active Filter
    Private Sub LoadData()
        FilterDataGridView(activeFilter)
    End Sub

    ' Method to Filter DataGridView Based on Filter Type
    Private Sub FilterDataGridView(filterType As String)
        Using connection As New MySqlConnection(connectionString)
            connection.Open()

            Dim query As String = "SELECT * FROM tb_mistroublereport"

            Select Case filterType
                Case "today"
                    query &= " WHERE DATE(start_date) = CURDATE()"
                Case "week"
                    query &= " WHERE YEARWEEK(start_date, 1) = YEARWEEK(CURDATE(), 1)"
                Case "year"
                    query &= " WHERE YEAR(start_date) = YEAR(CURDATE())"
            End Select

            Using command As New MySqlCommand(query, connection)
                Dim table As New DataTable()
                Dim adapter As New MySqlDataAdapter(command)
                adapter.Fill(table)

                If table.Rows.Count = 0 Then
                    DataGridView2.DataSource = Nothing
                Else
                    DataGridView2.DataSource = table
                End If
            End Using

            connection.Close()
        End Using
    End Sub

    Private Sub btn_PrintTicket_Click(sender As Object, e As EventArgs) Handles btn_PrintTicket.Click
        If String.IsNullOrEmpty(txt_id.Text) Then
            MessageBox.Show("Please select a ticket to print.", "Print", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        Dim printForm As New FormPrintTicket()
        printForm.ShowTicket(Convert.ToInt32(txt_id.Text))
        printForm.ShowDialog()
    End Sub



#End Region

#Region "Tab4"
    'CONFIG SETTINGS

    Private Sub UpdateConnectionStringAndSave()
        connectionString = $"server={My.Settings.Server};port={My.Settings.Port};database={My.Settings.Database};user={My.Settings.Username};password={My.Settings.Password};"
        My.Settings.Save()
    End Sub

    Private Sub txt_server_TextChanged(sender As Object, e As EventArgs) Handles txt_server.TextChanged
        My.Settings.Server = txt_server.Text
    End Sub

    Private Sub txt_port_TextChanged(sender As Object, e As EventArgs) Handles txt_port.TextChanged
        My.Settings.Port = txt_port.Text
    End Sub

    Private Sub txt_database_TextChanged(sender As Object, e As EventArgs) Handles txt_database.TextChanged
        My.Settings.Database = txt_database.Text
    End Sub

    Private Sub txt_username_TextChanged(sender As Object, e As EventArgs) Handles txt_username.TextChanged
        My.Settings.Username = txt_username.Text
    End Sub

    Private Sub txt_password_TextChanged(sender As Object, e As EventArgs) Handles txt_password.TextChanged
        My.Settings.Password = txt_password.Text
    End Sub

    Private Sub btn_savesettings_Click(sender As Object, e As EventArgs) Handles btn_savesettings.Click
        UpdateConnectionStringAndSave()
        ' Try to open a connection to validate settings
        Try
            Using connection As New MySqlConnection(connectionString)
                connection.Open()
            End Using
            MessageBox.Show("Settings saved and connection successful.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show("Database connection failed: " & ex.Message, "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub TabPage1_Click(sender As Object, e As EventArgs) Handles TabPage1.Click

    End Sub


#End Region



End Class