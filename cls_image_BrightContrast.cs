using OpenCvSharp;
using OpenCvSharp.Extensions;

namespace IMG_Gen2
{
    public class cls_image_BrightContrast
    {
        private string? filePath;
        private CheckBox? BrightChkBox;
        private RadioButton? BrightMaxRadioBtn;
        private RadioButton? BrightMinRadioBtn;
        private HScrollBar? BrightMaxHScrBar;
        private HScrollBar? BrightMinHScrBar;
        private TextBox? BrightMaxTxtBox;
        private TextBox? BrightMinTxtBox;
        private CheckBox? ContrastChkBox;
        private RadioButton? ContrastMaxRadioBtn;
        private RadioButton? ContrastMinRadioBtn;
        private HScrollBar? ContrastMaxHScrBar;
        private HScrollBar? ContrastMinHScrBar;
        private TextBox? ContrastMaxTxtBox;
        private TextBox? ContrastMinTxtBox;
        private Button? BrightRndPreviewBtn;
        private PictureBox? PicBox2;
        private Boolean readFlag = false;
        private Bitmap? bmp;                                // 表示するBitmap
        private Graphics? g;                                // 描画用Graphicsオブジェクト
        private System.Drawing.Drawing2D.Matrix? mat;       // アフィン変換行列
        public cls_image_BrightContrast(List<Control> imgCtrl)
        {
            BrightChkBox = imgCtrl[0] as CheckBox;
            BrightMaxRadioBtn = imgCtrl[1] as RadioButton;
            BrightMinRadioBtn = imgCtrl[2] as RadioButton;
            BrightMaxHScrBar = imgCtrl[3] as HScrollBar;
            BrightMinHScrBar = imgCtrl[4] as HScrollBar;
            BrightMaxTxtBox = imgCtrl[5] as TextBox;
            BrightMinTxtBox = imgCtrl[6] as TextBox;

            ContrastChkBox = imgCtrl[7] as CheckBox;
            ContrastMaxRadioBtn = imgCtrl[8] as RadioButton;
            ContrastMinRadioBtn = imgCtrl[9] as RadioButton;
            ContrastMaxHScrBar = imgCtrl[10] as HScrollBar;
            ContrastMinHScrBar = imgCtrl[11] as HScrollBar;
            ContrastMaxTxtBox = imgCtrl[12] as TextBox;
            ContrastMinTxtBox = imgCtrl[13] as TextBox;

            BrightRndPreviewBtn = imgCtrl[14] as Button;
            PicBox2 = imgCtrl[15] as PictureBox;

            BrightMaxTxtBox!.Text = "0";
            BrightMinTxtBox!.Text = "0";
            ContrastMaxTxtBox!.Text = "100";
            ContrastMinTxtBox!.Text = "100";

            BrightMaxHScrBar!.ValueChanged += new EventHandler(BrightContrast_HScrBar_ValueChanged);
            BrightMinHScrBar!.ValueChanged += new EventHandler(BrightContrast_HScrBar_ValueChanged);
            ContrastMaxHScrBar!.ValueChanged += new EventHandler(BrightContrast_HScrBar_ValueChanged);
            ContrastMinHScrBar!.ValueChanged += new EventHandler(BrightContrast_HScrBar_ValueChanged);

            BrightChkBox!.Click += new EventHandler(ChkBox_Click);
            ContrastChkBox!.Click += new EventHandler(ChkBox_Click);
            BrightMaxRadioBtn!.Click += new EventHandler(BrightContrast_RadioBtn_Click);
            BrightMinRadioBtn!.Click += new EventHandler(BrightContrast_RadioBtn_Click);
            ContrastMaxRadioBtn!.Click += new EventHandler(BrightContrast_RadioBtn_Click);
            ContrastMinRadioBtn!.Click += new EventHandler(BrightContrast_RadioBtn_Click);

            BrightRndPreviewBtn!.Click += new EventHandler(BrightRndPreviewBtn_Click);
            PicBox2!.Resize += new EventHandler(PicBox2_Resize);

            ReadImageIni("./image_bright_contrast.ini");
        }
        //*************************************************************************
        // Events
        //*************************************************************************
        private void ChkBox_Click(Object? sender, EventArgs e)
        {
            SaveImageIni("./image_bright_contrast.ini");
        }
        private void BrightContrast_RadioBtn_Click(Object? sender, EventArgs e)
        {
            BrightContrast_View();
        }
        private void BrightRndPreviewBtn_Click(Object? sender, EventArgs e)
        {
            int brightMax = BrightMaxHScrBar!.Value;
            int brightMin = BrightMinHScrBar!.Value;
            int ContrastMax = ContrastMaxHScrBar!.Value;
            int ContrastMin = ContrastMinHScrBar!.Value;

            Random rnd = new System.Random();
            double alpha = rnd.Next(ContrastMin, ContrastMax) / 100;
            double beta = rnd.Next(brightMin, brightMax);

            Run_BitmapConverter(alpha, beta);
        }
        private void BrightContrast_HScrBar_ValueChanged(Object? sender, EventArgs e)
        {
            HScrollBar? ctrl = sender as HScrollBar;
            string ctrlName = ctrl!.Name.Replace("HScrBar", "TxtBox");
            TextBox[] txtBox = new TextBox[4] { BrightMaxTxtBox!, BrightMinTxtBox!, ContrastMaxTxtBox!, ContrastMinTxtBox! };
            RadioButton[] radioBtn = new RadioButton[4] { BrightMaxRadioBtn!, BrightMinRadioBtn!, ContrastMaxRadioBtn!, ContrastMinRadioBtn! };

            for (int i = 0; i < 4; i++)
            {
                if (txtBox[i].Name == ctrlName)
                {
                    txtBox[i].Text = ctrl.Value.ToString();
                    radioBtn[i].Checked = true;
                    BrightContrast_View();
                    break;
                }
            }
            if (!readFlag)
            {
                SaveImageIni("./image_bright_contrast.ini");
            }
        }
        private void PicBox2_Resize(object? sender, EventArgs? e)
        {
            if (g != null)
            {
                mat = g.Transform;
                g.Dispose();
                g = null;
            }
            Bitmap bmpPicBox = new Bitmap(PicBox2!.Width, PicBox2!.Height);
            PicBox2.Image = bmpPicBox;
            g = Graphics.FromImage(PicBox2.Image);

            if (mat != null)
            {
                g.Transform = mat;
            }

            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            // g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;

            DrawImage();
            ImageReset();
        }
        //*************************************************************************
        // 関数
        //*************************************************************************
        private void ReadImageIni(string iniFileName)
        {
            if (!cls_posPicBox.CheckFile(iniFileName)) { return; }

            readFlag = true;
            CheckBox[] chkBox = new CheckBox[2] { BrightChkBox!, ContrastChkBox! };
            HScrollBar[] hScrollBars = new HScrollBar[4] { BrightMaxHScrBar!, BrightMinHScrBar!, ContrastMaxHScrBar!, ContrastMinHScrBar! };
            StreamReader sr = new StreamReader(iniFileName);
            for (int i = 0; i < 6; i++)
            {
                string? line = sr.ReadLine();
                string[] Split = line!.Split(":");
                if (i < 2)
                {
                    chkBox[i].Checked = System.Convert.ToBoolean(Split[1]);
                }
                else
                {
                    hScrollBars[i - 2].Value = int.Parse(Split[1]);
                }
            }
            sr.Close();
            readFlag = false;
        }
        private void SaveImageIni(string iniFileName)
        {
            string settings = "";
            settings += "BrightChkBox:" + BrightChkBox!.Checked.ToString() + "\n";
            settings += "ContrastChkBox:" + ContrastChkBox!.Checked.ToString() + "\n";
            settings += "BrightMaxHScrBar:" + BrightMaxHScrBar!.Value.ToString() + "\n";
            settings += "BrightMinHScrBar:" + BrightMinHScrBar!.Value.ToString() + "\n";
            settings += "ContrastMaxHScrBar:" + ContrastMaxHScrBar!.Value.ToString() + "\n";
            settings += "ContrastMinHScrBar:" + ContrastMinHScrBar!.Value.ToString();

            StreamWriter sw = new StreamWriter(iniFileName);
            sw.WriteLine(settings);
            sw.Flush();
            sw.Close();
        }
        //*************************************************************************
        // 関数（Image関連）
        //*************************************************************************
        internal void SetImage(string filePath)
        {
            this.filePath = filePath;
            PicBox2!.SizeMode = PictureBoxSizeMode.AutoSize;
            BmpReadFile(filePath);
            mat = new System.Drawing.Drawing2D.Matrix();
            ImageReset();
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
        private void BrightContrast_View()
        {
            if (PicBox2!.Image == null) { return; }

            double alpha = 1;
            double beta = 0;

            if (BrightMaxRadioBtn!.Checked)
            {
                beta = BrightMaxHScrBar!.Value;
            }
            else
            {
                beta = BrightMinHScrBar!.Value;
            }
            if (ContrastMaxRadioBtn!.Checked)
            {
                alpha = (Double)ContrastMaxHScrBar!.Value / 100;
            }
            else
            {
                alpha = (Double)ContrastMinHScrBar!.Value / 100;
            }
            Run_BitmapConverter(alpha, beta);
        }
        private void Run_BitmapConverter(double alpha, double beta)
        {
            if (filePath == null) { return; }
            BmpReadFile(filePath);
            Mat cvMat = BitmapConverter.ToMat(bmp!);
            Cv2.ConvertScaleAbs(cvMat, cvMat, alpha, beta);
            if (bmp != null)
            {
                bmp.Dispose();
            }
            bmp = BitmapConverter.ToBitmap(cvMat);
            cvMat.Dispose();
            DrawImage();
        }
        private void BmpReadFile(string filePath)
        {
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
