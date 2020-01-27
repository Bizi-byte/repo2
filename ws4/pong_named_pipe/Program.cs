using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.IO.Pipes;

namespace pong_named_pipe
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("named pong");
            var client = new NamedPipeClientStream(".", "pipe1");
            client.Connect();

            Console.WriteLine("There are currently {0} pipe server instances open.",
               client.NumberOfServerInstances);
            byte[] buffer = new byte[5]; ;
            client.Read(buffer, 0, 5);
            Console.WriteLine(buffer[1]);
           
        }
    }
}
