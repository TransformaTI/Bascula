Option Explicit On 
Option Strict On

Imports System.Data
Imports System.Data.SqlClient

Public Class frmAnularOperacion
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "
    Public Sub New(ByVal Año As Integer, ByVal Folio As Integer)
        MyBase.new()
        InitializeComponent()
        _Año = Año
        _Folio = Folio
        cboMotivos.SelectedIndex = 0
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
    Friend WithEvents cboMotivos As System.Windows.Forms.ComboBox
    Friend WithEvents btnAceptar As System.Windows.Forms.Button
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents lblMotivo As System.Windows.Forms.Label
    Friend WithEvents rgrpDatos As Bascula.RoundedGroupBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmAnularOperacion))
        Me.cboMotivos = New System.Windows.Forms.ComboBox()
        Me.btnAceptar = New System.Windows.Forms.Button()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.lblMotivo = New System.Windows.Forms.Label()
        Me.rgrpDatos = New Bascula.RoundedGroupBox()
        Me.rgrpDatos.SuspendLayout()
        Me.SuspendLayout()
        '
        'cboMotivos
        '
        Me.cboMotivos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboMotivos.Items.AddRange(New Object() {"No Salió a Ruta", "Inconformidad del Operador", "Totalizador Incorrecto", "Salio del Taller de Gas", "Salio del Taller Mecanico", "Bàscula En Mal Estado", "Datos Ilegibles", "Inicializaciòn del Totalizador", "Pruebas de Manejo", "Viene de Reparar Muelles", "Mala Impresion de Documento", "kilometraje Incorrecto", "Porcentaje de Gas Incorrecto", "Cubicacion Incorrecta de la Unidad"})
        Me.cboMotivos.Location = New System.Drawing.Point(64, 30)
        Me.cboMotivos.Name = "cboMotivos"
        Me.cboMotivos.Size = New System.Drawing.Size(216, 21)
        Me.cboMotivos.TabIndex = 1
        '
        'btnAceptar
        '
        Me.btnAceptar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnAceptar.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAceptar.Image = CType(resources.GetObject("btnAceptar.Image"), System.Drawing.Image)
        Me.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAceptar.Location = New System.Drawing.Point(312, 10)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(80, 24)
        Me.btnAceptar.TabIndex = 1
        Me.btnAceptar.Text = "&Aceptar"
        Me.btnAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnCancelar
        '
        Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnCancelar.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancelar.Image = CType(resources.GetObject("btnCancelar.Image"), System.Drawing.Image)
        Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancelar.Location = New System.Drawing.Point(312, 42)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(80, 24)
        Me.btnCancelar.TabIndex = 2
        Me.btnCancelar.Text = "&Cancelar"
        Me.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblMotivo
        '
        Me.lblMotivo.AutoSize = True
        Me.lblMotivo.Location = New System.Drawing.Point(16, 33)
        Me.lblMotivo.Name = "lblMotivo"
        Me.lblMotivo.Size = New System.Drawing.Size(43, 13)
        Me.lblMotivo.TabIndex = 0
        Me.lblMotivo.Text = "&Motivo:"
        '
        'rgrpDatos
        '
        Me.rgrpDatos.BorderColor = System.Drawing.Color.DarkBlue
        Me.rgrpDatos.Controls.Add(Me.cboMotivos)
        Me.rgrpDatos.Controls.Add(Me.lblMotivo)
        Me.rgrpDatos.Dock = System.Windows.Forms.DockStyle.Left
        Me.rgrpDatos.FlatStyle = Bascula.RoundedGroupBox.Style.Pipe
        Me.rgrpDatos.Location = New System.Drawing.Point(0, 0)
        Me.rgrpDatos.Name = "rgrpDatos"
        Me.rgrpDatos.Size = New System.Drawing.Size(296, 75)
        Me.rgrpDatos.TabIndex = 0
        Me.rgrpDatos.TabStop = False
        Me.rgrpDatos.TextAlignment = System.Windows.Forms.HorizontalAlignment.Left
        '
        'frmAnularOperacion
        '
        Me.AcceptButton = Me.btnAceptar
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 14)
        Me.BackColor = System.Drawing.Color.Gainsboro
        Me.CancelButton = Me.btnCancelar
        Me.ClientSize = New System.Drawing.Size(400, 75)
        Me.ControlBox = False
        Me.Controls.Add(Me.rgrpDatos)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.btnAceptar)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "frmAnularOperacion"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Anulación de operacion"
        Me.rgrpDatos.ResumeLayout(False)
        Me.rgrpDatos.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private _Año, _Folio As Integer

    Private Sub cmdAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        AnularOperacion()
    End Sub
    Private Sub AnularOperacion()
        Dim cmdBascula As New SqlCommand("spBASCancelaFolio", Globales.GetInstance.cnSigamet)
        cmdBascula.Parameters.Add("@Año", SqlDbType.SmallInt).Value = _Año
        cmdBascula.Parameters.Add("@Folio", SqlDbType.Int).Value = _Folio
        cmdBascula.Parameters.Add("@Observaciones", SqlDbType.VarChar).Value = cboMotivos.Text
        cmdBascula.CommandType = CommandType.StoredProcedure
        Try
            Globales.GetInstance.AbreConexion()
            cmdBascula.ExecuteNonQuery()
            Me.Close()
            Me.DialogResult = DialogResult.OK
        Catch ex As Exception
            Globales.GetInstance.ExMessage(ex)
        Finally
            Globales.GetInstance.CierraConexion()
        End Try
    End Sub






End Class

