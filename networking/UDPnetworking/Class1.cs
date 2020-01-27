using System;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace UDPnetworking
{
    public class UDPserver
    {
        public UDPserver()
        {
            UdpClient server = new UdpClient(3000);
            IPEndPoint ep = null;

            byte[] buffer = server.Receive(ref ep);
            Console.WriteLine("server got: {0}", Encoding.ASCII.GetString(buffer));

            Thread.Sleep(1000);

            byte[] msg = Encoding.ASCII.GetBytes("server got msg");

            server.Send(msg, msg.Length, ep);
            
        }
    }

    public class UDPclient
    {
        public UDPclient()
        {
            UdpClient client = new UdpClient();
            IPEndPoint ep = null;
            //client.Connect(Dns.GetHostName(), 3000);

            byte[] msg = Encoding.ASCII.GetBytes("udp client sends hello");
            client.Send(msg, msg.Length, new IPEndPoint(Dns.GetHostEntry(Dns.GetHostName()).AddressList[1], 3000));
            Thread.Sleep(1000);
            byte[] buffer = client.Receive(ref ep);
            Console.WriteLine("client got: {0}", Encoding.ASCII.GetString(buffer));


        }
    }
}
