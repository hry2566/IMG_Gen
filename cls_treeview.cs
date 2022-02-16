namespace IMG_Gen2;

public partial class cls_treeview : TreeView
{
    private cls_posPicBox picBox1;
    private TabPage PosPage;
    private string? rootPath;                               // ルートフォルダパス
    private cls_treenode[] treeNode = new cls_treenode[0];

    public cls_treeview(cls_posPicBox picBox1, TabPage PosPage)
    {
        this.picBox1 = picBox1;
        this.PosPage = PosPage;
        this.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(SelectChange);
    }
    private void SelectChange(Object? sender, TreeViewEventArgs e)
    {
        if (e.Node!.Text.IndexOf(".") > -1)
        {
            string filePath;
            if (e.Node.Parent != null)
            {
                filePath = rootPath + e.Node.Parent.Text + "\\" + e.Node.Text;
            }
            else
            {
                filePath = rootPath + e.Node.Text;
            }
            picBox1.SetImage(filePath, rootPath!);
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
        string[] fPath = System.IO.Directory.GetDirectories(path, "*", System.IO.SearchOption.TopDirectoryOnly);
        if (fPath.Length == 0)
        {
            System.IO.DirectoryInfo di = new System.IO.DirectoryInfo(path);
            System.IO.FileInfo[] files = di.GetFiles("*.*", System.IO.SearchOption.AllDirectories);
            foreach (System.IO.FileInfo f in files)
            {
                Array.Resize(ref treeNode, treeNode.Length + 1);
                treeNode[treeNode.Length - 1] = new cls_treenode(path, f.FullName);
            }
        }
        else
        {
            for (int i = 0; i < fPath.Length; i++)
            {
                Array.Resize(ref treeNode, treeNode.Length + 1);
                treeNode[treeNode.Length - 1] = new cls_treenode(path, fPath[i]);
            }
        }
        this.Nodes.AddRange(treeNode);
        this.ExpandAll();
    }
    public void Node_Clear()
    {
        treeNode = new cls_treenode[0];
        this.Nodes.Clear();
    }
}
