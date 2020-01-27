using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChatRoom;

namespace ChatRoomClient
{
    class Program
    {
        static void Main(string[] args)
        {
            Client c = new Client(@"conf.txt");
            c.Run();
        }
    }
}
