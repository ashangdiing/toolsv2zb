namespace analysis4DFCYC
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
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxPath = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.labellogName = new System.Windows.Forms.Label();
            this.textBoxLogMessage = new System.Windows.Forms.TextBox();
            this.textBoxFinnd = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(40, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "路径";
            // 
            // textBoxPath
            // 
            this.textBoxPath.Location = new System.Drawing.Point(104, 22);
            this.textBoxPath.Multiline = true;
            this.textBoxPath.Name = "textBoxPath";
            this.textBoxPath.Size = new System.Drawing.Size(822, 27);
            this.textBoxPath.TabIndex = 1;
            this.textBoxPath.Text = "C:\\Users\\smileWei\\Desktop\\新建文件夹";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(89, 313);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "开始";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // labellogName
            // 
            this.labellogName.AccessibleRole = System.Windows.Forms.AccessibleRole.Pane;
            this.labellogName.AutoSize = true;
            this.labellogName.Location = new System.Drawing.Point(102, 72);
            this.labellogName.Name = "labellogName";
            this.labellogName.Size = new System.Drawing.Size(53, 12);
            this.labellogName.TabIndex = 3;
            this.labellogName.Text = "当前日志";
            // 
            // textBoxLogMessage
            // 
            this.textBoxLogMessage.Location = new System.Drawing.Point(89, 87);
            this.textBoxLogMessage.Multiline = true;
            this.textBoxLogMessage.Name = "textBoxLogMessage";
            this.textBoxLogMessage.Size = new System.Drawing.Size(796, 220);
            this.textBoxLogMessage.TabIndex = 4;
            // 
            // textBoxFinnd
            // 
            this.textBoxFinnd.Location = new System.Drawing.Point(253, 63);
            this.textBoxFinnd.Multiline = true;
            this.textBoxFinnd.Name = "textBoxFinnd";
            this.textBoxFinnd.Size = new System.Drawing.Size(295, 21);
            this.textBoxFinnd.TabIndex = 5;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(925, 348);
            this.Controls.Add(this.textBoxFinnd);
            this.Controls.Add(this.textBoxLogMessage);
            this.Controls.Add(this.labellogName);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBoxPath);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxPath;
        private System.Windows.Forms.Button button1;
        public System.Windows.Forms.Label labellogName;
        public System.Windows.Forms.TextBox textBoxLogMessage;
        private System.Windows.Forms.TextBox textBoxFinnd;
    }
}

