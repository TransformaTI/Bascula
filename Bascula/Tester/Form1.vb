Public Class Form1
    Inherits System.Windows.Forms.Form

    'Public cnSigamet As New SqlClient.SqlConnection(SigaMetClasses.LeeInfoConexion(True))

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
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents SqlConnection1 As System.Data.SqlClient.SqlConnection
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents Button5 As System.Windows.Forms.Button
    Friend WithEvents Button6 As System.Windows.Forms.Button
    Friend WithEvents Button7 As System.Windows.Forms.Button
    Friend WithEvents Button8 As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.SqlConnection1 = New System.Data.SqlClient.SqlConnection()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.Button6 = New System.Windows.Forms.Button()
        Me.Button7 = New System.Windows.Forms.Button()
        Me.Button8 = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(15, 7)
        Me.Button1.Name = "Button1"
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "Bascula"
        '
        'SqlConnection1
        '
        Me.SqlConnection1.ConnectionString = "data source=Report-ERP;initial catalog=SigametReportesHidro;password=michoacan;pe" & _
        "rsist security info=False;user id=jebana"
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(15, 39)
        Me.Button2.Name = "Button2"
        Me.Button2.TabIndex = 1
        Me.Button2.Text = "Parametros"
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(15, 71)
        Me.Button3.Name = "Button3"
        Me.Button3.TabIndex = 2
        Me.Button3.Text = "Ciclos Aut."
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(15, 103)
        Me.Button4.Name = "Button4"
        Me.Button4.TabIndex = 3
        Me.Button4.Text = "Modif. Ciclo"
        '
        'Button5
        '
        Me.Button5.Location = New System.Drawing.Point(15, 135)
        Me.Button5.Name = "Button5"
        Me.Button5.TabIndex = 4
        Me.Button5.Text = "Fact. Dens."
        '
        'Button6
        '
        Me.Button6.Location = New System.Drawing.Point(15, 167)
        Me.Button6.Name = "Button6"
        Me.Button6.TabIndex = 5
        Me.Button6.Text = "Destinos"
        '
        'Button7
        '
        Me.Button7.Location = New System.Drawing.Point(15, 199)
        Me.Button7.Name = "Button7"
        Me.Button7.TabIndex = 6
        Me.Button7.Text = "Transport."
        '
        'Button8
        '
        Me.Button8.Location = New System.Drawing.Point(24, 240)
        Me.Button8.Name = "Button8"
        Me.Button8.TabIndex = 7
        Me.Button8.Text = "Button8"
        '
        'Form1
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(115, 286)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.Button8, Me.Button7, Me.Button6, Me.Button5, Me.Button4, Me.Button3, Me.Button2, Me.Button1})
        Me.Name = "Form1"
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        'Dim oSeguridad As New SigaMetClasses.Seguridad(5, SqlConnection1.ConnectionString, "jebana", "michoacan")
        ''SigaMetClasses.DataLayer.Instancia.InicializaConexion(SqlConnection1)
        SigaMetClasses.DataLayer.InicializaConexion(SqlConnection1)

        Bascula.Globales.GetInstance.ConfiguraModulo(SqlConnection1, "jebana", "michoacan", 3, 4)

        Dim a As New Bascula.frmAutotanques()
        a.Show()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim a As New Bascula.frmParametros()
        a.Show()
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Dim a As New Bascula.frmCiclosAutomaticos()
        a.Show()
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Dim a As New Bascula.frmModificacionCiclos()
        a.Show()
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        Dim a As New Bascula.frmHistoricoFactoresDensidad()
        a.Show()
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        Dim a As New Bascula.frmDestinos()
        a.Show()
    End Sub

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        Dim a As New Bascula.frmTransportadoras()
        a.Show()
        'Dim a As Boolean
        'Dim b As Boolean
        'Dim result As Boolean

        'a = False
        'b = True

        'If (a) And (b) Then
        '    MessageBox.Show("verdadero")

        'Else
        '    MessageBox.Show("falso")
        'End If
    End Sub



    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click

        Dim ci As New Bascula.ControlInventarios(0.51, 0.54)

        Dim masas(2) As Double
        masas(0) = 1
        masas(1) = 1
        masas(2) = 1

        Dim volumenes(2) As Double
        volumenes(0) = 1
        volumenes(1) = 1
        volumenes(2) = 2

        Dim resultado As Double
        Dim capacidadATT As Decimal = 12280
        Dim calibracionPeso As Decimal = 95
        Dim ventaTotalizador As Decimal = 833894.0
        Dim porcentajeSalida As Decimal = 86.0
        Dim porcentajeLlegada As Decimal = 66.0
        Dim kilosSalida As Integer = 13210
        Dim kilosLlegada As Integer = 11860
        Dim factorDensidad As Decimal = ci.FactorDeDensidad(masas, volumenes)
        Dim tolerancia As Integer = 3
        Dim calibracionVolumen As Decimal = 95
        Dim porcentajeNominalInv As Integer = 95
        Dim umbralRelleno As Integer = 10
        Dim porcentajeVendido As Decimal = ci.PorcentajeVendido(porcentajeSalida, porcentajeLlegada)


        'dudas de donde se obtienen los valores
        Dim litrosfaltantesDeGas As Decimal = ci.FaltantesPorPeso(capacidadATT, calibracionPeso, ventaTotalizador, porcentajeSalida, porcentajeLlegada, kilosSalida, kilosLlegada, factorDensidad, tolerancia)
        Dim lirosComerciales As Decimal = 7613.6
        Dim litrosRelleno As Decimal = 9
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

        resultado = ci.FactorDeDensidad(masas, volumenes)
        resultado = ci.FaltantesPorPeso(capacidadATT, calibracionPeso, ventaTotalizador, porcentajeSalida, porcentajeLlegada, kilosSalida, kilosLlegada, factorDensidad, tolerancia)
        'resultado = ci.FaltantesPorPorcentaje(capacidadATT, calibracionVolumen, ventaTotalizador, porcentajeSalida, porcentajeLlegada, factorDensidad, tolerancia)
        resultado = ci.LimitePorcentajeNominalInventario(porcentajeNominalInv, umbralRelleno)
        resultado = ci.LitrosRelleno(ventaTotalizador, calibracionVolumen, lirosComerciales, litrosfaltantesDeGas)
        resultado = ci.CalculoPorcentajeNominalInventario(ventaTotalizador, calibracionVolumen, lirosComerciales, litrosfaltantesDeGas, capacidadATT, porcentajeLlegada, porcentajeNominalInv, umbralRelleno)
        resultado = ci.LitrosVendidos(capacidadATT, porcentajeVendido, calibracionVolumen)
        resultado = ci.PorcentajeTeorico(capacidadATT, porcentajeLlegada, litrosRelleno)
        resultado = ci.PorcentajeVendido(porcentajeSalida, porcentajeLlegada)


        'resultado = ci.CalculoPorcentajeNominalInventario(833894.0,95,
        'FaltantesPorPeso()
        MessageBox.Show(resultado.ToString())

    End Sub
End Class
