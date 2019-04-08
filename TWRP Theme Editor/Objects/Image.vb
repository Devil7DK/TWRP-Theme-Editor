Namespace Objects
    Public Class Image : Inherits ItemBase

#Region "Variable"
        Private Image As Drawing.Image
#End Region

#Region "Properties"
        Property FileName As String = ""
        Property RetainAspect As Boolean = False

        ReadOnly Property GetImage As Drawing.Image
            Get
                If Image Is Nothing Then
                    If My.Computer.FileSystem.FileExists(FileName) Then
                        Me.Image = Drawing.Image.FromFile(FileName)
                        Return Image
                    Else
                        Return New Drawing.Bitmap(1, 1)
                    End If
                Else
                    Return Me.Image
                End If
            End Get
        End Property
#End Region

#Region "Constructor"
        Sub New(ByVal Name As String, ByVal FileName As String, ByVal RetainAspect As Boolean)
            Me.Name = Name
            Me.FileName = FileName
            Me.RetainAspect = RetainAspect
        End Sub
#End Region

    End Class
End Namespace