using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmailClient
{
    public class Attachment
    {
        string _path;
        static Dictionary<string, string> MimeTypes = new Dictionary<string, string> {
        { "***", "application/octet-stream" },
        { "csv",    "text/csv" },
        { "tsv",    "text/tab-separated-values" },
        { "tab",    "text/tab-separated-values" },
        { "html",    "text/html" },
        { "htm",    "text/html" },
        { "doc",    "application/msword" },
        { "docx",    "application/vnd.openxmlformats-officedocument.wordprocessingml.document" },
        { "ods",    "application/x-vnd.oasis.opendocument.spreadsheet" },
        { "odt",    "application/vnd.oasis.opendocument.text" },
        { "rtf",    "application/rtf" },
        { "sxw",    "application/vnd.sun.xml.writer" },
        { "txt",    "text/plain" },
        { "xls",    "application/vnd.ms-excel" },
        { "xlsx",    "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet" },
        { "pdf",    "application/pdf" },
        { "ppt",    "application/vnd.ms-powerpoint" },
        { "pps",    "application/vnd.ms-powerpoint" },
        { "pptx",    "application/vnd.openxmlformats-officedocument.presentationml.presentation" },
        { "wmf",    "image/x-wmf" },
        { "atom",    "application/atom+xml" },
        { "xml",    "application/xml" },
        { "json",    "application/json" },
        { "js",    "application/javascript" },
        { "ogg",    "application/ogg" },
        { "ps",    "application/postscript" },
        { "woff",    "application/x-woff" },
        { "xhtml","application/xhtml+xml" },
        { "xht",    "application/xhtml+xml" },
        { "zip",    "application/zip" },
        { "gz",    "application/x-gzip" },
        { "rar",    "application/rar" },
        { "rm",    "application/vnd.rn-realmedia" },
        { "rmvb",    "application/vnd.rn-realmedia-vbr" },
        { "swf",    "application/x-shockwave-flash" },
        { "au",        "audio/basic" },
        { "snd",    "audio/basic" },
        { "mid",    "audio/mid" },
        { "rmi",        "audio/mid" },
        { "mp3",    "audio/mpeg" },
        { "aif",    "audio/x-aiff" },
        { "aifc",    "audio/x-aiff" },
        { "aiff",    "audio/x-aiff" },
        { "m3u",    "audio/x-mpegurl" },
        { "ra",    "audio/vnd.rn-realaudio" },
        { "ram",    "audio/vnd.rn-realaudio" },
        { "wav",    "audio/x-wave" },
        { "wma",    "audio/x-ms-wma" },
        { "m4a",    "audio/x-m4a" },
        { "bmp",    "image/bmp" },
        { "gif",    "image/gif" },
        { "jpe",    "image/jpeg" },
        { "jpeg",    "image/jpeg" },
        { "jpg",    "image/jpeg" },
        { "jfif",    "image/jpeg" },
        { "png",    "image/png" },
        { "svg",    "image/svg+xml" },
        { "tif",    "image/tiff" },
        { "tiff",    "image/tiff" },
        { "ico",    "image/vnd.microsoft.icon" },
        { "css",    "text/css" },
        { "bas",    "text/plain" },
        { "c",        "text/plain" },
        { "h",        "text/plain" },
        { "rtx",    "text/richtext" },
        { "mp2",    "video/mpeg" },
        { "mpa",    "video/mpeg" },
        { "mpe",    "video/mpeg" },
        { "mpeg",    "video/mpeg" },
        { "mpg",    "video/mpeg" },
        { "mpv2",    "video/mpeg" },
        { "mov",    "video/quicktime" },
        { "qt",    "video/quicktime" },
        { "lsf",    "video/x-la-asf" },
        { "lsx",    "video/x-la-asf" },
        { "asf",    "video/x-ms-asf" },
        { "asr",    "video/x-ms-asf" },
        { "asx",    "video/x-ms-asf" },
        { "avi",    "video/x-msvideo" },
        { "3gp",    "video/3gpp" },
        { "3gpp",    "video/3gpp" },
        { "3g2",    "video/3gpp2" },
        { "movie","video/x-sgi-movie" },
        { "mp4",    "video/mp4" },
        { "wmv",    "video/x-ms-wmv" },
        { "webm","video/webm" },
        { "m4v",    "video/x-m4v" },
        { "flv",    "video/x-flv" }
    };

        public Attachment(string path)
        {
            _path = path;
        }

        public string FileBaseName()
        {
            return Path.GetFileNameWithoutExtension(_path);
        }

        public string FileExtension()
        {
            string ext = Path.GetExtension(_path);
            return ext.Substring(1, ext.Length - 1);
        }

        public string FileName()
        {
            return Path.GetFileName(_path);
        }

        public string FileContennt(out Encoding encode)
        {
            StreamReader sr = new StreamReader(_path, detectEncodingFromByteOrderMarks: true);

            string result = sr.ReadToEnd();
            encode = sr.CurrentEncoding;
            sr.Close();

            return result;
        }

        public string GetMIMEType()
        {
            string fileExtension = FileExtension();
            if (MimeTypes.ContainsKey(fileExtension))
                return MimeTypes[fileExtension];
            return MimeTypes["***"];
        }


    }
}
