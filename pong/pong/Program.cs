using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.IO.Pipes;
using System.Threading;

namespace pong
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("pong starting");
            Console.WriteLine("client in handle: {0}", args[0]);
            Console.WriteLine("client out handle: {0}", args[1]);
            var ClientIn = new AnonymousPipeClientStream(PipeDirection.In, args[0]);
            var ClientOut = new AnonymousPipeClientStream(PipeDirection.Out, args[1]);

            var StreamIn = new StreamReader(ClientIn);
            Console.WriteLine("pong receiving");
            Console.WriteLine("pong end of stream = {0}", StreamIn.EndOfStream);
            Console.WriteLine(StreamIn.ReadLine());

            Console.WriteLine("pong sending");
            var StreamOut = new StreamWriter(ClientOut);
            StreamOut.AutoFlush = true;
            StreamOut.Write("pong");

            //Console.WriteLine("pong finish");
            //ClientOut.WaitForPipeDrain();
            //Console.WriteLine("pong");
            //Console.ReadKey();
        }
    }
}
