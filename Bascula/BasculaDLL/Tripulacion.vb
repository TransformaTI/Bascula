Public Class Tripulacion
    Inherits System.Windows.Forms.UserControl

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call        
    End Sub

    'UserControl overrides dispose to clean up the component list.
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
    Friend WithEvents pnlSeparador As System.Windows.Forms.Panel
    Friend WithEvents pnlOperador As System.Windows.Forms.Panel
    Friend WithEvents picOperador As System.Windows.Forms.PictureBox
    Friend WithEvents pnlAyudante As System.Windows.Forms.Panel
    Friend WithEvents picAyudante As System.Windows.Forms.PictureBox
    Friend WithEvents lblOperador As System.Windows.Forms.Label
    Friend WithEvents lblAyudante As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.pnlSeparador = New System.Windows.Forms.Panel()
        Me.pnlOperador = New System.Windows.Forms.Panel()
        Me.picOperador = New System.Windows.Forms.PictureBox()
        Me.pnlAyudante = New System.Windows.Forms.Panel()
        Me.picAyudante = New System.Windows.Forms.PictureBox()
        Me.lblOperador = New System.Windows.Forms.Label()
        Me.lblAyudante = New System.Windows.Forms.Label()
        Me.pnlOperador.SuspendLayout()
        Me.pnlAyudante.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnlSeparador
        '
        Me.pnlSeparador.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlSeparador.Location = New System.Drawing.Point(336, 0)
        Me.pnlSeparador.Name = "pnlSeparador"
        Me.pnlSeparador.Size = New System.Drawing.Size(24, 328)
        Me.pnlSeparador.TabIndex = 1
        '
        'pnlOperador
        '
        Me.pnlOperador.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblOperador, Me.picOperador})
        Me.pnlOperador.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlOperador.Name = "pnlOperador"
        Me.pnlOperador.Size = New System.Drawing.Size(336, 328)
        Me.pnlOperador.TabIndex = 4
        '
        'picOperador
        '
        Me.picOperador.Dock = System.Windows.Forms.DockStyle.Fill
        Me.picOperador.Name = "picOperador"
        Me.picOperador.Size = New System.Drawing.Size(336, 328)
        Me.picOperador.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.picOperador.TabIndex = 1
        Me.picOperador.TabStop = False
        '
        'pnlAyudante
        '
        Me.pnlAyudante.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblAyudante, Me.picAyudante})
        Me.pnlAyudante.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlAyudante.Location = New System.Drawing.Point(360, 0)
        Me.pnlAyudante.Name = "pnlAyudante"
        Me.pnlAyudante.Size = New System.Drawing.Size(344, 328)
        Me.pnlAyudante.TabIndex = 5
        '
        'picAyudante
        '
        Me.picAyudante.Dock = System.Windows.Forms.DockStyle.Fill
        Me.picAyudante.Name = "picAyudante"
        Me.picAyudante.Size = New System.Drawing.Size(344, 328)
        Me.picAyudante.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.picAyudante.TabIndex = 4
        Me.picAyudante.TabStop = False
        '
        'lblOperador
        '
        Me.lblOperador.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.lblOperador.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblOperador.Location = New System.Drawing.Point(0, 296)
        Me.lblOperador.Name = "lblOperador"
        Me.lblOperador.Size = New System.Drawing.Size(336, 32)
        Me.lblOperador.TabIndex = 2
        Me.lblOperador.Text = "Operador"
        Me.lblOperador.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblAyudante
        '
        Me.lblAyudante.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.lblAyudante.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAyudante.Location = New System.Drawing.Point(0, 296)
        Me.lblAyudante.Name = "lblAyudante"
        Me.lblAyudante.Size = New System.Drawing.Size(344, 32)
        Me.lblAyudante.TabIndex = 5
        Me.lblAyudante.Text = "Ayudante"
        Me.lblAyudante.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Tripulacion
        '
        Me.BackColor = System.Drawing.Color.Gainsboro
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.pnlAyudante, Me.pnlSeparador, Me.pnlOperador})
        Me.Name = "Tripulacion"
        Me.Size = New System.Drawing.Size(704, 328)
        Me.pnlOperador.ResumeLayout(False)
        Me.pnlAyudante.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region


    Private WithEvents _Operador As Empleado
    Private WithEvents _Ayudante As Empleado

    Private cn As SqlConnection

    Private Sub Tripulacion_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Resize
        pnlOperador.Width = CInt((Me.Width - pnlSeparador.Width) / 2)
    End Sub

    Private Sub LimpaFoto()
        picOperador.Image = Nothing
        picAyudante.Image = Nothing
    End Sub

    Private Sub AcomodaFotos(ByVal sender As Object, ByVal e As System.EventArgs) Handles _Operador.DataChanged, _Ayudante.DataChanged
        If Not _Operador Is Nothing Then
            If Not _Operador.Foto Is Nothing AndAlso _Operador.Foto.Width > picOperador.Width Then
                Dim rto As Double = picOperador.Width / _Operador.Foto.Width
                Dim nf As New Bitmap(_Operador.Foto, picOperador.Width, CInt(rto * _Operador.Foto.Height))
                _Operador.Foto = nf
            End If
            If Not _Operador.Foto Is Nothing AndAlso _Operador.Foto.Height > picOperador.Height Then
                Dim rto As Double = picOperador.Height / _Operador.Foto.Height
                Dim nf As New Bitmap(_Operador.Foto, CInt(rto * _Operador.Foto.Width), picOperador.Height)
                _Operador.Foto = nf
            End If
            picOperador.Image = _Operador.Foto
        End If
        If Not _Ayudante Is Nothing Then
            If Not _Ayudante.Foto Is Nothing AndAlso _Ayudante.Foto.Width > picAyudante.Width Then
                Dim rto As Double = picAyudante.Width / _Ayudante.Foto.Width
                Dim nf As New Bitmap(_Ayudante.Foto, picAyudante.Width, CInt(rto * _Ayudante.Foto.Height))
                _Ayudante.Foto = nf
            End If
            If Not _Ayudante.Foto Is Nothing AndAlso _Ayudante.Foto.Height > picAyudante.Height Then
                Dim rto As Double = picAyudante.Height / _Ayudante.Foto.Height
                Dim nf As New Bitmap(_Ayudante.Foto, CInt(rto * _Ayudante.Foto.Width), picAyudante.Height)
                _Ayudante.Foto = nf
            End If
            picAyudante.Image = _Ayudante.Foto
        End If
    End Sub

    WriteOnly Property ConexionSQL() As SqlConnection
        Set(ByVal Value As SqlConnection)
            cn = Value
        End Set
    End Property

    Property Operador() As Integer
        Get
            Return _Operador.Empleado
        End Get
        Set(ByVal Value As Integer)
            If Value > 0 Then
                _Operador = New Empleado(Value, cn)
                AcomodaFotos(Me, Nothing)
            End If
            If Value = 0 Then
                LimpaFoto()
            End If
        End Set
    End Property

    Property Ayudante() As Integer
        Get
            Return _Ayudante.Empleado
        End Get
        Set(ByVal Value As Integer)
            If Value > 0 Then
                _Ayudante = New Empleado(Value, cn)
                AcomodaFotos(Me, Nothing)
            End If
            If Value = 0 Then
                LimpaFoto()
            End If
        End Set
    End Property
End Class
