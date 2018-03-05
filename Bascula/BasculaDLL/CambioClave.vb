Public Class frmCambioClave
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New(ByVal Usuario As String)
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        Me.Usuario = Usuario
        txtUsuario.Text = Usuario
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
    Friend WithEvents grpDatos As System.Windows.Forms.GroupBox
    Friend WithEvents lblUsuario As System.Windows.Forms.Label
    Friend WithEvents lblClave As System.Windows.Forms.Label
    Friend WithEvents lblConfirmarClave As System.Windows.Forms.Label
    Friend WithEvents txtConfirmarClave As System.Windows.Forms.TextBox
    Friend WithEvents txtClave As System.Windows.Forms.TextBox
    Friend WithEvents txtUsuario As System.Windows.Forms.TextBox
    Friend WithEvents btnAceptar As System.Windows.Forms.Button
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmCambioClave))
        Me.grpDatos = New System.Windows.Forms.GroupBox()
        Me.txtUsuario = New System.Windows.Forms.TextBox()
        Me.txtClave = New System.Windows.Forms.TextBox()
        Me.txtConfirmarClave = New System.Windows.Forms.TextBox()
        Me.lblConfirmarClave = New System.Windows.Forms.Label()
        Me.lblClave = New System.Windows.Forms.Label()
        Me.lblUsuario = New System.Windows.Forms.Label()
        Me.btnAceptar = New System.Windows.Forms.Button()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.grpDatos.SuspendLayout()
        Me.SuspendLayout()
        '
        'grpDatos
        '
        Me.grpDatos.Controls.AddRange(New System.Windows.Forms.Control() {Me.txtUsuario, Me.txtClave, Me.txtConfirmarClave, Me.lblConfirmarClave, Me.lblClave, Me.lblUsuario})
        Me.grpDatos.Dock = System.Windows.Forms.DockStyle.Top
        Me.grpDatos.Location = New System.Drawing.Point(5, 5)
        Me.grpDatos.Name = "grpDatos"
        Me.grpDatos.Size = New System.Drawing.Size(282, 131)
        Me.grpDatos.TabIndex = 0
        Me.grpDatos.TabStop = False
        Me.grpDatos.Text = "Datos del cambio"
        '
        'txtUsuario
        '
        Me.txtUsuario.BackColor = System.Drawing.Color.Gainsboro
        Me.txtUsuario.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtUsuario.Location = New System.Drawing.Point(120, 29)
        Me.txtUsuario.MaxLength = 15
        Me.txtUsuario.Name = "txtUsuario"
        Me.txtUsuario.ReadOnly = True
        Me.txtUsuario.Size = New System.Drawing.Size(152, 21)
        Me.txtUsuario.TabIndex = 1
        Me.txtUsuario.TabStop = False
        Me.txtUsuario.Text = ""
        '
        'txtClave
        '
        Me.txtClave.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtClave.Location = New System.Drawing.Point(120, 61)
        Me.txtClave.MaxLength = 15
        Me.txtClave.Name = "txtClave"
        Me.txtClave.PasswordChar = Microsoft.VisualBasic.ChrW(42)
        Me.txtClave.Size = New System.Drawing.Size(152, 21)
        Me.txtClave.TabIndex = 3
        Me.txtClave.Text = ""
        '
        'txtConfirmarClave
        '
        Me.txtConfirmarClave.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtConfirmarClave.Location = New System.Drawing.Point(120, 93)
        Me.txtConfirmarClave.MaxLength = 15
        Me.txtConfirmarClave.Name = "txtConfirmarClave"
        Me.txtConfirmarClave.PasswordChar = Microsoft.VisualBasic.ChrW(42)
        Me.txtConfirmarClave.Size = New System.Drawing.Size(152, 21)
        Me.txtConfirmarClave.TabIndex = 5
        Me.txtConfirmarClave.Text = ""
        '
        'lblConfirmarClave
        '
        Me.lblConfirmarClave.AutoSize = True
        Me.lblConfirmarClave.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblConfirmarClave.Location = New System.Drawing.Point(16, 96)
        Me.lblConfirmarClave.Name = "lblConfirmarClave"
        Me.lblConfirmarClave.Size = New System.Drawing.Size(98, 14)
        Me.lblConfirmarClave.TabIndex = 4
        Me.lblConfirmarClave.Text = "Confirmar c&lave:"
        '
        'lblClave
        '
        Me.lblClave.AutoSize = True
        Me.lblClave.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblClave.Location = New System.Drawing.Point(16, 64)
        Me.lblClave.Name = "lblClave"
        Me.lblClave.Size = New System.Drawing.Size(77, 14)
        Me.lblClave.TabIndex = 2
        Me.lblClave.Text = "&Nueva clave:"
        '
        'lblUsuario
        '
        Me.lblUsuario.AutoSize = True
        Me.lblUsuario.Location = New System.Drawing.Point(16, 32)
        Me.lblUsuario.Name = "lblUsuario"
        Me.lblUsuario.Size = New System.Drawing.Size(46, 14)
        Me.lblUsuario.TabIndex = 0
        Me.lblUsuario.Text = "Usuario:"
        '
        'btnAceptar
        '
        Me.btnAceptar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnAceptar.Image = CType(resources.GetObject("btnAceptar.Image"), System.Drawing.Bitmap)
        Me.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAceptar.Location = New System.Drawing.Point(112, 152)
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
        Me.btnCancelar.Location = New System.Drawing.Point(208, 152)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.TabIndex = 2
        Me.btnCancelar.Text = "&Cancelar"
        Me.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'frmCambioClave
        '
        Me.AcceptButton = Me.btnAceptar
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 14)
        Me.BackColor = System.Drawing.Color.Gainsboro
        Me.CancelButton = Me.btnCancelar
        Me.ClientSize = New System.Drawing.Size(292, 186)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnCancelar, Me.btnAceptar, Me.grpDatos})
        Me.DockPadding.All = 5
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "frmCambioClave"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Cambio de clave"
        Me.grpDatos.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Usuario As String



    
    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        If txtClave.Text.Trim <> String.Empty AndAlso txtClave.Text = txtConfirmarClave.Text Then
            Dim cmdBascula As New SqlCommand("spSEGCambioContraseñaUsuario", Globales.GetInstance.cnSigamet)
            cmdBascula.CommandType = CommandType.StoredProcedure
            cmdBascula.Parameters.Add("@Usuario", SqlDbType.Char).Value = Me.Usuario
            cmdBascula.Parameters.Add("@Clave", SqlDbType.Char).Value = txtClave.Text.Trim.ToUpper
            Try
                Globales.GetInstance.AbreConexion()
                cmdBascula.ExecuteNonQuery()
                Me.DialogResult = DialogResult.OK
                Me.Close()
            Catch ex As Exception
                Globales.GetInstance.ExMessage(ex)
            Finally
                Globales.GetInstance.CierraConexion()
            End Try
        Else
            Globales.GetInstance.ErrMessage("La clave y su confirmación deben ser iguales.")
            txtConfirmarClave.Focus()
            txtConfirmarClave.SelectAll()
        End If

    End Sub
End Class
