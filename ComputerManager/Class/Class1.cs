using System;
using System.Collections.Generic;
using Equipment;

namespace Class
{ 
    public class ClassRoom
    {
        private List<Equipment.Equipment> ClassEquipment = new List<Equipment.Equipment>();

        public int EquipmentAmount { get => (ClassEquipment.Count); }
        public int WindowsPCs { get => (GetEquipmentByType(Equipment.Computer.OS.Windows)); }
        public int LinuxPCs { get => (GetEquipmentByType(Equipment.Computer.OS.Linux)); }
        public int DualBootPCs { get => (GetEquipmentByType(Equipment.Computer.OS.DualBoot)); }
        public int TotalPCs { get => (WindowsPCs + LinuxPCs + DualBootPCs); }

        private int GetEquipmentByType(Equipment.Computer.OS os)
        {
            int counter = 0;
            foreach (Equipment.Equipment e in ClassEquipment)
            {
                if (e is Computer &&
                    (e as Computer).OperatingSystem == os)
                {
                    ++counter;
                }
            }
            return counter;
        }
        public void AddEquipment(Equipment.Equipment e)
        {
            ClassEquipment.Add(e);
        }

        public void RemoveEquipment(Equipment.Equipment e)
        {
            ClassEquipment.Remove(e);
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
