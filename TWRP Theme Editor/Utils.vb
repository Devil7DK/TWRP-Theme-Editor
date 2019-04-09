Public Class Utils

    Public Shared Sub LoadThemeToTree(ByVal Theme As Objects.Theme, ByVal TreeView As TreeView)
        TreeView.Nodes.Clear()

        Dim ThemeNode As TreeNode = TreeView.Nodes.Add("theme", "Theme", 0)
        ThemeNode.Tag = Theme

        Dim ResourcesNode As TreeNode = ThemeNode.Nodes.Add("resources", "Resources", 1)
        ResourcesNode.Tag = Theme.Resources
        For i As Integer = 0 To Theme.Resources.Count - 1
            Dim Item As Object = Theme.Resources(i)
            If TypeOf Item Is Objects.Font Then
                Dim Font As Objects.Font = CType(Item, Objects.Font)
                ResourcesNode.Nodes.Add(i.ToString, Font.Name, 2).Tag = Font
            ElseIf TypeOf Item Is Objects.Image Then
                Dim Image As Objects.Image = CType(Item, Objects.Image)
                ResourcesNode.Nodes.Add(i.ToString, Image.Name, 3).Tag = Image
            End If
        Next

        Dim VariablesNode As TreeNode = ThemeNode.Nodes.Add("variables", "Variables", 4)
        VariablesNode.Tag = Theme.Variables

        Dim TemplatesNode As TreeNode = ThemeNode.Nodes.Add("templates", "Templates", 5)
        For i As Integer = 0 To Theme.Templates.Count - 1
            TemplatesNode.Nodes.Add(i.ToString, Theme.Templates(i).Name, 6).Tag = Theme.Templates(i)
        Next

        Dim pagesNode As TreeNode = ThemeNode.Nodes.Add("pages", "Pages", 7)
        For i As Integer = 0 To Theme.Pages.Count - 1
            pagesNode.Nodes.Add(i.ToString, Theme.Pages(i).Name, 8)
        Next

        DisableSelectedImageIndex(ThemeNode)
    End Sub

    Public Shared Sub LoadElementsToTree(ByVal Elements As List(Of Objects.Elements.ElementBase), ByVal TreeView As TreeView)
        TreeView.Nodes.Clear()

        For i As Integer = 0 To Elements.Count - 1
            Dim Element As Object = Elements(i)
            Dim Name As String = ""
            Dim ImageIndex As Integer = 0

            If TypeOf Element Is Objects.Elements.Action Then
                Name = "action"
                ImageIndex = 1
            ElseIf TypeOf Element Is Objects.Elements.Button Then
                Name = "button"
                ImageIndex = 2
            ElseIf TypeOf Element Is Objects.Elements.Fill Then
                Name = "fill"
                ImageIndex = 3
            ElseIf TypeOf Element Is Objects.Elements.Image Then
                Name = "image"
                ImageIndex = 4
            ElseIf TypeOf Element Is Objects.Elements.ProgressBar Then
                Name = "progressbar"
                ImageIndex = 5
            ElseIf TypeOf Element Is Objects.Elements.Text Then
                Name = "text"
                ImageIndex = 6
            Else
                Name = "unknown element"
                ImageIndex = 0
            End If

            TreeView.Nodes.Add(i.ToString, Name, ImageIndex).Tag = Element
        Next

        For Each Child As TreeNode In TreeView.Nodes
            DisableSelectedImageIndex(Child)
        Next
    End Sub

    Private Shared Sub DisableSelectedImageIndex(ByVal Node As TreeNode)
        Node.SelectedImageIndex = Node.ImageIndex
        For Each Child As TreeNode In Node.Nodes
            DisableSelectedImageIndex(Child)
        Next
    End Sub

End Class
