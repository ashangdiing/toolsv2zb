using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
 

namespace tools
{
    public class log
    {
        public static object locker = new object();

        static System.IO.FileInfo file; static StreamWriter sw;static FileStream stream;
        static string ApplicationPath = Directory.GetCurrentDirectory().ToString();
        static  DirectoryInfo logDirectory = new DirectoryInfo(ApplicationPath + "\\Log");
        public static void Debug(string msg)
        {
            
           
            string logmsg = string.Format("{0:yyyy年MM月dd日 HH:mm:ss:fffffff}  {1}:    {2}", DateTime.Now, "消息", msg);
            writeLine(logmsg);
            
            
        }

        public static void writeLine(string msg)
        {
           
            try
            {
                if (!logDirectory.Exists)
                {
                    logDirectory.Create();
                }

                if (file == null)
                {
                    //  System.Windows.Forms.MessageBox.Show(string.Format("c:\\{0:yyyy-MM-dd-HH:mm:ss}.log", DateTime.Now), "sss");
                    file = new FileInfo(string.Format(ApplicationPath + "\\Log\\{0:yyyy-MM-dd-HH-mm-ss}.txt", DateTime.Now));
                    sw = file.CreateText();
                    sw.Dispose();
                }
                file.Refresh();
                // System.Windows.Forms.MessageBox.Show(file.Length.ToString(), "ss");

                if (!file.Exists)
                {
                    file = new FileInfo(string.Format(ApplicationPath + "\\Log\\{0:yyyy-MM-dd-HH-mm-ss}.txt", DateTime.Now));
                    sw = file.CreateText();
                    sw.Dispose();
                }
                if (file.Length > 1024 * 10240)
                {
                    //System.Windows.Forms.MessageBox.Show("sa", "ss");
                    file = new FileInfo(string.Format(ApplicationPath + "\\Log\\{0:yyyy-MM-dd-HH-mm-ss}.txt", DateTime.Now));
                    sw = file.CreateText();
                    sw.WriteLine(msg);
                }
                else
                { 
                    
                    sw = file.AppendText();
                
                }
                sw.WriteLine(msg);
                
                sw.Flush();
                //   System.Windows.Forms.MessageBox.Show("sa","ss");

            }
            catch (Exception e) {
                tools.log.Debug(e.ToString());           
            }
            finally{
               
                sw.Close();
                sw.Dispose();
               
            }
        }
          

    }
}
