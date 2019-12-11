#define TestCode
using System;
using System.Diagnostics;
using System.IO;

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
#if DEBUG
            Console.WriteLine("Code is debugging");
#endif

#if TestCode
            Console.WriteLine("\nThe test code is running");
#endif

            Debug.WriteLine("We are in debuging mode");
            int z = 100;
            Debug.WriteLineIf(z == 100, "z is 100 on Debug Writeline");

            Trace.WriteLine("Tracing some output");
            Trace.WriteLineIf(z == 100, "z is 100 on Trace Writeline");

            File.AppendAllText("Events.log",$"z has value {z} at {DateTime.Now}");





        }



        static void DoThis ()
        {
            Console.WriteLine("\nIt is done");
        }
    }
}
