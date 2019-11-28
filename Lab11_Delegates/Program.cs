using System;

namespace Lab11_Delegates
{
    class Program
    {
        // Create a matching delegate
        public delegate void Delegate01();

        // Non trivial delegate
        delegate int Delegate02(int x);
        static void Main(string[] args)
        {
            // Delegate can be referenced as a class
            // So we can use the "new" keyword

            var delegateInstance = new Delegate01(MyMethod01);
            // Call this
            delegateInstance(); // Calls the method

            // Trivial cases we can simplify (same result)
            // 1. omit 'new'
            Delegate01 delegateInstance2 = MyMethod01;
            delegateInstance2();
            // Its the same as above just a different way of writing it

            // Final trivial case 
            // Action Delegate is void and takes no parameters
            // Instead of deletate we use action (But can't take in a parameter)
            Action delegateInstance3 = MyMethod01; // Same as above but using "Action"
            delegateInstance3();

            // Action delegateInstance4 = MyMethod02; DOES NOT WORK BECAUSE METHOD2 HAS A RETURN TYPE 


            Delegate02 delegateInstance4 = (x)       =>          { return (x * x * x); };  // Lamda Expression
                                     //     ^Input Parameters    ^{     Code Body      }

            Delegate02 delegateInstance5 =   x   =>  x * x * x;  // If its a single values you can write it like this (Simplified)

            // You can call the delegate as a parameter within itself because it returns an integer
            Console.WriteLine(MyMethod03(delegateInstance5(10)));
            Console.WriteLine(MyMethod03(delegateInstance5(delegateInstance5(10))));

        }

        static void MyMethod01()
        {
            Console.WriteLine("Running Method01");
        }

        static string MyMethod02()
        {
            return("Running Method02");
        }

        static int MyMethod03(int x)
        {
            return x * x;
        }


    }
}
