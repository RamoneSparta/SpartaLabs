using System;
using NUnit.Framework;
using Lab08_List_Dictionary_Task;
using Lab09_Rabbit_Test;

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
        public void Setup ()
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

        // The -1 means invalid/IDK what should be returned
       // The more test cases the more valid the code you're testing is, it could be a one off so more tests can test the validity of the method
        [TestCase(10,11,12,13,14, 1405)]
        [TestCase(1, 4, 9, 16, 25, 1604)]
        [TestCase(1, 2, 3, 4, 5, 280)]

        public void ArrayListDictionaryGetTotal(int a,int b, int c, int d, int e, int expected) 
        {
            // Call Method in the Other Project
            int actual = Lab_08_Array_List_Dictionary.Lab_08_Array_List_Dictionary_Get_Total(a,b,c,d,e);
            // Get Answer
            // See if its correct or not
            Assert.AreEqual(actual, expected);
        }


        [TestCase(3,7,8)]
        public void TestRabbitGrowth(int totalYears,int expectedCumulativeRabbitAge, int expectedRabbitCount)
        {
            // Arrange (Create instance here)

            //Act
            //Tuple(int Name 1, int Name 2)
            (int actualCumulativeAge, int actualRabbitCount) = RabbitCollection.MultiplyRabbits(totalYears);


            //Assert
            Assert.AreEqual( expectedCumulativeRabbitAge, actualCumulativeAge);
            Assert.AreEqual( expectedRabbitCount, actualRabbitCount);
        }

        [TestCase(4,4,2)]
        [TestCase(7,13,5)]
        [TestCase(8,18,7)]
        public void TestRabbitGrowthOnlyIncrementWhen3 (int totalYears, int expectedCumulativeRabbitAge, int expectedRabbitCount)
        {
            // Arrange (Create instance here)

            //Act
            //Tuple(int Name 1, int Name 2)
            (int actualCumulativeAge, int actualRabbitCount) = RabbitCollection.MultiplyRabbitsButOnlyWhenRabbitsAre3(totalYears);


            //Assert
            Assert.AreEqual(expectedCumulativeRabbitAge, actualCumulativeAge);
            Assert.AreEqual(expectedRabbitCount, actualRabbitCount);
        }
    }
}
