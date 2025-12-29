Imports System.Data.SqlClient
Public Class Form2
    Dim sqlcon As New SqlConnection(My.Settings.connection_string)
    Private Sub OvalShape1_Click(sender As System.Object, e As System.EventArgs)

    End Sub

    Private Sub Form2_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

       

    End Sub

    Private Sub TextBox2_TextChanged(sender As System.Object, e As System.EventArgs) Handles TextBox2.TextChanged

    End Sub





    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        Dim f As New Form4()
        f.ShowDialog()
    End Sub

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        Dim f As New Form3()
        f.ShowDialog()
    End Sub

    Private Sub Button3_Click(sender As System.Object, e As System.EventArgs) Handles Button3.Click
        Dim f As New Form5()
        f.ShowDialog()
    End Sub

    Private Sub Button4_Click(sender As System.Object, e As System.EventArgs) Handles Button4.Click
        Dim f As New Form6()
        f.ShowDialog()
    End Sub

    Private Sub Button5_Click(sender As System.Object, e As System.EventArgs) Handles Button5.Click
        Dim f As New Form7()
        f.ShowDialog()
    End Sub

    Private Sub Button7_Click(sender As System.Object, e As System.EventArgs) Handles Button7.Click
        Dim f As New Form8()
        f.ShowDialog()
    End Sub

    Private Sub Button8_Click(sender As System.Object, e As System.EventArgs) Handles Button8.Click
        Dim f As New Form9()
        f.ShowDialog()
    End Sub

    Private Sub Button9_Click(sender As System.Object, e As System.EventArgs) Handles Button9.Click
        Dim f As New Form10()
        f.ShowDialog()
    End Sub
End Class