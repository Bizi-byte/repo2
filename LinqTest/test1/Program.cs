using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test1
{
    class Program
    {
        static void Main(string[] args)
        {
            using (childrenEntities db = new childrenEntities())
            {
                //var eliraz = new peleg
                //{
                //    name = "eliraz",
                //    nickname = "shuli",
                //    birth = new DateTime(2011, 12, 8)
                //};

                //db.pelegs.Add(eliraz);
                //db.SaveChanges();

                var names = from entry in db.pelegs
                            //where entry.name == "tevel"
                            select entry.birth;
                foreach (var item in names)
                {
                    //Console.WriteLine("name:{0}", item.name);
                    //Console.WriteLine("nickname:{0}", item.nickname);
                    Console.WriteLine("birth:{0}", item);
                }            
            }
        }
    }
}
