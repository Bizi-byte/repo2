using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestLibrary
{
    public class TestClass
    {
        static TestClass()
        {
            Console.WriteLine("test class static ctor");

        }
        public void Print1()
        {
            Console.WriteLine("print1");
        }

        public void Print2()
        {
            Console.WriteLine("print2");
        }
    }
}
