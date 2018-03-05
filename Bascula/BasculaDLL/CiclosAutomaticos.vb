Option Strict On
Option Explicit On 

Imports System.Data.SqlClient

Public Class frmCiclosAutomaticos
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        CargaCelulas()
        vgCiclos.MultiSelect = True
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
    Friend WithEvents tbCiclosAutomaticos As System.Windows.Forms.ToolBar
    Friend WithEvents imgCiclosAutomaticos As System.Windows.Forms.ImageList
    Friend WithEvents btnBuscar As System.Windows.Forms.ToolBarButton
    Friend WithEvents Sep0 As System.Windows.Forms.ToolBarButton
    Friend WithEvents btnAbrirCiclos As System.Windows.Forms.ToolBarButton
    Friend WithEvents btnCerrarCiclos As System.Windows.Forms.ToolBarButton
    Friend WithEvents Sep1 As System.Windows.Forms.ToolBarButton
    Friend WithEvents btnCerrar As System.Windows.Forms.ToolBarButton
    Friend WithEvents rgrpDatos As Bascula.RoundedGroupBox
    Friend WithEvents Separador1 As Bascula.Figure
    Friend WithEvents lblFecha As System.Windows.Forms.Label
    Friend WithEvents lblCelula As System.Windows.Forms.Label
    Friend WithEvents cboCelula As System.Windows.Forms.ComboBox
    Friend WithEvents grpStatus As System.Windows.Forms.GroupBox
    Friend WithEvents dtpFecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents vgCiclos As Bascula.ViewGrid
    Friend WithEvents mnuCiclosAutomaticos As System.Windows.Forms.MainMenu
    Friend WithEvents mniHerramientas As System.Windows.Forms.MenuItem
    Friend WithEvents mniCiclosAutomaticos As System.Windows.Forms.MenuItem
    Friend WithEvents mniBuscar As System.Windows.Forms.MenuItem
    Friend WithEvents Sepm0 As System.Windows.Forms.MenuItem
    Friend WithEvents mniAbrirCiclos As System.Windows.Forms.MenuItem
    Friend WithEvents mniCerrarciclos As System.Windows.Forms.MenuItem
    Friend WithEvents Sepm1 As System.Windows.Forms.MenuItem
    Friend WithEvents mniCerrar As System.Windows.Forms.MenuItem
    Friend WithEvents rdoAbrir As System.Windows.Forms.RadioButton
    Friend WithEvents rdoCerrar As System.Windows.Forms.RadioButton
    Friend WithEvents btnActualizar As System.Windows.Forms.ToolBarButton
    Friend WithEvents chkFecha As System.Windows.Forms.CheckBox
    Friend WithEvents pnlControles As System.Windows.Forms.Panel
    Friend WithEvents llblTodos As System.Windows.Forms.LinkLabel
    Friend WithEvents llblNinguno As System.Windows.Forms.LinkLabel
    Friend WithEvents llblDesmarcarSeleccionados As System.Windows.Forms.LinkLabel
    Friend WithEvents llblMarcarSeleccionados As System.Windows.Forms.LinkLabel
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmCiclosAutomaticos))
        Me.tbCiclosAutomaticos = New System.Windows.Forms.ToolBar()
        Me.btnBuscar = New System.Windows.Forms.ToolBarButton()
        Me.btnActualizar = New System.Windows.Forms.ToolBarButton()
        Me.Sep0 = New System.Windows.Forms.ToolBarButton()
        Me.btnAbrirCiclos = New System.Windows.Forms.ToolBarButton()
        Me.btnCerrarCiclos = New System.Windows.Forms.ToolBarButton()
        Me.Sep1 = New System.Windows.Forms.ToolBarButton()
        Me.btnCerrar = New System.Windows.Forms.ToolBarButton()
        Me.imgCiclosAutomaticos = New System.Windows.Forms.ImageList(Me.components)
        Me.rgrpDatos = New Bascula.RoundedGroupBox()
        Me.chkFecha = New System.Windows.Forms.CheckBox()
        Me.grpStatus = New System.Windows.Forms.GroupBox()
        Me.rdoAbrir = New System.Windows.Forms.RadioButton()
        Me.rdoCerrar = New System.Windows.Forms.RadioButton()
        Me.dtpFecha = New System.Windows.Forms.DateTimePicker()
        Me.cboCelula = New System.Windows.Forms.ComboBox()
        Me.lblFecha = New System.Windows.Forms.Label()
        Me.lblCelula = New System.Windows.Forms.Label()
        Me.Separador1 = New Bascula.Figure()
        Me.vgCiclos = New Bascula.ViewGrid()
        Me.mnuCiclosAutomaticos = New System.Windows.Forms.MainMenu()
        Me.mniHerramientas = New System.Windows.Forms.MenuItem()
        Me.mniCiclosAutomaticos = New System.Windows.Forms.MenuItem()
        Me.mniBuscar = New System.Windows.Forms.MenuItem()
        Me.Sepm0 = New System.Windows.Forms.MenuItem()
        Me.mniAbrirCiclos = New System.Windows.Forms.MenuItem()
        Me.mniCerrarciclos = New System.Windows.Forms.MenuItem()
        Me.Sepm1 = New System.Windows.Forms.MenuItem()
        Me.mniCerrar = New System.Windows.Forms.MenuItem()
        Me.pnlControles = New System.Windows.Forms.Panel()
        Me.llblTodos = New System.Windows.Forms.LinkLabel()
        Me.llblNinguno = New System.Windows.Forms.LinkLabel()
        Me.llblDesmarcarSeleccionados = New System.Windows.Forms.LinkLabel()
        Me.llblMarcarSeleccionados = New System.Windows.Forms.LinkLabel()
        Me.rgrpDatos.SuspendLayout()
        Me.grpStatus.SuspendLayout()
        Me.pnlControles.SuspendLayout()
        Me.SuspendLayout()
        '
        'tbCiclosAutomaticos
        '
        Me.tbCiclosAutomaticos.Appearance = System.Windows.Forms.ToolBarAppearance.Flat
        Me.tbCiclosAutomaticos.Buttons.AddRange(New System.Windows.Forms.ToolBarButton() {Me.btnBuscar, Me.btnActualizar, Me.Sep0, Me.btnAbrirCiclos, Me.btnCerrarCiclos, Me.Sep1, Me.btnCerrar})
        Me.tbCiclosAutomaticos.DropDownArrows = True
        Me.tbCiclosAutomaticos.ImageList = Me.imgCiclosAutomaticos
        Me.tbCiclosAutomaticos.Location = New System.Drawing.Point(3, 0)
        Me.tbCiclosAutomaticos.Name = "tbCiclosAutomaticos"
        Me.tbCiclosAutomaticos.ShowToolTips = True
        Me.tbCiclosAutomaticos.Size = New System.Drawing.Size(540, 39)
        Me.tbCiclosAutomaticos.TabIndex = 1
        '
        'btnBuscar
        '
        Me.btnBuscar.ImageIndex = 0
        Me.btnBuscar.Text = "Buscar"
        Me.btnBuscar.ToolTipText = "Buscar autotanques"
        '
        'btnActualizar
        '
        Me.btnActualizar.ImageIndex = 4
        Me.btnActualizar.Text = "Actualizar"
        Me.btnActualizar.ToolTipText = "Cargar los datos más recientes"
        '
        'Sep0
        '
        Me.Sep0.Style = System.Windows.Forms.ToolBarButtonStyle.Separator
        '
        'btnAbrirCiclos
        '
        Me.btnAbrirCiclos.Enabled = False
        Me.btnAbrirCiclos.ImageIndex = 1
        Me.btnAbrirCiclos.Text = "Abrir ciclos"
        Me.btnAbrirCiclos.ToolTipText = "Abre los ciclos de los autotanques seleccionados"
        '
        'btnCerrarCiclos
        '
        Me.btnCerrarCiclos.Enabled = False
        Me.btnCerrarCiclos.ImageIndex = 2
        Me.btnCerrarCiclos.Text = "Cerrar ciclos"
        Me.btnCerrarCiclos.ToolTipText = "Cierra los ciclos de los autotanques seleccionados"
        '
        'Sep1
        '
        Me.Sep1.Style = System.Windows.Forms.ToolBarButtonStyle.Separator
        '
        'btnCerrar
        '
        Me.btnCerrar.ImageIndex = 3
        Me.btnCerrar.Text = "Cerrar"
        Me.btnCerrar.ToolTipText = "Cerrar la pantalla de ciclos automáticos"
        '
        'imgCiclosAutomaticos
        '
        Me.imgCiclosAutomaticos.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit
        Me.imgCiclosAutomaticos.ImageSize = New System.Drawing.Size(16, 16)
        Me.imgCiclosAutomaticos.ImageStream = CType(resources.GetObject("imgCiclosAutomaticos.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imgCiclosAutomaticos.TransparentColor = System.Drawing.Color.Transparent
        '
        'rgrpDatos
        '
        Me.rgrpDatos.BorderColor = System.Drawing.Color.Gray
        Me.rgrpDatos.Controls.AddRange(New System.Windows.Forms.Control() {Me.chkFecha, Me.grpStatus, Me.dtpFecha, Me.cboCelula, Me.lblFecha, Me.lblCelula})
        Me.rgrpDatos.Dock = System.Windows.Forms.DockStyle.Top
        Me.rgrpDatos.FlatStyle = Bascula.RoundedGroupBox.Style.Flat
        Me.rgrpDatos.Location = New System.Drawing.Point(3, 56)
        Me.rgrpDatos.Name = "rgrpDatos"
        Me.rgrpDatos.Size = New System.Drawing.Size(540, 82)
        Me.rgrpDatos.TabIndex = 0
        Me.rgrpDatos.TabStop = False
        Me.rgrpDatos.Text = "Datos de búsqueda"
        Me.rgrpDatos.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left
        '
        'chkFecha
        '
        Me.chkFecha.Checked = True
        Me.chkFecha.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkFecha.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.chkFecha.Location = New System.Drawing.Point(62, 28)
        Me.chkFecha.Name = "chkFecha"
        Me.chkFecha.Size = New System.Drawing.Size(13, 13)
        Me.chkFecha.TabIndex = 5
        '
        'grpStatus
        '
        Me.grpStatus.Controls.AddRange(New System.Windows.Forms.Control() {Me.rdoAbrir, Me.rdoCerrar})
        Me.grpStatus.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.grpStatus.Location = New System.Drawing.Point(256, 13)
        Me.grpStatus.Name = "grpStatus"
        Me.grpStatus.Size = New System.Drawing.Size(216, 56)
        Me.grpStatus.TabIndex = 4
        Me.grpStatus.TabStop = False
        '
        'rdoAbrir
        '
        Me.rdoAbrir.Checked = True
        Me.rdoAbrir.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.rdoAbrir.Location = New System.Drawing.Point(16, 14)
        Me.rdoAbrir.Name = "rdoAbrir"
        Me.rdoAbrir.Size = New System.Drawing.Size(80, 32)
        Me.rdoAbrir.TabIndex = 0
        Me.rdoAbrir.TabStop = True
        Me.rdoAbrir.Text = "Ciclos para &abrir"
        '
        'rdoCerrar
        '
        Me.rdoCerrar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.rdoCerrar.Location = New System.Drawing.Point(123, 14)
        Me.rdoCerrar.Name = "rdoCerrar"
        Me.rdoCerrar.Size = New System.Drawing.Size(80, 32)
        Me.rdoCerrar.TabIndex = 1
        Me.rdoCerrar.Text = "Ciclos para ce&rrar"
        '
        'dtpFecha
        '
        Me.dtpFecha.CustomFormat = "dd 'de' MMMM 'de' yyy"
        Me.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpFecha.Location = New System.Drawing.Point(76, 24)
        Me.dtpFecha.Name = "dtpFecha"
        Me.dtpFecha.Size = New System.Drawing.Size(156, 21)
        Me.dtpFecha.TabIndex = 1
        '
        'cboCelula
        '
        Me.cboCelula.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCelula.Location = New System.Drawing.Point(76, 49)
        Me.cboCelula.Name = "cboCelula"
        Me.cboCelula.Size = New System.Drawing.Size(156, 21)
        Me.cboCelula.TabIndex = 3
        '
        'lblFecha
        '
        Me.lblFecha.AutoSize = True
        Me.lblFecha.Location = New System.Drawing.Point(19, 27)
        Me.lblFecha.Name = "lblFecha"
        Me.lblFecha.Size = New System.Drawing.Size(38, 14)
        Me.lblFecha.TabIndex = 0
        Me.lblFecha.Text = "&Fecha:"
        '
        'lblCelula
        '
        Me.lblCelula.AutoSize = True
        Me.lblCelula.Location = New System.Drawing.Point(19, 52)
        Me.lblCelula.Name = "lblCelula"
        Me.lblCelula.Size = New System.Drawing.Size(38, 14)
        Me.lblCelula.TabIndex = 2
        Me.lblCelula.Text = "&Celula:"
        '
        'Separador1
        '
        Me.Separador1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Separador1.FillColor = System.Drawing.Color.LightSteelBlue
        Me.Separador1.LineColor = System.Drawing.Color.Gainsboro
        Me.Separador1.LineWidth = 1.0!
        Me.Separador1.Location = New System.Drawing.Point(3, 39)
        Me.Separador1.Name = "Separador1"
        Me.Separador1.Size = New System.Drawing.Size(540, 17)
        Me.Separador1.Style = Bascula.Figure.FigureStyle.Line
        Me.Separador1.TabIndex = 2
        Me.Separador1.TabStop = False
        '
        'vgCiclos
        '
        Me.vgCiclos.AlternativeBackColor = System.Drawing.Color.Gainsboro
        Me.vgCiclos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.vgCiclos.CheckBoxes = True
        Me.vgCiclos.CheckCondition = Nothing
        Me.vgCiclos.DataSource = Nothing
        Me.vgCiclos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.vgCiclos.FormatColumnNames = New String(-1) {}
        Me.vgCiclos.FullRowSelect = True
        Me.vgCiclos.GridLines = True
        Me.vgCiclos.HidedColumnNames = New String(-1) {}
        Me.vgCiclos.HideSelection = False
        Me.vgCiclos.Location = New System.Drawing.Point(3, 184)
        Me.vgCiclos.MultiSelect = False
        Me.vgCiclos.Name = "vgCiclos"
        Me.vgCiclos.PKColumnNames = Nothing
        Me.vgCiclos.Size = New System.Drawing.Size(540, 380)
        Me.vgCiclos.TabIndex = 2
        Me.vgCiclos.View = System.Windows.Forms.View.Details
        '
        'mnuCiclosAutomaticos
        '
        Me.mnuCiclosAutomaticos.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mniHerramientas})
        '
        'mniHerramientas
        '
        Me.mniHerramientas.Index = 0
        Me.mniHerramientas.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mniCiclosAutomaticos})
        Me.mniHerramientas.MergeOrder = 3
        Me.mniHerramientas.MergeType = System.Windows.Forms.MenuMerge.MergeItems
        Me.mniHerramientas.Text = "&Herramientas"
        '
        'mniCiclosAutomaticos
        '
        Me.mniCiclosAutomaticos.Index = 0
        Me.mniCiclosAutomaticos.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mniBuscar, Me.Sepm0, Me.mniAbrirCiclos, Me.mniCerrarciclos, Me.Sepm1, Me.mniCerrar})
        Me.mniCiclosAutomaticos.MergeType = System.Windows.Forms.MenuMerge.MergeItems
        Me.mniCiclosAutomaticos.Text = "&Ciclos automáticos"
        '
        'mniBuscar
        '
        Me.mniBuscar.Index = 0
        Me.mniBuscar.Shortcut = System.Windows.Forms.Shortcut.CtrlB
        Me.mniBuscar.Text = "&Buscar"
        '
        'Sepm0
        '
        Me.Sepm0.Index = 1
        Me.Sepm0.Text = "-"
        '
        'mniAbrirCiclos
        '
        Me.mniAbrirCiclos.Enabled = False
        Me.mniAbrirCiclos.Index = 2
        Me.mniAbrirCiclos.Shortcut = System.Windows.Forms.Shortcut.CtrlA
        Me.mniAbrirCiclos.Text = "&Abrir ciclos"
        '
        'mniCerrarciclos
        '
        Me.mniCerrarciclos.Enabled = False
        Me.mniCerrarciclos.Index = 3
        Me.mniCerrarciclos.Shortcut = System.Windows.Forms.Shortcut.CtrlC
        Me.mniCerrarciclos.Text = "&CerrarCiclos"
        '
        'Sepm1
        '
        Me.Sepm1.Index = 4
        Me.Sepm1.Text = "-"
        '
        'mniCerrar
        '
        Me.mniCerrar.Index = 5
        Me.mniCerrar.Text = "C&errar"
        '
        'pnlControles
        '
        Me.pnlControles.Controls.AddRange(New System.Windows.Forms.Control() {Me.llblTodos, Me.llblNinguno, Me.llblDesmarcarSeleccionados, Me.llblMarcarSeleccionados})
        Me.pnlControles.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlControles.Location = New System.Drawing.Point(3, 138)
        Me.pnlControles.Name = "pnlControles"
        Me.pnlControles.Size = New System.Drawing.Size(540, 46)
        Me.pnlControles.TabIndex = 3
        '
        'llblTodos
        '
        Me.llblTodos.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.llblTodos.Image = CType(resources.GetObject("llblTodos.Image"), System.Drawing.Bitmap)
        Me.llblTodos.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.llblTodos.ImageIndex = 5
        Me.llblTodos.ImageList = Me.imgCiclosAutomaticos
        Me.llblTodos.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline
        Me.llblTodos.LinkColor = System.Drawing.Color.DarkBlue
        Me.llblTodos.Location = New System.Drawing.Point(8, 16)
        Me.llblTodos.Name = "llblTodos"
        Me.llblTodos.Size = New System.Drawing.Size(56, 16)
        Me.llblTodos.TabIndex = 0
        Me.llblTodos.TabStop = True
        Me.llblTodos.Text = "&Todos"
        Me.llblTodos.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'llblNinguno
        '
        Me.llblNinguno.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.llblNinguno.Image = CType(resources.GetObject("llblNinguno.Image"), System.Drawing.Bitmap)
        Me.llblNinguno.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.llblNinguno.ImageIndex = 6
        Me.llblNinguno.ImageList = Me.imgCiclosAutomaticos
        Me.llblNinguno.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline
        Me.llblNinguno.LinkColor = System.Drawing.Color.DarkBlue
        Me.llblNinguno.Location = New System.Drawing.Point(72, 16)
        Me.llblNinguno.Name = "llblNinguno"
        Me.llblNinguno.Size = New System.Drawing.Size(64, 16)
        Me.llblNinguno.TabIndex = 0
        Me.llblNinguno.TabStop = True
        Me.llblNinguno.Text = "&Ninguno"
        Me.llblNinguno.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'llblDesmarcarSeleccionados
        '
        Me.llblDesmarcarSeleccionados.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.llblDesmarcarSeleccionados.Image = CType(resources.GetObject("llblDesmarcarSeleccionados.Image"), System.Drawing.Bitmap)
        Me.llblDesmarcarSeleccionados.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.llblDesmarcarSeleccionados.ImageIndex = 6
        Me.llblDesmarcarSeleccionados.ImageList = Me.imgCiclosAutomaticos
        Me.llblDesmarcarSeleccionados.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline
        Me.llblDesmarcarSeleccionados.LinkColor = System.Drawing.Color.DarkBlue
        Me.llblDesmarcarSeleccionados.Location = New System.Drawing.Point(242, 16)
        Me.llblDesmarcarSeleccionados.Name = "llblDesmarcarSeleccionados"
        Me.llblDesmarcarSeleccionados.Size = New System.Drawing.Size(68, 16)
        Me.llblDesmarcarSeleccionados.TabIndex = 0
        Me.llblDesmarcarSeleccionados.TabStop = True
        Me.llblDesmarcarSeleccionados.Text = "S&elección"
        Me.llblDesmarcarSeleccionados.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'llblMarcarSeleccionados
        '
        Me.llblMarcarSeleccionados.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.llblMarcarSeleccionados.Image = CType(resources.GetObject("llblMarcarSeleccionados.Image"), System.Drawing.Bitmap)
        Me.llblMarcarSeleccionados.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.llblMarcarSeleccionados.ImageIndex = 5
        Me.llblMarcarSeleccionados.ImageList = Me.imgCiclosAutomaticos
        Me.llblMarcarSeleccionados.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline
        Me.llblMarcarSeleccionados.LinkColor = System.Drawing.Color.DarkBlue
        Me.llblMarcarSeleccionados.Location = New System.Drawing.Point(168, 16)
        Me.llblMarcarSeleccionados.Name = "llblMarcarSeleccionados"
        Me.llblMarcarSeleccionados.Size = New System.Drawing.Size(66, 16)
        Me.llblMarcarSeleccionados.TabIndex = 0
        Me.llblMarcarSeleccionados.TabStop = True
        Me.llblMarcarSeleccionados.Text = "&Selección"
        Me.llblMarcarSeleccionados.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'frmCiclosAutomaticos
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 14)
        Me.BackColor = System.Drawing.Color.Gainsboro
        Me.ClientSize = New System.Drawing.Size(546, 567)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.vgCiclos, Me.pnlControles, Me.rgrpDatos, Me.Separador1, Me.tbCiclosAutomaticos})
        Me.DockPadding.Bottom = 3
        Me.DockPadding.Left = 3
        Me.DockPadding.Right = 3
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Menu = Me.mnuCiclosAutomaticos
        Me.MinimizeBox = False
        Me.Name = "frmCiclosAutomaticos"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = " Ciclos automáticos"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.rgrpDatos.ResumeLayout(False)
        Me.grpStatus.ResumeLayout(False)
        Me.pnlControles.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Rutinas de actualización"
    Private Sub CargaCelulas()
        Dim cmdBascula As New SqlCommand("Select Celula, Descripcion from Celula where (Comercial = 1 and Celula in (Select Celula from UsuarioCelula " _
                           & " where Usuario = @Usuario)) or Celula  = 0 order by Celula", Globales.GetInstance.cnSigamet)
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
    Private Sub Actualizar()
        If Not Globales.GetInstance.cnSigamet Is Nothing Then
            btnAbrirCiclos.Enabled = False
            btnCerrarCiclos.Enabled = False
            mniAbrirCiclos.Enabled = False
            mniCerrarciclos.Enabled = False
            If rdoAbrir.Checked Then
                CargaCiclosApertura()
            Else
                CargaCiclosCierre()
            End If
        End If
    End Sub
    Private Sub CargaCiclosApertura()
        If Not Globales.GetInstance.cnSigamet.ConnectionString = "" Then
            Dim cmdBascula As New SqlCommand("Select * from vwBASInicioAutotmaticoCiclo ", Globales.GetInstance.cnSigamet)
            Dim daBascula As New SqlDataAdapter(cmdBascula)
            Dim dtCiclos As New DataTable()
            Me.Cursor = Cursors.WaitCursor
            vgCiclos.DataSource = Nothing
            If Not cboCelula.SelectedItem Is Nothing AndAlso CInt(cboCelula.SelectedValue) > 0 Then
                cmdBascula.CommandText &= " where Celula = @Celula"
                cmdBascula.Parameters.Add("@Celula", SqlDbType.TinyInt).Value = CInt(cboCelula.SelectedValue)
            End If
            Try
                daBascula.Fill(dtCiclos)
                vgCiclos.DataSource = dtCiclos
                btnAbrirCiclos.Enabled = dtCiclos.Rows.Count > 0
                mniAbrirCiclos.Enabled = dtCiclos.Rows.Count > 0
            Catch ex As Exception
                Globales.GetInstance.ExMessage(ex)
            Finally
                Me.Cursor = Cursors.Default
            End Try
        End If
    End Sub
    Private Sub CargaCiclosCierre()
        If Not Globales.GetInstance.cnSigamet.ConnectionString = "" Then
            Dim cmdBascula As New SqlCommand("Select * from vwBASCierreAutotmaticoCiclo where 1 = 1 ", Globales.GetInstance.cnSigamet)
            Dim daBascula As New SqlDataAdapter(cmdBascula)
            Dim dtCiclos As New DataTable()
            Me.Cursor = Cursors.WaitCursor
            vgCiclos.DataSource = Nothing
            If chkFecha.Checked Then
                cmdBascula.CommandText &= " and FInicioRuta between  @Fecha and dateadd(hh,23,dateadd(n,59,dateadd(s,59,@Fecha))) "
                cmdBascula.Parameters.Add("@Fecha", SqlDbType.DateTime).Value = dtpFecha.Value.Date
            End If
            If Not cboCelula.SelectedItem Is Nothing AndAlso CInt(cboCelula.SelectedValue) > 0 Then
                cmdBascula.CommandText &= " and Celula = @Celula"
                cmdBascula.Parameters.Add("@Celula", SqlDbType.TinyInt).Value = CInt(cboCelula.SelectedValue)
            End If
            Try
                daBascula.Fill(dtCiclos)
                vgCiclos.DataSource = dtCiclos
                btnCerrarCiclos.Enabled = dtCiclos.Rows.Count > 0
                mniCerrarciclos.Enabled = dtCiclos.Rows.Count > 0
            Catch ex As Exception
                Globales.GetInstance.ExMessage(ex)
            Finally
                Me.Cursor = Cursors.Default
            End Try
        End If
    End Sub
    Private Sub cboCelula_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboCelula.SelectedIndexChanged
        Actualizar()
    End Sub
    Private Sub dtpFecha_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpFecha.ValueChanged
        If rdoCerrar.Checked Then
            btnCerrarCiclos.Enabled = False
            mniCerrarciclos.Enabled = False
            CargaCiclosCierre()
        End If
    End Sub
    Private Sub rdoAbrir_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdoAbrir.CheckedChanged
        If rdoAbrir.Checked Then
            chkFecha.Checked = True
        End If
        chkFecha.Enabled = Not rdoAbrir.Checked
        Actualizar()
    End Sub
    Private Sub chkFecha_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkFecha.CheckedChanged
        dtpFecha.Enabled = chkFecha.Checked
        Actualizar()
    End Sub
#End Region
#Region "Barra de herramientas y menu"
    Private Sub tbCiclosAutomaticos_ButtonClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolBarButtonClickEventArgs) Handles tbCiclosAutomaticos.ButtonClick
        Select Case e.Button.Text
            Case "Buscar"
                Buscar()
            Case "Actualizar"
                Actualizar()
            Case "Abrir ciclos"
                AbreCiclos()
            Case "Cerrar ciclos"
                CierraCiclos()
            Case "Cerrar"
                Me.Close()
                Me.Dispose()
        End Select
    End Sub
    Private Sub mniBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mniBuscar.Click
        Buscar()
    End Sub
    Private Sub mniAbrirCiclos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mniAbrirCiclos.Click
        AbreCiclos()
    End Sub
    Private Sub mniCerrarciclos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mniCerrarciclos.Click
        CierraCiclos()
    End Sub
    Private Sub mniCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mniCerrar.Click
        Me.Close()
        Me.Dispose()
    End Sub
#End Region
#Region "Manejo de datos"
    Private Sub Buscar()
        Dim Autotanque As String = InputBox("Autotanque:", Application.ProductName & " v." & Application.ProductVersion)
        If Autotanque.Trim <> "" Then
            If vgCiclos.FindFirst("Autotanque", Autotanque) < 0 Then
                Globales.GetInstance.ErrMessage("No se encontró el autotanqué.")
            End If
        End If
    End Sub
    Private Sub AbreCiclos()
        If vgCiclos.CheckedItems.Count > 0 Then
            Dim cmdBascula As New SqlCommand("", Globales.GetInstance.cnSigamet)
            Dim trnCiclos As SqlTransaction = Nothing
            Dim Folio As Integer
            Dim item As ListViewItem
            Dim row As DataRow
            cmdBascula.Parameters.Add("@Año", SqlDbType.SmallInt).Value = dtpFecha.Value.Year
            cmdBascula.Parameters.Add("@FInicioRuta", SqlDbType.DateTime).Value = dtpFecha.Value.Date
            cmdBascula.Parameters.Add("@ObservacionesInicioRuta", SqlDbType.VarChar).Value = "Apertura automática"
            cmdBascula.Parameters.Add("@Folio", SqlDbType.Int).Value = 0
            cmdBascula.Parameters.Add("@Celula", SqlDbType.TinyInt).Value = 0
            cmdBascula.Parameters.Add("@Autotanque", SqlDbType.SmallInt).Value = 0
            cmdBascula.Parameters.Add("@Ruta", SqlDbType.SmallInt).Value = 0
            cmdBascula.Parameters.Add("@KilometrajeInicial", SqlDbType.Int).Value = 0
            cmdBascula.Parameters.Add("@TotalizadorInicial", SqlDbType.Int).Value = 0
            cmdBascula.Parameters.Add("@PorcentajeGasInicial", SqlDbType.Decimal).Value = 0
            cmdBascula.Parameters.Add("@LitrosGasInicial", SqlDbType.Int).Value = 0
            cmdBascula.Parameters.Add("@PesoSalida", SqlDbType.Int).Value = 0
            Me.Cursor = Cursors.WaitCursor
            Try
                Globales.GetInstance.cnSigamet.Open()
                trnCiclos = Globales.GetInstance.cnSigamet.BeginTransaction
                cmdBascula.Transaction = trnCiclos
                For Each item In vgCiclos.CheckedItems
                    cmdBascula.CommandText = "select dbo.BASFolioConsecutivo(@Año)"
                    cmdBascula.CommandType = CommandType.Text
                    Folio = CInt(cmdBascula.ExecuteScalar)
                    row = CType(item.Tag, DataRow)

                    cmdBascula.CommandText = "spBASAbreCiclo"
                    cmdBascula.CommandType = CommandType.StoredProcedure

                    cmdBascula.Parameters("@Folio").Value = Folio
                    cmdBascula.Parameters("@Celula").Value = row("Celula")
                    cmdBascula.Parameters("@Autotanque").Value = row("Autotanque")
                    cmdBascula.Parameters("@Ruta").Value = row("Ruta")
                    cmdBascula.Parameters("@KilometrajeInicial").Value = row("KilometrajeInicial")
                    cmdBascula.Parameters("@TotalizadorInicial").Value = row("TotalizadorInicial")
                    cmdBascula.Parameters("@PorcentajeGasInicial").Value = row("PorcentajeGasInicial")
                    cmdBascula.Parameters("@LitrosGasInicial").Value = row("LitrosGasInicial")
                    cmdBascula.Parameters("@PesoSalida").Value = row("PesoSalida")

                    cmdBascula.ExecuteNonQuery()
                Next
                trnCiclos.Commit()
                MessageBox.Show("Se han abierto los cilos seleccionados.", Application.ProductName & " v." & Application.ProductVersion, MessageBoxButtons.OK, MessageBoxIcon.Information)
                Actualizar()
            Catch ex As Exception
                trnCiclos.Rollback()
                Globales.GetInstance.ExMessage(ex)
            Finally
                Globales.GetInstance.cnSigamet.Close()
                Me.Cursor = Cursors.Default
            End Try
        Else
            Globales.GetInstance.ErrMessage("No ha marcado ningún elemento.")
        End If
    End Sub
    Private Sub CierraCiclos()
        If vgCiclos.CheckedItems.Count > 0 Then
            Dim cmdBascula As New SqlCommand("spBASCierraCiclo", Globales.GetInstance.cnSigamet)
            Dim trnCiclos As SqlTransaction = Nothing
            Dim item As ListViewItem
            Dim row As DataRow
            cmdBascula.CommandType = CommandType.StoredProcedure
            cmdBascula.Parameters.Add("@FTerminoRuta", SqlDbType.DateTime).Value = Now
            cmdBascula.Parameters.Add("@ObservacionesCierreRuta", SqlDbType.VarChar).Value = "Cierre automático"
            cmdBascula.Parameters.Add("@PesoEficiencia", SqlDbType.Int).Value = 0
            cmdBascula.Parameters.Add("@PesoImporteEficiencia", SqlDbType.Money).Value = 0
            cmdBascula.Parameters.Add("@PorcentajeEficiencia", SqlDbType.Int).Value = 0
            cmdBascula.Parameters.Add("@PorcentajeImporteEficiencia", SqlDbType.Money).Value = 0
            cmdBascula.Parameters.Add("@Año", SqlDbType.SmallInt).Value = Now.Year
            cmdBascula.Parameters.Add("@Folio", SqlDbType.Int).Value = 0
            cmdBascula.Parameters.Add("@LitrosVendidos", SqlDbType.Int).Value = 0
            cmdBascula.Parameters.Add("@LitroGasNoVendido", SqlDbType.Int).Value = 0
            cmdBascula.Parameters.Add("@PesoLlegada", SqlDbType.Int).Value = 0
            cmdBascula.Parameters.Add("@PorcentajeGasNoVendido", SqlDbType.Money).Value = 0
            cmdBascula.Parameters.Add("@TotalizadorFinal", SqlDbType.Int).Value = 0
            cmdBascula.Parameters.Add("@KilometrajeFinal", SqlDbType.Int).Value = 0
            cmdBascula.Parameters.Add("@LitrosVendidosPorcentaje", SqlDbType.Int).Value = 0
            Me.Cursor = Cursors.WaitCursor
            Try
                Globales.GetInstance.cnSigamet.Open()
                trnCiclos = Globales.GetInstance.cnSigamet.BeginTransaction
                cmdBascula.Transaction = trnCiclos
                For Each item In vgCiclos.CheckedItems
                    row = CType(item.Tag, DataRow)
                    cmdBascula.Parameters("@Año").Value = row("AñoAtt")
                    cmdBascula.Parameters("@Folio").Value = row("Folio")
                    cmdBascula.Parameters("@LitrosVendidos").Value = row("LitrosVendidos")
                    cmdBascula.Parameters("@LitroGasNoVendido").Value = row("LitrosGasNoVendido")
                    cmdBascula.Parameters("@PesoLlegada").Value = row("PesoLlegada")
                    cmdBascula.Parameters("@PorcentajeGasNoVendido").Value = row("PorcentajeGasNoVendido")
                    cmdBascula.Parameters("@TotalizadorFinal").Value = row("TotalizadorFinal")
                    cmdBascula.Parameters("@KilometrajeFinal").Value = row("KilometrajeFinal")
                    cmdBascula.ExecuteNonQuery()
                Next
                trnCiclos.Commit()
                MessageBox.Show("Se han cerrado los cilos seleccionados.", Application.ProductName & " v." & Application.ProductVersion, MessageBoxButtons.OK, MessageBoxIcon.Information)
                Actualizar()
            Catch ex As Exception
                trnCiclos.Rollback()
                Globales.GetInstance.ExMessage(ex)
            Finally
                Globales.GetInstance.cnSigamet.Close()
                Me.Cursor = Cursors.Default
            End Try
        Else
            Globales.GetInstance.ErrMessage("No ha marcado ningún elemento.")
        End If
    End Sub
#End Region

    Private Sub llblTodos_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llblTodos.LinkClicked
        Dim item As ListViewItem
        For Each item In vgCiclos.Items
            item.Checked = True
        Next
    End Sub

    Private Sub llblNinguno_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llblNinguno.LinkClicked
        Dim item As ListViewItem
        For Each item In vgCiclos.Items
            item.Checked = False
        Next
    End Sub

    Private Sub llblMarcarSeleccionados_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llblMarcarSeleccionados.LinkClicked
        Dim item As ListViewItem
        For Each item In vgCiclos.SelectedItems
            item.Checked = True
        Next
    End Sub

    Private Sub llblDesmarcarSeleccionados_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llblDesmarcarSeleccionados.LinkClicked
        Dim item As ListViewItem
        For Each item In vgCiclos.SelectedItems
            item.Checked = False
        Next
    End Sub

End Class

