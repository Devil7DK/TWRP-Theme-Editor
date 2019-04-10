Imports System.Xml

Public Class XMLReader

    Public Shared Sub Read_UI_XML(ByVal XMLFilename As String, ByVal Theme As Objects.Theme)
        Dim XMLData As String = My.Computer.FileSystem.ReadAllText(XMLFilename)
        XMLData = XMLData.Replace("&&", "&amp;")

        Dim XMLDocument As New XmlDocument
        XMLDocument.LoadXml(XMLData)

        For Each RecoveryNode As XmlNode In XMLDocument.ChildNodes
            If RecoveryNode.Name = "recovery" Then

                For Each RecoveryItemNode As XmlNode In RecoveryNode.ChildNodes
                    If RecoveryItemNode.Name = "details" Then
                        For Each DetailNode As XmlNode In RecoveryItemNode.ChildNodes
                            If DetailNode.Name = "resolution" Then
                                Dim Width As Integer = 0
                                Dim Height As Integer = 0
                                If DetailNode.Attributes("width") IsNot Nothing Then Integer.TryParse(DetailNode.Attributes("width").Value, Width)
                                If DetailNode.Attributes("height") IsNot Nothing Then Integer.TryParse(DetailNode.Attributes("height").Value, Height)
                                Theme.Resolution = New Size(Width, Height)
                            ElseIf DetailNode.Name = "author" Then
                                Theme.Author = DetailNode.InnerText
                            ElseIf DetailNode.Name = "title" Then
                                Theme.Title = DetailNode.InnerText
                            ElseIf DetailNode.Name = "description" Then
                                Theme.Description = DetailNode.InnerText
                            ElseIf DetailNode.Name = "preview" Then
                                Theme.Preview = DetailNode.InnerText
                            End If
                        Next

                    ElseIf RecoveryItemNode.Name = "resources" Then
                        For Each ResourceNode As XmlNode In RecoveryItemNode.ChildNodes
                            If ResourceNode.Name = "font" Then
                                Dim Name As String = ""
                                Dim FileName As String = ""
                                Dim Size As Double = 12

                                If ResourceNode.Attributes("name") IsNot Nothing Then Name = ResourceNode.Attributes("name").Value
                                If ResourceNode.Attributes("filename") IsNot Nothing Then FileName = ResourceNode.Attributes("filename").Value
                                If ResourceNode.Attributes("size") IsNot Nothing Then Double.TryParse(ResourceNode.Attributes("size").Value, Size)

                                Theme.Resources.Add(New Objects.Font(Name, FileName, Size))
                            ElseIf ResourceNode.Name = "image" Then
                                Dim Name As String = ""
                                Dim FileName As String = ""
                                Dim RetainAspect As Integer = 0

                                If ResourceNode.Attributes("name") IsNot Nothing Then Name = ResourceNode.Attributes("name").Value
                                If ResourceNode.Attributes("filename") IsNot Nothing Then FileName = ResourceNode.Attributes("filename").Value
                                If ResourceNode.Attributes("retainaspect") IsNot Nothing Then Integer.TryParse(ResourceNode.Attributes("retainaspect").Value, RetainAspect)

                                Theme.Resources.Add(New Objects.Image(Name, FileName, CBool(RetainAspect)))
                            End If
                        Next

                    ElseIf RecoveryItemNode.Name = "variables" Then
                        For Each VariableNode As XmlNode In RecoveryItemNode.ChildNodes
                            If VariableNode.Name = "variable" Then
                                Dim Name As String = ""
                                Dim Value As String = ""
                                Dim Persist As Integer = 0

                                If VariableNode.Attributes("name") IsNot Nothing Then Name = VariableNode.Attributes("name").Value
                                If VariableNode.Attributes("value") IsNot Nothing Then Value = VariableNode.Attributes("value").Value
                                If VariableNode.Attributes("persist") IsNot Nothing Then Integer.TryParse(VariableNode.Attributes("persist").Value, Persist)

                                Theme.Variables.Add(New Objects.Variable(Name, Value, CBool(Persist)))
                            End If
                        Next

                    ElseIf RecoveryItemNode.Name = "templates" Then
                        For Each TemplateNode As XmlNode In RecoveryItemNode.ChildNodes
                            If TemplateNode.Name = "template" Then
                                Dim Template As New Objects.Template
                                Template.Name = TemplateNode.Attributes("name").Value

                                For Each TemplateItemNode As XmlNode In TemplateNode.ChildNodes
                                    If TemplateItemNode.Name = "background" Then
                                        Template.Background = TemplateItemNode.Attributes("color").Value
                                    End If

                                    ReadElements(TemplateNode, Template)
                                Next

                                Theme.Templates.Add(Template)
                            End If
                        Next
                    End If
                Next

            End If
        Next
    End Sub

    Private Shared Sub ReadElements(ByVal ParentNode As XmlNode, ByVal Page As Objects.PageBase)
        For Each ElementNode As XmlNode In ParentNode.ChildNodes
            Dim Conditions As New List(Of Objects.Condition)
            ReadConditions(ElementNode, Conditions)

            Dim Actions As New List(Of Objects.Action)
            ReadActions(ElementNode, Actions)

            Dim Placement As Objects.Placement = ReadPlacement(ElementNode)

            If ElementNode.Name = "action" Then
                Dim Key As String = ""

                Page.Actions.Add(New Objects.Elements.Action(Key, Actions))

            ElseIf ElementNode.Name = "button" Then
                Dim Image As String = ""
                Dim HighlightedImage As String = ""
                Dim HighlightedColor As String = ""
                Dim Font As String = ""
                Dim FontColor As String = ""
                Dim Text As String = ""

                ReadFontAndText(ElementNode, Font, FontColor, Text)

                For Each HColorNode As XmlNode In ElementNode.ChildNodes
                    If HColorNode.Name = "highlight" Then
                        If HColorNode.Attributes("color") IsNot Nothing Then HighlightedColor = HColorNode.Attributes("color").Value
                    End If
                Next

                For Each ImageNode As XmlNode In ElementNode.ChildNodes
                    If ImageNode.Name = "image" Then
                        If ImageNode.Attributes("resource") IsNot Nothing Then Image = ImageNode.Attributes("resource").Value
                        If ImageNode.Attributes("highlightresource") IsNot Nothing Then HighlightedImage = ImageNode.Attributes("highlightresource").Value
                        Exit For
                    End If
                Next

                Page.Elements.Add(New Objects.Elements.Button(Placement, Conditions, Actions, Image, HighlightedImage, HighlightedColor, Font, FontColor, Text))

            ElseIf ElementNode.Name = "fill" Then
                Dim Color As String = String.Empty

                If ElementNode.Attributes("color") IsNot Nothing Then Color = ElementNode.Attributes("color").Value

                Page.Elements.Add(New Objects.Elements.Fill(Placement, Conditions, Actions, Color))

            ElseIf ElementNode.Name = "image" Then
                Dim Image As String = ""

                For Each ImageNode As XmlNode In ElementNode.ChildNodes
                    If ImageNode.Name = "image" Then
                        If ImageNode.Attributes("resource") IsNot Nothing Then Image = ImageNode.Attributes("resource").Value
                        Exit For
                    End If
                Next

                Page.Elements.Add(New Objects.Elements.Image(Placement, Conditions, Actions, Image))

            ElseIf ElementNode.Name = "text" Then
                Dim Font As String = ""
                Dim FontColor As String = ""
                Dim Text As String = ""

                ReadFontAndText(ElementNode, Font, FontColor, Text)

                Page.Elements.Add(New Objects.Elements.Text(Placement, Conditions, Actions, Font, FontColor, Text))

            End If
        Next
    End Sub

    Private Shared Sub ReadActions(ByVal ParentNode As XmlNode, ByVal Actions As List(Of Objects.Action))
        For Each ActionNode As XmlNode In ParentNode.ChildNodes
            If ActionNode.Name = "action" Then
                Dim [Function] As String = ""
                Dim Value As String = ActionNode.InnerText

                If ActionNode.Attributes("function") IsNot Nothing Then [Function] = ActionNode.Attributes("function").Value

                Actions.Add(New Objects.Action([Function], Value))
            End If
        Next
    End Sub

    Private Shared Sub ReadConditions(ByVal ParentNode As XmlNode, ByVal Conditions As List(Of Objects.Condition))
        For Each ConditionNode As XmlNode In ParentNode.ChildNodes
            If ConditionNode.Name = "condition" Then
                Dim Var1 As String = String.Empty
                Dim Var2 As String = String.Empty
                Dim [Operator] As String

                If ConditionNode.Attributes("var1") IsNot Nothing Then Var1 = ConditionNode.Attributes("var1").Value
                If ConditionNode.Attributes("var2") IsNot Nothing Then Var2 = ConditionNode.Attributes("var2").Value
                If ConditionNode.Attributes("op") IsNot Nothing Then [Operator] = ConditionNode.Attributes("op").Value

                If Not String.IsNullOrEmpty(Var1) Or Not String.IsNullOrEmpty(Var2) Then
                    Conditions.Add(New Objects.Condition(Var1, Var2, [Operator]))
                End If
            End If
        Next
    End Sub

    Private Shared Function ReadPlacement(ByVal ParentNode As XmlNode) As Objects.Placement
        For Each PlacementNode As XmlNode In ParentNode.ChildNodes
            If PlacementNode.Name = "placement" Then
                Dim X As String = String.Empty
                Dim Y As String = String.Empty
                Dim Width As String = String.Empty
                Dim Height As String = String.Empty
                Dim Placement As String = String.Empty

                If PlacementNode.Attributes("x") IsNot Nothing Then X = PlacementNode.Attributes("x").Value
                If PlacementNode.Attributes("y") IsNot Nothing Then Y = PlacementNode.Attributes("y").Value
                If PlacementNode.Attributes("width") IsNot Nothing Then Width = PlacementNode.Attributes("width").Value
                If PlacementNode.Attributes("height") IsNot Nothing Then Height = PlacementNode.Attributes("height").Value
                If PlacementNode.Attributes("placement") IsNot Nothing Then Placement = PlacementNode.Attributes("placement").Value

                Return New Objects.Placement(X, Y, Width, Height, Placement)
            End If
        Next

        Return Nothing
    End Function

    Private Shared Sub ReadFontAndText(ByVal ParentNode As XmlNode, ByRef Font As String, ByRef FontColor As String, ByRef Text As String)
        For Each Node As XmlNode In ParentNode.ChildNodes
            If Node.Name = "font" Then
                If Node.Attributes("resource") IsNot Nothing Then Font = Node.Attributes("resource").Value
                If Node.Attributes("color") IsNot Nothing Then Font = Node.Attributes("color").Value
            ElseIf Node.Name = "text" Then
                Text = Node.InnerText
            End If
        Next
    End Sub

End Class

