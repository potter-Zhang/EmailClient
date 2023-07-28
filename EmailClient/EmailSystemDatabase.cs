/*

using System;
using System.Data.SqlClient;
using System.Net;
using System.Net.Mail;
using OpenPop.Pop3;

public class EmailSystem : IDisposable
{
    private const string SmtpServer = "smtp.qq.com";
    private const int SmtpPort = 587;
    private const string Pop3Server = "pop.qq.com";
    private const int Pop3Port = 995;
    private const string Username = "your_qq_email@qq.com";
    private const string Password = "your_password";
    private const string ConnectionString = "Data Source=/Email.sql;Initial Catalog=EmailSystemDB;Integrated Security=True";
	private readonly string _connectionString;

    public void RegisterUser(string username, string password)
    {
        string insertUserQuery = "INSERT INTO Users (Username, Password) VALUES (@Username, @Password)";

        using (var connection = new SQLiteConnection(ConnectionString))
        {
            connection.Open();

            using (var command = new SQLiteCommand(insertUserQuery, connection))
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

        using (var connection = new SQLiteConnection(ConnectionString))
        {
            connection.Open();

            using (var command = new SQLiteCommand(selectUserQuery, connection))
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
    using (var connection = new SQLiteConnection(ConnectionString))
    {
        connection.Open();
        // Check if email with the given id already exists in the Inbox table
        using (var checkCommand = new SQLiteCommand(checkEmailExistsQuery, connection))
        {
            checkCommand.Parameters.AddWithValue("@Id", id);

            int count = (int)checkCommand.ExecuteScalar();

            if (count > 0)
            {
                return;
            }
        }
        using (var insertCommand = new SQLiteCommand(insertEmailQuery, connection))
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

        using (var connection = new SQLiteConnection(ConnectionString))
        {
            connection.Open();

            using (var command = new SQLiteCommand(insertEmailQuery, connection))
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

            using (var command = new SQLiteCommand(deleteEmailQuery, connection))
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

            using (var command = new SQLiteCommand(deleteEmailQuery, connection))
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

            using (var command = new SQLiteCommand(selectEmailsQuery, connection))
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

            using (var command = new SQLiteCommand(selectEmailsQuery, connection))
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

            using (var command = new SQLiteCommand(selectEmailQuery, connection))
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
    public void Dispose()
    {
     //这里可做任何需要的逻辑清理包括关闭数据库的连接，保证了pop3Client 中代码的正确运行
    }
    // 添加接受 connectionString 参数的构造函数
    public EmailSystem(string connectionString)
    {
        _connectionString = connectionString;
    }
    
}


*/

using System;
using System.Data.SqlClient;
using System.Net;
using System.Net.Mail;
using System.Data.SQLite;
using System.IO;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Tab;


namespace EmailClient
{
    public class EmailSystem : IDisposable
    {

        private string ConnectionString = "Data Source=C:\\Users\\Harry\\Desktop\\test.db;Version=3;";//"Data Source=/Email.sql;Initial Catalog=EmailSystemDB;Integrated Security=True";
        private readonly string _connectionString;
        public void RegisterUser(string username, string password)
        {
            string insertUserQuery = "INSERT INTO Users (Username, Password) VALUES (@Username, @Password)";
            //string path = Environment.CurrentDirectory + @"/Data/";
            using (var connection = new SQLiteConnection(ConnectionString))
            {
                connection.Open();

                using (var command = new SQLiteCommand(insertUserQuery, connection))
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

            using (var connection = new SQLiteConnection(ConnectionString))
            {
                connection.Open();

                using (var command = new SQLiteCommand(selectUserQuery, connection))
                {
                    command.Parameters.AddWithValue("@Username", username);
                    command.Parameters.AddWithValue("@Password", password);

                    int count = (int)command.ExecuteScalar();
                    return count > 0;
                }
            }
        }


        public void CreateTables()
        {
            string createInbox = "CREATE TABLE IF NOT EXISTS Inbox (ID TEXT PRIMARY KEY, Sender TEXT, Recipient TEXT, Subject TEXT, Body TEXT, DateTime DATETIME);";
            string createOutbox = "CREATE TABLE IF NOT EXISTS Outbox (ID INTEGER PRIMARY KEY AUTOINCREMENT, Sender TEXT, Recipient TEXT, Subject TEXT, Body TEXT, DataTime DATETIME);";
            string createUsers = "CREATE TABLE IF NOT EXISTS Users (Username TEXT NOT NULL, Password TEXT NOT NULL);";

            using (var connection = new SQLiteConnection(ConnectionString))
            {
                connection.Open();

                using (var command = new SQLiteCommand(createInbox, connection))
                {
                    command.ExecuteNonQuery();
                }

                using (var command = new SQLiteCommand(createOutbox, connection))
                {
                    command.ExecuteNonQuery();
                }

                using (var command = new SQLiteCommand(createUsers, connection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }
        /*
            public void SaveEmailToOutbox(string sender, string recipient, string subject, string body)
            {
                string insertEmailQuery = "INSERT INTO Outbox (Sender, Recipient, Subject, Body, DateTime) VALUES (@Sender, @Recipient, @Subject, @Body, @DateTime)";

                using (var connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();

                    using (var command = new SQLiteCommand(insertEmailQuery, connection))
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
        */
        public void SaveEmailToInbox(string id, string sender, string recipient, string subject, string body, DateTime dateTime)
        {
            string insertEmailQuery = "INSERT INTO Inbox (Id, Sender, Recipient, Subject, Body, DateTime) VALUES (@Id, @Sender, @Recipient, @Subject, @Body, @DateTime)";

            using (var connection = new SQLiteConnection(ConnectionString))
            {
                connection.Open();

                using (var command = new SQLiteCommand(insertEmailQuery, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    command.Parameters.AddWithValue("@Sender", sender);
                    command.Parameters.AddWithValue("@Recipient", recipient);
                    command.Parameters.AddWithValue("@Subject", subject);
                    command.Parameters.AddWithValue("@Body", body);
                    command.Parameters.AddWithValue("@DateTime", dateTime);

                    command.ExecuteNonQuery();
                }
            }
        }
        public Email FindEmailById(string emailId)
        {
            string selectEmailQuery = "SELECT * FROM Inbox WHERE Id = @EmailId";

            using (var connection = new SQLiteConnection(ConnectionString))
            {
                connection.Open();

                using (var command = new SQLiteCommand(selectEmailQuery, connection))
                {
                    command.Parameters.AddWithValue("@EmailId", emailId);

                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            
                            string sender = reader.GetString(1);
                            string recipient = reader.GetString(2);
                            string subject = reader.GetString(3);
                            string body = reader.GetString(4);
                            DateTime dateTime = reader.GetDateTime(5);

                            return new Email(emailId, sender, recipient, dateTime.ToString("ddd, dd MMM yyyy HH:mm:ss zz00"), subject, body);
                            
                        }
                    }
                }
            }

            return null;
        }

        public List<Email> FindReceivedEmailsByUser(string userEmail)
        {
            string selectEmailsQuery = "SELECT Id, Sender, Subject, DateTime FROM Inbox WHERE Recipient = @UserEmail ORDER BY DateTime DESC";

            List<Email> emails = new List<Email>();

            using (var connection = new SQLiteConnection(ConnectionString))
            {
                connection.Open();

                using (var command = new SQLiteCommand(selectEmailsQuery, connection))
                {
                    command.Parameters.AddWithValue("@UserEmail", userEmail);

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string id = reader.GetString(0);
                            string sender = reader.GetString(1);
                            string subject = reader.GetString(2);
                            DateTime dateTime = reader.GetDateTime(3);

                            Email email = new Email(id, sender, userEmail, dateTime.ToString("ddd, dd MMM yyyy HH:mm:ss zz00"), subject, "");
                            emails.Add(email);
                        }
                    }
                }
            }

            return emails;
        }

        public void DeleteEmailFromInbox(string emailId)
        {
            string deleteEmailQuery = "DELETE FROM Inbox WHERE Id = @EmailId";

            using (var connection = new SQLiteConnection(ConnectionString))
            {
                connection.Open();

                using (var command = new SQLiteCommand(deleteEmailQuery, connection))
                {
                    command.Parameters.AddWithValue("@EmailId", emailId);

                    command.ExecuteNonQuery();
                }
            }
        }

        public void DeleteEmailFromOutbox(int emailId)
        {
            string deleteEmailQuery = "DELETE FROM Outbox WHERE Id = @EmailId";

            using (var connection = new SQLiteConnection(ConnectionString))
            {
                connection.Open();

                using (var command = new SQLiteCommand(deleteEmailQuery, connection))
                {
                    command.Parameters.AddWithValue("@EmailId", emailId);

                    command.ExecuteNonQuery();
                }
            }
        }
        public void Dispose()
        {
            //这里可做任何需要的逻辑清理包括关闭数据库的连接，保证了pop3Client 中代码的正确运行
        }
        // 添加接受 connectionString 参数的构造函数
        public EmailSystem()
        {
            string dbFile = Environment.CurrentDirectory + "\\Data\\EmailSystem.db";
            ConnectionString = "Data Source=" + dbFile + ";Version=3;";
            if (!Directory.Exists(Environment.CurrentDirectory + "\\Data"))
                Directory.CreateDirectory(Environment.CurrentDirectory + "\\Data");
            if (!File.Exists(dbFile))
                SQLiteConnection.CreateFile(dbFile);
        }


    }
}


