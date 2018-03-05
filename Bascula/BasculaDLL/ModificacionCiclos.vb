Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared

Public Class frmModificacionCiclos
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        Dim items As MenuItem() = {mnuBuscar.MenuItems(0).CloneMenu, mnuBuscar.MenuItems(1).CloneMenu, mnuBuscar.MenuItems(2).CloneMenu}
        dtpFecha.MaxDate = Now.Date.AddDays(2)
        dtpFecha.Value = Now.Date
        mniBuscar.MenuItems.AddRange(items)

        mniAgregar.Enabled = Globales.GetInstance.OperacionBascula(2).Habilitada Or Globales.GetInstance.OperacionBascula(9).Habilitada
        mniModificar.Enabled = Globales.GetInstance.OperacionBascula(2).Habilitada Or Globales.GetInstance.OperacionBascula(9).Habilitada
        btnAgregar.Enabled = Globales.GetInstance.OperacionBascula(2).Habilitada Or Globales.GetInstance.OperacionBascula(9).Habilitada
        btnModificar.Enabled = Globales.GetInstance.OperacionBascula(2).Habilitada Or Globales.GetInstance.OperacionBascula(9).Habilitada

        CargaCelulas()
        Actualizar()
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
    Friend WithEvents mnuCiclosCerrados As System.Windows.Forms.MainMenu
    Friend WithEvents mniModificaciones As System.Windows.Forms.MenuItem
    Friend WithEvents mniModificacionCiclos As System.Windows.Forms.MenuItem
    Friend WithEvents mniAgregar As System.Windows.Forms.MenuItem
    Friend WithEvents mniModificar As System.Windows.Forms.MenuItem
    Friend WithEvents Sepm0 As System.Windows.Forms.MenuItem
    Friend WithEvents mniBuscar As System.Windows.Forms.MenuItem
    Friend WithEvents mniActualizar As System.Windows.Forms.MenuItem
    Friend WithEvents Sepm1 As System.Windows.Forms.MenuItem
    Friend WithEvents mniCerrar As System.Windows.Forms.MenuItem
    Friend WithEvents imgModificacionCiclos As System.Windows.Forms.ImageList
    Friend WithEvents tbModificacionCiclos As System.Windows.Forms.ToolBar
    Friend WithEvents btnAgregar As System.Windows.Forms.ToolBarButton
    Friend WithEvents btnModificar As System.Windows.Forms.ToolBarButton
    Friend WithEvents Sep0 As System.Windows.Forms.ToolBarButton
    Friend WithEvents btnBuscar As System.Windows.Forms.ToolBarButton
    Friend WithEvents btnActualizar As System.Windows.Forms.ToolBarButton
    Friend WithEvents btnFiltrar As System.Windows.Forms.ToolBarButton
    Friend WithEvents Sep1 As System.Windows.Forms.ToolBarButton
    Friend WithEvents btnCerrar As System.Windows.Forms.ToolBarButton
    Friend WithEvents pnlDatosAutotanque As System.Windows.Forms.Panel
    Friend WithEvents lblCelula As System.Windows.Forms.Label
    Friend WithEvents lblRuta As System.Windows.Forms.Label
    Friend WithEvents txtPlacas As System.Windows.Forms.TextBox
    Friend WithEvents txtCapacidad As System.Windows.Forms.TextBox
    Friend WithEvents lblPlacas As System.Windows.Forms.Label
    Friend WithEvents lblCapacidad As System.Windows.Forms.Label
    Friend WithEvents vgCiclos As Bascula.ViewGrid
    Friend WithEvents lblFecha As System.Windows.Forms.Label
    Friend WithEvents dtpFecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents pnlTitulo As System.Windows.Forms.Panel
    Friend WithEvents mnuFiltro As System.Windows.Forms.ContextMenu
    Friend WithEvents mniAbierto As System.Windows.Forms.MenuItem
    Friend WithEvents mniCancelado As System.Windows.Forms.MenuItem
    Friend WithEvents mniCerrado As System.Windows.Forms.MenuItem
    Friend WithEvents mniTodas As System.Windows.Forms.MenuItem
    Friend WithEvents mniTodos As System.Windows.Forms.MenuItem
    Friend WithEvents Sepm2 As System.Windows.Forms.MenuItem
    Friend WithEvents txtRuta As System.Windows.Forms.TextBox
    Friend WithEvents txtCelula As System.Windows.Forms.TextBox
    Friend WithEvents mnuBuscar As System.Windows.Forms.ContextMenu
    Friend WithEvents mniBuscarFolio As System.Windows.Forms.MenuItem
    Friend WithEvents mniBuscarRuta As System.Windows.Forms.MenuItem
    Friend WithEvents mniBuscarAutotanque As System.Windows.Forms.MenuItem
    Friend WithEvents rlblTitulo As Bascula.RotatableLabel
    Friend WithEvents btnImprimir As System.Windows.Forms.ToolBarButton
    Friend WithEvents mniImprimir As System.Windows.Forms.MenuItem
    Friend WithEvents mniReporteApertura As System.Windows.Forms.MenuItem
    Friend WithEvents mniReporteCierre As System.Windows.Forms.MenuItem
    Friend WithEvents mniReporteResguardo As System.Windows.Forms.MenuItem
    Friend WithEvents mnuImprimir As System.Windows.Forms.ContextMenu
    Friend WithEvents mniReporteApertura2 As System.Windows.Forms.MenuItem
    Friend WithEvents mniReporteCierre2 As System.Windows.Forms.MenuItem
    Friend WithEvents crvReporte As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents chkPG As System.Windows.Forms.CheckBox
    Friend WithEvents Sep00 As System.Windows.Forms.MenuItem
    Friend WithEvents mniReportePG As System.Windows.Forms.MenuItem
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmModificacionCiclos))
        Me.mnuCiclosCerrados = New System.Windows.Forms.MainMenu(Me.components)
        Me.mniModificaciones = New System.Windows.Forms.MenuItem()
        Me.mniModificacionCiclos = New System.Windows.Forms.MenuItem()
        Me.mniAgregar = New System.Windows.Forms.MenuItem()
        Me.mniModificar = New System.Windows.Forms.MenuItem()
        Me.mniImprimir = New System.Windows.Forms.MenuItem()
        Me.Sepm0 = New System.Windows.Forms.MenuItem()
        Me.mniBuscar = New System.Windows.Forms.MenuItem()
        Me.mniActualizar = New System.Windows.Forms.MenuItem()
        Me.Sepm1 = New System.Windows.Forms.MenuItem()
        Me.mniCerrar = New System.Windows.Forms.MenuItem()
        Me.mniReporteApertura = New System.Windows.Forms.MenuItem()
        Me.mniReporteCierre = New System.Windows.Forms.MenuItem()
        Me.mniReporteResguardo = New System.Windows.Forms.MenuItem()
        Me.Sep00 = New System.Windows.Forms.MenuItem()
        Me.mniReportePG = New System.Windows.Forms.MenuItem()
        Me.imgModificacionCiclos = New System.Windows.Forms.ImageList(Me.components)
        Me.tbModificacionCiclos = New System.Windows.Forms.ToolBar()
        Me.btnAgregar = New System.Windows.Forms.ToolBarButton()
        Me.btnModificar = New System.Windows.Forms.ToolBarButton()
        Me.btnImprimir = New System.Windows.Forms.ToolBarButton()
        Me.mnuImprimir = New System.Windows.Forms.ContextMenu()
        Me.mniReporteApertura2 = New System.Windows.Forms.MenuItem()
        Me.mniReporteCierre2 = New System.Windows.Forms.MenuItem()
        Me.Sep0 = New System.Windows.Forms.ToolBarButton()
        Me.btnFiltrar = New System.Windows.Forms.ToolBarButton()
        Me.mnuFiltro = New System.Windows.Forms.ContextMenu()
        Me.mniAbierto = New System.Windows.Forms.MenuItem()
        Me.mniCancelado = New System.Windows.Forms.MenuItem()
        Me.mniCerrado = New System.Windows.Forms.MenuItem()
        Me.mniTodos = New System.Windows.Forms.MenuItem()
        Me.Sepm2 = New System.Windows.Forms.MenuItem()
        Me.mniTodas = New System.Windows.Forms.MenuItem()
        Me.btnBuscar = New System.Windows.Forms.ToolBarButton()
        Me.mnuBuscar = New System.Windows.Forms.ContextMenu()
        Me.mniBuscarFolio = New System.Windows.Forms.MenuItem()
        Me.mniBuscarRuta = New System.Windows.Forms.MenuItem()
        Me.mniBuscarAutotanque = New System.Windows.Forms.MenuItem()
        Me.btnActualizar = New System.Windows.Forms.ToolBarButton()
        Me.Sep1 = New System.Windows.Forms.ToolBarButton()
        Me.btnCerrar = New System.Windows.Forms.ToolBarButton()
        Me.pnlDatosAutotanque = New System.Windows.Forms.Panel()
        Me.txtRuta = New System.Windows.Forms.TextBox()
        Me.lblCelula = New System.Windows.Forms.Label()
        Me.txtCelula = New System.Windows.Forms.TextBox()
        Me.lblRuta = New System.Windows.Forms.Label()
        Me.txtPlacas = New System.Windows.Forms.TextBox()
        Me.txtCapacidad = New System.Windows.Forms.TextBox()
        Me.lblPlacas = New System.Windows.Forms.Label()
        Me.lblCapacidad = New System.Windows.Forms.Label()
        Me.crvReporte = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
        Me.lblFecha = New System.Windows.Forms.Label()
        Me.dtpFecha = New System.Windows.Forms.DateTimePicker()
        Me.pnlTitulo = New System.Windows.Forms.Panel()
        Me.rlblTitulo = New Bascula.RotatableLabel()
        Me.chkPG = New System.Windows.Forms.CheckBox()
        Me.vgCiclos = New Bascula.ViewGrid()
        Me.pnlDatosAutotanque.SuspendLayout()
        Me.pnlTitulo.SuspendLayout()
        Me.SuspendLayout()
        '
        'mnuCiclosCerrados
        '
        Me.mnuCiclosCerrados.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mniModificaciones})
        '
        'mniModificaciones
        '
        Me.mniModificaciones.Index = 0
        Me.mniModificaciones.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mniModificacionCiclos})
        Me.mniModificaciones.MergeOrder = 2
        Me.mniModificaciones.MergeType = System.Windows.Forms.MenuMerge.MergeItems
        Me.mniModificaciones.Text = "&Modificaciones"
        '
        'mniModificacionCiclos
        '
        Me.mniModificacionCiclos.Index = 0
        Me.mniModificacionCiclos.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mniAgregar, Me.mniModificar, Me.mniImprimir, Me.Sepm0, Me.mniBuscar, Me.mniActualizar, Me.Sepm1, Me.mniCerrar})
        Me.mniModificacionCiclos.MergeType = System.Windows.Forms.MenuMerge.MergeItems
        Me.mniModificacionCiclos.Text = "&Modificación de ciclos"
        '
        'mniAgregar
        '
        Me.mniAgregar.Index = 0
        Me.mniAgregar.Shortcut = System.Windows.Forms.Shortcut.Ins
        Me.mniAgregar.Text = "&Agregar"
        '
        'mniModificar
        '
        Me.mniModificar.Index = 1
        Me.mniModificar.Shortcut = System.Windows.Forms.Shortcut.CtrlIns
        Me.mniModificar.Text = "&Modificar"
        '
        'mniImprimir
        '
        Me.mniImprimir.Index = 2
        Me.mniImprimir.Text = "&Imprimir"
        '
        'Sepm0
        '
        Me.Sepm0.Index = 3
        Me.Sepm0.Text = "-"
        '
        'mniBuscar
        '
        Me.mniBuscar.Index = 4
        Me.mniBuscar.Shortcut = System.Windows.Forms.Shortcut.CtrlB
        Me.mniBuscar.Text = "&Buscar"
        '
        'mniActualizar
        '
        Me.mniActualizar.Index = 5
        Me.mniActualizar.Shortcut = System.Windows.Forms.Shortcut.F5
        Me.mniActualizar.Text = "Ac&tualizar"
        '
        'Sepm1
        '
        Me.Sepm1.Index = 6
        Me.Sepm1.Text = "-"
        '
        'mniCerrar
        '
        Me.mniCerrar.Index = 7
        Me.mniCerrar.Text = "&Cerrar"
        '
        'mniReporteApertura
        '
        Me.mniReporteApertura.Index = -1
        Me.mniReporteApertura.Text = "&Apertura de ciclo"
        '
        'mniReporteCierre
        '
        Me.mniReporteCierre.Index = -1
        Me.mniReporteCierre.Text = "&Cierre de ciclo"
        '
        'mniReporteResguardo
        '
        Me.mniReporteResguardo.Enabled = False
        Me.mniReporteResguardo.Index = 2
        Me.mniReporteResguardo.Text = "&Reporte resguardo"
        '
        'Sep00
        '
        Me.Sep00.Index = -1
        Me.Sep00.Text = "-"
        '
        'mniReportePG
        '
        Me.mniReportePG.Enabled = False
        Me.mniReportePG.Index = -1
        Me.mniReportePG.Text = "&PG's y vehículos externos"
        '
        'imgModificacionCiclos
        '
        Me.imgModificacionCiclos.ImageStream = CType(resources.GetObject("imgModificacionCiclos.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imgModificacionCiclos.TransparentColor = System.Drawing.Color.Transparent
        Me.imgModificacionCiclos.Images.SetKeyName(0, "")
        Me.imgModificacionCiclos.Images.SetKeyName(1, "")
        Me.imgModificacionCiclos.Images.SetKeyName(2, "")
        Me.imgModificacionCiclos.Images.SetKeyName(3, "")
        Me.imgModificacionCiclos.Images.SetKeyName(4, "")
        Me.imgModificacionCiclos.Images.SetKeyName(5, "")
        Me.imgModificacionCiclos.Images.SetKeyName(6, "")
        '
        'tbModificacionCiclos
        '
        Me.tbModificacionCiclos.Appearance = System.Windows.Forms.ToolBarAppearance.Flat
        Me.tbModificacionCiclos.Buttons.AddRange(New System.Windows.Forms.ToolBarButton() {Me.btnAgregar, Me.btnModificar, Me.btnImprimir, Me.Sep0, Me.btnFiltrar, Me.btnBuscar, Me.btnActualizar, Me.Sep1, Me.btnCerrar})
        Me.tbModificacionCiclos.DropDownArrows = True
        Me.tbModificacionCiclos.ImageList = Me.imgModificacionCiclos
        Me.tbModificacionCiclos.Location = New System.Drawing.Point(0, 0)
        Me.tbModificacionCiclos.Name = "tbModificacionCiclos"
        Me.tbModificacionCiclos.ShowToolTips = True
        Me.tbModificacionCiclos.Size = New System.Drawing.Size(752, 50)
        Me.tbModificacionCiclos.TabIndex = 0
        '
        'btnAgregar
        '
        Me.btnAgregar.ImageIndex = 0
        Me.btnAgregar.Name = "btnAgregar"
        Me.btnAgregar.Text = "Agregar"
        Me.btnAgregar.ToolTipText = "Apertura manual de ciclos"
        '
        'btnModificar
        '
        Me.btnModificar.ImageIndex = 1
        Me.btnModificar.Name = "btnModificar"
        Me.btnModificar.Text = "Modificar"
        Me.btnModificar.ToolTipText = "Modificar el ciclo seleccionado"
        '
        'btnImprimir
        '
        Me.btnImprimir.DropDownMenu = Me.mnuImprimir
        Me.btnImprimir.ImageIndex = 6
        Me.btnImprimir.Name = "btnImprimir"
        Me.btnImprimir.Style = System.Windows.Forms.ToolBarButtonStyle.DropDownButton
        Me.btnImprimir.Text = "Imprimir"
        Me.btnImprimir.ToolTipText = "Imprimir comprobante de báscula."
        '
        'mnuImprimir
        '
        Me.mnuImprimir.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mniReporteApertura2, Me.mniReporteCierre2, Me.mniReporteResguardo})
        '
        'mniReporteApertura2
        '
        Me.mniReporteApertura2.Index = 0
        Me.mniReporteApertura2.Text = "&Apertura de ciclo"
        '
        'mniReporteCierre2
        '
        Me.mniReporteCierre2.Index = 1
        Me.mniReporteCierre2.Text = "&Cierre de ciclo"
        '
        'Sep0
        '
        Me.Sep0.Name = "Sep0"
        Me.Sep0.Style = System.Windows.Forms.ToolBarButtonStyle.Separator
        '
        'btnFiltrar
        '
        Me.btnFiltrar.DropDownMenu = Me.mnuFiltro
        Me.btnFiltrar.ImageIndex = 2
        Me.btnFiltrar.Name = "btnFiltrar"
        Me.btnFiltrar.Style = System.Windows.Forms.ToolBarButtonStyle.DropDownButton
        Me.btnFiltrar.Text = "Filtrar"
        Me.btnFiltrar.ToolTipText = "Filtro de los datos"
        '
        'mnuFiltro
        '
        Me.mnuFiltro.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mniAbierto, Me.mniCancelado, Me.mniCerrado, Me.mniTodos, Me.Sepm2, Me.mniTodas})
        '
        'mniAbierto
        '
        Me.mniAbierto.Index = 0
        Me.mniAbierto.RadioCheck = True
        Me.mniAbierto.Text = "Abierto"
        '
        'mniCancelado
        '
        Me.mniCancelado.Index = 1
        Me.mniCancelado.RadioCheck = True
        Me.mniCancelado.Text = "Cancelado"
        '
        'mniCerrado
        '
        Me.mniCerrado.Checked = True
        Me.mniCerrado.DefaultItem = True
        Me.mniCerrado.Index = 2
        Me.mniCerrado.RadioCheck = True
        Me.mniCerrado.Text = "Cerrado"
        '
        'mniTodos
        '
        Me.mniTodos.Index = 3
        Me.mniTodos.RadioCheck = True
        Me.mniTodos.Text = "Todos"
        '
        'Sepm2
        '
        Me.Sepm2.Index = 4
        Me.Sepm2.Text = "-"
        '
        'mniTodas
        '
        Me.mniTodas.Checked = True
        Me.mniTodas.DefaultItem = True
        Me.mniTodas.Index = 5
        Me.mniTodas.RadioCheck = True
        Me.mniTodas.Text = "Todas las células"
        '
        'btnBuscar
        '
        Me.btnBuscar.DropDownMenu = Me.mnuBuscar
        Me.btnBuscar.ImageIndex = 3
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Style = System.Windows.Forms.ToolBarButtonStyle.DropDownButton
        Me.btnBuscar.Text = "Buscar"
        Me.btnBuscar.ToolTipText = "Buscar ciclos"
        '
        'mnuBuscar
        '
        Me.mnuBuscar.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mniBuscarFolio, Me.mniBuscarRuta, Me.mniBuscarAutotanque})
        '
        'mniBuscarFolio
        '
        Me.mniBuscarFolio.Index = 0
        Me.mniBuscarFolio.Text = "&Folio"
        '
        'mniBuscarRuta
        '
        Me.mniBuscarRuta.Index = 1
        Me.mniBuscarRuta.Text = "&Ruta"
        '
        'mniBuscarAutotanque
        '
        Me.mniBuscarAutotanque.Index = 2
        Me.mniBuscarAutotanque.Text = "&Autotanque"
        '
        'btnActualizar
        '
        Me.btnActualizar.ImageIndex = 4
        Me.btnActualizar.Name = "btnActualizar"
        Me.btnActualizar.Text = "Actualizar"
        Me.btnActualizar.ToolTipText = "Cargar los datos más recientes"
        '
        'Sep1
        '
        Me.Sep1.Name = "Sep1"
        Me.Sep1.Style = System.Windows.Forms.ToolBarButtonStyle.Separator
        '
        'btnCerrar
        '
        Me.btnCerrar.ImageIndex = 5
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Text = "Cerrar"
        Me.btnCerrar.ToolTipText = "Cerrar la modificación de ciclos"
        '
        'pnlDatosAutotanque
        '
        Me.pnlDatosAutotanque.BackColor = System.Drawing.Color.WhiteSmoke
        Me.pnlDatosAutotanque.Controls.Add(Me.txtRuta)
        Me.pnlDatosAutotanque.Controls.Add(Me.lblCelula)
        Me.pnlDatosAutotanque.Controls.Add(Me.txtCelula)
        Me.pnlDatosAutotanque.Controls.Add(Me.lblRuta)
        Me.pnlDatosAutotanque.Controls.Add(Me.txtPlacas)
        Me.pnlDatosAutotanque.Controls.Add(Me.txtCapacidad)
        Me.pnlDatosAutotanque.Controls.Add(Me.lblPlacas)
        Me.pnlDatosAutotanque.Controls.Add(Me.lblCapacidad)
        Me.pnlDatosAutotanque.Controls.Add(Me.crvReporte)
        Me.pnlDatosAutotanque.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlDatosAutotanque.Location = New System.Drawing.Point(0, 373)
        Me.pnlDatosAutotanque.Name = "pnlDatosAutotanque"
        Me.pnlDatosAutotanque.Size = New System.Drawing.Size(752, 72)
        Me.pnlDatosAutotanque.TabIndex = 1
        '
        'txtRuta
        '
        Me.txtRuta.BackColor = System.Drawing.Color.Gainsboro
        Me.txtRuta.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtRuta.Location = New System.Drawing.Point(57, 42)
        Me.txtRuta.Name = "txtRuta"
        Me.txtRuta.ReadOnly = True
        Me.txtRuta.Size = New System.Drawing.Size(64, 21)
        Me.txtRuta.TabIndex = 1
        '
        'lblCelula
        '
        Me.lblCelula.AutoSize = True
        Me.lblCelula.Location = New System.Drawing.Point(13, 13)
        Me.lblCelula.Name = "lblCelula"
        Me.lblCelula.Size = New System.Drawing.Size(40, 13)
        Me.lblCelula.TabIndex = 0
        Me.lblCelula.Text = "Celula:"
        '
        'txtCelula
        '
        Me.txtCelula.BackColor = System.Drawing.Color.Gainsboro
        Me.txtCelula.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCelula.Location = New System.Drawing.Point(57, 10)
        Me.txtCelula.Name = "txtCelula"
        Me.txtCelula.ReadOnly = True
        Me.txtCelula.Size = New System.Drawing.Size(64, 21)
        Me.txtCelula.TabIndex = 1
        '
        'lblRuta
        '
        Me.lblRuta.AutoSize = True
        Me.lblRuta.Location = New System.Drawing.Point(13, 45)
        Me.lblRuta.Name = "lblRuta"
        Me.lblRuta.Size = New System.Drawing.Size(34, 13)
        Me.lblRuta.TabIndex = 0
        Me.lblRuta.Text = "Ruta:"
        '
        'txtPlacas
        '
        Me.txtPlacas.BackColor = System.Drawing.Color.Gainsboro
        Me.txtPlacas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPlacas.Location = New System.Drawing.Point(243, 10)
        Me.txtPlacas.Name = "txtPlacas"
        Me.txtPlacas.ReadOnly = True
        Me.txtPlacas.Size = New System.Drawing.Size(101, 21)
        Me.txtPlacas.TabIndex = 1
        '
        'txtCapacidad
        '
        Me.txtCapacidad.BackColor = System.Drawing.Color.Gainsboro
        Me.txtCapacidad.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCapacidad.Location = New System.Drawing.Point(243, 42)
        Me.txtCapacidad.Name = "txtCapacidad"
        Me.txtCapacidad.ReadOnly = True
        Me.txtCapacidad.Size = New System.Drawing.Size(101, 21)
        Me.txtCapacidad.TabIndex = 1
        '
        'lblPlacas
        '
        Me.lblPlacas.AutoSize = True
        Me.lblPlacas.Location = New System.Drawing.Point(176, 13)
        Me.lblPlacas.Name = "lblPlacas"
        Me.lblPlacas.Size = New System.Drawing.Size(41, 13)
        Me.lblPlacas.TabIndex = 0
        Me.lblPlacas.Text = "Placas:"
        '
        'lblCapacidad
        '
        Me.lblCapacidad.AutoSize = True
        Me.lblCapacidad.Location = New System.Drawing.Point(176, 45)
        Me.lblCapacidad.Name = "lblCapacidad"
        Me.lblCapacidad.Size = New System.Drawing.Size(61, 13)
        Me.lblCapacidad.TabIndex = 0
        Me.lblCapacidad.Text = "Capacidad:"
        '
        'crvReporte
        '
        Me.crvReporte.ActiveViewIndex = -1
        Me.crvReporte.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.crvReporte.Cursor = System.Windows.Forms.Cursors.Default
        Me.crvReporte.Location = New System.Drawing.Point(576, 8)
        Me.crvReporte.Name = "crvReporte"
        Me.crvReporte.Size = New System.Drawing.Size(10, 10)
        Me.crvReporte.TabIndex = 54
        '
        'lblFecha
        '
        Me.lblFecha.AutoSize = True
        Me.lblFecha.Location = New System.Drawing.Point(404, 13)
        Me.lblFecha.Name = "lblFecha"
        Me.lblFecha.Size = New System.Drawing.Size(40, 13)
        Me.lblFecha.TabIndex = 3
        Me.lblFecha.Text = "&Fecha:"
        '
        'dtpFecha
        '
        Me.dtpFecha.CustomFormat = "dd 'de' MMMM 'de' yyy"
        Me.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpFecha.Location = New System.Drawing.Point(446, 10)
        Me.dtpFecha.Name = "dtpFecha"
        Me.dtpFecha.Size = New System.Drawing.Size(152, 21)
        Me.dtpFecha.TabIndex = 4
        '
        'pnlTitulo
        '
        Me.pnlTitulo.Controls.Add(Me.rlblTitulo)
        Me.pnlTitulo.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlTitulo.Location = New System.Drawing.Point(0, 50)
        Me.pnlTitulo.Name = "pnlTitulo"
        Me.pnlTitulo.Size = New System.Drawing.Size(24, 323)
        Me.pnlTitulo.TabIndex = 5
        '
        'rlblTitulo
        '
        Me.rlblTitulo.Border = False
        Me.rlblTitulo.Caption = "Ciclos"
        Me.rlblTitulo.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.rlblTitulo.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rlblTitulo.ForeColor = System.Drawing.Color.MidnightBlue
        Me.rlblTitulo.Location = New System.Drawing.Point(0, 248)
        Me.rlblTitulo.Name = "rlblTitulo"
        Me.rlblTitulo.RotationAngle = 270
        Me.rlblTitulo.Size = New System.Drawing.Size(21, 75)
        Me.rlblTitulo.TabIndex = 0
        '
        'chkPG
        '
        Me.chkPG.Location = New System.Drawing.Point(608, 8)
        Me.chkPG.Name = "chkPG"
        Me.chkPG.Size = New System.Drawing.Size(152, 24)
        Me.chkPG.TabIndex = 6
        Me.chkPG.Text = "PG's y vehículos externos"
        '
        'vgCiclos
        '
        Me.vgCiclos.AlternativeBackColor = System.Drawing.Color.Gainsboro
        Me.vgCiclos.CheckCondition = Nothing
        Me.vgCiclos.DataSource = Nothing
        Me.vgCiclos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.vgCiclos.FormatColumnNames = New String(-1) {}
        Me.vgCiclos.FullRowSelect = True
        Me.vgCiclos.GridLines = True
        Me.vgCiclos.HidedColumnNames = New String() {"Celula", "Ruta", "Placas", "Capacidad", "PorcentajeGasInicial", "LitrosGasInicial", "KilometrajeInicial", "TotalizadorInicial", "PorcentajeGasFinal", "LitrosGasFinal", "KilometrajeFinal", "TotalizadorFinal", "ObservacionesInicioRuta", "ObservacionesCierreRuta"}
        Me.vgCiclos.HideSelection = False
        Me.vgCiclos.Location = New System.Drawing.Point(24, 50)
        Me.vgCiclos.MultiSelect = False
        Me.vgCiclos.Name = "vgCiclos"
        Me.vgCiclos.PKColumnNames = Nothing
        Me.vgCiclos.Size = New System.Drawing.Size(728, 323)
        Me.vgCiclos.TabIndex = 2
        Me.vgCiclos.UseCompatibleStateImageBehavior = False
        Me.vgCiclos.View = System.Windows.Forms.View.Details
        '
        'frmModificacionCiclos
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 14)
        Me.BackColor = System.Drawing.Color.Gainsboro
        Me.ClientSize = New System.Drawing.Size(752, 445)
        Me.Controls.Add(Me.chkPG)
        Me.Controls.Add(Me.dtpFecha)
        Me.Controls.Add(Me.lblFecha)
        Me.Controls.Add(Me.vgCiclos)
        Me.Controls.Add(Me.pnlTitulo)
        Me.Controls.Add(Me.tbModificacionCiclos)
        Me.Controls.Add(Me.pnlDatosAutotanque)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Menu = Me.mnuCiclosCerrados
        Me.MinimizeBox = False
        Me.Name = "frmModificacionCiclos"
        Me.ShowInTaskbar = False
        Me.Text = "Modificación de ciclos"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.pnlDatosAutotanque.ResumeLayout(False)
        Me.pnlDatosAutotanque.PerformLayout()
        Me.pnlTitulo.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

#Region "Variables globales"
    Private Status As String = "CERRADO"
    Private Celula As Integer = 0
    Private dtCelula As New DataTable()
    Private Busqueda As String = "Folio"
    Private Folio As String
    Private rptReporte As New ReportDocument()
    Private _TablaReporte As Table
    Private _LogonInfo As TableLogOnInfo
#End Region

#Region "Rutinas de actualización"
    Private Sub CargaCelulas()
        Dim cmdBascula As New SqlCommand("Select Celula, Descripcion from Celula where Comercial = 1 and Celula in (Select Celula from UsuarioCelula " _
                            & " where Usuario = @Usuario) order by Descripcion", Globales.GetInstance.cnSigamet)
        Dim daBascula As New SqlDataAdapter(cmdBascula)
        Dim Key(0) As DataColumn
        Dim Row As DataRow
        cmdBascula.Parameters.Add("@Usuario", SqlDbType.Char).Value = Globales.GetInstance._Usuario
        dtCelula.Clear()
        Try
            daBascula.Fill(dtCelula)
            Key(0) = dtCelula.Columns("Descripcion")
            dtCelula.PrimaryKey = Key
        Catch ex As Exception
            Globales.GetInstance.ExMessage(ex)
        End Try
        For Each Row In dtCelula.Rows
            mnuFiltro.MenuItems.Add(CStr(Row("Descripcion")), AddressOf mniCelula_Click)
        Next
    End Sub
    Private Sub Actualizar()
        Dim cmdBascula As New SqlCommand("Select * from vwBASInformacionFolios where FInicioRuta " & _
                    "between @FInicial and @FFinal ", Globales.GetInstance.cnSigamet)
        Dim daBascuala As New SqlDataAdapter(cmdBascula)
        Dim dtCiclos As New DataTable()
        cmdBascula.Parameters.Add("@FInicial", SqlDbType.DateTime).Value = dtpFecha.Value.Date
        cmdBascula.Parameters.Add("@FFinal", SqlDbType.DateTime).Value = dtpFecha.Value.Date.AddHours(23).AddMinutes(59).AddSeconds(59)
        If Status <> "" Then
            cmdBascula.CommandText &= " and StatusBascula = @Status "
            cmdBascula.Parameters.Add("@Status", SqlDbType.Char).Value = Status
        End If
        If Celula > 0 Then
            cmdBascula.CommandText &= " and Celula = @Celula "
            cmdBascula.Parameters.Add("@Celula", SqlDbType.TinyInt).Value = Celula
        End If
        'Agregado para la reimpresión y consulta de PG's y vehíclos externos
        If chkPG.Checked Then
            cmdBascula.CommandText = "Select * from vwBASInformacionCicloPG where FPesoInicial between @FInicial and @FFinal or FPesoFinal between @FInicial and @FFinal"
        ElseIf Not Globales.GetInstance.OperacionBascula(9).Habilitada Then
            cmdBascula.CommandText &= " and StatusLogistica not in  ('LIQCAJA', 'LIQUIDADO') "
        End If

        AsignaTitulo()
        Try
            daBascuala.Fill(dtCiclos)
            vgCiclos.DataSource = dtCiclos
            vgCiclos.FindFirst("Folio", Folio)
        Catch ex As Exception
            Globales.GetInstance.ExMessage(ex)
        End Try
    End Sub
    Private Sub dtpFecha_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpFecha.ValueChanged
        Actualizar()
    End Sub
    Private Sub vgCiclos_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles vgCiclos.SelectedIndexChanged
        If Not vgCiclos.CurrentRow Is Nothing AndAlso Not chkPG.Checked Then
            txtCelula.Text = CStr(vgCiclos.CurrentRow("Celula"))
            txtRuta.Text = CStr(vgCiclos.CurrentRow("Ruta"))
            txtPlacas.Text = CStr(vgCiclos.CurrentRow("Placas"))
            txtCapacidad.Text = CStr(vgCiclos.CurrentRow("Capacidad"))
            Folio = CStr(vgCiclos.CurrentRow("Folio"))
            Select Case CStr(vgCiclos.CurrentRow("StatusBascula")).Trim.ToUpper
                Case "CERRADO"
                    mniReporteApertura.Enabled = True
                    mniReporteApertura2.Enabled = True
                    mniReporteCierre.Enabled = True
                    mniReporteCierre2.Enabled = True
                Case "ABIERTO"
                    mniReporteApertura.Enabled = True
                    mniReporteApertura2.Enabled = True
                    mniReporteCierre.Enabled = False
                    mniReporteCierre2.Enabled = False
                Case Else
                    mniReporteApertura.Enabled = False
                    mniReporteApertura2.Enabled = False
                    mniReporteCierre.Enabled = False
                    mniReporteCierre2.Enabled = False
            End Select
            If CInt(vgCiclos.CurrentRow("Autotanque")) = Globales.GetInstance._PipaCuata Then
                mniReporteResguardo.Enabled = True
                mniReporteApertura2.Enabled = False
                mniReporteCierre2.Enabled = False
            Else
                mniReporteResguardo.Enabled = False
                mniReporteApertura2.Enabled = True
                mniReporteCierre2.Enabled = True
            End If
        End If
    End Sub
    Private Sub mniStatus_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mniAbierto.Click, mniCancelado.Click, mniCerrado.Click, mniTodos.Click
        Dim item As MenuItem
        For Each item In mnuFiltro.MenuItems
            If item.Index < 4 Then
                item.Checked = False
            Else
                Exit For
            End If
        Next
        CType(sender, MenuItem).Checked = True
        If CType(sender, MenuItem).Index = 3 Then
            Status = ""
        Else
            Status = CType(sender, MenuItem).Text
        End If
        Actualizar()
    End Sub
    Private Sub mniCelula_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mniTodas.Click
        Dim item As MenuItem
        For Each item In mnuFiltro.MenuItems
            If item.Index > 4 Then
                item.Checked = False
            End If
        Next
        CType(sender, MenuItem).Checked = True
        If CType(sender, MenuItem).Index = 5 Then
            Celula = 0
        Else
            Celula = CInt(dtCelula.Rows.Find(CType(sender, MenuItem).Text)("Celula"))
        End If
        Actualizar()
    End Sub
    Private Sub AsignaTitulo()
        Dim item As MenuItem
        rlblTitulo.Caption = "Ciclos "
        If Not chkPG.Checked Then
            For Each item In mnuFiltro.MenuItems
                If item.Index < 3 AndAlso item.Checked Then
                    rlblTitulo.Caption &= item.Text.ToLower & "s "
                End If
            Next
            For Each item In mnuFiltro.MenuItems
                If item.Index > 4 AndAlso item.Checked Then
                    rlblTitulo.Caption &= "de " & item.Text.Trim.ToLower & " "
                End If
            Next
        Else
            rlblTitulo.Caption &= " de PG's y vehpiculos externos "
        End If
        rlblTitulo.Caption &= "del " & dtpFecha.Value.ToShortDateString
    End Sub
#End Region
#Region "Rutinas de manejo de datos"
    Private Sub Modificar()
        If Not vgCiclos.CurrentRow Is Nothing Then
            Dim frmCapturaCiclo As New frmCapturaCiclo(vgCiclos.CurrentRow)
            If frmCapturaCiclo.ShowDialog() = DialogResult.OK Then
                Actualizar()
            End If
        End If
    End Sub
    Private Sub Agregar()
        Dim frmCapturaCiclo As New frmCapturaCiclo(dtpFecha.Value)
        If frmCapturaCiclo.ShowDialog() = DialogResult.OK Then
            Actualizar()
        End If
    End Sub
    Private Sub Buscar(ByVal Campo As String)
        Dim Busqueda As String = InputBox(Campo & ":", Application.ProductName & " v." & Application.ProductVersion)
        If Busqueda.Trim <> "" AndAlso vgCiclos.FindFirst(Campo, Busqueda) < 0 Then
            Globales.GetInstance.ErrMessage("No se encontro coincidencia.")
        End If
    End Sub
#End Region
#Region "Menus y barra de herramientas"
    Private Sub mniModificar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mniModificar.Click
        Modificar()
    End Sub
    Private Sub mniAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mniAgregar.Click
        Agregar()
    End Sub
    Private Sub mniBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mniBuscarFolio.Click, mniBuscarAutotanque.Click, mniBuscarRuta.Click
        Buscar(CType(sender, MenuItem).Text.Substring(1))
        Busqueda = CType(sender, MenuItem).Text.Substring(1)
    End Sub
    Private Sub mnuBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mniBuscar.Click
        Buscar(Busqueda)
    End Sub
    Private Sub mniActualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mniActualizar.Click
        Actualizar()
    End Sub
    Private Sub mniCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mniCerrar.Click
        Me.Close()
        Me.Dispose()
    End Sub
    Private Sub tbModificacionCiclos_ButtonClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolBarButtonClickEventArgs) Handles tbModificacionCiclos.ButtonClick
        Select Case e.Button.Text
            Case "Agregar"
                Agregar()
            Case "Modificar"
                Modificar()
            Case "Buscar"
                Buscar(Busqueda)
            Case "Actualizar"
                Actualizar()
            Case "Imprimir"
                ImprimeReportePG()
            Case "Cerrar"
                    Me.Close()
                    Me.Dispose()
        End Select
    End Sub
#End Region
#Region "Rutinas de impresión de reportes"
    Private Sub ImprimeReportePG()
        If chkPG.Checked Then
            If Not vgCiclos.CurrentRow Is Nothing Then
                Dim rw As DataRow = vgCiclos.CurrentRow
                ImprimirComprobantePG(CInt(rw("AñoAtt")), CInt(rw("Folio")))
            Else
                Globales.GetInstance.ErrMessage("Seleccione el folio que desea reimprimir")
            End If
        End If
    End Sub

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
        Catch ex As LoadSaveReportException
            Globales.GetInstance.ExMessage(ex)
        Catch ex As Exception
            Globales.GetInstance.ExMessage(ex)
        Finally
            Me.Cursor = Cursors.Default
        End Try

    End Sub
    Private Sub ImprimirComprobantePG(ByVal Año As Integer, ByVal Folio As Integer)
        Dim crParameterFieldDefinitions As ParameterFieldDefinitions
        Dim crParameterFieldDefinition As ParameterFieldDefinition
        Dim crParametervalues As CrystalDecisions.Shared.ParameterValues
        Dim crParameterDiscretValue As CrystalDecisions.Shared.ParameterDiscreteValue
        Cursor = Cursors.WaitCursor
        crvReporte.ReportSource = Nothing
        Try
            'rptReporte.Load(Globales.GetInstance._RutaReportes & "\rptAbreCiclo.rpt")
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
        Catch ex As LoadSaveReportException
            Globales.GetInstance.ExMessage(ex)
        Catch ex As Exception
            Globales.GetInstance.ExMessage(ex)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub ImprimirCicloResguardo(ByVal Año As Integer, ByVal Folio As Integer, ByVal Reimpresion As Boolean)
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
            crParameterDiscretValue.Value = Reimpresion
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
    Private Sub frmModificacionCiclos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Actualizar()
    End Sub

    Private Sub mniReporteApertura_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mniReporteApertura.Click, mniReporteApertura2.Click
        If Not vgCiclos.CurrentRow Is Nothing Then
            Dim rw As DataRow = vgCiclos.CurrentRow
            ImprimirAbreCiclo(CInt(rw("AñoAtt")), CInt(rw("Folio")))
        Else
            Globales.GetInstance.ErrMessage("Seleccione el folio que desea reimprimir")
        End If
    End Sub

    Private Sub mniReporteCierre_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mniReporteCierre.Click, mniReporteCierre2.Click
        If Not vgCiclos.CurrentRow Is Nothing Then
            Dim rw As DataRow = vgCiclos.CurrentRow
            ImprimirCierraCiclo(CInt(rw("AñoAtt")), CInt(rw("Folio")))
        Else
            Globales.GetInstance.ErrMessage("Seleccione el folio que desea reimprimir")
        End If
    End Sub
    Private Sub mniReporteResguardo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mniReporteResguardo.Click
        If Not vgCiclos.CurrentRow Is Nothing Then
            Dim rw As DataRow = vgCiclos.CurrentRow
            ImprimirCicloResguardo(CInt(rw("AñoAtt")), CInt(rw("Folio")), True)
        Else
            Globales.GetInstance.ErrMessage("Seleccione el folio que desea reimprimir")
        End If
    End Sub


    Private Sub chkPG_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkPG.CheckedChanged
        btnAgregar.Enabled = Not chkPG.Checked AndAlso (Globales.GetInstance.OperacionBascula(2).Habilitada Or Globales.GetInstance.OperacionBascula(9).Habilitada)
        btnModificar.Enabled = Not chkPG.Checked AndAlso (Globales.GetInstance.OperacionBascula(2).Habilitada Or Globales.GetInstance.OperacionBascula(9).Habilitada)
        btnFiltrar.Enabled = Not chkPG.Checked
        btnBuscar.Enabled = Not chkPG.Checked

        mniAgregar.Enabled = Not chkPG.Checked AndAlso (Globales.GetInstance.OperacionBascula(2).Habilitada Or Globales.GetInstance.OperacionBascula(9).Habilitada)
        mniModificar.Enabled = Not chkPG.Checked AndAlso (Globales.GetInstance.OperacionBascula(2).Habilitada Or Globales.GetInstance.OperacionBascula(9).Habilitada)
        mniBuscar.Enabled = Not chkPG.Checked
        mniReporteApertura.Enabled = Not chkPG.Checked
        mniReporteCierre.Enabled = Not chkPG.Checked
        mniReporteApertura2.Enabled = Not chkPG.Checked
        mniReporteCierre2.Enabled = Not chkPG.Checked

        mniReportePG.Enabled = chkPG.Checked

        Actualizar()
    End Sub

    Private Sub mniReportePG_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mniReportePG.Click
        If chkPG.Checked Then
            If Not vgCiclos.CurrentRow Is Nothing Then
                Dim rw As DataRow = vgCiclos.CurrentRow
                ImprimirAbreCiclo(CInt(rw("AñoAtt")), CInt(rw("Folio")))
            Else
                Globales.GetInstance.ErrMessage("Seleccione el folio que desea reimprimir")
            End If
        End If
    End Sub

    
End Class
