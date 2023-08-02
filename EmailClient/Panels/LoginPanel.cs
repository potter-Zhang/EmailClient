using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EmailClient.Panels
{
    public partial class LoginPanel : UserControl
    {
        public string userEmailAddress;
        public string userPassword;
        public string smtpServer;
        public int smtpPort;
        public string pop3Server;
        public int pop3Port;
        public bool login;
        EmailSystem emailSystem;
        
        private void Init()
        {
            userEmailAddress = string.Empty;
            userPassword = string.Empty;
            smtpServer = string.Empty;
            smtpPort = 0;
            pop3Server = string.Empty;
            pop3Port = 0;
            emailSystem = new EmailSystem();
            login = false;
        }

        public LoginPanel()
        {
            InitializeComponent();
            Init();
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            login = false;
            if (EmailAddressTextBox.Text.Length == 0)
            {
                MessageBox.Show("请输入邮箱", "提示", MessageBoxButtons.OK);
                return;
            }
            if (PasswordTextBox.Text.Length == 0)
            {
                MessageBox.Show("请输入授权码", "提示", MessageBoxButtons.OK);
                return;
            }
            if (SmtpServerTextBox.Text.Length == 0)
            {
                MessageBox.Show("请输入smtp服务器", "提示", MessageBoxButtons.OK);
                return;
            }
            if (SmtpPortTextBox.Text.Length == 0)
            {
                MessageBox.Show("请输入smtp端口号", "提示", MessageBoxButtons.OK);
                return;
            }
            if (Pop3PortTextBox.Text.Length == 0)
            {
                MessageBox.Show("请输入pop3端口号", "提示", MessageBoxButtons.OK);
                return;
            }
            if (Pop3ServerTextBox.Text.Length == 0)
            {
                MessageBox.Show("请输入pop3服务器", "提示", MessageBoxButtons.OK);
                return;
            }

            userEmailAddress = EmailAddressTextBox.Text;
            userPassword = PasswordTextBox.Text;
            smtpServer = SmtpServerTextBox.Text;
            pop3Server = Pop3ServerTextBox.Text;
            smtpPort = int.Parse(SmtpPortTextBox.Text);
            pop3Port = int.Parse(Pop3PortTextBox.Text);

            try
            {
                
                emailSystem.CreateTables();
                MessageBox.Show("成功登录", "", MessageBoxButtons.OK);
                login = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("登录失败：" + ex.Message, "错误", MessageBoxButtons.OK);
            }
            
        }

        private void EmailAddressLabel_Click(object sender, EventArgs e)
        {

        }

        private void PasswordTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void Pop3PortTextBox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
