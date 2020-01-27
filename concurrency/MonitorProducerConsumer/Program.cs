using System;
using System.Threading;
using GenericLinkList;

namespace MonitorProducerConsumer
{
    struct Args
    {
        public LinkList<int> List;
        public int insertData;

        public Args(LinkList<int> list, int data)
        {
            List = list;
            insertData = data;
        }
    }
    class Program
    {
        public static object o;
        
        static Program()
        {
            o = new object();
        }

        static void Producer(object arg)
        {
            bool islocked = false;
            try
            {
                Monitor.Enter(o, ref islocked);
                Args a = (Args)arg;
                a.List.Push(a.insertData);
                Console.WriteLine("push {0} to list", a.insertData);
                a.List.Print();
            }
            finally
            {
                if (islocked)
                {
                    Monitor.Exit(o);
                }
            }


        }

        static void Consumer(object arg)
        {
            bool islocked = false;
            try
            {
                Monitor.Enter(o, ref islocked);
                Args a = (Args)arg;
                Console.WriteLine("consumed: {0}", a.List.Head());
                a.List.Pop();

            }
            finally
            {
                if (islocked)
                {
                    Monitor.Exit(o);
                }
            }

        }
        static void Main(string[] args)
        {
            LinkList<int> l1 = new LinkList<int>();
            for(int i = 0; i < 10; ++i)
            {
                l1.Push(i);
            }
            l1.Print();


            Args a1 = new Args(l1, 11);

            Thread t1 = new Thread(Producer);
            Thread t2 = new Thread(Producer);
            Thread t3 = new Thread(Producer);
            Thread t4 = new Thread(Consumer);
            Thread t5 = new Thread(Consumer);
            Thread t6 = new Thread(Consumer);

            t1.Start(a1);

            t5.Start(a1);

            t6.Start(a1);

            a1.insertData = 13;
            t2.Start(a1);

            a1.insertData = 17;
            t3.Start(a1);

            t4.Start(a1);

            t1.Join();
            t2.Join();
            t3.Join();
            t4.Join();
            t5.Join();
            t6.Join();
                   

            l1.Print();

            LinkList<int> l2 = new LinkList<int>();
            for (int i = 0; i < 10; ++i)
            {
                l2.QPush(i);
                l2.Print();
            }
            l2.Print();


        }
    }
}
