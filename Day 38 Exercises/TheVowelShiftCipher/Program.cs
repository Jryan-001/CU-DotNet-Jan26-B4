namespace TheVowelShiftCipher
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter string: ");


            string input = Console.ReadLine();

            Dictionary<char, char> vowelShift = new Dictionary<char, char>()
                        {
                            {'a','e'},
                            {'e','i'},
                            {'i','o'},
                            {'o','u'},
                            {'u','a'}
                        };

            string output = "";

            foreach (char c in input)
            {
                if (vowelShift.ContainsKey(c))
                {
                    output += vowelShift[c];
                }
                else
                {

                    char shift = (char)((c - 'a' + 1) % 26 + 'a');


                    if (vowelShift.ContainsKey(shift))
                    {
                        shift = (char)((shift - 'a' + 1) % 26 + 'a');
                    }

                    output += shift;
                }
            }

            Console.WriteLine("Result: " + output);
        }
    }
}