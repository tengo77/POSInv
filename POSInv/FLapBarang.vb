Imports System.Data.Sql
Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Public Class FLapBarang


    Private Sub TextBox1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox1.KeyPress

        If e.KeyChar = Chr(13) Then
            CrystalReportViewer1.SelectionFormula = "{barang.INama} Like '*" & TextBox1.Text.ToString() & "*' "
            CrystalReportViewer1.ReportSource = Application.StartupPath & "\Barang.rpt"
            CrystalReportViewer1.RefreshReport()
        End If
    End Sub


    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click
        Dim rptDoc As New ReportDocument
        'rptDoc.Load(Application.StartupPath & "\CrystalReport1.rpt")
        'CrystalReportViewer1.ReportSource = Application.StartupPath + "F:\POS\POSInv\POSInv\CrystalReport1.rpt"
        'CrystalReportViewer1.SelectionFormula = "{barang.INama} = '" & TextBox1.Text.ToString() & "'"
        'CrystalReportViewer1.Refresh()
        'CrystalReportViewer1.RefreshReport()

    End Sub
End Class