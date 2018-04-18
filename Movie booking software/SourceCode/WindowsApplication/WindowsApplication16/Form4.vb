Imports System.Data.OleDb
Public Class Form4
    Dim audi As Integer
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)



    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        'Dim drstud As OleDbDataReader
        Dim con As New OleDbConnection
        Dim cmd As OleDbCommand
        con.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Saransh\Documents\movie.booking.accdb"
        If con.State <> ConnectionState.Open Then
            con.Open()
        End If

        cmd = New OleDbCommand("insert into auditorium(audi_rows,audi_columns,audi_time_of_showstart,audi_show_gap) values(" & Val(TextBox1.Text) & "," & Val(TextBox2.Text) & "," & Val(TextBox3.Text) & "," & Val(TextBox4.Text) & ")", con)
        cmd.ExecuteNonQuery()
        audi = DataGridView1.RowCount() - 1
        con.Close()

        Dim da As OleDbDataAdapter
        Dim ds As DataSet
        If con.State <> ConnectionState.Open Then
            con.Open()
        End If
        da = New OleDbDataAdapter("select * from auditorium", con)
        ds = New DataSet
        da.Fill(ds, "stud")
        DataGridView1.DataSource = ds.Tables(0)
        con.Close()
    End Sub

    Private Sub Form4_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim con As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Saransh\Documents\movie.booking.accdb")
        Dim da As OleDbDataAdapter
        Dim ds As DataSet
        If con.State <> ConnectionState.Open Then
            con.Open()
        End If
        da = New OleDbDataAdapter("select * from auditorium", con)
        ds = New DataSet
        da.Fill(ds, "stud")
        DataGridView1.DataSource = ds.Tables(0)
        audi = DataGridView1.RowCount
        con.Close()
        Label6.Text = "For Audi no. " & audi & " Enter below"

    End Sub

    Private Sub Label2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label2.Click

    End Sub

    Private Sub Label6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label6.Click

    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Dim update As Integer
        Dim con As New OleDbConnection
        Dim cmd As OleDbCommand
        con.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Saransh\Documents\movie.booking.accdb"
        If con.State <> ConnectionState.Open Then
            con.Open()
        End If


        Dim da As OleDbDataAdapter
        Dim ds As DataSet
        da = New OleDbDataAdapter("select audi_id from auditorium", con)
        ds = New DataSet
        da.Fill(ds, "stud")
        update = ds.Tables(0).Rows(DataGridView1.CurrentCell.RowIndex).Item(0)

        cmd = New OleDbCommand("update auditorium set audi_rows=" & Val(TextBox1.Text) & ",audi_columns=" & Val(TextBox2.Text) & ",audi_time_of_showstart=" & Val(TextBox3.Text) & ",audi_show_gap=" & Val(TextBox4.Text) & "  where audi_id=" & update, con)
        cmd.ExecuteNonQuery()
        audi = DataGridView1.RowCount() - 1
        con.Close()

        If con.State <> ConnectionState.Open Then
            con.Open()
        End If
        da = New OleDbDataAdapter("select * from auditorium", con)
        ds = New DataSet
        da.Fill(ds, "stud")
        DataGridView1.DataSource = ds.Tables(0)
        con.Close()
    End Sub
End Class