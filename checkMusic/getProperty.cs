using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace checkMusic
{
    class getProperty
    {
         public  static string ApplicationPath = Directory.GetCurrentDirectory().ToString();
        public static  string getLeavePath(){

           // MessageBox.Show(ConfigurationManager.AppSettings["LeavePath"]);
            return ConfigurationManager.AppSettings["LeavePath"] ;          
        }
        public static string getRecordPath()
        {
            return ConfigurationManager.AppSettings["RecordPath"] ;
        }
        public static  void  setLeavePath(string path)
        {

            // MessageBox.Show(s);
            UpdateAppConfig ua = new UpdateAppConfig();
            ua.updateAppConfig("LeavePath", path);
           
          
        }
        public static  void  setRecordPath(string path)
        {
          //  ConfigurationManager.AppSettings.Remove("RecordPath");
           // ConfigurationManager.AppSettings.Add("RecordPath", path);
           // ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None).Save(ConfigurationSaveMode.Modified);
           // ConfigurationManager.RefreshSection("appSettings"); 
            UpdateAppConfig ua = new UpdateAppConfig();
            ua.updateAppConfig("RecordPath", path);
        }
       
    }
}
