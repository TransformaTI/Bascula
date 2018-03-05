<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ValidaCierreAutotanque
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.OK_Button = New System.Windows.Forms.Button()
        Me.Cancel_Button = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblPeso = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lblClientes = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.lblLitros = New System.Windows.Forms.Label()
        Me.lblNota = New System.Windows.Forms.Label()
        Me.lblNotaConfirmacion = New System.Windows.Forms.Label()
        Me.lblLitrosTotalizador = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.OK_Button, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Cancel_Button, 1, 0)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(296, 310)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(146, 29)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'OK_Button
        '
        Me.OK_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.OK_Button.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.OK_Button.Location = New System.Drawing.Point(3, 3)
        Me.OK_Button.Name = "OK_Button"
        Me.OK_Button.Size = New System.Drawing.Size(67, 23)
        Me.OK_Button.TabIndex = 1
        Me.OK_Button.Text = "&Aceptar"
        '
        'Cancel_Button
        '
        Me.Cancel_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Cancel_Button.Location = New System.Drawing.Point(76, 3)
        Me.Cancel_Button.Name = "Cancel_Button"
        Me.Cancel_Button.Size = New System.Drawing.Size(67, 23)
        Me.Cancel_Button.TabIndex = 0
        Me.Cancel_Button.Text = "&Cancelar"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.Label1.Location = New System.Drawing.Point(12, 22)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(196, 31)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Peso de cierre:"
        '
        'lblPeso
        '
        Me.lblPeso.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPeso.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.lblPeso.Location = New System.Drawing.Point(303, 22)
        Me.lblPeso.Name = "lblPeso"
        Me.lblPeso.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.lblPeso.Size = New System.Drawing.Size(130, 31)
        Me.lblPeso.TabIndex = 3
        Me.lblPeso.Text = "lblPeso"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.Label3.Location = New System.Drawing.Point(13, 53)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(246, 31)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Clientes atendidos:"
        '
        'lblClientes
        '
        Me.lblClientes.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblClientes.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.lblClientes.Location = New System.Drawing.Point(309, 53)
        Me.lblClientes.Name = "lblClientes"
        Me.lblClientes.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.lblClientes.Size = New System.Drawing.Size(125, 31)
        Me.lblClientes.TabIndex = 5
        Me.lblClientes.Text = "lblClientes"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.Label5.Location = New System.Drawing.Point(13, 84)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(193, 31)
        Me.Label5.TabIndex = 6
        Me.Label5.Text = "Venta clientes:"
        '
        'lblLitros
        '
        Me.lblLitros.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLitros.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.lblLitros.Location = New System.Drawing.Point(304, 84)
        Me.lblLitros.Name = "lblLitros"
        Me.lblLitros.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.lblLitros.Size = New System.Drawing.Size(130, 31)
        Me.lblLitros.TabIndex = 7
        Me.lblLitros.Text = "lblLitros"
        Me.lblLitros.Visible = False
        '
        'lblNota
        '
        Me.lblNota.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNota.Location = New System.Drawing.Point(12, 182)
        Me.lblNota.Name = "lblNota"
        Me.lblNota.Size = New System.Drawing.Size(411, 52)
        Me.lblNota.TabIndex = 8
        Me.lblNota.Text = "Favor de encender su tableta antes de cierre de bascula para que sus datos se des" & _
    "carguen."
        '
        'lblNotaConfirmacion
        '
        Me.lblNotaConfirmacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNotaConfirmacion.Location = New System.Drawing.Point(14, 243)
        Me.lblNotaConfirmacion.Name = "lblNotaConfirmacion"
        Me.lblNotaConfirmacion.Size = New System.Drawing.Size(428, 41)
        Me.lblNotaConfirmacion.TabIndex = 9
        Me.lblNotaConfirmacion.Text = "¿Los datos de cierre son correctos?"
        Me.lblNotaConfirmacion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblLitrosTotalizador
        '
        Me.lblLitrosTotalizador.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLitrosTotalizador.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.lblLitrosTotalizador.Location = New System.Drawing.Point(304, 115)
        Me.lblLitrosTotalizador.Name = "lblLitrosTotalizador"
        Me.lblLitrosTotalizador.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.lblLitrosTotalizador.Size = New System.Drawing.Size(130, 31)
        Me.lblLitrosTotalizador.TabIndex = 11
        Me.lblLitrosTotalizador.Text = "lblLitrosTotalizador"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.Label6.Location = New System.Drawing.Point(13, 115)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(226, 31)
        Me.Label6.TabIndex = 10
        Me.Label6.Text = "Venta totalizador:"
        '
        'ValidaCierreAutotanque
        '
        Me.AcceptButton = Me.OK_Button
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.Cancel_Button
        Me.ClientSize = New System.Drawing.Size(454, 351)
        Me.Controls.Add(Me.lblLitrosTotalizador)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.lblNotaConfirmacion)
        Me.Controls.Add(Me.lblNota)
        Me.Controls.Add(Me.lblLitros)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.lblClientes)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.lblPeso)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "ValidaCierreAutotanque"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "¿Los datos de cierre son correctos?"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents OK_Button As System.Windows.Forms.Button
    Friend WithEvents Cancel_Button As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblPeso As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lblClientes As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents lblLitros As System.Windows.Forms.Label
    Friend WithEvents lblNota As System.Windows.Forms.Label
    Friend WithEvents lblNotaConfirmacion As System.Windows.Forms.Label
    Friend WithEvents lblLitrosTotalizador As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label

End Class
