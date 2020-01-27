using System;

using System.Threading;

namespace BusyWaitProducerConsumer
{
    public class Args
    {
        public uint Iter;
        public object Data;
        public object DataFlag;
        public SpinLock SLock;

        public Args(uint iterations, object data, object dataFlag, SpinLock slock)
        {
            Iter = iterations;
            Data = data;
            DataFlag = dataFlag;
            SLock = slock;
        }
    }

    public class Producer
    {
        Thread p;
        public Producer(Args args)
        {
            p = new Thread(Produce);
            p.Start(args);
        }

        public void Produce(object args)
        {
            bool islocked;
            Args currentargs = (Args)args;
            uint counter = 100;

            while (0 < counter)
            {
                //Console.WriteLine("counter:{0}", counter);
                islocked = false;
                try
                {
                    //currentargs.SLock.Enter(ref islocked);
                    if (false == (bool)currentargs.DataFlag)
                    {
                        currentargs.Data = (int)currentargs.Data + 1;
                        currentargs.DataFlag = true;
                        counter--;
                    }
                }
                finally
                {
                    //currentargs.SLock.Exit();
                }
            }
        }
        public void Join()
        {
            p.Join();
        }
    }

    public class Consumer
    {
        Thread c;
        public Consumer(Args args)
        {
            c = new Thread(Consume);
            c.Start(args);
        }

        public void Consume(object args)
        {
            bool islocked;
            Args currentargs = (Args)args;
            uint counter = 100;

            while (0 < counter)
            {
                //Console.WriteLine("iter:{0}", currentargs.Iter);
                islocked = false;
                try
                {
                    //currentargs.SLock.Enter(ref islocked);
                    if (true == (bool)currentargs.DataFlag)
                    {
                        Console.WriteLine("consume:{0}", (int)currentargs.Data);
                        currentargs.DataFlag = false;
                        --counter;
                    }
                }
                finally
                {
                    //currentargs.SLock.Exit();
                }
            }
        }

        public void Join()
        {
            c.Join();
        }
    }
}
