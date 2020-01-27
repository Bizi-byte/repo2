using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Net;
using System.Net.Sockets;
using Newtonsoft.Json;
using System.IO;


namespace ChatRoom
{
    public class Configuration
    {
        public int ServerPort;
        public int GroupPort;
        public string GroupIp;
        public string ServerIp;
        public Configuration(int serverPort, int groupPort, string groupIp, string serverIp)
        {
            ServerPort = serverPort;
            GroupPort = groupPort;
            GroupIp = groupIp;
            ServerIp = serverIp;
        }

        static public Configuration Create(string path)
        {
            StreamReader r = new StreamReader(File.OpenRead(path));
            return JsonConvert.DeserializeObject<Configuration>(r.ReadToEnd());
        }
    }
    public class Server
    {

        // receives registration messages and chat messages
        UdpClient receiver;

        // sends chat messages to all clients
        UdpClient sender;

        // keep ids of all clients
        HashSet<String> ids = new HashSet<string>();
        bool to_stop = false;
        IPEndPoint ep;
        public Server(string configurationFilePath)
        {
            
            Configuration c = Configuration.Create(configurationFilePath);
            
            IPAddress groupaddr = IPAddress.Parse(c.GroupIp);
            ep = new IPEndPoint(groupaddr, c.GroupPort);

            sender = new UdpClient();
            sender.JoinMulticastGroup(groupaddr);
            sender.Connect(ep);
            
            receiver = new UdpClient(c.ServerPort);
        }

        public void Run()
        {
            Thread serverthread = new Thread(ChatSender);
            serverthread.Start();
        }

        public void ShutDown()
        {
            sender.Close();
            receiver.Close();
        }
        private void ChatSender()
        {
            while (!to_stop)
            {
                IPAddress ip = ((IPEndPoint)receiver.Client.LocalEndPoint).Address;
                IPEndPoint remote = null;
                //Console.WriteLine("waiting to client on ip: {0} port: {1}", ip, ((IPEndPoint)receiver.Client.LocalEndPoint).Port);

                
                byte[] buffer = receiver.Receive(ref remote);

                //Console.WriteLine("got msg from client");
                string msg = Encoding.ASCII.GetString(buffer);

                if(msg.StartsWith("register"))
                {
                    //Console.WriteLine("msg is: {0}", msg);
                    string id = msg.Substring(9, msg.Length - 9);
                    //Console.WriteLine("requested id: {0}", id);
                    if (ids.Contains(id))
                    {
                        string return_msg = "user name is taken";
                        receiver.Send(Encoding.ASCII.GetBytes(return_msg), return_msg.Length, remote);
                    }
                    else
                    {
                        string return_msg = "user name is ok";
                        receiver.Send(Encoding.ASCII.GetBytes(return_msg), return_msg.Length, remote);
                        ids.Add(id);
                        Console.WriteLine("registered {0}", id);

                        string welcome = id + " joined the chat. welcome!";
                        sender.Send(Encoding.ASCII.GetBytes(welcome), welcome.Length);
                    }
                }
                else
                {
                    Console.WriteLine("got msg from client: {0}", msg);
                    sender.Send(buffer, buffer.Length);
                }
            }

        }

       

    }



    public class Client
    {
        IPEndPoint ep;
        UdpClient receiver;
        UdpClient sender;
        string ID;
        public Client(string configyrationFilePath)
        {
            Thread.Sleep(1000);

            Console.WriteLine("welcome to chat room!");
            Console.WriteLine("please enter a user name");
            string id = Console.ReadLine();
            Configuration c = Configuration.Create(configyrationFilePath);
            IPEndPoint server = new IPEndPoint(IPAddress.Parse(c.ServerIp), c.ServerPort);
            //IPAddress[] list = Dns.GetHostEntry(Dns.GetHostName()).AddressList;
            //foreach(IPAddress ip in list)
            //{
            //    Console.WriteLine("ip:{0}", ip);
            //}


            sender = new UdpClient();
            sender.Connect(server);

            IPAddress groupaddr = IPAddress.Parse(c.GroupIp);
            ep = new IPEndPoint(IPAddress.Any, c.GroupPort);
            receiver = new UdpClient();
            receiver.ExclusiveAddressUse = false;
            receiver.Client.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);
            receiver.Client.Bind(ep);
            receiver.JoinMulticastGroup(groupaddr);

            string registration = "register:" + id;


            IPAddress sip = ((IPEndPoint)sender.Client.RemoteEndPoint).Address;
            //Console.WriteLine("sending to server on ip: {0} port: {1}", sip, ((IPEndPoint)sender.Client.RemoteEndPoint).Port);
            //Console.WriteLine("sending to server msg: {0} length: {1}", registration, registration.Length);

            sender.Send(Encoding.ASCII.GetBytes(registration), registration.Length);
            //Console.WriteLine("sended registration");
            byte[] confirmation = sender.Receive(ref ep);
            Console.WriteLine(Encoding.ASCII.GetString(confirmation));
            if (Encoding.ASCII.GetString(confirmation) == "user name is ok")
            {
                ID = id;
            }

        }

        public void Run()
        {
            Thread keyboard = new Thread(KeyBoardListener);
            Thread chat = new Thread(ChatListener);

            keyboard.Start();
            chat.Start();

        }

        public void ShutDown()
        {
            sender.Close();
            receiver.Close();
        }
        private void KeyBoardListener()
        {
            while(true)
            {
                string msg = ID + ":" + Console.ReadLine();
                sender.Send(Encoding.ASCII.GetBytes(msg), msg.Length);
            }

        }

        private void ChatListener()
        {
            while(true)
            {
                var buffer = receiver.Receive(ref ep);
                Console.WriteLine(Encoding.ASCII.GetString(buffer));

            }

        }

    }




}
