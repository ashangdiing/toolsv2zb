using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
namespace avayaBusyrel
{
    public class log
    {
        static object objLock = new object();
        public static bool logFlag = true;
        // public static string msg="";
        static System.IO.FileInfo file; static StreamWriter sw;
        public static string ApplicationPath = System.AppDomain.CurrentDomain.BaseDirectory.ToString();//winfom无测试
        // public static string ApplicationPath = Directory.GetCurrentDirectory().ToString(); //winform 完全测试过
        public static DirectoryInfo logDirectory = new DirectoryInfo(ApplicationPath + "\\Log");
       public static long logFileMaxSize = 1204 * 1024;
        public static int sleepTime = 10;

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
                    file = new FileInfo(string.Format(ApplicationPath + "\\Log\\{0:yyyy-MM-dd-HH-mm-ss}.txt", DateTime.Now));
                    lock (objLock)
                    {
                        sw = file.CreateText();
                    }
                }
                if (!file.Exists)
                {
                    file = new FileInfo(string.Format(ApplicationPath + "\\Log\\{0:yyyy-MM-dd-HH-mm-ss}.txt", DateTime.Now));
                    lock (objLock)
                    {
                        sw = file.CreateText();
                    }
                }
                if (file.Length > logFileMaxSize)
                {
                    sw.Flush();
                    if (sw != null)
                        sw.Close();
                    sw.Dispose();
                    file = new FileInfo(string.Format(ApplicationPath + "\\Log\\{0:yyyy-MM-dd-HH-mm-ss}.txt", DateTime.Now));
                    lock (objLock)
                    {
                        sw = file.CreateText();
                    }
                    //  sw.WriteLine(msg);
                }
                lock (objLock)
                {
                    sw.WriteLine(msg);
                    sw.AutoFlush = true;
                    file.Refresh();
                }
                //   System.Windows.Forms.MessageBox.Show("sa","ss");

            }
            catch (Exception e)
            {
                writeLine(e.ToString());
            }

        }
    }
}