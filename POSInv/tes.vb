Imports System.Data.Sql
Imports System.Data.SqlClient
Public Class tes

    Private Sub tes_Load(sender As Object, e As EventArgs) Handles Me.Load
        DateTimePicker1.Value = Now
        DateTimePicker2.Value = Now
        Me.WindowState = FormWindowState.Maximized
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

    Private Sub BtnMin_Click(sender As Object, e As EventArgs) Handles btnMin.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked = True Then
            TextBox1.Enabled = True
            TextBox1.Focus()
            DateTimePicker1.Enabled = False
            DateTimePicker2.Enabled = False
        Else
            TextBox1.Enabled = False
            DateTimePicker1.Enabled = True
            DateTimePicker2.Enabled = True
        End If
    End Sub

    Private Sub btnCari_Click(sender As Object, e As EventArgs) Handles btnCari.Click
        Dim stringFormula As String

        CrystalReportViewer1.ReportSource = "E:\_Sidang\Ujian\POS_Inv\POSInv\POSInv\teee.rpt"

        If CheckBox1.Checked = True Then
            If Not String.IsNullOrEmpty(Me.TextBox1.Text) Then
                stringFormula = "{Barang.INama} Like '*" & TextBox1.Text.ToString() & "*' "
                CrystalReportViewer1.ReportSource = Application.StartupPath & "\teee.rpt"
                'stringFormula &= "Or {Staff.Awal} Like '*" & TextBox1.Text.ToString() & "*' "
                'stringFormula &= "Or {Barang.INama} Like '*" & TextBox1.Text.ToString() & "*' "
            Else
                stringFormula = ""
            End If
        Else
            stringFormula = "(DateValue({POS.POSDate}))  >= #" & Me.DateTimePicker1.Value.ToShortDateString & "# "
            stringFormula &= "And  (DateValue({POS.POSDate})) <= #" & Me.DateTimePicker2.Value.ToShortDateString & "# "
        End If


        CrystalReportViewer1.SelectionFormula = stringFormula

        'CrystalReportViewer1.Refresh()
        CrystalReportViewer1.RefreshReport()
    End Sub
End Class