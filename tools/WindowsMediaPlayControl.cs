using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace tools
{
    public delegate void isEndEvent();
    public partial class WindowsMediaPlayControl : Form
    {

       
        public WindowsMediaPlayControl()
        {
            InitializeComponent();
        }
        public  AxWMPLib.AxWindowsMediaPlayer getAxWindowsMediaPlayer(){
            //1=停止，2=暂停，3=播放，6=正在缓冲，8=播放完毕 9=正在连接，10=准备就绪 
            return axWindowsMediaPlayer;
        }

        private void WindowsMediaPlayControl_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            axWindowsMediaPlayer.Ctlcontrols.stop();
            e.Cancel = true;
        }

       
      
    }
}
