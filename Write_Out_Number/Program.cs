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

            Console.WriteLine(ConvertNumberToEnglish(userInput));
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

        // Converts a number string to plain English
        private static StringBuilder ConvertNumberToEnglish(string numberString)
        {
            int numberOfDigits = numberString.Length;
            StringBuilder convertedNumberString = new StringBuilder();

            foreach (var digit in numberString)
            {
                convertedNumberString.Append(digit).Append(" ");
            }
            return convertedNumberString;
        }

        //// Check if string is a 32 bit integer
        //private static bool IsInteger32(string numberString)
        //{
        //    if (IsZero(numberString))
        //    {
        //        return true;
        //    }

        //    int number;
        //    if (Int32.TryParse(numberString, out number)) // Check if string is actually a integer
        //    {
        //        return IsZero(number) ? false : true; // Check if number is a 32 bit integer by checking if value from parse is zero
        //    }
        //    else
        //    {
        //        return false;
        //    }
        //}
    }
}
