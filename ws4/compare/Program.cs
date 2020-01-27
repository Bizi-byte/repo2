using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections.Specialized;
using System.DirectoryServices;
using Microsoft.Win32.SafeHandles;

namespace compare
{
    public class Compar
    {
        enum location { begin = 0 }
        public ulong Position { private get; set; }
        private OrderedDictionary Diff;
       public  Compar(String filePath1, String filePath2)
       {
            Diff = new OrderedDictionary();
            FileStream f1 = new FileStream(filePath1, FileMode.Open);
            FileStream f2 = new FileStream(filePath2, FileMode.Open);

            StreamReader sr1 = new StreamReader(f1);
            StreamReader sr2 = new StreamReader(f2);

            String s1;
            String s2;

            uint counter = 1;

            do
            {
                s1 = sr1.ReadLine();
                s2 = sr2.ReadLine();
                if (s1 != s2)
                {
                    Diff.Add(counter, ((null == s1)?"empty":s1) + " , " + ((null == s2)?"empty":s2));
                }
                ++counter;
            }
            while (s1 != null || s2 != null);
       }

        public void Dispose()
        {

        }
        public void Print()
        {
            ICollection keys = Diff.Keys;
            ICollection values = Diff.Values;

            uint[] keysarr = new uint[Diff.Count];
            String[] valuesarr = new String[Diff.Count];
            keys.CopyTo(keysarr, 0);
            values.CopyTo(valuesarr, 0);
            for(int i = 0; i < Diff.Count; ++i)
            {
                Console.WriteLine("line no {0}:\n{1}", keysarr[i], valuesarr[i]);
            }
        }
    }
    
    class Program
    {
        static void Main(string[] args)
        {

            //Comp(@"C:\Users\User\ishay\b.txt", @"C:\Users\User\ishay\c.txt");
            //compare.Compar c = new compare.Compar(@"C:\Users\student\source\repos\ishay-peleg\b.txt", @"C:\Users\student\source\repos\ishay-peleg\c.txt");
            FileStream f1 = new FileStream(@"C:\Users\student\source\repos\ishay-peleg\b.txt", FileMode.Open);
            
            IntPtr file = new IntPtr(); 
            SafeFileHandle file1 = new SafeFileHandle(file, true);
            //c.Print();

        }

        static void Comp(String filePath1, String filePath2)
        {
            FileStream f1 = new FileStream(filePath1, FileMode.Open);
            FileStream f2 = new FileStream(filePath2, FileMode.Open);

            StreamReader sr1 = new StreamReader(f1);
            StreamReader sr2 = new StreamReader(f2);

            String s1;
            String s2;

            uint counter = 0;

            do
            {
                s1 = sr1.ReadLine();
                s2 = sr2.ReadLine();
                if (s1 != s2)
                {
                    Console.WriteLine("line no {0}:", counter);
                    Console.WriteLine("{0} , {1}", (s1 == null)?"empty":s1, (s2 == null)?"empty":s2);
                }
                ++counter;
            }
            while (s1 != null || s2 != null);
            
        }
    }
}
