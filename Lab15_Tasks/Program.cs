using System;
using System.Threading;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Lab15_Tasks
{
    class Program
    {
        static void Main(string[] args)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            // Inside here can go a delegate or an anonymous method using lambda
            // Syntax
            var task01 = new Task(
                () => {});   // Lambda anonymous method


            var task02 = new Task(
                () => { Console.WriteLine("In Task 2"); });   // Lambda anonymous method

            task02.Start();

            // Slicker Way
            var task03 = Task.Run(() => { Console.WriteLine("In Task 3"); });
            var task04 = Task.Run(() => { Console.WriteLine("In Task 4"); });
            var task05 = Task.Run(() => { Console.WriteLine("In Task 5"); });
            

            // Stopwatch
            // Array of tasks
            // Wait for one to complete / all to complete

            // A tick is a 10,000 milliseconds
            Console.WriteLine("Your Code has been running for "+stopwatch.ElapsedMilliseconds+" miliseconds Or "+stopwatch.ElapsedTicks+" ticks");
            Console.ReadLine();
        }
    }
}
