using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class PostMan
    {
        ServLisener servLisener;
        MesSender mesSender;
        public delegate void resivMessag(string Messeg);
        public resivMessag MyRessiv;
        public PostMan(string MyIpAddr,int MyPort) 
        {
            servLisener = new ServLisener(MyIpAddr, MyPort);
            servLisener.MyParser = getMyMessag;
            servLisener.StartServer();
        }
        //передача сообщения тем кто слушает
        public void getMyMessag(string str) { MyRessiv?.Invoke(str); }
        public void MySendMessag(string IpAdd,int port,string messeg) 
        {
            mesSender = new MesSender(IpAdd, port);
            mesSender.SendMessage(messeg);
        }

    }
}
