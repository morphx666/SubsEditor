Module ModuleGlobals
    Public Function StringToWindowState(state As String) As FormWindowState
        Select Case state
            Case FormWindowState.Normal.ToString()
                Return FormWindowState.Normal
            Case FormWindowState.Maximized.ToString()
                Return FormWindowState.Maximized
            Case FormWindowState.Minimized.ToString()
                Return FormWindowState.Minimized
            Case Else
                Return FormWindowState.Normal
        End Select
    End Function

    Public Function StringToPoint(point As String) As Point
        Dim tokens() = point.Substring(1, point.Length - 2).Split(","c)
        Return New Point(CInt(tokens(0).Split("="c)(1)), CInt(tokens(1).Split("="c)(1)))
    End Function

    Public Function StringToSize(point As String) As Size
        Dim tokens() = point.Substring(1, point.Length - 2).Split(","c)
        Return New Size(CInt(tokens(0).Split("="c)(1)), CInt(tokens(1).Split("="c)(1)))
    End Function

    Public Function StringToBoolean(value As String) As Boolean
        Dim b As Boolean = False
        Boolean.TryParse(value, b)
        Return b
    End Function

    Public Function FormatTimeStamp(value As TimeSpan) As String
        Return String.Format("{0:00}:{1:00}:{2:00}.{3:0000}", value.Hours, value.Minutes, value.Seconds, value.Milliseconds)
    End Function
End Module




