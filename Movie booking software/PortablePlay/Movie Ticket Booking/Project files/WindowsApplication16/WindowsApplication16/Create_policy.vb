Imports System.Data.OleDb
Public Class Create_policy
    Public selected As Integer
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        'Dim con As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & Application.StartupPath & "\movie.booking.accdb")
        Dim da As OleDbDataAdapter
        Dim cmd As OleDbCommand
        Dim ds As DataSet
        conopen()

        da = New OleDbDataAdapter("select max(policy_id) from show_policy", con)
        ds = New DataSet
        da.Fill(ds, "stud")
        cmd = New OleDbCommand("insert into audi_policy(audi_id,policy_id,policy_rate,day1) values(1," & selected & +1 & "," & Val(TextBox2.Text) & ",'" & ComboBox2.SelectedItem & "')", con)
        cmd.ExecuteNonQuery()
        MsgBox("policy inserted successfully")
        con.Close()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click

        'Dim con As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & Application.StartupPath & "\movie.booking.accdb")
        Dim cmd As OleDbCommand


        'If con.State <> ConnectionState.Open Then
        '    con.Open()
        'End If
        conopen()


        cmd = New OleDbCommand("update audi_policy set policy_rate=" & Val(TextBox3.Text) & " where policy_id=" & ComboBox1.SelectedIndex + 1 & " and day1='" & ComboBox2.SelectedItem & "'", con)
        cmd.ExecuteNonQuery()

        MsgBox("policy updated successfully")
        con.Close()

    End Sub

    Private Sub Form6_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ComboBox1.Items.Clear()
        ComboBox2.Items.Clear()

        ComboBox2.Items.Add("Monday")
        ComboBox2.Items.Add("Tuesday")
        ComboBox2.Items.Add("Wednesday")
        ComboBox2.Items.Add("Thursday")
        ComboBox2.Items.Add("Friday")
        ComboBox2.Items.Add("Saturday")
        ComboBox2.Items.Add("Sunday")

        'Dim con As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & Application.StartupPath & "\movie.booking.accdb")
        Dim da As OleDbDataAdapter
        Dim ds As DataSet
        Dim row As Integer
        'If con.State <> ConnectionState.Open Then
        '    con.Open()
        'End If
        conopen()

        da = New OleDbDataAdapter("select count(policy_id) from show_policy", con)
        ds = New DataSet
        da.Fill(ds, "stud")
        row = ds.Tables(0).Rows(0).Item(0)
        da = New OleDbDataAdapter("select policy_name from show_policy", con)
        ds = New DataSet
        da.Fill(ds, "stud")
        For i = 0 To row - 1
            ComboBox1.Items.Add(ds.Tables(0).Rows(i).Item(0).ToString)
        Next
        ComboBox2.Text = ComboBox2.Items(0)
        Try
            ComboBox1.Text = ComboBox1.Items(0)
        Catch ex As Exception

        End Try


        Dim cmd As OleDbCommand
        Dim drstud As OleDbDataReader
        conopen()
        cmd = New OleDbCommand("select policy_rate from audi_policy where day1='" & ComboBox2.SelectedItem & "' and policy_id=" & ComboBox1.SelectedIndex + 1 & "", con)
        drstud = cmd.ExecuteReader()
        drstud.Read()
        If drstud.HasRows Then
            TextBox3.Text = drstud(0)
        End If
        con.Close()

    End Sub



    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        If TextBox1.Text = "" Or TextBox2.Text = "" Then
            MsgBox("please fill policy name,and cost")
        Else

            Dim da As OleDbDataAdapter
            Dim cmd As OleDbCommand
            Dim ds As DataSet

            conopen()

            da = New OleDbDataAdapter("select max(policy_id) from show_policy", con)
            ds = New DataSet
            da.Fill(ds, "stud")
            Try
                cmd = New OleDbCommand("insert into show_policy(policy_id,policy_name) values(" & Val(ds.Tables(0).Rows(0).Item(0).ToString) + 1 & ",'" & TextBox1.Text & "')", con)
                cmd.ExecuteNonQuery()
                For i = 1 To 7

                    If i = 1 Then
                        cmd = New OleDbCommand("insert into audi_policy(policy_id,policy_rate,day1) values(" & Val(ds.Tables(0).Rows(0).Item(0).ToString) + 1 & "," & Val(TextBox2.Text) & ",'Monday')", con)
                        cmd.ExecuteNonQuery()
                    ElseIf i = 2 Then
                        cmd = New OleDbCommand("insert into audi_policy(policy_id,policy_rate,day1) values(" & Val(ds.Tables(0).Rows(0).Item(0).ToString) + 1 & "," & Val(TextBox2.Text) & ",'Tuesday')", con)
                        cmd.ExecuteNonQuery()
                    ElseIf i = 3 Then
                        cmd = New OleDbCommand("insert into audi_policy(policy_id,policy_rate,day1) values(" & Val(ds.Tables(0).Rows(0).Item(0).ToString) + 1 & "," & Val(TextBox2.Text) & ",'Wednesday')", con)
                        cmd.ExecuteNonQuery()
                    ElseIf i = 4 Then
                        cmd = New OleDbCommand("insert into audi_policy(policy_id,policy_rate,day1) values(" & Val(ds.Tables(0).Rows(0).Item(0).ToString) + 1 & "," & Val(TextBox2.Text) & ",'Thursday')", con)
                        cmd.ExecuteNonQuery()
                    ElseIf i = 5 Then
                        cmd = New OleDbCommand("insert into audi_policy(policy_id,policy_rate,day1) values(" & Val(ds.Tables(0).Rows(0).Item(0).ToString) + 1 & "," & Val(TextBox2.Text) & ",'Friday')", con)
                        cmd.ExecuteNonQuery()
                    ElseIf i = 6 Then
                        cmd = New OleDbCommand("insert into audi_policy(policy_id,policy_rate,day1) values(" & Val(ds.Tables(0).Rows(0).Item(0).ToString) + 1 & "," & Val(TextBox2.Text) & ",'Saturday')", con)
                        cmd.ExecuteNonQuery()
                    ElseIf i = 7 Then
                        cmd = New OleDbCommand("insert into audi_policy(policy_id,policy_rate,day1) values(" & Val(ds.Tables(0).Rows(0).Item(0).ToString) + 1 & "," & Val(TextBox2.Text) & ",'Sunday')", con)
                        cmd.ExecuteNonQuery()

                    End If

                Next
                MsgBox("Policy added")
            Catch ex As Exception
                MsgBox("Cant add policies with same name present already,try another name")
            End Try

            Dim row As Integer
            ComboBox1.Items.Clear()
            da = New OleDbDataAdapter("select count(policy_id) from show_policy", con)
            ds = New DataSet
            da.Fill(ds, "stud")
            row = ds.Tables(0).Rows(0).Item(0)
            da = New OleDbDataAdapter("select policy_name from show_policy", con)
            ds = New DataSet
            da.Fill(ds, "stud")
            For i = 0 To row - 1
                ComboBox1.Items.Add(ds.Tables(0).Rows(i).Item(0).ToString)
            Next
            ComboBox1.Text = ComboBox1.Items(0)
            con.Close()

        End If

        Dim cmd2 As OleDbCommand
        Dim drstud As OleDbDataReader
        conopen()
        cmd2 = New OleDbCommand("select policy_rate from audi_policy where day1='" & ComboBox2.SelectedItem & "' and policy_id=" & ComboBox1.SelectedIndex + 1 & "", con)
        drstud = cmd2.ExecuteReader()
        drstud.Read()
        If drstud.HasRows Then
            TextBox3.Text = drstud(0)
        End If
        con.Close()
    End Sub


    Private Sub ComboBox2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox2.SelectedIndexChanged
        Dim cmd As OleDbCommand
        Dim drstud As OleDbDataReader
        conopen()
        cmd = New OleDbCommand("select policy_rate from audi_policy where day1='" & ComboBox2.SelectedItem & "' and policy_id=" & ComboBox1.SelectedIndex + 1 & "", con)
        drstud = cmd.ExecuteReader()
        drstud.Read()
        If drstud.HasRows Then
            TextBox3.Text = drstud(0)
        End If

        con.Close()
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged
        Dim sel As Integer
        Dim cmd2 As OleDbCommand
        Dim drstud As OleDbDataReader
        conopen()
        cmd2 = New OleDbCommand("select policy_id from audi_policy", con)
        drstud = cmd2.ExecuteReader()
        drstud.Read()
        sel = drstud(0)

        cmd2 = New OleDbCommand("select policy_rate from audi_policy where day1='" & ComboBox2.SelectedItem & "' and policy_id=" & ComboBox1.SelectedIndex + sel & "", con)
        drstud = cmd2.ExecuteReader()
        drstud.Read()
        If drstud.HasRows Then
            TextBox3.Text = drstud(0)
        End If
        con.Close()
    End Sub

  
    Private Sub Button1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim cmd As OleDbCommand
        Dim da As OleDbDataAdapter
        Dim ds As DataSet
        Dim row, sel As Integer
        Dim drstud As OleDbDataReader

        conopen()
        Try
            cmd = New OleDbCommand("select policy_id from audi_policy", con)
            drstud = cmd.ExecuteReader()
            drstud.Read()
            sel = drstud(0)
            cmd = New OleDbCommand("delete from show_policy where policy_id=" & ComboBox1.SelectedIndex + sel & "", con)
            cmd.ExecuteNonQuery()

            cmd = New OleDbCommand("update audi_info set policy_id=0 where policy_id=" & ComboBox1.SelectedIndex + sel & "", con)
            cmd.ExecuteNonQuery()
            MsgBox("Policy deleted successfully")
        Catch ex As Exception
            MsgBox("Select any valid policy.")
        End Try
       
        con.Close()

        da = New OleDbDataAdapter("select count(policy_id) from show_policy", con)
        ds = New DataSet
        da.Fill(ds, "stud")
        row = ds.Tables(0).Rows(0).Item(0)
        da = New OleDbDataAdapter("select policy_name from show_policy", con)
        ds = New DataSet
        da.Fill(ds, "stud")
        ComboBox1.Items.Clear()
        ComboBox1.Text = ""
        For i = 0 To row - 1
            ComboBox1.Items.Add(ds.Tables(0).Rows(i).Item(0).ToString)
        Next
    End Sub
End Class