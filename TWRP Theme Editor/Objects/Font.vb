Namespace Objects
    Public Class Font : Inherits ItemBase

#Region "Variables"
        Private Font As Drawing.Font = Nothing
#End Region

#Region "Properties"
        Property FileName As String = ""
        Property Size As Double = 12

        ReadOnly Property GetFont As Drawing.Font
            Get
                If Me.Font Is Nothing Then
                    If My.Computer.FileSystem.FileExists(FileName) Then
                        Dim privateFonts As New Text.PrivateFontCollection()
                        privateFonts.AddFontFile(FileName)
                        Me.Font = New Drawing.Font(privateFonts.Families(0), Size)
                        Return Font
                    Else
                        Return New Drawing.Font("Arial", Size)
                    End If
                Else
                    Return Me.Font
                End If
            End Get
        End Property
#End Region

#Region "Constructor"
        Sub New(ByVal Name As String, ByVal FileName As String, ByVal Size As Double)
            Me.Name = Name
            Me.FileName = FileName
            Me.Size = Size
        End Sub
#End Region

    End Class
End Namespace