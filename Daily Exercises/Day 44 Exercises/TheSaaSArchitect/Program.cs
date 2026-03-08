using System.Text;

namespace TheSaaSArchitect
{
    abstract class Subscriber : IComparable<Subscriber>
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public DateTime JoinDate { get; set; }

        public abstract decimal CalculateMonthlyBill();

        public override bool Equals(object obj)
        {
            if (obj is Subscriber other)
            {
                return this.ID == other.ID;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return ID.GetHashCode();
        }

        public int CompareTo(Subscriber other)
        {
            if (other == null) return 1;

            int result = this.JoinDate.CompareTo(other.JoinDate);

            if (result == 0)
            {
                result = this.Name.CompareTo(other.Name);
            }
            return result;
        }
    }

    class BusinessSubscriber : Subscriber
    {
        public decimal FixedRate { get; set; }
        public decimal TaxRate { get; set; }

        public override decimal CalculateMonthlyBill()
        {
            return FixedRate * (1 + TaxRate);
        }
    }

    class ConsumerSubscriber : Subscriber
    {
        public double DataUsageGB { get; set; }
        public decimal PricePerGB { get; set; }

        public override decimal CalculateMonthlyBill()
        {
            return (decimal)DataUsageGB * PricePerGB;
        }
    }

    class ReportGenerator
    {
        public static void PrintRevenueReport(IEnumerable<Subscriber> subscribers)
        {
            Console.WriteLine("-------------------------------------------------------------");
            Console.WriteLine("Type\t\tName\t\tJoinDate\tBill");
            Console.WriteLine("-------------------------------------------------------------");

            foreach (Subscriber sub in subscribers)
            {
                string type = "";

                if (sub is BusinessSubscriber)
                    type = "Business";
                else
                    type = "Consumer";

                Console.WriteLine(
                    type + "\t\t" +
                    sub.Name + "\t\t" +
                    sub.JoinDate.ToShortDateString() + "\t" +
                    sub.CalculateMonthlyBill()
                );
            }
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Dictionary<string, Subscriber> subscriberMap = new Dictionary<string, Subscriber>();

            subscriberMap.Add("info@techcorp.com", new BusinessSubscriber { ID = Guid.NewGuid(), Name = "TechCorp", JoinDate = new DateTime(2022, 1, 1), FixedRate = 500, TaxRate = 0.1m });
            subscriberMap.Add("john@gmail.com", new ConsumerSubscriber { ID = Guid.NewGuid(), Name = "John Smith", JoinDate = new DateTime(2023, 5, 15), DataUsageGB = 45.5, PricePerGB = 2.5m });
            subscriberMap.Add("hr@bizstack.io", new BusinessSubscriber { ID = Guid.NewGuid(), Name = "BizStack", JoinDate = new DateTime(2022, 1, 1), FixedRate = 800, TaxRate = 0.15m });
            subscriberMap.Add("alice@yahoo.com", new ConsumerSubscriber { ID = Guid.NewGuid(), Name = "Alice Wong", JoinDate = new DateTime(2024, 2, 10), DataUsageGB = 120, PricePerGB = 1.8m });
            subscriberMap.Add("support@startup.co", new BusinessSubscriber { ID = Guid.NewGuid(), Name = "StartUp", JoinDate = new DateTime(2023, 11, 20), FixedRate = 300, TaxRate = 0.05m });

            var sortedSubscribers = (from entry in subscriberMap
                                     orderby entry.Value.CalculateMonthlyBill() descending
                                     select entry.Value).ToList();

            Console.WriteLine("SAAS REVENUE REPORT (Sorted by Bill Amount)");
            ReportGenerator.PrintRevenueReport(sortedSubscribers);

            Console.ReadKey();
        }
    }
}
