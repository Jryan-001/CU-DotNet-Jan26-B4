namespace TechnicalChallenge
{

    abstract class vehicle
    {
        public string ModelName { get; set; }
        public abstract void Move();

        public virtual string GetFuelStatus()
        {
            return $"Fuel level is stable";
        }
    }

    class ElectricCar : vehicle
    {
        public override void Move()
        {
            Console.WriteLine($"{ModelName} is gliding silently on battery power.");
        }

        public override string GetFuelStatus()
        {
            return $"{ModelName} battery is at 80%.";
        }
    }

    class HeavyTruck : vehicle
    {
        public override void Move()
        {
            Console.WriteLine($"{ModelName} is gliding silently on battery power.");
        }
    }

    class CargoPlane : vehicle
    {
        public override void Move()
        {
            Console.WriteLine($"{ModelName} is ascending to 30,000 feet.");
        }

        public override string GetFuelStatus()
        {
            return base.GetFuelStatus() + $" Checking jet fuel reserves...";
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            vehicle[] v1 = new vehicle[]
            {
                new ElectricCar(){ ModelName = "koenigsegg"},
                new HeavyTruck(){ ModelName = "Maserati"},
                new CargoPlane(){ ModelName = "AlpineOne"}
            };
            foreach (var v in v1)
            {
                v.Move();
                Console.WriteLine(v.GetFuelStatus());
            }
        }
    }
}
