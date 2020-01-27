using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;

namespace downloadwebpage
{
    class Program
    {
        static void Main(string[] args)
        {
            FileStream f = File.Create("web.html");


            WebClient wc = new WebClient();
            String webpage = wc.DownloadString(@"https://www.google.co.il/?gws_rd=ssl");

            StreamWriter sw = new StreamWriter(f);
            sw.Write(webpage);
            System.Diagnostics.Process.Start("web.html");
            f.Close();
        }
    }
}
