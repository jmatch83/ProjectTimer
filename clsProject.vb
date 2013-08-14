Public Class clsProject
    Private m_sName As String
    Private m_sID As String
    Private m_sDesc As String
    Private m_wTimer As Stopwatch

    'mod 2010-02-18 add time ++
    Public Sub New(ByVal sID As String, ByVal sName As String, ByVal sDescription As String)
        'Public Sub New(ByVal sID As String, ByVal sName As String, ByVal sDescription As String, ByVal sTime As String)
        'mod 2010-02-18 add time --
        ID = sID
        Name = sName
        Description = sDescription
        m_wTimer = New Stopwatch
        'setTime = sTime 'mod 2010-02-18 add time
    End Sub

#Region "Properties"
    Public Property Name() As String
        Get
            Return m_sName
        End Get
        Set(ByVal value As String)
            m_sName = value
        End Set
    End Property

    Public Property ID() As String
        Get
            Return m_sID
        End Get
        Set(ByVal value As String)
            m_sID = value
        End Set
    End Property

    Public Property Description() As String
        Get
            Return m_sDesc
        End Get
        Set(ByVal value As String)
            m_sDesc = value
        End Set
    End Property

    'mod 2010-02-18 add time ++
    'Public WriteOnly Property setTime() As String
    '    Set(ByVal sTime As String)
    '        Dim oTime As Object
    '        Dim tTime As TimeSpan
    '        Dim sHMS As String()
    '        sHMS = Split(sTime, ":")
    '        tTime = New TimeSpan(CInt(sHMS(0)), CInt(sHMS(1)), CInt(sHMS(2)))
    '        oTime = DirectCast(tTime, Object)
    '        m_wTimer = DirectCast(oTime, Stopwatch)
    '    End Set
    'End Property
    'mod 2010-02-18 add time --

    Public ReadOnly Property getTime() As String
        Get
            Dim Hours As String
            Dim Mins As String
            Dim Secs As String

            Hours = m_wTimer.Elapsed.Hours.ToString
            Mins = m_wTimer.Elapsed.Minutes.ToString
            Secs = m_wTimer.Elapsed.Seconds.ToString
            If Val(Hours) < 10 Then
                Hours = "0" & Hours
            End If
            If Val(Mins) < 10 Then
                Mins = "0" & Mins
            End If
            If Val(Secs) < 10 Then
                Secs = "0" & Secs
            End If
            Return Hours & ":" & Mins & ":" & Secs

        End Get
    End Property

    Public ReadOnly Property IsTimerRunning() As Boolean
        Get
            Return m_wTimer.IsRunning
        End Get
    End Property
#End Region

#Region "Methods"
    Public Sub StartTime()
        If Not m_wTimer.IsRunning Then
            m_wTimer.Start()
        End If
    End Sub

    Public Sub StopTime()
        If m_wTimer.IsRunning Then
            m_wTimer.Stop()
        End If
    End Sub

    Public Sub ResetTime()
        m_wTimer.Reset()
    End Sub
#End Region

End Class
