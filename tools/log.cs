using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;


namespace tools
{
    public class log
    {
      
      //  static System.IO.FileInfo file; static StreamWriter sw;  

       public  static Thread logThread;
        public static void initLog() {

            if (logThread == null)
            {
                logThread = new Thread(tools.logThread.logThreadRun);
                logThread.Start();
            }
            
        }
        public static void Debug(string msg ){
            initLog();
            string logmsg = string.Format("{0:yyyy年MM月dd日 HH:mm:ss:fffffff}  {1}:    {2}", DateTime.Now, "消息", msg);
            tools.logThread.addMessage(logmsg);
        }

        public static void stopThread()
        {
            logThread.Abort();
            tools.logThread.close();
        }

       
    }
}
