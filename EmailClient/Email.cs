using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace EmailClient
{
    public class Email
    {
        public string sender;
        public string id;
        public string date;
        public string receiver;
        public string subject;
        public string body;
        //string endLine = "\r\n";

        public Email(string id, string sender, string receiver, string date, string subject, string body)
        {
            this.sender = sender;
            this.id = id;
            this.sender = sender;
            this.receiver = receiver;
            this.date = date;
            this.subject = subject;
            this.body = body;
        }

        public static DateTime String2DateTime(string dateStr)
        {
            //"ddd, dd MMM yyyy HH:mm:ss zz00"
            DateTime date;
            string format =  "ddd, dd MMM yyyy HH:mm:ss zz";
            try
            {
                date = DateTime.ParseExact(dateStr.Substring(0, format.Length + 1), format, System.Globalization.CultureInfo.InvariantCulture);
            }
            catch(FormatException fe)
            {
                date = DateTime.MinValue;
            }
            return date;
            
        }

        private static string Base64Decode(string str, Encoding encode)
        {
            try
            {
                byte[] bytes = Convert.FromBase64String(str);
                return encode.GetString(bytes);
                
            }
            catch(Exception e)
            {
                return str;
            }
        }

        private static string Base64Encode(string s)
        {
            byte[] bytes = Encoding.Default.GetBytes(s);
            return Convert.ToBase64String(bytes);
        }

        public static string Construct(string date, string from, string to, string subject, string body)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Date: ");
            sb.AppendLine(date);
            sb.Append("From: <");
            sb.AppendLine(from + ">");
            sb.Append("To: <");
            sb.AppendLine(to + ">");
            sb.Append("Subject: =?UTF-8?B?");
            sb.Append(Base64Encode(subject));
            sb.AppendLine("?=");
            sb.AppendLine("MIME-Version: 1.0");
            sb.AppendLine("Content-Type: text/plain; charset=UTF-8");
            sb.AppendLine("Content-Transfer-Encoding: base64");
            sb.AppendLine("");
            sb.AppendLine(Base64Encode(body));
            return sb.ToString();
        }

        
        public static Email Parse(string email)
        {
            string from = Regex.Match(email, @"From:.*?<(?<from>.*?)>").Groups["from"].Value;
          
            string to = Regex.Match(email, @"To:.*?<(?<to>.*?)>").Groups["to"].Value;
            var subjectMatch = Regex.Match(email, @"Subject: =\?(?<charEncode>.*?)\?(?<byteEncode>.*?)\?(\n|\r\n)?(?<subject>.*?)(\n|\r\n)?\?=");
            string charEncode = subjectMatch.Groups["charEncode"].Value.ToLower();
            string byteEncode = subjectMatch.Groups["byteEncode"].Value;
            string encodedSubject = subjectMatch.Groups["subject"].Value;
            Encoding encode = Encoding.UTF8;
            try
            {
                Encoding e = Encoding.GetEncoding(charEncode);
                encode = e;
            }
            catch (Exception e)
            { 
                
            }
            string emailSubject = Base64Decode(encodedSubject, encode);
            
            string date = Regex.Match(email, @"Date: (?<date>.*)").Groups["date"].Value;
            string id = Regex.Match(email, @"Message-ID: <(?<id>.*?)>").Groups["id"].Value;
            //string id = Regex.Match(email, @"");
            var bodies = Regex.Matches(email, @"Content-Type: text/plain;(.|\n|\r)*?charset=[""]?(?<encode>.*?)[""]?(\n|\r\n)Content-Transfer-Encoding: base64(\n|\r\n){2}(?<body>(.|\n|\r\n)*)(\n|\r\n)\.(\n|\r\n)");

            string emailBody = string.Empty;
            foreach(Match body in bodies )
            {
                Encoding encoding= Encoding.UTF8;
                try
                {
                    Encoding e = Encoding.GetEncoding(body.Groups["encode"].Value.ToLower());
                    encoding = e;
                }
                catch (Exception e)
                {

                }
                emailBody += Base64Decode(body.Groups["body"].Value, encoding) + "\r\n";
            }
            //string emailBody = Base64Decode(Regex.Match(email, @"\n\n(?<body>(.|\n)*)\n\.\n").Groups["body"].Value);
            return new Email(id, from, to, date, emailSubject, emailBody);
        }
    }
}
