using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GettingStartedClient.ServiceReference1;

namespace GettingStartedClient
{
    class Program
    {
        static void Main(string[] args)
        {
            CalculatorClient c = new CalculatorClient();

            double x = 10;
            double y = 5;
            double result = c.Add(x, y);
            Console.WriteLine("Added {0} and {1}, and got {2}", x, y, result);

            result = c.Subtract(x, y);
            Console.WriteLine("Substracted {0} and {1}, and got {2}", x, y, result);

            result = c.Multiply(x, y);
            Console.WriteLine("Multiplied {0} and {1}, and got {2}", x, y, result);

            result = c.Divide(x, y);
            Console.WriteLine("Divided {0} and {1}, and got {2}", x, y, result);

            Console.WriteLine("press enter");
            Console.ReadLine();
            c.Close();






        }
    }
}
