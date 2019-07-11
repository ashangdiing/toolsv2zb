using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace tools.File
{
    class RIFF_WAVE_Chunk
    {////文件头定义
        /// <summary>
        /// 文件前四个字节 为RIFF  
        /// </summary>
        public byte[] szRiffID = new byte[] { 0x52, 0x49, 0x46, 0x46 };   // 'R','I','F','F'
        /// <summary>
        /// 数据大小 这个数字等于+8 =文件大小
        /// </summary>
        public uint dwRiffSize = 0;
        /// <summary>
        ///WAVE文件定义 为WAVE
        /// </summary>
        public byte[] szRiffFormat = new byte[] { 0x57, 0x41, 0x56, 0x45 }; // 'W','A','V','E'         
       
    }
}
