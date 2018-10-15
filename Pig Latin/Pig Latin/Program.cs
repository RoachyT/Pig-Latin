using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Pig_Latin
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Pig Latin Translator");

            //translator loop 
            while (true)
            {
                string input = ReadInput();

                foreach (string x in input.Split(' '))
                {
                    Translator("^[AEIOUaeiou]", "[^A-z]", x);
                }
                //ask user if they want to enter another word 
                if (!ReadBoolean())
                {
                    Console.ReadKey();
                    break;
                }
            }
        }

        static string ReadInput()
        {
            while (true)
            {
                Console.WriteLine("Enter a line to be translated:");
                string answer = Console.ReadLine().ToLower();
 
                if (!String.IsNullOrWhiteSpace(answer))
                    return answer;
            }
        }
        static bool ReadBoolean()
        {
            while (true)
            {
                //declaring variable types
                string repeat;
                Console.WriteLine("\nTranslate another line? y/n");
                repeat = Console.ReadLine().ToLower();

                if (repeat == "y" || repeat == "yes")
                {
                    return true;
                }
                else if (repeat == "n" || repeat == "no")
                {
                    Console.WriteLine("Goodbye");
                    return false;
                }
                else
                {
                    Console.WriteLine("That was an incorrect input.\nPlease enter yes or no:  ");  
                }
            }
        }
        public static void Translator(string vowelCheck, string numCheck, string answer)
        {           
            string seperate = answer.Substring(0,1);

            if (Regex.IsMatch(answer, numCheck))
            {
                Console.WriteLine(answer);
            }
            else if (Regex.IsMatch(seperate, vowelCheck))
            {
                Console.Write(answer + "way ");
            }
            else
            {
                int firstVowel = 0;
                for (int i = 0; i < answer.Length; i++)
                {
                    if (Regex.IsMatch(answer[i].ToString(), vowelCheck))
                    {
                        firstVowel = i;
                        break;
                    }
                }
                seperate = answer.Substring(0, firstVowel);
                Console.Write(answer.Substring(firstVowel) + seperate + "ay ");
            }
        }
    }
}
