Public Class frmDestinos
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
    Friend WithEvents imgDestinos As System.Windows.Forms.ImageList
    Friend WithEvents mnuDestinos As System.Windows.Forms.MainMenu
    Friend WithEvents mniCatalogos As System.Windows.Forms.MenuItem
    Friend WithEvents mniDestinos As System.Windows.Forms.MenuItem
    Friend WithEvents mniAgregar As System.Windows.Forms.MenuItem
    Friend WithEvents mniModificar As System.Windows.Forms.MenuItem
    Friend WithEvents Sepm0 As System.Windows.Forms.MenuItem
    Friend WithEvents mniActualizar As System.Windows.Forms.MenuItem
    Friend WithEvents mniBuscar As System.Windows.Forms.MenuItem
    Friend WithEvents Sepm1 As System.Windows.Forms.MenuItem
    Friend WithEvents mniCerrar As System.Windows.Forms.MenuItem
    Friend WithEvents tbDestinos As System.Windows.Forms.ToolBar
    Friend WithEvents btnAgregar As System.Windows.Forms.ToolBarButton
    Friend WithEvents btnModificar As System.Windows.Forms.ToolBarButton
    Friend WithEvents Sep0 As System.Windows.Forms.ToolBarButton
    Friend WithEvents btnBuscar As System.Windows.Forms.ToolBarButton
    Friend WithEvents btnActualizar As System.Windows.Forms.ToolBarButton
    Friend WithEvents Sep1 As System.Windows.Forms.ToolBarButton
    Friend WithEvents btnCerrar As System.Windows.Forms.ToolBarButton
    Friend WithEvents vgDestino As Bascula.ViewGrid
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmDestinos))
        Me.imgDestinos = New System.Windows.Forms.ImageList(Me.components)
        Me.mnuDestinos = New System.Windows.Forms.MainMenu()
        Me.mniCatalogos = New System.Windows.Forms.MenuItem()
        Me.mniDestinos = New System.Windows.Forms.MenuItem()
        Me.mniAgregar = New System.Windows.Forms.MenuItem()
        Me.mniModificar = New System.Windows.Forms.MenuItem()
        Me.Sepm0 = New System.Windows.Forms.MenuItem()
        Me.mniActualizar = New System.Windows.Forms.MenuItem()
        Me.mniBuscar = New System.Windows.Forms.MenuItem()
        Me.Sepm1 = New System.Windows.Forms.MenuItem()
        Me.mniCerrar = New System.Windows.Forms.MenuItem()
        Me.tbDestinos = New System.Windows.Forms.ToolBar()
        Me.btnAgregar = New System.Windows.Forms.ToolBarButton()
        Me.btnModificar = New System.Windows.Forms.ToolBarButton()
        Me.Sep0 = New System.Windows.Forms.ToolBarButton()
        Me.btnBuscar = New System.Windows.Forms.ToolBarButton()
        Me.btnActualizar = New System.Windows.Forms.ToolBarButton()
        Me.Sep1 = New System.Windows.Forms.ToolBarButton()
        Me.btnCerrar = New System.Windows.Forms.ToolBarButton()
        Me.vgDestino = New Bascula.ViewGrid()
        Me.SuspendLayout()
        '
        'imgDestinos
        '
        Me.imgDestinos.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit
        Me.imgDestinos.ImageSize = New System.Drawing.Size(16, 16)
        Me.imgDestinos.ImageStream = CType(resources.GetObject("imgDestinos.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imgDestinos.TransparentColor = System.Drawing.Color.Transparent
        '
        'mnuDestinos
        '
        Me.mnuDestinos.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mniCatalogos})
        '
        'mniCatalogos
        '
        Me.mniCatalogos.Index = 0
        Me.mniCatalogos.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mniDestinos})
        Me.mniCatalogos.MergeOrder = 1
        Me.mniCatalogos.MergeType = System.Windows.Forms.MenuMerge.MergeItems
        Me.mniCatalogos.Text = "&Catálogos"
        '
        'mniDestinos
        '
        Me.mniDestinos.Index = 0
        Me.mniDestinos.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mniAgregar, Me.mniModificar, Me.Sepm0, Me.mniActualizar, Me.mniBuscar, Me.Sepm1, Me.mniCerrar})
        Me.mniDestinos.MergeOrder = 1
        Me.mniDestinos.MergeType = System.Windows.Forms.MenuMerge.MergeItems
        Me.mniDestinos.Text = "&Origen y destino del vehículo"
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
        'mniActualizar
        '
        Me.mniActualizar.Index = 3
        Me.mniActualizar.Shortcut = System.Windows.Forms.Shortcut.F5
        Me.mniActualizar.Text = "Ac&tualizar"
        '
        'mniBuscar
        '
        Me.mniBuscar.Index = 4
        Me.mniBuscar.Shortcut = System.Windows.Forms.Shortcut.CtrlB
        Me.mniBuscar.Text = "&Buscar"
        '
        'Sepm1
        '
        Me.Sepm1.Index = 5
        Me.Sepm1.Text = "-"
        '
        'mniCerrar
        '
        Me.mniCerrar.Index = 6
        Me.mniCerrar.Text = "Cerrar"
        '
        'tbDestinos
        '
        Me.tbDestinos.Appearance = System.Windows.Forms.ToolBarAppearance.Flat
        Me.tbDestinos.Buttons.AddRange(New System.Windows.Forms.ToolBarButton() {Me.btnAgregar, Me.btnModificar, Me.Sep0, Me.btnBuscar, Me.btnActualizar, Me.Sep1, Me.btnCerrar})
        Me.tbDestinos.DropDownArrows = True
        Me.tbDestinos.ImageList = Me.imgDestinos
        Me.tbDestinos.Name = "tbDestinos"
        Me.tbDestinos.ShowToolTips = True
        Me.tbDestinos.Size = New System.Drawing.Size(784, 39)
        Me.tbDestinos.TabIndex = 0
        '
        'btnAgregar
        '
        Me.btnAgregar.ImageIndex = 0
        Me.btnAgregar.Text = "Agregar"
        Me.btnAgregar.ToolTipText = "Agregar un nuevo destino"
        '
        'btnModificar
        '
        Me.btnModificar.ImageIndex = 1
        Me.btnModificar.Text = "Modificar"
        Me.btnModificar.ToolTipText = "Modificar el destino seleccionado"
        '
        'Sep0
        '
        Me.Sep0.Style = System.Windows.Forms.ToolBarButtonStyle.Separator
        '
        'btnBuscar
        '
        Me.btnBuscar.ImageIndex = 3
        Me.btnBuscar.Text = "Buscar"
        Me.btnBuscar.ToolTipText = "Localizar destino"
        '
        'btnActualizar
        '
        Me.btnActualizar.ImageIndex = 2
        Me.btnActualizar.Text = "Actualizar"
        Me.btnActualizar.ToolTipText = "Cargar los datos más recientes"
        '
        'Sep1
        '
        Me.Sep1.Style = System.Windows.Forms.ToolBarButtonStyle.Separator
        '
        'btnCerrar
        '
        Me.btnCerrar.ImageIndex = 4
        Me.btnCerrar.Text = "Cerrar"
        Me.btnCerrar.ToolTipText = "Cerrar el catálogo de destinos"
        '
        'vgDestino
        '
        Me.vgDestino.AlternativeBackColor = System.Drawing.Color.Gainsboro
        Me.vgDestino.CheckCondition = Nothing
        Me.vgDestino.DataSource = Nothing
        Me.vgDestino.Dock = System.Windows.Forms.DockStyle.Fill
        Me.vgDestino.FormatColumnNames = New String() {Nothing}
        Me.vgDestino.FullRowSelect = True
        Me.vgDestino.GridLines = True
        Me.vgDestino.HidedColumnNames = New String() {Nothing}
        Me.vgDestino.Location = New System.Drawing.Point(0, 39)
        Me.vgDestino.Name = "vgDestino"
        Me.vgDestino.PKColumnNames = Nothing
        Me.vgDestino.Size = New System.Drawing.Size(784, 598)
        Me.vgDestino.TabIndex = 1
        Me.vgDestino.View = System.Windows.Forms.View.Details
        '
        'frmDestinos
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 14)
        Me.BackColor = System.Drawing.Color.Gainsboro
        Me.ClientSize = New System.Drawing.Size(784, 637)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.vgDestino, Me.tbDestinos})
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Menu = Me.mnuDestinos
        Me.MinimizeBox = False
        Me.Name = "frmDestinos"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Origen y destino de vehiculos"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Manejo de datos"
    Private Sub Actualizar()
        Dim cmdBascula As New SqlCommand("Select * from vwBASDestinoTransporte", Globales.GetInstance.cnSigamet)
        Dim daBascula As New SqlDataAdapter(cmdBascula)
        Dim dtDestino As New DataTable()
        Try
            daBascula.Fill(dtDestino)
            vgDestino.DataSource = dtDestino
        Catch ex As Exception
            Globales.GetInstance.ExMessage(ex)
        End Try
    End Sub
    Private Sub Buscar()
        Dim Destino As String = InputBox("Destino:", Application.ProductName & " v." & Application.ProductVersion)
        If vgDestino.FindSimilar("Destino", Destino.Trim, True) < 0 Then
            Globales.GetInstance.ErrMessage("No se encontro el registro.")
        End If
    End Sub
    Private Sub Agregar()
        Dim frmCapturaDestino As New frmCapturaDestino()
        If frmCapturaDestino.ShowDialog = DialogResult.OK Then
            Actualizar()
            vgDestino.FindFirst("IDDestinoTransporte", frmCapturaDestino.Destino)
            frmCapturaDestino.Dispose()
        End If
    End Sub
    Private Sub Modificar()
        If Not vgDestino.CurrentRow Is Nothing Then
            Dim frmCapturaDestino As New frmCapturaDestino(CInt(vgDestino.CurrentRow("IDDestinoTransporte")), CStr(vgDestino.CurrentRow("Destino")).Trim)
            If frmCapturaDestino.ShowDialog = DialogResult.OK Then
                Actualizar()
                vgDestino.FindFirst("IDDestinoTransporte", frmCapturaDestino.Destino)
                frmCapturaDestino.Dispose()
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
    Private Sub tbDestinos_ButtonClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolBarButtonClickEventArgs) Handles tbDestinos.ButtonClick
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
