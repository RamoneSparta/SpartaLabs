using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Sql;
using System.Data.SqlClient;

namespace Lab04_Connect_To_Raw_SQL
{
    class Program
    {
        static void Main(string[] args)
        {
            // @ Means take LITTERALLY whats in the following string
            // NO escaping of chatacters allowed
            // Example @"C\folder\file" IS GOOD
            //        @"C\\folder\\file" IS Bad
            string connectionString = @"Data Source=(localdb)\mssqllocaldb;Initial Catalog=Northwind";
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                Console.WriteLine(connection.State);

                // Read From Database
                using (var sqlCommand = new SqlCommand("Select * From Customers", connection))
                //  using (var sqlCommand = new SqlCommand("INSERT INTO Customers VALUES('RAGN','Smooth Jazz LTD','Ramone Nelson','Owner','12 Oppenheim rd','London',NULL,'SE13 7PT','UK','02083181340',NULL)", connection))
                {
                    // create a loop to read and iterate and parse data'
                    SqlDataReader reader = sqlCommand.ExecuteReader();
                    // loop while data present
                    while (reader.Read())
                    {
                        string CustomerID = reader["CustomerID"].ToString();
                        string ContactName = reader["ContactName"].ToString();
                        Console.WriteLine($"{CustomerID,-10}{ContactName}");
                    }
                    Console.ReadLine();
                }
            }


        }
    }
}
