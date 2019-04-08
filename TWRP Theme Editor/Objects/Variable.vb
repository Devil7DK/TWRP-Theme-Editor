Namespace Objects
    Public Class Variable : Inherits ItemBase

#Region "Properties"
        Property Value As String = ""

        Property Persist As Boolean = False
#End Region

#Region "Constructor"
        Sub New(ByVal Name As String, ByVal Value As String, ByVal Persist As Boolean)
            Me.Name = Name
            Me.Value = Value
            Me.Persist = Persist
        End Sub
#End Region

    End Class
End Namespace