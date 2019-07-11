namespace checkMusic
{
    partial class checkFile
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.leaveRecord = new System.Windows.Forms.Label();
            this.record = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.textBoxLeaveRecord = new System.Windows.Forms.TextBox();
            this.textBoxRecord = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxLogCollect = new System.Windows.Forms.TextBox();
            this.textBoxCheckFileIntervial = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // leaveRecord
            // 
            this.leaveRecord.AutoSize = true;
            this.leaveRecord.Location = new System.Drawing.Point(51, 41);
            this.leaveRecord.Name = "leaveRecord";
            this.leaveRecord.Size = new System.Drawing.Size(29, 12);
            this.leaveRecord.TabIndex = 0;
            this.leaveRecord.Text = "留言";
            // 
            // record
            // 
            this.record.AutoSize = true;
            this.record.Location = new System.Drawing.Point(51, 100);
            this.record.Name = "record";
            this.record.Size = new System.Drawing.Size(29, 12);
            this.record.TabIndex = 1;
            this.record.Text = "录音";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(53, 197);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "开始";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBoxLeaveRecord
            // 
            this.textBoxLeaveRecord.Location = new System.Drawing.Point(108, 41);
            this.textBoxLeaveRecord.Name = "textBoxLeaveRecord";
            this.textBoxLeaveRecord.Size = new System.Drawing.Size(320, 21);
            this.textBoxLeaveRecord.TabIndex = 3;
            this.textBoxLeaveRecord.Text = "C:\\Esunnet";
            this.textBoxLeaveRecord.TextChanged += new System.EventHandler(this.textBoxLeaveRecord_TextChanged);
            // 
            // textBoxRecord
            // 
            this.textBoxRecord.Location = new System.Drawing.Point(108, 97);
            this.textBoxRecord.Name = "textBoxRecord";
            this.textBoxRecord.Size = new System.Drawing.Size(320, 21);
            this.textBoxRecord.TabIndex = 4;
            this.textBoxRecord.Text = "C:\\Esunnet";
            this.textBoxRecord.TextChanged += new System.EventHandler(this.textBoxRecord_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(51, 133);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(143, 12);
            this.label1.TabIndex = 5;
            this.label1.Text = "日志收集间隔(最大500)：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(53, 163);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(269, 12);
            this.label2.TabIndex = 6;
            this.label2.Text = "文件检测时间间隔(大于日志必须大于收集时间)：";
            // 
            // textBoxLogCollect
            // 
            this.textBoxLogCollect.Location = new System.Drawing.Point(201, 123);
            this.textBoxLogCollect.Name = "textBoxLogCollect";
            this.textBoxLogCollect.Size = new System.Drawing.Size(100, 21);
            this.textBoxLogCollect.TabIndex = 7;
            this.textBoxLogCollect.TextChanged += new System.EventHandler(this.logCollect);
            // 
            // textBoxCheckFileIntervial
            // 
            this.textBoxCheckFileIntervial.Location = new System.Drawing.Point(328, 154);
            this.textBoxCheckFileIntervial.Name = "textBoxCheckFileIntervial";
            this.textBoxCheckFileIntervial.Size = new System.Drawing.Size(100, 21);
            this.textBoxCheckFileIntervial.TabIndex = 8;
            this.textBoxCheckFileIntervial.TextChanged += new System.EventHandler(this.textBoxCheckFileIntervial_TextChanged);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(508, 235);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 9;
            this.button2.Text = "文本转换";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // checkFile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(890, 315);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.textBoxCheckFileIntervial);
            this.Controls.Add(this.textBoxLogCollect);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxRecord);
            this.Controls.Add(this.textBoxLeaveRecord);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.record);
            this.Controls.Add(this.leaveRecord);
            this.Name = "checkFile";
            this.Text = "文件大小检查";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.checkFile_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label leaveRecord;
        private System.Windows.Forms.Label record;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBoxLeaveRecord;
        private System.Windows.Forms.TextBox textBoxRecord;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxLogCollect;
        private System.Windows.Forms.TextBox textBoxCheckFileIntervial;
        private System.Windows.Forms.Button button2;
    }
}

