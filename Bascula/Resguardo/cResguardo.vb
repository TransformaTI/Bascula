Option Strict On
Option Explicit On 

Imports System.Data.SqlClient
Imports System.Windows.Forms
Imports System.IO
Namespace Resguardo

#Region "Class cAutotanqueTurno"
    Public Class cAutotanqueTurno
        'Inherits Conexion
        Public dtTable As DataTable
        'Public GLOBAL_Conexion As New SqlConnection(GLOBAL_ConString)
        Public GLOBAL_Conexion As SqlConnection = SigametSeguridad.Seguridad.Conexion
        Protected cmd As SqlCommand

        Private _FolioAtt As Integer
        Private _AnoAtt As Short
        Private _AlmacenGas As Integer
        Private _Autotanque As Integer
        Private _Celula As Short
        Private _Corporativo As Short
        Private _TipoProducto As Short
        Private _CapacidadOperativa As Decimal

        Public Property FolioAtt() As Integer
            Get
                Return _FolioAtt
            End Get
            Set(ByVal Value As Integer)
                _FolioAtt = Value
            End Set
        End Property

        Public Property AnoAtt() As Short
            Get
                Return _AnoAtt
            End Get
            Set(ByVal Value As Short)
                _AnoAtt = Value
            End Set
        End Property

        Public Property AlmacenGas() As Integer
            Get
                Return _AlmacenGas
            End Get
            Set(ByVal Value As Integer)
                _AlmacenGas = Value
            End Set
        End Property

        Public Property Autotanque() As Integer
            Get
                Return _Autotanque
            End Get
            Set(ByVal Value As Integer)
                _Autotanque = Value
            End Set
        End Property

        Public Property Celula() As Short
            Get
                Return _Celula
            End Get
            Set(ByVal Value As Short)
                _Celula = Value
            End Set
        End Property

        Public Property Corporativo() As Short
            Get
                Return _Corporativo
            End Get
            Set(ByVal Value As Short)
                _Corporativo = Value
            End Set
        End Property

        Public Property TipoProducto() As Short
            Get
                Return _TipoProducto
            End Get
            Set(ByVal Value As Short)
                _TipoProducto = Value
            End Set
        End Property

        Public Property CapacidadOperativa() As Decimal
            Get
                Return _CapacidadOperativa
            End Get
            Set(ByVal Value As Decimal)
                _CapacidadOperativa = Value
            End Set
        End Property

        Public Sub New()

        End Sub

        'Constructor para inicializar los valores de la clase
        Public Sub New(ByVal intFolioAtt As Integer, _
                       ByVal shtAnoAtt As Short)
            FolioAtt = intFolioAtt
            AnoAtt = shtAnoAtt
        End Sub

        'Metodo para realizar el registro, modificacion o eliminacion de un registro
        'en la tabla MovimientoAlmacenProductoZona
        Public Sub ConsultarAutotanque()
            Dim dr As SqlDataReader
            Dim IdentificadorAlmacenGas As Integer = 0
            AsignarParametrosConsultarAutotanque()
            Try
                GLOBAL_Conexion.Open()
                dr = cmd.ExecuteReader(CommandBehavior.CloseConnection)
                dr.Read()
                _AlmacenGas = CType(dr(2), Integer)
                _Autotanque = CType(dr(3), Integer)
                _Celula = CType(dr(4), Short)
                _Corporativo = CType(dr(5), Short)
                _TipoProducto = CType(dr(6), Short)
                _CapacidadOperativa = CType(dr(7), Decimal)
            Catch ex As Exception
                _AlmacenGas = 0
                _Autotanque = 0
                _Celula = 0
                _Corporativo = 0
                _TipoProducto = 0
                _CapacidadOperativa = 0
                MessageBox.Show(ex.Message, "Resguardo", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
            GLOBAL_Conexion.Close()
        End Sub

        'Metodo de la clase para asignar los parametros al procedimiento que ejecutara cada
        'una de las acciones
        Protected Sub AsignarParametrosConsultarAutotanque()
            cmd = New SqlCommand("spINVAutotanqueTurno", GLOBAL_Conexion)
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.Add("@FolioAtt", SqlDbType.Int).Value = FolioAtt
            cmd.Parameters.Add("@AnoAtt", SqlDbType.SmallInt).Value = AnoAtt
        End Sub
    End Class
#End Region

#Region "Class cResguardo"
    Public Class cResguardo
        'Inherits Conexion

        Private _MovimientoAlmacen As Integer
        Private _AnoAtt As Short
        Private _FolioAtt As Integer
        Private _Cliente As Integer
        Private _Status As String
        Private _CapacidadTanque As Integer
        Private _PorcentajeInicial As Decimal
        Private _PorcentajeFinal As Decimal
        Private _Litros As Decimal
        Private _FResguardo As DateTime

        Protected Property MovimientoAlmacen() As Integer
            Get
                Return _MovimientoAlmacen
            End Get
            Set(ByVal Value As Integer)
                _MovimientoAlmacen = Value
            End Set
        End Property

        Protected Property AnoAtt() As Short
            Get
                Return _AnoAtt
            End Get
            Set(ByVal Value As Short)
                _AnoAtt = Value
            End Set
        End Property

        Protected Property FolioAtt() As Integer
            Get
                Return _FolioAtt
            End Get
            Set(ByVal Value As Integer)
                _FolioAtt = Value
            End Set
        End Property

        Protected Property Cliente() As Integer
            Get
                Return _Cliente
            End Get
            Set(ByVal Value As Integer)
                _Cliente = Value
            End Set
        End Property

        Protected Property Status() As String
            Get
                Return _Status
            End Get
            Set(ByVal Value As String)
                _Status = Value
            End Set
        End Property

        Protected Property CapacidadTanque() As Integer
            Get
                Return _CapacidadTanque
            End Get
            Set(ByVal Value As Integer)
                _CapacidadTanque = Value
            End Set
        End Property

        Protected Property PorcentajeInicial() As Decimal
            Get
                Return _PorcentajeInicial
            End Get
            Set(ByVal Value As Decimal)
                _PorcentajeInicial = Value
            End Set
        End Property

        Protected Property PorcentajeFinal() As Decimal
            Get
                Return _PorcentajeFinal
            End Get
            Set(ByVal Value As Decimal)
                _PorcentajeFinal = Value
            End Set
        End Property

        Protected Property Litros() As Decimal
            Get
                Return _Litros
            End Get
            Set(ByVal Value As Decimal)
                _Litros = Value
            End Set
        End Property

        Protected Property FResguardo() As DateTime
            Get
                Return _FResguardo
            End Get
            Set(ByVal Value As DateTime)
                _FResguardo = Value
            End Set
        End Property

        Public Sub New()

        End Sub

        Public Sub New(ByVal intMovimientoAlmacen As Integer, _
                       ByVal shtAnoAtt As Short, _
                       ByVal intFolioAtt As Integer, _
                       ByVal intCliente As Integer, _
                       ByVal strStatus As String, _
                       ByVal intCapacidadTanque As Integer, _
                       ByVal decPorcentajeInicial As Decimal, _
                       ByVal decPorcentajeFinal As Decimal, _
                       ByVal decLitros As Decimal, _
                       ByVal dtFResguardo As DateTime)
            MovimientoAlmacen = intMovimientoAlmacen
            AnoAtt = shtAnoAtt
            FolioAtt = intFolioAtt
            Cliente = intCliente
            Status = strStatus
            CapacidadTanque = intCapacidadTanque
            PorcentajeInicial = decPorcentajeInicial
            PorcentajeFinal = decPorcentajeFinal
            Litros = decLitros
            FResguardo = dtFResguardo
        End Sub

        Public Sub AlmacenarResguardo()
            'Dim cnSigamet As SqlConnection
            Dim cnSigamet As SqlConnection = SigametSeguridad.Seguridad.Conexion
            Dim cmdComando As SqlCommand
            Dim drAlmacen As SqlDataReader
            'AbrirArchivo()
            Try
                'cnSigamet = New SqlConnection(GLOBAL_ConString)
                cmdComando = New SqlCommand("spINVResguardo", cnSigamet)

                cmdComando.Parameters.Add("@MovimientoAlmacen", SqlDbType.Int).Value = MovimientoAlmacen
                cmdComando.Parameters.Add("@AnoAtt", SqlDbType.SmallInt).Value = AnoAtt
                cmdComando.Parameters.Add("@FolioAtt", SqlDbType.Int).Value = FolioAtt
                cmdComando.Parameters.Add("@Cliente", SqlDbType.Int).Value = Cliente
                cmdComando.Parameters.Add("@Status", SqlDbType.VarChar).Value = Status
                cmdComando.Parameters.Add("@CapacidadTanque", SqlDbType.Int).Value = CapacidadTanque
                cmdComando.Parameters.Add("@PorcentajeIncial", SqlDbType.Decimal).Value = PorcentajeInicial
                cmdComando.Parameters.Add("@PorcentajeFinal", SqlDbType.Decimal).Value = PorcentajeFinal
                cmdComando.Parameters.Add("@Litros", SqlDbType.Decimal).Value = Litros
                cmdComando.Parameters.Add("@FResguardo", SqlDbType.DateTime).Value = FResguardo
                cmdComando.CommandType = CommandType.StoredProcedure
                cnSigamet.Open()
                drAlmacen = cmdComando.ExecuteReader(CommandBehavior.CloseConnection)
                cnSigamet.Close()
            Catch exc As Exception
                EventLog.WriteEntry("Clase Consulta" & exc.Source, exc.Message, EventLogEntryType.Error)
                MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Sub


    End Class
#End Region
End Namespace

