namespace Snipping_OCR
{
    public partial class InputDialog : Form
    {

        public string AppId { get; set; }
        public string Secret { get; set; }

        public InputDialog()
        {
            InitializeComponent();
        }

        public InputDialog(string appId, string secret)
        {
            InitializeComponent();
            AppId = appId;
            Secret = secret;
        }

        private void linkHelp_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://fanyi-api.baidu.com/doc/13");
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textAPPID.Text) || string.IsNullOrEmpty(textSecret.Text))
            {
                MessageBox.Show(Resources.SettingsTips);
                return;
            }
            AppId = textAPPID.Text;
            Secret = textSecret.Text;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void InputDialog_Load(object sender, EventArgs e)
        {
            textAPPID.Text = AppId;
            textSecret.Text = Secret;
        }
    }
}
