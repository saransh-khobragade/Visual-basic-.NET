Imports System.Data.OleDb
Public Class create_audi
    Dim audi As Integer

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim audi_id As Integer
        ' Dim con As New OleDbConnection
        Dim cmd As OleDbCommand
        Dim da As OleDbDataAdapter
        Dim ds As DataSet

        'con.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & Application.StartupPath & "\movie.booking.accdb"
        'If con.State <> ConnectionState.Open Then
        '    con.Open()
        'End If
        conopen()


        da = New OleDbDataAdapter("select max(audi_id) from auditorium", con)
        ds = New DataSet
        da.Fill(ds, "stud")
        audi_id = Val(ds.Tables(0).Rows(0).Item(0).ToString) + 1
        cmd = New OleDbCommand("insert into auditorium(audi_id,audi_rows,audi_columns,audi_time_of_showstart,audi_show_gap) values(" & audi_id & "," & Val(TextBox1.Text) & "," & Val(TextBox2.Text) & ",'" & DateTimePicker1.Value & "'," & Val(TextBox4.Text) & ")", con)

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



        Dim j As Integer
        For i = 1 To Val(TextBox1.Text)
            For j = 1 To Val(TextBox2.Text)
                cmd = New OleDbCommand("insert into audi_info(audi_id,seat_id,seat_status,time1,date1,seat_cost,tax_id,policy_id) values(" & audi_id & ",'" & Chr(64 + i) & "" & j & "','Available',1,1,1,1,0)", con)
                cmd.ExecuteNonQuery()
            Next
        Next
        MsgBox("New Auditorium created")
        con.Close()
    End Sub

    Private Sub Form4_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Dim con As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & Application.StartupPath & "\movie.booking.accdb")
        Dim da As OleDbDataAdapter
        Dim ds As DataSet
        'If con.State <> ConnectionState.Open Then
        '    con.Open()
        'End If
        conopen()

        da = New OleDbDataAdapter("select * from auditorium", con)
        ds = New DataSet
        da.Fill(ds, "stud")
        DataGridView1.DataSource = ds.Tables(0)
        DataGridView1.Columns(0).Visible = False
        DataGridView1.AllowUserToAddRows = False
        audi = DataGridView1.RowCount
        con.Close()
        Label6.Text = "For Audi no. " & audi & " Enter below"
        DateTimePicker1.Format = DateTimePickerFormat.Custom
        DateTimePicker1.CustomFormat = "HH:mm"
    End Sub

    Private Sub Label2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label2.Click

    End Sub

    Private Sub Label6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label6.Click

    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Dim update As Integer
        Dim cmd As OleDbCommand
        conopen()


        Dim da As OleDbDataAdapter
        Dim ds As DataSet
        da = New OleDbDataAdapter("select audi_id from auditorium", con)
        ds = New DataSet
        da.Fill(ds, "stud")
        update = ds.Tables(0).Rows(DataGridView1.CurrentCell.RowIndex).Item(0)

        cmd = New OleDbCommand("update auditorium set audi_rows=" & Val(TextBox1.Text) & ",audi_columns=" & Val(TextBox2.Text) & ",audi_time_of_showstart='" & DateTimePicker1.Value.Hour & ":" & DateTimePicker1.Value.Minute & "',audi_show_gap=" & Val(TextBox4.Text) & "  where audi_id=" & update, con)
        cmd.ExecuteNonQuery()
        audi = DataGridView1.RowCount() - 1
        con.Close()

        conopen()

        da = New OleDbDataAdapter("select * from auditorium", con)
        ds = New DataSet
        da.Fill(ds, "stud")
        DataGridView1.DataSource = ds.Tables(0)
        DataGridView1.AllowUserToAddRows = False
        con.Close()
    End Sub

    Private Sub DataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        frmReport.Show()

    End Sub

    Private Sub DataGridView1_CellMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles DataGridView1.CellMouseClick
        Dim current As Integer
        current = DataGridView1.CurrentCell.RowIndex

        Dim cmd As OleDbCommand
        Dim drstud As OleDbDataReader
       
        conopen()

        cmd = New OleDbCommand("select * from auditorium where audi_id=" & current + 1 & "", con)
        drstud = cmd.ExecuteReader()
        drstud.Read()
        TextBox1.Text = drstud(2)
        TextBox2.Text = drstud(3)
        DateTimePicker1.Value = drstud(4)
        TextBox4.Text = drstud(5)
        con.Close()
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        'Form6.Show()
        'Me.Close()

    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        Dim update As Integer
        Dim cmd As OleDbCommand
      
        conopen()


        Dim da As OleDbDataAdapter
        Dim ds As DataSet
        da = New OleDbDataAdapter("select audi_id from auditorium", con)
        ds = New DataSet
        da.Fill(ds, "stud")
        update = ds.Tables(0).Rows(DataGridView1.CurrentCell.RowIndex).Item(0)

        cmd = New OleDbCommand("delete from auditorium where audi_id=" & update, con)
        cmd.ExecuteNonQuery()

        audi = DataGridView1.RowCount() - 1
        con.Close()

        conopen()

        da = New OleDbDataAdapter("select * from auditorium", con)
        ds = New DataSet
        da.Fill(ds, "stud")
        DataGridView1.DataSource = ds.Tables(0)
        DataGridView1.AllowUserToAddRows = False
        con.Close()
    End Sub
End Class