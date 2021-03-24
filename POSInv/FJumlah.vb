Imports System.Data.Sql
Imports System.Data.SqlClient

Public Class FJumlah
    Dim ketemu As Boolean

    Private Sub FJumlah_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        Call Tampilitem()
        Call AturDGV()
        Call buka()
        cmd = New SqlCommand("SELECT * FROM inventory", koneksi)
        Dim dt As New DataTable
        Dim adapter As New SqlDataAdapter
        adapter = New SqlDataAdapter(cmd)
        Call Bersih()
    End Sub

    Private Sub tambahdata_Click(sender As Object, e As EventArgs) Handles tambahdata.Click
        If CBItem.Text = "" Or TBJumlah.Text = "" Or DTP.Text = "" Then
            MsgBox("Silahkan Isi Semua Form")
        End If

        Call buka()
        Try
            Dim strArr() As String
            strArr = DTP.Text.Split(" ")
            Dim arra() As Decimal = {0.1, 0.2, 0.3, 0.4, 0.5, 0.6, 0.7, 0.8, 0.9}
            Dim arrb() As Decimal = {0.9, 0.8, 0.7, 0.6, 0.5, 0.4, 0.3, 0.2, 0.1}
            Dim arrc() As Decimal = {0.11, 0.25, 0.43, 0.67, 1.0, 1.5, 2.33, 4, 9}
            Dim simpan As String
            Dim cari As String
            Dim prd As Integer
            Dim prdnext As Integer
            cari = "SELECT * FROM item WHERE namaitem = '" & CBItem.Text & "'"
            cmdcari = New SqlCommand(cari, koneksi)
            bacacari = cmdcari.ExecuteReader
            bacacari.Read()
            Dim iditem As Integer = bacacari("iditem")
            Dim cek As String
            cek = "SELECT TOP 1 * FROM qty WHERE iditem = '" & iditem & "' ORDER BY idqty DESC"
            cmdcek = New SqlCommand(cek, koneksi)
            bacacek = cmdcek.ExecuteReader
            If bacacek.HasRows Then
                bacacek.Read()
                prd = bacacek("nperiode")
                prdnext = prd + 1

                simpan = "INSERT INTO qty (iditem,nperiode,bulan,tahun,jumlah) VALUES ('" & iditem & "','" & prdnext & "','" & strArr(0) & "','" & strArr(1) & "','" & TBJumlah.Text & "')"
                cmd = New SqlCommand(simpan, koneksi)
                cmd.ExecuteNonQuery()
            Else
                prd = 1
                simpan = "INSERT INTO qty (iditem,nperiode,bulan,tahun,jumlah) VALUES ('" & iditem & "','" & prd & "','" & strArr(0) & "','" & strArr(1) & "','" & TBJumlah.Text & "')"
                cmd = New SqlCommand(simpan, koneksi)
                cmd.ExecuteNonQuery()
            End If
            MsgBox("Data berhasil di Simpan", MsgBoxStyle.Information, "Information")
        Catch ex As Exception
            MessageBox.Show("Input data gagal dilakukan.")
        End Try
        Bersih()
    End Sub

    Sub Tampilitem()
        Call buka()
        Dim tabel As SqlDataAdapter
        Dim data As DataSet
        Dim record As New BindingSource
        tabel = New SqlDataAdapter("SELECT item.namaitem, qty.bulan, qty.tahun, qty.nperiode, qty.jumlah, qty.idqty FROM qty INNER JOIN item ON item.iditem = qty.iditem ORDER BY qty.idqty ASC", koneksi)
        data = New DataSet
        tabel.Fill(data)
        record.DataSource = data
        record.DataMember = data.Tables(0).ToString()
        DGVJual.DataSource = record
        DGVJual.ReadOnly = True
    End Sub

    Sub AturDGV()
        Try
            DGVJual.Columns(0).Width = 300
            DGVJual.Columns(1).Width = 300
            DGVJual.Columns(2).Width = 300
            DGVJual.Columns(3).Width = 65
            DGVJual.Columns(4).Width = 320
            DGVJual.Columns(5).Width = 20

            DGVJual.Columns(0).HeaderText = "ITEM"
            DGVJual.Columns(1).HeaderText = "BULAN"
            DGVJual.Columns(2).HeaderText = "TAHUN"
            DGVJual.Columns(3).HeaderText = "PERIODE"
            DGVJual.Columns(4).HeaderText = "JUMLAH"
            DGVJual.Columns(5).HeaderText = "-"
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Bersih()
        CBItem.Text = ""
        TBJumlah.Text = ""
    End Sub

    Private Sub TampilCombo()
        Call buka()
        Dim str As String
        str = "SELECT namaitem FROM item"
        cmd = New SqlCommand(str, koneksi)
        baca = cmd.ExecuteReader
        If baca.HasRows Then
            Do While baca.Read
                CBItem.Items.Add(baca("namaitem"))
            Loop
        End If
    End Sub

    'Private Sub ubahdata_Click(sender As Object, e As EventArgs)
    '    If CBItem.Text = "" Or TBJumlah.Text = "" Then
    '        MsgBox("Silahkan Isi Semua Form")
    '    End If

    '    Call buka()
    '    Try
    '        Dim cari As String
    '        cari = "SELECT * FROM item WHERE namaitem = '" & CBItem.Text & "'"
    '        cmdcari = New SqlCommand(cari, koneksi)
    '        bacacari = cmdcari.ExecuteReader
    '        bacacari.Read()
    '        Dim iditem As Integer = bacacari("iditem")
    '        Dim update As String = "UPDATE qty SET iditem ='" & iditem & "',jumlah ='" & TBJumlah.Text & "' WHERE idqty ='" & TBid.Text & "'"
    '        cmd = New SqlCommand(update, koneksi)
    '        cmd.ExecuteNonQuery()
    '        MsgBox("Data berhasil di Update", MsgBoxStyle.Information, "Information")
    '    Catch ex As Exception
    '        MessageBox.Show("Update data gagal dilakukan.")
    '    End Try
    '    Bersih()
    'End Sub

    'Private Sub hapusdata_Click(sender As Object, e As EventArgs)
    '    Call buka()
    '    Dim hapus As String = "DELETE qty WHERE idqty ='" & TBid.Text & "'"
    '    cmd = New SqlCommand(hapus, koneksi)
    '    cmd.ExecuteNonQuery()
    '    MsgBox("Data berhasil di hapus", MsgBoxStyle.Information, "Information")
    '    Call Bersih()
    'End Sub

    Private Sub FJumlah_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call TampilCombo()
        'Me.WindowState = FormWindowState.Maximized
    End Sub

    Private Sub DGVJual_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DGVJual.CellContentClick
        On Error Resume Next
        CBItem.Text = DGVJual.Rows(e.RowIndex).Cells(0).Value
        TBJumlah.Text = DGVJual.Rows(e.RowIndex).Cells(4).Value
        TBid.Text = DGVJual.Rows(e.RowIndex).Cells(5).Value
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If CBItem.Text = "" Or TBJumlah.Text = "" Then
            MsgBox("Silahkan Isi Semua Form")
        End If

        Call buka()
        Try
            Dim cari As String
            cari = "SELECT * FROM item WHERE namaitem = '" & CBItem.Text & "'"
            cmdcari = New SqlCommand(cari, koneksi)
            bacacari = cmdcari.ExecuteReader
            bacacari.Read()
            Dim iditem As Integer = bacacari("iditem")
            Dim update As String = "UPDATE qty SET iditem ='" & iditem & "',jumlah ='" & TBJumlah.Text & "' WHERE idqty ='" & TBid.Text & "'"
            cmd = New SqlCommand(update, koneksi)
            cmd.ExecuteNonQuery()
            MsgBox("Data berhasil di Update", MsgBoxStyle.Information, "Information")
        Catch ex As Exception
            MessageBox.Show("Update data gagal dilakukan.")
        End Try
        Bersih()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Call buka()
        Dim hapus As String = "DELETE qty WHERE idqty ='" & TBid.Text & "'"
        cmd = New SqlCommand(hapus, koneksi)
        cmd.ExecuteNonQuery()
        MsgBox("Data berhasil di hapus", MsgBoxStyle.Information, "Information")
        Call Bersih()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        FHapus.Show()
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

    Private Sub BtnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        FItem.ShowDialog()
    End Sub


    Private Sub TBJumlah_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TBJumlah.KeyPress
        If Not ((e.KeyChar >= "0" And e.KeyChar <= "9") Or e.KeyChar = vbBack) Then e.Handled = True
    End Sub
End Class