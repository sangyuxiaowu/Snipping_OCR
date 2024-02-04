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
            iconMenu = new ContextMenuStrip(components);
            显示ToolStripMenuItem = new ToolStripMenuItem();
            开始截图ToolStripMenuItem = new ToolStripMenuItem();
            识别剪贴板ToolStripMenuItem = new ToolStripMenuItem();
            专注模式ToolStripMenuItem = new ToolStripMenuItem();
            划词翻译ToolStripMenuItem = new ToolStripMenuItem();
            翻译设置ToolStripMenuItem = new ToolStripMenuItem();
            退出软件ToolStripMenuItem = new ToolStripMenuItem();
            splitContainerText = new SplitContainer();
            textTR = new TextBox();
            textOCR = new TextBox();
            notifyIcon = new NotifyIcon(components);
            ((System.ComponentModel.ISupportInitialize)splitContainer).BeginInit();
            splitContainer.Panel1.SuspendLayout();
            splitContainer.Panel2.SuspendLayout();
            splitContainer.SuspendLayout();
            iconMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainerText).BeginInit();
            splitContainerText.Panel1.SuspendLayout();
            splitContainerText.Panel2.SuspendLayout();
            splitContainerText.SuspendLayout();
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
            splitContainer.Panel2.Controls.Add(splitContainerText);
            splitContainer.Panel2MinSize = 200;
            splitContainer.Size = new Size(784, 461);
            splitContainer.SplitterDistance = 500;
            splitContainer.TabIndex = 0;
            // 
            // sqPhoto
            // 
            sqPhoto.AllowDrop = true;
            sqPhoto.AutoReSize = true;
            sqPhoto.CanMove = true;
            sqPhoto.CanReSize = true;
            sqPhoto.CanZoom = true;
            sqPhoto.ContextMenuStrip = iconMenu;
            sqPhoto.Dock = DockStyle.Fill;
            sqPhoto.Image = null;
            sqPhoto.Location = new Point(0, 0);
            sqPhoto.Margin = new Padding(4, 4, 4, 4);
            sqPhoto.Name = "sqPhoto";
            sqPhoto.Size = new Size(500, 461);
            sqPhoto.SizeMode = PictureBoxSizeMode.Zoom;
            sqPhoto.TabIndex = 0;
            sqPhoto.ZoomCenter = true;
            sqPhoto.ZoomMin = 100;
            sqPhoto.DragDrop += sqPhoto_DragDrop;
            sqPhoto.DragEnter += sqPhoto_DragEnter;
            // 
            // iconMenu
            // 
            iconMenu.Items.AddRange(new ToolStripItem[] { 显示ToolStripMenuItem, 开始截图ToolStripMenuItem, 识别剪贴板ToolStripMenuItem, 专注模式ToolStripMenuItem, 划词翻译ToolStripMenuItem, 退出软件ToolStripMenuItem });
            iconMenu.Name = "iconMenu";
            iconMenu.Size = new Size(197, 136);
            // 
            // 显示ToolStripMenuItem
            // 
            显示ToolStripMenuItem.Name = "显示ToolStripMenuItem";
            显示ToolStripMenuItem.Size = new Size(196, 22);
            显示ToolStripMenuItem.Text = Resources.ShowInterface;
            显示ToolStripMenuItem.Click += 显示ToolStripMenuItem_Click;
            // 
            // 开始截图ToolStripMenuItem
            // 
            开始截图ToolStripMenuItem.Name = "开始截图ToolStripMenuItem";
            开始截图ToolStripMenuItem.Size = new Size(196, 22);
            开始截图ToolStripMenuItem.Text = Resources.StartScreenshot;
            开始截图ToolStripMenuItem.Click += 开始截图ToolStripMenuItem_Click;
            // 
            // 识别剪贴板ToolStripMenuItem
            // 
            识别剪贴板ToolStripMenuItem.Name = "识别剪贴板ToolStripMenuItem";
            识别剪贴板ToolStripMenuItem.Size = new Size(196, 22);
            识别剪贴板ToolStripMenuItem.Text = Resources.RecognizeClipboard;
            识别剪贴板ToolStripMenuItem.Click += 识别剪贴板ToolStripMenuItem_Click;
            // 
            // 专注模式ToolStripMenuItem
            // 
            专注模式ToolStripMenuItem.Name = "专注模式ToolStripMenuItem";
            专注模式ToolStripMenuItem.Size = new Size(196, 22);
            专注模式ToolStripMenuItem.Text = Resources.FocusMode;
            专注模式ToolStripMenuItem.Click += 专注模式ToolStripMenuItem_Click;
            // 
            // 划词翻译ToolStripMenuItem
            // 
            划词翻译ToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { 翻译设置ToolStripMenuItem });
            划词翻译ToolStripMenuItem.Name = "划词翻译ToolStripMenuItem";
            划词翻译ToolStripMenuItem.Size = new Size(196, 22);
            划词翻译ToolStripMenuItem.Text = Resources.TranslateSelected;
            划词翻译ToolStripMenuItem.Click += 划词翻译ToolStripMenuItem_Click;
            // 
            // 翻译设置ToolStripMenuItem
            // 
            翻译设置ToolStripMenuItem.Name = "翻译设置ToolStripMenuItem";
            翻译设置ToolStripMenuItem.Size = new Size(179, 22);
            翻译设置ToolStripMenuItem.Text = Resources.TranslateSettings;
            翻译设置ToolStripMenuItem.Click += 翻译设置ToolStripMenuItem_Click;
            // 
            // 退出软件ToolStripMenuItem
            // 
            退出软件ToolStripMenuItem.Name = "退出软件ToolStripMenuItem";
            退出软件ToolStripMenuItem.Size = new Size(196, 22);
            退出软件ToolStripMenuItem.Text = Resources.ExitSoftware;
            退出软件ToolStripMenuItem.Click += 退出软件ToolStripMenuItem_Click;
            // 
            // splitContainerText
            // 
            splitContainerText.Dock = DockStyle.Fill;
            splitContainerText.Location = new Point(0, 0);
            splitContainerText.Name = "splitContainerText";
            splitContainerText.Orientation = Orientation.Horizontal;
            // 
            // splitContainerText.Panel1
            // 
            splitContainerText.Panel1.Controls.Add(textTR);
            splitContainerText.Panel1Collapsed = true;
            // 
            // splitContainerText.Panel2
            // 
            splitContainerText.Panel2.Controls.Add(textOCR);
            splitContainerText.Panel2MinSize = 300;
            splitContainerText.Size = new Size(280, 461);
            splitContainerText.SplitterDistance = 161;
            splitContainerText.TabIndex = 1;
            // 
            // textTR
            // 
            textTR.BorderStyle = BorderStyle.None;
            textTR.Dock = DockStyle.Fill;
            textTR.Location = new Point(0, 0);
            textTR.Multiline = true;
            textTR.Name = "textTR";
            textTR.ScrollBars = ScrollBars.Vertical;
            textTR.Size = new Size(150, 161);
            textTR.TabIndex = 0;
            // 
            // textOCR
            // 
            textOCR.BorderStyle = BorderStyle.None;
            textOCR.Dock = DockStyle.Fill;
            textOCR.Font = new Font("Microsoft YaHei UI", 10.5F);
            textOCR.Location = new Point(0, 0);
            textOCR.Multiline = true;
            textOCR.Name = "textOCR";
            textOCR.ScrollBars = ScrollBars.Vertical;
            textOCR.Size = new Size(280, 461);
            textOCR.TabIndex = 0;
            textOCR.KeyUp += textOCR_KeyUp;
            textOCR.MouseUp += textOCR_MouseUp;
            // 
            // notifyIcon
            // 
            notifyIcon.ContextMenuStrip = iconMenu;
            notifyIcon.Icon = (Icon)resources.GetObject("notifyIcon.Icon");
            notifyIcon.Text = Resources.ScreenOCR;
            notifyIcon.Visible = true;
            notifyIcon.DoubleClick += notifyIcon_DoubleClick;
            // 
            // Main
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(784, 461);
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
            ((System.ComponentModel.ISupportInitialize)splitContainer).EndInit();
            splitContainer.ResumeLayout(false);
            iconMenu.ResumeLayout(false);
            splitContainerText.Panel1.ResumeLayout(false);
            splitContainerText.Panel1.PerformLayout();
            splitContainerText.Panel2.ResumeLayout(false);
            splitContainerText.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainerText).EndInit();
            splitContainerText.ResumeLayout(false);
            ResumeLayout(false);
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
        private ToolStripMenuItem 专注模式ToolStripMenuItem;
        private SplitContainer splitContainerText;
        private TextBox textTR;
        private ToolStripMenuItem 划词翻译ToolStripMenuItem;
        private ToolStripMenuItem 翻译设置ToolStripMenuItem;
    }
}