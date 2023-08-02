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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace EmailClient.Panels
{
    public partial class SendPanel : UserControl
    {
        string emailAddress;
        string password;
        List<Attachment> attachments;
        
        SmtpClient smtpClient;
        EmailSystem emailSystem;

        public SendPanel(string emailAddress, string password, string smtpServer, int smtpPort)
        {
            InitializeComponent();
            this.emailAddress = emailAddress;
            this.password = password;
           
            smtpClient = new SmtpClient(smtpServer, smtpPort);
            emailSystem = new EmailSystem();
            attachments = new List<Attachment>();
            
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
                string dateTime = smtpClient.SendEmail(emailAddress, password, ToTextBox.Text, SubjectTextBox.Text, ContentRichTextBox.Text, attachments);
                emailSystem.SaveEmailToOutbox(Guid.NewGuid().ToString(), emailAddress, ToTextBox.Text, SubjectTextBox.Text, ContentRichTextBox.Text, Email.String2DateTime(dateTime), AttachmentTextBox.Text);
                MessageBox.Show("成功发送邮件！", "", MessageBoxButtons.OK);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "error", MessageBoxButtons.OK);
            }
        }

        private void SubjectLabel_Click(object sender, EventArgs e)
        {

        }


       

        private void AttachmentLabel_Click(object sender, EventArgs e)
        {

        }

        private void SubjectTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void ToTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void ToLabel_Click(object sender, EventArgs e)
        {

        }

        private void AttachmentTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void AttachmentTextBox_Click(object sender, EventArgs e)
        {
            attachments.Clear();
            AttachmentTextBox.Text = "";
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "选择文件";
            openFileDialog.Multiselect = true;
            openFileDialog.Filter = "所有文件|*.*";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                foreach (string file in openFileDialog.FileNames)
                {
                    Attachment a = new Attachment(file);
                    attachments.Add(a);
                    AttachmentTextBox.Text += a.FileName() + " ";
                }

            }
        }
    }
}
