using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Net.Mail;

namespace EmailClient
{
    public partial class EmailClientForm : Form
    {
        private StmpClient _stmpClient;
        //private Pop3Client _pop3Client;
        enum PanelType { SEND, OUT, IN };

        private List<Panel> _panels;
        private PanelType _currentPanel;

        public EmailClientForm()
        {
            InitializeComponent();
            Setup();
            Init();
        }

        private void Init()
        { 
            _panels = new List<Panel>();
            _panels.Add(SendPanel);
            _currentPanel = PanelType.SEND;
        }

        private void LoginSwitch()
        {
            LoginPanel.Visible = false;
            splitContainer.Visible = true;
        }

        private void SwitchPanel(PanelType panelType)
        {
            _panels[(int)_currentPanel].Visible = false;
            _currentPanel = panelType;
            _panels[(int)_currentPanel].Visible = true;
        }

        private void Setup()
        {
            splitContainer.Visible = false;
            LoginPanel.Visible = true;
            AttachmentList.ColumnCount = 2;
            AttachmentList.Columns[0].Name = "index";
            AttachmentList.Columns[1].Name = "file";
        }
        private void LoginButton_Click(object sender, EventArgs e)
        {
            

            if (EmailAddress.Text.Length == 0)
            {
                MessageBox.Show("ERROR: please enter a email address");
                return;
            }

            if (!EmailAddress.Text.EndsWith("@qq.com"))
            {
                MessageBox.Show("ERROR: invalid email address, support qq email only");
                return;
            }

            if (Password.Text.Length == 0)
            {
                MessageBox.Show("ERROR: please enter a password");
                return;
            }
            

            try
            {
                _stmpClient = new StmpClient(EmailAddress.Text, Password.Text);
                //_pop3Client = new Pop3Client(EmailAddress.Text, Password.Text);
                LoginSwitch();
                //SendEmail se = new SendEmail(stmpClient);

                //se.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            //Close();
            //SwitchPanel(PanelType.SEND);
        }

        private void SendButton_Click(object sender, EventArgs e)
        {
            Subject.Text = "hello";
            To.Text = "2976857809@qq.com";
            Content.Text = "test email";
            string subject = Subject.Text;
            string to = To.Text;
            string text = Content.Text;

            try
            {
                _stmpClient.SendEmail(to, subject, text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void AddAttachmentButton_Click(object sender, EventArgs e)
        {
            string filePath = string.Empty;
            string fileName = string.Empty;
            string fileContent = string.Empty;

            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Title = "Add attachment";
                openFileDialog.InitialDirectory = "C:\\";
                openFileDialog.Filter = "txt files (*.txt)|*.txt";
                openFileDialog.Multiselect = false;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    filePath = openFileDialog.FileName;
                    fileName = filePath.Substring(filePath.LastIndexOf('\\') + 1);
                    var fileStream = openFileDialog.OpenFile();

                    using (StreamReader reader = new StreamReader(fileStream))
                    {
                        fileContent = reader.ReadToEnd();
                    }
                }
            }

            string[] newRow = { AttachmentList.Rows.Count.ToString(), fileName };
            AttachmentList.Rows.Add(newRow);
        }

        private void EmailAddressLabel_Click(object sender, EventArgs e)
        {

        }

       
    }
}
