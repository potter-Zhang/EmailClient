using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace EmailClient.Panels
{
    public partial class InboxPanel : UserControl
    {
        string emailAddress;
        string password;
        Pop3Client pop3Client;
        List<string> emails;
        List<string> messageIds;
        int numOfEmails;

       
        public InboxPanel(string emailAddress, string password)
        {
            InitializeComponent();
            Setup();
            this.emailAddress = emailAddress;
            this.password = password;
            numOfEmails = 0;
            messageIds = new List<string>();
            
            pop3Client = new Pop3Client("pop.qq.com", 995);
            pop3Client.Connect(emailAddress, password);
        }

        

        public void FetchEmail()
        {
            try
            {
                if (numOfEmails == pop3Client.GetEmailNum())
                    return;

                InboxListView.Items.Clear();
                emails = pop3Client.GetEmails();

                foreach (string emailStr in emails)
                {
                    Email email = Email.Parse(emailStr);
                    if (messageIds.Contains(email.id))
                        continue;
                    messageIds.Add(email.id);
                    Action action = () => AddEmailToListView(email);
                    Invoke(action);
                    numOfEmails++;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        public void AddEmailToListView(Email email)
        {
            ListViewItem item = new ListViewItem(email.sender);
            item.SubItems.Add(email.subject);
            item.SubItems.Add(email.date);
            InboxListView.Items.Add(item);
        }

        private void Setup()
        {
            InboxListView.FullRowSelect = true;
            
            //InboxListView.GridLines = true;
            InboxListView.View = View.Details;
            //InboxListView.Columns.Add("发送者", -100, HorizontalAlignment.Left);
            //InboxListView.Columns.Add("主题", -120, HorizontalAlignment.Left);
            //InboxListView.Columns.Add("时间", -100, HorizontalAlignment.Left);
            //InboxListView.Show();
        }

        

        private void CheckButton_Click(object sender, EventArgs e)
        {
            Email email = Email.Parse(emails[InboxListView.SelectedIndices[0]]);
            DisplayForm disp = new DisplayForm(email.sender, email.subject, email.body);
            disp.Show();
        }

        private void InboxListView_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void GetButton_Click(object sender, EventArgs e)
        {
            pop3Client.Connect(emailAddress, password);
            FetchEmail();
        }
    }
}
