using System;
using System.Collections.Generic;
using System.Linq;

namespace Lab09_Rabbit_Test
{
    
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }

    public class RabbitCollection 
    {
        public static List<Rabbit> rabbits = new List<Rabbit>();

        /*  
         *  Input totalYears to run the system
         *  Output will be the list of rabbits produced
         *  Every year, double number of rabbits
         *  Every year, increment age also of every rabbit
         *  
         *  Test data:
         *  Year 0      1 rabbit age 0
         *  Year 1      2 rabbits age 1,0
         *  Year 2      4 rabbits aged 2,1,0,0
         *  Year 3      8 rabbits aged 3,2,1,1,0,0,0,0 total age ==> 7 ==> length 8
            
                */
        public static (int CumulativeRabbitAge, int rabbitCount) MultiplyRabbits(int totalYears)
        {
            int totalRabbitAge = 0;
            rabbits = new List<Rabbit>();

            var rabbit = new Rabbit
            {
                RabbitID = 0,
                RabbitName = "Rabbit",
                Age = 0

            };
            rabbits.Add(rabbit);

            for (int i = 0; i < totalYears; i++)
            {

                foreach (Rabbit r in rabbits.ToArray())
                {
                   var newrabbit = new Rabbit();
                    rabbits.Add(newrabbit);
                    r.Age++;

                }
                
            }
            rabbits.ForEach(r => totalRabbitAge += r.Age);
            return (totalRabbitAge, rabbits.Count);
        }



        /*
         Can we change the test or create a second one which only starts to add new rabbits
         if their age is >=3
                  Test data
         Year 0    1 rabbit age 0
         Year 1    1            1
              2    1            2
              3    1            3
              4    2            4,0
              5    3            5,1,0
              6    4            6,2,1,0
              7    5            7,3,2,1,0
              8    7            8,4,3,2,1,0,0   ==> Cumulative years => 18

             */
        public static (int CumulativeRabbitAge, int rabbitCount) MultiplyRabbitsButOnlyWhenRabbitsAre3(int totalYears)
        {
            int totalRabbitAge = 0;
            rabbits = new List<Rabbit>();

            var rabbit = new Rabbit
            {
                RabbitID = 0,
                RabbitName = "Rabbit",
                Age = 0

            };
            rabbits.Add(rabbit);

            for (int i = 0; i < totalYears; i++)
            {

                foreach (Rabbit r in rabbits.ToArray())
                {
                    if (r.Age >= 3)
                    {
                        var newrabbit = new Rabbit();
                        rabbits.Add(newrabbit);
                        r.Age++;
                    }
                    else
                    {
                        r.Age++;
                    }

                }

            }
            rabbits.ForEach(r => totalRabbitAge += r.Age);
            return (totalRabbitAge, rabbits.Count);
        }

    }

    public class Rabbit
    { 
        public int RabbitID { get; set; }
        public string RabbitName { get; set; }
        public int Age { get; set; }

        public Rabbit() 
        {
            this.RabbitID = RabbitCollection.rabbits.Count + 1;
            this.RabbitName = "Rabbit" + RabbitID;
            Age = 0;
        }

    }


}
