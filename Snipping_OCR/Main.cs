using PaddleOCRSharp;
using System.Diagnostics;
using System.Drawing.Imaging;

namespace Snipping_OCR
{
    public partial class Main : Form
    {

        public Main()
        {
            InitializeComponent();
        }

        private PaddleOCREngine engine;


        /// <summary>
        /// ��д������Ϣ
        /// </summary>
        /// <param name="m"></param>
        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
            Hotkey.ProcessHotKey(m);
        }

        /// <summary>
        /// ������ע���ȼ�
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Main_Load(object sender, EventArgs e)
        {
            //ע���ȼ� Ctrl+TAB ��ͼ
            try
            {
                Hotkey.Regist(base.Handle, HotkeyModifiers.MOD_CONTROL, Keys.Tab, new Hotkey.HotKeyCallBackHanlder(StartCapture));
            }
            catch
            {
                notifyIcon.ShowBalloonTip(2, "��Ļ OCR", "�ȼ�ע��ʧ�ܣ����Կ���ʹ��������ʽִ�� OCR��",ToolTipIcon.Info);
            }

            OCRParameter oCRParameter = new()
            {
                use_gpu = true,
            };
            engine = new(null, oCRParameter);
        }

        /// <summary>
        /// �رգ�ж���ȼ�
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
        /// ����ϵͳ��ͼ����
        /// </summary>
        private void StartCapture()
        {
            // ����
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

        }

        /// <summary>
        /// ��ͼ���
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SnippingToolProcess_Exited(object? sender, EventArgs e)
        {
            this.BeginInvoke(new Action(() =>
            {
                ClipboardOCR();
            }));
        }

        private readonly string[] ImgAllow = new string[] { "jpg", "png", "gif", "peg", "bmp" };

        /// <summary>
        /// �Ӽ��а��ȡͼƬ��ʶ��
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

            // ֱ�Ӹ��Ƶ�ͼƬ�ļ�
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
        /// �Ϸ�ͼƬ
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
        /// �����Ϸ�
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
        /// ִ��OCRʶ��ͼƬ
        /// </summary>
        /// <param name="imgfile"></param>
        private void showFileOcr(Image imgfile)
        {
            //ʶ��������
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
        /// ����ʶ��
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

        private void �˳����ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void ʶ�������ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClipboardOCR();
        }

        private void ��ʾToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WindowsAPI.ShowWindow(this.Handle, 9);
        }

        private void ��ʼ��ͼToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StartCapture();
        }
    }
}