using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EmailClient.Panels
{
    public partial class SendPanel : UserControl
    {
        string emailAddress;
        string password;
        
        SmtpClient smtpClient;
        EmailSystem emailSystem;

        public SendPanel(string emailAddress, string password, string smtpServer, int smtpPort)
        {
            InitializeComponent();
            this.emailAddress = emailAddress;
            this.password = password;
           
            smtpClient = new SmtpClient(smtpServer, smtpPort);
            emailSystem = new EmailSystem();
        }

        private void SendButton_Click(object sender, EventArgs e)
        {
            if (smtpClient == null)
            {
                MessageBox.Show("ERROR: smtpClient missing", "error", MessageBoxButtons.OK);
                return;
            }

            try
            {
                string dateTime = smtpClient.SendEmail(emailAddress, password, ToTextBox.Text, SubjectTextBox.Text, ContentRichTextBox.Text);
                emailSystem.SaveEmailToOutbox(Guid.NewGuid().ToString(), emailAddress, ToTextBox.Text, SubjectTextBox.Text, ContentRichTextBox.Text, Email.String2DateTime(dateTime));
                MessageBox.Show("成功发送邮件！", "", MessageBoxButtons.OK);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "error", MessageBoxButtons.OK);
            }
        }
    }
}
