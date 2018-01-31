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
        const string initMessage = "\nYet another calculator!";
        const string operatorRequest = "Please input an operator, \"L\" for a list of operators, or \"X\" to exit the program";

        const string operatorList = "+ / * - ^";


        public static char Initialize()
        {
            char operation;
            Console.WriteLine(initMessage);
            Console.WriteLine(operatorRequest);
            operation = Console.ReadKey().KeyChar;

            if (operation == 'L')
            {
                Console.WriteLine("\n" + "Possible operators: " + operatorList);
                return 'L';
            }
            else if(operation == 'X')
            {
                Environment.Exit(0);
            }
            else
            {
                operation = InterpretOperatorChar(operation);
            }

            Console.WriteLine();
            return operation;
        }

        public static char InterpretOperatorChar(char input) //function to interpret an operator character
        {
            if (operatorList.Contains(input))
            { return input; }
            else
            {
                switch (input)
                {
                    case 'M':
                    case 'm':
                        return '*';
                    case 'D':
                    case 'd':
                        return '/';
                    case 'S':
                    case 's':
                        return '-';
                    case '^':
                    case 'P':
                    case 'p':
                        return '^';
                    case 'A':
                    case 'a':
                        return '+';
                    default:
                        return '0';
                }
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
                    decimal num1 = RequestNumber();
                    decimal num2 = RequestNumber();
                    int int1 = new int();
                    int int2 = new int();

                    switch (operation)
                    {
                        case '*':
                            result = Calc.Multiply(num1, num2);
                            break;
                        case '/':
                            result = Calc.Divide(num1, num2);
                            break;
                        case '-':
                            result = Calc.Subtract(num1, num2);
                            break;
                        case '^':
                             int1 = Convert.ToInt32(num1);
                             int2 = Convert.ToInt32(num2);
                            result = Calc.Power(int1,int2);
                            break;
                        case '+':
                            result = Calc.Add(num1, num2);
                            break;
                        default:
                            Console.WriteLine("invalid operator");
                            break;
                    }
                    if (operation == '^')
                    {
                        Console.WriteLine("Required conversions:\n {0} -> {1}\n {2} -> {3}\n", num1, int1, num2, int2); //display conversions from ints to decimals
                        Console.WriteLine(int1 + operation.ToString() + int2 + "=" + result);
                    }
                    else
                    { Console.WriteLine(num1 + operation.ToString() + num2 + "=" + result); }
                    
                }
                else if (operation == 'L')  { }

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

        public static decimal Power(int i1, int i2)
        {
            if(i2 > 0) //for positive exponents, multiply 1 by i1, i2 times
            {
                decimal output = 1;

                for (int i = 0; i < i2; i++)
                {
                    output *= i1;
                }
                return output;
            }
            else if(i2 < 0) //for negative exponents, divide i1 by i1, i2 times
            {
                decimal output = i1;

                for (int i = 0; i >= i2; i--)
                {
                    output /= i1;
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
