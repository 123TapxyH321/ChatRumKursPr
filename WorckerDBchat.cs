using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class WorckerDBchat
    {
        SqlConnection conn = null;
        SqlDataAdapter da = null;
        SqlCommand MyComm;
        public WorckerDBchat(string str)
        {
            conn = new SqlConnection();
            conn.ConnectionString = str;
        }
        public WorckerDBchat():this(@"Data Source=aleksandr\sqlexpress;Initial Catalog=ChatRumBD; Integrated Security=SSPI;") { }
        //public WorckerDBchat():this(@"Data Source=COM2-11\SQLEXPRESS;Initial Catalog=ChatRumBD; Integrated Security=SSPI;") { }
        //получение списка пользователей
        public DataTable ListUser() 
        {
            DataTable tab = new DataTable();
            try 
            {
                MyComm = new SqlCommand("SP_LictUser", conn);
                MyComm.CommandType = System.Data.CommandType.StoredProcedure;
                da = new SqlDataAdapter(MyComm);
                da.Fill(tab);
            }
            catch(Exception ex) 
            {
                Console.WriteLine(ex.Message);
            }
            return tab;
        }
        //данные об абонненте по Id(статус,айпи адресс,порт)
        public DataTable getAbonentData(int idUser)
        {
            DataTable tab = new DataTable();
            try
            {
                MyComm = new SqlCommand("SP_getAbonentData", conn);
                MyComm.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter Id = new SqlParameter
                {
                    ParameterName = "@idUser",
                    Value = idUser

                };
                MyComm.Parameters.Add(Id);
                da = new SqlDataAdapter(MyComm);
                da.Fill(tab);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return tab;
        }
        //очистка принятых сообщений
        void ClireMyMesseg(int idUser)
        {
            try
            {
                DataTable tab = new DataTable();
                MyComm = new SqlCommand("SP_ClireMyMesseg", conn);
                MyComm.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter Id = new SqlParameter
                {
                    ParameterName = "@idRecipUser",
                    Value = idUser

                };
                MyComm.Parameters.Add(Id);
                da = new SqlDataAdapter(MyComm);
                da.Fill(tab);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        //получение табл сообщение по двум айди(отправитель,получатель)
        public DataTable GetMyMesseg(int idRecipUser)
        {
            DataTable tab = new DataTable();
            try
            {
                MyComm = new SqlCommand("SP_GetMyMesseg", conn);
                MyComm.CommandType = System.Data.CommandType.StoredProcedure; 
                SqlParameter IdRecip = new SqlParameter
                {
                    ParameterName = "@idRecipUser",
                    Value = idRecipUser

                };
                MyComm.Parameters.Add(IdRecip);
                da = new SqlDataAdapter(MyComm);
                da.Fill(tab);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            //удоление сообщений в бд
            ClireMyMesseg(idRecipUser);
            return tab;
        }
        //новый пользователь
        public void NewUser(string name,string passw)
        {
            DataTable tab = new DataTable();
            try
            {
                MyComm = new SqlCommand("SP_NewUser", conn);
                MyComm.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter Name = new SqlParameter
                {
                    ParameterName = "@Name",
                    Value = name

                };
                MyComm.Parameters.Add(Name);
                SqlParameter Passw = new SqlParameter
                {
                    ParameterName = "@Password",
                    Value = passw

                };
                MyComm.Parameters.Add(Passw);
                da = new SqlDataAdapter(MyComm);
                da.Fill(tab);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
        }
        //пароль по Id
        public string PasswordUser(int idUser) 
        {
            string str="";
            try
            {
                DataTable rez=new DataTable();
                MyComm = new SqlCommand("SP_PasswordUser", conn);
                MyComm.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter Id = new SqlParameter
                {
                    ParameterName = "@idUser",
                    Value = idUser

                };
                MyComm.Parameters.Add(Id);
                //SqlParameter Passw = new SqlParameter
                //{
                //    ParameterName = "@password",
                //    SqlDbType = SqlDbType.NVarChar
                //};
                //Passw.Direction = ParameterDirection.Output;
                //MyComm.Parameters.Add(Passw);
                da = new SqlDataAdapter(MyComm);
                da.Fill(rez);
                //str = (string)MyComm.Parameters["@password"].Value;
                str = (string)rez.Rows[0][0];
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return str;  
        }
        //запись сообщения для оф абанента
        public void SeveMyMesseg(int idSendUser, int idRecipUser,string messeg)
        {
            DataTable tab = new DataTable();
            try
            {
                MyComm = new SqlCommand("SP_SeveMyMesseg", conn);
                MyComm.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter IdSend = new SqlParameter
                {
                    ParameterName = "@idSendUser",
                    Value = idSendUser

                };
                MyComm.Parameters.Add(IdSend);
                SqlParameter IdRecip = new SqlParameter
                {
                    ParameterName = "@idRecipUser",
                    Value = idRecipUser

                };
                MyComm.Parameters.Add(IdRecip);
                SqlParameter Messeg = new SqlParameter
                {
                    ParameterName = "@messeg",
                    Value = messeg

                };
                MyComm.Parameters.Add(Messeg);
                da = new SqlDataAdapter(MyComm);
                da.Fill(tab);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        //внесение изм в статус
        public void StatusTheNet(int idUser,string IpAddres, int port)
        {
            DataTable tab = new DataTable();
            try
            {
                MyComm = new SqlCommand("SP_StatusTheNet", conn);
                MyComm.CommandType = System.Data.CommandType.StoredProcedure;
                SqlParameter IdUser = new SqlParameter
                {
                    ParameterName = "@idUser",
                    Value = idUser

                };
                MyComm.Parameters.Add(IdUser);
                SqlParameter IpAdd = new SqlParameter
                {
                    ParameterName = "@IPAddres",
                    Value = IpAddres

                };
                MyComm.Parameters.Add(IpAdd);
                SqlParameter Port = new SqlParameter
                {
                    ParameterName = "@port",
                    Value = port

                };
                MyComm.Parameters.Add(Port);
                da = new SqlDataAdapter(MyComm);
                da.Fill(tab);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
