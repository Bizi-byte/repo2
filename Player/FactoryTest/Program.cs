using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Factory;
using SingletonUtil;
using System.Threading;

namespace FactoryTest
{
    public class B
    {
        public B()
        {
            Console.WriteLine("B created");
        }
    }

    public class D1 : B
    {
        public D1()
        {
            Console.WriteLine("D1 created");
        }

        public static D1 Create()
        {
            return (new D1());
        }
    }

    public class D2 : B
    {
        public D2()
        {
            Console.WriteLine("D2 created");
        }

        public static D2 Create()
        {
            return (new D2());
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            CreatorFactory<B, int> f = new CreatorFactory<B, int>();
            f.Add(1, D2.Create);
            f.Add(2, D1.Create);

            //B d1 = f.Create<D1>(2);
            //B d2 = f.Create<D2>(1);

            f.Add(3, Singleton<D1>.Create);
            f.Add(4, Singleton<D2>.Create);

            B d3 = f.Create(3);
            B d4 = f.Create(3);
            B d5 = f.Create(3);

            Thread t1 = new Thread(ThreadCreat);
            Thread t2 = new Thread(ThreadCreat);

            t1.Start(f);
            t2.Start(f);

            for(int i = 0; i < 10; ++i)
            {
                new Thread(ThreadCreat).Start(f);
            }

            
        }
        public static void ThreadCreat(Object factory)
        {
            B d1 = ((CreatorFactory<B, int>)factory).Create(3);
        }
    }

}
