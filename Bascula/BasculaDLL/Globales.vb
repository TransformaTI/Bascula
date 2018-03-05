Imports System.IO

Public Class Globales

    Private Shared _singleton As Globales

    Private Sub New()

    End Sub

    Shared ReadOnly Property GetInstance() As Globales
        Get
            If _singleton Is Nothing Then
                _singleton = New Globales()
            End If
            Return _singleton
        End Get
    End Property

#Region "Variables globales"
    'Información del usuario
    Public _Celula As Integer
    Public _Usuario As String
    Public _Nombre As String
    Public _DesCelula As String
    Public _Password As String
    Public _Corporativo As Short
    Public _Sucursal As Short

    'Información de la conexión
    Public _Servidor As String
    Public _Database As String

    'Parámetros
    '20120117#TEXIS
    Public _ExisteMasico As Boolean
    Public _RutaReportes As String
    Public _ExisteBascula As Boolean
    Public _Precio As Decimal
    Public _ValorCalculoEficiencia As Byte
    Public _Eficiencia As Byte
    Public _FactorDensidad As Decimal
    Public _FDRellenosSiNo As Boolean
    Public _ClaveModificar As String
    Public _ValorMinimoPorPeso As Integer
    Public _ValorMinimoPorPorcentaje As Integer
    Public _RangoKilometraje As Integer
    Public _LeeTransponder As Boolean
    Public _MedicionFisica As Boolean
    Public _TemperaturaMinima As Decimal
    Public _TemperaturaMaxima As Decimal
    Public _FactorDensidadControlMovimientos As Decimal
    Public _AnticiparPesado As Boolean
    Public _TipoCalculoAlmacen As Byte
    Public _PorcentajeLlenado As Decimal
    Public _TipoDato As Boolean
    Public _Detalle As Byte
    Public _ContenedorPredeterminado As Integer
    Public _MostarLitrajePorPeso As Boolean
    Public _MaxPorcentajeLlenado As Decimal
    Public _CalibracionMinima As Decimal
    Public _CalibracionMaxima As Decimal
    Public _CalibracionPrdeterminada As Decimal
    Public _PresionMaximaGas As Decimal
    Public _PresionMinimaGas As Decimal
    Public _ToleranciaTraciego As Decimal
    Public _PipaCuata As Integer = Nothing

    Public _RutaFotoEmpleado As String

    Public _PedirFMovimiento As Boolean
    Public _FormulaEficiencia As Short
    Public _DatosCelulaRuta As Boolean

    '20120413#CFSL-INICIO
    Public _PesadoAutotanqueIndividual As Boolean
    Public _CargaPorcentajeInventario As Boolean
    Public _UmbralRellenoDefault As Decimal
    Public _EficienciaPesadoATT As Byte
    Public _FormulaEficPesadoATT As Short
    'El valor Default de Porcentaje Inventario será establecido con la variable _PorcentajeLlenado
    '20120413#CFSL-FIN

    '20131001#CFSL-INICIO
    Public _FDRellenosATTIndividual As Boolean
    '20131001#CFSL-FIN

    Public _dtContenedorPredeterminado As New DataTable()


    '20060222$CFSL
    'Se inserto este nuevo parametro para identificar la forma que se leera la cadena del peso en b'ascula
    Public _TipoLecturaCadenaPeso As Short

    '20100309#CFSL
    'Cadena de conexion para descargar la información del Másico y calcular la eficiencia.
    Public _SGCMasicoConnectionString As String

    '20100309#CFSL
    'Variable que contiene el query a realizar para extraer la información
    Public _SGCMasicoQuery1 As String
    Public _SGCMasicoQuery2 As String

    '20120121#TEXIS
    'Variable que contiene el query a realizar para extraer la información 
    Public _SGCMasicoImportacion1 As String
    Public _SGCMasicoImportacion2 As String

    'Parámetros
    '20161124#TEXIS
    'variables para tags

    Public _IpLectorTag As String
    Public _PuertoLectorTag As String
    Public _CaracterLectorTag As String
    Public _PosicionInicialLectorTag As Integer
    Public _NCaracteresLectorTag As Integer


    '20100324#CFSL
    'Variable que controlara en la captura de los kilos de la pantalla de "DatosAdicionalesPG.vb"
    Public _PesoMaximoPemex As Integer

    '20101008#CFSL
    'Variable que contiene el query a realizar para extraer la información
    Public _SGCMasicoSumUpdate1 As String
    Public _SGCMasicoSumUpdate2 As String
    Public _SGCMasicoSumUpdate3 As String
    Public _SGCMasicoAsignaLts As Boolean
    Public _ImprimeEficiencaManual As Boolean

    '20150929#CFSL-INICIO
    Public _PorcentajeGeneral As Decimal
    Public _ConexionComisiones As String
    Public _CierreSinDescargaSGC As Boolean
    Public _MostrarLitrosDescarga As Boolean

    Public _ToleranciaPositivaSGCWEB As Decimal
    Public _ToleranciaNegativaSGCWEB As Decimal

    '20150929#CFSL-FIN

    '23092015#LUSATE-INI
    Public _CelulasUsuario As Boolean
    '23092015#LUSATE-FIN

    'Vector de operaciones
    '1	Anular
    '2	Modificar
    '3	Captura
    '4	Reportes
    '5	CapturaContabilidad
    '6	CambiarParametros
    '7	Catalogos
    '8	Consulta
    '9	HacerTodo
    '10	Imprimir
    '11	CiclosAutomaticos
    '12 CapturaCalibracion
    '13 CiclosEspeciales
    '14 GenerarEficienciaMasicoManual
    '15 ImportarInformacionMasico

    Public OperacionBascula(15) As Bascula.SafeLogin.Operation

    'Configuración
    Public Settings As New AppSettings(Application.StartupPath & "\" & Environment.UserName & ".Bascula.exe.config")

    'Conexión
    Public cnSigamet As New SqlClient.SqlConnection()

    '20150929#CFSL-INICIO
    'Conexión
    Public cnConexionComisiones As New SqlClient.SqlConnection()
    '20150929#CFSL-FIN

#End Region
#Region "Funciones y subrutinas globales"
    'Asignación de datos a un grid
    Public Sub GridData(ByRef Grid As DataGrid, ByVal Table As DataTable, Optional ByVal TableStyleIndex As Integer = -1, Optional ByVal Columns As Integer = 0)
        If CInt(Grid.Width / Table.Columns.Count) - 5 > 0 Then
            If TableStyleIndex = -1 Then
                Grid.PreferredColumnWidth = CInt(Grid.Width / Table.Columns.Count) - 20 + Table.Columns.Count
            Else
                Grid.TableStyles(TableStyleIndex).MappingName = Table.TableName
                Dim Index As Byte
                If Columns = 0 Then
                    Columns = Table.Columns.Count - 1
                End If
                For Index = 0 To CByte(Columns - 1)
                    Grid.TableStyles(TableStyleIndex).GridColumnStyles(Index).Width = CInt(Grid.Width / Columns) - 20 + Columns
                Next Index
            End If
        End If
        Grid.DataSource = Table
    End Sub
    'Busqueda en grid
    Public Function EncuentraRegistro(ByRef Grid As DataGrid, ByVal Busqueda As String, Optional ByVal Columna As Integer = 0) As Boolean
        Dim Index As Integer
        For Index = 0 To CuentaFilas(Grid)
            If Not Microsoft.VisualBasic.IsDBNull(Grid.Item(Index, Columna)) Then
                If Trim(CStr(Grid.Item(Index, Columna))).ToUpper = Trim(Busqueda).ToUpper Then
                    Grid.UnSelect(Grid.CurrentRowIndex)
                    Grid.Select(Index)
                    Grid.CurrentRowIndex = Index
                    Return True
                End If
            End If
        Next
        Return False
    End Function
    'Propiedades de un grid
    Public Function CuentaFilas(ByVal Grid As DataGrid) As Integer
        Return CType(Grid.DataSource, DataTable).Rows.Count - 1
    End Function
    Public Function CuentaColumnas(ByVal Grid As DataGrid) As Integer
        Return CType(Grid.DataSource, DataTable).Columns.Count - 1
    End Function
    'Converción de DataView a DataTable
    Public Function ViewToTable(ByVal DataViewSource As DataView) As DataTable
        Dim dtSource As New DataTable()
        Dim RowIndex, ColumnIndex As Integer
        Dim IArray(DataViewSource.Table.Columns.Count - 1) As Object
        dtSource = DataViewSource.Table.Clone
        For RowIndex = 0 To DataViewSource.Count - 1
            For ColumnIndex = 0 To DataViewSource.Table.Columns.Count - 1
                IArray(ColumnIndex) = DataViewSource.Item(RowIndex)(ColumnIndex)
            Next
            dtSource.Rows.Add(IArray)
        Next
        Return dtSource
    End Function
    'Mensajes de error
    Public Sub ExMessage(ByVal ex As Exception)
        MessageBox.Show(ex.Message, Application.ProductName & " v." & Application.ProductVersion, MessageBoxButtons.OK, MessageBoxIcon.Error)
    End Sub
    Public Sub ErrMessage(ByVal ErrorMessage As String)
        MessageBox.Show(ErrorMessage, Application.ProductName & " v." & Application.ProductVersion, MessageBoxButtons.OK, MessageBoxIcon.Error)
    End Sub
    'Manejo de la conexión
    Public Sub AbreConexion()
        If cnSigamet.State <> ConnectionState.Open Then
            cnSigamet.Open()
        End If
    End Sub
    Public Sub CierraConexion()
        If cnSigamet.State <> ConnectionState.Closed Then
            cnSigamet.Close()
        End If
    End Sub



    'Manejo de la conexión
    Public Sub AbreConexionComisiones()
        If cnConexionComisiones.State <> ConnectionState.Open Then
            cnConexionComisiones.Open()
        End If
    End Sub
    Public Sub CierraConexionComisiones()
        If cnConexionComisiones.State <> ConnectionState.Closed Then
            cnConexionComisiones.Close()
        End If
    End Sub

    'Fecha actual
    Public Function FechaActual() As DateTime
        Dim cmdBascual As New SqlCommand("Select getdate()", cnSigamet)
        Dim res As DateTime
        Try
            AbreConexion()
            res = CDate(cmdBascual.ExecuteScalar)
            Return res
        Catch ex As Exception
            Throw ex
        Finally
            cmdBascual.Dispose()
            CierraConexion()
        End Try
    End Function
#End Region

#Region "Rutinas Privadas"
    Private Sub CargaContenedorPredeterminado()
        Dim cmdComando As New SqlCommand("Select Corporativo,Sucursal,Cast(Isnull(Valor,0) As Smallint) Valor From Parametro Where Modulo = 5 and Parametro = 'ContenedorPredeterminado'  Order By Corporativo,Sucursal", Globales.GetInstance.cnSigamet)
        Dim daContenedor As New SqlDataAdapter(cmdComando)
        Dim dtContenedor As New DataTable()
        Try
            daContenedor.Fill(dtContenedor)
            _dtContenedorPredeterminado = dtContenedor
            Dim keys(1) As DataColumn
            keys(0) = _dtContenedorPredeterminado.Columns("Corporativo")
            keys(1) = _dtContenedorPredeterminado.Columns("Sucursal")
            _dtContenedorPredeterminado.PrimaryKey = keys
        Catch ex As Exception
            Globales.GetInstance.ExMessage(ex)
        End Try
    End Sub

#End Region
    Public Sub ConfiguraModulo(ByVal cn As SqlConnection, ByVal Usuario As String, ByVal Password As String, ByVal Corporativo As Short, ByVal Sucursal As Short)
        Dim Acceso As New Bascula.SafeLogin()
        'Dim Updater As Bascula.Updater
        'Dim cmdBascula As New SqlCommand("Select Valor from Parametro where Modulo = @Modulo and Parametro = @Parametro")
        'Dim cmdBascula As New SqlCommand("exec spSEGParametrosModulo " & CStr(5) & ", " & Corporativo.ToString() & ", " & Sucursal.ToString)
        'Dim UpdateResult As Bascula.Updater.UpdaterResult
        cnSigamet = cn
        _Usuario = Usuario
        _Password = Password
        _Servidor = cn.DataSource
        _Database = cn.Database
        _Corporativo = Corporativo
        _Sucursal = Sucursal


        'cmdBascula.Connection = cnSigamet
        PortatilClasses.Globals.GetInstance.ConfiguraModulo(_Usuario, _Password, cnSigamet.ConnectionString, _Corporativo, _Sucursal)


        Try

            'Carga privilegios
            Acceso.GetOperation(_Usuario, _Password, 5, cnSigamet, OperacionBascula)
            'Carga parámetros

            Dim oConfig As New SigaMetClasses.cConfig(5, _Corporativo, _Sucursal)
            _RutaReportes = CType(oConfig.Parametros("RutaReportesW7"), String).Trim
            _ExisteBascula = CBool(CStr(oConfig.Parametros("ExisteBascula")).Trim)
            _FactorDensidad = CDec(CStr(oConfig.Parametros("FactorDensidad")).Trim)
            _Eficiencia = CByte(CStr(oConfig.Parametros("Eficiencia")).Trim)
            _ValorCalculoEficiencia = CByte(CStr(oConfig.Parametros("ValorCalculoEficiencia")).Trim)
            _ClaveModificar = CStr(oConfig.Parametros("ClaveModificar")).Trim
            _ValorMinimoPorPeso = CInt(CStr(oConfig.Parametros("ValorMinimoPeso")).Trim)
            _ValorMinimoPorPorcentaje = CInt(CStr(oConfig.Parametros("ValorCalculoEficiencia")).Trim)
            _RangoKilometraje = CInt(CStr(oConfig.Parametros("RangoKilometraje")).Trim)
            _LeeTransponder = CBool(CStr(oConfig.Parametros("LeeTransponder")).Trim)
            _MedicionFisica = CBool(CStr(oConfig.Parametros("MedicionFisica")).Trim)
            _AnticiparPesado = CBool(CStr(oConfig.Parametros("AnticiparPesado")).Trim)
            _TipoCalculoAlmacen = CByte(CStr(oConfig.Parametros("TipoCalculoAlmacen")).Trim)
            _PorcentajeLlenado = CDec(CStr(oConfig.Parametros("PorcentajeLlenado")).Trim)
            _TipoDato = CBool(CStr(oConfig.Parametros("TipoDato")).Trim)
            _Detalle = CByte(CStr(oConfig.Parametros("Detalle")).Trim)
            _ContenedorPredeterminado = CInt(CStr(oConfig.Parametros("ContenedorPredeterminado")).Trim)
            _MaxPorcentajeLlenado = CInt(CStr(oConfig.Parametros("MaxPorcentajeLlenado")).Trim)
            _MostarLitrajePorPeso = CBool(CStr(oConfig.Parametros("MostarLitrajePorPeso")).Trim)
            _ToleranciaTraciego = CDec(CStr(oConfig.Parametros("ToleranciaTraciego")).Trim)
            _PedirFMovimiento = CBool(CStr(oConfig.Parametros("PedirFMovimiento")).Trim)
            _FormulaEficiencia = CShort(CStr(oConfig.Parametros("FormulaEficiencia")).Trim)
            If _Sucursal = 1 And _Corporativo = 1 Then
                _PipaCuata = CInt(CStr(oConfig.Parametros("PipaCuata")).Trim)
            End If


            '20070129CFSL#004
            _RutaFotoEmpleado = CType(oConfig.Parametros("RutaFotoEmpleado"), String).Trim


            '20060222CFSL#001
            _TipoLecturaCadenaPeso = CShort(CStr(oConfig.Parametros("TipoLecturaCadenaPeso")).Trim)
            '20060310CFSL#002
            _DatosCelulaRuta = CBool(CStr(oConfig.Parametros("DatosCelulaRuta")).Trim)
            '20060311CFSL#003
            CargaContenedorPredeterminado()

            '20100309#CFSL
            _SGCMasicoConnectionString = CType(oConfig.Parametros("SGCMasicoConnectionString"), String).Trim
            _SGCMasicoQuery1 = CType(oConfig.Parametros("SGCMasicoQuery1"), String).Trim
            _SGCMasicoQuery2 = CType(oConfig.Parametros("SGCMasicoQuery2"), String).Trim


            '20100324#CFSL - Se agrego la validacion de PesoMaximoPemex en el complemento de datos de los embarques
            _PesoMaximoPemex = CInt(CStr(oConfig.Parametros("PesoMaximoPemex")).Trim)

            '20101008#CFSL
            _SGCMasicoSumUpdate1 = CType(oConfig.Parametros("SGCMasicoSumUpdate1"), String).Trim
            _SGCMasicoSumUpdate2 = CType(oConfig.Parametros("SGCMasicoSumUpdate2"), String).Trim
            _SGCMasicoSumUpdate3 = CType(oConfig.Parametros("SGCMasicoSumUpdate3"), String).Trim
            '20120117#TEXIS
            _ExisteMasico = CBool(CStr(oConfig.Parametros("ExisteMasico")).Trim)
            _SGCMasicoAsignaLts = CBool(CStr(oConfig.Parametros("SGCMasicoAsignaLts")).Trim)
            _SGCMasicoImportacion1 = CType(oConfig.Parametros("SGCMasicoImportacion1"), String).Trim
            _SGCMasicoImportacion2 = CType(oConfig.Parametros("SGCMasicoImportacion2"), String).Trim
            _ImprimeEficiencaManual = CBool(CStr(oConfig.Parametros("ImprimeEficiencaManual")).Trim)

            _IpLectorTag = CType(oConfig.Parametros("IpLectorTag"), String).Trim
            _PuertoLectorTag = CType(oConfig.Parametros("PuertoLectorTag"), String).Trim
            _CaracterLectorTag = CType(oConfig.Parametros("CaracterLectorTag"), String).Trim
            _PosicionInicialLectorTag = CInt(CStr(oConfig.Parametros("PosicionInicialLectorTag")).Trim)
            _NCaracteresLectorTag = CInt(CStr(oConfig.Parametros("NCaracteresLectorTag")).Trim)

            '20120413#CFSL-INICIO
            _PesadoAutotanqueIndividual = CBool(CStr(oConfig.Parametros("PesadoATTIndividual")).Trim)
            _CargaPorcentajeInventario = CBool(CStr(oConfig.Parametros("CargaPorcentajeInventario")).Trim)
            _UmbralRellenoDefault = CDec(CStr(oConfig.Parametros("UmbralRellenoDefault")).Trim)
            _EficienciaPesadoATT = CByte(CStr(oConfig.Parametros("EficienciaPesadoATT")).Trim)
            _FormulaEficPesadoATT = CShort(CStr(oConfig.Parametros("FormulaEficPesadoATT")).Trim)
            _FDRellenosSiNo = CBool(CStr(oConfig.Parametros("FDRellenosSiNo")).Trim)
            '20120413#CFSL-FIN

            '20131001#CFSL-INICIO
            _FDRellenosATTIndividual = CBool(CStr(oConfig.Parametros("FDRellenosATTIndividual")).Trim)
            '20131001#CFSL-FIN


            '20150929#CFSL-INICIO
            _PorcentajeGeneral = CDec(CStr(oConfig.Parametros("PorcentajeGeneral")).Trim)
            _ConexionComisiones = CType(oConfig.Parametros("ConexionComisiones"), String).Trim
            _CierreSinDescargaSGC = CBool(CStr(oConfig.Parametros("CierreSinDescargaSGC")).Trim)
            _MostrarLitrosDescarga = CBool(CStr(oConfig.Parametros("MostrarLitrosDescarga")).Trim)

            cnConexionComisiones = New SqlClient.SqlConnection(_ConexionComisiones)

            _ToleranciaPositivaSGCWEB = CDec(CStr(oConfig.Parametros("ToleranciaPositivaSGCWEB")).Trim)
            _ToleranciaNegativaSGCWEB = CDec(CStr(oConfig.Parametros("ToleranciaNegativaSGCWEB")).Trim)

            '20150929#CFSL-FIN

            '23032016#LUSATE-INI
            _CelulasUsuario = CBool(CStr(oConfig.Parametros("CelulasUsuario")).Trim)
            '23032016#LUSATE-FIN

            oConfig = New SigaMetClasses.cConfig(16, _Corporativo, _Sucursal)
            _TemperaturaMinima = CDec(CStr(oConfig.Parametros("TemperaturaMinimaTanque")).Trim)
            _TemperaturaMaxima = CDec(CStr(oConfig.Parametros("TemperaturaMaximaTanque")).Trim)
            _PresionMaximaGas = CDec(CStr(oConfig.Parametros("PresionMaximaTanque")).Trim)
            _PresionMinimaGas = CDec(CStr(oConfig.Parametros("PresionMinimaTanque")).Trim)
            _FactorDensidadControlMovimientos = CDec(CStr(oConfig.Parametros("FactorDensidad")).Trim)


            oConfig = New SigaMetClasses.cConfig(6, _Corporativo, _Sucursal)
            _CalibracionMaxima = CDec(CStr(oConfig.Parametros("CalibracionMaxima")).Trim)
            _CalibracionMinima = CDec(CStr(oConfig.Parametros("CalibracionMinima")).Trim)
            _CalibracionPrdeterminada = CDec(CStr(oConfig.Parametros("CalibracionPredeterminada")).Trim)


            Dim cmdBascula As New SqlCommand()
            cmdBascula.Connection = cnSigamet
            AbreConexion()
            cmdBascula.CommandText = "SELECT precio,vigente,zonaeconomica " & _
                                        "FROM Precio " & _
                                        "WHERE vigente = 1 AND zonaeconomica = 0"

            If Not Microsoft.VisualBasic.IsDBNull(cmdBascula.ExecuteScalar) Then
                _Precio = CDec(cmdBascula.ExecuteScalar)
            End If
        Catch ex As Exception
            ExMessage(ex)
        Finally
            CierraConexion()
        End Try
    End Sub



End Class
