namespace UtilityBillingSystem
{
    abstract class UtilityBill
    {
        public int ConsumerId { get; set; }
        public string ConsumerName { get; set; }
        public decimal UnitsConsumed { get; set; }
        public decimal RatePerUnit { get; set; }
        protected UtilityBill(int id, string name, decimal unit, decimal rate)
        {
            ConsumerId = id;
            ConsumerName = name;
            UnitsConsumed = unit;
            RatePerUnit = rate;
        }
        public abstract decimal CalculateBillAmount();
        public virtual decimal CalculateTax(decimal billAmount)
        {
            return billAmount * 0.05m;
        }
        public void PrintBill()
        {
            decimal total = CalculateBillAmount() + CalculateTax(CalculateBillAmount());
            Console.WriteLine($"Consumer ID: {ConsumerId}");
            Console.WriteLine($"Consumer Name: {ConsumerName}");
            Console.WriteLine($"Total Units: {UnitsConsumed}");
            Console.WriteLine($"Final Payable amount: {total}");
        }
    }
    class ElectricityBill : UtilityBill
    {
        public ElectricityBill(int id, string name, decimal unit, decimal rate) : base(id, name, unit, rate)
        {
            Console.WriteLine("In the electricty bill Constructor");
        }
        public override decimal CalculateBillAmount()
        {
            decimal amount = UnitsConsumed * RatePerUnit;
            if (UnitsConsumed > 300)
            {
                amount += amount * 0.10m;
            }
            return amount;
        }
    }
    class WaterBill : UtilityBill
    {
        public WaterBill(int id, string name, decimal unit, decimal rate) : base(id, name, unit, rate)
        {
            Console.WriteLine("In the Water bill Constructor");
        }
        public override decimal CalculateBillAmount()
        {
            return UnitsConsumed * RatePerUnit;
        }
        public override decimal CalculateTax(decimal billAmount)
        {
            return billAmount * 0.02m;
        }
    }

    class GasBill : UtilityBill
    {
        public GasBill(int id, string name, decimal unit, decimal rate) : base(id, name, unit, rate)
        {
            Console.WriteLine("In the Gas bill Constructor");
        }
        public override decimal CalculateBillAmount()
        {
            return (UnitsConsumed * RatePerUnit) + 150;
        }
        public override decimal CalculateTax(decimal billAmount)
        {
            return 0m;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            List<UtilityBill> list = new List<UtilityBill>
            {
                new ElectricityBill(10001, "Ajay", 252, 7.7m),
                new WaterBill(10005, "Birat", 209, 7.6m),
                new GasBill(10008, "Chandu", 50, 8.9m)
            };
            foreach (UtilityBill bill in list)
            {
                bill.PrintBill();
            }
        }
    }
}