namespace IMG_Gen2;

public partial class cls_treeview : TreeView
{
    PictureBox picBox1;
    private string? folderPath;              // ルートフォルダパス
    private cls_treenode[] treeNode = new cls_treenode[0];

    public cls_treeview(PictureBox picBox1)
    {
        this.picBox1 = picBox1;
        this.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(SelectChange);
    }

    private void SelectChange(Object? sender, TreeViewEventArgs e)
    {
        // Console.WriteLine(e.Node.Parent.Text);
        if (e.Node!.Text.IndexOf(".") > -1)
        {
            string filepath = folderPath + e.Node.Parent.Text + "\\" + e.Node.Text;
            Image img = new Bitmap(filepath);

            // picBox1.ImageLocation = filepath;
            picBox1.Image = img;
            // Console.WriteLine(filepath);


        }
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
