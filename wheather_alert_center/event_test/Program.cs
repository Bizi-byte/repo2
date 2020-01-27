using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace event_test
{
    class A
    {
        public delegate void Del(int num);

        public event Del Eve;

        public void onCall()
        {
            Eve?.Invoke(10);
        }

        public void Print()
        {
            Console.WriteLine("A printing");
        }
    }

    class B
    {
        public void Print()
        {
            Console.WriteLine("B printing");
        }
        public void Han(int num)
        {
            Console.WriteLine(num);
            Print();
            
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            A a = new A();
            B b = new B();
            a.Eve += b.Han;
            a.onCall();
        }
    }
}
