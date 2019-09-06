using System;

namespace MyConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            int n, reverse = 0, rem;
            Console.Write("---------------------Reverse a Number------------------------");
            Console.Write("\n");
            Console.Write("Enter a number: ");
            n = int.Parse(Console.ReadLine());
            while (n != 0)
            {
                rem = n % 10;
                reverse = reverse * 10 + rem;
                n /= 10;
            }            
            Console.Write("Reversed Number: " + reverse);
            Console.Write("\n");
            Console.Write("---------------------Number Triangle------------------------");
            Console.Write("\n");
            NumberTriangle.NumTriangle();
            Console.Write("\n");
            Console.Write("---------------------Fibonacci Triangle------------------------");
            Console.Write("\n");
            FibonacciTriangle.FibTriangle();
        }
    }
}
