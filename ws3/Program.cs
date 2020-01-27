using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;


namespace ws3
{
    class X
    {
        private int[] arr; 
        public event EventHandler ChangedA;
        event EventHandler<EventArgs> ChangedB;
        protected virtual  void OnChangedA(EventArgs e)
        {
            EventHandler handler = ChangedA;
            handler?.Invoke(this, e);
            /*if (handler != null)
            {
                handler(this, e);
            }*/
        }

        public static int c;
        private int _a;
        public int B { get; set; }
        public int A
        {
            get { return _a;  }
            set { _a = value; OnChangedA(EventArgs.Empty); }
        }
        public int this[int index]
        {
            get { return arr[index]; }
            set { arr[index] = value; }
        }

        public int this[float index]
        {
            get => arr[(int)index];
            set => arr[(int)index] = value;

        }
            

        public X(int num1, int num2, ulong arr_size)
        {
            _a = num1;
            B = num2;
            arr = new int[arr_size];
        }
        // static ctor wite expression body members
        static X() => c = 10;
    }

    static class Y
    {
        public static void ext(this X x) => Console.WriteLine("Hello");
        

    }

    
    class Program
    {
        static void Main(string[] args)
        {
            var x1 = new X(1, 2, 5);
            x1.A = 2;
            Console.WriteLine(x1.A);
            Console.WriteLine(x1.A = 3);
            x1.B = 4;
            Console.WriteLine(x1.B);
            Console.WriteLine(x1.B = 7);
            x1.ext();
            Console.WriteLine(X.c);

            x1.ChangedA += ReceiveHandler;
            x1.A = 7;

            Assembly assem = typeof(X).Assembly;
            Console.WriteLine("assembly of x: " + assem);

            for(int j = 0, i = 10; j < 5; ++i, ++j)
            {
                x1[j] = i;
                Console.WriteLine(x1[j]);
            }

            float k = 20;
            for (int j = 0; j < 5; ++k, ++j)
            {
                x1[j] = (int)k;
                Console.WriteLine(x1[j]);
            }
        }

        static void ReceiveHandler(object sender, EventArgs e)
        {
            Console.WriteLine("event arrived");
        }
    }
}
