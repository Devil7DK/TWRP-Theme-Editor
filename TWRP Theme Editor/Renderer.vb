Public Class Renderer

    Public Shared Sub RenderTemplate(ByVal Theme As Objects.Theme, ByVal Template As Objects.Template, ByVal Image As Bitmap, ByVal SelectedNode As TreeNode)
        If Theme IsNot Nothing AndAlso Template IsNot Nothing AndAlso Image IsNot Nothing Then
            Using G As Graphics = Graphics.FromImage(Image)
                If Template.Background IsNot Nothing AndAlso Not String.IsNullOrEmpty(Template.Background) Then G.Clear(Theme.GetColor(Template.Background))

                For i As Integer = 0 To Template.Elements.Count - 1
                    Dim Element As Object = Template.Elements(i)

                    Dim Rect As Rectangle = Nothing

                    If TypeOf Element Is Objects.Elements.Button Then

                    ElseIf TypeOf Element Is Objects.Elements.Fill Then
                        Dim FillElement As Objects.Elements.Fill = CType(Element, Objects.Elements.Fill)
                        Dim Color As Color = Theme.GetColor(FillElement.Color)

                        Rect = Theme.GetRect(FillElement.Placement)
                        G.FillRectangle(New SolidBrush(Color), Rect)
                    ElseIf TypeOf Element Is Objects.Elements.Image Then
                        Dim ImageElement As Objects.Elements.Image = CType(Element, Objects.Elements.Image)
                        Dim Image2Draw As Image = Theme.GetImage(ImageElement.Image)

                        If Image2Draw IsNot Nothing Then
                            Rect = Theme.GetRect(ImageElement.Placement, Image2Draw.Width, Image2Draw.Height)
                            G.DrawImage(Image2Draw, Rect)
                        End If
                    End If

                    If Rect <> Nothing AndAlso SelectedNode IsNot Nothing AndAlso SelectedNode.Tag IsNot Nothing AndAlso SelectedNode.Tag Is Element Then
                        Dim OutLineThickness As Integer = 5
                        Dim OutRect As New Rectangle(Rect.X - OutLineThickness, Rect.Y - OutLineThickness, Rect.Width + (OutLineThickness * 2), Rect.Height + (OutLineThickness * 2))
                        G.DrawRectangle(New Pen(Color.Red, OutLineThickness), OutRect)
                    End If
                Next
            End Using

            Image.Save("D:\T.bmp", Imaging.ImageFormat.Bmp)
        End If
    End Sub

End Class
