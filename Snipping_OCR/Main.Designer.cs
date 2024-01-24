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
            专注模式ToolStripMenuItem = new ToolStripMenuItem();
            开启ToolStripMenuItem = new ToolStripMenuItem();
            关闭ToolStripMenuItem = new ToolStripMenuItem();
            退出软件ToolStripMenuItem = new ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)splitContainer).BeginInit();
            splitContainer.Panel1.SuspendLayout();
            splitContainer.Panel2.SuspendLayout();
            splitContainer.SuspendLayout();
            iconMenu.SuspendLayout();
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
            iconMenu.Items.AddRange(new ToolStripItem[] { 显示ToolStripMenuItem, 开始截图ToolStripMenuItem, 识别剪贴板ToolStripMenuItem, 专注模式ToolStripMenuItem, 退出软件ToolStripMenuItem });
            iconMenu.Name = "iconMenu";
            iconMenu.Size = new Size(137, 114);
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
            // 专注模式ToolStripMenuItem
            // 
            专注模式ToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { 开启ToolStripMenuItem, 关闭ToolStripMenuItem });
            专注模式ToolStripMenuItem.Name = "专注模式ToolStripMenuItem";
            专注模式ToolStripMenuItem.Size = new Size(136, 22);
            专注模式ToolStripMenuItem.Text = "专注模式";
            // 
            // 开启ToolStripMenuItem
            // 
            开启ToolStripMenuItem.Name = "开启ToolStripMenuItem";
            开启ToolStripMenuItem.Size = new Size(100, 22);
            开启ToolStripMenuItem.Text = "开启";
            开启ToolStripMenuItem.Click += 专注开启ToolStripMenuItem_Click;
            // 
            // 关闭ToolStripMenuItem
            // 
            关闭ToolStripMenuItem.Checked = true;
            关闭ToolStripMenuItem.CheckState = CheckState.Checked;
            关闭ToolStripMenuItem.Name = "关闭ToolStripMenuItem";
            关闭ToolStripMenuItem.Size = new Size(100, 22);
            关闭ToolStripMenuItem.Text = "关闭";
            关闭ToolStripMenuItem.Click += 专注关闭ToolStripMenuItem_Click;
            // 
            // 退出软件ToolStripMenuItem
            // 
            退出软件ToolStripMenuItem.Name = "退出软件ToolStripMenuItem";
            退出软件ToolStripMenuItem.Size = new Size(136, 22);
            退出软件ToolStripMenuItem.Text = "退出软件";
            退出软件ToolStripMenuItem.Click += 退出软件ToolStripMenuItem_Click;
            // 
            // Main
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(784, 461);
            Controls.Add(splitContainer);
            Icon = (Icon)resources.GetObject("$this.Icon");
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
        private ToolStripMenuItem 开启ToolStripMenuItem;
        private ToolStripMenuItem 关闭ToolStripMenuItem;
    }
}