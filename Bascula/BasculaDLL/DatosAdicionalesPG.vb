Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared

Public Class frmDatosAdicionalesPG
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New(ByVal AñoAtt As Integer, ByVal Folio As Integer)
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        Me._AñoAtt = AñoAtt
        Me._Folio = Folio
        CargaDestinoOrigenTransporte()
        CargaProducto()
        CargaTipoVehiculo()
        CargaTransportadoras()
    End Sub

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
    Friend WithEvents rgrpTransportadore As Bascula.RoundedGroupBox
    Friend WithEvents lblTransportadora As System.Windows.Forms.Label
    Friend WithEvents lblTipoVehiculo As System.Windows.Forms.Label
    Friend WithEvents lblProducto As System.Windows.Forms.Label
    Friend WithEvents lblOrigen As System.Windows.Forms.Label
    Friend WithEvents lblDestino As System.Windows.Forms.Label
    Friend WithEvents cboTransportadora As System.Windows.Forms.ComboBox
    Friend WithEvents cboTipoVehiculo As System.Windows.Forms.ComboBox
    Friend WithEvents cboProducto As System.Windows.Forms.ComboBox
    Friend WithEvents cboOrigen As System.Windows.Forms.ComboBox
    Friend WithEvents cboDestino As System.Windows.Forms.ComboBox
    Friend WithEvents Figure1 As Bascula.Figure
    Friend WithEvents rgrpTrafico As Bascula.RoundedGroupBox
    Friend WithEvents lblNumero As System.Windows.Forms.Label
    Friend WithEvents lblFecha As System.Windows.Forms.Label
    Friend WithEvents lblLitros As System.Windows.Forms.Label
    Friend WithEvents lblKilogramos As System.Windows.Forms.Label
    Friend WithEvents txtNumero As System.Windows.Forms.TextBox
    Friend WithEvents txtKilogramos As System.Windows.Forms.TextBox
    Friend WithEvents txtLitros As System.Windows.Forms.TextBox
    Friend WithEvents btnAceptar As System.Windows.Forms.Button
    Friend WithEvents dtpFecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblChofer As System.Windows.Forms.Label
    Friend WithEvents txtChofer As System.Windows.Forms.TextBox
    Friend WithEvents crvReporte As CrystalDecisions.Windows.Forms.CrystalReportViewer
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmDatosAdicionalesPG))
        Me.rgrpTransportadore = New Bascula.RoundedGroupBox()
        Me.lblChofer = New System.Windows.Forms.Label()
        Me.cboDestino = New System.Windows.Forms.ComboBox()
        Me.cboOrigen = New System.Windows.Forms.ComboBox()
        Me.cboProducto = New System.Windows.Forms.ComboBox()
        Me.cboTipoVehiculo = New System.Windows.Forms.ComboBox()
        Me.cboTransportadora = New System.Windows.Forms.ComboBox()
        Me.lblDestino = New System.Windows.Forms.Label()
        Me.lblOrigen = New System.Windows.Forms.Label()
        Me.lblProducto = New System.Windows.Forms.Label()
        Me.lblTipoVehiculo = New System.Windows.Forms.Label()
        Me.lblTransportadora = New System.Windows.Forms.Label()
        Me.txtChofer = New System.Windows.Forms.TextBox()
        Me.Figure1 = New Bascula.Figure()
        Me.rgrpTrafico = New Bascula.RoundedGroupBox()
        Me.dtpFecha = New System.Windows.Forms.DateTimePicker()
        Me.txtLitros = New System.Windows.Forms.TextBox()
        Me.txtKilogramos = New System.Windows.Forms.TextBox()
        Me.txtNumero = New System.Windows.Forms.TextBox()
        Me.lblLitros = New System.Windows.Forms.Label()
        Me.lblKilogramos = New System.Windows.Forms.Label()
        Me.lblFecha = New System.Windows.Forms.Label()
        Me.lblNumero = New System.Windows.Forms.Label()
        Me.btnAceptar = New System.Windows.Forms.Button()
        Me.crvReporte = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
        Me.rgrpTransportadore.SuspendLayout()
        Me.rgrpTrafico.SuspendLayout()
        Me.SuspendLayout()
        '
        'rgrpTransportadore
        '
        Me.rgrpTransportadore.BorderColor = System.Drawing.Color.Brown
        Me.rgrpTransportadore.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblChofer, Me.cboDestino, Me.cboOrigen, Me.cboProducto, Me.cboTipoVehiculo, Me.cboTransportadora, Me.lblDestino, Me.lblOrigen, Me.lblProducto, Me.lblTipoVehiculo, Me.lblTransportadora, Me.txtChofer})
        Me.rgrpTransportadore.Dock = System.Windows.Forms.DockStyle.Top
        Me.rgrpTransportadore.FlatStyle = Bascula.RoundedGroupBox.Style.Pipe
        Me.rgrpTransportadore.ForeColor = System.Drawing.Color.DarkRed
        Me.rgrpTransportadore.Location = New System.Drawing.Point(5, 5)
        Me.rgrpTransportadore.Name = "rgrpTransportadore"
        Me.rgrpTransportadore.Size = New System.Drawing.Size(464, 275)
        Me.rgrpTransportadore.TabIndex = 0
        Me.rgrpTransportadore.TabStop = False
        Me.rgrpTransportadore.Text = "Transportadora"
        Me.rgrpTransportadore.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left
        '
        'lblChofer
        '
        Me.lblChofer.AutoSize = True
        Me.lblChofer.ForeColor = System.Drawing.Color.Black
        Me.lblChofer.Location = New System.Drawing.Point(16, 232)
        Me.lblChofer.Name = "lblChofer"
        Me.lblChofer.Size = New System.Drawing.Size(60, 20)
        Me.lblChofer.TabIndex = 10
        Me.lblChofer.Text = "&Chofer:"
        '
        'cboDestino
        '
        Me.cboDestino.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboDestino.Location = New System.Drawing.Point(141, 192)
        Me.cboDestino.Name = "cboDestino"
        Me.cboDestino.Size = New System.Drawing.Size(304, 27)
        Me.cboDestino.TabIndex = 9
        '
        'cboOrigen
        '
        Me.cboOrigen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboOrigen.Location = New System.Drawing.Point(141, 152)
        Me.cboOrigen.Name = "cboOrigen"
        Me.cboOrigen.Size = New System.Drawing.Size(304, 27)
        Me.cboOrigen.TabIndex = 7
        '
        'cboProducto
        '
        Me.cboProducto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboProducto.Location = New System.Drawing.Point(141, 112)
        Me.cboProducto.Name = "cboProducto"
        Me.cboProducto.Size = New System.Drawing.Size(304, 27)
        Me.cboProducto.TabIndex = 5
        '
        'cboTipoVehiculo
        '
        Me.cboTipoVehiculo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTipoVehiculo.Location = New System.Drawing.Point(141, 72)
        Me.cboTipoVehiculo.Name = "cboTipoVehiculo"
        Me.cboTipoVehiculo.Size = New System.Drawing.Size(304, 27)
        Me.cboTipoVehiculo.TabIndex = 3
        '
        'cboTransportadora
        '
        Me.cboTransportadora.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTransportadora.Location = New System.Drawing.Point(141, 32)
        Me.cboTransportadora.Name = "cboTransportadora"
        Me.cboTransportadora.Size = New System.Drawing.Size(304, 27)
        Me.cboTransportadora.TabIndex = 1
        '
        'lblDestino
        '
        Me.lblDestino.AutoSize = True
        Me.lblDestino.ForeColor = System.Drawing.Color.Black
        Me.lblDestino.Location = New System.Drawing.Point(16, 195)
        Me.lblDestino.Name = "lblDestino"
        Me.lblDestino.Size = New System.Drawing.Size(66, 20)
        Me.lblDestino.TabIndex = 8
        Me.lblDestino.Text = "&Destino:"
        '
        'lblOrigen
        '
        Me.lblOrigen.AutoSize = True
        Me.lblOrigen.ForeColor = System.Drawing.Color.Black
        Me.lblOrigen.Location = New System.Drawing.Point(16, 155)
        Me.lblOrigen.Name = "lblOrigen"
        Me.lblOrigen.Size = New System.Drawing.Size(60, 20)
        Me.lblOrigen.TabIndex = 6
        Me.lblOrigen.Text = "&Origen:"
        '
        'lblProducto
        '
        Me.lblProducto.AutoSize = True
        Me.lblProducto.ForeColor = System.Drawing.Color.Black
        Me.lblProducto.Location = New System.Drawing.Point(16, 115)
        Me.lblProducto.Name = "lblProducto"
        Me.lblProducto.Size = New System.Drawing.Size(76, 20)
        Me.lblProducto.TabIndex = 4
        Me.lblProducto.Text = "&Producto:"
        '
        'lblTipoVehiculo
        '
        Me.lblTipoVehiculo.AutoSize = True
        Me.lblTipoVehiculo.ForeColor = System.Drawing.Color.Black
        Me.lblTipoVehiculo.Location = New System.Drawing.Point(16, 75)
        Me.lblTipoVehiculo.Name = "lblTipoVehiculo"
        Me.lblTipoVehiculo.Size = New System.Drawing.Size(108, 20)
        Me.lblTipoVehiculo.TabIndex = 2
        Me.lblTipoVehiculo.Text = "Tipo &vehículo:"
        '
        'lblTransportadora
        '
        Me.lblTransportadora.AutoSize = True
        Me.lblTransportadora.ForeColor = System.Drawing.Color.Black
        Me.lblTransportadora.Location = New System.Drawing.Point(16, 35)
        Me.lblTransportadora.Name = "lblTransportadora"
        Me.lblTransportadora.Size = New System.Drawing.Size(123, 20)
        Me.lblTransportadora.TabIndex = 0
        Me.lblTransportadora.Text = "&Transportadora:"
        '
        'txtChofer
        '
        Me.txtChofer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtChofer.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtChofer.Location = New System.Drawing.Point(141, 232)
        Me.txtChofer.Name = "txtChofer"
        Me.txtChofer.Size = New System.Drawing.Size(304, 27)
        Me.txtChofer.TabIndex = 11
        Me.txtChofer.Text = ""
        '
        'Figure1
        '
        Me.Figure1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Figure1.FillColor = System.Drawing.Color.LightSteelBlue
        Me.Figure1.LineColor = System.Drawing.Color.Gainsboro
        Me.Figure1.LineWidth = 2.0!
        Me.Figure1.Location = New System.Drawing.Point(5, 280)
        Me.Figure1.Name = "Figure1"
        Me.Figure1.Size = New System.Drawing.Size(464, 24)
        Me.Figure1.Style = Bascula.Figure.FigureStyle.Line
        Me.Figure1.TabIndex = 1
        '
        'rgrpTrafico
        '
        Me.rgrpTrafico.BorderColor = System.Drawing.Color.Green
        Me.rgrpTrafico.Controls.AddRange(New System.Windows.Forms.Control() {Me.dtpFecha, Me.txtLitros, Me.txtKilogramos, Me.txtNumero, Me.lblLitros, Me.lblKilogramos, Me.lblFecha, Me.lblNumero})
        Me.rgrpTrafico.Dock = System.Windows.Forms.DockStyle.Top
        Me.rgrpTrafico.FlatStyle = Bascula.RoundedGroupBox.Style.Pipe
        Me.rgrpTrafico.ForeColor = System.Drawing.Color.DarkGreen
        Me.rgrpTrafico.Location = New System.Drawing.Point(5, 304)
        Me.rgrpTrafico.Name = "rgrpTrafico"
        Me.rgrpTrafico.Size = New System.Drawing.Size(464, 120)
        Me.rgrpTrafico.TabIndex = 1
        Me.rgrpTrafico.TabStop = False
        Me.rgrpTrafico.Text = "Tráfico"
        Me.rgrpTrafico.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left
        '
        'dtpFecha
        '
        Me.dtpFecha.CustomFormat = "dd/MM/yyyy HH:mm tt"
        Me.dtpFecha.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpFecha.Location = New System.Drawing.Point(280, 31)
        Me.dtpFecha.Name = "dtpFecha"
        Me.dtpFecha.Size = New System.Drawing.Size(160, 24)
        Me.dtpFecha.TabIndex = 3
        '
        'txtLitros
        '
        Me.txtLitros.BackColor = System.Drawing.SystemColors.Window
        Me.txtLitros.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtLitros.Location = New System.Drawing.Point(280, 72)
        Me.txtLitros.Name = "txtLitros"
        Me.txtLitros.Size = New System.Drawing.Size(160, 27)
        Me.txtLitros.TabIndex = 6
        Me.txtLitros.Text = "0"
        Me.txtLitros.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtKilogramos
        '
        Me.txtKilogramos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtKilogramos.Location = New System.Drawing.Point(88, 72)
        Me.txtKilogramos.Name = "txtKilogramos"
        Me.txtKilogramos.Size = New System.Drawing.Size(104, 27)
        Me.txtKilogramos.TabIndex = 5
        Me.txtKilogramos.Text = "0"
        Me.txtKilogramos.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtNumero
        '
        Me.txtNumero.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtNumero.Location = New System.Drawing.Point(88, 31)
        Me.txtNumero.Name = "txtNumero"
        Me.txtNumero.Size = New System.Drawing.Size(104, 27)
        Me.txtNumero.TabIndex = 1
        Me.txtNumero.Text = "0"
        Me.txtNumero.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblLitros
        '
        Me.lblLitros.AutoSize = True
        Me.lblLitros.ForeColor = System.Drawing.Color.Black
        Me.lblLitros.Location = New System.Drawing.Point(216, 75)
        Me.lblLitros.Name = "lblLitros"
        Me.lblLitros.Size = New System.Drawing.Size(51, 20)
        Me.lblLitros.TabIndex = 6
        Me.lblLitros.Text = "&Litros:"
        '
        'lblKilogramos
        '
        Me.lblKilogramos.AutoSize = True
        Me.lblKilogramos.ForeColor = System.Drawing.Color.Black
        Me.lblKilogramos.Location = New System.Drawing.Point(16, 75)
        Me.lblKilogramos.Name = "lblKilogramos"
        Me.lblKilogramos.Size = New System.Drawing.Size(38, 20)
        Me.lblKilogramos.TabIndex = 4
        Me.lblKilogramos.Text = "&Kgs:"
        '
        'lblFecha
        '
        Me.lblFecha.AutoSize = True
        Me.lblFecha.ForeColor = System.Drawing.Color.Black
        Me.lblFecha.Location = New System.Drawing.Point(216, 34)
        Me.lblFecha.Name = "lblFecha"
        Me.lblFecha.Size = New System.Drawing.Size(54, 20)
        Me.lblFecha.TabIndex = 2
        Me.lblFecha.Text = "&Fecha:"
        '
        'lblNumero
        '
        Me.lblNumero.AutoSize = True
        Me.lblNumero.ForeColor = System.Drawing.Color.Black
        Me.lblNumero.Location = New System.Drawing.Point(16, 34)
        Me.lblNumero.Name = "lblNumero"
        Me.lblNumero.Size = New System.Drawing.Size(69, 20)
        Me.lblNumero.TabIndex = 0
        Me.lblNumero.Text = "&Número:"
        '
        'btnAceptar
        '
        Me.btnAceptar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnAceptar.Image = CType(resources.GetObject("btnAceptar.Image"), System.Drawing.Bitmap)
        Me.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAceptar.Location = New System.Drawing.Point(360, 432)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(88, 32)
        Me.btnAceptar.TabIndex = 2
        Me.btnAceptar.Text = "&Aceptar"
        Me.btnAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'crvReporte
        '
        Me.crvReporte.ActiveViewIndex = -1
        Me.crvReporte.Location = New System.Drawing.Point(344, 432)
        Me.crvReporte.Name = "crvReporte"
        Me.crvReporte.ReportSource = Nothing
        Me.crvReporte.Size = New System.Drawing.Size(10, 10)
        Me.crvReporte.TabIndex = 54
        '
        'frmDatosAdicionalesPG
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(8, 20)
        Me.BackColor = System.Drawing.Color.Gainsboro
        Me.ClientSize = New System.Drawing.Size(474, 474)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.crvReporte, Me.btnAceptar, Me.rgrpTrafico, Me.Figure1, Me.rgrpTransportadore})
        Me.DockPadding.All = 5
        Me.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "frmDatosAdicionalesPG"
        Me.ShowInTaskbar = False
        Me.Text = "Datos adicionales del PG"
        Me.rgrpTransportadore.ResumeLayout(False)
        Me.rgrpTrafico.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Variables globales"
    Private _AñoAtt, _Folio As Integer
    Private _DatosGuardados As Boolean
    Private rptReporte As New ReportDocument()
    Private _TablaReporte As Table
    Private _LogonInfo As TableLogOnInfo
#End Region

#Region "Carga de catálogos"
    Private Sub CargaTransportadoras()
        Dim daBascula As New SqlDataAdapter("Select Transportadora, Descripcion from Transportadora order by Descripcion", Globales.GetInstance.cnSigamet)
        Dim dtTransportadora As New DataTable()
        Try
            daBascula.Fill(dtTransportadora)
            cboTransportadora.ValueMember = "Transportadora"
            cboTransportadora.DisplayMember = "Descripcion"
            cboTransportadora.DataSource = dtTransportadora
            cboTransportadora.SelectedValue = 1
        Catch ex As SqlException
            Globales.GetInstance.ExMessage(ex)
        Catch ex As Exception
            Globales.GetInstance.ExMessage(ex)
        End Try
    End Sub
    Private Sub CargaTipoVehiculo()
        Dim daBascula As New SqlDataAdapter("Select TipoVehiculo, Descripcion from TipoVehiculo order by Descripcion", Globales.GetInstance.cnSigamet)
        Dim dtTipoVehiculo As New DataTable()
        Try
            daBascula.Fill(dtTipoVehiculo)
            cboTipoVehiculo.ValueMember = "TipoVehiculo"
            cboTipoVehiculo.DisplayMember = "Descripcion"
            cboTipoVehiculo.DataSource = dtTipoVehiculo
            cboTipoVehiculo.SelectedValue = 5
        Catch ex As SqlException
            Globales.GetInstance.ExMessage(ex)
        Catch ex As Exception
            Globales.GetInstance.ExMessage(ex)
        End Try
    End Sub
    Private Sub CargaProducto()
        Dim daBascula As New SqlDataAdapter("select TipoProducto, Descripcion from TipoProducto order by Descripcion", Globales.GetInstance.cnSigamet)
        Dim dtProducto As New DataTable()
        Try
            daBascula.Fill(dtProducto)
            cboProducto.ValueMember = "TipoProducto"
            cboProducto.DisplayMember = "Descripcion"
            cboProducto.DataSource = dtProducto
            cboProducto.SelectedValue = 1
        Catch ex As SqlException
            Globales.GetInstance.ExMessage(ex)
        Catch ex As Exception
            Globales.GetInstance.ExMessage(ex)
        End Try
    End Sub
    Private Sub CargaDestinoOrigenTransporte()
        Dim daBascula As New SqlDataAdapter("select DestinoTransporte, Descripcion from DestinoTransporte order by Descripcion", Globales.GetInstance.cnSigamet)
        Dim dtOrigen As New DataTable()
        Dim dtDestino As New DataTable()
        Try
            daBascula.Fill(dtOrigen)
            daBascula.Fill(dtDestino)


            cboDestino.ValueMember = "DestinoTransporte"
            cboDestino.DisplayMember = "Descripcion"
            cboDestino.DataSource = dtDestino
            cboDestino.SelectedValue = 0

            cboOrigen.ValueMember = "DestinoTransporte"
            cboOrigen.DisplayMember = "Descripcion"
            cboOrigen.DataSource = dtOrigen
            cboOrigen.SelectedValue = 0
        Catch ex As SqlException
            Globales.GetInstance.ExMessage(ex)
        Catch ex As Exception
            Globales.GetInstance.ExMessage(ex)
        End Try
    End Sub
#End Region

#Region "Manejo de cajas de texto"
    Private Sub TextBox_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtNumero.Enter, txtKilogramos.Enter, txtChofer.Enter, txtLitros.Enter
        CType(sender, TextBox).BackColor = Color.LemonChiffon
        CType(sender, TextBox).SelectAll()
    End Sub
    Private Sub TextBox_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtNumero.Leave, txtKilogramos.Leave, txtChofer.Leave, txtLitros.Leave
        CType(sender, TextBox).BackColor = Color.White
    End Sub
    Private Sub TextBoxInteger_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNumero.KeyPress
        ''If Not (e.KeyChar.IsDigit(e.KeyChar) OrElse e.KeyChar.IsControl(e.KeyChar) OrElse Asc(e.KeyChar) = 8) Then
        If Not (Char.IsDigit(e.KeyChar) OrElse Char.IsControl(e.KeyChar) OrElse Asc(e.KeyChar) = 8) Then
            e.Handled = True
        Else
            e.Handled = False
        End If
    End Sub
    Private Sub TextBoxParametrezado_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtKilogramos.KeyPress, txtLitros.KeyPress
        If Globales.GetInstance._TipoDato Then
            ''If Not (e.KeyChar.IsDigit(e.KeyChar) OrElse e.KeyChar.IsControl(e.KeyChar) OrElse Asc(e.KeyChar) = 8 OrElse _
            If Not (Char.IsDigit(e.KeyChar) OrElse Char.IsDigit(e.KeyChar) OrElse Asc(e.KeyChar) = 8 OrElse _
                (e.KeyChar = CChar(".") AndAlso CType(sender, TextBox).Text.IndexOf(".") < 0)) Then
                e.Handled = True
            Else
                e.Handled = False
            End If
        Else
            ''If Not (e.KeyChar.IsDigit(e.KeyChar) OrElse e.KeyChar.IsControl(e.KeyChar) OrElse Asc(e.KeyChar) = 8) Then
            If Not (Char.IsDigit(e.KeyChar) OrElse Char.IsDigit(e.KeyChar) OrElse Asc(e.KeyChar) = 8) Then
                e.Handled = True
            Else
                e.Handled = False
            End If
        End If
    End Sub
    Private Sub TextBox_EnterPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtChofer.KeyPress, txtNumero.KeyPress, txtKilogramos.KeyPress, _
                        cboTransportadora.KeyPress, cboTipoVehiculo.KeyPress, cboProducto.KeyPress, cboOrigen.KeyPress, cboDestino.KeyPress, dtpFecha.KeyPress, txtLitros.KeyPress
        If Asc(e.KeyChar) = 13 Then
            Dim ctrl As Control
            ctrl = CType(sender, Control)
            If ctrl Is txtKilogramos Then
                btnAceptar_Click(btnAceptar, New System.EventArgs())
            Else
                While ctrl Is CType(sender, Control) OrElse Not ctrl.TabStop OrElse ctrl.Enabled = False
                    ctrl = Me.GetNextControl(ctrl, True)
                End While
                ctrl.Focus()
            End If
        End If
    End Sub
#End Region

#Region "Validadcion de cajas de texto"
    Private Function Valida(ByVal Cadena As String) As String
        Cadena = Cadena.Trim
        If Cadena.Length > 0 Then
            Return Cadena
        Else
            Return "0"
        End If
    End Function


    Private Function ValidaDatos() As Boolean
        If txtKilogramos.Text.Trim().Length > 0 Then
            If CDec(CStr(txtKilogramos.Text.Trim())) >= 0 And CDec(CStr(txtKilogramos.Text.Trim())) <= Globales.GetInstance._PesoMaximoPemex Then
                Return True
            Else
                MessageBox.Show("El valor del campo kilogramos no puede superar los " + CStr(Globales.GetInstance._PesoMaximoPemex).Trim() + " kls.  Por favor corrija el dato e intente de nuevo.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Return False
            End If
        Else
            Return False
        End If
    End Function
#End Region

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        If ValidaDatos() Then
            Dim cmdBascula As New SqlCommand("spBASDatosAdicionalesPG", Globales.GetInstance.cnSigamet)
            cmdBascula.CommandType = CommandType.StoredProcedure
            cmdBascula.Parameters.Add("@AñoAtt", SqlDbType.Int).Value = _AñoAtt
            cmdBascula.Parameters.Add("@Folio", SqlDbType.Int).Value = _Folio
            cmdBascula.Parameters.Add("@Transportadora", SqlDbType.Int).Value = cboTransportadora.SelectedValue
            cmdBascula.Parameters.Add("@TipoVehiculo", SqlDbType.Int).Value = cboTipoVehiculo.SelectedValue
            cmdBascula.Parameters.Add("@TipoProducto", SqlDbType.Int).Value = cboProducto.SelectedValue
            cmdBascula.Parameters.Add("@Origen", SqlDbType.Int).Value = cboOrigen.SelectedValue
            cmdBascula.Parameters.Add("@Destino", SqlDbType.Int).Value = cboDestino.SelectedValue
            cmdBascula.Parameters.Add("@NumeroTrafico", SqlDbType.Int).Value = CType(Valida(txtNumero.Text), Integer)
            cmdBascula.Parameters.Add("@KilosTrafico", SqlDbType.Decimal).Value = CType(Valida(txtKilogramos.Text), Decimal)
            cmdBascula.Parameters.Add("@LitrosTrafico", SqlDbType.Decimal).Value = CType(Valida(txtLitros.Text), Decimal)
            cmdBascula.Parameters.Add("@FTrafico", SqlDbType.DateTime).Value = dtpFecha.Value
            cmdBascula.Parameters.Add("@Chofer", SqlDbType.VarChar).Value = txtChofer.Text.Trim
            Try
                Globales.GetInstance.AbreConexion()
                cmdBascula.ExecuteNonQuery()
                _DatosGuardados = True
                ImprimirComprobantePG(Me._AñoAtt, Me._Folio)
                Me.Close()
                Me.Dispose()
            Catch ex As SqlException
                Globales.GetInstance.ExMessage(ex)
            Catch ex As Exception
                Globales.GetInstance.ExMessage(ex)
            Finally
                Globales.GetInstance.CierraConexion()
            End Try
        End If
    End Sub

    Private Sub frmDatosAdicionalesPG_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        e.Cancel = Not _DatosGuardados
    End Sub

#Region "Rutinas de impresión de reportes"
    Private Sub ImprimirComprobantePG(ByVal Año As Integer, ByVal Folio As Integer)
        Dim crParameterFieldDefinitions As ParameterFieldDefinitions
        Dim crParameterFieldDefinition As ParameterFieldDefinition
        Dim crParametervalues As CrystalDecisions.Shared.ParameterValues
        Dim crParameterDiscretValue As CrystalDecisions.Shared.ParameterDiscreteValue
        Cursor = Cursors.WaitCursor
        crvReporte.ReportSource = Nothing
        Try
            rptReporte.Load(Globales.GetInstance._RutaReportes & "\rptCierraCicloTrailers.rpt")
            ConexionReporte()
            crParameterFieldDefinitions = rptReporte.DataDefinition.ParameterFields

            crParameterFieldDefinition = crParameterFieldDefinitions.Item("@AñoAtt")
            crParametervalues = crParameterFieldDefinition.CurrentValues
            crParameterDiscretValue = New ParameterDiscreteValue()
            crParameterDiscretValue.Value = Año
            crParametervalues.Add(crParameterDiscretValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParametervalues)

            crParameterFieldDefinition = crParameterFieldDefinitions.Item("@Folio")
            crParametervalues = crParameterFieldDefinition.CurrentValues
            crParameterDiscretValue = New ParameterDiscreteValue()
            crParameterDiscretValue.Value = Folio
            crParametervalues.Add(crParameterDiscretValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParametervalues)

            crvReporte.ReportSource = rptReporte
            crvReporte.PrintReport()

            rptReporte.Close()
            rptReporte.Dispose()
            rptReporte = New ReportDocument()

        Catch ex As LoadSaveReportException
            Globales.GetInstance.ExMessage(ex)
        Catch ex As Exception
            Globales.GetInstance.ExMessage(ex)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub
    Private Sub ConexionReporte()
        Dim UsuarioReporte As String
        Dim PasswordUsuarioReporte As String
        Dim oConfig As SigaMetClasses.cConfig = New SigaMetClasses.cConfig(9, Globales.GetInstance._Corporativo, Globales.GetInstance._Sucursal)
        UsuarioReporte = CStr(oConfig.Parametros("UsuarioReportes")).Trim

        Dim oUsuarioReportes As New SigaMetClasses.cUserInfo()
        oUsuarioReportes.ConsultaDatosUsuarioReportes(UsuarioReporte)
        PasswordUsuarioReporte = oUsuarioReportes.Password

        For Each _TablaReporte In rptReporte.Database.Tables
            _LogonInfo = _TablaReporte.LogOnInfo
            With _LogonInfo.ConnectionInfo
                .ServerName = Globales.GetInstance._Servidor
                .DatabaseName = Globales.GetInstance._Database
                '.UserID = Globales.GetInstance._Usuario
                '.Password = Globales.GetInstance._Password
                .UserID = UsuarioReporte
                .Password = PasswordUsuarioReporte
            End With
            Try
                _TablaReporte.ApplyLogOnInfo(_LogonInfo)

            Catch exArgumentos As ArgumentNullException
                MessageBox.Show("La información de seguridad para este reporte está incompleta.  Por favor intente de nuevo.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Catch ex As Exception
                MessageBox.Show(ex.Message, ex.Source, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        Next
    End Sub
#End Region

    Private Sub txtKilogramos_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtKilogramos.TextChanged
        txtLitros.Text = CType((Val(txtKilogramos.Text) / Globales.GetInstance._FactorDensidadControlMovimientos), Decimal).ToString("N2")
    End Sub

    'Private Sub txtLitros_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtLitros.TextChanged
    '    txtKilogramos.Text = CType((Val(txtLitros.Text) * Globales.GetInstance._FactorDensidadControlMovimientos), Decimal).ToString("N2")
    'End Sub
End Class
