Imports System.ComponentModel

Namespace Objects
    Public Class Theme

#Region "Properties"
        Property Resolution As Size
        Property Author As String
        Property Title As String
        Property Description As String
        Property Preview As String
        Property Version As Double

        Property Resources As New List(Of ItemBase)

        Property Variables As New BindingList(Of Variable) With {.AllowNew = True, .AllowEdit = True, .AllowRemove = True}

        Property Templates As New List(Of ItemBase)

        Property Pages As New List(Of Page)
#End Region

    End Class
End Namespace