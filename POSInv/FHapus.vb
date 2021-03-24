Imports System.Data.Sql
Imports System.Data.SqlClient
Public Class FHapus
    Sub bersih()
        ComboBox1.Text = ""
        ComboBox2.Text = ""
    End Sub
    Sub munculcombo()
        Call buka()
        cmd = New SqlCommand("select distinct namaitem from item", koneksi)
        dr = cmd.ExecuteReader
        ComboBox1.Items.Clear()
        Do While dr.Read
            ComboBox1.Items.Add(dr.Item("namaitem"))
            ComboBox2.Items.Add(dr.Item("namaitem"))
        Loop
    End Sub

    Sub mati()
        ComboBox1.DropDownStyle = ComboBoxStyle.DropDownList
        ComboBox2.DropDownStyle = ComboBoxStyle.DropDownList
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        sql = "SELECT * FROM item WHERE namaitem = '" & ComboBox1.Text & "'"
        cmdcari = New SqlCommand(sql, koneksi)
        bacacari = cmdcari.ExecuteReader
        bacacari.Read()
        Dim iditem As Integer = bacacari("iditem")
        Call buka()
        cmd = New SqlCommand("Delete from forecasting where iditem='" & iditem & "'", koneksi)
        cmd.ExecuteNonQuery()
        MsgBox("Data berhasil di hapus", MsgBoxStyle.Information, "Information")
        Call bersih()
    End Sub

    Private Sub FHapus_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        munculcombo()
        bersih()
        mati()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        sql = "SELECT * FROM item WHERE namaitem = '" & ComboBox2.Text & "'"
        cmdcari = New SqlCommand(sql, koneksi)
        bacacari = cmdcari.ExecuteReader
        bacacari.Read()
        Dim iditem As Integer = bacacari("iditem")
        Call buka()
        cmd = New SqlCommand("Delete from qty where iditem='" & iditem & "'", koneksi)
        cmd.ExecuteNonQuery()
        MsgBox("Data berhasil di hapus", MsgBoxStyle.Information, "Information")
        Call bersih()
    End Sub
End Class