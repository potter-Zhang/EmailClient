using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace EmailClient
{
    public class Email
    {
        public string sender;
        public string receiver;
        public string subject;
        public string body;
        string endLine = "\r\n";

        public Email(string from, string to, string subject, string body)
        {
            this.sender = from;
            this.receiver = to;   
            this.subject = subject;
            this.body = body;
        }

        private static string Base64Decode(string str)
        {
            try
            {
                byte[] bytes = Convert.FromBase64String(str);
                return Encoding.UTF8.GetString(bytes);
            }
            catch(Exception e)
            {
                return str;
            }
        }

        
        public static Email Parse(string email)
        {
            string from = Regex.Match(email, @"From:.*?<(?<from>.*?)>").Groups["from"].Value;
            if (from == "")
            {
                int a = 1;
            }
            string to = Regex.Match(email, @"To: (?<to>.*?)(\n|\r\n)").Groups["to"].Value;
            string emailSubject = Base64Decode(Regex.Match(email, @"Subject: =\?(?<charEncode>.*?)\?(?<byteEncode>.*?)\?(?<subject>.*?)\?=").Groups["subject"].Value);

            var bodies = Regex.Matches(email, @"Content-Type: text/plain;(.|\n|\r)*?charset=.*?(\n|\r\n)Content-Transfer-Encoding: base64(\n|\r\n){2}(?<body>(.|\n|\r\n)*)(\n|\r\n)\.(\n|\r\n)");
            string emailBody = string.Empty;
            foreach(Match body in bodies )
            {
                emailBody += Base64Decode(body.Groups["body"].Value) + "\r\n";
            }
            //string emailBody = Base64Decode(Regex.Match(email, @"\n\n(?<body>(.|\n)*)\n\.\n").Groups["body"].Value);
            return new Email(from, to, emailSubject, emailBody);
        }
    }
}
