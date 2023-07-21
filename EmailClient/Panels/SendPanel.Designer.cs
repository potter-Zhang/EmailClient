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
            this.SuspendLayout();
            // 
            // ToLabel
            // 
            this.ToLabel.AutoSize = true;
            this.ToLabel.Location = new System.Drawing.Point(123, 36);
            this.ToLabel.Name = "ToLabel";
            this.ToLabel.Size = new System.Drawing.Size(82, 24);
            this.ToLabel.TabIndex = 0;
            this.ToLabel.Text = "收件人：";
            // 
            // ToTextBox
            // 
            this.ToTextBox.Location = new System.Drawing.Point(238, 33);
            this.ToTextBox.Name = "ToTextBox";
            this.ToTextBox.Size = new System.Drawing.Size(274, 30);
            this.ToTextBox.TabIndex = 1;
            // 
            // SubjectTextBox
            // 
            this.SubjectTextBox.Location = new System.Drawing.Point(238, 94);
            this.SubjectTextBox.Name = "SubjectTextBox";
            this.SubjectTextBox.Size = new System.Drawing.Size(274, 30);
            this.SubjectTextBox.TabIndex = 3;
            // 
            // SubjectLabel
            // 
            this.SubjectLabel.AutoSize = true;
            this.SubjectLabel.Location = new System.Drawing.Point(123, 97);
            this.SubjectLabel.Name = "SubjectLabel";
            this.SubjectLabel.Size = new System.Drawing.Size(64, 24);
            this.SubjectLabel.TabIndex = 2;
            this.SubjectLabel.Text = "主题：";
            // 
            // ContentRichTextBox
            // 
            this.ContentRichTextBox.Location = new System.Drawing.Point(59, 172);
            this.ContentRichTextBox.Name = "ContentRichTextBox";
            this.ContentRichTextBox.Size = new System.Drawing.Size(576, 282);
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
            // SendPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
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
    }
}
