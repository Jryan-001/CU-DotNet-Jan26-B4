using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PanValidityChecker
{
    class OLADriver
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string VehicleNo { get; set; }

        public List<Ride> Rides { get; set; }

        public override string ToString()
        {
            Console.WriteLine($"Driver ID - {Id}, Name - {Name}, Vehicle No - {VehicleNo}");
            foreach (var r in Rides)
            {
                Console.WriteLine(r);
            }
            return "\n";
        }

        //public OLADriver(int id, string name, string num, List<Ride> r) 
        //{
        //    Id = id;
        //    Name = name;
        //    VehicleNo = num;
        //    Rides = r;  
        //}

        //public string Display()
        //{
        //    return $"Driver Id - {Id} Driver Name - {Name} Driver Vehicle No - {VehicleNo} Rides Taken - {Rides}";
        //}
    }

    class Ride
    {
        public int RideID { get; set; }

        public string From { get; set; }

        public string To { get; set; }

        public decimal Fare { get; set; }

        public Ride(int id, string from, string to, decimal amount)
        {
            RideID = id;
            From = from;
            To = to;
            Fare = amount;
        }

        public override string ToString()
        {
            return $"Ride ID - {RideID}, From - {From}, To - {To}, Fare - {Fare}";
        }

    }
    internal class OlaRide
    {
        static void Main(string[] args)
        {
            Ride r1 = new Ride(111, "Kharar", "Chandigarh", 3000m);
            Ride r2 = new Ride(112, "Chandigarh", "Kharar", 3500m);
            Ride r3 = new Ride(113, "Kharar", "Jaipur", 4000m);
            Ride r4 = new Ride(114, "Jaipur", "Delhi", 5000m);
            Ride r5 = new Ride(115, "Kharar", "Delhi", 6000m);

            OLADriver d1 = new OLADriver()
            {
                Id = 1000,
                Name = "Raj",
                VehicleNo = "MX00AB3441",
                Rides = new List<Ride> { r1, r2 }
            };
            OLADriver d2 = new OLADriver()
            {
                Id = 1101,
                Name = "Sneha",
                VehicleNo = "MA20XY0001",
                Rides = new List<Ride> { r3, r4 }
            };
            OLADriver d3 = new OLADriver()
            {
                Id = 3051,
                Name = "Harpuneet",
                VehicleNo = "MA01MB3001",
                Rides = new List<Ride> { r5 }
            };

            Console.WriteLine(d1);
            Console.WriteLine(d2);
            Console.WriteLine(d3);
        }
    }
}
