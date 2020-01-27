using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace GettingStartedLib
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class CalculatorService : ICalculator
    {
        public double Add(double num1, double num2)
        {
            double result =  num1 + num2;
            Console.WriteLine("received: {0}, {1}", num1, num2);
            Console.WriteLine("result:{0}", result);
            return result;
        }
        public double Subtract(double num1, double num2)
        {
            double result = num1 - num2;
            Console.WriteLine("received: {0}, {1}", num1, num2);
            Console.WriteLine("result:{0}", result);
            return result;
        }
        public double Multiply(double num1, double num2)
        {
            double result = num1 * num2;
            Console.WriteLine("received: {0}, {1}", num1, num2);
            Console.WriteLine("result:{0}", result);
            return result;
        }
        public double Divide(double num1, double num2)
        {
            double result = num1 / num2;
            Console.WriteLine("received: {0}, {1}", num1, num2);
            Console.WriteLine("result:{0}", result);
            return result;
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }
    }
}
