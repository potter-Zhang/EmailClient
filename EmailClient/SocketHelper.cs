using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;
using System.Net.Security;

namespace EmailClient
{
    public class SocketHelper
    {
        public static SslStream GetSocket(string server, int port)
        {
            IPHostEntry hostEntry = Dns.GetHostEntry(server);

            IPEndPoint ipe = new IPEndPoint(hostEntry.AddressList[0], port);
            Socket socket = new Socket(ipe.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            
            socket.Connect(ipe);
            SslStream secureStream = new SslStream(new NetworkStream(socket));
            secureStream.AuthenticateAsClient(server);
            if (!socket.Connected)
                throw new Exception("ERROR: socket connection failed");
            return secureStream;
        }
    }
}
