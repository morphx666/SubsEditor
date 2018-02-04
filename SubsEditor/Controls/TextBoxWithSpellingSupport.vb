Public Class TextBoxWithSpellingSupport
    Inherits System.Windows.Forms.TextBox

    Private drawableTextBox As DrawableTextBox
    Private lineHeight As Integer

    Private mMisspelledWords As List(Of Word) = New List(Of Word)
    Private mSpellCheckerEngine As NHunspell.Hunspell
    Private mDictionaries As DictionariesList

    Private overMisspelledWord As Word = Nothing
    Private mouseClickPosition As Point

    Public Class DictionaryChangedEventArgs
        Private mDictionary As Dictionary
        Private mLocale As String

        Public Sub New(dictionary As Dictionary, locale As String)
            mDictionary = dictionary
            mLocale = locale
        End Sub

        Public ReadOnly Property Dictionary As Dictionary
            Get
                Return mDictionary
            End Get
        End Property

        Public ReadOnly Property Locale As String
            Get
                Return mLocale
            End Get
        End Property
    End Class

    Public Event DictionaryChanged(sender As Object, e As DictionaryChangedEventArgs)

    Public Class Word
        Private mWord As String
        Private mStartIndex As Integer
        Private mEndIndex As Integer
        Private mBounds As Rectangle

        Public Sub New(word As String, startIndex As Integer, endIndex As Integer, startPoint As Point, endPoint As Point)
            mWord = word
            mStartIndex = startIndex
            mEndIndex = endIndex
            mBounds = New Rectangle(startPoint.X, startPoint.Y, endPoint.X - startPoint.X, endPoint.Y - startPoint.Y)
        End Sub

        Public ReadOnly Property Word As String
            Get
                Return mWord
            End Get
        End Property

        Public ReadOnly Property StartIndex As Integer
            Get
                Return mStartIndex
            End Get
        End Property

        Public ReadOnly Property EndIndex As Integer
            Get
                Return mEndIndex
            End Get
        End Property

        Public ReadOnly Property Bounds As Rectangle
            Get
                Return mBounds
            End Get
        End Property

        Public Shared Operator =(w1 As Word, w2 As Word)
            If w1 Is Nothing AndAlso w2 Is Nothing Then Return True
            If w1 Is Nothing AndAlso w2 IsNot Nothing Then Return False
            If w1 IsNot Nothing AndAlso w2 Is Nothing Then Return False

            Return w1.Word = w2.Word AndAlso w1.Bounds = w2.Bounds
        End Operator

        Public Shared Operator <>(w1 As Word, w2 As Word)
            Return Not (w1 = w2)
        End Operator
    End Class

    Protected Overrides Sub CreateHandle()
        MyBase.CreateHandle()

        SetLineHeight()

        drawableTextBox = New DrawableTextBox(Me)
        AddHandler drawableTextBox.Paint, AddressOf DrawOnTextBox
        AddHandler Me.TextChanged, Sub() Me.Invalidate()
        AddHandler Me.FontChanged, Sub() Me.Invoke(New MethodInvoker(AddressOf SetLineHeight))

        Me.ContextMenu = New ContextMenu()
        AddHandler Me.ContextMenu.Popup, AddressOf ModifyContextMenu

        CreateContextMenus()
    End Sub

    Public Property Dictionaries As DictionariesList
        Get
            Return mDictionaries
        End Get
        Set(value As DictionariesList)
            mDictionaries = value

            If mDictionaries IsNot Nothing Then
                AddHandler mDictionaries.CollectionChanged, Sub() CreateContextMenus()
                AddHandler mDictionaries.DefaultDictionaryChanged, Sub() CreateContextMenus()
            End If
        End Set
    End Property

    Private Sub CreateContextMenus()
        Me.ContextMenu.MenuItems.Clear()

        With Me.ContextMenu.MenuItems.Add("-", AddressOf HandleContextMenu)
            .Name = "miSep01"
            .Visible = False
        End With

        If Dictionaries IsNot Nothing AndAlso Dictionaries.Count > 0 Then
            Dim defDict = mDictionaries.GetDefaultDictionary()
            Dim defDictStr = If(defDict Is Nothing, "", String.Format("{0} ({1})", defDict.Language, defDict.Locale))

            With Me.ContextMenu.MenuItems.Add("Language")
                .Name = "miLanguage"
                For Each d In Dictionaries
                    For Each l In d.Locales
                        Dim dictionary = d
                        Dim locale = l
                        Dim text = String.Format("{0} ({1})", d.Language, l)
                        Dim enabled = text = defDictStr

                        .MenuItems.Add(text, Sub() RaiseEvent DictionaryChanged(Me, New DictionaryChangedEventArgs(dictionary, locale))).Checked = enabled
                    Next
                Next
            End With
            Me.ContextMenu.MenuItems.Add("-", AddressOf HandleContextMenu).Name = "miSep02"
        End If

        Me.ContextMenu.MenuItems.Add("Cut", AddressOf HandleContextMenu).Name = "miCut"
        Me.ContextMenu.MenuItems.Add("Copy", AddressOf HandleContextMenu).Name = "miCopy"
        Me.ContextMenu.MenuItems.Add("Paste", AddressOf HandleContextMenu).Name = "miPaste"
        Me.ContextMenu.MenuItems.Add("Delete", AddressOf HandleContextMenu).Name = "miDelete"
        Me.ContextMenu.MenuItems.Add("-", AddressOf HandleContextMenu).Name = "miSep03"
        Me.ContextMenu.MenuItems.Add("Select All", AddressOf HandleContextMenu).Name = "miSelectAll"
    End Sub

    Public Property SpellCheckerEngine As NHunspell.Hunspell
        Get
            Return mSpellCheckerEngine
        End Get
        Set(value As NHunspell.Hunspell)
            mSpellCheckerEngine = value
            Me.Invalidate()
        End Set
    End Property

    Public ReadOnly Property MisspelledWords As List(Of Word)
        Get
            Return mMisspelledWords
        End Get
    End Property

    Public Function Words() As List(Of Word)
        Return TextBoxWithSpellingSupport.GetWords(Me.Text, Me, lineHeight)
    End Function

    Public Shared Function GetWords(value As String, Optional tb As TextBoxWithSpellingSupport = Nothing, Optional lineHeight As Integer = 0) As List(Of Word)
        Dim wordsList = New List(Of Word)

        Dim AddWord = Sub(newWord As String, index As Integer)
                          If tb Is Nothing Then
                              wordsList.Add(New Word(newWord, 0, 0, Point.Empty, Point.Empty))
                          Else
                              Dim sp = tb.GetPositionFromCharIndex(index)
                              Dim ep = tb.GetPositionFromCharIndex(index + newWord.Length)

                              sp.X += 1
                              ep.X += 1
                              ep.Y += lineHeight
                              wordsList.Add(New Word(newWord, index, index + newWord.Length, sp, ep))
                          End If
                      End Sub

        Dim word As String = ""
        Dim startIndex As Integer = 0
        Dim c As Char
        For i As Integer = 0 To value.Length - 1
            c = value(i)
            If Char.IsLetterOrDigit(c) OrElse c = "'" OrElse (c = "-" AndAlso word <> "") Then
                word += c
            ElseIf word <> "" Then
                AddWord(word, startIndex)
                word = ""
                startIndex = i + 1
            Else
                startIndex += 1
            End If
        Next

        If word <> "" Then AddWord(word, startIndex)

        Return wordsList
    End Function

    Private Sub SetLineHeight()
        With Me
            Dim isMultiline = .Multiline
            .Multiline = True
            .Text = "a" + vbCrLf + "b"
            lineHeight = .GetPositionFromCharIndex(3).Y - .GetPositionFromCharIndex(0).Y
            .Text = ""
            .Multiline = isMultiline
        End With
    End Sub

    Private Sub DrawOnTextBox(sender As Object, e As DrawableTextBox.PaintEventArgs)
        If mSpellCheckerEngine IsNot Nothing AndAlso e.TextBox.Text <> "" Then
            Dim drawableTextBox = CType(sender, DrawableTextBox)

            e.BufferGraphics.Clear(Color.Transparent)

            mMisspelledWords.Clear()
            Dim words = Me.Words()
            For Each word In words
                If Not mSpellCheckerEngine.Spell(word.Word) Then
                    drawableTextBox.DrawWave(word.Bounds)
                    mMisspelledWords.Add(word)
                End If
            Next

            'If overMisspelledWord IsNot Nothing Then
            '    e.BufferGraphics.DrawRectangle(Pens.Red, overMisspelledWord.Bounds.X, overMisspelledWord.Bounds.Bottom + 2, 16, 4)
            'End If

            e.TextBoxGraphics.DrawImageUnscaled(e.Bitmap, 0, 0)
        End If
    End Sub

    Private Sub ModifyContextMenu()
        Do
            Dim mi = Me.ContextMenu.MenuItems(0)
            If mi.Name.StartsWith("miMSW") Then
                Me.ContextMenu.MenuItems.Remove(mi)
            Else
                Exit Do
            End If
        Loop
        Me.ContextMenu.MenuItems("miSep01").Visible = False

        Dim mouseRect = New Rectangle(mouseClickPosition.X, mouseClickPosition.Y, 1, 1)
        For Each misspelledWord In mMisspelledWords
            If misspelledWord.Bounds.IntersectsWith(mouseRect) Then
                overMisspelledWord = misspelledWord

                Dim i As Integer = 0
                For Each suggestion In mSpellCheckerEngine.Suggest(misspelledWord.Word)
                    With Me.ContextMenu.MenuItems.Add(suggestion, AddressOf HandleContextMenu)
                        .Name = "miMSW" + i.ToString()
                        .Index = i
                    End With
                    i += 1
                Next

                Me.ContextMenu.MenuItems("miSep01").Visible = True
                Exit For
            End If
        Next

        Me.ContextMenu.MenuItems("miCut").Enabled = Me.SelectedText <> ""
        Me.ContextMenu.MenuItems("miCopy").Enabled = Me.SelectedText <> ""
        Me.ContextMenu.MenuItems("miPaste").Enabled = Clipboard.ContainsText
        Me.ContextMenu.MenuItems("miDelete").Enabled = Me.SelectedText <> ""
        Me.ContextMenu.MenuItems("miSelectAll").Enabled = Me.SelectedText <> Me.Text
    End Sub

    Private Sub HandleContextMenu(sender As Object, e As EventArgs)
        Dim mi = CType(sender, MenuItem)

        If mi.Name.StartsWith("miMSW") Then
            Me.SelectionStart = overMisspelledWord.StartIndex
            Me.SelectionLength = overMisspelledWord.EndIndex - overMisspelledWord.StartIndex
            Me.SelectedText = mi.Text
            overMisspelledWord = Nothing
        Else
            Select Case mi.Name
                Case "miCut"
                    Clipboard.SetText(Me.SelectedText)
                    Me.SelectedText = ""
                Case "miCopy"
                    Clipboard.SetText(Me.SelectedText)
                Case "miPaste"
                    If Me.SelectedText = "" Then
                        Me.Text = Me.Text.Substring(0, Me.SelectionStart) + Clipboard.GetText() + Me.Text.Substring(Me.SelectionStart)
                    Else
                        Me.SelectedText = Clipboard.GetText()
                    End If
                Case "miDelete"
                    Me.SelectedText = ""
                Case "miSelectAll"
                    Me.SelectionStart = 0
                    Me.SelectionLength = Me.Text.Length
            End Select
        End If
    End Sub

    Private Sub TextBoxWithSpellingSupport_MouseDown(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseDown
        CType(sender, TextBoxWithSpellingSupport).Focus()
        mouseClickPosition = e.Location
    End Sub
End Class
