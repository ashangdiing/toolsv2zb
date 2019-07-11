using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace testTools
{
    public class UpdateOutCall
    {
        public UpdateOutCall(string calledNumber, string startTimep, string planTimep, string timeOutTimep, int timesp, string IVRUrl)
        {
            DateTime startTime = DateTime.Now, planTime = DateTime.Now; string timeOutTime; int times = 10;
           
            if (string.IsNullOrEmpty(calledNumber))
                return;
            if (string.IsNullOrEmpty(IVRUrl))
                IVRUrl = ConfigurationManager.AppSettings["IVRUrl"]; ; 
            if (!string.IsNullOrEmpty(startTimep))
                startTime= Convert.ToDateTime(startTimep);
            if (!string.IsNullOrEmpty(planTimep))
             planTime=Convert.ToDateTime(planTimep);
            if (timesp>1)
                times =timesp;

            updateCallOutSql(calledNumber, startTime, planTime, times, IVRUrl);
        }


        public void updateCallOutSql(string calledNumber, DateTime startTimep, DateTime planTimep, int timesp,string IVRUrl)
        {
            SqlConnection connection = null;
            SqlCommand command = null;
            try
            {
                connection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["Default"].ConnectionString);
                connection.Open();
                command = new SqlCommand();
                command.Connection = connection;
                command.Parameters.Add(new SqlParameter("@calledNumber", calledNumber));
                command.Parameters.Add(new SqlParameter("@startTimep", startTimep));
                command.Parameters.Add(new SqlParameter("@planTimep", planTimep));
                command.Parameters.Add(new SqlParameter("@timesp", timesp));
                command.Parameters.Add(new SqlParameter("@IVRUrl", IVRUrl));
                // tools.log.Debug("更新：1" + id);
                    command.CommandText = "INSERT INTO [TS_CALLOUT] ([TS_TASK_ID],[TS_TYPE],[TS_CALLED],[TS_URL],[TS_START_TIME],[TS_SCHEDULE_TIME],[TS_EXPIRED_TIME],[TS_TIMES],[TS_BUSY_INTERVAL],[TS_NOANSWER_INTERVAL] ,[TS_OTHER_INTERVAL] ,[TS_ALREADY_TIMES] ,[TS_STATUS],[TS_HOST]"
                        + ") VALUES (12,'test',@calledNumber,@IVRUrl, DATEADD(ss,3,@startTimep),DATEADD(ss,4,@planTimep), DATEADD(DAY,7,GETDATE()) ,@timesp,@timesp ,@timesp ,@timesp ,0 ,0 ,' ')";
               int x= command.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
            }
            finally
            {
                if (command != null)
                    command.Dispose();
                if (connection != null) connection.Dispose();

            }
        }

    }
}
