namespace IMG_Gen2;

public partial class MainForm : Form
{
    public MainForm()
    {
        Directory.CreateDirectory("./ini");
        InitializeComponent();
        InitializeUserComponent();
        Controls_EventHandler();
    }

    // ***********************************************************************
    // MainForm
    // ***********************************************************************
    private void Form_Load(object? sender, EventArgs e)
    {
        ReadAppIni("./ini/IMG_Gen.ini");
        ReadIni("./ini/label.ini", LabelLstView);
        ReadIni("./ini/mask.ini", MaskLstView);
        Image_Split!.SetOpt(RootPathTxtBox.Text, Image_BrightContrast!, Image_RandomNoise!);
        // this.Icon = new System.Drawing.Icon("./Icon2.ico");
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
            RootPathTxtBox.Text = folderBrowserDialog1.SelectedPath + "\\";
            SaveAppIni("./ini/IMG_Gen.ini", folderBrowserDialog1.SelectedPath + "\\");
        }
    }

    // ***********************************************************************
    // MenuTab
    // ***********************************************************************
    private void MenuTab_SelectedIndexChanged(object? sender, EventArgs e)
    {
        switch(MenuTab.SelectedIndex)
        {
            case 0:
                FileTreeView!.Focus();
                break;
            case 1:
                LabelLstView.Focus();
                break;
            case 2:
                MaskLstView.Focus();
                break;
        }
    }

    // ***********************************************************************
    // MaskTab
    // ***********************************************************************
    private void MaskLstView_SelectedIndexChanged(object? sender, EventArgs e)
    {
        TextBox[] textBox = new TextBox[3] { MaskNameTxtBox, MaskColorTxtBox, MaskWidthTxtBox };
        SelectedIndexChanged(textBox, MaskLstView);
    }
    private void MaskEntBtn_Click(Object? sender, EventArgs? e)
    {
        MaskNameTxtBox.Text = "Mask";
        TextBox[] textBox = new TextBox[3] { MaskNameTxtBox, MaskColorTxtBox, MaskWidthTxtBox };
        EntBtn_Click(textBox, MaskLstView);
        SaveIni("./ini/mask.ini", MaskLstView);
    }
    private void MaskModBtn_Click(Object? sender, EventArgs? e)
    {
        TextBox[] textBox = new TextBox[3] { MaskNameTxtBox, MaskColorTxtBox, MaskWidthTxtBox };
        ModBtn_Click(textBox, MaskLstView);
        SaveIni("./ini/mask.ini", MaskLstView);
    }
    private void MaskDelBtn_Click(Object? sender, EventArgs? e)
    {
        DelBtn_Click(MaskLstView);
        SaveIni("./ini/mask.ini", MaskLstView);
    }
    private void MaskColorBtn_Click(Object? sender, EventArgs? e)
    {
        ColorBtn_Click(MaskColorTxtBox);
    }

    // ***********************************************************************
    // LabelTab
    // ***********************************************************************
    private void lblLstView_SelectedIndexChanged(object? sender, EventArgs e)
    {
        TextBox[] textBox = new TextBox[3] { LabelNameTxtBox, LabelColorTxtBox, LabelWidthTxtBox };
        SelectedIndexChanged(textBox, LabelLstView);
    }
    private void LabelEntBtn_Click(Object? sender, EventArgs? e)
    {
        TextBox[] textBox = new TextBox[3] { LabelNameTxtBox, LabelColorTxtBox, LabelWidthTxtBox };
        EntBtn_Click(textBox, LabelLstView);
        SaveIni("./ini/label.ini", LabelLstView);
        Image_Split!.CheckLabel();
    }
    private void LabelModBtn_Click(Object? sender, EventArgs? e)
    {
        TextBox[] textBox = new TextBox[3] { LabelNameTxtBox, LabelColorTxtBox, LabelWidthTxtBox };
        ModBtn_Click(textBox, LabelLstView);
        SaveIni("./ini/label.ini", LabelLstView);
        Image_Split!.CheckLabel();

    }
    private void LabelDelBtn_Click(Object? sender, EventArgs? e)
    {
        DelBtn_Click(LabelLstView);
        SaveIni("./ini/label.ini", LabelLstView);
        Image_Split!.CheckLabel();
    }
    private void LabelColorBtn_Click(Object? sender, EventArgs? e)
    {
        ColorBtn_Click(LabelColorTxtBox);
    }

    // ViewTab
    private void ViewTab_SelectedIndexChanged(Object? sender, EventArgs? e)
    {
        switch (ViewTab.SelectedIndex)
        {
            case 0:
                break;
            case 1:
                this.SplitContainer1.Panel2.Controls.Add(this.PicBox2);
                break;
            case 2:
                this.SplitContainer2.Panel2.Controls.Add(this.PicBox2);
                break;
        }
        MenuTab_SelectedIndexChanged(null,null!);
    }

    // ImageTab
    private void ImageTab_SelectedIndexChanged(Object? sender, EventArgs? e)
    {
        MenuTab_SelectedIndexChanged(null,null!);
    }

    // SplitTab
    private void SplitTab_SelectedIndexChanged(Object? sender, EventArgs? e)
    {
        MenuTab_SelectedIndexChanged(null,null!);
    }

    // ***********************************************************************
    // 関数
    // ***********************************************************************
    private void ReadAppIni(string iniFileName)
    {
        if (!cls_posPicBox.CheckFile(iniFileName)) { return; }
        StreamReader sr = new StreamReader(iniFileName);
        while (!sr.EndOfStream)
        {
            string? line = sr.ReadLine();
            string[] values = line!.Split(":::");
            switch (values[0])
            {
                case "rootpath":
                    RootPathTxtBox.Text = values[1];
                    FileTreeView!.Path = RootPathTxtBox.Text;
                    break;
            }
        }
        sr.Close();
    }
    private void SaveAppIni(string iniFileName, string rootPath)
    {
        StreamWriter sw = new StreamWriter(iniFileName, false);
        sw.WriteLine("rootpath:::" + RootPathTxtBox.Text);
        sw.Close();
    }
    private void ReadIni(string iniFileName, ListView listview)
    {
        if (!cls_posPicBox.CheckFile(iniFileName)) { return; }
        StreamReader sr = new StreamReader(iniFileName);
        while (!sr.EndOfStream)
        {
            string? line = sr.ReadLine();
            string[] values = line!.Split(',');
            ListViewItem item = new();

            item = listview.Items.Add(values[0]);
            item.SubItems.Add(values[1]);
            item.SubItems.Add(values[2]);
            item.UseItemStyleForSubItems = false;
            item.SubItems[1].BackColor = cls_posPicBox.String2Color(values[1]);
        }
        sr.Close();
    }
    private void SaveIni(string iniFileName, ListView listview)
    {
        StreamWriter sw = new StreamWriter(iniFileName);
        for (int i = 0; i < listview.Items.Count; i++)
        {
            sw.WriteLine(listview.Items[i].SubItems[0].Text + "," +
                         listview.Items[i].SubItems[1].Text + "," +
                         listview.Items[i].SubItems[2].Text);
        }
        sw.Flush();
        sw.Close();
    }
    private void SelectedIndexChanged(TextBox[] textBox, ListView listview)
    {
        if (listview.SelectedItems.Count == 0) { return; }
        for (int i = 0; i < 3; i++)
        {
            textBox[i].Text = listview.SelectedItems[0].SubItems[i].Text;
        }
    }
    private void EntBtn_Click(TextBox[] textBox, ListView listview)
    {
        if (textBox[0].Text == "") { return; }
        ListViewItem item;
        item = listview.Items.Add(textBox[0].Text);
        item.SubItems.Add(textBox[1].Text);
        item.SubItems.Add(textBox[2].Text);
        item.UseItemStyleForSubItems = false;
        item.SubItems[1].BackColor = cls_posPicBox.String2Color(textBox[1].Text);
        listview.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
    }
    private void ModBtn_Click(TextBox[] textBox, ListView listview)
    {
        if (listview.SelectedItems.Count == 0) { return; }
        for (int i = 0; i < 3; i++)
        {
            listview.SelectedItems[0].SubItems[i].Text = textBox[i].Text;
        }
        listview.SelectedItems[0].UseItemStyleForSubItems = false;
        listview.SelectedItems[0].SubItems[1].BackColor = cls_posPicBox.String2Color(textBox[1].Text);
        listview.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
    }
    private void DelBtn_Click(ListView listView)
    {
        if (listView.SelectedItems.Count == 0) { return; }
        listView.Items[listView.SelectedItems[0].Index].Remove();
        listView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
    }
    private void ColorBtn_Click(TextBox textbox)
    {
        ColorDialog cd = new ColorDialog();
        cd.AllowFullOpen = true;
        cd.SolidColorOnly = false;

        if (cd.ShowDialog() == DialogResult.OK)
        {
            textbox.Text = cd.Color.Name;
        }
    }
}
