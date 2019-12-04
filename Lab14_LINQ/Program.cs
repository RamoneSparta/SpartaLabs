using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using Microsoft.EntityFrameworkCore.Design;

namespace Lab14_LINQ
{
    #region Class Program
    class Program
    {
        #region Global Variables
        static List<Customer> customers = new List<Customer>();
        static List<ModifiedCustomer> modifiedCustomers = new List<ModifiedCustomer>();
        static List<Product> products = new List<Product>();
        static List<Category> categories = new List<Category>();
        #endregion

        static void Main(string[] args)
        {
            #region Explaination
            /*
             * 1) Reading Nothwind using Entity Core 2.1.1
             * 2) Basic LINQ
             * 3) More Advanced LINQ with Lambda
             */
            #endregion

            #region Explaining Nuget install command
            // Nuget: microsoft.entityframeworkcore/ sqlserver/ design verson 2.1.1
            /* Commands:
             * install-packages microsoft.entityframeworkcore
             * install-packages microsoft.entityframeworkcore.sqlserver
             * install-packages microsoft.entityframeworkcore.design
             */
            #endregion


            #region Using The Northwind Database
            using (var db = new Northwind())
            {
                customers = db.Customers.ToList();

                // Simple LINQ From Local Collection
                // Whole Dataset is returned (More Data)
                // IEnumerable
                var selectedCustomers =
                    from customer in customers
                    select customer;

                // Same Query over Database directly
                // Only Return Actual Data Needed
                // Lazy Loading: Query Is Not Actually Executed!!!
                // Data Has Not Actually Arrived Yet!
                var selectedCustomers2 =
                    from customer in db.Customers
                    select customer;

                // Forced the Lazy Loading into a list
                // Force Data by pushing to a list ie.ToList() or by taking aggregate eg: Sum,Count
                var selectedCustomers3 =
                    (from customer in db.Customers
                     where customer.ContactName != "New Name" // Just to get rid of the data I added previously in a different task
                     where customer.ContactName != "Ramone Nelson" // Just to get rid of the data I added previously in a different task
                     where customer.City == "London" || customer.City == "Berlin"
                     orderby customer.ContactName
                     select customer).ToList();

                // PrintCustomers(selectedCustomers3);
                //  Console.WriteLine($"There are {selectedCustomers3.Count} records in the table");

                // Create Custom Object Output
                var selectedCustomers4 =
                    (from customer in db.Customers
                     orderby customer.ContactTitle descending // Before the select you need to use clauses like orderby and where
                     select new  // This is the custom object (Annonymous type), you just make a new object and assign what you want to 
                     {
                         Title = customer.ContactTitle,
                         Name = customer.ContactName,
                         Location = customer.Address + " " + customer.City + ": " + customer.Country // Custom field with concatination
                     }
                     ).Take(20).Skip(10).ToList(); // The list makes sure we can print it 
                                                   // .Take(20) gets a batch of the first 20 records
                                                   // .Skip(10) skips the first batch of 10 records
                                                   // Printing out the Custom Object
                Console.WriteLine($"{"Job Title",-25}{"Employee Name",-20} {"Address"}");
                foreach (var c in selectedCustomers4)
                {
                    Console.WriteLine($"{c.Title,-25}{c.Name,-20} {c.Location}");
                }

                // Or

                var selectedCustomers5 =
                        (from c in db.Customers

                         select new ModifiedCustomer(c.ContactTitle, c.ContactName, c.Country)).ToString();

                // Grouping
                // Group and list all customer by city
                // City with a Count(Customer)
                var selectedCustomers6 =
                    (from c in db.Customers
                     group c by c.City into Cities
                     where Cities.Count() > 1
                     orderby Cities.Count() descending
                     select new
                     {
                         City = Cities.Key,
                         Count = Cities.Count()
                     }
                     ).ToList();
                foreach (var c in selectedCustomers6)
                {
                    Console.WriteLine($"{c.City,-20}{c.Count}");
                }

                // Join
                // Products with CategoryID => CategoryName
                Console.WriteLine("\n\nThis is a list of products Inner Join Category Showing Name \n");// Escape characters

                var listOfProducts =
                    (from p in db.Products
                     join c in db.Categories
                     on p.CategoryID equals c.CategoryID
                     select new
                     {
                         ID = p.ProductID,
                         Name = p.ProductName,
                         Category = c.CategoryName

                     }).ToList();
                //    listOfProducts.ForEach(p => Console.WriteLine($"{p.ID, -10}{p.Name, -45}{p.Category}"));

                Console.WriteLine("\n\n Print Off the Same list bu using much smarter\n" + "'dot' Notation To join Tables ''\n");
                // read in products and categories
                products = db.Products.ToList();
                categories = db.Categories.ToList();
                products.ForEach(p => Console.WriteLine($"{p.ProductID,-15}{p.ProductName,-45}{p.Category.CategoryName}")); /// That last p is a slick join but you didn't read that from me ;)

                Console.WriteLine("\n\n List Categories with a Count of Products and a Sub-List of Product Names \n");
                categories.ForEach(c =>
                {
                    Console.WriteLine($"{c.CategoryID,-10}{c.CategoryName} has {c.Products.Count} Products");
                    foreach (var p in c.Products)
                    {
                        Console.WriteLine($"\t\t\t\t\t{p.ProductID,-10}{p.ProductName}");
                    }

                });

                Console.WriteLine($"\n\nLINQ Lambda Notation");
                customers = db.Customers.ToList();
                Console.WriteLine($"Count is {customers.Count}");


                // Distinct
                Console.WriteLine("\n\nList of Cities: Select ... Distinct ... OrderBy\n");
                Console.WriteLine("\n\nUsing Select to Select one column");
                var cityList = db.Customers.Select(c => c.City).Distinct().OrderBy(c => c).ToList(); // The OrderBy(c=>c) orders the list
                cityList.ForEach(city => Console.WriteLine($"{city}"));

                Console.WriteLine("\n\nContains (same as SQL Like)\n");

                var cityListFiltered =
                    db.Customers.Select(c => c.City)
                                .Where(city => city.Contains("o"))
                                .Distinct()
                                .OrderBy(c => c)
                                .ToList();
                cityListFiltered.ForEach(city => Console.WriteLine(city));

            }
            #endregion

        }

        #region Print Customers (Takes in list made from the Database table)
        public static void PrintCustomers(List<Customer> customers)
        {
            customers.ForEach(c => Console.WriteLine($"{c.CustomerID,-10}{c.ContactName,-20}{c.CompanyName,-30}{c.City}"));
        }
        #endregion
    }
    #endregion

    #region Get Customers
    public class GetCustomers
    {
        public static List<Customer> customers = new List<Customer>();

        GetCustomers()
        {

        }

        public static int GetAllCustomers()
        {
            customers = new List<Customer>();
            using (var db = new Northwind())
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
            using (var db = new Northwind())
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

        public static int CustomersList(string city)
        {
            customers = new List<Customer>();
            using (var db = new Northwind())
            {
                if (string.IsNullOrEmpty(city))
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
                else
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


            }
            return customers.Count;
        }


        public static int GetCustomers2(string city)
        {
            using (var db = new Northwind())
            {
                if (string.IsNullOrEmpty(city))
                {
                    return db.Customers.Count();
                }
                else
                {
                    return db.Customers.Where(c => c.City == city).Count();
                }
            }
        }
    }
    #endregion

    #region Products
    public class Products
    {
        public static int GetProducts (string productName)
        {
            using (var db = new Northwind())
            {
                if (string.IsNullOrEmpty(productName))
                {
                    return db.Products.Count();
                }
                else
                {
                    return db.Products.Where(p => p.ProductName == productName).Count();
                }
            }
        }

        public static int GetProductAmount(int amount)
        {
            using (var db = new Northwind())
            {
                return db.Products.Where(p => p.UnitsInStock >= amount).Count();
            }
        }
    }
    #endregion

    #region DatabaseContextAndClasses
    // connect to database

    public partial class Customer
    {
        public string CustomerID { get; set; }
        public string CompanyName { get; set; }
        public string ContactName { get; set; }
        public string ContactTitle { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
    }
    public class Category
    {
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }
        public virtual ICollection<Product> Products { get; set; }

        public Category()
        {
            this.Products = new List<Product>();
        }
    }

    public class Product
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public int? CategoryID { get; set; }
        public virtual Category Category { get; set; }
        public string QuantityPerUnit { get; set; }
        public decimal? UnitPrice { get; set; } = 0;
        public short? UnitsInStock { get; set; } = 0;
        public short? UnitsOnOrder { get; set; } = 0;
        public short? ReorderLevel { get; set; } = 0;
        public bool Discontinued { get; set; } = false;
    }

    public class Northwind : DbContext
    {
        public DbSet<Category> Categories { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<Customer> Customers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\mssqllocaldb;" + "Initial Catalog=Northwind;" + "Integrated Security = true;" + "MultipleActiveResultSets=true;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Category>()
                .Property(c => c.CategoryName)
                .IsRequired()
                .HasMaxLength(15);

            // define a one-to-many relationship
            modelBuilder.Entity<Category>()
                .HasMany(c => c.Products)
                .WithOne(p => p.Category);

            modelBuilder.Entity<Product>()
                .Property(c => c.ProductName)
                .IsRequired()
                .HasMaxLength(40);

            modelBuilder.Entity<Product>()
                .HasOne(p => p.Category)
                .WithMany(c => c.Products);
        }
    }

    public class ModifiedCustomer
    {
        public string Name { get; set; }
        public string Location { get; set; }
        public string Title { get; set; }

        public ModifiedCustomer(string Name, string Location, string Title)
        {
            this.Name = Name;
            this.Location = Location;
            this.Title = Title;
        }

    }
    #endregion
}
