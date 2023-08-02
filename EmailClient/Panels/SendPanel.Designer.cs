namespace EmailClient.Panels
{
    partial class SendPanel
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
            this.ToLabel = new System.Windows.Forms.Label();
            this.ToTextBox = new System.Windows.Forms.TextBox();
            this.SubjectTextBox = new System.Windows.Forms.TextBox();
            this.SubjectLabel = new System.Windows.Forms.Label();
            this.ContentRichTextBox = new System.Windows.Forms.RichTextBox();
            this.SendButton = new System.Windows.Forms.Button();
            this.AttachmentLabel = new System.Windows.Forms.Label();
            this.AttachmentTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // ToLabel
            // 
            this.ToLabel.AutoSize = true;
            this.ToLabel.Location = new System.Drawing.Point(140, 37);
            this.ToLabel.Name = "ToLabel";
            this.ToLabel.Size = new System.Drawing.Size(82, 24);
            this.ToLabel.TabIndex = 0;
            this.ToLabel.Text = "收件人：";
            this.ToLabel.Click += new System.EventHandler(this.ToLabel_Click);
            // 
            // ToTextBox
            // 
            this.ToTextBox.Location = new System.Drawing.Point(255, 34);
            this.ToTextBox.Name = "ToTextBox";
            this.ToTextBox.Size = new System.Drawing.Size(274, 30);
            this.ToTextBox.TabIndex = 1;
            this.ToTextBox.TextChanged += new System.EventHandler(this.ToTextBox_TextChanged);
            // 
            // SubjectTextBox
            // 
            this.SubjectTextBox.Location = new System.Drawing.Point(255, 80);
            this.SubjectTextBox.Name = "SubjectTextBox";
            this.SubjectTextBox.Size = new System.Drawing.Size(274, 30);
            this.SubjectTextBox.TabIndex = 3;
            this.SubjectTextBox.TextChanged += new System.EventHandler(this.SubjectTextBox_TextChanged);
            // 
            // SubjectLabel
            // 
            this.SubjectLabel.AutoSize = true;
            this.SubjectLabel.Location = new System.Drawing.Point(140, 86);
            this.SubjectLabel.Name = "SubjectLabel";
            this.SubjectLabel.Size = new System.Drawing.Size(64, 24);
            this.SubjectLabel.TabIndex = 2;
            this.SubjectLabel.Text = "主题：";
            this.SubjectLabel.Click += new System.EventHandler(this.SubjectLabel_Click);
            // 
            // ContentRichTextBox
            // 
            this.ContentRichTextBox.Location = new System.Drawing.Point(59, 191);
            this.ContentRichTextBox.Name = "ContentRichTextBox";
            this.ContentRichTextBox.Size = new System.Drawing.Size(576, 263);
            this.ContentRichTextBox.TabIndex = 4;
            this.ContentRichTextBox.Text = "";
            // 
            // SendButton
            // 
            this.SendButton.Location = new System.Drawing.Point(283, 486);
            this.SendButton.Name = "SendButton";
            this.SendButton.Size = new System.Drawing.Size(112, 34);
            this.SendButton.TabIndex = 5;
            this.SendButton.Text = "发送";
            this.SendButton.UseVisualStyleBackColor = true;
            this.SendButton.Click += new System.EventHandler(this.SendButton_Click);
            // 
            // AttachmentLabel
            // 
            this.AttachmentLabel.AutoSize = true;
            this.AttachmentLabel.Location = new System.Drawing.Point(140, 134);
            this.AttachmentLabel.Name = "AttachmentLabel";
            this.AttachmentLabel.Size = new System.Drawing.Size(64, 24);
            this.AttachmentLabel.TabIndex = 7;
            this.AttachmentLabel.Text = "附件：";
            this.AttachmentLabel.Click += new System.EventHandler(this.AttachmentLabel_Click);
            // 
            // AttachmentTextBox
            // 
            this.AttachmentTextBox.Location = new System.Drawing.Point(255, 134);
            this.AttachmentTextBox.Name = "AttachmentTextBox";
            this.AttachmentTextBox.ReadOnly = true;
            this.AttachmentTextBox.Size = new System.Drawing.Size(274, 30);
            this.AttachmentTextBox.TabIndex = 9;
            this.AttachmentTextBox.Click += new System.EventHandler(this.AttachmentTextBox_Click);
            this.AttachmentTextBox.TextChanged += new System.EventHandler(this.AttachmentTextBox_TextChanged);
            // 
            // SendPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.AttachmentTextBox);
            this.Controls.Add(this.AttachmentLabel);
            this.Controls.Add(this.SendButton);
            this.Controls.Add(this.ContentRichTextBox);
            this.Controls.Add(this.SubjectTextBox);
            this.Controls.Add(this.SubjectLabel);
            this.Controls.Add(this.ToTextBox);
            this.Controls.Add(this.ToLabel);
            this.Name = "SendPanel";
            this.Size = new System.Drawing.Size(697, 546);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label ToLabel;
        private TextBox ToTextBox;
        private TextBox SubjectTextBox;
        private Label SubjectLabel;
        private RichTextBox ContentRichTextBox;
        private Button SendButton;
        private Label AttachmentLabel;
        private TextBox AttachmentTextBox;
    }
}
