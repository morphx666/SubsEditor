Imports System.Collections.ObjectModel
Imports <xmlns:d="http://openoffice.org/extensions/description/2006">

Public Class Dictionary
    Private mDirectory As String
    Private mLanguage As String
    Private mVersion As String
    Private mID As String
    Private mIsDefault As Boolean
    Private mLocales As List(Of String) = New List(Of String)
    Private mLocale As String

    Private localesSubDirectory As String

    Public Sub New(directory As String)
        mDirectory = directory

        Dim d = New IO.DirectoryInfo(mDirectory)
        If d.Exists Then
            Dim fileName As String = IO.Path.Combine(mDirectory, "description.xml")
            If IO.File.Exists(fileName) Then
                Dim doc = XDocument.Load(fileName)
                mLanguage = doc.<d:description>.<d:display-name>.<d:name>.Value
                mVersion = doc.<d:description>.<d:version>.@value
            Else
                ' ???
                mLanguage = (New IO.DirectoryInfo(mDirectory)).Name
                mVersion = "0.0"
            End If

            Dim tokens() = mDirectory.Split("\")
            mID = tokens(tokens.Length - 1)

            FindLocales(d)
        Else
            Throw New Exception("Dictionary Not Found")
        End If
    End Sub

    Private Sub FindLocales(directory As IO.DirectoryInfo)
        Dim files = directory.GetFiles("*.aff")
        If files.Count > 0 Then
            localesSubDirectory = directory.FullName
            mLocales = (From f In directory.GetFiles("*.aff") Select f.Name.Replace(f.Extension, "")).ToList()
        Else
            Dim dirs = directory.GetDirectories()
            For Each d In dirs
                FindLocales(d)
                If localesSubDirectory <> "" Then Exit For
            Next
        End If
    End Sub

    Public Function GetSpellingEngine() As NHunspell.Hunspell
        Return New NHunspell.Hunspell(GetAFFFile(), GetDICFile())
    End Function

    Private Function GetAFFFile() As String
        Return IO.Path.Combine(localesSubDirectory, mLocale + ".aff")
    End Function

    Private Function GetDICFile() As String
        Return IO.Path.Combine(localesSubDirectory, mLocale + ".dic")
    End Function

    Public ReadOnly Property Locales As List(Of String)
        Get
            Return mLocales
        End Get
    End Property

    Public Property Locale As String
        Get
            Return mLocale
        End Get
        Set(value As String)
            mLocale = value
        End Set
    End Property

    Public ReadOnly Property ID As String
        Get
            Return mID
        End Get
    End Property

    Public ReadOnly Property Directory As String
        Get
            Return mDirectory
        End Get
    End Property

    Public ReadOnly Property Language As String
        Get
            Return mLanguage
        End Get
    End Property

    Public ReadOnly Property Version As String
        Get
            Return mVersion
        End Get
    End Property

    Public Property IsDefault As Boolean
        Get
            Return mIsDefault
        End Get
        Set(value As Boolean)
            mIsDefault = value
        End Set
    End Property

    Public Overrides Function ToString() As String
        Return mLanguage
    End Function

    Public Shared ReadOnly Property DictionariesFolder As String
        Get
            Return IO.Path.Combine(My.Application.Info.DirectoryPath, "Dictionaries")
        End Get
    End Property
End Class

Public Class DictionariesList
    Inherits ObservableCollection(Of Dictionary)

    Public Event DefaultDictionaryChanged(sender As Object, e As EventArgs)

    Public Sub SetDefault(id As String, locale As String)
        MyBase.Items.ToList().ForEach(Sub(d)
                                          d.IsDefault = (d.ID = id)
                                          If d.IsDefault Then d.Locale = locale
                                          RaiseEvent DefaultDictionaryChanged(Me, New EventArgs())
                                      End Sub)
    End Sub

    Public Function GetSpellingEngine() As NHunspell.Hunspell
        Dim defDict = GetDefaultDictionary()
        If defDict Is Nothing Then
            Return Nothing
        Else
            Return defDict.GetSpellingEngine()
        End If
    End Function

    Public Function GetDefaultDictionary() As Dictionary
        Dim dd = From d In MyBase.Items Select d Where d.IsDefault
        If dd.Count > 0 Then
            Return dd.First()
        Else
            Return Nothing
        End If
    End Function
End Class