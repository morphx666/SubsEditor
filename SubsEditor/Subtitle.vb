Imports System.Collections.ObjectModel

Public Class Subtitle
    Private mIndex As Integer
    Private mFromTimeOriginal As TimeSpan
    Private mToTimeOriginal As TimeSpan
    Private mFromTimeOffsetted As TimeSpan
    Private mToTimeOffsetted As TimeSpan
    Private mTextOriginal As String
    Private mTextOffsetted As String

    Public Sub New(index As Integer, fromTime As TimeSpan, toTime As TimeSpan, text As String)
        mIndex = index

        mFromTimeOriginal = fromTime
        mFromTimeOffsetted = fromTime

        mToTimeOriginal = toTime
        mToTimeOffsetted = toTime

        mTextOriginal = text
        mTextOffsetted = text
    End Sub

    Public Property Index As Integer
        Get
            Return mIndex
        End Get
        Set(value As Integer)
            mIndex = value
        End Set
    End Property

    Public ReadOnly Property FromTimeOriginal As TimeSpan
        Get
            Return mFromTimeOriginal
        End Get
    End Property

    Public ReadOnly Property ToTimeOriginal As TimeSpan
        Get
            Return mToTimeOriginal
        End Get
    End Property

    Public ReadOnly Property TextOriginal As String
        Get
            Return mTextOriginal
        End Get
    End Property

    Public Property FromTimeOffsetted As TimeSpan
        Get
            Return mFromTimeOffsetted
        End Get
        Set(value As TimeSpan)
            mFromTimeOffsetted = value
        End Set
    End Property

    Public Property ToTimeOffsetted As TimeSpan
        Get
            Return mToTimeOffsetted
        End Get
        Set(value As TimeSpan)
            mToTimeOffsetted = value
        End Set
    End Property

    Public Property TextOffsetted As String
        Get
            Return mTextOffsetted
        End Get
        Set(value As String)
            mTextOffsetted = value
        End Set
    End Property

    Public Function GetOffsettedSRTTime() As String
        Return String.Format("{0:00}:{1:00}:{2:00},{3:000} --> {4:00}:{5:00}:{6:00},{7:000}",
                             mFromTimeOffsetted.Hours,
                             mFromTimeOffsetted.Minutes,
                             mFromTimeOffsetted.Seconds,
                             mFromTimeOffsetted.Milliseconds,
                             mToTimeOffsetted.Hours,
                             mToTimeOffsetted.Minutes,
                             mToTimeOffsetted.Seconds,
                             mToTimeOffsetted.Milliseconds)
    End Function

    Public Function GetOffsettedSUBTime(fps As Single) As String
        Return String.Format("{{{0:0}}}{{{1:0}}}",
                             mFromTimeOffsetted.TotalMilliseconds * fps / 1000,
                             mToTimeOffsetted.TotalMilliseconds * fps / 1000)
    End Function

    Public Shared Function StringToTimeSpan(textTime As String) As TimeSpan
        Dim tokens() = textTime.Replace(",", ":").Split(":"c)
        Dim h As Integer = tokens(0)
        Dim m As Integer = tokens(1)
        Dim s As Integer = tokens(2)
        Dim ms As Integer = tokens(3)

        Return New TimeSpan(0, h, m, s, ms)
    End Function

    Public Shared Operator =(c1 As Subtitle, c2 As Subtitle) As Boolean
        If c1 Is Nothing OrElse c2 Is Nothing Then Return False

        Return c1.Index = c2.Index
    End Operator

    Public Shared Operator <>(c1 As Subtitle, c2 As Subtitle) As Boolean
        Return Not c1 = c2
    End Operator
End Class

Public Class SubtitlesList
    Inherits ObservableCollection(Of Subtitle)
End Class