using net.PingTools;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Windows.Forms;

namespace WinService
{
    public partial class Service : ServiceBase
    {
        public static ThreadPing tp; static string IPAddress, timeout, Intervial;
        public Service()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            /**/
         //   MessageBox.Show("---------------------------");
          //  tools.log.Debug("  asdasdasd");
            readAppconfig();
            if (tp == null) { 
            tp = new ThreadPing();
            tp.startPingThread(IPAddress);
            }
            PingTools.stopApp = false;

            /*
                */
        }

        protected override void OnStop()
        {
            PingTools.stopApp = true;
            ThreadPing.clear();
        }
        public static string  getAppIPAdderssString(){
            return IPAddress;
        }
        public static void  readAppconfig(){

              timeout=ConfigurationManager.AppSettings["pingTimeOut"];
              Intervial = ConfigurationManager.AppSettings["pingIntervial"];
            if(!string.IsNullOrEmpty(timeout))
                PingTools.setTimeout(Convert.ToInt32(timeout));
            if (!string.IsNullOrEmpty(Intervial))
                PingTools.sleepTime = Convert.ToInt32(Intervial);
            IPAddress = ConfigurationManager.AppSettings["pingIPAddress"];
        }
    }
}
