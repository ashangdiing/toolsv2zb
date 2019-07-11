using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using tools;

namespace queryRecord
{
    public partial class QueryForm : Form
    {
        public String callTypeCondition, extCondition, callerCondition, calledCondition, agentCondition,
            starttimeCondition, endTimeCondition, tallTimeMinCondition, tallTimeMaxCondition, extTypeCondition, totalPageCondition,
            sqlWhere,sqlCountWhere, pageWhere; int pageSizeCondition, pageCondition,beginNumber,endNumber;public static bool querying=false,canPlay=false,canDown=false;
        private bool RemoveImpuritiesCondition=false;
        private RecordDataBase rdb; private List<RecordRow> lrecords;
        private static AxWMPLib.AxWindowsMediaPlayer axWindowsMediaPlayer;static  WindowsMediaPlayControl wmc;
        public static string ApplicationPath = System.AppDomain.CurrentDomain.BaseDirectory.ToString();
        public static String getRecordRemoteUri = System.Configuration.ConfigurationManager.AppSettings["GetRecordUrl"];
        public QueryForm()
        {
            InitializeComponent();
            Loaderinit();
        }
       
        private void buttonQuery_Click(object sender, EventArgs e)
        {
            getCondition();
        }
        public void Loaderinit(){
            //以下2句一起设置全屏
            //this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized; 
            dateTimePickerStartTime.Value = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-01") + " 00:00:00");
          //  dateTimePickerStartTime.Value = Convert.ToDateTime("2013-01-01 00:00:00");
            dateTimePickerEndTime.Value = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd") + " 23:59:59");
            comboBoxExtType.Text = "数字";
            getCondition();
        }
        public void getCondition(){
            this.Enabled = false;
            this.labelState.Text = "查询中";
            dataGridViewQueryResult.Rows.Clear();
            RemoveImpuritiesCondition = false;
            callTypeCondition = extCondition = callerCondition = calledCondition = agentCondition = starttimeCondition = endTimeCondition = tallTimeMinCondition = tallTimeMaxCondition = extTypeCondition = sqlWhere = pageWhere = sqlCountWhere = totalPageCondition = "";
             beginNumber=endNumber=pageSizeCondition=pageCondition=0;
            sqlWhere = "SELECT    ROW_NUMBER() over(order by [TS_START_TIME] desc) as rows,* FROM (select *,datediff(SS,TS_START_TIME,TS_END_TIME) as talkTime,case when len(TS_IP)>0 then 1 else 0 end as isIP from  [Esunnet].[dbo].[TS_REC_LOG]) resource where";
            pageWhere = ") sort where rows between ";
            sqlCountWhere = "select count(*) from   (select *,datediff(SS,TS_START_TIME,TS_END_TIME) as talkTime,case when len(TS_IP)>0 then 1 else 0 end as isIP from  [Esunnet].[dbo].[TS_REC_LOG]) resource where ";
           // MessageBox.Show(comboBoxCallType.SelectedItem.ToString());
            if (!String.IsNullOrEmpty(dateTimePickerStartTime.Value.ToString()))
                starttimeCondition = dateTimePickerStartTime.Value.ToString("yyyy-MM-dd HH:mm:ss");
            if (!String.IsNullOrEmpty(dateTimePickerEndTime.Value.ToString()))
                endTimeCondition = dateTimePickerEndTime.Value.ToString("yyyy-MM-dd HH:mm:ss");
            sqlWhere = sqlWhere + " TS_START_TIME>='" + starttimeCondition+"'";
            sqlWhere = sqlWhere + " and  TS_START_TIME<='" + endTimeCondition+"'";
            sqlCountWhere = sqlCountWhere + " TS_START_TIME>='" + starttimeCondition + "'";
            sqlCountWhere = sqlCountWhere + "and TS_START_TIME<='" + endTimeCondition + "'";
             callTypeCondition = getComboBoxValue(comboBoxCallType);
                extCondition = getComboBoxValue(comboBoxExt);
                callerCondition = textBoxCaller.Text.ToString();
                calledCondition = textBoxCalled.Text.ToString();
                if (!String.IsNullOrEmpty(textBoxCaller.Text.ToString()))
                {
                    sqlWhere = sqlWhere + " and  TS_CALLER like '%" + callerCondition + "%'";
                    sqlCountWhere = sqlCountWhere + " and  TS_CALLER like '%" + callerCondition + "%'";
                }
                if (!String.IsNullOrEmpty(textBoxCalled.Text.ToString()))
                {
                    sqlWhere = sqlWhere + " and  TS_CALLED like '%" + calledCondition + "%'";
                    sqlCountWhere = sqlCountWhere + " and  TS_CALLED like '%" + calledCondition + "%'";
                }
                RemoveImpuritiesCondition = checkBoxrRemoveImpurities.Checked;
                if (RemoveImpuritiesCondition == true) {
                    sqlWhere = sqlWhere + " and  len(TS_CALL_ID)>0";
                    sqlCountWhere = sqlCountWhere + "and  len(TS_CALL_ID)>0";
                }
            agentCondition = getComboBoxValue(comboBoxAgent);
            extTypeCondition = getComboBoxValue(comboBoxExtType);
              tallTimeMinCondition = getComboBoxValue(comboBoxMin);
              tallTimeMaxCondition = getComboBoxValue(comboBoxMax);
              if (callTypeCondition != null)
              {
                  if (callTypeCondition == "呼入")
                      callTypeCondition = "0";
                  else callTypeCondition = "3";
                  sqlWhere = sqlWhere + " and  TS_TYPE =" + callTypeCondition;
                  sqlCountWhere = sqlCountWhere + " and  TS_TYPE =" + callTypeCondition;
              }
              if (extCondition != null)
              {
                  sqlWhere = sqlWhere + " and  TS_NUMBER like '%" + extCondition + "%'";
                  sqlCountWhere = sqlCountWhere + " and  TS_NUMBER like '%" + extCondition + "%'";
              }

              if (agentCondition != null)
              {
                  sqlWhere = sqlWhere + " and  TS_AGENT_ID like '%" + agentCondition + "%'";
                  sqlCountWhere = sqlCountWhere + " and  TS_AGENT_ID like '%" + agentCondition + "%'";
              }
              if (extTypeCondition != null)
              {
                  if (extTypeCondition == "IP") 
                      extTypeCondition = "1"; 
                  else extTypeCondition = "0";
                  sqlWhere = sqlWhere + " and  isIP ='" + extTypeCondition + "'";
                  sqlCountWhere = sqlCountWhere + " and  isIP ='" + extTypeCondition + "'"; 
              }
              if (tallTimeMinCondition != null)
              {
                  sqlWhere = sqlWhere + " and  talkTime > " + tallTimeMinCondition;
                  sqlCountWhere = sqlCountWhere + " and  talkTime > " + tallTimeMinCondition;
              }
              if (tallTimeMaxCondition != null)
              {
                  sqlWhere = sqlWhere + " and  talkTime <" + tallTimeMaxCondition  ;
                  sqlCountWhere = sqlCountWhere + " and  talkTime <" + tallTimeMaxCondition  ;
              }
              pageSizeCondition =Convert.ToInt32(getComboBoxValue(comboBoxPageSize));
              if (pageSizeCondition == 0)
                  pageSizeCondition = 30;
           rdb = new RecordDataBase();
           int total=0;
           //获取到总页数
           total = rdb.getTotalRecord(sqlCountWhere);
           label1Total.Text = "页"+total+"条";
           if (total % pageSizeCondition == 0)
               totalPage.Text = totalPageCondition = total/pageSizeCondition + "";
           else totalPage.Text = totalPageCondition = total / pageSizeCondition+1 + "";
           if (String.IsNullOrEmpty(textBoxPage.Text.ToString()))
               pageCondition=1;
           
           pageCondition = Convert.ToInt32(textBoxPage.Text);
            //大于总页数
           if (Convert.ToInt32(textBoxPage.Text.ToString()) > Convert.ToInt32(totalPage.Text))
           { textBoxPage.Text = totalPage.Text;
           pageCondition = Convert.ToInt32(textBoxPage.Text);
           }
           if (Convert.ToInt32(textBoxPage.Text.ToString()) < 1)
           {
               textBoxPage.Text ="1";
               pageCondition = Convert.ToInt32(textBoxPage.Text);
           }
           beginNumber = pageSizeCondition * (pageCondition - 1) + 1;
           endNumber = pageSizeCondition * pageCondition;
           pageWhere = pageWhere + beginNumber + " and  " + endNumber;

           lrecords = rdb.getRecords("select * from  ( " + sqlWhere + pageWhere);
           if (lrecords!=null)
            dataGridViewQueryResult.Rows.AddRange(lrecords.ToArray());
               String sql = sqlWhere + pageWhere;
               String sqlcount = sqlCountWhere;
            //   MessageBox.Show(tools.logThread.ApplicationPath);
           //    MessageBox.Show(sqlcount);
               this.Enabled = true;
               this.labelState.Text = "正常";
        }
        public static String getComboBoxValue(ComboBox c)
        {
            if (c.SelectedIndex != -1)
                return c.SelectedItem.ToString();
            if(!String.IsNullOrEmpty(c.Text))
                return c.Text;
            return null;
        }
        private void pPage_Click(object sender, EventArgs e)
        {
            getCondition();
            pageCondition = Convert.ToInt32(textBoxPage.Text);
            if (pageCondition>1)
            pageCondition--;
            textBoxPage.Text = pageCondition+"";
        }
        private void button2_Click(object sender, EventArgs e)
        {
            getCondition();
            pageCondition = Convert.ToInt32(textBoxPage.Text);
            if (pageCondition < Convert.ToInt32(totalPageCondition))
            pageCondition++;
            textBoxPage.Text = pageCondition + "";
        }
        private void dataGridViewQueryResult_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;
            if (e.ColumnIndex < 0)
                return;
            DataGridView dataGridViewQueryResult = sender as DataGridView;
            if (e.ColumnIndex == 1)
            {
                if (dataGridViewQueryResult[e.ColumnIndex, e.RowIndex].Value==null)
                    dataGridViewQueryResult[e.ColumnIndex, e.RowIndex].Value = 1;
                else dataGridViewQueryResult[e.ColumnIndex, e.RowIndex].Value =null;
            }
            if (e.ColumnIndex == 10)
            {
                if (!canPlay)
                    return;
            //    System.Diagnostics.Process.Start("D:\\music\\Michael Jackson - Bad (Remastered).mp3");
             // System.Diagnostics.Process process = new System.Diagnostics.Process();
             // process.StartInfo.CreateNoWindow = true;
             // process.StartInfo.FileName = "D:\\music\\Michael Jackson - Bad (Remastered).mp3";
              //process.Start();
              //process.Close();
                //初始化media
                getAxWindowsMediaPlayer();
                if (axWindowsMediaPlayer.currentPlaylist.count >1000)
                    axWindowsMediaPlayer.currentPlaylist.clear();
                String callid = dataGridViewQueryResult[12, e.RowIndex].Value.ToString().Trim();
                if (String.IsNullOrEmpty(callid))
                {
                //    tools.log.Debug("无caiiid");
                    playMusic(downPlayFile(dataGridViewQueryResult[13, e.RowIndex].Value.ToString().Trim()));
                    return;
                }
            //    MessageBox.Show(callid);
                //添加media播放完事件
                List<string> ltids=rdb.getRecordTsids(callid,null);
                playMusic(downPlayFile(ltids[0]));
                //如果存在转接录音添加到后面
                if (ltids.Count > 1)
                {
                    addPlayList(downPlayFile(ltids[1]));
                }
            }
            if(e.ColumnIndex==11){
                if (!canDown)
                    return;
                String callid = dataGridViewQueryResult[12, e.RowIndex].Value.ToString().Trim();
                List<string> ltids = rdb.getRecordTsids(callid,null);
                if (ltids.Count < 1)
                    ltids.Add(dataGridViewQueryResult[13, e.RowIndex].Value.ToString().Trim());
                downFiles(ltids);
            }
        }
        private String downPlayFile(String tid)
        {
          //  tools.log.Debug("听：将下载》" + tid);
            DirectoryInfo logDirectory = new DirectoryInfo(ApplicationPath + "\\downPlayFile");
            String localpath="";
            if (!logDirectory.Exists)
            {
                logDirectory.Create();
                DirectoryInfo di = new DirectoryInfo(logDirectory.FullName);
                di.Attributes = di.Attributes | FileAttributes.Hidden;
            }
            System.Net.WebClient myWebClient = new System.Net.WebClient();
            String RemoteUri = getRecordRemoteUri + "?tid=" + tid;
                localpath=logDirectory.FullName +"\\"+ tid+".wav";
                if (!IsFileInUse(localpath))
                {
                    myWebClient.DownloadFile(RemoteUri, localpath);
                }
            return localpath;
        }

        private String downFiles(List<String> tids)
        {
            if (tids.Count == 0)
                return null;
           DirectoryInfo DownDirectory = new DirectoryInfo(ApplicationPath + "\\recdownFile");
           if (!DownDirectory.Exists)
               DownDirectory.Create();
            saveFileDialog.Filter = "录音文件（*.wav）|*.wav|批量下载压缩文件（*.zip）|*.zip";
            saveFileDialog.FilterIndex = 1;
            saveFileDialog.RestoreDirectory = true;
         //   MessageBox.Show(saveFileDialog.FileName);
           // saveFileDialog.ShowDialog();
            String stids = "";
            foreach(string tid in tids){
                stids.Trim();
                stids = stids+"tid=" + tid+"&";
                stids.Trim();
            }
            stids=stids.Remove(stids.LastIndexOf("&"), 1);
            String RemoteUri = getRecordRemoteUri + "?type=download&" + stids;
            tools.log.Debug("下载》" + RemoteUri);
         //   MessageBox.Show(RemoteUri);
          //  if (tids.Count > 1)
            //    saveFileDialog.FileName = DownDirectory.FullName + "\\record.zip";
            //else saveFileDialog.FileName = DownDirectory.FullName + "\\record.wav";
            saveFileDialog.CheckPathExists = true;
            //MessageBox.Show(saveFileDialog.FileName);
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                System.Net.WebClient myWebClient = new System.Net.WebClient();
                myWebClient.DownloadFile(RemoteUri, saveFileDialog.FileName);
            }
            return saveFileDialog.FileName;
        }

        private void playMusic(String mediaPath)
        {
           
           //   axWindowsMediaPlayer.currentPlaylist.clear();
            WMPLib.IWMPMedia Media = axWindowsMediaPlayer.newMedia(mediaPath);
            axWindowsMediaPlayer.currentPlaylist.appendItem(Media); 
         //   tools.log.Debug("播放列表添加了一首》" + Media.sourceURL +"当前状态："+axWindowsMediaPlayer.playState.ToString());
          //  axWindowsMediaPlayer.currentMedia.setItemInfo("Title", "录音播放");
               // axWindowsMediaPlayer.settings.autoStart = true;
        
        // axWindowsMediaPlayer.playState.ToString().LastIndexOf("Ready") > 0
                axWindowsMediaPlayer.Ctlcontrols.play();
                axWindowsMediaPlayer.Ctlcontrols.next();
            //    tools.log.Debug("播放列表数量》" + axWindowsMediaPlayer.currentPlaylist.count + "markerCount" + axWindowsMediaPlayer.currentMedia.markerCount + "attributeCount" + axWindowsMediaPlayer.currentMedia.attributeCount + "durationString" + axWindowsMediaPlayer.currentMedia.durationString);
            wmc.Visible = true;
            wmc.TopMost=true;
             //   
           
        }
        private void addPlayList(String mediaPath)
        {
           
            WMPLib.IWMPMedia Media = axWindowsMediaPlayer.newMedia(mediaPath);
            axWindowsMediaPlayer.currentPlaylist.appendItem(Media);
        }
        private static void axWindowsMediaPlayer_PlayStateChange(object sender, AxWMPLib._WMPOCXEvents_PlayStateChangeEvent e)
        {
            //1=停止，2=暂停，3=播放，6=正在缓冲，8=播放完毕 9=正在连接，10=准备就绪
         //   MessageBox.Show(axWindowsMediaPlayer.playState+"");
        
            if (e.newState == 3)
            {
             
            }
        }
        public static  AxWMPLib.AxWindowsMediaPlayer getAxWindowsMediaPlayer(){
            if (axWindowsMediaPlayer == null)
            {
                 wmc = new WindowsMediaPlayControl();
                axWindowsMediaPlayer = wmc.getAxWindowsMediaPlayer();
                axWindowsMediaPlayer.PlayStateChange += new AxWMPLib._WMPOCXEvents_PlayStateChangeEventHandler(axWindowsMediaPlayer_PlayStateChange);
                wmc.Show();
            }
            return axWindowsMediaPlayer;
        }
        private void checkBoxAllSelect_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox cb=sender as CheckBox;
            if (cb.Checked)
            {
               // cb.Checked = false;
                foreach (DataGridViewRow dvr in dataGridViewQueryResult.Rows)
                {
                    dvr.Cells[1].Value = 1;
                }
            }
            else { 
               // cb.Checked = true;
                foreach (DataGridViewRow dvr in dataGridViewQueryResult.Rows)
                {
                    dvr.Cells[1].Value =null;
                }
            }
        }
        private void comboBoxPageSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            getCondition();
        }

        private void comboBoxCallType_SelectedIndexChanged(object sender, EventArgs e)
        {
            getCondition();
        }

        private void comboBoxExtType_SelectedIndexChanged(object sender, EventArgs e)
        {
            getCondition();
        }
        public static bool IsFileInUse(string fileName){
                  
            bool inUse = true;
            FileInfo fi = new FileInfo(fileName);
                if (!fi.Exists)
                     return false;
                    FileStream fs = null;
                 try{
                  fs = new FileStream(fileName, FileMode.Open, FileAccess.Read,FileShare.None);
                   fs.Close();
                  }
                 catch (Exception ex)
                 {
                     inUse = true;
                 }
                 return inUse;//true 打开 false 没有打开
        }
        private void deltePlayMusic(String appPath){
            if (axWindowsMediaPlayer != null)
            {
                axWindowsMediaPlayer.Ctlcontrols.stop();
                axWindowsMediaPlayer.Dispose();
            }
            DirectoryInfo logDirectory = new DirectoryInfo(ApplicationPath + "\\downPlayFile");
            if (!logDirectory.Exists) return;
            foreach(FileInfo file in  logDirectory.GetFiles()){
                
                file.Delete();
            }
            
        }
        private void QueryForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            deltePlayMusic(ApplicationPath);
            System.Environment.Exit(0);
        }

        private void checkBoxrRemoveImpurities_CheckedChanged(object sender, EventArgs e)
        {
            getCondition();
        }

        private void buttonDownSelected_Click(object sender, EventArgs e)
        {
            if (!canDown)
                return;
            List<string> ltsids = new List<string>();
            foreach (DataGridViewRow dvr in dataGridViewQueryResult.Rows)
            {
                if (dvr.Cells[1].Value!=null)
                {
                    ltsids.Add(dvr.Cells[13].Value.ToString().Trim());
                }
            }
            downFiles(ltsids);
        }

        private void buttonDownQuery_Click(object sender, EventArgs e)
        {
            if (!canDown)
                return;
            getCondition();
            string sqlnopage = sqlWhere;
            downFiles(rdb.getRecordTsids(null, sqlWhere));
        }

        /*
    select * from  (SELECT    ROW_NUMBER() over(order by [TS_START_TIME]) as rows,* FROM [Esunnet].[dbo].[TS_REC_LOG] where
	1=1 and len(TS_CALL_ID)>0 
	) sort where rows between 1*10+1 and 2*10
         */

    }
}
