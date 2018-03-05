Public Class TransponderLeido
   

    Private userTransponder As String
    Public Property Transponder() As String
        Get
            Return userTransponder
        End Get
        Set(ByVal Value As String)
            userTransponder = Value
        End Set
    End Property

    

End Class
