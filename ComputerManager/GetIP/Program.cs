using System;
using System.Net;
using System.Net.Sockets;
using System.Diagnostics;

namespace GetIP
{
    class Program
    {
        static void Main(string[] args)
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());

            foreach(var ip in host.AddressList)
            {
                Console.WriteLine("ip:{0}", ip.ToString());
            }
            string localIP;
            using (Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, 0))
            {
                socket.Connect("8.8.8.8", 65530);
                var endPoint = socket.LocalEndPoint as IPEndPoint;
                localIP = endPoint.Address.ToString();
                Console.WriteLine("ip:{0}", localIP);
            }
            Console.WriteLine("shell command:");
            var proc = new Process();
            proc.StartInfo.FileName = "/bin/bash";
            proc.StartInfo.Arguments = "echo hello";
            proc.StartInfo.UseShellExecute = true;
            //proc.StartInfo.RedirectStandardOutput = true;
            proc.Start();
            //Console.ReadLine();

        }

    }
}

