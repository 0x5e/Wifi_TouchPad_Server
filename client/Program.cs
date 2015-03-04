using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Sockets;
namespace client
{
    class Program
    {
        static void Main(string[] args)
        {
            UdpClient udpClient = new UdpClient("127.0.0.1", 8888); 
            IPEndPoint sender = new IPEndPoint(IPAddress.Any, 0);            // 发送  
     
            while(true)
            {
                String read = Console.ReadLine();
                byte[] data = Encoding.UTF8.GetBytes(read);
                if (data.Length>0)
                udpClient.Send(data, data.Length);

                System.Threading.Thread.Sleep(100);
                if (udpClient.Available > 0)
                {
                    byte[] buf = udpClient.Receive(ref sender);
                    String ret = Encoding.UTF8.GetString(buf, 0, buf.Length);
                    Console.WriteLine(ret);
                }
            }
        }
    }
}
