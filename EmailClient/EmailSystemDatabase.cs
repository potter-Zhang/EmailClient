using System;
using System.Data.SqlClient;
using System.Net;
using System.Net.Mail;
using OpenPop.Pop3;

public class EmailSystem
{
    private const string SmtpServer = "smtp.qq.com";
    private const int SmtpPort = 587;
    private const string Pop3Server = "pop.qq.com";
    private const int Pop3Port = 995;
    private const string Username = "your_qq_email@qq.com";
    private const string Password = "your_password";
    private const string ConnectionString = "Data Source=/Email.sql;Initial Catalog=EmailSystemDB;Integrated Security=True";

    public void RegisterUser(string username, string password)
    {
        string insertUserQuery = "INSERT INTO Users (Username, Password) VALUES (@Username, @Password)";

        using (var connection = new SqlConnection(ConnectionString))
        {
            connection.Open();

            using (var command = new SqlCommand(insertUserQuery, connection))
            {
                command.Parameters.AddWithValue("@Username", username);
                command.Parameters.AddWithValue("@Password", password);

                command.ExecuteNonQuery();
            }
        }
    }

    public bool ValidateUser(string username, string password)
    {
        string selectUserQuery = "SELECT COUNT(*) FROM Users WHERE Username = @Username AND Password = @Password";

        using (var connection = new SqlConnection(ConnectionString))
        {
            connection.Open();

            using (var command = new SqlCommand(selectUserQuery, connection))
            {
                command.Parameters.AddWithValue("@Username", username);
                command.Parameters.AddWithValue("@Password", password);

                int count = (int)command.ExecuteScalar();
                return count > 0;
            }
        }
    }

    public void SendEmail(string recipient, string subject, string body)
    {
        // 发送邮件
        using (var client = new SmtpClient(SmtpServer, SmtpPort))
        {
            client.EnableSsl = true;
            client.Credentials = new NetworkCredential(Username, Password);

            var message = new MailMessage(Username, recipient, subject, body);
            client.Send(message);

            // 保存到发件箱
            SaveEmailToSentItems(Username, recipient, subject, body);
        }
    }

    public void ReceiveEmails()
    {
        using (var client = new Pop3Client())
        {
            client.Connect(Pop3Server, Pop3Port, true);
            client.Authenticate(Username, Password);

            int messageCount = client.GetMessageCount();
            for (int i = messageCount; i > 0; i--)
            {
                var message = client.GetMessage(i);
                // 处理邮件，可以获取主题、发件人、正文等信息
                Console.WriteLine($"Subject: {message.Headers.Subject}");
                Console.WriteLine($"From: {message.Headers.From}");
                Console.WriteLine($"Body: {message.MessagePart.GetBodyAsText()}");

                // 保存到收件箱
                SaveEmailToInbox(message.Headers.From.Address, Username, message.Headers.Subject, message.MessagePart.GetBodyAsText());
            }
        }
    }

    private void SaveEmailToInbox(string sender, string recipient, string subject, string body)
    {
        string insertEmailQuery = "INSERT INTO Inbox (Sender, Recipient, Subject, Body, DateTime) VALUES (@Sender, @Recipient, @Subject, @Body, @DateTime)";

        using (var connection = new SqlConnection(ConnectionString))
        {
            connection.Open();

            using (var command = new SqlCommand(insertEmailQuery, connection))
            {
                command.Parameters.AddWithValue("@Sender", sender);
                command.Parameters.AddWithValue("@Recipient", recipient);
                command.Parameters.AddWithValue("@Subject", subject);
                command.Parameters.AddWithValue("@Body", body);
                command.Parameters.AddWithValue("@DateTime", DateTime.Now);

                command.ExecuteNonQuery();
            }
        }
    }

    private void SaveEmailToOutbox(string sender, string recipient, string subject, string body)
    {
        string insertEmailQuery = "INSERT INTO Outbox (Sender, Recipient, Subject, Body, DateTime) VALUES (@Sender, @Recipient, @Subject, @Body, @DateTime)";

        using (var connection = new SqlConnection(ConnectionString))
        {
            connection.Open();

            using (var command = new SqlCommand(insertEmailQuery, connection))
            {
                command.Parameters.AddWithValue("@Sender", sender);
                command.Parameters.AddWithValue("@Recipient", recipient);
                command.Parameters.AddWithValue("@Subject", subject);
                command.Parameters.AddWithValue("@Body", body);
                command.Parameters.AddWithValue("@DateTime", DateTime.Now);

                command.ExecuteNonQuery();
            }
        }
    }

    public void DeleteEmailFromInbox(int emailId)
    {
        string deleteEmailQuery = "DELETE FROM Inbox WHERE Id = @EmailId";

        using (var connection = new SqlConnection(ConnectionString))
        {
            connection.Open();

            using (var command = new SqlCommand(deleteEmailQuery, connection))
            {
                command.Parameters.AddWithValue("@EmailId", emailId);

                command.ExecuteNonQuery();
            }
        }
    }

    public void DeleteEmailFromOutbox(int emailId)
    {
        string deleteEmailQuery = "DELETE FROM Outbox WHERE Id = @EmailId";

        using (var connection = new SqlConnection(ConnectionString))
        {
            connection.Open();

            using (var command = new SqlCommand(deleteEmailQuery, connection))
            {
                command.Parameters.AddWithValue("@EmailId", emailId);

                command.ExecuteNonQuery();
            }
        }
    }
}


