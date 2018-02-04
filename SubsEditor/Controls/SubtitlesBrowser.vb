Imports System.ComponentModel

Public Class SubtitlesBrowser
    Private Enum Objects
        Subtitles
        ScrollBar
    End Enum

    Private Enum SubtitleSections
        None
        Left
        Body
        Right
    End Enum

    Private Structure SubtitleRectangle
        Public Rectangle As Rectangle
        Public Subtitle As Subtitle

        Public Sub New(subtitle As Subtitle, rectangle As Rectangle)
            Me.Rectangle = rectangle
            Me.Subtitle = subtitle
        End Sub
    End Structure

    Private mPosition As TimeSpan = TimeSpan.Zero
    Private mZoomFactor As Integer = 100
    Private mSelectedSubtitle As Subtitle
    Private mRippleEdits As Boolean
    Private mMediaDuration As TimeSpan = TimeSpan.Zero
    Private mPeaksFileName As String
    Private mSubtitles As SubtitlesList

    Private mSubtitleBackColor As Color = Color.FromArgb(128, 80, 80, 80)
    Private mSubtitleSelectedBackColor As Color = Color.FromArgb(128, Color.DimGray)
    Private mWaveFormColor As Color = Color.FromArgb(200, 173, 255, 47)
    Private mWaveFormSelectedColor As Color = Color.FromArgb(200, Color.Red)
    Private mGridColor As Color = Color.FromArgb(33, 33, 33)
    Private mGridTimeColor As Color = Color.Silver
    Private mGridTimeFont As Font = New Font(Me.Font.FontFamily, 9, FontStyle.Regular, GraphicsUnit.Pixel)
    Private mPositionMarkerColor As Color = Color.FromArgb(200, Color.LightBlue)

    Private xOffset As Integer = 0
    Private isLeftMouseButtonDown As Boolean
    Private cursorPos As Point
    Private overObject As Objects = Objects.Subtitles
    Private subtitleSection As SubtitleSections = SubtitleSections.None
    Private overSubtitle As Subtitle = Nothing
    Private beforeEditToTime As TimeSpan
    Private subtitleChanged As Boolean
    Private subtitlesRectangles As List(Of SubtitleRectangle) = New List(Of SubtitleRectangle)
    Private subtitleChangedAfterMouseOperation As Boolean

    Private lastSubtitle As Subtitle
    Private firstSubtitle As Subtitle
    Private subtitlesTrackLengthInSeconds As Double

    Private isShiftDown As Boolean
    Private isCtrlDown As Boolean

    Private newSubtitleStartPosition As Integer
    Private newSubtitleEndPosition As Integer
    Private isCreatingNewSubtitle As Boolean

    Private peaks As List(Of Integer) = New List(Of Integer)
    Private minPeak As Integer
    Private maxPeak As Integer
    Private peaksInterval As Integer

    Public Class SubtitleSelectedEventArgs
        Private mSubtitle As Subtitle
        Private mChanged As Boolean

        Public Sub New(subtitle As Subtitle, changed As Boolean)
            mSubtitle = subtitle
            mChanged = changed
        End Sub

        Public ReadOnly Property Subtitle As Subtitle
            Get
                Return mSubtitle
            End Get
        End Property

        Public ReadOnly Property Changed As Boolean
            Get
                Return mChanged
            End Get
        End Property
    End Class

    Public Class SubtitlesChangedEventArgs
        Private mSubtitles As List(Of Subtitle)
        Private mChanged As Boolean

        Public Sub New(subtitles As List(Of Subtitle))
            mSubtitles = subtitles
        End Sub

        Public ReadOnly Property Subtitles As List(Of Subtitle)
            Get
                Return mSubtitles
            End Get
        End Property
    End Class

    Public Class PositionChangedEventArgs
        Private mSubtitle As Subtitle
        Private mPosition As TimeSpan

        Public Sub New(subtitle As Subtitle, position As TimeSpan)
            mSubtitle = subtitle
            mPosition = position
        End Sub

        Public ReadOnly Property Subtitle As Subtitle
            Get
                Return mSubtitle
            End Get
        End Property

        Public ReadOnly Property Position As TimeSpan
            Get
                Return mPosition
            End Get
        End Property
    End Class

    Public Class CreateNewSubtitleEventArgs
        Private mStartTime As TimeSpan
        Private mEndTime As TimeSpan

        Public Sub New(startTime As TimeSpan, endTime As TimeSpan)
            mStartTime = startTime
            mEndTime = endTime
        End Sub

        Public ReadOnly Property StartTime As TimeSpan
            Get
                Return mStartTime
            End Get
        End Property

        Public ReadOnly Property EndTime As TimeSpan
            Get
                Return mEndTime
            End Get
        End Property
    End Class

    Public Event SubtitleSelected(sender As Object, e As SubtitleSelectedEventArgs)
    Public Event PositionChanged(sender As Object, e As PositionChangedEventArgs)
    Public Event SubtitlesChanged(sender As Object, e As SubtitlesChangedEventArgs)
    Public Event ZoomFactorChanged(sender As Object, e As EventArgs)
    Public Event CreateNewSubtitle(sender As Object, e As CreateNewSubtitleEventArgs)
    Public Event EditSubtitle(sender As Object, e As SubtitleSelectedEventArgs)

    <Browsable(False)>
    Public Property Subtitles As SubtitlesList
        Get
            Return mSubtitles
        End Get
        Set(value As SubtitlesList)
            mSubtitles = value

            If mSubtitles IsNot Nothing Then AddHandler Subtitles.CollectionChanged, Sub() UpdateUI(False)
        End Set
    End Property

    <Category("Appearance")>
    Public Property SubtitleBackColor As Color
        Get
            Return mSubtitleBackColor
        End Get
        Set(value As Color)
            mSubtitleBackColor = value
            Me.Invalidate()
        End Set
    End Property

    <Category("Appearance")>
    Public Property SubtitleSelectedBackColor As Color
        Get
            Return mSubtitleSelectedBackColor
        End Get
        Set(value As Color)
            mSubtitleSelectedBackColor = value
            Me.Invalidate()
        End Set
    End Property

    <Category("Appearance")>
    Public Property GridColor As Color
        Get
            Return mGridColor
        End Get
        Set(value As Color)
            mGridColor = value
            Me.Invalidate()
        End Set
    End Property

    <Category("Appearance")>
    Public Property GridTimeColor As Color
        Get
            Return mGridTimeColor
        End Get
        Set(value As Color)
            mGridTimeColor = value
            Me.Invalidate()
        End Set
    End Property

    <Category("Appearance")>
    Public Property WaveFormColor As Color
        Get
            Return mWaveFormColor
        End Get
        Set(value As Color)
            mWaveFormColor = value
            Me.Invalidate()
        End Set
    End Property

    <Category("Appearance")>
    Public Property WaveFormSelectedColor As Color
        Get
            Return mWaveFormSelectedColor
        End Get
        Set(value As Color)
            mWaveFormSelectedColor = value
            Me.Invalidate()
        End Set
    End Property

    <Category("Appearance")>
    Public Property GridTimeFont As Font
        Get
            Return mGridTimeFont
        End Get
        Set(value As Font)
            mGridTimeFont = value
            Me.Invalidate()
        End Set
    End Property

    <Category("Appearance")>
    Public Property PositionMarkerColor As Color
        Get
            Return mPositionMarkerColor
        End Get
        Set(value As Color)
            mPositionMarkerColor = value
            Me.Invalidate()
        End Set
    End Property

    <Browsable(False)>
    Public Property PeaksFileName As String
        Get
            Return mPeaksFileName
        End Get
        Set(value As String)
            mPeaksFileName = value

            peaks.Clear()

            If IO.File.Exists(mPeaksFileName) Then
                peaksInterval = 0
                Dim sr = New IO.FileStream(mPeaksFileName, IO.FileMode.Open)
                While sr.Position < sr.Length
                    Dim b(2 - 1) As Byte
                    sr.Read(b, 0, b.Length)
                    If peaksInterval = 0 Then
                        peaksInterval = BitConverter.ToInt16(b, 0)
                    Else
                        peaks.Add(BitConverter.ToInt16(b, 0))
                    End If
                End While
                sr.Close()
                sr.Dispose()

                minPeak = peaks.Min
                maxPeak = peaks.Max
            End If

            Me.Invalidate()
        End Set
    End Property

    <Browsable(False)>
    Public Property Position() As TimeSpan
        Get
            Return mPosition
        End Get
        Set(value As TimeSpan)
            mPosition = value
            Me.Invalidate()
        End Set
    End Property

    <Browsable(False)>
    Public Property SelectedSubtitle As Subtitle
        Get
            Return mSelectedSubtitle
        End Get
        Set(value As Subtitle)
            If mSelectedSubtitle <> value Then
                mSelectedSubtitle = value
                Me.Invalidate()
            End If
        End Set
    End Property

    <Category("Appearance")>
    Public Property ZoomFactor As Single
        Get
            Return mZoomFactor
        End Get
        Set(value As Single)
            SetZoomFactor(value)
        End Set
    End Property

    <Category("Behavior")>
    Public Property RippleEdits As Boolean
        Get
            Return mRippleEdits
        End Get
        Set(value As Boolean)
            mRippleEdits = value
        End Set
    End Property

    Public Sub CenterPosition(force As Boolean)
        Dim x As Integer = TimeToX(mPosition)
        If x < 0 OrElse x > Me.Width OrElse force Then
            Dim newOffset As Integer = mPosition.TotalSeconds * mZoomFactor - Me.Width \ 2
            If newOffset <> xOffset Then
                xOffset = newOffset
                CheckOffset()
                Me.Invalidate()
            End If
        End If
    End Sub

    Public Property MediaDuration As TimeSpan
        Get
            Return mMediaDuration
        End Get
        Set(value As TimeSpan)
            mMediaDuration = value
            subtitlesTrackLengthInSeconds = mMediaDuration.TotalSeconds
            Me.Invalidate()
        End Set
    End Property

    Public Sub UpdateUI(resetOffset As Boolean)
        SetFirstLastSubtitle()
        If resetOffset Then xOffset = 0
        Me.Invalidate()
    End Sub

    Public Function GetSubtitleAtPosition() As Subtitle
        Dim p As Point = New Point(TimeToX(mPosition), 3)
        For Each cr In subtitlesRectangles
            If cr.Rectangle.Contains(p) Then
                Return cr.Subtitle
            End If
        Next

        Return Nothing
    End Function

    Public Function TimeToX(time As TimeSpan) As Integer
        Return time.TotalSeconds * mZoomFactor - xOffset
    End Function

    Public Function XToTime(x As Integer) As TimeSpan
        Return TimeSpan.FromSeconds((x + xOffset) / mZoomFactor)
    End Function

    Private Sub SetFirstLastSubtitle()
        If mSubtitles Is Nothing OrElse Subtitles.Count = 0 Then
            firstSubtitle = Nothing
            lastSubtitle = Nothing
            MediaDuration = TimeSpan.Zero
        Else
            Dim min = mSubtitles.Min(Of TimeSpan)(Function(c) c.FromTimeOffsetted)
            firstSubtitle = (From c In mSubtitles Select c Where c.FromTimeOffsetted = min).First()

            Dim max = mSubtitles.Max(Of TimeSpan)(Function(c) c.ToTimeOffsetted)
            lastSubtitle = (From c In mSubtitles Select c Where c.ToTimeOffsetted = max).First()

            MediaDuration = lastSubtitle.ToTimeOffsetted
        End If
    End Sub

    Private Sub SubtitlesBrowser_DoubleClick(sender As Object, e As System.EventArgs) Handles Me.DoubleClick
        If overObject = Objects.Subtitles Then
            If subtitleSection <> SubtitleSections.None Then RaiseEvent EditSubtitle(Me, New SubtitleSelectedEventArgs(mSelectedSubtitle, subtitleChanged))
        End If
    End Sub

    Private Sub SubtitlesBrowser_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        isShiftDown = e.Shift
        isCtrlDown = e.Control
    End Sub

    Private Sub SubtitlesBrowser_KeyUp(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
        isShiftDown = e.Shift
        isCtrlDown = e.Control
    End Sub

    Private Sub SubtitlesBrowser_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Me.SetStyle(ControlStyles.AllPaintingInWmPaint, True)
        Me.SetStyle(ControlStyles.OptimizedDoubleBuffer, True)
        Me.SetStyle(ControlStyles.ResizeRedraw, True)
        Me.SetStyle(ControlStyles.Selectable, True)
        Me.SetStyle(ControlStyles.UserPaint, True)
    End Sub

    Private Sub SubtitlesBrowser_MouseDown(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseDown
        subtitleChangedAfterMouseOperation = False

        If mSubtitles.Count > 0 AndAlso e.Button = Windows.Forms.MouseButtons.Left Then
            If e.Y < Me.Height - 10 Then
                If isShiftDown Then
                    isCreatingNewSubtitle = True
                    newSubtitleStartPosition = e.X
                    newSubtitleEndPosition = e.X
                Else
                    overObject = Objects.Subtitles
                End If
            Else
                overObject = Objects.ScrollBar
            End If
            isLeftMouseButtonDown = True
            cursorPos = e.Location
            subtitleChanged = False
            If overSubtitle IsNot Nothing Then beforeEditToTime = overSubtitle.ToTimeOffsetted
        End If
    End Sub

    Private Sub SubtitlesBrowser_MouseMove(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseMove
        If isLeftMouseButtonDown Then
            Dim delta As Integer = (cursorPos.X - e.X)
            Dim factor As Double = 1000 / mZoomFactor

            If isCtrlDown Then factor *= 2

            If isCreatingNewSubtitle Then
                newSubtitleEndPosition = e.X
            Else
                Select Case overObject
                    Case Objects.Subtitles
                        subtitleChanged = subtitleChanged Or (delta <> 0)
                        Select Case subtitleSection
                            Case SubtitleSections.None
                                xOffset += (cursorPos.X - e.X)
                            Case SubtitleSections.Left
                                overSubtitle.FromTimeOffsetted -= TimeSpan.FromMilliseconds(delta * factor)
                                subtitleChangedAfterMouseOperation = True
                            Case SubtitleSections.Right
                                overSubtitle.ToTimeOffsetted -= TimeSpan.FromMilliseconds(delta * factor)
                                subtitleChangedAfterMouseOperation = True
                            Case SubtitleSections.Body
                                overSubtitle.FromTimeOffsetted -= TimeSpan.FromMilliseconds(delta * factor)
                                overSubtitle.ToTimeOffsetted -= TimeSpan.FromMilliseconds(delta * factor)
                                subtitleChangedAfterMouseOperation = True
                        End Select
                    Case Objects.ScrollBar
                        xOffset = subtitlesTrackLengthInSeconds * mZoomFactor * e.X / Me.Width
                End Select
            End If

            cursorPos.X = e.X
            Me.Invalidate()
        Else
            Me.Cursor = Cursors.Default
            subtitleSection = SubtitleSections.None
            overSubtitle = Nothing

            For Each cr In subtitlesRectangles
                If cr.Rectangle.Contains(e.Location) Then
                    If e.X <= cr.Rectangle.X + 4 Then
                        Me.Cursor = Cursors.PanWest
                        subtitleSection = SubtitleSections.Left
                    ElseIf e.X >= cr.Rectangle.Right - 4 Then
                        Me.Cursor = Cursors.PanEast
                        subtitleSection = SubtitleSections.Right
                    Else
                        Me.Cursor = Cursors.NoMoveHoriz
                        subtitleSection = SubtitleSections.Body
                    End If

                    overSubtitle = cr.Subtitle
                    Exit For
                End If
            Next
        End If
    End Sub

    Private Sub SubtitlesBrowser_MouseUp(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseUp
        If e.Button = Windows.Forms.MouseButtons.Left Then
            isLeftMouseButtonDown = False
            Me.Cursor = Cursors.Default

            If overObject = Objects.Subtitles AndAlso overSubtitle IsNot Nothing Then
                If mRippleEdits Then UpdateSubtitles(overSubtitle, overSubtitle.ToTimeOffsetted - beforeEditToTime)

                If mSelectedSubtitle <> overSubtitle Then
                    mSelectedSubtitle = overSubtitle
                    RaiseEvent SubtitleSelected(Me, New SubtitleSelectedEventArgs(overSubtitle, subtitleChanged))
                End If

                If subtitleChangedAfterMouseOperation Then RaiseEvent SubtitlesChanged(Me, New SubtitlesChangedEventArgs(New List(Of Subtitle)({overSubtitle})))
            End If

            If overObject <> Objects.ScrollBar Then RaiseEvent PositionChanged(Me, New PositionChangedEventArgs(overSubtitle, XToTime(e.X)))

            If isCreatingNewSubtitle Then
                isCreatingNewSubtitle = False
                RaiseEvent CreateNewSubtitle(Me, New CreateNewSubtitleEventArgs(XToTime(newSubtitleStartPosition), XToTime(newSubtitleEndPosition)))
            End If
            Me.Invalidate()
        End If
    End Sub

    Private Sub UpdateSubtitles(fromSubtitle As Subtitle, offset As TimeSpan)
        If offset <> TimeSpan.Zero Then
            Dim subtitlesToUpdate As List(Of Subtitle) = New List(Of Subtitle)
            subtitlesToUpdate.Add(fromSubtitle)

            For i As Integer = mSubtitles.IndexOf(fromSubtitle) + 1 To Subtitles.Count - 1
                mSubtitles(i).FromTimeOffsetted += offset
                mSubtitles(i).ToTimeOffsetted += offset
                subtitlesToUpdate.Add(mSubtitles(i))
            Next

            RaiseEvent SubtitlesChanged(Me, New SubtitlesChangedEventArgs(subtitlesToUpdate))
        End If
    End Sub

    Private Sub SubtitlesBrowser_MouseWheel(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseWheel
        SetZoomFactor(mZoomFactor + e.Delta * If(isCtrlDown, 10, 2) / 100)
    End Sub

    Private Sub SetZoomFactor(value As Single)
        If value < 10 Then
            mZoomFactor = 10
        Else
            mZoomFactor = value

            Dim offsetTime = XToTime(Me.Width / 2)
            xOffset = Me.Width / 2
            xOffset = TimeToX(offsetTime)
        End If

        RaiseEvent ZoomFactorChanged(Me, New EventArgs())
        Me.Invalidate()
    End Sub

    Private Sub CheckOffset()
        If mSubtitles.Count = 0 Then Exit Sub

        If xOffset < 0 Then xOffset = 0
        Dim lastX As Integer = TimeToX(mMediaDuration)
        If lastX < 0 Then xOffset = TimeToX(mMediaDuration) + xOffset
    End Sub

    Private Sub SubtitlesBrowser_Paint(sender As Object, e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint
        Dim g As Graphics = e.Graphics
        Dim r As Rectangle = Me.DisplayRectangle
        r.Inflate(-1, -1)

        Dim cr As Rectangle
        Dim h As Integer = r.Height - 8
        Dim h2 As Integer = h / 2
        Dim _subtitlesForeColor As Brush = New SolidBrush(Me.ForeColor)

        g.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias
        g.Clear(Me.BackColor)

        Using _gridColor = New Pen(mGridColor, 2)
            g.DrawLine(_gridColor, 0, h2, r.Width, h2)
        End Using
        Using _gridColor = New Pen(mGridColor)
            g.DrawLine(_gridColor, 0, h2 - h2 \ 2, r.Width, h2 - h2 \ 2)
            g.DrawLine(_gridColor, 0, h2 + h2 \ 2, r.Width, h2 + h2 \ 2)
        End Using

        If mSubtitles IsNot Nothing AndAlso mSubtitles.Count > 0 AndAlso mMediaDuration > TimeSpan.Zero Then
            CheckOffset()

            Dim selectedPoints = DrawPeaks(g, r, h, h2)
            Dim _subtitlesBackColor As Brush
            Dim _borderColor As Pen

            Dim x1 As Integer
            Dim x2 As Integer

            subtitlesRectangles.Clear()
            For Each c In mSubtitles
                x1 = TimeToX(c.FromTimeOffsetted)
                x2 = TimeToX(c.ToTimeOffsetted)
                If x2 <= 0 OrElse x1 >= r.Width Then Continue For

                cr = New Rectangle(x1, 2, x2 - x1, r.Height - 11)

                If c = mSelectedSubtitle Then
                    _subtitlesBackColor = New SolidBrush(mSubtitleSelectedBackColor)
                    _borderColor = New Pen(Color.FromArgb(200, Color.Gray))
                Else
                    _subtitlesBackColor = New SolidBrush(mSubtitleBackColor)
                    _borderColor = New Pen(Color.FromArgb(200, Color.DarkGray))
                End If

                _borderColor.DashStyle = Drawing2D.DashStyle.Dot

                g.FillRectangle(_subtitlesBackColor, cr)
                g.DrawString(c.TextOffsetted, Me.Font, _subtitlesForeColor, cr)
                g.DrawRectangle(_borderColor, cr)

                subtitlesRectangles.Add(New SubtitleRectangle(c, cr))

                _borderColor.Dispose()
                _subtitlesBackColor.Dispose()
            Next

            If selectedPoints.Length > 0 Then
                Using _waveFormSelectedColor = New Pen(mWaveFormSelectedColor)
                    g.DrawLines(_waveFormSelectedColor, selectedPoints)
                End Using
            End If

            x1 = TimeToX(mMediaDuration) + xOffset
            x2 = TimeToX(mPosition)

            Dim w As Integer = Math.Max(16, CInt(Me.Width / (x1 / Me.Width)))

            g.FillRectangle(Brushes.Gray, r.X, r.Height - 7, r.Width, 8)
            g.FillRectangle(Brushes.LightGray,
                                CInt((Me.Width - w) * xOffset / x1),
                                r.Height - 7,
                                w,
                                8)

            Using _positionMarkerColor = New Pen(mPositionMarkerColor, 3)
                g.DrawLine(_positionMarkerColor, x2 - 1, r.Height - 7, x2 - 1, 0)
            End Using
        End If

        DrawGrid(g, r)

        If isCreatingNewSubtitle Then
            cr = New Rectangle(newSubtitleStartPosition, 2, newSubtitleEndPosition - newSubtitleStartPosition, r.Height - 11)
            Using _borderColor = New Pen(Color.FromArgb(128, mGridColor), 3)
                g.DrawRectangle(_borderColor, cr)
            End Using
            Using _backColor = New SolidBrush(Color.FromArgb(128, mSubtitleSelectedBackColor))
                g.FillRectangle(_backColor, cr)
            End Using
            g.DrawString(My.Resources.NewSubtitleText, Me.Font, _subtitlesForeColor, cr)
        End If

        _subtitlesForeColor.Dispose()
    End Sub

    Private Function DrawPeaks(g As Graphics, r As Rectangle, h As Integer, h2 As Integer) As Point()
        Dim range = (maxPeak - minPeak) / 2
        Dim selectedPoints As List(Of Point) = New List(Of Point)

        If peaks.Count > 0 AndAlso range > 0 Then
            Dim pts As List(Of Point) = New List(Of Point)
            Dim i As Integer = 0

            Dim xs1 As Integer = -1
            Dim xs2 As Integer = -1

            If mSelectedSubtitle IsNot Nothing Then
                xs1 = TimeToX(mSelectedSubtitle.FromTimeOffsetted)
                xs2 = TimeToX(mSelectedSubtitle.ToTimeOffsetted)
            End If

            Dim x1 As Single = 0
            Dim x2 As Single = 0
            Dim y1 As Single = h2
            Dim y2 As Single = 0

            Using _waveFormColor = New Pen(mWaveFormColor)
                Using _waveFormSelectedColor = New Pen(mWaveFormSelectedColor)
                    Do While x2 < r.Width AndAlso i < peaks.Count
                        x2 = i * mZoomFactor / peaksInterval - xOffset
                        If x2 > 0 Then
                            y2 = h2 - peaks(i) / range * h - 8

                            If x1 >= xs1 AndAlso x2 <= xs2 Then
                                selectedPoints.Add(New Point(x1, y1))
                                selectedPoints.Add(New Point(x2, y2))
                            Else
                                g.DrawLine(_waveFormColor, x1, y1, x2, y2)
                            End If
                        End If

                        x1 = x2
                        y1 = y2

                        i += 1
                    Loop
                End Using
            End Using
        End If

        Return selectedPoints.ToArray()
    End Function

    Private Sub DrawGrid(g As Graphics, r As Rectangle)
        Dim t = XToTime(0)
        Dim timeInterval = TimeSpan.FromSeconds(0)
        Dim x As Integer

        Dim nextTime As TimeSpan
        Dim pixelsSeparation As Integer = 0
        Dim labelWidth = 0
        Do Until pixelsSeparation > labelWidth
            timeInterval += TimeSpan.FromSeconds(1)
            nextTime = t + timeInterval
            pixelsSeparation = TimeToX(nextTime) - TimeToX(t)
            labelWidth = g.MeasureString("00:00:00", mGridTimeFont, 0).Width + 20
        Loop

        Using _gridColor = New Pen(mGridColor)
            Using _gridTimeColor = New SolidBrush(mGridTimeColor)
                Do
                    x = TimeToX(t)
                    g.DrawLine(_gridColor, x, 0, x, r.Height)
                    g.DrawString(String.Format("{0:00}:{1:00}:{2:00}", t.Hours, t.Minutes, t.Seconds), mGridTimeFont, _gridTimeColor, x, r.Height - 24)
                    t += timeInterval
                Loop Until x >= r.Width
            End Using
        End Using
    End Sub

    Private Sub DrawBackground(g As Graphics, r As Rectangle)
        Using _gridColor = New Pen(mGridColor)
            For i As Integer = 0 To r.Width Step 10
                g.DrawLine(_gridColor, i, 0, i, r.Height)
                g.DrawLine(_gridColor, 0, i, r.Width, i)
            Next
        End Using
    End Sub
End Class
