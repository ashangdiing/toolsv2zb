
using queryRecord;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
namespace queryRecord
{
    public partial class Login : Form
    {
        public static System.Util.DataBase db;public QueryForm qf;
        public Login()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            this.label2.Text = "        logining.......   Please wait ";
            loginHandel();
        //    MessageBox.Show("ss", "kon");
            if (!loginReadDB()) {
                MessageBox.Show("登陆失败","数据库访问失败....请检查数据库配置");
                return;    
            }
            db.command.Parameters.Add("@AgentID",SqlDbType.NChar);
            db.command.Parameters["@AgentID"].Value = this.agent;
            System.Data.SqlClient.SqlDataReader userInfo = db.queryData("SELECT ad.TS_ADMIN_ID,TS_ADMIN_NAME,TS_PASSWORD,TS_MODULE_ID FROM [Esunnet].[dbo].[TS_ADMIN] ad left join [TS_ADMIN_RIGHT] r on ad.TS_ADMIN_ID=r.TS_ADMIN_ID where r.TS_ADMIN_ID=@AgentID");
           if (!userInfo.HasRows)
           {
               MessageBox.Show("用户名不存在", "警告");
             return ;}
          // userInfo.Read();
           string PWFromDB=""; int right;
           while (userInfo.Read()) {
                PWFromDB = userInfo["TS_PASSWORD"].ToString();
               right = Convert.ToInt32(userInfo["TS_MODULE_ID"].ToString());
               if (right == 12)
                   QueryForm.canPlay = true;
               if (right == 1)
                   QueryForm.canDown = true;
           }
           db.closeDataBase();
           if (!PWFromDB.Equals(agentPassword)) {
               MessageBox.Show("密码错误","警告");
               return;
           }
          
          
       
            this.Visible = false;
            qf = new  QueryForm();
          //  mf.Owner = this;
            qf.ShowDialog();
          //  this.Show(mf);
        }
        

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click_1(object sender, EventArgs e)
        {

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
        // 关闭
        private void process1_Exited(object sender, EventArgs e)
        {
            this.label2.Text = "++++";
           
        }
        //取消
        private void button2_Click(object sender, EventArgs e)
        {
        
            this.Close();
        }
        public void loginHandel()
        {
            this.agent = this.agentTextBox.Text;
            this.agentPassword =this. agentPasswordTextBox.Text;
            this.dataBaseType = this.DBTypeComboBox.ValueMember;
            this.dataBaseServerIP = this.DBServerIPTextBox.Text;
            this.dataBaseUser = this.DBUserTextBox.Text;
            this.dataBasePassword = this.DBPasswordTextBox.Text;
            this.meetServIP = this.meetServIPTextBox.Text;
            this.meetServPort = this.meetServPortTextBox.Text;
            this.dataBase = this.DBTextBox.Text;
        }
        public bool loginReadDB(){
       //     db = new System.Util.DataBase(dataBaseServerIP, dataBase, dataBaseUser, dataBasePassword); 
            db = new System.Util.DataBase();
            return db.init();
        }

        private void Login_FormClosing(object sender, FormClosingEventArgs e)
        {
            System.Environment.Exit(0);
        }
    }
}
