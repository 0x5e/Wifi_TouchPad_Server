using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;

namespace Remote_Control_Server
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //从注册表读取设置
            Object val;
            val = Application.UserAppDataRegistry.GetValue("Key");
            if (val != null)
            {
                key = val.ToString();
            }
            else
            {
                key = String.Format("{0:0000}", new Random().Next(0, 9999));
            }
            配对码.Text = key;

            val = Application.UserAppDataRegistry.GetValue("Min");
            if (val != null && val.ToString().Equals("True"))
            {
                最小化.Checked = true;
                WindowState = System.Windows.Forms.FormWindowState.Minimized;
            }

            启动_停止.PerformClick();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (配对码.ReadOnly == false)
            {
                Start();
            }
            else
            {
                Stop();
            }
        }

        private void tabControl1_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab == 设置)
            {
                IP地址.Items.Clear();
                IPAddress[] arrIPAddresses = Dns.GetHostAddresses(Dns.GetHostName());
                foreach (IPAddress ip in arrIPAddresses)
                {
                    if (ip.AddressFamily.Equals(AddressFamily.InterNetwork))
                        IP地址.Items.Add(ip.ToString());
                }
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (最小化.Checked)
            {
                Application.UserAppDataRegistry.SetValue("Min", "True");
            }
            else
            {
                Application.UserAppDataRegistry.SetValue("Min", "False");
            }
        }

        bool first = true;
        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized) //判断是否最小化 
            {
                ShowInTaskbar = false; //不显示在系统任务栏 
                托盘.Visible = true; //托盘图标可见 
                if (first)
                {
                    first = false;
                    托盘.ShowBalloonTip(3000, "", "已最小化到托盘", ToolTipIcon.None);
                }
            }
        }

        private void notifyIcon1_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                Show();
                WindowState = FormWindowState.Normal;
                托盘.Visible = false;
                ShowInTaskbar = true;
            }
        }

        void printf(String str)
        {
            //listBox1.Items.Add(DateTime.Now.ToString() + " " + str);
            日志.Items.Add(str);
            日志.TopIndex = 日志.Items.Count - (int)(日志.Height / 日志.ItemHeight);

            if (WindowState == FormWindowState.Minimized) //判断是否最小化 
            {
                托盘.ShowBalloonTip(3000, "", str, ToolTipIcon.None);
            }
        }
    }
}
