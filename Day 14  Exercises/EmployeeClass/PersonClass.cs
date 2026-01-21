using System.ComponentModel.DataAnnotations;

namespace TextAnalysisUtility
{
    class Employee
    {
        int id;

        public void SetID(int id)
        {
            this.id = id; 
        }

        public string Name { get; set; }


        private string department;

        public string Department
        {
            get { return department; }
            set { if(value == "Account" || value == "Sales" || value == "IT")
                { department = value; }
                else { department = "Not Listed"; }
            }
        }

        private int salary;

        public int Salary
        {
            get { return salary; }
            set { if(value >= 50000 && value <= 90000) 
                    salary=value; }
        }

        public void Display()
        {
            Console.WriteLine($"ID of Employee: {id}");
            Console.WriteLine($"Name of Employee: {Name}");
            Console.WriteLine($"Department of Employee: {department}");
            Console.WriteLine($"Salary of Employee: {salary}");
        }



    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Employee e = new Employee();
            Employee e1 = new Employee();
            e.SetID(10);
            e.Name = "Harpu";
            e.Department = "Marketing";
            e.Salary = 50001;
            e.Display();

            e1.SetID(15);
            e1.Name = "Rahul";
            e1.Department = "Account";
            e1.Salary = 90001;
            e1.Display();
            
        }
    }
}
