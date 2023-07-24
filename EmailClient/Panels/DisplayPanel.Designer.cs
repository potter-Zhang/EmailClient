namespace EmailClient.Panels
{
    partial class DisplayPanel
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
            this.ContentRichTextBox = new System.Windows.Forms.RichTextBox();
            this.SubjectTextBox = new System.Windows.Forms.TextBox();
            this.SubjectLabel = new System.Windows.Forms.Label();
            this.FromTextBox = new System.Windows.Forms.TextBox();
            this.FromLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // ContentRichTextBox
            // 
            this.ContentRichTextBox.Location = new System.Drawing.Point(60, 202);
            this.ContentRichTextBox.Name = "ContentRichTextBox";
            this.ContentRichTextBox.ReadOnly = true;
            this.ContentRichTextBox.Size = new System.Drawing.Size(576, 282);
            this.ContentRichTextBox.TabIndex = 9;
            this.ContentRichTextBox.Text = "";
            this.ContentRichTextBox.TextChanged += new System.EventHandler(this.ContentRichTextBox_TextChanged);
            // 
            // SubjectTextBox
            // 
            this.SubjectTextBox.Location = new System.Drawing.Point(239, 124);
            this.SubjectTextBox.Name = "SubjectTextBox";
            this.SubjectTextBox.ReadOnly = true;
            this.SubjectTextBox.Size = new System.Drawing.Size(274, 30);
            this.SubjectTextBox.TabIndex = 8;
            this.SubjectTextBox.TextChanged += new System.EventHandler(this.SubjectTextBox_TextChanged);
            // 
            // SubjectLabel
            // 
            this.SubjectLabel.AutoSize = true;
            this.SubjectLabel.Location = new System.Drawing.Point(124, 127);
            this.SubjectLabel.Name = "SubjectLabel";
            this.SubjectLabel.Size = new System.Drawing.Size(64, 24);
            this.SubjectLabel.TabIndex = 7;
            this.SubjectLabel.Text = "主题：";
            this.SubjectLabel.Click += new System.EventHandler(this.SubjectLabel_Click);
            // 
            // FromTextBox
            // 
            this.FromTextBox.Location = new System.Drawing.Point(239, 63);
            this.FromTextBox.Name = "FromTextBox";
            this.FromTextBox.ReadOnly = true;
            this.FromTextBox.Size = new System.Drawing.Size(274, 30);
            this.FromTextBox.TabIndex = 6;
            this.FromTextBox.TextChanged += new System.EventHandler(this.FromTextBox_TextChanged);
            // 
            // FromLabel
            // 
            this.FromLabel.AutoSize = true;
            this.FromLabel.Location = new System.Drawing.Point(124, 66);
            this.FromLabel.Name = "FromLabel";
            this.FromLabel.Size = new System.Drawing.Size(82, 24);
            this.FromLabel.TabIndex = 5;
            this.FromLabel.Text = "寄件人：";
            this.FromLabel.Click += new System.EventHandler(this.FromLabel_Click);
            // 
            // DisplayPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ContentRichTextBox);
            this.Controls.Add(this.SubjectTextBox);
            this.Controls.Add(this.SubjectLabel);
            this.Controls.Add(this.FromTextBox);
            this.Controls.Add(this.FromLabel);
            this.Name = "DisplayPanel";
            this.Size = new System.Drawing.Size(697, 546);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private RichTextBox ContentRichTextBox;
        private TextBox SubjectTextBox;
        private Label SubjectLabel;
        private TextBox FromTextBox;
        private Label FromLabel;
    }
}
