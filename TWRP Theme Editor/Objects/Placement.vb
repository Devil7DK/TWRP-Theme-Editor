Namespace Objects
    Public Class Placement

#Region "Properties"
        Property X As String
        Property Y As String
        Property Width As String
        Property Height As String
        Property Placement As Integer = -1
#End Region

#Region "Constructor"
        Sub New(ByVal X As String, ByVal Y As String, ByVal Width As String, ByVal Height As String, ByVal Placement As String)
            Me.X = X
            Me.Y = Y
            Me.Width = Width
            Me.Height = Height

            Integer.TryParse(Placement, Me.Placement)
        End Sub
#End Region

    End Class
End Namespace