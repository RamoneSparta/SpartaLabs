using System;

namespace Lab10_Events
{
    class Program
    {
        // Create delegate type
        delegate void MyDelegate();
        delegate int MyDelegate02(int x);
        // Create event (empty at the moment)
        static event MyDelegate MyEvent;
        static event MyDelegate02 MyEvent02;

        static void Main(string[] args)
        {
            // Add methods to event
            MyEvent += Method01;
            MyEvent += Method02;
            MyEvent -= Method02;
            MyEvent += Method02;

            MyEvent02 += Method03;

            // Fire/Trigger Event
            MyEvent();
            Console.WriteLine("Running Method03 and the answer is: "+MyEvent02(10));
        }

        static void Method01()
        {
            Console.WriteLine("Running Method01");
        }

        static void Method02()
        {
            Console.WriteLine("Running Method02");
        }

        static int Method03 (int x)
        {
            return x * x;
        }
    }
}
