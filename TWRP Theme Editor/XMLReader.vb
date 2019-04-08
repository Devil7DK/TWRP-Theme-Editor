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
                    End If
                Next

            End If
        Next
    End Sub

End Class
