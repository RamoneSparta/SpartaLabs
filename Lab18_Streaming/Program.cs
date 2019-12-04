using System;
using System.IO;
using System.Linq;
using System.Diagnostics;
using System.Text;

namespace Lab18_Streaming
{
    class Program
    {
        static void Main(string[] args)
        {
            File.WriteAllText("data.txt","Hello this is some data");

            var myArray = new string[] {"Hello", "this", "is some data"};
            
            File.WriteAllLines("ArrayData.txt", myArray);

            for (int i = 0; i < 10; i++)
            {
                // The Environment.NewLine is like \n but works on a mac as well
                File.AppendAllText("ArrayData.txt", Environment.NewLine + $"Adding line {i} at {DateTime.Now}");
            }

            Console.WriteLine(File.ReadAllText("data.txt"));

            var output = File.ReadAllLines("ArrayData.txt").ToList();
            output.ForEach(line => Console.WriteLine(line));

            Directory.CreateDirectory("Here is a folder");
            File.Create("Here is a folder\\MyFile.txt");
            File.Create(@"Here is a folder\myFile2.txt");

            Directory.CreateDirectory(@"C:\RootFolder");
            Console.WriteLine(Directory.Exists(@"C:\RootFolder"));



            // Stream some data to a file
            // System can't cope with latge files: so it breaks them down into blocks and sends them
            var noOfLines = 100000;
            var s = new Stopwatch();
            s.Start();

            using (var writer = new StreamWriter("output.dat"))
            {
                for (int i = 0; i < noOfLines; i++)
                {
                    writer.WriteLine($"Logging some data at {DateTime.Now}");
                }
            }
            var writeTime = s.ElapsedMilliseconds;

            Console.WriteLine($"It took {s.ElapsedMilliseconds} to write {noOfLines} lines");

            string nextline;
            // Reading the data
            using (var streamReader = new StreamReader("output.dat"))
            {
                // The reader does not know how big the file is
                // Read until reader.ReadLine is null

                while ((nextline = streamReader.ReadLine()) != null)
                {
               //     Console.WriteLine(nextline);
                }
                streamReader.Close();
               // Console.WriteLine($"It tok {s.ElapsedMilliseconds -writeTime} to read {noOfLines}");
            }

            s.Restart();
            var longString = "";
            using (var streamReader = new StreamReader("output.dat"))
            {
                while((nextline = streamReader.ReadLine()) != null)
                {
                    longString += nextline;
                }
                streamReader.Close();

            }
            
            Console.WriteLine($"It took {s.ElapsedMilliseconds} to write {noOfLines} lines");
            //Console.WriteLine(longString);

            s.Restart();
            longString = "";
            var stringBuilder = new StringBuilder();
            using (var streamReader = new StreamReader("output.dat"))
            {
                while ((nextline = streamReader.ReadLine()) != null)
                {
                    stringBuilder.Append(nextline);
                }
                streamReader.Close();

            }

            Console.WriteLine($"It took {s.ElapsedMilliseconds} to write {noOfLines} strings together using stringbuilder");
        }
    }
}
