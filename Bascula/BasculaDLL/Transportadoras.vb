Option Strict On
Option Explicit On 


Imports System.Data.SqlClient
Imports System.Drawing.Color


Public Class frmTransportadoras
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
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
    Friend WithEvents mniCatalogos As System.Windows.Forms.MenuItem
    Friend WithEvents mniAgregar As System.Windows.Forms.MenuItem
    Friend WithEvents mniModificar As System.Windows.Forms.MenuItem
    Friend WithEvents Sepm0 As System.Windows.Forms.MenuItem
    Friend WithEvents mniBuscar As System.Windows.Forms.MenuItem
    Friend WithEvents mniActualizar As System.Windows.Forms.MenuItem
    Friend WithEvents Sepm1 As System.Windows.Forms.MenuItem
    Friend WithEvents mniCerrar As System.Windows.Forms.MenuItem
    Friend WithEvents btnAgregar As System.Windows.Forms.ToolBarButton
    Friend WithEvents btnModificar As System.Windows.Forms.ToolBarButton
    Friend WithEvents Sep0 As System.Windows.Forms.ToolBarButton
    Friend WithEvents btnBuscar As System.Windows.Forms.ToolBarButton
    Friend WithEvents btnActualizar As System.Windows.Forms.ToolBarButton
    Friend WithEvents Sep1 As System.Windows.Forms.ToolBarButton
    Friend WithEvents btnCerrar As System.Windows.Forms.ToolBarButton
    Friend WithEvents imgTransportadoras As System.Windows.Forms.ImageList
    Friend WithEvents mnuTransportadoras As System.Windows.Forms.MainMenu
    Friend WithEvents mniTransportadoras As System.Windows.Forms.MenuItem
    Friend WithEvents tbTransportadoras As System.Windows.Forms.ToolBar
    Friend WithEvents vgTransportadora As Bascula.ViewGrid
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmTransportadoras))
        Me.imgTransportadoras = New System.Windows.Forms.ImageList(Me.components)
        Me.mnuTransportadoras = New System.Windows.Forms.MainMenu()
        Me.mniCatalogos = New System.Windows.Forms.MenuItem()
        Me.mniTransportadoras = New System.Windows.Forms.MenuItem()
        Me.mniAgregar = New System.Windows.Forms.MenuItem()
        Me.mniModificar = New System.Windows.Forms.MenuItem()
        Me.Sepm0 = New System.Windows.Forms.MenuItem()
        Me.mniBuscar = New System.Windows.Forms.MenuItem()
        Me.mniActualizar = New System.Windows.Forms.MenuItem()
        Me.Sepm1 = New System.Windows.Forms.MenuItem()
        Me.mniCerrar = New System.Windows.Forms.MenuItem()
        Me.tbTransportadoras = New System.Windows.Forms.ToolBar()
        Me.btnAgregar = New System.Windows.Forms.ToolBarButton()
        Me.btnModificar = New System.Windows.Forms.ToolBarButton()
        Me.Sep0 = New System.Windows.Forms.ToolBarButton()
        Me.btnBuscar = New System.Windows.Forms.ToolBarButton()
        Me.btnActualizar = New System.Windows.Forms.ToolBarButton()
        Me.Sep1 = New System.Windows.Forms.ToolBarButton()
        Me.btnCerrar = New System.Windows.Forms.ToolBarButton()
        Me.vgTransportadora = New Bascula.ViewGrid()
        Me.SuspendLayout()
        '
        'imgTransportadoras
        '
        Me.imgTransportadoras.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit
        Me.imgTransportadoras.ImageSize = New System.Drawing.Size(16, 16)
        Me.imgTransportadoras.ImageStream = CType(resources.GetObject("imgTransportadoras.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imgTransportadoras.TransparentColor = System.Drawing.Color.Transparent
        '
        'mnuTransportadoras
        '
        Me.mnuTransportadoras.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mniCatalogos})
        '
        'mniCatalogos
        '
        Me.mniCatalogos.Index = 0
        Me.mniCatalogos.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mniTransportadoras})
        Me.mniCatalogos.MergeOrder = 1
        Me.mniCatalogos.MergeType = System.Windows.Forms.MenuMerge.MergeItems
        Me.mniCatalogos.Text = "&Catálogos"
        '
        'mniTransportadoras
        '
        Me.mniTransportadoras.Index = 0
        Me.mniTransportadoras.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mniAgregar, Me.mniModificar, Me.Sepm0, Me.mniBuscar, Me.mniActualizar, Me.Sepm1, Me.mniCerrar})
        Me.mniTransportadoras.MergeOrder = 2
        Me.mniTransportadoras.MergeType = System.Windows.Forms.MenuMerge.MergeItems
        Me.mniTransportadoras.Text = "&Transportadoras"
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
        'Sepm0
        '
        Me.Sepm0.Index = 2
        Me.Sepm0.Text = "-"
        '
        'mniBuscar
        '
        Me.mniBuscar.Index = 3
        Me.mniBuscar.Shortcut = System.Windows.Forms.Shortcut.CtrlB
        Me.mniBuscar.Text = "&Buscar"
        '
        'mniActualizar
        '
        Me.mniActualizar.Index = 4
        Me.mniActualizar.Shortcut = System.Windows.Forms.Shortcut.F5
        Me.mniActualizar.Text = "Ac&tualizar"
        '
        'Sepm1
        '
        Me.Sepm1.Index = 5
        Me.Sepm1.Text = "-"
        '
        'mniCerrar
        '
        Me.mniCerrar.Index = 6
        Me.mniCerrar.Text = "&Cerrar"
        '
        'tbTransportadoras
        '
        Me.tbTransportadoras.Appearance = System.Windows.Forms.ToolBarAppearance.Flat
        Me.tbTransportadoras.Buttons.AddRange(New System.Windows.Forms.ToolBarButton() {Me.btnAgregar, Me.btnModificar, Me.Sep0, Me.btnBuscar, Me.btnActualizar, Me.Sep1, Me.btnCerrar})
        Me.tbTransportadoras.DropDownArrows = True
        Me.tbTransportadoras.ImageList = Me.imgTransportadoras
        Me.tbTransportadoras.Name = "tbTransportadoras"
        Me.tbTransportadoras.ShowToolTips = True
        Me.tbTransportadoras.Size = New System.Drawing.Size(616, 39)
        Me.tbTransportadoras.TabIndex = 0
        '
        'btnAgregar
        '
        Me.btnAgregar.ImageIndex = 0
        Me.btnAgregar.Text = "Agregar"
        Me.btnAgregar.ToolTipText = "Agregar nueva transportadora"
        '
        'btnModificar
        '
        Me.btnModificar.ImageIndex = 1
        Me.btnModificar.Text = "Modificar"
        Me.btnModificar.ToolTipText = "Modificar los datos de la transportadora seleccionada"
        '
        'Sep0
        '
        Me.Sep0.Style = System.Windows.Forms.ToolBarButtonStyle.Separator
        '
        'btnBuscar
        '
        Me.btnBuscar.ImageIndex = 2
        Me.btnBuscar.Text = "Buscar"
        Me.btnBuscar.ToolTipText = "Buscar transportadora"
        '
        'btnActualizar
        '
        Me.btnActualizar.ImageIndex = 3
        Me.btnActualizar.Text = "Actualizar"
        Me.btnActualizar.ToolTipText = "Cargar los datos mas recientes"
        '
        'Sep1
        '
        Me.Sep1.Style = System.Windows.Forms.ToolBarButtonStyle.Separator
        '
        'btnCerrar
        '
        Me.btnCerrar.ImageIndex = 4
        Me.btnCerrar.Text = "Cerrar"
        Me.btnCerrar.ToolTipText = "Cerrar el catálogo de transportadoras"
        '
        'vgTransportadora
        '
        Me.vgTransportadora.AlternativeBackColor = System.Drawing.Color.Gainsboro
        Me.vgTransportadora.CheckCondition = Nothing
        Me.vgTransportadora.DataSource = Nothing
        Me.vgTransportadora.Dock = System.Windows.Forms.DockStyle.Fill
        Me.vgTransportadora.FormatColumnNames = New String() {Nothing}
        Me.vgTransportadora.FullRowSelect = True
        Me.vgTransportadora.GridLines = True
        Me.vgTransportadora.HidedColumnNames = New String() {Nothing}
        Me.vgTransportadora.HideSelection = False
        Me.vgTransportadora.Location = New System.Drawing.Point(0, 39)
        Me.vgTransportadora.MultiSelect = False
        Me.vgTransportadora.Name = "vgTransportadora"
        Me.vgTransportadora.PKColumnNames = Nothing
        Me.vgTransportadora.Size = New System.Drawing.Size(616, 506)
        Me.vgTransportadora.TabIndex = 1
        Me.vgTransportadora.View = System.Windows.Forms.View.Details
        '
        'frmTransportadoras
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 14)
        Me.BackColor = System.Drawing.Color.Gainsboro
        Me.ClientSize = New System.Drawing.Size(616, 545)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.vgTransportadora, Me.tbTransportadoras})
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Menu = Me.mnuTransportadoras
        Me.MinimizeBox = False
        Me.Name = "frmTransportadoras"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Catálogo de transportadoras"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ResumeLayout(False)

    End Sub

#End Region


#Region "Manejo de datos"
    Private Sub Actualizar()
        Dim cmdBascula As New SqlCommand("Select * from vwBASTransportadora", Globales.GetInstance.cnSigamet)
        Dim daBascula As New SqlDataAdapter(cmdBascula)
        Dim dtTransportadora As New DataTable()
        Try
            daBascula.Fill(dtTransportadora)
            vgTransportadora.DataSource = dtTransportadora
        Catch ex As Exception
            Globales.GetInstance.ExMessage(ex)
        End Try
    End Sub
    Private Sub Buscar()
        Dim Transportadora As String = InputBox("Transportadora:", Application.ProductName & " v." & Application.ProductVersion)
        If vgTransportadora.FindSimilar("Transportadora", Transportadora.Trim, True) < 0 Then
            Globales.GetInstance.ErrMessage("No se encontro el registro.")
        End If
    End Sub
    Private Sub Agregar()
        Dim frmCapturaTransportadora As New frmCapturaTransportadora()
        If frmCapturaTransportadora.ShowDialog = DialogResult.OK Then
            Actualizar()
            vgTransportadora.FindFirst("IDTransportadora", frmCapturaTransportadora.Transportadora)
            frmCapturaTransportadora.Dispose()
        End If
    End Sub
    Private Sub Modificar()
        If Not vgTransportadora.CurrentRow Is Nothing Then
            Dim frmCapturaTransportadora As New frmCapturaTransportadora(CInt(vgTransportadora.CurrentRow("IDTransportadora")), CStr(vgTransportadora.CurrentRow("Transportadora")).Trim)
            If frmCapturaTransportadora.ShowDialog = DialogResult.OK Then
                Actualizar()
                vgTransportadora.FindFirst("IDTransportadora", frmCapturaTransportadora.Transportadora)
                frmCapturaTransportadora.Dispose()
            End If
        End If
    End Sub
#End Region
#Region "Menus y barra de herramientas"
    Private Sub mniAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mniAgregar.Click
        Agregar()
    End Sub
    Private Sub mniModificar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mniModificar.Click
        Modificar()
    End Sub
    Private Sub mniActualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mniActualizar.Click
        Actualizar()
    End Sub
    Private Sub mniBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mniBuscar.Click
        Buscar()
    End Sub
    Private Sub mniCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mniCerrar.Click
        Me.Close()
        Me.Dispose()
    End Sub
    Private Sub tbTransportadoras_ButtonClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolBarButtonClickEventArgs) Handles tbTransportadoras.ButtonClick
        Select Case e.Button.Text
            Case "Agregar"
                Agregar()
            Case "Modificar"
                Modificar()
            Case "Buscar"
                Buscar()
            Case "Actualizar"
                Actualizar()
            Case "Cerrar"
                Me.Close()
                Me.Dispose()
        End Select
    End Sub
#End Region
End Class

