using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceTest
{
    public interface Itest
    {
        void Play();
    }
    public class Test : Itest
    {
        public void Play()
        {
            Console.WriteLine("plaaying...");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Itest t = new Test();
            t.Play();
        }
    }
}
