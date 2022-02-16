namespace IMG_Gen2
{
    public class cls_selectbox
    {
        private Panel[] selectbox = new Panel[4];       // 選択ボックス
        private Point pos;                              // 四角位置
        private Size size;                              // 四角サイズ
        
        public cls_selectbox(cls_rectangle rectangle, Control posPicBox, Point pos, Size size)
        {
            this.pos = pos;
            this.size = size;
            Init(posPicBox, rectangle);
        }
        private void Init(Control posPicBox, cls_rectangle rectangle)
        {
            for (int i = 0; i < 4; i++)
            {
                this.selectbox[i] = new Panel();
                if (i == 1 || i == 2)
                {
                    this.selectbox[i].Cursor = Cursors.SizeNESW;
                }
                else if (i == 0 || i == 3)
                {
                    this.selectbox[i].Cursor = Cursors.SizeNWSE;
                }

                this.selectbox[i].BorderStyle = BorderStyle.FixedSingle;
                this.selectbox[i].BackColor = System.Drawing.Color.White;
                this.selectbox[i].Size = new Size(8, 8);
                this.selectbox[i].Visible = false;
                this.selectbox[i].TabIndex = i;

                this.selectbox[i].MouseDown += new MouseEventHandler(rectangle.SelectboxMouseDown);
                this.selectbox[i].MouseUp += new MouseEventHandler(rectangle.SelectboxMouseUp);
                this.selectbox[i].MouseMove += new MouseEventHandler(rectangle.SelectboxMouseMove);
            }
            posPicBox.Controls.AddRange(this.selectbox);
        }
        internal void SetShow(bool flag)
        {
            for (int i = 0; i < 4; i++)
            {
                this.selectbox[i].Visible = flag;
            }
        }
        internal void SetPos(Point pos, Size size, System.Drawing.Drawing2D.Matrix mat)
        {
            this.selectbox[0].Location = new Point(
                (int)((pos.X * mat.Elements[0]) + mat.Elements[4]) - 8,
                (int)((pos.Y * mat.Elements[0]) + mat.Elements[5]) - 8);

            this.selectbox[1].Location = new Point(
                (int)((pos.X * mat.Elements[0]) + mat.Elements[4] + size.Width * mat.Elements[0]),
                (int)((pos.Y * mat.Elements[0]) + mat.Elements[5]) - 8);

            this.selectbox[2].Location = new Point(
                (int)((pos.X * mat.Elements[0]) + mat.Elements[4]) - 8,
                (int)((pos.Y * mat.Elements[0]) + mat.Elements[5] + size.Height * mat.Elements[0]));

            this.selectbox[3].Location = new Point(
                (int)((pos.X * mat.Elements[0]) + mat.Elements[4] + size.Width * mat.Elements[0]),
                (int)((pos.Y * mat.Elements[0]) + mat.Elements[5] + size.Height * mat.Elements[0]));
        }
        internal void Delete()
        {
            for (int i = 0; i < 4; i++)
            {
                this.selectbox[i].Dispose();
            }
        }
    }
}