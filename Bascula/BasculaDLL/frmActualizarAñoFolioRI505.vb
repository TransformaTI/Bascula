Public Class frmActualizarAñoFolioRI505
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
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cmbAño As System.Windows.Forms.ComboBox
    Friend WithEvents txtFolio As System.Windows.Forms.TextBox
    Friend WithEvents btnAceptar As System.Windows.Forms.Button
    Friend WithEvents BtnCancelar As System.Windows.Forms.Button
    Friend WithEvents lblIdServicio As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cmbAño = New System.Windows.Forms.ComboBox()
        Me.txtFolio = New System.Windows.Forms.TextBox()
        Me.btnAceptar = New System.Windows.Forms.Button()
        Me.BtnCancelar = New System.Windows.Forms.Button()
        Me.lblIdServicio = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(24, 40)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(48, 23)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Año:"
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(24, 80)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(48, 23)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Folio:"
        '
        'cmbAño
        '
        Me.cmbAño.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbAño.Location = New System.Drawing.Point(104, 40)
        Me.cmbAño.Name = "cmbAño"
        Me.cmbAño.Size = New System.Drawing.Size(136, 21)
        Me.cmbAño.TabIndex = 2
        '
        'txtFolio
        '
        Me.txtFolio.Location = New System.Drawing.Point(104, 72)
        Me.txtFolio.Name = "txtFolio"
        Me.txtFolio.Size = New System.Drawing.Size(136, 20)
        Me.txtFolio.TabIndex = 3
        Me.txtFolio.Text = ""
        '
        'btnAceptar
        '
        Me.btnAceptar.Location = New System.Drawing.Point(128, 120)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(72, 23)
        Me.btnAceptar.TabIndex = 4
        Me.btnAceptar.Text = "Aceptar"
        '
        'BtnCancelar
        '
        Me.BtnCancelar.Location = New System.Drawing.Point(208, 120)
        Me.BtnCancelar.Name = "BtnCancelar"
        Me.BtnCancelar.Size = New System.Drawing.Size(64, 23)
        Me.BtnCancelar.TabIndex = 5
        Me.BtnCancelar.Text = "Cancelar"
        '
        'lblIdServicio
        '
        Me.lblIdServicio.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblIdServicio.Location = New System.Drawing.Point(106, 8)
        Me.lblIdServicio.Name = "lblIdServicio"
        Me.lblIdServicio.Size = New System.Drawing.Size(134, 23)
        Me.lblIdServicio.TabIndex = 6
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(24, 8)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(64, 16)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "Id Servico:"
        '
        'frmActualizarAñoFolioRI505
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(280, 158)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.Label4, Me.lblIdServicio, Me.BtnCancelar, Me.btnAceptar, Me.txtFolio, Me.cmbAño, Me.Label2, Me.Label1})
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(288, 192)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(288, 192)
        Me.Name = "frmActualizarAñoFolioRI505"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Actualizar Año y Folio"
        Me.ResumeLayout(False)

    End Sub

#End Region

    Public anio As Integer
    Public folio As Integer
    Public LtsTotMenosCalibAtt As Double
 
    Dim objeto As RI505Servicio
    Dim att As Integer

    Friend Sub LoadOrders(ByVal idServicio As String, ByVal autotanque As Integer)
        Me.lblIdServicio.Text = idServicio
        att = autotanque
    End Sub

    Private Sub frmActualizarAñoFolioRI505_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.cmbAño.Items.Add(DateTime.Now.Year - 1)
        Me.cmbAño.Items.Add(DateTime.Now.Year)
        Me.cmbAño.SelectedIndex = 1
        Me.txtFolio.Focus()
        AddHandler Me.txtFolio.KeyPress, AddressOf keypressed
    End Sub

    Sub keypressed(ByVal o As [Object], ByVal e As KeyPressEventArgs)
        ''If Not (e.KeyChar.IsDigit(e.KeyChar) OrElse e.KeyChar.IsControl(e.KeyChar) OrElse Asc(e.KeyChar) = 8) Then
        If Not (Char.IsDigit(e.KeyChar) OrElse Char.IsControl(e.KeyChar) OrElse Asc(e.KeyChar) = 8) Then
            e.Handled = True
        Else
            e.Handled = False
        End If
        If e.KeyChar = Chr(13) Then
            btnAceptar_Click(Nothing, Nothing)
        End If
    End Sub

    Public Class RI505Servicio
        Private _añoAtt As Integer
        Private _folio As Integer
        Private _autotanque As Integer
        Private _litrosLiquidados As Decimal
        Private _eficicencia As Integer
        Private _importeEficicencia As Double
        Private _calibracionPorcentaje As Decimal

        Public Property CalibracionPorcentaje() As Decimal
            Get
                Return _calibracionPorcentaje
            End Get
            Set(ByVal Value As Decimal)
                _calibracionPorcentaje = Value
            End Set
        End Property

        Public Property ImporteEficicencia() As Double
            Get
                Return _importeEficicencia
            End Get
            Set(ByVal Value As Double)
                _importeEficicencia = Value
            End Set
        End Property

        Public Property Eficicencia() As Integer
            Get
                Return _eficicencia
            End Get
            Set(ByVal Value As Integer)
                _eficicencia = Value
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

        Public Property LitrosLiquidados() As Decimal
            Get
                Return _litrosLiquidados
            End Get
            Set(ByVal Value As Decimal)
                _litrosLiquidados = Value
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

    End Class

    Private Function VerificarDatos(ByVal folio As Integer, ByVal año As Integer) As String
        Dim resultado As String = "Vacio"
        Dim cmdBuscar As New SqlCommand("spBASSGCVerificarDatos", Globales.GetInstance.cnSigamet)
        Dim reader As SqlDataReader
        cmdBuscar.CommandType = CommandType.StoredProcedure
        cmdBuscar.Parameters.Add("@Folio", SqlDbType.Int).Value = folio
        cmdBuscar.Parameters.Add("@Anio", SqlDbType.Int).Value = año
        Try
            Globales.GetInstance.AbreConexion()
            reader = cmdBuscar.ExecuteReader
            If reader.Read Then
                objeto = New RI505Servicio()
                objeto.Autotanque = CInt(reader("Autotanque"))
                objeto.AñoAtt = CInt(reader("AñoAtt"))
                objeto.CalibracionPorcentaje = CType(reader("CalibracionPorcentaje"), Decimal)
                objeto.Folio = CInt(reader("Folio"))
                If reader.IsDBNull(4) Then
                    objeto.Eficicencia = 0
                Else
                    objeto.Eficicencia = CInt(reader("Eficiencia"))
                End If
                If reader.IsDBNull(5) Then
                    objeto.ImporteEficicencia = 0
                Else
                    objeto.ImporteEficicencia = CType(reader("ImporteEficiencia"), Double)
                End If
                objeto.LitrosLiquidados = CType(reader("LitrosLiquidados"), Decimal)
                If objeto.Autotanque = att Then
                    resultado = "Verdadero"
                Else
                    resultado = "Falso"
                End If
                reader.Close()
            End If

        Catch ex As Exception
            Globales.GetInstance.ExMessage(ex)
        Finally
            Globales.GetInstance.CierraConexion()
        End Try
        Return resultado
    End Function

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        Me.Cursor = Cursors.WaitCursor
        Dim resultado As String = VerificarDatos(CInt(Me.txtFolio.Text), CInt(CType(Me.cmbAño.SelectedItem, String)))
        If Me.txtFolio.Text.Length > 6 Then
            MsgBox("El número del folio no debe ser mayor a 6 digitos.", MsgBoxStyle.Exclamation, "Mensaje del sistema")
            Me.txtFolio.Focus()
        Else
            If resultado = "Verdadero" Then
                anio = CInt(Me.cmbAño.Text)
                folio = CInt(Me.txtFolio.Text)
                LtsTotMenosCalibAtt = (objeto.LitrosLiquidados * (objeto.CalibracionPorcentaje / 100))
                Me.DialogResult = DialogResult.Yes
                Me.Close()
            End If
            If (resultado = "Falso") Then
                If MsgBox("El auntotanque del folio venta NO coincide con el autotanque del llenado en masico." + Chr(13) + "¿Aún asi desea vincular el registro?.", MsgBoxStyle.YesNo, "Mensaje del sistema") = MsgBoxResult.Yes Then
                    anio = CInt(Me.cmbAño.Text)
                    folio = CInt(Me.txtFolio.Text)
                    LtsTotMenosCalibAtt = (objeto.LitrosLiquidados * (objeto.CalibracionPorcentaje / 100))
                    Me.DialogResult = DialogResult.Yes
                    Me.Close()
                End If
            End If
            If (resultado = "Vacio") Then
                MsgBox("Verifique los datos capturados ya que no existe el folio indicado.", MsgBoxStyle.Information, "Mensaje del sistema")
            End If
        End If
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub BtnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancelar.Click
        Me.DialogResult = DialogResult.No
        Me.Close()
    End Sub
End Class
