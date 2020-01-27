using System;
using System.Threading;
using BusyWaitProducerConsumer;

namespace TestOnePC
{
    class Program
    {
        public static int data = 0;
        public static bool dataFlag;
        public static SpinLock sl;
        static void Main(string[] args)
        {
            sl = new SpinLock();
            Args a = new Args(10, data, dataFlag, sl);
            Producer p = new Producer(a);
            Consumer c = new Consumer(a);

            p.Join();
            c.Join();
        }
    }
}
