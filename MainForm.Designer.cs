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
        this.Location = new System.Drawing.Point(498,316);
        this.Size = new System.Drawing.Size(1182,795);
        this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        this.Text =  "IMG_Gen2";
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
        this.RootPathTxtBox.Anchor = (System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right);
        this.RootPathTxtBox.Location = new System.Drawing.Point(152,20);
        this.RootPathTxtBox.Name =  "RootPathTxtBox";
        this.RootPathTxtBox.Size = new System.Drawing.Size(984,27);
        this.RootPathTxtBox.TabIndex = 1;
        this.Controls.Add(this.RootPathTxtBox);

        //
        // SplitContainer0
        //
        this.SplitContainer0 = new System.Windows.Forms.SplitContainer();
        this.SplitContainer0.Text =  "SplitContainer0";
        this.SplitContainer0.Anchor = (System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right);
        this.SplitContainer0.BackColor = System.Drawing.Color.WhiteSmoke;
        this.SplitContainer0.Location = new System.Drawing.Point(8,72);
        this.SplitContainer0.Name =  "SplitContainer0";
        this.SplitContainer0.Size = new System.Drawing.Size(1136,664);
        this.SplitContainer0.TabIndex = 2;
        this.SplitContainer0.SplitterDistance = 209;
        this.Controls.Add(this.SplitContainer0);

        //
        // TabControl0
        //
        this.TabControl0 = new System.Windows.Forms.TabControl();
        this.TabControl0.ItemSize = new System.Drawing.Size(72,25);
        this.TabControl0.Text =  "TabControl0";
        this.TabControl0.Dock = System.Windows.Forms.DockStyle.Fill;
        this.TabControl0.Name =  "TabControl0";
        this.TabControl0.Size = new System.Drawing.Size(921,662);
        this.TabControl0.TabIndex = 4;
        this.SplitContainer0.Panel2.Controls.Add(this.TabControl0);

        //
        // TabPage0
        //
        this.TabPage0 = new System.Windows.Forms.TabPage();
        this.TabPage0.Location = new System.Drawing.Point(4,29);
        this.TabPage0.TabIndex = 5;
        this.TabPage0.Text =  "座標編集";
        this.TabPage0.Name =  "TabPage0";
        this.TabPage0.Size = new System.Drawing.Size(913,629);
        this.TabControl0.Controls.Add(this.TabPage0);

        //
        // TabPage1
        //
        this.TabPage1 = new System.Windows.Forms.TabPage();
        this.TabPage1.Location = new System.Drawing.Point(4,29);
        this.TabPage1.TabIndex = 6;
        this.TabPage1.Text =  "画像処理";
        this.TabPage1.Name =  "TabPage1";
        this.TabPage1.Size = new System.Drawing.Size(913,629);
        this.TabControl0.Controls.Add(this.TabPage1);

        //
        // TabPage2
        //
        this.TabPage2 = new System.Windows.Forms.TabPage();
        this.TabPage2.Location = new System.Drawing.Point(4,29);
        this.TabPage2.TabIndex = 7;
        this.TabPage2.Text =  "画像分割";
        this.TabPage2.Name =  "TabPage2";
        this.TabPage2.Size = new System.Drawing.Size(913,629);
        this.TabControl0.Controls.Add(this.TabPage2);

    }

    #endregion
    private Button RootSelectBtn;
    private TextBox RootPathTxtBox;
    private SplitContainer SplitContainer0;
    private TabControl TabControl0;
    private TabPage TabPage0;
    private TabPage TabPage1;
    private TabPage TabPage2;
}
