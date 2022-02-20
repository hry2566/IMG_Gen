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
        this.Location = new System.Drawing.Point(-8,-8);
        this.ClientSize = new System.Drawing.Size(1068,724);
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
        this.RootPathTxtBox.Size = new System.Drawing.Size(892,27);
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
        this.SplitContainer0.Size = new System.Drawing.Size(1026,628);
        this.SplitContainer0.TabIndex = 2;
        this.SplitContainer0.SplitterDistance = 264;
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
        this.ViewTab.Size = new System.Drawing.Size(756,626);
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
        this.PosPage.Size = new System.Drawing.Size(748,593);
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
        this.ImgPage.Size = new System.Drawing.Size(748,593);
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
        this.SplitPage.Size = new System.Drawing.Size(748,593);
        this.ViewTab.Controls.Add(this.SplitPage);

        //
        // MenuTab
        //
        this.MenuTab = new System.Windows.Forms.TabControl();
        this.MenuTab.ItemSize = new System.Drawing.Size(60,25);
        this.MenuTab.Text =  "TabControl1";
        this.MenuTab.Dock = System.Windows.Forms.DockStyle.Fill;
        this.MenuTab.Name =  "MenuTab";
        this.MenuTab.Size = new System.Drawing.Size(262,626);
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
        this.FilePage.Size = new System.Drawing.Size(254,593);
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
        this.LabelPage.Size = new System.Drawing.Size(254,593);
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
        this.MaskPage.Size = new System.Drawing.Size(254,593);
        this.MenuTab.Controls.Add(this.MaskPage);

        //
        // LabelGrpBox
        //
        this.LabelGrpBox = new System.Windows.Forms.GroupBox();
        this.LabelGrpBox.Text =  "ラベル設定";
        this.LabelGrpBox.BackColor = System.Drawing.SystemColors.ActiveCaption;
        this.LabelGrpBox.Location = new System.Drawing.Point(0,428);
        this.LabelGrpBox.Name =  "LabelGrpBox";
        this.LabelGrpBox.Size = new System.Drawing.Size(246,168);
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
        this.LabelNameLbl.Size = new System.Drawing.Size(58,20);
        this.LabelNameLbl.TabIndex = 11;
        this.LabelGrpBox.Controls.Add(this.LabelNameLbl);

        //
        // LabelNameTxtBox
        //
        this.LabelNameTxtBox = new System.Windows.Forms.TextBox();
        this.LabelNameTxtBox.Text =  "TextBox1";
        this.LabelNameTxtBox.Location = new System.Drawing.Point(72,64);
        this.LabelNameTxtBox.Name =  "LabelNameTxtBox";
        this.LabelNameTxtBox.Size = new System.Drawing.Size(166,27);
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
        this.LabelColorLbl.Size = new System.Drawing.Size(39,20);
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
        this.LabelColorTxtBox.Size = new System.Drawing.Size(122,27);
        this.LabelColorTxtBox.TabIndex = 14;
        this.LabelColorTxtBox.Anchor = (System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right);
        this.LabelGrpBox.Controls.Add(this.LabelColorTxtBox);

        //
        // LabelColorBtn
        //
        this.LabelColorBtn = new System.Windows.Forms.Button();
        this.LabelColorBtn.BackColor = System.Drawing.SystemColors.ActiveCaption;
        this.LabelColorBtn.Text =  "色";
        this.LabelColorBtn.Location = new System.Drawing.Point(201,96);
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
        this.LabelWidthLbl.Size = new System.Drawing.Size(39,20);
        this.LabelWidthLbl.TabIndex = 16;
        this.LabelGrpBox.Controls.Add(this.LabelWidthLbl);

        //
        // LabelWidthTxtBox
        //
        this.LabelWidthTxtBox = new System.Windows.Forms.TextBox();
        this.LabelWidthTxtBox.Text =  "1";
        this.LabelWidthTxtBox.Location = new System.Drawing.Point(72,128);
        this.LabelWidthTxtBox.Name =  "LabelWidthTxtBox";
        this.LabelWidthTxtBox.Size = new System.Drawing.Size(166,27);
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
        this.MaskGrpBox.Location = new System.Drawing.Point(0,428);
        this.MaskGrpBox.Name =  "MaskGrpBox";
        this.MaskGrpBox.Size = new System.Drawing.Size(246,168);
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
        this.MaskNameLbl.Size = new System.Drawing.Size(57,20);
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
        this.MaskColorLbl.Size = new System.Drawing.Size(39,20);
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
        this.MaskWidthLbl.Size = new System.Drawing.Size(39,20);
        this.MaskWidthLbl.TabIndex = 30;
        this.MaskGrpBox.Controls.Add(this.MaskWidthLbl);

        //
        // MaskNameTxtBox
        //
        this.MaskNameTxtBox = new System.Windows.Forms.TextBox();
        this.MaskNameTxtBox.Text =  "TextBox4";
        this.MaskNameTxtBox.BackColor = System.Drawing.SystemColors.ControlLightLight;
        this.MaskNameTxtBox.Modified =  true;
        this.MaskNameTxtBox.ReadOnly =  true;
        this.MaskNameTxtBox.Location = new System.Drawing.Point(72,64);
        this.MaskNameTxtBox.Name =  "MaskNameTxtBox";
        this.MaskNameTxtBox.Size = new System.Drawing.Size(166,27);
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
        this.MaskColorTxtBox.Size = new System.Drawing.Size(122,27);
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
        this.MaskWidthTxtBox.Size = new System.Drawing.Size(166,27);
        this.MaskWidthTxtBox.TabIndex = 33;
        this.MaskWidthTxtBox.Anchor = (System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right);
        this.MaskGrpBox.Controls.Add(this.MaskWidthTxtBox);

        //
        // MaskColorBtn
        //
        this.MaskColorBtn = new System.Windows.Forms.Button();
        this.MaskColorBtn.BackColor = System.Drawing.SystemColors.ActiveCaption;
        this.MaskColorBtn.Text =  "色";
        this.MaskColorBtn.Location = new System.Drawing.Point(201,96);
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
        this.StatusStrip1.Location = new System.Drawing.Point(0,702);
        this.StatusStrip1.Name =  "StatusStrip1";
        this.StatusStrip1.Size = new System.Drawing.Size(1068,22);
        this.StatusStrip1.TabIndex = 39;
        this.StatusStrip1.Text =  "StatusStrip1";
        this.Controls.Add(this.StatusStrip1);

        //
        // StatusStrip2
        //
        this.StatusStrip2 = new System.Windows.Forms.StatusStrip();
        this.StatusStrip2.BackColor = System.Drawing.Color.Silver;
        this.StatusStrip2.Location = new System.Drawing.Point(0,571);
        this.StatusStrip2.Name =  "StatusStrip2";
        this.StatusStrip2.Size = new System.Drawing.Size(748,22);
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
        this.LabelLstView.Size = new System.Drawing.Size(241,416);
        this.LabelLstView.TabIndex = 41;
        this.LabelLstView.Anchor = (System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right);
        this.LabelPage.Controls.Add(this.LabelLstView);

        //
        // MaskLstView
        //
        this.MaskLstView = new System.Windows.Forms.ListView();
        this.MaskLstView.FullRowSelect =  true;
        this.MaskLstView.Text =  "ListView1";
        this.MaskLstView.View = System.Windows.Forms.View.Details;
        this.MaskLstView.Location = new System.Drawing.Point(8,8);
        this.MaskLstView.Name =  "MaskLstView";
        this.MaskLstView.Size = new System.Drawing.Size(241,416);
        this.MaskLstView.TabIndex = 40;
        this.MaskLstView.Anchor = (System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right);
        this.MaskPage.Controls.Add(this.MaskLstView);

        //
        // SplitContainer1
        //
        this.SplitContainer1 = new System.Windows.Forms.SplitContainer();
        this.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
        this.SplitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
        this.SplitContainer1.Text =  "SplitContainer1";
        this.SplitContainer1.BackColor = System.Drawing.Color.Gray;
        this.SplitContainer1.Name =  "SplitContainer1";
        this.SplitContainer1.Size = new System.Drawing.Size(748,593);
        this.SplitContainer1.TabIndex = 44;
        this.SplitContainer1.SplitterDistance = 263;
        this.ImgPage.Controls.Add(this.SplitContainer1);

        //
        // ImageTab
        //
        this.ImageTab = new System.Windows.Forms.TabControl();
        this.ImageTab.ItemSize = new System.Drawing.Size(118,25);
        this.ImageTab.Text =  "TabControl3";
        this.ImageTab.Location = new System.Drawing.Point(8,8);
        this.ImageTab.Name =  "ImageTab";
        this.ImageTab.Size = new System.Drawing.Size(247,576);
        this.ImageTab.TabIndex = 45;
        this.ImageTab.Anchor = (System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right);
        this.SplitContainer1.Panel1.Controls.Add(this.ImageTab);

        //
        // BrightPage
        //
        this.BrightPage = new System.Windows.Forms.TabPage();
        this.BrightPage.BackColor = System.Drawing.SystemColors.ActiveCaption;
        this.BrightPage.Location = new System.Drawing.Point(4,29);
        this.BrightPage.TabIndex = 46;
        this.BrightPage.Text =  "明るさ・コントラスト";
        this.BrightPage.Name =  "BrightPage";
        this.BrightPage.Size = new System.Drawing.Size(239,543);
        this.ImageTab.Controls.Add(this.BrightPage);

        //
        // RndNoisePage
        //
        this.RndNoisePage = new System.Windows.Forms.TabPage();
        this.RndNoisePage.BackColor = System.Drawing.SystemColors.ActiveCaption;
        this.RndNoisePage.Location = new System.Drawing.Point(4,29);
        this.RndNoisePage.TabIndex = 47;
        this.RndNoisePage.Text =  "ランダムノイズ";
        this.RndNoisePage.Name =  "RndNoisePage";
        this.RndNoisePage.Size = new System.Drawing.Size(239,543);
        this.ImageTab.Controls.Add(this.RndNoisePage);

        //
        // PicBox2
        //
        this.PicBox2 = new System.Windows.Forms.PictureBox();
        this.PicBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
        this.PicBox2.TabIndex = 48;
        this.PicBox2.Text =  "PictureBox2";
        this.PicBox2.BackColor = System.Drawing.Color.White;
        this.PicBox2.Dock = System.Windows.Forms.DockStyle.Fill;
        this.PicBox2.Name =  "PicBox2";
        this.PicBox2.Size = new System.Drawing.Size(479,591);
        this.SplitContainer1.Panel2.Controls.Add(this.PicBox2);

        //
        // BrightChkBox
        //
        this.BrightChkBox = new System.Windows.Forms.CheckBox();
        this.BrightChkBox.AutoSize =  true;
        this.BrightChkBox.BackColor = System.Drawing.SystemColors.ActiveCaption;
        this.BrightChkBox.Text =  "明るさ（有効／無効）";
        this.BrightChkBox.Location = new System.Drawing.Point(8,8);
        this.BrightChkBox.Name =  "BrightChkBox";
        this.BrightChkBox.Size = new System.Drawing.Size(172,24);
        this.BrightChkBox.TabIndex = 45;
        this.BrightPage.Controls.Add(this.BrightChkBox);

        //
        // GroupBox2
        //
        this.GroupBox2 = new System.Windows.Forms.GroupBox();
        this.GroupBox2.Text =  "明るさ設定";
        this.GroupBox2.BackColor = System.Drawing.SystemColors.ActiveCaption;
        this.GroupBox2.Location = new System.Drawing.Point(8,40);
        this.GroupBox2.Name =  "GroupBox2";
        this.GroupBox2.Size = new System.Drawing.Size(224,184);
        this.GroupBox2.TabIndex = 49;
        this.GroupBox2.Anchor = (System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right);
        this.BrightPage.Controls.Add(this.GroupBox2);

        //
        // BrightMaxHScrBar
        //
        this.BrightMaxHScrBar = new System.Windows.Forms.HScrollBar();
        this.BrightMaxHScrBar.BackColor = System.Drawing.SystemColors.ActiveCaption;
        this.BrightMaxHScrBar.Maximum = 209;
        this.BrightMaxHScrBar.Minimum = -200;
        this.BrightMaxHScrBar.Text =  "HScrollBar0";
        this.BrightMaxHScrBar.Location = new System.Drawing.Point(16,64);
        this.BrightMaxHScrBar.Name =  "BrightMaxHScrBar";
        this.BrightMaxHScrBar.Size = new System.Drawing.Size(192,32);
        this.BrightMaxHScrBar.TabIndex = 52;
        this.BrightMaxHScrBar.Anchor = (System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right);
        this.GroupBox2.Controls.Add(this.BrightMaxHScrBar);

        //
        // BrightMaxTxtBox
        //
        this.BrightMaxTxtBox = new System.Windows.Forms.TextBox();
        this.BrightMaxTxtBox.Text =  "TextBox7";
        this.BrightMaxTxtBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
        this.BrightMaxTxtBox.BackColor = System.Drawing.SystemColors.ButtonHighlight;
        this.BrightMaxTxtBox.ReadOnly =  true;
        this.BrightMaxTxtBox.Location = new System.Drawing.Point(160,32);
        this.BrightMaxTxtBox.Name =  "BrightMaxTxtBox";
        this.BrightMaxTxtBox.Size = new System.Drawing.Size(52,27);
        this.BrightMaxTxtBox.TabIndex = 53;
        this.BrightMaxTxtBox.Anchor = (System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
        this.GroupBox2.Controls.Add(this.BrightMaxTxtBox);

        //
        // BrightMinHScrBar
        //
        this.BrightMinHScrBar = new System.Windows.Forms.HScrollBar();
        this.BrightMinHScrBar.BackColor = System.Drawing.SystemColors.ActiveCaption;
        this.BrightMinHScrBar.Maximum = 209;
        this.BrightMinHScrBar.Minimum = -200;
        this.BrightMinHScrBar.Text =  "HScrollBar1";
        this.BrightMinHScrBar.Location = new System.Drawing.Point(16,136);
        this.BrightMinHScrBar.Name =  "BrightMinHScrBar";
        this.BrightMinHScrBar.Size = new System.Drawing.Size(192,32);
        this.BrightMinHScrBar.TabIndex = 54;
        this.BrightMinHScrBar.Anchor = (System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right);
        this.GroupBox2.Controls.Add(this.BrightMinHScrBar);

        //
        // BrightMinTxtBox
        //
        this.BrightMinTxtBox = new System.Windows.Forms.TextBox();
        this.BrightMinTxtBox.Text =  "TextBox8";
        this.BrightMinTxtBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
        this.BrightMinTxtBox.BackColor = System.Drawing.SystemColors.ButtonHighlight;
        this.BrightMinTxtBox.ReadOnly =  true;
        this.BrightMinTxtBox.Location = new System.Drawing.Point(160,104);
        this.BrightMinTxtBox.Name =  "BrightMinTxtBox";
        this.BrightMinTxtBox.Size = new System.Drawing.Size(52,27);
        this.BrightMinTxtBox.TabIndex = 55;
        this.BrightMinTxtBox.Anchor = (System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
        this.GroupBox2.Controls.Add(this.BrightMinTxtBox);

        //
        // GroupBox3
        //
        this.GroupBox3 = new System.Windows.Forms.GroupBox();
        this.GroupBox3.Text =  "コントラスト設定";
        this.GroupBox3.BackColor = System.Drawing.SystemColors.ActiveCaption;
        this.GroupBox3.Location = new System.Drawing.Point(8,264);
        this.GroupBox3.Name =  "GroupBox3";
        this.GroupBox3.Size = new System.Drawing.Size(224,184);
        this.GroupBox3.TabIndex = 56;
        this.GroupBox3.Anchor = (System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right);
        this.BrightPage.Controls.Add(this.GroupBox3);

        //
        // BrightMaxRadioBtn
        //
        this.BrightMaxRadioBtn = new System.Windows.Forms.RadioButton();
        this.BrightMaxRadioBtn.Checked =  true;
        this.BrightMaxRadioBtn.TabStop =  true;
        this.BrightMaxRadioBtn.AutoSize =  true;
        this.BrightMaxRadioBtn.BackColor = System.Drawing.SystemColors.ActiveCaption;
        this.BrightMaxRadioBtn.Text =  "Max";
        this.BrightMaxRadioBtn.Location = new System.Drawing.Point(16,32);
        this.BrightMaxRadioBtn.Name =  "BrightMaxRadioBtn";
        this.BrightMaxRadioBtn.Size = new System.Drawing.Size(58,24);
        this.BrightMaxRadioBtn.TabIndex = 57;
        this.GroupBox2.Controls.Add(this.BrightMaxRadioBtn);

        //
        // BrightMinRadioBtn
        //
        this.BrightMinRadioBtn = new System.Windows.Forms.RadioButton();
        this.BrightMinRadioBtn.AutoSize =  true;
        this.BrightMinRadioBtn.BackColor = System.Drawing.SystemColors.ActiveCaption;
        this.BrightMinRadioBtn.Text =  "Min";
        this.BrightMinRadioBtn.Location = new System.Drawing.Point(16,104);
        this.BrightMinRadioBtn.Name =  "BrightMinRadioBtn";
        this.BrightMinRadioBtn.Size = new System.Drawing.Size(55,24);
        this.BrightMinRadioBtn.TabIndex = 58;
        this.GroupBox2.Controls.Add(this.BrightMinRadioBtn);

        //
        // ContrastMaxRadioBtn
        //
        this.ContrastMaxRadioBtn = new System.Windows.Forms.RadioButton();
        this.ContrastMaxRadioBtn.Checked =  true;
        this.ContrastMaxRadioBtn.TabStop =  true;
        this.ContrastMaxRadioBtn.AutoSize =  true;
        this.ContrastMaxRadioBtn.BackColor = System.Drawing.SystemColors.ActiveCaption;
        this.ContrastMaxRadioBtn.Text =  "Max";
        this.ContrastMaxRadioBtn.Location = new System.Drawing.Point(16,32);
        this.ContrastMaxRadioBtn.Name =  "ContrastMaxRadioBtn";
        this.ContrastMaxRadioBtn.Size = new System.Drawing.Size(58,24);
        this.ContrastMaxRadioBtn.TabIndex = 53;
        this.GroupBox3.Controls.Add(this.ContrastMaxRadioBtn);

        //
        // ContrastMinRadioBtn
        //
        this.ContrastMinRadioBtn = new System.Windows.Forms.RadioButton();
        this.ContrastMinRadioBtn.AutoSize =  true;
        this.ContrastMinRadioBtn.BackColor = System.Drawing.SystemColors.ActiveCaption;
        this.ContrastMinRadioBtn.Text =  "Min";
        this.ContrastMinRadioBtn.Location = new System.Drawing.Point(16,104);
        this.ContrastMinRadioBtn.Name =  "ContrastMinRadioBtn";
        this.ContrastMinRadioBtn.Size = new System.Drawing.Size(55,24);
        this.ContrastMinRadioBtn.TabIndex = 54;
        this.GroupBox3.Controls.Add(this.ContrastMinRadioBtn);

        //
        // ContrastMaxTxtBox
        //
        this.ContrastMaxTxtBox = new System.Windows.Forms.TextBox();
        this.ContrastMaxTxtBox.Text =  "oTextBox9";
        this.ContrastMaxTxtBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
        this.ContrastMaxTxtBox.BackColor = System.Drawing.SystemColors.ButtonHighlight;
        this.ContrastMaxTxtBox.ReadOnly =  true;
        this.ContrastMaxTxtBox.Location = new System.Drawing.Point(128,32);
        this.ContrastMaxTxtBox.Name =  "ContrastMaxTxtBox";
        this.ContrastMaxTxtBox.Size = new System.Drawing.Size(48,27);
        this.ContrastMaxTxtBox.TabIndex = 55;
        this.ContrastMaxTxtBox.Anchor = (System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
        this.GroupBox3.Controls.Add(this.ContrastMaxTxtBox);

        //
        // ContrastMinTxtBox
        //
        this.ContrastMinTxtBox = new System.Windows.Forms.TextBox();
        this.ContrastMinTxtBox.Text =  "oTextBox10";
        this.ContrastMinTxtBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
        this.ContrastMinTxtBox.BackColor = System.Drawing.SystemColors.ButtonHighlight;
        this.ContrastMinTxtBox.ReadOnly =  true;
        this.ContrastMinTxtBox.Location = new System.Drawing.Point(128,104);
        this.ContrastMinTxtBox.Name =  "ContrastMinTxtBox";
        this.ContrastMinTxtBox.Size = new System.Drawing.Size(48,27);
        this.ContrastMinTxtBox.TabIndex = 56;
        this.ContrastMinTxtBox.Anchor = (System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
        this.GroupBox3.Controls.Add(this.ContrastMinTxtBox);

        //
        // ContrastMaxHScrBar
        //
        this.ContrastMaxHScrBar = new System.Windows.Forms.HScrollBar();
        this.ContrastMaxHScrBar.BackColor = System.Drawing.SystemColors.ActiveCaption;
        this.ContrastMaxHScrBar.Maximum = 309;
        this.ContrastMaxHScrBar.Minimum = 100;
        this.ContrastMaxHScrBar.Text =  "HScrollBar2";
        this.ContrastMaxHScrBar.Value = 100;
        this.ContrastMaxHScrBar.Location = new System.Drawing.Point(16,64);
        this.ContrastMaxHScrBar.Name =  "ContrastMaxHScrBar";
        this.ContrastMaxHScrBar.Size = new System.Drawing.Size(192,32);
        this.ContrastMaxHScrBar.TabIndex = 57;
        this.ContrastMaxHScrBar.Anchor = (System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right);
        this.GroupBox3.Controls.Add(this.ContrastMaxHScrBar);

        //
        // ContrastMinHScrBar
        //
        this.ContrastMinHScrBar = new System.Windows.Forms.HScrollBar();
        this.ContrastMinHScrBar.BackColor = System.Drawing.SystemColors.ActiveCaption;
        this.ContrastMinHScrBar.Maximum = 309;
        this.ContrastMinHScrBar.Minimum = 100;
        this.ContrastMinHScrBar.Text =  "HScrollBar3";
        this.ContrastMinHScrBar.Value = 100;
        this.ContrastMinHScrBar.Location = new System.Drawing.Point(16,136);
        this.ContrastMinHScrBar.Name =  "ContrastMinHScrBar";
        this.ContrastMinHScrBar.Size = new System.Drawing.Size(192,32);
        this.ContrastMinHScrBar.TabIndex = 58;
        this.ContrastMinHScrBar.Anchor = (System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right);
        this.GroupBox3.Controls.Add(this.ContrastMinHScrBar);

        //
        // BrightRndPreviewBtn
        //
        this.BrightRndPreviewBtn = new System.Windows.Forms.Button();
        this.BrightRndPreviewBtn.BackColor = System.Drawing.SystemColors.ButtonFace;
        this.BrightRndPreviewBtn.Text =  "ランダムプレビュー";
        this.BrightRndPreviewBtn.Location = new System.Drawing.Point(8,456);
        this.BrightRndPreviewBtn.Name =  "BrightRndPreviewBtn";
        this.BrightRndPreviewBtn.Size = new System.Drawing.Size(224,40);
        this.BrightRndPreviewBtn.TabIndex = 59;
        this.BrightRndPreviewBtn.Anchor = (System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right);
        this.BrightPage.Controls.Add(this.BrightRndPreviewBtn);

        //
        // ContrastChkBox
        //
        this.ContrastChkBox = new System.Windows.Forms.CheckBox();
        this.ContrastChkBox.AutoSize =  true;
        this.ContrastChkBox.BackColor = System.Drawing.SystemColors.ActiveCaption;
        this.ContrastChkBox.Text =  "コントラスト（有効／無効）";
        this.ContrastChkBox.Location = new System.Drawing.Point(8,232);
        this.ContrastChkBox.Name =  "ContrastChkBox";
        this.ContrastChkBox.Size = new System.Drawing.Size(198,24);
        this.ContrastChkBox.TabIndex = 60;
        this.BrightPage.Controls.Add(this.ContrastChkBox);

        //
        // RndNoiseChkBox
        //
        this.RndNoiseChkBox = new System.Windows.Forms.CheckBox();
        this.RndNoiseChkBox.Checked =  true;
        this.RndNoiseChkBox.AutoSize =  true;
        this.RndNoiseChkBox.BackColor = System.Drawing.SystemColors.ActiveCaption;
        this.RndNoiseChkBox.Text =  "ランダムノイズ（有効／無効）";
        this.RndNoiseChkBox.Location = new System.Drawing.Point(8,8);
        this.RndNoiseChkBox.Name =  "RndNoiseChkBox";
        this.RndNoiseChkBox.Size = new System.Drawing.Size(212,24);
        this.RndNoiseChkBox.TabIndex = 61;
        this.RndNoisePage.Controls.Add(this.RndNoiseChkBox);

        //
        // GroupBox4
        //
        this.GroupBox4 = new System.Windows.Forms.GroupBox();
        this.GroupBox4.Text =  "ノイズ設定";
        this.GroupBox4.BackColor = System.Drawing.SystemColors.ActiveCaption;
        this.GroupBox4.Location = new System.Drawing.Point(8,40);
        this.GroupBox4.Name =  "GroupBox4";
        this.GroupBox4.Size = new System.Drawing.Size(224,184);
        this.GroupBox4.TabIndex = 62;
        this.GroupBox4.Anchor = (System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right);
        this.RndNoisePage.Controls.Add(this.GroupBox4);

        //
        // RndNoiseScrBar
        //
        this.RndNoiseScrBar = new System.Windows.Forms.HScrollBar();
        this.RndNoiseScrBar.BackColor = System.Drawing.SystemColors.ActiveCaption;
        this.RndNoiseScrBar.Maximum = 264;
        this.RndNoiseScrBar.Minimum = 128;
        this.RndNoiseScrBar.Text =  "HScrollBar4";
        this.RndNoiseScrBar.Value = 137;
        this.RndNoiseScrBar.Location = new System.Drawing.Point(16,64);
        this.RndNoiseScrBar.Name =  "RndNoiseScrBar";
        this.RndNoiseScrBar.Size = new System.Drawing.Size(192,32);
        this.RndNoiseScrBar.TabIndex = 65;
        this.RndNoiseScrBar.Anchor = (System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right);
        this.GroupBox4.Controls.Add(this.RndNoiseScrBar);

        //
        // RndNoiseTxtBox
        //
        this.RndNoiseTxtBox = new System.Windows.Forms.TextBox();
        this.RndNoiseTxtBox.Text =  "TextBox11";
        this.RndNoiseTxtBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
        this.RndNoiseTxtBox.BackColor = System.Drawing.SystemColors.ButtonHighlight;
        this.RndNoiseTxtBox.ReadOnly =  true;
        this.RndNoiseTxtBox.Location = new System.Drawing.Point(160,32);
        this.RndNoiseTxtBox.Name =  "RndNoiseTxtBox";
        this.RndNoiseTxtBox.Size = new System.Drawing.Size(52,27);
        this.RndNoiseTxtBox.TabIndex = 66;
        this.RndNoiseTxtBox.Anchor = (System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
        this.GroupBox4.Controls.Add(this.RndNoiseTxtBox);

        //
        // RndNoiseRatioScrBar
        //
        this.RndNoiseRatioScrBar = new System.Windows.Forms.HScrollBar();
        this.RndNoiseRatioScrBar.BackColor = System.Drawing.SystemColors.ActiveCaption;
        this.RndNoiseRatioScrBar.Maximum = 59;
        this.RndNoiseRatioScrBar.Minimum = 1;
        this.RndNoiseRatioScrBar.Text =  "HScrollBar5";
        this.RndNoiseRatioScrBar.Value = 1;
        this.RndNoiseRatioScrBar.Location = new System.Drawing.Point(16,136);
        this.RndNoiseRatioScrBar.Name =  "RndNoiseRatioScrBar";
        this.RndNoiseRatioScrBar.Size = new System.Drawing.Size(192,32);
        this.RndNoiseRatioScrBar.TabIndex = 68;
        this.RndNoiseRatioScrBar.Anchor = (System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right);
        this.GroupBox4.Controls.Add(this.RndNoiseRatioScrBar);

        //
        // RndNoiseRatioTxtBox
        //
        this.RndNoiseRatioTxtBox = new System.Windows.Forms.TextBox();
        this.RndNoiseRatioTxtBox.Text =  "TextBox12";
        this.RndNoiseRatioTxtBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
        this.RndNoiseRatioTxtBox.BackColor = System.Drawing.SystemColors.ButtonHighlight;
        this.RndNoiseRatioTxtBox.ReadOnly =  true;
        this.RndNoiseRatioTxtBox.Location = new System.Drawing.Point(160,104);
        this.RndNoiseRatioTxtBox.Name =  "RndNoiseRatioTxtBox";
        this.RndNoiseRatioTxtBox.Size = new System.Drawing.Size(48,27);
        this.RndNoiseRatioTxtBox.TabIndex = 69;
        this.RndNoiseRatioTxtBox.Anchor = (System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
        this.GroupBox4.Controls.Add(this.RndNoiseRatioTxtBox);

        //
        // Label6
        //
        this.Label6 = new System.Windows.Forms.Label();
        this.Label6.AutoSize =  true;
        this.Label6.Text =  "ノイズ";
        this.Label6.BackColor = System.Drawing.SystemColors.ActiveCaption;
        this.Label6.Location = new System.Drawing.Point(16,32);
        this.Label6.Name =  "Label6";
        this.Label6.Size = new System.Drawing.Size(42,20);
        this.Label6.TabIndex = 70;
        this.GroupBox4.Controls.Add(this.Label6);

        //
        // Label7
        //
        this.Label7 = new System.Windows.Forms.Label();
        this.Label7.AutoSize =  true;
        this.Label7.Text =  "割合";
        this.Label7.BackColor = System.Drawing.SystemColors.ActiveCaption;
        this.Label7.Location = new System.Drawing.Point(16,104);
        this.Label7.Name =  "Label7";
        this.Label7.Size = new System.Drawing.Size(39,20);
        this.Label7.TabIndex = 71;
        this.GroupBox4.Controls.Add(this.Label7);

        //
        // RndNoisePreviewBtn
        //
        this.RndNoisePreviewBtn = new System.Windows.Forms.Button();
        this.RndNoisePreviewBtn.BackColor = System.Drawing.SystemColors.ButtonFace;
        this.RndNoisePreviewBtn.Text =  "ランダムプレビュー";
        this.RndNoisePreviewBtn.Location = new System.Drawing.Point(8,240);
        this.RndNoisePreviewBtn.Name =  "RndNoisePreviewBtn";
        this.RndNoisePreviewBtn.Size = new System.Drawing.Size(224,40);
        this.RndNoisePreviewBtn.TabIndex = 72;
        this.RndNoisePreviewBtn.Anchor = (System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right);
        this.RndNoisePage.Controls.Add(this.RndNoisePreviewBtn);

        //
        // Label8
        //
        this.Label8 = new System.Windows.Forms.Label();
        this.Label8.AutoSize =  true;
        this.Label8.Text =  "/100";
        this.Label8.BackColor = System.Drawing.SystemColors.ActiveCaption;
        this.Label8.Location = new System.Drawing.Point(176,32);
        this.Label8.Name =  "Label8";
        this.Label8.Size = new System.Drawing.Size(39,20);
        this.Label8.TabIndex = 70;
        this.Label8.Anchor = (System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
        this.GroupBox3.Controls.Add(this.Label8);

        //
        // Label9
        //
        this.Label9 = new System.Windows.Forms.Label();
        this.Label9.AutoSize =  true;
        this.Label9.Text =  "/100";
        this.Label9.BackColor = System.Drawing.SystemColors.ActiveCaption;
        this.Label9.Location = new System.Drawing.Point(176,104);
        this.Label9.Name =  "Label9";
        this.Label9.Size = new System.Drawing.Size(39,20);
        this.Label9.TabIndex = 71;
        this.Label9.Anchor = (System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
        this.GroupBox3.Controls.Add(this.Label9);

        //
        // SplitContainer2
        //
        this.SplitContainer2 = new System.Windows.Forms.SplitContainer();
        this.SplitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
        this.SplitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
        this.SplitContainer2.Text =  "SplitContainer2";
        this.SplitContainer2.BackColor = System.Drawing.Color.Gray;
        this.SplitContainer2.Name =  "SplitContainer2";
        this.SplitContainer2.Size = new System.Drawing.Size(748,593);
        this.SplitContainer2.TabIndex = 72;
        this.SplitContainer2.SplitterDistance = 263;
        this.SplitPage.Controls.Add(this.SplitContainer2);

        //
        // PicBox3
        //
        this.PicBox3 = new System.Windows.Forms.PictureBox();
        this.PicBox3.TabIndex = 73;
        this.PicBox3.Text =  "PictureBox2";
        this.PicBox3.BackColor = System.Drawing.Color.White;
        this.PicBox3.Dock = System.Windows.Forms.DockStyle.Fill;
        this.PicBox3.Name =  "PicBox3";
        this.PicBox3.Size = new System.Drawing.Size(479,591);
        this.SplitContainer2.Panel2.Controls.Add(this.PicBox3);

        //
        // SplitTab
        //
        this.SplitTab = new System.Windows.Forms.TabControl();
        this.SplitTab.ItemSize = new System.Drawing.Size(60,20);
        this.SplitTab.Text =  "TabControl3";
        this.SplitTab.Location = new System.Drawing.Point(8,8);
        this.SplitTab.Name =  "SplitTab";
        this.SplitTab.Size = new System.Drawing.Size(250,568);
        this.SplitTab.TabIndex = 74;
        this.SplitTab.Anchor = (System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right);
        this.SplitContainer2.Panel1.Controls.Add(this.SplitTab);

        //
        // SplitOptPage
        //
        this.SplitOptPage = new System.Windows.Forms.TabPage();
        this.SplitOptPage.BackColor = System.Drawing.SystemColors.ActiveCaption;
        this.SplitOptPage.Location = new System.Drawing.Point(4,24);
        this.SplitOptPage.TabIndex = 75;
        this.SplitOptPage.Text =  "分割設定";
        this.SplitOptPage.Name =  "SplitOptPage";
        this.SplitOptPage.Size = new System.Drawing.Size(242,540);
        this.SplitTab.Controls.Add(this.SplitOptPage);

        //
        // Label10
        //
        this.Label10 = new System.Windows.Forms.Label();
        this.Label10.AutoSize =  true;
        this.Label10.Text =  "1/";
        this.Label10.BackColor = System.Drawing.SystemColors.ActiveCaption;
        this.Label10.Location = new System.Drawing.Point(136,104);
        this.Label10.Name =  "Label10";
        this.Label10.Size = new System.Drawing.Size(23,20);
        this.Label10.TabIndex = 74;
        this.GroupBox4.Controls.Add(this.Label10);

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
    private Button MaskColorBtn;
    private StatusStrip StatusStrip1;
    private StatusStrip StatusStrip2;
    private ListView LabelLstView;
    private ListView MaskLstView;
    private SplitContainer SplitContainer1;
    private TabControl ImageTab;
    private TabPage BrightPage;
    private TabPage RndNoisePage;
    private PictureBox PicBox2;
    private CheckBox BrightChkBox;
    private GroupBox GroupBox2;
    private HScrollBar BrightMaxHScrBar;
    private TextBox BrightMaxTxtBox;
    private HScrollBar BrightMinHScrBar;
    private TextBox BrightMinTxtBox;
    private GroupBox GroupBox3;
    private RadioButton BrightMaxRadioBtn;
    private RadioButton BrightMinRadioBtn;
    private RadioButton ContrastMaxRadioBtn;
    private RadioButton ContrastMinRadioBtn;
    private TextBox ContrastMaxTxtBox;
    private TextBox ContrastMinTxtBox;
    private HScrollBar ContrastMaxHScrBar;
    private HScrollBar ContrastMinHScrBar;
    private Button BrightRndPreviewBtn;
    private CheckBox ContrastChkBox;
    private CheckBox RndNoiseChkBox;
    private GroupBox GroupBox4;
    private HScrollBar RndNoiseScrBar;
    private TextBox RndNoiseTxtBox;
    private HScrollBar RndNoiseRatioScrBar;
    private TextBox RndNoiseRatioTxtBox;
    private Label Label6;
    private Label Label7;
    private Button RndNoisePreviewBtn;
    private Label Label8;
    private Label Label9;
    private SplitContainer SplitContainer2;
    private PictureBox PicBox3;
    private TabControl SplitTab;
    private TabPage SplitOptPage;
    private Label Label10;
}
