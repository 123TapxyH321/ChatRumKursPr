using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class ManagerMyMesseg
    {
        public delegate void showMess(string str);
        public showMess ShowNewMess;//делегат для передачи на средства отображения 
         
        public delegate void sendMyMess(string IpAdd, int port, string messeg);
        public sendMyMess newMess;//для отправки абонненту
        public int MyId { get; private set; }//id в бд
        public string MyLogin { get; private set; }//логин в бд
        public List<Recipient> ListAbonent { get; private set; }//список абонентов
        WorckerDBchat conDBchat;//связь с бд
        public ManagerMyMesseg(int Id,string login) 
        {
            MyId = Id;
            MyLogin = login;
            ListAbonent = new List<Recipient>();
            conDBchat = new WorckerDBchat();
        }
        //создание/обновление списка абонентов
        public void createListAbonent() 
        {
            DataTable listAb = conDBchat.ListUser();
            DataTable listMes = conDBchat.GetMyMesseg(MyId);
            if (ListAbonent.Count == 0) 
            { 
                foreach(DataRow row in listAb.Rows) 
                {
                    if((int)row[0]!=MyId) ListAbonent.Add(new Recipient((int)row[0], row[1].ToString()));
                }
                for(int i=0;i<ListAbonent.Count;i++) 
                {
                    foreach (DataRow row in listMes.Rows)
                    {
                        if (ListAbonent[i].IdRecip == (int)row[0]) { ListAbonent[i].ResivMesseg(ListAbonent[i].NameRecip +"\n"+ row[1].ToString()); }
                    }
                }

            }
            else if (ListAbonent.Count < (listAb.Rows.Count-1)) 
            {
                foreach (DataRow row in listAb.Rows)
                {
                    if((int)row[0]!=MyId)
                    {
                        int flag = 0;
                        foreach (Recipient Rec in ListAbonent)
                        {
                            if ((int)row[0] == Rec.IdRecip) { flag++; }
                        }
                        if (flag == 0) { ListAbonent.Add(new Recipient((int)row[0], row[1].ToString())); }
                    }
                }
                if(listMes.Rows.Count!=0)
                {
                    for (int i = 0; i < ListAbonent.Count; i++)
                    {
                        foreach (DataRow row in listMes.Rows)
                        {
                            if (ListAbonent[i].IdRecip == (int)row[0]) { ListAbonent[i].ResivMesseg(ListAbonent[i].NameRecip + "\n" + row[1].ToString()); }
                        }
                    }
                }
            }
            else if (listMes.Rows.Count != 0)
            {
                for (int i = 0; i < ListAbonent.Count; i++)
                {
                    foreach (DataRow row in listMes.Rows)
                    {
                        if (ListAbonent[i].IdRecip == (int)row[0]) { ListAbonent[i].ResivMesseg(ListAbonent[i].NameRecip + "\n" + row[1].ToString()); }
                    }
                }
            }
        }
        //получение нового сообщения
        public void RecivNewMesseg(string messeg) 
        {
            //парсим
            string[] MasStr = messeg.Split('^');
            int i;
            for(i=0;i<ListAbonent.Count;i++) 
            {
                //находим отправителя
                if (ListAbonent[i].IdRecip == int.Parse(MasStr[0])) 
                {
                    //проверка активного чата
                    if (ListAbonent[i].Statys) 
                    {
                        ListAbonent[i].ResivMesseg(ListAbonent[i].NameRecip+"-"+MasStr[1]);
                        ShowNewMess?.Invoke(ListAbonent[i].NameRecip + "-" + MasStr[1]);
                    }
                    else 
                    {
                        ListAbonent[i].ResivMesseg(ListAbonent[i].NameRecip + "-" + MasStr[1]);
                    }
                    break;
                }
            }
            if (i == ListAbonent.Count) 
            {
                createListAbonent();
                RecivNewMesseg(messeg);
            }
        }
        //отправка сообщения
        public void SendNewMesseg(string messeg) 
        {
            for(int i = 0; i < ListAbonent.Count; i++) 
            {
                if (ListAbonent[i].Statys) 
                {
                    DataTable tab = conDBchat.getAbonentData(ListAbonent[i].IdRecip);
                    if ((bool)tab.Rows[0][0]) 
                    {
                        newMess?.Invoke(tab.Rows[0][1].ToString(), (int)tab.Rows[0][2],
                            MyId.ToString() + "^" + messeg);
                    }
                    else 
                    {
                        conDBchat.SeveMyMesseg(MyId, ListAbonent[i].IdRecip, messeg);
                    }
                    ListAbonent[i].ResivMesseg(MyLogin + "-" + messeg);
                    ShowNewMess?.Invoke(MyLogin + "-" + messeg);
                    break;
                }
            }
        }
    }
}
