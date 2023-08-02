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
     
        Dictionary<int, string> Ids;
        EmailSystem emailSystem;

        Task task;

       
        public InboxPanel(string emailAddress, string password, string pop3Server, int pop3Port)
        {
            InitializeComponent();
            Setup();
            this.emailAddress = emailAddress;
            this.password = password;
            pop3Client = new Pop3Client(pop3Server, pop3Port);

            emailSystem = new EmailSystem();
            Ids = new Dictionary<int, string>();
          
        }

        

        public void FetchEmail()
        {
            try
            {
                ChangeStatus("trying to connect...");
                pop3Client.Connect(emailAddress, password);
                // get new emails and update database
                ChangeStatus("connect succeeded!");
                int num = pop3Client.GetEmailNum();
               
                ChangeStatus("Emails on server: " + num);
                
                int numOfNewEmails = 0;
                for (int i = num; i >= 1; i--)
                {
                    ChangeStatus("Checking email " + i);
                    string UID;
                    if (emailSystem.FindReceivedEmailById((UID = pop3Client.GetId(i))) == null)
                    {
                        Email email = Email.Parse(pop3Client.GetEmail(i));
                        emailSystem.SaveEmailToInbox(UID, email.sender, emailAddress, email.subject, email.body, Email.String2DateTime(email.date));
                        UpdateListView();
                        numOfNewEmails++;
                        
                    }
                    pop3Client.DeleteEmail(i);

                }
                ChangeStatus("completed");
                pop3Client.Disconnect();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        public void UpdateListView()
        {
            // get email from database, dateTime asc
            List<Email> localEmails = emailSystem.FindReceivedEmailsByUser(emailAddress);
       

            // update messageIds
            for (int i = 0; i < localEmails.Count; i++)
            {
                Ids[i] = localEmails[i].id;
            }

            // update listview
            Action action = () => { InboxListView.Items.Clear(); };
            Invoke(action);
            for (int i = 0; i < localEmails.Count; i++)
            {

                AddEmailToListView(localEmails[i]);
            }

        }

        public void ChangeStatus(string status)
        {
            Action action = () => { StatusLabel.Text = status; };
            Invoke(action);
        }



        public void AddEmailToListView(Email email)
        {
            ListViewItem item = new ListViewItem(email.sender);
            item.SubItems.Add(email.subject);
            item.SubItems.Add(email.date);
            Action action = () => { InboxListView.Items.Add(item); };
            Invoke(action);
           

        }

        private void Setup()
        {
            InboxListView.FullRowSelect = true;
         
            InboxListView.View = View.Details;
           
        }

        

        private void CheckButton_Click(object sender, EventArgs e)
        {
            if (InboxListView.SelectedIndices.Count == 0)
            {
                MessageBox.Show("请先选择一封邮件", "提示", MessageBoxButtons.OK);
                return;
            }
            Email email = emailSystem.FindReceivedEmailById(Ids[InboxListView.SelectedIndices[0]]);
            if (email == null)
            {
                MessageBox.Show("error: email not found");
                return;
            }
            DisplayForm disp = new DisplayForm(new Sender() { sender = email.sender }, email.subject, email.body, email.date, "");
            disp.Show();
        }

        private void InboxListView_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void GetButton_Click(object sender, EventArgs e)
        {
           if (task != null && !task.IsCompleted)
            {
                MessageBox.Show("获取未完成");
                return;
            }
           
            task = Task.Factory.StartNew(() =>
            {
               UpdateListView(); FetchEmail();
            },TaskCreationOptions.LongRunning | TaskCreationOptions.RunContinuationsAsynchronously | TaskCreationOptions.DenyChildAttach);
           
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            if (InboxListView.SelectedIndices.Count == 0)
            {
                MessageBox.Show("请先选择一封邮件", "提示", MessageBoxButtons.OK);
                return;
            }
            emailSystem.DeleteEmailFromInbox(Ids[InboxListView.SelectedIndices[0]]);

            UpdateListView();
            MessageBox.Show("成功删除邮件", "提示", MessageBoxButtons.OK);
        }
    }
}
