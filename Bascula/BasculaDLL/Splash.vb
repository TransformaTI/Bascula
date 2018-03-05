Public Class frmSplash
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        lblModulo.Text = Application.ProductName
        Me.Text = Application.ProductName
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
    Friend WithEvents lblVersion As System.Windows.Forms.Label
    Friend WithEvents tmrEfect As System.Windows.Forms.Timer
    Friend WithEvents lblModulo As System.Windows.Forms.Label
    Friend WithEvents lblEmpresa As System.Windows.Forms.Label
    Friend WithEvents lblSistema As System.Windows.Forms.Label
    Friend WithEvents picLogo As System.Windows.Forms.PictureBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmSplash))
        Me.picLogo = New System.Windows.Forms.PictureBox()
        Me.lblModulo = New System.Windows.Forms.Label()
        Me.lblEmpresa = New System.Windows.Forms.Label()
        Me.lblSistema = New System.Windows.Forms.Label()
        Me.lblVersion = New System.Windows.Forms.Label()
        Me.tmrEfect = New System.Windows.Forms.Timer(Me.components)
        Me.SuspendLayout()
        '
        'picLogo
        '
        Me.picLogo.Image = CType(resources.GetObject("picLogo.Image"), System.Drawing.Bitmap)
        Me.picLogo.Location = New System.Drawing.Point(3, 6)
        Me.picLogo.Name = "picLogo"
        Me.picLogo.Size = New System.Drawing.Size(386, 146)
        Me.picLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picLogo.TabIndex = 0
        Me.picLogo.TabStop = False
        '
        'lblModulo
        '
        Me.lblModulo.AutoSize = True
        Me.lblModulo.Font = New System.Drawing.Font("Arial Black", 33.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblModulo.Location = New System.Drawing.Point(10, 155)
        Me.lblModulo.Name = "lblModulo"
        Me.lblModulo.Size = New System.Drawing.Size(0, 64)
        Me.lblModulo.TabIndex = 1
        Me.lblModulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblEmpresa
        '
        Me.lblEmpresa.AutoSize = True
        Me.lblEmpresa.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEmpresa.Location = New System.Drawing.Point(10, 219)
        Me.lblEmpresa.Name = "lblEmpresa"
        Me.lblEmpresa.Size = New System.Drawing.Size(181, 16)
        Me.lblEmpresa.TabIndex = 3
        Me.lblEmpresa.Text = "Sistema de Gas Metropolitano"
        '
        'lblSistema
        '
        Me.lblSistema.AutoSize = True
        Me.lblSistema.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSistema.Location = New System.Drawing.Point(10, 235)
        Me.lblSistema.Name = "lblSistema"
        Me.lblSistema.Size = New System.Drawing.Size(83, 20)
        Me.lblSistema.TabIndex = 4
        Me.lblSistema.Text = "SIGAMET"
        '
        'lblVersion
        '
        Me.lblVersion.AutoSize = True
        Me.lblVersion.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblVersion.Location = New System.Drawing.Point(10, 259)
        Me.lblVersion.Name = "lblVersion"
        Me.lblVersion.Size = New System.Drawing.Size(136, 20)
        Me.lblVersion.TabIndex = 5
        Me.lblVersion.Text = "Version: 1.0.0.0"
        '
        'tmrEfect
        '
        Me.tmrEfect.Interval = 80
        '
        'frmSplash
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 14)
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(400, 296)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblVersion, Me.lblSistema, Me.lblEmpresa, Me.lblModulo, Me.picLogo})
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmSplash"
        Me.Opacity = 0
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.TopMost = True
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub splash_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        lblModulo.Text = Application.ProductName
        lblVersion.Text = "Versión: " & Application.ProductVersion
        Me.Show()
        Application.DoEvents()
        tmrEfect.Enabled = True
    End Sub

    Private Sub tmrEfect_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrEfect.Tick
        Static Hidding As Boolean
        If Hidding Then
            Me.Opacity -= 0.1
            If Me.Opacity = 0 Then
                Me.Close()
                Me.Dispose()
            End If
        Else
            Me.Opacity += 0.1
            If Me.Opacity = 1 Then
                Hidding = True
                System.Threading.Thread.Sleep(500)
            End If
        End If
        Application.DoEvents()
    End Sub
End Class
