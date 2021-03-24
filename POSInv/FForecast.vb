Imports System.Data.Sql
Imports System.Data.SqlClient
Public Class FForecast

    Private Sub TampilCombo()
        'Call buka()
        'Dim str As String
        'str = "SELECT namaitem FROM item"
        'cmd = New SqlCommand(str, koneksi)
        'baca = cmd.ExecuteReader
        'If baca.HasRows Then
        '    Do While baca.Read
        '        CBItem.Items.Add(baca("namaitem"))
        '    Loop
        'End If
        Call buka()
        Dim str As String
        Dim cek4 As String
        Dim iditemx As Integer
        Dim jmlrowx As Integer
        Dim jmlr As Integer
        str = "SELECT * FROM item"
        cmd = New SqlCommand(str, koneksi)
        baca = cmd.ExecuteReader
        If baca.HasRows Then
            Do While baca.Read
                iditemx = baca("iditem")
                cek4 = "SELECT COUNT(*) FROM qty WHERE iditem = '" & iditemx & "'"
                cmd = New SqlCommand(cek4, koneksi)
                jmlrowx = cmd.ExecuteScalar
                jmlr = jmlrowx * 9
                cek4 = "SELECT COUNT(*) FROM forecasting WHERE iditem = '" & iditemx & "'"
                cmd = New SqlCommand(cek4, koneksi)
                jmlrowx = cmd.ExecuteScalar
                MsgBox(jmlr & " -- " & jmlrowx, MsgBoxStyle.Information, "Information")
                If jmlrowx <> jmlr Then
                    CBItem.Items.Add(baca("namaitem"))
                End If
            Loop
        End If
    End Sub
    Private Sub Bersih()
        CBItem.Text = ""
    End Sub
    Sub Tampilitem()
        Call buka()
        Dim cek As String
        Dim tabel As SqlDataAdapter
        Dim data As DataSet
        Dim record As New BindingSource
        data = New DataSet
        cek = "SELECT * FROM item"
        cmdcek = New SqlCommand(cek, koneksi)
        bacacek = cmdcek.ExecuteReader
        While bacacek.Read()
            tabel = New SqlDataAdapter("WITH cte AS (SELECT forecasting.waktu, item.namaitem, forecasting.nperiode, forecasting.hasil, forecasting.aktual, forecasting.mape, forecasting.iditem, forecasting.a, ROW_NUMBER() OVER (PARTITION BY forecasting.nperiode ORDER BY forecasting.mape ASC) AS rn FROM forecasting INNER JOIN item ON item.iditem = forecasting.iditem WHERE forecasting.iditem = '" & bacacek("iditem") & "') SELECT * FROM cte WHERE rn = 1", koneksi)
            tabel.Fill(data)
        End While

        record.DataSource = data
        record.DataMember = data.Tables(0).ToString()
        DGVforecasting.DataSource = record
        DGVforecasting.ReadOnly = True
    End Sub
    Sub AturDGV()
        Try
            DGVforecasting.Columns(0).Width = 213
            DGVforecasting.Columns(1).Width = 213
            DGVforecasting.Columns(2).Width = 213
            DGVforecasting.Columns(3).Width = 216
            DGVforecasting.Columns(4).Width = 213
            DGVforecasting.Columns(5).Width = 213
            DGVforecasting.Columns(6).Width = 80
            DGVforecasting.Columns(7).Width = 80

            DGVforecasting.Columns(0).HeaderText = "WAKTU"
            DGVforecasting.Columns(1).HeaderText = "ITEM"
            DGVforecasting.Columns(2).HeaderText = "PERIODE"
            DGVforecasting.Columns(3).HeaderText = "HASIL"
            DGVforecasting.Columns(4).HeaderText = "AKTUAL"
            DGVforecasting.Columns(5).HeaderText = "MAPE"
            DGVforecasting.Columns(6).HeaderText = "-"
            DGVforecasting.Columns(7).HeaderText = "-"
        Catch ex As Exception

        End Try
    End Sub
    Private Sub DGVforecasting_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DGVforecasting.CellContentClick
        On Error Resume Next
        Dim cari As String
        TB1.Text = DGVforecasting.Rows(e.RowIndex).Cells(0).Value
        TB2.Text = DGVforecasting.Rows(e.RowIndex).Cells(1).Value
        TB3.Text = DGVforecasting.Rows(e.RowIndex).Cells(2).Value
        TB4.Text = DGVforecasting.Rows(e.RowIndex).Cells(3).Value
        TB5.Text = DGVforecasting.Rows(e.RowIndex).Cells(4).Value
        TB6.Text = DGVforecasting.Rows(e.RowIndex).Cells(5).Value
        TB7.Text = DGVforecasting.Rows(e.RowIndex).Cells(7).Value

        Dim x As Integer = 1
        cari = "SELECT * FROM forecasting WHERE nperiode = '" & DGVforecasting.Rows(e.RowIndex).Cells(2).Value & "' AND iditem = '" & DGVforecasting.Rows(e.RowIndex).Cells(6).Value & "' ORDER BY a ASC"
        cmdcari = New SqlCommand(cari, koneksi)
        bacacari = cmdcari.ExecuteReader
        Do While bacacari.Read
            CType(Me.Controls("a" + x.ToString()), TextBox).Text = bacacari("hasil")
            CType(Me.Controls("s" + x.ToString()), TextBox).Text = bacacari("mape") & "%"
            x = x + 1
        Loop
    End Sub

    Private Sub FRMforecasting_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call TampilCombo()
    End Sub

    Private Sub tambahdata_Click(sender As Object, e As EventArgs) Handles tambahdata.Click
        If CBItem.Text = "" Then
            MsgBox("Silahkan Isi Semua Form")
        End If
        Call buka()
        Try
            Dim arra() As Decimal = {0.1, 0.2, 0.3, 0.4, 0.5, 0.6, 0.7, 0.8, 0.9}
            Dim arrb() As Decimal = {0.9, 0.8, 0.7, 0.6, 0.5, 0.4, 0.3, 0.2, 0.1}
            Dim arrc() As Decimal = {0.11, 0.25, 0.43, 0.67, 1.0, 1.5, 2.33, 4, 9}
            Dim alp As String
            Dim simpan As String
            Dim cari As String
            Dim cari2 As String
            Dim idf As Integer
            Dim ape As Decimal
            Dim mape As Decimal
            Dim apestr As String
            Dim mapestr As Integer
            Dim reader As SqlDataReader
            Dim jmlrow As Integer
            cari = "SELECT * FROM item WHERE namaitem = '" & CBItem.Text & "'"
            cmdcari = New SqlCommand(cari, koneksi)
            bacacari = cmdcari.ExecuteReader
            bacacari.Read()
            Dim iditem As Integer = bacacari("iditem")
            Dim cek As String
            Dim cek2 As String
            Dim kumpul As String
            cek = "SELECT COUNT(*) FROM qty WHERE iditem = '" & iditem & "'"
            cmdcek = New SqlCommand(cek, koneksi)
            jmlrow = cmdcek.ExecuteScalar
            If (jmlrow >= 12) Then
                Dim tgl As String = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss")
                Dim nn As Integer
                Dim per As Integer
                Dim perx As Integer
                Dim a As Decimal
                Dim b As Decimal
                Dim c As Decimal
                Dim f As Integer
                Dim sn() As Decimal = {}
                Dim sxn() As Decimal = {}
                Dim an() As Decimal = {}
                Dim bn() As Decimal = {}
                Dim fn() As Decimal = {}
                Dim sna As Decimal
                Dim snb As Decimal
                Dim snc As Decimal
                Dim sxna As Decimal
                Dim sxnb As Decimal
                Dim sxnc As Decimal
                Dim ana As Decimal
                Dim anb As Decimal
                Dim bna As Decimal
                Dim bnb As Decimal
                Dim x As Integer
                Dim y As Integer
                For i = 0 To UBound(arra)
                    a = arra(i)
                    b = arrb(i)
                    c = arrc(i)
                    alp = Replace(a, ",", ".")
                    x = 0
                    cari = "WITH bottom AS (SELECT TOP 12 * FROM qty WHERE iditem = '" & iditem & "' ORDER BY nperiode DESC) SELECT * FROM bottom ORDER BY nperiode ASC"
                    cmdcari = New SqlCommand(cari, koneksi)
                    bacacari = cmdcari.ExecuteReader
                    While bacacari.Read()
                        per = bacacari("nperiode")
                        perx = per + 1
                        ReDim Preserve sn(x)
                        ReDim Preserve sxn(x)
                        ReDim Preserve an(x)
                        ReDim Preserve bn(x)
                        ReDim Preserve fn(x)
                        If (x = 0) Then
                            snc = bacacari("jumlah")
                            sxnc = bacacari("jumlah")
                            sn(x) = snc
                            sxn(x) = sxnc
                            ana = 2 * snc
                            anb = Math.Round(ana - sxnc, 2)
                            an(x) = anb

                            bna = snc - sxnc
                            bnb = Math.Round(c * bna, 2)
                            bn(x) = bnb

                            f = bacacari("jumlah")
                            f = Math.Abs(f)
                            fn(x) = f
                        Else
                            y = x - 1
                            sna = bacacari("jumlah") * a
                            snb = sn(y) * b
                            snc = Math.Round(sna + snb, 2)
                            sn(x) = snc

                            sxna = snc * a
                            sxnb = sxn(y) * b
                            sxnc = Math.Round(sxna + sxnb, 2)
                            sxn(x) = sxnc

                            ana = 2 * snc
                            anb = Math.Round(ana - sxnc, 2)
                            an(x) = anb

                            bna = snc - sxnc
                            bnb = Math.Round(c * bna, 2)
                            bn(x) = bnb

                            f = Math.Round(anb + bnb)
                            f = Math.Abs(f)
                            fn(x) = f
                        End If

                        If (x < 11) Then
                            cek = "SELECT * FROM forecasting WHERE iditem = '" & iditem & "' AND nperiode = '" & perx & "' AND a = '" & alp & "'"
                            cmdcek = New SqlCommand(cek, koneksi)
                            bacacek = cmdcek.ExecuteReader
                            If (bacacek.HasRows) Then
                                bacacek.Read()
                                idf = bacacek("idforecasting")
                                If IsDBNull(bacacek("aktual")) Then
                                    ape = bacacari("jumlah") - f
                                    ape = Math.Round(Math.Abs(ape / bacacari("jumlah")), 4)
                                    apestr = Replace(ape, ",", ".")
                                    simpan = "UPDATE forecasting SET hasil ='" & f & "', aktual ='" & bacacari("jumlah") & "', ape ='" & apestr & "' WHERE idforecasting ='" & idf & "'"
                                Else
                                    ape = bacacek("aktual") - f
                                    ape = Math.Round(Math.Abs(ape / bacacek("aktual")), 4)
                                    apestr = Replace(ape, ",", ".")
                                    simpan = "UPDATE forecasting SET hasil ='" & f & "', aktual ='" & bacacek("aktual") & "', ape ='" & apestr & "' WHERE idforecasting ='" & idf & "'"
                                End If
                                cmd = New SqlCommand(simpan, koneksi)
                                cmd.ExecuteNonQuery()
                                kumpul = "SELECT TOP 12 * FROM forecasting WHERE iditem = '" & iditem & "' AND a = '" & alp & "' AND ape IS NOT NULL ORDER BY nperiode DESC"
                                cmd = New SqlCommand(kumpul, koneksi)
                                reader = cmd.ExecuteReader()
                                mape = 0
                                nn = 0
                                While reader.Read()
                                    mape = mape + reader("ape")
                                    nn = nn + 1
                                End While
                                mape = Math.Round(Math.Abs(mape / nn), 3)
                                mapestr = mape * 100
                                simpan = "UPDATE forecasting SET mape ='" & mapestr & "' WHERE idforecasting ='" & idf & "'"
                                cmd = New SqlCommand(simpan, koneksi)
                                cmd.ExecuteNonQuery()
                            Else
                                cari2 = "SELECT * FROM qty WHERE iditem = '" & iditem & "' AND nperiode = '" & perx & "'"
                                cmdcari2 = New SqlCommand(cari2, koneksi)
                                bacacari2 = cmdcari2.ExecuteReader
                                bacacari2.Read()
                                ape = bacacari2("jumlah") - f
                                ape = Math.Round(Math.Abs(ape / bacacari2("jumlah")), 4)
                                apestr = Replace(ape, ",", ".")
                                simpan = "INSERT INTO forecasting (waktu,iditem,nperiode,a,hasil,aktual,ape) VALUES ('" & tgl & "','" & iditem & "','" & perx & "','" & alp & "','" & f & "','" & bacacari2("jumlah") & "','" & apestr & "')"
                                cmd = New SqlCommand(simpan, koneksi)
                                cmd.ExecuteNonQuery()
                                cek2 = "SELECT COUNT(*) FROM forecasting"
                                cmdcek2 = New SqlCommand(cek2, koneksi)
                                idf = cmdcek2.ExecuteScalar
                                kumpul = "SELECT TOP 12 * FROM forecasting WHERE iditem = '" & iditem & "' AND a = '" & alp & "' AND ape IS NOT NULL ORDER BY nperiode DESC"
                                cmd = New SqlCommand(kumpul, koneksi)
                                reader = cmd.ExecuteReader()
                                mape = 0
                                nn = 0
                                While reader.Read()
                                    mape = mape + reader("ape")
                                    nn = nn + 1
                                End While
                                mape = Math.Round(Math.Abs(mape / nn), 3)
                                mapestr = mape * 100
                                simpan = "UPDATE forecasting SET mape ='" & mapestr & "' WHERE idforecasting ='" & idf & "'"
                                cmd = New SqlCommand(simpan, koneksi)
                                cmd.ExecuteNonQuery()
                            End If
                        End If
                        x = x + 1
                    End While
                    y = x - 1
                    f = Math.Round(fn(y))
                    f = Math.Abs(f)
                    perx = per + 1
                    simpan = "INSERT INTO forecasting (waktu,iditem,nperiode,a,hasil) VALUES ('" & tgl & "','" & iditem & "','" & perx & "','" & alp & "','" & f & "')"
                    cmd = New SqlCommand(simpan, koneksi)
                    cmd.ExecuteNonQuery()
                Next
            End If

            MsgBox("Data berhasil di Simpan", MsgBoxStyle.Information, "Information")
        Catch ex As Exception
            MessageBox.Show("Input data gagal dilakukan.")
        End Try
        Bersih()
    End Sub
End Class