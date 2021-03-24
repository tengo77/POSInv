Public Class FMain

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        End
    End Sub

    Private Sub btnMin_Click(sender As Object, e As EventArgs) Handles btnMin.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub

    Private Sub btnMax_Click(sender As Object, e As EventArgs) Handles btnMax.Click
        If Me.WindowState = FormWindowState.Normal Then
            Me.WindowState = FormWindowState.Maximized
        Else
            Me.WindowState = FormWindowState.Normal
        End If

    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles lblSelect1.Click

    End Sub

    Private Sub btnMaster_Click(sender As Object, e As EventArgs) Handles btnMaster.Click
        lblSelect1.Visible = True
        lblSelect2.Visible = False
        lblSelect3.Visible = False
        lblSelect4.Visible = False
        lblSelect5.Visible = False
        lblSelect6.Visible = False

        'tampil panel content
        pnlTentang.Visible = False
        pnlMaster.Visible = True
        pnlTransaksi.Visible = False
        pnlRamal.Visible = False
        pnlLap.Visible = False
        pnlTentang.Visible = False
    End Sub

    Private Sub btnTransaksi_Click(sender As Object, e As EventArgs) Handles btnTransaksi.Click
        lblSelect1.Visible = False
        lblSelect2.Visible = True
        lblSelect3.Visible = False
        lblSelect4.Visible = False
        lblSelect5.Visible = False
        lblSelect6.Visible = False
        'tampil panel content
        pnlTentang.Visible = False
        pnlMaster.Visible = False
        pnlTransaksi.Visible = True
        pnlRamal.Visible = False
        pnlLap.Visible = False
        pnlTentang.Visible = False
    End Sub

    Private Sub btnPeramalan_Click(sender As Object, e As EventArgs) Handles btnPeramalan.Click
        lblSelect1.Visible = False
        lblSelect2.Visible = False
        lblSelect3.Visible = True
        lblSelect4.Visible = False
        lblSelect5.Visible = False
        lblSelect6.Visible = False
        'tampil panel content
        pnlTentang.Visible = False
        pnlMaster.Visible = False
        pnlTransaksi.Visible = False
        pnlRamal.Visible = True
        pnlLap.Visible = False
        pnlTentang.Visible = False
    End Sub

    Private Sub btnLaporan_Click(sender As Object, e As EventArgs) Handles btnLaporan.Click
        lblSelect1.Visible = False
        lblSelect2.Visible = False
        lblSelect3.Visible = False
        lblSelect4.Visible = True
        lblSelect5.Visible = False
        lblSelect6.Visible = False
        'tampil panel content
        pnlTentang.Visible = False
        pnlMaster.Visible = False
        pnlTransaksi.Visible = False
        pnlRamal.Visible = False
        pnlLap.Visible = True
        pnlTentang.Visible = False
    End Sub

    Private Sub btnTentang_Click(sender As Object, e As EventArgs) Handles btnTentang.Click
        lblSelect1.Visible = False
        lblSelect2.Visible = False
        lblSelect3.Visible = False
        lblSelect4.Visible = False
        lblSelect5.Visible = True
        lblSelect6.Visible = False
        'tampil panel content
        pnlTentang.Visible = False
        pnlMaster.Visible = False
        pnlTransaksi.Visible = False
        pnlRamal.Visible = False
        pnlLap.Visible = False
        pnlTentang.Visible = True
    End Sub
    Private Sub btnLogOut_Click(sender As Object, e As EventArgs) Handles btnLogOut.Click
        lblSelect1.Visible = False
        lblSelect2.Visible = False
        lblSelect3.Visible = False
        lblSelect4.Visible = False
        lblSelect5.Visible = False
        lblSelect6.Visible = True
        Me.Close()
        FLogin.ShowDialog()
    End Sub

 
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        lblJam.Text = Format(Date.Now, "long time")
    End Sub


    Private Sub FMain_Load(sender As Object, e As EventArgs) Handles Me.Load
        lblTgl.Text = Date.Now.ToString("dddd") & " - " & Date.Now.ToString("MM dd, yyyy")
        Me.WindowState = FormWindowState.Maximized
    End Sub

    Private Sub btnBarang_Click(sender As Object, e As EventArgs) Handles btnBarang.Click
        FItem.ShowDialog()

    End Sub

    Private Sub btnPeriode_Click(sender As Object, e As EventArgs) Handles btnPeriode.Click
        FJumlah.ShowDialog()
    End Sub

    Private Sub btnRamal_Click(sender As Object, e As EventArgs) Handles btnRamal.Click
        FRamal.ShowDialog()
    End Sub

    Private Sub btnGrafik_Click(sender As Object, e As EventArgs) Handles btnGrafik.Click
        FGrafik.ShowDialog()
    End Sub

    Private Sub btnKry_Click(sender As Object, e As EventArgs) Handles btnKry.Click
        FKaryawan.ShowDialog()
    End Sub

    Private Sub btnUsr_Click(sender As Object, e As EventArgs) Handles btnUsr.Click
        FUser.ShowDialog()
    End Sub

    Private Sub btnPlg_Click(sender As Object, e As EventArgs) Handles btnPlg.Click
        FPelanggan.ShowDialog()
    End Sub

    Private Sub BtnBrg_Click(sender As Object, e As EventArgs) Handles btnBrg.Click
        FBarang.ShowDialog()
    End Sub

    Private Sub btnTrs_Click(sender As Object, e As EventArgs) Handles btnTrs.Click
        FPOS.ShowDialog()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        LapRamal.ShowDialog()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        FLapBar.ShowDialog()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        FLapInvoice.ShowDialog()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        tes.ShowDialog()
    End Sub
End Class