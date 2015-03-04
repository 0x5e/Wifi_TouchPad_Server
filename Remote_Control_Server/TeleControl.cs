using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using Newtonsoft.Json.Linq;
using System.Runtime.InteropServices;

namespace Remote_Control_Server
{
    partial class Form1
    {
        String key;
        String client = "";

        [DllImport("user32")]
        private static extern UInt32 SendInput(UInt32 nInputs, ref INPUT pInputs, int cbSize);

        [DllImport("kernel32")]
        public static extern int GetTickCount();

        private enum InputType
        {
            INPUT_MOUSE = 0,
            INPUT_KEYBOARD = 1,
            INPUT_HARDWARE = 2,
        }
        [Flags()]
        private enum MOUSEEVENTF
        {
            MOVE = 0x0001,  //mouse move     
            LEFTDOWN = 0x0002,  //left button down     
            LEFTUP = 0x0004,  //left button up     
            RIGHTDOWN = 0x0008,  //right button down     
            RIGHTUP = 0x0010,  //right button up     
            MIDDLEDOWN = 0x0020, //middle button down     
            MIDDLEUP = 0x0040,  //middle button up     
            XDOWN = 0x0080,  //x button down     
            XUP = 0x0100,  //x button down     
            WHEEL = 0x0800,  //wheel button rolled     
            VIRTUALDESK = 0x4000,  //map to entire virtual desktop     
            ABSOLUTE = 0x8000,  //absolute move     
        }
        [Flags()]
        private enum KEYEVENTF
        {
            EXTENDEDKEY = 0x0001,
            KEYUP = 0x0002,
            UNICODE = 0x0004,
            SCANCODE = 0x0008,
        }
        [StructLayout(LayoutKind.Explicit)]
        private struct INPUT
        {
            [FieldOffset(0)]
            public Int32 type;//0-MOUSEINPUT;1-KEYBDINPUT;2-HARDWAREINPUT     
            [FieldOffset(4)]
            public KEYBDINPUT ki;
            [FieldOffset(4)]
            public MOUSEINPUT mi;
            [FieldOffset(4)]
            public HARDWAREINPUT hi;
        }
        [StructLayout(LayoutKind.Sequential)]
        private struct MOUSEINPUT
        {
            public Int32 dx;
            public Int32 dy;
            public Int32 dwData;
            public Int32 dwFlags;
            public Int32 time;
            public IntPtr dwExtraInfo;
        }
        [StructLayout(LayoutKind.Sequential)]
        private struct KEYBDINPUT
        {
            public Int16 wVk;
            public Int16 wScan;
            public Int32 dwFlags;
            public Int32 time;
            public IntPtr dwExtraInfo;
        }
        [StructLayout(LayoutKind.Sequential)]
        private struct HARDWAREINPUT
        {
            public Int32 uMsg;
            public Int16 wParamL;
            public Int16 wParamH;
        }

        //发送unicode字符，可发送任意字符     
        void SendText(string message)
        {
            for (int i = 0; i < message.Length; i++)
            {
                INPUT input_down = new INPUT();
                input_down.type = (int)InputType.INPUT_KEYBOARD;
                input_down.ki.dwFlags = (int)KEYEVENTF.UNICODE;
                input_down.ki.wScan = (short)message[i];
                input_down.ki.wVk = 0;
                input_down.ki.time = GetTickCount();
                SendInput(1, ref input_down, Marshal.SizeOf(input_down));//keydown     
                INPUT input_up = new INPUT();
                input_up.type = (int)InputType.INPUT_KEYBOARD;
                input_up.ki.dwFlags = (int)(KEYEVENTF.KEYUP | KEYEVENTF.UNICODE);
                input_up.ki.wScan = (short)message[i];
                input_up.ki.wVk = 0;
                input_up.ki.time = GetTickCount();
                SendInput(1, ref input_up, Marshal.SizeOf(input_up));//keyup      
            }
        }

        private delegate void DelegatePrintf(String str);//委托

        String Control(String strJson, String addr)
        {
            DelegatePrintf print = new DelegatePrintf(printf);
            try
            {
                JObject jsonObj = JObject.Parse(strJson);
                //获取版本号
                if (jsonObj["version"] != null)
                {
                    return new JObject(new JProperty("version", System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString())).ToString();
                }

                //配对
                if (jsonObj["auth"] != null)
                {
                    String auth = Encoding.UTF8.GetString(Convert.FromBase64String(jsonObj["auth"].ToString()));
                    if (auth.Equals(key))
                    {
                        client = addr;
                        Invoke(print, "连接成功 " + addr);
                        return new JObject(new JProperty("state", "correct")).ToString();
                    }
                    else
                    {
                        Thread.Sleep(500);
                        Invoke(print, "连接失败 " + addr + " " + auth);
                        return new JObject(new JProperty("state", "wrong")).ToString();
                    }
                }

                if (client.Equals(addr))
                {
                    if (jsonObj["mouse"] != null)
                    {
                        //mouse_event(Convert.ToInt32(jsonObj["dwFlags"].ToString()), Convert.ToInt32(jsonObj["dx"].ToString()), Convert.ToInt32(jsonObj["dy"].ToString()), Convert.ToInt32(jsonObj["cButtons"].ToString()), Convert.ToInt32(jsonObj["dwExtraInfo"].ToString()));
                        JObject jsonMouse = JObject.Parse(jsonObj["mouse"].ToString());
                        INPUT input = new INPUT();
                        input.type = (int)InputType.INPUT_MOUSE;
                        input.mi.dx = (int)jsonMouse["dx"];
                        input.mi.dy = (int)jsonMouse["dy"];
                        input.mi.dwData = (int)jsonMouse["dwData"];
                        input.mi.dwFlags = (int)jsonMouse["dwFlags"];
                        SendInput(1, ref input, Marshal.SizeOf(input));
                    }

                    if (jsonObj["keybd"] != null)
                    {
                        //keybd_event(Convert.ToByte(jsonObj["bVk"].ToString()), Convert.ToByte(jsonObj["bScan"].ToString()), Convert.ToUInt32(jsonObj["dwFlags"].ToString()), Convert.ToUInt32(jsonObj["dwExtraInfo"].ToString()));
                        JObject jsonKeybd = JObject.Parse(jsonObj["keybd"].ToString());
                        INPUT input = new INPUT();
                        input.type = (int)InputType.INPUT_KEYBOARD;
                        input.ki.wVk = (short)jsonKeybd["wVk"];
                        //input.ki.wScan = Convert.ToInt16(jsonKeybd["wScan"].ToString());
                        input.ki.dwFlags = (int)jsonKeybd["dwFlags"];
                        SendInput(1, ref input, Marshal.SizeOf(input));
                    }
                    if (jsonObj["text"] != null)
                    {
                        SendText(jsonObj["text"].ToString());
                    }

                    if (jsonObj["exit"] != null)
                    {
                        client = "";
                        Invoke(print, "断开连接");
                    }
                }
                return "";
            }
            catch (Exception)
            {
                Invoke(print, "参数有误!");
                return "";
            }

        }

        void udp_thread()
        {
            IPEndPoint client_addr = new IPEndPoint(IPAddress.Any, 0);
            string line = "";
            while (true)
            {
                Thread.Sleep(5);

                //client_addr = new IPEndPoint(IPAddress.Any, 0);

                //非阻塞接收消息
                if (udpClient.Available != 0)
                {
                    byte[] buf = udpClient.Receive(ref client_addr);
                    String msg = Encoding.UTF8.GetString(buf, 0, buf.Length);
                    line += msg;
                }
                if (line.IndexOf('}') == -1)
                    continue;
                if (line.IndexOf('{') == -1 || line.IndexOf('{') > line.IndexOf('}'))
                {
                    line = line.Substring(line.IndexOf('}'));//舍去不完整的部分
                    continue;
                }

                System.Diagnostics.Trace.WriteLine(line);

                byte[] send = Encoding.UTF8.GetBytes(Control(line, client_addr.Address + ""));
                line = "";
                if (send.Length != 0)
                {
                    udpClient.Send(send, send.Length, client_addr);
                }


            }
        }

        Thread thread;
        UdpClient udpClient;
        void Start()
        {
            try
            {
                key = 配对码.Text;
                udpClient = new UdpClient(8888);
                thread = new Thread(udp_thread);
                thread.IsBackground = true;
                thread.Start();

                Application.UserAppDataRegistry.SetValue("Key", key);
                配对码.ReadOnly = true;
                启动_停止.Text = "停止";
                printf("等待连接...");
            }
            catch (Exception)
            {
                printf("开启失败,端口被占用");
            }
        }

        void Stop()
        {
            thread.Abort();
            udpClient.Close();

            配对码.ReadOnly = false;
            启动_停止.Text = "启动";
            printf("已停止");
        }
    }
}
