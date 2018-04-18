Public Class frmReport
    Dim seat_id1 As String
    Dim show_id As Integer
    Dim book1, book2 As Integer

    Private Sub frmReport_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            
            book1 = Booking_window.book1
            book1 = book1 + 1
            book2 = Booking_window.book2

            Dim rpt As New CrystalReport1

            rpt.SetParameterValue(0, book1)
            rpt.SetParameterValue(1, book2)

            'rpt.Load(path & "\resources\CrystalReport1.rpt")
            rpt.DataSourceConnections.Item(0).SetConnection(path & "\resources\movie.booking.accdb", "", False)

            book1 = Booking_window.book1
            book1 = book1 + 1
            book2 = Booking_window.book2

            rpt.SetParameterValue(0, book1)
            rpt.SetParameterValue(1, book2)

            CrystalReportViewer1.ReportSource = rpt
            CrystalReportViewer1.Refresh()

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Report could not be created", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.Close()
        End Try

    End Sub


    Private Sub CrystalReportViewer1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CrystalReportViewer1.Load

    End Sub
End Class