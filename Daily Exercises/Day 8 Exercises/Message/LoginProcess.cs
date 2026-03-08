namespace Message
{
    internal class LoginProcess
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter your login process");
            string userInput = Console.ReadLine();
            string[] parts = userInput.Split('|', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
            string userName = parts[0];
            string loginMessage = parts[1];
            loginMessage = loginMessage.ToLower();

            bool isExactMatch = true;
            if (!loginMessage.Equals("login successful"))
            {
                isExactMatch = false;
            }

            string loginStatus = "";
            if (!loginMessage.Contains("successful"))
            {
                loginStatus = "LOGIN FAILED";
            }
            else if (loginMessage.Contains("successful") && isExactMatch == true)
            {
                loginStatus = "LOGIN SUCCESS";
            }
            else if (loginMessage.Contains("successful") && isExactMatch == false)
            {
                loginStatus = "LOGIN SUCCESS (CUSTOM MESSAGE)";
            }

            Console.WriteLine($"User    : {userName,-10}");
            Console.WriteLine($"Message : {loginMessage,-10}");
            Console.WriteLine($"Status  : {loginStatus,-10}");
        }
    }
}
