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
    public partial class LoginSettings : Form
    {
        DataTable Tab;
        public WorckerDBchat dBchat { get; private set; }
        public delegate void getDataUser(ManagerMyMesseg MyManager, PostMan MyPostMan);
        public getDataUser LogUser;
        public LoginSettings()
        {
            InitializeComponent();
            dBchat = new WorckerDBchat();   
        }
        private void LoginSettings_Load(object sender, EventArgs e)
        {
            Tab = dBchat.ListUser();
            if (Tab.Rows.Count == 0) { groupBoxLogin.Enabled = false; }
            else groupBoxLogin.Enabled = true;
        }

        private void tb_Password_TextChanged(object sender, EventArgs e)
        {
            if (tb_Password.Text.Length == 0) { btnLolg.Enabled = false; }
            else btnLolg.Enabled = true;
            if (tb_Password.Text.Length > 10) 
            {
                string str=tb_Password.Text;
                tb_Password.Text = "";
                for(int i=0;i<10;i++) { tb_Password.Text += str[i].ToString(); }  
            }
        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (textBox2.Text.Length == 0) { btn_NewUser.Enabled = false; }
            else btn_NewUser.Enabled = true;
            if (textBox2.Text.Length > 10)
            {
                string str = textBox2.Text;
                textBox2.Text = "";
                for (int i = 0; i < 10; i++) { textBox2.Text += str[i].ToString(); }
            }
        }

        private void btnLolg_Click(object sender, EventArgs e)
        {
            ManagerMyMesseg myMesseg=null;
            PostMan post=null;
            int port = new Random().Next(1024, 6000);
            foreach (DataRow row in Tab.Rows) 
            {
                if (tb_Login.Text == row[1].ToString()) 
                {
                    if (tb_Password.Text == dBchat.PasswordUser((int)row[0])) 
                    {
                        
                        myMesseg = new ManagerMyMesseg((int)row[0], row[1].ToString());
                        post = new PostMan("127.0.0.1",port);
                        
                        break;
                    }
                }
            }
            if (myMesseg != null) 
            {
                dBchat.StatusTheNet(myMesseg.MyId, "127.0.0.1", port);
                LogUser?.Invoke(myMesseg, post);
                Close();
            }
            else 
            {
                MessageBox.Show("Неверный логин или пароль!!!");
                myMesseg = null;post = null;
                tb_Login.Text = tb_Password.Text = "";
                tb_Login.Focus();
                LoginSettings_Load(sender, e);
            }
        }

        private void btn_NewUser_Click(object sender, EventArgs e)
        {
            Tab = dBchat.ListUser();
            int num = 0;
            foreach (DataRow row in Tab.Rows)
            {
                if (textBox1.Text == row[1].ToString())
                {
                    num++;
                    break;
                }
            }
            if (num == 0) 
            {
                dBchat.NewUser(textBox1.Text, textBox2.Text);
                MessageBox.Show("Пользователь зарегистрирован!!!");
                textBox1.Text = textBox2.Text = "";
                LoginSettings_Load(sender, e);
            }
            else 
            {
                MessageBox.Show("Логин уже занят!!!");
                textBox1.Text = textBox2.Text = "";
                LoginSettings_Load(sender, e);
            }
        }
    }
}
