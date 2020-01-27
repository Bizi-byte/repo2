using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ClassLibrary1;

namespace ws3_tests
{
    class Program
    {
        static void Main(string[] args)
        {
            Class2<Class1> c1 = new Class2<Class1>(3);
            c1.Print();

            var c2 = new Derived2();
            Base b = c2;
            Derived1 d1 = c2;

            c2.Print();
            b.Print();
            d1.Print();


        }
    }
}
