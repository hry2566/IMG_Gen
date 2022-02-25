
namespace IMG_Gen2
{
    public class cls_image_RandomNoise
    {
        private string? filePath;
        private CheckBox? RndNoiseChkBox;
        private HScrollBar? RndNoiseScrBar;
        private HScrollBar? RndNoiseRatioScrBar;
        private TextBox? RndNoiseTxtBox;
        private TextBox? RndNoiseRatioTxtBox;
        private Button? RndNoisePreviewBtn;
        private PictureBox? PicBox2;
        private Boolean readFlag = false;
        private Boolean runFlag = false;
        private Bitmap? bmp;                                // 表示するBitmap
        private Graphics? g;                                // 描画用Graphicsオブジェクト
        private System.Drawing.Drawing2D.Matrix? mat;       // アフィン変換行列

        public cls_image_RandomNoise(List<Control> imgCtrl)
        {
            RndNoiseChkBox = imgCtrl[0] as CheckBox;
            RndNoiseScrBar = imgCtrl[1] as HScrollBar;
            RndNoiseRatioScrBar = imgCtrl[2] as HScrollBar;
            RndNoiseTxtBox = imgCtrl[3] as TextBox;
            RndNoiseRatioTxtBox = imgCtrl[4] as TextBox;
            RndNoisePreviewBtn = imgCtrl[5] as Button;
            PicBox2 = imgCtrl[6] as PictureBox;

            RndNoiseTxtBox!.Text = "0";
            RndNoiseRatioTxtBox!.Text = "1";

            RndNoiseScrBar!.ValueChanged += new EventHandler(RndNoise_HScrBar_ValueChanged);
            RndNoiseRatioScrBar!.ValueChanged += new EventHandler(RndNoise_HScrBar_ValueChanged);

            RndNoisePreviewBtn!.Click += new EventHandler(RndNoisePreviewBtn_Click);
            PicBox2!.Resize += new EventHandler(PicBox2_Resize);

            ReadImageIni("./ini/image_random_noise.ini");
        }
        private void PicBox2_Resize(object? sender, EventArgs? e)
        {
            if (g != null)
            {
                mat = g.Transform;
                g.Dispose();
                g = null;
            }
            g = Graphics.FromImage(PicBox2!.Image);

            if (mat != null)
            {
                g.Transform = mat;
            }

            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            // g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
        }
        internal void SetImage(string filePath)
        {
            this.filePath = filePath;
            PicBox2!.SizeMode = PictureBoxSizeMode.AutoSize;
            BmpReadFile(filePath);
            mat = new System.Drawing.Drawing2D.Matrix();
        }
        private void ReadImageIni(string iniFileName)
        {
            if (!cls_posPicBox.CheckFile(iniFileName)) { return; }

            readFlag = true;
            CheckBox[] chkBox = new CheckBox[1] { RndNoiseChkBox! };
            HScrollBar[] hScrollBars = new HScrollBar[2] { RndNoiseScrBar!, RndNoiseRatioScrBar! };
            StreamReader sr = new StreamReader(iniFileName);
            for (int i = 0; i < 3; i++)
            {
                string? line = sr.ReadLine();
                string[] Split = line!.Split(":");
                if (i < 1)
                {
                    chkBox[i].Checked = System.Convert.ToBoolean(Split[1]);
                }
                else
                {
                    hScrollBars[i - 1].Value = int.Parse(Split[1]);
                }
            }
            sr.Close();
            readFlag = false;
        }
        private void SaveImageIni(string iniFileName)
        {
            string settings = "";
            settings += "RndNoiseChkBox:" + RndNoiseChkBox!.Checked.ToString() + "\n";
            settings += "RndNoiseScrBar:" + RndNoiseScrBar!.Value.ToString() + "\n";
            settings += "RndNoiseCntScrBar:" + RndNoiseRatioScrBar!.Value.ToString();

            StreamWriter sw = new StreamWriter(iniFileName);
            sw.WriteLine(settings);
            sw.Flush();
            sw.Close();
        }
        private void RndNoisePreviewBtn_Click(Object? sender, EventArgs e)
        {
            if (PicBox2!.Image == null) { return; }

            runFlag = true;
            RndNoisePreviewBtn!.Visible = false;
            Random rnd = new System.Random();
            int noise = rnd.Next(128, RndNoiseScrBar!.Value);
            int ratio = rnd.Next(RndNoiseRatioScrBar!.Value, 50);

            CreateNoise(noise, ratio);
            ImageReset();
            RndNoisePreviewBtn!.Visible = true;
            runFlag = false;
        }

        private void CreateNoise(int noise, int ratio)
        {
            BmpReadFile(filePath!);
            AddNoise(bmp!, noise, ratio);
        }
        private void RndNoise_HScrBar_ValueChanged(Object? sender, EventArgs e)
        {
            HScrollBar? ctrl = sender as HScrollBar;
            string ctrlName = ctrl!.Name.Replace("ScrBar", "TxtBox");
            TextBox[] txtBox = new TextBox[2] { RndNoiseTxtBox!, RndNoiseRatioTxtBox! };

            for (int i = 0; i < 2; i++)
            {
                if (txtBox[i].Name == ctrlName)
                {
                    txtBox[i].Text = ctrl.Value.ToString();
                    if (!runFlag)
                    {
                        RandomNoise_View();
                    }
                    break;
                }
            }
            if (!readFlag)
            {
                SaveImageIni("./ini/image_random_noise.ini");
            }
        }
        private void RandomNoise_View()
        {
            if (PicBox2!.Image == null) { return; }

            runFlag = true;
            int noise = RndNoiseScrBar!.Value;
            int ratio = RndNoiseRatioScrBar!.Value;

            CreateNoise(noise, ratio);
            ImageReset();
            runFlag = false;
        }
        private void AddNoise(Bitmap bmp, int noise, int ratio)
        {
            if(bmp==null){return;}
            var width = bmp.Width;
            var height = bmp.Height;

            // Bitmapをロック
            var bmpData = bmp.LockBits(
                    new Rectangle(0, 0, width, height),
                    System.Drawing.Imaging.ImageLockMode.ReadWrite,
                    bmp.PixelFormat
                );

            // メモリの幅のバイト数を取得
            var stride = Math.Abs(bmpData.Stride);

            unsafe
            {
                // 画像データ格納用配列
                var ptr = (byte*)bmpData.Scan0;

                Random rnd = new System.Random();
                int iRnd = 0;
                int rgbPos = 0;
                int flag = 0;

                Parallel.For(0, height, y =>
                 {
                     // 行の先頭ポインタ
                     byte* pLine = ptr + y * stride;

                     for (int x = 0; x < width; x++)
                     {
                         // 輝度値の設定
                         iRnd = rnd.Next(-noise, noise);
                         flag = rnd.Next(0, ratio);
                         rgbPos = rnd.Next(0, 2);
                         if (flag == 0)
                         {
                             pLine[rgbPos] = (byte)(pLine[rgbPos] + iRnd);
                         }
                         // 次の画素へ
                         pLine += 4;
                     }
                 }
                );
            }
            // アンロック
            bmp.UnlockBits(bmpData);
        }
        private void ImageReset()
        {
            if (bmp == null) { return; }

            float scaleX = (float)PicBox2!.Width / (float)bmp!.Width;
            float scaleY = (float)(PicBox2.Height - 22) / (float)bmp.Height;
            float baseScale = 0;
            if (scaleX < scaleY)
            {
                baseScale = scaleX;
            }
            else
            {
                baseScale = scaleY;
            }
            mat!.Reset();
            mat.Scale(baseScale, baseScale, System.Drawing.Drawing2D.MatrixOrder.Prepend);
            DrawImage();
        }
        internal void DrawImage()
        {
            if (bmp == null) return;

            if (mat != null)
            {
                g!.Transform = mat;
            }
            g!.Clear(Color.White);
            g.DrawImage(bmp, 0, 0);
            PicBox2!.Refresh();
        }
        private void BmpReadFile(string filePath)
        {
            if(filePath==null){return;}
            if (bmp != null)
            {
                bmp.Dispose();
            }
            PictureBox pic1 = new();
            pic1.Image = new Bitmap(filePath);
            bmp = new Bitmap(pic1.Image);
            pic1.Image.Dispose();
        }
    }
}
