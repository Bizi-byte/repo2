using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace streams
{
    class Program
    {
        static void Main(string[] args)
        {
            FileStream file = new FileStream(@"C:\Users\User\ishay\a.txt", FileMode.Create);
            Console.WriteLine("can read {0}", file.CanRead);
            Console.WriteLine("can write {0}", file.CanWrite);
            Console.WriteLine("can seek {0}", file.CanSeek);

            file.WriteByte(2);
            file.WriteByte(3);

            byte[] buffer = { 49, 50, 51, 52 };
            byte[] buffer1 = new byte[4];

            file.Write(buffer, 0, buffer.Length);

            Console.WriteLine("file length {0}", file.Length);
            Console.WriteLine("file position {0}", file.Position);

            file.Position = 0;

            Console.WriteLine(file.ReadByte());
            Console.WriteLine(file.ReadByte());

            Console.WriteLine("file length {0}", file.Length);
            Console.WriteLine("file position {0}", file.Position);

            file.Read(buffer1, 0, 4);

            foreach (byte b in buffer1)
            {
                Console.Write(b + " ");
            }

            Console.WriteLine("file length {0}", file.Length);
            Console.WriteLine("file position {0}", file.Position);

            var text = new StreamWriter(file);
            text.AutoFlush = true;
            text.WriteLine("Have a nice day!");
            text.Write("have another nice day!");
            text.Write("have third nice day!");

            StreamReader sr = new StreamReader(file);
            file.Position = 0;
            String tmp = sr.ReadLine();
            Console.WriteLine(tmp);

            for(int i = 0; i < 42; ++i)
            {
                char tmp1 = Convert.ToChar(sr.Read());
                Console.Write(tmp1);
            }
            Console.WriteLine();

        }
    }
}
