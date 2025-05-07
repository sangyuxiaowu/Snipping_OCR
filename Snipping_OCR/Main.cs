using PaddleOCRSharp;
using Sang.Baidu.TranslateAPI;
using System.Diagnostics;
using System.Drawing.Imaging;
using System.Globalization;

#if NET481_OR_GREATER
using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Drawing;
using System.Threading;
#else
using Windows.Security.Credentials;
#endif


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
        /// 划词翻译
        /// </summary>
        private bool isTranslate = false;

        /// <summary>
        /// 翻译 SDK
        /// </summary>
        private BaiduTranslator baiduTranslator;

        /// <summary>
        /// 翻译配置 AppId
        /// </summary>
        private string baiduAppId = "";

        /// <summary>
        /// 翻译配置 密钥
        /// </summary>
        private string baiduSecretKey = "";

        /// <summary>
        /// 翻译目标语言
        /// </summary>
        private string targetLanguage = "";

        // 上次翻译内容
        private string lastTranslateText = "";

        /// <summary>
        /// 配置信息 Resource
        /// </summary>
        private readonly string configResource = "Snipping_OCR_BaiduTranslator";

#if NET481_OR_GREATER
        /// <summary>
        /// 程序配置文件目录
        /// </summary>
        string configFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory,"conf.dat");
#endif


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
            targetLanguage = currentCulture.TwoLetterISOLanguageName;
            if (targetLanguage == "zh")
            {
                Thread.CurrentThread.CurrentUICulture = new CultureInfo("zh-CN");
                Thread.CurrentThread.CurrentCulture = new CultureInfo("zh-CN");
            }
            else
            {
                Thread.CurrentThread.CurrentUICulture = CultureInfo.InvariantCulture;
                Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
            }

            this.Icon = notifyIcon.Icon;


            //注册热键 Ctrl+TAB 截图
            try
            {
                Hotkey.Regist(base.Handle, HotkeyModifiers.MOD_CONTROL, Keys.Tab, new Hotkey.HotKeyCallBackHanlder(StartCapture));
            }
            catch
            {
                notifyIcon.ShowBalloonTip(2, Resources.ScreenOCR, Resources.HotkeyRegistrationFailed, ToolTipIcon.Info);
            }

            OCRParameter oCRParameter = new OCRParameter()
            {
                use_gpu = true,
            };
            engine = new PaddleOCREngine(null, oCRParameter);

            // 获取翻译配置
            GetTranslateConfig();

            // 如果已经配置翻译，则启用划词翻译
            if (!string.IsNullOrEmpty(baiduAppId))
            {
                TranslateSwitch();
                TranslateCheck();
            }

            // 命令行启动OCR
            var CmdArgs = Environment.GetCommandLineArgs();
            if (CmdArgs.Length > 1)
            {
                // 如果存在第二个参数，并且第一个参数是 capture，则第二个参数是文件路径
                if (CmdArgs.Length > 2 && CmdArgs[1]== "capture")
                {
                    CmdArgs[1] = CmdArgs[2];
                }

                // 可以通过命令行调用所以需要判断文件是否存在
                string file = CmdArgs[1];
                if (File.Exists(file))
                {
                    string ext = file.ToLower().Substring(file.Length - 3);
                    if (ImgAllow.Contains(ext))
                    {
                        sqPhoto.Image = Image.FromFile(file);
                        timeOCR_Start();
                    }
                }
                else
                {
                    // 快捷命令
                    if (CmdArgs[1] == "capture")
                    {
                        StartCapture(); 
                    }
                }
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
# if NET481_OR_GREATER
                sinpping.WaitForExit();
#else
                await sinpping.WaitForExitAsync();
#endif
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
            string file = ((System.Array)e.Data.GetData(DataFormats.FileDrop)).GetValue(0).ToString();
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

        private void 专注模式ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetFocusMode(!isFocus);
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
            this.textTR.BackColor = this.textOCR.BackColor;
            this.Text = isFocus ? $"Snipping OCR - {Resources.FocusMode}" : "Snipping OCR";
            this.专注模式ToolStripMenuItem.Checked = isFocus;
        }

        /// <summary>
        /// 划词翻译切换
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 划词翻译ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TranslateSwitch();
            TranslateCheck();
        }

        /// <summary>
        /// 划词翻译切换
        /// </summary>
        private void TranslateSwitch()
        {
            this.isTranslate = !isTranslate;
            this.划词翻译ToolStripMenuItem.Checked = isTranslate;
            if (!isTranslate)
            {
                splitContainerText.Panel1Collapsed = true;
            }
        }

        /// <summary>
        /// 翻译配置和初始化检查
        /// </summary>
        private void TranslateCheck()
        {
            if (isTranslate)
            {
                // 检查配置
                if (string.IsNullOrEmpty(baiduAppId))
                {
                    SetTranslateConfig();
                    // 再次检查配置
                    if (string.IsNullOrEmpty(baiduAppId))
                    {
                        // 未配置翻译，关闭划词翻译
                        TranslateSwitch();
                        return;
                    }
                }
                if (baiduTranslator == null)
                {
                    baiduTranslator = new BaiduTranslator(baiduAppId, baiduSecretKey);
                }
                else
                {
                    baiduTranslator.SetAppIdAndSecretKey(baiduAppId, baiduSecretKey);
                }
            }
        }

        /// <summary>
        /// Ctrl + A 全选时触发翻译
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textOCR_KeyUp(object sender, KeyEventArgs e)
        {
            textOCR_MouseUp(null, null);
        }

        /// <summary>
        /// 选择文本时触发翻译
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void textOCR_MouseUp(object sender, MouseEventArgs e)
        {
            if (!isTranslate) return;
            if (textOCR.SelectedText.Length > 0)
            {
                // 选中文本时，显示翻译框
                var text = textOCR.SelectedText.Replace("\r\n", " ");

                // 如果选中文本和上次一样，则不再翻译
                if (text == lastTranslateText)
                {
                    splitContainerText.Panel1Collapsed = false;
                    return;
                }

                var result = await baiduTranslator.Translate(text, targetLanguage);
#if NET481_OR_GREATER
                this.Invoke((MethodInvoker)delegate
#else
                this.Invoke(() =>
#endif

                {
                    if (result is null || !result.Success)
                    {
                        textTR.Text = result?.Error_Msg;
                    }
                    else
                    {
                        textTR.Text = result.Trans_Result[0].Dst;
                        lastTranslateText = text;
                    }
                    splitContainerText.Panel1Collapsed = false;
                });
            }
            else
            {
                // 未选中文本时，并且没有复制翻译内容的意图时，隐藏翻译框
                if (!textTR.Focused)
                {
                    splitContainerText.Panel1Collapsed = true;
                }
            }
        }

        private void 翻译设置ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetTranslateConfig();
        }

        /// <summary>
        /// 设置翻译配置
        /// </summary>
        private void SetTranslateConfig()
        {
            InputDialog inputDialog = new InputDialog(Resources.TranslateSettings ,"APP ID", "Secret", baiduAppId, baiduSecretKey, "https://fanyi-api.baidu.com/doc/13", Resources.SaveSettings);
            if (inputDialog.ShowDialog() == DialogResult.OK)
            {
                baiduAppId = inputDialog.Value1;
                baiduSecretKey = inputDialog.Value2;
                SaveConfig();
            }
        }

        /// <summary>
        /// 获取翻译配置
        /// </summary>
        private void GetTranslateConfig()
        {
            try
            {
                #if NET481_OR_GREATER
                if (File.Exists(configFile))
                {
                    var lines = File.ReadAllLines(configFile);
                    if (lines.Length == 2)
                    {
                        baiduAppId = lines[0].Trim();
                        baiduSecretKey = lines[1].Trim();
                    }
                }
                #else
                var vault = new PasswordVault();
                var credential = vault.FindAllByResource(configResource).FirstOrDefault();
                if (credential != null)
                {
                    credential.RetrievePassword();
                    baiduAppId = credential.UserName;
                    baiduSecretKey = credential.Password;
                }
                #endif
            }
            catch
            {
                baiduAppId = "";
                baiduSecretKey = "";
            }
        }

        /// <summary>
        /// 保存配置
        /// </summary>
        private void SaveConfig()
        {
            try
            {
                #if NET481_OR_GREATER
                File.WriteAllText(configFile, $"{baiduAppId}\r\n{baiduSecretKey}");
                #else
                var vault = new PasswordVault();
                var credential = new PasswordCredential(configResource, baiduAppId, baiduSecretKey);
                vault.Add(credential);
                #endif
            }
            catch
            {
                // ignored
            }
            finally
            {
                // 更新翻译配置
                if (baiduTranslator != null)
                {
                    baiduTranslator.SetAppIdAndSecretKey(baiduAppId, baiduSecretKey);
                }
            }
        }

        
    }
}
