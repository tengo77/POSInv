Imports System.Data.Sql
Imports System.Data.SqlClient
Public Class FLBarang
    Private Sub LoadItem()
        Try
            Call buka()
            sql = "SELECT ItemNo, itemCode, INama, StocksOnHand FROM barang Order By INama"
            cmd = New SqlCommand(sql, koneksi)
            dr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            dgw.Rows.Clear()
            Do While dr.Read = True
                dgw.Rows.Add(dr(0), dr(1), dr(2), dr(3))
            Loop
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            cmd.Dispose()
            koneksi.Close()
        End Try
    End Sub

    Private Sub Search()
        Try
            Call buka()
            sql = "SELECT ItemNo, itemCode, INama, StocksOnHand FROM barang WHERE INama LIKE '" & TextBox1.Text & "%' Order By INama"
            cmd = New SqlCommand(sql, koneksi)
            dr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
            dgw.Rows.Clear()
            Do While dr.Read = True
                dgw.Rows.Add(dr(0), dr(1), dr(2), dr(3))
            Loop
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            cmd.Dispose()
            koneksi.Close()
        End Try
    End Sub

    Private Sub frmLoadItem_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadItem()
    End Sub

    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.TextChanged
        Search()
    End Sub

    Private Sub dgw_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgw.CellDoubleClick
        If FBarang.search = True Then
            FBarang.txtItemNo.Text = dgw.CurrentRow.Cells(0).Value
            FBarang.search = False
            Me.Close()
        End If

        If FPOS.posSearch = True Then
            FPOS.txtSearch.Text = dgw.CurrentRow.Cells(0).Value
            FPOS.posSearch = False
            Me.Close()
        End If

    End Sub
End Class