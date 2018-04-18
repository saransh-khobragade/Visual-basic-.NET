Imports System.Data.OleDb
Public Class Movie_creation
    Public show_id, audi_id, movie_id As Integer
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If TextBox1.Text = "" Or TextBox2.Text = "" Or TextBox3.Text = "" Or TextBox4.Text = "" Or ComboBox1.Text = "" Then
            MsgBox("Sorry cant add,No fields should be empty")
        Else
            Dim da As OleDbDataAdapter
            Dim cmd As OleDbCommand
            Dim ds As DataSet

            conopen()
            Try
                da = New OleDbDataAdapter("select max(movie_id) from movie", con)
                ds = New DataSet
                da.Fill(ds, "stud")
                movie_id = Val(ds.Tables(0).Rows(0).Item(0).ToString()) + 1
                cmd = New OleDbCommand("insert into movie(movie_id,audi_id,movie_name,dateofrelease,movie_lenght,movie_interval,movie_poster_path) values(" & Val(ds.Tables(0).Rows(0).Item(0).ToString()) + 1 & "," & ComboBox1.SelectedItem & ",'" & TextBox1.Text & "','" & DateTimePicker1.Value.Date & "'," & TextBox3.Text & "," & TextBox2.Text & ",'" & TextBox4.Text & "')", con)
                cmd.ExecuteNonQuery()
                MsgBox("Movie information saved")

                Button2.Enabled = True
                Button1.Enabled = False
                TextBox1.Enabled = False
                TextBox2.Enabled = False
                TextBox3.Enabled = False
                TextBox4.Enabled = False
                ComboBox1.Enabled = False
                DateTimePicker1.Enabled = False
                con.Close()

            Catch ex As Exception
                MsgBox("Can't add movie with same name,auditorium no. or same poster already provided.")
            End Try
             End If
       
    End Sub

    Private Sub Movie_creation_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Button1.Enabled = True
        Button2.Enabled = True
        Button3.Enabled = True
        Button4.Enabled = True
        ComboBox1.Enabled = True
        TextBox1.Enabled = True
        TextBox2.Enabled = True
        TextBox3.Enabled = True
        TextBox4.Enabled = True

        ComboBox1.Items.Clear()

        ' Dim con As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & Application.StartupPath & "\movie.booking.accdb")
        Dim da As OleDbDataAdapter
        Dim ds As DataSet

        'If con.State <> ConnectionState.Open Then
        '    con.Open()
        'End If
        conopen()

        da = New OleDbDataAdapter("select audi_id from auditorium", con)
        ds = New DataSet
        da.Fill(ds, "stud")
        For i = 0 To ds.Tables(0).Rows.Count() - 1
            ComboBox1.Items.Add(ds.Tables(0).Rows(i).Item(0).ToString)
        Next
        con.Close()

        Try
            ComboBox1.Text = ComboBox1.Items(0)
        Catch ex As Exception
            MsgBox("Atleast one auditorium should be created for movies.Please create one.")
            Me.Close()
        End Try
        
        Button2.Enabled = False

    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged
        'Dim con As New OleDbConnection
        Dim cmd As OleDbCommand
        Dim drstud As OleDbDataReader
        'con.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & Application.StartupPath & "\movie.booking.accdb"
        'If con.State <> ConnectionState.Open Then
        '    con.Open()
        'End If
        conopen()


        cmd = New OleDbCommand("select * from movie where audi_id=" & ComboBox1.SelectedItem & "", con)
        drstud = cmd.ExecuteReader()
        drstud.Read()
        If drstud.HasRows Then
            TextBox1.Text = drstud(3)
            DateTimePicker1.Value = drstud(4)
            TextBox2.Text = drstud(5)
            TextBox3.Text = drstud(6)
            TextBox4.Text = drstud(7)
            PictureBox1.Image = Image.FromFile(drstud(7))
        End If
        con.Close()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click

        'Dim con As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & Application.StartupPath & "\movie.booking.accdb")
        Dim da As OleDbDataAdapter
        Dim ds As DataSet
        Dim cmd As OleDbCommand
        Dim str As String
        Dim gap As Integer
        'If con.State <> ConnectionState.Open Then
        '    con.Open()
        'End If
        conopen()


        da = New OleDbDataAdapter("select audi_time_of_showstart from auditorium where audi_id=" & ComboBox1.SelectedItem & "", con)
        ds = New DataSet
        da.Fill(ds, "stud")
        str = ds.Tables(0).Rows(0).Item(0).ToString

        da = New OleDbDataAdapter("select audi_show_gap from auditorium where audi_id=" & ComboBox1.SelectedItem & "", con)
        ds = New DataSet
        da.Fill(ds, "stud")
        gap = ds.Tables(0).Rows(0).Item(0)



        Dim a, i As Integer
        a = minutes(str.Substring(10, 5))

        For i = 1 To 4
            da = New OleDbDataAdapter("select max(show_id) from show", con)
            ds = New DataSet
            da.Fill(ds, "stud")
            show_id = Val(ds.Tables(0).Rows(0).Item(0).ToString) + 1



            cmd = New OleDbCommand("insert into show(show_id,audi_id,movie_id,show_start_timing) values(" & show_id & "," & ComboBox1.SelectedItem & "," & movie_id & ",'" & time(a) & "')", con)
            cmd.ExecuteNonQuery()
            a = a + Val(gap) + Val(TextBox2.Text) + Val(TextBox3.Text)

        Next
        MsgBox("Show created/Refreshed")

        con.Close()
        Button1.Enabled = True
        Button2.Enabled = False
        TextBox1.Enabled = True
        TextBox2.Enabled = True
        TextBox3.Enabled = True
        TextBox4.Enabled = True
        ComboBox1.Enabled = True
        Button4.Enabled = True
        DateTimePicker1.Enabled = True

    End Sub
    Public Function time(ByRef a As Integer) As String
        Dim min As Integer
        Dim hours As Integer

        If a < 60 Then
            hours = 0
            min = a
        Else
            hours = a \ 60
            min = a - hours * 60


        End If
        Return hours & ":" & min
    End Function
    Public Function minutes(ByRef a As String) As Integer
        Dim str As String
        Dim hours As Integer
        Dim min As Integer
        str = a

        hours = Val(str.Substring(0, 2))

        min = Val(str.Substring(3, 2))

        min = min + hours * 60
        Return min
    End Function

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Dim file As New OpenFileDialog
        OpenFileDialog1.ShowDialog()
        TextBox4.Text = OpenFileDialog1.FileName
        Try
            PictureBox1.Image = Image.FromFile(OpenFileDialog1.FileName)
        Catch ex As Exception

        End Try


    End Sub

    Private Sub PictureBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox1.Click

    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        'Dim con As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & Application.StartupPath & "\movie.booking.accdb")
        Dim da As OleDbDataAdapter
        Dim cmd As OleDbCommand
        Dim ds As DataSet

        'If con.State <> ConnectionState.Open Then
        '    con.Open()
        'End If
        conopen()
        Try
            da = New OleDbDataAdapter("select movie_id from movie where audi_id=" & ComboBox1.SelectedIndex + 1 & "", con)
            ds = New DataSet
            da.Fill(ds, "stud")
            movie_id = Val(ds.Tables(0).Rows(0).Item(0).ToString())

            cmd = New OleDbCommand("update movie set movie_name='" & TextBox1.Text & "',dateofrelease='" & DateTimePicker1.Value.Date & "',movie_lenght=" & TextBox3.Text & ",movie_interval=" & TextBox2.Text & ",movie_poster_path='" & TextBox4.Text & "' where audi_id=" & ComboBox1.SelectedItem & "", con)
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox("Can't update movie with same name already provided.")
        End Try
        
        Try
            cmd = New OleDbCommand("delete from show where audi_id=" & ComboBox1.SelectedItem & "", con)
            cmd.ExecuteNonQuery()

            MsgBox("Movie information updated")

            Button2.Enabled = True
            Button1.Enabled = False
            TextBox1.Enabled = False
            TextBox2.Enabled = False
            TextBox3.Enabled = False
            TextBox4.Enabled = False
            ComboBox1.Enabled = False
            DateTimePicker1.Enabled = False
            Button4.Enabled = False
            con.Close()
        Catch ex As Exception
            MsgBox("panga")
        End Try

    End Sub
End Class