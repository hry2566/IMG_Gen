namespace IMG_Gen2;

public partial class MainForm : Form
{
    private cls_treeview? FileTreeView;
    private cls_posPicBox? PosPicBox;
    private ToolStripStatusLabel? sLabel1;
    private ToolStripStatusLabel? sLabel2;
    public MainForm()
    {
        InitializeComponent();
        InitializeUserComponent();
        Controls_EventHandler();
    }

    private void InitializeUserComponent()
    {
        //sLabel1
        this.sLabel1 = new ToolStripStatusLabel();
        this.sLabel1.Text = "sLabel1";
        this.StatusStrip1.Items.Add(sLabel1);

        //sLabel2
        this.sLabel2 = new ToolStripStatusLabel();
        this.sLabel2.Text = "sLabel2";
        this.StatusStrip2.Items.Add(sLabel2);

        //
        // PicBox1
        //
        this.PosPicBox = new cls_posPicBox(PosPage, sLabel2!);
        this.PosPicBox.TabIndex = 22;
        this.PosPicBox.Text = "PictureBox0";
        this.PosPicBox.AutoSize = true;
        this.PosPicBox.BackColor = System.Drawing.Color.Silver;
        this.PosPicBox.Name = "PicBox1";
        this.PosPicBox.Dock = System.Windows.Forms.DockStyle.Fill;
        this.PosPage.Controls.Add(this.PosPicBox);

        //
        // FileTreeView
        //
        this.FileTreeView = new cls_treeview(PosPicBox!, PosPage);
        this.FileTreeView.ItemHeight = 22;
        this.FileTreeView.LineColor = System.Drawing.Color.Black;
        this.FileTreeView.Text = "TreeView2";
        this.FileTreeView.Dock = System.Windows.Forms.DockStyle.Fill;
        this.FileTreeView.Name = "FileTreeView";
        this.FileTreeView.Size = new System.Drawing.Size(207, 662);
        this.FileTreeView.TabIndex = 23;
        this.FilePage.Controls.Add(this.FileTreeView);
    }

    private void Controls_EventHandler()
    {
        RootSelectBtn.Click += new EventHandler(RootSelectBtn_Click);

    }

    private void RootSelectBtn_Click(Object? sender, EventArgs? e)
    {
        FileTreeView!.Node_Clear();

        FolderBrowserDialog folderBrowserDialog1 = new FolderBrowserDialog(); ;
        folderBrowserDialog1.RootFolder = Environment.SpecialFolder.Desktop;
        folderBrowserDialog1.ShowNewFolderButton = true;

        if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
        {
            FileTreeView.Path = folderBrowserDialog1.SelectedPath + "\\";
            RootPathTxtBox.Text = FileTreeView.Path;
        }
    }

}
