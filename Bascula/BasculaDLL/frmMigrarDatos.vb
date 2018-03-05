Public Class frmMigrarDatos
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
    Friend WithEvents tbBtnMigrar As System.Windows.Forms.ToolBarButton
    Friend WithEvents tbMigrarDatos As System.Windows.Forms.ToolBar
    Friend WithEvents tbBtnVincular As System.Windows.Forms.ToolBarButton
    Friend WithEvents tbBtnSalir As System.Windows.Forms.ToolBarButton
    Friend WithEvents imgMigrar As System.Windows.Forms.ImageList
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dtpFechaInicial As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents dtpFechaFinal As System.Windows.Forms.DateTimePicker
    Friend WithEvents btnBuscar As System.Windows.Forms.Button
    Friend WithEvents lvDatosMigrar As GasMetropolitano2002.Runtime.Controls.ListViewObject
    Friend WithEvents tbBtnDesvincula As System.Windows.Forms.ToolBarButton
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmMigrarDatos))
        Me.tbBtnMigrar = New System.Windows.Forms.ToolBarButton()
        Me.tbMigrarDatos = New System.Windows.Forms.ToolBar()
        Me.tbBtnVincular = New System.Windows.Forms.ToolBarButton()
        Me.tbBtnDesvincula = New System.Windows.Forms.ToolBarButton()
        Me.tbBtnSalir = New System.Windows.Forms.ToolBarButton()
        Me.imgMigrar = New System.Windows.Forms.ImageList(Me.components)
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dtpFechaInicial = New System.Windows.Forms.DateTimePicker()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.dtpFechaFinal = New System.Windows.Forms.DateTimePicker()
        Me.btnBuscar = New System.Windows.Forms.Button()
        Me.lvDatosMigrar = New GasMetropolitano2002.Runtime.Controls.ListViewObject()
        Me.SuspendLayout()
        '
        'tbBtnMigrar
        '
        Me.tbBtnMigrar.Enabled = False
        Me.tbBtnMigrar.ImageIndex = 1
        Me.tbBtnMigrar.Text = "Migrar"
        '
        'tbMigrarDatos
        '
        Me.tbMigrarDatos.Buttons.AddRange(New System.Windows.Forms.ToolBarButton() {Me.tbBtnVincular, Me.tbBtnMigrar, Me.tbBtnDesvincula, Me.tbBtnSalir})
        Me.tbMigrarDatos.ButtonSize = New System.Drawing.Size(75, 55)
        Me.tbMigrarDatos.DropDownArrows = True
        Me.tbMigrarDatos.ImageList = Me.imgMigrar
        Me.tbMigrarDatos.Name = "tbMigrarDatos"
        Me.tbMigrarDatos.ShowToolTips = True
        Me.tbMigrarDatos.Size = New System.Drawing.Size(808, 58)
        Me.tbMigrarDatos.TabIndex = 0
        '
        'tbBtnVincular
        '
        Me.tbBtnVincular.Enabled = False
        Me.tbBtnVincular.ImageIndex = 0
        Me.tbBtnVincular.Text = "Vincular"
        '
        'tbBtnDesvincula
        '
        Me.tbBtnDesvincula.Enabled = False
        Me.tbBtnDesvincula.ImageIndex = 3
        Me.tbBtnDesvincula.Text = "Omitir Vinculo"
        '
        'tbBtnSalir
        '
        Me.tbBtnSalir.ImageIndex = 2
        Me.tbBtnSalir.Text = "Salir"
        '
        'imgMigrar
        '
        Me.imgMigrar.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit
        Me.imgMigrar.ImageSize = New System.Drawing.Size(32, 32)
        Me.imgMigrar.ImageStream = CType(resources.GetObject("imgMigrar.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imgMigrar.TransparentColor = System.Drawing.Color.Transparent
        '
        'Label1
        '
        Me.Label1.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
        Me.Label1.Location = New System.Drawing.Point(352, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(80, 23)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Fecha Inicial :"
        '
        'dtpFechaInicial
        '
        Me.dtpFechaInicial.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
        Me.dtpFechaInicial.Format = System.Windows.Forms.DateTimePickerFormat.Short
        Me.dtpFechaInicial.Location = New System.Drawing.Point(432, 16)
        Me.dtpFechaInicial.Name = "dtpFechaInicial"
        Me.dtpFechaInicial.Size = New System.Drawing.Size(88, 20)
        Me.dtpFechaInicial.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
        Me.Label2.Location = New System.Drawing.Point(536, 16)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(80, 16)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Fecha Final :"
        '
        'dtpFechaFinal
        '
        Me.dtpFechaFinal.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
        Me.dtpFechaFinal.Format = System.Windows.Forms.DateTimePickerFormat.Short
        Me.dtpFechaFinal.Location = New System.Drawing.Point(608, 16)
        Me.dtpFechaFinal.Name = "dtpFechaFinal"
        Me.dtpFechaFinal.Size = New System.Drawing.Size(88, 20)
        Me.dtpFechaFinal.TabIndex = 4
        '
        'btnBuscar
        '
        Me.btnBuscar.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
        Me.btnBuscar.Location = New System.Drawing.Point(744, 16)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(56, 23)
        Me.btnBuscar.TabIndex = 5
        Me.btnBuscar.Text = "Buscar"
        '
        'lvDatosMigrar
        '
        Me.lvDatosMigrar.AllowColumnReorder = True
        Me.lvDatosMigrar.AutoValidateColumn = False
        Me.lvDatosMigrar.CheckBoxes = True
        Me.lvDatosMigrar.ColunmOrder = Nothing
        Me.lvDatosMigrar.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lvDatosMigrar.FullRowSelect = True
        Me.lvDatosMigrar.Location = New System.Drawing.Point(0, 58)
        Me.lvDatosMigrar.MultiSelect = False
        Me.lvDatosMigrar.Name = "lvDatosMigrar"
        Me.lvDatosMigrar.Size = New System.Drawing.Size(808, 492)
        Me.lvDatosMigrar.SortColumns = False
        Me.lvDatosMigrar.TabIndex = 6
        '
        'frmMigrarDatos
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(808, 550)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.lvDatosMigrar, Me.btnBuscar, Me.dtpFechaFinal, Me.Label2, Me.dtpFechaInicial, Me.Label1, Me.tbMigrarDatos})
        Me.Name = "frmMigrarDatos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Importar Datos"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ResumeLayout(False)

    End Sub

#End Region
    Dim datosDiferencia As New ArrayList()
    Dim datosDiferenciaCopia As New ArrayList()
    Dim bandera As Boolean = False
    Dim index As Integer

    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        Me.Cursor = Cursors.WaitCursor
        Buscar()
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub Buscar()
        Dim listaDatosMySql As New ArrayList()
        Dim listaDatosSql As New ArrayList()
        listaDatosMySql = TraerDatosMySQL(Me.dtpFechaInicial.Value, Me.dtpFechaFinal.Value)
        listaDatosSql = TraerDatosSQL(Me.dtpFechaInicial.Value, Me.dtpFechaFinal.Value)
        datosDiferencia.Clear()
        datosDiferenciaCopia.Clear()
        Dim i As Int32
        Dim j As Int32
        Dim bandera As Boolean = False

        For i = 0 To listaDatosMySql.Count - 1
            For j = 0 To listaDatosSql.Count - 1
                If CType(listaDatosMySql(i), RI505Servicio).IdServicio = CType(listaDatosSql(j), RI505Servicio).IdServicio Then
                    bandera = True
                End If
            Next j
            If bandera = False Then
                datosDiferencia.Add(listaDatosMySql(i))
            End If
            bandera = False
        Next i
        Me.LimpiarYLlenarListView()

        If (Me.lvDatosMigrar.Items.Count > 0) Then
            Me.tbBtnMigrar.Enabled = True
            Me.tbBtnVincular.Enabled = True
            Me.tbBtnDesvincula.Enabled = True
        Else
            Me.tbBtnMigrar.Enabled = False
            Me.tbBtnVincular.Enabled = False
            Me.tbBtnDesvincula.Enabled = False
            MsgBox("No hay datos que migrar.", MsgBoxStyle.Information, "Mensaje del sistema")
        End If
    End Sub

    'Private Sub CrearCopiaDeLista()
    '    Dim i As Integer
    '    For i = 0 To datosDiferencia.Count - 1
    '        Dim objCopia As New RI505Servicio()
    '        Dim objOriginal As New RI505Servicio()
    '        objOriginal = CType(datosDiferencia(i), RI505Servicio)
    '        objCopia.Autotanque = objOriginal.Autotanque
    '        objCopia.AñoAtt = objOriginal.AñoAtt
    '        objCopia.Densidad = objOriginal.Densidad
    '        objCopia.DensidadPromedio = objOriginal.DensidadPromedio
    '        objCopia.Eficiencia = objOriginal.Eficiencia
    '        objCopia.FechaHoraFinal = objOriginal.FechaHoraFinal
    '        objCopia.FechaHoraInicial = objOriginal.FechaHoraInicial
    '        objCopia.Folio = objOriginal.Folio
    '        objCopia.IdServicio = objOriginal.IdServicio
    '        objCopia.IdUsuario = objOriginal.IdUsuario
    '        objCopia.ImporteEficiencia = objOriginal.ImporteEficiencia
    '        objCopia.IsChecked = objOriginal.IsChecked
    '        objCopia.LtsTotMenosCalibAtt = objOriginal.LtsTotMenosCalibAtt
    '        objCopia.Masa = objOriginal.Masa
    '        objCopia.Prefijado = objOriginal.Prefijado
    '        objCopia.Tag = objOriginal.Tag
    '        objCopia.Temperatura = objOriginal.Temperatura
    '        objCopia.Terminal = objOriginal.Terminal
    '        objCopia.Tipo = objOriginal.Tipo
    '        objCopia.Tolerancia = objOriginal.Tolerancia
    '        objCopia.TotalizadorFin = objOriginal.TotalizadorFin
    '        objCopia.TotalizadorFinMasa = objOriginal.TotalizadorFinMasa
    '        objCopia.TotalizadorIni = objOriginal.TotalizadorIni
    '        objCopia.TotalizadorIniMasa = objOriginal.TotalizadorIniMasa
    '        objCopia.TotMasa = objOriginal.TotMasa
    '        objCopia.TotVolumen = objOriginal.TotVolumen
    '        objCopia.Volumen = objOriginal.Volumen
    '        datosDiferenciaCopia.Add(objCopia)
    '    Next i
    'End Sub

    Private Sub LimpiarYLlenarListView()
        Me.lvDatosMigrar.Items.Clear()
        Me.lvDatosMigrar.AddRangeObjects(datosDiferencia)
        Me.lvDatosMigrar.columnResize()
    End Sub

    Private Function TraerDatosMySQL(ByVal fechaInicial As DateTime, ByVal fechaFinal As DateTime) As ArrayList
        Dim lista As New ArrayList()
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
                Dim sql As String = Globales.GetInstance._SGCMasicoImportacion1 + Globales.GetInstance._SGCMasicoImportacion2
                sql = sql.Replace("FHI", "'" + Me.dtpFechaInicial.Value.ToString("yyyy-MM-dd") + "00:00:00" + "'")
                sql = sql.Replace("FHF", "'" + Me.dtpFechaFinal.Value.ToString("yyyy-MM-dd") + "23:59:59" + "'")
                cmd = New MySql.Data.MySqlClient.MySqlCommand(sql, conn)
                cmd.CommandText = sql
                Dim reader As MySql.Data.MySqlClient.MySqlDataReader
                reader = cmd.ExecuteReader

                While reader.Read
                    Dim obj As New RI505Servicio()
                    obj.IdServicio = CInt(reader("id_servicio"))
                    obj.Terminal = CInt(reader("terminal"))
                    obj.Autotanque = CInt(reader("autotanque"))
                    obj.Tag = CType(reader("tag"), String)
                    obj.IdUsuario = CInt(reader("id_usuario"))
                    obj.FechaHoraInicial = CType(reader("fecha_hora_inicial"), DateTime)
                    obj.FechaHoraFinal = CType(reader("fecha_hora_final"), DateTime)
                    obj.Prefijado = CType(reader("prefijado"), Decimal)
                    obj.Volumen = CType(reader("volumen"), Decimal)
                    obj.Masa = CType(reader("masa"), Decimal)
                    obj.Densidad = CType(reader("densidad"), Decimal)
                    obj.Temperatura = CType(reader("temperatura"), Decimal)
                    obj.TotalizadorIni = CInt(reader("totalizadorIni"))
                    obj.TotalizadorFin = CInt(reader("totalizadorFin"))
                    obj.TotalizadorIniMasa = CInt(reader("totalizadorIniMasa"))
                    obj.TotalizadorFinMasa = CInt(reader("totalizadorFinMasa"))
                    obj.Tipo = CType(reader("tipo"), String)
                    obj.TotVolumen = CType(reader("totVolumen"), Decimal)
                    obj.TotMasa = CType(reader("totMasa"), Decimal)
                    If reader.IsDBNull(19) = True Then
                        obj.DensidadPromedio = 0
                    Else
                        obj.DensidadPromedio = CType(reader("densidad_promedio"), Decimal)
                    End If
                    lista.Add(obj)
                End While
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
        Return lista
    End Function

    Private Function TraerDatosSQL(ByVal fechaInicial As DateTime, ByVal fechaFinal As DateTime) As ArrayList
        Dim lista As New ArrayList()
        Dim cmdBuscar As New SqlCommand("spBASSGCBuscarParaMigrar", Globales.GetInstance.cnSigamet)
        Dim reader As SqlDataReader
        cmdBuscar.CommandType = CommandType.StoredProcedure
        cmdBuscar.Parameters.Add("@FechaInicial", SqlDbType.DateTime).Value = New DateTime(dtpFechaInicial.Value.Year, dtpFechaInicial.Value.Month, dtpFechaInicial.Value.Day, 0, 0, 0).ToString("yyyy-MM-ddTHH:mm:ss")
        cmdBuscar.Parameters.Add("@FechaFinal", SqlDbType.DateTime).Value = New DateTime(dtpFechaFinal.Value.Year, dtpFechaFinal.Value.Month, dtpFechaFinal.Value.Day, 23, 59, 59).ToString("yyyy-MM-ddTHH:mm:ss")
        Me.Cursor = Cursors.WaitCursor
        Try
            Globales.GetInstance.AbreConexion()
            reader = cmdBuscar.ExecuteReader
            While reader.Read
                Dim obj As New RI505Servicio()
                obj.IdServicio = CInt(reader("IdServicio"))
                obj.Terminal = CInt(reader("Terminal"))
                obj.Autotanque = CInt(reader("Autotanque"))
                obj.Tag = CType(reader("Tag"), String)
                obj.IdUsuario = CInt(reader("IdUsuario"))
                obj.FechaHoraInicial = CType(reader("FHoraInicial"), DateTime)
                obj.FechaHoraFinal = CType(reader("FHoraFinal"), DateTime)
                If reader.IsDBNull(7) = True Then
                    obj.Prefijado = 0
                Else
                    obj.Prefijado = CType(reader("Prefijado"), Decimal)
                End If
                obj.Volumen = CType(reader("Volumen"), Decimal)
                obj.Masa = CType(reader("Masa"), Decimal)
                If reader.IsDBNull(10) = True Then
                    obj.Densidad = 0
                Else
                    obj.Densidad = CType(reader("Densidad"), Decimal)
                End If
                obj.Temperatura = CType(reader("Temperatura"), Decimal)
                obj.TotalizadorIni = CInt(reader("TotalizadorInicial"))
                obj.TotalizadorFin = CInt(reader("TotalizadorFinal"))
                If reader.IsDBNull(14) = True Then
                    obj.TotalizadorIniMasa = 0
                Else
                    obj.TotalizadorIniMasa = CInt(reader("TotalizadorInicialMasa"))
                End If
                If reader.IsDBNull(15) = True Then
                    obj.TotalizadorFinMasa = 0
                Else
                    obj.TotalizadorFinMasa = CInt(reader("TotalizadorFinalMasa"))
                End If
                obj.Tipo = CType(reader("Tipo"), String)
                If reader.IsDBNull(17) = True Then
                    obj.DensidadPromedio = 0
                Else
                    obj.DensidadPromedio = CType(reader("DensidadPromedio"), Decimal)
                End If
                If reader.IsDBNull(18) = True Then
                    obj.AñoAtt = 0
                Else
                    obj.AñoAtt = CType(reader("AñoAtt"), Integer)
                End If
                If reader.IsDBNull(19) = True Then
                    obj.Folio = 0
                Else
                    obj.Folio = CType(reader("Folio"), Integer)
                End If
                lista.Add(obj)
            End While
            reader.Close()
        Catch ex As Exception
            Globales.GetInstance.ExMessage(ex)
        Finally
            Globales.GetInstance.CierraConexion()
            Me.Cursor = Cursors.Default
        End Try
        Return lista
    End Function

    Public Class RI505Servicio
        Private _isChecked As Boolean = False
        Private _idServicio As Integer
        Private _terminal As Integer
        Private _autotanque As Integer
        Private _tag As String
        Private _IdUsuario As Integer
        Private _fechaHoraInicial As DateTime
        Private _fechaHoraFinal As DateTime
        Private _prefijado As Decimal
        Private _volumen As Decimal
        Private _masa As Decimal
        Private _densidad As Decimal
        Private _temperatura As Decimal
        Private _totalizadorIni As Integer
        Private _totalizadorFin As Integer
        Private _totalizadorIniMasa As Integer
        Private _totalizadorFinMasa As Integer
        Private _tipo As String
        Private _totVolumen As Decimal
        Private _totMasa As Decimal
        Private _densidadPromedio As Decimal
        Private _añoAtt As Integer
        Private _folio As Integer
        Private _ltsTotMenosCalibAtt As Double
        Private _eficiencia As Double
        Private _tolerancia As Byte
        Private _importeEficiencia As Double

        Public Property IsChecked() As Boolean
            Get
                Return _isChecked
            End Get
            Set(ByVal Value As Boolean)
                _isChecked = Value
            End Set
        End Property


        Public Property IdServicio() As Integer
            Get
                Return _idServicio
            End Get
            Set(ByVal Value As Integer)
                _idServicio = Value
            End Set
        End Property

        Public Property Terminal() As Integer
            Get
                Return _terminal
            End Get
            Set(ByVal Value As Integer)
                _terminal = Value
            End Set
        End Property

        Public Property Autotanque() As Integer
            Get
                Return _autotanque
            End Get
            Set(ByVal Value As Integer)
                _autotanque = Value
            End Set
        End Property

        Public Property Tag() As String
            Get
                Return _tag
            End Get
            Set(ByVal Value As String)
                _tag = Value
            End Set
        End Property

        Public Property IdUsuario() As Integer
            Get
                Return _IdUsuario
            End Get
            Set(ByVal Value As Integer)
                _IdUsuario = Value
            End Set
        End Property

        Public Property FechaHoraInicial() As DateTime
            Get
                Return _fechaHoraInicial
            End Get
            Set(ByVal Value As DateTime)
                _fechaHoraInicial = Value
            End Set
        End Property

        Public Property FechaHoraFinal() As DateTime
            Get
                Return _fechaHoraFinal
            End Get
            Set(ByVal Value As DateTime)
                _fechaHoraFinal = Value
            End Set
        End Property

        Public Property Prefijado() As Decimal
            Get
                Return _prefijado
            End Get
            Set(ByVal Value As Decimal)
                _prefijado = Value
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

        Public Property Densidad() As Decimal
            Get
                Return _densidad
            End Get
            Set(ByVal Value As Decimal)
                _densidad = Value
            End Set
        End Property

        Public Property Temperatura() As Decimal
            Get
                Return _temperatura
            End Get
            Set(ByVal Value As Decimal)
                _temperatura = Value
            End Set
        End Property

        Public Property TotalizadorIni() As Integer
            Get
                Return _totalizadorIni
            End Get
            Set(ByVal Value As Integer)
                _totalizadorIni = Value
            End Set
        End Property

        Public Property TotalizadorFin() As Integer
            Get
                Return _totalizadorFin
            End Get
            Set(ByVal Value As Integer)
                _totalizadorFin = Value
            End Set
        End Property

        Public Property TotalizadorIniMasa() As Integer
            Get
                Return _totalizadorIniMasa
            End Get
            Set(ByVal Value As Integer)
                _totalizadorIniMasa = Value
            End Set
        End Property

        Public Property TotalizadorFinMasa() As Integer
            Get
                Return _totalizadorFinMasa
            End Get
            Set(ByVal Value As Integer)
                _totalizadorFinMasa = Value
            End Set
        End Property

        Public Property Tipo() As String
            Get
                Return _tipo
            End Get
            Set(ByVal Value As String)
                _tipo = Value
            End Set
        End Property

        Public Property TotVolumen() As Decimal
            Get
                Return _totVolumen
            End Get
            Set(ByVal Value As Decimal)
                _totVolumen = Value
            End Set
        End Property

        Public Property TotMasa() As Decimal
            Get
                Return _totMasa
            End Get
            Set(ByVal Value As Decimal)
                _totMasa = Value
            End Set
        End Property

        Public Property DensidadPromedio() As Decimal
            Get
                Return _densidadPromedio
            End Get
            Set(ByVal Value As Decimal)
                _densidadPromedio = Value
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

        Public Property LtsTotMenosCalibAtt() As Double
            Get
                Return _ltsTotMenosCalibAtt
            End Get
            Set(ByVal Value As Double)
                _ltsTotMenosCalibAtt = Value
            End Set
        End Property

        Public Property Eficiencia() As Double
            Get
                Return _eficiencia
            End Get
            Set(ByVal Value As Double)
                _eficiencia = Value
            End Set
        End Property

        Public Property Tolerancia() As Byte
            Get
                Return _tolerancia
            End Get
            Set(ByVal Value As Byte)
                _tolerancia = Value
            End Set
        End Property

        Public Property ImporteEficiencia() As Double
            Get
                Return _importeEficiencia
            End Get
            Set(ByVal Value As Double)
                _importeEficiencia = Value
            End Set
        End Property


    End Class

    Private Sub tbMigrarDatos_ButtonClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolBarButtonClickEventArgs) Handles tbMigrarDatos.ButtonClick
        Select Case e.Button.Text
            Case "Vincular"
                Vincular()
            Case "Migrar"
                Dim obj As New RI505Servicio()
                Dim listaDatosPorMigrar As New ArrayList()
                Dim listaDatosTotales As New ArrayList()
                listaDatosTotales = Me.lvDatosMigrar.GetCheckedItems()
                For Each obj In listaDatosTotales
                    If obj.IsChecked = True Then
                        listaDatosPorMigrar.Add(obj)
                    End If
                Next
                If listaDatosTotales.Count > 0 Then
                    If (listaDatosTotales.Count > listaDatosPorMigrar.Count) Then
                        If listaDatosPorMigrar.Count > 0 Then
                            If MsgBox("Hay algunos registros seleccionados sin vincular, Favor de verificar la columna Folio." + Chr(13) + "¿Desea migrar solo los datos vinculados?", MsgBoxStyle.YesNo, "Mensaje del sistema") = MsgBoxResult.Yes Then
                                Me.Cursor = Cursors.WaitCursor
                                Migrar(listaDatosPorMigrar)
                                Buscar()
                                Me.Cursor = Cursors.Default
                            End If
                        Else
                            MsgBox("Debe vincular por lo menos 1 registro.", MsgBoxStyle.Exclamation, "Mensaje del sistema")
                        End If
                    Else
                        If listaDatosPorMigrar.Count > 0 Then
                            Me.Cursor = Cursors.WaitCursor
                            Migrar(listaDatosPorMigrar)
                            Buscar()
                            Me.Cursor = Cursors.Default
                        Else
                            MsgBox("Debe vincular por lo menos 1 registro.", MsgBoxStyle.Exclamation, "Mensaje del sistema")
                        End If

                    End If
                Else
                    MsgBox("Debe vincular por lo menos 1 registro.", MsgBoxStyle.Exclamation, "Mensaje del sistema")
                End If


            Case "Omitir Vinculo"
                    Dim elementoSeleccionado As New RI505Servicio()
                    If lvDatosMigrar.SelectedItems.Count > 0 Then
                        elementoSeleccionado = CType(lvDatosMigrar.GetCurrentSelectedObject(), RI505Servicio)
                        If elementoSeleccionado.IsChecked = True Then
                            Dim arrayy As New ArrayList()
                            arrayy = ObtenerListaPorFolio(elementoSeleccionado.Folio)
                            Dim arrayCalculado As ArrayList = RecalcularDatosAcumulados(arrayy)
                            Me.LimpiarYLlenarListView()
                            Me.HabilitarCheckBox()
                            MsgBox("El registro fue desvinculado con exito.", MsgBoxStyle.Information, "Mensaje del sistema")
                        Else
                            MsgBox("El registro aun no ha sido vinculado", MsgBoxStyle.Information, "Mensaje del sistema")
                        End If
                    Else
                        MsgBox("Debe seleccionar un registro.", MsgBoxStyle.Exclamation, "Mensaje del sistema")
                    End If
            Case "Salir"
                    Me.Close()
                    Me.Dispose()
        End Select
    End Sub

    Private Sub Vincular()
        If Me.lvDatosMigrar.SelectedItems.Count > 0 Then
            Dim elemento As New RI505Servicio()
            elemento = CType(Me.lvDatosMigrar.GetCurrentSelectedObject(), RI505Servicio)
            Dim frmActualizar As New frmActualizarAñoFolioRI505()
            frmActualizar.LoadOrders(elemento.IdServicio.ToString(), elemento.Autotanque)
            frmActualizar.ShowDialog()

            If frmActualizar.DialogResult = DialogResult.Yes Then
                Dim array As New ArrayList()
                elemento = CType(Me.lvDatosMigrar.GetCurrentSelectedObject(), RI505Servicio)
                CType(datosDiferencia(Me.lvDatosMigrar.SelectedItems(0).Index()), RI505Servicio).IsChecked = True
                CType(datosDiferencia(Me.lvDatosMigrar.SelectedItems(0).Index()), RI505Servicio).AñoAtt = frmActualizar.anio
                CType(datosDiferencia(Me.lvDatosMigrar.SelectedItems(0).Index()), RI505Servicio).Folio = frmActualizar.folio
                CType(datosDiferencia(Me.lvDatosMigrar.SelectedItems(0).Index()), RI505Servicio).LtsTotMenosCalibAtt = frmActualizar.LtsTotMenosCalibAtt
                CType(datosDiferencia(Me.lvDatosMigrar.SelectedItems(0).Index()), RI505Servicio).Eficiencia = elemento.Volumen - frmActualizar.LtsTotMenosCalibAtt
                CType(datosDiferencia(Me.lvDatosMigrar.SelectedItems(0).Index()), RI505Servicio).Tolerancia = Globales.GetInstance._ValorCalculoEficiencia
                CType(datosDiferencia(Me.lvDatosMigrar.SelectedItems(0).Index()), RI505Servicio).ImporteEficiencia = elemento.Eficiencia * Globales.GetInstance._Precio

                Me.LimpiarYLlenarListView()
                Me.HabilitarCheckBox()
                Dim arrayy As ArrayList = ObtenerListaPorFolio(frmActualizar.folio)
                Dim arrayCalculado As ArrayList = CalcularDatosAcumulados(arrayy)
                Me.LimpiarYLlenarListView()
                Me.HabilitarCheckBox()
                MsgBox("El registro fue modificado con exito.", MsgBoxStyle.Information, "Mensaje del sistema")
            End If
        Else
            MsgBox("Debe seleccionar un registro.", MsgBoxStyle.Exclamation, "Mensaje del sistema")
        End If
    End Sub

    Private Sub HabilitarCheckBox()
        Dim i As Int32
        For i = 0 To datosDiferencia.Count - 1
            If CType(datosDiferencia(i), RI505Servicio).IsChecked = True Then
                Me.lvDatosMigrar.Items(i).Checked = True
            End If
        Next i
    End Sub

    Private Function Migrar(ByVal lista As ArrayList) As Boolean
        Dim elemento As New RI505Servicio()
        Dim objTransac As SqlTransaction = Nothing
        Dim resultado As Boolean = True
        Globales.GetInstance.AbreConexion()
        objTransac = Globales.GetInstance.cnSigamet.BeginTransaction()
        For Each elemento In lista
            Try
                Dim cmdSGC As New SqlCommand("spBASSGCMigrarDatosRI505Servicio", Globales.GetInstance.cnSigamet)
                cmdSGC.CommandType = CommandType.StoredProcedure
                cmdSGC.Transaction = objTransac
                cmdSGC.Parameters.Add("@IdServicio", SqlDbType.Int).Value = elemento.IdServicio
                cmdSGC.Parameters.Add("@Terminal", SqlDbType.Int).Value = elemento.Terminal
                cmdSGC.Parameters.Add("@Autotanque", SqlDbType.Int).Value = elemento.Autotanque
                cmdSGC.Parameters.Add("@Tag", SqlDbType.VarChar).Value = elemento.Tag
                cmdSGC.Parameters.Add("@IdUsuario", SqlDbType.Int).Value = elemento.IdUsuario
                cmdSGC.Parameters.Add("@FHoraInicial", SqlDbType.DateTime).Value = elemento.FechaHoraInicial
                cmdSGC.Parameters.Add("@FHoraFinal", SqlDbType.DateTime).Value = elemento.FechaHoraFinal
                cmdSGC.Parameters.Add("@Volumen", SqlDbType.Decimal).Value = elemento.Volumen
                cmdSGC.Parameters.Add("@Masa", SqlDbType.Decimal).Value = elemento.Masa
                cmdSGC.Parameters.Add("@Densidad", SqlDbType.Decimal).Value = elemento.Densidad
                cmdSGC.Parameters.Add("@Temperatura", SqlDbType.Decimal).Value = elemento.Temperatura
                cmdSGC.Parameters.Add("@TotalizadorInicial", SqlDbType.Int).Value = elemento.TotalizadorIni
                cmdSGC.Parameters.Add("@TotalizadorFinal", SqlDbType.Int).Value = elemento.TotalizadorFin
                cmdSGC.Parameters.Add("@Tipo", SqlDbType.VarChar).Value = elemento.Tipo
                cmdSGC.Parameters.Add("@AñoAtt", SqlDbType.Int).Value = elemento.AñoAtt
                cmdSGC.Parameters.Add("@Folio", SqlDbType.Int).Value = elemento.Folio
                cmdSGC.Parameters.Add("@LtsTotMenosCalibAtt", SqlDbType.Decimal).Value = elemento.LtsTotMenosCalibAtt
                cmdSGC.Parameters.Add("@Eficicnecia", SqlDbType.Decimal).Value = elemento.Eficiencia
                cmdSGC.Parameters.Add("@Tolerancia", SqlDbType.Decimal).Value = elemento.Tolerancia
                cmdSGC.Parameters.Add("@DensidadPromedio", SqlDbType.Decimal).Value = elemento.DensidadPromedio
                cmdSGC.Parameters.Add("@Prefijado", SqlDbType.Decimal).Value = elemento.Prefijado
                cmdSGC.Parameters.Add("@TotalizadorInicialMasa", SqlDbType.Int).Value = elemento.TotalizadorIniMasa
                cmdSGC.Parameters.Add("@TotalizadorFinalMasa", SqlDbType.Int).Value = elemento.TotalizadorFinMasa
                cmdSGC.Parameters.Add("@ImporteEficiencia", SqlDbType.Money).Value = elemento.ImporteEficiencia
                cmdSGC.Parameters.Add("@Precio", SqlDbType.Money).Value = Globales.GetInstance._Precio
                cmdSGC.ExecuteNonQuery()
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
            MsgBox("La datos se generaron correctamente.", MsgBoxStyle.Information, "Mensaje del sistema")
        End If
        Return resultado
    End Function

    Private Function ObtenerListaPorFolio(ByVal folio As Integer) As ArrayList
        Dim listaNueva As New ArrayList()
        Dim obj As New RI505Servicio()
        For Each obj In datosDiferencia
            If (obj.Folio) = folio Then
                listaNueva.Add(obj)
            End If
        Next
        Return listaNueva
    End Function

    Private Function RecalcularDatosAcumulados(ByVal listaPorModificar As ArrayList) As ArrayList
        Dim listaNuevaPorModificar As New ArrayList()
        Dim i As Integer
        Dim obj As New RI505Servicio()
        Dim objCopia As New RI505Servicio()
        Dim volumen As Double
        Dim objSeleccion As New RI505Servicio()
        objSeleccion = CType(lvDatosMigrar.GetCurrentSelectedObject(), RI505Servicio)
        objSeleccion.Eficiencia = 0
        objSeleccion.ImporteEficiencia = 0
        objSeleccion.AñoAtt = 0
        objSeleccion.Folio = 0
        objSeleccion.IsChecked = False
        objSeleccion.Tolerancia = 0
        objSeleccion.LtsTotMenosCalibAtt = 0

        For i = 0 To listaPorModificar.Count - 1
            If (objSeleccion.IdServicio <> CType(listaPorModificar(i), RI505Servicio).IdServicio) Then
                Dim nuevoObj As New RI505Servicio()
                nuevoObj = CType(listaPorModificar(i), RI505Servicio)
                listaNuevaPorModificar.Add(nuevoObj)
            End If
        Next
        listaNuevaPorModificar.Add(objSeleccion)

        For Each obj In listaNuevaPorModificar
            If (objSeleccion.IdServicio <> obj.IdServicio) Then
                volumen += obj.Volumen
                obj.Eficiencia = volumen - obj.LtsTotMenosCalibAtt
                obj.ImporteEficiencia = obj.Eficiencia * Globales.GetInstance._Precio
                objCopia = obj
            End If
        Next
        For Each obj In listaNuevaPorModificar
            If (objSeleccion.IdServicio <> obj.IdServicio) Then
                obj.Eficiencia = objCopia.Eficiencia
                obj.ImporteEficiencia = objCopia.ImporteEficiencia
            End If
        Next
        Return listaNuevaPorModificar
    End Function

    Private Function CalcularDatosAcumulados(ByVal listaPorModificar As ArrayList) As ArrayList
        Dim obj As New RI505Servicio()
        Dim objCopia As New RI505Servicio()
        Dim volumen As Double

        For Each obj In listaPorModificar
            volumen += obj.Volumen
            obj.Eficiencia = volumen - obj.LtsTotMenosCalibAtt
            obj.ImporteEficiencia = obj.Eficiencia * Globales.GetInstance._Precio
            objCopia = obj
        Next
        For Each obj In listaPorModificar
            obj.Eficiencia = objCopia.Eficiencia
            obj.ImporteEficiencia = objCopia.ImporteEficiencia
        Next
        Return listaPorModificar
    End Function

    Private Sub frmMigrarDatos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim ordenColumnas(21) As String
        Me.lvDatosMigrar.SortColumns = True
        ordenColumnas(0) = "Autotanque"
        ordenColumnas(1) = "AñoAtt"
        ordenColumnas(2) = "Folio"
        ordenColumnas(3) = "IdServicio"
        ordenColumnas(4) = "Terminal"
        ordenColumnas(5) = "Tag"
        ordenColumnas(6) = "IdUsuario"
        ordenColumnas(7) = "FechaHoraInicial"
        ordenColumnas(8) = "FechaHoraFinal"
        ordenColumnas(9) = "Prefijado"
        ordenColumnas(10) = "Masa"
        ordenColumnas(11) = "Volumen"
        ordenColumnas(12) = "LtsTotMenosCalibAtt"
        ordenColumnas(13) = "ImporteEficiencia"
        ordenColumnas(14) = "Tipo"
        ordenColumnas(15) = "Densidad"
        ordenColumnas(16) = "DensidadPromedio"
        ordenColumnas(17) = "Temperatura"
        ordenColumnas(18) = "TotalizadorIni"
        ordenColumnas(19) = "TotalizadorFin"
        ordenColumnas(20) = "TotalizadorIniMasa"
        ordenColumnas(21) = "TotalizadorFinMasa"
        Me.lvDatosMigrar.ColunmOrder = ordenColumnas
    End Sub
End Class
