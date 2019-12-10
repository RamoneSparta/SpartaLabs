using System;

namespace Lab29_Debugging
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int i = 0; i < 20; i++)
            {
                var j = $"Your number doubled is {(i+i)}";
                DoThis();
                Console.WriteLine($"{i} {j}");
            }
        }
        static void DoThis ()
        {
            Console.WriteLine("It is done");
        }
    }
}
