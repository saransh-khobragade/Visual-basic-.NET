Imports System.Data.OleDb
Public Class auditorium_design
    Dim rows As Integer
    Dim columns As Integer
    Dim audi_id As Integer

    Private Sub Label1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim allow, audi_count As Integer
        allow = 1
        Dim i, j As Integer

        For i = 0 To rows - 1
            For j = 1 To columns

                If DataGridView1.Rows(i).Cells(j).Style.Tag = 1 Then

                    If DataGridView1.Rows(i).Cells(j).Style.BackColor = Color.White Then

                        allow = 0
                    End If

                End If
            Next
        Next

        If allow = 1 Then
            Dim row_count As Integer
            Dim da As OleDbDataAdapter
            Dim ds As DataSet

            Dim cmd As OleDbCommand
            Dim count As Integer

            conopen()


            row_count = 0
            da = New OleDbDataAdapter("select count(audi_id) from auditorium", con)
            ds = New DataSet
            da.Fill(ds, "stud")
            audi_count = ds.Tables(0).Rows(0).Item(0)

            da = New OleDbDataAdapter("select * from auditorium", con)
            ds = New DataSet
            da.Fill(ds, "stud")
            For i = 0 To audi_count - 1
                row_count = row_count + (ds.Tables(0).Rows(i).Item(2) * ds.Tables(0).Rows(i).Item(3))
            Next

            da = New OleDbDataAdapter("select count(seat_id) from audi_info", con)
            ds = New DataSet
            da.Fill(ds, "stud")
            count = ds.Tables(0).Rows(0).Item(0).ToString


            For i = 0 To rows - 1
                For j = 1 To columns

                    If DataGridView1.Rows(i).Cells(j).Style.Tag = 2 Then


                        cmd = New OleDbCommand("update audi_info set seat_status='Unavailable',policy_id=0 where seat_id='" & Chr(65 + i) & "" & j & "' and audi_id=" & audi_id & "", con)
                        cmd.ExecuteNonQuery()

                    ElseIf DataGridView1.Rows(i).Cells(j).Style.Tag = 1 Then

                        cmd = New OleDbCommand("update audi_info set seat_status='Available' where seat_id='" & Chr(65 + i) & "" & j & "' and audi_id=" & audi_id & "", con)
                        cmd.ExecuteNonQuery()
                    End If
                Next
            Next
            Dim save As Integer
            For i = 0 To rows - 1
                For j = 1 To columns
                    If DataGridView1.Rows(i).Cells(j).Style.Tag = 1 Then
                        If DataGridView1.Rows(i).Cells(j).Style.BackColor = Color.PaleGoldenrod Then


                            cmd = New OleDbCommand("update audi_info set policy_id=1 where seat_id='" & Chr(65 + i) & "" & j & "' and audi_id=" & audi_id & "", con)
                            cmd.ExecuteNonQuery()

                        ElseIf DataGridView1.Rows(i).Cells(j).Style.BackColor = Color.Silver Then

                            cmd = New OleDbCommand("update audi_info set policy_id=2 where seat_id='" & Chr(65 + i) & "" & j & "' and audi_id=" & audi_id & "", con)
                            cmd.ExecuteNonQuery()
                        ElseIf DataGridView1.Rows(i).Cells(j).Style.BackColor = Color.LightSkyBlue Then

                            cmd = New OleDbCommand("update audi_info set policy_id=3 where seat_id='" & Chr(65 + i) & "" & j & "' and audi_id=" & audi_id & "", con)
                            cmd.ExecuteNonQuery()
                        End If
                    End If

                Next
            Next

            MsgBox("All information saved")
            allow = 0
            con.Close()
        Else
            MsgBox("Every seat policy must be defined")
        End If

    End Sub

    Private Sub DataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Dim i, j As Integer

        For i = 0 To rows - 1
            For j = 0 To columns
                If DataGridView1.Rows(i).Cells(j).Selected = True Then
                    If DataGridView1.Rows(i).Cells(j).Style.Tag = 1 Then
                        DataGridView1.Rows(i).Cells(j).Value = Image.FromFile(blackimage())
                        DataGridView1.Rows(i).Cells(j).Style.Tag = 2
                        DataGridView1.Rows(i).Cells(j).Style.BackColor = Color.White
                    Else
                        MsgBox("Selected seats are already Unavailable")
                        Exit Sub
                    End If

                End If
            Next
        Next
        MsgBox("Selected seats are now Unavailable")
    End Sub

    Private Sub Form1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        PictureBox1.Image = Image.FromFile(path & "\resources\screen.gif")
        Dim audi_count, audi_first As Integer

        Dim da As OleDbDataAdapter
        Dim ds As DataSet
        DataGridView1.Rows.Clear()
        DataGridView1.Columns.Clear()

       
        conopen()


        da = New OleDbDataAdapter("select count(audi_id) from auditorium", con)
        ds = New DataSet
        da.Fill(ds, "stud")
        audi_count = ds.Tables(0).Rows(0).Item(0)
        audi_id = 1

        For i = 0 To audi_count - 1

            Dim k As New Button
            k.Text = "Auditorium " & i + 1
            k.Top = 10
            k.Name = "Audi"
            k.Height = 30
            k.Left = 200 + i * 110
            k.Width = 100
            k.Tag = i + 1
            If i + 1 = audi_id Then
                k.BackColor = Color.LightGray
            End If

            AddHandler k.Click, AddressOf myOwnClick



            Me.Controls.Add(k)


        Next
        Try
            da = New OleDbDataAdapter("select audi_id from auditorium", con)
            ds = New DataSet
            da.Fill(ds, "stud")
            audi_first = ds.Tables(0).Rows(0).Item(0)

            da = New OleDbDataAdapter("select * from auditorium", con)
            ds = New DataSet
            da.Fill(ds, "stud")
            rows = ds.Tables(0).Rows(0).Item(2).ToString
            columns = ds.Tables(0).Rows(0).Item(3).ToString
            audi_id = ds.Tables(0).Rows(0).Item(1).ToString
            con.Close()
        Catch ex As Exception
            MsgBox("No Auditorium created yet..")
            Me.Close()

        End Try





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



        Dim drstud As OleDbDataReader
        Dim cmd As OleDbCommand
     
        conopen()

        For i = 0 To rows - 1
            For j = 1 To columns

                cmd = New OleDbCommand("select seat_status from audi_info where seat_id='" & Chr(65 + i) & "" & j & "' and audi_id=" & audi_id & "", con)
                drstud = cmd.ExecuteReader()
                drstud.Read()

                If drstud(0) = "Unavailable" Then

                    DataGridView1.Rows(i).Cells(j).Style.Tag = 2
                    DataGridView1.Rows(i).Cells(j).Value = Image.FromFile(blackimage())

                Else
                    DataGridView1.Rows(i).Cells(j).Style.Tag = 1
                    DataGridView1.Rows(i).Cells(j).Value = Image.FromFile(greenimage())
                End If


            Next
        Next

        For i = 0 To rows - 1
            For j = 1 To columns

                cmd = New OleDbCommand("select seat_status,policy_id from audi_info where seat_id='" & Chr(65 + i) & "" & j & "' and audi_id=" & audi_id & "", con)
                drstud = cmd.ExecuteReader()
                drstud.Read()
                If drstud(1) = 1 Then
                    DataGridView1.Rows(i).Cells(j).Style.BackColor = Color.PaleGoldenrod
                ElseIf drstud(1) = 2 Then
                    DataGridView1.Rows(i).Cells(j).Style.BackColor = Color.Silver
                ElseIf drstud(1) = 3 Then
                    DataGridView1.Rows(i).Cells(j).Style.BackColor = Color.LightSkyBlue
                Else
                    DataGridView1.Rows(i).Cells(j).Style.BackColor = Color.White

                End If

            Next
        Next

        Dim row1 As Integer
     
        conopen()
        Try
            da = New OleDbDataAdapter("select count(policy_id) from show_policy", con)
            ds = New DataSet
            da.Fill(ds, "stud")
            row1 = ds.Tables(0).Rows(0).Item(0)
            da = New OleDbDataAdapter("select policy_name from show_policy", con)
            ds = New DataSet
            da.Fill(ds, "stud")
            ComboBox1.Items.Clear()
            For i = 0 To row1 - 1
                ComboBox1.Items.Add(ds.Tables(0).Rows(i).Item(0).ToString)
            Next
            ComboBox1.Text = ComboBox1.Items(0)
        Catch ex As Exception
            MsgBox("No policies created yet.")
            Me.Close()

        End Try

        con.Close()

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        For i = 0 To rows - 1
            For j = 1 To columns
                DataGridView1.Rows(i).Cells(j).Style.Tag = 1
                DataGridView1.Rows(i).Cells(j).Style.BackColor = Color.White
                DataGridView1.Rows(i).Cells(j).Value = Image.FromFile(greenimage())
            Next
        Next
    End Sub



    Private Sub myOwnClick(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            Timer1.Enabled = True
          
            For Each Audi As Button In Me.Controls.OfType(Of Button)()
                If Audi.BackColor = Color.White Then
                    Audi.BackColor = Color.LightGray
                End If
            Next
            sender.backcolor = Color.White

            audi_id = sender.tag
            DataGridView1.Rows.Clear()
            DataGridView1.Columns.Clear()

            Dim drstud2 As OleDbDataReader
            Dim cmd As OleDbCommand
            Dim da As OleDbDataAdapter
            Dim ds As DataSet
         
            conopen()
            da = New OleDbDataAdapter("select audi_id from auditorium", con)
            ds = New DataSet
            da.Fill(ds, "stud")
            audi_id = audi_id + (ds.Tables(0).Rows(0).Item(0) - 1)

            da = New OleDbDataAdapter("select * from auditorium where audi_id=" & audi_id & "", con)
            ds = New DataSet
            da.Fill(ds, "stud")

            rows = ds.Tables(0).Rows(0).Item(2)
            columns = ds.Tables(0).Rows(0).Item(3)

            con.Close()

            DataGridView1.Rows.Clear()
            DataGridView1.Columns.Clear()

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


            For j = 1 To rows
                DataGridView1.Rows.Add()
                DataGridView1.Rows(j - 1).Height = 40
                DataGridView1.Rows(j - 1).Cells(0).Value = Chr(64 + j)
                DataGridView1.Rows(j - 1).Cells(0).Style.BackColor = Color.Azure
            Next

            con.Close()

            If con.State <> ConnectionState.Open Then
                con.Open()
            End If



            For i = 0 To rows - 1
                For j = 1 To columns

                    cmd = New OleDbCommand("select seat_status,policy_id from audi_info where seat_id='" & Chr(65 + i) & "" & j & "' and audi_id=" & audi_id & "", con)
                    drstud2 = cmd.ExecuteReader()
                    drstud2.Read()

                    If drstud2(0) = "Unavailable" Then

                        DataGridView1.Rows(i).Cells(j).Style.Tag = 2
                        DataGridView1.Rows(i).Cells(j).Value = Image.FromFile(blackimage())

                    Else
                        DataGridView1.Rows(i).Cells(j).Style.Tag = 1
                        DataGridView1.Rows(i).Cells(j).Value = Image.FromFile(greenimage())
                    End If

                    cmd = New OleDbCommand("select seat_status,policy_id from audi_info where seat_id='" & Chr(65 + i) & "" & j & "' and audi_id=" & audi_id & "", con)
                    drstud2 = cmd.ExecuteReader()
                    drstud2.Read()
                    If drstud2(1) = 1 Then
                        DataGridView1.Rows(i).Cells(j).Style.BackColor = Color.PaleGoldenrod
                    ElseIf drstud2(1) = 2 Then
                        DataGridView1.Rows(i).Cells(j).Style.BackColor = Color.Silver
                    ElseIf drstud2(1) = 3 Then
                        DataGridView1.Rows(i).Cells(j).Style.BackColor = Color.LightSkyBlue
                    Else
                        DataGridView1.Rows(i).Cells(j).Style.BackColor = Color.White
                    End If



                Next
            Next

            con.Close()
            Timer1.Enabled = False
            MsgBox("You have selected  Auditorium" & audi_id & "")
        Catch ex As Exception
            MsgBox("You are selecting too fast,click again")
            Me.Close()

        End Try
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Dim i, j, sel As Integer
        conopen()
        Dim da As OleDbDataAdapter
        Dim ds As DataSet
        da = New OleDbDataAdapter("select policy_id from show_policy where policy_name='" & ComboBox1.Text & "'", con)
        ds = New DataSet
        da.Fill(ds, "stud")
        sel = ds.Tables(0).Rows(0).Item(0).ToString

        For i = 0 To rows - 1
            For j = 0 To columns
                If DataGridView1.Rows(i).Cells(j).Selected = True And DataGridView1.Rows(i).Cells(j).Style.Tag = 1 And sel = 1 Then
                    DataGridView1.Rows(i).Cells(j).Style.BackColor = Color.PaleGoldenrod
                End If
                If DataGridView1.Rows(i).Cells(j).Selected = True And DataGridView1.Rows(i).Cells(j).Style.Tag = 1 And sel = 2 Then
                    DataGridView1.Rows(i).Cells(j).Style.BackColor = Color.Silver
                End If
                If DataGridView1.Rows(i).Cells(j).Selected = True And DataGridView1.Rows(i).Cells(j).Style.Tag = 1 And sel = 3 Then
                    DataGridView1.Rows(i).Cells(j).Style.BackColor = Color.LightSkyBlue
                End If
            Next
        Next
        MsgBox("Selected seats are now are of " & ComboBox1.SelectedItem & " policy")

    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)


    End Sub

    Private Sub Timer1_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Timer1.Tick

    End Sub

    Private Sub BackgroundWorker1_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs)

    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged

    End Sub
End Class
