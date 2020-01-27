using System;
using System.Net;
using System.Net.Sockets;
using System.IO;

namespace TCPnetworking
{
    public class TCPServer
    {
        TcpListener listener;

        public TCPServer()
        {
            String name = Dns.GetHostName();

            try
            {
                IPAddress[] adrss = Dns.GetHostEntry(name).AddressList;
                
                listener = new TcpListener(adrss[1], 2000);
                listener.Start();

                Socket s = listener.AcceptSocket();
                NetworkStream ns = new NetworkStream(s);
                StreamReader sr = new StreamReader(ns);
                StreamWriter sw = new StreamWriter(ns);

                sw.AutoFlush = true;

                String msg = sr.ReadLine();
                Console.WriteLine("server got msg:{0}", msg);

                sw.WriteLine("got your msg");

                ns.Close();
                s.Close();



            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void PrintAdrr()
        {
            try
            {
                IPAddress[] adrss = Dns.GetHostEntry(Dns.GetHostName()).AddressList;
                foreach (IPAddress adrs in adrss)
                {
                    Console.WriteLine("name: {0}/adrs: {1}", Dns.GetHostName(), adrs);
                }
                
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }
    }

    public class TCPClient
    {
        public TCPClient()
        {
            TcpClient client = new TcpClient(Dns.GetHostName(), 2000);
            NetworkStream ns = client.GetStream();

            StreamReader sr = new StreamReader(ns);
            StreamWriter sw = new StreamWriter(ns);

            sw.AutoFlush = true;
            sw.WriteLine("hi, im client");

            String msg = sr.ReadLine();

            Console.WriteLine("client got msg:{0}", msg);

            sw.Close();
            client.Close();


        }

    }
}
