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

            //declaring variable types
            string repeat;

            //translator loop 
            while (true)
            {
                //Here is where we will pass through the translator method
                Console.WriteLine("Enter a line to be translated:");
                string answer = Console.ReadLine();
                string[] sentance = answer.Split(' ');

                foreach(string x in sentance)
                {
                Translator("^[AEIOUaeiou]", "[0-9]", x);
                }
                Console.WriteLine("\nTranslate another line? y/n");

                repeat = Console.ReadLine().ToLower();

                if (repeat == "y" || repeat == "yes")
                {
                    continue;
                }
                else
                {
                    break;
                }
            }
        }
        public static void Translator(string vowelCheck, string numCheck, string answer)
        {           
            string seperate = answer.Substring(0,1);
            
            if (Regex.IsMatch(seperate, vowelCheck))
            {
                Console.Write(answer + "way ");

            }
            else if (Regex.IsMatch(seperate, numCheck))
            {
                Console.WriteLine(answer);
            }
            else
            {
                int firstVowel= 0;
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
