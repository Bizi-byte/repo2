using System;

namespace HiddenAssembly
{
    public class Base
    {
       
        public Base() => Console.WriteLine("Base");

        public override string ToString()
        {
            return "I am Base";
        }
    }

    public class Derived : Base
    {
        
    }
}
