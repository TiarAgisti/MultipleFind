Imports MySql.Data
Imports MySql.Data.MySqlClient
Public Class Form1

    Protected myConnectionString As String = "Server=Localhost;Database=vbnet;User Id=root;Password=tiar123" 'connection string 
    Function FindData() As DataTable
        Dim sql As String = "Select * From Customers Where IsActive = 1" ' string query awal

        If Not String.IsNullOrEmpty(txtName.Text) Then 'mengecek kondisi,apakah ada string yg di input atau tidak pada txtName
            sql += " AND CustomerName LIKE '%" & txtName.Text & "%'" 'jika ada,maka menambahkan string pada query awal
        End If

        If Not String.IsNullOrEmpty(txtAddress.Text) Then 'mengecek kondisi,apakah ada string yg di input atau tidak pada txtAddress
            sql += " AND Address LIKE '%" & txtAddress.Text & "%'" 'jika ada,maka menambahkan string kembali
        End If

        If Not String.IsNullOrEmpty(txtPhone.Text) Then 'mengecek kondisi,apakah ada string yg di input atau tidak pada txtPhone
            sql += " AND Phone LIKE '%" & txtPhone.Text & "%'" 'jika ada,maka menambahkan string kembali
        End If

        If Not String.IsNullOrEmpty(txtEmail.Text) Then 'mengecek kondisi,apakah ada string yg di input atau tidak pada txtEmail
            sql += " AND Email LIKE '%" & txtEmail.Text & "%'" 'jika ada,maka menambahkan string kembali
        End If

        Dim dataTable As DataTable = New DataTable 'deklarasi variable dataTable sbg DataTable
        Try
            Using conn = New MySqlConnection(myConnectionString) 'Membuat object connection baru
                conn.Open() 'buka connection
                Dim myCommand As MySqlCommand = New MySqlCommand(sql, conn) 'Membuat object command baru
                Using dataAdapter As MySqlDataAdapter = New MySqlDataAdapter(myCommand) 'Membuat object Adapeter baru
                    dataAdapter.Fill(dataTable) 'memasukan data table ke adapter
                End Using
                myCommand.Dispose() 'menghapus object command
                conn.Close() 'menutup koneksi
            End Using
            Return dataTable 'mengembalikan nilai ke variable datatable
        Catch ex As Exception
            Return Nothing
            MessageBox.Show(ex.Message)
        End Try
    End Function
    Private Sub btnFind_Click(sender As Object, e As EventArgs) Handles btnFind.Click
        dgv.DataSource = FindData() 'mengisi datasouce pada data grid
    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Close()
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dgv.DataSource = FindData() 'mengisi datasouce pada data grid
    End Sub
End Class
