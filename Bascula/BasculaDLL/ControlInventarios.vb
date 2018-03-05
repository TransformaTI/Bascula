Public Class ControlInventarios

    Dim _limiteInferiorFD As Double
    Dim _limiteSuperiorFD As Double

    Public Sub New(ByVal limiteInferiorFD As Double, ByVal limiteSuperiorFD As Double)
        _limiteInferiorFD = limiteInferiorFD
        _limiteSuperiorFD = limiteSuperiorFD
    End Sub

    Public Function FaltantesPorPorcentaje(ByVal capacidadATT As Decimal, ByVal calibracionVolumen As Integer, ByVal ventaTotalizador As Decimal, ByVal porcentajeSalida As Integer, ByVal porcentajeRegreso As Integer, ByVal factorDensidadRellenos As Double, ByVal tolerancia As Integer) As Double
        Dim eficiencia As Double
        Dim _litrosVendidos As Double
        Dim _porcentajeVendido As Integer
        _porcentajeVendido = PorcentajeVendido(porcentajeSalida, porcentajeRegreso)
        _litrosVendidos = LitrosVendidos(capacidadATT, _porcentajeVendido, calibracionVolumen)

        If ventaTotalizador >= _litrosVendidos Then
            eficiencia = 0
        Else
            eficiencia = _litrosVendidos - ventaTotalizador
            If eficiencia <= tolerancia Then
                eficiencia = 0
            End If
        End If
        Return eficiencia
    End Function

    Public Function LitrosVendidos(ByVal capacidadATT As Decimal, ByVal porcentajeVendido As Integer, ByVal calibracionVolumen As Integer) As Decimal
        Dim _litrosVendidos As Decimal
        _litrosVendidos = ((capacidadATT * porcentajeVendido) * (100 + (100 - calibracionVolumen)))
        Return _litrosVendidos
    End Function

    Public Function PorcentajeVendido(ByVal porcentajeSalida As Integer, ByVal porcentajeRegreso As Integer) As Integer
        Dim _porcentajeVendido As Integer
        _porcentajeVendido = porcentajeSalida - porcentajeRegreso
        Return _porcentajeVendido
    End Function

    Public Function FactorDeDensidad(ByVal masas() As Double, ByVal volumenes() As Double) As Double
        Dim factorDensidad As Double
        If masas.Length > 0 AndAlso volumenes.Length > 0 Then
            factorDensidad = (SumarArreglo(masas) / SumarArreglo(volumenes))
            If factorDensidad < _limiteInferiorFD Then
                factorDensidad = _limiteInferiorFD
            End If
            If factorDensidad > _limiteSuperiorFD Then
                factorDensidad = _limiteSuperiorFD
            End If
        Else
            factorDensidad = 0
        End If

        Return factorDensidad
    End Function

    Public Function FaltantesPorPeso(ByVal capacidadATT As Decimal, ByVal calibracionPeso As Decimal, ByVal ventaTotalizador As Decimal, ByVal PorcentajeSalida As Decimal, ByVal porcentajeRegreso As Decimal, ByVal kilosSalida As Integer, ByVal kilosRegreso As Integer, ByVal factorDensidadRellenos As Decimal, ByVal tolerancia As Integer) As Double
        Dim eficiencia As Double
        Dim sobrante As Double
        sobrante = SobranteEnLitrosPeso(capacidadATT, calibracionPeso, ventaTotalizador, PorcentajeSalida, porcentajeRegreso, kilosSalida, kilosRegreso, factorDensidadRellenos, tolerancia)
        If sobrante >= 0 Then

            eficiencia = 0
        Else
            eficiencia = Math.Abs(sobrante)
            If eficiencia <= tolerancia Then
                eficiencia = 0
            End If
        End If
        Return eficiencia
    End Function

    Public Function SobranteEnLitrosPeso(ByVal capacidadATT As Decimal, ByVal calibracionPeso As Decimal, ByVal ventaTotalizador As Decimal, ByVal PorcentajeSalida As Decimal, ByVal porcentajeRegreso As Decimal, ByVal kilosSalida As Integer, ByVal kilosRegreso As Integer, ByVal factorDensidadRellenos As Decimal, ByVal tolerancia As Integer) As Double
        Dim faltanteGas As Decimal
        faltanteGas = ventaTotalizador - (((kilosSalida - kilosRegreso) / factorDensidadRellenos) * (100 + (100 - calibracionPeso)))
        Return faltanteGas
    End Function

    Private Function SumarArreglo(ByVal arr() As Double) As Double
        Dim sumatoria As Double = 0
        Dim i As Integer
        If arr.Length > 0 Then
            For i = 0 To (arr.Length - 1)
                sumatoria += arr(i)
            Next i
        End If
        Return sumatoria
    End Function

    Public Function LitrosRelleno(ByVal ventaTotalizador As Decimal, ByVal calibracionVolumen As Integer, ByVal litrosComerciales As Decimal, ByVal litrosFaltenteGas As Decimal) As Decimal
        Dim _litrosRelleno As Decimal
        _litrosRelleno = (ventaTotalizador * calibracionVolumen) + litrosComerciales + litrosFaltenteGas
        Return _litrosRelleno
    End Function

    Public Function PorcentajeTeorico(ByVal capacidadATT As Decimal, ByVal porcentajeLLegada As Integer, ByVal litrosRelleno As Decimal) As Decimal
        Dim _porcentajeTeorico As Decimal
        _porcentajeTeorico = (((capacidadATT * porcentajeLLegada) + litrosRelleno) * 100) / capacidadATT
        Return _porcentajeTeorico
    End Function

    Public Function LimitePorcentajeNominalInventario(ByVal porcentajeNominalInv As Integer, ByVal umbralRelleno As Integer) As Integer
        Dim _limitePorcentajeNominalInventario As Integer
        _limitePorcentajeNominalInventario = porcentajeNominalInv - umbralRelleno
        Return _limitePorcentajeNominalInventario
    End Function

    Public Function CalculoPorcentajeNominalInventario(ByVal ventaTotalizador As Decimal, ByVal calibracionVolumen As Integer, ByVal litrosComerciales As Decimal, ByVal litrosFaltenteGas As Decimal, ByVal capacidadATT As Decimal, ByVal porcentajeLlegada As Integer, ByVal porcentajeNominalInventario As Integer, ByVal umbralRelleno As Integer) As Decimal
        Dim _litrosInventarioNominal As Decimal
        Dim _limitePorcentajeNominalInv As Decimal
        Dim _porcentajeTeoricoLlenado As Decimal
        Dim _litrosRelleno As Decimal

        _limitePorcentajeNominalInv = LimitePorcentajeNominalInventario(porcentajeNominalInventario, umbralRelleno)
        _litrosRelleno = LitrosRelleno(ventaTotalizador, calibracionVolumen, litrosComerciales, litrosFaltenteGas)
        _porcentajeTeoricoLlenado = PorcentajeTeorico(capacidadATT, porcentajeLlegada, _litrosRelleno)

        If _limitePorcentajeNominalInv >= _porcentajeTeoricoLlenado Then
            _litrosInventarioNominal = 0
        Else
            _litrosInventarioNominal = (porcentajeNominalInventario * capacidadATT) - (_limitePorcentajeNominalInv * capacidadATT)
        End If
        Return _litrosInventarioNominal
    End Function


End Class

