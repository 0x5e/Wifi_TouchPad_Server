namespace Remote_Control_Server
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.常规 = new System.Windows.Forms.TabPage();
            this.配对码 = new System.Windows.Forms.TextBox();
            this.日志 = new System.Windows.Forms.ListBox();
            this.启动_停止 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.设置 = new System.Windows.Forms.TabPage();
            this.最小化 = new System.Windows.Forms.CheckBox();
            this.帮助 = new System.Windows.Forms.TabPage();
            this.托盘 = new System.Windows.Forms.NotifyIcon(this.components);
            this.IP地址 = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.常规.SuspendLayout();
            this.设置.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.常规);
            this.tabControl1.Controls.Add(this.设置);
            this.tabControl1.Controls.Add(this.帮助);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(260, 137);
            this.tabControl1.TabIndex = 0;
            this.tabControl1.Click += new System.EventHandler(this.tabControl1_Click);
            // 
            // 常规
            // 
            this.常规.Controls.Add(this.配对码);
            this.常规.Controls.Add(this.日志);
            this.常规.Controls.Add(this.启动_停止);
            this.常规.Controls.Add(this.label1);
            this.常规.Location = new System.Drawing.Point(4, 22);
            this.常规.Name = "常规";
            this.常规.Padding = new System.Windows.Forms.Padding(3);
            this.常规.Size = new System.Drawing.Size(252, 111);
            this.常规.TabIndex = 0;
            this.常规.Text = "常规";
            this.常规.UseVisualStyleBackColor = true;
            // 
            // 配对码
            // 
            this.配对码.Font = new System.Drawing.Font("黑体", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.配对码.Location = new System.Drawing.Point(71, 14);
            this.配对码.MaxLength = 4;
            this.配对码.Name = "配对码";
            this.配对码.Size = new System.Drawing.Size(77, 41);
            this.配对码.TabIndex = 4;
            this.配对码.Text = "0000";
            this.配对码.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // 日志
            // 
            this.日志.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.日志.FormattingEnabled = true;
            this.日志.ItemHeight = 12;
            this.日志.Location = new System.Drawing.Point(3, 68);
            this.日志.Name = "日志";
            this.日志.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.日志.Size = new System.Drawing.Size(246, 40);
            this.日志.TabIndex = 3;
            this.日志.TabStop = false;
            // 
            // 启动_停止
            // 
            this.启动_停止.Location = new System.Drawing.Point(167, 23);
            this.启动_停止.Name = "启动_停止";
            this.启动_停止.Size = new System.Drawing.Size(75, 23);
            this.启动_停止.TabIndex = 2;
            this.启动_停止.Text = "启动";
            this.启动_停止.UseVisualStyleBackColor = true;
            this.启动_停止.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "配对码:";
            // 
            // 设置
            // 
            this.设置.Controls.Add(this.label2);
            this.设置.Controls.Add(this.IP地址);
            this.设置.Controls.Add(this.最小化);
            this.设置.Location = new System.Drawing.Point(4, 22);
            this.设置.Name = "设置";
            this.设置.Padding = new System.Windows.Forms.Padding(3);
            this.设置.Size = new System.Drawing.Size(252, 111);
            this.设置.TabIndex = 1;
            this.设置.Text = "设置";
            this.设置.UseVisualStyleBackColor = true;
            // 
            // 最小化
            // 
            this.最小化.AutoSize = true;
            this.最小化.Location = new System.Drawing.Point(9, 20);
            this.最小化.Name = "最小化";
            this.最小化.Size = new System.Drawing.Size(96, 16);
            this.最小化.TabIndex = 0;
            this.最小化.Text = "启动后最小化";
            this.最小化.UseVisualStyleBackColor = true;
            this.最小化.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // 帮助
            // 
            this.帮助.Location = new System.Drawing.Point(4, 22);
            this.帮助.Name = "帮助";
            this.帮助.Padding = new System.Windows.Forms.Padding(3);
            this.帮助.Size = new System.Drawing.Size(252, 111);
            this.帮助.TabIndex = 3;
            this.帮助.Text = "帮助";
            this.帮助.UseVisualStyleBackColor = true;
            // 
            // 托盘
            // 
            this.托盘.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.托盘.Text = "Remote Control";
            this.托盘.Click += new System.EventHandler(this.notifyIcon1_Click);
            // 
            // IP地址
            // 
            this.IP地址.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.IP地址.FormattingEnabled = true;
            this.IP地址.ItemHeight = 12;
            this.IP地址.Location = new System.Drawing.Point(3, 68);
            this.IP地址.Name = "IP地址";
            this.IP地址.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.IP地址.Size = new System.Drawing.Size(246, 40);
            this.IP地址.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "IP地址列表:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 161);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Remote Comtrol";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.SizeChanged += new System.EventHandler(this.Form1_SizeChanged);
            this.tabControl1.ResumeLayout(false);
            this.常规.ResumeLayout(false);
            this.常规.PerformLayout();
            this.设置.ResumeLayout(false);
            this.设置.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage 常规;
        private System.Windows.Forms.TabPage 设置;
        private System.Windows.Forms.ListBox 日志;
        private System.Windows.Forms.Button 启动_停止;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage 帮助;
        private System.Windows.Forms.TextBox 配对码;
        private System.Windows.Forms.CheckBox 最小化;
        private System.Windows.Forms.NotifyIcon 托盘;
        private System.Windows.Forms.ListBox IP地址;
        private System.Windows.Forms.Label label2;
    }
}

