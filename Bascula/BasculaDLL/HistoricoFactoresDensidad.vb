Public Class frmHistoricoFactoresDensidad
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
    Friend WithEvents cmdNuevo As System.Windows.Forms.Button
    Friend WithEvents imgHistorico As System.Windows.Forms.ImageList
    Friend WithEvents tbHistorico As System.Windows.Forms.ToolBar
    Friend WithEvents btnBuscar As System.Windows.Forms.ToolBarButton
    Friend WithEvents Sep0 As System.Windows.Forms.ToolBarButton
    Friend WithEvents btnCerrar As System.Windows.Forms.ToolBarButton
    Friend WithEvents pnlTitulo As System.Windows.Forms.Panel
    Friend WithEvents rlblTitulo As Bascula.RotatableLabel
    Friend WithEvents vgHistorico As Bascula.ViewGrid
    Friend WithEvents btnActualizar As System.Windows.Forms.ToolBarButton
    Friend WithEvents mnuHistoricoFactor As System.Windows.Forms.MainMenu
    Friend WithEvents mniCatalogos As System.Windows.Forms.MenuItem
    Friend WithEvents mniHistoricoFactor As System.Windows.Forms.MenuItem
    Friend WithEvents mniActualizar As System.Windows.Forms.MenuItem
    Friend WithEvents mniBuscar As System.Windows.Forms.MenuItem
    Friend WithEvents Sepm0 As System.Windows.Forms.MenuItem
    Friend WithEvents mniCerrar As System.Windows.Forms.MenuItem
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmHistoricoFactoresDensidad))
        Me.imgHistorico = New System.Windows.Forms.ImageList(Me.components)
        Me.cmdNuevo = New System.Windows.Forms.Button()
        Me.tbHistorico = New System.Windows.Forms.ToolBar()
        Me.btnActualizar = New System.Windows.Forms.ToolBarButton()
        Me.btnBuscar = New System.Windows.Forms.ToolBarButton()
        Me.Sep0 = New System.Windows.Forms.ToolBarButton()
        Me.btnCerrar = New System.Windows.Forms.ToolBarButton()
        Me.pnlTitulo = New System.Windows.Forms.Panel()
        Me.rlblTitulo = New Bascula.RotatableLabel()
        Me.vgHistorico = New Bascula.ViewGrid()
        Me.mnuHistoricoFactor = New System.Windows.Forms.MainMenu()
        Me.mniCatalogos = New System.Windows.Forms.MenuItem()
        Me.mniHistoricoFactor = New System.Windows.Forms.MenuItem()
        Me.mniActualizar = New System.Windows.Forms.MenuItem()
        Me.mniBuscar = New System.Windows.Forms.MenuItem()
        Me.Sepm0 = New System.Windows.Forms.MenuItem()
        Me.mniCerrar = New System.Windows.Forms.MenuItem()
        Me.pnlTitulo.SuspendLayout()
        Me.SuspendLayout()
        '
        'imgHistorico
        '
        Me.imgHistorico.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit
        Me.imgHistorico.ImageSize = New System.Drawing.Size(16, 16)
        Me.imgHistorico.ImageStream = CType(resources.GetObject("imgHistorico.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imgHistorico.TransparentColor = System.Drawing.Color.Transparent
        '
        'cmdNuevo
        '
        Me.cmdNuevo.Enabled = False
        Me.cmdNuevo.Location = New System.Drawing.Point(976, 288)
        Me.cmdNuevo.Name = "cmdNuevo"
        Me.cmdNuevo.Size = New System.Drawing.Size(16, 8)
        Me.cmdNuevo.TabIndex = 44
        Me.cmdNuevo.Text = "Nuevo"
        Me.cmdNuevo.Visible = False
        '
        'tbHistorico
        '
        Me.tbHistorico.Appearance = System.Windows.Forms.ToolBarAppearance.Flat
        Me.tbHistorico.Buttons.AddRange(New System.Windows.Forms.ToolBarButton() {Me.btnActualizar, Me.btnBuscar, Me.Sep0, Me.btnCerrar})
        Me.tbHistorico.DropDownArrows = True
        Me.tbHistorico.ImageList = Me.imgHistorico
        Me.tbHistorico.Name = "tbHistorico"
        Me.tbHistorico.ShowToolTips = True
        Me.tbHistorico.Size = New System.Drawing.Size(726, 39)
        Me.tbHistorico.TabIndex = 45
        '
        'btnActualizar
        '
        Me.btnActualizar.ImageIndex = 2
        Me.btnActualizar.Text = "Actualizar"
        Me.btnActualizar.ToolTipText = "Cargar la información más reciente"
        '
        'btnBuscar
        '
        Me.btnBuscar.ImageIndex = 0
        Me.btnBuscar.Text = "Buscar"
        Me.btnBuscar.ToolTipText = "Localizar registro"
        '
        'Sep0
        '
        Me.Sep0.Style = System.Windows.Forms.ToolBarButtonStyle.Separator
        '
        'btnCerrar
        '
        Me.btnCerrar.ImageIndex = 1
        Me.btnCerrar.Text = "Cerrar"
        Me.btnCerrar.ToolTipText = "Cerrar el histórico de factores de densidad"
        '
        'pnlTitulo
        '
        Me.pnlTitulo.Controls.AddRange(New System.Windows.Forms.Control() {Me.rlblTitulo})
        Me.pnlTitulo.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlTitulo.Location = New System.Drawing.Point(0, 39)
        Me.pnlTitulo.Name = "pnlTitulo"
        Me.pnlTitulo.Size = New System.Drawing.Size(24, 532)
        Me.pnlTitulo.TabIndex = 46
        '
        'rlblTitulo
        '
        Me.rlblTitulo.Border = False
        Me.rlblTitulo.Caption = "Historico de factores de densidad"
        Me.rlblTitulo.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.rlblTitulo.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rlblTitulo.ForeColor = System.Drawing.Color.DarkBlue
        Me.rlblTitulo.Location = New System.Drawing.Point(0, 230)
        Me.rlblTitulo.Name = "rlblTitulo"
        Me.rlblTitulo.RotationAngle = 270
        Me.rlblTitulo.Size = New System.Drawing.Size(21, 302)
        Me.rlblTitulo.TabIndex = 0
        '
        'vgHistorico
        '
        Me.vgHistorico.AlternativeBackColor = System.Drawing.Color.Gainsboro
        Me.vgHistorico.CheckCondition = Nothing
        Me.vgHistorico.DataSource = Nothing
        Me.vgHistorico.Dock = System.Windows.Forms.DockStyle.Fill
        Me.vgHistorico.FormatColumnNames = New String(-1) {}
        Me.vgHistorico.FullRowSelect = True
        Me.vgHistorico.GridLines = True
        Me.vgHistorico.HidedColumnNames = New String(-1) {}
        Me.vgHistorico.HideSelection = False
        Me.vgHistorico.Location = New System.Drawing.Point(24, 39)
        Me.vgHistorico.MultiSelect = False
        Me.vgHistorico.Name = "vgHistorico"
        Me.vgHistorico.PKColumnNames = Nothing
        Me.vgHistorico.Size = New System.Drawing.Size(702, 532)
        Me.vgHistorico.TabIndex = 47
        Me.vgHistorico.View = System.Windows.Forms.View.Details
        '
        'mnuHistoricoFactor
        '
        Me.mnuHistoricoFactor.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mniCatalogos})
        '
        'mniCatalogos
        '
        Me.mniCatalogos.Index = 0
        Me.mniCatalogos.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mniHistoricoFactor})
        Me.mniCatalogos.MergeOrder = 1
        Me.mniCatalogos.MergeType = System.Windows.Forms.MenuMerge.MergeItems
        Me.mniCatalogos.Text = "&Catálogos"
        '
        'mniHistoricoFactor
        '
        Me.mniHistoricoFactor.Index = 0
        Me.mniHistoricoFactor.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mniActualizar, Me.mniBuscar, Me.Sepm0, Me.mniCerrar})
        Me.mniHistoricoFactor.MergeType = System.Windows.Forms.MenuMerge.MergeItems
        Me.mniHistoricoFactor.Text = "Histórico de &factores de fensidad"
        '
        'mniActualizar
        '
        Me.mniActualizar.Index = 0
        Me.mniActualizar.Shortcut = System.Windows.Forms.Shortcut.F5
        Me.mniActualizar.Text = "&Actualizar"
        '
        'mniBuscar
        '
        Me.mniBuscar.Index = 1
        Me.mniBuscar.Shortcut = System.Windows.Forms.Shortcut.CtrlB
        Me.mniBuscar.Text = "&Buscar"
        '
        'Sepm0
        '
        Me.Sepm0.Index = 2
        Me.Sepm0.Text = "-"
        '
        'mniCerrar
        '
        Me.mniCerrar.Index = 3
        Me.mniCerrar.Text = "&Cerrar"
        '
        'frmHistoricoFactoresDensidad
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 14)
        Me.BackColor = System.Drawing.Color.Gainsboro
        Me.ClientSize = New System.Drawing.Size(726, 571)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.vgHistorico, Me.pnlTitulo, Me.tbHistorico, Me.cmdNuevo})
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Menu = Me.mnuHistoricoFactor
        Me.MinimizeBox = False
        Me.Name = "frmHistoricoFactoresDensidad"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Histórico de factores de densidad"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.pnlTitulo.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Manejo de datos"
    Private Sub Actualizar()
        Dim cmdBascula As New SqlClient.SqlCommand("SELECT * from vwBASHistoricoFactorDensidad", Globales.GetInstance.cnSigamet)
        Dim daBascula As New SqlClient.SqlDataAdapter(cmdBascula)
        Dim dtHistorico As New DataTable()
        Try
            daBascula.Fill(dtHistorico)
            vgHistorico.DataSource = dtHistorico
        Catch ex As Exception
            Globales.GetInstance.ExMessage(ex)
        End Try
    End Sub
    Private Sub Buscar()
        Dim Fecha As String
        Fecha = InputBox("Fecha(dd/mm/yyyy):", Application.ProductName & " v." & Application.ProductVersion, Now.Date.ToShortDateString)
        If vgHistorico.FindSimilar("FCambio", Fecha) < 0 Then
            Globales.GetInstance.ErrMessage("No se encontro el registro.")
        End If
    End Sub
#End Region
#Region "Menus y herramientas"
    Private Sub tbHistorico_ButtonClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolBarButtonClickEventArgs) Handles tbHistorico.ButtonClick
        Select Case e.Button.Text
            Case "Actualizar"
                Actualizar()
            Case "Buscar"
                Buscar()
            Case "Cerrar"
                Me.Close()
                Me.Dispose()
        End Select
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
#End Region
End Class
