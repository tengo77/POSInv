Imports System.Data.Sql
Imports System.Data.SqlClient
Public Class FLogin

    Sub tampilkan()
        FMain.lblEmployeeNo.Text = dr("StaffID")
        FMain.lblUsr.Text = dr!Username
        FMain.lblRole.Text = dr!role

    End Sub

    Sub restrict()
        FMain.btnMaster.Enabled = False
        FMain.btnPeramalan.Enabled = False
        FMain.btnLaporan.Enabled = False
    End Sub
    Sub granted()
        FMain.btnMaster.Enabled = True
        FMain.btnPeramalan.Enabled = True
        FMain.btnLaporan.Enabled = True
    End Sub

    Private Sub UsernameTextBox_Leave(sender As Object, e As EventArgs) Handles txtUser.Leave
        If txtUser.Text = "Username" Or txtUser.Text = "" Then
            txtUser.ForeColor = Color.Silver
            txtUser.Text = "Username"
        End If
    End Sub

    Private Sub UsernameTextBox_LostFocus(sender As Object, e As EventArgs) Handles txtUser.LostFocus
        If txtUser.Text = "Username" Or txtUser.Text = "" Then
            txtUser.ForeColor = Color.Silver
            txtUser.Text = "Username"
        End If
    End Sub

    Private Sub UsernameTextBox_MouseClick(sender As Object, e As MouseEventArgs) Handles txtUser.MouseClick
        If txtUser.Text = "Username" Then
            txtUser.Clear()
            txtUser.ForeColor = Color.Black
        End If
    End Sub

    Private Sub PasswordTextBox_Leave(sender As Object, e As EventArgs) Handles txtPwd.Leave
        If txtPwd.Text = "Password" Or txtPwd.Text = "" Then
            txtPwd.Text = "Password"
            txtPwd.ForeColor = Color.Silver
            txtPwd.PasswordChar = ""
        End If
    End Sub

    Private Sub PasswordTextBox_MouseClick(sender As Object, e As MouseEventArgs) Handles txtPwd.MouseClick
        If txtPwd.Text = "Password" Then
            txtPwd.Clear()
            txtPwd.ForeColor = Color.Black
            txtPwd.PasswordChar = "*"
        End If
    End Sub


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        End
    End Sub

    Private Sub UsernameTextBox_TextChanged(sender As Object, e As EventArgs) Handles txtUser.TextChanged
        If txtUser.Text = "Username" Then
            txtUser.ForeColor = Color.Silver
        Else
            txtUser.ForeColor = Color.Black
        End If
    End Sub


    Private Sub OK_Click(sender As Object, e As EventArgs) Handles OK.Click
        buka()
        cmd = New SqlCommand("SELECT * FROM tuser WHERE username= '" & txtUser.Text & "'", koneksi)
        dr = cmd.ExecuteReader
        dr.Read()
        If dr.HasRows Then 'jika username inputan terdapat dalam database
            If txtPwd.Text = dr.Item("pwd") Then 'jika password cocok dengan username
                If dr.Item("role") = "Admin" Then 'jika jenis user karyawan maka di beri nilai var user = karyawan
                    user = "Admin"
                    txtUser.Text = ""
                    txtPwd.Text = ""
                    MsgBox("Selamat Datang " & dr.Item("username"), MsgBoxStyle.MsgBoxSetForeground)
                    Call granted()
                    Call tampilkan()
                    FMain.Show()
                    Me.Hide()
                ElseIf dr.Item("role") = "Karyawan" Then 'jika jenis user karyawan maka di beri nilai var user = karyawan
                    user = "Karyawan"
                    txtUser.Text = ""
                    txtPwd.Text = ""
                    MsgBox("Selamat Datang " & dr.Item("username"), MsgBoxStyle.MsgBoxSetForeground)

                    Call restrict()
                    Call tampilkan()

                    FMain.Show()
                    Me.Hide()
                End If
            Else
                MsgBox("Username dan Password Tidak Cocok", MsgBoxStyle.Critical) 'jika password tidak cocok dengan username
                txtUser.Text = ""
                txtPwd.Text = ""
                txtUser.Focus()
            End If
        Else
            MsgBox("Username Tidak Ada", MsgBoxStyle.Critical) 'jika username inputan tidak ada dalam database
            txtUser.Text = ""
            txtPwd.Text = ""
            txtUser.Focus()
        End If
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        If txtPwd.UseSystemPasswordChar = True Then
            txtPwd.UseSystemPasswordChar = False
        Else
            txtPwd.UseSystemPasswordChar = True
        End If
    End Sub

    Private Sub FLogin_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call buka()
    End Sub
End Class
