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

        sr = new StreamReader("./mask.ini");
        item = new();

        while (!sr.EndOfStream)
        {
            string? line = sr.ReadLine();
            string[] values = line!.Split(',');

            item = new();
            item = MaskLstView.Items.Add(values[0]);
            item.SubItems.Add(values[1]);
            item.SubItems.Add(values[2]);
            item.UseItemStyleForSubItems = false;
            item.SubItems[1].BackColor = String2Color(values[1]);
        }
        sr.Close();
    }
    private void MaskModBtn_Click(Object? sender, EventArgs? e)
    {
        if (MaskLstView.SelectedItems.Count == 0) { return; }

        MaskLstView.SelectedItems[0].SubItems[0].Text = MaskNameTxtBox.Text;
        MaskLstView.SelectedItems[0].SubItems[1].Text = MaskColorTxtBox.Text;
        MaskLstView.SelectedItems[0].SubItems[2].Text = MaskWidthTxtBox.Text;
        MaskLstView.SelectedItems[0].UseItemStyleForSubItems = false;
        MaskLstView.SelectedItems[0].SubItems[1].BackColor = String2Color(MaskColorTxtBox.Text);

        MaskLstView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        SavaMaskIni();
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
    private void MaskDelBtn_Click(Object? sender, EventArgs? e)
    {
        if (MaskLstView.SelectedItems.Count == 0) { return; }

        MaskLstView.Items[MaskLstView.SelectedItems[0].Index].Remove();

        MaskLstView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        SavaMaskIni();
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

    private void MaskEntBtn_Click(Object? sender, EventArgs? e)
    { 
        if (MaskNameTxtBox.Text == "") { return; }

        ListViewItem item;
        item = MaskLstView.Items.Add(MaskNameTxtBox.Text);
        item.SubItems.Add(MaskColorTxtBox.Text);
        item.SubItems.Add(MaskWidthTxtBox.Text);
        item.UseItemStyleForSubItems = false;
        item.SubItems[1].BackColor = String2Color(MaskColorTxtBox.Text);

        MaskLstView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        SavaMaskIni();
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
    private void SavaMaskIni()
    {
        StreamWriter sw = new StreamWriter("./mask.ini");

        for (int i = 0; i < MaskLstView.Items.Count; i++)
        {
            sw.WriteLine(MaskLstView.Items[i].SubItems[0].Text + "," +
                         MaskLstView.Items[i].SubItems[1].Text + "," +
                         MaskLstView.Items[i].SubItems[2].Text);
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
