Imports System.Data.Sql
Imports System.Data.SqlClient
Public Class FPelanggan
    Dim adding As Boolean
    Dim updating As Boolean
    Public search As Boolean

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
    End Sub
    Private Sub GetCustomerNo()
        Try
            Call buka()
            sql = "SELECT CustomerNo FROM Customer Order By CustomerNo Desc"
            cmd = New SqlCommand(sql, koneksi)
            dr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            If dr.Read = True Then
                txtCustNo.Text = dr(0) + 1
            Else
                txtCustNo.Text = 1
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            cmd.Dispose()
            koneksi.Close()
        End Try
    End Sub


    Private Sub AddCustomer()
        Try
            Call buka()
            sql = "INSERT INTO Customer(Custname, Alamat, ContactNo) Values('" & txtName.Text & "', '" & txtAddress.Text & "', '" & txtContactNo.Text & "')"
            cmd = New SqlCommand(sql, koneksi)
            Dim i As Integer
            i = cmd.ExecuteNonQuery
            If i > 0 Then
                MsgBox("Customer Added", MsgBoxStyle.Information, "Add Customer")
            Else
                MsgBox("Failed to add customer", MsgBoxStyle.Critical, "Add Customer")

            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            cmd.Dispose()
            koneksi.Close()
        End Try
    End Sub
    Private Sub UpdateCustomer()
        Try
            Call buka()
            sql = "Update Customer SET Custname ='" & txtName.Text & "', Alamat ='" & txtAddress.Text & "', ContactNo = '" & txtContactNo.Text & "' WHERE CustomerNo = " & txtCustNo.Text & ""
            cmd = New SqlCommand(sql, koneksi)
            Dim i As Integer
            i = cmd.ExecuteNonQuery
            If i > 0 Then
                MsgBox("Customer Updated", MsgBoxStyle.Information, "Update Customer")
            Else
                MsgBox("Failed to update customer", MsgBoxStyle.Critical, "Update Customer")
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            cmd.Dispose()
            koneksi.Close()
        End Try
    End Sub
    Private Sub GetCustomerRecord()
        Try
            Call buka()
            sql = "SELECT CustName, Alamat, ContactNo FROM Customer WHERE CustomerNo = " & txtCustNo.Text & ""
            cmd = New SqlCommand(sql, koneksi)
            dr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            If dr.Read = True Then
                txtName.Text = dr(0)
                txtAddress.Text = dr(1)
                txtContactNo.Text = dr(2)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            cmd.Dispose()
            koneksi.Close()
        End Try
    End Sub
    Private Sub ClearFields()
        txtCustNo.Text = ""
        txtName.Text = ""
        txtContactNo.Text = ""
        txtAddress.Text = ""
    End Sub

    Private Sub EnabledText()
        txtCustNo.Enabled = True
        txtName.Enabled = True
        txtAddress.Enabled = True
        txtContactNo.Enabled = True
    End Sub

    Private Sub DisabledText()
        txtCustNo.Enabled = False
        txtName.Enabled = False
        txtAddress.Enabled = False
        txtContactNo.Enabled = False
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

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        DisabledButton()
        ClearFields()
        EnabledText()
        GetCustomerNo()

        adding = True
        updating = False
        txtName.Focus()
        txtCustNo.Enabled = False
    End Sub

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        If txtCustNo.Text = "" Then
            MsgBox("Please select record to update", MsgBoxStyle.Critical, "Update Record")
            Exit Sub
        End If

        EnabledText()
        DisabledButton()

        adding = False
        updating = True
        txtName.Focus()
        txtCustNo.Enabled = False
    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        search = True
        FLPelanggan.ShowDialog()
    End Sub

    Private Sub txtCustNo_TextChanged(sender As Object, e As EventArgs) Handles txtCustNo.TextChanged
        If search = True Then
            GetCustomerRecord()
            search = False
        End If
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If adding = True Then
            AddCustomer()
            DisabledText()
            EnabledButton()
            ClearFields()
        Else
            UpdateCustomer()
            DisabledText()
            EnabledButton()
            ClearFields()
        End If
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        DisabledText()
        EnabledButton()
        ClearFields()
    End Sub

    Private Sub FPelanggan_Load(sender As Object, e As EventArgs) Handles Me.Load
        EnabledButton()
        DisabledText()
    End Sub


    Private Sub txtContactNo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtContactNo.KeyPress
        If Not ((e.KeyChar >= "0" And e.KeyChar <= "9") Or e.KeyChar = vbBack) Then e.Handled = True
    End Sub
End Class