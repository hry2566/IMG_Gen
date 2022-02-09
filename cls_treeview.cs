namespace IMG_Gen2;

public partial class cls_treeview : TreeView
{
    private string? folderPath;              // 画像フォルダ名
    private cls_treenode[] treeNode = new cls_treenode[0];          // 

    public cls_treeview()
    {

    }

    public string Path
    {
        set
        {
            this.folderPath = value;
            SetView(value);
        }
        get { return this.folderPath!; }
    }

    private void SetView(string path)
    {
        string[] fPath = System.IO.Directory.GetDirectories(path, "*", System.IO.SearchOption.TopDirectoryOnly);

        for (int i = 0; i < fPath.Length; i++)
        {
            Array.Resize(ref treeNode, treeNode.Length + 1);
            treeNode[treeNode.Length - 1] = new cls_treenode(path, fPath[i]);
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
