using System.Linq.Expressions;
using System.Net;

namespace GlobalFreightTrackingSystem
{
    abstract class Shipment
    {
        public string TrackingId { get; set; }
        public double Weight { get; set; }
        public string Destination { get; set; }

        //protected Shipment(string id, double weight, string endpoint)
        //{
        //    TrackingId = id;
        //    Weight = weight;
        //    Destination = endpoint;
        //}
        public bool IsFragile { get; set; }
        public bool IsReinforced { get; set; }

        protected static HashSet<string> RestrictedZones = new HashSet<string> { "North Pole", "Unknown Island"};
        public abstract void ProcessShipment();

        protected void ValidateBusinessRules()
        {
            if(Weight<=0) throw new ArgumentOutOfRangeException("Weight should be greater than zero.");

            if(RestrictedZones.Contains(Destination)) throw new RestrictedDestinationException(Destination);

            if (IsFragile && !IsReinforced) throw new InsecurePackagingException("Fagile shipment is not reinforced.");
        }

    }
    interface ILoggable
    {
        void SaveLog(string message);
    }
    class ExpressShipment : Shipment
    {
        public override void ProcessShipment()
        {
            ValidateBusinessRules();
            Console.WriteLine($"Express shipment {TrackingId} dispatched to {Destination} with priority handling.");
        }
        
    }

    class HeavyFreight : Shipment
    {
        public bool Permit { get; set; }

        public override void ProcessShipment()
        {
            ValidateBusinessRules() ;
            if (Weight > 1000 && !Permit) throw new Exception("Heavy Lift Permit is not there for shipment over 1000 kg.");
        } 
    }

    class LogManager : ILoggable
    {
        string file = @"..\..\..\shipment_Audit.log";
        //string directory = @"..\..\..\";
        //string path = directory + file;
        public void SaveLog(string message)
        {
            using (StreamWriter sw = new StreamWriter(file, true))
            {
                sw.WriteLine($"{DateTime.Now} : {message}");
            }
        }
    }

    class RestrictedDestinationException : Exception
    {
        public string DeniedLocation { get; }

        public RestrictedDestinationException(string location): base($"Shipment denied. Restricted destination: {location}")
        {
            DeniedLocation = location;
        }
    }

    class InsecurePackagingException : Exception
    {
        public InsecurePackagingException(string message): base(message)
        {
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            LogManager logger = new LogManager();

            List<Shipment> ship = new List<Shipment>
            {
                new ExpressShipment
                {
                    TrackingId = "ABC001",
                    Weight = 101,
                    Destination = "Bangalore",
                    IsFragile = true,
                    IsReinforced = true
                },
                new ExpressShipment
                {
                    TrackingId = "XYZ002",
                    Weight = 0,
                    Destination = "Bermuda",
                    IsFragile = true,
                    IsReinforced = false
                },
                new ExpressShipment
                {
                    TrackingId = "AJX100",
                    Weight = 10,
                    Destination = "Australia",
                    IsFragile = true,
                    IsReinforced = true

                },
                new HeavyFreight
                {
                    TrackingId = "KXS119",
                    Weight = 800,
                    Destination = "Austria",
                    Permit = false,
                    IsFragile = false,
                    IsReinforced = true
                },
                new HeavyFreight
                {
                    TrackingId = "KLO112",
                    Weight = 1600,
                    Destination = "Tamil Nadu",
                    Permit = true,
                    IsFragile = true,
                    IsReinforced = false
                },
                new HeavyFreight
                {
                    TrackingId = "LDQ199",
                    Weight = 900,
                    Destination = "North Pole",
                    Permit = false,
                    IsFragile = true,
                    IsReinforced = true
                }
            };

            foreach(var shipment in ship)
            {
                try
                {
                    shipment.ProcessShipment();
                    logger.SaveLog($"SUCCESS: Shipment {shipment.TrackingId} processed successfully.");
                }
                catch(RestrictedDestinationException ex)
                {
                    logger.SaveLog($"SECURITY ALERT!: {ex.Message}");
                }
                catch(ArgumentOutOfRangeException ex)
                {
                    logger.SaveLog($"DATA ENTRY ERROR: {ex.Message}");
                }
                catch(Exception ex)
                {
                    logger.SaveLog(ex.Message);
                }
                finally
                {
                    Console.WriteLine($"Processing done for ID: {shipment.TrackingId}");
                }
            }
            
        }
    }
}
