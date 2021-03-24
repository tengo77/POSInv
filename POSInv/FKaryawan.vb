Imports System.Data.Sql
Imports System.Data.SqlClient
Public Class FKaryawan
    Public adding As Boolean
    Public updating As Boolean
    Public search As Boolean

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
    End Sub

    Private Sub GetStaffID()
        Try
            Call buka()
            sql = "SELECT StaffID FROM Staff Order By StaffID Desc"

            cmd = New SqlCommand(sql, koneksi)
            dr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            If dr.Read = True Then
                txtStaffID.Text = dr(0) + 1
            Else
                txtStaffID.Text = 1
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            cmd.Dispose()
            koneksi.Close()
        End Try
    End Sub
    Private Sub TambahStaff()
        Try
            Call buka()
            sql = "INSERT INTO Staff(akhir, awal, tengah, Alamat, ContactNo, [Position]) VALUES('" & txtLastname.Text & "', '" & txtFirstname.Text & "', '" & txtMI.Text & "', '" & txtAddress.Text & "', '" & txtContactNo.Text & "', '" & txtPosition.Text & "')"

            cmd = New SqlCommand(sql, koneksi)
            Dim i As Integer
            i = cmd.ExecuteNonQuery
            If i > 0 Then
                MsgBox("Staff Added", MsgBoxStyle.Information, "Add Staff")
            Else
                MsgBox("Failed to add staff", MsgBoxStyle.Critical, "Add Staff")
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            cmd.Dispose()
            koneksi.Close()
        End Try
    End Sub
    Private Sub UpdateStaff()
        Try
            Call buka()
            sql = "Update Staff SET akhir ='" & txtLastname.Text & "', awal = '" & txtFirstname.Text & "', tengah = '" & txtMI.Text & "', Alamat= '" & txtAddress.Text & "', ContactNo = '" & txtContactNo.Text & "', [Position] = '" & txtPosition.Text & "' WHERE StaffID = " & txtStaffID.Text & ""

            cmd = New SqlCommand(sql, koneksi)
            Dim i As Integer
            i = cmd.ExecuteNonQuery
            If i > 0 Then
                MsgBox("Staff Updated", MsgBoxStyle.Information, "Update Staff")
            Else
                MsgBox("Failed in updating staff", MsgBoxStyle.Critical, "Update Staff")
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            cmd.Dispose()
            koneksi.Close()
        End Try
    End Sub
    Private Sub GetStaffRecord()
        Try
            Call buka()
            sql = "SELECT * From Staff WHERE StaffID = " & txtStaffID.Text & ""

            cmd = New SqlCommand(sql, koneksi)
            dr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            If dr.Read = True Then
                txtLastname.Text = dr("akhir")
                txtFirstname.Text = dr("awal")
                txtMI.Text = dr("tengah")
                txtAddress.Text = dr("Alamat")
                txtContactNo.Text = dr("ContactNo")
                txtPosition.Text = dr("Position")

            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            cmd.Dispose()
            koneksi.Close()
        End Try
    End Sub
    Private Sub CLearFields()
        txtStaffID.Text = ""
        txtLastname.Text = ""
        txtFirstname.Text = ""
        txtMI.Text = ""
        txtAddress.Text = ""
        txtContactNo.Text = ""
        txtPosition.Text = ""
    End Sub

    Private Sub EnabledText()
        txtStaffID.Enabled = True
        txtLastname.Enabled = True
        txtFirstname.Enabled = True
        txtMI.Enabled = True
        txtAddress.Enabled = True
        txtContactNo.Enabled = True
        txtPosition.Enabled = True
    End Sub
    Private Sub DisabledText()
        txtStaffID.Enabled = False
        txtLastname.Enabled = False
        txtFirstname.Enabled = False
        txtMI.Enabled = False
        txtAddress.Enabled = False
        txtContactNo.Enabled = False
        txtPosition.Enabled = False
    End Sub
    Private Sub EnabledButton()
        btnAdd.Enabled = True
        btnUpdate.Enabled = True
        btnSearch.Enabled = True
        btnClose.Enabled = True

        btnSave.Enabled = False
        btnCancel.Enabled = False
    End Sub

    Private Sub DisabledButton()
        btnAdd.Enabled = False
        btnUpdate.Enabled = False
        btnSearch.Enabled = False
        btnClose.Enabled = False

        btnSave.Enabled = True
        btnCancel.Enabled = True
    End Sub

    Private Sub FKaryawan_Load(sender As Object, e As EventArgs) Handles Me.Load
        DisabledText()
        EnabledButton()
    End Sub
    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        adding = True
        updating = False

        EnabledText()
        CLearFields()
        DisabledButton()
        GetStaffID()
        txtLastname.Focus()
        txtStaffID.Enabled = False
    End Sub

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        If txtStaffID.Text = "" Then
            MsgBox("Please select record to update", MsgBoxStyle.Information, "Update Record")
            Exit Sub
        End If

        adding = False
        updating = True
        EnabledText()
        DisabledButton()
        txtLastname.Focus()
        txtStaffID.Enabled = False
    End Sub
    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If adding = True Then
            TambahStaff()
            DisabledText()
            EnabledButton()
            CLearFields()
        Else
            UpdateStaff()
            DisabledText()
            EnabledButton()
            CLearFields()
        End If
    End Sub
    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        DisabledText()
        EnabledButton()
        CLearFields()
    End Sub

    Private Sub txtStaffID_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtStaffID.TextChanged
        If search = True Then
            GetStaffRecord()
            search = False
        End If

    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        search = True
        FLStaff.ShowDialog()
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub txtContactNo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtContactNo.KeyPress
        If Not ((e.KeyChar >= "0" And e.KeyChar <= "9") Or e.KeyChar = vbBack) Then e.Handled = True
    End Sub

End Class