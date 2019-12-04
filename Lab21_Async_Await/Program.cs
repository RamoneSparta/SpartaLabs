using System;
using System.IO;
using System.Threading;
using System.Diagnostics;
using System.Net;

namespace Lab21_Async_Await
{
    class Program
    {
       
        static void Main(string[] args)
        {
            // Main method here
            // Setup : Create datafile
            // CSV = Comma Separated Values
            File.WriteAllText("data.csv", "id,name,age");
            File.AppendAllText("data.csv", "\n1,Bob,21");
            File.AppendAllText("data.csv", "\n2,Tina,22");
            File.AppendAllText("data.csv", "\n3,Paul,23");
            Uri uri = new Uri("https://www.bbc.co.uk/weather");

            // Sync : Wait for it
          //  ReadDataSync();
            // Async : Dont wait for it
          //  ReadDataAsync();

            // Webpage Sync
            GetWebPageSync(uri);
            
            // Webpage Async
            GetWebPageAsync(uri);

            Console.WriteLine("\nCode has finished\n");
            Console.ReadLine();
        }

        static void ReadDataSync() // Reading data synchorously
        {
            Stopwatch s = new Stopwatch();
            s.Start();
            var output = File.ReadAllText("data.csv");
            Thread.Sleep(5000);
            Console.WriteLine("\nSync\n");
            Console.WriteLine(output);
            Console.WriteLine("The time taken is: " + s.ElapsedMilliseconds);
        }


        async static void ReadDataAsync() // Convention to write Async after the method name
        {
            Stopwatch s = new Stopwatch();
            s.Start();
            var output = await File.ReadAllTextAsync("data.csv");
            Thread.Sleep(5000);
            Console.WriteLine("\nAsync\n");
            Console.WriteLine(output);
            Console.WriteLine("The time taken is: " + s.ElapsedMilliseconds);
        }


        private static void GetWebPageSync(Uri uri)
        { 
            WebClient webClient = new WebClient() { Proxy = null };
            webClient.DownloadFile(uri, "PageSync.html");
            Console.WriteLine("\nSync has started\n");
            Process.Start(@"C:\Program Files (x86)\Google\Chrome\Application\chrome.exe", "PageSync.html");
            Console.WriteLine("\nSync has stopped\n");
        }

         async private static void GetWebPageAsync(Uri uri)
        {
            WebClient webClient = new WebClient() { Proxy = null };
            Console.WriteLine("\nAsync has started\n");
            var webstring = await webClient.DownloadStringTaskAsync(uri);
            //Process.Start(@"C:\Program Files (x86)\Google\Chrome\Application\chrome.exe", "PageAsync.html"); 
            Console.WriteLine("\nAsync has stopped\n");
        }







    }
}
