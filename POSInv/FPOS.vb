Imports System.Data.Sql
Imports System.Data.SqlClient
Public Class FPOS
    Dim itemQuantity As Integer
    Dim productCode As String
    Dim itemDesc As String
    Dim itemPrice As Double
    Dim totalPrice As Double
    Dim totalCost As Double
    Dim disAmount As Double
    Dim itemNum As Integer
    Dim getProdtoDelete As Integer
    Public posSearch As Boolean

    Public isSearchCust As Boolean
    Dim isDiscount As Boolean
    Dim isQuanity As Boolean
    Private Sub BtnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub BtnMax_Click(sender As Object, e As EventArgs) Handles btnMax.Click
        If Me.WindowState = FormWindowState.Normal Then
            Me.WindowState = FormWindowState.Maximized
        Else
            Me.WindowState = FormWindowState.Normal
        End If
    End Sub

    Private Sub BtnMin_Click(sender As Object, e As EventArgs) Handles btnMin.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Function isAvailableQuantity() As Boolean
        Try
            Call buka()
            sql = "SELECT StocksOnHand FROM barang WHERE ItemNo = " & Val(txtSearch.Text) & ""
            cmd = New SqlCommand(sql, koneksi)
            dr = cmd.ExecuteReader(CommandBehavior.CloseConnection)


            If dr.Read = True Then

                If Val(txtQuantity.Text) < dr(0) Then
                    isAvailableQuantity = True
                Else
                    MsgBox("Insuficient stocks", MsgBoxStyle.Critical, "Validate Stocks")
                    txtSearch.Clear()
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            cmd.Dispose()
            koneksi.Close()
        End Try
    End Function

    Private Sub GetInvoiceNo()
        Try
            Call buka()
            sql = "SELECT InvoiceNo FROm POS Order By InvoiceNo desc"
            cmd = New SqlCommand(sql, koneksi)
            dr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            If dr.Read = True Then
                lblInvoiceNo.Text = Val(dr(0)) + 1

            Else
                lblInvoiceNo.Text = 100000000
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            cmd.Dispose()
            koneksi.Close()
        End Try
    End Sub
    Private Sub GetItemInfo()
        Try
            Call buka()
            sql = "SELECT ItemCode, INama, UnitPrice, itemNo FROM barang Where ItemNo = " & Val(txtSearch.Text) & ""
            cmd = New SqlCommand(sql, koneksi)
            dr = cmd.ExecuteReader(CommandBehavior.CloseConnection)

            If dr.Read = True Then
                productCode = dr(0)
                itemDesc = dr(1)
                itemPrice = dr(2)
                itemNum = dr(3)

                If isQuanity = True Then
                    itemQuantity = txtQuantity.Text
                    txtQuantity.Text = ""
                    isQuanity = False
                Else
                    itemQuantity = 1
                End If

                If isDiscount = True Then
                    disAmount = itemPrice * (lblDiscount.Text / 100)
                    itemPrice = itemPrice - disAmount
                    lblDiscount.Text = 0
                    isDiscount = False
                Else
                    disAmount = 0
                End If

                totalPrice = itemQuantity * itemPrice
                totalCost += totalPrice
                lblTotalCost.Text = Format(totalCost, "0")
                AddPOSDetail()
                UpdateDecreaseQuantity()
                dgw.Rows.Add(itemQuantity, productCode, itemDesc, itemPrice, totalPrice)
                txtSearch.Text = ""

            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            cmd.Dispose()
            koneksi.Close()
        End Try
    End Sub

    Private Sub AddPOSDetail()
        Try
            Call buka()
            sql = "INSERT INTO POSDetail(InvoiceNo, ItemNo, itemPrice, Quantity, Discount) Values('" & lblInvoiceNo.Text & "', '" & itemNum & "', '" & itemPrice & "', '" & itemQuantity & "', '" & disAmount & "')"
            cmd = New SqlCommand(sql, koneksi)
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            cmd.Dispose()
            koneksi.Close()
        End Try
    End Sub

    Private Sub UpdateDecreaseQuantity()
        Try
            Call buka()
            sql = "Update barang SET StocksOnHand = stocksOnHand - '" & itemQuantity & "' WHERE ItemNo = " & itemNum & ""
            cmd = New SqlCommand(sql, koneksi)
            cmd.ExecuteNonQuery()

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            cmd.Dispose()
            koneksi.Close()
        End Try
    End Sub

    Private Sub RemoveItem()
        lblTotalCost.Text = Format(lblTotalCost.Text - dgw.CurrentRow.Cells(4).Value, "0")

        GetProductIDToDelete()
        DeletePOSDetail()
        UpdateIncreaseQuantity()
        dgw.Rows.Remove(dgw.SelectedRows.Item(0))
        totalCost = lblTotalCost.Text
    End Sub
    Private Sub GetProductIDToDelete()
        Try
            Call buka()
            sql = "SELECT ItemNo FROM barang Where itemCode = '" & dgw.CurrentRow.Cells(1).Value & "'"
            cmd = New SqlCommand(sql, koneksi)
            dr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            If dr.Read = True Then
                getProdtoDelete = dr(0)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            cmd.Dispose()
            koneksi.Close()
        End Try
    End Sub

    Private Sub DeletePOSDetail()
        Try
            Call buka()
            sql = "DELETE FROM POSDetail WHERE itemNo = " & getProdtoDelete & " AND InvoiceNo = '" & lblInvoiceNo.Text & "'"
            cmd = New SqlCommand(sql, koneksi)
            Dim i As Integer
            i = cmd.ExecuteNonQuery
            If i > 0 Then
                MsgBox("Item Deleted", MsgBoxStyle.Information, "Delete Item")
            Else
                MsgBox("Failed to Delete item", MsgBoxStyle.Critical, "Delete Item")
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            cmd.Dispose()
            koneksi.Close()

        End Try
    End Sub
    Private Sub UpdateIncreaseQuantity()
        Try
            Call buka()
            sql = "Update barang SET StocksOnHand = stocksOnHand + '" & dgw.CurrentRow.Cells(0).Value & "' WHERE ItemNo = " & getProdtoDelete & ""
            cmd = New SqlCommand(sql, koneksi)
            cmd.ExecuteNonQuery()

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            cmd.Dispose()
            koneksi.Close()
        End Try
    End Sub
    Public Sub NewTransaction()
        dgw.Rows.Clear()
        lblTotalCost.Text = "0"
        totalCost = 0
        GetInvoiceNo()
        txtSearch.Focus()
    End Sub


    Public Sub AddPOS()

        Try
            Call buka()
            sql = "INSERT INTO POS(InvoiceNo, POSDate, POSTime, TotalAmount, StaffID, CustomerNo) VALUES('" & lblInvoiceNo.Text & "', '" & Format(Date.Now, "Short Date") & "', '" & Format(Date.Now, "Long Time") & "', '" & lblTotalCost.Text & "', '" & FMain.lblEmployeeNo.Text & "'," & Val(lblCustomerNo.Text) & ")"
            cmd = New SqlCommand(sql, koneksi)

            cmd.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            cmd.Dispose()
            koneksi.Close()
        End Try
    End Sub



    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        lblTime.Text = Format(Date.Now, "Long Time")
    End Sub

    Private Sub frmPOS_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        lbldate.Text = Format(Date.Now, "Long Date")
        Label5.Text = FMain.lblUsr.Text
        GetInvoiceNo()
        Me.WindowState = FormWindowState.Maximized
    End Sub

    Private Sub txtSearch_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSearch.TextChanged
        If isAvailableQuantity() = True Then
            GetItemInfo()
        End If

    End Sub

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        posSearch = True
        FLBarang.ShowDialog()
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub txtQuantity_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtQuantity.KeyPress
        If Not ((e.KeyChar >= "0" And e.KeyChar <= "9") Or e.KeyChar = vbBack) Then e.Handled = True
        If e.KeyChar = ControlChars.Cr Then
            txtSearch.Focus()
        End If
    End Sub

    Private Sub txtQuantity_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtQuantity.TextChanged
        isQuanity = True

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnQuantity.Click
        txtQuantity.Focus()
    End Sub

    Private Sub btnDiscount_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDiscount.Click
        isDiscount = True
        Dim percentDiscount As String
        percentDiscount = InputBox("Enter discount percent", "Discount")
        lblDiscount.Text = Val(percentDiscount)
        txtSearch.Focus()
    End Sub

    Private Sub btnNewTransacation_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNewTransacation.Click
        NewTransaction()
    End Sub

    Private Sub btnPayment_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPayment.Click
        FBayar.Show()
    End Sub

    Private Sub btnCustomer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCustomer.Click
        isSearchCust = True
        FLPelanggan.Show()
    End Sub

    Private Sub BtnRemove_Click(sender As Object, e As EventArgs) Handles btnRemove.Click
        If dgw.Rows.Count = 0 Then
            MsgBox("No Transaction", MsgBoxStyle.Exclamation, "Remove Item")
            txtSearch.Focus()
            Exit Sub
        Else
            If MsgBox("Are you sure you want to Delete?", MsgBoxStyle.YesNo, "Delete Item") = MsgBoxResult.Yes Then
                RemoveItem()
                txtSearch.Focus()
            Else
                Exit Sub
            End If

        End If
    End Sub
End Class