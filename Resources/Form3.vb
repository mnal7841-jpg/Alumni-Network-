Imports System.Data.SqlClient
Imports System.Text.RegularExpressions
Public Class Form3
    Dim sqlcon As New SqlConnection(My.Settings.connection_string)
    Dim dt1 As New DataTable()
    Dim a As New DataColumn("رقم الخريج")
    Dim b As New DataColumn("الاسم ")
    Dim c As New DataColumn("العمر")
    Dim d As New DataColumn("الجنس")
    Dim f As New DataColumn("التخصص")
    Dim g As New DataColumn("المؤهل")
    Dim h As New DataColumn("الشعبة")
    Dim i As New DataColumn("تاريخ الحصول")
    Dim j As New DataColumn("مكان الحصول")
    Dim k As New DataColumn("نوع المؤهل")
    Dim l As New DataColumn("الحالة الاجتماعية")
    Dim m As New DataColumn("الحالة الصحية")
    Dim n As New DataColumn("رقم الهاتف")
    'Dim currentId As Integer = 0
    'Private Property SelectionMode As Integer

    Private Sub Form3_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        ComboBox1.Items.AddRange({"ذكر", "أنثى"})
        ComboBox2.Items.AddRange({"أعزب", "متزوج", "مطلق", "أرمل"})
        ComboBox3.Items.AddRange(New String() {
        "دبلوم",
        "بكالوريوس",
        "ماجستير",
        "دكتوراه"
    })

        ComboBox8.Items.AddRange(New String() {
      "دبلوم",
      "بكالوريوس",
      "ماجستير",
      "دكتوراه"
  })
        ComboBox3.SelectedIndex = 0

        ComboBox4.Items.AddRange(New String() {
     "هندسة",
     "طب",
     "علوم الحاسوب",
     "محاسبة",
     "إدارة أعمال",
     "هندسة مدنية",
     "فلسفة",
     "هندسة كهربائية",
     "علوم طبية"
 })

        ComboBox7.Items.AddRange(New String() {
     "هندسة",
     "طب",
     "علوم الحاسوب",
     "محاسبة",
     "إدارة أعمال",
     "هندسة مدنية",
     "فلسفة",
     "هندسة كهربائية",
     "علوم طبية"
 })
        ComboBox5.Items.Clear()
        ComboBox5.Items.Add("عام")
        ComboBox5.Items.Add("خاص")

        ComboBox6.Items.Clear()
        ComboBox6.Items.Add("لديه إعاقة")
        ComboBox6.Items.Add("ليس لديه إعاقة")
    End Sub
    Private Sub TextBox2_TextChanged(sender As System.Object, e As System.EventArgs) Handles TextBox2.TextChanged
        Dim id = TextBox2.Text.Trim()
        If id.Length = 12 Then

            If IsNumeric(id) AndAlso (id.StartsWith("1") Or id.StartsWith("2")) Then
                MessageBox.Show("الرقم الوطني صحيح")
            Else
                MessageBox.Show("الرقم الوطني غير صحيح")
            End If
        End If
    End Sub
    Private Sub DateTimePicker1_ValueChanged(sender As System.Object, e As System.EventArgs) Handles DateTimePicker1.ValueChanged
        TextBox7.Text = Date.Today.Year - DateTimePicker1.Value.Year
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged
        ComboBox1.SelectedItem = ComboBox1.SelectedItem.ToString()
    End Sub

    Private Sub ComboBox2_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles ComboBox2.SelectedIndexChanged
        ComboBox2.SelectedItem = "الحالة الاجتماعية: " & ComboBox2.SelectedItem.ToString()
    End Sub
    Private Sub ComboBox3_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles ComboBox3.SelectedIndexChanged
        ComboBox3.SelectedItem = ComboBox3.SelectedItem.ToString()
    End Sub
    Private Sub ComboBox4_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles ComboBox4.SelectedIndexChanged
        ComboBox4.SelectedItem = ComboBox4.SelectedItem.ToString()
    End Sub
    Private Sub ComboBox5_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles ComboBox5.SelectedIndexChanged
        Select Case ComboBox5.SelectedItem.ToString()
            Case "عام"
            Case "خاص"
        End Select
    End Sub

    Private Sub ComboBox6_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles ComboBox6.SelectedIndexChanged
        ComboBox6.SelectedItem = ComboBox6.SelectedItem.ToString()
    End Sub
    Private Sub Button11_Click(sender As System.Object, e As System.EventArgs) Handles Button11.Click
        Try
            sqlcon.Open()
            Dim sqlcmd As New SqlCommand()
            sqlcmd.Connection = sqlcon

            sqlcmd.CommandText =
                "UPDATE [dbo].[Graduates_info] SET " &
                "[g_name]=N'" & TextBox3.Text & "', " &
                "[age]=" & TextBox7.Text & ", " &
                "[gender]=N'" & ComboBox1.Text & "', " &
                "[specialization]=N'" & ComboBox4.Text & "', " &
                "[qualified]=N'" & ComboBox3.Text & "', " &
                "[division]=N'" & TextBox5.Text & "', " &
                "[date]=N'" & DateTimePicker2.Value & "', " &
                "[place]=N'" & TextBox6.Text & "', " &
                "[q_type]=N'" & ComboBox5.Text & "', " &
                "[g_marital]=N'" & ComboBox2.Text & "', " &
                "[health_status]=N'" & ComboBox6.Text & "', " &
                "[phone]=N'" & TextBox4.Text & "' " &
                "WHERE [g_id]=" & TextBox2.Text

            sqlcmd.ExecuteNonQuery()

            MessageBox.Show("تم تعديل البيانات بنجاح ✅")

            sqlcon.Close()

        Catch ex As Exception
            MessageBox.Show(ex.Message)
            sqlcon.Close()
        End Try

    End Sub

    Private Sub Button15_Click(sender As System.Object, e As System.EventArgs) Handles Button15.Click
        Dim query As String = "SELECT [g_id],[g_name],[specialization],[age], [gender],[qualified],[division],[date], [place], [q_type], [g_marital],[health_status],[phone]  FROM Graduates_Info"
        Dim dt As New DataTable()
        Using cmd As New SqlCommand(query, sqlcon)
            Using da As New SqlDataAdapter(cmd)
                da.Fill(dt)
            End Using
        End Using
        DataGridView2.DataSource = dt
    End Sub
    Private Sub ComboBox7_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles ComboBox7.SelectedIndexChanged
        ComboBox7.SelectedItem = ComboBox7.SelectedItem.ToString()
    End Sub

    Private Sub ComboBox8_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles ComboBox8.SelectedIndexChanged
        ComboBox8.SelectedItem = ComboBox8.SelectedItem.ToString()
    End Sub

    Private Sub Button12_Click(sender As System.Object, e As System.EventArgs) Handles Button12.Click
        dt1.Columns.Add(a)
        dt1.Columns.Add(b)
        dt1.Columns.Add(c)
        dt1.Columns.Add(d)
        dt1.Columns.Add(f)
        dt1.Columns.Add(g)
        dt1.Columns.Add(h)
        dt1.Columns.Add(i)
        dt1.Columns.Add(j)
        dt1.Columns.Add(k)
        dt1.Columns.Add(l)
        dt1.Columns.Add(m)
        dt1.Columns.Add(n)
        sqlcon.Open()
        Dim sqlcmd As New SqlCommand()
        sqlcmd.Connection = sqlcon
        sqlcmd.CommandText = "select * from [dbo].[Graduates_info] where[specialization] =N'" + ComboBox7.SelectedItem + "' and [qualified]=N'" + ComboBox8.SelectedItem + "'"
        Dim dr As SqlDataReader = sqlcmd.ExecuteReader()
        While dr.Read()
            dt1.Rows.Add(dr("g_id"), dr("g_name"), dr("age"), dr("gender"), dr("specialization"), dr("qualified"), dr("division"), dr("date"), dr("place"), dr("q_type"), dr("g_marital"), dr("health_status"), dr("phone"))
        End While
        DataGridView2.DataSource = dt1
        sqlcon.Close()
    End Sub
    Private Sub Button10_Click(sender As System.Object, e As System.EventArgs) Handles Button10.Click
        sqlcon.Open()
        Dim sqlcmd As New SqlCommand()
        sqlcmd.Connection = sqlcon
        sqlcmd.CommandText = "INSERT INTO [dbo].[Graduates_info]([g_id],[g_name],[age],[gender],[specialization],[qualified],[division],[date],[place],[q_type],[g_marital],[health_status],[phone]) VALUES  ('" + TextBox2.Text + "' , N'" + TextBox3.Text + "','" + TextBox7.Text + "' , N'" + ComboBox1.SelectedItem + "',N'" + ComboBox4.SelectedItem + "',N'" + ComboBox3.SelectedItem + "',N'" + TextBox5.Text + " ','" + DateTimePicker2.Value + "',N'" + TextBox6.Text + "',N'" + ComboBox5.SelectedItem + "',N'" + ComboBox2.SelectedItem + "', N'" + ComboBox6.SelectedItem + "','" + TextBox4.Text + "')"
        sqlcmd.ExecuteNonQuery()

        MessageBox.Show("تم اضافة البيانات ......")

        sqlcon.Close()
    End Sub

    Private Sub TextBox4_TextChanged(sender As System.Object, e As System.EventArgs) Handles TextBox4.TextChanged
        Dim phone = TextBox4.Text.Trim()
        If phone.Length = 9 Then
            If IsNumeric(phone) AndAlso (phone.StartsWith("91") Or phone.StartsWith("92")) Then
                MessageBox.Show("رقم الهاتف صحيح")
            Else
                MessageBox.Show("رقم الهاتف غير صحيح")
            End If
        End If
    End Sub

    Private Sub DataGridView2_CellContentClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView2.CellContentClick


        ' التأكد من أنه تم اختيار صف صحيح
        If e.RowIndex >= 0 Then

            Dim row As DataGridViewRow = DataGridView2.Rows(e.RowIndex)

            TextBox2.Text = row.Cells("g_id").Value.ToString()
            TextBox3.Text = row.Cells("g_name").Value.ToString()
            TextBox7.Text = row.Cells("age").Value.ToString()
            ComboBox1.Text = row.Cells("gender").Value.ToString()
            ComboBox4.Text = row.Cells("specialization").Value.ToString()
            ComboBox3.Text = row.Cells("qualified").Value.ToString()
            TextBox5.Text = row.Cells("division").Value.ToString()
            DateTimePicker2.Value = Convert.ToDateTime(row.Cells("date").Value)
            TextBox6.Text = row.Cells("place").Value.ToString()
            ComboBox5.Text = row.Cells("q_type").Value.ToString()
            ComboBox2.Text = row.Cells("g_marital").Value.ToString()
            ComboBox6.Text = row.Cells("health_status").Value.ToString()
            TextBox4.Text = row.Cells("phone").Value.ToString()

        End If

    End Sub
End Class