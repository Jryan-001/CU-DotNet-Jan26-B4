namespace BankTransfer
{
    internal class BankTransactionAnalysis
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the Login Details");
            string userInput = Console.ReadLine();
            string[] parts = userInput.Split('|', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
            string sessionId = parts[0];
            string userName = parts[1];
            string loginMessage = parts[2];

            loginMessage = loginMessage.ToLower();

            bool hasKeyword = false;
            if (loginMessage.Contains("successful"))
            {
                hasKeyword = true;
            }

            bool isStandard = false;
            if (loginMessage.Equals("login successful"))
            {
                isStandard = true;
            }

            string loginStatus = null;
            if (!hasKeyword)
            {
                loginStatus = "LOGIN FAILED";
            }
            else if (hasKeyword && isStandard)
            {
                loginStatus = "LOGIN SUCCESS";
            }
            else if (hasKeyword && !isStandard)
            {
                loginStatus = "LOGIN SUCCESS (CUSTOM MESSAGE)";
            }

            Console.WriteLine($"Session ID : {sessionId}");
            Console.WriteLine($"User       : {userName}");
            Console.WriteLine($"Message    : {loginMessage}");
            Console.WriteLine($"Status     : {loginStatus}");
        }
    }
}
