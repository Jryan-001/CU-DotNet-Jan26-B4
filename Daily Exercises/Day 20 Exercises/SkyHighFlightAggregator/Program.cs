namespace SkyHighFlightAggregator
{

    class Flight:IComparable<Flight>
    {
        public string FlightNumber { get; set; }

        public decimal Price { get; set; }

        public TimeSpan Duration { get; set; }

        public DateTime DepartureTime { get; set; }

        public Flight()
        {
            FlightNumber = string.Empty;
            Price = 0;
            Duration = TimeSpan.Zero;
            DepartureTime = DateTime.MinValue;
        }

        public Flight(string num, decimal price, TimeSpan duration, DateTime departuretime)
        {
            FlightNumber=num;
            Price = price;
            Duration = duration;
            DepartureTime=departuretime;
        }

        public int CompareTo(Flight? other)
        {
            if (other == null)
                return 1;
            return this.Price.CompareTo(other?.Price);
        }

        public override string ToString()
        {
            return $"Flight Number - {FlightNumber} Price - {Price} Duration - {Duration} Time - {DepartureTime:t}";
        }
    }

    class DurationComparer : IComparer<Flight>
    {
        public int Compare(Flight? x, Flight? y)
        {
            if (x == null && y == null) return 0;
            if (x == null) return -1;
            if (y == null) return 1;

            return x.Duration.CompareTo(y.Duration);
        }
    }

    class DepartureComparer : IComparer<Flight>
    {
        public int Compare(Flight? x, Flight? y)
        {
            if (x == null && y == null) return 0;
            if (x == null) return -1;
            if (y == null) return 1;

            return x.DepartureTime.CompareTo(y.DepartureTime);
        }
    }


    internal class Program
    {
        static void Main(string[] args)
        {
            List<Flight> flights = new List<Flight>()
            {
                new Flight
                (
                    "AI101", 5500, TimeSpan.FromHours(2.5), DateTime.Today.AddHours(9)
                ),
                new Flight
                (
                    "UK202", 4200, TimeSpan.FromHours(1.8), DateTime.Today.AddHours(6)
                ),
                new Flight
                (
                    "IX303", 4800, TimeSpan.FromHours(3.1), DateTime.Today.AddHours(7)
                ),
                new Flight
                (
                    "SG404", 3900, TimeSpan.FromHours(2.0), DateTime.Today.AddHours(5)
                )
            };


            flights.Sort();
            Console.WriteLine("Economy View:");
            foreach (var flight in flights)
                Console.WriteLine(flight);

             
            flights.Sort(new DurationComparer());
            Console.WriteLine("Business Runner View:");
            foreach (var flight in flights)
                Console.WriteLine(flight);
             

            flights.Sort(new DepartureComparer());
            Console.WriteLine("Early Bird View:");
            foreach (var flight in flights)
                Console.WriteLine(flight);

        }
    }
}
