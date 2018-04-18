Imports System.Data.OleDb
Public Class Form2
    Dim rows As Integer
    Dim columns As Integer

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim i, j, flag As Integer
        flag = 0
        For i = 0 To Val(6)
            For j = 0 To Val(20)
                If DataGridView1.Rows(i).Cells(j).Selected = True Then
                    If DataGridView1.Rows(i).Cells(j).Style.BackColor = Color.Black Then
                        MsgBox("seats are unavailable")
                        flag = 1
                        Exit For
                    End If
                End If
            Next
            If flag = 1 Then
                Exit For
            End If
        Next

        For i = 0 To Val(6) - 1
            For j = 0 To Val(20) - 1
                If DataGridView1.Rows(i).Cells(j).Selected = True Then
                    If DataGridView1.Rows(i).Cells(j).Style.BackColor = Color.Red Then
                        MsgBox("already booked")
                        flag = 2
                        Exit For
                    End If
                End If
            Next
            If flag = 2 Then
                Exit For
            End If
        Next

        If flag = 0 Then
            For i = 0 To Val(6)
                For j = 0 To Val(20)
                    If DataGridView1.Rows(i).Cells(j).Selected = True Then
                        If DataGridView1.Rows(i).Cells(j).Style.BackColor = Color.Black Then
                        Else
                            DataGridView1.Rows(i).Cells(j).Style.BackColor = Color.Red
                        End If
                    End If
                Next
            Next
            MsgBox("selected seats are booked")
        End If

        Dim con As New OleDbConnection
        Dim cmd As OleDbCommand
        con.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Saransh\Documents\movie.booking.accdb"
        If con.State <> ConnectionState.Open Then
            con.Open()
        End If

        For i = 0 To rows
            For j = 0 To columns
                If DataGridView1.Rows(i).Cells(j).Style.BackColor = Color.Red Then
                    cmd = New OleDbCommand("update audi_info set seat_status='booked' where seat_id='" & Chr(65 + i) & "" & j & "' ", con)
                    cmd.ExecuteNonQuery()
                End If
            Next
        Next
        con.Close()

    End Sub

    Private Sub DataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub

    Private Sub Form2_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim con As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Saransh\Documents\movie.booking.accdb")
        Dim da As OleDbDataAdapter
        Dim ds As DataSet
        If con.State <> ConnectionState.Open Then
            con.Open()
        End If
        da = New OleDbDataAdapter("select * from auditorium where audi_id=122", con)
        ds = New DataSet
        da.Fill(ds, "stud")
        rows = ds.Tables(0).Rows(0).Item(1).ToString
        columns = ds.Tables(0).Rows(0).Item(2).ToString
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


        For j = 1 To rows
            DataGridView1.Rows.Add()
            DataGridView1.Rows(j - 1).Height = 40
            DataGridView1.Rows(j - 1).Cells(0).Value = Chr(64 + j)
            DataGridView1.Rows(j - 1).Cells(0).Style.BackColor = Color.Azure

        Next

       

        If con.State <> ConnectionState.Open Then
            con.Open()
        End If

        For i = 0 To rows - 1
            For j = 0 To columns

                DataGridView1.Rows(i).Cells(j).Style.BackColor = Color.Green


            Next
        Next

        For i = 0 To rows - 1
            For j = 1 To columns
                If j < columns Then
                    da = New OleDbDataAdapter("select seat_status from audi_info where seat_id='" & Chr(65 + i) & "" & j & "' ", con)
                    ds = New DataSet
                    da.Fill(ds, "stud")
                    ' MsgBox(ds.Tables(0).Rows(0).Item(0).ToString)

                    If ds.Tables(0).Rows(0).Item(0).ToString = "booked" Then

                        DataGridView1.Rows(i).Cells(j).Style.BackColor = Color.Red

                    ElseIf ds.Tables(0).Rows(0).Item(0).ToString = "Unavailable" Then

                        DataGridView1.Rows(i).Cells(j).Style.BackColor = Color.Black

                    Else
                        DataGridView1.Rows(i).Cells(j).Style.BackColor = Color.Green
                    End If

                End If
                DataGridView1.Rows(i).Cells(j).Value = Image.FromFile("C:\Users\Saransh\Desktop\seat2.jpg")
            Next
        Next
        con.Close()

        For j = 1 To rows
            DataGridView1.Rows(j - 1).Height = 40
            DataGridView1.Rows(j - 1).Cells(0).Value = Chr(64 + j)
            DataGridView1.Rows(j - 1).Cells(0).Style.BackColor = Color.Azure
        Next

    End Sub
End Class