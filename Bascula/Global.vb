

Imports System.IO

Module [Global]


#Region "Variables globales"
    'Información del usuario
    Public _Celula As Integer
    Public _Usuario As String
    Public _Nombre As String
    Public _DesCelula As String
    Public _Password As String
    Public _Corporativo As Short
    Public _Sucursal As Short
    Public _Parametros As Collection

    'Información de la conexión
    Public _Servidor As String
    Public _Database As String
    Public _CadenaConexion As String

    'Parámetros
    Public _RutaReportes As String    
    Public _ExisteBascula As Boolean
    Public _Precio As Decimal
    Public _ValorCalculoEficiencia As Byte
    Public _Eficiencia As Byte
    Public _FactorDensidad As Decimal
    Public _ClaveModificar As String
    Public _ValorMinimoPorPeso As Integer
    Public _ValorMinimoPorPorcentaje As Integer
    Public _RangoKilometraje As Integer
    Public _LeeTransponder As Boolean

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
    '13 Ciclos Especiales
    '14 GenerarEficienciaMasicoManual
    '15 ImportarInformacionMasico
    Public OperacionBascula(15) As Bascula.SafeLogin.Operation

    'Configuración
    Public Settings As AppSettings

    'Conexión
    'Public cnSigamet As New SqlClient.SqlConnection(SigaMetClasses.LeeInfoConexion(True))
    Public cnSigamet As New SqlClient.SqlConnection()

    '20160614#LUSATE Seguridad Reportes
    Public _SeguridadReportes As Boolean = False

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
#End Region
#Region "Funciones y subrutinas privadas"
    Private Function ValidaAcceso(ByVal Login As SigaMetClasses.Seguridad) As Bascula.Updater.UpdaterResult
        Dim Acceso As New Bascula.SafeLogin()
        Dim Updater As Bascula.Updater
        Dim oConfig As SigaMetClasses.cConfig
        Dim UpdateResult As Bascula.Updater.UpdaterResult
        With Login
            Try
                'Configura conexión
                'cnSigamet.ConnectionString &= "User ID=" & Trim(.UserID) & ";Password=" & .Password & _
                '                             ";Application Name=" & Application.ProductName & " Versión: " & Application.ProductVersion
                'Valida acceso
                If Not Acceso.Authorized(.UserID, .Password, 5, cnSigamet) Then
                    ErrMessage("No tiene privilegios para usar este módulo.")
                    Return Updater.UpdaterResult.RejectUpdate
                    Exit Function
                End If
                'Valida versión
                Updater = New Bascula.Updater(5, Application.ProductVersion, Application.StartupPath, cnSigamet)
                UpdateResult = Updater.Validar()
                If UpdateResult = Updater.UpdaterResult.NotNeedUpdate Then
                    'Carga privilegios
                    Acceso.GetOperation(.UserID, .Password, 5, cnSigamet, OperacionBascula)
                    'Carga parámetros
                    _Corporativo = .Corporativo
                    _Sucursal = .Sucursal
                    _Parametros = .Parametros
                    oConfig = New SigaMetClasses.cConfig(5, _Corporativo, _Sucursal)
                    _Servidor = cnSigamet.DataSource.Trim
                    _Database = cnSigamet.Database.Trim
                    _Usuario = .UserID.Trim
                    _Password = .Password.Trim
                    _Celula = .Celula
                    _Nombre = .UsuarioNombre.Trim
                    _DesCelula = .CelulaDescripcion.Trim
                    _RutaReportes = CStr(oConfig.Parametros("RutaReportesW7"))                    

                    Call TraePrecio()

                    'llenar los globales de parametros
                    _ExisteBascula = CBool(oConfig.Parametros("ExisteBascula"))


                    _FactorDensidad = CDec(oConfig.Parametros("FactorDensidad"))
                    _Eficiencia = CByte(oConfig.Parametros("Eficiencia"))
                    _ValorCalculoEficiencia = CByte(oConfig.Parametros("ValorCalculoEficiencia"))
                    _ClaveModificar = CStr(oConfig.Parametros("ClaveModificar"))
                    _ValorMinimoPorPeso = CInt(oConfig.Parametros("ValorMinimoPeso"))
                    _ValorMinimoPorPorcentaje = CInt(oConfig.Parametros("ValorCalculoEficiencia"))
                    _RangoKilometraje = CInt(oConfig.Parametros("RangoKilometraje"))
                    _LeeTransponder = CBool(oConfig.Parametros("LeeTransponder"))
                    _SeguridadReportes = CType(.Parametros("SeguridadReportes"), Boolean)

                    'Libera objetos no utilizados
                    oConfig.Dispose()
                    Return Updater.UpdaterResult.NotNeedUpdate
                Else
                    Return UpdateResult
                End If
            Catch ex As Exception
                ExMessage(ex)
            End Try
        End With
    End Function
    Private Sub TraePrecio()
        Try
            Dim cmdBascula As New SqlClient.SqlCommand("SELECT precio,vigente,zonaeconomica " & _
                                                            "FROM Precio " & _
                                                            "WHERE vigente = 1 AND zonaeconomica = 0", cnSigamet)
            AbreConexion()
            If Not Microsoft.VisualBasic.IsDBNull(cmdBascula.ExecuteScalar) Then
                _Precio = CDec(cmdBascula.ExecuteScalar)
            End If
        Catch ex As Exception
            ExMessage(ex)
        Finally
            CierraConexion()
        End Try
    End Sub
#End Region


    Public Sub Main()
        Dim frmSplash As New frmSplash()
        'Dim frmLogin As SigaMetClasses.Seguridad
        Dim frmPrincipal As frmPrincipal
        Dim Acceso As Bascula.Updater.UpdaterResult = Updater.UpdaterResult.NotValidated
        frmSplash.ShowDialog()
        'Validación de acceso
        While Acceso = Updater.UpdaterResult.NotValidated
            Dim img As New Bitmap(Application.StartupPath + "\Bascula.ico")
            Dim frmAcceso As New SigametSeguridad.UI.Acceso(Application.StartupPath + "\Default.Seguridad y Administracion.exe.config", True, 5, img)
            'frmSplash.ShowDialog()

            'frmLogin = New SigaMetClasses.Seguridad(Application.ProductName, Application.ProductVersion, Color.LightSteelBlue.Name, Image.FromFile(Application.StartupPath & "\Bascula.ico"))
            'frmLogin.ShowDialog()
            If frmAcceso.ShowDialog() = DialogResult.OK Then
                Dim frmLogin As New SigaMetClasses.Seguridad(5, frmAcceso.CadenaConexion, frmAcceso.Usuario.IdUsuario, frmAcceso.Usuario.ClaveDesencriptada)
                cnSigamet = frmAcceso.Conexion
                cnSigamet.ConnectionString = frmAcceso.CadenaConexion
                Acceso = ValidaAcceso(frmLogin)
                cnSigamet = frmAcceso.Conexion
                cnSigamet.ConnectionString = frmAcceso.CadenaConexion                
            Else
                Application.Exit()
                Exit Sub
            End If
            'frmLogin.Dispose()
        End While
        'Ejecuta la aplicación
        If Acceso = Updater.UpdaterResult.NotNeedUpdate Then
            If Not File.Exists(Application.StartupPath & "\" & Environment.UserName.ToUpper & ".Bascula.exe.config") Then
                File.Copy(Application.StartupPath & "\Default.Bascula.exe.config", Application.StartupPath & "\" & Environment.UserName.ToUpper & ".Bascula.exe.config")
            End If
            Settings = New AppSettings(Application.StartupPath & "\" & Environment.UserName.ToUpper & ".Bascula.exe.config")
            frmPrincipal = New frmPrincipal()
            frmPrincipal.Show()
            Application.Run(frmPrincipal)
        End If
    End Sub

    Public strCnnSigamet As String

End Module
