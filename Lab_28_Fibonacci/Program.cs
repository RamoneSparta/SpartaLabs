using System;

namespace Lab28_Fibonacci
{
    class Program
    {
        static void Main(string[] args)
        {
            Fibonacci fibonacci = new Fibonacci();
            Console.WriteLine(fibonacci.ReturnFibonacciNthItemInSequence(2));
        }
    }

    public class Fibonacci
    {
        // Create a test with 3 test values to make sure it works
        public int ReturnFibonacciNthItemInSequence(int n)
        {
            int nextNum = 0;
            int first = 0;
            int second = 1;

            if (n <= 1)
            {
                return n;
            }
            else if (n == 2 || n == 3)
            {
                return n - 1;
            }
            else
            {
                for (int i = 0; i <= (n-3); i++)
                {
                    nextNum = first + second;
                    first = second;
                    second = nextNum;
                }
            }


            return nextNum;
        }

    }
}
