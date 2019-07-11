using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace tools.File
{
    /// <summary>
    /// 声音内容定义
    /// </summary> 
    class Format_Chunk
    {
        /// <summary>
        /// 固定为  是"fmt "字后一位为0x20
        /// </summary>
        public byte[] ID = new byte[] { 0x66, 0x6D, 0x74, 0x20 };
        /// <summary>
        /// 区域大小
        /// </summary>
        public uint Size = 0;
        /// <summary>
        /// 记录着此声音的格式代号，例如1-WAVE_FORMAT_PCM， 2-WAVE_F0RAM_ADPCM等等。 
        /// </summary>
        public ushort FormatTag = 1;
        /// <summary>
        /// 声道数目，1--单声道；2--双声道
        /// </summary>
        public ushort Channels = 2;
        /// <summary>
        /// 采样频率  一般有11025Hz（11kHz）、22050Hz（22kHz）和44100Hz（44kHz）三种
        /// </summary>
        public uint SamlesPerSec = 0;
        /// <summary>
        /// 每秒所需字节数
        /// </summary>
        public uint AvgBytesPerSec = 0;
        /// <summary>
        /// 数据块对齐单位(每个采样需要的字节数)
        /// </summary>
        public ushort BlockAlign = 0;
        /// <summary>
        /// 音频采样大小 
        /// </summary>
        public ushort BitsPerSample = 0;
        /// <summary>
        /// ???
        /// </summary>
        public byte[] Temp = new byte[2];
    }
}
