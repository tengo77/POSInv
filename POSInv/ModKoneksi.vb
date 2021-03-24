Imports System.Data.Sql
Imports System.Data.SqlClient
Module ModKoneksi
    Public koneksi As SqlConnection
    Public data As DataSet
    Public dr As SqlDataReader
    Public adapter As SqlDataAdapter
    Public cmd As SqlCommand
    Public ass As DataTable
    Public sql As String
    Public periode_bulan, periode_tahun As String
    Public user As String
    Public sq As String

    Public baca As SqlDataReader
    Public bacacek As SqlDataReader
    Public bacacek2 As SqlDataReader
    Public bacacari As SqlDataReader
    Public bacacari2 As SqlDataReader
    Public bacacek3 As SqlDataReader
    Public cmdcek As SqlCommand
    Public cmdcek2 As SqlCommand
    Public cmdcek3 As SqlCommand
    Public cmdcek4 As SqlCommand
    Public cmdcari As SqlCommand
    Public cmdcari2 As SqlCommand
    Public Sub buka()
        sql = "Data Source=.\SQLEXPRESS; Initial Catalog=inventory; Integrated Security=True; MultipleActiveResultSets=True"
        koneksi = New SqlConnection(sql)
        Try
            If koneksi.State = ConnectionState.Closed Then
                koneksi.Open()
            End If
        Catch ex As Exception
            MsgBox(Err.Description, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub
End Module
