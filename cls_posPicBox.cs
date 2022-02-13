using System.Runtime.Serialization;
namespace IMG_Gen2;

public partial class cls_posPicBox : PictureBox
{
    private TabPage? PosPage;
    private ToolStripStatusLabel? sLabel;
    private Bitmap? bmp;                                // 表示するBitmap
    private Graphics? g;                                // 描画用Graphicsオブジェクト
    private System.Drawing.Drawing2D.Matrix? mat;       // アフィン変換行列
    private float baseScale;                                // 表示倍率
    private float scale;                                // 表示倍率
    private Point pos;                                  // マウス座標
    private bool MouseDownFlg = false;                  // マウスダウンフラグ
    private bool labelFlag = false;
    private Point OldPoint;                             // マウス座標記憶

    public cls_posPicBox(TabPage PosPage, ToolStripStatusLabel sLabel)
    {
        this.PosPage = PosPage;
        this.sLabel = sLabel;

        Controls_EventHandler();
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

    private void Control_MouseDown(object? sender, MouseEventArgs e)
    {
        if (mat == null) { return; }

        OldPoint.X = e.X;
        OldPoint.Y = e.Y;

        if (Control.ModifierKeys == Keys.Control)
        {
            labelFlag = true;
            return;
        }

        if (e.Button == System.Windows.Forms.MouseButtons.Right)
        {
            ImageReset();
            return;
        }

        MouseDownFlg = true;
    }
    private void Control_MouseUp(object? sender, MouseEventArgs e)
    {
        MouseDownFlg = false;
        labelFlag = false;
    }
    private void Control_MouseMove(object? sender, MouseEventArgs e)
    {
        if (mat == null) { return; }

        // pos.X = (int)((float)(e.X) / scale) - (int)((float)(mat.Elements[4]) / scale);
        pos.X = (int)((e.X - mat.Elements[4]) / scale);
        pos.Y = (int)((e.Y - mat.Elements[5]) / scale);
        sLabel!.Text = "Scale = " + scale.ToString() + " Pos.X = " + pos.X.ToString() + " Pos.Y = " + pos.Y.ToString();

        if (MouseDownFlg)
        {
            mat!.Translate(e.X - OldPoint.X, e.Y - OldPoint.Y, System.Drawing.Drawing2D.MatrixOrder.Append);
            DrawImage();

            OldPoint.X = e.X;
            OldPoint.Y = e.Y;
        }
        else if (labelFlag)
        {
            int movX;       // 画像移動量:X or 四角の幅
            int movY;       // 画像移動量:Y or 四角の高さ

            // 画像上のマウス座標取得し、画像移動量Ｘ＆Ｙ or 四角の高さ＆幅を算出
            movX = e.X - OldPoint.X;
            movY = e.Y - OldPoint.Y;

            Pen p = new Pen(Color.Red, 3 / scale);

            //長方形を描く
            int x1;
            int y1;
            int w1;
            int h1;

            if (movX > 0)
            {
                x1 = (int)((OldPoint.X - mat.Elements[4]) / scale);
                w1 = (int)((movX + OldPoint.X - mat.Elements[4]) / scale);
            }
            else
            {
                movX = OldPoint.X - e.X;
                x1 = (int)((e.X - mat.Elements[4]) / scale);
                w1 = (int)((movX + e.X - mat.Elements[4]) / scale);
            }

            if (movY > 0)
            {
                y1 = (int)((OldPoint.Y - mat.Elements[5]) / scale);
                h1 = (int)((movY + OldPoint.Y - mat.Elements[5]) / scale);
            }
            else
            {
                movY *= -1;
                y1 = (int)((e.Y - mat.Elements[5]) / scale);
                h1 = (int)((movY + e.Y - mat.Elements[5]) / scale);
            }

            g!.DrawRectangle(p, x1, y1, w1 - x1, h1 - y1);

            //リソースを解放する
            p.Dispose();
            this.Refresh();
            g.DrawImage(bmp!, 0, 0);
        }
    }
    private void Control_MouseWheel(object? sender, MouseEventArgs e)
    {
        if (bmp == null) { return; }

        mat!.Translate(-e.X, -e.Y, System.Drawing.Drawing2D.MatrixOrder.Append);

        if (e.Delta > 0)
        {
            if (mat.Elements[0] < 100)
            {
                mat.Scale(1.5f, 1.5f, System.Drawing.Drawing2D.MatrixOrder.Append);
            }
        }
        else
        {
            if (mat.Elements[0] > baseScale)
            {
                mat.Scale(1.0f / 1.5f, 1.0f / 1.5f, System.Drawing.Drawing2D.MatrixOrder.Append);
            }
        }

        if (mat.Elements[0] > baseScale)
        {
            mat.Translate(e.X, e.Y, System.Drawing.Drawing2D.MatrixOrder.Append);
            DrawImage();
        }
        else
        {
            ImageReset();
        }
    }
    private void Control_ReSize(object? sender, EventArgs? e)
    {
        if (g != null)
        {
            mat = g.Transform;
            g.Dispose();
            g = null;
        }

        Bitmap bmpPicBox = new Bitmap(this.Width, this.Height);
        this.Image = bmpPicBox;
        g = Graphics.FromImage(this.Image);

        if (mat != null)
        {
            g.Transform = mat;
        }

        g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
        // g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
        DrawImage();
    }
    private void DrawImage()
    {
        if (bmp == null) return;

        if (mat != null)
        {
            g!.Transform = mat;
        }

        g!.Clear(this.BackColor);
        g.DrawImage(bmp, 0, 0);
        this.Refresh();

        scale = mat!.Elements[0];
        sLabel!.Text = "Scale = " + scale.ToString() + " Pos.X = " + pos.X.ToString() + " Pos.Y = " + pos.Y.ToString();
    }

    internal void SetImage(string filePath)
    {
        if (bmp != null)
        {
            bmp.Dispose();
        }
        bmp = new Bitmap(filePath);
        mat = new System.Drawing.Drawing2D.Matrix();

        ImageReset();
    }
    private void ImageReset()
    {
        float scaleX = (float)this.Width / (float)bmp!.Width;
        float scaleY = (float)this.Height / (float)bmp.Height;

        if (scaleX < scaleY)
        {
            this.baseScale = scaleX;
        }
        else
        {
            this.baseScale = scaleY;
        }

        scale = baseScale;

        mat!.Reset();
        mat.Scale(baseScale, baseScale, System.Drawing.Drawing2D.MatrixOrder.Prepend);
        DrawImage();
    }
}
