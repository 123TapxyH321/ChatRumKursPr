using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConsoleApp1
{
    public partial class Form1 : Form
    {
        PostMan MypostMan;
        ManagerMyMesseg myChat;
        LoginSettings LogForm;
        DataTable TabUser;
        public Form1()
        {
            InitializeComponent();
            myChat = null;
            
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            if (myChat == null)
            {
                LogForm = new LoginSettings();
                LogForm.LogUser = CreateData;
                LogForm.ShowDialog();
                if(myChat!=null)
                {
                    myChat.createListAbonent();
                    MypostMan.MyRessiv = myChat.RecivNewMesseg;
                    myChat.ShowNewMess = ShowMessag;
                    myChat.newMess = MypostMan.MySendMessag;
                    this.Text += " - " + myChat.MyLogin;
                    Form1_Load(sender, e);
                }
                else { Close(); }
            }
            else
            {
                
                TabUser = null;
                TabUser = new DataTable();
                TabUser.Columns.Add("Id", typeof(int));
                TabUser.Columns.Add("NameUser", typeof(string));
                foreach (Recipient Res in myChat.ListAbonent)
                {
                    Res.infoMes = ShowInfoMess;
                    DataRow row = TabUser.NewRow();
                    row[0] = Res.IdRecip;
                    row[1] = Res.NameRecip;
                    TabUser.Rows.Add(row);
                }
                comBox_NameAbon.DataSource = TabUser;
                comBox_NameAbon.DisplayMember = "NameUser";
                comBox_NameAbon.ValueMember = "Id";


            }
        }
        void CreateData(ManagerMyMesseg data1,PostMan data2) 
        {
            myChat = data1;
            MypostMan = data2;
        }
        void ShowMessag(string str) { Lbox_Chat.Items.Add(str); }
        void ShowInfoMess(string str) { Lbox_InfoAbon.Items.Add(str); }
        private void comBox_NameAbon_SelectedIndexChanged(object sender, EventArgs e)
        {
            try 
            {
                int IdAbonent = (int)comBox_NameAbon.SelectedValue;
                if (myChat.ListAbonent.Count == comBox_NameAbon.Items.Count)
                {
                    Lbox_Chat.Items.Clear();
                    for (int i = 0; i < myChat.ListAbonent.Count; i++)
                    {
                        if (IdAbonent == myChat.ListAbonent[i].IdRecip)
                        {
                            myChat.ListAbonent[i].Statys = true;
                            foreach (string Str in myChat.ListAbonent[i].getMyMesList())
                            {
                                ShowMessag(Str);
                            }
                        }
                        else
                        {
                            myChat.ListAbonent[i].Statys = false;
                        }
                    }
                }
            }
            catch(Exception ex) 
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void btn_Send_Click(object sender, EventArgs e)
        {
            myChat.SendNewMesseg(tBox_MyMessag.Text);
            tBox_MyMessag.Text = "";
            tBox_MyMessag.Focus();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (myChat!=null) 
            {
                LogForm = new LoginSettings();
                LogForm.dBchat.StatusTheNet(myChat.MyId, "0", 0);
            }
        }
    }
}
