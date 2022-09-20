namespace AAAPrintScreen
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.sqPhoto = new AAAPrintScreen.Component.SQPhoto();
            this.textOCR = new System.Windows.Forms.TextBox();
            this.timerOCR = new System.Windows.Forms.Timer(this.components);
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer
            // 
            this.splitContainer.AllowDrop = true;
            this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer.Location = new System.Drawing.Point(0, 0);
            this.splitContainer.Name = "splitContainer";
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.Controls.Add(this.sqPhoto);
            this.splitContainer.Panel1MinSize = 300;
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.textOCR);
            this.splitContainer.Panel2MinSize = 100;
            this.splitContainer.Size = new System.Drawing.Size(784, 461);
            this.splitContainer.SplitterDistance = 500;
            this.splitContainer.TabIndex = 0;
            // 
            // sqPhoto
            // 
            this.sqPhoto.AllowDrop = true;
            this.sqPhoto.AutoReSize = true;
            this.sqPhoto.CanMove = true;
            this.sqPhoto.CanReSize = true;
            this.sqPhoto.CanZoom = true;
            this.sqPhoto.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sqPhoto.Image = null;
            this.sqPhoto.Location = new System.Drawing.Point(0, 0);
            this.sqPhoto.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.sqPhoto.Name = "sqPhoto";
            this.sqPhoto.Size = new System.Drawing.Size(500, 461);
            this.sqPhoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.sqPhoto.TabIndex = 0;
            this.sqPhoto.ZoomCenter = true;
            this.sqPhoto.ZoomMin = 100;
            this.sqPhoto.DragDrop += new System.Windows.Forms.DragEventHandler(this.sqPhoto_DragDrop);
            this.sqPhoto.DragEnter += new System.Windows.Forms.DragEventHandler(this.sqPhoto_DragEnter);
            // 
            // textOCR
            // 
            this.textOCR.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textOCR.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textOCR.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textOCR.Location = new System.Drawing.Point(0, 0);
            this.textOCR.Multiline = true;
            this.textOCR.Name = "textOCR";
            this.textOCR.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textOCR.Size = new System.Drawing.Size(280, 461);
            this.textOCR.TabIndex = 0;
            // 
            // timerOCR
            // 
            this.timerOCR.Tick += new System.EventHandler(this.timerOCR_Tick);
            // 
            // notifyIcon
            // 
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Text = "截图 OCR";
            this.notifyIcon.Visible = true;
            this.notifyIcon.DoubleClick += new System.EventHandler(this.notifyIcon_DoubleClick);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 461);
            this.Controls.Add(this.splitContainer);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(800, 500);
            this.MinimumSize = new System.Drawing.Size(800, 500);
            this.Name = "Main";
            this.ShowInTaskbar = false;
            this.Text = "屏幕 OCR";
            this.Load += new System.EventHandler(this.Main_Load);
            this.SizeChanged += new System.EventHandler(this.Main_SizeChanged);
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel2.ResumeLayout(false);
            this.splitContainer.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private SplitContainer splitContainer;
        private Component.SQPhoto sqPhoto;
        private TextBox textOCR;
        private System.Windows.Forms.Timer timerOCR;
        private NotifyIcon notifyIcon;
    }
}