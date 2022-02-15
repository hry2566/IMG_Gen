using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
namespace IMG_Gen2;

public partial class cls_posPicBox : PictureBox
{
    private string? rootPath;
    private string? filePath;
    private Point startPos;
    private Point endPos;
    private Bitmap? bmp; // 表示するBitmap
    private Graphics? g; // 描画用Graphicsオブジェクト
    private System.Drawing.Drawing2D.Matrix? mat; // アフィン変換行列
    private float baseScale; // 表示倍率
    private float scale; // 表示倍率
    private Point pos; // マウス座標
    private bool MouseDownFlg = false; // マウスダウンフラグ
    private bool labelFlag = false; // ラバーバンドフラグ
    private Point OldPoint; // マウス座標記憶
    List<cls_label_rectangle> lblRect = new();

    public cls_posPicBox(TabPage PosPage, ToolStripStatusLabel sLabel, ListView LabelLstView)
    {
        this.PosPage = PosPage;
        this.sLabel = sLabel;
        this.LabelLstView = LabelLstView;

        InitializeUserComponent();
        Controls_EventHandler();
    }
    private void Control_MouseDown(object? sender, MouseEventArgs e)
    {
        if (mat == null) { return; }

        OldPoint.X = e.X;
        OldPoint.Y = e.Y;

        if (Control.ModifierKeys == Keys.Control)
        {
            if (LabelLstView.SelectedItems.Count > 0 && e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                labelFlag = true;
                AllUnSelect();
                startPos = OldPoint;
            }
            return;
        }
        else if (e.Button == System.Windows.Forms.MouseButtons.Right)
        {
            ImageReset();
            return;
        }

        MouseDownFlg = true;
    }
    private void Control_MouseUp(object? sender, MouseEventArgs e)
    {
        if (MouseDownFlg)
        {
            MouseDownFlg = false;
        }
        else if (labelFlag)
        {
            labelFlag = false;
            endPos.X = e.X;
            endPos.Y = e.Y;
            AddPosFile();
            CreateLabel();
            DrawImage();
        }
    }
    private void AddPosFile()
    {
        CheckPosFolder(rootPath!, "pos");

        string labelName = LabelLstView.SelectedItems[0].SubItems[0].Text;
        string strColor = LabelLstView.SelectedItems[0].SubItems[1].Text;
        string strWidth = LabelLstView.SelectedItems[0].SubItems[2].Text;

        int x1, x2, y1, y2;
        if (startPos.X < endPos.X)
        {
            x1 = (int)((startPos.X - mat!.Elements[4]) / scale);
            x2 = (int)((endPos.X - mat!.Elements[4]) / scale);
        }
        else
        {
            x2 = (int)((startPos.X - mat!.Elements[4]) / scale);
            x1 = (int)((endPos.X - mat!.Elements[4]) / scale);
        }

        if (startPos.Y < endPos.Y)
        {
            y1 = (int)((startPos.Y - mat!.Elements[5]) / scale);
            y2 = (int)((endPos.Y - mat!.Elements[5]) / scale);
        }
        else
        {
            y2 = (int)((startPos.Y - mat!.Elements[5]) / scale);
            y1 = (int)((endPos.Y - mat!.Elements[5]) / scale);
        }

        string filename = rootPath + "pos/" + GetFileName() + ".txt";
        StreamWriter sw = new(filename, true);
        sw.WriteLine(labelName + "," + strColor + "," + strWidth + "," + x1 + "," + y1 + "," + x2 + "," + y2);
        sw.Close();
    }
    private string GetFileName()
    {
        string[] split = new string[0];

        if (filePath!.IndexOf("\\") > -1)
        {
            split = filePath.Split("\\");
        }
        else if (filePath.IndexOf("/") > -1)
        {
            split = filePath.Split("/");
        }
        return split[split.Count() - 1];
    }
    private void CheckPosFolder(string rootPath, string param)
    {
        if (!System.IO.File.Exists(rootPath + param))
        {
            Directory.CreateDirectory(rootPath + param);
        }
    }
    private void Control_MouseMove(object? sender, MouseEventArgs e)
    {
        if (mat == null) { return; }

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
        else if (labelFlag && LabelLstView.SelectedItems.Count > 0)
        {
            DrawRubberBand(e);
        }
    }
    private void DrawRubberBand(MouseEventArgs e)
    {
        int movX; // 画像移動量:X or 四角の幅
        int movY; // 画像移動量:Y or 四角の高さ

        // 画像上のマウス座標取得し、画像移動量Ｘ＆Ｙ or 四角の高さ＆幅を算出
        movX = e.X - OldPoint.X;
        movY = e.Y - OldPoint.Y;

        Color color = String2Color(LabelLstView.SelectedItems[0].SubItems[1].Text);
        int penWidth = int.Parse(LabelLstView.SelectedItems[0].SubItems[2].Text);
        Pen p = new Pen(color, penWidth / scale);

        //長方形を描く
        int x1;
        int y1;
        int w1;
        int h1;

        if (movX > 0)
        {
            x1 = (int)((OldPoint.X - mat!.Elements[4]) / scale);
            w1 = (int)((movX + OldPoint.X - mat.Elements[4]) / scale);
        }
        else
        {
            movX = OldPoint.X - e.X;
            x1 = (int)((e.X - mat!.Elements[4]) / scale);
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
        ImageReset();
    }
    internal void DrawImage()
    {
        if (bmp == null) return;

        if (mat != null)
        {
            g!.Transform = mat;
        }

        g!.Clear(this.BackColor);
        g.DrawImage(bmp, 0, 0);
        scale = mat!.Elements[0];
        DrawLabel();
        this.Refresh();

        sLabel!.Text = "Scale = " + scale.ToString() + " Pos.X = " + pos.X.ToString() + " Pos.Y = " + pos.Y.ToString();
    }
    private void CreateLabel()
    {
        lblRect_AllDelete();
        if (!System.IO.File.Exists(rootPath + "pos\\" + GetFileName() + ".txt")) { return; }

        StreamReader sr = new(rootPath + "pos\\" + GetFileName() + ".txt");
        while (!sr.EndOfStream)
        {
            string? line = sr.ReadLine();
            string[] split = line!.Split(",");

            cls_label_rectangle ctrl = new(this, g!, split[0], split[1], split[2], int.Parse(split[3]), int.Parse(split[4]), int.Parse(split[5]), int.Parse(split[6]));
            lblRect.Add(ctrl);
        }
        sr.Close();
    }

    internal void SaveLabel()
    {
        StreamWriter sw = new(rootPath + "pos\\" + GetFileName() + ".txt", false);
        for (int i = 0; i < lblRect.Count(); i++)
        {
            int x1 = lblRect[i].pos.X;
            int y1 = lblRect[i].pos.Y;
            int x2 = lblRect[i].pos.X + lblRect[i].size.Width;
            int y2 = lblRect[i].pos.Y + lblRect[i].size.Height;
            int dummy = 0;
            
            if(x1>x2)
            {
                dummy = x1;
                x1 = x2;
                x2 = dummy;
            }

            if(y1>y2)
            {
                dummy = y1;
                y1 = y2;
                y2 = dummy;
            }

            lblRect[i].pos.X = x1;
            lblRect[i].pos.Y = y1;
            lblRect[i].size.Width = x2 - x1;
            lblRect[i].size.Height = y2 - y1;


            string line = lblRect[i].labelName + "," +
                          lblRect[i].strColor + "," +
                          lblRect[i].penWidth.ToString() + "," +
                          x1.ToString() + "," +
                          y1.ToString() + "," +
                          x2.ToString() + "," +
                          y2.ToString();
            sw.WriteLine(line);
        }
        sw.Close();
    }
    private void lblRect_AllDelete()
    {
        for (int i = 0; i < lblRect.Count(); i++)
        {
            lblRect[i].Delete();
        }
        lblRect = new();
    }
    private void DrawLabel()
    {
        for (int i = 0; i < lblRect.Count(); i++)
        {
            lblRect[i].DrawLabel(scale, mat!);
        }
    }

    internal void SetImage(string filePath, String rootPath)
    {
        this.filePath = filePath;
        this.rootPath = rootPath;

        if (bmp != null)
        {
            bmp.Dispose();
        }
        bmp = new Bitmap(filePath);
        mat = new System.Drawing.Drawing2D.Matrix();

        // CreateLabel ();
        ImageReset();
    }
    private void ImageReset()
    {
        if (bmp == null) { return; }

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
        CreateLabel();
        DrawImage();
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

    internal void AllUnSelect()
    {
        for (int i = 0; i < lblRect.Count(); i++)
        {
            lblRect[i].SetSelect(false);
        }
    }
    internal void Control_KeyDown(object? sender, KeyEventArgs e)
    {
        if (e.Control && e.KeyCode == Keys.Delete)
        {
            for (int i = 0; i < lblRect.Count;i++)
            {
                if(lblRect[i].selectFlag)
                {
                    lblRect[i].Delete();
                    lblRect.Remove(lblRect[i]);
                    break;
                }
            }
            SaveLabel();
            DrawImage();
        }
        else if(e.KeyCode == Keys.Escape)
        {
            AllUnSelect();
        }

        
    }
}