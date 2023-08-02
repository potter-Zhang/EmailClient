namespace EmailClient
{
    partial class DisplayForm
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
            this.ContentRichTextBox = new System.Windows.Forms.RichTextBox();
            this.SubjectTextBox = new System.Windows.Forms.TextBox();
            this.SubjectLabel = new System.Windows.Forms.Label();
            this.MailTextBox = new System.Windows.Forms.TextBox();
            this.MailLabel = new System.Windows.Forms.Label();
            this.DateLabel = new System.Windows.Forms.Label();
            this.DateTextBox = new System.Windows.Forms.TextBox();
            this.AttachmentLabel = new System.Windows.Forms.Label();
            this.AttachmentTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // ContentRichTextBox
            // 
            this.ContentRichTextBox.Location = new System.Drawing.Point(59, 210);
            this.ContentRichTextBox.Name = "ContentRichTextBox";
            this.ContentRichTextBox.ReadOnly = true;
            this.ContentRichTextBox.Size = new System.Drawing.Size(576, 228);
            this.ContentRichTextBox.TabIndex = 14;
            this.ContentRichTextBox.Text = "";
            this.ContentRichTextBox.TextChanged += new System.EventHandler(this.ContentRichTextBox_TextChanged);
            // 
            // SubjectTextBox
            // 
            this.SubjectTextBox.Location = new System.Drawing.Point(238, 68);
            this.SubjectTextBox.Name = "SubjectTextBox";
            this.SubjectTextBox.ReadOnly = true;
            this.SubjectTextBox.Size = new System.Drawing.Size(274, 30);
            this.SubjectTextBox.TabIndex = 13;
            // 
            // SubjectLabel
            // 
            this.SubjectLabel.AutoSize = true;
            this.SubjectLabel.Location = new System.Drawing.Point(123, 71);
            this.SubjectLabel.Name = "SubjectLabel";
            this.SubjectLabel.Size = new System.Drawing.Size(64, 24);
            this.SubjectLabel.TabIndex = 12;
            this.SubjectLabel.Text = "主题：";
            // 
            // MailTextBox
            // 
            this.MailTextBox.Location = new System.Drawing.Point(238, 17);
            this.MailTextBox.Name = "MailTextBox";
            this.MailTextBox.ReadOnly = true;
            this.MailTextBox.Size = new System.Drawing.Size(274, 30);
            this.MailTextBox.TabIndex = 11;
            // 
            // MailLabel
            // 
            this.MailLabel.AutoSize = true;
            this.MailLabel.Location = new System.Drawing.Point(123, 20);
            this.MailLabel.Name = "MailLabel";
            this.MailLabel.Size = new System.Drawing.Size(82, 24);
            this.MailLabel.TabIndex = 10;
            this.MailLabel.Text = "寄件人：";
            // 
            // DateLabel
            // 
            this.DateLabel.AutoSize = true;
            this.DateLabel.Location = new System.Drawing.Point(124, 116);
            this.DateLabel.Name = "DateLabel";
            this.DateLabel.Size = new System.Drawing.Size(64, 24);
            this.DateLabel.TabIndex = 15;
            this.DateLabel.Text = "时间：";
            // 
            // DateTextBox
            // 
            this.DateTextBox.Location = new System.Drawing.Point(238, 116);
            this.DateTextBox.Name = "DateTextBox";
            this.DateTextBox.ReadOnly = true;
            this.DateTextBox.Size = new System.Drawing.Size(274, 30);
            this.DateTextBox.TabIndex = 16;
            // 
            // AttachmentLabel
            // 
            this.AttachmentLabel.AutoSize = true;
            this.AttachmentLabel.Location = new System.Drawing.Point(123, 166);
            this.AttachmentLabel.Name = "AttachmentLabel";
            this.AttachmentLabel.Size = new System.Drawing.Size(64, 24);
            this.AttachmentLabel.TabIndex = 17;
            this.AttachmentLabel.Text = "附件：";
            // 
            // AttachmentTextBox
            // 
            this.AttachmentTextBox.Location = new System.Drawing.Point(238, 166);
            this.AttachmentTextBox.Name = "AttachmentTextBox";
            this.AttachmentTextBox.ReadOnly = true;
            this.AttachmentTextBox.Size = new System.Drawing.Size(274, 30);
            this.AttachmentTextBox.TabIndex = 18;
            // 
            // DisplayForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(698, 450);
            this.Controls.Add(this.AttachmentTextBox);
            this.Controls.Add(this.AttachmentLabel);
            this.Controls.Add(this.DateTextBox);
            this.Controls.Add(this.DateLabel);
            this.Controls.Add(this.ContentRichTextBox);
            this.Controls.Add(this.SubjectTextBox);
            this.Controls.Add(this.SubjectLabel);
            this.Controls.Add(this.MailTextBox);
            this.Controls.Add(this.MailLabel);
            this.Name = "DisplayForm";
            this.Text = "DisplayForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private RichTextBox ContentRichTextBox;
        private TextBox SubjectTextBox;
        private Label SubjectLabel;
        private TextBox MailTextBox;
        private Label MailLabel;
        private Label DateLabel;
        private TextBox DateTextBox;
        private Label AttachmentLabel;
        private TextBox AttachmentTextBox;
    }
}