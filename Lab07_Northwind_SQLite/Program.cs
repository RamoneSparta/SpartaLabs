using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Sqlite;
using System;

namespace Lab07_Northwind_SQLite
{
    class Program
    {
        public static List<Customer> customers = new List<Customer>();


        static void Main(string[] args)
        {

            ListCustomer();
            AddCustomer();
            ListCustomer();
 
        }

        static void ListCustomer()
        {
            using (var db = new NorthwindDbContext())
            {
                customers = db.Customers.ToList();

            }
            customers.ForEach(c => Console.WriteLine($"{c.CustomerID,-15} {c.ContactName,-15} {c.CompanyName,-15} {c.City,-15} {c.Country,-15}"));

        }

        static void AddCustomer()
        {
            using (var db = new NorthwindDbContext())
            {
                for (int i = 0; i < 10; i++)
                {

                        db.Customers.Add(new Customer("Bob", "Bob builings", "London", "UK"));
                        db.SaveChanges();

 


                }


            }

        }








    }



    class Customer
    {

        public Customer ()
            {

            }

        public Customer(string ContactName, string CompanyName, string City, string Country)
        {

        }

        public string CustomerID { get; set; }
        public string ContactName { get; set; }
        public string CompanyName { get; set; }
        public string City { get; set; }
        public string Country { get; set; }



    }

    class NorthwindDbContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            string connectionString = @"Data Source=C:\Users\Ramone Nelson\Engineering45\SQLite\Northwind.db";
            builder.UseSqlite(connectionString);
        }
    }


}
