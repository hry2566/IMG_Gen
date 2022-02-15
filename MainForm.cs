using Microsoft.Win32.SafeHandles;
namespace IMG_Gen2;

public partial class MainForm : Form
{
    public MainForm()
    {
        InitializeComponent();
        InitializeUserComponent();
        Controls_EventHandler();
    }
    private void Form_Load(object? sender, EventArgs e)
    {
        ReadIni("./label.ini", LabelLstView);
        ReadIni("./mask.ini", MaskLstView);
    }

    private void ReadIni(string iniFileName, ListView listview)
    {
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
            item.SubItems[1].BackColor = String2Color(values[1]);
        }
        sr.Close();
    }
    private void MaskModBtn_Click(Object? sender, EventArgs? e)
    {
        TextBox[] textBox = new TextBox[3] { MaskNameTxtBox, MaskColorTxtBox, MaskWidthTxtBox };
        ModBtn_Click(textBox, MaskLstView);
        SaveIni("./mask.ini", MaskLstView);
    }
    private void LabelModBtn_Click(Object? sender, EventArgs? e)
    {
        TextBox[] textBox = new TextBox[3] { LabelNameTxtBox, LabelColorTxtBox, LabelWidthTxtBox };
        ModBtn_Click(textBox, LabelLstView);
        SaveIni("./label.ini", LabelLstView);
    }

    private void ModBtn_Click(TextBox[] textBox, ListView listview)
    {
        if (listview.SelectedItems.Count == 0) { return; }

        listview.SelectedItems[0].SubItems[0].Text = textBox[0].Text;
        listview.SelectedItems[0].SubItems[1].Text = textBox[1].Text;
        listview.SelectedItems[0].SubItems[2].Text = textBox[2].Text;
        listview.SelectedItems[0].UseItemStyleForSubItems = false;
        listview.SelectedItems[0].SubItems[1].BackColor = String2Color(textBox[1].Text);
        listview.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
    }

    private void lblLstView_SelectedIndexChanged(object? sender, EventArgs e)
    {
        TextBox[] textBox = new TextBox[3] { LabelNameTxtBox, LabelColorTxtBox, LabelWidthTxtBox };
        SelectedIndexChanged(textBox, LabelLstView);
    }
    private void MaskLstView_SelectedIndexChanged(object? sender, EventArgs e)
    {
        TextBox[] textBox = new TextBox[3] { MaskNameTxtBox, MaskColorTxtBox, MaskWidthTxtBox };
        SelectedIndexChanged(textBox, MaskLstView);
    }
    private void SelectedIndexChanged(TextBox[] textBox, ListView listview)
    {
        if (listview.SelectedItems.Count == 0) { return; }

        textBox[0].Text = listview.SelectedItems[0].SubItems[0].Text;
        textBox[1].Text = listview.SelectedItems[0].SubItems[1].Text;
        textBox[2].Text = listview.SelectedItems[0].SubItems[2].Text;
    }

    private void MaskDelBtn_Click(Object? sender, EventArgs? e)
    {
        DelBtn_Click(MaskLstView);
        SaveIni("./mask.ini", MaskLstView);
    }
    private void LabelDelBtn_Click(Object? sender, EventArgs? e)
    {
        DelBtn_Click(LabelLstView);
        SaveIni("./label.ini", LabelLstView);
    }
    private void DelBtn_Click(ListView listView)
    {
        if (listView.SelectedItems.Count == 0) { return; }

        listView.Items[listView.SelectedItems[0].Index].Remove();
        listView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
    }

    private void LabelEntBtn_Click(Object? sender, EventArgs? e)
    {
        TextBox[] textBox = new TextBox[3] { LabelNameTxtBox, LabelColorTxtBox, LabelWidthTxtBox };
        EntBtn_Click(textBox, LabelLstView);
        SaveIni("./label.ini", LabelLstView);
    }

    private void MaskEntBtn_Click(Object? sender, EventArgs? e)
    { 
        TextBox[] textBox = new TextBox[3] { MaskNameTxtBox, MaskColorTxtBox, MaskWidthTxtBox };
        EntBtn_Click(textBox, MaskLstView);
        SaveIni("./mask.ini", MaskLstView);
    }

    private void EntBtn_Click(TextBox[] textBox, ListView listview)
    {
        if (textBox[0].Text == "") { return; }

        ListViewItem item;
        item = listview.Items.Add(textBox[0].Text);
        item.SubItems.Add(textBox[1].Text);
        item.SubItems.Add(textBox[2].Text);
        item.UseItemStyleForSubItems = false;
        item.SubItems[1].BackColor = String2Color(textBox[1].Text);
        listview.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
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
    private void MaskColorBtn_Click(Object? sender, EventArgs? e)
    {
        ColorDialog cd = new ColorDialog();
        cd.AllowFullOpen = true;
        cd.SolidColorOnly = false;

        if (cd.ShowDialog() == DialogResult.OK)
        {
            MaskColorTxtBox.Text = cd.Color.Name;
        }
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
