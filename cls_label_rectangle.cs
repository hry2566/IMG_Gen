namespace IMG_Gen2
{
    public class cls_label_rectangle
    {
        private Button btn = new();
        private Graphics? g;
        private string? labelName;
        private Color color;
        private int penWidth;
        private Point pos;
        private Size size;

        public cls_label_rectangle(Control posPicBox, Graphics g, string labelName, string strColor, string strWidth, int x1, int y1, int x2, int y2)
        {
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
        }

        public void DrawLabel(float scale, System.Drawing.Drawing2D.Matrix mat)
        {
            btn.Location = new Point((int)((pos.X * scale) + mat.Elements[4]), (int)((pos.Y * scale) + mat.Elements[5]));
            btn.Size = new Size((int)((size.Width / 5) * scale), (int)((size.Height / 5) * scale));
            btn.Visible = true;

            for (int i = 0; i < mat.Elements.Count(); i++)
            {
                Console.WriteLine(i.ToString() + " " + mat.Elements[i].ToString());
            }

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