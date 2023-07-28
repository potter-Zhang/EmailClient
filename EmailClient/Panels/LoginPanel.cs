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
        EmailSystem emailSystem;
        
        private void Init()
        {
            userEmailAddress = string.Empty;
            userPassword = string.Empty;
            emailSystem = new EmailSystem();
        }

        public LoginPanel()
        {
            InitializeComponent();
            Init();
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            
            if (!EmailAddressTextBox.Text.EndsWith("@qq.com"))
            {
                MessageBox.Show("只支持qq邮箱", "提示", MessageBoxButtons.OK);
                return;
            }
            if (PasswordTextBox.Text.Length == 0)
            {
                MessageBox.Show("请输入授权码", "提示", MessageBoxButtons.OK);
                return;
            }
            userEmailAddress = EmailAddressTextBox.Text;
            userPassword = PasswordTextBox.Text;
            emailSystem.CreateTables();
            MessageBox.Show("成功登录", "", MessageBoxButtons.OK);
        }
    }
}
