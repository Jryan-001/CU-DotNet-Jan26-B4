namespace EmployeeAnnualPerformanceBonusCalculationSystem
{
    public class EmployeeBonus
    {
        public decimal BaseSalary { get; set; }
        public int PerformanceRating { get; set; }
        public int YearsOfExperience { get; set; }
        public decimal DepartmentMultiplier { get; set; }
        public double AttendancePercentage { get; set; }
        public decimal NetAnnualBonus{
            get
            {
                if(BaseSalary<=0)
                    return 0;
                decimal bonusPercentage = 0;
                if (PerformanceRating == 5)
                    bonusPercentage = 0.25m;
                else if (PerformanceRating == 4)
                    bonusPercentage = 0.18m;
                else if (PerformanceRating == 3)
                    bonusPercentage = 0.12m;
                else if (PerformanceRating == 2)
                    bonusPercentage = 0.05m;
                else if (PerformanceRating == 1)
                    bonusPercentage = 0.00m;
                else
                    throw new InvalidOperationException("Rating is invalid.");

                decimal annualBonus = BaseSalary*bonusPercentage;

                if (YearsOfExperience > 10)
                {
                    annualBonus+=BaseSalary*0.05m;
                }else if (YearsOfExperience > 5)
                {
                    annualBonus += BaseSalary * 0.03m;
                }

                if (AttendancePercentage < 85)
                {
                    annualBonus -= annualBonus * 0.20m;
                }

                annualBonus *= DepartmentMultiplier;

                decimal maximumBonus = BaseSalary * 0.40m;
                if (annualBonus > maximumBonus)
                {
                    annualBonus = maximumBonus;
                }
                decimal tax = 0;
                if (annualBonus <= 150000)
                {
                    tax= 0.10m;
                }else if(annualBonus >150000 && annualBonus <= 300000)
                {
                    tax= 0.20m;
                } else
                    tax= 0.30m;
                annualBonus -= annualBonus * tax;
                return Math.Round(annualBonus, 2);
            }
        }
    } 
    internal class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
