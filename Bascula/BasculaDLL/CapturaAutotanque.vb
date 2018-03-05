Imports System.Data.SqlClient

Public Class frmCapturaAutotanque
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New(ByVal Celula As Integer, ByVal Autotanque As Integer)
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        Dim cmdLogistica As New SqlCommand("Select TipoVehiculo, Descripcion from TipoVehiculo order by Descripcion", Globales.GetInstance.cnSigamet)
        Dim daLogistica As New SqlDataAdapter(cmdLogistica)
        'Tablas para llenado de combos
        Dim dtTipo As New DataTable()
        Dim dtMarca As New DataTable()
        Dim dtProducto As New DataTable()
        Dim dtPropietario As New DataTable()
        Dim dtCelula As New DataTable()
        cmdLogistica.Parameters.Add("@Usuario", SqlDbType.Char).Value = Globales.GetInstance._Usuario
        Try
            daLogistica.Fill(dtTipo)
            cmdLogistica.CommandText = "Select MarcaAutotanque, Descripcion from MarcaAutotanque order by Descripcion"
            daLogistica.Fill(dtMarca)
            cmdLogistica.CommandText = "Select TipoProducto, Descripcion from TipoProducto order by Descripcion"
            daLogistica.Fill(dtProducto)
            cmdLogistica.CommandText = "Select Propietario, Nombre from Propietario order by Nombre"
            daLogistica.Fill(dtPropietario)
            cmdLogistica.CommandText = "Select Celula, Descripcion from Celula where Comercial = 1 and Celula in (Select Celula from UsuarioCelula " _
                                & " where Usuario = @Usuario)"
            daLogistica.Fill(dtCelula)
        Catch ex As Exception
            Globales.GetInstance.ExMessage(ex)
        End Try

        'Llenado de combos
        cboTipo.ValueMember = "TipoVehiculo"
        cboTipo.DisplayMember = "Descripcion"
        cboTipo.DataSource = dtTipo

        cboMarca.ValueMember = "MarcaAutotanque"
        cboMarca.DisplayMember = "Descripcion"
        cboMarca.DataSource = dtMarca

        cboProducto.ValueMember = "TipoProducto"
        cboProducto.DisplayMember = "Descripcion"
        cboProducto.DataSource = dtProducto

        cboPropietario.ValueMember = "Propietario"
        cboPropietario.DisplayMember = "Nombre"
        cboPropietario.DataSource = dtPropietario

        cboCelula.ValueMember = "Celula"
        cboCelula.DisplayMember = "Descripcion"
        cboCelula.DataSource = dtCelula

        'Parametros de default
        Application.DoEvents()
        cboCelula.SelectedValue = Celula

        'Limpiado de memoria
        cmdLogistica.Dispose()
        daLogistica.Dispose()

        'Nuevo/Modificación
        Me.Text = "Modificación de autotanque"
        txtAutotanque.Text = Autotanque.ToString
        CargaDatosAutotanque()

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
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents btnAceptar As System.Windows.Forms.Button
    Friend WithEvents rgrpDatos As Bascula.RoundedGroupBox
    Friend WithEvents lblCelula As System.Windows.Forms.Label
    Friend WithEvents lblAutotanque As System.Windows.Forms.Label
    Friend WithEvents txtAutotanque As System.Windows.Forms.TextBox
    Friend WithEvents lblRuta As System.Windows.Forms.Label
    Friend WithEvents lblCapacidad As System.Windows.Forms.Label
    Friend WithEvents lblPlacas As System.Windows.Forms.Label
    Friend WithEvents lblTipo As System.Windows.Forms.Label
    Friend WithEvents lblMarca As System.Windows.Forms.Label
    Friend WithEvents lblTransponder As System.Windows.Forms.Label
    Friend WithEvents lblGPS As System.Windows.Forms.Label
    Friend WithEvents lblStatus As System.Windows.Forms.Label
    Friend WithEvents cboCelula As System.Windows.Forms.ComboBox
    Friend WithEvents txtCapacidad As System.Windows.Forms.TextBox
    Friend WithEvents txtPlacas As System.Windows.Forms.TextBox
    Friend WithEvents cboTipo As System.Windows.Forms.ComboBox
    Friend WithEvents cboMarca As System.Windows.Forms.ComboBox
    Friend WithEvents cboProducto As System.Windows.Forms.ComboBox
    Friend WithEvents cboPropietario As System.Windows.Forms.ComboBox
    Friend WithEvents txtTransponder As System.Windows.Forms.TextBox
    Friend WithEvents txtGPS As System.Windows.Forms.TextBox
    Friend WithEvents cboStatus As System.Windows.Forms.ComboBox
    Friend WithEvents cboRuta As System.Windows.Forms.ComboBox
    Friend WithEvents lblProducto As System.Windows.Forms.Label
    Friend WithEvents lblPropietario As System.Windows.Forms.Label
    Friend WithEvents lblCalibracion As System.Windows.Forms.Label
    Friend WithEvents txtCalibracion As System.Windows.Forms.TextBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmCapturaAutotanque))
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.btnAceptar = New System.Windows.Forms.Button()
        Me.rgrpDatos = New Bascula.RoundedGroupBox()
        Me.lblCalibracion = New System.Windows.Forms.Label()
        Me.txtCalibracion = New System.Windows.Forms.TextBox()
        Me.cboCelula = New System.Windows.Forms.ComboBox()
        Me.lblCelula = New System.Windows.Forms.Label()
        Me.lblAutotanque = New System.Windows.Forms.Label()
        Me.txtAutotanque = New System.Windows.Forms.TextBox()
        Me.lblRuta = New System.Windows.Forms.Label()
        Me.lblCapacidad = New System.Windows.Forms.Label()
        Me.lblPlacas = New System.Windows.Forms.Label()
        Me.lblTipo = New System.Windows.Forms.Label()
        Me.lblMarca = New System.Windows.Forms.Label()
        Me.lblProducto = New System.Windows.Forms.Label()
        Me.lblPropietario = New System.Windows.Forms.Label()
        Me.lblTransponder = New System.Windows.Forms.Label()
        Me.lblGPS = New System.Windows.Forms.Label()
        Me.lblStatus = New System.Windows.Forms.Label()
        Me.txtCapacidad = New System.Windows.Forms.TextBox()
        Me.txtPlacas = New System.Windows.Forms.TextBox()
        Me.cboTipo = New System.Windows.Forms.ComboBox()
        Me.cboMarca = New System.Windows.Forms.ComboBox()
        Me.cboProducto = New System.Windows.Forms.ComboBox()
        Me.cboPropietario = New System.Windows.Forms.ComboBox()
        Me.txtTransponder = New System.Windows.Forms.TextBox()
        Me.txtGPS = New System.Windows.Forms.TextBox()
        Me.cboStatus = New System.Windows.Forms.ComboBox()
        Me.cboRuta = New System.Windows.Forms.ComboBox()
        Me.rgrpDatos.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnCancelar
        '
        Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnCancelar.Image = CType(resources.GetObject("btnCancelar.Image"), System.Drawing.Bitmap)
        Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancelar.Location = New System.Drawing.Point(268, 49)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(80, 24)
        Me.btnCancelar.TabIndex = 2
        Me.btnCancelar.Text = "&Cancelar"
        Me.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnAceptar
        '
        Me.btnAceptar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnAceptar.Image = CType(resources.GetObject("btnAceptar.Image"), System.Drawing.Bitmap)
        Me.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAceptar.Location = New System.Drawing.Point(268, 13)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(80, 24)
        Me.btnAceptar.TabIndex = 1
        Me.btnAceptar.Text = "&Aceptar"
        Me.btnAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'rgrpDatos
        '
        Me.rgrpDatos.BorderColor = System.Drawing.Color.SteelBlue
        Me.rgrpDatos.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblCalibracion, Me.txtCalibracion, Me.cboCelula, Me.lblCelula, Me.lblAutotanque, Me.txtAutotanque, Me.lblRuta, Me.lblCapacidad, Me.lblPlacas, Me.lblTipo, Me.lblMarca, Me.lblProducto, Me.lblPropietario, Me.lblTransponder, Me.lblGPS, Me.lblStatus, Me.txtCapacidad, Me.txtPlacas, Me.cboTipo, Me.cboMarca, Me.cboProducto, Me.cboPropietario, Me.txtTransponder, Me.txtGPS, Me.cboStatus, Me.cboRuta})
        Me.rgrpDatos.Dock = System.Windows.Forms.DockStyle.Left
        Me.rgrpDatos.FlatStyle = Bascula.RoundedGroupBox.Style.Pipe
        Me.rgrpDatos.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rgrpDatos.ForeColor = System.Drawing.Color.DarkBlue
        Me.rgrpDatos.Location = New System.Drawing.Point(3, 3)
        Me.rgrpDatos.Name = "rgrpDatos"
        Me.rgrpDatos.Size = New System.Drawing.Size(252, 417)
        Me.rgrpDatos.TabIndex = 0
        Me.rgrpDatos.TabStop = False
        Me.rgrpDatos.Text = "Datos del autotanque"
        Me.rgrpDatos.TextAlignment = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lblCalibracion
        '
        Me.lblCalibracion.AutoSize = True
        Me.lblCalibracion.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCalibracion.ForeColor = System.Drawing.Color.Black
        Me.lblCalibracion.Location = New System.Drawing.Point(14, 386)
        Me.lblCalibracion.Name = "lblCalibracion"
        Me.lblCalibracion.Size = New System.Drawing.Size(63, 14)
        Me.lblCalibracion.TabIndex = 13
        Me.lblCalibracion.Text = "Ca&libración:"
        '
        'txtCalibracion
        '
        Me.txtCalibracion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCalibracion.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCalibracion.ForeColor = System.Drawing.Color.Black
        Me.txtCalibracion.Location = New System.Drawing.Point(103, 383)
        Me.txtCalibracion.MaxLength = 20
        Me.txtCalibracion.Name = "txtCalibracion"
        Me.txtCalibracion.Size = New System.Drawing.Size(136, 21)
        Me.txtCalibracion.TabIndex = 14
        Me.txtCalibracion.Text = ""
        '
        'cboCelula
        '
        Me.cboCelula.BackColor = System.Drawing.Color.Gainsboro
        Me.cboCelula.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCelula.Enabled = False
        Me.cboCelula.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboCelula.Location = New System.Drawing.Point(104, 51)
        Me.cboCelula.Name = "cboCelula"
        Me.cboCelula.Size = New System.Drawing.Size(136, 21)
        Me.cboCelula.TabIndex = 2
        '
        'lblCelula
        '
        Me.lblCelula.AutoSize = True
        Me.lblCelula.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCelula.ForeColor = System.Drawing.Color.Black
        Me.lblCelula.Location = New System.Drawing.Point(15, 54)
        Me.lblCelula.Name = "lblCelula"
        Me.lblCelula.Size = New System.Drawing.Size(38, 14)
        Me.lblCelula.TabIndex = 1
        Me.lblCelula.Text = "Cé&lula:"
        '
        'lblAutotanque
        '
        Me.lblAutotanque.AutoSize = True
        Me.lblAutotanque.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAutotanque.ForeColor = System.Drawing.Color.Black
        Me.lblAutotanque.Location = New System.Drawing.Point(15, 24)
        Me.lblAutotanque.Name = "lblAutotanque"
        Me.lblAutotanque.Size = New System.Drawing.Size(75, 14)
        Me.lblAutotanque.TabIndex = 0
        Me.lblAutotanque.Text = "Au&totanque:"
        '
        'txtAutotanque
        '
        Me.txtAutotanque.BackColor = System.Drawing.Color.Gainsboro
        Me.txtAutotanque.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtAutotanque.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAutotanque.ForeColor = System.Drawing.Color.Black
        Me.txtAutotanque.Location = New System.Drawing.Point(104, 21)
        Me.txtAutotanque.MaxLength = 10
        Me.txtAutotanque.Name = "txtAutotanque"
        Me.txtAutotanque.ReadOnly = True
        Me.txtAutotanque.Size = New System.Drawing.Size(136, 21)
        Me.txtAutotanque.TabIndex = 1
        Me.txtAutotanque.Text = ""
        '
        'lblRuta
        '
        Me.lblRuta.AutoSize = True
        Me.lblRuta.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRuta.ForeColor = System.Drawing.Color.Black
        Me.lblRuta.Location = New System.Drawing.Point(15, 84)
        Me.lblRuta.Name = "lblRuta"
        Me.lblRuta.Size = New System.Drawing.Size(31, 14)
        Me.lblRuta.TabIndex = 2
        Me.lblRuta.Text = "&Ruta:"
        '
        'lblCapacidad
        '
        Me.lblCapacidad.AutoSize = True
        Me.lblCapacidad.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCapacidad.ForeColor = System.Drawing.Color.Black
        Me.lblCapacidad.Location = New System.Drawing.Point(15, 114)
        Me.lblCapacidad.Name = "lblCapacidad"
        Me.lblCapacidad.Size = New System.Drawing.Size(59, 14)
        Me.lblCapacidad.TabIndex = 3
        Me.lblCapacidad.Text = "Ca&pacidad:"
        '
        'lblPlacas
        '
        Me.lblPlacas.AutoSize = True
        Me.lblPlacas.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPlacas.ForeColor = System.Drawing.Color.Black
        Me.lblPlacas.Location = New System.Drawing.Point(15, 144)
        Me.lblPlacas.Name = "lblPlacas"
        Me.lblPlacas.Size = New System.Drawing.Size(39, 14)
        Me.lblPlacas.TabIndex = 4
        Me.lblPlacas.Text = "Placa&s:"
        '
        'lblTipo
        '
        Me.lblTipo.AutoSize = True
        Me.lblTipo.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTipo.ForeColor = System.Drawing.Color.Black
        Me.lblTipo.Location = New System.Drawing.Point(15, 174)
        Me.lblTipo.Name = "lblTipo"
        Me.lblTipo.Size = New System.Drawing.Size(30, 14)
        Me.lblTipo.TabIndex = 5
        Me.lblTipo.Text = "T&ipo:"
        '
        'lblMarca
        '
        Me.lblMarca.AutoSize = True
        Me.lblMarca.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMarca.ForeColor = System.Drawing.Color.Black
        Me.lblMarca.Location = New System.Drawing.Point(15, 204)
        Me.lblMarca.Name = "lblMarca"
        Me.lblMarca.Size = New System.Drawing.Size(38, 14)
        Me.lblMarca.TabIndex = 6
        Me.lblMarca.Text = "&Marca:"
        '
        'lblProducto
        '
        Me.lblProducto.AutoSize = True
        Me.lblProducto.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblProducto.ForeColor = System.Drawing.Color.Black
        Me.lblProducto.Location = New System.Drawing.Point(15, 234)
        Me.lblProducto.Name = "lblProducto"
        Me.lblProducto.Size = New System.Drawing.Size(52, 14)
        Me.lblProducto.TabIndex = 7
        Me.lblProducto.Text = "Pro&ducto:"
        '
        'lblPropietario
        '
        Me.lblPropietario.AutoSize = True
        Me.lblPropietario.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPropietario.ForeColor = System.Drawing.Color.Black
        Me.lblPropietario.Location = New System.Drawing.Point(15, 264)
        Me.lblPropietario.Name = "lblPropietario"
        Me.lblPropietario.Size = New System.Drawing.Size(62, 14)
        Me.lblPropietario.TabIndex = 8
        Me.lblPropietario.Text = "Propietari&o:"
        '
        'lblTransponder
        '
        Me.lblTransponder.AutoSize = True
        Me.lblTransponder.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTransponder.ForeColor = System.Drawing.Color.Black
        Me.lblTransponder.Location = New System.Drawing.Point(15, 294)
        Me.lblTransponder.Name = "lblTransponder"
        Me.lblTransponder.Size = New System.Drawing.Size(71, 14)
        Me.lblTransponder.TabIndex = 9
        Me.lblTransponder.Text = "Tra&nsponder:"
        '
        'lblGPS
        '
        Me.lblGPS.AutoSize = True
        Me.lblGPS.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblGPS.ForeColor = System.Drawing.Color.Black
        Me.lblGPS.Location = New System.Drawing.Point(15, 324)
        Me.lblGPS.Name = "lblGPS"
        Me.lblGPS.Size = New System.Drawing.Size(28, 14)
        Me.lblGPS.TabIndex = 10
        Me.lblGPS.Text = "&GPS:"
        '
        'lblStatus
        '
        Me.lblStatus.AutoSize = True
        Me.lblStatus.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStatus.ForeColor = System.Drawing.Color.Black
        Me.lblStatus.Location = New System.Drawing.Point(15, 354)
        Me.lblStatus.Name = "lblStatus"
        Me.lblStatus.Size = New System.Drawing.Size(39, 14)
        Me.lblStatus.TabIndex = 11
        Me.lblStatus.Text = "Stat&us:"
        '
        'txtCapacidad
        '
        Me.txtCapacidad.BackColor = System.Drawing.Color.Gainsboro
        Me.txtCapacidad.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtCapacidad.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCapacidad.ForeColor = System.Drawing.Color.Black
        Me.txtCapacidad.Location = New System.Drawing.Point(104, 111)
        Me.txtCapacidad.MaxLength = 10
        Me.txtCapacidad.Name = "txtCapacidad"
        Me.txtCapacidad.ReadOnly = True
        Me.txtCapacidad.Size = New System.Drawing.Size(136, 21)
        Me.txtCapacidad.TabIndex = 4
        Me.txtCapacidad.Text = ""
        '
        'txtPlacas
        '
        Me.txtPlacas.BackColor = System.Drawing.Color.Gainsboro
        Me.txtPlacas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPlacas.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPlacas.ForeColor = System.Drawing.Color.Black
        Me.txtPlacas.Location = New System.Drawing.Point(104, 141)
        Me.txtPlacas.MaxLength = 20
        Me.txtPlacas.Name = "txtPlacas"
        Me.txtPlacas.ReadOnly = True
        Me.txtPlacas.Size = New System.Drawing.Size(136, 21)
        Me.txtPlacas.TabIndex = 5
        Me.txtPlacas.Text = ""
        '
        'cboTipo
        '
        Me.cboTipo.BackColor = System.Drawing.Color.Gainsboro
        Me.cboTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTipo.Enabled = False
        Me.cboTipo.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboTipo.Location = New System.Drawing.Point(104, 171)
        Me.cboTipo.Name = "cboTipo"
        Me.cboTipo.Size = New System.Drawing.Size(136, 21)
        Me.cboTipo.TabIndex = 6
        '
        'cboMarca
        '
        Me.cboMarca.BackColor = System.Drawing.Color.Gainsboro
        Me.cboMarca.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboMarca.Enabled = False
        Me.cboMarca.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboMarca.Location = New System.Drawing.Point(104, 201)
        Me.cboMarca.Name = "cboMarca"
        Me.cboMarca.Size = New System.Drawing.Size(136, 21)
        Me.cboMarca.TabIndex = 7
        '
        'cboProducto
        '
        Me.cboProducto.BackColor = System.Drawing.Color.Gainsboro
        Me.cboProducto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboProducto.Enabled = False
        Me.cboProducto.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboProducto.Location = New System.Drawing.Point(104, 231)
        Me.cboProducto.Name = "cboProducto"
        Me.cboProducto.Size = New System.Drawing.Size(136, 21)
        Me.cboProducto.TabIndex = 8
        '
        'cboPropietario
        '
        Me.cboPropietario.BackColor = System.Drawing.Color.Gainsboro
        Me.cboPropietario.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPropietario.Enabled = False
        Me.cboPropietario.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboPropietario.Location = New System.Drawing.Point(104, 261)
        Me.cboPropietario.Name = "cboPropietario"
        Me.cboPropietario.Size = New System.Drawing.Size(136, 21)
        Me.cboPropietario.TabIndex = 9
        '
        'txtTransponder
        '
        Me.txtTransponder.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTransponder.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTransponder.ForeColor = System.Drawing.Color.Black
        Me.txtTransponder.Location = New System.Drawing.Point(104, 291)
        Me.txtTransponder.MaxLength = 20
        Me.txtTransponder.Name = "txtTransponder"
        Me.txtTransponder.Size = New System.Drawing.Size(136, 21)
        Me.txtTransponder.TabIndex = 10
        Me.txtTransponder.Text = ""
        '
        'txtGPS
        '
        Me.txtGPS.BackColor = System.Drawing.Color.Gainsboro
        Me.txtGPS.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtGPS.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtGPS.ForeColor = System.Drawing.Color.Black
        Me.txtGPS.Location = New System.Drawing.Point(104, 321)
        Me.txtGPS.MaxLength = 3
        Me.txtGPS.Name = "txtGPS"
        Me.txtGPS.ReadOnly = True
        Me.txtGPS.Size = New System.Drawing.Size(136, 21)
        Me.txtGPS.TabIndex = 11
        Me.txtGPS.Text = ""
        '
        'cboStatus
        '
        Me.cboStatus.BackColor = System.Drawing.Color.Gainsboro
        Me.cboStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboStatus.Enabled = False
        Me.cboStatus.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboStatus.Items.AddRange(New Object() {"ACTIVO", "INACTIVO"})
        Me.cboStatus.Location = New System.Drawing.Point(104, 351)
        Me.cboStatus.Name = "cboStatus"
        Me.cboStatus.Size = New System.Drawing.Size(136, 21)
        Me.cboStatus.TabIndex = 12
        '
        'cboRuta
        '
        Me.cboRuta.BackColor = System.Drawing.Color.Gainsboro
        Me.cboRuta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboRuta.Enabled = False
        Me.cboRuta.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboRuta.Location = New System.Drawing.Point(104, 81)
        Me.cboRuta.Name = "cboRuta"
        Me.cboRuta.Size = New System.Drawing.Size(136, 21)
        Me.cboRuta.TabIndex = 2
        '
        'frmCapturaAutotanque
        '
        Me.AcceptButton = Me.btnAceptar
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 14)
        Me.BackColor = System.Drawing.Color.Gainsboro
        Me.CancelButton = Me.btnCancelar
        Me.ClientSize = New System.Drawing.Size(360, 423)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.rgrpDatos, Me.btnCancelar, Me.btnAceptar})
        Me.DockPadding.All = 3
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmCapturaAutotanque"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.rgrpDatos.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Variables globales"
    Private Ruta As Integer
#End Region

#Region "Manejo de datos"
    Private Sub CargaDatosAutotanque()
        Dim cmdLogistica As New SqlCommand("Select * from vwDatosAutotanque where Autotanque = @Autotanque", Globales.GetInstance.cnSigamet)
        Dim rdrLogistica As SqlDataReader
        'Carga de parámetros
        cmdLogistica.Parameters.Add("@Autotanque", SqlDbType.Int).Value = CInt(txtAutotanque.Text)
        Try
            Globales.GetInstance.cnSigamet.Open()
            rdrLogistica = cmdLogistica.ExecuteReader
            If rdrLogistica.Read Then
                Ruta = CInt(rdrLogistica("Ruta"))
                cboRuta.SelectedValue = Ruta
                txtCapacidad.Text = CStr(rdrLogistica("Capacidad"))
                txtPlacas.Text = CStr(rdrLogistica("Placas"))
                cboTipo.SelectedValue = rdrLogistica("TipoVehiculo")
                cboMarca.SelectedValue = rdrLogistica("MarcaAutotanque")
                cboProducto.SelectedValue = rdrLogistica("TipoProducto")
                cboPropietario.SelectedValue = rdrLogistica("Propietario")
                txtTransponder.Text = CStr(rdrLogistica("Transponder"))
                txtGPS.Text = CStr(rdrLogistica("GPS"))
                If CStr(rdrLogistica("Status")).Trim.ToUpper = "ACTIVO" Then
                    cboStatus.SelectedIndex = 0
                Else
                    cboStatus.SelectedIndex = 1
                End If
                txtCalibracion.Text = CStr(rdrLogistica("Calibracion"))
            End If
            rdrLogistica.Close()
        Catch ex As Exception
            Globales.GetInstance.ExMessage(ex)
        Finally
            Globales.GetInstance.cnSigamet.Close()
            cmdLogistica.Dispose()
        End Try
    End Sub
    Private Sub cboCelula_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboCelula.SelectedValueChanged
        If Not cboCelula.SelectedValue Is Nothing Then
            Dim daLogistica As New SqlDataAdapter("Select Ruta, Descripcion from Ruta where Celula = @Celula", Globales.GetInstance.cnSigamet)
            Dim dtRuta As New DataTable()
            daLogistica.SelectCommand.Parameters.Add("@Celula", SqlDbType.TinyInt).Value = CInt(cboCelula.SelectedValue)
            Try
                daLogistica.Fill(dtRuta)
                cboRuta.ValueMember = "Ruta"
                cboRuta.DisplayMember = "Descripcion"
                cboRuta.DataSource = dtRuta
                cboRuta.SelectedValue = Ruta
                If cboRuta.SelectedItem Is Nothing Then
                    cboRuta.SelectedIndex = 0
                End If
            Catch ex As Exception
                Globales.GetInstance.ExMessage(ex)
            Finally
                daLogistica.Dispose()
            End Try
        End If
    End Sub
#End Region
#Region "Botones"
    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.Close()
        Me.Dispose()
    End Sub
    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        Dim cmdLogistica As SqlCommand
        'Validaciones
        If Trim(txtAutotanque.Text) = "" Then
            Globales.GetInstance.ErrMessage("No ha proporcionado el número de autotanque.")
            txtAutotanque.Focus()
            Exit Sub
        End If
        If Trim(txtCapacidad.Text) = "" Then
            txtCapacidad.Text = "0"
        End If
        If Trim(txtGPS.Text) = "" Then
            txtGPS.Text = "0"
        End If
        If Trim(txtCapacidad.Text) = "" Then
            txtCapacidad.Text = "0"
        End If
        If Val(txtCapacidad.Text) > 2147483647 Then
            Globales.GetInstance.ErrMessage("La capacidad del autotanque debe ser menor a 2147483648.")
            txtCapacidad.Clear()
            txtCapacidad.Focus()
            Exit Sub
        End If
        If Val(txtGPS.Text) > 255 Then
            Globales.GetInstance.ErrMessage("El número de GPS debe ser menor a 256.")
            txtGPS.Clear()
            txtGPS.Focus()
            Exit Sub
        End If
        If Val(txtCalibracion.Text) < Globales.GetInstance._CalibracionMinima OrElse Val(txtCalibracion.Text) > Globales.GetInstance._CalibracionMaxima Then
            Globales.GetInstance.ErrMessage("La calibración está fuera del intervalo (" & Globales.GetInstance._CalibracionMinima.ToString() & ", " & Globales.GetInstance._CalibracionMaxima.ToString() & ")")
            txtCalibracion.Clear()
            txtCalibracion.Focus()
            Exit Sub
        End If
        Me.Cursor = Cursors.WaitCursor
        cmdLogistica = New SqlCommand("spLOGAutotanque", Globales.GetInstance.cnSigamet)

        ' Asignación de parámetros
        cmdLogistica.CommandType = CommandType.StoredProcedure
        cmdLogistica.Parameters.Add("@Autotanque", SqlDbType.SmallInt).Value = CInt(txtAutotanque.Text)
        cmdLogistica.Parameters.Add("@Capacidad", SqlDbType.Int).Value = CInt(txtCapacidad.Text)
        cmdLogistica.Parameters.Add("@Ruta", SqlDbType.SmallInt).Value = CInt(cboRuta.SelectedValue)
        cmdLogistica.Parameters.Add("@GPS", SqlDbType.TinyInt).Value = CInt(txtGPS.Text)
        cmdLogistica.Parameters.Add("@Placas", SqlDbType.Char).Value = txtPlacas.Text
        cmdLogistica.Parameters.Add("@Marca", SqlDbType.TinyInt).Value = CInt(cboMarca.SelectedValue)
        cmdLogistica.Parameters.Add("@Tipo", SqlDbType.TinyInt).Value = CInt(cboTipo.SelectedValue)
        cmdLogistica.Parameters.Add("@Propietario", SqlDbType.SmallInt).Value = CInt(cboPropietario.SelectedValue)
        cmdLogistica.Parameters.Add("@Producto", SqlDbType.TinyInt).Value = CInt(cboProducto.SelectedValue)
        cmdLogistica.Parameters.Add("@Transponder", SqlDbType.Char).Value = txtTransponder.Text
        cmdLogistica.Parameters.Add("@Celula", SqlDbType.TinyInt).Value = CInt(cboCelula.SelectedValue)
        cmdLogistica.Parameters.Add("@Status", SqlDbType.Char).Value = cboStatus.Text
        cmdLogistica.Parameters.Add("@Nuevo", SqlDbType.Bit).Value = (Me.Text = "Nuevo autotanque")
        cmdLogistica.Parameters.Add("@Calibracion", SqlDbType.Decimal).Value = Val(txtCalibracion.Text)
        Try
            Globales.GetInstance.cnSigamet.Open()
            cmdLogistica.ExecuteNonQuery()
            Me.DialogResult = DialogResult.OK
            Me.Close()
        Catch ex As Exception
            Globales.GetInstance.ExMessage(ex)
        Finally
            Me.Cursor = Cursors.Default
            Globales.GetInstance.cnSigamet.Close()
            cmdLogistica.Dispose()
        End Try
    End Sub
#End Region
#Region "Manejo de cajas de texto"
    Private Sub TextBox_Enter(ByVal sender As Object, ByVal e As EventArgs) Handles txtTransponder.Enter, txtCalibracion.Enter
        CType(sender, TextBox).BackColor = Color.LightGoldenrodYellow
    End Sub
    Private Sub TextBox_Leave(ByVal sender As Object, ByVal e As EventArgs) Handles txtTransponder.Leave, txtCalibracion.Leave
        CType(sender, TextBox).BackColor = Color.White
    End Sub
    Private Sub TextBox_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs) Handles txtTransponder.KeyPress
        If Not (Char.IsDigit(e.KeyChar) Or Asc(e.KeyChar) = 8 Or Char.IsControl(e.KeyChar)) Then
            e.Handled = True
        Else
            e.Handled = False
        End If
    End Sub
    Private Sub TextBoxDecimal_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCalibracion.KeyPress
        If Not (Char.IsDigit(e.KeyChar) OrElse Char.IsControl(e.KeyChar) OrElse Asc(e.KeyChar) = 8 OrElse _
                    (e.KeyChar = CChar(".") AndAlso CType(sender, TextBox).Text.IndexOf(".") < 0)) Then
            e.Handled = True
        Else
            e.Handled = False
        End If
    End Sub
#End Region

End Class
