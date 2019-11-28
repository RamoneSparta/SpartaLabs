using System;
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace Lab5_CRUD_APP_RAW_SQL
{
    class Program
    {
        static List<Customer> customers = new List<Customer>();
        static Customer CustomerAdded;


        static void Main(string[] args)
        {
            
            string connectionString = @"Data Source=(localdb)\mssqllocaldb;Initial Catalog=Northwind";
            using (var sqlconnection = new SqlConnection(connectionString))
            {
                sqlconnection.Open();
                Console.WriteLine(sqlconnection.State);
                //Console.WriteLine(generateRandomCustomerID());
                CustomerAdded = AddCustomer(sqlconnection);
                listCustomers(sqlconnection);
                UpdateCustomer(sqlconnection, CustomerAdded);
                listCustomers(sqlconnection);
                DeleteCustomer(sqlconnection, CustomerAdded);
                listCustomers(sqlconnection);
            }
            }

        #region ListCustomers
        static void listCustomers(SqlConnection sqlconnection)
        {
            // Building a new customers list because if not, when called it'll add it more than once 
            customers.Clear();
            // Get Customers
            using (var sqlCommand = new SqlCommand("SELECT * FROM Customers", sqlconnection) )
            {
                SqlDataReader sqlReader = sqlCommand.ExecuteReader();
                while (sqlReader.Read())
                {
                    var customer = new Customer()
                    {
                        CustomerID = sqlReader["CustomerID"].ToString(),
                        ContactName = sqlReader["ContactName"].ToString(),
                        CompanyName = sqlReader["CompanyName"].ToString(),
                        City = sqlReader["City"].ToString(),
                        Country = sqlReader["Country"].ToString()
                    };
                    // Put into list
                    
                    customers.Add(customer);
                }
                sqlReader.Close();
            }


            // Print the list

            // A) For each

            //foreach (var c in customers)
            //{
            //    Console.WriteLine($"{c.CustomerID, -10}{c.ContactName, -40}{c.CompanyName, -40}"+$"{c.City, -15}{c.Country, -15}");
            //}

            // Headings
            Console.WriteLine($"{"CustomerID",-15}{"ContactName",-40}{"CompanyName",-40} {"City",-15}{"Country",-15}");

            // B) Lambda
            customers.ForEach(c => Console.WriteLine($"{c.CustomerID,-15}{c.ContactName,-40}{c.CompanyName,-40}" + $"{c.City,-15}{c.Country,-15}"));


        }
        #endregion

        #region AddCustomer
        static Customer AddCustomer(SqlConnection sqlConnection)
        {
            var randomCustomerID = generateRandomCustomerID();
                    var newCustomer = new Customer()
                    {
                        CustomerID = generateRandomCustomerID(),
                        ContactName = "Ramone Nelson",
                        CompanyName = "Smooth Jazz LTD",
                        City = "London",
                        Country = "UK"
                    };
            //var sqlString = "INSERT INTO CUSTOMERS (CustomerID,ContactName,CompanyName,City,Country) VALUES ('RAMO27','Ramone Nelson','Smooth Jazz LTD','London','UK')";


            //using (var sqlCommand = new SqlCommand(sqlString,sqlConnection))
            //{
            //    // ExecuteNonQuery we're not querying (reading) but updating data
            //    // return an integer for the nuber of records successfully updated
            //    // expect 1 retured because we're adding 1 customer
            //    int affected = sqlCommand.ExecuteNonQuery();
            //    Console.WriteLine($"{affected} new recoreds added to database");
            //}


            var sqlString2 = "INSERT INTO CUSTOMERS (CustomerID,ContactName,CompanyName,City,Country) " 
                + "VALUES (@CustomerID,@ContactName,@CompanyName,@City,@Country)";


            using (var sqlCommand2 = new SqlCommand(sqlString2,sqlConnection))
            {
                // Set the type of parameters
                // all varchar
                // Set the value of parameters
                sqlCommand2.Parameters.AddWithValue("@CustomerID", newCustomer.CustomerID);
                sqlCommand2.Parameters.AddWithValue("@ContactName", newCustomer.ContactName);
                sqlCommand2.Parameters.AddWithValue("@CompanyName", newCustomer.CompanyName);
                sqlCommand2.Parameters.AddWithValue("@City", newCustomer.City);
                sqlCommand2.Parameters.AddWithValue("@Country", newCustomer.Country);

                int affected = sqlCommand2.ExecuteNonQuery(); 
                Console.WriteLine($"{affected} Records added to database at: "+newCustomer.CustomerID);

                if (affected == 1)
                {
                    return newCustomer;
                }

            }
            return null;

        }
        #endregion

        #region generateRandomCustomerIDLessElegant
        //static string generateRandomCustomerIDLessElegant()
        //{
        //    var characters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        //    var rand = new Random();
        //    var generatedCustomerID = new char[5];

        //    for (int i = 0; i < generatedCustomerID.Length; i++)
        //    {
        //        generatedCustomerID[i] = characters[rand.Next(characters.Length)];
        //    }

        //    return generatedCustomerID.ToString();
        //}
        #endregion

        #region UpdateCustomer
        static void UpdateCustomer(SqlConnection sqlConnection, Customer c)
        {
            c.ContactName = "Funk Master Flex";
            var updateSqlString = $"UPDATE CUSTOMERS SET ContactName ='{c.ContactName}'" + $"Where CustomerId='{c.CustomerID}'";
            using (var sqlCommand = new SqlCommand(updateSqlString,sqlConnection))
            {

                int affected = sqlCommand.ExecuteNonQuery();
                Console.WriteLine($"{affected} Records Updated");
            }
        }
        #endregion

        #region DeleteCustomer
        static void DeleteCustomer(SqlConnection sqlConnection, Customer c)
        {
            var sqlString = $"DELETE FROM CUSTOMERS WHERE CustomerID = '{c.CustomerID}'";


            using (var sqlCommand = new SqlCommand(sqlString, sqlConnection))
            {


                int affected = sqlCommand.ExecuteNonQuery();
                Console.WriteLine($"{affected} Records deleted with the ID: "+c.CustomerID);

            }
        }

        #endregion

        #region generateRandomCustomerID
        static string generateRandomCustomerID()
        {
            var rand = new Random();

            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.Append((char)rand.Next(65, 90));
            stringBuilder.Append((char)rand.Next(65, 90));
            stringBuilder.Append((char)rand.Next(65, 90));
            stringBuilder.Append((char)rand.Next(65, 90));
            stringBuilder.Append((char)rand.Next(65, 90));


            return stringBuilder.ToString();
        }
        #endregion
    }



    class Customer
    {
        public string CustomerID { get; set; }
        public string ContactName { get; set; }
        public string CompanyName { get; set; }
        public string City { get; set; }
        public string Country { get; set; }

    }





}


 




