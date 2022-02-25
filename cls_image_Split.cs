namespace IMG_Gen2
{
    public class cls_image_Split
    {
        private struct RECTPOS			//四角の座標
		{
		  public int x1;
		  public int y1;
		  public int x2;
		  public int y2;
		}
        private struct LABEL_INFO
        {
            public string labelName = "";
            public RECTPOS rectPos = new();
        }
        private struct IMG_INFO
        {
            public string labelName = "";
            public int Cnt = 0;
            public List<RECTPOS> rectPos = new();
        }
        private struct TREE_INFO
        {
            public List<string> fileList;
            public List<TreeNode> node;
        }
        private string? rootPath;
        private string? filePath;
        private TextBox? ImageWidthTxtBox;
        private TextBox? ImageHeightTxtBox;
        private TextBox? SplitWidthTxtBox;
        private TextBox? SplitHeightTxtBox;
        private TextBox? WrapWidthTxtBox;
        private TextBox? WrapHeightTxtBox;
        private TextBox? SplitCntTxtBox1;
        private CheckBox? RndSplitRadioBtn;
        private Button? SplitPreviewBtn;
        private TextBox? SplitCntTxtBox2;
        private DataGridView? SplitCntDataGridView;
        private Button? RunSplitBtn;
        private Button? StopSplitBtn;
        private PictureBox? PicBox2;
        private Boolean readFlag = false;
        private Boolean stopFlag = true;
        private cls_treeview? FileTreeView;
        private TREE_INFO treeInfo;
        private cls_image_BrightContrast? Image_BrightContrast;

        public cls_image_Split(List<Control> splitCtrl)
        {
            ImageWidthTxtBox = splitCtrl[0] as TextBox;
            ImageHeightTxtBox = splitCtrl[1] as TextBox;
            SplitWidthTxtBox = splitCtrl[2] as TextBox;
            SplitHeightTxtBox = splitCtrl[3] as TextBox;
            WrapWidthTxtBox = splitCtrl[4] as TextBox;
            WrapHeightTxtBox = splitCtrl[5] as TextBox;
            SplitCntTxtBox1 = splitCtrl[6] as TextBox;
            RndSplitRadioBtn = splitCtrl[7] as CheckBox;
            SplitPreviewBtn = splitCtrl[8] as Button;
            SplitCntTxtBox2 = splitCtrl[9] as TextBox;
            SplitCntDataGridView = splitCtrl[10] as DataGridView;
            RunSplitBtn = splitCtrl[11] as Button;
            StopSplitBtn = splitCtrl[12] as Button;
            PicBox2 = splitCtrl[13] as PictureBox;

            ImageWidthTxtBox!.Text = "";
            ImageHeightTxtBox!.Text = "";
            SplitWidthTxtBox!.Text = "";
            SplitHeightTxtBox!.Text = "";
            WrapWidthTxtBox!.Text = "";
            WrapHeightTxtBox!.Text = "";
            SplitCntTxtBox1!.Text = "";
            SplitCntTxtBox2!.Text = "";

            SplitCntDataGridView!.ColumnCount = 3;

            SplitCntDataGridView.Columns[0].HeaderText = "ラベル";
            SplitCntDataGridView.Columns[1].HeaderText = "設定数";
            SplitCntDataGridView.Columns[2].HeaderText = "作成済";
            SplitCntDataGridView.RowHeadersVisible = false;
            SplitCntDataGridView.Columns[0].ReadOnly = true;
            SplitCntDataGridView.Columns[2].ReadOnly = true;
            SplitCntDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            SplitCntDataGridView.CellValueChanged += new DataGridViewCellEventHandler(SplitCntDataGridView_CellValueChanged);
            SplitWidthTxtBox.TextChanged += new EventHandler(TxtChanged);
            SplitHeightTxtBox.TextChanged += new EventHandler(TxtChanged);
            WrapWidthTxtBox.TextChanged += new EventHandler(TxtChanged);
            WrapHeightTxtBox.TextChanged += new EventHandler(TxtChanged);
            RndSplitRadioBtn!.CheckedChanged += new EventHandler(TxtChanged);
            SplitPreviewBtn!.Click += new EventHandler(SplitPreviewBtn_Click);
            RunSplitBtn!.Click += new EventHandler(RunSplitBtn_Click);
            StopSplitBtn!.Click += new EventHandler(StopSplitBtn_Click);

            CheckLabel();
            ReadIni("./ini/image_split.ini");
        }
        internal void SetFileView(cls_treeview FileTreeView)
        {
            this.FileTreeView = FileTreeView;
        }
        
        private void SplitPreviewBtn_Click(object? sender, EventArgs e)
        {
            if(filePath==null){return;}

            List<RECTPOS> rectPos = new List<RECTPOS>();
			List<Point> maskDotPos = new List<Point>();

			maskDotPos = GetMaskDotPos();
            
			Graphics g = Graphics.FromImage(Pic2Bmp(filePath));

            // // マスク点座標表示
            for(int i=0;i<maskDotPos.Count-1;i++)
            {
                g.FillEllipse(Brushes.White, maskDotPos[i].X, maskDotPos[i].Y, 10, 10);
            }

			rectPos = CreateSplitPos(maskDotPos);
			SplitCntTxtBox1!.Text = rectPos.Count.ToString();
			SplitCntTxtBox2!.Text = rectPos.Count.ToString();
			
			Pen p = new Pen(Color.Red, 3);
			int colorNo = 0;
			
			for (int i = 0; i < rectPos.Count; i++) 
            {
				switch(colorNo)
				{
				    case 0:
						p = new Pen(Color.Red, 3);
						break;
				    case 1:
						p = new Pen(Color.Blue, 3);
						break;
					case 2:
						p = new Pen(Color.Yellow, 3);
						break;
					case 3:
						p = new Pen(Color.Magenta, 3);
						break;
					case 4:
						p = new Pen(Color.Green, 3);
						break;
					default:
						colorNo = 0;
						p = new Pen(Color.Red, 3);
						break;
				}
				colorNo++;
				g.DrawRectangle(p, rectPos[i].x1, rectPos[i].y1, rectPos[i].x2 - rectPos[i].x1, rectPos[i].y2 - rectPos[i].y1);
            }
            PicBox2!.Refresh();
            g.Dispose();
            p.Dispose();
        }
        private Bitmap Pic2Bmp(string filePath)
        {
            if(PicBox2!.Image!=null)
            {
                PicBox2.Image.Dispose();
                PicBox2.Image=null;
            }
            PicBox2.Image = new Bitmap(filePath);
            Bitmap bmp = new(PicBox2.Image);
            if(PicBox2.Image!=null)
            {
                PicBox2.Image.Dispose();
                PicBox2.Image=null;
            }
            PicBox2.Image=bmp;
            return bmp;
        }
        private List<RECTPOS> CreateSplitPos(List<Point>? maskPos = null){
			List<RECTPOS> rectPos = new List<RECTPOS>();
			RECTPOS newPos;
			Random rnd = new System.Random();
			
			// 分割イメージ表示
			int wrapX = 0;
			int wrapY = 0;
			int cutW = 0;
			int cutH = 0;
			int posX;
			int posY;
			bool rndFlag = RndSplitRadioBtn!.Checked;
			
			if (SplitWidthTxtBox!.Text == "") {
				SplitWidthTxtBox.Text = "224";
			}
			if (SplitHeightTxtBox!.Text == "") {
				SplitHeightTxtBox.Text = "224";
			}
			if (WrapWidthTxtBox!.Text == "") {
				WrapWidthTxtBox.Text = "0";
			}
			if (WrapHeightTxtBox!.Text == "") {
				WrapHeightTxtBox.Text = "0";
			}
			
			cutW = int.Parse(SplitWidthTxtBox.Text);
			cutH = int.Parse(SplitHeightTxtBox.Text);
			wrapX = int.Parse(WrapWidthTxtBox.Text);
			wrapY = int.Parse(WrapHeightTxtBox.Text);

            if(cutW<wrapX+1){
                wrapX = cutW -1;
                WrapWidthTxtBox.Text = wrapX.ToString();
            }
            if(cutH<wrapY+1)
            {
                wrapY=cutH-1;
                WrapHeightTxtBox.Text=wrapY.ToString();
            }

            int imgWidth = int.Parse(ImageWidthTxtBox!.Text);
            int imgHeight = int.Parse(ImageHeightTxtBox!.Text);

			for (int cntY = 0; cntY < imgHeight; cntY += cutH) {
				cntY -= wrapY;
				for (int cntX = 0; cntX < imgWidth; cntX += cutW) {
					cntX -= wrapX;
					
					if (rndFlag) {
						posX = cntX + rnd.Next(0, wrapX);
						posY = cntY + rnd.Next(0, wrapY);
					} else {
						posX = cntX;
						posY = cntY;
					}
					
					newPos.x1 = posX;
					newPos.y1 = posY;
					newPos.x2 = cutW + posX;
					newPos.y2 = cutH + posY;
					
//					rectPos.Add(newPos);
					
					if (maskPos != null) {
						if (maskPos.Count > 0) {
							bool flag = true;
							for (int i = 0; i < maskPos.Count; i++) {
								if (newPos.x1 < maskPos[i].X && maskPos[i].X < newPos.x2 &&
								    newPos.y1 < maskPos[i].Y && maskPos[i].Y < newPos.y2) {
									flag = false;
									break;
								}
							}
							if (flag) {
								rectPos.Add(newPos);
							}
						} else {
							rectPos.Add(newPos);
						}
					}else{
						rectPos.Add(newPos);
					}
				}
			}
			return rectPos;	
		}
        private List<Point> GetMaskDotPos(){
			List<Point> maskPos = new List<Point>();
            string maskFile = rootPath+"_mask\\mask.txt";
            if (!File.Exists(maskFile)) {return new List<Point>();}

            int x1,y1,x2,y2;

            StreamReader sr = new StreamReader(maskFile);
            string? line = "";
            int Width = int.Parse(SplitWidthTxtBox!.Text);
            int Height = int.Parse(SplitHeightTxtBox!.Text);

            while ((line = sr.ReadLine()) != null)
            {
                if (line != "")
                {
                    string[] strSplit = line.Split(',');
                    x1 = int.Parse(strSplit[3]);
                    y1 = int.Parse(strSplit[4]);
                    x2 = int.Parse(strSplit[5]);
                    y2 = int.Parse(strSplit[6]);

                    Point pos;

                    int stepX = (int)(Width / 5);
                    int stepY = (int)(Height / 5);
                    if (stepX<1){stepX=1;}
                    if (stepY<1){stepY=1;}

                    for(int cntX = x1; cntX < x2; cntX += stepX)
                    {
                        for(int cntY = y1; cntY < y2; cntY += stepY)
                        {
                            pos = new Point(cntX, cntY);
                            maskPos.Add(pos);
                        }
                    }
                } 
            }
            sr.Close();
            return maskPos;
		}
        private void ReadIni(string filePath)
        {
            if (!cls_posPicBox.CheckFile(filePath)) { return; }
            readFlag = true;
            StreamReader sr = new(filePath);
            string[] split = sr.ReadLine()!.Split(":");
            SplitWidthTxtBox!.Text = split[1];
            split = sr.ReadLine()!.Split(":");
            SplitHeightTxtBox!.Text = split[1];
            split = sr.ReadLine()!.Split(":");
            WrapWidthTxtBox!.Text = split[1];
            split = sr.ReadLine()!.Split(":");
            WrapHeightTxtBox!.Text = split[1];
            split = sr.ReadLine()!.Split(":");
            RndSplitRadioBtn!.Checked = System.Convert.ToBoolean(split[1]);
            sr.Close();
            readFlag = false;
        }
        private void TxtChanged(object? sender, EventArgs e)
        {
            if (readFlag) { return; }
            StreamWriter sw = new("./ini/image_split.ini");
            sw.WriteLine("SplitWidth:" + SplitWidthTxtBox!.Text);
            sw.WriteLine("SplitHeight:" + SplitHeightTxtBox!.Text);
            sw.WriteLine("WrapWidth:" + WrapWidthTxtBox!.Text);
            sw.WriteLine("WrapHeight:" + WrapHeightTxtBox!.Text);
            sw.WriteLine("RandomChkBox:" + RndSplitRadioBtn!.Checked.ToString());
            sw.Close();
        }
        internal void CheckLabel()
        {
            List<string> labelName1 = new();
            List<string> labelName2 = new();
            List<string> labelName3 = new();
            labelName3.Add("OK,1000,0");

            if (cls_posPicBox.CheckFile("./ini/label.ini"))
            {
                StreamReader sr = new("./ini/label.ini");
                while (!sr.EndOfStream)
                {
                    string[] split = sr.ReadLine()!.Split(",");
                    bool skipFlag = true;
                    for (int i = 0; i < labelName1.Count; i++)
                    {
                        if (labelName1[i] == split[0])
                        {
                            skipFlag = false;
                        }
                    }
                    if (skipFlag)
                    {
                        labelName1.Add(split[0]);
                    }
                }
                sr.Close();
            }

            if (cls_posPicBox.CheckFile("./ini/image_split_label.ini"))
            {
                StreamReader sr = new("./ini/image_split_label.ini");
                while (!sr.EndOfStream)
                {
                    string? line = sr.ReadLine();
                    labelName2.Add(line!);
                }
                sr.Close();
            }

            for (int i = 0; i < labelName1.Count; i++)
            {
                bool addFlag = true;
                for (int j = 0; j < labelName2.Count; j++)
                {
                    string[] split = labelName2[j].Split(",");
                    if (labelName1[i] == split[0])
                    {
                        labelName3.Add(labelName2[j]);
                        addFlag = false;
                        break;
                    }
                }
                if (addFlag)
                {
                    labelName3.Add(labelName1[i] + ",0,0");
                }
            }

            StreamReader sr1 = new("./ini/image_split_label.ini");
            labelName3[0] = sr1.ReadLine()!;
            sr1.Close();

            StreamWriter sw = new("./ini/image_split_label.ini");
            for (int i = 0; i < labelName3.Count; i++)
            {
                sw.WriteLine(labelName3[i]);
            }
            sw.Close();

            ReadLabelIni("./ini/image_split_label.ini");
        }
        private void SplitCntDataGridView_CellValueChanged(object? sender, DataGridViewCellEventArgs e)
        {
            if(readFlag){return;}
            if (SplitCntDataGridView!.Rows[e.RowIndex].Cells[0].Value.ToString() == "") { return; }
            SaveIni("./ini/image_split_label.ini");
        }
        private void SaveIni(string iniFileName)
        {
            if(readFlag){return;}
            StreamWriter sw = new(iniFileName);
            for (int i = 0; i < SplitCntDataGridView!.RowCount - 1; i++)
            {
                string str = SplitCntDataGridView.Rows[i].Cells[0].Value.ToString() + ",";
                str += SplitCntDataGridView.Rows[i].Cells[1].Value.ToString() + ",";
                str += SplitCntDataGridView.Rows[i].Cells[2].Value.ToString();
                sw.WriteLine(str);
            }
            sw.Close();
        }
        private void ReadLabelIni(string iniFileName)
        {
            if (!cls_posPicBox.CheckFile(iniFileName)) { return; }

            SplitCntDataGridView!.Rows.Clear();

            StreamReader sr = new(iniFileName);
            while (!sr.EndOfStream)
            {
                string[] split = sr.ReadLine()!.Split(",");
                SplitCntDataGridView!.Rows.Add(split[0], split[1], 0);
            }
            sr.Close();
        }
        internal void SetImage(string filePath,string rootPath)
        {
            this.filePath = filePath;
            this.rootPath = rootPath;
            PicBox2!.SizeMode = PictureBoxSizeMode.Zoom;
            PicBox2.Image.Dispose();
            PicBox2.Image = new Bitmap(filePath);
            ImageWidthTxtBox!.Text = PicBox2!.Image.Width.ToString();
            ImageHeightTxtBox!.Text = PicBox2.Image.Height.ToString();
        }

        internal void SetOpt(string rootPath, cls_image_BrightContrast Image_BrightContrast)
        {
            this.rootPath = rootPath;
            this.Image_BrightContrast = Image_BrightContrast;
        }

        private void StopSplitBtn_Click(object? sender, EventArgs e)
        {
            stopFlag=true;
        } 
        private void SearchNode(TreeNode treeNode)
        {
            treeInfo.fileList!.Add(treeNode.FullPath);
            treeInfo.node!.Add(treeNode);
            foreach (TreeNode tn in treeNode.Nodes)
            {
                SearchNode(tn);
            }
        }        
        private void RunSplitBtn_Click(object? sender, EventArgs e)
        {
            treeInfo = new();
            treeInfo.fileList = new();
            treeInfo.node = new();
            foreach (TreeNode n in FileTreeView!.Nodes)
            {
                SearchNode(n);
            }

            for(int l=0;l<treeInfo.fileList!.Count;l++)
            {
                filePath = rootPath + treeInfo.fileList[l];
                FileTreeView.SelectedNode = treeInfo.node![l];
                FileTreeView.Focus();
                
                // IMGファイル有無＆読込
                if(File.Exists(filePath))
                {
                    RunSplitBtn!.Enabled=false;
                    readFlag = true;

                    List<LABEL_INFO> labelInfo = new();
                    LABEL_INFO lblInf = new();
                    List<Point> maskDotPos = new();
                    List<RECTPOS> rectPos = new();
                    List<IMG_INFO> imgInfo = new();
                    IMG_INFO info = new();

                    // Posファイル有無＆読込
                    string[] split = filePath.Split("\\");
                    string posFileName = rootPath + "_pos/" + split[split.Count()-1] + ".txt";
                    

                    info.labelName = "OK";
                    info.Cnt = int.Parse(SplitCntDataGridView!.Rows[0].Cells[1].Value.ToString()!);
                    imgInfo.Add(info);

                    if(File.Exists(posFileName))
                    {
                        StreamReader sr = new (posFileName);
                        while (!sr.EndOfStream)
                        {
                            string line = sr.ReadLine()!;
                            split = line.Split(",");
                            lblInf.labelName = split[0];
                            lblInf.rectPos.x1 = int.Parse(split[3]);
                            lblInf.rectPos.y1 = int.Parse(split[4]);
                            lblInf.rectPos.x2 = int.Parse(split[5]);
                            lblInf.rectPos.y2 = int.Parse(split[6]);
                            labelInfo.Add(lblInf);
                        }
                        sr.Close();
                    }

                    // splitフォルダー有無＆作成
                    Directory.CreateDirectory(rootPath + "/_split");

                    // ラベルフォルダー有無＆作成
                    Directory.CreateDirectory(rootPath + "/_split/OK");
                    for(int i=0;i<labelInfo.Count;i++)
                    {
                        Directory.CreateDirectory(rootPath + "/_split/" + labelInfo[i].labelName);
                        
                        bool flag = false;
                        for(int j=0;j<imgInfo.Count;j++)
                        {
                            if(labelInfo[i].labelName==imgInfo[j].labelName)
                            {
                                flag=true;
                                break;       
                            }
                        }
                        if(!flag)
                        {
                            info = new();
                            info.labelName = labelInfo[i].labelName;
                            imgInfo.Add(info);
                        }
                    }

                    // ラベル無　作成数-1
                    for(int i=1;i<SplitCntDataGridView!.RowCount-1;i++)
                    {
                        SplitCntDataGridView!.Rows[i].Cells[2].Value = -1;
                        string? labelName = SplitCntDataGridView!.Rows[i].Cells[0].Value.ToString();
                        for(int j=0;j<labelInfo.Count;j++)
                        {
                            if(labelName ==labelInfo[j].labelName )
                            {
                                SplitCntDataGridView!.Rows[i].Cells[2].Value = 0;
                                for(int k=0;k<imgInfo.Count;k++)
                                {
                                    if(imgInfo[k].labelName==labelName)
                                    {
                                        info = imgInfo[k];
                                        info.Cnt = int.Parse(SplitCntDataGridView!.Rows[i].Cells[1].Value.ToString()!);
                                        imgInfo[k] = info;
                                        break;
                                    }
                                }
                                break;
                            }
                        }
                    }
                    
                    // Maskファイル有無＆読込
                    maskDotPos = GetMaskDotPos();

                    while (true)
                    {
                        int createdCnt = 0;
                        // 座標作成（マスク部削除）
                        rectPos = CreateSplitPos(maskDotPos);

                        // 座標ラベル部仕分け
                        CreateImgInfo(imgInfo,rectPos,labelInfo);

                        for(int i=0;i<imgInfo.Count;i++)
                        {
                            if(imgInfo[i].Cnt==imgInfo[i].rectPos.Count)
                            {
                                createdCnt++;
                            }
                        }
                        if(createdCnt==imgInfo.Count){break;}
                    }

                    // 画像保存
                    stopFlag=false;
                    saveSplit(filePath,imgInfo);

                    if(stopFlag)
                    {
                        break;
                    }
                }
            }
            if(stopFlag)
            {
                MessageBox.Show("中断しました");
            }
            else
            {
                MessageBox.Show("終了");
            }
            
            RunSplitBtn!.Enabled=true;
            readFlag=false;
        }
        private bool saveSplit(string filePath, List<IMG_INFO> imgInfo)
        {
            string path = rootPath + "_split/";
            string[] split = filePath.Split("\\");
            string fileName = split[split.Count()-1];

            Task[] task = new Task[imgInfo.Count];
            readFlag=true;
            for(int i=0;i<imgInfo.Count;i++)
            {
                task[i] = Task.Run(() => {
                    SaveSplitImg(imgInfo,i,filePath);
                });
                Thread.Sleep(100);
            }

            //スレッド終了待ち
            bool flag=true;
            while (flag)
            {
                flag=false;
                for(int i=0;i<task.Count();i++)
                {
                    if(task[i].Status==TaskStatus.Running)
                    {
                        flag = true;
                        break;
                    }
                }
                Application.DoEvents();
                if(stopFlag){return false;}
            }
            return true;
		}
        private bool SaveSplitImg(List<IMG_INFO> imgInfo,int index,string filePath)
        {
            string path = rootPath + "_split/";
            string[] split = filePath.Split("\\");
            string fileName = split[split.Count()-1];

            Bitmap bmpNew;
            Bitmap img3 = new Bitmap(filePath);
            int cnt = 0;

            for(int j=0;j<imgInfo[index].rectPos.Count;j++)
            {
                int x = imgInfo[index].rectPos[j].x1;
                int y = imgInfo[index].rectPos[j].y1;
                int width = imgInfo[index].rectPos[j].x2 -imgInfo[index].rectPos[j].x1;
                int height = imgInfo[index].rectPos[j].y2 -imgInfo[index].rectPos[j].y1;

                Rectangle rect = new Rectangle(x, y, width, height);
                bmpNew = img3.Clone(rect, img3.PixelFormat);

                // 画像を保存
                string newFilePath = path + imgInfo[index].labelName +"/" + fileName + cnt.ToString() + ".jpg";
                
                Task task = Task.Run(() => {
                    SaveThread(bmpNew,newFilePath);
                });
                // bmpNew.Save(newFilePath,System.Drawing.Imaging.ImageFormat.Jpeg);
                
                SplitCntDataGridView!.Invoke((MethodInvoker)(() =>
                {
                    SplitCntDataGridView!.Rows[index].Cells[2].Value = j+1;
                }));
                if(stopFlag){break;}
                cnt++;
            }
            return true;
        }
        private void CreateImgInfo(List<IMG_INFO> imgInfo,List<RECTPOS> rectPos,List<LABEL_INFO> labelInfo)
        {
            // lblInf ラベル名と座標
            // rectPos 分割座標（マスク除去後）
            // imgInfo 保存画像（ラベル名、作成枚数、座標配列）

            for(int i=0;i<rectPos.Count;i++)
            {
                bool okFlag=true;
                bool grayFlag=false;
                for(int j=0;j<labelInfo.Count;j++)
                {
                    if(rectPos[i].x1 < labelInfo[j].rectPos.x1 && rectPos[i].x2 > labelInfo[j].rectPos.x2 &&
                       rectPos[i].y1 < labelInfo[j].rectPos.y1 && rectPos[i].y2 > labelInfo[j].rectPos.y2)
                    {
                        for(int k=0;k<imgInfo.Count;k++)
                        {
                            if(imgInfo[k].labelName==labelInfo[j].labelName)
                            {
                                if(imgInfo[k].rectPos.Count<imgInfo[k].Cnt)
                                {
                                    imgInfo[k].rectPos.Add(rectPos[i]);
                                }
                                okFlag=false;
                                break;
                            }
                        }
                    }
                    if(!okFlag)
                    {
                        if(rectPos[i].x1 < labelInfo[j].rectPos.x1 && rectPos[i].x2 > labelInfo[j].rectPos.x1 &&
                           rectPos[i].y1 < labelInfo[j].rectPos.y1 && rectPos[i].y2 > labelInfo[j].rectPos.y1)
                        {
                            grayFlag=true;
                        }
                        if(rectPos[i].x1 < labelInfo[j].rectPos.x2 && rectPos[i].x2 > labelInfo[j].rectPos.x2 &&
                        rectPos[i].y1 < labelInfo[j].rectPos.y1 && rectPos[i].y2 > labelInfo[j].rectPos.y1)
                        {
                            grayFlag=true;
                        }
                        if(rectPos[i].x1 < labelInfo[j].rectPos.x1 && rectPos[i].x2 > labelInfo[j].rectPos.x1 &&
                        rectPos[i].y1 < labelInfo[j].rectPos.y2 && rectPos[i].y2 > labelInfo[j].rectPos.y2)
                        {
                            grayFlag=true;
                        }
                        if(rectPos[i].x1 < labelInfo[j].rectPos.x2 && rectPos[i].x2 > labelInfo[j].rectPos.x2 &&
                        rectPos[i].y1 < labelInfo[j].rectPos.y2 && rectPos[i].y2 > labelInfo[j].rectPos.y2)
                        {
                            grayFlag=true;
                        }
                    }
                    if(!okFlag)
                    {
                        break;
                    }
                }
                if(okFlag && !grayFlag)
                {
                    if(imgInfo[0].rectPos.Count<imgInfo[0].Cnt)
                    {
                        imgInfo[0].rectPos.Add(rectPos[i]);
                    }
                }
            }
        }
        private void SaveThread(Bitmap bmpNew,string newFilePath)
        {
            bmpNew = Image_BrightContrast!.GetBrightContrast(bmpNew);
            bmpNew.Save(newFilePath,System.Drawing.Imaging.ImageFormat.Jpeg);
        }
    }
}