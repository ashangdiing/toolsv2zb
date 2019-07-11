using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace System.Util
{
   public  class DataBase
    {
        SqlDataReader sdr;
        public  SqlConnection connection;
        public  SqlCommand command;
        private static string dataBaeIP,user,passWord,dataBase;
        public DataBase(string dataBaeIP,string dataBase,string user,string passWord) {
            DataBase.dataBaeIP = dataBaeIP;
            DataBase.dataBase = dataBase;
            DataBase.user = user;
            DataBase.passWord = passWord;

           


        }
        public DataBase() { }
        public bool init (){
            try
            {
                connection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["Default"].ConnectionString);
               // connection = new SqlConnection("server=" + dataBaeIP + ";uid=" + user + ";pwd=" + passWord + ";database=" + dataBase);
                command = new SqlCommand();
                command.Connection = connection;
            }
            catch {
                return false;
            }
            return true;
        }
        public static  SqlConnection getConnect()
        {
          
          //return   new SqlConnection("server=" + dataBaeIP + ";uid=" + user + ";pwd=" + passWord + ";database=" + dataBase);
            return new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["Default"].ConnectionString);
        }

        public SqlDataReader queryData(string sql)
        {
            command.CommandText = sql;
            if (connection.State == System.Data.ConnectionState.Closed)
            connection.Open();    
             sdr=command.ExecuteReader();
             //command.ExecuteNonQuery();
            return sdr;
        }
        public void closeDataBase() {
            sdr.Close();
            connection.Close();

        }
    }
}
