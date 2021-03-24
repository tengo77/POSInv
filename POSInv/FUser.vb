Imports System.Data.Sql
Imports System.Data.SqlClient
Public Class FUser

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
    End Sub
    Dim adding As Boolean
    Public uSearch As Boolean

    Private Sub AddUser()
        Try
            Call buka()
            sql = "INSERT INTO TUser VALUES('" & txtUser.Text & "','" & txtCpwd.Text & "','" & cmbRole.Text & "', '" & txtStaffID.Text & "')"

            cmd = New SqlCommand(sql, koneksi)
            Dim i As Integer
            i = cmd.ExecuteNonQuery
            If i > 0 Then
                MsgBox("User Added Successfully", MsgBoxStyle.Information, "Add User")
            Else
                MsgBox("Failed in Adding User", MsgBoxStyle.Exclamation, "Add User")
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            cmd.Dispose()
            koneksi.Close()
        End Try
    End Sub

    Private Sub DeleteUser()
        Try
            Call buka()
            sql = "DELETE FROM TUser Where username = '" & ListBox1.SelectedItem & "'"
            cmd = New SqlCommand(sql, koneksi)
            Dim i As Integer
            i = cmd.ExecuteNonQuery
            If i > 0 Then
                MsgBox("User Deleted", MsgBoxStyle.Information, "Delete User")
            Else
                MsgBox("Failed in Deleting User")
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            cmd.Dispose()
            koneksi.Close()
        End Try
    End Sub
    Private Sub Loadusers()
        Try
            Call buka()
            sql = "SELECT username from TUser order by username"
            cmd = New SqlCommand(sql, koneksi)
            dr = cmd.ExecuteReader(CommandBehavior.CloseConnection)

            ListBox1.Items.Clear()
            Do While dr.Read = True
                ListBox1.Items.Add(dr(0))
            Loop
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            cmd.Dispose()
            koneksi.Close()
        End Try
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If ListBox1.SelectedItem = "" Then
            MsgBox("Please select username to delete", MsgBoxStyle.Exclamation, "Delete user")
        Else
            If MsgBox("Are you sure you want delete user?", MsgBoxStyle.YesNo, "Delete User") = MsgBoxResult.Yes Then
                DeleteUser()
                Loadusers()
            Else
                Exit Sub
            End If


        End If
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        txtUser.Enabled = True
        txtCpwd.Enabled = True
        txtPwd.Enabled = True
        txtStaffID.Enabled = True
        cmbRole.Enabled = True
        adding = True
        txtUser.Focus()
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If txtPwd.Text <> txtCpwd.Text Then
            MsgBox("Password Not Match", MsgBoxStyle.Exclamation, "Add user")
            txtPwd.SelectAll()
            txtCpwd.SelectAll()
            txtPwd.Focus()
            Exit Sub

        End If
        If adding = True Then
            AddUser()
            Loadusers()
            txtUser.Enabled = False
            txtCpwd.Enabled = False
            txtPwd.Enabled = False
            txtStaffID.Enabled = False
            cmbRole.Enabled = False
            txtCpwd.Text = ""
            txtPwd.Text = ""
            txtUser.Text = ""
            txtStaffID.Text = ""
            cmbRole.Text = ""
            adding = False
        Else
            MsgBox("Nothing to Save: Click [Add Button] to Add User", MsgBoxStyle.Information, "Add User")
        End If
    End Sub

    Private Sub FUser_Load(sender As Object, e As EventArgs) Handles Me.Load
        txtUser.Enabled = False
        txtCpwd.Enabled = False
        txtPwd.Enabled = False
        txtStaffID.Enabled = False
        cmbRole.Enabled = False
        txtCpwd.Text = ""
        txtPwd.Text = ""
        txtUser.Text = ""
        txtStaffID.Text = ""
        cmbRole.Text = ""
        Loadusers()
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        uSearch = True
        FLStaff.ShowDialog()
    End Sub
End Class