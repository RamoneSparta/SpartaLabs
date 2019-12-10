using System;
using System.Collections.Generic;
using System.Linq;


namespace Simpson_HW
{
    class Program
    {
        static void Main(string[] args)
        {
            var list = new List<object>() { 1, "a", "b", 0, 15 };
            Simpson simpson = new Simpson();
            Console.WriteLine(simpson.areaApprox(6, 0, 12));
            Console.WriteLine(Simpson.GetIntegersFromList(list));
        }
    }

    /* Homework
 * Graph of y = X*X (Can hard code in)
 * Points 0,1,2,3,4,5,6 (Values of X (Also N))
 * Value of Y : 0,1,4,9,16,25,36
 * Goal approximate Area under graph
 * Simpson's Rule:
 * Area = ((MAX X - MIN X)/ 3N) * [Y(0th Item) + Y(Last item) + 4(odd index items ie 1,3,5) + 2(even indexed items ie 2,4)]
 *  
 *  public double GetAreaUnderGraphUsingSimposonsRule(int n, int min, int max, int difference)
 *  {n = 6, min = 0, max = 6,difference = (max-min/n)}
 *  Area = 60 (if n is 6)
 */
    public class Simpson
    {
        public double areaApprox (int n, int min, int max)
        {
            
            double dx = (max - min) / n;
            int[] x = new int[max];
            int[] y = new int[max];
            int oddIndex = 0;
            int evenIndex = 0;
            int count = 0;
            for (int i = 0; i < max; i++)
            {
                x[i] = (i + 1);
                y[i] = ((i + 1) * (i + 1));
            }
            foreach (int num in y)
            {
                if (count == (max - 1))
                {
 
                }
                else if (x[count] % 2 == 0)
                {
                    evenIndex += num;
                    count++;
                }
                else
                {
                    oddIndex += num;
                    count++;
                }
            }

            double area = (dx/3) * (y[min] + y[max-1] + (oddIndex*4) + (evenIndex*2));
            return Math.Round(area);
        }

        public static IEnumerable<int> GetIntegersFromList(List<object> listOfItems)
        {
            List<int> newListOfItems = new List<int>();
            foreach (int i in listOfItems)
            {
                newListOfItems.Add(i);
            }
            return newListOfItems;
        }
    }
}
