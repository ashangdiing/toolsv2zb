namespace testTools
{
    partial class Form1
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
            this.labelOutcalNumber = new System.Windows.Forms.Label();
            this.textBoxOutCallNumber = new System.Windows.Forms.TextBox();
            this.submit = new System.Windows.Forms.Button();
            this.labelstartTime = new System.Windows.Forms.Label();
            this.labelplan = new System.Windows.Forms.Label();
            this.labeltimeoutTime = new System.Windows.Forms.Label();
            this.labelTimes = new System.Windows.Forms.Label();
            this.dateTimePickerStartTime = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerPlanTime = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerTimeOut = new System.Windows.Forms.DateTimePicker();
            this.numericUpDownTimes = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxIVRURL = new System.Windows.Forms.TextBox();
            this.display = new System.Windows.Forms.TextBox();
            this.clear = new System.Windows.Forms.Button();
            this.query = new System.Windows.Forms.Button();
            this.insert = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTimes)).BeginInit();
            this.SuspendLayout();
            // 
            // labelOutcalNumber
            // 
            this.labelOutcalNumber.AutoSize = true;
            this.labelOutcalNumber.Location = new System.Drawing.Point(44, 30);
            this.labelOutcalNumber.Name = "labelOutcalNumber";
            this.labelOutcalNumber.Size = new System.Drawing.Size(65, 12);
            this.labelOutcalNumber.TabIndex = 0;
            this.labelOutcalNumber.Text = "外呼的号码";
            // 
            // textBoxOutCallNumber
            // 
            this.textBoxOutCallNumber.Location = new System.Drawing.Point(130, 27);
            this.textBoxOutCallNumber.Multiline = true;
            this.textBoxOutCallNumber.Name = "textBoxOutCallNumber";
            this.textBoxOutCallNumber.Size = new System.Drawing.Size(183, 53);
            this.textBoxOutCallNumber.TabIndex = 1;
            this.textBoxOutCallNumber.Text = "018627283312";
            // 
            // submit
            // 
            this.submit.Location = new System.Drawing.Point(393, 56);
            this.submit.Name = "submit";
            this.submit.Size = new System.Drawing.Size(75, 23);
            this.submit.TabIndex = 2;
            this.submit.Text = "submit";
            this.submit.UseVisualStyleBackColor = true;
            this.submit.Click += new System.EventHandler(this.submit_Click);
            // 
            // labelstartTime
            // 
            this.labelstartTime.AutoSize = true;
            this.labelstartTime.Location = new System.Drawing.Point(46, 123);
            this.labelstartTime.Name = "labelstartTime";
            this.labelstartTime.Size = new System.Drawing.Size(53, 12);
            this.labelstartTime.TabIndex = 3;
            this.labelstartTime.Text = "开始时间";
            // 
            // labelplan
            // 
            this.labelplan.AutoSize = true;
            this.labelplan.Location = new System.Drawing.Point(387, 132);
            this.labelplan.Name = "labelplan";
            this.labelplan.Size = new System.Drawing.Size(53, 12);
            this.labelplan.TabIndex = 5;
            this.labelplan.Text = "计划时间";
            // 
            // labeltimeoutTime
            // 
            this.labeltimeoutTime.AutoSize = true;
            this.labeltimeoutTime.Location = new System.Drawing.Point(387, 98);
            this.labeltimeoutTime.Name = "labeltimeoutTime";
            this.labeltimeoutTime.Size = new System.Drawing.Size(53, 12);
            this.labeltimeoutTime.TabIndex = 7;
            this.labeltimeoutTime.Text = "超时时间";
            // 
            // labelTimes
            // 
            this.labelTimes.AutoSize = true;
            this.labelTimes.Location = new System.Drawing.Point(679, 68);
            this.labelTimes.Name = "labelTimes";
            this.labelTimes.Size = new System.Drawing.Size(29, 12);
            this.labelTimes.TabIndex = 9;
            this.labelTimes.Text = "次数";
            // 
            // dateTimePickerStartTime
            // 
            this.dateTimePickerStartTime.CustomFormat = "yyyy-MM-dd HH:mm:sss";
            this.dateTimePickerStartTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerStartTime.Location = new System.Drawing.Point(130, 123);
            this.dateTimePickerStartTime.Name = "dateTimePickerStartTime";
            this.dateTimePickerStartTime.Size = new System.Drawing.Size(200, 21);
            this.dateTimePickerStartTime.TabIndex = 11;
            this.dateTimePickerStartTime.UseWaitCursor = true;
            // 
            // dateTimePickerPlanTime
            // 
            this.dateTimePickerPlanTime.CustomFormat = "yyyy-MM-dd HH:mm:sss";
            this.dateTimePickerPlanTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerPlanTime.Location = new System.Drawing.Point(471, 123);
            this.dateTimePickerPlanTime.Name = "dateTimePickerPlanTime";
            this.dateTimePickerPlanTime.Size = new System.Drawing.Size(200, 21);
            this.dateTimePickerPlanTime.TabIndex = 12;
            this.dateTimePickerPlanTime.UseWaitCursor = true;
            // 
            // dateTimePickerTimeOut
            // 
            this.dateTimePickerTimeOut.CustomFormat = "yyyy-MM-dd HH:mm:sss";
            this.dateTimePickerTimeOut.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerTimeOut.Location = new System.Drawing.Point(471, 89);
            this.dateTimePickerTimeOut.Name = "dateTimePickerTimeOut";
            this.dateTimePickerTimeOut.Size = new System.Drawing.Size(200, 21);
            this.dateTimePickerTimeOut.TabIndex = 13;
            this.dateTimePickerTimeOut.UseWaitCursor = true;
            // 
            // numericUpDownTimes
            // 
            this.numericUpDownTimes.Location = new System.Drawing.Point(779, 59);
            this.numericUpDownTimes.Name = "numericUpDownTimes";
            this.numericUpDownTimes.Size = new System.Drawing.Size(120, 21);
            this.numericUpDownTimes.TabIndex = 15;
            this.numericUpDownTimes.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(44, 95);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 16;
            this.label1.Text = "labelVRURL";
            // 
            // textBoxIVRURL
            // 
            this.textBoxIVRURL.Location = new System.Drawing.Point(130, 86);
            this.textBoxIVRURL.Name = "textBoxIVRURL";
            this.textBoxIVRURL.Size = new System.Drawing.Size(183, 21);
            this.textBoxIVRURL.TabIndex = 17;
            this.textBoxIVRURL.Text = "http://192.168.1.78/ivr/callOutDefault.aspx";
            // 
            // display
            // 
            this.display.Location = new System.Drawing.Point(33, 163);
            this.display.Multiline = true;
            this.display.Name = "display";
            this.display.Size = new System.Drawing.Size(866, 157);
            this.display.TabIndex = 18;
            // 
            // clear
            // 
            this.clear.Location = new System.Drawing.Point(701, 95);
            this.clear.Name = "clear";
            this.clear.Size = new System.Drawing.Size(75, 23);
            this.clear.TabIndex = 19;
            this.clear.Text = "清理";
            this.clear.UseVisualStyleBackColor = true;
            this.clear.Click += new System.EventHandler(this.clear_Click);
            // 
            // query
            // 
            this.query.Location = new System.Drawing.Point(802, 98);
            this.query.Name = "query";
            this.query.Size = new System.Drawing.Size(75, 23);
            this.query.TabIndex = 20;
            this.query.Text = "查询";
            this.query.UseVisualStyleBackColor = true;
            this.query.Click += new System.EventHandler(this.query_Click);
            // 
            // insert
            // 
            this.insert.Location = new System.Drawing.Point(554, 56);
            this.insert.Name = "insert";
            this.insert.Size = new System.Drawing.Size(75, 23);
            this.insert.TabIndex = 21;
            this.insert.Text = "插入";
            this.insert.UseVisualStyleBackColor = true;
            this.insert.Click += new System.EventHandler(this.insert_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(927, 332);
            this.Controls.Add(this.insert);
            this.Controls.Add(this.query);
            this.Controls.Add(this.clear);
            this.Controls.Add(this.display);
            this.Controls.Add(this.textBoxIVRURL);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.numericUpDownTimes);
            this.Controls.Add(this.dateTimePickerTimeOut);
            this.Controls.Add(this.dateTimePickerPlanTime);
            this.Controls.Add(this.dateTimePickerStartTime);
            this.Controls.Add(this.labelTimes);
            this.Controls.Add(this.labeltimeoutTime);
            this.Controls.Add(this.labelplan);
            this.Controls.Add(this.labelstartTime);
            this.Controls.Add(this.submit);
            this.Controls.Add(this.textBoxOutCallNumber);
            this.Controls.Add(this.labelOutcalNumber);
            this.Name = "Form1";
            this.Text = "测试小工具";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTimes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelOutcalNumber;
        private System.Windows.Forms.TextBox textBoxOutCallNumber;
        private System.Windows.Forms.Button submit;
        private System.Windows.Forms.Label labelstartTime;
        private System.Windows.Forms.Label labelplan;
        private System.Windows.Forms.Label labeltimeoutTime;
        private System.Windows.Forms.Label labelTimes;
        private System.Windows.Forms.DateTimePicker dateTimePickerStartTime;
        private System.Windows.Forms.DateTimePicker dateTimePickerPlanTime;
        private System.Windows.Forms.DateTimePicker dateTimePickerTimeOut;
        private System.Windows.Forms.NumericUpDown numericUpDownTimes;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxIVRURL;
        private System.Windows.Forms.TextBox display;
        private System.Windows.Forms.Button clear;
        private System.Windows.Forms.Button query;
        private System.Windows.Forms.Button insert;
    }
}

