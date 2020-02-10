using System;
using System.Reflection;
using System.Net;


namespace assemblies_test
{
    public class Test
    {
        public Test()
        {
            Console.WriteLine("creating test object");
        }
        public void Foo(){}
    }

    public class X
    {
        public X() => Console.WriteLine("Starting X object");
        public void Bar(){}
    }

    public class Base
    {
        
    }

    public class Derived : Base
    {
        public Derived()
        {
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var test = new Test();
            Type test_type = typeof(Test);
            Assembly info = test_type.Assembly;
            Console.WriteLine(test_type);
            Console.WriteLine(info);
            Console.WriteLine("Hello World!");

            var types = info.GetTypes();
            foreach (var type in types)
            {
                Console.WriteLine(type);
            }

            var full_types = info.DefinedTypes;
            foreach (var type in full_types)
            {
                Console.WriteLine(type);
                Console.WriteLine("base is:{0}",
                                  type.BaseType);
                foreach (var method in type.DeclaredMethods)
                {
                    Console.WriteLine(value: method.Name);
                }
            }

            Base b = new Derived();
            Console.WriteLine(b.GetType());
            using(var client = new WebClient())
            {
                client.DownloadFile(@"https://github.com/Bizi-byte/repo2/blob/master/csharp/HiddenAssembly/bin/Debug/netstandard2.0/HiddenAssembly.dll", "HiddenAssembly.dll");
            }

            var Assem = Assembly.LoadFrom(@"HiddenAssembly.dll");
            //var Assem = Assembly.LoadFrom("/home/ishay/repo2/csharp/HiddenAssembly/bin/Debug/netstandard2.0/HiddenAssembly.dll");
            //var Assem = Assembly.LoadFrom("https://github.com/Bizi-byte/repo2/blob/master/csharp/HiddenAssembly/bin/Debug/netstandard2.0/HiddenAssembly.dll");

            var Assemtypes = Assem.GetTypes();
            foreach (var type in Assemtypes)
            {
                Console.WriteLine(type);
            }

            var fullAssemtypes = Assem.DefinedTypes;
            foreach (var type in fullAssemtypes)
            {
                Console.WriteLine(type);
                Console.WriteLine("base is:{0}",
                                  type.BaseType);
                foreach (var method in type.DeclaredMethods)
                {
                    Console.WriteLine(value: method.Name);
                }
            }
        }
    }
}
