Imports System.Data.Sql
Imports System.Data.SqlClient
Public Class FItem
    Dim ketemu As Boolean

    Private Sub tambahdata_Click(sender As Object, e As EventArgs) Handles tambahdata.Click

        If TbiD.Text = "" Or tbnamaitem.Text = "" Then
            MsgBox("Silahkan Isi Semua Form")
        End If

        Call buka()
        Try
            Dim simpan As String = "INSERT INTO item VALUES ('" & TbiD.Text & "','" & tbnamaitem.Text & "')"
            cmd = New SqlCommand(simpan, koneksi)
            cmd.ExecuteNonQuery()
            MsgBox("Data berhasil di Input", MsgBoxStyle.Information, "Information")
        Catch ex As Exception
            MessageBox.Show("Input data gagal dilakukan.")
        End Try
        Call Bersih() : TbiD.Focus()
    End Sub

    Private Sub itemmenu_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        Call Tampilitem()
        Call AturDGV()
        Call buka()
        TbiD.Enabled = True
        TbiD.Focus()
        cmd = New SqlCommand("SELECT * FROM hanifah", koneksi)
        Dim dt As New DataTable
        Dim adapter As New SqlDataAdapter
        adapter = New SqlDataAdapter(cmd)
        Call Bersih()
    End Sub

    Sub Tampilitem()
        Call buka()
        cmd = New SqlCommand("SELECT iditem, namaitem FROM item", koneksi)
        Dim dt As New DataTable
        Dim adapter As New SqlDataAdapter
        adapter = New SqlDataAdapter(cmd)
        adapter.Fill(dt)
        DGVitem.DataSource = dt
        DGVitem.Refresh()
    End Sub

    Sub AturDGV()
        Try
            DGVitem.Columns(0).Width = 150
            DGVitem.Columns(1).Width = 1133
            DGVitem.Columns(0).HeaderText = "ID ITEM"
            DGVitem.Columns(1).HeaderText = "NAMA ITEM"
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Bersih()
        TbiD.Text = ""
        tbnamaitem.Text = ""
    End Sub

    Private Sub TbiD_LostFocus(sender As Object, e As EventArgs) Handles TbiD.LostFocus
        Dim cmd As New SqlCommand
        Dim rd As SqlDataReader
        cmd = New SqlCommand("SELECT * FROM item WHERE iditem ='" & TbiD.Text & "'", koneksi)
        rd = cmd.ExecuteReader
        rd.Read()
        If rd.HasRows Then
            ketemu = True
            TbiD.Enabled = False
            tbnamaitem.Text = rd("namaitem")
        End If
        rd.Close()
    End Sub

    Private Sub ubahdata_Click(sender As Object, e As EventArgs) Handles ubahdata.Click

        If TbiD.Text = "" Or tbnamaitem.Text = "" Then
            MsgBox("Silahkan Isi Semua Form")
        End If

        Call buka()
        Try
            Dim ubah As String = "UPDATE item SET namaitem ='" & tbnamaitem.Text & "' WHERE iditem ='" & TbiD.Text & "'"
            cmd = New SqlCommand(ubah, koneksi)
            cmd.ExecuteNonQuery()
            MsgBox("Data berhasil di Update", MsgBoxStyle.Information, "Information")
        Catch ex As Exception
            MessageBox.Show("Update data gagal dilakukan.")
        End Try
        Call Bersih() : TbiD.Focus()
    End Sub

    Private Sub hapusdata_Click(sender As Object, e As EventArgs) Handles hapusdata.Click
        Call buka()
        Dim hapus As String = "DELETE item WHERE iditem='" & TbiD.Text & "'"
        cmd = New SqlCommand(hapus, koneksi)
        cmd.ExecuteNonQuery()
        MsgBox("Data berhasil di hapus", MsgBoxStyle.Information, "Information")
        Call Bersih() : TbiD.Focus()
    End Sub

    Private Sub DGVitem_CellContentClick1(sender As Object, e As DataGridViewCellEventArgs) Handles DGVitem.CellContentClick
        On Error Resume Next
        TbiD.Text = DGVitem.Rows(e.RowIndex).Cells(0).Value
        tbnamaitem.Text = DGVitem.Rows(e.RowIndex).Cells(1).Value
        TbiD.Enabled = False
    End Sub
End Class