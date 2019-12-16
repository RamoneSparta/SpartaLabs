using System;
using NUnit.Framework;
using Lab08_List_Dictionary_Task;
using Lab09_Rabbit_Test;
using Lab14_LINQ;
using Lab20_Northwind_Products;
using Lab28_Fibonacci;
using Simpson_HW;

namespace NUNIT_TESTS
{
    //class Program
    //{
    //    static void Main(string[] args)
    //    {
    //        Console.WriteLine("Hello World!");
    //    }
    //}

    [TestFixture]
    class NUNIT_TESTS
    {
        // Annotations
        // The setup runs first
        [SetUp]
        public void Setup()
        {
            // eg. get data from database for all tests
        }


        [Test]
        public void RunThisTest()
        {
            // Arrange (data)

            // Act (Run The test)

            // Assert (true/fase ie pass/fail)

            Assert.AreEqual(true, true);
        }

        #region Get Dictionary Total
        // The -1 means invalid/IDK what should be returned
        // The more test cases the more valid the code you're testing is, it could be a one off so more tests can test the validity of the method
        [TestCase(10, 11, 12, 13, 14, 1405)]
        [TestCase(1, 4, 9, 16, 25, 1604)]
        [TestCase(1, 2, 3, 4, 5, 280)]

        public void ArrayListDictionaryGetTotal(int a, int b, int c, int d, int e, int expected)
        {
            // Call Method in the Other Project
            int actual = Lab_08_Array_List_Dictionary.Lab_08_Array_List_Dictionary_Get_Total(a, b, c, d, e);
            // Get Answer
            // See if its correct or not
            Assert.AreEqual(actual, expected);
        }
        #endregion

        #region Test Rabbit Growth
        [TestCase(3, 7, 8)]
        public void TestRabbitGrowth(int totalYears, int expectedCumulativeRabbitAge, int expectedRabbitCount)
        {
            // Arrange (Create instance here)

            //Act
            //Tuple(int Name 1, int Name 2)
            (int actualCumulativeAge, int actualRabbitCount) = RabbitCollection.MultiplyRabbits(totalYears);


            //Assert
            Assert.AreEqual(expectedCumulativeRabbitAge, actualCumulativeAge);
            Assert.AreEqual(expectedRabbitCount, actualRabbitCount);
        }
        #endregion

        #region Test Rabbit Growth (Only when 3)
        [TestCase(4, 4, 2)]
        [TestCase(7, 13, 5)]
        [TestCase(8, 18, 7)]
        public void TestRabbitGrowthOnlyIncrementWhen3(int totalYears, int expectedCumulativeRabbitAge, int expectedRabbitCount)
        {
            // Arrange (Create instance here)

            //Act
            //Tuple(int Name 1, int Name 2)
            (int actualCumulativeAge, int actualRabbitCount) = RabbitCollection.MultiplyRabbitsButOnlyWhenRabbitsAre3(totalYears);


            //Assert
            Assert.AreEqual(expectedCumulativeRabbitAge, actualCumulativeAge);
            Assert.AreEqual(expectedRabbitCount, actualRabbitCount);
        }
        #endregion

        #region TestNumberofNorthwindCustomers
        /*
         * create a class to read in Northwindcustomers and return the total
         * Then repeat for London Customers
         
             */
        [TestCase(null, 91)]
        [TestCase("London", 6)]

        public void TestNoOfNorthwindCustomers(string city, int expectedCustomers)
        {
            // Arrange
            // You can create a new instance here

            // Act
            int actualNoOfCustomers = GetCustomers.GetAllCustomers();
            int actualNoOfCustomersFromCity = GetCustomers.GetAllCustomersForCity(city);

            // Assert
            Assert.AreEqual(expectedCustomers, GetCustomers.GetCustomers2(city));
        }
        #endregion

        #region TestNumberofNorthwindProducts

        [TestCase(null, 77)]
        [TestCase("Tofu", 1)]
        [TestCase("Chai", 1)]
        [TestCase("Tourtière", 1)]

        public void TestOfNorthwindProducts(string productName, int expectedProducts)
        {
            // Arrange
            // You can create a new instance here

            // Act
            int actualNoOfProducts = Products.GetProducts(productName);


            // Assert
            Assert.AreEqual(expectedProducts, actualNoOfProducts);
        }

        [TestCase(50, 23)]
        public void TestOfNorthwindProductsForOrderLevel(int reOrderLv, int expectedProducts)
        {
            // Arrange
            // You can create a new instance here

            // Act
            int actualNoOfProducts = Products.GetProductAmount(reOrderLv);


            // Assert
            Assert.AreEqual(expectedProducts, actualNoOfProducts);
        }

        #endregion

        #region TestNoOfProductsForDifferentCases

        [TestCase(3)]
        public void TestNoOfProducts(int expectedProducts)
        {
            // arrange

            // act
            var actualProducts = Lab20_Northwind_Products.ProductsFromNorthwind.GetProducts();

            //assert
            Assert.AreEqual(expectedProducts, actualProducts);
        }

        [TestCase("p",3)]
        [TestCase("a", 2)]
        [TestCase("e", 1)]
        [TestCase("i", 3)]
        [TestCase("o", 2)]
        [TestCase("u", 1)]
        public void TestNoOfProductsStartingWithALetter(string letter, int expectedProducts)
        {
            // arrange

            // act
            var actualProducts = Lab20_Northwind_Products.ProductsFromNorthwind.GetProductsStartingWithALetter(letter);

            //assert
            Assert.AreEqual(expectedProducts, actualProducts);
        }


        [TestCase("p", 17)]
        [TestCase("a", 58)]
        [TestCase("e", 60)]
        [TestCase("i", 48)]
        [TestCase("o", 52)]
        [TestCase("u", 41)]
        [TestCase("d", 30)]
        public void TestNoOfProductsContainingLetter(string letter, int expectedProducts)
        {
            // arrange

            // act
            var actualProducts = Lab20_Northwind_Products.ProductsFromNorthwind.GetProductsContainingALetter(letter);

            //assert
            Assert.AreEqual(expectedProducts, actualProducts);
        }
        #endregion

        #region Fibonacci
        [TestCase(0, 0)]
        [TestCase(5, 3)]
        [TestCase(9, 21)]
        [TestCase(10, 34)]
        [TestCase(11, 55)]
        [TestCase(20, 4181)]
        public void TestFibonacci(int sequenceNumber, int expectedNumber)
        {
            Fibonacci fibonacci = new Fibonacci();

            var fibSequenceResult = fibonacci.ReturnFibonacciNthItemInSequence(sequenceNumber);

            Assert.AreEqual(expectedNumber, fibSequenceResult);

        }
        #endregion

        #region Simpson
        [TestCase(6,0,6,72)]
        [TestCase(3, 0, 6, 145)]
        [TestCase(12, 0, 12, 576)]
        [TestCase(6, 0, 12, 1153)]
        public void TestSimposon(int n, int min, int max, int actual)
        {
            Simpson simpson = new Simpson();

            double expected = simpson.areaApprox(n,min,max);

            Assert.AreEqual(expected, actual);
        }
        #endregion

        [TestCase(2, 5, false)]
        [TestCase(2, 10, true)]
        public void TestBoolMethod(int x, int y, bool expected) 
        {
            Fibonacci fibonacci = new Fibonacci();

            bool actual = fibonacci.ABoolMethod(x, y);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(2, 5, "Atleast one is odd")]
        [TestCase(2, 10, "Both are even")]
        public void TestStringMethod(int x, int y, string expected)
        {
            Fibonacci fibonacci = new Fibonacci();

            string actual = fibonacci.AStringMethod(x, y);

            Assert.AreEqual(expected, actual);
        }

    }
}

