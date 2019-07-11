using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
namespace analysis4DFCYC
{
    class analysisDFCYCLog
    {
        public static string  date;
        public static Int64 count=0;
        public static DirectoryInfo TheFolder;
        public static Form1 form;
        public static string findString;
       public static  string message="";
        public static bool isMessage=false;
        public static string currentevent;
       static Dictionary<string, string> dic; 
        public analysisDFCYCLog(string folderPath,Form1 form1,string FindString) { 
            TheFolder=new DirectoryInfo(folderPath); //遍历文件夹 
            form = form1;
            findString = FindString;
            readEveryLog();
        }
        public static void readEveryLog() { 
          foreach (FileInfo file in TheFolder.GetFiles() ){
              form.labellogName.Text = file.Name;
              if (!file.Name.EndsWith(".log"))
                   return;
              using (StreamReader sr = new StreamReader(file.FullName, System.Text.Encoding.GetEncoding("GB2312")))
               {
                   while (!sr.EndOfStream)
                   {
                       message=sr.ReadLine();
                       if (!string.IsNullOrEmpty(message))
                       analysisEveryLine(message);
                       count++;
                       if (count<0)
                           return;
                   }
               }           
              

           }  
        }

        public static void analysisEveryLine(string message)
        {
            string temp;

            //SystemStatus 该字符中有时间
            if (string.IsNullOrEmpty(findString))
                findString = "------------------------------------<><><><";
            if (message.Contains("SystemStatus"))
            { getDate(message);
            return;
            }

            if (message != null) {

                if (message.Contains("message"))
                {
                    foreach (string key in dic.Keys)
                    {
                   //    MessageBox.Show(dic[key]);
                    }
                }
                dic = new Dictionary<string, string>();
                dic.Clear();
                currentevent = null;
                if(message.Contains("EventRinging")){
               string  timeString =message.Substring(message.IndexOf("@")+1,13);
               MessageBox.Show(date + timeString);
               dic.Add("time", date+timeString);
                }
              
               // MessageBox.Show(message);
              int index= message.IndexOf("message");
              message = message.Substring(index+7);
              dic.Add("message", message.Trim());
              currentevent = message.Trim();
              return;
            }
            if (currentevent == null)
                return;
            if (currentevent.Equals("EventRinging"))
            {
                if (message.Contains("AttributeConnID")) {
                    temp = message.Substring(message.IndexOf("AttributeConnID")+1);
                    temp = temp.Replace("'","");
                    dic.Add("connid", temp.Trim());
                }
                if (message.Contains("CallingNumber"))
                {
                    temp = message.Substring(message.IndexOf("CallingNumber")+1);
                    temp = temp.Replace("'", "");
                    dic.Add("phone", temp.Trim());
                }
                if (message.Contains("AttributeAgentID"))
                {
                    temp = message.Substring(message.IndexOf("AttributeAgentID")+1);
                    temp = temp.Replace("'", "");
                    dic.Add("agent", temp.Trim());
                }

                if (message.Contains("AttributeThisDN"))
                {
                    temp = message.Substring(message.IndexOf("AttributeThisDN")+1);
                    temp = temp.Replace("'", "");
                    dic.Add("ext", temp.Trim());
                }
                return;
            }

           
            if (currentevent.Equals("RequestAnswerCall"))
            {
                if (message.Contains("AttributeConnID"))
                {
                    temp = message.Substring(message.IndexOf("AttributeConnID") + 1);
                    temp = temp.Replace("'", "");
                    dic.Add("connid", temp.Trim());
                }
                if (message.Contains("AttributeThisDN"))
                {
                    temp = message.Substring(message.IndexOf("AttributeThisDN") + 1);
                    temp = temp.Replace("'", "");
                    dic.Add("connid", temp.Trim());
                }
                return;
            }


            if (message.Contains(findString))
            {
                form.textBoxLogMessage.Text = message;
                MessageBox.Show(message);
            }
        }
        public void EventRinging()
        {

        }

    
        public   static void  getDate(String message){
            string[] s=message.Split('@');
            date=s[1];
            date = date.Insert(6, "20");
            date = date.Replace("/", "-");
            date=Convert.ToDateTime(date).ToString("yyyy-MM-dd");
        }

    }
}
