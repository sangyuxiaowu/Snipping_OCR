#if NET481_OR_GREATER
using System;
using System.Windows.Forms;
#endif

namespace Snipping_OCR
{
    public partial class InputDialog : Form
    {
        public string Value1 { get; set; }
        public string Value2 { get; set; }
        
        // 新增配置属性
        public string DialogTitle { get; set; }
        public string Label1Text { get; set; }
        public string Label2Text { get; set; }
        public string HelpUrl { get; set; }
        public string ButtonText { get; set; }

        public InputDialog()
        {
            InitializeComponent();
            // 设置默认值
            DialogTitle = "Input Dialog";
            Label1Text = "Input 1";
            Label2Text = "Input 2";
            ButtonText = Resources.SaveSettings;
        }

        /// <summary>
        /// 使用默认标签创建对话框
        /// </summary>
        public InputDialog(string value1 = "", string value2 = "") : this()
        {
            Value1 = value1;
            Value2 = value2;
        }

        /// <summary>
        /// 完全自定义的对话框
        /// </summary>
        public InputDialog(string title, string label1, string label2, string value1 = "", string value2 = "", string helpUrl = null, string buttonText = null)
        {
            InitializeComponent();
            
            DialogTitle = title;
            Label1Text = label1;
            Label2Text = label2;
            Value1 = value1;
            Value2 = value2;
            HelpUrl = helpUrl;
            ButtonText = buttonText ?? Resources.SaveSettings;
        }

        private void linkHelp_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (!string.IsNullOrEmpty(HelpUrl))
            {
                System.Diagnostics.Process.Start(HelpUrl);
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textInput1.Text) || string.IsNullOrEmpty(textInput2.Text))
            {
                MessageBox.Show(Resources.SettingsTips);
                return;
            }
            Value1 = textInput1.Text;
            Value2 = textInput2.Text;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void InputDialog_Load(object sender, EventArgs e)
        {
            // 设置标题和标签文本
            this.Text = DialogTitle;
            labInput1.Text = Label1Text;
            labInput2.Text = Label2Text;
            btnOK.Text = ButtonText;
            
            // 设置输入框的值
            textInput1.Text = Value1;
            textInput2.Text = Value2;
            
            // 如果没有帮助链接，则隐藏帮助链接
            linkHelp.Visible = !string.IsNullOrEmpty(HelpUrl);
            linkHelp.Text = string.IsNullOrEmpty(HelpUrl) ? "" : Resources.Help;
        }
    }
}