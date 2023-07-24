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


namespace EmailClient
{
    public class Pop3Client
    {
        //private TcpClient _client; // TcpClient 类型的字段，用于建立与服务器的 TCP 连接
        private SslStream _stream; //NetworkStream 类型的字段，用于通过 TCP 连接进行数据读写
        private byte[] _buffer;//用于存储从服务器接收到的数据

        public Pop3Client(string server, int port)
        {
            //_client = new TcpClient(server, port);//表示pop3服务器地址和端口号
            _stream = SocketHelper.GetSocket("pop.qq.com", 995);//通过网络完成与服务器之间的
            _buffer = new byte[4096];//小缓冲区存储数据

            // 阅读服务器消息
            ReadResponse();
        }

        public void Connect(string emailAddress, string password)
        {
            SendCommand("USER " + emailAddress);
            ReadResponse();
            SendCommand("PASS " + password);
            ReadResponse();
            // 检查是否成功登陆
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
            for (int i = 1; i <= numEmails; i++)
            {
                SendCommand("RETR " + i); // 按下标索引检索邮件
                emails.Add(ReadResponse());
            }

            return emails;//获取到所有的邮件内容存储到emails中以供使用
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
                responseBuilder.Append(Encoding.ASCII.GetString(_buffer, 0, bytesRead));

            } while (bytesRead == 4096);
           

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

        public MyPop3Client(string pop3Address, int pop3Port, string emailAddress, string emailPassword)
        {
            _pop3Address = pop3Address;
            _pop3Port = pop3Port;
            _emailAddress = emailAddress;
            _emailPassword = emailPassword;
        }

        /*     public List<string> GetEmails()
             {
                 using (var pop3Client = new Pop3Client(_pop3Address, _pop3Port))
                 {
                     pop3Client.Connect(_emailAddress, _emailPassword);//验证登录pop3服务器
                     return pop3Client.GetEmails();
                 }
             }存储到列表LIst中将获得的内容
        */

    }


    /*
    class Program
    {
        static void Main(string[] args)
        {
            string pop3Address = "pop.qq.com";//连接服务器
            int pop3Port = 995;//端口号
            string emailAddress = "email@qq.com";
            string emailPassword = "password";

            MyPop3Client client = new MyPop3Client(pop3Address, pop3Port, emailAddress, emailPassword);
         //连接服务器代码

            List<string> emails = client.GetEmails();
            foreach (string email in emails)
            {
                Console.WriteLine(email);
                //直接输出文件内容，也可以在此处改为存储文件内容到数据库中
            }

            Console.WriteLine("Done");//结束
        }
    }
    */
}
