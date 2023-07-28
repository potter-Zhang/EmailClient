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
            
            userEmailAddress = EmailAddressTextBox.Text;
            userPassword = PasswordTextBox.Text;
            emailSystem.CreateTables();
            MessageBox.Show("成功登录", "", MessageBoxButtons.OK);
        }
    }
}
