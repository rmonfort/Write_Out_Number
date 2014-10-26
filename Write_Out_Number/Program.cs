using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Write_Out_Number
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.Write("Please enter a positive integer (Limit: 2,147,483,647): ");
            string userInput = Console.ReadLine();

            while (!IsPositiveInteger32(userInput))
            {
                Console.WriteLine("The value entered is not a positive integer or it surpasses the limit.\n");
                Console.Write("Please enter a positive integer (Limit: 2,147,483,647): ");
                userInput = Console.ReadLine();
            }

            int number;
            Int32.TryParse(userInput, out number);
            Console.WriteLine(ConvertNumberToEnglish(number));
        }

        // Check if string is equal to "0"
        private static bool IsZero(string numberString)
        {
            return numberString == "0";
        }

        // Check if number is equal to 0
        private static bool IsZero(int number)
        {
            return number == 0;
        }

        // Checks if string is a 32 bit postitive integer
        private static bool IsPositiveInteger32(string numberString)
        {
            if (IsZero(numberString))
            {
                return true;
            }

            int number;
            if (Int32.TryParse(numberString, out number)) // Check if string is actually a integer
            {
                return number <= 0 ? false : true;
            }
            else
            {
                return false;
            }
        }

        // Recursively converts a number to English
        public static string ConvertNumberToEnglish(int number)
        {
            if (IsZero(number)) 
            {
                return "zero";
            }

            StringBuilder words = new StringBuilder();

            if ((number / 1000000000) > 0)
            {
                words.Append(ConvertNumberToEnglish(number / 1000000000) + " billion ");
                number %= 1000000000;
            }

            if ((number / 1000000) > 0)
            {
                words.Append(ConvertNumberToEnglish(number / 1000000) + " million ");
                number %= 1000000;
            }

            if ((number / 1000) > 0)
            {
                words.Append(ConvertNumberToEnglish(number / 1000) + " thousand ");
                number %= 1000;
            }

            if ((number / 100) > 0)
            {
                words.Append(ConvertNumberToEnglish(number / 100) + " hundred ");
                number %= 100;
            }

            if (number > 0)
            {
                if (words.ToString() != "")
                {
                    words.Append("and ");
                }

                var units = new[] { 
                    "zero", 
                    "one", 
                    "two", 
                    "three", 
                    "four", 
                    "five", 
                    "six", 
                    "seven", 
                    "eight", 
                    "nine", 
                    "ten", 
                    "eleven", 
                    "twelve", 
                    "thirteen", 
                    "fourteen", 
                    "fifteen", 
                    "sixteen", 
                    "seventeen", 
                    "eighteen", 
                    "nineteen" };

                var tens = new[] { 
                    "zero", 
                    "ten", 
                    "twenty", 
                    "thirty", 
                    "forty", 
                    "fifty", 
                    "sixty", 
                    "seventy", 
                    "eighty", 
                    "ninety" };

                if (number < 20)
                {
                    words.Append(units[number]);
                }
                else
                {
                    words.Append(tens[number / 10]);
                    if ((number % 10) > 0)
                    {
                        words.Append("-" + units[number % 10]);
                    }
                }
            }
            return words.ToString();
        }
    }
}
