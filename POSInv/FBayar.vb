Imports System.Data.Sql
Imports System.Data.SqlClient
Public Class FBayar
    Private Sub AddPayment()
        txtCash.Text = txtCash.Text.Replace(",", "")
        Try
            Call buka()
            sql = "INSERT INTO Bayar(InvoiceNo,[Cash],[Kembalian]) VALUES('" & FPOS.lblInvoiceNo.Text & "','" & txtCash.Text & "', '" & txtChange.Text & "')"
            cmd = New SqlCommand(sql, koneksi)
            cmd.ExecuteNonQuery()

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            cmd.Dispose()
            koneksi.Close()
        End Try
    End Sub

    Private Sub txtCash_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCash.KeyPress
        If Not ((e.KeyChar >= "0" And e.KeyChar <= "9") Or e.KeyChar = vbBack) Then e.Handled = True
        If e.KeyChar = ControlChars.Cr Then

            If txtCash.Text = "" Then
                MsgBox("Please Enter Amount! ", MsgBoxStyle.Information, "Payment")
                txtCash.Focus()
                Exit Sub
            End If

            If Val(txtCash.Text) < Val(txtTA.Text) Then
                MsgBox("The Amount is Lower than the Cost", MsgBoxStyle.Exclamation, "Payment")
                txtCash.SelectAll()
                txtCash.Focus()
                Exit Sub
            End If

            FPOS.AddPOS()
            AddPayment()
            MsgBox("printing receipt...", MsgBoxStyle.Information, "Receipt")
            FReceipt.Show()
            FPOS.NewTransaction()
            FPOS.txtSearch.Focus()
            Me.Close()
        End If
    End Sub

    Private Sub txtCash_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCash.TextChanged
        txtChange.Text = Format(Val(txtCash.Text.Replace(",", "")) - Val(txtTA.Text.Replace(",", "")), "0")
    End Sub

    Private Sub frmPayment_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txtTA.Text = FPOS.lblTotalCost.Text
    End Sub


    Private Sub txtTA_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtTA.KeyPress
        If Not ((e.KeyChar >= "0" And e.KeyChar <= "9") Or e.KeyChar = vbBack) Then e.Handled = True
    End Sub


    Private Sub txtChange_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtChange.KeyPress
        If Not ((e.KeyChar >= "0" And e.KeyChar <= "9") Or e.KeyChar = vbBack) Then e.Handled = True
    End Sub
End Class