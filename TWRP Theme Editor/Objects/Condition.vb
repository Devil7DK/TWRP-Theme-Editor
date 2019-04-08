Namespace Objects
    Public Class Condition

#Region "Property"
        Property Variable1 As String
        Property Variable2 As String
#End Region

#Region "Constructor"
        Sub New(ByVal Variable1 As String)
            Me.Variable1 = Variable1
            Me.Variable2 = String.Empty
        End Sub

        Sub New(ByVal Variable1 As String, ByVal Variable2 As String)
            Me.Variable1 = Variable1
            Me.Variable2 = Variable2
        End Sub
#End Region

#Region "Functions"
        Function Validate(ByVal Variables As Dictionary(Of String, String)) As Boolean

        End Function
#End Region

    End Class
End Namespace