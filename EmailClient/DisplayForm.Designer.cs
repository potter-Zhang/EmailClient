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
            this.FromTextBox = new System.Windows.Forms.TextBox();
            this.FromLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // ContentRichTextBox
            // 
            this.ContentRichTextBox.Location = new System.Drawing.Point(59, 156);
            this.ContentRichTextBox.Name = "ContentRichTextBox";
            this.ContentRichTextBox.ReadOnly = true;
            this.ContentRichTextBox.Size = new System.Drawing.Size(576, 282);
            this.ContentRichTextBox.TabIndex = 14;
            this.ContentRichTextBox.Text = "";
            this.ContentRichTextBox.TextChanged += new System.EventHandler(this.ContentRichTextBox_TextChanged);
            // 
            // SubjectTextBox
            // 
            this.SubjectTextBox.Location = new System.Drawing.Point(238, 78);
            this.SubjectTextBox.Name = "SubjectTextBox";
            this.SubjectTextBox.ReadOnly = true;
            this.SubjectTextBox.Size = new System.Drawing.Size(274, 30);
            this.SubjectTextBox.TabIndex = 13;
            // 
            // SubjectLabel
            // 
            this.SubjectLabel.AutoSize = true;
            this.SubjectLabel.Location = new System.Drawing.Point(123, 81);
            this.SubjectLabel.Name = "SubjectLabel";
            this.SubjectLabel.Size = new System.Drawing.Size(64, 24);
            this.SubjectLabel.TabIndex = 12;
            this.SubjectLabel.Text = "主题：";
            // 
            // FromTextBox
            // 
            this.FromTextBox.Location = new System.Drawing.Point(238, 17);
            this.FromTextBox.Name = "FromTextBox";
            this.FromTextBox.ReadOnly = true;
            this.FromTextBox.Size = new System.Drawing.Size(274, 30);
            this.FromTextBox.TabIndex = 11;
            // 
            // FromLabel
            // 
            this.FromLabel.AutoSize = true;
            this.FromLabel.Location = new System.Drawing.Point(123, 20);
            this.FromLabel.Name = "FromLabel";
            this.FromLabel.Size = new System.Drawing.Size(82, 24);
            this.FromLabel.TabIndex = 10;
            this.FromLabel.Text = "寄件人：";
            // 
            // DisplayForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(698, 450);
            this.Controls.Add(this.ContentRichTextBox);
            this.Controls.Add(this.SubjectTextBox);
            this.Controls.Add(this.SubjectLabel);
            this.Controls.Add(this.FromTextBox);
            this.Controls.Add(this.FromLabel);
            this.Name = "DisplayForm";
            this.Text = "DisplayForm";
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