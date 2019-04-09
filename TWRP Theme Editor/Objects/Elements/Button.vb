Namespace Objects.Elements
    Public Class Button : Inherits ElementBase

#Region "Properties"
        Property Image As String
        Property HighlightedImage As String
#End Region

#Region "Constructor"
        Sub New(ByVal Placement As Placement, ByVal Conditions As List(Of Condition), ByVal Actions As List(Of Objects.Action), ByVal Image As String, ByVal HighlightedImage As String)
            Me.Placement = Placement
            Me.Conditions = Conditions
            Me.Actions = Actions
            Me.Image = Image
            Me.HighlightedImage = HighlightedImage
        End Sub
#End Region

    End Class
End Namespace