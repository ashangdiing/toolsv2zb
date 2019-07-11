using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Util;

namespace queryRecord
{
   public class RecordDataBase
    {
      
        SqlDataReader sdr;
        public SqlConnection connection;
        public SqlCommand command; public List<RecordRow> listRecords;
       private void init(){
           connection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["Default"].ConnectionString);
           command = new SqlCommand();
           command.Connection = connection;
       }
       public List<String> getRecordTsids(String callID,string sql) {
           List<string> ltsid=new  List<string>();
           if (sql == null)
           {
               if(string.IsNullOrEmpty(callID))
                   return ltsid;
               sql = "select * from [Esunnet].[dbo].[TS_REC_LOG] where TS_CALL_ID ='" + callID + "' order by TS_START_TIME";
           }
           init();
           if (connection == null)
               return null;
           command.CommandText = sql;
           if (connection.State == System.Data.ConnectionState.Closed)
               connection.Open();
           sdr = command.ExecuteReader();
           if (!sdr.HasRows)
               return null;
           while (sdr.Read()) {
               ltsid.Add(sdr["TS_ID"].ToString());
           }
           return ltsid;
       }

       public List<RecordRow> getRecords(String sql){
            try
           {
           int temp = 0;
            init();
           RecordRow rr;
           if (connection== null)
               return null;
           command.CommandText = sql;
           if (connection.State == System.Data.ConnectionState.Closed)
               connection.Open();
           sdr = command.ExecuteReader();
           if (!sdr.HasRows)
               return null;
           listRecords = new List<RecordRow>();
           while(sdr.Read()){
               rr = new RecordRow();
               rr.numberCell.Value = sdr["rows"].ToString();
               rr.selectedCell.Selected = false;
               temp = Convert.ToInt32(sdr["TS_TYPE"].ToString());
               if(temp==0)
               rr.callTypeCell.Value = "呼入";
               else if (temp == 3)
                   rr.callTypeCell.Value = "呼出";
               else   rr.callTypeCell.Value = "呼出";
               rr.extCell.Value = sdr["TS_NUMBER"].ToString();
               rr.callerCell.Value = sdr["TS_CALLER"].ToString(); ;
               rr.calledCell.Value = sdr["TS_CALLED"].ToString(); ;
               rr.agentCell.Value = sdr["TS_AGENT_ID"].ToString(); ;
               rr.startTimeCell.Value = sdr["TS_START_TIME"].ToString(); ;
               rr.endTimeCell.Value = sdr["TS_END_TIME"].ToString(); ;
               rr.tallTimeCell.Value = sdr["talkTime"].ToString();
               Image downImage = Image.FromFile("Image/play.bmp");
               Image playImage = Image.FromFile("Image/down.bmp");
               rr.playCell.Value = downImage;
               rr.downCell.Value = playImage;
               rr.callidCell.Value = sdr["TS_CALL_ID"].ToString();
               rr.tsidCell.Value = sdr["TS_ID"].ToString();
               listRecords.Add(rr);
           }
           return listRecords;
           }
            catch (SqlException e)
            {
                return listRecords;
            }
                  finally
           {
               if (sdr!=null) sdr.Close();
               connection.Close();
           }
       }

       public int getTotalRecord(String sql){
           init();
           try
           {
               if (connection == null)
                   return -1;
               command.CommandText = sql;
               if (connection.State == System.Data.ConnectionState.Closed)
                   connection.Open();
               sdr = command.ExecuteReader();
               
               sdr.Read();
               return sdr.GetInt32(0);
           } catch(SqlException e){
               return -1;
           }
           finally
           {
               if (sdr!=null) sdr.Close();
               connection.Close();
           }
       } 


    }
}
