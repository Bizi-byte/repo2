using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HidingVsOverriding
{

    public class Base
    {
        public void Method1()
        {
            Console.WriteLine("base1");
        }

        virtual public void Method2()
        {
            Console.WriteLine("base2");
        }

        public void Method3()
        {
            Console.WriteLine("base3");
        }
    }

    public class Derived : Base
    {
        new public void Method1()
        {
            Console.WriteLine("derived1");
        }

        override public void Method2()
        {
            Console.WriteLine("derived2");
        }

        public void Method3()
        {
            Console.WriteLine("derived3");
        }
    }

    static public class G
    {
        static G()
        {
            Console.WriteLine("static ctor");

            B = true;
        }
        public static readonly uint x = 5;
        public static uint y = 7;
        static public bool B { get; set; }
    }

    static public class G1
    {
        
        public static readonly uint x;
        public static uint y;
        static public bool B { get; set; }
    }

    class Program
    {
        static uint num = 9;
        static void Main(string[] args)
        {
            Console.WriteLine("globals: {0}, {1}, {2}", G.x, G.y, G.B);
            Console.WriteLine("program class static: {0}", num);
            Console.WriteLine("G ctor: {0}", typeof(G).TypeInitializer);

            Console.WriteLine("globals: {0}, {1}, {2}", G1.x, G1.y, G1.B);
            Console.WriteLine("G1 ctor: {0}", typeof(G1).TypeInitializer);
            var b1 = new Base();
            Base b2 = new Derived();
            var d1 = new Derived();

            b1.Method1();
            b1.Method2();
            b1.Method3();

            b2.Method1();
            b2.Method2();
            b2.Method3();

            d1.Method1();
            d1.Method2();
            d1.Method3();

            var l = new List<Base>();
            l.Add(b1);
            l.Add(b2);
            l.Add(d1);

            for(int i = 0; i < l.Count(); ++i)
            {
                l[i].Method2();
            }

            var al = new ArrayList();
            al.Add(1);
            al.Add(b1);

        }
    }
}
