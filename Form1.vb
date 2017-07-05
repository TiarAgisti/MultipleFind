Imports MySql.Data
Imports MySql.Data.MySqlClient
Public Class Form1

    Protected myConnectionString As String = "Server=Localhost;Database=vbnet;User Id=root;Password=tiar123"
    Function FindData() As DataTable
        Dim sql As String = "Select * From Customers Where IsActive = 1"

        If Not String.IsNullOrEmpty(txtName.Text) Then
            sql += " AND CustomerName LIKE '%" & txtName.Text & "%'"
        End If

        If Not String.IsNullOrEmpty(txtAddress.Text) Then
            sql += " AND Address LIKE '%" & txtAddress.Text & "%'"
        End If

        If Not String.IsNullOrEmpty(txtPhone.Text) Then
            sql += " AND Phone LIKE '%" & txtPhone.Text & "%'"
        End If

        If Not String.IsNullOrEmpty(txtEmail.Text) Then
            sql += " AND Email LIKE '%" & txtEmail.Text & "%'"
        End If

        Dim dataTable As DataTable = New DataTable
        Try
            Using conn = New MySqlConnection(myConnectionString)
                conn.Open()
                Dim myCommand As MySqlCommand = New MySqlCommand(sql, conn)
                Using dataAdapter As MySqlDataAdapter = New MySqlDataAdapter(myCommand)
                    dataAdapter.Fill(dataTable)
                End Using
                myCommand.Dispose()
                conn.Close()
                Return dataTable
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Private Sub btnFind_Click(sender As Object, e As EventArgs) Handles btnFind.Click
        dgv.DataSource = FindData()
    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Close()
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dgv.DataSource = FindData()
    End Sub
End Class
