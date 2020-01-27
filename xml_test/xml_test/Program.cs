using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace xml_test
{
    ///<include file='XMLFile1.xml' path='doc/members/member[@name="T:xml_test.A"]/*'/>
    public class A
    {
        /// <summary>
        /// property to store number
        /// </summary>
        int Num { get; set; }

        /// <summary>
        /// ctor
        /// </summary>
        /// <param name="num"></param>
        public A(int num)
        {
            Num = num;
        }

        /// <summary>
        /// prints the stored number
        /// </summary>
        /// <returns>
        /// the stored number
        /// </returns>
        public int Print()
        {
            Console.WriteLine(Num);
            return Num;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            A a1 = new A(10);
            a1.Print();
        }
    }
}
