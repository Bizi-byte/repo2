using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace hello_world
{
    class Hello
    {
        static void Main(string[] args)
        {
            Console.WriteLine("hello_world!");
            //Console.ReadKey();
            var assem = Assembly.LoadFrom(@"C:\Users\Yishai Peleg\source\repos\ishay-peleg\TestLibrary\obj\Debug\TestLibrary.dll");
            var types = assem.GetTypes();
            foreach(Type t in types)
                Console.WriteLine("type:{0}", t.Name);
            MethodInfo m = types[0].GetMethod("Print1");
            var test = Activator.CreateInstance(types[0]);
            m.Invoke(test, null);

            var m1 = types[0].GetMethods();
            Console.WriteLine(m1.Count());
            foreach (MethodInfo mi in m1)
            {
                Console.WriteLine("name:{0}, type{1}", mi.Name, mi.MemberType);
                //if (mi.MemberType == MemberTypes.Method)
                //    mi.Invoke(test, null);
            }

            m1[1].Invoke(test, null);
        }
    }
}
