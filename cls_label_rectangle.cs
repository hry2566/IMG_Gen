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
        private Point memPos;
        private bool changeFlag = false;


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
            btn.MouseDown += new MouseEventHandler(Btn_MouseDown);
            btn.MouseMove += new MouseEventHandler(Btn_MouseMove);
        }
        private void Btn_MouseDown(object? sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && selectFlag)
            {
                memPos.X = e.X ;
                memPos.Y =e.Y ;
            }
        }
        private void Btn_MouseMove(object? sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && selectFlag)
            {
                Point btnPos = new(e.X , e.Y);
                Point newPos = new(btnPos.X - memPos.X + btn.Location.X, btnPos.Y - memPos.Y + btn.Location.Y);

                btn.Location = newPos;
                Pen p = new Pen(color, penWidth / mat!.Elements[0]);
                try
                {
                    posPicBox.DrawImage();
                    g!.DrawRectangle(p, (btnPos.X - memPos.X + btn.Location.X - mat.Elements[4])/mat.Elements[0], (btnPos.Y - memPos.Y + btn.Location.Y - mat.Elements[5])/mat.Elements[0], size.Width, size.Height);
                    posPicBox.Refresh();
                }
                catch { }

                selectFlag = true;
                changeFlag = false;
            }
            else
            {
                changeFlag = true;
            }
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