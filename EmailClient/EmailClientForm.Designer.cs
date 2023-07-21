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
            this.EmailAddress = new System.Windows.Forms.TextBox();
            this.Password = new System.Windows.Forms.TextBox();
            this.EmailAddressLabel = new System.Windows.Forms.Label();
            this.PasswordLabel = new System.Windows.Forms.Label();
            this.LoginButton = new System.Windows.Forms.Button();
            this.LoginPanel = new System.Windows.Forms.Panel();
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.MenuInboxButton = new System.Windows.Forms.Button();
            this.MenuOutboxButton = new System.Windows.Forms.Button();
            this.MenuSendEmailButton = new System.Windows.Forms.Button();
            this.SendPanel = new System.Windows.Forms.Panel();
            this.AttachmentList = new System.Windows.Forms.DataGridView();
            this.AddAttachmentButton = new System.Windows.Forms.Button();
            this.AttachmentLabel = new System.Windows.Forms.Label();
            this.SendButton = new System.Windows.Forms.Button();
            this.Content = new System.Windows.Forms.RichTextBox();
            this.Subject = new System.Windows.Forms.TextBox();
            this.SubjectLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.To = new System.Windows.Forms.TextBox();
            this.LoginPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            this.SendPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AttachmentList)).BeginInit();
            this.SuspendLayout();
            // 
            // EmailAddress
            // 
            this.EmailAddress.Location = new System.Drawing.Point(570, 146);
            this.EmailAddress.Name = "EmailAddress";
            this.EmailAddress.Size = new System.Drawing.Size(246, 30);
            this.EmailAddress.TabIndex = 0;
            // 
            // Password
            // 
            this.Password.Location = new System.Drawing.Point(570, 221);
            this.Password.Name = "Password";
            this.Password.Size = new System.Drawing.Size(246, 30);
            this.Password.TabIndex = 1;
            // 
            // EmailAddressLabel
            // 
            this.EmailAddressLabel.AutoSize = true;
            this.EmailAddressLabel.Location = new System.Drawing.Point(346, 152);
            this.EmailAddressLabel.Name = "EmailAddressLabel";
            this.EmailAddressLabel.Size = new System.Drawing.Size(127, 24);
            this.EmailAddressLabel.TabIndex = 2;
            this.EmailAddressLabel.Text = "EmailAddress";
            // 
            // PasswordLabel
            // 
            this.PasswordLabel.AutoSize = true;
            this.PasswordLabel.Location = new System.Drawing.Point(346, 227);
            this.PasswordLabel.Name = "PasswordLabel";
            this.PasswordLabel.Size = new System.Drawing.Size(91, 24);
            this.PasswordLabel.TabIndex = 3;
            this.PasswordLabel.Text = "Password";
            // 
            // LoginButton
            // 
            this.LoginButton.Location = new System.Drawing.Point(502, 344);
            this.LoginButton.Name = "LoginButton";
            this.LoginButton.Size = new System.Drawing.Size(112, 34);
            this.LoginButton.TabIndex = 4;
            this.LoginButton.Text = "Login";
            this.LoginButton.UseVisualStyleBackColor = true;
            this.LoginButton.Click += new System.EventHandler(this.LoginButton_Click);
            // 
            // LoginPanel
            // 
            this.LoginPanel.Controls.Add(this.EmailAddress);
            this.LoginPanel.Controls.Add(this.LoginButton);
            this.LoginPanel.Controls.Add(this.EmailAddressLabel);
            this.LoginPanel.Controls.Add(this.PasswordLabel);
            this.LoginPanel.Controls.Add(this.Password);
            this.LoginPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LoginPanel.Location = new System.Drawing.Point(0, 0);
            this.LoginPanel.Name = "LoginPanel";
            this.LoginPanel.Size = new System.Drawing.Size(1155, 524);
            this.LoginPanel.TabIndex = 5;
            // 
            // splitContainer
            // 
            this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer.Location = new System.Drawing.Point(0, 0);
            this.splitContainer.Name = "splitContainer";
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.splitContainer.Panel1.Controls.Add(this.MenuInboxButton);
            this.splitContainer.Panel1.Controls.Add(this.MenuOutboxButton);
            this.splitContainer.Panel1.Controls.Add(this.MenuSendEmailButton);
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.SendPanel);
            this.splitContainer.Size = new System.Drawing.Size(1155, 524);
            this.splitContainer.SplitterDistance = 215;
            this.splitContainer.TabIndex = 5;
            // 
            // MenuInboxButton
            // 
            this.MenuInboxButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.MenuInboxButton.Location = new System.Drawing.Point(0, 68);
            this.MenuInboxButton.Name = "MenuInboxButton";
            this.MenuInboxButton.Size = new System.Drawing.Size(215, 34);
            this.MenuInboxButton.TabIndex = 2;
            this.MenuInboxButton.Text = "Inbox";
            this.MenuInboxButton.UseVisualStyleBackColor = true;
            // 
            // MenuOutboxButton
            // 
            this.MenuOutboxButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.MenuOutboxButton.Location = new System.Drawing.Point(0, 34);
            this.MenuOutboxButton.Name = "MenuOutboxButton";
            this.MenuOutboxButton.Size = new System.Drawing.Size(215, 34);
            this.MenuOutboxButton.TabIndex = 1;
            this.MenuOutboxButton.Text = "OutBox";
            this.MenuOutboxButton.UseVisualStyleBackColor = true;
            // 
            // MenuSendEmailButton
            // 
            this.MenuSendEmailButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.MenuSendEmailButton.Location = new System.Drawing.Point(0, 0);
            this.MenuSendEmailButton.Name = "MenuSendEmailButton";
            this.MenuSendEmailButton.Size = new System.Drawing.Size(215, 34);
            this.MenuSendEmailButton.TabIndex = 0;
            this.MenuSendEmailButton.Text = "Send";
            this.MenuSendEmailButton.UseVisualStyleBackColor = true;
            // 
            // SendPanel
            // 
            this.SendPanel.Controls.Add(this.AttachmentList);
            this.SendPanel.Controls.Add(this.AddAttachmentButton);
            this.SendPanel.Controls.Add(this.AttachmentLabel);
            this.SendPanel.Controls.Add(this.SendButton);
            this.SendPanel.Controls.Add(this.Content);
            this.SendPanel.Controls.Add(this.Subject);
            this.SendPanel.Controls.Add(this.SubjectLabel);
            this.SendPanel.Controls.Add(this.label1);
            this.SendPanel.Controls.Add(this.To);
            this.SendPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SendPanel.Location = new System.Drawing.Point(0, 0);
            this.SendPanel.Name = "SendPanel";
            this.SendPanel.Size = new System.Drawing.Size(936, 524);
            this.SendPanel.TabIndex = 0;
            // 
            // AttachmentList
            // 
            this.AttachmentList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.AttachmentList.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.AttachmentList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.AttachmentList.Location = new System.Drawing.Point(190, 166);
            this.AttachmentList.Name = "AttachmentList";
            this.AttachmentList.RowHeadersWidth = 62;
            this.AttachmentList.RowTemplate.Height = 32;
            this.AttachmentList.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.AttachmentList.Size = new System.Drawing.Size(239, 56);
            this.AttachmentList.TabIndex = 18;
            // 
            // AddAttachmentButton
            // 
            this.AddAttachmentButton.Location = new System.Drawing.Point(50, 209);
            this.AddAttachmentButton.Name = "AddAttachmentButton";
            this.AddAttachmentButton.Size = new System.Drawing.Size(112, 34);
            this.AddAttachmentButton.TabIndex = 17;
            this.AddAttachmentButton.Text = "Add";
            this.AddAttachmentButton.UseVisualStyleBackColor = true;
            this.AddAttachmentButton.Click += new System.EventHandler(this.AddAttachmentButton_Click);
            // 
            // AttachmentLabel
            // 
            this.AttachmentLabel.AutoSize = true;
            this.AttachmentLabel.Location = new System.Drawing.Point(50, 172);
            this.AttachmentLabel.Name = "AttachmentLabel";
            this.AttachmentLabel.Size = new System.Drawing.Size(116, 24);
            this.AttachmentLabel.TabIndex = 16;
            this.AttachmentLabel.Text = "Attachment:";
            // 
            // SendButton
            // 
            this.SendButton.Location = new System.Drawing.Point(691, 81);
            this.SendButton.Name = "SendButton";
            this.SendButton.Size = new System.Drawing.Size(147, 34);
            this.SendButton.TabIndex = 15;
            this.SendButton.Text = "SendButton";
            this.SendButton.UseVisualStyleBackColor = true;
            // 
            // Content
            // 
            this.Content.Location = new System.Drawing.Point(50, 280);
            this.Content.Name = "Content";
            this.Content.Size = new System.Drawing.Size(837, 220);
            this.Content.TabIndex = 14;
            this.Content.Text = "";
            // 
            // Subject
            // 
            this.Subject.Location = new System.Drawing.Point(190, 121);
            this.Subject.Name = "Subject";
            this.Subject.Size = new System.Drawing.Size(239, 30);
            this.Subject.TabIndex = 13;
            // 
            // SubjectLabel
            // 
            this.SubjectLabel.AutoSize = true;
            this.SubjectLabel.Location = new System.Drawing.Point(50, 127);
            this.SubjectLabel.Name = "SubjectLabel";
            this.SubjectLabel.Size = new System.Drawing.Size(78, 24);
            this.SubjectLabel.TabIndex = 12;
            this.SubjectLabel.Text = "Subject:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(50, 86);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 24);
            this.label1.TabIndex = 11;
            this.label1.Text = "To:";
            // 
            // To
            // 
            this.To.Location = new System.Drawing.Point(190, 80);
            this.To.Name = "To";
            this.To.Size = new System.Drawing.Size(239, 30);
            this.To.TabIndex = 10;
            // 
            // EmailClientForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1155, 524);
            this.Controls.Add(this.LoginPanel); 
            this.Controls.Add(this.splitContainer);
            this.Name = "EmailClientForm";
            this.Text = "EmailClient";
            this.LoginPanel.ResumeLayout(false);
            this.LoginPanel.PerformLayout();
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            this.SendPanel.ResumeLayout(false);
            this.SendPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AttachmentList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private TextBox EmailAddress;
        private TextBox Password;
        private Label EmailAddressLabel;
        private Label PasswordLabel;
        private Button LoginButton;
        private Panel LoginPanel;
        private SplitContainer splitContainer;
        private Button MenuInboxButton;
        private Button MenuOutboxButton;
        private Button MenuSendEmailButton;
        private Panel SendPanel;
        private DataGridView AttachmentList;
        private Button AddAttachmentButton;
        private Label AttachmentLabel;
        private Button SendButton;
        private RichTextBox Content;
        private TextBox Subject;
        private Label SubjectLabel;
        private Label label1;
        private TextBox To;
    }
}