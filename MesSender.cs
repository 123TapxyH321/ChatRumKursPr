using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class MesSender
    {
        Socket MySender;
        IPEndPoint AddresServ;
        public MesSender(string strAddresIp,int port) 
        {
            AddresServ = new IPEndPoint(IPAddress.Parse(strAddresIp), port);
        }
        public void SendMessage(string str) 
        {
            MySender = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.IP);
            MySender.Connect(AddresServ);
            if (MySender.Connected) 
            { 
                MySender.Send(Encoding.Unicode.GetBytes(str));
                MySender.Close();
            }
        }
    }
}
