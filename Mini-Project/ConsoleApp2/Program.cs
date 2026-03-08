namespace ConsoleApp2
{
    internal class Program
    {
        
        static void Main(string[] args)
        {
            //Defined Words to run the game on
            
            string[] ar = { "DARK", "FLYING", "FIGHTER",
                "GUEST", "RANGE", "LOOP", "DEMON", "ABISS",
                "BLISS", "CASANOVA", "DARKMATTER", "ANTIMATTER",
                "BLACKHOLE", "BIZZARE", "ZUTHOPIA" };
            string[] arr = new string[ar.Length];

            //Use of random keyword to use different words each time
            Random ran = new Random();

            string randomWord = ar[ran.Next(ar.Length)];
            
            char[] words = new char[randomWord.Length];


            for(int i =0; i < randomWord.Length; i++)
            {
                words[i] = '_';
            }

            int lives = 6;
            HashSet<char> insertedCharacters = new HashSet<char>();

            Console.WriteLine("Welcome to C# Hangman! Word Has Started");
            Console.WriteLine($"You have {lives} Lives ");

            while (lives > 0)
            {
                Console.WriteLine("Word: " + string.Join(" ",words));
                Console.Write("Guess a Character: ");
                string userInput = Console.ReadLine().ToUpper();

                if (string.IsNullOrEmpty(userInput) || userInput.Length != 1 || !char.IsLetter(userInput[0]))
                {
                    Console.WriteLine("\nPlease enter a valid letter and single character only.\n");
                    continue;
                }


                char guessed = userInput[0];

                if (insertedCharacters.Contains(guessed))
                {
                    Console.WriteLine($"You already guessed {guessed}. Try again.");
                    continue;
                }

                insertedCharacters.Add(guessed);

                bool val = false;
                for(int i =0; i<randomWord.Length; i++)
                {
                    if(randomWord[i] == guessed)
                    {
                        words[i] = guessed;
                        val = true;
                    }
                }
                if (val)
                {
                    Console.WriteLine("Good catch!\n");
                }
                else
                {
                    lives--;
                    Console.WriteLine($"Wrong guess! Lives left: {lives}\n");
                }

                bool won = true;

                for (int i = 0; i < words.Length; i++)
                {
                    if (words[i] == '_')
                    {
                        won = false;
                        break;
                    }
                }

                if (won)
                {
                    Console.WriteLine("You Won!");
                    Console.WriteLine($"This is exactly the correct word: {randomWord}");
                    return;
                }
            }
            Console.WriteLine("Game Over");
            Console.WriteLine($"The Actual Word was {randomWord}");
            //for(int j=0; j< words.Length; j++ )

            //Lives count 

            // Guess
            
        }
    }
}
