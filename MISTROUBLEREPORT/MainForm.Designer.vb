<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class MainForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MainForm))
        Me.btn_CreateTicket = New System.Windows.Forms.Button()
        Me.btn_Find = New System.Windows.Forms.Button()
        Me.btn_Settings = New System.Windows.Forms.Button()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.btn_Submit = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txt_Description = New System.Windows.Forms.RichTextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txt_ticketnumber = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txt_Name = New System.Windows.Forms.TextBox()
        Me.combo_Department = New System.Windows.Forms.ComboBox()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.txt_find2 = New System.Windows.Forms.TextBox()
        Me.btn_find1 = New System.Windows.Forms.Button()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.btn_PrintTicket = New System.Windows.Forms.Button()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.btn_Delete = New System.Windows.Forms.Button()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.txt_id = New System.Windows.Forms.TextBox()
        Me.Action_Text_Box = New System.Windows.Forms.RichTextBox()
        Me.btn_Save2 = New System.Windows.Forms.Button()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txt_inputticket = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.combo_RiskRating = New System.Windows.Forms.ComboBox()
        Me.txt_TroubleTime = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txt_CompletedTime = New System.Windows.Forms.TextBox()
        Me.txt_Level = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.RadioAll = New System.Windows.Forms.RadioButton()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.RadioYear = New System.Windows.Forms.RadioButton()
        Me.RadioToday = New System.Windows.Forms.RadioButton()
        Me.RadioWeek = New System.Windows.Forms.RadioButton()
        Me.DataGridView2 = New System.Windows.Forms.DataGridView()
        Me.TabPage4 = New System.Windows.Forms.TabPage()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.btn_ChangePassword = New System.Windows.Forms.Button()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.btn_savesettings = New System.Windows.Forms.Button()
        Me.txt_password = New System.Windows.Forms.TextBox()
        Me.CONFIG = New System.Windows.Forms.Label()
        Me.txt_username = New System.Windows.Forms.TextBox()
        Me.txt_server = New System.Windows.Forms.TextBox()
        Me.txt_database = New System.Windows.Forms.TextBox()
        Me.txt_port = New System.Windows.Forms.TextBox()
        Me.btn_Print = New System.Windows.Forms.Button()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.NotifyIcon1 = New System.Windows.Forms.NotifyIcon(Me.components)
        Me.MySqlCommand1 = New MySql.Data.MySqlClient.MySqlCommand()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.TabPage3.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage4.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.SuspendLayout()
        '
        'btn_CreateTicket
        '
        Me.btn_CreateTicket.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_CreateTicket.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_CreateTicket.Location = New System.Drawing.Point(12, 106)
        Me.btn_CreateTicket.Name = "btn_CreateTicket"
        Me.btn_CreateTicket.Size = New System.Drawing.Size(100, 40)
        Me.btn_CreateTicket.TabIndex = 1
        Me.btn_CreateTicket.Text = "Create Ticket"
        Me.btn_CreateTicket.UseVisualStyleBackColor = True
        '
        'btn_Find
        '
        Me.btn_Find.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_Find.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_Find.Location = New System.Drawing.Point(12, 152)
        Me.btn_Find.Name = "btn_Find"
        Me.btn_Find.Size = New System.Drawing.Size(100, 40)
        Me.btn_Find.TabIndex = 2
        Me.btn_Find.Text = "Find Ticket"
        Me.btn_Find.UseVisualStyleBackColor = True
        '
        'btn_Settings
        '
        Me.btn_Settings.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_Settings.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_Settings.Location = New System.Drawing.Point(12, 244)
        Me.btn_Settings.Name = "btn_Settings"
        Me.btn_Settings.Size = New System.Drawing.Size(100, 40)
        Me.btn_Settings.TabIndex = 3
        Me.btn_Settings.Text = "Settings"
        Me.btn_Settings.UseVisualStyleBackColor = True
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Controls.Add(Me.TabPage3)
        Me.TabControl1.Controls.Add(Me.TabPage4)
        Me.TabControl1.Location = New System.Drawing.Point(118, -21)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(679, 473)
        Me.TabControl1.TabIndex = 4
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.Label17)
        Me.TabPage1.Controls.Add(Me.btn_Submit)
        Me.TabPage1.Controls.Add(Me.Label3)
        Me.TabPage1.Controls.Add(Me.txt_Description)
        Me.TabPage1.Controls.Add(Me.Label2)
        Me.TabPage1.Controls.Add(Me.txt_ticketnumber)
        Me.TabPage1.Controls.Add(Me.Label1)
        Me.TabPage1.Controls.Add(Me.txt_Name)
        Me.TabPage1.Controls.Add(Me.combo_Department)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(671, 428)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "TabPage1"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(286, 25)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(121, 24)
        Me.Label17.TabIndex = 8
        Me.Label17.Text = "Ticket Form"
        '
        'btn_Submit
        '
        Me.btn_Submit.BackColor = System.Drawing.Color.LimeGreen
        Me.btn_Submit.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_Submit.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_Submit.ForeColor = System.Drawing.Color.White
        Me.btn_Submit.Location = New System.Drawing.Point(300, 331)
        Me.btn_Submit.Name = "btn_Submit"
        Me.btn_Submit.Size = New System.Drawing.Size(89, 36)
        Me.btn_Submit.TabIndex = 7
        Me.btn_Submit.Text = "Submit"
        Me.btn_Submit.UseVisualStyleBackColor = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(97, 198)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(137, 16)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Describe the Problem"
        '
        'txt_Description
        '
        Me.txt_Description.BackColor = System.Drawing.Color.LightGray
        Me.txt_Description.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_Description.ForeColor = System.Drawing.SystemColors.InfoText
        Me.txt_Description.HideSelection = False
        Me.txt_Description.Location = New System.Drawing.Point(100, 220)
        Me.txt_Description.Name = "txt_Description"
        Me.txt_Description.Size = New System.Drawing.Size(484, 96)
        Me.txt_Description.TabIndex = 5
        Me.txt_Description.Text = "Type here."
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(242, 133)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(95, 16)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Ticket Number"
        '
        'txt_ticketnumber
        '
        Me.txt_ticketnumber.BackColor = System.Drawing.Color.LightGray
        Me.txt_ticketnumber.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_ticketnumber.Location = New System.Drawing.Point(207, 152)
        Me.txt_ticketnumber.Name = "txt_ticketnumber"
        Me.txt_ticketnumber.ReadOnly = True
        Me.txt_ticketnumber.Size = New System.Drawing.Size(165, 31)
        Me.txt_ticketnumber.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(47, 94)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(47, 16)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Name "
        '
        'txt_Name
        '
        Me.txt_Name.BackColor = System.Drawing.Color.LightGray
        Me.txt_Name.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_Name.Location = New System.Drawing.Point(100, 84)
        Me.txt_Name.Name = "txt_Name"
        Me.txt_Name.Size = New System.Drawing.Size(160, 31)
        Me.txt_Name.TabIndex = 1
        '
        'combo_Department
        '
        Me.combo_Department.BackColor = System.Drawing.Color.LightGray
        Me.combo_Department.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.combo_Department.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.combo_Department.FormattingEnabled = True
        Me.combo_Department.Items.AddRange(New Object() {"Select Department", "HR", "MKK", "CSMC", "LOGISTIC"})
        Me.combo_Department.Location = New System.Drawing.Point(317, 82)
        Me.combo_Department.Name = "combo_Department"
        Me.combo_Department.Size = New System.Drawing.Size(260, 32)
        Me.combo_Department.TabIndex = 0
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.txt_find2)
        Me.TabPage2.Controls.Add(Me.btn_find1)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(671, 447)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "TabPage2"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'txt_find2
        '
        Me.txt_find2.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_find2.Location = New System.Drawing.Point(312, 165)
        Me.txt_find2.Name = "txt_find2"
        Me.txt_find2.Size = New System.Drawing.Size(253, 35)
        Me.txt_find2.TabIndex = 1
        '
        'btn_find1
        '
        Me.btn_find1.BackColor = System.Drawing.Color.SteelBlue
        Me.btn_find1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_find1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btn_find1.ForeColor = System.Drawing.SystemColors.Control
        Me.btn_find1.Location = New System.Drawing.Point(167, 165)
        Me.btn_find1.Name = "btn_find1"
        Me.btn_find1.Size = New System.Drawing.Size(93, 35)
        Me.btn_find1.TabIndex = 0
        Me.btn_find1.Text = "Find"
        Me.btn_find1.UseVisualStyleBackColor = False
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.btn_PrintTicket)
        Me.TabPage3.Controls.Add(Me.Panel2)
        Me.TabPage3.Controls.Add(Me.Panel1)
        Me.TabPage3.Controls.Add(Me.DataGridView2)
        Me.TabPage3.Location = New System.Drawing.Point(4, 22)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage3.Size = New System.Drawing.Size(671, 447)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "TabPage3"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'btn_PrintTicket
        '
        Me.btn_PrintTicket.Location = New System.Drawing.Point(549, 193)
        Me.btn_PrintTicket.Name = "btn_PrintTicket"
        Me.btn_PrintTicket.Size = New System.Drawing.Size(75, 23)
        Me.btn_PrintTicket.TabIndex = 15
        Me.btn_PrintTicket.Text = "Print"
        Me.btn_PrintTicket.UseVisualStyleBackColor = True
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.Khaki
        Me.Panel2.Controls.Add(Me.btn_Delete)
        Me.Panel2.Controls.Add(Me.Label16)
        Me.Panel2.Controls.Add(Me.txt_id)
        Me.Panel2.Controls.Add(Me.Action_Text_Box)
        Me.Panel2.Controls.Add(Me.btn_Save2)
        Me.Panel2.Controls.Add(Me.Label9)
        Me.Panel2.Controls.Add(Me.txt_inputticket)
        Me.Panel2.Controls.Add(Me.Label8)
        Me.Panel2.Controls.Add(Me.combo_RiskRating)
        Me.Panel2.Controls.Add(Me.txt_TroubleTime)
        Me.Panel2.Controls.Add(Me.Label4)
        Me.Panel2.Controls.Add(Me.Label6)
        Me.Panel2.Controls.Add(Me.txt_CompletedTime)
        Me.Panel2.Controls.Add(Me.txt_Level)
        Me.Panel2.Controls.Add(Me.Label5)
        Me.Panel2.Location = New System.Drawing.Point(121, 12)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(511, 215)
        Me.Panel2.TabIndex = 13
        '
        'btn_Delete
        '
        Me.btn_Delete.BackColor = System.Drawing.Color.Red
        Me.btn_Delete.ForeColor = System.Drawing.Color.White
        Me.btn_Delete.Location = New System.Drawing.Point(11, 181)
        Me.btn_Delete.Name = "btn_Delete"
        Me.btn_Delete.Size = New System.Drawing.Size(75, 23)
        Me.btn_Delete.TabIndex = 19
        Me.btn_Delete.Text = "Delete"
        Me.btn_Delete.UseVisualStyleBackColor = False
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(402, 14)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(44, 16)
        Me.Label16.TabIndex = 18
        Me.Label16.Text = "Action"
        '
        'txt_id
        '
        Me.txt_id.Location = New System.Drawing.Point(61, 7)
        Me.txt_id.Name = "txt_id"
        Me.txt_id.ReadOnly = True
        Me.txt_id.Size = New System.Drawing.Size(40, 20)
        Me.txt_id.TabIndex = 17
        Me.txt_id.Visible = False
        '
        'Action_Text_Box
        '
        Me.Action_Text_Box.Location = New System.Drawing.Point(333, 33)
        Me.Action_Text_Box.Name = "Action_Text_Box"
        Me.Action_Text_Box.Size = New System.Drawing.Size(170, 110)
        Me.Action_Text_Box.TabIndex = 16
        Me.Action_Text_Box.Text = ""
        '
        'btn_Save2
        '
        Me.btn_Save2.BackColor = System.Drawing.Color.LimeGreen
        Me.btn_Save2.ForeColor = System.Drawing.Color.White
        Me.btn_Save2.Location = New System.Drawing.Point(147, 181)
        Me.btn_Save2.Name = "btn_Save2"
        Me.btn_Save2.Size = New System.Drawing.Size(75, 23)
        Me.btn_Save2.TabIndex = 16
        Me.btn_Save2.Text = "Save"
        Me.btn_Save2.UseVisualStyleBackColor = False
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(107, 8)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(153, 16)
        Me.Label9.TabIndex = 13
        Me.Label9.Text = "Add Information in Ticket"
        '
        'txt_inputticket
        '
        Me.txt_inputticket.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_inputticket.Location = New System.Drawing.Point(119, 33)
        Me.txt_inputticket.Name = "txt_inputticket"
        Me.txt_inputticket.Size = New System.Drawing.Size(180, 22)
        Me.txt_inputticket.TabIndex = 13
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(17, 39)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(95, 16)
        Me.Label8.TabIndex = 14
        Me.Label8.Text = "Ticket Number"
        '
        'combo_RiskRating
        '
        Me.combo_RiskRating.BackColor = System.Drawing.SystemColors.Info
        Me.combo_RiskRating.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.combo_RiskRating.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.combo_RiskRating.FormattingEnabled = True
        Me.combo_RiskRating.Items.AddRange(New Object() {"Risk Rating", "1X Trouble w/ Low Impact rating per device", "2X Trouble w/ Negligible rating per device", "2X Trouble w/ Moderate rating per device"})
        Me.combo_RiskRating.Location = New System.Drawing.Point(11, 146)
        Me.combo_RiskRating.Name = "combo_RiskRating"
        Me.combo_RiskRating.Size = New System.Drawing.Size(348, 24)
        Me.combo_RiskRating.TabIndex = 7
        '
        'txt_TroubleTime
        '
        Me.txt_TroubleTime.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_TroubleTime.Location = New System.Drawing.Point(119, 63)
        Me.txt_TroubleTime.Name = "txt_TroubleTime"
        Me.txt_TroubleTime.Size = New System.Drawing.Size(180, 22)
        Me.txt_TroubleTime.TabIndex = 0
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(27, 66)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(85, 16)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "TroubleTime"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(68, 121)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(40, 16)
        Me.Label6.TabIndex = 5
        Me.Label6.Text = "Level"
        '
        'txt_CompletedTime
        '
        Me.txt_CompletedTime.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_CompletedTime.Location = New System.Drawing.Point(119, 91)
        Me.txt_CompletedTime.Name = "txt_CompletedTime"
        Me.txt_CompletedTime.Size = New System.Drawing.Size(180, 22)
        Me.txt_CompletedTime.TabIndex = 1
        '
        'txt_Level
        '
        Me.txt_Level.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_Level.Location = New System.Drawing.Point(119, 121)
        Me.txt_Level.Name = "txt_Level"
        Me.txt_Level.ReadOnly = True
        Me.txt_Level.Size = New System.Drawing.Size(180, 22)
        Me.txt_Level.TabIndex = 2
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(8, 94)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(104, 16)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "CompletedTime"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.SkyBlue
        Me.Panel1.Controls.Add(Me.RadioAll)
        Me.Panel1.Controls.Add(Me.Label7)
        Me.Panel1.Controls.Add(Me.RadioYear)
        Me.Panel1.Controls.Add(Me.RadioToday)
        Me.Panel1.Controls.Add(Me.RadioWeek)
        Me.Panel1.Location = New System.Drawing.Point(6, 96)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(81, 131)
        Me.Panel1.TabIndex = 12
        '
        'RadioAll
        '
        Me.RadioAll.AutoSize = True
        Me.RadioAll.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadioAll.Location = New System.Drawing.Point(3, 106)
        Me.RadioAll.Name = "RadioAll"
        Me.RadioAll.Size = New System.Drawing.Size(40, 20)
        Me.RadioAll.TabIndex = 12
        Me.RadioAll.TabStop = True
        Me.RadioAll.Text = "All"
        Me.RadioAll.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(4, 1)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(70, 16)
        Me.Label7.TabIndex = 9
        Me.Label7.Text = "Show Only"
        '
        'RadioYear
        '
        Me.RadioYear.AutoSize = True
        Me.RadioYear.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadioYear.Location = New System.Drawing.Point(3, 80)
        Me.RadioYear.Name = "RadioYear"
        Me.RadioYear.Size = New System.Drawing.Size(54, 20)
        Me.RadioYear.TabIndex = 11
        Me.RadioYear.TabStop = True
        Me.RadioYear.Text = "Year"
        Me.RadioYear.UseVisualStyleBackColor = True
        '
        'RadioToday
        '
        Me.RadioToday.AutoSize = True
        Me.RadioToday.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadioToday.Location = New System.Drawing.Point(3, 27)
        Me.RadioToday.Name = "RadioToday"
        Me.RadioToday.Size = New System.Drawing.Size(65, 20)
        Me.RadioToday.TabIndex = 8
        Me.RadioToday.TabStop = True
        Me.RadioToday.Text = "Today"
        Me.RadioToday.UseVisualStyleBackColor = True
        '
        'RadioWeek
        '
        Me.RadioWeek.AutoSize = True
        Me.RadioWeek.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadioWeek.Location = New System.Drawing.Point(3, 54)
        Me.RadioWeek.Name = "RadioWeek"
        Me.RadioWeek.Size = New System.Drawing.Size(61, 20)
        Me.RadioWeek.TabIndex = 10
        Me.RadioWeek.TabStop = True
        Me.RadioWeek.Text = "Week"
        Me.RadioWeek.UseVisualStyleBackColor = True
        '
        'DataGridView2
        '
        Me.DataGridView2.AllowUserToAddRows = False
        Me.DataGridView2.AllowUserToDeleteRows = False
        Me.DataGridView2.BackgroundColor = System.Drawing.SystemColors.ButtonFace
        Me.DataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView2.Location = New System.Drawing.Point(6, 246)
        Me.DataGridView2.Name = "DataGridView2"
        Me.DataGridView2.ReadOnly = True
        Me.DataGridView2.Size = New System.Drawing.Size(659, 158)
        Me.DataGridView2.TabIndex = 6
        '
        'TabPage4
        '
        Me.TabPage4.Controls.Add(Me.Panel3)
        Me.TabPage4.Location = New System.Drawing.Point(4, 22)
        Me.TabPage4.Name = "TabPage4"
        Me.TabPage4.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage4.Size = New System.Drawing.Size(671, 447)
        Me.TabPage4.TabIndex = 3
        Me.TabPage4.Text = "TabPage4"
        Me.TabPage4.UseVisualStyleBackColor = True
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.btn_ChangePassword)
        Me.Panel3.Controls.Add(Me.Label14)
        Me.Panel3.Controls.Add(Me.Label13)
        Me.Panel3.Controls.Add(Me.Label12)
        Me.Panel3.Controls.Add(Me.Label11)
        Me.Panel3.Controls.Add(Me.Label10)
        Me.Panel3.Controls.Add(Me.btn_savesettings)
        Me.Panel3.Controls.Add(Me.txt_password)
        Me.Panel3.Controls.Add(Me.CONFIG)
        Me.Panel3.Controls.Add(Me.txt_username)
        Me.Panel3.Controls.Add(Me.txt_server)
        Me.Panel3.Controls.Add(Me.txt_database)
        Me.Panel3.Controls.Add(Me.txt_port)
        Me.Panel3.Location = New System.Drawing.Point(6, 6)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(659, 411)
        Me.Panel3.TabIndex = 6
        '
        'btn_ChangePassword
        '
        Me.btn_ChangePassword.Location = New System.Drawing.Point(477, 143)
        Me.btn_ChangePassword.Name = "btn_ChangePassword"
        Me.btn_ChangePassword.Size = New System.Drawing.Size(117, 23)
        Me.btn_ChangePassword.TabIndex = 14
        Me.btn_ChangePassword.Text = "Access Password"
        Me.btn_ChangePassword.UseVisualStyleBackColor = True
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(14, 231)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(53, 13)
        Me.Label14.TabIndex = 11
        Me.Label14.Text = "Password"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(14, 185)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(55, 13)
        Me.Label13.TabIndex = 10
        Me.Label13.Text = "Username"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(14, 138)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(84, 13)
        Me.Label12.TabIndex = 9
        Me.Label12.Text = "Database Name"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(14, 92)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(26, 13)
        Me.Label11.TabIndex = 8
        Me.Label11.Text = "Port"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(14, 44)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(38, 13)
        Me.Label10.TabIndex = 7
        Me.Label10.Text = "Server"
        '
        'btn_savesettings
        '
        Me.btn_savesettings.BackColor = System.Drawing.Color.LimeGreen
        Me.btn_savesettings.ForeColor = System.Drawing.Color.White
        Me.btn_savesettings.Location = New System.Drawing.Point(524, 340)
        Me.btn_savesettings.Name = "btn_savesettings"
        Me.btn_savesettings.Size = New System.Drawing.Size(101, 44)
        Me.btn_savesettings.TabIndex = 6
        Me.btn_savesettings.Text = "Save"
        Me.btn_savesettings.UseVisualStyleBackColor = False
        '
        'txt_password
        '
        Me.txt_password.BackColor = System.Drawing.Color.LightGray
        Me.txt_password.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_password.Location = New System.Drawing.Point(14, 246)
        Me.txt_password.Name = "txt_password"
        Me.txt_password.Size = New System.Drawing.Size(220, 26)
        Me.txt_password.TabIndex = 4
        '
        'CONFIG
        '
        Me.CONFIG.AutoSize = True
        Me.CONFIG.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CONFIG.Location = New System.Drawing.Point(87, 12)
        Me.CONFIG.Name = "CONFIG"
        Me.CONFIG.Size = New System.Drawing.Size(71, 20)
        Me.CONFIG.TabIndex = 5
        Me.CONFIG.Text = "CONFIG"
        '
        'txt_username
        '
        Me.txt_username.BackColor = System.Drawing.Color.LightGray
        Me.txt_username.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_username.Location = New System.Drawing.Point(14, 200)
        Me.txt_username.Name = "txt_username"
        Me.txt_username.Size = New System.Drawing.Size(220, 26)
        Me.txt_username.TabIndex = 3
        '
        'txt_server
        '
        Me.txt_server.BackColor = System.Drawing.Color.LightGray
        Me.txt_server.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_server.Location = New System.Drawing.Point(14, 63)
        Me.txt_server.Name = "txt_server"
        Me.txt_server.Size = New System.Drawing.Size(220, 26)
        Me.txt_server.TabIndex = 0
        '
        'txt_database
        '
        Me.txt_database.BackColor = System.Drawing.Color.LightGray
        Me.txt_database.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_database.Location = New System.Drawing.Point(14, 154)
        Me.txt_database.Name = "txt_database"
        Me.txt_database.Size = New System.Drawing.Size(220, 26)
        Me.txt_database.TabIndex = 2
        '
        'txt_port
        '
        Me.txt_port.BackColor = System.Drawing.Color.LightGray
        Me.txt_port.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_port.Location = New System.Drawing.Point(14, 108)
        Me.txt_port.Name = "txt_port"
        Me.txt_port.Size = New System.Drawing.Size(220, 26)
        Me.txt_port.TabIndex = 1
        '
        'btn_Print
        '
        Me.btn_Print.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btn_Print.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btn_Print.Location = New System.Drawing.Point(12, 198)
        Me.btn_Print.Name = "btn_Print"
        Me.btn_Print.Size = New System.Drawing.Size(100, 40)
        Me.btn_Print.TabIndex = 5
        Me.btn_Print.Text = "Print"
        Me.btn_Print.UseVisualStyleBackColor = True
        '
        'Timer1
        '
        '
        'NotifyIcon1
        '
        Me.NotifyIcon1.Text = "NotifyIcon1"
        Me.NotifyIcon1.Visible = True
        '
        'MySqlCommand1
        '
        Me.MySqlCommand1.CacheAge = 0
        Me.MySqlCommand1.Connection = Nothing
        Me.MySqlCommand1.EnableCaching = False
        Me.MySqlCommand1.Transaction = Nothing
        '
        'MainForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.btn_Print)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.btn_Settings)
        Me.Controls.Add(Me.btn_Find)
        Me.Controls.Add(Me.btn_CreateTicket)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "MainForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "MIS TROUBLE REPORT"
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        Me.TabPage3.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage4.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btn_CreateTicket As Button
    Friend WithEvents btn_Find As Button
    Friend WithEvents btn_Settings As Button
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents TabPage3 As TabPage
    Friend WithEvents btn_Print As Button
    Friend WithEvents TabPage4 As TabPage
    Friend WithEvents combo_Department As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents txt_Name As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents txt_Description As RichTextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents txt_ticketnumber As TextBox
    Friend WithEvents btn_Submit As Button
    Friend WithEvents btn_find1 As Button
    Friend WithEvents txt_find2 As TextBox
    Friend WithEvents txt_TroubleTime As TextBox
    Friend WithEvents txt_Level As TextBox
    Friend WithEvents txt_CompletedTime As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents DataGridView2 As DataGridView
    Friend WithEvents Label6 As Label
    Friend WithEvents combo_RiskRating As ComboBox
    Friend WithEvents Label7 As Label
    Friend WithEvents RadioToday As RadioButton
    Friend WithEvents RadioYear As RadioButton
    Friend WithEvents RadioWeek As RadioButton
    Friend WithEvents Panel1 As Panel
    Friend WithEvents RadioAll As RadioButton
    Friend WithEvents Label8 As Label
    Friend WithEvents txt_inputticket As TextBox
    Friend WithEvents btn_PrintTicket As Button
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Label9 As Label
    Friend WithEvents btn_Save2 As Button
    Friend WithEvents Timer1 As Timer
    Friend WithEvents txt_id As TextBox
    Friend WithEvents txt_server As TextBox
    Friend WithEvents txt_database As TextBox
    Friend WithEvents txt_port As TextBox
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Label14 As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents btn_savesettings As Button
    Friend WithEvents txt_password As TextBox
    Friend WithEvents CONFIG As Label
    Friend WithEvents txt_username As TextBox
    Friend WithEvents NotifyIcon1 As NotifyIcon
    Friend WithEvents MySqlCommand1 As MySql.Data.MySqlClient.MySqlCommand
    Friend WithEvents Action_Text_Box As RichTextBox
    Friend WithEvents Label16 As Label
    Friend WithEvents Label17 As Label
    Friend WithEvents btn_ChangePassword As Button
    Friend WithEvents btn_Delete As Button
End Class
