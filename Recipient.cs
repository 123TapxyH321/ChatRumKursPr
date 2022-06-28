using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Recipient
    {

        public int IdRecip { get; private set; }//Id в бд
        public string NameRecip { get; private set; }//логин в бд
        public bool Statys { get; set; }//активный чат
        public delegate void getInfoMes(string str);
        public getInfoMes infoMes;
        int CountNewMes;
        List<string> MessegList;//хранение активной переписки
        public Recipient(int num,string Name) 
        {
            MessegList = new List<string>();
            IdRecip = num;
            NameRecip = Name;
            CountNewMes = 0;
            Statys = false;
        }
        public List<string> getMyMesList() 
        {
            if (CountNewMes != 0) { CountNewMes = 0; }
            return MessegList; 
        }
        //запись нового сообшения
        public void ResivMesseg(string messeg) 
        {
            if (Statys) { MessegList.Add(messeg); }
            else 
            {
                MessegList.Add(messeg);
                CountNewMes++;
                infoMes?.Invoke(NameRecip + "-" + CountNewMes);
            }
        }
    }
}
