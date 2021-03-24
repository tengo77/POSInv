Imports System.Data.Sql
Imports System.Data.SqlClient
Public Class FLPelanggan
    Private Sub LoadCustomer()
        Try
            Call buka()
            sql = "SELECT CustomerNo, CustName, Alamat FROM Customer Order By CustName"
            cmd = New SqlCommand(sql, koneksi)
            dr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            dgw.Rows.Clear()
            Do While dr.Read = True
                dgw.Rows.Add(dr(0), dr(1), dr(2))
            Loop
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            cmd.Dispose()
            koneksi.Close()
        End Try
    End Sub

    Private Sub SearchCustomer()
        Try
            Call buka()
            sql = "SELECT CustomerNo, CustName, Alamat FROM Customer WHERE CustName LIKE '" & TextBox1.Text & "%' Order By CustName"
            cmd = New SqlCommand(sql, koneksi)
            dr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            dgw.Rows.Clear()
            Do While dr.Read = True
                dgw.Rows.Add(dr(0), dr(1), dr(2))
            Loop
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            cmd.Dispose()
            koneksi.Close()
        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs)
        Me.Close()
    End Sub

    Private Sub dgw_DoubleClick(sender As Object, e As EventArgs) Handles dgw.DoubleClick
        If FPelanggan.search = True Then
            FPelanggan.txtCustNo.Text = dgw.CurrentRow.Cells(0).Value
            Me.Close()
        End If

        If FPOS.isSearchCust = True Then
            FPOS.lblCustomerNo.Text = dgw.CurrentRow.Cells(0).Value
            FPOS.lblCustomerName.Text = dgw.CurrentRow.Cells(1).Value
            FPOS.isSearchCust = False
            Me.Close()
        End If
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        SearchCustomer()
    End Sub

    Private Sub FLPelanggan_Load(sender As Object, e As EventArgs) Handles Me.Load
        LoadCustomer()
    End Sub
End Class