namespace Practice
{
    interface ITimer
    {
        void SetTimer(int time);
    }
    interface ISmart
    {
        void Smart(string network);
    }
    
    abstract class KitchenElectricAppliance
    {
        public int PowerConsumption { get; set; }

        public string ModelName { get; set; }

        //public double Price { get; set; }

        protected KitchenElectricAppliance(int power, string name)
        {
            PowerConsumption = power;
            ModelName = name;
        }
        public abstract void Cook();

        public virtual void Preheat()
        {
            Console.WriteLine($"{ModelName}: No Preheating needed.");
        }
    }

    class Microwave: KitchenElectricAppliance, ITimer
    {
        public Microwave(int power, string name):base(power, name) { }
        
        public void SetTimer(int time)
        {
            Console.WriteLine($"{ModelName} set for {time} minutes.");
        }

        public override void Cook()
        {
            Console.WriteLine($"{ModelName} is cooking food.");
        }
    }

    class ElectricOven : KitchenElectricAppliance, ITimer, ISmart
    {
        public ElectricOven(int power, string name):base(power, name) { }

        public void SetTimer(int time)
        {
            Console.WriteLine($"{ModelName} set for {time} minutes.");
        }
        public void Smart(string network)
        {
            Console.WriteLine($"{ModelName} connected to {network} wifi Network.");
        }

        public override void Preheat()
        {
            Console.WriteLine($"{ModelName} needs to Preheat to set a base temperature requirement.");
        }
        public override void Cook()
        {
            Console.WriteLine($"{ModelName} is cooking the food item.");
        }
    }

    class AirFryer: KitchenElectricAppliance
    {
        public AirFryer(int power, string name):base(power, name) { }

        public override void Cook()
        {
            Console.WriteLine($"{ModelName} is Air Frying the food item.");
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            List<KitchenElectricAppliance> appliances = new List<KitchenElectricAppliance>()
            {
                new Microwave(1000, "WavePro"),
                new ElectricOven(900, "Oven900"),
                new AirFryer(1100, "AirQuick")
            };
            foreach(var appliance in appliances)
            {
                appliance.Preheat();
                appliance.Cook();
            }

            foreach(var appliance in appliances)
            {
                if(appliance is ISmart network)
                {
                    network.Smart("Capgemini_x0");
                }
                else
                {
                    Console.WriteLine($"{appliance.ModelName} is not Wifi supported appliance.");
                }
            }
        }
    }
}
