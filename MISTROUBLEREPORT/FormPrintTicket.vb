Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared

Public Class FormPrintTicket
    Public Sub ShowTicket(ticketId As Integer)
        Dim report As New TicketReport() ' This is your .rpt file's class

        ' Set up connection info from your app settings
        Dim connInfo As New ConnectionInfo()
        connInfo.ServerName = My.Settings.Server
        connInfo.DatabaseName = My.Settings.Database
        connInfo.UserID = My.Settings.Username
        connInfo.Password = My.Settings.Password
        connInfo.Type = ConnectionInfoType.SQL
        connInfo.IntegratedSecurity = False

        ' Apply connection info to all tables in the report
        For Each table As Table In report.Database.Tables
            Dim logonInfo As TableLogOnInfo = table.LogOnInfo
            logonInfo.ConnectionInfo = connInfo
            table.ApplyLogOnInfo(logonInfo)
        Next

        ' Set the parameter for the ticket ID
        report.SetParameterValue("id", ticketId)

        CrystalReportViewer1.ReportSource = report
        CrystalReportViewer1.Refresh()
    End Sub
End Class