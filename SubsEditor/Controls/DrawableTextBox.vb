Public Class DrawableTextBox
    Inherits NativeWindow

    Private Const WM_PAINT = 15

    Private textBox As TextBox
    Private bitmap As Bitmap
    Private textBoxGraphics As Graphics
    Private bufferGraphics As Graphics

    Public Class PaintEventArgs
        Private mTextBox As TextBox
        Private mBitmap As Bitmap
        Private mTextBoxGraphics As Graphics
        Private mBufferGraphics As Graphics

        Public Sub New(textBox As TextBox, bitmap As Bitmap, textBoxGraphics As Graphics, bufferGraphics As Graphics)
            mTextBox = textBox
            mBitmap = bitmap
            mTextBoxGraphics = textBoxGraphics
            mBufferGraphics = bufferGraphics
        End Sub

        Public ReadOnly Property TextBox As TextBox
            Get
                Return mTextBox
            End Get
        End Property

        Public ReadOnly Property Bitmap As Bitmap
            Get
                Return mBitmap
            End Get
        End Property

        Public ReadOnly Property TextBoxGraphics As Graphics
            Get
                Return mTextBoxGraphics
            End Get
        End Property

        Public ReadOnly Property BufferGraphics As Graphics
            Get
                Return mBufferGraphics
            End Get
        End Property
    End Class

    Public Event Paint(sender As Object, e As PaintEventArgs)

    Public Sub New(textBox As TextBox)
        Me.textBox = textBox
        Me.bitmap = New Bitmap(textBox.Width, textBox.Height)
        Me.bufferGraphics = Graphics.FromImage(Me.bitmap)
        Me.bufferGraphics.Clip = New Region(textBox.ClientRectangle)
        Me.textBoxGraphics = Graphics.FromHwnd(textBox.Handle)
        Me.AssignHandle(textBox.Handle)
    End Sub

    Protected Overrides Sub WndProc(ByRef m As System.Windows.Forms.Message)
        Select Case m.Msg
            Case WM_PAINT
                textBox.Invalidate()
                MyBase.WndProc(m)
                RaiseEvent Paint(Me, New PaintEventArgs(textBox, bitmap, textBoxGraphics, bufferGraphics))
                Exit Sub
        End Select
        MyBase.WndProc(m)
    End Sub

    Public Sub DrawWave(r As Rectangle)
        Dim pen = Pens.Red
        If r.Right - r.X > 4 Then
            Dim pl = New ArrayList()
            For i = r.X To (r.Right - 2) Step 4
                pl.Add(New Point(i, r.Bottom))
                pl.Add(New Point(i + 2, r.Bottom + 2))
            Next
            Dim p() = CType(pl.ToArray(GetType(Point)), Point())
            bufferGraphics.DrawLines(pen, p)
        Else
            'bufferGraphics.DrawLine(pen, startPoint, endPoint)
        End If
    End Sub
End Class
