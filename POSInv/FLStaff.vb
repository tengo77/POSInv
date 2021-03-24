Imports System.Data.Sql
Imports System.Data.SqlClient
Public Class FLStaff

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub
    Sub Tampilitem()
        Call buka()
        cmd = New SqlCommand("SELECT StaffID, awal FROM Staff", koneksi)
        Dim dt As New DataTable
        Dim adapter As New SqlDataAdapter
        adapter = New SqlDataAdapter(cmd)
        adapter.Fill(dt)
        dgw.DataSource = dt
        dgw.Refresh()
    End Sub
    Private Sub LoadStaff()

        Try
            Call buka()
            sql = "SELECT StaffID, awal + ' ' + tengah + ' ' + akhir as StaffName, [Position] FROM Staff Order by awal"

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

    Private Sub SearchStaff()
        Try
            Call buka()
            sql = "SELECT StaffID, awal + ' ' + tengah + ' ' + akhir as StaffName, [Position] FROM Staff WHERE awal LIKE '" & TextBox1.Text & "%' Order by awal"

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

    Private Sub frmLoadStaff_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        LoadStaff()
    End Sub

    Private Sub dgw_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgw.CellDoubleClick
        If FKaryawan.search = True Then
            FKaryawan.txtStaffID.Text = dgw.CurrentRow.Cells(0).Value
            Me.Close()
        End If
        If FUser.uSearch = True Then
            FUser.txtStaffID.Text = dgw.CurrentRow.Cells(0).Value
            FUser.uSearch = False
            Me.Close()
        End If
    End Sub

    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.TextChanged
        SearchStaff()
    End Sub
End Class