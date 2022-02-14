namespace IMG_Gen2;

partial class MainForm
{
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        //
        // Form1
        //
        this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.BackColor = System.Drawing.Color.Silver;
        this.KeyPreview =  true;
        this.Location = new System.Drawing.Point(-9,-9);
        this.ClientSize = new System.Drawing.Size(812,628);
        this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        this.Text =  "IMG_Gen";
        this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
        this.Name =  "Form1";

        //
        // RootSelectBtn
        //
        this.RootSelectBtn = new System.Windows.Forms.Button();
        this.RootSelectBtn.AutoSize =  true;
        this.RootSelectBtn.BackColor = System.Drawing.Color.WhiteSmoke;
        this.RootSelectBtn.Text =  "ルートフォルダ選択";
        this.RootSelectBtn.Location = new System.Drawing.Point(16,16);
        this.RootSelectBtn.Name =  "RootSelectBtn";
        this.RootSelectBtn.Size = new System.Drawing.Size(125,32);
        this.RootSelectBtn.TabIndex = 16;
        this.Controls.Add(this.RootSelectBtn);

        //
        // RootPathTxtBox
        //
        this.RootPathTxtBox = new System.Windows.Forms.TextBox();
        this.RootPathTxtBox.Text =  "TextBox0";
        this.RootPathTxtBox.BackColor = System.Drawing.SystemColors.ButtonHighlight;
        this.RootPathTxtBox.ReadOnly =  true;
        this.RootPathTxtBox.Location = new System.Drawing.Point(152,20);
        this.RootPathTxtBox.Name =  "RootPathTxtBox";
        this.RootPathTxtBox.Size = new System.Drawing.Size(640,23);
        this.RootPathTxtBox.TabIndex = 1;
        this.RootPathTxtBox.Anchor = (System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right);
        this.Controls.Add(this.RootPathTxtBox);

        //
        // SplitContainer0
        //
        this.SplitContainer0 = new System.Windows.Forms.SplitContainer();
        this.SplitContainer0.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
        this.SplitContainer0.Text =  "SplitContainer0";
        this.SplitContainer0.BackColor = System.Drawing.Color.Silver;
        this.SplitContainer0.Location = new System.Drawing.Point(19,63);
        this.SplitContainer0.Name =  "SplitContainer0";
        this.SplitContainer0.Size = new System.Drawing.Size(774,536);
        this.SplitContainer0.TabIndex = 2;
        this.SplitContainer0.SplitterDistance = 263;
        this.SplitContainer0.Anchor = (System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right);
        this.Controls.Add(this.SplitContainer0);

        //
        // ViewTab
        //
        this.ViewTab = new System.Windows.Forms.TabControl();
        this.ViewTab.ItemSize = new System.Drawing.Size(72,25);
        this.ViewTab.Text =  "TabControl0";
        this.ViewTab.Dock = System.Windows.Forms.DockStyle.Fill;
        this.ViewTab.Name =  "ViewTab";
        this.ViewTab.Size = new System.Drawing.Size(505,534);
        this.ViewTab.TabIndex = 4;
        this.SplitContainer0.Panel2.Controls.Add(this.ViewTab);

        //
        // PosPage
        //
        this.PosPage = new System.Windows.Forms.TabPage();
        this.PosPage.BackColor = System.Drawing.Color.Gray;
        this.PosPage.Location = new System.Drawing.Point(4,29);
        this.PosPage.TabIndex = 5;
        this.PosPage.Text =  "座標";
        this.PosPage.Name =  "PosPage";
        this.PosPage.Size = new System.Drawing.Size(497,501);
        this.ViewTab.Controls.Add(this.PosPage);

        //
        // ImgPage
        //
        this.ImgPage = new System.Windows.Forms.TabPage();
        this.ImgPage.BackColor = System.Drawing.Color.Gray;
        this.ImgPage.Location = new System.Drawing.Point(4,29);
        this.ImgPage.TabIndex = 6;
        this.ImgPage.Text =  "画像処理";
        this.ImgPage.Name =  "ImgPage";
        this.ImgPage.Size = new System.Drawing.Size(497,501);
        this.ViewTab.Controls.Add(this.ImgPage);

        //
        // SplitPage
        //
        this.SplitPage = new System.Windows.Forms.TabPage();
        this.SplitPage.BackColor = System.Drawing.Color.Gray;
        this.SplitPage.Location = new System.Drawing.Point(4,29);
        this.SplitPage.TabIndex = 7;
        this.SplitPage.Text =  "分割";
        this.SplitPage.Name =  "SplitPage";
        this.SplitPage.Size = new System.Drawing.Size(497,501);
        this.ViewTab.Controls.Add(this.SplitPage);

        //
        // MenuTab
        //
        this.MenuTab = new System.Windows.Forms.TabControl();
        this.MenuTab.ItemSize = new System.Drawing.Size(60,25);
        this.MenuTab.Text =  "TabControl1";
        this.MenuTab.Dock = System.Windows.Forms.DockStyle.Fill;
        this.MenuTab.Name =  "MenuTab";
        this.MenuTab.Size = new System.Drawing.Size(261,534);
        this.MenuTab.TabIndex = 7;
        this.SplitContainer0.Panel1.Controls.Add(this.MenuTab);

        //
        // FilePage
        //
        this.FilePage = new System.Windows.Forms.TabPage();
        this.FilePage.BackColor = System.Drawing.SystemColors.ActiveCaption;
        this.FilePage.Location = new System.Drawing.Point(4,29);
        this.FilePage.TabIndex = 8;
        this.FilePage.Text =  "ファイル";
        this.FilePage.Name =  "FilePage";
        this.FilePage.Size = new System.Drawing.Size(253,501);
        this.MenuTab.Controls.Add(this.FilePage);

        //
        // LabelPage
        //
        this.LabelPage = new System.Windows.Forms.TabPage();
        this.LabelPage.BackColor = System.Drawing.SystemColors.ActiveCaption;
        this.LabelPage.Location = new System.Drawing.Point(4,29);
        this.LabelPage.TabIndex = 9;
        this.LabelPage.Text =  "ラベル";
        this.LabelPage.Name =  "LabelPage";
        this.LabelPage.Size = new System.Drawing.Size(253,501);
        this.MenuTab.Controls.Add(this.LabelPage);

        //
        // MaskPage
        //
        this.MaskPage = new System.Windows.Forms.TabPage();
        this.MaskPage.BackColor = System.Drawing.SystemColors.ActiveCaption;
        this.MaskPage.Location = new System.Drawing.Point(4,29);
        this.MaskPage.TabIndex = 10;
        this.MaskPage.Text =  "マスク";
        this.MaskPage.Name =  "MaskPage";
        this.MaskPage.Size = new System.Drawing.Size(253,501);
        this.MenuTab.Controls.Add(this.MaskPage);

        //
        // LabelGrpBox
        //
        this.LabelGrpBox = new System.Windows.Forms.GroupBox();
        this.LabelGrpBox.Text =  "ラベル設定";
        this.LabelGrpBox.BackColor = System.Drawing.SystemColors.ActiveCaption;
        this.LabelGrpBox.Location = new System.Drawing.Point(0,334);
        this.LabelGrpBox.Name =  "LabelGrpBox";
        this.LabelGrpBox.Size = new System.Drawing.Size(245,168);
        this.LabelGrpBox.TabIndex = 23;
        this.LabelGrpBox.Anchor = (System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right);
        this.LabelPage.Controls.Add(this.LabelGrpBox);

        //
        // LabelNameLbl
        //
        this.LabelNameLbl = new System.Windows.Forms.Label();
        this.LabelNameLbl.AutoSize =  true;
        this.LabelNameLbl.Text =  "ラベル名";
        this.LabelNameLbl.BackColor = System.Drawing.SystemColors.ActiveCaption;
        this.LabelNameLbl.Location = new System.Drawing.Point(8,64);
        this.LabelNameLbl.Name =  "LabelNameLbl";
        this.LabelNameLbl.Size = new System.Drawing.Size(47,15);
        this.LabelNameLbl.TabIndex = 11;
        this.LabelGrpBox.Controls.Add(this.LabelNameLbl);

        //
        // LabelNameTxtBox
        //
        this.LabelNameTxtBox = new System.Windows.Forms.TextBox();
        this.LabelNameTxtBox.Location = new System.Drawing.Point(72,64);
        this.LabelNameTxtBox.Name =  "LabelNameTxtBox";
        this.LabelNameTxtBox.Size = new System.Drawing.Size(165,23);
        this.LabelNameTxtBox.TabIndex = 12;
        this.LabelNameTxtBox.Anchor = (System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right);
        this.LabelGrpBox.Controls.Add(this.LabelNameTxtBox);

        //
        // LabelColorLbl
        //
        this.LabelColorLbl = new System.Windows.Forms.Label();
        this.LabelColorLbl.AutoSize =  true;
        this.LabelColorLbl.Text =  "線色";
        this.LabelColorLbl.BackColor = System.Drawing.SystemColors.ActiveCaption;
        this.LabelColorLbl.Location = new System.Drawing.Point(8,96);
        this.LabelColorLbl.Name =  "LabelColorLbl";
        this.LabelColorLbl.Size = new System.Drawing.Size(31,15);
        this.LabelColorLbl.TabIndex = 13;
        this.LabelGrpBox.Controls.Add(this.LabelColorLbl);

        //
        // LabelColorTxtBox
        //
        this.LabelColorTxtBox = new System.Windows.Forms.TextBox();
        this.LabelColorTxtBox.Text =  "Red";
        this.LabelColorTxtBox.BackColor = System.Drawing.Color.White;
        this.LabelColorTxtBox.ReadOnly =  true;
        this.LabelColorTxtBox.Location = new System.Drawing.Point(72,96);
        this.LabelColorTxtBox.Name =  "LabelColorTxtBox";
        this.LabelColorTxtBox.Size = new System.Drawing.Size(121,23);
        this.LabelColorTxtBox.TabIndex = 14;
        this.LabelColorTxtBox.Anchor = (System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right);
        this.LabelGrpBox.Controls.Add(this.LabelColorTxtBox);

        //
        // LabelColorBtn
        //
        this.LabelColorBtn = new System.Windows.Forms.Button();
        this.LabelColorBtn.BackColor = System.Drawing.SystemColors.ActiveCaption;
        this.LabelColorBtn.Text =  "色";
        this.LabelColorBtn.Location = new System.Drawing.Point(200,96);
        this.LabelColorBtn.Name =  "LabelColorBtn";
        this.LabelColorBtn.Size = new System.Drawing.Size(40,32);
        this.LabelColorBtn.TabIndex = 15;
        this.LabelColorBtn.Anchor = (System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
        this.LabelGrpBox.Controls.Add(this.LabelColorBtn);

        //
        // LabelWidthLbl
        //
        this.LabelWidthLbl = new System.Windows.Forms.Label();
        this.LabelWidthLbl.AutoSize =  true;
        this.LabelWidthLbl.Text =  "線幅";
        this.LabelWidthLbl.BackColor = System.Drawing.SystemColors.ActiveCaption;
        this.LabelWidthLbl.Location = new System.Drawing.Point(8,128);
        this.LabelWidthLbl.Name =  "LabelWidthLbl";
        this.LabelWidthLbl.Size = new System.Drawing.Size(31,15);
        this.LabelWidthLbl.TabIndex = 16;
        this.LabelGrpBox.Controls.Add(this.LabelWidthLbl);

        //
        // LabelWidthTxtBox
        //
        this.LabelWidthTxtBox = new System.Windows.Forms.TextBox();
        this.LabelWidthTxtBox.Text =  "1";
        this.LabelWidthTxtBox.Location = new System.Drawing.Point(72,128);
        this.LabelWidthTxtBox.Name =  "LabelWidthTxtBox";
        this.LabelWidthTxtBox.Size = new System.Drawing.Size(165,23);
        this.LabelWidthTxtBox.TabIndex = 17;
        this.LabelWidthTxtBox.Anchor = (System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right);
        this.LabelGrpBox.Controls.Add(this.LabelWidthTxtBox);

        //
        // LabelEntBtn
        //
        this.LabelEntBtn = new System.Windows.Forms.Button();
        this.LabelEntBtn.BackColor = System.Drawing.SystemColors.ActiveCaption;
        this.LabelEntBtn.Text =  "登録";
        this.LabelEntBtn.Location = new System.Drawing.Point(8,24);
        this.LabelEntBtn.Name =  "LabelEntBtn";
        this.LabelEntBtn.Size = new System.Drawing.Size(64,32);
        this.LabelEntBtn.TabIndex = 18;
        this.LabelGrpBox.Controls.Add(this.LabelEntBtn);

        //
        // LabelModBtn
        //
        this.LabelModBtn = new System.Windows.Forms.Button();
        this.LabelModBtn.BackColor = System.Drawing.SystemColors.ActiveCaption;
        this.LabelModBtn.Text =  "修正";
        this.LabelModBtn.Location = new System.Drawing.Point(80,24);
        this.LabelModBtn.Name =  "LabelModBtn";
        this.LabelModBtn.Size = new System.Drawing.Size(64,32);
        this.LabelModBtn.TabIndex = 19;
        this.LabelGrpBox.Controls.Add(this.LabelModBtn);

        //
        // LabelDelBtn
        //
        this.LabelDelBtn = new System.Windows.Forms.Button();
        this.LabelDelBtn.BackColor = System.Drawing.SystemColors.ActiveCaption;
        this.LabelDelBtn.Text =  "削除";
        this.LabelDelBtn.Location = new System.Drawing.Point(152,24);
        this.LabelDelBtn.Name =  "LabelDelBtn";
        this.LabelDelBtn.Size = new System.Drawing.Size(64,32);
        this.LabelDelBtn.TabIndex = 20;
        this.LabelGrpBox.Controls.Add(this.LabelDelBtn);

        //
        // MaskGrpBox
        //
        this.MaskGrpBox = new System.Windows.Forms.GroupBox();
        this.MaskGrpBox.Text =  "マスク設定";
        this.MaskGrpBox.BackColor = System.Drawing.SystemColors.ActiveCaption;
        this.MaskGrpBox.Location = new System.Drawing.Point(0,334);
        this.MaskGrpBox.Name =  "MaskGrpBox";
        this.MaskGrpBox.Size = new System.Drawing.Size(245,168);
        this.MaskGrpBox.TabIndex = 24;
        this.MaskGrpBox.Anchor = (System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right);
        this.MaskPage.Controls.Add(this.MaskGrpBox);

        //
        // MaskEntBtn
        //
        this.MaskEntBtn = new System.Windows.Forms.Button();
        this.MaskEntBtn.BackColor = System.Drawing.SystemColors.ActiveCaption;
        this.MaskEntBtn.Text =  "登録";
        this.MaskEntBtn.Location = new System.Drawing.Point(8,24);
        this.MaskEntBtn.Name =  "MaskEntBtn";
        this.MaskEntBtn.Size = new System.Drawing.Size(64,32);
        this.MaskEntBtn.TabIndex = 25;
        this.MaskGrpBox.Controls.Add(this.MaskEntBtn);

        //
        // MaskModBtn
        //
        this.MaskModBtn = new System.Windows.Forms.Button();
        this.MaskModBtn.BackColor = System.Drawing.SystemColors.ActiveCaption;
        this.MaskModBtn.Text =  "修正";
        this.MaskModBtn.Location = new System.Drawing.Point(80,24);
        this.MaskModBtn.Name =  "MaskModBtn";
        this.MaskModBtn.Size = new System.Drawing.Size(64,32);
        this.MaskModBtn.TabIndex = 26;
        this.MaskGrpBox.Controls.Add(this.MaskModBtn);

        //
        // MaskDelBtn
        //
        this.MaskDelBtn = new System.Windows.Forms.Button();
        this.MaskDelBtn.BackColor = System.Drawing.SystemColors.ActiveCaption;
        this.MaskDelBtn.Text =  "削除";
        this.MaskDelBtn.Location = new System.Drawing.Point(152,24);
        this.MaskDelBtn.Name =  "MaskDelBtn";
        this.MaskDelBtn.Size = new System.Drawing.Size(64,32);
        this.MaskDelBtn.TabIndex = 27;
        this.MaskGrpBox.Controls.Add(this.MaskDelBtn);

        //
        // MaskNameLbl
        //
        this.MaskNameLbl = new System.Windows.Forms.Label();
        this.MaskNameLbl.AutoSize =  true;
        this.MaskNameLbl.Text =  "マスク名";
        this.MaskNameLbl.BackColor = System.Drawing.SystemColors.ActiveCaption;
        this.MaskNameLbl.Location = new System.Drawing.Point(8,64);
        this.MaskNameLbl.Name =  "MaskNameLbl";
        this.MaskNameLbl.Size = new System.Drawing.Size(46,15);
        this.MaskNameLbl.TabIndex = 28;
        this.MaskGrpBox.Controls.Add(this.MaskNameLbl);

        //
        // MaskColorLbl
        //
        this.MaskColorLbl = new System.Windows.Forms.Label();
        this.MaskColorLbl.AutoSize =  true;
        this.MaskColorLbl.Text =  "線色";
        this.MaskColorLbl.BackColor = System.Drawing.SystemColors.ActiveCaption;
        this.MaskColorLbl.Location = new System.Drawing.Point(8,96);
        this.MaskColorLbl.Name =  "MaskColorLbl";
        this.MaskColorLbl.Size = new System.Drawing.Size(31,15);
        this.MaskColorLbl.TabIndex = 29;
        this.MaskGrpBox.Controls.Add(this.MaskColorLbl);

        //
        // MaskWidthLbl
        //
        this.MaskWidthLbl = new System.Windows.Forms.Label();
        this.MaskWidthLbl.AutoSize =  true;
        this.MaskWidthLbl.Text =  "線幅";
        this.MaskWidthLbl.BackColor = System.Drawing.SystemColors.ActiveCaption;
        this.MaskWidthLbl.Location = new System.Drawing.Point(8,128);
        this.MaskWidthLbl.Name =  "MaskWidthLbl";
        this.MaskWidthLbl.Size = new System.Drawing.Size(31,15);
        this.MaskWidthLbl.TabIndex = 30;
        this.MaskGrpBox.Controls.Add(this.MaskWidthLbl);

        //
        // MaskNameTxtBox
        //
        this.MaskNameTxtBox = new System.Windows.Forms.TextBox();
        this.MaskNameTxtBox.Modified =  true;
        this.MaskNameTxtBox.Location = new System.Drawing.Point(72,64);
        this.MaskNameTxtBox.Name =  "MaskNameTxtBox";
        this.MaskNameTxtBox.Size = new System.Drawing.Size(165,23);
        this.MaskNameTxtBox.TabIndex = 31;
        this.MaskNameTxtBox.Anchor = (System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right);
        this.MaskGrpBox.Controls.Add(this.MaskNameTxtBox);

        //
        // MaskColorTxtBox
        //
        this.MaskColorTxtBox = new System.Windows.Forms.TextBox();
        this.MaskColorTxtBox.Text =  "Red";
        this.MaskColorTxtBox.Location = new System.Drawing.Point(72,96);
        this.MaskColorTxtBox.Name =  "MaskColorTxtBox";
        this.MaskColorTxtBox.Size = new System.Drawing.Size(121,23);
        this.MaskColorTxtBox.TabIndex = 32;
        this.MaskColorTxtBox.Anchor = (System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right);
        this.MaskGrpBox.Controls.Add(this.MaskColorTxtBox);

        //
        // MaskWidthTxtBox
        //
        this.MaskWidthTxtBox = new System.Windows.Forms.TextBox();
        this.MaskWidthTxtBox.Text =  "1";
        this.MaskWidthTxtBox.Location = new System.Drawing.Point(72,128);
        this.MaskWidthTxtBox.Name =  "MaskWidthTxtBox";
        this.MaskWidthTxtBox.Size = new System.Drawing.Size(165,23);
        this.MaskWidthTxtBox.TabIndex = 33;
        this.MaskWidthTxtBox.Anchor = (System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right);
        this.MaskGrpBox.Controls.Add(this.MaskWidthTxtBox);

        //
        // MaskLstBox
        //
        this.MaskLstBox = new System.Windows.Forms.ListBox();
        this.MaskLstBox.ItemHeight = 20;
        this.MaskLstBox.Text =  "ListBox";
        this.MaskLstBox.Location = new System.Drawing.Point(8,8);
        this.MaskLstBox.Name =  "MaskLstBox";
        this.MaskLstBox.Size = new System.Drawing.Size(237,304);
        this.MaskLstBox.TabIndex = 35;
        this.MaskLstBox.Anchor = (System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right);
        this.MaskPage.Controls.Add(this.MaskLstBox);

        //
        // PicBox2
        //
        this.PicBox2 = new System.Windows.Forms.PictureBox();
        this.PicBox2.TabIndex = 36;
        this.PicBox2.Text =  "PictureBox1";
        this.PicBox2.BackColor = System.Drawing.Color.White;
        this.PicBox2.Location = new System.Drawing.Point(16,16);
        this.PicBox2.Name =  "PicBox2";
        this.PicBox2.Size = new System.Drawing.Size(320,240);
        this.ImgPage.Controls.Add(this.PicBox2);

        //
        // PicBox3
        //
        this.PicBox3 = new System.Windows.Forms.PictureBox();
        this.PicBox3.TabIndex = 37;
        this.PicBox3.Text =  "PictureBox2";
        this.PicBox3.BackColor = System.Drawing.Color.White;
        this.PicBox3.Location = new System.Drawing.Point(16,16);
        this.PicBox3.Name =  "PicBox3";
        this.PicBox3.Size = new System.Drawing.Size(320,240);
        this.SplitPage.Controls.Add(this.PicBox3);

        //
        // SplitOptPage
        //
        this.SplitOptPage = new System.Windows.Forms.TabPage();
        this.SplitOptPage.BackColor = System.Drawing.SystemColors.ActiveCaption;
        this.SplitOptPage.Location = new System.Drawing.Point(4,29);
        this.SplitOptPage.TabIndex = 38;
        this.SplitOptPage.Text =  "分割";
        this.SplitOptPage.Name =  "SplitOptPage";
        this.SplitOptPage.Size = new System.Drawing.Size(253,501);
        this.MenuTab.Controls.Add(this.SplitOptPage);

        //
        // MaskColorBtn
        //
        this.MaskColorBtn = new System.Windows.Forms.Button();
        this.MaskColorBtn.BackColor = System.Drawing.SystemColors.ActiveCaption;
        this.MaskColorBtn.Text =  "色";
        this.MaskColorBtn.Location = new System.Drawing.Point(200,96);
        this.MaskColorBtn.Name =  "MaskColorBtn";
        this.MaskColorBtn.Size = new System.Drawing.Size(40,32);
        this.MaskColorBtn.TabIndex = 39;
        this.MaskColorBtn.Anchor = (System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
        this.MaskGrpBox.Controls.Add(this.MaskColorBtn);

        //
        // StatusStrip1
        //
        this.StatusStrip1 = new System.Windows.Forms.StatusStrip();
        this.StatusStrip1.BackColor = System.Drawing.Color.Silver;
        this.StatusStrip1.Location = new System.Drawing.Point(0,606);
        this.StatusStrip1.Name =  "StatusStrip1";
        this.StatusStrip1.Size = new System.Drawing.Size(812,22);
        this.StatusStrip1.TabIndex = 39;
        this.StatusStrip1.Text =  "StatusStrip1";
        this.Controls.Add(this.StatusStrip1);

        //
        // StatusStrip2
        //
        this.StatusStrip2 = new System.Windows.Forms.StatusStrip();
        this.StatusStrip2.BackColor = System.Drawing.Color.Silver;
        this.StatusStrip2.Location = new System.Drawing.Point(0,479);
        this.StatusStrip2.Name =  "StatusStrip2";
        this.StatusStrip2.Size = new System.Drawing.Size(497,22);
        this.StatusStrip2.TabIndex = 40;
        this.StatusStrip2.Text =  "StatusStrip2";
        this.PosPage.Controls.Add(this.StatusStrip2);

        //
        // LabelLstView
        //
        this.LabelLstView = new System.Windows.Forms.ListView();
        this.LabelLstView.FullRowSelect =  true;
        this.LabelLstView.MultiSelect =  false;
        this.LabelLstView.Text =  "ListView0";
        this.LabelLstView.View = System.Windows.Forms.View.Details;
        this.LabelLstView.Location = new System.Drawing.Point(8,8);
        this.LabelLstView.Name =  "LabelLstView";
        this.LabelLstView.Size = new System.Drawing.Size(240,320);
        this.LabelLstView.TabIndex = 41;
        this.LabelLstView.Anchor = (System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right);
        this.LabelPage.Controls.Add(this.LabelLstView);

    }

    #endregion
    private Button RootSelectBtn;
    private TextBox RootPathTxtBox;
    private SplitContainer SplitContainer0;
    private TabControl ViewTab;
    private TabPage PosPage;
    private TabPage ImgPage;
    private TabPage SplitPage;
    private TabControl MenuTab;
    private TabPage FilePage;
    private TabPage LabelPage;
    private TabPage MaskPage;
    private GroupBox LabelGrpBox;
    private Label LabelNameLbl;
    private TextBox LabelNameTxtBox;
    private Label LabelColorLbl;
    private TextBox LabelColorTxtBox;
    private Button LabelColorBtn;
    private Label LabelWidthLbl;
    private TextBox LabelWidthTxtBox;
    private Button LabelEntBtn;
    private Button LabelModBtn;
    private Button LabelDelBtn;
    private GroupBox MaskGrpBox;
    private Button MaskEntBtn;
    private Button MaskModBtn;
    private Button MaskDelBtn;
    private Label MaskNameLbl;
    private Label MaskColorLbl;
    private Label MaskWidthLbl;
    private TextBox MaskNameTxtBox;
    private TextBox MaskColorTxtBox;
    private TextBox MaskWidthTxtBox;
    private ListBox MaskLstBox;
    private PictureBox PicBox2;
    private PictureBox PicBox3;
    private TabPage SplitOptPage;
    private Button MaskColorBtn;
    private StatusStrip StatusStrip1;
    private StatusStrip StatusStrip2;
    private ListView LabelLstView;
}
