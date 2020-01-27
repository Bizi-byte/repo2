using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Program
    {
        public static void Main()
        {
            int a = 5;
            NewMethod();
            a += 3;
            Console.ReadKey();
        }

        private static void NewMethod() => Console.WriteLine("Hello");
    }
}
