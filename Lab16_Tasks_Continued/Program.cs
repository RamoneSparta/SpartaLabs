using System;
using System.Threading;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Linq;

namespace Lab16_Tasks_Continued
{
    class Program
    {
       static Stopwatch s = new Stopwatch();
        static void Main(string[] args)
        {
            var s = new Stopwatch();
            s.Start();
            var task01 = Task.Run(() =>
            {
                Console.WriteLine("Task01 is running");
                Console.WriteLine($"Task01 stoped at {s.ElapsedMilliseconds} milliseconds");
            });
            // Old fashioned way of putting a Delegate as a parameter as a task

            var actiondelegate = new Action(SpecialActionMethod); // Pass in method as an Argument
            var task02 = new Task(actiondelegate);
            task02.Start();


            // Array of tasks
            Task[] taskArray = new Task[]
            {
               new Task(() =>
               { 
                   // We can tell this to do a job e.g a overnight processing task
               }),
               new Task(() =>
               {
                   // We can say do another job here as well
               }),
               new Task(() =>
               { 
                   // And so on
               }),
               new Task(() =>
               { 
                // And so on
               }),
               new Task(() => { }),
               new Task(() => { }),
               new Task(() => { })
            };
            // To start each task in the array
            foreach (var t in taskArray)
            {
                t.Start();
            }

            // Another way of doing the above
            var taskArray2 = new Task[3];
            taskArray2[0] = Task.Run(() =>
            {
                Thread.Sleep(500); // Simulating work by putting in 0.5 second pause
                Console.WriteLine(" First Array Task completeing at {0} milliseconds", s.ElapsedMilliseconds);
            });

            taskArray2[1] = Task.Run(() =>
            {
                Thread.Sleep(1000); // Simulating work by putting in 1 second pause
                Console.WriteLine(" Second Array Task completeing at {0} milliseconds", s.ElapsedMilliseconds);
            });

            taskArray2[2] = Task.Run(() =>
            {
                Thread.Sleep(2000); // Simulating work by putting in 2 second pause
                Console.WriteLine(" Third Array Task completeing at {0} milliseconds", s.ElapsedMilliseconds);
            });

            // We can wait for one or all Array Tasks to complete
            Task.WaitAny(taskArray2);
            Console.WriteLine($"Wating for First array task to complete at {s.ElapsedMilliseconds}");

            // Now we're waiting for all array tasks to complete
            Task.WaitAll(taskArray2);
            Console.WriteLine($"Wating for All tasks to complete at {s.ElapsedMilliseconds}");


            // Parallel ForEach Loop
            int[] myCollection = new int[] { 10, 20, 30, 40, 50, 60, 70, 80, 90, 100 };
            // Regular foreach loops are in order 1...2...3...4
            // Parallel foreach loop just kicks off x jobs at the same time, waits for answersd
            Console.WriteLine("\n\nRunning as a Asynchronous Loop\n");
            long Async = 0;
            Parallel.ForEach(myCollection, (item) =>  // Here is a method (its saying for each item in myCollection run the method) (It also needs to take in "item" as a parameter because of the values in the array become the input to the parameters of the lambda expression)
             {
                 Thread.Sleep(item * 100);
                 Console.WriteLine($"Foreach loop item: {item} has taken {s.ElapsedMilliseconds} milliseconds to run");
                 Async += s.ElapsedMilliseconds;
             });
            Console.WriteLine($"It Took Async {Async} milliseconds");




            // Contrating with a Synchorouns Loop
            Console.WriteLine("\n\nNow Running as a Synchronous Loop\n");
            long Sync = 0;
            Parallel.ForEach(myCollection, (item) =>  // Here is a method (its saying for each item in myCollection run the method) (It also needs to take in "item" as a parameter because of the values in the array become the input to the parameters of the lambda expression)
            {
                Thread.Sleep(item * 100);
                Console.WriteLine($"Foreach loop item: {item} has taken {s.ElapsedMilliseconds} milliseconds to run");
                Sync += s.ElapsedMilliseconds;
            });
            Console.WriteLine($"It Took Sync {Sync} milliseconds");

            Console.WriteLine($"The difference in time is: {Sync - Async}");


            // Also Powerful is a Parallel LINQ: Database Queries in Parellel
            // Fake it here: User Local Collection
            var dbOutput =
                (from item in myCollection
                 select item
                ).AsParallel().ToList();
            // Could use it on a real database query if many queries and each one possible takes a long time to execute


            // Getting data back from tasks
            var taskWithoutReturningData = new Task(() => { });
            var taskWithReturningData = new Task<int>(() => 
            {
                int total = 0;
                for (int i = 0; i < 100; i++)
                {
                    total += i;
                }
                return total;

            });

            taskWithReturningData.Start();

            Console.WriteLine($"I have counted to 100 using a background task so I dont have " +
                $"to hand in the main thread while I wait. The answer is {taskWithReturningData.Result}");

            Console.WriteLine("Disclaimer::: " +
                "The act of waiting for a result by definition turns this into a synchonous operations ... More details comming");

            // One tics is 10 to the -7 seconds ie 0.1 milliseconds
            Console.WriteLine("The Main method Completed all tasks at: {0} Milliseconds", s.ElapsedMilliseconds);
            // Console.WriteLine("The Main method Completed all tasks at: {0} ticks", s.ElapsedTicks);
            Console.ReadLine();

        }

        static void SpecialActionMethod()
        {
            Console.WriteLine("This action method takes no parameters, returns nothing but" +
                " just performs and action in this case printing out this...");
            var total = 0;
            for (int i = 0; i < 999_999_999; i++)
            {
                total += 1;
            }
            Console.WriteLine(total);
            Thread.Sleep(2000); // Adding 2 seconds to the time
            Console.WriteLine($"Special action method completed at: {s.ElapsedMilliseconds} milliseconds");
        }
    }
}
