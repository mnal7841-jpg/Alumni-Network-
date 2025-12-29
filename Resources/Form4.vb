Imports System.Data.SqlClient
Public Class Form4
    Dim sqlcon As New SqlConnection(My.Settings.connection_string)

    Private Sub DataGridView2_CellContentClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView2.CellContentClick

    End Sub

    Private Sub Form4_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        Dim f As New Form3() ' أو Form4 حسب اسم النموذج
        f.ShowDialog()
    End Sub
End Class