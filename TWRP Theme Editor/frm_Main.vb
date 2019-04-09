Imports System.ComponentModel
Imports System.Text


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

                MsgBox(CType(Theme.Resources(0), Objects.Font).FileName)
            End If
        End If
    End Sub

    Private Sub Tree_ThemeExplorer_AfterSelect(sender As Object, e As TreeViewEventArgs) Handles Tree_ThemeExplorer.AfterSelect
        If e.Node.Tag IsNot Nothing Then
            pg_Main.SelectedObject = e.Node.Tag
        End If

        If e.Node.Tag IsNot Nothing AndAlso TypeOf e.Node.Tag Is Objects.Template Then
            Dim Template As Objects.Template = CType(e.Node.Tag, Objects.Template)
            Utils.LoadElementsToTree(Template.Elements, Tree_Elements)
        End If
    End Sub

    Sub ShowVariablesEditor(ByVal Variables As BindingList(Of Objects.Variable), ByVal ParentName As String)
        If TabbedView1.Documents.Count > 0 Then
            Dim ExistingDocument As DevExpress.XtraBars.Docking2010.Views.BaseDocument = TabbedView1.Documents.FindFirst(Function(c) c.Control IsNot Nothing AndAlso TypeOf c.Control Is DevExpress.XtraGrid.GridControl AndAlso CType(c.Control, DevExpress.XtraGrid.GridControl).DataSource Is Variables)
            If ExistingDocument IsNot Nothing Then
                TabbedView1.ActivateDocument(ExistingDocument.Control)
                Exit Sub
            End If
        End If

        Dim GridControl As New DevExpress.XtraGrid.GridControl
        Dim GridView As New DevExpress.XtraGrid.Views.Grid.GridView(GridControl)
        GridView.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.True
        GridView.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.True
        GridView.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom
        GridControl.DataSource = Variables

        Dim Document As DevExpress.XtraBars.Docking2010.Views.BaseDocument = TabbedView1.AddDocument(GridControl)
        Document.Caption = String.Format("Variables [{0}]", ParentName)
    End Sub

    Private Sub Tree_ThemeExplorer_DoubleClick(sender As Object, e As EventArgs) Handles Tree_ThemeExplorer.DoubleClick
        Dim Node As TreeNode = Tree_ThemeExplorer.SelectedNode
        If Node.Name = "variables" AndAlso Node.Tag IsNot Nothing AndAlso TypeOf Node.Tag Is BindingList(Of Objects.Variable) Then
            ShowVariablesEditor(CType(Node.Tag, BindingList(Of Objects.Variable)), Node.Parent.Text)
        End If
    End Sub


End Class
