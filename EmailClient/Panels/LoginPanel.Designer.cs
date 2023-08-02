namespace EmailClient.Panels
{
    partial class LoginPanel
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
            this.EmailAddressLabel = new System.Windows.Forms.Label();
            this.EmailAddressTextBox = new System.Windows.Forms.TextBox();
            this.PasswordTextBox = new System.Windows.Forms.TextBox();
            this.PasswordLabel = new System.Windows.Forms.Label();
            this.LoginButton = new System.Windows.Forms.Button();
            this.SmtpServerLabel = new System.Windows.Forms.Label();
            this.SmtpServerTextBox = new System.Windows.Forms.TextBox();
            this.SmtpPortTextBox = new System.Windows.Forms.TextBox();
            this.SmtpPortLabel = new System.Windows.Forms.Label();
            this.Pop3PortLabel = new System.Windows.Forms.Label();
            this.Pop3PortTextBox = new System.Windows.Forms.TextBox();
            this.Pop3ServerTextBox = new System.Windows.Forms.TextBox();
            this.Pop3ServerLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // EmailAddressLabel
            // 
            this.EmailAddressLabel.AutoSize = true;
            this.EmailAddressLabel.Location = new System.Drawing.Point(71, 140);
            this.EmailAddressLabel.Name = "EmailAddressLabel";
            this.EmailAddressLabel.Size = new System.Drawing.Size(100, 24);
            this.EmailAddressLabel.TabIndex = 0;
            this.EmailAddressLabel.Text = "电子邮箱：";
            this.EmailAddressLabel.Click += new System.EventHandler(this.EmailAddressLabel_Click);
            // 
            // EmailAddressTextBox
            // 
            this.EmailAddressTextBox.Location = new System.Drawing.Point(212, 140);
            this.EmailAddressTextBox.Name = "EmailAddressTextBox";
            this.EmailAddressTextBox.Size = new System.Drawing.Size(228, 30);
            this.EmailAddressTextBox.TabIndex = 1;
            // 
            // PasswordTextBox
            // 
            this.PasswordTextBox.Location = new System.Drawing.Point(212, 192);
            this.PasswordTextBox.Name = "PasswordTextBox";
            this.PasswordTextBox.Size = new System.Drawing.Size(228, 30);
            this.PasswordTextBox.TabIndex = 3;
            this.PasswordTextBox.TextChanged += new System.EventHandler(this.PasswordTextBox_TextChanged);
            // 
            // PasswordLabel
            // 
            this.PasswordLabel.AutoSize = true;
            this.PasswordLabel.Location = new System.Drawing.Point(71, 198);
            this.PasswordLabel.Name = "PasswordLabel";
            this.PasswordLabel.Size = new System.Drawing.Size(82, 24);
            this.PasswordLabel.TabIndex = 2;
            this.PasswordLabel.Text = "授权码：";
            // 
            // LoginButton
            // 
            this.LoginButton.Location = new System.Drawing.Point(278, 381);
            this.LoginButton.Name = "LoginButton";
            this.LoginButton.Size = new System.Drawing.Size(112, 34);
            this.LoginButton.TabIndex = 4;
            this.LoginButton.Text = "登录";
            this.LoginButton.UseVisualStyleBackColor = true;
            this.LoginButton.Click += new System.EventHandler(this.LoginButton_Click);
            // 
            // SmtpServerLabel
            // 
            this.SmtpServerLabel.AutoSize = true;
            this.SmtpServerLabel.Location = new System.Drawing.Point(71, 246);
            this.SmtpServerLabel.Name = "SmtpServerLabel";
            this.SmtpServerLabel.Size = new System.Drawing.Size(126, 24);
            this.SmtpServerLabel.TabIndex = 5;
            this.SmtpServerLabel.Text = "smtp服务器：";
            // 
            // SmtpServerTextBox
            // 
            this.SmtpServerTextBox.Location = new System.Drawing.Point(212, 246);
            this.SmtpServerTextBox.Name = "SmtpServerTextBox";
            this.SmtpServerTextBox.Size = new System.Drawing.Size(150, 30);
            this.SmtpServerTextBox.TabIndex = 6;
            // 
            // SmtpPortTextBox
            // 
            this.SmtpPortTextBox.Location = new System.Drawing.Point(512, 246);
            this.SmtpPortTextBox.Name = "SmtpPortTextBox";
            this.SmtpPortTextBox.Size = new System.Drawing.Size(88, 30);
            this.SmtpPortTextBox.TabIndex = 7;
            // 
            // SmtpPortLabel
            // 
            this.SmtpPortLabel.AutoSize = true;
            this.SmtpPortLabel.Location = new System.Drawing.Point(377, 249);
            this.SmtpPortLabel.Name = "SmtpPortLabel";
            this.SmtpPortLabel.Size = new System.Drawing.Size(129, 24);
            this.SmtpPortLabel.TabIndex = 8;
            this.SmtpPortLabel.Text = "端口（SSL）：";
            // 
            // Pop3PortLabel
            // 
            this.Pop3PortLabel.AutoSize = true;
            this.Pop3PortLabel.Location = new System.Drawing.Point(377, 301);
            this.Pop3PortLabel.Name = "Pop3PortLabel";
            this.Pop3PortLabel.Size = new System.Drawing.Size(129, 24);
            this.Pop3PortLabel.TabIndex = 12;
            this.Pop3PortLabel.Text = "端口（SSL）：";
            // 
            // Pop3PortTextBox
            // 
            this.Pop3PortTextBox.Location = new System.Drawing.Point(512, 298);
            this.Pop3PortTextBox.Name = "Pop3PortTextBox";
            this.Pop3PortTextBox.Size = new System.Drawing.Size(88, 30);
            this.Pop3PortTextBox.TabIndex = 11;
            this.Pop3PortTextBox.TextChanged += new System.EventHandler(this.Pop3PortTextBox_TextChanged);
            // 
            // Pop3ServerTextBox
            // 
            this.Pop3ServerTextBox.Location = new System.Drawing.Point(212, 298);
            this.Pop3ServerTextBox.Name = "Pop3ServerTextBox";
            this.Pop3ServerTextBox.Size = new System.Drawing.Size(150, 30);
            this.Pop3ServerTextBox.TabIndex = 10;
            // 
            // Pop3ServerLabel
            // 
            this.Pop3ServerLabel.AutoSize = true;
            this.Pop3ServerLabel.Location = new System.Drawing.Point(71, 298);
            this.Pop3ServerLabel.Name = "Pop3ServerLabel";
            this.Pop3ServerLabel.Size = new System.Drawing.Size(128, 24);
            this.Pop3ServerLabel.TabIndex = 9;
            this.Pop3ServerLabel.Text = "pop3服务器：";
            // 
            // LoginPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.Pop3PortLabel);
            this.Controls.Add(this.Pop3PortTextBox);
            this.Controls.Add(this.Pop3ServerTextBox);
            this.Controls.Add(this.Pop3ServerLabel);
            this.Controls.Add(this.SmtpPortLabel);
            this.Controls.Add(this.SmtpPortTextBox);
            this.Controls.Add(this.SmtpServerTextBox);
            this.Controls.Add(this.SmtpServerLabel);
            this.Controls.Add(this.LoginButton);
            this.Controls.Add(this.PasswordTextBox);
            this.Controls.Add(this.PasswordLabel);
            this.Controls.Add(this.EmailAddressTextBox);
            this.Controls.Add(this.EmailAddressLabel);
            this.Name = "LoginPanel";
            this.Size = new System.Drawing.Size(697, 546);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label EmailAddressLabel;
        private TextBox EmailAddressTextBox;
        private TextBox PasswordTextBox;
        private Label PasswordLabel;
        private Button LoginButton;
        private Label SmtpServerLabel;
        private TextBox SmtpServerTextBox;
        private TextBox SmtpPortTextBox;
        private Label SmtpPortLabel;
        private Label Pop3PortLabel;
        private TextBox Pop3PortTextBox;
        private TextBox Pop3ServerTextBox;
        private Label Pop3ServerLabel;
    }
}
