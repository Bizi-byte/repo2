using System;
using System.Threading;

namespace concurrency
{
    public class X
    {
        public X()
        { }
    }
    class Program
    {
        public static int x = 10;
        public static object o1;
        public static X x1;
        static Program()
        {
            o1 = new object();
            o1 = 100;
            x1 = new X();
        }
        
        static void Main(string[] args)
        {
            var t1 = new Thread(ThreadFunc);
            t1.Name = "second_thread";
            var thread = Thread.CurrentThread;
            thread.Name = "main thread";
            t1.Start(100);
            //lock (o1)
            {
                for (int i = 0; i < 5; ++i)
                {
                    Console.WriteLine("{0}:{1}", thread.Name, x);
                    //Console.WriteLine("{0}:{1}", thread.Name, o1);
                    //Thread.Sleep(0);
                    Thread.Yield();
                }
            }
            t1.Join();

            var t2 = new Thread(ThreadFunc1);
            t2.Name = "third_thread";
            t2.Start();
            ThreadFunc1();
            t2.Join();

          
           

        }

        public static void ThreadFunc(Object o)
        {
            //Console.WriteLine("Thread data: {0}", o);
            var thread = Thread.CurrentThread;
            //Console.WriteLine(thread.Name);
            //Console.WriteLine(thread.ManagedThreadId);
            //lock(o1)
            {
                for (int i = 0; i < 5; ++i)
                {
                    Console.WriteLine("{0}:{1}", thread.Name, x);
                    //Console.WriteLine("{0}:{1}", thread.Name, o1);
                    //Thread.Sleep(0);
                    Thread.Yield();
                }
            }
        }

        public static void ThreadFunc1()
        {
            
            var thread = Thread.CurrentThread;
            Console.WriteLine(thread.Name);
            Console.WriteLine(thread.ManagedThreadId);
            Monitor.Enter(o1);
            try
            {
                Console.WriteLine(o1);
                

            }
            finally
            {
                Monitor.Exit(o1);

            }
            
        }
    }
}
