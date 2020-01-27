using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace MultiCastUdp
{
    public class Sender
    {
        public Sender()
        {
            UdpClient server = new UdpClient();
            IPAddress groupaddr = IPAddress.Parse("224.5.6.7");
            IPEndPoint ep = new IPEndPoint(groupaddr, 2222);
            server.JoinMulticastGroup(groupaddr);
            server.Connect(ep);
            Console.WriteLine("type your msg and press enter to send msg");
            string msg = Console.ReadLine();
            byte[] buffer = Encoding.ASCII.GetBytes(msg);
            server.Send(buffer, buffer.Length);

            server.Close();
        }
        
    }

    public class Receiver
    {
        public Receiver()
        {
            try
            {

                IPAddress groupaddr = IPAddress.Parse("224.5.6.7");
                IPEndPoint ep = new IPEndPoint(IPAddress.Any, 2222);
                UdpClient client = new UdpClient(ep);
                //client.ExclusiveAddressUse = false;
                client.JoinMulticastGroup(groupaddr);

                var buffer = client.Receive(ref ep);
                Console.WriteLine("received:{0}", Encoding.ASCII.GetString(buffer));
                client.Close();

            }
            catch(Exception e)
            {
                Console.OutputEncoding = System.Text.Encoding.UTF8;
                Console.WriteLine(e.Message);
            }

        }

    }
}
