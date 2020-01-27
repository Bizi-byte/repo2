using System;

namespace Equipment
{
    public interface Equipment
    {
        public uint SerialNumber { get; set; }

    }
    public class Computer : Equipment
    {
        public uint SerialNumber { get; set; }
        private static uint SerialCounter = 0;
        public enum OS {
            Windows,
            Linux,
            DualBoot
        }

        public OS OperatingSystem { get; private set; }

        public Computer(OS os)
        {
            OperatingSystem = os;
            SerialNumber = SerialCounter++;
        }

        public Computer()
        {
        }
    }

    public class Projector : Equipment
    {
        public uint SerialNumber { get; set; }

    }
}
