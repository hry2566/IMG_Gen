

namespace IMG_Gen2;

public partial class cls_posPicBox : PictureBox
{
    private string? rootPath;                           // ルートパス
    private string? filePath;                           // 画像ファイルパス
    private Point startPos;                             // Startマウス座標記憶
    private Point endPos;                               // Endマウス座標記憶
    private Point pos;                                  // 画像上のピクセル座標
    private Bitmap? bmp;                                // 表示するBitmap
    private Graphics? g;                                // 描画用Graphicsオブジェクト
    private System.Drawing.Drawing2D.Matrix? mat;       // アフィン変換行列
    private float baseScale;                            // 画面読み込み時の表示倍率
    private bool scaleFlag = false;                     // スケールフラグ
    private bool labelFlag = false;                     // ラベルフラグ
    private bool maskFlag = false;                      // マスクフラグ
    List<cls_rectangle> lblRect = new();                // ラベル
    List<cls_rectangle> maskRect = new();               // マスク

    public cls_posPicBox(TabPage PosPage, ToolStripStatusLabel sLabel, ListView LabelLstView, ListView MaskLstView)
    {
        this.PosPage = PosPage;
        this.sLabel = sLabel;
        this.LabelLstView = LabelLstView;
        this.MaskLstView = MaskLstView;

        InitializeUserComponent();
        Controls_EventHandler();
    }

    // ***********************************************************************
    // this
    // ***********************************************************************
    private void Control_MouseDown(object? sender, MouseEventArgs e)
    {
        if (mat == null) { return; }

        startPos.X = e.X;
        startPos.Y = e.Y;

        if (Control.ModifierKeys == Keys.Control)
        {
            if (LabelLstView.SelectedItems.Count > 0 && e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                labelFlag = true;
                AllUnSelect();
            }
            return;
        }
        else if (e.Button == System.Windows.Forms.MouseButtons.Right)
        {
            ImageReset();
            return;
        }
        else if (Control.ModifierKeys == Keys.Alt)
        {
            if (MaskLstView.SelectedItems.Count > 0 && e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                maskFlag = true;
                AllUnSelect();
            }
            return;
        }
        scaleFlag = true;
    }
    private void Control_MouseUp(object? sender, MouseEventArgs e)
    {
        if (scaleFlag)
        {
            scaleFlag = false;
        }
        else if (labelFlag)
        {
            labelFlag = false;
            endPos.X = e.X;
            endPos.Y = e.Y;
            AddPosFile(LabelLstView, "pos");
            lblRect = CreateRectangle("pos");
            lblRect[lblRect.Count - 1].SetSelect(true);
            DrawImage();
        }
        else if (maskFlag)
        {
            maskFlag = false;
            endPos.X = e.X;
            endPos.Y = e.Y;
            AddPosFile(MaskLstView, "mask");
            maskRect = CreateRectangle("mask");
            maskRect[maskRect.Count - 1].SetSelect(true);
            DrawImage();
        }
    }
    private void Control_MouseMove(object? sender, MouseEventArgs e)
    {
        if (mat == null) { return; }

        pos.X = (int)((e.X - mat.Elements[4]) / mat!.Elements[0]);
        pos.Y = (int)((e.Y - mat.Elements[5]) / mat!.Elements[0]);
        sLabel!.Text = "Scale = " + mat!.Elements[0].ToString() +
                       " Pos.X = " + pos.X.ToString() +
                       " Pos.Y = " + pos.Y.ToString();

        if (scaleFlag)
        {
            mat!.Translate(e.X - startPos.X, e.Y - startPos.Y, System.Drawing.Drawing2D.MatrixOrder.Append);
            DrawImage();
            startPos.X = e.X;
            startPos.Y = e.Y;
        }
        else if (labelFlag && LabelLstView.SelectedItems.Count > 0)
        {
            DrawRubberBand(e, LabelLstView);
        }
        else if (maskFlag && MaskLstView.SelectedItems.Count > 0)
        {
            DrawRubberBand(e, MaskLstView);
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
        ImageReset();
    }
    internal void Control_KeyDown(object? sender, KeyEventArgs e)
    {
        if (e.Control && e.KeyCode == Keys.Delete)
        {
            for (int i = 0; i < lblRect.Count; i++)
            {
                if (lblRect[i].selectFlag)
                {
                    lblRect[i].Delete();
                    lblRect.Remove(lblRect[i]);
                    break;
                }
            }
            SaveRect("pos", lblRect);
            DrawImage();
        }
        else if (e.Alt && e.KeyCode == Keys.Delete)
        {
            for (int i = 0; i < maskRect.Count; i++)
            {
                if (maskRect[i].selectFlag)
                {
                    maskRect[i].Delete();
                    maskRect.Remove(maskRect[i]);
                    break;
                }
            }
            SaveRect("mask", maskRect);
            DrawImage();
        }
        else if (e.KeyCode == Keys.Escape)
        {
            AllUnSelect();
        }
    }

    // ***********************************************************************
    // 関数
    // ***********************************************************************
    // Image
    internal void SetImage(string filePath, String rootPath)
    {
        this.filePath = filePath;
        this.rootPath = rootPath;

        if (bmp != null)
        {
            bmp.Dispose();
        }
        PictureBox pic1 = new();
        pic1.Image = new Bitmap(filePath);
        bmp = new Bitmap(pic1.Image);
        pic1.Image.Dispose();

        mat = new System.Drawing.Drawing2D.Matrix();
        ImageReset();
    }
    private void ImageReset()
    {
        if (bmp == null) { return; }

        float scaleX = (float)this.Width / (float)bmp!.Width;
        float scaleY = (float)(this.Height-22) / (float)bmp.Height;

        if (scaleX < scaleY)
        {
            this.baseScale = scaleX;
        }
        else
        {
            this.baseScale = scaleY;
        }
        mat!.Reset();
        mat.Scale(baseScale, baseScale, System.Drawing.Drawing2D.MatrixOrder.Prepend);
        lblRect = CreateRectangle("pos");
        maskRect = CreateRectangle("mask");
        DrawImage();
    }

    // ***********************************************************************
    // File
    internal void SaveLabel()
    {
        SaveRect("pos", lblRect);
    }
    internal void SaveMask()
    {
        SaveRect("mask", maskRect);
    }
    private void SaveRect(string folderPath, List<cls_rectangle> rectangle)
    {
        string filePath = "";

        switch (folderPath)
        {
            case "pos":
                filePath = rootPath + folderPath + "\\" + GetFileName() + ".txt";
                break;
            case "mask":
                filePath = rootPath + folderPath + "\\mask.txt";
                break;
        }
        if (!CheckFile(filePath)) { return; }
        StreamWriter sw = new(filePath, false);
        for (int i = 0; i < rectangle.Count(); i++)
        {
            int x1 = rectangle[i].pos.X;
            int y1 = rectangle[i].pos.Y;
            int x2 = rectangle[i].pos.X + rectangle[i].size.Width;
            int y2 = rectangle[i].pos.Y + rectangle[i].size.Height;
            int dummy = 0;

            if (x1 > x2)
            {
                dummy = x1;
                x1 = x2;
                x2 = dummy;
            }
            if (y1 > y2)
            {
                dummy = y1;
                y1 = y2;
                y2 = dummy;
            }
            rectangle[i].pos.X = x1;
            rectangle[i].pos.Y = y1;
            rectangle[i].size.Width = x2 - x1;
            rectangle[i].size.Height = y2 - y1;

            string line = rectangle[i].labelName + "," +
                          rectangle[i].strColor + "," +
                          rectangle[i].penWidth.ToString() + "," +
                          x1.ToString() + "," +
                          y1.ToString() + "," +
                          x2.ToString() + "," +
                          y2.ToString();
            sw.WriteLine(line);
        }
        sw.Close();
    }
    private void AddPosFile(ListView listview, string folderName)
    {
        string labelName = listview.SelectedItems[0].SubItems[0].Text;
        string strColor = listview.SelectedItems[0].SubItems[1].Text;
        string strWidth = listview.SelectedItems[0].SubItems[2].Text;

        int x1, x2, y1, y2;
        if (startPos.X < endPos.X)
        {
            x1 = (int)((startPos.X - mat!.Elements[4]) / mat!.Elements[0]);
            x2 = (int)((endPos.X - mat!.Elements[4]) / mat!.Elements[0]);
        }
        else
        {
            x2 = (int)((startPos.X - mat!.Elements[4]) / mat!.Elements[0]);
            x1 = (int)((endPos.X - mat!.Elements[4]) / mat!.Elements[0]);
        }

        if (startPos.Y < endPos.Y)
        {
            y1 = (int)((startPos.Y - mat!.Elements[5]) / mat!.Elements[0]);
            y2 = (int)((endPos.Y - mat!.Elements[5]) / mat!.Elements[0]);
        }
        else
        {
            y2 = (int)((startPos.Y - mat!.Elements[5]) / mat!.Elements[0]);
            y1 = (int)((endPos.Y - mat!.Elements[5]) / mat!.Elements[0]);
        }

        string filename;
        StreamWriter sw;
        CheckFolder(rootPath!, folderName);

        switch (folderName)
        {
            case "pos":
                filename = rootPath + folderName + "/" + GetFileName() + ".txt";
                sw = new(filename, true);
                sw.WriteLine(labelName + "," + strColor + "," + strWidth + "," + x1 + "," + y1 + "," + x2 + "," + y2);
                sw.Close();
                break;
            case "mask":
                filename = rootPath + folderName + "/mask.txt";
                sw = new(filename, true);
                sw.WriteLine(labelName + "," + strColor + "," + strWidth + "," + x1 + "," + y1 + "," + x2 + "," + y2);
                sw.Close();
                break;
        }
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
    private static void CheckFolder(string rootPath, string param)
    {
        if (!System.IO.File.Exists(rootPath + param))
        {
            Directory.CreateDirectory(rootPath + param);
        }
    }
    internal static bool CheckFolder(string file_folder_Path)
    {
        if (System.IO.Directory.Exists(file_folder_Path))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    internal static bool CheckFile(string file_folder_Path)
    {
        if (System.IO.File.Exists(file_folder_Path))
        {
            return true;
        }
        else
        {
            return false;
        }
    }


    // ***********************************************************************
    // Draw
    private void DrawRubberBand(MouseEventArgs e, ListView listView)
    {
        int movX = e.X - startPos.X;
        int movY = e.Y - startPos.Y;

        Color color = String2Color(listView.SelectedItems[0].SubItems[1].Text);
        int penWidth = int.Parse(listView.SelectedItems[0].SubItems[2].Text);
        Pen p = new Pen(color, penWidth / mat!.Elements[0]);

        int x1, y1, w1, h1;
        if (movX > 0)
        {
            x1 = (int)((startPos.X - mat!.Elements[4]) / mat!.Elements[0]);
            w1 = (int)((movX + startPos.X - mat.Elements[4]) / mat!.Elements[0]);
        }
        else
        {
            movX = startPos.X - e.X;
            x1 = (int)((e.X - mat!.Elements[4]) / mat!.Elements[0]);
            w1 = (int)((movX + e.X - mat.Elements[4]) / mat!.Elements[0]);
        }

        if (movY > 0)
        {
            y1 = (int)((startPos.Y - mat.Elements[5]) / mat!.Elements[0]);
            h1 = (int)((movY + startPos.Y - mat.Elements[5]) / mat!.Elements[0]);
        }
        else
        {
            movY *= -1;
            y1 = (int)((e.Y - mat.Elements[5]) / mat!.Elements[0]);
            h1 = (int)((movY + e.Y - mat.Elements[5]) / mat!.Elements[0]);
        }
        g!.DrawRectangle(p, x1, y1, w1 - x1, h1 - y1);

        p.Dispose();
        this.Refresh();
        g.DrawImage(bmp!, 0, 0);
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
        DrawRect();
        this.Refresh();

        sLabel!.Text = "Scale = " + mat!.Elements[0].ToString() + " Pos.X = " + pos.X.ToString() + " Pos.Y = " + pos.Y.ToString();
    }
    private List<cls_rectangle> CreateRectangle(string folderName)
    {
        List<cls_rectangle> rectangle = new();
        string filepath = "";

        switch (folderName)
        {
            case "pos":
                filepath = rootPath + folderName + "\\" + GetFileName() + ".txt";
                lblRect_AllDelete();
                break;
            case "mask":
                filepath = rootPath + folderName + "\\mask.txt";
                maskRect_AllDelete();
                break;
        }

        if (!System.IO.File.Exists(filepath)) { return new List<cls_rectangle>(); }

        StreamReader sr = new(filepath);
        while (!sr.EndOfStream)
        {
            string? line = sr.ReadLine();
            string[] split = line!.Split(",");

            cls_rectangle ctrl = new(this, g!, split[0], split[1], split[2], int.Parse(split[3]), int.Parse(split[4]), int.Parse(split[5]), int.Parse(split[6]));
            rectangle.Add(ctrl);
        }
        sr.Close();
        return rectangle;
    }
    private void lblRect_AllDelete()
    {
        for (int i = 0; i < lblRect.Count(); i++)
        {
            lblRect[i].Delete();
        }
        lblRect = new();
    }
    private void maskRect_AllDelete()
    {
        for (int i = 0; i < maskRect.Count(); i++)
        {
            maskRect[i].Delete();
        }
        maskRect = new();
    }
    private void DrawRect()
    {
        for (int i = 0; i < lblRect.Count(); i++)
        {
            lblRect[i].DrawRectangle(mat!);
        }
        for (int i = 0; i < maskRect.Count(); i++)
        {
            maskRect[i].DrawRectangle(mat!);
        }
    }
    internal void AllUnSelect()
    {
        for (int i = 0; i < lblRect.Count(); i++)
        {
            lblRect[i].SetSelect(false);
        }
        for (int i = 0; i < maskRect.Count(); i++)
        {
            maskRect[i].SetSelect(false);
        }
    }
    internal static Color String2Color(string strColor)
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