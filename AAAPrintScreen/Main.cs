using CCWin.SkinControl;
using PaddleOCRSharp;
using System.Security.Cryptography;

namespace AAAPrintScreen
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
        private void Main_Load(object sender, EventArgs e)
        {
            //注册热键 Ctrl+ALT+V 截图
            Hotkey.Regist(base.Handle, HotkeyModifiers.MOD_CONTROL_ALT, Keys.A, new Hotkey.HotKeyCallBackHanlder(StartCapture));
        }


        /// <summary>
        /// 截图控件
        /// </summary>
        private FrmCapture m_frmCapture;
        private void StartCapture()
        {
            // 隐藏
            this.WindowState = FormWindowState.Minimized;
            this.Hide();
            if (m_frmCapture == null || m_frmCapture.IsDisposed)
            {
                m_frmCapture = new FrmCapture();
            }
            m_frmCapture.IsCaptureCursor = false;
            m_frmCapture.Disposed += M_frmCapture_Disposed;
            m_frmCapture.Show();
        }

        private void M_frmCapture_Disposed(object? sender, EventArgs e)
        {
            WindowsAPI.ShowWindow(this.Handle, 9);
            var img = Clipboard.GetImage();
            if (img == null) return;
            sqPhoto.Image = img;
            timeOCR_Start();
        }

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

        private void showFileOcr(Image imgfile)
        {

            //识别结果对象
            var ocrResult = new OCRResult();
            using PaddleOCREngine engine = new PaddleOCREngine(null, new OCRParameter());
            ocrResult = engine.DetectText(imgfile);
            if (!ocrResult.IsNull())
            {
                textOCR.Text = "";
                foreach (var item in ocrResult.TextBlocks)
                {
                    textOCR.Text += item.Text+"\r\n";
                }
            }
            textOCR.Cursor = Cursors.IBeam;
        }

        private void timeOCR_Start() {
            textOCR.Cursor = Cursors.WaitCursor;
            timerOCR.Enabled = true;
        }
        private void timerOCR_Tick(object sender, EventArgs e)
        {
            timerOCR.Enabled = false;
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
    }
}