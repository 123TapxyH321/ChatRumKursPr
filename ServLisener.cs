using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class ServLisener
    {
        public int Port { get; private set; }
        public string MyAddress { get; private set; }
        Socket Lisener;
        public delegate void StrParser(string strMes);
        public StrParser MyParser;
        public ServLisener(string str,int num) 
        {
            Port = num;
            MyAddress = str;
        }
        void MyAcceptCallbakFunction(IAsyncResult ia)
        {
            //получаем ссылку на слушающий сокет
            Socket socket = (Socket)ia.AsyncState;
            //получаем сокет для обмена данными с клиентом
            Socket ns = socket.EndAccept(ia);
            //выводим в консоль информацию о подключении
            Console.WriteLine(ns.RemoteEndPoint.ToString());
            //отправляем клиенту текущщее время асинхронно,
            //по завершении операции отправки будет 
            byte[] recivBufer = new byte[256];
            do
            {
                ns.Receive(recivBufer);
            } while (ns.Available > 0);
            ns.Shutdown(SocketShutdown.Send);
            ns.Close();
            if (recivBufer.Length != 0) 
            {
                MyParser?.Invoke(Encoding.Unicode.GetString(recivBufer));
            }
            //возобновляем асинхронный Accept
            socket.BeginAccept(new
            AsyncCallback(MyAcceptCallbakFunction),
            socket);
        } 
        public void StartServer()
        {
            if (Lisener != null)
                return;
            Lisener = new Socket(AddressFamily.InterNetwork,
            SocketType.Stream,
            ProtocolType.IP);
            Lisener.Bind(new IPEndPoint(IPAddress.Parse(MyAddress),Port));
            Lisener.Listen(10);
            //начинаем асинхронный Accept, при подключении
            //клиента вызовется обработчик 
            //MyAcceptCallbakFunction
            Lisener.BeginAccept(new AsyncCallback
            (MyAcceptCallbakFunction),
            Lisener);
        }
    }
}
