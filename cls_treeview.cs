namespace IMG_Gen2;

public partial class cls_treeview : TreeView
{
    private cls_posPicBox picBox1;
    private TabControl ViewTab;
    private cls_image_BrightContrast Image_BrightContrast;
    private cls_image_RandomNoise? Image_RandomNoise;
    private cls_image_Split? Image_Split;
    private string? rootPath;                               // ルートフォルダパス
    private cls_treenode[] treeNode = new cls_treenode[0];

    public cls_treeview(cls_posPicBox picBox1, TabControl ViewTab, cls_image_BrightContrast Image_BrightContrast, cls_image_RandomNoise Image_RandomNoise, cls_image_Split Image_Split)
    {
        this.picBox1 = picBox1;
        this.ViewTab = ViewTab;
        this.Image_BrightContrast = Image_BrightContrast;
        this.Image_RandomNoise = Image_RandomNoise;
        this.Image_Split = Image_Split;
        this.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(SelectChange);
        this.ViewTab.SelectedIndexChanged += new EventHandler(ViewTab_SelectedIndexChanged);
    }
    private void ViewTab_SelectedIndexChanged(Object? sender, EventArgs e)
    {
        if(this.SelectedNode==null){return;}
        string filePath = rootPath + this.SelectedNode.FullPath;
        SwitchImage(ViewTab.SelectedIndex, filePath);
    }
    private void SwitchImage(int selectIndex, string filePath)
    {
        if (!System.IO.File.Exists(filePath)) { return; }
        
        switch(ViewTab.SelectedIndex)
        {
            case 0:
                picBox1.SetImage(filePath, rootPath!);
                break;
            case 1:
                Image_BrightContrast.SetImage(filePath);
                Image_RandomNoise!.SetImage(filePath);
                break;
            case 2:
                Image_Split!.SetImage(filePath, rootPath!);
                break;
        }
    }
    private void SelectChange(Object? sender, TreeViewEventArgs e)
    {
        if (e.Node!.Text.IndexOf(".") > -1)
        {
            string filePath = rootPath + e.Node!.FullPath;
            SwitchImage(ViewTab.SelectedIndex, filePath);
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
