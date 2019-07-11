using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;

namespace checkMusic.Record
{
    class Record
    {
        SqlDataReader recordsSDR; int id = 0; string recordUrl = ""; public CheckWavFile cwf; public bool isUpdate = false; public int musicTimeOnSite = 0;
       
        public void updateRecordSql() {

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
                //  command.Parameters.Add(new SqlParameter("isRead", isRead));
               // tools.log.Debug("更新：1" + id);
                if(isUpdate)
                command.CommandText = " update [Esunnet].[dbo].[TS_REC_LOG]   set TS_ADMIN_AGENT_FLAG=1 where TS_ID=@id";
                else command.CommandText = " update [Esunnet].[dbo].[TS_REC_LOG]   set TS_ADMIN_AGENT_FLAG=3 where TS_ID=@id";
                command.ExecuteNonQuery();

               // tools.log.Debug("更新up：" + id);

            }
            catch (Exception ex)
            {
                tools.log.Debug("updateRecordSql异常:" + ex.ToString());
            }
            finally
            {
                tools.log.Debug("更新recordID："+id +" time:"+ musicTimeOnSite);
                if (command != null)
                    command.Dispose();
                if (connection != null) connection.Dispose();
                 
            }
        }
       
        public void readRecordSql() {
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

              //  command.CommandText = " SELECT  * from (SELECT row_number() over(order by id desc ) as num,id,number as phone,message,case  state  when '0' then '发送' when '1' then '接收'  end as state,datetime as dateTime,isRead  from SMS ) temp where num between  @begin and @end";
                command.CommandText = "SELECT TOP 100 TS_ID,TS_CALL_ID,TS_FILE_URL FROM [Esunnet].[dbo].[TS_REC_LOG]  where TS_END_TIME>TS_START_TIME and TS_ADMIN_AGENT_FLAG is  null  order by TS_START_TIME  desc";
                // command.CommandText = "SELECT TOP 100 TS_ID,TS_CALL_ID,TS_FILE_URL FROM [Esunnet].[dbo].[TS_REC_LOG]  where  TS_END_TIME>TS_START_TIME and TS_ADMIN_AGENT_FLAG=0 order by TS_START_TIME  desc";
              
                recordsSDR = command.ExecuteReader();
                if (!recordsSDR.HasRows) { return; }
              //  tools.log.Debug("<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<");
                while (recordsSDR.Read()) {
                    if (!recordsSDR.HasRows) { return; }
                     id = Convert.ToInt32(recordsSDR["TS_ID"]);
                     recordUrl =recordsSDR["TS_FILE_URL"].ToString();
                          isUpdate= isUseful();
                        //  tools.log.Debug("---+++++-");
                         updateRecordSql();
                        // tools.log.Debug("----------");
                }
               // tools.log.Debug(">>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>");
            }
            catch (Exception ex)
            {
                tools.log.Debug("readRecordSql异常：" + ex.ToString());
            }
            finally
            {
                if (command != null)
                    command.Dispose();
                if (connection != null) connection.Dispose();
            }
        }
        public bool isUseful() {
           // return true;
          
            if (recordUrl.IndexOf(".wav") < 0)
                return false;
        //    tools.log.Debug("id" + id + " 路径1" + recordUrl);
          //  tools.log.Debug("id" + recordUrl.Length + " 索引1: " + recordUrl.LastIndexOf("ecord"));
             string RU = recordUrl.Substring(recordUrl.LastIndexOf("ecord") + 5);  //record          
           // string RU = recordUrl.Substring(recordUrl.LastIndexOf("ecord") +8);    //recordwav       
            RU = getProperty.getRecordPath()+RU;
            tools.log.Debug("recordid:" + id + " 路径:" + RU);
            if (!new FileInfo(RU).Exists)
                return false;
            
            cwf = new CheckWavFile();
            bool temp=cwf.isUseful(RU);
            musicTimeOnSite = (int)cwf.wi.Second;
            return temp;
        }
    }
}
