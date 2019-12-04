using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Formatters.Soap;
using System.IO;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Lab22_Serialization
{
    class Program
    {
        static void Main(string[] args)
        {
            Customer customer = new Customer(1,"Bob","ND3245F239");
            Customer customer2 = new Customer(2, "Jim", "FI49583V43");
            var customers = new List<Customer>() { customer, customer2 };
            

            // Serailize customer to XML format
            // Create an object for serialisation
            // SOAP = Simple Object Access Protocol => XML Transmission mechanism
            var formatter = new SoapFormatter();

            // Stream customer to File
            // About to stream data to XML file: Eeach time create new file, We have file access
            using (var stream = new FileStream("data.xml",FileMode.Create,FileAccess.Write,FileShare.None))
            {
                // Searialise data to XML as a Steam of data and send to the file stream
                formatter.Serialize(stream, customers);
            }
            // Print out file
            Console.WriteLine(File.ReadAllText("data.xml"));


            // Reverse the Process: 
            var customersFromXMLFile = new List<Customer>();

            // Stream READ
            using (var reader = File.OpenRead("data.xml"))
            {
                // Deseralize XML => Customer 
                customersFromXMLFile = formatter.Deserialize(reader) as List<Customer>;
            }
            // print
            customersFromXMLFile.ForEach(c => Console.WriteLine(c.CustomerID.ToString() +" "+ c.CustomerName.ToString()));

        }
    }

    [Serializable]
    class Customer
    {
        public int CustomerID { get; set; }
        public string CustomerName { get; set; }

        [NonSerialized]
        private string NINO;

        public Customer(int CustomerID, string CustomerName, string NINO)
        {
            this.CustomerID = CustomerID;
            this.CustomerName = CustomerName;
            this.NINO = NINO;
        }
    }
}
