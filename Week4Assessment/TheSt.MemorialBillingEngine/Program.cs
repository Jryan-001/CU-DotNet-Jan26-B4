namespace TheSt.MemorialBillingEngine
{
    class Patient
    {
        public string Name { get; set; }

        public decimal BaseFee { get; set; }

        public Patient()
        {
            Name = string.Empty;
            BaseFee = 0;
        }

        public Patient(string name, decimal fee)
        {
            Name = name;
            BaseFee = fee;
        }

        public virtual decimal CalculateFinalBill()
        {

            return BaseFee;
        }
    }

    class Inpatient : Patient
    {
        public Inpatient(string name, decimal fee, int days, decimal rate) : base(name, fee)
        {
            DaysStayed = days;
            DailyRate = rate;
        }
        public int DaysStayed { get; set; }

        public decimal DailyRate { get; set; }

        
        public override decimal CalculateFinalBill()
        {
            decimal total = BaseFee + (DaysStayed * DailyRate);
            return total;
        }
    }

    class Outpatient : Patient
    {
        public decimal Procedurefee { get; set; }
        public Outpatient(string name, decimal fee, decimal fees) : base(name, fee)
        {
            Procedurefee = fees;
        }

        public override decimal CalculateFinalBill()
        {
            decimal total = BaseFee + Procedurefee;
            return total;
        }

    }


    class EmergencyPatient : Patient
    {
        public int SeverityLevel { get; set; }

        public EmergencyPatient(string name, decimal fee, int level) : base(name, fee)
        {
            SeverityLevel = level;
        }

        public override decimal CalculateFinalBill()
        {
            decimal total = BaseFee * SeverityLevel;
            return total;
        }
    }

    class HospitalBilling
    {
        private List<Patient> patients = new List<Patient>();
        
        public void AddPatient(Patient p)
        {
            patients.Add(p);
        }

        public void GenerateDailyReport()
        {
            foreach (var patient in patients)
            {
                Console.WriteLine($"Name - {patient.Name} Bill - {patient.CalculateFinalBill().ToString("C2")}");
            }
        }

        public decimal CalculateTotalRevenue()
        {
            decimal total = 0;
            foreach (var patient in patients)
            {
                total +=  patient.CalculateFinalBill();
            }
            return total;
        }

        public int GetInpatientCount()
        {
            int count = 0;
            foreach(var patient in patients)
            {
                if(patient is Inpatient)
                {
                    count++;
                }
            }
            return count;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Patient patient = new Patient();
            HospitalBilling billing = new HospitalBilling();
            billing.AddPatient(new Inpatient("Snehit", 3000m, 4, 1200m));
            billing.AddPatient(new Outpatient("Antil", 700m, 1300m));
            billing.AddPatient(new EmergencyPatient("Subodh", 1100m, 5));
            billing.GenerateDailyReport();
            Console.WriteLine($"Total Revenue: {billing.CalculateTotalRevenue():C2}");
            Console.WriteLine($"Inpatient Count: {billing.GetInpatientCount()}");

        }
    }
}
