using System;

namespace tests
{
    public interface I
    {
        public uint Property { get; set; }
    }

    public class X : I
    {
        public uint Property { get;  set; }

        public X()
        {
            Property = 10;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
