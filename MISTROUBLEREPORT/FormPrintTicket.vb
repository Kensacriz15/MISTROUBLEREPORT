Imports MySql.Data.MySqlClient

Public Class FormPrintTicket
    Public Sub ShowTicket(ticketId As Integer)
        Dim connStr As String = ModuleConnection.connectionString
        Dim ds As New TroubleReportDataset()
        Dim rpt As New TicketReport()


        Using connection As New MySqlConnection(ModuleConnection.connectionString)
            Dim query As String = "SELECT * FROM tb_mistroublereport WHERE id = @id"
            Using da As New MySqlDataAdapter(query, connection)
                da.SelectCommand.Parameters.AddWithValue("@id", ticketId)
                da.Fill(ds.tb_mistroublereport)
            End Using
        End Using

        rpt.SetDataSource(ds)

        CrystalReportViewer1.ReportSource = Nothing
        CrystalReportViewer1.ReportSource = rpt
        CrystalReportViewer1.RefreshReport()

    End Sub
End Class



