'20100310#CFSL - Se agregaron funcionalidades para el calculo de eficiencia en Hidrogas.

Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.Windows.Forms.MessageBox
Imports LeerPesoBascula
Imports System.Collections.Generic

Public Class frmAutotanques
    Inherits System.Windows.Forms.Form



#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        '#If Debug Then
        '        pnlPruebaTransponder.Visible = True
        '#End If

        Dim daBascula As New SqlDataAdapter("Select * from VehiculoExterno", Globales.GetInstance.cnSigamet)
        Dim dtPG As New DataTable()
        Dim dtContenedor As New DataTable()

        Try
            daBascula.Fill(dtPG)


            'daBascula.SelectCommand.CommandText = "Select AlmacenGas, Descripcion from almacengas " & _
            '                "where Status = 'ACTIVO' and TipoAlmacenGas = 1 and TipoProducto = 1"
            If Not Globales.GetInstance._CelulasUsuario Then
                daBascula.SelectCommand.CommandText = "spBasConsultaAlmacenDestino"
            Else
                daBascula.SelectCommand.CommandText = "spBasConsultaAlmacenDestino @Usuario = " & Globales.GetInstance._Usuario
            End If

            daBascula.Fill(dtContenedor)
            ccboPG.DisplayMember = "VehiculoExterno"
            ccboPG.ValueMember = "Capacidad"
            ccboPG.DataSource = dtPG

            cboContenedor.DisplayMember = "Descripcion"
            cboContenedor.ValueMember = "AlmacenGas"
            cboContenedor.DataSource = dtContenedor
            cboContenedor.SelectedValue = Globales.GetInstance._ContenedorPredeterminado
        Catch ex As Exception
            Globales.GetInstance.ExMessage(ex)
        End Try

        bdtpFSalida.Value = Globales.GetInstance.FechaActual.Date

        trpFotos.ConexionSQL = Globales.GetInstance.cnSigamet
        trpFotos.Operador = 0
        trpFotos.Ayudante = 0

        vgHistorial.Visible = Globales.GetInstance._Detalle = 0
        lblHistorial.Visible = Globales.GetInstance._Detalle = 0
        trpFotos.Visible = Globales.GetInstance._Detalle = 1

        'Tipo de detalle        
        Limpiar()
        If Not Globales.GetInstance.OperacionBascula(9).Habilitada Then
            txtKilometrajeApertura.ReadOnly = True
        End If
        txtPesoApertura.ReadOnly = (Not Globales.GetInstance.OperacionBascula(9).Habilitada AndAlso Not Globales.GetInstance.OperacionBascula(3).Habilitada) OrElse Not Globales.GetInstance._ExisteBascula
        txtPesoCierre.ReadOnly = (Not Globales.GetInstance.OperacionBascula(9).Habilitada AndAlso Not Globales.GetInstance.OperacionBascula(3).Habilitada) OrElse Not Globales.GetInstance._ExisteBascula

        txtPesoApertura.Enabled = Globales.GetInstance._ExisteBascula
        txtPesoCierre.Enabled = Globales.GetInstance._ExisteBascula

        If Globales.GetInstance._ExisteBascula Then
            InicializaBascula()
        End If

        'Transponder
        btnDescartarLectura.Visible = Globales.GetInstance._LeeTransponder
        btnRegresarFila.Visible = Globales.GetInstance._LeeTransponder

        'Medición física
        rgrpMedicionFisica.Enabled = Globales.GetInstance._MedicionFisica

        'Para pesar autotanques anticipadamente
        pnlFSalida.Enabled = Globales.GetInstance._AnticiparPesado
        pnlFSalida.Visible = Globales.GetInstance._AnticiparPesado

        'Afecta almacengas por totalizadores
        lblLitrosCargados.Visible = Globales.GetInstance._TipoCalculoAlmacen = 1
        txtLitrosCargados.Visible = Globales.GetInstance._TipoCalculoAlmacen = 1
        txtLitrosCargados.Enabled = Globales.GetInstance._TipoCalculoAlmacen = 1
        txtLitrosCargados.TabStop = Globales.GetInstance._TipoCalculoAlmacen = 1

        txtLitrosVendidos.Visible = Globales.GetInstance._MostarLitrajePorPeso
        lblLitrosVendidos.Visible = Globales.GetInstance._MostarLitrajePorPeso

        'FMovimiento
        pnlFMovimiento.Visible = Globales.GetInstance._PedirFMovimiento

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
    Friend WithEvents txtPlacas As System.Windows.Forms.TextBox
    Friend WithEvents txtCapacidad As System.Windows.Forms.TextBox
    Friend WithEvents txtFechaApertura As System.Windows.Forms.TextBox
    Friend WithEvents lblFechaApertura As System.Windows.Forms.Label
    Friend WithEvents lblRuta As System.Windows.Forms.Label
    Friend WithEvents lblCapacidad As System.Windows.Forms.Label
    Friend WithEvents lblHoraApertura As System.Windows.Forms.Label
    Friend WithEvents txtHoraApertura As System.Windows.Forms.TextBox
    Friend WithEvents lblCelula As System.Windows.Forms.Label
    Friend WithEvents lblPlacas As System.Windows.Forms.Label
    Friend WithEvents lblLitrosApertura As System.Windows.Forms.Label
    Friend WithEvents lblPercentajeApertura As System.Windows.Forms.Label
    Friend WithEvents txtKilometrajeApertura As System.Windows.Forms.TextBox
    Friend WithEvents lblKilometrajeApertura As System.Windows.Forms.Label
    Friend WithEvents lblTotalizadorApertura As System.Windows.Forms.Label
    Friend WithEvents txtTotalizadorApertura As System.Windows.Forms.TextBox
    Friend WithEvents lblGasInicial As System.Windows.Forms.Label
    Friend WithEvents txtPorcentajeApertura As System.Windows.Forms.TextBox
    Friend WithEvents lblPesoApertura As System.Windows.Forms.Label
    Friend WithEvents txtLitrosApertura As System.Windows.Forms.TextBox
    Friend WithEvents txtObservacionesApertura As System.Windows.Forms.TextBox
    Friend WithEvents lblObservacionesApertura As System.Windows.Forms.Label
    Friend WithEvents pnlAcciones As System.Windows.Forms.Panel
    Friend WithEvents rgrpCierre As Bascula.RoundedGroupBox
    Friend WithEvents txtExtra As System.Windows.Forms.TextBox
    Friend WithEvents txtPrecio As System.Windows.Forms.TextBox
    Friend WithEvents txtDiferencia As System.Windows.Forms.TextBox
    Friend WithEvents txtLitrosLiquidados As System.Windows.Forms.TextBox
    Friend WithEvents txtLitrosVendidos As System.Windows.Forms.TextBox
    Friend WithEvents txtAyudante As System.Windows.Forms.TextBox
    Friend WithEvents lblExtra As System.Windows.Forms.Label
    Friend WithEvents lblCelulaCierre As System.Windows.Forms.Label
    Friend WithEvents lblRutaCierre As System.Windows.Forms.Label
    Friend WithEvents lblHoraCierre As System.Windows.Forms.Label
    Friend WithEvents lblPorcentajeNoVendido As System.Windows.Forms.Label
    Friend WithEvents lblVenta As System.Windows.Forms.Label
    Friend WithEvents lblPesoCierre As System.Windows.Forms.Label
    Friend WithEvents lblGasNoVendido As System.Windows.Forms.Label
    Friend WithEvents lblDiferenciaTotalizador As System.Windows.Forms.Label
    Friend WithEvents lblFechaCierre As System.Windows.Forms.Label
    Friend WithEvents lblOperador As System.Windows.Forms.Label
    Friend WithEvents lblAyudabte As System.Windows.Forms.Label
    Friend WithEvents lblDiferenciaKilometraje As System.Windows.Forms.Label
    Friend WithEvents lblKilometrajeCierre As System.Windows.Forms.Label
    Friend WithEvents lblTotalizadorCierre As System.Windows.Forms.Label
    Friend WithEvents txtFolio As System.Windows.Forms.TextBox
    Friend WithEvents lblAutotanque As System.Windows.Forms.Label
    Friend WithEvents txtAutotanque As System.Windows.Forms.TextBox
    Friend WithEvents rgrpFila As Bascula.RoundedGroupBox
    Friend WithEvents lblFolio As System.Windows.Forms.Label
    Friend WithEvents imgAutotanques As System.Windows.Forms.ImageList
    Friend WithEvents tbAutotanque As System.Windows.Forms.ToolBar
    Friend WithEvents btnLimpiar As System.Windows.Forms.ToolBarButton
    Friend WithEvents Sep0 As System.Windows.Forms.ToolBarButton
    Friend WithEvents btnAnular As System.Windows.Forms.ToolBarButton
    Friend WithEvents btnModificar As System.Windows.Forms.ToolBarButton
    Friend WithEvents Sep1 As System.Windows.Forms.ToolBarButton
    Friend WithEvents btnBuscar As System.Windows.Forms.ToolBarButton
    Friend WithEvents btnImprimir As System.Windows.Forms.ToolBarButton
    Friend WithEvents Sep2 As System.Windows.Forms.ToolBarButton
    Friend WithEvents btnCalculadora As System.Windows.Forms.ToolBarButton
    Friend WithEvents btnCerrar As System.Windows.Forms.ToolBarButton
    Friend WithEvents lblPrecio As System.Windows.Forms.Label
    Friend WithEvents lblImportePorcentaje As System.Windows.Forms.Label
    Friend WithEvents lblLitrosPorcentaje As System.Windows.Forms.Label
    Friend WithEvents lblLitrosLiquidados As System.Windows.Forms.Label
    Friend WithEvents lblLitrosVendidos As System.Windows.Forms.Label
    Friend WithEvents lblObservacionesCierre As System.Windows.Forms.Label
    Friend WithEvents lblLitrosPeso As System.Windows.Forms.Label
    Friend WithEvents lblImportePeso As System.Windows.Forms.Label
    Friend WithEvents btnPesar As System.Windows.Forms.Button
    Friend WithEvents vgHistorial As Bascula.ViewGrid
    Friend WithEvents figSeparador As Bascula.Figure
    Friend WithEvents btnBuscarAtt As System.Windows.Forms.Button
    Friend WithEvents txtImportePorcentaje As System.Windows.Forms.TextBox
    Friend WithEvents txtLitrosPorcentaje As System.Windows.Forms.TextBox
    Friend WithEvents lblDiferencia As System.Windows.Forms.Label
    Friend WithEvents txtDiferenciaLitros As System.Windows.Forms.TextBox
    Friend WithEvents txtRutaCierre As System.Windows.Forms.TextBox
    Friend WithEvents txtHoraCierre As System.Windows.Forms.TextBox
    Friend WithEvents lblLitrosNoVendido As System.Windows.Forms.Label
    Friend WithEvents txtDiferenciaPorcentaje As System.Windows.Forms.TextBox
    Friend WithEvents lblDiferenciaGas As System.Windows.Forms.Label
    Friend WithEvents txtFechaCierre As System.Windows.Forms.TextBox
    Friend WithEvents txtVenta As System.Windows.Forms.TextBox
    Friend WithEvents txtDiferenciaTotalizador As System.Windows.Forms.TextBox
    Friend WithEvents txtOperador As System.Windows.Forms.TextBox
    Friend WithEvents txtDiferenciaKilometraje As System.Windows.Forms.TextBox
    Friend WithEvents txtLitrosPeso As System.Windows.Forms.TextBox
    Friend WithEvents txtCelulaCierre As System.Windows.Forms.TextBox
    Friend WithEvents txtAutotanqueF2 As System.Windows.Forms.TextBox
    Friend WithEvents txtAutotanqueF1 As System.Windows.Forms.TextBox
    Friend WithEvents txtPesoApertura As System.Windows.Forms.TextBox
    Friend WithEvents txtPesoCierre As System.Windows.Forms.TextBox
    Friend WithEvents txtObservacionesCierre As System.Windows.Forms.TextBox
    Friend WithEvents txtKilometrajeCierre As System.Windows.Forms.TextBox
    Friend WithEvents txtLitrosCierre As System.Windows.Forms.TextBox
    Friend WithEvents txtPorcentajeCierre As System.Windows.Forms.TextBox
    Friend WithEvents rgrpApertura As Bascula.RoundedGroupBox
    Friend WithEvents txtCelulaApertura As System.Windows.Forms.TextBox
    Friend WithEvents txtRutaApertura As System.Windows.Forms.TextBox
    Friend WithEvents txtTotalizadorCierre As System.Windows.Forms.TextBox
    Friend WithEvents txtImportePeso As System.Windows.Forms.TextBox
    Friend WithEvents chkPG As System.Windows.Forms.CheckBox
    Friend WithEvents ccboPG As Bascula.SelfCompletitionComboBox
    Friend WithEvents crvReporte As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents mnuImprimir As System.Windows.Forms.ContextMenu
    Friend WithEvents mniReporteApertura As System.Windows.Forms.MenuItem
    Friend WithEvents mniReporteCierre As System.Windows.Forms.MenuItem
    Friend WithEvents tmrTransponder As System.Windows.Forms.Timer
    'Friend WithEvents comLectorTransponder As MSComm
    'Friend WithEvents comLectorBascula As MSComm
    Friend WithEvents btnDescartarLectura As System.Windows.Forms.Button
    Friend WithEvents btnRegresarFila As System.Windows.Forms.Button
    Friend WithEvents tipAyuda As System.Windows.Forms.ToolTip
    Friend WithEvents lblHistorial As System.Windows.Forms.Label
    Friend WithEvents rgrpMedicionFisica As Bascula.RoundedGroupBox
    Friend WithEvents lblTemperatura As System.Windows.Forms.Label
    Friend WithEvents txtTemperatura As System.Windows.Forms.TextBox
    Friend WithEvents lblPresion As System.Windows.Forms.Label
    Friend WithEvents txtPresion As System.Windows.Forms.TextBox
    Friend WithEvents lblEmpleado As System.Windows.Forms.Label
    Friend WithEvents txtEmpleado As System.Windows.Forms.TextBox
    Friend WithEvents lblContenedor As System.Windows.Forms.Label
    Friend WithEvents cboContenedor As System.Windows.Forms.ComboBox
    Friend WithEvents lblEmbarque As System.Windows.Forms.Label
    Friend WithEvents txtEmbarque As System.Windows.Forms.TextBox
    Friend WithEvents pnlFSalida As System.Windows.Forms.Panel
    Friend WithEvents lblFSalida As System.Windows.Forms.Label
    Friend WithEvents bdtpFSalida As Bascula.BlinkDateTimePicker
    Friend WithEvents lblLitrosCargados As System.Windows.Forms.Label
    Friend WithEvents txtLitrosCargados As System.Windows.Forms.TextBox
    Private WithEvents comLectorBascula As AxMSCommLib.AxMSComm
    Private WithEvents comLectorTransponder As AxMSCommLib.AxMSComm
    Friend WithEvents pnlHistorial As System.Windows.Forms.Panel
    Friend WithEvents trpFotos As Bascula.Tripulacion
    Friend WithEvents lblTipoMovimiento As System.Windows.Forms.Label
    Friend WithEvents cboTipoMovimiento As System.Windows.Forms.ComboBox
    Friend WithEvents tmrHora As System.Windows.Forms.Timer
    Friend WithEvents btnSentidoMovimiento As System.Windows.Forms.Button
    Friend WithEvents lblSentidoMovimiento As System.Windows.Forms.Label
    Friend WithEvents pnlPruebaTransponder As System.Windows.Forms.Panel
    Friend WithEvents nupdAtt As System.Windows.Forms.NumericUpDown
    Friend WithEvents Inserta As System.Windows.Forms.Button
    Friend WithEvents btnCicloEspecial As System.Windows.Forms.ToolBarButton
    Friend WithEvents pnlFMovimiento As System.Windows.Forms.Panel
    Friend WithEvents dtpFMovimiento As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblFMovimiento As System.Windows.Forms.Label
    Friend WithEvents cboAlmacenEntrada As System.Windows.Forms.ComboBox
    Friend WithEvents tmrLectura As System.Windows.Forms.Timer
    Friend WithEvents lblAlmacenEntrada As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmAutotanques))
        Me.pnlAcciones = New System.Windows.Forms.Panel()
        Me.cboAlmacenEntrada = New System.Windows.Forms.ComboBox()
        Me.lblAlmacenEntrada = New System.Windows.Forms.Label()
        Me.pnlPruebaTransponder = New System.Windows.Forms.Panel()
        Me.Inserta = New System.Windows.Forms.Button()
        Me.nupdAtt = New System.Windows.Forms.NumericUpDown()
        Me.lblEmbarque = New System.Windows.Forms.Label()
        Me.lblSentidoMovimiento = New System.Windows.Forms.Label()
        Me.btnSentidoMovimiento = New System.Windows.Forms.Button()
        Me.imgAutotanques = New System.Windows.Forms.ImageList(Me.components)
        Me.cboTipoMovimiento = New System.Windows.Forms.ComboBox()
        Me.lblTipoMovimiento = New System.Windows.Forms.Label()
        Me.txtEmbarque = New System.Windows.Forms.TextBox()
        Me.cboContenedor = New System.Windows.Forms.ComboBox()
        Me.lblContenedor = New System.Windows.Forms.Label()
        Me.txtAutotanque = New System.Windows.Forms.TextBox()
        Me.btnBuscarAtt = New System.Windows.Forms.Button()
        Me.btnPesar = New System.Windows.Forms.Button()
        Me.lblAutotanque = New System.Windows.Forms.Label()
        Me.chkPG = New System.Windows.Forms.CheckBox()
        Me.crvReporte = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
        Me.rgrpFila = New Bascula.RoundedGroupBox()
        Me.txtAutotanqueF1 = New System.Windows.Forms.TextBox()
        Me.txtAutotanqueF2 = New System.Windows.Forms.TextBox()
        Me.ccboPG = New Bascula.SelfCompletitionComboBox()
        Me.btnDescartarLectura = New System.Windows.Forms.Button()
        Me.btnRegresarFila = New System.Windows.Forms.Button()
        Me.comLectorBascula = New AxMSCommLib.AxMSComm()
        Me.comLectorTransponder = New AxMSCommLib.AxMSComm()
        Me.txtFolio = New System.Windows.Forms.TextBox()
        Me.lblFolio = New System.Windows.Forms.Label()
        Me.tbAutotanque = New System.Windows.Forms.ToolBar()
        Me.btnLimpiar = New System.Windows.Forms.ToolBarButton()
        Me.Sep0 = New System.Windows.Forms.ToolBarButton()
        Me.btnAnular = New System.Windows.Forms.ToolBarButton()
        Me.btnModificar = New System.Windows.Forms.ToolBarButton()
        Me.Sep1 = New System.Windows.Forms.ToolBarButton()
        Me.btnBuscar = New System.Windows.Forms.ToolBarButton()
        Me.btnCicloEspecial = New System.Windows.Forms.ToolBarButton()
        Me.btnImprimir = New System.Windows.Forms.ToolBarButton()
        Me.mnuImprimir = New System.Windows.Forms.ContextMenu()
        Me.mniReporteApertura = New System.Windows.Forms.MenuItem()
        Me.mniReporteCierre = New System.Windows.Forms.MenuItem()
        Me.btnCalculadora = New System.Windows.Forms.ToolBarButton()
        Me.Sep2 = New System.Windows.Forms.ToolBarButton()
        Me.btnCerrar = New System.Windows.Forms.ToolBarButton()
        Me.tmrTransponder = New System.Windows.Forms.Timer(Me.components)
        Me.tipAyuda = New System.Windows.Forms.ToolTip(Me.components)
        Me.pnlHistorial = New System.Windows.Forms.Panel()
        Me.lblHistorial = New System.Windows.Forms.Label()
        Me.vgHistorial = New Bascula.ViewGrid()
        Me.trpFotos = New Bascula.Tripulacion()
        Me.pnlFSalida = New System.Windows.Forms.Panel()
        Me.bdtpFSalida = New Bascula.BlinkDateTimePicker()
        Me.lblFSalida = New System.Windows.Forms.Label()
        Me.tmrHora = New System.Windows.Forms.Timer(Me.components)
        Me.rgrpMedicionFisica = New Bascula.RoundedGroupBox()
        Me.pnlFMovimiento = New System.Windows.Forms.Panel()
        Me.dtpFMovimiento = New System.Windows.Forms.DateTimePicker()
        Me.lblFMovimiento = New System.Windows.Forms.Label()
        Me.lblEmpleado = New System.Windows.Forms.Label()
        Me.txtEmpleado = New System.Windows.Forms.TextBox()
        Me.lblPresion = New System.Windows.Forms.Label()
        Me.txtPresion = New System.Windows.Forms.TextBox()
        Me.lblTemperatura = New System.Windows.Forms.Label()
        Me.txtTemperatura = New System.Windows.Forms.TextBox()
        Me.rgrpCierre = New Bascula.RoundedGroupBox()
        Me.txtImportePorcentaje = New System.Windows.Forms.TextBox()
        Me.txtLitrosPorcentaje = New System.Windows.Forms.TextBox()
        Me.lblFechaCierre = New System.Windows.Forms.Label()
        Me.txtFechaCierre = New System.Windows.Forms.TextBox()
        Me.lblHoraCierre = New System.Windows.Forms.Label()
        Me.txtHoraCierre = New System.Windows.Forms.TextBox()
        Me.lblOperador = New System.Windows.Forms.Label()
        Me.txtOperador = New System.Windows.Forms.TextBox()
        Me.lblAyudabte = New System.Windows.Forms.Label()
        Me.txtAyudante = New System.Windows.Forms.TextBox()
        Me.txtExtra = New System.Windows.Forms.TextBox()
        Me.lblRutaCierre = New System.Windows.Forms.Label()
        Me.txtRutaCierre = New System.Windows.Forms.TextBox()
        Me.lblCelulaCierre = New System.Windows.Forms.Label()
        Me.txtCelulaCierre = New System.Windows.Forms.TextBox()
        Me.lblObservacionesCierre = New System.Windows.Forms.Label()
        Me.txtObservacionesCierre = New System.Windows.Forms.TextBox()
        Me.lblKilometrajeCierre = New System.Windows.Forms.Label()
        Me.txtKilometrajeCierre = New System.Windows.Forms.TextBox()
        Me.lblTotalizadorCierre = New System.Windows.Forms.Label()
        Me.txtTotalizadorCierre = New System.Windows.Forms.TextBox()
        Me.lblGasNoVendido = New System.Windows.Forms.Label()
        Me.lblPorcentajeNoVendido = New System.Windows.Forms.Label()
        Me.txtPorcentajeCierre = New System.Windows.Forms.TextBox()
        Me.lblLitrosNoVendido = New System.Windows.Forms.Label()
        Me.txtLitrosCierre = New System.Windows.Forms.TextBox()
        Me.lblPesoCierre = New System.Windows.Forms.Label()
        Me.txtPesoCierre = New System.Windows.Forms.TextBox()
        Me.lblDiferencia = New System.Windows.Forms.Label()
        Me.txtDiferencia = New System.Windows.Forms.TextBox()
        Me.lblDiferenciaKilometraje = New System.Windows.Forms.Label()
        Me.txtDiferenciaKilometraje = New System.Windows.Forms.TextBox()
        Me.lblDiferenciaGas = New System.Windows.Forms.Label()
        Me.txtDiferenciaPorcentaje = New System.Windows.Forms.TextBox()
        Me.txtDiferenciaLitros = New System.Windows.Forms.TextBox()
        Me.lblDiferenciaTotalizador = New System.Windows.Forms.Label()
        Me.txtDiferenciaTotalizador = New System.Windows.Forms.TextBox()
        Me.lblVenta = New System.Windows.Forms.Label()
        Me.txtVenta = New System.Windows.Forms.TextBox()
        Me.lblLitrosLiquidados = New System.Windows.Forms.Label()
        Me.txtLitrosLiquidados = New System.Windows.Forms.TextBox()
        Me.lblPrecio = New System.Windows.Forms.Label()
        Me.txtPrecio = New System.Windows.Forms.TextBox()
        Me.lblLitrosVendidos = New System.Windows.Forms.Label()
        Me.txtLitrosVendidos = New System.Windows.Forms.TextBox()
        Me.lblLitrosPeso = New System.Windows.Forms.Label()
        Me.txtLitrosPeso = New System.Windows.Forms.TextBox()
        Me.lblImportePeso = New System.Windows.Forms.Label()
        Me.txtImportePeso = New System.Windows.Forms.TextBox()
        Me.lblLitrosPorcentaje = New System.Windows.Forms.Label()
        Me.lblImportePorcentaje = New System.Windows.Forms.Label()
        Me.rgrpApertura = New Bascula.RoundedGroupBox()
        Me.txtLitrosCargados = New System.Windows.Forms.TextBox()
        Me.lblLitrosCargados = New System.Windows.Forms.Label()
        Me.lblFechaApertura = New System.Windows.Forms.Label()
        Me.lblRuta = New System.Windows.Forms.Label()
        Me.lblCapacidad = New System.Windows.Forms.Label()
        Me.lblHoraApertura = New System.Windows.Forms.Label()
        Me.lblCelula = New System.Windows.Forms.Label()
        Me.lblPlacas = New System.Windows.Forms.Label()
        Me.txtFechaApertura = New System.Windows.Forms.TextBox()
        Me.txtRutaApertura = New System.Windows.Forms.TextBox()
        Me.txtCapacidad = New System.Windows.Forms.TextBox()
        Me.txtHoraApertura = New System.Windows.Forms.TextBox()
        Me.txtCelulaApertura = New System.Windows.Forms.TextBox()
        Me.txtPlacas = New System.Windows.Forms.TextBox()
        Me.lblKilometrajeApertura = New System.Windows.Forms.Label()
        Me.txtKilometrajeApertura = New System.Windows.Forms.TextBox()
        Me.lblTotalizadorApertura = New System.Windows.Forms.Label()
        Me.txtTotalizadorApertura = New System.Windows.Forms.TextBox()
        Me.lblGasInicial = New System.Windows.Forms.Label()
        Me.lblPercentajeApertura = New System.Windows.Forms.Label()
        Me.txtPorcentajeApertura = New System.Windows.Forms.TextBox()
        Me.lblLitrosApertura = New System.Windows.Forms.Label()
        Me.txtLitrosApertura = New System.Windows.Forms.TextBox()
        Me.lblPesoApertura = New System.Windows.Forms.Label()
        Me.txtPesoApertura = New System.Windows.Forms.TextBox()
        Me.lblObservacionesApertura = New System.Windows.Forms.Label()
        Me.txtObservacionesApertura = New System.Windows.Forms.TextBox()
        Me.figSeparador = New Bascula.Figure()
        Me.tmrLectura = New System.Windows.Forms.Timer(Me.components)
        Me.pnlAcciones.SuspendLayout()
        Me.pnlPruebaTransponder.SuspendLayout()
        CType(Me.nupdAtt, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.rgrpFila.SuspendLayout()
        CType(Me.comLectorBascula, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.comLectorTransponder, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlHistorial.SuspendLayout()
        Me.pnlFSalida.SuspendLayout()
        Me.rgrpMedicionFisica.SuspendLayout()
        Me.pnlFMovimiento.SuspendLayout()
        Me.rgrpCierre.SuspendLayout()
        Me.rgrpApertura.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlAcciones
        '
        Me.pnlAcciones.Controls.Add(Me.cboAlmacenEntrada)
        Me.pnlAcciones.Controls.Add(Me.lblAlmacenEntrada)
        Me.pnlAcciones.Controls.Add(Me.pnlPruebaTransponder)
        Me.pnlAcciones.Controls.Add(Me.lblEmbarque)
        Me.pnlAcciones.Controls.Add(Me.lblSentidoMovimiento)
        Me.pnlAcciones.Controls.Add(Me.btnSentidoMovimiento)
        Me.pnlAcciones.Controls.Add(Me.cboTipoMovimiento)
        Me.pnlAcciones.Controls.Add(Me.lblTipoMovimiento)
        Me.pnlAcciones.Controls.Add(Me.txtEmbarque)
        Me.pnlAcciones.Controls.Add(Me.cboContenedor)
        Me.pnlAcciones.Controls.Add(Me.lblContenedor)
        Me.pnlAcciones.Controls.Add(Me.txtAutotanque)
        Me.pnlAcciones.Controls.Add(Me.btnBuscarAtt)
        Me.pnlAcciones.Controls.Add(Me.btnPesar)
        Me.pnlAcciones.Controls.Add(Me.lblAutotanque)
        Me.pnlAcciones.Controls.Add(Me.chkPG)
        Me.pnlAcciones.Controls.Add(Me.crvReporte)
        Me.pnlAcciones.Controls.Add(Me.rgrpFila)
        Me.pnlAcciones.Controls.Add(Me.ccboPG)
        Me.pnlAcciones.Controls.Add(Me.btnDescartarLectura)
        Me.pnlAcciones.Controls.Add(Me.btnRegresarFila)
        Me.pnlAcciones.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnlAcciones.Location = New System.Drawing.Point(872, 50)
        Me.pnlAcciones.Name = "pnlAcciones"
        Me.pnlAcciones.Size = New System.Drawing.Size(152, 595)
        Me.pnlAcciones.TabIndex = 0
        '
        'cboAlmacenEntrada
        '
        Me.cboAlmacenEntrada.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboAlmacenEntrada.DropDownWidth = 512
        Me.cboAlmacenEntrada.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboAlmacenEntrada.Location = New System.Drawing.Point(12, 174)
        Me.cboAlmacenEntrada.Name = "cboAlmacenEntrada"
        Me.cboAlmacenEntrada.Size = New System.Drawing.Size(128, 21)
        Me.cboAlmacenEntrada.TabIndex = 64
        '
        'lblAlmacenEntrada
        '
        Me.lblAlmacenEntrada.AutoSize = True
        Me.lblAlmacenEntrada.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAlmacenEntrada.Location = New System.Drawing.Point(12, 155)
        Me.lblAlmacenEntrada.Name = "lblAlmacenEntrada"
        Me.lblAlmacenEntrada.Size = New System.Drawing.Size(124, 13)
        Me.lblAlmacenEntrada.TabIndex = 63
        Me.lblAlmacenEntrada.Text = "Almacén de entrada:"
        '
        'pnlPruebaTransponder
        '
        Me.pnlPruebaTransponder.Controls.Add(Me.Inserta)
        Me.pnlPruebaTransponder.Controls.Add(Me.nupdAtt)
        Me.pnlPruebaTransponder.Location = New System.Drawing.Point(8, 544)
        Me.pnlPruebaTransponder.Name = "pnlPruebaTransponder"
        Me.pnlPruebaTransponder.Size = New System.Drawing.Size(88, 56)
        Me.pnlPruebaTransponder.TabIndex = 62
        Me.pnlPruebaTransponder.Visible = False
        '
        'Inserta
        '
        Me.Inserta.Location = New System.Drawing.Point(5, 29)
        Me.Inserta.Name = "Inserta"
        Me.Inserta.Size = New System.Drawing.Size(75, 23)
        Me.Inserta.TabIndex = 1
        Me.Inserta.Text = "Inserta"
        '
        'nupdAtt
        '
        Me.nupdAtt.Location = New System.Drawing.Point(5, 5)
        Me.nupdAtt.Name = "nupdAtt"
        Me.nupdAtt.Size = New System.Drawing.Size(72, 21)
        Me.nupdAtt.TabIndex = 0
        '
        'lblEmbarque
        '
        Me.lblEmbarque.AutoSize = True
        Me.lblEmbarque.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEmbarque.Location = New System.Drawing.Point(8, 104)
        Me.lblEmbarque.Name = "lblEmbarque"
        Me.lblEmbarque.Size = New System.Drawing.Size(67, 13)
        Me.lblEmbarque.TabIndex = 56
        Me.lblEmbarque.Text = "Embarque:"
        Me.lblEmbarque.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lblEmbarque.Visible = False
        '
        'lblSentidoMovimiento
        '
        Me.lblSentidoMovimiento.AutoSize = True
        Me.lblSentidoMovimiento.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSentidoMovimiento.Location = New System.Drawing.Point(23, 484)
        Me.lblSentidoMovimiento.Name = "lblSentidoMovimiento"
        Me.lblSentidoMovimiento.Size = New System.Drawing.Size(108, 13)
        Me.lblSentidoMovimiento.TabIndex = 61
        Me.lblSentidoMovimiento.Text = "Mayor peso inicial"
        Me.lblSentidoMovimiento.Visible = False
        '
        'btnSentidoMovimiento
        '
        Me.btnSentidoMovimiento.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnSentidoMovimiento.ImageIndex = 10
        Me.btnSentidoMovimiento.ImageList = Me.imgAutotanques
        Me.btnSentidoMovimiento.Location = New System.Drawing.Point(56, 452)
        Me.btnSentidoMovimiento.Name = "btnSentidoMovimiento"
        Me.btnSentidoMovimiento.Size = New System.Drawing.Size(40, 23)
        Me.btnSentidoMovimiento.TabIndex = 60
        Me.tipAyuda.SetToolTip(Me.btnSentidoMovimiento, "Cambiar el sentido del movimiento")
        Me.btnSentidoMovimiento.Visible = False
        '
        'imgAutotanques
        '
        Me.imgAutotanques.ImageStream = CType(resources.GetObject("imgAutotanques.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imgAutotanques.TransparentColor = System.Drawing.Color.Transparent
        Me.imgAutotanques.Images.SetKeyName(0, "")
        Me.imgAutotanques.Images.SetKeyName(1, "")
        Me.imgAutotanques.Images.SetKeyName(2, "")
        Me.imgAutotanques.Images.SetKeyName(3, "")
        Me.imgAutotanques.Images.SetKeyName(4, "")
        Me.imgAutotanques.Images.SetKeyName(5, "")
        Me.imgAutotanques.Images.SetKeyName(6, "")
        Me.imgAutotanques.Images.SetKeyName(7, "")
        Me.imgAutotanques.Images.SetKeyName(8, "")
        Me.imgAutotanques.Images.SetKeyName(9, "")
        Me.imgAutotanques.Images.SetKeyName(10, "")
        Me.imgAutotanques.Images.SetKeyName(11, "")
        Me.imgAutotanques.Images.SetKeyName(12, "")
        '
        'cboTipoMovimiento
        '
        Me.cboTipoMovimiento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTipoMovimiento.Items.AddRange(New Object() {"Venta", "Traslado", "Resguardo", "Otro"})
        Me.cboTipoMovimiento.Location = New System.Drawing.Point(8, 120)
        Me.cboTipoMovimiento.Name = "cboTipoMovimiento"
        Me.cboTipoMovimiento.Size = New System.Drawing.Size(136, 21)
        Me.cboTipoMovimiento.TabIndex = 59
        '
        'lblTipoMovimiento
        '
        Me.lblTipoMovimiento.AutoSize = True
        Me.lblTipoMovimiento.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTipoMovimiento.Location = New System.Drawing.Point(8, 104)
        Me.lblTipoMovimiento.Name = "lblTipoMovimiento"
        Me.lblTipoMovimiento.Size = New System.Drawing.Size(105, 13)
        Me.lblTipoMovimiento.TabIndex = 58
        Me.lblTipoMovimiento.Text = "Tipo movimiento:"
        Me.lblTipoMovimiento.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtEmbarque
        '
        Me.txtEmbarque.AcceptsReturn = True
        Me.txtEmbarque.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtEmbarque.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEmbarque.Location = New System.Drawing.Point(8, 120)
        Me.txtEmbarque.MaxLength = 10
        Me.txtEmbarque.Name = "txtEmbarque"
        Me.txtEmbarque.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.txtEmbarque.Size = New System.Drawing.Size(136, 27)
        Me.txtEmbarque.TabIndex = 57
        Me.txtEmbarque.Visible = False
        '
        'cboContenedor
        '
        Me.cboContenedor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboContenedor.DropDownWidth = 512
        Me.cboContenedor.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboContenedor.Location = New System.Drawing.Point(12, 222)
        Me.cboContenedor.Name = "cboContenedor"
        Me.cboContenedor.Size = New System.Drawing.Size(128, 21)
        Me.cboContenedor.TabIndex = 55
        '
        'lblContenedor
        '
        Me.lblContenedor.AutoSize = True
        Me.lblContenedor.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblContenedor.Location = New System.Drawing.Point(12, 203)
        Me.lblContenedor.Name = "lblContenedor"
        Me.lblContenedor.Size = New System.Drawing.Size(112, 13)
        Me.lblContenedor.TabIndex = 54
        Me.lblContenedor.Text = "Almacén de salida:"
        '
        'txtAutotanque
        '
        Me.txtAutotanque.AcceptsReturn = True
        Me.txtAutotanque.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtAutotanque.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAutotanque.Location = New System.Drawing.Point(8, 65)
        Me.txtAutotanque.MaxLength = 10
        Me.txtAutotanque.Name = "txtAutotanque"
        Me.txtAutotanque.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.txtAutotanque.Size = New System.Drawing.Size(104, 27)
        Me.txtAutotanque.TabIndex = 1
        '
        'btnBuscarAtt
        '
        Me.btnBuscarAtt.Enabled = False
        Me.btnBuscarAtt.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnBuscarAtt.Image = CType(resources.GetObject("btnBuscarAtt.Image"), System.Drawing.Image)
        Me.btnBuscarAtt.Location = New System.Drawing.Point(115, 67)
        Me.btnBuscarAtt.Name = "btnBuscarAtt"
        Me.btnBuscarAtt.Size = New System.Drawing.Size(24, 23)
        Me.btnBuscarAtt.TabIndex = 2
        '
        'btnPesar
        '
        Me.btnPesar.Enabled = False
        Me.btnPesar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnPesar.Image = CType(resources.GetObject("btnPesar.Image"), System.Drawing.Image)
        Me.btnPesar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnPesar.Location = New System.Drawing.Point(30, 384)
        Me.btnPesar.Name = "btnPesar"
        Me.btnPesar.Size = New System.Drawing.Size(96, 40)
        Me.btnPesar.TabIndex = 3
        Me.btnPesar.TabStop = False
        Me.btnPesar.Text = "P&esar (F5)"
        Me.btnPesar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.tipAyuda.SetToolTip(Me.btnPesar, "Guardar los datos")
        '
        'lblAutotanque
        '
        Me.lblAutotanque.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAutotanque.Location = New System.Drawing.Point(8, 16)
        Me.lblAutotanque.Name = "lblAutotanque"
        Me.lblAutotanque.Size = New System.Drawing.Size(72, 8)
        Me.lblAutotanque.TabIndex = 0
        Me.lblAutotanque.Text = "&Autotánque:"
        Me.lblAutotanque.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'chkPG
        '
        Me.chkPG.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.chkPG.Location = New System.Drawing.Point(8, 36)
        Me.chkPG.Name = "chkPG"
        Me.chkPG.Size = New System.Drawing.Size(35, 24)
        Me.chkPG.TabIndex = 2
        Me.chkPG.Text = "&PG"
        '
        'crvReporte
        '
        Me.crvReporte.ActiveViewIndex = -1
        Me.crvReporte.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.crvReporte.Cursor = System.Windows.Forms.Cursors.Default
        Me.crvReporte.Location = New System.Drawing.Point(-10, -10)
        Me.crvReporte.Name = "crvReporte"
        Me.crvReporte.Size = New System.Drawing.Size(10, 10)
        Me.crvReporte.TabIndex = 53
        '
        'rgrpFila
        '
        Me.rgrpFila.BorderColor = System.Drawing.Color.Teal
        Me.rgrpFila.Controls.Add(Me.txtAutotanqueF1)
        Me.rgrpFila.Controls.Add(Me.txtAutotanqueF2)
        Me.rgrpFila.Location = New System.Drawing.Point(8, 254)
        Me.rgrpFila.Name = "rgrpFila"
        Me.rgrpFila.Size = New System.Drawing.Size(136, 104)
        Me.rgrpFila.TabIndex = 4
        Me.rgrpFila.TabStop = False
        Me.rgrpFila.Text = "Autotánques en fila"
        '
        'txtAutotanqueF1
        '
        Me.txtAutotanqueF1.BackColor = System.Drawing.Color.Gainsboro
        Me.txtAutotanqueF1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtAutotanqueF1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAutotanqueF1.Location = New System.Drawing.Point(14, 26)
        Me.txtAutotanqueF1.Name = "txtAutotanqueF1"
        Me.txtAutotanqueF1.ReadOnly = True
        Me.txtAutotanqueF1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.txtAutotanqueF1.Size = New System.Drawing.Size(109, 21)
        Me.txtAutotanqueF1.TabIndex = 0
        Me.txtAutotanqueF1.TabStop = False
        '
        'txtAutotanqueF2
        '
        Me.txtAutotanqueF2.BackColor = System.Drawing.Color.Gainsboro
        Me.txtAutotanqueF2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtAutotanqueF2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAutotanqueF2.Location = New System.Drawing.Point(14, 66)
        Me.txtAutotanqueF2.Name = "txtAutotanqueF2"
        Me.txtAutotanqueF2.ReadOnly = True
        Me.txtAutotanqueF2.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.txtAutotanqueF2.Size = New System.Drawing.Size(109, 21)
        Me.txtAutotanqueF2.TabIndex = 1
        Me.txtAutotanqueF2.TabStop = False
        '
        'ccboPG
        '
        Me.ccboPG.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ccboPG.Location = New System.Drawing.Point(8, 65)
        Me.ccboPG.Name = "ccboPG"
        Me.ccboPG.Size = New System.Drawing.Size(104, 27)
        Me.ccboPG.TabIndex = 0
        '
        'btnDescartarLectura
        '
        Me.btnDescartarLectura.Enabled = False
        Me.btnDescartarLectura.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnDescartarLectura.ImageIndex = 8
        Me.btnDescartarLectura.ImageList = Me.imgAutotanques
        Me.btnDescartarLectura.Location = New System.Drawing.Point(48, 37)
        Me.btnDescartarLectura.Name = "btnDescartarLectura"
        Me.btnDescartarLectura.Size = New System.Drawing.Size(24, 23)
        Me.btnDescartarLectura.TabIndex = 2
        Me.tipAyuda.SetToolTip(Me.btnDescartarLectura, "Descartar la lectura del transponder")
        '
        'btnRegresarFila
        '
        Me.btnRegresarFila.Enabled = False
        Me.btnRegresarFila.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnRegresarFila.ImageIndex = 9
        Me.btnRegresarFila.ImageList = Me.imgAutotanques
        Me.btnRegresarFila.Location = New System.Drawing.Point(80, 37)
        Me.btnRegresarFila.Name = "btnRegresarFila"
        Me.btnRegresarFila.Size = New System.Drawing.Size(24, 23)
        Me.btnRegresarFila.TabIndex = 2
        Me.tipAyuda.SetToolTip(Me.btnRegresarFila, "Regresar la fila de autotanques")
        '
        'comLectorBascula
        '
        Me.comLectorBascula.Enabled = True
        Me.comLectorBascula.Location = New System.Drawing.Point(0, 0)
        Me.comLectorBascula.Name = "comLectorBascula"
        Me.comLectorBascula.TabIndex = 0
        '
        'comLectorTransponder
        '
        Me.comLectorTransponder.Enabled = True
        Me.comLectorTransponder.Location = New System.Drawing.Point(0, 0)
        Me.comLectorTransponder.Name = "comLectorTransponder"
        Me.comLectorTransponder.TabIndex = 0
        '
        'txtFolio
        '
        Me.txtFolio.BackColor = System.Drawing.Color.LightSteelBlue
        Me.txtFolio.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtFolio.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFolio.ForeColor = System.Drawing.Color.MidnightBlue
        Me.txtFolio.Location = New System.Drawing.Point(454, 7)
        Me.txtFolio.Name = "txtFolio"
        Me.txtFolio.ReadOnly = True
        Me.txtFolio.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.txtFolio.Size = New System.Drawing.Size(100, 24)
        Me.txtFolio.TabIndex = 85
        Me.txtFolio.TabStop = False
        '
        'lblFolio
        '
        Me.lblFolio.AutoSize = True
        Me.lblFolio.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFolio.Location = New System.Drawing.Point(415, 12)
        Me.lblFolio.Name = "lblFolio"
        Me.lblFolio.Size = New System.Drawing.Size(36, 13)
        Me.lblFolio.TabIndex = 84
        Me.lblFolio.Text = "Folio:"
        Me.lblFolio.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'tbAutotanque
        '
        Me.tbAutotanque.Appearance = System.Windows.Forms.ToolBarAppearance.Flat
        Me.tbAutotanque.Buttons.AddRange(New System.Windows.Forms.ToolBarButton() {Me.btnLimpiar, Me.Sep0, Me.btnAnular, Me.btnModificar, Me.Sep1, Me.btnBuscar, Me.btnCicloEspecial, Me.btnImprimir, Me.btnCalculadora, Me.Sep2, Me.btnCerrar})
        Me.tbAutotanque.DropDownArrows = True
        Me.tbAutotanque.ImageList = Me.imgAutotanques
        Me.tbAutotanque.Location = New System.Drawing.Point(0, 0)
        Me.tbAutotanque.Name = "tbAutotanque"
        Me.tbAutotanque.ShowToolTips = True
        Me.tbAutotanque.Size = New System.Drawing.Size(1024, 50)
        Me.tbAutotanque.TabIndex = 3
        Me.tbAutotanque.TabStop = True
        '
        'btnLimpiar
        '
        Me.btnLimpiar.ImageIndex = 0
        Me.btnLimpiar.Name = "btnLimpiar"
        Me.btnLimpiar.Text = "Limpiar"
        Me.btnLimpiar.ToolTipText = "Iniciar una nueva captura"
        '
        'Sep0
        '
        Me.Sep0.Name = "Sep0"
        Me.Sep0.Style = System.Windows.Forms.ToolBarButtonStyle.Separator
        '
        'btnAnular
        '
        Me.btnAnular.Enabled = False
        Me.btnAnular.ImageIndex = 1
        Me.btnAnular.Name = "btnAnular"
        Me.btnAnular.Text = "Anular"
        Me.btnAnular.ToolTipText = "Cancelar el movimiento"
        '
        'btnModificar
        '
        Me.btnModificar.Enabled = False
        Me.btnModificar.ImageIndex = 2
        Me.btnModificar.Name = "btnModificar"
        Me.btnModificar.Text = "Modificar"
        Me.btnModificar.ToolTipText = "Cambiar los datos del ciclo"
        '
        'Sep1
        '
        Me.Sep1.Name = "Sep1"
        Me.Sep1.Style = System.Windows.Forms.ToolBarButtonStyle.Separator
        '
        'btnBuscar
        '
        Me.btnBuscar.ImageIndex = 3
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Text = "Buscar"
        Me.btnBuscar.ToolTipText = "Buscar folio"
        Me.btnBuscar.Visible = False
        '
        'btnCicloEspecial
        '
        Me.btnCicloEspecial.ImageIndex = 12
        Me.btnCicloEspecial.Name = "btnCicloEspecial"
        Me.btnCicloEspecial.Tag = "Especial"
        Me.btnCicloEspecial.Text = "Especial"
        Me.btnCicloEspecial.ToolTipText = "Intercambiar datos del ciclo."
        Me.btnCicloEspecial.Visible = False
        '
        'btnImprimir
        '
        Me.btnImprimir.DropDownMenu = Me.mnuImprimir
        Me.btnImprimir.Enabled = False
        Me.btnImprimir.ImageIndex = 4
        Me.btnImprimir.Name = "btnImprimir"
        Me.btnImprimir.Style = System.Windows.Forms.ToolBarButtonStyle.DropDownButton
        Me.btnImprimir.Text = "Imprimir"
        Me.btnImprimir.ToolTipText = "Imprimir comprobante"
        '
        'mnuImprimir
        '
        Me.mnuImprimir.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mniReporteApertura, Me.mniReporteCierre})
        '
        'mniReporteApertura
        '
        Me.mniReporteApertura.Index = 0
        Me.mniReporteApertura.Text = "&Apertura de ciclo"
        '
        'mniReporteCierre
        '
        Me.mniReporteCierre.Index = 1
        Me.mniReporteCierre.Text = "&Cierre de ciclo"
        '
        'btnCalculadora
        '
        Me.btnCalculadora.ImageIndex = 5
        Me.btnCalculadora.Name = "btnCalculadora"
        Me.btnCalculadora.Text = "Calculadora"
        Me.btnCalculadora.ToolTipText = "Abrir calculadora"
        '
        'Sep2
        '
        Me.Sep2.Name = "Sep2"
        Me.Sep2.Style = System.Windows.Forms.ToolBarButtonStyle.Separator
        '
        'btnCerrar
        '
        Me.btnCerrar.ImageIndex = 6
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Text = "Cerrar"
        Me.btnCerrar.ToolTipText = "Cerrar la pantalla de pesado de autotanques"
        '
        'tmrTransponder
        '
        Me.tmrTransponder.Interval = 1000
        '
        'pnlHistorial
        '
        Me.pnlHistorial.Controls.Add(Me.lblHistorial)
        Me.pnlHistorial.Controls.Add(Me.vgHistorial)
        Me.pnlHistorial.Controls.Add(Me.trpFotos)
        Me.pnlHistorial.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlHistorial.Location = New System.Drawing.Point(240, 435)
        Me.pnlHistorial.Name = "pnlHistorial"
        Me.pnlHistorial.Size = New System.Drawing.Size(632, 210)
        Me.pnlHistorial.TabIndex = 54
        '
        'lblHistorial
        '
        Me.lblHistorial.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblHistorial.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblHistorial.ForeColor = System.Drawing.Color.MidnightBlue
        Me.lblHistorial.Location = New System.Drawing.Point(0, 0)
        Me.lblHistorial.Name = "lblHistorial"
        Me.lblHistorial.Size = New System.Drawing.Size(632, 33)
        Me.lblHistorial.TabIndex = 89
        Me.lblHistorial.Text = "Historial"
        Me.lblHistorial.TextAlign = System.Drawing.ContentAlignment.BottomLeft
        '
        'vgHistorial
        '
        Me.vgHistorial.AlternativeBackColor = System.Drawing.Color.Gainsboro
        'Me.vgHistorial.AutoArrange = False
        Me.vgHistorial.CheckCondition = Nothing
        Me.vgHistorial.DataSource = Nothing
        Me.vgHistorial.Dock = System.Windows.Forms.DockStyle.Fill
        Me.vgHistorial.FormatColumnNames = New String(-1) {}
        Me.vgHistorial.FullRowSelect = True
        Me.vgHistorial.GridLines = True
        Me.vgHistorial.HidedColumnNames = New String() {"Autotanque", "LitrosVendidos", "LitrosLiquidados", "Celula", "Ruta", "Placas", "Capacidad", "LitrosGasInicial", "KilometrajeInicial", "TotalizadorInicial", "LitrosGasFinal", "KilometrajeFinal", "TotalizadorFinal", "StatusLogistica", "ObservacionesInicioRuta", "ObservacionesCierreRuta"}
        Me.vgHistorial.HideSelection = False
        Me.vgHistorial.Location = New System.Drawing.Point(0, 0)
        Me.vgHistorial.MultiSelect = False
        Me.vgHistorial.Name = "vgHistorial"
        Me.vgHistorial.NullText = "--"
        Me.vgHistorial.PKColumnNames = Nothing
        Me.vgHistorial.Size = New System.Drawing.Size(632, 210)
        Me.vgHistorial.TabIndex = 50
        Me.vgHistorial.TabStop = False
        Me.vgHistorial.UseCompatibleStateImageBehavior = False
        Me.vgHistorial.View = System.Windows.Forms.View.Details
        '
        'trpFotos
        '
        Me.trpFotos.BackColor = System.Drawing.Color.Gainsboro
        Me.trpFotos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.trpFotos.Location = New System.Drawing.Point(0, 0)
        Me.trpFotos.Name = "trpFotos"
        Me.trpFotos.Size = New System.Drawing.Size(632, 210)
        Me.trpFotos.TabIndex = 90
        '
        'pnlFSalida
        '
        Me.pnlFSalida.Controls.Add(Me.bdtpFSalida)
        Me.pnlFSalida.Controls.Add(Me.lblFSalida)
        Me.pnlFSalida.Location = New System.Drawing.Point(569, 3)
        Me.pnlFSalida.Name = "pnlFSalida"
        Me.pnlFSalida.Size = New System.Drawing.Size(352, 37)
        Me.pnlFSalida.TabIndex = 6
        '
        'bdtpFSalida
        '
        Me.bdtpFSalida.BlinkColor = System.Drawing.Color.LightCoral
        Me.bdtpFSalida.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bdtpFSalida.Location = New System.Drawing.Point(56, 6)
        Me.bdtpFSalida.Name = "bdtpFSalida"
        Me.bdtpFSalida.Size = New System.Drawing.Size(296, 27)
        Me.bdtpFSalida.TabIndex = 86
        Me.bdtpFSalida.Value = New Date(2005, 2, 9, 10, 29, 54, 145)
        '
        'lblFSalida
        '
        Me.lblFSalida.AutoSize = True
        Me.lblFSalida.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFSalida.Location = New System.Drawing.Point(8, 12)
        Me.lblFSalida.Name = "lblFSalida"
        Me.lblFSalida.Size = New System.Drawing.Size(44, 13)
        Me.lblFSalida.TabIndex = 85
        Me.lblFSalida.Text = "Salida:"
        Me.lblFSalida.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'tmrHora
        '
        Me.tmrHora.Interval = 60000
        '
        'rgrpMedicionFisica
        '
        Me.rgrpMedicionFisica.BorderColor = System.Drawing.Color.Olive
        Me.rgrpMedicionFisica.Controls.Add(Me.pnlFMovimiento)
        Me.rgrpMedicionFisica.Controls.Add(Me.lblEmpleado)
        Me.rgrpMedicionFisica.Controls.Add(Me.txtEmpleado)
        Me.rgrpMedicionFisica.Controls.Add(Me.lblPresion)
        Me.rgrpMedicionFisica.Controls.Add(Me.txtPresion)
        Me.rgrpMedicionFisica.Controls.Add(Me.lblTemperatura)
        Me.rgrpMedicionFisica.Controls.Add(Me.txtTemperatura)
        Me.rgrpMedicionFisica.Dock = System.Windows.Forms.DockStyle.Left
        Me.rgrpMedicionFisica.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rgrpMedicionFisica.ForeColor = System.Drawing.Color.Olive
        Me.rgrpMedicionFisica.Location = New System.Drawing.Point(0, 435)
        Me.rgrpMedicionFisica.Name = "rgrpMedicionFisica"
        Me.rgrpMedicionFisica.Size = New System.Drawing.Size(240, 210)
        Me.rgrpMedicionFisica.TabIndex = 86
        Me.rgrpMedicionFisica.TabStop = False
        Me.rgrpMedicionFisica.Text = "Medición física"
        '
        'pnlFMovimiento
        '
        Me.pnlFMovimiento.Controls.Add(Me.dtpFMovimiento)
        Me.pnlFMovimiento.Controls.Add(Me.lblFMovimiento)
        Me.pnlFMovimiento.Location = New System.Drawing.Point(8, 145)
        Me.pnlFMovimiento.Name = "pnlFMovimiento"
        Me.pnlFMovimiento.Size = New System.Drawing.Size(224, 64)
        Me.pnlFMovimiento.TabIndex = 64
        '
        'dtpFMovimiento
        '
        Me.dtpFMovimiento.CustomFormat = "dd/MM/yyyy HH:mm tt"
        Me.dtpFMovimiento.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpFMovimiento.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpFMovimiento.Location = New System.Drawing.Point(5, 32)
        Me.dtpFMovimiento.Name = "dtpFMovimiento"
        Me.dtpFMovimiento.Size = New System.Drawing.Size(211, 27)
        Me.dtpFMovimiento.TabIndex = 1
        '
        'lblFMovimiento
        '
        Me.lblFMovimiento.AutoSize = True
        Me.lblFMovimiento.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFMovimiento.Location = New System.Drawing.Point(8, 8)
        Me.lblFMovimiento.Name = "lblFMovimiento"
        Me.lblFMovimiento.Size = New System.Drawing.Size(170, 19)
        Me.lblFMovimiento.TabIndex = 0
        Me.lblFMovimiento.Text = "Fecha del movimiento:"
        '
        'lblEmpleado
        '
        Me.lblEmpleado.AutoSize = True
        Me.lblEmpleado.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEmpleado.ForeColor = System.Drawing.Color.Black
        Me.lblEmpleado.Location = New System.Drawing.Point(11, 116)
        Me.lblEmpleado.Name = "lblEmpleado"
        Me.lblEmpleado.Size = New System.Drawing.Size(85, 19)
        Me.lblEmpleado.TabIndex = 4
        Me.lblEmpleado.Text = "&Empleado:"
        Me.lblEmpleado.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtEmpleado
        '
        Me.txtEmpleado.BackColor = System.Drawing.Color.White
        Me.txtEmpleado.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtEmpleado.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEmpleado.ForeColor = System.Drawing.Color.Black
        Me.txtEmpleado.Location = New System.Drawing.Point(158, 113)
        Me.txtEmpleado.Name = "txtEmpleado"
        Me.txtEmpleado.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.txtEmpleado.Size = New System.Drawing.Size(72, 27)
        Me.txtEmpleado.TabIndex = 5
        '
        'lblPresion
        '
        Me.lblPresion.AutoSize = True
        Me.lblPresion.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPresion.ForeColor = System.Drawing.Color.Black
        Me.lblPresion.Location = New System.Drawing.Point(11, 75)
        Me.lblPresion.Name = "lblPresion"
        Me.lblPresion.Size = New System.Drawing.Size(144, 19)
        Me.lblPresion.TabIndex = 2
        Me.lblPresion.Text = "&Presión (Kgs/cm²):"
        Me.lblPresion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtPresion
        '
        Me.txtPresion.BackColor = System.Drawing.Color.White
        Me.txtPresion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPresion.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPresion.ForeColor = System.Drawing.Color.Black
        Me.txtPresion.Location = New System.Drawing.Point(158, 72)
        Me.txtPresion.Name = "txtPresion"
        Me.txtPresion.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.txtPresion.Size = New System.Drawing.Size(72, 27)
        Me.txtPresion.TabIndex = 3
        '
        'lblTemperatura
        '
        Me.lblTemperatura.AutoSize = True
        Me.lblTemperatura.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTemperatura.ForeColor = System.Drawing.Color.Black
        Me.lblTemperatura.Location = New System.Drawing.Point(11, 34)
        Me.lblTemperatura.Name = "lblTemperatura"
        Me.lblTemperatura.Size = New System.Drawing.Size(141, 19)
        Me.lblTemperatura.TabIndex = 0
        Me.lblTemperatura.Text = "&Temperatura (°C):"
        Me.lblTemperatura.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtTemperatura
        '
        Me.txtTemperatura.BackColor = System.Drawing.Color.White
        Me.txtTemperatura.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTemperatura.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTemperatura.ForeColor = System.Drawing.Color.Black
        Me.txtTemperatura.Location = New System.Drawing.Point(158, 31)
        Me.txtTemperatura.Name = "txtTemperatura"
        Me.txtTemperatura.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.txtTemperatura.Size = New System.Drawing.Size(72, 27)
        Me.txtTemperatura.TabIndex = 1
        '
        'rgrpCierre
        '
        Me.rgrpCierre.BorderColor = System.Drawing.Color.Brown
        Me.rgrpCierre.Controls.Add(Me.txtImportePorcentaje)
        Me.rgrpCierre.Controls.Add(Me.txtLitrosPorcentaje)
        Me.rgrpCierre.Controls.Add(Me.lblFechaCierre)
        Me.rgrpCierre.Controls.Add(Me.txtFechaCierre)
        Me.rgrpCierre.Controls.Add(Me.lblHoraCierre)
        Me.rgrpCierre.Controls.Add(Me.txtHoraCierre)
        Me.rgrpCierre.Controls.Add(Me.lblOperador)
        Me.rgrpCierre.Controls.Add(Me.txtOperador)
        Me.rgrpCierre.Controls.Add(Me.lblAyudabte)
        Me.rgrpCierre.Controls.Add(Me.txtAyudante)
        Me.rgrpCierre.Controls.Add(Me.txtExtra)
        Me.rgrpCierre.Controls.Add(Me.lblRutaCierre)
        Me.rgrpCierre.Controls.Add(Me.txtRutaCierre)
        Me.rgrpCierre.Controls.Add(Me.lblCelulaCierre)
        Me.rgrpCierre.Controls.Add(Me.txtCelulaCierre)
        Me.rgrpCierre.Controls.Add(Me.lblObservacionesCierre)
        Me.rgrpCierre.Controls.Add(Me.txtObservacionesCierre)
        Me.rgrpCierre.Controls.Add(Me.lblKilometrajeCierre)
        Me.rgrpCierre.Controls.Add(Me.txtKilometrajeCierre)
        Me.rgrpCierre.Controls.Add(Me.lblTotalizadorCierre)
        Me.rgrpCierre.Controls.Add(Me.txtTotalizadorCierre)
        Me.rgrpCierre.Controls.Add(Me.lblGasNoVendido)
        Me.rgrpCierre.Controls.Add(Me.lblPorcentajeNoVendido)
        Me.rgrpCierre.Controls.Add(Me.txtPorcentajeCierre)
        Me.rgrpCierre.Controls.Add(Me.lblLitrosNoVendido)
        Me.rgrpCierre.Controls.Add(Me.txtLitrosCierre)
        Me.rgrpCierre.Controls.Add(Me.lblPesoCierre)
        Me.rgrpCierre.Controls.Add(Me.txtPesoCierre)
        Me.rgrpCierre.Controls.Add(Me.lblDiferencia)
        Me.rgrpCierre.Controls.Add(Me.txtDiferencia)
        Me.rgrpCierre.Controls.Add(Me.lblDiferenciaKilometraje)
        Me.rgrpCierre.Controls.Add(Me.txtDiferenciaKilometraje)
        Me.rgrpCierre.Controls.Add(Me.lblDiferenciaGas)
        Me.rgrpCierre.Controls.Add(Me.txtDiferenciaPorcentaje)
        Me.rgrpCierre.Controls.Add(Me.txtDiferenciaLitros)
        Me.rgrpCierre.Controls.Add(Me.lblDiferenciaTotalizador)
        Me.rgrpCierre.Controls.Add(Me.txtDiferenciaTotalizador)
        Me.rgrpCierre.Controls.Add(Me.lblVenta)
        Me.rgrpCierre.Controls.Add(Me.txtVenta)
        Me.rgrpCierre.Controls.Add(Me.lblLitrosLiquidados)
        Me.rgrpCierre.Controls.Add(Me.txtLitrosLiquidados)
        Me.rgrpCierre.Controls.Add(Me.lblPrecio)
        Me.rgrpCierre.Controls.Add(Me.txtPrecio)
        Me.rgrpCierre.Controls.Add(Me.lblLitrosVendidos)
        Me.rgrpCierre.Controls.Add(Me.txtLitrosVendidos)
        Me.rgrpCierre.Controls.Add(Me.lblLitrosPeso)
        Me.rgrpCierre.Controls.Add(Me.txtLitrosPeso)
        Me.rgrpCierre.Controls.Add(Me.lblImportePeso)
        Me.rgrpCierre.Controls.Add(Me.txtImportePeso)
        Me.rgrpCierre.Controls.Add(Me.lblLitrosPorcentaje)
        Me.rgrpCierre.Controls.Add(Me.lblImportePorcentaje)
        Me.rgrpCierre.Dock = System.Windows.Forms.DockStyle.Top
        Me.rgrpCierre.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rgrpCierre.ForeColor = System.Drawing.Color.Maroon
        Me.rgrpCierre.Location = New System.Drawing.Point(0, 195)
        Me.rgrpCierre.Name = "rgrpCierre"
        Me.rgrpCierre.Size = New System.Drawing.Size(872, 240)
        Me.rgrpCierre.TabIndex = 2
        Me.rgrpCierre.TabStop = False
        Me.rgrpCierre.Text = "Cierre de ruta"
        '
        'txtImportePorcentaje
        '
        Me.txtImportePorcentaje.BackColor = System.Drawing.Color.Gainsboro
        Me.txtImportePorcentaje.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtImportePorcentaje.Enabled = False
        Me.txtImportePorcentaje.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtImportePorcentaje.ForeColor = System.Drawing.Color.Black
        Me.txtImportePorcentaje.Location = New System.Drawing.Point(688, 207)
        Me.txtImportePorcentaje.Name = "txtImportePorcentaje"
        Me.txtImportePorcentaje.ReadOnly = True
        Me.txtImportePorcentaje.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.txtImportePorcentaje.Size = New System.Drawing.Size(64, 27)
        Me.txtImportePorcentaje.TabIndex = 50
        Me.txtImportePorcentaje.TabStop = False
        '
        'txtLitrosPorcentaje
        '
        Me.txtLitrosPorcentaje.BackColor = System.Drawing.Color.Gainsboro
        Me.txtLitrosPorcentaje.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtLitrosPorcentaje.Enabled = False
        Me.txtLitrosPorcentaje.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLitrosPorcentaje.ForeColor = System.Drawing.Color.Black
        Me.txtLitrosPorcentaje.Location = New System.Drawing.Point(616, 207)
        Me.txtLitrosPorcentaje.Name = "txtLitrosPorcentaje"
        Me.txtLitrosPorcentaje.ReadOnly = True
        Me.txtLitrosPorcentaje.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.txtLitrosPorcentaje.Size = New System.Drawing.Size(64, 27)
        Me.txtLitrosPorcentaje.TabIndex = 50
        Me.txtLitrosPorcentaje.TabStop = False
        '
        'lblFechaCierre
        '
        Me.lblFechaCierre.AutoSize = True
        Me.lblFechaCierre.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFechaCierre.ForeColor = System.Drawing.Color.Black
        Me.lblFechaCierre.Location = New System.Drawing.Point(6, 32)
        Me.lblFechaCierre.Name = "lblFechaCierre"
        Me.lblFechaCierre.Size = New System.Drawing.Size(60, 19)
        Me.lblFechaCierre.TabIndex = 50
        Me.lblFechaCierre.Text = "Fecha: "
        Me.lblFechaCierre.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtFechaCierre
        '
        Me.txtFechaCierre.BackColor = System.Drawing.Color.Gainsboro
        Me.txtFechaCierre.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtFechaCierre.Enabled = False
        Me.txtFechaCierre.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFechaCierre.ForeColor = System.Drawing.Color.Black
        Me.txtFechaCierre.Location = New System.Drawing.Point(86, 29)
        Me.txtFechaCierre.Name = "txtFechaCierre"
        Me.txtFechaCierre.ReadOnly = True
        Me.txtFechaCierre.Size = New System.Drawing.Size(111, 27)
        Me.txtFechaCierre.TabIndex = 50
        Me.txtFechaCierre.TabStop = False
        '
        'lblHoraCierre
        '
        Me.lblHoraCierre.AutoSize = True
        Me.lblHoraCierre.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblHoraCierre.ForeColor = System.Drawing.Color.Black
        Me.lblHoraCierre.Location = New System.Drawing.Point(203, 32)
        Me.lblHoraCierre.Name = "lblHoraCierre"
        Me.lblHoraCierre.Size = New System.Drawing.Size(49, 19)
        Me.lblHoraCierre.TabIndex = 50
        Me.lblHoraCierre.Text = "Hora:"
        Me.lblHoraCierre.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtHoraCierre
        '
        Me.txtHoraCierre.BackColor = System.Drawing.Color.Gainsboro
        Me.txtHoraCierre.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtHoraCierre.Enabled = False
        Me.txtHoraCierre.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtHoraCierre.ForeColor = System.Drawing.Color.Black
        Me.txtHoraCierre.Location = New System.Drawing.Point(261, 29)
        Me.txtHoraCierre.Name = "txtHoraCierre"
        Me.txtHoraCierre.ReadOnly = True
        Me.txtHoraCierre.Size = New System.Drawing.Size(104, 27)
        Me.txtHoraCierre.TabIndex = 50
        Me.txtHoraCierre.TabStop = False
        '
        'lblOperador
        '
        Me.lblOperador.AutoSize = True
        Me.lblOperador.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblOperador.ForeColor = System.Drawing.Color.Black
        Me.lblOperador.Location = New System.Drawing.Point(6, 66)
        Me.lblOperador.Name = "lblOperador"
        Me.lblOperador.Size = New System.Drawing.Size(82, 19)
        Me.lblOperador.TabIndex = 50
        Me.lblOperador.Text = "Operador:"
        Me.lblOperador.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtOperador
        '
        Me.txtOperador.BackColor = System.Drawing.Color.Gainsboro
        Me.txtOperador.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtOperador.Enabled = False
        Me.txtOperador.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtOperador.ForeColor = System.Drawing.Color.Black
        Me.txtOperador.Location = New System.Drawing.Point(86, 63)
        Me.txtOperador.Name = "txtOperador"
        Me.txtOperador.ReadOnly = True
        Me.txtOperador.Size = New System.Drawing.Size(282, 27)
        Me.txtOperador.TabIndex = 50
        Me.txtOperador.TabStop = False
        '
        'lblAyudabte
        '
        Me.lblAyudabte.AutoSize = True
        Me.lblAyudabte.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAyudabte.ForeColor = System.Drawing.Color.Black
        Me.lblAyudabte.Location = New System.Drawing.Point(6, 100)
        Me.lblAyudabte.Name = "lblAyudabte"
        Me.lblAyudabte.Size = New System.Drawing.Size(82, 19)
        Me.lblAyudabte.TabIndex = 50
        Me.lblAyudabte.Text = "Ayudante:"
        Me.lblAyudabte.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtAyudante
        '
        Me.txtAyudante.BackColor = System.Drawing.Color.Gainsboro
        Me.txtAyudante.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtAyudante.Enabled = False
        Me.txtAyudante.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAyudante.ForeColor = System.Drawing.Color.Black
        Me.txtAyudante.Location = New System.Drawing.Point(86, 97)
        Me.txtAyudante.Name = "txtAyudante"
        Me.txtAyudante.ReadOnly = True
        Me.txtAyudante.Size = New System.Drawing.Size(282, 27)
        Me.txtAyudante.TabIndex = 50
        Me.txtAyudante.TabStop = False
        '
        'txtExtra
        '
        Me.txtExtra.BackColor = System.Drawing.Color.Gainsboro
        Me.txtExtra.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtExtra.Enabled = False
        Me.txtExtra.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtExtra.ForeColor = System.Drawing.Color.Black
        Me.txtExtra.Location = New System.Drawing.Point(86, 131)
        Me.txtExtra.Name = "txtExtra"
        Me.txtExtra.ReadOnly = True
        Me.txtExtra.Size = New System.Drawing.Size(282, 27)
        Me.txtExtra.TabIndex = 50
        Me.txtExtra.TabStop = False
        '
        'lblRutaCierre
        '
        Me.lblRutaCierre.AutoSize = True
        Me.lblRutaCierre.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRutaCierre.ForeColor = System.Drawing.Color.Black
        Me.lblRutaCierre.Location = New System.Drawing.Point(6, 168)
        Me.lblRutaCierre.Name = "lblRutaCierre"
        Me.lblRutaCierre.Size = New System.Drawing.Size(47, 19)
        Me.lblRutaCierre.TabIndex = 50
        Me.lblRutaCierre.Text = "Ruta:"
        Me.lblRutaCierre.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtRutaCierre
        '
        Me.txtRutaCierre.BackColor = System.Drawing.Color.Gainsboro
        Me.txtRutaCierre.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtRutaCierre.Enabled = False
        Me.txtRutaCierre.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRutaCierre.ForeColor = System.Drawing.Color.Black
        Me.txtRutaCierre.Location = New System.Drawing.Point(86, 165)
        Me.txtRutaCierre.Name = "txtRutaCierre"
        Me.txtRutaCierre.ReadOnly = True
        Me.txtRutaCierre.Size = New System.Drawing.Size(111, 27)
        Me.txtRutaCierre.TabIndex = 50
        Me.txtRutaCierre.TabStop = False
        '
        'lblCelulaCierre
        '
        Me.lblCelulaCierre.AutoSize = True
        Me.lblCelulaCierre.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCelulaCierre.ForeColor = System.Drawing.Color.Black
        Me.lblCelulaCierre.Location = New System.Drawing.Point(203, 168)
        Me.lblCelulaCierre.Name = "lblCelulaCierre"
        Me.lblCelulaCierre.Size = New System.Drawing.Size(58, 19)
        Me.lblCelulaCierre.TabIndex = 50
        Me.lblCelulaCierre.Text = "Célula:"
        Me.lblCelulaCierre.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtCelulaCierre
        '
        Me.txtCelulaCierre.BackColor = System.Drawing.Color.Gainsboro
        Me.txtCelulaCierre.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCelulaCierre.Enabled = False
        Me.txtCelulaCierre.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCelulaCierre.ForeColor = System.Drawing.Color.Black
        Me.txtCelulaCierre.Location = New System.Drawing.Point(261, 165)
        Me.txtCelulaCierre.Name = "txtCelulaCierre"
        Me.txtCelulaCierre.ReadOnly = True
        Me.txtCelulaCierre.Size = New System.Drawing.Size(104, 27)
        Me.txtCelulaCierre.TabIndex = 50
        Me.txtCelulaCierre.TabStop = False
        '
        'lblObservacionesCierre
        '
        Me.lblObservacionesCierre.AutoSize = True
        Me.lblObservacionesCierre.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblObservacionesCierre.ForeColor = System.Drawing.Color.Black
        Me.lblObservacionesCierre.Location = New System.Drawing.Point(6, 200)
        Me.lblObservacionesCierre.Name = "lblObservacionesCierre"
        Me.lblObservacionesCierre.Size = New System.Drawing.Size(48, 19)
        Me.lblObservacionesCierre.TabIndex = 8
        Me.lblObservacionesCierre.Text = "&Obs.:"
        '
        'txtObservacionesCierre
        '
        Me.txtObservacionesCierre.BackColor = System.Drawing.Color.White
        Me.txtObservacionesCierre.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtObservacionesCierre.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtObservacionesCierre.ForeColor = System.Drawing.Color.Black
        Me.txtObservacionesCierre.Location = New System.Drawing.Point(86, 200)
        Me.txtObservacionesCierre.Multiline = True
        Me.txtObservacionesCierre.Name = "txtObservacionesCierre"
        Me.txtObservacionesCierre.Size = New System.Drawing.Size(282, 32)
        Me.txtObservacionesCierre.TabIndex = 9
        '
        'lblKilometrajeCierre
        '
        Me.lblKilometrajeCierre.AutoSize = True
        Me.lblKilometrajeCierre.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblKilometrajeCierre.ForeColor = System.Drawing.Color.Black
        Me.lblKilometrajeCierre.Location = New System.Drawing.Point(400, 34)
        Me.lblKilometrajeCierre.Name = "lblKilometrajeCierre"
        Me.lblKilometrajeCierre.Size = New System.Drawing.Size(78, 16)
        Me.lblKilometrajeCierre.TabIndex = 0
        Me.lblKilometrajeCierre.Text = "&Kilometraje:"
        '
        'txtKilometrajeCierre
        '
        Me.txtKilometrajeCierre.BackColor = System.Drawing.Color.White
        Me.txtKilometrajeCierre.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtKilometrajeCierre.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtKilometrajeCierre.ForeColor = System.Drawing.Color.Black
        Me.txtKilometrajeCierre.Location = New System.Drawing.Point(384, 51)
        Me.txtKilometrajeCierre.Name = "txtKilometrajeCierre"
        Me.txtKilometrajeCierre.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.txtKilometrajeCierre.Size = New System.Drawing.Size(96, 27)
        Me.txtKilometrajeCierre.TabIndex = 1
        '
        'lblTotalizadorCierre
        '
        Me.lblTotalizadorCierre.AutoSize = True
        Me.lblTotalizadorCierre.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalizadorCierre.ForeColor = System.Drawing.Color.Black
        Me.lblTotalizadorCierre.Location = New System.Drawing.Point(491, 34)
        Me.lblTotalizadorCierre.Name = "lblTotalizadorCierre"
        Me.lblTotalizadorCierre.Size = New System.Drawing.Size(119, 16)
        Me.lblTotalizadorCierre.TabIndex = 2
        Me.lblTotalizadorCierre.Text = "Lectura &totalizador:"
        '
        'txtTotalizadorCierre
        '
        Me.txtTotalizadorCierre.BackColor = System.Drawing.Color.White
        Me.txtTotalizadorCierre.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTotalizadorCierre.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalizadorCierre.ForeColor = System.Drawing.Color.Black
        Me.txtTotalizadorCierre.Location = New System.Drawing.Point(502, 51)
        Me.txtTotalizadorCierre.Name = "txtTotalizadorCierre"
        Me.txtTotalizadorCierre.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.txtTotalizadorCierre.Size = New System.Drawing.Size(96, 27)
        Me.txtTotalizadorCierre.TabIndex = 3
        '
        'lblGasNoVendido
        '
        Me.lblGasNoVendido.AutoSize = True
        Me.lblGasNoVendido.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblGasNoVendido.ForeColor = System.Drawing.Color.Black
        Me.lblGasNoVendido.Location = New System.Drawing.Point(624, 19)
        Me.lblGasNoVendido.Name = "lblGasNoVendido"
        Me.lblGasNoVendido.Size = New System.Drawing.Size(138, 16)
        Me.lblGasNoVendido.TabIndex = 50
        Me.lblGasNoVendido.Text = "** Gas No Vendido **"
        Me.lblGasNoVendido.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblPorcentajeNoVendido
        '
        Me.lblPorcentajeNoVendido.AutoSize = True
        Me.lblPorcentajeNoVendido.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPorcentajeNoVendido.ForeColor = System.Drawing.Color.Black
        Me.lblPorcentajeNoVendido.Location = New System.Drawing.Point(641, 34)
        Me.lblPorcentajeNoVendido.Name = "lblPorcentajeNoVendido"
        Me.lblPorcentajeNoVendido.Size = New System.Drawing.Size(20, 16)
        Me.lblPorcentajeNoVendido.TabIndex = 4
        Me.lblPorcentajeNoVendido.Text = "&%"
        '
        'txtPorcentajeCierre
        '
        Me.txtPorcentajeCierre.BackColor = System.Drawing.Color.White
        Me.txtPorcentajeCierre.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPorcentajeCierre.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPorcentajeCierre.ForeColor = System.Drawing.Color.Black
        Me.txtPorcentajeCierre.Location = New System.Drawing.Point(616, 51)
        Me.txtPorcentajeCierre.MaxLength = 4
        Me.txtPorcentajeCierre.Name = "txtPorcentajeCierre"
        Me.txtPorcentajeCierre.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.txtPorcentajeCierre.Size = New System.Drawing.Size(64, 27)
        Me.txtPorcentajeCierre.TabIndex = 5
        '
        'lblLitrosNoVendido
        '
        Me.lblLitrosNoVendido.AutoSize = True
        Me.lblLitrosNoVendido.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLitrosNoVendido.ForeColor = System.Drawing.Color.Black
        Me.lblLitrosNoVendido.Location = New System.Drawing.Point(705, 34)
        Me.lblLitrosNoVendido.Name = "lblLitrosNoVendido"
        Me.lblLitrosNoVendido.Size = New System.Drawing.Size(39, 16)
        Me.lblLitrosNoVendido.TabIndex = 50
        Me.lblLitrosNoVendido.Text = "Litros"
        '
        'txtLitrosCierre
        '
        Me.txtLitrosCierre.BackColor = System.Drawing.Color.Gainsboro
        Me.txtLitrosCierre.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtLitrosCierre.Enabled = False
        Me.txtLitrosCierre.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLitrosCierre.ForeColor = System.Drawing.Color.Black
        Me.txtLitrosCierre.Location = New System.Drawing.Point(688, 51)
        Me.txtLitrosCierre.Name = "txtLitrosCierre"
        Me.txtLitrosCierre.ReadOnly = True
        Me.txtLitrosCierre.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.txtLitrosCierre.Size = New System.Drawing.Size(64, 27)
        Me.txtLitrosCierre.TabIndex = 50
        Me.txtLitrosCierre.TabStop = False
        '
        'lblPesoCierre
        '
        Me.lblPesoCierre.AutoSize = True
        Me.lblPesoCierre.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPesoCierre.ForeColor = System.Drawing.Color.Black
        Me.lblPesoCierre.Location = New System.Drawing.Point(784, 34)
        Me.lblPesoCierre.Name = "lblPesoCierre"
        Me.lblPesoCierre.Size = New System.Drawing.Size(78, 16)
        Me.lblPesoCierre.TabIndex = 6
        Me.lblPesoCierre.Text = "&Peso (Kgs.):"
        '
        'txtPesoCierre
        '
        Me.txtPesoCierre.BackColor = System.Drawing.Color.White
        Me.txtPesoCierre.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPesoCierre.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPesoCierre.ForeColor = System.Drawing.Color.Black
        Me.txtPesoCierre.Location = New System.Drawing.Point(768, 51)
        Me.txtPesoCierre.MaxLength = 20000
        Me.txtPesoCierre.Name = "txtPesoCierre"
        Me.txtPesoCierre.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.txtPesoCierre.Size = New System.Drawing.Size(96, 27)
        Me.txtPesoCierre.TabIndex = 7
        '
        'lblDiferencia
        '
        Me.lblDiferencia.AutoSize = True
        Me.lblDiferencia.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDiferencia.ForeColor = System.Drawing.Color.Black
        Me.lblDiferencia.Location = New System.Drawing.Point(768, 191)
        Me.lblDiferencia.Name = "lblDiferencia"
        Me.lblDiferencia.Size = New System.Drawing.Size(102, 16)
        Me.lblDiferencia.TabIndex = 50
        Me.lblDiferencia.Text = "Diferencia litros:"
        '
        'txtDiferencia
        '
        Me.txtDiferencia.BackColor = System.Drawing.Color.Gainsboro
        Me.txtDiferencia.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDiferencia.Enabled = False
        Me.txtDiferencia.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDiferencia.ForeColor = System.Drawing.Color.Black
        Me.txtDiferencia.Location = New System.Drawing.Point(768, 207)
        Me.txtDiferencia.Name = "txtDiferencia"
        Me.txtDiferencia.ReadOnly = True
        Me.txtDiferencia.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.txtDiferencia.Size = New System.Drawing.Size(96, 27)
        Me.txtDiferencia.TabIndex = 50
        Me.txtDiferencia.TabStop = False
        '
        'lblDiferenciaKilometraje
        '
        Me.lblDiferenciaKilometraje.AutoSize = True
        Me.lblDiferenciaKilometraje.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDiferenciaKilometraje.ForeColor = System.Drawing.Color.Black
        Me.lblDiferenciaKilometraje.Location = New System.Drawing.Point(398, 88)
        Me.lblDiferenciaKilometraje.Name = "lblDiferenciaKilometraje"
        Me.lblDiferenciaKilometraje.Size = New System.Drawing.Size(70, 16)
        Me.lblDiferenciaKilometraje.TabIndex = 50
        Me.lblDiferenciaKilometraje.Text = "Diferencia:"
        '
        'txtDiferenciaKilometraje
        '
        Me.txtDiferenciaKilometraje.BackColor = System.Drawing.Color.Gainsboro
        Me.txtDiferenciaKilometraje.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDiferenciaKilometraje.Enabled = False
        Me.txtDiferenciaKilometraje.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDiferenciaKilometraje.ForeColor = System.Drawing.Color.MediumBlue
        Me.txtDiferenciaKilometraje.Location = New System.Drawing.Point(384, 105)
        Me.txtDiferenciaKilometraje.Name = "txtDiferenciaKilometraje"
        Me.txtDiferenciaKilometraje.ReadOnly = True
        Me.txtDiferenciaKilometraje.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.txtDiferenciaKilometraje.Size = New System.Drawing.Size(96, 27)
        Me.txtDiferenciaKilometraje.TabIndex = 50
        Me.txtDiferenciaKilometraje.TabStop = False
        '
        'lblDiferenciaGas
        '
        Me.lblDiferenciaGas.AutoSize = True
        Me.lblDiferenciaGas.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDiferenciaGas.ForeColor = System.Drawing.Color.Black
        Me.lblDiferenciaGas.Location = New System.Drawing.Point(633, 88)
        Me.lblDiferenciaGas.Name = "lblDiferenciaGas"
        Me.lblDiferenciaGas.Size = New System.Drawing.Size(121, 16)
        Me.lblDiferenciaGas.TabIndex = 50
        Me.lblDiferenciaGas.Text = "*** Diferencia ***"
        Me.lblDiferenciaGas.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtDiferenciaPorcentaje
        '
        Me.txtDiferenciaPorcentaje.BackColor = System.Drawing.Color.Gainsboro
        Me.txtDiferenciaPorcentaje.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDiferenciaPorcentaje.Enabled = False
        Me.txtDiferenciaPorcentaje.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDiferenciaPorcentaje.ForeColor = System.Drawing.Color.MediumBlue
        Me.txtDiferenciaPorcentaje.Location = New System.Drawing.Point(616, 105)
        Me.txtDiferenciaPorcentaje.Name = "txtDiferenciaPorcentaje"
        Me.txtDiferenciaPorcentaje.ReadOnly = True
        Me.txtDiferenciaPorcentaje.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.txtDiferenciaPorcentaje.Size = New System.Drawing.Size(64, 27)
        Me.txtDiferenciaPorcentaje.TabIndex = 50
        Me.txtDiferenciaPorcentaje.TabStop = False
        '
        'txtDiferenciaLitros
        '
        Me.txtDiferenciaLitros.BackColor = System.Drawing.Color.Gainsboro
        Me.txtDiferenciaLitros.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDiferenciaLitros.Enabled = False
        Me.txtDiferenciaLitros.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDiferenciaLitros.ForeColor = System.Drawing.Color.MediumBlue
        Me.txtDiferenciaLitros.Location = New System.Drawing.Point(688, 105)
        Me.txtDiferenciaLitros.Name = "txtDiferenciaLitros"
        Me.txtDiferenciaLitros.ReadOnly = True
        Me.txtDiferenciaLitros.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.txtDiferenciaLitros.Size = New System.Drawing.Size(64, 27)
        Me.txtDiferenciaLitros.TabIndex = 50
        Me.txtDiferenciaLitros.TabStop = False
        '
        'lblDiferenciaTotalizador
        '
        Me.lblDiferenciaTotalizador.AutoSize = True
        Me.lblDiferenciaTotalizador.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDiferenciaTotalizador.ForeColor = System.Drawing.Color.Black
        Me.lblDiferenciaTotalizador.Location = New System.Drawing.Point(516, 88)
        Me.lblDiferenciaTotalizador.Name = "lblDiferenciaTotalizador"
        Me.lblDiferenciaTotalizador.Size = New System.Drawing.Size(70, 16)
        Me.lblDiferenciaTotalizador.TabIndex = 50
        Me.lblDiferenciaTotalizador.Text = "Diferencia:"
        '
        'txtDiferenciaTotalizador
        '
        Me.txtDiferenciaTotalizador.BackColor = System.Drawing.Color.Gainsboro
        Me.txtDiferenciaTotalizador.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDiferenciaTotalizador.Enabled = False
        Me.txtDiferenciaTotalizador.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDiferenciaTotalizador.ForeColor = System.Drawing.Color.MediumBlue
        Me.txtDiferenciaTotalizador.Location = New System.Drawing.Point(502, 105)
        Me.txtDiferenciaTotalizador.Name = "txtDiferenciaTotalizador"
        Me.txtDiferenciaTotalizador.ReadOnly = True
        Me.txtDiferenciaTotalizador.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.txtDiferenciaTotalizador.Size = New System.Drawing.Size(96, 27)
        Me.txtDiferenciaTotalizador.TabIndex = 50
        Me.txtDiferenciaTotalizador.TabStop = False
        '
        'lblVenta
        '
        Me.lblVenta.AutoSize = True
        Me.lblVenta.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblVenta.ForeColor = System.Drawing.Color.Black
        Me.lblVenta.Location = New System.Drawing.Point(768, 88)
        Me.lblVenta.Name = "lblVenta"
        Me.lblVenta.Size = New System.Drawing.Size(88, 16)
        Me.lblVenta.TabIndex = 50
        Me.lblVenta.Text = "Venta del día:"
        '
        'txtVenta
        '
        Me.txtVenta.BackColor = System.Drawing.Color.Gainsboro
        Me.txtVenta.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtVenta.Enabled = False
        Me.txtVenta.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtVenta.ForeColor = System.Drawing.Color.MediumBlue
        Me.txtVenta.Location = New System.Drawing.Point(768, 105)
        Me.txtVenta.Name = "txtVenta"
        Me.txtVenta.ReadOnly = True
        Me.txtVenta.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.txtVenta.Size = New System.Drawing.Size(96, 27)
        Me.txtVenta.TabIndex = 50
        Me.txtVenta.TabStop = False
        '
        'lblLitrosLiquidados
        '
        Me.lblLitrosLiquidados.AutoSize = True
        Me.lblLitrosLiquidados.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLitrosLiquidados.ForeColor = System.Drawing.Color.Black
        Me.lblLitrosLiquidados.Location = New System.Drawing.Point(503, 140)
        Me.lblLitrosLiquidados.Name = "lblLitrosLiquidados"
        Me.lblLitrosLiquidados.Size = New System.Drawing.Size(94, 16)
        Me.lblLitrosLiquidados.TabIndex = 50
        Me.lblLitrosLiquidados.Text = "Lts. liquidados:"
        '
        'txtLitrosLiquidados
        '
        Me.txtLitrosLiquidados.BackColor = System.Drawing.Color.Gainsboro
        Me.txtLitrosLiquidados.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtLitrosLiquidados.Enabled = False
        Me.txtLitrosLiquidados.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLitrosLiquidados.ForeColor = System.Drawing.Color.MediumBlue
        Me.txtLitrosLiquidados.Location = New System.Drawing.Point(502, 156)
        Me.txtLitrosLiquidados.Name = "txtLitrosLiquidados"
        Me.txtLitrosLiquidados.ReadOnly = True
        Me.txtLitrosLiquidados.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.txtLitrosLiquidados.Size = New System.Drawing.Size(96, 27)
        Me.txtLitrosLiquidados.TabIndex = 50
        Me.txtLitrosLiquidados.TabStop = False
        '
        'lblPrecio
        '
        Me.lblPrecio.AutoSize = True
        Me.lblPrecio.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPrecio.ForeColor = System.Drawing.Color.Black
        Me.lblPrecio.Location = New System.Drawing.Point(616, 140)
        Me.lblPrecio.Name = "lblPrecio"
        Me.lblPrecio.Size = New System.Drawing.Size(84, 16)
        Me.lblPrecio.TabIndex = 50
        Me.lblPrecio.Text = "Precio x litro:"
        '
        'txtPrecio
        '
        Me.txtPrecio.BackColor = System.Drawing.Color.Gainsboro
        Me.txtPrecio.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPrecio.Enabled = False
        Me.txtPrecio.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPrecio.ForeColor = System.Drawing.Color.MediumBlue
        Me.txtPrecio.Location = New System.Drawing.Point(616, 156)
        Me.txtPrecio.Name = "txtPrecio"
        Me.txtPrecio.ReadOnly = True
        Me.txtPrecio.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.txtPrecio.Size = New System.Drawing.Size(64, 27)
        Me.txtPrecio.TabIndex = 50
        Me.txtPrecio.TabStop = False
        '
        'lblLitrosVendidos
        '
        Me.lblLitrosVendidos.AutoSize = True
        Me.lblLitrosVendidos.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLitrosVendidos.ForeColor = System.Drawing.Color.Black
        Me.lblLitrosVendidos.Location = New System.Drawing.Point(768, 138)
        Me.lblLitrosVendidos.Name = "lblLitrosVendidos"
        Me.lblLitrosVendidos.Size = New System.Drawing.Size(98, 16)
        Me.lblLitrosVendidos.TabIndex = 50
        Me.lblLitrosVendidos.Text = "Litros vendidos:"
        '
        'txtLitrosVendidos
        '
        Me.txtLitrosVendidos.BackColor = System.Drawing.Color.Gainsboro
        Me.txtLitrosVendidos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtLitrosVendidos.Enabled = False
        Me.txtLitrosVendidos.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLitrosVendidos.ForeColor = System.Drawing.Color.MediumBlue
        Me.txtLitrosVendidos.Location = New System.Drawing.Point(768, 156)
        Me.txtLitrosVendidos.Name = "txtLitrosVendidos"
        Me.txtLitrosVendidos.ReadOnly = True
        Me.txtLitrosVendidos.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.txtLitrosVendidos.Size = New System.Drawing.Size(96, 27)
        Me.txtLitrosVendidos.TabIndex = 50
        Me.txtLitrosVendidos.TabStop = False
        '
        'lblLitrosPeso
        '
        Me.lblLitrosPeso.AutoSize = True
        Me.lblLitrosPeso.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLitrosPeso.ForeColor = System.Drawing.Color.Black
        Me.lblLitrosPeso.Location = New System.Drawing.Point(387, 191)
        Me.lblLitrosPeso.Name = "lblLitrosPeso"
        Me.lblLitrosPeso.Size = New System.Drawing.Size(92, 16)
        Me.lblLitrosPeso.TabIndex = 50
        Me.lblLitrosPeso.Text = "Litros a pagar:"
        '
        'txtLitrosPeso
        '
        Me.txtLitrosPeso.BackColor = System.Drawing.Color.Gainsboro
        Me.txtLitrosPeso.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtLitrosPeso.Enabled = False
        Me.txtLitrosPeso.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLitrosPeso.ForeColor = System.Drawing.Color.Black
        Me.txtLitrosPeso.Location = New System.Drawing.Point(384, 207)
        Me.txtLitrosPeso.Name = "txtLitrosPeso"
        Me.txtLitrosPeso.ReadOnly = True
        Me.txtLitrosPeso.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.txtLitrosPeso.Size = New System.Drawing.Size(96, 27)
        Me.txtLitrosPeso.TabIndex = 50
        Me.txtLitrosPeso.TabStop = False
        '
        'lblImportePeso
        '
        Me.lblImportePeso.AutoSize = True
        Me.lblImportePeso.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblImportePeso.ForeColor = System.Drawing.Color.Black
        Me.lblImportePeso.Location = New System.Drawing.Point(522, 191)
        Me.lblImportePeso.Name = "lblImportePeso"
        Me.lblImportePeso.Size = New System.Drawing.Size(58, 16)
        Me.lblImportePeso.TabIndex = 50
        Me.lblImportePeso.Text = "Importe:"
        '
        'txtImportePeso
        '
        Me.txtImportePeso.BackColor = System.Drawing.Color.Gainsboro
        Me.txtImportePeso.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtImportePeso.Enabled = False
        Me.txtImportePeso.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtImportePeso.ForeColor = System.Drawing.Color.Black
        Me.txtImportePeso.Location = New System.Drawing.Point(502, 207)
        Me.txtImportePeso.Name = "txtImportePeso"
        Me.txtImportePeso.ReadOnly = True
        Me.txtImportePeso.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.txtImportePeso.Size = New System.Drawing.Size(96, 27)
        Me.txtImportePeso.TabIndex = 50
        Me.txtImportePeso.TabStop = False
        '
        'lblLitrosPorcentaje
        '
        Me.lblLitrosPorcentaje.AutoSize = True
        Me.lblLitrosPorcentaje.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLitrosPorcentaje.ForeColor = System.Drawing.Color.Black
        Me.lblLitrosPorcentaje.Location = New System.Drawing.Point(616, 191)
        Me.lblLitrosPorcentaje.Name = "lblLitrosPorcentaje"
        Me.lblLitrosPorcentaje.Size = New System.Drawing.Size(78, 16)
        Me.lblLitrosPorcentaje.TabIndex = 50
        Me.lblLitrosPorcentaje.Text = "Lit. a pagar:"
        '
        'lblImportePorcentaje
        '
        Me.lblImportePorcentaje.AutoSize = True
        Me.lblImportePorcentaje.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblImportePorcentaje.ForeColor = System.Drawing.Color.Black
        Me.lblImportePorcentaje.Location = New System.Drawing.Point(688, 191)
        Me.lblImportePorcentaje.Name = "lblImportePorcentaje"
        Me.lblImportePorcentaje.Size = New System.Drawing.Size(58, 16)
        Me.lblImportePorcentaje.TabIndex = 50
        Me.lblImportePorcentaje.Text = "Importe:"
        '
        'rgrpApertura
        '
        Me.rgrpApertura.BorderColor = System.Drawing.Color.Green
        Me.rgrpApertura.Controls.Add(Me.txtLitrosCargados)
        Me.rgrpApertura.Controls.Add(Me.lblLitrosCargados)
        Me.rgrpApertura.Controls.Add(Me.lblFechaApertura)
        Me.rgrpApertura.Controls.Add(Me.lblRuta)
        Me.rgrpApertura.Controls.Add(Me.lblCapacidad)
        Me.rgrpApertura.Controls.Add(Me.lblHoraApertura)
        Me.rgrpApertura.Controls.Add(Me.lblCelula)
        Me.rgrpApertura.Controls.Add(Me.lblPlacas)
        Me.rgrpApertura.Controls.Add(Me.txtFechaApertura)
        Me.rgrpApertura.Controls.Add(Me.txtRutaApertura)
        Me.rgrpApertura.Controls.Add(Me.txtCapacidad)
        Me.rgrpApertura.Controls.Add(Me.txtHoraApertura)
        Me.rgrpApertura.Controls.Add(Me.txtCelulaApertura)
        Me.rgrpApertura.Controls.Add(Me.txtPlacas)
        Me.rgrpApertura.Controls.Add(Me.lblKilometrajeApertura)
        Me.rgrpApertura.Controls.Add(Me.txtKilometrajeApertura)
        Me.rgrpApertura.Controls.Add(Me.lblTotalizadorApertura)
        Me.rgrpApertura.Controls.Add(Me.txtTotalizadorApertura)
        Me.rgrpApertura.Controls.Add(Me.lblGasInicial)
        Me.rgrpApertura.Controls.Add(Me.lblPercentajeApertura)
        Me.rgrpApertura.Controls.Add(Me.txtPorcentajeApertura)
        Me.rgrpApertura.Controls.Add(Me.lblLitrosApertura)
        Me.rgrpApertura.Controls.Add(Me.txtLitrosApertura)
        Me.rgrpApertura.Controls.Add(Me.lblPesoApertura)
        Me.rgrpApertura.Controls.Add(Me.txtPesoApertura)
        Me.rgrpApertura.Controls.Add(Me.lblObservacionesApertura)
        Me.rgrpApertura.Controls.Add(Me.txtObservacionesApertura)
        Me.rgrpApertura.Dock = System.Windows.Forms.DockStyle.Top
        Me.rgrpApertura.Font = New System.Drawing.Font("Tahoma", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rgrpApertura.ForeColor = System.Drawing.Color.DarkGreen
        Me.rgrpApertura.Location = New System.Drawing.Point(0, 50)
        Me.rgrpApertura.Name = "rgrpApertura"
        Me.rgrpApertura.Size = New System.Drawing.Size(872, 145)
        Me.rgrpApertura.TabIndex = 1
        Me.rgrpApertura.TabStop = False
        Me.rgrpApertura.Text = "Carga inicial"
        '
        'txtLitrosCargados
        '
        Me.txtLitrosCargados.BackColor = System.Drawing.Color.White
        Me.txtLitrosCargados.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtLitrosCargados.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLitrosCargados.ForeColor = System.Drawing.Color.Black
        Me.txtLitrosCargados.Location = New System.Drawing.Point(128, 112)
        Me.txtLitrosCargados.Name = "txtLitrosCargados"
        Me.txtLitrosCargados.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.txtLitrosCargados.Size = New System.Drawing.Size(144, 27)
        Me.txtLitrosCargados.TabIndex = 7
        '
        'lblLitrosCargados
        '
        Me.lblLitrosCargados.AutoSize = True
        Me.lblLitrosCargados.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.lblLitrosCargados.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLitrosCargados.ForeColor = System.Drawing.Color.Black
        Me.lblLitrosCargados.Location = New System.Drawing.Point(6, 115)
        Me.lblLitrosCargados.Name = "lblLitrosCargados"
        Me.lblLitrosCargados.Size = New System.Drawing.Size(122, 19)
        Me.lblLitrosCargados.TabIndex = 51
        Me.lblLitrosCargados.Text = "Litros cargados:"
        '
        'lblFechaApertura
        '
        Me.lblFechaApertura.AutoSize = True
        Me.lblFechaApertura.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.lblFechaApertura.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFechaApertura.ForeColor = System.Drawing.Color.Black
        Me.lblFechaApertura.Location = New System.Drawing.Point(6, 24)
        Me.lblFechaApertura.Name = "lblFechaApertura"
        Me.lblFechaApertura.Size = New System.Drawing.Size(60, 19)
        Me.lblFechaApertura.TabIndex = 50
        Me.lblFechaApertura.Text = "Fecha: "
        Me.lblFechaApertura.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblRuta
        '
        Me.lblRuta.AutoSize = True
        Me.lblRuta.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.lblRuta.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRuta.ForeColor = System.Drawing.Color.Black
        Me.lblRuta.Location = New System.Drawing.Point(6, 54)
        Me.lblRuta.Name = "lblRuta"
        Me.lblRuta.Size = New System.Drawing.Size(47, 19)
        Me.lblRuta.TabIndex = 50
        Me.lblRuta.Text = "Ruta:"
        Me.lblRuta.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblCapacidad
        '
        Me.lblCapacidad.AutoSize = True
        Me.lblCapacidad.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.lblCapacidad.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCapacidad.ForeColor = System.Drawing.Color.Black
        Me.lblCapacidad.Location = New System.Drawing.Point(6, 84)
        Me.lblCapacidad.Name = "lblCapacidad"
        Me.lblCapacidad.Size = New System.Drawing.Size(90, 19)
        Me.lblCapacidad.TabIndex = 50
        Me.lblCapacidad.Text = "Cap 100%:"
        Me.lblCapacidad.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblHoraApertura
        '
        Me.lblHoraApertura.AutoSize = True
        Me.lblHoraApertura.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.lblHoraApertura.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.lblHoraApertura.ForeColor = System.Drawing.Color.Black
        Me.lblHoraApertura.Location = New System.Drawing.Point(216, 24)
        Me.lblHoraApertura.Name = "lblHoraApertura"
        Me.lblHoraApertura.Size = New System.Drawing.Size(49, 19)
        Me.lblHoraApertura.TabIndex = 52
        Me.lblHoraApertura.Text = "Hora:"
        '
        'lblCelula
        '
        Me.lblCelula.AutoSize = True
        Me.lblCelula.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.lblCelula.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.lblCelula.ForeColor = System.Drawing.Color.Black
        Me.lblCelula.Location = New System.Drawing.Point(216, 54)
        Me.lblCelula.Name = "lblCelula"
        Me.lblCelula.Size = New System.Drawing.Size(58, 19)
        Me.lblCelula.TabIndex = 53
        Me.lblCelula.Text = "Célula:"
        '
        'lblPlacas
        '
        Me.lblPlacas.AutoSize = True
        Me.lblPlacas.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.lblPlacas.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPlacas.ForeColor = System.Drawing.Color.Black
        Me.lblPlacas.Location = New System.Drawing.Point(217, 84)
        Me.lblPlacas.Name = "lblPlacas"
        Me.lblPlacas.Size = New System.Drawing.Size(58, 19)
        Me.lblPlacas.TabIndex = 50
        Me.lblPlacas.Text = "Placas:"
        '
        'txtFechaApertura
        '
        Me.txtFechaApertura.BackColor = System.Drawing.Color.Gainsboro
        Me.txtFechaApertura.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtFechaApertura.Enabled = False
        Me.txtFechaApertura.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFechaApertura.ForeColor = System.Drawing.Color.Black
        Me.txtFechaApertura.Location = New System.Drawing.Point(96, 21)
        Me.txtFechaApertura.Name = "txtFechaApertura"
        Me.txtFechaApertura.ReadOnly = True
        Me.txtFechaApertura.Size = New System.Drawing.Size(104, 27)
        Me.txtFechaApertura.TabIndex = 0
        Me.txtFechaApertura.TabStop = False
        '
        'txtRutaApertura
        '
        Me.txtRutaApertura.BackColor = System.Drawing.Color.Gainsboro
        Me.txtRutaApertura.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtRutaApertura.Enabled = False
        Me.txtRutaApertura.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRutaApertura.ForeColor = System.Drawing.Color.Black
        Me.txtRutaApertura.Location = New System.Drawing.Point(96, 51)
        Me.txtRutaApertura.Name = "txtRutaApertura"
        Me.txtRutaApertura.ReadOnly = True
        Me.txtRutaApertura.Size = New System.Drawing.Size(104, 27)
        Me.txtRutaApertura.TabIndex = 50
        Me.txtRutaApertura.TabStop = False
        '
        'txtCapacidad
        '
        Me.txtCapacidad.BackColor = System.Drawing.Color.Gainsboro
        Me.txtCapacidad.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCapacidad.Enabled = False
        Me.txtCapacidad.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCapacidad.ForeColor = System.Drawing.Color.MediumBlue
        Me.txtCapacidad.Location = New System.Drawing.Point(96, 81)
        Me.txtCapacidad.Name = "txtCapacidad"
        Me.txtCapacidad.ReadOnly = True
        Me.txtCapacidad.Size = New System.Drawing.Size(104, 27)
        Me.txtCapacidad.TabIndex = 0
        Me.txtCapacidad.TabStop = False
        '
        'txtHoraApertura
        '
        Me.txtHoraApertura.BackColor = System.Drawing.Color.Gainsboro
        Me.txtHoraApertura.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtHoraApertura.Enabled = False
        Me.txtHoraApertura.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtHoraApertura.ForeColor = System.Drawing.Color.Black
        Me.txtHoraApertura.Location = New System.Drawing.Point(275, 21)
        Me.txtHoraApertura.Name = "txtHoraApertura"
        Me.txtHoraApertura.ReadOnly = True
        Me.txtHoraApertura.Size = New System.Drawing.Size(104, 27)
        Me.txtHoraApertura.TabIndex = 50
        Me.txtHoraApertura.TabStop = False
        '
        'txtCelulaApertura
        '
        Me.txtCelulaApertura.BackColor = System.Drawing.Color.Gainsboro
        Me.txtCelulaApertura.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCelulaApertura.Enabled = False
        Me.txtCelulaApertura.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.txtCelulaApertura.ForeColor = System.Drawing.Color.Black
        Me.txtCelulaApertura.Location = New System.Drawing.Point(275, 51)
        Me.txtCelulaApertura.Name = "txtCelulaApertura"
        Me.txtCelulaApertura.ReadOnly = True
        Me.txtCelulaApertura.Size = New System.Drawing.Size(104, 27)
        Me.txtCelulaApertura.TabIndex = 54
        Me.txtCelulaApertura.TabStop = False
        '
        'txtPlacas
        '
        Me.txtPlacas.BackColor = System.Drawing.Color.Gainsboro
        Me.txtPlacas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPlacas.Enabled = False
        Me.txtPlacas.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPlacas.ForeColor = System.Drawing.Color.Black
        Me.txtPlacas.Location = New System.Drawing.Point(275, 81)
        Me.txtPlacas.Name = "txtPlacas"
        Me.txtPlacas.ReadOnly = True
        Me.txtPlacas.Size = New System.Drawing.Size(104, 27)
        Me.txtPlacas.TabIndex = 50
        Me.txtPlacas.TabStop = False
        '
        'lblKilometrajeApertura
        '
        Me.lblKilometrajeApertura.AutoSize = True
        Me.lblKilometrajeApertura.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblKilometrajeApertura.ForeColor = System.Drawing.Color.Black
        Me.lblKilometrajeApertura.Location = New System.Drawing.Point(401, 26)
        Me.lblKilometrajeApertura.Name = "lblKilometrajeApertura"
        Me.lblKilometrajeApertura.Size = New System.Drawing.Size(78, 16)
        Me.lblKilometrajeApertura.TabIndex = 0
        Me.lblKilometrajeApertura.Text = "&Kilometraje:"
        '
        'txtKilometrajeApertura
        '
        Me.txtKilometrajeApertura.AcceptsReturn = True
        Me.txtKilometrajeApertura.BackColor = System.Drawing.Color.White
        Me.txtKilometrajeApertura.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtKilometrajeApertura.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtKilometrajeApertura.ForeColor = System.Drawing.Color.Black
        Me.txtKilometrajeApertura.Location = New System.Drawing.Point(391, 50)
        Me.txtKilometrajeApertura.Name = "txtKilometrajeApertura"
        Me.txtKilometrajeApertura.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.txtKilometrajeApertura.Size = New System.Drawing.Size(96, 27)
        Me.txtKilometrajeApertura.TabIndex = 1
        '
        'lblTotalizadorApertura
        '
        Me.lblTotalizadorApertura.AutoSize = True
        Me.lblTotalizadorApertura.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalizadorApertura.ForeColor = System.Drawing.Color.Black
        Me.lblTotalizadorApertura.Location = New System.Drawing.Point(493, 27)
        Me.lblTotalizadorApertura.Name = "lblTotalizadorApertura"
        Me.lblTotalizadorApertura.Size = New System.Drawing.Size(119, 16)
        Me.lblTotalizadorApertura.TabIndex = 50
        Me.lblTotalizadorApertura.Text = "Lectura &totalizador:"
        '
        'txtTotalizadorApertura
        '
        Me.txtTotalizadorApertura.BackColor = System.Drawing.Color.Gainsboro
        Me.txtTotalizadorApertura.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTotalizadorApertura.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalizadorApertura.ForeColor = System.Drawing.Color.Black
        Me.txtTotalizadorApertura.Location = New System.Drawing.Point(504, 50)
        Me.txtTotalizadorApertura.Name = "txtTotalizadorApertura"
        Me.txtTotalizadorApertura.ReadOnly = True
        Me.txtTotalizadorApertura.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.txtTotalizadorApertura.Size = New System.Drawing.Size(96, 27)
        Me.txtTotalizadorApertura.TabIndex = 2
        Me.txtTotalizadorApertura.TabStop = False
        '
        'lblGasInicial
        '
        Me.lblGasInicial.AutoSize = True
        Me.lblGasInicial.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblGasInicial.ForeColor = System.Drawing.Color.Black
        Me.lblGasInicial.Location = New System.Drawing.Point(627, 18)
        Me.lblGasInicial.Name = "lblGasInicial"
        Me.lblGasInicial.Size = New System.Drawing.Size(141, 16)
        Me.lblGasInicial.TabIndex = 30
        Me.lblGasInicial.Text = "** G a s  i n i c i a l **"
        '
        'lblPercentajeApertura
        '
        Me.lblPercentajeApertura.AutoSize = True
        Me.lblPercentajeApertura.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPercentajeApertura.ForeColor = System.Drawing.Color.Black
        Me.lblPercentajeApertura.Location = New System.Drawing.Point(639, 33)
        Me.lblPercentajeApertura.Name = "lblPercentajeApertura"
        Me.lblPercentajeApertura.Size = New System.Drawing.Size(25, 16)
        Me.lblPercentajeApertura.TabIndex = 2
        Me.lblPercentajeApertura.Text = "&%:"
        '
        'txtPorcentajeApertura
        '
        Me.txtPorcentajeApertura.BackColor = System.Drawing.Color.White
        Me.txtPorcentajeApertura.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPorcentajeApertura.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPorcentajeApertura.ForeColor = System.Drawing.Color.Black
        Me.txtPorcentajeApertura.Location = New System.Drawing.Point(616, 50)
        Me.txtPorcentajeApertura.MaxLength = 4
        Me.txtPorcentajeApertura.Name = "txtPorcentajeApertura"
        Me.txtPorcentajeApertura.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.txtPorcentajeApertura.Size = New System.Drawing.Size(64, 27)
        Me.txtPorcentajeApertura.TabIndex = 3
        '
        'lblLitrosApertura
        '
        Me.lblLitrosApertura.AutoSize = True
        Me.lblLitrosApertura.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLitrosApertura.ForeColor = System.Drawing.Color.Black
        Me.lblLitrosApertura.Location = New System.Drawing.Point(703, 33)
        Me.lblLitrosApertura.Name = "lblLitrosApertura"
        Me.lblLitrosApertura.Size = New System.Drawing.Size(44, 16)
        Me.lblLitrosApertura.TabIndex = 50
        Me.lblLitrosApertura.Text = "Litros:"
        '
        'txtLitrosApertura
        '
        Me.txtLitrosApertura.BackColor = System.Drawing.Color.Gainsboro
        Me.txtLitrosApertura.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtLitrosApertura.Enabled = False
        Me.txtLitrosApertura.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLitrosApertura.ForeColor = System.Drawing.Color.Black
        Me.txtLitrosApertura.Location = New System.Drawing.Point(688, 50)
        Me.txtLitrosApertura.Name = "txtLitrosApertura"
        Me.txtLitrosApertura.ReadOnly = True
        Me.txtLitrosApertura.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.txtLitrosApertura.Size = New System.Drawing.Size(64, 27)
        Me.txtLitrosApertura.TabIndex = 50
        Me.txtLitrosApertura.TabStop = False
        '
        'lblPesoApertura
        '
        Me.lblPesoApertura.AutoSize = True
        Me.lblPesoApertura.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPesoApertura.ForeColor = System.Drawing.Color.Black
        Me.lblPesoApertura.Location = New System.Drawing.Point(785, 33)
        Me.lblPesoApertura.Name = "lblPesoApertura"
        Me.lblPesoApertura.Size = New System.Drawing.Size(78, 16)
        Me.lblPesoApertura.TabIndex = 4
        Me.lblPesoApertura.Text = "&Peso (Kgs.):"
        '
        'txtPesoApertura
        '
        Me.txtPesoApertura.BackColor = System.Drawing.Color.White
        Me.txtPesoApertura.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPesoApertura.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPesoApertura.ForeColor = System.Drawing.Color.Black
        Me.txtPesoApertura.Location = New System.Drawing.Point(768, 50)
        Me.txtPesoApertura.MaxLength = 20000
        Me.txtPesoApertura.Name = "txtPesoApertura"
        Me.txtPesoApertura.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.txtPesoApertura.Size = New System.Drawing.Size(96, 27)
        Me.txtPesoApertura.TabIndex = 5
        '
        'lblObservacionesApertura
        '
        Me.lblObservacionesApertura.AutoSize = True
        Me.lblObservacionesApertura.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.lblObservacionesApertura.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblObservacionesApertura.ForeColor = System.Drawing.Color.Black
        Me.lblObservacionesApertura.Location = New System.Drawing.Point(395, 88)
        Me.lblObservacionesApertura.Name = "lblObservacionesApertura"
        Me.lblObservacionesApertura.Size = New System.Drawing.Size(117, 19)
        Me.lblObservacionesApertura.TabIndex = 6
        Me.lblObservacionesApertura.Text = "&Observaciones:"
        '
        'txtObservacionesApertura
        '
        Me.txtObservacionesApertura.BackColor = System.Drawing.Color.White
        Me.txtObservacionesApertura.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtObservacionesApertura.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtObservacionesApertura.ForeColor = System.Drawing.Color.Black
        Me.txtObservacionesApertura.Location = New System.Drawing.Point(512, 87)
        Me.txtObservacionesApertura.Multiline = True
        Me.txtObservacionesApertura.Name = "txtObservacionesApertura"
        Me.txtObservacionesApertura.Size = New System.Drawing.Size(352, 48)
        Me.txtObservacionesApertura.TabIndex = 8
        '
        'figSeparador
        '
        Me.figSeparador.FillColor = System.Drawing.Color.LightSteelBlue
        Me.figSeparador.LineColor = System.Drawing.Color.RoyalBlue
        Me.figSeparador.LineWidth = 2.0!
        Me.figSeparador.Location = New System.Drawing.Point(0, 0)
        Me.figSeparador.Name = "figSeparador"
        Me.figSeparador.Size = New System.Drawing.Size(150, 150)
        Me.figSeparador.TabIndex = 0
        '
        'tmrLectura
        '
        '
        'frmAutotanques
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 14)
        Me.BackColor = System.Drawing.Color.Gainsboro
        Me.ClientSize = New System.Drawing.Size(1024, 645)
        Me.Controls.Add(Me.pnlHistorial)
        Me.Controls.Add(Me.rgrpMedicionFisica)
        Me.Controls.Add(Me.pnlFSalida)
        Me.Controls.Add(Me.txtFolio)
        Me.Controls.Add(Me.lblFolio)
        Me.Controls.Add(Me.rgrpCierre)
        Me.Controls.Add(Me.rgrpApertura)
        Me.Controls.Add(Me.pnlAcciones)
        Me.Controls.Add(Me.tbAutotanque)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MinimizeBox = False
        Me.Name = "frmAutotanques"
        Me.ShowInTaskbar = False
        Me.Text = "Pesado de autotanques"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.pnlAcciones.ResumeLayout(False)
        Me.pnlAcciones.PerformLayout()
        Me.pnlPruebaTransponder.ResumeLayout(False)
        CType(Me.nupdAtt, System.ComponentModel.ISupportInitialize).EndInit()
        Me.rgrpFila.ResumeLayout(False)
        Me.rgrpFila.PerformLayout()
        CType(Me.comLectorBascula, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.comLectorTransponder, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlHistorial.ResumeLayout(False)
        Me.pnlFSalida.ResumeLayout(False)
        Me.pnlFSalida.PerformLayout()
        Me.rgrpMedicionFisica.ResumeLayout(False)
        Me.rgrpMedicionFisica.PerformLayout()
        Me.pnlFMovimiento.ResumeLayout(False)
        Me.pnlFMovimiento.PerformLayout()
        Me.rgrpCierre.ResumeLayout(False)
        Me.rgrpCierre.PerformLayout()
        Me.rgrpApertura.ResumeLayout(False)
        Me.rgrpApertura.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region


#Region "Enumeradores privados"
    Private Enum Estado As Byte
        Esperando = 0
        AperturaCiclo = 1
        CierreCiclo = 2
        PesadoPGLleno = 3
        PesadoPGVacio = 4
    End Enum
#End Region

#Region "Variables globales"
    Private Folio As Integer
    Private Año As Integer
    Private Embarque As Integer
    Private PG As String
    Private EstadoActual As Estado = Estado.Esperando
    Private rptReporte As New ReportDocument()
    Private _TablaReporte As Table
    Private _LogonInfo As TableLogOnInfo
    Private _PesoLeido As Integer = 0
    Private _TranspondersLeidos As New ArrayList()
    Private _EmpleadoMedicion As Integer
    Private _SentidoMovimiento As Integer = 1
    Private _CalibracionAutotanque As Decimal
    Private _CalibracionPorcentajeAutotanque As Decimal
    Private _LitrosComerciales As Integer = 0
    Private _LitrosMasico As Integer = 0
    Private _LitrosUmbral As Integer = 0
    Private _dtAlmacenGasEntrada As New DataTable()

    '#20120413#HEMOPA-INICIO
    Private _PesoAutomatico As Boolean = False
    Private _PorcentajeInventario As Integer = CInt(Globales.GetInstance._PorcentajeLlenado)
    Private _UmbralRelleno As Integer = CInt(Globales.GetInstance._UmbralRellenoDefault)
    Private _FDRellenos As Decimal = Globales.GetInstance._FactorDensidad
    '#20120413#HEMOPA-FIN

    '20131001#CFSL-INICIO
    Private _FactorDensidadMasico As Boolean = False
    '20131001#CFSL-FIN

    '20150929#CFSL-INICIO
    Private _BoletinEnLinea As Boolean = False
    Private _VerificaDescarga As Boolean = False
    Private _Comision As Boolean = False
    Private _PrecioLitro As Decimal = 0

    Private _ClientesAtendidos As Integer = 0
    Private _LitrosTotalizadorSGC As Decimal = 0
    Private _LitrosReal As Decimal = 0
    Private _EficienciaReal As Decimal = 0
    Private _EficienciaEmpresa As Decimal = 0
    Private _EficienciaOperadorLitros As Decimal = 0
    Private _EficienciaOperadorPesos As Decimal = 0

    Private _EficienciaOperadorLitrosReal As Decimal = 0
    Private _EficienciaOperadorPesosReal As Decimal = 0

    Private _Operador As Integer = 0
    Private _ClienteOperador As Integer = 0

    'Private _ConsultaDescarga As Boolean = False
    '20150929#CFSL-FIN



    Private FolioAnt As Integer = 0
    Private AñoAnt As Integer = 0
    Private FTerminoAnt As DateTime
    Private DifTotalizador As Decimal = 0
    Private EficienciaMasico As Decimal = 0
    Private ImporteEficienciaMasico As Decimal = 0

    Dim frmResguardoEntrada As New Resguardo.frmResguardo()

    Private TConexion, Empresa As Integer   ''CambiosBascula
    Dim frmLecturaCOM As New frmLeerCOM ''CambiosBascula
    Dim ValidadorCOM As New AbrirEthernet   ''CambiosBascula          

    ' texis variables para control del lector de tag

    Private LlamarBascula As ServicioBasculita.LeerEthernetClient
    Private DatosEntrada As ServicioBasculita.Conexion
    Private lstTransponders As List(Of TransponderLeido)
    Private semaforo As Boolean = False
    Private semaforoElimina As Boolean = False

#End Region


#Region "Manejo de cajas de texto"
    Private Sub TextBox_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtAutotanque.Enter, txtKilometrajeApertura.Enter, _
            txtPorcentajeApertura.Enter, txtPesoApertura.Enter, txtObservacionesApertura.Enter, txtKilometrajeCierre.Enter, _
            txtPorcentajeCierre.Enter, txtPesoCierre.Enter, txtObservacionesCierre.Enter, txtTotalizadorCierre.Enter, txtCapacidad.Enter, _
            txtTemperatura.Enter, txtPresion.Enter, txtEmpleado.Enter, txtEmbarque.Enter, txtLitrosCargados.Enter
        CType(sender, TextBox).BackColor = Color.LemonChiffon
        CType(sender, TextBox).SelectAll()
    End Sub

    Private Sub TextBox_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtAutotanque.Leave, txtKilometrajeApertura.Leave, _
        txtPorcentajeApertura.Leave, txtPesoApertura.Leave, txtObservacionesApertura.Leave, txtKilometrajeCierre.Leave, _
                txtPorcentajeCierre.Leave, txtPesoCierre.Leave, txtObservacionesCierre.Leave, txtTotalizadorCierre.Leave, txtCapacidad.Leave, _
                txtTemperatura.Leave, txtPresion.Leave, txtEmpleado.Leave, txtEmbarque.Leave, txtLitrosCargados.Leave

        CType(sender, TextBox).BackColor = Color.White


    End Sub

    Private Sub TextBoxInteger_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtAutotanque.KeyPress, txtKilometrajeApertura.KeyPress, _
            txtKilometrajeCierre.KeyPress, txtEmpleado.KeyPress, _
            txtEmbarque.KeyPress
        ''If Not (e.KeyChar.IsDigit(e.KeyChar) OrElse e.KeyChar.IsControl(e.KeyChar) OrElse Asc(e.KeyChar) = 8) Then
        If Not (Char.IsDigit(e.KeyChar) OrElse Char.IsControl(e.KeyChar) OrElse Asc(e.KeyChar) = 8) Then
            e.Handled = True
        Else
            e.Handled = False
        End If
    End Sub
    Private Sub TextBoxDecimal_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPorcentajeApertura.KeyPress, txtPorcentajeCierre.KeyPress, _
            txtTemperatura.KeyPress, txtPresion.KeyPress, txtPesoApertura.KeyPress, txtPesoCierre.KeyPress, txtTotalizadorCierre.KeyPress, txtTotalizadorApertura.KeyPress, _
            txtLitrosCargados.KeyPress, txtCapacidad.KeyPress
        'If Not (Char.IsDigit(e.KeyChar) OrElse Char.IsControl(e.KeyChar) OrElse Asc(e.KeyChar) = 8 OrElse _
        '    (e.KeyChar = CChar(".") AndAlso CType(sender, TextBox).Text.IndexOf(".") < 0) OrElse _
        '     (e.KeyChar = CChar("-") AndAlso CType(sender, TextBox).Text.IndexOf("-") < 0 AndAlso CType(sender, TextBox).Name = "txtTemperatura" AndAlso CType(sender, TextBox).SelectionStart = 0)) Then
        '    e.Handled = True
        'Else
        '    e.Handled = False
        'End If

        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        ElseIf e.KeyChar = CChar(".") And Not CType(sender, TextBox).Text.IndexOf(".") < 0 Then
            e.Handled = True
        ElseIf e.KeyChar = "." Then
            e.Handled = False
        Else
            e.Handled = True
        End If

    End Sub
    Private Sub TextBoxParametrezado_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPesoApertura.KeyPress, txtPesoCierre.KeyPress, txtTotalizadorCierre.KeyPress, _
                    txtTotalizadorApertura.KeyPress, txtLitrosCargados.KeyPress
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

    '#20120413#HEMOPA-INICIO
    Private Sub InhabilitarBotonesPesoAutomatico()
        If Globales.GetInstance._PesadoAutotanqueIndividual Then
            txtPesoApertura.ReadOnly = (Not Globales.GetInstance.OperacionBascula(9).Habilitada AndAlso Not Globales.GetInstance.OperacionBascula(3).Habilitada) OrElse Not (Globales.GetInstance._ExisteBascula And _PesoAutomatico)
            txtPesoCierre.ReadOnly = (Not Globales.GetInstance.OperacionBascula(9).Habilitada AndAlso Not Globales.GetInstance.OperacionBascula(3).Habilitada) OrElse Not (Globales.GetInstance._ExisteBascula And _PesoAutomatico)
            txtPesoApertura.Enabled = Globales.GetInstance._ExisteBascula And _PesoAutomatico
            txtPesoCierre.Enabled = Globales.GetInstance._ExisteBascula And _PesoAutomatico
        End If
        If chkPG.Enabled Then
            txtPesoApertura.ReadOnly = (Not Globales.GetInstance.OperacionBascula(9).Habilitada AndAlso Not Globales.GetInstance.OperacionBascula(3).Habilitada) OrElse Not Globales.GetInstance._ExisteBascula
            txtPesoCierre.ReadOnly = (Not Globales.GetInstance.OperacionBascula(9).Habilitada AndAlso Not Globales.GetInstance.OperacionBascula(3).Habilitada) OrElse Not Globales.GetInstance._ExisteBascula
            txtPesoApertura.Enabled = Globales.GetInstance._ExisteBascula
            txtPesoCierre.Enabled = Globales.GetInstance._ExisteBascula
        End If
    End Sub
    '#20120413#HEMOPA-FIN

    Private Sub txtAutotanque_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtAutotanque.TextChanged
        btnBuscarAtt.Enabled = txtAutotanque.Text.Trim <> ""
    End Sub
    Private Sub TextBox_EnterPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPorcentajeApertura.KeyPress, _
                    txtPorcentajeCierre.KeyPress, txtAutotanque.KeyPress, txtKilometrajeApertura.KeyPress, txtPesoApertura.KeyPress, _
                    txtKilometrajeCierre.KeyPress, txtPesoCierre.KeyPress, txtTotalizadorCierre.KeyPress, txtCapacidad.KeyPress, _
                    txtTemperatura.KeyPress, txtPresion.KeyPress, txtTotalizadorApertura.KeyPress, txtLitrosCargados.KeyPress, txtEmpleado.KeyPress
        If Asc(e.KeyChar) = 13 Then
            Dim ctrl As Control
            If CType(sender, TextBox).Name = "txtAutotanque" Then
                BuscaAutotanque()
            Else
                ctrl = CType(sender, Control)
                While Not ctrl Is Nothing AndAlso (ctrl Is CType(sender, Control) OrElse (ctrl.GetType.Name <> "TextBox" AndAlso ctrl.GetType.Name <> "DateTimePicker") OrElse Not _
                                        ctrl.TabStop OrElse ctrl.Enabled = False)
                    ctrl = Me.GetNextControl(ctrl, True)
                End While
                If Not ctrl Is Nothing Then
                    ctrl.Focus()
                End If
            End If
        End If
    End Sub
    Private Sub TextBoxObservaciones_EnterPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtObservacionesApertura.KeyPress, txtObservacionesCierre.KeyPress
        If Asc(e.KeyChar) = 13 Then
            If Not Globales.GetInstance._MedicionFisica OrElse (chkPG.Checked AndAlso txtEmbarque.Text <> "") Then
                btnPesar_Click(Me, New System.EventArgs())
            Else
                txtEmbarque.Focus()
                txtTemperatura.Focus()
            End If
        End If
    End Sub
    Private Sub TextBoxEmpleado_EnterPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtEmpleado.KeyPress, txtEmbarque.KeyPress
        If Asc(e.KeyChar) = 13 AndAlso Not dtpFMovimiento.Visible Then
            btnPesar_Click(Me, New System.EventArgs())
        End If
    End Sub
    Private Sub dtpFMovimiento_EnterPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles dtpFMovimiento.KeyPress
        If Asc(e.KeyChar) = 13 Then
            btnPesar_Click(Me, New System.EventArgs())
        End If
    End Sub
#End Region


#Region "Rutinas de activación / inactivación"
    Private Sub CambiaApertura(ByVal Enabled As Boolean)
        rgrpApertura.Enabled = Enabled
        btnPesar.Enabled = Enabled
        tmrHora.Enabled = Enabled
    End Sub
    Private Sub CambiaCierre(ByVal Enabled As Boolean)
        btnImprimir.Enabled = Enabled AndAlso Globales.GetInstance.OperacionBascula(10).Habilitada
        rgrpCierre.Enabled = Enabled
        btnPesar.Enabled = Enabled
        tmrHora.Enabled = Enabled
    End Sub
    Private Sub PosicionaContenedorPredeterminado(ByVal Corporativo As Short, ByVal Sucursal As Short)
        Dim keys(1) As Object
        keys(0) = Corporativo
        keys(1) = Sucursal
        Dim drContenedorPredeterminado As DataRow = Globales.GetInstance._dtContenedorPredeterminado.Rows.Find(keys)
        If drContenedorPredeterminado Is Nothing Then
            cboContenedor.SelectedValue = Globales.GetInstance._ContenedorPredeterminado
        Else
            cboContenedor.SelectedValue = CType(drContenedorPredeterminado.Item("Valor"), Integer)
        End If
    End Sub
#End Region

#Region "Rutinas de limpieza e inicialización"
    Private Sub Limpiar()
        '20100310#CFSL - Variables
        FolioAnt = 0
        AñoAnt = 0
        DifTotalizador = 0
        EficienciaMasico = 0
        ImporteEficienciaMasico = 0

        Dim RecorrerTransponder As Boolean = Not chkPG.Checked AndAlso txtAutotanque.Text.Trim <> ""

        btnCicloEspecial.Visible = False
        EstadoActual = Estado.Esperando
        CambiaApertura(False)
        CambiaCierre(False)

        'txtTemperatura.Clear()
        'txtPresion.Clear()
        rgrpMedicionFisica.Enabled = Globales.GetInstance._MedicionFisica

        mniReporteApertura.Enabled = False
        mniReporteCierre.Enabled = False

        LimpiaApertura()
        LimpiaCierre()
        cboAlmacenEntrada.DataSource = Nothing
        cboAlmacenEntrada.Items.Clear()
        cboAlmacenEntrada.Enabled = False
        _dtAlmacenGasEntrada = Nothing
        txtEmbarque.Clear()
        txtCapacidad.ReadOnly = True
        txtCapacidad.Enabled = False
        txtCapacidad.BackColor = txtRutaApertura.BackColor
        vgHistorial.DataSource = Nothing
        Folio = 0
        Año = Globales.GetInstance.FechaActual.Year
        chkPG.Checked = False
        txtFolio.Clear()
        chkPG.Enabled = True
        btnAnular.Enabled = False
        btnModificar.Enabled = False
        btnImprimir.Enabled = False
        btnPesar.Enabled = False
        ccboPG.Enabled = True
        ccboPG.Visible = False
        txtAutotanque.Visible = True
        txtAutotanque.Enabled = True
        txtKilometrajeApertura.Enabled = True
        txtKilometrajeCierre.Enabled = True
        txtTotalizadorApertura.Enabled = True
        txtTotalizadorCierre.Enabled = True
        lblContenedor.Text = "Almacén de salida:"
        txtAutotanque.Clear()
        txtAutotanque.Focus()

        '#20120413#HEMOPA-INICIO
        _PesoAutomatico = False
        _PorcentajeInventario = CInt(Globales.GetInstance._PorcentajeLlenado)
        _UmbralRelleno = CInt(Globales.GetInstance._UmbralRellenoDefault)
        _FDRellenos = Globales.GetInstance._FactorDensidad
        _LitrosMasico = 0
        _LitrosComerciales = 0
        _LitrosUmbral = 0
        '#20120413#HEMOPA-FIN


        '20150929#CFSL-INICIO
        _BoletinEnLinea = False
        _VerificaDescarga = False
        _Comision = False
        _PrecioLitro = 0

        _ClientesAtendidos = 0
        _LitrosTotalizadorSGC = 0
        _LitrosReal = 0
        _EficienciaReal = 0
        _EficienciaEmpresa = 0
        _EficienciaOperadorLitros = 0
        _EficienciaOperadorPesos = 0

        _EficienciaOperadorLitrosReal = 0
        _EficienciaOperadorPesosReal = 0

        _Operador = 0
        _ClienteOperador = 0
        '_ConsultaDescarga = False
        '20150929#CFSL-FIN

        If Globales.GetInstance._ExisteBascula Then
            LimpiaBascula()
        End If
        If Globales.GetInstance._LeeTransponder Then
            LimpiaTransponder()
        End If

        trpFotos.Operador = 0
        trpFotos.Ayudante = 0

        cboTipoMovimiento.Enabled = True
        cboTipoMovimiento.SelectedIndex = 0

        cboContenedor.Enabled = False

        bdtpFSalida.Value = Globales.GetInstance.FechaActual.Date
        bdtpFSalida.Enabled = True

        lblSentidoMovimiento.Visible = False
        btnSentidoMovimiento.Visible = False
        btnSentidoMovimiento.Enabled = True
        _SentidoMovimiento = 1

        If RecorrerTransponder Then
            RecorreFila()
        End If


        'TEXIS para regresar el semaforo a false
        semaforo = False

        If (semaforoElimina = True) Then
            lstTransponders.RemoveAt(0)
            semaforoElimina = False
        End If

        txtTemperatura.Text = ""
        txtPresion.Text = ""
        txtEmpleado.Text = ""
        txtAutotanque.Focus()


    End Sub
    Private Sub LimpiaApertura()
        Dim ctrl As Control
        For Each ctrl In rgrpApertura.Controls
            If ctrl.GetType.Name = "TextBox" Then
                CType(ctrl, TextBox).Clear()
            End If
        Next
    End Sub
    Private Sub LimpiaCierre()
        Dim ctrl As Control
        For Each ctrl In rgrpCierre.Controls
            If ctrl.GetType.Name = "TextBox" Then
                CType(ctrl, TextBox).Clear()
            End If
        Next
    End Sub
    Private Sub IniciaCapturaApertura()
        Dim FechaActual As DateTime = Globales.GetInstance.FechaActual
        EstadoActual = Estado.AperturaCiclo
        btnImprimir.Enabled = False
        chkPG.Enabled = False

        CambiaApertura(True)

        txtFechaApertura.Text = FechaActual.ToShortDateString
        txtHoraApertura.Text = FechaActual.ToShortTimeString
        txtKilometrajeApertura.Focus()
    End Sub
    Private Sub IniciaCapturaCierre()
        Dim cmdBascula As New SqlCommand("Select * from vwBASTripulacion where AñoAtt = @Año and Folio = @Folio", Globales.GetInstance.cnSigamet)
        Dim daBascula As New SqlDataAdapter(cmdBascula)
        Dim rdDatosCierre As SqlDataReader
        Dim op, ay As Integer
        Dim FechaActual As DateTime = Globales.GetInstance.FechaActual
        cmdBascula.Parameters.Add("@Año", SqlDbType.SmallInt).Value = Año
        cmdBascula.Parameters.Add("@Folio", SqlDbType.Int).Value = Folio
        chkPG.Enabled = False
        txtFechaCierre.Text = FechaActual.ToShortDateString
        txtHoraCierre.Text = FechaActual.ToShortTimeString

        lblSentidoMovimiento.Visible = True
        btnSentidoMovimiento.Visible = True
        Try
            Globales.GetInstance.AbreConexion()
            rdDatosCierre = cmdBascula.ExecuteReader
            If rdDatosCierre.Read() Then
                txtCelulaCierre.Text = CStr(rdDatosCierre("DescripcionCelula"))
                txtCelulaCierre.Tag = CType(rdDatosCierre("Celula"), Integer)
                txtRutaCierre.Text = CStr(rdDatosCierre("DescripcionRuta"))
                txtRutaCierre.Tag = CType(rdDatosCierre("Ruta"), Integer)

                txtOperador.Text = CStr(rdDatosCierre("Operador"))
                txtAyudante.Text = CStr(rdDatosCierre("Ayudante"))
                txtExtra.Text = CStr(rdDatosCierre("Extra"))
                op = CInt(rdDatosCierre("IDOperador"))
                ay = CInt(rdDatosCierre("IDAyudante"))

                '20150929#CFSL-INICIO
                _Operador = op
                '20150929#CFSL-FIN

                rdDatosCierre.Close()
                cmdBascula.CommandText = "Select dbo.PrecioVigente(0, 1)"
                txtPrecio.Text = CDec(cmdBascula.ExecuteScalar).ToString
                CambiaCierre(True)
                txtKilometrajeCierre.Focus()
                EstadoActual = Estado.CierreCiclo
                trpFotos.Operador = op
                trpFotos.Ayudante = ay

                mniReporteApertura.Enabled = True
                cboContenedor.Enabled = False
                cboTipoMovimiento.Enabled = False
                bdtpFSalida.Enabled = False
            End If
        Catch ex As Exception
            Globales.GetInstance.ExMessage(ex)
        Finally
            Globales.GetInstance.CierraConexion()
        End Try
    End Sub
#End Region

#Region "Rutinas de busqueda de ciclos, autotanques y pg's"

    Private Function BuscaAlmacenGas() As Integer
        'Dim cmdComando As New SqlCommand("Select Almacengas, Descripcion From AlmacenGas Where Autotanque = @Autotanque AND Status = 'ACTIVO'", Globales.GetInstance.cnSigamet)
        '#20120413#HEMOPA-INICIO
        'Dim cmdComando As New SqlCommand("Select AG.Almacengas, S.Siglas+' - '+AG.Descripcion Descripcion, AG.Descripcion DescripcionAlmacen, S.Sucursal, S.Descripcion DescripcionSucursal,C.Celula, C.Descripcion DescripcionCelula, R.Ruta, R.Descripcion DescripcionRuta, C.Corporativo From AlmacenGas AG Inner Join Celula C On AG.Celula = C.Celula Inner Join Sucursal S On C.Sucursal = S.Sucursal Inner Join Ruta R on AG.Ruta = R.Ruta Where AG.Autotanque = @Autotanque AND AG.Status = 'ACTIVO'", Globales.GetInstance.cnSigamet)

        Dim cmdBascula As New SqlCommand("spBASBuscaAlmacenGas", Globales.GetInstance.cnSigamet)
        cmdBascula.CommandType = CommandType.StoredProcedure
        Dim daAlmacenGas As New SqlDataAdapter(cmdBascula)

        cmdBascula.Parameters.Add("@Autotanque", SqlDbType.SmallInt).Value = CInt(txtAutotanque.Text)

        Dim dtAlmacenGas As New DataTable()
        Try
            daAlmacenGas.Fill(dtAlmacenGas)
            _dtAlmacenGasEntrada = dtAlmacenGas
            Dim keys(0) As DataColumn
            keys(0) = _dtAlmacenGasEntrada.Columns("AlmacenGas")
            _dtAlmacenGasEntrada.PrimaryKey = keys

            cboAlmacenEntrada.Tag = CType(1, Integer)
            cboAlmacenEntrada.DisplayMember = "Descripcion"
            cboAlmacenEntrada.ValueMember = "AlmacenGas"
            cboAlmacenEntrada.DataSource = _dtAlmacenGasEntrada
            cboAlmacenEntrada.Tag = CType(0, Integer)

            If cboAlmacenEntrada.Items.Count > 1 Then
                cboAlmacenEntrada.SelectedIndex = -1
                cboAlmacenEntrada.SelectedIndex = -1
                cboAlmacenEntrada.Enabled = True
                ActiveControl = cboAlmacenEntrada
            Else
                cboAlmacenEntrada.SelectedItem = 0
                cboAlmacenEntrada.Enabled = False
                Dim drAlmacenGas As DataRow = _dtAlmacenGasEntrada.Rows.Find(cboAlmacenEntrada.SelectedValue)
                PosicionaContenedorPredeterminado(CType(drAlmacenGas.Item("Corporativo"), Short), CType(drAlmacenGas.Item("Sucursal"), Short))
            End If

        Catch ex As Exception
            Globales.GetInstance.ExMessage(ex)
            Return 0
        End Try
        Return cboAlmacenEntrada.Items.Count
    End Function

    Private Sub BuscaAutotanque()
        If txtAutotanque.Text.Trim <> "" AndAlso Val(txtAutotanque.Text) > 0 Then
            '20110202#CFSL Se quito la contulta en codigo y se cambio por un SP
            'Dim cmdBascula As New SqlClient.SqlCommand("Select * from vwLOGAutotanque where Autotanque = @Autotanque and Status = 'ACTIVO'", Globales.GetInstance.cnSigamet)

            Dim cmdBascula As New SqlCommand("spBASLOGAutotanque", Globales.GetInstance.cnSigamet)
            cmdBascula.CommandType = CommandType.StoredProcedure

            Dim daBascula As New SqlClient.SqlDataAdapter(cmdBascula)
            Dim rdAutotanque As SqlDataReader = Nothing
            cmdBascula.Parameters.Add("@Autotanque", SqlDbType.Int).Value = CInt(txtAutotanque.Text)
            cmdBascula.Parameters.Add("@Status", SqlDbType.VarChar).Value = "ACTIVO"
            Try
                Globales.GetInstance.AbreConexion()
                rdAutotanque = cmdBascula.ExecuteReader
                If rdAutotanque.Read Then
                    'texis si existe el att poner semaforo en true

                    semaforo = True

                    txtAutotanque.Enabled = False
                    txtPlacas.Text = CStr(rdAutotanque("Placas"))
                    txtCapacidad.Text = CStr(rdAutotanque("Capacidad"))

                    txtRutaApertura.Text = CType(rdAutotanque("DescripcionRuta"), String)
                    txtRutaApertura.Tag = CType(rdAutotanque("Ruta"), Integer)
                    txtCelulaApertura.Text = CType(rdAutotanque("DescripcionCelula"), String)
                    txtCelulaApertura.Tag = CType(rdAutotanque("Celula"), Integer)

                    _CalibracionAutotanque = CDec(rdAutotanque("Calibracion")) / 100
                    _CalibracionPorcentajeAutotanque = CDec(rdAutotanque("CalibracionPorcentaje")) / 100

                    '#20120413#HEMOPA-INICIO
                    _PesoAutomatico = CType(IIf(rdAutotanque("PesoAutomatico") Is DBNull.Value, False, rdAutotanque("PesoAutomatico")), Boolean)
                    _PorcentajeInventario = CType(IIf(rdAutotanque("PorcentajeInventario") Is DBNull.Value, 0, rdAutotanque("PorcentajeInventario")), Integer)
                    _UmbralRelleno = CType(IIf(rdAutotanque("UmbralRelleno") Is DBNull.Value, 0, rdAutotanque("UmbralRelleno")), Integer)
                    '#20120413#HEMOPA-FIN

                    '20131001#CFSL-INICIO
                    _FactorDensidadMasico = (CType(IIf(rdAutotanque("FactorDensidadMasico") Is DBNull.Value, False, rdAutotanque("FactorDensidadMasico")), Boolean))
                    '20131001#CFSL-FIN

                    '20150929#CFSL-INICIO
                    _BoletinEnLinea = (CType(IIf(rdAutotanque("BoletinEnLinea") Is DBNull.Value, False, rdAutotanque("BoletinEnLinea")), Boolean))
                    _VerificaDescarga = (CType(IIf(rdAutotanque("VerificaDescarga") Is DBNull.Value, False, rdAutotanque("VerificaDescarga")), Boolean))
                    _Comision = (CType(IIf(rdAutotanque("Comision") Is DBNull.Value, False, rdAutotanque("Comision")), Boolean))
                    _PrecioLitro = CDec(rdAutotanque("PrecioLitro"))
                    '20150929#CFSL-FIN

                    rdAutotanque.Close()
                    BuscaAlmacenGas()

                    If Globales.GetInstance._DatosCelulaRuta Then
                        txtRutaApertura.Clear()
                        txtRutaApertura.Tag = CType(0, Integer)
                        txtCelulaApertura.Clear()
                        txtCelulaApertura.Tag = CType(0, Integer)
                        If cboAlmacenEntrada.SelectedIndex > -1 Then
                            Dim drAlmacenGas As DataRow = _dtAlmacenGasEntrada.Rows.Find(cboAlmacenEntrada.SelectedValue)
                            txtRutaApertura.Text = CType(drAlmacenGas.Item("DescripcionRuta"), String)
                            txtRutaApertura.Tag = CType(drAlmacenGas.Item("Ruta"), Integer)
                            txtCelulaApertura.Text = CType(drAlmacenGas.Item("DescripcionCelula"), String)
                            txtCelulaApertura.Tag = CType(drAlmacenGas.Item("Celula"), Integer)
                        End If

                    End If

                    If BuscaFolio(CInt(txtAutotanque.Text)) Then
                        IniciaCapturaCierre()
                        If _BoletinEnLinea Then
                            ConsultaDescargaOperador()
                        End If
                    Else
                        '20100310#CFSL - Migrar Datos del SGC
                        'texis#2012/01/17
                        'If Globales.GetInstance._ExisteMasico Then
                        '    MigraDatosMasico()
                        'Else
                        '    FolioAnt = 0
                        '    AñoAnt = 0
                        '    DifTotalizador = 0
                        '    EficienciaMasico = 0
                        '    ImporteEficienciaMasico = 0
                        'End If
                        'Texis#2012/01/18 se comentó el codigo de abajo suprimiendo la parte del numero de la formula
                        'por el codigo de arriba en si existe masico

                        'If Globales.GetInstance._FormulaEficiencia = 7 Then
                        '    MigraDatosMasico()
                        'Else
                        '    FolioAnt = 0
                        '    AñoAnt = 0
                        '    DifTotalizador = 0
                        '    EficienciaMasico = 0
                        '    ImporteEficienciaMasico = 0
                        'End If

                        Año = Globales.GetInstance.FechaActual.Year

                        'LUSATE INICIO 18/05/2015 Cambio para que en la apertura el porcentaje sea igual a 0
                        If Empresa = 0 Then
                            txtPorcentajeApertura.Text = CStr(0)
                        Else
                            '#20120413#HEMOPA-INICIO
                            If Globales.GetInstance._CargaPorcentajeInventario Then
                                If (CInt(_PorcentajeInventario) > 0) Then
                                    txtPorcentajeApertura.Text = _PorcentajeInventario.ToString
                                Else
                                    txtPorcentajeApertura.Text = Globales.GetInstance._PorcentajeLlenado.ToString
                                End If
                            Else
                                txtPorcentajeApertura.Text = Globales.GetInstance._PorcentajeLlenado.ToString
                            End If
                            '#20120413#HEMOPA-FIN
                        End If
                        'LUSATE FIN 18/05/2015 Cambio para que en la apertura el porcentaje sea igual a 0
                        txtKilometrajeApertura.Focus()
                        cboContenedor.Enabled = True
                    End If
                Else
                    Globales.GetInstance.ErrMessage("No se ha encontrado el autotánque.")
                    rdAutotanque.Close()
                    Limpiar()
                End If
            Catch ex As Exception
                Globales.GetInstance.ExMessage(ex)
                'rdAutotanque.Close()
                Limpiar()
            Finally
                If Not rdAutotanque Is Nothing Then
                    rdAutotanque.Close()
                End If
                Globales.GetInstance.CierraConexion()
                btnBuscarAtt.Enabled = False
                rdAutotanque.Close()
            End Try
        End If
        '#20120413#HEMOPA-INICIO-FIN
        InhabilitarBotonesPesoAutomatico()
    End Sub
    Private Sub BuscaPG()
        '#20120413#HEMOPA-INICIO-FIN
        InhabilitarBotonesPesoAutomatico()

        Dim cmdBascula As New SqlCommand("Select * from vwBASInformacionCicloPG where Status = 'ABIERTO' and PG = @PG", Globales.GetInstance.cnSigamet)
        Dim daBascula As New SqlDataAdapter(cmdBascula)
        Dim rdrPG As SqlDataReader
        cmdBascula.Parameters.Add("@PG", SqlDbType.Char).Value = ccboPG.Text.Trim
        txtEmbarque.Enabled = True
        lblContenedor.Text = "Almacén de descarga:"
        Try
            Globales.GetInstance.AbreConexion()
            rdrPG = cmdBascula.ExecuteReader
            If rdrPG.Read Then
                txtKilometrajeApertura.Text = CStr(rdrPG("KilometrajeInicial"))
                txtPorcentajeApertura.Text = CStr(rdrPG("PorcentajeGasInicial"))
                txtPesoApertura.Text = CStr(rdrPG("PesoSalida"))
                txtObservacionesApertura.Text = CStr(rdrPG("ObservacionesInicioRuta"))
                txtKilometrajeCierre.Text = txtKilometrajeApertura.Text
                txtPorcentajeCierre.Text = txtPorcentajeApertura.Text
                txtEmbarque.Text = CStr(rdrPG("NumeroEmbarque"))
                txtCapacidad.Text = CStr(rdrPG("Capacidad"))
                Folio = CInt(rdrPG("Folio"))
                Año = CInt(rdrPG("AñoAtt"))
                Embarque = CInt(rdrPG("Embarque"))
                PG = CStr(rdrPG("PG"))
                cboContenedor.SelectedValue = CInt(rdrPG("AlmacenGas"))
                txtFolio.Text = Folio.ToString
                rdrPG.Close()
                IniciaCapturaCierre()
                CambiaCierre(True)
                txtTotalizadorCierre.Enabled = False
                ccboPG.Enabled = False
                txtKilometrajeCierre.Enabled = False
                txtPorcentajeCierre.Focus()
                EstadoActual = Estado.PesadoPGVacio
                txtEmbarque.Enabled = False
            Else
                rdrPG.Close()
                Año = Globales.GetInstance.FechaActual.Year
                txtKilometrajeApertura.Enabled = False
                IniciaCapturaApertura()

                Dim _capacidadPG As Decimal
                _capacidadPG = ConsultaCapacidadPG(ccboPG.Text.Trim)
                If _capacidadPG > 0 Then
                    txtCapacidad.Text = CStr(_capacidadPG)
                Else
                    txtCapacidad.Text = ""
                End If



                txtPorcentajeApertura.Tag = System.DBNull.Value
                txtPesoApertura.Tag = System.DBNull.Value

                txtCapacidad.BackColor = Color.White
                txtCapacidad.ReadOnly = False
                txtCapacidad.Enabled = True

                txtCapacidad.Focus()
                ccboPG.Enabled = False

                cboContenedor.Enabled = True
                cboContenedor.SelectedValue = Globales.GetInstance._ContenedorPredeterminado
                EstadoActual = Estado.PesadoPGLleno
            End If
        Catch ex As Exception
            Globales.GetInstance.ExMessage(ex)
        Finally
            Globales.GetInstance.CierraConexion()
        End Try
    End Sub

    Public Function ConsultaCapacidadPG(ByVal PG As String) As Decimal
        Dim cmdBascula As New SqlCommand("spBASBuscaVehiculoExterno", Globales.GetInstance.cnSigamet)
        Dim res As Decimal
        cmdBascula.CommandType = CommandType.StoredProcedure
        cmdBascula.Parameters.Add("@PG", SqlDbType.VarChar).Value = PG
        Me.Cursor = Cursors.WaitCursor
        Try
            Globales.GetInstance.AbreConexion()
            res = CType(cmdBascula.ExecuteScalar(), Decimal)
        Catch ex As Exception
            Globales.GetInstance.ExMessage(ex)
        Finally
            Globales.GetInstance.CierraConexion()
            Me.Cursor = Cursors.Default
        End Try
        Return res
    End Function


    Private Function BuscaFolio(ByVal Autotanque As Integer) As Boolean

        'Dim cmdBascula As New SqlClient.SqlCommand("Select top 20 * from vwBASInformacionFolios where Autotanque = @Autotanque " & _
        '                " and StatusBascula in ('ABIERTO', 'CERRADO', 'CIERRE') AND StatusLogistica in ('ASIGNADO', 'CIERRE', 'INICIO', 'LIQCAJA', 'LIQUIDADO') " & _
        '                " order by FInicioRuta desc", Globales.GetInstance.cnSigamet)
        '20110202#CFSL Se quito la contulta en codigo y se cambio por un SP
        Dim cmdBascula As New SqlCommand("spBASInformacionFolios", Globales.GetInstance.cnSigamet)
        cmdBascula.CommandType = CommandType.StoredProcedure

        Dim daBascula As New SqlClient.SqlDataAdapter(cmdBascula)
        Dim dtHistorial As New DataTable()
        Dim dtFiltro As New DataTable()
        Dim rw, rwCiclo As DataRow
        Dim FechaActual As DateTime = Globales.GetInstance.FechaActual
        Dim TipoMovimientoAlmacen As Integer
        'cmdBascula.Parameters.Add("@Año", SqlDbType.SmallInt).Value = Globales.GetInstance.FechaActual.Year
        cmdBascula.Parameters.Add("@Autotanque", SqlDbType.SmallInt).Value = Autotanque
        cmdBascula.Parameters.Add("@Corporativo", SqlDbType.SmallInt).Value = Globales.GetInstance._Corporativo
        cmdBascula.Parameters.Add("@Sucursal", SqlDbType.SmallInt).Value = Globales.GetInstance._Sucursal
        Try
            daBascula.Fill(dtHistorial)
            vgHistorial.DataSource = dtHistorial
            If dtHistorial.Rows.Count = 0 Then
                'Primer inicio de ciclo
                txtKilometrajeApertura.ReadOnly = False
                txtTotalizadorApertura.ReadOnly = False
                txtTotalizadorApertura.Enabled = True
                txtTotalizadorApertura.TabStop = True
                txtTotalizadorApertura.BackColor = Color.White

                IniciaCapturaApertura()

            Else

                'Agregado para el primer inicio de ciclo
                txtKilometrajeApertura.ReadOnly = True
                txtTotalizadorApertura.ReadOnly = True
                txtTotalizadorApertura.Enabled = False
                txtTotalizadorApertura.TabStop = False
                txtTotalizadorApertura.BackColor = Color.Gainsboro

                '20100310#CFSL - Datos Para el calculo que se hara con la nueva formula de Hidrogas
                rwCiclo = dtHistorial.Rows(0)

                '#20120413#HEMOPA-INICIO-FIN
                _FDRellenos = CType(IIf(rwCiclo("FDRellenos") Is DBNull.Value, Globales.GetInstance._FactorDensidad, rwCiclo("FDRellenos")), Decimal)
                _LitrosComerciales = CType(IIf(rwCiclo("LitrosComerciales") Is DBNull.Value, 0, rwCiclo("LitrosComerciales")), Integer)
                '_LitrosUmbral - ESTA VARIABLE AUN NO SE OCUPA

                If CType(rwCiclo("StatusBascula"), String) = "ABIERTO   " Then
                    FolioAnt = 0
                    AñoAnt = 0
                    DifTotalizador = 0
                    EficienciaMasico = 0
                    ImporteEficienciaMasico = 0
                Else
                    FolioAnt = CInt(rwCiclo("Folio"))
                    AñoAnt = CInt(rwCiclo("AñoAtt"))
                    FTerminoAnt = CType(rwCiclo("FTerminoRuta"), DateTime)
                    DifTotalizador = CType(rwCiclo("LitrosLiquidados"), Decimal) * _CalibracionPorcentajeAutotanque
                End If





                dtHistorial.DefaultView.RowFilter = "StatusBascula = 'ABIERTO'"
                dtFiltro = Globales.GetInstance.ViewToTable(dtHistorial.DefaultView)
                If dtFiltro.Rows.Count > 0 Then
                    rw = dtFiltro.Rows(0)

                    Año = CInt(rw("AñoAtt"))
                    Folio = CInt(rw("Folio"))

                    txtTotalizadorApertura.Text = CStr(rw("TotalizadorInicial"))
                    txtFechaApertura.Text = CDate(rw("FPeso")).ToShortDateString
                    txtFolio.Text = CStr(rw("Folio"))
                    txtHoraApertura.Text = CDate(rw("FPeso")).ToShortTimeString
                    bdtpFSalida.Value = CDate(rw("FInicioRuta"))
                    txtKilometrajeApertura.Text = CStr(rw("KilometrajeInicial"))
                    txtPorcentajeApertura.Text = CStr(rw("PorcentajeGasInicial"))
                    txtPorcentajeApertura.Tag = System.DBNull.Value
                    txtPesoApertura.Tag = System.DBNull.Value
                    txtLitrosApertura.Text = CStr(rw("LitrosGasInicial"))
                    txtObservacionesApertura.Text = CStr(rw("ObservacionesInicioRuta"))
                    txtPesoApertura.Text = CStr(rw("PesoSalida"))

                    TipoMovimientoAlmacen = CInt(rw("TipoMovimientoAlmacen"))
                    Select Case TipoMovimientoAlmacen
                        Case 17
                            cboTipoMovimiento.SelectedIndex = 0
                        Case 4
                            cboTipoMovimiento.SelectedIndex = 1
                        Case 8
                            cboTipoMovimiento.SelectedIndex = 2
                        Case Else
                            cboTipoMovimiento.SelectedIndex = 3
                    End Select

                    If cboAlmacenEntrada.Items.Count > 0 And CInt(rw("AlmacenGas")) > 0 Then
                        cboAlmacenEntrada.SelectedValue = CInt(rw("AlmacenGas"))
                        cboAlmacenEntrada.Enabled = False
                    Else
                        cboAlmacenEntrada.Enabled = False
                    End If

                    btnAnular.Enabled = Globales.GetInstance.OperacionBascula(1).Habilitada OrElse Globales.GetInstance.OperacionBascula(9).Habilitada
                    btnModificar.Enabled = Globales.GetInstance.OperacionBascula(2).Habilitada OrElse Globales.GetInstance.OperacionBascula(9).Habilitada

                    CambiaApertura(False)
                    CambiaCierre(True)
                    dtHistorial.DefaultView.RowFilter = ""
                    Return True
                Else
                    IniciaCapturaApertura()
                    dtHistorial.DefaultView.RowFilter = "StatusBascula = 'CERRADO' and FTerminoRuta = Max(FTerminoRuta)"
                    dtFiltro = Globales.GetInstance.ViewToTable(dtHistorial.DefaultView)
                    If dtFiltro.Rows.Count > 0 Then
                        rw = dtFiltro.Rows(0)
                        If Globales.GetInstance._AnticiparPesado AndAlso CDate(rw("FInicioRuta")) = FechaActual.Date Then
                            bdtpFSalida.Value = FechaActual.Date.AddDays(1)
                        Else
                            bdtpFSalida.Value = FechaActual.Date
                        End If
                        txtKilometrajeApertura.Text = CStr(rw("KilometrajeFinal"))
                        txtTotalizadorApertura.Text = CStr(rw("TotalizadorFinal"))

                        If IsDBNull(rw("PorcentajeGasFinal")) Then
                            txtPorcentajeApertura.Tag = System.DBNull.Value
                        Else
                            txtPorcentajeApertura.Tag = CType(rw("PorcentajeGasFinal"), Decimal)
                        End If

                        If IsDBNull(rw("PesoLlegada")) Then
                            txtPesoApertura.Tag = System.DBNull.Value
                        Else
                            txtPesoApertura.Tag = CType(rw("PesoLlegada"), Decimal)
                        End If
                    Else
                        txtPorcentajeApertura.Tag = System.DBNull.Value
                        txtPesoApertura.Tag = System.DBNull.Value
                    End If
                    dtHistorial.DefaultView.RowFilter = ""
                    Return False
                End If
            End If
            btnBuscar.Enabled = False
        Catch ex As Exception
            Globales.GetInstance.ExMessage(ex)
        End Try
    End Function
#End Region

    '20100310#CFSL - Rutinas del SGC
    '20101008#CFSL - Rutina para hacer el update en la base de datos de los litros a suministrar automaticamente por medio del SGC
#Region "Rutinas del SGC"

    Private Sub MigraDatosMasico()
        Try
            Dim conn As MySql.Data.MySqlClient.MySqlConnection
            Dim cmd As MySql.Data.MySqlClient.MySqlCommand
            Dim connStr As String
            connStr = Globales.GetInstance._SGCMasicoConnectionString
            conn = New MySql.Data.MySqlClient.MySqlConnection(connStr)

            Try

                conn.Open()
                Dim da As New MySql.Data.MySqlClient.MySqlDataAdapter()
                Dim dt As New DataTable()
                Dim sql As String = Globales.GetInstance._SGCMasicoQuery1 + " " + Globales.GetInstance._SGCMasicoQuery2
                Dim resultado(1) As String
                resultado = ConsultaUltimoServicio()
                sql = sql.Replace("FHI", "'" + resultado(0) + "'")
                sql = sql.Replace("FHF", "'" + resultado(1) + "'")
                sql = sql.Replace("ATT", txtAutotanque.Text.Trim + ";")
                cmd = New MySql.Data.MySqlClient.MySqlCommand(sql, conn)
                cmd.CommandText = sql
                da.SelectCommand = cmd
                da.Fill(dt)
                conn.Close()
                If Not (dt Is Nothing) Then
                    If dt.Rows.Count > 0 Then
                        Dim dr As DataRow
                        Dim cmdSGC As New SqlCommand("spBASSGCInsertaRI505ServicioMasico", Globales.GetInstance.cnSigamet)
                        cmdSGC.CommandType = CommandType.StoredProcedure
                        Dim trBascula As SqlTransaction = Nothing
                        Try
                            Me.Cursor = Cursors.WaitCursor
                            Globales.GetInstance.AbreConexion()
                            trBascula = Globales.GetInstance.cnSigamet.BeginTransaction
                            cmdSGC.Transaction = trBascula
                            For Each dr In dt.Rows
                                cmdSGC.Parameters.Clear()

                                cmdSGC.Parameters.Add("@IdServicio", SqlDbType.Int).Value = dr("id_servicio")
                                cmdSGC.Parameters.Add("@Terminal", SqlDbType.Int).Value = dr("terminal")
                                cmdSGC.Parameters.Add("@Autotanque", SqlDbType.Int).Value = dr("autotanque")
                                cmdSGC.Parameters.Add("@Tag", SqlDbType.VarChar).Value = dr("tag")
                                cmdSGC.Parameters.Add("@IdUsuario", SqlDbType.Int).Value = dr("id_usuario")
                                cmdSGC.Parameters.Add("@FHoraInicial", SqlDbType.DateTime).Value = dr("fecha_hora_inicial")
                                cmdSGC.Parameters.Add("@FHoraFinal", SqlDbType.DateTime).Value = dr("fecha_hora_final")
                                cmdSGC.Parameters.Add("@Volumen", SqlDbType.Decimal).Value = dr("volumen")
                                cmdSGC.Parameters.Add("@Masa", SqlDbType.Decimal).Value = dr("masa")
                                cmdSGC.Parameters.Add("@Densidad", SqlDbType.Decimal).Value = dr("densidad")
                                cmdSGC.Parameters.Add("@Temperatura", SqlDbType.Decimal).Value = dr("temperatura")
                                cmdSGC.Parameters.Add("@TotalizadorInicial", SqlDbType.Int).Value = dr("totalizadorIni")
                                cmdSGC.Parameters.Add("@TotalizadorFinal", SqlDbType.Int).Value = dr("totalizadorFin")
                                cmdSGC.Parameters.Add("@Tipo", SqlDbType.VarChar).Value = dr("tipo")
                                cmdSGC.Parameters.Add("@TotalizadorInicialMasa", SqlDbType.Int).Value = dr("totalizadorIniMasa")
                                cmdSGC.Parameters.Add("@TotalizadorFinalMasa", SqlDbType.Int).Value = dr("totalizadorFinMasa")
                                cmdSGC.Parameters.Add("@Prefijado", SqlDbType.Decimal).Value = dr("prefijado")
                                cmdSGC.Parameters.Add("@DensidadPromedio", SqlDbType.Decimal).Value = dr("densidad_promedio")
                                cmdSGC.ExecuteNonQuery()
                            Next
                            trBascula.Commit()
                        Catch ex As Exception
                            trBascula.Rollback()
                            Globales.GetInstance.ExMessage(ex)
                        Finally
                            Globales.GetInstance.CierraConexion()
                            Me.Cursor = Cursors.Default
                        End Try
                    End If
                End If

            Catch ex As MySql.Data.MySqlClient.MySqlException
                conn.Close()
                MessageBox.Show("No existe conexión con la base de datos del Másico" + Chr(13) + ex.Message, "MySQL Error Level", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Catch ex As SqlException
                conn.Close()
                Dim er As SqlError
                For Each er In ex.Errors
                    MessageBox.Show(er.Message, "SQL Error Level" + CType(er.Class, String), MessageBoxButtons.OK, MessageBoxIcon.Information)
                Next
                Globales.GetInstance.ExMessage(ex)
            Catch ex As Exception
                conn.Close()
                Globales.GetInstance.ExMessage(ex)
            End Try

        Catch ex As Exception
            Globales.GetInstance.ExMessage(ex)
        End Try
    End Sub

    '20120125#Funcion que actualiza datos al SGC para el llenado y paro automatico en el MASICO
    Private Sub ActualizaSuministroSGC(ByVal Litros As Integer, ByVal Saldo As Integer, ByVal LitrosComerciales As Integer, ByVal LitrosUmbral As Integer, ByVal Autotanque As Integer)
        Try
            Dim conn As MySql.Data.MySqlClient.MySqlConnection
            Dim cmd As MySql.Data.MySqlClient.MySqlCommand
            Dim connStr As String
            connStr = Globales.GetInstance._SGCMasicoConnectionString
            conn = New MySql.Data.MySqlClient.MySqlConnection(connStr)



            Try
                'MODALIDAD PREFIJADO - Pueder surtir continuamente el autotanque sobre la cantidad registrada en VALOR
                'SGCMasicoSumUpdate1 - UPDATE RI505CA_at_config,Autotanques SET RI505CA_at_config.tipo_proceso = 2
                'SGCMasicoSumUpdate2 - , RI505CA_at_config.valor = 
                'SGCMasicoSumUpdate3 - WHERE RI505CA_at_config.Id_autotanque = Autotanques.Id_autotanque AND Autotanques.no_economico = 

                'MODALIDAD PROGRAMADA - Solo suministrará por unica ocasión la cantidad programada y cantidad programada debe ser igual a saldo para que se active la bomba. Para volver a surtir debe volverse a programar.
                'SGCMasicoSumUpdate1 - UPDATE RI505CA_at_config,Autotanques SET RI505CA_at_config.tipo_carga = 2, RI505CA_at_config.cantidad_programada = 
                'SGCMasicoSumUpdate2 - , RI505CA_at_config.saldo  = 
                'SGCMasicoSumUpdate3 - WHERE RI505CA_at_config.Id_autotanque = Autotanques.Id_autotanque AND Autotanques.no_economico = 

                conn.Open()
                Dim da As New MySql.Data.MySqlClient.MySqlDataAdapter()
                Dim dt As New DataTable()
                'PREFIJADO()
                Dim sql As String = Globales.GetInstance._SGCMasicoSumUpdate1 + Globales.GetInstance._SGCMasicoSumUpdate2 + (Litros + LitrosComerciales + LitrosUmbral).ToString() + " " + Globales.GetInstance._SGCMasicoSumUpdate3 + Autotanque.ToString()
                'PROGRAMADO()
                'Dim sql As String = Globales.GetInstance._SGCMasicoSumUpdate1 + Litros.ToString() + " " + Globales.GetInstance._SGCMasicoSumUpdate2 + Saldo.ToString() + " " + Globales.GetInstance._SGCMasicoSumUpdate3 + Autotanque.ToString()

                cmd = New MySql.Data.MySqlClient.MySqlCommand(sql, conn)
                cmd.CommandText = sql
                cmd.ExecuteNonQuery()
                conn.Close()
            Catch ex As MySql.Data.MySqlClient.MySqlException
                conn.Close()
                MessageBox.Show("No existe conexión con la base de datos del Másico" + Chr(13) + ex.Message, "MySQL Error Level", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Catch ex As Exception
                conn.Close()
                Globales.GetInstance.ExMessage(ex)
            End Try

        Catch ex As Exception
            Globales.GetInstance.ExMessage(ex)
        End Try
    End Sub

    Public Function ConsultaUltimoServicio() As String()
        Dim cmdBascula As New SqlCommand("spBASSGCConsultaUltimoServicio", Globales.GetInstance.cnSigamet)
        Dim res(1) As String
        cmdBascula.CommandType = CommandType.StoredProcedure
        cmdBascula.Parameters.Add("@Autotanque", SqlDbType.Int).Value = CInt(txtAutotanque.Text)
        Me.Cursor = Cursors.WaitCursor
        Try
            Globales.GetInstance.AbreConexion()
            Dim reader As SqlDataReader = cmdBascula.ExecuteReader
            Dim fechaInicial As DateTime
            Dim fechaFinal As DateTime
            If (reader.Read()) Then
                fechaInicial = CType(reader(0), DateTime)
                fechaFinal = CType(reader(1), DateTime)
                res(0) = fechaInicial.ToString("yyyy-MM-ddTHH:mm:ss")
                res(1) = fechaFinal.ToString("yyyy-MM-ddTHH:mm:ss")
            End If
        Catch ex As Exception
            Globales.GetInstance.ExMessage(ex)
        Finally
            Globales.GetInstance.CierraConexion()
            Me.Cursor = Cursors.Default
        End Try
        Return res
    End Function


#End Region

    '20150929#CFSL - Rutinas para calcula de eficiencia de operador segun calibracion de clientes
#Region "CalculoEficienciaOperador"
    Private Sub ConsultaDescargaOperador()
        Dim cmdBascula As New SqlCommand("spBASEficienciaOperadorCliente", Globales.GetInstance.cnSigamet)
        cmdBascula.CommandType = CommandType.StoredProcedure

        Dim daBascula As New SqlClient.SqlDataAdapter(cmdBascula)
        Dim rdEficiencia As SqlDataReader = Nothing
        cmdBascula.Parameters.Add("@AñoAtt", SqlDbType.SmallInt).Value = Año
        cmdBascula.Parameters.Add("@Folio", SqlDbType.Int).Value = Folio
        cmdBascula.Parameters.Add("@PorcentajeEmpresa", SqlDbType.Decimal).Value = Globales.GetInstance._PorcentajeGeneral
        cmdBascula.Parameters.Add("@PrecioLitro", SqlDbType.Money).Value = _PrecioLitro
        cmdBascula.Parameters.Add("@Operador", SqlDbType.Int).Value = _Operador

        Try
            Globales.GetInstance.AbreConexion()
            rdEficiencia = cmdBascula.ExecuteReader
            If rdEficiencia.Read Then

                _ClientesAtendidos = CType(rdEficiencia("ClientesAtendidos"), Integer)
                _LitrosTotalizadorSGC = CType(rdEficiencia("LitrosTotalizador"), Decimal)
                _LitrosReal = CType(rdEficiencia("LitrosReal"), Decimal)
                _EficienciaReal = CType(rdEficiencia("EficienciaReal"), Decimal)
                _EficienciaEmpresa = CType(rdEficiencia("EficienciaEmpresa"), Decimal)
                _EficienciaOperadorLitros = CType(rdEficiencia("EficienciaOperadorLitros"), Decimal)
                _EficienciaOperadorPesos = CType(rdEficiencia("EficienciaOperadorPesos"), Decimal)
                _ClienteOperador = CType(rdEficiencia("ClienteOperador"), Integer)

                rdEficiencia.Close()
            End If
        Catch ex As Exception
            Globales.GetInstance.ExMessage(ex)
            'Limpiar()
        Finally
            If Not rdEficiencia Is Nothing Then
                rdEficiencia.Close()
            End If
            Globales.GetInstance.CierraConexion()
            rdEficiencia.Close()
        End Try
    End Sub


    Private Sub CalculaComisionOperador(ByVal Pesar As Boolean)

        Dim _DiferenciaTotalizadorVsSGC As Decimal
        Dim _LitrosTotalizadorMenosEficienciaEmpresa As Decimal
        Dim _LitrosPesoPorcentaje As Decimal

        _DiferenciaTotalizadorVsSGC = CDec(Val(txtDiferenciaTotalizador.Text)) - _LitrosTotalizadorSGC

        If Pesar Then
            _LitrosPesoPorcentaje = CDec(Val(txtLitrosVendidos.Text))
        Else
            _LitrosPesoPorcentaje = CDec(Val(txtDiferenciaLitros.Text))
        End If


        'Si la diferencia de la VENTA TOTALIZADOS menos los LITROS REPORTADOS POR EL SGCWEB son iguales o están dentro de la tolerancia parametrizada se calculan los litros a favor del operador
        If _DiferenciaTotalizadorVsSGC >= Globales.GetInstance._ToleranciaNegativaSGCWEB And _DiferenciaTotalizadorVsSGC <= Globales.GetInstance._ToleranciaPositivaSGCWEB Then
            _LitrosTotalizadorMenosEficienciaEmpresa = CDec((Val(txtDiferenciaTotalizador.Text))) - _EficienciaEmpresa
            _EficienciaOperadorLitrosReal = _LitrosTotalizadorMenosEficienciaEmpresa - _LitrosPesoPorcentaje
            _EficienciaOperadorPesosReal = _EficienciaOperadorLitrosReal * _PrecioLitro
            'Si hay mas litros por VENTA TOTALIZADOR que LITROS REPORTADOR POR EL SGCWEB al excedente se le quita el Porcentaje de EMPRESA sgun parametro(5%) mas la Eficiancia Empresa que se tenga registrada.
        ElseIf _DiferenciaTotalizadorVsSGC > Globales.GetInstance._ToleranciaPositivaSGCWEB Then
            _LitrosTotalizadorMenosEficienciaEmpresa = CDec((Val(txtDiferenciaTotalizador.Text))) - (_EficienciaEmpresa + (_DiferenciaTotalizadorVsSGC * ((100 - Globales.GetInstance._PorcentajeGeneral) / 100)))
            _EficienciaOperadorLitrosReal = _LitrosTotalizadorMenosEficienciaEmpresa - _LitrosPesoPorcentaje
            _EficienciaOperadorPesosReal = _EficienciaOperadorLitrosReal * _PrecioLitro
            'Si hay menos litros por VENTA TOTALIZADOR se quita solamente el Porcentaje EMPRESA según parametro (5%)
        ElseIf _DiferenciaTotalizadorVsSGC < Globales.GetInstance._ToleranciaNegativaSGCWEB Then
            _LitrosTotalizadorMenosEficienciaEmpresa = CDec((Val(txtDiferenciaTotalizador.Text))) - (CDec((Val(txtDiferenciaTotalizador.Text))) * ((100 - Globales.GetInstance._PorcentajeGeneral) / 100))
            _EficienciaOperadorLitrosReal = _LitrosTotalizadorMenosEficienciaEmpresa - _LitrosPesoPorcentaje
            _EficienciaOperadorPesosReal = _EficienciaOperadorLitrosReal * _PrecioLitro

        End If

    End Sub



    Private Sub RegistraDatosComision()

        Dim cmdBascula As New SqlCommand("spBASRegistraComision", Globales.GetInstance.cnConexionComisiones)
        Dim trBascula As SqlTransaction = Nothing
        cmdBascula.CommandType = CommandType.StoredProcedure
        cmdBascula.CommandTimeout = 45
        Me.Cursor = Cursors.WaitCursor
        cmdBascula.Parameters.Add("@AñoAtt", SqlDbType.SmallInt).Value = Año
        cmdBascula.Parameters.Add("@FolioAtt", SqlDbType.Int).Value = Folio
        cmdBascula.Parameters.Add("@Celula", SqlDbType.TinyInt).Value = CInt(Val(txtCelulaCierre.Tag))
        cmdBascula.Parameters.Add("@RutaC", SqlDbType.SmallInt).Value = CInt(Val(txtRutaCierre.Tag))
        cmdBascula.Parameters.Add("@Autotanque", SqlDbType.SmallInt).Value = CType((txtAutotanque.Text), Integer)
        cmdBascula.Parameters.Add("@Operador", SqlDbType.Int).Value = _Operador
        cmdBascula.Parameters.Add("@Cliente", SqlDbType.Int).Value = _ClienteOperador
        cmdBascula.Parameters.Add("@FSuministro", SqlDbType.DateTime).Value = bdtpFSalida.Value
        cmdBascula.Parameters.Add("@ClientesAtendidos", SqlDbType.SmallInt).Value = _ClientesAtendidos
        cmdBascula.Parameters.Add("@Totalizador", SqlDbType.Decimal).Value = CDec(Val(txtDiferenciaTotalizador.Text))
        cmdBascula.Parameters.Add("@TotalizadorSGC", SqlDbType.Decimal).Value = _LitrosTotalizadorSGC
        cmdBascula.Parameters.Add("@TotalizadorReal", SqlDbType.Decimal).Value = _LitrosReal
        If _FactorDensidadMasico Then
            cmdBascula.Parameters.Add("@FactorDensidad", SqlDbType.Decimal).Value = _FDRellenos
        Else
            cmdBascula.Parameters.Add("@FactorDensidad", SqlDbType.Decimal).Value = Globales.GetInstance._FactorDensidad
        End If
        cmdBascula.Parameters.Add("@PesoVenta", SqlDbType.Decimal).Value = CDec(Val(txtVenta.Text))
        cmdBascula.Parameters.Add("@LitrosPesoVenta", SqlDbType.Decimal).Value = CDec(Val(txtLitrosVendidos.Text))
        cmdBascula.Parameters.Add("@LitrosPorcentajeVenta", SqlDbType.Decimal).Value = CDec(Val(txtDiferenciaLitros.Text))
        cmdBascula.Parameters.Add("@LitrosEmpresa", SqlDbType.Decimal).Value = _EficienciaEmpresa
        cmdBascula.Parameters.Add("@LitrosOperador", SqlDbType.Decimal).Value = _EficienciaOperadorLitros
        cmdBascula.Parameters.Add("@LitrosOperadorPago", SqlDbType.Decimal).Value = _EficienciaOperadorLitrosReal
        cmdBascula.Parameters.Add("@TotalOperadorPago", SqlDbType.Money).Value = _EficienciaOperadorPesosReal
        cmdBascula.Parameters.Add("@PrecioPago", SqlDbType.Money).Value = _PrecioLitro
        cmdBascula.Parameters.Add("@LitrosOperadorCobro", SqlDbType.Decimal).Value = 0
        cmdBascula.Parameters.Add("@TotalCobro", SqlDbType.Money).Value = 0
        cmdBascula.Parameters.Add("@PrecioCobro", SqlDbType.Money).Value = 0

        Try
            Globales.GetInstance.AbreConexionComisiones()
            trBascula = Globales.GetInstance.cnConexionComisiones.BeginTransaction
            cmdBascula.Transaction = trBascula
            cmdBascula.ExecuteNonQuery()
            trBascula.Commit()
        Catch ex As Exception
            trBascula.Rollback()
            'Globales.GetInstance.ExMessage(ex)
        Finally
            Globales.GetInstance.CierraConexionComisiones()
            Me.Cursor = Cursors.Default
        End Try

    End Sub



#End Region








#Region "Botones y barra de herramientas"
    Private Sub btnBuscarAtt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarAtt.Click
        If chkPG.Checked Then
            BuscaPG()
        Else
            BuscaAutotanque()
        End If
    End Sub

    Private Sub tbAutotanque_ButtonClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolBarButtonClickEventArgs) Handles tbAutotanque.ButtonClick
        Select Case e.Button.Text
            Case "Limpiar"
                Limpiar()
            Case "Anular"
                Anular()
            Case "Modificar"
                Modificar()
            Case "Especial"
                GeneraCicloEspecial()
            Case "Calculadora"
                Shell("Calc.exe")
            Case "Cerrar"
                Me.Close()
                Me.Dispose()
        End Select
    End Sub

    Private Sub btnPesar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPesar.Click
        Select Case EstadoActual
            Case Estado.AperturaCiclo
                If ValidaFechaSalidaMovimientoApertura() Then
                    txtPesoApertura.Focus()
                    ProcesoAperturaCiclo()

                   
                End If
            Case Estado.CierreCiclo
                If ValidaFechaSalidaMovimientoCierre() Then
                    txtPesoCierre.Focus()
                    ProcesoCierreCiclo()
                   
                End If
            Case Estado.PesadoPGLleno
                txtPesoApertura.Focus()
                ProcesoPGLleno()
            Case Estado.PesadoPGVacio
                txtPesoCierre.Focus()
                ProcesoPGVacio()
        End Select
    End Sub
#End Region
#Region "Rutinas de validaión"
    Private Function ValidaAperuta() As Boolean
        'If txtKilometrajeApertura.Text.Trim = "" Then
        '    ErrMessage("No ha escrito el kilometraje.")
        '    txtKilometrajeApertura.Focus()
        '    Return False
        'Else
        If txtPorcentajeApertura.Text.Trim = "" Then
            Globales.GetInstance.ErrMessage("No ha escrito el porcentaje de llenado.")
            txtPorcentajeApertura.Focus()
            txtPorcentajeApertura.Focus()
        ElseIf Val(txtPorcentajeApertura.Text) > Globales.GetInstance._MaxPorcentajeLlenado Then
            Globales.GetInstance.ErrMessage("El porcentaje de llenado no puede ser mayor al " & Globales.GetInstance._MaxPorcentajeLlenado.ToString)
            txtPorcentajeApertura.Focus()
            Return False
        ElseIf Val(txtPorcentajeApertura.Text) = 0 Then
            Globales.GetInstance.ErrMessage("El porcentaje de llenado no puede ser igual a 0")
            txtPorcentajeApertura.Focus()
            Return False
        ElseIf Globales.GetInstance._MedicionFisica AndAlso txtTemperatura.Text.Trim = String.Empty Then
            Globales.GetInstance.ErrMessage("Debe capturar la temperatura.")
            txtTemperatura.Focus()
            Return False
        ElseIf Globales.GetInstance._MedicionFisica AndAlso txtPresion.Text.Trim = String.Empty Then
            Globales.GetInstance.ErrMessage("Debe capturar la presión.")
            txtPresion.Focus()
            Return False
        ElseIf Globales.GetInstance._MedicionFisica AndAlso txtEmpleado.Text.Trim = String.Empty Then
            Globales.GetInstance.ErrMessage("Debe capturar el empleado.")
            txtEmpleado.Focus()
            Return False
        ElseIf Globales.GetInstance._MedicionFisica AndAlso (Val(txtTemperatura.Text) < Globales.GetInstance._TemperaturaMinima OrElse Val(txtTemperatura.Text) > Globales.GetInstance._TemperaturaMaxima) Then
            Globales.GetInstance.ErrMessage("La temperatura está fuera de los límites (" + Globales.GetInstance._TemperaturaMinima.ToString + ", " + Globales.GetInstance._TemperaturaMaxima.ToString + ").")
            txtTemperatura.Focus()
            Return False
        ElseIf Globales.GetInstance._MedicionFisica AndAlso (Val(txtPresion.Text) < Globales.GetInstance._PresionMinimaGas OrElse Val(txtPresion.Text) > Globales.GetInstance._PresionMaximaGas) Then
            Globales.GetInstance.ErrMessage("La presión está fuera de los límites (" & Globales.GetInstance._PresionMinimaGas & "," & Globales.GetInstance._PresionMaximaGas & ").")
            txtPresion.Focus()
            Return False
        ElseIf Globales.GetInstance._TipoCalculoAlmacen = 1 AndAlso Val(txtLitrosCargados.Text) = 0 Then
            Globales.GetInstance.ErrMessage("No ha capturado los litros cargados.")
            txtLitrosCargados.Focus()
            Return False
        ElseIf Globales.GetInstance._ContenedorPredeterminado = 0 AndAlso cboContenedor.SelectedIndex = 0 AndAlso cboTipoMovimiento.SelectedIndex = 0 Then
            Globales.GetInstance.ErrMessage("No ha seleccionado el almacen contenedor.")
            cboContenedor.Focus()
            Return False
        ElseIf CInt(cboAlmacenEntrada.SelectedIndex) = -1 Then
            Globales.GetInstance.ErrMessage("El autotanque no tiene asignado un almacén.")
            cboAlmacenEntrada.Focus()
            Return False
        Else
            Return True
        End If
    End Function
    Private Function ValidaCierre() As Boolean
        'If txtKilometrajeCierre.Text.Trim = "" Then
        '    ErrMessage("No ha escrito el kilometraje.")
        '    txtKilometrajeCierre.Focus()
        '    Return False
        'Else
        If txtTotalizadorCierre.Text.Trim = "" Then
            Globales.GetInstance.ErrMessage("No ha escrito la lectura del totalizador.")
            txtTotalizadorCierre.Focus()
            Return False
        ElseIf txtPorcentajeCierre.Text.Trim = "" Then
            Globales.GetInstance.ErrMessage("No ha escrito el porcentaje de gas no vendido.")
            txtPorcentajeCierre.Focus()
            Return False
        ElseIf Val(txtKilometrajeApertura.Text) > Val(txtKilometrajeCierre.Text) Then
            Globales.GetInstance.ErrMessage("El kilometraje final no puede ser menor al kilometraje inicial.")
            txtKilometrajeCierre.Focus()
            Return False
        ElseIf Val(txtKilometrajeCierre.Text) - Val(txtKilometrajeApertura.Text) > Globales.GetInstance._RangoKilometraje Then
            Globales.GetInstance.ErrMessage("El kilometraje final es demasiado grande; la diferencia de kilometrajes debe ser menor a " & _
                        Globales.GetInstance._RangoKilometraje.ToString & ".")
            txtKilometrajeCierre.Focus()
            Return False
        ElseIf _SentidoMovimiento = 1 AndAlso Val(txtTotalizadorApertura.Text) > Val(txtTotalizadorCierre.Text) Then
            Globales.GetInstance.ErrMessage("El totalizador final no puede ser menor al totalizador inicial.")
            txtTotalizadorCierre.Focus()
            Return False
        ElseIf _SentidoMovimiento = 1 AndAlso Val(txtPorcentajeApertura.Text) < Val(txtPorcentajeCierre.Text) Then
            Globales.GetInstance.ErrMessage("El porcentaje de llenado no puede ser menor al porcentaje de gas no vendido.")
            txtPorcentajeCierre.Focus()
            Return False
        ElseIf Globales.GetInstance._MedicionFisica AndAlso txtTemperatura.Text.Trim = String.Empty Then
            Globales.GetInstance.ErrMessage("Debe capturar la temperatura.")
            txtTemperatura.Focus()
            Return False
        ElseIf Globales.GetInstance._MedicionFisica AndAlso txtPresion.Text.Trim = String.Empty Then
            Globales.GetInstance.ErrMessage("Debe capturar la presión.")
            txtPresion.Focus()
            Return False
        ElseIf Globales.GetInstance._MedicionFisica AndAlso txtEmpleado.Text.Trim = String.Empty Then
            Globales.GetInstance.ErrMessage("Debe capturar el empleado.")
            txtEmpleado.Focus()
            Return False
        ElseIf Globales.GetInstance._MedicionFisica AndAlso (Val(txtTemperatura.Text) < Globales.GetInstance._TemperaturaMinima OrElse Val(txtTemperatura.Text) > Globales.GetInstance._TemperaturaMaxima) Then
            Globales.GetInstance.ErrMessage("La temperatura está fuera de los límites (" + Globales.GetInstance._TemperaturaMinima.ToString + ", " + Globales.GetInstance._TemperaturaMaxima.ToString + ").")
            txtTemperatura.Focus()
            Return False
        ElseIf Globales.GetInstance._MedicionFisica AndAlso (Val(txtPresion.Text) < Globales.GetInstance._PresionMinimaGas OrElse Val(txtPresion.Text) > Globales.GetInstance._PresionMaximaGas) Then
            Globales.GetInstance.ErrMessage("La presión está fuera de los límites (" & Globales.GetInstance._PresionMinimaGas & "," & Globales.GetInstance._PresionMaximaGas & ").")
            txtPresion.Focus()
            Return False
        Else
            Return True
        End If
    End Function
    Private Function ValidaPGLleno() As Boolean
        If Val(txtPorcentajeApertura.Text) > Globales.GetInstance._MaxPorcentajeLlenado Then
            Globales.GetInstance.ErrMessage("El porcentaje de llenado no puede ser mayor al " & Globales.GetInstance._MaxPorcentajeLlenado.ToString)
            txtPorcentajeApertura.Focus()
            Return False
        ElseIf Val(txtCapacidad.Text) = 0 AndAlso ccboPG.SelectedIndex > -1 Then
            Globales.GetInstance.ErrMessage("La capacidad del PG es incorrecta.")
            txtCapacidad.Focus()
            Return False
        Else
            Return True
        End If
    End Function
    Private Function ValidaPGVacio() As Boolean
        If _SentidoMovimiento = 1 AndAlso Val(txtPorcentajeApertura.Text) < Val(txtPorcentajeCierre.Text) Then
            Globales.GetInstance.ErrMessage("El porcentaje de llenado no puede ser menor al porcentaje de gas no vendido.")
            txtPorcentajeCierre.Focus()
            Return False
        Else
            Return True
        End If
    End Function


#End Region
#Region "Validacion de FechaSalida VS FechaMovimiento"
    Private Function ValidaFechaSalidaMovimientoApertura() As Boolean
        If Globales.GetInstance._PedirFMovimiento Then
            If dtpFMovimiento.Value.Date > bdtpFSalida.Value.Date Then
                Globales.GetInstance.ErrMessage("La fecha del movimiento de apertura no puede ser posterior a la fecha de salida.")
                ActiveControl = bdtpFSalida
                Return False
            Else
                Return True
            End If
        Else
            Return True
        End If
    End Function

    Private Function ValidaFechaSalidaMovimientoCierre() As Boolean
        If Globales.GetInstance._PedirFMovimiento Then
            If dtpFMovimiento.Value.Date < bdtpFSalida.Value.Date Then
                Globales.GetInstance.ErrMessage("La fecha del movimiento de cierre no puede ser anterior a la fecha de salida.")
                ActiveControl = bdtpFSalida
                Return False
            Else
                Return True
            End If
        Else
            Return True
        End If
    End Function
#End Region
#Region "Rutinas de cálculo de diferencias"
    Private Sub txtPorcentajeApertura_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPorcentajeApertura.TextChanged
        txtLitrosApertura.Text = (Val(txtCapacidad.Text) * Val(txtPorcentajeApertura.Text) / 100).ToString
    End Sub
    Private Sub txtKilometrajeCierre_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtKilometrajeCierre.TextChanged
        Try
            txtDiferenciaKilometraje.Text = (Val(txtKilometrajeCierre.Text) - Val(txtKilometrajeApertura.Text)).ToString
        Catch ex As InvalidCastException
            Globales.GetInstance.ErrMessage("El valor escrito es demasiado grande.")
            txtKilometrajeCierre.Clear()




            txtKilometrajeCierre.Focus()
        Catch ex As Exception
            Globales.GetInstance.ExMessage(ex)
        End Try
    End Sub
    Private Sub txtTotalizadorCierre_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtTotalizadorCierre.TextChanged
        Try
            txtDiferenciaTotalizador.Text = (Val(txtTotalizadorCierre.Text) - Val(txtTotalizadorApertura.Text)).ToString
            txtLitrosLiquidados.Text = txtDiferenciaTotalizador.Text
            CalculaEficienciaPorPorcentaje()
            CalculaEficienciaPorPeso()
        Catch ex As InvalidCastException
            Globales.GetInstance.ErrMessage("El valor escrito es demasiado grande.")
            txtTotalizadorCierre.Clear()
            txtTotalizadorCierre.Focus()
        Catch ex As Exception
            Globales.GetInstance.ExMessage(ex)
        End Try
    End Sub

    Private Sub txtPorcentajeCierre_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPorcentajeCierre.TextChanged
        Try
            ''Dim Eficiencia As Decimal
            txtLitrosCierre.Text = (Val(txtCapacidad.Text) * Val(txtPorcentajeCierre.Text) / 100).ToString
            txtDiferenciaPorcentaje.Text = (_SentidoMovimiento * (Val(txtPorcentajeApertura.Text) - Val(txtPorcentajeCierre.Text))).ToString
            txtDiferenciaLitros.Text = (_SentidoMovimiento * (Val(txtLitrosApertura.Text) - Val(txtLitrosCierre.Text))).ToString
            CalculaEficienciaPorPorcentaje()

            txtVenta.Text = (_SentidoMovimiento * (Val(txtPesoApertura.Text) - Val(txtPesoCierre.Text))).ToString
            '#20120413#HEMOPA-FIN
            '#20120413#HEMOPA-INICIO
            'txtLitrosVendidos.Text = Format(Val(txtVenta.Text) / Globales.GetInstance._FactorDensidad, "###0.00")
            If Globales.GetInstance._FDRellenosSiNo Or Globales.GetInstance._FDRellenosATTIndividual Then
                '20131001#CFSL-INICIO
                If _FactorDensidadMasico Then
                    txtLitrosVendidos.Text = Format(Val(txtVenta.Text) / _FDRellenos, "###0.00")
                Else
                    txtLitrosVendidos.Text = Format(Val(txtVenta.Text) / Globales.GetInstance._FactorDensidad, "###0.00")
                End If
                '20131001#CFSL-FIN
            Else
                txtLitrosVendidos.Text = Format(Val(txtVenta.Text) / Globales.GetInstance._FactorDensidad, "###0.00")
            End If
            '#20120413#HEMOPA-FIN

            CalculaEficienciaPorPeso()
        Catch ex As InvalidCastException
            Globales.GetInstance.ErrMessage("El valor escrito es demasiado grande.")
            txtPorcentajeCierre.Clear()
            txtPorcentajeCierre.Focus()
        Catch ex As Exception
            Globales.GetInstance.ExMessage(ex)
        End Try
    End Sub
    Private Sub txtPesoCierre_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPesoCierre.TextChanged
        txtVenta.Text = (_SentidoMovimiento * (Val(txtPesoApertura.Text) - Val(txtPesoCierre.Text))).ToString

        '#20120413#HEMOPA-INICIO-FIN
        'txtLitrosVendidos.Text = Format(Val(txtVenta.Text) / Globales.GetInstance._FactorDensidad, "###0.00")
        If Globales.GetInstance._FDRellenosSiNo Or Globales.GetInstance._FDRellenosATTIndividual Then
            '20131001#CFSL-INICIO
            If _FactorDensidadMasico Then
                txtLitrosVendidos.Text = Format(Val(txtVenta.Text) / _FDRellenos, "###0.00")
            Else
                txtLitrosVendidos.Text = Format(Val(txtVenta.Text) / Globales.GetInstance._FactorDensidad, "###0.00")
            End If
            '20131001#CFSL-FIN
        Else
            txtLitrosVendidos.Text = Format(Val(txtVenta.Text) / Globales.GetInstance._FactorDensidad, "###0.00")
        End If
        '#20120413#HEMOPA-FIN

        CalculaEficienciaPorPeso()
    End Sub

    Private Sub CalculaEficienciaPorPorcentaje()
        '#20120413#HEMOPA-INICIO
        Dim _EficienciaCalculo As Byte = Globales.GetInstance._Eficiencia
        Dim _FormulaEficienciaCalculo As Short = Globales.GetInstance._FormulaEficiencia

        If (Globales.GetInstance._PesadoAutotanqueIndividual = True And _PesoAutomatico = True) Then
            _EficienciaCalculo = Globales.GetInstance._EficienciaPesadoATT
            _FormulaEficienciaCalculo = Globales.GetInstance._FormulaEficPesadoATT
        End If
        '#20120413#HEMOPA-FIN

        '#20120413#HEMOPA-INICIO-FIN

        If _EficienciaCalculo = 2 Or _EficienciaCalculo = 3 Or _EficienciaCalculo = 4 Or _EficienciaCalculo = 5 Then
            Select Case _FormulaEficienciaCalculo
                Case 4
                    Dim FactorPorcentaje As Decimal = 2 - _CalibracionPorcentajeAutotanque
                    Dim DiferenciaVolumen As Decimal = CDec(Val(txtDiferenciaTotalizador.Text) - (Val(txtDiferenciaLitros.Text) * FactorPorcentaje))
                    If _SentidoMovimiento = 1 AndAlso (DiferenciaVolumen >= (Globales.GetInstance._ValorMinimoPorPorcentaje * -1)) Then
                        txtLitrosPeso.Text = "0"
                        txtImportePeso.Text = "0"
                    Else
                        txtLitrosPeso.Text = Format(Math.Abs(DiferenciaVolumen), "###00.00")
                        txtImportePeso.Text = Format((Val(txtPrecio.Text) * Val(txtLitrosPeso.Text)), "###00.00")
                    End If


                    Dim SoloDiferenciaVolumen As Decimal = CDec(Val(txtDiferenciaTotalizador.Text) - Val(txtDiferenciaLitros.Text))
                    If _SentidoMovimiento = 1 AndAlso (SoloDiferenciaVolumen >= (Globales.GetInstance._ValorMinimoPorPorcentaje * -1)) Then
                        txtLitrosPeso.Text = "0"
                        txtImportePeso.Text = "0"
                    Else
                        txtLitrosPorcentaje.Text = Format(Math.Abs(SoloDiferenciaVolumen), "###00.00")
                        txtImportePorcentaje.Text = Format((Val(txtPrecio.Text) * Val(txtLitrosPeso.Text)), "###00.00")
                    End If

                Case 5
                    Dim FactorPorcentaje As Decimal = 2 - _CalibracionPorcentajeAutotanque
                    Dim DiferenciaVolumen As Decimal = CDec(((Val(txtDiferenciaLitros.Text) * FactorPorcentaje)) - Globales.GetInstance._ValorCalculoEficiencia)
                    If _SentidoMovimiento = 1 AndAlso (Val(txtDiferenciaTotalizador.Text) >= DiferenciaVolumen) Then
                        txtLitrosPeso.Text = "0"
                        txtImportePeso.Text = "0"
                        txtLitrosPorcentaje.Text = "0"
                        txtImportePorcentaje.Text = "0"

                    Else
                        '20120125#Se le suman los listors que se quitan como tolerancia
                        DiferenciaVolumen = DiferenciaVolumen + Globales.GetInstance._ValorCalculoEficiencia
                        txtLitrosPeso.Text = Format(Math.Abs(DiferenciaVolumen - Val(txtDiferenciaTotalizador.Text)), "###00.00")
                        txtImportePeso.Text = Format((Val(txtPrecio.Text) * Val(txtLitrosPeso.Text)), "###00.00")
                        txtLitrosPorcentaje.Text = Format(Math.Abs(DiferenciaVolumen - Val(txtDiferenciaTotalizador.Text)), "###00.00")
                        txtImportePorcentaje.Text = Format((Val(txtPrecio.Text) * Val(txtLitrosPorcentaje.Text)), "###00.00")
                    End If

                    '20100310#CFSL - El calculo de la diferencia se almacena en el ciclo anterior
                Case 7
                    txtLitrosPorcentaje.Text = "0"
                    txtImportePorcentaje.Text = "0"

                Case Else
                    Dim PSalida As Decimal = CDec(0.0182 * Val(txtCapacidad.Text) * (100 - Val(txtPorcentajeApertura.Text)) / 100)
                    Dim PLlegada As Decimal = CDec(0.0182 * Val(txtCapacidad.Text) * (100 - Val(txtPorcentajeCierre.Text)) / 100)
                    Dim VaporGas As Decimal = PLlegada - PSalida
                    Dim Eficiencia As Decimal = CDec(Val(txtDiferenciaTotalizador.Text) - 1.02 * Val(txtDiferenciaLitros.Text) + VaporGas)
                    If _SentidoMovimiento = 1 AndAlso Eficiencia < 0 AndAlso Math.Abs(Eficiencia) > Globales.GetInstance._ValorMinimoPorPorcentaje Then
                        Eficiencia = Math.Abs(Eficiencia)
                        txtLitrosPorcentaje.Text = Format(Eficiencia, "###00.00")
                        txtImportePorcentaje.Text = Format((Val(txtPrecio.Text) * Eficiencia), "###00.00")
                    Else
                        txtLitrosPorcentaje.Text = "0"
                        txtImportePorcentaje.Text = "0"
                    End If
            End Select
        End If
    End Sub

    'FORMULA VERIFICADA EN METROPOLITANO 20110509
    'El valor de los parametro tienen
    'Eficiencia = 3
    'FormulaEficiencia = 3

    Private Sub CalculaEficienciaPorPeso()
        '#20120413#HEMOPA-INICIO
        Dim _EficienciaCalculo As Byte = Globales.GetInstance._Eficiencia
        Dim _FormulaEficienciaCalculo As Short = Globales.GetInstance._FormulaEficiencia

        If (Globales.GetInstance._PesadoAutotanqueIndividual = True And _PesoAutomatico = True) Then
            _EficienciaCalculo = Globales.GetInstance._EficienciaPesadoATT
            _FormulaEficienciaCalculo = Globales.GetInstance._FormulaEficPesadoATT
        End If
        '#20120413#HEMOPA-FIN

        '#20120413#HEMOPA-INICIO-FIN
        If _EficienciaCalculo = 1 Or _EficienciaCalculo = 3 Then
            Select Case _FormulaEficienciaCalculo
                Case 1
                    '2% después de diferencia
                    Dim Diferencia As Decimal = CDec(Val(txtDiferenciaTotalizador.Text) - Val(txtLitrosVendidos.Text))
                    If Diferencia < 0 Then
                        txtLitrosPeso.Text = Format(Math.Abs(Diferencia) + 0.02 * Val(txtLitrosLiquidados.Text), "###00.00")
                        txtImportePeso.Text = Format((Val(txtPrecio.Text) * Val(txtLitrosPeso.Text)), "###00.00")
                    Else
                        txtLitrosPeso.Text = "0"
                        txtImportePeso.Text = "0"
                    End If
                Case 2
                    '2% antes de diferencia 
                    Dim Factor As Decimal = 2 - _CalibracionAutotanque
                    Dim Diferencia As Decimal = CDec(Val(txtDiferenciaTotalizador.Text) - Factor * Val(txtLitrosVendidos.Text))
                    If _SentidoMovimiento = 1 AndAlso Diferencia < -20 Then
                        txtLitrosPeso.Text = Format(Math.Abs(Diferencia), "###00.00")
                        txtImportePeso.Text = Format((Val(txtPrecio.Text) * Val(txtLitrosPeso.Text)), "###00.00")
                    Else
                        txtLitrosPeso.Text = "0"
                        txtImportePeso.Text = "0"
                    End If
                Case 3
                    Dim FactorPorcentaje As Decimal = 2 - _CalibracionPorcentajeAutotanque
                    Dim FactorPeso As Decimal = 2 - _CalibracionAutotanque
                    Dim DiferenciaVolumen As Decimal = CDec(Val(txtDiferenciaTotalizador.Text) - (Val(txtDiferenciaLitros.Text) * FactorPorcentaje))
                    Dim DiferenciaPeso As Decimal = CDec(Val(txtDiferenciaTotalizador.Text) - Val(txtLitrosVendidos.Text) * FactorPeso)
                    If _SentidoMovimiento = 1 AndAlso (DiferenciaPeso >= -20 Or DiferenciaVolumen >= -20) Then
                        txtLitrosPeso.Text = "0"
                        txtImportePeso.Text = "0"
                    Else
                        txtLitrosPeso.Text = Format(Math.Min(Math.Abs(DiferenciaVolumen), Math.Abs(DiferenciaPeso)), "###00.00")
                        txtImportePeso.Text = Format((Val(txtPrecio.Text) * Val(txtLitrosPeso.Text)), "###00.00")
                    End If
                    '20090503 Nueva Formula
                Case 6
                    Dim FactorPorcentaje As Decimal = 2 - _CalibracionPorcentajeAutotanque
                    Dim FactorPeso As Decimal = 2 - _CalibracionAutotanque

                    'Nueva Formula Parala Efieciancia Ajusta se quita un punto en el %
                    Dim _LitrosCierre As String = (Val(txtCapacidad.Text) * (Val(txtPorcentajeCierre.Text) - 1) / 100).ToString
                    Dim _DiferenciaLitros As String = (_SentidoMovimiento * (Val(txtLitrosApertura.Text) - Val(_LitrosCierre))).ToString

                    Dim DiferenciaVolumen As Decimal = CDec(Val(txtDiferenciaTotalizador.Text) - (Val(txtDiferenciaLitros.Text) * FactorPorcentaje))
                    Dim DiferenciaVolumenAjustado As Decimal = CDec(Val(txtDiferenciaTotalizador.Text) - (Val(_DiferenciaLitros) * FactorPorcentaje))
                    Dim DiferenciaPeso As Decimal = CDec(Val(txtDiferenciaTotalizador.Text) - Val(txtLitrosVendidos.Text) * FactorPeso)

                    'txtLitrosPeso.Text = "0"
                    'txtImportePeso.Text = "0"
                    If _SentidoMovimiento = 1 AndAlso (DiferenciaPeso <= 20) Then
                        If (DiferenciaVolumen <= 20) Then
                            txtLitrosPeso.Text = Format(Math.Min(Math.Abs(DiferenciaVolumen), Math.Abs(DiferenciaPeso)), "###00.00")
                            txtImportePeso.Text = Format((Val(txtPrecio.Text) * Val(txtLitrosPeso.Text)), "###00.00")
                        Else
                            If (DiferenciaVolumenAjustado <= 20) Then
                                txtLitrosPeso.Text = Format(Math.Min(Math.Abs(DiferenciaVolumenAjustado), Math.Abs(DiferenciaPeso)), "###00.00")
                                txtImportePeso.Text = Format((Val(txtPrecio.Text) * Val(txtLitrosPeso.Text)), "###00.00")
                            Else
                                txtLitrosPeso.Text = "0"
                                txtImportePeso.Text = "0"
                            End If
                        End If
                    Else
                        txtLitrosPeso.Text = "0"
                        txtImportePeso.Text = "0"
                    End If

                    '20100310#CFSL - El calculo de la diferencia se almacena en el ciclo anterior
                Case 7
                    txtLitrosPeso.Text = "0"
                    txtImportePeso.Text = "0"
                Case 8
                    '#20120413#HEMOPA-INICIO
                    Dim FactorPeso As Decimal = 2 - _CalibracionAutotanque
                    Dim DiferenciaPeso As Decimal = CDec((Val(txtDiferenciaTotalizador.Text) - (Val(txtLitrosVendidos.Text) * FactorPeso)) - Globales.GetInstance._ValorCalculoEficiencia)
                    If _SentidoMovimiento = 1 AndAlso (DiferenciaPeso >= 0) Then
                        txtLitrosPeso.Text = "0"
                        txtImportePeso.Text = "0"
                        txtLitrosPorcentaje.Text = "0"
                        txtImportePorcentaje.Text = "0"
                    Else
                        DiferenciaPeso = DiferenciaPeso + Globales.GetInstance._ValorCalculoEficiencia
                        txtLitrosPeso.Text = Format(Math.Abs(DiferenciaPeso), "###00.00")
                        txtImportePeso.Text = Format((Val(txtPrecio.Text) * Val(txtLitrosPeso.Text)), "###00.00")
                        txtLitrosPorcentaje.Text = Format(Math.Abs(DiferenciaPeso), "###00.00")
                        txtImportePorcentaje.Text = Format((Val(txtPrecio.Text) * Val(txtLitrosPorcentaje.Text)), "###00.00")
                    End If
                    '#20120413#HEMOPA-FIN

            End Select
        End If
    End Sub

    Private Sub CalculaDiferencias()
        Try
            ''Dim Eficiencia As Decimal
            txtLitrosApertura.Text = (Val(txtCapacidad.Text) * Val(txtPorcentajeApertura.Text) / 100).ToString
            txtDiferenciaKilometraje.Text = (Val(txtKilometrajeCierre.Text) - Val(txtKilometrajeApertura.Text)).ToString
            txtDiferenciaTotalizador.Text = (_SentidoMovimiento * (Val(txtTotalizadorCierre.Text) - Val(txtTotalizadorApertura.Text))).ToString
            txtLitrosLiquidados.Text = txtDiferenciaTotalizador.Text
            CalculaEficienciaPorPorcentaje()
            CalculaEficienciaPorPeso()
            txtLitrosCierre.Text = (Val(txtCapacidad.Text) * Val(txtPorcentajeCierre.Text) / 100).ToString
            txtDiferenciaPorcentaje.Text = (_SentidoMovimiento * (Val(txtPorcentajeApertura.Text) - Val(txtPorcentajeCierre.Text))).ToString
            txtDiferenciaLitros.Text = (_SentidoMovimiento * (Val(txtLitrosApertura.Text) - Val(txtLitrosCierre.Text))).ToString
            CalculaEficienciaPorPorcentaje()
            txtVenta.Text = (_SentidoMovimiento * (Val(txtPesoApertura.Text) - Val(txtPesoCierre.Text))).ToString

            '#20120413#HEMOPA-INICIO-FIN
            'txtLitrosVendidos.Text = (Val(txtVenta.Text) / Globales.GetInstance._FactorDensidad).ToString
            If Globales.GetInstance._FDRellenosSiNo Or Globales.GetInstance._FDRellenosATTIndividual Then
                '20131001#CFSL-INICIO
                If _FactorDensidadMasico Then
                    txtLitrosVendidos.Text = Format(Val(txtVenta.Text) / _FDRellenos, "###0.00")
                Else
                    txtLitrosVendidos.Text = Format(Val(txtVenta.Text) / Globales.GetInstance._FactorDensidad, "###0.00")
                End If
                '20131001#CFSL-FIN
            Else
                txtLitrosVendidos.Text = Format(Val(txtVenta.Text) / Globales.GetInstance._FactorDensidad, "###0.00")
            End If
            '#20120413#HEMOPA-FIN

            CalculaEficienciaPorPeso()
        Catch ex As InvalidCastException
            Globales.GetInstance.ErrMessage("El valor escrito es demasiado grande.")
            txtKilometrajeCierre.Clear()
            txtKilometrajeCierre.Focus()
        Catch ex As Exception
            Globales.GetInstance.ExMessage(ex)
        End Try
    End Sub
#End Region
#Region "Procesos de pesado"
    Private Sub ProcesoAperturaCiclo()
        If ValidaAperuta() Then
            If Globales.GetInstance.OperacionBascula(9).Habilitada AndAlso Val(txtPesoApertura.Text) = 0 Then
                txtPesoApertura.Text = LeeBascula.ToString
            End If
            '#20120413#HEMOPA-INICIO
            If ((Globales.GetInstance._ExisteBascula And Globales.GetInstance._PesadoAutotanqueIndividual = False) Or (Globales.GetInstance._ExisteBascula And Globales.GetInstance._PesadoAutotanqueIndividual And _PesoAutomatico)) AndAlso txtPesoApertura.Text.Trim = "" Then
                Globales.GetInstance.ErrMessage("No ha escrito el peso de salida.")
                txtPesoApertura.Focus()
            ElseIf ((Globales.GetInstance._ExisteBascula And Globales.GetInstance._PesadoAutotanqueIndividual = False) Or (Globales.GetInstance._ExisteBascula And Globales.GetInstance._PesadoAutotanqueIndividual And _PesoAutomatico)) AndAlso Val(txtPesoApertura.Text) <= 0 Then
                '#20120413#HEMOPA-FIN
                Globales.GetInstance.ErrMessage("La lectura de báscula es incorrecta, intente de nuevo.")
                btnPesar.Focus()
                txtPesoApertura.Focus()
            Else

                Dim PesoApertura As Decimal
                PesoApertura = CDec(Val(txtPesoApertura.Text))
                '#20120413#HEMOPA-INICIO-FIN
                If ((Globales.GetInstance._ExisteBascula And Globales.GetInstance._PesadoAutotanqueIndividual = False) Or (Globales.GetInstance._ExisteBascula And Globales.GetInstance._PesadoAutotanqueIndividual And _PesoAutomatico)) Then
                    If MessageBox.Show("El peso de apertura es: " & PesoApertura.ToString("N2") & " Kgs. ¿Es correcto?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
                        '20120124#CFSL -INICIO- Migrar Datos del SGC
                        If Globales.GetInstance._ExisteMasico Then
                            MigraDatosMasico()
                        Else
                            FolioAnt = 0
                            AñoAnt = 0
                            DifTotalizador = 0
                            EficienciaMasico = 0
                            ImporteEficienciaMasico = 0
                        End If
                        '20120124#CFSL -FIN- Migrar Datos del SGC
                        If AbreCiclo(PesoApertura) Then
                            cboAlmacenEntrada.Enabled = False
                            rgrpMedicionFisica.Enabled = False
                            If cboTipoMovimiento.SelectedIndex = 2 Then
                                ImprimirCicloResguardo(Año, Folio)
                            Else
                                ImprimirAbreCiclo(Año, Folio)
                            End If


                            LimpiaBascula()
                            btnImprimir.Enabled = Globales.GetInstance.OperacionBascula(1).Habilitada
                            mniReporteApertura.Enabled = True
                            cboTipoMovimiento.Enabled = False
                            cboContenedor.Enabled = False
                            bdtpFSalida.Enabled = False
                            tbAutotanque.Focus()

                            'TEXIS FIN DE RUTINA DE APERTURA 
                            Limpiar()

                        End If
                    End If
                Else
                    '20120124#CFSL -INICIO- Migrar Datos del SGC
                    If Globales.GetInstance._ExisteMasico Then
                        MigraDatosMasico()
                    Else
                        FolioAnt = 0
                        AñoAnt = 0
                        DifTotalizador = 0
                        EficienciaMasico = 0
                        ImporteEficienciaMasico = 0
                    End If
                    '20120124#CFSL -FIN- Migrar Datos del SGC
                    If AbreCiclo(PesoApertura) Then
                        cboAlmacenEntrada.Enabled = False
                        rgrpMedicionFisica.Enabled = False
                        If cboTipoMovimiento.SelectedIndex = 2 Then
                            ImprimirCicloResguardo(Año, Folio)
                        Else
                            ImprimirAbreCiclo(Año, Folio)
                            If (EficienciaMasico > 0) Then
                                MessageBox.Show("Folio: " + CType(FolioAnt, String) + Chr(13) + "Fecha Cierre: " + FTerminoAnt.ToShortDateString() + Chr(13) + "Hora Cierre: " + FTerminoAnt.ToShortTimeString() + Chr(13) + "Litros Vendidos: " + CType(DifTotalizador, String) + Chr(13) + "Litros Eficiencia: " + CType(EficienciaMasico, String) + Chr(13) + "Importe Eficiencia: " + CType(ImporteEficienciaMasico, String) + Chr(13) + Chr(13) + "Por favor inserte una hoja en blanco para el imprimir el aviso de pago." + Chr(13), "Eficiencia Generada", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                                ImprimirAvisoEficiencia(AñoAnt, FolioAnt)
                                'Else
                                '    MessageBox.Show("Folio: " + CType(FolioAnt, String) + Chr(13) + "Año: " + CType(AñoAnt, String) + Chr(13) + "Fecha Cierre: " + FTerminoAnt.ToShortDateString() + Chr(13) + "Hora Cierre: " + FTerminoAnt.ToShortTimeString() + Chr(13) + "Litros Vendidos: " + CType(DifTotalizador, String) + Chr(13) + "Litros Eficiencia: " + CType(EficienciaMasico, String) + Chr(13) + "Importe Eficiencia: " + CType(ImporteEficienciaMasico, String) + Chr(13), "No se genero eficiencia")
                            End If
                        End If

                      
                        LimpiaBascula()
                        btnImprimir.Enabled = Globales.GetInstance.OperacionBascula(1).Habilitada
                        mniReporteApertura.Enabled = True
                        cboTipoMovimiento.Enabled = False
                        cboContenedor.Enabled = False
                        bdtpFSalida.Enabled = False
                        tbAutotanque.Focus()

                        'TEXIS FIN DE RUTINA DE APERTURA 
                        Limpiar()
                    End If
                End If
            End If
        End If
    End Sub



    Private Sub ProcesoCierreCiclo()
        Dim ValidaCierreAutotanque As ValidaCierreAutotanque


        If ValidaCierre() Then
            If Globales.GetInstance.OperacionBascula(9).Habilitada AndAlso Val(txtPesoCierre.Text) = 0 Then
                txtPesoCierre.Text = LeeBascula.ToString
            End If
            '#20120413#HEMOPA-INICIO-FIN
            If ((Globales.GetInstance._ExisteBascula And Globales.GetInstance._PesadoAutotanqueIndividual = False) Or (Globales.GetInstance._ExisteBascula And Globales.GetInstance._PesadoAutotanqueIndividual And _PesoAutomatico)) AndAlso txtPesoCierre.Text.Trim = "" Then
                Globales.GetInstance.ErrMessage("No ha escrito el peso de llegada.")
                txtPesoCierre.Focus()
                '#20120413#HEMOPA-INICIO-FIN
            ElseIf ((Globales.GetInstance._ExisteBascula And Globales.GetInstance._PesadoAutotanqueIndividual = False) Or (Globales.GetInstance._ExisteBascula And Globales.GetInstance._PesadoAutotanqueIndividual And _PesoAutomatico)) AndAlso Val(txtPesoCierre.Text) <= 0 Then
                Globales.GetInstance.ErrMessage("La lectura de báscula es incorrecta, intente de nuevo.")
                btnPesar.Focus()
                txtPesoCierre.Focus()
            Else
                Dim Pesar As Boolean = True
                If cboTipoMovimiento.SelectedIndex = 2 AndAlso Math.Abs((Val(txtDiferenciaLitros.Text))) > Globales.GetInstance._ToleranciaTraciego Then
                    Dim FechaActual As DateTime = Globales.GetInstance.FechaActual
                    Pesar = False
                    If frmResguardoEntrada Is Nothing Then
                        frmResguardoEntrada = New Resguardo.frmResguardo()
                    End If
                    If frmResguardoEntrada.InicializaForma(Folio, CShort(Año), FechaActual, Globales.GetInstance._Usuario, Globales.GetInstance._Password, Globales.GetInstance._Corporativo, Globales.GetInstance._Sucursal) Then
                        Pesar = frmResguardoEntrada.ShowDialog = DialogResult.OK
                    End If
                End If


                If _BoletinEnLinea And _Comision Then
                    CalculaComisionOperador(Pesar)
                End If

                If Pesar Then
                    Dim PesoCierre As Decimal
                    PesoCierre = CDec(Val(txtPesoCierre.Text))
                    '#20120413#HEMOPA-INICIO-FIN

                    'Val(txtLitrosPeso.Text)- Aqui se tiene los litros de la eficiencia
                    _LitrosMasico = CInt((Val(txtDiferenciaTotalizador.Text) * (_CalibracionPorcentajeAutotanque)) + Val(txtLitrosPeso.Text))




                    If ((Globales.GetInstance._ExisteBascula And Globales.GetInstance._PesadoAutotanqueIndividual = False) Or (Globales.GetInstance._ExisteBascula And Globales.GetInstance._PesadoAutotanqueIndividual And _PesoAutomatico)) Then
                        'If MessageBox.Show("El peso de cierre es: " & PesoCierre.ToString("N2") & " Kgs. ¿Es correcto?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then

                        Dim _Confirmacion As New DialogResult()

                        If _BoletinEnLinea Then
                            ValidaCierreAutotanque = New ValidaCierreAutotanque(True, _VerificaDescarga, Globales.GetInstance._CierreSinDescargaSGC, Globales.GetInstance._MostrarLitrosDescarga, PesoCierre, _ClientesAtendidos, _LitrosTotalizadorSGC, CInt(Val(txtDiferenciaTotalizador.Text)))
                            _Confirmacion = ValidaCierreAutotanque.ShowDialog
                        Else
                            _Confirmacion = MessageBox.Show("El peso de cierre es: " & PesoCierre.ToString("N2") & " Kgs. ¿Es correcto?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2)

                        End If

                        If _Confirmacion = DialogResult.OK Or _Confirmacion = DialogResult.Yes Then


                            If CierraCiclo(PesoCierre) Then

                                'If Pesar AndAlso CierraCiclo() Then
                                rgrpMedicionFisica.Enabled = False
                                btnAnular.Enabled = False
                                If cboTipoMovimiento.SelectedIndex = 2 And Not frmResguardoEntrada Is Nothing Then
                                    'If Not frmResguardoEntrada Is Nothing Then
                                    frmResguardoEntrada.RealizarMovimientos()
                                    frmResguardoEntrada.Dispose()
                                    'End If
                                End If

                                If cboTipoMovimiento.SelectedIndex = 2 Then
                                    ImprimirCicloResguardo(Año, Folio)
                                Else
                                    ImprimirCierraCiclo(Año, Folio)
                                    If Globales.GetInstance._SGCMasicoAsignaLts Then
                                        'ActualizaSuministroSGC(CInt(Val(txtDiferenciaTotalizador.Text) * (_CalibracionPorcentajeAutotanque)), CInt(Val(txtDiferenciaTotalizador.Text) * (_CalibracionPorcentajeAutotanque)), CType((txtAutotanque.Text), Integer))
                                        ActualizaSuministroSGC(_LitrosMasico, _LitrosMasico, _LitrosComerciales, _LitrosUmbral, CType((txtAutotanque.Text), Integer))
                                    End If
                                    If _BoletinEnLinea And _Comision Then
                                        RegistraDatosComision()
                                    End If
                                End If

                               

                                LimpiaBascula()
                                tbAutotanque.DropDownArrows = True
                                mniReporteCierre.Enabled = True
                                btnImprimir.Enabled = Globales.GetInstance.OperacionBascula(1).Habilitada
                                btnSentidoMovimiento.Enabled = False
                                btnCicloEspecial.Visible = cboTipoMovimiento.SelectedIndex = 3 AndAlso Globales.GetInstance.OperacionBascula(13).Habilitada
                                tbAutotanque.Focus()

                                ' TEXIS ACABO RUTINA
                                Limpiar()

                            End If
                        End If
                    Else

                        Dim _Confirmacion As New DialogResult()

                        If _BoletinEnLinea Then
                            ValidaCierreAutotanque = New ValidaCierreAutotanque(False, _VerificaDescarga, Globales.GetInstance._CierreSinDescargaSGC, Globales.GetInstance._MostrarLitrosDescarga, PesoCierre, _ClientesAtendidos, _LitrosTotalizadorSGC, CInt(Val(txtDiferenciaTotalizador.Text)))
                            _Confirmacion = ValidaCierreAutotanque.ShowDialog
                        Else
                            _Confirmacion = DialogResult.Yes
                        End If

                        If _Confirmacion = DialogResult.OK Or _Confirmacion = DialogResult.Yes Then

                            If CierraCiclo(PesoCierre) Then
                                'If Pesar AndAlso CierraCiclo() Then
                                rgrpMedicionFisica.Enabled = False
                                btnAnular.Enabled = False
                                If cboTipoMovimiento.SelectedIndex = 2 And Not frmResguardoEntrada Is Nothing Then
                                    frmResguardoEntrada.RealizarMovimientos()
                                    frmResguardoEntrada.Dispose()
                                End If
                                If cboTipoMovimiento.SelectedIndex = 2 Then
                                    ImprimirCicloResguardo(Año, Folio)
                                Else
                                    ImprimirCierraCiclo(Año, Folio)
                                    If Globales.GetInstance._SGCMasicoAsignaLts Then
                                        'ActualizaSuministroSGC(CInt(Val(txtDiferenciaTotalizador.Text) * (_CalibracionPorcentajeAutotanque)), CInt(Val(txtDiferenciaTotalizador.Text) * (_CalibracionPorcentajeAutotanque)), CType((txtAutotanque.Text), Integer))
                                        ActualizaSuministroSGC(_LitrosMasico, _LitrosMasico, _LitrosComerciales, _LitrosUmbral, CType((txtAutotanque.Text), Integer))
                                    End If
                                    If _BoletinEnLinea And _Comision Then
                                        RegistraDatosComision()
                                    End If
                                End If

                               

                                LimpiaBascula()
                                tbAutotanque.DropDownArrows = True
                                mniReporteCierre.Enabled = True
                                btnImprimir.Enabled = Globales.GetInstance.OperacionBascula(1).Habilitada
                                btnSentidoMovimiento.Enabled = False
                                btnCicloEspecial.Visible = cboTipoMovimiento.SelectedIndex = 3 AndAlso Globales.GetInstance.OperacionBascula(13).Habilitada
                                tbAutotanque.Focus()

                                'TEXIS
                                Limpiar()

                            End If
                        End If
                    End If
                End If
            End If
        End If
    End Sub
    Private Sub ProcesoPGLleno()
        If ValidaPGLleno() Then
            If Globales.GetInstance.OperacionBascula(9).Habilitada AndAlso Val(txtPesoApertura.Text) = 0 Then
                txtPesoApertura.Text = LeeBascula.ToString
            End If
            If (Globales.GetInstance._ExisteBascula) AndAlso txtPesoApertura.Text.Trim = "" Then
                Globales.GetInstance.ErrMessage("No ha escrito el peso de salida.")
                txtPesoApertura.Focus()
            ElseIf (Globales.GetInstance._ExisteBascula) AndAlso Val(txtPesoApertura.Text) <= 0 Then
                Globales.GetInstance.ErrMessage("La lectura de báscula es incorrecta, intente de nuevo.")
                btnPesar.Focus()
                txtPesoApertura.Focus()
            Else

                Dim PesoPGApertura As Decimal
                PesoPGApertura = CDec(Val(txtPesoApertura.Text))
                If (Globales.GetInstance._ExisteBascula) Then
                    If MessageBox.Show("El peso de apertura es: " & PesoPGApertura.ToString("N2") & " Kgs. ¿Es correcto?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
                        cboContenedor.Enabled = False
                        PesaPGLLleno(PesoPGApertura)
                        tbAutotanque.Focus()
                    End If
                Else
                    cboContenedor.Enabled = False
                    PesaPGLLleno(PesoPGApertura)
                    tbAutotanque.Focus()
                End If
                'PesaPGLLleno()
                'tbAutotanque.Focus()
            End If
        End If
    End Sub
    Private Sub ProcesoPGVacio()
        Dim frmDatosAdicionalesPG As frmDatosAdicionalesPG
        If ValidaPGVacio() Then
            If Globales.GetInstance.OperacionBascula(9).Habilitada AndAlso Val(txtPesoCierre.Text) = 0 Then
                txtPesoCierre.Text = LeeBascula.ToString
            End If
            If (Globales.GetInstance._ExisteBascula) AndAlso txtPesoCierre.Text.Trim = "" Then
                Globales.GetInstance.ErrMessage("No ha escrito el peso de llegada.")
                txtPesoCierre.Focus()
            ElseIf (Globales.GetInstance._ExisteBascula) AndAlso Val(txtPesoCierre.Text) <= 0 Then
                Globales.GetInstance.ErrMessage("La lectura de báscula es incorrecta, intente de nuevo.")
                btnPesar.Focus()
                txtPesoCierre.Focus()
            Else
                Dim PesoPGCierre As Decimal
                PesoPGCierre = CDec(Val(txtPesoCierre.Text))
                If (Globales.GetInstance._ExisteBascula) Then
                    If MessageBox.Show("El peso de cierre es: " & PesoPGCierre.ToString("N2") & " Kgs. ¿Es correcto?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
                        PesaPGVacio(PesoPGCierre)
                        btnSentidoMovimiento.Enabled = False
                        frmDatosAdicionalesPG = New frmDatosAdicionalesPG(Año, Folio)
                        frmDatosAdicionalesPG.ShowDialog()
                        tbAutotanque.Focus()
                    End If
                Else
                    PesaPGVacio(PesoPGCierre)
                    btnSentidoMovimiento.Enabled = False
                    frmDatosAdicionalesPG = New frmDatosAdicionalesPG(Año, Folio)
                    frmDatosAdicionalesPG.ShowDialog()
                    tbAutotanque.Focus()
                End If
                'PesaPGVacio()
                'btnSentidoMovimiento.Enabled = False
                'frmDatosAdicionalesPG = New frmDatosAdicionalesPG(Año, Folio)
                'frmDatosAdicionalesPG.ShowDialog()
                'tbAutotanque.Focus()
            End If
        End If
    End Sub
#End Region
#Region "Operaciones de báscula"
    Private Function LeeBascula() As Integer
        If Globales.GetInstance._ExisteBascula Then
            If TConexion = 0 Then
                ValidadorCOM.ResultadoValidacion = frmLecturaCOM.ResultadoLectura
                _PesoLeido = CInt(ValidadorCOM.ValidarCadena(Empresa, CInt(Globales.GetInstance.Settings.GetSetting("BasculaCOM", "InicioLectura")),
                                                             CInt(Globales.GetInstance.Settings.GetSetting("BasculaCOM", "LongitudLectura")),
                                                             Globales.GetInstance.Settings.GetSetting("BasculaCOM", "CaracterInicio")))
            ElseIf TConexion = 1 Then

                Dim IPAddress, Puerto As String
                IPAddress = Globales.GetInstance.Settings.GetSetting("BasculaEthernet", "IP")
                Puerto = Globales.GetInstance.Settings.GetSetting("BasculaEthernet", "Puerto")

                Dim LecturaEthernet As New LeerPesoBascula.AbrirEthernet()
                LecturaEthernet.ResultadoValidacion = ""
                LecturaEthernet.AbirConexion(IPAddress, Puerto)
                LecturaEthernet.ObtenerDatos()
                LecturaEthernet.CerrarConexion()
                _PesoLeido = CInt(LecturaEthernet.ValidarCadena(Empresa, CInt(Globales.GetInstance.Settings.GetSetting("BasculaEthernet", "InicioLectura")),
                                                                CInt(Globales.GetInstance.Settings.GetSetting("BasculaEthernet", "LongitudLectura")),
                                                                Globales.GetInstance.Settings.GetSetting("BasculaEthernet", "CaracterInicio")))
            End If
        End If

        Return _PesoLeido
    End Function

    Private Sub txtPesoApertura_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPesoApertura.Enter
        '#20120413#HEMOPA-INICIO-FIN
        If ((Globales.GetInstance._ExisteBascula And chkPG.Checked) Or (Globales.GetInstance._ExisteBascula And Globales.GetInstance._PesadoAutotanqueIndividual = False) Or (Globales.GetInstance._ExisteBascula And Globales.GetInstance._PesadoAutotanqueIndividual And _PesoAutomatico)) AndAlso Not (Globales.GetInstance.OperacionBascula(9).Habilitada _
                                                AndAlso Val(txtPesoApertura.Text) > 0) Then
            txtPesoApertura.Text = LeeBascula.ToString
        End If
    End Sub
    Private Sub txtPesoCierre_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPesoCierre.Enter
        '#20120413#HEMOPA-INICIO-FIN
        If ((Globales.GetInstance._ExisteBascula And chkPG.Checked) Or (Globales.GetInstance._ExisteBascula And Globales.GetInstance._PesadoAutotanqueIndividual = False) Or (Globales.GetInstance._ExisteBascula And Globales.GetInstance._PesadoAutotanqueIndividual And _PesoAutomatico)) AndAlso Not (Globales.GetInstance.OperacionBascula(9).Habilitada _
                                                AndAlso Val(txtPesoCierre.Text) > 0) Then
            CalculaDiferencias()
            txtPesoCierre.Text = LeeBascula.ToString
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
#End Region

#Region "Rutinas de apertura y cierre de ciclos"
    Private Function AbreCiclo(ByVal PApertura As Decimal) As Boolean
        Dim cmdBascula As New SqlCommand("spBASAbreCiclo", Globales.GetInstance.cnSigamet)
        Dim rdFolio As SqlDataReader = Nothing
        Dim trBascula As SqlTransaction = Nothing

        cmdBascula.CommandType = CommandType.StoredProcedure
        cmdBascula.Parameters.Add("@Año", SqlDbType.SmallInt).Value = Año
        cmdBascula.Parameters.Add("@Folio", SqlDbType.Int).Value = Folio
        cmdBascula.Parameters.Add("@Celula", SqlDbType.TinyInt).Value = CType((Val(txtCelulaApertura.Tag)), Integer)
        cmdBascula.Parameters.Add("@Autotanque", SqlDbType.SmallInt).Value = CType((txtAutotanque.Text), Integer)
        cmdBascula.Parameters.Add("@Ruta", SqlDbType.SmallInt).Value = CInt(Val(txtRutaApertura.Tag))
        cmdBascula.Parameters.Add("@FInicioRuta", SqlDbType.DateTime).Value = Globales.GetInstance.FechaActual
        cmdBascula.Parameters.Add("@KilometrajeInicial", SqlDbType.Int).Value = CType(Valida(txtKilometrajeApertura.Text), Integer)
        cmdBascula.Parameters.Add("@TotalizadorInicial", SqlDbType.Decimal).Value = CType(Valida(txtTotalizadorApertura.Text), Decimal)
        cmdBascula.Parameters.Add("@PorcentajeGasInicial", SqlDbType.Decimal).Value = CType(Valida(txtPorcentajeApertura.Text), Decimal)
        cmdBascula.Parameters.Add("@LitrosGasInicial", SqlDbType.Decimal).Value = CType(Valida(txtLitrosApertura.Text), Decimal)
        cmdBascula.Parameters.Add("@PesoSalida", SqlDbType.Decimal).Value = PApertura
        cmdBascula.Parameters.Add("@ObservacionesInicioRuta", SqlDbType.VarChar).Value = txtObservacionesApertura.Text
        cmdBascula.Parameters.Add("@LitrosCargados", SqlDbType.Decimal).Value = CType(Valida(txtLitrosCargados.Text), Decimal)
        cmdBascula.Parameters.Add("@Contenedor", SqlDbType.Int).Value = CType(cboContenedor.SelectedValue, Integer)
        cmdBascula.Parameters.Add("@Temperatura", SqlDbType.Decimal).Value = CType(Valida(txtTemperatura.Text), Decimal)
        cmdBascula.Parameters.Add("@Presion", SqlDbType.Decimal).Value = CType(Valida(txtPresion.Text), Decimal)
        cmdBascula.Parameters.Add("@EmpleadoMedicion", SqlDbType.Int).Value = CType(Valida(txtEmpleado.Text), Integer)
        cmdBascula.Parameters.Add("@AlmacenGas", SqlDbType.Int).Value = CType(cboAlmacenEntrada.SelectedValue, Integer)
        cmdBascula.Parameters.Add("@PorcentajeFinalCicloAnterior", SqlDbType.Decimal).Value = txtPorcentajeApertura.Tag
        cmdBascula.Parameters.Add("@PesoFinalCicloAnterior", SqlDbType.Decimal).Value = txtPesoApertura.Tag


        Select Case cboTipoMovimiento.SelectedIndex
            Case 0
                cmdBascula.Parameters.Add("@TipoMovimiento", SqlDbType.Int).Value = 17
            Case 1
                cmdBascula.Parameters.Add("@TipoMovimiento", SqlDbType.Int).Value = 4
            Case 2
                cmdBascula.Parameters.Add("@TipoMovimiento", SqlDbType.Int).Value = 8
        End Select
        If Globales.GetInstance._AnticiparPesado Then
            cmdBascula.Parameters("@FInicioRuta").Value = bdtpFSalida.Value
        End If
        If Globales.GetInstance._PedirFMovimiento Then
            cmdBascula.Parameters.Add("@FMovimiento", SqlDbType.DateTime).Value = dtpFMovimiento.Value
        End If

        '20100310#CFSL - Calculo de eficiencia para formula con Masico
        'If Globales.GetInstance._FormulaEficiencia = 7 And FolioAnt > 0 And AñoAnt > 0 And DifTotalizador > 0 Then
        '201200124#CFSL - Calculo de eficiencia para formula con Masico
        If Globales.GetInstance._ExisteMasico = True And FolioAnt > 0 And AñoAnt > 0 Then
            cmdBascula.Parameters.Add("@FolioAnt", SqlDbType.Int).Value = FolioAnt
            cmdBascula.Parameters.Add("@AñoAnt", SqlDbType.Int).Value = AñoAnt
            cmdBascula.Parameters.Add("@FTerminoAnt", SqlDbType.DateTime).Value = FTerminoAnt
            cmdBascula.Parameters.Add("@DifTotalizador", SqlDbType.Decimal).Value = DifTotalizador
        End If
        '20120124#CASALA - Nuevas variables
        cmdBascula.Parameters.Add("@ExisteMasico", SqlDbType.Bit).Value = Globales.GetInstance._ExisteMasico
        cmdBascula.Parameters.Add("@FormulaEficiencia", SqlDbType.TinyInt).Value = Globales.GetInstance._FormulaEficiencia


        Me.Cursor = Cursors.WaitCursor
        Try
            Globales.GetInstance.CierraConexion()
            Globales.GetInstance.AbreConexion()
            trBascula = Globales.GetInstance.cnSigamet.BeginTransaction
            cmdBascula.Transaction = trBascula
            rdFolio = cmdBascula.ExecuteReader
            If rdFolio.Read Then
                Folio = CInt(rdFolio("Folio"))
                EficienciaMasico = CDec(rdFolio("LitrosEficiencia"))
                ImporteEficienciaMasico = CDec(rdFolio("ImporteEficiencia"))
                txtFolio.Text = Folio.ToString
            End If
            rdFolio.Close()
            CambiaApertura(False)
            btnPesar.Enabled = False
            trBascula.Commit()
            Globales.GetInstance.CierraConexion()
            Return True
        Catch ex As Exception
            If Not rdFolio Is Nothing Then
                rdFolio.Close()
            End If
            trBascula.Rollback()
            Globales.GetInstance.ExMessage(ex)
        Finally
            If Not rdFolio Is Nothing Then
                rdFolio.Close()
            End If
            Globales.GetInstance.CierraConexion()
            Me.Cursor = Cursors.Default
        End Try
    End Function


    Private Function CierraCiclo(ByVal PCierre As Decimal) As Boolean
        Dim cmdBascula As New SqlCommand("spBASCierraCiclo", Globales.GetInstance.cnSigamet)
        Dim LitrosVendidos As Decimal
        Dim trBascula As SqlTransaction = Nothing
        Select Case Globales.GetInstance._TipoCalculoAlmacen
            Case 0
                LitrosVendidos = CType(Valida(txtLitrosVendidos.Text), Decimal)
            Case 1
                LitrosVendidos = CType(Valida(txtDiferenciaTotalizador.Text), Decimal)
            Case 2
                LitrosVendidos = CType(Valida(txtDiferenciaLitros.Text), Decimal)
        End Select
        cmdBascula.CommandType = CommandType.StoredProcedure
        cmdBascula.Parameters.Add("@Año", SqlDbType.SmallInt).Value = Año
        cmdBascula.Parameters.Add("@Folio", SqlDbType.Int).Value = Folio
        cmdBascula.Parameters.Add("@LitrosVendidos", SqlDbType.Decimal).Value = LitrosVendidos
        cmdBascula.Parameters.Add("@LitrosVendidosPorcentaje", SqlDbType.Decimal).Value = CType(Valida(txtDiferenciaLitros.Text), Decimal)
        cmdBascula.Parameters.Add("@LitroGasNoVendido", SqlDbType.Decimal).Value = CType(Valida(txtLitrosCierre.Text), Decimal)
        cmdBascula.Parameters.Add("@FTerminoRuta", SqlDbType.DateTime).Value = Globales.GetInstance.FechaActual
        cmdBascula.Parameters.Add("@TotalizadorFinal", SqlDbType.Decimal).Value = CType(Valida(txtTotalizadorCierre.Text), Decimal)
        cmdBascula.Parameters.Add("@PesoLlegada", SqlDbType.Decimal).Value = CType(PCierre, Decimal)
        cmdBascula.Parameters.Add("@KilometrajeFinal", SqlDbType.Int).Value = CType(Valida(txtKilometrajeCierre.Text), Integer)
        cmdBascula.Parameters.Add("@PorcentajeGasNoVendido", SqlDbType.Money).Value = CType(Valida(txtPorcentajeCierre.Text), Decimal)
        cmdBascula.Parameters.Add("@ObservacionesCierreRuta", SqlDbType.VarChar).Value = txtObservacionesCierre.Text.Trim

        cmdBascula.Parameters.Add("@PesoEficiencia", SqlDbType.Decimal).Value = CType(Valida(txtLitrosPeso.Text), Decimal)
        cmdBascula.Parameters.Add("@PesoImporteEficiencia", SqlDbType.Money).Value = CType(Valida(txtImportePeso.Text), Decimal)
        cmdBascula.Parameters.Add("@PorcentajeEficiencia", SqlDbType.Decimal).Value = CType(Valida(txtLitrosPorcentaje.Text), Decimal)
        cmdBascula.Parameters.Add("@PorcentajeImporteEficiencia", SqlDbType.Money).Value = CType(Valida(txtImportePorcentaje.Text), Decimal)

        cmdBascula.Parameters.Add("@Contenedor", SqlDbType.Int).Value = CType(cboContenedor.SelectedValue, Integer)
        cmdBascula.Parameters.Add("@Temperatura", SqlDbType.Decimal).Value = CType(Valida(txtTemperatura.Text), Decimal)
        cmdBascula.Parameters.Add("@Presion", SqlDbType.Decimal).Value = CType(Valida(txtPresion.Text), Decimal)
        cmdBascula.Parameters.Add("@EmpleadoMedicion", SqlDbType.Int).Value = CType(Valida(txtEmpleado.Text), Integer)
        cmdBascula.Parameters.Add("@AlmacenGas", SqlDbType.Int).Value = CType(Val(cboAlmacenEntrada.SelectedValue), Integer)
        cmdBascula.Parameters.Add("@LitrosTotalizador", SqlDbType.Decimal).Value = CType(Valida(txtDiferenciaTotalizador.Text), Decimal)

        cmdBascula.Parameters.Add("@RellenoLitrosComerciales", SqlDbType.Decimal).Value = CType(_LitrosComerciales, Decimal)
        cmdBascula.Parameters.Add("@RellenoLitrosMasico", SqlDbType.Decimal).Value = CType(_LitrosMasico, Decimal)
        cmdBascula.Parameters.Add("@RellenoLitrosUmbral", SqlDbType.Decimal).Value = CType(_LitrosUmbral, Decimal)


        If Globales.GetInstance._PedirFMovimiento Then
            cmdBascula.Parameters.Add("@FMovimiento", SqlDbType.DateTime).Value = dtpFMovimiento.Value
        End If
        Me.Cursor = Cursors.WaitCursor
        Try
            Globales.GetInstance.AbreConexion()
            trBascula = Globales.GetInstance.cnSigamet.BeginTransaction
            cmdBascula.Transaction = trBascula
            cmdBascula.ExecuteNonQuery()
            CambiaCierre(False)
            btnPesar.Enabled = False
            trBascula.Commit()
            Return True
        Catch ex As Exception
            trBascula.Rollback()
            Globales.GetInstance.ExMessage(ex)
        Finally
            Globales.GetInstance.CierraConexion()
            Me.Cursor = Cursors.Default
        End Try
    End Function
    Private Sub PesaPGLLleno(ByVal PPGApertura As Decimal)
        Dim cmdBascula As New SqlCommand("spBASPesaPGLleno", Globales.GetInstance.cnSigamet)
        Dim rdFolio As SqlDataReader
        cmdBascula.CommandType = CommandType.StoredProcedure
        cmdBascula.Parameters.Add("@Año", SqlDbType.SmallInt).Value = Año
        cmdBascula.Parameters.Add("@Folio", SqlDbType.Int).Value = Folio
        cmdBascula.Parameters.Add("@Autotanque", SqlDbType.VarChar).Value = ccboPG.Text.Trim
        cmdBascula.Parameters.Add("@FInicioRuta", SqlDbType.DateTime).Value = Globales.GetInstance.FechaActual
        cmdBascula.Parameters.Add("@KilometrajeInicial", SqlDbType.Int).Value = CType(Valida(txtKilometrajeApertura.Text), Integer)
        cmdBascula.Parameters.Add("@TotalizadorInicial", SqlDbType.Decimal).Value = CType(Valida(txtTotalizadorApertura.Text), Decimal)
        cmdBascula.Parameters.Add("@PorcentajeGasInicial", SqlDbType.Decimal).Value = CType(Valida(txtPorcentajeApertura.Text), Decimal)
        cmdBascula.Parameters.Add("@LitrosGasInicial", SqlDbType.Decimal).Value = CType(Valida(txtLitrosApertura.Text), Decimal)
        cmdBascula.Parameters.Add("@PesoSalida", SqlDbType.Decimal).Value = PPGApertura
        cmdBascula.Parameters.Add("@NumeroEmbarque", SqlDbType.VarChar).Value = txtEmbarque.Text
        cmdBascula.Parameters.Add("@ObservacionesInicioRuta", SqlDbType.VarChar).Value = txtObservacionesApertura.Text
        cmdBascula.Parameters.Add("@Externo", SqlDbType.Bit).Value = ccboPG.SelectedValue Is Nothing
        cmdBascula.Parameters.Add("@Capacidad", SqlDbType.Decimal).Value = CType(Valida(txtCapacidad.Text), Decimal)
        cmdBascula.Parameters.Add("@PG", SqlDbType.Char).Value = ccboPG.Text.Trim
        cmdBascula.Parameters.Add("@AlmacenGas", SqlDbType.SmallInt).Value = cboContenedor.SelectedValue
        Me.Cursor = Cursors.WaitCursor
        Try
            Globales.GetInstance.AbreConexion()
            rdFolio = cmdBascula.ExecuteReader
            If rdFolio.Read Then
                Folio = CInt(rdFolio("Folio"))
                txtFolio.Text = Folio.ToString
            End If
            rdFolio.Close()
            rgrpMedicionFisica.Enabled = False
            CambiaApertura(False)
            btnPesar.Enabled = False
        Catch ex As Exception
            Globales.GetInstance.ExMessage(ex)
        Finally
            Globales.GetInstance.CierraConexion()
            Me.Cursor = Cursors.Default
        End Try
    End Sub
    Private Sub PesaPGVacio(ByVal PPGCierre As Decimal)
        Dim cmdBascula As New SqlCommand("spBASPesaPGVacio", Globales.GetInstance.cnSigamet)
        cmdBascula.CommandType = CommandType.StoredProcedure
        cmdBascula.Parameters.Add("@Embarque", SqlDbType.Int).Value = Embarque
        cmdBascula.Parameters.Add("@Año", SqlDbType.SmallInt).Value = Año
        cmdBascula.Parameters.Add("@Folio", SqlDbType.Int).Value = Folio
        cmdBascula.Parameters.Add("@LitroGasNoVendido", SqlDbType.Decimal).Value = CType(Valida(txtLitrosCierre.Text), Decimal)
        cmdBascula.Parameters.Add("@FTerminoRuta", SqlDbType.DateTime).Value = Globales.GetInstance.FechaActual
        cmdBascula.Parameters.Add("@PesoLlegada", SqlDbType.Decimal).Value = PPGCierre
        cmdBascula.Parameters.Add("@KilometrajeFinal", SqlDbType.Int).Value = CType(Valida(txtKilometrajeCierre.Text), Integer)
        cmdBascula.Parameters.Add("@PorcentajeGasNoVendido", SqlDbType.Money).Value = CType(Valida(txtPorcentajeCierre.Text), Decimal)
        cmdBascula.Parameters.Add("@ObservacionesCierreRuta", SqlDbType.VarChar).Value = txtObservacionesCierre.Text.Trim
        cmdBascula.Parameters.Add("@SentidoMovimiento", SqlDbType.Bit).Value = _SentidoMovimiento = 1
        Me.Cursor = Cursors.WaitCursor
        Try
            Globales.GetInstance.AbreConexion()
            cmdBascula.ExecuteNonQuery()
            rgrpMedicionFisica.Enabled = False
            CambiaCierre(False)
            btnPesar.Enabled = False
        Catch ex As Exception
            Globales.GetInstance.ExMessage(ex)
        Finally
            Globales.GetInstance.CierraConexion()
            Me.Cursor = Cursors.Default
        End Try
    End Sub
#End Region

#Region "Rutinas de actualización"
    Private Sub tmrHora_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrHora.Tick
        If EstadoActual = Estado.AperturaCiclo Then
            txtHoraApertura.Text = CDate(Now.ToShortDateString & " " & txtHoraApertura.Text).AddMinutes(1).ToShortTimeString
        ElseIf EstadoActual = Estado.CierreCiclo Then
            txtHoraCierre.Text = CDate(Now.ToShortDateString & " " & txtHoraCierre.Text).AddMinutes(1).ToShortTimeString
        End If
    End Sub
#End Region

#Region "Rutinas de manejo del cmbo de pg's"
    Private Sub chkPG_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkPG.CheckedChanged
        txtAutotanque.Visible = Not chkPG.Checked
        ccboPG.Visible = chkPG.Checked
        lblEmbarque.Visible = chkPG.Checked
        txtEmbarque.Visible = chkPG.Checked

        lblTipoMovimiento.Visible = Not chkPG.Checked
        cboTipoMovimiento.Visible = Not chkPG.Checked

        rgrpMedicionFisica.Enabled = Not chkPG.Checked
        If chkPG.Checked Then
            ccboPG.Text = txtAutotanque.Text
            ccboPG.Focus()
            If ccboPG.Text.Trim <> "" Then
                btnBuscar.Enabled = True
            End If
        Else
            txtAutotanque.Text = CInt(Val(ccboPG.Text)).ToString
            txtAutotanque.Focus()
        End If
    End Sub
    Private Sub ccboPG_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ccboPG.TextChanged
        btnBuscarAtt.Enabled = ccboPG.Text.Trim <> "" AndAlso ccboPG.Visible
    End Sub
    Private Sub ccboPG_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles ccboPG.KeyPress
        If Asc(e.KeyChar) = 13 AndAlso ccboPG.Text.Trim <> "" Then
            BuscaPG()
        End If
    End Sub
#End Region

#Region "Rutinas de impresión de reportes"
    Private Sub ImprimirAbreCiclo(ByVal Año As Integer, ByVal Folio As Integer)
        Dim crParameterFieldDefinitions As ParameterFieldDefinitions
        Dim crParameterFieldDefinition As ParameterFieldDefinition
        Dim crParametervalues As CrystalDecisions.Shared.ParameterValues
        Dim crParameterDiscretValue As CrystalDecisions.Shared.ParameterDiscreteValue
        Cursor = Cursors.WaitCursor
        crvReporte.ReportSource = Nothing
        Try
            rptReporte.Load(Globales.GetInstance._RutaReportes & "\rptAbreCiclo.rpt")
            'rptReporte.Load(Application.StartupPath & "\rptAbreCiclo.rpt")
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


            'Cursor = Cursors.WaitCursor
            'Dim NuevoReporte As New ReporteDinamico.frmReporte(Globales.GetInstance._RutaReportes, "rptAbreCiclo.rpt", Globales.GetInstance._Servidor, Globales.GetInstance._Database, Globales.GetInstance._Usuario, Globales.GetInstance._Password, Globales.GetInstance.cnSigamet)
            'NuevoReporte.WindowState = FormWindowState.Maximized
            'NuevoReporte.ShowDialog()
            'Cursor = Cursors.Default
        Catch ex As LoadSaveReportException
            Globales.GetInstance.ExMessage(ex)
        Catch ex As Exception
            Globales.GetInstance.ExMessage(ex)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub


    Private Sub ImprimirAvisoEficiencia(ByVal Año As Integer, ByVal Folio As Integer)
        Dim crParameterFieldDefinitions As ParameterFieldDefinitions
        Dim crParameterFieldDefinition As ParameterFieldDefinition
        Dim crParametervalues As CrystalDecisions.Shared.ParameterValues
        Dim crParameterDiscretValue As CrystalDecisions.Shared.ParameterDiscreteValue
        Cursor = Cursors.WaitCursor
        crvReporte.ReportSource = Nothing
        Try
            rptReporte.Load(Globales.GetInstance._RutaReportes & "\rptAviosoEfieciencia.rpt")
            'rptReporte.Load(Application.StartupPath & "\rptAbreCiclo.rpt")
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

    Private Sub ImprimirCierraCiclo(ByVal Año As Integer, ByVal Folio As Integer)
        Dim crParameterFieldDefinitions As ParameterFieldDefinitions
        Dim crParameterFieldDefinition As ParameterFieldDefinition
        Dim crParametervalues As CrystalDecisions.Shared.ParameterValues
        Dim crParameterDiscretValue As CrystalDecisions.Shared.ParameterDiscreteValue
        Cursor = Cursors.WaitCursor
        crvReporte.ReportSource = Nothing
        Try
            rptReporte.Load(Globales.GetInstance._RutaReportes & "\rptCierraCiclo.rpt")
            'rptReporte.Load(Application.StartupPath & "\rptCierraCiclo.rpt")
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
    Private Sub ImprimirCicloCompleto(ByVal Año As Integer, ByVal Folio As Integer)
        Dim crParameterFieldDefinitions As ParameterFieldDefinitions
        Dim crParameterFieldDefinition As ParameterFieldDefinition
        Dim crParametervalues As CrystalDecisions.Shared.ParameterValues
        Dim crParameterDiscretValue As CrystalDecisions.Shared.ParameterDiscreteValue
        Cursor = Cursors.WaitCursor
        crvReporte.ReportSource = Nothing
        Try
            rptReporte.Load(Globales.GetInstance._RutaReportes & "\rptCiclo.rpt")
            'rptReporte.Load(Application.StartupPath & "\rptCierraCiclo.rpt")
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
    Private Sub ImprimirCicloResguardo(ByVal Año As Integer, ByVal Folio As Integer)
        Dim crParameterFieldDefinitions As ParameterFieldDefinitions
        Dim crParameterFieldDefinition As ParameterFieldDefinition
        Dim crParametervalues As CrystalDecisions.Shared.ParameterValues
        Dim crParameterDiscretValue As CrystalDecisions.Shared.ParameterDiscreteValue
        Cursor = Cursors.WaitCursor
        crvReporte.ReportSource = Nothing
        Try
            rptReporte.Load(Globales.GetInstance._RutaReportes & "\Resguardo Bascula.rpt")
            ConexionReporte()
            crParameterFieldDefinitions = rptReporte.DataDefinition.ParameterFields

            crParameterFieldDefinition = crParameterFieldDefinitions.Item("@AnoAtt")
            crParametervalues = crParameterFieldDefinition.CurrentValues
            crParameterDiscretValue = New ParameterDiscreteValue()
            crParameterDiscretValue.Value = Año
            crParametervalues.Add(crParameterDiscretValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParametervalues)

            crParameterFieldDefinition = crParameterFieldDefinitions.Item("@FolioAtt")
            crParametervalues = crParameterFieldDefinition.CurrentValues
            crParameterDiscretValue = New ParameterDiscreteValue()
            crParameterDiscretValue.Value = Folio
            crParametervalues.Add(crParameterDiscretValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParametervalues)

            crParameterFieldDefinition = crParameterFieldDefinitions.Item("@Reimpresion")
            crParametervalues = crParameterFieldDefinition.CurrentValues
            crParameterDiscretValue = New ParameterDiscreteValue()
            crParameterDiscretValue.Value = 0
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
        Dim _Usuario As String
        Dim _Password As String
        Dim oConfig As SigaMetClasses.cConfig = New SigaMetClasses.cConfig(9, Globales.GetInstance._Corporativo, Globales.GetInstance._Sucursal)
        _Usuario = CStr(oConfig.Parametros("UsuarioReportes")).Trim

        Dim oUsuarioReportes As New SigaMetClasses.cUserInfo()
        oUsuarioReportes.ConsultaDatosUsuarioReportes(_Usuario)
        _Password = oUsuarioReportes.Password

        For Each _TablaReporte In rptReporte.Database.Tables
            _LogonInfo = _TablaReporte.LogOnInfo
            With _LogonInfo.ConnectionInfo
                .ServerName = Globales.GetInstance._Servidor
                .DatabaseName = Globales.GetInstance._Database
                '.UserID = Globales.GetInstance._Usuario
                '.Password = Globales.GetInstance._Password
                .UserID = _Usuario
                .Password = _Password
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

#Region "Rutinas de manejo de datos"
    Private Sub Anular()
        Dim frmAnularOperacion As New frmAnularOperacion(Año, Folio)
        If frmAnularOperacion.ShowDialog() = DialogResult.OK Then
            Limpiar()
        End If
    End Sub
    Private Sub Modificar()
        Dim daBascula As New SqlDataAdapter("Select * from vwBASInformacionFolios where AñoAtt = @Año and Folio = @Folio", Globales.GetInstance.cnSigamet)
        Dim frmCapturaCiclo As frmCapturaCiclo
        Dim dtDatos As New DataTable()
        daBascula.SelectCommand.Parameters.Add("@Año", SqlDbType.SmallInt).Value = Año
        daBascula.SelectCommand.Parameters.Add("@Folio", SqlDbType.Int).Value = Folio
        Try
            daBascula.Fill(dtDatos)
            frmCapturaCiclo = New frmCapturaCiclo(dtDatos.Rows(0))
            If frmCapturaCiclo.ShowDialog = DialogResult.OK Then
                BuscaAutotanque()
            End If
        Catch ex As Exception
            Globales.GetInstance.ExMessage(ex)
        End Try
    End Sub
#End Region

#Region "Rutinas de comunicación báscula"
    Private Sub InicializaBascula()
        'Try
        ''CambiosBascula
        'comLectorBascula.InBufferCount = 0
        'comLectorBascula.OutBufferCount = 0
        'comLectorBascula.CommPort = CShort(Globales.GetInstance.Settings.GetSetting("Bascula", "Puerto"))
        'comLectorBascula.Settings = Globales.GetInstance.Settings.GetSetting("Bascula", "Settings")
        'comLectorBascula.Handshaking = CType(CInt(Globales.GetInstance.Settings.GetSetting("Bascula", "Handshaking")), MSCommLib.HandshakeConstants)
        'comLectorBascula.EOFEnable = CBool(Globales.GetInstance.Settings.GetSetting("Bascula", "EOFEnable"))
        'comLectorBascula.InputMode = MSCommLib.InputModeConstants.comInputModeText
        'If comLectorBascula.PortOpen = True Then
        '    comLectorBascula.PortOpen = False
        'Else
        '    comLectorBascula.PortOpen = True
        'End If

        'Catch ex As Exception
        '    Globales.GetInstance.ErrMessage("Error en la incialización del puerto para la lectura de báscula:" & Chr(13) & ex.Message)
        'End Try

        TConexion = CInt(Globales.GetInstance.Settings.GetSetting("frmPrincipal", "TConexion")) ''CambiosBascula
        Empresa = Globales.GetInstance._TipoLecturaCadenaPeso   ''CambiosBascula

        If TConexion = 0 Then
            frmLecturaCOM.Puerto = Globales.GetInstance.Settings.GetSetting("BasculaCOM", "Puerto")
            frmLecturaCOM.Bits = Globales.GetInstance.Settings.GetSetting("BasculaCOM", "Bits")
            frmLecturaCOM.Bauts = Globales.GetInstance.Settings.GetSetting("BasculaCOM", "Baut")
            frmLecturaCOM.Paridad = CInt(Globales.GetInstance.Settings.GetSetting("BasculaCOM", "Paridad"))
            frmLecturaCOM.ControlParada = CInt(Globales.GetInstance.Settings.GetSetting("BasculaCOM", "ControlParada"))
            frmLecturaCOM.ControlFlujo = CInt(Globales.GetInstance.Settings.GetSetting("BasculaCOM", "Flujo"))

            frmLecturaCOM.Show()
            frmLecturaCOM.Visible = False
        End If
    End Sub

    'Funcion para Validar la lectura de la bascula
    Private Function ValidarCadena(ByVal Cadena As String) As String
        Dim Lectura As String = ""

        Select Case Globales.GetInstance._TipoLecturaCadenaPeso
            Case Is = 0
                ''Dim Lectura As String
                Dim Inicio, Longitud As Integer
                Dim charInicio As String
                Inicio = CInt(Globales.GetInstance.Settings.GetSetting("Bascula", "InicioLectura"))
                Longitud = CInt(Globales.GetInstance.Settings.GetSetting("Bascula", "LongitudLectura"))
                charInicio = CStr(Globales.GetInstance.Settings.GetSetting("Bascula", "CaracterInicio"))
                Lectura = Cadena
                If charInicio <> String.Empty Then
                    Lectura = Lectura.Substring(Lectura.IndexOf(charInicio))
                End If
                Lectura = Mid(Lectura, Inicio, Longitud)
                ''Return Lectura
            Case Is = 1
                ''Dim Lectura As String = ""
                Dim i As Integer = 0
                While Cadena.Chars(i) <> "i"
                    i = i + 1
                End While
                Dim ii As Integer = 0
                If i >= 13 Then
                    ii = i - 13
                    While Lectura.Length < 5
                        Lectura = Lectura & Cadena.Chars(ii)
                        ii = ii + 1
                    End While
                End If
                While ii < 5 And i < 13
                    Lectura = Lectura & Cadena.Chars(i + 4)
                    i = i + 1
                    ii = ii + 1
                End While
                Dim c As Integer = 4 - Lectura.Length
                If Lectura.Length < 5 Then
                    For i = 0 To c
                        Lectura = Lectura + Cadena.Chars(i)
                    Next
                End If
                ''Return Lectura
        End Select
        Return Lectura
    End Function
    'Fin de función

    Private Sub comLectorBascula_OnComm(ByVal sender As Object, ByVal e As System.EventArgs)
        ''CambiosBascula
        'Try
        '    Dim Lectura As String
        '    Select Case comLectorBascula.CommEvent
        '        Case Is = CType(MSCommLib.OnCommConstants.comEvReceive, Short)
        '            _PesoLeido = 0
        '            Lectura = ValidarCadena(CStr(comLectorBascula.Input))
        '            If (IsNumeric(Lectura)) AndAlso Val(Trim(Lectura)) <> 0 Then
        '                _PesoLeido = CInt(Val(Lectura))
        '            Else
        '                comLectorBascula.InBufferCount = 0
        '                comLectorBascula.OutBufferCount = 0
        '                _PesoLeido = 0
        '            End If
        '    End Select
        'Catch
        '    Globales.GetInstance.ErrMessage("Error en la comunicación con la báscula")
        'End Try
    End Sub

    'Private Sub comLectorBascula_OnComm(ByVal sender As Object, ByVal e As System.EventArgs) Handles comLectorBascula.OnComm
    '    Try
    '        Dim Lectura As String
    '        Dim Inicio, Longitud As Integer
    '        Dim charInicio As String
    '        Inicio = CInt(Globales.GetInstance.Settings.GetSetting("Bascula", "InicioLectura"))
    '        Longitud = CInt(Globales.GetInstance.Settings.GetSetting("Bascula", "LongitudLectura"))
    '        charInicio = CStr(Globales.GetInstance.Settings.GetSetting("Bascula", "CaracterInicio"))
    '        Select Case comLectorBascula.CommEvent
    '            Case Is = CType(MSCommLib.OnCommConstants.comEvReceive, Short)
    '                _PesoLeido = 0
    '                Lectura = CStr(comLectorBascula.Input)
    '                If charInicio <> String.Empty Then
    '                    Lectura = Lectura.Substring(Lectura.IndexOf(charInicio))
    '                End If
    '                Lectura = Mid(Lectura, Inicio, Longitud)
    '                If (IsNumeric(Lectura)) AndAlso Val(Trim(Lectura)) <> 0 Then
    '                    _PesoLeido = CInt(Val(Lectura))
    '                Else
    '                    comLectorBascula.InBufferCount = 0
    '                    comLectorBascula.OutBufferCount = 0
    '                    _PesoLeido = 0
    '                End If
    '        End Select
    '    Catch
    '        Globales.GetInstance.ErrMessage("Error en la comunicación con la báscula")
    '    End Try
    'End Sub

    Private Sub LimpiaBascula()
        If Not comLectorBascula Is Nothing Then
            'comLectorBascula.InBufferCount = 0
            'comLectorBascula.OutBufferCount = 0
        End If
        _PesoLeido = 0
    End Sub
#End Region

#Region "Rutinas de comunicación transponder"
    Private Sub InicializaTransponder()
        Try
            comLectorTransponder.InBufferCount = 0
            comLectorTransponder.OutBufferCount = 0
            comLectorTransponder.CommPort = CShort(Globales.GetInstance.Settings.GetSetting("Transponder", "Puerto"))
            comLectorTransponder.Settings = Globales.GetInstance.Settings.GetSetting("Transponder", "Settings")
            comLectorTransponder.Handshaking = CType(CInt(Globales.GetInstance.Settings.GetSetting("Transponder", "Handshaking")), MSCommLib.HandshakeConstants)
            comLectorTransponder.EOFEnable = CBool(Globales.GetInstance.Settings.GetSetting("Transponder", "EOFEnable"))
            comLectorTransponder.InputMode = MSCommLib.InputModeConstants.comInputModeText
            If comLectorTransponder.PortOpen = True Then
                comLectorTransponder.PortOpen = False
            Else
                comLectorTransponder.PortOpen = True
            End If
            tmrTransponder.Enabled = True
        Catch
            'Globales.GetInstance.ErrMessage("Error en la inicialización del puerto para la lectura de transponders." & Chr(13) & _
            '                    "Se deshabilitará esta función.")
            'tmrTransponder.Enabled = False
        End Try
    End Sub
    Private Sub tmrTransponder_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles tmrTransponder.Tick
        Try
            LeeTransponder()
            If comLectorTransponder.PortOpen = True Then
                comLectorTransponder.PortOpen = False
            End If
            comLectorTransponder.InBufferCount = 0
            comLectorTransponder.OutBufferCount = 0
        Catch
        Finally
            InicializaTransponder()
        End Try
    End Sub
    Private Sub LeeTransponder()
        Dim cmdBIN, Lectura As String
        Dim cmd As String = "01010020003F8804"
        Try
            cmdBIN = CStr(DecToBin(cmd))
            comLectorTransponder.Output = cmdBIN
        Catch
        End Try
        'System.Threading.Thread.Sleep(1000)
        If comLectorTransponder.InBufferCount <> 3 Then
            Lectura = CStr(comLectorTransponder.Input)
            Lectura = Lectura.Substring(10, 16)
            Lectura = CStr(Convert.ToInt64(Lectura))
            If Lectura > "0" Then
                ValidaLeido(Lectura)
            End If
        End If
    End Sub

    Private Sub LimpiaTransponder()
        'comLectorTransponder.InBufferCount = 0
        'comLectorTransponder.OutBufferCount = 0
        'If comLectorTransponder.PortOpen = True Then
        '    comLectorTransponder.PortOpen = False
        'Else
        '    comLectorTransponder.PortOpen = True
        'End If
        'tmrTransponder.Enabled = False
        'tmrTransponder.Enabled = True
        'tmrTransponder.Start()

    End Sub

    Private Sub ValidaLeido(ByVal ID As String)
        Dim Autotanque As String = AutoTanqueTransponder(ID)
        If Autotanque <> "" AndAlso Not _TranspondersLeidos.Contains(Autotanque) Then
            InsertaTransponder(Autotanque)
        End If
    End Sub
    Private Function AutoTanqueTransponder(ByVal Transponder As String) As String
        Dim cmdBascula As New SqlCommand("Select Autotanque from Autotanque where Transponder = @Transponder and TipoVehiculo = 1 and TipoProducto = 1 and Status = 'ACTIVO'", Globales.GetInstance.cnSigamet)
        cmdBascula.Parameters.Add("@Transponder", SqlDbType.Char).Value = Transponder

        Try
            Globales.GetInstance.AbreConexion()
            If Not Microsoft.VisualBasic.IsDBNull(cmdBascula.ExecuteScalar) Then
                Return CStr(cmdBascula.ExecuteScalar)
            Else
                Return Nothing
            End If
        Catch
            ''Finally
            Globales.GetInstance.CierraConexion()
            Return Nothing
        End Try
    End Function
    Private Function DecToBin(ByRef sTemp As String) As Object
        Dim sCmdString As String = ""
        Dim i As Integer
        Dim HNibble As Integer
        Dim LNibble As Integer
        Try
            For i = 1 To Len(sTemp) Step 2
                If Mid(sTemp, i, 1) >= "A" And Mid(sTemp, i, 1) <= "F" Then
                    HNibble = (Asc(Mid(sTemp, i, 1)) - 55) * 16
                Else
                    HNibble = (Asc(Mid(sTemp, i, 1)) - 48) * 16
                End If
                If Mid(sTemp, i + 1, 1) >= "A" And Mid(sTemp, i + 1, 1) <= "F" Then
                    LNibble = Asc(Mid(sTemp, i + 1, 1)) - 55
                Else
                    LNibble = Asc(Mid(sTemp, i + 1, 1)) - 48
                End If
                sCmdString = sCmdString & Chr(HNibble + LNibble)
            Next i
        Catch
        End Try
        Return sCmdString
    End Function
#End Region

#Region "Rutinas de la cola de autotanques"
    Private Sub InsertaTransponder(ByVal Autotanque As String)
        If _TranspondersLeidos.Count = 0 AndAlso (txtAutotanque.Text.Trim <> "" OrElse chkPG.Checked) Then
            _TranspondersLeidos.Add(Nothing)
            _TranspondersLeidos.Insert(1, Autotanque)
        Else
            _TranspondersLeidos.Add(Autotanque)
        End If
        MovimientoTransponder()
    End Sub
    Public Sub RecorreFila()
        Try
            _TranspondersLeidos.RemoveAt(0)
            MovimientoTransponder()
            btnDescartarLectura.Enabled = True
            btnRegresarFila.Enabled = True
            BuscaAutotanque()
        Catch
        End Try
    End Sub
    Public Sub RegresaFila()
        Try
            _TranspondersLeidos.Insert(0, Nothing)
            _TranspondersLeidos.Insert(0, Nothing)
            Limpiar()
            MovimientoTransponder()
            txtAutotanque.Enabled = True
        Catch
        End Try
    End Sub
    Private Sub MovimientoTransponder()
        If _TranspondersLeidos.Count > 0 AndAlso Not _TranspondersLeidos(0) Is Nothing Then
            txtAutotanque.Text = CStr(_TranspondersLeidos(0))
            If _TranspondersLeidos.Count = 1 AndAlso Not chkPG.Checked Then
                btnDescartarLectura.Enabled = True
                btnRegresarFila.Enabled = True
                BuscaAutotanque()
            Else
                btnDescartarLectura.Enabled = False
                btnRegresarFila.Enabled = False
            End If
        End If
        If _TranspondersLeidos.Count > 1 AndAlso Not _TranspondersLeidos(1) Is Nothing Then
            txtAutotanqueF1.Text = CStr(_TranspondersLeidos(1))
        Else
            txtAutotanqueF1.Clear()
        End If
        If _TranspondersLeidos.Count > 2 AndAlso Not _TranspondersLeidos(2) Is Nothing Then
            txtAutotanqueF2.Text = CStr(_TranspondersLeidos(2))
        Else
            txtAutotanqueF2.Clear()
        End If
    End Sub
    Private Sub btnDescartarLectura_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDescartarLectura.Click
        btnDescartarLectura.Enabled = False
        btnRegresarFila.Enabled = False
        Limpiar()
    End Sub
    Private Sub btnRegresarFila_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRegresarFila.Click
        RegresaFila()
    End Sub
    Private Sub frmAutotanques_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        If Globales.GetInstance._LeeTransponder Then
            InicializaTransponder()
            LlamarBascula = New ServicioBasculita.LeerEthernetClient()
            DatosEntrada = New ServicioBasculita.Conexion()
            lstTransponders = New List(Of TransponderLeido)
            tmrLectura.Interval = 1000
            tmrLectura.Start()
        End If

        txtAutotanque.Focus()
    End Sub
#End Region

    Private Sub bdtpFSalida_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bdtpFSalida.ValueChanged
        If Globales.GetInstance._AnticiparPesado Then
            bdtpFSalida.Blink()
        End If
    End Sub
    Private Sub mniReporteApertura_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mniReporteApertura.Click
        ImprimirAbreCiclo(Año, Folio)
    End Sub
    Private Sub mniReporteCierre_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mniReporteCierre.Click
        ImprimirCierraCiclo(Me.Año, Me.Folio)
    End Sub
    Private Sub btnSentidoMovimiento_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSentidoMovimiento.Click
        btnSentidoMovimiento.ImageIndex += _SentidoMovimiento
        _SentidoMovimiento *= -1
        lblSentidoMovimiento.Text = IIf(_SentidoMovimiento = 1, "Mayor peso inicial", "Mayor peso final").ToString()
        CalculaDiferencias()
    End Sub
    'Para pruebas
    Private Sub Inserta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Inserta.Click
        InsertaTransponder(nupdAtt.Value.ToString)
    End Sub
    Private Sub frmAutotanques_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.F5 Then
            btnPesar_Click(btnPesar, New System.EventArgs())
        End If
    End Sub
    'Para pruebas
    Private Sub RTextBoxDecimal_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If Not (Char.IsDigit(e.KeyChar) OrElse Char.IsControl(e.KeyChar) OrElse Asc(e.KeyChar) = 8 OrElse _
                    (e.KeyChar = CChar(".") AndAlso CType(sender, TextBox).Text.IndexOf(".") < 0) OrElse _
                     (e.KeyChar = CChar("-") AndAlso CType(sender, TextBox).Text.IndexOf("-") < 0 AndAlso CType(sender, TextBox).SelectionStart = 0)) Then
            e.Handled = True
        Else
            e.Handled = False
        End If
    End Sub

    Private Sub GeneraCicloEspecial()
        Dim cmdBascula As New SqlCommand("spBASGeneraCicloEspecial", Globales.GetInstance.cnSigamet)
        Dim rdFolio As SqlDataReader
        cmdBascula.CommandType = CommandType.StoredProcedure
        cmdBascula.Parameters.Add("@Año", SqlDbType.SmallInt).Value = Año
        cmdBascula.Parameters.Add("@Folio", SqlDbType.Int).Value = Folio
        Me.Cursor = Cursors.WaitCursor
        Try
            Globales.GetInstance.AbreConexion()
            rdFolio = cmdBascula.ExecuteReader
            If rdFolio.Read Then
                Folio = CInt(rdFolio("Folio"))
                txtFolio.Text = Folio.ToString
            End If
            rdFolio.Close()
            btnCicloEspecial.Visible = False
            ImprimirCicloCompleto(Año, Folio)
        Catch ex As Exception
            Globales.GetInstance.ExMessage(ex)
        Finally
            Globales.GetInstance.CierraConexion()
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub cboAlmacenEntrada_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cboAlmacenEntrada.KeyDown
        If (e.KeyData = Keys.Enter) Then
            Me.SelectNextControl(CType(sender, Control), True, True, True, True)
        End If
    End Sub

    Private Sub cboAlmacenEntrada_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboAlmacenEntrada.SelectedIndexChanged
        If Globales.GetInstance._DatosCelulaRuta Then
            If CType(cboAlmacenEntrada.Tag, Integer) = 0 And cboAlmacenEntrada.SelectedIndex > -1 Then
                Dim drAlmacenGas As DataRow = _dtAlmacenGasEntrada.Rows.Find(cboAlmacenEntrada.SelectedValue)
                txtRutaApertura.Text = CType(drAlmacenGas.Item("DescripcionRuta"), String)
                txtRutaApertura.Tag = CType(drAlmacenGas.Item("Ruta"), Integer)
                txtCelulaApertura.Text = CType(drAlmacenGas.Item("DescripcionCelula"), String)
                txtCelulaApertura.Tag = CType(drAlmacenGas.Item("Celula"), Integer)
                PosicionaContenedorPredeterminado(CType(drAlmacenGas.Item("Corporativo"), Short), CType(drAlmacenGas.Item("Sucursal"), Short))
            End If
        End If
    End Sub

    Private Sub frmAutotanques_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        frmLecturaCOM.Close() ''CambiosBascula
    End Sub

    Private Sub pnlAcciones_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles pnlAcciones.Paint

    End Sub

    Private Sub tmrLectura_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrLectura.Tick
        EjecutarLectura()
    End Sub

    Public Sub EjecutarLectura()

        DatosEntrada.IP = Globales.GetInstance._IpLectorTag
        DatosEntrada.Puerto = Globales.GetInstance._PuertoLectorTag
        DatosEntrada.CaracterDeEjecucion = Globales.GetInstance._CaracterLectorTag
        DatosEntrada.CaracterABuscar = String.Empty
        DatosEntrada.PosicionInicial = Globales.GetInstance._PosicionInicialLectorTag
        DatosEntrada.NumCaracteres = Globales.GetInstance._NCaracteresLectorTag

        Try

            If (txtAutotanque.Text.Length = 0) Then

                If (lstTransponders.Count > 0) Then

                    If semaforo = False Then
                        Dim valorSinCeros As Long
                        valorSinCeros = Long.Parse(lstTransponders(0).Transponder)
                        Dim att As String = ConsultarAtt(valorSinCeros.ToString()).ToString()
                        If att <> "0" Then
                            txtAutotanque.Text = att
                            semaforoElimina = True
                            BuscaAutotanque()
                        Else
                            lstTransponders.RemoveAt(0)
                        End If

                    End If

                End If

            End If


            Dim str As String = LlamarBascula.ObtenerLectura(DatosEntrada)

            If (str.Length > 5) Then

                Dim trans As TransponderLeido = New TransponderLeido()
                trans.Transponder = str

                If ValidarElementoEnLista(trans) = False Then

                    lstTransponders.Add(trans)

                    If semaforo = False Then
                        Dim valorSinCeros As Long
                        valorSinCeros = Long.Parse(lstTransponders(0).Transponder)
                        Dim att As String = ConsultarAtt(valorSinCeros.ToString()).ToString()
                        If att <> "0" Then
                            txtAutotanque.Text = att
                            semaforoElimina = True
                            BuscaAutotanque()
                        Else
                            lstTransponders.Remove(trans)
                        End If

                    End If

                End If
            End If

        Catch ex As Exception
            MessageBox.Show("Error: " + ex.Message)
        End Try

    End Sub

    Function ValidarElementoEnLista(ByVal Elemento As TransponderLeido) As Boolean

        Dim resultado As Boolean = False
        Dim item As TransponderLeido

        If lstTransponders.Count > 0 Then

            For Each item In lstTransponders
                If item.Transponder = Elemento.Transponder Then
                    resultado = True
                End If
            Next
        End If
        Return resultado
    End Function

    Function ConsultarAtt(ByVal Tag As String) As Integer
        Dim Autotanque As Integer = 0
        Dim cmdBascula As New SqlCommand("spBASConsultarAttPorTag", Globales.GetInstance.cnSigamet)
        Dim rdFolio As SqlDataReader

        cmdBascula.CommandType = CommandType.StoredProcedure
        cmdBascula.Parameters.Add("@Tag", SqlDbType.VarChar).Value = Tag
        Try
            Globales.GetInstance.AbreConexion()
            rdFolio = cmdBascula.ExecuteReader
            If rdFolio.Read Then
                Autotanque = CInt(rdFolio("Autotanque"))
            End If
            rdFolio.Close()
        Catch ex As Exception
           
            Globales.GetInstance.ExMessage(ex)
        Finally

            Globales.GetInstance.CierraConexion()

        End Try
        Return Autotanque
    End Function

End Class