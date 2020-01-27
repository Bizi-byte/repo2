using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Weather;
//using Travelers;

namespace Park
{
    public class ParkAdmin
    {
        public ParkAdmin()
        {
            WC = new WeatherCenter();
        }
        /*public void Enter(ITraveler t)
        {
            WC.StormInPark += t.StormAlert;
            WC.StormChangedIntensity += t.StormIntensityChangeAlert;
            WC.StormMaxIntensity += t.StormMaxIntensityAlert;
        }*/

        public void Enter(String name)
        {
            var t = new Single(name);
            AddToStormAlert(t);
        }

        public void Enter(String name, ulong members_num, ulong min_age)
        {
            ITraveler t;
            if (min_age < 65)
            {
                t = new Group(name, members_num);
            }
            else
            {
                t = new ElderCitizenGroup(name, members_num);
            }
            AddToStormAlert(t);
        }

        private void AddToStormAlert(ITraveler t)
        {
            WC.StormInPark += t.StormAlert;
            WC.StormChangedIntensity += t.StormIntensityChangeAlert;
            WC.StormMaxIntensity += t.StormMaxIntensityAlert;
        }

        private void RemoveFromStormAlert(ITraveler t)
        {
            WC.StormInPark -= t.StormAlert;
            WC.StormChangedIntensity -= t.StormIntensityChangeAlert;
            WC.StormMaxIntensity -= t.StormMaxIntensityAlert;
        }

        private abstract class ITraveler
        {
            public ITraveler(String name)
            {
                Name = name;
            }

            public abstract void StormAlert(object o, Storm.StormEventArgs e);
            public abstract void StormIntensityChangeAlert(Object o, Weather.Storm.StormEventArgs e);
            public abstract void StormMaxIntensityAlert(Object o, Weather.Storm.StormEventArgs e);

            public String Name { get; set; }
        }

        private class Single : ITraveler
        {
            public Single(String name) : base(name)
            {
                Console.WriteLine("I'm a single traveler called {0}", name);
            }
            public override void StormAlert(object o, Storm.StormEventArgs e)
            {
                Console.WriteLine("{0}: I'm a brave single traveler", base.Name);
            }
            public override void StormIntensityChangeAlert(Object o, Weather.Storm.StormEventArgs e)
            {
                Console.WriteLine("{0}: Time to be carefull!", base.Name);
            }
            public override void StormMaxIntensityAlert(Object o, Weather.Storm.StormEventArgs e)
            {
                Console.WriteLine("{0}: Time to go under shelter!", base.Name);
            }
        }

        private class Group : ITraveler
        {
            public Group(String name, ulong num) : base(name)
            {
                Num = num;
                Console.WriteLine("We are a group called {0} with {1} members", name, num);
            }
            public override void StormAlert(object o, Storm.StormEventArgs e)
            {
                Console.WriteLine("{0}: we are not afraid from a storm", base.Name);
            }
            public override void StormIntensityChangeAlert(Object o, Weather.Storm.StormEventArgs e)
            {
                Console.WriteLine("{0}: maybe we are wrong...", base.Name);
            }
            public override void StormMaxIntensityAlert(Object o, Weather.Storm.StormEventArgs e)
            {
                if (0 < Num)
                {
                    Console.WriteLine("{1}: we lost one member. we are now {0} members", --Num, base.Name);
                }
                
            }

            public ulong Num { get; set; }

        }

        private class ElderCitizenGroup : ITraveler
        {
            public ElderCitizenGroup(String name, ulong num) : base(name)
            {
                Num = num;
                Console.WriteLine("We are a group of elder citizens called {0} with {1} members", name, num);
            }
            public override void StormAlert(object o, Storm.StormEventArgs e)
            {
                Console.WriteLine("{0}: A storm is coming", base.Name);
            }
            public override void StormIntensityChangeAlert(Object o, Weather.Storm.StormEventArgs e)
            {
                Console.WriteLine("{0}: Considering going home", base.Name);
            }
            public override void StormMaxIntensityAlert(Object o, Weather.Storm.StormEventArgs e)
            {
                Console.WriteLine("{0}: luckily we are on the bus", base.Name);
            }
            public ulong Num { get; }

        }
        private readonly WeatherCenter WC;
    }
    
}
