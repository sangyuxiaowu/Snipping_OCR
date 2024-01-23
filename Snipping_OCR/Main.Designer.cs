namespace Snipping_OCR
{
    partial class Main
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            splitContainer = new SplitContainer();
            sqPhoto = new SQPhoto.SQPhoto();
            textOCR = new TextBox();
            notifyIcon = new NotifyIcon(components);
            iconMenu = new ContextMenuStrip(components);
            显示ToolStripMenuItem = new ToolStripMenuItem();
            开始截图ToolStripMenuItem = new ToolStripMenuItem();
            识别剪贴板ToolStripMenuItem = new ToolStripMenuItem();
            退出软件ToolStripMenuItem = new ToolStripMenuItem();
            toolStrip1 = new ToolStrip();
            btn_tls = new ToolStripButton();
            toolStripSeparator1 = new ToolStripSeparator();
            toolStripLabel1 = new ToolStripLabel();
            toolStripComboBox1 = new ToolStripComboBox();
            ((System.ComponentModel.ISupportInitialize)splitContainer).BeginInit();
            splitContainer.Panel1.SuspendLayout();
            splitContainer.Panel2.SuspendLayout();
            splitContainer.SuspendLayout();
            iconMenu.SuspendLayout();
            toolStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // splitContainer
            // 
            splitContainer.AllowDrop = true;
            splitContainer.Dock = DockStyle.Fill;
            splitContainer.Location = new Point(0, 0);
            splitContainer.Name = "splitContainer";
            // 
            // splitContainer.Panel1
            // 
            splitContainer.Panel1.Controls.Add(sqPhoto);
            splitContainer.Panel1MinSize = 300;
            // 
            // splitContainer.Panel2
            // 
            splitContainer.Panel2.Controls.Add(textOCR);
            splitContainer.Panel2MinSize = 100;
            splitContainer.Size = new Size(784, 484);
            splitContainer.SplitterDistance = 500;
            splitContainer.TabIndex = 0;
            // 
            // sqPhoto
            // 
            sqPhoto.AllowDrop = true;
            sqPhoto.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            sqPhoto.AutoReSize = true;
            sqPhoto.CanMove = true;
            sqPhoto.CanReSize = true;
            sqPhoto.CanZoom = true;
            sqPhoto.Image = null;
            sqPhoto.Location = new Point(0, 28);
            sqPhoto.Margin = new Padding(4, 4, 4, 4);
            sqPhoto.Name = "sqPhoto";
            sqPhoto.Size = new Size(500, 456);
            sqPhoto.SizeMode = PictureBoxSizeMode.Zoom;
            sqPhoto.TabIndex = 0;
            sqPhoto.ZoomCenter = true;
            sqPhoto.ZoomMin = 100;
            sqPhoto.DragDrop += sqPhoto_DragDrop;
            sqPhoto.DragEnter += sqPhoto_DragEnter;
            // 
            // textOCR
            // 
            textOCR.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            textOCR.BorderStyle = BorderStyle.None;
            textOCR.Font = new Font("Microsoft YaHei UI", 10.5F, FontStyle.Regular, GraphicsUnit.Point);
            textOCR.Location = new Point(0, 28);
            textOCR.Multiline = true;
            textOCR.Name = "textOCR";
            textOCR.ScrollBars = ScrollBars.Vertical;
            textOCR.Size = new Size(280, 456);
            textOCR.TabIndex = 0;
            // 
            // notifyIcon
            // 
            notifyIcon.ContextMenuStrip = iconMenu;
            notifyIcon.Icon = (Icon)resources.GetObject("notifyIcon.Icon");
            notifyIcon.Text = "截图 OCR";
            notifyIcon.Visible = true;
            notifyIcon.DoubleClick += notifyIcon_DoubleClick;
            // 
            // iconMenu
            // 
            iconMenu.Items.AddRange(new ToolStripItem[] { 显示ToolStripMenuItem, 开始截图ToolStripMenuItem, 识别剪贴板ToolStripMenuItem, 退出软件ToolStripMenuItem });
            iconMenu.Name = "iconMenu";
            iconMenu.Size = new Size(137, 92);
            // 
            // 显示ToolStripMenuItem
            // 
            显示ToolStripMenuItem.Name = "显示ToolStripMenuItem";
            显示ToolStripMenuItem.Size = new Size(136, 22);
            显示ToolStripMenuItem.Text = "显示界面";
            显示ToolStripMenuItem.Click += 显示ToolStripMenuItem_Click;
            // 
            // 开始截图ToolStripMenuItem
            // 
            开始截图ToolStripMenuItem.Name = "开始截图ToolStripMenuItem";
            开始截图ToolStripMenuItem.Size = new Size(136, 22);
            开始截图ToolStripMenuItem.Text = "开始截图";
            开始截图ToolStripMenuItem.Click += 开始截图ToolStripMenuItem_Click;
            // 
            // 识别剪贴板ToolStripMenuItem
            // 
            识别剪贴板ToolStripMenuItem.Name = "识别剪贴板ToolStripMenuItem";
            识别剪贴板ToolStripMenuItem.Size = new Size(136, 22);
            识别剪贴板ToolStripMenuItem.Text = "识别剪贴板";
            识别剪贴板ToolStripMenuItem.Click += 识别剪贴板ToolStripMenuItem_Click;
            // 
            // 退出软件ToolStripMenuItem
            // 
            退出软件ToolStripMenuItem.Name = "退出软件ToolStripMenuItem";
            退出软件ToolStripMenuItem.Size = new Size(136, 22);
            退出软件ToolStripMenuItem.Text = "退出软件";
            退出软件ToolStripMenuItem.Click += 退出软件ToolStripMenuItem_Click;
            // 
            // toolStrip1
            // 
            toolStrip1.Items.AddRange(new ToolStripItem[] { btn_tls, toolStripSeparator1, toolStripLabel1, toolStripComboBox1 });
            toolStrip1.Location = new Point(0, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(784, 25);
            toolStrip1.TabIndex = 1;
            toolStrip1.Text = "toolStrip1";
            // 
            // btn_tls
            // 
            btn_tls.DisplayStyle = ToolStripItemDisplayStyle.Text;
            btn_tls.Image = (Image)resources.GetObject("btn_tls.Image");
            btn_tls.ImageTransparentColor = Color.Magenta;
            btn_tls.Name = "btn_tls";
            btn_tls.Size = new Size(48, 22);
            btn_tls.Text = "最小化";
            btn_tls.Click += btn_tls_Click;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(6, 25);
            // 
            // toolStripLabel1
            // 
            toolStripLabel1.Name = "toolStripLabel1";
            toolStripLabel1.Size = new Size(107, 22);
            toolStripLabel1.Text = "是否开启自动翻译:";
            // 
            // toolStripComboBox1
            // 
            toolStripComboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            toolStripComboBox1.DropDownWidth = 10;
            toolStripComboBox1.Items.AddRange(new object[] { "否", "是" });
            toolStripComboBox1.Name = "toolStripComboBox1";
            toolStripComboBox1.Size = new Size(121, 25);
            // 
            // Main
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(784, 484);
            ControlBox = false;
            Controls.Add(toolStrip1);
            Controls.Add(splitContainer);
            MinimumSize = new Size(800, 500);
            Name = "Main";
            ShowInTaskbar = false;
            Text = "Snipping OCR";
            TopMost = true;
            FormClosed += Main_FormClosed;
            Load += Main_Load;
            SizeChanged += Main_SizeChanged;
            splitContainer.Panel1.ResumeLayout(false);
            splitContainer.Panel2.ResumeLayout(false);
            splitContainer.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer).EndInit();
            splitContainer.ResumeLayout(false);
            iconMenu.ResumeLayout(false);
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private SplitContainer splitContainer;
        private SQPhoto.SQPhoto sqPhoto;
        private TextBox textOCR;
        private NotifyIcon notifyIcon;
        private ContextMenuStrip iconMenu;
        private ToolStripMenuItem 显示ToolStripMenuItem;
        private ToolStripMenuItem 识别剪贴板ToolStripMenuItem;
        private ToolStripMenuItem 退出软件ToolStripMenuItem;
        private ToolStripMenuItem 开始截图ToolStripMenuItem;
        private ToolStrip toolStrip1;
        private ToolStripButton btn_tls;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripLabel toolStripLabel1;
        private ToolStripComboBox toolStripComboBox1;
    }
}