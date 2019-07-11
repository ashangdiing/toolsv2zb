using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace checkMusic
{
    class UpdateAppConfig
    {
        string ApplicationPath="";
       System.IO.FileInfo AppConfigfile;
        StreamWriter sw;
        public void init(){
            ApplicationPath = Directory.GetCurrentDirectory().ToString();           
            AppConfigfile = new FileInfo(ApplicationPath + "\\App.config");
        }
        public void removeAppConfig(){
            init();
            if (AppConfigfile.Exists)
                AppConfigfile.Delete();

        }
        public void creatAppConfig()
        {
            init();
            if (!AppConfigfile.Exists)
                AppConfigfile.Create();
        }

        public void updateAppConfig(string key,string value)
        {
            init();
           
            if (AppConfigfile.Exists)
                AppConfigfile.Delete();
            
               sw= AppConfigfile.CreateText();
          
            sw.WriteLine("<?xml version=\""+"1.0\"?>");
            sw.WriteLine("<configuration>");
            sw.WriteLine("<connectionStrings>");
            sw.WriteLine("<add name=\"Default\" connectionString=\"Max Pool Size = 512;server="+"."+";uid=sa; pwd=esun5005;database=ESUNNET\" providerName=\"System.Data.SqlClient\" />");
            sw.WriteLine("</connectionStrings>");
            sw.WriteLine(" <appSettings>");
            if (key == "LeavePath")
            {
                sw.WriteLine("<add key=\"LeavePath\"  value=\"" + value + "\"/>");
                sw.WriteLine("<add key=\"RecordPath\"  value=\"" + value + "\"/>");
            }
           // sw.WriteLine("<add key=\"LeavePath\"  value=\"" + "D:\\work\\z中百集团\\VXML" + "\"/>");
            if (key == "RecordPath")
            {
                sw.WriteLine("<add key=\"LeavePath\"  value=\"" + value + "\"/>");
                sw.WriteLine("<add key=\"RecordPath\"  value=\"" + value + "\"/>"); 
            }
            sw.WriteLine("</appSettings>");
            sw.WriteLine("</configuration>");

            sw.AutoFlush = true;
            AppConfigfile.Refresh();
            sw.Flush();
            if (sw != null)
                sw.Close();
            sw.Dispose();

        }

    }
}
