using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Stack;


namespace ws2_test
{
    class Program
    {
        static void Main(string[] args)
        {
            var stack = new Stack.GenericStack<int>(10);

            stack.Push(1);

            for(int i = 0; i < 9; ++i)
            {
                stack.Push(i);
            }

            Console.WriteLine("11 push: " + stack.Push(1));

            for (int i = 0; i < 10; ++i)
            {
                Console.WriteLine(" " + stack.Peek());
                stack.Pop();
            }

            Console.WriteLine("empty: " + stack.IsEmpty());
            Console.ReadKey();

        }

    }
}
