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

        public InboxPanel(string emailAddress, string password)
        {
            InitializeComponent();
            Setup();
            this.emailAddress= emailAddress;
            this.password= password;
            
        }

        public void FetchEmail()
        {
            
            try
            {
                pop3Client = new Pop3Client("pop.qq.com", 995);
                pop3Client.Connect(emailAddress, password);
                emails = pop3Client.GetEmails();

                foreach (string emailStr in emails)
                {
                    Email email = Email.Parse(emailStr);
                    ListViewItem item = new ListViewItem(email.sender);
                    item.SubItems.Add(email.subject);
                    InboxListView.Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Setup()
        {
            InboxListView.FullRowSelect = true;
        
            //InboxListView.GridLines = true;
            InboxListView.View = View.Details;
            InboxListView.Columns.Add("sender", -100, HorizontalAlignment.Left);
            InboxListView.Columns.Add("subject", -120, HorizontalAlignment.Left);
            
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
    }
}
