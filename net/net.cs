using net.callOut;
using net.PingTools;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace net
{
    public partial class net : Form
    {
        public net()
        {
            InitializeComponent();
        }
       
        private void buttonStartPing_Click(object sender, EventArgs e)
        {
             if (!string.IsNullOrEmpty(textBoxPinGintervial.Text.Trim()))
            PingTools.PingTools.sleepTime = System.Convert.ToInt32(textBoxPinGintervial.Text.Trim());
             if (!string.IsNullOrEmpty(textBoxTimeOut.Text.Trim()))
                PingTools.PingTools.setTimeout(System.Convert.ToInt32(textBoxTimeOut.Text.Trim()));
             if (string.IsNullOrEmpty(textBoxIPs.Text.Trim()))
               return;
            ThreadPing tp = new ThreadPing();
            tp.startPingThread(textBoxIPs.Text.Trim());
        }
 

        private void textBoxPinGintervial_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBoxPinGintervial.Text.Trim()))
            PingTools.PingTools.sleepTime = System.Convert.ToInt32(textBoxPinGintervial.Text.Trim());
        }

        private void textBoxTimeOut_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBoxTimeOut.Text.Trim()))
                PingTools.PingTools.setTimeout(System.Convert.ToInt32(textBoxTimeOut.Text.Trim()));
        }

        private void net_FormClosing(object sender, FormClosingEventArgs e)
        {
            System.Environment.Exit(0);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            callout.Text = "外呼接口已开启";
            callOutThread cat = new callOutThread();

        }
    }
}
