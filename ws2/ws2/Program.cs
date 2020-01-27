using System;

using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Stack;
using GenericLinkList;
using Shapes;

namespace ws2
{
    struct X
    {
        public int x, y;
        public string s;

        public X(int p1, int p2)
        {
            x = p1;
            y = p2;
            s = "hi!";
        }

        public void Print()
        {
            Console.WriteLine(s + x + y);
        }
    }
    // struct with defalt paramterless ctor
    struct Y
    {
        public int x, y;

        public void Print()
        {
            Console.WriteLine("Y: " + x + y);
        }
    }

    class Program
    {
        static void swap(ref X x1, ref X x2)
        {
            X tmp = x1;
            x1 = x2;
            x2 = tmp;
        }

        static void Main(string[] args)
        {
            int? num = null;
            num = 10;

            if (num.HasValue)
            {
                Console.WriteLine("int: {0}", num.Value);

            }
            else
            {
                Console.WriteLine("int: null");
            }

            num = null;
            int num2 = num ?? -1;
            Console.WriteLine("int2: {0}", num2);
            
            object onum = num;
            Console.WriteLine("boxed num: {0}", onum);


            onum = 3;

            int? num3 = (int)onum;
            Console.WriteLine("num3: {0}", num3);

            // use of ctor
            var x = new X(1,2);

            // assignment without a ctor, all members should be assigned
            X x1;
            x1.x = 4;
            x1.y = 5;
            x1.s = "x1 hi";

            x.Print();
            x1.Print();

            Y y;
            //Console.WriteLine("Y: " + y.x + y.y);
            //y.Print();

            ///use of object intializer
            Y y1 = new Y{ x = 3, y = 2 };

            y1.Print();

            Console.WriteLine(1.5d);
            var d = 1.5d;
            var f = 1.5f;
            Console.WriteLine(d.GetType());
            Console.WriteLine(f.GetType());

            // nullable value type
            int? z = null;
            Console.WriteLine(z);

            // anonymous types. x and y are read only
            var a = new { x = 9, y = 8 };
            Console.WriteLine(a.x + a.y);

            var b = new { x.s };
            Console.WriteLine(b.s);

            // stack test
            var stack = new GenericStack<int>(10);

            stack.Push(1);
            Console.WriteLine("empty: " + stack.IsEmpty());

            for (int i = 0; i < 9; ++i)
            {
                stack.Push(i);
            }

            Console.WriteLine("11 push: " + stack.Push(1));

            for (int i = 0; i < 10; ++i)
            {
                Console.Write(" " + stack.Peek());
                stack.Pop();
            }

            Console.WriteLine("\n 0 pop: " + stack.Pop());

            Console.WriteLine("empty: " + stack.IsEmpty());

            for (int i = 0; i < 10; ++i)
            {
                stack.Push(i);
            }
            Console.WriteLine("empty: " + stack.IsEmpty());
            stack.Clear();
            Console.WriteLine("after clear- empty: " + stack.IsEmpty());
            //Console.ReadKey();

            var node1 = new Node<int>(2, null);
            var node2 = new Node<int > (3, node1);
            var node3 = new Node<int>(4, node2);

            Console.WriteLine("node1 data: " + node1.data);
            Console.WriteLine("node2 data: " + node2.data);
            Console.WriteLine("node1 threw node 2: " + node2.next.data);
            Console.WriteLine("node3 data: " + node3.data);
            Console.WriteLine("node1 threw node 3: " + node3.next.next.data);

            var list = new LinkList<int>();

            LinkList<int> l1;
            list.Push(2);
            Console.WriteLine(list.Head());

            for( int i = 5; i < 15; ++i)
            {
                list.Push(i);
            }

            for (int i = 5; i < 15; ++i)
            {
                Console.Write(list.Head());
                list.Pop();
                Console.WriteLine(" num of elements: " + list.Count());
            }

            Console.WriteLine(" empty: " + list.IsEmpty());
            list.Pop();
            Console.WriteLine(" num of elements: " + list.Count());
            Console.WriteLine(" empty: " + list.IsEmpty());

            for (int i = 5; i < 15; ++i)
            {
                list.Push(i);
            }

            Console.WriteLine("before clear-empty: " + list.IsEmpty() + ", " +
                "                                       size: " + list.Count());
            Console.WriteLine("after clear-empty: " + list.IsEmpty());

            // assignment and swapping of reference type
            var x2 = new X(1, 2);
            var x3 = new X(3, 4);
            var x4 = new X(5, 6);

            x2.Print();
            x3.Print();
            x4.Print();

            x4 = x3;
            x3 = x2;

            x3.Print();
            x4.Print();
            
            swap(ref x3, ref x4);

            x3.Print();
            x4.Print();

            foreach (Node<int> n in list)
            {
                Console.WriteLine(n.data);
            }
            list.Clear();

            var c1 = new Circle();
            var r1 = new Rectangle();

            var c2 = new Circle(2, "red", false);

            Console.WriteLine(c1.ToString());
            Console.WriteLine(r1.ToString());
            Console.WriteLine(c2.ToString());

            var comp1 = new ComplexShape();
            comp1.Add(c1);
            comp1.Add(c2);
            comp1.Add(r1);

            Console.WriteLine("c1 Area: " + c1.Area());
            Console.WriteLine("c2 Area: " + c2.Area());
            Console.WriteLine("r1 Area: " + r1.Area());
            Console.WriteLine("complex Area: " + comp1.Area());
            Console.WriteLine("Perimeter: " + comp1.Perimeter());
            Console.WriteLine("END!");

            var stack1 = new ObjectStack(5);

            
            Console.WriteLine("stack1 empty before: " + stack1.IsEmpty());

            for (int i = 0; i < 6; ++i)
            {
                stack1.Push(i);
                Console.WriteLine("stack1 peek: " +  stack1.Peek());
                Console.WriteLine("stack1 empty: " + stack1.IsEmpty());
            }

            stack1.Pop();
            Console.WriteLine("after pop- stack1 peek: " + stack1.Peek());

            stack1.Clear();
            Console.WriteLine("stack1 empty after clear: " + stack1.IsEmpty());

        }
    }

}
