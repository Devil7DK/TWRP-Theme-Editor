Namespace Objects.Elements
    Public Class Image : Inherits ElementBase

#Region "Properties"
        Property Image As String
#End Region

#Region "Constructor"
        Sub New(ByVal Placement As Placement, ByVal Conditions As List(Of Condition), ByVal Actions As List(Of Objects.Action), ByVal Image As String)
            Me.Placement = Placement
            Me.Conditions = Conditions
            Me.Actions = Actions
            Me.Image = Image
        End Sub
#End Region

    End Class
End Namespace