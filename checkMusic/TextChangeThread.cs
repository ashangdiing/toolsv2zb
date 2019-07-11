using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace checkMusic
{
    public class TextChangeThread
    {
      public  string txtFileName;
        public void Read()
        {
            StreamReader objReader = new StreamReader(txtFileName, Encoding.UTF8);
            if (txtFileName == null) return;
            string sLine = "";int index=0;

            while ((sLine = objReader.ReadLine()) != null)
            {
                if (sLine.IndexOf("http://172.16.10.36/website/recordSuccess.aspx?") < 0) continue;
                index=sLine.IndexOf("URL=");
               sLine= sLine.Substring(index + 4);
               Write(sLine);
            }
            objReader.Close();
        }

        public void Write(string data)
        {
            if (txtFileName == null) return;
            FileStream fs = new FileStream(txtFileName+"newFile.txt", FileMode.Append);
            StreamWriter sw = new StreamWriter(fs);
            //开始写入
            sw.WriteLine(data);
         //   sw.WriteLine("-------");
            //清空缓冲区
            sw.Flush();
            //关闭流
            sw.Close();
            fs.Close();
        }



    }
}
