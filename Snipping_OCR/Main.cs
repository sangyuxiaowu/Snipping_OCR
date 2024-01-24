using PaddleOCRSharp;
using System.Diagnostics;
using System.Drawing.Imaging;
using System.Globalization;

namespace Snipping_OCR
{
    public partial class Main : Form
    {

        public Main()
        {
            InitializeComponent();
        }

        /// <summary>
        /// OCR 引擎
        /// </summary>
        private PaddleOCREngine engine;

        /// <summary>
        /// 专注模式
        /// </summary>
        private bool isFocus = false;


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
            // 根据操作系统自动设置语言
            CultureInfo currentCulture = CultureInfo.CurrentCulture;
            if (currentCulture.TwoLetterISOLanguageName == "zh")
            {
                Thread.CurrentThread.CurrentUICulture = new CultureInfo("zh-CN");
            }
            else
            {
                Thread.CurrentThread.CurrentUICulture = CultureInfo.InvariantCulture;
            }


            //注册热键 Ctrl+TAB 截图
            try
            {
                Hotkey.Regist(base.Handle, HotkeyModifiers.MOD_CONTROL, Keys.Tab, new Hotkey.HotKeyCallBackHanlder(StartCapture));
            }
            catch
            {
                notifyIcon.ShowBalloonTip(2, Resources.ScreenOCR, Resources.HotkeyRegistrationFailed, ToolTipIcon.Info);
            }

            OCRParameter oCRParameter = new()
            {
                use_gpu = true,
            };
            engine = new(null, oCRParameter);
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
            if (!isFocus)
            {
                this.WindowState = FormWindowState.Minimized;
                this.Hide();
            }

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
            //识别结果对象
            var ocrResult = new OCRResult();
            ocrResult = engine.DetectText(ImageToBytes(imgfile));
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
                if (!string.IsNullOrEmpty(txt) && txt != textOCR.Text) textOCR.Text = txt;
                textOCR.Cursor = Cursors.IBeam;
            }));
        }

        private byte[] ImageToBytes(Image img)
        {
            MemoryStream ms = new MemoryStream();
            img.Save(ms, ImageFormat.Jpeg);
            return ms.ToArray();
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

        private void 专注开启ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetFocusMode(true);
        }

        private void 专注关闭ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetFocusMode(false);
        }

        /// <summary>
        /// 专注模式切换
        /// </summary>
        /// <param name="isFocus">是否启用</param>
        private void SetFocusMode(bool isFocus)
        {
            this.isFocus = isFocus;
            this.TopMost = isFocus;
            this.FormBorderStyle = isFocus ? FormBorderStyle.FixedToolWindow : FormBorderStyle.Sizable;
            this.MinimumSize = isFocus ? this.textOCR.Size : new Size(800, 500);
            this.Size = isFocus ? this.textOCR.Size : new Size(800, 500);
            this.splitContainer.Panel1Collapsed = isFocus;
            this.Opacity = isFocus ? 0.9 : 1;
            this.textOCR.BackColor = isFocus ? Color.FromArgb(227, 237, 205) : Color.White;
            this.Text = isFocus ? $"Snipping OCR - {Resources.FocusMode}" : "Snipping OCR";
            this.开启ToolStripMenuItem.Checked = isFocus;
            this.关闭ToolStripMenuItem.Checked = !isFocus;
        }
    }
}
