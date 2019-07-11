using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;

namespace net.callOut
{
    class creatVxmlFile
    {
        System.IO.FileInfo file;
        StreamWriter sw;
        public Evaluation e;
        public static string IISPath = getIISPath();
        static DirectoryInfo IISDirectory = new DirectoryInfo(IISPath);

        public static string getIISPath()
        {
            if (IISPath == null)
                IISPath = ConfigurationManager.AppSettings["IISPath"];
            return IISPath;
        }
        public string creatFile(){
            if (!IISDirectory.Exists) {
                tools.log.Debug("iis路径不存在，请检查");
                return "iis路径不存在，请检查";
            }
            if (file == null) {
                file = new FileInfo( IISDirectory.ToString()+"\\callout"+e.taskID+".html");
            }
           
            try
            {
                if (file.Exists) file.Delete();
              //  sw = file.CreateText();

                sw = new StreamWriter(file.FullName, false, Encoding.UTF8);
                //    sw.WriteLine("<%@ Page Language=\"C#\" AutoEventWireup=\"true\" CodeBehind=\"callOutDefault.aspx.cs\" Inherits=\"VXML.callOutDefault\" %><?xml version=\"1.0\" encoding=\"utf-8\" ?><vxml version=\"1.0\">");
                sw.WriteLine("<?xml version=\"1.0\" encoding=\"utf-8\" ?><vxml version=\"1.0\">");

                sw.WriteLine("<var name = \"gRetryMaxTimes\" expr = \"3\" />");
                sw.WriteLine("<var name = \"gRetryTimes\" expr = \"0\" />");
                sw.WriteLine("<var name = \"gNoInputTimes\" expr = \"0\" />");
                sw.WriteLine("<form id=\"start\">");
                sw.WriteLine("<block><prompt><audio src = \"d:\\music\\welcome.wav\">您好，这里是江岸区监督指挥中心，你于</audio></prompt>");
              //  sw.WriteLine("<prompt>" + e.toIVRDay(e.dateTime.Trim()) + "</prompt> ");

                sw.WriteLine("<prompt><audio src = \"d:\\music\\mm" + e.toIVRMM(e.dateTime.Trim()) + ".wav\">" + e.toTTSMM(e.dateTime.Trim()) + "月</audio></prompt>");
                sw.WriteLine("<prompt><audio src = \"d:\\music\\day" + e.toIVRDay(e.dateTime.Trim()) + ".wav\">" + e.toTTSDay(e.dateTime.Trim()) + "日</audio></prompt>");
               // sw.WriteLine("<prompt><audio src = \"d:\\music\\guanyu.wav\">在</audio></prompt><prompt>" + e.accidentAddress + "</prompt>");
              //  sw.WriteLine("<prompt><audio src = \"d:\\music\\event.wav\">投诉的案件已处置完毕</audio></prompt>");
              
                sw.WriteLine("<prompt><audio src = \"d:\\music\\menu.wav\"> 请您对该案件的处置结果进行评价。满意请按一，基本满意请按二，不满意请按三，谢谢.</audio></prompt> <goto next=\"#isAgain\" /></block> </form>");
              
                sw.WriteLine("<menu id=\"isAgain\">");
                sw.WriteLine("<choice dtmf = \"1\" next = \"#Digits1\"/>");
                sw.WriteLine("<choice dtmf = \"2\" next = \"#Digits2\"/>");
                sw.WriteLine("<choice dtmf = \"3\" next = \"#Digits3\"/>");
                // sw.WriteLine("  <choice dtmf = \"9\" next =\"#Digits9\"/>");
                sw.WriteLine("</menu>");

                sw.WriteLine("<form id=\"Digits1\"><block><prompt><audio src = \"d:\\music\\thanks.wav\"> 蟹蟹</audio></prompt><assign name=\"result\" expr=\"1\"/>");
                sw.WriteLine("<assign name=\"caseID1\" expr=\"'" + e.taskID + "'\"/>");
                sw.WriteLine("<submit next=\"http://10.6.79.75:83/evaluationSuccess.aspx\" namelist =\"caseID1 result\"/> ");
                sw.WriteLine("<disconnect/> </block></form>");

                sw.WriteLine("<form id=\"Digits2\"><block><prompt><audio src = \"d:\\music\\thanks.wav\">蟹蟹 </audio></prompt><assign name=\"result\" expr=\"2\"/>");
                sw.WriteLine("<assign name=\"caseID1\" expr=\"'" + e.taskID + "'\"/>");
                sw.WriteLine("<submit next=\"http://10.6.79.75:83/evaluationSuccess.aspx\" namelist =\"caseID1 result\"/> ");
                sw.WriteLine("<disconnect/> </block></form>");

                sw.WriteLine("<form id=\"Digits3\"><block><prompt><audio src = \"d:\\music\\thanks.wav\">蟹蟹 </audio></prompt><assign name=\"result\" expr=\"3\"/>");
                sw.WriteLine("<assign name=\"caseID1\" expr=\"'" + e.taskID + "'\"/>");
                sw.WriteLine("<submit next=\"http://10.6.79.75:83/evaluationSuccess.aspx\" namelist =\"caseID1 result\"/> ");
                sw.WriteLine("<disconnect/> </block></form>");


                sw.WriteLine("<form id=\"Digits77\"><block><prompt><audio src = \"d:\\music\\noinputlong.wav\">一直未按键，您未对处理结果做出评价，我们将按基本满意记录。 \r\n</audio></prompt><assign name=\"result\" expr=\"77\"/>");
                sw.WriteLine("<assign name=\"caseID1\" expr=\"'" + e.taskID + "'\"/>");
                sw.WriteLine("<submit next=\"http://10.6.79.75:83/evaluationSuccess.aspx\" namelist =\"caseID1 result\"/> ");
                sw.WriteLine("<disconnect/> </block></form>");

                sw.WriteLine("<form id=\"Digits78\"><block><prompt><audio src = \"d:\\music\\nomatchmore.wav\">三次输入错误，您未对处理结果做出评价，我们将按基本满意记录。\r\n</audio></prompt><assign name=\"result\" expr=\"78\"/>");
                sw.WriteLine("<assign name=\"caseID1\" expr=\"'" + e.taskID + "'\"/>");
                sw.WriteLine("<submit next=\"http://10.6.79.75:83/evaluationSuccess.aspx\" namelist =\"caseID1 result\"/> ");
                sw.WriteLine("<disconnect/> </block></form>");


                sw.WriteLine("<noinput>");
                sw.WriteLine("<assign name = \"gNoInputTimes\" expr = \"gNoInputTimes+1\" />");
                sw.WriteLine("<if cond = \"gNoInputTimes >= gRetryMaxTimes\">");
                sw.WriteLine("<goto next=\"#Digits77\"/>");
                sw.WriteLine("<else />");
                sw.WriteLine("<prompt>  <audio src = \"d:\\music\\noinput.wav\">您没有输入 \r\n</audio> </prompt><reprompt /></if> </noinput>");

                sw.WriteLine("<nomatch>   <assign name = \"gRetryTimes\" expr = \"gRetryTimes+1\" />");
                sw.WriteLine("<if  cond = \"gRetryTimes >= gRetryMaxTimes\">");
                sw.WriteLine("<goto next=\"#Digits78\"/>");
                sw.WriteLine("<else />");
                sw.WriteLine("<prompt>");
                sw.WriteLine("<audio src = \"d:\\music\\nomatch.wav\">  您的选择不正确，请重新选择\r\n</audio> </prompt>  <reprompt />  </if> </nomatch>");

                sw.WriteLine("</vxml>");


                sw.AutoFlush = true;
                file.Refresh();
                sw.Flush();
            }
            catch (Exception ex)
            {
                tools.log.Debug("创建文件IO异常：" + ex.ToString());
                return "false";
            }
            finally {
                if (sw != null)
                    sw.Close();
                sw.Dispose();
            }
           
            return "success";
        }
        public void removeFile() {
            if (file == null)
            {
                file = new FileInfo(IISDirectory.ToString() + "\\callout" + e.taskID + ".html");
            }
            if (file.Exists)
            {
                file.Delete();
                tools.log.Debug("文件已删除" + file.FullName);
            }
            else tools.log.Debug("不存在文件" + file.FullName);
        }
    }
}
