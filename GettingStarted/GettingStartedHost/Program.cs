using System;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GettingStartedLib;

namespace GettingStartedHost
{
    class Program
    {
        static void Main(string[] args)
        {
            Uri uri = new Uri("http://localhost:8733/GettingStarted/");

            ServiceHost selfHost = new ServiceHost(typeof(CalculatorService), uri);

            try
            {
                selfHost.AddServiceEndpoint(typeof(ICalculator), new WSHttpBinding(), "CalculatorService");

                ServiceMetadataBehavior smb = new ServiceMetadataBehavior();
                smb.HttpGetEnabled = true;
                selfHost.Description.Behaviors.Add(smb);

                selfHost.Open();
                Console.WriteLine("The service is ready");

                Console.WriteLine("press enter to stop service");
                Console.WriteLine();
                Console.ReadLine();
                selfHost.Close();
            }

            catch(CommunicationException ce)
            {
                Console.WriteLine("exception: {0}", ce.Message);
                selfHost.Abort();
            }
        }
    }
}
