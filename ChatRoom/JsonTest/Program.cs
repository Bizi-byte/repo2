using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;

namespace JsonTest
{
    class Configuration
    {
        public uint ServerPort;
        public uint GroupPort;
        public string Ip;
        public Configuration(uint serverPort, uint groupPort, string ip)
        {
            ServerPort = serverPort;
            GroupPort = groupPort;
            Ip = ip;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"C:\Users\User\ishay\ChatRoom\conf.txt";
            Console.WriteLine(path);

            FileStream f = File.OpenRead(path);
            StreamReader r = new StreamReader(f);
            string data = r.ReadToEnd();

            //JsonSerializer js = new JsonSerializer();
            
            //StringReader sr = new StringReader(data);
            Configuration c = JsonConvert.DeserializeObject<Configuration>(data);
            Console.WriteLine(c.ServerPort);
            Console.WriteLine(c.GroupPort);
            Console.WriteLine(c.Ip);

            JsonTextReader tr = new JsonTextReader(new StreamReader(File.OpenRead(path)));

            while(tr.Read())
            {
                if (null != tr.Value)
                {
                    Console.WriteLine("token:{0}, val:{1}", tr.TokenType, tr.Value);
                }
                else 
                {
                    Console.WriteLine("token:{0}", tr.TokenType);
                }
            }



        }
    }
}
