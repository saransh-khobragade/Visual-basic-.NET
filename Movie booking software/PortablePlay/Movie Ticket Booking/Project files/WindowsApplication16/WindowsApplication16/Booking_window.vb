Imports System.Data.OleDb
Public Class Booking_window
    Dim rows As Integer
    Dim columns As Integer
    Public book1, book2 As Integer
    Public audi_id, show_id, policy_id As Integer
    Public day1 As String
    Public global1 As String
    Public book_flag As Integer


    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
      
            Dim i, j, flag As Integer
            flag = 0

            For i = 0 To rows - 1
                For j = 0 To columns
                    If DataGridView1.Rows(i).Cells(j).Selected = True Then
                        If DataGridView1.Rows(i).Cells(j).Style.Tag = 2 Then
                            MsgBox("Seats are unavailable")
                            book_flag = 0
                            flag = 1
                            Exit For
                        End If
                    End If
                Next
                If flag = 1 Then
                    Exit For
                End If
            Next

            For i = 0 To rows - 1
                For j = 1 To columns
                    If DataGridView1.Rows(i).Cells(j).Selected = True Then
                        If DataGridView1.Rows(i).Cells(j).Style.Tag = 3 Then
                            MsgBox("Already booked")
                            flag = 2
                            book_flag = 0
                            Exit For
                        End If
                    End If
                Next
                If flag = 2 Then
                    Exit For
                End If
            Next

            If flag = 0 Then
                For i = 0 To rows - 1
                    For j = 1 To columns
                        If DataGridView1.Rows(i).Cells(j).Selected = True Then
                            If DataGridView1.Rows(i).Cells(j).Style.Tag = 2 Then
                            Else
                                DataGridView1.Rows(i).Cells(j).Style.Tag = 3
                                DataGridView1.Rows(i).Cells(j).Value = Image.FromFile(redimage())
                            End If
                        End If
                    Next
                Next
                MsgBox("Selected seats are booked")
                book_flag = 1
            End If

            'Dim con As New OleDbConnection
            Dim cmd As OleDbCommand
            Dim da As OleDbDataAdapter
            Dim ds As DataSet
            Dim booking_id, tax, cost, net As Integer

            'con.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & Application.StartupPath & "\movie.booking.accdb"
            'If con.State <> ConnectionState.Open Then
            '    con.Open()
            'End If
            conopen()

            da = New OleDbDataAdapter("select sum(tax_value) from tax", con)
            ds = New DataSet
            da.Fill(ds, "stud")
            tax = Val(ds.Tables(0).Rows(0).Item(0).ToString)



            For i = 0 To rows - 1
                For j = 1 To columns
                    If book_flag <> 0 Then
                        If DataGridView1.Rows(i).Cells(j).Selected = True Then
                            If DataGridView1.Rows(i).Cells(j).Style.Tag = 3 Then
                                da = New OleDbDataAdapter("select max(booking_id) from booking", con)
                                ds = New DataSet
                                da.Fill(ds, "stud")
                                booking_id = Val(ds.Tables(0).Rows(0).Item(0).ToString) + 1

                                da = New OleDbDataAdapter("SELECT policy_id from audi_info where seat_id='" & Chr(65 + i) & "" & j & "' and audi_id=" & audi_id & "", con)
                                ds = New DataSet
                                da.Fill(ds, "stud")
                                policy_id = Val(ds.Tables(0).Rows(0).Item(0).ToString)


                                da = New OleDbDataAdapter("SELECT policy_rate from audi_policy as A,audi_info as B where A.policy_id=B.policy_id and A.day1='" & day1 & "' and B.seat_id='" & Chr(65 + i) & "" & j & "' and B.audi_id=" & audi_id & "", con)
                                ds = New DataSet
                                da.Fill(ds, "stud")
                                net = Val(ds.Tables(0).Rows(0).Item(0).ToString)
                                cost = net + net * (tax / 100)


                                cmd = New OleDbCommand("insert into booking(booking_id,audi_id,seat_id,policy_id,show_id,cost,time1,date1,day1,net_cost) values(" & booking_id & "," & audi_id & ",'" & Chr(65 + i) & "" & j & "'," & policy_id & "," & show_id & "," & cost & ",'" & DateTime.Now().ToLongTimeString & "','" & Now().Date & "','" & day1 & "'," & net & ")", con)
                                cmd.ExecuteNonQuery()

                                da = New OleDbDataAdapter("select max(booking_Id) from booking", con)
                                ds = New DataSet
                                da.Fill(ds, "stud")
                                book2 = ds.Tables(0).Rows(0).Item(0).ToString

                            End If
                        End If
                    End If


                Next
            Next




            con.Close()
            If book_flag = 1 Then
                Button2.Enabled = True
                Button1.Enabled = False
            End If


        
    End Sub

    Private Sub DataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub

    Private Sub Form2_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        PictureBox1.Image = Image.FromFile(path & "\resources\screen.gif")
        DataGridView1.Rows.Clear()
        DataGridView1.Columns.Clear()
        book1 = -1
        book2 = -1

        day1 = Main_window.day

        Dim da As OleDbDataAdapter
        Dim ds As DataSet


        da = New OleDbDataAdapter("select show_id from show", con)
        ds = New DataSet
        da.Fill(ds, "stud")
        show_id = ds.Tables(0).Rows(0).Item(0) + (Main_window.show_id - 1)

        da = New OleDbDataAdapter("select audi_id from show where show_id=" & show_id & "", con)
        ds = New DataSet
        da.Fill(ds, "stud")
        audi_id = ds.Tables(0).Rows(0).Item(0)

        da = New OleDbDataAdapter("select policy_id from audi_info where audi_id=" & audi_id & " and seat_status='Available' and policy_id=0", con)
        ds = New DataSet
        da.Fill(ds, "stud")

        Try
            If ds.Tables(0).Rows(0).Item(0) = 0 Then
                MsgBox("Policies are not clearly defined for this auditorium yet,please define policies first at auditorium design")

                Me.Close()
            End If

        Catch ex As Exception
        End Try
        
        Label2.Text = audi_id

       

        da = New OleDbDataAdapter("select * from auditorium where audi_id=" & audi_id & "", con)
        ds = New DataSet
        da.Fill(ds, "stud")
        rows = ds.Tables(0).Rows(0).Item(2).ToString
        columns = ds.Tables(0).Rows(0).Item(3).ToString
        con.Close()

        Dim dgColDisc1 As New DataGridViewTextBoxColumn
        dgColDisc1.HeaderText = "row"
        DataGridView1.Columns.Add(dgColDisc1)
        dgColDisc1.Width = 20
        For i = 1 To columns
            Dim dgColDisc As New DataGridViewImageColumn
            dgColDisc.HeaderText = (i)
            dgColDisc.Width = 40
            DataGridView1.Columns.Add(dgColDisc)
        Next

        DataGridView1.AllowUserToAddRows = False
        For j = 1 To rows
            DataGridView1.Rows.Add()
            DataGridView1.Rows(j - 1).Height = 40
            DataGridView1.Rows(j - 1).Cells(0).Value = Chr(64 + j)
            DataGridView1.Rows(j - 1).Cells(0).Style.BackColor = Color.Azure

        Next


        conopen()


        For i = 0 To rows - 1
            For j = 0 To columns

                DataGridView1.Rows(i).Cells(j).Style.Tag = 1
                DataGridView1.Rows(i).Cells(j).Value = Image.FromFile(greenimage())


            Next
        Next

        Dim drstud As OleDbDataReader
        Dim cmd As OleDbCommand

        conopen()


        For i = 0 To rows - 1
            For j = 1 To columns

                cmd = New OleDbCommand("select seat_id from booking where seat_id='" & Chr(65 + i) & "" & j & "' and audi_id=" & audi_id & " and show_id=" & show_id & " and day1='" & day1 & "' ", con)
                drstud = cmd.ExecuteReader()
                If drstud.HasRows Then
                    DataGridView1.Rows(i).Cells(j).Style.Tag = 3
                    DataGridView1.Rows(i).Cells(j).Value = Image.FromFile(redimage())
                End If

                cmd = New OleDbCommand("select seat_status,policy_id from audi_info where seat_id='" & Chr(65 + i) & "" & j & "' and audi_id=" & audi_id & "", con)
                drstud = cmd.ExecuteReader()
                drstud.Read()
                If drstud.HasRows Then
                    If drstud(0) = "Unavailable" Then
                        DataGridView1.Rows(i).Cells(j).Style.Tag = 2
                        DataGridView1.Rows(i).Cells(j).Value = Image.FromFile(whiteimage())
                    End If
                    If drstud(1) = 1 Then
                        DataGridView1.Rows(i).Cells(j).Style.BackColor = Color.PaleGoldenrod
                    ElseIf drstud(1) = 2 Then
                        DataGridView1.Rows(i).Cells(j).Style.BackColor = Color.Silver
                    ElseIf drstud(1) = 3 Then
                        DataGridView1.Rows(i).Cells(j).Style.BackColor = Color.LightSkyBlue
                    End If
                Else
                    MsgBox("thier is no audi info")
                End If

            Next
        Next


        da = New OleDbDataAdapter("select max(booking_Id) from booking", con)
        ds = New DataSet
        da.Fill(ds, "stud")
        book1 = Val(ds.Tables(0).Rows(0).Item(0).ToString)
        book2 = Val(ds.Tables(0).Rows(0).Item(0).ToString)

        con.Close()

        For j = 1 To rows
            DataGridView1.Rows(j - 1).Height = 40
            DataGridView1.Rows(j - 1).Cells(0).Value = Chr(64 + j)
            DataGridView1.Rows(j - 1).Cells(0).Style.BackColor = Color.Azure
        Next
        Button1.Enabled = True
        Button2.Enabled = False
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        frmReport.ShowDialog()

        Dim da As OleDbDataAdapter
        Dim ds As DataSet
        da = New OleDbDataAdapter("select max(booking_Id) from booking where audi_id=" & audi_id & " and show_id=" & show_id & "", con)
        ds = New DataSet
        da.Fill(ds, "stud")
        book1 = Val(ds.Tables(0).Rows(0).Item(0).ToString)

        Button1.Enabled = True
        Button2.Enabled = False


    End Sub
End Class
