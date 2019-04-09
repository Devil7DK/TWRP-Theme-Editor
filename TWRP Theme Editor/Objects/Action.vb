Namespace Objects
    Public Class Action

#Region "Properties"
        Property [Function] As String
        Property Value As String
#End Region

#Region "Constructor"
        Sub New(ByVal [Function] As String, ByVal Value As String)
            Me.Function = [Function]
            Me.Value = Value
        End Sub
#End Region

    End Class
End Namespace