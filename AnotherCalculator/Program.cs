using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnotherCalculator
{
    class Program
    {
        //messages stored as constants
        const string inputRequest = "Input a number";
        const string initMessage = "For your calculating pleasure";
        const string operatorRequest = "Please input an operator";



        public static char Initialize()
        {
            char operation;
            Console.WriteLine(initMessage);
            Console.WriteLine(operatorRequest);
            operation = Console.ReadKey().KeyChar;
            Console.WriteLine();
            return operation;
        }

        static void Main(string[] args)
        {
            decimal result= new decimal();
            char operation = Initialize();

            switch (operation)
            {
                case 'm':
                    result = Calc.Multiply(RequestNumber(), RequestNumber());
                    break;

                default:
                    Console.WriteLine("invalid operator");
                    break;
            }
            Console.WriteLine(result);
            Console.ReadLine();
        }

        public static decimal RequestNumber()
        {
            Console.WriteLine(inputRequest);

            decimal result;
            bool parsed = decimal.TryParse(Console.ReadLine(), out result);
            return result;
        }


    }

    public class Calc
    {
        //properties
        public int Number1;
        public int Number2;

        //operations

        public static decimal Multiply(decimal d1, decimal d2)
        {
            return d1 * d2;
        }

        public static decimal Divide(decimal d1, decimal d2)
        {
            return d1 / d2;
        }

        public static decimal Add(decimal d1, decimal d2)
        {
            return d1 + d2;
        }

        public static decimal Subtract(decimal d1, decimal d2)
        {
            return d1 - d2;
        }

        public static decimal Power(decimal d1, decimal d2)
        {
            decimal output = 1;

            for (int i = 0; i < d2; i++)
            {
                output = output * d1;
            }
            return output;
        }
    }
}
