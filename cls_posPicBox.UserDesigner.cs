namespace IMG_Gen2;

partial class cls_posPicBox : PictureBox
{
    #region 
    private void InitializeUserComponent()
    {

    }
    private void Controls_EventHandler()
    {
        //this
        this.MouseWheel += new System.Windows.Forms.MouseEventHandler(Control_MouseWheel);
        this.MouseDown += new MouseEventHandler(Control_MouseDown);
        this.MouseUp += new MouseEventHandler(Control_MouseUp);
        this.MouseMove += new MouseEventHandler(Control_MouseMove);

        //PosPage
        PosPage!.Resize += new EventHandler(Control_ReSize);
    }

    #endregion
    private TabPage? PosPage;
    private ToolStripStatusLabel? sLabel;
    private ListView LabelLstView;

}
