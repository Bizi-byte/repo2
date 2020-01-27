using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqTest
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> db = new List<int> { 1, 2, 3, 4 };
            List<int> db1 = new List<int> { 1, 2, 3, 4 };
            List<string> dbs = new List<string> { "aft", "gno", "ako" };
            var ldb = db.Select<int, int>(n => { if (n < 3) return n; else return 0; });
            foreach (var item in ldb)
            {
                Console.WriteLine(item);
            }

            IEnumerable<int> nums = from i in db where i < 3 select i;

            foreach (var item in nums)
            {
                Console.WriteLine(item);
            }

            var q1 = from num in db
                     where num < 3
                     select num;
            var q1Count = q1.Count();

            var l1 = q1.ToList();
            var a1 = q1.ToArray();
            Console.WriteLine("q1 size: {0}", q1Count);
            foreach (var item in q1)
                Console.WriteLine("q1: {0}", item);
            db[2] = 0;

            foreach (var item in l1)
            {
                Console.WriteLine("l1:{0}", item);
            }

            foreach (var item in a1)
            {
                Console.WriteLine("a1:{0}", item);
            }

            foreach (var item in q1)
            {
                Console.WriteLine("q1:{0}", item);
            }
            Console.WriteLine("average:{0}", db.Average());

            var dbconcat = db.Concat(db1);

            foreach (var item in dbconcat)
            {
                Console.WriteLine("con:{0}", item);
            }

            var q2 = from s in dbs
                     orderby s ascending
                     group s by s[0];
            int counter = 0;
            foreach (var item in q2)
            {

                foreach (var item1 in item)
                {
                    Console.WriteLine("{0}:{1}", counter, item1);
                }
                ++counter;
            }
                     
        }

    }
}
