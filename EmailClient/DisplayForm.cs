using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Tab;
using System.Xml.Linq;

namespace EmailClient
{
    public struct Sender { public string sender; }
    public struct Receiver { public string receiver; }
    public partial class DisplayForm : Form
    {
        public DisplayForm(Sender s, string subject, string body)
        {
            InitializeComponent();
            MailLabel.Text = "寄件人";
            MailTextBox.Text = s.sender;
            SubjectTextBox.Text = subject;
            ContentRichTextBox.Text = body;
        }

        public DisplayForm(Receiver r, string subject, string body)
        {
            InitializeComponent();
            MailLabel.Text = "收件人";
            MailTextBox.Text = r.receiver;
            SubjectTextBox.Text = subject;
            ContentRichTextBox.Text = body;
        }


        private void ContentRichTextBox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
