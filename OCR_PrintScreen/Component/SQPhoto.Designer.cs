
namespace AAAPrintScreen.Component
{
    partial class SQPhoto
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.PanBox = new System.Windows.Forms.Panel();
            this.PicBox = new System.Windows.Forms.PictureBox();
            this.PanBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PicBox)).BeginInit();
            this.SuspendLayout();
            // 
            // PanBox
            // 
            this.PanBox.Controls.Add(this.PicBox);
            this.PanBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanBox.Location = new System.Drawing.Point(0, 0);
            this.PanBox.Name = "PanBox";
            this.PanBox.Size = new System.Drawing.Size(247, 174);
            this.PanBox.TabIndex = 0;
            // 
            // PicBox
            // 
            this.PicBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PicBox.Location = new System.Drawing.Point(0, 0);
            this.PicBox.Name = "PicBox";
            this.PicBox.Size = new System.Drawing.Size(247, 174);
            this.PicBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PicBox.TabIndex = 0;
            this.PicBox.TabStop = false;
            // 
            // SQPhoto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.PanBox);
            this.DoubleBuffered = true;
            this.Name = "SQPhoto";
            this.Size = new System.Drawing.Size(247, 174);
            this.PanBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PicBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel PanBox;
        private System.Windows.Forms.PictureBox PicBox;
    }
}
