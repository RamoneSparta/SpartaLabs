using System;
using System.Linq;

namespace Lab17_Northwind_Test_Core
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            var testingInstance = new NorthwindEntities();
            var testnumber = GetCustomers.GetAllCustomers();
            var testnumber2 = GetCustomers.GetAllCustomersForCity("London");
            Console.WriteLine(testnumber);
            Console.WriteLine(testnumber2);
            */
        }
    }

    public class GetCustomers
    {
        public static List<Customer> customers = new List<Customer>();

        GetCustomers()
        {

        }

        public static int GetAllCustomers()
        {
            customers = new List<Customer>();
            using (var db = new NorthwindEntities())
            {
                var queryForAllCustomers =
                    (
                       from customers in db.Customers
                       select customers
                    ).ToList();
                foreach (Customer c in queryForAllCustomers)
                {
                    customers.Add(c);
                }

            }

            return customers.Count;
        }

        public static int GetAllCustomersForCity(string city)
        {
            customers = new List<Customer>();
            using (var db = new NorthwindEntities())
            {
                var queryForAllCustomers =
                    (
                       from customers in db.Customers
                       where customers.City == city
                       select customers
                    ).ToList();
                foreach (Customer c in queryForAllCustomers)
                {
                    customers.Add(c);
                }

            }

            return customers.Count;
        }

    }
}
