using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.IO.Pipes;
using System.Diagnostics;
using System.Threading;

namespace ws4
{
    class Program
    {
        static void Main(string[] args)
        {
            var P1 = new Process();
            P1.StartInfo.FileName = "C:\\Users\\student\\source\\repos\\ishay-peleg\\ws4\\pong\\bin\\Debug\\pong";
            P1.StartInfo.UseShellExecute = false;
            P1.StartInfo.CreateNoWindow = false;

            Console.WriteLine("ping starting");

            var ServerOut = new AnonymousPipeServerStream(PipeDirection.Out, HandleInheritability.Inheritable);
            Console.WriteLine("Current TransmissionMode: {0}.", ServerOut.TransmissionMode);

            var ServerIn = new AnonymousPipeServerStream(PipeDirection.In, HandleInheritability.Inheritable);
            Console.WriteLine("server out handle: {0}", ServerOut.GetClientHandleAsString());
            Console.WriteLine("server in handle: {0}", ServerIn.GetClientHandleAsString());
            P1.StartInfo.Arguments = ServerOut.GetClientHandleAsString() + " " + ServerIn.GetClientHandleAsString();

            P1.Start();
            ServerOut.DisposeLocalCopyOfClientHandle();
            ServerIn.DisposeLocalCopyOfClientHandle();

            var StreamOut = new StreamWriter(ServerOut);
            StreamOut.AutoFlush = true;
            var StreamIn = new StreamReader(ServerIn);

            StreamOut.Write("ping");
            ServerOut.WaitForPipeDrain();
            //Thread.Sleep(1000);

            //Console.WriteLine(StreamIn.Peek());

            Console.WriteLine("finish1");
            String temp;
            int counter = 0;
            do
            {
                Console.WriteLine("loop: {0}", counter++);
                Thread.Sleep(1000);
                temp = StreamIn.ReadLine();
            } while (temp == null);
            Console.WriteLine(temp);

            //Process.Start("C:\\Users\\student\\source\\repos\\ishay-peleg\\wheather_alert_center\\day_in_the_park\\bin\\Debug\\day_in_the_park");
            //Console.WriteLine(P1.ProcessName);
            //Console.WriteLine("finish2");
            //P1.WaitForExit();
            //P1.Close();
            //Console.ReadLine();
        }
    }
}
