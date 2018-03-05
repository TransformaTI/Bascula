Option Strict On
Option Explicit On 


Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared

Public Class frmImprimeCiclo
    Inherits System.Windows.Forms.Form
    Dim rptTabla As Table
    Dim rptLogin As New CrystalDecisions.Shared.TableLogOnInfo()
    Dim rptNombreReporte As New ReportDocument()
    Dim crParametervalues As CrystalDecisions.Shared.ParameterValues
    Dim crParameterDiscretValue As CrystalDecisions.Shared.ParameterDiscreteValue
    Dim crParameterFieldDefinitions As ParameterFieldDefinitions
    Dim crParameterFieldDefinition As ParameterFieldDefinition


#Region " Windows Form Designer generated code "
   
    Public Sub New(ByVal Folio As Integer, _
                   ByVal Autotanque As Integer)

        MyBase.New()
        InitializeComponent()
        rptNombreReporte.Load(Globales.GetInstance._RutaReportes & "\rptAbreCiclo.rpt")
        Call HazConexion()
        crParameterFieldDefinitions = rptNombreReporte.DataDefinition.ParameterFields
        crParameterFieldDefinition = crParameterFieldDefinitions.Item("@Folio")
        crParametervalues = crParameterFieldDefinition.CurrentValues
        crParameterDiscretValue = New ParameterDiscreteValue()
        crParameterDiscretValue.Value = Folio
        crParametervalues.Add(crParameterDiscretValue)
        crParameterFieldDefinition.ApplyCurrentValues(crParametervalues)

        crParameterFieldDefinition = crParameterFieldDefinitions.Item("@Autotanque")
        crParametervalues = crParameterFieldDefinition.CurrentValues
        crParameterDiscretValue = New ParameterDiscreteValue()
        crParameterDiscretValue.Value = Autotanque
        crParametervalues.Add(crParameterDiscretValue)
        crParameterFieldDefinition.ApplyCurrentValues(crParametervalues)


        crvReporte.ReportSource = rptNombreReporte
        'crvReporte.RefreshReport()
        'crvReporte.Update()
        'crvReporte.PrintReport()
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
    Friend WithEvents crvReporte As CrystalDecisions.Windows.Forms.CrystalReportViewer
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.crvReporte = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
        Me.SuspendLayout()
        '
        'crvReporte
        '
        Me.crvReporte.ActiveViewIndex = -1
        ''Me.crvReporte.DisplayGroupTree = False
        Me.crvReporte.ShowGroupTreeButton = False
        Me.crvReporte.Location = New System.Drawing.Point(8, 24)
        Me.crvReporte.Name = "crvReporte"
        Me.crvReporte.ReportSource = Nothing
        Me.crvReporte.Size = New System.Drawing.Size(688, 488)
        Me.crvReporte.TabIndex = 0
        Me.crvReporte.Visible = False
        '
        'frmImprimeCiclo
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(712, 525)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.crvReporte})
        Me.Name = "frmImprimeCiclo"
        Me.Text = "frmImprimeCiclo"
        Me.ResumeLayout(False)

    End Sub

#End Region

    Public Sub HazConexion()
        crvReporte.ReportSource = Nothing
        Dim strfiltro As String = ""
        Try
            For Each rptTabla In rptNombreReporte.Database.Tables
                rptLogin = rptTabla.LogOnInfo
                With rptLogin.ConnectionInfo
                    .ServerName = Globales.GetInstance._Servidor    ''"ERPMETRO"
                    .UserID = Globales.GetInstance._Usuario         ''"sa"
                    .Password = Globales.GetInstance._Password      ''"development"
                    .DatabaseName = Globales.GetInstance._Database  ''"Sigamet"
                End With
                rptTabla.ApplyLogOnInfo(rptLogin)
            Next rptTabla
        Catch Exp As LoadSaveReportException
            MsgBox("No se Encontro el reporte de apertura de ciclo", MsgBoxStyle.Critical, "Carga del reporte")
        End Try
    End Sub
End Class
