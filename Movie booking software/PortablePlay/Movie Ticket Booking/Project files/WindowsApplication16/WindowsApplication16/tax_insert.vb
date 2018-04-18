Imports System.Data.OleDb
Public Class Tax_insert

    Private Sub Tax_insert_Load(ByVal sender As System.Object, ByVal e As System.EventArgs)
      
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If TextBox1.Text = "" Or TextBox2.Text = "" Then
            MsgBox("please fill policy name,and cost")
        Else
            'Dim con As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & Application.StartupPath & "\movie.booking.accdb")
            Dim da As OleDbDataAdapter
            Dim cmd As OleDbCommand
            Dim ds As DataSet

            'If con.State <> ConnectionState.Open Then
            '    con.Open()
            'End If
            conopen()
            Try
                da = New OleDbDataAdapter("select max(tax_id) from tax", con)
                ds = New DataSet
                da.Fill(ds, "stud")
                cmd = New OleDbCommand("insert into tax(tax_id,tax_name,tax_value) values(" & Val(ds.Tables(0).Rows(0).Item(0).ToString) + 1 & ",'" & TextBox1.Text & "'," & Val(TextBox2.Text) & ")", con)
                cmd.ExecuteNonQuery()
                MsgBox("tax info inserted")
            Catch ex As Exception
                MsgBox("You cant add tax with name already added")
            End Try
        End If


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

        cmd = New OleDbCommand("select * from tax where tax_id=" & ComboBox1.SelectedIndex + 1 & "", con)
        drstud = cmd.ExecuteReader()
        drstud.Read()
        TextBox1.Text = drstud(2)
        TextBox2.Text = drstud(3)
        con.Close()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        'Dim con As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & Application.StartupPath & "\movie.booking.accdb")
        Dim cmd As OleDbCommand



        'If con.State <> ConnectionState.Open Then
        '    con.Open()
        'End If
        conopen()

        cmd = New OleDbCommand("update tax set tax_name='" & TextBox1.Text & "' ,tax_value=" & Val(TextBox2.Text) & " where tax_id=" & ComboBox1.SelectedIndex + 1 & "", con)
        cmd.ExecuteNonQuery()

        MsgBox("Tax updated successfully")
        con.Close()

    End Sub

    Private Sub Tax_insert_Load1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim i As Integer
        'Dim con As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & Application.StartupPath & "\movie.booking.accdb")
        Dim da As OleDbDataAdapter
        Dim ds As DataSet
        Dim tax As Integer
        'If con.State <> ConnectionState.Open Then
        '    con.Open()
        'End If
        da = New OleDbDataAdapter("select count(tax_id) from tax", con)
        ds = New DataSet
        da.Fill(ds, "stud")
        tax = ds.Tables(0).Rows(0).Item(0)

        da = New OleDbDataAdapter("select tax_name from tax", con)
        ds = New DataSet
        da.Fill(ds, "stud")

        For i = 0 To tax - 1
            ComboBox1.Items.Add(ds.Tables(0).Rows(i).Item(0).ToString)
        Next
        Try
            ComboBox1.Text = ComboBox1.Items(0)
        Catch ex As Exception

        End Try
    End Sub
End Class