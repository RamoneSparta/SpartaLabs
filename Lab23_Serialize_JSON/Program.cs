using System;
using System.IO;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Lab23_Serialize_JSON
{
    class Program
    {
        static void Main(string[] args)
        {
            Customer customer = new Customer(1, "Bob", "ND3245F239");
            Customer customer2 = new Customer(2, "Jim", "FI49583V43");
            Customer customer3 = new Customer(3, "Tom", "SD345234V2");

            var customers = new List<Customer>() { customer, customer2, customer3 };

            // Serialise object
            var JSONCustomerList = JsonConvert.SerializeObject(customers);

            // Looking at the JSON object
            Console.WriteLine(JSONCustomerList);

            // Stream to file
            File.WriteAllText("data.json",JSONCustomerList);

            // ReadFile
            var JSONString = File.ReadAllText("data.json");

            // Deserialise object
            var customersFromJson =
                JsonConvert.DeserializeObject<List<Customer>>(JSONString);

            customersFromJson.ForEach(c => Console.WriteLine($"{c.CustomerID} {c.CustomerName}"));


        }
    }

    [Serializable]
    public class Customer
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
