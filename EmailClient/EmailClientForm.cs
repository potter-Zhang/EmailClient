﻿using EmailClient.Panels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EmailClient
{
    public partial class EmailClientForm : Form
    {
        LoginPanel loginPanel;
        InboxPanel inboxPanel;
        OutboxPanel outboxPanel;

        public EmailClientForm()
        {
            InitializeComponent();
            loginPanel = new LoginPanel();
            loginPanel.Show();
            Layout.Panel2.Controls.Add(loginPanel);

        }

        bool AccountExist()
        {
            return loginPanel.login;
        }

        private void SwitchPanel(string panelName)
        {
            if (!AccountExist())
            {
                MessageBox.Show("请先登录", "警告", MessageBoxButtons.OK);
                return;
            }
                

            Layout.Panel2.Controls.Clear();
            switch (panelName)
            {
                case "LoginPanel":
                    loginPanel.Show();
                    Layout.Panel2.Controls.Add(loginPanel);
                    break;
                case "SendPanel":
                    SendPanel sendPanel = new SendPanel(loginPanel.userEmailAddress, loginPanel.userPassword, loginPanel.smtpServer, loginPanel.smtpPort);
                    sendPanel.Show();
                    Layout.Panel2.Controls.Add(sendPanel);
                    break;
                case "InboxPanel":
                    
                    inboxPanel = new InboxPanel(loginPanel.userEmailAddress, loginPanel.userPassword, loginPanel.pop3Server, loginPanel.pop3Port);
                    inboxPanel.Show();
                    Layout.Panel2.Controls.Add(inboxPanel);
                    break;
                
                case "OutboxPanel":
                    outboxPanel = new OutboxPanel(loginPanel.userEmailAddress);
                    outboxPanel.Show();
                    Layout.Panel2.Controls.Add(outboxPanel);
                    
                    break;
                default:
                    break;

            }
        }


        private void SendEmailButton_Click(object sender, EventArgs e)
        {
            SwitchPanel("SendPanel");
        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void AccountButton_Click(object sender, EventArgs e)
        {
            SwitchPanel("LoginPanel");
        }

        private void InboxButton_Click(object sender, EventArgs e)
        {
            SwitchPanel("InboxPanel");
        }

        private void OutboxButton_Click(object sender, EventArgs e)
        {
            SwitchPanel("OutboxPanel");
        }
    }
}
