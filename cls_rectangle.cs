
namespace IMG_Gen2
{
    public class cls_rectangle
    {
        private cls_posPicBox posPicBox;
        private Button btn = new();                     // 選択用
        private Graphics? g;                            // 描画用Graphicsオブジェクト
        internal string? labelName;                     // ラベル名（マスク名含む）
        internal string strColor;                       // 色（文字列）
        internal int penWidth;                          // ペン幅
        internal Point pos;                             // 四角位置
        internal Size size;                             // 四角サイズ
        private cls_selectbox selectBox;                // 選択ボックス
        internal bool selectFlag = false;               // 選択フラグ
        private System.Drawing.Drawing2D.Matrix? mat;   // アフィン変換行列
        private Point memPos;                           // 座標記憶
        private bool changeFlag = false;                // 編集フラグ
        private Size memSize;                           // サイズ記憶
        public cls_rectangle(cls_posPicBox posPicBox, Graphics g, string labelName, string strColor, string strWidth, int x1, int y1, int x2, int y2)
        {
            this.posPicBox = posPicBox;
            this.g = g;
            this.labelName = labelName;
            this.strColor = strColor;
            this.penWidth = int.Parse(strWidth);

            pos.X = x1;
            pos.Y = y1;
            size.Width = x2 - x1;
            size.Height = y2 - y1;
            btn.Visible = false;
            posPicBox.Controls.Add(btn);
            selectBox = new(this, posPicBox, pos, size);

            btn.Click += new EventHandler(Btn_Click);
            btn.MouseDown += new MouseEventHandler(Btn_MouseDown);
            btn.MouseMove += new MouseEventHandler(Btn_MouseMove);
            btn.MouseUp += new MouseEventHandler(Btn_MouseUp);
        }

        // ***********************************************************************
        // Btn
        // ***********************************************************************
        private void Btn_MouseUp(object? sender, MouseEventArgs e)
        {
            if (changeFlag)
            {
                posPicBox.SaveLabel();
                posPicBox.SaveMask();
                changeFlag = false;
            }
        }
        private void Btn_MouseDown(object? sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && selectFlag)
            {
                memPos.X = e.X;
                memPos.Y = e.Y;
            }
        }
        private void Btn_MouseMove(object? sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && selectFlag)
            {
                changeFlag = true;
                pos.X = (int)((e.X - memPos.X + btn.Location.X - mat!.Elements[4]) / mat.Elements[0]);
                pos.Y = (int)((e.Y - memPos.Y + btn.Location.Y - mat.Elements[5]) / mat.Elements[0]);
                posPicBox.DrawImage();
            }
        }
        private void Btn_Click(Object? sender, EventArgs e)
        {
            if (selectFlag && !changeFlag)
            {
                selectFlag = false;
                selectBox.SetShow(false);
            }
            else
            {
                posPicBox.AllUnSelect();
                selectFlag = true;
                selectBox.SetShow(true);
            }
        }

        // ***********************************************************************
        // SelectBox
        // ***********************************************************************
        internal void SelectboxMouseDown(object? sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && selectFlag)
            {
                memPos.X = e.X;
                memPos.Y = e.Y;
                memSize.Width = pos.X + size.Width;
                memSize.Height = pos.Y + size.Height;
                changeFlag = true;
            }
        }
        internal void SelectboxMouseUp(object? sender, MouseEventArgs e)
        {
            if (changeFlag)
            {
                posPicBox.SaveLabel();
                posPicBox.SaveMask();
                posPicBox.DrawImage();
                changeFlag = false;
            }
        }
        internal void SelectboxMouseMove(object? sender, MouseEventArgs e)
        {
            Panel? move_selectbox = sender as Panel;

            if (e.Button == MouseButtons.Left && changeFlag)
            {
                Point newPos = new(e.X - memPos.X + move_selectbox!.Location.X, e.Y - memPos.Y + move_selectbox.Location.Y);
                move_selectbox.Location = newPos;

                switch (move_selectbox!.TabIndex)
                {
                    case 0:
                        pos.X = (int)((newPos.X + 8 - mat!.Elements[4]) / mat.Elements[0]);
                        pos.Y = (int)((newPos.Y + 8 - mat!.Elements[5]) / mat.Elements[0]);
                        size.Width = (int)(memSize.Width - pos.X);
                        size.Height = (int)(memSize.Height - pos.Y);
                        break;
                    case 1:
                        pos.Y = (int)((newPos.Y + 8 - mat!.Elements[5]) / mat.Elements[0]);
                        size.Width = (int)((int)((newPos.X - mat!.Elements[4]) / mat.Elements[0]) - pos.X);
                        size.Height = (int)(memSize.Height - pos.Y);
                        break;
                    case 2:
                        pos.X = (int)((newPos.X + 8 - mat!.Elements[4]) / mat.Elements[0]);
                        size.Width = (int)(memSize.Width - pos.X);
                        size.Height = (int)((int)((newPos.Y - mat!.Elements[5]) / mat.Elements[0]) - pos.Y);
                        break;
                    case 3:
                        size.Width = (int)((int)((newPos.X - mat!.Elements[4]) / mat.Elements[0]) - pos.X);
                        size.Height = (int)((int)((newPos.Y - mat!.Elements[5]) / mat.Elements[0]) - pos.Y);
                        break;
                }
                posPicBox.DrawImage();
            }
        }

        // ***********************************************************************
        // 関数
        // ***********************************************************************
        internal void SetSelect(bool selectFlag)
        {
            this.selectFlag = selectFlag;
            selectBox.SetShow(selectFlag);
        }
        internal void DrawRectangle(System.Drawing.Drawing2D.Matrix mat)
        {
            int width = (int)(size.Width / 5 * mat.Elements[0]);
            int height = (int)(size.Height / 5 * mat.Elements[0]);
            int btnSize;
            if (width > height)
            {
                btnSize = width;
            }
            else
            {
                btnSize = height;
            }
            if (btnSize < 5 || btnSize > 30)
            {
                btnSize = 30;
            }

            this.mat = mat;
            btn.Location = new Point((int)((pos.X * mat.Elements[0]) + mat.Elements[4]), (int)((pos.Y * mat.Elements[0]) + mat.Elements[5]));
            btn.Size = new Size(btnSize, btnSize);
            btn.Visible = true;
            btn.BackColor = cls_posPicBox.String2Color(strColor);
            btn.Cursor = Cursors.SizeAll;
            selectBox.SetPos(pos, size, mat);

            Pen p = new Pen(cls_posPicBox.String2Color(strColor), penWidth / mat.Elements[0]);
            try
            {
                if (labelName == "Mask")
                {
                    SolidBrush sBrush = new(Color.FromArgb(128, cls_posPicBox.String2Color(strColor)));
                    g!.FillRectangle(sBrush, pos.X, pos.Y, size.Width, size.Height);
                    g!.DrawRectangle(p, pos.X, pos.Y, size.Width, size.Height);
                }
                else
                {
                    g!.DrawRectangle(p, pos.X, pos.Y, size.Width, size.Height);
                }
            }
            catch { }
        }
        internal void Delete()
        {
            btn.Dispose();
            selectBox.Delete();
        }
    }
}