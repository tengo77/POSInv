Imports System.Data.Sql
Imports System.Data.SqlClient
Public Class FStockOut

    Private Sub loadsolditem()
        Dim totalAmount As Double
        Dim totalQuantity As Integer
        Try
            Call buka()
            sql = "SELECT INama, UnitPrice, SUM([Quantity]) as ItemQuantity, POSDate, (UnitPrice * SUM([Quantity])) As TotalAmount FROM barang as I, POS as P, POSDetail as PD WHERE I.ItemNo = PD.ItemNo AND PD.InvoiceNo=P.InvoiceNo AND POSDate >= #" & dtpFrom.Text & "# AND POSDate <=#" & dtpTo.Text & "# Group By INama, UnitPrice, [Quantity], POSDate Order By INama"
            cmd = New SqlCommand(sql, koneksi)
            dr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            dgw.Rows.Clear()

            totalAmount = 0
            totalQuantity = 0
            Do While dr.Read = True
                dgw.Rows.Add(dr(0), dr(1), dr(2), dr(4))
                totalAmount += dr(4)
                totalQuantity += dr(2)
            Loop

            lblQuantity.Text = totalQuantity
            lblTotal.Text = Format(totalAmount, "#,##0.00")
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            cmd.Dispose()
            koneksi.Close()
        End Try
    End Sub
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        loadsolditem()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub FStockOut_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lblQuantity.Text = ""
        lblTotal.Text = ""
        dgw.Rows.Clear()
    End Sub
End Class