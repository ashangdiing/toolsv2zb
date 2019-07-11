using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace checkMusic
{
    class CheckFileThread 

    {
        public static int checkFileIntervial=200 ;
        //public static CheckWavFile recordFile, leaveFile;
        public Record.Record r;public Leave.Leave l;
       // public static DirectoryInfo recordDirectory, leaveDirectory; 
        int i=1,j=1;
        public void checkLeaveFile(){
            while (true)
            {
                System.Threading.Thread.Sleep(checkFileIntervial+3);
                l = new Leave.Leave();
                l.readLeaveSql();                 
             //   i++;
            }
            
        }

        
        public void checkRecordFile()
        {
            while (true)
            {

           //     recordDirectory =new DirectoryInfo( getProperty.getRecordPath());
                System.Threading.Thread.Sleep(checkFileIntervial);
                 r = new Record.Record();
                 r.readRecordSql();
                /**  
                foreach(FileInfo fi in recordDirectory.GetFiles()){
                    tools.log.Debug("文件名" + fi.FullName);
                    recordFile = new CheckWavFile();
                    recordFile.isUseful(fi.FullName);
                    
                }
                **/
               
                j++;
            }

        }

    }
}
