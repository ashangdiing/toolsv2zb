using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using tools.File;

namespace checkMusic
{
    public  class CheckWavFile
    {
        public bool isExists = false, isValid = false; FileInfo fi;public string fileType;
       /// <summary>
       /// 多少秒算有效
       /// </summary>
       public static int usefulSecond=3;
        public WaveInfo wi;
        public bool isUseful(string pn) {
           
            fi = new FileInfo(pn);
            if (!fi.Exists)
                return false;          
            if (!isMusicFile(pn))
                return false;         
            wi = new WaveInfo(pn);
        //   tools.log.Debug("文件名:" + pn + "秒数:" + wi.Second + "Channels:" + wi.Channels + "BitsPerSample:" + wi.BitsPerSample + "SamlesPerSec:" + wi.SamlesPerSec + "FormatTag:" + wi.FormatTag);
         //   tools.log.Debug("文件名:----------");
            if (!wi.WaveBool)
                return false;
            isExists = true;
            if (wi.Second > usefulSecond)
                return true;
            isValid = true;
                   return true;
        } 
        /// <summary>
        /// 多少秒
        /// </summary>
        public int getMusicTime() {
            return (int)wi.Second;
        }
        public bool isMusicFile(string fn){
            string fileType = fn.Substring(fn.LastIndexOf(".") + 1);
            this.fileType = fileType;
            if (fileType.ToLower().Equals("wav") || fileType.ToLower().Equals("mp3") || fileType.ToLower().Equals("wma"))
                return true;
            return false;
              
        }
    }
}
