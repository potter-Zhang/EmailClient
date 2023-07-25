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

private void SaveEmailToInbox(int id, string sender, string recipient, string subject, string body, DateTime dateTime)
{
    string checkEmailExistsQuery = "SELECT COUNT(*) FROM Inbox WHERE Id = @Id";
    string insertEmailQuery = "INSERT INTO Inbox (Id, Sender, Recipient, Subject, Body, DateTime) VALUES (@Id, @Sender, @Recipient, @Subject, @Body, @DateTime)";
    using (var connection = new SqlConnection(ConnectionString))
    {
        connection.Open();
        // Check if email with the given id already exists in the Inbox table
        using (var checkCommand = new SqlCommand(checkEmailExistsQuery, connection))
        {
            checkCommand.Parameters.AddWithValue("@Id", id);

            int count = (int)checkCommand.ExecuteScalar();

            if (count > 0)
            {
                return;
            }
        }
        using (var insertCommand = new SqlCommand(insertEmailQuery, connection))
        {
            insertCommand.Parameters.AddWithValue("@Id", id);
            insertCommand.Parameters.AddWithValue("@Sender", sender);
            insertCommand.Parameters.AddWithValue("@Recipient", recipient);
            insertCommand.Parameters.AddWithValue("@Subject", subject);
            insertCommand.Parameters.AddWithValue("@Body", body);
            insertCommand.Parameters.AddWithValue("@DateTime", dateTime);

            insertCommand.ExecuteNonQuery();
        }
    }
}

    private void SaveEmailToOutbox(string sender, string recipient, string subject, string body,DateTime dateTime)
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
                command.Parameters.AddWithValue("@DateTime", datatime);

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

    public List<Email> FindSentEmailsByUser(string userEmail)
    {
        string selectEmailsQuery = "SELECT Id, Recipient, Subject, DateTime FROM Outbox WHERE Sender = @UserEmail";

        List<Email> emails = new List<Email>();

        using (var connection = new SqlConnection(ConnectionString))
        {
            connection.Open();

            using (var command = new SqlCommand(selectEmailsQuery, connection))
            {
                command.Parameters.AddWithValue("@UserEmail", userEmail);

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int id = reader.GetInt32(0);
                        string recipient = reader.GetString(1);
                        string subject = reader.GetString(2);
                        DateTime dateTime = reader.GetDateTime(3);

                        Email email = new Email(id, recipient, subject, dateTime);
                        emails.Add(email);
                    }
                }
            }
        }

        return emails;
    }

    public List<Email> FindReceivedEmailsByUser(string userEmail)
    {
        string selectEmailsQuery = "SELECT Id, Sender, Subject, DateTime FROM Inbox WHERE Recipient = @UserEmail";

        List<Email> emails = new List<Email>();

        using (var connection = new SqlConnection(ConnectionString))
        {
            connection.Open();

            using (var command = new SqlCommand(selectEmailsQuery, connection))
            {
                command.Parameters.AddWithValue("@UserEmail", userEmail);

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int id = reader.GetInt32(0);
                        string sender = reader.GetString(1);
                        string subject = reader.GetString(2);
                        DateTime dateTime = reader.GetDateTime(3);

                        Email email = new Email(id, sender, subject, dateTime);
                        emails.Add(email);
                    }
                }
            }
        }

        return emails;
    }

    public Email FindEmailById(int emailId)
    {
        string selectEmailQuery = "SELECT Sender, Recipient, Subject, DateTime FROM Inbox WHERE Id = @EmailId";

        using (var connection = new SqlConnection(ConnectionString))
        {
            connection.Open();

            using (var command = new SqlCommand(selectEmailQuery, connection))
            {
                command.Parameters.AddWithValue("@EmailId", emailId);

                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        string sender = reader.GetString(0);
                        string recipient = reader.GetString(1);
                        string subject = reader.GetString(2);
                        DateTime dateTime = reader.GetDateTime(3);

                        return new Email(emailId, sender, recipient, subject, dateTime);
                    }
                }
            }
        }

        return null;
    }

    
}


