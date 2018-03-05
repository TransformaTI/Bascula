Imports System.Windows.Forms

Public Class ValidaCierreAutotanque

    Public Sub New(ByVal PesoVisible As Boolean, ByVal VerificaDescarga As Boolean, ByVal CierraSinDescarga As Boolean, ByVal MostrarLitrosDescarga As Boolean, ByVal PesoCierre As Decimal, ClientesAtendidos As Integer, LitrosTotalizadorSGC As Decimal, LitrosTotalizadorATT As Integer)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.


        Dim _DiferenciaTotalizadorVsSGC As Decimal
        Dim _AceptarVisible As Boolean = False

        Label1.Visible = PesoVisible
        lblPeso.Visible = PesoVisible

        Label5.Visible = MostrarLitrosDescarga
        lblLitros.Visible = MostrarLitrosDescarga

        lblPeso.Text = PesoCierre.ToString("N1")
        lblClientes.Text = ClientesAtendidos.ToString()
        lblLitros.Text = LitrosTotalizadorSGC.ToString("N1")
        lblLitrosTotalizador.Text = LitrosTotalizadorATT.ToString("N1")




        _DiferenciaTotalizadorVsSGC = LitrosTotalizadorATT - LitrosTotalizadorSGC

        If _DiferenciaTotalizadorVsSGC >= Globales.GetInstance._ToleranciaNegativaSGCWEB And _DiferenciaTotalizadorVsSGC <= Globales.GetInstance._ToleranciaPositivaSGCWEB Then
            lblNota.Text = "¡La información de los suministros fue descargada exitosamente!"
            _AceptarVisible = True
        ElseIf _DiferenciaTotalizadorVsSGC > Globales.GetInstance._ToleranciaPositivaSGCWEB Then
            lblNota.Text = "Falta información por descargar. Por favor ENCIENDA SU TABLETA."
            lblClientes.ForeColor = Color.Red
            lblLitros.ForeColor = Color.Red
            If CierraSinDescarga Then
                _AceptarVisible = True
            Else
                If ClientesAtendidos = 0 And VerificaDescarga = False Then
                    _AceptarVisible = True
                ElseIf ClientesAtendidos = 0 And VerificaDescarga = True Then
                    _AceptarVisible = False
                End If
            End If
        ElseIf _DiferenciaTotalizadorVsSGC < Globales.GetInstance._ToleranciaNegativaSGCWEB Then
            lblNota.Text = "Hay un excendente de información descargada."
            lblClientes.ForeColor = Color.Olive
            lblLitros.ForeColor = Color.Olive
            _AceptarVisible = True
        End If

        lblNotaConfirmacion.Visible = _AceptarVisible
        OK_Button.Visible = _AceptarVisible


        'OK_Button.Visible = False

    End Sub

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

End Class
