using System.Runtime.Serialization;
namespace IMG_Gen2;

public partial class cls_posPicBox : PictureBox
{
    private TabPage? PosPage;
    private Bitmap? bmp;                                // 表示するBitmap
    private Graphics? g;                                // 描画用Graphicsオブジェクト
    private System.Drawing.Drawing2D.Matrix? mat;       // アフィン変換行列
    private float scale;                                // 表示倍率
    private bool MouseDownFlg = false;                  // マウスダウンフラグ
    private Point OldPoint;                             // マウス座標

    public cls_posPicBox(TabPage PosPage)
    {
        this.PosPage = PosPage;

        Controls_EventHandler();
    }

    private void Controls_EventHandler()
    {
        PosPage!.Resize += new EventHandler(Control_ReSize);
        this.MouseWheel += new System.Windows.Forms.MouseEventHandler(Control_MouseWheel);
        this.MouseDown += new MouseEventHandler(Control_MouseDown);
        this.MouseUp += new MouseEventHandler(Control_MouseUp);
        this.MouseMove += new MouseEventHandler(Control_MouseMove);
    }

    private void Control_MouseDown(object? sender, MouseEventArgs e)
    {
        if (e.Button == System.Windows.Forms.MouseButtons.Right)
        {
            ImageReset();
            return;
        }
        OldPoint.X = e.X;
        OldPoint.Y = e.Y;
        MouseDownFlg = true;
    }
    private void Control_MouseUp(object? sender, MouseEventArgs e)
    {
        MouseDownFlg = false;
    }
    private void Control_MouseMove(object? sender, MouseEventArgs e)
    {
        if (MouseDownFlg == true)
        {
            mat!.Translate(e.X - OldPoint.X, e.Y - OldPoint.Y, System.Drawing.Drawing2D.MatrixOrder.Append);
            DrawImage();

            OldPoint.X = e.X;
            OldPoint.Y = e.Y;
        }
    }
    private void Control_MouseWheel(object? sender, MouseEventArgs e)
    {
        float minScale = (float)this.Width / (float)bmp!.Width;

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
            if (mat.Elements[0] > minScale)
            {
                mat.Scale(1.0f / 1.5f, 1.0f / 1.5f, System.Drawing.Drawing2D.MatrixOrder.Append);
            }
        }

        if (mat.Elements[0] > minScale)
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

        scale = GetScale();
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
        // scale = GetScale();
        // mat.Scale(scale, scale, System.Drawing.Drawing2D.MatrixOrder.Prepend);

        // DrawImage();
    }

    private float GetScale()
    {
        float scaleX = (float)this.Width / (float)bmp!.Width;
        float scaleY = (float)this.Height / (float)bmp.Height;

        if (scaleX < scaleY)
        {
            return scaleX;
        }
        else
        {
            return scaleY;
        }
    }

    private void ImageReset()
    {
        mat!.Reset();
        scale = GetScale();
        mat.Scale(scale, scale, System.Drawing.Drawing2D.MatrixOrder.Prepend);
        DrawImage();
    }
}
