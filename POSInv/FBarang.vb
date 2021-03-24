Imports System.Data.Sql
Imports System.Data.SqlClient
Public Class FBarang
    Dim adding As Boolean
    Dim updating As Boolean
    Public search As Boolean
    Dim getStocksOnHand As Integer

    Sub munculsatuan()
        Call buka()
        cmd = New SqlCommand("select distinct satuan from barang", koneksi)
        dr = cmd.ExecuteReader
        txtSatuan.Items.Clear()
        Do While dr.Read
            txtSatuan.Items.Add(dr.Item("Satuan"))
        Loop
    End Sub
    Private Sub GetQuantity()
        Try
            Call buka()
            sql = "SELECT StocksOnhand FROM barang WHERE ItemNo = " & txtItemNo.Text & ""
            cmd = New SqlCommand(sql, koneksi)
            dr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            If dr.Read = True Then
                getStocksOnHand = dr(0)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            cmd.Dispose()
            koneksi.Close()
        End Try
    End Sub

    Private Sub AddStocksInUpdating()
        If txtItemNo.Text = "" Then
            MsgBox("Please select item to add stocks.", MsgBoxStyle.Critical, "Select Item")
            Exit Sub
        End If
        Dim strStocksIn As String
        strStocksIn = InputBox("Enter number of items : ", "Stocks In")
        txtQuantity.Text = Val(txtQuantity.Text) + Val(strStocksIn)
        Try
            Call buka()
            sql = "INSERT INTO StocksIn(ItemNo, ItemQuantity, SIDate, CurrentStocks) VALUES('" & txtItemNo.Text & "', '" & strStocksIn & "', '" & Format(Date.Now, "Short Date") & "', " & txtQuantity.Text & ")"
            cmd = New SqlCommand(sql, koneksi)
            Dim i As Integer

            i = cmd.ExecuteNonQuery()
            If i > 0 Then
                MsgBox("Stocks added successfully", MsgBoxStyle.Information, "Stocks In")
                Updateproduct()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            cmd.Dispose()
            koneksi.Close()
        End Try
    End Sub
    Private Sub DeleteBarang()
        Call buka()

        If MessageBox.Show("Apakah data barang ingin dihapus?", "", MessageBoxButtons.OKCancel) = Windows.Forms.DialogResult.OK Then
            cmd = New SqlCommand("Delete from barang where ItemNo='" & txtItemNo.Text & "'", koneksi)
            cmd.ExecuteNonQuery()
        End If
    End Sub

    Private Sub DeleteStockIn()
        Call buka()
        cmd = New SqlCommand("Delete from StocksIn where ItemNo='" & txtItemNo.Text & "'", koneksi)
        cmd.ExecuteNonQuery()
    End Sub
    Private Sub AddStocksInAdding()
        Try
            Call buka()
            sql = "INSERT INTO StocksIn(ItemNo, ItemQuantity, SIDate) VALUES('" & txtItemNo.Text & "', '" & txtQuantity.Text & "', '" & Format(Date.Now, "Short Date") & "')"
            cmd = New SqlCommand(sql, koneksi)
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            cmd.Dispose()
            koneksi.Close()
        End Try
    End Sub
    Private Sub GetItemNo()
        Try
            Call buka()
            sql = "SELECT ItemNo From barang Order By ItemNo desc"
            cmd = New SqlCommand(sql, koneksi)
            dr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            If dr.Read = True Then
                txtItemNo.Text = dr(0) + 1
            Else
                txtItemNo.Text = 1
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            cmd.Dispose()
            koneksi.Close()
        End Try
    End Sub

    Private Sub AddItem()
        txtUnitPrice.Text = txtUnitPrice.Text.Replace(",", "")
        Try
            Call buka()
            sql = "Insert Into barang(ItemCode, INama, Satuan, StocksOnHand, UnitPrice, OPrice) VALUES('" & txtItemCode.Text & "', '" & txtDescription.Text & "', '" & txtSatuan.Text & "', '" & txtQuantity.Text & "', '" & txtUnitPrice.Text & "', '" & txtOPrice.Text & "')"
            cmd = New SqlCommand(sql, koneksi)
            Dim i As Integer
            i = cmd.ExecuteNonQuery
            If i > 0 Then
                MsgBox("Item Added", MsgBoxStyle.Information, "Add Item")
            Else
                MsgBox("Failed to add item", MsgBoxStyle.Critical, "Add Item")

            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            cmd.Dispose()
            koneksi.Close()
        End Try
    End Sub

    Private Sub UpdateItem()
        txtUnitPrice.Text = txtUnitPrice.Text.Replace(",", "")
        Try
            Call buka()
            sql = "UPDATE barang SET ItemCode = '" & txtItemCode.Text & "', INama = '" & txtDescription.Text & "', Satuan ='" & txtSatuan.Text & "', StocksOnHand = '" & txtQuantity.Text & "', UnitPrice = '" & txtUnitPrice.Text & "', OPrice= '" & txtOPrice.Text & "' WHERE ItemNo = " & txtItemNo.Text & ""
            cmd = New SqlCommand(sql, koneksi)
            Dim i As Integer
            i = cmd.ExecuteNonQuery
            If i > 0 Then
                MsgBox("Item Updated", MsgBoxStyle.Information, "Update Item")
            Else
                MsgBox("Failed to update item", MsgBoxStyle.Information, "Update Item")
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            cmd.Dispose()
            koneksi.Close()
        End Try
    End Sub

    Private Sub GetItemRecord()
        Try
            Call buka()
            sql = "SELECT ItemCode, INama, Satuan, StocksOnHand, UnitPrice, OPrice From barang Where ItemNo = " & txtItemNo.Text & ""
            cmd = New SqlCommand(sql, koneksi)
            dr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            If dr.Read = True Then
                txtItemCode.Text = dr(0)
                txtDescription.Text = dr(1)
                txtSatuan.Text = dr(2)
                txtQuantity.Text = dr(3)
                txtUnitPrice.Text = dr(4)
                txtOPrice.Text = dr(5)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            cmd.Dispose()
            koneksi.Close()
        End Try
    End Sub

    Private Sub ClearFields()
        txtItemNo.Text = ""
        txtItemCode.Text = ""
        txtDescription.Text = ""
        txtSatuan.Text = ""
        txtQuantity.Text = ""
        txtUnitPrice.Text = ""
        txtOPrice.Text = ""
    End Sub

    Private Sub EnabledText()
        txtItemNo.Enabled = True
        txtItemCode.Enabled = True
        txtDescription.Enabled = True
        txtSatuan.Enabled = True
        txtQuantity.Enabled = True
        txtUnitPrice.Enabled = True
        txtOPrice.Enabled = True
    End Sub

    Private Sub DisabledText()
        txtItemNo.Enabled = False
        txtItemCode.Enabled = False
        txtDescription.Enabled = False
        txtSatuan.Enabled = False
        txtQuantity.Enabled = False
        txtUnitPrice.Enabled = False
        txtOPrice.Enabled = False

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

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        adding = True
        updating = False

        EnabledText()
        DisabledButton()
        ClearFields()
        GetItemNo()
        txtItemCode.Focus()
        txtItemNo.Enabled = False
        munculsatuan()
    End Sub

    Private Sub btnUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdate.Click
        adding = False
        updating = True
        EnabledText()
        DisabledButton()
        txtItemCode.Focus()
        txtItemNo.Enabled = False
        munculsatuan()
    End Sub

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        search = True
        FLBarang.ShowDialog()
    End Sub

    Private Sub txtItemNo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtItemNo.TextChanged
        If search = True Then
            GetItemRecord()
            search = False
        End If
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub
    Private Sub Updateproduct()
        GetQuantity()
        UpdateItem()
        DisabledText()
        EnabledButton()
        ClearFields()
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If adding = True Then
            AddItem()
            AddStocksInAdding()
            DisabledText()
            EnabledButton()
            ClearFields()
        Else
            Updateproduct()
        End If
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        DisabledText()
        EnabledButton()
        ClearFields()
    End Sub

    Private Sub frmItem_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        EnabledButton()
        DisabledText()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        AddStocksInUpdating()
    End Sub

    Private Sub Del_Click(sender As Object, e As EventArgs) Handles Del.Click
        DeleteBarang()
        DeleteStockIn()
        ClearFields()
    End Sub


    Private Sub txtQuantity_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtQuantity.KeyPress
        If Not ((e.KeyChar >= "0" And e.KeyChar <= "9") Or e.KeyChar = vbBack) Then e.Handled = True
    End Sub


    Private Sub txtUnitPrice_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtUnitPrice.KeyPress
        If Not ((e.KeyChar >= "0" And e.KeyChar <= "9") Or e.KeyChar = vbBack) Then e.Handled = True
    End Sub

    Private Sub txtReproduceLevel_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtOPrice.KeyPress
        If Not ((e.KeyChar >= "0" And e.KeyChar <= "9") Or e.KeyChar = vbBack) Then e.Handled = True
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
    End Sub
End Class