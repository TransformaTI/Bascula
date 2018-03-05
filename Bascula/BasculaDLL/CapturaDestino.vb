Public Class frmCapturaDestino
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    Public Sub New(ByVal IDDestino As Integer, ByVal Destino As String)
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        Me.Text = "Modificación de destino"
        _IDDestino = IDDestino
        txtDestino.Text = Destino
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
    Friend WithEvents lblDestino As System.Windows.Forms.Label
    Friend WithEvents txtDestino As System.Windows.Forms.TextBox
    Friend WithEvents btnAceptar As System.Windows.Forms.Button
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmCapturaDestino))
        Me.rgrpDatos = New Bascula.RoundedGroupBox()
        Me.txtDestino = New System.Windows.Forms.TextBox()
        Me.lblDestino = New System.Windows.Forms.Label()
        Me.btnAceptar = New System.Windows.Forms.Button()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.rgrpDatos.SuspendLayout()
        Me.SuspendLayout()
        '
        'rgrpDatos
        '
        Me.rgrpDatos.BorderColor = System.Drawing.Color.DarkBlue
        Me.rgrpDatos.Controls.AddRange(New System.Windows.Forms.Control() {Me.txtDestino, Me.lblDestino})
        Me.rgrpDatos.Dock = System.Windows.Forms.DockStyle.Top
        Me.rgrpDatos.FlatStyle = Bascula.RoundedGroupBox.Style.Pipe
        Me.rgrpDatos.Location = New System.Drawing.Point(3, 0)
        Me.rgrpDatos.Name = "rgrpDatos"
        Me.rgrpDatos.Size = New System.Drawing.Size(324, 64)
        Me.rgrpDatos.TabIndex = 0
        Me.rgrpDatos.TabStop = False
        Me.rgrpDatos.Text = "Datos del destino"
        Me.rgrpDatos.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left
        '
        'txtDestino
        '
        Me.txtDestino.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtDestino.Location = New System.Drawing.Point(66, 29)
        Me.txtDestino.MaxLength = 50
        Me.txtDestino.Name = "txtDestino"
        Me.txtDestino.Size = New System.Drawing.Size(238, 21)
        Me.txtDestino.TabIndex = 1
        Me.txtDestino.Text = ""
        '
        'lblDestino
        '
        Me.lblDestino.AutoSize = True
        Me.lblDestino.Location = New System.Drawing.Point(16, 32)
        Me.lblDestino.Name = "lblDestino"
        Me.lblDestino.Size = New System.Drawing.Size(46, 14)
        Me.lblDestino.TabIndex = 0
        Me.lblDestino.Text = "&Destino:"
        '
        'btnAceptar
        '
        Me.btnAceptar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnAceptar.Image = CType(resources.GetObject("btnAceptar.Image"), System.Drawing.Bitmap)
        Me.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAceptar.Location = New System.Drawing.Point(62, 71)
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
        Me.btnCancelar.Location = New System.Drawing.Point(193, 71)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.TabIndex = 2
        Me.btnCancelar.Text = "&Cancelar"
        Me.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'frmCapturaDestino
        '
        Me.AcceptButton = Me.btnAceptar
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 14)
        Me.BackColor = System.Drawing.Color.Gainsboro
        Me.CancelButton = Me.btnCancelar
        Me.ClientSize = New System.Drawing.Size(330, 106)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnAceptar, Me.rgrpDatos, Me.btnCancelar})
        Me.DockPadding.Left = 3
        Me.DockPadding.Right = 3
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "frmCapturaDestino"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Nuevo destino"
        Me.rgrpDatos.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Variables globales"
    Private _IDDestino As Integer
#End Region
#Region "Propiedades"
    ReadOnly Property Destino() As String
        Get
            Return _IDDestino.ToString
        End Get
    End Property
#End Region
#Region "Manejo de datos"
    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        If Not txtDestino.Text.Trim = "" Then
            Dim cmdBascula As New SqlCommand("spBASDestinoTransporte", Globales.GetInstance.cnSigamet)
            cmdBascula.CommandType = CommandType.StoredProcedure
            cmdBascula.Parameters.Add("@Destino", SqlDbType.Int).Value = _IDDestino
            cmdBascula.Parameters.Add("@Descripcion", SqlDbType.VarChar).Value = txtDestino.Text.Trim
            cmdBascula.Parameters.Add("@NuevoDestino", SqlDbType.Int).Direction = ParameterDirection.Output
            Try
                Globales.GetInstance.AbreConexion()
                cmdBascula.ExecuteNonQuery()
                _IDDestino = CInt(cmdBascula.Parameters("@NuevoDestino").Value)
                Me.DialogResult = DialogResult.OK
                Me.Close()
            Catch ex As Exception
                Globales.GetInstance.ExMessage(ex)
            Finally
                Globales.GetInstance.CierraConexion()
            End Try
        Else
            Globales.GetInstance.ErrMessage("No ha escrito el nombre del destino.")
            txtDestino.Focus()
        End If
    End Sub
#End Region
#Region "Manejo de cajas de texto"
    Private Sub txtDestino_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtDestino.Enter
        txtDestino.BackColor = Color.LemonChiffon
    End Sub
    Private Sub txtDestino_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtDestino.Leave
        txtDestino.BackColor = Color.White
    End Sub
#End Region
End Class
