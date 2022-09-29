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
                Hotkey.Regist(base.Handle, HotkeyModifiers.MOD_CONTROL_ALT, Keys.A, new Hotkey.HotKeyCallBackHanlder(StartCaptureAsync));
            }
            catch
            {
                notifyIcon.ShowBalloonTip(2, "屏幕 OCR", "热键注册失败，您仍可以使用其他方式执行 OCR。",ToolTipIcon.Info);
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
                Hotkey.UnRegist(base.Handle, new Hotkey.HotKeyCallBackHanlder(StartCaptureAsync));
            }
            catch
            {

            }
        }



        /// <summary>
        /// 调用系统截图处理
        /// </summary>
        private void StartCaptureAsync()
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

            var snippingToolProcess = Process.GetProcessesByName("ScreenClippingHost")[0];
            snippingToolProcess.EnableRaisingEvents = true;
            snippingToolProcess.Exited += SnippingToolProcess_Exited;

            /*
            Process snippingToolProcess = new Process()
            {
                StartInfo = new ProcessStartInfo("C:\\Windows\\system32\\SnippingTool.exe", "/clip"),
                EnableRaisingEvents = true,
            };
            snippingToolProcess.Exited += SnippingToolProcess_Exited;
            snippingToolProcess.Start();
            */
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

        /// <summary>
        /// 从剪切板获取图片并识别
        /// </summary>
        private void ClipboardOCR()
        {

            WindowsAPI.ShowWindow(this.Handle, 9);
            var img = Clipboard.GetImage();

            if (img != null) {
                sqPhoto.Image = img;
                timeOCR_Start();
                return;
            }

            var files = Clipboard.GetFileDropList();
            if (files.Count > 0)
            {
                sqPhoto.Image = Image.FromFile(files[0]!);
                timeOCR_Start();
            }
        }

        /// <summary>
        /// 拖放图片
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void sqPhoto_DragDrop(object sender, DragEventArgs e)
        {
            string[] allow = new string[] { "jpg", "png", "gif", "peg", "bmp" };
            string file = ((System.Array)e.Data.GetData(DataFormats.FileDrop)).GetValue(0).ToString();
            string ext = file.ToLower().Substring(file.Length - 3);
            if (allow.Contains(ext))
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
                    if (!string.IsNullOrEmpty(txt) && txt != textOCR.Text) textOCR.Text = txt;
                    textOCR.Cursor = Cursors.IBeam;
                }));
                
            }).Start();
        }

        /// <summary>
        /// 启动识别
        /// </summary>
        private void timeOCR_Start() {
            textOCR.Cursor = Cursors.WaitCursor;
            showFileOcr(sqPhoto.Image);
        }

        private void notifyIcon_DoubleClick(object sender, EventArgs e)
        {
            WindowsAPI.ShowWindow(this.Handle, 9);
        }

        private void Main_SizeChanged(object sender, EventArgs e)
        {
            if(this.WindowState == FormWindowState.Minimized)
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

        
    }
}