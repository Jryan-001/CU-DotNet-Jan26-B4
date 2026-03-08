namespace Demo05LoanInheritance
{
    class Loan
    {
        public string LoanNumber { get; set; }
        public string CustomerName { get; set; }

        public decimal PrincipalAmount { get; set; }

        public int TenureInYears { get; set; }
        public Loan()
        {
            LoanNumber = string.Empty;
            CustomerName = string.Empty;
            PrincipalAmount = 0;
            TenureInYears = 0;
        }

        public Loan(string num, string name, decimal amount, int years)
        {
            LoanNumber = num;
            CustomerName = name;
            PrincipalAmount = amount;
            TenureInYears = years;
        }

        public decimal CalculateEMI()
        {
            decimal Emi = PrincipalAmount + (PrincipalAmount * 0.10m * TenureInYears);
            return Emi / (TenureInYears * 12);
        }
    }
    class HomeLoan : Loan
    {
        public HomeLoan(string num, string name, decimal amount, int years) : base(num, name, amount, years)
        {
            Console.WriteLine("HomeLoan Constructor");
        }
        public new decimal CalculateEMI()
        {
            decimal OneTimeProcessingFee = PrincipalAmount + (PrincipalAmount * 0.01m);
            decimal Emi = OneTimeProcessingFee + (OneTimeProcessingFee * 0.08m * TenureInYears);
            
            return Emi / (TenureInYears * 12);
        }
    }

    class CarLoan : Loan
    {
        public CarLoan(string num, string name, decimal amount, int years) : base(num, name, amount, years)
        {
            Console.WriteLine("CarLoan Constructor");
        }
        public new decimal CalculateEMI()
        {
            decimal InsuranceCharge = PrincipalAmount + 15000m;
            decimal Emi = InsuranceCharge + (InsuranceCharge * 0.09m * TenureInYears);
            
            return Emi / (TenureInYears * 12);
        }

        //public CarLoan(decimal amount, int years)
        //{
        //    PrincipalAmount = amount;
        //    TenureInYears = years;
        //}
    }
    internal class LoanEMICalculationSystem
    {
        static void Main(string[] args)
        {
            //Loan[] l = new Loan[] {
            //new HomeLoan("jdfjahjef", "dkjwahfg", 1000m, 1),
            //new HomeLoan("sudhish","sudhish", 1100m, 1),
            //new CarLoan("Rahul", "rahul", 1000m, 1),
            //new CarLoan("Jai", "JAi", 1100m, 1)
            //};

            ////HomeLoan h1 = new HomeLoan();

            //for (int i = 0; i < l.Length; i++)
            //{
            //    decimal e = l[i].CalculateEMI();
            //    Console.WriteLine(e);

            //}
            Loan[] l = new Loan[]
            {
                new HomeLoan("HL001", "Raj", 500000m, 5),
                new HomeLoan("HL002", "Amit", 600000m, 10),
                new CarLoan("CL001", "Rahul", 300000m, 3),
                new CarLoan("CL002", "Priya", 400000m, 4)
            };
            
            for (int i = 0; i < l.Length; i++)
            {
                // This calls the BASE class method because reference type is Loan
                decimal emi = l[i].CalculateEMI();
                Console.WriteLine($"{l[i].CustomerName}: EMI = {emi:f2}");
            }
            
            HomeLoan home = new HomeLoan("HL003", "Neha", 500000m, 5);
            CarLoan car = new CarLoan("CL003", "Vikram", 300000m, 3);
            // These call the DERIVED class methods
            Console.WriteLine($"HomeLoan EMI: {home.CalculateEMI():f2}");
            Console.WriteLine($"CarLoan EMI: {car.CalculateEMI():f2}");

        }
    }
}
