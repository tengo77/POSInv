Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Public Class LapRamal

    Private Sub TextBox1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox1.KeyPress
        If e.KeyChar = Chr(13) Then
            CrystalReportViewer1.SelectionFormula = "{item.namaitem} Like '*" & TextBox1.Text.ToString() & "*' "
            'CrystalReportViewer1.ReportSource = Application.StartupPath & "\DummyRamal.rpt"
            CrystalReportViewer1.ReportSource = "E:\_Sidang\Ujian\POS_Inv\POSInv\POSInv\DummyRamal.rpt"
            CrystalReportViewer1.RefreshReport()
        End If
    End Sub

    Private Sub LapRamal_Load(sender As Object, e As EventArgs) Handles Me.Load
        Me.WindowState = FormWindowState.Maximized
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