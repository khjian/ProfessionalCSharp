using System;

namespace AssemblyA
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"Main in domain {AppDomain.CurrentDomain.FriendlyName} called");
        }
    }

    public class Demo
    {
        public Demo(int val1, int val2)
        {
            Console.WriteLine($"Constructor with the values {val1},{val2} in domain " +
                              $"{AppDomain.CurrentDomain.FriendlyName} called");
        }

    }
}
