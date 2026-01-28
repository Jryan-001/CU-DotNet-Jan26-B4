namespace EmployeeCompensationManagementSystem
{
    class Employee
    {
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }

        public decimal BasicSalary { get; set; }

        public int ExperienceInYears { get; set; }

        public Employee()
        {
            EmployeeId = 0;
            EmployeeName = string.Empty;
            BasicSalary = 0;
            ExperienceInYears = 0;
        }

        public Employee(int id, string name, decimal salary, int years)
        {
            EmployeeId = id;
            EmployeeName = name;
            BasicSalary = salary;
            ExperienceInYears = years;
        }

        public decimal CalculateAnnualSalary()
        {
            decimal AnnualSalary = BasicSalary * 12;
            return AnnualSalary;
        }

        public void DisplayEmployeeDetails()
        {
            Console.WriteLine( $"Name - {EmployeeName}, Id - {EmployeeId}, Salary - {BasicSalary}, Experience - {ExperienceInYears}, Annual Salary - {CalculateAnnualSalary()}");
        }
    }

    class PermanentEmployee : Employee
    {
        public PermanentEmployee(int id, string name, decimal salary, int years): base(id, name, salary, years) 
        {
            Console.WriteLine("in Permanent Employee Constructor");
        }

        

        public new decimal CalculateAnnualSalary()
        {
            decimal HRA = 0.2m * BasicSalary;
            decimal SpecialAllowance = 0.1m * BasicSalary;
            decimal LoyaltyBonus = 0m;
            if (ExperienceInYears >= 5) 
            {
                LoyaltyBonus += 50000m;
            }
            decimal total = (BasicSalary + HRA + SpecialAllowance) * 12 + LoyaltyBonus;
            return total;
        }

        public new void DisplayEmployeeDetails()
        {
            Console.WriteLine($"Name - {EmployeeName}, Id - {EmployeeId}, Salary - {BasicSalary}, Experience - {ExperienceInYears}, Annual Salary - {CalculateAnnualSalary()}");
        }

    } 

    class ContractEmployee : Employee
    {
        public int ContractDurationInMonths { get; set; }
        public ContractEmployee(int id, string name, decimal salary, int years, int duration) : base(id, name, salary, years)
        {
            ContractDurationInMonths = duration;
            Console.WriteLine("In Contract Employee Constructor");
        }

        public new decimal CalculateAnnualSalary()
        {
            decimal Bonus = 0m;
            if (ContractDurationInMonths >= 12)
            {
                Bonus += 30000m;
            }
            decimal total = (BasicSalary * 12) + Bonus;
            return total ;
        }

        public new void DisplayEmployeeDetails()
        {
            Console.WriteLine($"Name - {EmployeeName}, Id - {EmployeeId}, Salary - {BasicSalary}, Contract Duration - {ContractDurationInMonths} months, Experience - {ExperienceInYears}, Annual Salary - {CalculateAnnualSalary()}");
        }
    }


    class InternEmployee : Employee
    {
        public InternEmployee(int id, string name, decimal salary, int years) : base(id, name, salary, years)
        {
            Console.WriteLine("In Intern Employee Constructor");
        }

        public new decimal CalculateAnnualSalary()
        {
            decimal FixedStipend = BasicSalary;
            decimal total = BasicSalary * 12;
            return total;
        }
        public new void DisplayEmployeeDetails()
        {
            Console.WriteLine($"Name - {EmployeeName}, Id - {EmployeeId}, Salary - {BasicSalary}, Experience - {ExperienceInYears}, Annual Salary - {CalculateAnnualSalary()}");
        }

    }
    internal class Program
    {
        static void Main(string[] args)
        {
            // Demonstrating method hiding behavior
            Employee emp1 = new PermanentEmployee(112, "Ram", 30000m, 5);
            PermanentEmployee emp2 = new PermanentEmployee(112, "Ram", 30000m, 5);
            Console.WriteLine("\n--- Method Hiding Demo ---");
            Console.WriteLine($"Base reference (emp1): {emp1.CalculateAnnualSalary()}");    // Calls Employee.CalculateAnnualSalary()
            Console.WriteLine($"Derived reference (emp2): {emp2.CalculateAnnualSalary()}"); // Calls PermanentEmployee.CalculateAnnualSalary()
            Console.WriteLine("\n--- All Employees ---");
            Employee baseEmp = new Employee(111, "Raj", 20000m, 2);
            ContractEmployee emp3 = new ContractEmployee(113, "Rahul", 25000m, 2, 13);
            InternEmployee emp4 = new InternEmployee(114, "Rajat", 15000m, 3);
            baseEmp.DisplayEmployeeDetails();
            emp2.DisplayEmployeeDetails();
            emp3.DisplayEmployeeDetails();
            emp4.DisplayEmployeeDetails();

        }
    }
}
