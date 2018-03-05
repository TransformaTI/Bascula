Option Strict On
Option Explicit On 

Imports System.Windows.Forms
Imports System.IO

Module Main
    'Public GLOBAL_Servidor As String
    'Public GLOBAL_BaseDatos As String
    Public GLOBAL_Usuario As String
    Public GLOBAL_Password As String
    Public GLOBAL_Corporativo As Short
    Public GLOBAL_Sucursal As Short
    'Public GLOBAL_RutaReportes As String
End Module

'Public MustInherit Class Conexion
'    Private _FileConfiguracion As String

'    Protected Property FileConfiguracion() As String
'        Get
'            Return _FileConfiguracion
'        End Get
'        Set(ByVal Value As String)
'            _FileConfiguracion = Value
'        End Set
'    End Property

'    Public ReadOnly Property GLOBAL_ConString() As String
'        Get
'            Return FileConfiguracion & "User ID=" & GLOBAL_Usuario & ";Password=" & GLOBAL_Password & ";"
'        End Get
'    End Property

'    Protected Sub AbrirArchivo()
'        Dim fileName As String = Application.StartupPath & "\Login.inf"
'        Dim fileInfo As New FileInfo(fileName)

'        If fileInfo.Exists Then
'            fileInfo.OpenRead()
'            Dim r As StreamReader = fileInfo.OpenText()
'            FileConfiguracion = r.ReadLine()
'            r.Close()
'        Else
'            MessageBox.Show("No existe el archivo de configuracion", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
'        End If
'    End Sub

'    Sub New()
'        AbrirArchivo()
'    End Sub

'End Class
