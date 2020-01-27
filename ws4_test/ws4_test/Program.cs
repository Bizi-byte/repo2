using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ws4_test
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<int, int> f =  x => x * x;
            Func<int , int> f1 = x => { Console.WriteLine(x * x); return x; } ;
            Console.WriteLine(f(5));
            Console.WriteLine(f1(5));

            Action<int> a1 = x => Console.WriteLine(x);
            a1(7);

            int num = 4;

            unsafe
            {
                int* ptr = &num;
                *ptr = 10;
                *(ptr + 1) = 20;
                Console.WriteLine(*(ptr + 1));
            }
        }
    }
}
