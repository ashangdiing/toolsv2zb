using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;

namespace net.callOut
{
    class callOutThread
    {
        SqlDataReader EvaluationSDR; List<Evaluation> le ;
        public static Thread callOutTask;public static string IVRUrl;
        creatVxmlFile cvf;
        public static string getIVRUrl()
        {
            if (IVRUrl == null)
                 IVRUrl = ConfigurationManager.AppSettings["IVRUrl"];
            return IVRUrl;
        }
        public callOutThread() {
            getIVRUrl();
            if (callOutTask == null) {
               
            callOutTask = new Thread(startTask);
            callOutTask.IsBackground = true;
            callOutTask.Start();
        }
            
        }
        public void startTask(){
            while (true)
            {
                PingTools.PingTools.sleepTime = 1000;
                creatEvaluationFile();
                removeEvaluationFile();
                updateTimeoutEvaluation();
                System.Threading.Thread.Sleep(PingTools.PingTools.sleepTime);
                if (PingTools.PingTools.stopApp)
                    break;
            }
        }

        public void creatEvaluationFile(){
            le=readEvaluation();
            if (le == null || le.Count == 0)
                return;
            foreach(Evaluation e1 in le){
                
                cvf = new creatVxmlFile();
                cvf.e = e1;
                if ("success" == cvf.creatFile())
                {
                    updateEvaluation(e1.taskID, "1");
                   // write2CallOut(e1);
                }
            }
        }
        public void removeEvaluationFile()
        {
           le = readEvaluation("removeFile");
           if (le == null || le.Count == 0)
               return;
           foreach (Evaluation e1 in le)
           {

               cvf = new creatVxmlFile();
               cvf.e = e1;
               cvf.removeFile();
               updateEvaluation(e1.taskID,"-1");
           }
        }

        public List<Evaluation> readEvaluation() {
            return readEvaluation("creatFile");
        }
        public List<Evaluation> readEvaluation(string Types)
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
                if (Types == "creatFile")
                    command.CommandText = "SELECT TOP 100 * FROM  [Evaluation]  where  state=0  order by dateTime ";
                else if (Types == "removeFile")
                    command.CommandText = "SELECT TOP 100 * FROM  [Evaluation]  where  state=-2   and lastUpdateTime is not null order by dateTime";
                else return null;
                EvaluationSDR = command.ExecuteReader();
                if (!EvaluationSDR.HasRows) { return null; }
                     le=new List<Evaluation>();
                     Evaluation e;
                while (EvaluationSDR.Read())
                {
                    if (!EvaluationSDR.HasRows) { return null; }
                    e = new Evaluation();
                    e.name = EvaluationSDR["name"].ToString();
                    e.taskID = EvaluationSDR["TaskID"].ToString();
                    e.department = EvaluationSDR["TaskID"].ToString();
                    e.dateTime = EvaluationSDR["dateTime"].ToString();
                    e.lastUpdateTime = EvaluationSDR["lastUpdateTime"].ToString();
                    e.state = EvaluationSDR["state"].ToString();
                    e.phoneNumber = EvaluationSDR["phoneNumber"].ToString();
                    e.accidentAddress = EvaluationSDR["accidentAddress"].ToString();
                    le.Add(e);
                }

            }
            catch (Exception ex)
            {
                tools.log.Debug("读取结果异常："+ex.ToString());
                return null;
            }
            finally
            {
                if (command != null)
                    command.Dispose();
                if (connection != null) connection.Dispose();
            } return le;
        }



        public void updateEvaluation(string taskID, string state)
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
                command.Parameters.Add(new SqlParameter("taskID", taskID));
                command.Parameters.Add(new SqlParameter("state", state));
                command.CommandText = " update  Evaluation  set  state=@state,lastUpdateTime=GETDATE() where taskID=@taskID";
                command.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                tools.log.Debug("更新TASKID：" + taskID + "状态" + state + "不成功");
                tools.log.Debug(ex.ToString());
                
            }
            finally
            {
                if (command != null)
                    command.Dispose();
                if (connection != null) connection.Dispose();
                
            }
        }



        public void updateTimeoutEvaluation()
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

                command.CommandText = " update   Evaluation  set evaluationResult=76,lastUpdateTime=getdate(),state=-2  where DATEADD(mi,-49*60,getdate())>lastUpdateTime and evaluationResult is null ";
                command.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                tools.log.Debug("超时更新出错");
                tools.log.Debug(ex.ToString());

            }
            finally
            {
                if (command != null)
                    command.Dispose();
                if (connection != null) connection.Dispose();

            }
        }


        public int write2CallOut(Evaluation e) {
            
            int x=0;
            SqlConnection connection = null;
            SqlCommand command = null;
            try
            {
                //   SqlConnection connection = new SqlConnection("server= 127.0.0.1;uid=sa;pwd=esun5005;database=crmrun");
                connection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["Default"].ConnectionString);
                connection.Open();
                command = new SqlCommand();
                command.Connection = connection;
                command.Parameters.Add(new SqlParameter("taskID", e.taskID));
                command.Parameters.Add(new SqlParameter("phone", e.phoneNumber));
                command.Parameters.Add(new SqlParameter("ivr", e.phoneNumber));
                command.Parameters.Add(new SqlParameter("url", IVRUrl.Trim()+ e.taskID.Trim() + ".html"));

                command.CommandText = " INSERT INTO   TS_CALLOUT(TS_TASK_ID ,TS_TYPE,TS_CALLED ,TS_URL,TS_START_TIME ,TS_SCHEDULE_TIME" +
          ",TS_EXPIRED_TIME ,TS_TIMES  ,TS_BUSY_INTERVAL ,TS_NOANSWER_INTERVAL ,TS_OTHER_INTERVAL  ,TS_ALREADY_TIMES  ,TS_STATUS  ,TS_HOST)"
          + "VALUES(@taskID ,'test' ,@phone ,@url ,getdate() ,getdate(),'2020-01-01'" +
          " ,1 ,1 ,1 ,1 ,0 ,0,'')";
              x= command.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                tools.log.Debug("TASKID：" + e.taskID + "插入ivr不成功" + IVRUrl);
                tools.log.Debug(ex.ToString());

            }
            finally
            {
                if (command != null)
                    command.Dispose();
                if (connection != null) connection.Dispose();
                 
            }
            return x;
        }

    }
}
