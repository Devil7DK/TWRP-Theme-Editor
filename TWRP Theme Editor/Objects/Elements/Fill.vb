Namespace Objects.Elements
    Public Class Fill : Inherits ElementBase

#Region "Properties"
        Property Color As String
#End Region

#Region "Constructor"
        Sub New(ByVal Placement As Placement, ByVal Conditions As List(Of Condition), ByVal Actions As List(Of Objects.Action), ByVal Color As String)
            Me.Placement = Placement
            Me.Conditions = Conditions
            Me.Actions = Actions
            Me.Color = Color
        End Sub
#End Region

    End Class
End Namespace