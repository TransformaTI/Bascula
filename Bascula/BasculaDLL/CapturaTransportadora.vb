Public Class frmCapturaTransportadora
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    Public Sub New(ByVal IDTransportadora As Integer, ByVal Transportadora As String)
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        Me.Text = "Modificación de transportadora"
        _IDTransportadora = IDTransportadora
        txtTransportadora.Text = Transportadora
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
    Friend WithEvents rgrpDatos As Bascula.RoundedGroupBox
    Friend WithEvents btnAceptar As System.Windows.Forms.Button
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents lblTransportadora As System.Windows.Forms.Label
    Friend WithEvents txtTransportadora As System.Windows.Forms.TextBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmCapturaTransportadora))
        Me.rgrpDatos = New Bascula.RoundedGroupBox()
        Me.btnAceptar = New System.Windows.Forms.Button()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.lblTransportadora = New System.Windows.Forms.Label()
        Me.txtTransportadora = New System.Windows.Forms.TextBox()
        Me.rgrpDatos.SuspendLayout()
        Me.SuspendLayout()
        '
        'rgrpDatos
        '
        Me.rgrpDatos.BorderColor = System.Drawing.Color.DarkBlue
        Me.rgrpDatos.Controls.AddRange(New System.Windows.Forms.Control() {Me.txtTransportadora, Me.lblTransportadora})
        Me.rgrpDatos.Dock = System.Windows.Forms.DockStyle.Top
        Me.rgrpDatos.FlatStyle = Bascula.RoundedGroupBox.Style.Pipe
        Me.rgrpDatos.Location = New System.Drawing.Point(3, 0)
        Me.rgrpDatos.Name = "rgrpDatos"
        Me.rgrpDatos.Size = New System.Drawing.Size(388, 64)
        Me.rgrpDatos.TabIndex = 0
        Me.rgrpDatos.TabStop = False
        Me.rgrpDatos.Text = "Datos de la transportadora"
        Me.rgrpDatos.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left
        '
        'btnAceptar
        '
        Me.btnAceptar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnAceptar.Image = CType(resources.GetObject("btnAceptar.Image"), System.Drawing.Bitmap)
        Me.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAceptar.Location = New System.Drawing.Point(96, 71)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.TabIndex = 1
        Me.btnAceptar.Text = "&Aceptar"
        Me.btnAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnCancelar
        '
        Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnCancelar.Image = CType(resources.GetObject("btnCancelar.Image"), System.Drawing.Bitmap)
        Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancelar.Location = New System.Drawing.Point(224, 71)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.TabIndex = 2
        Me.btnCancelar.Text = "&Cancelar"
        Me.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblTransportadora
        '
        Me.lblTransportadora.AutoSize = True
        Me.lblTransportadora.Location = New System.Drawing.Point(15, 32)
        Me.lblTransportadora.Name = "lblTransportadora"
        Me.lblTransportadora.Size = New System.Drawing.Size(85, 14)
        Me.lblTransportadora.TabIndex = 0
        Me.lblTransportadora.Text = "&Transportadora:"
        '
        'txtTransportadora
        '
        Me.txtTransportadora.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTransportadora.Location = New System.Drawing.Point(111, 29)
        Me.txtTransportadora.MaxLength = 60
        Me.txtTransportadora.Name = "txtTransportadora"
        Me.txtTransportadora.Size = New System.Drawing.Size(264, 21)
        Me.txtTransportadora.TabIndex = 1
        Me.txtTransportadora.Text = ""
        '
        'frmCapturaTransportadora
        '
        Me.AcceptButton = Me.btnAceptar
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 14)
        Me.BackColor = System.Drawing.Color.Gainsboro
        Me.CancelButton = Me.btnCancelar
        Me.ClientSize = New System.Drawing.Size(394, 105)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnAceptar, Me.btnCancelar, Me.rgrpDatos})
        Me.DockPadding.Left = 3
        Me.DockPadding.Right = 3
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "frmCapturaTransportadora"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Nueva transportadora"
        Me.rgrpDatos.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Variables globales"
    Private _IDTransportadora As Integer
#End Region
#Region "Propiedades"
    ReadOnly Property Transportadora() As String
        Get
            Return _IDTransportadora.ToString
        End Get
    End Property
#End Region
#Region "Manejo de datos"
    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        If Not txtTransportadora.Text.Trim = "" Then
            Dim cmdBascula As New SqlCommand("spBASTransportadora", Globales.GetInstance.cnSigamet)
            cmdBascula.CommandType = CommandType.StoredProcedure
            cmdBascula.Parameters.Add("@Transportadora", SqlDbType.Int).Value = _IDTransportadora
            cmdBascula.Parameters.Add("@Descripcion", SqlDbType.VarChar).Value = txtTransportadora.Text.Trim
            cmdBascula.Parameters.Add("@NuevaTransportadora", SqlDbType.Int).Direction = ParameterDirection.Output
            Try
                Globales.GetInstance.AbreConexion()
                cmdBascula.ExecuteNonQuery()
                _IDTransportadora = CInt(cmdBascula.Parameters("@NuevaTransportadora").Value)
                Me.DialogResult = DialogResult.OK
                Me.Close()
            Catch ex As Exception
                Globales.GetInstance.ExMessage(ex)
            Finally
                Globales.GetInstance.CierraConexion()
            End Try
        Else
            Globales.GetInstance.ErrMessage("No ha escrito el nombre de la transportadora.")
            txtTransportadora.Focus()
        End If
    End Sub
#End Region
#Region "Manejo de cajas de texto"
    Private Sub txtTransportadora_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTransportadora.Enter
        txtTransportadora.BackColor = Color.LemonChiffon
    End Sub
    Private Sub txtTransportadora_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTransportadora.Leave
        txtTransportadora.BackColor = Color.White
    End Sub
#End Region
End Class
