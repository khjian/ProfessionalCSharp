using System;

namespace Demo
{
    public class MathOperations
    {
        public static void MultiplyByTwo(double value)
        {
           Console.WriteLine($"Multiply by 2:{value} gives {value*2}");
        }

        public static void Square(double value)
        {
            Console.WriteLine($"Squaring:{value} gives {value*value}");
        }
    }

    /*委托演示
     static void Main(string[] args)
        {
            Func<double,double>[] operations =
            {
                MathOperations.MultiplyByTwo,
                MathOperations.Square
            };

            for (int i = 0; i < operations.Length; i++)
            {
                Console.WriteLine($"Using operation {i}:");
                ProcessAndDisplayNumber(operations[i],2.0);
                ProcessAndDisplayNumber(operations[i],7.94);
                ProcessAndDisplayNumber(operations[i],1.414);
            }
            Console.ReadLine();
        }

        static void ProcessAndDisplayNumber(Func<double, double> action, double value)
        {
            double result = action(value);
            Console.WriteLine($"Value is {value},result of operation is {result}");
        }
     */

    /*多播委托演示
      static void Main(string[] args)
        {
            Action<double> operations = MathOperations.MultiplyByTwo;
            operations += MathOperations.Square;
            ProcessAndDispayNumber(operations, 2.0);
            ProcessAndDispayNumber(operations,7.94);
            ProcessAndDispayNumber(operations,1.414);
            Console.ReadLine();
        }

        static void ProcessAndDispayNumber(Action<double> action, double value)
        {
            Console.WriteLine();
            Console.WriteLine($"ProcessAndDisplayNumber called with value = {value}");
            action(value);
        }
     */
}
