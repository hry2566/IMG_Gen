namespace IMG_Gen2;

public partial class cls_treeview : TreeView
{
    private cls_posPicBox picBox1;
    private TabPage PosPage;
    private cls_image_BrightContrast Image_BrightContrast;
    private string? rootPath;                               // ルートフォルダパス
    private cls_treenode[] treeNode = new cls_treenode[0];

    public cls_treeview(cls_posPicBox picBox1, TabPage PosPage, cls_image_BrightContrast Image_BrightContrast)
    {
        this.picBox1 = picBox1;
        this.PosPage = PosPage;
        this.Image_BrightContrast = Image_BrightContrast;
        this.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(SelectChange);
    }
    private void SelectChange(Object? sender, TreeViewEventArgs e)
    {
        if (e.Node!.Text.IndexOf(".") > -1)
        {
            string filePath = rootPath + e.Node!.FullPath;

            if (!System.IO.File.Exists(filePath)) { return; }
            picBox1.SetImage(filePath, rootPath!);
            Image_BrightContrast.SetImage(filePath);
        }
    }
    internal string Path
    {
        set
        {
            if (!cls_posPicBox.CheckFolder(value)) { return; }
            this.rootPath = value;
            SetView(value);
        }
        get { return this.rootPath!; }
    }
    private void SetView(string path)
    {
        string[] subFolders = System.IO.Directory.GetDirectories(
                path, "*", System.IO.SearchOption.TopDirectoryOnly);

        for (int i = 0; i < subFolders.Length; i++)
        {
            string[] split = subFolders[i].Split("\\");
            string folderName = split[split.Length - 1];

            if (folderName != "pos" && folderName != "mask" && folderName != "split")
            {
                Array.Resize(ref treeNode, treeNode.Length + 1);
                treeNode[treeNode.Length - 1] = new(folderName, path);
            }
        }
        this.Nodes.AddRange(treeNode);
        treeNode = cls_treenode.AddFileNode(path, "*.jpg");
        this.Nodes.AddRange(treeNode);
        treeNode = cls_treenode.AddFileNode(path, "*.bmp");
        this.Nodes.AddRange(treeNode);
        treeNode = cls_treenode.AddFileNode(path, "*.png");
        this.Nodes.AddRange(treeNode);
        treeNode = cls_treenode.AddFileNode(path, "*.gif");
        this.Nodes.AddRange(treeNode);
        this.ExpandAll();
    }
    public void Node_Clear()
    {
        treeNode = new cls_treenode[0];
        this.Nodes.Clear();
    }
}
