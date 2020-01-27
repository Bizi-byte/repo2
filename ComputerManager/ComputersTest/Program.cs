using System;
using Equipment;
using Class;

namespace ComputersTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Computer c1 = new Computer(Computer.OS.Linux);
            Computer c2 = new Computer(Computer.OS.Windows);
            Computer c3 = new Computer(Computer.OS.DualBoot);

            Projector p1 = new Projector();

            Equipment.Equipment e1 = c1;

            Console.WriteLine("c1: serial:{0}, os:{1}", c1.SerialNumber, c1.OperatingSystem);
            Console.WriteLine("c2: serial:{0}, os:{1}", c2.SerialNumber, c2.OperatingSystem);
            Console.WriteLine("c3: serial:{0}, os:{1}", c3.SerialNumber, c3.OperatingSystem);

            Console.WriteLine(typeof(Computer));
            Console.WriteLine(e1.GetType());

            ClassRoom cr1 = new ClassRoom();
            
            cr1.AddEquipment(c1);
            
            cr1.AddEquipment(c2);
            cr1.AddEquipment(c3);

            cr1.AddEquipment(p1);

            Console.WriteLine("class room equipment amount:{0}, computers:{1}", cr1.EquipmentAmount, cr1.TotalPCs);
        }
    }
}
