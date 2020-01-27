using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.IO;
using System.IO.Pipes;
using System.Diagnostics;

namespace ping_named_pipe
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("named ping");
            var server = new NamedPipeServerStream("pipe1", PipeDirection.InOut);
            server.WaitForConnection();

            var stream = new StreamWriter(server);
            stream.Write("ping");
            Console.ReadKey();
        }
    }
}
