Namespace Objects
    Public Class Condition

#Region "Property"
        Property Variable1 As String
        Property Variable2 As String
        Property [Operator] As String
#End Region

#Region "Constructor"
        Sub New(ByVal Variable1 As String, ByVal Variable2 As String, ByVal [Operator] As String)
            Me.Variable1 = Variable1
            Me.Variable2 = Variable2
            Me.Operator = [Operator]
        End Sub
#End Region

#Region "Functions"
        Function Validate(ByVal Variables As Dictionary(Of String, String)) As Boolean

        End Function
#End Region

    End Class
End Namespace