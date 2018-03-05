Public Class Empleado

    Public Sub New(ByVal Empleado As Integer, ByVal ConexionSQL As SqlConnection)
        _Empleado = Empleado
        cn = ConexionSQL
        CargaDatos()
    End Sub

    Public Sub New(ByVal Empleado As Integer, ByVal ConexionSQL As SqlConnection, ByVal RutaFoto As String)
        _Empleado = Empleado
        Me.RutaFoto = RutaFoto
        CargaDatos()
    End Sub

    Private _Empleado As Integer
    Private _Nombre As String
    Private _IDPuesto As Integer
    Private _Puesto As String
    Private _IDCorporativo As Integer
    Private _Corporativo As String
    Private _Sueldo As Decimal
    Private _Status As String
    Private _Foto As Bitmap

    Private cn As SqlConnection
    Private RutaFoto As String

    ReadOnly Property Empleado() As Integer
        Get
            Return _Empleado
        End Get
    End Property
    ReadOnly Property Nombre() As String
        Get
            Return _Nombre
        End Get
    End Property
    ReadOnly Property IDPuesto() As Integer
        Get
            Return _IDPuesto
        End Get
    End Property
    ReadOnly Property Puesto() As String
        Get
            Return _Puesto
        End Get
    End Property
    ReadOnly Property IDCorporativo() As Integer
        Get
            Return _IDCorporativo
        End Get
    End Property
    ReadOnly Property Corporativo() As String
        Get
            Return _Corporativo
        End Get
    End Property
    ReadOnly Property Sueldo() As Decimal
        Get
            Return _Sueldo
        End Get
    End Property
    ReadOnly Property Status() As String
        Get
            Return _Status
        End Get
    End Property
    Property Foto() As Bitmap
        Get
            Return _Foto
        End Get
        Set(ByVal Value As Bitmap)
            _Foto = Value
        End Set
    End Property

    Private Sub CargaDatos()
        Dim cmd As New SqlCommand("Select * from vwSEGEmpleados where Empleado = @Empleado", cn)
        Dim rd As SqlDataReader = Nothing
        Dim open As Boolean
        cmd.Parameters.Add("@Empleado", SqlDbType.Int).Value = _Empleado
        Try
            If cn.State <> ConnectionState.Open Then
                cn.Open()
                open = True
            End If

            rd = cmd.ExecuteReader

            If rd.Read Then
                If Not Microsoft.VisualBasic.IsDBNull(rd("Nombre")) Then
                    _Nombre = CStr(rd("Nombre"))
                End If
                If Not Microsoft.VisualBasic.IsDBNull(rd("IDPuesto")) Then
                    _IDPuesto = CInt(rd("IDPuesto"))
                End If
                If Not Microsoft.VisualBasic.IsDBNull(rd("Puesto")) Then
                    _Puesto = CStr(rd("Puesto"))
                End If
                If Not Microsoft.VisualBasic.IsDBNull(rd("IDCorporativo")) Then
                    _IDCorporativo = CInt(rd("IDCorporativo"))
                End If
                If Not Microsoft.VisualBasic.IsDBNull(rd("Corporativo")) Then
                    _Corporativo = CStr(rd("Corporativo"))
                End If
                If Not Microsoft.VisualBasic.IsDBNull(rd("Sueldo")) Then
                    _Sueldo = CDec(rd("Sueldo"))
                End If
                If Not Microsoft.VisualBasic.IsDBNull(rd("Status")) Then
                    _Status = CStr(rd("Status"))
                End If
            End If
            rd.Close()
            If IO.File.Exists(Globales.GetInstance._RutaFotoEmpleado & Empleado & ".jpg") Then
                _Foto = New Bitmap(Globales.GetInstance._RutaFotoEmpleado & Empleado & ".jpg")
            End If
            RaiseEvent DataChanged(Me, Nothing)
        Catch ex As Exception
            Globales.GetInstance.ExMessage(ex)
        Finally
            Try
                rd.Close()
            Catch
            End Try
            If open Then
                cn.Close()
            End If
        End Try
    End Sub


    Public Event DataChanged(ByVal sender As Object, ByVal e As System.EventArgs)



End Class
