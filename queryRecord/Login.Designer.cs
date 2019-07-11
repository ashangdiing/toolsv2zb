
namespace queryRecord
{
    partial class Login
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.agent_Label = new System.Windows.Forms.Label();
            this.agentTextBox = new System.Windows.Forms.TextBox();
            this.agentPasswordTextBox = new System.Windows.Forms.TextBox();
            this.pass_word_label = new System.Windows.Forms.Label();
            this.loginButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.cancelButton = new System.Windows.Forms.Button();
            this.optionButton = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.DBUserTextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.DBTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.DBPasswordTextBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.DBServerIPTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.DBTypeComboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.meetServPortTextBox = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.meetServIPTextBox = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // agent_Label
            // 
            this.agent_Label.AutoSize = true;
            this.agent_Label.Location = new System.Drawing.Point(55, 27);
            this.agent_Label.Name = "agent_Label";
            this.agent_Label.Size = new System.Drawing.Size(41, 12);
            this.agent_Label.TabIndex = 0;
            this.agent_Label.Text = "工号：";
            // 
            // agentTextBox
            // 
            this.agentTextBox.Location = new System.Drawing.Point(126, 24);
            this.agentTextBox.Name = "agentTextBox";
            this.agentTextBox.Size = new System.Drawing.Size(206, 21);
            this.agentTextBox.TabIndex = 1;
            this.agentTextBox.Text = "admin";
            // 
            // agentPasswordTextBox
            // 
            this.agentPasswordTextBox.Location = new System.Drawing.Point(126, 59);
            this.agentPasswordTextBox.Name = "agentPasswordTextBox";
            this.agentPasswordTextBox.PasswordChar = '*';
            this.agentPasswordTextBox.Size = new System.Drawing.Size(203, 21);
            this.agentPasswordTextBox.TabIndex = 1;
            this.agentPasswordTextBox.Text = "admin";
            // 
            // pass_word_label
            // 
            this.pass_word_label.AutoSize = true;
            this.pass_word_label.Location = new System.Drawing.Point(55, 59);
            this.pass_word_label.Name = "pass_word_label";
            this.pass_word_label.Size = new System.Drawing.Size(41, 12);
            this.pass_word_label.TabIndex = 0;
            this.pass_word_label.Text = "密码：";
            // 
            // loginButton
            // 
            this.loginButton.Location = new System.Drawing.Point(46, 96);
            this.loginButton.Name = "loginButton";
            this.loginButton.Size = new System.Drawing.Size(60, 23);
            this.loginButton.TabIndex = 1;
            this.loginButton.Text = "登陆";
            this.loginButton.UseVisualStyleBackColor = true;
            this.loginButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(44, 131);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(293, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "------------------------------------------------";
            this.label2.Click += new System.EventHandler(this.label2_Click_1);
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(165, 96);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(60, 23);
            this.cancelButton.TabIndex = 2;
            this.cancelButton.Text = "取消";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.button2_Click);
            // 
            // optionButton
            // 
            this.optionButton.Location = new System.Drawing.Point(269, 96);
            this.optionButton.Name = "optionButton";
            this.optionButton.Size = new System.Drawing.Size(60, 23);
            this.optionButton.TabIndex = 3;
            this.optionButton.Text = "选项>>";
            this.optionButton.UseVisualStyleBackColor = true;
            // 
            // tabControl1
            // 
            this.tabControl1.Alignment = System.Windows.Forms.TabAlignment.Bottom;
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(46, 157);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(286, 166);
            this.tabControl1.SizeMode = System.Windows.Forms.TabSizeMode.FillToRight;
            this.tabControl1.TabIndex = 4;
            this.tabControl1.UseWaitCursor = true;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.DBUserTextBox);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.DBTextBox);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.DBPasswordTextBox);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.DBServerIPTextBox);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.DBTypeComboBox);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Location = new System.Drawing.Point(4, 4);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(278, 140);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "数据库设定";
            this.tabPage1.UseVisualStyleBackColor = true;
            this.tabPage1.UseWaitCursor = true;
            this.tabPage1.Click += new System.EventHandler(this.tabPage1_Click);
            // 
            // DBUserTextBox
            // 
            this.DBUserTextBox.Location = new System.Drawing.Point(97, 88);
            this.DBUserTextBox.Name = "DBUserTextBox";
            this.DBUserTextBox.Size = new System.Drawing.Size(175, 21);
            this.DBUserTextBox.TabIndex = 13;
            this.DBUserTextBox.Text = "sa";
            this.DBUserTextBox.UseWaitCursor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(38, 88);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 12;
            this.label5.Text = "用户名：";
            this.label5.UseWaitCursor = true;
            // 
            // DBTextBox
            // 
            this.DBTextBox.Location = new System.Drawing.Point(97, 60);
            this.DBTextBox.Name = "DBTextBox";
            this.DBTextBox.Size = new System.Drawing.Size(175, 21);
            this.DBTextBox.TabIndex = 11;
            this.DBTextBox.Text = "esunnet";
            this.DBTextBox.UseWaitCursor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(26, 63);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 10;
            this.label4.Text = "数据库名：";
            this.label4.UseWaitCursor = true;
            // 
            // DBPasswordTextBox
            // 
            this.DBPasswordTextBox.Location = new System.Drawing.Point(97, 109);
            this.DBPasswordTextBox.Name = "DBPasswordTextBox";
            this.DBPasswordTextBox.PasswordChar = '*';
            this.DBPasswordTextBox.Size = new System.Drawing.Size(175, 21);
            this.DBPasswordTextBox.TabIndex = 11;
            this.DBPasswordTextBox.Text = "esun5005";
            this.DBPasswordTextBox.UseWaitCursor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(50, 112);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 12);
            this.label6.TabIndex = 10;
            this.label6.Text = "密码：";
            this.label6.UseWaitCursor = true;
            // 
            // DBServerIPTextBox
            // 
            this.DBServerIPTextBox.Location = new System.Drawing.Point(97, 36);
            this.DBServerIPTextBox.Name = "DBServerIPTextBox";
            this.DBServerIPTextBox.Size = new System.Drawing.Size(175, 21);
            this.DBServerIPTextBox.TabIndex = 7;
            this.DBServerIPTextBox.Text = "172.20.23.14";
            this.DBServerIPTextBox.UseWaitCursor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 41);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 12);
            this.label3.TabIndex = 6;
            this.label3.Text = "服务器地址：";
            this.label3.UseWaitCursor = true;
            // 
            // DBTypeComboBox
            // 
            this.DBTypeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.DBTypeComboBox.FormattingEnabled = true;
            this.DBTypeComboBox.Items.AddRange(new object[] {
            "MSSQL",
            "SQlSERVER",
            "ORACLE"});
            this.DBTypeComboBox.Location = new System.Drawing.Point(97, 10);
            this.DBTypeComboBox.Name = "DBTypeComboBox";
            this.DBTypeComboBox.Size = new System.Drawing.Size(175, 20);
            this.DBTypeComboBox.TabIndex = 5;
            this.DBTypeComboBox.UseWaitCursor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "数据库类型：";
            this.label1.UseWaitCursor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.meetServPortTextBox);
            this.tabPage2.Controls.Add(this.label8);
            this.tabPage2.Controls.Add(this.meetServIPTextBox);
            this.tabPage2.Controls.Add(this.label7);
            this.tabPage2.Location = new System.Drawing.Point(4, 4);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(278, 140);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "会议服务器";
            this.tabPage2.UseVisualStyleBackColor = true;
            this.tabPage2.UseWaitCursor = true;
            this.tabPage2.Click += new System.EventHandler(this.tabPage2_Click);
            // 
            // meetServPortTextBox
            // 
            this.meetServPortTextBox.Location = new System.Drawing.Point(88, 63);
            this.meetServPortTextBox.Name = "meetServPortTextBox";
            this.meetServPortTextBox.Size = new System.Drawing.Size(175, 21);
            this.meetServPortTextBox.TabIndex = 15;
            this.meetServPortTextBox.Text = "3306";
            this.meetServPortTextBox.UseWaitCursor = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(29, 66);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 12);
            this.label8.TabIndex = 14;
            this.label8.Text = "端口号：";
            this.label8.UseWaitCursor = true;
            // 
            // meetServIPTextBox
            // 
            this.meetServIPTextBox.Location = new System.Drawing.Point(88, 13);
            this.meetServIPTextBox.Name = "meetServIPTextBox";
            this.meetServIPTextBox.Size = new System.Drawing.Size(175, 21);
            this.meetServIPTextBox.TabIndex = 13;
            this.meetServIPTextBox.Text = "127.0.0.1";
            this.meetServIPTextBox.UseWaitCursor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 16);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(77, 12);
            this.label7.TabIndex = 12;
            this.label7.Text = "会议服务器：";
            this.label7.UseWaitCursor = true;
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(389, 335);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.optionButton);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.loginButton);
            this.Controls.Add(this.agentTextBox);
            this.Controls.Add(this.pass_word_label);
            this.Controls.Add(this.agent_Label);
            this.Controls.Add(this.agentPasswordTextBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "调度系统--登陆";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Login_FormClosing);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label agent_Label;
        private System.Windows.Forms.TextBox agentTextBox;
        private System.Windows.Forms.TextBox agentPasswordTextBox;
        private System.Windows.Forms.Label pass_word_label;
        private System.Windows.Forms.Button loginButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button optionButton;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox DBTypeComboBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox DBServerIPTextBox;
        private System.Windows.Forms.TextBox DBTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox DBPasswordTextBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox DBUserTextBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox meetServPortTextBox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox meetServIPTextBox;
        private System.Windows.Forms.Label label7;
        private string agent, agentPassword, dataBaseType, dataBaseServerIP, dataBasePassword, dataBaseUser, meetServPort, meetServIP, dataBase;
    }
}