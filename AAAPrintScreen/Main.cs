using CCWin.SkinControl;

namespace AAAPrintScreen
{
    public partial class Main : Form
    {

        public Main()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            var k_hook = new KeyboardHook();
            k_hook.KeyDownEvent += new KeyEventHandler(hook_KeyDown);//钩住键按下
            k_hook.Start();//安装键盘钩子
        }
        private int alt_Num = 0;
        private DateTime alt_last = DateTime.Now;
        private void hook_KeyDown(object sender, KeyEventArgs e)
        {
            //判断按下的键 ALT
            if (e.KeyValue == 164 || e.KeyValue == 165)
            {
                if((alt_last - DateTime.Now).TotalMilliseconds < 800)
                {
                    alt_Num++;
                    if (alt_Num >= 3)
                    {
                        alt_Num = 0;
                        StartCapture();
                    }
                }
                else
                {
                    alt_Num = 1;
                    alt_last = DateTime.Now;
                }
            }
        }
        /// <summary>
        /// 截图控件
        /// </summary>
        private FrmCapture m_frmCapture;
        private void StartCapture()
        {
            // 隐藏
            WindowsAPI.ShowWindow(this.Handle, 0);
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
        }

        private void sqPhoto_DragDrop(object sender, DragEventArgs e)
        {
            string[] allow = new string[] { "jpg", "png", "gif", "peg", "bmp" };
            string file = ((System.Array)e.Data.GetData(DataFormats.FileDrop)).GetValue(0).ToString();
            string ext = file.ToLower().Substring(file.Length - 3);
            if (allow.Contains(ext)) showFileOCR(file);
        }

        private void showFileOCR(string file)
        {
            throw new NotImplementedException();
        }
    }
}