Public Class WavReader
    Implements IDisposable

    Private mFileName As String
    Private mHeader As WavHeader
    Private stream As IO.FileStream

    Private Delegate Function ReadData() As Integer

    Public Class WavHeader
        Private _chunkID(4 - 1) As Byte
        Private _chunkSize(4 - 1) As Byte
        Private _format(4 - 1) As Byte

        Private _subchunk1ID(4 - 1) As Byte
        Private _subchunk1Size(4 - 1) As Byte
        Private _audioFormat(2 - 1) As Byte
        Private _numChannels(2 - 1) As Byte
        Private _sampleRate(4 - 1) As Byte
        Private _byteRate(4 - 1) As Byte
        Private _blockAlign(2 - 1) As Byte
        Private _bitsPerSample(2 - 1) As Byte

        Private _subchunk2ID(4 - 1) As Byte
        Private _subchunk2Size(4 - 1) As Byte

        Private mDataStart As Long

        Public Sub New(stream As IO.FileStream)
            stream.Seek(0, IO.SeekOrigin.Begin)
            stream.Read(_chunkID, 0, _chunkID.Length)
            stream.Read(_chunkSize, 0, _chunkSize.Length)
            stream.Read(_format, 0, _format.Length)

            stream.Read(_subchunk1ID, 0, _subchunk1ID.Length)
            stream.Read(_subchunk1Size, 0, _subchunk1Size.Length)
            stream.Read(_audioFormat, 0, _audioFormat.Length)
            stream.Read(_numChannels, 0, _numChannels.Length)
            stream.Read(_sampleRate, 0, _sampleRate.Length)
            stream.Read(_byteRate, 0, _byteRate.Length)
            stream.Read(_blockAlign, 0, _blockAlign.Length)
            stream.Read(_bitsPerSample, 0, _bitsPerSample.Length)

            stream.Read(_subchunk2ID, 0, _subchunk2ID.Length)
            stream.Read(_subchunk2Size, 0, _subchunk2Size.Length)

            mDataStart = stream.Position
        End Sub

        Public ReadOnly Property Channels As Integer
            Get
                Return BitConverter.ToInt16(_numChannels, 0)
            End Get
        End Property

        Public ReadOnly Property SampleRate As Integer
            Get
                Return BitConverter.ToInt32(_sampleRate, 0)
            End Get
        End Property

        Public ReadOnly Property BitDepth As Integer
            Get
                Return BitConverter.ToInt16(_bitsPerSample, 0)
            End Get
        End Property

        Public ReadOnly Property BytesPerSecond As Integer
            Get
                Return SampleRate * (BitDepth / 8) * Channels
            End Get
        End Property

        Public ReadOnly Property DataStart As Long
            Get
                Return mDataStart
            End Get
        End Property
    End Class

    Public Sub New(fileName As String)
        mFileName = fileName
        Initialize()
    End Sub

    Public Sub New(stream As IO.FileStream)
        Me.stream = stream
        mHeader = New WavHeader(stream)
    End Sub

    Public ReadOnly Property FileName As String
        Get
            Return mFileName
        End Get
    End Property

    Public ReadOnly Property Header As WavHeader
        Get
            Return mHeader
        End Get
    End Property

    Public Function SavePeaks(fileName As String) As Boolean
        Try
            Dim readSamples As ReadData = GetDataReader()

            Dim sampleRate = 126
            While Not (mHeader.SampleRate Mod sampleRate = 0) AndAlso sampleRate < 1000
                sampleRate += 1
            End While

            Dim bytesPerSecond = Header.BytesPerSecond
            Dim channels = mHeader.Channels
            Dim interval As Integer = (bytesPerSecond / sampleRate)
            Dim peaks As List(Of Integer) = New List(Of Integer)

            If interval = 0 Then Return False

            peaks.Add(mHeader.SampleRate * channels * If(mHeader.BitDepth = 8, 1, 2) / interval)

            stream.Position = Header.DataStart

            Dim peakValue As Integer = 0
            Do
                peakValue = 0
                For c = 1 To channels
                    Dim k As Integer = readSamples()
                    peakValue += k
                Next
                peaks.Add(peakValue / channels)
                stream.Position += (interval - channels - If(mHeader.BitDepth = 8, 0, 2))
            Loop While stream.Position < stream.Length

            Dim fs = New IO.FileStream(fileName, IO.FileMode.Create, IO.FileAccess.Write)
            For Each peak In peaks
                Dim b() As Byte = BitConverter.GetBytes(CType(peak, Integer))
                fs.Write(b, 0, b.Length - 2)
            Next
            fs.Close()

            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Private Sub Initialize()
        If IO.File.Exists(mFileName) Then
            Try
                stream = New IO.FileStream(mFileName, IO.FileMode.Open, IO.FileAccess.Read, IO.FileShare.Read)
                mHeader = New WavHeader(stream)
            Catch ex As Exception
            End Try
        End If
    End Sub

    Private Function GetDataReader() As ReadData
        Select Case mHeader.BitDepth
            Case 8 : Return AddressOf ReadByte
            Case 16 : Return AddressOf ReadWord
            Case Else : Return Nothing
        End Select
    End Function

    Private Function ReadByte() As Integer
        Return stream.ReadByte()
    End Function

    Private Function ReadWord() As Integer
        Dim b(2 - 1) As Byte
        stream.Read(b, 0, 2)
        Return BitConverter.ToInt16(b, 0)
    End Function

#Region "IDisposable Support"
    Private disposedValue As Boolean ' To detect redundant calls

    ' IDisposable
    Protected Overridable Sub Dispose(disposing As Boolean)
        If Not Me.disposedValue Then
            If disposing Then
                ' TODO: dispose managed state (managed objects).
            End If

            ' TODO: free unmanaged resources (unmanaged objects) and override Finalize() below.
            ' TODO: set large fields to null.
            If stream IsNot Nothing Then
                stream.Close()
                stream.Dispose()
            End If
        End If
        Me.disposedValue = True
    End Sub

    ' TODO: override Finalize() only if Dispose(disposing As Boolean) above has code to free unmanaged resources.
    'Protected Overrides Sub Finalize()
    '    ' Do not change this code.  Put cleanup code in Dispose(disposing As Boolean) above.
    '    Dispose(False)
    '    MyBase.Finalize()
    'End Sub

    ' This code added by Visual Basic to correctly implement the disposable pattern.
    Public Sub Dispose() Implements IDisposable.Dispose
        ' Do not change this code.  Put cleanup code in Dispose(disposing As Boolean) above.
        Dispose(True)
        GC.SuppressFinalize(Me)
    End Sub
#End Region
End Class
