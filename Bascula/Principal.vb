Option Strict On
Option Explicit On 

Public Class frmPrincipal
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

        'Titulo
        Me.Text = Application.ProductName & " v." & Application.ProductVersion
        Bascula.Globales.GetInstance.ConfiguraModulo([Global].cnSigamet, [Global]._Usuario, [Global]._Password, [Global]._Corporativo, [Global]._Sucursal)
        'Operaciones        
        'Reportes
        mniReportes.Enabled = OperacionBascula(4).Habilitada Or OperacionBascula(9).Habilitada
        btnReportes.Enabled = OperacionBascula(4).Habilitada Or OperacionBascula(9).Habilitada
        'Modificaciones
        mniModificacionCiclos.Enabled = OperacionBascula(2).Habilitada Or OperacionBascula(9).Habilitada Or OperacionBascula(10).Habilitada


        'mniEficiencia.Enabled = OperacionBascula(14).Habilitada Or OperacionBascula(9).Habilitada
        mniEficiencia.Visible = OperacionBascula(14).Habilitada Or OperacionBascula(9).Habilitada

        'mniMigrar.Enabled = OperacionBascula(15).Habilitada Or OperacionBascula(9).Habilitada
        mniMigrar.Visible = OperacionBascula(15).Habilitada Or OperacionBascula(9).Habilitada

        'Parámetros
        mniParametros.Enabled = OperacionBascula(6).Habilitada Or OperacionBascula(9).Habilitada
        btnParametro.Enabled = OperacionBascula(6).Habilitada Or OperacionBascula(9).Habilitada
        btnParametro.Visible = OperacionBascula(6).Habilitada Or OperacionBascula(9).Habilitada
        Sep1.Visible = OperacionBascula(6).Habilitada Or OperacionBascula(9).Habilitada
        'Catálogos
        mniCatalogos.Enabled = OperacionBascula(7).Habilitada Or OperacionBascula(9).Habilitada
        'Ciclos automáticos
        'mniCiclosAutomaticos.Enabled = Not _ExisteBascula Or OperacionBascula(11).Habilitada Or OperacionBascula(9).Habilitada
        mniCiclosAutomaticos.Enabled = OperacionBascula(11).Habilitada Or OperacionBascula(9).Habilitada
        'Autotanques
        mniAutotanque.Enabled = OperacionBascula(12).Habilitada

        'Barra de estado
        stsUsuario.Text = _Usuario
        stsNombre.Text = _Nombre
        stsArea.Text = _DesCelula
        stsFecha.Text = Now.ToShortDateString
        stsServidor.Text = _Servidor
        stsBaseDeDatos.Text = _Database
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
    Friend WithEvents mnuPrincipal As System.Windows.Forms.MainMenu
    Friend WithEvents imgPrincipal As System.Windows.Forms.ImageList
    Friend WithEvents mniBascula As System.Windows.Forms.MenuItem
    Friend WithEvents mniPesar As System.Windows.Forms.MenuItem
    Friend WithEvents mniAutotanqueGM As System.Windows.Forms.MenuItem
    Friend WithEvents mniHistoricoFactores As System.Windows.Forms.MenuItem
    Friend WithEvents mniSalir As System.Windows.Forms.MenuItem
    Friend WithEvents mniCatalogos As System.Windows.Forms.MenuItem
    Friend WithEvents mniOrigenDestino As System.Windows.Forms.MenuItem
    Friend WithEvents mniModificaciones As System.Windows.Forms.MenuItem
    Friend WithEvents mniParametros As System.Windows.Forms.MenuItem
    Friend WithEvents mniCiclosAutomaticos As System.Windows.Forms.MenuItem
    Friend WithEvents mnuAyuda As System.Windows.Forms.MenuItem
    Friend WithEvents Sepm2 As System.Windows.Forms.MenuItem
    Friend WithEvents Sepm3 As System.Windows.Forms.MenuItem
    Friend WithEvents mniHerramientas As System.Windows.Forms.MenuItem
    Friend WithEvents mniAcerca As System.Windows.Forms.MenuItem
    Friend WithEvents mniCatReportes As System.Windows.Forms.MenuItem
    Friend WithEvents mniReportes As System.Windows.Forms.MenuItem
    Friend WithEvents stbPrincipal As System.Windows.Forms.StatusBar
    Friend WithEvents stsUsuario As System.Windows.Forms.StatusBarPanel
    Friend WithEvents stsNombre As System.Windows.Forms.StatusBarPanel
    Friend WithEvents stsArea As System.Windows.Forms.StatusBarPanel
    Friend WithEvents stsFecha As System.Windows.Forms.StatusBarPanel
    Friend WithEvents stsServidor As System.Windows.Forms.StatusBarPanel
    Friend WithEvents stsBaseDeDatos As System.Windows.Forms.StatusBarPanel
    Friend WithEvents tbPrincipal As System.Windows.Forms.ToolBar
    Friend WithEvents btnAutotanque As System.Windows.Forms.ToolBarButton
    Friend WithEvents Sep0 As System.Windows.Forms.ToolBarButton
    Friend WithEvents btnReportes As System.Windows.Forms.ToolBarButton
    Friend WithEvents Sep1 As System.Windows.Forms.ToolBarButton
    Friend WithEvents btnParametro As System.Windows.Forms.ToolBarButton
    Friend WithEvents btnSalir As System.Windows.Forms.ToolBarButton
    Friend WithEvents Sep2 As System.Windows.Forms.ToolBarButton
    Friend WithEvents mniTransportadoras As System.Windows.Forms.MenuItem
    Friend WithEvents mniModificacionCiclos As System.Windows.Forms.MenuItem
    Friend WithEvents Sep3 As System.Windows.Forms.ToolBarButton
    Friend WithEvents btnClave As System.Windows.Forms.ToolBarButton
    Friend WithEvents mniClave As System.Windows.Forms.MenuItem
    Friend WithEvents mniAutotanque As System.Windows.Forms.MenuItem
    Friend WithEvents mniEficiencia As System.Windows.Forms.MenuItem
    Friend WithEvents mniMigrar As System.Windows.Forms.MenuItem
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPrincipal))
        Me.mnuPrincipal = New System.Windows.Forms.MainMenu(Me.components)
        Me.mniBascula = New System.Windows.Forms.MenuItem()
        Me.mniPesar = New System.Windows.Forms.MenuItem()
        Me.mniAutotanqueGM = New System.Windows.Forms.MenuItem()
        Me.Sepm2 = New System.Windows.Forms.MenuItem()
        Me.Sepm3 = New System.Windows.Forms.MenuItem()
        Me.mniSalir = New System.Windows.Forms.MenuItem()
        Me.mniCatalogos = New System.Windows.Forms.MenuItem()
        Me.mniHistoricoFactores = New System.Windows.Forms.MenuItem()
        Me.mniOrigenDestino = New System.Windows.Forms.MenuItem()
        Me.mniTransportadoras = New System.Windows.Forms.MenuItem()
        Me.mniAutotanque = New System.Windows.Forms.MenuItem()
        Me.mniModificaciones = New System.Windows.Forms.MenuItem()
        Me.mniModificacionCiclos = New System.Windows.Forms.MenuItem()
        Me.mniEficiencia = New System.Windows.Forms.MenuItem()
        Me.mniMigrar = New System.Windows.Forms.MenuItem()
        Me.mniHerramientas = New System.Windows.Forms.MenuItem()
        Me.mniCiclosAutomaticos = New System.Windows.Forms.MenuItem()
        Me.mniParametros = New System.Windows.Forms.MenuItem()
        Me.mniClave = New System.Windows.Forms.MenuItem()
        Me.mniCatReportes = New System.Windows.Forms.MenuItem()
        Me.mniReportes = New System.Windows.Forms.MenuItem()
        Me.mnuAyuda = New System.Windows.Forms.MenuItem()
        Me.mniAcerca = New System.Windows.Forms.MenuItem()
        Me.imgPrincipal = New System.Windows.Forms.ImageList(Me.components)
        Me.stbPrincipal = New System.Windows.Forms.StatusBar()
        Me.stsUsuario = New System.Windows.Forms.StatusBarPanel()
        Me.stsNombre = New System.Windows.Forms.StatusBarPanel()
        Me.stsArea = New System.Windows.Forms.StatusBarPanel()
        Me.stsFecha = New System.Windows.Forms.StatusBarPanel()
        Me.stsServidor = New System.Windows.Forms.StatusBarPanel()
        Me.stsBaseDeDatos = New System.Windows.Forms.StatusBarPanel()
        Me.tbPrincipal = New System.Windows.Forms.ToolBar()
        Me.btnAutotanque = New System.Windows.Forms.ToolBarButton()
        Me.Sep0 = New System.Windows.Forms.ToolBarButton()
        Me.btnReportes = New System.Windows.Forms.ToolBarButton()
        Me.Sep1 = New System.Windows.Forms.ToolBarButton()
        Me.btnParametro = New System.Windows.Forms.ToolBarButton()
        Me.Sep2 = New System.Windows.Forms.ToolBarButton()
        Me.btnClave = New System.Windows.Forms.ToolBarButton()
        Me.Sep3 = New System.Windows.Forms.ToolBarButton()
        Me.btnSalir = New System.Windows.Forms.ToolBarButton()
        CType(Me.stsUsuario, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.stsNombre, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.stsArea, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.stsFecha, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.stsServidor, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.stsBaseDeDatos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'mnuPrincipal
        '
        Me.mnuPrincipal.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mniBascula, Me.mniCatalogos, Me.mniModificaciones, Me.mniHerramientas, Me.mniCatReportes, Me.mnuAyuda})
        '
        'mniBascula
        '
        Me.mniBascula.Index = 0
        Me.mniBascula.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mniPesar, Me.Sepm3, Me.mniSalir})
        Me.mniBascula.MergeType = System.Windows.Forms.MenuMerge.MergeItems
        Me.mniBascula.Text = "&Báscula"
        '
        'mniPesar
        '
        Me.mniPesar.Index = 0
        Me.mniPesar.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mniAutotanqueGM, Me.Sepm2})
        Me.mniPesar.MergeType = System.Windows.Forms.MenuMerge.MergeItems
        Me.mniPesar.Shortcut = System.Windows.Forms.Shortcut.CtrlP
        Me.mniPesar.Text = "&Pesar"
        '
        'mniAutotanqueGM
        '
        Me.mniAutotanqueGM.Index = 0
        Me.mniAutotanqueGM.MergeType = System.Windows.Forms.MenuMerge.MergeItems
        Me.mniAutotanqueGM.Shortcut = System.Windows.Forms.Shortcut.CtrlA
        Me.mniAutotanqueGM.Text = "&Autotanques de la empresa"
        '
        'Sepm2
        '
        Me.Sepm2.Index = 1
        Me.Sepm2.Text = "-"
        '
        'Sepm3
        '
        Me.Sepm3.Index = 1
        Me.Sepm3.Text = "-"
        '
        'mniSalir
        '
        Me.mniSalir.Index = 2
        Me.mniSalir.MergeOrder = 1
        Me.mniSalir.MergeType = System.Windows.Forms.MenuMerge.MergeItems
        Me.mniSalir.Text = "Salir"
        '
        'mniCatalogos
        '
        Me.mniCatalogos.Index = 1
        Me.mniCatalogos.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mniHistoricoFactores, Me.mniOrigenDestino, Me.mniTransportadoras, Me.mniAutotanque})
        Me.mniCatalogos.MergeOrder = 1
        Me.mniCatalogos.MergeType = System.Windows.Forms.MenuMerge.MergeItems
        Me.mniCatalogos.Text = "&Catálogos"
        '
        'mniHistoricoFactores
        '
        Me.mniHistoricoFactores.Index = 0
        Me.mniHistoricoFactores.MergeType = System.Windows.Forms.MenuMerge.MergeItems
        Me.mniHistoricoFactores.Shortcut = System.Windows.Forms.Shortcut.CtrlF
        Me.mniHistoricoFactores.Text = "Histórico de &factores de densidad"
        '
        'mniOrigenDestino
        '
        Me.mniOrigenDestino.Index = 1
        Me.mniOrigenDestino.MergeOrder = 1
        Me.mniOrigenDestino.MergeType = System.Windows.Forms.MenuMerge.MergeItems
        Me.mniOrigenDestino.Text = "&Origen y destino del vehículo"
        '
        'mniTransportadoras
        '
        Me.mniTransportadoras.Index = 2
        Me.mniTransportadoras.MergeOrder = 2
        Me.mniTransportadoras.MergeType = System.Windows.Forms.MenuMerge.MergeItems
        Me.mniTransportadoras.Text = "&Transportadoras"
        '
        'mniAutotanque
        '
        Me.mniAutotanque.Index = 3
        Me.mniAutotanque.MergeOrder = 3
        Me.mniAutotanque.MergeType = System.Windows.Forms.MenuMerge.MergeItems
        Me.mniAutotanque.Text = "Au&totanque"
        '
        'mniModificaciones
        '
        Me.mniModificaciones.Index = 2
        Me.mniModificaciones.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mniModificacionCiclos, Me.mniEficiencia, Me.mniMigrar})
        Me.mniModificaciones.MergeOrder = 2
        Me.mniModificaciones.MergeType = System.Windows.Forms.MenuMerge.MergeItems
        Me.mniModificaciones.Text = "&Modificaciones"
        '
        'mniModificacionCiclos
        '
        Me.mniModificacionCiclos.Index = 0
        Me.mniModificacionCiclos.MergeType = System.Windows.Forms.MenuMerge.MergeItems
        Me.mniModificacionCiclos.Shortcut = System.Windows.Forms.Shortcut.CtrlM
        Me.mniModificacionCiclos.Text = "&Modificación de ciclos"
        '
        'mniEficiencia
        '
        Me.mniEficiencia.Index = 1
        Me.mniEficiencia.Shortcut = System.Windows.Forms.Shortcut.CtrlE
        Me.mniEficiencia.Text = "&Eficiencia"
        '
        'mniMigrar
        '
        Me.mniMigrar.Index = 2
        Me.mniMigrar.Shortcut = System.Windows.Forms.Shortcut.CtrlI
        Me.mniMigrar.Text = "&Importar llenados"
        '
        'mniHerramientas
        '
        Me.mniHerramientas.Index = 3
        Me.mniHerramientas.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mniCiclosAutomaticos, Me.mniParametros, Me.mniClave})
        Me.mniHerramientas.MergeOrder = 3
        Me.mniHerramientas.MergeType = System.Windows.Forms.MenuMerge.MergeItems
        Me.mniHerramientas.Text = "&Herramientas"
        '
        'mniCiclosAutomaticos
        '
        Me.mniCiclosAutomaticos.Index = 0
        Me.mniCiclosAutomaticos.MergeType = System.Windows.Forms.MenuMerge.MergeItems
        Me.mniCiclosAutomaticos.Text = "&Ciclos automáticos"
        '
        'mniParametros
        '
        Me.mniParametros.Index = 1
        Me.mniParametros.MergeOrder = 1
        Me.mniParametros.MergeType = System.Windows.Forms.MenuMerge.MergeItems
        Me.mniParametros.Shortcut = System.Windows.Forms.Shortcut.CtrlP
        Me.mniParametros.Text = "&Parametros"
        '
        'mniClave
        '
        Me.mniClave.Index = 2
        Me.mniClave.Text = "C&ambiar clave"
        '
        'mniCatReportes
        '
        Me.mniCatReportes.Index = 4
        Me.mniCatReportes.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mniReportes})
        Me.mniCatReportes.MergeOrder = 4
        Me.mniCatReportes.MergeType = System.Windows.Forms.MenuMerge.MergeItems
        Me.mniCatReportes.Text = "&Reportes"
        '
        'mniReportes
        '
        Me.mniReportes.Index = 0
        Me.mniReportes.Shortcut = System.Windows.Forms.Shortcut.CtrlR
        Me.mniReportes.Text = "&Reportes..."
        '
        'mnuAyuda
        '
        Me.mnuAyuda.Index = 5
        Me.mnuAyuda.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mniAcerca})
        Me.mnuAyuda.MergeOrder = 5
        Me.mnuAyuda.MergeType = System.Windows.Forms.MenuMerge.MergeItems
        Me.mnuAyuda.Text = "&?"
        '
        'mniAcerca
        '
        Me.mniAcerca.Index = 0
        Me.mniAcerca.MergeType = System.Windows.Forms.MenuMerge.MergeItems
        Me.mniAcerca.Shortcut = System.Windows.Forms.Shortcut.F1
        Me.mniAcerca.Text = "&Acerca de Báscula² y Bascula.dll"
        '
        'imgPrincipal
        '
        Me.imgPrincipal.ImageStream = CType(resources.GetObject("imgPrincipal.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imgPrincipal.TransparentColor = System.Drawing.Color.Transparent
        Me.imgPrincipal.Images.SetKeyName(0, "")
        Me.imgPrincipal.Images.SetKeyName(1, "")
        Me.imgPrincipal.Images.SetKeyName(2, "")
        Me.imgPrincipal.Images.SetKeyName(3, "")
        Me.imgPrincipal.Images.SetKeyName(4, "")
        Me.imgPrincipal.Images.SetKeyName(5, "")
        '
        'stbPrincipal
        '
        Me.stbPrincipal.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.stbPrincipal.Location = New System.Drawing.Point(0, 681)
        Me.stbPrincipal.Name = "stbPrincipal"
        Me.stbPrincipal.Panels.AddRange(New System.Windows.Forms.StatusBarPanel() {Me.stsUsuario, Me.stsNombre, Me.stsArea, Me.stsFecha, Me.stsServidor, Me.stsBaseDeDatos})
        Me.stbPrincipal.ShowPanels = True
        Me.stbPrincipal.Size = New System.Drawing.Size(1016, 24)
        Me.stbPrincipal.SizingGrip = False
        Me.stbPrincipal.TabIndex = 4
        '
        'stsUsuario
        '
        Me.stsUsuario.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Spring
        Me.stsUsuario.Name = "stsUsuario"
        Me.stsUsuario.Text = "Usuario"
        Me.stsUsuario.ToolTipText = "Login de Usuario"
        Me.stsUsuario.Width = 306
        '
        'stsNombre
        '
        Me.stsNombre.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.stsNombre.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Contents
        Me.stsNombre.Name = "stsNombre"
        Me.stsNombre.Text = "Nombre"
        Me.stsNombre.Width = 54
        '
        'stsArea
        '
        Me.stsArea.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.stsArea.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Spring
        Me.stsArea.Name = "stsArea"
        Me.stsArea.Text = "Área"
        Me.stsArea.Width = 306
        '
        'stsFecha
        '
        Me.stsFecha.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.stsFecha.Name = "stsFecha"
        Me.stsFecha.Text = "Fecha"
        '
        'stsServidor
        '
        Me.stsServidor.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.stsServidor.Icon = CType(resources.GetObject("stsServidor.Icon"), System.Drawing.Icon)
        Me.stsServidor.Name = "stsServidor"
        Me.stsServidor.Text = "Servidor"
        Me.stsServidor.ToolTipText = "Nombre del servidor"
        Me.stsServidor.Width = 150
        '
        'stsBaseDeDatos
        '
        Me.stsBaseDeDatos.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.stsBaseDeDatos.Name = "stsBaseDeDatos"
        Me.stsBaseDeDatos.Text = "Base"
        Me.stsBaseDeDatos.ToolTipText = "Nombre de la base de datos"
        '
        'tbPrincipal
        '
        Me.tbPrincipal.Appearance = System.Windows.Forms.ToolBarAppearance.Flat
        Me.tbPrincipal.Buttons.AddRange(New System.Windows.Forms.ToolBarButton() {Me.btnAutotanque, Me.Sep0, Me.btnReportes, Me.Sep1, Me.btnParametro, Me.Sep2, Me.btnClave, Me.Sep3, Me.btnSalir})
        Me.tbPrincipal.DropDownArrows = True
        Me.tbPrincipal.ImageList = Me.imgPrincipal
        Me.tbPrincipal.Location = New System.Drawing.Point(0, 0)
        Me.tbPrincipal.Name = "tbPrincipal"
        Me.tbPrincipal.ShowToolTips = True
        Me.tbPrincipal.Size = New System.Drawing.Size(1016, 42)
        Me.tbPrincipal.TabIndex = 6
        '
        'btnAutotanque
        '
        Me.btnAutotanque.ImageIndex = 0
        Me.btnAutotanque.Name = "btnAutotanque"
        Me.btnAutotanque.Text = "Autotánques"
        Me.btnAutotanque.ToolTipText = "Pesar autotanques de la empresa"
        '
        'Sep0
        '
        Me.Sep0.Name = "Sep0"
        Me.Sep0.Style = System.Windows.Forms.ToolBarButtonStyle.Separator
        '
        'btnReportes
        '
        Me.btnReportes.ImageIndex = 2
        Me.btnReportes.Name = "btnReportes"
        Me.btnReportes.Text = "Reportes"
        Me.btnReportes.ToolTipText = "Reportes de báscula"
        '
        'Sep1
        '
        Me.Sep1.Name = "Sep1"
        Me.Sep1.Style = System.Windows.Forms.ToolBarButtonStyle.Separator
        '
        'btnParametro
        '
        Me.btnParametro.ImageIndex = 3
        Me.btnParametro.Name = "btnParametro"
        Me.btnParametro.Text = "Parámetros"
        Me.btnParametro.ToolTipText = "Cambiar parametros de pesado y gas"
        '
        'Sep2
        '
        Me.Sep2.Name = "Sep2"
        Me.Sep2.Style = System.Windows.Forms.ToolBarButtonStyle.Separator
        '
        'btnClave
        '
        Me.btnClave.ImageIndex = 5
        Me.btnClave.Name = "btnClave"
        Me.btnClave.Text = "Cambiar clave"
        Me.btnClave.ToolTipText = "Modificar la contraseña del usuario"
        '
        'Sep3
        '
        Me.Sep3.Name = "Sep3"
        Me.Sep3.Style = System.Windows.Forms.ToolBarButtonStyle.Separator
        '
        'btnSalir
        '
        Me.btnSalir.ImageIndex = 4
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Text = "Salir"
        Me.btnSalir.ToolTipText = "Salir del módulo de Báscula"
        '
        'frmPrincipal
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 14)
        Me.BackColor = System.Drawing.Color.DarkSeaGreen
        Me.ClientSize = New System.Drawing.Size(1016, 705)
        Me.Controls.Add(Me.tbPrincipal)
        Me.Controls.Add(Me.stbPrincipal)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.IsMdiContainer = True
        Me.Menu = Me.mnuPrincipal
        Me.Name = "frmPrincipal"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.stsUsuario, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.stsNombre, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.stsArea, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.stsFecha, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.stsServidor, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.stsBaseDeDatos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

    Private Sub CargaFormulario(ByVal NombreFormulario As String)
        Dim frm As Form = Nothing
        Me.Cursor = Cursors.WaitCursor
        For Each frm In Me.MdiChildren
            If frm.Name = NombreFormulario Then
                frm.Focus()
                Me.Cursor = Cursors.Default
                Exit Sub
            End If
        Next
        Select Case NombreFormulario
            Case "frmAutotanques"
                frm = New frmAutotanques()
            Case "frmDestinos"
                frm = New frmDestinos()
            Case "frmTransportadoras"
                frm = New frmTransportadoras()
            Case "frmCiclosAutomaticos"
                frm = New frmCiclosAutomaticos()
            Case "frmModificacionCiclos"
                frm = New frmModificacionCiclos()
            Case "frmHistoricoFactoresDensidad"
                frm = New frmHistoricoFactoresDensidad()
            Case "frmParametros"
                frm = New frmParametros()
            Case "frmAutotanque"
                frm = New frmAutotanque()
            Case "frmMigrarDatos"
                frm = New frmMigrarDatos()
            Case "frmEficiencia"
                frm = New frmEficiencia()
            Case Else
                ErrMessage("Esta función no ha sido implementada.")
        End Select
        If Not frm Is Nothing Then
            frm.MdiParent = Me
            frm.Show()
        End If
        Me.Cursor = Cursors.Default
    End Sub


    Private Sub mniAutotanqueGM_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mniAutotanqueGM.Click
        CargaFormulario("frmAutotanques")
    End Sub
    Private Sub mniTrailer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        CargaFormulario("frmOperacionesTR")
    End Sub
    Private Sub mniOrigenDestino_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mniOrigenDestino.Click
        CargaFormulario("frmDestinos")
    End Sub
    Private Sub mniTransportadoras_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mniTransportadoras.Click
        CargaFormulario("frmTransportadoras")
    End Sub
    Private Sub mniAutotanqueOE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        CargaFormulario("frmAtOtrasEmpresas")
    End Sub
    Private Sub mniCiclosAutomaticos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mniCiclosAutomaticos.Click
        CargaFormulario("frmCiclosAutomaticos")
    End Sub
    Private Sub mniModificacionCiclos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mniModificacionCiclos.Click
        CargaFormulario("frmModificacionCiclos")
    End Sub
    Private Sub mniHistoricoFactores_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mniHistoricoFactores.Click
        CargaFormulario("frmHistoricoFactoresDensidad")
    End Sub
    Private Sub mniAcerca_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mniAcerca.Click
        Dim frmAcerca As New frmAcerca()
        frmAcerca.ShowDialog()
    End Sub


    Private Sub mniCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mniSalir.Click
        Me.Close()
    End Sub
    Private Sub frmPrincipal_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        Application.DoEvents()
        If Me.MdiChildren.Length > 0 Then
            Dim frmOpen As Form
            If MessageBox.Show("Existen ventanas abiertas. " & Chr(13) & "¿Desea continuar cerrando el módulo?", Application.ProductName & " versión " & Application.ProductVersion, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.No Then
                e.Cancel = True
                Exit Sub
            End If
            For Each frmOpen In Me.MdiChildren
                frmOpen.Close()
            Next
            If Me.MdiChildren.Length > 0 Then
                e.Cancel = True
            Else
                Application.Exit()
            End If
        Else
            Application.Exit()
        End If
    End Sub

    Private Sub CargaReportes()        
        Cursor = Cursors.WaitCursor
        Dim oReportes As New ReporteDinamico.frmListaReporte(5, _RutaReportes, _Servidor, _Database, Globales.GetInstance._Usuario, Globales.GetInstance.cnSigamet, Globales.GetInstance._Corporativo, Globales.GetInstance._Sucursal, [Global]._SeguridadReportes)
        oReportes.MdiParent = Me
        oReportes.WindowState = FormWindowState.Maximized        
        oReportes.Show()
        Cursor = Cursors.Default
    End Sub
    Private Sub mnuReportes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mniCatReportes.Click
        CargaReportes()
    End Sub

    Private Sub mnuParametros_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mniParametros.Click
        CargaFormulario("frmParametros")
    End Sub

    Private Sub tbPrincipal_ButtonClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolBarButtonClickEventArgs) Handles tbPrincipal.ButtonClick
        Select Case e.Button.Text
            Case "Autotánques"
                CargaFormulario("frmAutotanques")
            Case "Reportes"
                CargaReportes()
            Case "Parámetros"
                CargaFormulario("frmParametros")
            Case "Cambiar clave"
                CambiarClave()
            Case "Salir"
                Me.Close()
            Case Else
                ErrMessage("Esta función no ha sido implementada.")
        End Select
    End Sub


    Private Sub mniReportes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mniReportes.Click
        CargaReportes()
    End Sub

    Private Sub CambiarClave()
        Dim frmCambioClave As New Bascula.frmCambioClave(Globales.GetInstance._Usuario)
        frmCambioClave.ShowDialog()
    End Sub

    Private Sub mniClave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mniClave.Click
        CambiarClave()
    End Sub

    Private Sub mniAutotanques_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mniAutotanque.Click
        CargaFormulario("frmAutotanque")
    End Sub

    Private Sub mniEficiencia_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mniEficiencia.Click
        CargaFormulario("frmEficiencia")
    End Sub

    Private Sub mniMigrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mniMigrar.Click
        CargaFormulario("frmMigrarDatos")
    End Sub

    Private Sub frmPrincipal_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class
