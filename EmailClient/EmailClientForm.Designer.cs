namespace EmailClient
{
    partial class EmailClientForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EmailClientForm));
            this.Layout = new System.Windows.Forms.SplitContainer();
            this.AccountButton = new System.Windows.Forms.Button();
            this.InboxButton = new System.Windows.Forms.Button();
            this.OutboxButton = new System.Windows.Forms.Button();
            this.SendEmailButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.Layout)).BeginInit();
            this.Layout.Panel1.SuspendLayout();
            this.Layout.SuspendLayout();
            this.SuspendLayout();
            // 
            // Layout
            // 
            this.Layout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Layout.Location = new System.Drawing.Point(0, 0);
            this.Layout.Name = "Layout";
            // 
            // Layout.Panel1
            // 
            this.Layout.Panel1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.Layout.Panel1.Controls.Add(this.AccountButton);
            this.Layout.Panel1.Controls.Add(this.InboxButton);
            this.Layout.Panel1.Controls.Add(this.OutboxButton);
            this.Layout.Panel1.Controls.Add(this.SendEmailButton);
            // 
            // Layout.Panel2
            // 
            this.Layout.Panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.splitContainer1_Panel2_Paint);
            this.Layout.Size = new System.Drawing.Size(938, 546);
            this.Layout.SplitterDistance = 241;
            this.Layout.TabIndex = 0;
            // 
            // AccountButton
            // 
            this.AccountButton.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.AccountButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.AccountButton.ForeColor = System.Drawing.SystemColors.Desktop;
            this.AccountButton.Image = ((System.Drawing.Image)(resources.GetObject("AccountButton.Image")));
            this.AccountButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.AccountButton.Location = new System.Drawing.Point(0, 147);
            this.AccountButton.Name = "AccountButton";
            this.AccountButton.Size = new System.Drawing.Size(241, 49);
            this.AccountButton.TabIndex = 3;
            this.AccountButton.Text = "账号管理";
            this.AccountButton.UseVisualStyleBackColor = false;
            this.AccountButton.Click += new System.EventHandler(this.AccountButton_Click);
            // 
            // InboxButton
            // 
            this.InboxButton.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.InboxButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.InboxButton.ForeColor = System.Drawing.SystemColors.Desktop;
            this.InboxButton.Image = ((System.Drawing.Image)(resources.GetObject("InboxButton.Image")));
            this.InboxButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.InboxButton.Location = new System.Drawing.Point(0, 98);
            this.InboxButton.Name = "InboxButton";
            this.InboxButton.Size = new System.Drawing.Size(241, 49);
            this.InboxButton.TabIndex = 2;
            this.InboxButton.Text = "收件箱";
            this.InboxButton.UseVisualStyleBackColor = false;
            this.InboxButton.Click += new System.EventHandler(this.InboxButton_Click);
            // 
            // OutboxButton
            // 
            this.OutboxButton.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.OutboxButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.OutboxButton.ForeColor = System.Drawing.SystemColors.Desktop;
            this.OutboxButton.Image = ((System.Drawing.Image)(resources.GetObject("OutboxButton.Image")));
            this.OutboxButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.OutboxButton.Location = new System.Drawing.Point(0, 49);
            this.OutboxButton.Name = "OutboxButton";
            this.OutboxButton.Size = new System.Drawing.Size(241, 49);
            this.OutboxButton.TabIndex = 1;
            this.OutboxButton.Text = "发件箱";
            this.OutboxButton.UseVisualStyleBackColor = false;
            this.OutboxButton.Click += new System.EventHandler(this.OutboxButton_Click);
            // 
            // SendEmailButton
            // 
            this.SendEmailButton.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.SendEmailButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.SendEmailButton.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.SendEmailButton.Image = ((System.Drawing.Image)(resources.GetObject("SendEmailButton.Image")));
            this.SendEmailButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.SendEmailButton.Location = new System.Drawing.Point(0, 0);
            this.SendEmailButton.Name = "SendEmailButton";
            this.SendEmailButton.Size = new System.Drawing.Size(241, 49);
            this.SendEmailButton.TabIndex = 0;
            this.SendEmailButton.Text = "写信";
            this.SendEmailButton.UseVisualStyleBackColor = false;
            this.SendEmailButton.Click += new System.EventHandler(this.SendEmailButton_Click);
            // 
            // EmailClientForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(938, 546);
            this.Controls.Add(this.Layout);
            this.Name = "EmailClientForm";
            this.Text = "EmailClientForm";
            this.Layout.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Layout)).EndInit();
            this.Layout.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private SplitContainer Layout;
        private Button OutboxButton;
        private Button SendEmailButton;
        private Button InboxButton;
        private Button AccountButton;
    }
}