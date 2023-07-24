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
    public partial class DisplayForm : Form
    {
        public DisplayForm(string sender, string subject, string body)
        {
            InitializeComponent();
            FromTextBox.Text = sender;
            SubjectTextBox.Text = subject;
            ContentRichTextBox.Text = body;
        }

        private void ContentRichTextBox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
