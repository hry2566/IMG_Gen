namespace IMG_Gen2
{
    public class cls_label_rectangle
    {
        cls_posPicBox posPicBox;
        private Button btn = new();
        private Graphics? g;
        private string? labelName;
        private Color color;
        private int penWidth;
        private Point pos;
        private Size size;
        private cls_selectbox selectBox;
        private bool selectFlag = false;
        private System.Drawing.Drawing2D.Matrix? mat;

        public cls_label_rectangle(cls_posPicBox posPicBox, Graphics g, string labelName, string strColor, string strWidth, int x1, int y1, int x2, int y2)
        {
            this.posPicBox = posPicBox;
            this.g = g;
            this.labelName = labelName;
            this.color = String2Color(strColor);
            this.penWidth = int.Parse(strWidth);
            pos.X = x1;
            pos.Y = y1;
            size.Width = x2 - x1;
            size.Height = y2 - y1;

            btn.Visible = false;
            posPicBox.Controls.Add(btn);
            selectBox = new(posPicBox,pos,size);

            btn.Click += new EventHandler(Btn_Click);
        }

        private void Btn_Click(Object? sender, EventArgs e)
        {
            if(selectFlag){
                selectFlag = false;
                selectBox.SetShow(false);
            }else{
                posPicBox.AllUnSelect();
                selectFlag = true;
                selectBox.SetShow(true);

            }
        }

        internal void SetSelect(bool selectFlag)
        {
            this.selectFlag = selectFlag;
            selectBox.SetShow(selectFlag);
        }

        public void DrawLabel(float scale, System.Drawing.Drawing2D.Matrix mat)
        {
            this.mat = mat;

            btn.Location = new Point((int)((pos.X * scale) + mat.Elements[4]), (int)((pos.Y * scale) + mat.Elements[5]));
            btn.Size = new Size((int)((size.Width / 5) * scale), (int)((size.Height / 5) * scale));
            btn.Visible = true;

            selectBox.SetPos(pos,mat,size);

            Pen p = new Pen(color, penWidth / scale);
            try
            {
                g!.DrawRectangle(p, pos.X, pos.Y, size.Width, size.Height);
            }
            catch { }
        }

        public void Delete()
        {
            btn.Dispose();
            selectBox.Delete();
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
}