namespace Snipping_OCR
{
    partial class InputDialog
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            labAPPID = new Label();
            textAPPID = new TextBox();
            textSecret = new TextBox();
            labSecret = new Label();
            btnOK = new Button();
            linkHelp = new LinkLabel();
            SuspendLayout();
            // 
            // labAPPID
            // 
            labAPPID.AutoSize = true;
            labAPPID.Location = new Point(28, 25);
            labAPPID.Name = "labAPPID";
            labAPPID.Size = new Size(47, 17);
            labAPPID.TabIndex = 0;
            labAPPID.Text = "APP ID";
            // 
            // textAPPID
            // 
            textAPPID.Location = new Point(109, 22);
            textAPPID.Name = "textAPPID";
            textAPPID.Size = new Size(139, 23);
            textAPPID.TabIndex = 1;
            // 
            // textSecret
            // 
            textSecret.Location = new Point(109, 55);
            textSecret.Name = "textSecret";
            textSecret.Size = new Size(139, 23);
            textSecret.TabIndex = 3;
            // 
            // labSecret
            // 
            labSecret.AutoSize = true;
            labSecret.Location = new Point(28, 58);
            labSecret.Name = "labSecret";
            labSecret.Size = new Size(44, 17);
            labSecret.TabIndex = 2;
            labSecret.Text = "Secret";
            // 
            // btnOK
            // 
            btnOK.Location = new Point(148, 96);
            btnOK.Name = "btnOK";
            btnOK.Size = new Size(100, 25);
            btnOK.TabIndex = 5;
            btnOK.Text = Resources.SaveSettings;
            btnOK.UseVisualStyleBackColor = true;
            btnOK.Click += btnOK_Click;
            // 
            // linkHelp
            // 
            linkHelp.AutoSize = true;
            linkHelp.Location = new Point(28, 100);
            linkHelp.Name = "linkHelp";
            linkHelp.Size = new Size(35, 17);
            linkHelp.TabIndex = 6;
            linkHelp.TabStop = true;
            linkHelp.Text = Resources.Help;
            linkHelp.LinkClicked += linkHelp_LinkClicked;
            // 
            // InputDialog
            // 
            AcceptButton = btnOK;
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(284, 141);
            Controls.Add(linkHelp);
            Controls.Add(btnOK);
            Controls.Add(textSecret);
            Controls.Add(labSecret);
            Controls.Add(textAPPID);
            Controls.Add(labAPPID);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            MaximumSize = new Size(300, 180);
            MinimumSize = new Size(300, 180);
            Name = "InputDialog";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "InputDialog";
            TopMost = true;
            Load += InputDialog_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labAPPID;
        private TextBox textAPPID;
        private TextBox textSecret;
        private Label labSecret;
        private Button btnOK;
        private LinkLabel linkHelp;
    }
}