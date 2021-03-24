Imports System.Data.Sql
Imports System.Data.SqlClient
Imports System.Windows.Forms.DataVisualization.Charting
Public Class FGrafik

    Private Sub FGrafik_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        cmd = New SqlCommand("SELECT * FROM posinv", koneksi)
        Dim dt As New DataTable
        Dim adapter As New SqlDataAdapter
        adapter = New SqlDataAdapter(cmd)
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
    Private Sub Bersih()
        CBItem.Text = ""
    End Sub

    Private Sub FGrafik_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call TampilCombo()
    End Sub

    Private Sub proses_Click(sender As Object, e As EventArgs) Handles proses.Click
        If CBItem.Text = "" Then
            MsgBox("Silahkan Isi Semua Form")
        End If

        Call buka()
        Try
            Dim cari As String
            Dim iditem As Integer
            Dim desc() As String = {"Aktual", "Forecasting"}
            Dim nak() As Integer = {}
            Dim nfo() As Integer = {}
            cari = "SELECT * FROM item WHERE namaitem = '" & CBItem.Text & "'"
            cmdcari = New SqlCommand(cari, koneksi)
            bacacari = cmdcari.ExecuteReader
            bacacari.Read()
            iditem = bacacari("iditem")
            Dim x As Integer = 0
            Dim query As String
            cari = "WITH cte AS (SELECT *, ROW_NUMBER() OVER (PARTITION BY nperiode ORDER BY mape ASC) AS rn FROM forecasting WHERE iditem = '" & iditem & "' AND mape IS NOT NULL) SELECT * FROM cte WHERE rn = 1"
            cmdcari = New SqlCommand(cari, koneksi)
            bacacari = cmdcari.ExecuteReader
            If bacacari.HasRows Then
                Do While bacacari.Read
                    query = "SELECT * FROM forecasting WHERE idforecasting = '" & bacacari("idforecasting") & "'"
                    cmd = New SqlCommand(query, koneksi)
                    baca = cmd.ExecuteReader
                    baca.Read()
                    ReDim Preserve nak(x)
                    nak(x) = bacacari("aktual")
                    ReDim Preserve nfo(x)
                    nfo(x) = bacacari("hasil")
                    x = x + 1
                Loop
            End If

            x = x - 1
            Dim nid(x) As Integer
            With Chart1
                .Series.Clear()
                For a As Integer = 0 To desc.Length - 1
                    .Series.Add(desc(a))
                Next
                For a As Integer = 0 To desc.Length - 1
                    .Series(a).ChartType = SeriesChartType.Line
                Next
                .Series(0).Points.DataBindXY(nid, nak)
                .Series(1).Points.DataBindXY(nid, nfo)
            End With
        Catch ex As Exception
            MessageBox.Show("Gagal.")
        End Try
        Bersih()
    End Sub

    Private Sub BtnMin_Click(sender As Object, e As EventArgs) Handles btnMin.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub

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
End Class