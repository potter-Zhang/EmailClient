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
    // Created by little_prince
    public class SmtpClient
    {
        private SslStream _secureSocket;
        //private Socket _socket;
        private byte[] _buffer;
     
        private string _server;
        private int _port;
        private const string _endLine = "\r\n";

        //2976857809@qq.com
        //2976857809@qq.com

        public SmtpClient(string server, int port) 
        {
           
            _buffer = new byte[256];
        
            _server = server;
            _port = port;
                
           
          
        }

        private string Base64Encode(string s)
        {
            byte[] bytes = Encoding.Default.GetBytes(s);
            return Convert.ToBase64String(bytes);
        }

        public void Connect(string emailAddress, string password)
        {
            _secureSocket = SocketHelper.GetSocket(_server, _port);//("smtp.qq.com", 465);
            SendCommand("EHLO EmailService");
            ReceiveResponse();

            SendCommand("AUTH PLAIN " + Base64Encode("\0" + emailAddress + "\0" + password));
            ReceiveResponse();
            
       
        }

        public void Disconnect()
        {
            SendCommand("QUIT");
            ReceiveResponse();
            _secureSocket.Close();
        }

        public string SendEmail(string from, string password, string to, string subject, string text)
        {
            
            Connect(from, password);
            SendCommand("MAIL FROM:<" + from + ">");
            ReceiveResponse();
            SendCommand("RCPT TO:<" + to + ">");
            ReceiveResponse();
            SendCommand("DATA");
            ReceiveResponse();
            string dateTime = DateTime.Now.ToString("ddd, dd MMM yyyy HH:mm:ss zz00", new System.Globalization.CultureInfo("en-us"));
            SendCommand(
                Email.Construct(dateTime,
                from,
                to,
                subject,
                text
                ));
            SendCommand(".");
            ReceiveResponse();
            SendCommand("QUIT");
            ReceiveResponse();
            return dateTime;
        }


        private void SendCommand(string cmd)
        {
            cmd += _endLine;
            byte[] bytes = Encoding.UTF8.GetBytes(cmd);
            _secureSocket.Write(bytes);

        }

        private void ReceiveResponse()
        {
            int numBytes = _secureSocket.Read(_buffer);
            string response = Encoding.UTF8.GetString(_buffer, 0, numBytes);
            if (response[0] >= '4')
                throw new Exception($"smtp error: {response}");
        }
    }

   
}
