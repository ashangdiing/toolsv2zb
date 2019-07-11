using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
//
//STATUS=0 表示未更新过 1  更新并可用  3 更新不可用
//
namespace checkMusic.Leave
{
    class Leave
    {
        SqlDataReader LeaveSDR; int id = 0; string fileName = ""; public CheckWavFile cwf;public int musicTimeOnSite;
        bool isUpdate=false;
        public void readLeaveSql()
        {
         //   test();
            SqlConnection connection = null;
            SqlCommand command = null;
            //  connection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["Default"].ConnectionString);

            try
            {
                connection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["Default"].ConnectionString);
                connection.Open();
                command = new SqlCommand();
                command.Connection = connection;
                //  command.Parameters.Add(new SqlParameter("begin", begin));
                //  command.Parameters.Add(new SqlParameter("end", end));
        // command.CommandText = "SELECT TOP 100 ID,FILENAME FROM [Esunnet].[dbo].[Record]  where RECDATE>DATEADD(ss,-1200,GETDATE()) and STATUS=0 order by RECDATE  desc";
                command.CommandText = "SELECT TOP 100 ID,FILENAME FROM [Esunnet].[dbo].[Record]  where  STATUS=0 order by RECDATE  desc";
              
                LeaveSDR = command.ExecuteReader();
                if (!LeaveSDR.HasRows) { return; }
                while (LeaveSDR.Read())
                {
                    if (!LeaveSDR.HasRows) { return; }
                    id = Convert.ToInt32(LeaveSDR["ID"]);
                    fileName = LeaveSDR["FILENAME"].ToString();
                   // updateLeaveSql();

                    isUpdate = isUseful();                   
                        updateLeaveSql();
                    
                }
            }
            catch (Exception ex)
            {
                tools.log.Debug(ex.ToString());
            }
            finally
            {
                if (command != null)
                    command.Dispose();
                if (connection != null) connection.Dispose();
            }
        }



        public void updateLeaveSql()
        {

            SqlConnection connection = null;
            SqlCommand command = null;
            try
            {
                //   SqlConnection connection = new SqlConnection("server= 127.0.0.1;uid=sa;pwd=esun5005;database=crmrun");
                connection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["Default"].ConnectionString);
                connection.Open();
                command = new SqlCommand();
                command.Connection = connection;
                command.Parameters.Add(new SqlParameter("id", id));
                command.Parameters.Add(new SqlParameter("musicTimeOnSite", musicTimeOnSite));
                 if(isUpdate)
                command.CommandText = " update [Esunnet].[dbo].[Record]  set STATUS=1,FILESIZE=@musicTimeOnSite where ID=@id";
                 else command.CommandText = " update [Esunnet].[dbo].[Record]  set STATUS=3,FILESIZE=@musicTimeOnSite where ID=@id";
                command.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                tools.log.Debug(ex.ToString());
            }
            finally
            {
                if (command != null)
                    command.Dispose();
                if (connection != null) connection.Dispose();
                tools.log.Debug("更新LeaveID：" + id+":time:"+musicTimeOnSite);
            }
        }


        public bool isUseful()
        {

           // musicTimeOnSite = 1;
            // return true;
           // tools.log.Debug(RU);
            if (fileName.IndexOf(".wav") < 0)
                return false;
            string RU = getProperty.getLeavePath() +"\\"+ fileName;
               tools.log.Debug("leaveid:"+id+"  路径:"+RU);
              
               if (!new FileInfo(RU).Exists)
                   return false;
            cwf = new CheckWavFile();
           bool isUseFul= cwf.isUseful(RU);
           musicTimeOnSite = cwf.getMusicTime();
          //  tools.log.Debug("秒"+musicTimeOnSite);
           if (!isUseFul) return isUseFul;
         
       //    tools.log.Debug("秒---"+musicTimeOnSite);
           return isUseFul;
        }

        public void  test()
        {

            // musicTimeOnSite = 1;
            // return true;
            // tools.log.Debug(RU);
            string RU = getProperty.getLeavePath();
            tools.log.Debug("路径" + RU);
            //  tools.log.Debug(RU);
            
            foreach (FileInfo fi in new DirectoryInfo(RU).GetFiles())
            {
                cwf = new CheckWavFile();
                cwf.isUseful(fi.FullName);
               
                musicTimeOnSite = cwf.getMusicTime();
             //   tools.log.Debug("秒" + musicTimeOnSite);
            }
           
         
        }

    }
}
