Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.IO
Imports Bascula

Public Class frmAutotanque
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        Dim cmdLogistica As New SqlCommand("Select C.Celula as Celula, ltrim(rtrim(C.Descripcion)) as Descripcion from Celula C " _
                      & " where C.Comercial = 1", Globales.GetInstance.cnSigamet)
        Dim daLogistica As New SqlDataAdapter(cmdLogistica)
        Dim dtCelula As New DataTable()
        cmdLogistica.Parameters.Add("@Usuario", SqlDbType.Char).Value = Globales.GetInstance._Usuario
        Try
            daLogistica.Fill(dtCelula)
        Catch ex As Exception
            Globales.GetInstance.ExMessage(ex)
        End Try
        cboCelula.ValueMember = "Celula"
        cboCelula.DisplayMember = "Descripcion"
        cboCelula.DataSource = dtCelula
        cboCelula.SelectedValue = Globales.GetInstance._Celula
        cmdLogistica.Dispose()
        daLogistica.Dispose()
        CargaInformacion()
        CargaDatosAdicionales()

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
    Friend WithEvents mnuCatalogo As System.Windows.Forms.MenuItem
    Friend WithEvents pnlDatosAdicionales As System.Windows.Forms.Panel
    Friend WithEvents txtMarca As System.Windows.Forms.TextBox
    Friend WithEvents lblMarca As System.Windows.Forms.Label
    Friend WithEvents txtStatus As System.Windows.Forms.TextBox
    Friend WithEvents txtProducto As System.Windows.Forms.TextBox
    Friend WithEvents txtPropietario As System.Windows.Forms.TextBox
    Friend WithEvents txtTipo As System.Windows.Forms.TextBox
    Friend WithEvents lblStatus As System.Windows.Forms.Label
    Friend WithEvents lblProducto As System.Windows.Forms.Label
    Friend WithEvents lblPropietario As System.Windows.Forms.Label
    Friend WithEvents lblTipo As System.Windows.Forms.Label
    Friend WithEvents mnuAutotanque As System.Windows.Forms.MainMenu
    Friend WithEvents cboCelula As System.Windows.Forms.ComboBox
    Friend WithEvents lblCelula As System.Windows.Forms.Label
    Friend WithEvents vgrdCatalogo As Bascula.ViewGrid
    Friend WithEvents pnlTitulo As System.Windows.Forms.Panel
    Friend WithEvents rlblTitulo As Bascula.RotatableLabel
    Friend WithEvents tbOperador As System.Windows.Forms.ToolBar
    Friend WithEvents Sep0 As System.Windows.Forms.ToolBarButton
    Friend WithEvents btnModificar As System.Windows.Forms.ToolBarButton
    Friend WithEvents Sep1 As System.Windows.Forms.ToolBarButton
    Friend WithEvents btnFiltro As System.Windows.Forms.ToolBarButton
    Friend WithEvents mnuFiltro As System.Windows.Forms.ContextMenu
    Friend WithEvents btnBuscar As System.Windows.Forms.ToolBarButton
    Friend WithEvents Sep2 As System.Windows.Forms.ToolBarButton
    Friend WithEvents Sep3 As System.Windows.Forms.ToolBarButton
    Friend WithEvents btnCerrar As System.Windows.Forms.ToolBarButton
    Friend WithEvents Sep4 As System.Windows.Forms.ToolBarButton
    Friend WithEvents imgHerramientas As System.Windows.Forms.ImageList
    Friend WithEvents mniTodos As System.Windows.Forms.MenuItem
    Friend WithEvents mniActivos As System.Windows.Forms.MenuItem
    Friend WithEvents mniInactivos As System.Windows.Forms.MenuItem
    Friend WithEvents mniAutotanque As System.Windows.Forms.MenuItem
    Friend WithEvents mniModificar As System.Windows.Forms.MenuItem
    Friend WithEvents Sepm0 As System.Windows.Forms.MenuItem
    Friend WithEvents mniBuscar As System.Windows.Forms.MenuItem
    Friend WithEvents Sepm2 As System.Windows.Forms.MenuItem
    Friend WithEvents mniActualizar As System.Windows.Forms.MenuItem
    Friend WithEvents Sepm3 As System.Windows.Forms.MenuItem
    Friend WithEvents mniCerrar As System.Windows.Forms.MenuItem
    Friend WithEvents btnActualizar As System.Windows.Forms.ToolBarButton
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmAutotanque))
        Me.mnuAutotanque = New System.Windows.Forms.MainMenu()
        Me.mnuCatalogo = New System.Windows.Forms.MenuItem()
        Me.mniAutotanque = New System.Windows.Forms.MenuItem()
        Me.mniModificar = New System.Windows.Forms.MenuItem()
        Me.Sepm0 = New System.Windows.Forms.MenuItem()
        Me.mniBuscar = New System.Windows.Forms.MenuItem()
        Me.Sepm2 = New System.Windows.Forms.MenuItem()
        Me.mniActualizar = New System.Windows.Forms.MenuItem()
        Me.Sepm3 = New System.Windows.Forms.MenuItem()
        Me.mniCerrar = New System.Windows.Forms.MenuItem()
        Me.pnlDatosAdicionales = New System.Windows.Forms.Panel()
        Me.txtMarca = New System.Windows.Forms.TextBox()
        Me.lblMarca = New System.Windows.Forms.Label()
        Me.txtStatus = New System.Windows.Forms.TextBox()
        Me.txtProducto = New System.Windows.Forms.TextBox()
        Me.txtPropietario = New System.Windows.Forms.TextBox()
        Me.txtTipo = New System.Windows.Forms.TextBox()
        Me.lblStatus = New System.Windows.Forms.Label()
        Me.lblProducto = New System.Windows.Forms.Label()
        Me.lblPropietario = New System.Windows.Forms.Label()
        Me.lblTipo = New System.Windows.Forms.Label()
        Me.cboCelula = New System.Windows.Forms.ComboBox()
        Me.lblCelula = New System.Windows.Forms.Label()
        Me.vgrdCatalogo = New Bascula.ViewGrid()
        Me.pnlTitulo = New System.Windows.Forms.Panel()
        Me.rlblTitulo = New Bascula.RotatableLabel()
        Me.tbOperador = New System.Windows.Forms.ToolBar()
        Me.Sep0 = New System.Windows.Forms.ToolBarButton()
        Me.btnModificar = New System.Windows.Forms.ToolBarButton()
        Me.Sep1 = New System.Windows.Forms.ToolBarButton()
        Me.btnFiltro = New System.Windows.Forms.ToolBarButton()
        Me.mnuFiltro = New System.Windows.Forms.ContextMenu()
        Me.mniTodos = New System.Windows.Forms.MenuItem()
        Me.mniActivos = New System.Windows.Forms.MenuItem()
        Me.mniInactivos = New System.Windows.Forms.MenuItem()
        Me.btnBuscar = New System.Windows.Forms.ToolBarButton()
        Me.Sep2 = New System.Windows.Forms.ToolBarButton()
        Me.btnActualizar = New System.Windows.Forms.ToolBarButton()
        Me.Sep3 = New System.Windows.Forms.ToolBarButton()
        Me.btnCerrar = New System.Windows.Forms.ToolBarButton()
        Me.Sep4 = New System.Windows.Forms.ToolBarButton()
        Me.imgHerramientas = New System.Windows.Forms.ImageList(Me.components)
        Me.pnlDatosAdicionales.SuspendLayout()
        Me.pnlTitulo.SuspendLayout()
        Me.SuspendLayout()
        '
        'mnuAutotanque
        '
        Me.mnuAutotanque.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuCatalogo})
        '
        'mnuCatalogo
        '
        Me.mnuCatalogo.Index = 0
        Me.mnuCatalogo.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mniAutotanque})
        Me.mnuCatalogo.MergeOrder = 1
        Me.mnuCatalogo.MergeType = System.Windows.Forms.MenuMerge.MergeItems
        Me.mnuCatalogo.Text = "&Catálogos"
        '
        'mniAutotanque
        '
        Me.mniAutotanque.Index = 0
        Me.mniAutotanque.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mniModificar, Me.Sepm0, Me.mniBuscar, Me.Sepm2, Me.mniActualizar, Me.Sepm3, Me.mniCerrar})
        Me.mniAutotanque.MergeOrder = 3
        Me.mniAutotanque.MergeType = System.Windows.Forms.MenuMerge.MergeItems
        Me.mniAutotanque.Text = "Au&totanque"
        '
        'mniModificar
        '
        Me.mniModificar.Index = 0
        Me.mniModificar.Shortcut = System.Windows.Forms.Shortcut.CtrlIns
        Me.mniModificar.Text = "&Modificar"
        '
        'Sepm0
        '
        Me.Sepm0.Index = 1
        Me.Sepm0.Text = "-"
        '
        'mniBuscar
        '
        Me.mniBuscar.Index = 2
        Me.mniBuscar.Text = "&Buscar"
        '
        'Sepm2
        '
        Me.Sepm2.Index = 3
        Me.Sepm2.Text = "-"
        '
        'mniActualizar
        '
        Me.mniActualizar.Index = 4
        Me.mniActualizar.Shortcut = System.Windows.Forms.Shortcut.F5
        Me.mniActualizar.Text = "Ac&tualizar"
        '
        'Sepm3
        '
        Me.Sepm3.Index = 5
        Me.Sepm3.Text = "-"
        '
        'mniCerrar
        '
        Me.mniCerrar.Index = 6
        Me.mniCerrar.Text = "&Cerrar"
        '
        'pnlDatosAdicionales
        '
        Me.pnlDatosAdicionales.BackColor = System.Drawing.Color.AntiqueWhite
        Me.pnlDatosAdicionales.Controls.AddRange(New System.Windows.Forms.Control() {Me.txtMarca, Me.lblMarca, Me.txtStatus, Me.txtProducto, Me.txtPropietario, Me.txtTipo, Me.lblStatus, Me.lblProducto, Me.lblPropietario, Me.lblTipo})
        Me.pnlDatosAdicionales.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlDatosAdicionales.Location = New System.Drawing.Point(0, 465)
        Me.pnlDatosAdicionales.Name = "pnlDatosAdicionales"
        Me.pnlDatosAdicionales.Size = New System.Drawing.Size(768, 112)
        Me.pnlDatosAdicionales.TabIndex = 2
        '
        'txtMarca
        '
        Me.txtMarca.BackColor = System.Drawing.SystemColors.Window
        Me.txtMarca.Location = New System.Drawing.Point(421, 10)
        Me.txtMarca.Name = "txtMarca"
        Me.txtMarca.ReadOnly = True
        Me.txtMarca.Size = New System.Drawing.Size(216, 21)
        Me.txtMarca.TabIndex = 23
        Me.txtMarca.Text = ""
        '
        'lblMarca
        '
        Me.lblMarca.AutoSize = True
        Me.lblMarca.ForeColor = System.Drawing.Color.Black
        Me.lblMarca.Location = New System.Drawing.Point(370, 13)
        Me.lblMarca.Name = "lblMarca"
        Me.lblMarca.Size = New System.Drawing.Size(38, 14)
        Me.lblMarca.TabIndex = 22
        Me.lblMarca.Text = "Marca:"
        '
        'txtStatus
        '
        Me.txtStatus.BackColor = System.Drawing.SystemColors.Window
        Me.txtStatus.Location = New System.Drawing.Point(421, 46)
        Me.txtStatus.Name = "txtStatus"
        Me.txtStatus.ReadOnly = True
        Me.txtStatus.Size = New System.Drawing.Size(78, 21)
        Me.txtStatus.TabIndex = 21
        Me.txtStatus.Text = ""
        '
        'txtProducto
        '
        Me.txtProducto.BackColor = System.Drawing.SystemColors.Window
        Me.txtProducto.Location = New System.Drawing.Point(104, 82)
        Me.txtProducto.Name = "txtProducto"
        Me.txtProducto.ReadOnly = True
        Me.txtProducto.Size = New System.Drawing.Size(204, 21)
        Me.txtProducto.TabIndex = 20
        Me.txtProducto.Text = ""
        '
        'txtPropietario
        '
        Me.txtPropietario.BackColor = System.Drawing.SystemColors.Window
        Me.txtPropietario.Location = New System.Drawing.Point(104, 46)
        Me.txtPropietario.Name = "txtPropietario"
        Me.txtPropietario.ReadOnly = True
        Me.txtPropietario.Size = New System.Drawing.Size(204, 21)
        Me.txtPropietario.TabIndex = 19
        Me.txtPropietario.Text = ""
        '
        'txtTipo
        '
        Me.txtTipo.BackColor = System.Drawing.SystemColors.Window
        Me.txtTipo.Location = New System.Drawing.Point(104, 10)
        Me.txtTipo.Name = "txtTipo"
        Me.txtTipo.ReadOnly = True
        Me.txtTipo.Size = New System.Drawing.Size(204, 21)
        Me.txtTipo.TabIndex = 18
        Me.txtTipo.Text = ""
        '
        'lblStatus
        '
        Me.lblStatus.AutoSize = True
        Me.lblStatus.ForeColor = System.Drawing.Color.Black
        Me.lblStatus.Location = New System.Drawing.Point(370, 49)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(39, 14)
        Me.lblStatus.TabIndex = 17
        Me.lblStatus.Text = "Status:"
        '
        'lblProducto
        '
        Me.lblProducto.AutoSize = True
        Me.lblProducto.ForeColor = System.Drawing.Color.Black
        Me.lblProducto.Location = New System.Drawing.Point(12, 85)
        Me.lblProducto.Name = "lblProducto"
        Me.lblProducto.Size = New System.Drawing.Size(52, 14)
        Me.lblProducto.TabIndex = 16
        Me.lblProducto.Text = "Producto:"
        '
        'lblPropietario
        '
        Me.lblPropietario.AutoSize = True
        Me.lblPropietario.ForeColor = System.Drawing.Color.Black
        Me.lblPropietario.Location = New System.Drawing.Point(12, 49)
        Me.lblPropietario.Name = "lblPropietario"
        Me.lblPropietario.Size = New System.Drawing.Size(62, 14)
        Me.lblPropietario.TabIndex = 15
        Me.lblPropietario.Text = "Propietario:"
        '
        'lblTipo
        '
        Me.lblTipo.AutoSize = True
        Me.lblTipo.ForeColor = System.Drawing.Color.Black
        Me.lblTipo.Location = New System.Drawing.Point(12, 13)
        Me.lblTipo.Name = "lblTipo"
        Me.lblTipo.Size = New System.Drawing.Size(90, 14)
        Me.lblTipo.TabIndex = 14
        Me.lblTipo.Text = "Tipo de vehículo:"
        '
        'cboCelula
        '
        Me.cboCelula.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCelula.Location = New System.Drawing.Point(556, 11)
        Me.cboCelula.Name = "cboCelula"
        Me.cboCelula.TabIndex = 5
        '
        'lblCelula
        '
        Me.lblCelula.AutoSize = True
        Me.lblCelula.ForeColor = System.Drawing.Color.Black
        Me.lblCelula.Location = New System.Drawing.Point(516, 11)
        Me.lblCelula.Name = "lblCelula"
        Me.lblCelula.Size = New System.Drawing.Size(38, 14)
        Me.lblCelula.TabIndex = 4
        Me.lblCelula.Text = "&Célula:"
        '
        'vgrdCatalogo
        '
        Me.vgrdCatalogo.AlternativeBackColor = System.Drawing.Color.Cornsilk
        Me.vgrdCatalogo.BackColor = System.Drawing.Color.FloralWhite
        Me.vgrdCatalogo.CheckCondition = Nothing
        Me.vgrdCatalogo.DataSource = Nothing
        Me.vgrdCatalogo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.vgrdCatalogo.FormatColumnNames = New String(-1) {}
        Me.vgrdCatalogo.FullRowSelect = True
        Me.vgrdCatalogo.GridLines = True
        Me.vgrdCatalogo.HidedColumnNames = New String() {"Celula", "Marca", "Status", "Tipo", "Propietario", "Producto"}
        Me.vgrdCatalogo.HideSelection = False
        Me.vgrdCatalogo.Location = New System.Drawing.Point(24, 39)
        Me.vgrdCatalogo.MultiSelect = False
        Me.vgrdCatalogo.Name = "vgrdCatalogo"
        Me.vgrdCatalogo.NullText = ""
        Me.vgrdCatalogo.PKColumnNames = New String() {"Autotanque"}
        Me.vgrdCatalogo.Size = New System.Drawing.Size(744, 426)
        Me.vgrdCatalogo.TabIndex = 6
        Me.vgrdCatalogo.View = System.Windows.Forms.View.Details
        '
        'pnlTitulo
        '
        Me.pnlTitulo.Controls.AddRange(New System.Windows.Forms.Control() {Me.rlblTitulo})
        Me.pnlTitulo.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlTitulo.Location = New System.Drawing.Point(0, 39)
        Me.pnlTitulo.Name = "pnlTitulo"
        Me.pnlTitulo.Size = New System.Drawing.Size(24, 426)
        Me.pnlTitulo.TabIndex = 7
        '
        'rlblTitulo
        '
        Me.rlblTitulo.Border = False
        Me.rlblTitulo.Caption = "Autotanques de célula x"
        Me.rlblTitulo.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.rlblTitulo.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rlblTitulo.ForeColor = System.Drawing.Color.DarkSlateBlue
        Me.rlblTitulo.Location = New System.Drawing.Point(0, 158)
        Me.rlblTitulo.Name = "rlblTitulo"
        Me.rlblTitulo.RotationAngle = 270
        Me.rlblTitulo.Size = New System.Drawing.Size(25, 268)
        Me.rlblTitulo.TabIndex = 6
        '
        'tbOperador
        '
        Me.tbOperador.Appearance = System.Windows.Forms.ToolBarAppearance.Flat
        Me.tbOperador.Buttons.AddRange(New System.Windows.Forms.ToolBarButton() {Me.Sep0, Me.btnModificar, Me.Sep1, Me.btnFiltro, Me.btnBuscar, Me.Sep2, Me.btnActualizar, Me.Sep3, Me.btnCerrar, Me.Sep4})
        Me.tbOperador.DropDownArrows = True
        Me.tbOperador.ImageList = Me.imgHerramientas
        Me.tbOperador.Name = "tbOperador"
        Me.tbOperador.ShowToolTips = True
        Me.tbOperador.Size = New System.Drawing.Size(768, 39)
        Me.tbOperador.TabIndex = 8
        '
        'Sep0
        '
        Me.Sep0.Style = System.Windows.Forms.ToolBarButtonStyle.Separator
        '
        'btnModificar
        '
        Me.btnModificar.ImageIndex = 2
        Me.btnModificar.Text = "Modificar"
        '
        'Sep1
        '
        Me.Sep1.Style = System.Windows.Forms.ToolBarButtonStyle.Separator
        '
        'btnFiltro
        '
        Me.btnFiltro.DropDownMenu = Me.mnuFiltro
        Me.btnFiltro.ImageIndex = 7
        Me.btnFiltro.Style = System.Windows.Forms.ToolBarButtonStyle.DropDownButton
        Me.btnFiltro.Text = "Filtro"
        '
        'mnuFiltro
        '
        Me.mnuFiltro.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mniTodos, Me.mniActivos, Me.mniInactivos})
        '
        'mniTodos
        '
        Me.mniTodos.Checked = True
        Me.mniTodos.Index = 0
        Me.mniTodos.RadioCheck = True
        Me.mniTodos.Text = "&Todos"
        '
        'mniActivos
        '
        Me.mniActivos.Index = 1
        Me.mniActivos.Text = "&Activos"
        '
        'mniInactivos
        '
        Me.mniInactivos.Index = 2
        Me.mniInactivos.Text = "&Inactivos"
        '
        'btnBuscar
        '
        Me.btnBuscar.ImageIndex = 4
        Me.btnBuscar.Text = "Buscar"
        '
        'Sep2
        '
        Me.Sep2.Style = System.Windows.Forms.ToolBarButtonStyle.Separator
        '
        'btnActualizar
        '
        Me.btnActualizar.ImageIndex = 5
        Me.btnActualizar.Text = "Actualizar"
        '
        'Sep3
        '
        Me.Sep3.Style = System.Windows.Forms.ToolBarButtonStyle.Separator
        '
        'btnCerrar
        '
        Me.btnCerrar.ImageIndex = 6
        Me.btnCerrar.Text = "Cerrar"
        '
        'Sep4
        '
        Me.Sep4.Style = System.Windows.Forms.ToolBarButtonStyle.Separator
        '
        'imgHerramientas
        '
        Me.imgHerramientas.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit
        Me.imgHerramientas.ImageSize = New System.Drawing.Size(16, 16)
        Me.imgHerramientas.ImageStream = CType(resources.GetObject("imgHerramientas.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imgHerramientas.TransparentColor = System.Drawing.Color.Transparent
        '
        'frmAutotanque
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 14)
        Me.BackColor = System.Drawing.Color.OldLace
        Me.ClientSize = New System.Drawing.Size(768, 577)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.vgrdCatalogo, Me.pnlTitulo, Me.cboCelula, Me.lblCelula, Me.pnlDatosAdicionales, Me.tbOperador})
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ForeColor = System.Drawing.Color.Black
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Menu = Me.mnuAutotanque
        Me.Name = "frmAutotanque"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Catálogo de autotanques"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.pnlDatosAdicionales.ResumeLayout(False)
        Me.pnlTitulo.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Variables globales"
    Dim dtAutotanque As New DataTable()
    Dim Filtro As String
#End Region

#Region "Rutinas de actualización"
    Public Sub CargaInformacion()
        If Not cboCelula.SelectedValue Is Nothing Then
            Dim daLogistica As New SqlDataAdapter("Select * from vwLOGAutotanque Where Celula = @Celula", Globales.GetInstance.cnSigamet)
            Dim PKColumn(0) As DataColumn
            vgrdCatalogo.DataSource = Nothing
            daLogistica.SelectCommand.Parameters.Add("@Celula", SqlDbType.TinyInt).Value = CInt(cboCelula.SelectedValue)
            If Filtro <> "" Then
                daLogistica.SelectCommand.CommandText &= Filtro
            End If
            daLogistica.SelectCommand.CommandText &= " order by Autotanque"
            Try
                dtAutotanque.Clear()
                daLogistica.Fill(dtAutotanque)
                PKColumn(0) = dtAutotanque.Columns(0)
                dtAutotanque.PrimaryKey = PKColumn
                vgrdCatalogo.DataSource = dtAutotanque
                CargaDatosAdicionales()
            Catch ex As Exception
                Globales.GetInstance.ExMessage(ex)
            End Try
        End If
    End Sub
    Public Sub CargaDatosAdicionales()
        If Not vgrdCatalogo.CurrentRow Is Nothing Then
            Dim FoundRow As DataRow = vgrdCatalogo.CurrentRow
            If Not FoundRow Is Nothing Then
                txtTipo.Text = CStr(FoundRow("Tipo"))
                txtPropietario.Text = CStr(FoundRow("Propietario"))
                txtProducto.Text = CStr(FoundRow("Producto"))
                txtMarca.Text = CStr(FoundRow("Marca"))
                txtStatus.Text = CStr(FoundRow("Status"))
            Else
                txtTipo.Clear()
                txtPropietario.Clear()
                txtProducto.Clear()
                txtMarca.Clear()
                txtStatus.Clear()
            End If
        Else
            txtTipo.Clear()
            txtPropietario.Clear()
            txtProducto.Clear()
            txtMarca.Clear()
            txtStatus.Clear()
        End If
    End Sub
    Private Sub mniFiltro_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mniTodos.Click, mniActivos.Click, mniInactivos.Click
        mniTodos.Checked = False
        mniActivos.Checked = False
        mniInactivos.Checked = False
        CType(sender, MenuItem).Checked = True
        Select Case CType(sender, MenuItem).Text
            Case "&Todos"
                Filtro = ""
                rlblTitulo.Caption = "Autotanques de célula " & CStr(cboCelula.SelectedValue)
            Case "&Activos"
                Filtro = " and Status = 'ACTIVO'"
                rlblTitulo.Caption = "Autotanques activos de célula " & CStr(cboCelula.SelectedValue)
            Case "&Inactivos"
                Filtro = " and Status = 'INACTIVO'"
                rlblTitulo.Caption = "Autotanques inactivos de célula " & CStr(cboCelula.SelectedValue)
        End Select
        CargaInformacion()
    End Sub
    Private Sub cboCelula_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboCelula.SelectedValueChanged
        If Not cboCelula.SelectedValue Is Nothing Then
            CargaInformacion()
            If mniTodos.Checked Then
                rlblTitulo.Caption = "Autotanques de célula " & CStr(cboCelula.SelectedValue)
            ElseIf mniActivos.Checked Then
                rlblTitulo.Caption = "Autotanques activos de célula " & CStr(cboCelula.SelectedValue)
            Else
                rlblTitulo.Caption = "Autotanques inactivos de célula " & CStr(cboCelula.SelectedValue)
            End If
        End If
    End Sub
    Private Sub vgrdCatalogo_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles vgrdCatalogo.SelectedIndexChanged
        CargaDatosAdicionales()
    End Sub
#End Region

#Region "Rutinas de menus y herramientas"
    Private Sub mniCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mniCerrar.Click
        Me.Close()
        Me.Dispose()
    End Sub
    Private Sub mniModificar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mniModificar.Click
        Modificar()
    End Sub
    Private Sub mniBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mniBuscar.Click
        Buscar()
    End Sub
    Private Sub mniActualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mniActualizar.Click
        CargaInformacion()
        CargaDatosAdicionales()
    End Sub

    Private Sub tbOperador_ButtonClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolBarButtonClickEventArgs) Handles tbOperador.ButtonClick
        Select Case e.Button.Text
            Case "Modificar"
                Modificar()
            Case "Buscar"
                Buscar()
            Case "Actualizar"
                CargaInformacion()
                CargaDatosAdicionales()
            Case "Cerrar"
                Me.Close()
                Me.Dispose()
        End Select
    End Sub
#End Region

#Region "Rutina de manejo de datos"
    Private Sub Modificar()
        'Validación de selección en grid
        If Not vgrdCatalogo.CurrentRow Is Nothing Then
            'Creación y carga de formulario
            Dim frmCapturaAutotanque As New frmCapturaAutotanque(CInt(cboCelula.SelectedValue), CInt(CType(vgrdCatalogo.CurrentPK, Object())(0)))
            frmCapturaAutotanque.ShowDialog()
            'Validación de resultados
            If frmCapturaAutotanque.DialogResult = DialogResult.OK Then
                'Carga de información
                CargaInformacion()
                CargaDatosAdicionales()
                'Recuperación de posición en grid
                vgrdCatalogo.FindFirst("Autotanque", frmCapturaAutotanque.txtAutotanque.Text)
                vgrdCatalogo.Focus()
            End If
            'Eliminación de objetos
            frmCapturaAutotanque.Dispose()
        End If
    End Sub
    Private Sub Buscar()
        'Petición de busqueda
        Dim Operador As String = InputBox("No. de autotanque:")
        'Validación de texto de busqueda
        If Trim(Operador) <> "" Then
            'Busqueda
            If vgrdCatalogo.FindFirst("Autotanque", Trim(Operador)) < 0 Then
                MessageBox.Show("No se ha encontrado el autotanque no. " & Trim(Operador), Application.ProductName & " v." & Application.ProductVersion, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                vgrdCatalogo.Focus()
            End If
        End If
    End Sub

#End Region





End Class
