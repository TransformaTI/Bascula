Public Class frmParametros
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
    Friend WithEvents mnuParametros As System.Windows.Forms.MainMenu
    Friend WithEvents mniHerramientas As System.Windows.Forms.MenuItem
    Friend WithEvents mniParametros As System.Windows.Forms.MenuItem
    Friend WithEvents imgParametros As System.Windows.Forms.ImageList
    Friend WithEvents tbParametros As System.Windows.Forms.ToolBar
    Friend WithEvents btnModificar As System.Windows.Forms.ToolBarButton
    Friend WithEvents Sep0 As System.Windows.Forms.ToolBarButton
    Friend WithEvents btnActualizar As System.Windows.Forms.ToolBarButton
    Friend WithEvents Sep1 As System.Windows.Forms.ToolBarButton
    Friend WithEvents btnCerrar As System.Windows.Forms.ToolBarButton
    Friend WithEvents mniModificar As System.Windows.Forms.MenuItem
    Friend WithEvents Sepm0 As System.Windows.Forms.MenuItem
    Friend WithEvents mniActualizar As System.Windows.Forms.MenuItem
    Friend WithEvents Sepm1 As System.Windows.Forms.MenuItem
    Friend WithEvents mniCerrar As System.Windows.Forms.MenuItem
    Friend WithEvents vgParametros As Bascula.ViewGrid
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmParametros))
        Me.mnuParametros = New System.Windows.Forms.MainMenu()
        Me.mniHerramientas = New System.Windows.Forms.MenuItem()
        Me.mniParametros = New System.Windows.Forms.MenuItem()
        Me.mniModificar = New System.Windows.Forms.MenuItem()
        Me.Sepm0 = New System.Windows.Forms.MenuItem()
        Me.mniActualizar = New System.Windows.Forms.MenuItem()
        Me.Sepm1 = New System.Windows.Forms.MenuItem()
        Me.mniCerrar = New System.Windows.Forms.MenuItem()
        Me.imgParametros = New System.Windows.Forms.ImageList(Me.components)
        Me.tbParametros = New System.Windows.Forms.ToolBar()
        Me.btnModificar = New System.Windows.Forms.ToolBarButton()
        Me.Sep0 = New System.Windows.Forms.ToolBarButton()
        Me.btnActualizar = New System.Windows.Forms.ToolBarButton()
        Me.Sep1 = New System.Windows.Forms.ToolBarButton()
        Me.btnCerrar = New System.Windows.Forms.ToolBarButton()
        Me.vgParametros = New Bascula.ViewGrid()
        Me.SuspendLayout()
        '
        'mnuParametros
        '
        Me.mnuParametros.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mniHerramientas})
        '
        'mniHerramientas
        '
        Me.mniHerramientas.Index = 0
        Me.mniHerramientas.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mniParametros})
        Me.mniHerramientas.MergeOrder = 3
        Me.mniHerramientas.MergeType = System.Windows.Forms.MenuMerge.MergeItems
        Me.mniHerramientas.Text = "&Herramientas"
        '
        'mniParametros
        '
        Me.mniParametros.Index = 0
        Me.mniParametros.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mniModificar, Me.Sepm0, Me.mniActualizar, Me.Sepm1, Me.mniCerrar})
        Me.mniParametros.MergeOrder = 1
        Me.mniParametros.MergeType = System.Windows.Forms.MenuMerge.MergeItems
        Me.mniParametros.Text = "&Parametros"
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
        'mniActualizar
        '
        Me.mniActualizar.Index = 2
        Me.mniActualizar.Shortcut = System.Windows.Forms.Shortcut.F5
        Me.mniActualizar.Text = "&Actualizar"
        '
        'Sepm1
        '
        Me.Sepm1.Index = 3
        Me.Sepm1.Text = "-"
        '
        'mniCerrar
        '
        Me.mniCerrar.Index = 4
        Me.mniCerrar.Text = "&Cerrar"
        '
        'imgParametros
        '
        Me.imgParametros.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit
        Me.imgParametros.ImageSize = New System.Drawing.Size(16, 16)
        Me.imgParametros.ImageStream = CType(resources.GetObject("imgParametros.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imgParametros.TransparentColor = System.Drawing.Color.Transparent
        '
        'tbParametros
        '
        Me.tbParametros.Appearance = System.Windows.Forms.ToolBarAppearance.Flat
        Me.tbParametros.Buttons.AddRange(New System.Windows.Forms.ToolBarButton() {Me.btnModificar, Me.Sep0, Me.btnActualizar, Me.Sep1, Me.btnCerrar})
        Me.tbParametros.DropDownArrows = True
        Me.tbParametros.ImageList = Me.imgParametros
        Me.tbParametros.Name = "tbParametros"
        Me.tbParametros.ShowToolTips = True
        Me.tbParametros.Size = New System.Drawing.Size(504, 39)
        Me.tbParametros.TabIndex = 0
        '
        'btnModificar
        '
        Me.btnModificar.ImageIndex = 0
        Me.btnModificar.Text = "Modificar"
        Me.btnModificar.ToolTipText = "Modificar el parámetro seleccionado"
        '
        'Sep0
        '
        Me.Sep0.Style = System.Windows.Forms.ToolBarButtonStyle.Separator
        '
        'btnActualizar
        '
        Me.btnActualizar.ImageIndex = 1
        Me.btnActualizar.Text = "Actualizar"
        Me.btnActualizar.ToolTipText = "Cargar los datos más recientes"
        '
        'Sep1
        '
        Me.Sep1.Style = System.Windows.Forms.ToolBarButtonStyle.Separator
        '
        'btnCerrar
        '
        Me.btnCerrar.ImageIndex = 2
        Me.btnCerrar.Text = "Cerrar"
        Me.btnCerrar.ToolTipText = "Cerrar el catálogo de parámetros"
        '
        'vgParametros
        '
        Me.vgParametros.AlternativeBackColor = System.Drawing.Color.Gainsboro
        Me.vgParametros.CheckCondition = Nothing
        Me.vgParametros.DataSource = Nothing
        Me.vgParametros.Dock = System.Windows.Forms.DockStyle.Fill
        Me.vgParametros.FormatColumnNames = New String(-1) {}
        Me.vgParametros.FullRowSelect = True
        Me.vgParametros.GridLines = True
        Me.vgParametros.HidedColumnNames = New String(-1) {}
        Me.vgParametros.HideSelection = False
        Me.vgParametros.Location = New System.Drawing.Point(0, 39)
        Me.vgParametros.MultiSelect = False
        Me.vgParametros.Name = "vgParametros"
        Me.vgParametros.PKColumnNames = Nothing
        Me.vgParametros.Size = New System.Drawing.Size(504, 454)
        Me.vgParametros.TabIndex = 1
        Me.vgParametros.View = System.Windows.Forms.View.Details
        '
        'frmParametros
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 14)
        Me.BackColor = System.Drawing.Color.Gainsboro
        Me.ClientSize = New System.Drawing.Size(504, 493)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.vgParametros, Me.tbParametros})
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Menu = Me.mnuParametros
        Me.MinimizeBox = False
        Me.Name = "frmParametros"
        Me.ShowInTaskbar = False
        Me.Text = "Parámetros"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Parametro As String

    Private Sub Actualizar()
        Dim cmdBascula As New SqlCommand("Select * from vwBASParametros", Globales.GetInstance.cnSigamet)
        Dim daBascula As New SqlDataAdapter(cmdBascula)
        Dim dtParametros As New DataTable()
        Try
            daBascula.Fill(dtParametros)
        Catch ex As Exception
            Globales.GetInstance.ExMessage(ex)
        End Try
        vgParametros.DataSource = dtParametros
        vgParametros.FindFirst("Parametro", Parametro)
    End Sub

    Private Sub Modificar()
        If Not vgParametros.CurrentRow Is Nothing Then
            Try
                Dim NuevoValor As Decimal
                Dim ValAnterior As String = CStr(vgParametros.CurrentRow("Valor")).Trim
                Dim Input As String = InputBox("Nuevo valor para el parámetro " & CStr(vgParametros.CurrentRow("Parametro")).Trim & ":" _
                                    , Application.ProductName & " v." & _
                                    Application.ProductVersion).Trim
                Dim cmdBascula As SqlCommand
                If Input <> "" Then
                    NuevoValor = CDec(Input)
                    cmdBascula = New SqlCommand("exec spBASCambiaParametro @Parametro, @NuevoValor, @Usuario, @ValorAnterior", Globales.GetInstance.cnSigamet)
                    cmdBascula.Parameters.Add("@NuevoValor", SqlDbType.Char).Value = NuevoValor.ToString
                    cmdBascula.Parameters.Add("@Parametro", SqlDbType.Char).Value = vgParametros.CurrentRow("Parametro")
                    cmdBascula.Parameters.Add("@Usuario", SqlDbType.Char).Value = Globales.GetInstance._Usuario
                    cmdBascula.Parameters.Add("@ValorAnterior", SqlDbType.Char).Value = ValAnterior
                    Globales.GetInstance.AbreConexion()
                    cmdBascula.ExecuteNonQuery()
                    Globales.GetInstance.CierraConexion()
                    Actualizar()
                End If
            Catch ex As InvalidCastException
                Globales.GetInstance.ErrMessage("El valor escrito es incorrecto." & Chr(13) & "Verifique.")
                Modificar()
            Catch ex As Exception
                Globales.GetInstance.ExMessage(ex)
            Finally
                Globales.GetInstance.CierraConexion()
            End Try
        End If
    End Sub

    Private Sub tbParametros_ButtonClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolBarButtonClickEventArgs) Handles tbParametros.ButtonClick
        Select Case e.Button.Text
            Case "Modificar"
                Modificar()
            Case "Actualizar"
                Actualizar()
            Case "Cerrar"
                Me.Close()
                Me.Dispose()
        End Select
    End Sub

    Private Sub mniModificar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mniModificar.Click
        Modificar()
    End Sub

    Private Sub mniActualizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mniActualizar.Click
        Actualizar()
    End Sub

    Private Sub mniCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mniCerrar.Click
        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub vgParametros_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles vgParametros.SelectedIndexChanged
        If Not vgParametros.CurrentRow Is Nothing Then
            Parametro = CStr(vgParametros.CurrentRow("Parametro"))
        Else
            Parametro = ""
        End If
    End Sub
End Class
