Imports System.Windows.Forms
Imports System.Drawing


Public Class frmResguardo
    Inherits System.Windows.Forms.Form

    Private _dtClienteResguardo As New DataTable("ClienteResguardo")
    Private _FolioAtt As Integer
    Private _AnoAtt As Short
    Private _FechaMovimiento As DateTime
    Private _Almacengas As Integer
    Private _Autotanque As Integer
    Private _CapacidadOperativa As Decimal = 0
    Private _Existencia As Decimal = 0
    Private _Corporativo As Short
    Private _Sucursal As Short
    Private _TipoProducto As Short
    Private _LitrosResguardados As Decimal = 0

    Private DatosClienteCargados As Boolean = False
    Private CelulaCliente As Integer
    Private Producto As Integer

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()
        InicializaTablaResguardo()
        'Add any initialization after the InitializeComponent() call

    End Sub


    ''Public Sub New(ByVal FolioAtt As Integer, ByVal AnoAtt As Short, ByVal FMovimiento As DateTime, ByVal Servidor As String, ByVal BaseDatos As String, ByVal Usuario As String, ByVal Password As String)
    'Public Sub New(ByVal FolioAtt As Integer, ByVal AnoAtt As Short, ByVal FMovimiento As DateTime, ByVal Usuario As String, ByVal Password As String)
    '    MyBase.New()

    '    'This call is required by the Windows Form Designer.
    '    InitializeComponent()

    '    'Add any initialization after the InitializeComponent() call

    '    _FolioAtt = FolioAtt
    '    _AnoAtt = AnoAtt
    '    _FechaMovimiento = FMovimiento

    '    GLOBAL_Usuario = Usuario
    '    GLOBAL_Password = Password

    '    If _dtClienteResguardo.Rows.Count = 0 Then
    '        BuscarCliente()
    '    End If
    'End Sub


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
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents DataGridTableStyle1 As System.Windows.Forms.DataGridTableStyle
    Friend WithEvents btnAceptar As System.Windows.Forms.Button
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents btnAgregar As System.Windows.Forms.Button
    Friend WithEvents btnBorrar As System.Windows.Forms.Button
    Friend WithEvents ielImagenes As System.Windows.Forms.ImageList
    Friend WithEvents lblPorcentajeFinal As System.Windows.Forms.Label
    Friend WithEvents txtCapacidadTanque As SigaMetClasses.Controles.txtNumeroEntero
    Friend WithEvents lblPorcentaInicial As System.Windows.Forms.Label
    Friend WithEvents lblCapacidad As System.Windows.Forms.Label
    Friend WithEvents btnBuscar As System.Windows.Forms.Button
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents lblLitros As System.Windows.Forms.Label
    Friend WithEvents ProductoPanel As PortatilClasses.CrearControl.ProductoPanel
    Friend WithEvents txtCliente As SigaMetClasses.Controles.txtNumeroEntero
    Friend WithEvents lblRuta As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents lblEmpresa As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dtpFMovimiento As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblCliente As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents dtpFResguardo As System.Windows.Forms.DateTimePicker
    Friend WithEvents grdResguardo As System.Windows.Forms.DataGrid
    Friend WithEvents col1 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents col2 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents col3 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents col4 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents col5 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents col6 As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents txtPorcentajeInicial As SigaMetClasses.Controles.txtNumeroDecimal
    Friend WithEvents txtPorcentajeFinal As SigaMetClasses.Controles.txtNumeroDecimal
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmResguardo))
        Me.grdResguardo = New System.Windows.Forms.DataGrid()
        Me.DataGridTableStyle1 = New System.Windows.Forms.DataGridTableStyle()
        Me.col1 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.col2 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.col3 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.col4 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.col5 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.col6 = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.txtPorcentajeFinal = New SigaMetClasses.Controles.txtNumeroDecimal()
        Me.txtPorcentajeInicial = New SigaMetClasses.Controles.txtNumeroDecimal()
        Me.lblPorcentajeFinal = New System.Windows.Forms.Label()
        Me.txtCapacidadTanque = New SigaMetClasses.Controles.txtNumeroEntero()
        Me.lblPorcentaInicial = New System.Windows.Forms.Label()
        Me.lblCapacidad = New System.Windows.Forms.Label()
        Me.btnBuscar = New System.Windows.Forms.Button()
        Me.ielImagenes = New System.Windows.Forms.ImageList(Me.components)
        Me.Label10 = New System.Windows.Forms.Label()
        Me.lblLitros = New System.Windows.Forms.Label()
        Me.ProductoPanel = New PortatilClasses.CrearControl.ProductoPanel(Me.components)
        Me.txtCliente = New SigaMetClasses.Controles.txtNumeroEntero()
        Me.lblRuta = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.lblEmpresa = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dtpFMovimiento = New System.Windows.Forms.DateTimePicker()
        Me.lblCliente = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.dtpFResguardo = New System.Windows.Forms.DateTimePicker()
        Me.btnAceptar = New System.Windows.Forms.Button()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.btnAgregar = New System.Windows.Forms.Button()
        Me.btnBorrar = New System.Windows.Forms.Button()
        CType(Me.grdResguardo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'grdResguardo
        '
        Me.grdResguardo.AccessibleName = ""
        Me.grdResguardo.Anchor = (((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right)
        Me.grdResguardo.BackgroundColor = System.Drawing.Color.Gainsboro
        Me.grdResguardo.CaptionBackColor = System.Drawing.Color.RoyalBlue
        Me.grdResguardo.CaptionText = "Detalle de mediciones"
        Me.grdResguardo.DataMember = ""
        Me.grdResguardo.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grdResguardo.HeaderFont = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grdResguardo.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.grdResguardo.Location = New System.Drawing.Point(16, 452)
        Me.grdResguardo.Name = "grdResguardo"
        Me.grdResguardo.ReadOnly = True
        Me.grdResguardo.Size = New System.Drawing.Size(520, 118)
        Me.grdResguardo.TabIndex = 112
        Me.grdResguardo.TableStyles.AddRange(New System.Windows.Forms.DataGridTableStyle() {Me.DataGridTableStyle1})
        '
        'DataGridTableStyle1
        '
        Me.DataGridTableStyle1.DataGrid = Me.grdResguardo
        Me.DataGridTableStyle1.GridColumnStyles.AddRange(New System.Windows.Forms.DataGridColumnStyle() {Me.col1, Me.col2, Me.col3, Me.col4, Me.col5, Me.col6})
        Me.DataGridTableStyle1.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.DataGridTableStyle1.MappingName = "ClienteResguardo"
        '
        'col1
        '
        Me.col1.Format = ""
        Me.col1.FormatInfo = Nothing
        Me.col1.HeaderText = "Cliente"
        Me.col1.MappingName = "Cliente"
        Me.col1.Width = 70
        '
        'col2
        '
        Me.col2.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.col2.Format = "N0"
        Me.col2.FormatInfo = Nothing
        Me.col2.HeaderText = "Cap. tanque"
        Me.col2.MappingName = "CapacidadTanque"
        Me.col2.Width = 70
        '
        'col3
        '
        Me.col3.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.col3.Format = "N1"
        Me.col3.FormatInfo = Nothing
        Me.col3.HeaderText = "% Inicial"
        Me.col3.MappingName = "PorcentajeInicial"
        Me.col3.Width = 50
        '
        'col4
        '
        Me.col4.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.col4.Format = "N1"
        Me.col4.FormatInfo = Nothing
        Me.col4.HeaderText = "% Final"
        Me.col4.MappingName = "PorcentajeFinal"
        Me.col4.Width = 50
        '
        'col5
        '
        Me.col5.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.col5.Format = "N2"
        Me.col5.FormatInfo = Nothing
        Me.col5.HeaderText = "Litros"
        Me.col5.MappingName = "Litros"
        Me.col5.Width = 90
        '
        'col6
        '
        Me.col6.Format = ""
        Me.col6.FormatInfo = Nothing
        Me.col6.HeaderText = "Fecha resguardo"
        Me.col6.MappingName = "FResguardo"
        Me.col6.Width = 120
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.AddRange(New System.Windows.Forms.Control() {Me.txtPorcentajeFinal, Me.txtPorcentajeInicial, Me.lblPorcentajeFinal, Me.txtCapacidadTanque, Me.lblPorcentaInicial, Me.lblCapacidad, Me.btnBuscar, Me.Label10, Me.lblLitros, Me.ProductoPanel, Me.txtCliente, Me.lblRuta, Me.Label12, Me.Label6, Me.Label5, Me.lblEmpresa, Me.Label1, Me.dtpFMovimiento, Me.lblCliente, Me.Label3, Me.Label7, Me.dtpFResguardo})
        Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.ForeColor = System.Drawing.Color.DarkBlue
        Me.GroupBox2.Location = New System.Drawing.Point(16, 8)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(520, 400)
        Me.GroupBox2.TabIndex = 103
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Datos del cliente"
        '
        'txtPorcentajeFinal
        '
        Me.txtPorcentajeFinal.AutoSize = False
        Me.txtPorcentajeFinal.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.txtPorcentajeFinal.Location = New System.Drawing.Point(145, 191)
        Me.txtPorcentajeFinal.Name = "txtPorcentajeFinal"
        Me.txtPorcentajeFinal.Size = New System.Drawing.Size(216, 21)
        Me.txtPorcentajeFinal.TabIndex = 4
        Me.txtPorcentajeFinal.Text = ""
        '
        'txtPorcentajeInicial
        '
        Me.txtPorcentajeInicial.AutoSize = False
        Me.txtPorcentajeInicial.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.txtPorcentajeInicial.Location = New System.Drawing.Point(145, 163)
        Me.txtPorcentajeInicial.MaxLength = 4
        Me.txtPorcentajeInicial.Name = "txtPorcentajeInicial"
        Me.txtPorcentajeInicial.Size = New System.Drawing.Size(216, 21)
        Me.txtPorcentajeInicial.TabIndex = 3
        Me.txtPorcentajeInicial.Text = ""
        '
        'lblPorcentajeFinal
        '
        Me.lblPorcentajeFinal.AutoSize = True
        Me.lblPorcentajeFinal.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.lblPorcentajeFinal.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblPorcentajeFinal.Location = New System.Drawing.Point(30, 195)
        Me.lblPorcentajeFinal.Name = "lblPorcentajeFinal"
        Me.lblPorcentajeFinal.Size = New System.Drawing.Size(95, 13)
        Me.lblPorcentajeFinal.TabIndex = 88
        Me.lblPorcentajeFinal.Text = "Porcentaje final:"
        '
        'txtCapacidadTanque
        '
        Me.txtCapacidadTanque.AutoSize = False
        Me.txtCapacidadTanque.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.txtCapacidadTanque.Location = New System.Drawing.Point(145, 135)
        Me.txtCapacidadTanque.MaxLength = 5
        Me.txtCapacidadTanque.Name = "txtCapacidadTanque"
        Me.txtCapacidadTanque.Size = New System.Drawing.Size(216, 21)
        Me.txtCapacidadTanque.TabIndex = 2
        Me.txtCapacidadTanque.Text = ""
        '
        'lblPorcentaInicial
        '
        Me.lblPorcentaInicial.AutoSize = True
        Me.lblPorcentaInicial.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.lblPorcentaInicial.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblPorcentaInicial.Location = New System.Drawing.Point(31, 167)
        Me.lblPorcentaInicial.Name = "lblPorcentaInicial"
        Me.lblPorcentaInicial.TabIndex = 87
        Me.lblPorcentaInicial.Text = "Porcentaje incial:"
        '
        'lblCapacidad
        '
        Me.lblCapacidad.AutoSize = True
        Me.lblCapacidad.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.lblCapacidad.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblCapacidad.Location = New System.Drawing.Point(31, 139)
        Me.lblCapacidad.Name = "lblCapacidad"
        Me.lblCapacidad.Size = New System.Drawing.Size(107, 13)
        Me.lblCapacidad.TabIndex = 86
        Me.lblCapacidad.Text = "Capacidad tanque:"
        '
        'btnBuscar
        '
        Me.btnBuscar.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
        Me.btnBuscar.BackColor = System.Drawing.SystemColors.Control
        Me.btnBuscar.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBuscar.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnBuscar.Image = CType(resources.GetObject("btnBuscar.Image"), System.Drawing.Bitmap)
        Me.btnBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnBuscar.ImageIndex = 5
        Me.btnBuscar.ImageList = Me.ielImagenes
        Me.btnBuscar.Location = New System.Drawing.Point(421, 21)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.TabIndex = 120
        Me.btnBuscar.TabStop = False
        Me.btnBuscar.Text = "&Buscar"
        Me.btnBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'ielImagenes
        '
        Me.ielImagenes.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit
        Me.ielImagenes.ImageSize = New System.Drawing.Size(16, 16)
        Me.ielImagenes.ImageStream = CType(resources.GetObject("ielImagenes.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ielImagenes.TransparentColor = System.Drawing.Color.Transparent
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.Label10.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label10.Location = New System.Drawing.Point(240, 371)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(132, 14)
        Me.Label10.TabIndex = 84
        Me.Label10.Text = "Total litros resguardados:"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblLitros
        '
        Me.lblLitros.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblLitros.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLitros.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblLitros.Location = New System.Drawing.Point(378, 367)
        Me.lblLitros.Name = "lblLitros"
        Me.lblLitros.Size = New System.Drawing.Size(120, 21)
        Me.lblLitros.TabIndex = 83
        Me.lblLitros.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'ProductoPanel
        '
        Me.ProductoPanel.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ProductoPanel.ForeColor = System.Drawing.SystemColors.ControlText
        Me.ProductoPanel.Location = New System.Drawing.Point(24, 286)
        Me.ProductoPanel.MaxLength = 8
        Me.ProductoPanel.Name = "ProductoPanel"
        Me.ProductoPanel.NumProductos = 0
        Me.ProductoPanel.Size = New System.Drawing.Size(473, 66)
        Me.ProductoPanel.TabIndex = 15
        'Me.ProductoPanel.txtCantidad1
        '
        'txtCliente
        '
        Me.txtCliente.AutoSize = False
        Me.txtCliente.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCliente.Location = New System.Drawing.Point(145, 23)
        Me.txtCliente.Name = "txtCliente"
        Me.txtCliente.Size = New System.Drawing.Size(216, 21)
        Me.txtCliente.TabIndex = 1
        Me.txtCliente.Text = ""
        '
        'lblRuta
        '
        Me.lblRuta.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblRuta.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.lblRuta.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblRuta.Location = New System.Drawing.Point(145, 79)
        Me.lblRuta.Name = "lblRuta"
        Me.lblRuta.Size = New System.Drawing.Size(352, 21)
        Me.lblRuta.TabIndex = 79
        Me.lblRuta.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label12.Location = New System.Drawing.Point(31, 27)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(112, 14)
        Me.Label12.TabIndex = 78
        Me.Label12.Text = "Número de cliente:"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label6.Location = New System.Drawing.Point(31, 225)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(113, 14)
        Me.Label6.TabIndex = 77
        Me.Label6.Text = "Fecha movimiento:"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.Label5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label5.Location = New System.Drawing.Point(31, 109)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(51, 14)
        Me.Label5.TabIndex = 73
        Me.Label5.Text = "Empresa:"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblEmpresa
        '
        Me.lblEmpresa.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblEmpresa.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.lblEmpresa.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblEmpresa.Location = New System.Drawing.Point(145, 107)
        Me.lblEmpresa.Name = "lblEmpresa"
        Me.lblEmpresa.Size = New System.Drawing.Size(352, 21)
        Me.lblEmpresa.TabIndex = 69
        Me.lblEmpresa.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(31, 81)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(31, 14)
        Me.Label1.TabIndex = 67
        Me.Label1.Text = "Ruta:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dtpFMovimiento
        '
        Me.dtpFMovimiento.CustomFormat = "dd/MM/yyyy hh:mm tt"
        Me.dtpFMovimiento.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpFMovimiento.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpFMovimiento.Location = New System.Drawing.Point(145, 221)
        Me.dtpFMovimiento.Name = "dtpFMovimiento"
        Me.dtpFMovimiento.Size = New System.Drawing.Size(216, 21)
        Me.dtpFMovimiento.TabIndex = 5
        '
        'lblCliente
        '
        Me.lblCliente.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblCliente.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCliente.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblCliente.Location = New System.Drawing.Point(145, 51)
        Me.lblCliente.Name = "lblCliente"
        Me.lblCliente.Size = New System.Drawing.Size(352, 21)
        Me.lblCliente.TabIndex = 81
        Me.lblCliente.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 8.25!)
        Me.Label3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label3.Location = New System.Drawing.Point(31, 53)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(42, 14)
        Me.Label3.TabIndex = 80
        Me.Label3.Text = "Cliente:"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label7.Location = New System.Drawing.Point(31, 253)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(103, 14)
        Me.Label7.TabIndex = 82
        Me.Label7.Text = "Fecha resguardo:"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dtpFResguardo
        '
        Me.dtpFResguardo.CustomFormat = ""
        Me.dtpFResguardo.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpFResguardo.Location = New System.Drawing.Point(145, 249)
        Me.dtpFResguardo.Name = "dtpFResguardo"
        Me.dtpFResguardo.Size = New System.Drawing.Size(216, 21)
        Me.dtpFResguardo.TabIndex = 6
        '
        'btnAceptar
        '
        Me.btnAceptar.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAceptar.Image = CType(resources.GetObject("btnAceptar.Image"), System.Drawing.Bitmap)
        Me.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAceptar.ImageIndex = 3
        Me.btnAceptar.ImageList = Me.ielImagenes
        Me.btnAceptar.Location = New System.Drawing.Point(560, 16)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(80, 24)
        Me.btnAceptar.TabIndex = 117
        Me.btnAceptar.Text = "&Aceptar"
        Me.btnAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnCancelar
        '
        Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancelar.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancelar.Image = CType(resources.GetObject("btnCancelar.Image"), System.Drawing.Bitmap)
        Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancelar.ImageIndex = 2
        Me.btnCancelar.ImageList = Me.ielImagenes
        Me.btnCancelar.Location = New System.Drawing.Point(560, 48)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(80, 24)
        Me.btnCancelar.TabIndex = 118
        Me.btnCancelar.Text = "&Cancelar"
        Me.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnAgregar
        '
        Me.btnAgregar.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAgregar.Image = CType(resources.GetObject("btnAgregar.Image"), System.Drawing.Bitmap)
        Me.btnAgregar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAgregar.ImageIndex = 0
        Me.btnAgregar.ImageList = Me.ielImagenes
        Me.btnAgregar.Location = New System.Drawing.Point(160, 418)
        Me.btnAgregar.Name = "btnAgregar"
        Me.btnAgregar.Size = New System.Drawing.Size(80, 24)
        Me.btnAgregar.TabIndex = 109
        Me.btnAgregar.Text = "A&gregar"
        Me.btnAgregar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnBorrar
        '
        Me.btnBorrar.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBorrar.Image = CType(resources.GetObject("btnBorrar.Image"), System.Drawing.Bitmap)
        Me.btnBorrar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnBorrar.ImageIndex = 1
        Me.btnBorrar.ImageList = Me.ielImagenes
        Me.btnBorrar.Location = New System.Drawing.Point(320, 418)
        Me.btnBorrar.Name = "btnBorrar"
        Me.btnBorrar.Size = New System.Drawing.Size(80, 24)
        Me.btnBorrar.TabIndex = 110
        Me.btnBorrar.Text = "&Borrar"
        Me.btnBorrar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'frmResguardo
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(656, 584)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnBorrar, Me.btnAgregar, Me.btnCancelar, Me.btnAceptar, Me.grdResguardo, Me.GroupBox2})
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MaximizeBox = False
        Me.Name = "frmResguardo"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Detalle de clientes"
        CType(Me.grdResguardo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Metodos y Funciones"
    'Inicializa una tabla de uso interno donde se va guardando la informacion de 
    'las mediciones del embarque
    Private Sub InicializaTablaResguardo()
        If _dtClienteResguardo.Columns.Count = 0 Then
            Dim dcColumna As DataColumn
            ''Dim dtRenglon As DataRow
            'Columana 000
            dcColumna = New DataColumn()
            dcColumna.DataType = System.Type.GetType("System.Int32")
            dcColumna.ColumnName = "Cliente"
            _dtClienteResguardo.Columns.Add(dcColumna)
            'Columna 001
            dcColumna = New DataColumn()
            dcColumna.DataType = System.Type.GetType("System.String")
            dcColumna.ColumnName = "Status"
            _dtClienteResguardo.Columns.Add(dcColumna)
            'Columna 002
            dcColumna = New DataColumn()
            dcColumna.DataType = System.Type.GetType("System.Int32")
            dcColumna.ColumnName = "CapacidadTanque"
            _dtClienteResguardo.Columns.Add(dcColumna)
            'Columna 003
            dcColumna = New DataColumn()
            dcColumna.DataType = System.Type.GetType("System.Decimal")
            dcColumna.ColumnName = "PorcentajeInicial"
            _dtClienteResguardo.Columns.Add(dcColumna)
            'Columna 004
            dcColumna = New DataColumn()
            dcColumna.DataType = System.Type.GetType("System.Decimal")
            dcColumna.ColumnName = "PorcentajeFinal"
            _dtClienteResguardo.Columns.Add(dcColumna)
            'Columna 005
            dcColumna = New DataColumn()
            dcColumna.DataType = System.Type.GetType("System.Decimal")
            dcColumna.ColumnName = "Litros"
            _dtClienteResguardo.Columns.Add(dcColumna)
            'Columna 006
            dcColumna = New DataColumn()
            dcColumna.DataType = System.Type.GetType("System.DateTime")
            dcColumna.ColumnName = "FMovimiento"
            _dtClienteResguardo.Columns.Add(dcColumna)
            'Columna 007
            dcColumna = New DataColumn()
            dcColumna.DataType = System.Type.GetType("System.DateTime")
            dcColumna.ColumnName = "FResguardo"
            _dtClienteResguardo.Columns.Add(dcColumna)
        End If
    End Sub


    Function ValidarDatos() As Boolean
        If (_Existencia + _LitrosResguardados + ProductoPanel.SumarKilos) > _CapacidadOperativa Then
            MessageBox.Show("La cantidad de gas que ingresará rebasará la capacidad operativa de la unidad, por favor verifique.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            ActiveControl = ProductoPanel.txtCantidad1
            Return False
        ElseIf Not DatosClienteCargados Then
            'Dim Mensaje As PortatilClasses.Mensaje
            'Mensaje = New PortatilClasses.Mensaje(115)
            MessageBox.Show("No hay datos del cliente.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            ActiveControl = txtCliente
            Return False
        ElseIf txtCapacidadTanque.Text.Length = 0 Then
            'Dim Mensaje As PortatilClasses.Mensaje
            'Mensaje = New PortatilClasses.Mensaje(56)
            MessageBox.Show("Escriba la capacidad del tanque del cliente.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            ActiveControl = txtCapacidadTanque
            Return False
        ElseIf txtPorcentajeInicial.Text.Length = 0 Then
            'Dim Mensaje As PortatilClasses.Mensaje
            'Mensaje = New PortatilClasses.Mensaje(57)
            MessageBox.Show("Escriba el porcentaje del tanque antes de ser retirado el gas.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            ActiveControl = txtPorcentajeInicial
            Return False
        ElseIf CType(txtPorcentajeInicial.Text, Decimal) <= 0 Or CType(txtPorcentajeInicial.Text, Decimal) > 100 Then
            MessageBox.Show("El valor del porcentaje inicial no es correcto.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            ActiveControl = txtPorcentajeInicial
            Return False
        ElseIf txtPorcentajeFinal.Text.Length = 0 Then
            'Dim Mensaje As PortatilClasses.Mensaje
            'Mensaje = New PortatilClasses.Mensaje(57)
            MessageBox.Show("Escriba el porcentaje del tanque después de ser retirado el gas.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            ActiveControl = txtPorcentajeFinal
            Return False
        ElseIf CType(txtPorcentajeFinal.Text, Decimal) < 0 Or CType(txtPorcentajeFinal.Text, Decimal) >= CType(txtPorcentajeInicial.Text, Decimal) Then
            MessageBox.Show("El valor del porcentaje final no es correcto.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            ActiveControl = txtPorcentajeFinal
            Return False
        ElseIf dtpFMovimiento.Value.Date.ToShortDateString() <> _FechaMovimiento.Date.ToShortDateString() Then
            MessageBox.Show("La fecha de movimiento es incorrecta.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            ActiveControl = dtpFMovimiento
            Return False
        ElseIf dtpFResguardo.Value.Date > _FechaMovimiento.Date Then
            MessageBox.Show("La fecha de resguardo es incorrecta.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            ActiveControl = dtpFResguardo
            Return False
        ElseIf ProductoPanel.SumarKilos = 0 Then
            MessageBox.Show("Teclee la cantidad en litros que fueron resguardados.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            ActiveControl = ProductoPanel.txtCantidad1
            ProductoPanel.txtCantidad1.SelectAll()
            Return False
        ElseIf ProductoPanel.SumarKilos > CType(txtCapacidadTanque.Text, Integer) Then
            MessageBox.Show("La cantidad de litros resguardados no puede ser mayor que la capacidad del tanque.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            ActiveControl = ProductoPanel.txtCantidad1
            ProductoPanel.txtCantidad1.SelectAll()
            Return False
        Else
            Return True
        End If
    End Function

    Private Sub CargaGrid()
        'Asignacion de valores a un renglon que se validara y despues
        'se anexara a la tabla _dtMedicionAlmacen
        Dim drow As DataRow
        drow = _dtClienteResguardo.NewRow
        drow(0) = CType(txtCliente.Text, Integer)
        drow(1) = "ACTIVO"
        drow(2) = CType(txtCapacidadTanque.Text, Integer)
        drow(3) = CType(txtPorcentajeInicial.Text, Decimal)
        drow(4) = CType(txtPorcentajeFinal.Text, Decimal)
        drow(5) = ProductoPanel.SumarKilos
        drow(6) = dtpFMovimiento.Value
        drow(7) = dtpFResguardo.Value
        _LitrosResguardados = _LitrosResguardados + ProductoPanel.SumarKilos
        lblLitros.Text = _LitrosResguardados.ToString("N2")
        _dtClienteResguardo.Rows.Add(drow)
        grdResguardo.DataSource = Nothing
        grdResguardo.DataSource = _dtClienteResguardo
    End Sub

    Private Function BuscarAutotanque() As Boolean
        Dim oAutotanqueTurno As New Resguardo.cAutotanqueTurno(_FolioAtt, _AnoAtt)
        oAutotanqueTurno.ConsultarAutotanque()
        _Almacengas = oAutotanqueTurno.AlmacenGas
        _Autotanque = oAutotanqueTurno.Autotanque
        _Corporativo = oAutotanqueTurno.Corporativo
        _TipoProducto = oAutotanqueTurno.TipoProducto
        _CapacidadOperativa = oAutotanqueTurno.CapacidadOperativa
        If _Almacengas = 0 Then
            Return False
        Else
            Return True
        End If
    End Function

    'Public Sub New(ByVal FolioAtt As Integer, ByVal AnoAtt As Short, ByVal FMovimiento As DateTime, ByVal Servidor As String, ByVal BaseDatos As String, ByVal Usuario As String, ByVal Password As String)
    Public Function InicializaForma(ByVal FolioAtt As Integer, ByVal AnoAtt As Short, ByVal FMovimiento As DateTime, ByVal Usuario As String, ByVal Password As String, ByVal Corporativo As Short, ByVal Sucursal As Short) As Boolean
        Dim Result As Boolean
        Cursor = Cursors.WaitCursor
        _FolioAtt = FolioAtt
        _AnoAtt = AnoAtt
        _FechaMovimiento = FMovimiento
        GLOBAL_Usuario = Usuario
        GLOBAL_Password = Password
        GLOBAL_Corporativo = Corporativo
        GLOBAL_Sucursal = Sucursal


        If _dtClienteResguardo.Rows.Count = 0 Then
            Result = BuscarAutotanque()
            ProductoContenedor()
            ProductoPanel.CargarProducto(_Almacengas, _TipoProducto)
            ProductoPanel.CargarExistencias(_Almacengas)

            _Existencia = 0
            Dim i As Integer
            i = 0
            While i < ProductoPanel.lblLista.Count
                If CType(ProductoPanel.lblLista(i), Label).Text.Length > 0 Then
                    _Existencia = _Existencia + CType(CType(ProductoPanel.lblLista(i), Label).Text, Decimal)
                End If
                i = i + 1
            End While


        ElseIf _TipoProducto <> 1 Then
            MessageBox.Show("El producto del almacén no es correcto.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Result = False
        Else
            Result = True
        End If

        If Result = True Then
            dtpFMovimiento.Value = _FechaMovimiento
            dtpFResguardo.Value = _FechaMovimiento
            ActiveControl = txtCliente
        End If
        Cursor = Cursors.Default
        Return Result
    End Function

    ' Realiza los movimientos del trasiego
    Public Sub RealizarMovimientos()
        'Dim Result As DialogResult
        'Dim Mensajes As New PortatilClasses.Mensaje(4)
        'Result = MessageBox.Show(Mensajes.Mensaje, Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        'If Result = DialogResult.Yes Then
        Cursor = Cursors.WaitCursor
        Refresh()
        Dim Cliente As Integer
        Dim Status As String
        Dim CapacidadTanque As Integer
        Dim PorcentajeInicial As Decimal
        Dim PorcentajeFinal As Decimal
        Dim Litros As Decimal
        Dim Kilos As Decimal
        Dim FechaMov As DateTime
        Dim FechaRes As DateTime

        Dim oConfig As New SigaMetClasses.cConfig(5, _Corporativo, GLOBAL_Sucursal)


        Dim FactorDensidad As String
        FactorDensidad = CType(oConfig.Parametros("FactorDensidad"), String).Trim
        Dim i As Integer = 0
        While i < _dtClienteResguardo.Rows.Count
            Cliente = CType(_dtClienteResguardo.Rows(i).Item(0), Integer)
            Status = CType(_dtClienteResguardo.Rows(i).Item(1), String)
            CapacidadTanque = CType(_dtClienteResguardo.Rows(i).Item(2), Integer)
            PorcentajeInicial = CType(_dtClienteResguardo.Rows(i).Item(3), Decimal)
            PorcentajeFinal = CType(_dtClienteResguardo.Rows(i).Item(4), Decimal)
            Litros = CType(_dtClienteResguardo.Rows(i).Item(5), Decimal)
            FechaMov = CType(_dtClienteResguardo.Rows(i).Item(6), DateTime)
            FechaRes = CType(_dtClienteResguardo.Rows(i).Item(7), DateTime)
            Kilos = Litros * CType(FactorDensidad, Decimal)

            Dim oFolioMovimientoAlmacen As New PortatilClasses.Consulta.cFolioMovimientoAlmacen()
            oFolioMovimientoAlmacen.Registrar(0, _Almacengas, 0, 8, 0)

            Dim oMovimientoAlmacenE As New PortatilClasses.Consulta.cMovimientoAlmacen(0, 0, _Almacengas, _
                                                       FechaMov, Kilos, Litros, 8, FechaRes, oFolioMovimientoAlmacen.NDocumento, _
                                                       oFolioMovimientoAlmacen.ClaseMovimientoAlmacen, _
                                                       oFolioMovimientoAlmacen.IdCorporativo, GLOBAL_Usuario)
            oMovimientoAlmacenE.CargaDatos()

            ProductoPanel.RegistraMovimientoProducto(_Almacengas, oMovimientoAlmacenE.Identificador, Litros, _
                                                                 Producto)

            Dim oResguardo As New Resguardo.cResguardo(oMovimientoAlmacenE.Identificador, _AnoAtt, _FolioAtt, Cliente, Status, CapacidadTanque, PorcentajeInicial, PorcentajeFinal, Litros, FechaRes)
            oResguardo.AlmacenarResguardo()


            oMovimientoAlmacenE = Nothing
            oFolioMovimientoAlmacen = Nothing
            oResguardo = Nothing

            i = i + 1
        End While
        Cursor = Cursors.Default
        Close()
        'End If
    End Sub

    ' Carga el producto del almacén, debido a que la carga se realiza directamente del contenedor
    Private Sub ProductoContenedor()
        Cursor = Cursors.WaitCursor
        Dim oProductoContenedor As New PortatilClasses.Consulta.cProductoContenedor(0, _Almacengas)
        oProductoContenedor.CargaDatos()
        Producto = oProductoContenedor.Identificador
        oProductoContenedor = Nothing
        Cursor = Cursors.Default
    End Sub

    ' Limpia los controles en donde se cragan los datos del cliente
    Private Sub LimpiarCliente()
        lblRuta.Text = ""
        lblEmpresa.Text = ""
        txtCliente.Clear()
        txtCapacidadTanque.Clear()
        txtPorcentajeInicial.Clear()
        txtPorcentajeFinal.Clear()
        lblCliente.Text = ""
        CelulaCliente = 0
        'lblLitros.Text = "0"
        dtpFMovimiento.Value = _FechaMovimiento
        dtpFResguardo.Value = _FechaMovimiento
        DatosClienteCargados = False
    End Sub

    ' Busca al cliente por medio del numero de cliente
    Private Sub BuscarCliente()
        Cursor = Cursors.WaitCursor
        Dim oCliente As New PortatilClasses.Consulta.cCliente(5, CType(txtCliente.Text, Integer))
        oCliente.CargaDatos()

        If oCliente.Cliente <> "" Then
            lblCliente.Text = oCliente.Cliente
            lblRuta.Text = oCliente.Ruta
            lblRuta.Tag = oCliente.IdRuta
            lblEmpresa.Text = oCliente.Corporativo
            lblEmpresa.Tag = oCliente.IdCorporativo
            CelulaCliente = oCliente.Celula
            DatosClienteCargados = True
        Else
            LimpiarCliente()
            Dim Mensajes As New PortatilClasses.Mensaje(3)
            MessageBox.Show(Mensajes.Mensaje, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            ActiveControl = txtCliente
            txtCliente.Clear()
            DatosClienteCargados = False
        End If
        oCliente = Nothing
        Cursor = Cursors.Default
    End Sub
#End Region

    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        Dim oBusquedaCliente As New SigaMetClasses.BusquedaCliente()
        If oBusquedaCliente.ShowDialog() = Windows.Forms.DialogResult.OK Then
            If oBusquedaCliente.Cliente <> 0 Then
                txtCliente.Text = CType(oBusquedaCliente.Cliente, String)
                BuscarCliente()
                ActiveControl = txtCapacidadTanque
            Else
                ActiveControl = txtCliente
            End If
        End If
    End Sub

    ' Evento del control ProductoPanel que se activa cuando nos cambiamos de control
    Private Sub ProductoPanel_SiguienteControl(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) _
    Handles ProductoPanel.SiguienteControl
        If e.KeyData = Keys.Enter Then
            Me.SelectNextControl(CType(sender, Control), True, True, True, True)

        End If
    End Sub

    ' Evento para pasarse de un control a otro por medio del enter
    Private Sub dtpFMovimiento_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dtpFMovimiento.KeyDown, ProductoPanel.KeyDown, dtpFResguardo.KeyDown
        If e.KeyData = Keys.Enter Then
            Me.SelectNextControl(CType(sender, Control), True, True, True, True)
        End If
    End Sub

    ' Evento para pasarse de un control a otro por medio del enter
    Private Sub txtCliente_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) _
    Handles txtCliente.KeyDown, txtCapacidadTanque.KeyDown, txtPorcentajeFinal.KeyDown, txtPorcentajeInicial.KeyDown
        If e.KeyData = Keys.Enter Or e.KeyData = Keys.Down Then
            Me.SelectNextControl(CType(sender, Control), True, True, True, True)
        End If
        If e.KeyData = Keys.Up Then
            MyBase.SelectNextControl(CType(sender, Control), False, True, True, True)
        End If
    End Sub

    Private Sub txtCliente_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCliente.Leave
        If txtCliente.Text <> "" And txtCliente.Text.Length > 0 Then
            BuscarCliente()
        End If
    End Sub

    Private Sub btnAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgregar.Click
        If ValidarDatos() Then
            If _dtClienteResguardo.Rows.Count < 3 Then
                CargaGrid()
                LimpiarCliente()
                Dim i As Integer
                i = 0
                While i < ProductoPanel.txtLista.Count()
                    CType(ProductoPanel.txtLista(i), TextBox).Text = ""
                    i = i + 1
                End While
                ActiveControl = txtCliente
            Else
                MessageBox.Show("No puede agregar mas de 3 clientes.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        End If
    End Sub

    Private Sub btnBorrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBorrar.Click
        If _dtClienteResguardo.Rows.Count > 0 Then
            _LitrosResguardados = _LitrosResguardados - CType(_dtClienteResguardo.Rows(grdResguardo.CurrentRowIndex).Item(5), Decimal)
            lblLitros.Text = _LitrosResguardados.ToString("N2")
            _dtClienteResguardo.Rows(grdResguardo.CurrentRowIndex).Delete()
            _dtClienteResguardo.AcceptChanges()
            grdResguardo.DataSource = Nothing
            grdResguardo.DataSource = _dtClienteResguardo
        End If
    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        LimpiarCliente()
        If _dtClienteResguardo.Rows.Count > 0 Then
            'RealizarMovimientos()
            btnAceptar.DialogResult() = DialogResult.OK
            Me.DialogResult() = DialogResult.OK
            Me.Close()
        Else
            'Dim Mensaje As PortatilClasses.Mensaje
            'Mensaje = New PortatilClasses.Mensaje(108)
            MessageBox.Show("Por favor agregue la lista de clientes con resguardo de gas.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            ActiveControl = txtCliente
        End If
    End Sub

    Private Sub txtCapacidadTanque_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCapacidadTanque.Leave, txtPorcentajeInicial.Leave, txtPorcentajeFinal.Leave
        If txtCapacidadTanque.Text.Length > 0 And txtPorcentajeInicial.Text.Length > 0 And txtPorcentajeFinal.Text.Length > 0 Then
            Dim Capacidad As Integer = CType(txtCapacidadTanque.Text, Integer)
            Dim PorcentajeInicial As Decimal = CType(txtPorcentajeInicial.Text, Decimal)
            Dim PorcentajeFinal As Decimal = CType(txtPorcentajeFinal.Text, Decimal)

            If Capacidad > 0 And PorcentajeInicial > 0 And PorcentajeFinal <= PorcentajeInicial Then
                Dim CapacidadInicial As Decimal = Capacidad * (PorcentajeInicial / 100)
                Dim CapacidadFinal As Decimal = Capacidad * (PorcentajeFinal / 100)
                Dim TotalLitrosExtraidos As Decimal = CapacidadInicial - CapacidadFinal
                Dim i As Integer
                i = 0
                While i < ProductoPanel.txtLista.Count()
                    CType(ProductoPanel.txtLista(i), TextBox).Text = TotalLitrosExtraidos.ToString("N2")
                    i = i + 1
                End While

            Else
                MessageBox.Show("Los valores de capacidad o porcentajes son incorrectos por favor verifique.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                ActiveControl = Me.ActiveControl
            End If
        End If
    End Sub
End Class
