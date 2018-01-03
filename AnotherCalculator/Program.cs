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


        const string operatorList = "+ / * - ^";


        public static char Initialize()
        {
            char operation;
            Console.WriteLine(initMessage);
            Console.WriteLine(operatorRequest);
            operation = InterpretOperatorChar(Console.ReadKey().KeyChar);
            Console.WriteLine();
            return operation;
        }

        public static char InterpretOperatorChar(char input) //function to interpret an operator character
        {
            switch (input)
            {
                case 'm':
                    return '*';
                case 'd':
                    return '/';
                case 's':
                    return '-';
                case '^':
                case 'p':
                    return '^';
                case 'a':
                    return '+';
                default:
                    throw new LogicException();
            }
         }

        static void Main(string[] args)
        {
            decimal result = new decimal();
            while (true)
            {
                char operation = Initialize();

                if (operatorList.Contains(operation))
                {
                    switch (operation)
                    {
                        case '*':
                            result = Calc.Multiply(RequestNumber(), RequestNumber());
                            break;
                        case '/':
                            result = Calc.Divide(RequestNumber(), RequestNumber());
                            break;
                        case '-':
                            result = Calc.Subtract(RequestNumber(), RequestNumber());
                            break;
                        case '^':
                            result = Calc.Power((int.Parse(RequestNumber().ToString())), int.Parse(RequestNumber().ToString()));
                            break;
                        case '+':
                            result = Calc.Add(RequestNumber(), RequestNumber());
                            break;

                        default:
                            Console.WriteLine("invalid operator");
                            break;
                    }
                    Console.WriteLine(result);
                }
                else { Console.WriteLine("invalid operator"); }
            }
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

        //operations with decimals

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

        //operations with integers
        public static int Multiply(int d1, int d2)
        {
            return d1 * d2;
        }

        public static int Divide(int d1, int d2)
        {
            if(d2 == 0)
            {
                return 0;                             //rewrite this garbage
                throw new DivideByZeroException();
            }

            else if (d2 != 0)
            {
                return d1 / d2;
            }
            else { return 0; }
        }

        public static int Add(int d1, int d2)
        {
            return d1 + d2;
        }

        public static int Subtract(int d1, int d2)
        {
            return d1 - d2;
        }

        public static decimal Power(int d1, int d2)
        {
            if(d2 > 0)
            {
                decimal output = 1;

                for (int i = 0; i < d2; i++)
                {
                    output = output * d1;
                }
                return output;
            }
            else if(d2 < 0)
            {
                decimal output = d1;

                for (int i = 0; i >= d2; i--)
                {
                    output = output / d1;
                }
                return output;
            }
            else { return 0; }
        }
    }


    public class LogicException : Exception
    {
        public LogicException() { }
    }
}
