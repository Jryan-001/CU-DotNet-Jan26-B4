namespace TheDailyLogger
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string file = "journal.txt";
            string directory = @"..\..\..\";
            string path = directory + file;
            using StreamWriter sw = new StreamWriter(path, true);
            do
            {
                Console.WriteLine("Enter file data");
                string data = Console.ReadLine();
                if (data == "stop")
                {
                    break;
                }
                sw.WriteLine(data);
            } while (true);
        }
    }
}
