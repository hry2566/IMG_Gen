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

        //
        // LabelLstView
        //
        LabelLstView.FullRowSelect = true;

        ColumnHeader[] column = new ColumnHeader[3];
        for (int i = 0; i < column.Count(); i++)
        {
            column[i] = new();
        }
        // column[0].Width = -2;
        // column[1].Width = -2;
        // column[2].Width = -2;
        column[0].Text = "ラベル";
        column[1].Text = "線色";
        column[2].Text = "線幅";
        this.LabelLstView.Columns.AddRange(column);

        ListViewItem item;

        item = LabelLstView.Items.Add("NG");
        item.SubItems.Add("Color [Red]");
        item.SubItems.Add("1");
        item.UseItemStyleForSubItems = false;
        item.SubItems[1].BackColor = Color.Red;
    }

    private void Controls_EventHandler()
    {
        //
        // RootSelectBtn
        //
        RootSelectBtn.Click += new EventHandler(RootSelectBtn_Click);

        //
        // LabelColorBtn
        //
        LabelColorBtn.Click += new EventHandler(LabelColorBtn_Click);

        //
        // LabelEntBtn
        //
        LabelEntBtn.Click += new EventHandler(LabelEntBtn_Click);

    }

    private void LabelEntBtn_Click(Object? sender, EventArgs? e)
    {
        ListViewItem item;
        item = LabelLstView.Items.Add(LabelNameTxtBox.Text);
        item.SubItems.Add(LabelColorTxtBox.Text);
        item.SubItems.Add(LabelWidthTxtBox.Text);
        item.UseItemStyleForSubItems = false;
        item.SubItems[1].BackColor = Color.Blue;

        LabelLstView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
    }
    private void LabelColorBtn_Click(Object? sender, EventArgs? e)
    {
        //ColorDialogクラスのインスタンスを作成
        ColorDialog cd = new ColorDialog();

        //はじめに選択されている色を設定
        // cd.Color = TextBox1.BackColor;
        //色の作成部分を表示可能にする
        //デフォルトがTrueのため必要はない
        cd.AllowFullOpen = true;
        //純色だけに制限しない
        //デフォルトがFalseのため必要はない
        cd.SolidColorOnly = false;
        //[作成した色]に指定した色（RGB値）を表示する
        // cd.CustomColors = new int[] {
        //                             0x33, 0x66, 0x99, 0xCC, 0x3300, 0x3333,
        //                             0x3366, 0x3399, 0x33CC, 0x6600, 0x6633,
        //                             0x6666, 0x6699, 0x66CC, 0x9900, 0x9933};

        //ダイアログを表示する
        if (cd.ShowDialog() == DialogResult.OK)
        {
            //選択された色の取得
            LabelColorTxtBox.Text = cd.Color.ToString();
        }
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
