using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace tools.File
{
    /// <summary>
    /// 数据区
    /// </summary> 
    class Data_Chunk
    { /// <summary>
        /// 文件前四个字节 为RIFF
        /// </summary>
        public byte[] ID = new byte[] { 0x64, 0x61, 0x74, 0x61 };   // 'd','a','t','a'
        /// <summary>
        /// 大小
        /// </summary>
        public uint Size = 0;
        /// <summary>
        /// 开始播放的位置
        /// </summary>
        public long FileBeginIndex = 0;
        /// <summary>
        /// 结束播放的位置
        /// </summary>
        public long FileOverIndex = 0;
    }
}
