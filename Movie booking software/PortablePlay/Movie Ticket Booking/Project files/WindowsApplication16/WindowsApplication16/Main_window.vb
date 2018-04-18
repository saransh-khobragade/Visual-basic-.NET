Imports System.Data.OleDb
Public Class Main_window
    Public show_id As Integer
    Public day As String
    Private Sub Main_window_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        ComboBox1.Items.Add("Monday")
        ComboBox1.Items.Add("Tuesday")
        ComboBox1.Items.Add("Wednesday")
        ComboBox1.Items.Add("Thursday")
        ComboBox1.Items.Add("Friday")
        ComboBox1.Items.Add("Saturday")
        ComboBox1.Items.Add("Sunday")

        ComboBox1.Text = ComboBox1.Items(0)


    End Sub

    Private Sub myOwnClick(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If day = "" Then
            MsgBox("Please select day of booking first")
        Else
            show_id = sender.tag
            Booking_window.ShowDialog()
            Me.Controls.Clear()
            InitializeComponent()
            day = Booking_window.global1
            display()
            ComboBox1.Text = day
        End If



    End Sub

    Private Sub ClientToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ClientToolStripMenuItem.Click

    End Sub

    Private Sub CreateAuditoriumToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CreateAuditoriumToolStripMenuItem.Click
        create_audi.ShowDialog()
        Me.Controls.Clear()
        InitializeComponent()
        display()
        ComboBox1.Text = day

    End Sub

    Private Sub CreatePoliciesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CreatePoliciesToolStripMenuItem.Click
        Create_policy.ShowDialog()
        Me.Controls.Clear()
        InitializeComponent()
        display()
        ComboBox1.Text = day
    End Sub

    Private Sub DesignAuditoriumToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DesignAuditoriumToolStripMenuItem.Click
        auditorium_design.ShowDialog()
        Me.Controls.Clear()
        InitializeComponent()
        display()

        ComboBox1.Text = day
    End Sub

    Private Sub CreateMoviesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CreateMoviesToolStripMenuItem.Click
        Movie_creation.ShowDialog()
        Me.Controls.Clear()
        InitializeComponent()
        display()
        ComboBox1.Text = day

    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged

        Booking_window.global1 = ComboBox1.SelectedItem
        Me.Controls.Clear()
        InitializeComponent()
        ComboBox1.SelectedText = Booking_window.global1
        If Booking_window.global1 = "" Then
        Else

            day = Booking_window.global1
        End If

        display()


    End Sub
    Public Function display()
        Dim i, j, count1, count2, audi_id, movie_id As Integer
        'Dim con As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & Application.StartupPath & "\movie.booking.accdb")
        Dim da, da2 As OleDbDataAdapter
        Dim ds, ds2 As DataSet
        Dim drstud, drstud2 As OleDbDataReader
        Dim cmd As OleDbCommand



        count1 = 1
        count2 = 2

        conopen()
        Try
            da2 = New OleDbDataAdapter("select movie_id from movie", con)
            ds2 = New DataSet
            da2.Fill(ds2, "stud")
            movie_id = ds2.Tables(0).Rows(0).Item(0)

        Catch ex As Exception
            Label1.Visible = True
        End Try
        da = New OleDbDataAdapter("select movie_name,movie_poster_path from movie", con)
        ds = New DataSet
        da.Fill(ds, "stud")


        For i = 0 To ds.Tables(0).Rows.Count() - 1

            Dim p As New PictureBox
            p.Name = "P" & i + 1
            p.Top = 80
            p.Height = 80
            p.Left = 10 + i * 170
            p.Width = 150
            p.SizeMode = PictureBoxSizeMode.StretchImage
            p.Tag = i + 1
            If ds.Tables(0).Rows(i).Item(1).ToString <> "" Then
                p.Image = Image.FromFile(ds.Tables(0).Rows(i).Item(1).ToString)
            End If

            Me.Controls.Add(p)

            Dim k As New Label
            k.Name = "L" & i + 1
            k.Text = ds.Tables(0).Rows(i).Item(0).ToString
            k.Top = 160
            k.Height = 20
            k.Left = 10 + i * 170
            k.Width = 150
            k.Tag = i + 1
            k.ForeColor = Color.White
            'AddHandler k.Click, AddressOf myOwnClick
            Me.Controls.Add(k)




            da2 = New OleDbDataAdapter("select show_start_timing from show where movie_id=" & i + movie_id & "", con)
            ds2 = New DataSet
            da2.Fill(ds2, "stud")

            For j = 0 To ds2.Tables(0).Rows.Count() - 1



                Dim t As New Button

                t.Text = ds2.Tables(0).Rows(j).Item(0).ToString
                t.Top = 180
                t.Height = 20
                t.Left = (10 + j * 37) + (i) * 170
                t.Width = 35
                t.Name = "T" & j
                cmd = New OleDbCommand("select audi_id from booking where show_id=" & j + 1 + ((i) * 4) & "", con)
                drstud = cmd.ExecuteReader()
                drstud.Read()
                If drstud.HasRows Then
                    audi_id = drstud(0)
                    cmd = New OleDbCommand("select count(seat_id) from audi_info where audi_id=" & audi_id & " and seat_status='Available'", con)
                    drstud = cmd.ExecuteReader()
                    drstud.Read()
                    count1 = drstud(0)
                    cmd = New OleDbCommand("select count(seat_id) from booking where day1='" & day & "' and show_id=" & j + 1 + ((i) * 4) & "", con)
                    drstud = cmd.ExecuteReader()
                    drstud.Read()
                    count2 = drstud(0)
                End If


                If count1 = count2 Then
                    t.BackColor = Color.Red
                Else
                    t.BackColor = Color.Green
                End If

                count1 = 1
                count2 = 2

                t.ForeColor = Color.White
                t.Tag = j + 1 + ((i) * 4)

                AddHandler t.Click, AddressOf myOwnClick
                Me.Controls.Add(t)
            Next j


        Next i
        con.Close()
        ComboBox1.Items.Add("Monday")
        ComboBox1.Items.Add("Tuesday")
        ComboBox1.Items.Add("Wednesday")
        ComboBox1.Items.Add("Thursday")
        ComboBox1.Items.Add("Friday")
        ComboBox1.Items.Add("Saturday")
        ComboBox1.Items.Add("Sunday")
        PictureBox1.Image = Image.FromFile(path & "\resources\logo.png")
    End Function

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)



    End Sub

    Private Sub TaxInsertionToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TaxInsertionToolStripMenuItem.Click
        Tax_insert.ShowDialog()
        Me.Controls.Clear()
        InitializeComponent()
        display()
        ComboBox1.Text = day
    End Sub

    Private Sub ComboBox1_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedValueChanged
      

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim cmd As OleDbCommand
        conopen()
        cmd = New OleDbCommand("delete * from booking", con)
        cmd.ExecuteNonQuery()
        con.Close()
        MsgBox("All booking history cleared")
        Me.Controls.Clear()
        InitializeComponent()
        display()
        ComboBox1.Text = ComboBox1.Items(0)
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Dim cmd As OleDbCommand
        conopen()
        cmd = New OleDbCommand("delete * from movie", con)
        cmd.ExecuteNonQuery()
        con.Close()
        MsgBox("All Movies cleared")
        Me.Controls.Clear()
        InitializeComponent()
        display()
        ComboBox1.Text = ComboBox1.Items(0)
    End Sub

    Private Sub GuidehowToUseThisSoftwareToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GuidehowToUseThisSoftwareToolStripMenuItem.Click
        guide.ShowDialog()

    End Sub

  
   
    Private Sub PictureBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox1.Click

    End Sub
End Class