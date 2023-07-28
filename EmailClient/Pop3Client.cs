using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Diagnostics;
using System.Net;
using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata;
using System.Runtime.InteropServices;
using System.Security.Cryptography.Xml;
using System.Net.Security;
using System.Net.Mail;
using System.Security.Cryptography.X509Certificates;



namespace EmailClient
{
    public class Pop3Client : IDisposable
    {
        //private TcpClient _client; // TcpClient 类型的字段，用于建立与服务器的 TCP 连接
        private SslStream _stream; //NetworkStream 类型的字段，用于通过 TCP 连接进行数据读写
        private byte[] _buffer;//用于存储从服务器接收到的数据
        private string _server;
        private int _port;
        private const int bufSize = 4096;        //private readonly EmailSystem _emailSystem;



        public Pop3Client(string server, int port/*, string connectionString*/)
        {
            //_client = new TcpClient(server, port);//表示pop3服务器地址和端口号
            //通过网络完成与服务器之间的
            _server = server;
            _port = port;
            _buffer = new byte[bufSize];//小缓冲区存储数据
            //_emailSystem = new EmailSystem(connectionString);

            // 阅读服务器消息
            
        }

        public void Connect(string emailAddress, string password)
        {
            _stream = SocketHelper.GetSocket(_server, _port);
            ReadResponse();
            SendCommand("USER " + emailAddress);
            ReadResponse();
            SendCommand("PASS " + password);
            ReadResponse();
            // 检查是否成功登陆
        }
        public int GetEmailNum()
        {
            SendCommand("STAT"); // 询问并获取邮箱中邮件数量
            string response = ReadResponse();//返回值存储
            string[] statResponse = response.Split(' ');
            //数组的第一个元素将是服务器响应中的状态码
            //第二个元素将是邮箱中的邮件数量。

            return int.Parse(statResponse[1]);//获取数量
        }

        public string GetEmail(int index)
        {
            if (index > GetEmailNum())
                return string.Empty;
            SendCommand("RETR " + index);
            return ReadResponse();  

        }

        public string GetId(int index)
        {
            
            SendCommand("UIDL " + index);
            string ans = ReadResponse();
            string[] ansResponse = ans.Split(" ");
            return ansResponse[2] + "@qq.com";
        }
        public List<string> GetEmails()//获取邮件类
        {
            SendCommand("STAT"); // 询问并获取邮箱中邮件数量
            string response = ReadResponse();//返回值存储
            string[] statResponse = response.Split(' ');
            //数组的第一个元素将是服务器响应中的状态码
            //第二个元素将是邮箱中的邮件数量。

            int numEmails = int.Parse(statResponse[1]);//获取数量
            List<string> emails = new List<string>();

            // 获取每封邮件
            for (int i = numEmails; i >= 1; i--)
            {
                SendCommand("LIST " + i);
                int size = int.Parse(ReadResponse().Split(" ")[2]);
                SendCommand("RETR " + i); // 按下标索引检索邮件
                emails.Add(ReadResponse());
            }

            return emails;//获取到所有的邮件内容存储到emails中以供使用
        }

        public void DeleteEmail(int emailIndex)//用DELE命令来标记需要删除的邮件，在quit后直接在服务器中删除
        {
            SendCommand("DELE " + emailIndex);
            ReadResponse();

            //_emailSystem.DeleteEmailFromInbox(emailIndex);
        }
        /// <summary>
        /// 此处做弹窗连接选择是否删除服务器中邮件
        /// </summary>



        public void Dispose()
        {
            // 在 Dispose 方法中释放资源，例如关闭与服务器的连接
            Disconnect();

            //_emailSystem.Dispose();
        }


        private void SendCommand(string cmd)//向服务器发送命令通信
        {
            cmd += "\r\n";
            byte[] bytes = Encoding.ASCII.GetBytes(cmd);
            _stream.Write(bytes, 0, bytes.Length);
        }

        

        private string ReadResponse()//响应数据，并将其读取为字符串
        {
            StringBuilder responseBuilder = new StringBuilder();
            int bytesRead;


            do
            {
                bytesRead = _stream.Read(_buffer);
                if (bytesRead == 0)
                    break;
                string s = Encoding.ASCII.GetString(_buffer, 0, bytesRead);
                
                responseBuilder.Append(Encoding.ASCII.GetString(_buffer, 0, bytesRead));

            } while (bytesRead == bufSize);


            return responseBuilder.ToString();
        }

        public void Disconnect()//断开连接
        {
            SendCommand("QUIT");
            _stream.Close();
        }
    }

    public class MyPop3Client
    {
        private readonly string _pop3Address;
        private readonly int _pop3Port;
        private readonly string _emailAddress;
        private readonly string _emailPassword;
        private readonly string _connectionString;

        public MyPop3Client(string pop3Address, int pop3Port, string emailAddress, string emailPassword, string connectionString)
        {
            _pop3Address = pop3Address;
            _pop3Port = pop3Port;
            _emailAddress = emailAddress;
            _emailPassword = emailPassword;
            _connectionString = connectionString;
        }

        public List<string> GetEmailsAndDeleteMarked()
        {
            var pop3Client = new Pop3Client(_pop3Address, _pop3Port);
            pop3Client.Connect(_emailAddress, _emailPassword); // 验证登录到pop3服务器
            List<string> emails = pop3Client.GetEmails(); // 获取邮件内容

            // 标记需要删除的邮件
            for (int i = 1; i <= emails.Count; i++)
            {
                pop3Client.DeleteEmail(i); // 使用DELE命令标记需要删除的邮件，并在数据库中删除
            }

            pop3Client.Dispose(); // 手动调用 Dispose() 方法释放资源

            return emails;
        }

        public void ViewEmails()
        {
            EmailSystem emailSystem = null;
            try
            {
                string connectionString = "Data Source=/Email.sql;Initial Catalog=EmailSystemDB;Integrated Security=True";
                emailSystem = new EmailSystem();
                // 假设 MyPop3Client 已知当前用户的邮箱地址和密码
                // string emailAddress = emailAddress;
                // string emailPassword = emailPassword;

                if (emailSystem.ValidateUser(_emailAddress, _emailPassword))
                {
                    // 登录成功，获取并查看邮件内容
                    List<string> emails = GetEmailsAndDeleteMarked();

                    // 输出邮件内容
                    foreach (string email in emails)
                    {
                        Console.WriteLine(email);
                    }
                }
                else
                {
                    Console.WriteLine("登录失败，请检查您的邮箱地址和密码。");
                }
            }
            finally
            {
                if (emailSystem != null)
                {
                    emailSystem.Dispose();
                }
            }
        }




    }





}
