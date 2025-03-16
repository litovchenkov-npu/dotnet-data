using System;

namespace calculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BaseCalculator calc = new BaseCalculator();
            Console.WriteLine("Enter the first number: ");
            calc.num.a = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Enter the second number: ");
            calc.num.b = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Select an operation (+, -, *, /): ");
            calc.SelectOperation();

            Console.WriteLine("Result: ");
            Console.WriteLine(calc.num.result);
        }

        public struct Numbers
        {
            private double _a, _b, _result;
            public double a
            {
                get { return _a; }
                set { _a = value; }
            }
            public double b
            {
                get { return _b; }
                set { _b = value; }
            }
            public double result
            {
                get { return _result; }
                set { _result = value; }
            }
        }

        public interface ICalculator
        {
            public double Add();
            public double Sub();
            public double Mul();
            public double Div();
        }

        public class BaseCalculator : ICalculator
        {
            public Numbers num = new Numbers();
            public void SelectOperation()
            {
                char operation = Convert.ToChar(Console.ReadLine());
                switch (operation)
                {
                    case '+': Add(); break;
                    case '-': Sub(); break;
                    case '*': Mul(); break;
                    case '/': Div(); break;
                    default: Console.WriteLine("Wrong input!\n"); break;
                }
            }

            public double Add()
            {
                return num.result = num.a + num.b;
            }
            public double Sub()
            {
                return num.result = num.a - num.b;
            }
            public double Mul()
            {
                return num.result = num.a * num.b;
            }
            public double Div()
            {
                if (num.b == 0)
                {
                    Console.WriteLine("Division by zero!\n");
                    return num.result = double.PositiveInfinity;
                }
                else
                {
                    return num.result = num.a / num.b;
                }
            }
        }
    }
}