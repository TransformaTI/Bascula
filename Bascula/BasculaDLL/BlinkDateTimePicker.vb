Public Class BlinkDateTimePicker
    Inherits System.Windows.Forms.DateTimePicker

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
    Friend WithEvents tmrBlinker As System.Windows.Forms.Timer
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.tmrBlinker = New System.Windows.Forms.Timer(Me.components)
        '
        'tmrBlinker
        '
        Me.tmrBlinker.Interval = 1000
        '
        'BlinkDateTimePicker
        '
        Me.Name = "UserControl1"
        Me.Size = New System.Drawing.Size(152, 20)
        Me.Value = New Date(2005, 2, 9, 10, 29, 54, 145)

    End Sub

#End Region




    Private _BackColor As Color = SystemColors.Window
    Private _BlinkColor As Color = Color.LemonChiffon
    Public Overrides Property BackColor() As Color
        Get
            Return _BackColor
        End Get
        Set(ByVal Value As Color)
            _BackColor = Value
            Invalidate()
        End Set
    End Property

    Public Property BlinkColor() As Color
        Get
            Return _BlinkColor
        End Get
        Set(ByVal Value As Color)
            _BlinkColor = Value
        End Set
    End Property



    Protected Overrides Sub WndProc(ByRef m As Message)
        If m.Msg = 20 Then
            Dim g As Graphics = Graphics.FromHdc(m.WParam)
            g.FillRectangle(New SolidBrush(_BackColor), ClientRectangle)
            g.Dispose()
            Return
        End If
        MyBase.WndProc(m)
    End Sub

    Public Sub Blink()
        tmrBlinker.Enabled = Me.Enabled
    End Sub


    Private Sub tmrBlinker_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrBlinker.Tick
        Static BlinkTimes As Integer
        Static Blink As Boolean
        If Blink Then
            Me.BackColor = SystemColors.Window
            Me.Font = New Font(Me.Font, FontStyle.Regular)
        Else
            Me.BackColor = _BlinkColor
            Me.Font = New Font(Me.Font, FontStyle.Bold)
            Beep()
        End If
        Me.Refresh()
        BlinkTimes += 1
        Blink = Not Blink
        If BlinkTimes = 10 Then
            BlinkTimes = 0
            tmrBlinker.Enabled = False
        End If
    End Sub
End Class
