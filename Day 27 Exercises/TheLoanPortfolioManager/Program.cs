using System.Security.Principal;

namespace TheLoanPortfolioManager
{
    class Loan
    {
        public string ClientName { get; set; }

        public double Principal { get; set; }
        public double InterestRate { get; set; }

        public Loan(string name, double amount, double rate)
        {
            ClientName = name;
            Principal = amount;
            InterestRate = rate;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            string file = "loan.csv";
            List<Loan> loanList = new List<Loan>();
            string directory = @"..\..\..\";
            string path = directory + file;
            using (StreamWriter sw = new StreamWriter(path, true))
            {
                do
                {
                    if (new FileInfo(path).Length == 0)
                        sw.WriteLine("ClientName, Principal, InterestRate");

                    Console.WriteLine("Enter Client Name");
                    string name = Console.ReadLine();
                    if (name == "stop")
                        break;
                    Console.WriteLine("Enter Pricipal Amount");
                    double amount = double.Parse(Console.ReadLine());

                    Console.WriteLine("Enter Interest Rate");
                    double rate = double.Parse(Console.ReadLine());

                    
                    sw.WriteLine($"{name}, {amount}, {rate}");
                }while(true);
            
            }
            using StreamReader sr = new StreamReader(path);

            sr.ReadLine();
            do
            {
                string i = sr.ReadLine();
                if (i == null)
                    break;

                string[] arr = i.Split(',');
                try
                {
                    double p = double.Parse(arr[1]);
                    double r = double.Parse(arr[2]);

                    loanList.Add(new Loan(arr[0], p, r));

                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex);
                }
            } while (true);
            Console.WriteLine($"{"CLIENT",-8} | {"PRINCIPAL",-10} | {"INTEREST",-12} | {"RISK LEVEL",-15}");
            Console.WriteLine("_________________________________________________");
            foreach(Loan l in loanList)
            {
                double interestAmount = l.Principal * ((l.InterestRate) / 100);

                string risk;
                if (l.InterestRate > 10)
                    risk = "High Risk";
                else if (l.InterestRate >= 5 && l.InterestRate <= 10)
                    risk = "Medium Risk";
                else risk = "Low Risk";
                Console.WriteLine($"{l.ClientName,-8} | {l.Principal,-10} | {interestAmount,-12} | {risk,-15}");

            }
        }
}
}
