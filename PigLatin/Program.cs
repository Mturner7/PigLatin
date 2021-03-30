using System;
using System.Text.RegularExpressions;

namespace PigLatin
{
    class Program
    {
        private static bool PromptUser(string msg="Continue")
        {
            string input = "";
            while (input != "n" && input != "y")
            {
                Console.Write($"\n{msg} (y/n): ");
                input = Console.ReadLine().ToLower();
            }
            if (input == "n") return false;
            return true;
        }

        private static bool CheckWord(string word)
        {
            if (!Regex.IsMatch(word, @"(^[a-zA-Z']+$)")) return false;
            return true;
        }

        public static string Translate(string input)
        {
            char[] _word = input.ToCharArray();
            char temp = _word[0];
            string vowels = "aeiouAEIOU";
            
            if (!vowels.Contains(temp))
            {
                _word[0] = _word[_word.Length - 1];
                _word[_word.Length - 1] = temp;
            }

            string ret = new string(_word) + "ay";
            return ret;
        }

        private static void PigOut()
        {
            Console.Clear();
            Console.Write("Enter a line to be translated: ");
            string input = Console.ReadLine();
            
            if (String.IsNullOrWhiteSpace(input))
            {
                Console.WriteLine("Your input is empty! Please enter some text next time.");
                return;
            }

            string[] phrase = input.Split(' ');
            string result = "";

            foreach (string word in phrase)
            {
                if (CheckWord(word)) result += Translate(word);
                else result += word;
                result += ' ';
            }
            Console.WriteLine($"\n{result}");
        }

        static void Main(string[] args)
        {
            bool running = true;
            while (running)
            {
                PigOut();   
                running = PromptUser("Would you like to translate another line?");
            }
        }
    }
}
