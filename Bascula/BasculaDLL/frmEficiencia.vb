Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared


Public Class frmEficiencia
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

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
    Friend WithEvents lblFechaInicio As System.Windows.Forms.Label
    Friend WithEvents lblEficiencia As System.Windows.Forms.Label
    Friend WithEvents cmbEficiencia As System.Windows.Forms.ComboBox
    Friend WithEvents btnBuscar As System.Windows.Forms.Button
    Friend WithEvents chkSeleccionarTodos As System.Windows.Forms.CheckBox
    Friend WithEvents dtpFechaInicio As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpFechaFinal As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblFechaFinal As System.Windows.Forms.Label
    Friend WithEvents crvReporte As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents imgIconos As System.Windows.Forms.ImageList
    Friend WithEvents tbEficicnecia As System.Windows.Forms.ToolBar
    Friend WithEvents tbBtnGenerar As System.Windows.Forms.ToolBarButton
    Friend WithEvents tbBtnImprimir As System.Windows.Forms.ToolBarButton
    Friend WithEvents tbBtnCerrar As System.Windows.Forms.ToolBarButton
    Friend WithEvents lblNumReg As System.Windows.Forms.Label
    Friend WithEvents lblNumeroRegistros As System.Windows.Forms.Label
    Friend WithEvents lblNoImp As System.Windows.Forms.Label
    Friend WithEvents lblNumeroImpresiones As System.Windows.Forms.Label
    Friend WithEvents lvwEficiencias As GasMetropolitano2002.Runtime.Controls.ListViewObject
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmEficiencia))
        Me.lblFechaInicio = New System.Windows.Forms.Label()
        Me.dtpFechaInicio = New System.Windows.Forms.DateTimePicker()
        Me.lblEficiencia = New System.Windows.Forms.Label()
        Me.cmbEficiencia = New System.Windows.Forms.ComboBox()
        Me.btnBuscar = New System.Windows.Forms.Button()
        Me.chkSeleccionarTodos = New System.Windows.Forms.CheckBox()
        Me.dtpFechaFinal = New System.Windows.Forms.DateTimePicker()
        Me.lblFechaFinal = New System.Windows.Forms.Label()
        Me.imgIconos = New System.Windows.Forms.ImageList(Me.components)
        Me.crvReporte = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
        Me.tbEficicnecia = New System.Windows.Forms.ToolBar()
        Me.tbBtnGenerar = New System.Windows.Forms.ToolBarButton()
        Me.tbBtnImprimir = New System.Windows.Forms.ToolBarButton()
        Me.tbBtnCerrar = New System.Windows.Forms.ToolBarButton()
        Me.lblNumReg = New System.Windows.Forms.Label()
        Me.lblNumeroRegistros = New System.Windows.Forms.Label()
        Me.lblNoImp = New System.Windows.Forms.Label()
        Me.lblNumeroImpresiones = New System.Windows.Forms.Label()
        Me.lvwEficiencias = New GasMetropolitano2002.Runtime.Controls.ListViewObject()
        Me.SuspendLayout()
        '
        'lblFechaInicio
        '
        Me.lblFechaInicio.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblFechaInicio.Location = New System.Drawing.Point(274, 12)
        Me.lblFechaInicio.Name = "lblFechaInicio"
        Me.lblFechaInicio.Size = New System.Drawing.Size(72, 16)
        Me.lblFechaInicio.TabIndex = 0
        Me.lblFechaInicio.Text = "Fecha inicial:"
        '
        'dtpFechaInicio
        '
        Me.dtpFechaInicio.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtpFechaInicio.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaInicio.Location = New System.Drawing.Point(346, 8)
        Me.dtpFechaInicio.Name = "dtpFechaInicio"
        Me.dtpFechaInicio.Size = New System.Drawing.Size(104, 20)
        Me.dtpFechaInicio.TabIndex = 1
        '
        'lblEficiencia
        '
        Me.lblEficiencia.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblEficiencia.Location = New System.Drawing.Point(658, 12)
        Me.lblEficiencia.Name = "lblEficiencia"
        Me.lblEficiencia.Size = New System.Drawing.Size(64, 13)
        Me.lblEficiencia.TabIndex = 2
        Me.lblEficiencia.Text = "Eficiencia :"
        '
        'cmbEficiencia
        '
        Me.cmbEficiencia.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbEficiencia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbEficiencia.Location = New System.Drawing.Point(728, 8)
        Me.cmbEficiencia.Name = "cmbEficiencia"
        Me.cmbEficiencia.Size = New System.Drawing.Size(112, 21)
        Me.cmbEficiencia.TabIndex = 3
        '
        'btnBuscar
        '
        Me.btnBuscar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnBuscar.Location = New System.Drawing.Point(968, 8)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(75, 23)
        Me.btnBuscar.TabIndex = 4
        Me.btnBuscar.Text = "Buscar"
        '
        'chkSeleccionarTodos
        '
        Me.chkSeleccionarTodos.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.chkSeleccionarTodos.Location = New System.Drawing.Point(870, 12)
        Me.chkSeleccionarTodos.Name = "chkSeleccionarTodos"
        Me.chkSeleccionarTodos.Size = New System.Drawing.Size(94, 16)
        Me.chkSeleccionarTodos.TabIndex = 5
        Me.chkSeleccionarTodos.Text = "Marcar Todos"
        Me.chkSeleccionarTodos.Visible = False
        '
        'dtpFechaFinal
        '
        Me.dtpFechaFinal.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dtpFechaFinal.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaFinal.Location = New System.Drawing.Point(544, 8)
        Me.dtpFechaFinal.Name = "dtpFechaFinal"
        Me.dtpFechaFinal.Size = New System.Drawing.Size(104, 20)
        Me.dtpFechaFinal.TabIndex = 7
        '
        'lblFechaFinal
        '
        Me.lblFechaFinal.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblFechaFinal.Location = New System.Drawing.Point(469, 12)
        Me.lblFechaFinal.Name = "lblFechaFinal"
        Me.lblFechaFinal.Size = New System.Drawing.Size(72, 16)
        Me.lblFechaFinal.TabIndex = 6
        Me.lblFechaFinal.Text = "Fecha final:"
        '
        'imgIconos
        '
        Me.imgIconos.ImageStream = CType(resources.GetObject("imgIconos.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imgIconos.TransparentColor = System.Drawing.Color.Transparent
        Me.imgIconos.Images.SetKeyName(0, "")
        Me.imgIconos.Images.SetKeyName(1, "")
        Me.imgIconos.Images.SetKeyName(2, "")
        '
        'crvReporte
        '
        Me.crvReporte.ActiveViewIndex = -1
        Me.crvReporte.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.crvReporte.Cursor = System.Windows.Forms.Cursors.Default
        Me.crvReporte.Location = New System.Drawing.Point(48, 304)
        Me.crvReporte.Name = "crvReporte"
        Me.crvReporte.Size = New System.Drawing.Size(616, 32)
        Me.crvReporte.TabIndex = 8
        '
        'tbEficicnecia
        '
        Me.tbEficicnecia.Buttons.AddRange(New System.Windows.Forms.ToolBarButton() {Me.tbBtnGenerar, Me.tbBtnImprimir, Me.tbBtnCerrar})
        Me.tbEficicnecia.DropDownArrows = True
        Me.tbEficicnecia.ImageList = Me.imgIconos
        Me.tbEficicnecia.Location = New System.Drawing.Point(0, 0)
        Me.tbEficicnecia.Name = "tbEficicnecia"
        Me.tbEficicnecia.ShowToolTips = True
        Me.tbEficicnecia.Size = New System.Drawing.Size(1056, 58)
        Me.tbEficicnecia.TabIndex = 10
        '
        'tbBtnGenerar
        '
        Me.tbBtnGenerar.ImageIndex = 0
        Me.tbBtnGenerar.Name = "tbBtnGenerar"
        Me.tbBtnGenerar.Text = "Generar"
        '
        'tbBtnImprimir
        '
        Me.tbBtnImprimir.ImageIndex = 1
        Me.tbBtnImprimir.Name = "tbBtnImprimir"
        Me.tbBtnImprimir.Text = "Imprimir"
        '
        'tbBtnCerrar
        '
        Me.tbBtnCerrar.ImageIndex = 2
        Me.tbBtnCerrar.Name = "tbBtnCerrar"
        Me.tbBtnCerrar.Text = "Cerrar"
        '
        'lblNumReg
        '
        Me.lblNumReg.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNumReg.Location = New System.Drawing.Point(160, 30)
        Me.lblNumReg.Name = "lblNumReg"
        Me.lblNumReg.Size = New System.Drawing.Size(120, 16)
        Me.lblNumReg.TabIndex = 12
        Me.lblNumReg.Text = "Número de registros:"
        Me.lblNumReg.Visible = False
        '
        'lblNumeroRegistros
        '
        Me.lblNumeroRegistros.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNumeroRegistros.ForeColor = System.Drawing.Color.Blue
        Me.lblNumeroRegistros.Location = New System.Drawing.Point(283, 30)
        Me.lblNumeroRegistros.Name = "lblNumeroRegistros"
        Me.lblNumeroRegistros.Size = New System.Drawing.Size(37, 16)
        Me.lblNumeroRegistros.TabIndex = 13
        Me.lblNumeroRegistros.Visible = False
        '
        'lblNoImp
        '
        Me.lblNoImp.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNoImp.ForeColor = System.Drawing.Color.Black
        Me.lblNoImp.Location = New System.Drawing.Point(329, 30)
        Me.lblNoImp.Name = "lblNoImp"
        Me.lblNoImp.Size = New System.Drawing.Size(135, 16)
        Me.lblNoImp.TabIndex = 14
        Me.lblNoImp.Text = "Número de impresiones:"
        Me.lblNoImp.Visible = False
        '
        'lblNumeroImpresiones
        '
        Me.lblNumeroImpresiones.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNumeroImpresiones.ForeColor = System.Drawing.Color.Red
        Me.lblNumeroImpresiones.Location = New System.Drawing.Point(473, 30)
        Me.lblNumeroImpresiones.Name = "lblNumeroImpresiones"
        Me.lblNumeroImpresiones.Size = New System.Drawing.Size(49, 16)
        Me.lblNumeroImpresiones.TabIndex = 15
        Me.lblNumeroImpresiones.Visible = False
        '
        'lvwEficiencias
        '
        Me.lvwEficiencias.AllowColumnReorder = True
        Me.lvwEficiencias.AutoValidateColumn = False
        Me.lvwEficiencias.CheckBoxes = True
        Me.lvwEficiencias.ColunmOrder = Nothing
        Me.lvwEficiencias.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lvwEficiencias.FullRowSelect = True
        Me.lvwEficiencias.Location = New System.Drawing.Point(0, 58)
        Me.lvwEficiencias.Name = "lvwEficiencias"
        Me.lvwEficiencias.Size = New System.Drawing.Size(1056, 564)
        Me.lvwEficiencias.SortColumns = False
        Me.lvwEficiencias.TabIndex = 16
        Me.lvwEficiencias.UseCompatibleStateImageBehavior = False
        '
        'frmEficiencia
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(1056, 622)
        Me.Controls.Add(Me.lvwEficiencias)
        Me.Controls.Add(Me.lblNumeroImpresiones)
        Me.Controls.Add(Me.lblNoImp)
        Me.Controls.Add(Me.lblNumeroRegistros)
        Me.Controls.Add(Me.lblNumReg)
        Me.Controls.Add(Me.lblFechaInicio)
        Me.Controls.Add(Me.dtpFechaInicio)
        Me.Controls.Add(Me.dtpFechaFinal)
        Me.Controls.Add(Me.chkSeleccionarTodos)
        Me.Controls.Add(Me.lblFechaFinal)
        Me.Controls.Add(Me.lblEficiencia)
        Me.Controls.Add(Me.btnBuscar)
        Me.Controls.Add(Me.cmbEficiencia)
        Me.Controls.Add(Me.crvReporte)
        Me.Controls.Add(Me.tbEficicnecia)
        Me.MinimizeBox = False
        Me.Name = "frmEficiencia"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Calcular Eficiencia"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

    Private rptReporte As New ReportDocument()
    Private _TablaReporte As Table
    Private _LogonInfo As TableLogOnInfo
    Dim contadorImpresion As Integer = 0

    Private Sub frmEficiencia_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim combo1 As New ElementosCombo()
        combo1.Descripcion = "Por Generar"
        combo1.Valor = "CALCULADO"

        Dim combo2 As New ElementosCombo()
        combo2.Descripcion = "Generado"
        combo2.Valor = "GENERADO"

        Me.cmbEficiencia.Items.Add(combo1)
        Me.cmbEficiencia.Items.Add(combo2)
        Me.cmbEficiencia.DisplayMember = "Descripcion"
        Me.cmbEficiencia.ValueMember = "Valor"
        Me.cmbEficiencia.SelectedIndex = 0

        Dim ordenColumnas(21) As String
        Me.lvwEficiencias.SortColumns = True
        ordenColumnas(0) = "Autotanque"
        ordenColumnas(1) = "CalibracionPorcentaje"
        ordenColumnas(2) = "AñoAtt"
        ordenColumnas(3) = "Folio"
        ordenColumnas(4) = "Celula"
        ordenColumnas(5) = "Ruta"
        ordenColumnas(6) = "Operador"
        ordenColumnas(7) = "LitrosLiquidados"
        ordenColumnas(8) = "NoLlenados"
        ordenColumnas(9) = "FHoraInicial"
        ordenColumnas(10) = "FHoraFinal"
        ordenColumnas(11) = "Masa"
        ordenColumnas(12) = "Volumen"
        ordenColumnas(13) = "LtsTotMenosCalibAtt"
        ordenColumnas(14) = "EficienciaMasico"
        ordenColumnas(15) = "ImporteEficienciaMasico"
        ordenColumnas(16) = "EficienciaPorcentaje"
        ordenColumnas(17) = "ImporteEficienciaPorcentaje"
        ordenColumnas(18) = "IdOperador"
        ordenColumnas(19) = "Cliente"
        ordenColumnas(20) = "FAsignacion"
        ordenColumnas(21) = "FTerminoRuta"

        Me.lvwEficiencias.ColunmOrder = ordenColumnas
    End Sub

    Public Class ElementosCombo
        Private _descripcion As String
        Private _valor As String

        Public Property Descripcion() As String
            Get
                Return _descripcion
            End Get
            Set(ByVal Value As String)
                _descripcion = Value
            End Set
        End Property

        Public Property Valor() As String
            Get
                Return _valor
            End Get
            Set(ByVal Value As String)
                _valor = Value
            End Set
        End Property

    End Class

    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        Dim listaResultados As ArrayList
        Me.Cursor = Cursors.WaitCursor
        listaResultados = Buscar()
        Me.Cursor = Cursors.Default
        If (listaResultados.Count > 0) Then
            Me.lvwEficiencias.Clear()
            Me.lvwEficiencias.AddRangeObjects(listaResultados)
            Me.lvwEficiencias.columnResize()
            Me.lblNumeroRegistros.Visible = True
            Me.lblNumReg.Visible = True
            Me.lblNumeroRegistros.Text = Me.lvwEficiencias.Items.Count.ToString()
            Me.verificarListView()
        Else
            MsgBox("No existen registros que mostrar.", MsgBoxStyle.Information, "Mensaje del sistema")
            Me.lvwEficiencias.Clear()
            Me.lblNumeroRegistros.Text = "0"
        End If
    End Sub

    Public Function Buscar() As ArrayList
        Dim listaObjetos As New ArrayList()
        Dim cmdBuscar As New SqlCommand("spBASConsultaEficienciaMasico", Globales.GetInstance.cnSigamet)
        Dim reader As SqlDataReader
        cmdBuscar.CommandType = CommandType.StoredProcedure

        cmdBuscar.Parameters.Add("@FechaInicio", SqlDbType.DateTime).Value = New DateTime(Me.dtpFechaInicio.Value.Year, dtpFechaInicio.Value.Month, dtpFechaInicio.Value.Day, 0, 0, 0).ToString("yyyy-MM-ddTHH:mm:ss")
        cmdBuscar.Parameters.Add("@FechaFin", SqlDbType.DateTime).Value = New DateTime(Me.dtpFechaFinal.Value.Year, dtpFechaFinal.Value.Month, dtpFechaFinal.Value.Day, 23, 59, 59).ToString("yyyy-MM-ddTHH:mm:ss")
        cmdBuscar.Parameters.Add("@Status", SqlDbType.VarChar).Value = CType(Me.cmbEficiencia.SelectedItem, ElementosCombo).Valor
        'Me.Cursor = Cursors.WaitCursor
        Try
            Globales.GetInstance.AbreConexion()
            reader = cmdBuscar.ExecuteReader
            While reader.Read
                Dim obj As New Objeto()
                obj.Autotanque = CInt(reader("Autotanque"))
                If reader.IsDBNull(1) = True Then
                    obj.AñoAtt = 0
                Else
                    obj.AñoAtt = CType(reader("AñoAtt"), Integer)
                End If

                If reader.IsDBNull(2) = True Then
                    obj.Folio = 0
                Else
                    obj.Folio = CType(reader("Folio"), Integer)
                End If

                obj.NoLlenados = CInt(reader("NoLlenados"))
                obj.FHoraInicial = CType(reader("FHoraInicial"), DateTime)
                obj.FHoraFinal = CType(reader("FHoraFinal"), DateTime)
                obj.Volumen = CType(reader("Volumen"), Decimal)
                obj.Masa = CType(reader("Masa"), Decimal)
                obj.LitrosLiquidados = CType(reader("LitrosLiquidados"), Decimal)
                obj.CalibracionPorcentaje = CType(reader("Calibracion"), Decimal)
                obj.LtsTotMenosCalibAtt = CType(reader("LitrosMenosCalibracion"), Decimal)
                obj.EficienciaMasico = CType(reader("EficienciaMasico"), Decimal)
                obj.ImporteEficienciaMasico = CType(reader("ImporteEficienciaMasico"), Double)
                obj.EficienciaPorcentaje = CInt(reader("EficienciaPorcentaje"))
                obj.ImporteEficienciaPorcentaje = CType(reader("ImporteEficienciaPorcentaje"), Double)
                obj.Operador = CType(reader("Operador"), String)
                obj.IdOperador = CType(reader("IDOperador"), Integer)
                obj.Cliente = CType(reader("Cliente"), Integer)
                obj.FAsignacion = CType(reader("FAsignacion"), DateTime)
                obj.FTerminoRuta = CType(reader("FTerminoRuta"), DateTime)
                obj.Celula = CType(reader("Celula"), Integer)
                obj.Ruta = CType(reader("Ruta"), Integer)
                listaObjetos.Add(obj)
            End While
            reader.Close()
        Catch ex As Exception
            Globales.GetInstance.ExMessage(ex)
        Finally
            Globales.GetInstance.CierraConexion()
            'Me.Cursor = Cursors.Default
        End Try
        Return listaObjetos
    End Function

    Public Class Objeto
        Private _autotanque As Integer
        Private _añoAtt As Integer
        Private _folio As Integer
        Private _noLlenados As Integer
        Private _fHoraInicial As DateTime
        Private _fHoraFinal As DateTime
        Private _volumen As Decimal
        Private _masa As Decimal
        Private _litrosLiquidados As Decimal
        Private _calibracionPorcentaje As Decimal
        Private _ltsTotMenosCalibAtt As Decimal
        Private _eficienciaMasico As Decimal
        Private _importeEficienciaMasico As Double
        Private _eficienciaPorcentaje As Integer
        Private _importeEficienciaPorcentaje As Double
        Private _operador As String
        Private _idOperador As Integer
        Private _cliente As Integer
        Private _fAsignacion As DateTime
        Private _celula As Integer
        Private _ruta As Integer
        Private _fTerminoRuta As DateTime


        Public Property Autotanque() As Integer
            Get
                Return _autotanque
            End Get
            Set(ByVal Value As Integer)
                _autotanque = Value
            End Set
        End Property

        Public Property AñoAtt() As Integer
            Get
                Return _añoAtt
            End Get
            Set(ByVal Value As Integer)
                _añoAtt = Value
            End Set
        End Property

        Public Property Folio() As Integer
            Get
                Return _folio
            End Get
            Set(ByVal Value As Integer)
                _folio = Value
            End Set
        End Property

        Public Property NoLlenados() As Integer
            Get
                Return _noLlenados
            End Get
            Set(ByVal Value As Integer)
                _noLlenados = Value
            End Set
        End Property

        Public Property FHoraInicial() As DateTime
            Get
                Return _fHoraInicial
            End Get
            Set(ByVal Value As DateTime)
                _fHoraInicial = Value
            End Set
        End Property

        Public Property FHoraFinal() As DateTime
            Get
                Return _fHoraFinal
            End Get
            Set(ByVal Value As DateTime)
                _fHoraFinal = Value
            End Set
        End Property

        Public Property Volumen() As Decimal
            Get
                Return _volumen
            End Get
            Set(ByVal Value As Decimal)
                _volumen = Value
            End Set
        End Property

        Public Property Masa() As Decimal
            Get
                Return _masa
            End Get
            Set(ByVal Value As Decimal)
                _masa = Value
            End Set
        End Property
        Public Property LitrosLiquidados() As Decimal
            Get
                Return _litrosLiquidados
            End Get
            Set(ByVal Value As Decimal)
                _litrosLiquidados = Value
            End Set
        End Property
        Public Property CalibracionPorcentaje() As Decimal
            Get
                Return _calibracionPorcentaje
            End Get
            Set(ByVal Value As Decimal)
                _calibracionPorcentaje = Value
            End Set
        End Property
        Public Property LtsTotMenosCalibAtt() As Decimal
            Get
                Return _ltsTotMenosCalibAtt
            End Get
            Set(ByVal Value As Decimal)
                _ltsTotMenosCalibAtt = Value
            End Set
        End Property
        Public Property EficienciaMasico() As Decimal
            Get
                Return _eficienciaMasico
            End Get
            Set(ByVal Value As Decimal)
                _eficienciaMasico = Value
            End Set
        End Property

        Public Property ImporteEficienciaMasico() As Double
            Get
                Return _importeEficienciaMasico
            End Get
            Set(ByVal Value As Double)
                _importeEficienciaMasico = Value
            End Set
        End Property

        Public Property EficienciaPorcentaje() As Integer
            Get
                Return _eficienciaPorcentaje
            End Get
            Set(ByVal Value As Integer)
                _eficienciaPorcentaje = Value
            End Set
        End Property

        Public Property ImporteEficienciaPorcentaje() As Double
            Get
                Return _importeEficienciaPorcentaje
            End Get
            Set(ByVal Value As Double)
                _importeEficienciaPorcentaje = Value
            End Set
        End Property

        Public Property Operador() As String
            Get
                Return _operador
            End Get
            Set(ByVal Value As String)
                _operador = Value
            End Set
        End Property

        Public Property IdOperador() As Integer
            Get
                Return _idOperador
            End Get
            Set(ByVal Value As Integer)
                _idOperador = Value
            End Set
        End Property

        Public Property Cliente() As Integer
            Get
                Return _cliente
            End Get
            Set(ByVal Value As Integer)
                _cliente = Value
            End Set
        End Property

        Public Property FAsignacion() As DateTime
            Get
                Return _fAsignacion
            End Get
            Set(ByVal Value As DateTime)
                _fAsignacion = Value
            End Set
        End Property

        Public Property Celula() As Integer
            Get
                Return _celula
            End Get
            Set(ByVal Value As Integer)
                _celula = Value
            End Set
        End Property

        Public Property Ruta() As Integer
            Get
                Return _ruta
            End Get
            Set(ByVal Value As Integer)
                _ruta = Value
            End Set
        End Property

        Public Property FTerminoRuta() As DateTime
            Get
                Return _fTerminoRuta
            End Get
            Set(ByVal Value As DateTime)
                _fTerminoRuta = Value
            End Set
        End Property

    End Class

    Private Sub chkSeleccionarTodos_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkSeleccionarTodos.CheckedChanged
        Dim elemento As New ListViewItem()

        If Me.chkSeleccionarTodos.Checked = True Then
            For Each elemento In Me.lvwEficiencias.Items
                elemento.Checked = True
            Next
        End If
        If Me.chkSeleccionarTodos.Checked = False Then
            For Each elemento In Me.lvwEficiencias.Items
                elemento.Checked = False
            Next
        End If
    End Sub

    Public Function Registrar(ByVal arreglo As ArrayList) As Boolean
        Dim elemento As New Objeto()
        Dim objTransac As SqlTransaction = Nothing
        Dim resultado As Boolean = True
        Globales.GetInstance.AbreConexion()
        objTransac = Globales.GetInstance.cnSigamet.BeginTransaction()
        For Each elemento In arreglo
            Try
                Dim cmdBuscar As New SqlCommand("spBASSGCModificaEficiencia", Globales.GetInstance.cnSigamet)
                cmdBuscar.CommandType = CommandType.StoredProcedure
                cmdBuscar.Transaction = objTransac
                cmdBuscar.Parameters.Add("@AnioAtt", SqlDbType.SmallInt).Value = elemento.AñoAtt
                cmdBuscar.Parameters.Add("@Folio", SqlDbType.Int).Value = elemento.Folio
                cmdBuscar.Parameters.Add("@EficienciaMasico", SqlDbType.Decimal).Value = elemento.EficienciaMasico
                cmdBuscar.Parameters.Add("@ImporteEficienciaMasico", SqlDbType.Money).Value = elemento.ImporteEficienciaMasico
                cmdBuscar.Parameters.Add("@Cliente", SqlDbType.Int).Value = elemento.Cliente
                cmdBuscar.Parameters.Add("@FAsignacion", SqlDbType.DateTime).Value = elemento.FAsignacion
                cmdBuscar.Parameters.Add("@FTerminoRuta", SqlDbType.DateTime).Value = elemento.FTerminoRuta
                cmdBuscar.Parameters.Add("@Celula", SqlDbType.TinyInt).Value = elemento.Celula
                cmdBuscar.Parameters.Add("@ruta", SqlDbType.SmallInt).Value = elemento.Ruta
                cmdBuscar.Parameters.Add("@Autotanque", SqlDbType.Int).Value = elemento.Autotanque
                cmdBuscar.ExecuteNonQuery()

            Catch ex As Exception
                resultado = False
                objTransac.Rollback()
                MsgBox("Seprodujo un error." + ex.Message, MsgBoxStyle.Critical, "Mensaje del sistema")
                Globales.GetInstance.CierraConexion()
                Exit For
            End Try
        Next
        If resultado = True Then
            objTransac.Commit()
            MsgBox("La datos se generaron correctamente", MsgBoxStyle.Information, "Mensaje del sistema")
        End If
        Return resultado
    End Function

    Private Sub ImprimirAvisoEficiencia(ByVal Año As Integer, ByVal Folio As Integer)

        Dim crParameterFieldDefinitions As ParameterFieldDefinitions
        Dim crParameterFieldDefinition As ParameterFieldDefinition
        Dim crParametervalues As CrystalDecisions.Shared.ParameterValues
        Dim crParameterDiscretValue As CrystalDecisions.Shared.ParameterDiscreteValue
        'Cursor = Cursors.WaitCursor
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
            'Finally
            '    Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub ConexionReporte()

        For Each _TablaReporte In rptReporte.Database.Tables
            _LogonInfo = _TablaReporte.LogOnInfo
            With _LogonInfo.ConnectionInfo
                .ServerName = Globales.GetInstance._Servidor
                .DatabaseName = Globales.GetInstance._Database
                .UserID = Globales.GetInstance._Usuario
                .Password = Globales.GetInstance._Password
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

    Private Sub verificarListView()
        If (lvwEficiencias.Items.Count > 0) Then
            Me.chkSeleccionarTodos.Visible = True
        Else
            Me.chkSeleccionarTodos.Visible = False
        End If
    End Sub

    Private Sub cmbEficiencia_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbEficiencia.SelectedIndexChanged
        If CType(Me.cmbEficiencia.SelectedItem, ElementosCombo).Descripcion = "Por Generar" Then
            Me.tbBtnImprimir.Enabled = False
            Me.tbBtnGenerar.Enabled = True
            Me.lvwEficiencias.Clear()
            Me.lblNumeroRegistros.Text = "0"
            verificarListView()
        Else
            Me.tbBtnImprimir.Enabled = True
            Me.tbBtnGenerar.Enabled = False
            Me.lvwEficiencias.Clear()
            Me.lblNumeroRegistros.Text = "0"
            verificarListView()
        End If
    End Sub

    Private Sub tbEficicnecia_ButtonClick_1(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolBarButtonClickEventArgs) Handles tbEficicnecia.ButtonClick
        Select Case e.Button.Text
            Case "Generar"
                Dim arreglo As New ArrayList()
                arreglo = Me.lvwEficiencias.GetCheckedItems()

                If arreglo.Count > 0 Then
                    Me.Cursor = Cursors.WaitCursor
                    If Registrar(arreglo) = True Then
                        Me.lvwEficiencias.Clear()
                        Me.lvwEficiencias.AddRangeObjects(Buscar())
                        Me.lblNumeroRegistros.Text = Me.lvwEficiencias.Items.Count.ToString()
                        Me.verificarListView()
                        Dim elemento As New Objeto()
                        If (Globales.GetInstance._ImprimeEficiencaManual = True) Then
                            Me.lblNoImp.Visible = True
                            Me.lblNumeroImpresiones.Visible = True
                            contadorImpresion = arreglo.Count
                            Me.lblNumeroImpresiones.Text = contadorImpresion.ToString()
                            For Each elemento In arreglo
                                ImprimirAvisoEficiencia(elemento.AñoAtt, elemento.Folio)
                                contadorImpresion = contadorImpresion - 1
                                Me.lblNumeroImpresiones.Text = contadorImpresion.ToString()
                            Next
                            Me.lblNoImp.Visible = False
                            Me.lblNumeroImpresiones.Visible = False
                        End If
                    End If
                    Me.Cursor = Cursors.Default
                Else
                    Me.lblNumeroRegistros.Text = "0"
                    MsgBox("No hay elementos selecionados,Favor de verificar.", MsgBoxStyle.Information, "Mensaje del sistema")
                End If
            Case "Imprimir"
                Dim arreglo As New ArrayList()
                arreglo = Me.lvwEficiencias.GetCheckedItems()
                If arreglo.Count > 0 Then
                    Me.Cursor = Cursors.WaitCursor
                    Dim elemento As New Objeto()
                    If (Globales.GetInstance._ImprimeEficiencaManual = True) Then
                        Me.lblNoImp.Visible = True
                        Me.lblNumeroImpresiones.Visible = True
                        contadorImpresion = arreglo.Count
                        Me.lblNumeroImpresiones.Text = contadorImpresion.ToString()
                        For Each elemento In arreglo

                            ImprimirAvisoEficiencia(elemento.AñoAtt, elemento.Folio)

                            contadorImpresion = contadorImpresion - 1
                            Me.lblNumeroImpresiones.Text = contadorImpresion.ToString()
                        Next
                        Me.lblNoImp.Visible = False
                        Me.lblNumeroImpresiones.Visible = False
                    End If
                    Me.Cursor = Cursors.Default
                Else
                    MsgBox("No hay elementos seleccionados para imprimir, Favor de verificar.", MsgBoxStyle.Information, "Mensaje del sistema")
                End If
            Case "Cerrar"
                Me.Close()
                Me.Dispose()
        End Select
    End Sub
End Class
