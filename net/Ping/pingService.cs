using net.PingTools;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;

namespace net
{
    partial class pingService : ServiceBase
    {
        ThreadPing tp;
        public pingService()
        {
            InitializeComponent();
            tp = new ThreadPing();
            tp.startPingThread("192.168.27.253 192.168.27.33");
        }

        protected override void OnStart(string[] args)
        {
            // TODO:  在此处添加代码以启动服务。
            PingTools.PingTools.stopApp = false;
        }

        protected override void OnStop()
        {
            // TODO:  在此处添加代码以执行停止服务所需的关闭操作。
            PingTools.PingTools.stopApp = true;
        }
    }
}
