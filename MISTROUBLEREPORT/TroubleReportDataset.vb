Partial Public Class TroubleReportDataset
    Partial Public Class tb_mistroublereportDataTable
        Private Sub tb_mistroublereportDataTable_ColumnChanging(sender As Object, e As DataColumnChangeEventArgs) Handles Me.ColumnChanging
            If (e.Column.ColumnName = Me.idColumn.ColumnName) Then
                'Add user code here
            End If

        End Sub

    End Class
End Class

