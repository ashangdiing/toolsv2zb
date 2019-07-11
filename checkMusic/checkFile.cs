using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace checkMusic
{
    public partial class checkFile : Form
    {
       
        static string LeavePath, RecordPath;
        Thread recordThread, leaveThread;
        public checkFile()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            if (!Init())
            MessageBox.Show("初始化失败");
          
           startThread();

        }

        private void startThread()
        {
            tools.log.Debug("线程开始"); 
            CheckFileThread cft = new CheckFileThread();
            
            
            if(!string.IsNullOrEmpty(LeavePath)){
                recordThread = new Thread(cft.checkLeaveFile);
             recordThread.Start();
            }
            return;
            if (!string.IsNullOrEmpty(RecordPath))
            {
                leaveThread = new Thread(cft.checkRecordFile);
                 leaveThread.Start();
            }

        }

        public  bool Init(){
            LeavePath = getProperty.getLeavePath(); RecordPath = getProperty.getRecordPath();
            return true;
         if (string.IsNullOrEmpty(this.textBoxLeaveRecord.Text) && string.IsNullOrEmpty(this.textBoxRecord.Text))
         {
             return false;
        }
        
            if (string.IsNullOrEmpty(LeavePath)) {
                getProperty.setLeavePath(this.textBoxLeaveRecord.Text);
            } else
                this.textBoxLeaveRecord.Text = getProperty.getLeavePath();
            if (string.IsNullOrEmpty(RecordPath))
            {
                getProperty.setLeavePath(this.textBoxRecord.Text);
            }else 
             this.textBoxRecord.Text = getProperty.getRecordPath();

            return true;
        }

        private void logCollect(object sender, EventArgs e)
        {
            string  intervialTime="10";
            if (!string.IsNullOrEmpty(textBoxLogCollect.Text.ToString().Trim()))
            {
                intervialTime = textBoxLogCollect.Text.ToString().Trim();
                tools.logThread.sleepTime = Convert.ToInt32(intervialTime);
            }
        }

        private void textBoxCheckFileIntervial_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBoxCheckFileIntervial.Text.ToString().Trim()))
            {
                string checkFileIntervial = "10";
                checkFileIntervial = textBoxCheckFileIntervial.Text.ToString().Trim();
                CheckFileThread.checkFileIntervial = Convert.ToInt32(checkFileIntervial);
            }
        }

        private void checkFile_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (recordThread != null)
            recordThread.Abort();
            if (leaveThread != null)
            leaveThread.Abort();
            if (tools.log.logThread!= null)
            tools.logThread.logFlag=false;
        }

        private void textBoxLeaveRecord_TextChanged(object sender, EventArgs e)
        {
           
           if (new DirectoryInfo(textBoxLeaveRecord.Text.ToString().Trim()).Exists)
               getProperty.setLeavePath( textBoxLeaveRecord.Text.ToString().Trim());
        }

        private void textBoxRecord_TextChanged(object sender, EventArgs e)
        {

            if (new DirectoryInfo(textBoxRecord.Text.ToString().Trim()).Exists)
                getProperty.setRecordPath(textBoxRecord.Text.ToString().Trim());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string path=textBoxLeaveRecord.Text.ToString().Trim();
            TextChangeThread tct = new TextChangeThread();
            tct.txtFileName = path;
            new Thread(tct.Read).Start();
        }
    }
}
