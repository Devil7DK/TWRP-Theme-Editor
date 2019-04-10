Imports System.ComponentModel

Namespace Objects
    Public Class Theme

#Region "Properties"
        Property Paths() As String()
        Property Resolution As Size
        Property Author As String
        Property Title As String
        Property Description As String
        Property Preview As String
        Property Version As Double

        Property Resources As New List(Of ItemBase)

        Property Variables As New BindingList(Of Variable) With {.AllowNew = True, .AllowEdit = True, .AllowRemove = True}

        Property Templates As New List(Of Template)

        Property Pages As New List(Of Page)
#End Region

#Region "Functions"
        Function GetColor(ByVal Name As String) As Color
            If Name.StartsWith("%") Then
                For Each Variable As Variable In Variables
                    If Variable.Name = Name.Trim(CChar("%")) Then
                        Return ColorTranslator.FromHtml(Variable.Value)
                    End If
                Next
            ElseIf Name.StartsWith("#") Then
                Return ColorTranslator.FromHtml(Name)
            End If
            Return Color.Black
        End Function

        Function GetImage(ByVal Name As String) As Drawing.Image
            For Each Resource As Object In Resources
                If TypeOf Resource Is Image Then
                    Dim ImageObj As Image = CType(Resource, Image)

                    For Each Path As String In Paths
                        Dim ImagePath As String = IO.Path.Combine(Path, "images", ImageObj.FileName & ".png")
                        If My.Computer.FileSystem.FileExists(ImagePath) Then
                            Return Drawing.Image.FromFile(ImagePath)
                        End If
                    Next
                End If
            Next

            Return Nothing
        End Function

        Function GetRect(ByVal Placement As Placement, Optional MinWidth As Integer = 0, Optional MinHeight As Integer = 0) As Rectangle
            Dim X As Integer = ParseInt(Placement.X)
            Dim Y As Integer = ParseInt(Placement.Y)
            Dim Width As Integer = ParseInt(Placement.Width)
            Dim Height As Integer = ParseInt(Placement.Height)

            If Width = 0 Then Width = MinWidth
            If Height = 0 Then Height = MinHeight

            Return New Rectangle(X, Y, Width, Height)
        End Function

        Function ParseInt(ByVal Value As String) As Integer
            Try
                Return Integer.Parse(Value)
            Catch ex As Exception

            End Try

            For Each Variable As Variable In Variables
                If Variable.Name = Value Then
                    Try
                        Return Integer.Parse(Variable.Value)
                    Catch ex As Exception

                    End Try
                End If
            Next

            Return 0
        End Function

        Function ValidateConditions(ByVal Conditions As List(Of Condition)) As Boolean

        End Function
#End Region

    End Class
End Namespace