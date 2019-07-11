using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace tools.File
{
    /// <summary>
    /// FACT
    /// </summary> 
    class Fact_Chunk
    {
        /// <summary>
        /// 文件前四个字节 为fact
        /// </summary>
        public byte[] ID = new byte[] { 0x66, 0x61, 0x63, 0x74 };   // 'f','a','c','t'
        /// <summary>
        /// 数据大小
        /// </summary>
        public uint Size = 0;
        /// <summary>
        /// 临时数据
        /// </summary>
        public byte[] Temp;

    }
}
