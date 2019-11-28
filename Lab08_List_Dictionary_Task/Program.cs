using System;
using System.Collections.Generic;
using System.Linq;

namespace Lab08_List_Dictionary_Task
{
    
    class Program
    {
        static void Main(string[] args)
        {
            
        }
    }


       public class Lab_08_Array_List_Dictionary 
    {
        


        public static int Lab_08_Array_List_Dictionary_Get_Total(int a, int b, int c, int d, int e)
        {
            List<int> numList = new List<int>();
            Dictionary<int, int> numDictionary = new Dictionary<int, int>();
           
            a += 5;
            b += 5;
            c += 5;
            d += 5;
            e += 5;

            int[] numArray = {a,b,c,d,e };

            for (int i = 0; i < numArray.Length; i++)
            {
                var item = numArray[i] * numArray[i];
                numList.Add(item);
            }

            for (int i = 0; i < numList.Count; i++)
            {
                var item2 = numList[i] - 10;
                numDictionary.Add(i, item2);
            }

            
            return numDictionary.Values.Sum();
        }



 


    }

}
