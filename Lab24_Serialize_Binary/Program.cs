using System;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using Lab23_Serialize_JSON;
using Lab24_Serialize_Binary;



namespace Lab24_Serialize_Binary
{
    class Program
    {
        static void Main(string[] args)
        {
            Customer customer = new Customer(1, "Tom", "ND3245F239");
            Customer customer2 = new Customer(2, "Richard ( ͡° ͜ʖ ͡°)", "FI49583V43");
            Customer customer3 = new Customer(3, "Harry", "SD345234V2");

            var customers = new List<Customer>() { customer, customer2, customer3 };

            // Formatter : Allow us to serialise to binary
            var formatter = new BinaryFormatter();

            // Stream to file
            using (var stream = new FileStream("data.bin",FileMode.Create,FileAccess.Write,FileShare.None))
            {
                formatter.Serialize(stream,customers);
            }

            var readingCustomers = new List<Customer>();

            // Read back
            using (var readingStream = File.OpenRead("data.bin"))
            {
                readingCustomers = formatter.Deserialize(readingStream) as List<Customer>;
            }

            // Deserialise
            readingCustomers.ForEach(c => Console.WriteLine($"{c.CustomerID} {c.CustomerName}"));
        }
    }
}
