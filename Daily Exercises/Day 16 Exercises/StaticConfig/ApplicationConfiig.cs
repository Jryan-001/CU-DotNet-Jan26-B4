namespace StaticConfig
{
    class ApplicationConfiig
    {
        public static string ApplicationName { get; set; }

        public static string Environment { get; set; }

        public static int AccessCount { get; set; }
        public  static bool Isinitialized { get; set; }
        //public ApplicationConfiig()
        //{
        //    Console.WriteLine("Default Constructor Executed");
        //}
        static ApplicationConfiig()
        {
            ApplicationName = "MyApp";
            Environment = "Development";
            AccessCount = 0;
            Isinitialized = false;

            Console.WriteLine("Static Constructor Executed");
        }

        public static void Initialize(string appName,  string environment)
        {
            ApplicationName = appName;
            Environment = environment;
            AccessCount++;
        }

        public static string GetConfigurationSummary()
        {
            AccessCount++;
            return $"Application Name: {ApplicationName} Environment: {Environment} Access Count: {AccessCount} Initialized Status: {Isinitialized}";
        }

        public static void ResetConfiguration()
        {
            ApplicationName = "MyApp";
            Environment = "Development";
            Isinitialized = false;
            AccessCount++;
        }
        

        //public override string ToString()
        //{
        //    return $"Application Name: {ApplicationName} Environment: {Environment} Access Count: {AccessCount} Initialized Status: {Isinitialized}";
        //}
    }

    internal class App
    {
        static void Main(string[] args)
        {
            //ApplicationConfiig app = new ApplicationConfiig();
            ApplicationConfiig.Initialize("A1", "Dev");
            
            Console.WriteLine(ApplicationConfiig.GetConfigurationSummary());
            ApplicationConfiig.ResetConfiguration();
            Console.WriteLine(ApplicationConfiig.GetConfigurationSummary());
            //Console.WriteLine(app);
        }
    }
}
