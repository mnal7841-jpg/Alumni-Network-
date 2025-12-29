
Imports System.Data.SqlClient
Public Class Form1


    Dim sqlcon As New SqlConnection(My.Settings.connection_string)

    Private Sub Form1_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        Dim frm As New Form2()

        If TextBox1.Text = "admin" And TextBox2.Text = "5050" Then
            MessageBox.Show("مرحبا بمدير النظام")
            Me.Hide()
            frm.Show()


        ElseIf TextBox1.Text = "user" And TextBox2.Text = "112233" Then
            MessageBox.Show("مرحبا بك فالنظام")
            Me.Hide()
            frm.Show()

        Else
            MessageBox.Show("البيانات غير صحيحة")
        End If
       

    End Sub

    

    Private Sub TextBox1_TextChanged(sender As System.Object, e As System.EventArgs) Handles TextBox1.TextChanged

    End Sub

    Private Sub TextBox2_TextChanged(sender As System.Object, e As System.EventArgs) Handles TextBox2.TextChanged

    End Sub
End Class
