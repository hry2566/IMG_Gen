namespace IMG_Gen2
{
    public class cls_image_Split
    {
        private string? filePath;
        private TextBox? ImageWidthTxtBox;
        private TextBox? ImageHeightTxtBox;
        private TextBox? SplitWidthTxtBox;
        private TextBox? SplitHeightTxtBox;
        private TextBox? WrapWidthTxtBox;
        private TextBox? WrapHeightTxtBox;
        private TextBox? SplitCntTxtBox1;
        private CheckBox? RndSplitRadioBtn;
        private Button? SplitPreviewBtn;
        private TextBox? SplitCntTxtBox2;
        private DataGridView? SplitCntDataGridView;
        private Button? RunSplitBtn;
        private Button? StopSplitBtn;
        private PictureBox? PicBox2;
        private Boolean readFlag = false;

        public cls_image_Split(List<Control> splitCtrl)
        {
            ImageWidthTxtBox = splitCtrl[0] as TextBox;
            ImageHeightTxtBox = splitCtrl[1] as TextBox;
            SplitWidthTxtBox = splitCtrl[2] as TextBox;
            SplitHeightTxtBox = splitCtrl[3] as TextBox;
            WrapWidthTxtBox = splitCtrl[4] as TextBox;
            WrapHeightTxtBox = splitCtrl[5] as TextBox;
            SplitCntTxtBox1 = splitCtrl[6] as TextBox;
            RndSplitRadioBtn = splitCtrl[7] as CheckBox;
            SplitPreviewBtn = splitCtrl[8] as Button;
            SplitCntTxtBox2 = splitCtrl[9] as TextBox;
            SplitCntDataGridView = splitCtrl[10] as DataGridView;
            RunSplitBtn = splitCtrl[11] as Button;
            StopSplitBtn = splitCtrl[12] as Button;
            PicBox2 = splitCtrl[13] as PictureBox;

            ImageWidthTxtBox!.Text = "";
            ImageHeightTxtBox!.Text = "";
            SplitWidthTxtBox!.Text = "";
            SplitHeightTxtBox!.Text = "";
            WrapWidthTxtBox!.Text = "";
            WrapHeightTxtBox!.Text = "";
            SplitCntTxtBox1!.Text = "";
            SplitCntTxtBox2!.Text = "";

            SplitCntDataGridView!.ColumnCount = 3;

            SplitCntDataGridView.Columns[0].HeaderText = "ラベル";
            SplitCntDataGridView.Columns[1].HeaderText = "設定数";
            SplitCntDataGridView.Columns[2].HeaderText = "作成済";
            SplitCntDataGridView.RowHeadersVisible = false;
            SplitCntDataGridView.Columns[0].ReadOnly = true;
            SplitCntDataGridView.Columns[2].ReadOnly = true;
            SplitCntDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            SplitCntDataGridView.CellValueChanged += new DataGridViewCellEventHandler(SplitCntDataGridView_CellValueChanged);
            SplitWidthTxtBox.TextChanged += new EventHandler(TxtChanged);
            SplitHeightTxtBox.TextChanged += new EventHandler(TxtChanged);
            WrapWidthTxtBox.TextChanged += new EventHandler(TxtChanged);
            WrapHeightTxtBox.TextChanged += new EventHandler(TxtChanged);
            RndSplitRadioBtn!.CheckedChanged += new EventHandler(TxtChanged);

            CheckLabel();
            ReadIni("./image_split.ini");
        }
        private void ReadIni(string filePath)
        {
            if (!cls_posPicBox.CheckFile(filePath)) { return; }
            readFlag = true;
            StreamReader sr = new(filePath);
            string[] split = sr.ReadLine()!.Split(":");
            SplitWidthTxtBox!.Text = split[1];
            split = sr.ReadLine()!.Split(":");
            SplitHeightTxtBox!.Text = split[1];
            split = sr.ReadLine()!.Split(":");
            WrapWidthTxtBox!.Text = split[1];
            split = sr.ReadLine()!.Split(":");
            WrapHeightTxtBox!.Text = split[1];
            split = sr.ReadLine()!.Split(":");
            RndSplitRadioBtn!.Checked = System.Convert.ToBoolean(split[1]);

            sr.Close();
            readFlag = false;
        }
        private void TxtChanged(object? sender, EventArgs e)
        {
            if (readFlag) { return; }
            StreamWriter sw = new("./image_split.ini");
            sw.WriteLine("SplitWidth:" + SplitWidthTxtBox!.Text);
            sw.WriteLine("SplitHeight:" + SplitHeightTxtBox!.Text);
            sw.WriteLine("WrapWidth:" + WrapWidthTxtBox!.Text);
            sw.WriteLine("WrapHeight:" + WrapHeightTxtBox!.Text);
            sw.WriteLine("RandomChkBox:" + RndSplitRadioBtn!.Checked.ToString());
            sw.Close();
        }
        internal void CheckLabel()
        {
            List<string> labelName1 = new();
            List<string> labelName2 = new();
            List<string> labelName3 = new();
            labelName3.Add("OK,1000,0");

            if (cls_posPicBox.CheckFile("./label.ini"))
            {
                StreamReader sr = new("./label.ini");
                while (!sr.EndOfStream)
                {
                    string[] split = sr.ReadLine()!.Split(",");
                    bool skipFlag = true;
                    for (int i = 0; i < labelName1.Count; i++)
                    {
                        if (labelName1[i] == split[0])
                        {
                            skipFlag = false;
                        }
                    }
                    if (skipFlag)
                    {
                        labelName1.Add(split[0]);
                    }
                }
                sr.Close();
            }

            if (cls_posPicBox.CheckFile("./image_split_label.ini"))
            {
                StreamReader sr = new("./image_split_label.ini");
                while (!sr.EndOfStream)
                {
                    string? line = sr.ReadLine();
                    labelName2.Add(line!);
                }
                sr.Close();
            }

            for (int i = 0; i < labelName1.Count; i++)
            {
                bool addFlag = true;
                for (int j = 0; j < labelName2.Count; j++)
                {
                    string[] split = labelName2[j].Split(",");
                    if (labelName1[i] == split[0])
                    {
                        labelName3.Add(labelName2[j]);
                        addFlag = false;
                        break;
                    }
                }
                if (addFlag)
                {
                    labelName3.Add(labelName1[i] + ",0,0");
                }
            }

            StreamWriter sw = new("./image_split_label.ini");
            for (int i = 0; i < labelName3.Count; i++)
            {
                sw.WriteLine(labelName3[i]);
            }
            sw.Close();

            ReadLabelIni("./image_split_label.ini");
        }
        private void SplitCntDataGridView_CellValueChanged(object? sender, DataGridViewCellEventArgs e)
        {
            if (SplitCntDataGridView!.Rows[e.RowIndex].Cells[0].Value.ToString() == "") { return; }
            SaveIni("./image_split_label.ini");
        }
        private void SaveIni(string iniFileName)
        {
            StreamWriter sw = new(iniFileName);
            for (int i = 0; i < SplitCntDataGridView!.RowCount - 1; i++)
            {
                string str = SplitCntDataGridView.Rows[i].Cells[0].Value.ToString() + ",";
                str += SplitCntDataGridView.Rows[i].Cells[1].Value.ToString() + ",";
                str += SplitCntDataGridView.Rows[i].Cells[2].Value.ToString();
                sw.WriteLine(str);
            }
            sw.Close();
        }
        private void ReadLabelIni(string iniFileName)
        {
            if (!cls_posPicBox.CheckFile(iniFileName)) { return; }

            SplitCntDataGridView!.Rows.Clear();

            StreamReader sr = new(iniFileName);
            while (!sr.EndOfStream)
            {
                string[] split = sr.ReadLine()!.Split(",");
                SplitCntDataGridView!.Rows.Add(split[0], split[1], 0);
            }
            sr.Close();
        }
        internal void SetImage(string filePath)
        {
            this.filePath = filePath;
            ImageWidthTxtBox!.Text = PicBox2!.Image.Width.ToString();
            ImageHeightTxtBox!.Text = PicBox2.Image.Height.ToString();
        }
    }
}