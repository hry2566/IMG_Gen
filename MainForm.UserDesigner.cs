namespace IMG_Gen2;

partial class MainForm
{
    #region 
    private void InitializeUserComponent()
    {
        // Image_BrightContrast
        List<Control> imgCtrl = new();
        imgCtrl.Add(BrightChkBox);
        imgCtrl.Add(BrightMaxRadioBtn);
        imgCtrl.Add(BrightMinRadioBtn);
        imgCtrl.Add(BrightMaxHScrBar);
        imgCtrl.Add(BrightMinHScrBar);
        imgCtrl.Add(BrightMaxTxtBox);
        imgCtrl.Add(BrightMinTxtBox);
        imgCtrl.Add(ContrastChkBox);
        imgCtrl.Add(ContrastMaxRadioBtn);
        imgCtrl.Add(ContrastMinRadioBtn);
        imgCtrl.Add(ContrastMaxHScrBar);
        imgCtrl.Add(ContrastMinHScrBar);
        imgCtrl.Add(ContrastMaxTxtBox);
        imgCtrl.Add(ContrastMinTxtBox);
        imgCtrl.Add(BrightRndPreviewBtn);
        imgCtrl.Add(PicBox2);
        Image_BrightContrast = new(imgCtrl, ImageTab, ViewTab);

        // Image_RandomNoise
        imgCtrl = new();
        imgCtrl.Add(RndNoiseChkBox);
        imgCtrl.Add(RndNoiseScrBar);
        imgCtrl.Add(RndNoiseRatioScrBar);
        imgCtrl.Add(RndNoiseTxtBox);
        imgCtrl.Add(RndNoiseRatioTxtBox);
        imgCtrl.Add(RndNoisePreviewBtn);
        imgCtrl.Add(PicBox2);
        Image_RandomNoise = new(imgCtrl, ImageTab, ViewTab);

        //Image_Split
        List<Control> splitCtrl = new();
        splitCtrl.Add(ImageWidthTxtBox);
        splitCtrl.Add(ImageHeightTxtBox);
        splitCtrl.Add(SplitWidthTxtBox);
        splitCtrl.Add(SplitHeightTxtBox);
        splitCtrl.Add(WrapWidthTxtBox);
        splitCtrl.Add(WrapHeightTxtBox);
        splitCtrl.Add(SplitCntTxtBox1);
        splitCtrl.Add(RndSplitRadioBtn);
        splitCtrl.Add(SplitPreviewBtn);
        splitCtrl.Add(SplitCntTxtBox2);
        splitCtrl.Add(SplitCntDataGridView);
        splitCtrl.Add(RunSplitBtn);
        splitCtrl.Add(StopSplitBtn);
        splitCtrl.Add(PicBox2);
        Image_Split = new(splitCtrl);

        // sLabel1
        this.sLabel1 = new ToolStripStatusLabel();
        this.sLabel1.Text = "sLabel1";
        this.StatusStrip1.Items.Add(sLabel1);

        //sLabel2
        this.sLabel2 = new ToolStripStatusLabel();
        this.sLabel2.Text = "sLabel2";
        this.StatusStrip2.Items.Add(sLabel2);

        // PicBox1
        this.PosPicBox = new cls_posPicBox(PosPage, sLabel2!, LabelLstView, MaskLstView);
        this.PosPicBox.TabIndex = 22;
        this.PosPicBox.Text = "PictureBox0";
        this.PosPicBox.AutoSize = true;
        this.PosPicBox.BackColor = System.Drawing.Color.Silver;
        this.PosPicBox.Name = "PicBox1";
        this.PosPicBox.Dock = System.Windows.Forms.DockStyle.Fill;
        this.PosPage.Controls.Add(this.PosPicBox);

        // FileTreeView
        this.FileTreeView = new cls_treeview(PosPicBox!, ViewTab, Image_BrightContrast!, Image_RandomNoise, Image_Split!);
        this.FileTreeView.ItemHeight = 22;
        this.FileTreeView.LineColor = System.Drawing.Color.Black;
        this.FileTreeView.Text = "TreeView2";
        this.FileTreeView.Dock = System.Windows.Forms.DockStyle.Fill;
        this.FileTreeView.Name = "FileTreeView";
        this.FileTreeView.Size = new System.Drawing.Size(207, 662);
        this.FileTreeView.TabIndex = 23;
        this.FileTreeView.Sorted = true;
        this.FilePage.Controls.Add(this.FileTreeView);
        Image_Split.SetFileView(FileTreeView);

        // LabelLstView
        ColumnHeader[] labelColumn = new ColumnHeader[3];
        for (int i = 0; i < labelColumn.Count(); i++)
        {
            labelColumn[i] = new();
        }
        labelColumn[0].Text = "ラ　ベ　ル";
        labelColumn[1].Text = "線　色";
        labelColumn[2].Text = "線　幅";
        this.LabelLstView.Columns.AddRange(labelColumn);
        LabelLstView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);

        // MaskLstView
        ColumnHeader[] maskColumn = new ColumnHeader[3];
        for (int i = 0; i < maskColumn.Count(); i++)
        {
            maskColumn[i] = new();
        }
        maskColumn[0].Text = "ラ　ベ　ル";
        maskColumn[1].Text = "線　色";
        maskColumn[2].Text = "線　幅";
        this.MaskLstView.Columns.AddRange(maskColumn);
        MaskLstView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
    }
    private void Controls_EventHandler()
    {
        // this
        this.Load += new EventHandler(Form_Load);
        this.KeyDown += new System.Windows.Forms.KeyEventHandler(PosPicBox!.Control_KeyDown);

        // LabelLstView
        LabelLstView.SelectedIndexChanged += new EventHandler(lblLstView_SelectedIndexChanged);

        //MaskLstView
        MaskLstView.SelectedIndexChanged += new EventHandler(MaskLstView_SelectedIndexChanged);

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

        // MaskEntBtn
        MaskEntBtn.Click += new EventHandler(MaskEntBtn_Click);

        //MaskColorBtn
        MaskColorBtn.Click += new EventHandler(MaskColorBtn_Click);

        // MaskModBtn
        MaskModBtn.Click += new EventHandler(MaskModBtn_Click);

        // MaskDelBtn
        MaskDelBtn.Click += new EventHandler(MaskDelBtn_Click);

        // ViewTab
        ViewTab.SelectedIndexChanged += new EventHandler(ViewTab_SelectedIndexChanged);

        // MenuTab
        MenuTab.SelectedIndexChanged += new EventHandler(MenuTab_SelectedIndexChanged);

        // ImageTab
        ImageTab.SelectedIndexChanged += new EventHandler(ImageTab_SelectedIndexChanged);

        // SplitTab
        SplitTab.SelectedIndexChanged += new EventHandler(SplitTab_SelectedIndexChanged);
    }

    #endregion
    private cls_treeview? FileTreeView;
    private cls_posPicBox? PosPicBox;
    private ToolStripStatusLabel? sLabel1;
    private ToolStripStatusLabel? sLabel2;
    private cls_image_BrightContrast? Image_BrightContrast;
    private cls_image_RandomNoise? Image_RandomNoise;
    private cls_image_Split? Image_Split;

}
