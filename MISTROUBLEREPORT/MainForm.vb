Imports MySql.Data.MySqlClient
Imports System.Data

Public Class MainForm
    Dim connectionString As String

    Private activeFilter As String = "all"

    ' Form Load Event
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TabControl1.Anchor = AnchorStyles.Top Or AnchorStyles.Left
        MaximizeBox = False
        combo_Department.SelectedIndex = 0
        combo_RiskRating.SelectedIndex = 0
        txt_password.UseSystemPasswordChar = True

        ' Load saved settings to textboxes
        LoadSettings()

        ' Build connection string from settings
        connectionString = $"server={txt_server.Text};port={txt_port.Text};database={txt_database.Text};user={txt_username.Text};password={txt_password.Text};"
        ModuleConnection.connectionString = connectionString

        ' Try to connect and check table
        Try
            Using connection As New MySqlConnection(connectionString)
                connection.Open()

                ' Check if the required table exists
                Dim checkTableQuery As String = "
                SELECT COUNT(*) 
                FROM information_schema.tables 
                WHERE table_schema = @db AND table_name = 'tb_mistroublereport';
            "

                Dim tableExists As Boolean = False
                Using cmd As New MySqlCommand(checkTableQuery, connection)
                    cmd.Parameters.AddWithValue("@db", My.Settings.Database)
                    tableExists = Convert.ToInt32(cmd.ExecuteScalar()) > 0
                End Using

                ' Ask to create the table if not found
                If Not tableExists Then
                    Dim response = MessageBox.Show("The table 'tb_mistroublereport' does not exist. Do you want to create it now?", "Missing Table", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                    If response = DialogResult.Yes Then
                        Dim createTableQuery As String = "
                        CREATE TABLE tb_mistroublereport (
                          id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
                          start_date DATETIME NOT NULL,
                          name VARCHAR(40) NOT NULL,
                          department VARCHAR(30) DEFAULT NULL,
                          ticket_number VARCHAR(50) NOT NULL,
                          description TEXT,
                          trouble_time DATETIME DEFAULT NULL,
                          completed_time DATETIME DEFAULT NULL,
                          level VARCHAR(20) DEFAULT NULL,
                          risk_rating VARCHAR(50) DEFAULT NULL,
                          action_description TEXT
                        ) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;
                    "

                        Using createCmd As New MySqlCommand(createTableQuery, connection)
                            createCmd.ExecuteNonQuery()
                        End Using

                        MessageBox.Show("Table created successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Else
                        MessageBox.Show("Startup aborted. Table is required.", "Startup Halted", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        TabControl1.SelectedIndex = 3 ' Go to Settings tab
                        Return
                    End If
                End If

                ' Load any data needed into controls
                LoadData()

            End Using
        Catch ex As Exception
            MessageBox.Show("Database connection failed: " & ex.Message & vbCrLf & "Please check your settings.", "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            TabControl1.SelectedIndex = 3 ' Go to Settings tab
        End Try
    End Sub


    Private Sub LoadSettings()
        txt_server.Text = My.Settings.Server
        txt_port.Text = My.Settings.Port
        txt_database.Text = My.Settings.Database
        txt_username.Text = My.Settings.Username
        txt_password.Text = My.Settings.Password

        connectionString = $"server={My.Settings.Server};port={My.Settings.Port};database={My.Settings.Database};user={My.Settings.Username};password={My.Settings.Password};"
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

    Private Sub btn_Print_Click(sender As Object, e As EventArgs) Handles btn_Print.Click
        Dim passwordEntryForm As New PasswordEntryForm()
        If passwordEntryForm.ShowDialog() = DialogResult.OK Then
            Dim inputPassword As String = passwordEntryForm.EnteredPassword
            Dim correctPassword As String = My.Settings.AdminPassword

            If inputPassword = correctPassword Then
                TabControl1.SelectedIndex = 2
            Else
                MessageBox.Show("Incorrect password. Access denied.", "Password Incorrect", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End If
    End Sub


    Private Sub btn_Settings_Click(sender As Object, e As EventArgs) Handles btn_Settings.Click
        TabControl1.SelectedIndex = 3
    End Sub

    Private Sub StyleDataGridView()
        With DataGridView2
            ' Alternating row colors
            .AlternatingRowsDefaultCellStyle.BackColor = Color.LightGray
            .RowsDefaultCellStyle.BackColor = Color.White

            ' Grid and header styles
            .GridColor = Color.DarkGray
            .BorderStyle = BorderStyle.Fixed3D
            .EnableHeadersVisualStyles = False

            ' Header style
            .ColumnHeadersDefaultCellStyle.Font = New Font("Segoe UI", 10, FontStyle.Bold)
            .ColumnHeadersDefaultCellStyle.BackColor = Color.SteelBlue
            .ColumnHeadersDefaultCellStyle.ForeColor = Color.White
            .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .ColumnHeadersHeight = 35

            ' Row selection style
            .DefaultCellStyle.SelectionBackColor = Color.LightSteelBlue
            .DefaultCellStyle.SelectionForeColor = Color.Black

            ' Font and layout
            .DefaultCellStyle.Font = New Font("Segoe UI", 10)
            .RowTemplate.Height = 28
            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            .AllowUserToAddRows = False
            .AllowUserToResizeRows = False
            .ReadOnly = True
        End With
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

        ' Check if department is selected
        If combo_Department.SelectedIndex = 0 OrElse combo_Department.SelectedItem Is Nothing Then
            MessageBox.Show("Please select a department.", "Submit Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        Dim department As String = combo_Department.SelectedItem.ToString()

        ' Validate name field
        If String.IsNullOrWhiteSpace(name) Then
            MessageBox.Show("Please enter a name.", "Submit Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        Using connection As New MySqlConnection(connectionString)
            connection.Open()

            Dim query As String = "INSERT INTO tb_mistroublereport (start_date, name, ticket_number, description, department) VALUES (@start_date, @name, @ticket_number, @description, @department)"

            Using command As New MySqlCommand(query, connection)
                command.Parameters.AddWithValue("@start_date", startDate)
                command.Parameters.AddWithValue("@name", name)
                command.Parameters.AddWithValue("@ticket_number", ticketNumber)
                command.Parameters.AddWithValue("@description", description)
                command.Parameters.AddWithValue("@department", department)

                command.ExecuteNonQuery()
            End Using

            ' Refresh DataGridView
            Dim adapter As New MySqlDataAdapter("SELECT * FROM tb_mistroublereport", connection)
            Dim table As New DataTable()
            adapter.Fill(table)
            DataGridView2.DataSource = table

            connection.Close()
        End Using

        ' Copy ticket number to clipboard
        Clipboard.SetText(ticketNumber)

        ' Show confirmation
        MessageBox.Show("Ticket submitted successfully!" & vbCrLf & "Ticket Number: " & ticketNumber & vbCrLf & "It has been copied to the clipboard.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

        ' Clear input fields
        txt_Name.Text = ""
        txt_ticketnumber.Text = ""
        txt_Description.Text = ""
        combo_Department.SelectedIndex = 0
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

                If table.Rows.Count > 0 Then
                    Dim row As DataRow = table.Rows(0)
                    Dim ticketNumber As String = row("ticket_number").ToString()
                    Dim startDate As DateTime = Convert.ToDateTime(row("start_date"))
                    Dim name As String = row("name").ToString()
                    Dim description As String = row("description").ToString()
                    Dim completedTime As Object = row("completed_time")

                    ' Build ticket info
                    Dim ticketInfo As String = $"Ticket Number: {ticketNumber}{Environment.NewLine}" &
                                           $"Start Date: {startDate}{Environment.NewLine}" &
                                           $"Name: {name}{Environment.NewLine}" &
                                           $"Description: {description}"

                    ' Add ticket status
                    If Not IsDBNull(completedTime) AndAlso Not String.IsNullOrWhiteSpace(completedTime.ToString()) Then
                        ticketInfo &= $"{Environment.NewLine}Status: Ticket Closed"
                    Else
                        ticketInfo &= $"{Environment.NewLine}Status: Ticket Open"
                    End If

                    MessageBox.Show(ticketInfo, "Ticket Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Else
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

        btn_Delete.Enabled = DataGridView2.SelectedRows.Count > 0

        If DataGridView2.SelectedRows.Count > 0 Then
            txt_id.Text = DataGridView2.SelectedRows(0).Cells("id").Value.ToString()
            txt_inputticket.Text = DataGridView2.SelectedRows(0).Cells("ticket_number").Value.ToString()
            txt_TroubleTime.Text = DataGridView2.SelectedRows(0).Cells("trouble_time").Value.ToString()
            txt_CompletedTime.Text = DataGridView2.SelectedRows(0).Cells("completed_time").Value.ToString()
            txt_Level.Text = DataGridView2.SelectedRows(0).Cells("level").Value.ToString()
            combo_RiskRating.Text = DataGridView2.SelectedRows(0).Cells("risk_rating").Value.ToString()
            Action_Text_Box.Text = DataGridView2.SelectedRows(0).Cells("action_description").Value.ToString()
        End If
        If DataGridView2.Columns.Contains("id") Then
            DataGridView2.Columns("id").Visible = False
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

    Private Sub Action_Text_Box_TextChanged(sender As Object, e As EventArgs) Handles Action_Text_Box.TextChanged

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

            ' Convert and validate times
            Dim troubleTime As DateTime
            Dim completedTime As DateTime

            If Not DateTime.TryParse(txt_TroubleTime.Text, troubleTime) OrElse Not DateTime.TryParse(txt_CompletedTime.Text, completedTime) Then
                MessageBox.Show("Please enter valid time values (e.g., 11:00 AM).")
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

            ' Construct SQL query
            Dim query As String = If(recordExists,
           "UPDATE tb_mistroublereport SET ticket_number = @ticket_number, trouble_time = @trouble_time, completed_time = @completed_time, level = @level, risk_rating = @risk_rating, action_description = @action_description WHERE id = @id",
           "INSERT INTO tb_mistroublereport (id, ticket_number, trouble_time, completed_time, level, risk_rating, action_description) VALUES (@id, @ticket_number, @trouble_time, @completed_time, @level, @risk_rating, @action_description)")

            ' Create and configure MySqlCommand
            Using command As New MySqlCommand(query, connection)
                command.Parameters.AddWithValue("@id", txt_id.Text)
                command.Parameters.AddWithValue("@ticket_number", txt_inputticket.Text)
                command.Parameters.AddWithValue("@trouble_time", DateTime.Today.Add(troubleTime.TimeOfDay))
                command.Parameters.AddWithValue("@completed_time", DateTime.Today.Add(completedTime.TimeOfDay))
                Dim level As String = CalculateLevelFromTimes(txt_TroubleTime.Text, txt_CompletedTime.Text)
                command.Parameters.AddWithValue("@level", level)
                command.Parameters.AddWithValue("@risk_rating", combo_RiskRating.SelectedItem.ToString())
                command.Parameters.AddWithValue("@action_description", Action_Text_Box.Text)
                command.ExecuteNonQuery()

                MessageBox.Show(If(recordExists, "Data updated successfully.", "Data saved successfully."))

                ' Clear fields
                txt_inputticket.Text = ""
                txt_TroubleTime.Text = ""
                txt_CompletedTime.Text = ""
                txt_Level.Text = ""
                Action_Text_Box.Text = ""
                combo_RiskRating.SelectedIndex = 0
            End Using

            ' Refresh DataGridView
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

        ModuleConnection.connectionString = $"server={My.Settings.Server};port={My.Settings.Port};database={My.Settings.Database};user={My.Settings.Username};password=;"

        Dim printForm As New FormPrintTicket()
        printForm.ShowTicket(Convert.ToInt32(txt_id.Text))
        printForm.ShowDialog()
    End Sub

    Private Sub btn_Delete_Click(sender As Object, e As EventArgs) Handles btn_Delete.Click
        If DataGridView2.SelectedRows.Count = 0 Then
            MessageBox.Show("Please select a row to delete.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        ' Ask for password
        Dim passwordEntryForm As New PasswordEntryForm()
        If passwordEntryForm.ShowDialog() <> DialogResult.OK Then Return

        Dim inputPassword As String = passwordEntryForm.EnteredPassword
        Dim correctPassword As String = My.Settings.AdminPassword

        If inputPassword <> correctPassword Then
            MessageBox.Show("Incorrect password. Deletion denied.", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        ' Confirm deletion
        Dim confirmResult As DialogResult = MessageBox.Show("Are you sure you want to delete the selected entry?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
        If confirmResult <> DialogResult.Yes Then Return

        ' Perform deletion
        Dim selectedId As Integer = Convert.ToInt32(DataGridView2.SelectedRows(0).Cells("id").Value)

        Using connection As New MySqlConnection(connectionString)
            connection.Open()
            Dim deleteQuery As String = "DELETE FROM tb_mistroublereport WHERE id = @id"

            Using command As New MySqlCommand(deleteQuery, connection)
                command.Parameters.AddWithValue("@id", selectedId)
                command.ExecuteNonQuery()
            End Using

            MessageBox.Show("Record deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Using

        ' Refresh data
        LoadData()

        ' Clear fields
        txt_id.Text = ""
        txt_inputticket.Text = ""
        txt_TroubleTime.Text = ""
        txt_CompletedTime.Text = ""
        txt_Level.Text = ""
        combo_RiskRating.SelectedIndex = 0
        Action_Text_Box.Text = ""
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

        Try
            Using connection As New MySqlConnection(connectionString)
                connection.Open()

                ' ✅ Check if the table exists
                Dim checkTableQuery As String = "
                SELECT COUNT(*) 
                FROM information_schema.tables 
                WHERE table_schema = @database AND table_name = 'tb_mistroublereport';
            "

                Dim tableExists As Boolean = False

                Using checkCmd As New MySqlCommand(checkTableQuery, connection)
                    checkCmd.Parameters.AddWithValue("@database", My.Settings.Database)
                    tableExists = Convert.ToInt32(checkCmd.ExecuteScalar()) > 0
                End Using

                ' ⚠️ If not exists, ask to create
                If Not tableExists Then
                    Dim result As DialogResult = MessageBox.Show(
                        "The table 'tb_mistroublereport' was not found in the database. Do you want to create it?",
                        "Table Not Found",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question
                    )

                    If result = DialogResult.Yes Then
                        Dim createTableQuery As String = "
                        CREATE TABLE tb_mistroublereport (
                          id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
                          start_date DATETIME NOT NULL,
                          name VARCHAR(40) NOT NULL,
                          department VARCHAR(30) DEFAULT NULL,
                          ticket_number VARCHAR(50) NOT NULL,
                          description TEXT,
                          trouble_time DATETIME DEFAULT NULL,
                          completed_time DATETIME DEFAULT NULL,
                          level VARCHAR(20) DEFAULT NULL,
                          risk_rating VARCHAR(50) DEFAULT NULL,
                          action_description TEXT
                        ) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;
                    "

                        Using createCmd As New MySqlCommand(createTableQuery, connection)
                            createCmd.ExecuteNonQuery()
                        End Using

                        MessageBox.Show("Table created successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Else
                        MessageBox.Show("Table creation skipped. You may encounter errors if the table is required.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    End If
                End If

            End Using

            MessageBox.Show("Settings saved and connection successful.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Catch ex As Exception
            MessageBox.Show("Database connection failed: " & ex.Message, "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btn_ChangePassword_Click(sender As Object, e As EventArgs) Handles btn_ChangePassword.Click
        Dim changeForm As New ChangePasswordForm()
        changeForm.ShowDialog()
    End Sub


#End Region



End Class