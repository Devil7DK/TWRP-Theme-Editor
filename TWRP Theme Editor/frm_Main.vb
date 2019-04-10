Imports System.ComponentModel
Imports System.Text
Imports DevExpress.XtraBars.Docking2010
Imports DevExpress.XtraBars.Docking2010.Views

Partial Public Class frm_Main
    Shared Sub New()
        DevExpress.UserSkins.BonusSkins.Register()
    End Sub
    Public Sub New()
        InitializeComponent()
    End Sub

    Private Sub DockPanel5_Click(sender As Object, e As EventArgs) Handles DockPanel5.Click

    End Sub

    Private Sub btn_LoadTheme_TWRES_ItemClick(sender As Object, e As DevExpress.XtraBars.ItemClickEventArgs) Handles btn_LoadTheme_TWRES.ItemClick
        If FolderBrowserDialog1.ShowDialog = DialogResult.OK Then
            Dim UI_XML As String = IO.Path.Combine(FolderBrowserDialog1.SelectedPath, "ui.xml")
            Dim PORTRAIT_XML As String = IO.Path.Combine(FolderBrowserDialog1.SelectedPath, "portrait.xml")
            Dim LANDSCAPE_XML As String = IO.Path.Combine(FolderBrowserDialog1.SelectedPath, "landscape.xml")

            If My.Computer.FileSystem.FileExists(UI_XML) AndAlso (My.Computer.FileSystem.FileExists(PORTRAIT_XML) Or My.Computer.FileSystem.FileExists(LANDSCAPE_XML)) Then
                Dim Theme As New Objects.Theme

                XMLReader.Read_UI_XML(UI_XML, Theme)

                Utils.LoadThemeToTree(Theme, Tree_ThemeExplorer)

                Theme.Paths = {FolderBrowserDialog1.SelectedPath}

                MsgBox(CType(Theme.Resources(0), Objects.Font).FileName)
            End If
        End If
    End Sub

    Private Sub Tree_ThemeExplorer_AfterSelect(sender As Object, e As TreeViewEventArgs) Handles Tree_ThemeExplorer.AfterSelect
        If e.Node.Tag IsNot Nothing Then
            pg_Main.SelectedObject = e.Node.Tag
        End If
    End Sub

    Sub ShowVariablesEditor(ByVal Variables As BindingList(Of Objects.Variable), ByVal ParentName As String)
        If tv_Main.Documents.Count > 0 Then
            Dim ExistingDocument As DevExpress.XtraBars.Docking2010.Views.BaseDocument = tv_Main.Documents.FindFirst(Function(c) c.Control IsNot Nothing AndAlso TypeOf c.Control Is DevExpress.XtraGrid.GridControl AndAlso CType(c.Control, DevExpress.XtraGrid.GridControl).DataSource Is Variables)
            If ExistingDocument IsNot Nothing Then
                tv_Main.ActivateDocument(ExistingDocument.Control)
                Exit Sub
            End If
        End If

        Dim GridControl As New DevExpress.XtraGrid.GridControl
        Dim GridView As New DevExpress.XtraGrid.Views.Grid.GridView(GridControl)
        GridView.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.True
        GridView.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.True
        GridView.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom
        GridControl.DataSource = Variables

        Dim Document As DevExpress.XtraBars.Docking2010.Views.BaseDocument = tv_Main.AddDocument(GridControl)
        Document.Caption = String.Format("Variables [{0}]", ParentName)
        tv_Main.ActivateDocument(Document.Control)
    End Sub

    Private Sub Tree_ThemeExplorer_DoubleClick(sender As Object, e As EventArgs) Handles Tree_ThemeExplorer.DoubleClick
        Dim Node As TreeNode = Tree_ThemeExplorer.SelectedNode
        If Node.Name = "variables" AndAlso Node.Tag IsNot Nothing AndAlso TypeOf Node.Tag Is BindingList(Of Objects.Variable) Then
            ShowVariablesEditor(CType(Node.Tag, BindingList(Of Objects.Variable)), Node.Parent.Text)
        ElseIf Node.Parent IsNot Nothing AndAlso Node.Parent.Name = "templates" AndAlso TypeOf Node.Tag Is Objects.Template Then
            Dim Theme As Objects.Theme = CType(Node.Parent.Parent.Tag, Objects.Theme)
            Dim Template As Objects.Template = CType(Node.Tag, Objects.Template)
            ShowTemplateEditor(Template, Theme)
        End If
    End Sub

    Private Sub UpdateTemplateEditor()
        If tv_Main.ActiveDocument IsNot Nothing AndAlso tv_Main.ActiveDocument.Tag IsNot Nothing AndAlso TypeOf tv_Main.ActiveDocument.Tag Is Objects.Template AndAlso TypeOf tv_Main.ActiveDocument.Control Is DevExpress.XtraEditors.PictureEdit Then
            Dim PictureEdit As DevExpress.XtraEditors.PictureEdit = CType(tv_Main.ActiveDocument.Control, DevExpress.XtraEditors.PictureEdit)
            Dim Template As Objects.Template = CType(tv_Main.ActiveDocument.Tag, Objects.Template)
            Dim Theme As Objects.Theme = CType(Tree_ThemeExplorer.Nodes(0).Tag, Objects.Theme)

            Dim Bitmap As New Bitmap(Theme.Resolution.Width, Theme.Resolution.Height)
            Renderer.RenderTemplate(Theme, Template, Bitmap, Tree_Elements.SelectedNode)

            PictureEdit.Image = Bitmap
            PictureEdit.Refresh()
        End If
    End Sub

    Private Sub ShowTemplateEditor(ByVal Template As Objects.Template, ByVal Theme As Objects.Theme)
        If tv_Main.Documents.Count > 0 Then
            Dim ExistingDocument As DevExpress.XtraBars.Docking2010.Views.BaseDocument = tv_Main.Documents.FindFirst(Function(c) TypeOf c.Tag Is Objects.Template AndAlso c.Tag Is Template)
            If ExistingDocument IsNot Nothing Then
                tv_Main.ActivateDocument(ExistingDocument.Control)
                Exit Sub
            End If
        End If

        Dim PictureEdit As New DevExpress.XtraEditors.PictureEdit
        With PictureEdit
            .Properties.AllowZoomOnMouseWheel = DevExpress.Utils.DefaultBoolean.True
            .Properties.ShowZoomSubMenu = DevExpress.Utils.DefaultBoolean.True
            .Properties.ZoomingOperationMode = DevExpress.XtraEditors.Repository.ZoomingOperationMode.ControlMouseWheel
            .Properties.AllowScrollOnMouseWheel = DevExpress.Utils.DefaultBoolean.True
            .Properties.AllowScrollViaMouseDrag = True
            .Properties.ShowScrollBars = True

            Dim Zoom As Double = Math.Min(100, Math.Min((PictureEdit.Width - 12) * 100 / Theme.Resolution.Width,
                                       (PictureEdit.Height - 2) * 100 / Theme.Resolution.Height))
            PictureEdit.Properties.ZoomPercent = Zoom
        End With

        Dim Document As DevExpress.XtraBars.Docking2010.Views.BaseDocument = tv_Main.AddDocument(PictureEdit)
        Document.Caption = String.Format("Template - {0}", Template.Name)
        Document.Tag = Template
        tv_Main.ActivateDocument(Document.Control)
        UpdateTemplateEditor()
    End Sub

    Private Sub Tree_Elements_AfterSelect(sender As Object, e As TreeViewEventArgs) Handles Tree_Elements.AfterSelect
        If e.Node.Tag IsNot Nothing Then
            pg_Main.SelectedObject = e.Node.Tag

            If tv_Main.ActiveDocument.Tag IsNot Nothing Then
                If TypeOf tv_Main.ActiveDocument.Tag Is Objects.Template Then
                    UpdateTemplateEditor()
                End If
            End If
        End If
    End Sub

    Private Sub tv_Main_DocumentActivated(sender As Object, e As DocumentEventArgs) Handles tv_Main.DocumentActivated
        If e.Document.Tag IsNot Nothing AndAlso TypeOf e.Document.Tag Is Objects.PageBase Then
            Dim PageBase As Objects.PageBase = CType(e.Document.Tag, Objects.PageBase)
            Utils.LoadElementsToTree(PageBase.Elements, Tree_Elements)
        Else
            Tree_Elements.Nodes.Clear()
        End If
    End Sub

    Private Sub tv_Main_DocumentClosed(sender As Object, e As DocumentEventArgs) Handles tv_Main.DocumentClosed
        Tree_Elements.Nodes.Clear()
    End Sub
End Class
