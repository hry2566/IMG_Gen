using Microsoft.Win32.SafeHandles;
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

        // PicBox1
        this.PosPicBox = new cls_posPicBox(PosPage, sLabel2!);
        this.PosPicBox.TabIndex = 22;
        this.PosPicBox.Text = "PictureBox0";
        this.PosPicBox.AutoSize = true;
        this.PosPicBox.BackColor = System.Drawing.Color.Silver;
        this.PosPicBox.Name = "PicBox1";
        this.PosPicBox.Dock = System.Windows.Forms.DockStyle.Fill;
        this.PosPage.Controls.Add(this.PosPicBox);

        // FileTreeView
        this.FileTreeView = new cls_treeview(PosPicBox!, PosPage);
        this.FileTreeView.ItemHeight = 22;
        this.FileTreeView.LineColor = System.Drawing.Color.Black;
        this.FileTreeView.Text = "TreeView2";
        this.FileTreeView.Dock = System.Windows.Forms.DockStyle.Fill;
        this.FileTreeView.Name = "FileTreeView";
        this.FileTreeView.Size = new System.Drawing.Size(207, 662);
        this.FileTreeView.TabIndex = 23;
        this.FilePage.Controls.Add(this.FileTreeView);

        // LabelLstView
        ColumnHeader[] column = new ColumnHeader[3];
        for (int i = 0; i < column.Count(); i++)
        {
            column[i] = new();
        }
        column[0].Text = "ラ　ベ　ル";
        column[1].Text = "線　色";
        column[2].Text = "線　幅";
        this.LabelLstView.Columns.AddRange(column);
        LabelLstView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
    }

    private void Controls_EventHandler()
    {
        // this
        this.Load += new EventHandler(Form_Load);

        LabelLstView.SelectedIndexChanged += new EventHandler(lblLstView_SelectedIndexChanged);

        // RootSelectBtn
        RootSelectBtn.Click += new EventHandler(RootSelectBtn_Click);

        // LabelColorBtn
        LabelColorBtn.Click += new EventHandler(LabelColorBtn_Click);

        // LabelEntBtn
        LabelEntBtn.Click += new EventHandler(LabelEntBtn_Click);

        // LabelDelBtn
        LabelDelBtn.Click += new EventHandler(LabelDelBtn_Click);

        //LabelModBtn
        LabelModBtn.Click += new EventHandler(LabelModBtn_Click);

    }

    private void Form_Load(object? sender, EventArgs e)
    {
        StreamReader sr = new StreamReader("./label.ini");
        ListViewItem item;

        while (!sr.EndOfStream)
        {
            string? line = sr.ReadLine();
            string[] values = line!.Split(',');

            item = new();
            item = LabelLstView.Items.Add(values[0]);
            item.SubItems.Add(values[1]);
            item.SubItems.Add(values[2]);
            item.UseItemStyleForSubItems = false;
            item.SubItems[1].BackColor = String2Color(values[1]);
        }
        sr.Close();
    }

    private void LabelModBtn_Click(Object? sender, EventArgs? e)
    {
        if (LabelLstView.SelectedItems.Count == 0) { return; }

        LabelLstView.SelectedItems[0].SubItems[0].Text = LabelNameTxtBox.Text;
        LabelLstView.SelectedItems[0].SubItems[1].Text = LabelColorTxtBox.Text;
        LabelLstView.SelectedItems[0].SubItems[2].Text = LabelWidthTxtBox.Text;
        LabelLstView.SelectedItems[0].UseItemStyleForSubItems = false;
        LabelLstView.SelectedItems[0].SubItems[1].BackColor = String2Color(LabelColorTxtBox.Text);

        LabelLstView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        SavaLabelIni();
    }

    private void lblLstView_SelectedIndexChanged(object? sender, EventArgs e)
    {
        if (LabelLstView.SelectedItems.Count == 0) { return; }

        LabelNameTxtBox.Text = LabelLstView.SelectedItems[0].SubItems[0].Text;
        LabelColorTxtBox.Text = LabelLstView.SelectedItems[0].SubItems[1].Text;
        LabelWidthTxtBox.Text = LabelLstView.SelectedItems[0].SubItems[2].Text;
    }

    private void LabelDelBtn_Click(Object? sender, EventArgs? e)
    {
        if (LabelLstView.SelectedItems.Count == 0) { return; }

        LabelLstView.Items[LabelLstView.SelectedItems[0].Index].Remove();

        LabelLstView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        SavaLabelIni();
    }

    private void LabelEntBtn_Click(Object? sender, EventArgs? e)
    {
        if (LabelNameTxtBox.Text == "") { return; }

        ListViewItem item;
        item = LabelLstView.Items.Add(LabelNameTxtBox.Text);
        item.SubItems.Add(LabelColorTxtBox.Text);
        item.SubItems.Add(LabelWidthTxtBox.Text);
        item.UseItemStyleForSubItems = false;
        item.SubItems[1].BackColor = String2Color(LabelColorTxtBox.Text);

        LabelLstView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        SavaLabelIni();
    }

    private void SavaLabelIni()
    {
        StreamWriter sw = new StreamWriter("./label.ini");

        for (int i = 0; i < LabelLstView.Items.Count; i++)
        {
            sw.WriteLine(LabelLstView.Items[i].SubItems[0].Text + "," +
                         LabelLstView.Items[i].SubItems[1].Text + "," +
                         LabelLstView.Items[i].SubItems[2].Text);
        }
        sw.Flush();
        sw.Close();
    }
    private void LabelColorBtn_Click(Object? sender, EventArgs? e)
    {
        ColorDialog cd = new ColorDialog();
        cd.AllowFullOpen = true;
        cd.SolidColorOnly = false;

        if (cd.ShowDialog() == DialogResult.OK)
        {
            LabelColorTxtBox.Text = cd.Color.Name;
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

    private Color String2Color(string strColor)
    {
        Color color;

        try
        {
            color = ColorTranslator.FromHtml(strColor);
        }
        catch
        {
            strColor = "#" + strColor;
            color = ColorTranslator.FromHtml(strColor);
        }
        return color;
    }

}
