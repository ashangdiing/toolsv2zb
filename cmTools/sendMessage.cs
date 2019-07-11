using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace cmTools
{
   public  class sendMessage
   {
       NetworkStream steram;
       IPAddress ServerIp;
       IPEndPoint ipEndPoint;
       TcpClient tc;
         public bool login(){
              init();
              //recive();
              sendMessages();
              //sendMessages();
             // sendMessages();
              recive();
              recive();
              sendMessages();
              recive();
              sendMessages();
              recive();
              recive();
              sendMessages();
              recive();
              sendMessages();
              recive();
             return false;
         }

         private void init()
         {
             // ServerIp = IPAddress.Parse("127.0.0.1");
             ServerIp = IPAddress.Parse("14.23.151.178");
             ipEndPoint = new IPEndPoint(ServerIp, 5005);
             // ipEndPoint = new IPEndPoint(ServerIp, 1433);
             tc = new TcpClient();
             tc.Connect(ipEndPoint);
             steram = tc.GetStream();
             
         }


         private void sendMessages()
         {

          
             // MessageBox.Show(r1);
             string mesage ="" ;
             string cmd = "aaa"; string cr = "\r\n";

                byte[] sendMessage = System.Text.Encoding.ASCII.GetBytes(cmd.ToCharArray());
           //  byte[] sendMessage = ASCIIEncoding.GetEncoding("gb2312").GetBytes(cmd);
             steram.Write(sendMessage, 0, sendMessage.Length);
             steram.Write(System.Text.Encoding.ASCII.GetBytes(cr.ToCharArray()), 0, cr.Length);
         }
         private void recive()
         {
             //  byte[] buffers=new byte[1024];
             byte[] buffers = new byte[1024];
             int len = steram.Read(buffers, 0, buffers.Length);
            string message = System.Text.Encoding.UTF8.GetString(buffers, 0, len);
           //  string message = System.Text.Encoding.UTF8.GetString(buffers,9, len);
         //    string message = System.Text.Encoding.GetEncoding("ANSI").GetString(buffers, 0, len);
             tools.log.Debug("返回消息：" + message);
            // tc.Close();
         } 
    }
}
