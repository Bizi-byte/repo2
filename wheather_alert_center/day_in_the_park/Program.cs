using System;
using Weather;
using Park;
//using Travelers;

namespace day_in_the_park
{
    class Program
    {
        static void Main(string[] args)
        {
            //var ws1 = new WeatherCenter();

            /*var t1 = new Single("babi");
            var t2 = new Group("people", 3);
            var t3 = new ElderCitizenGroup("youngsters", 5);*/

            var park1 = new ParkAdmin();

            /*park1.Enter(t1);
            park1.Enter(t2);
            park1.Enter(t3);*/

            park1.Enter("john");
            park1.Enter("work", 10, 60);
            park1.Enter("matnas", 20, 66);

            var s1 = new Storm();
            s1.Intensity = 6;
            s1.Intensity = 10;

            Console.ReadKey();


        }
    }
}
