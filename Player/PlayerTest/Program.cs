
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Player;

namespace PlayerTest
{

    class Program
    {
        static void Main(string[] args)
        {
            MusicPlayer player = new MusicPlayer();
            player.Load("music1.txt");
            player.Play();
        }
    }
}
