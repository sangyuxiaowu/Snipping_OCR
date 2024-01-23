using PaddleOCRSharp;
using Snipping_OCR;
using System.Diagnostics;
using System.Security.Policy;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Snipping_OCR
{
    public partial class Main : Form
    {

        public Main()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 覆写窗体消息
        /// </summary>
        /// <param name="m"></param>
        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
            Hotkey.ProcessHotKey(m);
        }

        /// <summary>
        /// 启动，注册热键
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Main_Load(object sender, EventArgs e)
        {
            //注册热键 Ctrl+ALT+A 截图
            try
            {
                toolStripComboBox1.Text = "否";
                Hotkey.Regist(base.Handle, HotkeyModifiers.MOD_CONTROL_ALT, Keys.Q, new Hotkey.HotKeyCallBackHanlder(StartCapture));
            }
            catch
            {
                notifyIcon.ShowBalloonTip(2, "屏幕 OCR", "热键注册失败，您仍可以使用其他方式执行 OCR。", ToolTipIcon.Info);
            }

        }

        /// <summary>
        /// 关闭，卸载热键
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Main_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                Hotkey.UnRegist(base.Handle, new Hotkey.HotKeyCallBackHanlder(StartCapture));
            }
            catch
            {

            }
        }



        /// <summary>
        /// 调用系统截图处理
        /// </summary>
        private async void StartCapture()
        {
            // 隐藏
            this.WindowState = FormWindowState.Minimized;
            this.Hide();

            var psi = new ProcessStartInfo()
            {
                UseShellExecute = true,
                FileName = "ms-screenclip:"
            };
            Process.Start(psi);

            var postLaunchProcesses = Process.GetProcessesByName("SnippingTool");
            var snippingToolProcess = Process.GetProcessesByName("ScreenClippingHost");
            var postLaunchProcesses3 = postLaunchProcesses.Concat(snippingToolProcess);
            var sinpping = postLaunchProcesses3.FirstOrDefault();
            if (sinpping != null)
            {
                await sinpping.WaitForExitAsync();
                ClipboardOCR();
            }
        }

        /// <summary>
        /// 截图完成
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SnippingToolProcess_Exited(object? sender, EventArgs e)
        {
            Debug.WriteLine("触发了已经");
            this.BeginInvoke(new Action(() =>
            {
                ClipboardOCR();
            }));
        }

        private readonly string[] ImgAllow = new string[] { "jpg", "png", "gif", "peg", "bmp" };

        /// <summary>
        /// 从剪切板获取图片并识别
        /// </summary>
        private void ClipboardOCR()
        {

            WindowsAPI.ShowWindow(this.Handle, 9);
            var img = Clipboard.GetImage();

            if (img != null)
            {
                sqPhoto.Image = img;
                timeOCR_Start();
                return;
            }

            // 直接复制的图片文件
            var files = Clipboard.GetFileDropList();
            if (files.Count > 0)
            {
                string ext = files[0].ToLower().Substring(files[0].Length - 3);
                if (ImgAllow.Contains(ext))
                {
                    sqPhoto.Image = Image.FromFile(files[0]);
                    timeOCR_Start();
                }
            }
        }

        /// <summary>
        /// 拖放图片
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void sqPhoto_DragDrop(object sender, DragEventArgs e)
        {
            string file = ((System.Array)e.Data.GetData(DataFormats.FileDrop)).GetValue(0).ToString()!;
            string ext = file.ToLower().Substring(file.Length - 3);
            if (ImgAllow.Contains(ext))
            {
                sqPhoto.Image = Image.FromFile(file);
                timeOCR_Start();
            }
        }

        /// <summary>
        /// 允许拖放
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void sqPhoto_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.All;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        /// <summary>
        /// 执行OCR识别图片
        /// </summary>
        /// <param name="imgfile"></param>
        private void showFileOcr(Image imgfile)
        {
            var isfanyi = toolStripComboBox1.Text.Equals("是");
            new Task(() =>
            {
                //识别结果对象
                var ocrResult = new OCRResult();
                using PaddleOCREngine engine = new PaddleOCREngine(null, new OCRParameter());
                ocrResult = engine.DetectText(imgfile);
                var txt = "";
                if (ocrResult.TextBlocks.Count > 0)
                {
                    foreach (var item in ocrResult.TextBlocks)
                    {
                        txt += item.Text + "\r\n";
                    }
                }
                this.BeginInvoke(new Action(() =>
                {
                    if (!string.IsNullOrEmpty(txt) && txt != textOCR.Text)
                    {
                        textOCR.Text = txt;
                    }
                    textOCR.Cursor = Cursors.IBeam;
                }));
                if (isfanyi)
                {
                    var fanyi = BaiduTransHelper.Trans(txt);
                    txt += $"翻译:\r\n{fanyi}";
                    this.BeginInvoke(new Action(() =>
                    {
                        if (!string.IsNullOrEmpty(txt) && txt != textOCR.Text)
                        {
                            textOCR.Text = txt;
                        }
                        textOCR.Cursor = Cursors.IBeam;
                    }));
                }

            }).Start();
        }

        /// <summary>
        /// 启动识别
        /// </summary>
        private void timeOCR_Start()
        {
            textOCR.Cursor = Cursors.WaitCursor;
            showFileOcr(sqPhoto.Image);
        }

        private void notifyIcon_DoubleClick(object sender, EventArgs e)
        {
            WindowsAPI.ShowWindow(this.Handle, 9);
        }

        private void Main_SizeChanged(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.Hide();
            }
        }

        private void 退出软件ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void 识别剪贴板ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClipboardOCR();
        }

        private void 显示ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WindowsAPI.ShowWindow(this.Handle, 9);
        }

        private void 开始截图ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StartCapture();
        }

        private void btn_tls_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void toolStripTextBox2_Click(object sender, EventArgs e)
        {
            new Task(() =>
            {
                var fanyi = BaiduTransHelper.Trans(textOCR.Text);
                this.BeginInvoke(new Action(() =>
                {
                    textOCR.Text = fanyi;
                }));
            }).Start();
        }
    }
}
