Imports System.Data.OleDb
Public Class Form1
    Dim rows As Integer
    Dim columns As Integer

    Private Sub Label1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub


    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim da As OleDbDataAdapter
        Dim ds As DataSet
        Dim con As New OleDbConnection
        Dim cmd As OleDbCommand
        Dim count As Integer
        con.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Saransh\Documents\movie.booking.accdb"
        If con.State <> ConnectionState.Open Then
            con.Open()
        End If

        da = New OleDbDataAdapter("select count(seat_id) from audi_info", con)
        ds = New DataSet
        da.Fill(ds, "stud")
        count = ds.Tables(0).Rows(0).Item(0).ToString

        Dim i, j As Integer
        For i = 0 To rows
            For j = 0 To columns
                If DataGridView1.Rows(i).Cells(j).Style.BackColor = Color.Black Then
                    If count < 140 Then
                        cmd = New OleDbCommand("insert into audi_info values(1,'" & Chr(65 + i) & "" & j & "','Unavailable',1,1,1,1,1)", con)
                    Else
                        cmd = New OleDbCommand("update audi_info set seat_status='Unavailable' where seat_id='" & Chr(65 + i) & "" & j & "' ", con)

                    End If
                    cmd.ExecuteNonQuery()

                ElseIf DataGridView1.Rows(i).Cells(j).Style.BackColor = Color.Green Then

                    If count < 140 Then
                        cmd = New OleDbCommand("insert into audi_info values(1,'" & Chr(65 + i) & "" & j & "','Available',1,1,1,1,1)", con)
                    Else
                        cmd = New OleDbCommand("update audi_info set seat_status='Available' where seat_id='" & Chr(65 + i) & "" & j & "' ", con)
                    End If
                    cmd.ExecuteNonQuery()
                End If
            Next
        Next
        MsgBox("information saved")
        con.Close()
    End Sub

    Private Sub DataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Dim i, j As Integer
        For i = 0 To rows
            For j = 0 To columns
                If DataGridView1.Rows(i).Cells(j).Selected = True And DataGridView1.Rows(i).Cells(j).Style.BackColor = Color.Green Then
                    DataGridView1.Rows(i).Cells(j).Style.BackColor = Color.Black
                End If
            Next
        Next
        MsgBox("selected seats are now unavailable")
    End Sub

    Private Sub Form1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
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

        'Dim dgColDisc11 As New DataGridViewTextBoxColumn
        'dgColDisc11.HeaderText = "sno"
        'DataGridView1.Columns.Add(dgColDisc11)

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

        For i = 0 To rows - 1
            For j = 1 To columns
                DataGridView1.Rows(i).Cells(j).Style.BackColor = Color.Green
                DataGridView1.Rows(i).Cells(j).Value = Image.FromFile("C:\Users\Saransh\Documents\MOVIE.BOOKING\PHOTOS\RED.JPG")
            Next
        Next
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        For i = 0 To rows - 1
            For j = 1 To columns
                DataGridView1.Rows(i).Cells(j).Style.BackColor = Color.Green
                DataGridView1.Rows(i).Cells(j).Value = Image.FromFile("C:\Users\Saransh\Documents\MOVIE.BOOKING\PHOTOS\RED.JPG")
            Next
        Next
    End Sub
End Class
