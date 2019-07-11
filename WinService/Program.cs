using net.PingTools;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Windows.Forms;
using tools;

namespace WinService
{
    static class Program
    {
      static  ServiceBase[] ServicesToRun;
       static  ThreadPing tp;
       //ServiceBase.Run注册完服务之后必须运行service.run不然服务无法启动。
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        static void Main(string[] args)
        {
            if (args == null || args.Length == 0)
            {
                Console.WriteLine("----------请重新输入参数后运行-----------------");
                Console.WriteLine("需要先注册服务:");
                Console.WriteLine("-i   注册服务");
                Console.WriteLine("-u   卸载服务");
                Trace.WriteLine("-d   调试服务");
                MessageBox.Show("-i   注册服务, -u   卸载服务 -d   调试服务.需要在命令行。");
                tp = new ThreadPing();
                Service.readAppconfig();
                tp.startPingThread(Service.getAppIPAdderssString());
                MessageBox.Show("------正在运行不要关闭，也不要点确定，注册服务请重新运行--------");
                ThreadPing.clear();
            }
            else
            {
                if ("-i".Equals(args[0]))
                {
                    Exec("\"" + typeof(Program).Assembly.Location + "\"");
                }
                else if ("-u".Equals(args[0]))
                {
                    Exec("-u \"" + typeof(Program).Assembly.Location + "\"");
                }
                else if ("-d".Equals(args[0]))
                {
                   //  Console.WriteLine("---------------------------");
                    tp = new ThreadPing();
                    Service.readAppconfig();
                    tp.startPingThread(Service.getAppIPAdderssString());
                    MessageBox.Show("----------正在运行不要关闭，也不要点确定-----------------");
                    ThreadPing.clear();
                }
               
            }
        }




        public static bool Exec(string args)
        {
            string s = System.Environment.GetEnvironmentVariable("windir");
            string url = s + "\\Microsoft.NET\\Framework\\v2.0.50727\\InstallUtil.exe";
            Console.WriteLine("{0} {1}", url, args);
            log.Debug(url + "+++++++" + args);
            MessageBox.Show("---------------------------");
            //Sbw.DbClient.Log.Info();
            Process p = new Process();
            p.StartInfo.FileName = url;
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardInput = true;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.RedirectStandardError = true;
            //   not   display   window
            p.StartInfo.CreateNoWindow = true;
            p.StartInfo.Arguments = args;
            p.Start();
            string strRst = p.StandardOutput.ReadToEnd();
        //    log.Debug("----" + strRst);
            Console.WriteLine("+++++++++++++" + strRst);
            //  p.Close();
            Service ser= new Service();
            ServicesToRun = new ServiceBase[] { ser };
            ServiceBase.Run(ServicesToRun);
            return true;
        }
    }
}
