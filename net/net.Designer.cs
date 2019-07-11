namespace net
{
    partial class net
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
            this.labelIPs = new System.Windows.Forms.Label();
            this.textBoxIPs = new System.Windows.Forms.TextBox();
            this.buttonStartPing = new System.Windows.Forms.Button();
            this.labelIntervial = new System.Windows.Forms.Label();
            this.textBoxPinGintervial = new System.Windows.Forms.TextBox();
            this.labeltimeOut = new System.Windows.Forms.Label();
            this.textBoxTimeOut = new System.Windows.Forms.TextBox();
            this.callout = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelIPs
            // 
            this.labelIPs.AutoSize = true;
            this.labelIPs.Location = new System.Drawing.Point(28, 25);
            this.labelIPs.Name = "labelIPs";
            this.labelIPs.Size = new System.Drawing.Size(113, 12);
            this.labelIPs.TabIndex = 0;
            this.labelIPs.Text = "IP地址(空格隔开)：";
            // 
            // textBoxIPs
            // 
            this.textBoxIPs.Location = new System.Drawing.Point(147, 16);
            this.textBoxIPs.Multiline = true;
            this.textBoxIPs.Name = "textBoxIPs";
            this.textBoxIPs.Size = new System.Drawing.Size(337, 180);
            this.textBoxIPs.TabIndex = 1;
            this.textBoxIPs.Text = "10.4.10.54 10.6.69.1 10.4.10.66";
            // 
            // buttonStartPing
            // 
            this.buttonStartPing.Location = new System.Drawing.Point(409, 287);
            this.buttonStartPing.Name = "buttonStartPing";
            this.buttonStartPing.Size = new System.Drawing.Size(75, 23);
            this.buttonStartPing.TabIndex = 2;
            this.buttonStartPing.Text = "开始ping";
            this.buttonStartPing.UseVisualStyleBackColor = true;
            this.buttonStartPing.Click += new System.EventHandler(this.buttonStartPing_Click);
            // 
            // labelIntervial
            // 
            this.labelIntervial.AutoSize = true;
            this.labelIntervial.Location = new System.Drawing.Point(55, 222);
            this.labelIntervial.Name = "labelIntervial";
            this.labelIntervial.Size = new System.Drawing.Size(101, 12);
            this.labelIntervial.TabIndex = 3;
            this.labelIntervial.Text = "ping间隔(毫秒)：";
            // 
            // textBoxPinGintervial
            // 
            this.textBoxPinGintervial.Location = new System.Drawing.Point(147, 213);
            this.textBoxPinGintervial.Name = "textBoxPinGintervial";
            this.textBoxPinGintervial.Size = new System.Drawing.Size(100, 21);
            this.textBoxPinGintervial.TabIndex = 4;
            this.textBoxPinGintervial.TextChanged += new System.EventHandler(this.textBoxPinGintervial_TextChanged);
            // 
            // labeltimeOut
            // 
            this.labeltimeOut.AutoSize = true;
            this.labeltimeOut.Location = new System.Drawing.Point(276, 216);
            this.labeltimeOut.Name = "labeltimeOut";
            this.labeltimeOut.Size = new System.Drawing.Size(77, 12);
            this.labeltimeOut.TabIndex = 3;
            this.labeltimeOut.Text = "超时(毫秒)：";
            // 
            // textBoxTimeOut
            // 
            this.textBoxTimeOut.Location = new System.Drawing.Point(368, 207);
            this.textBoxTimeOut.Name = "textBoxTimeOut";
            this.textBoxTimeOut.Size = new System.Drawing.Size(100, 21);
            this.textBoxTimeOut.TabIndex = 4;
            this.textBoxTimeOut.TextChanged += new System.EventHandler(this.textBoxTimeOut_TextChanged);
            // 
            // callout
            // 
            this.callout.Location = new System.Drawing.Point(57, 275);
            this.callout.Name = "callout";
            this.callout.Size = new System.Drawing.Size(99, 23);
            this.callout.TabIndex = 5;
            this.callout.Text = "外呼接口开启";
            this.callout.UseVisualStyleBackColor = true;
            this.callout.Click += new System.EventHandler(this.button1_Click);
            // 
            // net
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(547, 322);
            this.Controls.Add(this.callout);
            this.Controls.Add(this.textBoxTimeOut);
            this.Controls.Add(this.labeltimeOut);
            this.Controls.Add(this.textBoxPinGintervial);
            this.Controls.Add(this.labelIntervial);
            this.Controls.Add(this.buttonStartPing);
            this.Controls.Add(this.textBoxIPs);
            this.Controls.Add(this.labelIPs);
            this.Name = "net";
            this.Text = "网络检测";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.net_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelIPs;
        private System.Windows.Forms.TextBox textBoxIPs;
        private System.Windows.Forms.Button buttonStartPing;
        private System.Windows.Forms.Label labelIntervial;
        private System.Windows.Forms.TextBox textBoxPinGintervial;
        private System.Windows.Forms.Label labeltimeOut;
        private System.Windows.Forms.TextBox textBoxTimeOut;
        private System.Windows.Forms.Button callout;
    }
}

