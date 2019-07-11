using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.NetworkInformation;
using System.IO;
using System.Threading;
namespace net.PingTools
{

   public  class PingTools:IDisposable
   {
       public static int sleepTime { get; set; }
       public  static void  setTimeout(int t){
           timeout=t;
       }
       public Thread pingThread;
        System.IO.FileInfo file; StreamWriter sw; object objLock = new object(); 
        public static  bool stopApp=false;
        public static string ApplicationPath=System.AppDomain.CurrentDomain.BaseDirectory.ToString();//winform路径未测试过
      //  public static string ApplicationPath = Directory.GetCurrentDirectory().ToString();//winform路径测试过
        public static DirectoryInfo logDirectory = new DirectoryInfo(ApplicationPath + "\\PingLog");
        PingOptions options; static int timeout = 300; static string data = "ICMP"; string IP = "192.168.27.253";public static int systemTimeOut=1000;
        byte[] buffer; PingReply reply; System.Net.NetworkInformation.Ping p; public string mgstemp;
        public static long logFileMaxSize = 1204 * 1024;
       public  PingTools(string IP) {
           sleepTime = 1000;
            this.IP = IP;
            pingThread = new Thread(startPing);
            pingThread.IsBackground = true;
            pingThread.Start();
        }
         public void startPing(){
             while (true)
             {
                 Ping();
                 System.Threading.Thread.Sleep(sleepTime);
                 if (stopApp) 
                     break;
             }
         }


       public void Ping() {
            
           buffer = Encoding.ASCII.GetBytes(data);
           options = new PingOptions();
           options.DontFragment = true;
           p = new System.Net.NetworkInformation.Ping();
           reply = p.Send(IP, systemTimeOut, buffer);
            if (reply.Status == IPStatus.Unknown)
                writeLine("未知原因，请检测网卡.code:Unknown");
            else if (reply.Status == IPStatus.TimedOut)
                writeLine("请求超时." + "回复时长：" + reply.RoundtripTime + "无应答code:TimedOut");
            else if (reply.Status == IPStatus.BadDestination)
                writeLine("坏的目标无法到达.code:BadDestination");
            else if (reply.Status == IPStatus.BadRoute)
                writeLine("路由无法到达.code:BadRoute");
            else if (reply.Status == IPStatus.DestinationNetworkUnreachable)
                writeLine("无法访问计算机网络.code:DestinationNetworkUnreachable");
            else if (reply.Status == IPStatus.DestinationProhibited)
                writeLine("目标被禁Ping.code:DestinationProhibited");
            else if (reply.Status == IPStatus.DestinationScopeMismatch)
                writeLine("目标地址与原地址不在同一网络.code:DestinationScopeMismatch");
            else if (reply.Status == IPStatus.DestinationUnreachable)
                writeLine("无法得知回复消息，原因未知.code:DestinationUnreachable");
            else if (reply.Status == IPStatus.HardwareError)
                writeLine("硬件错误.code:HardwareError");
            else if (reply.Status == IPStatus.PacketTooBig)
                writeLine("MTU达到最大.code:PacketTooBig");
            else if (reply.Status == IPStatus.TtlExpired)
                writeLine("路由值达到最大，未到达，TTl耗尽code:TtlExpired");
            else
            {
                if (reply.RoundtripTime > timeout) {
                    mgstemp = "回复时长：" + reply.RoundtripTime + "ms; 大于" + timeout + "ms,istimout,算超时.IP:" + reply.Address;
                }
                else mgstemp = "回复时长：" + reply.RoundtripTime + "ms.IP:" + reply.Address;
                writeLine(mgstemp);
            }
       }
       public  void writeLine(string msg)
       {
           msg = string.Format("{0:yyyy-MM-dd HH:mm:ss.fffffff}", DateTime.Now) + msg;
           try
           {
               if (!logDirectory.Exists)
               {
                   logDirectory.Create();
               }

               if (file == null)
               {
                   file = new FileInfo(string.Format(logDirectory + "\\Host_{0}-{1:yyyy-MM-dd_HH-mm-ss}.txt", IP, DateTime.Now));
                   lock (objLock)
                   {
                       sw = file.CreateText();
                   }
               }
               if (!file.Exists)
               {
                   file = new FileInfo(string.Format(logDirectory + "\\Host_{0}-{1:yyyy-MM-dd_HH-mm-ss}.txt", IP, DateTime.Now));
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
                   file = new FileInfo(string.Format(logDirectory + "\\Host_{0}-{1:yyyy-MM-dd_HH-mm-ss}.txt", IP, DateTime.Now));
                   lock (objLock)
                   {
                       sw = file.CreateText();
                   }
               }
               lock (objLock)
               {
                   sw.WriteLine(msg);
                   sw.AutoFlush = true;
                   file.Refresh();
               }
           }
           catch (Exception e)
           {
               
           }

       }
       public  void close()
       {
           if (sw != null)
               sw.Close();
           sw.Dispose();
       }

   

       public void Dispose()
       {
           close();
           pingThread.Abort();
           System.Threading.Thread.CurrentThread.Abort();
          

       }
   }
}
