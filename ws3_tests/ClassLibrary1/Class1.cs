using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class Class1
    {
        private readonly int x;
        public Class1(int num)
        {
            x = num;
        }

        public Class1()
        {
            x = 0;
        }
        public void Print()
        {
            Console.WriteLine(x);
        }
    }
    // generic constrains
    public class Class2<T>  where T : Class1, new()
    {
        T a;
        public Class2(int num)
        {
            a = new T();
        }

        public void Print()
        {
            a.Print();
        }

    }

    public interface Base
    {
        void Print();
    }

    public class Derived1 : Base
    {
        public virtual void Print()
        {
            Console.WriteLine(" derived 1");
        }
    }

    public class Derived2 : Derived1
    {
        public override void Print() => Console.WriteLine(" derived 2");
    }
}
