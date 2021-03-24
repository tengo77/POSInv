<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FItem
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TbiD = New System.Windows.Forms.TextBox()
        Me.tbnamaitem = New System.Windows.Forms.TextBox()
        Me.hapusdata = New System.Windows.Forms.Button()
        Me.ubahdata = New System.Windows.Forms.Button()
        Me.tambahdata = New System.Windows.Forms.Button()
        Me.DGVitem = New System.Windows.Forms.DataGridView()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        CType(Me.DGVitem, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.Font = New System.Drawing.Font("Bahnschrift Condensed", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.Label1.Location = New System.Drawing.Point(109, 7)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(133, 42)
        Me.Label1.TabIndex = 28
        Me.Label1.Text = "DATA ITEM"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TbiD
        '
        Me.TbiD.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.TbiD.Location = New System.Drawing.Point(78, 60)
        Me.TbiD.Name = "TbiD"
        Me.TbiD.Size = New System.Drawing.Size(42, 20)
        Me.TbiD.TabIndex = 27
        '
        'tbnamaitem
        '
        Me.tbnamaitem.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.tbnamaitem.Location = New System.Drawing.Point(194, 60)
        Me.tbnamaitem.Name = "tbnamaitem"
        Me.tbnamaitem.Size = New System.Drawing.Size(137, 20)
        Me.tbnamaitem.TabIndex = 24
        '
        'hapusdata
        '
        Me.hapusdata.Font = New System.Drawing.Font("Montserrat SemiBold", 7.0!, System.Drawing.FontStyle.Bold)
        Me.hapusdata.Location = New System.Drawing.Point(254, 86)
        Me.hapusdata.Name = "hapusdata"
        Me.hapusdata.Size = New System.Drawing.Size(77, 29)
        Me.hapusdata.TabIndex = 22
        Me.hapusdata.Text = "Hapus Data"
        Me.hapusdata.UseVisualStyleBackColor = True
        '
        'ubahdata
        '
        Me.ubahdata.Font = New System.Drawing.Font("Montserrat SemiBold", 7.0!, System.Drawing.FontStyle.Bold)
        Me.ubahdata.Location = New System.Drawing.Point(172, 86)
        Me.ubahdata.Name = "ubahdata"
        Me.ubahdata.Size = New System.Drawing.Size(77, 29)
        Me.ubahdata.TabIndex = 21
        Me.ubahdata.Text = "Ubah Data"
        Me.ubahdata.UseVisualStyleBackColor = True
        '
        'tambahdata
        '
        Me.tambahdata.Font = New System.Drawing.Font("Montserrat SemiBold", 7.0!, System.Drawing.FontStyle.Bold)
        Me.tambahdata.Location = New System.Drawing.Point(78, 86)
        Me.tambahdata.Name = "tambahdata"
        Me.tambahdata.Size = New System.Drawing.Size(89, 29)
        Me.tambahdata.TabIndex = 20
        Me.tambahdata.Text = "Tambah Data"
        Me.tambahdata.UseVisualStyleBackColor = True
        '
        'DGVitem
        '
        Me.DGVitem.AllowUserToAddRows = False
        Me.DGVitem.AllowUserToDeleteRows = False
        Me.DGVitem.BackgroundColor = System.Drawing.Color.Snow
        Me.DGVitem.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGVitem.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.DGVitem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DGVitem.DefaultCellStyle = DataGridViewCellStyle2
        Me.DGVitem.Location = New System.Drawing.Point(4, 127)
        Me.DGVitem.Name = "DGVitem"
        Me.DGVitem.ReadOnly = True
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DGVitem.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.DGVitem.RowHeadersVisible = False
        Me.DGVitem.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DGVitem.Size = New System.Drawing.Size(360, 201)
        Me.DGVitem.TabIndex = 72
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Roboto", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.Label5.Location = New System.Drawing.Point(129, 63)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(64, 14)
        Me.Label5.TabIndex = 101
        Me.Label5.Text = "Nama Item"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Roboto", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.Label2.Location = New System.Drawing.Point(24, 63)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(46, 14)
        Me.Label2.TabIndex = 102
        Me.Label2.Text = "ID Item"
        '
        'FItem
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(63, Byte), Integer), CType(CType(48, Byte), Integer), CType(CType(120, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(368, 331)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.DGVitem)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TbiD)
        Me.Controls.Add(Me.tbnamaitem)
        Me.Controls.Add(Me.hapusdata)
        Me.Controls.Add(Me.ubahdata)
        Me.Controls.Add(Me.tambahdata)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow
        Me.Name = "FItem"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FItem"
        CType(Me.DGVitem, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TbiD As System.Windows.Forms.TextBox
    Friend WithEvents tbnamaitem As System.Windows.Forms.TextBox
    Friend WithEvents hapusdata As System.Windows.Forms.Button
    Friend WithEvents ubahdata As System.Windows.Forms.Button
    Friend WithEvents tambahdata As System.Windows.Forms.Button
    Friend WithEvents DGVitem As DataGridView
    Friend WithEvents Label5 As Label
    Friend WithEvents Label2 As Label
End Class
