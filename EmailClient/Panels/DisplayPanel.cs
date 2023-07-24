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
    public partial class DisplayPanel : UserControl
    {
        public DisplayPanel(string sender, string subject, string body)
        {
            InitializeComponent();
            FromTextBox.Text = sender;
            SubjectTextBox.Text = subject;
            ContentRichTextBox.Text = body;
        }

        private void FromTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void ContentRichTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void SubjectTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void SubjectLabel_Click(object sender, EventArgs e)
        {

        }

        private void FromLabel_Click(object sender, EventArgs e)
        {

        }
    }
}
