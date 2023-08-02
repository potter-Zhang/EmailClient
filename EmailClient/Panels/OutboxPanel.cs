using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EmailClient.Panels
{
    public partial class OutboxPanel : UserControl
    {
        EmailSystem emailSystem;
        string emailAddress;
        Dictionary<int, string> Ids;

        

        public OutboxPanel(string emailAddress)
        {
            InitializeComponent();
            Init(emailAddress);
        }

        void Init(string addr)
        {
            emailAddress = addr;
            emailSystem = new EmailSystem();
            Ids = new Dictionary<int, string>();
            OutboxListView.FullRowSelect = true;
            OutboxListView.View = View.Details;
            UpdateListView();
        }

        void AddEmailToListView(Email email)
        {
            ListViewItem item = new ListViewItem(email.receiver);
            item.SubItems.Add(email.subject);
            item.SubItems.Add(email.date);
            OutboxListView.Items.Add(item);
        }

        public void UpdateListView()
        {
            List<Email> emails = emailSystem.FindSentEmailsByUser(emailAddress);

            for (int i = 0; i < emails.Count; i++)
            {
                Ids[i] = emails[i].id;
            }

            OutboxListView.Items.Clear();
            foreach (Email email in emails)
            {
                AddEmailToListView(email);
            }
        }

        private void OutboxListView_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void CheckButton_Click(object sender, EventArgs e)
        {
            if (OutboxListView.SelectedIndices.Count == 0)
            {
                MessageBox.Show("请先选择一封邮件", "提示", MessageBoxButtons.OK);
                return;
            }
            Email email = emailSystem.FindSentEmailById(Ids[OutboxListView.SelectedIndices[0]]);
            if (email == null)
            {
                MessageBox.Show("error: email not found");
                return;
            }
            DisplayForm disp = new DisplayForm(new Receiver() { receiver = email.receiver }, email.subject, email.body, email.date, email.attachment);
            disp.Show();
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            if (OutboxListView.SelectedIndices.Count == 0)
            {
                MessageBox.Show("请先选择一封邮件", "提示", MessageBoxButtons.OK);
                return;
            }
            emailSystem.DeleteEmailFromOutbox(Ids[OutboxListView.SelectedIndices[0]]);
            UpdateListView();
            MessageBox.Show("删除成功", "提示", MessageBoxButtons.OK);
        }

        private void OutboxListView_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }
    }
}
