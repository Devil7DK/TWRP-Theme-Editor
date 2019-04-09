Namespace Objects.Elements
    Public Class Action

#Region "Properties"
        Property Key As String
        Property Actions As New List(Of Objects.Action)
#End Region

#Region "Constructor"
        Sub New(ByVal Key As String, ByVal Actions As List(Of Objects.Action))
            Me.Key = Key
            Me.Actions = Actions
        End Sub
#End Region

    End Class
End Namespace