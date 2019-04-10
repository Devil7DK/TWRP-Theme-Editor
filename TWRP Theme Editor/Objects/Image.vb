Namespace Objects
    Public Class Image : Inherits ItemBase

#Region "Variable"
        Private Image As Drawing.Image
#End Region

#Region "Properties"
        Property FileName As String = ""
        Property RetainAspect As Boolean = False
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