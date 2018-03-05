Public Class frmCapturaCiclo
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents pnlDatos As System.Windows.Forms.Panel
    Friend WithEvents rgrpApertura As Bascula.RoundedGroupBox
    Friend WithEvents txtTotalizadorInicial As System.Windows.Forms.TextBox
    Friend WithEvents txtKilometrajeInicial As System.Windows.Forms.TextBox
    Friend WithEvents txtPesoSalida As System.Windows.Forms.TextBox
    Friend WithEvents dtpFSalida As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblTotalizadorInicial As System.Windows.Forms.Label
    Friend WithEvents lblKilometrajeInicial As System.Windows.Forms.Label
    Friend WithEvents lblLitrosInicial As System.Windows.Forms.Label
    Friend WithEvents lblGasInicial As System.Windows.Forms.Label
    Friend WithEvents lblPesoSalida As System.Windows.Forms.Label
    Friend WithEvents lblFSalida As System.Windows.Forms.Label
    Friend WithEvents txtLitrosInicial As System.Windows.Forms.TextBox
    Friend WithEvents txtGasInicial As System.Windows.Forms.TextBox
    Friend WithEvents rgrpCierre As Bascula.RoundedGroupBox
    Friend WithEvents lblLitrosFinal As System.Windows.Forms.Label
    Friend WithEvents lblGasFinal As System.Windows.Forms.Label
    Friend WithEvents lblPesoLlegada As System.Windows.Forms.Label
    Friend WithEvents lblFLlegada As System.Windows.Forms.Label
    Friend WithEvents txtGasFinal As System.Windows.Forms.TextBox
    Friend WithEvents txtPesoLlegada As System.Windows.Forms.TextBox
    Friend WithEvents dtpFLlegada As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtTotalizadorFinal As System.Windows.Forms.TextBox
    Friend WithEvents txtLitrosFinal As System.Windows.Forms.TextBox
    Friend WithEvents lblTotalizadorFinal As System.Windows.Forms.Label
    Friend WithEvents lblKilometrajeFinal As System.Windows.Forms.Label
    Friend WithEvents txtLitrosLiquidados As System.Windows.Forms.TextBox
    Friend WithEvents txtLitrosBascula As System.Windows.Forms.TextBox
    Friend WithEvents lblDiferenciaTotalizador As System.Windows.Forms.Label
    Friend WithEvents lblDiferenciaKilometraje As System.Windows.Forms.Label
    Friend WithEvents lblDiferenciaLitrosGas As System.Windows.Forms.Label
    Friend WithEvents lblDiferenciaGas As System.Windows.Forms.Label
    Friend WithEvents lblDiferenciaPeso As System.Windows.Forms.Label
    Friend WithEvents lblLitrosBascula As System.Windows.Forms.Label
    Friend WithEvents lblLitrosLiquidados As System.Windows.Forms.Label
    Friend WithEvents lblDiferenciaLitros As System.Windows.Forms.Label
    Friend WithEvents rgrpDiferencias As Bascula.RoundedGroupBox
    Friend WithEvents figSeparador As Bascula.Figure
    Friend WithEvents txtDiferenciaLitros As System.Windows.Forms.TextBox
    Friend WithEvents txtDiferenciaTotalizador As System.Windows.Forms.TextBox
    Friend WithEvents txtDiferenciaKilometraje As System.Windows.Forms.TextBox
    Friend WithEvents txtDiferenciaLitrosGas As System.Windows.Forms.TextBox
    Friend WithEvents txtDiferenciaGas As System.Windows.Forms.TextBox
    Friend WithEvents txtDiferenciaPeso As System.Windows.Forms.TextBox
    Friend WithEvents lblStatusBascula As System.Windows.Forms.Label
    Friend WithEvents lblStatusLogistica As System.Windows.Forms.Label
    Friend WithEvents cboStatusBascula As System.Windows.Forms.ComboBox
    Friend WithEvents cboStatusLogistica As System.Windows.Forms.ComboBox
    Friend WithEvents btnAceptar As System.Windows.Forms.Button
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents lblCelula As System.Windows.Forms.Label
    Friend WithEvents cboCelula As System.Windows.Forms.ComboBox
    Friend WithEvents rgrpOtros As Bascula.RoundedGroupBox
    Friend WithEvents lblRuta As System.Windows.Forms.Label
    Friend WithEvents cboRuta As System.Windows.Forms.ComboBox
    Friend WithEvents cboAutotanque As System.Windows.Forms.ComboBox
    Friend WithEvents lblAutotanque As System.Windows.Forms.Label
    Friend WithEvents lblFolio As System.Windows.Forms.Label
    Friend WithEvents lblAño As System.Windows.Forms.Label
    Friend WithEvents txtKilometrajeFinal As System.Windows.Forms.TextBox
    Friend WithEvents cboMotivo As System.Windows.Forms.ComboBox
    Friend WithEvents lblMotivo As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmCapturaCiclo))
        Me.pnlDatos = New System.Windows.Forms.Panel()
        Me.rgrpCierre = New Bascula.RoundedGroupBox()
        Me.txtTotalizadorFinal = New System.Windows.Forms.TextBox()
        Me.txtKilometrajeFinal = New System.Windows.Forms.TextBox()
        Me.txtLitrosFinal = New System.Windows.Forms.TextBox()
        Me.lblTotalizadorFinal = New System.Windows.Forms.Label()
        Me.lblKilometrajeFinal = New System.Windows.Forms.Label()
        Me.lblLitrosFinal = New System.Windows.Forms.Label()
        Me.lblGasFinal = New System.Windows.Forms.Label()
        Me.lblPesoLlegada = New System.Windows.Forms.Label()
        Me.lblFLlegada = New System.Windows.Forms.Label()
        Me.txtGasFinal = New System.Windows.Forms.TextBox()
        Me.txtPesoLlegada = New System.Windows.Forms.TextBox()
        Me.dtpFLlegada = New System.Windows.Forms.DateTimePicker()
        Me.rgrpApertura = New Bascula.RoundedGroupBox()
        Me.txtTotalizadorInicial = New System.Windows.Forms.TextBox()
        Me.txtKilometrajeInicial = New System.Windows.Forms.TextBox()
        Me.txtLitrosInicial = New System.Windows.Forms.TextBox()
        Me.lblTotalizadorInicial = New System.Windows.Forms.Label()
        Me.lblKilometrajeInicial = New System.Windows.Forms.Label()
        Me.lblLitrosInicial = New System.Windows.Forms.Label()
        Me.lblGasInicial = New System.Windows.Forms.Label()
        Me.lblPesoSalida = New System.Windows.Forms.Label()
        Me.lblFSalida = New System.Windows.Forms.Label()
        Me.txtGasInicial = New System.Windows.Forms.TextBox()
        Me.txtPesoSalida = New System.Windows.Forms.TextBox()
        Me.dtpFSalida = New System.Windows.Forms.DateTimePicker()
        Me.txtDiferenciaLitros = New System.Windows.Forms.TextBox()
        Me.txtLitrosLiquidados = New System.Windows.Forms.TextBox()
        Me.txtLitrosBascula = New System.Windows.Forms.TextBox()
        Me.txtDiferenciaTotalizador = New System.Windows.Forms.TextBox()
        Me.txtDiferenciaKilometraje = New System.Windows.Forms.TextBox()
        Me.txtDiferenciaLitrosGas = New System.Windows.Forms.TextBox()
        Me.txtDiferenciaGas = New System.Windows.Forms.TextBox()
        Me.lblDiferenciaTotalizador = New System.Windows.Forms.Label()
        Me.lblDiferenciaKilometraje = New System.Windows.Forms.Label()
        Me.lblDiferenciaLitrosGas = New System.Windows.Forms.Label()
        Me.lblDiferenciaGas = New System.Windows.Forms.Label()
        Me.lblDiferenciaPeso = New System.Windows.Forms.Label()
        Me.lblLitrosBascula = New System.Windows.Forms.Label()
        Me.lblLitrosLiquidados = New System.Windows.Forms.Label()
        Me.lblDiferenciaLitros = New System.Windows.Forms.Label()
        Me.txtDiferenciaPeso = New System.Windows.Forms.TextBox()
        Me.rgrpDiferencias = New Bascula.RoundedGroupBox()
        Me.figSeparador = New Bascula.Figure()
        Me.lblStatusBascula = New System.Windows.Forms.Label()
        Me.lblStatusLogistica = New System.Windows.Forms.Label()
        Me.cboStatusBascula = New System.Windows.Forms.ComboBox()
        Me.cboStatusLogistica = New System.Windows.Forms.ComboBox()
        Me.btnAceptar = New System.Windows.Forms.Button()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.lblCelula = New System.Windows.Forms.Label()
        Me.cboCelula = New System.Windows.Forms.ComboBox()
        Me.rgrpOtros = New Bascula.RoundedGroupBox()
        Me.lblRuta = New System.Windows.Forms.Label()
        Me.cboRuta = New System.Windows.Forms.ComboBox()
        Me.cboAutotanque = New System.Windows.Forms.ComboBox()
        Me.lblAutotanque = New System.Windows.Forms.Label()
        Me.lblFolio = New System.Windows.Forms.Label()
        Me.lblAño = New System.Windows.Forms.Label()
        Me.cboMotivo = New System.Windows.Forms.ComboBox()
        Me.lblMotivo = New System.Windows.Forms.Label()
        Me.pnlDatos.SuspendLayout()
        Me.rgrpCierre.SuspendLayout()
        Me.rgrpApertura.SuspendLayout()
        Me.rgrpDiferencias.SuspendLayout()
        Me.rgrpOtros.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlDatos
        '
        Me.pnlDatos.Controls.AddRange(New System.Windows.Forms.Control() {Me.rgrpCierre, Me.rgrpApertura})
        Me.pnlDatos.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlDatos.DockPadding.All = 3
        Me.pnlDatos.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.pnlDatos.Location = New System.Drawing.Point(3, 3)
        Me.pnlDatos.Name = "pnlDatos"
        Me.pnlDatos.Size = New System.Drawing.Size(596, 208)
        Me.pnlDatos.TabIndex = 0
        '
        'rgrpCierre
        '
        Me.rgrpCierre.BorderColor = System.Drawing.Color.Brown
        Me.rgrpCierre.Controls.AddRange(New System.Windows.Forms.Control() {Me.txtTotalizadorFinal, Me.txtKilometrajeFinal, Me.txtLitrosFinal, Me.lblTotalizadorFinal, Me.lblKilometrajeFinal, Me.lblLitrosFinal, Me.lblGasFinal, Me.lblPesoLlegada, Me.lblFLlegada, Me.txtGasFinal, Me.txtPesoLlegada, Me.dtpFLlegada})
        Me.rgrpCierre.Dock = System.Windows.Forms.DockStyle.Right
        Me.rgrpCierre.FlatStyle = Bascula.RoundedGroupBox.Style.Pipe
        Me.rgrpCierre.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rgrpCierre.ForeColor = System.Drawing.Color.Maroon
        Me.rgrpCierre.Location = New System.Drawing.Point(305, 3)
        Me.rgrpCierre.Name = "rgrpCierre"
        Me.rgrpCierre.Size = New System.Drawing.Size(288, 202)
        Me.rgrpCierre.TabIndex = 1
        Me.rgrpCierre.TabStop = False
        Me.rgrpCierre.Text = "Cierre"
        Me.rgrpCierre.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left
        '
        'txtTotalizadorFinal
        '
        Me.txtTotalizadorFinal.BackColor = System.Drawing.Color.White
        Me.txtTotalizadorFinal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTotalizadorFinal.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalizadorFinal.ForeColor = System.Drawing.Color.Black
        Me.txtTotalizadorFinal.Location = New System.Drawing.Point(124, 167)
        Me.txtTotalizadorFinal.Name = "txtTotalizadorFinal"
        Me.txtTotalizadorFinal.Size = New System.Drawing.Size(150, 21)
        Me.txtTotalizadorFinal.TabIndex = 9
        Me.txtTotalizadorFinal.Tag = "TotalizadorFinal"
        Me.txtTotalizadorFinal.Text = ""
        '
        'txtKilometrajeFinal
        '
        Me.txtKilometrajeFinal.BackColor = System.Drawing.Color.White
        Me.txtKilometrajeFinal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtKilometrajeFinal.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtKilometrajeFinal.ForeColor = System.Drawing.Color.Black
        Me.txtKilometrajeFinal.Location = New System.Drawing.Point(124, 139)
        Me.txtKilometrajeFinal.Name = "txtKilometrajeFinal"
        Me.txtKilometrajeFinal.Size = New System.Drawing.Size(150, 21)
        Me.txtKilometrajeFinal.TabIndex = 7
        Me.txtKilometrajeFinal.Tag = "KilometrajeFinal"
        Me.txtKilometrajeFinal.Text = ""
        '
        'txtLitrosFinal
        '
        Me.txtLitrosFinal.BackColor = System.Drawing.Color.Gainsboro
        Me.txtLitrosFinal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtLitrosFinal.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLitrosFinal.ForeColor = System.Drawing.Color.Black
        Me.txtLitrosFinal.Location = New System.Drawing.Point(124, 111)
        Me.txtLitrosFinal.Name = "txtLitrosFinal"
        Me.txtLitrosFinal.ReadOnly = True
        Me.txtLitrosFinal.Size = New System.Drawing.Size(150, 21)
        Me.txtLitrosFinal.TabIndex = 72
        Me.txtLitrosFinal.TabStop = False
        Me.txtLitrosFinal.Text = ""
        '
        'lblTotalizadorFinal
        '
        Me.lblTotalizadorFinal.AutoSize = True
        Me.lblTotalizadorFinal.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalizadorFinal.ForeColor = System.Drawing.Color.Black
        Me.lblTotalizadorFinal.Location = New System.Drawing.Point(18, 170)
        Me.lblTotalizadorFinal.Name = "lblTotalizadorFinal"
        Me.lblTotalizadorFinal.Size = New System.Drawing.Size(88, 14)
        Me.lblTotalizadorFinal.TabIndex = 8
        Me.lblTotalizadorFinal.Text = "&Totalizador final:"
        '
        'lblKilometrajeFinal
        '
        Me.lblKilometrajeFinal.AutoSize = True
        Me.lblKilometrajeFinal.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblKilometrajeFinal.ForeColor = System.Drawing.Color.Black
        Me.lblKilometrajeFinal.Location = New System.Drawing.Point(18, 142)
        Me.lblKilometrajeFinal.Name = "lblKilometrajeFinal"
        Me.lblKilometrajeFinal.Size = New System.Drawing.Size(89, 14)
        Me.lblKilometrajeFinal.TabIndex = 6
        Me.lblKilometrajeFinal.Text = "&Kilometraje final:"
        '
        'lblLitrosFinal
        '
        Me.lblLitrosFinal.AutoSize = True
        Me.lblLitrosFinal.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLitrosFinal.ForeColor = System.Drawing.Color.Black
        Me.lblLitrosFinal.Location = New System.Drawing.Point(18, 114)
        Me.lblLitrosFinal.Name = "lblLitrosFinal"
        Me.lblLitrosFinal.Size = New System.Drawing.Size(97, 14)
        Me.lblLitrosFinal.TabIndex = 61
        Me.lblLitrosFinal.Text = "Litros de gas final:"
        '
        'lblGasFinal
        '
        Me.lblGasFinal.AutoSize = True
        Me.lblGasFinal.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblGasFinal.ForeColor = System.Drawing.Color.Black
        Me.lblGasFinal.Location = New System.Drawing.Point(18, 86)
        Me.lblGasFinal.Name = "lblGasFinal"
        Me.lblGasFinal.Size = New System.Drawing.Size(80, 14)
        Me.lblGasFinal.TabIndex = 4
        Me.lblGasFinal.Text = "% de &gas final:"
        '
        'lblPesoLlegada
        '
        Me.lblPesoLlegada.AutoSize = True
        Me.lblPesoLlegada.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPesoLlegada.ForeColor = System.Drawing.Color.Black
        Me.lblPesoLlegada.Location = New System.Drawing.Point(18, 58)
        Me.lblPesoLlegada.Name = "lblPesoLlegada"
        Me.lblPesoLlegada.Size = New System.Drawing.Size(86, 14)
        Me.lblPesoLlegada.TabIndex = 2
        Me.lblPesoLlegada.Text = "&Peso de llegada:"
        '
        'lblFLlegada
        '
        Me.lblFLlegada.AutoSize = True
        Me.lblFLlegada.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFLlegada.ForeColor = System.Drawing.Color.Black
        Me.lblFLlegada.Location = New System.Drawing.Point(18, 30)
        Me.lblFLlegada.Name = "lblFLlegada"
        Me.lblFLlegada.Size = New System.Drawing.Size(92, 14)
        Me.lblFLlegada.TabIndex = 0
        Me.lblFLlegada.Text = "&Fecha de llegada:"
        '
        'txtGasFinal
        '
        Me.txtGasFinal.BackColor = System.Drawing.Color.Gainsboro
        Me.txtGasFinal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtGasFinal.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtGasFinal.ForeColor = System.Drawing.Color.Black
        Me.txtGasFinal.Location = New System.Drawing.Point(124, 80)
        Me.txtGasFinal.Name = "txtGasFinal"
        Me.txtGasFinal.ReadOnly = True
        Me.txtGasFinal.Size = New System.Drawing.Size(150, 21)
        Me.txtGasFinal.TabIndex = 5
        Me.txtGasFinal.Tag = "PorcentajeGasFinal"
        Me.txtGasFinal.Text = ""
        '
        'txtPesoLlegada
        '
        Me.txtPesoLlegada.BackColor = System.Drawing.Color.White
        Me.txtPesoLlegada.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPesoLlegada.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPesoLlegada.ForeColor = System.Drawing.Color.Black
        Me.txtPesoLlegada.Location = New System.Drawing.Point(124, 55)
        Me.txtPesoLlegada.Name = "txtPesoLlegada"
        Me.txtPesoLlegada.Size = New System.Drawing.Size(150, 21)
        Me.txtPesoLlegada.TabIndex = 3
        Me.txtPesoLlegada.Tag = "PesoLlegada"
        Me.txtPesoLlegada.Text = ""
        '
        'dtpFLlegada
        '
        Me.dtpFLlegada.CustomFormat = "dd 'de' MMMM 'de' yyy"
        Me.dtpFLlegada.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpFLlegada.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpFLlegada.Location = New System.Drawing.Point(124, 27)
        Me.dtpFLlegada.Name = "dtpFLlegada"
        Me.dtpFLlegada.Size = New System.Drawing.Size(150, 21)
        Me.dtpFLlegada.TabIndex = 1
        Me.dtpFLlegada.Value = New Date(2003, 10, 8, 0, 0, 0, 0)
        '
        'rgrpApertura
        '
        Me.rgrpApertura.BorderColor = System.Drawing.Color.SeaGreen
        Me.rgrpApertura.Controls.AddRange(New System.Windows.Forms.Control() {Me.txtTotalizadorInicial, Me.txtKilometrajeInicial, Me.txtLitrosInicial, Me.lblTotalizadorInicial, Me.lblKilometrajeInicial, Me.lblLitrosInicial, Me.lblGasInicial, Me.lblPesoSalida, Me.lblFSalida, Me.txtGasInicial, Me.txtPesoSalida, Me.dtpFSalida})
        Me.rgrpApertura.Dock = System.Windows.Forms.DockStyle.Left
        Me.rgrpApertura.FlatStyle = Bascula.RoundedGroupBox.Style.Pipe
        Me.rgrpApertura.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rgrpApertura.ForeColor = System.Drawing.Color.DarkGreen
        Me.rgrpApertura.Location = New System.Drawing.Point(3, 3)
        Me.rgrpApertura.Name = "rgrpApertura"
        Me.rgrpApertura.Size = New System.Drawing.Size(285, 202)
        Me.rgrpApertura.TabIndex = 0
        Me.rgrpApertura.TabStop = False
        Me.rgrpApertura.Text = "Apertura"
        Me.rgrpApertura.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left
        '
        'txtTotalizadorInicial
        '
        Me.txtTotalizadorInicial.BackColor = System.Drawing.Color.White
        Me.txtTotalizadorInicial.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTotalizadorInicial.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalizadorInicial.ForeColor = System.Drawing.Color.Black
        Me.txtTotalizadorInicial.Location = New System.Drawing.Point(122, 169)
        Me.txtTotalizadorInicial.Name = "txtTotalizadorInicial"
        Me.txtTotalizadorInicial.Size = New System.Drawing.Size(150, 21)
        Me.txtTotalizadorInicial.TabIndex = 9
        Me.txtTotalizadorInicial.Tag = "TotalizadorInicial"
        Me.txtTotalizadorInicial.Text = ""
        '
        'txtKilometrajeInicial
        '
        Me.txtKilometrajeInicial.BackColor = System.Drawing.Color.White
        Me.txtKilometrajeInicial.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtKilometrajeInicial.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtKilometrajeInicial.ForeColor = System.Drawing.Color.Black
        Me.txtKilometrajeInicial.Location = New System.Drawing.Point(122, 141)
        Me.txtKilometrajeInicial.Name = "txtKilometrajeInicial"
        Me.txtKilometrajeInicial.Size = New System.Drawing.Size(150, 21)
        Me.txtKilometrajeInicial.TabIndex = 7
        Me.txtKilometrajeInicial.Tag = "KilometrajeInicial"
        Me.txtKilometrajeInicial.Text = ""
        '
        'txtLitrosInicial
        '
        Me.txtLitrosInicial.BackColor = System.Drawing.Color.Gainsboro
        Me.txtLitrosInicial.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtLitrosInicial.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLitrosInicial.ForeColor = System.Drawing.Color.Black
        Me.txtLitrosInicial.Location = New System.Drawing.Point(122, 113)
        Me.txtLitrosInicial.Name = "txtLitrosInicial"
        Me.txtLitrosInicial.ReadOnly = True
        Me.txtLitrosInicial.Size = New System.Drawing.Size(150, 21)
        Me.txtLitrosInicial.TabIndex = 60
        Me.txtLitrosInicial.TabStop = False
        Me.txtLitrosInicial.Text = ""
        '
        'lblTotalizadorInicial
        '
        Me.lblTotalizadorInicial.AutoSize = True
        Me.lblTotalizadorInicial.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalizadorInicial.ForeColor = System.Drawing.Color.Black
        Me.lblTotalizadorInicial.Location = New System.Drawing.Point(16, 172)
        Me.lblTotalizadorInicial.Name = "lblTotalizadorInicial"
        Me.lblTotalizadorInicial.Size = New System.Drawing.Size(95, 14)
        Me.lblTotalizadorInicial.TabIndex = 8
        Me.lblTotalizadorInicial.Text = "&Totalizador inicial:"
        '
        'lblKilometrajeInicial
        '
        Me.lblKilometrajeInicial.AutoSize = True
        Me.lblKilometrajeInicial.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblKilometrajeInicial.ForeColor = System.Drawing.Color.Black
        Me.lblKilometrajeInicial.Location = New System.Drawing.Point(16, 144)
        Me.lblKilometrajeInicial.Name = "lblKilometrajeInicial"
        Me.lblKilometrajeInicial.Size = New System.Drawing.Size(96, 14)
        Me.lblKilometrajeInicial.TabIndex = 6
        Me.lblKilometrajeInicial.Text = "&Kilometraje inicial:"
        '
        'lblLitrosInicial
        '
        Me.lblLitrosInicial.AutoSize = True
        Me.lblLitrosInicial.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLitrosInicial.ForeColor = System.Drawing.Color.Black
        Me.lblLitrosInicial.Location = New System.Drawing.Point(16, 116)
        Me.lblLitrosInicial.Name = "lblLitrosInicial"
        Me.lblLitrosInicial.Size = New System.Drawing.Size(103, 14)
        Me.lblLitrosInicial.TabIndex = 0
        Me.lblLitrosInicial.Text = "Litros de gas inicial:"
        '
        'lblGasInicial
        '
        Me.lblGasInicial.AutoSize = True
        Me.lblGasInicial.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblGasInicial.ForeColor = System.Drawing.Color.Black
        Me.lblGasInicial.Location = New System.Drawing.Point(16, 88)
        Me.lblGasInicial.Name = "lblGasInicial"
        Me.lblGasInicial.Size = New System.Drawing.Size(87, 14)
        Me.lblGasInicial.TabIndex = 4
        Me.lblGasInicial.Text = "% de &gas inicial:"
        '
        'lblPesoSalida
        '
        Me.lblPesoSalida.AutoSize = True
        Me.lblPesoSalida.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPesoSalida.ForeColor = System.Drawing.Color.Black
        Me.lblPesoSalida.Location = New System.Drawing.Point(16, 60)
        Me.lblPesoSalida.Name = "lblPesoSalida"
        Me.lblPesoSalida.Size = New System.Drawing.Size(79, 14)
        Me.lblPesoSalida.TabIndex = 2
        Me.lblPesoSalida.Text = "&Peso de salida:"
        '
        'lblFSalida
        '
        Me.lblFSalida.AutoSize = True
        Me.lblFSalida.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFSalida.ForeColor = System.Drawing.Color.Black
        Me.lblFSalida.Location = New System.Drawing.Point(16, 32)
        Me.lblFSalida.Name = "lblFSalida"
        Me.lblFSalida.Size = New System.Drawing.Size(85, 14)
        Me.lblFSalida.TabIndex = 0
        Me.lblFSalida.Text = "&Fecha de salida:"
        '
        'txtGasInicial
        '
        Me.txtGasInicial.BackColor = System.Drawing.Color.Gainsboro
        Me.txtGasInicial.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtGasInicial.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtGasInicial.ForeColor = System.Drawing.Color.Black
        Me.txtGasInicial.Location = New System.Drawing.Point(122, 85)
        Me.txtGasInicial.Name = "txtGasInicial"
        Me.txtGasInicial.ReadOnly = True
        Me.txtGasInicial.Size = New System.Drawing.Size(150, 21)
        Me.txtGasInicial.TabIndex = 5
        Me.txtGasInicial.Tag = "PorcentajeGasInicial"
        Me.txtGasInicial.Text = ""
        '
        'txtPesoSalida
        '
        Me.txtPesoSalida.BackColor = System.Drawing.Color.White
        Me.txtPesoSalida.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPesoSalida.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPesoSalida.ForeColor = System.Drawing.Color.Black
        Me.txtPesoSalida.Location = New System.Drawing.Point(122, 57)
        Me.txtPesoSalida.Name = "txtPesoSalida"
        Me.txtPesoSalida.Size = New System.Drawing.Size(150, 21)
        Me.txtPesoSalida.TabIndex = 3
        Me.txtPesoSalida.Tag = "PesoSalida"
        Me.txtPesoSalida.Text = ""
        '
        'dtpFSalida
        '
        Me.dtpFSalida.CustomFormat = "dd 'de' MMMM 'de' yyy"
        Me.dtpFSalida.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpFSalida.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpFSalida.Location = New System.Drawing.Point(122, 29)
        Me.dtpFSalida.Name = "dtpFSalida"
        Me.dtpFSalida.Size = New System.Drawing.Size(150, 21)
        Me.dtpFSalida.TabIndex = 1
        Me.dtpFSalida.Value = New Date(2003, 10, 8, 0, 0, 0, 0)
        '
        'txtDiferenciaLitros
        '
        Me.txtDiferenciaLitros.BackColor = System.Drawing.Color.Gainsboro
        Me.txtDiferenciaLitros.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDiferenciaLitros.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDiferenciaLitros.ForeColor = System.Drawing.Color.Black
        Me.txtDiferenciaLitros.Location = New System.Drawing.Point(157, 89)
        Me.txtDiferenciaLitros.Name = "txtDiferenciaLitros"
        Me.txtDiferenciaLitros.ReadOnly = True
        Me.txtDiferenciaLitros.Size = New System.Drawing.Size(120, 21)
        Me.txtDiferenciaLitros.TabIndex = 58
        Me.txtDiferenciaLitros.TabStop = False
        Me.txtDiferenciaLitros.Text = ""
        '
        'txtLitrosLiquidados
        '
        Me.txtLitrosLiquidados.BackColor = System.Drawing.Color.Gainsboro
        Me.txtLitrosLiquidados.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtLitrosLiquidados.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLitrosLiquidados.ForeColor = System.Drawing.Color.Black
        Me.txtLitrosLiquidados.Location = New System.Drawing.Point(157, 59)
        Me.txtLitrosLiquidados.Name = "txtLitrosLiquidados"
        Me.txtLitrosLiquidados.ReadOnly = True
        Me.txtLitrosLiquidados.Size = New System.Drawing.Size(120, 21)
        Me.txtLitrosLiquidados.TabIndex = 57
        Me.txtLitrosLiquidados.TabStop = False
        Me.txtLitrosLiquidados.Text = ""
        '
        'txtLitrosBascula
        '
        Me.txtLitrosBascula.BackColor = System.Drawing.Color.Gainsboro
        Me.txtLitrosBascula.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtLitrosBascula.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLitrosBascula.ForeColor = System.Drawing.Color.Black
        Me.txtLitrosBascula.Location = New System.Drawing.Point(157, 29)
        Me.txtLitrosBascula.Name = "txtLitrosBascula"
        Me.txtLitrosBascula.ReadOnly = True
        Me.txtLitrosBascula.Size = New System.Drawing.Size(120, 21)
        Me.txtLitrosBascula.TabIndex = 56
        Me.txtLitrosBascula.TabStop = False
        Me.txtLitrosBascula.Text = ""
        '
        'txtDiferenciaTotalizador
        '
        Me.txtDiferenciaTotalizador.BackColor = System.Drawing.Color.Gainsboro
        Me.txtDiferenciaTotalizador.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDiferenciaTotalizador.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDiferenciaTotalizador.ForeColor = System.Drawing.Color.Black
        Me.txtDiferenciaTotalizador.Location = New System.Drawing.Point(157, 253)
        Me.txtDiferenciaTotalizador.Name = "txtDiferenciaTotalizador"
        Me.txtDiferenciaTotalizador.ReadOnly = True
        Me.txtDiferenciaTotalizador.Size = New System.Drawing.Size(120, 21)
        Me.txtDiferenciaTotalizador.TabIndex = 55
        Me.txtDiferenciaTotalizador.TabStop = False
        Me.txtDiferenciaTotalizador.Text = ""
        '
        'txtDiferenciaKilometraje
        '
        Me.txtDiferenciaKilometraje.BackColor = System.Drawing.Color.Gainsboro
        Me.txtDiferenciaKilometraje.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDiferenciaKilometraje.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDiferenciaKilometraje.ForeColor = System.Drawing.Color.Black
        Me.txtDiferenciaKilometraje.Location = New System.Drawing.Point(157, 223)
        Me.txtDiferenciaKilometraje.Name = "txtDiferenciaKilometraje"
        Me.txtDiferenciaKilometraje.ReadOnly = True
        Me.txtDiferenciaKilometraje.Size = New System.Drawing.Size(120, 21)
        Me.txtDiferenciaKilometraje.TabIndex = 54
        Me.txtDiferenciaKilometraje.TabStop = False
        Me.txtDiferenciaKilometraje.Text = ""
        '
        'txtDiferenciaLitrosGas
        '
        Me.txtDiferenciaLitrosGas.BackColor = System.Drawing.Color.Gainsboro
        Me.txtDiferenciaLitrosGas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDiferenciaLitrosGas.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDiferenciaLitrosGas.ForeColor = System.Drawing.Color.Black
        Me.txtDiferenciaLitrosGas.Location = New System.Drawing.Point(157, 193)
        Me.txtDiferenciaLitrosGas.Name = "txtDiferenciaLitrosGas"
        Me.txtDiferenciaLitrosGas.ReadOnly = True
        Me.txtDiferenciaLitrosGas.Size = New System.Drawing.Size(120, 21)
        Me.txtDiferenciaLitrosGas.TabIndex = 53
        Me.txtDiferenciaLitrosGas.TabStop = False
        Me.txtDiferenciaLitrosGas.Text = ""
        '
        'txtDiferenciaGas
        '
        Me.txtDiferenciaGas.BackColor = System.Drawing.Color.Gainsboro
        Me.txtDiferenciaGas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDiferenciaGas.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDiferenciaGas.ForeColor = System.Drawing.Color.Black
        Me.txtDiferenciaGas.Location = New System.Drawing.Point(157, 163)
        Me.txtDiferenciaGas.Name = "txtDiferenciaGas"
        Me.txtDiferenciaGas.ReadOnly = True
        Me.txtDiferenciaGas.Size = New System.Drawing.Size(120, 21)
        Me.txtDiferenciaGas.TabIndex = 52
        Me.txtDiferenciaGas.TabStop = False
        Me.txtDiferenciaGas.Text = ""
        '
        'lblDiferenciaTotalizador
        '
        Me.lblDiferenciaTotalizador.AutoSize = True
        Me.lblDiferenciaTotalizador.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDiferenciaTotalizador.Location = New System.Drawing.Point(16, 256)
        Me.lblDiferenciaTotalizador.Name = "lblDiferenciaTotalizador"
        Me.lblDiferenciaTotalizador.Size = New System.Drawing.Size(130, 14)
        Me.lblDiferenciaTotalizador.TabIndex = 51
        Me.lblDiferenciaTotalizador.Text = "Diferencia de totalizador:"
        '
        'lblDiferenciaKilometraje
        '
        Me.lblDiferenciaKilometraje.AutoSize = True
        Me.lblDiferenciaKilometraje.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDiferenciaKilometraje.Location = New System.Drawing.Point(16, 226)
        Me.lblDiferenciaKilometraje.Name = "lblDiferenciaKilometraje"
        Me.lblDiferenciaKilometraje.Size = New System.Drawing.Size(133, 14)
        Me.lblDiferenciaKilometraje.TabIndex = 50
        Me.lblDiferenciaKilometraje.Text = "Diferencia de kilometraje:"
        '
        'lblDiferenciaLitrosGas
        '
        Me.lblDiferenciaLitrosGas.AutoSize = True
        Me.lblDiferenciaLitrosGas.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDiferenciaLitrosGas.Location = New System.Drawing.Point(16, 196)
        Me.lblDiferenciaLitrosGas.Name = "lblDiferenciaLitrosGas"
        Me.lblDiferenciaLitrosGas.Size = New System.Drawing.Size(138, 14)
        Me.lblDiferenciaLitrosGas.TabIndex = 49
        Me.lblDiferenciaLitrosGas.Text = "Diferencia de litros de gas:"
        '
        'lblDiferenciaGas
        '
        Me.lblDiferenciaGas.AutoSize = True
        Me.lblDiferenciaGas.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDiferenciaGas.Location = New System.Drawing.Point(16, 166)
        Me.lblDiferenciaGas.Name = "lblDiferenciaGas"
        Me.lblDiferenciaGas.Size = New System.Drawing.Size(125, 14)
        Me.lblDiferenciaGas.TabIndex = 48
        Me.lblDiferenciaGas.Text = "Diferencia de % de gas:"
        '
        'lblDiferenciaPeso
        '
        Me.lblDiferenciaPeso.AutoSize = True
        Me.lblDiferenciaPeso.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDiferenciaPeso.Location = New System.Drawing.Point(16, 136)
        Me.lblDiferenciaPeso.Name = "lblDiferenciaPeso"
        Me.lblDiferenciaPeso.Size = New System.Drawing.Size(101, 14)
        Me.lblDiferenciaPeso.TabIndex = 47
        Me.lblDiferenciaPeso.Text = "Diferencia de peso:"
        '
        'lblLitrosBascula
        '
        Me.lblLitrosBascula.AutoSize = True
        Me.lblLitrosBascula.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLitrosBascula.Location = New System.Drawing.Point(16, 32)
        Me.lblLitrosBascula.Name = "lblLitrosBascula"
        Me.lblLitrosBascula.Size = New System.Drawing.Size(92, 14)
        Me.lblLitrosBascula.TabIndex = 24
        Me.lblLitrosBascula.Text = "Litros en bascula:"
        '
        'lblLitrosLiquidados
        '
        Me.lblLitrosLiquidados.AutoSize = True
        Me.lblLitrosLiquidados.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLitrosLiquidados.Location = New System.Drawing.Point(16, 62)
        Me.lblLitrosLiquidados.Name = "lblLitrosLiquidados"
        Me.lblLitrosLiquidados.Size = New System.Drawing.Size(89, 14)
        Me.lblLitrosLiquidados.TabIndex = 39
        Me.lblLitrosLiquidados.Text = "Litros liquidados:"
        '
        'lblDiferenciaLitros
        '
        Me.lblDiferenciaLitros.AutoSize = True
        Me.lblDiferenciaLitros.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDiferenciaLitros.Location = New System.Drawing.Point(16, 92)
        Me.lblDiferenciaLitros.Name = "lblDiferenciaLitros"
        Me.lblDiferenciaLitros.Size = New System.Drawing.Size(102, 14)
        Me.lblDiferenciaLitros.TabIndex = 40
        Me.lblDiferenciaLitros.Text = "Diferencia de litros:"
        '
        'txtDiferenciaPeso
        '
        Me.txtDiferenciaPeso.BackColor = System.Drawing.Color.Gainsboro
        Me.txtDiferenciaPeso.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDiferenciaPeso.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDiferenciaPeso.ForeColor = System.Drawing.Color.Black
        Me.txtDiferenciaPeso.Location = New System.Drawing.Point(157, 133)
        Me.txtDiferenciaPeso.Name = "txtDiferenciaPeso"
        Me.txtDiferenciaPeso.ReadOnly = True
        Me.txtDiferenciaPeso.Size = New System.Drawing.Size(120, 21)
        Me.txtDiferenciaPeso.TabIndex = 13
        Me.txtDiferenciaPeso.TabStop = False
        Me.txtDiferenciaPeso.Text = ""
        '
        'rgrpDiferencias
        '
        Me.rgrpDiferencias.BorderColor = System.Drawing.Color.Gray
        Me.rgrpDiferencias.Controls.AddRange(New System.Windows.Forms.Control() {Me.figSeparador, Me.lblDiferenciaLitros, Me.lblLitrosBascula, Me.lblLitrosLiquidados, Me.lblDiferenciaTotalizador, Me.lblDiferenciaKilometraje, Me.lblDiferenciaLitrosGas, Me.lblDiferenciaGas, Me.lblDiferenciaPeso, Me.txtDiferenciaLitros, Me.txtLitrosLiquidados, Me.txtLitrosBascula, Me.txtDiferenciaPeso, Me.txtDiferenciaTotalizador, Me.txtDiferenciaKilometraje, Me.txtDiferenciaLitrosGas, Me.txtDiferenciaGas})
        Me.rgrpDiferencias.Dock = System.Windows.Forms.DockStyle.Left
        Me.rgrpDiferencias.FlatStyle = Bascula.RoundedGroupBox.Style.Road
        Me.rgrpDiferencias.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rgrpDiferencias.Location = New System.Drawing.Point(3, 211)
        Me.rgrpDiferencias.Name = "rgrpDiferencias"
        Me.rgrpDiferencias.Size = New System.Drawing.Size(288, 305)
        Me.rgrpDiferencias.TabIndex = 59
        Me.rgrpDiferencias.TabStop = False
        Me.rgrpDiferencias.Text = "Diferencias"
        Me.rgrpDiferencias.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left
        '
        'figSeparador
        '
        Me.figSeparador.FillColor = System.Drawing.Color.LightSteelBlue
        Me.figSeparador.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.figSeparador.LineColor = System.Drawing.Color.Silver
        Me.figSeparador.LineWidth = 2.0!
        Me.figSeparador.Location = New System.Drawing.Point(8, 112)
        Me.figSeparador.Name = "figSeparador"
        Me.figSeparador.Size = New System.Drawing.Size(272, 16)
        Me.figSeparador.Style = Bascula.Figure.FigureStyle.Line
        Me.figSeparador.TabIndex = 52
        '
        'lblStatusBascula
        '
        Me.lblStatusBascula.AutoSize = True
        Me.lblStatusBascula.Location = New System.Drawing.Point(16, 120)
        Me.lblStatusBascula.Name = "lblStatusBascula"
        Me.lblStatusBascula.Size = New System.Drawing.Size(96, 14)
        Me.lblStatusBascula.TabIndex = 6
        Me.lblStatusBascula.Text = "Status de &báscula:"
        '
        'lblStatusLogistica
        '
        Me.lblStatusLogistica.AutoSize = True
        Me.lblStatusLogistica.Location = New System.Drawing.Point(16, 152)
        Me.lblStatusLogistica.Name = "lblStatusLogistica"
        Me.lblStatusLogistica.Size = New System.Drawing.Size(99, 14)
        Me.lblStatusLogistica.TabIndex = 8
        Me.lblStatusLogistica.Text = "Status de &logística:"
        '
        'cboStatusBascula
        '
        Me.cboStatusBascula.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboStatusBascula.Items.AddRange(New Object() {"ABIERTO", "CANCELADO", "CERRADO"})
        Me.cboStatusBascula.Location = New System.Drawing.Point(120, 117)
        Me.cboStatusBascula.Name = "cboStatusBascula"
        Me.cboStatusBascula.Size = New System.Drawing.Size(166, 21)
        Me.cboStatusBascula.TabIndex = 7
        Me.cboStatusBascula.Tag = "StatusBascula"
        '
        'cboStatusLogistica
        '
        Me.cboStatusLogistica.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboStatusLogistica.Items.AddRange(New Object() {"ASIGNADO", "CANCELADO", "CIERRE", "INICIO", "LIQCAJA", "LIQUIDADO", "SIN SALIDA"})
        Me.cboStatusLogistica.Location = New System.Drawing.Point(120, 149)
        Me.cboStatusLogistica.Name = "cboStatusLogistica"
        Me.cboStatusLogistica.Size = New System.Drawing.Size(166, 21)
        Me.cboStatusLogistica.TabIndex = 9
        Me.cboStatusLogistica.Tag = "StatusLogistica"
        '
        'btnAceptar
        '
        Me.btnAceptar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnAceptar.Image = CType(resources.GetObject("btnAceptar.Image"), System.Drawing.Bitmap)
        Me.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAceptar.Location = New System.Drawing.Point(408, 487)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.TabIndex = 2
        Me.btnAceptar.Text = "&Aceptar"
        Me.btnAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnCancelar
        '
        Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnCancelar.Image = CType(resources.GetObject("btnCancelar.Image"), System.Drawing.Bitmap)
        Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancelar.Location = New System.Drawing.Point(504, 487)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.TabIndex = 3
        Me.btnCancelar.Text = "&Cancelar"
        Me.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblCelula
        '
        Me.lblCelula.AutoSize = True
        Me.lblCelula.Location = New System.Drawing.Point(16, 24)
        Me.lblCelula.Name = "lblCelula"
        Me.lblCelula.Size = New System.Drawing.Size(38, 14)
        Me.lblCelula.TabIndex = 0
        Me.lblCelula.Text = "C&elula:"
        '
        'cboCelula
        '
        Me.cboCelula.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCelula.Location = New System.Drawing.Point(120, 21)
        Me.cboCelula.Name = "cboCelula"
        Me.cboCelula.Size = New System.Drawing.Size(166, 21)
        Me.cboCelula.TabIndex = 1
        Me.cboCelula.Tag = "Celula"
        '
        'rgrpOtros
        '
        Me.rgrpOtros.BorderColor = System.Drawing.Color.Gray
        Me.rgrpOtros.Controls.AddRange(New System.Windows.Forms.Control() {Me.cboStatusBascula, Me.cboStatusLogistica, Me.lblCelula, Me.cboCelula, Me.lblStatusBascula, Me.lblStatusLogistica, Me.lblRuta, Me.cboRuta, Me.cboAutotanque, Me.lblAutotanque})
        Me.rgrpOtros.FlatStyle = Bascula.RoundedGroupBox.Style.Pipe
        Me.rgrpOtros.Location = New System.Drawing.Point(304, 216)
        Me.rgrpOtros.Name = "rgrpOtros"
        Me.rgrpOtros.Size = New System.Drawing.Size(291, 184)
        Me.rgrpOtros.TabIndex = 1
        Me.rgrpOtros.TabStop = False
        Me.rgrpOtros.Text = "Otros datos"
        Me.rgrpOtros.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left
        '
        'lblRuta
        '
        Me.lblRuta.AutoSize = True
        Me.lblRuta.Location = New System.Drawing.Point(16, 56)
        Me.lblRuta.Name = "lblRuta"
        Me.lblRuta.Size = New System.Drawing.Size(31, 14)
        Me.lblRuta.TabIndex = 2
        Me.lblRuta.Text = "&Ruta:"
        '
        'cboRuta
        '
        Me.cboRuta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboRuta.Location = New System.Drawing.Point(120, 53)
        Me.cboRuta.Name = "cboRuta"
        Me.cboRuta.Size = New System.Drawing.Size(166, 21)
        Me.cboRuta.TabIndex = 3
        Me.cboRuta.Tag = "Ruta"
        '
        'cboAutotanque
        '
        Me.cboAutotanque.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboAutotanque.Location = New System.Drawing.Point(120, 85)
        Me.cboAutotanque.Name = "cboAutotanque"
        Me.cboAutotanque.Size = New System.Drawing.Size(166, 21)
        Me.cboAutotanque.TabIndex = 5
        Me.cboAutotanque.Tag = "Autotanque"
        '
        'lblAutotanque
        '
        Me.lblAutotanque.AutoSize = True
        Me.lblAutotanque.Location = New System.Drawing.Point(16, 88)
        Me.lblAutotanque.Name = "lblAutotanque"
        Me.lblAutotanque.Size = New System.Drawing.Size(66, 14)
        Me.lblAutotanque.TabIndex = 4
        Me.lblAutotanque.Text = "A&utotanque:"
        '
        'lblFolio
        '
        Me.lblFolio.AutoSize = True
        Me.lblFolio.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFolio.ForeColor = System.Drawing.Color.Navy
        Me.lblFolio.Location = New System.Drawing.Point(327, 434)
        Me.lblFolio.Name = "lblFolio"
        Me.lblFolio.Size = New System.Drawing.Size(50, 15)
        Me.lblFolio.TabIndex = 60
        Me.lblFolio.Text = "Folio:   "
        '
        'lblAño
        '
        Me.lblAño.AutoSize = True
        Me.lblAño.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAño.ForeColor = System.Drawing.Color.Navy
        Me.lblAño.Location = New System.Drawing.Point(327, 408)
        Me.lblAño.Name = "lblAño"
        Me.lblAño.Size = New System.Drawing.Size(47, 15)
        Me.lblAño.TabIndex = 60
        Me.lblAño.Text = "Año:    "
        '
        'cboMotivo
        '
        Me.cboMotivo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboMotivo.Items.AddRange(New Object() {"ASIGNADO", "CANCELADO", "CIERRE", "INICIO", "LIQCAJA", "LIQUIDADO", "SIN SALIDA"})
        Me.cboMotivo.Location = New System.Drawing.Point(376, 457)
        Me.cboMotivo.Name = "cboMotivo"
        Me.cboMotivo.Size = New System.Drawing.Size(200, 21)
        Me.cboMotivo.TabIndex = 11
        Me.cboMotivo.Tag = "StatusLogistica"
        '
        'lblMotivo
        '
        Me.lblMotivo.AutoSize = True
        Me.lblMotivo.Location = New System.Drawing.Point(327, 460)
        Me.lblMotivo.Name = "lblMotivo"
        Me.lblMotivo.Size = New System.Drawing.Size(41, 14)
        Me.lblMotivo.TabIndex = 10
        Me.lblMotivo.Text = "Motivo:"
        '
        'frmCapturaCiclo
        '
        Me.AcceptButton = Me.btnAceptar
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 14)
        Me.BackColor = System.Drawing.Color.Gainsboro
        Me.CancelButton = Me.btnCancelar
        Me.ClientSize = New System.Drawing.Size(602, 519)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblFolio, Me.lblAño, Me.rgrpOtros, Me.btnAceptar, Me.rgrpDiferencias, Me.pnlDatos, Me.btnCancelar, Me.lblMotivo, Me.cboMotivo})
        Me.DockPadding.All = 3
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmCapturaCiclo"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.pnlDatos.ResumeLayout(False)
        Me.rgrpCierre.ResumeLayout(False)
        Me.rgrpApertura.ResumeLayout(False)
        Me.rgrpDiferencias.ResumeLayout(False)
        Me.rgrpOtros.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Constructores"
    Public Sub New(ByVal Fecha As DateTime)
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        Me.Text = "Nuevo ciclo"
        dtpFLlegada.Value = Fecha
        dtpFSalida.Value = Fecha
        cboStatusBascula.SelectedIndex = 0
        cboStatusLogistica.SelectedIndex = 0
        lblMotivo.Visible = False
        cboMotivo.Visible = False
        CargaRutas()
        CargaAutotanques()
        CargaCelulas()
    End Sub
    Public Sub New(ByVal Datos As DataRow)
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        Me.Text = "Modificación del ciclo con folio " & CStr(Datos("Folio")) & " del año " & CStr(Datos("AñoAtt"))
        dtpFSalida.MinDate = CDate("01/01/" & CStr(Datos("AñoAtt")))
        dtpFSalida.MaxDate = CDate("31/12/" & CStr(Datos("AñoAtt")))
        dtpFLlegada.MinDate = CDate("01/01/" & CStr(Datos("AñoAtt")))
        dtpFLlegada.MaxDate = CDate("31/12/" & CStr(Datos("AñoAtt")))
        _Año = CInt(Datos("AñoAtt"))
        _Folio = CInt(Datos("Folio"))
        lblAño.Text = "Año: " & _Año.ToString
        lblFolio.Text &= _Folio.ToString
        DatosIniciales = Datos
        txtPesoLlegada.Enabled = Globales.GetInstance.OperacionBascula(5).Habilitada Or Globales.GetInstance.OperacionBascula(9).Habilitada
        txtPesoSalida.Enabled = Globales.GetInstance.OperacionBascula(5).Habilitada Or Globales.GetInstance.OperacionBascula(9).Habilitada
        'txtGasFinal.Enabled = Globales.GetInstance.OperacionBascula(2).Habilitada Or Globales.GetInstance.OperacionBascula(9).Habilitada
        'txtGasInicial.Enabled = Globales.GetInstance.OperacionBascula(2).Habilitada Or Globales.GetInstance.OperacionBascula(9).Habilitada
        CargaRutas()
        CargaAutotanques()
        CargaCelulas()
        CargaMotivo()
        CargaDatos(Datos)
    End Sub
#End Region
#Region "Variables globales"
    Private _Año, _Folio, CapacidadAutotanque As Integer
    Private PrevCelula As Byte
    Private DatosIniciales As DataRow
    Private dtRuta As New DataTable()
    Dim dtAutotanque As New DataTable()
#End Region
#Region "Rutinas de actualización"
    Private Sub CargaRutas()
        Dim cmdBascula As New SqlCommand("Select Ruta, Descripcion, Celula from Ruta order by Descripcion", Globales.GetInstance.cnSigamet)
        Dim daBascula As New SqlDataAdapter(cmdBascula)
        Try
            daBascula.Fill(dtRuta)
        Catch ex As Exception
            Globales.GetInstance.ExMessage(ex)
        End Try
    End Sub
    Private Sub CargaAutotanques()
        Dim cmdBascula As New SqlCommand("Select Autotanque, Capacidad from Autotanque where Status ='ACTIVO' and TipoVehiculo = 1 order by Autotanque", Globales.GetInstance.cnSigamet)
        Dim daBascula As New SqlDataAdapter(cmdBascula)
        Dim PK(0) As DataColumn
        Try
            daBascula.Fill(dtAutotanque)
            PK(0) = dtAutotanque.Columns("Autotanque")
            dtAutotanque.PrimaryKey = PK
        Catch ex As Exception
            Globales.GetInstance.ExMessage(ex)
        End Try
        cboAutotanque.DisplayMember = "Autotanque"
        cboAutotanque.ValueMember = "Autotanque"
        cboAutotanque.DataSource = dtAutotanque
    End Sub
    Private Sub CargaCelulas()
        Dim cmdBascula As New SqlCommand("Select Celula, Descripcion from Celula where Comercial = 1 order by Descripcion", Globales.GetInstance.cnSigamet)
        Dim daBascula As New SqlDataAdapter(cmdBascula)
        Dim dtCelula As New DataTable()
        cmdBascula.Parameters.Add("@Usuario", SqlDbType.Char).Value = Globales.GetInstance._Usuario
        Try
            daBascula.Fill(dtCelula)
        Catch ex As Exception
            Globales.GetInstance.ExMessage(ex)
        End Try
        cboCelula.ValueMember = "Celula"
        cboCelula.DisplayMember = "Descripcion"
        cboCelula.DataSource = dtCelula
    End Sub
    Private Sub CargaMotivo()
        Dim cmdBascula As New SqlCommand("Select * from MotivoModificacionAutotanqueTurno order by MotivoModificacionAutotanqueTurno", Globales.GetInstance.cnSigamet)
        Dim daBascula As New SqlDataAdapter(cmdBascula)
        Dim dtMotivo As New DataTable()
        Try
            daBascula.Fill(dtMotivo)
        Catch ex As Exception
            Globales.GetInstance.ExMessage(ex)
        End Try
        cboMotivo.ValueMember = "MotivoModificacionAutotanqueTurno"
        cboMotivo.DisplayMember = "Descripcion"
        cboMotivo.DataSource = dtMotivo
    End Sub
    Private Sub CargaDatos(ByVal Datos As DataRow)
        On Error Resume Next
        cboAutotanque.SelectedValue = Datos("Autotanque")
        dtpFSalida.Value = CDate(Datos("FInicioRuta"))
        txtPesoSalida.Text = CStr(Datos("PesoSalida")).Trim
        txtGasInicial.Text = CStr(Datos("PorcentajeGasInicial")).Trim
        txtKilometrajeInicial.Text = CStr(Datos("KilometrajeInicial")).Trim
        txtTotalizadorInicial.Text = CStr(Datos("TotalizadorInicial")).Trim

        dtpFLlegada.Value = CDate(Datos("FTerminoRuta"))
        txtPesoLlegada.Text = CStr(Datos("PesoLlegada")).Trim
        txtGasFinal.Text = CStr(Datos("PorcentajeGasFinal")).Trim
        txtKilometrajeFinal.Text = CStr(Datos("KilometrajeFinal")).Trim
        txtTotalizadorFinal.Text = CStr(Datos("TotalizadorFinal")).Trim

        cboCelula.SelectedValue = Datos("Celula")
        cboRuta.SelectedValue = Datos("Ruta")

        cboStatusBascula.Text = CStr(Datos("StatusBascula")).Trim
        cboStatusLogistica.Text = CStr(Datos("StatusLogistica")).Trim

        txtLitrosBascula.Text = CStr(Datos("LitrosVendidos")).Trim
        txtLitrosLiquidados.Text = CStr(Datos("LitrosLiquidados")).Trim
    End Sub
    Private Sub cboCelula_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboCelula.SelectedIndexChanged
        If Not cboCelula.SelectedItem Is Nothing AndAlso PrevCelula <> CByte(cboCelula.SelectedValue) Then
            Dim dtRutaCelula As New DataTable()
            Dim dtAutotanqueCelula As New DataTable()
            dtRuta.DefaultView.RowFilter = "Celula = " & CStr(cboCelula.SelectedValue)
            dtRutaCelula = Globales.GetInstance.ViewToTable(dtRuta.DefaultView)
            cboRuta.DisplayMember = "Ruta"
            cboRuta.ValueMember = "Ruta"
            cboRuta.DataSource = dtRutaCelula
            If Not DatosIniciales Is Nothing AndAlso _
                    CStr(CType(sender, ComboBox).SelectedValue).Trim <> CStr(DatosIniciales(CStr(CType(sender, ComboBox).Tag))).Trim Then
                lblCelula.ForeColor = Color.DarkRed
            Else
                lblCelula.ForeColor = Color.Black
            End If
            PrevCelula = CByte(cboCelula.SelectedValue)
        End If
    End Sub
#End Region
#Region "Manejo de cajas de texto"
    Private Sub TextBox_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPesoSalida.Enter, txtGasInicial.Enter, txtKilometrajeInicial.Enter, txtTotalizadorInicial.Enter, txtPesoLlegada.Enter, txtGasFinal.Enter, txtKilometrajeFinal.Enter, txtTotalizadorFinal.Enter
        CType(sender, TextBox).BackColor = Color.LemonChiffon
        CType(sender, TextBox).SelectAll()
    End Sub
    Private Sub TextBox_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPesoSalida.Leave, txtGasInicial.Leave, txtKilometrajeInicial.Leave, txtTotalizadorInicial.Leave, txtPesoLlegada.Leave, txtGasFinal.Leave, txtKilometrajeFinal.Leave, txtTotalizadorFinal.Leave
        CType(sender, TextBox).BackColor = Color.White
    End Sub
    Private Sub TextBoxInteger_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtKilometrajeInicial.KeyPress, txtKilometrajeFinal.KeyPress
        If Not (Char.IsDigit(e.KeyChar) OrElse Char.IsControl(e.KeyChar) OrElse Asc(e.KeyChar) = 8) Then
            e.Handled = True
        Else
            e.Handled = False
        End If
    End Sub
    Private Sub TextBoxDecimal_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtGasInicial.KeyPress, txtGasFinal.KeyPress
        If Not (Char.IsDigit(e.KeyChar) OrElse Char.IsControl(e.KeyChar) OrElse Asc(e.KeyChar) = 8 OrElse _
                    (e.KeyChar = CChar(".") AndAlso CType(sender, TextBox).Text.IndexOf(".") < 0)) Then
            e.Handled = True
        Else
            e.Handled = False
        End If
    End Sub
    Private Sub TextBoxParametrezado_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPesoSalida.KeyPress, txtTotalizadorInicial.KeyPress, txtPesoLlegada.KeyPress, txtTotalizadorFinal.KeyPress
        If Globales.GetInstance._TipoDato Then
            If Not (Char.IsDigit(e.KeyChar) OrElse Char.IsControl(e.KeyChar) OrElse Asc(e.KeyChar) = 8 OrElse _
                        (e.KeyChar = CChar(".") AndAlso CType(sender, TextBox).Text.IndexOf(".") < 0) OrElse _
                         (e.KeyChar = CChar("-") AndAlso CType(sender, TextBox).Text.IndexOf("-") < 0 AndAlso CType(sender, TextBox).Name = "txtTemperatura" AndAlso CType(sender, TextBox).SelectionStart = 0)) Then
                e.Handled = True
            Else
                e.Handled = False
            End If
        Else
            If Not (Char.IsDigit(e.KeyChar) OrElse Char.IsControl(e.KeyChar) OrElse Asc(e.KeyChar) = 8) Then
                e.Handled = True
            Else
                e.Handled = False
            End If
        End If

    End Sub
#End Region
#Region "Manejo de cambios"
    Private Sub dtpFSalida_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpFSalida.ValueChanged
        If DatosIniciales Is Nothing Then
            _Año = dtpFSalida.Value.Year
            lblAño.Text = "Año: " & _Año.ToString
        ElseIf dtpFSalida.Value.Date <> CDate(DatosIniciales("FInicioRuta")).Date Then
            lblFSalida.ForeColor = Color.DarkRed
        Else
            lblFSalida.ForeColor = Color.Black
        End If
    End Sub
    Private Sub dtpFLlegada_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpFLlegada.ValueChanged
        If Not DatosIniciales Is Nothing AndAlso dtpFLlegada.Value.Date <> CDate(DatosIniciales("FTerminoRuta")).Date Then
            lblFLlegada.ForeColor = Color.DarkRed
        Else
            lblFLlegada.ForeColor = Color.Black
        End If
    End Sub
    Private Sub txtPesoSalida_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPesoSalida.TextChanged
        If Not DatosIniciales Is Nothing AndAlso _
                    CType(sender, TextBox).Text.Trim <> CStr(DatosIniciales(CStr(CType(sender, TextBox).Tag))).Trim Then
            lblPesoSalida.ForeColor = Color.DarkRed
        Else
            lblPesoSalida.ForeColor = Color.Black
        End If
    End Sub
    Private Sub txtGasInicial_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtGasInicial.TextChanged
        If Not DatosIniciales Is Nothing AndAlso _
                    CType(sender, TextBox).Text.Trim <> CStr(DatosIniciales(CStr(CType(sender, TextBox).Tag))).Trim Then
            lblGasInicial.ForeColor = Color.DarkRed
        Else
            lblGasInicial.ForeColor = Color.Black
        End If
    End Sub
    Private Sub txtKilometrajeInicial_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtKilometrajeInicial.TextChanged
        If Not DatosIniciales Is Nothing AndAlso _
                    CType(sender, TextBox).Text.Trim <> CStr(DatosIniciales(CStr(CType(sender, TextBox).Tag))).Trim Then
            lblKilometrajeInicial.ForeColor = Color.DarkRed
        Else
            lblKilometrajeInicial.ForeColor = Color.Black
        End If
    End Sub
    Private Sub txtTotalizadorInicial_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtTotalizadorInicial.TextChanged
        If Not DatosIniciales Is Nothing AndAlso _
                    CType(sender, TextBox).Text.Trim <> CStr(DatosIniciales(CStr(CType(sender, TextBox).Tag))).Trim Then
            lblTotalizadorInicial.ForeColor = Color.DarkRed
        Else
            lblTotalizadorInicial.ForeColor = Color.Black
        End If
    End Sub
    Private Sub txtPesoLlegada_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPesoLlegada.TextChanged
        If Not DatosIniciales Is Nothing AndAlso _
                    CType(sender, TextBox).Text.Trim <> CStr(DatosIniciales(CStr(CType(sender, TextBox).Tag))).Trim Then
            lblPesoLlegada.ForeColor = Color.DarkRed
        Else
            lblPesoLlegada.ForeColor = Color.Black
        End If
    End Sub
    Private Sub txtGasFinal_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtGasFinal.TextChanged
        If Not DatosIniciales Is Nothing AndAlso _
                    CType(sender, TextBox).Text.Trim <> CStr(DatosIniciales(CStr(CType(sender, TextBox).Tag))).Trim Then
            lblGasFinal.ForeColor = Color.DarkRed
        Else
            lblGasFinal.ForeColor = Color.Black
        End If
    End Sub
    Private Sub txtKilometrajeFinal_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtKilometrajeFinal.TextChanged
        If Not DatosIniciales Is Nothing AndAlso _
                    CType(sender, TextBox).Text.Trim <> CStr(DatosIniciales(CStr(CType(sender, TextBox).Tag))).Trim Then
            lblKilometrajeFinal.ForeColor = Color.DarkRed
        Else
            lblKilometrajeFinal.ForeColor = Color.Black
        End If
    End Sub
    Private Sub txtTotalizadorFinal_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtTotalizadorFinal.TextChanged
        If Not DatosIniciales Is Nothing AndAlso _
                    CType(sender, TextBox).Text.Trim <> CStr(DatosIniciales(CStr(CType(sender, TextBox).Tag))).Trim Then
            lblTotalizadorFinal.ForeColor = Color.DarkRed
        Else
            lblTotalizadorFinal.ForeColor = Color.Black
        End If
    End Sub
    Private Sub cboRuta_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboRuta.SelectedIndexChanged
        If Not DatosIniciales Is Nothing AndAlso _
                    CStr(CType(sender, ComboBox).SelectedValue).Trim <> CStr(DatosIniciales(CStr(CType(sender, ComboBox).Tag))).Trim Then
            lblRuta.ForeColor = Color.DarkRed
        Else
            lblRuta.ForeColor = Color.Black
        End If
    End Sub
    Private Sub cboAutotanque_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboAutotanque.SelectedIndexChanged
        If Not DatosIniciales Is Nothing AndAlso Not CType(sender, ComboBox).SelectedValue Is Nothing AndAlso _
            CStr(CType(sender, ComboBox).SelectedValue).Trim <> CStr(DatosIniciales(CStr(CType(sender, ComboBox).Tag))).Trim Then
            lblAutotanque.ForeColor = Color.DarkRed
        Else
            lblAutotanque.ForeColor = Color.Black
        End If
    End Sub
    Private Sub cboStatusBascula_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboStatusBascula.SelectedIndexChanged
        If Not DatosIniciales Is Nothing AndAlso _
                    CType(sender, ComboBox).Text.Trim <> CStr(DatosIniciales(CStr(CType(sender, ComboBox).Tag))).Trim Then
            lblStatusBascula.ForeColor = Color.DarkRed
        Else
            lblStatusBascula.ForeColor = Color.Black
        End If
        Select Case cboStatusBascula.Text.Trim.ToUpper
            Case "ABIERTO"
                Dim StatusLogistica As String() = {"ASIGNADO", "INICIO"}
                cboStatusLogistica.Items.Clear()
                cboStatusLogistica.Items.AddRange(StatusLogistica)
                cboStatusLogistica.SelectedIndex = 0
            Case "CANCELADO"
                Dim StatusLogistica As String() = {"CANCELADO", "SIN SALIDA"}
                cboStatusLogistica.Items.Clear()
                cboStatusLogistica.Items.AddRange(StatusLogistica)
                cboStatusLogistica.SelectedIndex = 0
            Case "CERRADO"
                Dim StatusLogistica As String() = {"CIERRE", "LIQUIDADO", "LIQCAJA"}
                cboStatusLogistica.Items.Clear()
                cboStatusLogistica.Items.AddRange(StatusLogistica)
                cboStatusLogistica.SelectedIndex = 0
        End Select
    End Sub
    Private Sub cboStatusLogistica_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboStatusLogistica.SelectedIndexChanged
        If Not DatosIniciales Is Nothing AndAlso _
                            CType(sender, ComboBox).Text.Trim <> CStr(DatosIniciales(CStr(CType(sender, ComboBox).Tag))).Trim Then
            lblStatusLogistica.ForeColor = Color.DarkRed
        Else
            lblStatusLogistica.ForeColor = Color.Black
        End If
    End Sub
#End Region

    Private Sub ObtieneCapacidadAutotanque(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboAutotanque.SelectedIndexChanged
        If Not cboAutotanque.SelectedValue Is Nothing Then
            CapacidadAutotanque = CInt(dtAutotanque.Rows.Find(cboAutotanque.SelectedValue)("Capacidad"))
        End If
    End Sub
    Private Sub CalculaLitrosGasInicial(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtGasInicial.TextChanged, cboAutotanque.SelectedIndexChanged
        Try
            If Val(txtGasInicial.Text) > 100 Then
                txtGasInicial.Text = "100"
            End If
            CapacidadAutotanque = CInt(dtAutotanque.Rows.Find(cboAutotanque.SelectedValue)("Capacidad"))
            txtLitrosInicial.Text = Fix(CapacidadAutotanque * Val(txtGasInicial.Text) / 100).ToString
        Catch ex As Exception
            Globales.GetInstance.ErrMessage("El número escrito es erroneo o demasiado grande." & Chr(13) & "Verifique.")
            CType(sender, TextBox).SelectAll()
        End Try
    End Sub
    Private Sub CalculaLitrosGasFinal(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtGasFinal.TextChanged, cboAutotanque.SelectedIndexChanged
        Try
            If Val(txtGasFinal.Text) > 100 Then
                txtGasFinal.Text = "100"
            End If
            CapacidadAutotanque = CInt(dtAutotanque.Rows.Find(cboAutotanque.SelectedValue)("Capacidad"))
            txtLitrosFinal.Text = Fix(CapacidadAutotanque * Val(txtGasFinal.Text) / 100).ToString
        Catch ex As Exception
            Globales.GetInstance.ErrMessage("El número escrito es erroneo o demasiado grande." & Chr(13) & "Verifique.")
            CType(sender, TextBox).SelectAll()
        End Try
    End Sub
    Private Sub CalculaLitrosEnBascula(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtDiferenciaPeso.TextChanged, txtLitrosLiquidados.TextChanged
        txtLitrosBascula.Text = Fix(CInt(txtDiferenciaPeso.Text) / Globales.GetInstance._FactorDensidad).ToString
        txtDiferenciaLitros.Text = Fix(Val(txtLitrosLiquidados.Text) - Val(txtLitrosBascula.Text)).ToString
    End Sub
    Private Sub CalculaDiferenciaGas(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtGasInicial.TextChanged, txtGasFinal.TextChanged
        txtDiferenciaGas.Text = (Val(txtGasInicial.Text) - Val(txtGasFinal.Text)).ToString
    End Sub
    Private Sub CalculaDiferenciaLitros(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtLitrosInicial.TextChanged, txtLitrosFinal.TextChanged
        Try
            txtDiferenciaLitrosGas.Text = (Val(txtLitrosInicial.Text) - Val(txtLitrosFinal.Text)).ToString
        Catch ex As Exception
            Globales.GetInstance.ErrMessage("El número escrito es erroneo o demasiado grande." & Chr(13) & "Verifique.")
            CType(sender, TextBox).SelectAll()
        End Try
    End Sub
    Private Sub CalculaDiferenciaPeso(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPesoSalida.TextChanged, txtPesoLlegada.TextChanged
        Try
            txtDiferenciaPeso.Text = (Val(txtPesoSalida.Text) - Val(txtPesoLlegada.Text)).ToString
        Catch ex As Exception
            Globales.GetInstance.ErrMessage("El número escrito es erroneo o demasiado grande." & Chr(13) & "Verifique.")
            CType(sender, TextBox).SelectAll()
        End Try
    End Sub
    Private Sub CalculaDiferenciaKilometraje(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtKilometrajeInicial.TextChanged, txtKilometrajeFinal.TextChanged
        Try
            txtDiferenciaKilometraje.Text = (Val(txtKilometrajeFinal.Text) - Val(txtKilometrajeInicial.Text)).ToString
        Catch ex As Exception
            Globales.GetInstance.ErrMessage("El número escrito es erroneo o demasiado grande." & Chr(13) & "Verifique.")
            CType(sender, TextBox).SelectAll()
        End Try
    End Sub
    Private Sub CalculaDiferenciaTotalizador(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTotalizadorInicial.TextChanged, txtTotalizadorFinal.TextChanged
        Try
            txtDiferenciaTotalizador.Text = (Val(txtTotalizadorFinal.Text) - Val(txtTotalizadorInicial.Text)).ToString
        Catch ex As Exception
            Globales.GetInstance.ErrMessage("El número escrito es erroneo o demasiado grande." & Chr(13) & "Verifique.")
            CType(sender, TextBox).SelectAll()
        End Try
    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        Dim cmdBascula As New SqlCommand("spBASModificaFolio", Globales.GetInstance.cnSigamet)
        Dim rdFolio As SqlDataReader
        If cboMotivo.Visible AndAlso CInt(cboMotivo.SelectedValue) = 0 Then
            Globales.GetInstance.ErrMessage("Debe seleccionar el motivo de la modificación.")
            cboMotivo.Focus()
            Exit Sub
        End If
        cmdBascula.Parameters.Add("@Año", SqlDbType.SmallInt).Value = _Año
        cmdBascula.Parameters.Add("@Folio", SqlDbType.Int).Value = _Folio
        cmdBascula.Parameters.Add("@Celula", SqlDbType.TinyInt).Value = cboCelula.SelectedValue
        cmdBascula.Parameters.Add("@Autotanque", SqlDbType.SmallInt).Value = cboAutotanque.SelectedValue
        cmdBascula.Parameters.Add("@Ruta", SqlDbType.SmallInt).Value = cboRuta.SelectedValue
        cmdBascula.Parameters.Add("@FInicioRuta", SqlDbType.DateTime).Value = dtpFSalida.Value.Date
        cmdBascula.Parameters.Add("@KilometrajeInicial", SqlDbType.Int).Value = CInt(Val(txtKilometrajeInicial.Text))
        cmdBascula.Parameters.Add("@TotalizadorInicial", SqlDbType.Int).Value = CInt(Val(txtTotalizadorInicial.Text))
        cmdBascula.Parameters.Add("@PorcentajeGasInicial", SqlDbType.Decimal).Value = Val(txtGasInicial.Text)
        cmdBascula.Parameters.Add("@LitrosGasInicial", SqlDbType.Int).Value = CInt(Val(txtLitrosInicial.Text))
        cmdBascula.Parameters.Add("@PesoSalida", SqlDbType.Int).Value = CInt(Val(txtPesoSalida.Text))
        cmdBascula.Parameters.Add("@LitrosVendidos", SqlDbType.Int).Value = CInt(Val(txtDiferenciaTotalizador.Text))
        cmdBascula.Parameters.Add("@LitrosGasNoVendido", SqlDbType.Int).Value = CInt(Val(txtLitrosFinal.Text))
        cmdBascula.Parameters.Add("@FTerminoRuta", SqlDbType.DateTime).Value = dtpFLlegada.Value.Date
        cmdBascula.Parameters.Add("@TotalizadorFinal", SqlDbType.Int).Value = CInt(Val(txtTotalizadorFinal.Text))
        cmdBascula.Parameters.Add("@PesoLlegada", SqlDbType.Int).Value = CInt(Val(txtPesoLlegada.Text))
        cmdBascula.Parameters.Add("@KilometrajeFinal", SqlDbType.Int).Value = CInt(Val(txtKilometrajeFinal.Text))
        cmdBascula.Parameters.Add("@PorcentajeGasNoVendido", SqlDbType.Decimal).Value = Val(txtGasFinal.Text)
        cmdBascula.Parameters.Add("@StatusBascula", SqlDbType.Char).Value = cboStatusBascula.Text
        cmdBascula.Parameters.Add("@StatusLogistica", SqlDbType.Char).Value = cboStatusLogistica.Text
        cmdBascula.Parameters.Add("@Motivo", SqlDbType.TinyInt).Value = cboMotivo.SelectedValue
        cmdBascula.CommandType = CommandType.StoredProcedure
        Try
            Globales.GetInstance.AbreConexion()
            rdFolio = cmdBascula.ExecuteReader
            If rdFolio.Read Then
                lblFolio.Text = "Folio: " & CStr(rdFolio("Folio"))
                Me.Refresh()
                System.Threading.Thread.Sleep(2)
            End If
            Me.Close()
            Me.DialogResult = DialogResult.OK
        Catch ex As Exception
            Globales.GetInstance.ExMessage(ex)
        Finally
            Globales.GetInstance.CierraConexion()
        End Try
    End Sub
End Class
