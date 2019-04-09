Partial Public Class frm_Main
    Inherits DevExpress.XtraBars.Ribbon.RibbonForm

    ''' <summary>
    ''' Required designer variable.
    ''' </summary>
    Private components As System.ComponentModel.IContainer = Nothing

    ''' <summary>
    ''' Clean up any resources being used.
    ''' </summary>
    ''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso (components IsNot Nothing) Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

#Region "Windows Form Designer generated code"

    ''' <summary>
    ''' Required method for Designer support - do not modify
    ''' the contents of this method with the code editor.
    ''' </summary>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_Main))
        Me.ribbonControl1 = New DevExpress.XtraBars.Ribbon.RibbonControl()
        Me.btn_LoadTheme_TWRES = New DevExpress.XtraBars.BarButtonItem()
        Me.SkinRibbonGalleryBarItem1 = New DevExpress.XtraBars.SkinRibbonGalleryBarItem()
        Me.ribbonPage1 = New DevExpress.XtraBars.Ribbon.RibbonPage()
        Me.rpg_LoadTheme = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.RibbonPageGroup1 = New DevExpress.XtraBars.Ribbon.RibbonPageGroup()
        Me.DockManager1 = New DevExpress.XtraBars.Docking.DockManager(Me.components)
        Me.DockPanel1 = New DevExpress.XtraBars.Docking.DockPanel()
        Me.DockPanel1_Container = New DevExpress.XtraBars.Docking.ControlContainer()
        Me.RichTextBox1 = New System.Windows.Forms.RichTextBox()
        Me.DockPanel2 = New DevExpress.XtraBars.Docking.DockPanel()
        Me.DockPanel2_Container = New DevExpress.XtraBars.Docking.ControlContainer()
        Me.Tree_Elements = New System.Windows.Forms.TreeView()
        Me.panelContainer1 = New DevExpress.XtraBars.Docking.DockPanel()
        Me.DockPanel5 = New DevExpress.XtraBars.Docking.DockPanel()
        Me.DockPanel5_Container = New DevExpress.XtraBars.Docking.ControlContainer()
        Me.Tree_ThemeExplorer = New System.Windows.Forms.TreeView()
        Me.ImageList_ThemeExplorer = New System.Windows.Forms.ImageList(Me.components)
        Me.DockPanel3 = New DevExpress.XtraBars.Docking.DockPanel()
        Me.DockPanel3_Container = New DevExpress.XtraBars.Docking.ControlContainer()
        Me.pg_Main = New DevExpress.XtraVerticalGrid.PropertyGridControl()
        Me.SplitterControl1 = New DevExpress.XtraEditors.SplitterControl()
        Me.pgd_Main = New DevExpress.XtraVerticalGrid.PropertyDescriptionControl()
        Me.DocumentManager1 = New DevExpress.XtraBars.Docking2010.DocumentManager(Me.components)
        Me.TabbedView1 = New DevExpress.XtraBars.Docking2010.Views.Tabbed.TabbedView(Me.components)
        Me.FolderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog()
        Me.ImageList_Elements = New System.Windows.Forms.ImageList(Me.components)
        CType(Me.ribbonControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DockManager1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.DockPanel1.SuspendLayout()
        Me.DockPanel1_Container.SuspendLayout()
        Me.DockPanel2.SuspendLayout()
        Me.DockPanel2_Container.SuspendLayout()
        Me.panelContainer1.SuspendLayout()
        Me.DockPanel5.SuspendLayout()
        Me.DockPanel5_Container.SuspendLayout()
        Me.DockPanel3.SuspendLayout()
        Me.DockPanel3_Container.SuspendLayout()
        CType(Me.pg_Main, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DocumentManager1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TabbedView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ribbonControl1
        '
        Me.ribbonControl1.ExpandCollapseItem.Id = 0
        Me.ribbonControl1.Items.AddRange(New DevExpress.XtraBars.BarItem() {Me.ribbonControl1.ExpandCollapseItem, Me.btn_LoadTheme_TWRES, Me.SkinRibbonGalleryBarItem1})
        Me.ribbonControl1.Location = New System.Drawing.Point(0, 0)
        Me.ribbonControl1.MaxItemId = 3
        Me.ribbonControl1.Name = "ribbonControl1"
        Me.ribbonControl1.Pages.AddRange(New DevExpress.XtraBars.Ribbon.RibbonPage() {Me.ribbonPage1})
        Me.ribbonControl1.Size = New System.Drawing.Size(758, 143)
        '
        'btn_LoadTheme_TWRES
        '
        Me.btn_LoadTheme_TWRES.Caption = "TWRP Resources"
        Me.btn_LoadTheme_TWRES.Id = 1
        Me.btn_LoadTheme_TWRES.Name = "btn_LoadTheme_TWRES"
        '
        'SkinRibbonGalleryBarItem1
        '
        Me.SkinRibbonGalleryBarItem1.Caption = "SkinRibbonGalleryBarItem1"
        Me.SkinRibbonGalleryBarItem1.Id = 2
        Me.SkinRibbonGalleryBarItem1.Name = "SkinRibbonGalleryBarItem1"
        '
        'ribbonPage1
        '
        Me.ribbonPage1.Groups.AddRange(New DevExpress.XtraBars.Ribbon.RibbonPageGroup() {Me.rpg_LoadTheme, Me.RibbonPageGroup1})
        Me.ribbonPage1.Name = "ribbonPage1"
        Me.ribbonPage1.Text = "ribbonPage1"
        '
        'rpg_LoadTheme
        '
        Me.rpg_LoadTheme.ItemLinks.Add(Me.btn_LoadTheme_TWRES)
        Me.rpg_LoadTheme.Name = "rpg_LoadTheme"
        Me.rpg_LoadTheme.ShowCaptionButton = False
        Me.rpg_LoadTheme.Text = "Load Theme"
        '
        'RibbonPageGroup1
        '
        Me.RibbonPageGroup1.ItemLinks.Add(Me.SkinRibbonGalleryBarItem1)
        Me.RibbonPageGroup1.Name = "RibbonPageGroup1"
        Me.RibbonPageGroup1.Text = "RibbonPageGroup1"
        '
        'DockManager1
        '
        Me.DockManager1.Form = Me
        Me.DockManager1.RootPanels.AddRange(New DevExpress.XtraBars.Docking.DockPanel() {Me.DockPanel1, Me.DockPanel2, Me.panelContainer1})
        Me.DockManager1.TopZIndexControls.AddRange(New String() {"DevExpress.XtraBars.BarDockControl", "DevExpress.XtraBars.StandaloneBarDockControl", "System.Windows.Forms.StatusBar", "System.Windows.Forms.MenuStrip", "System.Windows.Forms.StatusStrip", "DevExpress.XtraBars.Ribbon.RibbonStatusBar", "DevExpress.XtraBars.Ribbon.RibbonControl", "DevExpress.XtraBars.Navigation.OfficeNavigationBar", "DevExpress.XtraBars.Navigation.TileNavPane", "DevExpress.XtraBars.TabFormControl", "DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormControl"})
        '
        'DockPanel1
        '
        Me.DockPanel1.Controls.Add(Me.DockPanel1_Container)
        Me.DockPanel1.Dock = DevExpress.XtraBars.Docking.DockingStyle.Bottom
        Me.DockPanel1.ID = New System.Guid("e1571869-6565-47da-8a8e-ae3c9f4f33cd")
        Me.DockPanel1.Location = New System.Drawing.Point(0, 444)
        Me.DockPanel1.Name = "DockPanel1"
        Me.DockPanel1.OriginalSize = New System.Drawing.Size(200, 139)
        Me.DockPanel1.Size = New System.Drawing.Size(758, 139)
        Me.DockPanel1.Text = "Output"
        '
        'DockPanel1_Container
        '
        Me.DockPanel1_Container.Controls.Add(Me.RichTextBox1)
        Me.DockPanel1_Container.Location = New System.Drawing.Point(4, 24)
        Me.DockPanel1_Container.Name = "DockPanel1_Container"
        Me.DockPanel1_Container.Size = New System.Drawing.Size(750, 111)
        Me.DockPanel1_Container.TabIndex = 0
        '
        'RichTextBox1
        '
        Me.RichTextBox1.BackColor = System.Drawing.Color.Black
        Me.RichTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.RichTextBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.RichTextBox1.ForeColor = System.Drawing.Color.White
        Me.RichTextBox1.Location = New System.Drawing.Point(0, 0)
        Me.RichTextBox1.Name = "RichTextBox1"
        Me.RichTextBox1.Size = New System.Drawing.Size(750, 111)
        Me.RichTextBox1.TabIndex = 0
        Me.RichTextBox1.Text = ""
        '
        'DockPanel2
        '
        Me.DockPanel2.Controls.Add(Me.DockPanel2_Container)
        Me.DockPanel2.Dock = DevExpress.XtraBars.Docking.DockingStyle.Left
        Me.DockPanel2.ID = New System.Guid("4904d10a-fde2-4c73-b67a-62b6035cc760")
        Me.DockPanel2.Location = New System.Drawing.Point(0, 143)
        Me.DockPanel2.Name = "DockPanel2"
        Me.DockPanel2.OriginalSize = New System.Drawing.Size(200, 200)
        Me.DockPanel2.SavedDock = DevExpress.XtraBars.Docking.DockingStyle.Left
        Me.DockPanel2.SavedIndex = 1
        Me.DockPanel2.Size = New System.Drawing.Size(200, 301)
        Me.DockPanel2.Text = "Element Tree"
        '
        'DockPanel2_Container
        '
        Me.DockPanel2_Container.Controls.Add(Me.Tree_Elements)
        Me.DockPanel2_Container.Location = New System.Drawing.Point(4, 23)
        Me.DockPanel2_Container.Name = "DockPanel2_Container"
        Me.DockPanel2_Container.Size = New System.Drawing.Size(191, 274)
        Me.DockPanel2_Container.TabIndex = 0
        '
        'Tree_Elements
        '
        Me.Tree_Elements.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Tree_Elements.ImageIndex = 0
        Me.Tree_Elements.ImageList = Me.ImageList_Elements
        Me.Tree_Elements.Location = New System.Drawing.Point(0, 0)
        Me.Tree_Elements.Name = "Tree_Elements"
        Me.Tree_Elements.SelectedImageIndex = 0
        Me.Tree_Elements.Size = New System.Drawing.Size(191, 274)
        Me.Tree_Elements.TabIndex = 5
        '
        'panelContainer1
        '
        Me.panelContainer1.Controls.Add(Me.DockPanel5)
        Me.panelContainer1.Controls.Add(Me.DockPanel3)
        Me.panelContainer1.Dock = DevExpress.XtraBars.Docking.DockingStyle.Right
        Me.panelContainer1.ID = New System.Guid("554c0e2d-9d1a-492a-9fd6-18b73f2f7f18")
        Me.panelContainer1.Location = New System.Drawing.Point(558, 143)
        Me.panelContainer1.Name = "panelContainer1"
        Me.panelContainer1.OriginalSize = New System.Drawing.Size(200, 200)
        Me.panelContainer1.Size = New System.Drawing.Size(200, 301)
        Me.panelContainer1.Text = "panelContainer1"
        '
        'DockPanel5
        '
        Me.DockPanel5.Controls.Add(Me.DockPanel5_Container)
        Me.DockPanel5.Dock = DevExpress.XtraBars.Docking.DockingStyle.Fill
        Me.DockPanel5.FloatVertical = True
        Me.DockPanel5.ID = New System.Guid("a2c8b19b-1093-4483-b0f4-c3e05bc0e9f1")
        Me.DockPanel5.Location = New System.Drawing.Point(0, 0)
        Me.DockPanel5.Name = "DockPanel5"
        Me.DockPanel5.OriginalSize = New System.Drawing.Size(200, 165)
        Me.DockPanel5.Size = New System.Drawing.Size(200, 151)
        Me.DockPanel5.Text = "Theme Explorer"
        '
        'DockPanel5_Container
        '
        Me.DockPanel5_Container.Controls.Add(Me.Tree_ThemeExplorer)
        Me.DockPanel5_Container.Location = New System.Drawing.Point(5, 23)
        Me.DockPanel5_Container.Name = "DockPanel5_Container"
        Me.DockPanel5_Container.Size = New System.Drawing.Size(191, 123)
        Me.DockPanel5_Container.TabIndex = 0
        '
        'Tree_ThemeExplorer
        '
        Me.Tree_ThemeExplorer.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Tree_ThemeExplorer.ImageIndex = 0
        Me.Tree_ThemeExplorer.ImageList = Me.ImageList_ThemeExplorer
        Me.Tree_ThemeExplorer.Location = New System.Drawing.Point(0, 0)
        Me.Tree_ThemeExplorer.Name = "Tree_ThemeExplorer"
        Me.Tree_ThemeExplorer.SelectedImageIndex = 0
        Me.Tree_ThemeExplorer.Size = New System.Drawing.Size(191, 123)
        Me.Tree_ThemeExplorer.TabIndex = 0
        '
        'ImageList_ThemeExplorer
        '
        Me.ImageList_ThemeExplorer.ImageStream = CType(resources.GetObject("ImageList_ThemeExplorer.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList_ThemeExplorer.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList_ThemeExplorer.Images.SetKeyName(0, "theme.png")
        Me.ImageList_ThemeExplorer.Images.SetKeyName(1, "resources.png")
        Me.ImageList_ThemeExplorer.Images.SetKeyName(2, "font.png")
        Me.ImageList_ThemeExplorer.Images.SetKeyName(3, "image.png")
        Me.ImageList_ThemeExplorer.Images.SetKeyName(4, "variables.png")
        Me.ImageList_ThemeExplorer.Images.SetKeyName(5, "templates.png")
        Me.ImageList_ThemeExplorer.Images.SetKeyName(6, "template.png")
        Me.ImageList_ThemeExplorer.Images.SetKeyName(7, "pages.png")
        Me.ImageList_ThemeExplorer.Images.SetKeyName(8, "page.png")
        '
        'DockPanel3
        '
        Me.DockPanel3.Controls.Add(Me.DockPanel3_Container)
        Me.DockPanel3.Dock = DevExpress.XtraBars.Docking.DockingStyle.Fill
        Me.DockPanel3.ID = New System.Guid("29ee0702-ac88-46ea-b504-bbd8ad0b5999")
        Me.DockPanel3.Location = New System.Drawing.Point(0, 151)
        Me.DockPanel3.Name = "DockPanel3"
        Me.DockPanel3.OriginalSize = New System.Drawing.Size(200, 165)
        Me.DockPanel3.Size = New System.Drawing.Size(200, 150)
        Me.DockPanel3.Text = "Properties"
        '
        'DockPanel3_Container
        '
        Me.DockPanel3_Container.Controls.Add(Me.pg_Main)
        Me.DockPanel3_Container.Controls.Add(Me.SplitterControl1)
        Me.DockPanel3_Container.Controls.Add(Me.pgd_Main)
        Me.DockPanel3_Container.Location = New System.Drawing.Point(5, 23)
        Me.DockPanel3_Container.Name = "DockPanel3_Container"
        Me.DockPanel3_Container.Size = New System.Drawing.Size(191, 123)
        Me.DockPanel3_Container.TabIndex = 0
        '
        'pg_Main
        '
        Me.pg_Main.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pg_Main.Location = New System.Drawing.Point(0, 0)
        Me.pg_Main.Name = "pg_Main"
        Me.pg_Main.Size = New System.Drawing.Size(191, 60)
        Me.pg_Main.TabIndex = 1
        '
        'SplitterControl1
        '
        Me.SplitterControl1.Cursor = System.Windows.Forms.Cursors.HSplit
        Me.SplitterControl1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.SplitterControl1.Location = New System.Drawing.Point(0, 60)
        Me.SplitterControl1.Name = "SplitterControl1"
        Me.SplitterControl1.Size = New System.Drawing.Size(191, 5)
        Me.SplitterControl1.TabIndex = 2
        Me.SplitterControl1.TabStop = False
        '
        'pgd_Main
        '
        Me.pgd_Main.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pgd_Main.Location = New System.Drawing.Point(0, 65)
        Me.pgd_Main.Name = "pgd_Main"
        Me.pgd_Main.Size = New System.Drawing.Size(191, 58)
        Me.pgd_Main.TabIndex = 0
        Me.pgd_Main.TabStop = False
        '
        'DocumentManager1
        '
        Me.DocumentManager1.ContainerControl = Me
        Me.DocumentManager1.View = Me.TabbedView1
        Me.DocumentManager1.ViewCollection.AddRange(New DevExpress.XtraBars.Docking2010.Views.BaseView() {Me.TabbedView1})
        '
        'ImageList_Elements
        '
        Me.ImageList_Elements.ImageStream = CType(resources.GetObject("ImageList_Elements.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList_Elements.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList_Elements.Images.SetKeyName(0, "element_control.png")
        Me.ImageList_Elements.Images.SetKeyName(1, "element_action.png")
        Me.ImageList_Elements.Images.SetKeyName(2, "element_button.png")
        Me.ImageList_Elements.Images.SetKeyName(3, "element_fill.png")
        Me.ImageList_Elements.Images.SetKeyName(4, "element_image.png")
        Me.ImageList_Elements.Images.SetKeyName(5, "element_progressbar.png")
        Me.ImageList_Elements.Images.SetKeyName(6, "element_text.png")
        '
        'frm_Main
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(758, 583)
        Me.Controls.Add(Me.panelContainer1)
        Me.Controls.Add(Me.DockPanel2)
        Me.Controls.Add(Me.DockPanel1)
        Me.Controls.Add(Me.ribbonControl1)
        Me.Name = "frm_Main"
        Me.Ribbon = Me.ribbonControl1
        Me.Text = "Form1"
        CType(Me.ribbonControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DockManager1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.DockPanel1.ResumeLayout(False)
        Me.DockPanel1_Container.ResumeLayout(False)
        Me.DockPanel2.ResumeLayout(False)
        Me.DockPanel2_Container.ResumeLayout(False)
        Me.panelContainer1.ResumeLayout(False)
        Me.DockPanel5.ResumeLayout(False)
        Me.DockPanel5_Container.ResumeLayout(False)
        Me.DockPanel3.ResumeLayout(False)
        Me.DockPanel3_Container.ResumeLayout(False)
        CType(Me.pg_Main, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DocumentManager1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TabbedView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

    Private WithEvents ribbonControl1 As DevExpress.XtraBars.Ribbon.RibbonControl
    Private WithEvents ribbonPage1 As DevExpress.XtraBars.Ribbon.RibbonPage
    Private WithEvents rpg_LoadTheme As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents DockManager1 As DevExpress.XtraBars.Docking.DockManager
    Friend WithEvents DockPanel3 As DevExpress.XtraBars.Docking.DockPanel
    Friend WithEvents DockPanel3_Container As DevExpress.XtraBars.Docking.ControlContainer
    Friend WithEvents DockPanel2 As DevExpress.XtraBars.Docking.DockPanel
    Friend WithEvents DockPanel2_Container As DevExpress.XtraBars.Docking.ControlContainer
    Friend WithEvents DockPanel5 As DevExpress.XtraBars.Docking.DockPanel
    Friend WithEvents DockPanel5_Container As DevExpress.XtraBars.Docking.ControlContainer
    Friend WithEvents DockPanel1 As DevExpress.XtraBars.Docking.DockPanel
    Friend WithEvents DockPanel1_Container As DevExpress.XtraBars.Docking.ControlContainer
    Friend WithEvents RichTextBox1 As RichTextBox
    Friend WithEvents DocumentManager1 As DevExpress.XtraBars.Docking2010.DocumentManager
    Friend WithEvents TabbedView1 As DevExpress.XtraBars.Docking2010.Views.Tabbed.TabbedView
    Friend WithEvents pg_Main As DevExpress.XtraVerticalGrid.PropertyGridControl
    Friend WithEvents SplitterControl1 As DevExpress.XtraEditors.SplitterControl
    Friend WithEvents pgd_Main As DevExpress.XtraVerticalGrid.PropertyDescriptionControl
    Friend WithEvents panelContainer1 As DevExpress.XtraBars.Docking.DockPanel
    Friend WithEvents btn_LoadTheme_TWRES As DevExpress.XtraBars.BarButtonItem
    Friend WithEvents FolderBrowserDialog1 As FolderBrowserDialog
    Friend WithEvents SkinRibbonGalleryBarItem1 As DevExpress.XtraBars.SkinRibbonGalleryBarItem
    Friend WithEvents RibbonPageGroup1 As DevExpress.XtraBars.Ribbon.RibbonPageGroup
    Friend WithEvents Tree_ThemeExplorer As TreeView
    Friend WithEvents ImageList_ThemeExplorer As ImageList
    Friend WithEvents Tree_Elements As TreeView
    Friend WithEvents ImageList_Elements As ImageList
End Class
