#if NET481_OR_GREATER
using System;
using System.Drawing;
using System.Windows.Forms;

#endif

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
            labInput1 = new Label();
            textInput1 = new TextBox();
            textInput2 = new TextBox();
            labInput2 = new Label();
            btnOK = new Button();
            linkHelp = new LinkLabel();
            SuspendLayout();
            // 
            // labInput1
            // 
            labInput1.AutoSize = true;
            labInput1.Location = new Point(28, 25);
            labInput1.Name = "labInput1";
            labInput1.Size = new Size(47, 17);
            labInput1.TabIndex = 0;
            labInput1.Text = "Input 1";
            // 
            // textInput1
            // 
            textInput1.Location = new Point(109, 22);
            textInput1.Name = "textInput1";
            textInput1.Size = new Size(139, 23);
            textInput1.TabIndex = 1;
            // 
            // textInput2
            // 
            textInput2.Location = new Point(109, 55);
            textInput2.Name = "textInput2";
            textInput2.Size = new Size(139, 23);
            textInput2.TabIndex = 3;
            // 
            // labInput2
            // 
            labInput2.AutoSize = true;
            labInput2.Location = new Point(28, 58);
            labInput2.Name = "labInput2";
            labInput2.Size = new Size(44, 17);
            labInput2.TabIndex = 2;
            labInput2.Text = "Input 2";
            // 
            // btnOK
            // 
            btnOK.Location = new Point(148, 96);
            btnOK.Name = "btnOK";
            btnOK.Size = new Size(100, 25);
            btnOK.TabIndex = 5;
            btnOK.Text = "OK";
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
            linkHelp.Text = "Help";
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
            Controls.Add(textInput2);
            Controls.Add(labInput2);
            Controls.Add(textInput1);
            Controls.Add(labInput1);
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

        private Label labInput1;
        private TextBox textInput1;
        private TextBox textInput2;
        private Label labInput2;
        private Button btnOK;
        private LinkLabel linkHelp;
    }
}