using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace net.PingTools
{
     public  class ThreadPing
    {
         public string IPString;
        public static  List<PingTools> lpt = new List<PingTools>();
        PingTools pt;
       
         public void  startPingThread(string ips){
           
             string[] ipArray = System.Text.RegularExpressions.Regex.Split(ips, "\\s{1,}");
             foreach (string s in ipArray)
             {
                 //System.Windows.Forms.MessageBox.Show(s);

                 /** 
                   if (System.Text.RegularExpressions.Regex.Split(s,"\\.{1,}").Length < 4) {

                     //  System.Windows.Forms.MessageBox.Show(s+"不是ip地址");
                       continue;
                  }
                 **/

                 pt = new PingTools(s);
                
                 lpt.Add(pt);
               
             }
         }

         public static void clear(){
                 System.Threading.Thread.CurrentThread.Abort();
         }

    }
}
