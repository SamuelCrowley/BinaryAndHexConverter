using System;
using System.Collections.Generic;

namespace BinaryHexadecimalConverter
{
    class Program
    {
        static void Main(string[] args)
        {
            //Define a list of numbers that can either be stored as hexadecimal or decimal
            List<DecimalAlternative> numbers = new List<DecimalAlternative>();

            //Add test cases to the list
            numbers.Add(new DecimalAlternative("50e", 16));
            numbers.Add(new DecimalAlternative("1011", 2));
            numbers.Add(new DecimalAlternative("e5f", 16));
            numbers.Add(new DecimalAlternative("100101010", 2));
            numbers.Add(new DecimalAlternative("eeeee", 16));
            numbers.Add(new DecimalAlternative("101110", 2));
            numbers.Add(new DecimalAlternative("ef1234a", 16));
            numbers.Add(new DecimalAlternative("111111111", 2));
            numbers.Add(new DecimalAlternative("000000", 16));

            //Iterate through list to check every value works correctly
            foreach (var item in numbers)
            {
                Console.WriteLine("Original: " + item.GetVal());
                Console.WriteLine("Decimal: " + ConvertVal(item.GetVal(), item.MultiplyBy()));
            }
        }

        public static double ConvertVal(string value, int multiplyBy)
        {
            //Define a value for the total amount 
            double totalVal = 0;

            //Current value of the item
            double currentVal = 0;

            //Define what the value will need to be multiplied by based on its position in the string and data type (16 base for hex, 2 for binary)
            double multiplication = Multiplication(value.Length, multiplyBy);

            //Index for the following foreach loop
            int index = 0;

            //Iterate through each item in the string
            foreach (var item in value)
            {
                //Reduce multiplication value by one stage before every iteration
                multiplication /= multiplyBy;
                index++;

                //Return the value (1 for 1, 10 for A, 15 for F etc) and multiply it appropriately 
                currentVal = (ReturnDataAsInt(item.ToString().ToUpper()) * multiplication);
                totalVal += currentVal;
            }

            //Return the value
            return totalVal;
        }

        static double Multiplication(double lengthVal, int multiplyBy)
        {
            //Work out what the maximum multiplication value will be, ConvertVal() divides the value appropriately as it iterates through the string
            double val = 1;
            for (int i = 0; i < lengthVal; i++)
            {
                val *= multiplyBy;
            }

            return val;
        }

        static int ReturnDataAsInt(string letter)
        {
            //Return appropriate value based on the alphanumerical parameter sent to this method by ConvertVal()
            switch (letter)
            {
                case "0":
                    return 0;
                case "1":
                    return 1;
                case "2":
                    return 2;
                case "3":
                    return 3;
                case "4":
                    return 4;
                case "5":
                    return 5;
                case "6":
                    return 6;
                case "7":
                    return 7;
                case "8":
                    return 8;
                case "9":
                    return 9;
                case "A":
                    return 10;
                case "B":
                    return 11;
                case "C":
                    return 12;
                case "D":
                    return 13;
                case "E":
                    return 14;
                case "F":
                    return 15;
                default:
                    Console.WriteLine("Error, ReturnHexStringAsInt received an invalid input");
                    return -1;
            }
        }

        public class DecimalAlternative
        {
            //Stores the string containing the value and the base number that each type of data multiplies by (16 for hex, 2 for binary)
            string myVal;
            int multiplyBy;

            public DecimalAlternative(string myVal, int multiplyBy)
            {
                this.myVal = myVal;
                this.multiplyBy = multiplyBy;
            }

            public string GetVal()
            {
                return myVal;
            }

            public int MultiplyBy()
            {
                return multiplyBy;
            }
        }
    }
}
