using System;

namespace JsonValidator
{
    public class Program
    {
        public static void Main(string[] args)
        {
            if (args == null || args.Length == 0)
            {
                Console.WriteLine(@"Error: Provide the path to the file as argument. Ex. Program C:\Users\Public\TestFolder\WriteText.txt");
                return;
            }

            string text = System.IO.File.ReadAllText(args[0]);

            IMatch jsonMatch = new Value().Match(text);

            Console.WriteLine(jsonMatch.Success() ? "Valid" : "Invalid");
            Console.Read();
        }
    }
}
