using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weather
{
    public class Storm
    {
        public Storm(ulong intensity = 1)
        {
            _intensity = intensity;
            StormAlert?.Invoke(this, new StormEventArgs(_intensity));
        }
        public ulong Intensity
        {
            get { return _intensity; }
            set
            {
                _intensity = value;
                if (_intensity == 10)
                {
                    MaxStormIntensity?.Invoke(this, new StormEventArgs(_intensity));
                }
                else
                {
                    StormChangedIntensity?.Invoke(this, new StormEventArgs(_intensity));
                }
            }
        }
        ulong _intensity;
        static public event EventHandler<StormEventArgs> StormAlert;
        static public event EventHandler<StormEventArgs> StormChangedIntensity;
        static public event EventHandler<StormEventArgs> MaxStormIntensity;

        public class StormEventArgs : EventArgs
        {
            public ulong Intensity { get; set; }
            public StormEventArgs(ulong intensity)
            {
                Intensity = intensity;
            }
        }
    }

    public class WeatherCenter
    {
        public WeatherCenter()
        {
            Weather.Storm.StormAlert += WSStormAlert;
            Weather.Storm.StormChangedIntensity += WSStormIntensityChangeAlert;
            Weather.Storm.MaxStormIntensity += WSMaxIntensityAlert;
        }

        public void WSStormIntensityChangeAlert(Object o, Weather.Storm.StormEventArgs e)
        {
            Console.WriteLine("intensity is {0}!! ", e.Intensity);
            StormChangedIntensity?.Invoke(o, e);
        }

        public void WSStormAlert(Object o, Weather.Storm.StormEventArgs e)
        {
            Console.WriteLine("Storm arrives!");
            StormInPark?.Invoke(o, e);
        }

        public void WSMaxIntensityAlert(Object o, Weather.Storm.StormEventArgs e)
        {
            Console.WriteLine("intensity is max!");
            StormMaxIntensity?.Invoke(o, e);
        }

        public event EventHandler<Storm.StormEventArgs> StormInPark;
        public event EventHandler<Storm.StormEventArgs> StormChangedIntensity;
        public event EventHandler<Storm.StormEventArgs> StormMaxIntensity;

    }
}
