namespace IMG_Gen2;

public partial class MainForm : Form
{
    private cls_treeview? FileTreeView;
    private cls_posPicBox? PosPicBox;
    public MainForm()
    {
        InitializeComponent();
        InitializeUserComponent();
        Controls_EventHandler();
    }

    private void InitializeUserComponent()
    {
        //
        // PicBox1
        //
        this.PosPicBox = new cls_posPicBox(PosPage);
        this.PosPicBox.TabIndex = 22;
        this.PosPicBox.Text = "PictureBox0";
        this.PosPicBox.AutoSize = true;
        this.PosPicBox.BackColor = System.Drawing.Color.White;
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
